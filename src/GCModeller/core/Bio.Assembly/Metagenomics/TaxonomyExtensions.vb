﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.Ranges

Namespace Metagenomics

    Public Module TaxonomyExtensions

        Public Delegate Function TaxonomyProjector(Of T)(obj As T) As Taxonomy

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <typeparam name="TOut"></typeparam>
        ''' <param name="seq"></param>
        ''' <param name="ref">如果目标<paramref name="getTaxonomy"/>的分类结果是
        ''' 位于当前的这个参考<paramref name="ref"/>范围内的，则会被筛选出来
        ''' </param>
        ''' <param name="getTaxonomy"></param>
        ''' <param name="getValue"></param>
        ''' <returns></returns>
        ''' 
        <Extension>
        Public Iterator Function SelectByTaxonomyRange(Of T, TOut)(seq As IEnumerable(Of T),
                                                                   ref As Taxonomy,
                                                                   getTaxonomy As TaxonomyProjector(Of T),
                                                                   getValue As Projector(Of T, TOut)) As IEnumerable(Of TOut)
            Dim pop As TOut

            For Each o As T In seq
                Dim tax As Taxonomy = getTaxonomy(obj:=o)
                Dim rel As Relations = ref.CompareWith(tax)

                If rel = Relations.Equals OrElse rel = Relations.Include Then
                    pop = getValue([in]:=o)
                    Yield pop
                End If
            Next
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function SelectByTaxonomyRange(relativeAbundance As Dictionary(Of Taxonomy, Double), ref As Taxonomy) As IEnumerable(Of Double)
            Return relativeAbundance.SelectByTaxonomyRange(ref, Function(tax) tax.Key, Function(tax) tax.Value)
        End Function
    End Module
End Namespace