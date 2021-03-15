
'*************************************************************************************************************
' SimControlsDialogBox - set values for user accessible SRFR Simulation Controls
'*************************************************************************************************************

Public Class SimControlsDialogBox

#Region " Member Data "

    Private mInitializing As Boolean = True

#End Region

#Region " Methods "

    Public Sub InitUI(ByVal SrfrCriteria As SrfrCriteria, ByVal MyStore As DataStore.ObjectNode)
        If ((SrfrCriteria IsNot Nothing) And (MyStore IsNot Nothing)) Then
            mInitializing = True

            Select Case (SrfrCriteria.SolutionModel.Value)
                Case SolutionModels.KinematicWave
                    Me.PhiAYLControl.LinkToModel(MyStore, SrfrCriteria.PhiAYL_KW_Property)
                Case SolutionModels.ZeroInertia
                    Me.PhiAYLControl.LinkToModel(MyStore, SrfrCriteria.PhiAYL_ZI_Property)
                Case Else
                    Debug.Assert(False)
            End Select

            Me.PhiAZLControl.LinkToModel(MyStore, SrfrCriteria.PhiAZLProperty)
            Me.ThetaControl.LinkToModel(MyStore, SrfrCriteria.ThetaProperty)

            mInitializing = False
        End If
    End Sub

#End Region

#Region " UI Event Handler(s) "

    Private Sub PhiAYLControl_ValueChanged() Handles PhiAYLControl.ValueChanged
        If Not (mInitializing) Then
            Me.OkSimControls.Enabled = True
        End If
    End Sub

    Private Sub PhiAZLControl_ValueChanged() Handles PhiAZLControl.ValueChanged
        If Not (mInitializing) Then
            Me.OkSimControls.Enabled = True
        End If
    End Sub

    Private Sub ThetaControl_ValueChanged() Handles ThetaControl.ValueChanged
        If Not (mInitializing) Then
            Me.OkSimControls.Enabled = True
        End If
    End Sub

    Private Sub OkSimControls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkSimControls.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub SimControl_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:SimulationInputs", 0)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:SimulationInputs", 0)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

End Class