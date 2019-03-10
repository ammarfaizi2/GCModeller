﻿#Region "Microsoft.VisualBasic::ba7ef08fe088dc421d8b2c592e1c83fc, mime\application%netcdf\HDF5\structure\BTreeEntry.vb"

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

    '     Class BTreeEntry
    ' 
    '         Properties: address, key, targetAddress
    ' 
    '         Constructor: (+1 Overloads) Sub New
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



Imports Microsoft.VisualBasic.MIME.application.netCDF.HDF5.IO

Namespace HDF5.[Structure]


    Public Class BTreeEntry

        Private m_address As Long
        Private m_key As Long
        Private m_targetAddress As Long

        Public Sub New([in] As BinaryReader, sb As Superblock, address As Long)
            [in].offset = address

            Me.m_address = address
            Me.m_key = ReadHelper.readL([in], sb)
            Me.m_targetAddress = ReadHelper.readO([in], sb)
        End Sub

        Public Overridable ReadOnly Property address() As Long
            Get
                Return Me.m_address
            End Get
        End Property

        Public Overridable ReadOnly Property targetAddress() As Long
            Get
                Return Me.m_targetAddress
            End Get
        End Property

        Public Overridable ReadOnly Property key() As Long
            Get
                Return Me.m_key
            End Get
        End Property

        Public Overridable Sub printValues()
            Console.WriteLine("BTreeEntry >>>")
            Console.WriteLine("address : " & Me.m_address)
            Console.WriteLine("key : " & Me.m_key)
            Console.WriteLine("target address : " & Me.m_targetAddress)
            Console.WriteLine("BTreeEntry <<<")
        End Sub
    End Class

End Namespace

