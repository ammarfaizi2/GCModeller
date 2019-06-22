﻿Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Text.Parser.HtmlParser
Imports Microsoft.VisualBasic.Text.Xml.Models
Imports SMRUCC.genomics.ComponentModel
Imports SMRUCC.genomics.Data.Regtransbase.WebServices
Imports r = System.Text.RegularExpressions.Regex

Namespace Regprecise

    Friend Class RegulatorQuery : Inherits WebQuery(Of String)

        Public Sub New(<CallerMemberName>
                       Optional cache As String = Nothing,
                       Optional interval As Integer = -1,
                       Optional offline As Boolean = False)

            MyBase.New(url:=AddressOf UrlParser,
                       contextGuid:=AddressOf NameParser,
                       parser:=AddressOf More,
                       prefix:=Nothing,
                       cache:=cache,
                       interval:=interval,
                       offline:=offline
                   )
        End Sub

        ' 因为在这里是进行Web请求，所以为了降低目标服务器的压力，在这里可以牺牲掉代码的执行效率

        Private Shared Function UrlParser(str As String) As String
            Return basicParser(str, Nothing).regulator.text
        End Function

        Private Shared Function NameParser(str As String) As String
            Return basicParser(str, Nothing).regulator.name
        End Function

        ''' <summary>
        ''' 解析基本的信息
        ''' </summary>
        ''' <param name="str"></param>
        ''' <returns></returns>
        Friend Shared Function basicParser(str As String, regulator As Regulator) As Regulator
            Dim list$() = r.Matches(str, "<td.+?</td>").ToArray
            Dim i As VBInteger = Scan0

            If regulator Is Nothing Then
                regulator = New Regulator
            End If

            regulator.type = If(InStr(list(++i), " RNA "), Types.RNA, Types.TF)

            Dim entry As String = r.Match(list(++i), "href="".+?"">.+?</a>").Value
            Dim url As String = "http://regprecise.lbl.gov/RegPrecise/" & entry.href
            regulator.regulator = New NamedValue With {
                .name = RegulomeQuery.GetsId(entry),
                .text = url
            }
            regulator.effector = __getTagValue(list(++i))
            regulator.pathway = __getTagValue(list(++i))

            Return regulator
        End Function

        Private Shared Function More(html$, null As Type) As Object
            Dim infoTable$ = html.Match("<table class=""proptbl"">.+?</table>", RegexOptions.Singleline)
            Dim properties$() = r.Matches(infoTable, "<tr>.+?</tr>", RegexICSng).ToArray
            Dim i As VBInteger = 1
            Dim regulator As New Regulator

            With r.Match(html, "\[<a href="".+?"">see more</a>\]", RegexOptions.IgnoreCase).Value
                If Not .StringEmpty Then
                    regulator.infoURL = $"http://regprecise.lbl.gov/RegPrecise/{ .href}"
                End If
            End With

            If regulator.type = Types.TF Then
                Dim LocusTag As String = r _
                    .Match(properties(++i), "href="".+?"">.+?</a>", RegexOptions.Singleline) _
                    .Value
                regulator.locus_tag = New NamedValue With {
                    .name = RegulomeQuery.GetsId(LocusTag),
                    .text = LocusTag.href
                }
                regulator.family = __getTagValue_td(properties(++i).Replace("<td>Regulator family:</td>", ""))
            Else
                Dim Name As String = r.Matches(properties(++i), "<td>.+?</td>", RegexICSng).ToArray.Last
                Name = Mid(Name, 5)
                Name = Mid(Name, 1, Len(Name) - 5)
                regulator.locus_tag = New NamedValue With {
                    .name = Name,
                    .text = ""
                }
                regulator.family = r.Match(infoTable, "<td class=""[^""]+?"">RFAM:</td>[^<]+?<td>.+?</td>", RegexOptions.Singleline).Value
                regulator.family = __getTagValue_td(regulator.family)
            End If

            regulator.regulationMode = __getTagValue_td(properties(++i))
            regulator.biological_process = __getTagValue_td(properties(++i))

            Dim regulogEntry$ = r.Match(properties(i + 1), "href="".+?"">.+?</a>", RegexOptions.Singleline).Value
            Dim url As String = "http://regprecise.lbl.gov/RegPrecise/" & regulogEntry.href

            regulator.regulog = New NamedValue With {
                .name = RegulomeQuery _
                    .GetsId(regulogEntry) _
                    .TrimNewLine("") _
                    .Replace(vbTab, "") _
                    .Trim,
                .text = url
            }

            Dim exportServletLnks$() = __exportServlet(html)
            regulator.operons = OperonQuery.OperonParser(html, Nothing)
            regulator.regulatorySites = MotifFasta.Parse(url:=exportServletLnks.ElementAtOrDefault(1))

            Return regulator
        End Function

        Private Shared Function __getTagValue_td(strData As String) As String
            strData = r.Match(strData, "<td>.+?</td>", RegexOptions.Singleline).Value
            If String.IsNullOrEmpty(Trim(strData)) Then
                Return ""
            End If
            strData = Mid(strData, 5)
            strData = Mid(strData, 1, Len(strData) - 5)
            Return strData
        End Function

        Private Shared Function __exportServlet(pageContent As String) As String()
            Dim url As String = Regex.Match(pageContent, "<table class=""tblexport"">.+?</table>", RegexOptions.Singleline).Value
            Dim links$() = r.Matches(url, "<tr>.+?</tr>", RegexOptions.Singleline + RegexOptions.IgnoreCase).ToArray
            links = links _
                .Select(Function(s) Regex.Match(s, "href="".+?""><b>DOWNLOAD</b>").Value) _
                .Select(Function(s) "http://regprecise.lbl.gov/RegPrecise/" & s.href) _
                .ToArray
            Return links
        End Function

        Private Shared Function __getTagValue(s As String) As String
            s = Regex.Match(s, """>.+?</td>").Value
            s = Mid(s, 3)
            s = Mid(s, 1, Len(s) - 5)
            Return Trim(s)
        End Function
    End Class
End Namespace