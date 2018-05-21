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
''' DROP TABLE IF EXISTS `regulon_tmp`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `regulon_tmp` (
'''   `regulon_id` char(12) NOT NULL,
'''   `regulon_name` varchar(500) NOT NULL,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("regulon_tmp", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `regulon_tmp` (
  `regulon_id` char(12) NOT NULL,
  `regulon_name` varchar(500) NOT NULL,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class regulon_tmp: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("regulon_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="regulon_id")> Public Property regulon_id As String
    <DatabaseField("regulon_name"), NotNull, DataType(MySqlDbType.VarChar, "500"), Column(Name:="regulon_name")> Public Property regulon_name As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5"), Column(Name:="key_id_org")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `regulon_tmp` (`regulon_id`, `regulon_name`, `key_id_org`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `regulon_tmp` (`regulon_id`, `regulon_name`, `key_id_org`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `regulon_tmp` (`regulon_id`, `regulon_name`, `key_id_org`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `regulon_tmp` (`regulon_id`, `regulon_name`, `key_id_org`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `regulon_tmp` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `regulon_tmp` SET `regulon_id`='{0}', `regulon_name`='{1}', `key_id_org`='{2}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `regulon_tmp` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `regulon_tmp` (`regulon_id`, `regulon_name`, `key_id_org`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, regulon_id, regulon_name, key_id_org)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `regulon_tmp` (`regulon_id`, `regulon_name`, `key_id_org`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, regulon_id, regulon_name, key_id_org)
        Else
        Return String.Format(INSERT_SQL, regulon_id, regulon_name, key_id_org)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{regulon_id}', '{regulon_name}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `regulon_tmp` (`regulon_id`, `regulon_name`, `key_id_org`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, regulon_id, regulon_name, key_id_org)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `regulon_tmp` (`regulon_id`, `regulon_name`, `key_id_org`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, regulon_id, regulon_name, key_id_org)
        Else
        Return String.Format(REPLACE_SQL, regulon_id, regulon_name, key_id_org)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `regulon_tmp` SET `regulon_id`='{0}', `regulon_name`='{1}', `key_id_org`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As regulon_tmp
                         Return DirectCast(MyClass.MemberwiseClone, regulon_tmp)
                     End Function
End Class


End Namespace
