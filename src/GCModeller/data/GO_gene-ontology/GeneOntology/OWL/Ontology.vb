﻿#Region "Microsoft.VisualBasic::29b7ca83865856b60ad9f92e502ea6ea, data\GO_gene-ontology\GeneOntology\OWL\Ontology.vb"

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

    ' Class Ontology
    ' 
    '     Properties: [date], hasOBOFormatVersion, versionIRI
    ' 
    ' Class hasOBOFormatVersion
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.MIME.application.rdf_xml
Imports SMRUCC.genomics.Model.Biopax

Public Class Ontology : Inherits OwlOntology
    Public Property [date] As EntityProperties.date
    Public Property hasOBOFormatVersion As hasOBOFormatVersion
    <XmlElement("auto-generated-by")> Public Property autoGeneratedBy As RDFProperty
    <XmlElement("saved-by")> Public Property SavedBy As RDFProperty
    <XmlElement("default-namespace")> Public Property DefaultNamespace As RDFProperty
    Public Property versionIRI As RDFProperty
End Class

Public Class hasOBOFormatVersion : Inherits EntityProperty

End Class
