REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:09


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `reaction`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reaction` (
'''   `reaction_id` char(12) NOT NULL,
'''   `reaction_name` varchar(1000) NOT NULL,
'''   `reaction_description` varchar(2000) DEFAULT NULL,
'''   `reaction_type` varchar(250) NOT NULL,
'''   `note` longtext
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reaction", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `reaction` (
  `reaction_id` char(12) NOT NULL,
  `reaction_name` varchar(1000) NOT NULL,
  `reaction_description` varchar(2000) DEFAULT NULL,
  `reaction_type` varchar(250) NOT NULL,
  `note` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class reaction: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("reaction_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="reaction_id")> Public Property reaction_id As String
    <DatabaseField("reaction_name"), NotNull, DataType(MySqlDbType.VarChar, "1000"), Column(Name:="reaction_name")> Public Property reaction_name As String
    <DatabaseField("reaction_description"), DataType(MySqlDbType.VarChar, "2000"), Column(Name:="reaction_description")> Public Property reaction_description As String
    <DatabaseField("reaction_type"), NotNull, DataType(MySqlDbType.VarChar, "250"), Column(Name:="reaction_type")> Public Property reaction_type As String
    <DatabaseField("note"), DataType(MySqlDbType.Text), Column(Name:="note")> Public Property note As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `reaction` (`reaction_id`, `reaction_name`, `reaction_description`, `reaction_type`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `reaction` (`reaction_id`, `reaction_name`, `reaction_description`, `reaction_type`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `reaction` (`reaction_id`, `reaction_name`, `reaction_description`, `reaction_type`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `reaction` (`reaction_id`, `reaction_name`, `reaction_description`, `reaction_type`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `reaction` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `reaction` SET `reaction_id`='{0}', `reaction_name`='{1}', `reaction_description`='{2}', `reaction_type`='{3}', `note`='{4}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `reaction` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `reaction` (`reaction_id`, `reaction_name`, `reaction_description`, `reaction_type`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, reaction_id, reaction_name, reaction_description, reaction_type, note)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `reaction` (`reaction_id`, `reaction_name`, `reaction_description`, `reaction_type`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, reaction_id, reaction_name, reaction_description, reaction_type, note)
        Else
        Return String.Format(INSERT_SQL, reaction_id, reaction_name, reaction_description, reaction_type, note)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{reaction_id}', '{reaction_name}', '{reaction_description}', '{reaction_type}', '{note}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reaction` (`reaction_id`, `reaction_name`, `reaction_description`, `reaction_type`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, reaction_id, reaction_name, reaction_description, reaction_type, note)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `reaction` (`reaction_id`, `reaction_name`, `reaction_description`, `reaction_type`, `note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, reaction_id, reaction_name, reaction_description, reaction_type, note)
        Else
        Return String.Format(REPLACE_SQL, reaction_id, reaction_name, reaction_description, reaction_type, note)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `reaction` SET `reaction_id`='{0}', `reaction_name`='{1}', `reaction_description`='{2}', `reaction_type`='{3}', `note`='{4}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As reaction
                         Return DirectCast(MyClass.MemberwiseClone, reaction)
                     End Function
End Class


End Namespace
