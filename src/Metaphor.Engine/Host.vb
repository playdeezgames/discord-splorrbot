Imports Metaphor.Model
Imports Metaphor.Store

Public Class Host
    Private ReadOnly store As IStore

    Private Sub New(store As IStore)
        Me.store = store
    End Sub
    Public Function HandleMessage(userId As UInt64, message As String) As String
        Dim data = store.ReadUserData(userId)
        Dim result = String.Join(
            vbCrLf,
            UserModel.Create(data).
                HandleCommand(
                    New Queue(Of String)(message.Split(" "c))))
        store.WriteUserdata(data)
        Return result
    End Function
    Public Shared Function Create(store As IStore) As Host
        Return New Host(store)
    End Function
End Class
