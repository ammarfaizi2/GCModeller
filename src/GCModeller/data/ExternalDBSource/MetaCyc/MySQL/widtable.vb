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
''' DROP TABLE IF EXISTS `widtable`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `widtable` (
'''   `PreviousWID` bigint(20) NOT NULL AUTO_INCREMENT,
'''   PRIMARY KEY (`PreviousWID`)
''' ) ENGINE=InnoDB AUTO_INCREMENT=1000000 DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("widtable", Database:="warehouse", SchemaSQL:="
CREATE TABLE `widtable` (
  `PreviousWID` bigint(20) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`PreviousWID`)
) ENGINE=InnoDB AUTO_INCREMENT=1000000 DEFAULT CHARSET=utf8;
")>
Public Class widtable: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("PreviousWID"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="PreviousWID"), XmlAttribute> Public Property PreviousWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `widtable` () VALUES ();</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `widtable` (`PreviousWID`) VALUES ('{0}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `widtable` () VALUES ();</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `widtable` (`PreviousWID`) VALUES ('{0}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `widtable` WHERE `PreviousWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `widtable` SET `PreviousWID`='{0}' WHERE `PreviousWID` = '{1}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `widtable` WHERE `PreviousWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, PreviousWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `widtable` (`PreviousWID`) VALUES ('{0}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
            '  Return String.Format(INSERT_SQL, )
            Throw New NotImplementedException
        End Function

''' <summary>
''' ```SQL
''' INSERT INTO `widtable` (`PreviousWID`) VALUES ('{0}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, PreviousWID)
        Else
                ' Return String.Format(INSERT_SQL, )
                Throw New NotImplementedException
            End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"()"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `widtable` (`PreviousWID`) VALUES ('{0}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
            ' Return String.Format(REPLACE_SQL, )
            Throw New NotImplementedException
        End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `widtable` (`PreviousWID`) VALUES ('{0}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, PreviousWID)
        Else
                '  Return String.Format(REPLACE_SQL, )
                Throw New NotImplementedException
            End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `widtable` SET `PreviousWID`='{0}' WHERE `PreviousWID` = '{1}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, PreviousWID, PreviousWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As widtable
                         Return DirectCast(MyClass.MemberwiseClone, widtable)
                     End Function
End Class


End Namespace
