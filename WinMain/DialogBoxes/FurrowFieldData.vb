
'*************************************************************************************************************
' Furrow Field Data Dialog
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI
Imports Srfr

Public Class FurrowFieldData
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal _unit As Unit)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeFurrowFieldData(_unit)

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
    Friend WithEvents FurrowDataMenu As System.Windows.Forms.MainMenu
    Friend WithEvents FileMenu As System.Windows.Forms.MenuItem
    Friend WithEvents EditMenu As System.Windows.Forms.MenuItem
    Friend WithEvents FurrowDataPanel As DataStore.ctl_Panel
    Friend WithEvents ProfilometerBox As DataStore.ctl_GroupBox
    Friend WithEvents TopWidthLabel As System.Windows.Forms.Label
    Friend WithEvents MiddleWidthLabel As System.Windows.Forms.Label
    Friend WithEvents BottomWidthLabel As System.Windows.Forms.Label
    Friend WithEvents FurrowMeasurementLabel As DataStore.ctl_Label
    Friend WithEvents NumberOfRodsLabel As DataStore.ctl_Label
    Friend WithEvents RodSpacingLabel As System.Windows.Forms.Label
    Friend WithEvents NumberOfRodsControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents RodSpacingControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents TrapezoidBox As DataStore.ctl_GroupBox
    Friend WithEvents PowerLawBox As DataStore.ctl_GroupBox
    Friend WithEvents TrapezoidSideSlopeControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents TrapezoidBottomWidthControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents TrapezoidSideSlopeLabel As DataStore.ctl_Label
    Friend WithEvents TrapezoidBottomWidthLabel As System.Windows.Forms.Label
    Friend WithEvents TrapezoidArea As System.Windows.Forms.Label
    Friend WithEvents PowerLawMaximumDepthLabel As System.Windows.Forms.Label
    Friend WithEvents PowerLawExponentLabel As DataStore.ctl_Label
    Friend WithEvents PowerLawWidthAt100mmLabel As System.Windows.Forms.Label
    Friend WithEvents PowerLawArea As System.Windows.Forms.Label
    Friend WithEvents PowerLawMaximumDepthControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents PowerLawExponentControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents PowerLawWidth100mmControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents ProfilometerArea As System.Windows.Forms.Label
    Friend WithEvents CrossSectionArea As System.Windows.Forms.Label
    Friend WithEvents BottomWidthControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents MiddleWidthControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents TopWidthControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents FitToLabel As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents FurrowFieldDataTypeControl As DataStore.ctl_SelectParameter
    Friend WithEvents FurrowGraphics As GraphingUI.ex_PictureBox
    Friend WithEvents EditCopyBitmapItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditMenuPopupSeparator As System.Windows.Forms.MenuItem
    Friend WithEvents ProfilometerDataControl As DataStore.ctl_DataTableParameter
    Friend WithEvents FileMenuPopupSeparator As System.Windows.Forms.MenuItem
    Friend WithEvents FurrowShapeControl As DataStore.ctl_SelectParameter
    Friend WithEvents FurrowShapeLabel As DataStore.ctl_Label
    Friend WithEvents FileCloseItem As System.Windows.Forms.MenuItem
    Friend WithEvents ButtonSave As DataStore.ctl_Button
    Friend WithEvents FileSaveItem As System.Windows.Forms.MenuItem
    Friend WithEvents WidthTableBox As DataStore.ctl_GroupBox
    Friend WithEvents WidthTableArea As System.Windows.Forms.Label
    Friend WithEvents ButtonCancel As DataStore.ctl_Button
    Friend WithEvents DepthWidthBox As DataStore.ctl_GroupBox
    Friend WithEvents DepthWidthControl As DataStore.ctl_DataTableParameter
    Friend WithEvents SetTopMidBotButton As DataStore.ctl_Button
    Friend WithEvents MaxDepthControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents TrapezoidMaximumDepthControl As System.Windows.Forms.NumericUpDown
    Friend WithEvents TrapezoidMaximumDepthLabel As System.Windows.Forms.Label
    Friend WithEvents MaxDepthLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.FurrowDataMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.FileMenu = New System.Windows.Forms.MenuItem
        Me.FileSaveItem = New System.Windows.Forms.MenuItem
        Me.FileCloseItem = New System.Windows.Forms.MenuItem
        Me.FileMenuPopupSeparator = New System.Windows.Forms.MenuItem
        Me.EditMenu = New System.Windows.Forms.MenuItem
        Me.EditCopyBitmapItem = New System.Windows.Forms.MenuItem
        Me.EditMenuPopupSeparator = New System.Windows.Forms.MenuItem
        Me.FurrowDataPanel = New DataStore.ctl_Panel
        Me.ButtonCancel = New DataStore.ctl_Button
        Me.FurrowGraphics = New GraphingUI.ex_PictureBox
        Me.ButtonSave = New DataStore.ctl_Button
        Me.FitToLabel = New System.Windows.Forms.Label
        Me.FurrowShapeControl = New DataStore.ctl_SelectParameter
        Me.FurrowShapeLabel = New DataStore.ctl_Label
        Me.FurrowMeasurementLabel = New DataStore.ctl_Label
        Me.FurrowFieldDataTypeControl = New DataStore.ctl_SelectParameter
        Me.DepthWidthBox = New DataStore.ctl_GroupBox
        Me.SetTopMidBotButton = New DataStore.ctl_Button
        Me.WidthTableArea = New System.Windows.Forms.Label
        Me.DepthWidthControl = New DataStore.ctl_DataTableParameter
        Me.ProfilometerBox = New DataStore.ctl_GroupBox
        Me.ProfilometerArea = New System.Windows.Forms.Label
        Me.RodSpacingControl = New System.Windows.Forms.NumericUpDown
        Me.NumberOfRodsControl = New System.Windows.Forms.NumericUpDown
        Me.RodSpacingLabel = New System.Windows.Forms.Label
        Me.NumberOfRodsLabel = New DataStore.ctl_Label
        Me.ProfilometerDataControl = New DataStore.ctl_DataTableParameter
        Me.WidthTableBox = New DataStore.ctl_GroupBox
        Me.CrossSectionArea = New System.Windows.Forms.Label
        Me.MaxDepthControl = New System.Windows.Forms.NumericUpDown
        Me.BottomWidthControl = New System.Windows.Forms.NumericUpDown
        Me.MiddleWidthControl = New System.Windows.Forms.NumericUpDown
        Me.TopWidthControl = New System.Windows.Forms.NumericUpDown
        Me.MaxDepthLabel = New System.Windows.Forms.Label
        Me.BottomWidthLabel = New System.Windows.Forms.Label
        Me.MiddleWidthLabel = New System.Windows.Forms.Label
        Me.TopWidthLabel = New System.Windows.Forms.Label
        Me.PowerLawBox = New DataStore.ctl_GroupBox
        Me.PowerLawArea = New System.Windows.Forms.Label
        Me.PowerLawMaximumDepthControl = New System.Windows.Forms.NumericUpDown
        Me.PowerLawExponentControl = New System.Windows.Forms.NumericUpDown
        Me.PowerLawWidth100mmControl = New System.Windows.Forms.NumericUpDown
        Me.PowerLawMaximumDepthLabel = New System.Windows.Forms.Label
        Me.PowerLawExponentLabel = New DataStore.ctl_Label
        Me.PowerLawWidthAt100mmLabel = New System.Windows.Forms.Label
        Me.TrapezoidBox = New DataStore.ctl_GroupBox
        Me.TrapezoidArea = New System.Windows.Forms.Label
        Me.TrapezoidMaximumDepthControl = New System.Windows.Forms.NumericUpDown
        Me.TrapezoidSideSlopeControl = New System.Windows.Forms.NumericUpDown
        Me.TrapezoidBottomWidthControl = New System.Windows.Forms.NumericUpDown
        Me.TrapezoidMaximumDepthLabel = New System.Windows.Forms.Label
        Me.TrapezoidSideSlopeLabel = New DataStore.ctl_Label
        Me.TrapezoidBottomWidthLabel = New System.Windows.Forms.Label
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.FurrowDataPanel.SuspendLayout()
        CType(Me.FurrowGraphics, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DepthWidthBox.SuspendLayout()
        CType(Me.DepthWidthControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProfilometerBox.SuspendLayout()
        CType(Me.RodSpacingControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberOfRodsControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProfilometerDataControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WidthTableBox.SuspendLayout()
        CType(Me.MaxDepthControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomWidthControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MiddleWidthControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopWidthControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PowerLawBox.SuspendLayout()
        CType(Me.PowerLawMaximumDepthControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PowerLawExponentControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PowerLawWidth100mmControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TrapezoidBox.SuspendLayout()
        CType(Me.TrapezoidMaximumDepthControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrapezoidSideSlopeControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrapezoidBottomWidthControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FurrowDataMenu
        '
        Me.FurrowDataMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileMenu, Me.EditMenu})
        '
        'FileMenu
        '
        Me.FileMenu.Index = 0
        Me.FileMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileSaveItem, Me.FileCloseItem, Me.FileMenuPopupSeparator})
        Me.FileMenu.Text = "&File"
        '
        'FileSaveItem
        '
        Me.FileSaveItem.Index = 0
        Me.FileSaveItem.Text = "&Save Field Data && Close"
        '
        'FileCloseItem
        '
        Me.FileCloseItem.Index = 1
        Me.FileCloseItem.Text = "&Cancel && Close"
        '
        'FileMenuPopupSeparator
        '
        Me.FileMenuPopupSeparator.Index = 2
        Me.FileMenuPopupSeparator.Text = "-"
        '
        'EditMenu
        '
        Me.EditMenu.Index = 1
        Me.EditMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.EditCopyBitmapItem, Me.EditMenuPopupSeparator})
        Me.EditMenu.Text = "&Edit"
        '
        'EditCopyBitmapItem
        '
        Me.EditCopyBitmapItem.Index = 0
        Me.EditCopyBitmapItem.Text = "Copy &Bitmap"
        '
        'EditMenuPopupSeparator
        '
        Me.EditMenuPopupSeparator.Index = 1
        Me.EditMenuPopupSeparator.Text = "-"
        '
        'FurrowDataPanel
        '
        Me.FurrowDataPanel.Controls.Add(Me.ButtonCancel)
        Me.FurrowDataPanel.Controls.Add(Me.FurrowGraphics)
        Me.FurrowDataPanel.Controls.Add(Me.ButtonSave)
        Me.FurrowDataPanel.Controls.Add(Me.FitToLabel)
        Me.FurrowDataPanel.Controls.Add(Me.FurrowShapeControl)
        Me.FurrowDataPanel.Controls.Add(Me.FurrowShapeLabel)
        Me.FurrowDataPanel.Controls.Add(Me.FurrowMeasurementLabel)
        Me.FurrowDataPanel.Controls.Add(Me.FurrowFieldDataTypeControl)
        Me.FurrowDataPanel.Controls.Add(Me.DepthWidthBox)
        Me.FurrowDataPanel.Controls.Add(Me.ProfilometerBox)
        Me.FurrowDataPanel.Controls.Add(Me.WidthTableBox)
        Me.FurrowDataPanel.Controls.Add(Me.PowerLawBox)
        Me.FurrowDataPanel.Controls.Add(Me.TrapezoidBox)
        Me.FurrowDataPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FurrowDataPanel.Location = New System.Drawing.Point(0, 0)
        Me.FurrowDataPanel.Name = "FurrowDataPanel"
        Me.FurrowDataPanel.Size = New System.Drawing.Size(564, 455)
        Me.FurrowDataPanel.TabIndex = 0
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(8, 424)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(80, 24)
        Me.ButtonCancel.TabIndex = 14
        Me.ButtonCancel.Text = "&Cancel"
        '
        'FurrowGraphics
        '
        Me.FurrowGraphics.AccessibleDescription = "A copyable bitmap image"
        Me.FurrowGraphics.AccessibleName = "Bitmap Diagram"
        Me.FurrowGraphics.Location = New System.Drawing.Point(280, 64)
        Me.FurrowGraphics.Name = "FurrowGraphics"
        Me.FurrowGraphics.Size = New System.Drawing.Size(272, 216)
        Me.FurrowGraphics.TabIndex = 13
        Me.FurrowGraphics.TabStop = False
        Me.FurrowGraphics.Text = "Bitmap Diagram"
        '
        'ButtonSave
        '
        Me.ButtonSave.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonSave.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ButtonSave.Location = New System.Drawing.Point(272, 424)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(280, 24)
        Me.ButtonSave.TabIndex = 10
        Me.ButtonSave.Text = "&Save Data && Close"
        Me.ButtonSave.UseVisualStyleBackColor = False
        '
        'FitToLabel
        '
        Me.FitToLabel.Location = New System.Drawing.Point(224, 32)
        Me.FitToLabel.Name = "FitToLabel"
        Me.FitToLabel.Size = New System.Drawing.Size(112, 23)
        Me.FitToLabel.TabIndex = 12
        Me.FitToLabel.Text = "Fit To"
        Me.FitToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FurrowShapeControl
        '
        Me.FurrowShapeControl.ApplicationValue = -1
        Me.FurrowShapeControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FurrowShapeControl.EnableSaveActions = False
        Me.FurrowShapeControl.IsCalculated = False
        Me.FurrowShapeControl.Location = New System.Drawing.Point(336, 32)
        Me.FurrowShapeControl.Name = "FurrowShapeControl"
        Me.FurrowShapeControl.SelectedIndexSet = False
        Me.FurrowShapeControl.Size = New System.Drawing.Size(152, 24)
        Me.FurrowShapeControl.TabIndex = 6
        '
        'FurrowShapeLabel
        '
        Me.FurrowShapeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowShapeLabel.Location = New System.Drawing.Point(280, 8)
        Me.FurrowShapeLabel.Name = "FurrowShapeLabel"
        Me.FurrowShapeLabel.Size = New System.Drawing.Size(272, 23)
        Me.FurrowShapeLabel.TabIndex = 5
        Me.FurrowShapeLabel.Text = "Furrow S&hape"
        Me.FurrowShapeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FurrowMeasurementLabel
        '
        Me.FurrowMeasurementLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowMeasurementLabel.Location = New System.Drawing.Point(16, 8)
        Me.FurrowMeasurementLabel.Name = "FurrowMeasurementLabel"
        Me.FurrowMeasurementLabel.Size = New System.Drawing.Size(232, 23)
        Me.FurrowMeasurementLabel.TabIndex = 0
        Me.FurrowMeasurementLabel.Text = "Furrow C&ross Section Data"
        Me.FurrowMeasurementLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FurrowFieldDataTypeControl
        '
        Me.FurrowFieldDataTypeControl.ApplicationValue = -1
        Me.FurrowFieldDataTypeControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FurrowFieldDataTypeControl.EnableSaveActions = False
        Me.FurrowFieldDataTypeControl.IsCalculated = False
        Me.FurrowFieldDataTypeControl.Location = New System.Drawing.Point(40, 32)
        Me.FurrowFieldDataTypeControl.Name = "FurrowFieldDataTypeControl"
        Me.FurrowFieldDataTypeControl.SelectedIndexSet = False
        Me.FurrowFieldDataTypeControl.Size = New System.Drawing.Size(184, 24)
        Me.FurrowFieldDataTypeControl.TabIndex = 1
        '
        'DepthWidthBox
        '
        Me.DepthWidthBox.Controls.Add(Me.SetTopMidBotButton)
        Me.DepthWidthBox.Controls.Add(Me.WidthTableArea)
        Me.DepthWidthBox.Controls.Add(Me.DepthWidthControl)
        Me.DepthWidthBox.Location = New System.Drawing.Point(8, 64)
        Me.DepthWidthBox.Name = "DepthWidthBox"
        Me.DepthWidthBox.Size = New System.Drawing.Size(256, 352)
        Me.DepthWidthBox.TabIndex = 2
        Me.DepthWidthBox.TabStop = False
        Me.DepthWidthBox.Text = "Depth / Width Data"
        '
        'SetTopMidBotButton
        '
        Me.SetTopMidBotButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetTopMidBotButton.Location = New System.Drawing.Point(8, 24)
        Me.SetTopMidBotButton.Name = "SetTopMidBotButton"
        Me.SetTopMidBotButton.Size = New System.Drawing.Size(232, 23)
        Me.SetTopMidBotButton.TabIndex = 1
        Me.SetTopMidBotButton.Text = "Set Depths to &Top/Middle/Bottom"
        '
        'WidthTableArea
        '
        Me.WidthTableArea.Location = New System.Drawing.Point(16, 320)
        Me.WidthTableArea.Name = "WidthTableArea"
        Me.WidthTableArea.Size = New System.Drawing.Size(224, 24)
        Me.WidthTableArea.TabIndex = 10
        Me.WidthTableArea.Text = "Cross Section Area"
        Me.WidthTableArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DepthWidthControl
        '
        Me.DepthWidthControl.AllRowsFixed = False
        Me.DepthWidthControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.DepthWidthControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.DepthWidthControl.CaptionText = "Depth / Width Table"
        Me.DepthWidthControl.CausesValidation = False
        Me.DepthWidthControl.ColumnWidthRatios = Nothing
        Me.DepthWidthControl.DataMember = ""
        Me.DepthWidthControl.EnableSaveActions = False
        Me.DepthWidthControl.FirstColumnIncreases = False
        Me.DepthWidthControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.DepthWidthControl.FirstColumnMinimum = 0
        Me.DepthWidthControl.FirstRowFixed = False
        Me.DepthWidthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthWidthControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.DepthWidthControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DepthWidthControl.Location = New System.Drawing.Point(8, 56)
        Me.DepthWidthControl.MaxRows = 50
        Me.DepthWidthControl.MinRows = 0
        Me.DepthWidthControl.Name = "DepthWidthControl"
        Me.DepthWidthControl.PasteDisabled = False
        Me.DepthWidthControl.SecondColumnIncreases = False
        Me.DepthWidthControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.DepthWidthControl.SecondColumnMinimum = 0
        Me.DepthWidthControl.Size = New System.Drawing.Size(232, 256)
        Me.DepthWidthControl.TabIndex = 2
        Me.DepthWidthControl.TableReadonly = False
        '
        'ProfilometerBox
        '
        Me.ProfilometerBox.Controls.Add(Me.ProfilometerArea)
        Me.ProfilometerBox.Controls.Add(Me.RodSpacingControl)
        Me.ProfilometerBox.Controls.Add(Me.NumberOfRodsControl)
        Me.ProfilometerBox.Controls.Add(Me.RodSpacingLabel)
        Me.ProfilometerBox.Controls.Add(Me.NumberOfRodsLabel)
        Me.ProfilometerBox.Controls.Add(Me.ProfilometerDataControl)
        Me.ProfilometerBox.Location = New System.Drawing.Point(8, 64)
        Me.ProfilometerBox.Name = "ProfilometerBox"
        Me.ProfilometerBox.Size = New System.Drawing.Size(256, 352)
        Me.ProfilometerBox.TabIndex = 2
        Me.ProfilometerBox.TabStop = False
        Me.ProfilometerBox.Text = "Profilometer Data"
        '
        'ProfilometerArea
        '
        Me.ProfilometerArea.Location = New System.Drawing.Point(16, 320)
        Me.ProfilometerArea.Name = "ProfilometerArea"
        Me.ProfilometerArea.Size = New System.Drawing.Size(224, 24)
        Me.ProfilometerArea.TabIndex = 10
        Me.ProfilometerArea.Text = "Cross Section Area"
        Me.ProfilometerArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RodSpacingControl
        '
        Me.RodSpacingControl.Location = New System.Drawing.Point(168, 48)
        Me.RodSpacingControl.Name = "RodSpacingControl"
        Me.RodSpacingControl.Size = New System.Drawing.Size(64, 23)
        Me.RodSpacingControl.TabIndex = 4
        '
        'NumberOfRodsControl
        '
        Me.NumberOfRodsControl.Location = New System.Drawing.Point(168, 24)
        Me.NumberOfRodsControl.Name = "NumberOfRodsControl"
        Me.NumberOfRodsControl.Size = New System.Drawing.Size(64, 23)
        Me.NumberOfRodsControl.TabIndex = 2
        '
        'RodSpacingLabel
        '
        Me.RodSpacingLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RodSpacingLabel.Location = New System.Drawing.Point(16, 48)
        Me.RodSpacingLabel.Name = "RodSpacingLabel"
        Me.RodSpacingLabel.Size = New System.Drawing.Size(144, 23)
        Me.RodSpacingLabel.TabIndex = 3
        Me.RodSpacingLabel.Text = "Rod Spa&cing"
        Me.RodSpacingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NumberOfRodsLabel
        '
        Me.NumberOfRodsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberOfRodsLabel.Location = New System.Drawing.Point(16, 24)
        Me.NumberOfRodsLabel.Name = "NumberOfRodsLabel"
        Me.NumberOfRodsLabel.Size = New System.Drawing.Size(144, 23)
        Me.NumberOfRodsLabel.TabIndex = 1
        Me.NumberOfRodsLabel.Text = "&No. of Rods"
        Me.NumberOfRodsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProfilometerDataControl
        '
        Me.ProfilometerDataControl.AllRowsFixed = False
        Me.ProfilometerDataControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.ProfilometerDataControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.ProfilometerDataControl.CaptionText = "Profilometer Data"
        Me.ProfilometerDataControl.CausesValidation = False
        Me.ProfilometerDataControl.ColumnWidthRatios = Nothing
        Me.ProfilometerDataControl.DataMember = ""
        Me.ProfilometerDataControl.EnableSaveActions = True
        Me.ProfilometerDataControl.FirstColumnIncreases = False
        Me.ProfilometerDataControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.ProfilometerDataControl.FirstColumnMinimum = -10000
        Me.ProfilometerDataControl.FirstRowFixed = False
        Me.ProfilometerDataControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProfilometerDataControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.ProfilometerDataControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.ProfilometerDataControl.Location = New System.Drawing.Point(8, 80)
        Me.ProfilometerDataControl.MaxRows = 50
        Me.ProfilometerDataControl.MinRows = 0
        Me.ProfilometerDataControl.Name = "ProfilometerDataControl"
        Me.ProfilometerDataControl.PasteDisabled = False
        Me.ProfilometerDataControl.SecondColumnIncreases = False
        Me.ProfilometerDataControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.ProfilometerDataControl.SecondColumnMinimum = 0
        Me.ProfilometerDataControl.Size = New System.Drawing.Size(232, 232)
        Me.ProfilometerDataControl.TabIndex = 5
        Me.ProfilometerDataControl.TableReadonly = False
        '
        'WidthTableBox
        '
        Me.WidthTableBox.Controls.Add(Me.CrossSectionArea)
        Me.WidthTableBox.Controls.Add(Me.MaxDepthControl)
        Me.WidthTableBox.Controls.Add(Me.BottomWidthControl)
        Me.WidthTableBox.Controls.Add(Me.MiddleWidthControl)
        Me.WidthTableBox.Controls.Add(Me.TopWidthControl)
        Me.WidthTableBox.Controls.Add(Me.MaxDepthLabel)
        Me.WidthTableBox.Controls.Add(Me.BottomWidthLabel)
        Me.WidthTableBox.Controls.Add(Me.MiddleWidthLabel)
        Me.WidthTableBox.Controls.Add(Me.TopWidthLabel)
        Me.WidthTableBox.Location = New System.Drawing.Point(8, 64)
        Me.WidthTableBox.Name = "WidthTableBox"
        Me.WidthTableBox.Size = New System.Drawing.Size(256, 352)
        Me.WidthTableBox.TabIndex = 2
        Me.WidthTableBox.TabStop = False
        Me.WidthTableBox.Text = "Width Data"
        '
        'CrossSectionArea
        '
        Me.CrossSectionArea.Location = New System.Drawing.Point(16, 320)
        Me.CrossSectionArea.Name = "CrossSectionArea"
        Me.CrossSectionArea.Size = New System.Drawing.Size(224, 24)
        Me.CrossSectionArea.TabIndex = 10
        Me.CrossSectionArea.Text = "Cross Section Area"
        Me.CrossSectionArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MaxDepthControl
        '
        Me.MaxDepthControl.Location = New System.Drawing.Point(176, 112)
        Me.MaxDepthControl.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.MaxDepthControl.Name = "MaxDepthControl"
        Me.MaxDepthControl.Size = New System.Drawing.Size(64, 23)
        Me.MaxDepthControl.TabIndex = 8
        '
        'BottomWidthControl
        '
        Me.BottomWidthControl.Location = New System.Drawing.Point(176, 80)
        Me.BottomWidthControl.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.BottomWidthControl.Name = "BottomWidthControl"
        Me.BottomWidthControl.Size = New System.Drawing.Size(64, 23)
        Me.BottomWidthControl.TabIndex = 6
        '
        'MiddleWidthControl
        '
        Me.MiddleWidthControl.Location = New System.Drawing.Point(176, 56)
        Me.MiddleWidthControl.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.MiddleWidthControl.Name = "MiddleWidthControl"
        Me.MiddleWidthControl.Size = New System.Drawing.Size(64, 23)
        Me.MiddleWidthControl.TabIndex = 4
        '
        'TopWidthControl
        '
        Me.TopWidthControl.Location = New System.Drawing.Point(176, 32)
        Me.TopWidthControl.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.TopWidthControl.Name = "TopWidthControl"
        Me.TopWidthControl.Size = New System.Drawing.Size(64, 23)
        Me.TopWidthControl.TabIndex = 2
        '
        'MaxDepthLabel
        '
        Me.MaxDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxDepthLabel.Location = New System.Drawing.Point(16, 112)
        Me.MaxDepthLabel.Name = "MaxDepthLabel"
        Me.MaxDepthLabel.Size = New System.Drawing.Size(152, 23)
        Me.MaxDepthLabel.TabIndex = 7
        Me.MaxDepthLabel.Text = "Ma&x Depth"
        Me.MaxDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BottomWidthLabel
        '
        Me.BottomWidthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BottomWidthLabel.Location = New System.Drawing.Point(16, 80)
        Me.BottomWidthLabel.Name = "BottomWidthLabel"
        Me.BottomWidthLabel.Size = New System.Drawing.Size(152, 23)
        Me.BottomWidthLabel.TabIndex = 5
        Me.BottomWidthLabel.Text = "&Bottom Width"
        Me.BottomWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MiddleWidthLabel
        '
        Me.MiddleWidthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MiddleWidthLabel.Location = New System.Drawing.Point(16, 56)
        Me.MiddleWidthLabel.Name = "MiddleWidthLabel"
        Me.MiddleWidthLabel.Size = New System.Drawing.Size(152, 23)
        Me.MiddleWidthLabel.TabIndex = 3
        Me.MiddleWidthLabel.Text = "&Middle Width"
        Me.MiddleWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TopWidthLabel
        '
        Me.TopWidthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopWidthLabel.Location = New System.Drawing.Point(16, 32)
        Me.TopWidthLabel.Name = "TopWidthLabel"
        Me.TopWidthLabel.Size = New System.Drawing.Size(152, 23)
        Me.TopWidthLabel.TabIndex = 1
        Me.TopWidthLabel.Text = "&Top Width"
        Me.TopWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PowerLawBox
        '
        Me.PowerLawBox.Controls.Add(Me.PowerLawArea)
        Me.PowerLawBox.Controls.Add(Me.PowerLawMaximumDepthControl)
        Me.PowerLawBox.Controls.Add(Me.PowerLawExponentControl)
        Me.PowerLawBox.Controls.Add(Me.PowerLawWidth100mmControl)
        Me.PowerLawBox.Controls.Add(Me.PowerLawMaximumDepthLabel)
        Me.PowerLawBox.Controls.Add(Me.PowerLawExponentLabel)
        Me.PowerLawBox.Controls.Add(Me.PowerLawWidthAt100mmLabel)
        Me.PowerLawBox.Location = New System.Drawing.Point(272, 288)
        Me.PowerLawBox.Name = "PowerLawBox"
        Me.PowerLawBox.Size = New System.Drawing.Size(280, 128)
        Me.PowerLawBox.TabIndex = 9
        Me.PowerLawBox.TabStop = False
        Me.PowerLawBox.Text = "Power Law Furrow"
        '
        'PowerLawArea
        '
        Me.PowerLawArea.Location = New System.Drawing.Point(16, 96)
        Me.PowerLawArea.Name = "PowerLawArea"
        Me.PowerLawArea.Size = New System.Drawing.Size(216, 23)
        Me.PowerLawArea.TabIndex = 6
        Me.PowerLawArea.Text = "Cross Section Area"
        Me.PowerLawArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PowerLawMaximumDepthControl
        '
        Me.PowerLawMaximumDepthControl.Location = New System.Drawing.Point(176, 24)
        Me.PowerLawMaximumDepthControl.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.PowerLawMaximumDepthControl.Name = "PowerLawMaximumDepthControl"
        Me.PowerLawMaximumDepthControl.Size = New System.Drawing.Size(56, 23)
        Me.PowerLawMaximumDepthControl.TabIndex = 1
        '
        'PowerLawExponentControl
        '
        Me.PowerLawExponentControl.DecimalPlaces = 2
        Me.PowerLawExponentControl.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.PowerLawExponentControl.Location = New System.Drawing.Point(176, 72)
        Me.PowerLawExponentControl.Maximum = New Decimal(New Integer() {10, 0, 0, 65536})
        Me.PowerLawExponentControl.Name = "PowerLawExponentControl"
        Me.PowerLawExponentControl.Size = New System.Drawing.Size(56, 23)
        Me.PowerLawExponentControl.TabIndex = 5
        '
        'PowerLawWidth100mmControl
        '
        Me.PowerLawWidth100mmControl.Location = New System.Drawing.Point(176, 48)
        Me.PowerLawWidth100mmControl.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.PowerLawWidth100mmControl.Name = "PowerLawWidth100mmControl"
        Me.PowerLawWidth100mmControl.Size = New System.Drawing.Size(56, 23)
        Me.PowerLawWidth100mmControl.TabIndex = 3
        '
        'PowerLawMaximumDepthLabel
        '
        Me.PowerLawMaximumDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLawMaximumDepthLabel.Location = New System.Drawing.Point(16, 24)
        Me.PowerLawMaximumDepthLabel.Name = "PowerLawMaximumDepthLabel"
        Me.PowerLawMaximumDepthLabel.Size = New System.Drawing.Size(152, 23)
        Me.PowerLawMaximumDepthLabel.TabIndex = 0
        Me.PowerLawMaximumDepthLabel.Text = "Maximum &Depth"
        Me.PowerLawMaximumDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PowerLawExponentLabel
        '
        Me.PowerLawExponentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLawExponentLabel.Location = New System.Drawing.Point(16, 72)
        Me.PowerLawExponentLabel.Name = "PowerLawExponentLabel"
        Me.PowerLawExponentLabel.Size = New System.Drawing.Size(152, 23)
        Me.PowerLawExponentLabel.TabIndex = 4
        Me.PowerLawExponentLabel.Text = "&Exponent"
        Me.PowerLawExponentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PowerLawWidthAt100mmLabel
        '
        Me.PowerLawWidthAt100mmLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLawWidthAt100mmLabel.Location = New System.Drawing.Point(16, 48)
        Me.PowerLawWidthAt100mmLabel.Name = "PowerLawWidthAt100mmLabel"
        Me.PowerLawWidthAt100mmLabel.Size = New System.Drawing.Size(152, 23)
        Me.PowerLawWidthAt100mmLabel.TabIndex = 2
        Me.PowerLawWidthAt100mmLabel.Text = "&Width at"
        Me.PowerLawWidthAt100mmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrapezoidBox
        '
        Me.TrapezoidBox.Controls.Add(Me.TrapezoidArea)
        Me.TrapezoidBox.Controls.Add(Me.TrapezoidMaximumDepthControl)
        Me.TrapezoidBox.Controls.Add(Me.TrapezoidSideSlopeControl)
        Me.TrapezoidBox.Controls.Add(Me.TrapezoidBottomWidthControl)
        Me.TrapezoidBox.Controls.Add(Me.TrapezoidMaximumDepthLabel)
        Me.TrapezoidBox.Controls.Add(Me.TrapezoidSideSlopeLabel)
        Me.TrapezoidBox.Controls.Add(Me.TrapezoidBottomWidthLabel)
        Me.TrapezoidBox.Location = New System.Drawing.Point(272, 288)
        Me.TrapezoidBox.Name = "TrapezoidBox"
        Me.TrapezoidBox.Size = New System.Drawing.Size(280, 128)
        Me.TrapezoidBox.TabIndex = 8
        Me.TrapezoidBox.TabStop = False
        Me.TrapezoidBox.Text = "Trapezoid Furrow"
        '
        'TrapezoidArea
        '
        Me.TrapezoidArea.Location = New System.Drawing.Point(16, 96)
        Me.TrapezoidArea.Name = "TrapezoidArea"
        Me.TrapezoidArea.Size = New System.Drawing.Size(216, 23)
        Me.TrapezoidArea.TabIndex = 6
        Me.TrapezoidArea.Text = "Cross Section Area"
        Me.TrapezoidArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrapezoidMaximumDepthControl
        '
        Me.TrapezoidMaximumDepthControl.Location = New System.Drawing.Point(176, 24)
        Me.TrapezoidMaximumDepthControl.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.TrapezoidMaximumDepthControl.Name = "TrapezoidMaximumDepthControl"
        Me.TrapezoidMaximumDepthControl.Size = New System.Drawing.Size(56, 23)
        Me.TrapezoidMaximumDepthControl.TabIndex = 1
        '
        'TrapezoidSideSlopeControl
        '
        Me.TrapezoidSideSlopeControl.DecimalPlaces = 2
        Me.TrapezoidSideSlopeControl.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.TrapezoidSideSlopeControl.Location = New System.Drawing.Point(176, 72)
        Me.TrapezoidSideSlopeControl.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.TrapezoidSideSlopeControl.Name = "TrapezoidSideSlopeControl"
        Me.TrapezoidSideSlopeControl.Size = New System.Drawing.Size(56, 23)
        Me.TrapezoidSideSlopeControl.TabIndex = 5
        '
        'TrapezoidBottomWidthControl
        '
        Me.TrapezoidBottomWidthControl.Location = New System.Drawing.Point(176, 48)
        Me.TrapezoidBottomWidthControl.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.TrapezoidBottomWidthControl.Name = "TrapezoidBottomWidthControl"
        Me.TrapezoidBottomWidthControl.Size = New System.Drawing.Size(56, 23)
        Me.TrapezoidBottomWidthControl.TabIndex = 3
        '
        'TrapezoidMaximumDepthLabel
        '
        Me.TrapezoidMaximumDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrapezoidMaximumDepthLabel.Location = New System.Drawing.Point(16, 24)
        Me.TrapezoidMaximumDepthLabel.Name = "TrapezoidMaximumDepthLabel"
        Me.TrapezoidMaximumDepthLabel.Size = New System.Drawing.Size(152, 23)
        Me.TrapezoidMaximumDepthLabel.TabIndex = 0
        Me.TrapezoidMaximumDepthLabel.Text = "Max &Depth"
        Me.TrapezoidMaximumDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrapezoidSideSlopeLabel
        '
        Me.TrapezoidSideSlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrapezoidSideSlopeLabel.Location = New System.Drawing.Point(16, 72)
        Me.TrapezoidSideSlopeLabel.Name = "TrapezoidSideSlopeLabel"
        Me.TrapezoidSideSlopeLabel.Size = New System.Drawing.Size(152, 23)
        Me.TrapezoidSideSlopeLabel.TabIndex = 4
        Me.TrapezoidSideSlopeLabel.Text = "Side S&lope (H/V)"
        Me.TrapezoidSideSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrapezoidBottomWidthLabel
        '
        Me.TrapezoidBottomWidthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrapezoidBottomWidthLabel.Location = New System.Drawing.Point(16, 48)
        Me.TrapezoidBottomWidthLabel.Name = "TrapezoidBottomWidthLabel"
        Me.TrapezoidBottomWidthLabel.Size = New System.Drawing.Size(152, 23)
        Me.TrapezoidBottomWidthLabel.TabIndex = 2
        Me.TrapezoidBottomWidthLabel.Text = "Bottom &Width"
        Me.TrapezoidBottomWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'FurrowFieldData
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(564, 455)
        Me.Controls.Add(Me.FurrowDataPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.Menu = Me.FurrowDataMenu
        Me.MinimizeBox = False
        Me.Name = "FurrowFieldData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cross Section Editor"
        Me.FurrowDataPanel.ResumeLayout(False)
        CType(Me.FurrowGraphics, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DepthWidthBox.ResumeLayout(False)
        CType(Me.DepthWidthControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProfilometerBox.ResumeLayout(False)
        CType(Me.RodSpacingControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberOfRodsControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProfilometerDataControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WidthTableBox.ResumeLayout(False)
        CType(Me.MaxDepthControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomWidthControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MiddleWidthControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopWidthControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PowerLawBox.ResumeLayout(False)
        CType(Me.PowerLawMaximumDepthControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PowerLawExponentControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PowerLawWidth100mmControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TrapezoidBox.ResumeLayout(False)
        CType(Me.TrapezoidMaximumDepthControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrapezoidSideSlopeControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrapezoidBottomWidthControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Constants "
    '
    ' Resolve reference conflicts between DataStore & Srfr
    '
    Protected Const OneMillimeter As Double = Srfr.Globals.OneMillimeter
    Protected Const OneDecimeter As Double = Srfr.Globals.OneDecimeter
    Protected Const OneCentimeter As Double = Srfr.Globals.OneCentimeter
    Protected Const OneMeter As Double = Srfr.Globals.OneMeter

    Protected Const CentimetersPerMeter As Double = Srfr.Globals.CentimetersPerMeter
    Protected Const CentimetersPerInch As Double = Srfr.Globals.CentimetersPerInch

    Protected Const MillimetersPerMeter As Double = Srfr.Globals.MillimetersPerMeter
    Protected Const MillimetersPerCentimeter As Double = OneCentimeter / OneMillimeter
    Protected Const MillimetersPerInch As Double = Srfr.Globals.MillimetersPerInch
    Protected Const MillimetersPerFoot As Double = OneFoot / OneMillimeter

    Protected Const FeetPerMeter As Double = Srfr.Globals.FeetPerMeter

    Protected Const InchesPerMeter As Double = Srfr.Globals.InchesPerMeter
    Protected Const InchesPerFoot As Double = Srfr.Globals.InchesPerFoot

    Protected Const OneSecond As Double = Srfr.Globals.OneSecond
    Protected Const TenSeconds As Double = Srfr.Globals.TenSeconds
    Protected Const OneMinute As Double = Srfr.Globals.OneMinute
    Protected Const OneHour As Double = Srfr.Globals.OneHour
    Protected Const SecondsPerMinute As Double = Srfr.Globals.SecondsPerMinute
    Protected Const SecondsPerHour As Double = Srfr.Globals.SecondsPerHour

    Protected Const LiterPerSecond As Double = Srfr.Globals.LiterPerSecond

#End Region

#Region " Member Data "

    ' Data objects
    Private mUnit As Unit
    Private mSystemGeometry As SystemGeometry

    Private mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    ' Rectange for drawing graphics
    Private mRect As Rectangle
    Private mMaxWidth As Double    ' Max width of rectangle
    Private mMaxHeight As Double   ' Max height of rectangle

    ' Drawing tools
    Private mBold As Font           ' Bold font
    Private mSize As SizeF          ' Size of string
    Private mMargin As Integer      ' Margin for labels

    Private mGrayPen As Pen = DarkGrayPen()
    Private mBlackPen As Pen = BlackPen1()
    Private mGrayBrush As SolidBrush = DarkGraySolidBrush()
    Private mBlackBrush As SolidBrush = BlackSolidBrush()
    Private mVertical As New StringFormat(StringFormatFlags.DirectionVertical)

#End Region

#Region " Properties "

#Region " Cross Section "

    Public Property TopSectionWidth() As Double
        Get
            Return Me.TopWidthControl.Value
        End Get
        Set(ByVal value As Double)

            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.TopWidthLabel.Text = "&" & mDictionary.tTopWidth.Translated & " (ft)"
                    Me.TopWidthControl.DecimalPlaces = 2
                    Me.TopWidthControl.Increment = 0.01D
                    Me.TopWidthControl.Maximum = CDec(FeetPerMeter)
                    Me.TopWidthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Inches
                    Me.TopWidthLabel.Text = "&" & mDictionary.tTopWidth.Translated & " (in)"
                    Me.TopWidthControl.DecimalPlaces = 1
                    Me.TopWidthControl.Increment = 0.1D
                    Me.TopWidthControl.Maximum = CDec(InchesPerMeter)
                    Me.TopWidthControl.Value = CDec(Math.Round(value, 1))
                Case Units.Meters
                    Me.TopWidthLabel.Text = "&" & mDictionary.tTopWidth.Translated & " (m)"
                    Me.TopWidthControl.DecimalPlaces = 2
                    Me.TopWidthControl.Increment = 0.01D
                    Me.TopWidthControl.Maximum = CDec(OneMeter)
                    Me.TopWidthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Centimeters
                    Me.TopWidthLabel.Text = "&" & mDictionary.tTopWidth.Translated & " (cm)"
                    Me.TopWidthControl.DecimalPlaces = 1
                    Me.TopWidthControl.Increment = 0.1D
                    Me.TopWidthControl.Maximum = CDec(CentimetersPerMeter)
                    Me.TopWidthControl.Value = CDec(Math.Round(value, 1))
                Case Else ' Units.Millimeters
                    Me.TopWidthLabel.Text = "&" & mDictionary.tTopWidth.Translated & " (mm)"
                    Me.TopWidthControl.DecimalPlaces = 0
                    Me.TopWidthControl.Increment = 1D
                    Me.TopWidthControl.Maximum = CDec(MillimetersPerMeter)
                    Me.TopWidthControl.Value = CDec(Math.Round(value))
            End Select
        End Set
    End Property

    Public Property MiddleSectionWidth() As Double
        Get
            Return Me.MiddleWidthControl.Value
        End Get
        Set(ByVal value As Double)

            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.MiddleWidthLabel.Text = "&" & mDictionary.tMiddleWidth.Translated & " (ft)"
                    Me.MiddleWidthControl.DecimalPlaces = 2
                    Me.MiddleWidthControl.Increment = 0.01D
                    Me.MiddleWidthControl.Maximum = CDec(FeetPerMeter)
                    Me.MiddleWidthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Inches
                    Me.MiddleWidthLabel.Text = "&" & mDictionary.tMiddleWidth.Translated & " (in)"
                    Me.MiddleWidthControl.DecimalPlaces = 1
                    Me.MiddleWidthControl.Increment = 0.1D
                    Me.MiddleWidthControl.Maximum = CDec(InchesPerMeter)
                    Me.MiddleWidthControl.Value = CDec(Math.Round(value, 1))
                Case Units.Meters
                    Me.MiddleWidthLabel.Text = "&" & mDictionary.tMiddleWidth.Translated & " (m)"
                    Me.MiddleWidthControl.DecimalPlaces = 2
                    Me.MiddleWidthControl.Increment = 0.01D
                    Me.MiddleWidthControl.Maximum = CDec(OneMeter)
                    Me.MiddleWidthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Centimeters
                    Me.MiddleWidthLabel.Text = "&" & mDictionary.tMiddleWidth.Translated & " (cm)"
                    Me.MiddleWidthControl.DecimalPlaces = 1
                    Me.MiddleWidthControl.Increment = 0.1D
                    Me.MiddleWidthControl.Maximum = CDec(CentimetersPerMeter)
                    Me.MiddleWidthControl.Value = CDec(Math.Round(value, 1))
                Case Else ' Units.Millimeters
                    Me.MiddleWidthLabel.Text = "&" & mDictionary.tMiddleWidth.Translated & " (mm)"
                    Me.MiddleWidthControl.DecimalPlaces = 0
                    Me.MiddleWidthControl.Increment = 1D
                    Me.MiddleWidthControl.Maximum = CDec(MillimetersPerMeter)
                    Me.MiddleWidthControl.Value = CDec(Math.Round(value))
            End Select
        End Set
    End Property

    Public Property BottomSectionWidth() As Double
        Get
            Return Me.BottomWidthControl.Value
        End Get
        Set(ByVal value As Double)

            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.BottomWidthLabel.Text = "&" & mDictionary.tBottomWidth.Translated & " (ft)"
                    Me.BottomWidthControl.DecimalPlaces = 2
                    Me.BottomWidthControl.Increment = 0.01D
                    Me.BottomWidthControl.Maximum = CDec(FeetPerMeter)
                    Me.BottomWidthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Inches
                    Me.BottomWidthLabel.Text = "&" & mDictionary.tBottomWidth.Translated & " (in)"
                    Me.BottomWidthControl.DecimalPlaces = 1
                    Me.BottomWidthControl.Increment = 0.1D
                    Me.BottomWidthControl.Maximum = CDec(InchesPerMeter)
                    Me.BottomWidthControl.Value = CDec(Math.Round(value, 1))
                Case Units.Meters
                    Me.BottomWidthLabel.Text = "&" & mDictionary.tBottomWidth.Translated & " (m)"
                    Me.BottomWidthControl.DecimalPlaces = 2
                    Me.BottomWidthControl.Increment = 0.01D
                    Me.BottomWidthControl.Maximum = CDec(OneMeter)
                    Me.BottomWidthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Centimeters
                    Me.BottomWidthLabel.Text = "&" & mDictionary.tBottomWidth.Translated & " (cm)"
                    Me.BottomWidthControl.DecimalPlaces = 1
                    Me.BottomWidthControl.Increment = 0.1D
                    Me.BottomWidthControl.Maximum = CDec(CentimetersPerMeter)
                    Me.BottomWidthControl.Value = CDec(Math.Round(value, 1))
                Case Else ' Units.Millimeters
                    Me.BottomWidthLabel.Text = "&" & mDictionary.tBottomWidth.Translated & " (mm)"
                    Me.BottomWidthControl.DecimalPlaces = 0
                    Me.BottomWidthControl.Increment = 1D
                    Me.BottomWidthControl.Maximum = CDec(MillimetersPerMeter)
                    Me.BottomWidthControl.Value = CDec(Math.Round(value))
            End Select
        End Set
    End Property

    Public Property SectionDepth() As Double
        Get
            Return Me.MaxDepthControl.Value
        End Get
        Set(ByVal value As Double)

            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.MaxDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (ft)"
                    Me.MaxDepthControl.DecimalPlaces = 2
                    Me.MaxDepthControl.Increment = 0.01D
                    Me.MaxDepthControl.Maximum = CDec(FeetPerMeter)
                    Me.MaxDepthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Inches
                    Me.MaxDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (in)"
                    Me.MaxDepthControl.DecimalPlaces = 1
                    Me.MaxDepthControl.Increment = 0.1D
                    Me.MaxDepthControl.Maximum = CDec(InchesPerMeter)
                    Me.MaxDepthControl.Value = CDec(Math.Round(value, 1))
                Case Units.Meters
                    Me.MaxDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (m)"
                    Me.MaxDepthControl.DecimalPlaces = 2
                    Me.MaxDepthControl.Increment = 0.01D
                    Me.MaxDepthControl.Maximum = CDec(OneMeter)
                    Me.MaxDepthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Centimeters
                    Me.MaxDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (cm)"
                    Me.MaxDepthControl.DecimalPlaces = 1
                    Me.MaxDepthControl.Increment = 0.1D
                    Me.MaxDepthControl.Maximum = CDec(CentimetersPerMeter)
                    Me.MaxDepthControl.Value = CDec(Math.Round(value, 1))
                Case Else ' Units.Millimeters
                    Me.MaxDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (mm)"
                    Me.MaxDepthControl.DecimalPlaces = 0
                    Me.MaxDepthControl.Increment = 1D
                    Me.MaxDepthControl.Maximum = CDec(MillimetersPerMeter)
                    Me.MaxDepthControl.Value = CDec(Math.Round(value))
            End Select
        End Set
    End Property

#End Region

#Region " Profilometer Table "

    Private mProfilometerPropertyNode As PropertyNode = New PropertyNode
    Private mProfilometerUpdating As Boolean = False

    Public Property ProfilometerTable() As DataTable
        Get
            Return mProfilometerPropertyNode.GetDataTableParameter.Value
        End Get
        Set(ByVal value As DataTable)

            Dim _profilometerParameter As DataTableParameter = New DataTableParameter(value)

            mProfilometerPropertyNode.SetParameter(_profilometerParameter)
            mProfilometerPropertyNode.EventsEnabled = True

            Me.ProfilometerDataControl.LinkToModel(Nothing, mProfilometerPropertyNode)
            Me.ProfilometerDataControl.ReadonlyColumn(sRodLocationX) = True
            Me.ProfilometerDataControl.MinRows = MinimumNoOfRods
            Me.ProfilometerDataControl.MaxRows = MaximumNoOfRods
            Me.ProfilometerDataControl.UpdateUI()
        End Set
    End Property

    Private mNumberOfRods As Integer
    Public Property NumberOfRods() As Integer
        Get
            Return Me.NumberOfRodsControl.Value
        End Get
        Set(ByVal value As Integer)
            mNumberOfRods = value
            Me.NumberOfRodsControl.Value = mNumberOfRods
            Me.NumberOfRodsControl.Minimum = MinimumNoOfRods
            Me.NumberOfRodsControl.Maximum = MaximumNoOfRods
        End Set
    End Property

    Private mRodSpacing As Double
    Public Property RodSpacing() As Double
        Get
            Return Me.RodSpacingControl.Value
        End Get
        Set(ByVal value As Double)
            mRodSpacing = value

            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.RodSpacingLabel.Text = "&" & mDictionary.tRodSpacing.Translated & " (ft)"
                    Me.RodSpacingControl.DecimalPlaces = 2
                    Me.RodSpacingControl.Increment = 0.01D
                    Me.RodSpacingControl.Value = CDec(Math.Round(mRodSpacing, 2))
                    Me.RodSpacingControl.Minimum = CDec(MinimumRodSpacing * FeetPerMeter)
                    Me.RodSpacingControl.Maximum = CDec(MaximumRodSpacing * FeetPerMeter)
                Case Units.Inches
                    Me.RodSpacingLabel.Text = "&" & mDictionary.tRodSpacing.Translated & " (in)"
                    Me.RodSpacingControl.DecimalPlaces = 1
                    Me.RodSpacingControl.Increment = 0.1D
                    Me.RodSpacingControl.Value = CDec(Math.Round(mRodSpacing, 1))
                    Me.RodSpacingControl.Minimum = CDec(MinimumRodSpacing * InchesPerMeter)
                    Me.RodSpacingControl.Maximum = CDec(MaximumRodSpacing * InchesPerMeter)
                Case Units.Meters
                    Me.RodSpacingLabel.Text = "&" & mDictionary.tRodSpacing.Translated & " (m)"
                    Me.RodSpacingControl.DecimalPlaces = 2
                    Me.RodSpacingControl.Increment = 0.01D
                    Me.RodSpacingControl.Value = CDec(Math.Round(mRodSpacing, 2))
                    Me.RodSpacingControl.Minimum = CDec(MinimumRodSpacing * OneMeter)
                    Me.RodSpacingControl.Maximum = CDec(MaximumRodSpacing * OneMeter)
                Case Units.Centimeters
                    Me.RodSpacingLabel.Text = "&" & mDictionary.tRodSpacing.Translated & " (cm)"
                    Me.RodSpacingControl.DecimalPlaces = 1
                    Me.RodSpacingControl.Increment = 0.1D
                    Me.RodSpacingControl.Value = CDec(Math.Round(mRodSpacing, 1))
                    Me.RodSpacingControl.Minimum = CDec(MinimumRodSpacing * CentimetersPerMeter)
                    Me.RodSpacingControl.Maximum = CDec(MaximumRodSpacing * CentimetersPerMeter)
                Case Else ' Units.Millimeters
                    Me.RodSpacingLabel.Text = "&" & mDictionary.tRodSpacing.Translated & " (mm)"
                    Me.RodSpacingControl.DecimalPlaces = 0
                    Me.RodSpacingControl.Increment = 1
                    Me.RodSpacingControl.Value = CDec(Math.Round(mRodSpacing))
                    Me.RodSpacingControl.Minimum = CDec(MinimumRodSpacing * MillimetersPerMeter)
                    Me.RodSpacingControl.Maximum = CDec(MaximumRodSpacing * MillimetersPerMeter)
            End Select
        End Set
    End Property

#End Region

#Region " Depth / Width Table "

    Private mDepthWidthPropertyNode As PropertyNode = New PropertyNode
    Private mDepthWidthUpdating As Boolean = False

    Public Property DepthWidthTable() As DataTable
        Get
            Return mDepthWidthPropertyNode.GetDataTableParameter.Value
        End Get
        Set(ByVal value As DataTable)

            Dim _depthWidthParameter As DataTableParameter = New DataTableParameter(value)

            mDepthWidthPropertyNode.SetParameter(_depthWidthParameter)
            mDepthWidthPropertyNode.EventsEnabled = True

            Me.DepthWidthControl.LinkToModel(Nothing, mDepthWidthPropertyNode)
            Me.DepthWidthControl.MinRows = MinimumNoOfWidths
            Me.DepthWidthControl.MaxRows = MaximumNoOfWidths
            Me.DepthWidthControl.UpdateUI()
        End Set
    End Property

#End Region

#Region " Trapezoid Furrow "

    Private mTrapezoidSideSlopeSource As Integer
    Public Property TrapezoidSideSlope() As Double
        Get
            Return Me.TrapezoidSideSlopeControl.Value
        End Get
        Set(ByVal value As Double)
            mTrapezoidSideSlopeSource = DataStore.Globals.ValueSources.UserEntered

            Me.TrapezoidSideSlopeControl.Value = CDec(Math.Round(value, 2))
        End Set
    End Property

    Private mTrapezoidBottomWidthSource As Integer
    Public Property TrapezoidBottomWidth() As Double
        Get
            Return Me.TrapezoidBottomWidthControl.Value
        End Get
        Set(ByVal value As Double)
            mTrapezoidBottomWidthSource = DataStore.Globals.ValueSources.UserEntered

            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.TrapezoidBottomWidthLabel.Text = "&" & mDictionary.tBottomWidth.Translated & " (ft)"
                    Me.TrapezoidBottomWidthControl.DecimalPlaces = 2
                    Me.TrapezoidBottomWidthControl.Increment = 0.01D
                    Me.TrapezoidBottomWidthControl.Maximum = CDec(2 * FeetPerMeter)
                    Me.TrapezoidBottomWidthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Inches
                    Me.TrapezoidBottomWidthLabel.Text = "&" & mDictionary.tBottomWidth.Translated & " (in)"
                    Me.TrapezoidBottomWidthControl.DecimalPlaces = 1
                    Me.TrapezoidBottomWidthControl.Increment = 0.1D
                    Me.TrapezoidBottomWidthControl.Maximum = CDec(2 * InchesPerMeter)
                    Me.TrapezoidBottomWidthControl.Value = CDec(Math.Round(value, 1))
                Case Units.Meters
                    Me.TrapezoidBottomWidthLabel.Text = "&" & mDictionary.tBottomWidth.Translated & " (m)"
                    Me.TrapezoidBottomWidthControl.DecimalPlaces = 2
                    Me.TrapezoidBottomWidthControl.Increment = 0.01D
                    Me.TrapezoidBottomWidthControl.Maximum = CDec(2 * OneMeter)
                    Me.TrapezoidBottomWidthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Centimeters
                    Me.TrapezoidBottomWidthLabel.Text = "&" & mDictionary.tBottomWidth.Translated & " (cm)"
                    Me.TrapezoidBottomWidthControl.DecimalPlaces = 1
                    Me.TrapezoidBottomWidthControl.Increment = 0.1D
                    Me.TrapezoidBottomWidthControl.Maximum = CDec(2 * CentimetersPerMeter)
                    Me.TrapezoidBottomWidthControl.Value = CDec(Math.Round(value, 1))
                Case Else ' Units.Millimeters
                    Me.TrapezoidBottomWidthLabel.Text = "&" & mDictionary.tBottomWidth.Translated & " (mm)"
                    Me.TrapezoidBottomWidthControl.DecimalPlaces = 0
                    Me.TrapezoidBottomWidthControl.Increment = 1
                    Me.TrapezoidBottomWidthControl.Maximum = CDec(2 * MillimetersPerMeter)
                    Me.TrapezoidBottomWidthControl.Value = CDec(Math.Round(value))
            End Select
        End Set
    End Property

    Private mTrapezoidMaximumDepthSource As Integer
    Public Property TrapezoidMaximumDepth() As Double
        Get
            Return Me.TrapezoidMaximumDepthControl.Value
        End Get
        Set(ByVal value As Double)
            mTrapezoidMaximumDepthSource = DataStore.Globals.ValueSources.UserEntered

            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.TrapezoidMaximumDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (ft)"
                    Me.TrapezoidMaximumDepthControl.DecimalPlaces = 2
                    Me.TrapezoidMaximumDepthControl.Increment = 0.01D
                    Me.TrapezoidMaximumDepthControl.Maximum = CDec(FeetPerMeter)
                    Me.TrapezoidMaximumDepthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Inches
                    Me.TrapezoidMaximumDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (in)"
                    Me.TrapezoidMaximumDepthControl.DecimalPlaces = 1
                    Me.TrapezoidMaximumDepthControl.Increment = 0.1D
                    Me.TrapezoidMaximumDepthControl.Maximum = CDec(InchesPerMeter)
                    Me.TrapezoidMaximumDepthControl.Value = CDec(Math.Round(value, 1))
                Case Units.Meters
                    Me.TrapezoidMaximumDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (m)"
                    Me.TrapezoidMaximumDepthControl.DecimalPlaces = 2
                    Me.TrapezoidMaximumDepthControl.Increment = 0.01D
                    Me.TrapezoidMaximumDepthControl.Maximum = CDec(OneMeter)
                    Me.TrapezoidMaximumDepthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Centimeters
                    Me.TrapezoidMaximumDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (cm)"
                    Me.TrapezoidMaximumDepthControl.DecimalPlaces = 1
                    Me.TrapezoidMaximumDepthControl.Increment = 0.1D
                    Me.TrapezoidMaximumDepthControl.Maximum = CDec(CentimetersPerMeter)
                    Me.TrapezoidMaximumDepthControl.Value = CDec(Math.Round(value, 1))
                Case Else ' Units.Millimeters
                    Me.TrapezoidMaximumDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (mm)"
                    Me.TrapezoidMaximumDepthControl.DecimalPlaces = 0
                    Me.TrapezoidMaximumDepthControl.Increment = 1
                    Me.TrapezoidMaximumDepthControl.Maximum = CDec(MillimetersPerMeter)
                    Me.TrapezoidMaximumDepthControl.Value = CDec(Math.Round(value))
            End Select
        End Set
    End Property

#End Region

#Region " Power Law Furrow "

    Private mPowerLawExponentSource As Integer
    Public Property PowerLawExponent() As Double
        Get
            Return Me.PowerLawExponentControl.Value
        End Get
        Set(ByVal value As Double)
            mPowerLawExponentSource = DataStore.Globals.ValueSources.UserEntered

            Me.PowerLawExponentControl.Value = CDec(Math.Round(value, 2))
        End Set
    End Property

    Private mPowerLawWidthAt100mmSource As Integer
    Public Property PowerLawWidthAt100mm() As Double
        Get
            Return Me.PowerLawWidth100mmControl.Value
        End Get
        Set(ByVal value As Double)
            mPowerLawWidthAt100mmSource = DataStore.Globals.ValueSources.UserEntered

            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.PowerLawWidthAt100mmLabel.Text = "&" & mDictionary.tWidthAt.Translated & " 4in (ft)"
                    Me.PowerLawWidth100mmControl.DecimalPlaces = 2
                    Me.PowerLawWidth100mmControl.Increment = 0.01D
                    Me.PowerLawWidth100mmControl.Maximum = CDec(2 * FeetPerMeter)
                    Me.PowerLawWidth100mmControl.Value = CDec(Math.Round(value, 2))
                Case Units.Inches
                    Me.PowerLawWidthAt100mmLabel.Text = "&" & mDictionary.tWidthAt.Translated & " 4in (in)"
                    Me.PowerLawWidth100mmControl.DecimalPlaces = 1
                    Me.PowerLawWidth100mmControl.Increment = 0.1D
                    Me.PowerLawWidth100mmControl.Maximum = CDec(2 * InchesPerMeter)
                    Me.PowerLawWidth100mmControl.Value = CDec(Math.Round(value, 1))
                Case Units.Meters
                    Me.PowerLawWidthAt100mmLabel.Text = "&" & mDictionary.tWidthAt.Translated & " 100mm (m)"
                    Me.PowerLawWidth100mmControl.DecimalPlaces = 2
                    Me.PowerLawWidth100mmControl.Increment = 0.01D
                    Me.PowerLawWidth100mmControl.Maximum = CDec(2 * OneMeter)
                    Me.PowerLawWidth100mmControl.Value = CDec(Math.Round(value, 2))
                Case Units.Centimeters
                    Me.PowerLawWidthAt100mmLabel.Text = "&" & mDictionary.tWidthAt.Translated & " 100mm (cm)"
                    Me.PowerLawWidth100mmControl.DecimalPlaces = 1
                    Me.PowerLawWidth100mmControl.Increment = 0.1D
                    Me.PowerLawWidth100mmControl.Maximum = CDec(2 * CentimetersPerMeter)
                    Me.PowerLawWidth100mmControl.Value = CDec(Math.Round(value, 1))
                Case Else ' Units.Millimeters
                    Me.PowerLawWidthAt100mmLabel.Text = "&" & mDictionary.tWidthAt.Translated & " 100mm (mm)"
                    Me.PowerLawWidth100mmControl.DecimalPlaces = 0
                    Me.PowerLawWidth100mmControl.Increment = 1
                    Me.PowerLawWidth100mmControl.Maximum = CDec(2 * MillimetersPerMeter)
                    Me.PowerLawWidth100mmControl.Value = CDec(Math.Round(value))
            End Select
        End Set
    End Property

    Private mPowerLawMaximumDepthSource As Integer
    Public Property PowerLawMaximumDepth() As Double
        Get
            Return Me.PowerLawMaximumDepthControl.Value
        End Get
        Set(ByVal value As Double)
            mPowerLawMaximumDepthSource = DataStore.Globals.ValueSources.UserEntered

            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.PowerLawMaximumDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (ft)"
                    Me.PowerLawMaximumDepthControl.DecimalPlaces = 2
                    Me.PowerLawMaximumDepthControl.Increment = 0.01D
                    Me.PowerLawMaximumDepthControl.Maximum = CDec(FeetPerMeter)
                    Me.PowerLawMaximumDepthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Inches
                    Me.PowerLawMaximumDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (in)"
                    Me.PowerLawMaximumDepthControl.DecimalPlaces = 1
                    Me.PowerLawMaximumDepthControl.Increment = 0.1D
                    Me.PowerLawMaximumDepthControl.Maximum = CDec(InchesPerMeter)
                    Me.PowerLawMaximumDepthControl.Value = CDec(Math.Round(value, 2))
                Case Units.Meters
                    Me.PowerLawMaximumDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (m)"
                    Me.PowerLawMaximumDepthControl.DecimalPlaces = 2
                    Me.PowerLawMaximumDepthControl.Increment = 0.01D
                    Me.PowerLawMaximumDepthControl.Maximum = CDec(OneMeter)
                    Me.PowerLawMaximumDepthControl.Value = CDec(Math.Round(value))
                Case Units.Centimeters
                    Me.PowerLawMaximumDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (cm)"
                    Me.PowerLawMaximumDepthControl.DecimalPlaces = 1
                    Me.PowerLawMaximumDepthControl.Increment = 0.1D
                    Me.PowerLawMaximumDepthControl.Maximum = CDec(CentimetersPerMeter)
                    Me.PowerLawMaximumDepthControl.Value = CDec(Math.Round(value))
                Case Else ' Units.Millimeters
                    Me.PowerLawMaximumDepthLabel.Text = "&" & mDictionary.tMaxDepth.Translated & " (mm)"
                    Me.PowerLawMaximumDepthControl.DecimalPlaces = 0
                    Me.PowerLawMaximumDepthControl.Increment = 1
                    Me.PowerLawMaximumDepthControl.Maximum = CDec(MillimetersPerMeter)
                    Me.PowerLawMaximumDepthControl.Value = CDec(Math.Round(value))
            End Select
        End Set
    End Property

#End Region

#Region " Field Data / Furrow Shape "

    Public Property FurrowFieldDataType() As FurrowFieldDataTypes
        Get
            Return Me.FurrowFieldDataTypeControl.SelectedIndex
        End Get
        Set(ByVal value As FurrowFieldDataTypes)

            Select Case (value)

                Case Globals.FurrowFieldDataTypes.ProfilometerTable
                    Me.FurrowFieldDataTypeControl.SelectedIndex = Globals.FurrowFieldDataTypes.ProfilometerTable
                    Me.CalcFurrowFromProfilometer()

                Case Globals.FurrowFieldDataTypes.DepthWidthTable
                    Me.FurrowFieldDataTypeControl.SelectedIndex = Globals.FurrowFieldDataTypes.DepthWidthTable
                    Me.CalcFurrowFromDepthWidthTable()

                Case Else ' Assume Globals.FurrowFieldDataTypes.WidthTable
                    Me.FurrowFieldDataTypeControl.SelectedIndex = Globals.FurrowFieldDataTypes.WidthTable
                    Me.CalcFurrowFromWidthTable()

            End Select
        End Set
    End Property

    Public Property FurrowShape() As FurrowShapes
        Get
            Return Me.FurrowShapeControl.SelectedIndex
        End Get
        Set(ByVal value As FurrowShapes)

            Select Case (value)
                Case FurrowShapes.PowerLawFromFieldData, FurrowShapes.PowerLaw
                    Me.FurrowShapeControl.SelectedIndex = FurrowShapes.PowerLaw
                Case Else ' Assume Globals.FurrowShapes.Trapezoid
                    Me.FurrowShapeControl.SelectedIndex = FurrowShapes.Trapezoid
            End Select
        End Set
    End Property

#End Region

#End Region

#Region " Initialization "

    Private mInitializing As Boolean = False
    Private Sub InitializeFurrowFieldData(ByVal _unit As Unit)

        If (_unit IsNot Nothing) Then
            mUnit = _unit
            mSystemGeometry = mUnit.SystemGeometryRef
        End If

        mInitializing = True

        Me.Text = mDictionary.ControlText(Me)

        ' Load text fields that require Translation
        Me.FurrowFieldDataTypeControl.Add(mDictionary.tWidthTable.Translated, 0)
        Me.FurrowFieldDataTypeControl.Add(mDictionary.tDepthWidthTable.Translated, 1)
        Me.FurrowFieldDataTypeControl.Add(mDictionary.tProfilometerTable.Translated, 2)

        Me.FurrowShapeControl.Add(mDictionary.tTrapezoid.Translated, 0)
        Me.FurrowShapeControl.Add(mDictionary.tPowerLaw.Translated, 1)

        Me.FitToLabel.Text = "----- " & mDictionary.tFitTo.Translated & " ---->"

    End Sub

#End Region

#Region " Methods "

#Region " Update UI "

    Private Sub UpdateUI()
        '
        ' Update Field Data UI
        '
        Select Case (Me.FurrowFieldDataTypeControl.SelectedIndex)
            Case Globals.FurrowFieldDataTypes.DepthWidthTable
                UpdateDepthWidthTable()
            Case Globals.FurrowFieldDataTypes.ProfilometerTable
                UpdateProfilometerTable()
            Case Else ' Assume Globals.FurrowFieldDataTypes.WidthTable
                UpdateWidthTable()
        End Select
        '
        ' Update Cross Section UI
        '
        Select Case (Me.FurrowShapeControl.SelectedIndex)
            Case Globals.FurrowShapes.PowerLaw
                UpdatePowerLawCrossSection()
            Case Else ' Assume Globals.FurrowShapes.Trapezoid
                UpdateTrapezoidCrossSection()
        End Select
        '
        ' Update graphics
        '
        UpdateGraphics()

    End Sub

    Private Sub UpdateDepthWidthTable()

        Me.WidthTableBox.Hide()
        Me.ProfilometerBox.Hide()
        Me.DepthWidthBox.Show()

        mMaxWidth = 0
        mMaxHeight = 0

        ' Update Depth / Width table display
        If Not (mDepthWidthUpdating) Then
            Me.DepthWidthControl.UpdateUI()
        End If

        ' Get Depth / Width data
        Dim _depthWidthParameter As DataTableParameter = mDepthWidthPropertyNode.GetDataTableParameter
        Dim _numWidths As Integer = _depthWidthParameter.Value.Rows.Count

        ' Determine furrow depth
        Dim _depth As Double = 0.0

        For _idx As Integer = 0 To _numWidths - 1
            If (_depth < _depthWidthParameter.GetDoubleDisplay(_idx, sDepthX)) Then
                _depth = _depthWidthParameter.GetDoubleDisplay(_idx, sDepthX)
            End If
        Next

        If (mMaxHeight < _depth) Then
            mMaxHeight = _depth
        End If

        ' Determine furrow width
        Dim _width As Double = 0.0

        For _idx As Integer = 0 To _numWidths - 1
            If (_width < _depthWidthParameter.GetDoubleDisplay(_idx, sWidthX)) Then
                _width = _depthWidthParameter.GetDoubleDisplay(_idx, sWidthX)
            End If
        Next

        If (mMaxWidth < _width) Then
            mMaxWidth = _width
        End If

        ' Calculate cross section area (ft²|m²)
        Dim _area As Double = 0.0
        Dim _width1 As Double = _depthWidthParameter.GetDoubleDisplay(0, sWidthX)
        Dim _depth1 As Double = _depthWidthParameter.GetDoubleDisplay(0, sDepthX)
        Dim _width2 As Double
        Dim _depth2 As Double

        For _idx As Integer = 1 To _numWidths - 1
            _width2 = _depthWidthParameter.GetDoubleDisplay(_idx, sWidthX)
            _depth2 = _depthWidthParameter.GetDoubleDisplay(_idx, sDepthX)
            _area += ((_width1 + _width2) / 2.0) * Math.Abs(_depth2 - _depth1)
            _width1 = _width2
            _depth1 = _depth2
        Next

        _width2 = 0.0
        _depth2 = 0.0
        _area += ((_width1 + _width2) / 2.0) * Math.Abs(_depth2 - _depth1)

        Me.WidthTableArea.Text = mDictionary.tCrossSectionArea.Translated & " "

        Select Case (mUnitsSystem.ShapeUnits)
            Case Units.Feet
                Me.WidthTableArea.Text += "(ft²) = " + Format(_area, "0.000")
            Case Units.Inches
                _area /= InchesPerFoot ^ 2
                Me.WidthTableArea.Text += "(ft²) = " + Format(_area, "0.000")
            Case Units.Meters
                Me.WidthTableArea.Text += "(m²) = " + Format(_area, "0.000")
            Case Units.Centimeters
                _area /= CentimetersPerMeter ^ 2
                Me.WidthTableArea.Text += "(m²) = " + Format(_area, "0.000")
            Case Else ' Units.Millimeters
                _area /= MillimetersPerMeter ^ 2
                Me.WidthTableArea.Text += "(m²) = " + Format(_area, "0.000")
        End Select

    End Sub

    Private Sub UpdateProfilometerTable()

        Me.DepthWidthBox.Hide()
        Me.WidthTableBox.Hide()
        Me.ProfilometerBox.Show()

        mMaxWidth = 0
        mMaxHeight = 0

        ' Update Profilometer Table display
        If Not (mProfilometerUpdating) Then
            Me.ProfilometerDataControl.UpdateUI()
        End If

        ' Get Profilometer data
        Dim _profilometerParameter As DataTableParameter = mProfilometerPropertyNode.GetDataTableParameter
        Dim _numRods As Integer = _profilometerParameter.Value.Rows.Count

        If (MinimumNoOfRods <= _numRods) Then

            ' Find furrow edges
            Dim _leftRod As Integer = 0
            For _idx As Integer = 1 To _numRods - 1
                If (0.0 < _profilometerParameter.GetDoubleDisplay(_idx, sRodDepthX)) Then
                    _leftRod = _idx - 1
                    Exit For
                End If
            Next

            Dim _rightRod As Integer = _numRods - 1
            For _idx As Integer = _numRods - 2 To 0 Step -1
                If (0.0 < _profilometerParameter.GetDoubleDisplay(_idx, sRodDepthX)) Then
                    _rightRod = _idx + 1
                    Exit For
                End If
            Next

            ' Determine furrow depth
            Dim _top As Double = Double.MaxValue
            Dim _bot As Double = Double.MinValue
            For _idx As Integer = _leftRod To _rightRod
                If (_top > _profilometerParameter.GetDoubleDisplay(_idx, sRodDepthX)) Then
                    _top = _profilometerParameter.GetDoubleDisplay(_idx, sRodDepthX)
                End If
                If (_bot < _profilometerParameter.GetDoubleDisplay(_idx, sRodDepthX)) Then
                    _bot = _profilometerParameter.GetDoubleDisplay(_idx, sRodDepthX)
                End If
            Next
            Dim _depth As Double = _bot - _top

            If (mMaxHeight < _depth) Then
                mMaxHeight = _depth
            End If

            ' Determine furrow width
            Dim _side1 As Double = _profilometerParameter.GetDoubleDisplay(_leftRod, sRodLocationX)
            Dim _side2 As Double = _profilometerParameter.GetDoubleDisplay(_rightRod, sRodLocationX)
            Dim _topWidth As Double = _side2 - _side1

            If (mMaxWidth < _topWidth) Then
                mMaxWidth = _topWidth
            End If

            ' Calculate cross section area (ft²|m²)
            Dim _area As Double = 0.0
            Dim _spacing As Double = _topWidth / (_rightRod - _leftRod)

            Dim _depth1 As Double = _profilometerParameter.GetDoubleDisplay(_leftRod, sRodDepthX) ' (in|mm)
            For _idx As Integer = _leftRod + 1 To _rightRod
                Dim _depth2 As Double = _profilometerParameter.GetDoubleDisplay(_idx, sRodDepthX) ' (in|mm)
                _area += _spacing * ((_depth1 + _depth2) / 2.0)
                _depth1 = _depth2
            Next

            Me.ProfilometerArea.Text = mDictionary.tCrossSectionArea.Translated & " "

            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.ProfilometerArea.Text += "(ft²) = " + Format(_area, "0.000")
                Case Units.Inches
                    _area /= InchesPerFoot ^ 2
                    Me.ProfilometerArea.Text += "(ft²) = " + Format(_area, "0.000")
                Case Units.Meters
                    Me.ProfilometerArea.Text += "(m²) = " + Format(_area, "0.000")
                Case Units.Centimeters
                    _area /= CentimetersPerMeter ^ 2
                    Me.ProfilometerArea.Text += "(m²) = " + Format(_area, "0.000")
                Case Else ' Units.Millimeters
                    _area /= MillimetersPerMeter ^ 2
                    Me.ProfilometerArea.Text += "(m²) = " + Format(_area, "0.000")
            End Select
        End If

    End Sub

    Private Sub UpdateWidthTable()

        Me.DepthWidthBox.Hide()
        Me.ProfilometerBox.Hide()
        Me.WidthTableBox.Show()

        mMaxWidth = 0
        mMaxHeight = 0

        ' Determine furrow depth
        Dim _depth As Double = Me.MaxDepthControl.Value

        If (mMaxHeight < _depth) Then
            mMaxHeight = _depth
        End If

        ' Determine furrow width
        Dim _topWidth As Double = Me.TopWidthControl.Value
        Dim _midWidth As Double = Me.MiddleWidthControl.Value
        Dim _botWidth As Double = Me.BottomWidthControl.Value

        Dim _maxWidth As Double = Math.Max(Math.Max(_topWidth, _midWidth), _botWidth)

        If (mMaxWidth < _maxWidth) Then
            mMaxWidth = _maxWidth
        End If

        ' Calculate cross section area
        Dim _topArea As Double = (_depth / 2.0) * (_midWidth + ((_topWidth - _midWidth) / 2.0))
        Dim _botArea As Double = (_depth / 2.0) * (_botWidth + ((_midWidth - _botWidth) / 2.0))
        Dim _area As Double = _topArea + _botArea

        Me.CrossSectionArea.Text = mDictionary.tCrossSectionArea.Translated & " "

        Select Case (mUnitsSystem.ShapeUnits)
            Case Units.Feet
                Me.CrossSectionArea.Text += "(ft²) = " + Format(_area, "0.000")
            Case Units.Inches
                _area /= InchesPerFoot ^ 2
                Me.CrossSectionArea.Text += "(ft²) = " + Format(_area, "0.000")
            Case Units.Meters
                Me.CrossSectionArea.Text += "(m²) = " + Format(_area, "0.000")
            Case Units.Centimeters
                _area /= CentimetersPerMeter ^ 2
                Me.CrossSectionArea.Text += "(m²) = " + Format(_area, "0.000")
            Case Else ' Units.Millimeters
                _area /= MillimetersPerMeter ^ 2
                Me.CrossSectionArea.Text += "(m²) = " + Format(_area, "0.000")
        End Select

    End Sub

    Private Sub UpdatePowerLawCrossSection()

        Me.TrapezoidBox.Hide()
        Me.PowerLawBox.Show()

        ' Get power law data (in ft|m)
        Dim _widthAt100mm As Double = Me.PowerLawWidth100mmControl.Value
        Dim _depth As Double = Me.PowerLawMaximumDepthControl.Value
        Dim _exponent As Double = Me.PowerLawExponentControl.Value

        If (mMaxHeight < _depth) Then
            mMaxHeight = _depth
        End If

        ' Compute C using:  C = W@100mm / 100mm^e
        Dim _const As Double = _widthAt100mm
        Select Case (mUnitsSystem.ShapeUnits)
            Case Units.Feet
                _const /= ((100.0 / MillimetersPerFoot) ^ _exponent)
            Case Units.Inches
                _const /= ((100.0 / MillimetersPerInch) ^ _exponent)
            Case Units.Meters
                _const /= ((100.0 / MillimetersPerMeter) ^ _exponent)
            Case Units.Centimeters
                _const /= ((100.0 / MillimetersPerCentimeter) ^ _exponent)
            Case Else ' Units.Millimeters
                _const /= (100.0 ^ _exponent)
        End Select

        ' Compute top width using:  Wtop = C * D^e
        Dim _topWidth As Double = _const * (_depth ^ _exponent)

        If (mMaxWidth < _topWidth) Then
            mMaxWidth = _topWidth
        End If

        ' Calculate power law area
        Dim _area As Double = (_topWidth * _depth) / (_exponent + 1)

        Me.PowerLawArea.Text = mDictionary.tPowerLawArea.Translated & " "

        Select Case (mUnitsSystem.ShapeUnits)
            Case Units.Feet
                Me.PowerLawArea.Text += "(ft²) = " + Format(_area, "0.000")
            Case Units.Inches
                _area /= InchesPerFoot ^ 2
                Me.PowerLawArea.Text += "(ft²) = " + Format(_area, "0.000")
            Case Units.Meters
                Me.PowerLawArea.Text += "(m²) = " + Format(_area, "0.000")
            Case Units.Centimeters
                _area /= CentimetersPerMeter ^ 2
                Me.PowerLawArea.Text += "(m²) = " + Format(_area, "0.000")
            Case Else ' Units.Millimeters
                _area /= MillimetersPerMeter ^ 2
                Me.PowerLawArea.Text += "(m²) = " + Format(_area, "0.000")
        End Select

        ' Set value background color to match source
        If (mPowerLawExponentSource = DataStore.Globals.ValueSources.UserEntered) Then
            Me.PowerLawExponentControl.BackColor = DataStore.BackColor_UserEntered
        Else
            Me.PowerLawExponentControl.BackColor = DataStore.BackColor_Calculated
        End If

        If (mPowerLawMaximumDepthSource = DataStore.Globals.ValueSources.UserEntered) Then
            Me.PowerLawMaximumDepthControl.BackColor = DataStore.BackColor_UserEntered
        Else
            Me.PowerLawMaximumDepthControl.BackColor = DataStore.BackColor_Calculated
        End If

        If (mPowerLawWidthAt100mmSource = DataStore.Globals.ValueSources.UserEntered) Then
            Me.PowerLawWidth100mmControl.BackColor = DataStore.BackColor_UserEntered
        Else
            Me.PowerLawWidth100mmControl.BackColor = DataStore.BackColor_Calculated
        End If

    End Sub

    Private Sub UpdateTrapezoidCrossSection()

        Me.PowerLawBox.Hide()
        Me.TrapezoidBox.Show()

        ' Get trapezoid data
        Dim _depth As Double = Me.TrapezoidMaximumDepthControl.Value
        Dim _slope As Double = Me.TrapezoidSideSlopeControl.Value
        Dim _botWidth As Double = Me.TrapezoidBottomWidthControl.Value

        If (mMaxHeight < _depth) Then
            mMaxHeight = _depth
        End If

        Dim _topWidth As Double = _botWidth + (_depth * _slope) * 2.0

        If (mMaxWidth < _topWidth) Then
            mMaxWidth = _topWidth
        End If

        ' Calculate trapezoid area
        Dim _area As Double = _depth * (_botWidth + (_depth * _slope))

        Me.TrapezoidArea.Text = mDictionary.tTrapezoidArea.Translated & " "

        Select Case (mUnitsSystem.ShapeUnits)
            Case Units.Feet
                Me.TrapezoidArea.Text += "(ft²) = " + Format(_area, "0.000")
            Case Units.Inches
                _area /= InchesPerFoot ^ 2
                Me.TrapezoidArea.Text += "(ft²) = " + Format(_area, "0.000")
            Case Units.Meters
                Me.TrapezoidArea.Text += "(m²) = " + Format(_area, "0.000")
            Case Units.Centimeters
                _area /= CentimetersPerMeter ^ 2
                Me.TrapezoidArea.Text += "(m²) = " + Format(_area, "0.000")
            Case Else ' Units.Millimeters
                _area /= MillimetersPerMeter ^ 2
                Me.TrapezoidArea.Text += "(m²) = " + Format(_area, "0.000")
        End Select

        ' Set value background color to match source
        If (mTrapezoidBottomWidthSource = DataStore.Globals.ValueSources.UserEntered) Then
            Me.TrapezoidBottomWidthControl.BackColor = DataStore.BackColor_UserEntered
        Else
            Me.TrapezoidBottomWidthControl.BackColor = DataStore.BackColor_Calculated
        End If

        If (mTrapezoidSideSlopeSource = DataStore.Globals.ValueSources.UserEntered) Then
            Me.TrapezoidSideSlopeControl.BackColor = DataStore.BackColor_UserEntered
        Else
            Me.TrapezoidSideSlopeControl.BackColor = DataStore.BackColor_Calculated
        End If

        If (mTrapezoidMaximumDepthSource = DataStore.Globals.ValueSources.UserEntered) Then
            Me.TrapezoidMaximumDepthControl.BackColor = DataStore.BackColor_UserEntered
        Else
            Me.TrapezoidMaximumDepthControl.BackColor = DataStore.BackColor_Calculated
        End If

    End Sub

#End Region

#Region " Graphics "

    Private Sub UpdateGraphics()

        Try
            ' Get graphics area
            Dim _rect As Rectangle = New Rectangle(0, 0, FurrowGraphics.Width, FurrowGraphics.Height)
            Dim _bitmap As Bitmap = New Bitmap(FurrowGraphics.Width, FurrowGraphics.Height)
            Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

            mBold = New Font(Me.Font, FontStyle.Bold)
            mSize = _graphics.MeasureString("JLS", Me.Font)
            mMargin = CInt(mSize.Height + 1)

            ' Fill graphics area with the background color
            Dim _brush As Brush = New SolidBrush(Me.BackColor)
            _graphics.FillRectangle(_brush, 0, 0, FurrowGraphics.Width, FurrowGraphics.Height)

            mRect = New Rectangle(_rect.X + mMargin, _
                                  _rect.Y + (2 * mMargin), _
                                  _rect.Width - (2 * mMargin), _
                                  _rect.Height - (3 * mMargin))

            ' Determine optimum enclosing rectangle for graphics
            Dim _ratio As Double = (mRect.Width * 1.0) / (mRect.Height * 1.0)

            If (_ratio < (mMaxWidth / mMaxHeight)) Then
                ' Width is limiting
                mRect.Height = CInt((mRect.Width * mMaxHeight) / mMaxWidth)
                mRect.Y = CInt(_rect.Y + ((_rect.Height - mRect.Height + mMargin) / 2))
            Else
                ' Depth is limiting
                mRect.Width = CInt((mRect.Height * mMaxWidth) / mMaxHeight)
                mRect.X = CInt(_rect.X + ((_rect.Width - mRect.Width) / 2))
            End If

            ' Draw graphs
            Select Case (Me.FurrowFieldDataTypeControl.SelectedIndex)
                Case Globals.FurrowFieldDataTypes.ProfilometerTable
                    DrawProfilometerGraph(_graphics, _rect)
                Case Globals.FurrowFieldDataTypes.DepthWidthTable
                    DrawDepthWidthGraph(_graphics, _rect)
                Case Else ' Assume Globals.FurrowFieldDataTypes.WidthTable
                    DrawTopWidthGraph(_graphics, _rect)
            End Select

            Select Case (Me.FurrowShapeControl.SelectedIndex)
                Case Globals.FurrowShapes.PowerLaw
                    DrawPowerLawGraph(_graphics, _rect)
                Case Else ' Assume Globals.FurrowShapes.Trapezoid
                    DrawTrapezoidGraph(_graphics, _rect)
            End Select

            ' Copy new bitmap into the image (this prevents flicker)
            If (FurrowGraphics.Image IsNot Nothing) Then
                FurrowGraphics.Image.Dispose()
                FurrowGraphics.Image = Nothing
            End If

            FurrowGraphics.Image = _bitmap

        Catch ex As Exception
        End Try

    End Sub

    Private Function XLoc(ByVal _width As Double) As Integer
        Dim _xLoc As Integer = CInt(((mMaxWidth - _width) * mRect.Width) / (mMaxWidth * 2.0))
        Return _xLoc
    End Function

    Private Function YLoc(ByVal _depth As Double) As Integer
        Dim _yLoc As Integer = CInt(((mMaxHeight - _depth) * mRect.Height) / mMaxHeight)
        Return _yLoc
    End Function

    Private Sub DrawTopWidthGraph(ByVal _graphics As Graphics, ByVal _rect As Rectangle)

        ' Ignore errors while drawing graph
        Try
            ' Get Cross Section data
            Dim _topWidth As Double = Me.TopWidthControl.Value
            Dim _midWidth As Double = Me.MiddleWidthControl.Value
            Dim _botWidth As Double = Me.BottomWidthControl.Value

            Dim _depth As Double = Me.MaxDepthControl.Value

            ' Compute cross section furrow
            Dim _tx As Integer = XLoc(_topWidth)    ' Top delta
            Dim _mx As Integer = XLoc(_midWidth)    ' Middle delta
            Dim _bx As Integer = XLoc(_botWidth)    ' Bottom delta

            Dim _ty As Integer = YLoc(_depth)
            Dim _my As Integer = YLoc(_depth / 2.0)
            Dim _by As Integer = YLoc(0.0)

            Dim _point1 As Point = New Point(mRect.X + _tx, mRect.Y + _ty)
            Dim _point2 As Point = New Point(mRect.X + _mx, mRect.Y + _my)
            Dim _point3 As Point = New Point(mRect.X + _bx, mRect.Y + _by)
            Dim _point4 As Point = New Point(mRect.X + mRect.Width - _bx, mRect.Y + _by)
            Dim _point5 As Point = New Point(mRect.X + mRect.Width - _mx, mRect.Y + _my)
            Dim _point6 As Point = New Point(mRect.X + mRect.Width - _tx, mRect.Y + _ty)

            ' Draw cross section
            Dim _crossSection As Point() = {_point1, _point2, _point3, _point4, _point5, _point6}

            _graphics.DrawLines(mGrayPen, _crossSection)

            ' Draw cross section label
            Dim _title As String = mDictionary.tWidthTable.Translated
            mSize = _graphics.MeasureString(_title, Me.Font)
            _graphics.DrawString(_title, Me.Font, mBlackBrush, _rect.X, _rect.Y + mMargin - 1)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub DrawDepthWidthGraph(ByVal _graphics As Graphics, ByVal _rect As Rectangle)

        ' Ignore errors while drawing graph
        Try
            ' Get Depth / Width data
            Dim _depthWidthParameter As DataTableParameter = mDepthWidthPropertyNode.GetDataTableParameter
            Dim _numWidths As Integer = _depthWidthParameter.Value.Rows.Count

            ' Get first width / depth
            Dim _width As Double = _depthWidthParameter.GetDoubleDisplay(0, sWidthX)
            Dim _depth As Double = _depthWidthParameter.GetDoubleDisplay(0, sDepthX)

            Dim _x As Integer = XLoc(_width)
            Dim _y As Integer = YLoc(_depth)

            Dim _point1l As Point = New Point(mRect.X + _x, mRect.Y + _y)
            Dim _point1r As Point = New Point(mRect.X + mRect.Width - _x, mRect.Y + _y)
            Dim _point2l As Point
            Dim _point2r As Point

            For _idx As Integer = 1 To _numWidths - 1
                _width = _depthWidthParameter.GetDoubleDisplay(_idx, sWidthX)
                _depth = _depthWidthParameter.GetDoubleDisplay(_idx, sDepthX)

                _x = XLoc(_width)
                _y = YLoc(_depth)

                _point2l = New Point(mRect.X + _x, mRect.Y + _y)
                _point2r = New Point(mRect.X + mRect.Width - _x, mRect.Y + _y)

                _graphics.DrawLine(mGrayPen, _point1l, _point2l)
                _graphics.DrawLine(mGrayPen, _point1r, _point2r)

                _point1l = _point2l
                _point1r = _point2r
            Next

            ' Draw bottom point
            _width = 0.0
            _depth = 0.0

            _x = XLoc(_width)
            _y = YLoc(_depth)

            _point2l = New Point(mRect.X + _x, mRect.Y + _y)
            _point2r = New Point(mRect.X + mRect.Width - _x, mRect.Y + _y)

            _graphics.DrawLine(mGrayPen, _point1l, _point2l)
            _graphics.DrawLine(mGrayPen, _point1r, _point2r)

            ' Draw cross section label
            Dim _title As String = mDictionary.tDepthWidthTable.Translated
            mSize = _graphics.MeasureString(_title, Me.Font)
            _graphics.DrawString(_title, Me.Font, mBlackBrush, _rect.X, _rect.Y + mMargin - 1)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub DrawProfilometerGraph(ByVal _graphics As Graphics, ByVal _rect As Rectangle)

        ' Ignore errors while drawing graph
        Try
            ' Get Profilometer data
            Dim _profilometerParameter As DataTableParameter = mProfilometerPropertyNode.GetDataTableParameter
            Dim _numRods As Integer = _profilometerParameter.Value.Rows.Count

            If (MinimumNoOfRods <= _numRods) Then

                ' Find furrow edges
                Dim _leftRod As Integer = 0
                For _idx As Integer = 1 To _numRods - 1
                    If (0.0 < _profilometerParameter.GetDoubleDisplay(_idx, sRodDepthX)) Then
                        _leftRod = _idx - 1
                        Exit For
                    End If
                Next

                Dim _rightRod As Integer = _numRods - 1
                For _idx As Integer = _numRods - 2 To 0 Step -1
                    If (0.0 < _profilometerParameter.GetDoubleDisplay(_idx, sRodDepthX)) Then
                        _rightRod = _idx + 1
                        Exit For
                    End If
                Next

                ' Get furrow dimensions
                Dim _depth As Double = _profilometerParameter.GetMaxDoubleDisplay(sRodDepthX)
                Dim _side1 As Double = _profilometerParameter.GetDoubleDisplay(_leftRod, sRodLocationX)
                Dim _side2 As Double = _profilometerParameter.GetDoubleDisplay(_rightRod, sRodLocationX)

                ' Draw profilometer furrow
                'Dim _xOffset As Double = ((mMaxWidth - _width) / 2.0) - _side1
                Dim _xOffset As Double = (mMaxWidth - _side2 - _side1) / 2.0
                Dim _yOffset As Double = mRect.Top

                Dim _obx, _oby As Integer

                For _idx As Integer = _leftRod To _rightRod
                    Dim _x As Double = _profilometerParameter.GetDoubleDisplay(_idx, sRodLocationX)
                    Dim _y As Double = _profilometerParameter.GetDoubleDisplay(_idx, sRodDepthX)

                    Dim _tx As Integer = CInt(mRect.Left + (((_xOffset + _x) * mRect.Width) / mMaxWidth))
                    Dim _bx As Integer = _tx

                    Dim _ty As Integer = mRect.Top
                    Dim _by As Integer = mRect.Top + YLoc(_depth - _y)

                    If (_leftRod < _idx) Then
                        _graphics.DrawLine(mGrayPen, _obx, _oby, _bx, _by)
                    End If

                    _obx = _bx
                    _oby = _by
                Next

                ' Draw the profilometer label
                Dim _title As String = mDictionary.tProfilometerTable.Translated
                mSize = _graphics.MeasureString(_title, Me.Font)
                _graphics.DrawString(_title, Me.Font, mBlackBrush, _rect.X, _rect.Y + mMargin - 1)

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub DrawTrapezoidGraph(ByVal _graphics As Graphics, ByVal _rect As Rectangle)

        ' Ignore errors while drawing graph
        Try
            ' Get trapezoid data (in ft|m)
            Dim _botWidth As Double = Me.TrapezoidBottomWidthControl.Value
            Dim _depth As Double = Me.TrapezoidMaximumDepthControl.Value
            Dim _slope As Double = Me.TrapezoidSideSlopeControl.Value

            Dim _topWidth As Double = _botWidth + (_slope * _depth * 2.0)

            ' Compute trapezoid furrow
            Dim _tx As Integer = CInt(((mMaxWidth - _topWidth) * mRect.Width) / (mMaxWidth * 2.0)) ' Top delta
            Dim _bx As Integer = CInt(((mMaxWidth - _botWidth) * mRect.Width) / (mMaxWidth * 2.0)) ' Bottom delta

            Dim _ty As Integer = CInt(((mMaxHeight - _depth) * mRect.Height) / mMaxHeight)
            Dim _by As Integer = mRect.Height

            Dim _point1 As Point = New Point(mRect.X + _tx, mRect.Y + _ty)
            Dim _point2 As Point = New Point(mRect.X + _bx, mRect.Y + _by)
            Dim _point3 As Point = New Point(mRect.X + mRect.Width - _bx, mRect.Y + _by)
            Dim _point4 As Point = New Point(mRect.X + mRect.Width - _tx, mRect.Y + _ty)

            ' Draw trapezoid
            Dim _crossSection As Point() = {_point1, _point2, _point3, _point4}

            _graphics.DrawLines(mBlackPen, _crossSection)

            ' Draw the trapezoid label
            Dim _title As String = mDictionary.tTrapezoid.Translated
            mSize = _graphics.MeasureString(_title, mBold)
            _graphics.DrawString(_title, mBold, mBlackBrush, _rect.Width - mSize.Width - 8, _rect.Y + mMargin - 1)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub DrawPowerLawGraph(ByVal _graphics As Graphics, ByVal _rect As Rectangle)

        ' Ignore errors while drawing graph
        Try
            ' Get power law data (in ft|m)
            Dim _widthAt100mm As Double = Me.PowerLawWidth100mmControl.Value
            Dim _depth As Double = Me.PowerLawMaximumDepthControl.Value
            Dim _exponent As Double = Me.PowerLawExponentControl.Value

            ' Compute C using:  C = W@100mm / 100mm^e
            Dim _const As Double = _widthAt100mm
            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    _const /= ((100.0 / MillimetersPerFoot) ^ _exponent)
                Case Units.Inches
                    _const /= ((100.0 / MillimetersPerInch) ^ _exponent)
                Case Units.Meters
                    _const /= ((100.0 / MillimetersPerMeter) ^ _exponent)
                Case Units.Centimeters
                    _const /= ((100.0 / MillimetersPerCentimeter) ^ _exponent)
                Case Else ' Units.Millimeters
                    _const /= (100.0 ^ _exponent)
            End Select

            ' Compute top width using:  Wtop = C * D^e
            Dim _topWidth As Double = _const * (_depth ^ _exponent)

            ' Compute & draw power law furrow
            Dim _depthPoints As Integer = CInt((mRect.Height * _depth) / mMaxHeight)
            Dim _widthPoints As Integer = CInt((mRect.Width * _topWidth) / mMaxWidth)

            Dim _center As Integer = CInt(mRect.X + (mRect.Width / 2))  ' Center of furrow
            Dim _bottom As Integer = CInt(mRect.Y + mRect.Height)       ' Bottom of furrow

            Dim x1l As Integer = _center    ' x - left half
            Dim x1r As Integer = _center    ' x - right half
            Dim x2l, x2r As Integer

            Dim y1 As Integer = _bottom
            Dim y2 As Integer

            For _pt As Integer = 1 To _depthPoints
                Dim _d As Double = (_depth * _pt) / _depthPoints
                Dim _w As Double = (_const * (_d ^ _exponent)) / 2.0

                Dim _dw As Integer = CInt((_w * _widthPoints) / _topWidth)

                y2 = _bottom - _pt

                ' Draw left half of power law curve
                x2l = _center - _dw
                _graphics.DrawLine(mBlackPen, x1l, y1, x2l, y2)

                ' Draw right half of power law curve
                x2r = _center + _dw
                _graphics.DrawLine(mBlackPen, x1r, y1, x2r, y2)

                x1l = x2l
                x1r = x2r
                y1 = y2
            Next

            ' Draw the power law label
            Dim _title As String = mDictionary.tPowerLaw.Translated
            mSize = _graphics.MeasureString(_title, mBold)
            _graphics.DrawString(_title, mBold, mBlackBrush, _rect.Width - mSize.Width - 8, _rect.Y + mMargin - 1)

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Match Furrow Cross Sections "

    Private Sub CalcAndSaveTrapezoid(ByVal _y As ArrayList, ByVal _w As ArrayList)

        If (mInitializing) Then ' calculation will probably cause Exception
            Return
        End If

        Try
            ' Find Maximum Height
            Dim _maxHeight As Double = 5.0 * OneMillimeter
            For _idx As Integer = 0 To _y.Count - 1
                Dim _yi As Double = CDbl(_y(_idx))    ' Height
                Dim _wi As Double = CDbl(_w(_idx))    ' Width

                ' Save Maximum Height
                If (_maxHeight < _yi) Then
                    _maxHeight = _yi
                End If
            Next

            ' Use Regression to fit Heights/Widths to Trapezoid
            Dim _a As Double
            Dim _b As Double
            LinearFit(_y, _w, _a, _b)

            ' Set Power Law furrow data (in Display Units)
            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.TrapezoidSideSlopeControl.Value = CDec(Math.Abs(_b / 2.0))
                    Me.TrapezoidMaximumDepthControl.Value = CDec(_maxHeight * FeetPerMeter)
                    Me.TrapezoidBottomWidthControl.Value = CDec(_a * FeetPerMeter)
                Case Units.Inches
                    Me.TrapezoidSideSlopeControl.Value = CDec(Math.Abs(_b / 2.0))
                    Me.TrapezoidMaximumDepthControl.Value = CDec(_maxHeight * InchesPerMeter)
                    Me.TrapezoidBottomWidthControl.Value = CDec(_a * InchesPerMeter)
                Case Units.Meters
                    Me.TrapezoidSideSlopeControl.Value = CDec(Math.Abs(_b / 2.0))
                    Me.TrapezoidMaximumDepthControl.Value = CDec(_maxHeight)
                    Me.TrapezoidBottomWidthControl.Value = CDec(_a)
                Case Units.Centimeters
                    Me.TrapezoidSideSlopeControl.Value = CDec(Math.Abs(_b / 2.0))
                    Me.TrapezoidMaximumDepthControl.Value = CDec(_maxHeight * CentimetersPerMeter)
                    Me.TrapezoidBottomWidthControl.Value = CDec(_a * CentimetersPerMeter)
                Case Else ' units.Millimeters
                    Me.TrapezoidSideSlopeControl.Value = CDec(Math.Abs(_b / 2.0))
                    Me.TrapezoidMaximumDepthControl.Value = CDec(_maxHeight * MillimetersPerMeter)
                    Me.TrapezoidBottomWidthControl.Value = CDec(_a * MillimetersPerMeter)
            End Select

        Catch ex As Exception
            If Not (mInitializing) Then
                If (Me.FurrowShapeControl.SelectedIndex = Globals.FurrowShapes.Trapezoid) Then
                    Dim _title As String = mDictionary.tErrTrapezoidCalculations.Translated

                    Dim _message As String = mDictionary.tErrParametersCannotBeFitted.Translated _
                                 + Chr(13) _
                                 + Chr(13) + mDictionary.tErrAdjustParametersManually.Translated

                    MsgBox(_message, MsgBoxStyle.Exclamation, _title)
                End If
            End If
        End Try

        ' Set background color to indicate values were calculated
        mTrapezoidSideSlopeSource = DataStore.Globals.ValueSources.Calculated
        mTrapezoidBottomWidthSource = DataStore.Globals.ValueSources.Calculated
        mTrapezoidMaximumDepthSource = DataStore.Globals.ValueSources.Calculated

    End Sub

    Private Sub CalcAndSavePowerLaw(ByVal _y As ArrayList, ByVal _w As ArrayList)

        If (mInitializing) Then ' calculation will probably cause Exception
            Return
        End If

        Try
            ' Check Minimum Height/Width; find Maximum Height
            Dim _maxHeight As Double = 5.0 * OneMillimeter
            For _idx As Integer = 0 To _y.Count - 1
                Dim _yi As Double = CDbl(_y(_idx))    ' Height
                Dim _wi As Double = CDbl(_w(_idx))    ' Width

                ' Save Maximum Height
                If (_maxHeight < _yi) Then
                    _maxHeight = _yi
                End If

                ' Minimum Height is 5mm
                If (_yi < 5.0 * OneMillimeter) Then
                    _yi = 5.0 * OneMillimeter
                    _y(_idx) = _yi
                End If

                ' Minimum Width is 10mm
                If (_wi < OneCentimeter) Then
                    _wi = OneCentimeter
                    _w(_idx) = _wi
                End If
            Next

            ' Use Regression to fit Heights/Widths to Power Law
            Dim _C As Double
            Dim _M As Double
            PowerFit(_y, _w, _C, _M)

            ' Set Power Law furrow data (in Display Units)
            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    Me.PowerLawExponentControl.Value = CDec(_M)
                    Me.PowerLawMaximumDepthControl.Value = CDec(_maxHeight * FeetPerMeter)
                    Me.PowerLawWidth100mmControl.Value = CDec((_C * (Depth100mm ^ _M)) * FeetPerMeter)
                Case Units.Inches
                    Me.PowerLawExponentControl.Value = CDec(_M)
                    Me.PowerLawMaximumDepthControl.Value = CDec(_maxHeight * InchesPerMeter)
                    Me.PowerLawWidth100mmControl.Value = CDec((_C * (Depth100mm ^ _M)) * InchesPerMeter)
                Case Units.Meters
                    Me.PowerLawExponentControl.Value = CDec(_M)
                    Me.PowerLawMaximumDepthControl.Value = CDec(_maxHeight)
                    Me.PowerLawWidth100mmControl.Value = CDec(_C * (Depth100mm ^ _M))
                Case Units.Centimeters
                    Me.PowerLawExponentControl.Value = CDec(_M)
                    Me.PowerLawMaximumDepthControl.Value = CDec(_maxHeight * CentimetersPerMeter)
                    Me.PowerLawWidth100mmControl.Value = CDec((_C * (Depth100mm ^ _M)) * CentimetersPerMeter)
                Case Else ' units.Millimeters
                    Me.PowerLawExponentControl.Value = CDec(_M)
                    Me.PowerLawMaximumDepthControl.Value = CDec(_maxHeight * MillimetersPerMeter)
                    Me.PowerLawWidth100mmControl.Value = CDec((_C * (Depth100mm ^ _M)) * MillimetersPerMeter)
            End Select

        Catch ex As Exception
            If Not (mInitializing) Then
                If (Me.FurrowShapeControl.SelectedIndex = Globals.FurrowShapes.PowerLaw) Then
                    Dim _title As String = mDictionary.tErrPowerLawCalculations.Translated

                    Dim _message As String = mDictionary.tErrParametersCannotBeFitted.Translated _
                                 + Chr(13) _
                                 + Chr(13) + mDictionary.tErrAdjustParametersManually.Translated

                    MsgBox(_message, MsgBoxStyle.Exclamation, _title)
                End If
            End If
        End Try

        ' Set background color to indicate values were calculated
        mPowerLawExponentSource = DataStore.Globals.ValueSources.Calculated
        mPowerLawMaximumDepthSource = DataStore.Globals.ValueSources.Calculated
        mPowerLawWidthAt100mmSource = DataStore.Globals.ValueSources.Calculated

    End Sub

    Private Sub CalcFurrowFromProfilometer()

        If (mInitializing) Then ' calculation will probably cause Exception
            Return
        End If

        If Not (mProfilometerPropertyNode Is Nothing) Then
            ' Get Profilometer data
            Dim _profilometerParameter As DataTableParameter = mProfilometerPropertyNode.GetDataTableParameter
            Dim _numRods As Integer = _profilometerParameter.Value.Rows.Count

            ' Find furrow edges
            Dim _leftRod As Integer = 0
            For _idx As Integer = 1 To _numRods - 1
                Dim _rodDepth As Double = CDbl(_profilometerParameter.Value.Rows(_idx).Item(sRodDepthX))
                If (0.0 < _rodDepth) Then
                    _leftRod = _idx - 1
                    Exit For
                End If
            Next

            Dim _rightRod As Integer = _numRods - 1
            For _idx As Integer = _numRods - 2 To 0 Step -1
                Dim _rodDepth As Double = CDbl(_profilometerParameter.Value.Rows(_idx).Item(sRodDepthX))
                If (0.0 < _rodDepth) Then
                    _rightRod = _idx + 1
                    Exit For
                End If
            Next

            Dim _centerRod As Integer = CInt((_leftRod + _rightRod) / 2)

            ' Get furrow dimensions
            Dim _depth As Double = _profilometerParameter.GetMaxDoubleSI(sRodDepthX)
            Dim _leftEdge As Double = _profilometerParameter.GetDoubleSI(_leftRod, sRodLocationX)
            Dim _rightEdge As Double = _profilometerParameter.GetDoubleSI(_rightRod, sRodLocationX)
            Dim _center As Double = (_leftEdge + _rightEdge) / 2.0

            ' Build corresponding Height / Width arrays
            Dim _y As ArrayList = New ArrayList ' Heights
            Dim _ly, _ry, _yi As Double
            Dim _w As ArrayList = New ArrayList ' Widths
            Dim _lw, _rw, _wi As Double

            Dim _lastYi As Double = Double.MaxValue
            For _idx As Integer = 0 To _centerRod - _leftRod
                ' Get the average depth
                _ly = CDbl(_profilometerParameter.Value.Rows(_leftRod + _idx).Item(sRodDepthX))
                _ry = CDbl(_profilometerParameter.Value.Rows(_rightRod - _idx).Item(sRodDepthX))
                _yi = _depth - ((_ly + _ry) / 2.0)

                ' Get the width
                _lw = Math.Abs(CDbl(_profilometerParameter.Value.Rows(_leftRod + _idx).Item(sRodLocationX)) - _center)
                _rw = Math.Abs(CDbl(_profilometerParameter.Value.Rows(_rightRod - _idx).Item(sRodLocationX)) - _center)
                _wi = _lw + _rw

                ' Width must be at least 10mm
                If (OneCentimeter <= _wi) Then
                    _y.Add(_yi)
                    _w.Add(_wi)
                    ' Stop when Depth is less than 10mm
                    If (_yi < OneCentimeter) Then
                        Exit For
                    End If
                End If
            Next

            ' Fit to Trapezoid furrow
            CalcAndSaveTrapezoid(_y, _w)

            ' Fit to Power Law furrow  (W = Cy^M)
            CalcAndSavePowerLaw(_y, _w)
        End If

    End Sub

    Private Sub CalcFurrowFromWidthTable()

        If (mInitializing) Then ' calculation will probably cause Exception
            Return
        End If

        ' Get Flow Cross Section furrow data (in SI Units)
        Dim _topWidth As Double = Me.TopWidthControl.Value
        Dim _midWidth As Double = Me.MiddleWidthControl.Value
        Dim _botWidth As Double = Me.BottomWidthControl.Value
        Dim _maxDepth As Double = Me.MaxDepthControl.Value

        Select Case (mUnitsSystem.ShapeUnits)
            Case Units.Feet
                _topWidth /= FeetPerMeter
                _midWidth /= FeetPerMeter
                _botWidth /= FeetPerMeter
                _maxDepth /= FeetPerMeter
            Case Units.Inches
                _topWidth /= InchesPerMeter
                _midWidth /= InchesPerMeter
                _botWidth /= InchesPerMeter
                _maxDepth /= InchesPerMeter
            Case Units.Meters
            Case Units.Centimeters
                _topWidth /= CentimetersPerMeter
                _midWidth /= CentimetersPerMeter
                _botWidth /= CentimetersPerMeter
                _maxDepth /= CentimetersPerMeter
            Case Else ' Units.Millimeters
                _topWidth /= MillimetersPerMeter
                _midWidth /= MillimetersPerMeter
                _botWidth /= MillimetersPerMeter
                _maxDepth /= MillimetersPerMeter
        End Select

        ' Build corresponding Height / Width arrays
        Dim _y As ArrayList = New ArrayList ' Heights
        Dim _w As ArrayList = New ArrayList ' Widths

        _y.Add(_maxDepth)
        _w.Add(_topWidth)
        _y.Add(_maxDepth / 2.0)
        _w.Add(_midWidth)
        _y.Add(0.0)
        _w.Add(_botWidth)

        ' Fit to Trapezoid furrow
        CalcAndSaveTrapezoid(_y, _w)

        ' Fit to Power Law furrow  (W = Cy^M)
        CalcAndSavePowerLaw(_y, _w)

    End Sub

    Private Sub CalcFurrowFromDepthWidthTable()

        If (mInitializing) Then ' calculation will probably cause Exception
            Return
        End If

        If Not (mDepthWidthPropertyNode Is Nothing) Then
            ' Get Depth / Width data
            Dim _depthWidthParameter As DataTableParameter = mDepthWidthPropertyNode.GetDataTableParameter
            Dim _numWidths As Integer = _depthWidthParameter.Value.Rows.Count

            ' Build corresponding Depth / Width arrays
            Dim _y As ArrayList = New ArrayList ' Depths
            Dim _yi As Double
            Dim _w As ArrayList = New ArrayList ' Widths
            Dim _wi As Double

            For _idx As Integer = 0 To _numWidths - 1
                _yi = CDbl(_depthWidthParameter.Value.Rows(_idx).Item(sDepthX))
                _wi = CDbl(_depthWidthParameter.Value.Rows(_idx).Item(sWidthX))
                _y.Add(_yi)
                _w.Add(_wi)
            Next

            ' Fit to Trapezoid furrow
            CalcAndSaveTrapezoid(_y, _w)

            ' Fit to Power Law furrow  (W = Cy^M)
            CalcAndSavePowerLaw(_y, _w)
        End If

    End Sub

#End Region

#End Region

#Region " UI Event Handlers "

#Region " File Menu "
    '
    ' Clear the previously popup added menu items
    '
    Private Sub ClearFileMenuPopupItems()
        ' Delete all menu items after the FileMenuPopupSeparator
        For _idx As Integer = Me.FileMenu.MenuItems.Count - 1 To 0 Step -1
            Dim _menuItem As MenuItem = Me.FileMenu.MenuItems(_idx)
            If (_menuItem Is Me.FileMenuPopupSeparator) Then
                Exit For
            Else
                Me.FileMenu.MenuItems.RemoveAt(_idx)
            End If
        Next
    End Sub
    '
    ' Recursive method for adding sub-items to the File Menu
    '
    Private Sub AddFileMenuPopupItems(ByVal _control As Control)

        If Not (_control Is Nothing) Then
            If (_control.Visible) Then
                ' DataTableParameter controls have sub-items
                If (_control.GetType Is GetType(ctl_DataTableParameter)) Then
                    ' Make separator visible
                    FileMenuPopupSeparator.Visible = True
                    ' Get reference to DataTable control
                    Dim _dataTableCtrl As ctl_DataTableParameter = DirectCast(_control, ctl_DataTableParameter)
                    ' Add item to File Menu for this DataTable
                    Dim _fileMenuItem As MenuItem = FileMenu.MenuItems.Add(_dataTableCtrl.CaptionText)
                    ' Add the sub-items for this DataTable
                    _dataTableCtrl.FileMenu_Popup(_fileMenuItem)
                Else
                    ' Recursively call method to scan contained controls
                    For Each _ctrl As Control In _control.Controls
                        AddFileMenuPopupItems(_ctrl)
                    Next
                End If
            End If
        End If

    End Sub
    '
    ' Adjust File Menu to match current display
    '
    Private Sub FileMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileMenu.Popup
        ' Get Focus to force update of pending user data changes.  Most controls use LostFocus
        ' as a signal to save user data changes.
        Me.Focus()

        ' Add File submenus
        FileMenuPopupSeparator.Visible = False
        ClearFileMenuPopupItems()
        AddFileMenuPopupItems(Me)

    End Sub

    Private Sub FileSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileSaveItem.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub FileCloseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileCloseItem.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ButtonSave.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ButtonCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

#End Region

#Region " Edit Menu "
    '
    ' Clear the previously popup added menu items
    '
    Private Sub ClearEditMenuPopupItems()
        ' Delete all menu items after the EditMenuPopupSeparator
        For _idx As Integer = Me.EditMenu.MenuItems.Count - 1 To 0 Step -1
            Dim _menuItem As MenuItem = Me.EditMenu.MenuItems(_idx)
            If (_menuItem Is Me.EditMenuPopupSeparator) Then
                Exit For
            Else
                Me.EditMenu.MenuItems.RemoveAt(_idx)
            End If
        Next
    End Sub
    '
    ' Recursive method for adding sub-items to the Edit Menu
    '
    Private Sub AddEditMenuPopupItems(ByVal _control As Control)

        If Not (_control Is Nothing) Then
            If (_control.Visible) Then
                ' DataTableParameter controls have sub-items
                If (_control.GetType Is GetType(ctl_DataTableParameter)) Then
                    ' Make separator visible
                    EditMenuPopupSeparator.Visible = True
                    ' Get reference to DataTable control
                    Dim _dataTableCtrl As ctl_DataTableParameter = DirectCast(_control, ctl_DataTableParameter)
                    ' Add item to Edit Menu for this DataTable
                    Dim _editMenuItem As MenuItem = EditMenu.MenuItems.Add(_dataTableCtrl.CaptionText)
                    ' Add the sub-items for this DataTable
                    _dataTableCtrl.EditMenu_Popup(_editMenuItem)
                Else
                    ' Recursively call method to scan contained controls
                    For Each _ctrl As Control In _control.Controls
                        AddEditMenuPopupItems(_ctrl)
                    Next
                End If
            End If
        End If

    End Sub
    '
    ' Adjust Edit Menu to match current display
    '
    Private Sub EditMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditMenu.Popup
        ' Get Focus to force update of pending user data changes.  Most controls use LostFocus
        ' as a signal to save user data changes.
        Me.Focus()

        ' Build the 'Copy Bitmap' items
        EditCopyBitmapItem.MenuItems.Clear()
        AddPictureBoxCopyItems(EditCopyBitmapItem, Me)

        If (0 < EditCopyBitmapItem.MenuItems.Count) Then
            EditCopyBitmapItem.Enabled = True
        Else
            EditCopyBitmapItem.Enabled = False
        End If

        ' Add edit submenus
        ClearEditMenuPopupItems()
        EditMenuPopupSeparator.Visible = False
        AddEditMenuPopupItems(Me)

    End Sub

#End Region

#Region " Help "

    Private Sub FurrowFieldData_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:FurrowGeometry", 1400)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:FurrowGeometry", 1400)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#Region " Field Data "

    Private Sub FurrowFieldDataType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FurrowFieldDataTypeControl.SelectedIndexChanged

        Select Case (Me.FurrowFieldDataTypeControl.SelectedIndex)
            Case FurrowFieldDataTypes.ProfilometerTable
                Me.CalcFurrowFromProfilometer()
            Case FurrowFieldDataTypes.DepthWidthTable
                Me.CalcFurrowFromDepthWidthTable()
            Case Else ' Assume FurrowFieldDataTypes.WidthTable
                Me.CalcFurrowFromWidthTable()
        End Select

        Me.UpdateUI()
    End Sub

    Private Sub FurrowShape_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FurrowShapeControl.SelectedIndexChanged
        Me.UpdateUI()
    End Sub

#End Region

#Region " Profilometer Data "
    '
    ' Number of Rods
    '
    Private mUpdatingNumberOfRods As Boolean = False
    Private Sub UpdateNumberOfRods()

        ' Only update Number of Rods if value has changed
        If (mNumberOfRods = CInt(Me.NumberOfRodsControl.Value)) Then
            Return
        End If

        If Not (mProfilometerPropertyNode Is Nothing) Then
            If Not (mUpdatingNumberOfRods) Then
                mUpdatingNumberOfRods = True
                NumberOfRods = CInt(Me.NumberOfRodsControl.Value)

                Dim _parameter As DataTableParameter = mProfilometerPropertyNode.GetDataTableParameter
                If Not (_parameter Is Nothing) Then

                    Dim _profilometerData As DataTable = _parameter.Value
                    If Not (_profilometerData Is Nothing) Then

                        ' Insert new Rod rows, if necessary
                        While (_profilometerData.Rows.Count < NumberOfRods)
                            Dim _loc As Integer = CInt(_profilometerData.Rows.Count / 2)
                            Dim _rodRow As DataRow = _profilometerData.Rows(_loc)
                            Dim _newRow As DataRow = _profilometerData.NewRow
                            _newRow.Item(sRodDepthX) = _rodRow.Item(sRodDepthX)
                            _profilometerData.Rows.InsertAt(_newRow, _loc)
                        End While

                        ' Remove old Rod rows, if necessary
                        While (NumberOfRods < _profilometerData.Rows.Count)
                            Dim _loc As Integer = CInt(_profilometerData.Rows.Count / 2)
                            _profilometerData.Rows.RemoveAt(_loc)
                        End While

                        ' Reset Location column values
                        Dim _rodSpacing As Double = Me.RodSpacingControl.Value
                        Select Case (mUnitsSystem.ShapeUnits)
                            Case Units.Feet
                                _rodSpacing /= FeetPerMeter
                            Case Units.Inches
                                _rodSpacing /= InchesPerMeter
                            Case Units.Meters
                            Case Units.Centimeters
                                _rodSpacing /= CentimetersPerMeter
                            Case Else ' Units.Millimeters
                                _rodSpacing /= MillimetersPerMeter
                        End Select

                        Dim _firstLoc As Double = -((_rodSpacing * (NumberOfRods - 1)) / 2.0)
                        For _idx As Integer = 0 To _profilometerData.Rows.Count - 1
                            _profilometerData.Rows(_idx).Item(sRodLocationX) = _firstLoc + (_idx * _rodSpacing)
                        Next
                    End If

                End If

                mProfilometerPropertyNode.SetParameter(_parameter)

                Me.CalcFurrowFromProfilometer()
                Me.UpdateUI()

                mUpdatingNumberOfRods = False
            End If
        End If

    End Sub

    Private Sub NumberOfRods_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NumberOfRodsControl.ValueChanged
        UpdateNumberOfRods()
    End Sub

    Private Sub NumberOfRods_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NumberOfRodsControl.LostFocus
        UpdateNumberOfRods()
    End Sub
    '
    ' Rod Spacing
    '
    Private mUpdatingRodSpacing As Boolean = False
    Private Sub UpdateRodSpacing()

        ' Only update Rod Spacing if value has changed
        If (mRodSpacing = Me.RodSpacingControl.Value) Then
            Return
        End If

        If Not (mProfilometerPropertyNode Is Nothing) Then
            If Not (mUpdatingRodSpacing) Then
                mUpdatingRodSpacing = True
                RodSpacing = Me.RodSpacingControl.Value

                Dim _parameter As DataTableParameter = mProfilometerPropertyNode.GetDataTableParameter
                If Not (_parameter Is Nothing) Then

                    Dim _profilometerData As DataTable = _parameter.Value
                    If Not (_profilometerData Is Nothing) Then

                        ' Reset Location column values
                        Dim _rodSpacing As Double = Me.RodSpacingControl.Value
                        Select Case (mUnitsSystem.ShapeUnits)
                            Case Units.Feet
                                _rodSpacing /= FeetPerMeter
                            Case Units.Inches
                                _rodSpacing /= InchesPerMeter
                            Case Units.Meters
                            Case Units.Centimeters
                                _rodSpacing /= CentimetersPerMeter
                            Case Else ' Units.Millimeters
                                _rodSpacing /= MillimetersPerMeter
                        End Select

                        Dim _firstLoc As Double = -((_rodSpacing * (NumberOfRodsControl.Value - 1)) / 2.0)
                        For _idx As Integer = 0 To _profilometerData.Rows.Count - 1
                            _profilometerData.Rows(_idx).Item(sRodLocationX) = _firstLoc + (_idx * _rodSpacing)
                        Next
                    End If

                End If

                mProfilometerPropertyNode.SetParameter(_parameter)

                Me.CalcFurrowFromProfilometer()
                Me.UpdateUI()

                mUpdatingRodSpacing = False
            End If
        End If

    End Sub

    Private Sub RodSpacing_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RodSpacingControl.ValueChanged
        UpdateRodSpacing()
    End Sub

    Private Sub RodSpacing_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RodSpacingControl.LostFocus
        UpdateRodSpacing()
    End Sub
    '
    ' Profilometer Data Table
    '

    ' Pre-Save verification
    Private Sub ProfilometerDataControl_PreSaveAction(ByVal _profilometerData As DataTable, _
                                                      ByRef _saveOK As Boolean) _
    Handles ProfilometerDataControl.PreSaveAction

        If Not (_profilometerData Is Nothing) Then

            Dim _numRods As Integer = _profilometerData.Rows.Count

            ' Find furrow edges
            Dim _leftRod As Integer = 0
            For _idx As Integer = 1 To _numRods - 1
                Dim _rodDepth As Double = CDbl(_profilometerData.Rows(_idx).Item(sRodDepthX))
                If (0.0 < _rodDepth) Then
                    _leftRod = _idx - 1
                    Exit For
                End If
            Next

            Dim _rightRod As Integer = _numRods - 1
            For _idx As Integer = _numRods - 2 To 0 Step -1
                Dim _rodDepth As Double = CDbl(_profilometerData.Rows(_idx).Item(sRodDepthX))
                If (0.0 < _rodDepth) Then
                    _rightRod = _idx + 1
                    Exit For
                End If
            Next

            Dim _centerRod As Integer = CInt((_leftRod + _rightRod) / 2)

            ' Get furrow depths
            Dim _leftY As Double = CDbl(_profilometerData.Rows(_leftRod).Item(sRodDepthX))
            Dim _rightY As Double = CDbl(_profilometerData.Rows(_rightRod).Item(sRodDepthX))
            Dim _centerY As Double = CDbl(_profilometerData.Rows(_centerRod).Item(sRodDepthX))

            ' Check if Depth data is inverted
            If ((_leftY > _centerY) And (_centerY < _rightY)) Then
                ' Depth data appears to be inverted

                Dim _title As String = mDictionary.tErrProfilometerDataVerification.Translated

                Dim _message As String = mDictionary.tErrProfilometerDepthDataInverted.Translated _
                             + Chr(13) _
                             + Chr(13) + mDictionary.tErrContinuingWillInvertDepthData.Translated _
                             + Chr(13) _
                             + Chr(13) + mDictionary.tDoYouWantToContinue.Translated

                Dim _result As MsgBoxResult = MsgBox(_message, _
                                              MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel, _
                                              _title)

                If (_result = MsgBoxResult.Ok) Then
                    ' Invert & save the new data
                    Dim _maxDepth As Double = DataStore.Utilities.DataColumnMax(_profilometerData, sRodDepthX)

                    For Each _dataRow As DataRow In _profilometerData.Rows
                        Dim _depth As Double = CDbl(_dataRow.Item(sRodDepthX))
                        _dataRow.Item(sRodDepthX) = _maxDepth - _depth
                    Next
                Else
                    ' Don't save the new data
                    _saveOK = False
                    Return
                End If
            End If
        End If

        _saveOK = True

    End Sub

    ' Post-Save udpates
    Private Sub ProfilometerDataControl_ControlValueChanged() _
    Handles ProfilometerDataControl.ControlValueChanged
        If Not (mProfilometerPropertyNode Is Nothing) Then

            mInitializing = True

            ' Update No. of Rods, if necessary
            Dim _noOfRods As Integer = ProfilometerTable.Rows.Count
            If Not (Me.NumberOfRodsControl.Value = _noOfRods) Then
                Me.NumberOfRodsControl.Value = _noOfRods
            End If

            ' Update Rod Spacing, if necessary
            Dim _row0 As DataRow = ProfilometerTable.Rows(0)
            Dim _row1 As DataRow = ProfilometerTable.Rows(1)
            Dim _loc0 As Double = CDbl(_row0.Item(sRodLocationX))
            Dim _loc1 As Double = CDbl(_row1.Item(sRodLocationX))

            Dim _rodSpacing As Double = Math.Abs(_loc1 - _loc0)
            Select Case (mUnitsSystem.ShapeUnits)
                Case Units.Feet
                    _rodSpacing *= FeetPerMeter
                Case Units.Inches
                    _rodSpacing *= InchesPerMeter
                Case Units.Meters
                Case Units.Centimeters
                    _rodSpacing *= CentimetersPerMeter
                Case Else ' Units.Millimeters
                    _rodSpacing *= MillimetersPerMeter
            End Select

            If Not (ThisClose(Me.RodSpacingControl.Value, _rodSpacing, 0.0005)) Then
                Me.RodSpacingControl.Value = CDec(_rodSpacing)
            End If

            mInitializing = False

            mProfilometerUpdating = True
            Me.CalcFurrowFromProfilometer()
            Me.UpdateUI()
            mProfilometerUpdating = False
        End If
    End Sub

#End Region

#Region " Depth / Width Data "
    '
    ' Depth / Width Data Table
    '
    Private Sub DepthWidthControl_ControlValueChanged() _
    Handles DepthWidthControl.ControlValueChanged
        If Not (mDepthWidthPropertyNode Is Nothing) Then
            ' Re-calc the Furrow cross section & Update UI
            mDepthWidthUpdating = True
            Me.CalcFurrowFromDepthWidthTable()
            Me.UpdateUI()
            mDepthWidthUpdating = False
        End If
    End Sub
    '
    ' Reset table to Top / Middle / Bottom depths
    '
    Private Sub SetTopMidBotButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SetTopMidBotButton.Click

        If Not (mDepthWidthPropertyNode Is Nothing) Then
            Dim _depthWidthParameter As DataTableParameter = mDepthWidthPropertyNode.GetDataTableParameter

            If Not (_depthWidthParameter Is Nothing) Then
                Dim _depthWidthTable As DataTable = _depthWidthParameter.Value

                ' Get the Maximum Depth
                Dim _maxDepth As Double = DataStore.Utilities.DataColumnMax(_depthWidthTable, sDepthX)
                If (_maxDepth = Double.MinValue) Then
                    _maxDepth = DefaultSectionDepth
                End If

                Dim _shapeUnits As Units = mUnitsSystem.ShapeUnits
                Dim _getDepth As db_GetDoubleValue = New db_GetDoubleValue(_maxDepth, _shapeUnits)

                _getDepth.Title = mDictionary.tMaxDepth.Translated
                _getDepth.Instructions = mDictionary.tEnterFurrowMaximumDepth.Translated
                _getDepth.MinValue = OneDecimeter
                _getDepth.MaxValue = OneMeter

                Dim _results As DialogResult = _getDepth.ShowDialog

                If (_results = DialogResult.OK) Then
                    _maxDepth = _getDepth.Value
                Else
                    Return
                End If

                ' Get the Top / Bottom Widths
                Dim _topWidth As Double = DefaultTopSectionWidth
                Dim _botWidth As Double = DefaultBottomSectionWidth

                If Not (_depthWidthTable Is Nothing) Then
                    If (0 < _depthWidthTable.Rows.Count) Then
                        ' Start with Width from first Depth
                        Dim _dataRow As DataRow = _depthWidthTable.Rows(0)
                        Dim _width As Double = CDbl(_dataRow.Item(sWidthX))

                        _topWidth = _width
                        _botWidth = _width

                        ' Scan remaining Depths for better values
                        For _idx As Integer = 1 To _depthWidthTable.Rows.Count - 1
                            _dataRow = _depthWidthTable.Rows(_idx)
                            _width = CDbl(_dataRow.Item(sWidthX))

                            ' Save maximum width as Top Width
                            If (_topWidth < _width) Then
                                _topWidth = _width
                            End If

                            ' Save minimum width as Bottom Width
                            If (_botWidth > _width) Then
                                _botWidth = _width
                            End If
                        Next

                    End If
                Else
                    ' If no DataTable, create one
                    _depthWidthTable = New DataTable(SystemGeometry.sDepthWidthTable)
                End If

                ' Remove the previous data
                _depthWidthTable.Clear()
                _depthWidthTable.Columns.Clear()

                ' Add the columns
                _depthWidthTable.Columns.Add(sDepthX, GetType(Double))
                _depthWidthTable.Columns.Add(sWidthX, GetType(Double))

                ' Add the rows of reset data
                Dim _depthWidthRow As DataRow = _depthWidthTable.NewRow
                _depthWidthRow.Item(sDepthX) = _maxDepth
                _depthWidthRow.Item(sWidthX) = _topWidth
                _depthWidthTable.Rows.Add(_depthWidthRow)

                _depthWidthRow = _depthWidthTable.NewRow
                _depthWidthRow.Item(sDepthX) = _maxDepth / 2.0
                _depthWidthRow.Item(sWidthX) = (_topWidth + _botWidth) / 2.0
                _depthWidthTable.Rows.Add(_depthWidthRow)

                _depthWidthRow = _depthWidthTable.NewRow
                _depthWidthRow.Item(sDepthX) = 0.0
                _depthWidthRow.Item(sWidthX) = _botWidth
                _depthWidthTable.Rows.Add(_depthWidthRow)
            End If

            ' Save the new data
            mDepthWidthPropertyNode.SetParameter(_depthWidthParameter)

            ' Re-calc the Furrow cross section & Update UI
            Me.CalcFurrowFromDepthWidthTable()
            Me.UpdateUI()
        End If

    End Sub

#End Region

#Region " Cross Section Data "

    Private Sub TopWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TopWidthControl.ValueChanged
        Me.CalcFurrowFromWidthTable()
        Me.UpdateUI()
    End Sub

    Private Sub TopWidth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TopWidthControl.LostFocus
        Me.CalcFurrowFromWidthTable()
        Me.UpdateUI()
    End Sub

    Private Sub MiddleWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MiddleWidthControl.ValueChanged
        Me.CalcFurrowFromWidthTable()
        Me.UpdateUI()
    End Sub

    Private Sub MiddleWidth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MiddleWidthControl.LostFocus
        Me.CalcFurrowFromWidthTable()
        Me.UpdateUI()
    End Sub

    Private Sub BottomWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BottomWidthControl.ValueChanged
        Me.CalcFurrowFromWidthTable()
        Me.UpdateUI()
    End Sub

    Private Sub BottomWidth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BottomWidthControl.LostFocus
        Me.CalcFurrowFromWidthTable()
        Me.UpdateUI()
    End Sub

    Private Sub FlowMaxDepth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MaxDepthControl.ValueChanged
        Me.CalcFurrowFromWidthTable()
        Me.UpdateUI()
    End Sub

    Private Sub FlowMaxDepth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MaxDepthControl.LostFocus
        Me.CalcFurrowFromWidthTable()
        Me.UpdateUI()
    End Sub

#End Region

#Region " Trapezoid Furrow "

    Private Sub TrapezoidBottomWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TrapezoidBottomWidthControl.ValueChanged
        mTrapezoidBottomWidthSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

    Private Sub TrapezoidBottomWidth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TrapezoidBottomWidthControl.LostFocus
        mTrapezoidBottomWidthSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

    Private Sub TrapezoidSideSlope_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TrapezoidSideSlopeControl.ValueChanged
        mTrapezoidSideSlopeSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

    Private Sub TrapezoidSideSlope_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TrapezoidSideSlopeControl.LostFocus
        mTrapezoidSideSlopeSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

    Private Sub TrapezoidMaximumDepth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TrapezoidMaximumDepthControl.ValueChanged
        mTrapezoidMaximumDepthSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

    Private Sub TrapezoidMaximumDepth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TrapezoidMaximumDepthControl.LostFocus
        mTrapezoidMaximumDepthSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

#End Region

#Region " Power Law Furrow "

    Private Sub PowerLawWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PowerLawWidth100mmControl.ValueChanged
        mPowerLawWidthAt100mmSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

    Private Sub PowerLawWidth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PowerLawWidth100mmControl.LostFocus
        mPowerLawWidthAt100mmSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

    Private Sub PowerLawExponent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PowerLawExponentControl.ValueChanged
        mPowerLawExponentSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

    Private Sub PowerLawExponent_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PowerLawExponentControl.LostFocus
        mPowerLawExponentSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

    Private Sub PowerLawMaximumDepth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PowerLawMaximumDepthControl.ValueChanged
        mPowerLawMaximumDepthSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

    Private Sub PowerLawMaximumDepth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PowerLawMaximumDepthControl.LostFocus
        mPowerLawMaximumDepthSource = DataStore.Globals.ValueSources.UserEntered
        Me.UpdateUI()
    End Sub

#End Region

#Region " Form Events "
    '
    ' Shown event is generated by ShowDialog() call
    '
    Private Sub FurrowFieldData_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Shown
        mInitializing = False
        UpdateTranslation(Me)

        Select Case (Me.FurrowFieldDataTypeControl.SelectedIndex)
            Case Globals.FurrowFieldDataTypes.ProfilometerTable
                Me.CalcFurrowFromProfilometer()
            Case Globals.FurrowFieldDataTypes.DepthWidthTable
                Me.CalcFurrowFromDepthWidthTable()
            Case Else ' Assume Globals.FurrowFieldDataTypes.WidthTable
                Me.CalcFurrowFromWidthTable()
        End Select

        Me.UpdateUI()
    End Sub

#End Region

#End Region

End Class
