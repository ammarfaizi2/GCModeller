REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:11


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `regulons`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `regulons` (
'''   `regulon_guid` int(11) NOT NULL DEFAULT '0',
'''   `pkg_guid` int(11) NOT NULL DEFAULT '0',
'''   `art_guid` int(11) NOT NULL DEFAULT '0',
'''   `name` varchar(50) DEFAULT NULL,
'''   `fl_real_name` int(1) DEFAULT NULL,
'''   `genome_guid` int(11) DEFAULT NULL,
'''   `regulator_guid` int(11) DEFAULT NULL,
'''   `descript` blob,
'''   `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   PRIMARY KEY (`regulon_guid`),
'''   KEY `FK_regulons-pkg_guid` (`pkg_guid`),
'''   KEY `FK_regulons-art_guid` (`art_guid`),
'''   KEY `FK_regulons-genome_guid` (`genome_guid`),
'''   KEY `FK_regulons-regulator_guid` (`regulator_guid`),
'''   CONSTRAINT `FK_regulons-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
'''   CONSTRAINT `FK_regulons-genome_guid` FOREIGN KEY (`genome_guid`) REFERENCES `dict_genomes` (`genome_guid`),
'''   CONSTRAINT `FK_regulons-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`),
'''   CONSTRAINT `regulons_ibfk_1` FOREIGN KEY (`regulator_guid`) REFERENCES `obj_name_genomes` (`obj_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("regulons", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `regulons` (
  `regulon_guid` int(11) NOT NULL DEFAULT '0',
  `pkg_guid` int(11) NOT NULL DEFAULT '0',
  `art_guid` int(11) NOT NULL DEFAULT '0',
  `name` varchar(50) DEFAULT NULL,
  `fl_real_name` int(1) DEFAULT NULL,
  `genome_guid` int(11) DEFAULT NULL,
  `regulator_guid` int(11) DEFAULT NULL,
  `descript` blob,
  `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`regulon_guid`),
  KEY `FK_regulons-pkg_guid` (`pkg_guid`),
  KEY `FK_regulons-art_guid` (`art_guid`),
  KEY `FK_regulons-genome_guid` (`genome_guid`),
  KEY `FK_regulons-regulator_guid` (`regulator_guid`),
  CONSTRAINT `FK_regulons-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
  CONSTRAINT `FK_regulons-genome_guid` FOREIGN KEY (`genome_guid`) REFERENCES `dict_genomes` (`genome_guid`),
  CONSTRAINT `FK_regulons-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`),
  CONSTRAINT `regulons_ibfk_1` FOREIGN KEY (`regulator_guid`) REFERENCES `obj_name_genomes` (`obj_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class regulons: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("regulon_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="regulon_guid"), XmlAttribute> Public Property regulon_guid As Long
    <DatabaseField("pkg_guid"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="pkg_guid")> Public Property pkg_guid As Long
    <DatabaseField("art_guid"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="art_guid")> Public Property art_guid As Long
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="name")> Public Property name As String
    <DatabaseField("fl_real_name"), DataType(MySqlDbType.Int64, "1"), Column(Name:="fl_real_name")> Public Property fl_real_name As Long
    <DatabaseField("genome_guid"), DataType(MySqlDbType.Int64, "11"), Column(Name:="genome_guid")> Public Property genome_guid As Long
    <DatabaseField("regulator_guid"), DataType(MySqlDbType.Int64, "11"), Column(Name:="regulator_guid")> Public Property regulator_guid As Long
    <DatabaseField("descript"), DataType(MySqlDbType.Blob), Column(Name:="descript")> Public Property descript As Byte()
    <DatabaseField("last_update"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="last_update")> Public Property last_update As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `regulons` (`regulon_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `regulator_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `regulons` (`regulon_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `regulator_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `regulons` (`regulon_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `regulator_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `regulons` (`regulon_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `regulator_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `regulons` WHERE `regulon_guid` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `regulons` SET `regulon_guid`='{0}', `pkg_guid`='{1}', `art_guid`='{2}', `name`='{3}', `fl_real_name`='{4}', `genome_guid`='{5}', `regulator_guid`='{6}', `descript`='{7}', `last_update`='{8}' WHERE `regulon_guid` = '{9}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `regulons` WHERE `regulon_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, regulon_guid)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `regulons` (`regulon_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `regulator_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, regulon_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, regulator_guid, descript, MySqlScript.ToMySqlDateTimeString(last_update))
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `regulons` (`regulon_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `regulator_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, regulon_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, regulator_guid, descript, MySqlScript.ToMySqlDateTimeString(last_update))
        Else
        Return String.Format(INSERT_SQL, regulon_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, regulator_guid, descript, MySqlScript.ToMySqlDateTimeString(last_update))
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{regulon_guid}', '{pkg_guid}', '{art_guid}', '{name}', '{fl_real_name}', '{genome_guid}', '{regulator_guid}', '{descript}', '{last_update}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `regulons` (`regulon_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `regulator_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, regulon_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, regulator_guid, descript, MySqlScript.ToMySqlDateTimeString(last_update))
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `regulons` (`regulon_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `regulator_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, regulon_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, regulator_guid, descript, MySqlScript.ToMySqlDateTimeString(last_update))
        Else
        Return String.Format(REPLACE_SQL, regulon_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, regulator_guid, descript, MySqlScript.ToMySqlDateTimeString(last_update))
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `regulons` SET `regulon_guid`='{0}', `pkg_guid`='{1}', `art_guid`='{2}', `name`='{3}', `fl_real_name`='{4}', `genome_guid`='{5}', `regulator_guid`='{6}', `descript`='{7}', `last_update`='{8}' WHERE `regulon_guid` = '{9}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, regulon_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, regulator_guid, descript, MySqlScript.ToMySqlDateTimeString(last_update), regulon_guid)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As regulons
                         Return DirectCast(MyClass.MemberwiseClone, regulons)
                     End Function
End Class


End Namespace
