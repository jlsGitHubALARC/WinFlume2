
'*************************************************************************************************************
' Class BasisPower3QHControl - UserControl for displaying & editing a tailwater calculation method:
'                                   Power curve with offset using 3 Q-y2 measurements
'*************************************************************************************************************
Public Class BasisPower3QHControl

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

        ' Update Discharge/Tailwater Level control pairs (3QH uses entries 3-5)
        Me.Discharge0.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterQ(3)
        Me.Discharge0.SiValue = mFlume.TailwaterQ(3)
        Me.Discharge0.SiUnits = WinFlumeForm.SiDischargeUnitsText
        Me.Discharge0.Label = Me.DischargeLabel.Text

        Me.TailwaterLevel0.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterH(3)
        Me.TailwaterLevel0.SiValue = mFlume.TailwaterH(3)
        Me.TailwaterLevel0.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.TailwaterLevel0.Label = Me.TailwaterLevelLabel.Text

        Me.Discharge1.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterQ(4)
        Me.Discharge1.SiValue = mFlume.TailwaterQ(4)
        Me.Discharge1.SiUnits = WinFlumeForm.SiDischargeUnitsText
        Me.Discharge1.Label = Me.DischargeLabel.Text

        Me.TailwaterLevel1.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterH(4)
        Me.TailwaterLevel1.SiValue = mFlume.TailwaterH(4)
        Me.TailwaterLevel1.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.TailwaterLevel1.Label = Me.TailwaterLevelLabel.Text

        Me.Discharge2.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterQ(5)
        Me.Discharge2.SiValue = mFlume.TailwaterQ(5)
        Me.Discharge2.SiUnits = WinFlumeForm.SiDischargeUnitsText
        Me.Discharge2.Label = Me.DischargeLabel.Text

        Me.TailwaterLevel2.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterH(5)
        Me.TailwaterLevel2.SiValue = mFlume.TailwaterH(5)
        Me.TailwaterLevel2.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.TailwaterLevel2.Label = Me.TailwaterLevelLabel.Text

        ' Check for user input errors
        Dim ErrMsg As String = ""

        If (mFlume.TailwaterQ(4) <= mFlume.TailwaterQ(3)) Then
            ErrMsg = My.Resources.MsgQandHmustIncrease
        Else
            ErrMsg = ""
        End If
        Me.Discharge1.SetError(ErrMsg)

        If (mFlume.TailwaterH(4) <= mFlume.TailwaterH(3)) Then
            ErrMsg = My.Resources.MsgQandHmustIncrease
        Else
            ErrMsg = ""
        End If
        Me.TailwaterLevel1.SetError(ErrMsg)

        If (mFlume.TailwaterQ(5) <= mFlume.TailwaterQ(4)) Then
            ErrMsg = My.Resources.MsgQandHmustIncrease
        Else
            ErrMsg = ""
        End If
        Me.Discharge2.SetError(ErrMsg)

        If (mFlume.TailwaterH(5) <= mFlume.TailwaterH(4)) Then
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
    Protected Sub Discharge0_ValueChanged() Handles Discharge0.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim discharge0 As Single = Me.Discharge0.SiValue
            If Not (mFlume.TailwaterQ(3) = discharge0) Then
                mFlume.TailwaterQ(3) = discharge0
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub TailwaterLevel0_ValueChanged() Handles TailwaterLevel0.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim tailwaterLevel As Single = Me.TailwaterLevel0.SiValue
            If Not (mFlume.TailwaterH(3) = tailwaterLevel) Then
                mFlume.TailwaterH(3) = tailwaterLevel
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub Discharge1_ValueChanged() Handles Discharge1.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim discharge1 As Single = Me.Discharge1.SiValue
            If Not (mFlume.TailwaterQ(4) = discharge1) Then
                mFlume.TailwaterQ(4) = discharge1
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub TailwaterLevel1_ValueChanged() Handles TailwaterLevel1.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim tailwaterLevel As Single = Me.TailwaterLevel1.SiValue
            If Not (mFlume.TailwaterH(4) = tailwaterLevel) Then
                mFlume.TailwaterH(4) = tailwaterLevel
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub Discharge2_ValueChanged() Handles Discharge2.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim discharge2 As Single = Me.Discharge2.SiValue
            If Not (mFlume.TailwaterQ(5) = discharge2) Then
                mFlume.TailwaterQ(5) = discharge2
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub TailwaterLevel2_ValueChanged() Handles TailwaterLevel2.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim tailwaterLevel As Single = Me.TailwaterLevel2.SiValue
            If Not (mFlume.TailwaterH(5) = tailwaterLevel) Then
                mFlume.TailwaterH(5) = tailwaterLevel
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub BasisPower3QHControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub BasisPower3QHControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
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
