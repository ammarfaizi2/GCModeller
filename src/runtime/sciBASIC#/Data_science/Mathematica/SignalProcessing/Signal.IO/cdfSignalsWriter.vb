﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.IO.netCDF
Imports Microsoft.VisualBasic.Data.IO.netCDF.Components
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math.SignalProcessing
Imports Microsoft.VisualBasic.Net.Http
Imports Microsoft.VisualBasic.Serialization.JSON

''' <summary>
''' cdf writer of the signals
''' </summary>
Public Module cdfSignalsWriter

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="signals"></param>
    ''' <param name="file"></param>
    ''' <param name="description"></param>
    ''' <param name="enableCDFExtension">enable netCDF extension type?</param>
    ''' <returns></returns>
    <Extension>
    Public Function WriteCDF(signals As IEnumerable(Of GeneralSignal), file As String,
                             Optional description$ = Nothing,
                             Optional enableCDFExtension As Boolean = False) As Boolean

        ' 20200704 redesign of the general signal cdf file storage layout:
        ' the previous version of the signal data file is too slow that reading 
        ' in R script code when the signal data count is large

        Using cdffile As New CDFWriter(file)
            Call cdffile.Dimensions(Dimension.Double, Dimension.Float, Dimension.Integer, Dimension.Long, Dimension.Text(fixedChars:=1024))
            Call cdffile.GlobalAttributes(New attribute With {.name = "time", .type = CDFDataTypes.CHAR, .value = Now.ToString})
            Call cdffile.GlobalAttributes(New attribute With {.name = "filename", .type = CDFDataTypes.CHAR, .value = file.FileName})
            Call cdffile.GlobalAttributes(New attribute With {.name = "github", .type = CDFDataTypes.CHAR, .value = LICENSE.githubURL})

            If Not description.StringEmpty Then
                Call cdffile.GlobalAttributes(New attribute With {.name = NameOf(description), .type = CDFDataTypes.CHAR, .value = description})
            End If

            Dim package As GeneralSignal() = signals.ToArray
            Dim chunksize As New List(Of Integer)
            Dim offsets As New List(Of Long)
            Dim dataDimension As Dimension
            Dim attrNames As New List(Of String)
            Dim measures As New List(Of Double)
            Dim signalDatas As New List(Of Double)
            Dim annotation As attribute

            Call cdffile.GlobalAttributes(New attribute With {.name = "signals", .type = CDFDataTypes.INT, .value = package.Length})

            For Each attr As NamedValue(Of CDFData) In package.createAttributes(enableCDFExtension)
                dataDimension = New Dimension With {
                    .name = "attribute_data: " & attr.Name,
                    .size = attr.Value.Length
                }
                annotation = New attribute With {
                    .name = "type",
                    .type = CDFDataTypes.CHAR,
                    .value = attr.Description
                }

                Call cdffile.AddVariable("meta:" & attr.Name, attr.Value, dataDimension, {annotation})
                Call attrNames.Add(attr.Name)
            Next

            Call cdffile.GlobalAttributes(New attribute With {.name = "metadata", .type = CDFDataTypes.CHAR, .value = attrNames.AsEnumerable.GetJson})

            Dim bufferOffset As Long = Scan0
            Dim signal_guid As New CDFData With {.chars = signals.Select(Function(sig) sig.reference).GetJson}
            Dim units As New CDFData With {.chars = signals.Select(Function(sig) sig.measureUnit).GetJson}

            For Each signal As GeneralSignal In signals
                measures.AddRange(signal.Measures)
                signalDatas.AddRange(signal.Strength)
                offsets.Add(bufferOffset)
                chunksize.Add(signal.Measures.Length)

                bufferOffset += signal.Measures.Length
            Next

            dataDimension = New Dimension With {.name = "data_chunks", .size = measures.Count}

            Call cdffile.AddVariable("measure_buffer", New CDFData With {.numerics = measures.ToArray}, dataDimension)
            Call cdffile.AddVariable("signal_buffer", New CDFData With {.numerics = signalDatas.ToArray}, dataDimension)

            dataDimension = New Dimension With {.name = "signals", .size = chunksize.Count}
            cdffile.AddVariable("chunk_size", New CDFData With {.integers = chunksize.ToArray}, dataDimension)

            If enableCDFExtension Then
                Call cdffile.AddVariable("buffer_offset", New CDFData With {.longs = offsets.ToArray}, dataDimension)
            End If

            dataDimension = New Dimension With {.name = "guid_json_chars", .size = signal_guid.chars.Length}
            cdffile.AddVariable("signal_guid", signal_guid, dataDimension)

            dataDimension = New Dimension With {.name = "measure_unit_json_chars", .size = units.chars.Length}
            cdffile.AddVariable("measure_unit", units, dataDimension)
        End Using

        Return True
    End Function

    <Extension>
    Private Iterator Function createAttributes(package As GeneralSignal(), enableCDFExtension As Boolean) As IEnumerable(Of NamedValue(Of CDFData))
        Dim allNames As String() = package.Select(Function(sig) sig.meta.Keys).IteratesALL.Distinct.ToArray

        For Each name As String In allNames
            Dim values As New List(Of String)
            Dim data As CDFData
            Dim type As String

            For Each signal As GeneralSignal In package
                values.Add(signal.meta.TryGetValue(name, [default]:=""))
            Next

            If values.AsParallel.Select(Function(s) s Is Nothing OrElse s = "" OrElse s.IsPattern("\d+")).All(Function(t) t = True) Then
                Dim longs = values.Select(AddressOf Long.Parse).ToArray

                If longs.All(Function(b) b <= 255 AndAlso b >= -255) Then
                    data = New CDFData With {.byteStream = longs.Select(Function(l) CByte(l)).ToBase64String}
                    type = "base64"
                ElseIf longs.All(Function(s) s <= Short.MaxValue AndAlso s >= Short.MinValue) Then
                    data = New CDFData With {.tiny_int = longs.Select(Function(l) CShort(l)).ToArray}
                    type = "int16"
                ElseIf longs.All(Function(i) i <= Integer.MaxValue AndAlso i >= Integer.MinValue) Then
                    data = New CDFData With {.integers = longs.Select(Function(l) CInt(l)).ToArray}
                    type = "i32"
                ElseIf enableCDFExtension Then
                    data = New CDFData With {.longs = longs}
                    type = "i64"
                Else
                    Throw New InvalidProgramException($"{GetType(Long).FullName} is not supports when option '{NameOf(enableCDFExtension)}' is not enable!")
                End If

            ElseIf values.AsParallel.Select(Function(s) s Is Nothing OrElse s = "" OrElse s.IsNumeric).All(Function(t) t = True) Then
                data = New CDFData With {.numerics = values.Select(AddressOf ParseDouble).ToArray}
                type = "f64"
            ElseIf values.AsParallel.Select(Function(s) s Is Nothing OrElse s = "" OrElse s.IsPattern("((true)|(false))", RegexICSng)).All(Function(t) t = True) Then
                If enableCDFExtension Then
                    data = New CDFData With {.flags = values.Select(AddressOf ParseBoolean).ToArray}
                    type = "flags"
                Else
                    data = New CDFData With {.tiny_int = values.Select(AddressOf ParseBoolean).Select(Function(f) CShort(If(f, 1, 0))).ToArray}
                    type = "i16"
                End If
            Else
                data = New CDFData With {.chars = values.AsEnumerable.GetJson}
                type = "json"
            End If

            Yield New NamedValue(Of CDFData) With {
                .Name = name,
                .Value = data,
                .Description = type
            }
        Next
    End Function
End Module