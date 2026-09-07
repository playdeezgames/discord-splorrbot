Friend Class ItemDeets
    Implements IItemDeets
    Private Sub New(name As String, purchasePrice As Integer)
        Me.Name = name
        Me.PurchasePrice = purchasePrice
    End Sub
    Public ReadOnly Property Name As String Implements IItemDeets.Name

    Public ReadOnly Property PurchasePrice As Integer Implements IItemDeets.PurchasePrice

    Friend Shared ReadOnly Table As IReadOnlyDictionary(Of String, IItemDeets) =
        New List(Of IItemDeets) From
        {
            New ItemDeets("Food", 5)
        }.ToDictionary(Function(x) x.Name, Function(x) x, StringComparer.CurrentCultureIgnoreCase)
End Class
