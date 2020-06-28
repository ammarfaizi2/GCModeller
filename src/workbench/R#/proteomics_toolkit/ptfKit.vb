﻿Imports System.IO
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Annotation.Ptf
Imports SMRUCC.Rsharp
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Components
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime.Interop

''' <summary>
''' toolkit for handle ptf annotation data set
''' </summary>
''' 
<Package("ptfKit")>
Module ptfKit

    <ExportAPI("load.ptf")>
    Public Function loadPtf(file As Object, Optional env As Environment = Nothing) As pipeline
        Dim stream = GetFileStream(file, FileAccess.Read, env)

        If stream Like GetType(Message) Then
            Return stream.TryCast(Of Message)
        End If

        Dim tryClose = Sub()
                           If TypeOf file Is String Then
                               Try
                                   Call stream.TryCast(Of Stream).Close()
                               Catch ex As Exception

                               End Try
                           End If
                       End Sub

        Return PtfFile _
            .ReadAnnotations(stream.TryCast(Of Stream)) _
            .DoCall(Function(anno)
                        Return pipeline.CreateFromPopulator(
                            upstream:=anno,
                            finalize:=tryClose
                        )
                    End Function)
    End Function

    <ExportAPI("filter")>
    Public Function filterBykey(<RRawVectorArgument> ptf As Object, key$, Optional env As Environment = Nothing) As pipeline
        Dim upstream As pipeline = pipeline.TryCreatePipeline(Of ProteinAnnotation)(ptf, env)

        If upstream.isError Then
            Return upstream
        End If

        Return upstream _
            .populates(Of ProteinAnnotation) _
            .Where(Function(protein)
                       Return protein.attributes.ContainsKey(key)
                   End Function) _
            .DoCall(AddressOf pipeline.CreateFromPopulator)
    End Function

    <ExportAPI("save.ptf")>
    <RApiReturn(GetType(Boolean))>
    Public Function savePtf(<RRawVectorArgument> ptf As Object, file As Object, Optional env As Environment = Nothing) As Object
        Dim stream = GetFileStream(file, FileAccess.Write, env)
        Dim anno As pipeline = pipeline.TryCreatePipeline(Of ProteinAnnotation)(ptf, env)

        If anno.isError Then
            Return anno.getError
        End If
        If stream Like GetType(Message) Then
            Return stream.TryCast(Of Message)
        End If

        Using writer As New StreamWriter(stream) With {.NewLine = vbLf}
            Call PtfFile.WriteStream(
                annotation:=anno.populates(Of ProteinAnnotation),
                file:=writer
            )
        End Using

        Return True
    End Function
End Module
