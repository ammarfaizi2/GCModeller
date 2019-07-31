﻿Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Namespace CommandLine

    ''' <summary>
    ''' Git bash environment helper module
    ''' </summary>
    Module GitBashEnvironment

        ''' <summary>
        ''' Enable .NET application running from git bash terminal
        ''' </summary>
        Const gitBash$ = "C:/Program Files/Git"

        ''' <summary>
        ''' Makes compatibility with git bash: <see cref="gitBash"/> = ``C:/Program Files/Git``
        ''' </summary>
        ''' <returns></returns>
        Public Function GetCLIArgs() As CommandLine
            ' 第一个参数为应用程序的文件路径，不需要
            Dim args$() = Environment.GetCommandLineArgs
            Dim tokens$() = args _
                .Skip(1) _
                .Select(Function(t) t.Replace(gitBash, "")) _
                .ToArray
            Dim cliString$ = tokens.JoinBy(" ")
            Dim cli = CLITools.TryParse(tokens, False, cliString)

            Return cli
        End Function

        Friend Function isRunningOnGitBash() As Boolean
            Return Environment.GetCommandLineArgs.Any(Function(a) InStr(a, gitBash) > 0)
        End Function

        ''' <summary>
        ''' (\\)192.168.1.239\blablabla
        ''' 前面的两个斜杠可能被预处理的时候被清除掉了
        ''' 所以在这里只匹配IP地址和后面的路径部分
        ''' </summary>
        Const BrokenWindowsNetworkDirectoryPattern = "\d+(\.\d+){3}\.+"
        Const WindowsNetworkDirectoryPattern = "\\{2}" & BrokenWindowsNetworkDirectoryPattern

        <Extension>
        Public Iterator Function fixWindowsNetworkDirectory(tokens As String()) As IEnumerable(Of String)
            Dim trim$
            Dim matchBroken$

            For Each token As String In tokens
                If App.IsMicrosoftPlatform AndAlso App.RunningInGitBash Then
                    ' 只针对Windows环境中的git bash环境进行修复
                    ' 因为gitbash会对\进行转义
                    ' 所以 \\192.168.1.239 之类的网络路径会被强制转义为 \192.168.1.239 即当前驱动器的某一个文件夹
                    If token.IsPattern(WindowsNetworkDirectoryPattern) Then
                        ' 已经是一个完整的路径了，直接返回
                        Yield token
                    Else
                        trim = token.TrimStart("\"c)
                        matchBroken = trim.Match(BrokenWindowsNetworkDirectoryPattern, RegexOptions.Singleline)

                        If trim <> token AndAlso InStr(trim, matchBroken) = 1 Then
                            Yield "\\" & trim
                        Else
                            ' 这不是一个网络路径
                            ' 则不需要进行修复
                            ' 直接返回原始的字符串即可
                            Yield token
                        End If
                    End If
                Else
                    ' 不是运行于gitbash之上的
                    ' 不需要修补，直接返回
                    Yield token
                End If
            Next
        End Function
    End Module
End Namespace