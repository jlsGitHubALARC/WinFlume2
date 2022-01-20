
'*************************************************************************************************************
' ctl_OperationsWorld - Operations World Tab UI
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_OperationsWorld
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
    Friend WithEvents OperationsWorldHelp As System.Windows.Forms.RichTextBox
    Friend WithEvents SystemTypeGroup As DataStore.ctl_GroupBox
    Friend WithEvents FurrowButton As DataStore.ctl_RadioButton
    Friend WithEvents BasinBorderButton As DataStore.ctl_RadioButton
    Friend WithEvents OperationsWorldUsage As System.Windows.Forms.RichTextBox
    Friend WithEvents OperationsWorldTitle As DataStore.ctl_Label
    Friend WithEvents OperationsBox As DataStore.ctl_GroupBox
    Friend WithEvents UsingLabel As DataStore.ctl_Label
    Friend WithEvents DepthCriteriaControl As DataStore.ctl_SelectParameter
    Friend WithEvents DepthCriteriaLabel As DataStore.ctl_Label
    Friend WithEvents WidthOption As System.Windows.Forms.RadioButton
    Friend WithEvents IrrigationWaterUseBox As DataStore.ctl_GroupBox
    Friend WithEvents UnitWaterCostControl As DataStore.ctl_DoubleParameter
    Friend WithEvents UnitWaterCostLabel As DataStore.ctl_Label
    Friend WithEvents RequiredDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents RequiredDepthLabel As DataStore.ctl_Label
    Friend WithEvents InflowRateOption As System.Windows.Forms.RadioButton
    Friend WithEvents IWantLabel As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctl_OperationsWorld))
        Me.OperationsWorldHelp = New System.Windows.Forms.RichTextBox()
        Me.SystemTypeGroup = New DataStore.ctl_GroupBox()
        Me.FurrowButton = New DataStore.ctl_RadioButton()
        Me.BasinBorderButton = New DataStore.ctl_RadioButton()
        Me.OperationsWorldUsage = New System.Windows.Forms.RichTextBox()
        Me.OperationsWorldTitle = New DataStore.ctl_Label()
        Me.OperationsBox = New DataStore.ctl_GroupBox()
        Me.InflowRateOption = New System.Windows.Forms.RadioButton()
        Me.UsingLabel = New DataStore.ctl_Label()
        Me.DepthCriteriaControl = New DataStore.ctl_SelectParameter()
        Me.DepthCriteriaLabel = New DataStore.ctl_Label()
        Me.WidthOption = New System.Windows.Forms.RadioButton()
        Me.IWantLabel = New DataStore.ctl_Label()
        Me.IrrigationWaterUseBox = New DataStore.ctl_GroupBox()
        Me.UnitWaterCostControl = New DataStore.ctl_DoubleParameter()
        Me.UnitWaterCostLabel = New DataStore.ctl_Label()
        Me.RequiredDepthControl = New DataStore.ctl_DoubleParameter()
        Me.RequiredDepthLabel = New DataStore.ctl_Label()
        Me.SystemTypeGroup.SuspendLayout()
        Me.OperationsBox.SuspendLayout()
        Me.IrrigationWaterUseBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'OperationsWorldHelp
        '
        Me.OperationsWorldHelp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.OperationsWorldHelp.Location = New System.Drawing.Point(441, 73)
        Me.OperationsWorldHelp.Name = "OperationsWorldHelp"
        Me.OperationsWorldHelp.Size = New System.Drawing.Size(329, 344)
        Me.OperationsWorldHelp.TabIndex = 7
        Me.OperationsWorldHelp.Text = ""
        '
        'SystemTypeGroup
        '
        Me.SystemTypeGroup.AccessibleDescription = "Selects the fundamental field type."
        Me.SystemTypeGroup.AccessibleName = "System Type"
        Me.SystemTypeGroup.Controls.Add(Me.FurrowButton)
        Me.SystemTypeGroup.Controls.Add(Me.BasinBorderButton)
        Me.SystemTypeGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemTypeGroup.Location = New System.Drawing.Point(10, 78)
        Me.SystemTypeGroup.Name = "SystemTypeGroup"
        Me.SystemTypeGroup.Size = New System.Drawing.Size(160, 76)
        Me.SystemTypeGroup.TabIndex = 3
        Me.SystemTypeGroup.TabStop = False
        Me.SystemTypeGroup.Text = "System Type"
        '
        'FurrowButton
        '
        Me.FurrowButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowButton.Location = New System.Drawing.Point(11, 44)
        Me.FurrowButton.Name = "FurrowButton"
        Me.FurrowButton.Size = New System.Drawing.Size(143, 24)
        Me.FurrowButton.TabIndex = 2
        Me.FurrowButton.Text = "&Furrow"
        '
        'BasinBorderButton
        '
        Me.BasinBorderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BasinBorderButton.Location = New System.Drawing.Point(11, 22)
        Me.BasinBorderButton.Name = "BasinBorderButton"
        Me.BasinBorderButton.Size = New System.Drawing.Size(143, 24)
        Me.BasinBorderButton.TabIndex = 1
        Me.BasinBorderButton.Text = "&Basin / Border"
        '
        'OperationsWorldUsage
        '
        Me.OperationsWorldUsage.BackColor = System.Drawing.SystemColors.Control
        Me.OperationsWorldUsage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OperationsWorldUsage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OperationsWorldUsage.Location = New System.Drawing.Point(10, 31)
        Me.OperationsWorldUsage.Name = "OperationsWorldUsage"
        Me.OperationsWorldUsage.ReadOnly = True
        Me.OperationsWorldUsage.Size = New System.Drawing.Size(760, 40)
        Me.OperationsWorldUsage.TabIndex = 1
        Me.OperationsWorldUsage.TabStop = False
        Me.OperationsWorldUsage.Text = resources.GetString("OperationsWorldUsage.Text")
        '
        'OperationsWorldTitle
        '
        Me.OperationsWorldTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OperationsWorldTitle.Location = New System.Drawing.Point(10, 7)
        Me.OperationsWorldTitle.Name = "OperationsWorldTitle"
        Me.OperationsWorldTitle.Size = New System.Drawing.Size(760, 24)
        Me.OperationsWorldTitle.TabIndex = 0
        Me.OperationsWorldTitle.Text = "Operations Analysis World"
        Me.OperationsWorldTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OperationsBox
        '
        Me.OperationsBox.AccessibleDescription = "Selects the Operations Function for WinSRFR to run."
        Me.OperationsBox.AccessibleName = "Operations Analysis"
        Me.OperationsBox.Controls.Add(Me.InflowRateOption)
        Me.OperationsBox.Controls.Add(Me.UsingLabel)
        Me.OperationsBox.Controls.Add(Me.DepthCriteriaControl)
        Me.OperationsBox.Controls.Add(Me.DepthCriteriaLabel)
        Me.OperationsBox.Controls.Add(Me.WidthOption)
        Me.OperationsBox.Controls.Add(Me.IWantLabel)
        Me.OperationsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OperationsBox.Location = New System.Drawing.Point(10, 161)
        Me.OperationsBox.Name = "OperationsBox"
        Me.OperationsBox.Size = New System.Drawing.Size(425, 256)
        Me.OperationsBox.TabIndex = 6
        Me.OperationsBox.TabStop = False
        Me.OperationsBox.Text = "Contour Options"
        '
        'InflowRateOption
        '
        Me.InflowRateOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRateOption.Location = New System.Drawing.Point(11, 105)
        Me.InflowRateOption.Name = "InflowRateOption"
        Me.InflowRateOption.Size = New System.Drawing.Size(408, 52)
        Me.InflowRateOption.TabIndex = 2
        Me.InflowRateOption.Text = "Furrows per Set and Cutoff Time for the known &Inflow Rate "
        '
        'UsingLabel
        '
        Me.UsingLabel.Location = New System.Drawing.Point(15, 165)
        Me.UsingLabel.Name = "UsingLabel"
        Me.UsingLabel.Size = New System.Drawing.Size(403, 23)
        Me.UsingLabel.TabIndex = 3
        Me.UsingLabel.Text = "Irrigation requirement criterion:"
        '
        'DepthCriteriaControl
        '
        Me.DepthCriteriaControl.AccessibleDescription = "Specifies what contour depth should be displayed in the Results."
        Me.DepthCriteriaControl.AccessibleName = "Depth Criteria"
        Me.DepthCriteriaControl.ApplicationValue = -1
        Me.DepthCriteriaControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DepthCriteriaControl.EnableSaveActions = False
        Me.DepthCriteriaControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthCriteriaControl.IsCalculated = False
        Me.DepthCriteriaControl.Location = New System.Drawing.Point(211, 194)
        Me.DepthCriteriaControl.Name = "DepthCriteriaControl"
        Me.DepthCriteriaControl.SelectedIndexSet = False
        Me.DepthCriteriaControl.Size = New System.Drawing.Size(152, 24)
        Me.DepthCriteriaControl.TabIndex = 5
        '
        'DepthCriteriaLabel
        '
        Me.DepthCriteriaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthCriteriaLabel.Location = New System.Drawing.Point(11, 194)
        Me.DepthCriteriaLabel.Name = "DepthCriteriaLabel"
        Me.DepthCriteriaLabel.Size = New System.Drawing.Size(194, 23)
        Me.DepthCriteriaLabel.TabIndex = 4
        Me.DepthCriteriaLabel.Text = "Depth to Display"
        Me.DepthCriteriaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WidthOption
        '
        Me.WidthOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WidthOption.Location = New System.Drawing.Point(11, 54)
        Me.WidthOption.Name = "WidthOption"
        Me.WidthOption.Size = New System.Drawing.Size(408, 52)
        Me.WidthOption.TabIndex = 1
        Me.WidthOption.Text = "Inflow Rate and Cutoff time for the known Border (furrow set) &Width"
        '
        'IWantLabel
        '
        Me.IWantLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IWantLabel.Location = New System.Drawing.Point(15, 30)
        Me.IWantLabel.Name = "IWantLabel"
        Me.IWantLabel.Size = New System.Drawing.Size(403, 23)
        Me.IWantLabel.TabIndex = 0
        Me.IWantLabel.Text = "Develop performance contours as a function of:"
        '
        'IrrigationWaterUseBox
        '
        Me.IrrigationWaterUseBox.AccessibleDescription = "Sets the required infiltration depth and unit water cost."
        Me.IrrigationWaterUseBox.AccessibleName = "Irrigation Water Use"
        Me.IrrigationWaterUseBox.Controls.Add(Me.UnitWaterCostControl)
        Me.IrrigationWaterUseBox.Controls.Add(Me.UnitWaterCostLabel)
        Me.IrrigationWaterUseBox.Controls.Add(Me.RequiredDepthControl)
        Me.IrrigationWaterUseBox.Controls.Add(Me.RequiredDepthLabel)
        Me.IrrigationWaterUseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IrrigationWaterUseBox.Location = New System.Drawing.Point(176, 78)
        Me.IrrigationWaterUseBox.Name = "IrrigationWaterUseBox"
        Me.IrrigationWaterUseBox.Size = New System.Drawing.Size(259, 76)
        Me.IrrigationWaterUseBox.TabIndex = 10
        Me.IrrigationWaterUseBox.TabStop = False
        Me.IrrigationWaterUseBox.Text = "Irrigation Water Use"
        '
        'UnitWaterCostControl
        '
        Me.UnitWaterCostControl.AccessibleDescription = "The cost of the irrigation water."
        Me.UnitWaterCostControl.AccessibleName = "Unit Water Cost"
        Me.UnitWaterCostControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.UnitWaterCostControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitWaterCostControl.IsCalculated = False
        Me.UnitWaterCostControl.IsInteger = False
        Me.UnitWaterCostControl.Location = New System.Drawing.Point(133, 48)
        Me.UnitWaterCostControl.MaxErrMsg = ""
        Me.UnitWaterCostControl.MinErrMsg = ""
        Me.UnitWaterCostControl.Name = "UnitWaterCostControl"
        Me.UnitWaterCostControl.Size = New System.Drawing.Size(121, 24)
        Me.UnitWaterCostControl.TabIndex = 8
        Me.UnitWaterCostControl.ToBeCalculated = True
        Me.UnitWaterCostControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.UnitWaterCostControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.UnitWaterCostControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.UnitWaterCostControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.UnitWaterCostControl.ValueText = ""
        '
        'UnitWaterCostLabel
        '
        Me.UnitWaterCostLabel.AccessibleDescription = "Cost per unit of irrigation water applied to field."
        Me.UnitWaterCostLabel.AccessibleName = "Unit Water Cost"
        Me.UnitWaterCostLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitWaterCostLabel.Location = New System.Drawing.Point(7, 48)
        Me.UnitWaterCostLabel.Name = "UnitWaterCostLabel"
        Me.UnitWaterCostLabel.Size = New System.Drawing.Size(120, 23)
        Me.UnitWaterCostLabel.TabIndex = 7
        Me.UnitWaterCostLabel.Text = "Unit Water &Cost"
        Me.UnitWaterCostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RequiredDepthControl
        '
        Me.RequiredDepthControl.AccessibleDescription = "Defines the desired depth the irrigation water should infiltrate the soil."
        Me.RequiredDepthControl.AccessibleName = "Required Depth"
        Me.RequiredDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RequiredDepthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequiredDepthControl.IsCalculated = False
        Me.RequiredDepthControl.IsInteger = False
        Me.RequiredDepthControl.Location = New System.Drawing.Point(133, 23)
        Me.RequiredDepthControl.MaxErrMsg = ""
        Me.RequiredDepthControl.MinErrMsg = ""
        Me.RequiredDepthControl.Name = "RequiredDepthControl"
        Me.RequiredDepthControl.Size = New System.Drawing.Size(121, 24)
        Me.RequiredDepthControl.TabIndex = 6
        Me.RequiredDepthControl.ToBeCalculated = True
        Me.RequiredDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.RequiredDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.RequiredDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.RequiredDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.RequiredDepthControl.ValueText = ""
        '
        'RequiredDepthLabel
        '
        Me.RequiredDepthLabel.AccessibleDescription = "Required infiltration depth, Dreq, for this irrigation."
        Me.RequiredDepthLabel.AccessibleName = "Required Depth"
        Me.RequiredDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequiredDepthLabel.Location = New System.Drawing.Point(7, 22)
        Me.RequiredDepthLabel.Name = "RequiredDepthLabel"
        Me.RequiredDepthLabel.Size = New System.Drawing.Size(120, 23)
        Me.RequiredDepthLabel.TabIndex = 5
        Me.RequiredDepthLabel.Text = "Required &Depth"
        Me.RequiredDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ctl_OperationsWorld
        '
        Me.Controls.Add(Me.IrrigationWaterUseBox)
        Me.Controls.Add(Me.SystemTypeGroup)
        Me.Controls.Add(Me.OperationsWorldTitle)
        Me.Controls.Add(Me.OperationsWorldUsage)
        Me.Controls.Add(Me.OperationsWorldHelp)
        Me.Controls.Add(Me.OperationsBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_OperationsWorld"
        Me.Size = New System.Drawing.Size(776, 422)
        Me.SystemTypeGroup.ResumeLayout(False)
        Me.OperationsBox.ResumeLayout(False)
        Me.IrrigationWaterUseBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm

    Private mDictionary As Dictionary
    Private mMyStore As DataStore.ObjectNode

    Private WithEvents mWinSRFR As WinSRFR
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mBorderCriteria As BorderCriteria

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Public Sub LinkToModel(ByVal _unit As Unit)

        Debug.Assert(Not (_unit Is Nothing), "Unit is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mBorderCriteria = mUnit.BorderCriteriaRef

        mDictionary = Dictionary.Instance
        mMyStore = mUnit.MyStore

        ' Link the contained controls to their models & store
        RequiredDepthControl.LinkToModel(mMyStore, mInflowManagement.RequiredDepthProperty)
        UnitWaterCostControl.LinkToModel(mMyStore, mInflowManagement.UnitWaterCostProperty)

        DepthCriteriaControl.LinkToModel(mMyStore, mBorderCriteria.InfiltratedDepthCriterionProperty)

        ' Update language translation
        UpdateLanguage()

        ' Update the control's User Interface
        UpdateUI()

    End Sub

#End Region

#Region " Update UI "

#Region " Operations World "
    '
    ' Update the Design World's UI
    '
    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mUnit IsNot Nothing) Then
            '
            ' Display world usage instructions
            '
            Me.OperationsWorldUsage.Text = mDictionary.tOperationsWorldUsage.Translated & "  "
            Me.OperationsWorldUsage.Text &= mDictionary.tProceedDownTabs.Translated
            '
            ' Set controls to their correct color
            '
            If (SystemInformation.HighContrast) Then
                OperationsWorldHelp.BackColor = System.Drawing.SystemColors.Window
                OperationsWorldHelp.ForeColor = System.Drawing.SystemColors.WindowText
            Else
                OperationsWorldHelp.BackColor = mWinSRFR.OperationsBackColor
                OperationsWorldHelp.ForeColor = mWinSRFR.OperationsForeColor
            End If

            ' Update System Criteria
            UpdateCrossSection()

            UpdateDepthCriteria()

            UpdateContourOperationsOptions()

            ' Update the Operations World Help text
            UpdateOperationsWorldHelp()
        End If

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me)
        UpdateUI()
    End Sub

