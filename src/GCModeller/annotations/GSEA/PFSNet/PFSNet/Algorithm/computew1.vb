﻿Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math
Imports Microsoft.VisualBasic.Math.Correlations
Imports Microsoft.VisualBasic.Math.LinearAlgebra
Imports Microsoft.VisualBasic.Math.Statistics.Linq
Imports SMRUCC.genomics.Analysis.PFSNet.DataStructure
Imports SMRUCC.genomics.Analysis.PFSNet.R

<HideModuleName> Module computew1Function

    ''' <summary>
    ''' ```R
    ''' ranks&lt;-apply(expr,2,function(x){
    '''	   rank(x)/length(x)
    ''' })
    ''' ```
    ''' 
    ''' apply函数之中的MARGIN参数的含义：
    ''' MARGIN	
    ''' a vector giving the subscripts which the function will be applied over. E.g., for a matrix 1 indicates rows, 2 indicates columns, c(1, 2) indicates rows and columns. 
    ''' Where X has named dimnames, it can be a character vector selecting dimension names.
    ''' 即上述的R函数是对矩阵之中的每一列进行计算
    ''' </summary>
    ''' <param name="expr"></param>
    ''' <param name="theta1"></param>
    ''' <param name="theta2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function computew1(expr As DataFrameRow(), theta1 As Double, theta2 As Double) As DataFrameRow()
        Dim ranks As Vector() = expr _
            .Select(Function(r) r.experiments.AsVector) _
            .Apply(math:=Function(x)
                             Dim data As Double() = x.ToArray
                             Dim rankVec As Vector = data.Ranking(Strategies.DenseRanking).AsVector
                             Return rankVec / data.Length
                         End Function,
                   axis:=ApplyOnAxis.Column,
                   aggregate:=Function(x) x.Select(Function(v) v.AsVector)) _
            .ToArray
        Dim result = ranks _
            .Apply(math:=Function(x)
                             Dim q2 = Quantile.Threshold(x, theta2)
                             Dim q1 = Quantile.Threshold(x, theta1)
                             Dim m = x.Median
                             Dim mx = x.Max
                             Dim delta_q12 As Double = q1 - q2

                             Return x.Select(Function(y) getFuzzyWeight(y, q1, q2, delta_q12))
                         End Function,
                   axis:=ApplyOnAxis.Column,
                   aggregate:=Function(x)
                                  Return x.Select(Function(v) v.AsVector)
                              End Function) _
            .ToArray

        Return expr _
            .Select(Function(r, i)
                        Return New DataFrameRow With {
                            .geneID = r.geneID,
                            .experiments = result(i)
                        }
                    End Function) _
            .ToArray
    End Function

    ''' <summary>
    ''' 计算模糊权重
    ''' </summary>
    ''' <param name="y"></param>
    ''' <param name="q1"></param>
    ''' <param name="q2"></param>
    ''' <param name="delta_q12"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getFuzzyWeight(y As Double, q1 As Double, q2 As Double, delta_q12 As Double) As Double
        If y.IsNaNImaginary Then
            Return Double.NaN
        ElseIf y >= q1 Then
            Return 1
        ElseIf y >= q2 Then
            Return (y - q2) / delta_q12
        Else
            Return 0
        End If
    End Function
End Module