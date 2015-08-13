Imports System.Timers
Imports System.Net
Imports BAGIS_ClassLibrary

Public Class AoiUploadTimer

    Private aTimer As Timer = New Timer
    Private m_aoiUpload As AoiUpload
    Private m_token As String
    Private m_parent As FrmDownloadAoiMenu
    Private beginTime As DateTime
    Private m_uploadTimeout As Double  'Units are seconds

    Public Sub New(ByRef aoiUpload As AoiUpload, ByVal strToken As String, ByVal interval As UInteger, _
                   ByVal uploadTimeout As Double, ByRef parentForm As FrmDownloadAoiMenu)
        m_aoiUpload = aoiUpload
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
        'Debug.Print("The Elapsed event was raised at {0}", e.SignalTime)
        Dim reqT As HttpWebRequest
        Dim resT As HttpWebResponse
        Try
            reqT = WebRequest.Create(m_aoiUpload.url)
            'This is a GET request
            reqT.Method = "GET"

            'Retrieve the token and format it for the header; Token comes from caller
            Dim cred As String = String.Format("{0} {1}", "Token", m_token)
            'Put token in header
            reqT.Headers(HttpRequestHeader.Authorization) = cred
            resT = CType(reqT.GetResponse(), HttpWebResponse)

            'Serialize the response so we can check the status
            Dim ser As System.Runtime.Serialization.Json.DataContractJsonSerializer = New System.Runtime.Serialization.Json.DataContractJsonSerializer(m_aoiUpload.[GetType]())
            m_aoiUpload = CType(ser.ReadObject(resT.GetResponseStream), AoiUpload)

            Dim uploadStatus As String = Trim(m_aoiUpload.task.status).ToUpper
            Dim strMessage As String = Nothing
            Dim stopTime As DateTime = Now
            Dim elapsedTime As TimeSpan = Now.Subtract(beginTime)
            Select Case uploadStatus
                Case BA_Task_Failure
                    strMessage = m_aoiUpload.task.traceback
                    aTimer.Close()
                    m_parent.UpdateLog(m_aoiUpload.id, m_aoiUpload.task.status, strMessage)
                Case BA_Task_Success
                    aTimer.Close()
                    m_parent.UpdateLog(m_aoiUpload.id, m_aoiUpload.task.status, strMessage)
                Case BA_Task_Pending
                    If elapsedTime.TotalSeconds > m_uploadTimeout Then
                        m_aoiUpload.task.status = BA_Task_Timed_Out
                        strMessage = "Upload timed out"
                        aTimer.Close()
                        m_parent.UpdateLog(m_aoiUpload.id, m_aoiUpload.task.status, strMessage)
                    End If
            End Select
            m_parent.UpdateStatus(m_parent.GrdTasks, m_aoiUpload, CInt(elapsedTime.TotalSeconds), strMessage)
        Catch ex As WebException
            Debug.Print("OnTimedEvent: " & ex.Message)
            aTimer.Close()
        End Try
    End Sub


End Class
