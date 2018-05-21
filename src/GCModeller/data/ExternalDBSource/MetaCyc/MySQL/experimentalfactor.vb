REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:13


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `experimentalfactor`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `experimentalfactor` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `Identifier` varchar(255) DEFAULT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `ExperimentDesign` bigint(20) DEFAULT NULL,
'''   `ExperimentalFactor_Category` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_ExperimentalFactor1` (`DataSetWID`),
'''   KEY `FK_ExperimentalFactor3` (`ExperimentDesign`),
'''   KEY `FK_ExperimentalFactor4` (`ExperimentalFactor_Category`),
'''   CONSTRAINT `FK_ExperimentalFactor1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ExperimentalFactor3` FOREIGN KEY (`ExperimentDesign`) REFERENCES `experimentdesign` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ExperimentalFactor4` FOREIGN KEY (`ExperimentalFactor_Category`) REFERENCES `term` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("experimentalfactor", Database:="warehouse", SchemaSQL:="
CREATE TABLE `experimentalfactor` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `Identifier` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `ExperimentDesign` bigint(20) DEFAULT NULL,
  `ExperimentalFactor_Category` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_ExperimentalFactor1` (`DataSetWID`),
  KEY `FK_ExperimentalFactor3` (`ExperimentDesign`),
  KEY `FK_ExperimentalFactor4` (`ExperimentalFactor_Category`),
  CONSTRAINT `FK_ExperimentalFactor1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ExperimentalFactor3` FOREIGN KEY (`ExperimentDesign`) REFERENCES `experimentdesign` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ExperimentalFactor4` FOREIGN KEY (`ExperimentalFactor_Category`) REFERENCES `term` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class experimentalfactor: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("Identifier"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Identifier")> Public Property Identifier As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Name")> Public Property Name As String
    <DatabaseField("ExperimentDesign"), DataType(MySqlDbType.Int64, "20"), Column(Name:="ExperimentDesign")> Public Property ExperimentDesign As Long
    <DatabaseField("ExperimentalFactor_Category"), DataType(MySqlDbType.Int64, "20"), Column(Name:="ExperimentalFactor_Category")> Public Property ExperimentalFactor_Category As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `experimentalfactor` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentDesign`, `ExperimentalFactor_Category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `experimentalfactor` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentDesign`, `ExperimentalFactor_Category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `experimentalfactor` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentDesign`, `ExperimentalFactor_Category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `experimentalfactor` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentDesign`, `ExperimentalFactor_Category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `experimentalfactor` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `experimentalfactor` SET `WID`='{0}', `DataSetWID`='{1}', `Identifier`='{2}', `Name`='{3}', `ExperimentDesign`='{4}', `ExperimentalFactor_Category`='{5}' WHERE `WID` = '{6}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `experimentalfactor` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `experimentalfactor` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentDesign`, `ExperimentalFactor_Category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, Identifier, Name, ExperimentDesign, ExperimentalFactor_Category)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `experimentalfactor` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentDesign`, `ExperimentalFactor_Category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, Identifier, Name, ExperimentDesign, ExperimentalFactor_Category)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, Identifier, Name, ExperimentDesign, ExperimentalFactor_Category)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{Identifier}', '{Name}', '{ExperimentDesign}', '{ExperimentalFactor_Category}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `experimentalfactor` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentDesign`, `ExperimentalFactor_Category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Identifier, Name, ExperimentDesign, ExperimentalFactor_Category)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `experimentalfactor` (`WID`, `DataSetWID`, `Identifier`, `Name`, `ExperimentDesign`, `ExperimentalFactor_Category`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, Identifier, Name, ExperimentDesign, ExperimentalFactor_Category)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Identifier, Name, ExperimentDesign, ExperimentalFactor_Category)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `experimentalfactor` SET `WID`='{0}', `DataSetWID`='{1}', `Identifier`='{2}', `Name`='{3}', `ExperimentDesign`='{4}', `ExperimentalFactor_Category`='{5}' WHERE `WID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, Identifier, Name, ExperimentDesign, ExperimentalFactor_Category, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As experimentalfactor
                         Return DirectCast(MyClass.MemberwiseClone, experimentalfactor)
                     End Function
End Class


End Namespace
