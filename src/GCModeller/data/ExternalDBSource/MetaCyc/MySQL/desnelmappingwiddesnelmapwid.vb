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
''' DROP TABLE IF EXISTS `desnelmappingwiddesnelmapwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `desnelmappingwiddesnelmapwid` (
'''   `DesignElementMappingWID` bigint(20) NOT NULL,
'''   `DesignElementMapWID` bigint(20) NOT NULL,
'''   KEY `FK_DesnElMappingWIDDesnElMap1` (`DesignElementMappingWID`),
'''   KEY `FK_DesnElMappingWIDDesnElMap2` (`DesignElementMapWID`),
'''   CONSTRAINT `FK_DesnElMappingWIDDesnElMap1` FOREIGN KEY (`DesignElementMappingWID`) REFERENCES `designelementmapping` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DesnElMappingWIDDesnElMap2` FOREIGN KEY (`DesignElementMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("desnelmappingwiddesnelmapwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `desnelmappingwiddesnelmapwid` (
  `DesignElementMappingWID` bigint(20) NOT NULL,
  `DesignElementMapWID` bigint(20) NOT NULL,
  KEY `FK_DesnElMappingWIDDesnElMap1` (`DesignElementMappingWID`),
  KEY `FK_DesnElMappingWIDDesnElMap2` (`DesignElementMapWID`),
  CONSTRAINT `FK_DesnElMappingWIDDesnElMap1` FOREIGN KEY (`DesignElementMappingWID`) REFERENCES `designelementmapping` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DesnElMappingWIDDesnElMap2` FOREIGN KEY (`DesignElementMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class desnelmappingwiddesnelmapwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DesignElementMappingWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DesignElementMappingWID"), XmlAttribute> Public Property DesignElementMappingWID As Long
    <DatabaseField("DesignElementMapWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DesignElementMapWID")> Public Property DesignElementMapWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `desnelmappingwiddesnelmapwid` (`DesignElementMappingWID`, `DesignElementMapWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `desnelmappingwiddesnelmapwid` (`DesignElementMappingWID`, `DesignElementMapWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `desnelmappingwiddesnelmapwid` (`DesignElementMappingWID`, `DesignElementMapWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `desnelmappingwiddesnelmapwid` (`DesignElementMappingWID`, `DesignElementMapWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `desnelmappingwiddesnelmapwid` WHERE `DesignElementMappingWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `desnelmappingwiddesnelmapwid` SET `DesignElementMappingWID`='{0}', `DesignElementMapWID`='{1}' WHERE `DesignElementMappingWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `desnelmappingwiddesnelmapwid` WHERE `DesignElementMappingWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DesignElementMappingWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `desnelmappingwiddesnelmapwid` (`DesignElementMappingWID`, `DesignElementMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DesignElementMappingWID, DesignElementMapWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `desnelmappingwiddesnelmapwid` (`DesignElementMappingWID`, `DesignElementMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DesignElementMappingWID, DesignElementMapWID)
        Else
        Return String.Format(INSERT_SQL, DesignElementMappingWID, DesignElementMapWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DesignElementMappingWID}', '{DesignElementMapWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `desnelmappingwiddesnelmapwid` (`DesignElementMappingWID`, `DesignElementMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DesignElementMappingWID, DesignElementMapWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `desnelmappingwiddesnelmapwid` (`DesignElementMappingWID`, `DesignElementMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DesignElementMappingWID, DesignElementMapWID)
        Else
        Return String.Format(REPLACE_SQL, DesignElementMappingWID, DesignElementMapWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `desnelmappingwiddesnelmapwid` SET `DesignElementMappingWID`='{0}', `DesignElementMapWID`='{1}' WHERE `DesignElementMappingWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DesignElementMappingWID, DesignElementMapWID, DesignElementMappingWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As desnelmappingwiddesnelmapwid
                         Return DirectCast(MyClass.MemberwiseClone, desnelmappingwiddesnelmapwid)
                     End Function
End Class


End Namespace
