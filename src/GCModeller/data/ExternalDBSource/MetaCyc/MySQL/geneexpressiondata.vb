﻿#Region "Microsoft.VisualBasic::fcf826d71e777f7c68aa46a6e324b43b, data\ExternalDBSource\MetaCyc\MySQL\geneexpressiondata.vb"

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

    ' Class geneexpressiondata
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:56 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `geneexpressiondata`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `geneexpressiondata` (
'''   `B` smallint(6) NOT NULL,
'''   `D` smallint(6) NOT NULL,
'''   `Q` smallint(6) NOT NULL,
'''   `Value` varchar(100) NOT NULL,
'''   `BioAssayValuesWID` bigint(20) NOT NULL,
'''   KEY `FK_GEDBAV` (`BioAssayValuesWID`),
'''   CONSTRAINT `FK_GEDBAV` FOREIGN KEY (`BioAssayValuesWID`) REFERENCES `biodatavalues` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("geneexpressiondata", Database:="warehouse", SchemaSQL:="
CREATE TABLE `geneexpressiondata` (
  `B` smallint(6) NOT NULL,
  `D` smallint(6) NOT NULL,
  `Q` smallint(6) NOT NULL,
  `Value` varchar(100) NOT NULL,
  `BioAssayValuesWID` bigint(20) NOT NULL,
  KEY `FK_GEDBAV` (`BioAssayValuesWID`),
  CONSTRAINT `FK_GEDBAV` FOREIGN KEY (`BioAssayValuesWID`) REFERENCES `biodatavalues` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class geneexpressiondata: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("B"), NotNull, DataType(MySqlDbType.Int64, "6")> Public Property B As Long
    <DatabaseField("D"), NotNull, DataType(MySqlDbType.Int64, "6")> Public Property D As Long
    <DatabaseField("Q"), NotNull, DataType(MySqlDbType.Int64, "6")> Public Property Q As Long
    <DatabaseField("Value"), NotNull, DataType(MySqlDbType.VarChar, "100")> Public Property Value As String
    <DatabaseField("BioAssayValuesWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioAssayValuesWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `geneexpressiondata` (`B`, `D`, `Q`, `Value`, `BioAssayValuesWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `geneexpressiondata` (`B`, `D`, `Q`, `Value`, `BioAssayValuesWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `geneexpressiondata` WHERE `BioAssayValuesWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `geneexpressiondata` SET `B`='{0}', `D`='{1}', `Q`='{2}', `Value`='{3}', `BioAssayValuesWID`='{4}' WHERE `BioAssayValuesWID` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `geneexpressiondata` WHERE `BioAssayValuesWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, BioAssayValuesWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `geneexpressiondata` (`B`, `D`, `Q`, `Value`, `BioAssayValuesWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, B, D, Q, Value, BioAssayValuesWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{B}', '{D}', '{Q}', '{Value}', '{BioAssayValuesWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `geneexpressiondata` (`B`, `D`, `Q`, `Value`, `BioAssayValuesWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, B, D, Q, Value, BioAssayValuesWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `geneexpressiondata` SET `B`='{0}', `D`='{1}', `Q`='{2}', `Value`='{3}', `BioAssayValuesWID`='{4}' WHERE `BioAssayValuesWID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, B, D, Q, Value, BioAssayValuesWID, BioAssayValuesWID)
    End Function
#End Region
End Class


End Namespace
