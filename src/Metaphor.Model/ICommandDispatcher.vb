Public Interface ICommandDispatcher
    Function HandleCommand(tokens As Queue(Of String)) As IEnumerable(Of String)
End Interface
