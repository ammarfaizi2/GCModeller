﻿#Region "Microsoft.VisualBasic::8ccc7dda3d3c5ccaa6a29d34d3aa8378, localblast\assembler\Greedy.vb"

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

' Module Greedy
' 
' 
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Algorithm.BinaryTree
Imports Microsoft.VisualBasic.ComponentModel.Algorithm.DynamicProgramming
Imports SMRUCC.genomics.Analysis.SequenceTools
Imports SMRUCC.genomics.SequenceModel
Imports SMRUCC.genomics.SequenceModel.FASTA

Public Module Greedy

    ' Greedy algorithm
    ' Given a Set Of sequence fragments the Object Is To find the shortest common supersequence.

    ' Сalculate pairwise alignments Of all fragments.
    ' Choose two fragments With the largest overlap.
    ' Merge chosen fragments.
    ' Repeat step 2 And 3 until only one fragment Is left.
    ' The result need Not be an optimal solution To the problem.

    ''' <summary>
    ''' 使用贪婪SCS算法进行测序数据的从头装配
    ''' </summary>
    ''' <param name="reads"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' 使用二叉树+SmithWaterman算法利用<see cref="SCS"/>进行基因组的从头装配
    ''' </remarks>
    <Extension>
    Public Iterator Function DeNovoAssembly(reads As IEnumerable(Of FastaSeq)) As IEnumerable(Of FastaSeq)
        Dim avltree As New AVLClusterTree(Of Bits)(AddressOf align, Function(fa) fa.GetSequenceData)

        For Each read As FastaSeq In reads
            Call avltree.Add(Bits.FromNucleotide(read))
        Next


    End Function

    ''' <summary>
    ''' do pairwise alignment of two reads
    ''' </summary>
    ''' <param name="a"></param>
    ''' <param name="b"></param>
    ''' <returns></returns>
    Private Function align(a As Bits, b As Bits) As Integer
        If a.GetSequenceData = b.GetSequenceData Then
            Return 0
        End If

        ' 在这里不可以使用smith-waterman比对来进行比较,
        ' 假若测序数据是16sRNA, 因为16sRNA高度保守, 
        ' 使用Smith-waterman算法比较会出现reads几乎全部集中在root节点的问题
        Dim overlapSize = a.OverlapSize(b)
        Dim minLen = Math.Min(a.length, b.length)

        If overlapSize >= minLen * 0.85 Then
            Return 0
        ElseIf overlapSize >= minLen * 0.65 Then
            Return 1
        Else
            Return -1
        End If
    End Function
End Module