#End Region

#Region " System Type "
    '
    ' Update the UI's Cross Section
    '
    Private Sub UpdateCrossSection()
        If Not (mSystemGeometry Is Nothing) Then
            ' Hide/Show/Limit controls & check to appropriate item
            Select Case (mSystemGeometry.CrossSection.Value)

                Case CrossSections.Basin, CrossSections.Border
                    ' World Tab
                    BasinBorderButton.Checked = True

                    'Me.WidthOption.Text = mDictionary.tOperationsGivenBorderWidth.Translated
                    'Me.InflowRateOption.Text = mDictionary.tOperationsGivenInflowRate.Translated

                Case Else ' Assume Furrow
                    ' World Tab
                    FurrowButton.Checked = True

                    'Me.WidthOption.Text = mDictionary.tOperationsGivenFurrowsPerSet.Translated
                    'Me.InflowRateOption.Text = mDictionary.tOperationsGivenInflowRate.Translated

            End Select
        End If
    End Sub

#End Region

#Region " Basin / Border / Furrow Contour Operations "
    '
    ' Depth Criteria
    '
    Private Sub UpdateDepthCriteria()
        If (mBorderCriteria IsNot Nothing) Then
            ' Update Depth Criteria selection list
            DepthCriteriaControl.Clear()

            Dim _sel As String = mBorderCriteria.GetFirstInfiltratedDepthCriteriaSelection
            Dim _idx As Integer = 0
            While Not (_sel Is Nothing)
                If Not (_sel = String.Empty) Then
                    DepthCriteriaControl.Add(_sel, _idx)
                End If

                _sel = mBorderCriteria.GetNextInfiltratedDepthCriteriaSelection
                _idx += 1
            End While

            ' Update selection
            DepthCriteriaControl.UpdateUI()
        End If
    End Sub
    '
    ' Contour Description
    '
    Private Sub UpdateContourOperationsOptions()
        If (mBorderCriteria IsNot Nothing) Then

            If (mUnit.CrossSection = CrossSections.Furrow) Then

                Me.InflowRateOption.Enabled = True

                Select Case (mBorderCriteria.OperationsOption.Value)
                    Case OperationsOptions.WidthGiven
                        Me.WidthOption.Checked = True

                    Case Else ' Assume OperationsOptions.InflowRateGiven
                        Me.InflowRateOption.Checked = True

                End Select

            Else ' Basin or Border

                Me.InflowRateOption.Enabled = False
                Me.WidthOption.Checked = True

            End If
        End If
    End Sub

