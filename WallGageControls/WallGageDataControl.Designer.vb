<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WallGageDataControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WallGageDataControl))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataPanel = New WinFlume.ctl_Panel()
        Me.FixedDischargeIntervalBox = New WinFlume.ctl_GroupBox()
        Me.FixedDischargeIntervalTable = New WinFlume.ctl_DataGridView()
        Me.FdiDischarge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FdiHead = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FdiDistacne = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FixedHeadIntervalBox = New WinFlume.ctl_GroupBox()
        Me.FixedHeadIntervalTable = New WinFlume.ctl_DataGridView()
        Me.FhiHead = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FhiDistance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FhiDischarge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusPanel = New WinFlume.ctl_StatusPanel()
        Me.DataPanel.SuspendLayout()
        Me.FixedDischargeIntervalBox.SuspendLayout()
        CType(Me.FixedDischargeIntervalTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FixedHeadIntervalBox.SuspendLayout()
        CType(Me.FixedHeadIntervalTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataPanel
        '
        Me.DataPanel.Controls.Add(Me.FixedDischargeIntervalBox)
        Me.DataPanel.Controls.Add(Me.FixedHeadIntervalBox)
        resources.ApplyResources(Me.DataPanel, "DataPanel")
        Me.DataPanel.Name = "DataPanel"
        '
        'FixedDischargeIntervalBox
        '
        Me.FixedDischargeIntervalBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.FixedDischargeIntervalBox, "FixedDischargeIntervalBox")
        Me.FixedDischargeIntervalBox.Controls.Add(Me.FixedDischargeIntervalTable)
        Me.FixedDischargeIntervalBox.Name = "FixedDischargeIntervalBox"
        Me.FixedDischargeIntervalBox.TabStop = False
        '
        'FixedDischargeIntervalTable
        '
        Me.FixedDischargeIntervalTable.AllowUserToAddRows = False
        Me.FixedDischargeIntervalTable.AllowUserToDeleteRows = False
        Me.FixedDischargeIntervalTable.AllowUserToResizeColumns = False
        Me.FixedDischargeIntervalTable.AllowUserToResizeRows = False
        Me.FixedDischargeIntervalTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.FixedDischargeIntervalTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.FixedDischargeIntervalTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FixedDischargeIntervalTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.FixedDischargeIntervalTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FixedDischargeIntervalTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FdiDischarge, Me.FdiHead, Me.FdiDistacne})
        resources.ApplyResources(Me.FixedDischargeIntervalTable, "FixedDischargeIntervalTable")
        Me.FixedDischargeIntervalTable.GridColor = System.Drawing.Color.Black
        Me.FixedDischargeIntervalTable.MultiSelect = False
        Me.FixedDischargeIntervalTable.Name = "FixedDischargeIntervalTable"
        Me.FixedDischargeIntervalTable.RowHeadersVisible = False
        Me.FixedDischargeIntervalTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.FixedDischargeIntervalTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        '
        'FdiDischarge
        '
        resources.ApplyResources(Me.FdiDischarge, "FdiDischarge")
        Me.FdiDischarge.Name = "FdiDischarge"
        '
        'FdiHead
        '
        resources.ApplyResources(Me.FdiHead, "FdiHead")
        Me.FdiHead.Name = "FdiHead"
        '
        'FdiDistacne
        '
        resources.ApplyResources(Me.FdiDistacne, "FdiDistacne")
        Me.FdiDistacne.Name = "FdiDistacne"
        '
        'FixedHeadIntervalBox
        '
        Me.FixedHeadIntervalBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.FixedHeadIntervalBox, "FixedHeadIntervalBox")
        Me.FixedHeadIntervalBox.Controls.Add(Me.FixedHeadIntervalTable)
        Me.FixedHeadIntervalBox.Name = "FixedHeadIntervalBox"
        Me.FixedHeadIntervalBox.TabStop = False
        '
        'FixedHeadIntervalTable
        '
        Me.FixedHeadIntervalTable.AllowUserToAddRows = False
        Me.FixedHeadIntervalTable.AllowUserToDeleteRows = False
        Me.FixedHeadIntervalTable.AllowUserToResizeColumns = False
        Me.FixedHeadIntervalTable.AllowUserToResizeRows = False
        Me.FixedHeadIntervalTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.FixedHeadIntervalTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.FixedHeadIntervalTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FixedHeadIntervalTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.FixedHeadIntervalTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FixedHeadIntervalTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FhiHead, Me.FhiDistance, Me.FhiDischarge})
        resources.ApplyResources(Me.FixedHeadIntervalTable, "FixedHeadIntervalTable")
        Me.FixedHeadIntervalTable.GridColor = System.Drawing.Color.Black
        Me.FixedHeadIntervalTable.MultiSelect = False
        Me.FixedHeadIntervalTable.Name = "FixedHeadIntervalTable"
        Me.FixedHeadIntervalTable.RowHeadersVisible = False
        Me.FixedHeadIntervalTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.FixedHeadIntervalTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        '
        'FhiHead
        '
        resources.ApplyResources(Me.FhiHead, "FhiHead")
        Me.FhiHead.Name = "FhiHead"
        '
        'FhiDistance
        '
        resources.ApplyResources(Me.FhiDistance, "FhiDistance")
        Me.FhiDistance.Name = "FhiDistance"
        '
        'FhiDischarge
        '
        resources.ApplyResources(Me.FhiDischarge, "FhiDischarge")
        Me.FhiDischarge.Name = "FhiDischarge"
        '
        'StatusPanel
        '
        Me.StatusPanel.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.StatusPanel, "StatusPanel")
        Me.StatusPanel.Name = "StatusPanel"
        '
        'WallGageDataControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.DataPanel)
        Me.Controls.Add(Me.StatusPanel)
        Me.Name = "WallGageDataControl"
        Me.DataPanel.ResumeLayout(False)
        Me.FixedDischargeIntervalBox.ResumeLayout(False)
        CType(Me.FixedDischargeIntervalTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FixedHeadIntervalBox.ResumeLayout(False)
        CType(Me.FixedHeadIntervalTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StatusPanel As ctl_StatusPanel
    Friend WithEvents DataPanel As ctl_Panel
    Friend WithEvents FixedDischargeIntervalBox As ctl_GroupBox
    Friend WithEvents FixedDischargeIntervalTable As ctl_DataGridView
    Friend WithEvents FdiDischarge As DataGridViewTextBoxColumn
    Friend WithEvents FdiHead As DataGridViewTextBoxColumn
    Friend WithEvents FdiDistacne As DataGridViewTextBoxColumn
    Friend WithEvents FixedHeadIntervalBox As ctl_GroupBox
    Friend WithEvents FixedHeadIntervalTable As ctl_DataGridView
    Friend WithEvents FhiHead As DataGridViewTextBoxColumn
    Friend WithEvents FhiDistance As DataGridViewTextBoxColumn
    Friend WithEvents FhiDischarge As DataGridViewTextBoxColumn
End Class
