Imports Metaphor.Data

Friend Class ItemDeets
    Implements IItemDeets
    Private Sub New(
                   name As String,
                   Optional purchasePrice As Integer = 0,
                   Optional onEat As EatHandler = Nothing)
        Me.Name = name
        Me.PurchasePrice = purchasePrice
        Me.OnEat = onEat
    End Sub
    Public ReadOnly Property Name As String Implements IItemDeets.Name

    Public ReadOnly Property PurchasePrice As Integer Implements IItemDeets.PurchasePrice

    Public ReadOnly Property CanEat As Boolean Implements IItemDeets.CanEat
        Get
            Return OnEat IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property OnEat As EatHandler Implements IItemDeets.OnEat

    Friend Shared ReadOnly Table As IReadOnlyDictionary(Of String, IItemDeets) =
        New List(Of IItemDeets) From
        {
            New ItemDeets("Food", purchasePrice:=5, onEat:=AddressOf EatFood)
        }.ToDictionary(Function(x) x.Name, Function(x) x, StringComparer.CurrentCultureIgnoreCase)

    Private Shared Sub EatFood(user As UserData, result As List(Of String))
        user.ChangeStomach(25, result)
        result.Add("Yum!")
    End Sub
End Class
