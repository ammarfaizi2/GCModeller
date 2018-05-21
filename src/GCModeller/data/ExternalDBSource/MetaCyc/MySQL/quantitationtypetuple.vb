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
''' DROP TABLE IF EXISTS `quantitationtypetuple`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `quantitationtypetuple` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `DesignElementTuple` bigint(20) DEFAULT NULL,
'''   `QuantitationType` bigint(20) DEFAULT NULL,
'''   `QuantitationTypeTuple_Datum` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_QuantitationTypeTuple1` (`DataSetWID`),
'''   KEY `FK_QuantitationTypeTuple2` (`DesignElementTuple`),
'''   KEY `FK_QuantitationTypeTuple3` (`QuantitationType`),
'''   KEY `FK_QuantitationTypeTuple4` (`QuantitationTypeTuple_Datum`),
'''   CONSTRAINT `FK_QuantitationTypeTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantitationTypeTuple2` FOREIGN KEY (`DesignElementTuple`) REFERENCES `designelementtuple` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantitationTypeTuple3` FOREIGN KEY (`QuantitationType`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantitationTypeTuple4` FOREIGN KEY (`QuantitationTypeTuple_Datum`) REFERENCES `datum` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("quantitationtypetuple", Database:="warehouse", SchemaSQL:="
CREATE TABLE `quantitationtypetuple` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `DesignElementTuple` bigint(20) DEFAULT NULL,
  `QuantitationType` bigint(20) DEFAULT NULL,
  `QuantitationTypeTuple_Datum` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_QuantitationTypeTuple1` (`DataSetWID`),
  KEY `FK_QuantitationTypeTuple2` (`DesignElementTuple`),
  KEY `FK_QuantitationTypeTuple3` (`QuantitationType`),
  KEY `FK_QuantitationTypeTuple4` (`QuantitationTypeTuple_Datum`),
  CONSTRAINT `FK_QuantitationTypeTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_QuantitationTypeTuple2` FOREIGN KEY (`DesignElementTuple`) REFERENCES `designelementtuple` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_QuantitationTypeTuple3` FOREIGN KEY (`QuantitationType`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_QuantitationTypeTuple4` FOREIGN KEY (`QuantitationTypeTuple_Datum`) REFERENCES `datum` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class quantitationtypetuple: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("DesignElementTuple"), DataType(MySqlDbType.Int64, "20"), Column(Name:="DesignElementTuple")> Public Property DesignElementTuple As Long
    <DatabaseField("QuantitationType"), DataType(MySqlDbType.Int64, "20"), Column(Name:="QuantitationType")> Public Property QuantitationType As Long
    <DatabaseField("QuantitationTypeTuple_Datum"), DataType(MySqlDbType.Int64, "20"), Column(Name:="QuantitationTypeTuple_Datum")> Public Property QuantitationTypeTuple_Datum As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `quantitationtypetuple` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `quantitationtypetuple` SET `WID`='{0}', `DataSetWID`='{1}', `DesignElementTuple`='{2}', `QuantitationType`='{3}', `QuantitationTypeTuple_Datum`='{4}' WHERE `WID` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `quantitationtypetuple` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, DesignElementTuple, QuantitationType, QuantitationTypeTuple_Datum)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, DesignElementTuple, QuantitationType, QuantitationTypeTuple_Datum)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, DesignElementTuple, QuantitationType, QuantitationTypeTuple_Datum)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{DesignElementTuple}', '{QuantitationType}', '{QuantitationTypeTuple_Datum}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, DesignElementTuple, QuantitationType, QuantitationTypeTuple_Datum)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `quantitationtypetuple` (`WID`, `DataSetWID`, `DesignElementTuple`, `QuantitationType`, `QuantitationTypeTuple_Datum`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, DesignElementTuple, QuantitationType, QuantitationTypeTuple_Datum)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, DesignElementTuple, QuantitationType, QuantitationTypeTuple_Datum)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `quantitationtypetuple` SET `WID`='{0}', `DataSetWID`='{1}', `DesignElementTuple`='{2}', `QuantitationType`='{3}', `QuantitationTypeTuple_Datum`='{4}' WHERE `WID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, DesignElementTuple, QuantitationType, QuantitationTypeTuple_Datum, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As quantitationtypetuple
                         Return DirectCast(MyClass.MemberwiseClone, quantitationtypetuple)
                     End Function
End Class


End Namespace
