﻿#Region "Microsoft.VisualBasic::b3cb1947830d5be69e9b65062790bd48, ..\GCModeller\analysis\annoTools\DataMySql\CEG\Annotation.vb"

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
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Data.csv.Extensions
Imports Microsoft.VisualBasic.Data.csv.DocumentStream
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic

Namespace CEG

    ''' <summary>
    ''' CEG看家基因的功能注释数据
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Annotation : Implements sIdEnumerable

        ''' <summary>
        ''' 本看家基因在CEG数据库之中的唯一编号
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property GId As String Implements sIdEnumerable.Identifier
        ''' <summary>
        ''' 基因名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property GeneName As String
        ''' <summary>
        ''' 功能描述
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Description As String

        Public Overrides Function ToString() As String
            Return String.Format("({0}){1}", GeneName, Description)
        End Function

        Public Shared Function LoadDocument(Path As String) As Annotation()
            Dim CsvObject As File = File.Load(Path)
            Dim Title As String() = New String() {"GId", "GeneName", "Description"}

            Call CsvObject.Insert(-1, CType(Title, RowObject))
            Dim Data = AsDataSource(Of Annotation)(CsvObject, False)
            Return Data
        End Function
    End Class
End Namespace