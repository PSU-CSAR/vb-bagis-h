Public Class StoredAoi

    Dim m_name As String
    Dim m_url As String
    Dim m_created_at As String
    Dim m_created_by As String

    Property name As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property

    Property url As String
        Get
            Return m_url
        End Get
        Set(value As String)
            m_url = value
        End Set
    End Property

    Property created_at As String
        Get
            Return m_created_at
        End Get
        Set(value As String)
            m_created_at = value
        End Set
    End Property

    Property created_by As String
        Get
            Return m_created_by
        End Get
        Set(value As String)
            m_created_by = value
        End Set
    End Property
End Class
