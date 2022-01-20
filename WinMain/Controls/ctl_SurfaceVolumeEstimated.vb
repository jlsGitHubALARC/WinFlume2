
'*************************************************************************************************************
' ctl_SurfaceVolumeEstimated - UI for viewing & editing Estimated Surface Volumes
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_SurfaceVolumeEstimated

#Region " Member Data "

    ' Misc
    Private mMsgDisplayed As Boolean = False

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
    Private WithEvents mSoilCropProperties As SoilCropProperties
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mEventCriteria As EventCriteria

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    Private mMyStore As DataStore.ObjectNode
    '
    ' Access to UI
    '
    Private mEvaluationWorld As EvaluationWorld
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal MyUnit As Unit, ByVal MyWorld As WorldWindow)

        Debug.Assert((MyUnit IsNot Nothing), "Unit is Nothing")

        ' Link control to its data model, UI and DataStore
        mUnit = MyUnit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mInflowManagement = mUnit.InflowManagementRef
        mEventCriteria = mUnit.EventCriteriaRef

        mEvaluationWorld = MyWorld
        mMyStore = mUnit.MyStore

        ' Link contained controls to their data models
        Me.RoughnessControl.LinkToModel(mUnit)
        Me.RoughnessControl.UpdateUI()

        ' EVALUE surface volume table
        Me.EstimatedSurfaceVolumesControl.LinkToModel(mMyStore, mEventCriteria.EstimatedSurfaceVolumesProperty)
        Me.EstimatedSurfaceVolumesControl.ReadonlyColumn(sTimeX) = True
        Me.EstimatedSurfaceVolumesControl.ReadonlyColumn(sDistX) = True
        Me.EstimatedSurfaceVolumesControl.ReadonlyColumn(sQinX) = True
        Me.EstimatedSurfaceVolumesControl.ReadonlyColumn(sY0) = True
        Me.EstimatedSurfaceVolumesControl.ReadonlyColumn(sAY0) = True
        ' Sigma Y is the only value the user can modify
        Me.EstimatedSurfaceVolumesControl.ReadonlyColumn(sVy) = True

        Me.EstimatedSurfaceVolumesControl.ColumnWidthRatios = New Integer() {3, 3, 3, 3, 3, 4, 3}
        Me.EstimatedSurfaceVolumesControl.EnableSaveActions = True

        ' Elliott-Walker 2-point table
        Me.EW2ptSurfaceVolumesControl.LinkToModel(mMyStore, mEventCriteria.EW2ptEstimatedSurfaceVolumesProperty)
        Me.EW2ptSurfaceVolumesControl.ReadonlyColumn(sTimeX) = True
        Me.EW2ptSurfaceVolumesControl.ReadonlyColumn(sDistX) = True
        Me.EW2ptSurfaceVolumesControl.ReadonlyColumn(sQinX) = True
        Me.EW2ptSurfaceVolumesControl.ReadonlyColumn(sY0) = True
        Me.EW2ptSurfaceVolumesControl.ReadonlyColumn(sAY0) = True
        ' Sigma Y is the only value the user can modify
        Me.EW2ptSurfaceVolumesControl.ReadonlyColumn(sVy) = True
        Me.EW2ptSurfaceVolumesControl.MinRows = 2 ' Two and only two rows for Elliott-Walker 2-Pt
        Me.EW2ptSurfaceVolumesControl.MaxRows = 2

        Me.EW2ptSurfaceVolumesControl.ColumnWidthRatios = New Integer() {3, 3, 3, 3, 3, 4, 3}
        Me.EW2ptSurfaceVolumesControl.EnableSaveActions = True

        mMsgDisplayed = False

        ' Update control's User Interface
        Me.UpdateUI()

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
        UpdateUI()
    End Sub
    '
    ' Update UI when DataStore changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub SoilCropProperties_PropertyChanged(ByVal reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub InflowManagement_PropertyChanged(ByVal reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub EventCriteria_PropertyChanged(ByVal reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
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
    '
    ' Update the FlowDepths control UI
    '
    Public Sub UpdateUI()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mEvaluationWorld IsNot Nothing) Then

            If (mEvaluationWorld.ResetingTabs) Then ' Evaluation World is reseting tab pages; wait
                Return
            End If

            Try
                ' Force the Surface Volume tables to update
                If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                    Dim _param1 As DataTableParameter = mEventCriteria.EW2ptEstimatedSurfaceVolumes
                Else
                    Dim _param1 As DataTableParameter = mEventCriteria.EstimatedSurfaceVolumes
                End If

                ' Surface Volume Table caption
                Dim caption As String = mDictionary.tEstimatedSurfaceVolumes.Translated
                If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                    If (1 < mSystemGeometry.FurrowsPerSet.Value) Then
                        caption &= " - " & mDictionary.tPerFurrow.Translated
                    End If
                End If

                ' Update the rest of the UI
                Me.RoughnessControl.UpdateUI()

                If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                    Me.EstimatedSurfaceVolumesControl.Hide()
                    Me.EW2ptSurfaceVolumesControl.Show()
                    Me.EW2ptSurfaceVolumesControl.UpdateUI()
                    Me.EW2ptSurfaceVolumesControl.CaptionText = caption
                Else
                    Me.EW2ptSurfaceVolumesControl.Hide()
                    Me.EstimatedSurfaceVolumesControl.Show()
                    Me.EstimatedSurfaceVolumesControl.UpdateUI()
                    Me.EstimatedSurfaceVolumesControl.CaptionText = caption
                End If

                Me.UpdateInstructions()

            Catch ex As Exception
            End Try
        End If

    End Sub
    '
    ' Update surface volume use instructions
    '
    Private Sub UpdateInstructions()
        Try
            ' Display instructions
            SurfaceVolumeInstructions.Clear()
            SurfaceVolumeInstructions.SelectionAlignment = HorizontalAlignment.Left

            AppendLine(SurfaceVolumeInstructions, mDictionary.tSurfaceVolumeDescr.Translated)
            AdvanceLine(SurfaceVolumeInstructions)
            AppendLine(SurfaceVolumeInstructions, mDictionary.tImproveSyInstructions.Translated)

            ' Check errors preventing surface volume estimation
            If (mInflowManagement.AppliedVolumeForField <= 0.0) Then ' No inflow specified
                AppendBoldText(SurfaceVolumeInstructions, mDictionary.tError.Translated & " - ")
                AppendLine(SurfaceVolumeInstructions, mDictionary.tNoInflowSpecified.Translated)
            End If

            Dim analysis As Analysis = mEvaluationWorld.CurrentAnalysis
            If (analysis IsNot Nothing) Then

                Dim hasSetupErrors As Boolean = analysis.CheckSetupErrors
                Dim hasSetupWarnings As Boolean = analysis.CheckSetupWarnings

                If (hasSetupErrors) Then
                    AdvanceLine(SurfaceVolumeInstructions)
                    AppendBoldLine(SurfaceVolumeInstructions, mDictionary.tErrors.Translated & ":")
                    AppendLine(SurfaceVolumeInstructions, "  " & mDictionary.tSeeVerifyTabForDetails.Translated)
                End If

                If (hasSetupWarnings) Then
                    AdvanceLine(SurfaceVolumeInstructions)
                    AppendBoldLine(SurfaceVolumeInstructions, mDictionary.tWarnings.Translated & ":")
                    Dim hasVBwarning As Boolean = analysis.HasSetupWarning(analysis.WarningFlags.VolumeBalanceWarning)
                    If (hasVBwarning) Then
                        AppendText(SurfaceVolumeInstructions, "  " & mDictionary.tCannotCalculatePIVB.Translated)
                    End If
                    AppendLine(SurfaceVolumeInstructions, "  " & mDictionary.tSeeVerifyTabForDetails.Translated)
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me)
        UpdateUI()
    End Sub
    '
    ' Resize control's UI to match the new window size
    '
    Private Sub ResizeUI()
        '
        ' Adjust controls on left to match new height
        '
        Me.RoughnessControl.Height = Me.Height - Me.Margin.Top - Me.Margin.Bottom
        Me.RoughnessControl.UpdateUI()

        Me.EstimatedSurfaceVolumesControl.Height = Me.Height - Me.SurfaceVolumeInstructions.Height - 20
        Me.EstimatedSurfaceVolumesControl.Width = Me.Width - Me.RoughnessControl.Width - 16
        Me.EstimatedSurfaceVolumesControl.UpdateUI()

        Me.EW2ptSurfaceVolumesControl.Height = Me.Height - Me.SurfaceVolumeInstructions.Height - 20
        Me.EW2ptSurfaceVolumesControl.Width = Me.Width - Me.RoughnessControl.Width - 16
        Me.EW2ptSurfaceVolumesControl.UpdateUI()

        Me.SurfaceVolumeInstructions.Location = New Point(Me.SurfaceVolumeInstructions.Location.X, _
                                                          Me.Height - Me.SurfaceVolumeInstructions.Height - 8)
        Me.SurfaceVolumeInstructions.Width = Me.EstimatedSurfaceVolumesControl.Width
    End Sub

