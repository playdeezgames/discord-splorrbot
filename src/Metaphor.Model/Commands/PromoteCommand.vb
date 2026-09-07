Imports Metaphor.Data

Friend NotInheritable Class PromoteCommand
    Private Sub New() : End Sub

    Delegate Sub BiologyDelegate(result As List(Of String))

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Return UserModel.WithBiology(
            user,
            Sub(result)
                If user.XP < user.XPGoal Then
                    result.Add("You don't have enough XP!")
                    Return
                End If
                result.Add("Yer pay rate increases by 1!")
                user.PayRate += 1
                result.Add($"Yer new pay rate is {user.PayRate}.")
                user.XP = 0
                user.XPGoal *= 2
                result.Add($"XP: {user.XP}/{user.XPGoal}")
            End Sub)
    End Function
End Class
