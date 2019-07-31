﻿#Region "Microsoft.VisualBasic::a45e75a0cc000e8b875b3efe5b7bc1bc, Shared\Settings.FileSystem\Regprecise\Directories.vb"

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

    '     Module Directories
    ' 
    '         Properties: Motif_PWM, RegPreciseRegulations
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Namespace GCModeller.FileSystem.RegPrecise

    Module Directories

        ''' <summary>
        ''' Directory of  /Regprecise/MEME/Motif_PWM/
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Motif_PWM As String
            Get
                Return FileSystem.GetRepositoryRoot & "/Regprecise/MEME/Motif_PWM/"
            End Get
        End Property

        ''' <summary>
        ''' <see cref="FileSystem.GetRepositoryRoot"/> &amp; "/Regprecise/RegPrecise.Xml"
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property RegPreciseRegulations As String
            Get
                Return FileSystem.GetRepositoryRoot & "/Regprecise/RegPrecise.Xml"
            End Get
        End Property

        ' Public ReadOnly Property RegPreciseDownload
    End Module
End Namespace
