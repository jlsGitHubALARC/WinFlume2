
'*************************************************************************************************************
' Class DataComparisonControl - UserControl for comparing the Flume's Design & Calibration with measured data
'*************************************************************************************************************
Public Class DataComparisonControl

#Region " Member Data "
    '
    ' WinFlume's top-level User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm

#End Region

#Region " UI Methods "

    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected Sub UpdateUI()
        If Not (Me.Visible) Then
            Return
        End If

        If (mWinFlumeForm IsNot Nothing) Then
            Me.MeasuredDataEntryControl.UpdateUI(mWinFlumeForm)
            Me.RatingComparisonControl.UpdateUI(mWinFlumeForm)
        End If
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Resize handlers
    '*********************************************************************************************************
    Private Sub Mybase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub DataComparisonControlTabControl_ValueChanged() _
        Handles DataComparisonControlTabControl.ValueChanged
        If (mWinFlumeForm IsNot Nothing) Then
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

#End Region

End Class
