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
''' DROP TABLE IF EXISTS `reaction`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reaction` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `reverseReaction` int(10) unsigned DEFAULT NULL,
'''   `reverseReaction_class` varchar(64) DEFAULT NULL,
'''   `totalProt` text,
'''   `maxHomologues` text,
'''   `inferredProt` text,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `reverseReaction` (`reverseReaction`),
'''   FULLTEXT KEY `totalProt` (`totalProt`),
'''   FULLTEXT KEY `maxHomologues` (`maxHomologues`),
'''   FULLTEXT KEY `inferredProt` (`inferredProt`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reaction", Database:="gk_current", SchemaSQL:="
CREATE TABLE `reaction` (
  `DB_ID` int(10) unsigned NOT NULL,
  `reverseReaction` int(10) unsigned DEFAULT NULL,
  `reverseReaction_class` varchar(64) DEFAULT NULL,
  `totalProt` text,
  `maxHomologues` text,
  `inferredProt` text,
  PRIMARY KEY (`DB_ID`),
  KEY `reverseReaction` (`reverseReaction`),
  FULLTEXT KEY `totalProt` (`totalProt`),
  FULLTEXT KEY `maxHomologues` (`maxHomologues`),
  FULLTEXT KEY `inferredProt` (`inferredProt`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class reaction: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("reverseReaction"), DataType(MySqlDbType.Int64, "10"), Column(Name:="reverseReaction")> Public Property reverseReaction As Long
    <DatabaseField("reverseReaction_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="reverseReaction_class")> Public Property reverseReaction_class As String
    <DatabaseField("totalProt"), DataType(MySqlDbType.Text), Column(Name:="totalProt")> Public Property totalProt As String
    <DatabaseField("maxHomologues"), DataType(MySqlDbType.Text), Column(Name:="maxHomologues")> Public Property maxHomologues As String
    <DatabaseField("inferredProt"), DataType(MySqlDbType.Text), Column(Name:="inferredProt")> Public Property inferredProt As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `reaction` (`DB_ID`, `reverseReaction`, `reverseReaction_class`, `totalProt`, `maxHomologues`, `inferredProt`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `reaction` (`DB_ID`, `reverseReaction`, `reverseReaction_class`, `totalProt`, `maxHomologues`, `inferredProt`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `reaction` (`DB_ID`, `reverseReaction`, `reverseReaction_class`, `totalProt`, `maxHomologues`, `inferredProt`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `reaction` (`DB_ID`, `reverseReaction`, `reverseReaction_class`, `totalProt`, `maxHomologues`, `inferredProt`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `reaction` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `reaction` SET `DB_ID`='{0}', `reverseReaction`='{1}', `reverseReaction_class`='{2}', `totalProt`='{3}', `maxHomologues`='{4}', `inferredProt`='{5}' WHERE `DB_ID` = '{6}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `reaction` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `reaction` (`DB_ID`, `reverseReaction`, `reverseReaction_class`, `totalProt`, `maxHomologues`, `inferredProt`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, reverseReaction, reverseReaction_class, totalProt, maxHomologues, inferredProt)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `reaction` (`DB_ID`, `reverseReaction`, `reverseReaction_class`, `totalProt`, `maxHomologues`, `inferredProt`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, reverseReaction, reverseReaction_class, totalProt, maxHomologues, inferredProt)
        Else
        Return String.Format(INSERT_SQL, DB_ID, reverseReaction, reverseReaction_class, totalProt, maxHomologues, inferredProt)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{reverseReaction}', '{reverseReaction_class}', '{totalProt}', '{maxHomologues}', '{inferredProt}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reaction` (`DB_ID`, `reverseReaction`, `reverseReaction_class`, `totalProt`, `maxHomologues`, `inferredProt`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, reverseReaction, reverseReaction_class, totalProt, maxHomologues, inferredProt)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `reaction` (`DB_ID`, `reverseReaction`, `reverseReaction_class`, `totalProt`, `maxHomologues`, `inferredProt`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, reverseReaction, reverseReaction_class, totalProt, maxHomologues, inferredProt)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, reverseReaction, reverseReaction_class, totalProt, maxHomologues, inferredProt)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `reaction` SET `DB_ID`='{0}', `reverseReaction`='{1}', `reverseReaction_class`='{2}', `totalProt`='{3}', `maxHomologues`='{4}', `inferredProt`='{5}' WHERE `DB_ID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, reverseReaction, reverseReaction_class, totalProt, maxHomologues, inferredProt, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As reaction
                         Return DirectCast(MyClass.MemberwiseClone, reaction)
                     End Function
End Class


End Namespace
