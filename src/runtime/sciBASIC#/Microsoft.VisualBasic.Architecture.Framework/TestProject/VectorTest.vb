﻿Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Text.Xml.Models

Module VectorTest

    Structure fdddd
        Public Shared Operator &(a As fdddd, b$) As String

        End Operator

        Public Shared Operator *(a As fdddd, b$) As String

        End Operator
        Public Shared Operator ^(a As fdddd, b$) As String

        End Operator
        Public Shared Operator Mod(a As fdddd, b$) As String

        End Operator
        Public Shared Operator Like(a As fdddd, b$) As String

        End Operator
        Public Shared Operator Xor(a As fdddd, b$) As String

        End Operator
        Public Shared Operator And(a As fdddd, b$) As String

        End Operator
        Public Shared Operator Or(a As fdddd, b$) As String

        End Operator
        Public Shared Operator \(a As fdddd, b$) As String

        End Operator

        Public Shared Operator -(a As fdddd) As Boolean

        End Operator

    End Structure

    Structure str

        Public Property pattern$

        Public Shared Operator Like(str As str, s$) As Boolean
            Return s.IsPattern(str.pattern, RegexICSng)
        End Operator
    End Structure

    Sub Main()

        'Dim strings = {"", "sdafa", "sssssss"}.VectorShadows

        'Dim newStrings$() = strings & strings

        'Call newStrings.GetJson.__DEBUG_ECHO


        '        Pause()

        Dim patterns = {
            New str With {.pattern = "\d+"},
            New str With {.pattern = "\s+"},
            New str With {.pattern = "\S+"}
        }.VectorShadows

        Dim index%() = Which.IsTrue(patterns Like "123")
        Dim patternList = patterns.pattern

        Call index.GetJson.__DEBUG_ECHO
        Call CType(patternList, IEnumerable(Of String)).ToArray.GetJson.__DEBUG_ECHO


        Dim vector = {1.0R, 2.0R, 3.0R, 4.0R, 5.0R, 6.0R, 7.0R, 8.0R, 9.0R, 10.0R}.VectorShadows
        Dim list As New List(Of String) From {"A1", "B2", "C3", "D4", "E5", "F6", "G7", "H8", "I9", "J10"}


        Dim sublist As String() = list(vector > 5.0R)

        Call sublist.GetJson.__DEBUG_ECHO

        'Dim dddd = vector Like 1234
        'Dim fffff = vector \ 33333

        'Dim ddddddd = vector Or fffff

        'Pause()

        'Dim textArray As Integer() = vector.value 'As Integer()

        'Call textArray.GetJson.__DEBUG_ECHO

        'Dim newText%() = {4, 5, 6, 7}

        'vector.value = newText

        'Dim gt = vector > 3

        Pause()
    End Sub
End Module
