﻿Imports SMRUCC.genomics.Assembly.KEGG.DBGET.bGetObject
Imports SMRUCC.genomics.ComponentModel.DBLinkBuilder

Namespace Assembly.KEGG.Medical

    Public Class Disease

        Public Property Entry As String
        Public Property Names As String()
        Public Property Description As String
        Public Property Category As String
        Public Property Genes As String()
        Public Property Carcinogen As String()
        Public Property Pathogens As String()
        Public Property Markers As String()
        Public Property Drugs As String()

        ''' <summary>
        ''' 多行数据已经join过了的单行字符串
        ''' </summary>
        ''' <returns></returns>
        Public Property Comments As String
        Public Property DbLinks As DBLink()
        Public Property References As Reference()
        Public Property Env_factors As String()

    End Class
End Namespace