﻿Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Assembly.Uniprot.Web
Imports SMRUCC.genomics.Assembly.Uniprot.XML
Imports SMRUCC.genomics.Data.Xfam.Pfam.PfamString
Imports Protein = SMRUCC.genomics.Assembly.Uniprot.XML.entry

Partial Module CLI

    <ExportAPI("/UniProt.domains")>
    <Usage("/UniProt.domains /in <uniprot.Xml> [/map <maps.tab/tsv> /out <proteins.csv>]")>
    <Description("Export the protein structure domain annotation table from UniProt database dump.")>
    Public Function UniProtXmlDomains(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim out$ = args("/out") Or $"{[in].TrimSuffix}.domains.csv"
        Dim proteins As PfamString()

        With args <= "/map"
            If .FileExists Then
                Dim mappings = Retrieve_IDmapping.MappingReader(.ref)

                With UniProtXML.LoadDictionary([in])
                    proteins = mappings _
                        .Where(Function(ID)
                                   Return ID.Value.Any(Function(s) .ContainsKey(s))
                               End Function) _
                        .Select(Function(map)
                                    Dim ID As String = map.Key
                                    Dim uniprotID$ = map.Value _
                                        .Where(Function(acc) .ContainsKey(acc)) _
                                        .First
                                    Dim protein As PfamString = .ref(uniprotID).UniProt2Pfam.First
                                    protein.ProteinId = ID
                                    Return protein
                                End Function) _
                        .ToArray
                End With
            Else
                proteins = UniProtXML _
                    .EnumerateEntries(path:=[in]) _
                    .Select(AddressOf UniProt2Pfam) _
                    .IteratesALL _
                    .ToArray
            End If
        End With

        Return proteins _
            .SaveTo(out) _
            .CLICode
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    <Extension>
    Private Iterator Function UniProt2Pfam(protein As Protein) As IEnumerable(Of PfamString)
        For Each ID As String In protein.accessions
            Yield New PfamString With {
                .ProteinId = ID,
                .Description = protein.proteinFullName,
                .Length = protein.sequence.length,
                .Domains = protein.features _
                    .SafeQuery _
                    .Where(Function(f) f.type = "domain") _
                    .Select(Function(feature) feature.description) _
                    .Distinct _
                    .ToArray,
                .PfamString = protein.features _
                    .SafeQuery _
                    .Where(Function(f) f.type = "domain") _
                    .OrderBy(Function(feature)
                                 Return feature.location.begin.position
                             End Function) _
                    .Select(Function(feature)
                                Return $"{feature.description}({feature.location.begin.position}|{feature.location.end.position})"
                            End Function) _
                    .ToArray
            }
        Next
    End Function
End Module