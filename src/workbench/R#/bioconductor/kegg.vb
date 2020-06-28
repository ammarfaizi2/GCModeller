﻿
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports RDotNET.Extensions.GCModeller
Imports SMRUCC.genomics.Assembly.KEGG.WebServices
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Components
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime.Interop

<Package("kegg")>
Module kegg

    <ExportAPI("write.keggMap.rds")>
    Public Function writeKeggMaps(<RRawVectorArgument> maps As Object, saveRDS As String, Optional env As Environment = Nothing) As Message
        Dim kegg As pipeline = pipeline.TryCreatePipeline(Of Map)(maps, env)

        If kegg.isError Then
            Return kegg.getError
        Else
            Call kegg.populates(Of Map).WriteMaps(saveRDS)
        End If

        Return Nothing
    End Function
End Module
