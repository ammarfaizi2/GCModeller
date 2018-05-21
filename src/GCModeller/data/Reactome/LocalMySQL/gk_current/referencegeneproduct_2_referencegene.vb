REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:14


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `referencegeneproduct_2_referencegene`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `referencegeneproduct_2_referencegene` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `referenceGene_rank` int(10) unsigned DEFAULT NULL,
'''   `referenceGene` int(10) unsigned DEFAULT NULL,
'''   `referenceGene_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `referenceGene` (`referenceGene`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("referencegeneproduct_2_referencegene", Database:="gk_current", SchemaSQL:="
CREATE TABLE `referencegeneproduct_2_referencegene` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `referenceGene_rank` int(10) unsigned DEFAULT NULL,
  `referenceGene` int(10) unsigned DEFAULT NULL,
  `referenceGene_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `referenceGene` (`referenceGene`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class referencegeneproduct_2_referencegene: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("referenceGene_rank"), DataType(MySqlDbType.Int64, "10"), Column(Name:="referenceGene_rank")> Public Property referenceGene_rank As Long
    <DatabaseField("referenceGene"), DataType(MySqlDbType.Int64, "10"), Column(Name:="referenceGene")> Public Property referenceGene As Long
    <DatabaseField("referenceGene_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="referenceGene_class")> Public Property referenceGene_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `referencegeneproduct_2_referencegene` (`DB_ID`, `referenceGene_rank`, `referenceGene`, `referenceGene_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `referencegeneproduct_2_referencegene` (`DB_ID`, `referenceGene_rank`, `referenceGene`, `referenceGene_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `referencegeneproduct_2_referencegene` (`DB_ID`, `referenceGene_rank`, `referenceGene`, `referenceGene_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `referencegeneproduct_2_referencegene` (`DB_ID`, `referenceGene_rank`, `referenceGene`, `referenceGene_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `referencegeneproduct_2_referencegene` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `referencegeneproduct_2_referencegene` SET `DB_ID`='{0}', `referenceGene_rank`='{1}', `referenceGene`='{2}', `referenceGene_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `referencegeneproduct_2_referencegene` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `referencegeneproduct_2_referencegene` (`DB_ID`, `referenceGene_rank`, `referenceGene`, `referenceGene_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, referenceGene_rank, referenceGene, referenceGene_class)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `referencegeneproduct_2_referencegene` (`DB_ID`, `referenceGene_rank`, `referenceGene`, `referenceGene_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, referenceGene_rank, referenceGene, referenceGene_class)
        Else
        Return String.Format(INSERT_SQL, DB_ID, referenceGene_rank, referenceGene, referenceGene_class)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{referenceGene_rank}', '{referenceGene}', '{referenceGene_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `referencegeneproduct_2_referencegene` (`DB_ID`, `referenceGene_rank`, `referenceGene`, `referenceGene_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, referenceGene_rank, referenceGene, referenceGene_class)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `referencegeneproduct_2_referencegene` (`DB_ID`, `referenceGene_rank`, `referenceGene`, `referenceGene_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, referenceGene_rank, referenceGene, referenceGene_class)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, referenceGene_rank, referenceGene, referenceGene_class)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `referencegeneproduct_2_referencegene` SET `DB_ID`='{0}', `referenceGene_rank`='{1}', `referenceGene`='{2}', `referenceGene_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, referenceGene_rank, referenceGene, referenceGene_class, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As referencegeneproduct_2_referencegene
                         Return DirectCast(MyClass.MemberwiseClone, referencegeneproduct_2_referencegene)
                     End Function
End Class


End Namespace
