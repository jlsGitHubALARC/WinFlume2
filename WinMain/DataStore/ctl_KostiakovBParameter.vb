
'*************************************************************************************************************
' ctl_KostiakovBParameter - DataStore enabled UserControl
'
' ctl_KostiakovBParameter is subclassed from ctl_DoubleParameter to provide alternate DisplayUnit handling.
'*************************************************************************************************************
Imports DataStore

Public Class ctl_KostiakovBParameter
    Inherits DataStore.ctl_DoubleParameter

#Region " Member Data "

    Private mTranslator As Translator = Translator.Instance

#End Region

#Region " Methods "
    '
    ' Get a copy of the Kostiakov b parameter from DataStore
    '
    Private Function DataParameter() As KostiakovBParameter
        Dim _parameter As Parameter = mProperty.GetParameter

        If (_parameter.GetType Is GetType(KostiakovBParameter)) Then
            Dim _kostiakovB As KostiakovBParameter = DirectCast(_parameter, KostiakovBParameter)
            Dim _copy As KostiakovBParameter = New KostiakovBParameter(_kostiakovB)
            Return _copy
        ElseIf (_parameter.GetType Is GetType(DoubleParameter)) Then
            Dim _double As DoubleParameter = DirectCast(_parameter, DoubleParameter)
            Dim _copy As KostiakovBParameter = New KostiakovBParameter(_double)
            Return _copy
        Else
            Debug.Assert(False, "Invalid parameter type")
            Return Nothing
        End If
    End Function
    '
    ' Units
    '
    Public Shadows Function DisplayUnits() As Units

        ' Have alternate units been selected?
        If (mAltUnits <> UnitsDefinition.Units.None) Then ' yes, use them
            DisplayUnits = mAltUnits
        Else ' no, use units defined in parameter
            Dim KostiakovB As KostiakovBParameter = Me.DataParameter()
            DisplayUnits = KostiakovB.DisplayUnits
        End If

    End Function

#End Region

#Region " UI Update Methods "
    '
    ' Save the TextBox data as a new value
    '
    Protected Overrides Sub SaveNewValue()
        If Not (mProperty Is Nothing) Then

            ' Prevent this method from being called while it is already executing.
            ' This can happen since it is called from UI Event handlers.
            If Not (mSavingNewValue) Then
                mSavingNewValue = True

                ' Get Parameter associated with this control
                Dim _kostiakovB As KostiakovBParameter = Me.DataParameter()
                Dim _value As Double = _kostiakovB.Value

                ' Get current display units
                Dim _units As Units = Me.DisplayUnits

                ' Don't process UI if parameter is a constant
                If Not (_kostiakovB.Source = ValueSources.Constant) Then
                    ' Process text input
                    If (TextBox.Text.Length = 0) Then
                        ' Text Box is empty; user set value to undefined
                        _kostiakovB.SetValue(0.0, _units)
                        _kostiakovB.Source = ValueSources.Undefined

                        mMyStore.MarkForUndo(mTranslator.tClearValue.Translated)
                        mProperty.SetParameter(_kostiakovB)
                        SetError("")

                        ' Let others know of this change so dependent changes can be made
                        RaiseControlValueChangedEvent()
                    Else
                        ' Text Box contains a string; has it changed?
                        If Not (TextBox.Text = mTextBoxText) Then
                            ' This is a new value; save it if it is valid
                            If (Parsable()) Then
                                _value = ParsedValue()
                                _kostiakovB.SetValue(_value, _units)
                                _kostiakovB.Source = ValueSources.UserEntered

                                mMyStore.MarkForUndo(mTranslator.tSetValue.Translated)
                                mProperty.SetParameter(_kostiakovB)

                                ' Record change as Script command
                                DataStore.DataStore.RecordScript(_kostiakovB)

                                ' Let others know of this change so dependent changes can be made
                                RaiseControlValueChangedEvent()
                            Else
                                ' Non-parsable value; reject it
                                MsgBox("'" + TextBox.Text + "' is not a valid value", MsgBoxStyle.Exclamation)
                                UpdateUI()
                            End If
                        End If
                    End If
                End If

                mSavingNewValue = False
            End If
        End If
    End Sub

    Public Overrides Sub UpdateUI()
        If Not (mProperty Is Nothing) Then
            ' Get Parameter associated with this control
            Dim _kostiakovB As KostiakovBParameter = Me.DataParameter
            Dim _value As String = _kostiakovB.Text(Me.DisplayUnits)
            Dim _units As String = UnitsText(Me.DisplayUnits)

            ' All source types (except Constant) are editable
            TextBox.ReadOnly = False
            'TextBox.TextAlign = HorizontalAlignment.Left
            TextBox.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
            TextBox.Top = 0

            ' Set Background color with source color
            Dim _color As System.Drawing.Color = BackColor_Undefined()

            Select Case _kostiakovB.Source
                Case ValueSources.Constant
                    _color = System.Drawing.SystemColors.Control
                    TextBox.ReadOnly = True
                    'TextBox.TextAlign = HorizontalAlignment.Right
                    TextBox.BorderStyle = Windows.Forms.BorderStyle.None
                    TextBox.Top = 4
                Case ValueSources.Calculated
                    _color = BackColor_Calculated()
                Case ValueSources.Defaulted
                    _color = BackColor_Defaulted()
                Case ValueSources.UserEntered
                    _color = BackColor_UserEntered()
                Case ValueSources.Errored
                    _color = BackColor_Errored()
                Case ValueSources.Remote
                    _color = BackColor_Remote()
                Case Else ' Assume ValueSources.Undefined
                    _value = String.Empty
            End Select

            ' Always display Errored back color when there is an error message
            If Not (mErrMsg = String.Empty) Then
                _color = BackColor_Errored()
            End If

            ' Limit value text to seven characters
            If (7 < _value.Length) Then
                _value = _value.Substring(0, 7)
            End If

            ' Update UI
            TextBox.Enabled = True
            If (mProperty.ToBeCalculated) Then
                TextBox.Enabled = False
                _color = BackColor_Calculated()
                _value = "TBD"
            End If

            TextBox.BackColor = _color
            TextBox.Text = _value
            mTextBoxText = _value
            UnitsLabel.Text = _units
        End If
    End Sub

