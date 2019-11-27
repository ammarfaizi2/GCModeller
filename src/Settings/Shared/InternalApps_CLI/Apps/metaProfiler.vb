﻿Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.InteropService
Imports Microsoft.VisualBasic.ApplicationServices

' Microsoft VisualBasic CommandLine Code AutoGenerator
' assembly: ..\bin\metaProfiler.exe

' 
'  // 
'  // SMRUCC genomics GCModeller Programs Profiles Manager
'  // 
'  // VERSION:   3.3277.7268.38152
'  // ASSEMBLY:  Settings, Version=3.3277.7268.38152, Culture=neutral, PublicKeyToken=null
'  // COPYRIGHT: Copyright © SMRUCC genomics. 2014
'  // GUID:      a554d5f5-a2aa-46d6-8bbb-f7df46dbbe27
'  // BUILT:     11/24/2019 8:47:12 AM
'  // 
' 
' 
' 
' 
' SYNOPSIS
' Settings command [/argument argument-value...] [/@set environment-variable=value...]
' 
' All of the command that available in this program has been list below:
' 
'  /box.plot:                                   
'  /do.enterotype.cluster:                      
'  /Export.Megan.BIOM:                          Export v1.0 biom json file for data visualize in Megan
'                                               program.
'  /gast.stat.names:                            
'  /heatmap.plot:                               
'  /hmp.otu_table:                              Export otu table from hmp biom files.
'  /LefSe.Matrix:                               Processing the relative aboundance matrix to the input
'                                               format file as it describ: http://huttenhower.sph.harvard.edu/galaxy/root?tool_id=lefse_upload
'  /Membrane_transport.network:                 Construct a relationship network based on the Membrane
'                                               transportor in bacteria genome
'  /Metabolic.EndPoint.Profiles.background:     Create Metabolic EndPoint Profiles Background Model
'  /OTU.cluster:                                
'  /Relative_abundance.barplot:                 
'  /Relative_abundance.stacked.barplot:         
'  /significant.difference:                     
'  /SILVA.bacteria:                             
'  /UPGMA.Tree:                                 
' 
' 
' API list that with functional grouping
' 
' 1. 02. Alpha diversity analysis tools
' 
' 
'    /Rank_Abundance:                             https://en.wikipedia.org/wiki/Rank_abundance_curve
' 
' 
' 2. 03. Human Microbiome Project cli tool
' 
' 
'    /handle.hmp.manifest:                        Download files from HMP website through http/fasp.
'    /hmp.manifest.files:                         
' 
' 
' 3. Microbiome antibiotic resistance composition analysis tools
' 
' 
'    /ARO.fasta.header.table:                     
' 
' 
' 4. Microbiome network cli tools
' 
' 
'    /Metagenome.UniProt.Ref:                     Create background model for apply pathway enrichment
'                                                 analysis of the Metagenome data.
'    /microbiome.metabolic.network:               Construct a metabolic complementation network between
'                                                 the bacterial genomes from a given taxonomy list.
'    /microbiome.pathway.profile:                 Generates the pathway network profile for the microbiome
'                                                 OTU result based on the KEGG and UniProt reference.
'    /microbiome.pathway.run.profile:             Build pathway interaction network based on the microbiome
'                                                 profile result.
'    /UniProt.screen.model:                       
' 
' 
' 5. SILVA database cli tools
' 
' 
'    /SILVA.headers:                              
' 
' 
' 6. Taxonomy assign cli tools
' 
' 
'    /gast.Taxonomy.greengenes:                   OTU taxonomy assign by apply gast method on the result
'                                                 of OTU rep sequence alignment against the greengenes.
' 
' 
' ----------------------------------------------------------------------------------------------------
' 
'    1. You can using "Settings ??<commandName>" for getting more details command help.
'    2. Using command "Settings /CLI.dev [---echo]" for CLI pipeline development.
'    3. Using command "Settings /i" for enter interactive console mode.

Namespace GCModellerApps


