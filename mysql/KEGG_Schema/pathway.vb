REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 10:06:32 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL

''' <summary>
''' ```SQL
''' 代谢途径概览表
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `pathway`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `pathway` (
'''   `entry_id` varchar(45) NOT NULL,
'''   `name` longtext,
'''   `definition` longtext,
'''   `class` text,
'''   `category` text,
'''   PRIMARY KEY (`entry_id`),
'''   UNIQUE KEY `entry_id_UNIQUE` (`entry_id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='代谢途径概览表';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("pathway", Database:="jp_kegg2", SchemaSQL:="
CREATE TABLE `pathway` (
  `entry_id` varchar(45) NOT NULL,
  `name` longtext,
  `definition` longtext,
  `class` text,
  `category` text,
  PRIMARY KEY (`entry_id`),
  UNIQUE KEY `entry_id_UNIQUE` (`entry_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='代谢途径概览表';")>
Public Class pathway: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry_id"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "45")> Public Property entry_id As String
    <DatabaseField("name"), DataType(MySqlDbType.Text)> Public Property name As String
    <DatabaseField("definition"), DataType(MySqlDbType.Text)> Public Property definition As String
    <DatabaseField("class"), DataType(MySqlDbType.Text)> Public Property [class] As String
    <DatabaseField("category"), DataType(MySqlDbType.Text)> Public Property category As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `pathway` (`entry_id`, `name`, `definition`, `class`, `category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `pathway` (`entry_id`, `name`, `definition`, `class`, `category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `pathway` WHERE `entry_id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `pathway` SET `entry_id`='{0}', `name`='{1}', `definition`='{2}', `class`='{3}', `category`='{4}' WHERE `entry_id` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `pathway` WHERE `entry_id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `pathway` (`entry_id`, `name`, `definition`, `class`, `category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry_id, name, definition, [class], category)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry_id}', '{name}', '{definition}', '{[class]}', '{category}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `pathway` (`entry_id`, `name`, `definition`, `class`, `category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry_id, name, definition, [class], category)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `pathway` SET `entry_id`='{0}', `name`='{1}', `definition`='{2}', `class`='{3}', `category`='{4}' WHERE `entry_id` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry_id, name, definition, [class], category, entry_id)
    End Function
#End Region
End Class


End Namespace
