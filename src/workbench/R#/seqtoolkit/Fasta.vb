﻿#Region "Microsoft.VisualBasic::96ee32bf3700bb8a62c3a6c3f8ee6fdb, R#\seqtoolkit\Fasta.vb"

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

' Module Fasta
' 
'     Constructor: (+1 Overloads) Sub New
'     Function: MSA, readFasta, readSeq, viewFasta
' 
' /********************************************************************************/

#End Region

Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Text
Imports SMRUCC.genomics.Analysis.SequenceTools.MSA
Imports SMRUCC.genomics.SequenceModel.FASTA
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Internal.ConsolePrinter
Imports SMRUCC.Rsharp.Runtime.Interop
Imports REnv = SMRUCC.Rsharp.Runtime.Internal

''' <summary>
''' Fasta sequence toolkit
''' </summary>
''' 
<Package("bioseq.fasta")>
Module Fasta

    Sub New()
        Call printer.AttachConsoleFormatter(Of FastaSeq)(AddressOf viewFasta)
        Call printer.AttachConsoleFormatter(Of MSAOutput)(AddressOf viewMSA)
    End Sub

    Private Function viewMSA(msa As MSAOutput) As String
        Dim sb As New StringBuilder

        Using text As New StringWriter(sb)
            Call msa.Print(16, text)
        End Using

        Return sb.ToString
    End Function

    Private Function viewFasta(seq As Object) As String
        If seq Is Nothing Then
            Return "NULL"
        End If

        Select Case seq
            Case GetType(FastaSeq)
                With DirectCast(seq, FastaSeq)
                    Return "> " & .Title & ASCII.LF & .SequenceData
                End With
            Case GetType(FastaFile)
                Return DirectCast(seq, FastaFile).Select(Function(fa) "> " & fa.Title).JoinBy(vbCrLf)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Function GetFastaSeq(a As Object) As IEnumerable(Of FastaSeq)
        If a Is Nothing Then
            Return {}
        Else
            Dim type As Type = a.GetType

            Select Case type
                Case GetType(FastaSeq)
                    Return {DirectCast(a, FastaSeq)}
                Case GetType(FastaFile)
                    Return DirectCast(a, FastaFile)
                Case Else
                    Throw New NotImplementedException(type.FullName)
            End Select
        End If
    End Function

    ''' <summary>
    ''' Read a single fasta sequence file
    ''' </summary>
    ''' <param name="file">
    ''' Just contains one sequence
    ''' </param>
    ''' <returns></returns>
    <ExportAPI("read.seq")>
    Public Function readSeq(file As String) As FastaSeq
        Return FastaSeq.Load(file)
    End Function

    <ExportAPI("read.fasta")>
    Public Function readFasta(file As String) As FastaFile
        Return FastaFile.Read(file)
    End Function

    ''' <summary>
    ''' Do multiple sequence alignment
    ''' </summary>
    ''' <param name="seqs"></param>
    ''' <returns></returns>
    <ExportAPI("MSA.of")>
    Public Function MSA(seqs As FastaFile) As MSAOutput
        Return seqs.MultipleAlignment(ScoreMatrix.DefaultMatrix)
    End Function

    <ExportAPI("fasta")>
    <RApiReturn(GetType(FastaFile))>
    Public Function Tofasta(x As Object, Optional env As Environment = Nothing) As Object
        If x Is Nothing Then
            Return Nothing
        ElseIf x.GetType Is GetType(MSAOutput) Then
            Return DirectCast(x, MSAOutput).ToFasta
        Else
            Return REnv.debug.stop(New NotImplementedException, env)
        End If
    End Function
End Module

