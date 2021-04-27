
'**********************************************************************************************
' Data Comparer - Form for comparing data across WinSRFR's analyses & simulations.
'
Imports Microsoft.Win32 'For Registry Access

Imports GraphingUI

Public Class DataComparer
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal mWinSRFR As WinSRFR)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeDataComparer(mWinSRFR)

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents ToolbarImageList As System.Windows.Forms.ImageList
    Friend WithEvents DataSelectionPanel As DataStore.ctl_Panel
    Friend WithEvents DataDisplayPanel As DataStore.ctl_Panel
    Friend WithEvents DataTypePanel As DataStore.ctl_Panel
    Friend WithEvents DataExplorer As WinMain.DataExplorer
    Friend WithEvents DataTypeGroup As DataStore.ctl_GroupBox
    Friend WithEvents ComparisonsControl As WinMain.ctl_Comparisons
    Friend WithEvents EditMenu As System.Windows.Forms.MenuItem
    Friend WithEvents EditCopyBitmapItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents EditUnitsItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.MenuItem
    Friend WithEvents FileCloseItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents FilePrintItem As System.Windows.Forms.MenuItem
    Friend WithEvents FilePrintPreviewItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewMenu As System.Windows.Forms.MenuItem
    Friend WithEvents ViewResultsAsItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewPortraitPageItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewGraphsOnlyItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.MenuItem
    Friend WithEvents HelpAboutItem As System.Windows.Forms.MenuItem
    Friend WithEvents WhatsThisItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditClearAllItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents UpstreamInfiltration As DataStore.ctl_CheckParameter
    Friend WithEvents InflowRunoff As DataStore.ctl_CheckParameter
    Friend WithEvents Inflow As DataStore.ctl_CheckParameter
    Friend WithEvents InfiltrationFunction As DataStore.ctl_CheckParameter
    Friend WithEvents Infiltration As DataStore.ctl_CheckParameter
    Friend WithEvents AdvRec As DataStore.ctl_CheckParameter
    Friend WithEvents Advance As DataStore.ctl_CheckParameter
    Friend WithEvents PerformanceIndicators As DataStore.ctl_CheckParameter
    Friend WithEvents GoodnessOfFit As DataStore.ctl_CheckParameter
    Friend WithEvents ErosionBox As DataStore.ctl_GroupBox
    Friend WithEvents ErosionG As System.Windows.Forms.CheckBox
    Friend WithEvents ErosionCGm As System.Windows.Forms.CheckBox
    Friend WithEvents ErosionCGv As System.Windows.Forms.CheckBox
    Friend WithEvents CurveNoLabel As System.Windows.Forms.Label
    Friend WithEvents CurveNo As System.Windows.Forms.NumericUpDown
    Friend WithEvents WhatsThisHelpButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents VsAdvance As DataStore.ctl_CheckParameter
    Friend WithEvents VolumeBalance As DataStore.ctl_CheckParameter
    Friend WithEvents ViewRefreshItem As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataComparer))
        Me.MainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.FileMenu = New System.Windows.Forms.MenuItem()
        Me.FileCloseItem = New System.Windows.Forms.MenuItem()
        Me.FileSeparator1 = New System.Windows.Forms.MenuItem()
        Me.FilePrintItem = New System.Windows.Forms.MenuItem()
        Me.FilePrintPreviewItem = New System.Windows.Forms.MenuItem()
        Me.EditMenu = New System.Windows.Forms.MenuItem()
        Me.EditClearAllItem = New System.Windows.Forms.MenuItem()
        Me.EditSeparator1 = New System.Windows.Forms.MenuItem()
        Me.EditCopyBitmapItem = New System.Windows.Forms.MenuItem()
        Me.EditSeparator2 = New System.Windows.Forms.MenuItem()
        Me.EditUnitsItem = New System.Windows.Forms.MenuItem()
        Me.ViewMenu = New System.Windows.Forms.MenuItem()
        Me.ViewResultsAsItem = New System.Windows.Forms.MenuItem()
        Me.ViewPortraitPageItem = New System.Windows.Forms.MenuItem()
        Me.ViewGraphsOnlyItem = New System.Windows.Forms.MenuItem()
        Me.ViewRefreshItem = New System.Windows.Forms.MenuItem()
        Me.HelpMenu = New System.Windows.Forms.MenuItem()
        Me.WhatsThisItem = New System.Windows.Forms.MenuItem()
        Me.HelpAboutItem = New System.Windows.Forms.MenuItem()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.WhatsThisHelpButton = New System.Windows.Forms.ToolBarButton()
        Me.ToolbarImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.DataSelectionPanel = New DataStore.ctl_Panel()
        Me.DataExplorer = New WinMain.DataExplorer()
        Me.DataTypePanel = New DataStore.ctl_Panel()
        Me.DataTypeGroup = New DataStore.ctl_GroupBox()
        Me.VsAdvance = New DataStore.ctl_CheckParameter()
        Me.VolumeBalance = New DataStore.ctl_CheckParameter()
        Me.ErosionBox = New DataStore.ctl_GroupBox()
        Me.CurveNo = New System.Windows.Forms.NumericUpDown()
        Me.CurveNoLabel = New System.Windows.Forms.Label()
        Me.ErosionCGv = New System.Windows.Forms.CheckBox()
        Me.ErosionCGm = New System.Windows.Forms.CheckBox()
        Me.ErosionG = New System.Windows.Forms.CheckBox()
        Me.GoodnessOfFit = New DataStore.ctl_CheckParameter()
        Me.PerformanceIndicators = New DataStore.ctl_CheckParameter()
        Me.UpstreamInfiltration = New DataStore.ctl_CheckParameter()
        Me.InflowRunoff = New DataStore.ctl_CheckParameter()
        Me.Inflow = New DataStore.ctl_CheckParameter()
        Me.InfiltrationFunction = New DataStore.ctl_CheckParameter()
        Me.Infiltration = New DataStore.ctl_CheckParameter()
        Me.AdvRec = New DataStore.ctl_CheckParameter()
        Me.Advance = New DataStore.ctl_CheckParameter()
        Me.DataDisplayPanel = New DataStore.ctl_Panel()
        Me.ComparisonsControl = New WinMain.ctl_Comparisons()
        Me.DataSelectionPanel.SuspendLayout()
        Me.DataTypePanel.SuspendLayout()
        Me.DataTypeGroup.SuspendLayout()
        Me.ErosionBox.SuspendLayout()
        CType(Me.CurveNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DataDisplayPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileMenu, Me.EditMenu, Me.ViewMenu, Me.HelpMenu})
        '
        'FileMenu
        '
        Me.FileMenu.Index = 0
        Me.FileMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileCloseItem, Me.FileSeparator1, Me.FilePrintItem, Me.FilePrintPreviewItem})
        Me.FileMenu.Text = "&File"
        '
        'FileCloseItem
        '
        Me.FileCloseItem.Index = 0
        Me.FileCloseItem.Text = "&Close"
        '
        'FileSeparator1
        '
        Me.FileSeparator1.Index = 1
        Me.FileSeparator1.Text = "-"
        '
        'FilePrintItem
        '
        Me.FilePrintItem.Index = 2
        Me.FilePrintItem.Text = "&Print Comparisons ..."
        '
        'FilePrintPreviewItem
        '
        Me.FilePrintPreviewItem.Index = 3
        Me.FilePrintPreviewItem.Text = "Print Pre&view Comparisons ..."
        '
        'EditMenu
        '
        Me.EditMenu.Index = 1
        Me.EditMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.EditClearAllItem, Me.EditSeparator1, Me.EditCopyBitmapItem, Me.EditSeparator2, Me.EditUnitsItem})
        Me.EditMenu.Text = "&Edit"
        '
        'EditClearAllItem
        '
        Me.EditClearAllItem.Index = 0
        Me.EditClearAllItem.Text = "Clear &All Selections"
        '
        'EditSeparator1
        '
        Me.EditSeparator1.Index = 1
        Me.EditSeparator1.Text = "-"
        '
        'EditCopyBitmapItem
        '
        Me.EditCopyBitmapItem.Index = 2
        Me.EditCopyBitmapItem.Text = "&Copy Bitmap"
        '
        'EditSeparator2
        '
        Me.EditSeparator2.Index = 3
        Me.EditSeparator2.Text = "-"
        '
        'EditUnitsItem
        '
        Me.EditUnitsItem.Index = 4
        Me.EditUnitsItem.Text = "&Units ..."
        '
        'ViewMenu
        '
        Me.ViewMenu.Index = 2
        Me.ViewMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ViewResultsAsItem, Me.ViewRefreshItem})
        Me.ViewMenu.Text = "&View"
        '
        'ViewResultsAsItem
        '
        Me.ViewResultsAsItem.Index = 0
        Me.ViewResultsAsItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ViewPortraitPageItem, Me.ViewGraphsOnlyItem})
        Me.ViewResultsAsItem.Text = "&Results as"
        '
        'ViewPortraitPageItem
        '
        Me.ViewPortraitPageItem.Index = 0
        Me.ViewPortraitPageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.ViewPortraitPageItem.Text = "&Portrait Page"
        '
        'ViewGraphsOnlyItem
        '
        Me.ViewGraphsOnlyItem.Index = 1
        Me.ViewGraphsOnlyItem.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.ViewGraphsOnlyItem.Text = "&Graphs Only"
        '
        'ViewRefreshItem
        '
        Me.ViewRefreshItem.Index = 1
        Me.ViewRefreshItem.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.ViewRefreshItem.Text = "Re&fresh"
        '
        'HelpMenu
        '
        Me.HelpMenu.Index = 3
        Me.HelpMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.WhatsThisItem, Me.HelpAboutItem})
        Me.HelpMenu.Text = "&Help"
        '
        'WhatsThisItem
        '
        Me.WhatsThisItem.Index = 0
        Me.WhatsThisItem.Text = "&What's This?"
        '
        'HelpAboutItem
        '
        Me.HelpAboutItem.Index = 1
        Me.HelpAboutItem.Text = "&About Data Comparison"
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.WhatsThisHelpButton})
        Me.ToolBar.ButtonSize = New System.Drawing.Size(23, 22)
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.ImageList = Me.ToolbarImageList
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(784, 28)
        Me.ToolBar.TabIndex = 0
        '
        'WhatsThisHelpButton
        '
        Me.WhatsThisHelpButton.ImageIndex = 0
        Me.WhatsThisHelpButton.Name = "WhatsThisHelpButton"
        Me.WhatsThisHelpButton.ToolTipText = "What's This Help"
        '
        'ToolbarImageList
        '
        Me.ToolbarImageList.ImageStream = CType(resources.GetObject("ToolbarImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ToolbarImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ToolbarImageList.Images.SetKeyName(0, "WhatsThis.ico")
        '
        'DataSelectionPanel
        '
        Me.DataSelectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataSelectionPanel.Controls.Add(Me.DataExplorer)
        Me.DataSelectionPanel.Controls.Add(Me.DataTypePanel)
        Me.DataSelectionPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataSelectionPanel.Location = New System.Drawing.Point(0, 28)
        Me.DataSelectionPanel.Name = "DataSelectionPanel"
        Me.DataSelectionPanel.Size = New System.Drawing.Size(370, 473)
        Me.DataSelectionPanel.TabIndex = 1
        '
        'DataExplorer
        '
        Me.DataExplorer.AccessibleDescription = "Selects the Analyses and Simulations for comparison."
        Me.DataExplorer.AccessibleName = "Data Explorer"
        Me.DataExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataExplorer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataExplorer.Location = New System.Drawing.Point(0, 184)
        Me.DataExplorer.Name = "DataExplorer"
        Me.DataExplorer.Size = New System.Drawing.Size(368, 287)
        Me.DataExplorer.Subtitle = "Select One"
        Me.DataExplorer.TabIndex = 2
        Me.DataExplorer.TitleBackColor = System.Drawing.SystemColors.Info
        Me.DataExplorer.TitleForeColor = System.Drawing.SystemColors.InfoText
        '
        'DataTypePanel
        '
        Me.DataTypePanel.AccessibleDescription = "Selects the data type to display for comparisons."
        Me.DataTypePanel.AccessibleName = "Data Type Selection"
        Me.DataTypePanel.Controls.Add(Me.DataTypeGroup)
        Me.DataTypePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataTypePanel.Location = New System.Drawing.Point(0, 0)
        Me.DataTypePanel.Name = "DataTypePanel"
        Me.DataTypePanel.Size = New System.Drawing.Size(368, 184)
        Me.DataTypePanel.TabIndex = 1
        '
        'DataTypeGroup
        '
        Me.DataTypeGroup.Controls.Add(Me.VsAdvance)
        Me.DataTypeGroup.Controls.Add(Me.VolumeBalance)
        Me.DataTypeGroup.Controls.Add(Me.ErosionBox)
        Me.DataTypeGroup.Controls.Add(Me.GoodnessOfFit)
        Me.DataTypeGroup.Controls.Add(Me.PerformanceIndicators)
        Me.DataTypeGroup.Controls.Add(Me.UpstreamInfiltration)
        Me.DataTypeGroup.Controls.Add(Me.InflowRunoff)
        Me.DataTypeGroup.Controls.Add(Me.Inflow)
        Me.DataTypeGroup.Controls.Add(Me.InfiltrationFunction)
        Me.DataTypeGroup.Controls.Add(Me.Infiltration)
        Me.DataTypeGroup.Controls.Add(Me.AdvRec)
        Me.DataTypeGroup.Controls.Add(Me.Advance)
        Me.DataTypeGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataTypeGroup.Location = New System.Drawing.Point(4, 4)
        Me.DataTypeGroup.Name = "DataTypeGroup"
        Me.DataTypeGroup.Size = New System.Drawing.Size(359, 178)
        Me.DataTypeGroup.TabIndex = 0
        Me.DataTypeGroup.TabStop = False
        Me.DataTypeGroup.Text = "Select &Type of Data to Compare"
        '
        'VsAdvance
        '
        Me.VsAdvance.AlwaysChecked = False
        Me.VsAdvance.AutoSize = True
        Me.VsAdvance.Checked = True
        Me.VsAdvance.CheckState = System.Windows.Forms.CheckState.Checked
        Me.VsAdvance.ErrorMessage = Nothing
        Me.VsAdvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VsAdvance.Location = New System.Drawing.Point(165, 80)
        Me.VsAdvance.Name = "VsAdvance"
        Me.VsAdvance.Size = New System.Drawing.Size(106, 21)
        Me.VsAdvance.TabIndex = 10
        Me.VsAdvance.Text = "Vs. Advance"
        Me.VsAdvance.UncheckAttemptMessage = Nothing
        '
        'VolumeBalance
        '
        Me.VolumeBalance.AlwaysChecked = False
        Me.VolumeBalance.AutoSize = True
        Me.VolumeBalance.Checked = True
        Me.VolumeBalance.CheckState = System.Windows.Forms.CheckState.Checked
        Me.VolumeBalance.ErrorMessage = Nothing
        Me.VolumeBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolumeBalance.Location = New System.Drawing.Point(150, 63)
        Me.VolumeBalance.Name = "VolumeBalance"
        Me.VolumeBalance.Size = New System.Drawing.Size(194, 21)
        Me.VolumeBalance.TabIndex = 9
        Me.VolumeBalance.Text = "Volume Balance Infiltration"
        Me.VolumeBalance.UncheckAttemptMessage = Nothing
        '
        'ErosionBox
        '
        Me.ErosionBox.Controls.Add(Me.CurveNo)
        Me.ErosionBox.Controls.Add(Me.CurveNoLabel)
        Me.ErosionBox.Controls.Add(Me.ErosionCGv)
        Me.ErosionBox.Controls.Add(Me.ErosionCGm)
        Me.ErosionBox.Controls.Add(Me.ErosionG)
        Me.ErosionBox.Location = New System.Drawing.Point(189, 106)
        Me.ErosionBox.Name = "ErosionBox"
        Me.ErosionBox.Size = New System.Drawing.Size(144, 70)
        Me.ErosionBox.TabIndex = 11
        Me.ErosionBox.TabStop = False
        Me.ErosionBox.Text = "Erosion"
        '
        'CurveNo
        '
        Me.CurveNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurveNo.Location = New System.Drawing.Point(85, 43)
        Me.CurveNo.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.CurveNo.Name = "CurveNo"
        Me.CurveNo.Size = New System.Drawing.Size(48, 23)
        Me.CurveNo.TabIndex = 4
        Me.CurveNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CurveNo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CurveNoLabel
        '
        Me.CurveNoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurveNoLabel.Location = New System.Drawing.Point(85, 27)
        Me.CurveNoLabel.Name = "CurveNoLabel"
        Me.CurveNoLabel.Size = New System.Drawing.Size(56, 23)
        Me.CurveNoLabel.TabIndex = 3
        Me.CurveNoLabel.Text = "Curve #"
        '
        'ErosionCGv
        '
        Me.ErosionCGv.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErosionCGv.Location = New System.Drawing.Point(13, 51)
        Me.ErosionCGv.Name = "ErosionCGv"
        Me.ErosionCGv.Size = New System.Drawing.Size(56, 24)
        Me.ErosionCGv.TabIndex = 2
        Me.ErosionCGv.Text = "CGv"
        '
        'ErosionCGm
        '
        Me.ErosionCGm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErosionCGm.Location = New System.Drawing.Point(13, 35)
        Me.ErosionCGm.Name = "ErosionCGm"
        Me.ErosionCGm.Size = New System.Drawing.Size(56, 24)
        Me.ErosionCGm.TabIndex = 1
        Me.ErosionCGm.Text = "CGm"
        '
        'ErosionG
        '
        Me.ErosionG.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErosionG.Location = New System.Drawing.Point(13, 18)
        Me.ErosionG.Name = "ErosionG"
        Me.ErosionG.Size = New System.Drawing.Size(32, 24)
        Me.ErosionG.TabIndex = 0
        Me.ErosionG.Text = "G"
        '
        'GoodnessOfFit
        '
        Me.GoodnessOfFit.AlwaysChecked = False
        Me.GoodnessOfFit.AutoSize = True
        Me.GoodnessOfFit.ErrorMessage = Nothing
        Me.GoodnessOfFit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GoodnessOfFit.Location = New System.Drawing.Point(150, 38)
        Me.GoodnessOfFit.Name = "GoodnessOfFit"
        Me.GoodnessOfFit.Size = New System.Drawing.Size(130, 21)
        Me.GoodnessOfFit.TabIndex = 8
        Me.GoodnessOfFit.Text = "Goodness Of Fit"
        Me.GoodnessOfFit.UncheckAttemptMessage = Nothing
        '
        'PerformanceIndicators
        '
        Me.PerformanceIndicators.AlwaysChecked = False
        Me.PerformanceIndicators.AutoSize = True
        Me.PerformanceIndicators.Checked = True
        Me.PerformanceIndicators.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PerformanceIndicators.ErrorMessage = Nothing
        Me.PerformanceIndicators.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PerformanceIndicators.Location = New System.Drawing.Point(150, 20)
        Me.PerformanceIndicators.Name = "PerformanceIndicators"
        Me.PerformanceIndicators.Size = New System.Drawing.Size(173, 21)
        Me.PerformanceIndicators.TabIndex = 7
        Me.PerformanceIndicators.Text = "Performance Indicators"
        Me.PerformanceIndicators.UncheckAttemptMessage = Nothing
        '
        'UpstreamInfiltration
        '
        Me.UpstreamInfiltration.AlwaysChecked = False
        Me.UpstreamInfiltration.Checked = True
        Me.UpstreamInfiltration.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UpstreamInfiltration.ErrorMessage = Nothing
        Me.UpstreamInfiltration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpstreamInfiltration.Location = New System.Drawing.Point(12, 152)
        Me.UpstreamInfiltration.Name = "UpstreamInfiltration"
        Me.UpstreamInfiltration.Size = New System.Drawing.Size(170, 24)
        Me.UpstreamInfiltration.TabIndex = 6
        Me.UpstreamInfiltration.Text = "Upstream Infiltration"
        Me.UpstreamInfiltration.UncheckAttemptMessage = Nothing
        '
        'InflowRunoff
        '
        Me.InflowRunoff.AlwaysChecked = False
        Me.InflowRunoff.Checked = True
        Me.InflowRunoff.CheckState = System.Windows.Forms.CheckState.Checked
        Me.InflowRunoff.ErrorMessage = Nothing
        Me.InflowRunoff.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRunoff.Location = New System.Drawing.Point(24, 37)
        Me.InflowRunoff.Name = "InflowRunoff"
        Me.InflowRunoff.Size = New System.Drawing.Size(120, 24)
        Me.InflowRunoff.TabIndex = 1
        Me.InflowRunoff.Text = "&& Runoff"
        Me.InflowRunoff.UncheckAttemptMessage = Nothing
        '
        'Inflow
        '
        Me.Inflow.AlwaysChecked = False
        Me.Inflow.Checked = True
        Me.Inflow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Inflow.ErrorMessage = Nothing
        Me.Inflow.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Inflow.Location = New System.Drawing.Point(12, 20)
        Me.Inflow.Name = "Inflow"
        Me.Inflow.Size = New System.Drawing.Size(133, 24)
        Me.Inflow.TabIndex = 0
        Me.Inflow.Text = "Inflow"
        Me.Inflow.UncheckAttemptMessage = Nothing
        '
        'InfiltrationFunction
        '
        Me.InfiltrationFunction.AlwaysChecked = False
        Me.InfiltrationFunction.Checked = True
        Me.InfiltrationFunction.CheckState = System.Windows.Forms.CheckState.Checked
        Me.InfiltrationFunction.ErrorMessage = Nothing
        Me.InfiltrationFunction.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationFunction.Location = New System.Drawing.Point(12, 133)
        Me.InfiltrationFunction.Name = "InfiltrationFunction"
        Me.InfiltrationFunction.Size = New System.Drawing.Size(170, 24)
        Me.InfiltrationFunction.TabIndex = 5
        Me.InfiltrationFunction.Text = "Infiltration Function"
        Me.InfiltrationFunction.UncheckAttemptMessage = Nothing
        '
        'Infiltration
        '
        Me.Infiltration.AlwaysChecked = False
        Me.Infiltration.Checked = True
        Me.Infiltration.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Infiltration.ErrorMessage = Nothing
        Me.Infiltration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Infiltration.Location = New System.Drawing.Point(12, 114)
        Me.Infiltration.Name = "Infiltration"
        Me.Infiltration.Size = New System.Drawing.Size(170, 24)
        Me.Infiltration.TabIndex = 4
        Me.Infiltration.Text = "Infiltration"
        Me.Infiltration.UncheckAttemptMessage = Nothing
        '
        'AdvRec
        '
        Me.AdvRec.AlwaysChecked = False
        Me.AdvRec.Checked = True
        Me.AdvRec.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AdvRec.ErrorMessage = Nothing
        Me.AdvRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvRec.Location = New System.Drawing.Point(24, 80)
        Me.AdvRec.Name = "AdvRec"
        Me.AdvRec.Size = New System.Drawing.Size(120, 24)
        Me.AdvRec.TabIndex = 3
        Me.AdvRec.Text = "&& Recession"
        Me.AdvRec.UncheckAttemptMessage = Nothing
        '
        'Advance
        '
        Me.Advance.AlwaysChecked = False
        Me.Advance.Checked = True
        Me.Advance.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Advance.ErrorMessage = Nothing
        Me.Advance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Advance.Location = New System.Drawing.Point(12, 63)
        Me.Advance.Name = "Advance"
        Me.Advance.Size = New System.Drawing.Size(133, 24)
        Me.Advance.TabIndex = 2
        Me.Advance.Text = "Advance"
        Me.Advance.UncheckAttemptMessage = Nothing
        '
        'DataDisplayPanel
        '
        Me.DataDisplayPanel.Controls.Add(Me.ComparisonsControl)
        Me.DataDisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataDisplayPanel.Location = New System.Drawing.Point(370, 28)
        Me.DataDisplayPanel.Name = "DataDisplayPanel"
        Me.DataDisplayPanel.Size = New System.Drawing.Size(414, 473)
        Me.DataDisplayPanel.TabIndex = 2
        '
        'ComparisonsControl
        '
        Me.ComparisonsControl.AccessibleDescription = "Tab pages displaying the comparisons graphs."
        Me.ComparisonsControl.AccessibleName = "Comparison Graphs"
        Me.ComparisonsControl.DataComparisonType = WinMain.Globals.DataComparisonTypes.AllDataComparisonTypes
        Me.ComparisonsControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComparisonsControl.ErosionCurveNo = 1
        Me.ComparisonsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComparisonsControl.Location = New System.Drawing.Point(0, 0)
        Me.ComparisonsControl.Multiline = True
        Me.ComparisonsControl.Name = "ComparisonsControl"
        Me.ComparisonsControl.ResultsView = WinMain.Globals.ResultsViews.PortraitPage
        Me.ComparisonsControl.SelectedIndex = 0
        Me.ComparisonsControl.Size = New System.Drawing.Size(414, 473)
        Me.ComparisonsControl.TabIndex = 0
        '
        'DataComparer
        '
        Me.AccessibleDescription = "Graphically displays results from multiple Analyses & Simulations for comparison." &
    ""
        Me.AccessibleName = "WinSRFR Data Comparison"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(784, 501)
        Me.Controls.Add(Me.DataDisplayPanel)
        Me.Controls.Add(Me.DataSelectionPanel)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.Menu = Me.MainMenu
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.Name = "DataComparer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Comparison"
        Me.DataSelectionPanel.ResumeLayout(False)
        Me.DataTypePanel.ResumeLayout(False)
        Me.DataTypeGroup.ResumeLayout(False)
        Me.DataTypeGroup.PerformLayout()
        Me.ErosionBox.ResumeLayout(False)
        CType(Me.CurveNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DataDisplayPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Member Data "

    Private mWinSRFR As WinSRFR
    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' Windows messages redefined from WinUser.h
    '
    Private Const HTCLIENT As Integer = &H1
    Private Const HTCAPTION As Integer = &H2
    Private Const WM_WINDOWPOSCHANGING As Integer = &H46
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1

    Private Const WM_MOUSEMOVE As Integer = &H200
    Private Const WM_LBUTTONDOWN As Integer = &H201
    Private Const WM_LBUTTONUP As Integer = &H202
    Private Const WM_LBUTTONDBLCLK As Integer = &H203
    Private Const WM_RBUTTONDOWN As Integer = &H204
    Private Const WM_RBUTTONUP As Integer = &H205
    Private Const WM_RBUTTONDBLCLK As Integer = &H206
    Private Const WM_MBUTTONDOWN As Integer = &H207
    Private Const WM_MBUTTONUP As Integer = &H208
    Private Const WM_MBUTTONDBLCLK As Integer = &H209
    '
    ' UI support
    '
    Private mWhatsThisHelp As Boolean = False
    Private mInitializing As Boolean = True

#End Region

#Region " Properties "

    Public Const sDataTypeSelections As String = "DataTypeSelections"
    Private ReadOnly Property SelectedDataTypes() As Integer
        Get
            Dim _dataTypes As Integer = 0

            If (AdvRec.Checked) Then
                _dataTypes += DataComparisonTypes.AdvanceRecessionGraph
            ElseIf (Advance.Checked) Then
                _dataTypes += DataComparisonTypes.AdvanceGraph
            End If

            If (InflowRunoff.Checked) Then
                _dataTypes += DataComparisonTypes.InflowRunoffGraph
            ElseIf (Inflow.Checked) Then
                _dataTypes += DataComparisonTypes.InflowGraph
            End If

            If (Infiltration.Checked) Then
                _dataTypes += DataComparisonTypes.InfiltrationGraph
            End If

            If (InfiltrationFunction.Checked) Then
                _dataTypes += DataComparisonTypes.InfiltrationFunctionGraph
            End If

            If (UpstreamInfiltration.Checked) Then
                _dataTypes += DataComparisonTypes.UpstreamInfiltrationGraph
            End If

            If (PerformanceIndicators.Checked) Then
                _dataTypes += DataComparisonTypes.PerformanceIndicators
            End If

            If (GoodnessOfFit.Checked) Then
                _dataTypes += DataComparisonTypes.GoodnessOfFit
            End If

            If (VolumeBalance.Checked) Then
                _dataTypes += DataComparisonTypes.VolumeBalance
            End If

            If (VsAdvance.Checked) Then
                _dataTypes += DataComparisonTypes.VsAdvance
            End If

            If (ErosionG.Checked) Then
                _dataTypes += DataComparisonTypes.ErosionGGraph
            End If

            If (ErosionCGm.Checked) Then
                _dataTypes += DataComparisonTypes.ErosionCGmGraph
            End If

            If (ErosionCGv.Checked) Then
                _dataTypes += DataComparisonTypes.ErosionCGvGraph
            End If

            Return _dataTypes
        End Get
    End Property

    Public Const sErosionCurveNo As String = "ErosionCurveNo"
    Private mErosionCurveNo As Integer = 1
    Public Property ErosionCurveNo() As Integer
        Get
            Return mErosionCurveNo
        End Get
        Set(ByVal Value As Integer)
            mErosionCurveNo = Value
        End Set
    End Property

    Private mResultsView As ResultsViews = Globals.ResultsViews.GraphsOnly
    Private Property DataResultsView() As ResultsViews
        Get
            Return mResultsView
        End Get
        Set(ByVal Value As ResultsViews)
            mResultsView = Value
        End Set
    End Property

#End Region

#Region " Initialization "

    Private Sub InitializeDataComparer(ByVal _winSRFR As WinSRFR)
        If (_winSRFR IsNot Nothing) Then
            mWinSRFR = _winSRFR
            mInitializing = True
            LoadComparisonParameters()
            mInitializing = False
        End If
    End Sub

    Public Sub ResetDataComparer()

        If Not (mWinSRFR Is Nothing) Then

            ' Data Explorer
            DataExplorer.InitializeDataExplorer(mWinSRFR)
            DataExplorer.ResetDataExplorer()

            ' Comparison Control
            ComparisonsControl.LinkToModel(mWinSRFR, SelectedDataTypes, DataResultsView)

            Dim _farm As Farm = mWinSRFR.GetFirstFarm
            While Not (_farm Is Nothing)
                Dim _field As Field = _farm.GetFirstField
                While Not (_field Is Nothing)
                    Dim _world As World = _field.GetFirstWorld
                    While Not (_world Is Nothing)
                        Dim _analysis As Unit = _world.GetFirstAnalysis
                        While Not (_analysis Is Nothing)
                            If (_analysis.BeingCompared) Then
                                If (ComparisonsControl.AddUnit(_analysis)) Then
                                    DataExplorer.SetCheckedState(_analysis)
                                Else
                                    DataExplorer.ClearCheckedState(_analysis)
                                End If
                            End If
                            _analysis = _world.GetNextAnalysis
                        End While
                        _world = _field.GetNextWorld
                    End While
                    _field = _farm.GetNextField
                End While
                _farm = mWinSRFR.GetNextFarm
            End While

            ' DataComparer (Me)
            UpdateUI()
        Else
            Debug.Assert(False, "WinSRFR is Nothing")
        End If

    End Sub

    Private Sub ResetComparisonTabPages()
        If (mWinSRFR IsNot Nothing) Then
            ComparisonsControl.ResetTabPages(SelectedDataTypes, mErosionCurveNo)
        End If
    End Sub

#End Region

#Region " Methods "

#Region " UI Methods "

    Private Sub UpdateUI()
        Me.Text = mDictionary.ControlText(Me)
        DataExplorer.Subtitle = mDictionary.tSelectOneOrMore.Translated

        Me.ErosionBox.Visible = False
    End Sub

#End Region

#Region " Registry Methods "

    Private Sub LoadComparisonParameters()

        ' Read Data Comparison Parameters in the Registry
        Try
            ' Open the Current User / Software key
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Read tab selections & update UI to match
                            Dim types As DataComparisonTypes = CInt(_regKey.GetValue(sDataTypeSelections, DataComparisonTypes.AllDataComparisonTypes))

                            If ((types And DataComparisonTypes.AdvanceGraph) = DataComparisonTypes.AdvanceGraph) Then
                                Me.Advance.Checked = True
                            Else
                                Me.Advance.Checked = False
                            End If

                            If ((types And DataComparisonTypes.AdvanceRecessionGraph) = DataComparisonTypes.AdvanceRecessionGraph) Then
                                Me.AdvRec.Checked = True
                                Me.Advance.Checked = True
                            Else
                                Me.AdvRec.Checked = False
                            End If

                            If ((types And DataComparisonTypes.ErosionCGmGraph) = DataComparisonTypes.ErosionCGmGraph) Then
                                Me.ErosionCGm.Checked = True
                            Else
                                Me.ErosionCGm.Checked = False
                            End If

                            If ((types And DataComparisonTypes.ErosionCGvGraph) = DataComparisonTypes.ErosionCGvGraph) Then
                                Me.ErosionCGv.Checked = True
                            Else
                                Me.ErosionCGv.Checked = False
                            End If

                            If ((types And DataComparisonTypes.ErosionGGraph) = DataComparisonTypes.ErosionGGraph) Then
                                Me.ErosionG.Checked = True
                            Else
                                Me.ErosionG.Checked = False
                            End If

                            If ((types And DataComparisonTypes.GoodnessOfFit) = DataComparisonTypes.GoodnessOfFit) Then
                                Me.GoodnessOfFit.Checked = True
                            Else
                                Me.GoodnessOfFit.Checked = False
                            End If

                            If ((types And DataComparisonTypes.VolumeBalance) = DataComparisonTypes.VolumeBalance) Then
                                Me.VolumeBalance.Checked = True
                            Else
                                Me.VolumeBalance.Checked = False
                            End If

                            If ((types And DataComparisonTypes.VsAdvance) = DataComparisonTypes.VsAdvance) Then
                                Me.VsAdvance.Checked = True
                                Me.VolumeBalance.Checked = True
                            Else
                                Me.VsAdvance.Checked = False
                            End If

                            If ((types And DataComparisonTypes.InfiltrationFunctionGraph) = DataComparisonTypes.InfiltrationFunctionGraph) Then
                                Me.InfiltrationFunction.Checked = True
                            Else
                                Me.InfiltrationFunction.Checked = False
                            End If

                            If ((types And DataComparisonTypes.InfiltrationGraph) = DataComparisonTypes.InfiltrationGraph) Then
                                Me.Infiltration.Checked = True
                            Else
                                Me.Infiltration.Checked = False
                            End If

                            If ((types And DataComparisonTypes.InflowGraph) = DataComparisonTypes.InflowGraph) Then
                                Me.Inflow.Checked = True
                            Else
                                Me.Inflow.Checked = False
                            End If

                            If ((types And DataComparisonTypes.InflowRunoffGraph) = DataComparisonTypes.InflowRunoffGraph) Then
                                Me.InflowRunoff.Checked = True
                                Me.Inflow.Checked = True
                            Else
                                Me.InflowRunoff.Checked = False
                            End If

                            If ((types And DataComparisonTypes.PerformanceIndicators) = DataComparisonTypes.PerformanceIndicators) Then
                                Me.PerformanceIndicators.Checked = True
                            Else
                                Me.PerformanceIndicators.Checked = False
                            End If

                            If ((types And DataComparisonTypes.UpstreamInfiltrationGraph) = DataComparisonTypes.UpstreamInfiltrationGraph) Then
                                Me.UpstreamInfiltration.Checked = True
                            Else
                                Me.UpstreamInfiltration.Checked = False
                            End If

                            ' Read erosion curve number & update UI to match
                            mErosionCurveNo = CInt(_regKey.GetValue(sErosionCurveNo, 1))

                            Me.CurveNo.Value = mErosionCurveNo
                            Me.ComparisonsControl.ErosionCurveNo = mErosionCurveNo
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore errors
        End Try
    End Sub

    Private Sub SaveComparisonParameters()

        ' Save Data Comparison Parameters in the Registry
        Try
            ' Open the Current User / Software key
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Write tab selections
                            Dim _integer As Integer = SelectedDataTypes
                            _regKey.SetValue(sDataTypeSelections, _integer)

                            ' Write erosion curve number
                            _integer = ErosionCurveNo
                            _regKey.SetValue(sErosionCurveNo, _integer)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore errors
        End Try
    End Sub

#End Region

#End Region

#Region " Model Event Handlers "

    Public Sub CheckChanged(ByVal _analysis As Unit, ByVal _checked As Boolean) _
    Handles DataExplorer.CheckChanged
        If (_checked) Then
            If (ComparisonsControl.AddUnit(_analysis)) Then
                DataExplorer.SetCheckedState(_analysis)
                _analysis.BeingCompared = True
            Else
                DataExplorer.ClearCheckedState(_analysis)
                _analysis.BeingCompared = False
            End If
        Else
            ComparisonsControl.RemoveUnit(_analysis)
            _analysis.BeingCompared = False
        End If
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " File Menu "

    Private Sub FileCloseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileCloseItem.Click
        SaveComparisonParameters()
        Me.Close()
    End Sub

    Private Sub FilePrintItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FilePrintItem.Click
        ComparisonsControl.Print(sender, e, ComparisonsControl.ResultsView)
    End Sub

    Private Sub FilePrintPreviewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FilePrintPreviewItem.Click
        ComparisonsControl.PrintPreview(sender, e, ComparisonsControl.ResultsView)
    End Sub

    Private Sub DataComparer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        SaveComparisonParameters()
    End Sub

#End Region

#Region " Edit Menu "

    Private Sub EditMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditMenu.Popup

        ' Build the 'Copy' items
        EditCopyBitmapItem.MenuItems.Clear()
        AddPictureBoxCopyItems(EditCopyBitmapItem, Me)

        If (0 < EditCopyBitmapItem.MenuItems.Count) Then
            EditCopyBitmapItem.Enabled = True
        Else
            EditCopyBitmapItem.Enabled = False
        End If

    End Sub

    Private Sub EditUnitsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditUnitsItem.Click
        Dim db As UnitsDialogBox = WinSRFR.UnitsDialogBox
        If (db.Visible) Then
            db.BringToFront()
        Else
            db.Show()
        End If
    End Sub
    '
    ' Clear All Selections
    '
    Private Sub EditClearAllItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditClearAllItem.Click

        ' Clear all the selected items
        DataExplorer.ClearAllSelections()
        ComparisonsControl.RemoveAllUnits()

        ' Reset all BeingCompared flags
        Dim _farm As Farm = mWinSRFR.GetFirstFarm
        While Not (_farm Is Nothing)
            Dim _field As Field = _farm.GetFirstField
            While Not (_field Is Nothing)
                Dim _world As World = _field.GetFirstWorld
                While Not (_world Is Nothing)
                    Dim _analysis As Unit = _world.GetFirstAnalysis
                    While Not (_analysis Is Nothing)
                        _analysis.BeingCompared = False
                        _analysis = _world.GetNextAnalysis
                    End While
                    _world = _field.GetNextWorld
                End While
                _field = _farm.GetNextField
            End While
            _farm = mWinSRFR.GetNextFarm
        End While

    End Sub

#End Region

#Region " View Menu "

    Private Sub ViewMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewMenu.Popup

        ViewGraphsOnlyItem.Checked = False
        ViewPortraitPageItem.Checked = False
        Select Case DataResultsView
            Case Globals.ResultsViews.GraphsOnly
                ViewGraphsOnlyItem.Checked = True
            Case Globals.ResultsViews.PortraitPage
                ViewPortraitPageItem.Checked = True
            Case Else
                Debug.Assert(False)
        End Select

    End Sub

    Private Sub ViewPortraitPageItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewPortraitPageItem.Click
        DataResultsView = Globals.ResultsViews.PortraitPage
        ComparisonsControl.ResultsView = DataResultsView
    End Sub

    Private Sub ViewGraphsOnlyItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewGraphsOnlyItem.Click
        DataResultsView = Globals.ResultsViews.GraphsOnly
        ComparisonsControl.ResultsView = DataResultsView
    End Sub

    Private Sub ViewRefreshItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewRefreshItem.Click
        Me.Refresh()
    End Sub

#End Region

#Region " Help Menu "

    Private Sub HelpAboutItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles HelpAboutItem.Click
        WinSRFR.ShowDialogPdfHelpManual("sec:DataComparison")
    End Sub

    Private Sub DataComparer_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:DataComparison")
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:DataComparison")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    '
    ' What's This help
    '
    Private Sub WhatsThisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WhatsThisItem.Click
        mWhatsThisHelp = True
        mWinSRFR.StartWhatsThisHelp(Me)
    End Sub
    '
    ' Stop What's This Help when window is de-activated
    '  Note - Mouse capture is lost when window is de-activated
    '
    Protected Overrides Sub OnDeactivate(ByVal e As EventArgs)
        ' If What's This Help is active; stop it
        If (mWhatsThisHelp) Then
            mWinSRFR.StopWhatsThisHelp(Me)
        End If
        ' Call base class method to continue Windows message processing
        MyBase.OnDeactivate(e)
    End Sub
    '
    ' WndProc() - override of WndProc for intercepting Windows messages
    '
    Protected Overrides Sub WndProc(ByRef m As Message)
        ' Intercept all Windows messages prior to system handling;
        '  Look for mouse button events of interest
        Select Case (m.Msg)

            Case WM_LBUTTONUP, WM_RBUTTONUP, WM_MBUTTONUP ' Button up message

                If (mWhatsThisHelp = True) Then
                    ' Process the What's This Help request
                    mWhatsThisHelp = mWinSRFR.WhatsThisHelp(m, Me)

                    If (mWhatsThisHelp) Then
                        mWinSRFR.PauseWhatsThisHelp(Me)
                    Else
                        mWinSRFR.StopWhatsThisHelp(Me)
                    End If

                    ' Absorb this event; don't let system process it
                    Return

                End If

        End Select

        ' Call base class method to continue Windows message processing
        MyBase.WndProc(m)
    End Sub

#End Region

#Region " Toolbar Buttons "

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) _
    Handles ToolBar.ButtonClick

        Select Case ToolBar.Buttons.IndexOf(e.Button)
            Case 0 ' What's This Help
                mWhatsThisHelp = True
                mWinSRFR.StartWhatsThisHelp(Me)

            Case Else
                Debug.Assert(False, "Invalid toolbar button")

        End Select
    End Sub

#End Region

#Region " Form Controls "

    Private Sub Advance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Advance.CheckedChanged
        If Not (mInitializing) Then
            If Not (Advance.Checked) Then
                ' When Advance clears; make sure Advance / Recession also clears
                If (AdvRec.Checked) Then
                    AdvRec.Checked = False
                    Return
                End If
            End If
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub AdvRec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AdvRec.CheckedChanged
        If Not (mInitializing) Then
            If (AdvRec.Checked) Then
                ' When Advance / Recession is checked; make sure Advanced is also checked
                If Not (Advance.Checked) Then
                    Advance.Checked = True
                    Return
                End If
            End If
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub Inflow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Inflow.CheckedChanged
        If Not (mInitializing) Then
            If Not (Inflow.Checked) Then
                ' When Inflow clears; make sure Inflow / Runoff also clears
                If (InflowRunoff.Checked) Then
                    InflowRunoff.Checked = False
                    Return
                End If
            End If
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub InflowRunoff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles InflowRunoff.CheckedChanged
        If Not (mInitializing) Then
            If (InflowRunoff.Checked) Then
                ' When Inflow / Runoff is checked; make sure Inflow is also checked
                If Not (Inflow.Checked) Then
                    Inflow.Checked = True
                    Return
                End If
            End If
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub Infiltration_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Infiltration.CheckedChanged
        If Not (mInitializing) Then
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub InfiltrationFunction_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles InfiltrationFunction.CheckedChanged
        If Not (mInitializing) Then
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub UpstreamInfiltration_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles UpstreamInfiltration.CheckedChanged
        If Not (mInitializing) Then
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub PerformanceIndicators_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PerformanceIndicators.CheckedChanged
        If Not (mInitializing) Then
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub GoodnessOfFit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GoodnessOfFit.CheckedChanged
        If Not (mInitializing) Then
            If (GoodnessOfFit.Checked) Then
                Dim msg As String = "Goodness Of Fit comparisons are made between pairs of Analyses." + ChrW(13) + ChrW(13) _
                                    + "Comparisons are made between the first selected Analysis and" + ChrW(13) _
                                    + "each successively selected Analysis." + ChrW(13) + ChrW(13) _
                                    + "WARNING:  Verification of the compatibility of the Analyses" + ChrW(13) _
                                    + "being compared is left to the user!"

                MsgBox(msg, MsgBoxStyle.Information, "Goodness Of Fit")
            End If

            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub VolumeBalance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles VolumeBalance.CheckedChanged
        If Not (mInitializing) Then
            If Not (VolumeBalance.Checked) Then
                ' When VolumeBalance clears; make sure Vs. Advance also clears
                If (VsAdvance.Checked) Then
                    VsAdvance.Checked = False
                    Return
                End If
            End If
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub VsAdvance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles VsAdvance.CheckedChanged
        If Not (mInitializing) Then
            If (VsAdvance.Checked) Then
                ' When Vs. Advance is checked; make sure VolumeBalance is also checked
                If Not (VolumeBalance.Checked) Then
                    VolumeBalance.Checked = True
                    Return
                End If
            End If
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub ErosionG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ErosionG.CheckedChanged
        If Not (mInitializing) Then
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub ErosionCGm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ErosionCGm.CheckedChanged
        If Not (mInitializing) Then
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub ErosionCGv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ErosionCGv.CheckedChanged
        If Not (mInitializing) Then
            ResetComparisonTabPages()
        End If
    End Sub

    Private Sub CurveNo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CurveNo.ValueChanged
        If Not (mInitializing) Then
            mErosionCurveNo = CurveNo.Value
            ResetComparisonTabPages()
        End If
    End Sub

#End Region

#End Region

End Class
