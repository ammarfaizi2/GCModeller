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
''' DROP TABLE IF EXISTS `biosourcewidbiosubtypewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `biosourcewidbiosubtypewid` (
'''   `BioSourceWID` bigint(20) NOT NULL,
'''   `BioSubtypeWID` bigint(20) NOT NULL,
'''   KEY `FK_BioSourceWIDBioSubtypeWID1` (`BioSourceWID`),
'''   KEY `FK_BioSourceWIDBioSubtypeWID2` (`BioSubtypeWID`),
'''   CONSTRAINT `FK_BioSourceWIDBioSubtypeWID1` FOREIGN KEY (`BioSourceWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioSourceWIDBioSubtypeWID2` FOREIGN KEY (`BioSubtypeWID`) REFERENCES `biosubtype` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("biosourcewidbiosubtypewid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `biosourcewidbiosubtypewid` (
  `BioSourceWID` bigint(20) NOT NULL,
  `BioSubtypeWID` bigint(20) NOT NULL,
  KEY `FK_BioSourceWIDBioSubtypeWID1` (`BioSourceWID`),
  KEY `FK_BioSourceWIDBioSubtypeWID2` (`BioSubtypeWID`),
  CONSTRAINT `FK_BioSourceWIDBioSubtypeWID1` FOREIGN KEY (`BioSourceWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioSourceWIDBioSubtypeWID2` FOREIGN KEY (`BioSubtypeWID`) REFERENCES `biosubtype` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class biosourcewidbiosubtypewid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("BioSourceWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="BioSourceWID"), XmlAttribute> Public Property BioSourceWID As Long
    <DatabaseField("BioSubtypeWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="BioSubtypeWID")> Public Property BioSubtypeWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `biosourcewidbiosubtypewid` (`BioSourceWID`, `BioSubtypeWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `biosourcewidbiosubtypewid` (`BioSourceWID`, `BioSubtypeWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `biosourcewidbiosubtypewid` (`BioSourceWID`, `BioSubtypeWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `biosourcewidbiosubtypewid` (`BioSourceWID`, `BioSubtypeWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `biosourcewidbiosubtypewid` WHERE `BioSourceWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `biosourcewidbiosubtypewid` SET `BioSourceWID`='{0}', `BioSubtypeWID`='{1}' WHERE `BioSourceWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `biosourcewidbiosubtypewid` WHERE `BioSourceWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, BioSourceWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `biosourcewidbiosubtypewid` (`BioSourceWID`, `BioSubtypeWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, BioSourceWID, BioSubtypeWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `biosourcewidbiosubtypewid` (`BioSourceWID`, `BioSubtypeWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, BioSourceWID, BioSubtypeWID)
        Else
        Return String.Format(INSERT_SQL, BioSourceWID, BioSubtypeWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{BioSourceWID}', '{BioSubtypeWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `biosourcewidbiosubtypewid` (`BioSourceWID`, `BioSubtypeWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, BioSourceWID, BioSubtypeWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `biosourcewidbiosubtypewid` (`BioSourceWID`, `BioSubtypeWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, BioSourceWID, BioSubtypeWID)
        Else
        Return String.Format(REPLACE_SQL, BioSourceWID, BioSubtypeWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `biosourcewidbiosubtypewid` SET `BioSourceWID`='{0}', `BioSubtypeWID`='{1}' WHERE `BioSourceWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, BioSourceWID, BioSubtypeWID, BioSourceWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As biosourcewidbiosubtypewid
                         Return DirectCast(MyClass.MemberwiseClone, biosourcewidbiosubtypewid)
                     End Function
End Class


End Namespace
