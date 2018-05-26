REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:37


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `journal`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `journal` (
'''   `issn` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `abbrev` varchar(60) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `uppercase` varchar(60) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `start_date` datetime DEFAULT NULL,
'''   `end_date` datetime DEFAULT NULL,
'''   PRIMARY KEY (`issn`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("journal", Database:="interpro", SchemaSQL:="
CREATE TABLE `journal` (
  `issn` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `abbrev` varchar(60) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `uppercase` varchar(60) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `start_date` datetime DEFAULT NULL,
  `end_date` datetime DEFAULT NULL,
  PRIMARY KEY (`issn`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class journal: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("issn"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9"), Column(Name:="issn"), XmlAttribute> Public Property issn As String
    <DatabaseField("abbrev"), NotNull, DataType(MySqlDbType.VarChar, "60"), Column(Name:="abbrev")> Public Property abbrev As String
    <DatabaseField("uppercase"), DataType(MySqlDbType.VarChar, "60"), Column(Name:="uppercase")> Public Property uppercase As String
    <DatabaseField("start_date"), DataType(MySqlDbType.DateTime), Column(Name:="start_date")> Public Property start_date As Date
    <DatabaseField("end_date"), DataType(MySqlDbType.DateTime), Column(Name:="end_date")> Public Property end_date As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `journal` (`issn`, `abbrev`, `uppercase`, `start_date`, `end_date`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `journal` (`issn`, `abbrev`, `uppercase`, `start_date`, `end_date`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `journal` (`issn`, `abbrev`, `uppercase`, `start_date`, `end_date`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `journal` (`issn`, `abbrev`, `uppercase`, `start_date`, `end_date`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `journal` WHERE `issn` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `journal` SET `issn`='{0}', `abbrev`='{1}', `uppercase`='{2}', `start_date`='{3}', `end_date`='{4}' WHERE `issn` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `journal` WHERE `issn` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, issn)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `journal` (`issn`, `abbrev`, `uppercase`, `start_date`, `end_date`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, issn, abbrev, uppercase, MySqlScript.ToMySqlDateTimeString(start_date), MySqlScript.ToMySqlDateTimeString(end_date))
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `journal` (`issn`, `abbrev`, `uppercase`, `start_date`, `end_date`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, issn, abbrev, uppercase, MySqlScript.ToMySqlDateTimeString(start_date), MySqlScript.ToMySqlDateTimeString(end_date))
        Else
        Return String.Format(INSERT_SQL, issn, abbrev, uppercase, MySqlScript.ToMySqlDateTimeString(start_date), MySqlScript.ToMySqlDateTimeString(end_date))
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{issn}', '{abbrev}', '{uppercase}', '{start_date}', '{end_date}')"
        Else
            Return $"('{issn}', '{abbrev}', '{uppercase}', '{start_date}', '{end_date}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `journal` (`issn`, `abbrev`, `uppercase`, `start_date`, `end_date`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, issn, abbrev, uppercase, MySqlScript.ToMySqlDateTimeString(start_date), MySqlScript.ToMySqlDateTimeString(end_date))
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `journal` (`issn`, `abbrev`, `uppercase`, `start_date`, `end_date`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, issn, abbrev, uppercase, MySqlScript.ToMySqlDateTimeString(start_date), MySqlScript.ToMySqlDateTimeString(end_date))
        Else
        Return String.Format(REPLACE_SQL, issn, abbrev, uppercase, MySqlScript.ToMySqlDateTimeString(start_date), MySqlScript.ToMySqlDateTimeString(end_date))
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `journal` SET `issn`='{0}', `abbrev`='{1}', `uppercase`='{2}', `start_date`='{3}', `end_date`='{4}' WHERE `issn` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, issn, abbrev, uppercase, MySqlScript.ToMySqlDateTimeString(start_date), MySqlScript.ToMySqlDateTimeString(end_date), issn)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As journal
                         Return DirectCast(MyClass.MemberwiseClone, journal)
                     End Function
End Class


End Namespace
