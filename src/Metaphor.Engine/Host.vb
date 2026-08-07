Public Module Host
    Public Function HandleMessage(userId As UInt64, message As String) As String
        Return $"ISWORX! {userId} `{message}`"
    End Function
End Module
