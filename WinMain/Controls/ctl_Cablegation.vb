
'**********************************************************************************************
' ctl_Cablegation - UI for viewing & editing the Cablegation inflow data
'
Imports DataStore
Imports DataStore.DataStore

Public Class ctl_Cablegation

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

        ' Cablegation controls
        Me.TotalInflowControl.LinkToModel(mMyStore, mInflowManagement.TotalInflowProperty)
        Me.PeakFlowControl.LinkToModel(mMyStore, mInflowManagement.PeakOrificeFlowProperty)
        Me.CutoffFlowControl.LinkToModel(mMyStore, mInflowManagement.CutoffFlowProperty)
        Me.PipeSlopeControl.LinkToModel(mMyStore, mInflowManagement.PipeSlopeProperty)
        Me.PipeDiameterControl.LinkToModel(mMyStore, mInflowManagement.PipeDiameterProperty)
        Me.OrificeEquivalentDiameterControl.LinkToModel(mMyStore, mInflowManagement.OrificeDiameterProperty)
        Me.OrificeSpacingControl.LinkToModel(mMyStore, mInflowManagement.OrificeSpacingProperty)
        Me.PlugSpeedControl.LinkToModel(mMyStore, mInflowManagement.PlugSpeedProperty)
        Me.HazenWilliamsControl.LinkToModel(mMyStore, mInflowManagement.HazenWilliamsPipeCoefficientProperty)

        Me.OrificeEquivalentDiameterButton.LinkToModel(mMyStore, mInflowManagement.OrificeOptionProperty, OrificeOptions.EquivalentDiameter)
        Me.PeakFlowButton.LinkToModel(mMyStore, mInflowManagement.OrificeOptionProperty, OrificeOptions.PeakFlow)

        ' Update Orifice Options command strings
        Dim orificeOption As PropertyNode = mInflowManagement.OrificeOptionProperty
        Dim _sel As String = mInflowManagement.GetFirstOrificeOptionSelection
        Dim _idx As Integer = 0
        orificeOption.ClearEnums()
        While (_sel IsNot Nothing)
            If Not (_sel = String.Empty) Then
                orificeOption.AddEnumItem(_sel, _idx, True)
            End If
            _sel = mInflowManagement.GetNextOrificeOptionSelection
            _idx += 1
        End While

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
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mInflowManagement IsNot Nothing) Then
            ' Update selected Orifice Option
            If (mInflowManagement.OrificeOption.Value = OrificeOptions.EquivalentDiameter) Then
                Me.OrificeEquivalentDiameterControl.Enabled = True
                Me.PeakFlowControl.Enabled = False
            Else
                Me.PeakFlowControl.Enabled = True
                Me.OrificeEquivalentDiameterControl.Enabled = False
            End If
        End If
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
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

End Class
