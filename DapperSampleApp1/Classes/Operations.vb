Imports System.Data
Imports ConfigurationLibrary.Classes
Imports Dapper
Imports DapperSampleApp1.Modeles
Imports kp.Dapper.Handlers
Imports Microsoft.Data.SqlClient

Namespace Classes
    Public Class Operations
        Private _cn As IDbConnection
        Public Sub New()
            _cn = New SqlConnection(ConfigurationHelper.ConnectionString())
            SqlMapper.AddTypeHandler(New SqlDateOnlyTypeHandler())
        End Sub

        Public Function GetAll() As List(Of Person)
            Return _cn.Query(Of Person)(SqlStatements.ReadPeople).ToList()
        End Function
        Public Function SinglePerson(id As Integer) As Person
            Return _cn.QueryFirstOrDefault(Of Person)(SqlStatements.Get, New With {Key .Id = id})
        End Function

        Public Async Function AddRange(list As List(Of Person)) As Task
            Await _cn.ExecuteAsync(SqlStatements.InsertPeople, list)
        End Function

        Public Sub Reset()
            _cn.Execute("DELETE FROM dbo.Person")
            _cn.Execute("DBCC CHECKIDENT (Person, RESEED, 0)")
        End Sub

    End Class
End Namespace