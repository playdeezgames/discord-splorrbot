Imports System.Text.RegularExpressions
Imports Metaphor.Data

Friend NotInheritable Class BuyCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Dim result As New List(Of String)
        If tokens.Count = 0 Then
            result.Add("Buy what? And how many? I have so many questions!")
        Else
            Dim quantity As Integer = 1
            If Regex.IsMatch(tokens.Peek(), "^[1-9][0-9]*$") Then
                quantity = Integer.Parse(tokens.Dequeue)
            End If
            If tokens.Count = 0 Then
                result.Add($"Buy {quantity} of what?")
            Else
                Dim itemName = String.Join(" "c, tokens)
                Dim deets As IItemDeets = Nothing
                If ItemDeets.Table.TryGetValue(itemName, deets) Then
                    Dim price = quantity * deets.PurchasePrice
                    If user.Jools >= price Then
                        result.Add($"You buy {quantity} {itemName}.")
                        user.AddItems(itemName, quantity)
                        user.Jools -= price
                        result.Add($"You pay {price} jools.")
                        result.Add($"You now have {user.Jools} jools.")
                    Else
                        result.Add($"That would cost {price}, but you only have {user.Jools}, so no sale.")
                    End If
                Else
                    result.Add($"I don't know what `{itemName}` is.")
                End If
            End If
        End If
        Return result
    End Function
End Class
