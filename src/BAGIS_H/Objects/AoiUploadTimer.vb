Imports System.Timers
Imports System.Net

Public Class AoiUploadTimer

    Private Shared aTimer As Timer
    Private Shared m_aoiUpload As AoiUpload
    Private Shared m_token As String
    Private Shared m_parent As FrmDownloadAoiMenu

    Public Sub New(ByRef aoiUpload As AoiUpload, ByVal strToken As String, interval As UInteger)
        m_aoiUpload = aoiUpload
        m_token = strToken

        'Instantiate timer
        aTimer = New Timer
        aTimer.Interval = interval

        ' Hook up the Elapsed event for the timer.
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
    End Sub

    Public Sub EnableTimer(ByVal enable As Boolean)
        aTimer.Enabled = enable
    End Sub

    ' Specify what you want to happen when the Elapsed event is 
    ' raised.
    Private Shared Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        Debug.Print("The Elapsed event was raised at {0}", e.SignalTime)
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

            Dim uploadStatus As String = m_aoiUpload.task.status
            MsgBox(uploadStatus)
            If Trim(uploadStatus).ToUpper <> "PENDING" Then
                aTimer.Stop()
                MsgBox("Timer stopped")
            End If
        Catch ex As WebException
            Debug.Print(" WaitForResponse: " & ex.Message)
        End Try
    End Sub


End Class
