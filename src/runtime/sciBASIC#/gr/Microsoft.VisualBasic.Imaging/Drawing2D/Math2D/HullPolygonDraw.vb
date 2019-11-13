﻿#Region "Microsoft.VisualBasic::73e7c4d7047183957d73162212c84a72, gr\Microsoft.VisualBasic.Imaging\Drawing2D\Math2D\HullPolygonDraw.vb"

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

    '     Module HullPolygonDraw
    ' 
    '         Function: buildPath
    ' 
    '         Sub: DrawHullPolygon
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Imaging.Math2D

Namespace Drawing2D.Math2D

    Public Module HullPolygonDraw

        ''' <summary>
        ''' 这个函数仅仅是作图函数，如果图形中有些离群点会导致图形面积过大的话，可以在调用这个函数之前做kmeans聚类过滤掉这些离群点
        ''' </summary>
        ''' <param name="g"></param>
        ''' <param name="polygon"></param>
        ''' <param name="color"></param>
        ''' <param name="strokeWidth!"></param>
        ''' <param name="alpha"><see cref="Color.A"/></param>
        ''' <param name="shadow"></param>
        <Extension>
        Public Sub DrawHullPolygon(g As IGraphics,
                                   polygon As IEnumerable(Of PointF),
                                   color As Color,
                                   Optional strokeWidth! = 8.5,
                                   Optional alpha% = 95,
                                   Optional shadow As Boolean = True,
                                   Optional convexHullCurveDegree! = 2)

            Dim shape As PointF() = polygon.ToArray

            If convexHullCurveDegree > 1 Then
                ' do curve interpolation
                ' smoothing
                shape = shape _
                    .BSpline(degree:=convexHullCurveDegree, RESOLUTION:=30) _
                    .ToArray
            End If

            Dim alphaBrush As New SolidBrush(color.Alpha(alpha))
            Dim path = shape.buildPath(Nothing)
            Dim shadowPath = shape.buildPath(New PointF(strokeWidth / 2, strokeWidth))
            Dim stroke As New Pen(color, strokeWidth) With {
                .DashStyle = DashStyle.Dash
            }
            Dim shadowStroke As New Pen(Color.LightGray, strokeWidth) With {
                .DashStyle = stroke.DashStyle
            }

            Call g.FillPath(alphaBrush, path)
            Call g.DrawPath(shadowStroke, shadowPath)
            Call g.DrawPath(stroke, path)
        End Sub

        <Extension>
        Private Function buildPath(polygon As IEnumerable(Of PointF), offset As PointF) As GraphicsPath
            Dim path As New GraphicsPath

            Call path.AddPolygon(polygon.Select(Function(p) p.OffSet2D(offset)).ToArray)
            Call path.CloseFigure()

            Return path
        End Function
    End Module
End Namespace
