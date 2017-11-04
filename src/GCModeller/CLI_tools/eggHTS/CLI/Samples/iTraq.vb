﻿Imports System.ComponentModel
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports SMRUCC.genomics.Analysis.HTS.Proteomics
Imports SMRUCC.genomics.GCModeller.Workbench.ExperimentDesigner

Partial Module CLI

    <ExportAPI("/iTraq.Symbol.Replacement")>
    <Description("* Using this CLI tool for processing the tag header of iTraq result at first.")>
    <Usage("/iTraq.Symbol.Replacement /in <iTraq.data.csv> /symbols <symbols.csv> [/out <out.DIR>]")>
    <Argument("/in", False, CLITypes.File, PipelineTypes.std_in,
              AcceptTypes:={GetType(iTraqReader)},
              Description:="")>
    <Argument("/symbols", False, CLITypes.File,
              AcceptTypes:={GetType(iTraqSymbols)},
              Description:="Using for replace the mass spectrum expeirment symbol to the user experiment tag.")>
    <Group(CLIGroups.iTraqTool)>
    Public Function iTraqSignReplacement(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim out$ = args.GetValue("/out", [in].ParentPath)
        Dim symbols = (args <= "/symbols").LoadCsv(Of iTraqSymbols)

        With [in].LoadCsv(Of iTraqReader)
            Call .iTraqMatrix(symbols) _
                 .ToArray _
                 .SaveTo(out & "/matrix.csv")
            Call .SymbolReplace(symbols) _
                 .ToArray _
                 .SaveTo(out & $"/{[in].BaseName}.sample.csv")
        End With

        Return 0
    End Function

    ''' <summary>
    ''' 根据实验设计的信息进行矩阵的分组
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    ''' 
    <ExportAPI("/iTraq.matrix.split")>
    <Description("Split the raw matrix into different compare group based on the experimental designer information.")>
    <Usage("/iTraq.matrix.split /in <matrix.csv> /sampleInfo <sampleInfo.csv> /designer <analysis.design.csv> [/out <out.Dir>]")>
    <Group(CLIGroups.iTraqTool)>
    <Argument("/sampleInfo", False, CLITypes.File, AcceptTypes:={GetType(SampleInfo)})>
    <Argument("/designer", False, CLITypes.File, AcceptTypes:={GetType(AnalysisDesigner)},
              Description:="The analysis designer in csv file format for the DEPs calculation, should contains at least two column: <Controls><Experimental>")>
    Public Function iTraqAnalysisMatrixSplit(args As CommandLine) As Integer
        Dim sampleInfo = (args <= "/sampleInfo").LoadCsv(Of SampleInfo)
        Dim designer = (args <= "/designer").LoadCsv(Of AnalysisDesigner)
        Dim out$ = args.GetValue("/out", (args <= "/in").TrimSuffix & "-Groups/")
        Dim matrix As DataSet() = DataSet.LoadDataSet(args <= "/in").ToArray

        For Each group In matrix.MatrixSplit(sampleInfo, designer)
            Dim groupName$ = group.Name
            Dim path$ = out & $"/{groupName.NormalizePathString(False)}.csv"
            Dim data As DataSet() = group.Value

            If Not data.All(Function(x) x.Properties.Count = 0) Then
                Call data.SaveTo(path)
                Call StripNaN(path, replaceAs:="NA")
            End If
        Next

        Return 0
    End Function

    <ExportAPI("/iTraq.t.test")>
    <Usage("/iTraq.t.test /in <matrix.csv> [/level <default=1.5> /p.value <default=0.05> /FDR <default=0.05> /out <out.csv>]")>
    <Group(CLIGroups.iTraqTool)>
    <Argument("/FDR", True, CLITypes.Double,
              Description:="do FDR adjust on the p.value result? If this argument value is set to 1, means no adjustment.")>
    Public Function iTraqTtest(args As CommandLine) As Integer
        Dim data As DataSet() = DataSet.LoadDataSet(args <= "/in").ToArray
        Dim level# = args.GetValue("/level", 1.5)
        Dim pvalue# = args.GetValue("/p.value", 0.05)
        Dim FDR# = args.GetValue("/FDR", 0.05)
        Dim out$ = args.GetValue("/out", (args <= "/in").TrimSuffix & ".log2FC.t.test.csv")
        Dim DEPs As DEP_iTraq() = data.logFCtest(level, pvalue, FDR)

        Return DEPs _
            .Where(Function(x) x.log2FC <> 0R) _
            .ToArray _
            .SaveDataSet(out) _
            .CLICode
    End Function
End Module