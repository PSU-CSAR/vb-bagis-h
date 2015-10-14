Imports System.Windows.Forms
Imports System.Net
Imports System.Text
Imports System.IO
Imports BAGIS_ClassLibrary
Imports ESRI.ArcGIS.CatalogUI
Imports ESRI.ArcGIS.Catalog
Imports ESRI.ArcGIS.esriSystem

Public Class FrmDownloadAoiMenu

    Private idxAoiName As Integer = 0
    Private idxDateUploaded As Integer = 1
    Private idxAuthor As Integer = 2
    Private idxDownload As Integer = 3
    Private idxComment As Integer = 4
    Private idxDownloadUrl As Integer = 5
    Private idxTaskAoi As Integer = 0
    Friend idxTaskType As Integer = 1
    Private idxTaskStatus As Integer = 2
    Private idxTaskTime As Integer = 3
    Private idxTaskMessage As Integer = 4
    Friend idxTaskUrl As Integer = 5
    Private idxTaskId As Integer = 6
    Private idxTaskLocalPath As Integer = 7
    Friend idxDownloadStatus As Integer = 8
    Private m_timer As AoiDownloadTimer = Nothing

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Set reference to HruExtension
        Dim hruExt As HruExtension = HruExtension.GetExtension

        'Set the user name and password from a text file that is NOT in source countrol
        'Note: Developers will have to change this to a path valid on their machine
        Dim filePath As String = "C:\Docs\Lesley\Repository\vb\BAGIS_H\branches\lbross\src\BAGIS_H\GoldenTicket.txt"
        '@ToDo: In the future, this comes from user input
        Try
            ' Create an instance of StreamReader to read from a file.
            ' The using statement also closes the StreamReader.
            Using sr As New StreamReader(filePath)
                hruExt.EBagisUserName = sr.ReadLine()
                hruExt.EBagisPassword = sr.ReadLine()
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
                    Dim downloadFilePath As String = TxtDownloadPath.Text & "\" & Convert.ToString(pRow.Cells(idxAoiName).Value)
                    If Directory.Exists(downloadFilePath) Then dList.Add(Convert.ToString(pRow.Cells(idxAoiName).Value))
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
                        .Cells(idxTaskType).Value = BA_TASK_DOWNLOAD
                        .Cells(idxTaskStatus).Value = BA_Task_Staging
                        .Cells(idxTaskTime).Value = "N/A"
                    End With
                    GrdTasks.Rows.Add(item)
                    Application.DoEvents()
                    'Set reference to HruExtension
                    Dim hruExt As HruExtension = HruExtension.GetExtension
                    Dim aDownload As AoiTask = BA_Download_Aoi(downloadUrl, hruExt.EbagisToken.token)
                    If aDownload.task IsNot Nothing Then
                        Dim interval As UInteger = 10000    'Value in milleseconds
                        If m_timer Is Nothing Then
                            m_timer = New AoiDownloadTimer(hruExt.EbagisToken.token, interval, Me)
                        End If
                        With item
                            .Cells(idxTaskStatus).Value = aDownload.task.status
                            .Cells(idxTaskUrl).Value = aDownload.url
                            .Cells(idxTaskTime).Value = DateTime.Now.ToString("MM/dd/yy H:mm")
                            .Cells(idxTaskMessage).Value = "Assembling download"
                            .Cells(idxTaskId).Value = aDownload.id
                            .Cells(idxTaskLocalPath).Value = TxtDownloadPath.Text & "\" & aoiName & ".zip"
                            .Cells(idxDownloadStatus).Value = BA_Download_Processing
                        End With
                        If m_timer.Enabled = False Then m_timer.EnableTimer(True)
                    Else
                        With item
                            .Cells(idxTaskStatus).Value = BA_Task_Failure
                            .Cells(idxTaskMessage).Value = "An error occurred while trying to download the AOI"
                            .Cells(idxDownloadStatus).Value = BA_Download_Complete
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

        Dim success As BA_ReturnCode = GenerateToken()

        If success = BA_ReturnCode.Success Then
            'Set reference to HruExtension
            Dim hruExt As HruExtension = HruExtension.GetExtension
            Dim storedAois As Dictionary(Of String, StoredAoi) = BA_List_Aoi(TxtBasinsDb.Text, hruExt.EbagisToken.token)
            RefreshGrid(storedAois)
        End If
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
                .Cells(idxComment).Value = kvp.Value.comment
                .Cells(idxDownloadUrl).Value = kvp.Value.url
            End With
            AoiGrid.Rows.Add(item)
        Next kvp
        AoiGrid.Sort(AoiGrid.Columns(idxAoiName), System.ComponentModel.ListSortDirection.Ascending)
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

        Dim fileName As String = Path.GetFileNameWithoutExtension(TxtUploadPath.Text)
        If String.IsNullOrEmpty(fileName) Then
            MessageBox.Show("No file selected to upload", "No file selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        UploadAoi(TxtUploadPath.Text)
    End Sub

    'Work around cross-threading exception to update task table
    Friend Sub UpdateStatus(ByVal ctl As Control, ByVal aoiUpload As AoiTask, ByVal strMessage As String)
        If ctl.InvokeRequired Then
            ctl.BeginInvoke(New Action(Of Control, AoiTask, String)(AddressOf UpdateStatus), ctl, aoiUpload, strMessage)
        Else
            For Each row As DataGridViewRow In GrdTasks.Rows
                Dim url As String = row.Cells(idxTaskUrl).Value
                If url = aoiUpload.url Then
                    row.Cells(idxTaskStatus).Value = aoiUpload.task.status
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

    Private Sub UpdateDownloadStatus(ByVal aoiDownload As AoiDownloadInfo, ByVal strMessage As String)
        For Each row As DataGridViewRow In GrdTasks.Rows
            Dim url As String = row.Cells(idxTaskUrl).Value
            If url = aoiDownload.Url Then
                row.Cells(idxTaskStatus).Value = aoiDownload.Status
                row.Cells(idxTaskMessage).Value = strMessage
                row.Cells(idxDownloadStatus).Value = aoiDownload.Status
                Exit Sub
            End If
        Next
        Application.DoEvents()
    End Sub

    Private Sub BtnSelectAoi_Click(sender As System.Object, e As System.EventArgs) Handles BtnSelectAoi.Click
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

            If bObjectSelected = False Then Exit Sub

            'get the name of the selected folder
            Dim pGxDataFolder As IGxFile
            pGxDataFolder = pGxObject.Next
            DataPath = pGxDataFolder.Path
            If String.IsNullOrEmpty(DataPath) Then Exit Sub 'user cancelled the action

            'check AOI/BASIN status
            Dim success As BA_ReturnCode = BA_CheckAoiStatus(DataPath, My.ArcMap.Application.hWnd, My.ArcMap.Document)
            If success = BA_ReturnCode.Success Then
                If GenerateToken() = BA_ReturnCode.Success Then
                    Dim aoiName As String = BA_GetBareName(DataPath)
                    'Set reference to HruExtension
                    Dim hruExt As HruExtension = HruExtension.GetExtension
                    Dim inArchive As Boolean = BA_AoiInArchive(TxtBasinsDb.Text, hruExt.EbagisToken.token, aoiName)
                    If inArchive = False Then
                        TxtUploadPath.Text = DataPath
                    Else
                        Dim sb As StringBuilder = New StringBuilder
                        sb.Append("An AOI named '" & aoiName & "' already exists in the repository. ")
                        sb.Append("Please use the update form to update parts of this AOI or ")
                        sb.Append("select another AOI to upload.")
                        MessageBox.Show(sb.ToString, "AOI already exists", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Debug.Print("BtnSelectAoi_Click Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub TxtUploadPath_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtUploadPath.TextChanged
        If Not String.IsNullOrEmpty(TxtUploadPath.Text) Then
            BtnUpload.Enabled = True
        Else
            BtnUpload.Enabled = False
        End If
    End Sub

    Private Sub BtnClear_Click(sender As System.Object, e As System.EventArgs) Handles BtnClear.Click
        GrdTasks.Rows.Clear()
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
        Return SecurityHelper.GenerateToken(TxtBasinsDb.Text & "validate-token/", TxtBasinsDb.Text & "api-token-auth/")
    End Function

    Friend Function DownloadFile(ByVal url As String) As BA_ReturnCode
        ' Using WebClient for built-in file download functionality
        Dim myWebClient As New WebClient()
        Try
            'Set reference to HruExtension
            Dim hruExt As HruExtension = HruExtension.GetExtension
            'Retrieve the token and format it for the header; Token comes from caller
            Dim cred As String = String.Format("{0} {1}", "Token", hruExt.EbagisToken.token)
            'Put token in header
            myWebClient.Headers(HttpRequestHeader.Authorization) = cred
            AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadFileCompleted
            AddHandler myWebClient.DownloadProgressChanged, AddressOf DownloadProgressCallback
            Dim downloadUri As Uri = New Uri(url)
            Dim aoiDownload As AoiDownloadInfo = Nothing
            ' Populate the AoiDownloadInfo object from the grid
            For Each row As DataGridViewRow In GrdTasks.Rows
                If row.Cells(idxDownloadUrl).Value.Equals(url) Then
                    Dim downloadFilePath As String = row.Cells(idxTaskLocalPath).Value
                    Dim id As String = row.Cells(idxTaskId).Value
                    Dim beginTime As DateTime = DateTime.Parse(row.Cells(idxTaskTime).Value)
                    aoiDownload = New AoiDownloadInfo(url, BA_Task_Success, beginTime, downloadFilePath, id)
                    aoiDownload.downloadStatus = BA_Download_Download_Started
                End If
            Next
            m_timer.EnableTimer(False)
            myWebClient.DownloadFileAsync(downloadUri, aoiDownload.FilePath, aoiDownload)
            UpdateDownloadStatus(aoiDownload, "Downloading file")
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
            Dim aoiDownload As AoiDownloadInfo = CType(e.UserState, AoiDownloadInfo)
            aoiDownload.downloadStatus = BA_Download_Complete
            If e.Error IsNot Nothing Then
                aoiDownload.Status = BA_Task_Failure
                UpdateDownloadStatus(aoiDownload, e.Error.Message)
                Exit Sub
            End If
            If e.Cancelled = True Then
                aoiDownload.Status = BA_Task_Failure
                UpdateDownloadStatus(aoiDownload, "Download cancelled")
                Exit Sub
            End If
            ' The download succeeded !!
            If e.Cancelled = False And e.Error Is Nothing Then
                aoiDownload.Status = BA_Task_Pending
                UpdateDownloadStatus(aoiDownload, "Unzipping file")
                Dim parentFolder As String = "PleaseReturn"
                Dim zipFile As String = BA_GetBareName(aoiDownload.FilePath, parentFolder)
                Dim zipFilePath As String = aoiDownload.FilePath
                Dim success As BA_ReturnCode = BA_UnzipAoi(zipFilePath, parentFolder & aoiDownload.AoiName)
                If success = BA_ReturnCode.Success Then
                    aoiDownload.Status = BA_Task_Success
                    UpdateDownloadStatus(aoiDownload, "Download complete")
                    UpdateLog(aoiDownload.id, aoiDownload.Status, Nothing)
                    success = BA_Remove_File(zipFilePath)
                Else
                    aoiDownload.Status = BA_Task_Failure
                    UpdateDownloadStatus(aoiDownload, "An error occurred while unzipping the AOI")
                    UpdateLog(aoiDownload.id, aoiDownload.Status, "An error occurred while unzipping the AOI")
                End If
            End If
            'Dim messageBoxVB As New System.Text.StringBuilder()
            'messageBoxVB.AppendFormat("{0} = {1}", "AoiName", aoiDownload.AoiName)
            'messageBoxVB.AppendLine()
            'MessageBox.Show(messageBoxVB.ToString(), "DownloadFileCompleted Event")
        Catch ex As Exception
            Debug.Print("DownloadFileCompleted: " & ex.Message)
            MessageBox.Show("DownloadFileCompleted Event Error" & ex.Message)
        End Try
    End Sub

    Private Sub DownloadProgressCallback(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)

        '  Displays the operation identifier, and the transfer progress.
        'Console.WriteLine("0}    downloaded 1} of 2} bytes. 3} % complete...", _
        'CStr(e.UserState), e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage)
        Try
            ' File download completed
            Dim aoiDownload As AoiDownloadInfo = CType(e.UserState, AoiDownloadInfo)
            Dim elapsedTime As TimeSpan = Now.Subtract(aoiDownload.StartTime)
            UpdateDownloadStatus(aoiDownload, "Downloading file")
        Catch ex As Exception
            Debug.Print("DownloadProgressCallback: " & ex.Message)
            MessageBox.Show(ex.Message, "DownloadProgressCallback Event Error")
        End Try
    End Sub

    Private Sub BtnUpload_Click(sender As System.Object, e As System.EventArgs) Handles BtnUpload.Click
        Dim archive As IZipArchive = New ZipArchive
        Dim tempFile As String = "\tempZip.txt"
        Try
            If Not String.IsNullOrEmpty(TxtUploadPath.Text) Then
                Dim aoiName As String = BA_GetBareName(TxtUploadPath.Text)
                Dim zipName As String = aoiName & ".zip"
                Dim parentFolder As String = "PleaseReturn"
                Dim file1 As String = BA_GetBareName(TxtUploadPath.Text, parentFolder)
                archive.CreateArchive(parentFolder & zipName)
                If File.Exists(TxtUploadPath.Text & tempFile) = False Then
                    ' Create a file to write to.
                    Dim sw As StreamWriter = File.CreateText(TxtUploadPath.Text & tempFile)
                    sw.WriteLine("Temporary file for uploading an aoi")
                    sw.Flush()
                    sw.Close()
                End If
                'archive api requires file at the root to correctly set relative paths within archive
                archive.AddFile(TxtUploadPath.Text & tempFile)
                If BA_ZipGeodatabases(TxtUploadPath.Text, archive) = BA_ReturnCode.Success Then
                    If BA_ZipMiscFiles(TxtUploadPath.Text, archive) = BA_ReturnCode.Success Then
                        '@ToDo: Test upload with an HRU
                        BA_ZipHrus(TxtUploadPath.Text, archive)
                        archive.CloseArchive()
                        If GenerateToken() <> BA_ReturnCode.Success Then Exit Sub
                        UploadAoi(parentFolder & zipName)
                    End If
                End If
                BA_Remove_File(TxtUploadPath.Text & tempFile)
            Else
                MessageBox.Show("You must select an AOI to upload", "No AOI selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Debug.Print("BtnUpload_Click exception: " & ex.Message)
        Finally
            'Be sure the archive is closed
            archive.CloseArchive()
        End Try
    End Sub

    Private Sub UploadAoi(ByVal zipFilePath As String)

        Dim aoiName As String = Path.GetFileNameWithoutExtension(zipFilePath)
        '---create a row---
        Dim item As New DataGridViewRow
        item.CreateCells(GrdTasks)
        With item
            .Cells(idxTaskAoi).Value = aoiName
            .Cells(idxTaskType).Value = BA_TASK_UPLOAD
            .Cells(idxTaskStatus).Value = BA_Task_Staging
            .Cells(idxTaskTime).Value = "N/A"
        End With
        GrdTasks.Rows.Add(item)
        Application.DoEvents()

        Dim uploadUrl = TxtBasinsDb.Text & "aois/"
        'Set reference to HruExtension
        Dim hruExt As HruExtension = HruExtension.GetExtension
        Dim anUpload As AoiTask = BA_UploadMultiPart(uploadUrl, hruExt.EbagisToken.token, aoiName, zipFilePath, TxtComment.Text)
        If anUpload.task IsNot Nothing Then
            With item
                .Cells(idxTaskStatus).Value = anUpload.task.status
                .Cells(idxTaskUrl).Value = anUpload.url
                .Cells(idxTaskTime).Value = DateTime.Now.ToString("MM/dd/yy H:mm")
                .Cells(idxTaskId).Value = anUpload.id
                .Cells(idxTaskLocalPath).Value = TxtUploadPath.Text
            End With
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

    Friend Sub UpdateLog(ByVal id As String, ByVal status As String, ByVal errorMessage As String)
        Dim foundEntry As TaskLogEntry = Nothing
        For Each row As DataGridViewRow In GrdTasks.Rows
            If row.Cells(idxTaskId).Value.ToString.Equals(id) Then
                'Update the task log entry
                foundEntry = New TaskLogEntry()
                With foundEntry
                    foundEntry.id = id
                    foundEntry.aoiName = row.Cells(idxAoiName).Value.ToString
                    foundEntry.localFolder = row.Cells(idxTaskLocalPath).Value.ToString
                    foundEntry.taskType = row.Cells(idxTaskType).Value.ToString
                    foundEntry.status = status
                    foundEntry.dateCompleted = Now
                    foundEntry.errorMessage = errorMessage
                End With
                Exit For
            End If
        Next

        If foundEntry IsNot Nothing Then
            Dim log As TaskLog = Nothing
            'First try to load an existing log file
            Dim downloadPath As String = foundEntry.localFolder
            Dim parentFolder As String = "PleaseReturn"
            If foundEntry.taskType = BA_TASK_DOWNLOAD Then
                Dim tempFile As String = BA_GetBareName(downloadPath, parentFolder)
            End If
            If BA_File_ExistsWindowsIO(parentFolder & BA_EnumDescription(PublicPath.EBagisTaskLog)) Then
                Dim obj As Object = SerializableData.Load(parentFolder & BA_EnumDescription(PublicPath.EBagisTaskLog), GetType(TaskLog))
                If obj IsNot Nothing Then
                    log = CType(obj, TaskLog)
                End If
            End If
            'If log file doesn't exist then create a new one
            If log Is Nothing Then
                log = New TaskLog()
            End If
            'Add the new entry to the task log in memory
            Dim entries(0) As TaskLogEntry
            If log.TaskLogEntries IsNot Nothing Then
                entries = log.TaskLogEntries
                System.Array.Resize(entries, entries.Length + 1)
            End If
            entries(entries.Length - 1) = foundEntry
            log.TaskLogEntries = entries
            log.Save(parentFolder & BA_EnumDescription(PublicPath.EBagisTaskLog))
        End If
    End Sub


    Private Sub BtnTaskLog_Click(sender As System.Object, e As System.EventArgs) Handles BtnTaskLog.Click
        Dim frmTaskLog As FrmTaskLog = New FrmTaskLog
        frmTaskLog.ShowDialog()
    End Sub

    Private Sub BtnUpdateStatus_Click(sender As System.Object, e As System.EventArgs) Handles BtnUpdateStatus.Click
        For Each row As DataGridViewRow In GrdTasks.Rows
            Dim taskType As String = row.Cells(idxTaskType).Value
            If taskType.Equals(BA_TASK_UPLOAD) Then
                Dim url As String = row.Cells(idxTaskUrl).Value
                CheckUploadStatus(url)
            End If
        Next
    End Sub

    Private Sub CheckUploadStatus(ByVal uploadUrl As String)
        Dim reqT As HttpWebRequest
        Dim resT As HttpWebResponse
        Try
            reqT = WebRequest.Create(uploadUrl)
            'This is a GET request
            reqT.Method = "GET"

            'Retrieve the token and format it for the header
            Dim hruExt As HruExtension = HruExtension.GetExtension
            Dim cred As String = String.Format("{0} {1}", "Token", hruExt.EbagisToken.token)
            'Put token in header
            reqT.Headers(HttpRequestHeader.Authorization) = cred
            resT = CType(reqT.GetResponse(), HttpWebResponse)

            'Serialize the response so we can check the status
            Dim aoiUpload As AoiTask = New AoiTask()
            Dim ser As System.Runtime.Serialization.Json.DataContractJsonSerializer = New System.Runtime.Serialization.Json.DataContractJsonSerializer(aoiUpload.[GetType]())
            aoiUpload = CType(ser.ReadObject(resT.GetResponseStream), AoiTask)

            Dim uploadStatus As String = Trim(aoiUpload.task.status).ToUpper
            Dim strMessage As String = Nothing
            Select Case uploadStatus
                Case BA_Task_Started
                    Me.UpdateLog(aoiUpload.id, aoiUpload.task.status, strMessage)
                Case BA_Task_Success
                    Me.UpdateLog(aoiUpload.id, aoiUpload.task.status, strMessage)
                Case BA_Task_Pending
                    Me.UpdateLog(aoiUpload.id, aoiUpload.task.status, strMessage)
                Case BA_Task_Failure
                    strMessage = aoiUpload.task.traceback
                    Me.UpdateLog(aoiUpload.id, aoiUpload.task.status, strMessage)
            End Select
            Me.UpdateStatus(GrdTasks, aoiUpload, strMessage)
        Catch ex As WebException
            Debug.Print("OnTimedEvent: " & ex.Message)
        End Try
    End Sub
End Class