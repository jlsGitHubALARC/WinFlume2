
'**********************************************************************************************
' Class VaryWithDialogBox - Displays & edits vary by distance & time data from a Data Set:
'
'   Each DataTable in the DataSet represents a Time
'   Each DataRow in a DataTable represents a Distance
'
Imports DataStore
Imports Srfr

Public Class VaryWithDialogBox
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal _dataSet As DataSet, ByVal _variation As VaryByLocTime.Variations)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeVaryWithDialogBox(_dataSet, _variation)

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
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents FileMenu As System.Windows.Forms.MenuItem
    Friend WithEvents EditMenu As System.Windows.Forms.MenuItem
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents ImportFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ExportFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DataGridPanel As System.Windows.Forms.Panel
    Friend WithEvents DistancePanel As System.Windows.Forms.Panel
    Friend WithEvents DistanceTimePanel As System.Windows.Forms.Panel
    Friend WithEvents TimeTabControl As System.Windows.Forms.TabControl
    Friend WithEvents CopyTableItem As System.Windows.Forms.MenuItem
    Friend WithEvents InsertTimeBeforeItem As System.Windows.Forms.MenuItem
    Friend WithEvents InsertTimeAfterItem As System.Windows.Forms.MenuItem
    Friend WithEvents DeleteTimeItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditTimeItem As System.Windows.Forms.MenuItem
    Friend WithEvents TimeContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents ControlPanel As DataStore.ctl_Panel
    Friend WithEvents AcceptData As DataStore.ctl_Button
    Friend WithEvents CancelData As DataStore.ctl_Button
    Friend WithEvents VaryWithGroup As DataStore.ctl_GroupBox
    Friend WithEvents DistanceTimeButton As DataStore.ctl_RadioButton
    Friend WithEvents DistanceButton As DataStore.ctl_RadioButton
    Friend WithEvents FieldLengthLabel As DataStore.ctl_Label
    Friend WithEvents EditSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents EditSepratator2 As System.Windows.Forms.MenuItem
    Friend WithEvents EditDistancesMenu As System.Windows.Forms.MenuItem
    Friend WithEvents CloseItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator1 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.MainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.FileMenu = New System.Windows.Forms.MenuItem
        Me.CloseItem = New System.Windows.Forms.MenuItem
        Me.FileSeparator1 = New System.Windows.Forms.MenuItem
        Me.EditMenu = New System.Windows.Forms.MenuItem
        Me.InsertTimeBeforeItem = New System.Windows.Forms.MenuItem
        Me.InsertTimeAfterItem = New System.Windows.Forms.MenuItem
        Me.DeleteTimeItem = New System.Windows.Forms.MenuItem
        Me.EditTimeItem = New System.Windows.Forms.MenuItem
        Me.EditSeparator1 = New System.Windows.Forms.MenuItem
        Me.EditDistancesMenu = New System.Windows.Forms.MenuItem
        Me.EditSepratator2 = New System.Windows.Forms.MenuItem
        Me.CopyTableItem = New System.Windows.Forms.MenuItem
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ImportFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ExportFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.TimeContextMenu = New System.Windows.Forms.ContextMenu
        Me.DataGridPanel = New System.Windows.Forms.Panel
        Me.DistanceTimePanel = New System.Windows.Forms.Panel
        Me.TimeTabControl = New System.Windows.Forms.TabControl
        Me.DistancePanel = New System.Windows.Forms.Panel
        Me.ControlPanel = New DataStore.ctl_Panel
        Me.FieldLengthLabel = New DataStore.ctl_Label
        Me.VaryWithGroup = New DataStore.ctl_GroupBox
        Me.DistanceTimeButton = New DataStore.ctl_RadioButton
        Me.DistanceButton = New DataStore.ctl_RadioButton
        Me.AcceptData = New DataStore.ctl_Button
        Me.CancelData = New DataStore.ctl_Button
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DataGridPanel.SuspendLayout()
        Me.DistanceTimePanel.SuspendLayout()
        Me.ControlPanel.SuspendLayout()
        Me.VaryWithGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileMenu, Me.EditMenu})
        '
        'FileMenu
        '
        Me.FileMenu.Index = 0
        Me.FileMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.CloseItem, Me.FileSeparator1})
        Me.FileMenu.Text = "&File"
        '
        'CloseItem
        '
        Me.CloseItem.Index = 0
        Me.CloseItem.Text = "&Close"
        '
        'FileSeparator1
        '
        Me.FileSeparator1.Index = 1
        Me.FileSeparator1.Text = "-"
        '
        'EditMenu
        '
        Me.EditMenu.Index = 1
        Me.EditMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.InsertTimeBeforeItem, Me.InsertTimeAfterItem, Me.DeleteTimeItem, Me.EditTimeItem, Me.EditSeparator1, Me.EditDistancesMenu, Me.EditSepratator2, Me.CopyTableItem})
        Me.EditMenu.Text = "&Edit"
        '
        'InsertTimeBeforeItem
        '
        Me.InsertTimeBeforeItem.Index = 0
        Me.InsertTimeBeforeItem.Text = "Insert Time &Before"
        '
        'InsertTimeAfterItem
        '
        Me.InsertTimeAfterItem.Index = 1
        Me.InsertTimeAfterItem.Text = "Insert Time &After"
        '
        'DeleteTimeItem
        '
        Me.DeleteTimeItem.Index = 2
        Me.DeleteTimeItem.Text = "&Delete Time"
        '
        'EditTimeItem
        '
        Me.EditTimeItem.Index = 3
        Me.EditTimeItem.Text = "&Edit Time"
        '
        'EditSeparator1
        '
        Me.EditSeparator1.Index = 4
        Me.EditSeparator1.Text = "-"
        '
        'EditDistancesMenu
        '
        Me.EditDistancesMenu.Index = 5
        Me.EditDistancesMenu.Text = "Di&stances"
        '
        'EditSepratator2
        '
        Me.EditSepratator2.Index = 6
        Me.EditSepratator2.Text = "-"
        '
        'CopyTableItem
        '
        Me.CopyTableItem.Index = 7
        Me.CopyTableItem.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.CopyTableItem.Text = "&Copy Table"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TimeContextMenu
        '
        '
        'DataGridPanel
        '
        Me.DataGridPanel.Controls.Add(Me.DistanceTimePanel)
        Me.DataGridPanel.Controls.Add(Me.DistancePanel)
        Me.DataGridPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridPanel.Location = New System.Drawing.Point(0, 0)
        Me.DataGridPanel.Name = "DataGridPanel"
        Me.DataGridPanel.Size = New System.Drawing.Size(312, 225)
        Me.DataGridPanel.TabIndex = 3
        '
        'DistanceTimePanel
        '
        Me.DistanceTimePanel.Controls.Add(Me.TimeTabControl)
        Me.DistanceTimePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DistanceTimePanel.Location = New System.Drawing.Point(0, 0)
        Me.DistanceTimePanel.Name = "DistanceTimePanel"
        Me.DistanceTimePanel.Size = New System.Drawing.Size(312, 225)
        Me.DistanceTimePanel.TabIndex = 1
        '
        'TimeTabControl
        '
        Me.TimeTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TimeTabControl.Location = New System.Drawing.Point(0, 0)
        Me.TimeTabControl.Multiline = True
        Me.TimeTabControl.Name = "TimeTabControl"
        Me.TimeTabControl.SelectedIndex = 0
        Me.TimeTabControl.Size = New System.Drawing.Size(312, 225)
        Me.TimeTabControl.TabIndex = 0
        '
        'DistancePanel
        '
        Me.DistancePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DistancePanel.Location = New System.Drawing.Point(0, 0)
        Me.DistancePanel.Name = "DistancePanel"
        Me.DistancePanel.Size = New System.Drawing.Size(312, 225)
        Me.DistancePanel.TabIndex = 0
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.FieldLengthLabel)
        Me.ControlPanel.Controls.Add(Me.VaryWithGroup)
        Me.ControlPanel.Controls.Add(Me.AcceptData)
        Me.ControlPanel.Controls.Add(Me.CancelData)
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ControlPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ControlPanel.Location = New System.Drawing.Point(0, 225)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(312, 128)
        Me.ControlPanel.TabIndex = 1
        '
        'FieldLengthLabel
        '
        Me.FieldLengthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FieldLengthLabel.Location = New System.Drawing.Point(16, 8)
        Me.FieldLengthLabel.Name = "FieldLengthLabel"
        Me.FieldLengthLabel.Size = New System.Drawing.Size(288, 23)
        Me.FieldLengthLabel.TabIndex = 0
        Me.FieldLengthLabel.Text = "Field Length = "
        Me.FieldLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VaryWithGroup
        '
        Me.VaryWithGroup.Controls.Add(Me.DistanceTimeButton)
        Me.VaryWithGroup.Controls.Add(Me.DistanceButton)
        Me.VaryWithGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VaryWithGroup.Location = New System.Drawing.Point(8, 40)
        Me.VaryWithGroup.Name = "VaryWithGroup"
        Me.VaryWithGroup.Size = New System.Drawing.Size(296, 42)
        Me.VaryWithGroup.TabIndex = 1
        Me.VaryWithGroup.TabStop = False
        Me.VaryWithGroup.Text = "Vary With ..."
        '
        'DistanceTimeButton
        '
        Me.DistanceTimeButton.Enabled = False
        Me.DistanceTimeButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DistanceTimeButton.Location = New System.Drawing.Point(144, 16)
        Me.DistanceTimeButton.Name = "DistanceTimeButton"
        Me.DistanceTimeButton.Size = New System.Drawing.Size(144, 24)
        Me.DistanceTimeButton.TabIndex = 1
        Me.DistanceTimeButton.Text = "Distance && &Time"
        '
        'DistanceButton
        '
        Me.DistanceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DistanceButton.Location = New System.Drawing.Point(16, 16)
        Me.DistanceButton.Name = "DistanceButton"
        Me.DistanceButton.Size = New System.Drawing.Size(128, 24)
        Me.DistanceButton.TabIndex = 0
        Me.DistanceButton.Text = "&Distance Only"
        '
        'AcceptData
        '
        Me.AcceptData.AccessibleDescription = "Accepts changes"
        Me.AcceptData.AccessibleName = "Ok Button"
        Me.AcceptData.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.AcceptData.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AcceptData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.AcceptData.Location = New System.Drawing.Point(8, 96)
        Me.AcceptData.Name = "AcceptData"
        Me.AcceptData.Size = New System.Drawing.Size(75, 24)
        Me.AcceptData.TabIndex = 2
        Me.AcceptData.Text = "&Ok"
        Me.AcceptData.UseVisualStyleBackColor = False
        '
        'CancelData
        '
        Me.CancelData.AccessibleDescription = "Cancels changes"
        Me.CancelData.AccessibleName = "Cancel Button"
        Me.CancelData.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelData.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelData.Location = New System.Drawing.Point(229, 96)
        Me.CancelData.Name = "CancelData"
        Me.CancelData.Size = New System.Drawing.Size(75, 24)
        Me.CancelData.TabIndex = 3
        Me.CancelData.Text = "&Cancel"
        '
        'VaryWithDialogBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(312, 353)
        Me.Controls.Add(Me.DataGridPanel)
        Me.Controls.Add(Me.ControlPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 600)
        Me.Menu = Me.MainMenu
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "VaryWithDialogBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Vary With ... Dialog Box"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DataGridPanel.ResumeLayout(False)
        Me.DistanceTimePanel.ResumeLayout(False)
        Me.ControlPanel.ResumeLayout(False)
        Me.VaryWithGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Constants "
    '
    ' Resolve reference conflicts between DataStore & Srfr
    '
    Protected Const OneMillimeter As Double = Srfr.Globals.OneMillimeter
    Protected Const OneCentimeter As Double = Srfr.Globals.OneCentimeter
    Protected Const OneMeter As Double = Srfr.Globals.OneMeter

    Protected Const MillimetersPerMeter As Double = Srfr.Globals.MillimetersPerMeter

    Protected Const OneSecond As Double = Srfr.Globals.OneSecond
    Protected Const TenSeconds As Double = Srfr.Globals.TenSeconds
    Protected Const OneMinute As Double = Srfr.Globals.OneMinute
    Protected Const OneHour As Double = Srfr.Globals.OneHour

    Protected Const LiterPerSecond As Double = Srfr.Globals.LiterPerSecond

