﻿#Region "Microsoft.VisualBasic::d493392bfbf03748add53031ca07d74a, Data_science\DataMining\DataMining\ComponentModel\Discretizer\Discretizer.vb"

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

    '     Class Discretizer
    ' 
    '         Properties: delta, max, min
    ' 
    '         Constructor: (+2 Overloads) Sub New
    '         Function: createBins, GetLevel
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.ComponentModel.Ranges.Model
Imports Microsoft.VisualBasic.Language

Namespace ComponentModel.Discretion

    ''' <summary>
    ''' 通过这个对象来执行对连续性数值的数据集的离散化操作
    ''' </summary>
    ''' <remarks>
    ''' 离散化是通过类似于等宽分bin来实现的
    ''' </remarks>
    Public Class Discretizer

        Public Property min As Double
        Public Property max As Double
        Public Property delta As Double

        Dim bins As DoubleRange()

        Sub New(sample As IEnumerable(Of Double), levels As Integer)
            With sample.ToArray
                min = .Min
                max = .Max
                delta = (max - min) / levels
            End With

            bins = createBins.ToArray
        End Sub

        ''' <summary>
        ''' json/xml serialization
        ''' </summary>
        Sub New()
        End Sub

        Private Iterator Function createBins() As IEnumerable(Of DoubleRange)
            Dim lower As VBDouble = min

            Do While lower < max
                Yield New DoubleRange(lower, lower = lower + delta)
            Loop
        End Function

        Public Function GetLevel(x As Double) As Integer
            If bins Is Nothing Then
                bins = createBins.ToArray
            End If

            If x < min Then
                Return 0
            ElseIf x > max Then
                Return bins.Length
            End If

            For i As Integer = 0 To bins.Length - 1
                If bins(i).IsInside(x) Then
                    Return i
                End If
            Next

            Throw New InvalidProgramException
        End Function
    End Class
End Namespace
