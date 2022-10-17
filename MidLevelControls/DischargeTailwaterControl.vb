
'*************************************************************************************************************
' Class DischargeTailwaterControl - UserControl for displaying & editing the range of flume operation and the
'                                   method for tailwater calculations
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Public Class DischargeTailwaterControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mDefaultFlume As Flume.FlumeType = Nothing

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Approach cross section
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Private mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                             ' Flume data
        If (mFlume Is Nothing) Then
            Return
        End If

        If Not (Me.Visible) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Debug.Assert(False)
            Return
        End If
        mUpdatingUI = True

        mDefaultFlume = WinFlumeForm.DefaultFlume

        ' Update Flume Operation controls
        Dim QMin As Single = mFlume.QMin
        Me.MinDischarge.SiDefaultValue = mDefaultFlume.QMin
        Me.MinDischarge.SiValue = QMin
        Me.MinDischarge.SiUnits = WinFlumeForm.SiDischargeUnitsText
        Me.MinDischarge.Label = Me.DischargeLabel.Text

        Dim QMax As Single = mFlume.QMax
        Me.MaxDischarge.SiDefaultValue = mDefaultFlume.QMax
        Me.MaxDischarge.SiValue = QMax
        Me.MaxDischarge.SiUnits = WinFlumeForm.SiDischargeUnitsText
        Me.MaxDischarge.Label = Me.DischargeLabel.Text

        Me.MinTailwaterLevel.SiValue = mFlume.MinTailwater
        Me.MinTailwaterLevel.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.MinTailwaterLevel.Label = Me.TailwaterLevelLabel.Text
        Me.MinTailwaterLevel.SingleText.ReadOnly = True

        Me.MaxTailwaterLevel.SiValue = mFlume.MaxTailwater
        Me.MaxTailwaterLevel.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.MaxTailwaterLevel.Label = Me.TailwaterLevelLabel.Text
        Me.MaxTailwaterLevel.SingleText.ReadOnly = True

        Me.FlumeOperationRangeBox.Refresh()

        ' Update Tailwater Calculations controls
        If (0 = Me.TailwaterMethod.Items.Count) Then
            Me.TailwaterMethod.Items.Add(My.Resources.TailwaterBasisManning)
            Me.TailwaterMethod.Items.Add(My.Resources.TailwaterBasis1QH)
            Me.TailwaterMethod.Items.Add(My.Resources.TailwaterBasis2QHPower)
            Me.TailwaterMethod.Items.Add(My.Resources.TailwaterBasis3QH)
            Me.TailwaterMethod.Items.Add(My.Resources.TailwaterBasisLinearLookupTable)
        End If

        Me.TailwaterMethod.Value = mFlume.TailwaterBasis

        Dim ctrl As Control = Nothing
        Select Case (mFlume.TailwaterBasis)
            Case TailwaterBasis1QH

                Dim basis1QH As BasisManning1QHControl = New BasisManning1QHControl
                ctrl = Me.UpdateTailwaterBasis(basis1QH)

                basis1QH = DirectCast(ctrl, BasisManning1QHControl)
                basis1QH.AccessibleName = My.Resources.TailwaterBasis
                basis1QH.AccessibleDescription = My.Resources.TailwaterBasis1QH
                basis1QH.UpdateUI(mWinFlumeForm)

            Case TailwaterBasis2QHPower

                Dim basis2QH As BasisPower2QHControl = New BasisPower2QHControl
                ctrl = Me.UpdateTailwaterBasis(basis2QH)

                basis2QH = DirectCast(ctrl, BasisPower2QHControl)
                basis2QH.AccessibleName = My.Resources.TailwaterBasis
                basis2QH.AccessibleDescription = My.Resources.TailwaterBasis2QHPower
                basis2QH.UpdateUI(mWinFlumeForm)

            Case TailwaterBasis3QH

                Dim basis3QH As BasisPower3QHControl = New BasisPower3QHControl
                ctrl = Me.UpdateTailwaterBasis(basis3QH)

                basis3QH = DirectCast(ctrl, BasisPower3QHControl)
                basis3QH.AccessibleName = My.Resources.TailwaterBasis
                basis3QH.AccessibleDescription = My.Resources.TailwaterBasis3QH
                basis3QH.UpdateUI(mWinFlumeForm)

            Case TailwaterBasisLinearLookupTable

                Dim linearLookup As BasisLinearLookupControl = New BasisLinearLookupControl
                ctrl = Me.UpdateTailwaterBasis(linearLookup)

                linearLookup = DirectCast(ctrl, BasisLinearLookupControl)
                linearLookup.AccessibleName = My.Resources.TailwaterBasis
                linearLookup.AccessibleDescription = My.Resources.TailwaterBasisLinearLookupTable
                linearLookup.UpdateUI(mWinFlumeForm)

            Case Else ' assume TailwaterBasisManning

                Dim basisManning As BasisManningControl = New BasisManningControl
                ctrl = Me.UpdateTailwaterBasis(basisManning)

                basisManning = DirectCast(ctrl, BasisManningControl)
                basisManning.AccessibleName = My.Resources.TailwaterBasis
                basisManning.AccessibleDescription = My.Resources.TailwaterBasisManning
                basisManning.UpdateUI(mWinFlumeForm)

        End Select

        Me.TailwaterCalculationsBox.Refresh()

        CheckErrors()

        mUpdatingUI = False
    End Sub

    Protected Sub CheckErrors()
        ' Set error message (default to no error)
        Dim ErrMsg As String = ""

        Dim Design As WinFlumeDesign = New WinFlumeDesign
        Dim DesignResult As DesignResultType = New DesignResultType
        Dim EvaluationReport As String = ""
        Dim ErrorSummary As String = ""
        Dim NWarnings As Integer = 0

        Dim evalstr As String
        evalstr = Design.EvaluateFlume(mFlume, DesignResult, EvaluationReport, ErrorSummary, NWarnings, False)

        ' Check Tailwater Levels, y2
        Dim CD As Single = mFlume.ChannelDepth

        Dim y2Qmin As Single = Me.MinTailwaterLevel.SiValue
        If (CD < y2Qmin) Then
            ErrMsg = My.Resources.Y2atQMin & " > " & My.Resources.ChannelDepth
        ElseIf (y2Qmin <= 0) Then
            ErrMsg = My.Resources.InvalidTailwaterLevel
        Else
            ErrMsg = ""
        End If
        Me.MinTailwaterLevel.SetError(ErrMsg)

        Dim y2Qmax As Single = Me.MaxTailwaterLevel.SiValue
        If (CD < y2Qmax) Then
            ErrMsg = My.Resources.Y2atQMax & " > " & My.Resources.ChannelDepth
        ElseIf (y2Qmax <= 0) Then
            ErrMsg = My.Resources.InvalidTailwaterLevel
        Else
            ErrMsg = ""
        End If
        Me.MaxTailwaterLevel.SetError(ErrMsg)

    End Sub

    '*********************************************************************************************************
    ' Sub UpdateTailwaterBasis() - ensure cross section control is being displayed
    '
    ' Input(s):         Ctrl    - control that should be displayed
    '
    ' Returns:          Control - control that is being displayed
    '*********************************************************************************************************
    Protected Function UpdateTailwaterBasis(ByVal Ctrl As Control) As Control

        If (0 = Me.TailwaterBasisPanel.Controls.Count) Then ' No controls are displayed
            Me.TailwaterBasisPanel.Controls.Add(Ctrl) ' Add requested one
        ElseIf (Me.TailwaterBasisPanel.Controls(0).GetType IsNot Ctrl.GetType) Then ' Control is not displayed
            Me.TailwaterBasisPanel.Controls.Clear()   ' Clear current control(s)
            Me.TailwaterBasisPanel.Controls.Add(Ctrl) ' Add requested one
        Else
            Ctrl = Me.TailwaterBasisPanel.Controls(0)
        End If

        Ctrl.Dock = DockStyle.Fill              ' Set styles

        Return Ctrl
    End Function

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub MinDischarge_ValueChanged() Handles MinDischarge.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim minDischarge As Single = Me.MinDischarge.SiValue
            If Not (mFlume.QMin = minDischarge) Then
                mFlume.QMin = minDischarge
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MaxDischarge_ValueChanged() Handles MaxDischarge.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim maxDischarge As Single = Me.MaxDischarge.SiValue
            If Not (mFlume.QMax = maxDischarge) Then
                mFlume.QMax = maxDischarge
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub TailwaterMethod_ValueChanged() Handles TailwaterMethod.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.TailwaterBasis = Me.TailwaterMethod.Value) Then
                mFlume.TailwaterBasis = Me.TailwaterMethod.Value
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub DischargeTailwaterControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub MyBase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize

        Dim loc As Point
        Dim wid As Integer

        ' Size the ComboBox(s)
        Me.FlumeOperationRangeBox.Width = Me.Width - 2 * Me.Margin.Horizontal
        Me.TailwaterCalculationsBox.Width = Me.Width - 2 * Me.Margin.Horizontal
        Me.TailwaterCalculationsBox.Height = Me.Height - Me.FlumeOperationRangeBox.Height - 3 * Me.Margin.Vertical

        loc = Me.TailwaterBasisPanel.Location
        loc.X = Me.Margin.Horizontal
        loc.Y = Me.TailwaterMethod.Location.Y + Me.TailwaterMethod.Height + Me.Margin.Vertical
        Me.TailwaterBasisPanel.Location = loc
        Me.TailwaterBasisPanel.Width = Me.TailwaterCalculationsBox.Width - 2 * Me.Margin.Horizontal
        Me.TailwaterBasisPanel.Height = Me.TailwaterCalculationsBox.Height - loc.Y - Me.Margin.Vertical

        ' Locate Flume Operation controls
        loc = Me.DischargeLabel.Location
        loc.X = CInt(Me.Width / 2) - 2
        Me.DischargeLabel.Location = loc

        loc = Me.MinDischarge.Location
        loc.X = CInt(Me.Width / 2)
        Me.MinDischarge.Location = loc

        loc = Me.MaxDischarge.Location
        loc.X = CInt(Me.Width / 2)
        Me.MaxDischarge.Location = loc

        loc = Me.MinFlowLabel.Location
        loc.X = Me.MinDischarge.Location.X - Me.MinFlowLabel.Width - Me.Margin.Horizontal
        Me.MinFlowLabel.Location = loc

        loc = Me.MaxFlowLabel.Location
        loc.X = Me.MaxDischarge.Location.X - Me.MaxFlowLabel.Width - Me.Margin.Horizontal
        Me.MaxFlowLabel.Location = loc

        wid = Math.Max(Me.DischargeLabel.Width, Me.MinDischarge.Width)
        loc = Me.TailwaterLevelLabel.Location
        loc.X = Me.DischargeLabel.Location.X + wid + 2 * Me.Margin.Horizontal - 4
        Me.TailwaterLevelLabel.Location = loc

        loc = Me.MinTailwaterLevel.Location
        loc.X = Me.DischargeLabel.Location.X + wid + 2 * Me.Margin.Horizontal
        Me.MinTailwaterLevel.Location = loc

        loc = Me.MaxTailwaterLevel.Location
        loc.X = Me.DischargeLabel.Location.X + wid + 2 * Me.Margin.Horizontal
        Me.MaxTailwaterLevel.Location = loc

        ' Size Tailwater Calculations controls
        loc = Me.TailwaterMethod.Location
        Me.TailwaterMethod.Width = Me.TailwaterCalculationsBox.Width - loc.X - 2 * Me.Margin.Horizontal

    End Sub

#End Region

End Class
