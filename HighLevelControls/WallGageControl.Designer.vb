<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WallGageControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WallGageControl))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.WallGagePanel = New WinFlume.ctl_Panel()
        Me.HeadSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.FixedHeadDataBox = New WinFlume.ctl_GroupBox()
        Me.FixedHeadIntervalTable = New WinFlume.ctl_DataGridView()
        Me.FhiHead = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FhiDistance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FhiDischarge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HeadStatusPanel = New WinFlume.ctl_StatusPanel()
        Me.DischargeSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.FixedDischargeDataBox = New WinFlume.ctl_GroupBox()
        Me.FixedDischargeIntervalTable = New WinFlume.ctl_DataGridView()
        Me.FdiDischarge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FdiHead = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FdiDistance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DischargeStatusPanel = New WinFlume.ctl_StatusPanel()
        Me.FixedHeadGageBox = New WinFlume.ctl_GroupBox()
        Me.FixedHeadPlotPanel = New WinFlume.ctl_Panel()
        Me.FixedHeadGagePanel = New WinFlume.ctl_Panel()
        Me.FixedHeadThumbnailLabel = New WinFlume.ctl_Label()
        Me.FixedHeadGagePlot = New WinFlume.ctl_Canvas2D()
        Me.FixedHeadControlPanel = New WinFlume.ctl_Panel()
        Me.PrintHeadGageButton = New WinFlume.ctl_Button()
        Me.HeadFirstLabelOffsetLabel = New WinFlume.ctl_Label()
        Me.HeadFirstLabelOffsetControl = New WinFlume.ctl_SingleUpDown()
        Me.LabelsTypePanel = New WinFlume.ctl_Panel()
        Me.FlowLabelsButton = New WinFlume.ctl_RadioButton()
        Me.HeadLabelsButton = New WinFlume.ctl_RadioButton()
        Me.HeadDecimalsToShowLabel = New WinFlume.ctl_Label()
        Me.HeadDecimalsToShowControl = New WinFlume.ctl_SingleUpDown()
        Me.HeadLabeledTickIntervalControl = New WinFlume.ctl_ComboBox()
        Me.HeadLabeledTickIntervalLabel = New WinFlume.ctl_Label()
        Me.HeadLabelSizeFactorLabel = New WinFlume.ctl_Label()
        Me.HeadLabelSizeFactorUpDown = New WinFlume.ctl_SingleUpDown()
        Me.ViewHeadGageButton = New WinFlume.ctl_Button()
        Me.HeadGageTypePanel = New WinFlume.ctl_Panel()
        Me.VerticalHeadGageButton = New WinFlume.ctl_RadioButton()
        Me.SlopedHeadGageButton = New WinFlume.ctl_RadioButton()
        Me.FixedDischargeGageBox = New WinFlume.ctl_GroupBox()
        Me.FixedDischargeGagePanel = New WinFlume.ctl_Panel()
        Me.FixedDischargeThumbnailLabel = New WinFlume.ctl_Label()
        Me.FixedDischargeGagePlot = New WinFlume.ctl_Canvas2D()
        Me.FixedDischargeControlPanel = New WinFlume.ctl_Panel()
        Me.PrintDischargeGageButton = New WinFlume.ctl_Button()
        Me.DischargeFirstLabelOffsetLabel = New WinFlume.ctl_Label()
        Me.DischargeFirstLabelOffsetControl = New WinFlume.ctl_SingleUpDown()
        Me.DischargeDecimalsToShowLabel = New WinFlume.ctl_Label()
        Me.DischargeDecimalsToShowControl = New WinFlume.ctl_SingleUpDown()
        Me.DischargeLabeledTickIntervalControl = New WinFlume.ctl_ComboBox()
        Me.DischargeLabeledTickIntervalLabel = New WinFlume.ctl_Label()
        Me.DischargeLabelSizeFactorLabel = New WinFlume.ctl_Label()
        Me.DischargeLabelSizeFactorUpDown = New WinFlume.ctl_SingleUpDown()
        Me.ViewDischargeGageButton = New WinFlume.ctl_Button()
        Me.DischargeGageTypePanel = New WinFlume.ctl_Panel()
        Me.VerticalDischargeGageButton = New WinFlume.ctl_RadioButton()
        Me.SlopedDischargeGageButton = New WinFlume.ctl_RadioButton()
        Me.GageTypeGroup = New WinFlume.ctl_GroupBox()
        Me.FixedHeadButton = New WinFlume.ctl_RadioButton()
        Me.FixedDischargeButton = New WinFlume.ctl_RadioButton()
        Me.DischargeGageSlopeLabel = New WinFlume.ctl_Label()
        Me.DischargeGageRatioLabel = New WinFlume.ctl_Label()
        Me.DischargeGageSlopeSingle = New WinFlume.ctl_SingleUnits()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.DischargeControlPanel = New WinFlume.ctl_Panel()
        Me.DischargeOptionsBox = New WinFlume.ctl_GroupBox()
        Me.DischargeSmartRangeButton = New WinFlume.ctl_Button()
        Me.DischargeIncrementSingle = New WinFlume.ctl_SingleUnits()
        Me.DischargeIncrementLabel = New WinFlume.ctl_Label()
        Me.MaximumDischargeSingle = New WinFlume.ctl_SingleUnits()
        Me.MaximumDischargeLabel = New WinFlume.ctl_Label()
        Me.MinimumDischargeSingle = New WinFlume.ctl_SingleUnits()
        Me.MinimumDischargeLabel = New WinFlume.ctl_Label()
        Me.DischargeReferenceGroup = New WinFlume.ctl_GroupBox()
        Me.DischargeUpstreamChannellBottomButton = New WinFlume.ctl_RadioButton()
        Me.DischargeSillReferencedButton = New WinFlume.ctl_RadioButton()
        Me.HeadControlPanel = New WinFlume.ctl_Panel()
        Me.HeadGageSlopeSingle = New WinFlume.ctl_SingleUnits()
        Me.GageRatioLabel = New WinFlume.ctl_Label()
        Me.GageSlopeLabel = New WinFlume.ctl_Label()
        Me.GageReferenceGroup = New WinFlume.ctl_GroupBox()
        Me.HeadUpstreamChannellBottomButton = New WinFlume.ctl_RadioButton()
        Me.HeadSillReferencedButton = New WinFlume.ctl_RadioButton()
        Me.HeadOptionsBox = New WinFlume.ctl_GroupBox()
        Me.HeadSmartRangeButton = New WinFlume.ctl_Button()
        Me.HeadIncrementSingle = New WinFlume.ctl_SingleUnits()
        Me.HeadIncrementLabel = New WinFlume.ctl_Label()
        Me.MaximumHeadSingle = New WinFlume.ctl_SingleUnits()
        Me.MaximumHeadLabel = New WinFlume.ctl_Label()
        Me.MinimumHeadSingle = New WinFlume.ctl_SingleUnits()
        Me.MinimumHeadLabel = New WinFlume.ctl_Label()
        Me.GageViewPanel = New WinFlume.ctl_Panel()
        Me.GageViewGroup = New WinFlume.ctl_GroupBox()
        Me.GagePlotViewButton = New WinFlume.ctl_RadioButton()
        Me.DataTableViewButton = New WinFlume.ctl_RadioButton()
        Me.PrintWallGageDialog = New System.Windows.Forms.PrintDialog()
        Me.PrintWallGageDocument = New System.Drawing.Printing.PrintDocument()
        Me.WallGagePanel.SuspendLayout()
        CType(Me.HeadSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeadSplitContainer.Panel1.SuspendLayout()
        Me.HeadSplitContainer.Panel2.SuspendLayout()
        Me.HeadSplitContainer.SuspendLayout()
        Me.FixedHeadDataBox.SuspendLayout()
        CType(Me.FixedHeadIntervalTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DischargeSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DischargeSplitContainer.Panel1.SuspendLayout()
        Me.DischargeSplitContainer.Panel2.SuspendLayout()
        Me.DischargeSplitContainer.SuspendLayout()
        Me.FixedDischargeDataBox.SuspendLayout()
        CType(Me.FixedDischargeIntervalTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FixedHeadGageBox.SuspendLayout()
        Me.FixedHeadPlotPanel.SuspendLayout()
        Me.FixedHeadGagePanel.SuspendLayout()
        CType(Me.FixedHeadGagePlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FixedHeadControlPanel.SuspendLayout()
        CType(Me.HeadFirstLabelOffsetControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LabelsTypePanel.SuspendLayout()
        CType(Me.HeadDecimalsToShowControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeadLabelSizeFactorUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeadGageTypePanel.SuspendLayout()
        Me.FixedDischargeGageBox.SuspendLayout()
        Me.FixedDischargeGagePanel.SuspendLayout()
        CType(Me.FixedDischargeGagePlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FixedDischargeControlPanel.SuspendLayout()
        CType(Me.DischargeFirstLabelOffsetControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DischargeDecimalsToShowControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DischargeLabelSizeFactorUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DischargeGageTypePanel.SuspendLayout()
        Me.GageTypeGroup.SuspendLayout()
        Me.ControlPanel.SuspendLayout()
        Me.DischargeControlPanel.SuspendLayout()
        Me.DischargeOptionsBox.SuspendLayout()
        Me.DischargeReferenceGroup.SuspendLayout()
        Me.HeadControlPanel.SuspendLayout()
        Me.GageReferenceGroup.SuspendLayout()
        Me.HeadOptionsBox.SuspendLayout()
        Me.GageViewPanel.SuspendLayout()
        Me.GageViewGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'WallGagePanel
        '
        Me.WallGagePanel.Controls.Add(Me.HeadSplitContainer)
        Me.WallGagePanel.Controls.Add(Me.DischargeSplitContainer)
        Me.WallGagePanel.Controls.Add(Me.FixedHeadGageBox)
        Me.WallGagePanel.Controls.Add(Me.FixedDischargeGageBox)
        resources.ApplyResources(Me.WallGagePanel, "WallGagePanel")
        Me.WallGagePanel.Name = "WallGagePanel"
        '
        'HeadSplitContainer
        '
        resources.ApplyResources(Me.HeadSplitContainer, "HeadSplitContainer")
        Me.HeadSplitContainer.Name = "HeadSplitContainer"
        '
        'HeadSplitContainer.Panel1
        '
        Me.HeadSplitContainer.Panel1.Controls.Add(Me.FixedHeadDataBox)
        '
        'HeadSplitContainer.Panel2
        '
        Me.HeadSplitContainer.Panel2.Controls.Add(Me.HeadStatusPanel)
        '
        'FixedHeadDataBox
        '
        Me.FixedHeadDataBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.FixedHeadDataBox, "FixedHeadDataBox")
        Me.FixedHeadDataBox.Controls.Add(Me.FixedHeadIntervalTable)
        Me.FixedHeadDataBox.Name = "FixedHeadDataBox"
        Me.FixedHeadDataBox.TabStop = False
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
        'HeadStatusPanel
        '
        Me.HeadStatusPanel.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.HeadStatusPanel, "HeadStatusPanel")
        Me.HeadStatusPanel.Name = "HeadStatusPanel"
        '
        'DischargeSplitContainer
        '
        resources.ApplyResources(Me.DischargeSplitContainer, "DischargeSplitContainer")
        Me.DischargeSplitContainer.Name = "DischargeSplitContainer"
        '
        'DischargeSplitContainer.Panel1
        '
        Me.DischargeSplitContainer.Panel1.Controls.Add(Me.FixedDischargeDataBox)
        '
        'DischargeSplitContainer.Panel2
        '
        Me.DischargeSplitContainer.Panel2.Controls.Add(Me.DischargeStatusPanel)
        '
        'FixedDischargeDataBox
        '
        Me.FixedDischargeDataBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.FixedDischargeDataBox, "FixedDischargeDataBox")
        Me.FixedDischargeDataBox.Controls.Add(Me.FixedDischargeIntervalTable)
        Me.FixedDischargeDataBox.Name = "FixedDischargeDataBox"
        Me.FixedDischargeDataBox.TabStop = False
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FixedDischargeIntervalTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
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
        'DischargeStatusPanel
        '
        Me.DischargeStatusPanel.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.DischargeStatusPanel, "DischargeStatusPanel")
        Me.DischargeStatusPanel.Name = "DischargeStatusPanel"
        '
        'FixedHeadGageBox
        '
        Me.FixedHeadGageBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.FixedHeadGageBox, "FixedHeadGageBox")
        Me.FixedHeadGageBox.Controls.Add(Me.FixedHeadPlotPanel)
        Me.FixedHeadGageBox.Controls.Add(Me.FixedHeadControlPanel)
        Me.FixedHeadGageBox.Name = "FixedHeadGageBox"
        Me.FixedHeadGageBox.TabStop = False
        '
        'FixedHeadPlotPanel
        '
        Me.FixedHeadPlotPanel.Controls.Add(Me.FixedHeadGagePanel)
        resources.ApplyResources(Me.FixedHeadPlotPanel, "FixedHeadPlotPanel")
        Me.FixedHeadPlotPanel.Name = "FixedHeadPlotPanel"
        '
        'FixedHeadGagePanel
        '
        Me.FixedHeadGagePanel.Controls.Add(Me.FixedHeadThumbnailLabel)
        Me.FixedHeadGagePanel.Controls.Add(Me.FixedHeadGagePlot)
        resources.ApplyResources(Me.FixedHeadGagePanel, "FixedHeadGagePanel")
        Me.FixedHeadGagePanel.Name = "FixedHeadGagePanel"
        '
        'FixedHeadThumbnailLabel
        '
        resources.ApplyResources(Me.FixedHeadThumbnailLabel, "FixedHeadThumbnailLabel")
        Me.FixedHeadThumbnailLabel.Name = "FixedHeadThumbnailLabel"
        '
        'FixedHeadGagePlot
        '
        resources.ApplyResources(Me.FixedHeadGagePlot, "FixedHeadGagePlot")
        Me.FixedHeadGagePlot.Name = "FixedHeadGagePlot"
        Me.FixedHeadGagePlot.TabStop = False
        '
        'FixedHeadControlPanel
        '
        Me.FixedHeadControlPanel.Controls.Add(Me.PrintHeadGageButton)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadFirstLabelOffsetLabel)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadFirstLabelOffsetControl)
        Me.FixedHeadControlPanel.Controls.Add(Me.LabelsTypePanel)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadDecimalsToShowLabel)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadDecimalsToShowControl)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadLabeledTickIntervalControl)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadLabeledTickIntervalLabel)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadLabelSizeFactorLabel)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadLabelSizeFactorUpDown)
        Me.FixedHeadControlPanel.Controls.Add(Me.ViewHeadGageButton)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadGageTypePanel)
        resources.ApplyResources(Me.FixedHeadControlPanel, "FixedHeadControlPanel")
        Me.FixedHeadControlPanel.Name = "FixedHeadControlPanel"
        '
        'PrintHeadGageButton
        '
        Me.PrintHeadGageButton.BackColor = System.Drawing.SystemColors.Control
        Me.PrintHeadGageButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.PrintHeadGageButton, "PrintHeadGageButton")
        Me.PrintHeadGageButton.Name = "PrintHeadGageButton"
        Me.PrintHeadGageButton.UseVisualStyleBackColor = False
        '
        'HeadFirstLabelOffsetLabel
        '
        resources.ApplyResources(Me.HeadFirstLabelOffsetLabel, "HeadFirstLabelOffsetLabel")
        Me.HeadFirstLabelOffsetLabel.Name = "HeadFirstLabelOffsetLabel"
        '
        'HeadFirstLabelOffsetControl
        '
        Me.HeadFirstLabelOffsetControl.FormatStyle = "0"
        Me.HeadFirstLabelOffsetControl.Label = ""
        resources.ApplyResources(Me.HeadFirstLabelOffsetControl, "HeadFirstLabelOffsetControl")
        Me.HeadFirstLabelOffsetControl.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.HeadFirstLabelOffsetControl.Minimum = New Decimal(New Integer() {9999, 0, 0, -2147483648})
        Me.HeadFirstLabelOffsetControl.Name = "HeadFirstLabelOffsetControl"
        Me.HeadFirstLabelOffsetControl.SiValue = 0!
        Me.HeadFirstLabelOffsetControl.UiValue = 0!
        Me.HeadFirstLabelOffsetControl.UndoEnabled = True
        '
        'LabelsTypePanel
        '
        Me.LabelsTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelsTypePanel.Controls.Add(Me.FlowLabelsButton)
        Me.LabelsTypePanel.Controls.Add(Me.HeadLabelsButton)
        resources.ApplyResources(Me.LabelsTypePanel, "LabelsTypePanel")
        Me.LabelsTypePanel.Name = "LabelsTypePanel"
        '
        'FlowLabelsButton
        '
        resources.ApplyResources(Me.FlowLabelsButton, "FlowLabelsButton")
        Me.FlowLabelsButton.Label = ""
        Me.FlowLabelsButton.Name = "FlowLabelsButton"
        Me.FlowLabelsButton.RbValue = -1
        Me.FlowLabelsButton.TabStop = True
        Me.FlowLabelsButton.UiValue = -1
        Me.FlowLabelsButton.UseVisualStyleBackColor = True
        '
        'HeadLabelsButton
        '
        resources.ApplyResources(Me.HeadLabelsButton, "HeadLabelsButton")
        Me.HeadLabelsButton.Label = ""
        Me.HeadLabelsButton.Name = "HeadLabelsButton"
        Me.HeadLabelsButton.RbValue = -1
        Me.HeadLabelsButton.TabStop = True
        Me.HeadLabelsButton.UiValue = -1
        Me.HeadLabelsButton.UseVisualStyleBackColor = True
        '
        'HeadDecimalsToShowLabel
        '
        resources.ApplyResources(Me.HeadDecimalsToShowLabel, "HeadDecimalsToShowLabel")
        Me.HeadDecimalsToShowLabel.Name = "HeadDecimalsToShowLabel"
        '
        'HeadDecimalsToShowControl
        '
        Me.HeadDecimalsToShowControl.FormatStyle = "0"
        Me.HeadDecimalsToShowControl.Label = ""
        resources.ApplyResources(Me.HeadDecimalsToShowControl, "HeadDecimalsToShowControl")
        Me.HeadDecimalsToShowControl.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.HeadDecimalsToShowControl.Name = "HeadDecimalsToShowControl"
        Me.HeadDecimalsToShowControl.SiValue = 0!
        Me.HeadDecimalsToShowControl.UiValue = 0!
        Me.HeadDecimalsToShowControl.UndoEnabled = True
        '
        'HeadLabeledTickIntervalControl
        '
        Me.HeadLabeledTickIntervalControl.BackColor = System.Drawing.SystemColors.Window
        Me.HeadLabeledTickIntervalControl.DefaultValue = 0
        Me.HeadLabeledTickIntervalControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.HeadLabeledTickIntervalControl, "HeadLabeledTickIntervalControl")
        Me.HeadLabeledTickIntervalControl.FormattingEnabled = True
        Me.HeadLabeledTickIntervalControl.Items.AddRange(New Object() {resources.GetString("HeadLabeledTickIntervalControl.Items"), resources.GetString("HeadLabeledTickIntervalControl.Items1"), resources.GetString("HeadLabeledTickIntervalControl.Items2"), resources.GetString("HeadLabeledTickIntervalControl.Items3"), resources.GetString("HeadLabeledTickIntervalControl.Items4")})
        Me.HeadLabeledTickIntervalControl.Name = "HeadLabeledTickIntervalControl"
        Me.HeadLabeledTickIntervalControl.UndoEnabled = True
        Me.HeadLabeledTickIntervalControl.Value = -1
        '
        'HeadLabeledTickIntervalLabel
        '
        resources.ApplyResources(Me.HeadLabeledTickIntervalLabel, "HeadLabeledTickIntervalLabel")
        Me.HeadLabeledTickIntervalLabel.Name = "HeadLabeledTickIntervalLabel"
        '
        'HeadLabelSizeFactorLabel
        '
        resources.ApplyResources(Me.HeadLabelSizeFactorLabel, "HeadLabelSizeFactorLabel")
        Me.HeadLabelSizeFactorLabel.Name = "HeadLabelSizeFactorLabel"
        '
        'HeadLabelSizeFactorUpDown
        '
        Me.HeadLabelSizeFactorUpDown.DecimalPlaces = 2
        Me.HeadLabelSizeFactorUpDown.FormatStyle = "0.0###"
        Me.HeadLabelSizeFactorUpDown.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.HeadLabelSizeFactorUpDown.Label = ""
        resources.ApplyResources(Me.HeadLabelSizeFactorUpDown, "HeadLabelSizeFactorUpDown")
        Me.HeadLabelSizeFactorUpDown.Maximum = New Decimal(New Integer() {205, 0, 0, 131072})
        Me.HeadLabelSizeFactorUpDown.Minimum = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.HeadLabelSizeFactorUpDown.Name = "HeadLabelSizeFactorUpDown"
        Me.HeadLabelSizeFactorUpDown.SiValue = 0.05!
        Me.HeadLabelSizeFactorUpDown.UiValue = 0.05!
        Me.HeadLabelSizeFactorUpDown.UndoEnabled = True
        Me.HeadLabelSizeFactorUpDown.Value = New Decimal(New Integer() {5, 0, 0, 131072})
        '
        'ViewHeadGageButton
        '
        Me.ViewHeadGageButton.BackColor = System.Drawing.SystemColors.Control
        Me.ViewHeadGageButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.ViewHeadGageButton, "ViewHeadGageButton")
        Me.ViewHeadGageButton.Name = "ViewHeadGageButton"
        Me.ViewHeadGageButton.UseVisualStyleBackColor = False
        '
        'HeadGageTypePanel
        '
        Me.HeadGageTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HeadGageTypePanel.Controls.Add(Me.VerticalHeadGageButton)
        Me.HeadGageTypePanel.Controls.Add(Me.SlopedHeadGageButton)
        resources.ApplyResources(Me.HeadGageTypePanel, "HeadGageTypePanel")
        Me.HeadGageTypePanel.Name = "HeadGageTypePanel"
        '
        'VerticalHeadGageButton
        '
        resources.ApplyResources(Me.VerticalHeadGageButton, "VerticalHeadGageButton")
        Me.VerticalHeadGageButton.Label = ""
        Me.VerticalHeadGageButton.Name = "VerticalHeadGageButton"
        Me.VerticalHeadGageButton.RbValue = -1
        Me.VerticalHeadGageButton.TabStop = True
        Me.VerticalHeadGageButton.UiValue = -1
        Me.VerticalHeadGageButton.UseVisualStyleBackColor = True
        '
        'SlopedHeadGageButton
        '
        resources.ApplyResources(Me.SlopedHeadGageButton, "SlopedHeadGageButton")
        Me.SlopedHeadGageButton.Label = ""
        Me.SlopedHeadGageButton.Name = "SlopedHeadGageButton"
        Me.SlopedHeadGageButton.RbValue = -1
        Me.SlopedHeadGageButton.TabStop = True
        Me.SlopedHeadGageButton.UiValue = -1
        Me.SlopedHeadGageButton.UseVisualStyleBackColor = True
        '
        'FixedDischargeGageBox
        '
        Me.FixedDischargeGageBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.FixedDischargeGageBox, "FixedDischargeGageBox")
        Me.FixedDischargeGageBox.Controls.Add(Me.FixedDischargeGagePanel)
        Me.FixedDischargeGageBox.Controls.Add(Me.FixedDischargeControlPanel)
        Me.FixedDischargeGageBox.Name = "FixedDischargeGageBox"
        Me.FixedDischargeGageBox.TabStop = False
        '
        'FixedDischargeGagePanel
        '
        Me.FixedDischargeGagePanel.Controls.Add(Me.FixedDischargeThumbnailLabel)
        Me.FixedDischargeGagePanel.Controls.Add(Me.FixedDischargeGagePlot)
        resources.ApplyResources(Me.FixedDischargeGagePanel, "FixedDischargeGagePanel")
        Me.FixedDischargeGagePanel.Name = "FixedDischargeGagePanel"
        '
        'FixedDischargeThumbnailLabel
        '
        resources.ApplyResources(Me.FixedDischargeThumbnailLabel, "FixedDischargeThumbnailLabel")
        Me.FixedDischargeThumbnailLabel.Name = "FixedDischargeThumbnailLabel"
        '
        'FixedDischargeGagePlot
        '
        resources.ApplyResources(Me.FixedDischargeGagePlot, "FixedDischargeGagePlot")
        Me.FixedDischargeGagePlot.Name = "FixedDischargeGagePlot"
        Me.FixedDischargeGagePlot.TabStop = False
        '
        'FixedDischargeControlPanel
        '
        Me.FixedDischargeControlPanel.Controls.Add(Me.PrintDischargeGageButton)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeFirstLabelOffsetLabel)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeFirstLabelOffsetControl)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeDecimalsToShowLabel)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeDecimalsToShowControl)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeLabeledTickIntervalControl)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeLabeledTickIntervalLabel)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeLabelSizeFactorLabel)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeLabelSizeFactorUpDown)
        Me.FixedDischargeControlPanel.Controls.Add(Me.ViewDischargeGageButton)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeGageTypePanel)
        resources.ApplyResources(Me.FixedDischargeControlPanel, "FixedDischargeControlPanel")
        Me.FixedDischargeControlPanel.Name = "FixedDischargeControlPanel"
        '
        'PrintDischargeGageButton
        '
        Me.PrintDischargeGageButton.BackColor = System.Drawing.SystemColors.Control
        Me.PrintDischargeGageButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.PrintDischargeGageButton, "PrintDischargeGageButton")
        Me.PrintDischargeGageButton.Name = "PrintDischargeGageButton"
        Me.PrintDischargeGageButton.UseVisualStyleBackColor = False
        '
        'DischargeFirstLabelOffsetLabel
        '
        resources.ApplyResources(Me.DischargeFirstLabelOffsetLabel, "DischargeFirstLabelOffsetLabel")
        Me.DischargeFirstLabelOffsetLabel.Name = "DischargeFirstLabelOffsetLabel"
        '
        'DischargeFirstLabelOffsetControl
        '
        Me.DischargeFirstLabelOffsetControl.FormatStyle = "0"
        Me.DischargeFirstLabelOffsetControl.Label = ""
        resources.ApplyResources(Me.DischargeFirstLabelOffsetControl, "DischargeFirstLabelOffsetControl")
        Me.DischargeFirstLabelOffsetControl.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.DischargeFirstLabelOffsetControl.Minimum = New Decimal(New Integer() {9999, 0, 0, -2147483648})
        Me.DischargeFirstLabelOffsetControl.Name = "DischargeFirstLabelOffsetControl"
        Me.DischargeFirstLabelOffsetControl.SiValue = 0!
        Me.DischargeFirstLabelOffsetControl.UiValue = 0!
        Me.DischargeFirstLabelOffsetControl.UndoEnabled = True
        '
        'DischargeDecimalsToShowLabel
        '
        resources.ApplyResources(Me.DischargeDecimalsToShowLabel, "DischargeDecimalsToShowLabel")
        Me.DischargeDecimalsToShowLabel.Name = "DischargeDecimalsToShowLabel"
        '
        'DischargeDecimalsToShowControl
        '
        Me.DischargeDecimalsToShowControl.FormatStyle = "0"
        Me.DischargeDecimalsToShowControl.Label = ""
        resources.ApplyResources(Me.DischargeDecimalsToShowControl, "DischargeDecimalsToShowControl")
        Me.DischargeDecimalsToShowControl.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.DischargeDecimalsToShowControl.Name = "DischargeDecimalsToShowControl"
        Me.DischargeDecimalsToShowControl.SiValue = 0!
        Me.DischargeDecimalsToShowControl.UiValue = 0!
        Me.DischargeDecimalsToShowControl.UndoEnabled = True
        '
        'DischargeLabeledTickIntervalControl
        '
        Me.DischargeLabeledTickIntervalControl.BackColor = System.Drawing.SystemColors.Window
        Me.DischargeLabeledTickIntervalControl.DefaultValue = 0
        Me.DischargeLabeledTickIntervalControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.DischargeLabeledTickIntervalControl, "DischargeLabeledTickIntervalControl")
        Me.DischargeLabeledTickIntervalControl.FormattingEnabled = True
        Me.DischargeLabeledTickIntervalControl.Items.AddRange(New Object() {resources.GetString("DischargeLabeledTickIntervalControl.Items"), resources.GetString("DischargeLabeledTickIntervalControl.Items1"), resources.GetString("DischargeLabeledTickIntervalControl.Items2"), resources.GetString("DischargeLabeledTickIntervalControl.Items3"), resources.GetString("DischargeLabeledTickIntervalControl.Items4")})
        Me.DischargeLabeledTickIntervalControl.Name = "DischargeLabeledTickIntervalControl"
        Me.DischargeLabeledTickIntervalControl.UndoEnabled = True
        Me.DischargeLabeledTickIntervalControl.Value = -1
        '
        'DischargeLabeledTickIntervalLabel
        '
        resources.ApplyResources(Me.DischargeLabeledTickIntervalLabel, "DischargeLabeledTickIntervalLabel")
        Me.DischargeLabeledTickIntervalLabel.Name = "DischargeLabeledTickIntervalLabel"
        '
        'DischargeLabelSizeFactorLabel
        '
        resources.ApplyResources(Me.DischargeLabelSizeFactorLabel, "DischargeLabelSizeFactorLabel")
        Me.DischargeLabelSizeFactorLabel.Name = "DischargeLabelSizeFactorLabel"
        '
        'DischargeLabelSizeFactorUpDown
        '
        Me.DischargeLabelSizeFactorUpDown.DecimalPlaces = 2
        Me.DischargeLabelSizeFactorUpDown.FormatStyle = "0.0###"
        Me.DischargeLabelSizeFactorUpDown.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.DischargeLabelSizeFactorUpDown.Label = ""
        resources.ApplyResources(Me.DischargeLabelSizeFactorUpDown, "DischargeLabelSizeFactorUpDown")
        Me.DischargeLabelSizeFactorUpDown.Maximum = New Decimal(New Integer() {205, 0, 0, 131072})
        Me.DischargeLabelSizeFactorUpDown.Minimum = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.DischargeLabelSizeFactorUpDown.Name = "DischargeLabelSizeFactorUpDown"
        Me.DischargeLabelSizeFactorUpDown.SiValue = 0.05!
        Me.DischargeLabelSizeFactorUpDown.UiValue = 0.05!
        Me.DischargeLabelSizeFactorUpDown.UndoEnabled = True
        Me.DischargeLabelSizeFactorUpDown.Value = New Decimal(New Integer() {5, 0, 0, 131072})
        '
        'ViewDischargeGageButton
        '
        Me.ViewDischargeGageButton.BackColor = System.Drawing.SystemColors.Control
        Me.ViewDischargeGageButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.ViewDischargeGageButton, "ViewDischargeGageButton")
        Me.ViewDischargeGageButton.Name = "ViewDischargeGageButton"
        Me.ViewDischargeGageButton.UseVisualStyleBackColor = False
        '
        'DischargeGageTypePanel
        '
        Me.DischargeGageTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DischargeGageTypePanel.Controls.Add(Me.VerticalDischargeGageButton)
        Me.DischargeGageTypePanel.Controls.Add(Me.SlopedDischargeGageButton)
        resources.ApplyResources(Me.DischargeGageTypePanel, "DischargeGageTypePanel")
        Me.DischargeGageTypePanel.Name = "DischargeGageTypePanel"
        '
        'VerticalDischargeGageButton
        '
        resources.ApplyResources(Me.VerticalDischargeGageButton, "VerticalDischargeGageButton")
        Me.VerticalDischargeGageButton.Label = ""
        Me.VerticalDischargeGageButton.Name = "VerticalDischargeGageButton"
        Me.VerticalDischargeGageButton.RbValue = -1
        Me.VerticalDischargeGageButton.TabStop = True
        Me.VerticalDischargeGageButton.UiValue = -1
        Me.VerticalDischargeGageButton.UseVisualStyleBackColor = True
        '
        'SlopedDischargeGageButton
        '
        resources.ApplyResources(Me.SlopedDischargeGageButton, "SlopedDischargeGageButton")
        Me.SlopedDischargeGageButton.Label = ""
        Me.SlopedDischargeGageButton.Name = "SlopedDischargeGageButton"
        Me.SlopedDischargeGageButton.RbValue = -1
        Me.SlopedDischargeGageButton.TabStop = True
        Me.SlopedDischargeGageButton.UiValue = -1
        Me.SlopedDischargeGageButton.UseVisualStyleBackColor = True
        '
        'GageTypeGroup
        '
        Me.GageTypeGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GageTypeGroup.Controls.Add(Me.FixedHeadButton)
        Me.GageTypeGroup.Controls.Add(Me.FixedDischargeButton)
        resources.ApplyResources(Me.GageTypeGroup, "GageTypeGroup")
        Me.GageTypeGroup.Name = "GageTypeGroup"
        Me.GageTypeGroup.TabStop = False
        '
        'FixedHeadButton
        '
        resources.ApplyResources(Me.FixedHeadButton, "FixedHeadButton")
        Me.FixedHeadButton.Label = ""
        Me.FixedHeadButton.Name = "FixedHeadButton"
        Me.FixedHeadButton.RbValue = -1
        Me.FixedHeadButton.TabStop = True
        Me.FixedHeadButton.UiValue = -1
        Me.FixedHeadButton.UseVisualStyleBackColor = True
        '
        'FixedDischargeButton
        '
        resources.ApplyResources(Me.FixedDischargeButton, "FixedDischargeButton")
        Me.FixedDischargeButton.Label = ""
        Me.FixedDischargeButton.Name = "FixedDischargeButton"
        Me.FixedDischargeButton.RbValue = -1
        Me.FixedDischargeButton.TabStop = True
        Me.FixedDischargeButton.UiValue = -1
        Me.FixedDischargeButton.UseVisualStyleBackColor = True
        '
        'DischargeGageSlopeLabel
        '
        resources.ApplyResources(Me.DischargeGageSlopeLabel, "DischargeGageSlopeLabel")
        Me.DischargeGageSlopeLabel.Name = "DischargeGageSlopeLabel"
        '
        'DischargeGageRatioLabel
        '
        resources.ApplyResources(Me.DischargeGageRatioLabel, "DischargeGageRatioLabel")
        Me.DischargeGageRatioLabel.Name = "DischargeGageRatioLabel"
        '
        'DischargeGageSlopeSingle
        '
        resources.ApplyResources(Me.DischargeGageSlopeSingle, "DischargeGageSlopeSingle")
        Me.DischargeGageSlopeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DischargeGageSlopeSingle.FormatStyle = "0.0###"
        Me.DischargeGageSlopeSingle.IsReadOnly = False
        Me.DischargeGageSlopeSingle.Label = ""
        Me.DischargeGageSlopeSingle.Name = "DischargeGageSlopeSingle"
        Me.DischargeGageSlopeSingle.ReadOnlyMsgBox = Nothing
        Me.DischargeGageSlopeSingle.SiDefaultValue = 0!
        Me.DischargeGageSlopeSingle.SiMin = -1.401298E-45!
        Me.DischargeGageSlopeSingle.SiUnits = ""
        Me.DischargeGageSlopeSingle.SiValue = 0!
        Me.DischargeGageSlopeSingle.UndoEnabled = True
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.GageTypeGroup)
        Me.ControlPanel.Controls.Add(Me.DischargeControlPanel)
        Me.ControlPanel.Controls.Add(Me.HeadControlPanel)
        resources.ApplyResources(Me.ControlPanel, "ControlPanel")
        Me.ControlPanel.Name = "ControlPanel"
        '
        'DischargeControlPanel
        '
        Me.DischargeControlPanel.Controls.Add(Me.DischargeGageSlopeSingle)
        Me.DischargeControlPanel.Controls.Add(Me.DischargeOptionsBox)
        Me.DischargeControlPanel.Controls.Add(Me.DischargeReferenceGroup)
        Me.DischargeControlPanel.Controls.Add(Me.DischargeGageRatioLabel)
        Me.DischargeControlPanel.Controls.Add(Me.DischargeGageSlopeLabel)
        resources.ApplyResources(Me.DischargeControlPanel, "DischargeControlPanel")
        Me.DischargeControlPanel.Name = "DischargeControlPanel"
        '
        'DischargeOptionsBox
        '
        Me.DischargeOptionsBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.DischargeOptionsBox, "DischargeOptionsBox")
        Me.DischargeOptionsBox.Controls.Add(Me.DischargeSmartRangeButton)
        Me.DischargeOptionsBox.Controls.Add(Me.DischargeIncrementSingle)
        Me.DischargeOptionsBox.Controls.Add(Me.DischargeIncrementLabel)
        Me.DischargeOptionsBox.Controls.Add(Me.MaximumDischargeSingle)
        Me.DischargeOptionsBox.Controls.Add(Me.MaximumDischargeLabel)
        Me.DischargeOptionsBox.Controls.Add(Me.MinimumDischargeSingle)
        Me.DischargeOptionsBox.Controls.Add(Me.MinimumDischargeLabel)
        Me.DischargeOptionsBox.Name = "DischargeOptionsBox"
        Me.DischargeOptionsBox.TabStop = False
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
        'DischargeReferenceGroup
        '
        Me.DischargeReferenceGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DischargeReferenceGroup.Controls.Add(Me.DischargeUpstreamChannellBottomButton)
        Me.DischargeReferenceGroup.Controls.Add(Me.DischargeSillReferencedButton)
        resources.ApplyResources(Me.DischargeReferenceGroup, "DischargeReferenceGroup")
        Me.DischargeReferenceGroup.Name = "DischargeReferenceGroup"
        Me.DischargeReferenceGroup.TabStop = False
        '
        'DischargeUpstreamChannellBottomButton
        '
        resources.ApplyResources(Me.DischargeUpstreamChannellBottomButton, "DischargeUpstreamChannellBottomButton")
        Me.DischargeUpstreamChannellBottomButton.Label = ""
        Me.DischargeUpstreamChannellBottomButton.Name = "DischargeUpstreamChannellBottomButton"
        Me.DischargeUpstreamChannellBottomButton.RbValue = -1
        Me.DischargeUpstreamChannellBottomButton.TabStop = True
        Me.DischargeUpstreamChannellBottomButton.UiValue = -1
        Me.DischargeUpstreamChannellBottomButton.UseVisualStyleBackColor = True
        '
        'DischargeSillReferencedButton
        '
        resources.ApplyResources(Me.DischargeSillReferencedButton, "DischargeSillReferencedButton")
        Me.DischargeSillReferencedButton.Label = ""
        Me.DischargeSillReferencedButton.Name = "DischargeSillReferencedButton"
        Me.DischargeSillReferencedButton.RbValue = -1
        Me.DischargeSillReferencedButton.TabStop = True
        Me.DischargeSillReferencedButton.UiValue = -1
        Me.DischargeSillReferencedButton.UseVisualStyleBackColor = True
        '
        'HeadControlPanel
        '
        Me.HeadControlPanel.Controls.Add(Me.HeadGageSlopeSingle)
        Me.HeadControlPanel.Controls.Add(Me.GageRatioLabel)
        Me.HeadControlPanel.Controls.Add(Me.GageSlopeLabel)
        Me.HeadControlPanel.Controls.Add(Me.GageReferenceGroup)
        Me.HeadControlPanel.Controls.Add(Me.HeadOptionsBox)
        resources.ApplyResources(Me.HeadControlPanel, "HeadControlPanel")
        Me.HeadControlPanel.Name = "HeadControlPanel"
        '
        'HeadGageSlopeSingle
        '
        resources.ApplyResources(Me.HeadGageSlopeSingle, "HeadGageSlopeSingle")
        Me.HeadGageSlopeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HeadGageSlopeSingle.FormatStyle = "0.0###"
        Me.HeadGageSlopeSingle.IsReadOnly = False
        Me.HeadGageSlopeSingle.Label = ""
        Me.HeadGageSlopeSingle.Name = "HeadGageSlopeSingle"
        Me.HeadGageSlopeSingle.ReadOnlyMsgBox = Nothing
        Me.HeadGageSlopeSingle.SiDefaultValue = 0!
        Me.HeadGageSlopeSingle.SiMin = -1.401298E-45!
        Me.HeadGageSlopeSingle.SiUnits = ""
        Me.HeadGageSlopeSingle.SiValue = 0!
        Me.HeadGageSlopeSingle.UndoEnabled = True
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
        Me.GageReferenceGroup.Controls.Add(Me.HeadUpstreamChannellBottomButton)
        Me.GageReferenceGroup.Controls.Add(Me.HeadSillReferencedButton)
        resources.ApplyResources(Me.GageReferenceGroup, "GageReferenceGroup")
        Me.GageReferenceGroup.Name = "GageReferenceGroup"
        Me.GageReferenceGroup.TabStop = False
        '
        'HeadUpstreamChannellBottomButton
        '
        resources.ApplyResources(Me.HeadUpstreamChannellBottomButton, "HeadUpstreamChannellBottomButton")
        Me.HeadUpstreamChannellBottomButton.Label = ""
        Me.HeadUpstreamChannellBottomButton.Name = "HeadUpstreamChannellBottomButton"
        Me.HeadUpstreamChannellBottomButton.RbValue = -1
        Me.HeadUpstreamChannellBottomButton.TabStop = True
        Me.HeadUpstreamChannellBottomButton.UiValue = -1
        Me.HeadUpstreamChannellBottomButton.UseVisualStyleBackColor = True
        '
        'HeadSillReferencedButton
        '
        resources.ApplyResources(Me.HeadSillReferencedButton, "HeadSillReferencedButton")
        Me.HeadSillReferencedButton.Label = ""
        Me.HeadSillReferencedButton.Name = "HeadSillReferencedButton"
        Me.HeadSillReferencedButton.RbValue = -1
        Me.HeadSillReferencedButton.TabStop = True
        Me.HeadSillReferencedButton.UiValue = -1
        Me.HeadSillReferencedButton.UseVisualStyleBackColor = True
        '
        'HeadOptionsBox
        '
        Me.HeadOptionsBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.HeadOptionsBox, "HeadOptionsBox")
        Me.HeadOptionsBox.Controls.Add(Me.HeadSmartRangeButton)
        Me.HeadOptionsBox.Controls.Add(Me.HeadIncrementSingle)
        Me.HeadOptionsBox.Controls.Add(Me.HeadIncrementLabel)
        Me.HeadOptionsBox.Controls.Add(Me.MaximumHeadSingle)
        Me.HeadOptionsBox.Controls.Add(Me.MaximumHeadLabel)
        Me.HeadOptionsBox.Controls.Add(Me.MinimumHeadSingle)
        Me.HeadOptionsBox.Controls.Add(Me.MinimumHeadLabel)
        Me.HeadOptionsBox.Name = "HeadOptionsBox"
        Me.HeadOptionsBox.TabStop = False
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
        Me.HeadIncrementSingle.IsReadOnly = False
        Me.HeadIncrementSingle.Label = ""
        Me.HeadIncrementSingle.Name = "HeadIncrementSingle"
        Me.HeadIncrementSingle.ReadOnlyMsgBox = Nothing
        Me.HeadIncrementSingle.SiDefaultValue = 0!
        Me.HeadIncrementSingle.SiMin = -1.401298E-45!
        Me.HeadIncrementSingle.SiUnits = ""
        Me.HeadIncrementSingle.SiValue = 0!
        Me.HeadIncrementSingle.UndoEnabled = True
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
        Me.MaximumHeadSingle.IsReadOnly = False
        Me.MaximumHeadSingle.Label = ""
        Me.MaximumHeadSingle.Name = "MaximumHeadSingle"
        Me.MaximumHeadSingle.ReadOnlyMsgBox = Nothing
        Me.MaximumHeadSingle.SiDefaultValue = 0!
        Me.MaximumHeadSingle.SiMin = -1.401298E-45!
        Me.MaximumHeadSingle.SiUnits = ""
        Me.MaximumHeadSingle.SiValue = 0!
        Me.MaximumHeadSingle.UndoEnabled = True
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
        Me.MinimumHeadSingle.IsReadOnly = False
        Me.MinimumHeadSingle.Label = ""
        Me.MinimumHeadSingle.Name = "MinimumHeadSingle"
        Me.MinimumHeadSingle.ReadOnlyMsgBox = Nothing
        Me.MinimumHeadSingle.SiDefaultValue = 0!
        Me.MinimumHeadSingle.SiMin = -1.401298E-45!
        Me.MinimumHeadSingle.SiUnits = ""
        Me.MinimumHeadSingle.SiValue = 0!
        Me.MinimumHeadSingle.UndoEnabled = True
        '
        'MinimumHeadLabel
        '
        resources.ApplyResources(Me.MinimumHeadLabel, "MinimumHeadLabel")
        Me.MinimumHeadLabel.Name = "MinimumHeadLabel"
        '
        'GageViewPanel
        '
        Me.GageViewPanel.Controls.Add(Me.GageViewGroup)
        resources.ApplyResources(Me.GageViewPanel, "GageViewPanel")
        Me.GageViewPanel.Name = "GageViewPanel"
        '
        'GageViewGroup
        '
        Me.GageViewGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GageViewGroup.Controls.Add(Me.GagePlotViewButton)
        Me.GageViewGroup.Controls.Add(Me.DataTableViewButton)
        resources.ApplyResources(Me.GageViewGroup, "GageViewGroup")
        Me.GageViewGroup.Name = "GageViewGroup"
        Me.GageViewGroup.TabStop = False
        '
        'GagePlotViewButton
        '
        resources.ApplyResources(Me.GagePlotViewButton, "GagePlotViewButton")
        Me.GagePlotViewButton.Label = ""
        Me.GagePlotViewButton.Name = "GagePlotViewButton"
        Me.GagePlotViewButton.RbValue = -1
        Me.GagePlotViewButton.TabStop = True
        Me.GagePlotViewButton.UiValue = -1
        Me.GagePlotViewButton.UseVisualStyleBackColor = True
        '
        'DataTableViewButton
        '
        resources.ApplyResources(Me.DataTableViewButton, "DataTableViewButton")
        Me.DataTableViewButton.Label = ""
        Me.DataTableViewButton.Name = "DataTableViewButton"
        Me.DataTableViewButton.RbValue = -1
        Me.DataTableViewButton.TabStop = True
        Me.DataTableViewButton.UiValue = -1
        Me.DataTableViewButton.UseVisualStyleBackColor = True
        '
        'PrintWallGageDialog
        '
        Me.PrintWallGageDialog.UseEXDialog = True
        '
        'PrintWallGageDocument
        '
        '
        'WallGageControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.WallGagePanel)
        Me.Controls.Add(Me.GageViewPanel)
        Me.Controls.Add(Me.ControlPanel)
        Me.Name = "WallGageControl"
        Me.WallGagePanel.ResumeLayout(False)
        Me.HeadSplitContainer.Panel1.ResumeLayout(False)
        Me.HeadSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.HeadSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeadSplitContainer.ResumeLayout(False)
        Me.FixedHeadDataBox.ResumeLayout(False)
        CType(Me.FixedHeadIntervalTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DischargeSplitContainer.Panel1.ResumeLayout(False)
        Me.DischargeSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.DischargeSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DischargeSplitContainer.ResumeLayout(False)
        Me.FixedDischargeDataBox.ResumeLayout(False)
        CType(Me.FixedDischargeIntervalTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FixedHeadGageBox.ResumeLayout(False)
        Me.FixedHeadPlotPanel.ResumeLayout(False)
        Me.FixedHeadGagePanel.ResumeLayout(False)
        CType(Me.FixedHeadGagePlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FixedHeadControlPanel.ResumeLayout(False)
        Me.FixedHeadControlPanel.PerformLayout()
        CType(Me.HeadFirstLabelOffsetControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LabelsTypePanel.ResumeLayout(False)
        Me.LabelsTypePanel.PerformLayout()
        CType(Me.HeadDecimalsToShowControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeadLabelSizeFactorUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeadGageTypePanel.ResumeLayout(False)
        Me.HeadGageTypePanel.PerformLayout()
        Me.FixedDischargeGageBox.ResumeLayout(False)
        Me.FixedDischargeGagePanel.ResumeLayout(False)
        CType(Me.FixedDischargeGagePlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FixedDischargeControlPanel.ResumeLayout(False)
        Me.FixedDischargeControlPanel.PerformLayout()
        CType(Me.DischargeFirstLabelOffsetControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DischargeDecimalsToShowControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DischargeLabelSizeFactorUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DischargeGageTypePanel.ResumeLayout(False)
        Me.DischargeGageTypePanel.PerformLayout()
        Me.GageTypeGroup.ResumeLayout(False)
        Me.GageTypeGroup.PerformLayout()
        Me.ControlPanel.ResumeLayout(False)
        Me.DischargeControlPanel.ResumeLayout(False)
        Me.DischargeControlPanel.PerformLayout()
        Me.DischargeOptionsBox.ResumeLayout(False)
        Me.DischargeOptionsBox.PerformLayout()
        Me.DischargeReferenceGroup.ResumeLayout(False)
        Me.DischargeReferenceGroup.PerformLayout()
        Me.HeadControlPanel.ResumeLayout(False)
        Me.HeadControlPanel.PerformLayout()
        Me.GageReferenceGroup.ResumeLayout(False)
        Me.GageReferenceGroup.PerformLayout()
        Me.HeadOptionsBox.ResumeLayout(False)
        Me.HeadOptionsBox.PerformLayout()
        Me.GageViewPanel.ResumeLayout(False)
        Me.GageViewGroup.ResumeLayout(False)
        Me.GageViewGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GageTypeGroup As ctl_GroupBox
    Friend WithEvents FixedHeadButton As ctl_RadioButton
    Friend WithEvents FixedDischargeButton As ctl_RadioButton
    Friend WithEvents DischargeGageSlopeLabel As ctl_Label
    Friend WithEvents DischargeGageRatioLabel As ctl_Label
    Friend WithEvents DischargeGageSlopeSingle As ctl_SingleUnits
    Friend WithEvents ControlPanel As ctl_Panel
    Friend WithEvents DischargeOptionsBox As ctl_GroupBox
    Friend WithEvents DischargeSmartRangeButton As ctl_Button
    Friend WithEvents DischargeIncrementSingle As ctl_SingleUnits
    Friend WithEvents DischargeIncrementLabel As ctl_Label
    Friend WithEvents MaximumDischargeSingle As ctl_SingleUnits
    Friend WithEvents MaximumDischargeLabel As ctl_Label
    Friend WithEvents MinimumDischargeSingle As ctl_SingleUnits
    Friend WithEvents MinimumDischargeLabel As ctl_Label
    Friend WithEvents DischargeReferenceGroup As ctl_GroupBox
    Friend WithEvents DischargeUpstreamChannellBottomButton As ctl_RadioButton
    Friend WithEvents DischargeSillReferencedButton As ctl_RadioButton
    Friend WithEvents DischargeControlPanel As ctl_Panel
    Friend WithEvents HeadControlPanel As ctl_Panel
    Friend WithEvents HeadOptionsBox As ctl_GroupBox
    Friend WithEvents HeadSmartRangeButton As ctl_Button
    Friend WithEvents HeadIncrementSingle As ctl_SingleUnits
    Friend WithEvents HeadIncrementLabel As ctl_Label
    Friend WithEvents MaximumHeadSingle As ctl_SingleUnits
    Friend WithEvents MaximumHeadLabel As ctl_Label
    Friend WithEvents MinimumHeadSingle As ctl_SingleUnits
    Friend WithEvents MinimumHeadLabel As ctl_Label
    Friend WithEvents GageReferenceGroup As ctl_GroupBox
    Friend WithEvents HeadUpstreamChannellBottomButton As ctl_RadioButton
    Friend WithEvents HeadSillReferencedButton As ctl_RadioButton
    Friend WithEvents HeadGageSlopeSingle As ctl_SingleUnits
    Friend WithEvents GageRatioLabel As ctl_Label
    Friend WithEvents GageSlopeLabel As ctl_Label
    Friend WithEvents GageViewPanel As ctl_Panel
    Friend WithEvents GageViewGroup As ctl_GroupBox
    Friend WithEvents GagePlotViewButton As ctl_RadioButton
    Friend WithEvents DataTableViewButton As ctl_RadioButton
    Friend WithEvents WallGagePanel As ctl_Panel
    Friend WithEvents FixedDischargeGageBox As ctl_GroupBox
    Friend WithEvents FixedDischargeGagePanel As ctl_Panel
    Friend WithEvents FixedDischargeThumbnailLabel As ctl_Label
    Friend WithEvents FixedDischargeGagePlot As ctl_Canvas2D
    Friend WithEvents FixedDischargeControlPanel As ctl_Panel
    Friend WithEvents DischargeFirstLabelOffsetLabel As ctl_Label
    Friend WithEvents DischargeFirstLabelOffsetControl As ctl_SingleUpDown
    Friend WithEvents DischargeDecimalsToShowLabel As ctl_Label
    Friend WithEvents DischargeDecimalsToShowControl As ctl_SingleUpDown
    Friend WithEvents DischargeLabeledTickIntervalControl As ctl_ComboBox
    Friend WithEvents DischargeLabeledTickIntervalLabel As ctl_Label
    Friend WithEvents DischargeLabelSizeFactorLabel As ctl_Label
    Friend WithEvents DischargeLabelSizeFactorUpDown As ctl_SingleUpDown
    Friend WithEvents ViewDischargeGageButton As ctl_Button
    Friend WithEvents DischargeGageTypePanel As ctl_Panel
    Friend WithEvents VerticalDischargeGageButton As ctl_RadioButton
    Friend WithEvents SlopedDischargeGageButton As ctl_RadioButton
    Friend WithEvents FixedHeadGageBox As ctl_GroupBox
    Friend WithEvents FixedHeadPlotPanel As ctl_Panel
    Friend WithEvents FixedHeadGagePanel As ctl_Panel
    Friend WithEvents FixedHeadThumbnailLabel As ctl_Label
    Friend WithEvents FixedHeadGagePlot As ctl_Canvas2D
    Friend WithEvents FixedHeadControlPanel As ctl_Panel
    Friend WithEvents HeadFirstLabelOffsetLabel As ctl_Label
    Friend WithEvents HeadFirstLabelOffsetControl As ctl_SingleUpDown
    Friend WithEvents LabelsTypePanel As ctl_Panel
    Friend WithEvents FlowLabelsButton As ctl_RadioButton
    Friend WithEvents HeadLabelsButton As ctl_RadioButton
    Friend WithEvents HeadDecimalsToShowLabel As ctl_Label
    Friend WithEvents HeadDecimalsToShowControl As ctl_SingleUpDown
    Friend WithEvents HeadLabeledTickIntervalControl As ctl_ComboBox
    Friend WithEvents HeadLabeledTickIntervalLabel As ctl_Label
    Friend WithEvents HeadLabelSizeFactorLabel As ctl_Label
    Friend WithEvents HeadLabelSizeFactorUpDown As ctl_SingleUpDown
    Friend WithEvents ViewHeadGageButton As ctl_Button
    Friend WithEvents HeadGageTypePanel As ctl_Panel
    Friend WithEvents VerticalHeadGageButton As ctl_RadioButton
    Friend WithEvents SlopedHeadGageButton As ctl_RadioButton
    Friend WithEvents DischargeSplitContainer As SplitContainer
    Friend WithEvents HeadSplitContainer As SplitContainer
    Friend WithEvents FixedHeadDataBox As ctl_GroupBox
    Friend WithEvents FixedHeadIntervalTable As ctl_DataGridView
    Friend WithEvents FhiHead As DataGridViewTextBoxColumn
    Friend WithEvents FhiDistance As DataGridViewTextBoxColumn
    Friend WithEvents FhiDischarge As DataGridViewTextBoxColumn
    Friend WithEvents HeadStatusPanel As ctl_StatusPanel
    Friend WithEvents FixedDischargeDataBox As ctl_GroupBox
    Friend WithEvents FixedDischargeIntervalTable As ctl_DataGridView
    Friend WithEvents FdiDischarge As DataGridViewTextBoxColumn
    Friend WithEvents FdiHead As DataGridViewTextBoxColumn
    Friend WithEvents FdiDistance As DataGridViewTextBoxColumn
    Friend WithEvents DischargeStatusPanel As ctl_StatusPanel
    Friend WithEvents PrintHeadGageButton As ctl_Button
    Friend WithEvents PrintDischargeGageButton As ctl_Button
    Friend WithEvents PrintWallGageDialog As PrintDialog
    Friend WithEvents PrintWallGageDocument As Printing.PrintDocument
End Class
