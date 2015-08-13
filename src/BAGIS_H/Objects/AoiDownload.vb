Imports BAGIS_ClassLibrary

Public Class AoiDownload

    Private _aoiDownloadUrl As String
    Private _downloadStartTime As DateTime
    Private _downloadFilepath As String
    Private _status As String
    Private _aoiName As String
    Private _id As String

    Public Sub New(ByVal aoiDownloadUrl As String, ByVal aoiStatus As String, ByVal startTime As DateTime, ByVal filePath As String, _
                   ByVal id As String)
        _aoiDownloadUrl = aoiDownloadUrl
        _downloadStartTime = startTime
        Debug.Print("beginTime 2: " & _downloadStartTime)
        _downloadFilepath = filePath
        'Extract aoiName from file path (ex: C:\Docs\Lesley\Downloads\uptest2.zip
        If Not String.IsNullOrEmpty(_downloadFilepath) Then
            _aoiName = System.IO.Path.GetFileNameWithoutExtension(_downloadFilepath)
        End If
        _status = aoiStatus
        _id = id
    End Sub

    Public ReadOnly Property Url As String
        Get
            Return _aoiDownloadUrl
        End Get
    End Property

    Public ReadOnly Property StartTime As DateTime
        Get
            Return _downloadStartTime
        End Get
    End Property

    Public ReadOnly Property AoiName As String
        Get
            Return _aoiName
        End Get
    End Property

    Public ReadOnly Property FilePath As String
        Get
            Return _downloadFilepath
        End Get
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property

    Public ReadOnly Property id As String
        Get
            Return _id
        End Get
    End Property
End Class
