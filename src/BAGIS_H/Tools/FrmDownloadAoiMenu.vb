Imports System.Windows.Forms
Imports System.Net
Imports System.Text
Imports System.IO
Imports BAGIS_ClassLibrary
Imports ESRI.ArcGIS.CatalogUI
Imports ESRI.ArcGIS.Catalog
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Framework

Public Class FrmDownloadAoiMenu

    Private idxAoiName As Integer = 0
    Private idxDateUploaded As Integer = 1
    Private idxAuthor As Integer = 2
    Private idxSelectAoi As Integer = 3
    Private idxComment As Integer = 4
    Private idxDownloadUrl As Integer = 5
    Private idxTaskAoi As Integer = 0
    Private idxTaskType As Integer = 1
    Private idxTaskStatus As Integer = 2
    Private idxTaskTime As Integer = 3
    Private idxTaskMessage As Integer = 4
    Private idxTaskUrl As Integer = 5
    Private idxTaskId As Integer = 6
    Private idxTaskLocalPath As Integer = 7
    Private idxDownloadStatus As Integer = 8
    Private idxCancelTask As Integer = 9
    Private m_loading As Boolean = True
    Private m_settings As BagisHSettings
    Private m_maxMessageLength As Integer = 100
    Private m_aoiSearchFilter As AOISearchFilter = Nothing
    Private FILTER_PREFIX_LENGTH As Int16 = "Show ".Length
    ' We cache this here and don't apply it until filter is applied
    Private m_txtFilterDescr As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Set reference to HruExtension
        Dim hruExt As HruExtension = HruExtension.GetExtension

        ' Add any initialization after the InitializeComponent() call.
        Dim pStepProg As IStepProgressor = BA_GetStepProgressor(My.ArcMap.Application.hWnd, 1)
        Dim progressDialog2 As IProgressDialog2 = Nothing
        Try
            progressDialog2 = BA_GetProgressDialog(pStepProg, "Validating eBAGIS user account", "Validating")
            progressDialog2.Animation = esriProgressAnimationTypes.esriProgressSpiral
            pStepProg.Hide()    'Don't use step progressor
            progressDialog2.ShowDialog()

            'Look for location of basins server in local config file
            Dim localSettingsPath As String = hruExt.SettingsPath & BA_EnumDescription(PublicPath.BagisHSettings)
            If Not BA_File_ExistsWindowsIO(localSettingsPath) Then
                'Make sure the BAGIS folder is there
                Dim parentPath As String = "PleaseReturn"
                Dim bagisFolder As String = BA_GetBareName(localSettingsPath, parentPath)
                If Not BA_Folder_ExistsWindowsIO(parentPath) Then
                    Dim existingFolder As String = "PleaseReturn"
                    bagisFolder = BA_GetBareName(parentPath, existingFolder)
                    Dim newFolder As String = BA_CreateFolder(existingFolder, bagisFolder)
                End If
                Dim jsonFile As String = BA_GetBareName(BA_EnumDescription(PublicPath.BagisHSettings))
                Dim copyPath As String = BA_GetAddInDirectory() & "\" & jsonFile
                File.Copy(copyPath, localSettingsPath)
            End If
            m_settings = ReadSettingsFromJson(localSettingsPath)
            If m_settings IsNot Nothing Then
            End If
            m_loading = False   'turn off loading flag to turn on validation of server name
            If String.IsNullOrEmpty(TxtBasinsDb.Text) Then
                MessageBox.Show("The host name for the basins database could not be loaded. Please contact your system administrator")
            Else
                If GenerateToken() = BA_ReturnCode.Success Then
                    BtnSignIn.Text = "Sign out"
                End If
            End If
        Catch ex As Exception
            Debug.Print("frmDownloadAoiMenu_New Exception: " & ex.Message)
        Finally
            pStepProg = Nothing
            progressDialog2.HideDialog()
            progressDialog2 = Nothing
        End Try

        AoiGrid.ClearSelection()
        AoiGrid.CurrentCell = Nothing
        m_aoiSearchFilter = New AOISearchFilter()
        Me.ActiveControl = BtnList
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
                Dim ckDownload As Boolean = pRow.Cells(idxSelectAoi).Value
                If ckDownload = True Then
                    dCount += 1
                    Dim downloadFilePath As String = TxtDownloadPath.Text & "\" & Convert.ToString(pRow.Cells(idxAoiName).Value)
                    If Directory.Exists(downloadFilePath) Then dList.Add(Convert.ToString(pRow.Cells(idxAoiName).Value))

                    'Make sure the selected aoi isn't already being downloaded
                    Dim aoiName As String = Convert.ToString(pRow.Cells(idxAoiName).Value)
                    For Each tRow As DataGridViewRow In GrdTasks.Rows
                        If Convert.ToString(tRow.Cells(idxTaskType).Value).Equals(BA_TASK_DOWNLOAD) Then
                            Dim aoiTask As String = Convert.ToString(tRow.Cells(idxTaskAoi).Value)
                            If aoiName.Equals(aoiTask) Then
                                MessageBox.Show(aoiName & " is already being downloaded.")
                                pRow.Cells(idxSelectAoi).Value = False
                                Exit Sub
                            End If
                        End If
                    Next
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
                Dim res As DialogResult = MessageBox.Show(messageBoxVB.ToString, "Existing AOI's", MessageBoxButtons.YesNo)
                If Not res = Windows.Forms.DialogResult.Yes Then
                    Exit Sub
                End If
            End If

            'BtnDownloadAoi.Enabled = False
            For Each pRow As DataGridViewRow In AoiGrid.Rows
                Dim ckDownload As Boolean = pRow.Cells(idxSelectAoi).Value
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
                        .Cells(idxCancelTask).Value = False
                    End With
                    GrdTasks.Rows.Add(item)
                    'Uncheck selected download so not accidently reselected
                    pRow.Cells(idxSelectAoi).Value = False
                    Application.DoEvents()
                    'Set reference to HruExtension
                    BtnSignIn.Text = "Sign out"
                    Dim hruExt As HruExtension = HruExtension.GetExtension
                    Dim aDownload As AoiTask = BA_Download_Aoi(downloadUrl, hruExt.EbagisToken.key)
                    If aDownload.task IsNot Nothing Then
                        With item
                            .Cells(idxTaskStatus).Value = aDownload.task.status
                            .Cells(idxTaskUrl).Value = aDownload.url
                            .Cells(idxTaskTime).Value = DateTime.Now.ToString("MM/dd/yy H:mm")
                            .Cells(idxTaskMessage).Value = "Assembling download"
                            .Cells(idxTaskId).Value = aDownload.id
                            .Cells(idxTaskLocalPath).Value = TxtDownloadPath.Text & "\" & aoiName & ".zip"
                            .Cells(idxDownloadStatus).Value = BA_Download_Processing
                        End With
                        If DownloadTimer.Enabled = False Then DownloadTimer.Enabled = True
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
        Dim progressDialog2 As IProgressDialog2 = Nothing
        Try
            progressDialog2 = BA_GetAnimationProgressor(My.ArcMap.Application.hWnd, "Retrieving list of AOIs", "List AOIs")
            progressDialog2.ShowDialog()

            Dim storedAois As Dictionary(Of String, StoredAoi) = BA_List_Aoi(TxtBasinsDb.Text, m_aoiSearchFilter)
            If storedAois IsNot Nothing AndAlso storedAois.Count > 0 Then
                RefreshGrid(storedAois)
            Else
                AoiGrid.Rows.Clear()
                Dim errMessage As String = "No stored AOIs were found on this server!"
                If m_aoiSearchFilter IsNot Nothing Then _
                    errMessage = "No stored AOIs met the conditions of your search filter!"
                MessageBox.Show(errMessage, "BAGIS-H", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Debug.Print("BtnList_Click Exception: " & ex.Message)
        Finally
            BtnList.Enabled = True
            If progressDialog2 IsNot Nothing Then
                progressDialog2.HideDialog()
                progressDialog2 = Nothing
            End If
        End Try
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
                .Cells(3).Value = False
                .Cells(idxComment).Value = kvp.Value.comment
                .Cells(idxDownloadUrl).Value = kvp.Value.url
            End With
            AoiGrid.Rows.Add(item)
        Next kvp
        AoiGrid.Sort(AoiGrid.Columns(idxAoiName), System.ComponentModel.ListSortDirection.Ascending)
        AoiGrid.ClearSelection()
        AoiGrid.CurrentCell = Nothing
    End Sub

    Private Sub BtnUploadZip_Click(sender As System.Object, e As System.EventArgs)
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "zip files (*.zip)|*.zip"
        openFileDialog1.FilterIndex = 1
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TxtUploadPath.Text = openFileDialog1.FileName
        End If

        If GenerateToken() <> BA_ReturnCode.Success Then Exit Sub

        BtnSignIn.Text = "Sign out"
        Dim fileName As String = Path.GetFileNameWithoutExtension(TxtUploadPath.Text)
        If String.IsNullOrEmpty(fileName) Then
            MessageBox.Show("No file selected to upload", "No file selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        UploadAoi(TxtUploadPath.Text)
    End Sub

    'Work around cross-threading exception to update task table
    Private Sub UpdateStatus(ByVal aoiUpload As AoiTask, ByVal strMessage As String)
        Dim shortMessage As String = strMessage
        Try
            'Pause timer so we can show the MessageBox if we need to
            DownloadTimer.Stop()
            If Not String.IsNullOrEmpty(strMessage) AndAlso strMessage.Length > m_maxMessageLength Then
                shortMessage = strMessage.Substring(0, m_maxMessageLength)
            End If

            For Each row As DataGridViewRow In GrdTasks.Rows
                Dim url As String = row.Cells(idxTaskUrl).Value
                If url = aoiUpload.url Then
                    row.Cells(idxTaskStatus).Value = aoiUpload.task.status
                    row.Cells(idxTaskMessage).Value = shortMessage
                    ' Pop a messageBox if error message is too long to be displayed in grid
                    If Not String.IsNullOrEmpty(strMessage) Then
                        If Not strMessage.Equals(shortMessage) Then
                            Dim sb As StringBuilder = New StringBuilder
                            Dim aoiName As String = row.Cells(idxAoiName).Value
                            Dim taskType As String = row.Cells(idxTaskType).Value
                            sb.Append(aoiName & " " & taskType & " error!" & vbCrLf & vbCrLf)
                            sb.Append(strMessage)
                            MessageBox.Show(sb.ToString, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                    Exit For
                End If
            Next
        Catch ex As Exception
            Debug.Print("UpdateStatus Exception: " & ex.Message)
        Finally
            'We always want to restart the download timer
            DownloadTimer.Start()
        End Try
    End Sub

    'Not currently used as of 26-APR-2016
    'Work around cross-threading exception to update task table
    'Friend Sub UpdateStatus(ByVal ctl As Control, ByVal taskId As String, ByVal taskStatus As String, ByVal strMessage As String)
    '    If ctl.InvokeRequired Then
    '        ctl.BeginInvoke(New Action(Of Control, String, String, String)(AddressOf UpdateStatus), _
    '                        ctl, taskId, taskStatus, strMessage)
    '    Else
    '        For Each row As DataGridViewRow In GrdTasks.Rows
    '            Dim tid As String = row.Cells(idxTaskId).Value
    '            If tid = taskId Then
    '                row.Cells(idxTaskStatus).Value = taskStatus
    '                row.Cells(idxTaskMessage).Value = strMessage
    '                Exit For
    '            End If
    '        Next
    '    End If
    'End Sub

    'Work around cross-threading exception to enable download button
    'Friend Sub EnableDownloadBtn(ByVal ctl As Control, ByVal Enabled As Boolean)
    '    If ctl.InvokeRequired Then
    '        ctl.BeginInvoke(New Action(Of Control, Boolean)(AddressOf EnableDownloadBtn), ctl, Enabled)
    '    Else
    '        BtnDownloadAoi.Enabled = Enabled
    '    End If
    '    Application.DoEvents()
    'End Sub

    'Note: This method sets the download status to complete so the timer stops checking it
    Private Sub UpdateDownloadStatus(ByVal aoiDownload As AoiDownloadInfo, ByVal strMessage As String)
        Dim shortMessage As String = strMessage
        Try
            'Pause timer so we can show the MessageBox if we need to
            DownloadTimer.Stop()
            If Not String.IsNullOrEmpty(strMessage) AndAlso strMessage.Length > m_maxMessageLength Then
                shortMessage = strMessage.Substring(0, m_maxMessageLength)
            End If
            For Each row As DataGridViewRow In GrdTasks.Rows
                Dim url As String = row.Cells(idxTaskUrl).Value
                If url = aoiDownload.Url Then
                    row.Cells(idxTaskStatus).Value = aoiDownload.Status
                    row.Cells(idxTaskMessage).Value = shortMessage
                    row.Cells(idxDownloadStatus).Value = BA_Download_Complete
                    If Not strMessage.Equals(shortMessage) Then
                        Dim sb As StringBuilder = New StringBuilder
                        Dim taskType As String = row.Cells(idxTaskType).Value
                        sb.Append(aoiDownload.AoiName & " " & taskType & " error!" & vbCrLf & vbCrLf)
                        sb.Append(strMessage)
                        MessageBox.Show(sb.ToString, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    Exit For
                End If
            Next
        Catch ex As Exception
            Debug.Print("UpdateDownloadStatus Exception: " & ex.Message)
        Finally
            'We always want to restart the download timer
            DownloadTimer.Start()
        End Try
    End Sub

    Private Sub BtnSelectAoi_Click(sender As System.Object, e As System.EventArgs) Handles BtnSelectAoi.Click
        If GenerateToken() = BA_ReturnCode.Success Then
            BtnSignIn.Text = "Sign out"
            Dim canUpload As Boolean = False
            Dim hruExt As HruExtension = HruExtension.GetExtension
            Dim lstGroups As IList(Of String) = hruExt.EbagisGroups
            If lstGroups IsNot Nothing AndAlso lstGroups.Count > 0 Then
                For Each strGroup As String In lstGroups
                    If strGroup.ToUpper.Trim.Equals(SecurityHelper.Groups.NWCC_ADMIN.ToString) Or _
                       strGroup.ToUpper.Trim.Equals(SecurityHelper.Groups.NWCC_STAFF.ToString) Then
                        canUpload = True
                        Exit For
                    End If
                Next
            End If
            If canUpload = False Then
                MessageBox.Show("You do not have permissions to upload AOIs to the Basins database!", "BAGIS-H", _
                                MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
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
                    Dim aoiName As String = BA_GetBareName(DataPath)
                    Dim inArchive As Boolean = BA_AoiInArchive(TxtBasinsDb.Text, aoiName)
                    If inArchive = False Then
                        TxtUploadPath.Text = DataPath
                    Else
                        Dim sb As StringBuilder = New StringBuilder
                        sb.Append("An AOI named '" & aoiName & "' already exists in the repository. ")
                        sb.Append("Please select another AOI to upload.")
                        MessageBox.Show(sb.ToString, "AOI already exists", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                Debug.Print("BtnSelectAoi_Click Exception: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Unable to sign in to Basins database. You cannot upload an AOI!", "BAGIS-H", _
                 MessageBoxButtons.OK, MessageBoxIcon.Hand)
            BtnSignIn.Text = "Sign in"
        End If
    End Sub

    Private Sub TxtUploadPath_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtUploadPath.TextChanged
        If Not String.IsNullOrEmpty(TxtUploadPath.Text) Then
            BtnUpload.Enabled = True
        Else
            Me.ActiveControl = BtnSelectAoi
            BtnUpload.Enabled = False
        End If
    End Sub

    Private Sub BtnClearCompleted_Click(sender As System.Object, e As System.EventArgs) Handles BtnClearCompleted.Click
        For x = GrdTasks.Rows.Count - 1 To 0 Step -1
            Dim pRow As DataGridViewRow = GrdTasks.Rows(x)
            Dim pStatus As String = Convert.ToString(pRow.Cells(idxTaskStatus).Value)
            ' Only remove rows with task status success, aborted, or failed
            Select Case pStatus
                Case BA_Task_Success
                    GrdTasks.Rows.RemoveAt(x)
                Case BA_Task_Aborted
                    GrdTasks.Rows.RemoveAt(x)
                Case BA_Task_Failure
                    GrdTasks.Rows.RemoveAt(x)
            End Select
        Next
    End Sub

    Private Sub BtnSelectDownloadFolder_Click(sender As System.Object, e As System.EventArgs) Handles BtnSelectDownloadFolder.Click
        'Check permissions before we let them start; If they can login, they can download
        If GenerateToken() <> BA_ReturnCode.Success Then
            MessageBox.Show("Unable to sign in to Basins database. You cannot download an AOI!", "BAGIS-H", _
                             MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If

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
        Return SecurityHelper.GenerateToken(TxtBasinsDb.Text & "account/user/", TxtBasinsDb.Text & "account/login/")
    End Function

    Friend Function DownloadFile(ByVal url As String) As BA_ReturnCode

        Try
            'Set reference to HruExtension
            Dim hruExt As HruExtension = HruExtension.GetExtension
            'Retrieve the token and format it for the header; Token comes from caller
            Dim cred As String = String.Format("{0} {1}", "Token", hruExt.EbagisToken.key)
            Dim downloadUri As Uri = New Uri(url)
            Dim aoiDownload As AoiDownloadInfo = Nothing
            ' Populate the AoiDownloadInfo object from the grid
            For Each row As DataGridViewRow In GrdTasks.Rows
                If Not String.IsNullOrEmpty(row.Cells(idxDownloadUrl).Value) AndAlso row.Cells(idxDownloadUrl).Value.Equals(url) Then
                    Dim downloadFilePath As String = row.Cells(idxTaskLocalPath).Value
                    Dim id As String = row.Cells(idxTaskId).Value
                    Dim beginTime As DateTime = DateTime.Parse(row.Cells(idxTaskTime).Value)
                    aoiDownload = New AoiDownloadInfo(url, BA_Task_Success, beginTime, downloadFilePath, id)
                    aoiDownload.downloadStatus = BA_Download_Download_Started
                    Exit For
                End If
            Next
            ' Using WebClient for built-in file download functionality
            Using myWebClient As New WebClient()
                'Put token in header
                myWebClient.Headers(HttpRequestHeader.Authorization) = cred
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadFileCompleted
                AddHandler myWebClient.DownloadProgressChanged, AddressOf DownloadProgressCallback
                myWebClient.DownloadFileAsync(downloadUri, aoiDownload.FilePath, aoiDownload)
            End Using
            UpdateDownloadStatus(aoiDownload, "Downloading file")
            Return BA_ReturnCode.Success
        Catch ex As Exception
            Debug.Print("DownloadFile: " & ex.Message)
            Return BA_ReturnCode.UnknownError
        End Try

    End Function

    Private Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Dim progressDialog2 As IProgressDialog2 = Nothing
        Try
            'Me.EnableDownloadBtn(BtnDownloadAoi, True)
            ' File download completed
            Dim aoiDownload As AoiDownloadInfo = CType(e.UserState, AoiDownloadInfo)
            aoiDownload.downloadStatus = BA_Download_Complete
            If e.Cancelled = True Then
                aoiDownload.Status = BA_Task_Aborted
                'Delete zip file since we cancelled the download
                If BA_File_ExistsWindowsIO(aoiDownload.FilePath) Then File.Delete(aoiDownload.FilePath)
                UpdateDownloadStatus(aoiDownload, "Download cancelled")
                Exit Sub
            End If
            If e.Error IsNot Nothing Then
                'Debug.Print("DownloadFileCompleted error: " & aoiDownload.Url)
                aoiDownload.Status = BA_Task_Failure
                'Delete zip file since there was an error
                If BA_File_ExistsWindowsIO(aoiDownload.FilePath) Then File.Delete(aoiDownload.FilePath)
                UpdateDownloadStatus(aoiDownload, e.Error.Message)
                Exit Sub
            End If
            ' The download succeeded !!
            If e.Cancelled = False And e.Error Is Nothing Then
                For Each row As DataGridViewRow In GrdTasks.Rows
                    Dim url As String = row.Cells(idxTaskUrl).Value
                    If url = aoiDownload.Url Then
                        Dim cancelFlag As Boolean = Convert.ToBoolean(row.Cells(idxCancelTask).Value)
                        If cancelFlag = True Then
                            aoiDownload.Status = BA_Task_Aborted
                            'Delete zip file since we cancelled the download
                            If BA_File_ExistsWindowsIO(aoiDownload.FilePath) Then File.Delete(aoiDownload.FilePath)
                            UpdateDownloadStatus(aoiDownload, "Download aborted")
                            Exit Sub
                        End If
                        Exit For
                    End If
                Next

                UpdateDownloadStatus(aoiDownload, "Unzipping file")
                progressDialog2 = BA_GetAnimationProgressor(My.ArcMap.Application.hWnd, "Unpacking " & aoiDownload.AoiName, "Unpacking AOI")
                progressDialog2.ShowDialog()
                Dim parentFolder As String = "PleaseReturn"
                Dim zipFile As String = BA_GetBareName(aoiDownload.FilePath, parentFolder)
                Dim zipFilePath As String = aoiDownload.FilePath
                Dim success As BA_ReturnCode = BA_UnzipAoi(zipFilePath, parentFolder & aoiDownload.AoiName)
                If success = BA_ReturnCode.Success Then
                    'aoiDownload.Status = BA_Task_Success
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
        Finally
            If progressDialog2 IsNot Nothing Then
                progressDialog2.HideDialog()
            End If
            progressDialog2 = Nothing
        End Try
    End Sub

    Private Sub DownloadProgressCallback(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)

        '  Displays the operation identifier, and the transfer progress.
        'Console.WriteLine("0}    downloaded 1} of 2} bytes. 3} % complete...", _
        'CStr(e.UserState), e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage)
        Try
            ' File download completed
            Dim aoiDownload As AoiDownloadInfo = CType(e.UserState, AoiDownloadInfo)
            For Each row As DataGridViewRow In GrdTasks.Rows
                Dim url As String = row.Cells(idxTaskUrl).Value
                If url = aoiDownload.Url Then
                    'Debug.Print(aoiDownload.AoiName & " progress callback: " & elapsedTime.ToString)
                    Dim cancelFlag As Boolean = Convert.ToBoolean(row.Cells(idxCancelTask).Value)
                    'Debug.Print(aoiDownload.AoiName & " cancelFlag: " & cancelFlag)
                    If cancelFlag = True Then
                        Dim cancelClient As WebClient = CType(sender, WebClient)
                        cancelClient.CancelAsync()
                        'Debug.Print(aoiDownload.AoiName & " download cancelled")
                    End If
                    Exit For
                End If
            Next
        Catch ex As Exception
            Debug.Print("DownloadProgressCallback: " & ex.Message)
            MessageBox.Show(ex.Message, "DownloadProgressCallback Event Error")
        End Try
    End Sub

    Private Sub BtnUpload_Click(sender As System.Object, e As System.EventArgs) Handles BtnUpload.Click
        Dim archive As IZipArchive = New ZipArchive
        Dim tempFile As String = "\tempZip.txt"
        Dim progressDialog2 As IProgressDialog2 = Nothing
        Try
            If Not String.IsNullOrEmpty(TxtUploadPath.Text) Then
                Dim aoiName As String = BA_GetBareName(TxtUploadPath.Text)
                Dim zipName As String = aoiName & ".zip"
                Dim parentFolder As String = "PleaseReturn"
                Dim file1 As String = BA_GetBareName(TxtUploadPath.Text, parentFolder)
                progressDialog2 = BA_GetAnimationProgressor(My.ArcMap.Application.hWnd, "Preparing " & aoiName & " for upload", "Zipping AOI")
                progressDialog2.ShowDialog()
                archive.CreateArchive(parentFolder & zipName)
                If File.Exists(TxtUploadPath.Text & tempFile) = False Then
                    ' Create a file to write to.
                    Using sw As StreamWriter = File.CreateText(TxtUploadPath.Text & tempFile)
                        sw.WriteLine("Temporary file for uploading an aoi")
                        sw.Flush()
                    End Using
                End If
                'archive api requires file at the root to correctly set relative paths within archive
                archive.AddFile(TxtUploadPath.Text & tempFile)
                Dim success As BA_ReturnCode = BA_ReturnCode.UnknownError
                If BA_ZipGeodatabases(TxtUploadPath.Text, archive) = BA_ReturnCode.Success Then
                    If BA_ZipMiscFiles(TxtUploadPath.Text, archive) = BA_ReturnCode.Success Then
                        success = BA_ZipHrus(TxtUploadPath.Text, archive)
                        archive.CloseArchive()
                        If GenerateToken() <> BA_ReturnCode.Success Then Exit Sub
                        progressDialog2.HideDialog()
                        BtnSignIn.Text = "Sign out"
                        'Set reference to HruExtension
                        Dim hruExt As HruExtension = HruExtension.GetExtension
                        Dim zipFileInfo As System.IO.FileInfo = New FileInfo(parentFolder & zipName)
                        Const CHUNK_SIZE As Integer = 4 * 1024.0F * 1024.0F   '4 MB
                        If zipFileInfo.Length > CHUNK_SIZE Then
                            Dim anUpload As AoiTask = UploadAoiChunked(zipFileInfo, hruExt.EbagisToken.key, CHUNK_SIZE)
                            If anUpload IsNot Nothing Then
                                success = BA_FinishChunkedUpload(anUpload, hruExt.EbagisToken.key)
                            End If
                        Else
                            UploadAoi(parentFolder & zipName)
                        End If
                    End If
                Else
                    MessageBox.Show("Unable to add the AOI geodatabases to the .zip file for upload! " + _
                                    "Restart ArcMap and try again. ", "eBAGIS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                archive.CloseArchive()
                success = BA_Remove_File(parentFolder & zipName)
            Else
                MessageBox.Show("You must select an AOI to upload", "No AOI selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Debug.Print("BtnUpload_Click exception: " & ex.Message)
        Finally
            progressDialog2.HideDialog()
            progressDialog2 = Nothing
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
        Dim anUpload As AoiTask = BA_UploadMultiPart(uploadUrl, hruExt.EbagisToken.key, aoiName, zipFilePath, TxtComment.Text)
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
            'Clear out comments field
            TxtComment.Text = Nothing
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
            If Not String.IsNullOrEmpty(row.Cells(idxTaskId).Value) AndAlso _
                row.Cells(idxTaskId).Value.ToString.Equals(id) Then
                'Update the task log entry
                foundEntry = New TaskLogEntry()
                Dim zipPath As String = row.Cells(idxTaskLocalPath).Value.ToString  'The path of the .zip file
                Dim localAoiPath As String = "PleaseReturn"
                Dim tempFile As String = BA_GetBareName(zipPath, localAoiPath)
                With foundEntry
                    foundEntry.id = id
                    foundEntry.aoiName = row.Cells(idxAoiName).Value.ToString
                    foundEntry.localFolder = localAoiPath & foundEntry.aoiName
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
            If BA_File_ExistsWindowsIO(foundEntry.localFolder & BA_EnumDescription(PublicPath.EBagisTaskLog)) Then
                Dim obj As Object = SerializableData.Load(foundEntry.localFolder & BA_EnumDescription(PublicPath.EBagisTaskLog), GetType(TaskLog))
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
            log.Save(foundEntry.localFolder & BA_EnumDescription(PublicPath.EBagisTaskLog))
        End If
    End Sub


    Private Sub BtnAoiHistory_Click(sender As System.Object, e As System.EventArgs) Handles BtnAoiHistory.Click
        '@ToDo: When the AOI log functionality is completed, this button will display the log
        'Dim frmTaskLog As FrmTaskLog = New FrmTaskLog
        'frmTaskLog.ShowDialog()
    End Sub

    Private Sub BtnRefreshTasks_Click(sender As System.Object, e As System.EventArgs) Handles BtnRefreshTasks.Click
        For Each row As DataGridViewRow In GrdTasks.Rows
            Dim taskType As String = row.Cells(idxTaskType).Value
            If taskType.Equals(BA_TASK_UPLOAD) Then
                Dim url As String = row.Cells(idxTaskUrl).Value
                CheckUploadStatus(url)
            End If
        Next
        Application.DoEvents()
    End Sub

    Private Sub CheckUploadStatus(ByVal uploadUrl As String)
        Try
            Dim reqT As HttpWebRequest = WebRequest.Create(uploadUrl)
            'This is a GET request
            reqT.Method = "GET"
            Dim aoiUpload As AoiTask = New AoiTask()

            'Retrieve the token and format it for the header
            Dim hruExt As HruExtension = HruExtension.GetExtension
            Dim cred As String = String.Format("{0} {1}", "Token", hruExt.EbagisToken.key)
            'Put token in header
            reqT.Headers(HttpRequestHeader.Authorization) = cred
            'Set the accept header to request a lower version of the api
            reqT.Accept = "application/json; version=" + BA_EbagisApiVersion
            Using resT As HttpWebResponse = CType(reqT.GetResponse(), HttpWebResponse)
                'Serialize the response so we can check the status
                Dim ser As System.Runtime.Serialization.Json.DataContractJsonSerializer = New System.Runtime.Serialization.Json.DataContractJsonSerializer(aoiUpload.[GetType]())
                aoiUpload = CType(ser.ReadObject(resT.GetResponseStream), AoiTask)
            End Using

            Dim uploadStatus As String = Nothing
            If aoiUpload.task IsNot Nothing Then
                uploadStatus = Trim(aoiUpload.task.status).ToUpper
            Else
                uploadStatus = Trim(aoiUpload.status).ToUpper
            End If

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
            Me.UpdateStatus(aoiUpload, strMessage)
        Catch webEx As WebException
            Debug.Print("CheckUploadStatus WebException: " & webEx.Message)
        Catch ex As Exception
            Debug.Print("CheckUploadStatus Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub DownloadTimer_Tick(sender As System.Object, e As System.EventArgs) Handles DownloadTimer.Tick
        Try
            Dim activeDownloads As Integer = 0
            Dim hruExt As HruExtension = HruExtension.GetExtension
            For Each pRow As DataGridViewRow In GrdTasks.Rows
                Dim downloadTask As AoiTask = Nothing
                Dim downloadStatus As String = pRow.Cells(idxDownloadStatus).Value
                Dim taskType As String = pRow.Cells(idxTaskType).Value
                If taskType.Equals(BA_TASK_DOWNLOAD) AndAlso Not String.IsNullOrEmpty(downloadStatus) _
                    AndAlso downloadStatus.Equals(BA_Download_Processing) Then
                    activeDownloads += 1
                    Dim url As String = pRow.Cells(idxTaskUrl).Value
                    'Check to see if we have a zip file
                    Dim contentType As String = WebservicesModule.BA_GetResponseContentType(url, hruExt.EbagisToken.key)

                    If contentType = BA_Mime_Compressed_Zip Then
                        Dim success As BA_ReturnCode = Me.DownloadFile(url)
                        Exit Sub
                    Else
                        downloadTask = BA_Download_Aoi(url, hruExt.EbagisToken.key)
                    End If

                    If downloadTask.task IsNot Nothing Then
                        Dim taskStatus As String = Trim(downloadTask.task.status).ToUpper
                        Select Case taskStatus
                            Case BA_Task_Failure
                                Dim downloadFilePath As String = pRow.Cells(idxTaskLocalPath).Value
                                Dim id As String = pRow.Cells(idxTaskId).Value
                                Dim beginTime As DateTime = DateTime.Parse(pRow.Cells(idxTaskTime).Value)
                                Dim aoiDownload As AoiDownloadInfo = New AoiDownloadInfo(url, taskStatus, beginTime, downloadFilePath, id)
                                Me.UpdateDownloadStatus(aoiDownload, downloadTask.task.traceback)
                                Debug.Print("Download failure from server: " & downloadTask.task.traceback)
                            Case BA_Task_Pending
                                Me.UpdateStatus(downloadTask, "Assembling download")
                        End Select
                    End If
                End If
            Next
            If activeDownloads < 1 Then DownloadTimer.Enabled = False
        Catch ex As WebException
            Debug.Print("DownloadTimer.Tick Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub GrdTasks_SelectionChanged(sender As Object, e As System.EventArgs) Handles GrdTasks.SelectionChanged
        Dim rows As DataGridViewSelectedRowCollection = GrdTasks.SelectedRows()
        If rows.Count = 1 Then
            BtnCancelTask.Enabled = True
        End If
    End Sub

    Private Sub BtnCancelTask_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelTask.Click
        Dim progressDialog2 As IProgressDialog2 = Nothing
        Dim rows As DataGridViewSelectedRowCollection = GrdTasks.SelectedRows()
        'Set reference to HruExtension
        Dim hruExt As HruExtension = HruExtension.GetExtension
        Try
            For Each aRow As DataGridViewRow In rows
                Dim aoiName As String = aRow.Cells(idxAoiName).Value
                If aRow.Cells(idxTaskType).Value.Equals(BA_TASK_UPLOAD) Then
                    'Uploads
                    'Can't do anything until upload actually starts; GUI is locked when zipping under way
                    'Only pending/started tasks can be cancelled
                    If aRow.Cells(idxTaskStatus).Value.Equals(BA_Task_Pending) Or _
                        aRow.Cells(idxTaskStatus).Value.Equals(BA_Task_Started) Then
                        Dim warningMessage As String = "Are you sure you want to cancel the upload for AOI: " & aoiName & _
                            "? This action cannot be reversed!"
                        Dim res1 As DialogResult = MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.YesNo, _
                                                                   MessageBoxIcon.Question)
                        If res1 = Windows.Forms.DialogResult.Yes Then
                            progressDialog2 = BA_GetAnimationProgressor(My.ArcMap.Application.hWnd, "Sending cancellation request for " & aoiName, "Cancelling upload")
                            progressDialog2.ShowDialog()
                            Dim taskId As String = Convert.ToString(aRow.Cells(idxTaskId).Value)
                            Dim taskStatus As String = Convert.ToString(aRow.Cells(idxTaskStatus).Value)
                            Dim cancelMessage As String = BA_CancelUpload(TxtBasinsDb.Text, taskId, hruExt.EbagisToken.key, taskStatus)
                            If Not String.IsNullOrEmpty(taskStatus) Then
                                aRow.Cells(idxTaskStatus).Value = taskStatus
                            End If
                            aRow.Cells(idxTaskMessage).Value = cancelMessage
                            progressDialog2.HideDialog()
                        End If
                    End If
                Else
                    'Downloads
                    'This code sets a cancel flag on the task grid that is read by the download listeners
                    If aRow.Cells(idxTaskStatus).Value.Equals(BA_Task_Success) Or _
                        aRow.Cells(idxTaskStatus).Value.Equals(BA_Task_Failure) Then
                        Dim warningMessage As String = "Are you sure you want to cancel the download for AOI: " & aoiName & _
                            "? This action cannot be reversed!"
                        Dim res1 As DialogResult = MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.YesNo, _
                                                                   MessageBoxIcon.Question)
                        If res1 = Windows.Forms.DialogResult.Yes Then
                            'File download to client has started
                            aRow.Cells(idxCancelTask).Value = True
                            MessageBox.Show("Request sent to cancel download for: " & aoiName)
                        End If
                    End If
                End If
            Next
            Application.DoEvents()
        Catch ex As Exception
            Debug.Print("BtnCancelTask_Click Exception: " & ex.Message)
        Finally
            If progressDialog2 IsNot Nothing Then
                progressDialog2.HideDialog()
                progressDialog2 = Nothing
            End If
        End Try
    End Sub

    Private Sub TestWebClient()

        Try
            Dim dList As IList(Of AoiDownloadInfo) = New List(Of AoiDownloadInfo)
            Dim aoiDownload1 As AoiDownloadInfo = New AoiDownloadInfo("https://test.ebagis.geog.pdx.edu/api/rest/downloads/f04df86b-08b7-417f-886e-8f157ec16db9/", _
                                                      BA_Task_Success, DateTime.Now, "C:\Docs\Lesley\Downloads\aoi1.zip", 1)
            Dim aoiDownload2 As AoiDownloadInfo = New AoiDownloadInfo("https://test.ebagis.geog.pdx.edu/api/rest/downloads/3480b635-a776-42d2-847e-5c208fd27e27/", _
                                                      BA_Task_Success, DateTime.Now, "C:\Docs\Lesley\Downloads\aoi2.zip", 2)
            Dim aoiDownload3 As AoiDownloadInfo = New AoiDownloadInfo("https://test.ebagis.geog.pdx.edu/api/rest/downloads/3f146a61-b9c1-476c-9365-85fe61f4ef6b/", _
                                                      BA_Task_Success, DateTime.Now, "C:\Docs\Lesley\Downloads\aoi3.zip", 3)
            dList.Add(aoiDownload1)
            dList.Add(aoiDownload2)
            dList.Add(aoiDownload3)

            'Set reference to HruExtension
            Dim hruExt As HruExtension = HruExtension.GetExtension
            'Retrieve the token and format it for the header; Token comes from caller
            Dim cred As String = String.Format("{0} {1}", "Token", hruExt.EbagisToken.key)

            For Each pDown As AoiDownloadInfo In dList
                Using myWebClient As New WebClient()
                    'Put token in header
                    myWebClient.Headers(HttpRequestHeader.Authorization) = cred
                    AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadFileCompleted
                    AddHandler myWebClient.DownloadProgressChanged, AddressOf DownloadProgressCallback

                    Dim downloadUri As Uri = New Uri(pDown.Url)
                    pDown.downloadStatus = BA_Download_Download_Started
                    myWebClient.DownloadFileAsync(downloadUri, pDown.FilePath, pDown)
                End Using
            Next
        Catch ex As Exception
            Debug.Print("TestWebClient Exception: " & ex.Message)
        End Try

    End Sub

    Private Sub TxtBasinsDb_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtBasinsDb.Validating
        Dim errorMsg As String = Nothing
        If Not ValidServerName(TxtBasinsDb.Text, errorMsg) Then
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            TxtBasinsDb.Select(0, TxtBasinsDb.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            MessageBox.Show(errorMsg, "Invalid database path", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function ValidServerName(ByVal url As String, ByRef errorMessage As String) As Boolean
        Dim progressDialog2 As IProgressDialog2 = Nothing
        Try
            progressDialog2 = BA_GetAnimationProgressor(My.ArcMap.Application.hWnd, "Validating and saving basins database server location", "Validating new server")
            progressDialog2.ShowDialog()

            'Always pass validation if loading
            If m_loading = True Then Return True
            ' Confirm there is text in the control.
            If TxtBasinsDb.Text.Length = 0 Then
                errorMessage = "Basins database is required."
                Return False
            End If
            If TxtBasinsDb.Text.IndexOf("https://", StringComparison.OrdinalIgnoreCase) <> 0 Then
                errorMessage = "A secure web service url starting with 'https' is required."
                Return False
            End If
            If Not Uri.IsWellFormedUriString(TxtBasinsDb.Text, UriKind.Absolute) Then
                errorMessage = "The url for the basins database you provided is not well-formed."
                Return False
            End If
            'Check server
            If SecurityHelper.BA_IsEBagisAvailable(TxtBasinsDb.Text) <> True Then
                errorMessage = "Unable to connect to the basins database you provided"
                Return False
            End If
            'Set reference to HruExtension
            Dim hruExt As HruExtension = HruExtension.GetExtension
            Dim success As BA_ReturnCode = SaveSettings(hruExt.SettingsPath & BA_EnumDescription(PublicPath.BagisHSettings), m_settings)
            If success = BA_ReturnCode.Success Then
                Return True
            Else
                errorMessage = "An error occurred while trying to save the updated basins database location"
                Return False
            End If
        Catch ex As Exception
            Debug.Print("ValidServerName: " & ex.Message)
            Return False
        Finally
            progressDialog2.HideDialog()
            progressDialog2 = Nothing
        End Try
    End Function

    Private Function ReadSettingsFromJson(ByVal filePath As String) As BagisHSettings
        Try
            Dim bytes() As Byte = New Byte(0) {}
            Dim settings As BagisHSettings = Nothing
            Using fsSource As System.IO.FileStream = New System.IO.FileStream(filePath, _
                FileMode.Open, FileAccess.Read)
                ' Read the source file into a byte array.
                ReDim bytes((fsSource.Length) - 1)
                Dim numBytesToRead As Integer = CType(fsSource.Length, Integer)
                Dim numBytesRead As Integer = 0

                While (numBytesToRead > 0)
                    ' Read may return anything from 0 to numBytesToRead.
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead, _
                        numBytesToRead)
                    ' Break when the end of the file is reached.
                    If (n = 0) Then
                        Exit While
                    End If
                    numBytesRead = (numBytesRead + n)
                    numBytesToRead = (numBytesToRead - n)
                End While
            End Using

            If bytes.Length > 0 Then
                Using memStream As MemoryStream = New MemoryStream(bytes)
                    settings = New BagisHSettings()
                    Dim ser As System.Runtime.Serialization.Json.DataContractJsonSerializer = New System.Runtime.Serialization.Json.DataContractJsonSerializer(settings.[GetType]())
                    Return CType(ser.ReadObject(memStream), BagisHSettings)
                End Using
            End If
            Return settings
        Catch ex As Exception
            Debug.Print("ReadSettingsFromJson Exception: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function SaveSettings(ByVal filePath As String, ByVal pSettings As BagisHSettings) As BA_ReturnCode
        Try
            'Serialize object to json
            Dim ser As System.Runtime.Serialization.Json.DataContractJsonSerializer = New System.Runtime.Serialization.Json.DataContractJsonSerializer(pSettings.[GetType]())
            Using fsDest As System.IO.FileStream = New System.IO.FileStream(filePath, _
                FileMode.Create, FileAccess.Write)
                ser.WriteObject(fsDest, pSettings)
            End Using
            MessageBox.Show("The updated basins database server location has been saved!")
            Return BA_ReturnCode.Success
        Catch ex As Exception
            Debug.Print("SaveSettings Exception: " & ex.Message)
            Return BA_ReturnCode.UnknownError
        End Try
    End Function

    'Warn user if they have running tasks and give them chance to change their mind
    Private Sub FrmDownloadAoiMenu_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim runningTasks As Int16 = 0
        For Each aRow As DataGridViewRow In GrdTasks.Rows
            Dim taskStatus As String = Convert.ToString(aRow.Cells(idxTaskStatus).Value)
            Select Case taskStatus
                Case BA_Task_Started
                    runningTasks += 1
                Case BA_Task_Staging
                    runningTasks += 1
                Case BA_Task_Pending
                    runningTasks += 1
            End Select
        Next
        If runningTasks > 0 Then
            e.Cancel = True
            Dim res As DialogResult = MessageBox.Show("There are tasks in process on this screen." & vbCrLf & _
                                                      "If you close the window they will continue to run " & _
                                                      "but you will be unable to retrieve the status." & vbCrLf & vbCrLf & _
                                                      "Do you still wish to close this window ?", "Window closing", _
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub BtnShowFilter_Click(sender As System.Object, e As System.EventArgs) Handles BtnShowFilter.Click
        If PnlFilter.Visible = True Then
            PnlFilter.Visible = False
        Else
            PnlFilter.Visible = True
            PnlFilter.BringToFront()
        End If
    End Sub

    Private Sub BtnCloseFilter_Click(sender As System.Object, e As System.EventArgs) Handles BtnCloseFilter.Click
        PnlFilter.Visible = False
    End Sub

    Private Sub RdoCurrentUser_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdoCurrentUser.CheckedChanged
        If RdoCurrentUser.Checked = True Then
            'Set reference to HruExtension
            Dim hruExt As HruExtension = HruExtension.GetExtension
            If String.IsNullOrEmpty(hruExt.EBagisUserName) Then
                MessageBox.Show("You cannot filter on your AOI uploads until you have signed in!", "BAGIS-H",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                RdoCurrentUser.Checked = False
                Exit Sub
            End If

            'Set the user name if it is a user name search
            m_aoiSearchFilter.Clear()
            m_aoiSearchFilter.UserName = hruExt.EBagisUserName
            m_txtFilterDescr = RdoCurrentUser.Text.Substring(FILTER_PREFIX_LENGTH)
        End If
    End Sub

    Private Sub BtnApplyFilter_Click(sender As System.Object, e As System.EventArgs) Handles BtnApplyFilter.Click
        TxtFilterDescr.Text = "None"
        ' Validate search string if this is a textual search
        If RdoSearch.Checked = True Then
            Dim errorMsg As String = Nothing
            If Not ValidSearchString(errorMsg) Then
                ' Select the text to be corrected by the user.
                TxtSearch.Select(0, TxtSearch.Text.Length)
                MessageBox.Show(errorMsg, "BAGIS-H", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                m_aoiSearchFilter.StringSearch = Trim(TxtSearch.Text)
                m_txtFilterDescr = RdoSearch.Text.Substring(FILTER_PREFIX_LENGTH) + " '" + m_aoiSearchFilter.StringSearch + "'"
            End If
        End If
        Me.BtnList.PerformClick()
        TxtFilterDescr.Text = m_txtFilterDescr
        PnlFilter.Hide()
    End Sub

    Private Sub BtnClearFilter_Click(sender As System.Object, e As System.EventArgs) Handles BtnClearFilter.Click
        m_aoiSearchFilter.Clear()
        Rdo2Weeks.Checked = False
        RdoCurrentUser.Checked = False
        RdoLastMonth.Checked = False
        m_txtFilterDescr = "None"
        TxtFilterDescr.Text = m_txtFilterDescr
        Me.BtnList.PerformClick()
    End Sub

    Private Sub Rdo2Weeks_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rdo2Weeks.CheckedChanged
        If Rdo2Weeks.Checked = True Then
            m_aoiSearchFilter.Clear()
            m_aoiSearchFilter.CreatedAfter = DateTime.Now.AddDays(-14)
            m_txtFilterDescr = Rdo2Weeks.Text.Substring(FILTER_PREFIX_LENGTH)
        End If
    End Sub

    Private Sub RdoLastMonth_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdoLastMonth.CheckedChanged
        If RdoLastMonth.Checked = True Then
            m_aoiSearchFilter.Clear()
            m_aoiSearchFilter.CreatedAfter = DateTime.Now.AddMonths(-1)
            m_txtFilterDescr = RdoLastMonth.Text.Substring(FILTER_PREFIX_LENGTH)
        End If
    End Sub

    Private Sub RdoSearch_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdoSearch.CheckedChanged
        If RdoSearch.Checked = True Then
            m_aoiSearchFilter.Clear()
            'We'll set the filter text in the txtSearch validating function
            TxtSearch.Enabled = True
        Else
            TxtSearch.Text = Nothing
            TxtSearch.Enabled = False
        End If
    End Sub

    Private Function ValidSearchString(ByRef errorMessage As String) As Boolean
        ' Confirm there is text in the control.
        If TxtSearch.Text.Length = 0 Then
            errorMessage = "Search text is required"
            Return False
        End If
        ' Confirm there are no spaces in the control
        If Trim(TxtSearch.Text).IndexOf(" ") > -1 Then
            errorMessage = "Spaces are not allowed in the search text"
            Return False
        End If
        Return True
    End Function

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        'Check permissions before we let them start; If they can login, they can download
        If GenerateToken() <> BA_ReturnCode.Success Then
            MessageBox.Show("Unable to sign in to Basins database. You cannot delete an AOI!", "BAGIS-H", _
                             MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        Else
            Dim canDelete As Boolean = False
            Dim hruExt As HruExtension = HruExtension.GetExtension
            Dim lstGroups As IList(Of String) = hruExt.EbagisGroups
            If lstGroups IsNot Nothing AndAlso lstGroups.Count > 0 Then
                For Each strGroup As String In lstGroups
                    If strGroup.ToUpper.Trim.Equals(SecurityHelper.Groups.NWCC_ADMIN.ToString) Then
                        canDelete = True
                        Exit For
                    End If
                Next
            End If
        End If

        'Is at least one aoi selected ?
        'Dictionary with aoiName as key and url as value
        Dim dDict As IDictionary(Of String, String) = New Dictionary(Of String, String)
        For Each pRow As DataGridViewRow In AoiGrid.Rows
            Dim ckDelete As Boolean = pRow.Cells(idxSelectAoi).Value
            If ckDelete = True Then
                dDict.Add(Convert.ToString(pRow.Cells(idxAoiName).Value).Trim, _
                          Convert.ToString(pRow.Cells(idxDownloadUrl).Value).Trim)
            End If
        Next
        If dDict.Keys.Count < 1 Then
            MessageBox.Show("You must select at least one AOI to delete!", "BAGIS-P", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            'Make sure user wants to delete
            Dim warnSb As StringBuilder = New StringBuilder()
            warnSb.Append("You are about to delete the AOI(s) listed below. This action cannot be undone." & vbCrLf & vbCrLf)
            For Each deleteName As String In dDict.Keys
                warnSb.Append(deleteName & vbCrLf)
            Next
            warnSb.Append(vbCrLf & "Do you wish to continue ?")
            Dim res As DialogResult = MessageBox.Show(warnSb.ToString, "Delete AOI(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = Windows.Forms.DialogResult.Yes Then
                'Set reference to HruExtension
                Dim hruExt As HruExtension = HruExtension.GetExtension
                'Delete the selected AOI's
                Dim failedToDelete As IList(Of String) = New List(Of String)
                Dim success As BA_ReturnCode = BA_ReturnCode.UnknownError
                For Each deleteName As String In dDict.Keys
                    Dim deleteUrl As String = dDict(deleteName)
                    success = BA_Delete_Aoi(deleteUrl, hruExt.EbagisToken.key)
                    If success <> BA_ReturnCode.Success Then
                        failedToDelete.Add(deleteName)
                    End If
                Next
                'Refresh the list of AOI's; Programatically click BtnList
                BtnList_Click(sender, e)
                'If any AOI's couldn't be deleted, warn the user
                If failedToDelete.Count > 0 Then
                    Dim sb As StringBuilder = New StringBuilder()
                    sb.Append("The following AOI(s) could not be deleted: " & vbCrLf & vbCrLf)
                    For Each dName As String In failedToDelete
                        sb.Append(dName & vbCrLf)
                    Next
                    sb.Append(vbCrLf)
                    sb.Append("Please contact an Administrator for assistance deleting AOI(s)." & vbCrLf)
                    MessageBox.Show(sb.ToString, "Failed to delete AOI", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("The selected AOI(s) have been deleted", "Delete AOI(s)", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    ' This event handler manually raises the CellValueChanged event
    ' by calling the CommitEdit method. Works with AoiGrid_CellValueChanged to manage the delete button
    Sub AoiGrid_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles AoiGrid.CurrentCellDirtyStateChanged
            If AoiGrid.IsCurrentCellDirty Then
                AoiGrid.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
    End Sub

    ' If a check box cell is clicked, this event handler disables  
    ' or enables the button in the same row as the clicked cell.
    Public Sub AoiGrid_CellValueChanged(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles AoiGrid.CellValueChanged

        Dim aoiSelected As Boolean = False
        If e.ColumnIndex = idxSelectAoi AndAlso e.RowIndex > -1 Then
            Dim checkCell As DataGridViewCheckBoxCell = _
                CType(AoiGrid.Rows(e.RowIndex).Cells(idxSelectAoi), DataGridViewCheckBoxCell)
            aoiSelected = CType(checkCell.Value, [Boolean])

            If aoiSelected = True Then
                BtnDelete.Enabled = True
                AoiGrid.Invalidate()
                Exit Sub
            Else
                'Check to see if any other rows are still selected
                For Each pRow As DataGridViewRow In AoiGrid.Rows
                    Dim ckDelete As Boolean = pRow.Cells(idxSelectAoi).Value
                    If ckDelete = True Then
                        aoiSelected = True
                        Exit For
                    End If
                Next
                BtnDelete.Enabled = aoiSelected
                AoiGrid.Invalidate()
            End If
        End If
    End Sub

    Private Sub BtnSignIn_Click(sender As System.Object, e As System.EventArgs) Handles BtnSignIn.Click
        Dim hruExt As HruExtension = HruExtension.GetExtension
        Dim bToken As BagisToken = hruExt.EbagisToken
        If bToken Is Nothing Then
            'Try to sign in
            Dim success As BA_ReturnCode = GenerateToken()
            If success = BA_ReturnCode.Success Then
                BtnSignIn.Text = "Sign out"
            End If
        Else
            'Sign out
            'Remove token from extension
            hruExt.EbagisToken = Nothing
            'Remove token from application settings
            SecurityHelper.DeleteToken()
            BtnSignIn.Text = "Sign in"
        End If
    End Sub

    'Private Sub BtnChunk_Click(sender As System.Object, e As System.EventArgs) Handles BtnChunk.Click
    'Dim fileInfo As System.IO.FileInfo = New FileInfo("C:\Users\lesleyb\AppData\Roaming\BAGIS\settings.xml")
    'Dim md5Hash As String = MultipartFormHelper.GenerateMD5Hash(fileInfo)
    'Dim chunkList As IList(Of Byte()) = New List(Of Byte())
    'Dim chunkSize As Integer = 1000
    'Dim maxNumberChunks As Integer = fileInfo.Length / chunkSize     'Last full chunk 
    'Dim bytesWritten As Integer = 0     'Running total of bytes saved to the List in memory
    'Using fileStream As New System.IO.FileStream(fileInfo.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
    '    Dim bytesRead As Integer = 0
    '    While bytesWritten < fileInfo.Length
    '        Dim bytes = New Byte(chunkSize - 1) {}  'Must re-initialize array every pass or it overwrites entry in List
    '        If chunkList.Count = maxNumberChunks Then
    '            ReDim bytes(fileInfo.Length - bytesWritten - 1) 'subtract 1 to avoid empty space at end
    '        End If
    '        bytesRead = fileStream.Read(bytes, 0, bytes.Length)
    '        chunkList.Add(bytes)
    '        bytesWritten = bytesWritten + bytesRead
    '    End While
    '    fileStream.Close()
    'End Using
    'Using oFileStream As System.IO.FileStream = New System.IO.FileStream("C:\Users\lesleyb\AppData\Roaming\BAGIS\test.xml", System.IO.FileMode.Create)
    '    Dim offset As Integer = 0
    '    For Each arrByte As Byte() In chunkList
    '        oFileStream.Write(arrByte, 0, arrByte.Length)
    '    Next
    '    oFileStream.Close()
    'End Using
    'Dim copyInfo As System.IO.FileInfo = New FileInfo("C:\Users\lesleyb\AppData\Roaming\BAGIS\test.xml")
    'Dim md5HashCopy As String = MultipartFormHelper.GenerateMD5Hash(copyInfo)
    'If md5Hash.Equals(md5HashCopy) Then
    '    Windows.Forms.MessageBox.Show("success!")
    'Else
    '    Windows.Forms.MessageBox.Show("failure ...")
    'End If

    'Set reference to HruExtension
    'End Sub

    Private Function UploadAoiChunked(ByVal fileInfo As System.IO.FileInfo, ByVal strToken As String, ByVal chunkSize As Integer) As AoiTask

        Dim aoiName As String = Path.GetFileNameWithoutExtension(fileInfo.FullName)
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

        'Information about the file
        If fileInfo IsNot Nothing Then
            Dim chunkList As IList(Of Byte()) = New List(Of Byte())
            Dim maxNumberChunks As Long = Math.Floor(fileInfo.Length / chunkSize)     'Last full chunk
            Dim bytesWritten As Long = 0     'Running total of bytes saved to the List in memory
            'Read the file into an List of bytes
            Using fileStream As New System.IO.FileStream(fileInfo.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                Dim bytesRead As Integer = 0
                While bytesWritten < fileInfo.Length
                    Dim bytes() As Byte = New Byte(chunkSize - 1) {}   'Must re-initialize array every pass or it overwrites entry in List
                    If chunkList.Count = maxNumberChunks Then
                        ReDim bytes(fileInfo.Length - bytesWritten - 1) 'subtract 1 to avoid empty space at end
                    End If
                    bytesRead = fileStream.Read(bytes, 0, bytes.Length)
                    chunkList.Add(bytes)
                    bytesWritten = bytesWritten + bytesRead
                End While
                fileStream.Close()
            End Using
            Dim idxChunk As Long = 0     'Keep track of which chunk we are sending; 0 is the first
            Dim idxEnd As Long = -1      'Keep track of end of each packet
            Dim uploadUrl = TxtBasinsDb.Text & "aois/"
            Dim anUpload As AoiTask = BA_WriteFirstChunk(uploadUrl, strToken, fileInfo, _
                                                         chunkList(idxChunk), TxtComment.Text, idxEnd)
            If Not String.IsNullOrEmpty(anUpload.url) Then
                With item
                    .Cells(idxTaskStatus).Value = anUpload.status
                    .Cells(idxTaskUrl).Value = anUpload.url
                    .Cells(idxTaskTime).Value = DateTime.Now.ToString("MM/dd/yy H:mm")
                    .Cells(idxTaskId).Value = anUpload.id
                    .Cells(idxTaskLocalPath).Value = TxtUploadPath.Text
                End With
                Application.DoEvents()
                'Clear out upload file name
                TxtUploadPath.Text = Nothing
                'Clear out comments field
                TxtComment.Text = Nothing
                idxChunk = idxChunk + 1
                Do While anUpload IsNot Nothing AndAlso idxChunk < chunkList.Count
                    Dim idxStart As Integer = idxEnd + 1    'Add one to move onto the next byte
                    idxEnd = idxStart + chunkList(idxChunk).GetUpperBound(0)
                    anUpload = BA_WriteBodyChunk(anUpload.url, strToken, chunkList(idxChunk), _
                                                 idxStart, idxEnd, fileInfo.Length, fileInfo.Name)
                    idxChunk = idxChunk + 1
                Loop
                If anUpload IsNot Nothing Then
                    'Set the checksum after sending the last chunk
                    anUpload.md5 = MultipartFormHelper.GenerateMD5Hash(fileInfo)
                    Return anUpload
                Else
                    With item
                        .Cells(idxTaskStatus).Value = BA_Task_Failure
                        .Cells(idxTaskTime).Value = "N/A"
                        .Cells(idxTaskMessage).Value = "An error occurred while trying to upload the AOI"
                    End With
                End If
            Else
                With item
                    .Cells(idxTaskStatus).Value = BA_Task_Failure
                    .Cells(idxTaskTime).Value = "N/A"
                    .Cells(idxTaskMessage).Value = "An error occurred while trying to upload the AOI"
                End With
            End If
        End If
        Return Nothing
    End Function
End Class