
'*************************************************************************************************************
' Class db_GetStringValue Dialog Box - Get a string from the user
'*************************************************************************************************************
Public Class db_GetStringValue
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal value As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeGetIntegerValue(value)

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
    Friend WithEvents InstructionsLabel As System.Windows.Forms.Label
    Friend WithEvents CancelValueButton As System.Windows.Forms.Button
    Friend WithEvents OkayButton As System.Windows.Forms.Button
    Friend WithEvents UserValue As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.InstructionsLabel = New System.Windows.Forms.Label()
        Me.CancelValueButton = New System.Windows.Forms.Button()
        Me.OkayButton = New System.Windows.Forms.Button()
        Me.UserValue = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'InstructionsLabel
        '
        Me.InstructionsLabel.AccessibleDescription = "Describes type of value to enter"
        Me.InstructionsLabel.AccessibleName = "Instructions"
        Me.InstructionsLabel.AutoSize = True
        Me.InstructionsLabel.Location = New System.Drawing.Point(10, 12)
        Me.InstructionsLabel.Name = "InstructionsLabel"
        Me.InstructionsLabel.Size = New System.Drawing.Size(183, 17)
        Me.InstructionsLabel.TabIndex = 0
        Me.InstructionsLabel.Text = "Please enter a String value."
        Me.InstructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CancelValueButton
        '
        Me.CancelValueButton.AccessibleDescription = "Cancels user value"
        Me.CancelValueButton.AccessibleName = "Cancel Button"
        Me.CancelValueButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelValueButton.Location = New System.Drawing.Point(292, 78)
        Me.CancelValueButton.Name = "CancelValueButton"
        Me.CancelValueButton.Size = New System.Drawing.Size(80, 23)
        Me.CancelValueButton.TabIndex = 3
        Me.CancelValueButton.Text = "&Cancel"
        '
        'OkayButton
        '
        Me.OkayButton.AccessibleDescription = "Accepts user value"
        Me.OkayButton.AccessibleName = "OK Button"
        Me.OkayButton.Location = New System.Drawing.Point(10, 78)
        Me.OkayButton.Name = "OkayButton"
        Me.OkayButton.Size = New System.Drawing.Size(80, 23)
        Me.OkayButton.TabIndex = 2
        Me.OkayButton.Text = "&Ok"
        '
        'UserValue
        '
        Me.UserValue.Location = New System.Drawing.Point(10, 40)
        Me.UserValue.Name = "UserValue"
        Me.UserValue.Size = New System.Drawing.Size(362, 23)
        Me.UserValue.TabIndex = 1
        Me.UserValue.Text = "String"
        '
        'db_GetStringValue
        '
        Me.AcceptButton = Me.OkayButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CancelValueButton
        Me.ClientSize = New System.Drawing.Size(384, 111)
        Me.Controls.Add(Me.UserValue)
        Me.Controls.Add(Me.CancelValueButton)
        Me.Controls.Add(Me.OkayButton)
        Me.Controls.Add(Me.InstructionsLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "db_GetStringValue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Get Value"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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

    Public ReadOnly Property Value() As String
        Get
            Return UserValue.Text
        End Get
    End Property

#End Region

#Region " Initialization "

    Private Sub InitializeGetIntegerValue(ByVal value As String)

        ' Save the inputs
        UserValue.Text = value

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

    Private Sub db_GetStringValue_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Shown
        Me.UserValue.Focus()
        Me.UserValue.SelectAll()
    End Sub

#End Region

End Class
