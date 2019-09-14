﻿#Region "Microsoft.VisualBasic::e6ac6c6ec17ce7006e2975f065c6f670, GSEA\Profiler\Metabolism.vb"

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

    ' Module CLI
    ' 
    '     Function: MetaboliteBackground
    ' 
    ' /********************************************************************************/

#End Region

Imports System.ComponentModel
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Assembly.KEGG.DBGET.bGetObject
Imports SMRUCC.genomics.Assembly.KEGG.DBGET.bGetObject.Organism
Imports Microsoft.VisualBasic.Language.UnixBash
Imports SMRUCC.genomics.Analysis.HTS.GSEA
Imports SMRUCC.genomics.Analysis.HTS.GSEA.KnowledgeBase

Partial Module CLI

    <ExportAPI("/kegg.metabolites.background")>
    <Description("Create background model for KEGG pathway enrichment based on the kegg metabolites, used for LC-MS metabolism data analysis.")>
    <Usage("/kegg.metabolites.background /in <organism.repository_directory> [/out <background_model.Xml>]")>
    <Argument("/in", False, CLITypes.File,
              Description:="A repository directory that contains the pathway map data and which is generated by ``/Download.Pathway.Maps`` tools in cli app 'KEGG_tools'.")>
    Public Function MetaboliteBackground(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim out$ = args("/out") Or $"{[in]}/metabolites.Xml"
        Dim info As OrganismInfo = $"{[in]}/kegg.json".LoadJSON(Of OrganismInfo)
        Dim maps As IEnumerable(Of Pathway) = (ls - l - r - "*.Xml" <= [in]).Select(AddressOf LoadXml(Of Pathway))
        Dim background As Background = KEGGCompounds.CreateBackground(info, maps)

        Return background _
            .GetXml _
            .SaveTo(out) _
            .CLICode
    End Function
End Module