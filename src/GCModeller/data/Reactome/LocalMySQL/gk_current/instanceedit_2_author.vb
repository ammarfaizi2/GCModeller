REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:41


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
''' DROP TABLE IF EXISTS `instanceedit_2_author`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `instanceedit_2_author` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `author_rank` int(10) unsigned DEFAULT NULL,
'''   `author` int(10) unsigned DEFAULT NULL,
'''   `author_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `author` (`author`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("instanceedit_2_author", Database:="gk_current", SchemaSQL:="
CREATE TABLE `instanceedit_2_author` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `author_rank` int(10) unsigned DEFAULT NULL,
  `author` int(10) unsigned DEFAULT NULL,
  `author_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `author` (`author`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class instanceedit_2_author: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("author_rank"), DataType(MySqlDbType.Int64, "10"), Column(Name:="author_rank")> Public Property author_rank As Long
    <DatabaseField("author"), DataType(MySqlDbType.Int64, "10"), Column(Name:="author")> Public Property author As Long
    <DatabaseField("author_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="author_class")> Public Property author_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `instanceedit_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `instanceedit_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `instanceedit_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `instanceedit_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `instanceedit_2_author` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `instanceedit_2_author` SET `DB_ID`='{0}', `author_rank`='{1}', `author`='{2}', `author_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `instanceedit_2_author` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `instanceedit_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, author_rank, author, author_class)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `instanceedit_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, author_rank, author, author_class)
        Else
        Return String.Format(INSERT_SQL, DB_ID, author_rank, author, author_class)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{DB_ID}', '{author_rank}', '{author}', '{author_class}')"
        Else
            Return $"('{DB_ID}', '{author_rank}', '{author}', '{author_class}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `instanceedit_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, author_rank, author, author_class)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `instanceedit_2_author` (`DB_ID`, `author_rank`, `author`, `author_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, author_rank, author, author_class)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, author_rank, author, author_class)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `instanceedit_2_author` SET `DB_ID`='{0}', `author_rank`='{1}', `author`='{2}', `author_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, author_rank, author, author_class, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As instanceedit_2_author
                         Return DirectCast(MyClass.MemberwiseClone, instanceedit_2_author)
                     End Function
End Class


End Namespace
