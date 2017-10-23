Public Class UserData

    Public username As String
    Public email As String
    Public first_name As String
    Public last_name As String
    Public groups As String()

    Public ReadOnly Property groupList As IList(Of String)
        Get
            Dim gList As List(Of String) = New List(Of String)
            If groups IsNot Nothing Then
                gList.AddRange(groups)
            End If
            Return gList
        End Get
    End Property
End Class
