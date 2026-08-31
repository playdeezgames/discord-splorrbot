Imports Metaphor.Data

Public Class User
    Implements IUser
    Private ReadOnly userData As UserData

    Private Sub New(userData As UserData)
        Me.userData = userData
    End Sub

    Public ReadOnly Property Identifier As ULong Implements IUser.Identifier
        Get
            Return userData.UserId
        End Get
    End Property

    Public Property Counter As Integer Implements IUser.Counter
        Get
            Return userData.Counter
        End Get
        Set(value As Integer)
            userData.Counter = value
        End Set
    End Property

    Public Shared Function Create(userData As UserData) As IUser
        Return New User(userData)
    End Function
End Class
