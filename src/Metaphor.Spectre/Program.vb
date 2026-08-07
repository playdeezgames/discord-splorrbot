Imports Metaphor.Engine
Imports Spectre.Console

Module Program
    Private Const QUIT_COMMAND = "/quit"
    Private Const USER_ID As UInt64 = 327506515533496320UL
    Sub Main(args As String())
        Do
            Dim command As String = AnsiConsole.Ask(Of String)("[olive]Now What?[/]")
            If command = QUIT_COMMAND Then
                Exit Do
            End If
            AnsiConsole.WriteLine(Host.HandleMessage(USER_ID, command))
        Loop
    End Sub
End Module
