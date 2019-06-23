﻿#Region "Microsoft.VisualBasic::c7faad2ba30eda9e63960a041f6a40a4, data\RegulonDatabase\Regprecise\WebServices\WebParser\Regulator.vb"

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

    '     Enum Types
    ' 
    '         RNA, TF
    ' 
    '  
    ' 
    ' 
    ' 
    '     Class Regulator
    ' 
    '         Properties: biological_process, effector, family, infoURL, locus_tag
    '                     LocusId, operons, pathway, Regulates, regulationMode
    '                     regulator, regulatorySites, regulog, type
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Function: __exportServlet, __getTagValue, __getTagValue_td, CreateObject, ExportMotifs
    '                   (+2 Overloads) GetMotifSite, More, ToString
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Text.Xml.Models
Imports SMRUCC.genomics.Data.Regtransbase.WebServices
Imports SMRUCC.genomics.SequenceModel

Namespace Regprecise

    Public Class Regulator : Implements IReadOnlyId

        <XmlAttribute> Public Property type As Types
        <XmlAttribute> Public Property family As String
        <XmlAttribute> Public Property regulationMode As String

        <XmlElement> Public Property regulator As NamedValue
        <XmlElement> Public Property effector As String
        <XmlElement> Public Property pathway As String
        <XmlElement> Public Property locus_tag As NamedValue
        <XmlElement> Public Property biological_process As String()
        <XmlElement> Public Property regulog As NamedValue

        ''' <summary>
        ''' 用来下载生成motif数据库的时候所需要使用的
        ''' </summary>
        ''' <returns></returns>
        <XmlElement("url")>
        Public Property infoURL As String

        <XmlArray("regulatory_sites", [Namespace]:=MotifFasta.xmlns)>
        Public Property regulatorySites As MotifFasta()

        ''' <summary>
        ''' 被这个调控因子所调控的基因，按照操纵子进行分组，这个适用于推断Regulon的
        ''' </summary>
        ''' <returns></returns>
        <XmlArray> Public Property operons As Operon()
        <XmlElement> Public Property Regulates As RegulatedGene()

        <XmlNamespaceDeclarations()>
        Public xmlns As New XmlSerializerNamespaces

        Sub New()
            xmlns.Add("model", MotifFasta.xmlns)
        End Sub

        ''' <summary>
        ''' 该Regprecise调控因子的基因号
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LocusId As String Implements IReadOnlyId.Identity
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return locus_tag.name
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("[{0}] {1}", type.ToString, regulator.ToString)
        End Function

        Public Function GetMotifSite(GeneId As String, MotifPosition As Integer) As Regtransbase.WebServices.MotifFasta
            Dim LQuery = (From fa As Regtransbase.WebServices.MotifFasta In regulatorySites
                          Where String.Equals(GeneId, fa.locus_tag) AndAlso
                              fa.position = MotifPosition
                          Select fa).FirstOrDefault
            Return LQuery
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="trace">locus_tag:position</param>
        ''' <returns></returns>
        Public Function GetMotifSite(trace As String) As Regtransbase.WebServices.MotifFasta
            Dim Tokens As String() = trace.Split(":"c)
            Return GetMotifSite(Tokens(Scan0), CInt(Val(Tokens(1))))
        End Function

        ''' <summary>
        ''' 这个函数会自动移除一些表示NNNN的特殊符号
        ''' </summary>
        ''' <returns></returns>
        Public Function ExportMotifs() As FASTA.FastaSeq()
            Dim LQuery As FASTA.FastaSeq() =
                LinqAPI.Exec(Of FASTA.FastaSeq) <=
                    From FastaObject As Regtransbase.WebServices.MotifFasta
                    In regulatorySites
                    Let t As String = $"[gene={FastaObject.locus_tag}:{FastaObject.position}] [family={family}] [regulog={regulog.name}]"
                    Let attrs = New String() {t}
                    Let seq As String = Regtransbase.WebServices.Regulator.SequenceTrimming(FastaObject)
                    Let fa As FASTA.FastaSeq =
                        New FASTA.FastaSeq With {
                            .SequenceData = seq,
                            .Headers = attrs
                        }
                    Select fa
            Return LQuery
        End Function
    End Class
End Namespace