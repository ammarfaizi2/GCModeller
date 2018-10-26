﻿Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository
Imports SMRUCC.genomics.Metagenomics

Namespace v2

    <XmlType(NameOf(VirtualCell), [Namespace]:=SMRUCC.genomics.LICENSE.GCModeller)>
    Public Class VirtualCell : Inherits XmlDataModel

        Public Property Taxonomy As Taxonomy
        Public Property MetabolismStructure As MetabolismStructure

        <XmlNamespaceDeclarations()>
        Public xmlns As New XmlSerializerNamespaces

        Sub New()
            Call xmlns.Add("GCModeller", LICENSE.GCModeller)
        End Sub

        Public Overrides Function ToString() As String
            Return Taxonomy.ToString
        End Function

    End Class

    Public Class MetabolismStructure : Inherits XmlDataModel

        Public Property Compounds As Compound()
        Public Property Reactions As Reaction()
        Public Property Pathways As Pathway()

    End Class

    Public Class Compound : Implements INamedValue

        <XmlAttribute> Public Property ID As String Implements IKeyedEntity(Of String).Key
        <XmlAttribute> Public Property name As String

        <XmlArray>
        Public Property otherNames As String()

    End Class

    Public Class Reaction : Implements INamedValue

        <XmlAttribute> Public Property ID As String Implements IKeyedEntity(Of String).Key
        <XmlAttribute> Public Property name As String

        <XmlText>
        Public Property Equation As String

    End Class

    Public Class Pathway : Implements INamedValue

        <XmlAttribute> Public Property ID As String Implements IKeyedEntity(Of String).Key
        <XmlAttribute> Public Property name As String

        Public Property Enzymes As Enzyme()

    End Class

    Public Class Enzyme : Implements INamedValue

        Public Property geneID As String Implements IKeyedEntity(Of String).Key
        Public Property KO As String
        Public Property catalysis As Catalysis()

    End Class

    Public Class Catalysis

        ''' <summary>
        ''' The reaction id
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute> Public Property Reaction As String
        <XmlAttribute> Public Property coefficient As Double

        <XmlText>
        Public Property comment As String

    End Class
End Namespace