#End Region

#Region " Member Data "

    Private Const RowNumberColumn As Integer = 0
    Private Const DistanceColumn As Integer = 1

    ' The input data set
    Private mDataSet As DataSet
    Private mDataTable As DataTable
    Private mDataTableName As String
    Private mLastValue As Double
    Private mLastValueInvalid As Boolean = False
    Private mLastCell As DataGridCell

    ' DataTable Data & Control
    Private mDataTableNode As PropertyNode = New PropertyNode
    Private WithEvents mDataTableControl As ctl_DataTableParameter

    ' Units System
    Private mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Properties "
    '
    ' Field Length
    '
    Private mLength As Double = 0.0
    Public Property FieldLength() As Double
        Get
            Return mLength
        End Get
        Set(ByVal Value As Double)
            ' Save & display the Length
            If (0.0 < Value) Then
                mLength = Value
                FieldLengthLabel.Text += LengthString(mLength, 0)
                mDataTableControl.FirstColumnMaximum = mLength
            Else
                Debug.Assert(False, "Field Length must be greater than 0.0")
            End If
        End Set
    End Property
    '
    ' Times
    '
    Private mMaxTimes As Integer = 25
    Public Property MaxTimes() As Integer
        Get
            Return mMaxTimes
        End Get
        Set(ByVal Value As Integer)
            mMaxTimes = Value
        End Set
    End Property

    Private mFirstTimeFixed As Boolean = True
    Public Property FirstTimeFixed() As Boolean
        Get
            Return mFirstTimeFixed
        End Get
        Set(ByVal Value As Boolean)
            mFirstTimeFixed = Value
        End Set
    End Property

    Private mLastTimeFixed As Boolean = False
    Public Property LastTimeFixed() As Boolean
        Get
            Return mLastTimeFixed
        End Get
        Set(ByVal Value As Boolean)
            mLastTimeFixed = Value
        End Set
    End Property
    '
    ' Distances
    '
    Private mMinDistances As Integer = 1
    Public Property MinDistances() As Integer
        Get
            Return mMinDistances
        End Get
        Set(ByVal Value As Integer)
            mMinDistances = Value
            mDataTableControl.MinRows = mMinDistances
        End Set
    End Property

    Private mMaxDistances As Integer = 50
    Public Property MaxDistances() As Integer
        Get
            Return mMaxDistances
        End Get
        Set(ByVal Value As Integer)
            mMaxDistances = Value
            mDataTableControl.MaxRows = mMaxDistances
        End Set
    End Property


    Private mFirstDistanceFixed As Boolean = True
    Public Property FirstDistanceFixed() As Boolean
        Get
            Return mFirstDistanceFixed
        End Get
        Set(ByVal Value As Boolean)
            mFirstDistanceFixed = Value
            mDataTableControl.FirstRowFixed = mFirstDistanceFixed
        End Set
    End Property

    Private mDistanceMinimum As Double = 0.0
    Public Property DistanceMinimum() As Double
        Get
            Return mDistanceMinimum
        End Get
        Set(ByVal Value As Double)
            mDistanceMinimum = Value
            mDataTableControl.FirstColumnMinimum = mDistanceMinimum
        End Set
    End Property

    Private mDistancePrecision As Double = 0.01
    Private mDistanceIncreases As Boolean = True
    Public Property DistanceIncreases() As Boolean
        Get
            Return mDistanceIncreases
        End Get
        Set(ByVal Value As Boolean)
            mDistanceIncreases = Value
            mDataTableControl.FirstColumnIncreases = mDistanceIncreases
        End Set
    End Property

    Private mVariation As VaryByLocTime.Variations
    Public ReadOnly Property Variation() As VaryByLocTime.Variations
        Get
            Return mVariation
        End Get
    End Property

