﻿#Region "Microsoft.VisualBasic::1924243393e0eb62a31cd5c978590594, ..\visualbasic_App\Microsoft.VisualBasic.Architecture.Framework\Scripting\TokenIcer\LDM\StackTokens(Of Tokens).vb"

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

Imports Microsoft.VisualBasic.Linq

Namespace Scripting.TokenIcer

    ''' <summary>
    ''' 进行栈树解析所必须要的一些基本元素
    ''' </summary>
    ''' <typeparam name="Tokens"></typeparam>
    Public Class StackTokens(Of Tokens)

        ''' <summary>
        ''' Pretend the root tokens as a true node
        ''' </summary>
        ''' <returns></returns>
        Public Property Pretend As Tokens
        ''' <summary>
        ''' 参数的分隔符，一般是逗号
        ''' </summary>
        ''' <returns></returns>
        Public Property ParamDeli As Tokens
        ''' <summary>
        ''' 向下一层堆栈符号，一般是左括号
        ''' </summary>
        ''' <returns></returns>
        Public Property LPair As Tokens
        ''' <summary>
        ''' 向上一层出栈符号，一般是右括号
        ''' </summary>
        ''' <returns></returns>
        Public Property RPair As Tokens
        Public Property WhiteSpace As Tokens

        ''' <summary>
        ''' Tokens equals?
        ''' </summary>
        ''' <param name="a"></param>
        ''' <param name="b"></param>
        ''' <returns></returns>
        Public Overloads Function Equals(a As Tokens, b As Tokens) As Boolean
            Dim flag As Boolean = __equals(a, b)
            Return flag
        End Function

        ReadOnly __equals As Func(Of Tokens, Tokens, Boolean)

        ''' <summary>
        ''' Tokens equals? 
        ''' </summary>
        ''' <param name="equals"></param>
        Sub New(equals As Func(Of Tokens, Tokens, Boolean))
            __equals = equals
        End Sub
    End Class
End Namespace
