﻿#Region "Microsoft.VisualBasic::804d2bbd8b5b8f68c2dbf279c7b0f4ec, data\RegulonDatabase\Regtransbase\MySQL\regulator2effectors.vb"

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

    ' Class regulator2effectors
    ' 
    '     Properties: effector_guid, regulator_guid
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:17 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `regulator2effectors`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `regulator2effectors` (
'''   `regulator_guid` int(10) unsigned NOT NULL DEFAULT '0',
'''   `effector_guid` int(10) unsigned NOT NULL DEFAULT '0',
'''   PRIMARY KEY (`regulator_guid`,`effector_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("regulator2effectors", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `regulator2effectors` (
  `regulator_guid` int(10) unsigned NOT NULL DEFAULT '0',
  `effector_guid` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`regulator_guid`,`effector_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class regulator2effectors: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("regulator_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="regulator_guid"), XmlAttribute> Public Property regulator_guid As Long
    <DatabaseField("effector_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="effector_guid"), XmlAttribute> Public Property effector_guid As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `regulator2effectors` (`regulator_guid`, `effector_guid`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `regulator2effectors` (`regulator_guid`, `effector_guid`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `regulator2effectors` WHERE `regulator_guid`='{0}' and `effector_guid`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `regulator2effectors` SET `regulator_guid`='{0}', `effector_guid`='{1}' WHERE `regulator_guid`='{2}' and `effector_guid`='{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `regulator2effectors` WHERE `regulator_guid`='{0}' and `effector_guid`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, regulator_guid, effector_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `regulator2effectors` (`regulator_guid`, `effector_guid`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, regulator_guid, effector_guid)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{regulator_guid}', '{effector_guid}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `regulator2effectors` (`regulator_guid`, `effector_guid`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, regulator_guid, effector_guid)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `regulator2effectors` SET `regulator_guid`='{0}', `effector_guid`='{1}' WHERE `regulator_guid`='{2}' and `effector_guid`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, regulator_guid, effector_guid, regulator_guid, effector_guid)
    End Function
#End Region
Public Function Clone() As regulator2effectors
                  Return DirectCast(MyClass.MemberwiseClone, regulator2effectors)
              End Function
End Class


End Namespace

