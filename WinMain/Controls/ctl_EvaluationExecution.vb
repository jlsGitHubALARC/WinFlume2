
'*************************************************************************************************************
' ctl_EvaluationExecution - Evaluation World's Execution Tab UI
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_EvaluationExecution
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
    Friend WithEvents RunControlBox As DataStore.ctl_GroupBox
    Friend WithEvents SolutionModelBox As DataStore.ctl_GroupBox
    Friend WithEvents CellDensityLabel As DataStore.ctl_Label
    Friend WithEvents CellDensityControl As DataStore.ctl_IntegerParameter
    Friend WithEvents SolutionModelControl As DataStore.ctl_SelectParameter
    Friend WithEvents ExecutionErrorsWarnings As WinMain.ErrorRichTextBox
    Friend WithEvents NoErrorsWarningsLabel As DataStore.ctl_Label
    Friend WithEvents ErrorsWarningsLabel As DataStore.ctl_Label
    Friend WithEvents RunAnalysisButton As DataStore.ctl_Button
    Friend WithEvents VerifyNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents EnableDiagnosticsControl As DataStore.ctl_CheckParameter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RunControlBox = New DataStore.ctl_GroupBox
        Me.SolutionModelBox = New DataStore.ctl_GroupBox
        Me.VerifyNotes = New System.Windows.Forms.RichTextBox
        Me.EnableDiagnosticsControl = New DataStore.ctl_CheckParameter
        Me.CellDensityLabel = New DataStore.ctl_Label
        Me.CellDensityControl = New DataStore.ctl_IntegerParameter
        Me.SolutionModelControl = New DataStore.ctl_SelectParameter
        Me.ExecutionErrorsWarnings = New WinMain.ErrorRichTextBox
        Me.NoErrorsWarningsLabel = New DataStore.ctl_Label
        Me.ErrorsWarningsLabel = New DataStore.ctl_Label
        Me.RunAnalysisButton = New DataStore.ctl_Button
        Me.RunControlBox.SuspendLayout()
        Me.SolutionModelBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'RunControlBox
        '
        Me.RunControlBox.AccessibleDescription = "Controls for verifying an irrigation evaluation."
        Me.RunControlBox.AccessibleName = "Run Control"
        Me.RunControlBox.Controls.Add(Me.SolutionModelBox)
        Me.RunControlBox.Controls.Add(Me.ExecutionErrorsWarnings)
        Me.RunControlBox.Controls.Add(Me.NoErrorsWarningsLabel)
        Me.RunControlBox.Controls.Add(Me.ErrorsWarningsLabel)
        Me.RunControlBox.Controls.Add(Me.RunAnalysisButton)
        Me.RunControlBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunControlBox.Location = New System.Drawing.Point(4, 6)
        Me.RunControlBox.Name = "RunControlBox"
        Me.RunControlBox.Size = New System.Drawing.Size(758, 414)
        Me.RunControlBox.TabIndex = 1
        Me.RunControlBox.TabStop = False
        Me.RunControlBox.Text = "Run Control"
        '
        'SolutionModelBox
        '
        Me.SolutionModelBox.AccessibleDescription = "Select the simulation model and parameters to use when verifying an evaluation."
        Me.SolutionModelBox.AccessibleName = "Simulation Solution Model"
        Me.SolutionModelBox.Controls.Add(Me.VerifyNotes)
        Me.SolutionModelBox.Controls.Add(Me.EnableDiagnosticsControl)
        Me.SolutionModelBox.Controls.Add(Me.CellDensityLabel)
        Me.SolutionModelBox.Controls.Add(Me.CellDensityControl)
        Me.SolutionModelBox.Controls.Add(Me.SolutionModelControl)
        Me.SolutionModelBox.Location = New System.Drawing.Point(10, 19)
        Me.SolutionModelBox.Name = "SolutionModelBox"
        Me.SolutionModelBox.Size = New System.Drawing.Size(742, 103)
        Me.SolutionModelBox.TabIndex = 0
        Me.SolutionModelBox.TabStop = False
        Me.SolutionModelBox.Text = "Simulation S&olution Model"
        '
        'VerifyNotes
        '
        Me.VerifyNotes.BackColor = System.Drawing.SystemColors.Info
        Me.VerifyNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VerifyNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VerifyNotes.ForeColor = System.Drawing.SystemColors.InfoText
        Me.VerifyNotes.Location = New System.Drawing.Point(317, 21)
        Me.VerifyNotes.Margin = New System.Windows.Forms.Padding(4)
        Me.VerifyNotes.Name = "VerifyNotes"
        Me.VerifyNotes.ReadOnly = True
        Me.VerifyNotes.Size = New System.Drawing.Size(418, 75)
        Me.VerifyNotes.TabIndex = 4
        Me.VerifyNotes.TabStop = False
        Me.VerifyNotes.Text = ""
        '
        'EnableDiagnosticsControl
        '
        Me.EnableDiagnosticsControl.AlwaysChecked = False
        Me.EnableDiagnosticsControl.AutoSize = True
        Me.EnableDiagnosticsControl.ErrorMessage = Nothing
        Me.EnableDiagnosticsControl.Location = New System.Drawing.Point(16, 77)
        Me.EnableDiagnosticsControl.Name = "EnableDiagnosticsControl"
        Me.EnableDiagnosticsControl.Size = New System.Drawing.Size(166, 21)
        Me.EnableDiagnosticsControl.TabIndex = 3
        Me.EnableDiagnosticsControl.Text = "E&nable Diagnostics"
        Me.EnableDiagnosticsControl.UncheckAttemptMessage = Nothing
        Me.EnableDiagnosticsControl.UseVisualStyleBackColor = True
        '
        'CellDensityLabel
        '
        Me.CellDensityLabel.Location = New System.Drawing.Point(15, 50)
        Me.CellDensityLabel.Name = "CellDensityLabel"
        Me.CellDensityLabel.Size = New System.Drawing.Size(96, 23)
        Me.CellDensityLabel.TabIndex = 1
        Me.CellDensityLabel.Text = "&Cell Density"
        Me.CellDensityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CellDensityControl
        '
        Me.CellDensityControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CellDensityControl.IsCalculated = False
        Me.CellDensityControl.Location = New System.Drawing.Point(112, 50)
        Me.CellDensityControl.Name = "CellDensityControl"
        Me.CellDensityControl.Size = New System.Drawing.Size(104, 24)
        Me.CellDensityControl.TabIndex = 2
        Me.CellDensityControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CellDensityControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CellDensityControl.ValueText = ""
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
        Me.SolutionModelControl.Location = New System.Drawing.Point(15, 22)
        Me.SolutionModelControl.Name = "SolutionModelControl"
        Me.SolutionModelControl.SelectedIndexSet = False
        Me.SolutionModelControl.Size = New System.Drawing.Size(295, 24)
        Me.SolutionModelControl.TabIndex = 0
        '
        'ExecutionErrorsWarnings
        '
        Me.ExecutionErrorsWarnings.AccessibleDescription = "Display of any errors and/or warnings occuring during the evaluation."
        Me.ExecutionErrorsWarnings.AccessibleName = "Errors and Warnings"
        Me.ExecutionErrorsWarnings.Location = New System.Drawing.Point(10, 176)
        Me.ExecutionErrorsWarnings.Name = "ExecutionErrorsWarnings"
        Me.ExecutionErrorsWarnings.ReadOnly = True
        Me.ExecutionErrorsWarnings.Size = New System.Drawing.Size(742, 232)
        Me.ExecutionErrorsWarnings.TabIndex = 2
        Me.ExecutionErrorsWarnings.Text = ""
        '
        'NoErrorsWarningsLabel
        '
        Me.NoErrorsWarningsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoErrorsWarningsLabel.Location = New System.Drawing.Point(10, 184)
        Me.NoErrorsWarningsLabel.Name = "NoErrorsWarningsLabel"
        Me.NoErrorsWarningsLabel.Size = New System.Drawing.Size(325, 23)
        Me.NoErrorsWarningsLabel.TabIndex = 3
        Me.NoErrorsWarningsLabel.Text = "None"
        Me.NoErrorsWarningsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorsWarningsLabel
        '
        Me.ErrorsWarningsLabel.BackColor = System.Drawing.SystemColors.Control
        Me.ErrorsWarningsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErrorsWarningsLabel.Location = New System.Drawing.Point(10, 152)
        Me.ErrorsWarningsLabel.Name = "ErrorsWarningsLabel"
        Me.ErrorsWarningsLabel.Size = New System.Drawing.Size(325, 24)
        Me.ErrorsWarningsLabel.TabIndex = 1
        Me.ErrorsWarningsLabel.Text = "Errors and Warnings"
        Me.ErrorsWarningsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RunAnalysisButton
        '
        Me.RunAnalysisButton.AccessibleDescription = "Press to summarize and and verify the irrigation event analysis."
        Me.RunAnalysisButton.AccessibleName = "Run Button"
        Me.RunAnalysisButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RunAnalysisButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RunAnalysisButton.Location = New System.Drawing.Point(40, 128)
        Me.RunAnalysisButton.Name = "RunAnalysisButton"
        Me.RunAnalysisButton.Size = New System.Drawing.Size(264, 23)
        Me.RunAnalysisButton.TabIndex = 0
        Me.RunAnalysisButton.Text = "&Verify and Summarize Analysis"
        Me.RunAnalysisButton.UseVisualStyleBackColor = False
        '
        'ctl_EvaluationExecution
        '
        Me.Controls.Add(Me.RunControlBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_EvaluationExecution"
        Me.Size = New System.Drawing.Size(780, 427)
        Me.RunControlBox.ResumeLayout(False)
        Me.SolutionModelBox.ResumeLayout(False)
        Me.SolutionModelBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "
    '
    ' Model / Analysis references passed or derived via initialization
    '
    Private WithEvents mEventCriteria As EventCriteria
    '
    ' Supported analyses
    '
    Private mInfiltratedProfile As InfiltratedProfile
    Private mMerriamKeller As MerriamKeller
    Private mElliotWalker As ElliotWalkerTwoPoint
    Private mEvalueAnalysis As EVALUE

#End Region

#Region " Properties "
    '
    ' Currently Selected Analysis
    '
    Public ReadOnly Property CurrentAnalysis() As EventAnalysis
        Get
            Dim _analysis As EventAnalysis = Nothing

            If (mEventCriteria IsNot Nothing) Then
                Select Case (mEventCriteria.EventAnalysisType.Value)
                    Case EventAnalysisTypes.InfiltratedProfileAnalysis
                        _analysis = mInfiltratedProfile
                    Case EventAnalysisTypes.MerriamKellerAnalysis
                        _analysis = mMerriamKeller
                    Case EventAnalysisTypes.TwoPointAnalysis
                        _analysis = mElliotWalker
                    Case EventAnalysisTypes.EvalueAnalysis
                        _analysis = mEvalueAnalysis
                End Select
            End If

            Return _analysis
        End Get
    End Property

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
    Private WithEvents mSubsurfaceFlow As SubsurfaceFlow

    Private WithEvents mSrfrCriteria As SrfrCriteria

    Private mEvaluationWorld As EvaluationWorld

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Public Sub LinkToModel(ByVal MyUnit As Unit, ByVal MyWorld As EvaluationWorld)

        Debug.Assert(MyUnit IsNot Nothing, "Unit is Nothing")
        Debug.Assert(MyWorld IsNot Nothing, "Design World is Nothing")

        ' Link this control to its data model and store
        mUnit = MyUnit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mSubsurfaceFlow = mUnit.SubsurfaceFlowRef

        mSrfrCriteria = mUnit.SrfrCriteriaRef

        mEvaluationWorld = MyWorld

        mMyStore = mUnit.MyStore
        mDictionary = Dictionary.Instance

        ' Get Evaluation World specific references
        mEventCriteria = mUnit.EventCriteriaRef

        ' Instantiate Analyses objects
        mInfiltratedProfile = New InfiltratedProfile(mUnit, mEvaluationWorld)
        mMerriamKeller = New MerriamKeller(mUnit, mEvaluationWorld)
        mElliotWalker = New ElliotWalkerTwoPoint(mUnit, mEvaluationWorld)
        mEvalueAnalysis = New EVALUE(mUnit, mEvaluationWorld)

        ' Link contained controls to their models & store
        Me.SolutionModelControl.LinkToModel(mMyStore, mSrfrCriteria.SolutionModelProperty)
        Me.CellDensityControl.LinkToModel(mMyStore, mSrfrCriteria.CellDensityProperty)
        Me.EnableDiagnosticsControl.LinkToModel(mMyStore, mSrfrCriteria.EnableDiagnosticsProperty)

        Me.SolutionModelControl.LinkToModel(mMyStore, mSrfrCriteria.SolutionModelProperty)
        Me.CellDensityControl.LinkToModel(mMyStore, mSrfrCriteria.CellDensityProperty)

        ' Update language translation
        UpdateLanguage()

        ' Update the control's User Interface
        UpdateUI()

    End Sub

#End Region

#Region " Update UI Methods "

#Region " System Type "
    '
    ' Update Solution Model selection list & selection
    '
    Private Sub UpdateSolutionModel()
        If (mSrfrCriteria IsNot Nothing) Then
            Dim _simModel As Integer = mSrfrCriteria.SolutionModel.Value

            ' Enable / disable access to SRFR controls
            Select Case (WinSRFR.UserLevel)
                Case UserLevels.Standard
                    ' Solution Model & Cell Density always set for Standard User
                    Me.SolutionModelControl.IsCalculated = True
                    Me.CellDensityControl.IsCalculated = True
                    Me.EnableDiagnosticsControl.Visible = False
                Case UserLevels.Advanced
                    ' Solution Model & Cell Density always available for Advanced User
                    Me.SolutionModelControl.IsCalculated = False
                    Me.CellDensityControl.IsCalculated = False
                    Me.EnableDiagnosticsControl.Visible = False
                Case Else ' Research
                    ' Solution Model & Cell Density always available for Research
                    Me.SolutionModelControl.IsCalculated = False
                    Me.CellDensityControl.IsCalculated = False
                    Me.EnableDiagnosticsControl.Visible = True
            End Select

            If (WinSRFR.DebuggerIsAttached) Then
                Me.EnableDiagnosticsControl.Visible = True
            End If

            ' Update selection list
            Dim _sel As String = String.Empty
            Dim _idx As Integer = 0

            Me.SolutionModelControl.Clear()

            Dim _selOk As Boolean = mSrfrCriteria.GetFirstSolutionModelSelection(_sel)
            While (_sel IsNot Nothing)
                If (_selOk) Then
                    Me.SolutionModelControl.Add(_sel, _idx, True)
                ElseIf (_simModel = _idx) Then
                    Me.SolutionModelControl.Add(_sel, _idx, False)
                End If
                _selOk = mSrfrCriteria.GetNextSolutionModelSelection(_sel)
                _idx += 1
            End While

            ' Update controls
            Me.SolutionModelControl.UpdateUI()
            Me.CellDensityControl.UpdateUI()
        End If
    End Sub

#End Region

#Region " Event Analysis "
    '
    ' Update the Event Analysis World's UI
    '
    Public Sub UpdateUI()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mEvaluationWorld.ResetingTabs) Then ' Evaluation World is reseting tab pages; wait
            Return
        End If

        If (mEventCriteria IsNot Nothing) Then
            '
            ' Set the UI to match the selected criteria
            '
            Select Case (mEventCriteria.EventAnalysisType.Value)

                Case EventAnalysisTypes.InfiltratedProfileAnalysis
                    Me.RunAnalysisButton.Text = "&" & mDictionary.tSummarizeAnalysis.Translated
                    Me.SolutionModelBox.Hide()

                    UpdateResultsControls(mInfiltratedProfile)

                Case EventAnalysisTypes.MerriamKellerAnalysis
                    Me.RunAnalysisButton.Text = "&" & mDictionary.tVerifySummarizeAnalysis.Translated
                    Me.SolutionModelBox.Show()

                    UpdateResultsControls(mMerriamKeller)

                Case EventAnalysisTypes.TwoPointAnalysis
                    Me.RunAnalysisButton.Text = "&" & mDictionary.tVerifySummarizeAnalysis.Translated
                    Me.SolutionModelBox.Show()

                    UpdateResultsControls(mElliotWalker)

                Case EventAnalysisTypes.EvalueAnalysis
                    Me.RunAnalysisButton.Text = "&" & mDictionary.tVerifySummarizeAnalysis.Translated
                    Me.SolutionModelBox.Show()

                    UpdateResultsControls(mEvalueAnalysis)

                Case Else
                    Debug.Assert(False) ' Support for the Event Analysis Type must be added
            End Select

            Me.VerifyNotes.Clear()
            Me.VerifyNotes.SelectionAlignment = HorizontalAlignment.Left
            AppendLine(Me.VerifyNotes, mDictionary.tVerifyNotes.Translated)

            UpdateSolutionModel()
        End If

    End Sub
    '
    ' Update the Results Control (Icons, Buttons, etc.)
    '
    Public Sub UpdateResultsControls(ByVal _analysis As Analysis)

        If (mUnit IsNot Nothing) Then

            UpdateEvaluationSetupErrorsWarnings(_analysis)

            If (_analysis IsNot Nothing) Then
                If (_analysis.HasSetupErrors) Then
                    ' There are errors; disable Run & Verify buttons
                    Me.RunAnalysisButton.BackColor = SystemColors.Control
                    Me.RunAnalysisButton.ForeColor = SystemColors.ControlText

                    Me.RunAnalysisButton.Enabled = False
                Else
                    ' There are no errors; enable appropriate buttons
                    Me.RunAnalysisButton.BackColor = SystemColors.ActiveCaption
                    Me.RunAnalysisButton.ForeColor = SystemColors.ActiveCaptionText

                    Me.RunAnalysisButton.Enabled = True
                End If
            End If
        End If

    End Sub
    '
    ' Update the UI's Event Analysis Criteria
    '
    Private Sub AddEventExecutionErrorWarning(ByVal _type As String, _
                                              ByVal _title As String, _
                                              ByVal _details As String)

        Dim _richTextBox As RichTextBox = CType(ExecutionErrorsWarnings, RichTextBox)

        AppendBoldLine(_richTextBox, _type + ":")
        AdvanceLine(_richTextBox)
        AppendLine(_richTextBox, _title)
        AdvanceLine(_richTextBox)
        AppendLine(_richTextBox, _details)
        AdvanceLine(_richTextBox)

    End Sub

    Private Sub AddEventExecutionWarning(ByVal _title As String, ByVal _details As String)
        AddEventExecutionErrorWarning(mDictionary.tWarning.Translated, _title, _details)
    End Sub

    Private Sub AddEventExecutionError(ByVal _title As String, ByVal _details As String)
        AddEventExecutionErrorWarning(mDictionary.tError.Translated, _title, _details)
    End Sub

    Private Sub UpdateEvaluationSetupErrorsWarnings(ByVal analysis As Analysis)
        If ((mUnit IsNot Nothing) And (analysis IsNot Nothing)) Then
            ' Check Analysis errors & warnings
            analysis.UpdateSetupErrorsAndWarnings()

            ' Display Evaluation errors & warnings
            Me.ExecutionErrorsWarnings.Clear()

            If (analysis.HasSetupErrorsOrWarnings) Then
                Me.ExecutionErrorsWarnings.DisplayErrorsAndWarnings(analysis, True)
                Me.ExecutionErrorsWarnings.Show()
            ElseIf (mUnit.ResultsAreValid) Then
                Me.ExecutionErrorsWarnings.DisplayWarning(mDictionary.tAnalysisHasAlreadyBeenRunID.Translated, _
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

#End Region

#Region " UI Event Handlers "

    Private Sub SolutionModelControl_ControlValueChanged() _
    Handles SolutionModelControl.ControlValueChanged
        ' Solution Model changes can effect Cell Density & FILFT
        mSrfrCriteria.CheckCellDensity(CellDensities.Medium)
        Me.UpdateUI()
    End Sub

    Private Sub CellDensityControl_ControlValueChanged() _
    Handles CellDensityControl.ControlValueChanged
        Me.UpdateUI()
    End Sub

    Private Sub RunAnalysisButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunAnalysisButton.Click
        Me.Focus()
        mEvaluationWorld.RunEventAnalysis()
    End Sub

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        Try
            ' Adjust control heights
            Me.RunControlBox.Height = Me.Height - 9

            Me.ExecutionErrorsWarnings.Height = Me.RunControlBox.Height - Me.ExecutionErrorsWarnings.Location.Y - 8

            ' Adjust Run Control widths
            Dim ctrlWidth As Integer = Me.Width - Me.RunControlBox.Location.X - 4

            Me.RunControlBox.Width = ctrlWidth

            ctrlWidth -= 2 * Me.SolutionModelBox.Location.X

            Me.SolutionModelBox.Width = ctrlWidth
            Me.ErrorsWarningsLabel.Width = ctrlWidth
            Me.ExecutionErrorsWarnings.Width = ctrlWidth
            Me.NoErrorsWarningsLabel.Width = ctrlWidth

            Me.VerifyNotes.Width = Me.SolutionModelBox.Width - Me.VerifyNotes.Location.X - 9

            Me.RunAnalysisButton.Location = New Point((Me.RunControlBox.Width - Me.RunAnalysisButton.Width) / 2, _
                                                      Me.RunAnalysisButton.Location.Y)

        Catch ex As Exception
        End Try

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
