Public Class TaskLog
    Inherits BAGIS_ClassLibrary.SerializableData

    Public TaskLogEntries As TaskLogEntry()

End Class

Public Class TaskLogEntry
    Inherits BAGIS_ClassLibrary.SerializableData

    Public aoiName As String
    Public id As String
    Public taskType As String
    Public status As String
    Public dateCompleted As Date
    Public localFolder As String
    Public errorMessage As String

End Class
