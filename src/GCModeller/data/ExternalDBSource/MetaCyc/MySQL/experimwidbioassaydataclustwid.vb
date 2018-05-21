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
''' DROP TABLE IF EXISTS `experimwidbioassaydataclustwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `experimwidbioassaydataclustwid` (
'''   `ExperimentWID` bigint(20) NOT NULL,
'''   `BioAssayDataClusterWID` bigint(20) NOT NULL,
'''   KEY `FK_ExperimWIDBioAssayDataClu1` (`ExperimentWID`),
'''   KEY `FK_ExperimWIDBioAssayDataClu2` (`BioAssayDataClusterWID`),
'''   CONSTRAINT `FK_ExperimWIDBioAssayDataClu1` FOREIGN KEY (`ExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ExperimWIDBioAssayDataClu2` FOREIGN KEY (`BioAssayDataClusterWID`) REFERENCES `bioassaydatacluster` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("experimwidbioassaydataclustwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `experimwidbioassaydataclustwid` (
  `ExperimentWID` bigint(20) NOT NULL,
  `BioAssayDataClusterWID` bigint(20) NOT NULL,
  KEY `FK_ExperimWIDBioAssayDataClu1` (`ExperimentWID`),
  KEY `FK_ExperimWIDBioAssayDataClu2` (`BioAssayDataClusterWID`),
  CONSTRAINT `FK_ExperimWIDBioAssayDataClu1` FOREIGN KEY (`ExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ExperimWIDBioAssayDataClu2` FOREIGN KEY (`BioAssayDataClusterWID`) REFERENCES `bioassaydatacluster` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class experimwidbioassaydataclustwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ExperimentWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ExperimentWID"), XmlAttribute> Public Property ExperimentWID As Long
    <DatabaseField("BioAssayDataClusterWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="BioAssayDataClusterWID")> Public Property BioAssayDataClusterWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `experimwidbioassaydataclustwid` (`ExperimentWID`, `BioAssayDataClusterWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `experimwidbioassaydataclustwid` (`ExperimentWID`, `BioAssayDataClusterWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `experimwidbioassaydataclustwid` (`ExperimentWID`, `BioAssayDataClusterWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `experimwidbioassaydataclustwid` (`ExperimentWID`, `BioAssayDataClusterWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `experimwidbioassaydataclustwid` WHERE `ExperimentWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `experimwidbioassaydataclustwid` SET `ExperimentWID`='{0}', `BioAssayDataClusterWID`='{1}' WHERE `ExperimentWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `experimwidbioassaydataclustwid` WHERE `ExperimentWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ExperimentWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `experimwidbioassaydataclustwid` (`ExperimentWID`, `BioAssayDataClusterWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ExperimentWID, BioAssayDataClusterWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `experimwidbioassaydataclustwid` (`ExperimentWID`, `BioAssayDataClusterWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, ExperimentWID, BioAssayDataClusterWID)
        Else
        Return String.Format(INSERT_SQL, ExperimentWID, BioAssayDataClusterWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ExperimentWID}', '{BioAssayDataClusterWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `experimwidbioassaydataclustwid` (`ExperimentWID`, `BioAssayDataClusterWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ExperimentWID, BioAssayDataClusterWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `experimwidbioassaydataclustwid` (`ExperimentWID`, `BioAssayDataClusterWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, ExperimentWID, BioAssayDataClusterWID)
        Else
        Return String.Format(REPLACE_SQL, ExperimentWID, BioAssayDataClusterWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `experimwidbioassaydataclustwid` SET `ExperimentWID`='{0}', `BioAssayDataClusterWID`='{1}' WHERE `ExperimentWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ExperimentWID, BioAssayDataClusterWID, ExperimentWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As experimwidbioassaydataclustwid
                         Return DirectCast(MyClass.MemberwiseClone, experimwidbioassaydataclustwid)
                     End Function
End Class


End Namespace
