<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReclassZones
  Inherits System.Windows.Forms.UserControl

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnAbout = New System.Windows.Forms.Button()
        Me.LblToolTip = New System.Windows.Forms.Label()
        Me.TxtAoiPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblOutputHruName = New System.Windows.Forms.Label()
        Me.TxtNewHruName = New System.Windows.Forms.TextBox()
        Me.TxtHruPath = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboParentHru = New System.Windows.Forms.ComboBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnGenerateHru = New System.Windows.Forms.Button()
        Me.BtnSelectAoi = New System.Windows.Forms.Button()
        Me.LblHruLayers = New System.Windows.Forms.Label()
        Me.BtnViewLayer = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.TxtSelZone = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OldValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewValues = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnSelectZones = New System.Windows.Forms.Button()
        Me.CkRetainAttributes = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtParentNonContig = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CkNonContiguous = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnAddAll = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAbout
        '
        Me.BtnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAbout.Location = New System.Drawing.Point(387, 5)
        Me.BtnAbout.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnAbout.Name = "BtnAbout"
        Me.BtnAbout.Size = New System.Drawing.Size(99, 23)
        Me.BtnAbout.TabIndex = 62
        Me.BtnAbout.Text = "Tell me more"
        Me.BtnAbout.UseVisualStyleBackColor = True
        '
        'LblToolTip
        '
        Me.LblToolTip.AutoSize = True
        Me.LblToolTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToolTip.Location = New System.Drawing.Point(8, 5)
        Me.LblToolTip.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblToolTip.Name = "LblToolTip"
        Me.LblToolTip.Size = New System.Drawing.Size(152, 16)
        Me.LblToolTip.TabIndex = 61
        Me.LblToolTip.Text = "Reclass zone values"
        '
        'TxtAoiPath
        '
        Me.TxtAoiPath.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtAoiPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAoiPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtAoiPath.Location = New System.Drawing.Point(179, 35)
        Me.TxtAoiPath.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtAoiPath.Name = "TxtAoiPath"
        Me.TxtAoiPath.ReadOnly = True
        Me.TxtAoiPath.Size = New System.Drawing.Size(272, 22)
        Me.TxtAoiPath.TabIndex = 60
        Me.TxtAoiPath.TabStop = False
        Me.TxtAoiPath.Text = "AOI is not specified"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(110, 36)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "AOI Path:"
        '
        'LblOutputHruName
        '
        Me.LblOutputHruName.AutoSize = True
        Me.LblOutputHruName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOutputHruName.Location = New System.Drawing.Point(8, 304)
        Me.LblOutputHruName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblOutputHruName.Name = "LblOutputHruName"
        Me.LblOutputHruName.Size = New System.Drawing.Size(138, 16)
        Me.LblOutputHruName.TabIndex = 58
        Me.LblOutputHruName.Text = "Output HRU Name:"
        '
        'TxtNewHruName
        '
        Me.TxtNewHruName.Enabled = False
        Me.TxtNewHruName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNewHruName.Location = New System.Drawing.Point(140, 302)
        Me.TxtNewHruName.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtNewHruName.Name = "TxtNewHruName"
        Me.TxtNewHruName.Size = New System.Drawing.Size(107, 22)
        Me.TxtNewHruName.TabIndex = 52
        '
        'TxtHruPath
        '
        Me.TxtHruPath.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtHruPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHruPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtHruPath.Location = New System.Drawing.Point(74, 386)
        Me.TxtHruPath.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtHruPath.Name = "TxtHruPath"
        Me.TxtHruPath.ReadOnly = True
        Me.TxtHruPath.Size = New System.Drawing.Size(377, 22)
        Me.TxtHruPath.TabIndex = 54
        Me.TxtHruPath.TabStop = False
        Me.TxtHruPath.Text = "HRU is not specified"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 387)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "HRU Path:"
        '
        'CboParentHru
        '
        Me.CboParentHru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboParentHru.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboParentHru.FormattingEnabled = True
        Me.CboParentHru.Location = New System.Drawing.Point(8, 78)
        Me.CboParentHru.Margin = New System.Windows.Forms.Padding(2)
        Me.CboParentHru.Name = "CboParentHru"
        Me.CboParentHru.Size = New System.Drawing.Size(123, 24)
        Me.CboParentHru.TabIndex = 51
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(332, 423)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(65, 23)
        Me.BtnCancel.TabIndex = 55
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnGenerateHru
        '
        Me.BtnGenerateHru.Enabled = False
        Me.BtnGenerateHru.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerateHru.Location = New System.Drawing.Point(401, 423)
        Me.BtnGenerateHru.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnGenerateHru.Name = "BtnGenerateHru"
        Me.BtnGenerateHru.Size = New System.Drawing.Size(114, 23)
        Me.BtnGenerateHru.TabIndex = 53
        Me.BtnGenerateHru.Text = "Generate HRUs"
        Me.BtnGenerateHru.UseVisualStyleBackColor = True
        '
        'BtnSelectAoi
        '
        Me.BtnSelectAoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelectAoi.Location = New System.Drawing.Point(8, 31)
        Me.BtnSelectAoi.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSelectAoi.Name = "BtnSelectAoi"
        Me.BtnSelectAoi.Size = New System.Drawing.Size(89, 23)
        Me.BtnSelectAoi.TabIndex = 50
        Me.BtnSelectAoi.Text = "Select AOI"
        Me.BtnSelectAoi.UseVisualStyleBackColor = True
        '
        'LblHruLayers
        '
        Me.LblHruLayers.AutoSize = True
        Me.LblHruLayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHruLayers.Location = New System.Drawing.Point(11, 58)
        Me.LblHruLayers.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblHruLayers.Name = "LblHruLayers"
        Me.LblHruLayers.Size = New System.Drawing.Size(154, 16)
        Me.LblHruLayers.TabIndex = 56
        Me.LblHruLayers.Text = "Zone layer to reclass"
        '
        'BtnViewLayer
        '
        Me.BtnViewLayer.Enabled = False
        Me.BtnViewLayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnViewLayer.Location = New System.Drawing.Point(134, 78)
        Me.BtnViewLayer.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnViewLayer.Name = "BtnViewLayer"
        Me.BtnViewLayer.Size = New System.Drawing.Size(129, 23)
        Me.BtnViewLayer.TabIndex = 63
        Me.BtnViewLayer.Text = "Add Zone Polygons"
        Me.BtnViewLayer.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.Location = New System.Drawing.Point(225, 270)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(120, 23)
        Me.BtnDelete.TabIndex = 67
        Me.BtnDelete.Text = "Delete Row(s)"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'TxtSelZone
        '
        Me.TxtSelZone.Enabled = False
        Me.TxtSelZone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelZone.Location = New System.Drawing.Point(303, 95)
        Me.TxtSelZone.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtSelZone.Name = "TxtSelZone"
        Me.TxtSelZone.Size = New System.Drawing.Size(77, 22)
        Me.TxtSelZone.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(264, 75)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 16)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Indentify zone value on mouse-click"
        '
        'BtnAdd
        '
        Me.BtnAdd.Enabled = False
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.Location = New System.Drawing.Point(225, 122)
        Me.BtnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(120, 23)
        Me.BtnAdd.TabIndex = 71
        Me.BtnAdd.Text = "Add Value"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Enabled = False
        Me.BtnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.Location = New System.Drawing.Point(225, 212)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(120, 23)
        Me.BtnUpdate.TabIndex = 72
        Me.BtnUpdate.Text = "Update Value(s)"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OldValue, Me.NewValues})
        Me.DataGridView1.Location = New System.Drawing.Point(8, 108)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(200, 131)
        Me.DataGridView1.TabIndex = 73
        '
        'OldValue
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.OldValue.DefaultCellStyle = DataGridViewCellStyle2
        Me.OldValue.HeaderText = "Old Values"
        Me.OldValue.Name = "OldValue"
        Me.OldValue.ReadOnly = True
        Me.OldValue.Width = 120
        '
        'NewValues
        '
        Me.NewValues.HeaderText = "New Values"
        Me.NewValues.Name = "NewValues"
        Me.NewValues.Width = 120
        '
        'BtnSelectZones
        '
        Me.BtnSelectZones.Enabled = False
        Me.BtnSelectZones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelectZones.Image = Global.BAGIS_H.My.Resources.Resources.IdentifyTool16
        Me.BtnSelectZones.Location = New System.Drawing.Point(282, 95)
        Me.BtnSelectZones.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSelectZones.Name = "BtnSelectZones"
        Me.BtnSelectZones.Size = New System.Drawing.Size(17, 19)
        Me.BtnSelectZones.TabIndex = 64
        Me.BtnSelectZones.UseVisualStyleBackColor = True
        '
        'CkRetainAttributes
        '
        Me.CkRetainAttributes.AutoSize = True
        Me.CkRetainAttributes.Checked = True
        Me.CkRetainAttributes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkRetainAttributes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CkRetainAttributes.Location = New System.Drawing.Point(250, 352)
        Me.CkRetainAttributes.Margin = New System.Windows.Forms.Padding(2)
        Me.CkRetainAttributes.Name = "CkRetainAttributes"
        Me.CkRetainAttributes.Size = New System.Drawing.Size(191, 20)
        Me.CkRetainAttributes.TabIndex = 74
        Me.CkRetainAttributes.Text = "Retain source attributes"
        Me.CkRetainAttributes.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(231, 235)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(231, 30)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Select New Values cell(s) on the left table" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "before clicking on the Update Value(" & _
    "s)!"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(231, 147)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(182, 15)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Add Old Value to be reclassified."
        '
        'TxtParentNonContig
        '
        Me.TxtParentNonContig.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtParentNonContig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtParentNonContig.Location = New System.Drawing.Point(476, 302)
        Me.TxtParentNonContig.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtParentNonContig.Name = "TxtParentNonContig"
        Me.TxtParentNonContig.Size = New System.Drawing.Size(51, 22)
        Me.TxtParentNonContig.TabIndex = 78
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(247, 304)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(232, 16)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Parent has non-contiguous HRU:"
        '
        'CkNonContiguous
        '
        Me.CkNonContiguous.AutoSize = True
        Me.CkNonContiguous.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CkNonContiguous.Location = New System.Drawing.Point(250, 328)
        Me.CkNonContiguous.Margin = New System.Windows.Forms.Padding(2)
        Me.CkNonContiguous.Name = "CkNonContiguous"
        Me.CkNonContiguous.Size = New System.Drawing.Size(210, 20)
        Me.CkNonContiguous.TabIndex = 79
        Me.CkNonContiguous.Text = "Allow non-contiguous HRU"
        Me.CkNonContiguous.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(231, 192)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(204, 15)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Add all Old Values to be reclassified."
        '
        'BtnAddAll
        '
        Me.BtnAddAll.Enabled = False
        Me.BtnAddAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddAll.Location = New System.Drawing.Point(225, 167)
        Me.BtnAddAll.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnAddAll.Name = "BtnAddAll"
        Me.BtnAddAll.Size = New System.Drawing.Size(120, 23)
        Me.BtnAddAll.TabIndex = 80
        Me.BtnAddAll.Text = "Add All Values"
        Me.BtnAddAll.UseVisualStyleBackColor = True
        '
        'FrmReclassZones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BtnAddAll)
        Me.Controls.Add(Me.CkNonContiguous)
        Me.Controls.Add(Me.TxtParentNonContig)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CkRetainAttributes)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtSelZone)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnSelectZones)
        Me.Controls.Add(Me.BtnViewLayer)
        Me.Controls.Add(Me.BtnAbout)
        Me.Controls.Add(Me.LblToolTip)
        Me.Controls.Add(Me.TxtAoiPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblOutputHruName)
        Me.Controls.Add(Me.TxtNewHruName)
        Me.Controls.Add(Me.TxtHruPath)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CboParentHru)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnGenerateHru)
        Me.Controls.Add(Me.BtnSelectAoi)
        Me.Controls.Add(Me.LblHruLayers)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmReclassZones"
        Me.Size = New System.Drawing.Size(529, 448)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnAbout As System.Windows.Forms.Button
    Friend WithEvents LblToolTip As System.Windows.Forms.Label
    Friend WithEvents TxtAoiPath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblOutputHruName As System.Windows.Forms.Label
    Friend WithEvents TxtNewHruName As System.Windows.Forms.TextBox
    Friend WithEvents TxtHruPath As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboParentHru As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnGenerateHru As System.Windows.Forms.Button
    Friend WithEvents BtnSelectAoi As System.Windows.Forms.Button
    Friend WithEvents LblHruLayers As System.Windows.Forms.Label
    Friend WithEvents BtnViewLayer As System.Windows.Forms.Button
    Friend WithEvents BtnSelectZones As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents TxtSelZone As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents CkRetainAttributes As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OldValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewValues As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtParentNonContig As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CkNonContiguous As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnAddAll As System.Windows.Forms.Button

End Class