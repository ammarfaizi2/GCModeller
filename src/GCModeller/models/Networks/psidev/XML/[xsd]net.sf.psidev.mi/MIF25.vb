﻿#Region "Microsoft.VisualBasic::f73d4d3afaafea8f0ccb67fdfb7e2ea0, ..\GCModeller\data\ExternalDBSource\string-db\[xsd]net.sf.psidev.mi\MIF25.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
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
Imports SMRUCC.genomics.Model.psidev.MIF25.Nodes

Namespace XML

    ' 请勿再修改本命名空间之中的所有Xml序列化对象的格式定义了，这个是用来读取string-db数据库的官方文档之中所介绍的格式

    ''' <summary>
    ''' net:sf:psidev:mi/http://psidev.sourceforge.net/mi/rel25/src/MIF25.xsd
    ''' </summary>
    <XmlRoot("entrySet", Namespace:="net:sf:psidev:mi")>
    Public Class EntrySet

        <XmlAttribute("level")> Public Property Level As Integer
        <XmlAttribute("version")> Public Property Version As Integer

        <XmlElement("entry")> Public Property Entries As Entry()
            Get
                Return _innerList
            End Get
            Set(value As Entry())
                _innerList = value
                If value.IsNullOrEmpty Then
                    _FirstInstance = Nothing
                Else
                    _FirstInstance = value(Scan0)
                End If
            End Set
        End Property

        Dim _innerList As Entry()
        ''' <summary>
        ''' 仅当<see cref="_innerList"/>之中包含有元素的时候，这个变量才不为空值
        ''' </summary>
        Public ReadOnly Property FirstInstance As Entry

        Public Function GetInteractor(Id As Integer) As Interactor
            If _FirstInstance Is Nothing Then
                Return Nothing
            End If
            If Entries.Length = 1 Then
                Return _FirstInstance.GetInteractor(handle:=Id)
            Else
                For Each entry In _innerList
                    Dim value As Interactor = entry.GetInteractor(Id)
                    If Not value Is Nothing Then
                        Return value
                    End If
                Next

                Return Nothing
            End If
        End Function
    End Class
End Namespace
