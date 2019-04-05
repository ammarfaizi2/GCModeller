﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Algorithm.BinaryTree
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH

Public Module CoreTree

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="localblast">多个基因组之间的比对结果</param>
    ''' <returns></returns>
    <Extension>
    Public Function BuildTree(proteins As IEnumerable(Of String), localblast As IEnumerable(Of BestHit))
        Dim comparer As New ProteinComparer(localblast)
        Dim tree As New AVLTree(Of String, String)(comparer, Function(name) name)

        For Each proteinName As String In proteins
            Call tree.Add(proteinName, proteinName, valueReplace:=False)
        Next

        ' 返回同源性的cluster

    End Function
End Module

Public Class ProteinComparer : Implements IComparer(Of String)

    ''' <summary>
    ''' [subj => [query => subject]]
    ''' </summary>
    Dim blastIndex As Dictionary(Of String, Dictionary(Of String, BestHit))

    Sub New(localblast As IEnumerable(Of BestHit))
        blastIndex = localblast _
            .GroupBy(Function(hit) hit.HitName) _
            .ToDictionary(Function(db) db.Key,
                          Function(db)
                              Return db.ToDictionary(Function(s) s.QueryName)
                          End Function)
    End Sub

    Public Function Compare(x As String, y As String) As Integer Implements IComparer(Of String).Compare
        If blastIndex.ContainsKey(x) Then
            Dim qvs = blastIndex(x)

            If qvs.ContainsKey(y) Then
                Dim besthit As BestHit = qvs(y)

                If besthit.identities > 0.85 Then
                    Return 0
                ElseIf besthit.identities > 0.6 Then
                    Return 1
                Else
                    Return -1
                End If
            Else
                Return 1
            End If
        Else
            Return -1
        End If
    End Function
End Class