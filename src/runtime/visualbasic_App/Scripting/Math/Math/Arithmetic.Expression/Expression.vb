﻿#Region "Microsoft.VisualBasic::44ba3a58a050d7ec9bd0f1cfb4865dfe, ..\visualbasic_App\Scripting\Math\Math\Arithmetic.Expression\Expression.vb"

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

Imports System.Text
Imports Microsoft.VisualBasic.Mathematical.Helpers
Imports Microsoft.VisualBasic.Mathematical.Types

''' <summary>
''' Expression Evaluation Engine
''' </summary>
''' <remarks></remarks>
Public Class Expression

    Public ReadOnly Property Constant As Helpers.Constants
    Public ReadOnly Property Variables As Variable
    Public ReadOnly Property Functions As [Function]

    ''' <summary>
    ''' Gets constant or variable value, but only sets variable value.
    ''' </summary>
    ''' <param name="var"></param>
    ''' <returns></returns>
    Default Public Property value(var As String) As Double
        Get
            Return GetValue(var)
        End Get
        Set(value As Double)
            Call Variables.Set(var, value)
        End Set
    End Property

    ''' <summary>
    ''' The default expression evaluation engine.
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property DefaultEngine As New Expression

    Public Sub New()
        Variables = New Variable(Me)
        Functions = New [Function](Me)
        Constant = New Helpers.Constants(Me)
    End Sub

    ''' <summary>
    ''' This shared method using the default expression engine for the evaluation.
    ''' </summary>
    ''' <param name="expr"></param>
    ''' <returns></returns>
    Public Shared Function Evaluate(expr As String) As Double
        Return DefaultEngine.Evaluation(expr)
    End Function

    ''' <summary>
    ''' Evaluate the a specific mathematics expression string to a double value, the functions, constants, 
    ''' bracket pairs can be include in this expression but the function are those were originally exists 
    ''' in the visualbasic. I'm sorry for this...
    ''' (对一个包含有函数、常数和匹配的括号的一个复杂表达式进行求值，但是对于表达式中的函数而言：仅能够使用在
    ''' VisualBaisc语言中存在的有限的几个数学函数。)  
    ''' </summary>
    ''' <param name="expr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Evaluation(expr As String) As Double
        Dim sep As SimpleExpression = ExpressionParser.TryParse(expr, Me)
        Return sep.Evaluate
    End Function

    ''' <summary>
    ''' 先常量，后变量
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    Public Function GetValue(x As String) As Double
        Dim isConst As Boolean = False
        Dim n As Double = Constant.[GET](x, isConst)

        If isConst Then
            Return n
        Else
            Return Variables(x)
        End If
    End Function

    Public Sub SetVariable(Name As String, expr As String)
        Call Variables.Set(Name, expr)
    End Sub

    Public Sub AddConstant(Name As String, expr As String)
        Dim val As Double = Me.Evaluation(expr)
        Call Constant.Add(Name, val)
    End Sub
End Class
