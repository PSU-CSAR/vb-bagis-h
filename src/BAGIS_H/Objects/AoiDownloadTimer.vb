Imports System.Timers
Imports System.Net
Imports BAGIS_ClassLibrary
Imports System.Web.Script.Serialization

Public Class AoiDownloadTimer

    Private aTimer As Timer = New Timer
    Private m_aoiDownload As AoiUpload
    Private m_token As String
    Private m_parent As FrmDownloadAoiMenu
    Private beginTime As DateTime
    Private m_uploadTimeout As Double  'Units are seconds

    Public Sub New(ByRef aoiDownload As AoiUpload, ByVal strToken As String, ByVal interval As UInteger, _
                   ByVal uploadTimeout As Double, ByRef parentForm As FrmDownloadAoiMenu)
        m_aoiDownload = aoiDownload
        m_token = strToken
        m_parent = parentForm
        m_uploadTimeout = uploadTimeout

        'Instantiate timer
        aTimer = New Timer
        aTimer.Interval = interval

        ' Hook up the Elapsed event for the timer.
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
    End Sub

    Public Sub EnableTimer(ByVal enable As Boolean)
        beginTime = Now
        aTimer.Enabled = enable
    End Sub

    'Use to cancel timer from form
    Public Sub CloseTimer()
        If aTimer IsNot Nothing Then
            aTimer.Close()
        End If
    End Sub

    ' Specify what you want to happen when the Elapsed event is 
    ' raised.
    Private Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        Try
            ' Create a new WebClient instance.
            ' Using WebClient for built-in file download functionality
            Dim myWebClient As New WebClient()

            'Retrieve the token and format it for the header; Token comes from caller
            Dim cred As String = String.Format("{0} {1}", "Token", m_token)
            'Put token in header
            myWebClient.Headers(HttpRequestHeader.Authorization) = cred
            Dim strResponse As String = myWebClient.DownloadString(m_aoiDownload.url)

            'Serialize the response so we can check the status
            'Dim ser As System.Runtime.Serialization.Json.DataContractJsonSerializer = New System.Runtime.Serialization.Json.DataContractJsonSerializer(m_aoiDownload.[GetType]())
            'm_aoiDownload = CType(ser.ReadObject(strResponse), AoiUpload)
            Dim ser As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer
            m_aoiDownload = ser.Deserialize(Of AoiUpload)(strResponse)

            Dim uploadStatus As String = Trim(m_aoiDownload.task.status).ToUpper
            Dim strMessage As String = Nothing
            Dim stopTime As DateTime = Now
            Dim elapsedTime As TimeSpan = Now.Subtract(beginTime)
            Select Case uploadStatus
                Case BA_Task_Failure
                    strMessage = m_aoiDownload.task.traceback
                    aTimer.Close()
                Case BA_Task_Success
                    aTimer.Close()
                Case BA_Task_Pending
                    If elapsedTime.TotalSeconds > m_uploadTimeout Then
                        m_aoiDownload.task.status = BA_Task_Timed_Out
                        strMessage = "Download timed out"
                        aTimer.Close()
                    End If
            End Select
            m_parent.UpdateStatus(m_parent.GrdTasks, m_aoiDownload, CInt(elapsedTime.TotalSeconds), strMessage)
        Catch ex As WebException
            Debug.Print("OnTimedEvent: " & ex.Message)
            aTimer.Close()
        End Try
    End Sub


End Class
