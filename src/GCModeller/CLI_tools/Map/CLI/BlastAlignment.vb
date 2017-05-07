﻿Imports System.Drawing
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Text
Imports SMRUCC.genomics.Assembly.NCBI.GenBank
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.TabularFormat
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.TabularFormat.ComponentModels
Imports SMRUCC.genomics.ContextModel
Imports SMRUCC.genomics.Interops.NCBI.Extensions
Imports SMRUCC.genomics.Interops.NCBI.Extensions.NCBIBlastResult
Imports SMRUCC.genomics.SequenceModel.FASTA
Imports SMRUCC.genomics.Visualize
Imports SMRUCC.genomics.Visualize.ComparativeGenomics.ModelAPI
Imports SMRUCC.genomics.Visualize.NCBIBlastResult

Partial Module CLI

    ''' <summary>
    ''' 这个函数是从编译好的blast bbh xml结果之中绘图
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/Visual.BBH",
               Info:="Visualize the blastp result.",
               Usage:="/Visual.BBH /in <bbh.Xml> /PTT <genome.PTT> /density <genomes.density.DIR> [/limits <sp-list.txt> /out <image.png>]")>
    <Argument("/PTT", False,
              Description:="A directory which contains all of the information data files for the reference genome, this directory would includes *.gb, *.ptt, *.gff, *.fna, *.faa, etc.")>
    Public Function BBHVisual(args As CommandLine) As Integer
        Dim [in] As String = args - "/in"
        Dim PTTfile As String = args("/PTT")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & ".visualize.png")
        Dim meta As Analysis.BestHit = [in].LoadXml(Of Analysis.BestHit)
        Dim limits As String() = args("/limits").ReadAllLines
        Dim density As String = args("/density")

        If Not limits.IsNullOrEmpty Then
            meta = meta.Take(limits)
        End If

        Dim scores As Func(Of Analysis.Hit, Double) = BBHMetaAPI.DensityScore(density, scale:=20)
        Dim PTT As PTT = TabularFormat.PTT.Load(PTTfile)
        Dim table As AlignmentTable = BBHMetaAPI.DataParser(
            meta, PTT,
            visualGroup:=True,
            scoreMaps:=scores)

        Call $"Min:={table.Hits.Min(Function(x) x.Identity)}, Max:={table.Hits.Max(Function(x) x.Identity)}".__DEBUG_ECHO

        Dim densityQuery As ICOGsBrush = ColorSchema.IdentitiesBrush(scores)
        Dim res As Image = BlastVisualize.PlotMap(
            table, PTT,
            AlignmentColorSchema:="identities",
            IdentityNoColor:=False,
            queryBrush:=densityQuery)

        Return res.SaveAs(out, ImageFormats.Png).CLICode
    End Function

    <ExportAPI("/Visualize.blastn.alignment",
               Info:="Blastn result alignment visualization from the NCBI web blast. This tools is only works for a plasmid blastn search result or a small gene cluster region in a large genome.",
               Usage:="/Visualize.blastn.alignment /in <alignmentTable.txt> /genbank <genome.gb> [/ORF.catagory <catagory.tsv> /local /out <image.png>]")>
    <Argument("/genbank", Description:="Provides the target genome coordinates for the blastn map plots.")>
    <Argument("/local", Description:="The file for ``/in`` parameter is a local blastn output result file?")>
    <Argument("/ORF.catagory", Description:="Using for the ORF shape color render, in a text file and each line its text format like: ``geneID``<TAB>``COG/KOG/GO/KO``")>
    Public Function BlastnVisualizeWebResult(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim gb$ = args <= "/genbank"
        Dim out$ = args.GetValue("/out", [in].TrimSuffix & ".blastn.visualize.png")
        Dim cata$ = args <= "/ORF.catagory"
        Dim local As Boolean = args.GetBoolean("/local")
        Dim genbank As GBFF.File = GBFF.File.Load(gb)
        Dim alignments As AlignmentTable

        If local Then
            alignments = AlignmentTableParserAPI.CreateFromBlastnFile([in], 120)
        Else
            alignments = AlignmentTableParserAPI.LoadTable(
                [in],
                headerSplit:=True)
        End If

        GCSkew.Steps = 250

        Dim nt As FastaToken = genbank.Origin.ToFasta
        Dim PTT As PTT = genbank.GbffToORF_PTT

        Dim region = alignments.GetAlignmentRegion

        If region.Length <= PTT.Size / 10 Then
            ' 这个比对结果是一个基因簇，则需要剪裁操作
            Call $"{[in].BaseName} probably is a cluster in genome {PTT.Title}.".__INFO_ECHO 

            alignments = alignments.Offset(region)
            PTT = PTT.RangeSelection(region, offset:=True)
        End If

        If cata.FileLength() > 0 Then
            Dim category As Dictionary(Of NamedValue(Of String)) =
                cata _
                .ReadAllLines _
                .Select(Function(s) s.Split(ASCII.TAB)) _
                .Select(Function(g) New NamedValue(Of String)(g(0), g.Get(1))) _
                .ToDictionary()

            For Each gene As GeneBrief In PTT
                gene.COG = category(gene.Synonym).Value
                If gene.COG Is Nothing Then
                    gene.COG = ""
                End If
            Next
        End If

        Dim plot As Image = BlastVisualize.PlotMap(
            alignments, PTT,
            AlignmentColorSchema:="identities",
            IdentityNoColor:=False,
            QueryNT:=nt)

        Return plot _
            .CorpBlank(margin:=120, blankColor:=Color.White) _
            .SaveAs(out, ImageFormats.Png) _
            .CLICode
    End Function
End Module