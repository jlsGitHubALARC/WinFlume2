<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DefinitionSketchDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DefinitionSketchDialog))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.ViewStationaryButton = New System.Windows.Forms.RadioButton()
        Me.ViewMovableButton = New System.Windows.Forms.RadioButton()
        Me.StationarySketch = New System.Windows.Forms.PictureBox()
        Me.MovableSketch = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.StationarySketch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MovableSketch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'ViewStationaryButton
        '
        resources.ApplyResources(Me.ViewStationaryButton, "ViewStationaryButton")
        Me.ViewStationaryButton.Checked = True
        Me.ViewStationaryButton.Name = "ViewStationaryButton"
        Me.ViewStationaryButton.TabStop = True
        Me.ViewStationaryButton.UseVisualStyleBackColor = True
        '
        'ViewMovableButton
        '
        resources.ApplyResources(Me.ViewMovableButton, "ViewMovableButton")
        Me.ViewMovableButton.Name = "ViewMovableButton"
        Me.ViewMovableButton.UseVisualStyleBackColor = True
        '
        'StationarySketch
        '
        Me.StationarySketch.Image = Global.WinFlume.My.Resources.Resources.Defsktch
        resources.ApplyResources(Me.StationarySketch, "StationarySketch")
        Me.StationarySketch.Name = "StationarySketch"
        Me.StationarySketch.TabStop = False
        '
        'MovableSketch
        '
        Me.MovableSketch.Image = Global.WinFlume.My.Resources.Resources.Defmovbl
        resources.ApplyResources(Me.MovableSketch, "MovableSketch")
        Me.MovableSketch.Name = "MovableSketch"
        Me.MovableSketch.TabStop = False
        '
        'DefinitionSketchDialog
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.MovableSketch)
        Me.Controls.Add(Me.StationarySketch)
        Me.Controls.Add(Me.ViewMovableButton)
        Me.Controls.Add(Me.ViewStationaryButton)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DefinitionSketchDialog"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.StationarySketch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MovableSketch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ViewStationaryButton As System.Windows.Forms.RadioButton
    Friend WithEvents ViewMovableButton As System.Windows.Forms.RadioButton
    Friend WithEvents StationarySketch As System.Windows.Forms.PictureBox
    Friend WithEvents MovableSketch As System.Windows.Forms.PictureBox

End Class
