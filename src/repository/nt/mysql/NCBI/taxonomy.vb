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
''' DROP TABLE IF EXISTS `taxonomy`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `taxonomy` (
'''   `taxid` int(11) NOT NULL,
'''   `name` varchar(64) DEFAULT NULL,
'''   `rank` int(11) DEFAULT NULL,
'''   `parent` int(11) NOT NULL,
'''   `childs` mediumtext,
'''   PRIMARY KEY (`taxid`),
'''   UNIQUE KEY `taxid_UNIQUE` (`taxid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' /*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
''' 
''' /*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
''' /*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
''' /*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
''' /*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
''' /*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
''' /*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
''' /*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
''' 
''' -- Dump completed on 2016-10-04 20:02:09
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("taxonomy", Database:="ncbi", SchemaSQL:="
CREATE TABLE `taxonomy` (
  `taxid` int(11) NOT NULL,
  `name` varchar(64) DEFAULT NULL,
  `rank` int(11) DEFAULT NULL,
  `parent` int(11) NOT NULL,
  `childs` mediumtext,
  PRIMARY KEY (`taxid`),
  UNIQUE KEY `taxid_UNIQUE` (`taxid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class taxonomy: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("taxid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="taxid"), XmlAttribute> Public Property taxid As Long
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="name")> Public Property name As String
    <DatabaseField("rank"), DataType(MySqlDbType.Int64, "11"), Column(Name:="rank")> Public Property rank As Long
    <DatabaseField("parent"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="parent")> Public Property parent As Long
    <DatabaseField("childs"), DataType(MySqlDbType.Text), Column(Name:="childs")> Public Property childs As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `taxonomy` (`taxid`, `name`, `rank`, `parent`, `childs`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `taxonomy` (`taxid`, `name`, `rank`, `parent`, `childs`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `taxonomy` (`taxid`, `name`, `rank`, `parent`, `childs`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `taxonomy` (`taxid`, `name`, `rank`, `parent`, `childs`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `taxonomy` WHERE `taxid` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `taxonomy` SET `taxid`='{0}', `name`='{1}', `rank`='{2}', `parent`='{3}', `childs`='{4}' WHERE `taxid` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `taxonomy` WHERE `taxid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, taxid)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `taxonomy` (`taxid`, `name`, `rank`, `parent`, `childs`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, taxid, name, rank, parent, childs)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `taxonomy` (`taxid`, `name`, `rank`, `parent`, `childs`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, taxid, name, rank, parent, childs)
        Else
        Return String.Format(INSERT_SQL, taxid, name, rank, parent, childs)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{taxid}', '{name}', '{rank}', '{parent}', '{childs}')"
        Else
            Return $"('{taxid}', '{name}', '{rank}', '{parent}', '{childs}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `taxonomy` (`taxid`, `name`, `rank`, `parent`, `childs`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, taxid, name, rank, parent, childs)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `taxonomy` (`taxid`, `name`, `rank`, `parent`, `childs`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, taxid, name, rank, parent, childs)
        Else
        Return String.Format(REPLACE_SQL, taxid, name, rank, parent, childs)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `taxonomy` SET `taxid`='{0}', `name`='{1}', `rank`='{2}', `parent`='{3}', `childs`='{4}' WHERE `taxid` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, taxid, name, rank, parent, childs, taxid)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As taxonomy
                         Return DirectCast(MyClass.MemberwiseClone, taxonomy)
                     End Function
End Class


End Namespace
