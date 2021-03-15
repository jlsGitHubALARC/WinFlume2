
'**********************************************************************************************
' Control class: ctl_Roughness
'
'   ctl_Roughness provides the UI for viewing & editing Roughness data
'
Imports DataStore
Imports DataStore.DataStore
Imports Srfr.Roughness

Public Class ctl_Roughness
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents RoughnessGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents VegetativeDensityControl As DataStore.ctl_DoubleParameter
    Friend WithEvents RoughnessMethodLabel As DataStore.ctl_Label
    Friend WithEvents RoughnessMethodControl As DataStore.ctl_SelectParameter
    Friend WithEvents NrcsManningNPanel As DataStore.ctl_Panel
    Friend WithEvents Sel_025 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_020 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_015 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_010 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_004 As DataStore.ctl_RadioButton
    Friend WithEvents SayreChiPanel As DataStore.ctl_Panel
    Friend WithEvents SayreChiControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ManningCnAnPanel As DataStore.ctl_Panel
    Friend WithEvents ManningAnControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ManningAnLabel As DataStore.ctl_Label
    Friend WithEvents ManningCnControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ManningCnLabel As DataStore.ctl_Label
    Friend WithEvents VegetativeDensitySelect As DataStore.ctl_CheckParameter
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents RoughnessPhoto As GraphingUI.ex_PictureBox
    Friend WithEvents TabulatedRoughnessSelect As DataStore.ctl_CheckParameter
    Friend WithEvents TabulatedManningNPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedManningNControl As DataStore.ctl_DataTableParameter
    Friend WithEvents TabulatedManningCnAnPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedManningCnAnControl As DataStore.ctl_DataTableParameter
    Friend WithEvents TabulatedSayreChiPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedSayreChiControl As DataStore.ctl_DataTableParameter
    Friend WithEvents NrcsSuggestedLabel As DataStore.ctl_Label
    Friend WithEvents Sel_UserEntered As DataStore.ctl_RadioButton
    Friend WithEvents UsersManningNControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SayreChiLabel As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctl_Roughness))
        Me.RoughnessGroupBox = New DataStore.ctl_GroupBox()
        Me.TabulatedManningNPanel = New DataStore.ctl_Panel()
        Me.TabulatedManningNControl = New DataStore.ctl_DataTableParameter()
        Me.TabulatedSayreChiPanel = New DataStore.ctl_Panel()
        Me.TabulatedSayreChiControl = New DataStore.ctl_DataTableParameter()
        Me.TabulatedManningCnAnPanel = New DataStore.ctl_Panel()
        Me.TabulatedManningCnAnControl = New DataStore.ctl_DataTableParameter()
        Me.TabulatedRoughnessSelect = New DataStore.ctl_CheckParameter()
        Me.VegetativeDensityControl = New DataStore.ctl_DoubleParameter()
        Me.RoughnessPhoto = New GraphingUI.ex_PictureBox()
        Me.VegetativeDensitySelect = New DataStore.ctl_CheckParameter()
        Me.RoughnessMethodLabel = New DataStore.ctl_Label()
        Me.RoughnessMethodControl = New DataStore.ctl_SelectParameter()
        Me.ManningCnAnPanel = New DataStore.ctl_Panel()
        Me.ManningAnControl = New DataStore.ctl_DoubleParameter()
        Me.ManningAnLabel = New DataStore.ctl_Label()
        Me.ManningCnControl = New DataStore.ctl_DoubleParameter()
        Me.ManningCnLabel = New DataStore.ctl_Label()
        Me.SayreChiPanel = New DataStore.ctl_Panel()
        Me.SayreChiControl = New DataStore.ctl_DoubleParameter()
        Me.SayreChiLabel = New DataStore.ctl_Label()
        Me.NrcsManningNPanel = New DataStore.ctl_Panel()
        Me.UsersManningNControl = New DataStore.ctl_DoubleParameter()
        Me.Sel_UserEntered = New DataStore.ctl_RadioButton()
        Me.NrcsSuggestedLabel = New DataStore.ctl_Label()
        Me.Sel_025 = New DataStore.ctl_RadioButton()
        Me.Sel_020 = New DataStore.ctl_RadioButton()
        Me.Sel_015 = New DataStore.ctl_RadioButton()
        Me.Sel_010 = New DataStore.ctl_RadioButton()
        Me.Sel_004 = New DataStore.ctl_RadioButton()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.RoughnessGroupBox.SuspendLayout()
        Me.TabulatedManningNPanel.SuspendLayout()
        CType(Me.TabulatedManningNControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedSayreChiPanel.SuspendLayout()
        CType(Me.TabulatedSayreChiControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedManningCnAnPanel.SuspendLayout()
        CType(Me.TabulatedManningCnAnControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RoughnessPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ManningCnAnPanel.SuspendLayout()
        Me.SayreChiPanel.SuspendLayout()
        Me.NrcsManningNPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'RoughnessGroupBox
        '
        Me.RoughnessGroupBox.AccessibleDescription = ""
        Me.RoughnessGroupBox.AccessibleName = ""
        Me.RoughnessGroupBox.Controls.Add(Me.TabulatedManningNPanel)
        Me.RoughnessGroupBox.Controls.Add(Me.TabulatedSayreChiPanel)
        Me.RoughnessGroupBox.Controls.Add(Me.TabulatedManningCnAnPanel)
        Me.RoughnessGroupBox.Controls.Add(Me.TabulatedRoughnessSelect)
        Me.RoughnessGroupBox.Controls.Add(Me.VegetativeDensityControl)
        Me.RoughnessGroupBox.Controls.Add(Me.RoughnessPhoto)
        Me.RoughnessGroupBox.Controls.Add(Me.VegetativeDensitySelect)
        Me.RoughnessGroupBox.Controls.Add(Me.RoughnessMethodLabel)
        Me.RoughnessGroupBox.Controls.Add(Me.RoughnessMethodControl)
        Me.RoughnessGroupBox.Controls.Add(Me.ManningCnAnPanel)
        Me.RoughnessGroupBox.Controls.Add(Me.SayreChiPanel)
        Me.RoughnessGroupBox.Controls.Add(Me.NrcsManningNPanel)
        Me.RoughnessGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessGroupBox.Location = New System.Drawing.Point(0, 0)
        Me.RoughnessGroupBox.Name = "RoughnessGroupBox"
        Me.RoughnessGroupBox.Size = New System.Drawing.Size(360, 416)
        Me.RoughnessGroupBox.TabIndex = 0
        Me.RoughnessGroupBox.TabStop = False
        Me.RoughnessGroupBox.Text = "Roughness"
        '
        'TabulatedManningNPanel
        '
        Me.TabulatedManningNPanel.Controls.Add(Me.TabulatedManningNControl)
        Me.TabulatedManningNPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedManningNPanel.Location = New System.Drawing.Point(8, 232)
        Me.TabulatedManningNPanel.Name = "TabulatedManningNPanel"
        Me.TabulatedManningNPanel.Size = New System.Drawing.Size(344, 178)
        Me.TabulatedManningNPanel.TabIndex = 8
        '
        'TabulatedManningNControl
        '
        Me.TabulatedManningNControl.AccessibleDescription = "Specifies Manning n value in a tabulated form."
        Me.TabulatedManningNControl.AccessibleName = "Tabulated Manning n"
        Me.TabulatedManningNControl.AllRowsFixed = False
        Me.TabulatedManningNControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedManningNControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedManningNControl.CaptionText = "Roughness Table"
        Me.TabulatedManningNControl.CausesValidation = False
        Me.TabulatedManningNControl.ColumnWidthRatios = Nothing
        Me.TabulatedManningNControl.DataMember = ""
        Me.TabulatedManningNControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedManningNControl.EnableSaveActions = False
        Me.TabulatedManningNControl.FirstColumnIncreases = True
        Me.TabulatedManningNControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedManningNControl.FirstColumnMinimum = 0R
        Me.TabulatedManningNControl.FirstRowFixed = False
        Me.TabulatedManningNControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedManningNControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedManningNControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedManningNControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedManningNControl.MaxRows = 50
        Me.TabulatedManningNControl.MinRows = 1
        Me.TabulatedManningNControl.Name = "TabulatedManningNControl"
        Me.TabulatedManningNControl.PasteDisabled = False
        Me.TabulatedManningNControl.SecondColumnIncreases = False
        Me.TabulatedManningNControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedManningNControl.SecondColumnMinimum = 0R
        Me.TabulatedManningNControl.Size = New System.Drawing.Size(344, 178)
        Me.TabulatedManningNControl.TabIndex = 0
        Me.TabulatedManningNControl.TableReadonly = False
        '
        'TabulatedSayreChiPanel
        '
        Me.TabulatedSayreChiPanel.Controls.Add(Me.TabulatedSayreChiControl)
        Me.TabulatedSayreChiPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedSayreChiPanel.Location = New System.Drawing.Point(8, 232)
        Me.TabulatedSayreChiPanel.Name = "TabulatedSayreChiPanel"
        Me.TabulatedSayreChiPanel.Size = New System.Drawing.Size(344, 178)
        Me.TabulatedSayreChiPanel.TabIndex = 10
        '
        'TabulatedSayreChiControl
        '
        Me.TabulatedSayreChiControl.AccessibleDescription = "Specifies Sayre-Albertson's Chi value in a tubulated form."
        Me.TabulatedSayreChiControl.AccessibleName = "Tabulated Sayre-Albertson's Chi"
        Me.TabulatedSayreChiControl.AllRowsFixed = False
        Me.TabulatedSayreChiControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedSayreChiControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedSayreChiControl.CaptionText = "Roughness Table"
        Me.TabulatedSayreChiControl.CausesValidation = False
        Me.TabulatedSayreChiControl.ColumnWidthRatios = Nothing
        Me.TabulatedSayreChiControl.DataMember = ""
        Me.TabulatedSayreChiControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedSayreChiControl.EnableSaveActions = False
        Me.TabulatedSayreChiControl.FirstColumnIncreases = True
        Me.TabulatedSayreChiControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedSayreChiControl.FirstColumnMinimum = 0R
        Me.TabulatedSayreChiControl.FirstRowFixed = False
        Me.TabulatedSayreChiControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedSayreChiControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedSayreChiControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedSayreChiControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedSayreChiControl.MaxRows = 50
        Me.TabulatedSayreChiControl.MinRows = 1
        Me.TabulatedSayreChiControl.Name = "TabulatedSayreChiControl"
        Me.TabulatedSayreChiControl.PasteDisabled = False
        Me.TabulatedSayreChiControl.SecondColumnIncreases = False
        Me.TabulatedSayreChiControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedSayreChiControl.SecondColumnMinimum = 0R
        Me.TabulatedSayreChiControl.Size = New System.Drawing.Size(344, 178)
        Me.TabulatedSayreChiControl.TabIndex = 0
        Me.TabulatedSayreChiControl.TableReadonly = False
        '
        'TabulatedManningCnAnPanel
        '
        Me.TabulatedManningCnAnPanel.Controls.Add(Me.TabulatedManningCnAnControl)
        Me.TabulatedManningCnAnPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedManningCnAnPanel.Location = New System.Drawing.Point(8, 232)
        Me.TabulatedManningCnAnPanel.Name = "TabulatedManningCnAnPanel"
        Me.TabulatedManningCnAnPanel.Size = New System.Drawing.Size(344, 178)
        Me.TabulatedManningCnAnPanel.TabIndex = 9
        '
        'TabulatedManningCnAnControl
        '
        Me.TabulatedManningCnAnControl.AccessibleDescription = "Specifies Manning Cn/An values in a tabulated form."
        Me.TabulatedManningCnAnControl.AccessibleName = "Tabulated Manning Cn/An"
        Me.TabulatedManningCnAnControl.AllRowsFixed = False
        Me.TabulatedManningCnAnControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedManningCnAnControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedManningCnAnControl.CaptionText = "Roughness Table"
        Me.TabulatedManningCnAnControl.CausesValidation = False
        Me.TabulatedManningCnAnControl.ColumnWidthRatios = Nothing
        Me.TabulatedManningCnAnControl.DataMember = ""
        Me.TabulatedManningCnAnControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedManningCnAnControl.EnableSaveActions = False
        Me.TabulatedManningCnAnControl.FirstColumnIncreases = True
        Me.TabulatedManningCnAnControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedManningCnAnControl.FirstColumnMinimum = 0R
        Me.TabulatedManningCnAnControl.FirstRowFixed = False
        Me.TabulatedManningCnAnControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedManningCnAnControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedManningCnAnControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedManningCnAnControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedManningCnAnControl.MaxRows = 50
        Me.TabulatedManningCnAnControl.MinRows = 1
        Me.TabulatedManningCnAnControl.Name = "TabulatedManningCnAnControl"
        Me.TabulatedManningCnAnControl.PasteDisabled = False
        Me.TabulatedManningCnAnControl.SecondColumnIncreases = False
        Me.TabulatedManningCnAnControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedManningCnAnControl.SecondColumnMinimum = 0R
        Me.TabulatedManningCnAnControl.Size = New System.Drawing.Size(344, 178)
        Me.TabulatedManningCnAnControl.TabIndex = 0
        Me.TabulatedManningCnAnControl.TableReadonly = False
        '
        'TabulatedRoughnessSelect
        '
        Me.TabulatedRoughnessSelect.AccessibleDescription = "Selects whether or not Roughness parameters are entered in a tabulated form."
        Me.TabulatedRoughnessSelect.AccessibleName = "Tabulated Roughness Enable"
        Me.TabulatedRoughnessSelect.AlwaysChecked = False
        Me.TabulatedRoughnessSelect.ErrorMessage = Nothing
        Me.TabulatedRoughnessSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedRoughnessSelect.Location = New System.Drawing.Point(257, 202)
        Me.TabulatedRoughnessSelect.Name = "TabulatedRoughnessSelect"
        Me.TabulatedRoughnessSelect.Size = New System.Drawing.Size(98, 24)
        Me.TabulatedRoughnessSelect.TabIndex = 7
        Me.TabulatedRoughnessSelect.Text = "&Tabulated"
        Me.TabulatedRoughnessSelect.UncheckAttemptMessage = Nothing
        '
        'VegetativeDensityControl
        '
        Me.VegetativeDensityControl.AccessibleDescription = "Specifies crop density that impedes surface flow."
        Me.VegetativeDensityControl.AccessibleName = "Vegetative Density"
        Me.VegetativeDensityControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.VegetativeDensityControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VegetativeDensityControl.IsCalculated = False
        Me.VegetativeDensityControl.IsInteger = False
        Me.VegetativeDensityControl.Location = New System.Drawing.Point(155, 202)
        Me.VegetativeDensityControl.MaxErrMsg = ""
        Me.VegetativeDensityControl.MinErrMsg = ""
        Me.VegetativeDensityControl.Name = "VegetativeDensityControl"
        Me.VegetativeDensityControl.Size = New System.Drawing.Size(96, 24)
        Me.VegetativeDensityControl.TabIndex = 4
        Me.VegetativeDensityControl.ToBeCalculated = True
        Me.VegetativeDensityControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.VegetativeDensityControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.VegetativeDensityControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.VegetativeDensityControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.VegetativeDensityControl.ValueText = ""
        '
        'RoughnessPhoto
        '
        Me.RoughnessPhoto.AccessibleDescription = "A copyable bitmap image"
        Me.RoughnessPhoto.AccessibleName = "Roughness Photo"
        Me.RoughnessPhoto.Location = New System.Drawing.Point(56, 22)
        Me.RoughnessPhoto.Name = "RoughnessPhoto"
        Me.RoughnessPhoto.Size = New System.Drawing.Size(256, 136)
        Me.RoughnessPhoto.TabIndex = 6
        Me.RoughnessPhoto.TabStop = False
        Me.RoughnessPhoto.Text = "Bitmap Diagram"
        '
        'VegetativeDensitySelect
        '
        Me.VegetativeDensitySelect.AccessibleDescription = "Selects whether or not there is a crop density that impedes surface flow."
        Me.VegetativeDensitySelect.AccessibleName = "Vegetative Density Enable"
        Me.VegetativeDensitySelect.AlwaysChecked = False
        Me.VegetativeDensitySelect.ErrorMessage = Nothing
        Me.VegetativeDensitySelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VegetativeDensitySelect.Location = New System.Drawing.Point(8, 202)
        Me.VegetativeDensitySelect.Name = "VegetativeDensitySelect"
        Me.VegetativeDensitySelect.Size = New System.Drawing.Size(152, 24)
        Me.VegetativeDensitySelect.TabIndex = 3
        Me.VegetativeDensitySelect.Text = "&Vegetative Density"
        Me.VegetativeDensitySelect.UncheckAttemptMessage = Nothing
        '
        'RoughnessMethodLabel
        '
        Me.RoughnessMethodLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessMethodLabel.Location = New System.Drawing.Point(22, 166)
        Me.RoughnessMethodLabel.Name = "RoughnessMethodLabel"
        Me.RoughnessMethodLabel.Size = New System.Drawing.Size(170, 23)
        Me.RoughnessMethodLabel.TabIndex = 1
        Me.RoughnessMethodLabel.Text = "Resistance E&quation"
        Me.RoughnessMethodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RoughnessMethodControl
        '
        Me.RoughnessMethodControl.AccessibleDescription = "Selects method for entering surface roughness parameters."
        Me.RoughnessMethodControl.AccessibleName = "Roughness Method"
        Me.RoughnessMethodControl.ApplicationValue = -1
        Me.RoughnessMethodControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RoughnessMethodControl.EnableSaveActions = False
        Me.RoughnessMethodControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessMethodControl.IsCalculated = False
        Me.RoughnessMethodControl.Location = New System.Drawing.Point(195, 166)
        Me.RoughnessMethodControl.Name = "RoughnessMethodControl"
        Me.RoughnessMethodControl.SelectedIndexSet = False
        Me.RoughnessMethodControl.Size = New System.Drawing.Size(160, 24)
        Me.RoughnessMethodControl.TabIndex = 2
        '
        'ManningCnAnPanel
        '
        Me.ManningCnAnPanel.AccessibleDescription = "Specifies surface roughness using Manning Cn & An values."
        Me.ManningCnAnPanel.AccessibleName = "Manning Cn & An"
        Me.ManningCnAnPanel.Controls.Add(Me.ManningAnControl)
        Me.ManningCnAnPanel.Controls.Add(Me.ManningAnLabel)
        Me.ManningCnAnPanel.Controls.Add(Me.ManningCnControl)
        Me.ManningCnAnPanel.Controls.Add(Me.ManningCnLabel)
        Me.ManningCnAnPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManningCnAnPanel.Location = New System.Drawing.Point(8, 232)
        Me.ManningCnAnPanel.Name = "ManningCnAnPanel"
        Me.ManningCnAnPanel.Size = New System.Drawing.Size(344, 178)
        Me.ManningCnAnPanel.TabIndex = 5
        '
        'ManningAnControl
        '
        Me.ManningAnControl.AccessibleDescription = "Specifies Manning An value."
        Me.ManningAnControl.AccessibleName = "Manning An"
        Me.ManningAnControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ManningAnControl.IsCalculated = False
        Me.ManningAnControl.IsInteger = False
        Me.ManningAnControl.Location = New System.Drawing.Point(147, 88)
        Me.ManningAnControl.MaxErrMsg = ""
        Me.ManningAnControl.MinErrMsg = ""
        Me.ManningAnControl.Name = "ManningAnControl"
        Me.ManningAnControl.Size = New System.Drawing.Size(144, 24)
        Me.ManningAnControl.TabIndex = 3
        Me.ManningAnControl.ToBeCalculated = True
        Me.ManningAnControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ManningAnControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ManningAnControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ManningAnControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ManningAnControl.ValueText = ""
        '
        'ManningAnLabel
        '
        Me.ManningAnLabel.Location = New System.Drawing.Point(11, 88)
        Me.ManningAnLabel.Name = "ManningAnLabel"
        Me.ManningAnLabel.Size = New System.Drawing.Size(127, 23)
        Me.ManningAnLabel.TabIndex = 2
        Me.ManningAnLabel.Text = "Manning &An"
        Me.ManningAnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ManningCnControl
        '
        Me.ManningCnControl.AccessibleDescription = "Specifies Manning Cn value."
        Me.ManningCnControl.AccessibleName = "Manning Cn"
        Me.ManningCnControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ManningCnControl.IsCalculated = False
        Me.ManningCnControl.IsInteger = False
        Me.ManningCnControl.Location = New System.Drawing.Point(147, 55)
        Me.ManningCnControl.MaxErrMsg = ""
        Me.ManningCnControl.MinErrMsg = ""
        Me.ManningCnControl.Name = "ManningCnControl"
        Me.ManningCnControl.Size = New System.Drawing.Size(144, 24)
        Me.ManningCnControl.TabIndex = 1
        Me.ManningCnControl.ToBeCalculated = True
        Me.ManningCnControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ManningCnControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ManningCnControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ManningCnControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ManningCnControl.ValueText = ""
        '
        'ManningCnLabel
        '
        Me.ManningCnLabel.Location = New System.Drawing.Point(8, 56)
        Me.ManningCnLabel.Name = "ManningCnLabel"
        Me.ManningCnLabel.Size = New System.Drawing.Size(130, 23)
        Me.ManningCnLabel.TabIndex = 0
        Me.ManningCnLabel.Text = "Manning &Cn"
        Me.ManningCnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SayreChiPanel
        '
        Me.SayreChiPanel.AccessibleDescription = "Specifies surface roughness using a Sayre-Albertson Chi value."
        Me.SayreChiPanel.AccessibleName = "Sayre-Albertson Chi"
        Me.SayreChiPanel.Controls.Add(Me.SayreChiControl)
        Me.SayreChiPanel.Controls.Add(Me.SayreChiLabel)
        Me.SayreChiPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SayreChiPanel.Location = New System.Drawing.Point(8, 232)
        Me.SayreChiPanel.Name = "SayreChiPanel"
        Me.SayreChiPanel.Size = New System.Drawing.Size(344, 178)
        Me.SayreChiPanel.TabIndex = 5
        '
        'SayreChiControl
        '
        Me.SayreChiControl.AccessibleDescription = "Specifies surface roughness using a Sayre-Albertson Chi value."
        Me.SayreChiControl.AccessibleName = "Sayre-Albertson Chi"
        Me.SayreChiControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SayreChiControl.IsCalculated = False
        Me.SayreChiControl.IsInteger = False
        Me.SayreChiControl.Location = New System.Drawing.Point(147, 72)
        Me.SayreChiControl.MaxErrMsg = ""
        Me.SayreChiControl.MinErrMsg = ""
        Me.SayreChiControl.Name = "SayreChiControl"
        Me.SayreChiControl.Size = New System.Drawing.Size(144, 24)
        Me.SayreChiControl.TabIndex = 1
        Me.SayreChiControl.ToBeCalculated = True
        Me.SayreChiControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SayreChiControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SayreChiControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SayreChiControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SayreChiControl.ValueText = ""
        '
        'SayreChiLabel
        '
        Me.SayreChiLabel.Location = New System.Drawing.Point(8, 72)
        Me.SayreChiLabel.Name = "SayreChiLabel"
        Me.SayreChiLabel.Size = New System.Drawing.Size(136, 23)
        Me.SayreChiLabel.TabIndex = 0
        Me.SayreChiLabel.Text = "&Sayre-Albertson Chi"
        Me.SayreChiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsManningNPanel
        '
        Me.NrcsManningNPanel.AccessibleDescription = "Set of radio buttons that select Manning N from NRCS suggested values."
        Me.NrcsManningNPanel.AccessibleName = "Manning N"
        Me.NrcsManningNPanel.Controls.Add(Me.UsersManningNControl)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_UserEntered)
        Me.NrcsManningNPanel.Controls.Add(Me.NrcsSuggestedLabel)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_025)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_020)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_015)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_010)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_004)
        Me.NrcsManningNPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsManningNPanel.Location = New System.Drawing.Point(8, 232)
        Me.NrcsManningNPanel.Name = "NrcsManningNPanel"
        Me.NrcsManningNPanel.Size = New System.Drawing.Size(344, 178)
        Me.NrcsManningNPanel.TabIndex = 5
        '
        'UsersManningNControl
        '
        Me.UsersManningNControl.AccessibleDescription = "Specifies surface roughness using Manning n value."
        Me.UsersManningNControl.AccessibleName = "Manning n"
        Me.UsersManningNControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.UsersManningNControl.IsCalculated = False
        Me.UsersManningNControl.IsInteger = False
        Me.UsersManningNControl.Location = New System.Drawing.Point(205, 149)
        Me.UsersManningNControl.MaxErrMsg = ""
        Me.UsersManningNControl.MinErrMsg = ""
        Me.UsersManningNControl.Name = "UsersManningNControl"
        Me.UsersManningNControl.Size = New System.Drawing.Size(108, 24)
        Me.UsersManningNControl.TabIndex = 7
        Me.UsersManningNControl.ToBeCalculated = True
        Me.UsersManningNControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.UsersManningNControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.UsersManningNControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.UsersManningNControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.UsersManningNControl.ValueText = ""
        '
        'Sel_UserEntered
        '
        Me.Sel_UserEntered.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_UserEntered.Location = New System.Drawing.Point(2, 150)
        Me.Sel_UserEntered.Name = "Sel_UserEntered"
        Me.Sel_UserEntered.Size = New System.Drawing.Size(188, 23)
        Me.Sel_UserEntered.TabIndex = 6
        Me.Sel_UserEntered.TabStop = True
        Me.Sel_UserEntered.Text = "&User Entered Value:"
        Me.Sel_UserEntered.UseVisualStyleBackColor = True
        '
        'NrcsSuggestedLabel
        '
        Me.NrcsSuggestedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsSuggestedLabel.Location = New System.Drawing.Point(1, 4)
        Me.NrcsSuggestedLabel.Name = "NrcsSuggestedLabel"
        Me.NrcsSuggestedLabel.Size = New System.Drawing.Size(341, 23)
        Me.NrcsSuggestedLabel.TabIndex = 0
        Me.NrcsSuggestedLabel.Text = "&NRCS Suggested Values:"
        '
        'Sel_025
        '
        Me.Sel_025.Location = New System.Drawing.Point(2, 120)
        Me.Sel_025.Name = "Sel_025"
        Me.Sel_025.Size = New System.Drawing.Size(340, 24)
        Me.Sel_025.TabIndex = 5
        Me.Sel_025.Text = "0.25 - Dense crops or small grain drilled crosswise"
        '
        'Sel_020
        '
        Me.Sel_020.Location = New System.Drawing.Point(2, 96)
        Me.Sel_020.Name = "Sel_020"
        Me.Sel_020.Size = New System.Drawing.Size(340, 24)
        Me.Sel_020.TabIndex = 4
        Me.Sel_020.Text = "0.20 - Alfalfa, dense or on long fields"
        '
        'Sel_015
        '
        Me.Sel_015.Location = New System.Drawing.Point(2, 72)
        Me.Sel_015.Name = "Sel_015"
        Me.Sel_015.Size = New System.Drawing.Size(340, 24)
        Me.Sel_015.TabIndex = 3
        Me.Sel_015.Text = "0.15 - Alfalfa, Mint or Broadcast Small Grain"
        '
        'Sel_010
        '
        Me.Sel_010.Location = New System.Drawing.Point(2, 48)
        Me.Sel_010.Name = "Sel_010"
        Me.Sel_010.Size = New System.Drawing.Size(340, 24)
        Me.Sel_010.TabIndex = 2
        Me.Sel_010.Text = "0.10 - Small Grain (drilled lengthwise)"
        '
        'Sel_004
        '
        Me.Sel_004.Location = New System.Drawing.Point(2, 24)
        Me.Sel_004.Name = "Sel_004"
        Me.Sel_004.Size = New System.Drawing.Size(340, 24)
        Me.Sel_004.TabIndex = 1
        Me.Sel_004.Text = "0.04 - Bare Soil"
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "")
        Me.ImageList.Images.SetKeyName(1, "")
        Me.ImageList.Images.SetKeyName(2, "")
        Me.ImageList.Images.SetKeyName(3, "")
        Me.ImageList.Images.SetKeyName(4, "")
        '
        'ctl_Roughness
        '
        Me.AccessibleDescription = "Inputs for describing the resistance the surface water encounters as it flows dow" &
    "n the field."
        Me.AccessibleName = "Roughness"
        Me.Controls.Add(Me.RoughnessGroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_Roughness"
        Me.Size = New System.Drawing.Size(368, 422)
        Me.RoughnessGroupBox.ResumeLayout(False)
        Me.TabulatedManningNPanel.ResumeLayout(False)
        CType(Me.TabulatedManningNControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedSayreChiPanel.ResumeLayout(False)
        CType(Me.TabulatedSayreChiControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedManningCnAnPanel.ResumeLayout(False)
        CType(Me.TabulatedManningCnAnControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RoughnessPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ManningCnAnPanel.ResumeLayout(False)
        Me.SayreChiPanel.ResumeLayout(False)
        Me.NrcsManningNPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Private mUnit As Unit = Nothing
    Private mWorld As World = Nothing
    Private mField As Field = Nothing
    Private mFarm As Farm = Nothing

    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Private WithEvents mSoilCropProperties As SoilCropProperties = Nothing
    Private WithEvents mEventCriteria As EventCriteria = Nothing

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Private mMyStore As DataStore.ObjectNode = Nothing

    Public Sub LinkToModel(ByVal _unit As Unit)

        Debug.Assert(Not (_unit Is Nothing), "Unit is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mEventCriteria = mUnit.EventCriteriaRef

        mMyStore = mUnit.MyStore

        ' Link the contained controls to their models & store
        RoughnessMethodControl.LinkToModel(mMyStore, mSoilCropProperties.RoughnessMethodProperty)

        Sel_004.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.BareSoil)
        Sel_010.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.SmallGrain)
        Sel_015.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.AlfalfaMintBroadcast)
        Sel_020.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.AlfalfaDenseOrLong)
        Sel_025.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.DenseSodCrops)
        Sel_UserEntered.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.UserEntered)

        TabulatedRoughnessSelect.LinkToModel(mMyStore, mSoilCropProperties.EnableTabulatedRoughnessProperty)

        VegetativeDensitySelect.LinkToModel(mMyStore, mSoilCropProperties.EnableVegetativeDensityProperty)
        VegetativeDensityControl.LinkToModel(mMyStore, mSoilCropProperties.VegetativeDensityProperty)

        UsersManningNControl.LinkToModel(mMyStore, mSoilCropProperties.UsersManningNProperty)
        ManningCnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningCnProperty)
        ManningAnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningAnProperty)
        SayreChiControl.LinkToModel(mMyStore, mSoilCropProperties.SayreChiProperty)

        TabulatedManningNControl.LinkToModel(mMyStore, mSoilCropProperties.ManningNTableProperty)
        TabulatedManningNControl.FirstRowFixed = True

        TabulatedManningCnAnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningCnAnTableProperty)
        TabulatedManningCnAnControl.FirstRowFixed = True

        TabulatedSayreChiControl.LinkToModel(mMyStore, mSoilCropProperties.SayreChiTableProperty)
        TabulatedSayreChiControl.FirstRowFixed = True

        ' Update language translation
        UpdateLanguage()

        ' Update the control's User Interface
        UpdateUI()

    End Sub
    '
    ' Update UI when any Soil Crop Property value changes
    '
    Public Sub SoilCropProperties_PropertyChanged(ByVal _reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        ' Update the UI only if it is linked to a model object
        If (mUnit IsNot Nothing) Then
            UpdateRoughnessMethod()
            UpdateVegetativeDensity()
            UpdateNrcsSuggestedManningN()
        End If
    End Sub
    '
    ' Update the Roughness Method selection list & selection
    '
    Private Sub UpdateRoughnessMethod()

        ' Update selection list
        Dim roughnessMethod As RoughnessMethods = mSoilCropProperties.RoughnessMethod.Value
        Dim _sel As String = String.Empty
        Dim _idx As Integer = 0

        RoughnessMethodControl.Clear()

        Dim _selOk As Boolean = mSoilCropProperties.GetFirstRoughnessMethodSelection(_sel)
        While Not (_sel Is Nothing)
            If (_selOk) Then
                RoughnessMethodControl.Add(_sel, _idx, True)
            ElseIf (roughnessMethod = _idx) Then
                RoughnessMethodControl.Add(_sel, _idx, False)
            End If
            _selOk = mSoilCropProperties.GetNextRoughnessMethodSelection(_sel)
            _idx += 1
        End While

        ' Update selection
        RoughnessMethodControl.UpdateUI()

        ' Design & Operations don't support Tabulated Roughness
        Dim supported As Boolean = False
        Dim worldType As WorldTypes = mSoilCropProperties.Unit.UnitType.Value

        Select Case (worldType)

            Case WorldTypes.SimulationWorld

                If (WinSRFR.UserLevel = UserLevels.Standard) Then
                    TabulatedRoughnessSelect.Hide()
                Else
                    TabulatedRoughnessSelect.Show()
                    supported = True
                End If

            Case Else
                TabulatedRoughnessSelect.Hide()
        End Select

        ' Hide / Show correspnding UI panels & photos
        Dim tabulated As Boolean = mSoilCropProperties.EnableTabulatedRoughness.Value
        Dim vegDensity As Boolean = mSoilCropProperties.EnableVegetativeDensity.Value

        If ((supported) And (tabulated)) Then
            ' Tabulated Roughness is selected
            NrcsManningNPanel.Hide()
            ManningCnAnPanel.Hide()
            SayreChiPanel.Hide()
            RoughnessPhoto.Hide()

            Select Case (roughnessMethod)
                Case RoughnessMethods.SayreAlbertson
                    TabulatedManningNPanel.Hide()
                    TabulatedManningCnAnPanel.Hide()

                    TabulatedSayreChiPanel.Show()
                    If (vegDensity) Then
                        TabulatedSayreChiControl.HiddenColumn(sVegDensityM) = False
                    Else
                        TabulatedSayreChiControl.HiddenColumn(sVegDensityM) = True
                    End If
                    TabulatedSayreChiControl.UpdateUI()

                Case RoughnessMethods.ManningCnAn
                    TabulatedManningNPanel.Hide()
                    TabulatedSayreChiPanel.Hide()

                    TabulatedManningCnAnPanel.Show()
                    If (vegDensity) Then
                        TabulatedManningCnAnControl.HiddenColumn(sVegDensityM) = False
                    Else
                        TabulatedManningCnAnControl.HiddenColumn(sVegDensityM) = True
                    End If
                    TabulatedManningCnAnControl.UpdateUI()

                Case Else ' Assume RoughnessMethods.ManningN
                    TabulatedManningCnAnPanel.Hide()
                    TabulatedSayreChiPanel.Hide()

                    TabulatedManningNPanel.Show()
                    If (vegDensity) Then
                        TabulatedManningNControl.HiddenColumn(sVegDensityM) = False
                    Else
                        TabulatedManningNControl.HiddenColumn(sVegDensityM) = True
                    End If
                    TabulatedManningNControl.UpdateUI()
            End Select

        Else
            ' Normal Roughness is selected
            TabulatedManningNPanel.Hide()
            TabulatedManningCnAnPanel.Hide()
            TabulatedSayreChiPanel.Hide()

            Select Case (roughnessMethod)
                Case RoughnessMethods.SayreAlbertson
                    NrcsManningNPanel.Hide()
                    ManningCnAnPanel.Hide()
                    SayreChiPanel.Show()
                    RoughnessPhoto.Hide()

                Case RoughnessMethods.ManningCnAn
                    NrcsManningNPanel.Hide()
                    SayreChiPanel.Hide()
                    ManningCnAnPanel.Show()
                    RoughnessPhoto.Hide()

                Case Else ' Assume RoughnessMethods.NrcsSuggestedManningN
                    ManningCnAnPanel.Hide()
                    SayreChiPanel.Hide()
                    NrcsManningNPanel.Show()
                    ShowManningRoughnessPhoto()
            End Select
        End If

    End Sub
    '
    ' Show the appropriate Roughness photo
    '
    Private Sub ShowManningRoughnessPhoto()

        ' Get a bitmap to hold the photo
        Dim _bitmap As Bitmap = New Bitmap(RoughnessPhoto.Width, RoughnessPhoto.Height)

        ' Load the photo that corresponds to the current Manning N  value
        Dim _manningN As Double = mSoilCropProperties.ManningN.Value

        If (_manningN < 0.06) Then
            _bitmap = CType(ImageList.Images(0), Bitmap)
        ElseIf (_manningN < 0.125) Then
            _bitmap = CType(ImageList.Images(1), Bitmap)
        ElseIf (_manningN < 0.175) Then
            _bitmap = CType(ImageList.Images(2), Bitmap)
        ElseIf (_manningN < 0.225) Then
            _bitmap = CType(ImageList.Images(3), Bitmap)
        Else
            _bitmap = CType(ImageList.Images(4), Bitmap)
        End If

        ' Load and show the photo
        If (RoughnessPhoto.Image IsNot Nothing) Then
            RoughnessPhoto.Image.Dispose()
            RoughnessPhoto.Image = Nothing
        End If

        RoughnessPhoto.Image = _bitmap
        RoughnessPhoto.Show()

    End Sub
    '
    ' Update display of Vegetative Density
    '
    Private Sub UpdateVegetativeDensity()
        ' Design & Operations don't support Vegetative Density
        Select Case mSoilCropProperties.Unit.UnitType.Value

            Case WorldTypes.SimulationWorld

                If (mWinSRFR.IsResearchLevel) Then
                    VegetativeDensitySelect.Show()

                    ' Vegetative Density is column in Tabulated Roughness
                    If (mSoilCropProperties.EnableTabulatedRoughness.Value) Then
                        VegetativeDensityControl.Hide()
                    Else
                        VegetativeDensityControl.Show()
                    End If

                    If (mSoilCropProperties.EnableVegetativeDensity.Value) Then
                        VegetativeDensityControl.Enabled = True
                    Else
                        VegetativeDensityControl.Enabled = False
                    End If
                Else
                    VegetativeDensitySelect.Hide()
                    VegetativeDensityControl.Hide()
                End If

            Case Else
                VegetativeDensitySelect.Hide()
                VegetativeDensityControl.Hide()
        End Select

    End Sub
    '
    ' Update which NRCS Manning N is checked
    '
    Private Sub UpdateNrcsSuggestedManningN()
        Select Case mSoilCropProperties.NrcsSuggestedManningN.Value
            Case NrcsSuggestedManningN.BareSoil
                Sel_004.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.SmallGrain
                Sel_010.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.AlfalfaMintBroadcast
                Sel_015.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.AlfalfaDenseOrLong
                Sel_020.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.DenseSodCrops
                Sel_025.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.UserEntered
                Sel_UserEntered.Checked = True
                Me.UsersManningNControl.Enabled = True
        End Select
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated

        Select Case reason
            Case WinSRFR.Reasons.Language
                UpdateLanguage()
        End Select
    End Sub
    '
    ' Manning N should track NRCS Suggested Manning N
    '
    Private Sub RoughnessMethodControl_ControlValueChanged() _
    Handles RoughnessMethodControl.ControlValueChanged
        If (mSoilCropProperties.RoughnessMethod.Value = RoughnessMethods.NrcsSuggestedManningN) Then
            Dim _suggested As NrcsSuggestedManningN = mSoilCropProperties.NrcsSuggestedManningN.Value
            SetNrcsManningN(_suggested)
        End If
    End Sub

#End Region

#Region " UI Event Handlers "
    '
    ' Update NRCS Manning N selection
    '
    Private Sub SetNrcsManningN(ByVal _suggested As NrcsSuggestedManningN)
        If (mSoilCropProperties IsNot Nothing) Then
            Dim _double As DoubleParameter = mSoilCropProperties.ManningN
            If (_suggested = NrcsSuggestedManningN.UserEntered) Then
                _double.Value = mSoilCropProperties.UsersManningN.Value
            Else
                _double.Value = NrcsSuggestedManningNValues(_suggested)
            End If
            _double.Source = DataStore.Globals.ValueSources.UserEntered
            mSoilCropProperties.ManningN = _double
        End If
    End Sub

    Private Sub Sel_004_ControlValueChanged() Handles Sel_004.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.BareSoil)
    End Sub

    Private Sub Sel_010_ControlValueChanged() Handles Sel_010.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.SmallGrain)
    End Sub

    Private Sub Sel_015_ControlValueChanged() Handles Sel_015.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.AlfalfaMintBroadcast)
    End Sub

    Private Sub Sel_020_ControlValueChanged() Handles Sel_020.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.AlfalfaDenseOrLong)
    End Sub

    Private Sub Sel_025_ControlValueChanged() Handles Sel_025.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.DenseSodCrops)
    End Sub

    Private Sub Sel_UserEntered_ControlValueChanged() Handles Sel_UserEntered.ControlValueChanged
        If (mSoilCropProperties IsNot Nothing) Then
            Dim _double As DoubleParameter = mSoilCropProperties.ManningN
            _double.Value = mSoilCropProperties.UsersManningN.Value
            _double.Source = DataStore.Globals.ValueSources.UserEntered
            mSoilCropProperties.ManningN = _double
        End If
    End Sub

    Private Sub UserManningNControl_ControlValueChanged() Handles UsersManningNControl.ControlValueChanged
        If (mSoilCropProperties IsNot Nothing) Then
            Dim _double As DoubleParameter = mSoilCropProperties.ManningN
            _double.Value = mSoilCropProperties.UsersManningN.Value
            _double.Source = DataStore.Globals.ValueSources.UserEntered
            mSoilCropProperties.ManningN = _double
        End If
    End Sub

    Private Sub RoughnessControl_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        ' Calculate/set new Height of the ctl_Roughness
        Dim newRoughnessControlHeight As Integer = MyBase.Height - Me.RoughnessGroupBox.Margin.Top - Me.RoughnessGroupBox.Margin.Bottom

        Me.RoughnessGroupBox.Height = newRoughnessControlHeight

        ' Use new Height to adjust appropriate contained controls
        Me.TabulatedManningCnAnPanel.Height = newRoughnessControlHeight - Me.TabulatedManningCnAnPanel.Top - Me.TabulatedManningCnAnPanel.Margin.Bottom
        Me.TabulatedManningCnAnControl.Height = Me.TabulatedManningCnAnPanel.Height - Me.TabulatedManningCnAnControl.Top - Me.TabulatedManningCnAnControl.Margin.Bottom

        Me.TabulatedManningNPanel.Height = newRoughnessControlHeight - Me.TabulatedManningNPanel.Top - Me.TabulatedManningNPanel.Margin.Bottom
        Me.TabulatedManningNControl.Height = Me.TabulatedManningNPanel.Height - Me.TabulatedManningNControl.Top - Me.TabulatedManningNControl.Margin.Bottom

        Me.TabulatedSayreChiPanel.Height = newRoughnessControlHeight - Me.TabulatedSayreChiPanel.Top - Me.TabulatedSayreChiPanel.Margin.Bottom
        Me.TabulatedSayreChiControl.Height = Me.TabulatedSayreChiPanel.Height - Me.TabulatedSayreChiControl.Top - Me.TabulatedSayreChiControl.Margin.Bottom

    End Sub
    '
    ' Make sure UI is up to date whenever it become visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

End Class
