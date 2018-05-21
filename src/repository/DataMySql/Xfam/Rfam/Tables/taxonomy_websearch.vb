REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:07


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Xfam.Rfam.MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `taxonomy_websearch`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `taxonomy_websearch` (
'''   `ncbi_id` int(10) unsigned DEFAULT '0',
'''   `species` varchar(100) DEFAULT NULL,
'''   `taxonomy` mediumtext,
'''   `lft` int(10) DEFAULT NULL,
'''   `rgt` int(10) DEFAULT NULL,
'''   `parent` int(10) unsigned DEFAULT NULL,
'''   `level` varchar(200) DEFAULT NULL,
'''   `minimal` tinyint(1) NOT NULL DEFAULT '0',
'''   `rank` varchar(100) DEFAULT NULL,
'''   KEY `taxonomy_lft_idx` (`lft`),
'''   KEY `taxonomy_rgt_idx` (`rgt`),
'''   KEY `taxonomy_level_text_idx` (`level`),
'''   KEY `taxonomy_species_text_idx` (`species`),
'''   KEY `minimal_idx` (`minimal`),
'''   KEY `parent` (`parent`),
'''   KEY `ncbi_id_idx` (`ncbi_id`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("taxonomy_websearch", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `taxonomy_websearch` (
  `ncbi_id` int(10) unsigned DEFAULT '0',
  `species` varchar(100) DEFAULT NULL,
  `taxonomy` mediumtext,
  `lft` int(10) DEFAULT NULL,
  `rgt` int(10) DEFAULT NULL,
  `parent` int(10) unsigned DEFAULT NULL,
  `level` varchar(200) DEFAULT NULL,
  `minimal` tinyint(1) NOT NULL DEFAULT '0',
  `rank` varchar(100) DEFAULT NULL,
  KEY `taxonomy_lft_idx` (`lft`),
  KEY `taxonomy_rgt_idx` (`rgt`),
  KEY `taxonomy_level_text_idx` (`level`),
  KEY `taxonomy_species_text_idx` (`species`),
  KEY `minimal_idx` (`minimal`),
  KEY `parent` (`parent`),
  KEY `ncbi_id_idx` (`ncbi_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class taxonomy_websearch: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ncbi_id"), DataType(MySqlDbType.Int64, "10"), Column(Name:="ncbi_id")> Public Property ncbi_id As Long
    <DatabaseField("species"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="species")> Public Property species As String
    <DatabaseField("taxonomy"), DataType(MySqlDbType.Text), Column(Name:="taxonomy")> Public Property taxonomy As String
    <DatabaseField("lft"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="lft"), XmlAttribute> Public Property lft As Long
    <DatabaseField("rgt"), DataType(MySqlDbType.Int64, "10"), Column(Name:="rgt")> Public Property rgt As Long
    <DatabaseField("parent"), DataType(MySqlDbType.Int64, "10"), Column(Name:="parent")> Public Property parent As Long
    <DatabaseField("level"), DataType(MySqlDbType.VarChar, "200"), Column(Name:="level")> Public Property level As String
    <DatabaseField("minimal"), NotNull, DataType(MySqlDbType.Boolean, "1"), Column(Name:="minimal")> Public Property minimal As Boolean
    <DatabaseField("rank"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="rank")> Public Property rank As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `taxonomy_websearch` (`ncbi_id`, `species`, `taxonomy`, `lft`, `rgt`, `parent`, `level`, `minimal`, `rank`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `taxonomy_websearch` (`ncbi_id`, `species`, `taxonomy`, `lft`, `rgt`, `parent`, `level`, `minimal`, `rank`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `taxonomy_websearch` (`ncbi_id`, `species`, `taxonomy`, `lft`, `rgt`, `parent`, `level`, `minimal`, `rank`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `taxonomy_websearch` (`ncbi_id`, `species`, `taxonomy`, `lft`, `rgt`, `parent`, `level`, `minimal`, `rank`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `taxonomy_websearch` WHERE `lft` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `taxonomy_websearch` SET `ncbi_id`='{0}', `species`='{1}', `taxonomy`='{2}', `lft`='{3}', `rgt`='{4}', `parent`='{5}', `level`='{6}', `minimal`='{7}', `rank`='{8}' WHERE `lft` = '{9}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `taxonomy_websearch` WHERE `lft` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, lft)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `taxonomy_websearch` (`ncbi_id`, `species`, `taxonomy`, `lft`, `rgt`, `parent`, `level`, `minimal`, `rank`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ncbi_id, species, taxonomy, lft, rgt, parent, level, minimal, rank)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `taxonomy_websearch` (`ncbi_id`, `species`, `taxonomy`, `lft`, `rgt`, `parent`, `level`, `minimal`, `rank`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, ncbi_id, species, taxonomy, lft, rgt, parent, level, minimal, rank)
        Else
        Return String.Format(INSERT_SQL, ncbi_id, species, taxonomy, lft, rgt, parent, level, minimal, rank)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ncbi_id}', '{species}', '{taxonomy}', '{lft}', '{rgt}', '{parent}', '{level}', '{minimal}', '{rank}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `taxonomy_websearch` (`ncbi_id`, `species`, `taxonomy`, `lft`, `rgt`, `parent`, `level`, `minimal`, `rank`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ncbi_id, species, taxonomy, lft, rgt, parent, level, minimal, rank)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `taxonomy_websearch` (`ncbi_id`, `species`, `taxonomy`, `lft`, `rgt`, `parent`, `level`, `minimal`, `rank`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, ncbi_id, species, taxonomy, lft, rgt, parent, level, minimal, rank)
        Else
        Return String.Format(REPLACE_SQL, ncbi_id, species, taxonomy, lft, rgt, parent, level, minimal, rank)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `taxonomy_websearch` SET `ncbi_id`='{0}', `species`='{1}', `taxonomy`='{2}', `lft`='{3}', `rgt`='{4}', `parent`='{5}', `level`='{6}', `minimal`='{7}', `rank`='{8}' WHERE `lft` = '{9}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ncbi_id, species, taxonomy, lft, rgt, parent, level, minimal, rank, lft)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As taxonomy_websearch
                         Return DirectCast(MyClass.MemberwiseClone, taxonomy_websearch)
                     End Function
End Class


End Namespace
