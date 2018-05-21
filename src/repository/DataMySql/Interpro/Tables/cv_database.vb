REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:10


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
''' DROP TABLE IF EXISTS `cv_database`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `cv_database` (
'''   `dbcode` char(1) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `dbname` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `dborder` int(5) NOT NULL,
'''   `dbshort` varchar(10) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   PRIMARY KEY (`dbcode`),
'''   UNIQUE KEY `uq_cv_database$database` (`dbname`),
'''   UNIQUE KEY `uq_cv_database$dborder` (`dborder`),
'''   UNIQUE KEY `uq_cv_database$dbshort` (`dbshort`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("cv_database", Database:="interpro", SchemaSQL:="
CREATE TABLE `cv_database` (
  `dbcode` char(1) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `dbname` varchar(20) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `dborder` int(5) NOT NULL,
  `dbshort` varchar(10) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  PRIMARY KEY (`dbcode`),
  UNIQUE KEY `uq_cv_database$database` (`dbname`),
  UNIQUE KEY `uq_cv_database$dborder` (`dborder`),
  UNIQUE KEY `uq_cv_database$dbshort` (`dbshort`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class cv_database: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("dbcode"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "1"), Column(Name:="dbcode"), XmlAttribute> Public Property dbcode As String
    <DatabaseField("dbname"), NotNull, DataType(MySqlDbType.VarChar, "20"), Column(Name:="dbname")> Public Property dbname As String
    <DatabaseField("dborder"), NotNull, DataType(MySqlDbType.Int64, "5"), Column(Name:="dborder")> Public Property dborder As Long
    <DatabaseField("dbshort"), NotNull, DataType(MySqlDbType.VarChar, "10"), Column(Name:="dbshort")> Public Property dbshort As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `cv_database` (`dbcode`, `dbname`, `dborder`, `dbshort`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `cv_database` (`dbcode`, `dbname`, `dborder`, `dbshort`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `cv_database` (`dbcode`, `dbname`, `dborder`, `dbshort`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `cv_database` (`dbcode`, `dbname`, `dborder`, `dbshort`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `cv_database` WHERE `dbcode` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `cv_database` SET `dbcode`='{0}', `dbname`='{1}', `dborder`='{2}', `dbshort`='{3}' WHERE `dbcode` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `cv_database` WHERE `dbcode` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, dbcode)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `cv_database` (`dbcode`, `dbname`, `dborder`, `dbshort`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, dbcode, dbname, dborder, dbshort)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `cv_database` (`dbcode`, `dbname`, `dborder`, `dbshort`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, dbcode, dbname, dborder, dbshort)
        Else
        Return String.Format(INSERT_SQL, dbcode, dbname, dborder, dbshort)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{dbcode}', '{dbname}', '{dborder}', '{dbshort}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `cv_database` (`dbcode`, `dbname`, `dborder`, `dbshort`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, dbcode, dbname, dborder, dbshort)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `cv_database` (`dbcode`, `dbname`, `dborder`, `dbshort`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, dbcode, dbname, dborder, dbshort)
        Else
        Return String.Format(REPLACE_SQL, dbcode, dbname, dborder, dbshort)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `cv_database` SET `dbcode`='{0}', `dbname`='{1}', `dborder`='{2}', `dbshort`='{3}' WHERE `dbcode` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, dbcode, dbname, dborder, dbshort, dbcode)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As cv_database
                         Return DirectCast(MyClass.MemberwiseClone, cv_database)
                     End Function
End Class


End Namespace
