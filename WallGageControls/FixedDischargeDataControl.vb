
'*************************************************************************************************************
' Class FixedDischargeDataControl - UserControl for generating the Fixed-Discharge Interval Wall Gage data
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.UnitsDialog    ' Unit conversion support

Public Class FixedDischargeDataControl

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

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display the Fixed-Discharge Interval Wall Gage options & data
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

        ValidateDischargeSmartRange(mFlume)

        Dim Qmin As Single = mFlume.WGageQMin
        Dim Qmax As Single = mFlume.WGageQMax
        Dim Qinc As Single = mFlume.WGageQInc
        Dim P1 As Single = mFlume.SillHeight

        ' Update Fixed-Discharge Interval parameters
        Me.MinimumDischargeSingle.SiUnits = DischargeUnitsAbbreviations(0)
        Me.MinimumDischargeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageQMin
        Me.MinimumDischargeSingle.SiValue = Qmin
        Me.MinimumDischargeSingle.Label = Me.MinimumDischargeLabel.Text

        Me.MaximumDischargeSingle.SiUnits = DischargeUnitsAbbreviations(0)
        Me.MaximumDischargeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageQMax
        Me.MaximumDischargeSingle.SiValue = Qmax
        Me.MaximumDischargeSingle.Label = Me.MaximumDischargeLabel.Text

        Me.DischargeIncrementSingle.SiUnits = DischargeUnitsAbbreviations(0)
        Me.DischargeIncrementSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageQInc
        Me.DischargeIncrementSingle.SiValue = Qinc
        Me.DischargeIncrementSingle.Label = Me.DischargeIncrementLabel.Text

        ' Update Wall Gage Options
        Me.SillReferencedButton.Label = Me.GageReferenceGroup.Text
        Me.SillReferencedButton.RbValue = WallGageRefTopOfSill
        Me.SillReferencedButton.UiValue = mFlume.WGageRef

        Me.UpstreamChannellBottomButton.Label = Me.GageReferenceGroup.Text
        Me.UpstreamChannellBottomButton.RbValue = WallGageRefApproachBottom
        Me.UpstreamChannellBottomButton.UiValue = mFlume.WGageRef

        Me.GageSlopeSingle.SiUnits = ""
        Me.GageSlopeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageZ
        Me.GageSlopeSingle.SiValue = mFlume.WGageZ
        Me.GageSlopeSingle.Label = "Z"

        ' Update Wall Gage data table
        Dim SiLunits As String = SiLengthUnitsText()
        Dim UiLunits As String = UiLengthUnitsText()

        Dim SiQunits As String = SiDischargeUnitsText()
        Dim UiQunits As String = UiDischargeUnitsText()

        Dim headColumnText As String = ""
        Dim distanceColumnText As String = ""
        Dim dischargeColumnText As String = ""
        Dim zRatio As String = mFlume.WGageZ.ToString & ":1 "
        Dim formatStyle As String = "0.000"

        If (mFlume.WGageRef = WallGageRefTopOfSill) Then ' Sill-Referenced
            headColumnText = My.Resources.SillReferenced
            distanceColumnText = My.Resources.SillReferenced
        Else ' Bottom-Referenced
            headColumnText = My.Resources.BottomReferenced
            distanceColumnText = My.Resources.BottomReferenced
        End If

        headColumnText &= vbCrLf & My.Resources.Head & " (" & UiLunits & ")"
        headColumnText &= vbCrLf & My.Resources.Vertical.ToLower

        distanceColumnText &= vbCrLf & My.Resources.Distance & " (" & UiLunits & ")"
        distanceColumnText &= vbCrLf & My.Resources.Slope.ToLower & " " & zRatio

        dischargeColumnText &= vbCrLf & My.Resources.Discharge
        dischargeColumnText &= vbCrLf & "(" & UiQunits & ")"

        Me.FixedDischargeIntervalTable.Columns(0).HeaderText = dischargeColumnText
        Me.FixedDischargeIntervalTable.Columns(1).HeaderText = headColumnText
        Me.FixedDischargeIntervalTable.Columns(2).HeaderText = distanceColumnText

        ' Update Wall Gage table data
        Dim RatingResults(1) As RatingResultsType
        Dim TableErrors(MaxHydErrors) As Boolean
        Dim uiValue As Single = 0

        mFlume.MakeRating(QHTable, False, Qmin, Qmax, Qinc, RatingResults, TableErrors)

        Me.FixedDischargeIntervalTable.Rows.Clear()

        For Each RatingResult As RatingResultsType In RatingResults
            If (RatingResult IsNot Nothing) Then

                Dim rowString(2) As String

                Dim h1 As Single = RatingResult.SMALLh1
                Dim Q As Single = RatingResult.Q

                Dim TotalH As Single = h1
                If (mFlume.WGageRef = WallGageRefApproachBottom) Then ' Bottom-Referenced; add Sill Height
                    TotalH += P1
                End If
                Dim Dist As Single = CSng(TotalH * Math.Sqrt(1 + mFlume.WGageZ ^ 2))

                uiValue = UiDischargeValue(Q, UiDischargeUnits)     ' Discharge
                rowString(0) = Format(uiValue, formatStyle)

                uiValue = UiLengthValue(TotalH, UiLengthUnits)      ' Head
                rowString(1) = Format(uiValue, formatStyle)

                uiValue = UiLengthValue(Dist, UiLengthUnits)        ' Distance
                rowString(2) = Format(uiValue, formatStyle)

                If (RatingResult.FatalError Or RatingResult.NonFatalError) Then
                    rowString(0) &= "*"
                End If

                Me.FixedDischargeIntervalTable.Rows.Add(rowString)

            End If
        Next RatingResult

        ' Update status
        Me.StatusPanel.Title.Text = My.Resources.AllWarningMessagesForThisTable
        Me.StatusPanel.StatusBox.Clear()

        Dim edx As Integer = 0
        Dim errText As String = ""
        For Each errBool In TableErrors
            If (errBool) Then
                If (edx < 10) Then
                    errText &= " "
                End If
                errText &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
            End If
            edx += 1
        Next errBool

        Me.StatusPanel.StatusBox.Text = errText

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

    Private Sub Mybase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize

        Dim dataWidth As Integer = Me.DataPanel.Width
        Dim dataHeight As Integer = Me.DataPanel.Height
        Dim boxWidth As Integer = dataWidth - Me.WallGageOptionsBox.Width - Me.Margin.Horizontal * 2
        Dim boxHeight As Integer = dataHeight - Me.Margin.Vertical

        Me.WallGageDataBox.Width = boxWidth
        Me.WallGageDataBox.Height = boxHeight
    End Sub

#End Region

#Region " Fixed-Discharge Interval "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub MinimumDischargeRange_ValueChanged() Handles MinimumDischargeSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Qmin As Single = Me.MinimumDischargeSingle.SiValue
            If Not (mFlume.WGageQMin = Qmin) Then
                mFlume.WGageQMin = Qmin
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MaximumDischargeRange_ValueChanged() Handles MaximumDischargeSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Qmax As Single = Me.MaximumDischargeSingle.SiValue
            If Not (mFlume.WGageQMax = Qmax) Then
                mFlume.WGageQMax = Qmax
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DischargeIncrementSingle_ValueChanged() Handles DischargeIncrementSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Qinc As Single = Me.DischargeIncrementSingle.SiValue
            If Not (mFlume.WGageQInc = Qinc) Then
                mFlume.WGageQInc = Qinc
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
