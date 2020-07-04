﻿Imports Microsoft.VisualBasic.Language.Perl
Imports Microsoft.VisualBasic.Linq

Namespace gast

    Module TaxonomyConsensus

        Public Function CalcConsensus(array As Taxonomy(), majority#) As Taxonomy()
            ' Set up variables To store the results
            Dim newTax As String() = {}      ' consensus taxon
            Dim rankCounts As Integer() = {} ' number of different taxa for each rank
            Dim maxPcts As Double() = {}     ' percentage of most popular taxon for each rank
            Dim naPcts As Double() = {}      ' percentage of each rank that has no taxonomy assigned
            Dim conVote As Integer = 0
            Dim taxCount As Integer = array.Length
            Dim minRankIndex As Integer = -1
            Dim minRank As String = "NA"

            ' Correct For percentages 1-100
            If (majority <= 1) Then
                majority = majority * 100
            End If

            ' Calculate the Consensus

            ' Flesh out the taxonomies so they all have indices To 7
            For Each t As Taxonomy In array
                For i As Integer = 0 To 7

                    ' If no value For that depth, add it
                    If t.GetDepth < i Then
                        t(i) = "NA"
                    End If
                Next
            Next

            Dim done As Boolean = False

            ' For each taxonomic rank
            For i As Integer = 0 To 7

                ' Initializes hashes With the counts Of Each tax assignment
                Dim tallies As New Dictionary(Of String, Integer) ' For Each tax value -- how many objects have this taxonomy
                Dim rankCnt = 0                                   ' How many different taxa values are there For that rank
                Dim maxCnt = 0                                    ' what was the size Of the most common taxon
                Dim naCnt = 0                                     ' how many are unassigned 
                Dim topPct = 0                                    ' used To determine If we are done With the taxonomy Or Not

                ' Step through the taxonomies And count them
                For Each t As Taxonomy In array
                    If Not tallies.ContainsKey(t(i)) Then
                        Call tallies.Add(t(i), 0)
                    End If
                    tallies(t(i)) += 1
                Next

                ' For Each unique tax assignment
                For Each k In tallies.Keys

                    If k <> "NA" Then
                        rankCnt += 1
                        minRankIndex = i

                        If tallies(k) > maxCnt Then
                            maxCnt = tallies(k)
                        End If
                    Else
                        naCnt = tallies(k)
                    End If

                    Dim vote = (tallies(k) / taxCount) * 100

                    If ((k <> "NA") AndAlso (vote > topPct)) Then
                        topPct = vote
                    End If

                    ' vote = (100 * (tallies(k) / taxCount) + 0.5)
                    If ((Not done) AndAlso (vote >= majority)) Then
                        Call Push(newTax, k)

                        If k <> "NA" Then
                            conVote = vote
                        End If
                    End If
                Next

                If topPct < majority Then
                    done = True
                End If

                ' If ($#newTax < $i) {push (@newTax, "NA");}
                Call Push(rankCounts, rankCnt)

                If (taxCount > 0) Then
                    Push(maxPcts, (100 * (maxCnt / taxCount) + 0.5))
                    Push(naPcts, (100 * (naCnt / taxCount) + 0.5))
                End If
            Next

            Dim taxReturn As Taxonomy() = {}

            If newTax.Length = 0 Then
                ' If no consensus at all, Call it Unknown
                Push(taxReturn, New Taxonomy("Unknown"))
            Else
                ' taxonomy Object For consensus
                Push(taxReturn, New Taxonomy(newTax))
            End If

            ' If (! $taxReturn[0]) {$taxReturn[0] = "NA";}
            If taxReturn(0) Is Nothing Then
                ' # 20081126 - empty tax should be 'Unknown'
                taxReturn(0) = New Taxonomy("Unknown")
            End If

            ' if ($taxReturn[-1] eq "Unassigned") {pop @taxReturn;} 
            ' If resolvedThen To an Unassigned rank, remove it.
            If taxReturn.Last.TaxonomyString = "Unassigned" Then
                ' If resolved to an Unassigned rank, remove it. -1表示最后一个元素
                Pop(taxReturn)
            End If

            ' winning majority
            taxReturn.Set(1, New Taxonomy(conVote + 0.5))

            If (minRankIndex >= 0) Then
                minRank = Taxonomy.ranks(minRankIndex)
            End If

            taxReturn.Set(2, New Taxonomy(minRank))                                           ' lowest rank With valid assignment
            taxReturn.Set(3, New Taxonomy(rankCounts.Select(Function(x) x.ToString).ToArray)) ' number Of different taxa at Each rank
            taxReturn.Set(4, New Taxonomy(maxPcts.Select(Function(x) x.ToString).ToArray))    ' percentage Of the most popular taxon (!= "NA")
            taxReturn.Set(5, New Taxonomy(naPcts.Select(Function(x) x.ToString).ToArray))     ' percentage that are unassigned ("NA")

            Return taxReturn
        End Function
    End Module
End Namespace