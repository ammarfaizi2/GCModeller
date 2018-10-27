﻿#Region "Microsoft.VisualBasic::78acc9fbdafc907d13c18cb7ef2ec06f, Compiler\Extensions.vb"

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

    ' Module Extensions
    ' 
    '     Function: ToMarkup, ToTabular
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports SMRUCC.genomics.GCModeller.Assembly.GCMarkupLanguage.v2
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Model
Imports Excel = Microsoft.VisualBasic.MIME.Office.Excel.File
Imports XmlReaction = SMRUCC.genomics.GCModeller.Assembly.GCMarkupLanguage.v2.Reaction

Public Module Extensions

    <Extension> Public Function ToMarkup(model As CellularModule, KEGG As RepositoryArguments) As VirtualCell
        Return New VirtualCell With {
            .Taxonomy = model.Taxonomy,
            .MetabolismStructure = New MetabolismStructure With {
                .Reactions = model _
                    .Phenotype _
                    .fluxes _
                    .Select(Function(r)
                                Return New XmlReaction With {
                                    .ID = r.ID,
                                    .name = r.name,
                                    .Equation = r.GetEquationString
                                }
                            End Function) _
                    .ToArray,
                .Pathways = KEGG.GetPathways _
                    .PathwayMaps _
                    .Select(Function(map)
                                Return New Pathway With {
                                    .ID = map.KOpathway,
                                    .name = map.name,
                                    .Enzymes =
                                }
                            End Function) _
                    .ToArray
            }
        }
    End Function



    <Extension> Public Function ToTabular(model As CellularModule) As Excel

    End Function
End Module

