
'**********************************************************************************************
' AnalysisDetails - UserControl that displays the details of a Farm / Field / Unit
'
Imports DataStore
Imports PrintingUI

Public Class AnalysisDetails
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
    Friend WithEvents DetailsTabControl As DataStore.ctl_TabControl
    Friend WithEvents LogTabPage As System.Windows.Forms.TabPage
    Friend WithEvents NotesTabPage As System.Windows.Forms.TabPage
    Friend WithEvents DataTabPage As System.Windows.Forms.TabPage
    Friend WithEvents AnalysisDetailsTitle As System.Windows.Forms.Label
    Friend WithEvents IdTabPage As System.Windows.Forms.TabPage
    Friend WithEvents OwnerLabel As DataStore.ctl_Label
    Friend WithEvents CreatedLabel As DataStore.ctl_Label
    Friend WithEvents CreationTime As System.Windows.Forms.Label
    Friend WithEvents AnalysisLog As System.Windows.Forms.RichTextBox
    Friend WithEvents AnalysisNotes As System.Windows.Forms.TextBox
    Friend WithEvents OwnerEvaluator As System.Windows.Forms.TextBox
    Friend WithEvents AnalysisDataHistory As System.Windows.Forms.RichTextBox
    Friend WithEvents ItemName As System.Windows.Forms.TextBox
    Friend WithEvents NameLabel As DataStore.ctl_Label
    Friend WithEvents EvaluatorLabel As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.AnalysisDetailsTitle = New System.Windows.Forms.Label
        Me.DetailsTabControl = New DataStore.ctl_TabControl
        Me.IdTabPage = New System.Windows.Forms.TabPage
        Me.CreationTime = New System.Windows.Forms.Label
        Me.CreatedLabel = New DataStore.ctl_Label
        Me.OwnerEvaluator = New System.Windows.Forms.TextBox
        Me.OwnerLabel = New DataStore.ctl_Label
        Me.ItemName = New System.Windows.Forms.TextBox
        Me.NameLabel = New DataStore.ctl_Label
        Me.EvaluatorLabel = New DataStore.ctl_Label
        Me.NotesTabPage = New System.Windows.Forms.TabPage
        Me.AnalysisNotes = New System.Windows.Forms.TextBox
        Me.DataTabPage = New System.Windows.Forms.TabPage
        Me.AnalysisDataHistory = New System.Windows.Forms.RichTextBox
        Me.LogTabPage = New System.Windows.Forms.TabPage
        Me.AnalysisLog = New System.Windows.Forms.RichTextBox
        Me.DetailsTabControl.SuspendLayout()
        Me.IdTabPage.SuspendLayout()
        Me.NotesTabPage.SuspendLayout()
        Me.DataTabPage.SuspendLayout()
        Me.LogTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'AnalysisDetailsTitle
        '
        Me.AnalysisDetailsTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.AnalysisDetailsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnalysisDetailsTitle.Location = New System.Drawing.Point(0, 0)
        Me.AnalysisDetailsTitle.Name = "AnalysisDetailsTitle"
        Me.AnalysisDetailsTitle.Size = New System.Drawing.Size(368, 23)
        Me.AnalysisDetailsTitle.TabIndex = 0
        Me.AnalysisDetailsTitle.Text = "Details"
        Me.AnalysisDetailsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DetailsTabControl
        '
        Me.DetailsTabControl.AccessibleDescription = "Select the Details tab page to display."
        Me.DetailsTabControl.AccessibleName = "Details Tab Pages"
        Me.DetailsTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.DetailsTabControl.Controls.Add(Me.IdTabPage)
        Me.DetailsTabControl.Controls.Add(Me.NotesTabPage)
        Me.DetailsTabControl.Controls.Add(Me.DataTabPage)
        Me.DetailsTabControl.Controls.Add(Me.LogTabPage)
        Me.DetailsTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailsTabControl.Location = New System.Drawing.Point(0, 23)
        Me.DetailsTabControl.Name = "DetailsTabControl"
        Me.DetailsTabControl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DetailsTabControl.SelectedIndex = 0
        Me.DetailsTabControl.Size = New System.Drawing.Size(368, 254)
        Me.DetailsTabControl.TabIndex = 1
        '
        'IdTabPage
        '
        Me.IdTabPage.AccessibleDescription = "View & edit the identification for the selected item."
        Me.IdTabPage.AccessibleName = "ID Tab"
        Me.IdTabPage.Controls.Add(Me.CreationTime)
        Me.IdTabPage.Controls.Add(Me.CreatedLabel)
        Me.IdTabPage.Controls.Add(Me.OwnerEvaluator)
        Me.IdTabPage.Controls.Add(Me.OwnerLabel)
        Me.IdTabPage.Controls.Add(Me.ItemName)
        Me.IdTabPage.Controls.Add(Me.NameLabel)
        Me.IdTabPage.Controls.Add(Me.EvaluatorLabel)
        Me.IdTabPage.Location = New System.Drawing.Point(4, 28)
        Me.IdTabPage.Name = "IdTabPage"
        Me.IdTabPage.Size = New System.Drawing.Size(360, 222)
        Me.IdTabPage.TabIndex = 3
        Me.IdTabPage.Text = "ID"
        '
        'CreationTime
        '
        Me.CreationTime.AccessibleDescription = "Date & time when the selected item was created."
        Me.CreationTime.AccessibleName = "Created"
        Me.CreationTime.Location = New System.Drawing.Point(96, 48)
        Me.CreationTime.Name = "CreationTime"
        Me.CreationTime.Size = New System.Drawing.Size(256, 23)
        Me.CreationTime.TabIndex = 3
        Me.CreationTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CreatedLabel
        '
        Me.CreatedLabel.Location = New System.Drawing.Point(8, 48)
        Me.CreatedLabel.Name = "CreatedLabel"
        Me.CreatedLabel.Size = New System.Drawing.Size(88, 23)
        Me.CreatedLabel.TabIndex = 2
        Me.CreatedLabel.Text = "Created:"
        Me.CreatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OwnerEvaluator
        '
        Me.OwnerEvaluator.Location = New System.Drawing.Point(96, 80)
        Me.OwnerEvaluator.Name = "OwnerEvaluator"
        Me.OwnerEvaluator.Size = New System.Drawing.Size(256, 23)
        Me.OwnerEvaluator.TabIndex = 6
        '
        'OwnerLabel
        '
        Me.OwnerLabel.Location = New System.Drawing.Point(8, 80)
        Me.OwnerLabel.Name = "OwnerLabel"
        Me.OwnerLabel.Size = New System.Drawing.Size(88, 23)
        Me.OwnerLabel.TabIndex = 4
        Me.OwnerLabel.Text = "Owner:"
        Me.OwnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ItemName
        '
        Me.ItemName.Location = New System.Drawing.Point(96, 16)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Size = New System.Drawing.Size(256, 23)
        Me.ItemName.TabIndex = 1
        '
        'NameLabel
        '
        Me.NameLabel.Location = New System.Drawing.Point(8, 16)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(88, 23)
        Me.NameLabel.TabIndex = 0
        Me.NameLabel.Text = "Name:"
        Me.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EvaluatorLabel
        '
        Me.EvaluatorLabel.Location = New System.Drawing.Point(8, 80)
        Me.EvaluatorLabel.Name = "EvaluatorLabel"
        Me.EvaluatorLabel.Size = New System.Drawing.Size(88, 23)
        Me.EvaluatorLabel.TabIndex = 5
        Me.EvaluatorLabel.Text = "Evaluator:"
        Me.EvaluatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NotesTabPage
        '
        Me.NotesTabPage.AccessibleDescription = "View & edit notes for the selected item."
        Me.NotesTabPage.AccessibleName = "Notes Tab"
        Me.NotesTabPage.Controls.Add(Me.AnalysisNotes)
        Me.NotesTabPage.Location = New System.Drawing.Point(4, 28)
        Me.NotesTabPage.Name = "NotesTabPage"
        Me.NotesTabPage.Size = New System.Drawing.Size(360, 222)
        Me.NotesTabPage.TabIndex = 0
        Me.NotesTabPage.Text = "Notes"
        Me.NotesTabPage.ToolTipText = "User Notes"
        Me.NotesTabPage.Visible = False
        '
        'AnalysisNotes
        '
        Me.AnalysisNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnalysisNotes.Location = New System.Drawing.Point(0, 0)
        Me.AnalysisNotes.Multiline = True
        Me.AnalysisNotes.Name = "AnalysisNotes"
        Me.AnalysisNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.AnalysisNotes.Size = New System.Drawing.Size(360, 225)
        Me.AnalysisNotes.TabIndex = 0
        '
        'DataTabPage
        '
        Me.DataTabPage.AccessibleDescription = "View the history log for the selected item."
        Me.DataTabPage.AccessibleName = "Data History Tab"
        Me.DataTabPage.Controls.Add(Me.AnalysisDataHistory)
        Me.DataTabPage.Location = New System.Drawing.Point(4, 28)
        Me.DataTabPage.Name = "DataTabPage"
        Me.DataTabPage.Size = New System.Drawing.Size(360, 222)
        Me.DataTabPage.TabIndex = 2
        Me.DataTabPage.Text = "Data History"
        Me.DataTabPage.ToolTipText = "History of original data"
        Me.DataTabPage.Visible = False
        '
        'AnalysisDataHistory
        '
        Me.AnalysisDataHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnalysisDataHistory.Location = New System.Drawing.Point(0, 0)
        Me.AnalysisDataHistory.Name = "AnalysisDataHistory"
        Me.AnalysisDataHistory.ReadOnly = True
        Me.AnalysisDataHistory.Size = New System.Drawing.Size(360, 225)
        Me.AnalysisDataHistory.TabIndex = 0
        Me.AnalysisDataHistory.Text = ""
        Me.AnalysisDataHistory.WordWrap = False
        '
        'LogTabPage
        '
        Me.LogTabPage.AccessibleDescription = "View the run log for the selected item."
        Me.LogTabPage.AccessibleName = "Log Tab"
        Me.LogTabPage.Controls.Add(Me.AnalysisLog)
        Me.LogTabPage.Location = New System.Drawing.Point(4, 28)
        Me.LogTabPage.Name = "LogTabPage"
        Me.LogTabPage.Size = New System.Drawing.Size(360, 222)
        Me.LogTabPage.TabIndex = 1
        Me.LogTabPage.Text = "Log"
        Me.LogTabPage.ToolTipText = "Execution Log"
        '
        'AnalysisLog
        '
        Me.AnalysisLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnalysisLog.Location = New System.Drawing.Point(0, 0)
        Me.AnalysisLog.Name = "AnalysisLog"
        Me.AnalysisLog.ReadOnly = True
        Me.AnalysisLog.Size = New System.Drawing.Size(360, 225)
        Me.AnalysisLog.TabIndex = 0
        Me.AnalysisLog.Text = ""
        Me.AnalysisLog.WordWrap = False
        '
        'AnalysisDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DetailsTabControl)
        Me.Controls.Add(Me.AnalysisDetailsTitle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "AnalysisDetails"
        Me.Size = New System.Drawing.Size(368, 277)
        Me.DetailsTabControl.ResumeLayout(False)
        Me.IdTabPage.ResumeLayout(False)
        Me.IdTabPage.PerformLayout()
        Me.NotesTabPage.ResumeLayout(False)
        Me.NotesTabPage.PerformLayout()
        Me.DataTabPage.ResumeLayout(False)
        Me.LogTabPage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "
    '
    ' Data Store
    '
    Private mDataStore As DataStore.DataStore = DataStore.DataStore.Instance()
    '
    ' References to WinSRFR objects
    '
    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Private WithEvents mFarm As Farm = Nothing
    Private WithEvents mField As Field = Nothing
    Private WithEvents mWorld As World = Nothing
    Private WithEvents mUnit As Unit = Nothing
    Private WithEvents mUnitControl As UnitControl = Nothing
    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' UI support data
    '
    Private mItemName As String = String.Empty
    Private mMinItemNameWidth As Integer = 0

    Private mOwnerEvaluator As String = String.Empty
    Private mMinOwnerWidth As Integer = 0

    Private mNotesChanged As Boolean = False

    Private mChangingTabPages As Boolean = False
    Private mSelectedTabpage As Integer = 0

#End Region

#Region " Initialization "

    Public Sub ClearDetails()

        ' Reset object references
        mFarm = Nothing
        mField = Nothing
        mWorld = Nothing
        mUnit = Nothing
        mUnitControl = Nothing

        ' Start with only ID & Notes Tabs
        mChangingTabPages = True
        Me.DetailsTabControl.SuspendLayout()
        Me.DetailsTabControl.Controls.Clear()
        Me.DetailsTabControl.Controls.Add(Me.IdTabPage)
        Me.DetailsTabControl.Controls.Add(Me.NotesTabPage)
        Me.DetailsTabControl.ResumeLayout()
        mChangingTabPages = False

        ' Maintain the same selected tab page, if possible
        If (mSelectedTabpage < Me.DetailsTabControl.Controls.Count) Then
            Me.DetailsTabControl.SelectedIndex = mSelectedTabpage
        Else
            Me.DetailsTabControl.SelectedIndex = 0
        End If

        ' Reset values
        mItemName = String.Empty
        mOwnerEvaluator = String.Empty
        mNotesChanged = False

        ' Since there is no Farm; start with minimal UI
        AnalysisDetailsTitle.Text = mDictionary.tDetails.Translated

        ItemName.Enabled = False
        ItemName.Text = mItemName

        CreationTime.Text = String.Empty

        OwnerEvaluator.Enabled = False
        OwnerEvaluator.Text = mOwnerEvaluator

        AnalysisNotes.Enabled = False
        AnalysisNotes.Text = mDictionary.tNA.Translated

    End Sub

    Public Sub Initialize(ByVal _winSRFR As WinSRFR)

        ' Save WinSRFR reference
        If Not (_winSRFR Is Nothing) Then
            mWinSRFR = _winSRFR
        Else
            Debug.Assert(False, "WinSRFR is Nothing")
        End If

        ' Save original control widths as minimum widths
        mMinItemNameWidth = ItemName.Width
        mMinOwnerWidth = OwnerEvaluator.Width

        ' Clear the Details display
        Me.ClearDetails()

    End Sub

#End Region

#Region " Methods "

    Public Sub DisplayFarmDetails(ByVal _farm As Farm)

        ' Update any previous data if it has changed
        SaveNameChanges()
        SaveOwnerEvaluatorChanges()
        SaveNotesChanges()

        If (_farm IsNot Nothing) Then

            ' No Data History or Log for Farms
            If (Me.DetailsTabControl.Controls.Contains(Me.DataTabPage)) Then
                mChangingTabPages = True
                Me.DetailsTabControl.SuspendLayout()
                Me.DetailsTabControl.Controls.Remove(Me.DataTabPage)
                Me.DetailsTabControl.ResumeLayout()
                mChangingTabPages = False
            End If

            If (Me.DetailsTabControl.Controls.Contains(Me.LogTabPage)) Then
                mChangingTabPages = True
                Me.DetailsTabControl.SuspendLayout()
                Me.DetailsTabControl.Controls.Remove(Me.LogTabPage)
                Me.DetailsTabControl.ResumeLayout()
                mChangingTabPages = False
            End If

            ' Maintain the same selected tab page, if possible
            If (mSelectedTabpage < Me.DetailsTabControl.Controls.Count) Then
                Me.DetailsTabControl.SelectedIndex = mSelectedTabpage
            Else
                Me.DetailsTabControl.SelectedIndex = 0
            End If

            ' Save the object's reference; clear the others
            mFarm = _farm
            mField = Nothing
            mWorld = Nothing
            mUnit = Nothing

            ' Update the Title
            AnalysisDetailsTitle.BackColor = System.Drawing.SystemColors.Control
            AnalysisDetailsTitle.ForeColor = System.Drawing.SystemColors.ControlText
            AnalysisDetailsTitle.Text = mDictionary.tDetails.Translated _
                                      + " - " + mWinSRFR.ProjectFarmText _
                                      + ": " + mFarm.Name.Value

            ' Display the details
            mItemName = mFarm.Name.Value
            ItemName.Text = mItemName
            ItemName.Enabled = True

            EvaluatorLabel.Hide()
            OwnerLabel.Show()
            OwnerEvaluator.Enabled = True
            OwnerEvaluator.Show()
            mOwnerEvaluator = mFarm.Owner.Value
            OwnerEvaluator.Text = mOwnerEvaluator

            CreationTime.Text = mFarm.CreationDateTime.Value.ToString("ddd, MMM dd, yyyy  h:mm tt")

            AnalysisNotes.Text = mFarm.Notes.Value
            AnalysisNotes.Enabled = True
            mNotesChanged = False

        Else
            ItemName.Text = ""
            ItemName.Enabled = False
        End If

    End Sub

    Public Sub DisplayFieldDetails(ByVal _field As Field)

        ' Update any previous data if it has changed
        SaveNameChanges()
        SaveOwnerEvaluatorChanges()
        SaveNotesChanges()

        If (_field IsNot Nothing) Then

            ' No Data History or Log for Fields
            If (Me.DetailsTabControl.Controls.Contains(Me.DataTabPage)) Then
                mChangingTabPages = True
                Me.DetailsTabControl.SuspendLayout()
                Me.DetailsTabControl.Controls.Remove(Me.DataTabPage)
                Me.DetailsTabControl.ResumeLayout()
                mChangingTabPages = False
            End If

            If (Me.DetailsTabControl.Controls.Contains(Me.LogTabPage)) Then
                mChangingTabPages = True
                Me.DetailsTabControl.SuspendLayout()
                Me.DetailsTabControl.Controls.Remove(Me.LogTabPage)
                Me.DetailsTabControl.ResumeLayout()
                mChangingTabPages = False
            End If

            ' Maintain the same selected tab page, if possible
            If (mSelectedTabpage < Me.DetailsTabControl.Controls.Count) Then
                Me.DetailsTabControl.SelectedIndex = mSelectedTabpage
            Else
                Me.DetailsTabControl.SelectedIndex = 0
            End If

            ' Save the object's reference; clear the others
            mFarm = Nothing
            mField = _field
            mWorld = Nothing
            mUnit = Nothing

            ' Update the Title
            AnalysisDetailsTitle.BackColor = System.Drawing.SystemColors.Control
            AnalysisDetailsTitle.ForeColor = System.Drawing.SystemColors.ControlText
            AnalysisDetailsTitle.Text = mDictionary.tDetails.Translated _
                                      + " - " + mWinSRFR.CaseFieldText _
                                      + ": " + mField.Name.Value

            ' Display the details
            mItemName = mField.Name.Value
            ItemName.Text = mItemName
            ItemName.Enabled = True

            EvaluatorLabel.Hide()
            OwnerLabel.Hide()
            OwnerEvaluator.Enabled = False
            OwnerEvaluator.Hide()

            CreationTime.Text = mField.CreationDateTime.Value.ToString("ddd, MMM dd, yyyy  h:mm tt")

            AnalysisNotes.Text = mField.Notes.Value
            AnalysisNotes.Enabled = True
            mNotesChanged = False
        Else
            ItemName.Text = ""
            ItemName.Enabled = False
        End If

    End Sub

    Public Sub DisplayWorldDetails(ByVal _world As World)

        ' Update any previous data if it has changed
        SaveNameChanges()
        SaveOwnerEvaluatorChanges()
        SaveNotesChanges()

        If (_world IsNot Nothing) Then

            ' No Data History or Log for Worlds
            If (Me.DetailsTabControl.Controls.Contains(Me.DataTabPage)) Then
                mChangingTabPages = True
                Me.DetailsTabControl.SuspendLayout()
                Me.DetailsTabControl.Controls.Remove(Me.DataTabPage)
                Me.DetailsTabControl.ResumeLayout()
                mChangingTabPages = False
            End If

            If (Me.DetailsTabControl.Controls.Contains(Me.LogTabPage)) Then
                mChangingTabPages = True
                Me.DetailsTabControl.SuspendLayout()
                Me.DetailsTabControl.Controls.Remove(Me.LogTabPage)
                Me.DetailsTabControl.ResumeLayout()
                mChangingTabPages = False
            End If

            ' Maintain the same selected tab page, if possible
            If (mSelectedTabpage < Me.DetailsTabControl.Controls.Count) Then
                Me.DetailsTabControl.SelectedIndex = mSelectedTabpage
            Else
                Me.DetailsTabControl.SelectedIndex = 0
            End If

            ' Save the object's reference; clear the others
            mFarm = Nothing
            mField = Nothing
            mWorld = _world
            mUnit = Nothing

            ' Update the Title
            Dim _backColor As System.Drawing.Color = System.Drawing.SystemColors.Control
            Dim _foreColor As System.Drawing.Color = System.Drawing.SystemColors.ControlText
            Dim _title As String = WorldsText(mWorld.WorldType.Value) + ": "

            Select Case (mWorld.WorldType.Value)

                Case WorldTypes.DesignWorld
                    _backColor = mWinSRFR.DesignBackColor
                    _foreColor = mWinSRFR.DesignForeColor

                Case WorldTypes.EventWorld
                    _backColor = mWinSRFR.EventBackColor
                    _foreColor = mWinSRFR.EventForeColor

                Case WorldTypes.OperationsWorld
                    _backColor = mWinSRFR.OperationsBackColor
                    _foreColor = mWinSRFR.OperationsForeColor

                Case WorldTypes.SimulationWorld
                    _backColor = mWinSRFR.SimulationBackColor
                    _foreColor = mWinSRFR.SimulationForeColor

            End Select

            AnalysisDetailsTitle.BackColor = _backColor
            AnalysisDetailsTitle.ForeColor = _foreColor
            AnalysisDetailsTitle.Text = mDictionary.tDetails.Translated _
                                      + " - " + _title + mWorld.Name.Value

            ' Display the details
            mItemName = mWorld.Name.Value
            ItemName.Text = mItemName
            ItemName.Enabled = True

            EvaluatorLabel.Hide()
            OwnerLabel.Hide()
            OwnerEvaluator.Enabled = False
            OwnerEvaluator.Hide()

            CreationTime.Text = mWorld.CreationDateTime.Value.ToString("ddd, MMM dd, yyyy  h:mm tt")

            AnalysisNotes.Text = mWorld.Notes.Value
            AnalysisNotes.Enabled = True
            mNotesChanged = False
        Else
            ItemName.Text = ""
            ItemName.Enabled = False
        End If

    End Sub

    Public Sub DisplayUnitDetails(ByVal _unit As Unit)

        ' Update any previous data if it has changed
        SaveNameChanges()
        SaveOwnerEvaluatorChanges()
        SaveNotesChanges()

        If (_unit IsNot Nothing) Then

            ' Units have both Data History and Log
            Dim historyParam As ArrayListParameter = _unit.DataHistory
            If (historyParam IsNot Nothing) Then
                Dim historyArray As ArrayList = historyParam.Array
                If (historyArray IsNot Nothing) Then
                    If (0 < historyArray.Count) Then
                        If Not (Me.DetailsTabControl.Controls.Contains(Me.DataTabPage)) Then
                            mChangingTabPages = True
                            Me.DetailsTabControl.SuspendLayout()
                            Me.DetailsTabControl.Controls.Add(Me.DataTabPage)
                            Me.DetailsTabControl.ResumeLayout()
                            mChangingTabPages = False
                        End If
                    End If
                End If
            End If

            Dim logParam As ArrayListParameter = _unit.UnitControlRef.Log
            If (logParam IsNot Nothing) Then
                Dim logArray As ArrayList = logParam.Array
                If (logArray IsNot Nothing) Then
                    If (0 < logArray.Count) Then
                        If Not (Me.DetailsTabControl.Controls.Contains(Me.LogTabPage)) Then
                            mChangingTabPages = True
                            Me.DetailsTabControl.SuspendLayout()
                            Me.DetailsTabControl.Controls.Add(Me.LogTabPage)
                            Me.DetailsTabControl.ResumeLayout()
                            mChangingTabPages = False
                        End If
                    End If
                End If
            End If

            ' Maintain the same selected tab page, if possible
            If (mSelectedTabpage < Me.DetailsTabControl.Controls.Count) Then
                Me.DetailsTabControl.SelectedIndex = mSelectedTabpage
            Else
                Me.DetailsTabControl.SelectedIndex = 0
            End If

            ' Save the object's reference; clear the others
            mFarm = Nothing
            mField = Nothing
            mWorld = Nothing
            mUnit = _unit
            mUnitControl = mUnit.UnitControlRef

            ' Update the Title
            Dim _backColor As System.Drawing.Color = System.Drawing.SystemColors.Control
            Dim _foreColor As System.Drawing.Color = System.Drawing.SystemColors.ControlText

            Select Case (_unit.UnitType.Value)

                Case WorldTypes.DesignWorld
                    _backColor = mWinSRFR.DesignBackColor
                    _foreColor = mWinSRFR.DesignForeColor

                Case WorldTypes.EventWorld
                    _backColor = mWinSRFR.EventBackColor
                    _foreColor = mWinSRFR.EventForeColor

                Case WorldTypes.OperationsWorld
                    _backColor = mWinSRFR.OperationsBackColor
                    _foreColor = mWinSRFR.OperationsForeColor

                Case WorldTypes.SimulationWorld
                    _backColor = mWinSRFR.SimulationBackColor
                    _foreColor = mWinSRFR.SimulationForeColor

            End Select

            AnalysisDetailsTitle.BackColor = _backColor
            AnalysisDetailsTitle.ForeColor = _foreColor
            AnalysisDetailsTitle.Text = mDictionary.tDetails.Translated _
                                      + " - " + _unit.Name.Value

            ' Display the details
            mItemName = _unit.Name.Value
            ItemName.Text = mItemName
            ItemName.Enabled = True

            OwnerLabel.Hide()
            EvaluatorLabel.Show()
            OwnerEvaluator.Enabled = True
            OwnerEvaluator.Show()
            mOwnerEvaluator = _unit.Evaluator.Value
            OwnerEvaluator.Text = mOwnerEvaluator

            CreationTime.Text = _unit.CreationDateTime.Value.ToString("ddd, MMM dd, yyyy  h:mm tt")

            AnalysisNotes.Text = mUnit.Notes.Value
            AnalysisNotes.Enabled = True
            mNotesChanged = False

            AnalysisDataHistory.Clear()
            If (mUnit.DataHistory IsNot Nothing) Then
                Dim historyArray As ArrayList = mUnit.DataHistory.Array
                For Each obj As Object In historyArray
                    If (obj.GetType Is GetType(String)) Then
                        Dim _string As String = CStr(obj)
                        AppendLine(AnalysisDataHistory, _string)
                    End If
                Next
            End If

            AnalysisLog.Clear()
            If (mUnitControl.Log IsNot Nothing) Then
                Dim logArray As ArrayList = mUnitControl.Log.Array
                For Each obj As Object In logArray
                    If (obj.GetType Is GetType(String)) Then
                        Dim _string As String = CStr(obj)
                        AppendLine(AnalysisLog, _string)
                    End If
                Next
            End If
        Else
            ItemName.Text = ""
            ItemName.Enabled = False
        End If

    End Sub

    Private Sub SizeControls()

        Dim _frmWidth As Integer = Me.Width
        Dim _ctrlLeft As Integer = ItemName.Left
        Dim _newWidth As Integer = _frmWidth - _ctrlLeft - 20

        If (_newWidth < mMinItemNameWidth) Then
            _newWidth = mMinItemNameWidth
        End If

        ItemName.Width = _newWidth
        CreationTime.Width = _newWidth
        OwnerEvaluator.Width = _newWidth

    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' WinSRFR changes
    '
    Private Sub WinSrfr_Updated(ByVal reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated
        If ((reason = WinSRFR.Reasons.Nomenclature) _
         Or (reason = WinSRFR.Reasons.Language)) Then
            If Not (mFarm Is Nothing) Then
                DisplayFarmDetails(mFarm)
            ElseIf Not (mField Is Nothing) Then
                DisplayFieldDetails(mField)
            ElseIf Not (mWorld Is Nothing) Then
                DisplayWorldDetails(mWorld)
            ElseIf Not (mUnit Is Nothing) Then
                DisplayUnitDetails(mUnit)
            End If
        End If
    End Sub
    '
    ' Farm changes
    '
    Private Sub Farm_Updated(ByVal reason As Farm.Reasons) _
    Handles mFarm.FarmUpdated
        If Not (reason = Farm.Reasons.FieldList) Then
            DisplayFarmDetails(mFarm)
        End If
    End Sub
    '
    ' Field changes
    '
    Private Sub Field_Updated(ByVal reason As Field.Reasons) _
    Handles mField.FieldUpdated
        If Not (reason = Field.Reasons.WorldList) Then
            DisplayFieldDetails(mField)
        End If
    End Sub
    '
    ' World changes
    '
    Private Sub World_Updated(ByVal reason As World.Reasons) _
    Handles mWorld.WorldUpdated
        If Not (reason = World.Reasons.AnalysisList) Then
            DisplayWorldDetails(mWorld)
        End If
    End Sub
    '
    ' Unit changes
    '
    Private Sub Unit_Updated(ByVal reason As Unit.Reasons) _
    Handles mUnit.UnitUpdated
        DisplayUnitDetails(mUnit)
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " ItemName Events "
    '
    ' Save the new Object Name
    '
    Private mSavingObjectName As Boolean = False

    Private Sub SaveNameChanges()

        If (mSavingObjectName = False) Then
            mSavingObjectName = True

            ' Define MsgBox parameters
            Dim _title As String = mDictionary.tErrNameChange.Translated
            Dim _style As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly

            ' Process text input; has it changed?
            If Not (mItemName = ItemName.Text) Then

                ' This is a new value
                mItemName = ItemName.Text
                Dim _msg As String = mItemName & " " & mDictionary.tIsNotUnique.Translated

                If (mFarm IsNot Nothing) Then

                    ' Verify Farm Name is unique within WinSRFR
                    Dim _winSRFR As WinSRFR = mFarm.WinSrfrRef
                    Dim _farm As Farm = _winSRFR.GetFarmByName(mItemName)

                    If (_farm Is Nothing) Then
                        ' This is a unique name, save it
                        mDataStore.MarkForUndo(mWinSRFR.ProjectFarmText & " " & mDictionary.tNameChange.Translated)

                        ' Update value
                        Dim _string As StringParameter = mFarm.Name
                        _string.Value = mItemName
                        _string.Source = DataStore.Globals.ValueSources.UserEntered
                        mFarm.Name = _string
                    Else
                        ' This name is already in use
                        MsgBox(_msg, _style, _title)
                        ' Restore the old name in the UI
                        mItemName = mFarm.Name.Value
                    End If

                ElseIf (mField IsNot Nothing) Then

                    ' Verify Field Name is unique within its Farm
                    Dim _farm As Farm = mField.FarmRef
                    Dim _field As Field = _farm.GetFieldByName(mItemName)

                    If (_field Is Nothing) Then
                        ' This is a unique name, save it
                        mDataStore.MarkForUndo(mWinSRFR.CaseFieldText & " " & mDictionary.tNameChange.Translated)

                        ' Update value
                        Dim _string As StringParameter = mField.Name
                        _string.Value = mItemName
                        _string.Source = DataStore.Globals.ValueSources.UserEntered
                        mField.Name = _string
                    Else
                        ' This name is already in use
                        MsgBox(_msg & " " & mDictionary.tWithinFarm.Translated & ": " & _farm.Name.Value, _style, _title)
                        ' Restore the old name in the UI
                        mItemName = mField.Name.Value
                    End If

                ElseIf Not (mWorld Is Nothing) Then

                    ' Verify World Name is unique within its Field
                    Dim _field As Field = mWorld.FieldRef
                    Dim _type As WorldTypes = CType(mWorld.WorldType.Value, WorldTypes)
                    Dim _world As World = _field.GetWorldByName(_type, mItemName)

                    If (_world Is Nothing) Then
                        ' This is a unique name, save it
                        mDataStore.MarkForUndo(WorldsText(_type) & " " & mDictionary.tNameChange.Translated)

                        ' Update value
                        Dim _string As StringParameter = mWorld.Name
                        _string.Value = mItemName
                        _string.Source = DataStore.Globals.ValueSources.UserEntered
                        mWorld.Name = _string
                    Else
                        ' This name is already in use
                        MsgBox(WorldsText(_type) + ": " + _msg & " " & mDictionary.tWithinField.Translated & ": " & _field.Name.Value, _style, _title)
                        ' Restore the old name in the UI
                        mItemName = mWorld.Name.Value
                    End If

                ElseIf Not (mUnit Is Nothing) Then

                    ' Verify Unit Name is unique within its World
                    Dim _world As World = mUnit.WorldRef
                    Dim _unit As Unit = _world.GetAnalysisByName(mItemName)
                    Dim _type As WorldTypes = CType(_world.WorldType.Value, WorldTypes)

                    If (_unit Is Nothing) Then
                        ' This is a unique name, save it
                        mDataStore.MarkForUndo(mDictionary.tAnalysis.Translated & " " & mDictionary.tNameChange.Translated)

                        ' Update value
                        Dim _string As StringParameter = mUnit.Name
                        _string.Value = mItemName
                        _string.Source = DataStore.Globals.ValueSources.UserEntered
                        mUnit.Name = _string

                        ' Update the Analysis' Data History
                        Dim _datetime As String = System.DateTime.Now.ToLongDateString _
                                                + " at " _
                                                + System.DateTime.Now.ToLongTimeString

                        Dim _dataHistory As ArrayListParameter = mUnit.DataHistory
                        If (_dataHistory IsNot Nothing) Then
                            _dataHistory.Source = DataStore.Globals.ValueSources.Calculated
                            _dataHistory.Array.Insert(0, " ")
                            _dataHistory.Array.Insert(0, "     " & mDictionary.tTo.Translated & ":  " + mUnit.Name.Value)
                            _dataHistory.Array.Insert(0, mDictionary.tNameChange.Translated & " by " & mUnit.UnitControlRef.ProductVersion.Value & " - " & _datetime)
                            mUnit.DataHistory = _dataHistory
                        End If
                    Else
                        ' This name is already in use
                        MsgBox(_msg + " " & mDictionary.tWithin.Translated & " " + WorldsText(_type) + ": " + _world.Name.Value, _style, _title)
                        ' Restore the old name in the UI
                        mItemName = mUnit.Name.Value
                    End If

                End If
            End If

            ItemName.Text = mItemName
            mSavingObjectName = False

            mWinSRFR.UpdateToolbar()

        End If

    End Sub
    '
    ' Handle ItemName events that cause name to be changed
    '
    Private Sub ObjectName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ItemName.KeyPress
        ' Absorb KepPress for Return key to suppress beep
        '   Note - setting e.Handled to True in KeyDown handler doesn't suppress beep
        If e.KeyChar = Chr(13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ObjectName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ItemName.KeyDown
        ' Enter the new value when the Return key is pressed
        If (e.KeyCode = Windows.Forms.Keys.Return) Then
            ' Save the new Object Name
            SaveNameChanges()
            ' Select all the text so the user can easily re-enter value
            ItemName.Focus()
            ItemName.SelectAll()
        End If
    End Sub

    Private Sub ObjectName_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemName.LostFocus
        ' Save the new Object Name
        SaveNameChanges()
    End Sub

    Private Sub ObjectName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemName.Enter
        If Not (mWinSRFR Is Nothing) Then
            mWinSRFR.StatusMessage = ItemName.AccessibleDescription
        End If
    End Sub

#End Region

#Region " Owner / Evaluator Events "
    '
    ' Save the new Owner / Evaluator (They share a single control)
    '
    Private Sub SaveOwnerEvaluatorChanges()

        ' Process text input; has it changed?
        If Not (OwnerEvaluator.Text = mOwnerEvaluator) Then

            ' This is a new value
            mOwnerEvaluator = OwnerEvaluator.Text

            If Not (mFarm Is Nothing) Then

                mDataStore.MarkForUndo(mDictionary.tOwnerChange.Translated)

                ' Update value
                Dim _string As StringParameter = mFarm.Owner
                _string.Value = mOwnerEvaluator
                _string.Source = DataStore.Globals.ValueSources.UserEntered
                mFarm.Owner = _string

            ElseIf Not (mUnit Is Nothing) Then

                mDataStore.MarkForUndo(mDictionary.tEvaluatorChange.Translated)

                ' Update value
                Dim _string As StringParameter = mUnit.Evaluator
                _string.Value = mOwnerEvaluator
                _string.Source = DataStore.Globals.ValueSources.UserEntered
                mUnit.Evaluator = _string

            End If

            mWinSRFR.UpdateToolbar()

        End If

    End Sub
    '
    ' Handle Owner /Evaluator events that cause name to be changed
    '
    Private Sub OwnerEvaluator_KeyPress(ByVal sender As System.Object, _
                                        ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles OwnerEvaluator.KeyPress
        ' Absorb KepPress for Return key to suppress beep
        '   Note - setting e.Handled to True in KeyDown handler doesn't suppress beep
        If e.KeyChar = Chr(13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub OwnerEvaluator_KeyDown(ByVal sender As System.Object, _
                                       ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles OwnerEvaluator.KeyDown
        ' Enter the new value when the Return key is pressed
        If (e.KeyCode = Windows.Forms.Keys.Return) Then
            ' Save the new Object Name
            SaveOwnerEvaluatorChanges()
            ' Select all the text so the user can easily re-enter value
            OwnerEvaluator.Focus()
            OwnerEvaluator.SelectAll()
        End If
    End Sub
    'End Sub

    Private Sub OwnerEvaluator_LostFocus(ByVal sender As System.Object, _
                                         ByVal e As System.EventArgs) _
    Handles OwnerEvaluator.LostFocus
        ' Save the new Object Name
        SaveOwnerEvaluatorChanges()
    End Sub

    Private Sub OwnerEvaluator_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OwnerEvaluator.Enter
        If Not (mWinSRFR Is Nothing) Then
            mWinSRFR.StatusMessage = OwnerEvaluator.AccessibleDescription
        End If
    End Sub

#End Region

#Region " Notes Events "
    '
    ' If the notes have changed, save the changes.
    '
    Private Sub SaveNotesChanges()

        If (mNotesChanged) Then
            mNotesChanged = False

            Dim _string As StringParameter

            ' Put new notes into correct object
            If Not (mFarm Is Nothing) Then

                mDataStore.MarkForUndo(mWinSRFR.ProjectFarmText & " " & mDictionary.tNotesChange.Translated)

                _string = mFarm.Notes
                _string.Value = AnalysisNotes.Text
                _string.Source = DataStore.Globals.ValueSources.UserEntered
                mFarm.Notes = _string

            ElseIf Not (mField Is Nothing) Then

                mDataStore.MarkForUndo(mWinSRFR.CaseFieldText & " " & mDictionary.tNotesChange.Translated)

                _string = mField.Notes
                _string.Value = AnalysisNotes.Text
                _string.Source = DataStore.Globals.ValueSources.UserEntered
                mField.Notes = _string

            ElseIf Not (mWorld Is Nothing) Then

                mDataStore.MarkForUndo(WorldsText(mWorld.WorldType.Value) & " " & mDictionary.tNotesChange.Translated)

                _string = mWorld.Notes
                _string.Value = AnalysisNotes.Text
                _string.Source = DataStore.Globals.ValueSources.UserEntered
                mWorld.Notes = _string

            ElseIf Not (mUnit Is Nothing) Then

                mDataStore.MarkForUndo(mDictionary.tAnalysis.Translated & " " & mDictionary.tNotesChange.Translated)

                _string = mUnit.Notes
                _string.Value = AnalysisNotes.Text
                _string.Source = DataStore.Globals.ValueSources.UserEntered
                mUnit.Notes = _string

            End If

            mWinSRFR.UpdateToolbar()

        End If

    End Sub

    Private Sub AnalysisNotes_TextChanged(ByVal sender As System.Object, _
                                          ByVal e As System.EventArgs) _
    Handles AnalysisNotes.TextChanged
        ' Set flag indicating Notes have changed
        mNotesChanged = True
    End Sub

    Private Sub AnalysisNotes_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AnalysisNotes.Enter
        If Not (mWinSRFR Is Nothing) Then
            mWinSRFR.StatusMessage = AnalysisNotes.AccessibleDescription
        End If
    End Sub

    Private Sub AnalysisNotes_LostFocus(ByVal sender As System.Object, _
                                        ByVal e As System.EventArgs) _
    Handles AnalysisNotes.LostFocus
        ' Update the Notes if they have changed
        SaveNotesChanges()
    End Sub

    Private Sub AnalysisNotes_MouseLeave(ByVal sender As System.Object, _
                                         ByVal e As System.EventArgs) _
    Handles AnalysisNotes.MouseLeave
        ' Update the Notes if they have changed
        SaveNotesChanges()
    End Sub

#End Region

#Region " Other UI Events "
    '
    ' Track selected tabpage & controls
    '
    Private Sub DetailsTabControl_SelectedIndexChanged(ByVal sender As System.Object, _
                                                       ByVal e As System.EventArgs) _
    Handles DetailsTabControl.SelectedIndexChanged
        If Not (mChangingTabPages) Then
            mSelectedTabpage = DetailsTabControl.SelectedIndex

            ' Update the Status Bar message
            If Not (mWinSRFR Is Nothing) Then
                Dim _tabPage As TabPage = DetailsTabControl.TabPages(mSelectedTabpage)
                If Not (_tabPage Is Nothing) Then
                    mWinSRFR.StatusMessage = _tabPage.AccessibleDescription
                End If
            End If
        End If
    End Sub

    Private Sub DetailsTabControl_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DetailsTabControl.Enter
        If Not (mWinSRFR Is Nothing) Then
            mWinSRFR.StatusMessage = DetailsTabControl.AccessibleDescription
        End If
    End Sub

    Private Sub AnalysisDataHistory_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AnalysisDataHistory.Enter
        If Not (mWinSRFR Is Nothing) Then
            mWinSRFR.StatusMessage = AnalysisDataHistory.AccessibleDescription
        End If
    End Sub

    Private Sub AnalysisLog_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AnalysisLog.Enter
        If Not (mWinSRFR Is Nothing) Then
            mWinSRFR.StatusMessage = AnalysisLog.AccessibleDescription
        End If
    End Sub
    '
    ' Control sizes track parent size
    '
    Private Sub Form_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        SizeControls()
    End Sub

#End Region

#End Region

End Class
