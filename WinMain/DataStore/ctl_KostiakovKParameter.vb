
'*************************************************************************************************************
' ctl_KostiakovParameter - DataStore enabled UserControl
'
' Combines a TextBox & a Label in a UserControl to provide a Kostiakov k value with units.
'
' ctl_KostiakovKParameter is subclassed from the Windows.Forms.UserControl to add interaction with
'       a KostiakovK DataStore Property.
'*************************************************************************************************************
Imports DataStore

Public Class ctl_KostiakovKParameter
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents UnitsMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents UnitsLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.TextBox = New System.Windows.Forms.TextBox
        Me.UnitsLabel = New System.Windows.Forms.Label
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UnitsMenu = New System.Windows.Forms.ContextMenu
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox
        '
        Me.TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox.Location = New System.Drawing.Point(0, 0)
        Me.TextBox.Name = "TextBox"
        Me.TextBox.Size = New System.Drawing.Size(64, 23)
        Me.TextBox.TabIndex = 0
        Me.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UnitsLabel
        '
        Me.UnitsLabel.Location = New System.Drawing.Point(64, 0)
        Me.UnitsLabel.Name = "UnitsLabel"
        Me.UnitsLabel.Size = New System.Drawing.Size(96, 23)
        Me.UnitsLabel.TabIndex = 1
        Me.UnitsLabel.Text = "Units"
        Me.UnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'ctl_KostiakovKParameter
        '
        Me.Controls.Add(Me.TextBox)
        Me.Controls.Add(Me.UnitsLabel)
        Me.Name = "ctl_KostiakovKParameter"
        Me.Size = New System.Drawing.Size(160, 24)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Member Data "
    '
    ' My Data Store
    '
    Private mMyStore As ObjectNode = Nothing
    '
    ' Property hosting data for this control
    '
    Private WithEvents mProperty As PropertyNode
    '
    ' Reference to the Units System
    '
    Protected WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance()
    '
    ' Last good TextBox data
    '
    Private mTextBoxText As String = String.Empty
    '
    ' Error message to display for invalid values
    '
    Protected mErrMsg As String = String.Empty
    '
    ' Language Translator
    '
    Protected mTranslator As Translator = Translator.Instance

#End Region

#Region " Control / Model Linkage "
    '
    ' Link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal _myDataStore As ObjectNode, ByVal _property As PropertyNode)
        Debug.Assert((_myDataStore IsNot Nothing) And (_property IsNot Nothing))

        mMyStore = _myDataStore                         ' Save reference to My Data Store
        mProperty = _property                           ' Save reference to Property for this control

        CheckError()                                    ' Check for error in current Value
        UpdateUI()                                      ' Update the UI with the Property data
    End Sub

#End Region

#Region " Methods "
    '
    ' Get a copy of the Kostiakov k parameter from DataStore
    '
    Private Function DataParameter() As KostiakovKParameter
        Dim _parameter As Parameter = mProperty.GetParameter

        If (_parameter.GetType Is GetType(KostiakovKParameter)) Then
            Dim _k As KostiakovKParameter = DirectCast(_parameter, KostiakovKParameter)
            Dim _copy As KostiakovKParameter = New KostiakovKParameter(_k)
            Return _copy
        Else
            Debug.Assert(False, "Invalid parameter type")
            Return Nothing
        End If
    End Function
    '
    ' Units
    '
    Public ReadOnly Property DisplayUnits() As KostiakovKParameter.K_Units
        Get
            Dim _kostiakovK As KostiakovKParameter = Me.DataParameter
            If (_kostiakovK.AltUnits = KostiakovKParameter.K_Units.NoUnits) Then
                Return KostiakovKParameter.DisplayUnits
            Else
                Return _kostiakovK.AltUnits
            End If
        End Get
    End Property
    '
    ' ValueText() - text box text
    '
    Public Property ValueText() As String
        Get
            Return TextBox.Text
        End Get
        Set(ByVal Value As String)
            TextBox.Text = Value
        End Set
    End Property
    '
    ' ValueBackColor() - text box back color
    '
    Public Property ValueBackColor() As System.Drawing.Color
        Get
            Return TextBox.BackColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            TextBox.BackColor = Value
        End Set
    End Property
    '
    ' ValueForeColor() - text box fore color
    '
    Public Property ValueForeColor() As System.Drawing.Color
        Get
            Return TextBox.ForeColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            TextBox.ForeColor = Value
        End Set
    End Property
    '
    ' UnitsBackColor() - units box back color
    '
    Public Property UnitsBackColor() As System.Drawing.Color
        Get
            Return UnitsLabel.BackColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            UnitsLabel.BackColor = Value
        End Set
    End Property
    '
    ' UnitsForeColor() - units box fore color
    '
    Public Property UnitsForeColor() As System.Drawing.Color
        Get
            Return UnitsLabel.ForeColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            UnitsLabel.ForeColor = Value
        End Set
    End Property
    '
    ' Parsable() - validates text is parsable as a Double
    '
    Private Function Parsable() As Boolean
        Try
            Dim val As Double = Double.Parse(TextBox.Text)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    '
    ' ParsedValue() - returns text as parsed Double
    '
    Private Function ParsedValue() As Double
        Try
            Dim val As Double = Double.Parse(TextBox.Text)
            Return val
        Catch ex As Exception
            Return 0.0
        End Try
    End Function
