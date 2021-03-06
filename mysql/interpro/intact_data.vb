REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:52 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `intact_data`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `intact_data` (
'''   `uniprot_id` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `protein_ac` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `undetermined` char(1) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `intact_id` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `interacts_with` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `type` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `entry_ac` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `pubmed_id` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   PRIMARY KEY (`entry_ac`,`intact_id`,`interacts_with`,`protein_ac`),
'''   CONSTRAINT `fk_intact_data$entry_ac` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("intact_data", Database:="interpro", SchemaSQL:="
CREATE TABLE `intact_data` (
  `uniprot_id` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `protein_ac` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `undetermined` char(1) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `intact_id` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `interacts_with` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `type` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `entry_ac` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `pubmed_id` varchar(30) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  PRIMARY KEY (`entry_ac`,`intact_id`,`interacts_with`,`protein_ac`),
  CONSTRAINT `fk_intact_data$entry_ac` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class intact_data: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("uniprot_id"), NotNull, DataType(MySqlDbType.VarChar, "20")> Public Property uniprot_id As String
    <DatabaseField("protein_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "30")> Public Property protein_ac As String
    <DatabaseField("undetermined"), DataType(MySqlDbType.VarChar, "1")> Public Property undetermined As String
    <DatabaseField("intact_id"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "30")> Public Property intact_id As String
    <DatabaseField("interacts_with"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "30")> Public Property interacts_with As String
    <DatabaseField("type"), DataType(MySqlDbType.VarChar, "20")> Public Property type As String
    <DatabaseField("entry_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "30")> Public Property entry_ac As String
    <DatabaseField("pubmed_id"), DataType(MySqlDbType.VarChar, "30")> Public Property pubmed_id As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `intact_data` (`uniprot_id`, `protein_ac`, `undetermined`, `intact_id`, `interacts_with`, `type`, `entry_ac`, `pubmed_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `intact_data` (`uniprot_id`, `protein_ac`, `undetermined`, `intact_id`, `interacts_with`, `type`, `entry_ac`, `pubmed_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `intact_data` WHERE `entry_ac`='{0}' and `intact_id`='{1}' and `interacts_with`='{2}' and `protein_ac`='{3}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `intact_data` SET `uniprot_id`='{0}', `protein_ac`='{1}', `undetermined`='{2}', `intact_id`='{3}', `interacts_with`='{4}', `type`='{5}', `entry_ac`='{6}', `pubmed_id`='{7}' WHERE `entry_ac`='{8}' and `intact_id`='{9}' and `interacts_with`='{10}' and `protein_ac`='{11}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `intact_data` WHERE `entry_ac`='{0}' and `intact_id`='{1}' and `interacts_with`='{2}' and `protein_ac`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry_ac, intact_id, interacts_with, protein_ac)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `intact_data` (`uniprot_id`, `protein_ac`, `undetermined`, `intact_id`, `interacts_with`, `type`, `entry_ac`, `pubmed_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, uniprot_id, protein_ac, undetermined, intact_id, interacts_with, type, entry_ac, pubmed_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{uniprot_id}', '{protein_ac}', '{undetermined}', '{intact_id}', '{interacts_with}', '{type}', '{entry_ac}', '{pubmed_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `intact_data` (`uniprot_id`, `protein_ac`, `undetermined`, `intact_id`, `interacts_with`, `type`, `entry_ac`, `pubmed_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, uniprot_id, protein_ac, undetermined, intact_id, interacts_with, type, entry_ac, pubmed_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `intact_data` SET `uniprot_id`='{0}', `protein_ac`='{1}', `undetermined`='{2}', `intact_id`='{3}', `interacts_with`='{4}', `type`='{5}', `entry_ac`='{6}', `pubmed_id`='{7}' WHERE `entry_ac`='{8}' and `intact_id`='{9}' and `interacts_with`='{10}' and `protein_ac`='{11}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, uniprot_id, protein_ac, undetermined, intact_id, interacts_with, type, entry_ac, pubmed_id, entry_ac, intact_id, interacts_with, protein_ac)
    End Function
#End Region
End Class


End Namespace
