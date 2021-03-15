
'**********************************************************************************************
' ctl_Runoff - UI for viewing & editing Runoff data
'
' Note - ctl_Runoff is a slimmed-down version of ctl_InflowManagement. It is designed to be
'        used in the Evaluation World. The position of the controls are rearranged to better
'        match other Evaluation World input tabs.  An Instructions field is added to guide the
'        user during data entry.
'
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI
Imports PrintingUI

Public Class ctl_Runoff
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
    Friend WithEvents HydrographGraphicsPanel As DataStore.ctl_Panel
    Friend WithEvents RunoffHydrograph As GraphingUI.ex_PictureBox
    Friend WithEvents RunoffLabel As DataStore.ctl_Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents RunoffGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents TabulatedRunoffControl As DataStore.ctl_DataTableParameter
    Friend WithEvents DownstreamRunoffGroup As DataStore.ctl_GroupBox
    Friend WithEvents OpenEndButton As DataStore.ctl_RadioButton
    Friend WithEvents InflowRunoffStatsPanel As DataStore.ctl_Panel
    Friend WithEvents RunoffDepthLabel As DataStore.ctl_Label
    Friend WithEvents MinusLabel As System.Windows.Forms.Label
    Friend WithEvents InfiltratedDepthLabel As DataStore.ctl_Label
    Friend WithEvents EqualsLabel2 As System.Windows.Forms.Label
    Friend WithEvents DepthAppliedControl As System.Windows.Forms.Label
    Friend WithEvents DepthAppliedLabel As DataStore.ctl_Label
    Friend WithEvents InfiltratedDepthControl As System.Windows.Forms.Label
    Friend WithEvents RunoffDepthControl As System.Windows.Forms.Label
    Friend WithEvents AverageDepthsLabel As DataStore.ctl_Label
    Friend WithEvents RunoffInstructions As WinMain.ErrorRichTextBox
    Friend WithEvents BlockedEndButton As DataStore.ctl_RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.HydrographGraphicsPanel = New DataStore.ctl_Panel
        Me.RunoffHydrograph = New GraphingUI.ex_PictureBox
        Me.RunoffLabel = New DataStore.ctl_Label
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.RunoffGroupBox = New DataStore.ctl_GroupBox
        Me.TabulatedRunoffControl = New DataStore.ctl_DataTableParameter
        Me.DownstreamRunoffGroup = New DataStore.ctl_GroupBox
        Me.OpenEndButton = New DataStore.ctl_RadioButton
        Me.BlockedEndButton = New DataStore.ctl_RadioButton
        Me.AverageDepthsLabel = New DataStore.ctl_Label
        Me.RunoffDepthControl = New System.Windows.Forms.Label
        Me.InfiltratedDepthControl = New System.Windows.Forms.Label
        Me.DepthAppliedLabel = New DataStore.ctl_Label
        Me.DepthAppliedControl = New System.Windows.Forms.Label
        Me.EqualsLabel2 = New System.Windows.Forms.Label
        Me.InfiltratedDepthLabel = New DataStore.ctl_Label
        Me.MinusLabel = New System.Windows.Forms.Label
        Me.RunoffDepthLabel = New DataStore.ctl_Label
        Me.InflowRunoffStatsPanel = New DataStore.ctl_Panel
        Me.RunoffInstructions = New WinMain.ErrorRichTextBox
        Me.HydrographGraphicsPanel.SuspendLayout()
        CType(Me.RunoffHydrograph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RunoffGroupBox.SuspendLayout()
        CType(Me.TabulatedRunoffControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DownstreamRunoffGroup.SuspendLayout()
        Me.InflowRunoffStatsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'HydrographGraphicsPanel
        '
        Me.HydrographGraphicsPanel.Controls.Add(Me.RunoffHydrograph)
        Me.HydrographGraphicsPanel.Location = New System.Drawing.Point(226, 4)
        Me.HydrographGraphicsPanel.Name = "HydrographGraphicsPanel"
        Me.HydrographGraphicsPanel.Size = New System.Drawing.Size(549, 150)
        Me.HydrographGraphicsPanel.TabIndex = 3
        '
        'RunoffHydrograph
        '
        Me.RunoffHydrograph.AccessibleDescription = "A copyable bitmap image"
        Me.RunoffHydrograph.AccessibleName = "Inflow Hydrograph"
        Me.RunoffHydrograph.Location = New System.Drawing.Point(3, 3)
        Me.RunoffHydrograph.Name = "RunoffHydrograph"
        Me.RunoffHydrograph.Size = New System.Drawing.Size(543, 144)
        Me.RunoffHydrograph.TabIndex = 16
        Me.RunoffHydrograph.TabStop = False
        Me.RunoffHydrograph.Text = "Bitmap Diagram"
        '
        'RunoffLabel
        '
        Me.RunoffLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunoffLabel.Location = New System.Drawing.Point(10, 4)
        Me.RunoffLabel.Name = "RunoffLabel"
        Me.RunoffLabel.Size = New System.Drawing.Size(210, 24)
        Me.RunoffLabel.TabIndex = 0
        Me.RunoffLabel.Text = "Inflow / Runoff"
        Me.RunoffLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'RunoffGroupBox
        '
        Me.RunoffGroupBox.Controls.Add(Me.TabulatedRunoffControl)
        Me.RunoffGroupBox.Controls.Add(Me.DownstreamRunoffGroup)
        Me.RunoffGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunoffGroupBox.Location = New System.Drawing.Point(10, 30)
        Me.RunoffGroupBox.Name = "RunoffGroupBox"
        Me.RunoffGroupBox.Size = New System.Drawing.Size(210, 386)
        Me.RunoffGroupBox.TabIndex = 2
        Me.RunoffGroupBox.TabStop = False
        Me.RunoffGroupBox.Text = "&Runoff"
        '
        'TabulatedRunoffControl
        '
        Me.TabulatedRunoffControl.AccessibleDescription = "Table for entering tabulated runoff."
        Me.TabulatedRunoffControl.AccessibleName = "Runoff Table"
        Me.TabulatedRunoffControl.AllRowsFixed = False
        Me.TabulatedRunoffControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedRunoffControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedRunoffControl.CaptionText = "Runoff Table"
        Me.TabulatedRunoffControl.ColumnWidthRatios = Nothing
        Me.TabulatedRunoffControl.DataMember = ""
        Me.TabulatedRunoffControl.EnableSaveActions = False
        Me.TabulatedRunoffControl.FirstColumnIncreases = True
        Me.TabulatedRunoffControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedRunoffControl.FirstColumnMinimum = 0
        Me.TabulatedRunoffControl.FirstRowFixed = False
        Me.TabulatedRunoffControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedRunoffControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedRunoffControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedRunoffControl.Location = New System.Drawing.Point(15, 70)
        Me.TabulatedRunoffControl.MaxRows = 250
        Me.TabulatedRunoffControl.MinRows = 0
        Me.TabulatedRunoffControl.Name = "TabulatedRunoffControl"
        Me.TabulatedRunoffControl.SecondColumnIncreases = False
        Me.TabulatedRunoffControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedRunoffControl.SecondColumnMinimum = 0
        Me.TabulatedRunoffControl.Size = New System.Drawing.Size(180, 310)
        Me.TabulatedRunoffControl.TabIndex = 2
        Me.TabulatedRunoffControl.TableReadonly = False
        '
        'DownstreamRunoffGroup
        '
        Me.DownstreamRunoffGroup.AccessibleDescription = "Selects whether or not runoff is allowed."
        Me.DownstreamRunoffGroup.AccessibleName = "Downstream Condition"
        Me.DownstreamRunoffGroup.Controls.Add(Me.OpenEndButton)
        Me.DownstreamRunoffGroup.Controls.Add(Me.BlockedEndButton)
        Me.DownstreamRunoffGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownstreamRunoffGroup.Location = New System.Drawing.Point(5, 20)
        Me.DownstreamRunoffGroup.Name = "DownstreamRunoffGroup"
        Me.DownstreamRunoffGroup.Size = New System.Drawing.Size(200, 44)
        Me.DownstreamRunoffGroup.TabIndex = 1
        Me.DownstreamRunoffGroup.TabStop = False
        Me.DownstreamRunoffGroup.Text = "&Downstream Condition"
        '
        'OpenEndButton
        '
        Me.OpenEndButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenEndButton.Location = New System.Drawing.Point(8, 15)
        Me.OpenEndButton.Name = "OpenEndButton"
        Me.OpenEndButton.Size = New System.Drawing.Size(95, 24)
        Me.OpenEndButton.TabIndex = 0
        Me.OpenEndButton.Text = "Open End"
        '
        'BlockedEndButton
        '
        Me.BlockedEndButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockedEndButton.Location = New System.Drawing.Point(109, 15)
        Me.BlockedEndButton.Name = "BlockedEndButton"
        Me.BlockedEndButton.Size = New System.Drawing.Size(87, 24)
        Me.BlockedEndButton.TabIndex = 1
        Me.BlockedEndButton.Text = "Blocked"
        '
        'AverageDepthsLabel
        '
        Me.AverageDepthsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AverageDepthsLabel.Location = New System.Drawing.Point(21, 4)
        Me.AverageDepthsLabel.Name = "AverageDepthsLabel"
        Me.AverageDepthsLabel.Size = New System.Drawing.Size(208, 23)
        Me.AverageDepthsLabel.TabIndex = 1
        Me.AverageDepthsLabel.Text = "Average Depths:"
        Me.AverageDepthsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RunoffDepthControl
        '
        Me.RunoffDepthControl.AccessibleDescription = "Displays average depth of runoff water."
        Me.RunoffDepthControl.AccessibleName = "Runoff Depth"
        Me.RunoffDepthControl.Location = New System.Drawing.Point(200, 48)
        Me.RunoffDepthControl.Name = "RunoffDepthControl"
        Me.RunoffDepthControl.Size = New System.Drawing.Size(64, 23)
        Me.RunoffDepthControl.TabIndex = 5
        Me.RunoffDepthControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InfiltratedDepthControl
        '
        Me.InfiltratedDepthControl.AccessibleDescription = "Displays average depth of water that infiltrated into field as Depth Applied - Ru" & _
            "noff Depth."
        Me.InfiltratedDepthControl.AccessibleName = "Infiltrated Depth"
        Me.InfiltratedDepthControl.Location = New System.Drawing.Point(200, 68)
        Me.InfiltratedDepthControl.Name = "InfiltratedDepthControl"
        Me.InfiltratedDepthControl.Size = New System.Drawing.Size(64, 23)
        Me.InfiltratedDepthControl.TabIndex = 7
        Me.InfiltratedDepthControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DepthAppliedLabel
        '
        Me.DepthAppliedLabel.Location = New System.Drawing.Point(26, 28)
        Me.DepthAppliedLabel.Name = "DepthAppliedLabel"
        Me.DepthAppliedLabel.Size = New System.Drawing.Size(170, 23)
        Me.DepthAppliedLabel.TabIndex = 2
        Me.DepthAppliedLabel.Text = "Depth Applied (Dapp):"
        Me.DepthAppliedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DepthAppliedControl
        '
        Me.DepthAppliedControl.AccessibleDescription = "Displays average depth of water applied to the field."
        Me.DepthAppliedControl.AccessibleName = "Depth Applied"
        Me.DepthAppliedControl.Location = New System.Drawing.Point(200, 28)
        Me.DepthAppliedControl.Name = "DepthAppliedControl"
        Me.DepthAppliedControl.Size = New System.Drawing.Size(64, 23)
        Me.DepthAppliedControl.TabIndex = 3
        Me.DepthAppliedControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EqualsLabel2
        '
        Me.EqualsLabel2.Location = New System.Drawing.Point(17, 68)
        Me.EqualsLabel2.Name = "EqualsLabel2"
        Me.EqualsLabel2.Size = New System.Drawing.Size(16, 23)
        Me.EqualsLabel2.TabIndex = 35
        Me.EqualsLabel2.Text = "="
        Me.EqualsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InfiltratedDepthLabel
        '
        Me.InfiltratedDepthLabel.Location = New System.Drawing.Point(37, 68)
        Me.InfiltratedDepthLabel.Name = "InfiltratedDepthLabel"
        Me.InfiltratedDepthLabel.Size = New System.Drawing.Size(159, 23)
        Me.InfiltratedDepthLabel.TabIndex = 6
        Me.InfiltratedDepthLabel.Text = "Depth Infiltrated (Dinf):"
        Me.InfiltratedDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MinusLabel
        '
        Me.MinusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinusLabel.Location = New System.Drawing.Point(17, 49)
        Me.MinusLabel.Name = "MinusLabel"
        Me.MinusLabel.Size = New System.Drawing.Size(16, 23)
        Me.MinusLabel.TabIndex = 37
        Me.MinusLabel.Text = "-"
        Me.MinusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RunoffDepthLabel
        '
        Me.RunoffDepthLabel.Location = New System.Drawing.Point(37, 48)
        Me.RunoffDepthLabel.Name = "RunoffDepthLabel"
        Me.RunoffDepthLabel.Size = New System.Drawing.Size(159, 23)
        Me.RunoffDepthLabel.TabIndex = 4
        Me.RunoffDepthLabel.Text = "Runoff (Dro):"
        Me.RunoffDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InflowRunoffStatsPanel
        '
        Me.InflowRunoffStatsPanel.Controls.Add(Me.RunoffDepthLabel)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.MinusLabel)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.InfiltratedDepthLabel)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.EqualsLabel2)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.DepthAppliedControl)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.DepthAppliedLabel)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.InfiltratedDepthControl)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.RunoffDepthControl)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.AverageDepthsLabel)
        Me.InflowRunoffStatsPanel.Location = New System.Drawing.Point(226, 158)
        Me.InflowRunoffStatsPanel.Name = "InflowRunoffStatsPanel"
        Me.InflowRunoffStatsPanel.Size = New System.Drawing.Size(549, 96)
        Me.InflowRunoffStatsPanel.TabIndex = 4
        '
        'RunoffInstructions
        '
        Me.RunoffInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.RunoffInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.RunoffInstructions.Location = New System.Drawing.Point(226, 260)
        Me.RunoffInstructions.Name = "RunoffInstructions"
        Me.RunoffInstructions.ReadOnly = True
        Me.RunoffInstructions.Size = New System.Drawing.Size(546, 156)
        Me.RunoffInstructions.TabIndex = 5
        Me.RunoffInstructions.Text = ""
        '
        'ctl_Runoff
        '
        Me.Controls.Add(Me.RunoffInstructions)
        Me.Controls.Add(Me.HydrographGraphicsPanel)
        Me.Controls.Add(Me.RunoffLabel)
        Me.Controls.Add(Me.RunoffGroupBox)
        Me.Controls.Add(Me.InflowRunoffStatsPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_Runoff"
        Me.Size = New System.Drawing.Size(780, 422)
        Me.HydrographGraphicsPanel.ResumeLayout(False)
        CType(Me.RunoffHydrograph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RunoffGroupBox.ResumeLayout(False)
        CType(Me.TabulatedRunoffControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DownstreamRunoffGroup.ResumeLayout(False)
        Me.InflowRunoffStatsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' References to model objects
    '
    Private mUnit As Unit = Nothing
    Private mWorld As World = Nothing
    Private mField As Field = Nothing
    Private mFarm As Farm = Nothing
    Private mDictionary As Dictionary = Nothing
    Private mMyStore As DataStore.ObjectNode = Nothing

    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Private WithEvents mSystemGeometry As SystemGeometry = Nothing
    Private WithEvents mInflowManagement As InflowManagement = Nothing
    Private WithEvents mEventCriteria As EventCriteria = Nothing

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    '
    ' Establish links to model objects and update UI
    '
    Public Sub LinkToModel(ByVal _unit As Unit)

        Debug.Assert(_unit IsNot Nothing)

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mEventCriteria = mUnit.EventCriteriaRef

        mDictionary = Dictionary.Instance
        mMyStore = mUnit.MyStore

        ' Link the contained controls to their models & store
        Me.OpenEndButton.LinkToModel(mMyStore, mSystemGeometry.DownstreamConditionProperty, DownstreamConditions.OpenEnd)
        Me.BlockedEndButton.LinkToModel(mMyStore, mSystemGeometry.DownstreamConditionProperty, DownstreamConditions.BlockedEnd)

        ' Tabulated Runoff control
        Me.TabulatedRunoffControl.LinkToModel(mMyStore, mInflowManagement.TabulatedRunoffProperty)
        Me.TabulatedRunoffControl.UpdateUI()

        ' Update language translation
        UpdateLanguage()

        ' Update this control's User Interface
        UpdateUI()

    End Sub
    '
    ' Update UI when System Geometry changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when Inflow Management values change
    '
    Private Sub InflowManagement_PropertyChanged(ByVal _reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when Event Criteria values change
    '
    Private Sub EventCriteria_PropertyChanged(ByVal _reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI graphics when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateGraphics()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Public Sub UpdateUI()
        ' Update the UI only if it is linked to a model object
        If (mUnit IsNot Nothing) Then
            UpdateCrossSection()
            UpdateRunoff()

            UpdateInstructions()
            UpdateGraphics()
        End If
    End Sub
    '
    ' Update the display of the Cross Section related UI
    '
    Private Sub UpdateCrossSection()
        Dim _crossSection As String = mSystemGeometry.CrossSectionName()
        Me.RunoffLabel.Text = _crossSection
    End Sub
    '
    ' Update display of Runoff table
    '
    Private Sub UpdateRunoff()

        ' Can't have Runoff if downstream end is blocked
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
            TabulatedRunoffControl.Hide()
        ElseIf Not (mInflowManagement.RunoffMeasured.Value) Then
            TabulatedRunoffControl.Hide()
        Else
            TabulatedRunoffControl.Show()

            ' Validate Runoff table
            Dim runoff As Double = mInflowManagement.RunoffVolume
            If (runoff = 0) Then
                ErrorProvider.SetError(TabulatedRunoffControl, mDictionary.tErrNoRunoff.Translated)
            Else
                Dim runoffTable As DataTable = mInflowManagement.TabulatedRunoff.Value
                If Not (runoffTable Is Nothing) Then
                    Dim rowCount As Integer = runoffTable.Rows.Count
                    If (0 < rowCount) Then
                        Dim firstRunoff As Double = CDbl(runoffTable.Rows(0).Item(sRunoffX))
                        Dim lastRunoff As Double = CDbl(runoffTable.Rows(rowCount - 1).Item(sRunoffX))

                        If Not (0 = firstRunoff) Then
                            ErrorProvider.SetError(TabulatedRunoffControl, mDictionary.tErrFirstRunoffNotZero.Translated)
                            'ElseIf Not (0 = lastRunoff) Then
                            '    ErrorProvider.SetError(TabulatedRunoffControl, mDictionary.tErrLastRunoffNotZero.Translated)
                        Else
                            ErrorProvider.SetError(TabulatedRunoffControl, "")
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    '
    ' Update instructions for entering inflow/runoff data
    '
    Private Sub UpdateInstructions()
        RunoffInstructions.Clear()
        RunoffInstructions.SelectionAlignment = HorizontalAlignment.Left

        AppendBoldText(RunoffInstructions, mDictionary.tRunoff.Translated)

        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
            AppendText(RunoffInstructions, " (" & mDictionary.tBlockedEnd.Translated & ") - ")
            AppendLine(RunoffInstructions, mDictionary.tRunoffBlockedInstructions.Translated)
        Else
            AppendText(RunoffInstructions, " (" & mDictionary.tOpenEnd.Translated & ") - ")
            AppendLine(RunoffInstructions, mDictionary.tRunoffOpenVerification.Translated)

            If Not (mInflowManagement.RunoffDataAvailable) Then
                AdvanceLine(RunoffInstructions)
                AppendBoldText(RunoffInstructions, mDictionary.tWarning.Translated)
                AppendLine(RunoffInstructions, " - " & mDictionary.tVolumeBalanceWoRunoff.Translated)

                If Not (mInflowManagement.RunoffMeasured.Value) Then
                    AdvanceLine(RunoffInstructions)
                    AppendLine(RunoffInstructions, mDictionary.tIfRunoffDataAvailable.Translated)
                End If
            End If
        End If

    End Sub
    '
    ' Make sure the graphics are up to date whenever they become visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        If (Visible) Then
            UpdateGraphics()
        End If
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " Inflow Management Graphics "
    '
    ' Update the Inflow Management graphics
    '
    Private Sub UpdateGraphics()

        If (mUnit IsNot Nothing) Then
            ' Enclose all graphics code in Try Catch block to ignore exceptions
            Try
                Select Case mInflowManagement.InflowMethod.Value

                    Case InflowMethods.TabulatedInflow
                        Dim _tabulatedInflow As DataTable = mInflowManagement.TabulatedInflow.Value
                        GraphTabulatedInflow(RunoffHydrograph, _tabulatedInflow)

                    Case Else ' Assume InflowMethods.StandardHydrograph
                        GraphHydrograph(RunoffHydrograph)
                End Select

            Catch ex As Exception
                ' Ignore exceptions
            End Try
        End If

    End Sub
    '
    ' Graphics for Standard Hydrograph
    '
    Private Sub GraphHydrograph(ByVal _pictureBox As PictureBox)

        ' Get the Hydrograph values
        Dim _length As Double = mSystemGeometry.Length.Value
        Dim _width As Double = mSystemGeometry.Width.Value

        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
            _width = mSystemGeometry.FurrowSpacing.Value
        End If

        Dim _inflowRate As Double = mInflowManagement.InflowRate.Value
        Dim _cutbackRate As Double = _inflowRate * mInflowManagement.CutbackRateRatio.Value

        Dim _cutoffTime As Double = mInflowManagement.CutoffTime.Value
        Dim _cutbackTime As Double = _cutoffTime * mInflowManagement.CutbackTimeRatio.Value

        Dim _cutoffLocation As Double = _length * mInflowManagement.CutoffLocationRatio.Value
        Dim _cutbackLocation As Double = _length * mInflowManagement.CutbackLocationRatio.Value

        Dim _cutbackMethod As CutbackMethods = CType(mInflowManagement.CutbackMethod.Value, CutbackMethods)
        Dim _cutoffMethod As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)

        Dim _appliedVolume As Double = mInflowManagement.AppliedVolume
        Dim _averageInflowRate As Double = _appliedVolume / _cutoffTime

        Dim _infiltratedVolume As Double = mInflowManagement.InfiltratedVolume

        ' Tabulated Runoff may be available but not enabled
        Dim _tabulatedRunoff As DataTable = Nothing
        Dim _runoffVolume As Double = 0.0
        Dim _maxRunoffTime As Double = 0.0
        Dim _maxRunoff As Double = 0.0
        If (mInflowManagement.RunoffDataAvailable) Then
            _tabulatedRunoff = mInflowManagement.TabulatedRunoff.Value
            _maxRunoffTime = DataColumnMax(_tabulatedRunoff, nTimeX)
            _maxRunoff = DataColumnMax(_tabulatedRunoff, nRunoffX)
            _runoffVolume = mInflowManagement.RunoffVolume
        End If

        Dim _maxTime As Double = MathMax(_cutoffTime, _maxRunoffTime)
        Dim _maxFlowRate As Double = MathMax(_inflowRate, _maxRunoff)

        Dim _volumeLabel As String = String.Empty
        Dim _avgInflowLabel As String = String.Empty

        ' Get drawing tools
        Dim _black As Pen = BlackPen1()
        Dim _grayBrush As SolidBrush = DarkGraySolidBrush()

        ' Highlight color is halfway between White and Background colors
        Dim _r As Integer = CInt((Color.White.R / 2) + (Me.BackColor.R / 2))
        Dim _g As Integer = CInt((Color.White.G / 2) + (Me.BackColor.G / 2))
        Dim _b As Integer = CInt((Color.White.B / 2) + (Me.BackColor.B / 2))
        Dim _highlight As Brush = New SolidBrush(Color.FromArgb(_r, _g, _b))

        ' Create a bitmap for the graphics
        Dim _bitmap As Bitmap = New Bitmap(_pictureBox.Width, _pictureBox.Height)
        Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

        ' Fill the bitmap with the background color
        _graphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, _pictureBox.Width, _pictureBox.Height)
        '
        ' Define & draw the Axes for the Hydrograph
        '
        Dim _offset As Integer = 16 ' Offset into bitmap for axes
        Dim _quadrant As QuadrantSelections = QuadrantSelections.UpperRight

        ' X-axis information (Time)
        Dim _xAxis As Axis

        ' Y-axis information (Flow Rate)
        Dim _yAxis As Axis
        _yAxis.AxisLabel = mDictionary.tFlowRate.Translated
        _yAxis.MaxValue = _maxFlowRate

        If (mInflowManagement.InflowRateProperty.ToBeCalculated) Then
            _yAxis.MaxLabel = "TBD"
        Else
            _yAxis.MaxLabel = FlowRateString(_maxFlowRate, 0)
        End If
        '
        ' Define & draw the Hydrograph 'curve'
        '
        Dim x1, x2 As Double
        Dim _xPoints As ArrayList = New ArrayList
        Dim _yPoints As ArrayList = New ArrayList

        ' Graphics is dependent on the Cutback & Cutoff methods
        Select Case _cutoffMethod

            Case Globals.CutoffMethods.TimeBased

                Select Case _cutbackMethod

                    Case CutbackMethods.NoCutback
                        x1 = 0.0

                    Case CutbackMethods.TimeBased
                        x1 = _cutbackTime

                    Case CutbackMethods.DistanceBased
                        x1 = _cutoffTime * 0.5

                End Select

                x2 = _cutoffTime

                ' Define X axis
                _xAxis.AxisLabel = mDictionary.tTime.Translated
                _xAxis.MaxValue = _maxTime

                If (mInflowManagement.CutoffTimeProperty.ToBeCalculated) Then
                    _xAxis.MaxLabel = "TBD"
                Else
                    _xAxis.MaxLabel = TimeString(_maxTime, 0)
                End If

            Case Else ' Assume distance based

                Select Case _cutbackMethod

                    Case CutbackMethods.NoCutback
                        x1 = 0.0

                    Case CutbackMethods.TimeBased
                        x1 = 0.0

                    Case CutbackMethods.DistanceBased
                        x1 = _cutbackLocation

                End Select

                x2 = _cutoffLocation

                ' Define X axis
                _xAxis.AxisLabel = mDictionary.tDistance.Translated
                _xAxis.MaxValue = _length

                If (mInflowManagement.Unit.SystemGeometryRef.LengthProperty.ToBeCalculated) Then
                    _xAxis.MaxLabel = "TBD"
                Else
                    _xAxis.MaxLabel = mInflowManagement.Unit.SystemGeometryRef.Length.ValueString
                End If

        End Select

        DrawAxes(_bitmap, _quadrant, _xAxis, _yAxis, _offset, Me.Font)

        _xPoints.Add(0.0)
        _yPoints.Add(_inflowRate * 0.9)

        If (0.0 < x1) Then
            _xPoints.Add(x1 * 0.97)
            _yPoints.Add(_inflowRate * 0.9)

            _xPoints.Add(x1 * 0.97)
            _yPoints.Add(_cutbackRate * 0.9)
        End If

        _xPoints.Add(x2 * 0.97)
        _yPoints.Add(_yPoints(_yPoints.Count - 1))

        _xPoints.Add(x2 * 0.97)
        _yPoints.Add(0.0)

        ' Draw the Hydrograph
        If ((_cutoffMethod = Globals.CutoffMethods.TimeBased) _
          And (_cutbackMethod = Globals.CutbackMethods.DistanceBased)) Then
            Dim _x1 As Double = CDbl(_xPoints(1)) * 0.9
            Dim _y1 As Double = CDbl(_yPoints(1))
            Dim _x2 As Double = CDbl(_xPoints(2)) * 1.1
            Dim _y2 As Double = CDbl(_yPoints(2))
            FillRect(_bitmap, _quadrant, _highlight, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
            DrawRect(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
        End If

        If (1 < _yPoints.Count) Then
            For _line As Integer = 0 To _yPoints.Count - 2
                Dim _x1 As Double = CDbl(_xPoints(_line))
                Dim _y1 As Double = CDbl(_yPoints(_line))
                Dim _x2 As Double = CDbl(_xPoints(_line + 1))
                Dim _y2 As Double = CDbl(_yPoints(_line + 1))
                DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
            Next _line
        End If
        '
        ' Define & draw the Tabulated Runoff 'curve', if there is Runoff
        '
        If Not (_tabulatedRunoff Is Nothing) Then
            If (0 < _tabulatedRunoff.Rows.Count) Then

                _xPoints.Clear()
                _yPoints.Clear()

                Dim _time1 As Double = CDbl(_tabulatedRunoff.Rows(0).Item(nTimeX))
                Dim _flow1 As Double = CDbl(_tabulatedRunoff.Rows(0).Item(nInflowX))

                _xPoints.Add(_time1 * 0.97)
                _yPoints.Add(_flow1 * 0.9)

                For _idx As Integer = 1 To _tabulatedRunoff.Rows.Count - 1

                    Dim _time2 As Double = CDbl(_tabulatedRunoff.Rows(_idx).Item(nTimeX))
                    Dim _flow2 As Double = CDbl(_tabulatedRunoff.Rows(_idx).Item(nInflowX))

                    _xPoints.Add(_time2 * 0.97)
                    _yPoints.Add(_flow2 * 0.9)

                    _time1 = _time2
                    _flow1 = _flow2
                Next

                If Not (0.0 = _flow1) Then
                    _xPoints.Add(_time1 * 0.97)
                    _yPoints.Add(0.0 * 0.9)
                End If

                For _line As Integer = 0 To _yPoints.Count - 2
                    Dim _x1 As Double = CDbl(_xPoints(_line))
                    Dim _y1 As Double = CDbl(_yPoints(_line))
                    Dim _x2 As Double = CDbl(_xPoints(_line + 1))
                    Dim _y2 As Double = CDbl(_yPoints(_line + 1))
                    DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
                Next _line
            End If
        End If
        '
        ' Update the Inflow-Outflow Mass Balance data
        '
        DepthAppliedControl.Text = "TBD"

        Dim _area As Double = mSystemGeometry.Area

        If (0 < _area) Then
            If Not (mSystemGeometry.LengthProperty.ToBeCalculated) Then
                If Not (mSystemGeometry.WidthProperty.ToBeCalculated) Then

                    Dim _appliedDepth As Double = _appliedVolume / _area
                    If (0 < _appliedDepth) Then
                        DepthAppliedControl.Text = DepthString(_appliedDepth, 0)
                    Else
                        DepthAppliedControl.Text = "N/A"
                    End If

                    Dim _runoffDepth As Double = _runoffVolume / _area
                    Dim _infiltratedDepth As Double = _infiltratedVolume / _area
                    If (0 < _runoffDepth) Then
                        RunoffDepthControl.Text = DepthString(_runoffDepth, 0)
                        InfiltratedDepthControl.Text = DepthString(_infiltratedDepth, 0)
                    Else
                        RunoffDepthControl.Text = "N/A"
                        InfiltratedDepthControl.Text = "N/A"
                    End If
                End If
            End If
        End If
        '
        ' Add water volume data to graph
        '
        If (_xAxis.MaxLabel = "TBD") Then
            _volumeLabel = mDictionary.tInflow.Translated + ": TBD"
            _avgInflowLabel = "Qavg: TBD"
        Else
            If (0.0 < _appliedVolume) Then
                _volumeLabel = mDictionary.tInflow.Translated + ": " + FieldVolumeString(_appliedVolume, 0)

                If (0.0 < _runoffVolume) Then
                    _volumeLabel += " ;  " + mDictionary.tRunoff.Translated + ": " + FieldVolumeString(_runoffVolume, 0)
                End If

                _avgInflowLabel = "Qavg: " + FlowRateString(_averageInflowRate, 0)
            End If
        End If

        Dim _size As SizeF = _graphics.MeasureString(_volumeLabel, Me.Font)
        _graphics.DrawString(_volumeLabel, Me.Font, _grayBrush, _
                            _bitmap.Width - _size.Width + 6, 0)

        If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            If Not (_avgInflowLabel Is Nothing) Then
                _size = _graphics.MeasureString(_avgInflowLabel, Me.Font)
                _graphics.DrawString(_avgInflowLabel, Me.Font, _grayBrush, _
                                    _offset + 16, _bitmap.Height - (3 * _size.Height))
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
    '
    ' Graphics for Tabulated Inflow
    '
    Private Sub GraphTabulatedInflow(ByVal _pictureBox As PictureBox, ByVal _tabulatedInflow As DataTable)

        ' Get the Tabulated Inflow values
        Dim _length As Double = mSystemGeometry.Length.Value
        Dim _width As Double = mSystemGeometry.Width.Value

        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
            _width = mSystemGeometry.FurrowSpacing.Value
        End If

        Dim _maxInflowTime As Double = DataColumnMax(_tabulatedInflow, nTimeX)
        Dim _maxInflow As Double = DataColumnMax(_tabulatedInflow, nInflowX)

        Dim _infiltratedVolume As Double = mInflowManagement.InfiltratedVolume

        ' Inflow data may be available but not enabled
        Dim _appliedVolume As Double = mInflowManagement.AppliedVolume
        Dim _averageInflowRate As Double = _appliedVolume / _maxInflowTime

        ' Tabulated Runoff may be available but not enabled
        Dim _tabulatedRunoff As DataTable = Nothing
        Dim _maxRunoffTime As Double = 0.0
        Dim _maxRunoff As Double = 0.0
        Dim _runoffVolume As Double = 0.0
        If (mInflowManagement.RunoffDataAvailable) Then
            _tabulatedRunoff = mInflowManagement.TabulatedRunoff.Value
            _maxRunoffTime = DataColumnMax(_tabulatedRunoff, nTimeX)
            _maxRunoff = DataColumnMax(_tabulatedRunoff, nRunoffX)
            _runoffVolume = mInflowManagement.RunoffVolume
        End If

        Dim _maxTime As Double = MathMax(_maxInflowTime, _maxRunoffTime)
        Dim _maxFlowRate As Double = MathMax(_maxInflow, _maxRunoff)

        ' Get drawing tools
        Dim _black As Pen = BlackPen1()
        Dim _grayBrush As SolidBrush = DarkGraySolidBrush()

        ' Create a bitmap for the graphics
        Dim _bitmap As Bitmap = New Bitmap(_pictureBox.Width, _pictureBox.Height)
        Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

        ' Fill the bitmap with the background color
        _graphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, _pictureBox.Width, _pictureBox.Height)
        '
        ' Define & draw the Axes for the Hydrograph
        '
        Dim _offset As Integer = 16 ' Offset into bitmap for axes
        Dim _quadrant As QuadrantSelections = QuadrantSelections.UpperRight

        ' X-axis information (Time)
        Dim _xAxis As Axis
        _xAxis.AxisLabel = mDictionary.tTime.Translated
        _xAxis.MaxValue = _maxTime
        _xAxis.MaxLabel = TimeString(_maxTime, 0)

        ' Y-axis information (Inflow Rate)
        Dim _yAxis As Axis
        _yAxis.AxisLabel = mDictionary.tFlowRate.Translated
        _yAxis.MaxValue = _maxFlowRate
        _yAxis.MaxLabel = FlowRateString(_maxFlowRate, 0)

        DrawAxes(_bitmap, _quadrant, _xAxis, _yAxis, _offset, Me.Font)
        '
        ' Define & draw the Tabulated Inflow 'curve'
        '
        Dim _xPoints As ArrayList = New ArrayList
        Dim _yPoints As ArrayList = New ArrayList

        Dim _time1 As Double
        Dim _flow1 As Double

        If Not (_tabulatedInflow Is Nothing) Then

            _time1 = CDbl(_tabulatedInflow.Rows(0).Item(nTimeX))
            _flow1 = CDbl(_tabulatedInflow.Rows(0).Item(nInflowX))

            _xPoints.Add(_time1 * 0.97)
            _yPoints.Add(_flow1 * 0.9)

            For _idx As Integer = 1 To _tabulatedInflow.Rows.Count - 1

                Dim _time2 As Double = CDbl(_tabulatedInflow.Rows(_idx).Item(nTimeX))
                Dim _flow2 As Double = CDbl(_tabulatedInflow.Rows(_idx).Item(nInflowX))

                _xPoints.Add(_time2 * 0.97)
                _yPoints.Add(_flow2 * 0.9)

                _time1 = _time2
                _flow1 = _flow2
            Next
        End If

        If Not (0.0 = _flow1) Then
            _xPoints.Add(_time1 * 0.97)
            _yPoints.Add(0.0 * 0.9)
        End If

        For _line As Integer = 0 To _yPoints.Count - 2
            Dim _x1 As Double = CDbl(_xPoints(_line))
            Dim _y1 As Double = CDbl(_yPoints(_line))
            Dim _x2 As Double = CDbl(_xPoints(_line + 1))
            Dim _y2 As Double = CDbl(_yPoints(_line + 1))
            DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
        Next _line
        '
        ' Define & draw the Tabulated Runoff 'curve', if there is Runoff
        '
        If Not (_tabulatedRunoff Is Nothing) Then
            If (0 < _tabulatedRunoff.Rows.Count) Then

                _xPoints.Clear()
                _yPoints.Clear()

                _time1 = CDbl(_tabulatedRunoff.Rows(0).Item(nTimeX))
                _flow1 = CDbl(_tabulatedRunoff.Rows(0).Item(nInflowX))

                _xPoints.Add(_time1 * 0.97)
                _yPoints.Add(_flow1 * 0.9)

                For _idx As Integer = 1 To _tabulatedRunoff.Rows.Count - 1

                    Dim _time2 As Double = CDbl(_tabulatedRunoff.Rows(_idx).Item(nTimeX))
                    Dim _flow2 As Double = CDbl(_tabulatedRunoff.Rows(_idx).Item(nInflowX))

                    _xPoints.Add(_time2 * 0.97)
                    _yPoints.Add(_flow2 * 0.9)

                    _time1 = _time2
                    _flow1 = _flow2
                Next

                If Not (0.0 = _flow1) Then
                    _xPoints.Add(_time1 * 0.97)
                    _yPoints.Add(0.0 * 0.9)
                End If

                For _line As Integer = 0 To _yPoints.Count - 2
                    Dim _x1 As Double = CDbl(_xPoints(_line))
                    Dim _y1 As Double = CDbl(_yPoints(_line))
                    Dim _x2 As Double = CDbl(_xPoints(_line + 1))
                    Dim _y2 As Double = CDbl(_yPoints(_line + 1))
                    DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
                Next _line
            End If
        End If
        '
        ' Update the Inflow-Outflow Mass Balance data
        '
        DepthAppliedControl.Text = "TBD"

        Dim _area As Double = mSystemGeometry.Area

        If (0 < _area) Then
            If Not (mSystemGeometry.LengthProperty.ToBeCalculated) Then
                If Not (mSystemGeometry.WidthProperty.ToBeCalculated) Then

                    Dim _appliedDepth As Double = _appliedVolume / _area
                    If (0 < _appliedDepth) Then
                        DepthAppliedControl.Text = DepthString(_appliedDepth, 0)
                    Else
                        DepthAppliedControl.Text = "N/A"
                    End If

                    Dim _runoffDepth As Double = _runoffVolume / _area
                    Dim _infiltratedDepth As Double = _infiltratedVolume / _area
                    If (0 < _runoffDepth) Then
                        RunoffDepthControl.Text = DepthString(_runoffDepth, 0)
                        InfiltratedDepthControl.Text = DepthString(_infiltratedDepth, 0)
                    Else
                        RunoffDepthControl.Text = "N/A"
                        InfiltratedDepthControl.Text = "N/A"
                    End If
                End If
            End If
        End If
        '
        ' Add water volume data to graph
        '
        If (0.0 < _appliedVolume) Then

            Dim _volumeLabel As String = mDictionary.tInflow.Translated + ": " + FieldVolumeString(_appliedVolume, 0)

            If (0.0 < _runoffVolume) Then
                _volumeLabel += " ;  " + mDictionary.tRunoff.Translated + ": " + FieldVolumeString(_runoffVolume, 0)
            End If

            Dim _avgInflowLabel As String = "Qavg: " + FlowRateString(_averageInflowRate, 0)

            Dim _size As SizeF = _graphics.MeasureString(_volumeLabel, Me.Font)
            _graphics.DrawString(_volumeLabel, Me.Font, _grayBrush, _
                                _bitmap.Width - _size.Width + 6, 0)

            _size = _graphics.MeasureString(_avgInflowLabel, Me.Font)
            _graphics.DrawString(_avgInflowLabel, Me.Font, _grayBrush, _
                                _offset + 16, _bitmap.Height - (3 * _size.Height))
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

#End Region

#Region " UI Event Handlers "

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        '
        ' Adjust contained controls to match new height & width
        '

        ' Runoff
        Me.RunoffGroupBox.Height = Me.Height - Me.RunoffGroupBox.Location.Y - 5
        Me.TabulatedRunoffControl.Height = Me.RunoffGroupBox.Height - Me.TabulatedRunoffControl.Location.Y - 5 - 5

        ' Graph
        Dim graphLoc As Point = New Point(Me.HydrographGraphicsPanel.Location.X, 2)
        Me.HydrographGraphicsPanel.Location = graphLoc

        Dim graphHeight As Integer = ((Me.Height - Me.InflowRunoffStatsPanel.Height) / 2) - 4
        Dim graphWidth As Integer = Me.Width - graphLoc.X

        Me.HydrographGraphicsPanel.Height = graphHeight - 4
        Me.HydrographGraphicsPanel.Width = graphWidth - 3

        Me.RunoffHydrograph.Location = New Point(2, 2)
        Me.RunoffHydrograph.Height = graphHeight - 6
        Me.RunoffHydrograph.Width = graphWidth - 6
        UpdateGraphics()

        ' Statistics (Height is fixed)
        Dim statsLoc As Point = New Point(Me.InflowRunoffStatsPanel.Location.X, graphLoc.Y + graphHeight + 2)
        Me.InflowRunoffStatsPanel.Location = statsLoc
        Me.InflowRunoffStatsPanel.Width = graphWidth

        ' Instructions
        Dim instrLoc As Point = Me.RunoffInstructions.Location
        Me.RunoffInstructions.Location = New Point(instrLoc.X, statsLoc.Y + Me.InflowRunoffStatsPanel.Height + 2)
        Me.RunoffInstructions.Height = graphHeight - 4
        Me.RunoffInstructions.Width = graphWidth - 3

    End Sub

    Private Sub TabulatedRunoffControl_ControlValueChanged() _
    Handles TabulatedRunoffControl.ControlValueChanged
        UpdateUI()
        UpdateGraphics()
    End Sub

#End Region

End Class
