﻿Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.foundation
Imports SMRUCC.genomics.foundation.BIOM.v10
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Components
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime.Interop

''' <summary>
''' the BIOM file toolkit
''' </summary>
<Package("BIOM_kit")>
Public Module BIOMkit

    Sub New()
        Internal.Object.Converts.makeDataframe.addHandler(GetType(BIOMDataSet(Of Double)), AddressOf asDataFrame)
    End Sub

    ''' <summary>
    ''' read matrix data from a given BIOM file.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="env"></param>
    ''' <returns></returns>
    <ExportAPI("read.matrix")>
    <RApiReturn(GetType(BIOMDataSet(Of Double)))>
    Public Function readMatrix(file As Object,
                               Optional denseMatrix As Boolean = True,
                               Optional env As Environment = Nothing) As Object

        If file Is Nothing Then
            Return Internal.debug.stop("the given file can not be nothing!", env)
        ElseIf TypeOf file Is String Then
            If DirectCast(file, String).FileExists Then
                Return BIOM.ReadAuto(file, denseMatrix:=denseMatrix)
            Else
                Return Internal.debug.stop("the given file is not found on your filesystem!", env)
            End If
        Else
            Return Internal.debug.stop(Message.InCompatibleType(GetType(String), file.GetType, env), env)
        End If
    End Function

    Public Function asDataFrame(x As Object, args As list, env As Environment) As dataframe
        Dim biomTable As BIOMDataSet(Of Double) = DirectCast(x, BIOMDataSet(Of Double))
        Dim columns As New Dictionary(Of String, List(Of Double))
        Dim taxonomyNames As New List(Of String)

        For Each otu As NamedValue(Of [Property](Of Double)) In biomTable.PopulateRows
            For Each col In otu.Value
                If Not columns.ContainsKey(col.Name) Then
                    Call columns.Add(col.Name, New List(Of Double))
                End If

                Call columns(col.Name).Add(col.Value)
            Next

            Call taxonomyNames.Add(otu.Name)
        Next

        Return New dataframe With {
            .columns = columns _
                .ToDictionary(Function(a) a.Key,
                              Function(a)
                                  Return DirectCast(a.Value.ToArray, Array)
                              End Function),
            .rownames = taxonomyNames.ToArray
        }
    End Function
End Module
