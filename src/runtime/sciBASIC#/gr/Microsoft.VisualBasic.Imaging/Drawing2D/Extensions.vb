﻿#Region "Microsoft.VisualBasic::d413443711d19e0ae6df0214a17b7395, ..\sciBASIC#\gr\Microsoft.VisualBasic.Imaging\Drawing2D\Extensions.vb"

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

Imports System.Drawing
Imports System.Runtime.CompilerServices

Namespace Drawing2D

    Public Module Extensions

        <Extension>
        Public Function Enlarge(size As SizeF, fold#) As SizeF
            With size
                Return New SizeF(.Width * fold, .Height * fold)
            End With
        End Function
    End Module
End Namespace
