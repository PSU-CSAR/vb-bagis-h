Public Class BtnDownloadAoi
  Inherits ESRI.ArcGIS.Desktop.AddIns.Button

  Public Sub New()

  End Sub

    Protected Overrides Sub OnClick()
        Try
            Dim dForm As FrmDownloadAoiMenu = New FrmDownloadAoiMenu()
            dForm.ShowDialog()
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.StackTrace)
        End Try
    End Sub

  Protected Overrides Sub OnUpdate()

  End Sub
End Class
