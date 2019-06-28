﻿#Region "Microsoft.VisualBasic::0b47bfe62d853bbca7261d24dfc19c59, Data_science\MachineLearning\MachineLearning\NeuralNetwork\ActiveFunctions\ReLU.vb"

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

'     Class ReLU
' 
'         Properties: Store
' 
'         Function: [Function], Derivative, Derivative2, ToString
' 
' 
' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.MachineLearning.NeuralNetwork.StoreProcedure
Imports Microsoft.VisualBasic.Text.Xml.Models

Namespace NeuralNetwork.Activations

    Public Class ReLU : Inherits IActivationFunction

        Public Overrides ReadOnly Property Store As ActiveFunction
            Get
                Return New ActiveFunction With {
                    .Arguments = {
                        New NamedValue With {
                            .name = "threshold",
                            .text = threshold
                        }
                    },
                    .name = NameOf(ReLU)
                }
            End Get
        End Property

        ReadOnly threshold# = 0

        Sub New()
        End Sub

        Sub New(threshold As Double)
            Me.threshold = threshold
        End Sub

        Public Overrides Function [Function](x As Double) As Double
            If x < threshold Then
                Return threshold
            Else
                Return x
            End If
        End Function

        Public Overrides Function Derivative(x As Double) As Double
            Return 1
        End Function

        Public Overrides Function Derivative2(y As Double) As Double
            Return 1
        End Function

        Public Overrides Function ToString() As String
            Return $"{NameOf(ReLU)}()"
        End Function
    End Class
End Namespace
