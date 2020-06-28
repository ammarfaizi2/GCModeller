﻿#Region "Microsoft.VisualBasic::f0f15bb14bf9e4f666fb692c456364a4, R#\kegg_kit\metabolism.vb"

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

' Module metabolism
' 
'     Function: CreateCompoundOriginModel, filterInvalidCompoundIds, GetAllCompounds
' 
' /********************************************************************************/

#End Region


Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports RDotNET.Extensions.GCModeller
Imports SMRUCC.genomics.Assembly.KEGG
Imports SMRUCC.genomics.Data
Imports SMRUCC.genomics.Model.Network.KEGG.ReactionNetwork
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.genomics.Assembly.KEGG.WebServices
Imports SMRUCC.genomics.Annotation.Ptf

''' <summary>
''' The kegg metabolism model toolkit
''' </summary>
<Package("kegg.metabolism", Category:=APICategories.ResearchTools)>
Module metabolism

    Sub New()

    End Sub

    <ExportAPI("load.reaction.cacheIndex")>
    Public Function loadReactionCacheIndex(file As String) As MapCache
        Return MapCache.ParseText(file.SolveStream.LineTokens)
    End Function

    ''' <summary>
    ''' Get compounds kegg id which is related to the given KO id list
    ''' </summary>
    ''' <param name="enzymes">KO id list</param>
    ''' <param name="reactions"></param>
    ''' <returns></returns>
    <ExportAPI("related.compounds")>
    Public Function GetAllCompounds(enzymes$(), reactions As ReactionRepository) As String()
        Return reactions _
            .GetByKOMatch(KO:=enzymes) _
            .Select(Function(r) r.GetSubstrateCompounds) _
            .IteratesALL _
            .Distinct _
            .ToArray
    End Function

    <ExportAPI("compound.origins")>
    Public Function CreateCompoundOriginModel(repo As String, Optional compoundNames As Dictionary(Of String, String) = Nothing) As OrganismCompounds
        If compoundNames Is Nothing Then
            Return OrganismCompounds.LoadData(repo)
        Else
            Return OrganismCompounds.LoadData(repo, compoundNames)
        End If
    End Function

    ''' <summary>
    ''' Removes invalid kegg compound id
    ''' </summary>
    ''' <param name="identified"></param>
    ''' <returns></returns>
    <ExportAPI("filter.invalid_keggIds")>
    Public Function filterInvalidCompoundIds(identified As String()) As String()
        Return identified _
            .Where(Function(id)
                       Return id.IsPattern(KEGGCompoundIDPatterns)
                   End Function) _
            .ToArray
    End Function

    ''' <summary>
    ''' do kegg pathway reconstruction by given protein annotation data
    ''' </summary>
    ''' <param name="reference"></param>
    ''' <param name="reactions"></param>
    ''' <param name="annotations"></param>
    ''' <param name="min_cov"></param>
    ''' <param name="env"></param>
    ''' <returns></returns>
    <ExportAPI("kegg.reconstruction")>
    Public Function KEGGReconstruction(reference As Object, reactions As Object, annotations As Object,
                                       Optional min_cov As Double = 0.3,
                                       Optional env As Environment = Nothing) As pipeline

        Dim rxnList As pipeline = pipeline.TryCreatePipeline(Of ReactionTable)(reactions, env)

        If rxnList.isError Then
            Return rxnList
        End If

        Dim maps As pipeline = pipeline.TryCreatePipeline(Of Map)(reference, env)

        If maps.isError Then
            Return maps
        End If

        Dim proteins As pipeline = pipeline.TryCreatePipeline(Of ProteinAnnotation)(annotations, env)

        If proteins.isError Then
            Return proteins
        End If

        Dim rxnIndex = rxnList.populates(Of ReactionTable).CreateIndex
    End Function
End Module

