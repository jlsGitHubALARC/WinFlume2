
'*************************************************************************************************************
' Class BasisManning1QHControl - UserControl for displaying & editing a tailwater calculation method:
'                                   Manning's equations using 1 Q-y2 measurement
'*************************************************************************************************************
Public Class BasisManning1QHControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mSection As Flume.SectionType = Nothing

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Approach cross section
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                             ' Flume data
        If (mFlume Is Nothing) Then
            Return
        End If

        ' Update Discharge/Tailwater Level control pairs (1QH uses entry 0)
        Me.Discharge0.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterQ(0)
        Me.Discharge0.SiValue = mFlume.TailwaterQ(0)
        Me.Discharge0.SiUnits = WinFlumeForm.SiDischargeUnitsText
        Me.Discharge0.Label = Me.DischargeLabel.Text

        Dim ErrMsg As String = ""
        If (mFlume.TailwaterQ(0) <= 0) Then
            ErrMsg = My.Resources.MsgDischargeLeZero
        End If
        Me.Discharge0.SetError(ErrMsg)

        Me.TailwaterLevel0.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterH(0)
        Me.TailwaterLevel0.SiValue = mFlume.TailwaterH(0)
        Me.TailwaterLevel0.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.TailwaterLevel0.Label = Me.TailwaterLevelLabel.Text

        ErrMsg = ""
        If (mFlume.TailwaterH(0) <= 0) Then
            ErrMsg = My.Resources.MsgLevelLeZero
        End If
        Me.TailwaterLevel0.SetError(ErrMsg)

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Protected Sub Discharge0_ValueChanged() Handles Discharge0.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim discharge As Single = Me.Discharge0.SiValue
            If Not (mFlume.TailwaterQ(0) = discharge) Then
                mFlume.TailwaterQ(0) = discharge
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub TailwaterLevel0_ValueChanged() Handles TailwaterLevel0.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim tailwaterLevel As Single = Me.TailwaterLevel0.SiValue
            If Not (mFlume.TailwaterH(0) = tailwaterLevel) Then
                mFlume.TailwaterH(0) = tailwaterLevel
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub BasisManning1QHControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub BasisManning1QHControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize

        Dim roomY As Integer = Me.Height - (Me.Discharge0.Location.Y + Me.Discharge0.Height + Me.Margin.Vertical)

        If (Me.HelpLabel.Height < roomY) Then
            Me.HelpLabel.Show()
        Else
            Me.HelpLabel.Hide()
        End If

    End Sub

#End Region

End Class
