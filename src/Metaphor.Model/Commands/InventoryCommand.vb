Imports Metaphor.Data

Friend NotInheritable Class InventoryCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Dim result As New List(Of String) From {
            "Inventory:"
        }
        If user.Inventory.Count <> 0 Then
            For Each entry In user.Inventory
                result.Add($"- {entry.Key}(x{entry.Value})")
            Next
        Else
            result.Add("- Nothing")
        End If
        Return result
    End Function
End Class
