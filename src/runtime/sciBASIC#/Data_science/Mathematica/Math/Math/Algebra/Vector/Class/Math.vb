﻿#Region "Microsoft.VisualBasic::015697f9e2540b93bb68f0c20bd4f7bb, Data_science\Mathematica\Math\Math\Algebra\Vector\Class\Math.vb"

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

'     Class Vector
' 
'         Function: Abs, BesselI, Exp, floor, Log
'                   Log10, (+3 Overloads) Max, (+3 Overloads) Min, Order, pchisq
'                   round, Sign, Sinh, Sort, Sqrt
'                   (+2 Overloads) Sum, Trunc
' 
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Language.Vectorization
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math.LinearAlgebra
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports sys = System.Math

Namespace LinearAlgebra

    Partial Class Vector

        ''' <summary>
        ''' abs(x) computes the absolute value of x, sqrt(x) computes the (principal) square root of x, √{x}.
        ''' </summary>
        ''' <param name="x">a numeric or complex vector or array.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Sqrt")>
        Public Shared Function Sqrt(x As Vector) As Vector
            Return New Vector(From n In x Select sys.Sqrt(n))
        End Function

        ''' <summary>
        ''' log computes logarithms, by default natural logarithms, log10 computes common (i.e., base 10) logarithms, 
        ''' and log2 computes binary (i.e., base 2) logarithms. 
        ''' The general form log(x, base) computes logarithms with base base.
        ''' log1p(x) computes log(1+x) accurately also for |x| &lt;&lt; 1.
        ''' exp computes the exponential function.
        ''' expm1(x) computes exp(x) - 1 accurately also for |x| &lt;&lt; 1.
        ''' </summary>
        ''' <param name="x">a numeric or complex vector.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Exp")>
        Public Shared Function Exp(x As Vector) As Vector
            Return New Vector(From n As Double In x Select sys.Exp(n))
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function Log(Optional base# = sys.E) As Vector
            Return Vector.Log(Me, base)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="x">a numeric or complex vector.</param>
        ''' <returns></returns>
        ''' <param name="base">a positive or complex number: the base with respect to which logarithms are computed. Defaults to e=exp(1).</param>
        ''' <remarks></remarks>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Log")>
        Public Shared Function Log(x As Vector, Optional base As Double = sys.E) As Vector
            Return New Vector(From n As Double In x Select sys.Log(n, base))
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function Log10(x As Vector) As Vector
            Return Log(x, base:=10)
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Max")>
        Public Shared Function Max(x As Vector) As Double
            Return x.Max
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function Max(x As Vector, y#) As Vector
            Return x.Select(Function(xi) sys.Max(xi, y)).AsVector
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function Max(x As Vector, y As Vector) As Vector
            Return x.SeqIterator _
                .Select(Function(i) sys.Max(i.value, y(i))) _
                .AsVector
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Min")>
        Public Shared Function Min(x As Vector) As Double
            Return x.Min
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function Min(x As Vector, y#) As Vector
            Return x.Select(Function(xi) sys.Min(xi, y)).AsVector
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function Min(x As Vector, y As Vector) As Vector
            Return x.SeqIterator _
                .Select(Function(i) sys.Min(i.value, y(i))) _
                .AsVector
        End Function

        ''' <summary>
        ''' Rounding of Numbers
        ''' </summary>
        ''' <param name="x"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Trunc")>
        Public Shared Function Trunc(x As Vector) As Vector
            Return New Vector(x.Select(AddressOf sys.Truncate))
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Abs")>
        Public Shared Function Abs(x As Vector) As Vector
            Return New Vector(From d As Double In x Select sys.Abs(d))
        End Function

        ''' <summary>
        ''' Bessel Functions of integer and fractional order, of first and second kind, J(nu) and Y(nu), 
        ''' and Modified Bessel functions (of first and third kind), I(nu) and K(nu).
        ''' </summary>
        ''' <returns>
        ''' Numeric vector with the (scaled, if expon.scaled = TRUE) values of the corresponding Bessel function.
        ''' The length of the result is the maximum of the lengths of the parameters. All parameters are recycled to that length.
        ''' </returns>
        ''' <remarks></remarks>
        ''' 
        <ExportAPI("Besseli")>
        Public Shared Function BesselI(x As Vector, nu As Vector,
                                <Parameter("expon.scaled", "logical; if TRUE, the results are exponentially scaled in order to avoid overflow (I(nu)) or underflow (K(nu)), respectively.")>
                                Optional ExponScaled As Boolean = False) As Vector
            Throw New NotImplementedException
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Floor")>
        Public Shared Function floor(x As Vector) As Vector
            Return New Vector(x.Select(AddressOf sys.Floor))
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Round")>
        Public Shared Function round(x As Vector, Optional digits As Integer = 4) As Vector
            Return New Vector(x.Select(Function(n) sys.Round(n, digits)))
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Sinh")>
        Public Shared Function Sinh(x As Vector) As Vector
            Return New Vector(x.Select(AddressOf sys.Sinh))
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Sign")>
        Public Shared Function Sign(x As Vector) As Vector
            Return New Vector(x.Select(AddressOf sys.Sign))
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("pchisq")>
        Public Shared Function pchisq(q As Vector, df As Vector, Optional ncp As Integer = 0, Optional lowertail As Boolean = True, Optional logp As Boolean = False) As Vector
            Throw New NotImplementedException
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Sum")>
        Public Shared Function Sum(x As Vector, Optional NaRM As Boolean = False) As Vector
            Return New Vector({x.Sum})
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Sum")>
        Public Shared Function Sum(x As BooleanVector, Optional NaRM As Boolean = False) As Vector
            Dim data = (From b As Boolean In x Select If(b, 1, 0)).ToArray
            Return New Vector(integers:={data.Sum})
        End Function

        ''' <summary>
        ''' Sorting or Ordering Vectors
        ''' Sort (or order) a vector or factor (partially) into ascending or descending order. For ordering along more than one variable, e.g., for sorting data frames, see order.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Sort")>
        Public Shared Function Sort(x As Vector, Optional decreasing As Boolean = False) As Vector
            Return If(
                Not decreasing,
                New Vector(x.OrderBy(Function(n) n)),
                New Vector(x.OrderByDescending(Function(n) n)))
        End Function

        ''' <summary>
        ''' order returns a permutation which rearranges its first argument into ascending or descending order, breaking ties by further arguments. sort.list is the same, using only one argument.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <ExportAPI("Order")>
        Public Shared Function Order(x As Vector, Optional nalast As Boolean = True, Optional decreasing As Boolean = False) As Vector
            Throw New NotImplementedException
        End Function
    End Class
End Namespace
