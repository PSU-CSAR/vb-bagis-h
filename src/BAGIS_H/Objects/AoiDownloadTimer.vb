Imports System.Timers
Imports System.Net
Imports BAGIS_ClassLibrary

Public Class AoiDownloadTimer

    Private aTimer As Timer = New Timer
    Private m_aoiDownload As AoiUpload
    Private m_token As String
    Private m_parent As FrmDownloadAoiMenu
    Private beginTime As DateTime
    Private m_downloadTimeout As Double  'Units are seconds
    Private m_downloadFilePath As String

    Public Sub New(ByRef aoiDownload As AoiUpload, ByVal strToken As String, ByVal interval As UInteger, _
                   ByVal downloadTimeout As Double, ByVal downloadFilePath As String, ByRef parentForm As FrmDownloadAoiMenu)
        m_aoiDownload = aoiDownload
        m_token = strToken
        m_parent = parentForm
        m_downloadTimeout = downloadTimeout
        m_downloadFilePath = downloadFilePath

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
            'Dim testUrl = "https://webservices.geog.pdx.edu/api/rest/downloads/JxVFr/"
            'Check to see if we have a zip file
            Dim contentType As String = WebservicesModule.BA_GetResponseContentType(m_aoiDownload.url, m_token)

            Dim strMessage As String = Nothing
            Dim elapsedTime As TimeSpan = Now.Subtract(beginTime)
            Debug.Print("beginTime 1: " & beginTime)
            'Debug.Print("contentType: " & contentType)
            If contentType = BA_Mime_Zip Then
                aTimer.Close()
                Dim aoiDownload As AoiDownload = New AoiDownload(m_aoiDownload.url, m_aoiDownload.task.status, beginTime, m_downloadFilePath)
                Dim success As BA_ReturnCode = m_parent.DownloadFile(aoiDownload)
                Exit Sub
            Else
                m_aoiDownload = BA_Download_Aoi(m_aoiDownload.url, m_token)
            End If

            Dim uploadStatus As String = Trim(m_aoiDownload.task.status).ToUpper
            Select Case uploadStatus
                Case BA_Task_Failure
                    strMessage = m_aoiDownload.task.traceback
                    Debug.Print("Download failure from server: " & m_aoiDownload.task.traceback)
                    aTimer.Close()
                Case BA_Task_Success
                    aTimer.Close()
                Case BA_Task_Pending
                    If elapsedTime.TotalSeconds > m_downloadTimeout Then
                        m_aoiDownload.task.status = BA_Task_Timed_Out
                        strMessage = "Download timed out"
                        aTimer.Close()
                    End If
                    strMessage = "Assembling download"
            End Select
            m_parent.UpdateStatus(m_parent.GrdTasks, m_aoiDownload, CInt(elapsedTime.TotalSeconds), strMessage)
        Catch ex As WebException
            Debug.Print("AoiDownloadTimer.OnTimedEvent: " & ex.Message)
            aTimer.Close()
        End Try
    End Sub

End Class
