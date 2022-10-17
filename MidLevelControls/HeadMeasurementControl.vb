
'*************************************************************************************************************
' Class HeadMeasurementControl - UserControl for displaying & editing the Head Measurement method
'*************************************************************************************************************
Imports WinFlume.UnitsDialog    ' Unit conversion support
Imports WinFlume.WinFlumeForm

Public Class HeadMeasurementControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume data
    '
    Private mFlume As Flume.FlumeType = Nothing
    '
    ' Head Measurement Control data
    '
    Private mIncrementUnitsOrder As TimeUnits() = {TimeUnits.Seconds, _
                                                   TimeUnits.Minutes, _
                                                   TimeUnits.Hours, _
                                                   TimeUnits.Days}
#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Head Measurement method
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume data
        If (mFlume Is Nothing) Then ' can't update without Flume data
            Return
        End If

        If Not (Me.Visible) Then ' only update when control is visible
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive call(s)
            Return
        End If
        mUpdatingUI = True

        ' Update Head Measurement Type selections
        Me.StandardButton.Label = My.Resources.StandardCustom
        Me.StandardButton.RbValue = WinFlumeForm.StandardCustomChoices.Standard

        Me.CustomButton.Label = My.Resources.StandardCustom
        Me.CustomButton.RbValue = WinFlumeForm.StandardCustomChoices.Custom

        ' Update Head Measurement method
        Dim standardType As Boolean = False
        Dim gageDesc As String = mFlume.GageDescription.Trim
        Dim gageError As Single = mFlume.GageError
        Dim defaultError As Single = WinFlumeForm.DefaultFlume.GageError

        ' If necessary, initialize Standard Head Measurement Method
        If (0 = Me.StandardMethodComboBox.Items.Count) Then
            Me.StandardMethodComboBox.Items.Add(My.Resources.PointGage)
            Me.StandardMethodComboBox.Items.Add(My.Resources.Dipstick)
            Me.StandardMethodComboBox.Items.Add(My.Resources.StaffFrLow & (0.1).ToString)
            Me.StandardMethodComboBox.Items.Add(My.Resources.StaffInStillFrMed & (0.2).ToString)
            Me.StandardMethodComboBox.Items.Add(My.Resources.StaffInStillFrHigh & (0.5).ToString)
            Me.StandardMethodComboBox.Items.Add(My.Resources.StaffNoStillFrMed & (0.2).ToString)
            Me.StandardMethodComboBox.Items.Add(My.Resources.StaffNoStillFrHigh & (0.5).ToString)
            Me.StandardMethodComboBox.Items.Add(My.Resources.PressureBuld)
            Me.StandardMethodComboBox.Items.Add(My.Resources.BubbleGage)
            Me.StandardMethodComboBox.Items.Add(My.Resources.FloatRecorder)

            Me.StandardExpectedUncertainty.SiDefaultValue = defaultError
            Me.StandardExpectedUncertainty.SiValue = gageError
            Me.StandardExpectedUncertainty.SingleText.ReadOnly = True
        End If

        ' Update Standard Head Measurement selections
        For mdx As Integer = 0 To Me.StandardMethodComboBox.Items.Count - 1
            Dim method As String = CStr(Me.StandardMethodComboBox.Items(mdx))
            If (method = gageDesc) Then
                Me.CustomMethodTextBox.Enabled = False
                Me.CustomExpectedUncertainty.Enabled = False

                Me.StandardMethodComboBox.Enabled = True
                Me.StandardExpectedUncertainty.Enabled = True

                Me.StandardMethodComboBox.Value = mdx
                Me.StandardMethodComboBox.DefaultValue = GageDescriptions.StaffInStillFrMed

                Me.StandardExpectedUncertainty.SiDefaultValue = defaultError
                Me.StandardExpectedUncertainty.SiValue = gageError

                Me.StandardButton.UiValue = WinFlumeForm.StandardCustomChoices.Standard
                Me.CustomButton.UiValue = WinFlumeForm.StandardCustomChoices.Standard

                standardType = True
                Exit For
            End If
        Next mdx

        ' Update Custom measurement method
        If Not (standardType) Then
            Me.StandardMethodComboBox.Enabled = False
            Me.StandardExpectedUncertainty.Enabled = False

            Me.CustomMethodTextBox.Enabled = True
            Me.CustomExpectedUncertainty.Enabled = True

            Me.CustomMethodTextBox.Label = My.Resources.CustomMethod
            Me.CustomMethodTextBox.Text = gageDesc
            Me.CustomExpectedUncertainty.SiDefaultValue = defaultError
            Me.CustomExpectedUncertainty.SiValue = gageError

            Me.StandardButton.UiValue = WinFlumeForm.StandardCustomChoices.Custom
            Me.CustomButton.UiValue = WinFlumeForm.StandardCustomChoices.Custom
        End If

        ' Update Allowable Flow Measurement Uncertainty
        Me.AtMinimumFlow.SiDefaultValue = WinFlumeForm.DefaultFlume.ErrAtMinQ
        Me.AtMinimumFlow.SiValue = mFlume.ErrAtMinQ

        Me.AtMaximumFlow.SiDefaultValue = WinFlumeForm.DefaultFlume.ErrAtMaxQ
        Me.AtMaximumFlow.SiValue = mFlume.ErrAtMaxQ

        ' Update Totalizing or Averaging
        Me.MeasurementInterval.SiDefaultValue = WinFlumeForm.DefaultFlume.MeasurementInterval
        Me.MeasurementInterval.SiValue = mFlume.MeasurementInterval

        Me.Duration.SiDefaultValue = WinFlumeForm.DefaultFlume.TotalizerDuration
        Me.Duration.SiValue = mFlume.TotalizerDuration

        Me.MeasurementIntervalUnits.Items.Clear()
        Me.DurationUnits.Items.Clear()
        For Each IncUnits As TimeUnits In mIncrementUnitsOrder
            Me.MeasurementIntervalUnits.Items.Add(TimeUnitsNames(IncUnits))
            Me.DurationUnits.Items.Add(TimeUnitsNames(IncUnits))
        Next IncUnits

        Dim MeasurementUnitsIndex As Integer = mFlume.IntervalUnitIndex
        If (MeasurementUnitsIndex < TimeUnits.Seconds) Then
            MeasurementUnitsIndex = TimeUnits.Seconds
        End If
        If (MeasurementUnitsIndex > TimeUnits.Days) Then
            MeasurementUnitsIndex = TimeUnits.Days
        End If
        Me.MeasurementIntervalUnits.Value = MeasurementUnitsIndex

        Dim DurationUnitsIndex As Integer = mFlume.DurationUnitIndex
        If (DurationUnitsIndex < TimeUnits.Seconds) Then
            DurationUnitsIndex = TimeUnits.Seconds
        End If
        If (DurationUnitsIndex > TimeUnits.Days) Then
            DurationUnitsIndex = TimeUnits.Days
        End If
        Me.DurationUnits.Value = DurationUnitsIndex

        mUpdatingUI = False
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    Private Sub HeadMeasurementControl_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Handle Standard/Custom Head Measurement selection changes
    '*********************************************************************************************************
    Private Sub UpdateStandardCustom(ByVal NewValue As Integer)

        If (NewValue = WinFlumeForm.StandardCustomChoices.Standard) Then
            ' Save new Head Measurement selection
            Dim mdx As Integer = Math.Max(0, Me.StandardMethodComboBox.SelectedIndex)
            mFlume.GageDescription = CStr(Me.StandardMethodComboBox.Items(mdx))
            mFlume.GageError = WinFlumeForm.hError(mdx)
            mWinFlumeForm.RaiseFlumeDataChanged()
        ElseIf (NewValue = WinFlumeForm.StandardCustomChoices.Custom) Then
            ' Check if a custom Head Measurement has been entered
            Dim cstMethod As String = Me.CustomMethodTextBox.Text.Trim
            Dim cstError As Single = Me.CustomExpectedUncertainty.SiValue

            ' Check if custom name matches a standard name
            For mdx As Integer = 0 To Me.StandardMethodComboBox.Items.Count - 1
                Dim stdMethod As String = CStr(Me.StandardMethodComboBox.Items(mdx)).Trim
                If (stdMethod = cstMethod) Then ' match: modify custom name
                    cstMethod &= " [" & My.Resources.Custom.ToLower & "]"
                    Exit For
                End If
            Next mdx

            ' Save new custom Head Measurement selection
            mFlume.GageDescription = cstMethod
            mFlume.GageError = cstError
            mWinFlumeForm.RaiseFlumeDataChanged()
        Else
            Debug.Assert(False)
        End If

    End Sub

    ' Standard method selection
    Private Sub StandardButton_ValueChanged(ByVal NewValue As Integer) Handles StandardButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore events during UI update
            If (mUpdatingUI) Then
                Return
            End If
            UpdateStandardCustom(NewValue)
        End If
    End Sub

    Private Sub StandardMethodComboBox_ValueChangedd() Handles StandardMethodComboBox.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore events during UI update
            If (mUpdatingUI) Then
                Return
            End If
            ' Save new Head Measurment selection
            Dim mdx As Integer = Math.Max(0, Me.StandardMethodComboBox.SelectedIndex)
            mFlume.GageDescription = CStr(Me.StandardMethodComboBox.Items(mdx))
            mFlume.GageError = WinFlumeForm.hError(mdx)
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    ' Custom material selection
    Private Sub CustomButton_ValueChanged(ByVal NewValue As Integer) Handles CustomButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore events during UI update
            If (mUpdatingUI) Then
                Return
            End If
            UpdateStandardCustom(NewValue)
        End If
    End Sub

    Private Sub CustomMethodTextBox_ValueChanged() Handles CustomMethodTextBox.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore events during UI update
            If (mUpdatingUI) Then
                Return
            End If

            Dim cstMethod As String = Me.CustomMethodTextBox.Value
            If Not (mFlume.GageDescription = cstMethod) Then ' method changed
                ' Check if custom name matches a standard name
                For mdx As Integer = 0 To Me.StandardMethodComboBox.Items.Count - 1
                    Dim stdMethod As String = CStr(Me.StandardMethodComboBox.Items(mdx)).Trim
                    If (stdMethod = cstMethod) Then ' match: modify custom name
                        cstMethod &= " [" & My.Resources.Custom.ToLower & "]"
                        Exit For
                    End If

                    ' Save new Flume Crest material selection
                    mFlume.GageDescription = cstMethod
                    mWinFlumeForm.RaiseFlumeDataChanged()
                Next mdx
            End If
        End If
    End Sub

    Private Sub CustomExpectedUncertainty_ValueChanged() Handles CustomExpectedUncertainty.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore events during UI update
            If (mUpdatingUI) Then
                Return
            End If
            ' Save new Head Measurement selection
            mFlume.GageError = Me.CustomExpectedUncertainty.SiValue
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub AtMinimumFlow_ValueChanged() Handles AtMinimumFlow.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim atMinFlow As Single = Me.AtMinimumFlow.SiValue
            If Not (mFlume.ErrAtMinQ = atMinFlow) Then
                mFlume.ErrAtMinQ = atMinFlow
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub AtMaximumFlow_ValueChanged() Handles AtMaximumFlow.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim atMaxFlow As Single = Me.AtMaximumFlow.SiValue
            If Not (mFlume.ErrAtMaxQ = atMaxFlow) Then
                mFlume.ErrAtMaxQ = atMaxFlow
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub
    '
    ' Ensure Measurment Interval <= Duration
    '
    Private Sub MeasurementInterval_ValueChanged() Handles MeasurementInterval.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (ValidDurationAndInterval()) Then
                Dim measInterval As Single = Me.MeasurementInterval.SiValue
                If Not (mFlume.MeasurementInterval = measInterval) Then
                    mFlume.MeasurementInterval = measInterval
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            Else
                Dim title As String = My.Resources.IntervalGtDuration
                Dim msg As String = My.Resources.IntervalExceedsDuration & vbCrLf & vbCrLf
                msg &= My.Resources.EditDuration
                Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.OkOnly, title)

                mWinFlumeForm.RemoveLastUndoItem()
                UpdateUI()
            End If
        End If
    End Sub

    Private Sub MeasurementIntervalUnits_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles MeasurementIntervalUnits.SelectedIndexChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (ValidDurationAndInterval()) Then
                Dim measIntervalUnits As Integer = Me.MeasurementIntervalUnits.Value
                If Not (mFlume.IntervalUnitIndex = measIntervalUnits) Then
                    mFlume.IntervalUnitIndex = measIntervalUnits
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            Else
                Dim title As String = My.Resources.IntervalGtDuration
                Dim msg As String = My.Resources.IntervalExceedsDuration & vbCrLf & vbCrLf
                msg &= My.Resources.EditDuration
                Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.OkOnly, title)

                mWinFlumeForm.RemoveLastUndoItem()
                UpdateUI()
            End If
        End If
    End Sub

    Private Sub Duration_ValueChanged() Handles Duration.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (ValidDurationAndInterval()) Then
                Dim duration As Single = Me.Duration.SiValue
                If Not (mFlume.TotalizerDuration = duration) Then
                    mFlume.TotalizerDuration = duration
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            Else
                Dim title As String = My.Resources.IntervalGtDuration
                Dim msg As String = My.Resources.DurationLessThanIteration & vbCrLf & vbCrLf
                msg &= My.Resources.AcceptDuration & vbCrLf & vbCrLf
                msg &= My.Resources.PreserveIntervalDuration
                Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                If (result = MsgBoxResult.Yes) Then
                    Dim duration As Single = Me.Duration.SiValue
                    mFlume.TotalizerDuration = duration
                    mFlume.MeasurementInterval = 1
                    mFlume.IntervalUnitIndex = TimeUnits.Seconds
                    UpdateUI()

                    If Not (ValidDurationAndInterval()) Then
                        mFlume.TotalizerDuration = 1
                        mFlume.DurationUnitIndex = TimeUnits.Seconds
                    End If
                    mWinFlumeForm.RaiseFlumeDataChanged()
                Else
                    mWinFlumeForm.RemoveLastUndoItem()
                    UpdateUI()
                End If
            End If
        End If
    End Sub

    Private Sub DurationUnits_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles DurationUnits.SelectedIndexChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (ValidDurationAndInterval()) Then
                Dim measDurationUnits As Integer = Me.DurationUnits.Value
                If Not (mFlume.DurationUnitIndex = measDurationUnits) Then
                    mFlume.DurationUnitIndex = measDurationUnits
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            Else
                Dim title As String = My.Resources.IntervalGtDuration
                Dim msg As String = My.Resources.DurationLessThanIteration & vbCrLf & vbCrLf
                msg &= My.Resources.AcceptDuration & vbCrLf & vbCrLf
                msg &= My.Resources.PreserveIntervalDuration
                Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                If (result = MsgBoxResult.Yes) Then
                    Dim duration As Single = Me.Duration.SiValue
                    mFlume.TotalizerDuration = duration
                    mFlume.MeasurementInterval = 1
                    mFlume.IntervalUnitIndex = TimeUnits.Seconds
                    mWinFlumeForm.RaiseFlumeDataChanged()
                Else
                    mWinFlumeForm.RemoveLastUndoItem()
                    UpdateUI()
                End If
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Function ValidDurationAndInterval() - check if the Measurement Interval <= Duration
    '*********************************************************************************************************
    Private Function ValidDurationAndInterval() As Boolean
        If Not (mUpdatingUI) Then
            Dim MeasurementUnitsIndex As Integer = Me.MeasurementIntervalUnits.Value
            If (MeasurementUnitsIndex < TimeUnits.Seconds) Then
                MeasurementUnitsIndex = TimeUnits.Seconds
            End If
            If (MeasurementUnitsIndex > TimeUnits.Days) Then
                MeasurementUnitsIndex = TimeUnits.Days
            End If

            Dim MeasurementUnitsValue As Single = Me.MeasurementInterval.SiValue
            Dim MeasurementInterval As Single = MeasurementUnitsValue * SecondsPerUnit(MeasurementUnitsIndex)

            Dim DurationUnitsIndex As Integer = Me.DurationUnits.Value
            If (DurationUnitsIndex < TimeUnits.Seconds) Then
                DurationUnitsIndex = TimeUnits.Seconds
            End If
            If (DurationUnitsIndex > TimeUnits.Days) Then
                DurationUnitsIndex = TimeUnits.Days
            End If

            Dim DurationUnitsValue As Single = Me.Duration.SiValue
            Dim MeasurementDuration As Single = DurationUnitsValue * SecondsPerUnit(DurationUnitsIndex)

            Return (MeasurementInterval < MeasurementDuration)
        Else
            Return True
        End If

    End Function

    '*********************************************************************************************************
    ' Sub HeadMeasurementControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub HeadMeasurementControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize

    End Sub

#End Region

End Class
