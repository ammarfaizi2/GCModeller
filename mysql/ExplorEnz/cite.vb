REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:37


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace ExplorEnz.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `cite`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `cite` (
'''   `cite_key` varchar(48) NOT NULL DEFAULT '',
'''   `ec_num` varchar(12) NOT NULL DEFAULT '',
'''   `ref_num` int(11) DEFAULT NULL,
'''   `acc_no` int(11) NOT NULL AUTO_INCREMENT,
'''   `last_change` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   PRIMARY KEY (`acc_no`)
''' ) ENGINE=MyISAM AUTO_INCREMENT=47359 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("cite", Database:="enzymed", SchemaSQL:="
CREATE TABLE `cite` (
  `cite_key` varchar(48) NOT NULL DEFAULT '',
  `ec_num` varchar(12) NOT NULL DEFAULT '',
  `ref_num` int(11) DEFAULT NULL,
  `acc_no` int(11) NOT NULL AUTO_INCREMENT,
  `last_change` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`acc_no`)
) ENGINE=MyISAM AUTO_INCREMENT=47359 DEFAULT CHARSET=latin1;")>
Public Class cite: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("cite_key"), NotNull, DataType(MySqlDbType.VarChar, "48"), Column(Name:="cite_key")> Public Property cite_key As String
    <DatabaseField("ec_num"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="ec_num")> Public Property ec_num As String
    <DatabaseField("ref_num"), DataType(MySqlDbType.Int64, "11"), Column(Name:="ref_num")> Public Property ref_num As Long
    <DatabaseField("acc_no"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="acc_no"), XmlAttribute> Public Property acc_no As Long
    <DatabaseField("last_change"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="last_change")> Public Property last_change As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `cite` (`cite_key`, `ec_num`, `ref_num`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `cite` (`cite_key`, `ec_num`, `ref_num`, `acc_no`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `cite` (`cite_key`, `ec_num`, `ref_num`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `cite` (`cite_key`, `ec_num`, `ref_num`, `acc_no`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `cite` WHERE `acc_no` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `cite` SET `cite_key`='{0}', `ec_num`='{1}', `ref_num`='{2}', `acc_no`='{3}', `last_change`='{4}' WHERE `acc_no` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `cite` WHERE `acc_no` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, acc_no)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `cite` (`cite_key`, `ec_num`, `ref_num`, `acc_no`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, cite_key, ec_num, ref_num, MySqlScript.ToMySqlDateTimeString(last_change))
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `cite` (`cite_key`, `ec_num`, `ref_num`, `acc_no`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, cite_key, ec_num, ref_num, acc_no, MySqlScript.ToMySqlDateTimeString(last_change))
        Else
        Return String.Format(INSERT_SQL, cite_key, ec_num, ref_num, MySqlScript.ToMySqlDateTimeString(last_change))
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{cite_key}', '{ec_num}', '{ref_num}', '{acc_no}', '{last_change}')"
        Else
            Return $"('{cite_key}', '{ec_num}', '{ref_num}', '{last_change}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `cite` (`cite_key`, `ec_num`, `ref_num`, `acc_no`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, cite_key, ec_num, ref_num, MySqlScript.ToMySqlDateTimeString(last_change))
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `cite` (`cite_key`, `ec_num`, `ref_num`, `acc_no`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, cite_key, ec_num, ref_num, acc_no, MySqlScript.ToMySqlDateTimeString(last_change))
        Else
        Return String.Format(REPLACE_SQL, cite_key, ec_num, ref_num, MySqlScript.ToMySqlDateTimeString(last_change))
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `cite` SET `cite_key`='{0}', `ec_num`='{1}', `ref_num`='{2}', `acc_no`='{3}', `last_change`='{4}' WHERE `acc_no` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, cite_key, ec_num, ref_num, acc_no, MySqlScript.ToMySqlDateTimeString(last_change), acc_no)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As cite
                         Return DirectCast(MyClass.MemberwiseClone, cite)
                     End Function
End Class


End Namespace