#End Region

#End Region

#Region " Operations World Help "

    Private Sub UpdateOperationsWorldHelp()

        OperationsWorldHelp.Clear()
        OperationsWorldHelp.SelectionAlignment = HorizontalAlignment.Center

        Select Case (mSystemGeometry.CrossSection.Value)

            Case CrossSections.Basin, CrossSections.Border

                AppendBoldUnderlineLine(OperationsWorldHelp, mDictionary.tInflowRateCutoffTradeoffs.Translated)
                AdvanceLine(OperationsWorldHelp)

                OperationsWorldHelp.SelectionAlignment = HorizontalAlignment.Left

                AppendLine(OperationsWorldHelp, mDictionary.tOperationsBorderInflowRateCutoff.Translated)
                AdvanceLine(OperationsWorldHelp)

                AppendBoldLine(OperationsWorldHelp, mDictionary.tValuesYouWillEnter.Translated & ":")
                AppendLine(OperationsWorldHelp, "     " & mDictionary.tLength.Translated)
                AppendLine(OperationsWorldHelp, "     " & mDictionary.tWidth.Translated)

                Select Case (mInflowManagement.CutoffMethod.Value)
                    Case CutoffMethods.DistanceBased
                        AppendLine(OperationsWorldHelp, "     " & mDictionary.tRangesInflowRateCutoffLocation.Translated)
                        AppendLine(OperationsWorldHelp, "     " & mDictionary.tAndOtherParameters.Translated & "...")
                        AdvanceLine(OperationsWorldHelp)

                        AppendBoldLine(OperationsWorldHelp, mDictionary.tValuesWinSrfrWillCalculate.Translated & ":")
                        AppendLine(OperationsWorldHelp, "     " & mDictionary.tInflowRateCutoffLocationContours.Translated)
                        AdvanceLine(OperationsWorldHelp)
                    Case Else ' Assume CutoffMethods.TimeBased
                        AppendLine(OperationsWorldHelp, "     " & mDictionary.tRangesInflowRateCutoffTime.Translated)
                        AppendLine(OperationsWorldHelp, "     " & mDictionary.tAndOtherParameters.Translated & "...")
                        AdvanceLine(OperationsWorldHelp)

                        AppendBoldLine(OperationsWorldHelp, mDictionary.tValuesWinSrfrWillCalculate.Translated & ":")
                        AppendLine(OperationsWorldHelp, "     " & mDictionary.tInflowRateCutoffTimeContours.Translated)
                        AdvanceLine(OperationsWorldHelp)
                End Select

                AppendBoldLine(OperationsWorldHelp, mDictionary.tThenYouWill.Translated & "...")
                AppendLine(OperationsWorldHelp, mDictionary.tSelectContourPoint.Translated)

            Case Else ' Assume CrossSections.Furrow

                Select Case (mBorderCriteria.OperationsOption.Value)

                    Case OperationsOptions.WidthGiven

                        AppendBoldUnderlineLine(OperationsWorldHelp, mDictionary.tInflowRateCutoffTradeoffs.Translated)
                        AdvanceLine(OperationsWorldHelp)

                        OperationsWorldHelp.SelectionAlignment = HorizontalAlignment.Left

                        AppendLine(OperationsWorldHelp, mDictionary.tOperationsFurrowInflowRateCutoff.Translated)
                        AdvanceLine(OperationsWorldHelp)

                        AppendBoldLine(OperationsWorldHelp, mDictionary.tValuesYouWillEnter.Translated & ":")
                        AppendLine(OperationsWorldHelp, "     " & mDictionary.tLength.Translated)
                        AppendLine(OperationsWorldHelp, "     " & mDictionary.tFurrowsPerSet.Translated)

                        Select Case (mInflowManagement.CutoffMethod.Value)
                            Case CutoffMethods.DistanceBased
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tRangesInflowRateCutoffLocation.Translated)
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tAndOtherParameters.Translated & "...")
                                AdvanceLine(OperationsWorldHelp)

                                AppendBoldLine(OperationsWorldHelp, mDictionary.tValuesWinSrfrWillCalculate.Translated & ":")
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tInflowRateCutoffLocationContours.Translated)
                                AdvanceLine(OperationsWorldHelp)
                            Case Else ' Assume CutoffMethods.TimeBased
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tRangesInflowRateCutoffTime.Translated)
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tAndOtherParameters.Translated & "...")
                                AdvanceLine(OperationsWorldHelp)

                                AppendBoldLine(OperationsWorldHelp, mDictionary.tValuesWinSrfrWillCalculate.Translated & ":")
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tInflowRateCutoffTimeContours.Translated)
                                AdvanceLine(OperationsWorldHelp)
                        End Select

                        AppendBoldLine(OperationsWorldHelp, mDictionary.tThenYouWill.Translated & "...")
                        AppendLine(OperationsWorldHelp, mDictionary.tSelectContourPoint.Translated)

                    Case Else ' Assume OperationsOptions.InflowRateGiven

                        AppendBoldUnderlineLine(OperationsWorldHelp, mDictionary.tFurrowsPerSetCutoffTradeoffs.Translated)
                        AdvanceLine(OperationsWorldHelp)

                        OperationsWorldHelp.SelectionAlignment = HorizontalAlignment.Left

                        AppendLine(OperationsWorldHelp, mDictionary.tOperationsFurrowsPerSetCutoff.Translated)
                        AdvanceLine(OperationsWorldHelp)

                        AppendBoldLine(OperationsWorldHelp, mDictionary.tValuesYouWillEnter.Translated & ":")
                        AppendLine(OperationsWorldHelp, "     " & mDictionary.tLength.Translated)
                        AppendLine(OperationsWorldHelp, "     " & mDictionary.tInflowRate.Translated)

                        Select Case (mInflowManagement.CutoffMethod.Value)
                            Case CutoffMethods.DistanceBased
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tRangesFurrowsPerSetCutoffLocation.Translated)
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tAndOtherParameters.Translated & "...")
                                AdvanceLine(OperationsWorldHelp)

                                AppendBoldLine(OperationsWorldHelp, mDictionary.tValuesWinSrfrWillCalculate.Translated & ":")
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tFurrowsPerSetCutoffLocationContours.Translated)
                                AdvanceLine(OperationsWorldHelp)
                            Case Else ' Assume CutoffMethods.TimeBased
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tRangesFurrowsPerSetCutoffTime.Translated)
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tAndOtherParameters.Translated & "...")
                                AdvanceLine(OperationsWorldHelp)

                                AppendBoldLine(OperationsWorldHelp, mDictionary.tValuesWinSrfrWillCalculate.Translated & ":")
                                AppendLine(OperationsWorldHelp, "     " & mDictionary.tFurrowsPerSetCutoffTimeContours.Translated)
                                AdvanceLine(OperationsWorldHelp)
                        End Select

                        AppendBoldLine(OperationsWorldHelp, mDictionary.tThenYouWill.Translated & "...")
                        AppendLine(OperationsWorldHelp, mDictionary.tSelectContourPoint.Translated)

                End Select

        End Select

    End Sub

