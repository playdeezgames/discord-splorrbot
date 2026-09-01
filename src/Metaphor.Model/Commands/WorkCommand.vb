Imports Metaphor.Data

Friend NotInheritable Class WorkCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        If user.NextWorkTimestamp > DateTimeOffset.Now Then
            Return {
                $"You cannot work again until {user.NextWorkTimestamp}."
                }
        End If
        Dim result As New List(Of String) From {
            "You work.",
            "You earn 1 jools."
        }
        user.Jools += user.PayRate
        user.NextWorkTimestamp = DateTimeOffset.Now.AddMinutes(1.0)
        result.Add($"You now have {user.Jools} jools.")
        result.Add($"You gain 1 XP.")
        user.XP = Math.Min(user.XP + 1, user.XPGoal)
        result.Add($"You how have {user.XP}/{user.XPGoal} XP.")
        Return result
    End Function
End Class