#End Region

#Region " Methods "

#Region " Time Methods "

    Private Sub InsertTimeBetween(ByVal _table1 As Integer, ByVal _table2 As Integer)
        Debug.Assert(_table1 = _table2 - 1, "Table numbers not contiguous")

        ' Get the two bounding tables
        Dim _dataTable1 As DataTable = mDataSet.Tables(_table1)
        Dim _dataTable2 As DataTable = mDataSet.Tables(_table2)

        Dim _time1, _time2 As Double

        If Not (ParseTime(_dataTable1.TableName, _time1)) Then
            Debug.Assert(False, "Time 1 not parsable")
            Return
        End If

        If Not (ParseTime(_dataTable2.TableName, _time2)) Then
            Debug.Assert(False, "Time 2 not parsable")
            Return
        End If

        ' Get the new time from the user
        Dim _timeValue As Double = (_time1 + _time2) / 2
        Dim _timeUnits As Units = mUnitsSystem.TimeUnits
        Dim _getTime As db_GetDoubleValue = New db_GetDoubleValue(_timeValue, _timeUnits)

        _getTime.Title = mDictionary.tTime.Translated
        _getTime.Instructions = mDictionary.tEnterTime.Translated
        _getTime.MinValue = _time1 + OneMinute
        _getTime.MaxValue = _time2 - OneMinute

        Dim _results As DialogResult = _getTime.ShowDialog

        If (_results = DialogResult.OK) Then
            _timeValue = _getTime.Value
        Else
            Return
        End If
        '
        ' Create the new table using average values from bounding tables
        '
        Dim _timeLabel As String = mDictionary.tTime.Translated & " " & TimeString(_timeValue, 0)
        Dim _dataTable As DataTable = New DataTable(_timeLabel)

        ' Add the columns
        Debug.Assert(_dataTable1.Columns.Count = _dataTable2.Columns.Count, "Column counts don't match")

        For _col As Integer = 0 To _dataTable1.Columns.Count - 1
            Dim _dataColumn1 As DataColumn = _dataTable1.Columns(_col)
            Dim _dataColumn2 As DataColumn = _dataTable2.Columns(_col)
            Debug.Assert(_dataColumn1.ColumnName = _dataColumn2.ColumnName, "Column names don't match")
            Debug.Assert(_dataColumn1.DataType Is _dataColumn2.DataType, "Column types don't match")

            Dim _dataColumn As DataColumn = New DataColumn(_dataColumn1.ColumnName, _dataColumn1.DataType)
            _dataTable.Columns.Add(_dataColumn)
        Next

        ' Add the rows
        Debug.Assert(_dataTable1.Rows.Count = _dataTable2.Rows.Count, "Row counts don't match")

        For _row As Integer = 0 To _dataTable1.Rows.Count - 1
            Dim _dataRow1 As DataRow = _dataTable1.Rows(_row)
            Dim _dataRow2 As DataRow = _dataTable2.Rows(_row)

            Dim _dataRow As DataRow = _dataTable.NewRow

            For _col As Integer = 0 To _dataTable.Columns.Count - 1
                If ((_dataRow1.Item(_col).GetType Is GetType(Double)) _
                And (_dataRow2.Item(_col).GetType Is GetType(Double))) Then
                    Dim _val1 As Double = CDbl(_dataRow1.Item(_col))
                    Dim _val2 As Double = CDbl(_dataRow2.Item(_col))
                    _dataRow.Item(_col) = (_val1 + _val2) / 2
                End If
            Next

            _dataTable.Rows.Add(_dataRow)
        Next
        '
        ' Insert the new DataTable by adding it to the ending and moving those behind it
        '
        ' NOTE - this is necessary since DataSet has no InsertAt() method
        '
        Dim _moveCount As Integer = mDataSet.Tables.Count - _table2

        ' Add new DataTable to end
        mDataSet.Tables.Add(_dataTable)

        ' Move DataTables that should be behind it
        For _count As Integer = 1 To _moveCount
            _dataTable = mDataSet.Tables.Item(_table2)
            mDataSet.Tables.RemoveAt(_table2)
            mDataSet.Tables.Add(_dataTable)
        Next

        ' Re-construct the UI to reflect the addition
        ConstructUiFromDataSet()
        TimeTabControl.SelectedIndex = _table1 + 1

    End Sub

    Private Sub InsertTimeBefore(ByVal _table As Integer)

        If (_table <= 0) Then

            ' Insert before first table
            If (FirstTimeFixed) Then
                Debug.Assert(False, "First time is fixed; can't insert before")
                Return
            End If

            Debug.Assert(False, "Insert before first table has not been implemented")

        Else
            ' Insert between tables
            InsertTimeBetween(_table - 1, _table)
        End If

    End Sub

    Private Sub InsertTimeAfter(ByVal _table As Integer)

        If (_table >= mDataSet.Tables.Count - 1) Then

            ' Insert after last table
            If (LastTimeFixed) Then
                Debug.Assert(False, "Last time is fixed; can't insert after")
                Return
            End If

            ' Get the last table
            Dim _lastTable As DataTable = mDataSet.Tables(_table)
            Dim _lastTime As Double

            If Not (ParseTime(_lastTable.TableName, _lastTime)) Then
                Debug.Assert(False, "Time not parsable")
                Return
            End If

            ' Get the new time from the user
            Dim _timeValue As Double = _lastTime + OneHour
            Dim _timeUnits As Units = mUnitsSystem.TimeUnits
            Dim _getTime As db_GetDoubleValue = New db_GetDoubleValue(_timeValue, _timeUnits)

            _getTime.Title = mDictionary.tTime.Translated
            _getTime.Instructions = mDictionary.tEnterTime.Translated
            _getTime.MinValue = _lastTime + OneMinute
            _getTime.MaxValue = Decimal.MaxValue

            Dim _results As DialogResult = _getTime.ShowDialog

            If (_results = DialogResult.OK) Then
                _timeValue = _getTime.Value
            Else
                Return
            End If

            ' Create the new table using values from the last table
            Dim _timeLabel As String = "Time " + TimeString(_timeValue, 0)
            Dim _dataTable As DataTable = New DataTable(_timeLabel)

            ' Add the columns
            For _col As Integer = 0 To _lastTable.Columns.Count - 1
                Dim _lastColumn As DataColumn = _lastTable.Columns(_col)
                Dim _dataColumn As DataColumn = New DataColumn(_lastColumn.ColumnName, _lastColumn.DataType)
                _dataTable.Columns.Add(_dataColumn)
            Next

            ' Add the rows
            For _row As Integer = 0 To _lastTable.Rows.Count - 1
                Dim _lastRow As DataRow = _lastTable.Rows(_row)
                Dim _dataRow As DataRow = _dataTable.NewRow

                For _col As Integer = 0 To _dataTable.Columns.Count - 1
                    _dataRow.Item(_col) = _lastRow.Item(_col)
                Next

                _dataTable.Rows.Add(_dataRow)
            Next

            ' Add the DataTable to the DataSet
            mDataSet.Tables.Add(_dataTable)

            ' Re-construct the UI to reflect the addition
            ConstructUiFromDataSet()
            TimeTabControl.SelectedIndex = _table + 1
        Else
            ' Insert between tables
            InsertTimeBetween(_table, _table + 1)
        End If

    End Sub

    Private Sub DeleteTime(ByVal _table As Integer)

        ' Valide delete is OK
        If ((FirstTimeFixed) And (_table = 0)) Then
            Debug.Assert(False, "First table is fixed; can't be deleted")
            Return
        ElseIf ((LastTimeFixed) And (_table = mDataSet.Tables.Count - 1)) Then
            Debug.Assert(False, "Last table is fixed; can't be deleted")
            Return
        End If

        ' Remove the DataTable from the DataSet
        mDataSet.Tables.RemoveAt(_table)

        ' Re-construct the UI to reflect the deletion
        ConstructUiFromDataSet()

    End Sub

    Private Sub EditTime(ByVal _table As Integer)

        ' Valide edit is OK
        If ((FirstTimeFixed) And (_table = 0)) Then
            Debug.Assert(False, "First table is fixed; can't be edited")
            Return
        ElseIf ((LastTimeFixed) And (_table = mDataSet.Tables.Count - 1)) Then
            Debug.Assert(False, "Last table is fixed; can't be edited")
            Return
        End If

        ' Get the two bounding times
        Dim _time, _time1, _time2 As Double
        Dim _dataTable As DataTable

        If (_table = 0) Then
            ' First time; lower bound is 0
            _time1 = 0.0 - OneMinute
        Else
            ' Not first time; use previous time as lower bound
            _dataTable = mDataSet.Tables(_table - 1)

            If Not (ParseTime(_dataTable.TableName, _time1)) Then
                Debug.Assert(False, "Time 1 not parsable")
                Return
            End If
        End If

        If (_table = mDataSet.Tables.Count - 1) Then
            ' Last time; no upper bound
            _time2 = Decimal.MaxValue
        Else
            ' Not last time; user next time as upper bound
            _dataTable = mDataSet.Tables(_table + 1)

            If Not (ParseTime(_dataTable.TableName, _time2)) Then
                Debug.Assert(False, "Time 2 not parsable")
                Return
            End If
        End If

        ' Get the new time from the user
        _dataTable = mDataSet.Tables(_table)

        If Not (ParseTime(_dataTable.TableName, _time)) Then
            Debug.Assert(False, "Time not parsable")
            Return
        End If

        Dim _timeUnits As Units = mUnitsSystem.TimeUnits
        Dim _getTime As db_GetDoubleValue = New db_GetDoubleValue(_time, _timeUnits)

        _getTime.Title = mDictionary.tTime.Translated
        _getTime.Instructions = mDictionary.tEnterTime.Translated
        _getTime.MinValue = _time1 + OneMinute
        _getTime.MaxValue = _time2 - OneMinute

        Dim _results As DialogResult = _getTime.ShowDialog

        If (_results = DialogResult.OK) Then
            _time = _getTime.Value
        Else
            Return
        End If

        ' Save the new time
        _dataTable.TableName = mDictionary.tTime.Translated & " " & TimeString(_time, 0)

        ' Update TabPage with new time
        TimeTabControl.TabPages(_table).Text = _dataTable.TableName

        ' Update DataGrid caption with new time
        Dim _dataGrid As DataGrid = CType(TimeTabControl.TabPages(_table).Controls(0), DataGrid)
        _dataGrid.CaptionText = _dataTable.TableName

    End Sub

