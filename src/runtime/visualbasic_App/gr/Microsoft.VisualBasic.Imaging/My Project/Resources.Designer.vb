﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Microsoft.VisualBasic.Imaging.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to {  
        '''  &quot;Spectral&quot;: {
        '''    &quot;3&quot;: [ &quot;rgb(252,141,89)&quot;, &quot;rgb(255,255,191)&quot;, &quot;rgb(153,213,148)&quot; ],
        '''    &quot;4&quot;: [ &quot;rgb(215,25,28)&quot;, &quot;rgb(253,174,97)&quot;, &quot;rgb(171,221,164)&quot;, &quot;rgb(43,131,186)&quot; ],
        '''    &quot;5&quot;: [ &quot;rgb(215,25,28)&quot;, &quot;rgb(253,174,97)&quot;, &quot;rgb(255,255,191)&quot;, &quot;rgb(171,221,164)&quot;, &quot;rgb(43,131,186)&quot; ],
        '''    &quot;6&quot;: [ &quot;rgb(213,62,79)&quot;, &quot;rgb(252,141,89)&quot;, &quot;rgb(254,224,139)&quot;, &quot;rgb(230,245,152)&quot;, &quot;rgb(153,213,148)&quot;, &quot;rgb(50,136,189)&quot; ],
        '''    &quot;7&quot;: [ &quot;rgb(213,62,79)&quot;, &quot;rgb(252,141,89)&quot;, &quot;rgb(254,224,139)&quot;, &quot;rgb(255,255,191)&quot;, &quot;rgb( [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property colorbrewer() As String
            Get
                Return ResourceManager.GetString("colorbrewer", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property DefaultTexture() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("DefaultTexture", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to {  
        '''  &quot;DarkSeaGreen&quot;: [ &quot;LightYellow&quot;, &quot;Snow&quot;, &quot;Khaki&quot;, &quot;White&quot;, &quot;LightBlue&quot;, &quot;LemonChiffon&quot;, &quot;Wheat&quot;, &quot;Aqua&quot;, &quot;MintCream&quot;, &quot;PowderBlue&quot;, &quot;WhiteSmoke&quot;, &quot;Aquamarine&quot;, &quot;Moccasin&quot;, &quot;LightGrey&quot;, &quot;Turquoise&quot;, &quot;PaleGoldenrod&quot;, &quot;Azure&quot;, &quot;LightCyan&quot;, &quot;Silver&quot;, &quot;PapayaWhip&quot;, &quot;Ivory&quot;, &quot;OldLace&quot;, &quot;MediumAquamarine&quot;, &quot;MediumSpringGreen&quot;, &quot;Linen&quot;, &quot;SkyBlue&quot;, &quot;BlanchedAlmond&quot;, &quot;Cornsilk&quot;, &quot;PeachPuff&quot;, &quot;PaleGreen&quot;, &quot;MediumTurquoise&quot;, &quot;Cyan&quot;, &quot;Honeydew&quot;, &quot;DarkTurquoise&quot;, &quot;MistyRose&quot;, &quot;LightSkyBlue&quot;, &quot;DarkSeaGreen&quot;, &quot;Pink&quot; [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property designer_colors() As String
            Get
                Return ResourceManager.GetString("designer_colors", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
