﻿#Region "Microsoft.VisualBasic::4e9b28e639dc0b3bd0143cd5bc685652, core\Bio.Assembly\SequenceModel\NucleicAcid\Translation\TranslTable.vb"

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

'     Class TranslTable
' 
'         Properties: CodenTable, InitCodons, StopCodons, TranslTable
' 
'         Constructor: (+2 Overloads) Sub New
' 
'         Function: __checkDirection, __parseHash, __parseTable, __split, __trimForce
'                   CreateFrom, Find, GetEnumerator, GetTable, IEnumerable_GetEnumerator
'                   IsInitCoden, (+2 Overloads) IsStopCoden, IsStopCodon, ToCodonCollection, ToString
'                   (+2 Overloads) Translate
' 
'         Sub: __initProfiles
' 
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel.Algorithm.base
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq.Extensions
Imports SMRUCC.genomics.SequenceModel.NucleotideModels.Conversion
Imports SMRUCC.genomics.SequenceModel.NucleotideModels.NucleicAcid
Imports SMRUCC.genomics.SequenceModel.Polypeptides
Imports SMRUCC.genomics.SequenceModel.Polypeptides.Polypeptide

Namespace SequenceModel.NucleotideModels.Translation

    ''' <summary>
    ''' Compiled by Andrzej (Anjay) Elzanowski and Jim Ostell at National Center for Biotechnology Information (NCBI), Bethesda, Maryland, U.S.A.
    ''' 
    ''' NCBI takes great care To ensure that the translation For Each coding sequence (CDS) present In GenBank records Is correct. 
    ''' Central To this effort Is careful checking On the taxonomy Of Each record And assignment Of the correct genetic code 
    ''' (shown As a /transl_table qualifier On the CDS In the flat files) For Each organism And record. This page summarizes And references this work.
    ''' 
    ''' The synopsis presented below Is based primarily On the reviews by Osawa et al. (1992) And Jukes And Osawa (1993). 
    ''' Listed In square brackets [] (under Systematic Range) are tentative assignments Of a particular code based On 
    ''' sequence homology And/Or phylogenetic relationships.
    ''' 
    ''' The print-form ASN.1 version Of this document, which includes all the genetic codes outlined below, Is also available here. 
    ''' Detailed information On codon usage can be found at the Codon Usage Database.
    ''' 
    ''' GenBank format by historical convention displays mRNA sequences Using the DNA alphabet. 
    ''' Thus, For the convenience Of people reading GenBank records, the genetic code tables shown here use T instead Of U.
    ''' 
    ''' The following genetic codes are described here:
    ''' 
    ''' 1. The Standard Code
    ''' 2. The Vertebrate Mitochondrial Code
    ''' 3. The Yeast Mitochondrial Code
    ''' 4. The Mold, Protozoan, And Coelenterate Mitochondrial Code And the Mycoplasma/Spiroplasma Code
    ''' 5. The Invertebrate Mitochondrial Code
    ''' 6. The Ciliate, Dasycladacean And Hexamita Nuclear Code
    ''' 9. The Echinoderm And Flatworm Mitochondrial Code
    ''' 10. The Euplotid Nuclear Code
    ''' 11. The Bacterial, Archaeal And Plant Plastid Code
    ''' 12. The Alternative Yeast Nuclear Code
    ''' 13. The Ascidian Mitochondrial Code
    ''' 14. The Alternative Flatworm Mitochondrial Code
    ''' 16. Chlorophycean Mitochondrial Code
    ''' 21. Trematode Mitochondrial Code
    ''' 22. Scenedesmus obliquus Mitochondrial Code
    ''' 23. Thraustochytrium Mitochondrial Code
    ''' 24. Pterobranchia Mitochondrial Code
    ''' 25. Candidate Division SR1 And Gracilibacteria Code
    ''' 
    ''' > http://www.ncbi.nlm.nih.gov/Taxonomy/taxonomyhome.html/index.cgi?chapter=tgencodes#SG25
    ''' </summary>
    Public Class TranslTable : Implements IEnumerable(Of KeyValuePair(Of Integer, AminoAcid))

        ''' <summary>
        ''' 遗传密码子表（哈希表）
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property CodenTable As IReadOnlyDictionary(Of Integer, AminoAcid)
        ''' <summary>
        ''' transl_table=<see cref="Transltable"/>
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property TranslTable As GeneticCodes

        Public ReadOnly Property InitCodons As Integer()
        Public ReadOnly Property StopCodons As Integer()

        Friend Sub New(index As GeneticCodes, transl_table As Dictionary(Of Codon, AminoAcid))
            TranslTable = index

            ' config codon data
            Call doInitProfiles(transl_table, _StopCodons, _InitCodons, _CodenTable)
        End Sub

        ''' <summary>
        ''' 判断某一个密码子是否为终止密码子
        ''' </summary>
        ''' <param name="hash">该密码子的哈希值</param>
        ''' <returns>这个密码子是否为一个终止密码</returns>
        ''' <remarks></remarks>
        Public Function IsStopCoden(hash As Integer) As Boolean
            Return Array.IndexOf(StopCodons, hash) > -1
        End Function

        Public Function IsStopCoden(Coden As NucleotideModels.Translation.Codon) As Boolean
            Dim hash As Integer = Coden.TranslHash
            Return Array.IndexOf(StopCodons, hash) > -1
        End Function

        ''' <summary>
        ''' 将一条核酸链翻译为蛋白质序列
        ''' </summary>
        ''' <param name="nucleicAcid"></param>
        ''' <param name="force">强制程序跳过终止密码子</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Translate(nucleicAcid As String, force As Boolean) As String
            Dim sb As New StringBuilder(1024)
            Dim tokens As Char()

            nucleicAcid = doCheckNtDirection(nucleicAcid)

            For i As Integer = 1 To Len(nucleicAcid) Step 3
                tokens = Mid(nucleicAcid, i, 3)

                If tokens.Length = 3 Then
                    Dim hash As Integer = Translation.TranslTable.GetHashCode(tokens(0), tokens(1), tokens(2))

                    If IsStopCoden(hash) Then
                        If force Then
                            Call sb.Append(ForceStopCoden)
                        Else
                            Exit For
                        End If
                    Else
                        Dim aa As AminoAcid = CodenTable(hash)
                        Dim ch As Char = Polypeptides.Polypeptide.ToChar(aa)

                        Call sb.Append(ch)
                    End If
                End If
            Next

            Dim prot As String = sb.ToString

            If force Then
                Return doTrimOfForce(prot)
            Else
                Return prot
            End If
        End Function

        ''' <summary>
        ''' 三个字母所表示的三联体密码子
        ''' </summary>
        ''' <param name="coden"></param>
        ''' <returns></returns>
        Public Function IsStopCodon(coden As String) As Boolean
            If coden.Length = 3 Then
                Return IsStopCoden(GetHashCode(coden(0), coden(1), coden(2)))
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' 三个字母所表示的三联体密码子
        ''' </summary>
        ''' <param name="coden"></param>
        ''' <returns></returns>
        Public Function IsInitCoden(coden As String) As Boolean
            If coden.Length = 3 Then
                Return Array.IndexOf(InitCodons, GetHashCode(coden(0), coden(1), coden(2))) > -1
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Check nt sequence direction by start and stop codon
        ''' </summary>
        ''' <param name="sequence"></param>
        ''' <returns></returns>
        Private Function doCheckNtDirection(sequence As String) As String
            Dim First As String = Mid(sequence, 1, 3)
            Dim last As String = Mid(sequence, Len(sequence) - 3)

            If IsInitCoden(First) Then
                ' 正常的序列
                Return sequence
            End If

            Dim lastAsInit As String = New String(last.Reverse.ToArray)

            If IsInitCoden(lastAsInit) Then
                ' 方向可能颠倒了
                Call $"This sequence is possibly in reverse direction...".__DEBUG_ECHO
                Return New String(sequence.Reverse.ToArray)
            End If

            First = NucleicAcid.Complement(First)

            If IsInitCoden(First) Then
                ' 互补的序列
                Call $"This sequence is possibly in complement strand...".__DEBUG_ECHO
                Return NucleicAcid.Complement(sequence)
            End If

            lastAsInit = NucleicAcid.Complement(lastAsInit)

            If IsInitCoden(lastAsInit) Then
                ' 方向可能颠倒了
                Call $"This sequence is possibly in reverse&complement strand...".__DEBUG_ECHO
                Return New String(NucleicAcid.Complement(sequence).Reverse.ToArray)
            End If

            ' 实在判断不出来了，只能够硬着头皮翻译下去了 
            Return sequence
        End Function

        Private Function doTrimOfForce(prot As String) As String
            If prot.Last = ForceStopCoden Then
                prot = Mid(prot, 1, Len(prot) - 1)
            End If

            Return prot
        End Function

        Const ForceStopCoden As Char = "-"c

        Public Function Translate(nt As IPolymerSequenceModel, force As Boolean) As String
            Return Translate(nt.SequenceData, force)
        End Function

        Public Function Translate(SequenceData As NucleicAcid, force As Boolean) As String
            Return Translate(SequenceData.SequenceData, force)
        End Function

        ''' <summary>
        ''' 没有终止密码子，非翻译用途的
        ''' </summary>
        ''' <param name="nt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ToCodonCollection(nt As NucleicAcid) As Codon()
            Dim codons = nt.ToArray.CreateSlideWindows(3, offset:=3)
            Dim aa As Codon() = LinqAPI.Exec(Of Codon) _
 _
                () <= From Codon As SlideWindow(Of DNA)
                      In codons
                      Let aac As Codon = New Codon With {
                         .X = Codon.Items(0),
                         .Y = Codon.Items(1),
                         .Z = Codon.Items(2)
                      }
                      Select aac

            ' 由于使用无参数的构造函数构造出来的密码子对象是
            ' 没有启动和终止的信息的， 所以使用当前的翻译表
            ' 的终止密码表来判断
            aa = (From codon As Codon
                  In aa
                  Where Array.IndexOf(StopCodons, codon.TranslHash) = -1
                  Select codon).ToArray

            Return aa
        End Function

        ''' <summary>
        ''' Available index value was described at http://www.ncbi.nlm.nih.gov/Taxonomy/taxonomyhome.html/index.cgi?chapter=tgencodes#SG25
        ''' </summary>
        ''' <param name="index"></param>
        ''' <returns></returns>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function GetTable(index As Integer) As TranslTable
            Return _tables(index)
        End Function

        Protected Shared ReadOnly _tables As New Dictionary(Of Integer, TranslTable) From {
 _
            {1, ParseTable(My.Resources.transl_table_1)},
            {2, ParseTable(My.Resources.transl_table_2)},
            {3, ParseTable(My.Resources.transl_table_3)},
            {4, ParseTable(My.Resources.transl_table_4)},
            {5, ParseTable(My.Resources.transl_table_5)},
            {6, ParseTable(My.Resources.transl_table_6)},
            {9, ParseTable(My.Resources.transl_table_9)},
            {10, ParseTable(My.Resources.transl_table_10)},
            {11, ParseTable(My.Resources.transl_table_11)},
            {12, ParseTable(My.Resources.transl_table_12)},
            {13, ParseTable(My.Resources.transl_table_13)},
            {14, ParseTable(My.Resources.transl_table_14)},
            {16, ParseTable(My.Resources.transl_table_16)},
            {21, ParseTable(My.Resources.transl_table_21)},
            {22, ParseTable(My.Resources.transl_table_22)},
            {23, ParseTable(My.Resources.transl_table_23)},
            {24, ParseTable(My.Resources.transl_table_24)},
            {25, ParseTable(My.Resources.transl_table_25)}
        }

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Overloads Shared Function GetHashCode(r1 As Char, r2 As Char, r3 As Char) As Integer
            Return Codon.CalTranslHash(
                X:=NucleotideConvert(r1),
                Y:=NucleotideConvert(r2),
                Z:=NucleotideConvert(r3)
            )
        End Function

        Public Iterator Function GetEnumerator() As IEnumerator(Of KeyValuePair(Of Integer, AminoAcid)) _
            Implements IEnumerable(Of KeyValuePair(Of Integer, AminoAcid)).GetEnumerator

            For Each codon In Me.CodenTable
                Yield codon
            Next
        End Function

        Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function

        Public Shared Function ParseTable(hashTable As String) As TranslTable
            Dim transl_table As GeneticCodes
            Dim hashTokens As String() = hashTable.LineTokens
            Dim codes As Dictionary(Of Codon, AminoAcid) = doParseTable(hashTokens, transl_table)
            Dim table As New TranslTable(transl_table, codes)

            Return table
        End Function

        Public Overrides Function ToString() As String
            Return $"transl_table={TranslTable}"
        End Function
    End Class
End Namespace
