<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDownloadAoiMenu
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.AoiGrid = New System.Windows.Forms.DataGridView()
        Me.AoiName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Uploaded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Author = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Download = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DownloadUrl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnDownloadAoi = New System.Windows.Forms.Button()
        Me.BtnList = New System.Windows.Forms.Button()
        Me.TxtBasinsDb = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDownloadPath = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnSelectDownloadFolder = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtUploadPath = New System.Windows.Forms.TextBox()
        Me.BtnSelectAoi = New System.Windows.Forms.Button()
        Me.BtnUploadZip = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtComment = New System.Windows.Forms.TextBox()
        Me.GrdTasks = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AoiType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Started = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Message = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Url = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocalFolder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DownloadStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.BtnTaskLog = New System.Windows.Forms.Button()
        Me.BtnUpdateStatus = New System.Windows.Forms.Button()
        Me.DownloadTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.AoiGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AoiGrid
        '
        Me.AoiGrid.AllowUserToAddRows = False
        Me.AoiGrid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AoiGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.AoiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AoiGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AoiName, Me.Uploaded, Me.Author, Me.Download, Me.Comment, Me.DownloadUrl})
        Me.AoiGrid.Location = New System.Drawing.Point(11, 41)
        Me.AoiGrid.Name = "AoiGrid"
        Me.AoiGrid.Size = New System.Drawing.Size(896, 165)
        Me.AoiGrid.TabIndex = 0
        Me.AoiGrid.TabStop = False
        '
        'AoiName
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AoiName.DefaultCellStyle = DataGridViewCellStyle2
        Me.AoiName.HeaderText = "AOI Name"
        Me.AoiName.Name = "AoiName"
        Me.AoiName.ReadOnly = True
        Me.AoiName.Width = 250
        '
        'Uploaded
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Uploaded.DefaultCellStyle = DataGridViewCellStyle3
        Me.Uploaded.HeaderText = "Uploaded"
        Me.Uploaded.Name = "Uploaded"
        Me.Uploaded.ReadOnly = True
        '
        'Author
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Author.DefaultCellStyle = DataGridViewCellStyle4
        Me.Author.HeaderText = "Author"
        Me.Author.Name = "Author"
        Me.Author.ReadOnly = True
        '
        'Download
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.NullValue = False
        Me.Download.DefaultCellStyle = DataGridViewCellStyle5
        Me.Download.HeaderText = "Download ?"
        Me.Download.Name = "Download"
        '
        'Comment
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comment.DefaultCellStyle = DataGridViewCellStyle6
        Me.Comment.HeaderText = "Comment"
        Me.Comment.Name = "Comment"
        Me.Comment.ReadOnly = True
        Me.Comment.Width = 250
        '
        'DownloadUrl
        '
        Me.DownloadUrl.HeaderText = "DownloadUrl"
        Me.DownloadUrl.Name = "DownloadUrl"
        Me.DownloadUrl.ReadOnly = True
        Me.DownloadUrl.Visible = False
        Me.DownloadUrl.Width = 5
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(806, 534)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(100, 30)
        Me.BtnCancel.TabIndex = 57
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnDownloadAoi
        '
        Me.BtnDownloadAoi.Enabled = False
        Me.BtnDownloadAoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDownloadAoi.Location = New System.Drawing.Point(806, 455)
        Me.BtnDownloadAoi.Name = "BtnDownloadAoi"
        Me.BtnDownloadAoi.Size = New System.Drawing.Size(100, 30)
        Me.BtnDownloadAoi.TabIndex = 56
        Me.BtnDownloadAoi.Text = "Download"
        Me.BtnDownloadAoi.UseVisualStyleBackColor = True
        '
        'BtnList
        '
        Me.BtnList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnList.Location = New System.Drawing.Point(502, 2)
        Me.BtnList.Name = "BtnList"
        Me.BtnList.Size = New System.Drawing.Size(100, 30)
        Me.BtnList.TabIndex = 68
        Me.BtnList.Text = "List"
        Me.BtnList.UseVisualStyleBackColor = True
        '
        'TxtBasinsDb
        '
        Me.TxtBasinsDb.Enabled = False
        Me.TxtBasinsDb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBasinsDb.Location = New System.Drawing.Point(143, 6)
        Me.TxtBasinsDb.Name = "TxtBasinsDb"
        Me.TxtBasinsDb.Size = New System.Drawing.Size(350, 22)
        Me.TxtBasinsDb.TabIndex = 73
        Me.TxtBasinsDb.Text = "https://ebagis.geog.pdx.edu/api/rest/"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 16)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Basins Database"
        '
        'TxtDownloadPath
        '
        Me.TxtDownloadPath.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtDownloadPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDownloadPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtDownloadPath.Location = New System.Drawing.Point(108, 453)
        Me.TxtDownloadPath.Name = "TxtDownloadPath"
        Me.TxtDownloadPath.ReadOnly = True
        Me.TxtDownloadPath.Size = New System.Drawing.Size(581, 22)
        Me.TxtDownloadPath.TabIndex = 76
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 456)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "Download to"
        '
        'BtnSelectDownloadFolder
        '
        Me.BtnSelectDownloadFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelectDownloadFolder.Location = New System.Drawing.Point(699, 455)
        Me.BtnSelectDownloadFolder.Name = "BtnSelectDownloadFolder"
        Me.BtnSelectDownloadFolder.Size = New System.Drawing.Size(100, 30)
        Me.BtnSelectDownloadFolder.TabIndex = 74
        Me.BtnSelectDownloadFolder.Text = "Select"
        Me.BtnSelectDownloadFolder.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 488)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 16)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Upload aoi path"
        '
        'TxtUploadPath
        '
        Me.TxtUploadPath.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TxtUploadPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUploadPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtUploadPath.Location = New System.Drawing.Point(130, 485)
        Me.TxtUploadPath.Name = "TxtUploadPath"
        Me.TxtUploadPath.ReadOnly = True
        Me.TxtUploadPath.Size = New System.Drawing.Size(435, 22)
        Me.TxtUploadPath.TabIndex = 78
        '
        'BtnSelectAoi
        '
        Me.BtnSelectAoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelectAoi.Location = New System.Drawing.Point(592, 488)
        Me.BtnSelectAoi.Name = "BtnSelectAoi"
        Me.BtnSelectAoi.Size = New System.Drawing.Size(100, 30)
        Me.BtnSelectAoi.TabIndex = 80
        Me.BtnSelectAoi.Text = "Select"
        Me.BtnSelectAoi.UseVisualStyleBackColor = True
        '
        'BtnUploadZip
        '
        Me.BtnUploadZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUploadZip.Location = New System.Drawing.Point(699, 488)
        Me.BtnUploadZip.Name = "BtnUploadZip"
        Me.BtnUploadZip.Size = New System.Drawing.Size(100, 30)
        Me.BtnUploadZip.TabIndex = 79
        Me.BtnUploadZip.Text = "Upload Zip"
        Me.BtnUploadZip.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 524)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 16)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Upload comment"
        '
        'TxtComment
        '
        Me.TxtComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComment.Location = New System.Drawing.Point(139, 523)
        Me.TxtComment.MaxLength = 512
        Me.TxtComment.Multiline = True
        Me.TxtComment.Name = "TxtComment"
        Me.TxtComment.Size = New System.Drawing.Size(550, 41)
        Me.TxtComment.TabIndex = 82
        '
        'GrdTasks
        '
        Me.GrdTasks.AllowUserToAddRows = False
        Me.GrdTasks.AllowUserToDeleteRows = False
        Me.GrdTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdTasks.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.GrdTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdTasks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.AoiType, Me.Status, Me.Started, Me.Message, Me.Url, Me.Id, Me.LocalFolder, Me.DownloadStatus})
        Me.GrdTasks.Location = New System.Drawing.Point(10, 282)
        Me.GrdTasks.Name = "GrdTasks"
        Me.GrdTasks.ReadOnly = True
        Me.GrdTasks.Size = New System.Drawing.Size(896, 165)
        Me.GrdTasks.TabIndex = 83
        Me.GrdTasks.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn1.HeaderText = "AOI Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 250
        '
        'AoiType
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AoiType.DefaultCellStyle = DataGridViewCellStyle9
        Me.AoiType.HeaderText = "Type"
        Me.AoiType.Name = "AoiType"
        Me.AoiType.ReadOnly = True
        '
        'Status
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status.DefaultCellStyle = DataGridViewCellStyle10
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'Started
        '
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Started.DefaultCellStyle = DataGridViewCellStyle11
        Me.Started.HeaderText = "Started"
        Me.Started.Name = "Started"
        Me.Started.ReadOnly = True
        Me.Started.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Started.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Started.Width = 125
        '
        'Message
        '
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Message.DefaultCellStyle = DataGridViewCellStyle12
        Me.Message.HeaderText = "Message"
        Me.Message.Name = "Message"
        Me.Message.ReadOnly = True
        Me.Message.Width = 275
        '
        'Url
        '
        Me.Url.HeaderText = "Url"
        Me.Url.Name = "Url"
        Me.Url.ReadOnly = True
        Me.Url.Visible = False
        Me.Url.Width = 5
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 5
        '
        'LocalFolder
        '
        Me.LocalFolder.HeaderText = "LocalFolder"
        Me.LocalFolder.Name = "LocalFolder"
        Me.LocalFolder.ReadOnly = True
        Me.LocalFolder.Visible = False
        Me.LocalFolder.Width = 5
        '
        'DownloadStatus
        '
        Me.DownloadStatus.HeaderText = "DownloadStatus"
        Me.DownloadStatus.Name = "DownloadStatus"
        Me.DownloadStatus.ReadOnly = True
        Me.DownloadStatus.Visible = False
        Me.DownloadStatus.Width = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 261)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 16)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Tasks in process"
        '
        'BtnClear
        '
        Me.BtnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.Location = New System.Drawing.Point(795, 246)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(110, 30)
        Me.BtnClear.TabIndex = 85
        Me.BtnClear.Text = "Clear tasks"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnUpload
        '
        Me.BtnUpload.Enabled = False
        Me.BtnUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpload.Location = New System.Drawing.Point(806, 488)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(100, 30)
        Me.BtnUpload.TabIndex = 86
        Me.BtnUpload.Text = "Upload"
        Me.BtnUpload.UseVisualStyleBackColor = True
        '
        'BtnTaskLog
        '
        Me.BtnTaskLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTaskLog.Location = New System.Drawing.Point(678, 246)
        Me.BtnTaskLog.Name = "BtnTaskLog"
        Me.BtnTaskLog.Size = New System.Drawing.Size(110, 30)
        Me.BtnTaskLog.TabIndex = 87
        Me.BtnTaskLog.Text = "View task log"
        Me.BtnTaskLog.UseVisualStyleBackColor = True
        '
        'BtnUpdateStatus
        '
        Me.BtnUpdateStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdateStatus.Location = New System.Drawing.Point(551, 246)
        Me.BtnUpdateStatus.Name = "BtnUpdateStatus"
        Me.BtnUpdateStatus.Size = New System.Drawing.Size(120, 30)
        Me.BtnUpdateStatus.TabIndex = 88
        Me.BtnUpdateStatus.Text = "Update status"
        Me.BtnUpdateStatus.UseVisualStyleBackColor = True
        '
        'DownloadTimer
        '
        Me.DownloadTimer.Interval = 10000
        '
        'FrmDownloadAoiMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 572)
        Me.Controls.Add(Me.BtnUpdateStatus)
        Me.Controls.Add(Me.BtnTaskLog)
        Me.Controls.Add(Me.BtnUpload)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GrdTasks)
        Me.Controls.Add(Me.TxtComment)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnSelectAoi)
        Me.Controls.Add(Me.BtnUploadZip)
        Me.Controls.Add(Me.TxtUploadPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDownloadPath)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnSelectDownloadFolder)
        Me.Controls.Add(Me.TxtBasinsDb)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BtnList)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnDownloadAoi)
        Me.Controls.Add(Me.AoiGrid)
        Me.Name = "FrmDownloadAoiMenu"
        Me.ShowIcon = False
        Me.Text = "Basins Aoi Menu"
        CType(Me.AoiGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdTasks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AoiGrid As System.Windows.Forms.DataGridView
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnDownloadAoi As System.Windows.Forms.Button
    Friend WithEvents BtnList As System.Windows.Forms.Button
    Friend WithEvents TxtBasinsDb As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtDownloadPath As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnSelectDownloadFolder As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtUploadPath As System.Windows.Forms.TextBox
    Friend WithEvents BtnSelectAoi As System.Windows.Forms.Button
    Friend WithEvents BtnUploadZip As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtComment As System.Windows.Forms.TextBox
    Friend WithEvents GrdTasks As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents AoiName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Uploaded As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Author As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Download As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DownloadUrl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnUpload As System.Windows.Forms.Button
    Friend WithEvents BtnTaskLog As System.Windows.Forms.Button
    Friend WithEvents BtnUpdateStatus As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AoiType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Started As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Message As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Url As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocalFolder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DownloadStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DownloadTimer As System.Windows.Forms.Timer
End Class
