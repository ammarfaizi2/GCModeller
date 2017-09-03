REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2017/9/3 10:58:21


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports System.Xml.Serialization

Namespace kb_UniProtKB.mysql

''' <summary>
''' ```SQL
''' 对这个蛋白质的文献报道数据
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protein_reference`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_reference` (
'''   `uid` int(10) unsigned NOT NULL AUTO_INCREMENT,
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) DEFAULT NULL,
'''   `reference_id` int(10) unsigned NOT NULL,
'''   `literature_title` mediumtext,
'''   PRIMARY KEY (`uid`),
'''   UNIQUE KEY `uid_UNIQUE` (`uid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='对这个蛋白质的文献报道数据';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_reference", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `protein_reference` (
  `uid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) DEFAULT NULL,
  `reference_id` int(10) unsigned NOT NULL,
  `literature_title` mediumtext,
  PRIMARY KEY (`uid`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='对这个蛋白质的文献报道数据';")>
Public Class protein_reference: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("uid"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="uid"), XmlAttribute> Public Property uid As Long
    <DatabaseField("hash_code"), NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code")> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("reference_id"), NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="reference_id")> Public Property reference_id As Long
    <DatabaseField("literature_title"), DataType(MySqlDbType.Text), Column(Name:="literature_title")> Public Property literature_title As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protein_reference` (`uid`, `hash_code`, `uniprot_id`, `reference_id`, `literature_title`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protein_reference` (`uid`, `hash_code`, `uniprot_id`, `reference_id`, `literature_title`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protein_reference` WHERE `uid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protein_reference` SET `uid`='{0}', `hash_code`='{1}', `uniprot_id`='{2}', `reference_id`='{3}', `literature_title`='{4}' WHERE `uid` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protein_reference` WHERE `uid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, uid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protein_reference` (`uid`, `hash_code`, `uniprot_id`, `reference_id`, `literature_title`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, uid, hash_code, uniprot_id, reference_id, literature_title)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{uid}', '{hash_code}', '{uniprot_id}', '{reference_id}', '{literature_title}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_reference` (`uid`, `hash_code`, `uniprot_id`, `reference_id`, `literature_title`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, uid, hash_code, uniprot_id, reference_id, literature_title)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protein_reference` SET `uid`='{0}', `hash_code`='{1}', `uniprot_id`='{2}', `reference_id`='{3}', `literature_title`='{4}' WHERE `uid` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, uid, hash_code, uniprot_id, reference_id, literature_title, uid)
    End Function
#End Region
Public Function Clone() As protein_reference
                  Return DirectCast(MyClass.MemberwiseClone, protein_reference)
              End Function
End Class


End Namespace
