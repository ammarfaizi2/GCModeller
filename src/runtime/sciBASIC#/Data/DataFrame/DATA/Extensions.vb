﻿#Region "Microsoft.VisualBasic::e6b5bf1c4cc5665ad1fe225c00cc069c, Data\DataFrame\DATA\Extensions.vb"

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

    '     Module Extensions
    ' 
    '         Sub: ProjectLargeDataFrame
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.IO
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Data.csv.IO

Namespace DATA

    <HideModuleName>
    Public Module Extensions

        Public Sub ProjectLargeDataFrame(targetFile$, columns As IEnumerable(Of String), output As TextWriter)
            Dim headers As Index(Of String) = Tokenizer.CharsParser(targetFile.ReadFirstLine)
            Dim index As Integer() = headers.GetOrdinal(columns)
            Dim row As RowObject

            row = New RowObject(index.Select(Function(i) headers(i)))
            output.WriteLine(row.AsLine)

            For Each line As String In targetFile.IterateAllLines.Skip(1)
                row = Tokenizer.CharsParser(line)
                row = row.Takes(index)
                output.WriteLine(row.AsLine)
            Next

            Call output.Flush()
        End Sub
    End Module
End Namespace