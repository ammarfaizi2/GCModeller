REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:13 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Xfam.Rfam.MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `motif_file`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `motif_file` (
'''   `motif_acc` varchar(7) NOT NULL,
'''   `seed` longblob NOT NULL,
'''   `cm` longblob NOT NULL,
'''   KEY `fk_motif_file_motif_idx` (`motif_acc`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("motif_file", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `motif_file` (
  `motif_acc` varchar(7) NOT NULL,
  `seed` longblob NOT NULL,
  `cm` longblob NOT NULL,
  KEY `fk_motif_file_motif_idx` (`motif_acc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class motif_file: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("motif_acc"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "7"), Column(Name:="motif_acc"), XmlAttribute> Public Property motif_acc As String
    <DatabaseField("seed"), NotNull, DataType(MySqlDbType.Blob), Column(Name:="seed")> Public Property seed As Byte()
    <DatabaseField("cm"), NotNull, DataType(MySqlDbType.Blob), Column(Name:="cm")> Public Property cm As Byte()
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `motif_file` (`motif_acc`, `seed`, `cm`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `motif_file` (`motif_acc`, `seed`, `cm`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `motif_file` WHERE `motif_acc` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `motif_file` SET `motif_acc`='{0}', `seed`='{1}', `cm`='{2}' WHERE `motif_acc` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `motif_file` WHERE `motif_acc` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, motif_acc)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `motif_file` (`motif_acc`, `seed`, `cm`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, motif_acc, seed, cm)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{motif_acc}', '{seed}', '{cm}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `motif_file` (`motif_acc`, `seed`, `cm`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, motif_acc, seed, cm)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `motif_file` SET `motif_acc`='{0}', `seed`='{1}', `cm`='{2}' WHERE `motif_acc` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, motif_acc, seed, cm, motif_acc)
    End Function
#End Region
Public Function Clone() As motif_file
                  Return DirectCast(MyClass.MemberwiseClone, motif_file)
              End Function
End Class


End Namespace
