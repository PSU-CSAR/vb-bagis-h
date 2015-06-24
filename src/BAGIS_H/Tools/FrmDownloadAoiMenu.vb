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
            Dim downloadCount As UInt16 = 0
            For Each pRow As DataGridViewRow In AoiGrid.Rows
                Dim ckDownload As Boolean = pRow.Cells(idxDownload).Value
                If ckDownload = True Then
                    downloadCount += 1
                    Exit For
                End If
            Next
            If downloadCount < 1 Then
                MessageBox.Show("You must select at least one AOI to download", "No AOI selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'Check token
            If String.IsNullOrEmpty(m_token.token) Then
                Dim tokenUrl = TxtBasinsDb.Text & "api-token-auth/"
                Dim strToken As String = SecurityHelper.GetServerToken(m_userName, m_password, tokenUrl)
                m_token.token = strToken
                If String.IsNullOrEmpty(strToken) Then
                    MessageBox.Show("Invalid user name or password. Failed to connect to database.", "Failed Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            For Each pRow As DataGridViewRow In AoiGrid.Rows
                Dim ckDownload As Boolean = pRow.Cells(idxDownload).Value
                If ckDownload = True Then
                    Dim downloadUrl As String = Convert.ToString(pRow.Cells(idxDownloadUrl).Value)
                    downloadUrl = downloadUrl & "download/"
                    '---create a row---
                    Dim item As New DataGridViewRow
                    item.CreateCells(GrdTasks)
                    With item
                        .Cells(idxTaskAoi).Value = Convert.ToString(pRow.Cells(idxAoiName).Value)
                        .Cells(idxTaskType).Value = DOWNLOAD_TYPE
                        .Cells(idxTaskStatus).Value = BA_Task_Started
                        .Cells(idxTaskTime).Value = "N/A"
                    End With
                    GrdTasks.Rows.Add(item)
                    Application.DoEvents()
                    Dim aDownload As AoiUpload = BA_Download_Aoi(downloadUrl, m_token.token)
                    If aDownload.task IsNot Nothing Then
                        Dim interval As UInteger = 10000    'Value in milleseconds
                        Dim downloadTimeout As Double = 160   'Value in seconds
                        Dim aTimer As AoiDownloadTimer = New AoiDownloadTimer(aDownload, m_token.token, interval, downloadTimeout, Me)
                        m_downTimersList.Add(aTimer)
                        With item
                            .Cells(idxTaskStatus).Value = aDownload.task.status
                            .Cells(idxTaskUrl).Value = aDownload.url
                            .Cells(idxTaskTime).Value = "0"
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

    Private Sub BtnUpload_Click(sender As System.Object, e As System.EventArgs) Handles BtnUpload.Click
        If String.IsNullOrEmpty(m_token.token) Then
            Dim tokenUrl = TxtBasinsDb.Text & "api-token-auth/"
            Dim strToken As String = SecurityHelper.GetServerToken(m_userName, m_password, tokenUrl)
            m_token.token = strToken
            If String.IsNullOrEmpty(strToken) Then
                MessageBox.Show("Invalid user name or password. Failed to connect to database.", "Failed Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

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
    Public Sub UpdateStatus(ByVal ctl As Control, ByVal aoiUpload As AoiUpload, ByVal elapsedTime As Integer, ByVal strMessage As String)
        If ctl.InvokeRequired Then
            ctl.BeginInvoke(New Action(Of Control, AoiUpload, Integer, String)(AddressOf UpdateStatus), ctl, aoiUpload, elapsedTime, strMessage)
        Else
            For Each row As DataGridViewRow In GrdTasks.Rows
                Dim url As String = row.Cells(idxTaskUrl).Value
                If url = aoiUpload.url Then
                    row.Cells(idxTaskStatus).Value = aoiUpload.task.status
                    row.Cells(idxTaskTime).Value = CStr(elapsedTime)
                    row.Cells(idxTaskMessage).Value = strMessage
                End If
            Next
        End If
        Application.DoEvents()
    End Sub

    Private Sub BtnSelectAoi_Click(sender As System.Object, e As System.EventArgs) Handles BtnSelectAoi.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "zip files (*.zip)|*.zip"
        openFileDialog1.FilterIndex = 1
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TxtUploadPath.Text = openFileDialog1.FileName
        End If
    End Sub

    Private Sub TxtUploadPath_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtUploadPath.TextChanged
        If Not String.IsNullOrEmpty(TxtUploadPath.Text) Then
            BtnUpload.Enabled = True
        End If
    End Sub

    Private Sub BtnClear_Click(sender As System.Object, e As System.EventArgs) Handles BtnClear.Click
        GrdTasks.Rows.Clear()
        For Each aTimer As AoiUploadTimer In m_timersList
            aTimer.CloseTimer()
        Next
        m_timersList.Clear()
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
End Class