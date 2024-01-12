Imports System.Runtime.CompilerServices
Imports ConsoleHelperLibrary.Classes

Namespace Classes

    Module Module1
        <ModuleInitializer>
        Public Sub Init()
            Console.Title = "Dapper code sample"
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center)
        End Sub
    End Module
End Namespace