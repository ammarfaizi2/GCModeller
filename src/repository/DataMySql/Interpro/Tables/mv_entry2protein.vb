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
''' DROP TABLE IF EXISTS `mv_entry2protein`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `mv_entry2protein` (
'''   `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `match_count` int(7) NOT NULL,
'''   PRIMARY KEY (`entry_ac`,`protein_ac`),
'''   KEY `fk_mv_entry2protein$protein` (`protein_ac`),
'''   CONSTRAINT `fk_mv_entry2protein$entry` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_mv_entry2protein$protein` FOREIGN KEY (`protein_ac`) REFERENCES `protein` (`protein_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("mv_entry2protein", Database:="interpro", SchemaSQL:="
CREATE TABLE `mv_entry2protein` (
  `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `match_count` int(7) NOT NULL,
  PRIMARY KEY (`entry_ac`,`protein_ac`),
  KEY `fk_mv_entry2protein$protein` (`protein_ac`),
  CONSTRAINT `fk_mv_entry2protein$entry` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_mv_entry2protein$protein` FOREIGN KEY (`protein_ac`) REFERENCES `protein` (`protein_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class mv_entry2protein: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9"), Column(Name:="entry_ac"), XmlAttribute> Public Property entry_ac As String
    <DatabaseField("protein_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "6"), Column(Name:="protein_ac"), XmlAttribute> Public Property protein_ac As String
    <DatabaseField("match_count"), NotNull, DataType(MySqlDbType.Int64, "7"), Column(Name:="match_count")> Public Property match_count As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `mv_entry2protein` (`entry_ac`, `protein_ac`, `match_count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `mv_entry2protein` (`entry_ac`, `protein_ac`, `match_count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `mv_entry2protein` (`entry_ac`, `protein_ac`, `match_count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `mv_entry2protein` (`entry_ac`, `protein_ac`, `match_count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `mv_entry2protein` WHERE `entry_ac`='{0}' and `protein_ac`='{1}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `mv_entry2protein` SET `entry_ac`='{0}', `protein_ac`='{1}', `match_count`='{2}' WHERE `entry_ac`='{3}' and `protein_ac`='{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `mv_entry2protein` WHERE `entry_ac`='{0}' and `protein_ac`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry_ac, protein_ac)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `mv_entry2protein` (`entry_ac`, `protein_ac`, `match_count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry_ac, protein_ac, match_count)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `mv_entry2protein` (`entry_ac`, `protein_ac`, `match_count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, entry_ac, protein_ac, match_count)
        Else
        Return String.Format(INSERT_SQL, entry_ac, protein_ac, match_count)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{entry_ac}', '{protein_ac}', '{match_count}')"
        Else
            Return $"('{entry_ac}', '{protein_ac}', '{match_count}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `mv_entry2protein` (`entry_ac`, `protein_ac`, `match_count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry_ac, protein_ac, match_count)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `mv_entry2protein` (`entry_ac`, `protein_ac`, `match_count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, entry_ac, protein_ac, match_count)
        Else
        Return String.Format(REPLACE_SQL, entry_ac, protein_ac, match_count)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `mv_entry2protein` SET `entry_ac`='{0}', `protein_ac`='{1}', `match_count`='{2}' WHERE `entry_ac`='{3}' and `protein_ac`='{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry_ac, protein_ac, match_count, entry_ac, protein_ac)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As mv_entry2protein
                         Return DirectCast(MyClass.MemberwiseClone, mv_entry2protein)
                     End Function
End Class


End Namespace