#End Region

#Region " Distance Methods "

#End Region

#Region " UI Methods "
    '
    ' Update the UI to match the Variation
    '
    Private Sub UpdateUI()

        If (mVariation = VaryByLocTime.Variations.VaryDistanceAndTime) Then
            DistanceTimeButton.Checked = True
            DistancePanel.Hide()
            DistanceTimePanel.Show()
        Else ' Assume VaryWithDistance
            DistanceButton.Checked = True
            DistanceTimePanel.Hide()
            DistancePanel.Show()
        End If

    End Sub
    '
    ' Construct the UI from the DataSet
    '
    Private Sub ConstructUiFromDataSet()

        ' Clear the Time tab pages
        TimeTabControl.TabPages.Clear()

        If (0 < mDataSet.Tables.Count) Then
            '
            ' Build the 'Distance Only' DataTable Control
            '
            mDataTableControl = GetDataTableControl(mDataTable)

            If (mDataTableControl IsNot Nothing) Then
                mDataTableControl.Dock = DockStyle.Fill
                DistancePanel.Controls.Add(mDataTableControl)
                mDataTableControl.UpdateUI()
            End If
        End If

    End Sub

#End Region

#End Region

#Region " Initialization "

    Private Sub InitializeVaryWithDialogBox(ByVal _dataSet As DataSet, _
                                            ByVal _variation As VaryByLocTime.Variations)

        If (_dataSet IsNot Nothing) Then

            ' Save the DataSet and Variation
            mDataSet = _dataSet
            mVariation = _variation

            ' Size the Dialog Box's width to hold all data columns
            If (0 < mDataSet.Tables.Count) Then

                ' Get the first DataTable (usually Time = 0)
                mDataTable = mDataSet.Tables(0)

                ' For 'Distance Only' replace 'Time...' name with DataSet name
                mDataTableName = mDataTable.TableName
                mDataTable.TableName = mDataSet.DataSetName

                Dim _numColumns As Integer = mDataTable.Columns.Count
                Dim _width As Integer = _numColumns * 75
                If (Me.MinimumSize.Width < _width) Then
                    Me.MinimumSize = New Size(_width, Me.MinimumSize.Height)
                    Me.MaximumSize = New Size(_width, Me.MaximumSize.Height)
                Else
                    Me.MinimumSize = New Size(Me.Size.Width, Me.MinimumSize.Height)
                    Me.MaximumSize = New Size(Me.Size.Width, Me.MaximumSize.Height)
                End If

                ' Initialize the UI
                ConstructUiFromDataSet()
                UpdateUI()

                AddHandler TimeTabControl.MouseDown, AddressOf Me.TabControl_MouseDown
            Else
                Debug.Assert(False, "DataSet is empty")
            End If
        End If

    End Sub

    Private Function GetDataTableControl(ByVal _dataTable As DataTable) As ctl_DataTableParameter

        If (_dataTable IsNot Nothing) Then

            ' Create the data model for the input DataTable
            Dim _dataTableParameter As DataTableParameter = New DataTableParameter(_dataTable)

            mDataTableNode.SetParameter(_dataTableParameter)
            mDataTableNode.EventsEnabled = True

            ' Create & initialize the control for the input DataTable
            Dim _dataTableControl As ctl_DataTableParameter = New ctl_DataTableParameter

            _dataTableControl.LinkToModel(Nothing, mDataTableNode)
            _dataTableControl.MinRows = mMinDistances
            _dataTableControl.MaxRows = mMaxDistances
            _dataTableControl.FirstRowFixed = mFirstDistanceFixed
            _dataTableControl.FirstColumnIncreases = mDistanceIncreases
            _dataTableControl.FirstColumnMinimum = mDistanceMinimum

            _dataTableControl.CaptionText = Translator.Instance.Translate(_dataTable.TableName)

            Return _dataTableControl
        End If

        Return Nothing
    End Function

