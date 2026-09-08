Imports Metaphor.Data

Friend NotInheritable Class WorkCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Return user.WithBiology(
            Sub(result)
                If user.NextWorkTimestamp > DateTimeOffset.Now Then
                    result.Add($"You cannot work again for {user.NextWorkTimestamp - DateTimeOffset.Now}.")
                    Return
                End If
                result.Add("You work.")
                result.Add("You earn 1 jools.")
                user.Jools += user.PayRate
                user.NextWorkTimestamp = DateTimeOffset.Now.AddMinutes(1.0)
                result.Add($"You now have {user.Jools} jools.")
                result.Add($"You gain 1 XP.")
                user.XP = Math.Min(user.XP + 1, user.XPGoal)
                result.Add($"You how have {user.XP}/{user.XPGoal} XP.")
            End Sub)
    End Function
End Class
