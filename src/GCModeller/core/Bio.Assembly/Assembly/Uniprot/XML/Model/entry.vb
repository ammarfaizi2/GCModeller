﻿Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Assembly.Uniprot.XML

    ''' <summary>
    ''' 因为<see cref="accessions"/>可能会出现多个值，所以会需要使用
    ''' <see cref="entry.ShadowCopy()"/>函数来解决实体多态的问题。
    ''' 经过shadow copy之后可以使用主键<see cref="accession"/>来创建字典
    ''' </summary>
    Public Class entry : Implements INamedValue

        <XmlAttribute> Public Property dataset As String
        <XmlAttribute> Public Property created As String
        <XmlAttribute> Public Property modified As String
        <XmlAttribute> Public Property version As String

        ''' <summary>
        ''' shadow copy之后的唯一标识符
        ''' </summary>
        ''' <returns></returns>
        <XmlIgnore>
        Private Property accession As String Implements INamedValue.Key

        ''' <summary>
        ''' 蛋白质的唯一标识符，可以用作为字典的键名
        ''' </summary>
        ''' <returns></returns>
        <XmlElement("accession")>
        Public Property accessions As String()
        Public Property name As String
        Public Property protein As protein
        <XmlElement("feature")>
        Public Property features As feature()
        Public Property gene As gene
        Public Property proteinExistence As value
        Public Property organism As organism
        Public Property sequence As sequence

        <XmlElement("keyword")> Public Property keywords As value()
        <XmlElement("comment")> Public Property comments As comment()
            Get
                Return CommentList.Values.ToVector
            End Get
            Set(value As comment())
                If value Is Nothing Then
                    _CommentList = New Dictionary(Of String, comment())
                Else
                    _CommentList = value _
                        .OrderBy(Function(c) c.type) _
                        .GroupBy(Function(c) c.type) _
                        .ToDictionary(Function(t) t.Key,
                                      Function(v) v.ToArray)
                End If
            End Set
        End Property

        <XmlElement("dbReference")> Public Property dbReferences As dbReference()
            Get
                Return Xrefs.Values.ToVector
            End Get
            Set(value As dbReference())
                If value Is Nothing Then
                    _Xrefs = New Dictionary(Of String, dbReference())
                    Return
                End If

                _Xrefs = value _
                    .OrderBy(Function(ref) ref.type) _
                    .GroupBy(Function(ref) ref.type) _
                    .ToDictionary(Function(t) t.Key,
                                  Function(v) v.ToArray)
            End Set
        End Property

        <XmlIgnore>
        Public ReadOnly Property CommentList As Dictionary(Of String, comment())
        <XmlIgnore>
        Public ReadOnly Property Xrefs As Dictionary(Of String, dbReference())

        Public Overrides Function ToString() As String
            Return accessions.GetJson
        End Function

        ''' <summary>
        ''' 这个是处理有多个accession的情况
        ''' </summary>
        ''' <returns></returns>
        Public Function ShadowCopy() As entry()
            Dim list As New List(Of entry)

            For Each accID As String In accessions
                Dim o As entry = TryCast(Me.MemberwiseClone, entry)
                o.accession = accID
                list += o
            Next

            Return list
        End Function
    End Class
End Namespace