﻿#Region "Microsoft.VisualBasic::8976347b9ffd824861dd537584d5ab3b, Data\BinaryData\DataStorage\HDF5\structure\StructureMember.vb"

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

    '     Class StructureMember
    ' 
    '         Properties: dims, message, name, offset
    ' 
    '         Constructor: (+1 Overloads) Sub New
    ' 
    '         Function: ToString
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


Imports Microsoft.VisualBasic.Data.IO.HDF5.IO

Namespace HDF5.[Structure]

    Public Class StructureMember : Inherits HDF5Ptr

        Public Overridable ReadOnly Property name As String
        Public Overridable ReadOnly Property offset As Integer
        Public Overridable ReadOnly Property dims As Integer
        Public Overridable ReadOnly Property message As DataTypeMessage

        Public Sub New([in] As BinaryReader, sb As Superblock, address As Long, version As Integer, byteSize As Integer)
            Call MyBase.New(address)

            [in].offset = address

            Me.name = [in].readASCIIString()

            If version < 3 Then
                [in].skipBytes(ReadHelper.padding(Me.name.Length + 1, 8))
                Me.offset = [in].readInt()
            Else
                Me.offset = CInt(ReadHelper.readVariableSizeMax([in], byteSize))
            End If

            If version = 1 Then
                Me.dims = [in].readByte()

                [in].skipBytes(3)
                ' ignore dimension info for now
                [in].skipBytes(24)
            End If

            Me.message = New DataTypeMessage([in], sb, [in].offset)
        End Sub

        Public Overrides Function ToString() As String
            Return $"Dim {name} As {Message} = [&{address}, {Offset}]"
        End Function

        Public Overridable Sub printValues()
            Console.WriteLine("StructureMember >>>")
            Console.WriteLine("address : " & Me.m_address)
            Console.WriteLine("name : " & Me.name)
            Console.WriteLine("offset : " & Me.offset)
            Console.WriteLine("m_dims : " & Me.dims)

            If Me.message IsNot Nothing Then
                Me.message.printValues()
            End If
            Console.WriteLine("StructureMember >>>")
        End Sub
    End Class

End Namespace
