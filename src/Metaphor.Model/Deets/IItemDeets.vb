Imports Metaphor.Data

Public Delegate Sub EatHandler(user As UserData, result As List(Of String))
Public Interface IItemDeets
    ReadOnly Property Name As String
    ReadOnly Property PurchasePrice As Integer
    ReadOnly Property CanEat As Boolean
    ReadOnly Property OnEat As EatHandler
End Interface
