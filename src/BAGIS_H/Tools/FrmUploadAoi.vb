Imports System.Windows.Forms
Imports System.IO

Public Class FrmUploadAoi

    Private m_token As BagisToken = New BagisToken
    'In practice the user name/password will be provided by the user
    Private m_userName As String = Nothing
    Private m_password As String = Nothing

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '---create a row---
        Dim item As New DataGridViewRow
        item.CreateCells(LayerGrid)
        With item
            .Cells(0).Value = "Pourpoint"
            .Cells(1).Value = "aoi"
            .Cells(2).Value = "update"
            .Cells(3).Value = True
        End With
        Dim item2 As New DataGridViewRow
        item2.CreateCells(LayerGrid)
        With item2
            .Cells(0).Value = "state_boundaries"
            .Cells(1).Value = "optional"
            .Cells(2).Value = "add"
            .Cells(3).Value = True
        End With
        Dim item3 As New DataGridViewRow
        item3.CreateCells(LayerGrid)
        With item3
            .Cells(0).Value = "gopher_holes"
            .Cells(1).Value = "optional"
            .Cells(2).Value = "delete"
            .Cells(3).Value = True
        End With
        Dim item4 As New DataGridViewRow
        item4.CreateCells(LayerGrid)
        With item4
            .Cells(0).Value = "cov_den"
            .Cells(1).Value = "optional"
            .Cells(2).Value = "update"
            .Cells(3).Value = True
        End With
        Dim item5 As New DataGridViewRow
        item5.CreateCells(LayerGrid)
        With item5
            .Cells(0).Value = "slope_pct"
            .Cells(1).Value = "surfaces"
            .Cells(2).Value = "add"
            .Cells(3).Value = True
        End With
        '---add the rows---
        LayerGrid.Rows.Add(item)
        LayerGrid.Rows.Add(item2)
        LayerGrid.Rows.Add(item3)
        LayerGrid.Rows.Add(item4)
        LayerGrid.Rows.Add(item5)
        LayerGrid.Sort(LayerGrid.Columns(2), System.ComponentModel.ListSortDirection.Descending)

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

    End Sub

    Private Sub BtnUploadAoi_Click(sender As System.Object, e As System.EventArgs) Handles BtnUploadAoi.Click
        If String.IsNullOrEmpty(m_token.token) Then
            Dim strToken As String = SecurityHelper.GetServerToken(m_userName, m_password, "https://webservices.geog.pdx.edu/api/rest/token/")
            m_token.token = strToken
            If String.IsNullOrEmpty(strToken) Then
                MessageBox.Show("Invalid user name or password. Failed to connect to database.", "Failed Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Dim uploadUrl = "https://webservices.geog.pdx.edu/api/rest/aois/"
        'Dim fileName As String = "aoi_text3"
        'Dim filePath As String = "C:\Docs\Lesley\Landis\data\TRY2\Landis-log.txt"
        Dim fileName As String = "zip2"
        Dim filePath As String = "C:\Docs\Lesley\aoi1_05222013.zip"
        'BA_UploadMultiPart(uploadUrl, m_token.token, fileName, filePath)
    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class