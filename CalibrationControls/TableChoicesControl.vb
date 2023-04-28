
'*************************************************************************************************************
' Class TableChoicesControl - UserControl for displaying & editing the Rating Table Choices
'
' TableChoicesControl provides the user interface and data management for the Rating Table Choices for
' WinFlume.
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.UnitsDialog    ' Unit conversion support

Public Class TableChoicesControl

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
    ' Rating Table Choices data
    '
    Private Const DesiredLines As Integer = 30                  ' Rating Table entries after Smart Range

    Private Const ClearAllRatingParameters As Integer = 32771   ' Bits 15, 2 & 1 are always selected
    Private Const SelectAllRatingParameters As Integer = 65535

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

#Region " Properties "

    Public Class TableChoice
        Public Rating As Flume.RatingResultsEnum
        Public Name As String
        Public Symbol As String
        Public SiUnits As String
        Public Selected As Boolean

        Public Sub New(ByVal Rating As Flume.RatingResultsEnum, ByVal Name As String, ByVal Symbol As String, _
                       ByVal SiUnits As String, ByVal Selected As Boolean)
            Me.Rating = Rating
            Me.Name = Name
            Me.Symbol = Symbol
            Me.SiUnits = SiUnits
            Me.Selected = Selected
        End Sub

        Public Sub New(ByVal tblChoice As TableChoice)
            With tblChoice
                Me.Rating = .Rating
                Me.Name = .Name
                Me.Symbol = .Symbol
                Me.SiUnits = .SiUnits
                Me.Selected = .Selected
            End With
        End Sub

    End Class

    Private mTableChoices As List(Of TableChoice) = Nothing
    Public ReadOnly Property TableChoices() As List(Of TableChoice)
        Get
            Dim ratingParameters As Integer = WinFlumeForm.RatingParametersToShow
            Me.RebuildTableChoicesList(ratingParameters)
            Return mTableChoices
        End Get
    End Property

    Public ReadOnly Property NumberOfTableChoices() As Integer
        Get
            NumberOfTableChoices = 0
            If (mTableChoices IsNot Nothing) Then
                For Each choice As TableChoice In mTableChoices
                    If (choice.Selected) Then
                        NumberOfTableChoices += 1
                    End If
                Next choice
            End If
        End Get
    End Property

#End Region

