Imports System.Timers
Imports System.Net
Imports System.Windows.Forms
Imports BAGIS_ClassLibrary

Public Class AoiDownloadTimer

    Private aTimer As System.Timers.Timer = New System.Timers.Timer
    Private m_token As String
    Private m_parent As FrmDownloadAoiMenu

    Public Sub New(ByVal strToken As String, ByVal interval As UInteger, _
                   ByRef parentForm As FrmDownloadAoiMenu)
        m_token = strToken
        m_parent = parentForm

        'Instantiate timer
        aTimer = New System.Timers.Timer
        aTimer.Interval = interval

        ' Hook up the Elapsed event for the timer.
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
    End Sub

    Public Sub EnableTimer(ByVal enable As Boolean)
        aTimer.Enabled = enable
    End Sub

    Public Function Enabled() As Boolean
        Return aTimer.Enabled()
    End Function

    'Use to cancel timer from form
    Public Sub CloseTimer()
        If aTimer IsNot Nothing Then
            aTimer.Close()
        End If
    End Sub

    ' Specify what you want to happen when the Elapsed event is 
    ' raised.
    'Private Sub OnTimedEvent2(source As Object, e As ElapsedEventArgs)
    '    Try
    '        'Dim testUrl = "https://webservices.geog.pdx.edu/api/rest/downloads/JxVFr/"
    '        'Check to see if we have a zip file
    '        Dim contentType As String = WebservicesModule.BA_GetResponseContentType(m_aoiDownload.url, m_token)

    '        Dim strMessage As String = Nothing
    '        Dim elapsedTime As TimeSpan = Now.Subtract(beginTime)
    '        'Debug.Print("beginTime 1: " & beginTime)
    '        'Debug.Print("contentType: " & contentType)
    '        If contentType = BA_Mime_Zip Then
    '            aTimer.Close()
    '            Dim aoiDownload As AoiDownloadInfo = New AoiDownloadInfo(m_aoiDownload.url, m_aoiDownload.task.status, beginTime, _
    '                                                             m_downloadFilePath, m_aoiDownload.id)
    '            Dim success As BA_ReturnCode = m_parent.DownloadFile(aoiDownload)
    '            Exit Sub
    '        Else
    '            m_aoiDownload = BA_Download_Aoi(m_aoiDownload.url, m_token)
    '        End If

    '        Dim uploadStatus As String = Trim(m_aoiDownload.task.status).ToUpper
    '        Select Case uploadStatus
    '            Case BA_Task_Failure
    '                strMessage = m_aoiDownload.task.traceback
    '                Debug.Print("Download failure from server: " & m_aoiDownload.task.traceback)
    '                aTimer.Close()
    '                m_parent.EnableDownloadBtn(m_parent.BtnDownloadAoi, True)
    '            Case BA_Task_Pending
    '                strMessage = "Assembling download"
    '                If elapsedTime.TotalSeconds > m_downloadTimeout Then
    '                    m_aoiDownload.task.status = BA_Task_Timed_Out
    '                    strMessage = "Download timed out"
    '                    aTimer.Close()
    '                    m_parent.EnableDownloadBtn(m_parent.BtnDownloadAoi, True)
    '                End If
    '        End Select
    '        m_parent.UpdateStatus(m_parent.GrdTasks, m_aoiDownload, strMessage)
    '    Catch ex As WebException
    '        Debug.Print("AoiDownloadTimer.OnTimedEvent: " & ex.Message)
    '        aTimer.Close()
    '    End Try
    'End Sub

    Private Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        Try
            Dim activeDownloads As Integer = 0
            For Each pRow As DataGridViewRow In m_parent.GrdTasks.Rows
                Dim downloadTask As AoiTask = Nothing
                Dim taskType As String = pRow.Cells(m_parent.idxTaskType).Value
                Dim downloadStatus As String = pRow.Cells(m_parent.idxDownloadStatus).Value
                If Not String.IsNullOrEmpty(downloadStatus) AndAlso downloadStatus.Equals(BA_Download_Processing) Then
                    activeDownloads += 1
                    Dim url As String = pRow.Cells(m_parent.idxTaskUrl).Value
                    'Check to see if we have a zip file
                    Dim contentType As String = WebservicesModule.BA_GetResponseContentType(url, m_token)
                    Dim strMessage As String = Nothing

                    If contentType = BA_Mime_Zip Then
                        Dim success As BA_ReturnCode = m_parent.DownloadFile(url)
                        Exit Sub
                    Else
                        downloadTask = BA_Download_Aoi(url, m_token)
                    End If

                    Dim uploadStatus As String = Trim(downloadTask.task.status).ToUpper
                    Select Case uploadStatus
                        Case BA_Task_Failure
                            strMessage = downloadTask.task.traceback
                            Debug.Print("Download failure from server: " & downloadTask.task.traceback)
                        Case BA_Task_Pending
                            strMessage = "Assembling download"
                    End Select
                    m_parent.UpdateStatus(m_parent.GrdTasks, downloadTask, strMessage)
                End If
            Next
            If activeDownloads < 1 Then aTimer.Stop()
        Catch ex As WebException
            Debug.Print("AoiDownloadTimer.OnTimedEvent: " & ex.Message)
        End Try
    End Sub

End Class
