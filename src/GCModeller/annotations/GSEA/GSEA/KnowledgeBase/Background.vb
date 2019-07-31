﻿Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository

''' <summary>
''' 假设基因组是有许多个功能聚类的集合构成的
''' </summary>
<XmlRoot("background", [Namespace]:="http://gcmodeller.org/GSEA/background.xml")>
Public Class Background : Inherits XmlDataModel
    Implements INamedValue

    Public Property name As String Implements IKeyedEntity(Of String).Key
    Public Property comments As String
    Public Property build As Date = Now
    ''' <summary>
    ''' The number of genes in this background genome.
    ''' </summary>
    ''' <returns></returns>
    Public Property size As Integer

    <XmlElement>
    Public Property clusters As Cluster()

    Public Overrides Function ToString() As String
        Return name
    End Function
End Class