#End Region

#Region " UI Events & Handlers "
    '
    ' Allow units to be changed via a right-click context menu
    '
    Protected Overrides Sub Units_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        'Handles UnitsLabel.MouseUp

        Dim _mousePoint As Point = New Point(e.X, e.Y)

        Select Case (e.Button)
            Case MouseButtons.Right
                ' Get Parameter associated with this control
                Dim _kostiakovB As KostiakovBParameter = Me.DataParameter()

                ' Get the Units strings associated with this Kostiakov b Parameter
                Dim _units As Units = _kostiakovB.DisplayUnits
                If Not (mAltUnits = UnitsDefinition.Units.None) Then
                    _units = mAltUnits
                End If

                Dim _unitStrings() As String = UnitStrings(_units)
                Dim _numUnits As Integer = _unitStrings.Length

                ' Build context menu if a choice of Units is available (i.e. more than 1)
                If (1 < _numUnits) Then
                    ' Build the Units' context menu
                    UnitsMenu.MenuItems.Clear()

                    For _idx As Integer = 0 To _numUnits - 1
                        UnitsMenu.MenuItems.Add(_unitStrings(_idx), AddressOf UnitsMenu_Click)

                        If (UnitsText(_units) = _unitStrings(_idx)) Then
                            UnitsMenu.MenuItems(_idx).Checked = True
                        End If
                    Next

                    ' Display the Units' context menu
                    UnitsMenu.Show(UnitsLabel, _mousePoint)
                End If
        End Select

    End Sub

    Protected Overrides Sub UnitsMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Handles UnitsMenu.Click (menu items are dynamically created)

        ' Sender should be UnitsMenu
        If (sender.GetType Is GetType(MenuItem)) Then
            Dim _menuItem As MenuItem = DirectCast(sender, MenuItem)

            ' Find the index of the selected menu item
            Dim _idx As Integer = _menuItem.Index

            ' Get Parameter associated with this control
            Dim _kostiakovB As KostiakovBParameter = Me.DataParameter()

            ' Save the Alternate Display Units associated with this Double Parameter
            mAltUnits = CType(_kostiakovB.Units + _idx, Units)

            ' If User set units back to original, set Alt Units to None.
            '   This enables the units to follow UnitsSystem changes
            If (mAltUnits = _kostiakovB.DisplayUnits) Then
                mAltUnits = UnitsDefinition.Units.None
            End If

            ' Update the UI to reflect the new units
            UpdateUI()

        End If

    End Sub

#End Region

End Class
