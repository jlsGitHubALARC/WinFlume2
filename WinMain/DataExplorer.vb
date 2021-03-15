
'**********************************************************************************************
' Data Explorer - User Control for accessing WinSRFR's data.
'
Public Class DataExplorer
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
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents DataExplorerLabel As System.Windows.Forms.Label
    Friend WithEvents DataTreeView As System.Windows.Forms.TreeView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataExplorer))
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.DataExplorerLabel = New System.Windows.Forms.Label
        Me.DataTreeView = New System.Windows.Forms.TreeView
        Me.SuspendLayout()
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "")
        Me.ImageList.Images.SetKeyName(1, "")
        Me.ImageList.Images.SetKeyName(2, "")
        Me.ImageList.Images.SetKeyName(3, "")
        Me.ImageList.Images.SetKeyName(4, "")
        Me.ImageList.Images.SetKeyName(5, "")
        Me.ImageList.Images.SetKeyName(6, "")
        Me.ImageList.Images.SetKeyName(7, "")
        Me.ImageList.Images.SetKeyName(8, "")
        Me.ImageList.Images.SetKeyName(9, "")
        Me.ImageList.Images.SetKeyName(10, "")
        Me.ImageList.Images.SetKeyName(11, "")
        Me.ImageList.Images.SetKeyName(12, "")
        Me.ImageList.Images.SetKeyName(13, "")
        Me.ImageList.Images.SetKeyName(14, "")
        '
        'DataExplorerLabel
        '
        Me.DataExplorerLabel.BackColor = System.Drawing.SystemColors.Info
        Me.DataExplorerLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataExplorerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataExplorerLabel.ForeColor = System.Drawing.SystemColors.InfoText
        Me.DataExplorerLabel.Location = New System.Drawing.Point(0, 0)
        Me.DataExplorerLabel.Name = "DataExplorerLabel"
        Me.DataExplorerLabel.Size = New System.Drawing.Size(300, 23)
        Me.DataExplorerLabel.TabIndex = 0
        Me.DataExplorerLabel.Text = "Data Explorer"
        Me.DataExplorerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataTreeView
        '
        Me.DataTreeView.BackColor = System.Drawing.SystemColors.Control
        Me.DataTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataTreeView.ImageIndex = 0
        Me.DataTreeView.ImageList = Me.ImageList
        Me.DataTreeView.Location = New System.Drawing.Point(0, 23)
        Me.DataTreeView.Name = "DataTreeView"
        Me.DataTreeView.SelectedImageIndex = 0
        Me.DataTreeView.Size = New System.Drawing.Size(300, 377)
        Me.DataTreeView.TabIndex = 1
        '
        'DataExplorer
        '
        Me.Controls.Add(Me.DataTreeView)
        Me.Controls.Add(Me.DataExplorerLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DataExplorer"
        Me.Size = New System.Drawing.Size(300, 400)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Class FarmTreeNode "
    '
    ' TreeView node for Farm objects
    '
    Private Class FarmTreeNode
        Inherits System.Windows.Forms.TreeNode

#Region " Member Data "

        Private mWinSRFR As WinSRFR = Nothing

        Private WithEvents mFarm As Farm = Nothing
        Public ReadOnly Property Farm() As Farm
            Get
                Return mFarm
            End Get
        End Property

#End Region

#Region " Constructor "

        Public Sub New(ByVal _winSRFR As WinSRFR, ByVal _farm As Farm)
            MyBase.New(_winSRFR.ProjectFarmText + Separator + _farm.Name.Value)
            mWinSRFR = _winSRFR
            mFarm = _farm
        End Sub

#End Region

#Region " Methods "

        Protected Friend Sub AddFields()

            Dim _field As Field = mFarm.GetFirstField

            While Not (_field Is Nothing)
                ' Field is not in TreeView; create and add a new node for it
                Dim _fieldNode As FieldTreeNode = New FieldTreeNode(mWinSRFR, _field)

                _fieldNode.ImageIndex = ImageIndexes.FieldIcon
                _fieldNode.SelectedImageIndex = ImageIndexes.FieldIcon

                ' Add the Worlds below the Field
                _fieldNode.AddWorlds()

                ' Only add the Field node if it contains Worlds
                If (0 < _fieldNode.Nodes.Count) Then
                    _fieldNode.Expand()
                    Me.Nodes.Add(_fieldNode)
                End If

                _field = mFarm.GetNextField
            End While

        End Sub

#End Region

    End Class

#End Region

#Region " Class FieldTreeNode "

    Private Class FieldTreeNode
        Inherits System.Windows.Forms.TreeNode

#Region " Member Data "

        Private mWinSRFR As WinSRFR = Nothing

        Private WithEvents mField As Field = Nothing
        Public ReadOnly Property Field() As Field
            Get
                Return mField
            End Get
        End Property

#End Region

#Region " Constructors "

        Public Sub New(ByVal _winSRFR As WinSRFR, ByVal _field As Field)
            MyBase.New(_winSRFR.CaseFieldText + Separator + _field.Name.Value)
            mWinSRFR = _winSRFR
            mField = _field
        End Sub

#End Region

#Region " Methods "

        Protected Friend Sub AddWorlds()

            Dim _world As World = mField.GetFirstWorld

            While Not (_world Is Nothing)
                ' World is not in TreeView; create and add a new node for it
                Dim _worldNode As WorldTreeNode = New WorldTreeNode(_world)

                Select Case (_world.WorldType.Value)

                    Case WorldTypes.DesignWorld
                        _worldNode.ImageIndex = ImageIndexes.DesignIcon
                        _worldNode.SelectedImageIndex = ImageIndexes.DesignIcon

                    Case WorldTypes.EventWorld
                        _worldNode.ImageIndex = ImageIndexes.EventIcon
                        _worldNode.SelectedImageIndex = ImageIndexes.EventIcon

                    Case WorldTypes.OperationsWorld
                        _worldNode.ImageIndex = ImageIndexes.OperationsIcon
                        _worldNode.SelectedImageIndex = ImageIndexes.OperationsIcon

                    Case WorldTypes.SimulationWorld
                        _worldNode.ImageIndex = ImageIndexes.SimulationIcon
                        _worldNode.SelectedImageIndex = ImageIndexes.SimulationIcon

                    Case Else
                        Debug.Assert(False, "Invalid World Type")
                End Select

                ' Add the Analyses below the World
                _worldNode.AddAnalyses()

                ' Only add the World node if it contains Analyses
                If (0 < _worldNode.Nodes.Count) Then
                    _worldNode.Expand()
                    Me.Nodes.Add(_worldNode)
                End If

                _world = mField.GetNextWorld
            End While

        End Sub

#End Region

    End Class

#End Region

#Region " Class WorldTreeNode "

    Private Class WorldTreeNode
        Inherits System.Windows.Forms.TreeNode

#Region " Member Data "

        Private mWorld As World = Nothing
        Public ReadOnly Property World() As World
            Get
                Return mWorld
            End Get
        End Property

#End Region

#Region " Constructors "

        Public Sub New(ByVal _world As World)
            MyBase.New(WorldsText(_world.WorldType.Value) + Separator + _world.Name.Value)
            mWorld = _world
        End Sub

#End Region

#Region " Methods "

        Protected Friend Sub AddAnalyses()

            Dim _analysis As Unit = mWorld.GetFirstAnalysis

            While Not (_analysis Is Nothing)

                Dim _analysisNode As AnalysisTreeNode = New AnalysisTreeNode(_analysis)
                Me.Nodes.Add(_analysisNode)

                _analysis = mWorld.GetNextAnalysis
            End While

        End Sub

#End Region

    End Class

#End Region

#Region " Class AnalysisTreeNode "

    Private Class AnalysisTreeNode
        Inherits System.Windows.Forms.TreeNode

#Region " Properties "

        Private mAnalysis As Unit = Nothing
        Public ReadOnly Property Analysis() As Unit
            Get
                Return mAnalysis
            End Get
        End Property

        Private mSelected As Boolean = False
        Public Property Selected() As Boolean
            Get
                Return mSelected
            End Get
            Set(ByVal Value As Boolean)
                mSelected = Value
            End Set
        End Property

#End Region

#Region " Constructors "

        Public Sub New(ByVal _analysis As Unit)
            MyBase.New(_analysis.Name.Value)
            mAnalysis = _analysis
            UpdateIcon()
        End Sub

#End Region

#Region " Methods "

        Public Sub UpdateIcon()

            If Not (mAnalysis Is Nothing) Then
                If (mAnalysis.ResultsAreValid) Then
                    If (0 = mAnalysis.PerformanceResultsRef.ErrorCount.Value) Then
                        If (Selected) Then
                            Me.ImageIndex = ImageIndexes.ResultsCheckedIcon
                            Me.SelectedImageIndex = ImageIndexes.ResultsCheckedIcon
                        Else
                            Me.ImageIndex = ImageIndexes.ResultsCheckBoxIcon
                            Me.SelectedImageIndex = ImageIndexes.ResultsCheckBoxIcon
                        End If
                    Else
                        Me.ImageIndex = ImageIndexes.WarningIcon
                        Me.SelectedImageIndex = ImageIndexes.WarningIcon
                    End If
                Else
                    Me.ImageIndex = ImageIndexes.NoResultsIcon
                    Me.SelectedImageIndex = ImageIndexes.NoResultsIcon
                End If
            End If
        End Sub

#End Region

    End Class

#End Region

#Region " Member Data "
    '
    ' Indexes into ImageList
    '
    Private Enum ImageIndexes
        FarmIcon
        FieldIcon
        DesignIcon
        EventIcon
        OperationsIcon
        SimulationIcon
        NoResultsIcon
        WarningIcon
        WarningCheckBoxIcon
        WarningCheckedIcon
        ResultsIcon
        ResultsCheckBoxIcon
        ResultsCheckedIcon
        CheckBoxIcon
        CheckedBoxIcon
    End Enum
    '
    ' Mouse click tracking
    '
    Private Enum MouseButton
        None
        Left
        Middle
        Right
    End Enum
    '
    ' References to WinSRFR objects
    '
    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' UI support data
    '
    Private mMouseButton As MouseButton = MouseButton.None
    Private mMousePoint As System.Drawing.Point

    Private mSelectedNode As TreeNode = Nothing

    Private Const Separator As String = ": "

#End Region

#Region " Properties "

    Private sTitle As String = mDictionary.tDataExplorer.Translated
    Private mSubtitle As String
    Public Property Subtitle() As String
        Get
            Return mSubtitle
        End Get
        Set(ByVal Value As String)
            If (Value Is Nothing) Then
                mSubtitle = String.Empty
            Else
                mSubtitle = Value
            End If

            If (mSubtitle = String.Empty) Then
                DataExplorerLabel.Text = sTitle
            Else
                DataExplorerLabel.Text = sTitle + " - " + mSubtitle
            End If
        End Set
    End Property

    Private mTitleBackColor As Drawing.Color = Drawing.SystemColors.Control
    Public Property TitleBackColor() As Drawing.Color
        Get
            Return mTitleBackColor
        End Get
        Set(ByVal Value As Drawing.Color)
            mTitleBackColor = Value
            DataExplorerLabel.BackColor = mTitleBackColor
        End Set
    End Property

    Private mTitleForeColor As Drawing.Color = Drawing.SystemColors.ControlText
    Public Property TitleForeColor() As Drawing.Color
        Get
            Return mTitleForeColor
        End Get
        Set(ByVal Value As Drawing.Color)
            mTitleForeColor = Value
            DataExplorerLabel.ForeColor = mTitleForeColor
        End Set
    End Property

#End Region

#Region " Initialization "

    Public Sub InitializeDataExplorer(ByVal _winSRFR As WinSRFR)
        Debug.Assert(Not (_winSRFR Is Nothing), "WinSRFR is Nothing")
        mWinSRFR = _winSRFR
    End Sub

    Public Sub ResetDataExplorer()
        AddFarms()
    End Sub

#End Region

#Region " Methods "

#Region " Farm Methods "

    Private Function GetFarmNode(ByVal _farm As Farm) As FarmTreeNode

        ' Scan the DataTreeView for the requested Farm
        For Each _farmNode As TreeNode In DataTreeView.Nodes
            If (_farmNode.Text.EndsWith(Separator + _farm.Name.Value)) Then
                Return CType(_farmNode, FarmTreeNode)
            End If
        Next

        Return Nothing

    End Function

    Private Function GetFarm(ByVal _farmNode As TreeNode) As Farm

        Dim _farm As Farm = Nothing

        If Not (_farmNode Is Nothing) Then
            ' Get the Farm object
            Dim _idx As Integer = _farmNode.Text.IndexOf(Separator) + Separator.Length
            Dim _farmName As String = _farmNode.Text.Substring(_idx)
            _farm = mWinSRFR.GetFarmByName(_farmName)
        End If

        Return _farm

    End Function

#End Region

#Region " Field Methods "

    Private Function GetFieldNode(ByVal _field As Field) As FieldTreeNode

        ' Scan the DataTreeView for the requested Field
        For Each _farmNode As TreeNode In DataTreeView.Nodes
            If (_farmNode.Text.EndsWith(Separator + _field.FarmRef.Name.Value)) Then
                For Each _fieldNode As TreeNode In _farmNode.Nodes
                    If (_fieldNode.Text.EndsWith(Separator + _field.Name.Value)) Then
                        ' Found it
                        Return CType(_fieldNode, FieldTreeNode)
                    End If
                Next
            End If
        Next

        Return Nothing

    End Function

    Private Function GetField(ByVal _fieldNode As TreeNode) As Field

        Dim _field As Field = Nothing

        If Not (_fieldNode Is Nothing) Then
            ' Get the Farm and lookup the requested Field
            Dim _farmNode As TreeNode = _fieldNode.Parent
            Dim _farm As Farm = GetFarm(_farmNode)
            If Not (_farm Is Nothing) Then
                Dim _idx As Integer = _fieldNode.Text.IndexOf(Separator) + Separator.Length
                Dim _fieldName As String = _fieldNode.Text.Substring(_idx)
                _field = _farm.GetFieldByName(_fieldName)
            End If
        End If

        Return _field

    End Function

#End Region

#Region " World Methods "

    Private Function GetWorldNode(ByVal _world As World) As WorldTreeNode

        ' Scan the DataTreeView for the requested World
        For Each _farmNode As TreeNode In DataTreeView.Nodes
            If (_farmNode.Text.EndsWith(Separator + _world.FieldRef.FarmRef.Name.Value)) Then
                For Each _fieldNode As TreeNode In _farmNode.Nodes
                    If (_fieldNode.Text.EndsWith(Separator + _world.FieldRef.Name.Value)) Then
                        For Each _worldNode As TreeNode In _fieldNode.Nodes
                            If (_worldNode.Text.EndsWith(Separator + _world.Name.Value)) Then
                                ' Name matches; does World Type?
                                Select Case (_worldNode.ImageIndex)
                                    Case ImageIndexes.DesignIcon
                                        If (_world.WorldType.Value = WorldTypes.DesignWorld) Then
                                            ' Found it
                                            Return CType(_worldNode, WorldTreeNode)
                                        End If
                                    Case ImageIndexes.EventIcon
                                        If (_world.WorldType.Value = WorldTypes.EventWorld) Then
                                            ' Found it
                                            Return CType(_worldNode, WorldTreeNode)
                                        End If
                                    Case ImageIndexes.OperationsIcon
                                        If (_world.WorldType.Value = WorldTypes.OperationsWorld) Then
                                            ' Found it
                                            Return CType(_worldNode, WorldTreeNode)
                                        End If
                                    Case ImageIndexes.SimulationIcon
                                        If (_world.WorldType.Value = WorldTypes.SimulationWorld) Then
                                            ' Found it
                                            Return CType(_worldNode, WorldTreeNode)
                                        End If
                                End Select
                            End If
                        Next
                    End If
                Next
            End If
        Next

        Return Nothing

    End Function

    Private Function GetWorld(ByVal _worldNode As TreeNode) As World

        Dim _world As World = Nothing

        If Not (_worldNode Is Nothing) Then
            ' Get the Field and lookup the requested World
            Dim _fieldNode As TreeNode = _worldNode.Parent
            Dim _field As Field = GetField(_fieldNode)
            If Not (_field Is Nothing) Then
                Dim _idx As Integer = _worldNode.Text.IndexOf(Separator) + Separator.Length
                Dim _worldName As String = _worldNode.Text.Substring(_idx)
                Dim _type As WorldTypes = Globals.WorldTypes.EventWorld
                Select Case (_worldNode.ImageIndex)
                    Case ImageIndexes.DesignIcon
                        _type = Globals.WorldTypes.DesignWorld
                    Case ImageIndexes.EventIcon
                        _type = Globals.WorldTypes.EventWorld
                    Case ImageIndexes.OperationsIcon
                        _type = Globals.WorldTypes.OperationsWorld
                    Case ImageIndexes.SimulationIcon
                        _type = Globals.WorldTypes.SimulationWorld
                End Select
                _world = _field.GetWorldByName(_type, _worldName)
            End If
        End If

        Return _world

    End Function

#End Region

#Region " Analysis Methods "

    Private Function GetAnalysisNode(ByVal _analysis As Unit) As AnalysisTreeNode

        ' Scan the DataTreeView for the requested Analysis
        For Each _farmNode As TreeNode In DataTreeView.Nodes
            ' Farm names are unique
            If (_farmNode.Text.EndsWith(Separator + _analysis.WorldRef.FieldRef.FarmRef.Name.Value)) Then
                For Each _fieldNode As TreeNode In _farmNode.Nodes
                    ' Field names are unique within a Farm
                    If (_fieldNode.Text.EndsWith(Separator + _analysis.WorldRef.FieldRef.Name.Value)) Then
                        ' World names are unique within a World within a Field
                        For Each _worldNode As TreeNode In _fieldNode.Nodes
                            If (_worldNode.Text.StartsWith(WorldsText(_analysis.WorldRef.WorldType.Value))) Then
                                If (_worldNode.Text.EndsWith(Separator + _analysis.WorldRef.Name.Value)) Then
                                    ' Analysis names are unique within a World
                                    For Each _analysisNode As TreeNode In _worldNode.Nodes
                                        If (_analysisNode.Text = _analysis.Name.Value) Then
                                            ' Found it
                                            Return CType(_analysisNode, AnalysisTreeNode)
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Next

        Return Nothing

    End Function

    Private Function GetAnalysis(ByVal _analysisNode As TreeNode) As Unit

        Dim _analysis As Unit = Nothing

        If Not (_analysisNode Is Nothing) Then
            ' Get World and lookup Analysis
            Dim _worldNode As TreeNode = _analysisNode.Parent
            Dim _world As World = GetWorld(_worldNode)
            If Not (_world Is Nothing) Then
                Dim _analysisName As String = _analysisNode.Text
                _analysis = _world.GetAnalysisByName(_analysisName)
            End If
        End If

        Return _analysis

    End Function

#End Region

#Region " UI Action Methods "
    '
    ' Display Right-Click (Context) menu for selected item
    '
    Private Sub DisplayContextMenu()

        ' Get the currently selected TreeView node
        Dim _treeNode As TreeNode = DataTreeView.SelectedNode

        If Not (_treeNode Is Nothing) Then
            ' Determine what type of object it references
            Dim _farm As Farm = GetFarm(_treeNode)
            Dim _field As Field = GetField(_treeNode)
            Dim _world As World = GetWorld(_treeNode)
            Dim _analysis As Unit = GetAnalysis(_treeNode)
        End If

    End Sub

    Public Sub SetCheckedState(ByVal _analysis As Unit)

        Dim _analysisTreeNode As AnalysisTreeNode = GetAnalysisNode(_analysis)

        If Not (_analysisTreeNode Is Nothing) Then
            _analysisTreeNode.Selected = True
            _analysisTreeNode.UpdateIcon()
        End If

    End Sub

    Private Sub SetCheckedState(ByVal _analysisTreeNode As AnalysisTreeNode)

        Dim _analysis As Unit = _analysisTreeNode.Analysis

        If Not (_analysis Is Nothing) Then
            _analysisTreeNode.Selected = True
            _analysisTreeNode.UpdateIcon()

            RaiseCheckChangedEvent(_analysis, True)
        End If

    End Sub

    Public Sub ClearCheckedState(ByVal _analysis As Unit)

        Dim _analysisTreeNode As AnalysisTreeNode = GetAnalysisNode(_analysis)

        If Not (_analysisTreeNode Is Nothing) Then
            _analysisTreeNode.Selected = False
            _analysisTreeNode.UpdateIcon()
        End If

    End Sub

    Private Sub ClearCheckedState(ByVal _analysisTreeNode As AnalysisTreeNode)

        Dim _analysis As Unit = _analysisTreeNode.Analysis

        If Not (_analysis Is Nothing) Then
            _analysisTreeNode.Selected = False
            _analysisTreeNode.UpdateIcon()

            RaiseCheckChangedEvent(_analysis, False)
        End If

    End Sub

    Public Sub ClearAllSelections()

        ' Scan the DataTreeView for all Analysis
        For Each _farmNode As TreeNode In DataTreeView.Nodes
            For Each _fieldNode As TreeNode In _farmNode.Nodes
                For Each _worldNode As TreeNode In _fieldNode.Nodes
                    For Each _analysisNode As AnalysisTreeNode In _worldNode.Nodes
                        _analysisNode.Selected = False
                        _analysisNode.UpdateIcon()
                    Next
                Next
            Next
        Next

    End Sub

    Private Sub ToggleCheckedState(ByVal _treeNode As TreeNode)

        If (_treeNode.GetType Is GetType(AnalysisTreeNode)) Then

            Dim _analysisTreeNode As AnalysisTreeNode = DirectCast(_treeNode, AnalysisTreeNode)
            Dim _analysis As Unit = _analysisTreeNode.Analysis

            If (_analysis.ResultsAreValid) Then
                If (_analysisTreeNode.Selected) Then
                    ' If Selected (i.e. Checked), clear the Checked State
                    ClearCheckedState(_analysisTreeNode)
                Else
                    ' If not Selected, set the Checked State
                    SetCheckedState(_analysisTreeNode)
                End If
            End If
        End If

    End Sub

#End Region

#Region " Farm List Methods "

    Protected Friend Sub AddFarms()

        ' First, clear the DataTree View
        DataTreeView.Nodes.Clear()

        ' Then, add the Farm data
        Dim _farm As Farm = mWinSRFR.GetFirstFarm

        While Not (_farm Is Nothing)

            Dim _farmNode As FarmTreeNode = New FarmTreeNode(mWinSRFR, _farm)

            _farmNode.ImageIndex = ImageIndexes.FarmIcon
            _farmNode.SelectedImageIndex = ImageIndexes.FarmIcon

            ' Also add the Fields below the Farm
            _farmNode.AddFields()

            DataTreeView.Nodes.Add(_farmNode)
            _farmNode.Expand()

            _farm = mWinSRFR.GetNextFarm
        End While

    End Sub

#End Region

#End Region

#Region " Events & Handlers "

#Region " Events "
    '
    ' Event generated when a checked state changes
    '
    Public Event CheckChanged(ByVal _analysis As Unit, ByVal _checked As Boolean)

    Public Sub RaiseCheckChangedEvent(ByVal _analysis As Unit, ByVal _checked As Boolean)
        RaiseEvent CheckChanged(_analysis, _checked)
    End Sub

#End Region

#Region " TreeView Events "
    '
    ' Handles KeyDown
    '
    Private Sub DataTreeView_KeyDown(ByVal sender As Object, _
                                         ByVal e As KeyEventArgs) _
    Handles DataTreeView.KeyDown

        Dim _treeNode As TreeNode = DataTreeView.SelectedNode

        If Not (_treeNode Is Nothing) Then

            ' Save Mouse Point and Selected Node
            mMousePoint = New Point(_treeNode.Bounds.X, _treeNode.Bounds.Y + _treeNode.Bounds.Height)
            mSelectedNode = _treeNode

            Select Case (e.KeyValue)
                Case Keys.Left
                    ' Collapse the TreeNode
                    mSelectedNode.Collapse()
                Case Keys.Right
                    ' Expand the TreeNode
                    mSelectedNode.Expand()
                Case Keys.Space, Keys.Return
                    ' Toggle the checked state
                    ToggleCheckedState(mSelectedNode)
                Case Else
                    Dim _key As Integer = e.KeyValue ' Statement for breakpoint
                    'Console.WriteLine("Key = " + _key.ToString)
            End Select
        End If

    End Sub
    '
    ' Control which DataTreeView nodes can collapse
    '
    Private Sub DataTreeView_BeforeCollapse(ByVal sender As Object, _
                                            ByVal e As TreeViewCancelEventArgs) _
    Handles DataTreeView.BeforeCollapse

        ' Get the currently selected TreeView node
        Dim _treeNode As TreeNode = DataTreeView.SelectedNode

        If Not (_treeNode Is Nothing) Then

            ' Determine what type of object it references
            Dim _farm As Farm = GetFarm(_treeNode)
            Dim _field As Field = GetField(_treeNode)
            Dim _world As World = GetWorld(_treeNode)
            Dim _analysis As Unit = GetAnalysis(_treeNode)

            ' Display the object's details
            If Not (_farm Is Nothing) Then
                e.Cancel = True

            ElseIf Not (_field Is Nothing) Then
                'e.Cancel = True

            ElseIf Not (_world Is Nothing) Then

            ElseIf Not (_analysis Is Nothing) Then
            End If

        End If

    End Sub
    '
    ' Use mouse down click determine which TreeView node is being selected
    '
    Private Sub DataTreeView_MouseDown(ByVal sender As Object, _
                                       ByVal e As System.Windows.Forms.MouseEventArgs) _
    Handles DataTreeView.MouseDown

        Dim _mousePoint As Point = New Point(e.X, e.Y)
        Dim _treeNode As TreeNode = DataTreeView.GetNodeAt(_mousePoint)

        If Not (_treeNode Is Nothing) Then

            ' Save Mouse Point and Selected Node
            mMousePoint = _mousePoint
            mSelectedNode = _treeNode

            ' Toggle the checked state
            ToggleCheckedState(mSelectedNode)

            ' Make this the Selected Node in the TreeView
            DataTreeView.SelectedNode = _treeNode

            ' Save which mouse button was pressed
            Select Case e.Button
                Case MouseButtons.Left
                    mMouseButton = MouseButton.Left
                Case MouseButtons.Right
                    mMouseButton = MouseButton.Right
                Case MouseButtons.Middle
                    mMouseButton = MouseButton.Middle
                Case Else
                    mMouseButton = MouseButton.None
            End Select

        End If

    End Sub

    Private Sub DataTreeView_Click(ByVal sender As Object, _
                                   ByVal e As System.EventArgs) _
    Handles DataTreeView.Click

        Select Case (mMouseButton)
            Case MouseButton.Right
                ' Display the right-click (context) menu
                DisplayContextMenu()
        End Select

    End Sub

#End Region

#End Region

End Class
