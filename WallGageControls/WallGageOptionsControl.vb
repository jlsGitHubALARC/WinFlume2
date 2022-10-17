
'*************************************************************************************************************
' Class WallGageOptionsControl - UserControl for displaying & editing the Wall Gage Options
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.UnitsDialog    ' Unit conversion support

Public Class WallGageOptionsControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mSection As Flume.SectionType = Nothing
    '
    ' Wall Gage Options data
    '
    Private Const DesiredLines As Integer = 30                  ' Rating Table entries after Smart Range

    Private Class SmartRangeUndoRedo                            ' Smart Range Undo/Redo data
        Public RangeMin As Single
        Public RangeMax As Single
        Public RangeInc As Single
        Public Sub New(ByVal Min As Single, ByVal Max As Single, ByVal Inc As Single)
            Me.RangeMin = Min
            Me.RangeMax = Max
            Me.RangeInc = Inc
        End Sub
    End Class

#End Region

#Region " Data Methods "

    Public Sub ValidateDischargeSmartRange(ByVal Flume As FlumeType)

        If (Flume IsNot Nothing) Then

            Dim Qmin As Single = Flume.WGageQMin
            Dim Qmax As Single = Flume.WGageQMax
            Dim Qinc As Single = Flume.WGageQInc

            If ((Qmin <= 0) And (Qmax <= 0) And (Qinc <= 0)) Then
                Flume.SmartRange(Qmin, Qmax, Qinc, QHTable, DesiredLines, False)
                Flume.WGageQMin = Qmin
                Flume.WGageQMax = Qmax
                Flume.WGageQInc = Qinc
            End If
        End If

    End Sub

    Public Sub ValidateHeadSmartRange(ByVal Flume As FlumeType)

        If (Flume IsNot Nothing) Then

            Dim Hmin As Single = Flume.WGageHMin
            Dim Hmax As Single = Flume.WGageHMax
            Dim Hinc As Single = Flume.WGageHInc

            If ((Hmin <= 0) And (Hmax <= 0) And (Hinc <= 0)) Then
                Flume.SmartRange(Hmin, Hmax, Hinc, HQTable, DesiredLines, False)
                Flume.WGageHMin = Hmin
                Flume.WGageHMax = Hmax
                Flume.WGageHInc = Hinc
            End If
        End If

    End Sub

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Rating Table Choices
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume data
        If ((mFlume Is Nothing) Or (Not (Me.Visible))) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Debug.Assert(False)
            Return
        End If
        mUpdatingUI = True

        ' Update Fixed-Discharge Interval parameters
        Me.MinimumDischargeLabel.Enabled = EnableDischarge.Value
        Me.MinimumDischargeSingle.Enabled = EnableDischarge.Value
        Me.MaximumDischargeLabel.Enabled = EnableDischarge.Value
        Me.MaximumDischargeSingle.Enabled = EnableDischarge.Value
        Me.DischargeIncrementLabel.Enabled = EnableDischarge.Value
        Me.DischargeIncrementSingle.Enabled = EnableDischarge.Value
        Me.DischargeSmartRangeButton.Enabled = EnableDischarge.Value

        Me.MinimumDischargeSingle.SiUnits = DischargeUnitsAbbreviations(0)
        Me.MinimumDischargeSingle.SiValue = mFlume.WGageQMin
        Me.MinimumDischargeSingle.Label = Me.MinimumDischargeLabel.Text

        Me.MaximumDischargeSingle.SiUnits = DischargeUnitsAbbreviations(0)
        Me.MaximumDischargeSingle.SiValue = mFlume.WGageQMax
        Me.MaximumDischargeSingle.Label = Me.MaximumDischargeLabel.Text

        Me.DischargeIncrementSingle.SiUnits = DischargeUnitsAbbreviations(0)
        Me.DischargeIncrementSingle.SiValue = mFlume.WGageQInc
        Me.DischargeIncrementSingle.Label = Me.DischargeIncrementLabel.Text

        ' Update Fixed-Head Interval parameters
        Me.MinimumHeadLabel.Enabled = EnableHead.Value
        Me.MinimumHeadSingle.Enabled = EnableHead.Value
        Me.MaximumHeadLabel.Enabled = EnableHead.Value
        Me.MaximumHeadSingle.Enabled = EnableHead.Value
        Me.HeadIncrementLabel.Enabled = EnableHead.Value
        Me.HeadIncrementSingle.Enabled = EnableHead.Value
        Me.HeadSmartRangeButton.Enabled = EnableHead.Value

        Me.MinimumHeadSingle.SiUnits = LengthUnitsAbbreviations(0)
        Me.MinimumHeadSingle.SiValue = mFlume.WGageHMin
        Me.MinimumHeadSingle.Label = Me.MinimumHeadLabel.Text

        Me.MaximumHeadSingle.SiUnits = LengthUnitsAbbreviations(0)
        Me.MaximumHeadSingle.SiValue = mFlume.WGageHMax
        Me.MaximumHeadSingle.Label = Me.MaximumHeadLabel.Text

        Me.HeadIncrementSingle.SiUnits = LengthUnitsAbbreviations(0)
        Me.HeadIncrementSingle.SiValue = mFlume.WGageHInc
        Me.HeadIncrementSingle.Label = Me.HeadIncrementLabel.Text

        ' Update Wall Gage Options
        Me.SillReferencedButton.Label = Me.GageReferenceGroup.Text
        Me.SillReferencedButton.RbValue = 0
        Me.SillReferencedButton.UiValue = mFlume.WGageRef

        Me.UpstreamChannellBottomButton.Label = Me.GageReferenceGroup.Text
        Me.UpstreamChannellBottomButton.RbValue = 1
        Me.UpstreamChannellBottomButton.UiValue = mFlume.WGageRef

        Me.GageSlopeSingle.SiUnits = ""
        Me.GageSlopeSingle.SiValue = mFlume.WGageZ
        Me.GageSlopeSingle.Label = "Z"

        mUpdatingUI = False
    End Sub

