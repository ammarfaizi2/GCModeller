﻿Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Text.Parser.HtmlParser
Imports SMRUCC.genomics.ComponentModel
Imports r = System.Text.RegularExpressions.Regex

Namespace Regprecise

    Public Class OperonQuery : Inherits WebQuery(Of String)

        Public Sub New(<CallerMemberName>
                       Optional cache As String = Nothing,
                       Optional interval As Integer = -1,
                       Optional offline As Boolean = False)

            MyBase.New(url:=Function(s) s,
                       contextGuid:=Function(s) s,
                       parser:=AddressOf OperonParser,
                       prefix:=Nothing,
                       cache:=cache,
                       interval:=interval,
                       offline:=offline
                   )
        End Sub

        Friend Shared Function OperonParser(page As String, null As Type) As Object
            Dim tokens$()
            Dim locus As Dictionary(Of String, String)

            page = r.Match(page, "<table id=""operontbl"">.+?</table>", RegexICSng).Value
            tokens = r.Matches(page, "<tr>.+?</tr>", RegexOptions.IgnoreCase Or RegexOptions.Singleline).ToArray
            locus = locusParser(page)
            tokens = (From row As String In tokens Where InStr(row, "<div class=""operon"">") > 0 Select row).ToArray

            Dim operons As Operon() = tokens _
                .Select(Function(value)
                            Return operonParser(value, locus)
                        End Function) _
                .ToArray

            Return operons
        End Function

        Private Shared Function operonParser(value$, locus As Dictionary(Of String, String)) As Operon
            Dim genes() = r.Matches(value, "<span>.+?</span>", RegexICSng).ToArray
            genes = (From s As String In genes Where InStr(s, "Locus", CompareMethod.Text) > 0 Select s).ToArray

            Try
                Dim list_genes As RegulatedGene() = genes _
                    .Select(Function(s) geneParser(s, locus)) _
                    .ToArray
                Return New Operon With {
                    .members = list_genes
                }
            Catch ex As Exception
                ex = New Exception(genes.GetJson, ex)
                Throw ex
            End Try
        End Function

        '<span> Locus tag: AB57_3864<br>Name: yciC<br>Funciton: Putative metal chaperone, GTPase Of COG0523 family
        '</span>

        Private Shared Function geneParser(value$, locus As Dictionary(Of String, String)) As RegulatedGene
            value = Mid(value, 8)
            value = Mid(value, 1, Len(value) - 8)
            value = value.TrimNewLine("")
            value = value.Replace(vbTab, "").Trim

            Dim tokens As String() = r.Split(value, "<\s*br\s*/>", RegexOptions.IgnoreCase)
            Dim locusId As String = tokens(Scan0)
            Dim name As String = tokens(1)
            Dim func As String = tokens(2)

            locusId = Mid(locusId, 11).Trim
            name = Mid(name, 6).Trim
            func = Mid(func, 10).Trim

            Dim vmssid As String = locus.TryGetValue(locusId)
            Dim gene As New RegulatedGene With {
                .description = func,
                .locusId = locusId,
                .name = name,
                .vimssId = vmssid
            }

            Return gene
        End Function

        Private Shared Function locusParser(page As String) As Dictionary(Of String, String)
            Dim locus As String() = Regex.Matches(page, "<a href="".+?"">.+?</a>", RegexOptions.IgnoreCase Or RegexOptions.Singleline).ToArray
            Dim dict = (From s As String In locus
                        Let id As String = s.GetValue, url As String = s.href
                        Let vimssid As String = MicrobesOnline.locusId(url)
                        Where Not String.IsNullOrEmpty(vimssid)
                        Select id, vimssid
                        Group By id Into Group) _
                            .ToDictionary(Function(x) x.id, Function(x) x.Group.First.vimssid)
            Return dict
        End Function
    End Class
End Namespace