Imports System.Windows.Forms

Public Class FrmPassword

    Private m_authenticateUrl As String

    Public Sub New(ByVal authenticationUrl As String)
        InitializeComponent()
        m_authenticateUrl = authenticationUrl
        TxtName.Focus()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnter.Click
        If String.IsNullOrEmpty(TxtName.Text) Or String.IsNullOrEmpty(TxtPassword.Text) Then
            MessageBox.Show("Both name and password are required", "Invalid name and password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            EnableForm(False)
            Dim strToken As String = SecurityHelper.GetServerToken(Trim(TxtName.Text), Trim(TxtPassword.Text), m_authenticateUrl)
            'If successful, store token in extension
            If Not String.IsNullOrEmpty(strToken) Then
                Dim newToken As BagisToken = New BagisToken()
                newToken.token = strToken
                Dim hruExt As HruExtension = HruExtension.GetExtension
                hruExt.EbagisToken = newToken
                hruExt.EBagisUserName = TxtName.Text
                Me.Close()
            Else
                MessageBox.Show("Invalid user name or password. Failed to connect to database.", "Failed Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtName.Focus()
            End If
            EnableForm(True)
        End If
    End Sub

    Private Sub EnableForm(ByVal enable As Boolean)
        TxtName.Enabled = enable
        TxtPassword.Enabled = enable
        BtnClose.Enabled = enable
        BtnEnter.Enabled = enable
    End Sub
End Class