﻿#Region "Microsoft.VisualBasic::40dcdc4f460bdac59c1d87ba3c52b8db, Data_science\MachineLearning\MachineLearning\SVM\StorageProcedure\TextWriter\ModelText.vb"

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

    '     Module ModelText
    ' 
    '         Function: ToString
    ' 
    '         Sub: Write
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.Text

Namespace SVM

    Module ModelText

        ''' <summary>
        ''' Writes a model to the provided stream.
        ''' </summary>
        ''' ''' <param name="output">The output stream</param>
        ''' ''' <param name="model">The model to write</param>
        Public Sub Write(output As TextWriter, model As Model)
            Dim param = model.Parameter

            output.Write("svm_type {0}" & ASCII.LF, param.SvmType)
            output.Write("kernel_type {0}" & ASCII.LF, param.KernelType)

            If param.KernelType = KernelType.POLY Then output.Write("degree {0}" & ASCII.LF, param.Degree)
            If param.KernelType = KernelType.POLY OrElse param.KernelType = KernelType.RBF OrElse param.KernelType = KernelType.SIGMOID Then output.Write("gamma {0:0.000000}" & ASCII.LF, param.Gamma)
            If param.KernelType = KernelType.POLY OrElse param.KernelType = KernelType.SIGMOID Then output.Write("coef0 {0:0.000000}" & ASCII.LF, param.Coefficient0)
            Dim nr_class = model.NumberOfClasses
            Dim l = model.SupportVectorCount
            output.Write("nr_class {0}" & ASCII.LF, nr_class)
            output.Write("total_sv {0}" & ASCII.LF, l)

            If True Then
                output.Write("rho")

                For i As Integer = 0 To CInt(nr_class * (nr_class - 1) / 2) - 1
                    output.Write(" {0:0.000000}", model.Rho(i))
                Next

                output.Write(ASCII.LF)
            End If

            If model.ClassLabels IsNot Nothing Then
                output.Write("label")

                For i = 0 To nr_class - 1
                    output.Write(" {0}", model.ClassLabels(i))
                Next

                output.Write(ASCII.LF)
            End If
            ' regression has probA only
            If model.PairwiseProbabilityA IsNot Nothing Then
                output.Write("probA")

                For i As Integer = 0 To CInt(nr_class * (nr_class - 1) / 2) - 1
                    output.Write(" {0:0.000000}", model.PairwiseProbabilityA(i))
                Next

                output.Write(ASCII.LF)
            End If

            If model.PairwiseProbabilityB IsNot Nothing Then
                output.Write("probB")

                For i As Integer = 0 To CInt(nr_class * (nr_class - 1) / 2) - 1
                    output.Write(" {0:0.000000}", model.PairwiseProbabilityB(i))
                Next

                output.Write(ASCII.LF)
            End If

            If model.NumberOfSVPerClass IsNot Nothing Then
                output.Write("nr_sv")

                For i = 0 To nr_class - 1
                    output.Write(" {0}", model.NumberOfSVPerClass(i))
                Next

                output.Write(ASCII.LF)
            End If

            output.Write("SV" & ASCII.LF)
            Dim sv_coef = model.SupportVectorCoefficients
            Dim SV = model.SupportVectors

            For i = 0 To l - 1

                For j = 0 To nr_class - 1 - 1
                    output.Write("{0:0.000000} ", sv_coef(j)(i))
                Next

                Dim p = SV(i)

                If p.Length = 0 Then
                    output.Write(ASCII.LF)
                    Continue For
                End If

                If param.KernelType = KernelType.PRECOMPUTED Then
                    output.Write("0:{0:0.000000}", CInt(p(0).value))
                Else
                    output.Write("{0}:{1:0.000000}", p(0).index, p(0).value)

                    For j = 1 To p.Length - 1
                        output.Write(" {0}:{1:0.000000}", p(j).index, p(j).value)
                    Next
                End If

                output.Write(ASCII.LF)
            Next

            output.Flush()
        End Sub

        Public Function ToString(model As Model) As String
            Dim sb As New StringBuilder

            Using text As New StringWriter(sb)
                Call Write(text, model)
            End Using

            Return sb.ToString
        End Function
    End Module
End Namespace
