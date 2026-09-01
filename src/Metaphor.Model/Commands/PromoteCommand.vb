Imports Metaphor.Data

Friend NotInheritable Class PromoteCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Dim result As New List(Of String)
        user.DoBiology(1, result)
        If user.IsDead() Then
            result.AddRange(UserModel.YerDead())
            Return result
        End If
        If user.XP < user.XPGoal Then
            result.Add(
                "You don't have enough XP!")
            Return result
        End If

        result.Add("Yer pay rate increases by 1!")
        user.PayRate += 1
        result.Add($"Yer new pay rate is {user.PayRate}.")
        user.XP = 0
        user.XPGoal *= 2
        result.Add($"XP: {user.XP}/{user.XPGoal}")
        Return result
    End Function
End Class
