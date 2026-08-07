Public Interface IUserModel
    Function HandleCommand(tokens As Queue(Of String)) As IEnumerable(Of String)
End Interface
