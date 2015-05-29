Public Class AoiUpload

    Public id As String
    Public url As String
    Public user As String
    Public md5 As String
    Public file As String
    Public filename As String
    Public offset As String
    Public created_at As String
    Public status As Integer
    Public completed_at As String
    Public task As Task

    ReadOnly Property DateCreated As Date
        Get
            Dim aDate As DateTime
            DateTime.TryParse(created_at, aDate)
            Return aDate
        End Get
    End Property

    ReadOnly Property DateCompleted As Date
        Get
            Dim aDate As DateTime
            DateTime.TryParse(completed_at, aDate)
            Return aDate
        End Get
    End Property


End Class

Public Class Task
    Public id As Integer
    Public task_id As String
    Public status As String
    Public date_done As String
    Public traceback As String

    ReadOnly Property DateDone As Date
        Get
            Dim aDate As DateTime
            DateTime.TryParse(date_done, aDate)
            Return aDate
        End Get
    End Property
End Class
