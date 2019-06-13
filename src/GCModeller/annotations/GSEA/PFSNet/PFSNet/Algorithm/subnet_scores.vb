﻿Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math
Imports SMRUCC.genomics.Analysis.PFSNet.DataStructure
Imports SMRUCC.genomics.Analysis.PFSNet.R

<HideModuleName> Module subnet_scores

    ''' <summary>
    ''' ```R
    ''' pscore&lt;-sapply(ccs,function(x){
    '''	    vertices&lt;-get.vertex.attribute(x,name="name")
    '''     ws&lt;-w1matrix1[vertices,,drop=FALSE]
    '''     ws[is.na(ws)]&lt;-0
    '''     v&lt;-c()
    '''
    '''     for(i in 1:ncol(ws)){
    '''         v&lt;-c(v,sum(
    '''             (V(x)$weight*ws[,i])
    '''         ))
    '''	    }
    '''	    
    '''     v
    '''     # apply(ss,2,function(y){
    '''     #    sum(apply(ss[y,,drop=FALSE],1,sum)/ncol(expr1o))
    '''	    # })
    '''	})
    '''	```
    ''' </summary>
    ''' <param name="ccs"></param>
    ''' <param name="w1matrix1"></param>
    ''' <returns></returns>
    Public Function sapply_pscore(ccs As PFSNetGraph(), w1matrix1 As DataFrameRow()) As Double()()
        Return (From x In ccs Select pscoring(x, w1matrix1)).ToArray
    End Function

    Private Function pscoring(x As PFSNetGraph, w1matrix1 As DataFrameRow()) As Double()
        Dim vertices = (From ccs_node In x.nodes Select ccs_node.name).ToArray  'vertices<-get.vertex.attribute(x,name="name")
        Dim ws = w1matrix1.Select(vertices) 'ws<-w1matrix1[vertices,,drop=FALSE]
        Dim v = New List(Of Double) '	v<-c()
        Dim ncol = ws(Scan0).samples

        For j As Integer = 0 To ncol - 1
            Dim p = j
            Dim sum = (From d In ws Select x.Node(d.geneID).weight * d.experiments(p)).Sum

            Call v.Add(sum)
        Next
        'v()
        '#apply(ss,2,function(y){
        '#		sum(apply(ss[y,,drop=FALSE],1,sum)/ncol(expr1o))
        '#	})
        Return v.ToArray
    End Function

    Public Function sapply_nscore(ccs As PFSNetGraph(), w1matrix1 As DataFrameRow()) As Double()()
        Return (From node As PFSNetGraph In ccs Select nscoring(node, w1matrix1)).ToArray
    End Function

    Private Function nscoring(x As PFSNetGraph, w1matrix1 As DataFrameRow()) As Double()
        Dim vertices = (From ccs_node In x.nodes Select ccs_node.name).ToArray  'vertices<-get.vertex.attribute(x,name="name")
        Dim ws = w1matrix1.Select(vertices) 'ws<-w1matrix1[vertices,,drop=FALSE]
        Dim v = New List(Of Double) '	v<-c()
        Dim ncol = ws(Scan0).samples

        For j As Integer = 0 To ncol - 1
            Dim p = j
            Dim sum = (From d In ws Select x.Node(d.geneID).weight2 * d.experiments(p)).Sum

            Call v.Add(sum)
        Next
        'v()
        '#apply(ss,2,function(y){
        '#		sum(apply(ss[y,,drop=FALSE],1,sum)/ncol(expr1o))
        '#	})
        Return v.ToArray
    End Function
End Module