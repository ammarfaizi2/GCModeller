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
''' DROP TABLE IF EXISTS `gene_product_subset`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `gene_product_subset` (
'''   `gene_product_id` int(11) NOT NULL,
'''   `subset_id` int(11) NOT NULL,
'''   UNIQUE KEY `gps3` (`gene_product_id`,`subset_id`),
'''   KEY `gps1` (`gene_product_id`),
'''   KEY `gps2` (`subset_id`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("gene_product_subset", Database:="go", SchemaSQL:="
CREATE TABLE `gene_product_subset` (
  `gene_product_id` int(11) NOT NULL,
  `subset_id` int(11) NOT NULL,
  UNIQUE KEY `gps3` (`gene_product_id`,`subset_id`),
  KEY `gps1` (`gene_product_id`),
  KEY `gps2` (`subset_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class gene_product_subset: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("gene_product_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property gene_product_id As Long
    <DatabaseField("subset_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property subset_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `gene_product_subset` (`gene_product_id`, `subset_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `gene_product_subset` (`gene_product_id`, `subset_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `gene_product_subset` WHERE `gene_product_id`='{0}' and `subset_id`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `gene_product_subset` SET `gene_product_id`='{0}', `subset_id`='{1}' WHERE `gene_product_id`='{2}' and `subset_id`='{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `gene_product_subset` WHERE `gene_product_id`='{0}' and `subset_id`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, gene_product_id, subset_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `gene_product_subset` (`gene_product_id`, `subset_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, gene_product_id, subset_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{gene_product_id}', '{subset_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `gene_product_subset` (`gene_product_id`, `subset_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, gene_product_id, subset_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `gene_product_subset` SET `gene_product_id`='{0}', `subset_id`='{1}' WHERE `gene_product_id`='{2}' and `subset_id`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, gene_product_id, subset_id, gene_product_id, subset_id)
    End Function
#End Region
End Class


End Namespace
