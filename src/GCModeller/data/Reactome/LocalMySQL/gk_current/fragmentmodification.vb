﻿#Region "Microsoft.VisualBasic::f13bfd7e35a69fb3b6ac818fceda88b1, ..\GCModeller\data\Reactome\LocalMySQL\gk_current\fragmentmodification.vb"

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

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:27 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `fragmentmodification`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `fragmentmodification` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `endPositionInReferenceSequence` int(10) DEFAULT NULL,
'''   `startPositionInReferenceSequence` int(10) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `endPositionInReferenceSequence` (`endPositionInReferenceSequence`),
'''   KEY `startPositionInReferenceSequence` (`startPositionInReferenceSequence`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("fragmentmodification", Database:="gk_current", SchemaSQL:="
CREATE TABLE `fragmentmodification` (
  `DB_ID` int(10) unsigned NOT NULL,
  `endPositionInReferenceSequence` int(10) DEFAULT NULL,
  `startPositionInReferenceSequence` int(10) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `endPositionInReferenceSequence` (`endPositionInReferenceSequence`),
  KEY `startPositionInReferenceSequence` (`startPositionInReferenceSequence`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class fragmentmodification: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("endPositionInReferenceSequence"), DataType(MySqlDbType.Int64, "10")> Public Property endPositionInReferenceSequence As Long
    <DatabaseField("startPositionInReferenceSequence"), DataType(MySqlDbType.Int64, "10")> Public Property startPositionInReferenceSequence As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `fragmentmodification` (`DB_ID`, `endPositionInReferenceSequence`, `startPositionInReferenceSequence`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `fragmentmodification` (`DB_ID`, `endPositionInReferenceSequence`, `startPositionInReferenceSequence`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `fragmentmodification` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `fragmentmodification` SET `DB_ID`='{0}', `endPositionInReferenceSequence`='{1}', `startPositionInReferenceSequence`='{2}' WHERE `DB_ID` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `fragmentmodification` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `fragmentmodification` (`DB_ID`, `endPositionInReferenceSequence`, `startPositionInReferenceSequence`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, endPositionInReferenceSequence, startPositionInReferenceSequence)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{endPositionInReferenceSequence}', '{startPositionInReferenceSequence}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `fragmentmodification` (`DB_ID`, `endPositionInReferenceSequence`, `startPositionInReferenceSequence`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, endPositionInReferenceSequence, startPositionInReferenceSequence)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `fragmentmodification` SET `DB_ID`='{0}', `endPositionInReferenceSequence`='{1}', `startPositionInReferenceSequence`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, endPositionInReferenceSequence, startPositionInReferenceSequence, DB_ID)
    End Function
#End Region
End Class


End Namespace

