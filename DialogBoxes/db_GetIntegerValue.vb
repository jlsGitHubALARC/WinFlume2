
'**********************************************************************************************
' db_GetIntegerValue Dialog Box - Get a value from the user in SI units
'
' NOTE - All Properties Get/Set in SI units
'
Public Class db_GetIntegerValue
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal _value As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeGetIntegerValue(_value)

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents InstructionsLabel As System.Windows.Forms.Label
    Friend WithEvents OkayButton As System.Windows.Forms.Button
    Friend WithEvents CancelValueButton As System.Windows.Forms.Button
    Friend WithEvents UserValue As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.InstructionsLabel = New System.Windows.Forms.Label
        Me.OkayButton = New System.Windows.Forms.Button
        Me.CancelValueButton = New System.Windows.Forms.Button
        Me.UserValue = New System.Windows.Forms.NumericUpDown
        CType(Me.UserValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InstructionsLabel
        '
        Me.InstructionsLabel.AccessibleDescription = "Describes type of value to enter"
        Me.InstructionsLabel.AccessibleName = "Instructions"
        Me.HelpProvider.SetHelpString(Me.InstructionsLabel, "Instructions")
        Me.InstructionsLabel.Location = New System.Drawing.Point(16, 16)
        Me.InstructionsLabel.Name = "InstructionsLabel"
        Me.HelpProvider.SetShowHelp(Me.InstructionsLabel, True)
        Me.InstructionsLabel.Size = New System.Drawing.Size(216, 40)
        Me.InstructionsLabel.TabIndex = 0
        Me.InstructionsLabel.Text = "Please enter an Integer value.  Line #2."
        Me.InstructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OkayButton
        '
        Me.OkayButton.AccessibleDescription = "Accepts user value"
        Me.OkayButton.AccessibleName = "OK Button"
        Me.HelpProvider.SetHelpString(Me.OkayButton, "OK Button")
        Me.OkayButton.Location = New System.Drawing.Point(32, 104)
        Me.OkayButton.Name = "OkayButton"
        Me.HelpProvider.SetShowHelp(Me.OkayButton, True)
        Me.OkayButton.Size = New System.Drawing.Size(80, 23)
        Me.OkayButton.TabIndex = 3
        Me.OkayButton.Text = "&Ok"
        '
        'CancelValueButton
        '
        Me.CancelValueButton.AccessibleDescription = "Cancels user value"
        Me.CancelValueButton.AccessibleName = "Cancel Button"
        Me.CancelValueButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.HelpProvider.SetHelpString(Me.CancelValueButton, "Cancel Button")
        Me.CancelValueButton.Location = New System.Drawing.Point(128, 104)
        Me.CancelValueButton.Name = "CancelValueButton"
        Me.HelpProvider.SetShowHelp(Me.CancelValueButton, True)
        Me.CancelValueButton.Size = New System.Drawing.Size(80, 23)
        Me.CancelValueButton.TabIndex = 4
        Me.CancelValueButton.Text = "&Cancel"
        '
        'UserValue
        '
        Me.UserValue.Location = New System.Drawing.Point(80, 64)
        Me.UserValue.Name = "UserValue"
        Me.UserValue.Size = New System.Drawing.Size(80, 23)
        Me.UserValue.TabIndex = 1
        Me.UserValue.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'db_GetIntegerValue
        '
        Me.AcceptButton = Me.OkayButton
        Me.AccessibleDescription = "Gets a value from the user."
        Me.AccessibleName = "Get Value Dialog Box"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CancelValueButton
        Me.ClientSize = New System.Drawing.Size(242, 135)
        Me.Controls.Add(Me.UserValue)
        Me.Controls.Add(Me.CancelValueButton)
        Me.Controls.Add(Me.OkayButton)
        Me.Controls.Add(Me.InstructionsLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.HelpProvider.SetHelpString(Me, "Get Value Dialog Box")
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "db_GetIntegerValue"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Get Value"
        CType(Me.UserValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Properties "

    Public Property Title() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal Value As String)
            Me.Text = Value
        End Set
    End Property

    Public Property Instructions() As String
        Get
            Return InstructionsLabel.Text
        End Get
        Set(ByVal Value As String)
            InstructionsLabel.Text = Value
        End Set
    End Property

    Public ReadOnly Property Value() As Integer
        Get
            Return CInt(UserValue.Value)
        End Get
    End Property

    Public Property MinValue() As Integer
        Get
            Return CInt(UserValue.Minimum)
        End Get
        Set(ByVal Value As Integer)
            UserValue.Minimum = Value
        End Set
    End Property

    Public Property MaxValue() As Integer
        Get
            Return CInt(UserValue.Maximum)
        End Get
        Set(ByVal Value As Integer)
            UserValue.Maximum = Value
        End Set
    End Property

#End Region

#Region " Initialization "

    Private Sub InitializeGetIntegerValue(ByVal _value As Integer)

        ' Save the inputs
        UserValue.Value = _value

        ' Adjust min & max so value is ok
        If (MinValue > Value) Then
            MinValue = Value
        End If

        If (MaxValue < Value) Then
            MaxValue = Value
        End If

        UserValue.Select(0, UserValue.Text.Length)
        UserValue.Focus()

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub OkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkayButton.Click
        ' Return OK & close the dialog box
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub db_GetIntegerValue_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Shown
        Me.UserValue.Focus()
        Me.UserValue.Select(0, 9)
    End Sub

#End Region

End Class
