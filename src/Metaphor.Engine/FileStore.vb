Imports System.IO
Imports System.Text.Json
Imports Metaphor.Data
Imports Metaphor.Store

Public Class FileStore
    Implements IStore
    Private Sub New()

    End Sub

    Public Sub WriteUserdata(userData As UserData) Implements IStore.WriteUserdata
        File.WriteAllText($"{userData.UserId}.json", JsonSerializer.Serialize(userData))
    End Sub

    Public Shared Function Create() As IStore
        Return New FileStore()
    End Function
    Public Function ReadUserData(userId As ULong) As UserData Implements IStore.ReadUserData
        Try
            Return JsonSerializer.Deserialize(Of UserData)(File.ReadAllText($"{userId}.json"))
        Catch ex As Exception
            Return New UserData With
                {
                    .UserId = userId
                }
        End Try
    End Function
End Class
