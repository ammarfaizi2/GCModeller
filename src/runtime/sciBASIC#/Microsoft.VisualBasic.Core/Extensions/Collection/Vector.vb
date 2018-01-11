﻿#Region "Microsoft.VisualBasic::c3c22065b05432da5a92611c11a91477, ..\sciBASIC#\Microsoft.VisualBasic.Core\Extensions\Collection\Vector.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Imports System.Runtime.CompilerServices
Imports System.Threading
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.Default
Imports Microsoft.VisualBasic.Language.Vectorization
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Linq.IteratorExtensions

''' <summary>
''' Extension methods for the .NET object sequence
''' </summary>
Public Module VectorExtensions

    <Extension>
    Public Iterator Function Replicate(Of T)(template As T, n%) As IEnumerable(Of T)
        For i As Integer = 0 To n - 1
            Yield template
        Next
    End Function

    <Extension>
    Public Function RepeatCalls(Of T)(factory As Func(Of T), n%, Optional sleep% = 0) As T()
        Return n _
            .SeqIterator _
            .Select(Function(i)
                        If sleep > 0 Then
                            Call Thread.Sleep(sleep)
                        End If

                        Return factory()
                    End Function) _
            .ToArray
    End Function

    ''' <summary>
    ''' Create a vector shadow of your data collection.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <returns>返回<see cref="Object"/>类型是为了简化语法</returns>
    <Extension>
    Public Function VectorShadows(Of T)(source As IEnumerable(Of T)) As Object
        Return New VectorShadows(Of T)(source)
    End Function

    ''' <summary>
    ''' 聚合，将nullable类型结构体转换为原来的值类型
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <returns></returns>
    <Extension>
    Public Function Coalesce(Of T As Structure)(source As IEnumerable(Of T?)) As IEnumerable(Of T)
        Debug.Assert(source IsNot Nothing)
        Return source.Where(Function(x) x.HasValue).[Select](Function(x) CType(x, T))
    End Function

    <Extension>
    Public Function Sort(Of T)(source As IEnumerable(Of NamedValue(Of T)), by As Index(Of String), Optional throwNoOrder As Boolean = False) As NamedValue(Of T)()
        Dim out As NamedValue(Of T)() = New NamedValue(Of T)(by.Count - 1) {}

        For Each x In source
            Dim i% = by(x.Name)

            If i = -1 Then
                If throwNoOrder Then
                    Throw New InvalidExpressionException(x.Name & " was not found in the index value.")
                Else
                    Continue For
                End If
            Else
                out(i) = x
            End If
        Next

        Return out
    End Function

    <Extension> Public Function GetRange(Of T)(vector As T(), index%, count%) As T()
        Dim fill As T() = New T(count - 1) {}
        Dim ends% = index + count - 1

        For i As Integer = index To ends
            fill(i - index) = vector(i)
        Next

        Return fill
    End Function

    ''' <summary>
    ''' 对目标序列进行排序生成新的序列，这个拓展函数尝试将升序排序和降序排序这两种操作的接口统一起来
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="desc"></param>
    ''' <returns></returns>
    <Extension>
    Public Function Sort(Of T)(source As IEnumerable(Of T), Optional by As Func(Of T, IComparable) = Nothing, Optional desc As Boolean = False) As IEnumerable(Of T)
        If by Is Nothing Then
            If Not desc Then
                Return From x In source Select x Order By x Ascending
            Else
                Return From x In source Select x Order By x Descending
            End If
        Else
            If Not desc Then
                Return source.OrderBy(by)
            Else
                Return source.OrderByDescending(by)
            End If
        End If
    End Function

    Const DimNotAgree$ = "Both a and b their length should be equals or one of them should be length=1!"

    ''' <summary>
    ''' 用来生成map数据的，
    ''' + 当两个向量长度相同，会不进行任何处理，即两个向量之间，元素都可以一一对应，
    ''' + 但是当某一个向量的长度为1的时候，就会将该向量补齐，因为此时会是一对多的关系
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="a"></param>
    ''' <param name="b"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function MappingData(Of T)(a As T(), b As T()) As IEnumerable(Of Map(Of T, T))
        If a.Length = 1 AndAlso b.Length > 1 Then
            ' 补齐a
            a = a(0).Repeats(b.Length)
        ElseIf a.Length > 1 AndAlso b.Length = 1 Then
            ' 补齐b
            b = b(0).Repeats(a.Length)
        ElseIf a.Length <> b.Length Then
            ' 无法计算
            Throw New ArgumentException(DimNotAgree)
        End If

        For i As Integer = 0 To a.Length - 1
            Yield New Map(Of T, T) With {
                .Key = a(i),
                .Maps = b(i)
            }
        Next
    End Function

    ''' <summary>
    ''' 在一个一维数组中搜索指定对象，并返回其首个匹配项的索引。
    ''' </summary>
    ''' <typeparam name="T">数组元素的类型。</typeparam>
    ''' <param name="array">要搜索的从零开始的一维数组。</param>
    ''' <param name="o">要在 array 中查找的对象。</param>
    ''' <returns>如果在整个 array 中找到 value 的第一个匹配项，则为该项的从零开始的索引；否则为 -1。</returns>
    <Extension>
    Public Function IndexOf(Of T)(array As T(), o As T) As Integer
        Return System.Array.IndexOf(array, value:=o)
    End Function

    ''' <summary>
    ''' 从后往前访问集合之中的元素，请注意请不要使用Linq查询表达式，尽量使用``list``或者``array``
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source">请不要使用Linq查询表达式，尽量使用``list``或者``array``</param>
    ''' <param name="index"></param>
    ''' <returns></returns>
    <Extension>
    Public Function Last(Of T)(source As IEnumerable(Of T), index As Integer) As T
        Return source(source.Count - index)
    End Function

    ''' <summary>
    ''' 取出在x元素之后的所有元素
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="x"></param>
    ''' <returns></returns>
    <Extension>
    Public Function After(Of T)(source As IEnumerable(Of T), x As T) As IEnumerable(Of T)
        Return source.After(Function(o) x.Equals(o))
    End Function

    ''' <summary>
    ''' Returns all of the elements which is after the element that detected by a specific 
    ''' evaluation function <paramref name="predicate"/>.
    ''' (取出在判定条件成立的元素之后的所有元素)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="predicate"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function After(Of T)(source As IEnumerable(Of T), predicate As Predicate(Of T)) As IEnumerable(Of T)
        Dim isAfter As Boolean = False

        For Each x As T In source
            If isAfter Then
                Yield x
            Else
                If predicate(x) Then
                    isAfter = True
                End If
            End If
        Next
    End Function

    ''' <summary>
    ''' Replace target array data by using specific object value.(替换目标向量为指定的对象的填充数据)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="array"></param>
    ''' <param name="o"></param>
    ''' <param name="len"></param>
    <Extension>
    Public Sub Memset(Of T)(ByRef array As T(), o As T, len As Integer)
        If array Is Nothing OrElse array.Length < len Then
            array = New T(len - 1) {}
        End If

        For i As Integer = 0 To len - 1
            array(i) = o
        Next
    End Sub

    ''' <summary>
    ''' 替换<paramref name="s"/>字符串变量数据为新的字符填充数据
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="c"></param>
    ''' <param name="len"></param>
    <Extension>
    Public Sub Memset(ByRef s As String, c As Char, len As Integer)
        s = New String(c, len)
    End Sub

    ''' <summary>
    ''' <see cref="Strings.Mid"/> function like operation on any type collection data.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="start">0 base</param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    <Extension> Public Function Midv(Of T)(source As IEnumerable(Of T), start%, length%) As T()
        If source.IsNullOrEmpty Then
            Return New T() {}
        ElseIf source.Count < length Then
            Return source.ToArray
        End If

        Dim array As T() = source.ToArray
        Dim ends As Integer = start + length

        If ends > array.Length Then
            length -= array.Length - ends
        End If

        Dim buf As T() = New T(length - 1) {}
        Call System.Array.ConstrainedCopy(array, start, buf, Scan0, buf.Length)
        Return buf
    End Function

    ''' <summary>
    ''' Load the text file as a numeric vector. Each line in the text file 
    ''' should be a <see cref="Double"/> type numeric value.
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    <Extension> Public Function LoadAsNumericVector(path As String) As Double()
        Dim array As String() = IO.File.ReadAllLines(path)
        Dim n As Double() = array.Select(AddressOf Val).ToArray
        Return n
    End Function

    ''' <summary>
    ''' Split the object array using a specific evaluation function.
    ''' (Please note that, all of the object in the <paramref name="source"/> array 
    ''' that match the <paramref name="delimiter"/> evaluation, will not includes 
    ''' in the returned tokens.)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="delimiter">和字符串的Split函数一样，这里作为delimiter的元素都不会出现在结果之中</param>
    ''' <param name="deliPosition">是否还应该在分区的结果之中包含有分隔符对象？默认不包含</param>
    ''' <returns></returns>
    <Extension> Public Function Split(Of T)(source As IEnumerable(Of T), delimiter As Assert(Of T), Optional deliPosition As DelimiterLocation = DelimiterLocation.NotIncludes) As T()()
        Dim array As T() = source.ToArray
        Dim blocks As New List(Of T())  ' The returned split blocks
        Dim tmp As New List(Of T)

        For i As Integer = 0 To array.Length - 1
            Dim x As T = array(i)

            ' 当前的x元素是分隔符对象
            If delimiter(x) = True Then
                ' 是否将这个分隔符也包含在分组内
                ' 如果是，则包含在下一个分组内
                If deliPosition <> DelimiterLocation.NotIncludes Then
                    If deliPosition = DelimiterLocation.NextFirst Then
                        Call blocks.Add(tmp.ToArray)
                        Call tmp.Clear()
                        Call tmp.Add(x)
                    Else
                        ' 包含在上一个分块的末尾
                        Call tmp.Add(x)
                        Call blocks.Add(tmp.ToArray)
                        Call tmp.Clear()
                    End If
                Else
                    Call blocks.Add(tmp.ToArray)
                    Call tmp.Clear()
                End If
            Else
                Call tmp.Add(x)
            End If
        Next

        If Not tmp.Count = 0 Then
            blocks += tmp.ToArray
        End If

        Return blocks.ToArray
    End Function

    ''' <summary>
    ''' 分隔符对象在分块之中的位置
    ''' </summary>
    Public Enum DelimiterLocation As Integer
        ''' <summary>
        ''' 上一个分块的最末尾
        ''' </summary>
        PreviousLast
        ''' <summary>
        ''' 不会再任何分块之中包含有分隔符
        ''' </summary>
        NotIncludes
        ''' <summary>
        ''' 包含在下一个分块之中的最开始的位置
        ''' </summary>
        NextFirst
    End Enum
End Module
