﻿#Region "Microsoft.VisualBasic::7344054b1f4d7b04b02deaaf757adbc3, ..\visualbasic_App\Data_science\Bootstrapping\Monte-Carlo\Example.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
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

Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Mathematical
Imports Microsoft.VisualBasic.Mathematical.BasicR
Imports Microsoft.VisualBasic.Mathematical.diffEq

Namespace MonteCarlo.Example

    ''' <summary>
    ''' 计算步骤
    ''' 
    ''' 1. 继承<see cref="Model"/>对象并实现具体的过程
    ''' 2. 设置好大概的参数的变化区间
    ''' 3. 设置好大概的函数初始值的变化区间
    ''' </summary>
    Public Class Example : Inherits Model

        Dim sin As var
        Dim a As Double
        Dim f As Double

        Protected Overrides Sub func(dx As Double, ByRef dy As Vector)
            dy(sin) = a * Math.Sin(dx) + f
        End Sub

        Public Overrides Function params() As VariableModel()
            Return {
                New VariableModel(-1000, 1000) With {.Name = NameOf(a)},
                New VariableModel(-1000, 1000) With {.Name = NameOf(f)}
            }
        End Function

        Public Overrides Function yinit() As VariableModel()
            Return {
                New VariableModel(-1000, 1000) With {.Name = NameOf(sin)}
            }
        End Function

        Public Overrides Function eigenvector() As Dictionary(Of String, Eigenvector)
            Return Nothing
        End Function
    End Class

    Public Class TestObservation : Inherits ODEs

        Dim sin As var
        Dim a As Double = 10
        Dim f As Double = -9.3

        Dim compare As Boolean = False

        Protected Overrides Sub func(dx As Double, ByRef dy As Vector)
            dy(sin) = a * Math.Sin(dx) + f
        End Sub

        Protected Overrides Function y0() As var()
            If compare Then
                Return {sin}
            Else
                Return {sin = f}
            End If
        End Function

        Public Shared Iterator Function Compares(n As Integer, a As Integer, b As Integer, parms As Dictionary(Of String, Double)) As IEnumerable(Of ODEsOut)
            Yield New TestObservation().Solve(n, a, b)
            Yield New TestObservation With {
                .a = parms(NameOf(a)),
                .compare = True,
                .f = parms(NameOf(f)),
                .sin = New var With {
                    .Name = NameOf(sin),
                    .value = parms(NameOf(sin))
                }
            }.Solve(n, a, b)
        End Function
    End Class
End Namespace
