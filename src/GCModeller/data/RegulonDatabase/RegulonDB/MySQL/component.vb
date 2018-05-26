REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:36


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
''' DROP TABLE IF EXISTS `component`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `component` (
'''   `component_id` char(12) NOT NULL,
'''   `component_name` varchar(255) NOT NULL,
'''   `component_type` varchar(250) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("component", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `component` (
  `component_id` char(12) NOT NULL,
  `component_name` varchar(255) NOT NULL,
  `component_type` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class component: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("component_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="component_id")> Public Property component_id As String
    <DatabaseField("component_name"), NotNull, DataType(MySqlDbType.VarChar, "255"), Column(Name:="component_name")> Public Property component_name As String
    <DatabaseField("component_type"), NotNull, DataType(MySqlDbType.VarChar, "250"), Column(Name:="component_type")> Public Property component_type As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `component` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `component` SET `component_id`='{0}', `component_name`='{1}', `component_type`='{2}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `component` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, component_id, component_name, component_type)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, component_id, component_name, component_type)
        Else
        Return String.Format(INSERT_SQL, component_id, component_name, component_type)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{component_id}', '{component_name}', '{component_type}')"
        Else
            Return $"('{component_id}', '{component_name}', '{component_type}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, component_id, component_name, component_type)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `component` (`component_id`, `component_name`, `component_type`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, component_id, component_name, component_type)
        Else
        Return String.Format(REPLACE_SQL, component_id, component_name, component_type)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `component` SET `component_id`='{0}', `component_name`='{1}', `component_type`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As component
                         Return DirectCast(MyClass.MemberwiseClone, component)
                     End Function
End Class


End Namespace