#End Region

#Region " UI Event Handlers "

#Region " File Menu "

    Private Sub FileMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileMenu.Popup
        ' Add the File menu items
        mDataTableControl.FileMenu_Popup(FileMenu)
    End Sub

    Private Sub CloseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CloseItem.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region " Edit Menu "

    Private mTableSelected As Integer
    Private mRowSelected As Integer

    Private Sub EditMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditMenu.Popup
        '
        ' Show / hide, Enable / disable the Edit Time menu items
        '
        If (Variation = VaryByLocTime.Variations.VaryDistanceAndTime) Then

            mTableSelected = TimeTabControl.SelectedIndex

            ' Vary By Distance & Time - show time items
            InsertTimeBeforeItem.Visible = True
            InsertTimeAfterItem.Visible = True
            DeleteTimeItem.Visible = True
            EditTimeItem.Visible = True
            EditSeparator1.Visible = True

            If ((FirstTimeFixed) And (mTableSelected = 0)) Then
                InsertTimeBeforeItem.Enabled = False
                InsertTimeAfterItem.Enabled = True
                DeleteTimeItem.Enabled = False
                EditTimeItem.Enabled = False
            ElseIf ((LastTimeFixed) And (mTableSelected = TimeTabControl.TabPages.Count - 1)) Then
                InsertTimeBeforeItem.Enabled = True
                InsertTimeAfterItem.Enabled = False
                DeleteTimeItem.Enabled = False
                EditTimeItem.Enabled = False
            Else
                InsertTimeBeforeItem.Enabled = True
                InsertTimeAfterItem.Enabled = True
                DeleteTimeItem.Enabled = True
                EditTimeItem.Enabled = True
            End If

            ' Disable Insert menu items if maximum times already defined
            If (mMaxTimes <= mDataSet.Tables.Count) Then
                InsertTimeBeforeItem.Enabled = False
                InsertTimeAfterItem.Enabled = False
            End If
        Else

            ' Vary By Distance - hide time items
            InsertTimeBeforeItem.Visible = False
            InsertTimeAfterItem.Visible = False
            DeleteTimeItem.Visible = False
            EditTimeItem.Visible = False
            EditSeparator1.Visible = False

        End If

        ' Add the Edit Distances menu items
        mDataTableControl.EditMenu_Popup(EditDistancesMenu)

    End Sub

    Private Sub CopyTableItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CopyTableItem.Click
        mDataTableControl.CopyToClipboard()
    End Sub

