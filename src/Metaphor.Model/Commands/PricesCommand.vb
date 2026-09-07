Imports Metaphor.Data

Friend NotInheritable Class PricesCommand
    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        'no biology
        Dim result As New List(Of String) From {
            "Prices:"
        }
        For Each entry In ItemDeets.Table.Values.Where(Function(x) x.PurchasePrice > 0)
            result.Add($"- {entry.Name} ({entry.PurchasePrice} jools)")
        Next
        Return result
    End Function
End Class
