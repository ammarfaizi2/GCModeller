REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @2016/10/4 19:50:53


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace mysql.NCBI

''' <summary>
''' ```SQL
''' nt sequence database
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `nt`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `nt` (
'''   `gi` int(11) NOT NULL,
'''   `db` varchar(32) NOT NULL,
'''   `uid` varchar(32) NOT NULL,
'''   `description` tinytext NOT NULL,
'''   PRIMARY KEY (`gi`),
'''   UNIQUE KEY `gi_UNIQUE` (`gi`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='nt sequence database';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("nt", Database:="ncbi", SchemaSQL:="
CREATE TABLE `nt` (
  `gi` int(11) NOT NULL,
  `db` varchar(32) NOT NULL,
  `uid` varchar(32) NOT NULL,
  `description` tinytext NOT NULL,
  PRIMARY KEY (`gi`),
  UNIQUE KEY `gi_UNIQUE` (`gi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='nt sequence database';")>
Public Class nt: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("gi"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property gi As Long
    <DatabaseField("db"), NotNull, DataType(MySqlDbType.VarChar, "32")> Public Property db As String
    <DatabaseField("uid"), NotNull, DataType(MySqlDbType.VarChar, "32")> Public Property uid As String
    <DatabaseField("description"), NotNull, DataType(MySqlDbType.Text)> Public Property description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `nt` (`gi`, `db`, `uid`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `nt` (`gi`, `db`, `uid`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `nt` WHERE `gi` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `nt` SET `gi`='{0}', `db`='{1}', `uid`='{2}', `description`='{3}' WHERE `gi` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `nt` WHERE `gi` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, gi)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `nt` (`gi`, `db`, `uid`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, gi, db, uid, description)
    End Function
''' <summary>
''' ```SQL
''' REPLACE INTO `nt` (`gi`, `db`, `uid`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, gi, db, uid, description)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `nt` SET `gi`='{0}', `db`='{1}', `uid`='{2}', `description`='{3}' WHERE `gi` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, gi, db, uid, description, gi)
    End Function
#End Region
End Class


End Namespace
