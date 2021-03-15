
'*************************************************************************************************************
' ctl_InfiltratedProfile
'
'   Provides the UI for viewing & editing Infiltrated Profile data:
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_InfiltratedProfile
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
    Friend WithEvents ReadOnlyLabel As DataStore.ctl_Label
    Friend WithEvents ErrorsAndWarnings As WinMain.ErrorRichTextBox
    Friend WithEvents IdControl As DataStore.ctl_DataTableParameter
    Friend WithEvents SwdControl As DataStore.ctl_DataTableParameter
    Friend WithEvents RootZonePanel As DataStore.ctl_Panel
    Friend WithEvents LeachingFractionLabel As DataStore.ctl_Label
    Friend WithEvents LeachingFractionControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ProbeLengthLabel As DataStore.ctl_Label
    Friend WithEvents ProbeLengthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents RootZoneDepthLabel As DataStore.ctl_Label
    Friend WithEvents RootZoneDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SoilWaterDeficitPanel As DataStore.ctl_Panel
    Friend WithEvents IrrigationTargetDepth As System.Windows.Forms.Label
    Friend WithEvents LeachingRequirement As System.Windows.Forms.Label
    Friend WithEvents SoilWaterDeficit As System.Windows.Forms.Label
    Friend WithEvents EqualsLabel As System.Windows.Forms.Label
    Friend WithEvents LeachingRequirmentLabel As DataStore.ctl_Label
    Friend WithEvents PlusLabel As System.Windows.Forms.Label
    Friend WithEvents SoilWaterDeficitLabel As DataStore.ctl_Label
    Friend WithEvents IrrigationTargetDepthLabel As DataStore.ctl_Label
    Friend WithEvents StarLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ReadOnlyLabel = New DataStore.ctl_Label
        Me.IdControl = New DataStore.ctl_DataTableParameter
        Me.SwdControl = New DataStore.ctl_DataTableParameter
        Me.StarLabel = New System.Windows.Forms.Label
        Me.RootZonePanel = New DataStore.ctl_Panel
        Me.LeachingFractionLabel = New DataStore.ctl_Label
        Me.LeachingFractionControl = New DataStore.ctl_DoubleParameter
        Me.ProbeLengthLabel = New DataStore.ctl_Label
        Me.ProbeLengthControl = New DataStore.ctl_DoubleParameter
        Me.RootZoneDepthLabel = New DataStore.ctl_Label
        Me.RootZoneDepthControl = New DataStore.ctl_DoubleParameter
        Me.SoilWaterDeficitPanel = New DataStore.ctl_Panel
        Me.IrrigationTargetDepth = New System.Windows.Forms.Label
        Me.LeachingRequirement = New System.Windows.Forms.Label
        Me.SoilWaterDeficit = New System.Windows.Forms.Label
        Me.EqualsLabel = New System.Windows.Forms.Label
        Me.LeachingRequirmentLabel = New DataStore.ctl_Label
        Me.PlusLabel = New System.Windows.Forms.Label
        Me.SoilWaterDeficitLabel = New DataStore.ctl_Label
        Me.IrrigationTargetDepthLabel = New DataStore.ctl_Label
        Me.ErrorsAndWarnings = New WinMain.ErrorRichTextBox
        CType(Me.IdControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SwdControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RootZonePanel.SuspendLayout()
        Me.SoilWaterDeficitPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReadOnlyLabel
        '
        Me.ReadOnlyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReadOnlyLabel.Location = New System.Drawing.Point(595, 398)
        Me.ReadOnlyLabel.Name = "ReadOnlyLabel"
        Me.ReadOnlyLabel.Size = New System.Drawing.Size(160, 23)
        Me.ReadOnlyLabel.TabIndex = 7
        Me.ReadOnlyLabel.Text = "Calculated by WinSRFR"
        Me.ReadOnlyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'IdControl
        '
        Me.IdControl.AccessibleDescription = "Table defining the post-irrigation probed infiltrated depths."
        Me.IdControl.AccessibleName = "Infiltrated Depths Table"
        Me.IdControl.AllRowsFixed = False
        Me.IdControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.IdControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.IdControl.CaptionText = "Post-Irrigation Infiltrated Depths - ID"
        Me.IdControl.CausesValidation = False
        Me.IdControl.ColumnWidthRatios = Nothing
        Me.IdControl.DataMember = ""
        Me.IdControl.EnableSaveActions = True
        Me.IdControl.FirstColumnIncreases = True
        Me.IdControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.IdControl.FirstColumnMinimum = 0
        Me.IdControl.FirstRowFixed = True
        Me.IdControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IdControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.IdControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.IdControl.Location = New System.Drawing.Point(6, 222)
        Me.IdControl.MaxRows = 50
        Me.IdControl.MinRows = 2
        Me.IdControl.Name = "IdControl"
        Me.IdControl.SecondColumnIncreases = False
        Me.IdControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.IdControl.SecondColumnMinimum = 0
        Me.IdControl.Size = New System.Drawing.Size(752, 176)
        Me.IdControl.TabIndex = 5
        Me.IdControl.TableReadonly = False
        '
        'SwdControl
        '
        Me.SwdControl.AccessibleDescription = "Table defining the pre-irrigation soil profile and water depletion."
        Me.SwdControl.AccessibleName = "Soil Water Depletion Table"
        Me.SwdControl.AllRowsFixed = False
        Me.SwdControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.SwdControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.SwdControl.CaptionText = "Pre-Irrigation Soil Water Depletion - SWD"
        Me.SwdControl.CausesValidation = False
        Me.SwdControl.ColumnWidthRatios = Nothing
        Me.SwdControl.DataMember = ""
        Me.SwdControl.EnableSaveActions = True
        Me.SwdControl.FirstColumnIncreases = False
        Me.SwdControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.SwdControl.FirstColumnMinimum = 0
        Me.SwdControl.FirstRowFixed = False
        Me.SwdControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwdControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.SwdControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.SwdControl.Location = New System.Drawing.Point(6, 6)
        Me.SwdControl.MaxRows = 10
        Me.SwdControl.MinRows = 1
        Me.SwdControl.Name = "SwdControl"
        Me.SwdControl.SecondColumnIncreases = False
        Me.SwdControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.SwdControl.SecondColumnMinimum = 0
        Me.SwdControl.Size = New System.Drawing.Size(752, 128)
        Me.SwdControl.TabIndex = 1
        Me.SwdControl.TableReadonly = False
        '
        'StarLabel
        '
        Me.StarLabel.Location = New System.Drawing.Point(579, 400)
        Me.StarLabel.Name = "StarLabel"
        Me.StarLabel.Size = New System.Drawing.Size(16, 23)
        Me.StarLabel.TabIndex = 6
        Me.StarLabel.Text = "*"
        Me.StarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RootZonePanel
        '
        Me.RootZonePanel.Controls.Add(Me.LeachingFractionLabel)
        Me.RootZonePanel.Controls.Add(Me.LeachingFractionControl)
        Me.RootZonePanel.Controls.Add(Me.ProbeLengthLabel)
        Me.RootZonePanel.Controls.Add(Me.ProbeLengthControl)
        Me.RootZonePanel.Controls.Add(Me.RootZoneDepthLabel)
        Me.RootZonePanel.Controls.Add(Me.RootZoneDepthControl)
        Me.RootZonePanel.Location = New System.Drawing.Point(6, 134)
        Me.RootZonePanel.Name = "RootZonePanel"
        Me.RootZonePanel.Size = New System.Drawing.Size(232, 88)
        Me.RootZonePanel.TabIndex = 2
        '
        'LeachingFractionLabel
        '
        Me.LeachingFractionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeachingFractionLabel.Location = New System.Drawing.Point(4, 32)
        Me.LeachingFractionLabel.Name = "LeachingFractionLabel"
        Me.LeachingFractionLabel.Size = New System.Drawing.Size(120, 23)
        Me.LeachingFractionLabel.TabIndex = 2
        Me.LeachingFractionLabel.Text = "&Leaching Fraction"
        Me.LeachingFractionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LeachingFractionControl
        '
        Me.LeachingFractionControl.AccessibleDescription = "Amount of addition water to apply for the leaching."
        Me.LeachingFractionControl.AccessibleName = "Leaching Fraction"
        Me.LeachingFractionControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.LeachingFractionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeachingFractionControl.IsCalculated = False
        Me.LeachingFractionControl.IsInteger = False
        Me.LeachingFractionControl.Location = New System.Drawing.Point(124, 32)
        Me.LeachingFractionControl.MaxErrMsg = ""
        Me.LeachingFractionControl.MinErrMsg = ""
        Me.LeachingFractionControl.Name = "LeachingFractionControl"
        Me.LeachingFractionControl.Size = New System.Drawing.Size(104, 24)
        Me.LeachingFractionControl.TabIndex = 3
        Me.LeachingFractionControl.ToBeCalculated = True
        Me.LeachingFractionControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.LeachingFractionControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.LeachingFractionControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.LeachingFractionControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.LeachingFractionControl.ValueText = ""
        '
        'ProbeLengthLabel
        '
        Me.ProbeLengthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProbeLengthLabel.Location = New System.Drawing.Point(4, 56)
        Me.ProbeLengthLabel.Name = "ProbeLengthLabel"
        Me.ProbeLengthLabel.Size = New System.Drawing.Size(120, 23)
        Me.ProbeLengthLabel.TabIndex = 4
        Me.ProbeLengthLabel.Text = "&Probe Length"
        Me.ProbeLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProbeLengthControl
        '
        Me.ProbeLengthControl.AccessibleDescription = "Length of probe used to take measurements in the field."
        Me.ProbeLengthControl.AccessibleName = "Probe Length"
        Me.ProbeLengthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ProbeLengthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProbeLengthControl.IsCalculated = False
        Me.ProbeLengthControl.IsInteger = False
        Me.ProbeLengthControl.Location = New System.Drawing.Point(124, 56)
        Me.ProbeLengthControl.MaxErrMsg = ""
        Me.ProbeLengthControl.MinErrMsg = ""
        Me.ProbeLengthControl.Name = "ProbeLengthControl"
        Me.ProbeLengthControl.Size = New System.Drawing.Size(104, 24)
        Me.ProbeLengthControl.TabIndex = 5
        Me.ProbeLengthControl.ToBeCalculated = True
        Me.ProbeLengthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ProbeLengthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ProbeLengthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ProbeLengthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ProbeLengthControl.ValueText = ""
        '
        'RootZoneDepthLabel
        '
        Me.RootZoneDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RootZoneDepthLabel.Location = New System.Drawing.Point(4, 8)
        Me.RootZoneDepthLabel.Name = "RootZoneDepthLabel"
        Me.RootZoneDepthLabel.Size = New System.Drawing.Size(120, 23)
        Me.RootZoneDepthLabel.TabIndex = 0
        Me.RootZoneDepthLabel.Text = "&Root Zone Depth"
        Me.RootZoneDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RootZoneDepthControl
        '
        Me.RootZoneDepthControl.AccessibleDescription = "Maximum depth of the crop's roots."
        Me.RootZoneDepthControl.AccessibleName = "Root Zone Depth"
        Me.RootZoneDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RootZoneDepthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RootZoneDepthControl.IsCalculated = False
        Me.RootZoneDepthControl.IsInteger = False
        Me.RootZoneDepthControl.Location = New System.Drawing.Point(124, 8)
        Me.RootZoneDepthControl.MaxErrMsg = ""
        Me.RootZoneDepthControl.MinErrMsg = ""
        Me.RootZoneDepthControl.Name = "RootZoneDepthControl"
        Me.RootZoneDepthControl.Size = New System.Drawing.Size(104, 24)
        Me.RootZoneDepthControl.TabIndex = 1
        Me.RootZoneDepthControl.ToBeCalculated = True
        Me.RootZoneDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.RootZoneDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.RootZoneDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.RootZoneDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.RootZoneDepthControl.ValueText = ""
        '
        'SoilWaterDeficitPanel
        '
        Me.SoilWaterDeficitPanel.AccessibleDescription = "Calculation of irrigation target depth."
        Me.SoilWaterDeficitPanel.AccessibleName = "Irrigation Target"
        Me.SoilWaterDeficitPanel.Controls.Add(Me.IrrigationTargetDepth)
        Me.SoilWaterDeficitPanel.Controls.Add(Me.LeachingRequirement)
        Me.SoilWaterDeficitPanel.Controls.Add(Me.SoilWaterDeficit)
        Me.SoilWaterDeficitPanel.Controls.Add(Me.EqualsLabel)
        Me.SoilWaterDeficitPanel.Controls.Add(Me.LeachingRequirmentLabel)
        Me.SoilWaterDeficitPanel.Controls.Add(Me.PlusLabel)
        Me.SoilWaterDeficitPanel.Controls.Add(Me.SoilWaterDeficitLabel)
        Me.SoilWaterDeficitPanel.Controls.Add(Me.IrrigationTargetDepthLabel)
        Me.SoilWaterDeficitPanel.Location = New System.Drawing.Point(525, 134)
        Me.SoilWaterDeficitPanel.Name = "SoilWaterDeficitPanel"
        Me.SoilWaterDeficitPanel.Size = New System.Drawing.Size(232, 88)
        Me.SoilWaterDeficitPanel.TabIndex = 4
        '
        'IrrigationTargetDepth
        '
        Me.IrrigationTargetDepth.Location = New System.Drawing.Point(165, 56)
        Me.IrrigationTargetDepth.Name = "IrrigationTargetDepth"
        Me.IrrigationTargetDepth.Size = New System.Drawing.Size(56, 23)
        Me.IrrigationTargetDepth.TabIndex = 7
        Me.IrrigationTargetDepth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LeachingRequirement
        '
        Me.LeachingRequirement.Location = New System.Drawing.Point(165, 32)
        Me.LeachingRequirement.Name = "LeachingRequirement"
        Me.LeachingRequirement.Size = New System.Drawing.Size(56, 23)
        Me.LeachingRequirement.TabIndex = 4
        Me.LeachingRequirement.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SoilWaterDeficit
        '
        Me.SoilWaterDeficit.Location = New System.Drawing.Point(165, 8)
        Me.SoilWaterDeficit.Name = "SoilWaterDeficit"
        Me.SoilWaterDeficit.Size = New System.Drawing.Size(56, 23)
        Me.SoilWaterDeficit.TabIndex = 1
        Me.SoilWaterDeficit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EqualsLabel
        '
        Me.EqualsLabel.Location = New System.Drawing.Point(7, 56)
        Me.EqualsLabel.Name = "EqualsLabel"
        Me.EqualsLabel.Size = New System.Drawing.Size(16, 23)
        Me.EqualsLabel.TabIndex = 5
        Me.EqualsLabel.Text = "="
        Me.EqualsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LeachingRequirmentLabel
        '
        Me.LeachingRequirmentLabel.Location = New System.Drawing.Point(23, 32)
        Me.LeachingRequirmentLabel.Name = "LeachingRequirmentLabel"
        Me.LeachingRequirmentLabel.Size = New System.Drawing.Size(144, 23)
        Me.LeachingRequirmentLabel.TabIndex = 3
        Me.LeachingRequirmentLabel.Text = "Leaching Requirment"
        Me.LeachingRequirmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PlusLabel
        '
        Me.PlusLabel.Location = New System.Drawing.Point(7, 32)
        Me.PlusLabel.Name = "PlusLabel"
        Me.PlusLabel.Size = New System.Drawing.Size(16, 23)
        Me.PlusLabel.TabIndex = 2
        Me.PlusLabel.Text = "+"
        Me.PlusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SoilWaterDeficitLabel
        '
        Me.SoilWaterDeficitLabel.Location = New System.Drawing.Point(5, 8)
        Me.SoilWaterDeficitLabel.Name = "SoilWaterDeficitLabel"
        Me.SoilWaterDeficitLabel.Size = New System.Drawing.Size(162, 23)
        Me.SoilWaterDeficitLabel.TabIndex = 0
        Me.SoilWaterDeficitLabel.Text = "Soil Water Deficit"
        Me.SoilWaterDeficitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'IrrigationTargetDepthLabel
        '
        Me.IrrigationTargetDepthLabel.Location = New System.Drawing.Point(23, 56)
        Me.IrrigationTargetDepthLabel.Name = "IrrigationTargetDepthLabel"
        Me.IrrigationTargetDepthLabel.Size = New System.Drawing.Size(144, 23)
        Me.IrrigationTargetDepthLabel.TabIndex = 6
        Me.IrrigationTargetDepthLabel.Text = "Irrigation Target Depth"
        Me.IrrigationTargetDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorsAndWarnings
        '
        Me.ErrorsAndWarnings.AccessibleDescription = "Display of errors and/or warnings for the analysis."
        Me.ErrorsAndWarnings.AccessibleName = "Errors and Warnings"
        Me.ErrorsAndWarnings.Location = New System.Drawing.Point(238, 142)
        Me.ErrorsAndWarnings.Name = "ErrorsAndWarnings"
        Me.ErrorsAndWarnings.ReadOnly = True
        Me.ErrorsAndWarnings.Size = New System.Drawing.Size(286, 72)
        Me.ErrorsAndWarnings.TabIndex = 3
        Me.ErrorsAndWarnings.Text = "Error:" & Global.Microsoft.VisualBasic.ChrW(10) & "Warning:" & Global.Microsoft.VisualBasic.ChrW(10) & "Warning:" & Global.Microsoft.VisualBasic.ChrW(10) & "Warning:" & Global.Microsoft.VisualBasic.ChrW(10) & "Warning:"
        '
        'ctl_InfiltratedProfile
        '
        Me.AccessibleDescription = "Pre and post-irrigation measurements required for a probe penetration analysis."
        Me.AccessibleName = "Soil Water Measurements"
        Me.Controls.Add(Me.SoilWaterDeficitPanel)
        Me.Controls.Add(Me.RootZonePanel)
        Me.Controls.Add(Me.StarLabel)
        Me.Controls.Add(Me.ReadOnlyLabel)
        Me.Controls.Add(Me.ErrorsAndWarnings)
        Me.Controls.Add(Me.IdControl)
        Me.Controls.Add(Me.SwdControl)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_InfiltratedProfile"
        Me.Size = New System.Drawing.Size(760, 420)
        CType(Me.IdControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SwdControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RootZonePanel.ResumeLayout(False)
        Me.SoilWaterDeficitPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Field data
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm

    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mSoilCropProperties As SoilCropProperties

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    Private mMyStore As DataStore.ObjectNode
    '
    ' Supported analyses
    '
    Private mInfiltratedProfile As InfiltratedProfile
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal worldWindow As WorldWindow)

        Debug.Assert(Not (_unit Is Nothing), "Unit is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef

        mWorldWindow = worldWindow

        mMyStore = mUnit.MyStore
        '
        ' Infiltrated Profile Analysis
        '
        mInfiltratedProfile = New InfiltratedProfile(mUnit, mWorldWindow)

        ' Soil Water Depletion DataTable control
        SwdControl.LinkToModel(mMyStore, mSoilCropProperties.SoilWaterDepletionProperty)
        SwdControl.ReadonlyColumn(sCumulativeDepthX) = True
        SwdControl.ReadonlyColumn(sProfileSwdX) = True
        SwdControl.ReadonlyColumn(sCumulativeSwdX) = True
        SwdControl.SelectionColumn(sTextureX) = SoilTextures
        SwdControl.UpdateUI()

        ' Infiltrated Depths DataTable control
        IdControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltratedDepthProperty)
        IdControl.ReadonlyColumn(sProfileIdX) = True
        IdControl.ReadonlyColumn(sRootZoneIdX) = True
        IdControl.ReadonlyColumn(sUsefulIdX) = True
        IdControl.ReadonlyColumn(sDeepPercIdX) = True
        IdControl.UpdateUI()

        ' Root Zone Depth & Leaching Fraction controls
        ProbeLengthControl.LinkToModel(mMyStore, mSoilCropProperties.ProbeLengthProperty)
        RootZoneDepthControl.LinkToModel(mMyStore, mSoilCropProperties.RootZoneDepthProperty)
        LeachingFractionControl.LinkToModel(mMyStore, mSoilCropProperties.LeachingFractionProperty)

        ' Update this control's User Interface
        UpdateUI()

    End Sub

#End Region

#Region " Infiltrated Profile Analysis "
    '
    ' Soil Water Depletion calculations
    '
    ' The Soil Water Depletion table contains user entered and WinSRFR calculated values:
    '
    '   User entered:   Profile Depth       - Depth of soil profile layer
    '                   AWC (mm/m)          - Available Water Capacity for profile layer
    '                   SWD (%)             - Soil Water Depletion for profile layer
    '                   Texture             - Soil texture descriptor (not used at this time)
    '
    '   Calculated:     Cumulative Depth    - Previous Cumulative Depth + Profile Depth
    '                   Profile SWD         - SWD for soil profile layer
    '                   Cumulative SWD      - Previous Cumulative SWD + Profile SWD
    '
    '   These calculations rely solely on values within the Soil Water Depletion table;
    '   no external parameters are involved.
    '
    Private Function CalcSoilWaterDepletion(ByVal _swdTable As DataTable) As Boolean

        If Not (_swdTable Is Nothing) Then

            ' Define values to be calculated
            Dim _cumDepth As Double = 0.0       ' Cumulative Depth
            Dim _profileSWD As Double = 0.0     ' Profile SWD
            Dim _cumSWD As Double = 0.0         ' Cumulative SWD

            ' For each row in the DataTable, update its calculated values
            For Each _dataRow As DataRow In _swdTable.Rows
                ' Enclose in Try/Catch block to trap exceptions
                Try
                    ' Get user entered data
                    Dim _profileDepth As Double = CDbl(_dataRow.Item(sProfileDepthX))
                    Dim _profileAWC As Double = CDbl(_dataRow.Item(sAwcX))
                    Dim _percentSWC As Double = CDbl(_dataRow.Item(sSwdX))
                    Dim _texture As String = CStr(_dataRow.Item(sTextureX))

                    ' Calculate cumulative Depth
                    _cumDepth += _profileDepth
                    _dataRow.Item(sCumulativeDepthX) = _cumDepth

                    ' Calculate profile SWD
                    _profileSWD = (_percentSWC * _profileDepth * _profileAWC)
                    _dataRow.Item(sProfileSwdX) = _profileSWD

                    ' Calculate cumulative SWD
                    _cumSWD += _profileSWD
                    _dataRow.Item(sCumulativeSwdX) = _cumSWD

                Catch ex As Exception
                    Debug.Assert(False, ex.Message)
                    Return False
                End Try
            Next
        Else
            Debug.Assert(False, "DataTable is Nothing")
            Return False
        End If

        Return True

    End Function
    '
    ' Infiltrated Depths calculations
    '
    ' The Infiltrated Depth table contains user entered and WinSRFR calculated values:
    '
    '   User entered:   Distance        - Distance down field of Probed Depth
    '                   Probed Depth    - Probe penetration depth
    '
    '   Calculated:     Profile Infiltrated Depth   - Infiltration within the Profile
    '                   Root Zone Infiltrated Depth - Infiltration within the Root Zone
    '                   Useful Infiltrated Depth    - Infiltration within the Target Depth
    '                   Deep Percolation            - Infiltration beyond Useful
    '
    ' These calculations are dependent on many external parameters & calculations:
    '
    '   Parameters:     Soil Water Depletion table (user entered & WinSRFR calculated)
    '                   Root Zone Depth (user entered)
    '                   Soil Water Deficit (calculated using Root Zone Depth)
    '                   Leaching Fraction (user entered)
    '                   Irrigation Target Depth (calculated using Leaching Fraction)
    '
    Private Function CalcInfiltratedDepths() As Boolean

        Dim _calcOK As Boolean = False

        ' Infiltrated Depth calculations
        Dim _infiltratedDepth As DataTableParameter = mSoilCropProperties.InfiltratedDepth
        Dim _idTable1 As DataTable = _infiltratedDepth.Value

        ' Calculate Infiltrated Depths table values & save if changes were made
        If Not (_idTable1 Is Nothing) Then
            Dim _idTable2 As DataTable = _idTable1.Copy

            _calcOK = CalcInfiltratedDepths(_idTable2)

            If (_calcOK) Then
                ' If changed, save Infiltrated Depths table
                If (DataTablesAreDifferent(_idTable1, _idTable2)) Then
                    _infiltratedDepth.Value = _idTable2
                    _infiltratedDepth.Source = DataStore.Globals.ValueSources.Calculated
                    mSoilCropProperties.InfiltratedDepth = _infiltratedDepth
                End If
            End If
        End If

        Return _calcOK

    End Function

    Private Function CalcInfiltratedDepths(ByVal _idTable As DataTable) As Boolean

        If Not (_idTable Is Nothing) Then

            ' Get SWD values
            Dim _probeLength As Double = mSoilCropProperties.ProbeLength.Value
            Dim _rootZoneDepth As Double = mSoilCropProperties.RootZoneDepth.Value
            Dim _targetDepth As Double = mSoilCropProperties.IrrigationTargetDepth

            Dim _profileRootZoneDepth As Double = mSoilCropProperties.ProfileRootZoneDepth
            Dim _profileRootZoneSWD As Double = mSoilCropProperties.ProfileSoilWaterDeficit

            Dim _cumulativeProfileDepth As Double = mSoilCropProperties.CumulativeProfileDepth
            Dim _cumulativeSWD As Double = mSoilCropProperties.CumulativeSWD

            ' Get ID values
            Dim _lastRow As DataRow = _idTable.Rows(_idTable.Rows.Count - 1)
            Dim _lastDistance As Double = CDbl(_lastRow.Item(sDistanceX))

            ' For each row in the DataTable, update its calculated values
            For Each _dataRow As DataRow In _idTable.Rows
                ' Enclose in Try/Catch block to trap exceptions
                Try
                    ' Get user entered data
                    Dim _probedDepth As Double = CDbl(_dataRow.Item(sProbedDepthX))
                    Dim _probedSWD As Double = mSoilCropProperties.InterpolateSwd(_probedDepth)
                    '
                    ' Profile Infiltrated Depth
                    '
                    Dim _profileID As Double = Double.NaN

                    If Not (_probeLength < _probedDepth) Then
                        If (_probedDepth < _cumulativeProfileDepth) Then
                            _profileID = _probedSWD
                        Else
                            _profileID = _cumulativeSWD
                        End If
                    End If

                    _dataRow.Item(sProfileIdX) = _profileID
                    '
                    ' Root Zone Infiltrated Depth
                    '
                    Dim _rootZoneID As Double = Double.NaN

                    If Not (_probeLength < _probedDepth) Then
                        If (_probedDepth < _profileRootZoneDepth) Then
                            _rootZoneID = _probedSWD
                        Else
                            _rootZoneID = _profileRootZoneSWD
                        End If
                    End If

                    _dataRow.Item(sRootZoneIdX) = _rootZoneID
                    '
                    ' Useful Infiltrated Depth
                    '
                    Dim _usefulID As Double = Double.NaN

                    If Not (_probeLength < _probedDepth) Then
                        If (_probedSWD < _targetDepth) Then
                            _usefulID = _probedSWD
                        Else
                            _usefulID = _targetDepth
                        End If
                    End If

                    _dataRow.Item(sUsefulIdX) = _usefulID
                    '
                    ' Deep Percolation
                    '
                    Dim _deepPercolation As Double = Double.NaN

                    If Not (_probeLength < _probedDepth) Then
                        ' Check for underestimation of Leaching Requirement
                        If (_usefulID < _targetDepth) Then
                            If ((_cumulativeProfileDepth < _probedDepth) _
                             Or (_probeLength = _probedDepth)) Then
                            Else
                                _deepPercolation = _profileID - _usefulID
                            End If
                        Else
                            _deepPercolation = _profileID - _usefulID
                        End If
                    End If

                    _dataRow.Item(sDeepPercIdX) = _deepPercolation

                Catch ex As Exception
                    Debug.Assert(False, ex.Message)
                    Return False
                End Try
            Next

            ' Update UI display values
            Me.UpdateUI()
        Else
            Debug.Assert(False, "DataTable is Nothing")
            Return False
        End If

        Return True

    End Function

#End Region

#Region " UI Update Methods "

    Private Sub ctl_InfiltratedProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        UpdateUI()
    End Sub

    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        ' Set maximum Distance table value(s)
        Me.IdControl.FirstColumnMaximum = mSystemGeometry.Length.Value

        ' Update UI display values
        Dim _soilWaterDeficit As Double = mSoilCropProperties.ProfileSoilWaterDeficit
        Me.SoilWaterDeficit.Text = DepthString(_soilWaterDeficit, 0)

        Dim _leachingRequirement As Double = mSoilCropProperties.LeachingRequirement
        Me.LeachingRequirement.Text = DepthString(_leachingRequirement, 0)

        Dim _targetDepth As Double = mSoilCropProperties.IrrigationTargetDepth
        Me.IrrigationTargetDepth.Text = DepthString(_targetDepth, 0)

        ' Update UI display of Errors & Warnings
        If (mInfiltratedProfile.CheckSetupWarnings) Then
            Me.ErrorsAndWarnings.Show()
            Me.ErrorsAndWarnings.Clear()
            Me.ErrorsAndWarnings.DisplayWarnings(mInfiltratedProfile, False)
        Else
            Me.ErrorsAndWarnings.Hide()
        End If
    End Sub

    Private Sub ctl_InfiltratedProfile_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        ResizeUI()
    End Sub

    Private Sub ResizeUI()

        ' Adjust contained controls to match new size
        Dim tableWidth As Integer = Me.Width - 8
        Dim tableHeight As Integer = Me.Height - Me.RootZonePanel.Height - Me.ReadOnlyLabel.Height - 8
        Dim swdHeight As Integer = tableHeight * (2 / 5)
        Dim idHeight As Integer = tableHeight - swdHeight

        ' Position & size SWD table
        Dim locX As Integer = 4
        Dim locY As Integer = 4
        Me.SwdControl.Location = New Point(locX, locY)
        Me.SwdControl.Width = tableWidth
        Me.SwdControl.Height = swdHeight
        Me.SwdControl.UpdateUI()

        ' Position & size middle controls
        locX = 4
        locY = SwdControl.Height + 2
        Me.RootZonePanel.Location = New Point(locX, locY)

        locX = Me.Width - Me.SoilWaterDeficitPanel.Width - 4
        Me.SoilWaterDeficitPanel.Location = New Point(locX, locY)

        locX = Me.RootZonePanel.Location.X + Me.RootZonePanel.Width
        locY = Me.RootZonePanel.Location.Y + 1
        Me.ErrorsAndWarnings.Location = New Point(locX, locY)
        Me.ErrorsAndWarnings.Width = tableWidth - Me.RootZonePanel.Width - Me.SoilWaterDeficitPanel.Width
        Me.ErrorsAndWarnings.Height = Me.RootZonePanel.Height - 2

        ' Position & size ID table
        locX = 4
        locY = Me.RootZonePanel.Location.Y + Me.RootZonePanel.Height
        Me.IdControl.Location = New Point(locX, locY)
        Me.IdControl.Width = tableWidth
        Me.IdControl.Height = idHeight
        Me.IdControl.UpdateUI()

        ' Position & size 'Calculated by WinSRFR' text
        locX = Me.Width - Me.ReadOnlyLabel.Width - 4
        locY = Me.Height - Me.ReadOnlyLabel.Height - 4
        Me.ReadOnlyLabel.Location = New Point(locX, locY)

        locX -= Me.StarLabel.Width
        Me.StarLabel.Location = New Point(locX, locY)

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " UI Event Handler(s) "
    '
    ' Soil Water Depletion DataTable
    '
    ' Pre-Save Action - After a change to a user value within the Soil Water Depletion table,
    '                   but before the table is saved, the calculated values must be updated.
    '
    Private Sub SwdControl_PreSaveAction(ByVal _swdTable As DataTable, ByRef _saveOK As Boolean) _
    Handles SwdControl.PreSaveAction

        If Not (_swdTable Is Nothing) Then
            ' Update the calculated values within the Soil Water Depletion table
            _saveOK = CalcSoilWaterDepletion(_swdTable)
        Else
            Debug.Assert(False, "DataTable is Nothing")
            _saveOK = False
        End If

    End Sub
    '
    ' Post-Save Action - The Infiltrated Depths table calculations are dependent on the
    '                    Soil Water Depletion table
    '
    Private Sub SwdControl_ControlValueChanged() _
    Handles SwdControl.ControlValueChanged
        CalcInfiltratedDepths()
    End Sub
    '
    ' Infiltrated Depths DataTable
    '
    ' Pre-Save Action - After a change to a user value within the Infiltrated Depths table,
    '                   but before the table is saved, the calculated values must be updated.
    '
    Private Sub IdControl_PreSaveAction(ByVal _idTable As DataTable, ByRef _saveOK As Boolean) _
    Handles IdControl.PreSaveAction

        If Not (_idTable Is Nothing) Then
            _saveOK = CalcInfiltratedDepths(_idTable)
        Else
            Debug.Assert(False, "DataTable is Nothing")
            _saveOK = False
        End If

    End Sub
    '
    ' Probe Length
    '
    ' Post-Save Action - The Infiltrated Depths table calculations are dependent on the
    '                    Probe Length
    '
    Private Sub ProbeLengthControl_ControlValueChanged() _
    Handles ProbeLengthControl.ControlValueChanged
        CalcInfiltratedDepths()
    End Sub
    '
    ' Root Zone Depth
    '
    ' Post-Save Action - The Infiltrated Depths table calculations are dependent on the
    '                    Root Zone Depth
    '
    Private Sub RootZoneDepthControl_ControlValueChanged() _
    Handles RootZoneDepthControl.ControlValueChanged
        CalcInfiltratedDepths()
    End Sub
    '
    ' Leaching Fraction 
    '
    ' Post-Save Action - The Infiltrated Depths table calculations are dependent on the
    '                    Leaching Fraction
    '
    Private Sub LeachingFractionControl_ControlValueChanged() _
    Handles LeachingFractionControl.ControlValueChanged
        CalcInfiltratedDepths()
    End Sub
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' Update the UI when System Geometry changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        If Not (mWorldWindow.Running) Then
            UpdateUI()
        End If
    End Sub
    '
    ' Update the UI when Soil Crop Properteis data changes
    '
    Private Sub SoilCropProperties_PropertyChanged(ByVal _reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        If Not (mWorldWindow.Running) Then
            UpdateUI()
        End If
    End Sub
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
    ' Update the graphics when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        ' Don't allow event driven updates prior to initialization
        If (mSystemGeometry IsNot Nothing) Then
            UpdateUI()
        End If
    End Sub

#End Region

End Class
