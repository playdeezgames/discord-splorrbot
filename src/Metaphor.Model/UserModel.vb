Public Class UserModel
    Implements IUserModel

    Private ReadOnly userId As ULong

    Private Sub New(userId As UInt64)
        Me.userId = userId
    End Sub

    Public Function HandleCommand(tokens As Queue(Of String)) As IEnumerable(Of String) Implements IUserModel.HandleCommand
        Return {"Invalid Command!"}
    End Function

    Public Shared Function Create(userId As ULong) As IUserModel
        Return New UserModel(userId)
    End Function
End Class
