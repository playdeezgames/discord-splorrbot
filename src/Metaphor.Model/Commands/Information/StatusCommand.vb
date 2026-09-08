Imports Metaphor.Data

Friend NotInheritable Class StatusCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        'does not require biology
        Dim nextWorktime = user.NextWorkTimestamp - DateTimeOffset.Now
        Return {
            "Status:",
            $"Pay Rate: {user.PayRate}",
            $"Jools: {user.Jools}",
            $"Next Work Time: {If(nextWorktime < TimeSpan.Zero, "IMMEDIATE", nextWorktime.ToString())}",
            $"XP: {user.XP}/{user.XPGoal}",
            $"Stomach: {user.Stomach}/{user.MaximumStomach}",
            $"Satiety: {user.Satiety}/{user.MaximumSatiety}",
            $"Health: {user.Health}/{user.MaximumHealth}",
            $"Energy: {user.Energy}/{user.MaximumEnergy}"
            }
    End Function
End Class
