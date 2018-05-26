REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:40


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
''' DROP TABLE IF EXISTS `designelementgroup`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `designelementgroup` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `MAGEClass` varchar(100) NOT NULL,
'''   `Identifier` varchar(255) DEFAULT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `ArrayDesign_FeatureGroups` bigint(20) DEFAULT NULL,
'''   `DesignElementGroup_Species` bigint(20) DEFAULT NULL,
'''   `FeatureWidth` float DEFAULT NULL,
'''   `FeatureLength` float DEFAULT NULL,
'''   `FeatureHeight` float DEFAULT NULL,
'''   `FeatureGroup_TechnologyType` bigint(20) DEFAULT NULL,
'''   `FeatureGroup_FeatureShape` bigint(20) DEFAULT NULL,
'''   `FeatureGroup_DistanceUnit` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_DesignElementGroup1` (`DataSetWID`),
'''   KEY `FK_DesignElementGroup3` (`ArrayDesign_FeatureGroups`),
'''   KEY `FK_DesignElementGroup4` (`DesignElementGroup_Species`),
'''   KEY `FK_DesignElementGroup5` (`FeatureGroup_TechnologyType`),
'''   KEY `FK_DesignElementGroup6` (`FeatureGroup_FeatureShape`),
'''   KEY `FK_DesignElementGroup7` (`FeatureGroup_DistanceUnit`),
'''   CONSTRAINT `FK_DesignElementGroup1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DesignElementGroup3` FOREIGN KEY (`ArrayDesign_FeatureGroups`) REFERENCES `arraydesign` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DesignElementGroup4` FOREIGN KEY (`DesignElementGroup_Species`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DesignElementGroup5` FOREIGN KEY (`FeatureGroup_TechnologyType`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DesignElementGroup6` FOREIGN KEY (`FeatureGroup_FeatureShape`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DesignElementGroup7` FOREIGN KEY (`FeatureGroup_DistanceUnit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("designelementgroup", Database:="warehouse", SchemaSQL:="
CREATE TABLE `designelementgroup` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `MAGEClass` varchar(100) NOT NULL,
  `Identifier` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `ArrayDesign_FeatureGroups` bigint(20) DEFAULT NULL,
  `DesignElementGroup_Species` bigint(20) DEFAULT NULL,
  `FeatureWidth` float DEFAULT NULL,
  `FeatureLength` float DEFAULT NULL,
  `FeatureHeight` float DEFAULT NULL,
  `FeatureGroup_TechnologyType` bigint(20) DEFAULT NULL,
  `FeatureGroup_FeatureShape` bigint(20) DEFAULT NULL,
  `FeatureGroup_DistanceUnit` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_DesignElementGroup1` (`DataSetWID`),
  KEY `FK_DesignElementGroup3` (`ArrayDesign_FeatureGroups`),
  KEY `FK_DesignElementGroup4` (`DesignElementGroup_Species`),
  KEY `FK_DesignElementGroup5` (`FeatureGroup_TechnologyType`),
  KEY `FK_DesignElementGroup6` (`FeatureGroup_FeatureShape`),
  KEY `FK_DesignElementGroup7` (`FeatureGroup_DistanceUnit`),
  CONSTRAINT `FK_DesignElementGroup1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DesignElementGroup3` FOREIGN KEY (`ArrayDesign_FeatureGroups`) REFERENCES `arraydesign` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DesignElementGroup4` FOREIGN KEY (`DesignElementGroup_Species`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DesignElementGroup5` FOREIGN KEY (`FeatureGroup_TechnologyType`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DesignElementGroup6` FOREIGN KEY (`FeatureGroup_FeatureShape`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DesignElementGroup7` FOREIGN KEY (`FeatureGroup_DistanceUnit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class designelementgroup: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("MAGEClass"), NotNull, DataType(MySqlDbType.VarChar, "100"), Column(Name:="MAGEClass")> Public Property MAGEClass As String
    <DatabaseField("Identifier"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Identifier")> Public Property Identifier As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Name")> Public Property Name As String
    <DatabaseField("ArrayDesign_FeatureGroups"), DataType(MySqlDbType.Int64, "20"), Column(Name:="ArrayDesign_FeatureGroups")> Public Property ArrayDesign_FeatureGroups As Long
    <DatabaseField("DesignElementGroup_Species"), DataType(MySqlDbType.Int64, "20"), Column(Name:="DesignElementGroup_Species")> Public Property DesignElementGroup_Species As Long
    <DatabaseField("FeatureWidth"), DataType(MySqlDbType.Double), Column(Name:="FeatureWidth")> Public Property FeatureWidth As Double
    <DatabaseField("FeatureLength"), DataType(MySqlDbType.Double), Column(Name:="FeatureLength")> Public Property FeatureLength As Double
    <DatabaseField("FeatureHeight"), DataType(MySqlDbType.Double), Column(Name:="FeatureHeight")> Public Property FeatureHeight As Double
    <DatabaseField("FeatureGroup_TechnologyType"), DataType(MySqlDbType.Int64, "20"), Column(Name:="FeatureGroup_TechnologyType")> Public Property FeatureGroup_TechnologyType As Long
    <DatabaseField("FeatureGroup_FeatureShape"), DataType(MySqlDbType.Int64, "20"), Column(Name:="FeatureGroup_FeatureShape")> Public Property FeatureGroup_FeatureShape As Long
    <DatabaseField("FeatureGroup_DistanceUnit"), DataType(MySqlDbType.Int64, "20"), Column(Name:="FeatureGroup_DistanceUnit")> Public Property FeatureGroup_DistanceUnit As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `designelementgroup` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `ArrayDesign_FeatureGroups`, `DesignElementGroup_Species`, `FeatureWidth`, `FeatureLength`, `FeatureHeight`, `FeatureGroup_TechnologyType`, `FeatureGroup_FeatureShape`, `FeatureGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `designelementgroup` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `ArrayDesign_FeatureGroups`, `DesignElementGroup_Species`, `FeatureWidth`, `FeatureLength`, `FeatureHeight`, `FeatureGroup_TechnologyType`, `FeatureGroup_FeatureShape`, `FeatureGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `designelementgroup` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `ArrayDesign_FeatureGroups`, `DesignElementGroup_Species`, `FeatureWidth`, `FeatureLength`, `FeatureHeight`, `FeatureGroup_TechnologyType`, `FeatureGroup_FeatureShape`, `FeatureGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `designelementgroup` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `ArrayDesign_FeatureGroups`, `DesignElementGroup_Species`, `FeatureWidth`, `FeatureLength`, `FeatureHeight`, `FeatureGroup_TechnologyType`, `FeatureGroup_FeatureShape`, `FeatureGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `designelementgroup` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `designelementgroup` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `Identifier`='{3}', `Name`='{4}', `ArrayDesign_FeatureGroups`='{5}', `DesignElementGroup_Species`='{6}', `FeatureWidth`='{7}', `FeatureLength`='{8}', `FeatureHeight`='{9}', `FeatureGroup_TechnologyType`='{10}', `FeatureGroup_FeatureShape`='{11}', `FeatureGroup_DistanceUnit`='{12}' WHERE `WID` = '{13}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `designelementgroup` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `designelementgroup` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `ArrayDesign_FeatureGroups`, `DesignElementGroup_Species`, `FeatureWidth`, `FeatureLength`, `FeatureHeight`, `FeatureGroup_TechnologyType`, `FeatureGroup_FeatureShape`, `FeatureGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, ArrayDesign_FeatureGroups, DesignElementGroup_Species, FeatureWidth, FeatureLength, FeatureHeight, FeatureGroup_TechnologyType, FeatureGroup_FeatureShape, FeatureGroup_DistanceUnit)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `designelementgroup` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `ArrayDesign_FeatureGroups`, `DesignElementGroup_Species`, `FeatureWidth`, `FeatureLength`, `FeatureHeight`, `FeatureGroup_TechnologyType`, `FeatureGroup_FeatureShape`, `FeatureGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, ArrayDesign_FeatureGroups, DesignElementGroup_Species, FeatureWidth, FeatureLength, FeatureHeight, FeatureGroup_TechnologyType, FeatureGroup_FeatureShape, FeatureGroup_DistanceUnit)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, ArrayDesign_FeatureGroups, DesignElementGroup_Species, FeatureWidth, FeatureLength, FeatureHeight, FeatureGroup_TechnologyType, FeatureGroup_FeatureShape, FeatureGroup_DistanceUnit)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{WID}', '{DataSetWID}', '{MAGEClass}', '{Identifier}', '{Name}', '{ArrayDesign_FeatureGroups}', '{DesignElementGroup_Species}', '{FeatureWidth}', '{FeatureLength}', '{FeatureHeight}', '{FeatureGroup_TechnologyType}', '{FeatureGroup_FeatureShape}', '{FeatureGroup_DistanceUnit}')"
        Else
            Return $"('{WID}', '{DataSetWID}', '{MAGEClass}', '{Identifier}', '{Name}', '{ArrayDesign_FeatureGroups}', '{DesignElementGroup_Species}', '{FeatureWidth}', '{FeatureLength}', '{FeatureHeight}', '{FeatureGroup_TechnologyType}', '{FeatureGroup_FeatureShape}', '{FeatureGroup_DistanceUnit}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `designelementgroup` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `ArrayDesign_FeatureGroups`, `DesignElementGroup_Species`, `FeatureWidth`, `FeatureLength`, `FeatureHeight`, `FeatureGroup_TechnologyType`, `FeatureGroup_FeatureShape`, `FeatureGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, ArrayDesign_FeatureGroups, DesignElementGroup_Species, FeatureWidth, FeatureLength, FeatureHeight, FeatureGroup_TechnologyType, FeatureGroup_FeatureShape, FeatureGroup_DistanceUnit)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `designelementgroup` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `ArrayDesign_FeatureGroups`, `DesignElementGroup_Species`, `FeatureWidth`, `FeatureLength`, `FeatureHeight`, `FeatureGroup_TechnologyType`, `FeatureGroup_FeatureShape`, `FeatureGroup_DistanceUnit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, ArrayDesign_FeatureGroups, DesignElementGroup_Species, FeatureWidth, FeatureLength, FeatureHeight, FeatureGroup_TechnologyType, FeatureGroup_FeatureShape, FeatureGroup_DistanceUnit)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, ArrayDesign_FeatureGroups, DesignElementGroup_Species, FeatureWidth, FeatureLength, FeatureHeight, FeatureGroup_TechnologyType, FeatureGroup_FeatureShape, FeatureGroup_DistanceUnit)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `designelementgroup` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `Identifier`='{3}', `Name`='{4}', `ArrayDesign_FeatureGroups`='{5}', `DesignElementGroup_Species`='{6}', `FeatureWidth`='{7}', `FeatureLength`='{8}', `FeatureHeight`='{9}', `FeatureGroup_TechnologyType`='{10}', `FeatureGroup_FeatureShape`='{11}', `FeatureGroup_DistanceUnit`='{12}' WHERE `WID` = '{13}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, ArrayDesign_FeatureGroups, DesignElementGroup_Species, FeatureWidth, FeatureLength, FeatureHeight, FeatureGroup_TechnologyType, FeatureGroup_FeatureShape, FeatureGroup_DistanceUnit, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As designelementgroup
                         Return DirectCast(MyClass.MemberwiseClone, designelementgroup)
                     End Function
End Class


End Namespace