#Region " Data Methods "

    Private Sub RebuildTableChoicesList(ByVal RatingParametersToShow As Integer)

        Dim value As Flume.RatingResultsEnum
        Dim name, symbol, siUnits As String
        Dim selected As Boolean

        mTableChoices = New List(Of TableChoice)

        value = RatingResultsEnum.SMALLh1
        name = My.Resources.HeadAtGage
        symbol = "h1"
        siUnits = "m"
        selected = True
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Q
        name = My.Resources.Discharge
        symbol = "Q"
        siUnits = "m³/s"
        selected = True
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Froude
        name = Me.FroudeNumberCheckBox.Text
        symbol = SymbolFromLabel(Me.FrLabel.Text)
        siUnits = ""
        selected = 0 < (RatingParametersToShow And 1 << CInt(FroudeNumberCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.ReqEnergyLoss
        name = Me.RequiredHeadLossCheckBox.Text
        symbol = SymbolFromLabel(Me.H1H2Label.Text)
        siUnits = "m"
        selected = 0 < (RatingParametersToShow And 1 << CInt(RequiredHeadLossCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.HLRatio
        name = Me.HeadToCrestLengthRatioCheckBox.Text
        symbol = SymbolFromLabel(Me.H1LLabel.Text)
        siUnits = ""
        selected = 0 < (RatingParametersToShow And 1 << CInt(HeadToCrestLengthRatioCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.H1
        name = Me.UpstreamEnergyHeadCheckBox.Text
        symbol = SymbolFromLabel(Me.H1Label.Text)
        siUnits = "m"
        selected = 0 < (RatingParametersToShow And 1 << CInt(UpstreamEnergyHeadCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.y1
        name = Me.UpstreamDepthCheckBox.Text
        symbol = SymbolFromLabel(Me.y1Label.Text)
        siUnits = "m"
        selected = 0 < (RatingParametersToShow And 1 << CInt(UpstreamDepthCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.V1
        name = Me.UpstreamVelocityCheckBox.Text
        symbol = SymbolFromLabel(Me.V1Table.Text)
        siUnits = "m/s"
        selected = 0 < (RatingParametersToShow And 1 << CInt(UpstreamVelocityCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Cd
        name = Me.DischargeCoefficientCheckBox.Text
        symbol = SymbolFromLabel(Me.CdLabel.Text)
        siUnits = ""
        selected = 0 < (RatingParametersToShow And 1 << CInt(DischargeCoefficientCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Cv
        name = Me.VelocityCoefficientCheckBox.Text
        symbol = SymbolFromLabel(Me.CvLabel.Text)
        siUnits = ""
        selected = 0 < (RatingParametersToShow And 1 << CInt(VelocityCoefficientCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.MaxTailwater
        name = Me.MaxAllowableTailwaterHeadCheckBox.Text
        symbol = SymbolFromLabel(Me.h2Label1.Text)
        siUnits = "m"
        selected = 0 < (RatingParametersToShow And 1 << CInt(MaxAllowableTailwaterHeadCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.smallh2
        name = Me.ActualTailwaterHeadCheckBox.Text
        symbol = SymbolFromLabel(Me.h2Label2.Text)
        siUnits = "m"
        selected = 0 < (RatingParametersToShow And 1 << CInt(ActualTailwaterHeadCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.ActualTailwaterDepth
        name = Me.ActualTailwaterDepthCheckBox.Text
        symbol = SymbolFromLabel(Me.y2Label.Text)
        siUnits = "m"
        selected = 0 < (RatingParametersToShow And 1 << CInt(ActualTailwaterDepthCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Submergence
        name = Me.SubmergenceRatioCheckBox.Text
        symbol = SymbolFromLabel(Me.H2H1Label.Text)
        siUnits = ""
        selected = 0 < (RatingParametersToShow And 1 << CInt(SubmergenceRatioCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.ModularLimit
        name = Me.ModularLimitCheckBox.Text
        symbol = ""
        siUnits = ""
        selected = 0 < (RatingParametersToShow And 1 << CInt(ModularLimitCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Errors
        name = My.Resources.Warnings
        symbol = ""
        siUnits = ""
        selected = True
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

    End Sub

    Private Function SymbolFromLabel(ByVal Label As String) As String
        SymbolFromLabel = Label
        If (Label(0) = "(") Then
            Dim closed As Integer = Label.IndexOf(")")
            If (closed > 0) Then
                SymbolFromLabel = Label.Substring(1, closed - 1)
            End If
        End If
    End Function

    Public Sub ValidateSmartRange(ByVal Flume As FlumeType)

        If (Flume IsNot Nothing) Then
            If (Flume.RatingTableType = QHTable) Then ' Discharge-Head (QH) rating table

                Dim Qmin As Single = Flume.RatingQMin
                Dim Qmax As Single = Flume.RatingQMax
                Dim Qinc As Single = Flume.RatingQInc

                If ((Qmin <= 0) And (Qmax <= 0) And (Qinc <= 0)) Then
                    Flume.SmartRange(Qmin, Qmax, Qinc, QHTable, DesiredLines, False)
                    Flume.RatingQMin = Qmin
                    Flume.RatingQMax = Qmax
                    Flume.RatingQInc = Qinc
                End If

            Else ' Head-Discharge (HQ) rating table

                Dim Hmin As Single = Flume.RatingHMin
                Dim Hmax As Single = Flume.RatingHMax
                Dim Hinc As Single = Flume.RatingHInc

                If ((Hmin <= 0) And (Hmax <= 0) And (Hinc <= 0)) Then
                    Flume.SmartRange(Hmin, Hmax, Hinc, HQTable, DesiredLines, False)
                    Flume.RatingHMin = Hmin
                    Flume.RatingHMax = Hmax
                    Flume.RatingHInc = Hinc
                End If
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

        ' Update Table Type & Range selections
        Me.DischargeHeadButton.Label = Me.RatingTableTypeGroup.Text
        Me.DischargeHeadButton.RbValue = QHTable
        Me.DischargeHeadButton.UiValue = mFlume.RatingTableType

        Me.HeadDischargeButton.Label = Me.RatingTableTypeGroup.Text
        Me.HeadDischargeButton.RbValue = HQTable
        Me.HeadDischargeButton.UiValue = mFlume.RatingTableType

        ValidateSmartRange(mFlume)

        If (mFlume.RatingTableType = QHTable) Then ' Discharge-Head (QH) rating table

            Me.DischargeHeadButton.Checked = True

            Me.RangeBox.Text = My.Resources.DischargeRange

            Me.MinimumRangeSingle.SiUnits = DischargeUnitsAbbreviations(0)
            Me.MinimumRangeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.RatingQMin
            Me.MinimumRangeSingle.SiValue = mFlume.RatingQMin
            Me.MinimumRangeSingle.Label = Me.MinimumRangeLabel.Text

            Me.MaximumRangeSingle.SiUnits = DischargeUnitsAbbreviations(0)
            Me.MaximumRangeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.RatingQMax
            Me.MaximumRangeSingle.SiValue = mFlume.RatingQMax
            Me.MaximumRangeSingle.Label = Me.MaximumRangeLabel.Text

            Me.RangeIncrementSingle.SiUnits = DischargeUnitsAbbreviations(0)
            Me.RangeIncrementSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.RatingQInc
            Me.RangeIncrementSingle.SiValue = mFlume.RatingQInc
            Me.RangeIncrementSingle.Label = Me.RangeIncrementLabel.Text

        Else ' Head-Discharge (HQ) rating table

            Me.HeadDischargeButton.Checked = True

            Me.RangeBox.Text = My.Resources.HeadAtGageRange

            Me.MinimumRangeSingle.SiUnits = LengthUnitsAbbreviations(0)
            Me.MinimumRangeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.RatingHMin
            Me.MinimumRangeSingle.SiValue = mFlume.RatingHMin
            Me.MinimumRangeSingle.Label = Me.MinimumRangeLabel.Text

            Me.MaximumRangeSingle.SiUnits = LengthUnitsAbbreviations(0)
            Me.MaximumRangeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.RatingHMax
            Me.MaximumRangeSingle.SiValue = mFlume.RatingHMax
            Me.MaximumRangeSingle.Label = Me.MaximumRangeLabel.Text

            Me.RangeIncrementSingle.SiUnits = LengthUnitsAbbreviations(0)
            Me.RangeIncrementSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.RatingHInc
            Me.RangeIncrementSingle.SiValue = mFlume.RatingHInc
            Me.RangeIncrementSingle.Label = Me.RangeIncrementLabel.Text

        End If

        ' Update Rating Table Parameter selections
        Dim RatingParametersToShow As Integer = WinFlumeForm.RatingParametersToShow

        For Each ctrl As Control In RatingTableOutputsBox.Controls
            If (ctrl.GetType Is GetType(ctl_CheckBox)) Then
                Dim checkBox As ctl_CheckBox = DirectCast(ctrl, ctl_CheckBox)
                Dim checkTag As Integer = CInt(checkBox.Tag)
                Dim checkBit As Integer = 1 << checkTag
                Dim selected As Integer = RatingParametersToShow And checkBit

                If (selected = 0) Then
                    checkBox.Value = False
                Else
                    checkBox.Value = True
                End If
            End If
        Next ctrl

        Me.RebuildTableChoicesList(RatingParametersToShow)

        mUpdatingUI = False
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    Private Sub TableChoicesControl_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub HeadDischargeButton_ValueChanged(ByVal NewValue As Integer) _
    Handles HeadDischargeButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.RatingTableType = NewValue) Then
                mFlume.RatingTableType = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DischargeHeadButton_ValueChanged(ByVal NewValue As Integer) _
    Handles DischargeHeadButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.RatingTableType = NewValue) Then
                mFlume.RatingTableType = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub MinimumRange_ValueChanged() Handles MinimumRangeSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (mFlume.RatingTableType = QHTable) Then ' Discharge-Head (QH) rating table
                Dim Qmin As Single = Me.MinimumRangeSingle.SiValue
                If Not (mFlume.RatingQMin = Qmin) Then
                    mFlume.RatingQMin = Qmin
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            Else ' Head-Discharge (HQ) rating table
                Dim Hmin As Single = Me.MinimumRangeSingle.SiValue
                If Not (mFlume.RatingHMin = Hmin) Then
                    mFlume.RatingHMin = Hmin
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Protected Sub MaximumRange_ValueChanged() Handles MaximumRangeSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (mFlume.RatingTableType = QHTable) Then ' Discharge-Head (QH) rating table
                Dim Qmax As Single = Me.MaximumRangeSingle.SiValue
                If Not (mFlume.RatingQMax = Qmax) Then
                    mFlume.RatingQMax = Qmax
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            Else ' Head-Discharge (HQ) rating table
                Dim Hmax As Single = Me.MaximumRangeSingle.SiValue
                If Not (mFlume.RatingHMax = Hmax) Then
                    mFlume.RatingHMax = Hmax
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Protected Sub RangeIncrement_ValueChanged() Handles RangeIncrementSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (mFlume.RatingTableType = QHTable) Then ' Discharge-Head (QH) rating table
                Dim Qinc As Single = Me.RangeIncrementSingle.SiValue
                If Not (mFlume.RatingQInc = Qinc) Then
                    mFlume.RatingQInc = Qinc
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            Else ' Head-Discharge (HQ) rating table
                Dim Hinc As Single = Me.RangeIncrementSingle.SiValue
                If Not (mFlume.RatingHInc = Hinc) Then
                    mFlume.RatingHInc = Hinc
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Rating Table parameter selections
    '*********************************************************************************************************
    Private Sub UpdateRatingTableParameters()
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim RatingTableParameters As Integer = ClearAllRatingParameters ' Bits 15, 2 & 1 are always selected

            For Each ctrl As Control In RatingTableOutputsBox.Controls
                If (ctrl.GetType Is GetType(ctl_CheckBox)) Then
                    Dim checkBox As ctl_CheckBox = DirectCast(ctrl, ctl_CheckBox)
                    If (checkBox.Checked) Then
                        Dim checkTag As Integer = CInt(checkBox.Tag)
                        Dim checkBit As Integer = 1 << checkTag
                        RatingTableParameters += checkBit
                    End If
                End If
            Next ctrl

            WinFlumeForm.RatingParametersToShow = RatingTableParameters
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub FroudeNumberCheckBox_ValueChanged() Handles FroudeNumberCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub RequiredHeadLossCheckBox_ValueChanged() Handles RequiredHeadLossCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub HeadToCrestLengthRatioCheckBox_ValueChanged() Handles HeadToCrestLengthRatioCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub UpstreamEnergyHeadCheckBox_ValueChanged() Handles UpstreamEnergyHeadCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub UpstreamDepthCheckBox_ValueChanged() Handles UpstreamDepthCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub UpstreamVelocityCheckBox_ValueChanged() Handles UpstreamVelocityCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub DischargeCoefficientCheckBox_ValueChanged() Handles DischargeCoefficientCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub VelocityCoefficientCheckBox_ValueChanged() Handles VelocityCoefficientCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub MaxAllowableTailwaterHeadCheckBox_ValueChanged() Handles MaxAllowableTailwaterHeadCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub ActualTailwaterHeadCheckBox_ValueChanged() Handles ActualTailwaterHeadCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub ActualTailwaterDepthCheckBox_ValueChanged() Handles ActualTailwaterDepthCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub SubmergenceRatioCheckBox_ValueChanged() Handles SubmergenceRatioCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub ModularLimitCheckBox_ValueChanged() Handles ModularLimitCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    '*********************************************************************************************************
    ' Button event handlers - Click, UndoButtonEvent, RedoButtonEvent
    '
    ' Note - Undo/Redo handling is specific to each Button since the action taken is not known to ctl_Button.
    '*********************************************************************************************************
    Private Sub SmartRangeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SmartRangeButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            If (mFlume.RatingTableType = QHTable) Then ' Discharge-Head (QH) rating table
                ' Set current selections as Undo point
                Dim Qmin As Single = mFlume.RatingQMin
                Dim Qmax As Single = mFlume.RatingQMax
                Dim Qinc As Single = mFlume.RatingQInc
                Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Qmin, Qmax, Qinc)
                SmartRangeButton.AddUndoItem(SmartRangeUndo)
                WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
                ' Set Smart Range values
                mFlume.SmartRange(Qmin, Qmax, Qinc, QHTable, DesiredLines, True)
                mFlume.RatingQMin = Qmin
                mFlume.RatingQMax = Qmax
                mFlume.RatingQInc = Qinc

            Else ' Head-Discharge (HQ) rating table

                ' Set current selections as Undo point
                Dim Hmin As Single = mFlume.RatingHMin
                Dim Hmax As Single = mFlume.RatingHMax
                Dim Hinc As Single = mFlume.RatingHInc
                Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
                SmartRangeButton.AddUndoItem(SmartRangeUndo)
                WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
                ' Set Smart Range values
                mFlume.SmartRange(Hmin, Hmax, Hinc, HQTable, DesiredLines, True)
                mFlume.RatingHMin = Hmin
                mFlume.RatingHMax = Hmax
                mFlume.RatingHInc = Hinc
            End If

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub SmartRangeButton_UndoButtonEvent(ByVal UndoValue As Object) _
    Handles SmartRangeButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(SmartRangeUndoRedo)) Then

                If (mFlume.RatingTableType = QHTable) Then ' Discharge-Head (QH) rating table

                    ' Set current selections as Redo point
                    Dim Qmin As Single = mFlume.RatingQMin
                    Dim Qmax As Single = mFlume.RatingQMax
                    Dim Qinc As Single = mFlume.RatingQInc
                    Dim SmartRangeRedo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Qmin, Qmax, Qinc)
                    SmartRangeButton.AddRedoItem(SmartRangeRedo)
                    ' Get Undo point's selections
                    Dim SmartRangeUndo As SmartRangeUndoRedo = DirectCast(UndoValue, SmartRangeUndoRedo)
                    ' Restore range parameters
                    mFlume.RatingQMin = SmartRangeUndo.RangeMin
                    mFlume.RatingQMax = SmartRangeUndo.RangeMax
                    mFlume.RatingQInc = SmartRangeUndo.RangeInc

                Else ' Head-Discharge (HQ) rating table

                    ' Set current selections as Redo point
                    Dim Hmin As Single = mFlume.RatingHMin
                    Dim Hmax As Single = mFlume.RatingHMax
                    Dim Hinc As Single = mFlume.RatingHInc
                    Dim SmartRangeRedo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
                    SmartRangeButton.AddRedoItem(SmartRangeRedo)
                    ' Get Undo point's selections
                    Dim SmartRangeUndo As SmartRangeUndoRedo = DirectCast(UndoValue, SmartRangeUndoRedo)
                    ' Restore range parameters
                    mFlume.RatingHMin = SmartRangeUndo.RangeMin
                    mFlume.RatingHMax = SmartRangeUndo.RangeMax
                    mFlume.RatingHInc = SmartRangeUndo.RangeInc
                End If

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub SmartRangeButton_RedoButtonEvent(ByVal RedoValue As Object) _
    Handles SmartRangeButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(SmartRangeUndoRedo)) Then

                If (mFlume.RatingTableType = QHTable) Then ' Discharge-Head (QH) rating table

                    ' Set current selections as Undo point
                    Dim Qmin As Single = mFlume.RatingQMin
                    Dim Qmax As Single = mFlume.RatingQMax
                    Dim Qinc As Single = mFlume.RatingQInc
                    Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Qmin, Qmax, Qinc)
                    SmartRangeButton.AddUndoItem(SmartRangeUndo)
                    ' Get Redo point's selections
                    Dim SmartRangeRedo As SmartRangeUndoRedo = DirectCast(RedoValue, SmartRangeUndoRedo)
                    ' Restore range parameters
                    mFlume.RatingQMin = SmartRangeRedo.RangeMin
                    mFlume.RatingQMax = SmartRangeRedo.RangeMax
                    mFlume.RatingQInc = SmartRangeRedo.RangeInc

                Else ' Head-Discharge (HQ) rating table

                    ' Set current selections as Undo point
                    Dim Hmin As Single = mFlume.RatingHMin
                    Dim Hmax As Single = mFlume.RatingHMax
                    Dim Hinc As Single = mFlume.RatingHInc
                    Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
                    SmartRangeButton.AddUndoItem(SmartRangeUndo)
                    ' Get Redo point's selections
                    Dim SmartRangeRedo As SmartRangeUndoRedo = DirectCast(RedoValue, SmartRangeUndoRedo)
                    ' Restore range parameters
                    mFlume.RatingHMin = SmartRangeRedo.RangeMin
                    mFlume.RatingHMax = SmartRangeRedo.RangeMax
                    mFlume.RatingHInc = SmartRangeRedo.RangeInc
                End If

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub SelectAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SelectAllButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Set current selections as Undo point
            Dim RatingTableParameters As Integer = WinFlumeForm.RatingParametersToShow
            SelectAllButton.AddUndoItem(RatingTableParameters)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
            ' Select all rating table parameters
            WinFlumeForm.RatingParametersToShow = SelectAllRatingParameters
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub SelectAllButton_UndoButtonEvent(ByVal UndoValue As Object) _
    Handles SelectAllButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(Integer)) Then
                ' Set selections for Redo point
                Dim RatingTableParameters As Integer = WinFlumeForm.RatingParametersToShow
                SelectAllButton.AddRedoItem(RatingTableParameters)
                ' Get Undo point's selections
                RatingTableParameters = CInt(UndoValue)
                ' Restore Undo rating table parameters
                WinFlumeForm.RatingParametersToShow = RatingTableParameters
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub SelectAllButton_RedoButtonEvent(ByVal RedoValue As Object) _
    Handles SelectAllButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(Integer)) Then
                ' Set selections for Undo point
                Dim RatingTableParameters As Integer = WinFlumeForm.RatingParametersToShow
                SelectAllButton.AddUndoItem(RatingTableParameters)
                ' Get Undo point's selections
                RatingTableParameters = CInt(RedoValue)
                ' Restore slect all rating table parameters
                WinFlumeForm.RatingParametersToShow = RatingTableParameters
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub ClearAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ClearAllButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Set current selections as Undo point
            Dim RatingTableParameters As Integer = WinFlumeForm.RatingParametersToShow
            ClearAllButton.AddUndoItem(RatingTableParameters)
            WinFlumeForm.ClearRedoStack()
            ' Clear all rating table parameters
            WinFlumeForm.RatingParametersToShow = ClearAllRatingParameters
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub ClearAllButton_UndoButtonEvent(ByVal UndoValue As Object) _
    Handles ClearAllButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(Integer)) Then
                ' Set selections for Redo point
                Dim RatingTableParameters As Integer = WinFlumeForm.RatingParametersToShow
                ClearAllButton.AddRedoItem(RatingTableParameters)
                ' Get Undo point's selections
                RatingTableParameters = CInt(UndoValue)
                ' Restore Undo rating table parameters
                WinFlumeForm.RatingParametersToShow = RatingTableParameters
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub ClearAllButton_RedoButtonEvent(ByVal RedoValue As Object) _
    Handles ClearAllButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(Integer)) Then
                ' Set selections for Undo point
                Dim RatingTableParameters As Integer = WinFlumeForm.RatingParametersToShow
                ClearAllButton.AddUndoItem(RatingTableParameters)
                ' Get Undo point's selections
                RatingTableParameters = CInt(RedoValue)
                ' Restore slect all rating table parameters
                WinFlumeForm.RatingParametersToShow = RatingTableParameters
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub TableChoicesControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub TableChoicesControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize

        Dim loc As Point = Me.Location
        Dim siz As Size = Me.Size

        If (siz.Width > 643) Then ' Limit to 1024x768 main window sizing
            siz.Width = 643
        End If
        If (siz.Height > 352) Then
            siz.Height = 352
        End If

        ' Resize the contained GroupBox's
        Dim wid25 As Integer = CInt(siz.Width * 2 / 5) - 2
        Dim wid35 As Integer = CInt(siz.Width * 3 / 5) - 2
        Dim hgt25 As Integer = CInt(siz.Height * 2 / 5) - 2
        Dim hgt35 As Integer = CInt(siz.Height * 3 / 5) - 2

        siz = New Size(wid25, hgt25)
        Me.RatingTableTypeGroup.Size = siz

        loc = Me.RatingTableTypeGroup.Location
        loc.Y = hgt25 + 4
        siz = New Size(wid25, hgt35 - 4)
        Me.RangeBox.Location = loc
        Me.RangeBox.Size = siz

        loc = Me.RatingTableTypeGroup.Location
        loc.X = wid25 + 6
        siz = New Size(wid35 - 6, hgt25 + hgt35 - 2)
        Me.RatingTableOutputsBox.Location = loc
        Me.RatingTableOutputsBox.Size = siz

        ' Re-locate 'Select All' & 'Clear All' buttons
        loc = Me.SelectAllButton.Location
        loc.Y = Me.RatingTableOutputsBox.Height - Me.SelectAllButton.Height
        loc.Y = Math.Min(loc.Y, Me.ModularLimitCheckBox.Location.Y + Me.ModularLimitCheckBox.Height + 4)
        Me.SelectAllButton.Location = loc

        loc = Me.ClearAllButton.Location
        loc.Y = Me.RatingTableOutputsBox.Height - Me.ClearAllButton.Height
        loc.Y = Math.Min(loc.Y, Me.ModularLimitCheckBox.Location.Y + Me.ModularLimitCheckBox.Height + 4)
        Me.ClearAllButton.Location = loc

    End Sub

#End Region

End Class
