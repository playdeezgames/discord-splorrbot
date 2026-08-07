Imports Metaphor.Model

Public Module Host
    Public Function HandleMessage(userId As UInt64, message As String) As String
        Return String.Join(
            vbCrLf,
            UserModel.Create(userId).
                HandleCommand(
                    New Queue(Of String)(message.Split(" "c))))
    End Function
End Module
