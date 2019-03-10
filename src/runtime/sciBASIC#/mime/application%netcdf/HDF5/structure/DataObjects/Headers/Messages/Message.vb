﻿#Region "Microsoft.VisualBasic::5d028855e4e914130abf2fd538257f9c, mime\application%netcdf\HDF5\structure\DataObjects\Headers\Messages\Message.vb"

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

    '     Class Message
    ' 
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Namespace HDF5.[Structure]

    ''' <summary>
    ''' Data object header messages are small pieces of metadata that are stored in the 
    ''' data object header for each object in an HDF5 file. Data object header messages 
    ''' provide the metadata required to describe an object and its contents, as well as 
    ''' optional pieces of metadata that annotate the meaning or purpose of the object.
    '''
    ''' Data object header messages are either stored directly in the data object header 
    ''' for the object Or are shared between multiple objects in the file. When a message 
    ''' Is shared, a flag in the Message Flags indicates that the actual Message Data 
    ''' portion of that message Is stored in another location (such as another data object 
    ''' header, Or a heap in the file) And the Message Data field contains the information 
    ''' needed to locate the actual information for the message.
    ''' </summary>
    Public MustInherit Class Message

    End Class
End Namespace
