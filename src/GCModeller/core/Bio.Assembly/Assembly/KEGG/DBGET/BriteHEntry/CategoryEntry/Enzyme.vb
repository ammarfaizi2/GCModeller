﻿Namespace Assembly.KEGG.DBGET.BriteHEntry

    ''' <summary>
    ''' 在这里的entry是KO编号，而非Reaction编号
    ''' </summary>
    Public Class EnzymeEntry : Inherits EnzymaticReaction

        Public ReadOnly Property KO As String
            Get
                Return Entry.Key
            End Get
        End Property

        Public ReadOnly Property geneNames As String()
            Get
                Return Entry.Value.GetTagValue(";").Name.Trim.StringSplit(",\s+")
            End Get
        End Property

        Public ReadOnly Property fullName As String
            Get
                Return Entry.Value.GetTagValue(";", trim:=True).Value
            End Get
        End Property

        Public Property ECName As String

        Sub New(base As EnzymaticReaction)
            Me.Category = base.Category
            Me.Class = base.Class
            Me.EC = base.EC
            Me.Entry = base.Entry
            Me.SubCategory = base.SubCategory

            With EC.GetTagValue(" ", trim:=True)
                EC = .Name
                ECName = .Value

                If EC.StringEmpty Then
                    EC = ECName
                    ECName = $"[EC:{EC}] n/a"
                End If
            End With
        End Sub

        Public Shared Function ParseEntries() As EnzymeEntry()
            Return EnzymaticReaction _
                .Build(GetResource.Hierarchical) _
                .Select(Function(er) New EnzymeEntry(er)) _
                .ToArray
        End Function

        ''' <summary>
        ''' 从卫星资源程序集之中加载数据库数据
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Load resource using <see cref="ResourcesSatellite"/></remarks>
        Public Shared Function GetResource() As htext
            Dim res$ = GetType(EnzymeEntry) _
                .Assembly _
                .ResourcesSatellite() _
                .GetString("ko01000")
            Dim htext As htext = htext.StreamParser(res)
            Return htext
        End Function
    End Class
End Namespace