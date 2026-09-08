Imports System.Runtime.CompilerServices
Imports Metaphor.Data
Imports Metaphor.Model.PromoteCommand

Friend Module UserDataExtensions
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
    <Extension>
    Friend Sub ChangeFatigue(user As UserData, delta As Integer, result As List(Of String))
        If delta = 0 Then
            Return
        End If
        result?.Add($"You {If(delta > 0, "gain", "lose")} {Math.Abs(delta)} energy.")
        user.Energy = Math.Clamp(user.Energy + delta, 0, user.MaximumEnergy)
        result?.Add($"You now have {user.Energy}/{user.MaximumEnergy} energy.")
    End Sub
    <Extension>
    Friend Function WithEffort(user As UserData, biologyDelegate As BiologyDelegate, Optional amount As Integer = 1) As IEnumerable(Of String)
        If user.Energy < amount Then
            Return {$"You are too tired to do that."}
        End If
        Dim result As New List(Of String)
        user.ChangeFatigue(-amount, result)
        Return result.Concat(WithBiology(user, biologyDelegate, amount))
    End Function
    <Extension>
    Friend Function WithBiology(user As UserData, biologyDelegate As BiologyDelegate, Optional amount As Integer = 1) As IEnumerable(Of String)
        Dim result As New List(Of String)
        user.DoBiology(amount, result)
        If user.IsDead() Then
            result.AddRange(CommandDispatcher.YerDead())
            Return result
        End If
        biologyDelegate(result)
        Return result
    End Function
    <Extension>
    Friend Sub ChangeJools(user As UserData, delta As Integer, result As List(Of String))
        If delta <> 0 Then
            result?.Add($"You {If(delta > 0, "gain", "lose")} {Math.Abs(delta)} jools.")
            user.Jools += delta
            result?.Add($"You now have {user.Jools} jools.")
        End If
    End Sub
    <Extension>
    Friend Sub ChangeStomach(user As UserData, delta As Integer, result As List(Of String))
        If delta = 0 Then
            Return
        End If
        result?.Add($"You {If(delta > 0, "gain", "lose")} {Math.Abs(delta)} stomach.")
        user.Stomach = Math.Clamp(user.Stomach + delta, 0, user.MaximumStomach)
        result?.Add($"You now have {user.Stomach}/{user.MaximumStomach} stomach.")
    End Sub
End Module
