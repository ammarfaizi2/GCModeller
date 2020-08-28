﻿Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.DataMining.ComponentModel.Encoder
Imports Microsoft.VisualBasic.Linq

Namespace SVM

    Public Class SupportVector : Inherits DynamicPropertyBase(Of Double)
        Implements INamedValue

        Public Property id As String Implements INamedValue.Key
        Public Property labels As Dictionary(Of String, String)

    End Class

    Public Class ProblemTable

        Public Property vectors As SupportVector()

        Public Property DimensionNames As String()

        Public ReadOnly Property Topics As String()
            Get
                Return vectors _
                    .Select(Function(a) a.labels.Keys) _
                    .IteratesALL _
                    .Distinct _
                    .ToArray
            End Get
        End Property

        Public Function GetProblem(topic As String) As Problem
            Dim inputs As New List(Of Node())
            Dim labels As New List(Of String)

            For Each vec As SupportVector In vectors
                Call DimensionNames _
                    .Select(Function(x, i) New Node(i + 1, vec(x))) _
                    .ToArray _
                    .DoCall(AddressOf inputs.Add)

                Call labels.Add(vec.labels(topic))
            Next

            Return New Problem With {
                .DimensionNames = DimensionNames,
                .MaxIndex = .DimensionNames.Length,
                .X = inputs _
                    .Select(Function(i) Node.Copy(i).ToArray) _
                    .ToArray,
                .Y = labels.ClassEncoder.ToArray
            }
        End Function

        ''' <summary>
        ''' row append
        ''' </summary>
        ''' <param name="a"></param>
        ''' <param name="b"></param>
        ''' <returns></returns>
        Public Shared Function Append(a As ProblemTable, b As ProblemTable) As ProblemTable
            Dim union As SupportVector() = a.vectors _
                .JoinIterates(b.vectors) _
                .ToArray
            Dim names As String() = union _
                .Select(Function(vi) vi.Properties.Keys) _
                .IteratesALL _
                .Distinct _
                .ToArray

            Return New ProblemTable With {
                .DimensionNames = names,
                .vectors = union
            }
        End Function
    End Class
End Namespace