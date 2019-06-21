﻿#Region "Microsoft.VisualBasic::8b5b82af3a4f3d17a4913390d7ed68b3, Bio.Assembly\Assembly\KEGG\DBGET\LinkDB\Pathways.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xie (genetics@smrucc.org)
'       xieguigang (xie.guigang@live.com)
' 
' Copyright (c) 2018 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
' 
' 
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
' 
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
' 
' You should have received a copy of the GNU General Public License
' along with this program. If not, see <http://www.gnu.org/licenses/>.



' /********************************************************************************/

' Summaries:

'     Module Pathways
' 
'         Constructor: (+1 Overloads) Sub New
'         Function: AllEntries, Downloads, URLProvider
' 
' 
' /********************************************************************************/

#End Region

Imports System.Text.RegularExpressions
Imports System.Threading
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Terminal.ProgressBar
Imports Microsoft.VisualBasic.Text.Xml.Models
Imports SMRUCC.genomics.Assembly.KEGG.DBGET.bGetObject
Imports SMRUCC.genomics.Assembly.KEGG.WebServices

Namespace Assembly.KEGG.DBGET.LinkDB

    ''' <summary>
    ''' LinkDB Search for KEGG pathways
    ''' </summary>
    Public Module Pathways

        ReadOnly sleep% = 2500

        Sub New()
            With App.GetVariable("/sleep")
                If Not .StringEmpty Then
                    sleep = Val(.ByRef)
                End If

                If sleep <= 0 Then
                    sleep = 2500
                End If
            End With
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="code">The species code in KEGG database</param>
        ''' <returns></returns>
        Public Function AllEntries(code$, Optional cache$ = "./.kegg/pathways/", Optional offline As Boolean = False) As ListEntry()
            Static handlers As New Dictionary(Of String, PathwayEntryQuery)

            Dim query As PathwayEntryQuery = handlers.ComputeIfAbsent(
                key:=cache,
                lazyValue:=Function()
                               Return New PathwayEntryQuery(cache, interval:=sleep, offline:=offline)
                           End Function)

            Return query.Query(Of ListEntry())(code, ".html")
        End Function

        ''' <summary>
        ''' 下载某一个物种所注释的代谢途径的数据
        ''' </summary>
        ''' <param name="sp"></param>
        ''' <param name="EXPORT"></param>
        ''' <returns></returns>
        Public Function Downloads(sp$, Optional EXPORT$ = "./LinkDB-pathways/", Optional cache$ = "./.kegg/pathways/", Optional offline As Boolean = False) As String()
            Dim entries As New List(Of ListEntry)
            Dim briteTable As Dictionary(Of String, BriteHEntry.Pathway) = BriteHEntry.Pathway.LoadDictionary
            Dim progress As New ProgressBar("KEGG LinkDB Downloads KEGG Pathways....", 1, CLS:=True)
            Dim failures As New List(Of String)

            ' VBDebugger.Mute = True

            Dim all As ListEntry() = AllEntries(sp, cache, offline:=offline).ToArray
            Dim url$
            Dim i As VBInteger = 1

            Static handlers As New Dictionary(Of String, PathwayMapDownloader)

            Dim query As PathwayMapDownloader = handlers.ComputeIfAbsent(
                key:=cache,
                lazyValue:=Function()
                               Return New PathwayMapDownloader(cache, interval:=sleep, offline:=offline)
                           End Function)

            For Each entry As ListEntry In all
                Dim imageUrl = String.Format("http://www.genome.jp/kegg/pathway/{0}/{1}.png", sp, entry.EntryID)
                Dim img As String = EXPORT & $"/{entry.EntryID}.png"
                Dim bCode As String = Regex.Match(entry.EntryID, "\d+").Value
                Dim xml$ = $"{EXPORT}/{briteTable(bCode).GetPathCategory}/{entry.EntryID}.Xml"
                Dim data As Pathway = query.Query(Of Pathway)(entry, ".html")

                If img.FileLength < 1024 Then
                    Call imageUrl.DownloadFile(img)
                End If

                If data Is Nothing Then
                    failures += entry.EntryID
                Else
                    entries += entry
                    url = $"http://www.genome.jp/dbget-bin/get_linkdb?-t+genes+path:{entry.EntryID}"
                    data.genes = url.LinkDbEntries(cache:=$"{cache}/linkdb/", offline:=offline) _
                        .Select(Function(t) New NamedValue(t.Key, t.Value)) _
                        .ToArray

                    Call data.SaveAsXml(xml)
                End If

                Call Thread.Sleep(sleep)
EXIT_LOOP:      Call progress.SetProgress(++i / all.Length * 100, entry.GetJson)
            Next

            ' VBDebugger.Mute = False

            Call progress.Dispose()
            Call entries.GetJson.SaveTo(EXPORT & $"/{sp}.json")

            Return failures
        End Function
    End Module
End Namespace
