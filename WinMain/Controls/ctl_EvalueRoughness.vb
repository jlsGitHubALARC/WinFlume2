
'*************************************************************************************************************
' ctl_EvalueRoughness - UI for viewing & editing the EVALUE Roughness Estimations
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI
Imports Srfr

Public Class ctl_EvalueRoughness

#Region " Member Data "

    ' Display instsructions using selected language
    Private mDictionary As Dictionary = Dictionary.Instance

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
    '
    ' Access to UI
    '
    Private mEvaluationWorld As EvaluationWorld

    ' Link contained data controls
    Public Sub LinkToModel(ByVal MyUnit As Unit, ByVal MyWindow As WorldWindow)

        ' Link this control to its data model and store
        mUnit = MyUnit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mEvaluationWorld = MyWindow

        Me.EvalueRoughnessFlowDepths.LinkToModel(MyUnit, MyWindow)

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
        Me.UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "

    Private Sub UpdateUI()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mEvaluationWorld IsNot Nothing) Then
            If (mEvaluationWorld.ResetingTabs) Then ' Evaluation World is reseting tab pages; wait
                Return
            End If

            Me.EvalueRoughnessFlowDepths.UpdateUI()

            UpdateInstructions()

        End If
    End Sub

    ' Update the current Roughness Estimation instructions
    Private Sub UpdateInstructions()
        Me.EvalueRoughnessInstructions.Text = mDictionary.tEvalueRoughnessFlowDepthsInstructions.Translated
    End Sub

    ' Update the current language translation
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
    End Sub

    ' Resize contained controls to follow Size changes
    Private Sub ResizeUI()
        Me.EvalueRoughnessInstructions.Width = Me.Width - (2 * Me.EvalueRoughnessInstructions.Location.X)

        Me.EvalueRoughnessFlowDepths.Width = Me.Width - Me.EvalueRoughnessFlowDepths.Location.X
        Me.EvalueRoughnessFlowDepths.Height = Me.Height - Me.EvalueRoughnessFlowDepths.Location.Y
    End Sub

#End Region

#Region " UI Event Handlers "

    ' Resize display
    Private Sub ctl_EvalueInfiltration_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
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