''' <summary>
'''
''' </summary>
'''
Public Class metaProfiler : Inherits InteropService

    Public Const App$ = "metaProfiler.exe"

    Sub New(App$)
        MyBase._executableAssembly = App$
    End Sub

     <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Shared Function FromEnvironment(directory As String) As metaProfiler
          Return New metaProfiler(App:=directory & "/" & metaProfiler.App)
     End Function

''' <summary>
''' ```bash
''' /ARO.fasta.header.table /in &lt;directory&gt; [/out &lt;out.csv&gt;]
''' ```
''' </summary>
'''
Public Function AROSeqTable([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/ARO.fasta.header.table")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /box.plot /in &lt;data.csv&gt; /groups &lt;sampleInfo.csv&gt; [/out &lt;out.DIR&gt;]
''' ```
''' </summary>
'''
Public Function Boxplot([in] As String, groups As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/box.plot")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/groups " & """" & groups & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /do.enterotype.cluster /in &lt;dataset.csv/txt&gt; [/iterations 50000 /parallel /out &lt;clusters.csv&gt;]
''' ```
''' </summary>
'''
Public Function DoEnterotypeCluster([in] As String, Optional iterations As String = "", Optional out As String = "", Optional parallel As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/do.enterotype.cluster")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not iterations.StringEmpty Then
            Call CLI.Append("/iterations " & """" & iterations & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If parallel Then
        Call CLI.Append("/parallel ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Export.Megan.BIOM /in &lt;relative.table.csv&gt; [/dense /out &lt;out.biom.json&gt;]
''' ```
''' Export v1.0 biom json file for data visualize in Megan program.
''' </summary>
'''
Public Function ExportToMegan([in] As String, Optional out As String = "", Optional dense As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Export.Megan.BIOM")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If dense Then
        Call CLI.Append("/dense ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /gast.stat.names /in &lt;*.names&gt; /gast &lt;gast.out&gt; [/out &lt;out.Csv&gt;]
''' ```
''' </summary>
'''
Public Function StateNames([in] As String, gast As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/gast.stat.names")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/gast " & """" & gast & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /gast.Taxonomy.greengenes /in &lt;blastn.txt&gt; /query &lt;OTU.rep.fasta&gt; /taxonomy &lt;97_otu_taxonomy.txt&gt; [/removes.lt &lt;default=0.0001&gt; /gast.consensus /min.pct &lt;default=0.6&gt; /out &lt;gastOut.csv&gt;]
''' ```
''' OTU taxonomy assign by apply gast method on the result of OTU rep sequence alignment against the greengenes.
''' </summary>
'''
Public Function gastTaxonomy_greengenes([in] As String, query As String, taxonomy As String, Optional removes_lt As String = "0.0001", Optional min_pct As String = "0.6", Optional out As String = "", Optional gast_consensus As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/gast.Taxonomy.greengenes")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/query " & """" & query & """ ")
    Call CLI.Append("/taxonomy " & """" & taxonomy & """ ")
    If Not removes_lt.StringEmpty Then
            Call CLI.Append("/removes.lt " & """" & removes_lt & """ ")
    End If
    If Not min_pct.StringEmpty Then
            Call CLI.Append("/min.pct " & """" & min_pct & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If gast_consensus Then
        Call CLI.Append("/gast.consensus ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /handle.hmp.manifest /in &lt;manifest.tsv&gt; [/out &lt;save.directory&gt;]
''' ```
''' Download files from HMP website through http/fasp.
''' </summary>
'''
Public Function Download16sSeq([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/handle.hmp.manifest")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /heatmap.plot /in &lt;data.csv&gt; /groups &lt;sampleInfo.csv&gt; [/schema &lt;default=YlGnBu:c9&gt; /tsv /group /title &lt;title&gt; /size &lt;2700,3000&gt; /out &lt;out.DIR&gt;]
''' ```
''' </summary>
'''
Public Function HeatmapPlot([in] As String, groups As String, Optional schema As String = "YlGnBu:c9", Optional title As String = "", Optional size As String = "", Optional out As String = "", Optional tsv As Boolean = False, Optional group As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/heatmap.plot")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/groups " & """" & groups & """ ")
    If Not schema.StringEmpty Then
            Call CLI.Append("/schema " & """" & schema & """ ")
    End If
    If Not title.StringEmpty Then
            Call CLI.Append("/title " & """" & title & """ ")
    End If
    If Not size.StringEmpty Then
            Call CLI.Append("/size " & """" & size & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If tsv Then
        Call CLI.Append("/tsv ")
    End If
    If group Then
        Call CLI.Append("/group ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /hmp.manifest.files /in &lt;manifest.tsv&gt; [/out &lt;list.txt&gt;]
''' ```
''' </summary>
'''
Public Function ExportFileList([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/hmp.manifest.files")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /hmp.otu_table /in &lt;download.directory&gt; [/out &lt;out.csv&gt;]
''' ```
''' Export otu table from hmp biom files.
''' </summary>
'''
Public Function ExportsOTUTable([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/hmp.otu_table")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /LefSe.Matrix /in &lt;Species_abundance.csv&gt; /ncbi_taxonomy &lt;NCBI_taxonomy&gt; [/all_rank /out &lt;out.tsv&gt;]
''' ```
''' Processing the relative aboundance matrix to the input format file as it describ: http://huttenhower.sph.harvard.edu/galaxy/root?tool_id=lefse_upload
''' </summary>
'''
Public Function LefSeMatrix([in] As String, ncbi_taxonomy As String, Optional out As String = "", Optional all_rank As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/LefSe.Matrix")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/ncbi_taxonomy " & """" & ncbi_taxonomy & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If all_rank Then
        Call CLI.Append("/all_rank ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Membrane_transport.network /metagenome &lt;list.txt/OTU.tab/biom&gt; /ref &lt;reaction.repository.XML&gt; /uniprot &lt;repository.json&gt; [/out &lt;network.directory&gt;]
''' ```
''' Construct a relationship network based on the Membrane transportor in bacteria genome
''' </summary>
'''
Public Function Membrane_transportNetwork(metagenome As String, ref As String, uniprot As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Membrane_transport.network")
    Call CLI.Append(" ")
    Call CLI.Append("/metagenome " & """" & metagenome & """ ")
    Call CLI.Append("/ref " & """" & ref & """ ")
    Call CLI.Append("/uniprot " & """" & uniprot & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Metabolic.EndPoint.Profiles.Background /ref &lt;reaction.repository.XML&gt; /uniprot &lt;repository.json&gt; [/out &lt;background.XML&gt;]
''' ```
''' Create Metabolic EndPoint Profiles Background Model
''' </summary>
'''
Public Function MetabolicEndPointProfilesBackground(ref As String, uniprot As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Metabolic.EndPoint.Profiles.Background")
    Call CLI.Append(" ")
    Call CLI.Append("/ref " & """" & ref & """ ")
    Call CLI.Append("/uniprot " & """" & uniprot & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Metagenome.UniProt.Ref /in &lt;uniprot.ultralarge.xml/cache.directory&gt; [/cache /all /out &lt;out.json&gt;]
''' ```
''' Create background model for apply pathway enrichment analysis of the Metagenome data.
''' </summary>
'''
Public Function BuildUniProtReference([in] As String, Optional out As String = "", Optional cache As Boolean = False, Optional all As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Metagenome.UniProt.Ref")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If cache Then
        Call CLI.Append("/cache ")
    End If
    If all Then
        Call CLI.Append("/all ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /microbiome.metabolic.network /metagenome &lt;list.txt/OTU.tab/biom&gt; /ref &lt;reaction.repository.XML&gt; /uniprot &lt;repository.json&gt; /Membrane_transport &lt;Membrane_transport.csv&gt; [/out &lt;network.directory&gt;]
''' ```
''' Construct a metabolic complementation network between the bacterial genomes from a given taxonomy list.
''' </summary>
'''
Public Function MetabolicComplementationNetwork(metagenome As String, ref As String, uniprot As String, Membrane_transport As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/microbiome.metabolic.network")
    Call CLI.Append(" ")
    Call CLI.Append("/metagenome " & """" & metagenome & """ ")
    Call CLI.Append("/ref " & """" & ref & """ ")
    Call CLI.Append("/uniprot " & """" & uniprot & """ ")
    Call CLI.Append("/Membrane_transport " & """" & Membrane_transport & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /microbiome.pathway.profile /in &lt;gastout.csv&gt; /ref &lt;UniProt.ref.index.json&gt; /maps &lt;kegg.maps.ref.XML&gt; [/sampleName &lt;default=NULL&gt; /just.profiles /rank &lt;default=family&gt; /p.value &lt;default=0.05&gt; /out &lt;out.directory&gt;]
''' ```
''' Generates the pathway network profile for the microbiome OTU result based on the KEGG and UniProt reference.
''' </summary>
'''
Public Function PathwayProfiles([in] As String, ref As String, maps As String, Optional samplename As String = "NULL", Optional rank As String = "family", Optional p_value As String = "0.05", Optional out As String = "", Optional just_profiles As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/microbiome.pathway.profile")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/ref " & """" & ref & """ ")
    Call CLI.Append("/maps " & """" & maps & """ ")
    If Not samplename.StringEmpty Then
            Call CLI.Append("/samplename " & """" & samplename & """ ")
    End If
    If Not rank.StringEmpty Then
            Call CLI.Append("/rank " & """" & rank & """ ")
    End If
    If Not p_value.StringEmpty Then
            Call CLI.Append("/p.value " & """" & p_value & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If just_profiles Then
        Call CLI.Append("/just.profiles ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /microbiome.pathway.run.profile /in &lt;profile.csv&gt; /maps &lt;kegg.maps.ref.Xml&gt; [/rank &lt;default=family&gt; /colors &lt;default=Set1:c6&gt; /tick 1 /size &lt;2000,1600&gt; /p.value &lt;default=0.05&gt; /out &lt;out.directory&gt;]
''' ```
''' Build pathway interaction network based on the microbiome profile result.
''' </summary>
'''
Public Function RunProfile([in] As String, maps As String, Optional rank As String = "family", Optional colors As String = "Set1:c6", Optional tick As String = "", Optional size As String = "", Optional p_value As String = "0.05", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/microbiome.pathway.run.profile")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/maps " & """" & maps & """ ")
    If Not rank.StringEmpty Then
            Call CLI.Append("/rank " & """" & rank & """ ")
    End If
    If Not colors.StringEmpty Then
            Call CLI.Append("/colors " & """" & colors & """ ")
    End If
    If Not tick.StringEmpty Then
            Call CLI.Append("/tick " & """" & tick & """ ")
    End If
    If Not size.StringEmpty Then
            Call CLI.Append("/size " & """" & size & """ ")
    End If
    If Not p_value.StringEmpty Then
            Call CLI.Append("/p.value " & """" & p_value & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /OTU.cluster /left &lt;left.fq&gt; /right &lt;right.fq&gt; /silva &lt;silva.bacteria.fasta&gt; [/out &lt;out.directory&gt; /processors &lt;default=2&gt; /@set mothur=path]
''' ```
''' </summary>
'''
Public Function ClusterOTU(left As String, right As String, silva As String, Optional out As String = "", Optional processors As String = "2", Optional _set As String = "") As Integer
    Dim CLI As New StringBuilder("/OTU.cluster")
    Call CLI.Append(" ")
    Call CLI.Append("/left " & """" & left & """ ")
    Call CLI.Append("/right " & """" & right & """ ")
    Call CLI.Append("/silva " & """" & silva & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not processors.StringEmpty Then
            Call CLI.Append("/processors " & """" & processors & """ ")
    End If
    If Not _set.StringEmpty Then
     Call CLI.Append($"/@set """"--internal_pipeline=TRUE;'{_set}'"""" ")
Else
     Call CLI.Append("/@set --internal_pipeline=TRUE ")
    End If


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Rank_Abundance /in &lt;OTU.table.csv&gt; [/schema &lt;color schema, default=Rainbow&gt; /out &lt;out.DIR&gt;]
''' ```
''' https://en.wikipedia.org/wiki/Rank_abundance_curve
''' </summary>
'''
Public Function Rank_Abundance([in] As String, Optional schema As String = "Rainbow", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Rank_Abundance")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not schema.StringEmpty Then
            Call CLI.Append("/schema " & """" & schema & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Relative_abundance.barplot /in &lt;dataset.csv&gt; [/group &lt;sample_group.csv&gt; /desc /asc /take &lt;-1&gt; /size &lt;3000,2700&gt; /column.n &lt;default=9&gt; /interval &lt;10px&gt; /out &lt;out.png&gt;]
''' ```
''' </summary>
'''
Public Function Relative_abundance_barplot([in] As String, Optional group As String = "", Optional take As String = "", Optional size As String = "", Optional column_n As String = "9", Optional interval As String = "", Optional out As String = "", Optional desc As Boolean = False, Optional asc As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Relative_abundance.barplot")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not group.StringEmpty Then
            Call CLI.Append("/group " & """" & group & """ ")
    End If
    If Not take.StringEmpty Then
            Call CLI.Append("/take " & """" & take & """ ")
    End If
    If Not size.StringEmpty Then
            Call CLI.Append("/size " & """" & size & """ ")
    End If
    If Not column_n.StringEmpty Then
            Call CLI.Append("/column.n " & """" & column_n & """ ")
    End If
    If Not interval.StringEmpty Then
            Call CLI.Append("/interval " & """" & interval & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If desc Then
        Call CLI.Append("/desc ")
    End If
    If asc Then
        Call CLI.Append("/asc ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Relative_abundance.stacked.barplot /in &lt;dataset.csv&gt; [/group &lt;sample_group.csv&gt; /out &lt;out.png&gt;]
''' ```
''' </summary>
'''
Public Function Relative_abundance_stackedbarplot([in] As String, Optional group As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Relative_abundance.stacked.barplot")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not group.StringEmpty Then
            Call CLI.Append("/group " & """" & group & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /significant.difference /in &lt;data.csv&gt; /groups &lt;sampleInfo.csv&gt; [/out &lt;out.csv.DIR&gt;]
''' ```
''' </summary>
'''
Public Function SignificantDifference([in] As String, groups As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/significant.difference")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/groups " & """" & groups & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /SILVA.bacteria /in &lt;silva.fasta&gt; [/out &lt;silva.bacteria.fasta&gt;]
''' ```
''' </summary>
'''
Public Function SILVABacterial([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/SILVA.bacteria")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /SILVA.headers /in &lt;silva.fasta&gt; /out &lt;headers.tsv&gt;
''' ```
''' </summary>
'''
Public Function SILVA_headers([in] As String, out As String) As Integer
    Dim CLI As New StringBuilder("/SILVA.headers")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/out " & """" & out & """ ")
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /UniProt.screen.model /in &lt;model.Xml&gt; [/coverage &lt;default=0.6&gt; /terms &lt;default=1000&gt; /out &lt;subset.xml&gt;]
''' ```
''' </summary>
'''
Public Function ScreenModels([in] As String, Optional coverage As String = "0.6", Optional terms As String = "1000", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/UniProt.screen.model")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not coverage.StringEmpty Then
            Call CLI.Append("/coverage " & """" & coverage & """ ")
    End If
    If Not terms.StringEmpty Then
            Call CLI.Append("/terms " & """" & terms & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /UPGMA.Tree /in &lt;in.csv&gt; [/out &lt;&gt;]
''' ```
''' </summary>
'''
Public Function UPGMATree([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/UPGMA.Tree")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function
End Class
End Namespace
