Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Namespace Modeles
    Public Class Person
        Implements INotifyPropertyChanged

        Private _id As Integer
        Private _firstName As String
        Private _lastName As String
        Private _birthDate As DateOnly

        Public Property Id As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                If value = _id Then
                    Return
                End If
                _id = value
                OnPropertyChanged()
            End Set
        End Property

        Public Property FirstName As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                If value = _firstName Then
                    Return
                End If
                _firstName = value
                OnPropertyChanged()
            End Set
        End Property

        Public Property LastName As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                If value = _lastName Then
                    Return
                End If
                _lastName = value
                OnPropertyChanged()
            End Set
        End Property
        Public Property BirthDate As DateOnly
            Get
                Return _birthDate
            End Get
            Set(ByVal value As DateOnly)
                If value.Equals(_birthDate) Then
                    Return
                End If
                _birthDate = value
                OnPropertyChanged()
            End Set

        End Property

        Public Overrides Function ToString() As String
            Return Id.ToString()
        End Function

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional ByVal propertyName As String = Nothing)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace