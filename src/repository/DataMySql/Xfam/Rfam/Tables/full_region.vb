REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:55:32 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Xfam.Rfam.MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `full_region`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `full_region` (
'''   `rfam_acc` varchar(7) NOT NULL,
'''   `rfamseq_acc` varchar(20) NOT NULL,
'''   `seq_start` bigint(19) unsigned NOT NULL DEFAULT '0',
'''   `seq_end` bigint(19) unsigned NOT NULL,
'''   `bit_score` double(7,2) NOT NULL DEFAULT '0.00' COMMENT '99999.99 is the approx limit from Infernal.',
'''   `evalue_score` varchar(15) NOT NULL DEFAULT '0',
'''   `cm_start` mediumint(8) unsigned NOT NULL,
'''   `cm_end` mediumint(8) unsigned NOT NULL,
'''   `truncated` enum('0','5','3','53') NOT NULL,
'''   `type` enum('seed','full') NOT NULL DEFAULT 'full',
'''   `is_significant` tinyint(1) unsigned NOT NULL,
'''   KEY `full_region_sign` (`is_significant`),
'''   KEY `full_region_acc_sign` (`rfam_acc`,`is_significant`) USING BTREE,
'''   KEY `fk_full_region_rfamseq1_cascase` (`rfamseq_acc`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("full_region", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `full_region` (
  `rfam_acc` varchar(7) NOT NULL,
  `rfamseq_acc` varchar(20) NOT NULL,
  `seq_start` bigint(19) unsigned NOT NULL DEFAULT '0',
  `seq_end` bigint(19) unsigned NOT NULL,
  `bit_score` double(7,2) NOT NULL DEFAULT '0.00' COMMENT '99999.99 is the approx limit from Infernal.',
  `evalue_score` varchar(15) NOT NULL DEFAULT '0',
  `cm_start` mediumint(8) unsigned NOT NULL,
  `cm_end` mediumint(8) unsigned NOT NULL,
  `truncated` enum('0','5','3','53') NOT NULL,
  `type` enum('seed','full') NOT NULL DEFAULT 'full',
  `is_significant` tinyint(1) unsigned NOT NULL,
  KEY `full_region_sign` (`is_significant`),
  KEY `full_region_acc_sign` (`rfam_acc`,`is_significant`) USING BTREE,
  KEY `fk_full_region_rfamseq1_cascase` (`rfamseq_acc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class full_region: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("rfam_acc"), NotNull, DataType(MySqlDbType.VarChar, "7")> Public Property rfam_acc As String
    <DatabaseField("rfamseq_acc"), NotNull, DataType(MySqlDbType.VarChar, "20")> Public Property rfamseq_acc As String
    <DatabaseField("seq_start"), NotNull, DataType(MySqlDbType.Int64, "19")> Public Property seq_start As Long
    <DatabaseField("seq_end"), NotNull, DataType(MySqlDbType.Int64, "19")> Public Property seq_end As Long
''' <summary>
''' 99999.99 is the approx limit from Infernal.
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("bit_score"), NotNull, DataType(MySqlDbType.Double)> Public Property bit_score As Double
    <DatabaseField("evalue_score"), NotNull, DataType(MySqlDbType.VarChar, "15")> Public Property evalue_score As String
    <DatabaseField("cm_start"), NotNull, DataType(MySqlDbType.Int64, "8")> Public Property cm_start As Long
    <DatabaseField("cm_end"), NotNull, DataType(MySqlDbType.Int64, "8")> Public Property cm_end As Long
    <DatabaseField("truncated"), NotNull, DataType(MySqlDbType.String)> Public Property truncated As String
    <DatabaseField("type"), NotNull, DataType(MySqlDbType.String)> Public Property type As String
    <DatabaseField("is_significant"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "1")> Public Property is_significant As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `full_region` (`rfam_acc`, `rfamseq_acc`, `seq_start`, `seq_end`, `bit_score`, `evalue_score`, `cm_start`, `cm_end`, `truncated`, `type`, `is_significant`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `full_region` (`rfam_acc`, `rfamseq_acc`, `seq_start`, `seq_end`, `bit_score`, `evalue_score`, `cm_start`, `cm_end`, `truncated`, `type`, `is_significant`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `full_region` WHERE `is_significant` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `full_region` SET `rfam_acc`='{0}', `rfamseq_acc`='{1}', `seq_start`='{2}', `seq_end`='{3}', `bit_score`='{4}', `evalue_score`='{5}', `cm_start`='{6}', `cm_end`='{7}', `truncated`='{8}', `type`='{9}', `is_significant`='{10}' WHERE `is_significant` = '{11}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `full_region` WHERE `is_significant` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, is_significant)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `full_region` (`rfam_acc`, `rfamseq_acc`, `seq_start`, `seq_end`, `bit_score`, `evalue_score`, `cm_start`, `cm_end`, `truncated`, `type`, `is_significant`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, rfam_acc, rfamseq_acc, seq_start, seq_end, bit_score, evalue_score, cm_start, cm_end, truncated, type, is_significant)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{rfam_acc}', '{rfamseq_acc}', '{seq_start}', '{seq_end}', '{bit_score}', '{evalue_score}', '{cm_start}', '{cm_end}', '{truncated}', '{type}', '{is_significant}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `full_region` (`rfam_acc`, `rfamseq_acc`, `seq_start`, `seq_end`, `bit_score`, `evalue_score`, `cm_start`, `cm_end`, `truncated`, `type`, `is_significant`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, rfam_acc, rfamseq_acc, seq_start, seq_end, bit_score, evalue_score, cm_start, cm_end, truncated, type, is_significant)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `full_region` SET `rfam_acc`='{0}', `rfamseq_acc`='{1}', `seq_start`='{2}', `seq_end`='{3}', `bit_score`='{4}', `evalue_score`='{5}', `cm_start`='{6}', `cm_end`='{7}', `truncated`='{8}', `type`='{9}', `is_significant`='{10}' WHERE `is_significant` = '{11}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, rfam_acc, rfamseq_acc, seq_start, seq_end, bit_score, evalue_score, cm_start, cm_end, truncated, type, is_significant, is_significant)
    End Function
#End Region
End Class


End Namespace
