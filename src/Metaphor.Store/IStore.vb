Imports Metaphor.Data

Public Interface IStore
    Function ReadUserData(userId As UInt64) As UserData
    Sub WriteUserdata(userData As UserData)
End Interface
