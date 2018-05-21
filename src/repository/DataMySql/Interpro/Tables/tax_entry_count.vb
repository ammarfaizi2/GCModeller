REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:10


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `tax_entry_count`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `tax_entry_count` (
'''   `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `tax_name` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `count` int(5) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("tax_entry_count", Database:="interpro", SchemaSQL:="
CREATE TABLE `tax_entry_count` (
  `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `tax_name` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `count` int(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class tax_entry_count: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry_ac"), DataType(MySqlDbType.VarChar, "9"), Column(Name:="entry_ac")> Public Property entry_ac As String
    <DatabaseField("tax_name"), DataType(MySqlDbType.VarChar, "30"), Column(Name:="tax_name")> Public Property tax_name As String
    <DatabaseField("count"), DataType(MySqlDbType.Int64, "5"), Column(Name:="count")> Public Property count As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `tax_entry_count` (`entry_ac`, `tax_name`, `count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `tax_entry_count` (`entry_ac`, `tax_name`, `count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `tax_entry_count` (`entry_ac`, `tax_name`, `count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `tax_entry_count` (`entry_ac`, `tax_name`, `count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `tax_entry_count` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `tax_entry_count` SET `entry_ac`='{0}', `tax_name`='{1}', `count`='{2}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `tax_entry_count` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `tax_entry_count` (`entry_ac`, `tax_name`, `count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry_ac, tax_name, count)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `tax_entry_count` (`entry_ac`, `tax_name`, `count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, entry_ac, tax_name, count)
        Else
        Return String.Format(INSERT_SQL, entry_ac, tax_name, count)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry_ac}', '{tax_name}', '{count}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `tax_entry_count` (`entry_ac`, `tax_name`, `count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry_ac, tax_name, count)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `tax_entry_count` (`entry_ac`, `tax_name`, `count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, entry_ac, tax_name, count)
        Else
        Return String.Format(REPLACE_SQL, entry_ac, tax_name, count)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `tax_entry_count` SET `entry_ac`='{0}', `tax_name`='{1}', `count`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As tax_entry_count
                         Return DirectCast(MyClass.MemberwiseClone, tax_entry_count)
                     End Function
End Class


End Namespace
