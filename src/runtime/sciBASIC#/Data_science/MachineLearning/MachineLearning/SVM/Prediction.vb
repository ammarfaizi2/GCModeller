﻿#Region "Microsoft.VisualBasic::9ce236e78dd8eb57a9e58293d7e2592a, Data_science\MachineLearning\MachineLearning\SVM\Prediction.vb"

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

    '     Module Prediction
    ' 
    '         Function: (+2 Overloads) Predict, PredictLabels, PredictLabelsProbability, PredictProbability
    ' 
    '         Sub: exit_with_help
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



Imports System.IO
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Text

Namespace SVM

    ''' <summary>
    ''' Class containing the routines to perform class membership prediction using a trained SVM.
    ''' </summary>
    Public Module Prediction

        ''' <summary>
        ''' Predicts the class memberships of all the vectors in the problem.
        ''' </summary>
        ''' <param name="problem">The SVM Problem to solve</param>
        ''' <param name="outputFile">File for result output</param>
        ''' <param name="model">The Model to use</param>
        ''' <param name="predict_probability">Whether to output a distribution over the classes</param>
        ''' <returns>Percentage correctly labelled</returns>
        Public Function Predict(problem As Problem, outputFile As String, model As Model, predict_probability As Boolean) As Double
            Dim correct = 0
            Dim total = 0
            Dim [error] As Double = 0
            Dim sumv As Double = 0, sumy As Double = 0, sumvv As Double = 0, sumyy As Double = 0, sumvy As Double = 0
            Dim output As StreamWriter = If(Not Equals(outputFile, Nothing), New StreamWriter(outputFile), Nothing)
            Dim svm_type = svm_get_svm_type(model)
            Dim nr_class = svm_get_nr_class(model)
            Dim labels = New Integer(nr_class - 1) {}
            Dim prob_estimates As Double() = Nothing

            If predict_probability Then
                If svm_type = SvmType.EPSILON_SVR OrElse svm_type = SvmType.NU_SVR Then
                    Console.WriteLine("Prob. model for test data: target value = predicted value + z," & ASCII.LF & "z: Laplace distribution e^(-|z|/sigma)/(2sigma),sigma=" & svm_get_svr_probability(model))
                Else
                    svm_get_labels(model, labels)
                    prob_estimates = New Double(nr_class - 1) {}

                    If output IsNot Nothing Then
                        output.Write("labels")

                        For j = 0 To nr_class - 1
                            output.Write(" " & labels(j))
                        Next

                        output.Write(ASCII.LF)
                    End If
                End If
            End If

            For i = 0 To problem.Count - 1
                Dim target = problem.Y(i)
                Dim x = problem.X(i)
                Dim v As Double

                If predict_probability AndAlso (svm_type = SvmType.C_SVC OrElse svm_type = SvmType.NU_SVC) Then
                    v = svm_predict_probability(model, x, prob_estimates)

                    If output IsNot Nothing Then
                        output.Write(v & " ")

                        For j = 0 To nr_class - 1
                            output.Write(prob_estimates(j) & " ")
                        Next

                        output.Write(ASCII.LF)
                    End If
                Else
                    v = svm_predict(model, x)
                    If output IsNot Nothing Then output.Write(v & ASCII.LF)
                End If

                If v = target Then Threading.Interlocked.Increment(correct)
                [error] += (v - target) * (v - target)
                sumv += v
                sumy += target
                sumvv += v * v
                sumyy += target * target
                sumvy += v * target
                Threading.Interlocked.Increment(total)
            Next

            If output IsNot Nothing Then output.Close()

            If model.Parameter.SvmType = SvmType.EPSILON_SVR OrElse model.Parameter.SvmType = SvmType.NU_SVR Then
                Return [error] / total
            Else
                Return correct / total
            End If
        End Function

        ''' <summary>
        ''' Predict the labels for all the data points in a problem.
        ''' </summary>
        ''' <param name="model">The model to use</param>
        ''' <param name="problem">The problem to solve</param>
        ''' <returns>The predicted labels</returns>
        <Extension()>
        Public Function PredictLabels(model As Model, problem As Problem) As Double()
            Return problem.X.[Select](Function(o) model.Predict(o)).ToArray()
        End Function

        ''' <summary>
        ''' Predict the probability distributions over all labels for each data point in a problem.
        ''' </summary>
        ''' <param name="model">The model to use</param>
        ''' <param name="problem">The problem to solve</param>
        ''' <returns>A distribution over labels for each data point</returns>
        <Extension()>
        Public Function PredictLabelsProbability(model As Model, problem As Problem) As Double()()
            Return problem.X.[Select](Function(o) model.PredictProbability(o)).ToArray()
        End Function

        ''' <summary>
        ''' Predict the class for a single input vector.
        ''' </summary>
        ''' <param name="model">The Model to use for prediction</param>
        ''' <param name="x">The vector for which to predict class</param>
        ''' <returns>The result</returns>
        <Extension()>
        Public Function Predict(model As Model, x As Node()) As Double
            Return svm_predict(model, x)
        End Function

        ''' <summary>
        ''' Predicts a class distribution for the single input vector.
        ''' </summary>
        ''' <param name="model">Model to use for prediction</param>
        ''' <param name="x">The vector for which to predict the class distribution</param>
        ''' <returns>A probability distribtion over classes</returns>
        <Extension()>
        Public Function PredictProbability(model As Model, x As Node()) As Double()
            Dim svm_type = svm_get_svm_type(model)
            If svm_type <> SvmType.C_SVC AndAlso svm_type <> SvmType.NU_SVC Then Throw New Exception("Model type " & svm_type & " unable to predict probabilities.")
            Dim nr_class = svm_get_nr_class(model)
            Dim probEstimates = New Double(nr_class - 1) {}
            svm_predict_probability(model, x, probEstimates)
            Return probEstimates
        End Function

        Private Sub exit_with_help()
            Debug.Write("usage: svm_predict [options] test_file model_file output_file" & ASCII.LF & "options:" & ASCII.LF & "-b probability_estimates: whether to predict probability estimates, 0 or 1 (default 0); one-class SVM not supported yet" & ASCII.LF)
            Environment.Exit(1)
        End Sub
    End Module
End Namespace