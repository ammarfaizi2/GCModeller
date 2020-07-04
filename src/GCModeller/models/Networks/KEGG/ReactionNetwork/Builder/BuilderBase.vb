﻿Imports System.Drawing
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph.Abstract
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq

Namespace ReactionNetwork

    Public MustInherit Class BuilderBase

        ''' <summary>
        ''' 正常的通过这个模型对象的构造函数创建的代谢物节点的颜色为蓝色
        ''' </summary>
        Protected Shared ReadOnly blue As New SolidBrush(Color.CornflowerBlue)
        ''' <summary>
        ''' 通过expansion操作添加的额外的代谢物的节点的颜色为灰色
        ''' </summary>
        Protected Shared ReadOnly gray As New SolidBrush(Color.LightGray)

        Friend Shared ReadOnly commonIgnores As Index(Of String) = My.Resources _
            .CommonIgnores _
            .LineTokens _
            .Distinct _
            .ToArray

        ''' <summary>
        ''' 从输入的数据之中构建出网络的节点列表
        ''' </summary>
        Protected ReadOnly nodes As CompoundNodeTable
        ' {KEGG_compound --> reaction ID()}
        Protected ReadOnly cpdGroups As Dictionary(Of String, String())
        Protected ReadOnly networkBase As Dictionary(Of String, ReactionTable)

        Protected ReadOnly g As New NetworkGraph

        Protected edges As New Dictionary(Of String, Edge)
        Protected reactionIDlist As New List(Of String)

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="br08901">代谢反应数据</param>
        ''' <param name="compounds">KEGG化合物编号，``{kegg_id => compound name}``</param>
        Protected Sub New(br08901 As IEnumerable(Of ReactionTable), compounds As IEnumerable(Of NamedValue(Of String)), color As Brush)
            ' 构建网络的基础数据
            ' 是依据KEGG代谢反应信息来定义的
            networkBase = br08901 _
                .GroupBy(Function(r) r.entry) _
                .ToDictionary(Function(r) r.Key,
                              Function(group)
                                  Return group.First
                              End Function)

            ' {KEGG_compound --> reaction ID()}
            cpdGroups = networkBase.Values _
                .Select(Function(x)
                            Return x.substrates _
                                .JoinIterates(x.products) _
                                .Select(Function(id)
                                            Return (id, x)
                                        End Function)
                        End Function) _
                .IteratesALL _
                .GroupBy(Function(x) x.Item1) _
                .ToDictionary(Function(x) x.Key,
                              Function(reactions)
                                  Return reactions _
                                      .Select(Function(x) x.Item2.entry) _
                                      .Distinct _
                                      .ToArray
                              End Function)

            nodes = New CompoundNodeTable(compounds, cpdGroups, g, color:=color)
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="commons">a list of reaction id</param>
        ''' <param name="a"></param>
        ''' <param name="b"></param>
        Protected MustOverride Sub createEdges(commons As String(), a As Node, b As Node)

        Protected Sub addNewEdge(edge As Edge)
            Dim ledge As IInteraction = edge

            If (Not nodes.containsKey(ledge.source)) OrElse (Not nodes.containsKey(ledge.target)) Then
                Throw New InvalidExpressionException(edge.ToString)
            End If
            If ledge.source Like commonIgnores OrElse ledge.target Like commonIgnores Then
                ' 跳过水
                Return
            End If

            With edge.GetNullDirectedGuid(True)
                If Not .DoCall(AddressOf edges.ContainsKey) Then
                    Call edges.Add(.ByRef, edge)
                    Call g.AddEdge(edge)
                End If
            End With
        End Sub

        ''' <summary>
        ''' 利用代谢反应的摘要数据构建出代谢物的互作网络
        ''' </summary>
        ''' <param name="extended">是否对结果进行进一步的拓展，以获取得到一个连通性更加多的大网络？默认不进行拓展</param>
        ''' <param name="enzymeInfo">
        ''' ``{KO => protein names}``
        ''' </param>
        ''' <returns></returns>
        Public Function BuildModel(Optional extended As Boolean = False,
                                   Optional enzymeInfo As Dictionary(Of String, String()) = Nothing,
                                   Optional enzymeRelated As Boolean = True) As NetworkGraph

            Dim commons As Value(Of String()) = {}
            Dim extendes As New List(Of Node)

            edges = New Dictionary(Of String, Edge)
            reactionIDlist = New List(Of String)

            If extended Then
                Call "KEGG compound network will appends with extended compound reactions".__DEBUG_ECHO
            End If

            ' 下面的这个for循环对所构建出来的节点列表进行边链接构建
            For Each a As Node In nodes.values.Where(Function(n) Not n.label Like commonIgnores).ToArray
                Dim reactionA = cpdGroups.TryGetValue(a.label)

                If reactionA.IsNullOrEmpty Then
                    Continue For
                End If

                For Each b As Node In nodes.values _
                    .Where(Function(x)
                               Return x.ID <> a.ID AndAlso Not x.label Like commonIgnores
                           End Function) _
                    .ToArray

                    Dim rB = cpdGroups.TryGetValue(b.label)

                    If rB.IsNullOrEmpty Then
                        Continue For
                    End If

                    ' a 和 b 是直接相连的
                    If Not (commons = reactionA.Intersect(rB).ToArray).IsNullOrEmpty Then
                        Call reactionIDlist.AddRange(commons.Value)
                        Call createEdges(commons, a, b)
                    Else

                        ' 这两个节点之间可能存在一个空位，
                        ' 对所有的节点进行遍历，找出同时链接a和b的节点
                        If extended Then

                            If Not cpdGroups.ContainsKey(a.label) OrElse Not cpdGroups.ContainsKey(b.label) Then
                                Continue For
                            Else
                                extendes += cpdGroups.doNetworkExtension(a, b, gray, AddressOf addNewEdge, nodes, reactionIDlist)
                            End If

                        End If
                    End If
                Next
            Next

            Return doNetworkExpansion(extendes, enzymeInfo, enzymeRelated)
        End Function

        Private Function doNetworkExpansion(extends As List(Of Node), enzymeInfo As Dictionary(Of String, String()), enzymeRelated As Boolean) As NetworkGraph
            extends = extends _
               .GroupBy(Function(n) n.label) _
               .Select(Function(x) x.First) _
               .AsList

            For Each x In extends
                If Not nodes.containsKey(x.label) Then
                    nodes.add(x)
                End If
            Next

            If Not enzymeRelated Then
                ' 使用所有的代谢反应来构建酶催化网络
                reactionIDlist = networkBase.Keys.AsList
            End If

            Call reactionIDlist _
                .Distinct _
                .doAppendReactionEnzyme(enzymeInfo, networkBase, nodes, AddressOf addNewEdge, enzymeRelated)

            Return g
        End Function
    End Class
End Namespace