#End Region

#Region " Model Event Handler(s) "
    '
    ' Event handler for property update events from model object
    '
    Public Sub Property_DataChanged(ByVal _reason As PropertyNode.Reasons) _
    Handles mProperty.PropertyDataChanged
        UpdateUI()                      ' Reflect the State Change in the UI
        CheckError()                    ' Check for error in new Value
    End Sub
    '
    ' Unit's System change event handler
    '
    Public Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        ' Re-display with new units
        UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Save the TextBox data as a new value
    '
    Private mSavingNewValue As Boolean = False
    Private Sub SaveNewValue()
        If (mProperty IsNot Nothing) Then

            ' Prevent this method from being called while it is already executing.
            ' This can happen since it is called from UI Event handlers.
            If Not (mSavingNewValue) Then
                mSavingNewValue = True

                ' Get value from model object
                Dim _kostiakovK As KostiakovKParameter = Me.DataParameter
                Dim _value As Double = _kostiakovK.Value

                ' Get current display units
                Dim _units As KostiakovKParameter.K_Units = Me.DisplayUnits

                ' Don't process UI if parameter is a constant
                If Not (_kostiakovK.Source = ValueSources.Constant) Then
                    ' Process text input
                    If (TextBox.Text.Length = 0) Then
                        ' Text Box is empty; user set value to undefined
                        _kostiakovK.SetValue(0.0, _units, _kostiakovK.KostiakovA)
                        _kostiakovK.Source = ValueSources.Undefined

                        mMyStore.MarkForUndo(mTranslator.tClearValue.Translated)
                        mProperty.SetParameter(_kostiakovK)
                        SetError("")

                        ' Let others know of this change so dependent changes can be made
                        RaiseControlValueChangedEvent()
                    Else
                        ' Text Box contains a string; has it changed?
                        If Not (TextBox.Text = mTextBoxText) Then
                            ' This is a new value; save it if it is valid
                            If (Parsable()) Then
                                _value = ParsedValue()
                                _kostiakovK.SetValue(_value, _units, _kostiakovK.KostiakovA)
                                _kostiakovK.Source = ValueSources.UserEntered

                                mMyStore.MarkForUndo(mTranslator.tSetValue.Translated)
                                mProperty.SetParameter(_kostiakovK)

                                ' Record change as Script command
                                DataStore.DataStore.RecordScript(_kostiakovK)

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

    Public Sub UpdateUI()
        If (mProperty IsNot Nothing) Then
            ' Get Parameter associated with this control
            Dim _kostiakovK As KostiakovKParameter = Me.DataParameter
            Dim _value As String = _kostiakovK.Text(Me.DisplayUnits)
            Dim _units As String = KostiakovKParameter.K_UnitsText(Me.DisplayUnits)

            ' All source types (except Constant) are editable
            TextBox.ReadOnly = False
            'TextBox.TextAlign = HorizontalAlignment.Left
            TextBox.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
            TextBox.Top = 0

            ' Set Background color with source color
            Dim _color As System.Drawing.Color = BackColor_Undefined()

            Select Case _kostiakovK.Source
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

    Public Sub CheckError()

        Dim _errMsg As String = String.Empty                        ' Set error message (default to no error)
        Dim _kostiakovK As KostiakovKParameter = Me.DataParameter   ' Get value from model object

        If (_kostiakovK IsNot Nothing) Then
            If Not (_kostiakovK.ValidateValue) Then
                Dim _value As Double = _kostiakovK.Value
                If (_value < _kostiakovK.MinValue) Then
                    _errMsg = String.Format("Value < {0}", _kostiakovK.MinValue)
                ElseIf (_kostiakovK.MaxValue < _value) Then
                    _errMsg = String.Format("{0} < Value", _kostiakovK.MaxValue)
                ElseIf (Double.IsNaN(_value)) Then
                    _errMsg = "Value is Not a Number"
                Else
                    _errMsg = "Value is invalid"
                End If
            End If
        Else
            _errMsg = "Parameter not defined"
        End If

        SetError(_errMsg)
    End Sub

    Public Sub SetError(ByVal _errMsg As String)
        mErrMsg = _errMsg
        ErrorProvider.SetError(TextBox, mErrMsg)
        UpdateUI()
    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub KeyPress_Handler(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox.KeyPress
        ' Absorb KepPress for Return key to suppress beep
        '   Note - setting e.Handled to True in KeyDown handler doesn't suppress beep
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(Windows.Forms.Keys.Return)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Control_ReturnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Return) Then
            ' Enter the new value when the Return key is pressed
            SaveNewValue()

            ' Select all the text so the user can easily re-enter value
            TextBox.Focus()
            TextBox.SelectAll()
        End If
    End Sub

    Private Sub Control_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        SaveNewValue()
    End Sub

    Private Sub Control_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.LostFocus
        SaveNewValue()
    End Sub
    '
    ' Allow units to be changed via a right-click context menu
    '
    Protected Overridable Sub Units_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UnitsLabel.MouseUp

        Dim _mousePoint As Point = New Point(e.X, e.Y)

        Select Case (e.Button)
            Case MouseButtons.Right
                ' Build context menu if a choice of Units is available (i.e. more than 1)
                Dim _numUnits As Integer = KostiakovKParameter.K_UnitsText.Length

                If (1 < _numUnits) Then
                    ' Build the Units' context menu
                    UnitsMenu.MenuItems.Clear()

                    Dim _units As KostiakovKParameter.K_Units = Me.DisplayUnits

                    For _idx As Integer = 0 To _numUnits - 1
                        UnitsMenu.MenuItems.Add(KostiakovKParameter.K_UnitsText(_idx), AddressOf UnitsMenu_Click)

                        If (KostiakovKParameter.K_UnitsText(_units) = KostiakovKParameter.K_UnitsText(_idx)) Then
                            UnitsMenu.MenuItems(_idx).Checked = True
                        End If
                    Next

                    ' Display the Units' context menu
                    UnitsMenu.Show(UnitsLabel, _mousePoint)
                End If
        End Select

    End Sub

    Private Sub UnitsMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles UnitsMenu.Click (menu items are dynamically created)

        ' Sender should be UnitsMenu
        If (sender.GetType Is GetType(MenuItem)) Then
            Dim _menuItem As MenuItem = DirectCast(sender, MenuItem)
            Dim _idx As Integer = _menuItem.Index

            ' Get Parameter associated with this control
            Dim _kostiakovK As KostiakovKParameter = Me.DataParameter

            ' Save the Alternate Display Units associated with this Kostiakov K Parameter
            Dim kUnits As KostiakovKParameter.K_Units = CType(_kostiakovK.KUnits + _idx, KostiakovKParameter.K_Units)

            ' If User set units back to original, set Alt Units to None.
            '   This will enable units to follow UnitsSystem changes
            If (kUnits = KostiakovKParameter.DisplayUnits) Then
                kUnits = KostiakovKParameter.K_Units.NoUnits
            End If

            _kostiakovK.AltUnits = kUnits

            mMyStore.MarkForUndo(mTranslator.tSetUnits.Translated)
            mProperty.SetParameter(_kostiakovK)

            ' Update the UI to reflect the new units
            UpdateUI()

        End If

    End Sub

    Protected Sub RaiseControlValueChangedEvent()
        RaiseEvent ControlValueChanged()
    End Sub

    Public Event ControlValueChanged()

#End Region

End Class
