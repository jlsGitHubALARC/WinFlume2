
'*************************************************************************************************************
' Simulation Graphics Dialog Box - handles both Standard and Advanced settings
'*************************************************************************************************************
Imports DataStore

Public Class SimGraphicsDialogBox
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal _unit As Unit, ByVal _userLevel As UserLevels)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeSimGraphicsDialogBox(_unit, _userLevel)

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
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CancelSimulationGraphics As DataStore.ctl_Button
    Friend WithEvents OkSimulationGraphics As DataStore.ctl_Button
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents StandardPanel As DataStore.ctl_Panel
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents FileMenu As System.Windows.Forms.MenuItem
    Friend WithEvents EditMenu As System.Windows.Forms.MenuItem
    Friend WithEvents EditProfileTableMenu As System.Windows.Forms.MenuItem
    Friend WithEvents EditHydrographTableMenu As System.Windows.Forms.MenuItem
    Friend WithEvents ProfileTimeTableControl As DataStore.ctl_DataTableParameter
    Friend WithEvents HydrographLocationTableControl As DataStore.ctl_DataTableParameter
    Friend WithEvents FileProfileTableMenu As System.Windows.Forms.MenuItem
    Friend WithEvents FileHydrographTableMenu As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.CancelSimulationGraphics = New DataStore.ctl_Button
        Me.OkSimulationGraphics = New DataStore.ctl_Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.StandardPanel = New DataStore.ctl_Panel
        Me.HydrographLocationTableControl = New DataStore.ctl_DataTableParameter
        Me.ProfileTimeTableControl = New DataStore.ctl_DataTableParameter
        Me.MainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.FileMenu = New System.Windows.Forms.MenuItem
        Me.FileProfileTableMenu = New System.Windows.Forms.MenuItem
        Me.FileHydrographTableMenu = New System.Windows.Forms.MenuItem
        Me.EditMenu = New System.Windows.Forms.MenuItem
        Me.EditProfileTableMenu = New System.Windows.Forms.MenuItem
        Me.EditHydrographTableMenu = New System.Windows.Forms.MenuItem
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StandardPanel.SuspendLayout()
        CType(Me.HydrographLocationTableControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProfileTimeTableControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CancelSimulationGraphics
        '
        Me.CancelSimulationGraphics.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelSimulationGraphics.Location = New System.Drawing.Point(341, 248)
        Me.CancelSimulationGraphics.Name = "CancelSimulationGraphics"
        Me.CancelSimulationGraphics.Size = New System.Drawing.Size(75, 24)
        Me.CancelSimulationGraphics.TabIndex = 3
        Me.CancelSimulationGraphics.Text = "&Cancel"
        '
        'OkSimulationGraphics
        '
        Me.OkSimulationGraphics.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OkSimulationGraphics.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkSimulationGraphics.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OkSimulationGraphics.Location = New System.Drawing.Point(16, 248)
        Me.OkSimulationGraphics.Name = "OkSimulationGraphics"
        Me.OkSimulationGraphics.Size = New System.Drawing.Size(75, 24)
        Me.OkSimulationGraphics.TabIndex = 2
        Me.OkSimulationGraphics.Text = "&Ok"
        Me.OkSimulationGraphics.UseVisualStyleBackColor = False
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'StandardPanel
        '
        Me.StandardPanel.Controls.Add(Me.HydrographLocationTableControl)
        Me.StandardPanel.Controls.Add(Me.ProfileTimeTableControl)
        Me.StandardPanel.Location = New System.Drawing.Point(8, 8)
        Me.StandardPanel.Name = "StandardPanel"
        Me.StandardPanel.Size = New System.Drawing.Size(416, 232)
        Me.StandardPanel.TabIndex = 0
        '
        'HydrographLocationTableControl
        '
        Me.HydrographLocationTableControl.AllRowsFixed = False
        Me.HydrographLocationTableControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.HydrographLocationTableControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.HydrographLocationTableControl.CaptionText = "Hydrograph Location Table"
        Me.HydrographLocationTableControl.CausesValidation = False
        Me.HydrographLocationTableControl.ColumnWidthRatios = Nothing
        Me.HydrographLocationTableControl.DataMember = ""
        Me.HydrographLocationTableControl.EnableSaveActions = False
        Me.HydrographLocationTableControl.FirstColumnIncreases = True
        Me.HydrographLocationTableControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.HydrographLocationTableControl.FirstColumnMinimum = 0
        Me.HydrographLocationTableControl.FirstRowFixed = True
        Me.HydrographLocationTableControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HydrographLocationTableControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.HydrographLocationTableControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.HydrographLocationTableControl.Location = New System.Drawing.Point(216, 8)
        Me.HydrographLocationTableControl.MaxRows = 50
        Me.HydrographLocationTableControl.MinRows = 2
        Me.HydrographLocationTableControl.Name = "HydrographLocationTableControl"
        Me.HydrographLocationTableControl.PasteDisabled = False
        Me.HydrographLocationTableControl.SecondColumnIncreases = False
        Me.HydrographLocationTableControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.HydrographLocationTableControl.SecondColumnMinimum = 0
        Me.HydrographLocationTableControl.Size = New System.Drawing.Size(192, 216)
        Me.HydrographLocationTableControl.TabIndex = 1
        Me.HydrographLocationTableControl.TableReadonly = False
        '
        'ProfileTimeTableControl
        '
        Me.ProfileTimeTableControl.AllRowsFixed = False
        Me.ProfileTimeTableControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.ProfileTimeTableControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.ProfileTimeTableControl.CaptionText = "Profile Time Table"
        Me.ProfileTimeTableControl.CausesValidation = False
        Me.ProfileTimeTableControl.ColumnWidthRatios = Nothing
        Me.ProfileTimeTableControl.DataMember = ""
        Me.ProfileTimeTableControl.EnableSaveActions = False
        Me.ProfileTimeTableControl.FirstColumnIncreases = True
        Me.ProfileTimeTableControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.ProfileTimeTableControl.FirstColumnMinimum = 0
        Me.ProfileTimeTableControl.FirstRowFixed = False
        Me.ProfileTimeTableControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProfileTimeTableControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.ProfileTimeTableControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.ProfileTimeTableControl.Location = New System.Drawing.Point(8, 8)
        Me.ProfileTimeTableControl.MaxRows = 50
        Me.ProfileTimeTableControl.MinRows = 1
        Me.ProfileTimeTableControl.Name = "ProfileTimeTableControl"
        Me.ProfileTimeTableControl.PasteDisabled = False
        Me.ProfileTimeTableControl.SecondColumnIncreases = False
        Me.ProfileTimeTableControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.ProfileTimeTableControl.SecondColumnMinimum = 0
        Me.ProfileTimeTableControl.Size = New System.Drawing.Size(192, 216)
        Me.ProfileTimeTableControl.TabIndex = 0
        Me.ProfileTimeTableControl.TableReadonly = False
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileMenu, Me.EditMenu})
        '
        'FileMenu
        '
        Me.FileMenu.Index = 0
        Me.FileMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileProfileTableMenu, Me.FileHydrographTableMenu})
        Me.FileMenu.Text = "&File"
        '
        'FileProfileTableMenu
        '
        Me.FileProfileTableMenu.Index = 0
        Me.FileProfileTableMenu.Text = "&Profile Time Table"
        '
        'FileHydrographTableMenu
        '
        Me.FileHydrographTableMenu.Index = 1
        Me.FileHydrographTableMenu.Text = "&Hydrograph Location Table"
        '
        'EditMenu
        '
        Me.EditMenu.Index = 1
        Me.EditMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.EditProfileTableMenu, Me.EditHydrographTableMenu})
        Me.EditMenu.Text = "&Edit"
        '
        'EditProfileTableMenu
        '
        Me.EditProfileTableMenu.Index = 0
        Me.EditProfileTableMenu.Text = "P&rofile Time Table"
        '
        'EditHydrographTableMenu
        '
        Me.EditHydrographTableMenu.Index = 1
        Me.EditHydrographTableMenu.Text = "H&ydrograph Location Table"
        '
        'SimGraphicsDialogBox
        '
        Me.AccessibleDescription = "Allows editing of the parameters that control the Simulation graphics display."
        Me.AccessibleName = "Simulation Graphics Dialog Box"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CancelSimulationGraphics
        Me.ClientSize = New System.Drawing.Size(434, 280)
        Me.Controls.Add(Me.OkSimulationGraphics)
        Me.Controls.Add(Me.CancelSimulationGraphics)
        Me.Controls.Add(Me.StandardPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu
        Me.MinimizeBox = False
        Me.Name = "SimGraphicsDialogBox"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simulation Graphics"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StandardPanel.ResumeLayout(False)
        CType(Me.HydrographLocationTableControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProfileTimeTableControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    Private mUnit As Unit
    Private mMyStore As DataStore.ObjectNode
    Private mSrfrCriteria As SrfrCriteria

    ' Profile Time Table
    Private mProfilePropertyNode As PropertyNode = New PropertyNode

    ' Hydrograph Location Table
    Private mHydrographPropertyNode As PropertyNode = New PropertyNode

    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Initialization "

    Private Sub InitializeSimGraphicsDialogBox(ByVal _unit As Unit, ByVal _userLevel As UserLevels)
        If (_unit IsNot Nothing) Then

            Me.Text = mDictionary.ControlText(Me)

            ' Link this control to its models
            mUnit = _unit
            mMyStore = _unit.MyStore
            mSrfrCriteria = _unit.SrfrCriteriaRef
            '
            ' Initialize the Profile table
            '
            Dim _cutoffTime As Double = mUnit.InflowManagementRef.CutoffTime.Value
            Dim _profileTable As DataTable = mSrfrCriteria.ProfileTable.Value
            If (_profileTable Is Nothing) Then
                _profileTable = New DataTable(SrfrCriteria.sProfileTable)
                mSrfrCriteria.ResetProfileTable(_profileTable, _cutoffTime)
            End If

            Dim _profileParameter As DataTableParameter = New DataTableParameter(_profileTable)

            mProfilePropertyNode.SetParameter(_profileParameter)
            mProfilePropertyNode.EventsEnabled = True

            ProfileTimeTableControl.LinkToModel(Nothing, mProfilePropertyNode)
            ProfileTimeTableControl.UpdateUI()
            '
            ' Initialize the Hydrograph table
            '
            Dim _length As Double = mUnit.SystemGeometryRef.Length.Value
            Dim _hydrographTable As DataTable = mSrfrCriteria.HydrographTable.Value
            If (_hydrographTable Is Nothing) Then
                _hydrographTable = New DataTable(SrfrCriteria.sHydrographTable)
                mSrfrCriteria.ResetHydrographTable(_hydrographTable, _length)
            End If

            ' SRFR requires its Hydrograph Location Table to span the field from start to end;
            '   so... adjust the Hydrograph Table to make this happen
            Dim _locations As Integer = _hydrographTable.Rows.Count
            Dim _tableStart As Double = CDbl(_hydrographTable.Rows(0).Item(nDistanceX))
            Dim _tableEnd As Double = CDbl(_hydrographTable.Rows(_locations - 1).Item(nDistanceX))
            Dim _tableSpan As Double = _tableEnd - _tableStart

            If ((Not (_tableStart = 0.0)) _
             Or (Not (_tableEnd = _length))) Then
                ' Table does not span field; adjust it so it does
                For _idx As Integer = 0 To _locations - 2
                    Dim _tableLoc As Double = CDbl(_hydrographTable.Rows(_idx).Item(nDistanceX))

                    ' Calculate SRFR hydrograph location as ratio of table values to actual length
                    Dim _ratioLoc As Double = ((_tableLoc - _tableStart) * _length) / _tableSpan

                    _hydrographTable.Rows(_idx).Item(nDistanceX) = _ratioLoc
                Next

                ' Force the last entry to be exactly length (with no truncation errors)
                _hydrographTable.Rows(_locations - 1).Item(nDistanceX) = _length
            End If

            Dim _hydrographParameter As DataTableParameter = New DataTableParameter(_hydrographTable)

            mHydrographPropertyNode.SetParameter(_hydrographParameter)
            mHydrographPropertyNode.EventsEnabled = True

            HydrographLocationTableControl.LinkToModel(Nothing, mHydrographPropertyNode)
            HydrographLocationTableControl.UpdateUI()
        End If

    End Sub

#End Region

#Region " UI Event Handlers "

#Region " File Menu "

    Private Sub FileMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileMenu.Popup
        ' Enable / disable the File Profile Time menu items
        ProfileTimeTableControl.FileMenu_Popup(FileProfileTableMenu)
        ' Enable / disable the File Hydrograph Location menu items
        HydrographLocationTableControl.FileMenu_Popup(FileHydrographTableMenu)
    End Sub

#End Region

#Region " Edit Menu "

    Private Sub EditMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditMenu.Popup
        ' Enable / disable the Edit Profile Time menu items
        ProfileTimeTableControl.EditMenu_Popup(EditProfileTableMenu)
        ' Enable / disable the Edit Hydrograph Location menu items
        HydrographLocationTableControl.EditMenu_Popup(EditHydrographTableMenu)
    End Sub

#End Region

#Region " Buttons "

    Dim mMarkedForUndo As Boolean = False
    Private Sub MarkForUndo()
        If Not (mMarkedForUndo) Then
            mMarkedForUndo = True
            ' Mark this as an Undo point
            Dim undoText As String = Me.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)
        End If
    End Sub

    Private Sub OkSimulationGraphics_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkSimulationGraphics.Click

        ' Save the new Profile Table
        Dim _profileParameter As DataTableParameter = mSrfrCriteria.ProfileTable
        Dim _profileTable As DataTable = mProfilePropertyNode.GetDataTableParameter.Value

        If DataTablesAreDifferent(_profileParameter.Value, _profileTable) Then
            MarkForUndo()
            _profileParameter.Value = _profileTable
            _profileParameter.Source = DataStore.Globals.ValueSources.UserEntered
            mSrfrCriteria.ProfileTable = _profileParameter
        End If

        ' Save the new Hydrograph Table
        Dim _hydrographParameter As DataTableParameter = mSrfrCriteria.HydrographTable
        Dim _hydrographTable As DataTable = mHydrographPropertyNode.GetDataTableParameter.Value

        If DataTablesAreDifferent(_hydrographParameter.Value, _hydrographTable) Then
            MarkForUndo()
            _hydrographParameter.Value = _hydrographTable
            _hydrographParameter.Source = DataStore.Globals.ValueSources.UserEntered
            mSrfrCriteria.HydrographTable = _hydrographParameter
        End If

        ' Close the dialog box
        Me.Close()

    End Sub

    Private Sub SimGraphicsDialogBox_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:SimulationInputs", 2300)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:SimulationInputs", 2300)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#End Region

End Class
