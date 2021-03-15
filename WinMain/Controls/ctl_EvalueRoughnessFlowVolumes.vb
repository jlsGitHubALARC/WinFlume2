
'*************************************************************************************************************
' ctl_EvalueRoughnessFlowVolumes - Estimates Roughness using measured Surface Flow Volumes
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI

Public Class ctl_EvalueRoughnessFlowVolumes

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm
    Private WithEvents mWinSRFR As WinSRFR

    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mSoilCropProperties As SoilCropProperties
    Private WithEvents mEventCriteria As EventCriteria

    Private mSurfaceFlow As SurfaceFlow

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mUserPreferences As UserPreferences = UserPreferences.Instance

    Private mDictionary As Dictionary = Dictionary.Instance

    Private mMyStore As DataStore.ObjectNode

    Private mAnalysis As Analysis
    Private mEVALUE As EVALUE
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal worldWindow As WorldWindow)

        Debug.Assert((_unit IsNot Nothing), "Unit is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mInflowManagement = mUnit.InflowManagementRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mEventCriteria = mUnit.EventCriteriaRef

        mSurfaceFlow = mUnit.SurfaceFlowRef

        mWorldWindow = worldWindow

        mAnalysis = mWorldWindow.CurrentAnalysis
        If (mAnalysis IsNot Nothing) Then
            If (mAnalysis.GetType Is GetType(EVALUE)) Then
                mEVALUE = DirectCast(mAnalysis, EVALUE)
            End If
        End If

        mMyStore = mUnit.MyStore

        ' Link the contained controls to their models & store
        RoughnessMethodControl.LinkToModel(mMyStore, mSoilCropProperties.RoughnessMethodProperty)

        Sel_004.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.BareSoil)
        Sel_010.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.SmallGrain)
        Sel_015.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.AlfalfaMintBroadcast)
        Sel_020.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.AlfalfaDenseOrLong)
        Sel_025.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.DenseSodCrops)
        Sel_UserEntered.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.UserEntered)

        UsersManningNControl.LinkToModel(mMyStore, mSoilCropProperties.UsersManningNProperty)
        ManningCnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningCnProperty)
        ManningAnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningAnProperty)
        SayreChiControl.LinkToModel(mMyStore, mSoilCropProperties.SayreChiProperty)

        Me.SurfaceVolumeSummaryTable.LinkToModel(mMyStore, mEventCriteria.SurfaceVolumeSummaryProperty)
        Me.SurfaceVolumeSummaryTable.AllRowsFixed = True
        Me.SurfaceVolumeSummaryTable.ReadonlyColumn(sTimeX) = True
        Me.SurfaceVolumeSummaryTable.ReadonlyColumn(sDistanceX) = True
        Me.SurfaceVolumeSummaryTable.ReadonlyColumn(sVyMeas) = True
        Me.SurfaceVolumeSummaryTable.ReadonlyColumn(sVyPred) = True
        Me.SurfaceVolumeSummaryTable.HiddenColumn(sBeta) = True
        Me.SurfaceVolumeSummaryTable.UpdateUI()

        ' Update language translation
        UpdateLanguage()

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
    ' Update UI when DataStore changes
    '
    Public Sub InflowManagement_PropertyChanged(ByVal reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub

    Public Sub SoilCropProperties_PropertyChanged(ByVal reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        UpdateUI()
    End Sub

    Public Sub EventCriteria_PropertyChanged(ByVal reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateUI()
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
        '
        ' Update UI only if EVALUE is the current analysis
        '
        If (mEVALUE Is Nothing) Then
            If (mWorldWindow Is Nothing) Then
                Return
            Else
                mAnalysis = mWorldWindow.CurrentAnalysis
                If (mAnalysis Is Nothing) Then
                    Return
                Else
                    If (mAnalysis.GetType Is GetType(EVALUE)) Then
                        mEVALUE = DirectCast(mAnalysis, EVALUE)
                    Else
                        Return
                    End If
                End If
            End If
        End If

        Debug.Assert(mEVALUE IsNot Nothing)
        '
        ' Update the UI & graphics
        '
        UpdateRoughnessMethod()
        UpdateNrcsSuggestedManningN()

        Dim table As DataTable = mEventCriteria.SurfaceVolumeSummary.Value
        Me.SurfaceVolumeSummaryTable.UpdateUI()

        UpdateGraphics()

    End Sub
    '
    ' Resize the UI to allow easier viewing
    '
    Private Sub ResizeUI()

        ' Adjust contained controls to match new size
        Me.SurfaceFlowVolumeGraph.Width = Me.Width - Me.SurfaceFlowVolumeGraph.Location.X - Me.Location.X
        Me.SurfaceFlowVolumeGraph.Height = Me.Height - Me.SurfaceFlowVolumeGraph.Location.Y - 5

        Me.SurfaceVolumeSummaryTable.Height = Me.Height - Me.SurfaceVolumeSummaryTable.Location.Y - 5

        Me.UpdateUI()

    End Sub
    '
    ' Update the Roughness Method selection list & selection
    '
    Private Sub UpdateRoughnessMethod()

        ' Update selection list
        Dim roughnessMethod As RoughnessMethods = mSoilCropProperties.RoughnessMethod.Value
        Dim _sel As String = String.Empty
        Dim _idx As Integer = 0

        RoughnessMethodControl.Clear()

        Dim _selOk As Boolean = mSoilCropProperties.GetFirstRoughnessMethodSelection(_sel)
        While Not (_sel Is Nothing)
            If (_selOk) Then
                RoughnessMethodControl.Add(_sel, _idx, True)
            ElseIf (roughnessMethod = _idx) Then
                RoughnessMethodControl.Add(_sel, _idx, False)
            End If
            _selOk = mSoilCropProperties.GetNextRoughnessMethodSelection(_sel)
            _idx += 1
        End While

        ' Update selection
        RoughnessMethodControl.UpdateUI()

        ' Hide / Show correspnding UI panels & photos
        Select Case (roughnessMethod)
            Case RoughnessMethods.SayreAlbertson
                NrcsManningNPanel.Hide()
                ManningCnAnPanel.Hide()
                SayreChiPanel.Show()

            Case RoughnessMethods.ManningCnAn
                NrcsManningNPanel.Hide()
                SayreChiPanel.Hide()
                ManningCnAnPanel.Show()

            Case Else ' Assume RoughnessMethods.NrcsSuggestedManningN
                ManningCnAnPanel.Hide()
                SayreChiPanel.Hide()
                NrcsManningNPanel.Show()
        End Select

    End Sub
    '
    ' Update which NRCS Manning N is checked
    '
    Private Sub UpdateNrcsSuggestedManningN()
        Select Case mSoilCropProperties.NrcsSuggestedManningN.Value
            Case NrcsSuggestedManningN.BareSoil
                Sel_004.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.SmallGrain
                Sel_010.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.AlfalfaMintBroadcast
                Sel_015.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.AlfalfaDenseOrLong
                Sel_020.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.DenseSodCrops
                Sel_025.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.UserEntered
                Sel_UserEntered.Checked = True
                Me.UsersManningNControl.Enabled = True
        End Select
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " Graphics Update Methods "
    '
    ' Update the graphs
    '
    Public Sub UpdateGraphics()
        '
        ' Separate Measured from Predicted data so graphing properties can be added to each.
        '
        If (mUnit IsNot Nothing) Then

            ' Get Measured Surface Volumes from summary table
            Dim measuredSurfaceVolumes As DataTable = mEventCriteria.SurfaceVolumeSummary.Value
            If (measuredSurfaceVolumes IsNot Nothing) Then
                Dim msvCopy As DataTable = measuredSurfaceVolumes.Copy

                ' Give appropriate name & removed unwanted columns
                msvCopy.TableName = "Measured Surface Volumes"
                msvCopy.Columns.RemoveAt(nTimeX)
                msvCopy.Columns.Remove(sVyPred)
                msvCopy.Columns.Remove(sBeta)

                ' Add display properties
                msvCopy.ExtendedProperties.Add("Symbol", "O")
                msvCopy.ExtendedProperties.Add("Line", True)
                msvCopy.ExtendedProperties.Add("Color", Drawing.Color.Blue)
                msvCopy.ExtendedProperties.Add("Key", True)
                msvCopy.ExtendedProperties.Add("Key Text", "Measured")

                ' Build DataSet & add Measured table as 1st entry
                Dim surfaceFlowSet As DataSet = New DataSet("Measured vs. Predicted Surface Volumes")
                surfaceFlowSet.Tables.Add(msvCopy)

                ' Get Predicted Surface Volumes from summary table
                Dim predictedSurfaceVolumes As DataTable = mEventCriteria.SurfaceVolumeSummary.Value
                If (predictedSurfaceVolumes IsNot Nothing) Then
                    Dim psvCopy As DataTable = predictedSurfaceVolumes.Copy

                    ' Give appropriate name & removed unwanted columns
                    psvCopy.TableName = "Predicted Surface Volumes"
                    psvCopy.Columns.RemoveAt(nTimeX)
                    psvCopy.Columns.Remove(sVyMeas)
                    psvCopy.Columns.Remove(sBeta)

                    ' Add display properties
                    psvCopy.ExtendedProperties.Add("Symbol", "X")
                    psvCopy.ExtendedProperties.Add("Line", True)
                    psvCopy.ExtendedProperties.Add("Color", Drawing.Color.DarkOrange)
                    psvCopy.ExtendedProperties.Add("Key", True)
                    psvCopy.ExtendedProperties.Add("Key Text", "Predicted")

                    ' Add Predicted table as 2nd entry
                    surfaceFlowSet.Tables.Add(psvCopy)
                End If

                ' Update Surface Flow Volume Summare graph
                Me.SurfaceFlowVolumeGraph.InitializeGraph2D(surfaceFlowSet)
                Me.SurfaceFlowVolumeGraph.UnitsX = Units.Meters
                Me.SurfaceFlowVolumeGraph.UnitsY = Units.CubicMeters
                Me.SurfaceFlowVolumeGraph.DisplayKey = True
                Me.SurfaceFlowVolumeGraph.HorizontalKeys = True
                Me.SurfaceFlowVolumeGraph.DrawImage()

            End If
        End If

    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' Manning N should track NRCS Suggested Manning N
    '
    Private Sub RoughnessMethodControl_ControlValueChanged() _
    Handles RoughnessMethodControl.ControlValueChanged
        If (mSoilCropProperties IsNot Nothing) Then
            If (mSoilCropProperties.RoughnessMethod.Value = RoughnessMethods.NrcsSuggestedManningN) Then
                Dim _suggested As NrcsSuggestedManningN = mSoilCropProperties.NrcsSuggestedManningN.Value
                SetNrcsManningN(_suggested)
            End If
        End If
    End Sub
    '
    ' Surface Volume Summary DataTable
    '
    ' Pre-Save Action - After a change to a user value within the Surface Volume Summary table, but
    '                   before the table is saved, the calculated values must be updated.
    '
    Private Sub SurfaceVolumeSummaryTable_PreSaveAction(ByVal SurfaceVolumeSummary As DataTable, ByRef SaveOK As Boolean) _
    Handles SurfaceVolumeSummaryTable.PreSaveAction
        SaveOK = False

        Try
            If (SurfaceVolumeSummary IsNot Nothing) Then
                SaveOK = mEventCriteria.CalculateSurfaceVolumeSummary(SurfaceVolumeSummary)
            End If
        Catch ex As Exception
            SaveOK = False
        End Try

    End Sub
    '
    ' When values in the Surface Volume Summary table change, the graph also needs to reflect the changes
    Private Sub SurfaceVolumeSummaryTable_ControlValueChanged() _
    Handles SurfaceVolumeSummaryTable.ControlValueChanged
        UpdateGraphics()
    End Sub

#End Region

#Region " UI Event Handlers "
    '
    ' Update NRCS Manning N selection
    '
    Private Sub SetNrcsManningN(ByVal _suggested As NrcsSuggestedManningN)
        If (mSoilCropProperties IsNot Nothing) Then
            Dim _double As DoubleParameter = mSoilCropProperties.ManningN
            If (_suggested = NrcsSuggestedManningN.UserEntered) Then
                _double.Value = mSoilCropProperties.UsersManningN.Value
            Else
                _double.Value = NrcsSuggestedManningNValues(_suggested)
            End If
            _double.Source = DataStore.Globals.ValueSources.UserEntered
            mSoilCropProperties.ManningN = _double
        End If
    End Sub

    Private Sub Sel_004_ControlValueChanged() Handles Sel_004.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.BareSoil)
    End Sub

    Private Sub Sel_010_ControlValueChanged() Handles Sel_010.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.SmallGrain)
    End Sub

    Private Sub Sel_015_ControlValueChanged() Handles Sel_015.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.AlfalfaMintBroadcast)
    End Sub

    Private Sub Sel_020_ControlValueChanged() Handles Sel_020.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.AlfalfaDenseOrLong)
    End Sub

    Private Sub Sel_025_ControlValueChanged() Handles Sel_025.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.DenseSodCrops)
    End Sub

    Private Sub Sel_UserEntered_ControlValueChanged() Handles Sel_UserEntered.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.UserEntered)
    End Sub

    Private Sub UserManningNControl_ControlValueChanged() Handles UsersManningNControl.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.UserEntered)
    End Sub
    '
    ' Resize contained controls when this control's size changes
    '
    Private Sub ctl_EvalueRoughness_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        Me.ResizeUI()
        Me.UpdateGraphics()
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
