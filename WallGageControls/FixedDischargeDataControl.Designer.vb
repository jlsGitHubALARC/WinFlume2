<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FixedDischargeDataControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FixedDischargeDataControl))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataPanel = New WinFlume.ctl_Panel()
        Me.WallGageDataBox = New WinFlume.ctl_GroupBox()
        Me.FixedDischargeIntervalTable = New WinFlume.ctl_DataGridView()
        Me.FdiDischarge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FdiHead = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FdiDistance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WallGageOptionsBox = New WinFlume.ctl_GroupBox()
        Me.DischargeSmartRangeButton = New WinFlume.ctl_Button()
        Me.DischargeIncrementSingle = New WinFlume.ctl_SingleUnits()
        Me.DischargeIncrementLabel = New WinFlume.ctl_Label()
        Me.MaximumDischargeSingle = New WinFlume.ctl_SingleUnits()
        Me.MaximumDischargeLabel = New WinFlume.ctl_Label()
        Me.MinimumDischargeSingle = New WinFlume.ctl_SingleUnits()
        Me.MinimumDischargeLabel = New WinFlume.ctl_Label()
        Me.GageSlopeSingle = New WinFlume.ctl_SingleUnits()
        Me.GageRatioLabel = New WinFlume.ctl_Label()
        Me.GageSlopeLabel = New WinFlume.ctl_Label()
        Me.GageReferenceGroup = New WinFlume.ctl_GroupBox()
        Me.UpstreamChannellBottomButton = New WinFlume.ctl_RadioButton()
        Me.SillReferencedButton = New WinFlume.ctl_RadioButton()
        Me.StatusPanel = New WinFlume.ctl_StatusPanel()
        Me.DataPanel.SuspendLayout()
        Me.WallGageDataBox.SuspendLayout()
        CType(Me.FixedDischargeIntervalTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WallGageOptionsBox.SuspendLayout()
        Me.GageReferenceGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataPanel
        '
        Me.DataPanel.Controls.Add(Me.WallGageDataBox)
        Me.DataPanel.Controls.Add(Me.WallGageOptionsBox)
        Me.DataPanel.Controls.Add(Me.GageSlopeSingle)
        Me.DataPanel.Controls.Add(Me.GageRatioLabel)
        Me.DataPanel.Controls.Add(Me.GageSlopeLabel)
        Me.DataPanel.Controls.Add(Me.GageReferenceGroup)
        resources.ApplyResources(Me.DataPanel, "DataPanel")
        Me.DataPanel.Name = "DataPanel"
        '
        'WallGageDataBox
        '
        Me.WallGageDataBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.WallGageDataBox, "WallGageDataBox")
        Me.WallGageDataBox.Controls.Add(Me.FixedDischargeIntervalTable)
        Me.WallGageDataBox.Name = "WallGageDataBox"
        Me.WallGageDataBox.TabStop = False
        '
        'FixedDischargeIntervalTable
        '
        resources.ApplyResources(Me.FixedDischargeIntervalTable, "FixedDischargeIntervalTable")
        Me.FixedDischargeIntervalTable.AllowUserToAddRows = False
        Me.FixedDischargeIntervalTable.AllowUserToDeleteRows = False
        Me.FixedDischargeIntervalTable.AllowUserToResizeColumns = False
        Me.FixedDischargeIntervalTable.AllowUserToResizeRows = False
        Me.FixedDischargeIntervalTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.FixedDischargeIntervalTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.FixedDischargeIntervalTable.CausesValidation = False
        Me.FixedDischargeIntervalTable.ClipboardColHeaders = Nothing
        Me.FixedDischargeIntervalTable.ClipboardColUnits = Nothing
        Me.FixedDischargeIntervalTable.ClipboardRows = Nothing
        Me.FixedDischargeIntervalTable.ClipboardText = Nothing
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
        Me.FixedDischargeIntervalTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FdiDischarge, Me.FdiHead, Me.FdiDistance})
        Me.FixedDischargeIntervalTable.GridColor = System.Drawing.Color.Black
        Me.FixedDischargeIntervalTable.MultiSelect = False
        Me.FixedDischargeIntervalTable.Name = "FixedDischargeIntervalTable"
        Me.FixedDischargeIntervalTable.ReadOnly = True
        Me.FixedDischargeIntervalTable.RowHeadersVisible = False
        Me.FixedDischargeIntervalTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.FixedDischargeIntervalTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.FixedDischargeIntervalTable.TableColUnits = Nothing
        '
        'FdiDischarge
        '
        resources.ApplyResources(Me.FdiDischarge, "FdiDischarge")
        Me.FdiDischarge.Name = "FdiDischarge"
        Me.FdiDischarge.ReadOnly = True
        '
        'FdiHead
        '
        resources.ApplyResources(Me.FdiHead, "FdiHead")
        Me.FdiHead.Name = "FdiHead"
        Me.FdiHead.ReadOnly = True
        '
        'FdiDistance
        '
        resources.ApplyResources(Me.FdiDistance, "FdiDistance")
        Me.FdiDistance.Name = "FdiDistance"
        Me.FdiDistance.ReadOnly = True
        '
        'WallGageOptionsBox
        '
        Me.WallGageOptionsBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.WallGageOptionsBox, "WallGageOptionsBox")
        Me.WallGageOptionsBox.Controls.Add(Me.DischargeSmartRangeButton)
        Me.WallGageOptionsBox.Controls.Add(Me.DischargeIncrementSingle)
        Me.WallGageOptionsBox.Controls.Add(Me.DischargeIncrementLabel)
        Me.WallGageOptionsBox.Controls.Add(Me.MaximumDischargeSingle)
        Me.WallGageOptionsBox.Controls.Add(Me.MaximumDischargeLabel)
        Me.WallGageOptionsBox.Controls.Add(Me.MinimumDischargeSingle)
        Me.WallGageOptionsBox.Controls.Add(Me.MinimumDischargeLabel)
        Me.WallGageOptionsBox.Name = "WallGageOptionsBox"
        Me.WallGageOptionsBox.TabStop = False
        '
        'DischargeSmartRangeButton
        '
        Me.DischargeSmartRangeButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.DischargeSmartRangeButton, "DischargeSmartRangeButton")
        Me.DischargeSmartRangeButton.Name = "DischargeSmartRangeButton"
        Me.DischargeSmartRangeButton.UseVisualStyleBackColor = False
        '
        'DischargeIncrementSingle
        '
        resources.ApplyResources(Me.DischargeIncrementSingle, "DischargeIncrementSingle")
        Me.DischargeIncrementSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DischargeIncrementSingle.FormatStyle = "0.0###"
        Me.DischargeIncrementSingle.IsReadOnly = False
        Me.DischargeIncrementSingle.Label = ""
        Me.DischargeIncrementSingle.Name = "DischargeIncrementSingle"
        Me.DischargeIncrementSingle.ReadOnlyMsgBox = Nothing
        Me.DischargeIncrementSingle.SiDefaultValue = 0!
        Me.DischargeIncrementSingle.SiMin = -1.401298E-45!
        Me.DischargeIncrementSingle.SiUnits = ""
        Me.DischargeIncrementSingle.SiValue = 0!
        Me.DischargeIncrementSingle.UndoEnabled = True
        '
        'DischargeIncrementLabel
        '
        resources.ApplyResources(Me.DischargeIncrementLabel, "DischargeIncrementLabel")
        Me.DischargeIncrementLabel.Name = "DischargeIncrementLabel"
        '
        'MaximumDischargeSingle
        '
        resources.ApplyResources(Me.MaximumDischargeSingle, "MaximumDischargeSingle")
        Me.MaximumDischargeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MaximumDischargeSingle.FormatStyle = "0.0###"
        Me.MaximumDischargeSingle.IsReadOnly = False
        Me.MaximumDischargeSingle.Label = ""
        Me.MaximumDischargeSingle.Name = "MaximumDischargeSingle"
        Me.MaximumDischargeSingle.ReadOnlyMsgBox = Nothing
        Me.MaximumDischargeSingle.SiDefaultValue = 0!
        Me.MaximumDischargeSingle.SiMin = -1.401298E-45!
        Me.MaximumDischargeSingle.SiUnits = ""
        Me.MaximumDischargeSingle.SiValue = 0!
        Me.MaximumDischargeSingle.UndoEnabled = True
        '
        'MaximumDischargeLabel
        '
        resources.ApplyResources(Me.MaximumDischargeLabel, "MaximumDischargeLabel")
        Me.MaximumDischargeLabel.Name = "MaximumDischargeLabel"
        '
        'MinimumDischargeSingle
        '
        resources.ApplyResources(Me.MinimumDischargeSingle, "MinimumDischargeSingle")
        Me.MinimumDischargeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MinimumDischargeSingle.FormatStyle = "0.0###"
        Me.MinimumDischargeSingle.IsReadOnly = False
        Me.MinimumDischargeSingle.Label = ""
        Me.MinimumDischargeSingle.Name = "MinimumDischargeSingle"
        Me.MinimumDischargeSingle.ReadOnlyMsgBox = Nothing
        Me.MinimumDischargeSingle.SiDefaultValue = 0!
        Me.MinimumDischargeSingle.SiMin = -1.401298E-45!
        Me.MinimumDischargeSingle.SiUnits = ""
        Me.MinimumDischargeSingle.SiValue = 0!
        Me.MinimumDischargeSingle.UndoEnabled = True
        '
        'MinimumDischargeLabel
        '
        resources.ApplyResources(Me.MinimumDischargeLabel, "MinimumDischargeLabel")
        Me.MinimumDischargeLabel.Name = "MinimumDischargeLabel"
        '
        'GageSlopeSingle
        '
        resources.ApplyResources(Me.GageSlopeSingle, "GageSlopeSingle")
        Me.GageSlopeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GageSlopeSingle.FormatStyle = "0.0###"
        Me.GageSlopeSingle.IsReadOnly = False
        Me.GageSlopeSingle.Label = ""
        Me.GageSlopeSingle.Name = "GageSlopeSingle"
        Me.GageSlopeSingle.ReadOnlyMsgBox = Nothing
        Me.GageSlopeSingle.SiDefaultValue = 0!
        Me.GageSlopeSingle.SiMin = -1.401298E-45!
        Me.GageSlopeSingle.SiUnits = ""
        Me.GageSlopeSingle.SiValue = 0!
        Me.GageSlopeSingle.UndoEnabled = True
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
        'StatusPanel
        '
        Me.StatusPanel.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.StatusPanel, "StatusPanel")
        Me.StatusPanel.Name = "StatusPanel"
        '
        'FixedDischargeDataControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.DataPanel)
        Me.Controls.Add(Me.StatusPanel)
        Me.Name = "FixedDischargeDataControl"
        Me.DataPanel.ResumeLayout(False)
        Me.DataPanel.PerformLayout()
        Me.WallGageDataBox.ResumeLayout(False)
        CType(Me.FixedDischargeIntervalTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WallGageOptionsBox.ResumeLayout(False)
        Me.WallGageOptionsBox.PerformLayout()
        Me.GageReferenceGroup.ResumeLayout(False)
        Me.GageReferenceGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StatusPanel As ctl_StatusPanel
    Friend WithEvents DataPanel As ctl_Panel
    Friend WithEvents GageSlopeSingle As ctl_SingleUnits
    Friend WithEvents GageRatioLabel As ctl_Label
    Friend WithEvents GageSlopeLabel As ctl_Label
    Friend WithEvents GageReferenceGroup As ctl_GroupBox
    Friend WithEvents UpstreamChannellBottomButton As ctl_RadioButton
    Friend WithEvents SillReferencedButton As ctl_RadioButton
    Friend WithEvents WallGageOptionsBox As ctl_GroupBox
    Friend WithEvents DischargeSmartRangeButton As ctl_Button
    Friend WithEvents DischargeIncrementSingle As ctl_SingleUnits
    Friend WithEvents DischargeIncrementLabel As ctl_Label
    Friend WithEvents MaximumDischargeSingle As ctl_SingleUnits
    Friend WithEvents MaximumDischargeLabel As ctl_Label
    Friend WithEvents MinimumDischargeSingle As ctl_SingleUnits
    Friend WithEvents MinimumDischargeLabel As ctl_Label
    Friend WithEvents WallGageDataBox As ctl_GroupBox
    Friend WithEvents FixedDischargeIntervalTable As ctl_DataGridView
    Friend WithEvents FdiDischarge As DataGridViewTextBoxColumn
    Friend WithEvents FdiHead As DataGridViewTextBoxColumn
    Friend WithEvents FdiDistance As DataGridViewTextBoxColumn
End Class
