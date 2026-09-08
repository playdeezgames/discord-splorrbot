Imports Metaphor.Data

Friend NotInheritable Class HelpCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        'does not require biology
        Return {
            "Commands:",
            "BET: bets an amount of money on a coin flip `BET 1 HEADS` or `BET 1 TAILS`",
            "BUY: buys a commodity using jools `BUY 5 FOOD`",
            "EAT: consumes an item with yer mouth `EAT FOOD`",
            "HELP: shows help (you are here)",
            "INVENTORY: shows inventory",
            "PRICES: list prices for buying commodities",
            "PROMOTE: assuming you have enough XP, you get a promotion",
            "RESPAWN: if yer dead, start over!",
            "STATUS: shows yer status",
            "WORK: you perform demeaning physical labor for low pay"
        }
    End Function
End Class
