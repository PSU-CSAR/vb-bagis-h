Imports System.Windows.Forms
Imports System.Net
Imports System.Text
Imports System.IO
Imports BAGIS_ClassLibrary
Imports ESRI.ArcGIS.CatalogUI
Imports ESRI.ArcGIS.Catalog

Public Class FrmDownloadAoiMenu

    Private m_token As BagisToken = New BagisToken
    'In practice the user name/password will be provided by the user
    Private m_userName As String = Nothing
    Private m_password As String = Nothing
    Private idxAoiName As Integer = 0
    Private idxDateUploaded As Integer = 1
    Private idxAuthor As Integer = 2
    Private idxDownload As Integer = 3
    Private idxDownloadUrl As Integer = 4
    Private idxTaskAoi As Integer = 0
    Private idxTaskType As Integer = 1
    Private idxTaskStatus As Integer = 2
    Private idxTaskTime As Integer = 3
    Private idxTaskMessage As Integer = 4
    Private idxTaskUrl As Integer = 5
    Private Const UPLOAD_TYPE As String = "Upload"
    Private Const DOWNLOAD_TYPE As String = "Download"
    Private m_timersList As IList(Of AoiUploadTimer)
    Private m_downTimersList As IList(Of AoiDownloadTimer)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Set the user name and password from a text file that is NOT in source countrol
        'Note: Developers will have to change this to a path valid on their machine
        Dim filePath As String = "C:\Docs\Lesley\Repository\vb\BAGIS_H\branches\lbross\src\BAGIS_H\GoldenTicket.txt"
        '@ToDo: In the future, this comes from user input
        Try
            ' Create an instance of StreamReader to read from a file.
            ' The using statement also closes the StreamReader.
            Using sr As New StreamReader(filePath)
                m_userName = sr.ReadLine()
                m_password = sr.ReadLine()
            End Using
        Catch e As Exception
            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(e.Message)
        End Try

        ' Add any initialization after the InitializeComponent() call.
        '---create a row---
        Dim item As New DataGridViewRow
        item.CreateCells(AoiGrid)
        With item
            .Cells(0).Value = "Price_R_at_Woodside_01232014"
            .Cells(1).Value = "23-JAN-2014"
            .Cells(2).Value = "G. Duh"
            .Cells(3).Value = False
            .Cells(4).Value = "Updated AOI with new gauge station"
        End With
        Dim item2 As New DataGridViewRow
        item2.CreateCells(AoiGrid)
        With item2
            .Cells(0).Value = "Santa_Fe_R_nr_Santa_Fe_11302012"
            .Cells(1).Value = "11-NOV-2012"
            .Cells(2).Value = "D. Garen"
            .Cells(3).Value = False
            .Cells(4).Value = "Initial upload of AOI; Includes HRU definition"
        End With
        '---add the row---
        '@ToDo: Temporarily stop populating form
        'AoiGrid.Rows.Add(item)
        'AoiGrid.Rows.Add(item2)
        AoiGrid.ClearSelection()
        AoiGrid.CurrentCell = Nothing

        'Check for token
        'm_token.token = SecurityHelper.GetStoredToken
        m_timersList = New List(Of AoiUploadTimer)
        m_downTimersList = New List(Of AoiDownloadTimer)
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnDownloadAoi_Click(sender As System.Object, e As System.EventArgs) Handles BtnDownloadAoi.Click
        Try
             'Is a destination folder selected
            If String.IsNullOrEmpty(TxtDownloadPath.Text) Then
                MessageBox.Show("You must select a destination folder to download an AOI", "No folder selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Can the user write to the destination folder
            If Not SecurityHelper.IsPathWritable(TxtDownloadPath.Text) Then
                MessageBox.Show("You do not have permission to save to the folder you selected", "No permission", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Is at least one aoi selected
            Dim dList As IList(Of String) = New List(Of String)
            Dim dCount As UInt16 = 0
            For Each pRow As DataGridViewRow In AoiGrid.Rows
                Dim ckDownload As Boolean = pRow.Cells(idxDownload).Value
                If ckDownload = True Then
                    dCount += 1
                    Dim downloadFilePath As String = TxtDownloadPath.Text & "\" & Convert.ToString(pRow.Cells(idxAoiName).Value) & ".zip"
                    If File.Exists(downloadFilePath) Then dList.Add(Convert.ToString(pRow.Cells(idxAoiName).Value))
                End If
            Next
            If dCount < 1 Then
                MessageBox.Show("You must select at least one AOI to download", "No AOI selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If dList.Count > 0 Then
                Dim messageBoxVB As New System.Text.StringBuilder()
                messageBoxVB.AppendLine("The following AOI's already exist in")
                messageBoxVB.AppendLine("the selected download folder:")
                For Each dName As String In dList
                    messageBoxVB.AppendLine(dName)
                Next
                messageBoxVB.AppendLine("")
                messageBoxVB.AppendLine("Click 'Yes' to overwrite or 'No' to cancel.")
                MessageBox.Show(messageBoxVB.ToString, "Existing AOI's", MessageBoxButtons.YesNo)
            End If

            'Check token
            If GenerateToken() <> BA_ReturnCode.Success Then Exit Sub

            BtnDownloadAoi.Enabled = False
            For Each pRow As DataGridViewRow In AoiGrid.Rows
                Dim ckDownload As Boolean = pRow.Cells(idxDownload).Value
                If ckDownload = True Then
                    Dim downloadUrl As String = Convert.ToString(pRow.Cells(idxDownloadUrl).Value)
                    downloadUrl = downloadUrl & "download/"
                    Dim aoiName As String = Convert.ToString(pRow.Cells(idxAoiName).Value)
                    '---create a row---
                    Dim item As New DataGridViewRow
                    item.CreateCells(GrdTasks)
                    With item
                        .Cells(idxTaskAoi).Value = aoiName
                        .Cells(idxTaskType).Value = DOWNLOAD_TYPE
                        .Cells(idxTaskStatus).Value = BA_Task_Started
                        .Cells(idxTaskTime).Value = "N/A"
                    End With
                    GrdTasks.Rows.Add(item)
                    Application.DoEvents()
                    Dim aDownload As AoiUpload = BA_Download_Aoi(downloadUrl, m_token.token)
                    If aDownload.task IsNot Nothing Then
                        Dim interval As UInteger = 10000    'Value in milleseconds
                        Dim downloadTimeout As Double = 300   'Value in seconds
                        Dim downloadFilePath As String = TxtDownloadPath.Text & "\" & aoiName & ".zip"
                        Dim aTimer As AoiDownloadTimer = New AoiDownloadTimer(aDownload, m_token.token, interval, downloadTimeout, downloadFilePath, Me)
                        m_downTimersList.Add(aTimer)
                        With item
                            .Cells(idxTaskStatus).Value = aDownload.task.status
                            .Cells(idxTaskUrl).Value = aDownload.url
                            .Cells(idxTaskTime).Value = "0"
                            .Cells(idxTaskMessage).Value = "Assembling download"
                        End With
                        aTimer.EnableTimer(True)
                    Else
                        With item
                            .Cells(idxTaskStatus).Value = BA_Task_Failure
                            .Cells(idxTaskTime).Value = "N/A"
                            .Cells(idxTaskMessage).Value = "An error occurred while trying to download the AOI"
                        End With
                    End If
                End If
            Next
        Catch ex As WebException
            Debug.Print("BtnDownloadAoi_Click Exception: " & ex.Message)
        End Try
    End Sub

    'Testing how to connect to an unsecured connection
    Protected Sub TestConnection()
        Dim reqT As HttpWebRequest
        Dim resT As HttpWebResponse
        reqT = WebRequest.Create("http://basins.geog.pdx.edu/bagis_test/test.html")
        reqT.Method = "GET"
        Try
            'Dim dataStreamT As System.IO.Stream = reqT.GetRequestStream()
            resT = CType(reqT.GetResponse(), HttpWebResponse)
            Dim responseStream As New System.IO.StreamReader(resT.GetResponseStream(), Encoding.UTF8)
            Dim result As String = responseStream.ReadToEnd()
            Debug.Print(result)
        Catch ex As WebException
            MsgBox(ex.InnerException)
        End Try
    End Sub

    Private Sub BtnList_Click(sender As System.Object, e As System.EventArgs) Handles BtnList.Click
        BtnList.Enabled = False
        If String.IsNullOrEmpty(m_token.token) Then
            Dim strToken As String = SecurityHelper.GetServerToken(m_userName, m_password, TxtBasinsDb.Text & "api-token-auth/")
            m_token.token = strToken
            If String.IsNullOrEmpty(strToken) Then
                MessageBox.Show("Invalid user name or password. Failed to connect to database.", "Failed Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        Dim storedAois As Dictionary(Of String, StoredAoi) = BA_List_Aoi(TxtBasinsDb.Text, m_token.token)
        RefreshGrid(storedAois)
        BtnList.Enabled = True
    End Sub

    Private Sub RefreshGrid(ByVal storedAois)
        AoiGrid.Rows.Clear()
        For Each kvp As KeyValuePair(Of String, StoredAoi) In storedAois
            '---create a row---
            Dim item As New DataGridViewRow
            item.CreateCells(AoiGrid)
            With item
                .Cells(idxAoiName).Value = kvp.Value.name
                .Cells(idxDateUploaded).Value = kvp.Value.DateCreated.ToString("MM-dd-yyyy")
                .Cells(idxAuthor).Value = kvp.Value.created_by.username
                '.Cells(3).Value = False
                '.Cells(4).Value = "Updated AOI with new gauge station"
                .Cells(idxDownloadUrl).Value = kvp.Value.url
            End With
            AoiGrid.Rows.Add(item)
        Next kvp
        AoiGrid.Sort(AoiGrid.Columns(idxAoiName), System.ComponentModel.ListSortDirection.Descending)
        AoiGrid.ClearSelection()
        AoiGrid.CurrentCell = Nothing
    End Sub

    Private Sub BtnUploadZip_Click(sender As System.Object, e As System.EventArgs) Handles BtnUploadZip.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "zip files (*.zip)|*.zip"
        openFileDialog1.FilterIndex = 1
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TxtUploadPath.Text = openFileDialog1.FileName
        End If

        If GenerateToken() <> BA_ReturnCode.Success Then Exit Sub

        Dim uploadUrl = TxtBasinsDb.Text & "aois/"
        Dim fileName As String = Path.GetFileNameWithoutExtension(TxtUploadPath.Text)
        If String.IsNullOrEmpty(fileName) Then
            MessageBox.Show("No file selected to upload", "No file selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '---create a row---
        Dim item As New DataGridViewRow
        item.CreateCells(GrdTasks)
        With item
            .Cells(idxTaskAoi).Value = fileName
            .Cells(idxTaskType).Value = UPLOAD_TYPE
            .Cells(idxTaskStatus).Value = BA_Task_Started
            .Cells(idxTaskTime).Value = "N/A"
        End With
        GrdTasks.Rows.Add(item)
        Application.DoEvents()

        Dim anUpload As AoiUpload = BA_UploadMultiPart(uploadUrl, m_token.token, fileName, TxtUploadPath.Text)
        If anUpload.task IsNot Nothing Then
            Dim interval As UInteger = 10000    'Value in milleseconds
            Dim uploadTimeout As Double = 120   'Value in seconds
            Dim aTimer As AoiUploadTimer = New AoiUploadTimer(anUpload, m_token.token, interval, uploadTimeout, Me)
            m_timersList.Add(aTimer)
            With item
                .Cells(idxTaskStatus).Value = anUpload.task.status
                .Cells(idxTaskUrl).Value = anUpload.url
                .Cells(idxTaskTime).Value = "0"
            End With
            aTimer.EnableTimer(True)
            'Clear out upload file name
            TxtUploadPath.Text = Nothing
        Else
            With item
                .Cells(idxTaskStatus).Value = BA_Task_Failure
                .Cells(idxTaskTime).Value = "N/A"
                .Cells(idxTaskMessage).Value = "An error occurred while trying to upload the AOI"
            End With
        End If
    End Sub

    'Work around cross-threading exception to update task table
    Friend Sub UpdateStatus(ByVal ctl As Control, ByVal aoiUpload As AoiUpload, ByVal elapsedTime As Integer, ByVal strMessage As String)
        If ctl.InvokeRequired Then
            ctl.BeginInvoke(New Action(Of Control, AoiUpload, Integer, String)(AddressOf UpdateStatus), ctl, aoiUpload, elapsedTime, strMessage)
        Else
            For Each row As DataGridViewRow In GrdTasks.Rows
                Dim url As String = row.Cells(idxTaskUrl).Value
                If url = aoiUpload.url Then
                    row.Cells(idxTaskStatus).Value = aoiUpload.task.status
                    row.Cells(idxTaskTime).Value = CStr(elapsedTime)
                    row.Cells(idxTaskMessage).Value = strMessage
                    Exit Sub
                End If
            Next
        End If
        Application.DoEvents()
    End Sub

    'Work around cross-threading exception to enable download button
    Friend Sub EnableDownloadBtn(ByVal ctl As Control, ByVal Enabled As Boolean)
        If ctl.InvokeRequired Then
            ctl.BeginInvoke(New Action(Of Control, Boolean)(AddressOf EnableDownloadBtn), ctl, Enabled)
        Else
            BtnDownloadAoi.Enabled = Enabled
        End If
        Application.DoEvents()
    End Sub

    Private Sub UpdateDownloadStatus(ByVal aoiDownload As AoiDownload, _
                                     ByVal elapsedTime As Integer, ByVal strMessage As String)
        For Each row As DataGridViewRow In GrdTasks.Rows
            Dim url As String = row.Cells(idxTaskUrl).Value
            If url = aoiDownload.Url Then
                row.Cells(idxTaskStatus).Value = aoiDownload.Status
                row.Cells(idxTaskTime).Value = CStr(elapsedTime)
                row.Cells(idxTaskMessage).Value = strMessage
                Exit Sub
            End If
        Next
        Application.DoEvents()
    End Sub

    '@ToDo: Check server to see if there is existing aoi under this name
    Private Sub BtnSelectAoi_Click(sender As System.Object, e As System.EventArgs) Handles BtnSelectAoi.Click

    End Sub

    Private Sub TxtUploadPath_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtUploadPath.TextChanged
        If Not String.IsNullOrEmpty(TxtUploadPath.Text) Then
            BtnUploadZip.Enabled = True
        End If
    End Sub

    Private Sub BtnClear_Click(sender As System.Object, e As System.EventArgs) Handles BtnClear.Click
        GrdTasks.Rows.Clear()
        For Each aTimer As AoiUploadTimer In m_timersList
            aTimer.CloseTimer()
        Next
        m_timersList.Clear()
        For Each aTimer As AoiDownloadTimer In m_downTimersList
            aTimer.CloseTimer()
        Next
        m_downTimersList.Clear()
        BtnDownloadAoi.Enabled = True
    End Sub

    Private Sub BtnSelectDownloadFolder_Click(sender As System.Object, e As System.EventArgs) Handles BtnSelectDownloadFolder.Click
        Dim bObjectSelected As Boolean
        Dim pGxDialog As IGxDialog = New GxDialog
        Dim pGxObject As IEnumGxObject = Nothing
        Dim pFilter As IGxObjectFilter = New GxFilterContainers

        'initialize and open mini browser
        With pGxDialog
            .AllowMultiSelect = False
            .ButtonCaption = "Select"
            .Title = "Select folder for download"
            .ObjectFilter = pFilter
            bObjectSelected = .DoModalOpen(My.ArcMap.Application.hWnd, pGxObject)
        End With

        If bObjectSelected = False Then Exit Sub

        'get the name of the selected folder
        Dim pGxDataFolder As IGxFile
        pGxDataFolder = pGxObject.Next
        TxtDownloadPath.Text = pGxDataFolder.Path
    End Sub

    Private Sub TxtDownloadPath_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDownloadPath.TextChanged
        If Not String.IsNullOrEmpty(TxtDownloadPath.Text) Then
            BtnDownloadAoi.Enabled = True
        End If
    End Sub

    Private Function GenerateToken() As BA_ReturnCode
        If String.IsNullOrEmpty(m_token.token) Then
            Dim tokenUrl = TxtBasinsDb.Text & "api-token-auth/"
            Dim strToken As String = SecurityHelper.GetServerToken(m_userName, m_password, tokenUrl)
            m_token.token = strToken
            If String.IsNullOrEmpty(strToken) Then
                MessageBox.Show("Invalid user name or password. Failed to connect to database.", "Failed Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return BA_ReturnCode.OtherError
            End If
        End If
        Return BA_ReturnCode.Success
    End Function

    Friend Function DownloadFile(ByVal aoiDownload As AoiDownload) As BA_ReturnCode
        ' Using WebClient for built-in file download functionality
        Dim myWebClient As New WebClient()
        Try
            'Retrieve the token and format it for the header; Token comes from caller
            Dim cred As String = String.Format("{0} {1}", "Token", m_token.token)
            'Put token in header
            myWebClient.Headers(HttpRequestHeader.Authorization) = cred
            AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadFileCompleted
            AddHandler myWebClient.DownloadProgressChanged, AddressOf DownloadProgressCallback
            Dim downloadUri As Uri = New Uri(aoiDownload.Url)
            myWebClient.DownloadFileAsync(downloadUri, aoiDownload.FilePath, aoiDownload)
            Dim elapsedTime As TimeSpan = Now.Subtract(aoiDownload.StartTime)
            UpdateDownloadStatus(aoiDownload, elapsedTime.TotalSeconds, "Downloading file")
            Return BA_ReturnCode.Success
        Catch ex As Exception
            Debug.Print("DownloadFile: " & ex.Message)
            Return BA_ReturnCode.UnknownError
        End Try

    End Function

    Private Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Try
            Me.EnableDownloadBtn(BtnDownloadAoi, True)
            ' File download completed
            Dim aoiDownload As AoiDownload = CType(e.UserState, AoiDownload)
            Dim elapsedTime As TimeSpan = Now.Subtract(aoiDownload.StartTime)
            If e.Error IsNot Nothing Then
                aoiDownload.Status = BA_Task_Failure
                UpdateDownloadStatus(aoiDownload, elapsedTime.TotalSeconds, e.Error.Message)
                Exit Sub
            End If
            If e.Cancelled = True Then
                aoiDownload.Status = BA_Task_Failure
                UpdateDownloadStatus(aoiDownload, elapsedTime.TotalSeconds, "Download cancelled")
                Exit Sub
            End If
            If e.Cancelled = False And e.Error Is Nothing Then
                aoiDownload.Status = BA_Task_Success
                UpdateDownloadStatus(aoiDownload, elapsedTime.TotalSeconds, "Download complete")
            End If
            'Dim messageBoxVB As New System.Text.StringBuilder()
            'messageBoxVB.AppendFormat("{0} = {1}", "AoiName", aoiDownload.AoiName)
            'messageBoxVB.AppendLine()
            'MessageBox.Show(messageBoxVB.ToString(), "DownloadFileCompleted Event")
        Catch ex As Exception
            Debug.Print("DownloadFileCompleted: " & ex.Message)
            MessageBox.Show(ex.Message, "DownloadFileCompleted Event Error")
        End Try
    End Sub

    Private Sub DownloadProgressCallback(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)

        '  Displays the operation identifier, and the transfer progress.
        'Console.WriteLine("0}    downloaded 1} of 2} bytes. 3} % complete...", _
        'CStr(e.UserState), e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage)
        Try
            ' File download completed
            Dim aoiDownload As AoiDownload = CType(e.UserState, AoiDownload)
            Dim elapsedTime As TimeSpan = Now.Subtract(aoiDownload.StartTime)
            UpdateDownloadStatus(aoiDownload, elapsedTime.TotalSeconds, "Downloading file")
        Catch ex As Exception
            Debug.Print("DownloadProgressCallback: " & ex.Message)
            MessageBox.Show(ex.Message, "DownloadProgressCallback Event Error")
        End Try
    End Sub

    Private Sub BtnUpload_Click(sender As System.Object, e As System.EventArgs) Handles BtnUpload.Click
        If SelectAoi() = BA_ReturnCode.Success Then     'Move to BtnSelect
            Dim aoiName As String = BA_GetBareName(TxtUploadPath.Text)
            'Dim zipFolder As String = aoiName & "_zip"
            Dim zipName As String = aoiName & ".zip"
            'If BA_CreateTempZipFolder(TxtUploadPath.Text, zipFolder) = BA_ReturnCode.Success Then
            Dim parentFolder As String = "PleaseReturn"
            Dim file1 As String = BA_GetBareName(TxtUploadPath.Text, parentFolder)
            'Create the archive
            'Dim archive As ESRI.ArcGIS.esriSystem.IZipArchive = New ESRI.ArcGIS.esriSystem.ZipArchive
            'archive.CreateArchive(parentFolder & zipName)
            'Dim targetFolder As String = parentFolder & zipFolder
            If BA_ZipGeodatabases(TxtUploadPath.Text, parentFolder & zipName) = BA_ReturnCode.Success Then
                'If BA_CopyMiscFiles(TxtUploadPath.Text, targetFolder) = BA_ReturnCode.Success Then
                '    If BA_CopyHrus(TxtUploadPath.Text, targetFolder) = BA_ReturnCode.Success Then
                '        If BA_ZipFolder(targetFolder, aoiName & ".zip") = BA_ReturnCode.Success Then

                '        End If
                '    End If
            End If
            'Close the archive
            'archive.CloseArchive()
            'End If
            'End If
        End If
    End Sub

    Private Function SelectAoi() As BA_ReturnCode
        Dim bObjectSelected As Boolean
        Dim pGxDialog As IGxDialog = New GxDialog
        Dim pGxObject As IEnumGxObject = Nothing
        Dim DataPath As String
        Dim pFilter As IGxObjectFilter = New GxFilterContainers

        Try
            'initialize and open mini browser
            With pGxDialog
                .AllowMultiSelect = False
                .ButtonCaption = "Select"
                .Title = "Select AOI Folder"
                .ObjectFilter = pFilter
                bObjectSelected = .DoModalOpen(My.ArcMap.Application.hWnd, pGxObject)
            End With

            If bObjectSelected = False Then Exit Function

            'get the name of the selected folder
            Dim pGxDataFolder As IGxFile
            pGxDataFolder = pGxObject.Next
            DataPath = pGxDataFolder.Path
            If String.IsNullOrEmpty(DataPath) Then Exit Function 'user cancelled the action

            'check AOI/BASIN status
            Dim success As BA_ReturnCode = BA_CheckAoiStatus(DataPath, My.ArcMap.Application.hWnd, My.ArcMap.Document)
            If success = BA_ReturnCode.Success Then
                TxtUploadPath.Text = DataPath
            End If
        Catch ex As Exception
            Debug.Print("SelectAoi Exception: " & ex.Message)
            Return BA_ReturnCode.OtherError
        End Try
    End Function

End Class