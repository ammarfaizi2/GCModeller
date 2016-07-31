﻿Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic

Public Module Genotype

    <Extension>
    Public Function Stattics(source As IEnumerable(Of GenotypeDetails)) As DocumentStream.File

    End Function

    ''' <summary>
    ''' Example: ``C: 0.844 (162)``
    ''' </summary>
    ''' <param name="raw"></param>
    ''' <returns></returns>
    <Extension>
    Public Function FrequencyParser(raw As String) As Frequency
        Dim base As Char = raw.First
        raw = Mid(raw, 3).Trim
        Dim Count As String = Regex.Match(raw, "\(\d+\)").Value.GetStackValue("(", ")")
        Dim f As Double = Val(raw)

        Return New Frequency With {
            .base = base,
            .Count = CInt(Count),
            .Frequency = f
        }
    End Function

    Const Frequency As String = "[ATGC]: \d\.\d+ \(\d+\)"

    Public Function Frequencies(field As String) As Frequency()
        Dim fs As String() = Regex.Matches(field, Frequency, RegexICSng).ToArray
        Return fs.ToArray(AddressOf FrequencyParser)
    End Function

    Const Genotype As String = "[ATGC]\|[ATGC] \d\.\d+ \(\d+\)"

    Public Function Genotypes(field As String) As Frequency()
        Dim fs As String() = Regex.Matches(field, Genotype, RegexICSng).ToArray
        Dim out As New List(Of Frequency)

        For Each m As String In fs
            Dim g As Char = m.First
            m = Mid(m, 3).Trim
            Dim f As Frequency = FrequencyParser(m)
            f.type = g
            out += f
        Next

        Return out
    End Function
End Module

Public Class GenotypeDetails

    Public Property Population As String

    <Column("Allele: frequency (count)")>
    Public Property AlleleFrequency As String
        Get
            Return String.Join("", Frequency.ToArray(Function(x) x.ToString))
        End Get
        Set(value As String)
            _Frequency = Genotype.Frequencies(value)
        End Set
    End Property

    <Column("Genotype: frequency (count)")>
    Public Property GenotypeFreqnency As String
        Get
            Return String.Join("", Genotypes.ToArray(Function(x) x.ToString))
        End Get
        Set(value As String)
            _Genotypes = Genotype.Genotypes(value)
        End Set
    End Property

    Public ReadOnly Property Frequency As Frequency()
    Public ReadOnly Property Genotypes As Frequency()

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class

Public Class Frequency

    ''' <summary>
    ''' 分子
    ''' </summary>
    ''' <returns></returns>
    Public Property type As Char
    ''' <summary>
    ''' 分母
    ''' </summary>
    ''' <returns></returns>
    Public Property base As Char
    Public Property Frequency As Double
    Public Property Count As Integer

    Public Overrides Function ToString() As String
        If type = Nothing OrElse type = NIL Then
            Return $"{base}: {Frequency} ({Count})"
        Else
            Return $"{type}|{base}: {Frequency} ({Count})"
        End If
    End Function
End Class