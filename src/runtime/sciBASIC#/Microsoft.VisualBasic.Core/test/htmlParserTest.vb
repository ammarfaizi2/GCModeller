﻿Imports Microsoft.VisualBasic.Text.Parser.HtmlParser

Module htmlParserTest

    Sub Main()
        Dim testhtml = "D:\GCModeller\src\runtime\sciBASIC#\Microsoft.VisualBasic.Core\test\testhtml.txt".ReadAllText

        Dim list = testhtml.HtmlList


        Pause()
    End Sub
End Module
