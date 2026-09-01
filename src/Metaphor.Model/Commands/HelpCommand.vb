Imports Metaphor.Data

Friend NotInheritable Class HelpCommand
    Private Sub New() : End Sub

    Friend Shared Function Handle(user As UserData, token As String, tokens As Queue(Of String)) As IEnumerable(Of String)
        Return {
            "Commands:",
            "HELP: shows help (you are here)",
            "PROMOTE: assuming you have enough XP, you get a promotion",
            "STATUS: shows yer status",
            "WORK: you perform demeaning physical labor for low pay"
        }
    End Function
End Class
