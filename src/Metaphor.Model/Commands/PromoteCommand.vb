Imports Metaphor.Data

Friend NotInheritable Class PromoteCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        If user.XP < user.XPGoal Then
            Return {
                "You don't have enough XP!"
                }
        End If

        Dim result As New List(Of String) From {
            "Yer pay rate increases by 1!"
        }
        user.PayRate += 1
        result.Add($"Yer new pay rate is {user.PayRate}.")
        user.XP = 0
        user.XPGoal *= 2
        result.Add($"XP: {user.XP}/{user.XPGoal}")
        Return result
    End Function
End Class
