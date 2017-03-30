REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:59 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `term_audit`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `term_audit` (
'''   `term_id` int(11) NOT NULL,
'''   `term_loadtime` int(11) DEFAULT NULL,
'''   UNIQUE KEY `term_id` (`term_id`),
'''   KEY `ta1` (`term_id`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("term_audit", Database:="go", SchemaSQL:="
CREATE TABLE `term_audit` (
  `term_id` int(11) NOT NULL,
  `term_loadtime` int(11) DEFAULT NULL,
  UNIQUE KEY `term_id` (`term_id`),
  KEY `ta1` (`term_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class term_audit: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("term_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property term_id As Long
    <DatabaseField("term_loadtime"), DataType(MySqlDbType.Int64, "11")> Public Property term_loadtime As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `term_audit` (`term_id`, `term_loadtime`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `term_audit` (`term_id`, `term_loadtime`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `term_audit` WHERE `term_id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `term_audit` SET `term_id`='{0}', `term_loadtime`='{1}' WHERE `term_id` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `term_audit` WHERE `term_id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, term_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `term_audit` (`term_id`, `term_loadtime`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, term_id, term_loadtime)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{term_id}', '{term_loadtime}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `term_audit` (`term_id`, `term_loadtime`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, term_id, term_loadtime)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `term_audit` SET `term_id`='{0}', `term_loadtime`='{1}' WHERE `term_id` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, term_id, term_loadtime, term_id)
    End Function
#End Region
End Class


End Namespace