#End Region

#Region " Controls "

    Private Sub DistanceButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DistanceButton.CheckedChanged
        If (DistanceButton.Checked) Then
            mVariation = VaryByLocTime.Variations.VaryWithDistance
            UpdateUI()
        End If
    End Sub

    Private Sub DistanceTimeButton_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DistanceTimeButton.CheckedChanged
        If (DistanceTimeButton.Checked) Then
            mVariation = VaryByLocTime.Variations.VaryDistanceAndTime
            UpdateUI()
        End If
    End Sub

    Private Sub AcceptData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AcceptData.Click

        ' Get & replace the udpated DataTable from the control
        mDataTable = mDataTableNode.GetDataTableParameter.Value

        ' Replace DataTable name
        mDataTable.TableName = mDataTableName

        mDataSet.Tables.Clear()
        mDataSet.Tables.Add(mDataTable)

        ' Set OK result & close the dialog box
        DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub VaryWithDialogBox_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        ' As of version 3.1, only the Slope / Elevation Table uses this dialog
        WinSRFR.ShowDialogPdfHelpManual("sec:BottomDescription", 0)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:BottomDescription", 0)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub mDataTableControl_ControlValueChanged() _
    Handles mDataTableControl.ControlValueChanged
        Dim _errMsg As String = mDataTableControl.ErrorProvider.GetError(mDataTableControl)
        Me.ErrorProvider.SetError(FieldLengthLabel, _errMsg)
    End Sub

