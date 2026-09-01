Imports System.Runtime.CompilerServices
Imports Metaphor.Data

Friend Module UserExtensions
    <Extension>
    Friend Function IsDead(user As UserData) As Boolean
        Return user.Health <= 0
    End Function
    <Extension>
    Friend Sub DoBiology(user As UserData, amount As Integer, output As List(Of String))
        If user.IsDead() Then Return
        Dim stomach = Math.Min(user.Stomach, amount)
        If stomach > 0 Then
            amount -= stomach
            user.Stomach -= stomach
            output?.Add($"-{stomach} stomach.")
            output?.Add($"Yer stomach is now {user.Stomach}/{user.MaximumStomach}.")
        End If
        If amount > 0 Then
            Dim satiety = Math.Min(user.Satiety, amount)
            amount -= satiety
            If satiety > 0 Then
                user.Satiety -= satiety
                output?.Add($"-{satiety} satiety.")
                output?.Add($"Yer satiety is now {user.Satiety}/{user.MaximumSatiety}.")
            End If
            If amount > 0 Then
                user.Health = Math.Max(0, user.Health - amount)
                output?.Add($"-{amount} health.")
                output?.Add($"Yer health is now {user.Health}/{user.MaximumHealth}.")
            End If
        Else
            If user.Satiety < user.MaximumSatiety Then
                output?.Add($"+1 satiety.")
                user.Satiety += 1
                output?.Add($"Yer satiety is now {user.Satiety}/{user.MaximumSatiety}.")
            Else
                If user.Health < user.MaximumHealth Then
                    output?.Add($"+1 health.")
                    user.Health += 1
                    output?.Add($"Yer health is now {user.Health}/{user.MaximumHealth}.")
                End If
            End If
        End If
    End Sub
End Module
