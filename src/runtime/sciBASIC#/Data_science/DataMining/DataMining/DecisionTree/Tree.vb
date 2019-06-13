Imports System.Runtime.CompilerServices

Namespace DecisionTree

    ''' <summary>
    ''' Implementation of the ID3 to create a decision tree
    ''' 
    ''' > https://github.com/WolfgangOfner/DecisionTree
    ''' </summary>
    Public Class Tree

        Public Property root As TreeNode

        ''' <summary>
        ''' Create a new empty ID3 based decision tree.
        ''' </summary>
        Sub New()
        End Sub

        ''' <summary>
        ''' Create a new decision tree and train for <see cref="root"/>.
        ''' </summary>
        ''' <param name="data"></param>
        Sub New(data As DataTable)
            root = Tree.Learn(data)
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function CalculateResult(valuesForQuery As IDictionary(Of String, String), Optional result As String = "") As String
            Return CalculateResult(root, valuesForQuery, result)
        End Function

        Public Shared Function CalculateResult(root As TreeNode, valuesForQuery As IDictionary(Of String, String), result As String) As String
            Dim valueFound = False

            result += root.name.ToUpper() & " -- "

            If root.isLeaf Then
                result = root.edge.ToLower() & " --> " & root.name.ToUpper()
                valueFound = True
            Else
                For Each childNode In root.childNodes
                    For Each entry In valuesForQuery
                        If childNode.edge.ToUpper().Equals(entry.Value.ToUpper()) AndAlso root.name.ToUpper().Equals(entry.Key.ToUpper()) Then
                            valuesForQuery.Remove(entry.Key)

                            Return result & CalculateResult(childNode, valuesForQuery, $"{childNode.edge.ToLower()} --> ")
                        End If
                    Next
                Next
            End If

            ' if the user entered an invalid attribute
            If Not valueFound Then
                result = "Attribute not found"
            End If

            Return result
        End Function

        ''' <summary>
        ''' Create tree of <see cref="root"/>
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function Learn(data As DataTable) As TreeNode
            Return Algorithm.Learn(data, "")
        End Function
    End Class
End Namespace