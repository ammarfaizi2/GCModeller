﻿Imports Microsoft.VisualBasic.DataMining.ComponentModel.Encoder
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace SVM

    Public Class SVMModel

        Public Property model As Model
        Public Property transform As IRangeTransform
        Public Property factors As ClassEncoder

        Public ReadOnly Property DimensionNames As String()
            Get
                Return model.DimensionNames
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return DimensionNames.GetJson
        End Function
    End Class
End Namespace