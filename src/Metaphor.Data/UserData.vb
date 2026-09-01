Public Class UserData
    Property UserId As UInt64
    Property Jools As Integer = 0
    Property PayRate As Integer = 1
    Property NextWorkTimestamp As DateTimeOffset = DateTimeOffset.Now
    Property XP As Integer = 0
    Property XPGoal As Integer = 10
End Class
