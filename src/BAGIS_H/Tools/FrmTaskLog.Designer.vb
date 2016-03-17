<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTaskLog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtAoiPath = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnSelectAoi = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtLog = New System.Windows.Forms.TextBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TxtAoiPath
        '
        Me.TxtAoiPath.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtAoiPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAoiPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtAoiPath.Location = New System.Drawing.Point(183, 32)
        Me.TxtAoiPath.Name = "TxtAoiPath"
        Me.TxtAoiPath.ReadOnly = True
        Me.TxtAoiPath.Size = New System.Drawing.Size(459, 22)
        Me.TxtAoiPath.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(114, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "AOI Path:"
        '
        'BtnSelectAoi
        '
        Me.BtnSelectAoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelectAoi.Location = New System.Drawing.Point(3, 28)
        Me.BtnSelectAoi.Name = "BtnSelectAoi"
        Me.BtnSelectAoi.Size = New System.Drawing.Size(105, 28)
        Me.BtnSelectAoi.TabIndex = 54
        Me.BtnSelectAoi.Text = "Select AOI"
        Me.BtnSelectAoi.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 16)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Select an AOI to view the eBAGIS task log"
        '
        'TxtLog
        '
        Me.TxtLog.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLog.ForeColor = System.Drawing.Color.Black
        Me.TxtLog.Location = New System.Drawing.Point(5, 63)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ReadOnly = True
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog.Size = New System.Drawing.Size(637, 328)
        Me.TxtLog.TabIndex = 58
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(542, 413)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(100, 30)
        Me.BtnCancel.TabIndex = 59
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnClear
        '
        Me.BtnClear.Enabled = False
        Me.BtnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.Location = New System.Drawing.Point(436, 413)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(100, 30)
        Me.BtnClear.TabIndex = 60
        Me.BtnClear.Text = "Clear Log"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'FrmTaskLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 452)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.TxtLog)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtAoiPath)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnSelectAoi)
        Me.Name = "FrmTaskLog"
        Me.ShowIcon = False
        Me.Text = "Task Log"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtAoiPath As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnSelectAoi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtLog As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnClear As System.Windows.Forms.Button
End Class
