Imports DapperSampleApp1.Classes
Imports DapperSampleApp1.Modeles
Imports Spectre.Console

Module Program
    Sub Main(args As String())

        Module1.Init()
        Dim peopleTable = CreateTable()
        Dim Operations As New Operations
        Dim people = Operations.GetAll()

        For Each person In people
            peopleTable.AddRow(person.Id.ToString(), person.FirstName, person.LastName, person.BirthDate.ToString())
        Next

        AnsiConsole.Write(peopleTable)
        Console.WriteLine()

        Dim person1 As Person = Operations.SinglePerson(2)
        AnsiConsole.MarkupLine($"[white]First name is[/] [cyan]{person1.FirstName}[/]")

        AnsiConsole.MarkupLine("[white]Press ENTER to exit[/]")
        Console.ReadLine()

    End Sub
    Public Function CreateTable() As Table
        Dim table = (New Table()).RoundedBorder().AddColumn("[b]Id[/]").AddColumn("[b]First[/]").AddColumn("[b]Last[/]").AddColumn("[b]Birth date[/]")
        Return table
    End Function

End Module
