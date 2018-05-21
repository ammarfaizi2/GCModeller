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
''' DROP TABLE IF EXISTS `event`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `event` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `_doRelease` enum('TRUE','FALSE') DEFAULT NULL,
'''   `definition` text,
'''   `evidenceType` int(10) unsigned DEFAULT NULL,
'''   `evidenceType_class` varchar(64) DEFAULT NULL,
'''   `goBiologicalProcess` int(10) unsigned DEFAULT NULL,
'''   `goBiologicalProcess_class` varchar(64) DEFAULT NULL,
'''   `releaseDate` date DEFAULT NULL,
'''   `releaseStatus` text,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `_doRelease` (`_doRelease`),
'''   KEY `evidenceType` (`evidenceType`),
'''   KEY `goBiologicalProcess` (`goBiologicalProcess`),
'''   KEY `releaseDate` (`releaseDate`),
'''   FULLTEXT KEY `definition` (`definition`),
'''   FULLTEXT KEY `releaseStatus` (`releaseStatus`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("event", Database:="gk_current", SchemaSQL:="
CREATE TABLE `event` (
  `DB_ID` int(10) unsigned NOT NULL,
  `_doRelease` enum('TRUE','FALSE') DEFAULT NULL,
  `definition` text,
  `evidenceType` int(10) unsigned DEFAULT NULL,
  `evidenceType_class` varchar(64) DEFAULT NULL,
  `goBiologicalProcess` int(10) unsigned DEFAULT NULL,
  `goBiologicalProcess_class` varchar(64) DEFAULT NULL,
  `releaseDate` date DEFAULT NULL,
  `releaseStatus` text,
  PRIMARY KEY (`DB_ID`),
  KEY `_doRelease` (`_doRelease`),
  KEY `evidenceType` (`evidenceType`),
  KEY `goBiologicalProcess` (`goBiologicalProcess`),
  KEY `releaseDate` (`releaseDate`),
  FULLTEXT KEY `definition` (`definition`),
  FULLTEXT KEY `releaseStatus` (`releaseStatus`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class [event]: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("_doRelease"), DataType(MySqlDbType.String), Column(Name:="_doRelease")> Public Property _doRelease As String
    <DatabaseField("definition"), DataType(MySqlDbType.Text), Column(Name:="definition")> Public Property definition As String
    <DatabaseField("evidenceType"), DataType(MySqlDbType.Int64, "10"), Column(Name:="evidenceType")> Public Property evidenceType As Long
    <DatabaseField("evidenceType_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="evidenceType_class")> Public Property evidenceType_class As String
    <DatabaseField("goBiologicalProcess"), DataType(MySqlDbType.Int64, "10"), Column(Name:="goBiologicalProcess")> Public Property goBiologicalProcess As Long
    <DatabaseField("goBiologicalProcess_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="goBiologicalProcess_class")> Public Property goBiologicalProcess_class As String
    <DatabaseField("releaseDate"), DataType(MySqlDbType.DateTime), Column(Name:="releaseDate")> Public Property releaseDate As Date
    <DatabaseField("releaseStatus"), DataType(MySqlDbType.Text), Column(Name:="releaseStatus")> Public Property releaseStatus As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `event` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `event` SET `DB_ID`='{0}', `_doRelease`='{1}', `definition`='{2}', `evidenceType`='{3}', `evidenceType_class`='{4}', `goBiologicalProcess`='{5}', `goBiologicalProcess_class`='{6}', `releaseDate`='{7}', `releaseStatus`='{8}' WHERE `DB_ID` = '{9}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `event` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, _doRelease, definition, evidenceType, evidenceType_class, goBiologicalProcess, goBiologicalProcess_class, MySqlScript.ToMySqlDateTimeString(releaseDate), releaseStatus)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, _doRelease, definition, evidenceType, evidenceType_class, goBiologicalProcess, goBiologicalProcess_class, MySqlScript.ToMySqlDateTimeString(releaseDate), releaseStatus)
        Else
        Return String.Format(INSERT_SQL, DB_ID, _doRelease, definition, evidenceType, evidenceType_class, goBiologicalProcess, goBiologicalProcess_class, MySqlScript.ToMySqlDateTimeString(releaseDate), releaseStatus)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{_doRelease}', '{definition}', '{evidenceType}', '{evidenceType_class}', '{goBiologicalProcess}', '{goBiologicalProcess_class}', '{releaseDate}', '{releaseStatus}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, _doRelease, definition, evidenceType, evidenceType_class, goBiologicalProcess, goBiologicalProcess_class, MySqlScript.ToMySqlDateTimeString(releaseDate), releaseStatus)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, _doRelease, definition, evidenceType, evidenceType_class, goBiologicalProcess, goBiologicalProcess_class, MySqlScript.ToMySqlDateTimeString(releaseDate), releaseStatus)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, _doRelease, definition, evidenceType, evidenceType_class, goBiologicalProcess, goBiologicalProcess_class, MySqlScript.ToMySqlDateTimeString(releaseDate), releaseStatus)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `event` SET `DB_ID`='{0}', `_doRelease`='{1}', `definition`='{2}', `evidenceType`='{3}', `evidenceType_class`='{4}', `goBiologicalProcess`='{5}', `goBiologicalProcess_class`='{6}', `releaseDate`='{7}', `releaseStatus`='{8}' WHERE `DB_ID` = '{9}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, _doRelease, definition, evidenceType, evidenceType_class, goBiologicalProcess, goBiologicalProcess_class, MySqlScript.ToMySqlDateTimeString(releaseDate), releaseStatus, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As [event]
                         Return DirectCast(MyClass.MemberwiseClone, [event])
                     End Function
End Class


End Namespace
