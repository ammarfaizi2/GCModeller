﻿#Region "Microsoft.VisualBasic::8a57dcd99772df23552550c9446405c6, ..\interops\meme_suite\MEME\Workflows\PromoterParser\GenePromoterParser.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
'       xie (genetics@smrucc.org)
' 
' Copyright (c) 2016 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.TagData
Imports Microsoft.VisualBasic.Extensions
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.TabularFormat
Imports SMRUCC.genomics.ComponentModel.Loci
Imports SMRUCC.genomics.SequenceModel
Imports SMRUCC.genomics.SequenceModel.FASTA

Namespace ContextModel

    ''' <summary>
    ''' 直接从基因的启动子区选取序列数据以及外加操纵子的第一个基因的启动子序列
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <[PackageNamespace]("Parser.Gene.Promoter", Publisher:="xie.guigang@gmail.com")>
    Public Class GenePromoterParser

        Public Shared ReadOnly Property PrefixLength As IReadOnlyList(Of Integer) = {100, 150, 200, 250, 300, 400, 500}

        Public ReadOnly Property PromoterRegions As IntegerTagged(Of Dictionary(Of String, FastaToken))()
        ReadOnly lengthIndex As New IndexOf(Of Integer)(PrefixLength)

        ''' <summary>
        ''' 基因组的Fasta核酸序列
        ''' </summary>
        ''' <param name="nt">全基因组序列</param>
        ''' <remarks></remarks>
        Sub New(nt As FastaToken, PTT As PTT)
            Dim genome As I_PolymerSequenceModel = nt
            Dim regions(PrefixLength.GetLength) As IntegerTagged(Of Dictionary(Of String, FastaToken))
            Dim i As int = 0

            For Each l% In PrefixLength
                regions(++i) = CreateObject(l, PTT, genome)
            Next
        End Sub

        Sub New(genome As PTTDbLoader)
            Call Me.New(genome.GenomeFasta, genome.ORF_PTT)
        End Sub

        ''' <summary>
        ''' 解析出所有基因前面的序列片段
        ''' </summary>
        ''' <param name="Length"></param>
        ''' <param name="PTT"></param>
        ''' <param name="GenomeSeq"></param>
        ''' <returns></returns>
        Private Shared Function CreateObject(Length As Integer, PTT As PTT, GenomeSeq As I_PolymerSequenceModel) As Dictionary(Of String, FASTA.FastaToken)
            Dim LQuery = (From gene As ComponentModels.GeneBrief
                          In PTT.GeneObjects.AsParallel
                          Select gene.Synonym,
                              Promoter = GetFASTA(gene, GenomeSeq, Length)).ToArray
            Dim DictData As Dictionary(Of String, FASTA.FastaToken) =
                LQuery.ToDictionary(Function(obj) obj.Synonym,
                                    Function(obj) obj.Promoter)
            Return DictData
        End Function

        Private Shared Function GetFASTA(Gene As ComponentModels.GeneBrief, GenomeSeq As I_PolymerSequenceModel, SegmentLength As Integer) As FASTA.FastaToken
            Dim Location As NucleotideLocation = Gene.Location

            Call Location.Normalization()

            If Location.Strand = Strands.Forward Then
                Location = New NucleotideLocation(Location.Left - SegmentLength, Location.Left)  ' 正向序列是上游，无需额外处理
            Else
                Location = New NucleotideLocation(Location.Right, Location.Right + SegmentLength, ComplementStrand:=True)  '反向序列是下游，需要额外小心
            End If

            Dim PromoterFsa As FASTA.FastaToken = New FASTA.FastaToken With {
                .Attributes = New String() {Gene.Synonym},
                .SequenceData = GenomeSeq.CutSequenceLinear(Location).SequenceData
            }

            Return PromoterFsa
        End Function

        Public Function GetRegionCollectionByLength(l%) As Dictionary(Of String, FastaToken)
            Dim i As Integer = Me.lengthIndex.IndexOf(l)
            Return Me.PromoterRegions(i%)
        End Function

        Public Function GetSequenceById(lstId As IEnumerable(Of String), <Parameter("Len")> Length As Integer) As FASTA.FastaFile
            Return GetSequenceById(Me, lstId, Length)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Promoter"></param>
        ''' <param name="idList"></param>
        ''' <param name="Length"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ExportAPI("Get.Sequence.By.Id")>
        Public Shared Function GetSequenceById(Promoter As GenePromoterParser,
                                               <Parameter("id.list", "The gene id list.")> idList As IEnumerable(Of String),
                                               <Parameter("Len")> Optional Length As Integer = 150) As FASTA.FastaFile
            If Not ContainsLength(Length) Then
                Call $"The promoter region length {Length} is not valid, using default value is 150bp.".__DEBUG_ECHO
                Length = 150
            End If

            Dim ListData As New List(Of String)(idList)

            Select Case Length
                Case 100
                    Return CType((From Fasta In Promoter.Promoter_150.AsParallel Where ListData.IndexOf(Fasta.Key) > -1 Select Fasta.Value).ToArray, SMRUCC.genomics.SequenceModel.FASTA.FastaFile)
                Case 150
                    Return CType((From Fasta In Promoter.Promoter_150.AsParallel Where ListData.IndexOf(Fasta.Key) > -1 Select Fasta.Value).ToArray, SMRUCC.genomics.SequenceModel.FASTA.FastaFile)
                Case 200
                    Return CType((From Fasta In Promoter.Promoter_200.AsParallel Where ListData.IndexOf(Fasta.Key) > -1 Select Fasta.Value).ToArray, SMRUCC.genomics.SequenceModel.FASTA.FastaFile)
                Case 250
                    Return CType((From Fasta In Promoter.Promoter_250.AsParallel Where ListData.IndexOf(Fasta.Key) > -1 Select Fasta.Value).ToArray, SMRUCC.genomics.SequenceModel.FASTA.FastaFile)
                Case 300
                    Return CType((From Fasta In Promoter.Promoter_300.AsParallel Where ListData.IndexOf(Fasta.Key) > -1 Select Fasta.Value).ToArray, SMRUCC.genomics.SequenceModel.FASTA.FastaFile)
                Case 350
                    Return CType((From Fasta In Promoter.Promoter_350.AsParallel Where ListData.IndexOf(Fasta.Key) > -1 Select Fasta.Value).ToArray, SMRUCC.genomics.SequenceModel.FASTA.FastaFile)
                Case 400
                    Return CType((From Fasta In Promoter.Promoter_400.AsParallel Where ListData.IndexOf(Fasta.Key) > -1 Select Fasta.Value).ToArray, SMRUCC.genomics.SequenceModel.FASTA.FastaFile)
                Case 450
                    Return CType((From Fasta In Promoter.Promoter_450.AsParallel Where ListData.IndexOf(Fasta.Key) > -1 Select Fasta.Value).ToArray, SMRUCC.genomics.SequenceModel.FASTA.FastaFile)
                Case 500
                    Return CType((From Fasta In Promoter.Promoter_500.AsParallel Where ListData.IndexOf(Fasta.Key) > -1 Select Fasta.Value).ToArray, SMRUCC.genomics.SequenceModel.FASTA.FastaFile)
                Case Else
                    Throw New Exception
            End Select
        End Function

        Private Shared Function ContainsLength(l As Integer) As Boolean
            Return Array.IndexOf(PrefixLength, l) > -1
        End Function
    End Class
End Namespace
