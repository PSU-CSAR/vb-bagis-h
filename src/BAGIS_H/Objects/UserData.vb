Public Class UserData

    Public username As String
    Public email As String
    Public first_name As String
    Public last_name As String
    Public roles As String()

    Public ReadOnly Property roleList As IList(Of String)
        Get
            Dim rList As List(Of String) = New List(Of String)
            If roles IsNot Nothing Then
                rList.AddRange(roles)
            End If
            Return rList
        End Get
    End Property
End Class
