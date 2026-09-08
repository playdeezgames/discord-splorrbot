Imports System.Text.RegularExpressions
Imports Metaphor.Data

Friend NotInheritable Class BuyCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Return user.WithBiology(
            Sub(result)
                If tokens.Count = 0 Then
                    result.Add("Buy what? And how many? I have so many questions!")
                    Return
                End If
                Dim quantity As Integer = 1
                If Regex.IsMatch(tokens.Peek(), "^[1-9][0-9]*$") Then
                    quantity = Integer.Parse(tokens.Dequeue)
                End If
                If tokens.Count = 0 Then
                    result.Add($"Buy {quantity} of what?")
                    Return
                End If
                Dim itemName = String.Join(" "c, tokens)
                Dim deets As IItemDeets = Nothing
                If Not ItemDeets.Table.TryGetValue(itemName, deets) Then
                    result.Add($"I don't know what `{itemName}` is.")
                    Return
                End If
                Dim price = quantity * deets.PurchasePrice
                If user.Jools < price Then
                    result.Add($"That would cost {price}, but you only have {user.Jools}, so no sale.")
                    Return
                End If
                result.Add($"You buy {quantity} {itemName}.")
                user.AddItems(itemName, quantity)
                result.Add($"You now have {user.Inventory(itemName)} {itemName}.")
                user.ChangeJools(-price, result)
            End Sub)
    End Function
End Class
