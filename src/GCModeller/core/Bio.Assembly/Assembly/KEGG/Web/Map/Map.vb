﻿#Region "Microsoft.VisualBasic::3e3b400449f08b97aa2769f02e1d4026, ..\core\Bio.Assembly\Assembly\KEGG\Web\Map\Map.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
'       xie (genetics@smrucc.org)
' 
' Copyright (c) 2016 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Assembly.KEGG.DBGET.BriteHEntry
Imports r = System.Text.RegularExpressions.Regex

Namespace Assembly.KEGG.WebServices

    Public Class Map

        <XmlElement> Public Property Areas As Area()

        Public Overrides Function ToString() As String
            Return Areas.GetJson
        End Function

        Const data$ = "<map name=""mapdata"">.+?</map>"

        Public Shared Function ParseHTML(url$) As Map
            Dim html$ = url.GET
            Dim map$ = r.Match(html, data, RegexICSng).Value
            Dim areas = map.lTokens


        End Function
    End Class

    Public Class Area

        <XmlAttribute> Public Property shape As String
        ''' <summary>
        ''' 位置坐标信息
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute> Public Property coords As String
        <XmlAttribute> Public Property href As String
        <XmlAttribute> Public Property title As String

        Public ReadOnly Property Type As String
            Get
                If InStr(href, "/dbget-bin/www_bget") = 1 Then
                    With IdList.First
                        If .IsPattern("C\d+") Then
                            Return NameOf(Compound)
                        ElseIf .IndexOf(":"c) > -1 Then
                            Return "Gene"
                        Else
                            Throw New NotImplementedException
                        End If
                    End With
                ElseIf InStr(href, "/kegg-bin/show_pathway") = 1 Then
                    Return NameOf(Pathway)
                Else
                    Throw New NotImplementedException
                End If
            End Get
        End Property

        Public ReadOnly Property IdList As String()
            Get
                Return href.Split("?"c).Last.Split("+"c)
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class
End Namespace
