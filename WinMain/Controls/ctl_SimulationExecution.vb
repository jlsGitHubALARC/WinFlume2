
'*************************************************************************************************************
' ctl_SimulationExecution - Simulation World's Execution Tab UI
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore

Public Class ctl_SimulationExecution
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
    Friend WithEvents SrfrSimulationBox As DataStore.ctl_GroupBox
    Friend WithEvents GraphicsButton As DataStore.ctl_Button
    Friend WithEvents SolutionModelLabel As DataStore.ctl_Label
    Friend WithEvents ComputationOptionsBox As DataStore.ctl_GroupBox
    Friend WithEvents CellDensityButton As DataStore.ctl_Button
    Friend WithEvents SolutionModelControl As DataStore.ctl_SelectParameter
    Friend WithEvents RunControlBox As DataStore.ctl_GroupBox
    Friend WithEvents ExecutionErrorsWarnings As WinMain.ErrorRichTextBox
    Friend WithEvents NoErrorsWarningsLabel As DataStore.ctl_Label
    Friend WithEvents ErrorsWarningsLabel As DataStore.ctl_Label
    Friend WithEvents EnableDiagnosticsControl As DataStore.ctl_CheckParameter
    Friend WithEvents CellDensity As System.Windows.Forms.Label
    Friend WithEvents HydrusGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents SyncWinSrfrDistance As DataStore.ctl_RadioButton
    Friend WithEvents SyncUserDistances As DataStore.ctl_RadioButton
    Friend WithEvents HydrusSyncDistances As DataStore.ctl_DataTableParameter
    Friend WithEvents SyncStatus As DataStore.ctl_Label
    Friend WithEvents ControlsButton As DataStore.ctl_Button
    Friend WithEvents OutputOptionsBox As DataStore.ctl_GroupBox
    Friend WithEvents SolutionModelSelected As System.Windows.Forms.Label
    Friend WithEvents RunSrfrBackground As CheckBox
    Friend WithEvents RunSimulationButton As DataStore.ctl_Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SrfrSimulationBox = New DataStore.ctl_GroupBox()
        Me.OutputOptionsBox = New DataStore.ctl_GroupBox()
        Me.GraphicsButton = New DataStore.ctl_Button()
        Me.HydrusGroupBox = New DataStore.ctl_GroupBox()
        Me.SyncStatus = New DataStore.ctl_Label()
        Me.HydrusSyncDistances = New DataStore.ctl_DataTableParameter()
        Me.SyncWinSrfrDistance = New DataStore.ctl_RadioButton()
        Me.SyncUserDistances = New DataStore.ctl_RadioButton()
        Me.ComputationOptionsBox = New DataStore.ctl_GroupBox()
        Me.ControlsButton = New DataStore.ctl_Button()
        Me.SolutionModelControl = New DataStore.ctl_SelectParameter()
        Me.CellDensity = New System.Windows.Forms.Label()
        Me.EnableDiagnosticsControl = New DataStore.ctl_CheckParameter()
        Me.CellDensityButton = New DataStore.ctl_Button()
        Me.SolutionModelLabel = New DataStore.ctl_Label()
        Me.SolutionModelSelected = New System.Windows.Forms.Label()
        Me.RunControlBox = New DataStore.ctl_GroupBox()
        Me.RunSrfrBackground = New System.Windows.Forms.CheckBox()
        Me.ExecutionErrorsWarnings = New WinMain.ErrorRichTextBox()
        Me.NoErrorsWarningsLabel = New DataStore.ctl_Label()
        Me.ErrorsWarningsLabel = New DataStore.ctl_Label()
        Me.RunSimulationButton = New DataStore.ctl_Button()
        Me.SrfrSimulationBox.SuspendLayout()
        Me.OutputOptionsBox.SuspendLayout()
        Me.HydrusGroupBox.SuspendLayout()
        CType(Me.HydrusSyncDistances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ComputationOptionsBox.SuspendLayout()
        Me.RunControlBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'SrfrSimulationBox
        '
        Me.SrfrSimulationBox.AccessibleDescription = "Criteria for running the Simulation."
        Me.SrfrSimulationBox.AccessibleName = "SRFR Simulation"
        Me.SrfrSimulationBox.Controls.Add(Me.OutputOptionsBox)
        Me.SrfrSimulationBox.Controls.Add(Me.HydrusGroupBox)
        Me.SrfrSimulationBox.Controls.Add(Me.ComputationOptionsBox)
        Me.SrfrSimulationBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SrfrSimulationBox.Location = New System.Drawing.Point(6, 8)
        Me.SrfrSimulationBox.Name = "SrfrSimulationBox"
        Me.SrfrSimulationBox.Size = New System.Drawing.Size(520, 408)
        Me.SrfrSimulationBox.TabIndex = 4
        Me.SrfrSimulationBox.TabStop = False
        Me.SrfrSimulationBox.Text = "SRFR Simulation"
        '
        'OutputOptionsBox
        '
        Me.OutputOptionsBox.AccessibleDescription = "Options controlling the generation of simulation results."
        Me.OutputOptionsBox.AccessibleName = "Output Options"
        Me.OutputOptionsBox.Controls.Add(Me.GraphicsButton)
        Me.OutputOptionsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputOptionsBox.Location = New System.Drawing.Point(6, 250)
        Me.OutputOptionsBox.Name = "OutputOptionsBox"
        Me.OutputOptionsBox.Size = New System.Drawing.Size(262, 78)
        Me.OutputOptionsBox.TabIndex = 5
        Me.OutputOptionsBox.TabStop = False
        Me.OutputOptionsBox.Text = "Output Options"
        '
        'GraphicsButton
        '
        Me.GraphicsButton.AccessibleDescription = "Accesses the Standard User Level Simulation Graphics parameters."
        Me.GraphicsButton.AccessibleName = "Graphics Button"
        Me.GraphicsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GraphicsButton.Location = New System.Drawing.Point(13, 32)
        Me.GraphicsButton.Name = "GraphicsButton"
        Me.GraphicsButton.Size = New System.Drawing.Size(112, 24)
        Me.GraphicsButton.TabIndex = 0
        Me.GraphicsButton.Text = "&Graphics ..."
        '
        'HydrusGroupBox
        '
        Me.HydrusGroupBox.AccessibleDescription = "Selects the distances at which to sync HYDRUS with SRFR."
        Me.HydrusGroupBox.AccessibleName = "HYDRUS Sync Control"
        Me.HydrusGroupBox.Controls.Add(Me.SyncStatus)
        Me.HydrusGroupBox.Controls.Add(Me.HydrusSyncDistances)
        Me.HydrusGroupBox.Controls.Add(Me.SyncWinSrfrDistance)
        Me.HydrusGroupBox.Controls.Add(Me.SyncUserDistances)
        Me.HydrusGroupBox.Location = New System.Drawing.Point(274, 30)
        Me.HydrusGroupBox.Name = "HydrusGroupBox"
        Me.HydrusGroupBox.Size = New System.Drawing.Size(240, 370)
        Me.HydrusGroupBox.TabIndex = 4
        Me.HydrusGroupBox.TabStop = False
        Me.HydrusGroupBox.Text = "&HYDRUS"
        '
        'SyncStatus
        '
        Me.SyncStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SyncStatus.Location = New System.Drawing.Point(7, 341)
        Me.SyncStatus.Name = "SyncStatus"
        Me.SyncStatus.Size = New System.Drawing.Size(227, 23)
        Me.SyncStatus.TabIndex = 3
        Me.SyncStatus.Text = "Sync Status"
        Me.SyncStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HydrusSyncDistances
        '
        Me.HydrusSyncDistances.AllRowsFixed = False
        Me.HydrusSyncDistances.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.HydrusSyncDistances.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.HydrusSyncDistances.CaptionText = "HYDRUS Sync Distances"
        Me.HydrusSyncDistances.CausesValidation = False
        Me.HydrusSyncDistances.ColumnWidthRatios = Nothing
        Me.HydrusSyncDistances.DataMember = ""
        Me.HydrusSyncDistances.EnableSaveActions = False
        Me.HydrusSyncDistances.FirstColumnIncreases = True
        Me.HydrusSyncDistances.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.HydrusSyncDistances.FirstColumnMinimum = 0R
        Me.HydrusSyncDistances.FirstRowFixed = False
        Me.HydrusSyncDistances.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HydrusSyncDistances.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.HydrusSyncDistances.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.HydrusSyncDistances.Location = New System.Drawing.Point(7, 82)
        Me.HydrusSyncDistances.MaxRows = 50
        Me.HydrusSyncDistances.MinRows = 1
        Me.HydrusSyncDistances.Name = "HydrusSyncDistances"
        Me.HydrusSyncDistances.PasteDisabled = False
        Me.HydrusSyncDistances.SecondColumnIncreases = False
        Me.HydrusSyncDistances.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.HydrusSyncDistances.SecondColumnMinimum = 0R
        Me.HydrusSyncDistances.Size = New System.Drawing.Size(227, 256)
        Me.HydrusSyncDistances.TabIndex = 0
        Me.HydrusSyncDistances.TableReadonly = False
        '
        'SyncWinSrfrDistance
        '
        Me.SyncWinSrfrDistance.AutoSize = True
        Me.SyncWinSrfrDistance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SyncWinSrfrDistance.Location = New System.Drawing.Point(7, 27)
        Me.SyncWinSrfrDistance.Name = "SyncWinSrfrDistance"
        Me.SyncWinSrfrDistance.Size = New System.Drawing.Size(204, 21)
        Me.SyncWinSrfrDistance.TabIndex = 1
        Me.SyncWinSrfrDistance.TabStop = True
        Me.SyncWinSrfrDistance.Text = "Sync at &WinSRFR Distances"
        Me.SyncWinSrfrDistance.UseVisualStyleBackColor = True
        '
        'SyncUserDistances
        '
        Me.SyncUserDistances.AutoSize = True
        Me.SyncUserDistances.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SyncUserDistances.Location = New System.Drawing.Point(7, 51)
        Me.SyncUserDistances.Name = "SyncUserDistances"
        Me.SyncUserDistances.Size = New System.Drawing.Size(173, 21)
        Me.SyncUserDistances.TabIndex = 2
        Me.SyncUserDistances.TabStop = True
        Me.SyncUserDistances.Text = "Sync at &User Distances"
        Me.SyncUserDistances.UseVisualStyleBackColor = True
        '
        'ComputationOptionsBox
        '
        Me.ComputationOptionsBox.AccessibleDescription = "Options controlling the simulation execution."
        Me.ComputationOptionsBox.AccessibleName = "Computational Options"
        Me.ComputationOptionsBox.Controls.Add(Me.ControlsButton)
        Me.ComputationOptionsBox.Controls.Add(Me.SolutionModelControl)
        Me.ComputationOptionsBox.Controls.Add(Me.CellDensity)
        Me.ComputationOptionsBox.Controls.Add(Me.EnableDiagnosticsControl)
        Me.ComputationOptionsBox.Controls.Add(Me.CellDensityButton)
        Me.ComputationOptionsBox.Controls.Add(Me.SolutionModelLabel)
        Me.ComputationOptionsBox.Controls.Add(Me.SolutionModelSelected)
        Me.ComputationOptionsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComputationOptionsBox.Location = New System.Drawing.Point(6, 30)
        Me.ComputationOptionsBox.Name = "ComputationOptionsBox"
        Me.ComputationOptionsBox.Size = New System.Drawing.Size(262, 191)
        Me.ComputationOptionsBox.TabIndex = 3
        Me.ComputationOptionsBox.TabStop = False
        Me.ComputationOptionsBox.Text = "Computational Options"
        '
        'ControlsButton
        '
        Me.ControlsButton.AccessibleDescription = "Accesses the Standard User Level Simulation Graphics parameters."
        Me.ControlsButton.AccessibleName = "Graphics Button"
        Me.ControlsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ControlsButton.Location = New System.Drawing.Point(13, 155)
        Me.ControlsButton.Name = "ControlsButton"
        Me.ControlsButton.Size = New System.Drawing.Size(112, 24)
        Me.ControlsButton.TabIndex = 4
        Me.ControlsButton.Text = "&Controls ..."
        '
        'SolutionModelControl
        '
        Me.SolutionModelControl.AccessibleDescription = "Selects the Simulation Solution Model to use when running the Simulation."
        Me.SolutionModelControl.AccessibleName = "Solution Model"
        Me.SolutionModelControl.ApplicationValue = -1
        Me.SolutionModelControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SolutionModelControl.EnableSaveActions = False
        Me.SolutionModelControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SolutionModelControl.IsCalculated = False
        Me.SolutionModelControl.Location = New System.Drawing.Point(13, 51)
        Me.SolutionModelControl.Name = "SolutionModelControl"
        Me.SolutionModelControl.SelectedIndexSet = False
        Me.SolutionModelControl.Size = New System.Drawing.Size(243, 24)
        Me.SolutionModelControl.TabIndex = 1
        '
        'CellDensity
        '
        Me.CellDensity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CellDensity.Location = New System.Drawing.Point(131, 89)
        Me.CellDensity.Name = "CellDensity"
        Me.CellDensity.Size = New System.Drawing.Size(47, 24)
        Me.CellDensity.TabIndex = 2
        Me.CellDensity.Text = "999"
        Me.CellDensity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EnableDiagnosticsControl
        '
        Me.EnableDiagnosticsControl.AlwaysChecked = False
        Me.EnableDiagnosticsControl.AutoSize = True
        Me.EnableDiagnosticsControl.ErrorMessage = Nothing
        Me.EnableDiagnosticsControl.Location = New System.Drawing.Point(13, 127)
        Me.EnableDiagnosticsControl.Name = "EnableDiagnosticsControl"
        Me.EnableDiagnosticsControl.Size = New System.Drawing.Size(166, 21)
        Me.EnableDiagnosticsControl.TabIndex = 3
        Me.EnableDiagnosticsControl.Text = "E&nable Diagnostics"
        Me.EnableDiagnosticsControl.UncheckAttemptMessage = Nothing
        Me.EnableDiagnosticsControl.UseVisualStyleBackColor = True
        '
        'CellDensityButton
        '
        Me.CellDensityButton.AccessibleDescription = "Accesses the Simulation Cell Density parameters."
        Me.CellDensityButton.AccessibleName = "Cell Density Button"
        Me.CellDensityButton.Enabled = False
        Me.CellDensityButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CellDensityButton.Location = New System.Drawing.Point(13, 89)
        Me.CellDensityButton.Name = "CellDensityButton"
        Me.CellDensityButton.Size = New System.Drawing.Size(112, 24)
        Me.CellDensityButton.TabIndex = 1
        Me.CellDensityButton.Text = "Cell &Density ..."
        '
        'SolutionModelLabel
        '
        Me.SolutionModelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SolutionModelLabel.Location = New System.Drawing.Point(13, 27)
        Me.SolutionModelLabel.Name = "SolutionModelLabel"
        Me.SolutionModelLabel.Size = New System.Drawing.Size(112, 23)
        Me.SolutionModelLabel.TabIndex = 0
        Me.SolutionModelLabel.Text = "Solution &Model"
        Me.SolutionModelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SolutionModelSelected
        '
        Me.SolutionModelSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SolutionModelSelected.Location = New System.Drawing.Point(13, 51)
        Me.SolutionModelSelected.Name = "SolutionModelSelected"
        Me.SolutionModelSelected.Size = New System.Drawing.Size(254, 24)
        Me.SolutionModelSelected.TabIndex = 5
        Me.SolutionModelSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RunControlBox
        '
        Me.RunControlBox.AccessibleDescription = "Run Button and Error / Warning Status"
        Me.RunControlBox.AccessibleName = "Run Control"
        Me.RunControlBox.Controls.Add(Me.RunSrfrBackground)
        Me.RunControlBox.Controls.Add(Me.ExecutionErrorsWarnings)
        Me.RunControlBox.Controls.Add(Me.NoErrorsWarningsLabel)
        Me.RunControlBox.Controls.Add(Me.ErrorsWarningsLabel)
        Me.RunControlBox.Controls.Add(Me.RunSimulationButton)
        Me.RunControlBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunControlBox.Location = New System.Drawing.Point(534, 8)
        Me.RunControlBox.Name = "RunControlBox"
        Me.RunControlBox.Size = New System.Drawing.Size(240, 408)
        Me.RunControlBox.TabIndex = 5
        Me.RunControlBox.TabStop = False
        Me.RunControlBox.Text = "Run Control"
        '
        'RunSrfrBackground
        '
        Me.RunSrfrBackground.AutoSize = True
        Me.RunSrfrBackground.Location = New System.Drawing.Point(10, 59)
        Me.RunSrfrBackground.Name = "RunSrfrBackground"
        Me.RunSrfrBackground.Size = New System.Drawing.Size(222, 21)
        Me.RunSrfrBackground.TabIndex = 4
        Me.RunSrfrBackground.Text = "Run in Background Thread"
        Me.RunSrfrBackground.UseVisualStyleBackColor = True
        '
        'ExecutionErrorsWarnings
        '
        Me.ExecutionErrorsWarnings.Location = New System.Drawing.Point(8, 112)
        Me.ExecutionErrorsWarnings.Name = "ExecutionErrorsWarnings"
        Me.ExecutionErrorsWarnings.ReadOnly = True
        Me.ExecutionErrorsWarnings.Size = New System.Drawing.Size(224, 288)
        Me.ExecutionErrorsWarnings.TabIndex = 2
        Me.ExecutionErrorsWarnings.Text = ""
        '
        'NoErrorsWarningsLabel
        '
        Me.NoErrorsWarningsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoErrorsWarningsLabel.Location = New System.Drawing.Point(16, 120)
        Me.NoErrorsWarningsLabel.Name = "NoErrorsWarningsLabel"
        Me.NoErrorsWarningsLabel.Size = New System.Drawing.Size(208, 23)
        Me.NoErrorsWarningsLabel.TabIndex = 3
        Me.NoErrorsWarningsLabel.Text = "None"
        Me.NoErrorsWarningsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorsWarningsLabel
        '
        Me.ErrorsWarningsLabel.BackColor = System.Drawing.SystemColors.Control
        Me.ErrorsWarningsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErrorsWarningsLabel.Location = New System.Drawing.Point(16, 80)
        Me.ErrorsWarningsLabel.Name = "ErrorsWarningsLabel"
        Me.ErrorsWarningsLabel.Size = New System.Drawing.Size(208, 24)
        Me.ErrorsWarningsLabel.TabIndex = 1
        Me.ErrorsWarningsLabel.Text = "Errors and Warnings"
        Me.ErrorsWarningsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RunSimulationButton
        '
        Me.RunSimulationButton.AccessibleDescription = "Press to execute the simulation."
        Me.RunSimulationButton.AccessibleName = "Run Button"
        Me.RunSimulationButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RunSimulationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RunSimulationButton.Location = New System.Drawing.Point(48, 26)
        Me.RunSimulationButton.Name = "RunSimulationButton"
        Me.RunSimulationButton.Size = New System.Drawing.Size(144, 24)
        Me.RunSimulationButton.TabIndex = 0
        Me.RunSimulationButton.Text = "&Run Simulation"
        Me.RunSimulationButton.UseVisualStyleBackColor = False
        '
        'ctl_SimulationExecution
        '
        Me.Controls.Add(Me.SrfrSimulationBox)
        Me.Controls.Add(Me.RunControlBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_SimulationExecution"
        Me.Size = New System.Drawing.Size(780, 422)
        Me.SrfrSimulationBox.ResumeLayout(False)
        Me.OutputOptionsBox.ResumeLayout(False)
        Me.HydrusGroupBox.ResumeLayout(False)
        Me.HydrusGroupBox.PerformLayout()
        CType(Me.HydrusSyncDistances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ComputationOptionsBox.ResumeLayout(False)
        Me.ComputationOptionsBox.PerformLayout()
        Me.RunControlBox.ResumeLayout(False)
        Me.RunControlBox.PerformLayout()
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
    Private WithEvents mSoilCropProperties As SoilCropProperties = Nothing
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mSubsurfaceFlow As SubsurfaceFlow

    Private WithEvents mBorderCriteria As BorderCriteria
    Private WithEvents mSrfrCriteria As SrfrCriteria

    Private mSimulationWorld As SimulationWorld
    Private WithEvents mCurrentAnalysis As Analysis

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Public Sub LinkToModel(ByVal _unit As Unit, ByVal _world As SimulationWorld)

        Debug.Assert(Not (_unit Is Nothing), "Unit is Nothing")
        Debug.Assert(Not (_world Is Nothing), "Simulation World is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mInflowManagement = mUnit.InflowManagementRef
        mSubsurfaceFlow = mUnit.SubsurfaceFlowRef

        mBorderCriteria = mUnit.BorderCriteriaRef
        mSrfrCriteria = mUnit.SrfrCriteriaRef

        mSimulationWorld = _world
        mMyStore = mUnit.MyStore
        mDictionary = Dictionary.Instance

        mCurrentAnalysis = mSimulationWorld.CurrentAnalysis

        ' Link the contained controls to their models & store

        Me.SolutionModelControl.LinkToModel(mMyStore, mSrfrCriteria.SolutionModelProperty)
        Me.EnableDiagnosticsControl.LinkToModel(mMyStore, mSrfrCriteria.EnableDiagnosticsProperty)

        Me.SyncUserDistances.LinkToModel(mMyStore, mSoilCropProperties.SyncHydrusOptionProperty, SyncHydrusOptions.SyncWithUserDistances)
        Me.SyncWinSrfrDistance.LinkToModel(mMyStore, mSoilCropProperties.SyncHydrusOptionProperty, SyncHydrusOptions.SyncWithWinSrfrDistances)

        Me.HydrusSyncDistances.LinkToModel(mMyStore, mSoilCropProperties.HydrusSyncDistancesProperty)

        ' Update language translation
        UpdateLanguage()

        ' Update the control's User Interface
        UpdateUI()

    End Sub

#End Region

#Region " UI Methods "
    '
    ' Update the Simulation World's UI
    '
    Public Sub UpdateUI()

        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mUnit IsNot Nothing) Then

            mSimulationWorld.UpdateResultsControls()

            Me.RunSrfrBackground.Checked = mCurrentAnalysis.RunInBackgroundThread

            ' Enable / disable access to SRFR controls
            Select Case (WinSRFR.UserLevel)
                Case UserLevels.Standard
                    ' Solution Model & Cell Density set for Standard User
                    Me.SolutionModelControl.IsCalculated = True
                    Me.CellDensityButton.Enabled = False
                    Me.EnableDiagnosticsControl.Visible = False
                    Me.ControlsButton.Visible = False
                    Me.HydrusGroupBox.Visible = False
                Case UserLevels.Advanced
                    ' Solution Model & Cell Density available for Advanced User
                    Me.SolutionModelControl.IsCalculated = False
                    Me.CellDensityButton.Enabled = True
                    Me.EnableDiagnosticsControl.Visible = False
                    Me.ControlsButton.Visible = False

                    If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.Hydrus1D) Then
                        Me.HydrusGroupBox.Visible = True

                        ' If sync distances are chosen be WinSRFR, make sure they are up-to-date and readonly
                        If (mSoilCropProperties.SyncHydrusOption.Value = SyncHydrusOptions.SyncWithWinSrfrDistances) Then
                            Dim hydrusProp As PropertyNode = mSoilCropProperties.HydrusSyncDistancesProperty
                            Me.HydrusSyncDistances.TableReadonly = True
                        Else
                            Me.HydrusSyncDistances.TableReadonly = False
                        End If

                        Me.HydrusSyncDistances.UpdateUI()
                    Else
                        Me.HydrusGroupBox.Visible = False
                    End If
                Case Else ' Research
                    ' Solution Model & Cell Density available for Research
                    Me.SolutionModelControl.IsCalculated = False
                    Me.CellDensityButton.Enabled = True
                    Me.EnableDiagnosticsControl.Visible = True
                    Me.ControlsButton.Visible = True

                    If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.Hydrus1D) Then
                        Me.HydrusGroupBox.Visible = True

                        ' If sync distances are chosen be WinSRFR, make sure they are up-to-date and readonly
                        If (mSoilCropProperties.SyncHydrusOption.Value = SyncHydrusOptions.SyncWithWinSrfrDistances) Then
                            Dim hydrusProp As PropertyNode = mSoilCropProperties.HydrusSyncDistancesProperty
                            Me.HydrusSyncDistances.TableReadonly = True
                        Else
                            Me.HydrusSyncDistances.TableReadonly = False
                        End If

                        Me.HydrusSyncDistances.UpdateUI()
                    Else
                        Me.HydrusGroupBox.Visible = False
                    End If
            End Select

            CellDensity.Text = mUnit.SrfrCriteriaRef.CellDensity.ValueString

            ' Update the System Type controls
            UpdateSolutionModel()

            If (WinSRFR.DebuggerIsAttached) Then
                Me.EnableDiagnosticsControl.Visible = True
            End If
        End If

    End Sub
    '
    ' Update the Results Control (Buttons)
    '
    Public Sub EnableRunButtons()
        Me.RunSimulationButton.Enabled = True
    End Sub

    Public Sub DisableRunButtons()
        Me.RunSimulationButton.Enabled = False
    End Sub
    '
    ' Update Solution Model selection list & selection
    '
    Private Sub UpdateSolutionModel()
        If Not (mSrfrCriteria Is Nothing) Then
            Dim _simModel As Integer = mSrfrCriteria.SolutionModel.Value

            If (mWinSRFR.UserLevel = UserLevels.Standard) Then
                SolutionModelControl.Hide()
                SolutionModelSelected.Show()
                SolutionModelSelected.Text = SolutionModelSelections(_simModel).Value
                SolutionModelSelected.BackColor = BackColor_Calculated()

            Else ' Assume Advanced or Research
                SolutionModelSelected.Hide()
                SolutionModelControl.Show()

                ' Update selection list
                Dim _sel As String = String.Empty
                Dim _idx As Integer = 0

                SolutionModelControl.Clear()

                Dim _selOk As Boolean = mSrfrCriteria.GetFirstSolutionModelSelection(_sel)
                While Not (_sel Is Nothing)
                    If (_selOk) Then
                        SolutionModelControl.Add(_sel, _idx, True)
                    ElseIf (_simModel = _idx) Then
                        SolutionModelControl.Add(_sel, _idx, False)
                    End If
                    _selOk = mSrfrCriteria.GetNextSolutionModelSelection(_sel)
                    _idx += 1
                End While

                ' Update selection
                SolutionModelControl.UpdateUI()
            End If
        End If
    End Sub

    Public Sub UpdateSimulationSetupErrorsWarnings(ByVal _analysis As SrfrSimulation)
        If ((mUnit IsNot Nothing) And (_analysis IsNot Nothing)) Then
            ' Check Simulation errors & warnings
            _analysis.UpdateSetupErrorsAndWarnings()

            ' Display Simulation errors & warnings
            Me.ExecutionErrorsWarnings.Clear()

            If (_analysis.HasSetupErrorsOrWarnings) Then
                Me.ExecutionErrorsWarnings.DisplayErrorsAndWarnings(_analysis, True)
                Me.ExecutionErrorsWarnings.Show()
            ElseIf (0 < mUnit.UnitControlRef.RunCount.Value) Then
                Me.ExecutionErrorsWarnings.DisplayWarning(mDictionary.tAnalysisHasAlreadyBeenRunID.Translated,
                                                          mDictionary.tAnalysisHasAlreadyBeenRunDetail.Translated)
                Me.ExecutionErrorsWarnings.Show()
            Else
                Me.ExecutionErrorsWarnings.Hide()
            End If
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

#Region " UI Event Handlers "

    Private Sub SolutionModelControl_ControlValueChanged() _
    Handles SolutionModelControl.ControlValueChanged
        ' Solution Model changes can effect Cell Density & FILFT
        mSrfrCriteria.CheckCellDensity(CellDensities.Medium)
    End Sub

    Private Sub GraphicsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GraphicsButton.Click
        Dim db As SimGraphicsDialogBox = New SimGraphicsDialogBox(mUnit, Globals.UserLevels.Standard)
        UpdateTranslation(db)
        db.ShowDialog()
    End Sub

    Private Sub CellDensityButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CellDensityButton.Click
        Dim db As SimCellDensityDialogBox = New SimCellDensityDialogBox(mUnit)
        UpdateTranslation(db)
        db.ShowDialog()
    End Sub

    Private Sub ControlsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ControlsButton.Click
        Dim db As SimControlsDialogBox = New SimControlsDialogBox
        db.InitUI(mSrfrCriteria, mMyStore)
        Dim result As DialogResult = db.ShowDialog()
        If (result = DialogResult.OK) Then
            Dim undoText As String = db.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)

            Dim param As DoubleParameter

            Select Case (mSrfrCriteria.SolutionModel.Value)

                Case SolutionModels.KinematicWave
                    param = mSrfrCriteria.PhiAYL_KW
                    param.Value = db.PhiAYLControl.Value
                    param.Source = ValueSources.UserEntered
                    mSrfrCriteria.PhiAYL_KW = param

                Case SolutionModels.ZeroInertia
                    param = mSrfrCriteria.PhiAYL_ZI
                    param.Value = db.PhiAYLControl.Value
                    param.Source = ValueSources.UserEntered
                    mSrfrCriteria.PhiAYL_ZI = param

                Case Else
                    Debug.Assert(False)
            End Select

            param = mSrfrCriteria.PhiAZL
            param.Value = db.PhiAZLControl.Value
            param.Source = ValueSources.UserEntered
            mSrfrCriteria.PhiAZL = param

            param = mSrfrCriteria.Theta
            param.Value = db.ThetaControl.Value
            param.Source = ValueSources.UserEntered
            mSrfrCriteria.Theta = param

        End If
    End Sub

    Private Sub RunSimulationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunSimulationButton.Click
        Me.RunSimulation()
    End Sub

    Private Sub RunSimulation()
        Me.Focus()
        mSimulationWorld.RunSrfrSimulation()
    End Sub

    Public Sub CurrentAnalysis_AnalysisEvent(ByVal Reason As Reasons, ByVal Msg As String) _
    Handles mCurrentAnalysis.AnalysisEvent
        Me.SyncStatus.Text = Msg
    End Sub
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    Private Sub RunSrfrBackground_CheckedChanged(sender As Object, e As EventArgs) _
        Handles RunSrfrBackground.CheckedChanged
        mCurrentAnalysis.RunInBackgroundThread = Me.RunSrfrBackground.Checked
    End Sub

#End Region

End Class
