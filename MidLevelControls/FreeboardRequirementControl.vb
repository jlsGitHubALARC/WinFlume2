
'*************************************************************************************************************
' Class FreeboardRequirementControl - UserControl for displaying & editing the Freeboard Requirement method
'                                     and the required minimum freeboard
'*************************************************************************************************************
Imports Flume.Globals

Public Class FreeboardRequirementControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mDefaultFlume As Flume.FlumeType = Nothing

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Approach cross section
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume data
        If (mFlume Is Nothing) Then
            Return
        End If

        If Not (Me.Visible) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Debug.Assert(False)
            Return
        End If
        mUpdatingUI = True

        mDefaultFlume = WinFlumeForm.DefaultFlume

        ' Update Freeboard Limit Type selections
        Me.FreeboardPercentageButton.Label = My.Resources.FreeboardLimit
        Me.FreeboardPercentageButton.RbValue = WinFlumeForm.FreeboardLimitTypes.PercentageLimit
        Me.FreeboardPercentageButton.UiValue = mFlume.FreeboardLimitType

        Me.FreeboardDistanceButton.Label = My.Resources.FreeboardLimit
        Me.FreeboardDistanceButton.RbValue = WinFlumeForm.FreeboardLimitTypes.DistanceLimit
        Me.FreeboardDistanceButton.UiValue = mFlume.FreeboardLimitType

        ' Update Freeboard Requirement selection
        If (mFlume.FreeboardLimitType = WinFlumeForm.FreeboardLimitTypes.DistanceLimit) Then

            Me.FreeboardPercentageButton.Checked = False
            Me.MinimumPercentageLabel.Enabled = False
            Me.MinimumPercentage.Enabled = False

            Me.FreeboardDistanceButton.Checked = True
            Me.MinimumDistanceLabel.Enabled = True
            Me.MinimumDistance.Enabled = True
            Me.MinimumDistance.Label = Me.MinimumDistanceLabel.Text

        Else ' assume PercentageLimit

            Me.FreeboardDistanceButton.Checked = False
            Me.MinimumDistanceLabel.Enabled = False
            Me.MinimumDistance.Enabled = False

            Me.FreeboardPercentageButton.Checked = True
            Me.MinimumPercentageLabel.Enabled = True
            Me.MinimumPercentage.Enabled = True
            Me.MinimumPercentage.Label = Me.MinimumPercentageLabel.Text

        End If

        Me.AbsoluteDistanceBox.Refresh()
        Me.PercentHeadBox.Refresh()

        ' Update Required Minimum Distance
        Me.MinimumDistance.SiDefaultValue = mDefaultFlume.FreeboardLimit(AbsFreeboardLimit)
        Me.MinimumDistance.SiValue = mFlume.FreeboardLimit(AbsFreeboardLimit)

        ' Update Required Minimum Percentage
        Me.MinimumPercentage.SiDefaultValue = mDefaultFlume.FreeboardLimit(PercentFreeboardLimit)
        Me.MinimumPercentage.SiValue = mFlume.FreeboardLimit(PercentFreeboardLimit)

        mUpdatingUI = False
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub FreeboardDistanceButton_ValueChanged(ByVal NewValue As Integer) _
        Handles FreeboardDistanceButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.FreeboardLimitType = NewValue) Then
                mFlume.FreeboardLimitType = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub FrreeboardPercentageButton__ValueChanged(ByVal NewValue As Integer) _
        Handles FreeboardPercentageButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.FreeboardLimitType = NewValue) Then
                mFlume.FreeboardLimitType = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MinimumDistance_ValueChanged() _
        Handles MinimumDistance.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim minDistance As Single = Me.MinimumDistance.SiValue
            If Not (mFlume.FreeboardLimit(AbsFreeboardLimit) = minDistance) Then
                mFlume.FreeboardLimit(AbsFreeboardLimit) = minDistance
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MinimumPercentage_ValueChanged() _
        Handles MinimumPercentage.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim minPercentage As Single = Me.MinimumPercentage.SiValue
            If Not (mFlume.FreeboardLimit(PercentFreeboardLimit) = minPercentage) Then
                mFlume.FreeboardLimit(PercentFreeboardLimit) = minPercentage
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub MyBase_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub MyBase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize

        ' Size the ComboBox(s)
        Me.AbsoluteDistanceBox.Width = Me.Width - 2 * Me.Margin.Horizontal
        Me.PercentHeadBox.Width = Me.Width - 2 * Me.Margin.Horizontal

        ' Locate the value labels
        Dim dloc As Point = Me.MinimumDistanceLabel.Location
        dloc.X = Me.MinimumDistance.Location.X - Me.MinimumDistanceLabel.Width - Me.Margin.Horizontal
        If (dloc.X < Me.Margin.Horizontal) Then
            dloc.X = Me.Margin.Horizontal
            Me.MinimumDistanceLabel.Location = dloc
            dloc = New Point(Me.MinimumDistanceLabel.Width + Me.Margin.Horizontal, Me.MinimumDistance.Location.Y)
            Me.MinimumDistance.Location = dloc
        Else
            Me.MinimumDistanceLabel.Location = dloc
        End If

        Dim ploc As Point = Me.MinimumPercentageLabel.Location
        ploc.X = Me.MinimumPercentage.Location.X - Me.MinimumPercentageLabel.Width - Me.Margin.Horizontal
        If (ploc.X < Me.Margin.Horizontal) Then
            ploc.X = Me.Margin.Horizontal
            Me.MinimumDistanceLabel.Location = ploc
            ploc = New Point(Me.MinimumDistanceLabel.Width + Me.Margin.Horizontal, Me.MinimumDistance.Location.Y)
            Me.MinimumDistance.Location = ploc
        Else
            Me.MinimumDistanceLabel.Location = ploc
        End If

    End Sub

#End Region

End Class
