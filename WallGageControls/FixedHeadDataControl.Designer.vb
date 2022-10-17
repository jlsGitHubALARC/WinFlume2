<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FixedHeadDataControl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FixedHeadDataControl))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataPanel = New WinFlume.ctl_Panel()
        Me.GageSlopeSingle = New WinFlume.ctl_SingleUnits()
        Me.GageRatioLabel = New WinFlume.ctl_Label()
        Me.GageSlopeLabel = New WinFlume.ctl_Label()
        Me.GageReferenceGroup = New WinFlume.ctl_GroupBox()
        Me.UpstreamChannellBottomButton = New WinFlume.ctl_RadioButton()
        Me.SillReferencedButton = New WinFlume.ctl_RadioButton()
        Me.WallGageOptionsBox = New WinFlume.ctl_GroupBox()
        Me.HeadSmartRangeButton = New WinFlume.ctl_Button()
        Me.HeadIncrementSingle = New WinFlume.ctl_SingleUnits()
        Me.HeadIncrementLabel = New WinFlume.ctl_Label()
        Me.MaximumHeadSingle = New WinFlume.ctl_SingleUnits()
        Me.MaximumHeadLabel = New WinFlume.ctl_Label()
        Me.MinimumHeadSingle = New WinFlume.ctl_SingleUnits()
        Me.MinimumHeadLabel = New WinFlume.ctl_Label()
        Me.WallGageDataBox = New WinFlume.ctl_GroupBox()
        Me.FixedHeadIntervalTable = New WinFlume.ctl_DataGridView()
        Me.FhiHead = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FhiDistance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FhiDischarge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusPanel = New WinFlume.ctl_StatusPanel()
        Me.DataPanel.SuspendLayout()
        Me.GageReferenceGroup.SuspendLayout()
        Me.WallGageOptionsBox.SuspendLayout()
        Me.WallGageDataBox.SuspendLayout()
        CType(Me.FixedHeadIntervalTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataPanel
        '
        Me.DataPanel.Controls.Add(Me.GageSlopeSingle)
        Me.DataPanel.Controls.Add(Me.GageRatioLabel)
        Me.DataPanel.Controls.Add(Me.GageSlopeLabel)
        Me.DataPanel.Controls.Add(Me.GageReferenceGroup)
        Me.DataPanel.Controls.Add(Me.WallGageOptionsBox)
        Me.DataPanel.Controls.Add(Me.WallGageDataBox)
        resources.ApplyResources(Me.DataPanel, "DataPanel")
        Me.DataPanel.Name = "DataPanel"
        '
        'GageSlopeSingle
        '
        resources.ApplyResources(Me.GageSlopeSingle, "GageSlopeSingle")
        Me.GageSlopeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GageSlopeSingle.FormatStyle = "0.0###"
        Me.GageSlopeSingle.Label = ""
        Me.GageSlopeSingle.Name = "GageSlopeSingle"
        Me.GageSlopeSingle.SiDefaultValue = 0!
        Me.GageSlopeSingle.SiMin = -1.401298E-45!
        Me.GageSlopeSingle.SiUnits = ""
        Me.GageSlopeSingle.SiValue = 0!
        '
        'GageRatioLabel
        '
        resources.ApplyResources(Me.GageRatioLabel, "GageRatioLabel")
        Me.GageRatioLabel.Name = "GageRatioLabel"
        '
        'GageSlopeLabel
        '
        resources.ApplyResources(Me.GageSlopeLabel, "GageSlopeLabel")
        Me.GageSlopeLabel.Name = "GageSlopeLabel"
        '
        'GageReferenceGroup
        '
        Me.GageReferenceGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GageReferenceGroup.Controls.Add(Me.UpstreamChannellBottomButton)
        Me.GageReferenceGroup.Controls.Add(Me.SillReferencedButton)
        resources.ApplyResources(Me.GageReferenceGroup, "GageReferenceGroup")
        Me.GageReferenceGroup.Name = "GageReferenceGroup"
        Me.GageReferenceGroup.TabStop = False
        '
        'UpstreamChannellBottomButton
        '
        resources.ApplyResources(Me.UpstreamChannellBottomButton, "UpstreamChannellBottomButton")
        Me.UpstreamChannellBottomButton.Label = ""
        Me.UpstreamChannellBottomButton.Name = "UpstreamChannellBottomButton"
        Me.UpstreamChannellBottomButton.RbValue = -1
        Me.UpstreamChannellBottomButton.TabStop = True
        Me.UpstreamChannellBottomButton.UiValue = -1
        Me.UpstreamChannellBottomButton.UseVisualStyleBackColor = True
        '
        'SillReferencedButton
        '
        resources.ApplyResources(Me.SillReferencedButton, "SillReferencedButton")
        Me.SillReferencedButton.Label = ""
        Me.SillReferencedButton.Name = "SillReferencedButton"
        Me.SillReferencedButton.RbValue = -1
        Me.SillReferencedButton.TabStop = True
        Me.SillReferencedButton.UiValue = -1
        Me.SillReferencedButton.UseVisualStyleBackColor = True
        '
        'WallGageOptionsBox
        '
        Me.WallGageOptionsBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.WallGageOptionsBox, "WallGageOptionsBox")
        Me.WallGageOptionsBox.Controls.Add(Me.HeadSmartRangeButton)
        Me.WallGageOptionsBox.Controls.Add(Me.HeadIncrementSingle)
        Me.WallGageOptionsBox.Controls.Add(Me.HeadIncrementLabel)
        Me.WallGageOptionsBox.Controls.Add(Me.MaximumHeadSingle)
        Me.WallGageOptionsBox.Controls.Add(Me.MaximumHeadLabel)
        Me.WallGageOptionsBox.Controls.Add(Me.MinimumHeadSingle)
        Me.WallGageOptionsBox.Controls.Add(Me.MinimumHeadLabel)
        Me.WallGageOptionsBox.Name = "WallGageOptionsBox"
        Me.WallGageOptionsBox.TabStop = False
        '
        'HeadSmartRangeButton
        '
        Me.HeadSmartRangeButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.HeadSmartRangeButton, "HeadSmartRangeButton")
        Me.HeadSmartRangeButton.Name = "HeadSmartRangeButton"
        Me.HeadSmartRangeButton.UseVisualStyleBackColor = False
        '
        'HeadIncrementSingle
        '
        resources.ApplyResources(Me.HeadIncrementSingle, "HeadIncrementSingle")
        Me.HeadIncrementSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HeadIncrementSingle.FormatStyle = "0.0###"
        Me.HeadIncrementSingle.Label = ""
        Me.HeadIncrementSingle.Name = "HeadIncrementSingle"
        Me.HeadIncrementSingle.SiDefaultValue = 0!
        Me.HeadIncrementSingle.SiMin = -1.401298E-45!
        Me.HeadIncrementSingle.SiUnits = ""
        Me.HeadIncrementSingle.SiValue = 0!
        '
        'HeadIncrementLabel
        '
        resources.ApplyResources(Me.HeadIncrementLabel, "HeadIncrementLabel")
        Me.HeadIncrementLabel.Name = "HeadIncrementLabel"
        '
        'MaximumHeadSingle
        '
        resources.ApplyResources(Me.MaximumHeadSingle, "MaximumHeadSingle")
        Me.MaximumHeadSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MaximumHeadSingle.FormatStyle = "0.0###"
        Me.MaximumHeadSingle.Label = ""
        Me.MaximumHeadSingle.Name = "MaximumHeadSingle"
        Me.MaximumHeadSingle.SiDefaultValue = 0!
        Me.MaximumHeadSingle.SiMin = -1.401298E-45!
        Me.MaximumHeadSingle.SiUnits = ""
        Me.MaximumHeadSingle.SiValue = 0!
        '
        'MaximumHeadLabel
        '
        resources.ApplyResources(Me.MaximumHeadLabel, "MaximumHeadLabel")
        Me.MaximumHeadLabel.Name = "MaximumHeadLabel"
        '
        'MinimumHeadSingle
        '
        resources.ApplyResources(Me.MinimumHeadSingle, "MinimumHeadSingle")
        Me.MinimumHeadSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MinimumHeadSingle.FormatStyle = "0.0###"
        Me.MinimumHeadSingle.Label = ""
        Me.MinimumHeadSingle.Name = "MinimumHeadSingle"
        Me.MinimumHeadSingle.SiDefaultValue = 0!
        Me.MinimumHeadSingle.SiMin = -1.401298E-45!
        Me.MinimumHeadSingle.SiUnits = ""
        Me.MinimumHeadSingle.SiValue = 0!
        '
        'MinimumHeadLabel
        '
        resources.ApplyResources(Me.MinimumHeadLabel, "MinimumHeadLabel")
        Me.MinimumHeadLabel.Name = "MinimumHeadLabel"
        '
        'WallGageDataBox
        '
        Me.WallGageDataBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.WallGageDataBox, "WallGageDataBox")
        Me.WallGageDataBox.Controls.Add(Me.FixedHeadIntervalTable)
        Me.WallGageDataBox.Name = "WallGageDataBox"
        Me.WallGageDataBox.TabStop = False
        '
        'FixedHeadIntervalTable
        '
        resources.ApplyResources(Me.FixedHeadIntervalTable, "FixedHeadIntervalTable")
        Me.FixedHeadIntervalTable.AllowUserToAddRows = False
        Me.FixedHeadIntervalTable.AllowUserToDeleteRows = False
        Me.FixedHeadIntervalTable.AllowUserToResizeColumns = False
        Me.FixedHeadIntervalTable.AllowUserToResizeRows = False
        Me.FixedHeadIntervalTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.FixedHeadIntervalTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.FixedHeadIntervalTable.CausesValidation = False
        Me.FixedHeadIntervalTable.ClipboardColHeaders = Nothing
        Me.FixedHeadIntervalTable.ClipboardColUnits = Nothing
        Me.FixedHeadIntervalTable.ClipboardRows = Nothing
        Me.FixedHeadIntervalTable.ClipboardText = Nothing
        Me.FixedHeadIntervalTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FixedHeadIntervalTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.FixedHeadIntervalTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FixedHeadIntervalTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FhiHead, Me.FhiDistance, Me.FhiDischarge})
        Me.FixedHeadIntervalTable.GridColor = System.Drawing.Color.Black
        Me.FixedHeadIntervalTable.MultiSelect = False
        Me.FixedHeadIntervalTable.Name = "FixedHeadIntervalTable"
        Me.FixedHeadIntervalTable.ReadOnly = True
        Me.FixedHeadIntervalTable.RowHeadersVisible = False
        Me.FixedHeadIntervalTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.FixedHeadIntervalTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.FixedHeadIntervalTable.TableColUnits = Nothing
        '
        'FhiHead
        '
        resources.ApplyResources(Me.FhiHead, "FhiHead")
        Me.FhiHead.Name = "FhiHead"
        Me.FhiHead.ReadOnly = True
        '
        'FhiDistance
        '
        resources.ApplyResources(Me.FhiDistance, "FhiDistance")
        Me.FhiDistance.Name = "FhiDistance"
        Me.FhiDistance.ReadOnly = True
        '
        'FhiDischarge
        '
        resources.ApplyResources(Me.FhiDischarge, "FhiDischarge")
        Me.FhiDischarge.Name = "FhiDischarge"
        Me.FhiDischarge.ReadOnly = True
        '
        'StatusPanel
        '
        Me.StatusPanel.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.StatusPanel, "StatusPanel")
        Me.StatusPanel.Name = "StatusPanel"
        '
        'FixedHeadDataControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.DataPanel)
        Me.Controls.Add(Me.StatusPanel)
        Me.Name = "FixedHeadDataControl"
        Me.DataPanel.ResumeLayout(False)
        Me.DataPanel.PerformLayout()
        Me.GageReferenceGroup.ResumeLayout(False)
        Me.GageReferenceGroup.PerformLayout()
        Me.WallGageOptionsBox.ResumeLayout(False)
        Me.WallGageOptionsBox.PerformLayout()
        Me.WallGageDataBox.ResumeLayout(False)
        CType(Me.FixedHeadIntervalTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StatusPanel As ctl_StatusPanel
    Friend WithEvents DataPanel As ctl_Panel
    Friend WithEvents WallGageDataBox As ctl_GroupBox
    Friend WithEvents FixedHeadIntervalTable As ctl_DataGridView
    Friend WithEvents FhiHead As DataGridViewTextBoxColumn
    Friend WithEvents FhiDistance As DataGridViewTextBoxColumn
    Friend WithEvents FhiDischarge As DataGridViewTextBoxColumn
    Friend WithEvents WallGageOptionsBox As ctl_GroupBox
    Friend WithEvents HeadSmartRangeButton As ctl_Button
    Friend WithEvents HeadIncrementSingle As ctl_SingleUnits
    Friend WithEvents HeadIncrementLabel As ctl_Label
    Friend WithEvents MaximumHeadSingle As ctl_SingleUnits
    Friend WithEvents MaximumHeadLabel As ctl_Label
    Friend WithEvents MinimumHeadSingle As ctl_SingleUnits
    Friend WithEvents MinimumHeadLabel As ctl_Label
    Friend WithEvents GageReferenceGroup As ctl_GroupBox
    Friend WithEvents UpstreamChannellBottomButton As ctl_RadioButton
    Friend WithEvents SillReferencedButton As ctl_RadioButton
    Friend WithEvents GageRatioLabel As ctl_Label
    Friend WithEvents GageSlopeLabel As ctl_Label
    Friend WithEvents GageSlopeSingle As ctl_SingleUnits
End Class
