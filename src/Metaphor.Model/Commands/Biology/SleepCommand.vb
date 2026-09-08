Imports Metaphor.Data

Friend NotInheritable Class SleepCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Dim result As New List(Of String) From {
            $"You sleep."
        }
        user.ChangeFatigue(user.Comfort, result)
        user.DoBiology(user.Comfort \ 5, result)
        Return result
    End Function
End Class
