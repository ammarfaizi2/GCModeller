﻿Imports System.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel

Namespace Serialization.BinaryDumping

    ''' <summary>
    ''' Do serialization or count memory size by this interface method
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="type"></param>
    ''' <param name="isVisited">当前的对象是否是一个已经被访问过的引用对象</param>
    Public Delegate Sub DoVisitObject(value As Object, type As Type, memberInfo As MemberInfo, isVisited As Boolean, isValueType As Boolean)

    ''' <summary>
    ''' A Common framework for visit a object
    ''' </summary>
    Public NotInheritable Class ObjectVisitor

        ''' <summary>
        ''' Only visit instance fields, otherwise visit properties
        ''' </summary>
        ''' <returns></returns>
        Public Property VisitOnlyFields As Boolean = False

        ''' <summary>
        ''' Visited reference types
        ''' </summary>
        Dim visitedReferences As New Index(Of Object)

        Sub New()
        End Sub

        Public Sub DoVisitObject(obj As Object, type As Type, visit As DoVisitObject)
            visitedReferences += obj

            If VisitOnlyFields Then
                Call doVisitFields(obj, type.GetFields, visit)
            Else
                Call doVisitProperties(obj, type.GetProperties(PublicProperty), visit)
            End If
        End Sub

        Private Sub doVisitProperties(obj As Object, properties As PropertyInfo(), visit As DoVisitObject)

        End Sub

        Private Sub doVisitFields(obj As Object, fields As FieldInfo(), visit As DoVisitObject)
            Dim value As Object
            Dim type As Type
            Dim isVisited As Boolean = False
            Dim isValueType As Boolean = False

            For Each field As FieldInfo In obj
                value = field.GetValue(obj)

                ' 因为在字段的定义中会存在继承或者接口实现的这些抽象的类型实现关系, 所以在这里优先从
                ' value值之中获取真实的类型信息
                '
                ' 如果是空值,则获取字段的类型信息
                If value Is Nothing Then
                    type = field.FieldType
                Else
                    ' 如果不是空值,则获取实际的类型信息
                    type = value.GetType

                    ' value is not nothing
                    If Not type.IsValueType AndAlso Not type Is GetType(String) Then
                        If value Like visitedReferences Then
                            isVisited = True
                        Else
                            isVisited = False
                            visitedReferences += value
                        End If

                        isValueType = False
                    Else
                        isValueType = True
                    End If
                End If

                Call visit(value, type, field, isVisited, isValueType)
            Next
        End Sub
    End Class
End Namespace