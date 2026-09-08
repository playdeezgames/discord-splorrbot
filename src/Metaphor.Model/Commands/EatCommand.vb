Imports Metaphor.Data

Friend NotInheritable Class EatCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Dim result As New List(Of String)
        If user.IsDead Then
            result.Add("Dead people don't eat. Dead people are eaten. Yum.")
            Return result
        End If
        If tokens.Count = 0 Then
            result.Add("What do you plan on eating?")
            Return result
        End If
        Dim itemname = String.Join(" "c, tokens)
        Dim deets As IItemDeets = Nothing
        If Not ItemDeets.Table.TryGetValue(itemname, deets) Then
            result.Add($"WTF is `{itemname}`?")
            Return result
        End If
        Dim quantity As Integer = 0
        If Not user.Inventory.TryGetValue(itemname, quantity) OrElse quantity <= 0 Then
            result.Add($"You ain't got any `{itemname}`.")
            Return result
        End If
        If Not deets.CanEat Then
            result.Add($"You can't eat that.")
            Return result
        End If
        user.AddItems(itemname, -1)
        result.Add($"You lose 1 {itemname}.")
        deets.OnEat.Invoke(user, result)
        Return result
    End Function
End Class
