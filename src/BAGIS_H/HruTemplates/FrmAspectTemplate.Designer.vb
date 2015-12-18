<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAspectTemplate
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboDirections = New System.Windows.Forms.ComboBox()
        Me.TxtRuleId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtFilterWidth = New System.Windows.Forms.TextBox()
        Me.TxtFilterHeight = New System.Windows.Forms.TextBox()
        Me.TxtIterations = New System.Windows.Forms.TextBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnApply = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnAbout = New System.Windows.Forms.Button()
        Me.LblToolTip = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 77)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Step 1. Reclassify aspect into"
        '
        'CboDirections
        '
        Me.CboDirections.FormattingEnabled = True
        Me.CboDirections.Items.AddRange(New Object() {"4", "8", "16"})
        Me.CboDirections.Location = New System.Drawing.Point(346, 74)
        Me.CboDirections.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CboDirections.Name = "CboDirections"
        Me.CboDirections.Size = New System.Drawing.Size(85, 28)
        Me.CboDirections.TabIndex = 1
        '
        'TxtRuleId
        '
        Me.TxtRuleId.Enabled = False
        Me.TxtRuleId.Location = New System.Drawing.Point(8, 295)
        Me.TxtRuleId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtRuleId.Name = "TxtRuleId"
        Me.TxtRuleId.Size = New System.Drawing.Size(66, 26)
        Me.TxtRuleId.TabIndex = 27
        Me.TxtRuleId.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(94, 194)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 25)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Filter width:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(94, 235)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 25)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Filter height:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(94, 280)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 25)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Filter iterations:"
        '
        'TxtFilterWidth
        '
        Me.TxtFilterWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilterWidth.Location = New System.Drawing.Point(270, 194)
        Me.TxtFilterWidth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtFilterWidth.Name = "TxtFilterWidth"
        Me.TxtFilterWidth.Size = New System.Drawing.Size(118, 30)
        Me.TxtFilterWidth.TabIndex = 31
        Me.TxtFilterWidth.Text = "5"
        '
        'TxtFilterHeight
        '
        Me.TxtFilterHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilterHeight.Location = New System.Drawing.Point(270, 235)
        Me.TxtFilterHeight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtFilterHeight.Name = "TxtFilterHeight"
        Me.TxtFilterHeight.Size = New System.Drawing.Size(118, 30)
        Me.TxtFilterHeight.TabIndex = 32
        Me.TxtFilterHeight.Text = "5"
        '
        'TxtIterations
        '
        Me.TxtIterations.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIterations.Location = New System.Drawing.Point(270, 275)
        Me.TxtIterations.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtIterations.Name = "TxtIterations"
        Me.TxtIterations.Size = New System.Drawing.Size(118, 30)
        Me.TxtIterations.TabIndex = 33
        Me.TxtIterations.Text = "5"
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(328, 318)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(105, 38)
        Me.BtnCancel.TabIndex = 35
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnApply
        '
        Me.BtnApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApply.Location = New System.Drawing.Point(442, 318)
        Me.BtnApply.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnApply.Name = "BtnApply"
        Me.BtnApply.Size = New System.Drawing.Size(105, 38)
        Me.BtnApply.TabIndex = 34
        Me.BtnApply.Text = "Apply"
        Me.BtnApply.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(94, 160)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(373, 25)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Set filter iterations to 0 to skip filtering"
        '
        'BtnAbout
        '
        Me.BtnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAbout.Location = New System.Drawing.Point(390, 18)
        Me.BtnAbout.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnAbout.Name = "BtnAbout"
        Me.BtnAbout.Size = New System.Drawing.Size(158, 43)
        Me.BtnAbout.TabIndex = 53
        Me.BtnAbout.Text = "Tell me more"
        Me.BtnAbout.UseVisualStyleBackColor = True
        '
        'LblToolTip
        '
        Me.LblToolTip.AutoSize = True
        Me.LblToolTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToolTip.Location = New System.Drawing.Point(18, 28)
        Me.LblToolTip.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblToolTip.Name = "LblToolTip"
        Me.LblToolTip.Size = New System.Drawing.Size(342, 25)
        Me.LblToolTip.TabIndex = 54
        Me.LblToolTip.Text = "Use aspect values to define zones"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(442, 75)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 25)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "directions."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 125)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(468, 25)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Step 2. Majority Filtering on Reclassified aspect"
        '
        'FrmAspectTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 374)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblToolTip)
        Me.Controls.Add(Me.BtnAbout)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnApply)
        Me.Controls.Add(Me.TxtIterations)
        Me.Controls.Add(Me.TxtFilterHeight)
        Me.Controls.Add(Me.TxtFilterWidth)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtRuleId)
        Me.Controls.Add(Me.CboDirections)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmAspectTemplate"
        Me.ShowIcon = False
        Me.Text = "Template - Aspect"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboDirections As System.Windows.Forms.ComboBox
    Friend WithEvents TxtRuleId As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtFilterWidth As System.Windows.Forms.TextBox
    Friend WithEvents TxtFilterHeight As System.Windows.Forms.TextBox
    Friend WithEvents TxtIterations As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnApply As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnAbout As System.Windows.Forms.Button
    Friend WithEvents LblToolTip As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class