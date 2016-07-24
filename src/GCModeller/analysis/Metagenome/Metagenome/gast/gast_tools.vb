﻿#Region "Microsoft.VisualBasic::673b0760afb82ce78852ada79af71477, ..\Metagenome\gast\GastTools.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
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

Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Assembly
Imports SMRUCC.genomics.Assembly.NCBI
Imports SMRUCC.genomics.SequenceModel.FASTA

Namespace gast

    Public Module gast_tools

        <Extension>
        Public Function ExportSILVA([in] As String, EXPORT As String) As Boolean
            Dim reader As New StreamIterator([in])
            Dim out As String = EXPORT & "/" & [in].BaseName & ".fasta"
            Dim tax As String = out.TrimSuffix & ".tax"

            Call "".SaveTo(out)
            Call "".SaveTo(tax)

            Using ref As New StreamWriter(New FileStream(out, FileMode.OpenOrCreate)),
                taxon As New StreamWriter(New FileStream(tax, FileMode.OpenOrCreate))

                ref.NewLine = vbLf
                taxon.NewLine = vbLf

                For Each fa As FastaToken In reader.ReadStream
                    Dim title As String = fa.Title
                    Dim uid As String = title.Split.First
                    Dim taxnomy As String = Mid(title, uid.Length + 1).Trim

                    uid = uid.Replace(".", "_")
                    fa = New FastaToken({uid}, fa.SequenceData)
                    title = {uid, taxnomy, "1"}.JoinBy(vbTab)

                    Call ref.WriteLine(fa.GenerateDocument(60))
                    Call taxon.WriteLine(title)
                Next
            End Using

            Return True
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="[in]">file path of *.names</param>
        ''' <returns></returns>
        Public Iterator Function NamesClusterOut([in] As String) As IEnumerable(Of NamedValue(Of String()))
            Dim lines As String() = [in].ReadAllLines

            For Each line As String In lines
                Dim tokens As String() = Strings.Split(line, vbTab)

                Yield New NamedValue(Of String()) With {
                    .Name = tokens(Scan0),
                    .x = tokens(1).Split(","c)
                }
            Next
        End Function

        Public Function ExportNt(nt As String, gi2taxid As String, taxi_dmp As String, out As String) As Boolean
            Dim giTaxid As BucketDictionary(Of Integer, Integer) =
                NCBI.Taxonomy.AcquireAuto(gi2taxid)
            Dim tree As New NcbiTaxonomyTree(taxi_dmp)

            Using ref As StreamWriter = out.OpenWriter(Encodings.ASCII,),
                tax As StreamWriter = (out.TrimSuffix & ".tax").OpenWriter(Encodings.ASCII)

                For Each seq As FastaToken In New StreamIterator(nt).ReadStream
                    Dim title As String = seq.Title
                    Dim gi As Integer = __gi(title)
                    Dim taxid As Integer = giTaxid(gi)
                    Dim nodes As TaxonNode() = tree.GetAscendantsWithRanksAndNames(taxid, True)

                    If nodes.Length = 0 Then
                        Continue For
                    End If

                    Dim taxonomy As String = TaxonNode.Taxonomy(nodes, ";")

                    seq = New FastaToken({title}, seq.SequenceData)
                    title = {title, taxonomy, "1"}.JoinBy(vbTab)

                    Call ref.WriteLine(seq.GenerateDocument(120))
                    Call tax.WriteLine(title)
                Next
            End Using

            Return True
        End Function

        Private Function __gi(ByRef title As String) As Integer
            Dim gi As String = Regex.Match(title, "gi\|\S+", RegexICSng).Value

            title = gi
            title = title.NormalizePathString().Trim("_"c)
            gi = Regex.Match(title, "gi(\||_)\d+", RegexICSng).Value
            gi = Regex.Match(gi, "\d+").Value

            Return CInt(Val(gi))
        End Function

        Public Function ParseNames(path As String) As Names()
            Dim lines As IEnumerable(Of String) = path.IterateAllLines
            Dim LQuery = LinqAPI.MakeList(Of Names) <=
                From line As String
                In lines
                Let tokens As String() = Strings.Split(line, vbTab)
                Let uid As String = tokens(Scan0)
                Let members As String() = tokens(1).Split(","c)
                Select New Names With {
                    .members = members,
                    .NumOfSeqs = members.Length,
                    .Unique = uid
                }
            Return New Names With {
                .Unique = "Total",
                .NumOfSeqs = LQuery.Sum(Function(x) x.NumOfSeqs)
            } + LQuery
        End Function

        <Extension>
        Public Iterator Function FillTaxonomy(source As IEnumerable(Of Names), gast_out As String) As IEnumerable(Of Names)
            Dim hash As New Dictionary(Of gastOUT)(gast_out.Imports(Of gastOUT)(vbTab))
            Dim notAssigned As Integer

            For Each x As Names In source
                If Not hash.ContainsKey(x.Unique) Then
                    Yield x
                    Continue For
                Else

                End If

                Dim taxi As gastOUT = hash(x.Unique)
                x.taxonomy = taxi.taxonomy
                x.distance = taxi.distance
                x.ref = taxi.refhvr_ids

                If taxi.refhvr_ids = "NA" Then
                    notAssigned += x.NumOfSeqs
                End If

                Yield x
            Next

            Yield New Names With {
                .distance = -1,
                .NumOfSeqs = notAssigned,
                .ref = "N/A",
                .taxonomy = "null",
                .Unique = "Not-Assign"
            }
        End Function
    End Module

    ''' <summary>
    ''' *.names
    ''' </summary>
    Public Class Names : Implements sIdEnumerable

        Public Property Unique As String Implements sIdEnumerable.Identifier
        <Ignored> Public Property members As String()
        Public Property NumOfSeqs As Integer
        Public Property taxonomy As String
        Public Property distance As Double
        Public Property ref As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class

    Public Class gastOUT : Implements sIdEnumerable

        Public Property read_id As String Implements sIdEnumerable.Identifier
        Public Property taxonomy As String
        Public Property distance As Double
        Public Property rank As String
        Public Property refssu_count As String
        Public Property vote As String
        Public Property minrank As String
        Public Property taxa_counts As String
        Public Property max_pcts As String
        Public Property na_pcts As String
        Public Property refhvr_ids As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class
End Namespace
