﻿Imports System.IO
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Annotation.Ptf
Imports SMRUCC.genomics.Assembly.Uniprot.XML

Public Module AnnotationCache

    <Extension>
    Public Sub WritePtfCache(proteins As IEnumerable(Of entry), cache As TextWriter, Optional includesNCBITaxonomy As Boolean = False)
        For Each protein As entry In proteins
            Call cache.WriteLine(PtfFile.ToString(toPtf(protein, includesNCBITaxonomy)))
        Next
    End Sub

    Private Function toPtf(protein As entry, includesNCBITaxonomy As Boolean) As ProteinAnnotation
        Dim dbxref As New Dictionary(Of String, String())
        Dim refList As String()

        dbxref.Add("synonym", protein.accessions)

        For Each refDb As String In {"KEGG", "KO", "GO", "Pfam", "RefSeq", "EC", "InterPro", "BioCyc", "eggNOG"}
            If protein.xrefs.ContainsKey(refDb) Then
                refList = protein.xrefs(refDb) _
                    .Select(Function(ref) ref.id) _
                    .ToArray

                Call dbxref.Add(refDb.ToLower, refList)
            End If
        Next

        If includesNCBITaxonomy Then
            Dim ncbi_id As String = protein.NCBITaxonomyId

            If Not ncbi_id.StringEmpty Then
                Call dbxref.Add("ncbi_taxonomy", {ncbi_id})
            End If
        End If

        Return New ProteinAnnotation With {
            .geneId = protein.accessions(Scan0),
            .description = protein.proteinFullName,
            .attributes = dbxref
        }
    End Function

    <Extension>
    Public Sub SplitAnnotations(proteins As IEnumerable(Of ProteinAnnotation), key As String, outputdir As String)
        Dim [handles] As New Dictionary(Of String, StreamWriter) From {
            {"na", $"{outputdir}/na.ptf".OpenWriter(bufferSize:=1024)}
        }

        For Each protein As ProteinAnnotation In proteins
            If Not protein.attributes.ContainsKey(key) Then
                Call [handles]("na").WriteLine(PtfFile.ToString(protein))
            Else
                For Each name As String In protein.attributes(key)
                    If Not [handles].ContainsKey(name) Then
                        [handles].Add(name, $"{outputdir}/{name.NormalizePathString}.ptf".OpenWriter(bufferSize:=1024))
                    End If

                    [handles](name).WriteLine(PtfFile.ToString(protein))
                Next
            End If
        Next

        For Each key In [handles].Keys
            Call [handles](key).Flush()
            Call [handles](key).Dispose()
        Next
    End Sub
End Module
