﻿
Imports System.IO
Imports System.Runtime.CompilerServices
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Dynamics.Engine
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Dynamics.Engine.ModelLoader
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Model

Namespace Raw

    Public Class StorageDriver : Implements IDisposable, IOmicsDataAdapter

        ReadOnly output As Writer

        Public ReadOnly Property mass As OmicsTuple(Of String()) Implements IOmicsDataAdapter.mass

        Sub New(output$, loader As Loader, model As CellularModule)
            Me.output = New Writer(loader, model, output.Open(FileMode.OpenOrCreate, doClear:=True)).Init
            Me.mass = New OmicsTuple(Of String())(transcriptome, proteome, metabolome)
        End Sub

        Private Function transcriptome() As String()
            Return output.mRNAId.Objects.AsList + output.RNAId.Objects
        End Function

        Private Function proteome() As String()
            Return output.Polypeptide.Objects
        End Function

        Private Function metabolome() As String()
            Return output.Metabolites.Objects
        End Function

        Public Sub MassSnapshot(iteration As Integer, data As Dictionary(Of String, Double)) Implements IOmicsDataAdapter.MassSnapshot
            Call output.Write(NameOf(Writer.Metabolites), iteration, snapshot:=data)
            Call output.Write(NameOf(Writer.mRNAId), iteration, snapshot:=data)
            Call output.Write(NameOf(Writer.Polypeptide), iteration, snapshot:=data)
            Call output.Write(NameOf(Writer.Proteins), iteration, snapshot:=data)
            Call output.Write(NameOf(Writer.RNAId), iteration, snapshot:=data)
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Sub FluxSnapshot(iteration As Integer, data As Dictionary(Of String, Double)) Implements IOmicsDataAdapter.FluxSnapshot
            Call output.Write(NameOf(Writer.Reactions), iteration, snapshot:=data)
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    Call output.Dispose()
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub

#End Region

    End Class
End Namespace