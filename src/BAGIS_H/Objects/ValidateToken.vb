Public Class ValidateToken

    'The message returned from /api/rest/validate-token/ if the token is valid
    Public message As String
    'The user name related to the token that was successfully validated
    Public user As String
    'Error message returned if the token is invalid
    Public detail As String

End Class
