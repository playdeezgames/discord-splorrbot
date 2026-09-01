Public Class UserData
    Property UserId As UInt64
    Property Jools As Integer = 0
    Property PayRate As Integer = 1
    Property NextWorkTimestamp As DateTimeOffset = DateTimeOffset.Now
    Property XP As Integer = 0
    Property XPGoal As Integer = 10
    Property Stomach As Integer = 0
    Property MaximumStomach As Integer = 50
    Property Satiety As Integer = 100
    Property MaximumSatiety As Integer = 100
    Property Health As Integer = 100
    Property MaximumHealth As Integer = 100
End Class
