
'*************************************************************************************************************
' ctl_AdvanceRecession - UI for viewing & editing Advance & Recession data
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI
Imports PrintingUI

Public Class ctl_AdvanceRecession
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
    Friend WithEvents SyncRecessionWithAdvance As DataStore.ctl_Button
    Friend WithEvents RecessionControl As DataStore.ctl_DataTableParameter
    Friend WithEvents AdvanceControl As DataStore.ctl_DataTableParameter
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents AdvRecGraphicsPanel As DataStore.ctl_Panel
    Friend WithEvents AdvRecGraph As GraphingUI.ex_PictureBox
    Friend WithEvents AdvRecInstructions As WinMain.ErrorRichTextBox
    Friend WithEvents AdvRecMeasurementsBox As DataStore.ctl_GroupBox
    Friend WithEvents AdvanceTimesLabel As DataStore.ctl_Label
    Friend WithEvents UseRecessionCheck As DataStore.ctl_CheckParameter
    Friend WithEvents RecessionTimesCheck As DataStore.ctl_CheckParameter
    Friend WithEvents TwoPointAdvanceControl As DataStore.ctl_DataTableParameter
    Friend WithEvents AdvancePowerLawBox As DataStore.ctl_GroupBox
    Friend WithEvents rControl As DataStore.ctl_DoubleParameter
    Friend WithEvents rLabel As System.Windows.Forms.Label
    Friend WithEvents pControl As WinMain.ctl_PowerAdvancePParameter
    Friend WithEvents pLabel As System.Windows.Forms.Label
    Friend WithEvents ResetButton As DataStore.ctl_Button
    Friend WithEvents PowerLawWarningLabel As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.SyncRecessionWithAdvance = New DataStore.ctl_Button
        Me.RecessionControl = New DataStore.ctl_DataTableParameter
        Me.AdvanceControl = New DataStore.ctl_DataTableParameter
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.AdvRecGraphicsPanel = New DataStore.ctl_Panel
        Me.AdvRecGraph = New GraphingUI.ex_PictureBox
        Me.AdvRecMeasurementsBox = New DataStore.ctl_GroupBox
        Me.UseRecessionCheck = New DataStore.ctl_CheckParameter
        Me.RecessionTimesCheck = New DataStore.ctl_CheckParameter
        Me.AdvanceTimesLabel = New DataStore.ctl_Label
        Me.TwoPointAdvanceControl = New DataStore.ctl_DataTableParameter
        Me.AdvancePowerLawBox = New DataStore.ctl_GroupBox
        Me.ResetButton = New DataStore.ctl_Button
        Me.rControl = New DataStore.ctl_DoubleParameter
        Me.rLabel = New System.Windows.Forms.Label
        Me.pControl = New WinMain.ctl_PowerAdvancePParameter
        Me.pLabel = New System.Windows.Forms.Label
        Me.PowerLawWarningLabel = New DataStore.ctl_Label
        Me.AdvRecInstructions = New WinMain.ErrorRichTextBox
        CType(Me.RecessionControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvanceControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AdvRecGraphicsPanel.SuspendLayout()
        CType(Me.AdvRecGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AdvRecMeasurementsBox.SuspendLayout()
        CType(Me.TwoPointAdvanceControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AdvancePowerLawBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'SyncRecessionWithAdvance
        '
        Me.SyncRecessionWithAdvance.AccessibleDescription = "Moves the Advance Table values to the Recession Table."
        Me.SyncRecessionWithAdvance.AccessibleName = "Move Advance Values to Recession Table"
        Me.SyncRecessionWithAdvance.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SyncRecessionWithAdvance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SyncRecessionWithAdvance.Location = New System.Drawing.Point(0, 391)
        Me.SyncRecessionWithAdvance.Name = "SyncRecessionWithAdvance"
        Me.SyncRecessionWithAdvance.Size = New System.Drawing.Size(310, 25)
        Me.SyncRecessionWithAdvance.TabIndex = 3
        Me.SyncRecessionWithAdvance.Text = "&Move Advance Values to Recession Table"
        Me.SyncRecessionWithAdvance.UseVisualStyleBackColor = False
        '
        'RecessionControl
        '
        Me.RecessionControl.AccessibleDescription = "Table for inputting the irrigation's recession measurements."
        Me.RecessionControl.AccessibleName = "Recession Table"
        Me.RecessionControl.AllRowsFixed = False
        Me.RecessionControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.RecessionControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.RecessionControl.CaptionText = "Recession Table"
        Me.RecessionControl.CausesValidation = False
        Me.RecessionControl.ColumnWidthRatios = Nothing
        Me.RecessionControl.DataMember = ""
        Me.RecessionControl.EnableSaveActions = False
        Me.RecessionControl.FirstColumnIncreases = True
        Me.RecessionControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.RecessionControl.FirstColumnMinimum = 0
        Me.RecessionControl.FirstRowFixed = False
        Me.RecessionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecessionControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.RecessionControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.RecessionControl.Location = New System.Drawing.Point(160, 77)
        Me.RecessionControl.MaxRows = 99
        Me.RecessionControl.MinRows = 0
        Me.RecessionControl.Name = "RecessionControl"
        Me.RecessionControl.PasteDisabled = False
        Me.RecessionControl.SecondColumnIncreases = False
        Me.RecessionControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.RecessionControl.SecondColumnMinimum = 0
        Me.RecessionControl.Size = New System.Drawing.Size(150, 308)
        Me.RecessionControl.TabIndex = 2
        Me.RecessionControl.TableReadonly = False
        '
        'AdvanceControl
        '
        Me.AdvanceControl.AccessibleDescription = "Table defining the advance of the irrigation water as it flows down the field.."
        Me.AdvanceControl.AccessibleName = "Advance Table"
        Me.AdvanceControl.AllRowsFixed = False
        Me.AdvanceControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.AdvanceControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.AdvanceControl.CaptionText = "Advance Table"
        Me.AdvanceControl.CausesValidation = False
        Me.AdvanceControl.ColumnWidthRatios = Nothing
        Me.AdvanceControl.DataMember = ""
        Me.AdvanceControl.EnableSaveActions = False
        Me.AdvanceControl.FirstColumnIncreases = True
        Me.AdvanceControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.AdvanceControl.FirstColumnMinimum = 0
        Me.AdvanceControl.FirstRowFixed = True
        Me.AdvanceControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvanceControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.AdvanceControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.AdvanceControl.Location = New System.Drawing.Point(5, 77)
        Me.AdvanceControl.MaxRows = 99
        Me.AdvanceControl.MinRows = 0
        Me.AdvanceControl.Name = "AdvanceControl"
        Me.AdvanceControl.PasteDisabled = False
        Me.AdvanceControl.SecondColumnIncreases = True
        Me.AdvanceControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.AdvanceControl.SecondColumnMinimum = 0
        Me.AdvanceControl.Size = New System.Drawing.Size(150, 278)
        Me.AdvanceControl.TabIndex = 1
        Me.AdvanceControl.TableReadonly = False
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'AdvRecGraphicsPanel
        '
        Me.AdvRecGraphicsPanel.Controls.Add(Me.AdvRecGraph)
        Me.AdvRecGraphicsPanel.Location = New System.Drawing.Point(316, 77)
        Me.AdvRecGraphicsPanel.Name = "AdvRecGraphicsPanel"
        Me.AdvRecGraphicsPanel.Size = New System.Drawing.Size(461, 166)
        Me.AdvRecGraphicsPanel.TabIndex = 5
        '
        'AdvRecGraph
        '
        Me.AdvRecGraph.AccessibleDescription = "A copyable bitmap image"
        Me.AdvRecGraph.AccessibleName = "Advance / Recession graph"
        Me.AdvRecGraph.Location = New System.Drawing.Point(3, 3)
        Me.AdvRecGraph.Name = "AdvRecGraph"
        Me.AdvRecGraph.Size = New System.Drawing.Size(450, 160)
        Me.AdvRecGraph.TabIndex = 16
        Me.AdvRecGraph.TabStop = False
        Me.AdvRecGraph.Text = "Bitmap Diagram"
        '
        'AdvRecMeasurementsBox
        '
        Me.AdvRecMeasurementsBox.AccessibleDescription = "Select the availability and use of the irrigation's advance and recession data."
        Me.AdvRecMeasurementsBox.AccessibleName = "Field Measurements"
        Me.AdvRecMeasurementsBox.Controls.Add(Me.UseRecessionCheck)
        Me.AdvRecMeasurementsBox.Controls.Add(Me.RecessionTimesCheck)
        Me.AdvRecMeasurementsBox.Controls.Add(Me.AdvanceTimesLabel)
        Me.AdvRecMeasurementsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvRecMeasurementsBox.Location = New System.Drawing.Point(5, 5)
        Me.AdvRecMeasurementsBox.Name = "AdvRecMeasurementsBox"
        Me.AdvRecMeasurementsBox.Size = New System.Drawing.Size(430, 66)
        Me.AdvRecMeasurementsBox.TabIndex = 0
        Me.AdvRecMeasurementsBox.TabStop = False
        Me.AdvRecMeasurementsBox.Text = "Field Measurements"
        '
        'UseRecessionCheck
        '
        Me.UseRecessionCheck.AlwaysChecked = False
        Me.UseRecessionCheck.AutoSize = True
        Me.UseRecessionCheck.ErrorMessage = Nothing
        Me.UseRecessionCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UseRecessionCheck.Location = New System.Drawing.Point(225, 40)
        Me.UseRecessionCheck.Name = "UseRecessionCheck"
        Me.UseRecessionCheck.Size = New System.Drawing.Size(173, 21)
        Me.UseRecessionCheck.TabIndex = 3
        Me.UseRecessionCheck.Text = "&Use for VB calculations"
        Me.UseRecessionCheck.UncheckAttemptMessage = Nothing
        Me.UseRecessionCheck.UseVisualStyleBackColor = True
        '
        'RecessionTimesCheck
        '
        Me.RecessionTimesCheck.AlwaysChecked = False
        Me.RecessionTimesCheck.AutoSize = True
        Me.RecessionTimesCheck.ErrorMessage = Nothing
        Me.RecessionTimesCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecessionTimesCheck.Location = New System.Drawing.Point(225, 20)
        Me.RecessionTimesCheck.Name = "RecessionTimesCheck"
        Me.RecessionTimesCheck.Size = New System.Drawing.Size(171, 21)
        Me.RecessionTimesCheck.TabIndex = 2
        Me.RecessionTimesCheck.Text = "I &Have Recession Data"
        Me.RecessionTimesCheck.UncheckAttemptMessage = Nothing
        Me.RecessionTimesCheck.UseVisualStyleBackColor = True
        '
        'AdvanceTimesLabel
        '
        Me.AdvanceTimesLabel.AutoSize = True
        Me.AdvanceTimesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvanceTimesLabel.Location = New System.Drawing.Point(15, 20)
        Me.AdvanceTimesLabel.Name = "AdvanceTimesLabel"
        Me.AdvanceTimesLabel.Size = New System.Drawing.Size(173, 17)
        Me.AdvanceTimesLabel.TabIndex = 0
        Me.AdvanceTimesLabel.Text = "Advance Data are Required"
        '
        'TwoPointAdvanceControl
        '
        Me.TwoPointAdvanceControl.AccessibleDescription = "Table for inputting the irrigation's advance measurements."
        Me.TwoPointAdvanceControl.AccessibleName = "Advance Table"
        Me.TwoPointAdvanceControl.AllRowsFixed = False
        Me.TwoPointAdvanceControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TwoPointAdvanceControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TwoPointAdvanceControl.CaptionText = "Advance Table"
        Me.TwoPointAdvanceControl.CausesValidation = False
        Me.TwoPointAdvanceControl.ColumnWidthRatios = Nothing
        Me.TwoPointAdvanceControl.DataMember = ""
        Me.TwoPointAdvanceControl.EnableSaveActions = False
        Me.TwoPointAdvanceControl.FirstColumnIncreases = True
        Me.TwoPointAdvanceControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.TwoPointAdvanceControl.FirstColumnMinimum = 0
        Me.TwoPointAdvanceControl.FirstRowFixed = False
        Me.TwoPointAdvanceControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TwoPointAdvanceControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TwoPointAdvanceControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TwoPointAdvanceControl.Location = New System.Drawing.Point(5, 77)
        Me.TwoPointAdvanceControl.MaxRows = 99
        Me.TwoPointAdvanceControl.MinRows = 0
        Me.TwoPointAdvanceControl.Name = "TwoPointAdvanceControl"
        Me.TwoPointAdvanceControl.PasteDisabled = False
        Me.TwoPointAdvanceControl.SecondColumnIncreases = True
        Me.TwoPointAdvanceControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.TwoPointAdvanceControl.SecondColumnMinimum = 0
        Me.TwoPointAdvanceControl.Size = New System.Drawing.Size(150, 308)
        Me.TwoPointAdvanceControl.TabIndex = 1
        Me.TwoPointAdvanceControl.TableReadonly = False
        '
        'AdvancePowerLawBox
        '
        Me.AdvancePowerLawBox.AccessibleDescription = "Display and edit of the advance power law parameters p and r."
        Me.AdvancePowerLawBox.AccessibleName = "Advance Power Law Parameters"
        Me.AdvancePowerLawBox.Controls.Add(Me.ResetButton)
        Me.AdvancePowerLawBox.Controls.Add(Me.rControl)
        Me.AdvancePowerLawBox.Controls.Add(Me.rLabel)
        Me.AdvancePowerLawBox.Controls.Add(Me.pControl)
        Me.AdvancePowerLawBox.Controls.Add(Me.pLabel)
        Me.AdvancePowerLawBox.Controls.Add(Me.PowerLawWarningLabel)
        Me.AdvancePowerLawBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvancePowerLawBox.Location = New System.Drawing.Point(442, 5)
        Me.AdvancePowerLawBox.Name = "AdvancePowerLawBox"
        Me.AdvancePowerLawBox.Size = New System.Drawing.Size(327, 66)
        Me.AdvancePowerLawBox.TabIndex = 4
        Me.AdvancePowerLawBox.TabStop = False
        Me.AdvancePowerLawBox.Text = "Advance Power Law Parameters"
        '
        'ResetButton
        '
        Me.ResetButton.AccessibleDescription = "Moves the Advance Table values to the Recession Table."
        Me.ResetButton.AccessibleName = "Move Advance to Recession Button"
        Me.ResetButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ResetButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ResetButton.Location = New System.Drawing.Point(252, 29)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(60, 24)
        Me.ResetButton.TabIndex = 4
        Me.ResetButton.Text = "R&eset"
        Me.ResetButton.UseVisualStyleBackColor = False
        '
        'rControl
        '
        Me.rControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.rControl.IsCalculated = False
        Me.rControl.IsInteger = False
        Me.rControl.Location = New System.Drawing.Point(173, 30)
        Me.rControl.MaxErrMsg = ""
        Me.rControl.MinErrMsg = ""
        Me.rControl.Name = "rControl"
        Me.rControl.Size = New System.Drawing.Size(76, 24)
        Me.rControl.TabIndex = 3
        Me.rControl.ToBeCalculated = True
        Me.rControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.rControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.rControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.rControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.rControl.ValueText = ""
        '
        'rLabel
        '
        Me.rLabel.AutoSize = True
        Me.rLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rLabel.Location = New System.Drawing.Point(157, 30)
        Me.rLabel.Name = "rLabel"
        Me.rLabel.Size = New System.Drawing.Size(14, 17)
        Me.rLabel.TabIndex = 2
        Me.rLabel.Text = "&r"
        '
        'pControl
        '
        Me.pControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pControl.Location = New System.Drawing.Point(23, 30)
        Me.pControl.Name = "pControl"
        Me.pControl.Size = New System.Drawing.Size(126, 24)
        Me.pControl.TabIndex = 1
        Me.pControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.pControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.pControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.pControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.pControl.ValueText = ""
        '
        'pLabel
        '
        Me.pLabel.AutoSize = True
        Me.pLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pLabel.Location = New System.Drawing.Point(6, 30)
        Me.pLabel.Name = "pLabel"
        Me.pLabel.Size = New System.Drawing.Size(17, 17)
        Me.pLabel.TabIndex = 0
        Me.pLabel.Text = "&p"
        '
        'PowerLawWarningLabel
        '
        Me.PowerLawWarningLabel.AccessibleDescription = "Indicates not enough data has been entered to calculate the advance power law."
        Me.PowerLawWarningLabel.AccessibleName = "Advance Power Law Warning"
        Me.PowerLawWarningLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLawWarningLabel.Location = New System.Drawing.Point(13, 20)
        Me.PowerLawWarningLabel.Name = "PowerLawWarningLabel"
        Me.PowerLawWarningLabel.Size = New System.Drawing.Size(300, 41)
        Me.PowerLawWarningLabel.TabIndex = 5
        Me.PowerLawWarningLabel.Text = "Calculation of parameters requires at least one advance point."
        Me.PowerLawWarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AdvRecInstructions
        '
        Me.AdvRecInstructions.AccessibleDescription = "Description of the input and use of an irrigation's advance and recession measure" & _
            "ments."
        Me.AdvRecInstructions.AccessibleName = "Advance / Recession summary"
        Me.AdvRecInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.AdvRecInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.AdvRecInstructions.Location = New System.Drawing.Point(316, 250)
        Me.AdvRecInstructions.Name = "AdvRecInstructions"
        Me.AdvRecInstructions.ReadOnly = True
        Me.AdvRecInstructions.Size = New System.Drawing.Size(461, 166)
        Me.AdvRecInstructions.TabIndex = 6
        Me.AdvRecInstructions.Text = ""
        '
        'ctl_AdvanceRecession
        '
        Me.AccessibleDescription = "Control for inputting and displaying the irrigation's advance and recession measu" & _
            "rments."
        Me.AccessibleName = "Advance / Recession"
        Me.Controls.Add(Me.AdvancePowerLawBox)
        Me.Controls.Add(Me.TwoPointAdvanceControl)
        Me.Controls.Add(Me.AdvRecMeasurementsBox)
        Me.Controls.Add(Me.AdvRecInstructions)
        Me.Controls.Add(Me.AdvRecGraphicsPanel)
        Me.Controls.Add(Me.SyncRecessionWithAdvance)
        Me.Controls.Add(Me.RecessionControl)
        Me.Controls.Add(Me.AdvanceControl)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_AdvanceRecession"
        Me.Size = New System.Drawing.Size(780, 422)
        CType(Me.RecessionControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvanceControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AdvRecGraphicsPanel.ResumeLayout(False)
        CType(Me.AdvRecGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AdvRecMeasurementsBox.ResumeLayout(False)
        Me.AdvRecMeasurementsBox.PerformLayout()
        CType(Me.TwoPointAdvanceControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AdvancePowerLawBox.ResumeLayout(False)
        Me.AdvancePowerLawBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    Private Const MinAdvRecMeasBoxWidth As Integer = 430

#End Region

#Region " Control / Model Linkage "
    '
    ' Field data
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm
    Private WithEvents mWinSRFR As WinSRFR

    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mEventCriteria As EventCriteria

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Private mMyStore As DataStore.ObjectNode
    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal unit As Unit, ByVal worldWindow As WorldWindow)

        Debug.Assert((unit IsNot Nothing), "Unit is Nothing")

        ' Link this control to its data model and store
        mUnit = unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mEventCriteria = mUnit.EventCriteriaRef

        mWorldWindow = worldWindow

        mMyStore = mUnit.MyStore

        ' Tabulated Advance DataTable control
        AdvanceControl.LinkToModel(mMyStore, mInflowManagement.TabulatedAdvanceProperty)
        AdvanceControl.ColumnWidthRatios = New Integer() {4, 3}
        AdvanceControl.FirstRowFixed = True
        AdvanceControl.UpdateUI()

        TwoPointAdvanceControl.LinkToModel(mMyStore, mInflowManagement.TwoPointTabulatedAdvanceProperty)
        TwoPointAdvanceControl.ColumnWidthRatios = New Integer() {4, 3}
        TwoPointAdvanceControl.FirstRowFixed = True
        TwoPointAdvanceControl.MinRows = 3
        TwoPointAdvanceControl.MaxRows = 3
        TwoPointAdvanceControl.UpdateUI()

        pControl.LinkToModel(mMyStore, mInflowManagement.AdvancePProperty)

        rControl.LinkToModel(mMyStore, mInflowManagement.AdvanceRProperty)
        rControl.MaxErrMsg = mDictionary.tPowerRgt1.Translated & " " & mDictionary.tRInstruct.Translated

        ' Tabulated Recession DataTable control
        RecessionControl.LinkToModel(mMyStore, mInflowManagement.TabulatedRecessionProperty)
        RecessionControl.ColumnWidthRatios = New Integer() {4, 3}
        RecessionControl.FirstRowFixed = False
        RecessionControl.UpdateUI()

        RecessionTimesCheck.LinkToModel(mMyStore, mInflowManagement.RecessionMeasuredProperty)
        UseRecessionCheck.LinkToModel(mMyStore, mInflowManagement.RecessionUsedProperty)

        ' Update this control's User Interface
        UpdateUI()

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
    ' Update UI when referenced DataStore values change
    '
    Private Sub InflowManagement_PropertyChanged(ByVal reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        ResizeUI()
        UpdateUI()
    End Sub

    Private Sub SystemGeometry_PropertyChanged(ByVal reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        ResizeUI()
        UpdateUI()
    End Sub

    Private Sub EventCriteria_PropertyChanged(ByVal reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        ResizeUI()
        UpdateUI()
    End Sub
    '
    ' Update UI when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "

    Private Sub ctl_AdvanceRecession_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        UpdateUI()
    End Sub

    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mEventCriteria IsNot Nothing) Then
            Dim length As Double = mSystemGeometry.Length.Value
            '
            ' Update Advance controls
            '
            AdvanceMeasured(mEventCriteria.AdvancePrereq)

            Select Case (mEventCriteria.EventAnalysisType.Value)
                Case EventAnalysisTypes.TwoPointAnalysis
                    Me.AdvanceControl.Hide()
                    Me.TwoPointAdvanceControl.Show()
                    Me.AdvancePowerLawBox.Show()
                Case EventAnalysisTypes.MerriamKellerAnalysis
                    Me.TwoPointAdvanceControl.Hide()
                    Me.AdvanceControl.Show()
                    Me.AdvancePowerLawBox.Hide()
                Case EventAnalysisTypes.EvalueAnalysis
                    Me.TwoPointAdvanceControl.Hide()
                    Me.AdvanceControl.Show()
                    Me.AdvancePowerLawBox.Show()
                Case Else
                    Me.AdvanceControl.Hide()
                    Me.TwoPointAdvanceControl.Hide()
                    Me.AdvancePowerLawBox.Hide()
            End Select

            ' Set maximum Distance table value(s)
            Me.TwoPointAdvanceControl.FirstColumnMaximum = length
            Me.TwoPointAdvanceControl.UpdateUI()

            Me.AdvanceControl.FirstColumnMaximum = length
            Me.AdvanceControl.UpdateUI()

            ' Verify Advance table
            Dim _advance As DataTable = mInflowManagement.TabulatedAdvance.Value
            If (Me.TwoPointAdvanceControl.Visible) Then
                _advance = mInflowManagement.TwoPointTabulatedAdvance.Value
            End If
            If (_advance IsNot Nothing) Then
                Dim _advanceRows As Integer = _advance.Rows.Count
                If (_advanceRows < 2) Then ' no advance points
                    Me.pLabel.Hide()
                    Me.pControl.Hide()
                    Me.rLabel.Hide()
                    Me.rControl.Hide()
                    Me.ResetButton.Hide()
                    Me.PowerLawWarningLabel.Show()
                Else ' at least 1 advance point
                    Me.PowerLawWarningLabel.Hide()
                    Me.pLabel.Show()
                    Me.pControl.Show()
                    Me.rLabel.Show()
                    Me.rControl.Show()

                    If (Me.TwoPointAdvanceControl.Visible) Then
                        Me.pControl.IsCalculated = True
                        Me.rControl.IsCalculated = True
                        Me.ResetButton.Hide()
                    Else
                        Me.pControl.IsCalculated = False
                        Me.rControl.IsCalculated = False
                        Me.ResetButton.Show()
                    End If

                    Me.pControl.UpdateUI()
                    Me.rControl.UpdateUI()
                End If

            Else ' No Advance
                Me.pLabel.Hide()
                Me.pControl.Hide()
                Me.rLabel.Hide()
                Me.rControl.Hide()
                Me.ResetButton.Hide()
                Me.PowerLawWarningLabel.Show()
            End If
            '
            ' Update Recession controls
            '
            RecessionMeasured(mEventCriteria.RecessionPrereq)

            Select Case (mEventCriteria.EventAnalysisType.Value)
                Case EventAnalysisTypes.TwoPointAnalysis
                    Me.UseRecessionCheck.Hide()
                Case EventAnalysisTypes.MerriamKellerAnalysis
                    Me.UseRecessionCheck.Hide()
                Case Else
                    Me.UseRecessionCheck.Show()
            End Select

            If ((mInflowManagement.RecessionMeasured.Value) And Not _
                (mEventCriteria.RecessionPrereq = EventCriteria.Prerequisites.NotUsed)) Then

                Me.RecessionControl.Show()
                Me.SyncRecessionWithAdvance.Show()

            Else ' Recession has not been measured

                Me.RecessionControl.Hide()
                Me.SyncRecessionWithAdvance.Hide()

                RecessionControlErrorProviderSetError("")

            End If

            ' Set maximum Distance table value(s)
            Me.RecessionControl.FirstColumnMaximum = length
            Me.RecessionControl.UpdateUI()

            UpdateInstructions()
            UpdateGraphics()
        End If
    End Sub

    Private Sub AdvanceControlErrorProviderSetError(ByVal ErrMsg As String)
        If (AdvanceControl.Visible) Then
            Me.ErrorProvider.SetError(AdvanceControl, ErrMsg)
        Else
            Me.ErrorProvider.SetError(AdvanceControl, "")
        End If
    End Sub

    Private Sub RecessionControlErrorProviderSetError(ByVal ErrMsg As String)
        If (RecessionControl.Visible) Then
            Me.ErrorProvider.SetError(RecessionControl, ErrMsg)
        Else
            Me.ErrorProvider.SetError(RecessionControl, "")
        End If
    End Sub

    Private Sub AdvanceMeasured(ByVal Prerequisite As EventCriteria.Prerequisites)

        Dim measured As Boolean = mInflowManagement.AdvanceMeasured.Value

        ' Control the display / use of the Measured checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.Required, EventCriteria.Prerequisites.RequiredVB

                Me.AdvanceTimesLabel.Enabled = True
                Me.AdvanceTimesLabel.Visible = True

            Case EventCriteria.Prerequisites.Useful, EventCriteria.Prerequisites.UsefulVB

                Me.AdvanceTimesLabel.Enabled = True
                Me.AdvanceTimesLabel.Visible = True

            Case Else ' EventCriteria.Prerequisites.NotUsed

                Me.AdvanceTimesLabel.Enabled = False
                Me.AdvanceTimesLabel.Visible = False

        End Select

    End Sub

    Private Sub RecessionMeasured(ByVal Prerequisite As EventCriteria.Prerequisites)

        Dim measured As Boolean = mInflowManagement.RecessionMeasured.Value
        Dim used As Boolean = True ' Used control is only for EVALUE
        If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.EvalueAnalysis) Then
            used = mInflowManagement.RecessionUsed.Value
        End If

        ' Control the display / use of the Measured checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.Required, EventCriteria.Prerequisites.RequiredVB

                Me.RecessionTimesCheck.Enabled = True
                Me.RecessionTimesCheck.Visible = True
                Me.RecessionTimesCheck.AlwaysChecked = True
                Me.RecessionTimesCheck.UncheckAttemptMessage = mDictionary.tRecessionRequired.Translated

                If ((Not measured) Or (Not used)) Then
                    Me.RecessionTimesCheck.ErrorMessage = mDictionary.tRecessionRequired.Translated
                Else
                    Me.RecessionTimesCheck.ErrorMessage = ""
                End If

            Case EventCriteria.Prerequisites.Useful, EventCriteria.Prerequisites.UsefulVB

                Me.RecessionTimesCheck.Enabled = True
                Me.RecessionTimesCheck.Visible = True
                Me.RecessionTimesCheck.AlwaysChecked = False
                Me.RecessionTimesCheck.ErrorMessage = ""

            Case Else ' EventCriteria.Prerequisites.NotUsed

                Me.RecessionTimesCheck.Enabled = False
                Me.RecessionTimesCheck.Visible = False
                Me.RecessionTimesCheck.AlwaysChecked = False
                Me.RecessionTimesCheck.ErrorMessage = ""

        End Select

        ' Control the display / use of the Used checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.RequiredVB

                Me.UseRecessionCheck.Enabled = True
                Me.UseRecessionCheck.Visible = True
                Me.UseRecessionCheck.AlwaysChecked = True
                Me.UseRecessionCheck.UncheckAttemptMessage = Me.RecessionTimesCheck.UncheckAttemptMessage

            Case EventCriteria.Prerequisites.UsefulVB

                Me.UseRecessionCheck.Enabled = Me.RecessionTimesCheck.Enabled And Me.RecessionTimesCheck.Checked
                Me.UseRecessionCheck.Visible = Me.RecessionTimesCheck.Enabled And Me.RecessionTimesCheck.Checked
                Me.UseRecessionCheck.AlwaysChecked = False

            Case Else

                Me.UseRecessionCheck.Enabled = False
                Me.UseRecessionCheck.Visible = False
                Me.UseRecessionCheck.AlwaysChecked = False

        End Select

    End Sub
    '
    ' Update instructions for entering inflow/runoff data
    '
    Private Sub UpdateInstructions()
        AdvRecInstructions.Clear()
        AdvRecInstructions.SelectionAlignment = HorizontalAlignment.Left
        '
        ' Advance instructions
        '
        AppendBoldText(AdvRecInstructions, mDictionary.tAdvance.Translated & " - ")
        If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
            AppendLine(AdvRecInstructions, mDictionary.t2PointAdvInstructions.Translated)
        Else
            AppendLine(AdvRecInstructions, mDictionary.tAdvanceInstructions.Translated)
        End If

        If (Me.AdvancePowerLawBox.Visible) Then
            AdvanceLine(AdvRecInstructions)
            AppendLine(AdvRecInstructions, " " & mDictionary.tAdvanceTableGraphedAsPoints.Translated)
            AppendLine(AdvRecInstructions, " " & mDictionary.tPowerLawAdvanceGraphedAsCurve.Translated)
        End If
        '
        ' Recession instructions
        '
        If (Me.RecessionTimesCheck.Enabled And Me.RecessionTimesCheck.Checked) Then
            AdvanceLine(AdvRecInstructions)
            AppendBoldText(AdvRecInstructions, mDictionary.tRecession.Translated & " - ")
            AppendLine(AdvRecInstructions, mDictionary.tRecessionInstructions.Translated)
            AdvanceLine(AdvRecInstructions)

            If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.MerriamKellerAnalysis) Then
                AppendLine(AdvRecInstructions, mDictionary.tRecessionNotes2.Translated)
            Else
                AppendLine(AdvRecInstructions, mDictionary.tRecessionNotes1.Translated)
            End If

            If Not (mInflowManagement.RecessionDataAvailable) Then
                AdvanceLine(AdvRecInstructions)
                AppendBoldText(AdvRecInstructions, mDictionary.tError.Translated & " - ")
                AppendLine(AdvRecInstructions, mDictionary.tNoRecessionSpecified.Translated)
            End If
        End If

    End Sub

    Private Sub ctl_AdvanceRecession_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        ResizeUI()
    End Sub

    Public Sub ResizeUI()

        If (mEventCriteria Is Nothing) Then
            Return
        End If

        If (Me.AdvancePowerLawBox.Visible) Then ' Power Law box is visible
            Me.AdvRecMeasurementsBox.Width = MinAdvRecMeasBoxWidth ' Measurement box has minimum width
        Else ' Power Law box not visible
            Me.AdvRecMeasurementsBox.Width = Me.Width - 10 ' Measurement box takes entire width
        End If

        Dim varyHeight As Integer = Me.Height - Me.AdvRecMeasurementsBox.Height
        Dim varyWidth As Integer = Me.Width - Me.AdvRecMeasurementsBox.Width

        Dim locX, locY, graphHeight, graphWidth As Integer
        Dim graphLoc As Point

        If ((mInflowManagement.RecessionMeasured.Value) And Not _
            (mEventCriteria.RecessionPrereq = EventCriteria.Prerequisites.NotUsed)) Then

            ' Adjust contained controls to match new height
            Me.AdvanceControl.Height = varyHeight - Me.SyncRecessionWithAdvance.Height - 12
            Me.TwoPointAdvanceControl.Height = Me.AdvanceControl.Height
            Me.RecessionControl.Height = Me.AdvanceControl.Height

            ' Adjust contained controls to match new width
            If (Me.AdvancePowerLawBox.Visible) Then
                Me.AdvancePowerLawBox.Width = varyWidth - 16
            End If

            ' Adjust contained controls to maintain relative positions
            locX = Me.AdvanceControl.Location.X
            locY = Me.AdvanceControl.Location.Y + Me.AdvanceControl.Height + 2
            Me.SyncRecessionWithAdvance.Location = New Point(locX, locY)

            ' Adjust Graph
            locX = Me.RecessionControl.Location.X + Me.RecessionControl.Width + 8
            locY = Me.RecessionControl.Location.Y

        Else ' only Advance is visible

            ' Adjust contained controls to match new height
            Me.AdvanceControl.Height = varyHeight - 12
            Me.TwoPointAdvanceControl.Height = Me.AdvanceControl.Height

            ' Adjust contained controls to match new width
            If (Me.AdvancePowerLawBox.Visible) Then
                Me.AdvancePowerLawBox.Width = varyWidth - 16
            End If

            ' Adjust Graph
            locX = Me.AdvanceControl.Location.X + Me.AdvanceControl.Width + 8
            locY = Me.AdvanceControl.Location.Y

        End If

        ' Graph
        graphLoc = New Point(locX, locY)
        Me.AdvRecGraphicsPanel.Location = graphLoc

        graphHeight = (varyHeight / 2) - 4
        graphWidth = Me.Width - graphLoc.X - 4

        Me.AdvRecGraphicsPanel.Height = graphHeight
        Me.AdvRecGraphicsPanel.Width = graphWidth

        Me.AdvRecGraph.Location = New Point(1, 1)
        Me.AdvRecGraph.Height = graphHeight - 2
        Me.AdvRecGraph.Width = graphWidth - 2
        UpdateGraphics()

        ' Instructions
        locY = graphLoc.Y + graphHeight + 4
        Me.AdvRecInstructions.Location = New Point(locX, locY)
        Me.AdvRecInstructions.Height = graphHeight - 8
        Me.AdvRecInstructions.Width = graphWidth

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " Advance / Recession Graphics "
    '
    ' Update the Advance / Recession graphics
    '
    Private Sub UpdateGraphics()

        If (mUnit IsNot Nothing) Then
            ' Enclose all graphics code in Try Catch block to ignore exceptions
            Try
                GraphAdvanceRecession(AdvRecGraph)
            Catch ex As Exception
                ' Ignore exceptions
            End Try
        End If

    End Sub
    '
    ' Graph Advance / Recession
    '
    Private Sub GraphAdvanceRecession(ByVal _pictureBox As PictureBox)

        ' Get Advance / Recession data
        Dim advTable As DataTable = mInflowManagement.TabulatedAdvance.Value
        If (Me.TwoPointAdvanceControl.Visible) Then
            advTable = mInflowManagement.TwoPointTabulatedAdvance.Value
        End If

        Dim recTable As DataTable = Nothing
        If (Me.RecessionTimesCheck.Enabled And Me.RecessionTimesCheck.Checked) Then
            recTable = mInflowManagement.TabulatedRecession.Value
        End If

        Dim maxAdvTime As Double = DataColumnMax(advTable, nTimeX1)
        Dim maxRecTime As Double = DataColumnMax(recTable, nTimeX1)
        Dim maxTime As Double = MathMax(maxAdvTime, maxRecTime)

        Dim length As Double = mSystemGeometry.Length.Value

        ' Get drawing tools
        Dim blackPen As Pen = BlackPen1()
        Dim bluePen As Pen = BluePen1()
        Dim brownPen As Pen = BrownPen1()
        Dim grayBrush As SolidBrush = DarkGraySolidBrush()

        ' Create a bitmap for the graphics
        Dim _bitmap As Bitmap = New Bitmap(_pictureBox.Width, _pictureBox.Height)
        Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

        ' Fill the bitmap with the background color
        _graphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, _pictureBox.Width, _pictureBox.Height)
        '
        ' Define & draw the Axes for the graph
        '
        Dim offset As Integer = 16 ' Offset into bitmap for axes
        Dim quadrant As QuadrantSelections = QuadrantSelections.UpperRight

        ' X-axis information (Distance)
        Dim xAxis As Axis
        xAxis.AxisLabel = mDictionary.tDistance.Translated
        xAxis.MaxValue = length
        xAxis.MaxLabel = LengthString(length, 0)

        ' Y-axis information (Time)
        Dim yAxis As Axis
        yAxis.AxisLabel = mDictionary.tTime.Translated
        yAxis.MaxValue = maxTime
        yAxis.MaxLabel = TimeString(maxTime, 0)

        DrawAxes(_bitmap, quadrant, xAxis, yAxis, offset, Me.Font)
        '
        ' Define & draw the Advance curve
        '
        Dim xPoints As ArrayList = New ArrayList
        Dim yPoints As ArrayList = New ArrayList

        Dim dist1 As Double
        Dim time1 As Double

        If (advTable IsNot Nothing) Then
            If (1 < advTable.Rows.Count) Then

                xPoints.Clear()
                yPoints.Clear()

                dist1 = CDbl(advTable.Rows(0).Item(nDistanceX))
                time1 = CDbl(advTable.Rows(0).Item(nTimeX1))

                xPoints.Add(dist1 * 0.97)
                yPoints.Add(time1 * 0.9)

                For rdx As Integer = 1 To advTable.Rows.Count - 1

                    Dim dist2 As Double = CDbl(advTable.Rows(rdx).Item(nDistanceX))
                    Dim time2 As Double = CDbl(advTable.Rows(rdx).Item(nTimeX1))

                    xPoints.Add(dist2 * 0.97)
                    yPoints.Add(time2 * 0.9)

                    dist1 = dist2
                    time1 = time2
                Next rdx

                Dim DrawAdvAsLines As Boolean = True
                If (Me.AdvancePowerLawBox.Visible) Then
                    DrawAdvAsLines = False
                End If
                If (DrawAdvAsLines) Then ' Draw input Advance as lines
                    For line As Integer = 0 To yPoints.Count - 2
                        Dim x1 As Double = CDbl(xPoints(line))
                        Dim y1 As Double = CDbl(yPoints(line))
                        Dim x2 As Double = CDbl(xPoints(line + 1))
                        Dim y2 As Double = CDbl(yPoints(line + 1))
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, x1, y1, x2, y2)
                    Next line
                Else ' Draw input Advance as points
                    For pt As Integer = 0 To yPoints.Count - 1
                        Dim x1 As Double = CDbl(xPoints(pt))
                        Dim y1 As Double = CDbl(yPoints(pt))
                        DrawPoint(_bitmap, quadrant, bluePen, xAxis, yAxis, offset, x1, y1)
                    Next pt
                End If

                Dim DrawPowerLawAdvance As Boolean = False
                If (Me.AdvancePowerLawBox.Visible) Then
                    DrawPowerLawAdvance = True
                End If
                If (DrawPowerLawAdvance) Then

                    Dim p As Double = mInflowManagement.AdvanceP.Value
                    Dim r As Double = mInflowManagement.AdvanceR.Value

                    If ((mInflowManagement.AdvanceP.Source = ValueSources.Calculated) _
                    And (mInflowManagement.AdvanceR.Source = ValueSources.Calculated)) Then
                        Dim newPRok As Boolean = False

                        If (UsePowerAdvanceLaw) Then ' use direct Power Advance Law function
                            newPRok = mInflowManagement.PowerAdvancePandR(p, r)
                        Else ' use AMOEBA fit
                            newPRok = mInflowManagement.AmoebaAdvancePandR(p, r)
                        End If
                    End If

                    xPoints.Clear()
                    yPoints.Clear()

                    Dim noPoints As Integer = 20
                    Dim maxAdvDist As Double = dist1

                    For pdx As Integer = 0 To noPoints - 1
                        dist1 = maxAdvDist * pdx / (noPoints - 1)
                        time1 = (1 / p) ^ (1 / r) * dist1 ^ (1 / r)

                        xPoints.Add(dist1 * 0.97)
                        yPoints.Add(time1 * 0.9)
                    Next pdx

                    For line As Integer = 0 To yPoints.Count - 2
                        Dim x1 As Double = CDbl(xPoints(line))
                        Dim y1 As Double = CDbl(yPoints(line))
                        Dim x2 As Double = CDbl(xPoints(line + 1))
                        Dim y2 As Double = CDbl(yPoints(line + 1))
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, x1, y1, x2, y2)
                    Next line

                End If
            End If
        End If
        '
        ' Define & draw the Recession curve
        '
        If (recTable IsNot Nothing) Then
            If (1 < recTable.Rows.Count) Then

                xPoints.Clear()
                yPoints.Clear()

                dist1 = CDbl(recTable.Rows(0).Item(nDistanceX))
                time1 = CDbl(recTable.Rows(0).Item(nTimeX1))

                xPoints.Add(dist1 * 0.97)
                yPoints.Add(time1 * 0.9)

                For rdx As Integer = 1 To recTable.Rows.Count - 1

                    Dim dist2 As Double = CDbl(recTable.Rows(rdx).Item(nDistanceX))
                    Dim time2 As Double = CDbl(recTable.Rows(rdx).Item(nTimeX1))

                    xPoints.Add(dist2 * 0.97)
                    yPoints.Add(time2 * 0.9)

                    dist1 = dist2
                    time1 = time2
                Next rdx

                Dim DrawRecAsLines As Boolean = True
                If (DrawRecAsLines) Then ' Draw input Recession as lines
                    For line As Integer = 0 To yPoints.Count - 2
                        Dim x1 As Double = CDbl(xPoints(line))
                        Dim y1 As Double = CDbl(yPoints(line))
                        Dim x2 As Double = CDbl(xPoints(line + 1))
                        Dim y2 As Double = CDbl(yPoints(line + 1))
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, x1, y1, x2, y2)
                    Next line
                Else ' Draw input Recession as points
                    For pt As Integer = 0 To yPoints.Count - 1
                        Dim x1 As Double = CDbl(xPoints(pt))
                        Dim y1 As Double = CDbl(yPoints(pt))
                        DrawPoint(_bitmap, quadrant, brownPen, xAxis, yAxis, offset, x1, y1)
                    Next pt
                End If
            End If
            '
            ' Add Avg. Opportunity Time
            '
            If (mInflowManagement.RecessionDataAvailable) Then
                Dim oppTimes As DataTable = mInflowManagement.CalcOpportunityTimes
                Dim avgTime As Double = AverageTimeOverDistance(oppTimes)
                Dim avgTimeString As String = mDictionary.tAvgOppTime.Translated & " = " & TimeString(avgTime, 0)
                _graphics.DrawString(avgTimeString, Me.Font, grayBrush, offset + 8, _bitmap.Height / 2)
            End If
        End If
        '
        ' Copy the new bitmap into the image (this prevents flicker)
        '
        If (_pictureBox.Image IsNot Nothing) Then
            _pictureBox.Image.Dispose()
            _pictureBox.Image = Nothing
        End If

        _pictureBox.Image = _bitmap

    End Sub

#End Region

#Region " UI Event Handler(s) "

    Private Sub AdvanceControl_ControlValueChanged() _
    Handles AdvanceControl.ControlValueChanged
        mInflowManagement.MyStore.EventsEnabled = False
        ResetPandR(False)
        mInflowManagement.MyStore.EventsEnabled = True

        mWorldWindow.UpdateResultsControls()
        UpdateInstructions()
        UpdateGraphics()
    End Sub

    Private Sub TwoPointAdvanceControl_ControlValueChanged() _
    Handles TwoPointAdvanceControl.ControlValueChanged
        mInflowManagement.MyStore.EventsEnabled = False
        ResetPandR(False)
        mInflowManagement.MyStore.EventsEnabled = True

        mWorldWindow.UpdateResultsControls()
        UpdateInstructions()
        UpdateGraphics()
    End Sub

    Private Sub RecessionControl_ControlValueChanged() _
    Handles RecessionControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateInstructions()
        UpdateGraphics()
    End Sub

    Private Sub SyncRecessionWithAdvance_Click(ByVal sender As System.Object, ByVal e As EventArgs) _
    Handles SyncRecessionWithAdvance.Click
        Dim undoText As String = SyncRecessionWithAdvance.Text.Replace("&", "")
        mMyStore.MarkForUndo(undoText)
        Dim advTable As DataTable = mInflowManagement.TabulatedAdvance.Value
        Dim recParam As DataTableParameter = mInflowManagement.TabulatedRecession
        recParam.Source = ValueSources.UserEntered
        recParam.Value = advTable
        mInflowManagement.TabulatedRecession = recParam
    End Sub

    Private Sub ResetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ResetButton.Click
        ResetPandR(True)
    End Sub

    Private Sub ResetPandR(ByVal MarkForUndo As Boolean)
        Dim p, r As Double
        Dim newPRok As Boolean = False

        If (UsePowerAdvanceLaw) Then ' use direct Power Advance Law function
            newPRok = mInflowManagement.PowerAdvancePandR(p, r)
        Else ' use AMOEBA fit
            newPRok = mInflowManagement.AmoebaAdvancePandR(p, r)
        End If

        If (newPRok) Then
            If Not ((p = mInflowManagement.AdvanceP.Value) _
                And (r = mInflowManagement.AdvanceR.Value)) Then

                If (MarkForUndo) Then
                    mMyStore.MarkForUndo(mDictionary.tResetAdvancePandR.Translated)
                End If

                Dim _pParam As PowerAdvancePParameter = mInflowManagement.AdvanceP
                _pParam.Value(r) = p
                _pParam.Source = ValueSources.Calculated
                mInflowManagement.AdvanceP = _pParam

                Dim _rParam As DoubleParameter = mInflowManagement.AdvanceR
                _rParam.Value = r
                _rParam.Source = ValueSources.Calculated
                mInflowManagement.AdvanceR = _rParam
            End If
        End If

        Me.pControl.UpdateUI()
        Me.rControl.UpdateUI()
    End Sub
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
        ResizeUI()
    End Sub

#End Region

End Class
