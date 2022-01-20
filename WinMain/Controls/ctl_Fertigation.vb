
'**********************************************************************************************
' ctl_Fertigation - UI for viewing & editing the Fertigation data
'
Imports Srfr
Imports Srfr.SoluteTransport

Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI

Public Class ctl_Fertigation

#Region " Member Data "
    '
    ' Control positions / heights for re-sizing
    '
    Private mMinFertigationHeight As Integer
    Private mFertigationHeight As Integer

    Private mMinFertigationBoxHeight As Integer
    Private mMinInjectionPointBoxHeight As Integer
    Private mMinTabulatedPulsePanelHeight As Integer
    Private mMinInjectionRateTableHeight As Integer

    Private mControlHeightsSaved As Boolean = False
    Private mLinkedToModel As Boolean = False

#End Region

#Region " Initialization "

    Private Sub InitializeFertigationControls()
        '
        ' Save initial control sizing for later re-sizing
        '
        mMinFertigationBoxHeight = Me.FertigationBox.Height
        mMinInjectionPointBoxHeight = Me.InjectionPointBox.Height
        mMinTabulatedPulsePanelHeight = Me.TabulatedPulsePanel.Height
        mMinInjectionRateTableHeight = Me.InjectionRateTable.Height

        mMinFertigationHeight = MyBase.Height
        mFertigationHeight = MyBase.Height

        mControlHeightsSaved = True

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
    Private mWinSRFR As WinSRFR = Nothing

    Private WithEvents mFertigation As Fertigation = Nothing
    Private WithEvents mInflowManagement As InflowManagement = Nothing

    Private mDictionary As Dictionary = Nothing
    Private mMyStore As DataStore.ObjectNode = Nothing

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Establish links to model objects and update UI
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal worldWindow As WorldWindow)
        Debug.Assert((_unit IsNot Nothing)) ' Unit is Nothing

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mFertigation = mUnit.FertigationRef
        mInflowManagement = mUnit.InflowManagementRef

        mWorldWindow = worldWindow

        mDictionary = Dictionary.Instance
        mMyStore = mUnit.MyStore

        ' Fertigation controls
        Me.TankConcentrationControl.LinkToModel(mMyStore, mFertigation.TankConcentrationProperty)

        Me.InjectionRateTable.LinkToModel(mMyStore, mFertigation.TabulatedInjectionRateProperty)

        ' Update language translation
        UpdateLanguage() ' also calls UpdateUI()

        mLinkedToModel = True

    End Sub
    '
    ' Update UI when Fertigation values change
    '
    Private Sub Fertigation_PropertyChanged(ByVal _reason As Fertigation.Reasons) _
    Handles mFertigation.PropertyDataChanged
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
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        ' Update the UI only if it is linked to a model object
        If (mUnit IsNot Nothing) Then

            Me.TabulatedPulsePanel.Show()

            Me.InjectionRateTable.UpdateUI()

            If (mWinSRFR.UserLevel = UserLevels.Standard) Then
                Me.FertigationOptionsButton.Visible = False
            Else
                Me.FertigationOptionsButton.Visible = True
            End If

            UpdateGraphics()
        End If
    End Sub
    '
    ' Make sure the graphics are up to date whenever they become visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me)
        UpdateUI()
    End Sub

#End Region

