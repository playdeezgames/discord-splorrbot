Imports Metaphor.Data
Imports Metaphor.Model.PromoteCommand
Friend Delegate Function TokenHandler(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
Public Class UserModel
    Implements IUserModel
    Private ReadOnly user As UserData
    Private Sub New(
                   user As UserData)
        Me.user = user
    End Sub
    Private Shared ReadOnly tokenHandlers As New Dictionary(Of String, TokenHandler)(StringComparer.CurrentCultureIgnoreCase) From
        {
            {Commands.BET, AddressOf BetCommand.Handle},
            {Commands.BUY, AddressOf BuyCommand.Handle},
            {Commands.HELP, AddressOf HelpCommand.Handle},
            {Commands.INVENTORY, AddressOf InventoryCommand.Handle},
            {Commands.PRICES, AddressOf PricesCommand.Handle},
            {Commands.PROMOTE, AddressOf PromoteCommand.Handle},
            {Commands.RESPAWN, AddressOf RespawnCommand.Handle},
            {Commands.STATUS, AddressOf StatusCommand.Handle},
            {Commands.WORK, AddressOf WorkCommand.Handle}
        }
    Public Function HandleCommand(tokens As Queue(Of String)) As IEnumerable(Of String) Implements IUserModel.HandleCommand
        Dim token As String = Nothing
        If tokens.TryDequeue(token) Then
            Dim handler As TokenHandler = Nothing
            If tokenHandlers.TryGetValue(token, handler) Then
                Return handler.Invoke(user, token, tokens)
            End If
        End If
        Return InvalidCommand()
    End Function

    Public Shared Function InvalidCommand() As IEnumerable(Of String)
        Return {"Invalid command try `HELP`."}
    End Function

    Public Shared Function YerDead() As IEnumerable(Of String)
        Return {"Dead people can't do that. Try `RESPAWN`."}
    End Function


    Friend Shared Function WithBiology(user As UserData, biologyDelegate As BiologyDelegate) As IEnumerable(Of String)
        Dim result As New List(Of String)
        user.DoBiology(1, result)
        If user.IsDead() Then
            result.AddRange(UserModel.YerDead())
            Return result
        End If
        biologyDelegate(result)
        Return result
    End Function

    Public Shared Function Create(user As UserData) As IUserModel
        Return New UserModel(user)
    End Function
End Class
