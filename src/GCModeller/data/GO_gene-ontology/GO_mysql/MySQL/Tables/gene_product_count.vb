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
''' DROP TABLE IF EXISTS `gene_product_count`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `gene_product_count` (
'''   `term_id` int(11) NOT NULL,
'''   `code` varchar(8) DEFAULT NULL,
'''   `speciesdbname` varchar(55) DEFAULT NULL,
'''   `species_id` int(11) DEFAULT NULL,
'''   `product_count` int(11) NOT NULL,
'''   KEY `species_id` (`species_id`),
'''   KEY `gpc1` (`term_id`),
'''   KEY `gpc2` (`code`),
'''   KEY `gpc3` (`speciesdbname`),
'''   KEY `gpc4` (`term_id`,`code`,`speciesdbname`),
'''   KEY `gpc5` (`term_id`,`species_id`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("gene_product_count", Database:="go", SchemaSQL:="
CREATE TABLE `gene_product_count` (
  `term_id` int(11) NOT NULL,
  `code` varchar(8) DEFAULT NULL,
  `speciesdbname` varchar(55) DEFAULT NULL,
  `species_id` int(11) DEFAULT NULL,
  `product_count` int(11) NOT NULL,
  KEY `species_id` (`species_id`),
  KEY `gpc1` (`term_id`),
  KEY `gpc2` (`code`),
  KEY `gpc3` (`speciesdbname`),
  KEY `gpc4` (`term_id`,`code`,`speciesdbname`),
  KEY `gpc5` (`term_id`,`species_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class gene_product_count: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("term_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property term_id As Long
    <DatabaseField("code"), DataType(MySqlDbType.VarChar, "8")> Public Property code As String
    <DatabaseField("speciesdbname"), DataType(MySqlDbType.VarChar, "55")> Public Property speciesdbname As String
    <DatabaseField("species_id"), PrimaryKey, DataType(MySqlDbType.Int64, "11")> Public Property species_id As Long
    <DatabaseField("product_count"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property product_count As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `gene_product_count` (`term_id`, `code`, `speciesdbname`, `species_id`, `product_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `gene_product_count` (`term_id`, `code`, `speciesdbname`, `species_id`, `product_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `gene_product_count` WHERE `species_id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `gene_product_count` SET `term_id`='{0}', `code`='{1}', `speciesdbname`='{2}', `species_id`='{3}', `product_count`='{4}' WHERE `species_id` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `gene_product_count` WHERE `species_id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, species_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `gene_product_count` (`term_id`, `code`, `speciesdbname`, `species_id`, `product_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, term_id, code, speciesdbname, species_id, product_count)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{term_id}', '{code}', '{speciesdbname}', '{species_id}', '{product_count}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `gene_product_count` (`term_id`, `code`, `speciesdbname`, `species_id`, `product_count`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, term_id, code, speciesdbname, species_id, product_count)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `gene_product_count` SET `term_id`='{0}', `code`='{1}', `speciesdbname`='{2}', `species_id`='{3}', `product_count`='{4}' WHERE `species_id` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, term_id, code, speciesdbname, species_id, product_count, species_id)
    End Function
#End Region
End Class


End Namespace
