﻿Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.GBFF.Keywords
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.GBFF.Keywords.FEATURES
Imports SMRUCC.genomics.SequenceModel
Imports SMRUCC.genomics.SequenceModel.NucleotideModels

Namespace Assembly.NCBI.GenBank.GBFF

    Public Module GbkParser

        ''' <summary>
        ''' 将一个GBK文件从硬盘文件之中读取出来，当发生错误的时候，会抛出错误
        ''' </summary>
        ''' <param name="Path"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        '''
        <ExportAPI("Read")> Public Function Read(Path As String) As NCBI.GenBank.GBFF.File
            Dim File As String() = IO.File.ReadAllLines(Path)
            Dim GenBank = __loadData(File, Path)

            Return GenBank
        End Function

        Private Function __originReadThread(gb As NCBI.GenBank.GBFF.File, buf As String()) As NCBI.GenBank.GBFF.Keywords.ORIGIN
            Dim bufs As String() = Internal_readBlock(KeyWord.GBK_FIELD_KEY_ORIGIN, buf)

            If bufs.IsNullOrEmpty Then
                Call $"{gb.FilePath.ToFileURL} have no sequence data.".__DEBUG_ECHO

                Return New ORIGIN With {
                    .SequenceData = ""
                }
            Else
                Return CType(bufs.Skip(1).ToArray, ORIGIN)
            End If
        End Function

        Friend Function __loadData(innerBufs As String(), Path As String) As NCBI.GenBank.GBFF.File
            Call "Start loading ncbi gbk file...".__DEBUG_ECHO

            Dim Sw As Stopwatch = Stopwatch.StartNew
            Dim gb As New File With {
                .FilePath = Path
            }
            Dim ReadThread As Action(Of File, String()) = AddressOf __readOrigin
            Dim ReadThreadResult As IAsyncResult = ReadThread.BeginInvoke(gb, innerBufs, Nothing, Nothing)

            gb.Comment = Internal_readBlock(KeyWord.GBK_FIELD_KEY_COMMENT, innerBufs)
            gb.Features = Internal_readBlock(KeyWord.GBK_FIELD_KEY_FEATURES, innerBufs).Skip(1).ToArray.FeaturesListParser
            gb.Accession = ACCESSION.CreateObject(Internal_readBlock(KeyWord.GBK_FIELD_KEY_ACCESSION, innerBufs), Path.BaseName)
            gb.Reference = REFERENCE.InternalParser(innerBufs)
            gb.Definition = Internal_readBlock(KeyWord.GBK_FIELD_KEY_DEFINITION, innerBufs)
            gb.Version = Internal_readBlock(KeyWord.GBK_FIELD_KEY_VERSION, innerBufs)
            gb.Source = Internal_readBlock(KeyWord.GBK_FIELD_KEY_SOURCE, innerBufs)
            gb.Locus = LOCUS.InternalParser(Internal_readBlock(KeyWord.GBK_FIELD_KEY_LOCUS, innerBufs).First)
            gb.Keywords = GBFF.Keywords.KEYWORDS.__innerParser(Internal_readBlock(KeyWord.GBK_FIELD_KEY_KEYWORDS, innerBufs))
            gb.DbLinks = GBFF.Keywords.DBLINK.Parser(Internal_readBlock(KeyWord.GBK_FIELD_KEY_DBLINK, innerBufs))

            gb.Accession.gb = gb
            gb.Comment.gb = gb
            gb.Definition.gb = gb
            gb.Features.gb = gb
            gb.Keywords.gb = gb
            gb.Locus.gb = gb
            gb.Reference.gb = gb
            gb.Source.gb = gb
            gb.Version.gb = gb
            gb.DbLinks.gb = gb

            Call gb.Features.LinkEntry()
            Call ReadThread.EndInvoke(ReadThreadResult)
            Call $"({gb.Accession.AccessionId})""{gb.Definition.Value}"" data load done!  {FileIO.FileSystem.GetFileInfo(Path).Length}bytes {Sw.ElapsedMilliseconds}ms...".__DEBUG_ECHO

            gb.Origin.gb = gb  '由于使用线程进行读取的，所以不能保证在赋值的时候是否初始化基因组序列完成
            innerBufs = Nothing

            Return gb
        End Function

        Private Sub __readOrigin(gb As File, bufs As String())
            gb.Origin = __originReadThread(gb, buf:=bufs)
        End Sub

        ''' <summary>
        ''' 快速读取数据库文件中的某一个字段的文本块
        ''' </summary>
        ''' <param name="keyword">字段名</param>
        ''' <returns>该字段的内容</returns>
        ''' <remarks></remarks>
        Private Function Internal_readBlock(Keyword As String, ByRef innerBufs As String()) As String()
            Dim Regx As New Regex(String.Format("^{0}\s+.+$", Keyword))
            Dim LQuery As String() =
                LinqAPI.Exec(Of String) <= From str As String
                                           In innerBufs
                                           Where Regx.Match(str).Success OrElse
                                               String.Equals(str, Keyword)
                                           Select str
            Dim index As Integer
            Dim p As Integer
            Dim bufs() As String = Nothing

            For Each Head As String In LQuery
                index = Array.IndexOf(innerBufs, Head)
                p = index + 1

                Do While String.IsNullOrEmpty(innerBufs(p)) OrElse innerBufs(p).First = " "c
                    p += 1
                    If p = innerBufs.Length Then
                        Exit Do
                    End If
                Loop

                Dim sBuf As String() = New String(p - index - 1) {}

                Call Array.ConstrainedCopy(innerBufs,
                                           index,
                                           sBuf,
                                           Scan0,
                                           sBuf.Length)

                If bufs Is Nothing Then
                    index = Scan0
                    ReDim bufs(sBuf.Length - 1)
                Else
                    index = bufs.Length
                    ReDim Preserve bufs(bufs.Length + sBuf.Length - 1)
                End If

                Call Array.ConstrainedCopy(sBuf, Scan0, bufs, index, sBuf.Length)
            Next

            Return bufs
        End Function
    End Module
End Namespace