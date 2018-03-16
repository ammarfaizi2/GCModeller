﻿#Region "Microsoft.VisualBasic::2fba45b4e3370a53925278ccb5fa631a, Shared\InternalApps_CLI\Apps\MapPlot.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
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



    ' /********************************************************************************/

    ' Summaries:

    ' Class MapPlot
    ' 
    '     Constructor: (+1 Overloads) Sub New
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Text
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.InteropService
Imports Microsoft.VisualBasic.ApplicationServices

' Microsoft VisualBasic CommandLine Code AutoGenerator
' assembly: ..\bin\MapPlot.exe

' ====================================================
' SMRUCC genomics GCModeller Programs Profiles Manager
' ====================================================
' 
' < Map.CLI >
' 
' All of the command that available in this program has been list below:
' 
'  /Config.Template:                 
'  /Visual.BBH:                      Visualize the blastp result.
'  /Visualize.blastn.alignment:      Blastn result alignment visualization from the NCBI web blast.
'                                    This tools is only works for a plasmid blastn search result or
'                                    a small gene cluster region in a large genome.
'  --Draw.ChromosomeMap:             Drawing the chromosomes map from the PTT object as the basically
'                                    genome information source.
'  --Draw.ChromosomeMap.genbank:     
' 
' 
' ----------------------------------------------------------------------------------------------------
' 
'    You can using "Settings ??<commandName>" for getting more details command help.

Namespace GCModellerApps


''' <summary>
''' Map.CLI
''' </summary>
'''
Public Class MapPlot : Inherits InteropService

    Public Const App$ = "MapPlot.exe"

    Sub New(App$)
        MyBase._executableAssembly = App$
    End Sub

''' <summary>
''' ```
''' /Config.Template [/out &lt;./config.inf>]
''' ```
''' </summary>
'''
Public Function WriteConfigTemplate(Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Config.Template")
    Call CLI.Append(" ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```
''' /Visual.BBH /in &lt;bbh.Xml> /PTT &lt;genome.PTT> /density &lt;genomes.density.DIR> [/limits &lt;sp-list.txt> /out &lt;image.png>]
''' ```
''' Visualize the blastp result.
''' </summary>
'''
Public Function BBHVisual([in] As String, PTT As String, density As String, Optional limits As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Visual.BBH")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/PTT " & """" & PTT & """ ")
    Call CLI.Append("/density " & """" & density & """ ")
    If Not limits.StringEmpty Then
            Call CLI.Append("/limits " & """" & limits & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```
''' /Visualize.blastn.alignment /in &lt;alignmentTable.txt> /genbank &lt;genome.gb> [/ORF.catagory &lt;catagory.tsv> /region &lt;left,right> /local /out &lt;image.png>]
''' ```
''' Blastn result alignment visualization from the NCBI web blast. This tools is only works for a plasmid blastn search result or a small gene cluster region in a large genome.
''' </summary>
'''
Public Function BlastnVisualizeWebResult([in] As String, genbank As String, Optional orf_catagory As String = "", Optional region As String = "", Optional out As String = "", Optional local As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Visualize.blastn.alignment")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/genbank " & """" & genbank & """ ")
    If Not orf_catagory.StringEmpty Then
            Call CLI.Append("/orf.catagory " & """" & orf_catagory & """ ")
    End If
    If Not region.StringEmpty Then
            Call CLI.Append("/region " & """" & region & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If local Then
        Call CLI.Append("/local ")
    End If


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```
''' --Draw.ChromosomeMap /ptt &lt;genome.ptt> [/conf &lt;config.inf> /out &lt;dir.export> /COG &lt;cog.csv>]
''' ```
''' Drawing the chromosomes map from the PTT object as the basically genome information source.
''' </summary>
'''
Public Function DrawingChrMap(ptt As String, Optional conf As String = "", Optional out As String = "", Optional cog As String = "") As Integer
    Dim CLI As New StringBuilder("--Draw.ChromosomeMap")
    Call CLI.Append(" ")
    Call CLI.Append("/ptt " & """" & ptt & """ ")
    If Not conf.StringEmpty Then
            Call CLI.Append("/conf " & """" & conf & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not cog.StringEmpty Then
            Call CLI.Append("/cog " & """" & cog & """ ")
    End If


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```
''' --Draw.ChromosomeMap.genbank /gb &lt;genome.gbk> [/conf &lt;config.inf> /out &lt;dir.export> /COG &lt;cog.csv>]
''' ```
''' </summary>
'''
Public Function DrawGenbank(gb As String, Optional conf As String = "", Optional out As String = "", Optional cog As String = "") As Integer
    Dim CLI As New StringBuilder("--Draw.ChromosomeMap.genbank")
    Call CLI.Append(" ")
    Call CLI.Append("/gb " & """" & gb & """ ")
    If Not conf.StringEmpty Then
            Call CLI.Append("/conf " & """" & conf & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not cog.StringEmpty Then
            Call CLI.Append("/cog " & """" & cog & """ ")
    End If


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function
End Class
End Namespace

