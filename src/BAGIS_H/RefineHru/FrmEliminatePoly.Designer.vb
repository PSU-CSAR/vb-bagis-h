Imports ESRI.ArcGIS.esriSystem

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEliminatePoly
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LstSelectHruLayers = New System.Windows.Forms.ListBox()
        Me.BtnSelectAOI = New System.Windows.Forms.Button()
        Me.LblNoOfZones = New System.Windows.Forms.Label()
        Me.LblMinZone = New System.Windows.Forms.Label()
        Me.LblMazSize = New System.Windows.Forms.Label()
        Me.TxtNoZones = New System.Windows.Forms.TextBox()
        Me.TxtMinZone = New System.Windows.Forms.TextBox()
        Me.TxtMaxZone = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadAcres = New System.Windows.Forms.RadioButton()
        Me.RadMile = New System.Windows.Forms.RadioButton()
        Me.RadKm = New System.Windows.Forms.RadioButton()
        Me.LblAreaUnit = New System.Windows.Forms.Label()
        Me.LlbMerge = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RdoPolyArea = New System.Windows.Forms.RadioButton()
        Me.RadPercentile = New System.Windows.Forms.RadioButton()
        Me.RadAreaOfAoi = New System.Windows.Forms.RadioButton()
        Me.BtnGoToMap = New System.Windows.Forms.Button()
        Me.PanelArea = New System.Windows.Forms.Panel()
        Me.LblPolygonArea = New System.Windows.Forms.Label()
        Me.TxtPolyArea = New System.Windows.Forms.TextBox()
        Me.PanelPercentile = New System.Windows.Forms.Panel()
        Me.LblThesholdPercentile = New System.Windows.Forms.Label()
        Me.cboThreshPercnt = New System.Windows.Forms.ComboBox()
        Me.LblHRUPath = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtHruName = New System.Windows.Forms.TextBox()
        Me.LlbRemoved = New System.Windows.Forms.Label()
        Me.BtnEliminate = New System.Windows.Forms.Button()
        Me.LblMerge = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RadLength = New System.Windows.Forms.RadioButton()
        Me.RadArea = New System.Windows.Forms.RadioButton()
        Me.TxtHruPath = New System.Windows.Forms.TextBox()
        Me.TxtNoZonesRemoved = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CkNonContiguous = New System.Windows.Forms.CheckBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnAbout = New System.Windows.Forms.Button()
        Me.TxtAOIPath = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CkRetainAttributes = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtParentNonContig = New System.Windows.Forms.TextBox()
        Me.TxtMinPoly = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelArea.SuspendLayout()
        Me.PanelPercentile.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(199, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "HRU layers"
        '
        'LstSelectHruLayers
        '
        Me.LstSelectHruLayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstSelectHruLayers.FormattingEnabled = True
        Me.LstSelectHruLayers.ItemHeight = 25
        Me.LstSelectHruLayers.Location = New System.Drawing.Point(171, 115)
        Me.LstSelectHruLayers.Name = "LstSelectHruLayers"
        Me.LstSelectHruLayers.Size = New System.Drawing.Size(165, 104)
        Me.LstSelectHruLayers.TabIndex = 6
        '
        'BtnSelectAOI
        '
        Me.BtnSelectAOI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelectAOI.Location = New System.Drawing.Point(16, 80)
        Me.BtnSelectAOI.Name = "BtnSelectAOI"
        Me.BtnSelectAOI.Size = New System.Drawing.Size(130, 35)
        Me.BtnSelectAOI.TabIndex = 5
        Me.BtnSelectAOI.Text = "Select AOI"
        Me.BtnSelectAOI.UseVisualStyleBackColor = True
        '
        'LblNoOfZones
        '
        Me.LblNoOfZones.AutoSize = True
        Me.LblNoOfZones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNoOfZones.Location = New System.Drawing.Point(444, 134)
        Me.LblNoOfZones.Name = "LblNoOfZones"
        Me.LblNoOfZones.Size = New System.Drawing.Size(173, 25)
        Me.LblNoOfZones.TabIndex = 8
        Me.LblNoOfZones.Text = "Number of Zones :"
        '
        'LblMinZone
        '
        Me.LblMinZone.AutoSize = True
        Me.LblMinZone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMinZone.Location = New System.Drawing.Point(467, 175)
        Me.LblMinZone.Name = "LblMinZone"
        Me.LblMinZone.Size = New System.Drawing.Size(149, 25)
        Me.LblMinZone.TabIndex = 9
        Me.LblMinZone.Text = "Min Zone Size :"
        '
        'LblMazSize
        '
        Me.LblMazSize.AutoSize = True
        Me.LblMazSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMazSize.Location = New System.Drawing.Point(461, 249)
        Me.LblMazSize.Name = "LblMazSize"
        Me.LblMazSize.Size = New System.Drawing.Size(155, 25)
        Me.LblMazSize.TabIndex = 10
        Me.LblMazSize.Text = "Max Zone Size :"
        '
        'TxtNoZones
        '
        Me.TxtNoZones.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtNoZones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoZones.Location = New System.Drawing.Point(622, 131)
        Me.TxtNoZones.Name = "TxtNoZones"
        Me.TxtNoZones.Size = New System.Drawing.Size(118, 30)
        Me.TxtNoZones.TabIndex = 11
        Me.TxtNoZones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtMinZone
        '
        Me.TxtMinZone.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtMinZone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMinZone.Location = New System.Drawing.Point(622, 170)
        Me.TxtMinZone.Name = "TxtMinZone"
        Me.TxtMinZone.Size = New System.Drawing.Size(118, 30)
        Me.TxtMinZone.TabIndex = 12
        Me.TxtMinZone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtMaxZone
        '
        Me.TxtMaxZone.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtMaxZone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaxZone.Location = New System.Drawing.Point(622, 246)
        Me.TxtMaxZone.Name = "TxtMaxZone"
        Me.TxtMaxZone.Size = New System.Drawing.Size(118, 30)
        Me.TxtMaxZone.TabIndex = 13
        Me.TxtMaxZone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadAcres)
        Me.Panel1.Controls.Add(Me.RadMile)
        Me.Panel1.Controls.Add(Me.RadKm)
        Me.Panel1.Controls.Add(Me.LblAreaUnit)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(555, 282)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(167, 116)
        Me.Panel1.TabIndex = 14
        '
        'RadAcres
        '
        Me.RadAcres.AutoSize = True
        Me.RadAcres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadAcres.Location = New System.Drawing.Point(16, 84)
        Me.RadAcres.Name = "RadAcres"
        Me.RadAcres.Size = New System.Drawing.Size(88, 29)
        Me.RadAcres.TabIndex = 3
        Me.RadAcres.TabStop = True
        Me.RadAcres.Text = "Acres"
        Me.RadAcres.UseVisualStyleBackColor = True
        '
        'RadMile
        '
        Me.RadMile.AutoSize = True
        Me.RadMile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadMile.Location = New System.Drawing.Point(16, 57)
        Me.RadMile.Name = "RadMile"
        Me.RadMile.Size = New System.Drawing.Size(118, 29)
        Me.RadMile.TabIndex = 2
        Me.RadMile.TabStop = True
        Me.RadMile.Text = "Sq. Miles"
        Me.RadMile.UseVisualStyleBackColor = True
        '
        'RadKm
        '
        Me.RadKm.AutoSize = True
        Me.RadKm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadKm.Location = New System.Drawing.Point(16, 28)
        Me.RadKm.Name = "RadKm"
        Me.RadKm.Size = New System.Drawing.Size(102, 29)
        Me.RadKm.TabIndex = 1
        Me.RadKm.TabStop = True
        Me.RadKm.Text = "Sq. Km"
        Me.RadKm.UseVisualStyleBackColor = True
        '
        'LblAreaUnit
        '
        Me.LblAreaUnit.AutoSize = True
        Me.LblAreaUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAreaUnit.Location = New System.Drawing.Point(13, 6)
        Me.LblAreaUnit.Name = "LblAreaUnit"
        Me.LblAreaUnit.Size = New System.Drawing.Size(102, 25)
        Me.LblAreaUnit.TabIndex = 0
        Me.LblAreaUnit.Text = "Area Unit"
        '
        'LlbMerge
        '
        Me.LlbMerge.AutoSize = True
        Me.LlbMerge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LlbMerge.Location = New System.Drawing.Point(11, 236)
        Me.LlbMerge.Name = "LlbMerge"
        Me.LlbMerge.Size = New System.Drawing.Size(216, 25)
        Me.LlbMerge.TabIndex = 15
        Me.LlbMerge.Text = "Eliminate Threshold :"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RdoPolyArea)
        Me.Panel2.Controls.Add(Me.RadPercentile)
        Me.Panel2.Controls.Add(Me.RadAreaOfAoi)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(15, 276)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(325, 70)
        Me.Panel2.TabIndex = 16
        '
        'RdoPolyArea
        '
        Me.RdoPolyArea.AutoSize = True
        Me.RdoPolyArea.Enabled = False
        Me.RdoPolyArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoPolyArea.Location = New System.Drawing.Point(5, 36)
        Me.RdoPolyArea.Name = "RdoPolyArea"
        Me.RdoPolyArea.Size = New System.Drawing.Size(318, 29)
        Me.RdoPolyArea.TabIndex = 31
        Me.RdoPolyArea.Text = "Area Of Individual Polygon Parts"
        Me.RdoPolyArea.UseVisualStyleBackColor = True
        '
        'RadPercentile
        '
        Me.RadPercentile.AutoSize = True
        Me.RadPercentile.Checked = True
        Me.RadPercentile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadPercentile.Location = New System.Drawing.Point(5, 5)
        Me.RadPercentile.Name = "RadPercentile"
        Me.RadPercentile.Size = New System.Drawing.Size(123, 29)
        Me.RadPercentile.TabIndex = 30
        Me.RadPercentile.TabStop = True
        Me.RadPercentile.Text = "Percentile"
        Me.RadPercentile.UseVisualStyleBackColor = True
        '
        'RadAreaOfAoi
        '
        Me.RadAreaOfAoi.AutoSize = True
        Me.RadAreaOfAoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadAreaOfAoi.Location = New System.Drawing.Point(130, 5)
        Me.RadAreaOfAoi.Name = "RadAreaOfAoi"
        Me.RadAreaOfAoi.Size = New System.Drawing.Size(155, 29)
        Me.RadAreaOfAoi.TabIndex = 29
        Me.RadAreaOfAoi.Text = "Area Of Zone"
        Me.RadAreaOfAoi.UseVisualStyleBackColor = True
        '
        'BtnGoToMap
        '
        Me.BtnGoToMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGoToMap.Location = New System.Drawing.Point(346, 308)
        Me.BtnGoToMap.Name = "BtnGoToMap"
        Me.BtnGoToMap.Size = New System.Drawing.Size(200, 35)
        Me.BtnGoToMap.TabIndex = 31
        Me.BtnGoToMap.Text = "Get Area From Map"
        Me.BtnGoToMap.UseVisualStyleBackColor = True
        '
        'PanelArea
        '
        Me.PanelArea.Controls.Add(Me.LblPolygonArea)
        Me.PanelArea.Controls.Add(Me.TxtPolyArea)
        Me.PanelArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelArea.Location = New System.Drawing.Point(113, 352)
        Me.PanelArea.Name = "PanelArea"
        Me.PanelArea.Size = New System.Drawing.Size(406, 45)
        Me.PanelArea.TabIndex = 17
        Me.PanelArea.Visible = False
        '
        'LblPolygonArea
        '
        Me.LblPolygonArea.AutoSize = True
        Me.LblPolygonArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPolygonArea.Location = New System.Drawing.Point(22, 9)
        Me.LblPolygonArea.Name = "LblPolygonArea"
        Me.LblPolygonArea.Size = New System.Drawing.Size(223, 25)
        Me.LblPolygonArea.TabIndex = 13
        Me.LblPolygonArea.Text = "Threshold Polygon Area"
        '
        'TxtPolyArea
        '
        Me.TxtPolyArea.Location = New System.Drawing.Point(244, 7)
        Me.TxtPolyArea.Name = "TxtPolyArea"
        Me.TxtPolyArea.Size = New System.Drawing.Size(143, 30)
        Me.TxtPolyArea.TabIndex = 11
        Me.TxtPolyArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PanelPercentile
        '
        Me.PanelPercentile.Controls.Add(Me.LblThesholdPercentile)
        Me.PanelPercentile.Controls.Add(Me.cboThreshPercnt)
        Me.PanelPercentile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelPercentile.Location = New System.Drawing.Point(113, 352)
        Me.PanelPercentile.Name = "PanelPercentile"
        Me.PanelPercentile.Size = New System.Drawing.Size(390, 45)
        Me.PanelPercentile.TabIndex = 18
        '
        'LblThesholdPercentile
        '
        Me.LblThesholdPercentile.AutoSize = True
        Me.LblThesholdPercentile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblThesholdPercentile.Location = New System.Drawing.Point(11, 9)
        Me.LblThesholdPercentile.Name = "LblThesholdPercentile"
        Me.LblThesholdPercentile.Size = New System.Drawing.Size(191, 25)
        Me.LblThesholdPercentile.TabIndex = 11
        Me.LblThesholdPercentile.Text = "Threshold Percentile"
        '
        'cboThreshPercnt
        '
        Me.cboThreshPercnt.FormattingEnabled = True
        Me.cboThreshPercnt.Location = New System.Drawing.Point(208, 6)
        Me.cboThreshPercnt.Name = "cboThreshPercnt"
        Me.cboThreshPercnt.Size = New System.Drawing.Size(88, 33)
        Me.cboThreshPercnt.TabIndex = 10
        '
        'LblHRUPath
        '
        Me.LblHRUPath.AutoSize = True
        Me.LblHRUPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHRUPath.Location = New System.Drawing.Point(11, 545)
        Me.LblHRUPath.Name = "LblHRUPath"
        Me.LblHRUPath.Size = New System.Drawing.Size(104, 25)
        Me.LblHRUPath.TabIndex = 19
        Me.LblHRUPath.Text = "HRU Path:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 507)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 25)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Output HRU Name:"
        '
        'TxtHruName
        '
        Me.TxtHruName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHruName.Location = New System.Drawing.Point(204, 504)
        Me.TxtHruName.Name = "TxtHruName"
        Me.TxtHruName.Size = New System.Drawing.Size(231, 30)
        Me.TxtHruName.TabIndex = 22
        '
        'LlbRemoved
        '
        Me.LlbRemoved.AutoSize = True
        Me.LlbRemoved.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LlbRemoved.ForeColor = System.Drawing.Color.Red
        Me.LlbRemoved.Location = New System.Drawing.Point(11, 447)
        Me.LlbRemoved.Name = "LlbRemoved"
        Me.LlbRemoved.Size = New System.Drawing.Size(318, 25)
        Me.LlbRemoved.TabIndex = 24
        Me.LlbRemoved.Text = "Estimated No. Of Zones Removed :"
        '
        'BtnEliminate
        '
        Me.BtnEliminate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminate.Location = New System.Drawing.Point(630, 580)
        Me.BtnEliminate.Name = "BtnEliminate"
        Me.BtnEliminate.Size = New System.Drawing.Size(115, 35)
        Me.BtnEliminate.TabIndex = 25
        Me.BtnEliminate.Text = "Eliminate"
        Me.BtnEliminate.UseVisualStyleBackColor = True
        '
        'LblMerge
        '
        Me.LblMerge.AutoSize = True
        Me.LblMerge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMerge.Location = New System.Drawing.Point(11, 411)
        Me.LblMerge.Name = "LblMerge"
        Me.LblMerge.Size = New System.Drawing.Size(310, 25)
        Me.LblMerge.TabIndex = 26
        Me.LblMerge.Text = "Merge Eliminated Polygons by:"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.RadLength)
        Me.Panel5.Controls.Add(Me.RadArea)
        Me.Panel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(341, 404)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(307, 34)
        Me.Panel5.TabIndex = 27
        '
        'RadLength
        '
        Me.RadLength.AutoSize = True
        Me.RadLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLength.Location = New System.Drawing.Point(162, 7)
        Me.RadLength.Name = "RadLength"
        Me.RadLength.Size = New System.Drawing.Size(141, 29)
        Me.RadLength.TabIndex = 1
        Me.RadLength.Text = "Length Rule"
        Me.RadLength.UseVisualStyleBackColor = True
        '
        'RadArea
        '
        Me.RadArea.AutoSize = True
        Me.RadArea.Checked = True
        Me.RadArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadArea.Location = New System.Drawing.Point(9, 7)
        Me.RadArea.Name = "RadArea"
        Me.RadArea.Size = New System.Drawing.Size(123, 29)
        Me.RadArea.TabIndex = 0
        Me.RadArea.TabStop = True
        Me.RadArea.Text = "Area Rule"
        Me.RadArea.UseVisualStyleBackColor = True
        '
        'TxtHruPath
        '
        Me.TxtHruPath.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtHruPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHruPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtHruPath.Location = New System.Drawing.Point(113, 544)
        Me.TxtHruPath.Name = "TxtHruPath"
        Me.TxtHruPath.Size = New System.Drawing.Size(629, 30)
        Me.TxtHruPath.TabIndex = 28
        '
        'TxtNoZonesRemoved
        '
        Me.TxtNoZonesRemoved.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtNoZonesRemoved.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoZonesRemoved.ForeColor = System.Drawing.Color.Red
        Me.TxtNoZonesRemoved.Location = New System.Drawing.Point(333, 444)
        Me.TxtNoZonesRemoved.Name = "TxtNoZonesRemoved"
        Me.TxtNoZonesRemoved.Size = New System.Drawing.Size(94, 30)
        Me.TxtNoZonesRemoved.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(586, 29)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "This tool eliminates small HRU polygons (zones)."
        '
        'CkNonContiguous
        '
        Me.CkNonContiguous.AutoSize = True
        Me.CkNonContiguous.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CkNonContiguous.Location = New System.Drawing.Point(447, 477)
        Me.CkNonContiguous.Name = "CkNonContiguous"
        Me.CkNonContiguous.Size = New System.Drawing.Size(295, 29)
        Me.CkNonContiguous.TabIndex = 34
        Me.CkNonContiguous.Text = "Allow non-contiguous HRU"
        Me.CkNonContiguous.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(505, 580)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(115, 35)
        Me.BtnCancel.TabIndex = 35
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnAbout
        '
        Me.BtnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAbout.Location = New System.Drawing.Point(600, 6)
        Me.BtnAbout.Name = "BtnAbout"
        Me.BtnAbout.Size = New System.Drawing.Size(145, 35)
        Me.BtnAbout.TabIndex = 36
        Me.BtnAbout.Text = "Tell me more"
        Me.BtnAbout.UseVisualStyleBackColor = True
        '
        'TxtAOIPath
        '
        Me.TxtAOIPath.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtAOIPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAOIPath.ForeColor = System.Drawing.Color.Blue
        Me.TxtAOIPath.Location = New System.Drawing.Point(132, 46)
        Me.TxtAOIPath.Name = "TxtAOIPath"
        Me.TxtAOIPath.Size = New System.Drawing.Size(610, 30)
        Me.TxtAOIPath.TabIndex = 37
        Me.TxtAOIPath.Text = "AOI is not specified"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 29)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "AOI Path:"
        '
        'CkRetainAttributes
        '
        Me.CkRetainAttributes.AutoSize = True
        Me.CkRetainAttributes.Checked = True
        Me.CkRetainAttributes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkRetainAttributes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CkRetainAttributes.Location = New System.Drawing.Point(447, 508)
        Me.CkRetainAttributes.Name = "CkRetainAttributes"
        Me.CkRetainAttributes.Size = New System.Drawing.Size(265, 29)
        Me.CkRetainAttributes.TabIndex = 39
        Me.CkRetainAttributes.Text = "Retain source attributes"
        Me.CkRetainAttributes.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(433, 447)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(191, 25)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Actual No. May Vary"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(431, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(207, 25)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Non-contiguous HRU :"
        '
        'TxtParentNonContig
        '
        Me.TxtParentNonContig.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtParentNonContig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtParentNonContig.Location = New System.Drawing.Point(647, 90)
        Me.TxtParentNonContig.Name = "TxtParentNonContig"
        Me.TxtParentNonContig.Size = New System.Drawing.Size(93, 30)
        Me.TxtParentNonContig.TabIndex = 42
        Me.TxtParentNonContig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtMinPoly
        '
        Me.TxtMinPoly.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtMinPoly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMinPoly.Location = New System.Drawing.Point(622, 208)
        Me.TxtMinPoly.Name = "TxtMinPoly"
        Me.TxtMinPoly.Size = New System.Drawing.Size(118, 30)
        Me.TxtMinPoly.TabIndex = 44
        Me.TxtMinPoly.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(442, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(175, 25)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Min Polygon Size :"
        '
        'FrmEliminatePoly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.PanelPercentile)
        Me.Controls.Add(Me.TxtMinPoly)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtParentNonContig)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CkRetainAttributes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtAOIPath)
        Me.Controls.Add(Me.BtnAbout)
        Me.Controls.Add(Me.BtnGoToMap)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.CkNonContiguous)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNoZonesRemoved)
        Me.Controls.Add(Me.TxtHruPath)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.LblMerge)
        Me.Controls.Add(Me.BtnEliminate)
        Me.Controls.Add(Me.LlbRemoved)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtHruName)
        Me.Controls.Add(Me.LblHRUPath)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LlbMerge)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtMaxZone)
        Me.Controls.Add(Me.TxtMinZone)
        Me.Controls.Add(Me.TxtNoZones)
        Me.Controls.Add(Me.LblMazSize)
        Me.Controls.Add(Me.LblMinZone)
        Me.Controls.Add(Me.LblNoOfZones)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LstSelectHruLayers)
        Me.Controls.Add(Me.BtnSelectAOI)
        Me.Controls.Add(Me.PanelArea)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmEliminatePoly"
        Me.Size = New System.Drawing.Size(748, 618)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelArea.ResumeLayout(False)
        Me.PanelArea.PerformLayout()
        Me.PanelPercentile.ResumeLayout(False)
        Me.PanelPercentile.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LstSelectHruLayers As System.Windows.Forms.ListBox
    Friend WithEvents BtnSelectAOI As System.Windows.Forms.Button
    Friend WithEvents LblNoOfZones As System.Windows.Forms.Label
    Friend WithEvents LblMinZone As System.Windows.Forms.Label
    Friend WithEvents LblMazSize As System.Windows.Forms.Label
    Friend WithEvents TxtNoZones As System.Windows.Forms.TextBox
    Friend WithEvents TxtMinZone As System.Windows.Forms.TextBox
    Friend WithEvents TxtMaxZone As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadAcres As System.Windows.Forms.RadioButton
    Friend WithEvents RadMile As System.Windows.Forms.RadioButton
    Friend WithEvents RadKm As System.Windows.Forms.RadioButton
    Friend WithEvents LblAreaUnit As System.Windows.Forms.Label
    Friend WithEvents LlbMerge As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnGoToMap As System.Windows.Forms.Button
    Friend WithEvents RadPercentile As System.Windows.Forms.RadioButton
    Friend WithEvents RadAreaOfAoi As System.Windows.Forms.RadioButton
    Friend WithEvents PanelArea As System.Windows.Forms.Panel
    Friend WithEvents LblPolygonArea As System.Windows.Forms.Label
    Friend WithEvents TxtPolyArea As System.Windows.Forms.TextBox
    Friend WithEvents PanelPercentile As System.Windows.Forms.Panel
    Friend WithEvents LblThesholdPercentile As System.Windows.Forms.Label
    Friend WithEvents cboThreshPercnt As System.Windows.Forms.ComboBox
    Friend WithEvents LblHRUPath As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtHruName As System.Windows.Forms.TextBox
    Friend WithEvents LlbRemoved As System.Windows.Forms.Label
    Friend WithEvents BtnEliminate As System.Windows.Forms.Button
    Friend WithEvents LblMerge As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents RadLength As System.Windows.Forms.RadioButton
    Friend WithEvents RadArea As System.Windows.Forms.RadioButton
    Friend WithEvents TxtHruPath As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoZonesRemoved As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CkNonContiguous As System.Windows.Forms.CheckBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnAbout As System.Windows.Forms.Button
    Friend WithEvents TxtAOIPath As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CkRetainAttributes As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RdoPolyArea As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtParentNonContig As System.Windows.Forms.TextBox
    Friend WithEvents TxtMinPoly As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class