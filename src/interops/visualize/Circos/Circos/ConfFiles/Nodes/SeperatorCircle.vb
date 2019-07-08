﻿#Region "Microsoft.VisualBasic::32a97cb02dfe0239bac5b238d4f98537, Circos\Circos\ConfFiles\Nodes\SeperatorCircle.vb"

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

    '     Class SeperatorCircle
    ' 
    '         Constructor: (+1 Overloads) Sub New
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Text
Imports SMRUCC.genomics.Visualize.Circos.TrackDatas
Imports Microsoft.VisualBasic.ComponentModel.Settings

Namespace Configurations.Nodes.Plots

    Public Class SeperatorCircle : Inherits Histogram

        Dim width As Integer

        Sub New(length As Integer, width As Integer)
            Call MyBase.New(data:=NtProps.GCSkew.CreateLineData(length, width))
            Me.width = width
        End Sub
    End Class
End Namespace
