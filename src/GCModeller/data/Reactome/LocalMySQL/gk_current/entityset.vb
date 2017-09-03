REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:27 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `entityset`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `entityset` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `isOrdered` enum('TRUE','FALSE') DEFAULT NULL,
'''   `totalProt` text,
'''   `inferredProt` text,
'''   `maxHomologues` text,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `isOrdered` (`isOrdered`),
'''   FULLTEXT KEY `totalProt` (`totalProt`),
'''   FULLTEXT KEY `inferredProt` (`inferredProt`),
'''   FULLTEXT KEY `maxHomologues` (`maxHomologues`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("entityset", Database:="gk_current", SchemaSQL:="
CREATE TABLE `entityset` (
  `DB_ID` int(10) unsigned NOT NULL,
  `isOrdered` enum('TRUE','FALSE') DEFAULT NULL,
  `totalProt` text,
  `inferredProt` text,
  `maxHomologues` text,
  PRIMARY KEY (`DB_ID`),
  KEY `isOrdered` (`isOrdered`),
  FULLTEXT KEY `totalProt` (`totalProt`),
  FULLTEXT KEY `inferredProt` (`inferredProt`),
  FULLTEXT KEY `maxHomologues` (`maxHomologues`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class entityset: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("isOrdered"), DataType(MySqlDbType.String)> Public Property isOrdered As String
    <DatabaseField("totalProt"), DataType(MySqlDbType.Text)> Public Property totalProt As String
    <DatabaseField("inferredProt"), DataType(MySqlDbType.Text)> Public Property inferredProt As String
    <DatabaseField("maxHomologues"), DataType(MySqlDbType.Text)> Public Property maxHomologues As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `entityset` (`DB_ID`, `isOrdered`, `totalProt`, `inferredProt`, `maxHomologues`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `entityset` (`DB_ID`, `isOrdered`, `totalProt`, `inferredProt`, `maxHomologues`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `entityset` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `entityset` SET `DB_ID`='{0}', `isOrdered`='{1}', `totalProt`='{2}', `inferredProt`='{3}', `maxHomologues`='{4}' WHERE `DB_ID` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `entityset` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `entityset` (`DB_ID`, `isOrdered`, `totalProt`, `inferredProt`, `maxHomologues`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, isOrdered, totalProt, inferredProt, maxHomologues)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{isOrdered}', '{totalProt}', '{inferredProt}', '{maxHomologues}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `entityset` (`DB_ID`, `isOrdered`, `totalProt`, `inferredProt`, `maxHomologues`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, isOrdered, totalProt, inferredProt, maxHomologues)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `entityset` SET `DB_ID`='{0}', `isOrdered`='{1}', `totalProt`='{2}', `inferredProt`='{3}', `maxHomologues`='{4}' WHERE `DB_ID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, isOrdered, totalProt, inferredProt, maxHomologues, DB_ID)
    End Function
#End Region
End Class


End Namespace
