﻿#Region "Microsoft.VisualBasic::21332bf781166ebda5136caacf613bcb, Data_science\MachineLearning\MachineLearning\SVM\Node.vb"

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

    '     Class Node
    ' 
    '         Properties: Index, Value
    ' 
    '         Constructor: (+2 Overloads) Sub New
    '         Function: CompareTo, Equals, GetHashCode, ToString
    ' 
    ' 
    ' /********************************************************************************/

#End Region

' 
' * SVM.NET Library
' * Copyright (C) 2008 Matthew Johnson
' * 
' * This program is free software: you can redistribute it and/or modify
' * it under the terms of the GNU General Public License as published by
' * the Free Software Foundation, either version 3 of the License, or
' * (at your option) any later version.
' * 
' * This program is distributed in the hope that it will be useful,
' * but WITHOUT ANY WARRANTY; without even the implied warranty of
' * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' * GNU General Public License for more details.
' * 
' * You should have received a copy of the GNU General Public License
' * along with this program.  If not, see <http://www.gnu.org/licenses/>.


Namespace SVM

    ''' <summary>
    ''' Encapsulates a node in a Problem vector, with an index and a value (for more efficient representation
    ''' of sparse data.
    ''' </summary>
    <Serializable>
    Public Class Node : Implements IComparable(Of Node)

        ''' <summary>
        ''' Index of this Node.
        ''' </summary>
        Public Property Index As Integer

        ''' <summary>
        ''' Value at Index.
        ''' </summary>
        Public Property Value As Double

        ''' <summary>
        ''' Default Constructor.
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Constructor.
        ''' </summary>
        ''' <param name="index">The index of the value.</param>
        ''' <param name="value">The value to store.</param>
        Public Sub New(index As Integer, value As Double)
            _index = index
            _value = value
        End Sub

        ''' <summary>
        ''' String representation of this Node as {index}:{value}.
        ''' </summary>
        ''' <returns>{index}:{value}</returns>
        Public Overrides Function ToString() As String
            Return String.Format("{0}:{1}", _index, _value.Truncate())
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            Dim other As Node = TryCast(obj, Node)
            If other Is Nothing Then Return False
            Return _index = other._index AndAlso _value.Truncate() = other._value.Truncate()
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return _index.GetHashCode() + _value.GetHashCode()
        End Function

#Region "IComparable<Node> Members"

        ''' <summary>
        ''' Compares this node with another.
        ''' </summary>
        ''' <param name="other">The node to compare to</param>
        ''' <returns>A positive number if this node is greater, a negative number if it is less than, or 0 if equal</returns>
        Public Function CompareTo(other As Node) As Integer Implements IComparable(Of Node).CompareTo
            Return _index.CompareTo(other._index)
        End Function

#End Region

        Public Shared Function Copy(dataset As IEnumerable(Of Node)) As IEnumerable(Of Node)
            Return dataset _
                .Select(Function(d)
                            Return New Node With {
                                .Index = d.Index,
                                .Value = d.Value
                            }
                        End Function)
        End Function
    End Class
End Namespace
