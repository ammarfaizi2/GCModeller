REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 10:06:32 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL

''' <summary>
''' ```SQL
''' KEGG drug data
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `drug`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `drug` (
'''   `entry` char(8) NOT NULL,
'''   `names` mediumtext,
'''   `formula` varchar(128) DEFAULT NULL,
'''   `exact_mass` double DEFAULT NULL,
'''   `mol_weight` double DEFAULT NULL,
'''   `remarks` varchar(45) DEFAULT NULL,
'''   `activity` varchar(45) DEFAULT NULL,
'''   `atoms` varchar(45) DEFAULT NULL,
'''   `bounds` varchar(45) DEFAULT NULL,
'''   `comments` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`entry`),
'''   UNIQUE KEY `entry_UNIQUE` (`entry`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='KEGG drug data';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("drug", Database:="jp_kegg2", SchemaSQL:="
CREATE TABLE `drug` (
  `entry` char(8) NOT NULL,
  `names` mediumtext,
  `formula` varchar(128) DEFAULT NULL,
  `exact_mass` double DEFAULT NULL,
  `mol_weight` double DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `activity` varchar(45) DEFAULT NULL,
  `atoms` varchar(45) DEFAULT NULL,
  `bounds` varchar(45) DEFAULT NULL,
  `comments` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`entry`),
  UNIQUE KEY `entry_UNIQUE` (`entry`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='KEGG drug data';")>
Public Class drug: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "8")> Public Property entry As String
    <DatabaseField("names"), DataType(MySqlDbType.Text)> Public Property names As String
    <DatabaseField("formula"), DataType(MySqlDbType.VarChar, "128")> Public Property formula As String
    <DatabaseField("exact_mass"), DataType(MySqlDbType.Double)> Public Property exact_mass As Double
    <DatabaseField("mol_weight"), DataType(MySqlDbType.Double)> Public Property mol_weight As Double
    <DatabaseField("remarks"), DataType(MySqlDbType.VarChar, "45")> Public Property remarks As String
    <DatabaseField("activity"), DataType(MySqlDbType.VarChar, "45")> Public Property activity As String
    <DatabaseField("atoms"), DataType(MySqlDbType.VarChar, "45")> Public Property atoms As String
    <DatabaseField("bounds"), DataType(MySqlDbType.VarChar, "45")> Public Property bounds As String
    <DatabaseField("comments"), DataType(MySqlDbType.VarChar, "45")> Public Property comments As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `drug` (`entry`, `names`, `formula`, `exact_mass`, `mol_weight`, `remarks`, `activity`, `atoms`, `bounds`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `drug` (`entry`, `names`, `formula`, `exact_mass`, `mol_weight`, `remarks`, `activity`, `atoms`, `bounds`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `drug` WHERE `entry` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `drug` SET `entry`='{0}', `names`='{1}', `formula`='{2}', `exact_mass`='{3}', `mol_weight`='{4}', `remarks`='{5}', `activity`='{6}', `atoms`='{7}', `bounds`='{8}', `comments`='{9}' WHERE `entry` = '{10}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `drug` WHERE `entry` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `drug` (`entry`, `names`, `formula`, `exact_mass`, `mol_weight`, `remarks`, `activity`, `atoms`, `bounds`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry, names, formula, exact_mass, mol_weight, remarks, activity, atoms, bounds, comments)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry}', '{names}', '{formula}', '{exact_mass}', '{mol_weight}', '{remarks}', '{activity}', '{atoms}', '{bounds}', '{comments}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `drug` (`entry`, `names`, `formula`, `exact_mass`, `mol_weight`, `remarks`, `activity`, `atoms`, `bounds`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry, names, formula, exact_mass, mol_weight, remarks, activity, atoms, bounds, comments)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `drug` SET `entry`='{0}', `names`='{1}', `formula`='{2}', `exact_mass`='{3}', `mol_weight`='{4}', `remarks`='{5}', `activity`='{6}', `atoms`='{7}', `bounds`='{8}', `comments`='{9}' WHERE `entry` = '{10}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry, names, formula, exact_mass, mol_weight, remarks, activity, atoms, bounds, comments, entry)
    End Function
#End Region
End Class


End Namespace
