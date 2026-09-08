Imports Metaphor.Data

Friend NotInheritable Class RespawnCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        'requires a LACK of biology
        If Not user.IsDead Then
            Return {"Yer not dead!"}
        End If
        user.Stomach = 0
        user.Satiety = user.MaximumSatiety \ 2
        user.Health = user.MaximumHealth \ 2
        user.Jools \= 2
        Return StatusCommand.Handle(user, token, tokens)
    End Function
End Class
