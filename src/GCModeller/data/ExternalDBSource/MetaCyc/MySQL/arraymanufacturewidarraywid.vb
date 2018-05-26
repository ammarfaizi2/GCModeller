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
''' DROP TABLE IF EXISTS `arraymanufacturewidarraywid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `arraymanufacturewidarraywid` (
'''   `ArrayManufactureWID` bigint(20) NOT NULL,
'''   `ArrayWID` bigint(20) NOT NULL,
'''   KEY `FK_ArrayManufactureWIDArrayW1` (`ArrayManufactureWID`),
'''   KEY `FK_ArrayManufactureWIDArrayW2` (`ArrayWID`),
'''   CONSTRAINT `FK_ArrayManufactureWIDArrayW1` FOREIGN KEY (`ArrayManufactureWID`) REFERENCES `arraymanufacture` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ArrayManufactureWIDArrayW2` FOREIGN KEY (`ArrayWID`) REFERENCES `array_` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("arraymanufacturewidarraywid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `arraymanufacturewidarraywid` (
  `ArrayManufactureWID` bigint(20) NOT NULL,
  `ArrayWID` bigint(20) NOT NULL,
  KEY `FK_ArrayManufactureWIDArrayW1` (`ArrayManufactureWID`),
  KEY `FK_ArrayManufactureWIDArrayW2` (`ArrayWID`),
  CONSTRAINT `FK_ArrayManufactureWIDArrayW1` FOREIGN KEY (`ArrayManufactureWID`) REFERENCES `arraymanufacture` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ArrayManufactureWIDArrayW2` FOREIGN KEY (`ArrayWID`) REFERENCES `array_` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class arraymanufacturewidarraywid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ArrayManufactureWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ArrayManufactureWID"), XmlAttribute> Public Property ArrayManufactureWID As Long
    <DatabaseField("ArrayWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ArrayWID")> Public Property ArrayWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `arraymanufacturewidarraywid` (`ArrayManufactureWID`, `ArrayWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `arraymanufacturewidarraywid` (`ArrayManufactureWID`, `ArrayWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `arraymanufacturewidarraywid` (`ArrayManufactureWID`, `ArrayWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `arraymanufacturewidarraywid` (`ArrayManufactureWID`, `ArrayWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `arraymanufacturewidarraywid` WHERE `ArrayManufactureWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `arraymanufacturewidarraywid` SET `ArrayManufactureWID`='{0}', `ArrayWID`='{1}' WHERE `ArrayManufactureWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `arraymanufacturewidarraywid` WHERE `ArrayManufactureWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ArrayManufactureWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `arraymanufacturewidarraywid` (`ArrayManufactureWID`, `ArrayWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ArrayManufactureWID, ArrayWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `arraymanufacturewidarraywid` (`ArrayManufactureWID`, `ArrayWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, ArrayManufactureWID, ArrayWID)
        Else
        Return String.Format(INSERT_SQL, ArrayManufactureWID, ArrayWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{ArrayManufactureWID}', '{ArrayWID}')"
        Else
            Return $"('{ArrayManufactureWID}', '{ArrayWID}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `arraymanufacturewidarraywid` (`ArrayManufactureWID`, `ArrayWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ArrayManufactureWID, ArrayWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `arraymanufacturewidarraywid` (`ArrayManufactureWID`, `ArrayWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, ArrayManufactureWID, ArrayWID)
        Else
        Return String.Format(REPLACE_SQL, ArrayManufactureWID, ArrayWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `arraymanufacturewidarraywid` SET `ArrayManufactureWID`='{0}', `ArrayWID`='{1}' WHERE `ArrayManufactureWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ArrayManufactureWID, ArrayWID, ArrayManufactureWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As arraymanufacturewidarraywid
                         Return DirectCast(MyClass.MemberwiseClone, arraymanufacturewidarraywid)
                     End Function
End Class


End Namespace
