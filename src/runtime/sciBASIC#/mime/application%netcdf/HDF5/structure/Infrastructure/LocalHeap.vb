﻿#Region "Microsoft.VisualBasic::8e6be876a68b43e6e4973de3d2bbc902, mime\application%netcdf\HDF5\structure\Infrastructure\LocalHeap.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.



    ' /********************************************************************************/

    ' Summaries:

    '     Class LocalHeap
    ' 
    '         Properties: address, addressOfDataSegment, data, dataSegmentSize, offsetToHeadOfFreeList
    '                     signature, totalLocalHeapSize, validSignature, version
    ' 
    '         Constructor: (+1 Overloads) Sub New
    ' 
    '         Function: getString
    ' 
    '         Sub: printValues
    ' 
    ' 
    ' /********************************************************************************/

#End Region


'
' * Mostly copied from NETCDF4 source code.
' * refer : http://www.unidata.ucar.edu
' * 
' * Modified by iychoi@email.arizona.edu
' 


Imports System.IO
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.MIME.application.netCDF.HDF5.IO
Imports BinaryReader = Microsoft.VisualBasic.MIME.application.netCDF.HDF5.IO.BinaryReader

Namespace HDF5.[Structure]

    ''' <summary>
    ''' A local heap is a collection of small pieces of data that are particular to a single object 
    ''' in the HDF5 file. Objects can be inserted and removed from the heap at any time. The 
    ''' address of a heap does not change once the heap is created. For example, a group stores 
    ''' addresses of objects in symbol table nodes with the names of links stored in the group's 
    ''' local heap.
    ''' </summary>
    Public Class LocalHeap

        Shared ReadOnly LOCALHEAP_SIGNATURE As Byte() = New CharStream() From {"H"c, "E"c, "A"c, "P"c}

        Private m_address As Long

        Private m_signature As Byte()
        Private m_version As Integer
        Private m_reserved0 As Byte()
        Private m_dataSegmentSize As Long
        Private m_offsetToHeadOfFreeList As Long
        Private m_addressOfDataSegment As Long

        Private m_data As Byte()

        Private m_totalLocalHeapSize As Integer

        Public Sub New([in] As BinaryReader, sb As Superblock, address As Long)

            Me.m_address = address

            [in].offset = address

            ' signature
            Me.m_signature = [in].readBytes(4)

            If Not Me.validSignature Then
                Throw New IOException("signature is not valid")
            End If

            Me.m_version = [in].readByte()

            If Me.m_version > 0 Then
                Throw New IOException("version not implemented")
            End If

            Me.m_reserved0 = [in].readBytes(3)

            Me.m_totalLocalHeapSize = 8

            Me.m_dataSegmentSize = ReadHelper.readL([in], sb)
            Me.m_offsetToHeadOfFreeList = ReadHelper.readL([in], sb)

            Me.m_totalLocalHeapSize += sb.sizeOfLengths * 2

            Me.m_addressOfDataSegment = ReadHelper.readO([in], sb)

            Me.m_totalLocalHeapSize += sb.sizeOfOffsets

            ' data
            [in].offset = Me.m_addressOfDataSegment
            Me.m_data = [in].readBytes(CInt(Me.m_dataSegmentSize))
        End Sub

        Public Overridable ReadOnly Property address() As Long
            Get
                Return Me.m_address
            End Get
        End Property

        Public Overridable ReadOnly Property signature() As Byte()
            Get
                Return Me.m_signature
            End Get
        End Property

        Public Overridable ReadOnly Property validSignature() As Boolean
            Get
                For i As Integer = 0 To 3
                    If Me.m_signature(i) <> LOCALHEAP_SIGNATURE(i) Then
                        Return False
                    End If
                Next
                Return True
            End Get
        End Property

        Public Overridable ReadOnly Property version() As Integer
            Get
                Return Me.m_version
            End Get
        End Property

        Public Overridable ReadOnly Property dataSegmentSize() As Long
            Get
                Return Me.m_dataSegmentSize
            End Get
        End Property

        Public Overridable ReadOnly Property offsetToHeadOfFreeList() As Long
            Get
                Return Me.m_offsetToHeadOfFreeList
            End Get
        End Property

        Public Overridable ReadOnly Property addressOfDataSegment() As Long
            Get
                Return Me.m_addressOfDataSegment
            End Get
        End Property

        Public Overridable ReadOnly Property totalLocalHeapSize() As Integer
            Get
                Return Me.m_totalLocalHeapSize
            End Get
        End Property

        Public Overridable ReadOnly Property data() As Byte()
            Get
                Return Me.m_data
            End Get
        End Property

        Public Overridable Sub printValues()
            Console.WriteLine("LocalHeap >>>")
            Console.WriteLine("address : " & Me.m_address)
            Console.WriteLine("signature : " & (Me.m_signature(0) And &HFF).ToString("x") & (Me.m_signature(1) And &HFF).ToString("x") & (Me.m_signature(2) And &HFF).ToString("x") & (Me.m_signature(3) And &HFF).ToString("x"))

            Console.WriteLine("version : " & Me.m_version)
            Console.WriteLine("data segment size : " & Me.m_dataSegmentSize)
            Console.WriteLine("offset to head of free list : " & Me.m_offsetToHeadOfFreeList)
            Console.WriteLine("address of data segment : " & Me.m_addressOfDataSegment)

            Console.WriteLine("total local heap size : " & Me.m_totalLocalHeapSize)

            If Me.m_data IsNot Nothing Then
                For i As Integer = 0 To Me.m_data.Length - 1
                    Console.WriteLine("data[" & i & "] : " & Me.m_data(i))
                Next
            End If

            Console.WriteLine("LocalHeap <<<")
        End Sub

        Public Overridable Function getString(offset As Integer) As String
            Dim count As Integer = 0
            While Me.m_data(offset + count) <> 0
                count += 1
            End While

            Return Me.m_data.ByteString(offset, count)
        End Function
    End Class

End Namespace

