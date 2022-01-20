
'**********************************************************************************************
' Control class: ctl_RoughnessLite
'
'   ctl_RoughnessLite provides the UI for viewing & editing Roughness data
'
Imports DataStore
Imports DataStore.DataStore
Imports Srfr.Roughness

Public Class ctl_RoughnessLite
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
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents RoughnessPhoto As GraphingUI.ex_PictureBox
    Friend WithEvents NrcsSuggestedLabel As DataStore.ctl_Label
    Friend WithEvents Sel_UserEntered As DataStore.ctl_RadioButton
    Friend WithEvents UsersManningNControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SayreChiLabel As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctl_RoughnessLite))
        Me.RoughnessGroupBox = New DataStore.ctl_GroupBox()
        Me.RoughnessPhoto = New GraphingUI.ex_PictureBox()
        Me.RoughnessMethodLabel = New DataStore.ctl_Label()
        Me.RoughnessMethodControl = New DataStore.ctl_SelectParameter()
        Me.NrcsManningNPanel = New DataStore.ctl_Panel()
        Me.UsersManningNControl = New DataStore.ctl_DoubleParameter()
        Me.Sel_UserEntered = New DataStore.ctl_RadioButton()
        Me.NrcsSuggestedLabel = New DataStore.ctl_Label()
        Me.Sel_025 = New DataStore.ctl_RadioButton()
        Me.Sel_020 = New DataStore.ctl_RadioButton()
        Me.Sel_015 = New DataStore.ctl_RadioButton()
        Me.Sel_010 = New DataStore.ctl_RadioButton()
        Me.Sel_004 = New DataStore.ctl_RadioButton()
        Me.ManningCnAnPanel = New DataStore.ctl_Panel()
        Me.ManningAnControl = New DataStore.ctl_DoubleParameter()
        Me.ManningAnLabel = New DataStore.ctl_Label()
        Me.ManningCnControl = New DataStore.ctl_DoubleParameter()
        Me.ManningCnLabel = New DataStore.ctl_Label()
        Me.SayreChiPanel = New DataStore.ctl_Panel()
        Me.SayreChiControl = New DataStore.ctl_DoubleParameter()
        Me.SayreChiLabel = New DataStore.ctl_Label()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.RoughnessGroupBox.SuspendLayout()
        CType(Me.RoughnessPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NrcsManningNPanel.SuspendLayout()
        Me.ManningCnAnPanel.SuspendLayout()
        Me.SayreChiPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'RoughnessGroupBox
        '
        Me.RoughnessGroupBox.AccessibleDescription = "Set of parameters that specify surface roughness parameters."
        Me.RoughnessGroupBox.AccessibleName = "Roughness"
        Me.RoughnessGroupBox.Controls.Add(Me.RoughnessPhoto)
        Me.RoughnessGroupBox.Controls.Add(Me.RoughnessMethodLabel)
        Me.RoughnessGroupBox.Controls.Add(Me.RoughnessMethodControl)
        Me.RoughnessGroupBox.Controls.Add(Me.NrcsManningNPanel)
        Me.RoughnessGroupBox.Controls.Add(Me.ManningCnAnPanel)
        Me.RoughnessGroupBox.Controls.Add(Me.SayreChiPanel)
        Me.RoughnessGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessGroupBox.Location = New System.Drawing.Point(0, 0)
        Me.RoughnessGroupBox.Name = "RoughnessGroupBox"
        Me.RoughnessGroupBox.Size = New System.Drawing.Size(360, 380)
        Me.RoughnessGroupBox.TabIndex = 0
        Me.RoughnessGroupBox.TabStop = False
        Me.RoughnessGroupBox.Text = "Roughness"
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
        'RoughnessMethodLabel
        '
        Me.RoughnessMethodLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessMethodLabel.Location = New System.Drawing.Point(12, 166)
        Me.RoughnessMethodLabel.Name = "RoughnessMethodLabel"
        Me.RoughnessMethodLabel.Size = New System.Drawing.Size(181, 23)
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
        Me.NrcsManningNPanel.Location = New System.Drawing.Point(8, 200)
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
        Me.NrcsSuggestedLabel.Location = New System.Drawing.Point(1, 3)
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
        'ManningCnAnPanel
        '
        Me.ManningCnAnPanel.AccessibleDescription = "Specifies surface roughness using Manning Cn & An values."
        Me.ManningCnAnPanel.AccessibleName = "Manning Cn & An"
        Me.ManningCnAnPanel.Controls.Add(Me.ManningAnControl)
        Me.ManningCnAnPanel.Controls.Add(Me.ManningAnLabel)
        Me.ManningCnAnPanel.Controls.Add(Me.ManningCnControl)
        Me.ManningCnAnPanel.Controls.Add(Me.ManningCnLabel)
        Me.ManningCnAnPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManningCnAnPanel.Location = New System.Drawing.Point(8, 200)
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
        Me.SayreChiPanel.Location = New System.Drawing.Point(8, 200)
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
        'ctl_RoughnessLite
        '
        Me.Controls.Add(Me.RoughnessGroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_RoughnessLite"
        Me.Size = New System.Drawing.Size(368, 386)
        Me.RoughnessGroupBox.ResumeLayout(False)
        CType(Me.RoughnessPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NrcsManningNPanel.ResumeLayout(False)
        Me.ManningCnAnPanel.ResumeLayout(False)
        Me.SayreChiPanel.ResumeLayout(False)
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

        UsersManningNControl.LinkToModel(mMyStore, mSoilCropProperties.UsersManningNProperty)
        ManningCnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningCnProperty)
        ManningAnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningAnProperty)
        SayreChiControl.LinkToModel(mMyStore, mSoilCropProperties.SayreChiProperty)

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

        ' Hide / Show correspnding UI panels & photos
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
        UpdateTranslation(Me)
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
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

End Class
