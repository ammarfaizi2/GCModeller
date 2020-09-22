﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.DataMining.FuzzyCMeans
Imports Microsoft.VisualBasic.DataMining.KMeans
Imports Microsoft.VisualBasic.Language
Imports randf = Microsoft.VisualBasic.Math.RandomExtensions

''' <summary>
''' ### the cmeans algorithm module
''' 
''' **Fuzzy clustering** (also referred to as **soft clustering**) is a form of clustering in which 
''' each data point can belong to more than one cluster.
'''
''' Clustering Or cluster analysis involves assigning data points to clusters (also called buckets, 
''' bins, Or classes), Or homogeneous classes, such that items in the same class Or cluster are as 
''' similar as possible, while items belonging to different classes are as dissimilar as possible. 
''' Clusters are identified via similarity measures. These similarity measures include distance, 
''' connectivity, And intensity. Different similarity measures may be chosen based on the data Or 
''' the application.
''' 
''' > https://en.wikipedia.org/wiki/Fuzzy_clustering
''' </summary>
''' <remarks>
''' Clustering problems have applications in **biology**, medicine, psychology, economics, and many other disciplines.
'''
''' ##### Bioinformatics
''' 
''' In the field of bioinformatics, clustering Is used for a number of applications. One use Is as 
''' a pattern recognition technique to analyze gene expression data from microarrays Or other 
''' technology. In this case, genes with similar expression patterns are grouped into the same cluster, 
''' And different clusters display distinct, well-separated patterns of expression. Use of clustering 
''' can provide insight into gene function And regulation. Because fuzzy clustering allows genes 
''' to belong to more than one cluster, it allows for the identification of genes that are conditionally 
''' co-regulated Or co-expressed. For example, one gene may be acted on by more than one Transcription 
''' factor, And one gene may encode a protein that has more than one function. Thus, fuzzy clustering 
''' Is more appropriate than hard clustering.
''' </remarks>
Public Module CMeans

    ''' <summary>
    ''' **Fuzzy clustering** (also referred to as **soft clustering**) is a form of clustering in which 
    ''' each data point can belong to more than one cluster.
    ''' </summary>
    Public Function CMeans(classCount As Integer, entities As IEnumerable(Of ClusterEntity)) As Classify()
        Return CMeans(classCount, 2, 0.001, entities.ToArray)
    End Function

    ''' <summary>
    ''' **Fuzzy clustering** (also referred to as **soft clustering**) is a form of clustering in which 
    ''' each data point can belong to more than one cluster.
    ''' </summary>
    Public Function CMeans(classCount As Integer, m As Double, entities As IEnumerable(Of ClusterEntity)) As Classify()
        Return CMeans(classCount, m, 0.001, entities.ToArray)
    End Function

    Private Iterator Function GetRandomMatrix(classCount As Integer, nsamples As Integer) As IEnumerable(Of Double())
        For Each x As Double In Enumerable.Range(0, nsamples)
            Dim c = New Double(classCount - 1) {}

            For i = 0 To c.Length - 1
                c(i) = randf.randf(0, 1 - c.Sum())

                If i = c.Length - 1 Then
                    c(i) = 1 - c.Sum()
                End If
            Next

            Yield c
        Next
    End Function

    ''' <summary>
    ''' **Fuzzy clustering** (also referred to as **soft clustering**) is a form of clustering in which 
    ''' each data point can belong to more than one cluster.
    ''' </summary>
    Public Function CMeans(classCount As Integer, m As Double, threshold As Double, entities As ClusterEntity(), Optional parallel As Boolean = True, Optional maxLoop As Integer = 10000) As Classify()
        Dim u As Double()() = GetRandomMatrix(classCount, nsamples:=entities.Length).ToArray()
        Dim _j As Double = -1
        Dim centers As Double()()
        Dim width As Integer = entities(0).Length
        Dim j_new As Double
        Dim membership_diff As Double
        Dim [loop] As i32 = Scan0

        While True
            centers = GetCenters(classCount, m, u, entities, width).ToArray
            j_new = J(m, u, centers, entities)
            membership_diff = Math.Abs(j_new - _j)

            If _j <> -1 AndAlso membership_diff < threshold Then
                Exit While
            Else
                Call $"loop_{[loop]} membership_diff: |{j_new} - {_j}| = {membership_diff}".__DEBUG_ECHO
            End If

            _j = j_new

            If parallel Then
                Call u.updateMembershipParallel(entities, centers, classCount, m)
            Else
                Call u.updateMembership(entities, centers, classCount, m)
            End If

            If ++[loop] > maxLoop Then
                Exit While
            End If
        End While

        Return entities.PopulateClusters(classCount, u)
    End Function

    <Extension>
    Private Sub updateMembershipParallel(ByRef u As Double()(), entities As ClusterEntity(), centers As Double()(), classCount As Integer, m As Double)
        u = Enumerable.Range(0, u.Length) _
            .Select(Function(i) (i, Val:=entities(i))) _
            .AsParallel _
            .Select(Function(obj)
                        Dim result As Double() = centers.scanRow(
                            entity:=obj.val,
                            classCount:=classCount,
                            m:=m
                        )
                        Dim pack = (obj.i, result)

                        Return pack
                    End Function) _
            .OrderBy(Function(pack) pack.i) _
            .Select(Function(a) a.result) _
            .ToArray
    End Sub

    <Extension>
    Private Function scanRow(centers As Double()(), entity As ClusterEntity, classCount As Integer, m As Double) As Double()
        Dim ui As Double() = New Double(classCount - 1) {}

        For j As Integer = 0 To classCount - 1
            Dim jIndex As Integer = j
            Dim sumAll As Double = Aggregate x As Integer
                                   In Enumerable.Range(0, classCount)
                                   Let a As Double = Math.Sqrt(Dist(entity, centers(jIndex))) / Math.Sqrt(Dist(entity, centers(x)))
                                   Let val As Double = a ^ (2 / (m - 1))
                                   Into Sum(val)
            ui(j) = 1 / sumAll

            If Double.IsNaN(ui(j)) Then
                ui(j) = 1
            End If
        Next

        Return ui
    End Function

    <Extension>
    Private Sub updateMembership(u As Double()(), entities As ClusterEntity(), centers As Double()(), classCount As Integer, m As Double)
        For i As Integer = 0 To u.Length - 1
            Dim index As Integer = i

            For j As Integer = 0 To u(i).Length - 1
                Dim jIndex As Integer = j
                Dim sumAll As Double = Aggregate x As Integer
                                       In Enumerable.Range(0, classCount)
                                       Let a As Double = Math.Sqrt(Dist(entities(index), centers(jIndex))) / Math.Sqrt(Dist(entities(index), centers(x)))
                                       Let val As Double = a ^ (2 / (m - 1))
                                       Into Sum(val)
                u(i)(j) = 1 / sumAll

                If Double.IsNaN(u(i)(j)) Then
                    u(i)(j) = 1
                End If
            Next
        Next
    End Sub

    <Extension>
    Private Function PopulateClusters(values As ClusterEntity(), classCount As Integer, u As Double()()) As Classify()
        Dim result As Classify() = Enumerable.Range(0, classCount) _
          .[Select](Function(x, i)
                        Return New Classify() With {
                            .Id = i + 1
                        }
                    End Function) _
          .ToArray
        Dim index As Integer
        Dim maxMembership As Double
        Dim clusterMembership As Double()
        Dim resultEntity As FuzzyCMeansEntity

        For i As Integer = 0 To values.Length - 1
            clusterMembership = u(i)
            maxMembership = clusterMembership.Max()
            index = Array.IndexOf(u(i), maxMembership)
            resultEntity = New FuzzyCMeansEntity With {
                .cluster = index,
                .entityVector = values(i).entityVector,
                .uid = values(i).uid,
                .memberships = result _
                    .ToDictionary(Function(a) a.Id - 1,
                                  Function(a)
                                      Return clusterMembership(a.Id - 1)
                                  End Function)
            }
            result(index).members.Add(resultEntity)
        Next

        Return result
    End Function

    Public Iterator Function GetCenters(classCount As Integer, m As Double, u As Double()(), entities As ClusterEntity(), width As Integer) As IEnumerable(Of Double())
        For Each i As Integer In Enumerable.Range(0, classCount)
            Yield Enumerable.Range(0, width) _
                              .[Select](Function(x)
                                            Dim sumAll = Aggregate j As Integer In Enumerable.Range(0, entities.Count)
                                                   Let val As Double = Math.Pow(u(j)(i), m) * entities(j)(x)
                                                   Into Sum(val)
                                            Dim b = Aggregate j As Integer In Enumerable.Range(0, entities.Count)
                                                        Let val As Double = Math.Pow(u(j)(i), m)
                                                           Into Sum(val)

                                            Return sumAll / b
                                        End Function) _
                              .ToArray()
        Next
    End Function

    Public Function J(m As Double, u As Double()(), centers As Double()(), entities As ClusterEntity()) As Double
        Return centers.Select(Function(x, i)
                                  Return entities.Select(Function(y, j1)
                                                             Return (u(j1)(i) ^ m) * Dist(y, x)
                                                         End Function).Sum()
                              End Function).Sum()
    End Function

    ''' <summary>
    ''' 在这里面只会计算结果值，并不会修改数据
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="center"></param>
    ''' <returns></returns>
    Private Function Dist(obj As ClusterEntity, center As Double()) As Double
        Return obj.entityVector.Select(Function(x, i) (x - center(i)) ^ 2).Sum()
    End Function
End Module