#End Region

#Region " Data Store Event Handlers "
    '
    ' Estimated Surface Volumes DataTable
    '
    ' Pre-Save Action - After a change to a user value within the Estimated Surface Volumes table, but
    '                   before the table is saved, the calculated values must be updated.
    '
    Private Sub EstimatedSurfaceVolumesControl_PreSaveAction(ByVal SurfaceVolumes As DataTable, ByRef SaveOK As Boolean) _
    Handles EstimatedSurfaceVolumesControl.PreSaveAction
        SaveOK = False

        Try
            If (SurfaceVolumes IsNot Nothing) Then
                SaveOK = mEventCriteria.CalculateEstimatedSurfaceVolumes(SurfaceVolumes)
            End If
        Catch ex As Exception
            SaveOK = False
        End Try

    End Sub

    Private Sub EW2ptSurfaceVolumesControl_PreSaveAction(ByVal SurfaceVolumes As DataTable, ByRef SaveOK As Boolean) _
    Handles EW2ptSurfaceVolumesControl.PreSaveAction
        SaveOK = False

        Try
            If (SurfaceVolumes IsNot Nothing) Then
                SaveOK = mEventCriteria.CalculateEW2ptEstimatedSurfaceVolumes(SurfaceVolumes)
            End If
        Catch ex As Exception
            SaveOK = False
        End Try

    End Sub

#End Region

#Region " UI Event Handers "
    '
    ' Resize contained controls when container control's size changes
    '
    Private Sub ctl_SurfaceVolumeEstimated_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        Me.ResizeUI()
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
