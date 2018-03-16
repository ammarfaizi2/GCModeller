﻿#Region "Microsoft.VisualBasic::bbe1630622d64d4102884f55b48387ea, gr\Microsoft.VisualBasic.Imaging\SVG\ModelBuilder.vb"

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

'     Module ModelBuilder
' 
'         Function: PiePath
' 
' 
' /********************************************************************************/

#End Region

Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.Imaging.SVG.XML
Imports sys = System.Math

Namespace SVG

    Public Module ModelBuilder

        Public Function PiePath(x!, y!, width!, height!, startAngle!, sweepAngle!) As path
            Dim endAngle! = startAngle + sweepAngle
            Dim rX = width / 2
            Dim rY = height / 2
            Dim x1 = x + rX * sys.Cos(Math.PI * startAngle / 180)
            Dim y1 = y + rY * sys.Sin(Math.PI * startAngle / 180)
            Dim x2 = x + rX * sys.Cos(Math.PI * endAngle / 180)
            Dim y2 = y + rY * sys.Sin(Math.PI * endAngle / 180)
            Dim d = $"M{x},{y}  L{x1},{y1}  A{rX},{rY} 0 0,1 {x2},{y2} z" ' 1 means clockwise

            Return New path With {
                .d = d
            }
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function SVGPath(path As GraphicsPath) As path
            Return New path(path)
        End Function

        ''' <summary>
        ''' 下面的命令可用于路径数据：
        ''' 
        ''' M = moveto
        ''' L = lineto
        ''' H = horizontal lineto
        ''' V = vertical lineto
        ''' C = curveto
        ''' S = smooth curveto
        ''' Q = quadratic Belzier curve
        ''' T = smooth quadratic Belzier curveto
        ''' A = elliptical Arc
        ''' Z = closepath
        ''' 
        ''' 注释：以上所有命令均允许小写字母。大写表示绝对定位，小写表示相对定位。
        ''' </summary>
        ''' <returns></returns>
        <Extension>
        Public Function SVGPathData(path As GraphicsPath) As String
            Dim points = path.PathData _
               .Points _
               .Select(Function(pt) $"{pt.X} {pt.Y}")
            Dim sb As New StringBuilder("M" & points.First)

            For Each pt In points.Skip(1)
                Call sb.Append(" ")
                Call sb.Append("L" & pt)
            Next

            Call sb.Append(" ")
            Call sb.Append("Z")

            Return sb.ToString
        End Function

        <Extension>
        Public Function ParseSVGPathData(path As path)
            Throw New NotImplementedException
        End Function
    End Module
End Namespace
