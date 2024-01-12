Imports Bogus

Namespace Classes
    Public Class BogusOperations

        Public Shared Function People(Optional ByVal count As Integer = 20) As List(Of Modeles.Person)
            Return (New Faker(Of Modeles.Person)()).
                    RuleFor(Function(c) c.FirstName, Function(f) f.Person.FirstName).
                    RuleFor(Function(c) c.LastName, Function(f) f.Person.LastName).
                    RuleFor(Function(c) c.BirthDate,
                            Function(f)
                                Return f.Date.BetweenDateOnly(New DateOnly(1999, 1, 1), New DateOnly(2010, 1, 1))
                            End Function).
                    Generate(count)
        End Function

        Public Shared Function Person() As Modeles.Person
            Return People(1).First()
        End Function
    End Class
End Namespace