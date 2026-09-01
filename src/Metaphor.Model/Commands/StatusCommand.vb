Imports Metaphor.Data

Friend NotInheritable Class StatusCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        'does not require biology
        Return {
            "Status:",
            $"Time: {DateTimeOffset.Now}",
            $"Pay Rate: {user.PayRate}",
            $"Jools: {user.Jools}",
            $"Next Work Time: {user.NextWorkTimestamp}",
            $"XP: {user.XP}/{user.XPGoal}",
            $"Stomach: {user.Stomach}/{user.MaximumStomach}",
            $"Satiety: {user.Satiety}/{user.MaximumSatiety}",
            $"Health: {user.Health}/{user.MaximumHealth}"
            }
    End Function
End Class
