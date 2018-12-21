﻿Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Algorithm.base
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.Ranges.Model
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.Python
Imports Microsoft.VisualBasic.Math.Distributions
Imports Microsoft.VisualBasic.Math.LinearAlgebra
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports Microsoft.VisualBasic.Scripting.Runtime

''' <summary>
''' 只显示log2FC的情况
''' </summary>
Public Module FoldChangeBar

    <Extension>
    Private Iterator Function createColorIntervals(colors As Color(), colorIntervals As Vector) As IEnumerable(Of (range As DoubleRange, colors As SolidBrush()))
        Dim intervals = colorIntervals.SlideWindows(2).ToArray
        Dim max = colorIntervals.Max
        Dim n = colors.Length
        Dim subset As SolidBrush()
        Dim intervalRange As DoubleRange = {0, max}
        Dim countRange As DoubleRange = {0, n}
        Dim a, b As Integer

        For Each interval As SlideWindow(Of Double) In intervals
            a = intervalRange.ScaleMapping(interval(0), countRange)
            b = intervalRange.ScaleMapping(interval(1), countRange)
            subset = colors _
                .slice(a, b - 1) _
                .Select(Function(c) New SolidBrush(c)) _
                .ToArray

            Yield (interval.Range, subset)
        Next
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="colors">区间按照从小到大进行排序过了的</param>
    ''' <param name="value#"></param>
    ''' <returns></returns>
    <Extension>
    Private Function getColors(colors As (range As DoubleRange, colors As SolidBrush())(), value#) As IEnumerable(Of SolidBrush)
        Dim fills As New List(Of SolidBrush)
        Dim len%
        Dim normalRange As DoubleRange = {0, 1}
        Dim range As DoubleRange
        Dim rangeColors As SolidBrush()

        For i As Integer = 0 To colors.Length - 1
            With colors(i)
                range = .range
                rangeColors = .colors
                len = rangeColors.Length
            End With

            If range.IsInside(value) Then
                ' 到此为止了
                ' 需要吧当前区间内的颜色给提出来
                fills += rangeColors.slice(0, range.ScaleMapping(value, {0, len}))
                Exit For
            ElseIf value >= range.Max Then
                fills += rangeColors
            End If
        Next

        If value > colors.Last.range.Max Then
            fills += colors.Last.colors.Last
        End If

        Return fills
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="size$"></param>
    ''' <param name="margin$"></param>
    ''' <param name="bg$"></param>
    ''' <param name="scaleColorSchema$"></param>
    ''' <param name="colorRangeInterval">
    ''' 向量里面的元素数量应该是单数的，这个间隔序列主要起着两种功能：
    ''' 
    ''' 1. 确定颜色取值的区间
    ''' 2. 标尺的绘制
    ''' </param>
    ''' <param name="colorlevels%"></param>
    ''' <param name="maxLabelLen%"></param>
    ''' <param name="labelFontCSS$"></param>
    ''' <param name="boxBorderCSS$"></param>
    ''' <param name="referenceStroke$"></param>
    ''' <returns></returns>
    <Extension>
    Public Function Plot(data As IEnumerable(Of NamedValue(Of Double)),
                         Optional size$ = "2700,1800",
                         Optional margin$ = g.DefaultUltraLargePadding,
                         Optional bg$ = "white",
                         Optional scaleColorSchema$ = "YlGnBu:c8",
                         Optional colorRangeInterval$ = "0,1,2,5",
                         Optional colorlevels% = 20,
                         Optional maxLabelLen% = 56,
                         Optional labelFontCSS$ = CSSFont.Win7LittleLarge,
                         Optional boxBorderCSS$ = Stroke.AxisStroke,
                         Optional referenceStroke$ = Stroke.AxisGridStroke,
                         Optional title$ = "FoldChange Bar Plot",
                         Optional titleFontCSS$ = CSSFont.Win7VeryLarge,
                         Optional tickHeight% = 10,
                         Optional tickFontCSS$ = CSSFont.Win7LittleLarge) As GraphicsData

        Dim colorIntervals As Vector = colorRangeInterval
        Dim colors As Color() = Designer.GetColors(scaleColorSchema, colorlevels)
        Dim colorRanges As (range As DoubleRange, colors As SolidBrush())() = colors _
            .createColorIntervals(colorIntervals) _
            .ToArray
        Dim values As NamedValue(Of Double)() = data.ToArray
        Dim labelFont As Font = CSSFont.TryParse(labelFontCSS)
        Dim boxStroke As Pen = Stroke.TryParse(boxBorderCSS)
        Dim referencePen As Pen = Stroke.TryParse(referenceStroke)
        Dim titleFont As Font = CSSFont.TryParse(titleFontCSS)
        Dim tickFont As Font = CSSFont.TryParse(tickFontCSS)
        Dim plotInternal =
            Sub(ByRef g As IGraphics, region As GraphicsRegion)

                ' 首先确定右边的边框的位置
                Dim rect As Rectangle = region.PlotRegion
                Dim maxLabel$ = values.Keys.MaxLengthString

                If (maxLabel.Length > maxLabelLen) Then
                    maxLabel = Mid(maxLabel, 1, maxLabelLen) & "..."
                End If

                maxLabelLen = g.MeasureString(maxLabel, labelFont).Width

                Dim boxLeft = rect.Left + maxLabelLen
                Dim boxWidth = rect.Right - boxLeft
                Dim boxMiddle = boxLeft + boxWidth / 2
                Dim boxHeight = rect.Height
                Dim box As New Rectangle With {
                    .X = boxLeft,
                    .Y = rect.Top,
                    .Width = boxWidth,
                    .Height = boxHeight
                }

                ' 在盒子的中间绘制一条参考线
                Call g.DrawLine(referencePen, New PointF(boxMiddle, box.Top), New PointF(boxMiddle, box.Top + boxHeight))
                ' 绘制图表盒子的边框
                Call g.DrawRectangle(boxStroke, box)

                Dim barWidth!
                Dim barHeight! = (boxHeight / (values.Length + 1)) * 0.8
                Dim dy = (boxHeight - values.Length * barHeight) / (values.Length + 1)
                Dim samples As New SampleDistribution(Vector.Abs(values.Values.AsVector))
                Dim barRibbon As SolidBrush()
                Dim dx!
                Dim barFragment As RectangleF
                Dim x! = boxLeft
                Dim y! = rect.Top + dy
                Dim tickSize As SizeF
                Dim direction%

                boxWidth = boxWidth / 2

                ' 开始绘制分组数据
                For Each sample As NamedValue(Of Double) In values
                    ' 绘制左边的标签
                    x = boxLeft - g.MeasureString(sample.Name, labelFont).Width - 5
                    g.DrawString(sample.Name, labelFont, Brushes.Black, New PointF(x, y))

                    ' 绘制图表数据
                    barWidth = Math.Abs(sample.Value) / samples.max * boxWidth
                    x = boxMiddle

                    ' 确定颜色
                    barRibbon = colorRanges _
                        .getColors(Math.Abs(sample.Value)) _
                        .ToArray
                    dx = colorIntervals.Max / samples.max * boxWidth
                    dx = dx / colorlevels - 1

                    If sample.Value = 0# Then
                        ' 零，则在中线上画一条线
                        Call g.FillRectangle(Brushes.Black, New Rectangle(boxMiddle - 1, y, 2, barHeight))
                    Else

                        ' 进行条形图的颜色填充
                        ' 需要根据值来决定填充和绘制的方向
                        direction = Math.Sign(sample.Value)

                        If direction < 0 Then
                            x -= dx
                        End If

                        For i As Integer = 0 To barRibbon.Length - 1
                            barFragment = New RectangleF With {
                                .X = x,
                                .Width = Math.Abs(dx) + 1,
                                .Y = y,
                                .Height = barHeight
                            }

                            x += direction * dx
                            g.FillRectangle(barRibbon(i), barFragment)
                            barWidth -= dx
                        Next

                        If barWidth > 0 Then
                            Dim lastColor As SolidBrush = barRibbon.Last

                            If direction < 0 Then
                                x -= barWidth
                                barWidth += dx
                            End If

                            barFragment = New RectangleF With {
                                .X = x,
                                .Height = barHeight,
                                .Width = barWidth,
                                .Y = y
                            }
                            g.FillRectangle(lastColor, barFragment)
                        End If

                    End If

                    y += barHeight + dy
                Next

                ' 绘制大标题
                With g.MeasureString(title, titleFont)
                    x = rect.Left + (rect.Width - .Width) / 2
                    y = rect.Top - .Height - barHeight
                End With

                Call g.DrawString(title, titleFont, Brushes.Black, New PointF(x, y))

                ' 绘制标尺
                For Each tick As Double In colorIntervals
                    dx = tick / samples.max * boxWidth

                    ' 左右两边都要同时绘制标尺标记
                    ' 右边
                    x = boxMiddle + dx
                    y = box.Bottom + tickHeight
                    tickSize = g.MeasureString(tick, tickFont)

                    Call g.DrawLine(Pens.Black, x, y, x, box.Bottom)
                    Call g.DrawString(tick, tickFont, Brushes.Black, x - tickSize.Width / 2, y + tickHeight / 3)

                    x = boxMiddle - dx

                    Call g.DrawLine(Pens.Black, x, y, x, box.Bottom)
                    Call g.DrawString(tick, tickFont, Brushes.Black, x - tickSize.Width / 2, y + tickHeight / 3)
                Next
            End Sub

        Return g.GraphicsPlots(
            size.SizeParser,
            margin, bg,
            plotInternal
        )
    End Function
End Module
