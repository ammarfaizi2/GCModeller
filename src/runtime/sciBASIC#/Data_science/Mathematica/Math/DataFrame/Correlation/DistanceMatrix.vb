﻿Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON

Public Class DistanceMatrix

    ReadOnly names As Index(Of String)
    ReadOnly matrix As Double()()

    Default Public Property dist(a$, b$) As Double
        Get
            Return Me(names(a), names(b))
        End Get
        Set
            Me(names(a), names(b)) = Value
        End Set
    End Property

    Default Public Property dist(i%, j%) As Double
        Get
            Return matrix(j)(i)
        End Get
        Set(value As Double)
            matrix(j)(i) = value
        End Set
    End Property

    Sub New(names As IEnumerable(Of String))
        Me.names = names.Indexing
        Me.matrix = MAT(Of Double)(Me.names.Count, Me.names.Count)
    End Sub

    Private Sub New(names As Index(Of String), matrix As Double()())
        Me.names = names
        Me.matrix = matrix
    End Sub

    Public Overrides Function ToString() As String
        If names.Count <= 6 Then
            Return names.Objects.GetJson
        Else
            Return "[" & names.Objects.Take(6).JoinBy(", ") & "..."
        End If
    End Function

    Public Shared Function CreateMatrix(Of T As {INamedValue, DynamicPropertyBase(Of Double)})(data As IEnumerable(Of T)) As DistanceMatrix
        Dim matrix As New List(Of Double())
        Dim dataVec As T() = data.SafeQuery.ToArray
        Dim names = dataVec.Keys

        For Each row As T In data
            matrix += names _
                .Select(Function(key)
                            Return row.Properties(key)
                        End Function) _
                .ToArray
        Next

        Return New DistanceMatrix(names, matrix)
    End Function

End Class
