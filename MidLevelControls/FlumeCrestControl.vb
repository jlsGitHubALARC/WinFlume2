
'*************************************************************************************************************
' Class FlumeCrestControl - UserControl for displaying & editing the Flume Crest construction
'*************************************************************************************************************
Imports Flume.Globals
Imports WinFlume.WinFlumeForm

Public Class FlumeCrestControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume data
    '
    Private mFlume As Flume.FlumeType = Nothing

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Flume Type & Material
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume data
        If (mFlume Is Nothing) Then ' can't update without Flume data
            Return
        End If

        If Not (Me.Visible) Then ' only update when control is visible
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive call(s)
            Return
        End If
        mUpdatingUI = True

        ' Update Flume Crest Type selections
        Me.StationaryCrestButton.Label = My.Resources.FlumeCrest
        Me.StationaryCrestButton.RbValue = StationaryCrest
        Me.StationaryCrestButton.UiValue = mFlume.CrestType

        Me.MovableCrestButton.Label = My.Resources.FlumeCrest
        Me.MovableCrestButton.RbValue = MovableCrest
        Me.MovableCrestButton.UiValue = mFlume.CrestType

        Me.StandardButton.Label = My.Resources.StandardCustom
        Me.StandardButton.RbValue = WinFlumeForm.StandardCustomChoices.Standard

        Me.CustomButton.Label = My.Resources.StandardCustom
        Me.CustomButton.RbValue = WinFlumeForm.StandardCustomChoices.Custom

        ' Update flume material selection
        Dim standardType As Boolean = False
        Dim liningType As String = mFlume.LiningType.Trim
        Dim liningRoughness As Single = mFlume.LiningRoughness
        Dim defaultRoughness As Single = WinFlumeForm.DefaultFlume.LiningRoughness

        ' If necessary, initialize Standard Material selection
        If (0 = Me.StandardMaterialComboBox.Items.Count) Then
            Me.StandardMaterialComboBox.Items.Add(My.Resources.Glass)
            Me.StandardMaterialComboBox.Items.Add(My.Resources.MetalSmooth)
            Me.StandardMaterialComboBox.Items.Add(My.Resources.MetalRough)
            Me.StandardMaterialComboBox.Items.Add(My.Resources.Wood)
            Me.StandardMaterialComboBox.Items.Add(My.Resources.ConcreteSmooth)
            Me.StandardMaterialComboBox.Items.Add(My.Resources.ConcreteRough)
            Me.StandardMaterialComboBox.Items.Add(My.Resources.FiberglassGelCoat)

            Me.StandardRoughnessHeight.SiDefaultValue = defaultRoughness
            Me.StandardRoughnessHeight.SiValue = liningRoughness
            Me.StandardRoughnessHeight.SingleText.ReadOnly = True
        End If

        ' Update Standard material selections
        For mdx As Integer = 0 To Me.StandardMaterialComboBox.Items.Count - 1
            Dim stdLining As String = CStr(Me.StandardMaterialComboBox.Items(mdx)).Trim
            Dim stdRoughness As Single = WinFlumeForm.cmRoughness(mdx)

            If (stdLining = liningType) Then
                If (ThisClose(stdRoughness, liningRoughness, 0.00000001)) Then
                    ' Flume contains a Standard material selection; select it
                    Me.CustomMaterialTextBox.Enabled = False
                    Me.CustomRoughnessHeight.Enabled = False

                    Me.StandardMaterialComboBox.Enabled = True
                    Me.StandardRoughnessHeight.Enabled = True

                    Me.StandardMaterialComboBox.Value = mdx
                    Me.StandardMaterialComboBox.DefaultValue = SurfaceRoughnesses.ConcreteSmooth

                    Me.StandardRoughnessHeight.SiDefaultValue = defaultRoughness
                    Me.StandardRoughnessHeight.SiValue = liningRoughness

                    Me.CustomButton.UiValue = WinFlumeForm.StandardCustomChoices.Standard
                    Me.StandardButton.UiValue = WinFlumeForm.StandardCustomChoices.Standard

                    standardType = True
                    Exit For
                End If
            End If
        Next mdx

        ' Update Custom material selection
        If Not (standardType) Then

            Me.StandardMaterialComboBox.Enabled = False
            Me.StandardRoughnessHeight.Enabled = False

            Me.CustomMaterialTextBox.Enabled = True
            Me.CustomRoughnessHeight.Enabled = True

            Me.CustomMaterialTextBox.Label = My.Resources.CustomMaterial
            Me.CustomMaterialTextBox.Text = liningType
            Me.CustomRoughnessHeight.SiDefaultValue = defaultRoughness
            Me.CustomRoughnessHeight.SiValue = liningRoughness

            Me.StandardButton.UiValue = WinFlumeForm.StandardCustomChoices.Custom
            Me.CustomButton.UiValue = WinFlumeForm.StandardCustomChoices.Custom
        End If

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

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub StationaryCrestButton_ValueChanged(ByVal NewValue As Integer) _
    Handles StationaryCrestButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.CrestType = NewValue) Then
                mFlume.CrestType = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MovableCrestButton_ValueChanged(ByVal NewValue As Integer) _
    Handles MovableCrestButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.CrestType = NewValue) Then
                mFlume.CrestType = NewValue
                Select Case (mFlume.CrestType)
                    Case StationaryCrest
                    ' Nothing to do
                    Case MovableCrest
                        ' Control Section limited to Rectangular or V-in-Rectangle
                        Dim cSection = mFlume.Section(cControl)                     ' Control Section data
                        If Not (cSection.Shape = shVInRectangle) Then
                            cSection.Shape = shRectangular
                        End If
                    Case Else
                        Debug.Assert(False, "Invalid Crest Type")
                End Select
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Handle Standard/Custom material selection changes
    '*********************************************************************************************************

    Private Sub UpdateStandardCustom(ByVal NewValue As Integer)

        If (NewValue = WinFlumeForm.StandardCustomChoices.Standard) Then
            ' Save new Flume Crest material selection
            Dim mdx As Integer = Math.Max(0, Me.StandardMaterialComboBox.SelectedIndex)
            mFlume.LiningType = CStr(Me.StandardMaterialComboBox.Items(mdx))
            mFlume.LiningRoughness = WinFlumeForm.cmRoughness(mdx)
            mWinFlumeForm.RaiseFlumeDataChanged()
        ElseIf (NewValue = WinFlumeForm.StandardCustomChoices.Custom) Then
            ' Check if a custom material has been entered
            Dim cstLining As String = Me.CustomMaterialTextBox.Text.Trim
            Dim cstRoughness As Single = Me.CustomRoughnessHeight.SiValue

            ' Check if custom name matches a standard name
            For mdx As Integer = 0 To Me.StandardMaterialComboBox.Items.Count - 1
                Dim stdLining As String = CStr(Me.StandardMaterialComboBox.Items(mdx)).Trim
                If (stdLining = cstLining) Then ' match: modify custom name
                    cstLining &= " [" & My.Resources.Custom.ToLower & "]"
                    Exit For
                End If
            Next mdx

            ' Save new custom Flume Crest material selection
            mFlume.LiningType = cstLining
            mFlume.LiningRoughness = cstRoughness
            mWinFlumeForm.RaiseFlumeDataChanged()
        Else
            Debug.Assert(False)
        End If

    End Sub

    ' Standard meterial selection
    Private Sub StandardButton_ValueChanged(ByVal NewValue As Integer) Handles StandardButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore events during UI update
            If (mUpdatingUI) Then
                Return
            End If
            UpdateStandardCustom(NewValue)
        End If
    End Sub

    Private Sub StandardMaterialComboBox_ValueChangedd() Handles StandardMaterialComboBox.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore events during UI update
            If (mUpdatingUI) Then
                Return
            End If
            ' Save new Flume Crest material selection
            Dim mdx As Integer = Math.Max(0, Me.StandardMaterialComboBox.SelectedIndex)
            mFlume.LiningType = CStr(Me.StandardMaterialComboBox.Items(mdx))
            mFlume.LiningRoughness = WinFlumeForm.cmRoughness(mdx)
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    ' Custom material selection
    Private Sub CustomButton_ValueChanged(ByVal NewValue As Integer) Handles CustomButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore events during UI update
            If (mUpdatingUI) Then
                Return
            End If
            UpdateStandardCustom(NewValue)
        End If
    End Sub

    Private Sub CustomMaterialTextBox_ValueChanged() Handles CustomMaterialTextBox.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore events during UI update
            If (mUpdatingUI) Then
                Return
            End If

            Dim cstLining As String = Me.CustomMaterialTextBox.Value
            If Not (mFlume.LiningType = cstLining) Then ' no change
                ' Check if custom name matches a standard name
                For mdx As Integer = 0 To Me.StandardMaterialComboBox.Items.Count - 1
                    Dim stdLining As String = CStr(Me.StandardMaterialComboBox.Items(mdx)).Trim
                    If (stdLining = cstLining) Then ' match: modify custom name
                        cstLining &= " [" & My.Resources.Custom.ToLower & "]"
                        Exit For
                    End If

                    ' Save new Flume Crest material selection
                    mFlume.LiningType = cstLining
                    mWinFlumeForm.RaiseFlumeDataChanged()
                Next mdx
            End If
        End If
    End Sub

    Private Sub CustomRoughnessHeight_ValueChanged() Handles CustomRoughnessHeight.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore events during UI update
            If (mUpdatingUI) Then
                Return
            End If
            ' Save new Flume Crest material selection
            mFlume.LiningRoughness = Me.CustomRoughnessHeight.SiValue
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub FlumeCrestControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub FlumeCrestControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize

    End Sub

#End Region

End Class
