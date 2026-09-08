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
    Property Inventory As New Dictionary(Of String, Integer)(StringComparer.CurrentCultureIgnoreCase)
    Property Energy As Integer = 100
    Property MaximumEnergy As Integer = 100
    Property Comfort As Integer = 25
    Public Sub AddItems(itemName As String, delta As Integer)
        Dim quantity As Integer = 0
        If Inventory.TryGetValue(itemName, quantity) Then
            quantity += delta
        Else
            quantity = delta
        End If
        If quantity > 0 Then
            Inventory(itemName) = quantity
        Else
            Inventory.Remove(itemName)
        End If
    End Sub
End Class