#Region " Fertigation Graphics "
    '
    ' Update the Fertigation graphics
    '
    Private Sub UpdateGraphics()

        If (mUnit IsNot Nothing) Then
            ' Enclose all graphics code in Try Catch block to ignore exceptions
            Try
                Dim _tabulatedInjection As DataTable = mFertigation.TabulatedInjectionRate.Value
                GraphTabulatedInjection(InjectionRateGraph, _tabulatedInjection)

            Catch ex As Exception
                ' Ignore exceptions
            End Try
        End If

    End Sub
    '
    ' Graphics for Tabulated Injection
    '
    Private Sub GraphTabulatedInjection(ByVal _pictureBox As PictureBox, ByVal _tabulatedInjection As DataTable)

        ' Get the Tabulated Injection values
        Dim _maxInjectionTime As Double = DataStore.Utilities.DataColumnMax(_tabulatedInjection, nTimeX)
        Dim _maxInjectionRate As Double = DataStore.Utilities.DataColumnMax(_tabulatedInjection, nInjectionRateX)

        ' Get drawing tools
        Dim _black As Pen = BlackPen1()
        Dim _blue As Pen = BluePen2()
        Dim _blueBrush As SolidBrush = BlueSolidBrush()

        ' x,y scaling to make graph fit better
        Dim _xAdj As Single = 0.97
        Dim _yAdj As Single = 0.9

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
        _xAxis.MaxValue = _maxInjectionTime
        _xAxis.MaxLabel = TimeString(_maxInjectionTime, 0)

        ' Y-axis information (Injection Rate)
        Dim _yAxis As Axis
        _yAxis.AxisLabel = mDictionary.tInjectionRate.Translated
        _yAxis.MaxValue = _maxInjectionRate
        _yAxis.MaxLabel = InjectionRateString(_maxInjectionRate, 0)

        DrawAxes(_bitmap, _quadrant, _xAxis, _yAxis, _offset, Me.Font)
        '
        ' Draw total applied title
        '
        Dim Tco As Double = mInflowManagement.Cutoff
        Dim Sapp As Double = mFertigation.AppliedSolute
        Dim Co As Double = mFertigation.TankConcentration.Value

        Dim appVol As String = InjectionVolumeString(Sapp)
        Dim appMass As String = MassString(Sapp * Co)

        Me.InjectionSummaryLabel.Text = mDictionary.tAppliedVolume.Translated & " = " & appVol _
                            & "  -  " & mDictionary.tAppliedMass.Translated & " = " & appMass
        '
        ' Check for fertigation injection past Tco
        '
        If (Tco < _maxInjectionTime) Then
            Me.FertigationWarnings.Clear()
            Me.FertigationWarnings.DisplayBoldLine(mDictionary.tWarning.Translated)
            Me.FertigationWarnings.DisplayLine(mDictionary.tInjectionTimesLimitedByTco.Translated)
            Me.FertigationWarnings.Show()

            Dim _x As Single = Tco * _xAdj
            Dim _y As Single = _maxInjectionRate * _yAdj

            DrawLine(_bitmap, _quadrant, _blue, _xAxis, _yAxis, _offset, _x, 0, _x, _maxInjectionRate)

            _x = CSng((_x * (_bitmap.Width - _offset - 1)) / _xAxis.MaxValue)
            _y = CSng((_y / 2 * (_bitmap.Height - _offset - 1)) / _yAxis.MaxValue)
            DrawText(_bitmap, _quadrant, _blueBrush, _offset, Me.Font, _x, _y, "Tco")
        Else
            Me.FertigationWarnings.Clear()
            Me.FertigationWarnings.Hide()
        End If
        '
        ' Define & draw the Tabulated Injection 'curve'
        '
        Dim _xPoints As ArrayList = New ArrayList
        Dim _yPoints As ArrayList = New ArrayList

        Dim time1 As Double
        Dim rate1 As Double

        If (_tabulatedInjection IsNot Nothing) Then

            time1 = CDbl(_tabulatedInjection.Rows(0).Item(nTimeX))
            rate1 = CDbl(_tabulatedInjection.Rows(0).Item(nInjectionRateX))

            _xPoints.Add(time1 * _xAdj)
            _yPoints.Add(rate1 * _yAdj)

            For _idx As Integer = 1 To _tabulatedInjection.Rows.Count - 1

                Dim time2 As Double = CDbl(_tabulatedInjection.Rows(_idx).Item(nTimeX))
                Dim rate2 As Double = CDbl(_tabulatedInjection.Rows(_idx).Item(nInjectionRateX))

                _xPoints.Add(time2 * _xAdj)
                _yPoints.Add(rate2 * _yAdj)

                time1 = time2
                rate1 = rate2
            Next
        End If

        If Not (0.0 = rate1) Then
            _xPoints.Add(time1 * _xAdj)
            _yPoints.Add(0.0 * _yAdj)
        End If

        For _line As Integer = 0 To _yPoints.Count - 2
            Dim _x1 As Double = CDbl(_xPoints(_line))
            Dim _y1 As Double = CDbl(_yPoints(_line))
            Dim _x2 As Double = CDbl(_xPoints(_line + 1))
            Dim _y2 As Double = CDbl(_yPoints(_line + 1))
            DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
        Next _line
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

