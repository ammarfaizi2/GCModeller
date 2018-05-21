REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:58:56


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace mysql

''' <summary>
''' ```SQL
''' 参考代谢途径的定义
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `data_pathway`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `data_pathway` (
'''   `uid` int(11) NOT NULL AUTO_INCREMENT,
'''   `KO` varchar(45) NOT NULL,
'''   `description` varchar(45) DEFAULT NULL,
'''   `name` varchar(45) DEFAULT NULL,
'''   `map` varchar(45) DEFAULT NULL COMMENT 'image -> gzip -> base64 string',
'''   PRIMARY KEY (`uid`),
'''   UNIQUE KEY `uid_UNIQUE` (`uid`),
'''   UNIQUE KEY `KO_UNIQUE` (`KO`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='参考代谢途径的定义';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("data_pathway", Database:="jp_kegg2", SchemaSQL:="
CREATE TABLE `data_pathway` (
  `uid` int(11) NOT NULL AUTO_INCREMENT,
  `KO` varchar(45) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `map` varchar(45) DEFAULT NULL COMMENT 'image -> gzip -> base64 string',
  PRIMARY KEY (`uid`),
  UNIQUE KEY `uid_UNIQUE` (`uid`),
  UNIQUE KEY `KO_UNIQUE` (`KO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='参考代谢途径的定义';")>
Public Class data_pathway: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("uid"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="uid"), XmlAttribute> Public Property uid As Long
    <DatabaseField("KO"), NotNull, DataType(MySqlDbType.VarChar, "45"), Column(Name:="KO")> Public Property KO As String
    <DatabaseField("description"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="description")> Public Property description As String
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="name")> Public Property name As String
''' <summary>
''' image -> gzip -> base64 string
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("map"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="map")> Public Property map As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `data_pathway` (`KO`, `description`, `name`, `map`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `data_pathway` (`uid`, `KO`, `description`, `name`, `map`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `data_pathway` (`KO`, `description`, `name`, `map`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `data_pathway` (`uid`, `KO`, `description`, `name`, `map`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `data_pathway` WHERE `uid` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `data_pathway` SET `uid`='{0}', `KO`='{1}', `description`='{2}', `name`='{3}', `map`='{4}' WHERE `uid` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `data_pathway` WHERE `uid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, uid)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `data_pathway` (`uid`, `KO`, `description`, `name`, `map`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, KO, description, name, map)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `data_pathway` (`uid`, `KO`, `description`, `name`, `map`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, uid, KO, description, name, map)
        Else
        Return String.Format(INSERT_SQL, KO, description, name, map)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{KO}', '{description}', '{name}', '{map}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `data_pathway` (`uid`, `KO`, `description`, `name`, `map`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, KO, description, name, map)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `data_pathway` (`uid`, `KO`, `description`, `name`, `map`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, uid, KO, description, name, map)
        Else
        Return String.Format(REPLACE_SQL, KO, description, name, map)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `data_pathway` SET `uid`='{0}', `KO`='{1}', `description`='{2}', `name`='{3}', `map`='{4}' WHERE `uid` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, uid, KO, description, name, map, uid)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As data_pathway
                         Return DirectCast(MyClass.MemberwiseClone, data_pathway)
                     End Function
End Class


End Namespace
