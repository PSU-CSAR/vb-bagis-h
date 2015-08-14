Imports BAGIS_ClassLibrary
Imports ESRI.ArcGIS.CatalogUI
Imports ESRI.ArcGIS.Catalog
Imports System.Windows.Forms
Imports System.Text

Public Class FrmTaskLog

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSelectAoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectAoi.Click
        Dim bObjectSelected As Boolean
        Dim pGxDialog As IGxDialog = New GxDialog
        Dim pGxObject As IEnumGxObject = Nothing
        Dim DataPath As String
        Dim pFilter As IGxObjectFilter = New GxFilterContainers
        Dim hruExt As HruExtension = HruExtension.GetExtension

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
                TxtAoiPath.Text = DataPath
                LoadTaskLog()
            Else
                MessageBox.Show("A valid AOI was not found in the folder you selected")
            End If
        Catch ex As Exception
            MessageBox.Show("BtnSelectAoi_Click Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadTaskLog()
        TxtLog.Text = Nothing
        Dim log As TaskLog = Nothing
        If BA_File_ExistsWindowsIO(TxtAoiPath.Text & BA_EnumDescription(PublicPath.EBagisTaskLog)) Then
            Dim obj As Object = SerializableData.Load(TxtAoiPath.Text & BA_EnumDescription(PublicPath.EBagisTaskLog), GetType(TaskLog))
            If obj IsNot Nothing Then
                log = CType(obj, TaskLog)
            End If
        End If
        If log Is Nothing Then
            MessageBox.Show("No valid task log was found for the AOI you selected.", "Task log not found", MessageBoxButtons.OK)
            Exit Sub
        End If
        Dim sb As StringBuilder = New StringBuilder
        Dim count As UInteger = 1
        For Each entry As TaskLogEntry In log.TaskLogEntries
            If count > 1 Then
                'Insert separator line
                sb.Append("---------------------------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf)
            End If
            sb.Append("Aoi name: " & entry.aoiName & vbCrLf)
            sb.Append("Local folder: " & entry.localFolder & vbCrLf)
            Dim fDate As String = entry.dateCompleted.ToShortDateString & " " & entry.dateCompleted.ToShortTimeString
            Select Case entry.taskType
                Case TASK_DOWNLOAD
                    sb.Append("Downloaded: " & fDate & vbCrLf)
                Case TASK_UPLOAD
                    sb.Append("Uploaded: " & fDate & vbCrLf)
            End Select
            sb.Append("Result: " & entry.status & vbCrLf)
            If Not String.IsNullOrEmpty(entry.errorMessage) Then
                sb.Append("Error message:" & vbCrLf)
                sb.Append(entry.errorMessage & vbCrLf)
            End If
            count += 1
        Next
        TxtLog.Text = sb.ToString
    End Sub
End Class