Imports Metaphor.Data

Friend NotInheritable Class BetCommand
    Private Sub New() : End Sub

    Private Const HEADS As String = NameOf(HEADS)
    Private Const TAILS As String = NameOf(TAILS)

    Private Shared ReadOnly generator As New Dictionary(Of String, Integer) From
        {
            {HEADS, 1},
            {TAILS, 1}
        }

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Dim result As New List(Of String)
        user.DoBiology(1, result)
        If user.IsDead() Then
            result.AddRange(UserModel.YerDead())
            Return result
        End If
        Dim bet As Integer = 0
        If tokens.Count <> 2 OrElse
            Not Integer.TryParse(tokens.Dequeue(), bet) OrElse
            bet <= 0 OrElse
            bet > user.Jools Then
            result.AddRange(UserModel.InvalidCommand())
            Return result
        End If
        Dim coin = RNG.FromGenerator(generator)
        result.Add($"Result: {coin}")
        Dim choice = tokens.Dequeue
        If String.Equals(coin, choice, StringComparison.CurrentCultureIgnoreCase) Then
            result.Add($"You win {bet} jools!")
            user.Jools += bet
        Else
            result.Add($"You lose {bet} jools!")
            user.Jools -= bet
        End If
        result.Add($"You now have {user.Jools} jools.")
        Return result
    End Function
End Class
