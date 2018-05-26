REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:35


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace mysql.NCBI

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `gi2taxid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `gi2taxid` (
'''   `gi` int(11) NOT NULL,
'''   `taxid` int(11) NOT NULL,
'''   PRIMARY KEY (`gi`,`taxid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("gi2taxid", Database:="ncbi", SchemaSQL:="
CREATE TABLE `gi2taxid` (
  `gi` int(11) NOT NULL,
  `taxid` int(11) NOT NULL,
  PRIMARY KEY (`gi`,`taxid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class gi2taxid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("gi"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="gi"), XmlAttribute> Public Property gi As Long
    <DatabaseField("taxid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="taxid"), XmlAttribute> Public Property taxid As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `gi2taxid` (`gi`, `taxid`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `gi2taxid` (`gi`, `taxid`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `gi2taxid` (`gi`, `taxid`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `gi2taxid` (`gi`, `taxid`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `gi2taxid` WHERE `gi`='{0}' and `taxid`='{1}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `gi2taxid` SET `gi`='{0}', `taxid`='{1}' WHERE `gi`='{2}' and `taxid`='{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `gi2taxid` WHERE `gi`='{0}' and `taxid`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, gi, taxid)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `gi2taxid` (`gi`, `taxid`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, gi, taxid)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `gi2taxid` (`gi`, `taxid`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, gi, taxid)
        Else
        Return String.Format(INSERT_SQL, gi, taxid)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{gi}', '{taxid}')"
        Else
            Return $"('{gi}', '{taxid}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `gi2taxid` (`gi`, `taxid`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, gi, taxid)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `gi2taxid` (`gi`, `taxid`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, gi, taxid)
        Else
        Return String.Format(REPLACE_SQL, gi, taxid)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `gi2taxid` SET `gi`='{0}', `taxid`='{1}' WHERE `gi`='{2}' and `taxid`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, gi, taxid, gi, taxid)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As gi2taxid
                         Return DirectCast(MyClass.MemberwiseClone, gi2taxid)
                     End Function
End Class


End Namespace
