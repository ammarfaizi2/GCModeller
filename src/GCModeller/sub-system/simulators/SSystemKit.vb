﻿#Region "Microsoft.VisualBasic::5a3b726e7182c2af681ecbc31c970668, simulators\SSystemKit.vb"

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

' Module SSystemKit
' 
'     Function: ConfigEnvironment, ConfigSSystem, createKernel, GetSnapshotsDriver, RunKernel
'               script
' 
' /********************************************************************************/

#End Region


Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Analysis.SSystem.Kernel
Imports SMRUCC.genomics.Analysis.SSystem.Kernel.ObjectModels
Imports SMRUCC.genomics.Analysis.SSystem.Script
Imports SMRUCC.Rsharp.Interpreter.ExecuteEngine.ExpressionSymbols.Closure
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Internal.Invokes
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime.Interop
Imports REnv = SMRUCC.Rsharp.Runtime

<Package("S.system")>
Module SSystemKit

    <ExportAPI("S.script")>
    Public Function script(Optional title$ = "unnamed model", Optional description$ = "") As Model
        Return New Model With {
            .Title = title,
            .Comment = description
        }
    End Function

    <ExportAPI("kernel")>
    Public Function createKernel(snapshot As DataSnapshot, Optional model As Model = Nothing) As Kernel
        If model Is Nothing Then
            model = SSystemKit.script()
        End If

        Dim dataDriver As New DataAcquisition(AddressOf snapshot.Cache)
        Dim kernel As New Kernel(model, dataDriver)
        Dim kick As New Kicks(kernel, model)

        kick.loadKernel(kernel)
        dataDriver.loadKernel(kernel)

        Return kernel
    End Function

    <ExportAPI("environment")>
    Public Function ConfigEnvironment(kernel As Kernel, <RListObjectArgument> symbols As Object, Optional env As Environment = Nothing) As Kernel
        Dim data As list = If(TypeOf symbols Is list, DirectCast(symbols, list), base.Rlist(symbols, env))
        Dim value As Double

        If data.length = 1 AndAlso TypeOf data.slots.Values.First Is list Then
            data = data.slots.Values.First
        End If

        If Not data.getValue(Of Boolean)("is.const", env) Then
            data.slots.Remove("is.const")
            kernel.Vars = data.slots _
                .Select(Function(a)
                            Return New var With {
                                .Id = a.Key,
                                .Value = CDbl(getFirst(a.Value))
                            }
                        End Function) _
                .ToArray
        End If

        For Each symbolName As String In data.slots.Keys
            value = REnv.asVector(Of Double)(data.getByName(symbolName)).GetValue(Scan0)
            kernel.SetMathSymbol(symbolName, value)
        Next

        Return kernel
    End Function

    <ExportAPI("s.system")>
    Public Function ConfigSSystem(kernel As Kernel, ssystem As DeclareLambdaFunction(), Optional env As Environment = Nothing) As Kernel
        Dim equations As New List(Of NamedValue(Of String))
        Dim name As String
        Dim expression As String

        For Each formula In ssystem
            name = formula.parameterNames(Scan0)
            expression = formula.name.GetStackValue("[", "]").GetTagValue("->").Value
            equations += New NamedValue(Of String) With {
                .Name = name,
                .Value = expression
            }
        Next

        kernel.Channels = equations _
            .Select(Function(a) New SEquation(a.Name, a.Value)) _
            .Select(Function(a) New Equation(a, kernel)) _
            .ToArray

        Return kernel
    End Function

    <ExportAPI("run")>
    Public Function RunKernel(kernel As Kernel, Optional ticks As Integer = 100, Optional resolution As Double = 0.1) As Kernel
        kernel.finalTime = ticks
        kernel.precision = resolution

        For Each reaction As Equation In kernel.Channels
            reaction.precision = resolution
        Next

        kernel.Run()

        Return kernel
    End Function

    <ExportAPI("snapshot")>
    Public Function GetSnapshotsDriver(Optional file As String = Nothing, Optional symbols As String() = Nothing) As DataSnapshot
        If file.StringEmpty Then
            Return New MemoryCacheSnapshot
        Else
            Return New SnapshotStream(file, symbols)
        End If
    End Function
End Module
