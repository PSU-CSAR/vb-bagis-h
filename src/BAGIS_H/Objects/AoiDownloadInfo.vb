Imports BAGIS_ClassLibrary

''' <summary>
'''  This class contains information that is passed to the DownloadFileCompleted event
'''  This information tracks the state of the download and is used to update the user interface
''' </summary>
''' <remarks></remarks>
Public Class AoiDownloadInfo

    Private _aoiDownloadUrl As String
    Private _downloadStartTime As DateTime
    Private _downloadFilepath As String
    Private _status As String
    Private _aoiName As String
    Private _id As String
    Private _downloadStatus As String

    Public Sub New(ByVal aoiDownloadUrl As String, ByVal aoiStatus As String, ByVal startTime As DateTime, ByVal filePath As String, _
                   ByVal id As String)
        _aoiDownloadUrl = aoiDownloadUrl
        _downloadStartTime = startTime
        _downloadFilepath = filePath
        'Extract aoiName from file path (ex: C:\Docs\Lesley\Downloads\uptest2.zip
        If Not String.IsNullOrEmpty(_downloadFilepath) Then
            _aoiName = System.IO.Path.GetFileNameWithoutExtension(_downloadFilepath)
        End If
        _status = aoiStatus
        _id = id
    End Sub

    ''' <summary>
    ''' The url that is called to download the file; This url contains a unique code that 
    ''' identifies the AOI
    ''' </summary>
    ''' <value></value>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Url As String
        Get
            Return _aoiDownloadUrl
        End Get
    End Property

    ''' <summary>
    ''' The timestamp for when the download started; This allows us to track and 
    ''' display elapsed time for the download
    ''' </summary>
    ''' <value></value>
    ''' <returns>DateTime</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property StartTime As DateTime
        Get
            Return _downloadStartTime
        End Get
    End Property

    ''' <summary>
    ''' The AOI name. This should be unique but it is not guaranteed
    ''' </summary>
    ''' <value></value>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AoiName As String
        Get
            Return _aoiName
        End Get
    End Property

    ''' <summary>
    ''' The folder that the AOI will be downloaded too. Assumption is that the aoi is in a .zip file
    ''' The filePath does not include the AOI name; This folder will be created when the AOI is unzipped
    ''' </summary>
    ''' <value></value>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FilePath As String
        Get
            Return _downloadFilepath
        End Get
    End Property

    ''' <summary>
    ''' The status of the task; Valid values from django are STARTED, PENDING, FAILED, and SUCCESS
    ''' eBagis may also use STAGING
    ''' </summary>
    ''' <value></value>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property

    ''' <summary>
    ''' Id for the download object/record
    ''' </summary>
    ''' <value></value>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property id As String
        Get
            Return _id
        End Get
    End Property

    ''' <summary>
    ''' Download status for PC-BAGIS client; Managed by PC-BAGIS
    ''' </summary>
    ''' <value></value>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Property downloadStatus As String
        Get
            Return _downloadStatus
        End Get
        Set(value As String)
            _downloadStatus = value
        End Set
    End Property
End Class
