﻿Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Extensions
Imports Microsoft.VisualBasic
Imports LANS.SystemsBiology.GCModeller.ModellingEngine.Assembly.DocumentFormat.GCMarkupLanguage.Extensions
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel
Imports LANS.SystemsBiology.GCModeller.Framework.Kernel_Driver.LDM
Imports LANS.SystemsBiology.Assembly.SBML.FLuxBalanceModel
Imports LANS.SystemsBiology.GCModeller.ModellingEngine.Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.ComponentModels
Imports LANS.SystemsBiology.GCModeller.ModellingEngine.Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.SignalTransductions
Imports LANS.SystemsBiology.GCModeller.ModellingEngine.Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Metabolism
Imports LANS.SystemsBiology.GCModeller.ModellingEngine.Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Bacterial_GENOME
Imports System.Text

''' <summary>
''' LansSystemsBiologyModel, this model file contains all of the required data for the GCModeller virtual cell simulation.
''' (细菌细胞的计算模型文件，在本模型文件之中包含了所有的GCModeller进行模拟计算所需要的信息)
''' </summary>
''' <remarks>
''' 一次基本的计算包括下面的步骤：
''' 1. FBA模型求解代谢物的浓度分布
''' 2. 根据代谢物的浓度分布计算出每一个基因的表达水平（转录水平）
''' 3. 根据调控关系计算出每一种酶分子和调控因子的浓度分布
''' 4. 下一个迭代循环直到到达最终的结束时间(RUN 命令行)
''' </remarks>
''' 
<[Namespace]("gcmodeller_gcml")>
<XmlRoot("LANS_SystemsBiology_BacterialModel", Namespace:="http://code.google.com/p/genome-in-code/virtualcell_model/GCMarkupLanguage")>
Public Class BacterialModel : Inherits ModelBaseType
    Implements I_FBAC2(Of CompoundSpeciesReference)
    Implements ISaveHandle
    'Implements ISaveHandle

    '   Public Property Proteins As Elements.Protein()

    ''' <summary>
    ''' 形成蛋白质复合物的规则：信号转导网络
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ProteinAssemblies As List(Of ProteinAssembly)
    Public Property RibosomeAssembly As List(Of ProteinAssembly)
    Public Property RNAPolymerase As List(Of ProteinAssembly)
    Public Property Polypeptides As Polypeptide()

    Public Property BacteriaGenome As BacterialGenome = New BacterialGenome
    Public Property CultivationMediums As CultivationMediums

    <XmlElement("MetabolismSystem", Namespace:="http://code.google.com/p/genome-in-code/virtualcell_model/GCMarkupLanguage/metabolism_system")>
    Public Property Metabolism As Metabolism

    ''' <summary>
    ''' 仅包含有两个元素：多肽链分子和RNA分子的降解反应
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DispositionModels As DispositionReactant()
    Public Property SignalTransductionPathway As SignalTransductionNetwork
    Public Property TransmembraneTransportation As List(Of TransportationReaction)

    ''' <summary>
    ''' 一些关键的系统保留变量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SystemVariables As KeyValuePair()

    Public Overrides Function ToString() As String
        Return FilePath
    End Function

    Public Overrides Function Save(Optional FilePath As String = "", Optional Encoding As Encoding = Nothing) As Boolean Implements ISaveHandle.Save
        If String.IsNullOrEmpty(FilePath) Then
            FilePath = Me.FilePath
        End If

        Return Me.GetXml.SaveTo(FilePath, Encoding)
    End Function

    ''' <summary>
    ''' Read the compiled model file that in the xml format.(读取已经编译好的保存为XML格式的模型文件)
    ''' </summary>
    ''' <param name="FilePath">Xml文件格式的计算机模型文件的文件路径</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <ExportAPI("read.xml.gcml")>
    Public Shared Function Load(FilePath As String) As BacterialModel
        Dim Model As BacterialModel = FilePath.LoadXml(Of BacterialModel)()
        Model.FilePath = FilePath
        Return Model
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Input">The input compiled xml model.</param>
    ''' <param name="Output">The output html file.</param>
    ''' <param name="Style">The xldt style file.</param>
    ''' <remarks></remarks>
    Public Shared Sub Visualizing(Input As String, Output As String, Style As String)
        Dim Xslt As System.Xml.Xsl.XslCompiledTransform = New System.Xml.Xsl.XslCompiledTransform

        Try
            Call Xslt.Load(Style)
            Call Xslt.Transform(Input, Output)
        Catch ex As Exception
            Call FileIO.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "/Error.log", ex.ToString, append:=False)
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' n reactions
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Height As Integer Implements I_FBAC2(Of CompoundSpeciesReference).Height
        Get
            Return Me.Metabolism.MetabolismNetwork.Count
        End Get
    End Property

    ''' <summary>
    ''' m metabolites
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Width As Integer Implements LANS.SystemsBiology.Assembly.SBML.FLuxBalanceModel.I_FBAC2(Of GCMarkupLanguage.GCML_Documents.ComponentModels.CompoundSpeciesReference).Width
        Get
            Return Me.Metabolism.Metabolites.Count
        End Get
    End Property

    Public ReadOnly Property IFBAC2MetabolismNetwork As IEnumerable(Of LANS.SystemsBiology.Assembly.SBML.FLuxBalanceModel.I_ReactionModel(Of GCML_Documents.ComponentModels.CompoundSpeciesReference)) Implements LANS.SystemsBiology.Assembly.SBML.FLuxBalanceModel.I_FBAC2(Of GCMarkupLanguage.GCML_Documents.ComponentModels.CompoundSpeciesReference).MetabolismNetwork
        Get
            Return Me.Metabolism.MetabolismNetwork
        End Get
    End Property

    Public ReadOnly Property IFBAC2Metabolites As IEnumerable(Of LANS.SystemsBiology.Assembly.SBML.FLuxBalanceModel.IMetabolite) Implements LANS.SystemsBiology.Assembly.SBML.FLuxBalanceModel.I_FBAC2(Of GCMarkupLanguage.GCML_Documents.ComponentModels.CompoundSpeciesReference).Metabolites
        Get
            Return Me.Metabolism.Metabolites
        End Get
    End Property

    Public Overloads Sub Copy(ByRef e As BacterialModel)
        e.Metabolism.Compartments = Me.Metabolism.Compartments
        e.FilePath = Me.FilePath
        e.BacteriaGenome.Genes = Me.BacteriaGenome.Genes
        e.Metabolism.MetabolismEnzymes = Me.Metabolism.MetabolismEnzymes
        e.Metabolism.MetabolismNetwork = Me.Metabolism.MetabolismNetwork
        e.Metabolism.Metabolites = Me.Metabolism.Metabolites
        e.ModelProperty = Me.ModelProperty
        e.Metabolism.Pathways = Me.Metabolism.Pathways
    End Sub
End Class