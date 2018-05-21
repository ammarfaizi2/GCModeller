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
''' DROP TABLE IF EXISTS `go_biologicalprocess`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `go_biologicalprocess` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `accession` text,
'''   `definition` text,
'''   `referenceDatabase` int(10) unsigned DEFAULT NULL,
'''   `referenceDatabase_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `referenceDatabase` (`referenceDatabase`),
'''   FULLTEXT KEY `accession` (`accession`),
'''   FULLTEXT KEY `definition` (`definition`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("go_biologicalprocess", Database:="gk_current", SchemaSQL:="
CREATE TABLE `go_biologicalprocess` (
  `DB_ID` int(10) unsigned NOT NULL,
  `accession` text,
  `definition` text,
  `referenceDatabase` int(10) unsigned DEFAULT NULL,
  `referenceDatabase_class` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `referenceDatabase` (`referenceDatabase`),
  FULLTEXT KEY `accession` (`accession`),
  FULLTEXT KEY `definition` (`definition`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class go_biologicalprocess: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("accession"), DataType(MySqlDbType.Text), Column(Name:="accession")> Public Property accession As String
    <DatabaseField("definition"), DataType(MySqlDbType.Text), Column(Name:="definition")> Public Property definition As String
    <DatabaseField("referenceDatabase"), DataType(MySqlDbType.Int64, "10"), Column(Name:="referenceDatabase")> Public Property referenceDatabase As Long
    <DatabaseField("referenceDatabase_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="referenceDatabase_class")> Public Property referenceDatabase_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `go_biologicalprocess` (`DB_ID`, `accession`, `definition`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `go_biologicalprocess` (`DB_ID`, `accession`, `definition`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `go_biologicalprocess` (`DB_ID`, `accession`, `definition`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `go_biologicalprocess` (`DB_ID`, `accession`, `definition`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `go_biologicalprocess` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `go_biologicalprocess` SET `DB_ID`='{0}', `accession`='{1}', `definition`='{2}', `referenceDatabase`='{3}', `referenceDatabase_class`='{4}' WHERE `DB_ID` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `go_biologicalprocess` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `go_biologicalprocess` (`DB_ID`, `accession`, `definition`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, accession, definition, referenceDatabase, referenceDatabase_class)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `go_biologicalprocess` (`DB_ID`, `accession`, `definition`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, accession, definition, referenceDatabase, referenceDatabase_class)
        Else
        Return String.Format(INSERT_SQL, DB_ID, accession, definition, referenceDatabase, referenceDatabase_class)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{accession}', '{definition}', '{referenceDatabase}', '{referenceDatabase_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `go_biologicalprocess` (`DB_ID`, `accession`, `definition`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, accession, definition, referenceDatabase, referenceDatabase_class)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `go_biologicalprocess` (`DB_ID`, `accession`, `definition`, `referenceDatabase`, `referenceDatabase_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, accession, definition, referenceDatabase, referenceDatabase_class)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, accession, definition, referenceDatabase, referenceDatabase_class)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `go_biologicalprocess` SET `DB_ID`='{0}', `accession`='{1}', `definition`='{2}', `referenceDatabase`='{3}', `referenceDatabase_class`='{4}' WHERE `DB_ID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, accession, definition, referenceDatabase, referenceDatabase_class, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As go_biologicalprocess
                         Return DirectCast(MyClass.MemberwiseClone, go_biologicalprocess)
                     End Function
End Class


End Namespace
