REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:51


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace kb_UniProtKB.mysql

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `tissue_locations`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `tissue_locations` (
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) DEFAULT NULL,
'''   `name` varchar(45) DEFAULT NULL,
'''   `tissue_id` int(10) unsigned NOT NULL,
'''   `tissue_name` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`hash_code`,`tissue_id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("tissue_locations", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `tissue_locations` (
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `tissue_id` int(10) unsigned NOT NULL,
  `tissue_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`hash_code`,`tissue_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class tissue_locations: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("hash_code"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code"), XmlAttribute> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="name")> Public Property name As String
    <DatabaseField("tissue_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="tissue_id"), XmlAttribute> Public Property tissue_id As Long
    <DatabaseField("tissue_name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="tissue_name")> Public Property tissue_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `tissue_locations` (`hash_code`, `uniprot_id`, `name`, `tissue_id`, `tissue_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `tissue_locations` (`hash_code`, `uniprot_id`, `name`, `tissue_id`, `tissue_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `tissue_locations` (`hash_code`, `uniprot_id`, `name`, `tissue_id`, `tissue_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `tissue_locations` (`hash_code`, `uniprot_id`, `name`, `tissue_id`, `tissue_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `tissue_locations` WHERE `hash_code`='{0}' and `tissue_id`='{1}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `tissue_locations` SET `hash_code`='{0}', `uniprot_id`='{1}', `name`='{2}', `tissue_id`='{3}', `tissue_name`='{4}' WHERE `hash_code`='{5}' and `tissue_id`='{6}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `tissue_locations` WHERE `hash_code`='{0}' and `tissue_id`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, hash_code, tissue_id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `tissue_locations` (`hash_code`, `uniprot_id`, `name`, `tissue_id`, `tissue_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, name, tissue_id, tissue_name)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `tissue_locations` (`hash_code`, `uniprot_id`, `name`, `tissue_id`, `tissue_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, hash_code, uniprot_id, name, tissue_id, tissue_name)
        Else
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, name, tissue_id, tissue_name)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{hash_code}', '{uniprot_id}', '{name}', '{tissue_id}', '{tissue_name}')"
        Else
            Return $"('{hash_code}', '{uniprot_id}', '{name}', '{tissue_id}', '{tissue_name}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `tissue_locations` (`hash_code`, `uniprot_id`, `name`, `tissue_id`, `tissue_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, name, tissue_id, tissue_name)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `tissue_locations` (`hash_code`, `uniprot_id`, `name`, `tissue_id`, `tissue_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, hash_code, uniprot_id, name, tissue_id, tissue_name)
        Else
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, name, tissue_id, tissue_name)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `tissue_locations` SET `hash_code`='{0}', `uniprot_id`='{1}', `name`='{2}', `tissue_id`='{3}', `tissue_name`='{4}' WHERE `hash_code`='{5}' and `tissue_id`='{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, hash_code, uniprot_id, name, tissue_id, tissue_name, hash_code, tissue_id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As tissue_locations
                         Return DirectCast(MyClass.MemberwiseClone, tissue_locations)
                     End Function
End Class


End Namespace
