﻿#Region "Microsoft.VisualBasic::a28dd34b8fb5abd37adc66d3cadc67f9, data\ExternalDBSource\MetaCyc\MySQL\imageacquisitionwidimagewid.vb"

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

    ' Class imageacquisitionwidimagewid
    ' 
    '     Properties: ImageAcquisitionWID, ImageWID
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:19 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `imageacquisitionwidimagewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `imageacquisitionwidimagewid` (
'''   `ImageAcquisitionWID` bigint(20) NOT NULL,
'''   `ImageWID` bigint(20) NOT NULL,
'''   KEY `FK_ImageAcquisitionWIDImageW1` (`ImageAcquisitionWID`),
'''   KEY `FK_ImageAcquisitionWIDImageW2` (`ImageWID`),
'''   CONSTRAINT `FK_ImageAcquisitionWIDImageW1` FOREIGN KEY (`ImageAcquisitionWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ImageAcquisitionWIDImageW2` FOREIGN KEY (`ImageWID`) REFERENCES `image` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("imageacquisitionwidimagewid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `imageacquisitionwidimagewid` (
  `ImageAcquisitionWID` bigint(20) NOT NULL,
  `ImageWID` bigint(20) NOT NULL,
  KEY `FK_ImageAcquisitionWIDImageW1` (`ImageAcquisitionWID`),
  KEY `FK_ImageAcquisitionWIDImageW2` (`ImageWID`),
  CONSTRAINT `FK_ImageAcquisitionWIDImageW1` FOREIGN KEY (`ImageAcquisitionWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ImageAcquisitionWIDImageW2` FOREIGN KEY (`ImageWID`) REFERENCES `image` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class imageacquisitionwidimagewid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ImageAcquisitionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ImageAcquisitionWID"), XmlAttribute> Public Property ImageAcquisitionWID As Long
    <DatabaseField("ImageWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ImageWID")> Public Property ImageWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `imageacquisitionwidimagewid` WHERE `ImageAcquisitionWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `imageacquisitionwidimagewid` SET `ImageAcquisitionWID`='{0}', `ImageWID`='{1}' WHERE `ImageAcquisitionWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `imageacquisitionwidimagewid` WHERE `ImageAcquisitionWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ImageAcquisitionWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ImageAcquisitionWID, ImageWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ImageAcquisitionWID}', '{ImageWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ImageAcquisitionWID, ImageWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `imageacquisitionwidimagewid` SET `ImageAcquisitionWID`='{0}', `ImageWID`='{1}' WHERE `ImageAcquisitionWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ImageAcquisitionWID, ImageWID, ImageAcquisitionWID)
    End Function
#End Region
Public Function Clone() As imageacquisitionwidimagewid
                  Return DirectCast(MyClass.MemberwiseClone, imageacquisitionwidimagewid)
              End Function
End Class


End Namespace
