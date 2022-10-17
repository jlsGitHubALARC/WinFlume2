
'*************************************************************************************************************
' Class BasisPower2QHControl - UserControl for displaying & editing a tailwater calculation method:
'                                   Power curve using 2 Q-y2 measurements
'*************************************************************************************************************
Public Class BasisPower2QHControl

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

        ' Update Discharge/Tailwater Level control pairs (2QH uses entries 1-2)
        Me.Discharge0.SiValue = 0.0!
        Me.Discharge0.SiUnits = WinFlumeForm.SiDischargeUnitsText
        Me.Discharge0.Label = Me.DischargeLabel.Text
        Me.Discharge0.SingleText.ReadOnly = True
        Me.TailwaterLevel0.SiValue = 0.0!
        Me.TailwaterLevel0.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.TailwaterLevel0.Label = Me.TailwaterLevelLabel.Text
        Me.TailwaterLevel0.SingleText.ReadOnly = True

        Me.Discharge1.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterQ(1)
        Me.Discharge1.SiValue = mFlume.TailwaterQ(1)
        Me.Discharge1.SiUnits = WinFlumeForm.SiDischargeUnitsText
        Me.Discharge1.Label = Me.DischargeLabel.Text

        Me.TailwaterLevel1.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterH(1)
        Me.TailwaterLevel1.SiValue = mFlume.TailwaterH(1)
        Me.TailwaterLevel1.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.TailwaterLevel1.Label = Me.TailwaterLevelLabel.Text

        Me.Discharge2.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterQ(2)
        Me.Discharge2.SiValue = mFlume.TailwaterQ(2)
        Me.Discharge2.SiUnits = WinFlumeForm.SiDischargeUnitsText
        Me.Discharge2.Label = Me.DischargeLabel.Text

        Me.TailwaterLevel2.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterH(2)
        Me.TailwaterLevel2.SiValue = mFlume.TailwaterH(2)
        Me.TailwaterLevel2.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.TailwaterLevel2.Label = Me.TailwaterLevelLabel.Text

        ' Check for user input errors
        Dim ErrMsg As String = ""

        If (mFlume.TailwaterQ(1) <= 0) Then
            ErrMsg = My.Resources.MsgQandHmustIncrease
        Else
            ErrMsg = ""
        End If
        Me.Discharge1.SetError(ErrMsg)

        If (mFlume.TailwaterH(1) <= 0) Then
            ErrMsg = My.Resources.MsgQandHmustIncrease
        Else
            ErrMsg = ""
        End If
        Me.TailwaterLevel1.SetError(ErrMsg)

        If (mFlume.TailwaterQ(2) <= mFlume.TailwaterQ(1)) Then
            ErrMsg = My.Resources.MsgQandHmustIncrease
        Else
            ErrMsg = ""
        End If
        Me.Discharge2.SetError(ErrMsg)

        If (mFlume.TailwaterH(2) <= mFlume.TailwaterH(1)) Then
            ErrMsg = My.Resources.MsgQandHmustIncrease
        Else
            ErrMsg = ""
        End If
        Me.TailwaterLevel2.SetError(ErrMsg)

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
    Protected Sub Discharge1_ValueChanged() Handles Discharge1.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim discharge1 As Single = Me.Discharge1.SiValue
            If Not (mFlume.TailwaterQ(1) = discharge1) Then
                mFlume.TailwaterQ(1) = discharge1
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub TailwaterLevel1_ValueChanged() Handles TailwaterLevel1.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim tailwaterLevel As Single = Me.TailwaterLevel1.SiValue
            If Not (mFlume.TailwaterH(1) = tailwaterLevel) Then
                mFlume.TailwaterH(1) = tailwaterLevel
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub Discharge2_ValueChanged() Handles Discharge2.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim discharge2 As Single = Me.Discharge2.SiValue
            If Not (mFlume.TailwaterQ(2) = discharge2) Then
                mFlume.TailwaterQ(2) = discharge2
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub TailwaterLevel2_ValueChanged() Handles TailwaterLevel2.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim tailwaterLevel As Single = Me.TailwaterLevel2.SiValue
            If Not (mFlume.TailwaterH(2) = tailwaterLevel) Then
                mFlume.TailwaterH(2) = tailwaterLevel
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub BasisPower2QHControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub BasisPower2QHControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize

        Dim roomY As Integer = Me.Height - (Me.Discharge2.Location.Y + Me.Discharge2.Height + Me.Margin.Vertical)

        If (Me.HelpLabel.Height < roomY) Then
            Me.HelpLabel.Show()
        Else
            Me.HelpLabel.Hide()
        End If

    End Sub

#End Region

End Class
