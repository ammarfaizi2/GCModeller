﻿Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.csv.DocumentStream
Imports Microsoft.VisualBasic.Data.visualize.Network
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Assembly.NCBI.Taxonomy
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.BLASTOutput.BlastPlus
Imports SMRUCC.genomics.Metagenomics

Namespace Metagenome

    ''' <summary>
    ''' ###### Protocol Steps
    ''' 
    ''' 1. 先对16S/18S blastn结果注释taxonomy，得到taxid
    ''' 2. 对16S/18S进行blastn得到成员之间的相似性矩阵
    ''' 3. 输出网络模型: ``query -> fromNode, subject -> toNode, taxid -> type(color)``
    ''' </summary>
    Public Module Protocol

        ''' <summary>
        ''' 重新直接生成
        ''' </summary>
        ''' <param name="taxData"></param>
        ''' <param name="gi2taxid"></param>
        ''' <returns></returns>
        <Extension>
        Public Function Dump_x2taxid(taxData As IEnumerable(Of BlastnMapping), gi2taxid As Boolean) As String()
            Dim list As New List(Of String)
            Dim parser = TaxidMaps.GetParser(gi2taxid)

            If gi2taxid Then

                For Each x In taxData
                    list += parser(x.Reference) & vbTab & x("taxid")
                Next

            Else

                list += Accession2Taxid.Acc2Taxid_Header

                For Each x In taxData
                    Dim acc$ = parser(x.Reference)
                    list += acc & vbTab & (acc & ".1") & vbTab & x("taxid") & vbTab & 0
                Next

            End If

            Return list.Distinct.ToArray
        End Function

        ''' <summary>
        ''' ###### step 1
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="x2taxid$">已经被subset的数据库</param>
        ''' <param name="taxonomy"></param>
        ''' <param name="is_gi2taxid">
        ''' ``Reference``是否使用的是旧的gi系统？这个参数决定了<paramref name="x2taxid"/>的工作模式
        ''' </param>
        ''' <param name="notFound">iterator函数不能够使用ByRef，所以假若需要得到notfound列表，就将这个参数实例化再传递进来</param>
        ''' <returns></returns>
        <Extension>
        Public Iterator Function TaxonomyMaps(source As IEnumerable(Of BlastnMapping),
                                              x2taxid$,
                                              taxonomy As NcbiTaxonomyTree,
                                              Optional is_gi2taxid? As Boolean = False,
                                              Optional notFound As List(Of String) = Nothing) As IEnumerable(Of BlastnMapping)

            Dim taxid As New Value(Of Integer)
            Dim mapping As TaxidMaps.Mapping = If(
                is_gi2taxid,
                TaxidMaps.MapByGI(x2taxid),
                TaxidMaps.MapByAcc(x2taxid))

            Dim taxidFromRef As Mapping = Reference2Taxid(mapping, is_gi2taxid)

            If notFound Is Nothing Then  ' iterator函数不能够使用ByRef，所以假若需要得到notfound列表，就将这个参数实例化再传递进来
                notFound = New List(Of String)
            End If

            For Each x As BlastnMapping In source

                With x
                    If (taxid = taxidFromRef(x.Reference)) > -1 Then

                        .Extensions(Protocol.taxid) = +taxid

                        Dim nodes = taxonomy.GetAscendantsWithRanksAndNames(+taxid, True)
                        Dim tree$ = TaxonomyNode.BuildBIOM(nodes)
                        Dim name$ = taxonomy(taxid)?.name

                        .Extensions(Protocol.taxonomyName) = name
                        .Extensions(Protocol.Taxonomy) = tree
                    Else
                        Call .Reference.Warning
                        Call notFound.Add(.Reference)

                        .Extensions(Protocol.taxid) = Integer.MaxValue  ' 找不到具体的物种分类数据的
                        .Extensions(Protocol.taxonomyName) = "unknown"
                        .Extensions(Protocol.Taxonomy) = "unknown"
                    End If
                End With

                Yield x
            Next
        End Function

        Const taxid$ = NameOf(taxid)
        Const taxonomyName$ = "Taxonomy.Name"
        Const Taxonomy$ = NameOf(Taxonomy)

        ''' <summary>
        ''' ###### step 2
        ''' 
        ''' 低于给定的阈值的hit都会被丢弃
        ''' </summary>
        ''' <param name="blastn">SSU的fasta文件自己对自己的比对结果</param>
        ''' <param name="identities#"></param>
        ''' <param name="coverage#"></param>
        ''' <returns></returns>
        <Extension>
        Public Iterator Function BuildMatrix(blastn As v228, Optional identities# = 0.3, Optional coverage# = 0.3) As IEnumerable(Of DataSet)
            For Each query As Query In blastn.Queries  ' 因为是blastn所以可能会存在一部分比对上的结果，所以会出现重复的片段，在这里取出identities最高的
                Dim besthits As SubjectHit() = query.GetBesthits(coverage:=coverage, identities:=identities)
                Dim distinct = From x As SubjectHit
                               In besthits
                               Select x
                               Group x By x.Name Into Group
                Dim similarity As Dictionary(Of String, Double) =
                    distinct.ToDictionary(Function(h) h.Name,
                                          Function(h) h.Group.OrderBy(
                                          Function(x) x.Score.Identities.Value) _
                                                  .Last.Score.Identities.Value)
                Yield New DataSet With {
                    .Identifier = query.QueryName,
                    .Properties = similarity
                }
            Next
        End Function

        ''' <summary>
        ''' ###### step 2
        ''' </summary>
        ''' <param name="blastn"></param>
        ''' <param name="identities#"></param>
        ''' <param name="coverage#"></param>
        ''' <returns></returns>
        <Extension>
        Public Iterator Function BuildMatrix(blastn As IEnumerable(Of BlastnMapping), Optional identities# = 0.3, Optional coverage# = 0.3) As IEnumerable(Of DataSet)
            Dim g = From x As BlastnMapping
                    In blastn
                    Where x.Identities >= identities AndAlso
                        x.GetCoverage >= coverage
                    Select x
                    Group x By x.ReadQuery Into Group

            For Each query In g
                Dim distinct = From x As BlastnMapping
                               In query.Group
                               Select x
                               Group x By x.Reference Into Group
                Dim similarity As Dictionary(Of String, Double) =
                    distinct.ToDictionary(Function(h) h.Reference,
                                          Function(h) h.Group.OrderBy(
                                          Function(x) x.Identities).Last.Identities)
                Yield New DataSet With {
                    .Identifier = query.ReadQuery,
                    .Properties = similarity
                }
            Next
        End Function

        ''' <summary>
        ''' ###### step 3
        ''' 
        ''' 节点的颜色分类以及边的颜色分类是通过taxid分组来进行的
        ''' </summary>
        ''' <param name="matrix"><see cref="BuildMatrix"/></param>
        ''' <param name="taxid"><see cref="TaxonomyMaps"/></param>
        ''' <param name="theme">The network color theme, default using colorbrewer theme style: **Paired:c12**</param>
        ''' <returns>使用于``Cytoscape``进行绘图可视化的网络数据模型</returns>
        <Extension>
        Public Function BuildNetwork(matrix As IEnumerable(Of DataSet), taxid As IEnumerable(Of BlastnMapping), Optional theme$ = "Paired:c12", Optional parallel As Boolean = False) As FileStream.Network
            Dim nodes As New List(Of Node)
            Dim edges As New List(Of NetworkEdge)
            Dim taxonomyTypes As New Dictionary(Of String, (taxid%, taxonomyName$, Taxonomy As String))

            For Each SSU As BlastnMapping In taxid
                Dim tax = (CInt(SSU(Protocol.taxid)), SSU(Protocol.taxonomyName), SSU(Protocol.Taxonomy))
                taxonomyTypes.Add(SSU.ReadQuery, tax)
            Next

            Return matrix.__buildNetwork(taxonomyTypes, theme, parallel)
        End Function

        <Extension>
        Private Function __buildNetwork(matrix As IEnumerable(Of DataSet),
                                        taxonomyTypes As Dictionary(Of String, (taxid%, taxonomyName$, Taxonomy As String)),
                                        theme$,
                                        parallel As Boolean) As FileStream.Network

            Dim nodes As New List(Of Node)
            Dim edges As New List(Of NetworkEdge)

            ' 2016-11-29
            ' 使用负数来表示unknown的taxid会在后面分配颜色，按照-重新分割的时候出现key not found的问题，所以这里用integer的最大值来避免出现这个问题
            Dim unknown As (taxid%, taxonomyName$, Taxonomy As String) = (Integer.MaxValue, "unknown", "unknown")

            If parallel Then
                Dim LQuery = From ssu As DataSet
                             In matrix.AsParallel
                             Select ssu.__subNetwork(unknown, taxonomyTypes)

                For Each x In LQuery
                    nodes += x.node
                    edges += x.edges
                Next
            Else
                For Each SSU As DataSet In matrix ' 从矩阵之中构建出网络的数据模型
                    Dim pops = SSU.__subNetwork(unknown, taxonomyTypes)
                    nodes += pops.node
                    edges += pops.edges
                Next
            End If

            Call theme$.__styleNetwork(nodes, edges)

            Return New FileStream.Network With {
                .Nodes = nodes,
                .Edges = edges
            }
        End Function

        ''' <summary>
        ''' ###### step 3
        ''' 
        ''' 节点的颜色分类以及边的颜色分类是通过taxid分组来进行的
        ''' </summary>
        ''' <param name="matrix"><see cref="BuildMatrix"/></param>
        ''' <param name="taxid">Using the exists OTU taxonomy annotation data.</param>
        ''' <param name="theme">The network color theme, default using colorbrewer theme style: **Paired:c12**</param>
        ''' <returns>使用于``Cytoscape``进行绘图可视化的网络数据模型</returns>
        <Extension>
        Public Function BuildNetwork(matrix As IEnumerable(Of DataSet), taxid As IEnumerable(Of OTUData), Optional theme$ = "Paired:c12", Optional parallel As Boolean = False) As FileStream.Network
            Dim taxonomyTypes As New Dictionary(Of String, (taxid%, taxonomyName$, Taxonomy As String))

            For Each SSU As OTUData In taxid
                Dim tax = (CInt(SSU.Data(Protocol.taxid)), SSU.Data(Protocol.taxonomyName), SSU.Taxonomy)
                taxonomyTypes.Add(SSU.OTU, tax)
            Next

            Return matrix.__buildNetwork(taxonomyTypes, theme, parallel)
        End Function

        <Extension>
        Private Function __subNetwork(ssu As DataSet,
                                  unknown As (taxid%, taxonomyName$, Taxonomy As String),
                            taxonomyTypes As Dictionary(Of String, (taxid%, taxonomyName$, Taxonomy As String))) _
                                          As (node As Node, edges As IEnumerable(Of NetworkEdge))

            Dim taxonomy As (taxid%, taxonomyName$, taxonomy As String)
            Dim edges As New List(Of NetworkEdge)

            If taxonomyTypes.ContainsKey(ssu.Identifier) Then
                taxonomy = taxonomyTypes(ssu.Identifier)
            Else
                taxonomy = unknown
            End If

            Dim node As New Node With {
                .Identifier = ssu.Identifier,
                .NodeType = taxonomy.taxid,
                .Properties = New Dictionary(Of String, String)
            }

            With node
                Call .Properties.Add(
                    NameOf(taxonomy.taxonomyName), taxonomy.taxonomyName)
                Call .Properties.Add(
                    NameOf(taxonomy.taxonomy), taxonomy.taxonomy)
            End With

            For Each hit In ssu.Properties
                Dim hitType% = If(taxonomyTypes.ContainsKey(hit.Key),
                    taxonomyTypes(hit.Key).taxid,
                    unknown.taxid)  ' 有些是没有能够注释出任何物种信息的
                Dim type%() = {
                    taxonomy.taxid,
                    hitType
                }
                Dim interacts = type _
                    .OrderBy(Function(t) t) _
                    .Distinct _
                    .JoinBy("-")

                edges += New NetworkEdge With {
                    .FromNode = ssu.Identifier,
                    .ToNode = hit.Key,
                    .Confidence = hit.Value,
                    .Properties = New Dictionary(Of String, String),
                    .InteractionType = interacts
                }
            Next

            Return (node, edges)
        End Function

        ''' <summary>
        ''' Apply color style for taxonomy group
        ''' </summary>
        ''' <param name="theme$">Color theme name</param>
        ''' <param name="nodes"></param>
        ''' <param name="edges"></param>
        ''' 
        <Extension>
        Private Sub __styleNetwork(theme$, ByRef nodes As List(Of Node), ByRef edges As List(Of NetworkEdge))
            Dim taxids As String() = nodes _
                .Select(Function(x) x.NodeType) _
                .Distinct _
                .ToArray
            Dim colors As Dictionary(Of String, String) =
                Designer _
                .GetColors(theme, taxids.Length) _
                .Select(AddressOf ColorTranslator.ToHtml) _
                .SeqIterator _
                .ToDictionary(Function(c) taxids(c.i),
                              Function(c) c.obj)  ' 手工设置颜色会非常麻烦，当物种的数量非常多的时候，则在这里可以进行手工生成
            Dim colorPaired As Color()
            Dim color As (r#, g#, b#)

            For Each edge As NetworkEdge In edges
                taxids = edge.InteractionType.Split("-"c)
                colorPaired = taxids _
                    .ToArray(Function(t) colors(t)) _
                    .Select(AddressOf ColorTranslator.FromHtml) _
                    .ToArray
                color = (
                    colorPaired.Average(Function(c) c.R),
                    colorPaired.Average(Function(c) c.G),
                    colorPaired.Average(Function(c) c.B))
                edge.Properties("color") = ColorTranslator.ToHtml(
                    Drawing.Color.FromArgb(
                        CInt(color.r),
                        CInt(color.g),
                        CInt(color.b)))
            Next

            For Each node As Node In nodes
                node.Properties("display") = $"({node.Identifier}) {node.Properties("taxonomyName")}"
                node.Properties("color") = colors(node.NodeType)
            Next
        End Sub
    End Module
End Namespace