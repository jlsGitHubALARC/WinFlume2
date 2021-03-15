
'*************************************************************************************************************
' ctl_SimulationWorld - Simulation World Tab UI
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_SimulationWorld
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
    Friend WithEvents ConstituentTransportBox As DataStore.ctl_GroupBox
    Friend WithEvents EnableErosionControl As DataStore.ctl_CheckParameter
    Friend WithEvents SimulationWorldUsage As System.Windows.Forms.RichTextBox
    Friend WithEvents SimulationWorldTitle As DataStore.ctl_Label
    Friend WithEvents SystemTypeGroup As DataStore.ctl_GroupBox
    Friend WithEvents FurrowButton As DataStore.ctl_RadioButton
    Friend WithEvents ComputationNetwork As System.Windows.Forms.PictureBox
    Friend WithEvents ComputationNetKey As DataStore.ctl_Label
    Friend WithEvents IrrigationWaterUseBox As DataStore.ctl_GroupBox
    Friend WithEvents UnitWaterCostControl As DataStore.ctl_DoubleParameter
    Friend WithEvents UnitWaterCostLabel As DataStore.ctl_Label
    Friend WithEvents RequiredDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents RequiredDepthLabel As DataStore.ctl_Label
    Friend WithEvents SimulationWorldHelp As System.Windows.Forms.RichTextBox
    Friend WithEvents ToggleButton As System.Windows.Forms.RadioButton
    Friend WithEvents EnableFertigationControl As DataStore.ctl_CheckParameter
    Friend WithEvents BasinBorderButton As DataStore.ctl_RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctl_SimulationWorld))
        Me.ConstituentTransportBox = New DataStore.ctl_GroupBox
        Me.EnableFertigationControl = New DataStore.ctl_CheckParameter
        Me.EnableErosionControl = New DataStore.ctl_CheckParameter
        Me.SimulationWorldUsage = New System.Windows.Forms.RichTextBox
        Me.SimulationWorldTitle = New DataStore.ctl_Label
        Me.SystemTypeGroup = New DataStore.ctl_GroupBox
        Me.FurrowButton = New DataStore.ctl_RadioButton
        Me.BasinBorderButton = New DataStore.ctl_RadioButton
        Me.ComputationNetwork = New System.Windows.Forms.PictureBox
        Me.ComputationNetKey = New DataStore.ctl_Label
        Me.IrrigationWaterUseBox = New DataStore.ctl_GroupBox
        Me.UnitWaterCostControl = New DataStore.ctl_DoubleParameter
        Me.UnitWaterCostLabel = New DataStore.ctl_Label
        Me.RequiredDepthControl = New DataStore.ctl_DoubleParameter
        Me.RequiredDepthLabel = New DataStore.ctl_Label
        Me.SimulationWorldHelp = New System.Windows.Forms.RichTextBox
        Me.ToggleButton = New System.Windows.Forms.RadioButton
        Me.ConstituentTransportBox.SuspendLayout()
        Me.SystemTypeGroup.SuspendLayout()
        CType(Me.ComputationNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IrrigationWaterUseBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConstituentTransportBox
        '
        Me.ConstituentTransportBox.AccessibleDescription = "Enables the additional simulation of erosion or fertigation."
        Me.ConstituentTransportBox.AccessibleName = "Constituent Transport"
        Me.ConstituentTransportBox.Controls.Add(Me.EnableFertigationControl)
        Me.ConstituentTransportBox.Controls.Add(Me.EnableErosionControl)
        Me.ConstituentTransportBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConstituentTransportBox.Location = New System.Drawing.Point(441, 78)
        Me.ConstituentTransportBox.Name = "ConstituentTransportBox"
        Me.ConstituentTransportBox.Size = New System.Drawing.Size(224, 76)
        Me.ConstituentTransportBox.TabIndex = 4
        Me.ConstituentTransportBox.TabStop = False
        Me.ConstituentTransportBox.Text = "Constituent Transport"
        '
        'EnableFertigationControl
        '
        Me.EnableFertigationControl.AlwaysChecked = False
        Me.EnableFertigationControl.ErrorMessage = Nothing
        Me.EnableFertigationControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnableFertigationControl.Location = New System.Drawing.Point(8, 45)
        Me.EnableFertigationControl.Name = "EnableFertigationControl"
        Me.EnableFertigationControl.Size = New System.Drawing.Size(194, 24)
        Me.EnableFertigationControl.TabIndex = 1
        Me.EnableFertigationControl.Text = "Ferti&gation"
        Me.EnableFertigationControl.UncheckAttemptMessage = Nothing
        '
        'EnableErosionControl
        '
        Me.EnableErosionControl.AlwaysChecked = False
        Me.EnableErosionControl.ErrorMessage = Nothing
        Me.EnableErosionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnableErosionControl.Location = New System.Drawing.Point(8, 20)
        Me.EnableErosionControl.Name = "EnableErosionControl"
        Me.EnableErosionControl.Size = New System.Drawing.Size(194, 24)
        Me.EnableErosionControl.TabIndex = 0
        Me.EnableErosionControl.Text = "&Erosion"
        Me.EnableErosionControl.UncheckAttemptMessage = Nothing
        '
        'SimulationWorldUsage
        '
        Me.SimulationWorldUsage.BackColor = System.Drawing.SystemColors.Control
        Me.SimulationWorldUsage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SimulationWorldUsage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimulationWorldUsage.Location = New System.Drawing.Point(10, 31)
        Me.SimulationWorldUsage.Name = "SimulationWorldUsage"
        Me.SimulationWorldUsage.ReadOnly = True
        Me.SimulationWorldUsage.Size = New System.Drawing.Size(760, 40)
        Me.SimulationWorldUsage.TabIndex = 1
        Me.SimulationWorldUsage.TabStop = False
        Me.SimulationWorldUsage.Text = resources.GetString("SimulationWorldUsage.Text")
        '
        'SimulationWorldTitle
        '
        Me.SimulationWorldTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimulationWorldTitle.Location = New System.Drawing.Point(10, 7)
        Me.SimulationWorldTitle.Name = "SimulationWorldTitle"
        Me.SimulationWorldTitle.Size = New System.Drawing.Size(760, 23)
        Me.SimulationWorldTitle.TabIndex = 0
        Me.SimulationWorldTitle.Text = "Simulation World"
        Me.SimulationWorldTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.SystemTypeGroup.TabIndex = 2
        Me.SystemTypeGroup.TabStop = False
        Me.SystemTypeGroup.Text = "System Type"
        '
        'FurrowButton
        '
        Me.FurrowButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowButton.Location = New System.Drawing.Point(11, 44)
        Me.FurrowButton.Name = "FurrowButton"
        Me.FurrowButton.Size = New System.Drawing.Size(143, 24)
        Me.FurrowButton.TabIndex = 1
        Me.FurrowButton.Text = "&Furrow"
        '
        'BasinBorderButton
        '
        Me.BasinBorderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BasinBorderButton.Location = New System.Drawing.Point(11, 22)
        Me.BasinBorderButton.Name = "BasinBorderButton"
        Me.BasinBorderButton.Size = New System.Drawing.Size(143, 24)
        Me.BasinBorderButton.TabIndex = 0
        Me.BasinBorderButton.Text = "&Basin / Border"
        '
        'ComputationNetwork
        '
        Me.ComputationNetwork.Image = Global.WinMain.My.Resources.Resources.ComputationNetwork
        Me.ComputationNetwork.InitialImage = Nothing
        Me.ComputationNetwork.Location = New System.Drawing.Point(10, 170)
        Me.ComputationNetwork.Name = "ComputationNetwork"
        Me.ComputationNetwork.Size = New System.Drawing.Size(760, 250)
        Me.ComputationNetwork.TabIndex = 6
        Me.ComputationNetwork.TabStop = False
        '
        'ComputationNetKey
        '
        Me.ComputationNetKey.BackColor = System.Drawing.SystemColors.Info
        Me.ComputationNetKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ComputationNetKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComputationNetKey.Location = New System.Drawing.Point(548, 341)
        Me.ComputationNetKey.Name = "ComputationNetKey"
        Me.ComputationNetKey.Size = New System.Drawing.Size(209, 37)
        Me.ComputationNetKey.TabIndex = 7
        Me.ComputationNetKey.Text = "Example SRFR Simulation Computation Network"
        Me.ComputationNetKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.IrrigationWaterUseBox.TabIndex = 3
        Me.IrrigationWaterUseBox.TabStop = False
        Me.IrrigationWaterUseBox.Text = "Irrigation Water Use"
        '
        'UnitWaterCostControl
        '
        Me.UnitWaterCostControl.AccessibleDescription = ""
        Me.UnitWaterCostControl.AccessibleName = ""
        Me.UnitWaterCostControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.UnitWaterCostControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitWaterCostControl.IsCalculated = False
        Me.UnitWaterCostControl.IsInteger = False
        Me.UnitWaterCostControl.Location = New System.Drawing.Point(133, 48)
        Me.UnitWaterCostControl.MaxErrMsg = ""
        Me.UnitWaterCostControl.MinErrMsg = ""
        Me.UnitWaterCostControl.Name = "UnitWaterCostControl"
        Me.UnitWaterCostControl.Size = New System.Drawing.Size(120, 24)
        Me.UnitWaterCostControl.TabIndex = 3
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
        Me.UnitWaterCostLabel.TabIndex = 2
        Me.UnitWaterCostLabel.Text = "Unit Water &Cost"
        Me.UnitWaterCostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RequiredDepthControl
        '
        Me.RequiredDepthControl.AccessibleDescription = ""
        Me.RequiredDepthControl.AccessibleName = ""
        Me.RequiredDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RequiredDepthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequiredDepthControl.IsCalculated = False
        Me.RequiredDepthControl.IsInteger = False
        Me.RequiredDepthControl.Location = New System.Drawing.Point(133, 23)
        Me.RequiredDepthControl.MaxErrMsg = ""
        Me.RequiredDepthControl.MinErrMsg = ""
        Me.RequiredDepthControl.Name = "RequiredDepthControl"
        Me.RequiredDepthControl.Size = New System.Drawing.Size(120, 24)
        Me.RequiredDepthControl.TabIndex = 1
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
        Me.RequiredDepthLabel.TabIndex = 0
        Me.RequiredDepthLabel.Text = "Required &Depth"
        Me.RequiredDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SimulationWorldHelp
        '
        Me.SimulationWorldHelp.BackColor = System.Drawing.SystemColors.Info
        Me.SimulationWorldHelp.ForeColor = System.Drawing.SystemColors.InfoText
        Me.SimulationWorldHelp.Location = New System.Drawing.Point(10, 170)
        Me.SimulationWorldHelp.Name = "SimulationWorldHelp"
        Me.SimulationWorldHelp.Size = New System.Drawing.Size(760, 250)
        Me.SimulationWorldHelp.TabIndex = 11
        Me.SimulationWorldHelp.Text = resources.GetString("SimulationWorldHelp.Text")
        '
        'ToggleButton
        '
        Me.ToggleButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.ToggleButton.FlatAppearance.BorderSize = 0
        Me.ToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ToggleButton.Location = New System.Drawing.Point(766, 421)
        Me.ToggleButton.Name = "ToggleButton"
        Me.ToggleButton.Size = New System.Drawing.Size(12, 12)
        Me.ToggleButton.TabIndex = 12
        Me.ToggleButton.TabStop = True
        Me.ToggleButton.UseVisualStyleBackColor = True
        '
        'ctl_SimulationWorld
        '
        Me.Controls.Add(Me.ToggleButton)
        Me.Controls.Add(Me.SystemTypeGroup)
        Me.Controls.Add(Me.IrrigationWaterUseBox)
        Me.Controls.Add(Me.ConstituentTransportBox)
        Me.Controls.Add(Me.SimulationWorldTitle)
        Me.Controls.Add(Me.SimulationWorldUsage)
        Me.Controls.Add(Me.ComputationNetKey)
        Me.Controls.Add(Me.ComputationNetwork)
        Me.Controls.Add(Me.SimulationWorldHelp)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_SimulationWorld"
        Me.Size = New System.Drawing.Size(780, 435)
        Me.ConstituentTransportBox.ResumeLayout(False)
        Me.SystemTypeGroup.ResumeLayout(False)
        CType(Me.ComputationNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IrrigationWaterUseBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    Private mViewHelp As Boolean = True

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
    Private WithEvents mSoilCropProperties As SoilCropProperties
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mErosion As Erosion
    Private WithEvents mFertigation As Fertigation
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
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mErosion = mUnit.ErosionRef
        mFertigation = mUnit.FertigationRef
        mBorderCriteria = mUnit.BorderCriteriaRef

        mDictionary = Dictionary.Instance
        mMyStore = mUnit.MyStore

        ' Link contained controls to their models & store
        BasinBorderButton.LinkToModel(mMyStore, mSystemGeometry.CrossSectionProperty, CrossSections.Border)
        FurrowButton.LinkToModel(mMyStore, mSystemGeometry.CrossSectionProperty, CrossSections.Furrow)

        RequiredDepthControl.LinkToModel(mMyStore, mInflowManagement.RequiredDepthProperty)
        UnitWaterCostControl.LinkToModel(mMyStore, mInflowManagement.UnitWaterCostProperty)

        EnableErosionControl.LinkToModel(mMyStore, mErosion.EnableErosionProperty)
        EnableFertigationControl.LinkToModel(mMyStore, mFertigation.EnableFertigationProperty)

        ' Size UI to current available space
        ResizeUI()

        ' Update language translation
        UpdateLanguage()

    End Sub

#End Region

#Region " Update UI "
    '
    ' Update the Simulation World's UI
    '
    Public Sub UpdateUI()
        If (mUnit Is Nothing) Then ' Control has not been initialized; don't update it
            Return
        End If

        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        ' Resize UI to fill available space
        ResizeUI()
        '
        ' Display world usage instructions
        '
        Me.SimulationWorldUsage.Text = mDictionary.tThisWorldSimulates.Translated & "  "
        Me.SimulationWorldUsage.Text &= mDictionary.tSelectYourParameters.Translated
        '
        ' Display User Level dependent UI
        '
        Select Case (mWinSRFR.UserLevel)
            Case UserLevels.Research

                Me.ConstituentTransportBox.Visible = True
                Me.ConstituentTransportBox.Enabled = True

                Me.EnableErosionControl.Visible = True
                Me.EnableErosionControl.Enabled = True

                Me.EnableFertigationControl.Visible = True
                Me.EnableFertigationControl.Enabled = True

            Case UserLevels.Advanced

                Me.ConstituentTransportBox.Visible = True
                Me.ConstituentTransportBox.Enabled = True

                Me.EnableErosionControl.Visible = False
                Me.EnableErosionControl.Enabled = False

                Me.EnableFertigationControl.Visible = True
                Me.EnableFertigationControl.Enabled = True

            Case Else ' UserLevels.Standard

                Me.ConstituentTransportBox.Visible = False
                Me.ConstituentTransportBox.Enabled = False

                Me.EnableErosionControl.Visible = False
                Me.EnableErosionControl.Enabled = False

                Me.EnableFertigationControl.Visible = False
                Me.EnableFertigationControl.Enabled = False

        End Select

        If (mViewHelp) Then
            SimulationWorldHelp.BringToFront()
        Else
            ComputationNetwork.BringToFront()
            ComputationNetKey.BringToFront()
        End If

    End Sub
    '
    ' Resize the UI to fill available space
    '
    Private Sub ResizeUI()

        Dim margin As Integer = 5
        Dim width As Integer = Me.Width - 2 * margin
        Dim third As Integer = width / 3

        ' Title
        Dim top As Integer = margin
        Dim loc As Point = New Point(margin, top)
        Me.SimulationWorldTitle.Location = loc
        Me.SimulationWorldTitle.Width = width

        ' Usage
        top += Me.SimulationWorldTitle.Height + margin
        loc = New Point(margin, top)
        Me.SimulationWorldUsage.Location = loc
        Me.SimulationWorldUsage.Width = width

        ' Controls
        top += Me.SimulationWorldUsage.Height + margin
        loc = New Point(margin, top)
        Me.SystemTypeGroup.Location = loc
        Me.SystemTypeGroup.Width = third - margin

        loc = New Point(loc.X + third, top)
        Me.IrrigationWaterUseBox.Location = loc
        Me.IrrigationWaterUseBox.Width = third

        loc = New Point(loc.X + third + margin, top)
        Me.ConstituentTransportBox.Location = loc
        Me.ConstituentTransportBox.Width = third - margin

        ' Description
        top += Me.SystemTypeGroup.Height + margin
        loc = New Point(margin, top)
        Me.SimulationWorldHelp.Location = loc
        Me.SimulationWorldHelp.Width = width
        Me.SimulationWorldHelp.Height = Me.Height - top - 2 * margin

        Me.ComputationNetwork.Location = loc
        Me.ComputationNetwork.Width = width
        Me.ComputationNetwork.Height = Me.Height - top - 2 * margin

        loc = New Point(Me.Width - Me.ToggleButton.Width, Me.Height - Me.ToggleButton.Height)
        Me.ToggleButton.Location = loc

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " UI Event Handlers "

    Private mToggling As Boolean = False
    Private Sub ToggleButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ToggleButton.CheckedChanged
        If Not (mToggling) Then
            mToggling = True
            mViewHelp = Not mViewHelp
            ToggleButton.Checked = False
            UpdateUI()
            mToggling = False
        End If
    End Sub
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        ResizeUI()
    End Sub

#End Region

End Class