#End Region

#Region " Event Handlers "

#Region " Wall Gage Options "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    Private Sub MyBase_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub SillReferencedButton_ValueChanged(NewValue As Integer) _
        Handles SillReferencedButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageRef = NewValue) Then
                mFlume.WGageRef = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub UpstreamChannellBottomButton_ValueChanged(NewValue As Integer) _
        Handles UpstreamChannellBottomButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageRef = NewValue) Then
                mFlume.WGageRef = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub GageSlopeSingle_ValueChanged() _
        Handles GageSlopeSingle.ValueChanged
        Dim GageZ As Single = Me.GageSlopeSingle.SiValue
        If Not (mFlume.WGageZ = GageZ) Then
            mFlume.WGageZ = GageZ
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

#End Region

#Region " Fixed-Head Interval "

    Private Sub EnableHead_CheckedChanged(sender As Object, e As EventArgs) _
        Handles EnableHead.CheckedChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub MinimumHeadRange_ValueChanged() Handles MinimumHeadSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hmin As Single = Me.MinimumHeadSingle.SiValue
            If Not (mFlume.WGageHMin = Hmin) Then
                mFlume.WGageHMin = Hmin
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MaximumHeadRange_ValueChanged() Handles MaximumHeadSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hmax As Single = Me.MaximumHeadSingle.SiValue
            If Not (mFlume.WGageHMax = Hmax) Then
                mFlume.WGageHMax = Hmax
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub HeadIncrementSingle_ValueChanged() Handles HeadIncrementSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hinc As Single = Me.HeadIncrementSingle.SiValue
            If Not (mFlume.WGageHInc = Hinc) Then
                mFlume.WGageHInc = Hinc
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Button event handlers - Click, UndoButtonEvent, RedoButtonEvent
    '
    ' Note - Undo/Redo handling is specific to each Button since the action taken is not known to ctl_Button.
    '*********************************************************************************************************
    Private Sub HeadSmartRangeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles HeadSmartRangeButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Set current selections as Undo point
            Dim Hmin As Single = mFlume.WGageHMin
            Dim Hmax As Single = mFlume.WGageHMax
            Dim Hinc As Single = mFlume.WGageHInc
            Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
            HeadSmartRangeButton.AddUndoItem(SmartRangeUndo)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
            ' Set Smart Range values
            mFlume.SmartRange(Hmin, Hmax, Hinc, HQTable, DesiredLines, True)
            mFlume.WGageHMin = Hmin
            mFlume.WGageHMax = Hmax
            mFlume.WGageHInc = Hinc

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub HeadSmartRangeButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles HeadSmartRangeButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(SmartRangeUndoRedo)) Then
                ' Set current selections as Redo point
                Dim Hmin As Single = mFlume.WGageHMin
                Dim Hmax As Single = mFlume.WGageHMax
                Dim Hinc As Single = mFlume.WGageHInc
                Dim SmartRangeRedo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
                HeadSmartRangeButton.AddRedoItem(SmartRangeRedo)
                ' Get Undo point's selections
                Dim SmartRangeUndo As SmartRangeUndoRedo = DirectCast(UndoValue, SmartRangeUndoRedo)
                ' Restore range parameters
                mFlume.WGageHMin = SmartRangeUndo.RangeMin
                mFlume.WGageHMax = SmartRangeUndo.RangeMax
                mFlume.WGageHInc = SmartRangeUndo.RangeInc

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub HeadSmartRangeButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles HeadSmartRangeButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(SmartRangeUndoRedo)) Then
                ' Set current selections as Undo point
                Dim Hmin As Single = mFlume.WGageHMin
                Dim Hmax As Single = mFlume.WGageHMax
                Dim Hinc As Single = mFlume.WGageHInc
                Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
                HeadSmartRangeButton.AddUndoItem(SmartRangeUndo)
                ' Get Redo point's selections
                Dim SmartRangeRedo As SmartRangeUndoRedo = DirectCast(RedoValue, SmartRangeUndoRedo)
                ' Restore range parameters
                mFlume.WGageHMin = SmartRangeRedo.RangeMin
                mFlume.WGageHMax = SmartRangeRedo.RangeMax
                mFlume.WGageHInc = SmartRangeRedo.RangeInc

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#Region " Fixed-Discharge Interval "

    Private Sub EnableDischarge_CheckedChanged(sender As Object, e As EventArgs) _
        Handles EnableDischarge.CheckedChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub MinimumDischargeRange_ValueChanged() Handles MinimumDischargeSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hmin As Single = Me.MinimumDischargeSingle.SiValue
            If Not (mFlume.WGageQMin = Hmin) Then
                mFlume.WGageQMin = Hmin
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MaximumDischargeRange_ValueChanged() Handles MaximumDischargeSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hmax As Single = Me.MaximumDischargeSingle.SiValue
            If Not (mFlume.WGageQMax = Hmax) Then
                mFlume.WGageQMax = Hmax
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DischargeIncrementSingle_ValueChanged() Handles DischargeIncrementSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hinc As Single = Me.DischargeIncrementSingle.SiValue
            If Not (mFlume.WGageQInc = Hinc) Then
                mFlume.WGageQInc = Hinc
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Button event handlers - Click, UndoButtonEvent, RedoButtonEvent
    '
    ' Note - Undo/Redo handling is specific to each Button since the action taken is not known to ctl_Button.
    '*********************************************************************************************************
    Private Sub DischargeSmartRangeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles DischargeSmartRangeButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Set current selections as Undo point
            Dim Qmin As Single = mFlume.WGageQMin
            Dim Qmax As Single = mFlume.WGageQMax
            Dim Qinc As Single = mFlume.WGageQInc
            Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Qmin, Qmax, Qinc)
            DischargeSmartRangeButton.AddUndoItem(SmartRangeUndo)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
            ' Set Smart Range values
            mFlume.SmartRange(Qmin, Qmax, Qinc, QHTable, DesiredLines, True)
            mFlume.WGageQMin = Qmin
            mFlume.WGageQMax = Qmax
            mFlume.WGageQInc = Qinc

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub DischargeSmartRangeButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles DischargeSmartRangeButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(SmartRangeUndoRedo)) Then
                ' Set current selections as Redo point
                Dim Qmin As Single = mFlume.WGageQMin
                Dim Qmax As Single = mFlume.WGageQMax
                Dim Qinc As Single = mFlume.WGageQInc
                Dim SmartRangeRedo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Qmin, Qmax, Qinc)
                DischargeSmartRangeButton.AddRedoItem(SmartRangeRedo)
                ' Get Undo point's selections
                Dim SmartRangeUndo As SmartRangeUndoRedo = DirectCast(UndoValue, SmartRangeUndoRedo)
                ' Restore range parameters
                mFlume.WGageQMin = SmartRangeUndo.RangeMin
                mFlume.WGageQMax = SmartRangeUndo.RangeMax
                mFlume.WGageQInc = SmartRangeUndo.RangeInc

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub DischargeSmartRangeButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles DischargeSmartRangeButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(SmartRangeUndoRedo)) Then
                ' Set current selections as Undo point
                Dim Qmin As Single = mFlume.WGageQMin
                Dim Qmax As Single = mFlume.WGageQMax
                Dim Qinc As Single = mFlume.WGageQInc
                Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Qmin, Qmax, Qinc)
                DischargeSmartRangeButton.AddUndoItem(SmartRangeUndo)
                ' Get Redo point's selections
                Dim SmartRangeRedo As SmartRangeUndoRedo = DirectCast(RedoValue, SmartRangeUndoRedo)
                ' Restore range parameters
                mFlume.WGageQMin = SmartRangeRedo.RangeMin
                mFlume.WGageQMax = SmartRangeRedo.RangeMax
                mFlume.WGageQInc = SmartRangeRedo.RangeInc

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#End Region

End Class
