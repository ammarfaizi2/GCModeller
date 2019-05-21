﻿#Region "Microsoft.VisualBasic::681757b512d978a2eebe4bfd4d365d48, Data_science\MachineLearning\MachineLearning\NeuralNetwork\Helpers.vb"

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

    '     Module Helpers
    ' 
    '         Properties: MaxEpochs, MinimumError
    ' 
    '         Function: GetRandom, (+2 Overloads) PopulateAllSynapses, ToDataMatrix
    ' 
    '     Enum TrainingType
    ' 
    '         Epoch, MinimumError
    ' 
    '  
    ' 
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language.Default
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.MachineLearning.NeuralNetwork.Activations
Imports Microsoft.VisualBasic.MachineLearning.NeuralNetwork.StoreProcedure

Namespace NeuralNetwork

    Public Module Helpers

        Public Property MaxEpochs As Integer = 10000
        Public Property MinimumError As Double = 0.01

        ''' <summary>
        ''' <see cref="Sigmoid"/> as default
        ''' </summary>
        Friend ReadOnly defaultActivation As DefaultValue(Of IActivationFunction) = New Sigmoid

        ReadOnly rand As New Random()

        ''' <summary>
        ''' 通过这个帮助函数生成``[-1, 1]``之间的随机数
        ''' </summary>
        ''' <returns></returns>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Friend Function GetRandom() As Double
            SyncLock rand
                Return 2 * rand.NextDouble() - 1
            End SyncLock
        End Function

        <Extension>
        Friend Function PopulateAllSynapses(neuron As Neuron) As IEnumerable(Of Synapse)
            Return neuron.InputSynapses + neuron.OutputSynapses.AsList
        End Function

        <Extension>
        Friend Iterator Function PopulateAllSynapses(network As Network) As IEnumerable(Of Synapse)
            For Each layer In network.HiddenLayer.AsList + {network.InputLayer, network.OutputLayer}
                For Each neuron In layer
                    For Each s In neuron.PopulateAllSynapses
                        Yield s
                    Next
                Next
            Next
        End Function

        <Extension>
        Public Function ToDataMatrix(Of T As {New, DynamicPropertyBase(Of Double), INamedValue})(samples As IEnumerable(Of Sample), names$(), outputNames$()) As IEnumerable(Of T)
            Dim nameIndex = names.SeqIterator
            Dim outsIndex = outputNames.SeqIterator

            Return samples _
                .Select(Function(sample)
                            Dim row As New T

                            row.Key = sample.ID
                            row.Properties = New Dictionary(Of String, Double)

                            Call nameIndex.DoEach(Sub(i) Call row.Add(i.value, sample.status(i)))
                            Call outsIndex.DoEach(Sub(i) Call row.Add(i.value, sample.target(i)))

                            Return row
                        End Function)
        End Function
    End Module

    Public Enum TrainingType
        ''' <summary>
        ''' 以给定的迭代次数的方式进行训练. <see cref="Helpers.MaxEpochs"/>
        ''' </summary>
        Epoch
        ''' <summary>
        ''' 以小于目标误差的方式进行训练. <see cref="Helpers.MinimumError"/>
        ''' </summary>
        MinimumError
    End Enum
End Namespace
