﻿Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.Ranges.Model
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Text
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports SMRUCC.genomics.Analysis.HTS.DataFrame

Public Module SampleColorBend

    ''' <summary>
    ''' 仅对行进行计算
    ''' </summary>
    ''' <param name="matrix"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function GetColors(matrix As Matrix, Optional colorSet$ = "RdYlGn:c8", Optional levels As Integer = 25) As IEnumerable(Of NamedCollection(Of Color))
        Dim colors As Color() = Designer.GetColors(colorSet, n:=levels)
        Dim indexRange As DoubleRange = {0, colors.Length - 1}

        For Each gene As DataFrameRow In matrix.expression
            Dim levelRange As New DoubleRange(gene.experiments)
            Dim index As Integer() = gene.experiments _
                .Select(Function(a)
                            Return levelRange.ScaleMapping(a, indexRange)
                        End Function) _
                .Select(Function(d) CInt(d)) _
                .ToArray

            Yield New NamedCollection(Of Color) With {
                .name = gene.geneID,
                .value = index _
                    .Select(Function(i) colors(i)) _
                    .ToArray
            }
        Next
    End Function

    ' drawing layout
    '
    '                A  B  C  D
    ' horizontal:   [ ][ ][ ][ ]
    '
    ' vertical:     [ ] A
    '               [ ] B
    '               [ ] C

    Public Sub Draw(g As IGraphics, layout As RectangleF, geneExpression As Color(),
                    Optional horizontal As Boolean = True,
                    Optional sampleNames As String() = Nothing,
                    Optional labelFontCSS$ = CSSFont.PlotSmallTitle）

        Dim boxSize As Single
        Dim labelFont As Font = CSSFont.TryParse(labelFontCSS).GDIObject

        If horizontal Then
            boxSize = layout.Width / geneExpression.Length
        Else
            boxSize = layout.Height / geneExpression.Length
        End If

        Dim x = layout.Left
        Dim y = layout.Top
        Dim textDraw As New GraphicsText(DirectCast(g, Graphics2D).Graphics)

        For i As Integer = 0 To geneExpression.Length - 1
            Call g.FillRectangle(New SolidBrush(geneExpression(i)), New RectangleF(x, y, boxSize, boxSize))

            If Not sampleNames.IsNullOrEmpty Then
                If horizontal Then
                    Call textDraw.DrawString(sampleNames(i), labelFont, Brushes.Black, New PointF(x, y - labelFont.Height), -90)
                Else
                    Call g.DrawString(sampleNames(i), labelFont, Brushes.Black, New PointF(x + boxSize + 5, y))
                End If
            End If

            If horizontal Then
                x += boxSize
            Else
                y += boxSize
            End If
        Next
    End Sub
End Module