#End Region

#Region " TabControl Events "
    '
    ' Handle mouse down events
    '
    ' Right mouse down in tab displays Time Context Menu
    '
    Private Sub TabControl_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        ' Handles TabControl.MouseDown

        If (sender.GetType Is GetType(TabControl)) Then

            Dim _tabControl As TabControl = DirectCast(sender, TabControl)

            ' Get mouse point
            Dim _mousePoint As New Point(e.X, e.Y)

            ' Find which TabPage was clicked
            For _page As Integer = 0 To _tabControl.TabPages.Count - 1
                Dim _tabRect As Rectangle = _tabControl.GetTabRect(_page)
                If (_tabRect.Contains(_mousePoint)) Then
                    mTableSelected = _page

                    Select Case (e.Button)
                        Case MouseButtons.Right
                            TimeContextMenu.Show(Me, _mousePoint)
                    End Select
                End If
            Next
        Else
            Debug.Assert(False, "Invalid Object for this event handler")
        End If

    End Sub

#End Region

#Region " Context Menu Events "
    '
    ' Build the context menu
    '
    Protected Sub TimeContextMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TimeContextMenu.Popup

        TimeContextMenu.MenuItems.Clear()
        TimeContextMenu.MenuItems.Add("Insert time before", New EventHandler(AddressOf InsertBefore_Click))
        TimeContextMenu.MenuItems.Add("Insert time after", New EventHandler(AddressOf InsertAfter_Click))

        ' Disable Insert menu items if maximum times already defined
        If (mMaxTimes <= mDataSet.Tables.Count) Then
            TimeContextMenu.MenuItems.Item(0).Enabled = False
            TimeContextMenu.MenuItems.Item(1).Enabled = False
        End If

        If ((mTableSelected = 0) And FirstTimeFixed) Then
            ' First time selected and is fixed; disable insert before menu item
            TimeContextMenu.MenuItems.Item(0).Enabled = False

        ElseIf ((mTableSelected = TimeTabControl.TabPages.Count - 1) And LastTimeFixed) Then
            ' Last time selected and is fixed; disable insert after menu item
            TimeContextMenu.MenuItems.Item(1).Enabled = False

        Else
            ' Middle time or not fixed
            TimeContextMenu.MenuItems.Add("-")
            TimeContextMenu.MenuItems.Add("Delete time", New EventHandler(AddressOf Delete_Click))
            TimeContextMenu.MenuItems.Add("-")
            TimeContextMenu.MenuItems.Add("Edit time", New EventHandler(AddressOf Edit_Click))

            ' Disable Delete menu items in only one time
            If (1 = TimeTabControl.TabPages.Count) Then
                TimeContextMenu.MenuItems.Item(3).Enabled = False
            End If
        End If

    End Sub
    '
    ' Handle the context menu items
    '
    Protected Sub InsertAfter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles InsertAfter.Click (menu items are dynamically created by RowContextMenu_Popup()
        InsertTimeAfter(mTableSelected)
    End Sub

    Protected Sub InsertBefore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles InsertBefore.Click (menu items are dynamically created by RowContextMenu_Popup()
        InsertTimeBefore(mTableSelected)
    End Sub

    Protected Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles Delete.Click (menu items are dynamically created by RowContextMenu_Popup()
        DeleteTime(mTableSelected)
    End Sub

    Protected Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles Edit.Click (menu items are dynamically created by RowContextMenu_Popup()
        EditTime(mTableSelected)
    End Sub

#End Region

#End Region

End Class

