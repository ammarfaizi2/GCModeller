﻿
Imports Microsoft.VisualBasic.ApplicationServices.Debugging.Logging
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Assembly.NCBI
Imports SMRUCC.genomics.Assembly.NCBI.GenBank
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.GBFF.Keywords
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.GBFF.Keywords.FEATURES
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.TabularFormat
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.NtMapping
Imports SMRUCC.genomics.SequenceModel.FASTA
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime.Interop
Imports featureLocation = SMRUCC.genomics.Assembly.NCBI.GenBank.GBFF.Keywords.FEATURES.Location
Imports gbffFeature = SMRUCC.genomics.Assembly.NCBI.GenBank.GBFF.Keywords.FEATURES.Feature

<Package("annotation.genbank_kit", Category:=APICategories.UtilityTools, Publisher:="xie.guigang@gcmodeller.org")>
Module genbankKit

    <ExportAPI("read.genbank")>
    Public Function readGenbank(file As String,
                                Optional repliconTable As Boolean = False,
                                Optional env As Environment = Nothing) As Object

        If Not file.FileExists(True) Then
            Return Internal.debug.stop($"invalid file resource: '{file}'!", env)
        End If

        If repliconTable Then
            Return GenBank.loadRepliconTable(file)
        Else
            Return GBFF.File.Load(file)
        End If
    End Function

    <ExportAPI("write.genbank")>
    Public Function writeGenbank(gb As GBFF.File, file$, Optional env As Environment = Nothing) As Object
        If gb Is Nothing Then
            Return Internal.debug.stop("write data is nothing!", env)
        Else
            Return gb.Save(file)
        End If
    End Function

    <ExportAPI("as.genbank")>
    <RApiReturn(GetType(GBFF.File))>
    Public Function asGenbank(<RRawVectorArgument> x As Object, Optional env As Environment = Nothing) As Object
        If x Is Nothing Then
            env.AddMessage("The genome information data object is nothing!", MSG_TYPES.WRN)
            Return Nothing
        End If

        If TypeOf x Is PTT Then
            Return DirectCast(x, PTT).CreateGenbankObject
        Else
            Return Internal.debug.stop(New NotImplementedException(x.GetType.FullName), env)
        End If
    End Function

    <ExportAPI("add.origin.fasta")>
    Public Function addNtOrigin(gb As GBFF.File, nt As FastaSeq, Optional mol_type$ = "genomic DNA") As GBFF.File
        Dim source As New gbffFeature With {
            .KeyName = "source",
            .Location = New featureLocation With {
                .Complement = False,
                .Locations = {
                    New RegionSegment With {.Left = 1, .Right = nt.Length}
                }
            }
        }

        gb.Origin = New ORIGIN With {
            .Headers = nt.Headers,
            .SequenceData = nt.SequenceData
        }
        gb.Features.SetSourceFeature(source)

        source.SetValue(FeatureQualifiers.mol_type, mol_type)
        source.SetValue(FeatureQualifiers.organism, nt.Title)

        Return gb
    End Function

    <ExportAPI("getRNA.fasta")>
    Public Function getRNASeq(gb As GBFF.File) As FastaFile
        Dim rnaGenes = gb.Features.Where(Function(region) InStr(region.KeyName, "RNA") > 0).ToArray
        Dim fasta As FastaSeq() = rnaGenes _
            .Select(Function(rna)
                        Dim attrs = {rna.Query(FeatureQualifiers.locus_tag) & " " & rna.KeyName & "|" & rna.Query(FeatureQualifiers.product)}
                        Dim fa As New FastaSeq With {
                            .Headers = attrs,
                            .SequenceData = rna.SequenceData
                        }

                        Return fa
                    End Function) _
            .ToArray

        Return New FastaFile(fasta)
    End Function

    <ExportAPI("add.protein.fasta")>
    Public Function addproteinSeq(gb As GBFF.File, <RRawVectorArgument> proteins As Object, Optional env As Environment = Nothing) As Object
        Dim seqs = GetFastaSeq(proteins)

        If seqs Is Nothing Then
            Return Internal.debug.stop("no protein sequence data provided!", env)
        End If

        Dim seqTable = seqs.ToDictionary(Function(fa) fa.Title.Split.First)
        Dim geneId As String
        Dim prot As FastaSeq

        For Each feature In gb.Features.Where(Function(a) a.KeyName = "CDS")
            geneId = feature.Query(FeatureQualifiers.locus_tag)
            prot = seqTable.TryGetValue(geneId)

            If prot Is Nothing Then
                env.AddMessage($"missing protein sequence for '{geneId}'...", MSG_TYPES.WRN)
                Continue For
            End If

            feature.SetValue(FeatureQualifiers.translation, prot.SequenceData)
            feature.SetValue(FeatureQualifiers.product, prot.Title)
        Next

        Return gb
    End Function

    <ExportAPI("add.RNA.gene")>
    Public Function addRNAGene(gb As GBFF.File, <RRawVectorArgument> RNA As Object, Optional env As Environment = Nothing) As Object
        If RNA Is Nothing Then
            Return gb
        End If

        Dim rnaMaps As Dictionary(Of String, BlastnMapping)
        Dim geneId As String
        Dim mapHit As BlastnMapping
        Dim type, product As String
        Dim RNAfeature As gbffFeature

        If TypeOf RNA Is BlastnMapping() Then
            rnaMaps = DirectCast(RNA, BlastnMapping()) _
                .GroupBy(Function(map) map.Reference) _
                .ToDictionary(Function(map) map.Key,
                              Function(map)
                                  Return map.First
                              End Function)
        ElseIf TypeOf RNA Is pipeline AndAlso DirectCast(RNA, pipeline).elementType Like GetType(BlastnMapping) Then
            rnaMaps = DirectCast(RNA, pipeline) _
                .populates(Of BlastnMapping) _
                .GroupBy(Function(map) map.Reference) _
                .ToDictionary(Function(map) map.Key,
                              Function(map)
                                  Return map.First
                              End Function)
        Else
            Return Internal.debug.stop($"invalid data source type: '{RNA.GetType.FullName}'!", env)
        End If

        For Each feature In gb.Features.Where(Function(a) a.KeyName = "gene")
            geneId = feature.Query(FeatureQualifiers.locus_tag)

            If rnaMaps.ContainsKey(geneId) Then
                mapHit = rnaMaps(geneId)
                type = mapHit.ReadQuery.GetTagValue.Value
                product = type.GetTagValue("|").Value
                type = type.Split("|"c).First

                RNAfeature = New gbffFeature With {.KeyName = type, .Location = feature.Location}
                RNAfeature.SetValue(FeatureQualifiers.product, product)
                RNAfeature.SetValue(FeatureQualifiers.locus_tag, geneId)

                Call gb.Features.Delete(type, geneId)
                Call gb.Features.Delete("CDS", geneId)
                Call gb.Features.Add(RNAfeature)
            End If
        Next

        Return gb
    End Function
End Module