#Region " UI Event Handlers "

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        ' Skip premature Resize events
        If (mControlHeightsSaved And mLinkedToModel) Then

            ' Get change in Height for Inflow Management control
            Dim _deltaHeight As Integer = mFertigationHeight - MyBase.Height

            ' Adjust contained controls to match new height (with limits on minimum heights)
            FertigationBox.Height = Math.Max(mMinFertigationBoxHeight, _
                                             FertigationBox.Height - _deltaHeight)

            InjectionPointBox.Height = Math.Max(mMinInjectionPointBoxHeight, _
                                                InjectionPointBox.Height - _deltaHeight)

            TabulatedPulsePanel.Height = Math.Max(mMinTabulatedPulsePanelHeight, _
                                                  TabulatedPulsePanel.Height - _deltaHeight)

            InjectionRateTable.Height = Math.Max(mMinInjectionRateTableHeight, _
                                                 InjectionRateTable.Height - _deltaHeight)

            If (mMinFertigationHeight < MyBase.Height) Then
                mFertigationHeight = MyBase.Height
            End If

        End If

    End Sub

    Private Sub InjectionRateTable_ControlValueChanged() _
    Handles InjectionRateTable.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        Me.UpdateGraphics()
    End Sub

    Private Sub ctl_Fertigation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        Me.InitializeFertigationControls()
    End Sub

    Private Sub FertigationOptionsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FertigationOptionsButton.Click

        Dim fo As FertigationOptions = New FertigationOptions()

        fo.InitUI(mFertigation, mMyStore, mWinSRFR)

        fo.CharacteristicType = mFertigation.CharacteristicType.Value
        fo.EnableDispersion = mFertigation.IncludeDispersion.Value
        fo.AdvectionInterpolationMethod = mFertigation.AdvectionInterpolationMethod.Value
        fo.DispersivityCoefficientMethod = mFertigation.DispersivityCoefficientMethod.Value

        Dim result As DialogResult = fo.ShowDialog()
        If (result = DialogResult.OK) Then
            mMyStore.MarkForUndo(mDictionary.tFertigationOptions.Translated)

            If Not (fo.CharacteristicType = mFertigation.CharacteristicType.Value) Then
                Dim intParam As IntegerParameter = mFertigation.CharacteristicType
                intParam.Value = fo.CharacteristicType
                intParam.Source = ValueSources.UserEntered
                mFertigation.CharacteristicType = intParam
            End If

            If Not (fo.EnableDispersion = mFertigation.IncludeDispersion.Value) Then
                Dim boolParam As BooleanParameter = mFertigation.IncludeDispersion
                boolParam.Value = fo.EnableDispersion
                boolParam.Source = ValueSources.UserEntered
                mFertigation.IncludeDispersion = boolParam
            End If

            If Not (fo.AdvectionInterpolationMethod = mFertigation.AdvectionInterpolationMethod.Value) Then
                Dim intParam As IntegerParameter = mFertigation.AdvectionInterpolationMethod
                intParam.Value = fo.AdvectionInterpolationMethod
                intParam.Source = ValueSources.UserEntered
                mFertigation.AdvectionInterpolationMethod = intParam
            End If

            If Not (fo.DispersivityCoefficientMethod = mFertigation.DispersivityCoefficientMethod.Value) Then
                Dim intParam As IntegerParameter = mFertigation.DispersivityCoefficientMethod
                intParam.Value = fo.DispersivityCoefficientMethod
                intParam.Source = ValueSources.UserEntered
                mFertigation.DispersivityCoefficientMethod = intParam
            End If

            If Not (fo.ElderCe = mFertigation.ElderCe.Value) Then
                Dim dblParam As DoubleParameter = mFertigation.ElderCe
                dblParam.Value = fo.ElderCe
                dblParam.Source = ValueSources.UserEntered
                mFertigation.ElderCe = dblParam
            End If

            If Not (fo.SpecifiedKx = mFertigation.SpecifiedKx.Value) Then
                Dim dblParam As DoubleParameter = mFertigation.SpecifiedKx
                dblParam.Value = fo.SpecifiedKx
                dblParam.Source = ValueSources.UserEntered
                mFertigation.SpecifiedKx = dblParam
            End If
        End If
    End Sub

#End Region

End Class
