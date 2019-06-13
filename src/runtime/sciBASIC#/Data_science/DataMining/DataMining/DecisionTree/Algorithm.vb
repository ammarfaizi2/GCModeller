﻿Namespace DecisionTree

    ''' <summary>
    ''' Algorithm module for train a new decision tree model
    ''' </summary>
    Module Algorithm

        ''' <summary>
        ''' Create tree of <see cref="Tree.root"/>
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="edgeName"></param>
        ''' <returns></returns>
        Public Function Learn(data As DataTable, Optional edgeName As String = "") As TreeNode
            Dim root As TreeNode = GetRootNode(data, edgeName)

            For Each item In root.nodeAttr.differentAttributeNames
                ' if a leaf, leaf will be added in this method
                Dim isLeaf = CheckIfIsLeaf(root, data, item)

                ' make a recursive call as long as the node is not a leaf
                If Not isLeaf Then
                    Dim reducedTable = CreateSmallerTable(data, item, root.index)

                    root.childNodes.Add(Learn(reducedTable, item))
                End If
            Next

            Return root
        End Function

        Private Function CheckIfIsLeaf(root As TreeNode, data As DataTable, attributeToCheck As String) As Boolean
            Dim isLeaf = True
            Dim allEndValues = New List(Of String)()

            ' get all leaf values for the attribute in question
            For i As Integer = 0 To data.Rows.Count - 1
                If data.Rows(i)(root.index).ToString().Equals(attributeToCheck) Then
                    allEndValues.Add(data.Rows(i)(data.Columns.Count - 1).ToString())
                End If
            Next

            ' check whether all elements of the list have the same value
            If allEndValues.Count > 0 AndAlso allEndValues.Any(Function(x) x <> allEndValues(0)) Then
                isLeaf = False
            End If

            ' create leaf with value to display and edge to the leaf
            If isLeaf Then
                root.childNodes.Add(New TreeNode(True, allEndValues(0), attributeToCheck))
            End If

            Return isLeaf
        End Function

        Private Function CreateSmallerTable(data As DataTable, edgePointingToNextNode As String, rootTableIndex As Integer) As DataTable
            Dim smallerData = New DataTable()

            ' add column titles
            For i As Integer = 0 To data.Columns.Count - 1
                smallerData.Columns.Add(data.Columns(i).ToString())
            Next

            ' add rows which contain edgePointingToNextNode to new datatable
            For i As Integer = 0 To data.Rows.Count - 1
                If data.Rows(i)(rootTableIndex).ToString().Equals(edgePointingToNextNode) Then
                    Dim row = New String(data.Columns.Count - 1) {}

                    For j As Integer = 0 To data.Columns.Count - 1
                        row(j) = data.Rows(i)(j).ToString()
                    Next

                    smallerData.Rows.Add(row)
                End If
            Next

            ' remove column which was already used as node            
            smallerData.Columns.Remove(smallerData.Columns(rootTableIndex))

            Return smallerData
        End Function

        Private Function GetRootNode(data As DataTable, edge As String) As TreeNode
            Dim attributes = New List(Of NodeAttr)()
            Dim highestInformationGainIndex = -1
            Dim highestInformationGain = Double.MinValue

            ' Get all names, amount of attributes and attributes for every column             
            For i As Integer = 0 To data.Columns.Count - 2
                Dim differentAttributenames = NodeAttr.GetDifferentAttributeNamesOfColumn(data, i)
                attributes.Add(New NodeAttr(data.Columns(i).ToString(), differentAttributenames))
            Next

            ' Calculate Entropy (S)
            Dim tableEntropy = CalculateTableEntropy(data)

            For i As Integer = 0 To attributes.Count - 1
                attributes(i).InformationGain = GetGainForAllAttributes(data, i, tableEntropy)

                If attributes(i).InformationGain > highestInformationGain Then
                    highestInformationGain = attributes(i).InformationGain
                    highestInformationGainIndex = i
                End If
            Next

            Return New TreeNode(attributes(highestInformationGainIndex).name, highestInformationGainIndex, attributes(highestInformationGainIndex), edge)
        End Function

        Private Function GetGainForAllAttributes(data As DataTable, colIndex As Integer, entropyOfDataset As Double) As Double
            Dim totalRows = data.Rows.Count
            Dim amountForDifferentValue = GetAmountOfEdgesAndTotalPositivResults(data, colIndex)
            Dim stepsForCalculation = New List(Of Double)()

            For Each item In amountForDifferentValue
                ' helper for calculation
                Dim firstDivision = item(0, 1) / CDbl(item(0, 0))
                Dim secondDivision = (item(0, 0) - item(0, 1)) / CDbl(item(0, 0))

                ' prevent dividedByZeroException
                If firstDivision = 0 OrElse secondDivision = 0 Then
                    stepsForCalculation.Add(0.0)
                Else
                    stepsForCalculation.Add(-firstDivision * Math.Log(firstDivision, 2) - secondDivision * Math.Log(secondDivision, 2))
                End If
            Next

            Dim gain = stepsForCalculation.[Select](Function(t, i) amountForDifferentValue(i)(0, 0) / CDbl(totalRows) * t).Sum()

            gain = entropyOfDataset - gain

            Return gain
        End Function

        Private Function CalculateTableEntropy(data As DataTable) As Double
            Dim totalRows = data.Rows.Count
            Dim amountForDifferentValue = GetAmountOfEdgesAndTotalPositivResults(data, data.Columns.Count - 1)

            Dim stepsForCalculation = amountForDifferentValue.[Select](Function(item) item(0, 0) / CDbl(totalRows)).[Select](Function(division) -division * Math.Log(division, 2)).ToList()

            Return stepsForCalculation.Sum()
        End Function

        Private Function GetAmountOfEdgesAndTotalPositivResults(data As DataTable, indexOfColumnToCheck As Integer) As List(Of Integer(,))
            Dim foundValues = New List(Of Integer(,))()
            Dim knownValues = CountKnownValues(data, indexOfColumnToCheck)

            For Each item In knownValues
                Dim amount = 0
                Dim positiveAmount = 0

                For i As Integer = 0 To data.Rows.Count - 1
                    If data.Rows(i)(indexOfColumnToCheck).ToString().Equals(item) Then
                        amount += 1

                        ' Counts the positive cases and adds the sum later to the array for the calculation
                        If data.Rows(i)(data.Columns.Count - 1).ToString().Equals(data.Rows(0)(data.Columns.Count - 1)) Then
                            positiveAmount += 1
                        End If
                    End If
                Next

                Dim array As Integer(,) = {{amount, positiveAmount}}
                foundValues.Add(array)
            Next

            Return foundValues
        End Function

        Private Function CountKnownValues(data As DataTable, indexOfColumnToCheck As Integer) As IEnumerable(Of String)
            Dim knownValues = New List(Of String)()

            ' add the value of the first row to the list
            If data.Rows.Count > 0 Then
                knownValues.Add(data.Rows(0)(indexOfColumnToCheck).ToString())
            End If

            For j As Integer = 1 To data.Rows.Count - 1
                Dim index = j
                Dim newValue = knownValues.All(Function(item) Not data.Rows(index)(indexOfColumnToCheck).ToString().Equals(item))

                If newValue Then
                    knownValues.Add(data.Rows(j)(indexOfColumnToCheck).ToString())
                End If
            Next

            Return knownValues
        End Function
    End Module
End Namespace