Imports Metaphor.Data

Friend NotInheritable Class StatusCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Return {
            "Status:",
            $"Time: {DateTimeOffset.Now}",
            $"Pay Rate: {user.PayRate}",
            $"Jools: {user.Jools}",
            $"Next Work Time: {user.NextWorkTimestamp}",
            $"XP: {user.XP}/{user.XPGoal}"
            }
    End Function
End Class
