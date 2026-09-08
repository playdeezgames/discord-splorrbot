Imports Metaphor.Data
Friend Delegate Function CommandHandler(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
Public Class CommandDispatcher
    Implements ICommandDispatcher
    Private ReadOnly user As UserData
    Private Sub New(
                   user As UserData)
        Me.user = user
    End Sub
    Private Shared ReadOnly tokenHandlers As New Dictionary(Of String, CommandHandler)(StringComparer.CurrentCultureIgnoreCase) From
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
    Public Function HandleCommand(tokens As Queue(Of String)) As IEnumerable(Of String) Implements ICommandDispatcher.HandleCommand
        Dim token As String = Nothing
        If tokens.TryDequeue(token) Then
            Dim handler As CommandHandler = Nothing
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

    Public Shared Function Create(user As UserData) As ICommandDispatcher
        Return New CommandDispatcher(user)
    End Function
End Class
