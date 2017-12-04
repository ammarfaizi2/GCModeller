﻿#Region "Microsoft.VisualBasic::88983bada103b891065981bb14358f2e, ..\R.Bioconductor\RDotNET.Extensions.GCModeller\test\Module1.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Imports SMRUCC.genomics.Assembly.KEGG.WebServices
Imports Microsoft.VisualBasic.Language.UnixBash
Imports RDotNET.Extensions.GCModeller
Imports SMRUCC.genomics.Assembly.KEGG.Medical

Module Module1

    Sub Main()

        ' Call MapDownloader.Downloads("./KEGGMaps/")
        Dim drugMaps = DrugParser _
            .ParseStream("D:\smartnucl_integrative\DATA\KEGG\medicus\drug\drug") _
            .BuildDrugCompoundMaps(DrugParser.LoadDrugGroup("D:\smartnucl_integrative\DATA\KEGG\medicus\dgroup\dgroup"))

        Call (ls - l - r - "*.XML" <= "D:\smartnucl_integrative\biodeepDB\protocols\biodeepMSMS1\biodeepMSMS\data\KEGGMaps") _
            .Select(AddressOf LoadXml(Of Map)) _
            .SaveRda(drugMaps, "./KEGG.rda")
    End Sub
End Module

