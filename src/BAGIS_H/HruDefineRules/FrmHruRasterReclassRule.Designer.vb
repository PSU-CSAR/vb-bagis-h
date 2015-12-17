<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHruRasterReclassRule
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.LstAoiRasterLayers = New System.Windows.Forms.ListBox()
        Me.BtnApply = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CboReclassField = New System.Windows.Forms.ComboBox()
        Me.GrpLayerType = New System.Windows.Forms.GroupBox()
        Me.RdoHru = New System.Windows.Forms.RadioButton()
        Me.RdoPrism = New System.Windows.Forms.RadioButton()
        Me.RdoDem = New System.Windows.Forms.RadioButton()
        Me.RdoRaster = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnAuto = New System.Windows.Forms.Button()
        Me.PnlStatistics = New System.Windows.Forms.Panel()
        Me.LblDiscrete = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblMin = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblMax = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblSTDV = New System.Windows.Forms.Label()
        Me.LblMean = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GrpReclass = New System.Windows.Forms.GroupBox()
        Me.BtnId = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OldValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewValues = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnLoad = New System.Windows.Forms.Button()
        Me.BtnUnique = New System.Windows.Forms.Button()
        Me.RdoEqInterval = New System.Windows.Forms.RadioButton()
        Me.TxtRuleId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GrpSlice = New System.Windows.Forms.GroupBox()
        Me.TxtBaseZone = New System.Windows.Forms.TextBox()
        Me.TxtNumberZones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RdoEqArea = New System.Windows.Forms.RadioButton()
        Me.LblRasterLayers = New System.Windows.Forms.Label()
        Me.BtnAbout = New System.Windows.Forms.Button()
        Me.LblToolTip = New System.Windows.Forms.Label()
        Me.GrpLayerType.SuspendLayout()
        Me.PnlStatistics.SuspendLayout()
        Me.GrpReclass.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSlice.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(420, 691)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 38)
        Me.BtnCancel.TabIndex = 31
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'LstAoiRasterLayers
        '
        Me.LstAoiRasterLayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstAoiRasterLayers.FormattingEnabled = True
        Me.LstAoiRasterLayers.ItemHeight = 25
        Me.LstAoiRasterLayers.Location = New System.Drawing.Point(171, 85)
        Me.LstAoiRasterLayers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LstAoiRasterLayers.Name = "LstAoiRasterLayers"
        Me.LstAoiRasterLayers.Size = New System.Drawing.Size(217, 154)
        Me.LstAoiRasterLayers.TabIndex = 26
        '
        'BtnApply
        '
        Me.BtnApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApply.Location = New System.Drawing.Point(525, 691)
        Me.BtnApply.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnApply.Name = "BtnApply"
        Me.BtnApply.Size = New System.Drawing.Size(90, 38)
        Me.BtnApply.TabIndex = 27
        Me.BtnApply.Text = "Apply"
        Me.BtnApply.UseVisualStyleBackColor = True
        '
        'CboReclassField
        '
        Me.CboReclassField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboReclassField.FormattingEnabled = True
        Me.CboReclassField.Location = New System.Drawing.Point(160, 22)
        Me.CboReclassField.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CboReclassField.Name = "CboReclassField"
        Me.CboReclassField.Size = New System.Drawing.Size(163, 33)
        Me.CboReclassField.TabIndex = 22
        '
        'GrpLayerType
        '
        Me.GrpLayerType.Controls.Add(Me.RdoHru)
        Me.GrpLayerType.Controls.Add(Me.RdoPrism)
        Me.GrpLayerType.Controls.Add(Me.RdoDem)
        Me.GrpLayerType.Controls.Add(Me.RdoRaster)
        Me.GrpLayerType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpLayerType.Location = New System.Drawing.Point(27, 55)
        Me.GrpLayerType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GrpLayerType.Name = "GrpLayerType"
        Me.GrpLayerType.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GrpLayerType.Size = New System.Drawing.Size(129, 208)
        Me.GrpLayerType.TabIndex = 32
        Me.GrpLayerType.TabStop = False
        Me.GrpLayerType.Text = "Layer type"
        '
        'RdoHru
        '
        Me.RdoHru.AutoSize = True
        Me.RdoHru.Location = New System.Drawing.Point(15, 38)
        Me.RdoHru.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoHru.Name = "RdoHru"
        Me.RdoHru.Size = New System.Drawing.Size(78, 29)
        Me.RdoHru.TabIndex = 3
        Me.RdoHru.TabStop = True
        Me.RdoHru.Text = "HRU"
        Me.RdoHru.UseVisualStyleBackColor = True
        '
        'RdoPrism
        '
        Me.RdoPrism.AutoSize = True
        Me.RdoPrism.Location = New System.Drawing.Point(15, 158)
        Me.RdoPrism.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoPrism.Name = "RdoPrism"
        Me.RdoPrism.Size = New System.Drawing.Size(99, 29)
        Me.RdoPrism.TabIndex = 2
        Me.RdoPrism.TabStop = True
        Me.RdoPrism.Text = "PRISM"
        Me.RdoPrism.UseVisualStyleBackColor = True
        '
        'RdoDem
        '
        Me.RdoDem.AutoSize = True
        Me.RdoDem.Location = New System.Drawing.Point(15, 118)
        Me.RdoDem.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoDem.Name = "RdoDem"
        Me.RdoDem.Size = New System.Drawing.Size(81, 29)
        Me.RdoDem.TabIndex = 1
        Me.RdoDem.TabStop = True
        Me.RdoDem.Text = "DEM"
        Me.RdoDem.UseVisualStyleBackColor = True
        '
        'RdoRaster
        '
        Me.RdoRaster.AutoSize = True
        Me.RdoRaster.Location = New System.Drawing.Point(15, 78)
        Me.RdoRaster.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoRaster.Name = "RdoRaster"
        Me.RdoRaster.Size = New System.Drawing.Size(93, 29)
        Me.RdoRaster.TabIndex = 0
        Me.RdoRaster.TabStop = True
        Me.RdoRaster.Text = "Raster"
        Me.RdoRaster.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 31)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(141, 25)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Reclass field:"
        '
        'BtnAuto
        '
        Me.BtnAuto.Enabled = False
        Me.BtnAuto.Location = New System.Drawing.Point(108, 72)
        Me.BtnAuto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnAuto.Name = "BtnAuto"
        Me.BtnAuto.Size = New System.Drawing.Size(90, 38)
        Me.BtnAuto.TabIndex = 23
        Me.BtnAuto.Text = "Auto"
        Me.BtnAuto.UseVisualStyleBackColor = True
        '
        'PnlStatistics
        '
        Me.PnlStatistics.Controls.Add(Me.LblDiscrete)
        Me.PnlStatistics.Controls.Add(Me.Label1)
        Me.PnlStatistics.Controls.Add(Me.Label2)
        Me.PnlStatistics.Controls.Add(Me.LblMin)
        Me.PnlStatistics.Controls.Add(Me.Label4)
        Me.PnlStatistics.Controls.Add(Me.LblMax)
        Me.PnlStatistics.Controls.Add(Me.Label5)
        Me.PnlStatistics.Controls.Add(Me.LblSTDV)
        Me.PnlStatistics.Controls.Add(Me.LblMean)
        Me.PnlStatistics.Controls.Add(Me.Label6)
        Me.PnlStatistics.Location = New System.Drawing.Point(404, 58)
        Me.PnlStatistics.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PnlStatistics.Name = "PnlStatistics"
        Me.PnlStatistics.Size = New System.Drawing.Size(216, 208)
        Me.PnlStatistics.TabIndex = 33
        Me.PnlStatistics.Visible = False
        '
        'LblDiscrete
        '
        Me.LblDiscrete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiscrete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblDiscrete.Location = New System.Drawing.Point(24, 32)
        Me.LblDiscrete.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDiscrete.Name = "LblDiscrete"
        Me.LblDiscrete.Size = New System.Drawing.Size(141, 123)
        Me.LblDiscrete.TabIndex = 34
        Me.LblDiscrete.Text = "Only discrete layers are shown in the list."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Min:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 3)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 25)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Layer Statistics"
        '
        'LblMin
        '
        Me.LblMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMin.Location = New System.Drawing.Point(78, 42)
        Me.LblMin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMin.Name = "LblMin"
        Me.LblMin.Size = New System.Drawing.Size(105, 25)
        Me.LblMin.TabIndex = 6
        Me.LblMin.Text = "LblMin"
        Me.LblMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 82)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 25)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Max:"
        '
        'LblMax
        '
        Me.LblMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMax.Location = New System.Drawing.Point(78, 82)
        Me.LblMax.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMax.Name = "LblMax"
        Me.LblMax.Size = New System.Drawing.Size(105, 25)
        Me.LblMax.TabIndex = 9
        Me.LblMax.Text = "LblMax"
        Me.LblMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 122)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 25)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Mean:"
        '
        'LblSTDV
        '
        Me.LblSTDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSTDV.Location = New System.Drawing.Point(78, 162)
        Me.LblSTDV.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSTDV.Name = "LblSTDV"
        Me.LblSTDV.Size = New System.Drawing.Size(105, 25)
        Me.LblSTDV.TabIndex = 13
        Me.LblSTDV.Text = "LblSTDV"
        Me.LblSTDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMean
        '
        Me.LblMean.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMean.Location = New System.Drawing.Point(78, 122)
        Me.LblMean.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMean.Name = "LblMean"
        Me.LblMean.Size = New System.Drawing.Size(105, 25)
        Me.LblMean.TabIndex = 11
        Me.LblMean.Text = "LblMean"
        Me.LblMean.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 162)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 25)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "STDV:"
        '
        'GrpReclass
        '
        Me.GrpReclass.Controls.Add(Me.BtnId)
        Me.GrpReclass.Controls.Add(Me.BtnAuto)
        Me.GrpReclass.Controls.Add(Me.CboReclassField)
        Me.GrpReclass.Controls.Add(Me.Label9)
        Me.GrpReclass.Controls.Add(Me.DataGridView1)
        Me.GrpReclass.Controls.Add(Me.BtnSave)
        Me.GrpReclass.Controls.Add(Me.BtnClear)
        Me.GrpReclass.Controls.Add(Me.BtnLoad)
        Me.GrpReclass.Controls.Add(Me.BtnUnique)
        Me.GrpReclass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpReclass.Location = New System.Drawing.Point(27, 278)
        Me.GrpReclass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GrpReclass.Name = "GrpReclass"
        Me.GrpReclass.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GrpReclass.Size = New System.Drawing.Size(592, 403)
        Me.GrpReclass.TabIndex = 30
        Me.GrpReclass.TabStop = False
        Me.GrpReclass.Text = "Reclass"
        Me.GrpReclass.Visible = False
        '
        'BtnId
        '
        Me.BtnId.Enabled = False
        Me.BtnId.Location = New System.Drawing.Point(206, 72)
        Me.BtnId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnId.Name = "BtnId"
        Me.BtnId.Size = New System.Drawing.Size(90, 38)
        Me.BtnId.TabIndex = 24
        Me.BtnId.Text = "ID"
        Me.BtnId.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OldValue, Me.NewValues})
        Me.DataGridView1.Location = New System.Drawing.Point(9, 125)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(412, 254)
        Me.DataGridView1.TabIndex = 5
        '
        'OldValue
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.OldValue.DefaultCellStyle = DataGridViewCellStyle1
        Me.OldValue.HeaderText = "Old Values"
        Me.OldValue.Name = "OldValue"
        Me.OldValue.ReadOnly = True
        Me.OldValue.Width = 110
        '
        'NewValues
        '
        Me.NewValues.HeaderText = "New Values"
        Me.NewValues.Name = "NewValues"
        Me.NewValues.Width = 110
        '
        'BtnSave
        '
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(400, 72)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(90, 38)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Save..."
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnClear
        '
        Me.BtnClear.Enabled = False
        Me.BtnClear.Location = New System.Drawing.Point(500, 72)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(90, 38)
        Me.BtnClear.TabIndex = 3
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnLoad
        '
        Me.BtnLoad.Enabled = False
        Me.BtnLoad.Location = New System.Drawing.Point(302, 72)
        Me.BtnLoad.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(90, 38)
        Me.BtnLoad.TabIndex = 2
        Me.BtnLoad.Text = "Load..."
        Me.BtnLoad.UseVisualStyleBackColor = True
        '
        'BtnUnique
        '
        Me.BtnUnique.Enabled = False
        Me.BtnUnique.Location = New System.Drawing.Point(9, 72)
        Me.BtnUnique.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnUnique.Name = "BtnUnique"
        Me.BtnUnique.Size = New System.Drawing.Size(90, 38)
        Me.BtnUnique.TabIndex = 0
        Me.BtnUnique.Text = "Unique"
        Me.BtnUnique.UseVisualStyleBackColor = True
        '
        'RdoEqInterval
        '
        Me.RdoEqInterval.AutoSize = True
        Me.RdoEqInterval.Location = New System.Drawing.Point(117, 28)
        Me.RdoEqInterval.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoEqInterval.Name = "RdoEqInterval"
        Me.RdoEqInterval.Size = New System.Drawing.Size(155, 29)
        Me.RdoEqInterval.TabIndex = 0
        Me.RdoEqInterval.Text = "Equal Interval"
        Me.RdoEqInterval.UseVisualStyleBackColor = True
        '
        'TxtRuleId
        '
        Me.TxtRuleId.Enabled = False
        Me.TxtRuleId.Location = New System.Drawing.Point(38, 717)
        Me.TxtRuleId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtRuleId.Name = "TxtRuleId"
        Me.TxtRuleId.Size = New System.Drawing.Size(66, 26)
        Me.TxtRuleId.TabIndex = 35
        Me.TxtRuleId.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 31)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 25)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Method:"
        '
        'GrpSlice
        '
        Me.GrpSlice.Controls.Add(Me.TxtBaseZone)
        Me.GrpSlice.Controls.Add(Me.TxtNumberZones)
        Me.GrpSlice.Controls.Add(Me.Label8)
        Me.GrpSlice.Controls.Add(Me.Label7)
        Me.GrpSlice.Controls.Add(Me.RdoEqArea)
        Me.GrpSlice.Controls.Add(Me.Label3)
        Me.GrpSlice.Controls.Add(Me.RdoEqInterval)
        Me.GrpSlice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpSlice.Location = New System.Drawing.Point(27, 278)
        Me.GrpSlice.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GrpSlice.Name = "GrpSlice"
        Me.GrpSlice.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GrpSlice.Size = New System.Drawing.Size(592, 125)
        Me.GrpSlice.TabIndex = 29
        Me.GrpSlice.TabStop = False
        Me.GrpSlice.Text = "Slice"
        Me.GrpSlice.Visible = False
        '
        'TxtBaseZone
        '
        Me.TxtBaseZone.Location = New System.Drawing.Point(506, 71)
        Me.TxtBaseZone.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtBaseZone.Name = "TxtBaseZone"
        Me.TxtBaseZone.Size = New System.Drawing.Size(73, 30)
        Me.TxtBaseZone.TabIndex = 20
        Me.TxtBaseZone.Text = "1"
        '
        'TxtNumberZones
        '
        Me.TxtNumberZones.Location = New System.Drawing.Point(214, 72)
        Me.TxtNumberZones.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtNumberZones.Name = "TxtNumberZones"
        Me.TxtNumberZones.Size = New System.Drawing.Size(73, 30)
        Me.TxtNumberZones.TabIndex = 19
        Me.TxtNumberZones.Text = "10"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(312, 75)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(179, 25)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Base zone value:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 77)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(182, 25)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Number of zones:"
        '
        'RdoEqArea
        '
        Me.RdoEqArea.AutoSize = True
        Me.RdoEqArea.Checked = True
        Me.RdoEqArea.Location = New System.Drawing.Point(306, 28)
        Me.RdoEqArea.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoEqArea.Name = "RdoEqArea"
        Me.RdoEqArea.Size = New System.Drawing.Size(134, 29)
        Me.RdoEqArea.TabIndex = 16
        Me.RdoEqArea.TabStop = True
        Me.RdoEqArea.Text = "Equal Area"
        Me.RdoEqArea.UseVisualStyleBackColor = True
        '
        'LblRasterLayers
        '
        Me.LblRasterLayers.AutoSize = True
        Me.LblRasterLayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRasterLayers.Location = New System.Drawing.Point(178, 55)
        Me.LblRasterLayers.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRasterLayers.Name = "LblRasterLayers"
        Me.LblRasterLayers.Size = New System.Drawing.Size(126, 25)
        Me.LblRasterLayers.TabIndex = 28
        Me.LblRasterLayers.Text = "Select layer"
        '
        'BtnAbout
        '
        Me.BtnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAbout.Location = New System.Drawing.Point(458, 6)
        Me.BtnAbout.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnAbout.Name = "BtnAbout"
        Me.BtnAbout.Size = New System.Drawing.Size(158, 43)
        Me.BtnAbout.TabIndex = 52
        Me.BtnAbout.Text = "Tell me more"
        Me.BtnAbout.UseVisualStyleBackColor = True
        '
        'LblToolTip
        '
        Me.LblToolTip.AutoSize = True
        Me.LblToolTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToolTip.Location = New System.Drawing.Point(18, 15)
        Me.LblToolTip.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblToolTip.Name = "LblToolTip"
        Me.LblToolTip.Size = New System.Drawing.Size(397, 25)
        Me.LblToolTip.TabIndex = 53
        Me.LblToolTip.Text = "Use a reclassified raster to define zones"
        '
        'FrmHruRasterReclassRule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(639, 749)
        Me.Controls.Add(Me.GrpReclass)
        Me.Controls.Add(Me.LblToolTip)
        Me.Controls.Add(Me.BtnAbout)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.LstAoiRasterLayers)
        Me.Controls.Add(Me.BtnApply)
        Me.Controls.Add(Me.GrpLayerType)
        Me.Controls.Add(Me.PnlStatistics)
        Me.Controls.Add(Me.TxtRuleId)
        Me.Controls.Add(Me.GrpSlice)
        Me.Controls.Add(Me.LblRasterLayers)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmHruRasterReclassRule"
        Me.ShowIcon = False
        Me.Text = "FrmHruRasterReclassRule"
        Me.GrpLayerType.ResumeLayout(False)
        Me.GrpLayerType.PerformLayout()
        Me.PnlStatistics.ResumeLayout(False)
        Me.PnlStatistics.PerformLayout()
        Me.GrpReclass.ResumeLayout(False)
        Me.GrpReclass.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSlice.ResumeLayout(False)
        Me.GrpSlice.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents LstAoiRasterLayers As System.Windows.Forms.ListBox
    Friend WithEvents BtnApply As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CboReclassField As System.Windows.Forms.ComboBox
    Friend WithEvents GrpLayerType As System.Windows.Forms.GroupBox
    Friend WithEvents RdoHru As System.Windows.Forms.RadioButton
    Friend WithEvents RdoPrism As System.Windows.Forms.RadioButton
    Friend WithEvents RdoDem As System.Windows.Forms.RadioButton
    Friend WithEvents RdoRaster As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnAuto As System.Windows.Forms.Button
    Friend WithEvents PnlStatistics As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblMin As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblMax As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblSTDV As System.Windows.Forms.Label
    Friend WithEvents LblMean As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GrpReclass As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents BtnLoad As System.Windows.Forms.Button
    Friend WithEvents BtnUnique As System.Windows.Forms.Button
    Friend WithEvents RdoEqInterval As System.Windows.Forms.RadioButton
    Friend WithEvents TxtRuleId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GrpSlice As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBaseZone As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumberZones As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RdoEqArea As System.Windows.Forms.RadioButton
    Friend WithEvents LblRasterLayers As System.Windows.Forms.Label
    Friend WithEvents BtnAbout As System.Windows.Forms.Button
    Friend WithEvents LblToolTip As System.Windows.Forms.Label
    Friend WithEvents OldValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewValues As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblDiscrete As System.Windows.Forms.Label
    Friend WithEvents BtnId As System.Windows.Forms.Button
End Class