
'*************************************************************************************************************
' RunMultiSimulationsNew Dialog - combines new Sensitivity Analysis capability to the already existing
'                                 RunMultSimulations dialog
'*************************************************************************************************************

Public Class RunMultiSimulationsNew

#Region " Properties "

    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Public Property WinSRFR() As WinSRFR
        Get
            Return mWinSRFR
        End Get
        Set(ByVal value As WinSRFR)
            mWinSRFR = value
            Me.Ctl_SensitivityAnalysisStructered.WinSRFR = mWinSRFR
        End Set
    End Property

    Private mSimulationWorld As SimulationWorld
    Public Property SimulationWorld() As SimulationWorld
        Get
            Return mSimulationWorld
        End Get
        Set(ByVal value As SimulationWorld)
            mSimulationWorld = value
            Me.Ctl_SensitivityAnalysisStructered.SimulationWorld = mSimulationWorld
        End Set
    End Property

#End Region

#Region " Methods "

    ' Both Structured and Unstructered require access to the current Unit
    Public Sub SetUnit(ByVal pUnit As Unit)
        Me.Ctl_SensitivityAnalysisStructered.Initialize(pUnit)
        Me.Ctl_SensitivityAnalysisStructered.WinSRFR = Me.WinSRFR
        Me.Ctl_SensitivityAnalysisStructered.SimulationWorld = Me.SimulationWorld
        Me.Ctl_SensitivityAnalysisUnstructured.WinSRFR = Me.WinSRFR
        Me.Ctl_SensitivityAnalysisUnstructured.SimulationWorld = Me.SimulationWorld
    End Sub

#End Region

#Region " Event Handler(s) "

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) _
        Handles CloseButton.Click
        Me.Hide()
    End Sub

#End Region

End Class
