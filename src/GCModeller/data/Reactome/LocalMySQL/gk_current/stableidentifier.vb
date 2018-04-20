﻿#Region "Microsoft.VisualBasic::1b114c90c58a0d320334ce1b48235b3e, data\Reactome\LocalMySQL\gk_current\stableidentifier.vb"

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

    ' Class stableidentifier
    ' 
    '     Properties: DB_ID, identifier, identifierVersion, oldIdentifier, oldIdentifierVersion
    '                 referenceDatabase, referenceDatabase_class
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:21 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `stableidentifier`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `stableidentifier` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `identifier` text,
'''   `identifierVersion` text,
'''   `oldIdentifier` text,
'''   `oldIdentifierVersion` text,
'''   `referenceDatabase` int(10) unsigned DEFAULT NULL,
'''   `referenceDatabase_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `referenceDatabase` (`referenceDatabase`),
'''   FULLTEXT KEY `identifier` (`identifier`),
'''   FULLTEXT KEY `identifierVersion` (`identifierVersion`),
'''   FULLTEXT KEY `oldIdentifier` (`oldIdentifier`),
'''   FULLTEXT KEY `oldIdentifierVersion` (`oldIdentifierVersion`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("stableidentifier", Database:="gk_current", SchemaSQL:="
CREATE TABLE `stableidentifier` (
  `DB_ID` int(10) unsigned NOT NULL,
  `identifier` text,
  `identifierVersion` text,
  `oldIdentifier` text,
  `oldIdentifierVersion` text,
  `referenceDatabase` int(10) unsigned DEFAULT NULL,
  `referenceDatabase_class` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `referenceDatabase` (`referenceDatabase`),
  FULLTEXT KEY `identifier` (`identifier`),
  FULLTEXT KEY `identifierVersion` (`identifierVersion`),
  FULLTEXT KEY `oldIdentifier` (`oldIdentifier`),
  FULLTEXT KEY `oldIdentifierVersion` (`oldIdentifierVersion`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class stableidentifier: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("identifier"), DataType(MySqlDbType.Text), Column(Name:="identifier")> Public Property identifier As String
    <DatabaseField("identifierVersion"), DataType(MySqlDbType.Text), Column(Name:="identifierVersion")> Public Property identifierVersion As String
    <DatabaseField("oldIdentifier"), DataType(MySqlDbType.Text), Column(Name:="oldIdentifier")> Public Property oldIdentifier As String
    <DatabaseField("oldIdentifierVersion"), DataType(MySqlDbType.Text), Column(Name:="oldIdentifierVersion")> Public Property oldIdentifierVersion As String
    <DatabaseField("referenceDatabase"), DataType(MySqlDbType.Int64, "10"), Column(Name:="referenceDatabase")> Public Property referenceDatabase As Long
    <DatabaseField("referenceDatabase_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="referenceDatabase_class")> Public Property referenceDatabase_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `stableidentifier` (`DB_ID`, `identifier`, `identifierVersion`, `oldIdentifier`, `oldIdentifierVersion`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `stableidentifier` (`DB_ID`, `identifier`, `identifierVersion`, `oldIdentifier`, `oldIdentifierVersion`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `stableidentifier` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `stableidentifier` SET `DB_ID`='{0}', `identifier`='{1}', `identifierVersion`='{2}', `oldIdentifier`='{3}', `oldIdentifierVersion`='{4}', `referenceDatabase`='{5}', `referenceDatabase_class`='{6}' WHERE `DB_ID` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `stableidentifier` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `stableidentifier` (`DB_ID`, `identifier`, `identifierVersion`, `oldIdentifier`, `oldIdentifierVersion`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, identifier, identifierVersion, oldIdentifier, oldIdentifierVersion, referenceDatabase, referenceDatabase_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{identifier}', '{identifierVersion}', '{oldIdentifier}', '{oldIdentifierVersion}', '{referenceDatabase}', '{referenceDatabase_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `stableidentifier` (`DB_ID`, `identifier`, `identifierVersion`, `oldIdentifier`, `oldIdentifierVersion`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, identifier, identifierVersion, oldIdentifier, oldIdentifierVersion, referenceDatabase, referenceDatabase_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `stableidentifier` SET `DB_ID`='{0}', `identifier`='{1}', `identifierVersion`='{2}', `oldIdentifier`='{3}', `oldIdentifierVersion`='{4}', `referenceDatabase`='{5}', `referenceDatabase_class`='{6}' WHERE `DB_ID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, identifier, identifierVersion, oldIdentifier, oldIdentifierVersion, referenceDatabase, referenceDatabase_class, DB_ID)
    End Function
#End Region
Public Function Clone() As stableidentifier
                  Return DirectCast(MyClass.MemberwiseClone, stableidentifier)
              End Function
End Class


End Namespace
