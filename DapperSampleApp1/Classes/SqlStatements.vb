Namespace Classes
    Public Class SqlStatements
        ''' <summary>
        ''' Add new person, return new primary key
        ''' </summary>
        Public Shared ReadOnly Property InsertPeople As String
            Get
                Return _
                <SQL>
                INSERT INTO dbo.Person
                (
                    FirstName,
                    LastName,
                    BirthDate
                )
                VALUES
                (@FirstName, @LastName, @BirthDate);
                SELECT CAST(scope_identity() AS int);
                </SQL>.Value

            End Get
        End Property

        ''' <summary>
        ''' Get all records from Person table
        ''' </summary>
        Public Shared ReadOnly Property ReadPeople As String
            Get
                Return _
                    <SQL>
                    SELECT Id,
                           FirstName,
                           LastName,
                           BirthDate
                    FROM dbo.Person;
                    </SQL>.Value
            End Get
        End Property

        ''' <summary>
        ''' Get a single person by primary key
        ''' </summary>
        Public Shared ReadOnly Property [Get] As String
            Get
                Return _
                    <SQL>
                    SELECT Id,
                           FirstName,
                           LastName,
                           BirthDate
                    FROM dbo.Person
                    WHERE Id = @Id;
                    </SQL>.Value
            End Get
        End Property

        ''' <summary>
        ''' Update person by primary key
        ''' </summary>
        Public Shared ReadOnly Property UpdatePerson As String
            Get
                Return _
                    <SQL>
                    UPDATE dbo.Person
                    SET FirstName = @FirstName,
                        LastName = @LastName,
                        BirthDate = @BirthDate
                    WHERE Id = @Id;
                    </SQL>.Value
            End Get
        End Property

        ''' <summary>
        ''' Remove person by primary key
        ''' </summary>
        Public Shared ReadOnly Property RemovePerson As String
            Get
                Return "DELETE FROM dbo.Person WHERE Id = @Id;"
            End Get
        End Property

        ''' <summary>
        ''' Get count of records for Person table
        ''' </summary>
        Public Shared ReadOnly Property CountOfPeople As String
            Get
                Return "SELECT COUNT(Id) FROM dbo.Person;"
            End Get
        End Property

        ''' <summary>
        ''' SELECT WHERE BETWEEN years for birthdate
        ''' </summary>
        Public Shared ReadOnly Property BirthDateBetweenYears As String
            Get
                Return _
                    <SQL>
                    SELECT Id,
                           FirstName,
                           LastName,
                           BirthDate
                    FROM InsertExamples.dbo.Person
                    WHERE YEAR(BirthDate)
                    BETWEEN @StartYear AND @EndYear;
                    </SQL>.Value
            End Get
        End Property

        ''' <summary>
        ''' Example for WHERE IN primary key
        ''' </summary>
        Public Shared ReadOnly Property WhereInClause As String
            Get
                Return _
                    <SQL>
                    SELECT Id,
                           FirstName,
                           LastName,
                           BirthDate
                    FROM dbo.Person
                    WHERE Id IN @Ids;
                    </SQL>.Value
            End Get
        End Property
    End Class
End Namespace