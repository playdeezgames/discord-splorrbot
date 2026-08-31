Imports Metaphor.Store

Public Class UserModel
    Implements IUserModel
    Private ReadOnly user As IUser
    Private Sub New(
                   user As IUser)
        Me.user = user
    End Sub
    Public Function HandleCommand(tokens As Queue(Of String)) As IEnumerable(Of String) Implements IUserModel.HandleCommand
        user.Counter += 1
        Return {$"Counter is now {user.Counter}."}
    End Function
    Public Shared Function Create(user As IUser) As IUserModel
        Return New UserModel(user)
    End Function
End Class
