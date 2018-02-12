﻿#Region "Microsoft.VisualBasic::930d37ab2324539d9707ad1d87c78e52, data\RegulonDatabase\RegulonDB\MySQL\tf_alignment.vb"

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

    ' Class tf_alignment
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:24:24 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `tf_alignment`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `tf_alignment` (
'''   `tf_alignment_id` char(12) NOT NULL,
'''   `transcription_factor_id` char(12) NOT NULL,
'''   `tf_matrix_id` char(12) DEFAULT NULL,
'''   `tf_alignment_name` varchar(255) NOT NULL,
'''   `tf_alignment_note` varchar(2000) DEFAULT NULL,
'''   `tf_alignment_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("tf_alignment", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `tf_alignment` (
  `tf_alignment_id` char(12) NOT NULL,
  `transcription_factor_id` char(12) NOT NULL,
  `tf_matrix_id` char(12) DEFAULT NULL,
  `tf_alignment_name` varchar(255) NOT NULL,
  `tf_alignment_note` varchar(2000) DEFAULT NULL,
  `tf_alignment_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class tf_alignment: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("tf_alignment_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property tf_alignment_id As String
    <DatabaseField("transcription_factor_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property transcription_factor_id As String
    <DatabaseField("tf_matrix_id"), DataType(MySqlDbType.VarChar, "12")> Public Property tf_matrix_id As String
    <DatabaseField("tf_alignment_name"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property tf_alignment_name As String
    <DatabaseField("tf_alignment_note"), DataType(MySqlDbType.VarChar, "2000")> Public Property tf_alignment_note As String
    <DatabaseField("tf_alignment_internal_comment"), DataType(MySqlDbType.Text)> Public Property tf_alignment_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `tf_alignment` (`tf_alignment_id`, `transcription_factor_id`, `tf_matrix_id`, `tf_alignment_name`, `tf_alignment_note`, `tf_alignment_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `tf_alignment` (`tf_alignment_id`, `transcription_factor_id`, `tf_matrix_id`, `tf_alignment_name`, `tf_alignment_note`, `tf_alignment_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `tf_alignment` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `tf_alignment` SET `tf_alignment_id`='{0}', `transcription_factor_id`='{1}', `tf_matrix_id`='{2}', `tf_alignment_name`='{3}', `tf_alignment_note`='{4}', `tf_alignment_internal_comment`='{5}', `key_id_org`='{6}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `tf_alignment` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `tf_alignment` (`tf_alignment_id`, `transcription_factor_id`, `tf_matrix_id`, `tf_alignment_name`, `tf_alignment_note`, `tf_alignment_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, tf_alignment_id, transcription_factor_id, tf_matrix_id, tf_alignment_name, tf_alignment_note, tf_alignment_internal_comment, key_id_org)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{tf_alignment_id}', '{transcription_factor_id}', '{tf_matrix_id}', '{tf_alignment_name}', '{tf_alignment_note}', '{tf_alignment_internal_comment}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `tf_alignment` (`tf_alignment_id`, `transcription_factor_id`, `tf_matrix_id`, `tf_alignment_name`, `tf_alignment_note`, `tf_alignment_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, tf_alignment_id, transcription_factor_id, tf_matrix_id, tf_alignment_name, tf_alignment_note, tf_alignment_internal_comment, key_id_org)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `tf_alignment` SET `tf_alignment_id`='{0}', `transcription_factor_id`='{1}', `tf_matrix_id`='{2}', `tf_alignment_name`='{3}', `tf_alignment_note`='{4}', `tf_alignment_internal_comment`='{5}', `key_id_org`='{6}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
