
'**********************************************************************************************
' ctl_StandardHydrograph - UI for viewing & editing the Standard Hydrograph inflow data
'
Imports DataStore
Imports DataStore.DataStore

Public Class ctl_StandardHydrograph

#Region " Control / Model Linkage "
    '
    ' References to model objects
    '
    Private mUnit As Unit = Nothing
    Private WithEvents mInflowManagement As InflowManagement = Nothing

    Private mDictionary As Dictionary = Nothing
    Private mMyStore As DataStore.ObjectNode = Nothing

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    '
    ' Establish links to model objects and update UI
    '
    Public Sub LinkToModel(ByVal _unit As Unit)
        Debug.Assert((_unit IsNot Nothing)) ' Unit is Nothing

        ' Link this control to its data model and store
        mUnit = _unit
        mInflowManagement = mUnit.InflowManagementRef

        mDictionary = Dictionary.Instance
        mMyStore = mUnit.MyStore

        ' Standard Hydrograph controls
        InflowRateControl.LinkToModel(mMyStore, mInflowManagement.InflowRateProperty)

        CutoffMethodControl.LinkToModel(mMyStore, mInflowManagement.CutoffMethodProperty)
        CutoffTimeControl.LinkToModel(mMyStore, mInflowManagement.CutoffTimeProperty)
        CutoffLocationControl.LinkToModel(mMyStore, mInflowManagement.CutoffLocationRatioProperty)
        InfiltrationDepthControl.LinkToModel(mMyStore, mInflowManagement.CutoffInfiltrationDepthProperty)
        OpportunityTimeControl.LinkToModel(mMyStore, mInflowManagement.CutoffOpportunityTimeProperty)
        UpstreamDepthControl.LinkToModel(mMyStore, mInflowManagement.CutoffUpstreamDepthProperty)

        CutbackMethodControl.LinkToModel(mMyStore, mInflowManagement.CutbackMethodProperty)
        CutbackTimeControl.LinkToModel(mMyStore, mInflowManagement.CutbackTimeRatioProperty)
        CutbackLocationControl.LinkToModel(mMyStore, mInflowManagement.CutbackLocationRatioProperty)
        CutbackRateControl.LinkToModel(mMyStore, mInflowManagement.CutbackRateRatioProperty)

        ' Update language translation
        UpdateLanguage() ' also calls UpdateUI()

    End Sub
    '
    ' Update UI when Inflow Management values change
    '
    Private Sub InflowManagement_PropertyChanged(ByVal _reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Public Sub UpdateUI()
        ' Update the UI only if it is linked to a model object
        If (mUnit IsNot Nothing) Then
            UpdateCutoff()
        End If
    End Sub
    '
    ' Update Cutoff selection list & selection
    '
    Private Sub UpdateCutoff()

        ' Update selection lists
        Dim _cutoffMethod As Integer = mInflowManagement.CutoffMethod.Value
        Dim _sel As String = String.Empty
        Dim _idx As Integer = 0

        CutoffMethodControl.Clear()

        Dim _selOk As Boolean = mInflowManagement.GetFirstCutoffMethodSelection(_sel)
        While Not (_sel Is Nothing)
            If (_selOk) Then
                CutoffMethodControl.Add(_sel, _idx, True)
            ElseIf (_cutoffMethod = _idx) Then
                CutoffMethodControl.Add(_sel, _idx, False)
            End If
            _selOk = mInflowManagement.GetNextCutoffMethodSelection(_sel)
            _idx += 1
        End While

        ' Update selections
        CutoffMethodControl.UpdateUI()

        ' Hide / Show UI panels & controls
        Select Case mInflowManagement.CutoffMethod.Value

            Case CutoffMethods.TimeBased
                CutoffLocationPanel.Hide()
                CutoffUpstreamDepthPanel.Hide()
                CutoffTimePanel.Show()

            Case CutoffMethods.DistanceBased
                CutoffTimePanel.Hide()
                CutoffUpstreamDepthPanel.Hide()
                CutoffLocationPanel.Show()

                InfiltrationDepthLabel.Hide()
                InfiltrationDepthControl.Hide()
                OpportunityTimeLabel.Hide()
                OpportunityTimeControl.Hide()

            Case CutoffMethods.DistanceInfDepth
                CutoffTimePanel.Hide()
                CutoffUpstreamDepthPanel.Hide()
                CutoffLocationPanel.Show()

                InfiltrationDepthLabel.Show()
                InfiltrationDepthControl.Show()
                OpportunityTimeLabel.Hide()
                OpportunityTimeControl.Hide()

            Case CutoffMethods.DistanceOppTime
                CutoffTimePanel.Hide()
                CutoffUpstreamDepthPanel.Hide()
                CutoffLocationPanel.Show()

                InfiltrationDepthLabel.Hide()
                InfiltrationDepthControl.Hide()
                OpportunityTimeLabel.Show()
                OpportunityTimeControl.Show()

            Case Else ' Assume CutoffMethods.UpstreamInfDepth
                CutoffTimePanel.Hide()
                CutoffLocationPanel.Hide()
                CutoffUpstreamDepthPanel.Show()
        End Select

        ' Cutoff effects Cutback
        UpdateCutback()

    End Sub
    '
    ' Update Cutback selection list & selection
    '
    Private Sub UpdateCutback()

        ' Update selection list
        Dim _cutbackMethod As Integer = mInflowManagement.CutbackMethod.Value
        Dim _sel As String = String.Empty
        Dim _idx As Integer = 0

        CutbackMethodControl.Clear()

        Dim _selOk As Boolean = mInflowManagement.GetFirstCutbackMethodSelection(_sel)
        While Not (_sel Is Nothing)
            If (_selOk) Then
                CutbackMethodControl.Add(_sel, _idx, True)
            ElseIf (_cutbackMethod = _idx) Then
                CutbackMethodControl.Add(_sel, _idx, False)
            End If
            _selOk = mInflowManagement.GetNextCutbackMethodSelection(_sel)
            _idx += 1
        End While

        ' Update selection
        CutbackMethodControl.SetError("")
        If (CutoffMethods.TimeBased < mInflowManagement.CutoffMethod.Value) Then
            ' Distance-Based Cutoff; can't be Time-Based Cutback
            If (mInflowManagement.CutbackMethod.Value = CutbackMethods.TimeBased) Then
                CutbackMethodControl.SetError(mDictionary.tErrCutbackCantBeTimeBased.Translated)
            End If
        End If
        CutbackMethodControl.UpdateUI()

        ' Hide / Show UI panels & controls
        Select Case mInflowManagement.CutbackMethod.Value

            Case CutbackMethods.TimeBased
                CutbackPanel.Show()

                CutbackTimeLabel.Show()
                CutbackTimeControl.Show()
                CutbackLocationLabel.Hide()
                CutbackLocationControl.Hide()

            Case CutbackMethods.DistanceBased
                CutbackPanel.Show()

                CutbackTimeLabel.Hide()
                CutbackTimeControl.Hide()
                CutbackLocationLabel.Show()
                CutbackLocationControl.Show()

            Case Else ' No Cutback
                CutbackPanel.Hide()

        End Select

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me)
        UpdateUI()
    End Sub

#End Region

End Class
