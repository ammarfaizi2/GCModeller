REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:38


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
''' DROP TABLE IF EXISTS `dict_exp_technique_types`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dict_exp_technique_types` (
'''   `exp_technique_type_guid` int(11) NOT NULL DEFAULT '0',
'''   `name` varchar(100) DEFAULT NULL,
'''   `exp_technique_type_superclass_guid` int(10) unsigned DEFAULT NULL,
'''   PRIMARY KEY (`exp_technique_type_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dict_exp_technique_types", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `dict_exp_technique_types` (
  `exp_technique_type_guid` int(11) NOT NULL DEFAULT '0',
  `name` varchar(100) DEFAULT NULL,
  `exp_technique_type_superclass_guid` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`exp_technique_type_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class dict_exp_technique_types: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("exp_technique_type_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="exp_technique_type_guid"), XmlAttribute> Public Property exp_technique_type_guid As Long
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="name")> Public Property name As String
    <DatabaseField("exp_technique_type_superclass_guid"), DataType(MySqlDbType.Int64, "10"), Column(Name:="exp_technique_type_superclass_guid")> Public Property exp_technique_type_superclass_guid As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `dict_exp_technique_types` WHERE `exp_technique_type_guid` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `dict_exp_technique_types` SET `exp_technique_type_guid`='{0}', `name`='{1}', `exp_technique_type_superclass_guid`='{2}' WHERE `exp_technique_type_guid` = '{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `dict_exp_technique_types` WHERE `exp_technique_type_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, exp_technique_type_guid)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, exp_technique_type_guid, name, exp_technique_type_superclass_guid)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, exp_technique_type_guid, name, exp_technique_type_superclass_guid)
        Else
        Return String.Format(INSERT_SQL, exp_technique_type_guid, name, exp_technique_type_superclass_guid)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{exp_technique_type_guid}', '{name}', '{exp_technique_type_superclass_guid}')"
        Else
            Return $"('{exp_technique_type_guid}', '{name}', '{exp_technique_type_superclass_guid}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, exp_technique_type_guid, name, exp_technique_type_superclass_guid)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `dict_exp_technique_types` (`exp_technique_type_guid`, `name`, `exp_technique_type_superclass_guid`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, exp_technique_type_guid, name, exp_technique_type_superclass_guid)
        Else
        Return String.Format(REPLACE_SQL, exp_technique_type_guid, name, exp_technique_type_superclass_guid)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `dict_exp_technique_types` SET `exp_technique_type_guid`='{0}', `name`='{1}', `exp_technique_type_superclass_guid`='{2}' WHERE `exp_technique_type_guid` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, exp_technique_type_guid, name, exp_technique_type_superclass_guid, exp_technique_type_guid)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As dict_exp_technique_types
                         Return DirectCast(MyClass.MemberwiseClone, dict_exp_technique_types)
                     End Function
End Class


End Namespace
