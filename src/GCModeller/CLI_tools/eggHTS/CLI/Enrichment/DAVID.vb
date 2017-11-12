﻿Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Analysis.GO
Imports SMRUCC.genomics.Analysis.HTS.Proteomics
Imports SMRUCC.genomics.Analysis.KEGG
Imports SMRUCC.genomics.Analysis.Microarray
Imports SMRUCC.genomics.Analysis.Microarray.DAVID
Imports SMRUCC.genomics.Assembly.KEGG.DBGET.BriteHEntry
Imports SMRUCC.genomics.Assembly.KEGG.WebServices
Imports SMRUCC.genomics.Assembly.Uniprot.XML

Partial Module CLI

    <ExportAPI("/DAVID.Split")>
    <Usage("/DAVID.Split /in <DAVID.txt> [/out <out.DIR, default=./>]")>
    <Group(CLIGroups.DAVID)>
    Public Function SplitDAVID(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim out$ = (args <= "/out") Or [in].ParentPath.AsDefault

        With SMRUCC.genomics.Analysis.Microarray.DAVID.Load(in$)
            Call .SelectGoTerms.SaveTo($"{out}/GO_enrichment.csv")
            Call .SelectKEGGPathway.SaveTo($"{out}/KEGG_enrichment.csv")
        End With

        Return 0
    End Function

    <ExportAPI("/KEGG.enrichment.DAVID")>
    <Usage("/KEGG.enrichment.DAVID /in <david.csv> [/tsv /custom <ko00001.keg> /size <default=1200,1000> /p.value <default=0.05> /tick 1 /out <out.png>]")>
    <Group(CLIGroups.DAVID)>
    Public Function DAVID_KEGGplot(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim pvalue# = args.GetValue("/p.value", 0.05R)
        Dim out$ = (args <= "/out") Or $"{[in].TrimSuffix}.DAVID_KEGG.plot_p.value={pvalue}.png".AsDefault
        Dim isTsv As Boolean = args.IsTrue("/tsv")
        Dim tick# = args.GetValue("/tick", 1.0R)

        ' 处理DAVID数据
        Dim table As FunctionCluster() = DAVID.Load([in], csv:=Not isTsv)
        Dim KEGG = table.SelectKEGGPathway
        Dim size$ = args.GetValue("/size", "1200,1000")
        Dim KEGG_PATH As Dictionary(Of String, BriteHText) = Nothing

        With args <= "/custom"
            If .FileExists(True) Then
                KEGG_PATH = PathwayMapping.CustomPathwayTable(ko00001:= .ref)
            End If
        End With

        Return KEGG _
            .KEGGEnrichmentPlot(size:=size,
                                KEGG:=KEGG_PATH,
                                tick:=tick,
                                pvalue:=pvalue) _
            .Save(out) _
            .CLICode
    End Function

    <ExportAPI("/GO.enrichment.DAVID")>
    <Usage("/GO.enrichment.DAVID /in <DAVID.csv> [/tsv /go <go.obo> /size <default=1200,1000> /tick 1 /p.value <0.05> /out <out.png>]")>
    <Group(CLIGroups.DAVID)>
    Public Function DAVID_GOplot(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim pvalue# = args.GetValue("/p.value", 0.05)
        Dim size$ = (args <= "/size") Or "1200,1000".AsDefault
        Dim isTsv As Boolean = args.IsTrue("/tsv")
        Dim tick# = args.GetValue("/tick", 1.0#)
        Dim GO$ = (args <= "/GO") Or (GCModeller.FileSystem.FileSystem.GO & "/GO.obo").AsDefault
        Dim out$ = (args <= "/out") Or $"{[in].TrimSuffix}_p.value={pvalue}.png".AsDefault
        Dim table As FunctionCluster() = DAVID.Load([in], csv:=Not isTsv)
        Dim GOterms = table.SelectGoTerms

        Return GOterms _
            .EnrichmentPlot(size, tick:=tick, pvalue:=pvalue) _
            .Save(out) _
            .CLICode
    End Function

    ''' <summary>
    ''' 因为富集分析的输出列表都是uniprotID，所以还需要uniprot注释数据转换为KEGG编号
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/KEGG.enrichment.DAVID.pathwaymap")>
    <Usage("/KEGG.enrichment.DAVID.pathwaymap /in <david.csv> /uniprot <uniprot.XML> [/tsv /DEPs <deps.csv> /colors <default=red,blue,green> /tag <default=log2FC> /pvalue <default=0.05> /out <out.DIR>]")>
    <Group(CLIGroups.DAVID)>
    Public Function DAVID_KEGGPathwayMap(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim out$ = args.GetValue("/out", [in].TrimSuffix & ".DAVID_KEGG/")
        Dim uniprot$ = args <= "/uniprot"
        Dim uniprot2KEGG = UniProtXML.Load(uniprot) _
            .entries _
            .Where(Function(x) x.Xrefs.ContainsKey("KEGG")) _
            .Select(Function(protein)
                        Return protein.accessions.Select(Function(uniprotID)
                                                             Return (uniprotID, protein.Xrefs("KEGG").Select(Function(id) id.id).ToArray)
                                                         End Function)
                    End Function) _
            .IteratesALL _
            .GroupBy(Function(x) x.Item1) _
            .ToDictionary(Function(id) id.Key,
                          Function(x)
                              Return x.Select(Function(o) o.Item2) _
                                  .IteratesALL _
                                  .Distinct _
                                  .ToArray
                          End Function)
        Dim pvalue# = args.GetValue("/pvalue", 0.05)
        Dim isTsv As Boolean = args.IsTrue("/tsv")

        ' 处理DAVID数据
        Dim table As FunctionCluster() = DAVID.Load([in], csv:=Not isTsv)
        Dim KEGG = table.SelectKEGGPathway(uniprot2KEGG)

        With args <= "/DEPs"
            If .FileLength > 0 Then
                Dim DEPgenes = EntityObject.LoadDataSet(.ref).SplitID.ToArray
                Dim isDEP As Func(Of EntityObject, Boolean) =
                    Function(gene)
                        Return gene("is.DEP").TextEquals("TRUE")
                    End Function
                Dim readTag$ = args.GetValue("/tag", "log2FC")
                Dim colors = DEGProfiling.ColorsProfiling(DEPgenes, isDEP, readTag, uniprot2KEGG)

                Call KEGG.KOBAS_DEPs(colors, EXPORT:=out, pvalue:=pvalue)
            Else
                Call KEGG.KOBAS_visualize(EXPORT:=out, pvalue:=pvalue)
            End If
        End With

        Return 0
    End Function
End Module