#End Region

#Region " UI Event Handlers "

#Region " System Type Selection "

    Private Sub BasinBorderButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BasinBorderButton.CheckedChanged
        If (BasinBorderButton.Checked) Then
            Dim _crossSection As IntegerParameter = mSystemGeometry.CrossSection
            If Not (_crossSection.Value = CrossSections.Border) Then

                Dim undoText As String = BasinBorderButton.Text.Replace("&", "")
                mMyStore.MarkForUndo(undoText)

                _crossSection.Value = CrossSections.Border
                _crossSection.Source = DataStore.Globals.ValueSources.UserEntered
                mSystemGeometry.CrossSection = _crossSection

                ' Border Design does not support Drainback
                Dim _upstreamCondition As IntegerParameter = mSystemGeometry.UpstreamCondition
                _upstreamCondition.Value = UpstreamConditions.NoDrainback
                _upstreamCondition.Source = DataStore.Globals.ValueSources.Calculated
                mSystemGeometry.UpstreamCondition = _upstreamCondition

                ' Border Design requires range for Slope
                Dim _slope As DoubleParameter = mSystemGeometry.Slope
                _slope.MinValue = MinimumBasinBorderSlope
                _slope.MaxValue = MaximumBasinBorderSlope
                If (_slope.Source = DataStore.Globals.ValueSources.Defaulted) Then
                    _slope.Value = DefaultBasinBorderSlope
                End If
                mSystemGeometry.Slope = _slope

                ' Borders have unique default tuning Factors
                Dim _phi3 As DoubleParameter = mBorderCriteria.Phi3Borders
                If (_phi3.Source = ValueSources.Defaulted) Then
                    _phi3.Value = DefaultPhi3Borders
                    mBorderCriteria.Phi3Borders = _phi3
                End If
            End If
        End If
    End Sub

    Private Sub FurrowButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FurrowButton.CheckedChanged
        If (FurrowButton.Checked) Then
            Dim _crossSection As IntegerParameter = mSystemGeometry.CrossSection
            If Not (_crossSection.Value = CrossSections.Furrow) Then

                Dim undoText As String = FurrowButton.Text.Replace("&", "")
                mMyStore.MarkForUndo(undoText)

                _crossSection.Value = CrossSections.Furrow
                _crossSection.Source = DataStore.Globals.ValueSources.UserEntered
                mSystemGeometry.CrossSection = _crossSection

                ' Furrow Design does not support Drainback
                Dim _upstreamCondition As IntegerParameter = mSystemGeometry.UpstreamCondition
                _upstreamCondition.Value = UpstreamConditions.NoDrainback
                _upstreamCondition.Source = DataStore.Globals.ValueSources.Calculated
                mSystemGeometry.UpstreamCondition = _upstreamCondition

                ' Furrow Design requires range for Slope
                Dim _slope As DoubleParameter = mSystemGeometry.Slope
                _slope.MinValue = MinimumFurrowSlope
                _slope.MaxValue = MaximumFurrowSlope
                If (_slope.Source = DataStore.Globals.ValueSources.Defaulted) Then
                    _slope.Value = DefaultFurrowSlope
                End If
                mSystemGeometry.Slope = _slope
            End If
        End If
    End Sub

#End Region

#Region " Basin / Border / Furrow Operations "

    Private Sub SelectOperationsOption(ByVal _option As OperationsOptions)
        If Not (mBorderCriteria Is Nothing) Then
            ' Update Operations Option only if the value has changed
            If Not (mBorderCriteria.OperationsOption.Value = _option) Then

                ' Set the new value if it has changed
                Dim _designOption As IntegerParameter = mBorderCriteria.OperationsOption
                If Not (_designOption.Value = _option) Then
                    mMyStore.MarkForUndo(mDictionary.tOperationsOptionChange.Translated)
                    _designOption.Value = _option
                    _designOption.Source = DataStore.Globals.ValueSources.UserEntered
                    mBorderCriteria.OperationsOption = _designOption
                End If

            End If
        End If
    End Sub

    Private Sub WidthOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WidthOption.CheckedChanged
        If (WidthOption.Checked) Then
            SelectOperationsOption(OperationsOptions.WidthGiven)
        End If
    End Sub

    Private Sub InflowRateOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles InflowRateOption.CheckedChanged
        If (InflowRateOption.Checked) Then
            SelectOperationsOption(OperationsOptions.InflowRateGiven)
        End If
    End Sub

#End Region

#Region " Misc. "
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

#End Region

End Class
