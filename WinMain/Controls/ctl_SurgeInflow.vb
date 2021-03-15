
'**********************************************************************************************
' ctl_SurgeInflow - UI for viewing & editing the Surge inflow data
'
Imports DataStore
Imports DataStore.DataStore

Public Class ctl_SurgeInflow

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

        ' Surge controls
        SurgeStrategyControl.LinkToModel(mMyStore, mInflowManagement.SurgeStrategyProperty)

        SurgeInflowRateControl.LinkToModel(mMyStore, mInflowManagement.SurgeInflowRateProperty)
        NumberOfSurgesControl.LinkToModel(mMyStore, mInflowManagement.NumberOfSurgesProperty)
        SurgeOnTimeControl.LinkToModel(mMyStore, mInflowManagement.SurgeOnTimeProperty)
        SurgeCutoffTimeControl.LinkToModel(mMyStore, mInflowManagement.SurgeCutoffTimeProperty)

        TabulatedTimeControl.LinkToModel(mMyStore, mInflowManagement.SurgeTimesTableProperty)

        TabulatedLocationControl.LinkToModel(mMyStore, mInflowManagement.SurgeLocationsTableProperty)

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
            UpdateSurgeStrategy()
        End If
    End Sub
    '
    ' Update the Surge Strategy selection list & selection
    '
    Private Sub UpdateSurgeStrategy()

        ' Update selection list
        Dim surgeStrategy As Integer = mInflowManagement.SurgeStrategy.Value
        Dim _sel As String = String.Empty
        Dim _idx As Integer = 0

        SurgeStrategyControl.Clear()

        Dim _selOk As Boolean = mInflowManagement.GetFirstSurgeStrategySelection(_sel)
        While Not (_sel Is Nothing)
            If (_selOk) Then
                SurgeStrategyControl.Add(_sel, _idx, True)
            ElseIf (surgeStrategy = _idx) Then
                SurgeStrategyControl.Add(_sel, _idx, False)
            End If
            _selOk = mInflowManagement.GetNextSurgeStrategySelection(_sel)
            _idx += 1
        End While

        ' Update selection
        SurgeStrategyControl.UpdateUI()

        ' Hide / Show correspnding UI panels
        Select Case mInflowManagement.SurgeStrategy.Value

            Case SurgeStrategies.TabulatedTime
                UniformTimePanel.Hide()
                UniformLocationPanel.Hide()
                TabulatedLocationPanel.Hide()
                TabulatedTimePanel.Show()

                UniformTimeSurgeBox.Hide()

                TabulatedTimeControl.UpdateUI()

            Case SurgeStrategies.TabulatedLocation
                UniformTimePanel.Hide()
                UniformLocationPanel.Hide()
                TabulatedTimePanel.Hide()
                TabulatedLocationPanel.Show()

                UniformTimeSurgeBox.Show()

                TabulatedLocationControl.UpdateUI()

            Case SurgeStrategies.UniformLocation
                UniformTimePanel.Hide()
                TabulatedTimePanel.Hide()
                TabulatedLocationPanel.Hide()
                UniformLocationPanel.Show()

                UniformTimeSurgeBox.Show()

            Case Else ' Assume SurgeStrategies.UniformTime
                UniformLocationPanel.Hide()
                TabulatedTimePanel.Hide()
                TabulatedLocationPanel.Hide()
                UniformTimePanel.Show()

                UniformTimeSurgeBox.Show()

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

#Region " UI Event Handlers "
    '
    ' Table updates
    '
    Private Sub TabulatedTimeControl_ControlValueChanged() _
    Handles TabulatedTimeControl.ControlValueChanged
        RaiseEvent ControlChanged(Reasons.TabulatedTimeControl)
    End Sub

    Private Sub TabulatedLocationControl_ControlValueChanged() _
    Handles TabulatedLocationControl.ControlValueChanged
        RaiseEvent ControlChanged(Reasons.TabulatedLocationControl)
    End Sub
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        TabulatedTimeControl
        TabulatedLocationControl

        Other
    End Enum

    Public Event ControlChanged(ByVal _reason As Reasons)

#End Region

End Class
