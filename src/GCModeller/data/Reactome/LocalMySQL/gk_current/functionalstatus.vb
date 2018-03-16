﻿#Region "Microsoft.VisualBasic::4249e07a05aab2f345a4d8383d140293, data\Reactome\LocalMySQL\gk_current\functionalstatus.vb"

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

    ' Class functionalstatus
    ' 
    '     Properties: DB_ID, functionalStatusType, functionalStatusType_class, structuralVariant, structuralVariant_class
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
''' DROP TABLE IF EXISTS `functionalstatus`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `functionalstatus` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `functionalStatusType` int(10) unsigned DEFAULT NULL,
'''   `functionalStatusType_class` varchar(64) DEFAULT NULL,
'''   `structuralVariant` int(10) unsigned DEFAULT NULL,
'''   `structuralVariant_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `functionalStatusType` (`functionalStatusType`),
'''   KEY `structuralVariant` (`structuralVariant`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("functionalstatus", Database:="gk_current", SchemaSQL:="
CREATE TABLE `functionalstatus` (
  `DB_ID` int(10) unsigned NOT NULL,
  `functionalStatusType` int(10) unsigned DEFAULT NULL,
  `functionalStatusType_class` varchar(64) DEFAULT NULL,
  `structuralVariant` int(10) unsigned DEFAULT NULL,
  `structuralVariant_class` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `functionalStatusType` (`functionalStatusType`),
  KEY `structuralVariant` (`structuralVariant`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class functionalstatus: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("functionalStatusType"), DataType(MySqlDbType.Int64, "10"), Column(Name:="functionalStatusType")> Public Property functionalStatusType As Long
    <DatabaseField("functionalStatusType_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="functionalStatusType_class")> Public Property functionalStatusType_class As String
    <DatabaseField("structuralVariant"), DataType(MySqlDbType.Int64, "10"), Column(Name:="structuralVariant")> Public Property structuralVariant As Long
    <DatabaseField("structuralVariant_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="structuralVariant_class")> Public Property structuralVariant_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `functionalstatus` (`DB_ID`, `functionalStatusType`, `functionalStatusType_class`, `structuralVariant`, `structuralVariant_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `functionalstatus` (`DB_ID`, `functionalStatusType`, `functionalStatusType_class`, `structuralVariant`, `structuralVariant_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `functionalstatus` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `functionalstatus` SET `DB_ID`='{0}', `functionalStatusType`='{1}', `functionalStatusType_class`='{2}', `structuralVariant`='{3}', `structuralVariant_class`='{4}' WHERE `DB_ID` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `functionalstatus` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `functionalstatus` (`DB_ID`, `functionalStatusType`, `functionalStatusType_class`, `structuralVariant`, `structuralVariant_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, functionalStatusType, functionalStatusType_class, structuralVariant, structuralVariant_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{functionalStatusType}', '{functionalStatusType_class}', '{structuralVariant}', '{structuralVariant_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `functionalstatus` (`DB_ID`, `functionalStatusType`, `functionalStatusType_class`, `structuralVariant`, `structuralVariant_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, functionalStatusType, functionalStatusType_class, structuralVariant, structuralVariant_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `functionalstatus` SET `DB_ID`='{0}', `functionalStatusType`='{1}', `functionalStatusType_class`='{2}', `structuralVariant`='{3}', `structuralVariant_class`='{4}' WHERE `DB_ID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, functionalStatusType, functionalStatusType_class, structuralVariant, structuralVariant_class, DB_ID)
    End Function
#End Region
Public Function Clone() As functionalstatus
                  Return DirectCast(MyClass.MemberwiseClone, functionalstatus)
              End Function
End Class


End Namespace

