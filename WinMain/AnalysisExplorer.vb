
'**********************************************************************************************
' Analysis Explorer - User Control for managing WinSRFR's analyses & simulations.
'
Public Class AnalysisExplorer
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents AnalysisTreeView As System.Windows.Forms.TreeView
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents AnalysisExplorerLabel As DataStore.ctl_Label
    Friend WithEvents FarmContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents FieldContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents AddFieldItem As System.Windows.Forms.MenuItem
    Friend WithEvents RemoveFieldItem As System.Windows.Forms.MenuItem
    Friend WithEvents FieldMenuSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents StartNewEventItem As System.Windows.Forms.MenuItem
    Friend WithEvents StartNewDesignItem As System.Windows.Forms.MenuItem
    Friend WithEvents StartNewOperationsItem As System.Windows.Forms.MenuItem
    Friend WithEvents StartNewSimulationItem As System.Windows.Forms.MenuItem
    Friend WithEvents EventMenuSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents WorldContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents RemoveWorldItem As System.Windows.Forms.MenuItem
    Friend WithEvents WorldMenuSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents StartAnalysisItem As System.Windows.Forms.MenuItem
    Friend WithEvents StartSimulationItem As System.Windows.Forms.MenuItem
    Friend WithEvents WorldMenuSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents WorldMenuSeparator3 As System.Windows.Forms.MenuItem
    Friend WithEvents CutWorldItem As System.Windows.Forms.MenuItem
    Friend WithEvents CopyWorldItem As System.Windows.Forms.MenuItem
    Friend WithEvents PasteAnalysisItem As System.Windows.Forms.MenuItem
    Friend WithEvents PasteSimulationItem As System.Windows.Forms.MenuItem
    Friend WithEvents FieldMenuSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents CutFieldItem As System.Windows.Forms.MenuItem
    Friend WithEvents CopyFieldItem As System.Windows.Forms.MenuItem
    Friend WithEvents FieldMenuSeparator3 As System.Windows.Forms.MenuItem
    Friend WithEvents PasteWorldItem As System.Windows.Forms.MenuItem
    Friend WithEvents FarmMenuSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents CutFarmItem As System.Windows.Forms.MenuItem
    Friend WithEvents CopyFarmItem As System.Windows.Forms.MenuItem
    Friend WithEvents FarmMenuSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents PasteFieldItem As System.Windows.Forms.MenuItem
    Friend WithEvents AnalysisContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents OpenAnalysisWindowItem As System.Windows.Forms.MenuItem
    Friend WithEvents RemoveAnalysisItem As System.Windows.Forms.MenuItem
    Friend WithEvents CutAnalysisItem As System.Windows.Forms.MenuItem
    Friend WithEvents CopyAnalysisItem As System.Windows.Forms.MenuItem
    Friend WithEvents EventMenuSeparator3 As System.Windows.Forms.MenuItem
    Friend WithEvents RunAnalysisItem As System.Windows.Forms.MenuItem
    Friend WithEvents WorldMenuSeparator4 As System.Windows.Forms.MenuItem
    Friend WithEvents RunAllWorldAnalysesItem As System.Windows.Forms.MenuItem
    Friend WithEvents FieldMenuSeparator4 As System.Windows.Forms.MenuItem
    Friend WithEvents RunAllFieldAnalysesItem As System.Windows.Forms.MenuItem
    Friend WithEvents FarmMenuSeparator3 As System.Windows.Forms.MenuItem
    Friend WithEvents RunAllFarmAnalysesItem As System.Windows.Forms.MenuItem
    Friend WithEvents EventMenuSeparator2 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnalysisExplorer))
        Me.AnalysisTreeView = New System.Windows.Forms.TreeView
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.AnalysisExplorerLabel = New DataStore.ctl_Label
        Me.FarmContextMenu = New System.Windows.Forms.ContextMenu
        Me.AddFieldItem = New System.Windows.Forms.MenuItem
        Me.FarmMenuSeparator1 = New System.Windows.Forms.MenuItem
        Me.CutFarmItem = New System.Windows.Forms.MenuItem
        Me.CopyFarmItem = New System.Windows.Forms.MenuItem
        Me.FarmMenuSeparator2 = New System.Windows.Forms.MenuItem
        Me.PasteFieldItem = New System.Windows.Forms.MenuItem
        Me.FarmMenuSeparator3 = New System.Windows.Forms.MenuItem
        Me.RunAllFarmAnalysesItem = New System.Windows.Forms.MenuItem
        Me.FieldContextMenu = New System.Windows.Forms.ContextMenu
        Me.RemoveFieldItem = New System.Windows.Forms.MenuItem
        Me.FieldMenuSeparator1 = New System.Windows.Forms.MenuItem
        Me.StartNewEventItem = New System.Windows.Forms.MenuItem
        Me.StartNewDesignItem = New System.Windows.Forms.MenuItem
        Me.StartNewOperationsItem = New System.Windows.Forms.MenuItem
        Me.StartNewSimulationItem = New System.Windows.Forms.MenuItem
        Me.FieldMenuSeparator2 = New System.Windows.Forms.MenuItem
        Me.CutFieldItem = New System.Windows.Forms.MenuItem
        Me.CopyFieldItem = New System.Windows.Forms.MenuItem
        Me.FieldMenuSeparator3 = New System.Windows.Forms.MenuItem
        Me.PasteWorldItem = New System.Windows.Forms.MenuItem
        Me.FieldMenuSeparator4 = New System.Windows.Forms.MenuItem
        Me.RunAllFieldAnalysesItem = New System.Windows.Forms.MenuItem
        Me.AnalysisContextMenu = New System.Windows.Forms.ContextMenu
        Me.OpenAnalysisWindowItem = New System.Windows.Forms.MenuItem
        Me.EventMenuSeparator1 = New System.Windows.Forms.MenuItem
        Me.RemoveAnalysisItem = New System.Windows.Forms.MenuItem
        Me.EventMenuSeparator2 = New System.Windows.Forms.MenuItem
        Me.CutAnalysisItem = New System.Windows.Forms.MenuItem
        Me.CopyAnalysisItem = New System.Windows.Forms.MenuItem
        Me.EventMenuSeparator3 = New System.Windows.Forms.MenuItem
        Me.RunAnalysisItem = New System.Windows.Forms.MenuItem
        Me.WorldContextMenu = New System.Windows.Forms.ContextMenu
        Me.RemoveWorldItem = New System.Windows.Forms.MenuItem
        Me.WorldMenuSeparator1 = New System.Windows.Forms.MenuItem
        Me.StartAnalysisItem = New System.Windows.Forms.MenuItem
        Me.StartSimulationItem = New System.Windows.Forms.MenuItem
        Me.WorldMenuSeparator2 = New System.Windows.Forms.MenuItem
        Me.CutWorldItem = New System.Windows.Forms.MenuItem
        Me.CopyWorldItem = New System.Windows.Forms.MenuItem
        Me.WorldMenuSeparator3 = New System.Windows.Forms.MenuItem
        Me.PasteAnalysisItem = New System.Windows.Forms.MenuItem
        Me.PasteSimulationItem = New System.Windows.Forms.MenuItem
        Me.WorldMenuSeparator4 = New System.Windows.Forms.MenuItem
        Me.RunAllWorldAnalysesItem = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'AnalysisTreeView
        '
        Me.AnalysisTreeView.BackColor = System.Drawing.SystemColors.Control
        Me.AnalysisTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AnalysisTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnalysisTreeView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AnalysisTreeView.ImageIndex = 0
        Me.AnalysisTreeView.ImageList = Me.ImageList
        Me.AnalysisTreeView.Location = New System.Drawing.Point(0, 23)
        Me.AnalysisTreeView.Name = "AnalysisTreeView"
        Me.AnalysisTreeView.SelectedImageIndex = 0
        Me.AnalysisTreeView.Size = New System.Drawing.Size(300, 377)
        Me.AnalysisTreeView.TabIndex = 1
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
        '
        'AnalysisExplorerLabel
        '
        Me.AnalysisExplorerLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.AnalysisExplorerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnalysisExplorerLabel.Location = New System.Drawing.Point(0, 0)
        Me.AnalysisExplorerLabel.Name = "AnalysisExplorerLabel"
        Me.AnalysisExplorerLabel.Size = New System.Drawing.Size(300, 23)
        Me.AnalysisExplorerLabel.TabIndex = 0
        Me.AnalysisExplorerLabel.Text = "Analysis Explorer"
        Me.AnalysisExplorerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FarmContextMenu
        '
        Me.FarmContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.AddFieldItem, Me.FarmMenuSeparator1, Me.CutFarmItem, Me.CopyFarmItem, Me.FarmMenuSeparator2, Me.PasteFieldItem, Me.FarmMenuSeparator3, Me.RunAllFarmAnalysesItem})
        '
        'AddFieldItem
        '
        Me.AddFieldItem.Index = 0
        Me.AddFieldItem.Text = "Add Field ..."
        '
        'FarmMenuSeparator1
        '
        Me.FarmMenuSeparator1.Index = 1
        Me.FarmMenuSeparator1.Text = "-"
        '
        'CutFarmItem
        '
        Me.CutFarmItem.Index = 2
        Me.CutFarmItem.Text = "Cut"
        Me.CutFarmItem.Visible = False
        '
        'CopyFarmItem
        '
        Me.CopyFarmItem.Index = 3
        Me.CopyFarmItem.Text = "Copy"
        Me.CopyFarmItem.Visible = False
        '
        'FarmMenuSeparator2
        '
        Me.FarmMenuSeparator2.Index = 4
        Me.FarmMenuSeparator2.Text = "-"
        Me.FarmMenuSeparator2.Visible = False
        '
        'PasteFieldItem
        '
        Me.PasteFieldItem.Index = 5
        Me.PasteFieldItem.Text = "Paste Field"
        '
        'FarmMenuSeparator3
        '
        Me.FarmMenuSeparator3.Index = 6
        Me.FarmMenuSeparator3.Text = "-"
        '
        'RunAllFarmAnalysesItem
        '
        Me.RunAllFarmAnalysesItem.Index = 7
        Me.RunAllFarmAnalysesItem.Text = "Run All"
        '
        'FieldContextMenu
        '
        Me.FieldContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.RemoveFieldItem, Me.FieldMenuSeparator1, Me.StartNewEventItem, Me.StartNewDesignItem, Me.StartNewOperationsItem, Me.StartNewSimulationItem, Me.FieldMenuSeparator2, Me.CutFieldItem, Me.CopyFieldItem, Me.FieldMenuSeparator3, Me.PasteWorldItem, Me.FieldMenuSeparator4, Me.RunAllFieldAnalysesItem})
        '
        'RemoveFieldItem
        '
        Me.RemoveFieldItem.Index = 0
        Me.RemoveFieldItem.Text = "Remove ..."
        '
        'FieldMenuSeparator1
        '
        Me.FieldMenuSeparator1.Index = 1
        Me.FieldMenuSeparator1.Text = "-"
        '
        'StartNewEventItem
        '
        Me.StartNewEventItem.Index = 2
        Me.StartNewEventItem.Text = "Add new Event Folder ..."
        '
        'StartNewDesignItem
        '
        Me.StartNewDesignItem.Index = 3
        Me.StartNewDesignItem.Text = "Add new Design Folder ..."
        '
        'StartNewOperationsItem
        '
        Me.StartNewOperationsItem.Index = 4
        Me.StartNewOperationsItem.Text = "Add new Operations Folder ..."
        '
        'StartNewSimulationItem
        '
        Me.StartNewSimulationItem.Index = 5
        Me.StartNewSimulationItem.Text = "Add new Simulation Folder ..."
        '
        'FieldMenuSeparator2
        '
        Me.FieldMenuSeparator2.Index = 6
        Me.FieldMenuSeparator2.Text = "-"
        '
        'CutFieldItem
        '
        Me.CutFieldItem.Index = 7
        Me.CutFieldItem.Text = "Cut"
        '
        'CopyFieldItem
        '
        Me.CopyFieldItem.Index = 8
        Me.CopyFieldItem.Text = "Copy"
        '
        'FieldMenuSeparator3
        '
        Me.FieldMenuSeparator3.Index = 9
        Me.FieldMenuSeparator3.Text = "-"
        '
        'PasteWorldItem
        '
        Me.PasteWorldItem.Index = 10
        Me.PasteWorldItem.Text = "Paste World Folder"
        '
        'FieldMenuSeparator4
        '
        Me.FieldMenuSeparator4.Index = 11
        Me.FieldMenuSeparator4.Text = "-"
        '
        'RunAllFieldAnalysesItem
        '
        Me.RunAllFieldAnalysesItem.Index = 12
        Me.RunAllFieldAnalysesItem.Text = "Run All"
        '
        'AnalysisContextMenu
        '
        Me.AnalysisContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.OpenAnalysisWindowItem, Me.EventMenuSeparator1, Me.RemoveAnalysisItem, Me.EventMenuSeparator2, Me.CutAnalysisItem, Me.CopyAnalysisItem, Me.EventMenuSeparator3, Me.RunAnalysisItem})
        '
        'OpenAnalysisWindowItem
        '
        Me.OpenAnalysisWindowItem.Index = 0
        Me.OpenAnalysisWindowItem.Text = "Open Window"
        '
        'EventMenuSeparator1
        '
        Me.EventMenuSeparator1.Index = 1
        Me.EventMenuSeparator1.Text = "-"
        '
        'RemoveAnalysisItem
        '
        Me.RemoveAnalysisItem.Index = 2
        Me.RemoveAnalysisItem.Text = "Remove ..."
        '
        'EventMenuSeparator2
        '
        Me.EventMenuSeparator2.Index = 3
        Me.EventMenuSeparator2.Text = "-"
        '
        'CutAnalysisItem
        '
        Me.CutAnalysisItem.Index = 4
        Me.CutAnalysisItem.Text = "Cut"
        '
        'CopyAnalysisItem
        '
        Me.CopyAnalysisItem.Index = 5
        Me.CopyAnalysisItem.Text = "Copy"
        '
        'EventMenuSeparator3
        '
        Me.EventMenuSeparator3.Index = 6
        Me.EventMenuSeparator3.Text = "-"
        '
        'RunAnalysisItem
        '
        Me.RunAnalysisItem.Index = 7
        Me.RunAnalysisItem.Text = "Run"
        '
        'WorldContextMenu
        '
        Me.WorldContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.RemoveWorldItem, Me.WorldMenuSeparator1, Me.StartAnalysisItem, Me.StartSimulationItem, Me.WorldMenuSeparator2, Me.CutWorldItem, Me.CopyWorldItem, Me.WorldMenuSeparator3, Me.PasteAnalysisItem, Me.PasteSimulationItem, Me.WorldMenuSeparator4, Me.RunAllWorldAnalysesItem})
        '
        'RemoveWorldItem
        '
        Me.RemoveWorldItem.Index = 0
        Me.RemoveWorldItem.Text = "Remove ..."
        '
        'WorldMenuSeparator1
        '
        Me.WorldMenuSeparator1.Index = 1
        Me.WorldMenuSeparator1.Text = "-"
        '
        'StartAnalysisItem
        '
        Me.StartAnalysisItem.Index = 2
        Me.StartAnalysisItem.Text = "Start new Analysis ..."
        '
        'StartSimulationItem
        '
        Me.StartSimulationItem.Index = 3
        Me.StartSimulationItem.Text = "Start new Simulation ..."
        '
        'WorldMenuSeparator2
        '
        Me.WorldMenuSeparator2.Index = 4
        Me.WorldMenuSeparator2.Text = "-"
        '
        'CutWorldItem
        '
        Me.CutWorldItem.Index = 5
        Me.CutWorldItem.Text = "Cut"
        '
        'CopyWorldItem
        '
        Me.CopyWorldItem.Index = 6
        Me.CopyWorldItem.Text = "Copy"
        '
        'WorldMenuSeparator3
        '
        Me.WorldMenuSeparator3.Index = 7
        Me.WorldMenuSeparator3.Text = "-"
        '
        'PasteAnalysisItem
        '
        Me.PasteAnalysisItem.Index = 8
        Me.PasteAnalysisItem.Text = "Paste Analysis"
        '
        'PasteSimulationItem
        '
        Me.PasteSimulationItem.Index = 9
        Me.PasteSimulationItem.Text = "Paste Simulation"
        '
        'WorldMenuSeparator4
        '
        Me.WorldMenuSeparator4.Index = 10
        Me.WorldMenuSeparator4.Text = "-"
        '
        'RunAllWorldAnalysesItem
        '
        Me.RunAllWorldAnalysesItem.Index = 11
        Me.RunAllWorldAnalysesItem.Text = "Run All"
        '
        'AnalysisExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AnalysisTreeView)
        Me.Controls.Add(Me.AnalysisExplorerLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "AnalysisExplorer"
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
        Public Property Farm() As Farm
            Get
                Return mFarm
            End Get
            Set(ByVal Value As Farm)
                mFarm = Value
            End Set
        End Property

        Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Constructor "

        Public Sub New(ByVal _winSRFR As WinSRFR, ByVal _farm As Farm)
            MyBase.New(_winSRFR.ProjectFarmText + Separator + _farm.Name.Value)
            mWinSRFR = _winSRFR
            mFarm = _farm
        End Sub

#End Region

#Region " Methods "

        Protected Friend Sub AddFieldHelpNode()

            ' Create & add a simple TreeNode containing the help text
            Dim _node As TreeNode

            Me.Nodes.Clear()

            _node = New TreeNode(mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToAdd.Translated & " " _
                                & mWinSRFR.CaseFieldText & " " & mDictionary.tToThe.Translated & " " _
                                & mWinSRFR.ProjectFarmText)

            _node.Tag = sDoubleClick
            _node.ImageIndex = ImageIndexes.FieldIcon
            _node.SelectedImageIndex = ImageIndexes.FieldIcon

            Me.Nodes.Add(_node)
            Me.Expand()

        End Sub

        Protected Friend Sub RemoveDeletedFields()
RemoveDeletedField:
            ' Check if all Fields in the TreeView are also in the Farm's Field List
            For Each _node As TreeNode In Me.Nodes
                If (_node.GetType Is GetType(FieldTreeNode)) Then
                    Dim _fieldNode As FieldTreeNode = DirectCast(_node, FieldTreeNode)
                    ' Check if this Field is in the Farm's Field List
                    Dim _fieldID As String = _fieldNode.Field.MyID
                    Dim _field As Field = mFarm.GetFieldByID(_fieldID)
                    ' If it isn't; remove it here
                    If (_field Is Nothing) Then
                        Me.Nodes.Remove(_fieldNode)
                        ' Remove() invalidates loop; start it over
                        GoTo RemoveDeletedField
                    Else
                        ' If if it still in the list, reset the model object
                        _fieldNode.Field = _field
                    End If
                Else
                    Me.Nodes.Remove(_node)
                    ' Remove() invalidates loop; start it over
                    GoTo RemoveDeletedField
                End If
            Next
        End Sub

        Protected Friend Sub AddNewFields()
            ' Check if all Fields in the Farm's Field List are also in the TreeView
            Dim _field As Field = mFarm.GetFirstField
            Dim _idx As Integer = 0

            While Not (_field Is Nothing)
                If (_idx < Me.Nodes.Count) Then
                    If Not (Me.Nodes.Item(_idx).Text.EndsWith(_field.Name.Value)) Then
                        ' Field is not in TreeView; create and insert a new node for it
                        Dim _fieldNode As FieldTreeNode = New FieldTreeNode(mWinSRFR, _field)

                        _fieldNode.ImageIndex = ImageIndexes.FieldIcon
                        _fieldNode.SelectedImageIndex = ImageIndexes.FieldIcon

                        Me.Nodes.Insert(_idx, _fieldNode)

                        ' Also add the Worlds below the Field
                        _fieldNode.AddNewWorlds()
                        _fieldNode.Expand()
                    End If
                Else
                    ' Field is not in TreeView; create and add a new node for it
                    Dim _fieldNode As FieldTreeNode = New FieldTreeNode(mWinSRFR, _field)

                    _fieldNode.ImageIndex = ImageIndexes.FieldIcon
                    _fieldNode.SelectedImageIndex = ImageIndexes.FieldIcon

                    Me.Nodes.Add(_fieldNode)

                    ' Also add the Worlds below the Field
                    _fieldNode.AddNewWorlds()
                    _fieldNode.Expand()

                End If
                _field = mFarm.GetNextField
                _idx += 1
            End While

            ' If no Fields, add "Double-Click..." help
            If (0 = Me.Nodes.Count) Then
                Me.AddFieldHelpNode()
            End If
        End Sub

#End Region

#Region " Model Event Handlers "

        Private Sub Farm_Updated(ByVal _reason As Farm.Reasons) _
        Handles mFarm.FarmUpdated
            Select Case _reason
                Case Farm.Reasons.Name
                    Me.Text = mWinSRFR.ProjectFarmText + Separator + mFarm.Name.Value
                Case Farm.Reasons.FieldList
                    RemoveDeletedFields()
                    AddNewFields()
            End Select
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
        Public Property Field() As Field
            Get
                Return mField
            End Get
            Set(ByVal Value As Field)
                mField = Value
            End Set
        End Property

        Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Constructors "

        Public Sub New(ByVal _winSRFR As WinSRFR, ByVal _field As Field)
            MyBase.New(_winSRFR.CaseFieldText + Separator + _field.Name.Value)
            mWinSRFR = _winSRFR
            mField = _field
        End Sub

#End Region

#Region " Methods "

        Protected Friend Sub AddWorldHelpNodes()

            ' Create & add a simple TreeNode containing the help text
            Dim _node As TreeNode

            Me.Nodes.Clear()

            ' Event
            _node = New TreeNode(mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToStart.Translated & " " & mDictionary.tEventAnalysis.Translated)
            _node.Tag = sDoubleClick
            _node.ImageIndex = ImageIndexes.EventIcon
            _node.SelectedImageIndex = ImageIndexes.EventIcon

            Me.Nodes.Add(_node)

            ' Design
            _node = New TreeNode(mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToStart.Translated & " " & mDictionary.tDesignAnalysis.Translated)
            _node.Tag = sDoubleClick
            _node.ImageIndex = ImageIndexes.DesignIcon
            _node.SelectedImageIndex = ImageIndexes.DesignIcon

            Me.Nodes.Add(_node)

            ' Operations
            _node = New TreeNode(mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToStart.Translated & " " & mDictionary.tOperationsAnalysis.Translated)
            _node.Tag = sDoubleClick
            _node.ImageIndex = ImageIndexes.OperationsIcon
            _node.SelectedImageIndex = ImageIndexes.OperationsIcon

            Me.Nodes.Add(_node)

            ' Simulation
            _node = New TreeNode(mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToStart.Translated & " " & mDictionary.tSimulation.Translated)
            _node.Tag = sDoubleClick
            _node.ImageIndex = ImageIndexes.SimulationIcon
            _node.SelectedImageIndex = ImageIndexes.SimulationIcon

            Me.Nodes.Add(_node)
            Me.Expand()

        End Sub

        Protected Friend Sub RemoveDeletedWorlds()
RemoveDeletedWorld:
            ' Check if all Worlds in the TreeView are also in the Field's World List
            For Each _node As TreeNode In Me.Nodes
                If (_node.GetType Is GetType(WorldTreeNode)) Then
                    Dim _worldNode As WorldTreeNode = DirectCast(_node, WorldTreeNode)
                    ' Check if this World is in the Field's World List
                    Dim _worldID As String = _worldNode.World.MyID
                    Dim _world As World = mField.GetWorldByID(_worldID)
                    ' If it isn't; remove it here
                    If (_world Is Nothing) Then
                        Me.Nodes.Remove(_worldNode)
                        ' Remove() invalidates loop; start it over
                        GoTo RemoveDeletedWorld
                    Else
                        ' If if it still in the list, reset the model object
                        _worldNode.World = _world
                    End If
                Else
                    Me.Nodes.Remove(_node)
                    ' Remove() invalidates loop; start it over
                    GoTo RemoveDeletedWorld
                End If
            Next
        End Sub

        Protected Friend Sub AddNewWorlds()
            ' Check if all Worlds in the Field's World List are also in the TreeView
            Dim _world As World = mField.GetFirstWorld
            Dim _idx As Integer = 0

            While Not (_world Is Nothing)
                If (_idx < Me.Nodes.Count) Then
                    If Not (Me.Nodes.Item(_idx).Text.EndsWith(_world.Name.Value)) Then
                        ' World is not in TreeView; create and insert a new node for it
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

                        Me.Nodes.Insert(_idx, _worldNode)

                        ' Also add the Analyses below the World
                        _worldNode.AddNewAnalyses()
                        _worldNode.Expand()
                    End If
                Else
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

                    Me.Nodes.Add(_worldNode)

                    ' Also add the Analyses below the World
                    _worldNode.AddNewAnalyses()
                    _worldNode.Expand()

                End If
                _world = mField.GetNextWorld
                _idx += 1
            End While

            ' If no Worlds, add "Double-Click..." help
            If (0 = Me.Nodes.Count) Then
                Me.AddWorldHelpNodes()
            End If
        End Sub

#End Region

#Region " Model Event Handlers "

        Private Sub Field_Updated(ByVal _reason As Field.Reasons) _
        Handles mField.FieldUpdated
            Select Case _reason
                Case Field.Reasons.Name
                    Me.Text = mWinSRFR.CaseFieldText + Separator + mField.Name.Value
                Case Field.Reasons.WorldList
                    RemoveDeletedWorlds()
                    AddNewWorlds()
            End Select
        End Sub

#End Region

    End Class

#End Region

#Region " Class WorldTreeNode "

    Private Class WorldTreeNode
        Inherits System.Windows.Forms.TreeNode

#Region " Member Data "

        Private WithEvents mWorld As World = Nothing
        Public Property World() As World
            Get
                Return mWorld
            End Get
            Set(ByVal Value As World)
                mWorld = Value
            End Set
        End Property

        Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Constructors "

        Public Sub New(ByVal _world As World)
            MyBase.New(Dictionary.Instance.Translate(WorldsText(_world.WorldType.Value)) + Separator + _world.Name.Value)
            mWorld = _world
        End Sub

#End Region

#Region " Methods "

        Protected Friend Sub AddAnalysisHelpNode(ByVal _type As WorldTypes)

            ' Create & add a simple TreeNode containing the help text
            Dim _node As TreeNode = Nothing

            Me.Nodes.Clear()

            Select Case (_type)

                Case WorldTypes.DesignWorld
                    _node = New TreeNode(mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToStart.Translated & " " & mDictionary.tDesignAnalysis.Translated)
                    _node.Tag = sDoubleClick
                    _node.ImageIndex = ImageIndexes.DesignIcon
                    _node.SelectedImageIndex = ImageIndexes.DesignIcon

                Case WorldTypes.EventWorld
                    _node = New TreeNode(mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToStart.Translated & " " & mDictionary.tEventAnalysis.Translated)
                    _node.Tag = sDoubleClick
                    _node.ImageIndex = ImageIndexes.EventIcon
                    _node.SelectedImageIndex = ImageIndexes.EventIcon

                Case WorldTypes.OperationsWorld
                    _node = New TreeNode(mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToStart.Translated & " " & mDictionary.tOperationsAnalysis.Translated)
                    _node.Tag = sDoubleClick
                    _node.ImageIndex = ImageIndexes.OperationsIcon
                    _node.SelectedImageIndex = ImageIndexes.OperationsIcon

                Case WorldTypes.SimulationWorld
                    _node = New TreeNode(mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToStart.Translated & " " & mDictionary.tSimulation.Translated)
                    _node.Tag = sDoubleClick
                    _node.ImageIndex = ImageIndexes.SimulationIcon
                    _node.SelectedImageIndex = ImageIndexes.SimulationIcon

            End Select

            Me.Nodes.Add(_node)
            Me.Expand()

        End Sub

        Protected Friend Sub RemoveDeletedAnalyses()
RemoveDeletedAnalysis:
            ' Check if all Analyses in the TreeView are also in the World's Analysis List
            For Each _node As TreeNode In Me.Nodes
                If (_node.GetType Is GetType(AnalysisTreeNode)) Then
                    Dim _analysisNode As AnalysisTreeNode = DirectCast(_node, AnalysisTreeNode)
                    ' Check if this Analysis is in the World's Analysis List
                    Dim _unitID As String = _analysisNode.Unit.MyID
                    Dim _unit As Unit = mWorld.GetAnalysisByID(_unitID)
                    ' If it isn't; remove it here
                    If (_unit Is Nothing) Then
                        Me.Nodes.Remove(_analysisNode)
                        ' Remove() invalidates loop; start it over
                        GoTo RemoveDeletedAnalysis
                    Else
                        ' If if it still in the list, reset the model object
                        _analysisNode.Unit = _unit
                    End If
                Else
                    Me.Nodes.Remove(_node)
                    ' Remove() invalidates loop; start it over
                    GoTo RemoveDeletedAnalysis
                End If
            Next
        End Sub

        Protected Friend Sub AddNewAnalyses()
            ' Check if all Analyses in the World's Analysis List are also in the TreeView
            Dim _analysis As Unit = mWorld.GetFirstAnalysis
            Dim _idx As Integer = 0
            While Not (_analysis Is Nothing)
                If (_idx < Me.Nodes.Count) Then
                    If Not (Me.Nodes.Item(_idx).Text.EndsWith(_analysis.Name.Value)) Then
                        ' Analysis is not in TreeView; create and insert a new node for it
                        Dim _analysisNode As AnalysisTreeNode = New AnalysisTreeNode(_analysis)

                        Me.Nodes.Insert(_idx, _analysisNode)
                    End If
                Else
                    ' Analysis is not in TreeView; create and add a new node for it
                    Dim _analysisNode As AnalysisTreeNode = New AnalysisTreeNode(_analysis)

                    Me.Nodes.Add(_analysisNode)
                End If
                _analysis = mWorld.GetNextAnalysis
                _idx += 1
            End While

            ' If no Analyses, add "Double-Click..." help
            If (0 = Me.Nodes.Count) Then
                Dim _worldType As WorldTypes = CType(mWorld.WorldType.Value, WorldTypes)
                Me.AddAnalysisHelpNode(_worldType)
            End If
        End Sub

#End Region

#Region " Model Event Handlers "

        Private Sub World_Updated(ByVal _reason As World.Reasons) _
        Handles mWorld.WorldUpdated
            Select Case _reason
                Case World.Reasons.Name
                    Me.Text = WorldsText(mWorld.WorldType.Value) + Separator + mWorld.Name.Value
                Case World.Reasons.AnalysisList
                    RemoveDeletedAnalyses()
                    AddNewAnalyses()
            End Select
        End Sub

#End Region

    End Class

#End Region

#Region " Class AnalysisTreeNode "

    Private Class AnalysisTreeNode
        Inherits System.Windows.Forms.TreeNode

#Region " Member Data "

        Private WithEvents mUnit As Unit = Nothing
        Public Property Unit() As Unit
            Get
                Return mUnit
            End Get
            Set(ByVal Value As Unit)
                mUnit = Value
            End Set
        End Property

        Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Constructors "

        Public Sub New(ByVal _analysis As Unit)
            MyBase.New(_analysis.Name.Value)
            mUnit = _analysis
            UpdateIcons()
        End Sub

#End Region

#Region " Methods "

        Private Sub UpdateIcons()

            If Not (mUnit Is Nothing) Then

                If (mUnit.ResultsAreValid) Then
                    If (0 = mUnit.PerformanceResultsRef.ErrorCount.Value) Then
                        Me.ImageIndex = ImageIndexes.ResultsIcon
                        Me.SelectedImageIndex = ImageIndexes.ResultsIcon
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

        Public Sub RefreshView()
            UpdateIcons()
        End Sub

#End Region

#Region " Model Event Handlers "

        Private Sub Analysis_Updated(ByVal _reason As Unit.Reasons) _
        Handles mUnit.UnitUpdated
            Select Case _reason
                Case Unit.Reasons.Name
                    Me.Text = mUnit.Name.Value
                Case Unit.Reasons.Results
                    UpdateIcons()
            End Select
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
        ResultsIcon
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
    Private mAnalysisDetails As AnalysisDetails = Nothing
    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' UI support data
    '
    Private mMouseButton As MouseButton = MouseButton.None
    Private mMousePoint As System.Drawing.Point

    Private mSelectedNode As TreeNode = Nothing

    Private Const Separator As String = ": "
    Private Const sDoubleClick As String = "Double-Click"

#End Region

#Region " Initialization "

    Public Sub Initialize(ByVal _winSRFR As WinSRFR, ByVal _analysisDetails As AnalysisDetails)

        ' Save the input arguments
        If Not (_winSRFR Is Nothing) Then
            mWinSRFR = _winSRFR

            If Not (_analysisDetails Is Nothing) Then
                mAnalysisDetails = _analysisDetails

                ' There is no Project/Farm yet; add "Double-Click ..." help
                AddFarmHelpNode()

            Else
                Debug.Assert(False) ' AnalysisDetails is Nothing
            End If
        Else
            Debug.Assert(False) ' WinSRFR is Nothing
        End If

    End Sub

#End Region

#Region " Methods "

#Region " Farm Methods "

    Public Sub AddFarm(ByVal _farm As Farm)

        If Not (_farm Is Nothing) Then

            ' Add the Farm to the TreeView
            Dim _farmNode As FarmTreeNode = New FarmTreeNode(mWinSRFR, _farm)
            If Not (_farmNode Is Nothing) Then

                _farmNode.ImageIndex = ImageIndexes.FarmIcon
                _farmNode.SelectedImageIndex = ImageIndexes.FarmIcon

                ' Clear all "Double-Click" entries
                If (0 < AnalysisTreeView.Nodes.Count) Then
                    If (AnalysisTreeView.Nodes.Item(0).Tag Is sDoubleClick) Then
                        AnalysisTreeView.Nodes.Clear()
                    End If
                End If

                ' Add the new Farm Node
                AnalysisTreeView.Nodes.Add(_farmNode)
                AnalysisTreeView.ExpandAll()

                ' Make it the Selected Node
                AnalysisTreeView.SelectedNode = _farmNode

                ' Also add any contained Fields
                Dim _field As Field = _farm.GetFirstField

                If Not (_field Is Nothing) Then
                    ' Add the contained Fields
                    While Not (_field Is Nothing)
                        AddField(_field)
                        _field = _farm.GetNextField
                    End While
                Else
                    ' There is no Case/Field; add "Click to create Case/Field"
                    _farmNode.AddFieldHelpNode()
                End If
            Else
                Debug.Assert(False, "Farm Node was not created")
            End If

        End If

    End Sub

    Public Sub RemoveFarm(ByVal _farm As Farm)

        If Not (_farm Is Nothing) Then
            ' Remove the Farm's corresponding Farm Node
            Dim _farmNode As FarmTreeNode = GetFarmNode(_farm)
            If Not (_farmNode Is Nothing) Then

                AnalysisTreeView.Nodes.Remove(_farmNode)

                ' If no Farm Nodes remain, display the "Double-Click to ..." help
                If (0 = AnalysisTreeView.Nodes.Count) Then
                    AddFarmHelpNode()
                End If
            End If
        End If

    End Sub

    Public Sub SelectFarm(ByVal _farm As Farm)

        If Not (_farm Is Nothing) Then
            ' Scan the AnalysisTreeView for the requested Farm
            For Each _farmNode As TreeNode In AnalysisTreeView.Nodes
                If (_farmNode.Text.EndsWith(Separator + _farm.Name.Value)) Then
                    AnalysisTreeView.SelectedNode = _farmNode
                End If
            Next
        End If

    End Sub

    Private Function GetFarmNode(ByVal _farm As Farm) As FarmTreeNode

        ' Scan the AnalysisTreeView for the requested Farm
        For Each _farmNode As TreeNode In AnalysisTreeView.Nodes
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

    Public Sub AddField(ByVal _field As Field)

        If Not (_field Is Nothing) Then

            ' Get the Farm Node for this Field
            Dim _farmNode As FarmTreeNode = GetFarmNode(_field.FarmRef)
            If Not (_farmNode Is Nothing) Then

                ' Add the Field to the Farm Node
                Dim _fieldNode As FieldTreeNode = New FieldTreeNode(mWinSRFR, _field)
                If Not (_fieldNode Is Nothing) Then

                    _fieldNode.ImageIndex = ImageIndexes.FieldIcon
                    _fieldNode.SelectedImageIndex = ImageIndexes.FieldIcon

                    ' Clear all "Double-Click" entries
                    If (0 < _farmNode.Nodes.Count) Then
                        If (_farmNode.Nodes.Item(0).Tag Is sDoubleClick) Then
                            _farmNode.Nodes.Clear()
                        End If
                    End If

                    ' Add the new Field Node
                    _farmNode.Nodes.Add(_fieldNode)
                    _farmNode.ExpandAll()

                    ' Make it the Selected Node
                    AnalysisTreeView.SelectedNode = _fieldNode

                    ' Also add any contained Worlds
                    Dim _world As World = _field.GetFirstWorld

                    If Not (_world Is Nothing) Then
                        ' Add the contained Worlds
                        While Not (_world Is Nothing)
                            AddWorld(_world)
                            _world = _field.GetNextWorld
                        End While
                    Else
                        ' There are no Worlds; add "Double-Click here to add World"
                        _fieldNode.AddWorldHelpNodes()
                    End If
                Else
                    Debug.Assert(False, "Field Node was not created")
                End If
            Else
                Debug.Assert(False, "Farm Node not found")
            End If
        Else
            Debug.Assert(False, "Field is Nothing")
        End If

    End Sub

    Public Sub RemoveField(ByVal _field As Field)

        If Not (_field Is Nothing) Then

            ' Get the Farm Node for this Field
            Dim _farmNode As FarmTreeNode = GetFarmNode(_field.FarmRef)
            If Not (_farmNode Is Nothing) Then

                ' Remove the Field Node from the Farm Node
                Dim _fieldNode As FieldTreeNode = GetFieldNode(_field)
                If Not (_fieldNode Is Nothing) Then

                    _farmNode.Nodes.Remove(_fieldNode)

                    ' If not Fields remain, display the "Double-Click ..." help
                    If (0 = _farmNode.Nodes.Count) Then
                        _farmNode.AddFieldHelpNode()
                    End If
                End If
            Else
                Debug.Assert(False, "Farm Node not found")
            End If
        End If

    End Sub

    Public Sub SelectField(ByVal _field As Field)

        If Not (_field Is Nothing) Then

            ' Scan the AnalysisTreeView for the requested Field's Farm
            For Each _farmNode As TreeNode In AnalysisTreeView.Nodes
                If (_farmNode.Text.EndsWith(Separator + _field.FarmRef.Name.Value)) Then

                    ' Scan the Farm Noe for the requested Field
                    For Each _fieldNode As TreeNode In _farmNode.Nodes
                        If (_fieldNode.Text.EndsWith(Separator + _field.Name.Value)) Then
                            AnalysisTreeView.SelectedNode = _fieldNode
                        End If
                    Next

                End If
            Next
        End If

    End Sub

    Private Function GetFieldNode(ByVal _field As Field) As FieldTreeNode

        ' Scan the AnalysisTreeView for the requested Field
        For Each _farmNode As TreeNode In AnalysisTreeView.Nodes
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

    Public Sub AddWorld(ByVal _world As World)

        If (_world IsNot Nothing) Then

            ' Get the Field Node for this World
            Dim _fieldNode As FieldTreeNode = GetFieldNode(_world.FieldRef)
            If (_fieldNode IsNot Nothing) Then

                ' Add the World to the Field Node
                Dim _worldNode As WorldTreeNode = New WorldTreeNode(_world)
                If (_worldNode IsNot Nothing) Then

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
                            Debug.Assert(False) ' Invalid World Type
                    End Select

                    ' Clear all "Double-Click" entries
                    If (0 < _fieldNode.Nodes.Count) Then
                        If (_fieldNode.Nodes.Item(0).Tag Is sDoubleClick) Then
                            _fieldNode.Nodes.Clear()
                        End If
                    End If

                    ' Add the new World Node
                    _fieldNode.Nodes.Add(_worldNode)
                    _fieldNode.ExpandAll()

                    ' Make it the Selected Node
                    AnalysisTreeView.SelectedNode = _worldNode

                    ' Also add any contained Analyses
                    Dim _analysis As Unit = _world.GetFirstAnalysis

                    If Not (_analysis Is Nothing) Then
                        ' Add the contained Analyses
                        While Not (_analysis Is Nothing)
                            AddAnalysis(_analysis)
                            _analysis = _world.GetNextAnalysis
                        End While
                    Else
                        ' There no Analyses; add "Double-Click here to start an Analysis"
                        Dim _worldType As WorldTypes = CType(_world.WorldType.Value, WorldTypes)
                        _worldNode.AddAnalysisHelpNode(_worldType)
                    End If
                End If
            End If
        End If

    End Sub

    Public Sub RemoveWorld(ByVal _world As World)

        If Not (_world Is Nothing) Then

            ' Get the Field Node for this World
            Dim _fieldNode As FieldTreeNode = GetFieldNode(_world.FieldRef)
            If Not (_fieldNode Is Nothing) Then

                ' Remove the World Node from the Field Node
                Dim _worldNode As WorldTreeNode = GetWorldNode(_world)
                If Not (_worldNode Is Nothing) Then

                    _fieldNode.Nodes.Remove(_worldNode)

                    ' If no Worlds remain, display the "Double-Click ..." help
                    If (0 = _fieldNode.Nodes.Count) Then
                        _fieldNode.AddWorldHelpNodes()
                    End If
                End If
            Else
                Debug.Assert(False, "Field Node not found")
            End If
        End If

    End Sub

    Private Function GetWorldNode(ByVal _world As World) As WorldTreeNode

        ' Scan the AnalysisTreeView for the requested World
        For Each _farmNode As TreeNode In AnalysisTreeView.Nodes
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

    Public Sub AddAnalysis(ByVal _analysis As Unit)

        If Not (_analysis Is Nothing) Then

            ' Get the World Node for this Analysis
            Dim _worldNode As WorldTreeNode = GetWorldNode(_analysis.WorldRef)
            If Not (_worldNode Is Nothing) Then

                ' Add the Analysis to the World Node
                Dim _analysisNode As AnalysisTreeNode = New AnalysisTreeNode(_analysis)
                If Not (_analysisNode Is Nothing) Then

                    ' Clear all "Double-Click" entries
                    If (0 < _worldNode.Nodes.Count) Then
                        If (_worldNode.Nodes.Item(0).Tag Is sDoubleClick) Then
                            _worldNode.Nodes.Clear()
                        End If
                    End If

                    ' Add the new Analysis Node
                    _worldNode.Nodes.Add(_analysisNode)
                    _worldNode.ExpandAll()

                    ' Make it the Selected Node
                    AnalysisTreeView.SelectedNode = _analysisNode

                Else
                    Debug.Assert(False) ' Analysis Node not created
                End If
            Else
                Debug.Assert(False) ' World Node not found
            End If
        Else
            Debug.Assert(False) ' Analysis is Nothing
        End If

    End Sub

    Public Sub RemoveAnalysis(ByVal _analysis As Unit)

        If Not (_analysis Is Nothing) Then

            ' Get the World Node for this Analysis
            Dim _worldNode As WorldTreeNode = GetWorldNode(_analysis.WorldRef)
            If Not (_worldNode Is Nothing) Then

                ' Remove the Analysis Node from the World Node
                Dim _analysisNode As AnalysisTreeNode = GetAnalysisNode(_analysis)
                If Not (_analysisNode Is Nothing) Then

                    _worldNode.Nodes.Remove(_analysisNode)

                    ' If no Analyses remain, display the "Double-Click ..." help
                    If (0 = _worldNode.Nodes.Count) Then
                        Dim _worldType As WorldTypes = CType(_analysis.UnitType.Value, WorldTypes)
                        _worldNode.AddAnalysisHelpNode(_worldType)
                    End If
                End If
            Else
                Debug.Assert(False, "World Node not found")
            End If
        End If

    End Sub

    Private Function GetAnalysisNode(ByVal _analysis As Unit) As AnalysisTreeNode

        ' Scan the AnalysisTreeView for the requested Analysis
        For Each _farmNode As TreeNode In AnalysisTreeView.Nodes
            If (_farmNode.Text.EndsWith(Separator + _analysis.WorldRef.FieldRef.FarmRef.Name.Value)) Then
                For Each _fieldNode As TreeNode In _farmNode.Nodes
                    If (_fieldNode.Text.EndsWith(Separator + _analysis.WorldRef.FieldRef.Name.Value)) Then
                        For Each _worldNode As TreeNode In _fieldNode.Nodes
                            If (_worldNode.Text.EndsWith(Separator + _analysis.WorldRef.Name.Value)) Then
                                For Each _analysisNode As TreeNode In _worldNode.Nodes
                                    If (_analysisNode.Text = _analysis.Name.Value) Then
                                        ' Found it
                                        Return CType(_analysisNode, AnalysisTreeNode)
                                    End If
                                Next
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

    Private Sub RefreshAnalyses()

        ' Scan the AnalysisTreeView refreshing all Analyses
        For Each farmNode As TreeNode In AnalysisTreeView.Nodes
            For Each fieldNode As TreeNode In farmNode.Nodes
                For Each worldNode As TreeNode In fieldNode.Nodes
                    For Each node As TreeNode In worldNode.Nodes
                        If (node.GetType Is GetType(AnalysisTreeNode)) Then
                            Dim analysisNode As AnalysisTreeNode = DirectCast(node, AnalysisTreeNode)
                            analysisNode.RefreshView()
                        End If
                    Next
                Next
            Next
        Next

    End Sub

#End Region

#Region " UI Action Methods "
    '
    ' Remove the object references by the Selected Node
    '
    Private Sub RemoveNode()

        If Not (mSelectedNode Is Nothing) Then

            ' Determine what type of object it references
            Dim _farm As Farm = GetFarm(mSelectedNode)
            Dim _field As Field = GetField(mSelectedNode)
            Dim _world As World = GetWorld(mSelectedNode)
            Dim _analysis As Unit = GetAnalysis(mSelectedNode)

            ' Remove the object
            If Not (_farm Is Nothing) Then
                mWinSRFR.RemoveFarm(_farm)

            ElseIf Not (_field Is Nothing) Then
                mWinSRFR.RemoveField(_field)

            ElseIf Not (_world Is Nothing) Then
                mWinSRFR.RemoveWorld(_world)

            ElseIf Not (_analysis Is Nothing) Then
                mWinSRFR.RemoveAnalysis(_analysis)
            End If

        End If

    End Sub
    '
    ' Display Right-Click (Context) menu for selected item
    '
    Private Sub DisplayContextMenu()

        If Not (mSelectedNode Is Nothing) Then

            ' Determine what type of object it references
            Dim _farm As Farm = GetFarm(mSelectedNode)
            Dim _field As Field = GetField(mSelectedNode)
            Dim _world As World = GetWorld(mSelectedNode)
            Dim _analysis As Unit = GetAnalysis(mSelectedNode)

            ' Display the object's context menu
            If Not (_farm Is Nothing) Then
                FarmContextMenu.Show(AnalysisTreeView, mMousePoint)

            ElseIf Not (_field Is Nothing) Then
                FieldContextMenu.Show(AnalysisTreeView, mMousePoint)

            ElseIf Not (_world Is Nothing) Then
                WorldContextMenu.Show(AnalysisTreeView, mMousePoint)

            ElseIf Not (_analysis Is Nothing) Then
                AnalysisContextMenu.Show(AnalysisTreeView, mMousePoint)
            End If
        End If

    End Sub

    Public Sub RefreshView()
        RefreshAnalyses()
        Me.Refresh()
    End Sub

#End Region

#Region " Farm List Methods "

    Private Sub AddFarmHelpNode()

        AnalysisTreeView.Nodes.Clear()

        ' Create & add a simple TreeNode containing the help text
        Dim _node As TreeNode

        AnalysisTreeView.Nodes.Clear()

        ' New Farm / Project
        _node = New TreeNode(mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToStartNewProject.Translated)
        _node.Tag = sDoubleClick
        _node.ImageIndex = ImageIndexes.FarmIcon
        _node.SelectedImageIndex = ImageIndexes.FarmIcon

        AnalysisTreeView.Nodes.Add(_node)

        AnalysisTreeView.ExpandAll()

        mAnalysisDetails.ClearDetails()

    End Sub

    Protected Friend Sub RemoveDeletedFarms()
RemoveDeletedFarm:
        ' Check if all Farms in the TreeView are also in the Farm List
        For Each _node As TreeNode In AnalysisTreeView.Nodes
            If (_node.GetType Is GetType(FarmTreeNode)) Then
                Dim _farmNode As FarmTreeNode = DirectCast(_node, FarmTreeNode)
                ' Check if this Farm is in the Farm List
                Dim _farmID As String = _farmNode.Farm.MyID
                Dim _farm As Farm = mWinSRFR.GetFarmByID(_farmID)
                ' If it isn't; remove it here
                If (_farm Is Nothing) Then
                    AnalysisTreeView.Nodes.Remove(_farmNode)
                    ' Remove() invalidates loop; start it over
                    GoTo RemoveDeletedFarm
                End If
            Else
                AnalysisTreeView.Nodes.Remove(_node)
                ' Remove() invalidates loop; start it over
                GoTo RemoveDeletedFarm
            End If
        Next
    End Sub

    Protected Friend Sub AddNewFarms()
        ' Check if all Farms in the Farm List are also in the TreeView
        Dim _farm As Farm = mWinSRFR.GetFirstFarm
        Dim _idx As Integer = 0

        While Not (_farm Is Nothing)
            If (_idx < AnalysisTreeView.Nodes.Count) Then
                If Not (AnalysisTreeView.Nodes.Item(_idx).Text.EndsWith(_farm.Name.Value)) Then
                    ' Farm is not in TreeView; create and insert a new node for it
                    Dim _farmNode As FarmTreeNode = New FarmTreeNode(mWinSRFR, _farm)

                    _farmNode.ImageIndex = ImageIndexes.FarmIcon
                    _farmNode.SelectedImageIndex = ImageIndexes.FarmIcon

                    AnalysisTreeView.Nodes.Insert(_idx, _farmNode)
                    mAnalysisDetails.DisplayFarmDetails(_farm)

                    ' Also add the Fields below the Farm
                    _farmNode.AddNewFields()
                    _farmNode.Expand()
                End If
            Else
                ' Farm is not in TreeView; create and add a new node for it
                Dim _farmNode As FarmTreeNode = New FarmTreeNode(mWinSRFR, _farm)

                _farmNode.ImageIndex = ImageIndexes.FarmIcon
                _farmNode.SelectedImageIndex = ImageIndexes.FarmIcon

                AnalysisTreeView.Nodes.Add(_farmNode)
                mAnalysisDetails.DisplayFarmDetails(_farm)

                ' Also add the Fields below the Farm
                _farmNode.AddNewFields()
                _farmNode.Expand()

            End If
            _farm = mWinSRFR.GetNextFarm
            _idx += 1
        End While

        ' If no Farms, add "Double-Click..." help
        If (0 = AnalysisTreeView.Nodes.Count) Then
            AddFarmHelpNode()
        End If
    End Sub

#End Region

#End Region

#Region " Model Event Handlers "
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal _reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated

        Select Case (_reason)
            Case WinSRFR.Reasons.FarmList
                RemoveDeletedFarms()
                AddNewFarms()
            Case WinSRFR.Reasons.Nomenclature, WinSRFR.Reasons.Language

                ' Update the Project/Farm & Case/Field text in the TreeView
                '
                ' Scan the AnalysisTreeView for all Farms
                For Each _node1 As TreeNode In AnalysisTreeView.Nodes

                    If (_node1.GetType Is GetType(FarmTreeNode)) Then

                        Dim _farmNode As FarmTreeNode = DirectCast(_node1, FarmTreeNode)

                        ' Update the Project / Farm name
                        _farmNode.Text = mWinSRFR.ProjectFarmText _
                                       + Separator _
                                       + _farmNode.Farm.Name.Value

                        ' Also update the Details view, if necessary
                        If (AnalysisTreeView.SelectedNode Is _farmNode) Then
                            mAnalysisDetails.DisplayFarmDetails(_farmNode.Farm)
                        End If

                        ' Scan each Farm for all Fields
                        For Each _node2 As TreeNode In _farmNode.Nodes

                            If (_node2.GetType Is GetType(FieldTreeNode)) Then

                                Dim _fieldNode As FieldTreeNode = DirectCast(_node2, FieldTreeNode)

                                ' Update the Case / Field name
                                _fieldNode.Text = mWinSRFR.CaseFieldText _
                                                + Separator _
                                                + _fieldNode.Field.Name.Value

                                ' Also update the Details view, if necessary
                                If (AnalysisTreeView.SelectedNode Is _fieldNode) Then
                                    mAnalysisDetails.DisplayFieldDetails(_fieldNode.Field)
                                End If
                            Else
                                ' Must be "Double-Click" node
                                _node2.Tag = sDoubleClick
                                _node2.Text = mDictionary.tDoubleClickHere.Translated & " " & mDictionary.tToAdd.Translated _
                                            + " " + mWinSRFR.CaseFieldText _
                                            + " " + mDictionary.tToThe.Translated _
                                            + " " + mWinSRFR.ProjectFarmText
                            End If
                        Next
                    Else
                        ' Must be "Double-Click" node
                        AddFarmHelpNode()
                    End If
                Next
        End Select

    End Sub

#End Region

#Region " UI Event Handlers "

#Region " TreeView Events "
    '
    ' Execute the 'Action' for the Selected Node
    '
    Private Sub ExecuteAction()
        '
        ' There is no Farm action
        '
        Dim _farm As Farm = GetFarm(mSelectedNode)

        If Not (_farm Is Nothing) Then
            Exit Sub
        End If
        '
        ' There is no Field action
        '
        Dim _field As Field = GetField(mSelectedNode)

        If Not (_field Is Nothing) Then
            Exit Sub
        End If
        '
        ' There is no World action
        '
        Dim _world As World = GetWorld(mSelectedNode)

        If Not (_world Is Nothing) Then
            Exit Sub
        End If
        '
        ' Check for Analysis action
        '
        Dim _analysis As Unit = GetAnalysis(mSelectedNode)

        If Not (_analysis Is Nothing) Then
            ' Analysis action is to show it
            mWinSRFR.ShowUnit(_analysis)
            Exit Sub
        End If
        '
        ' Check if Action is for "Double-Click to ..." user aid
        '
        If (mSelectedNode.Tag Is sDoubleClick) Then

            ' Get reference to parent node
            If Not (mSelectedNode.Parent Is Nothing) Then

                Dim _parentNode As TreeNode = mSelectedNode.Parent

                If (_parentNode.GetType Is GetType(FarmTreeNode)) Then
                    Dim _farmNode As FarmTreeNode = DirectCast(_parentNode, FarmTreeNode)

                    _field = mWinSRFR.AddField(_farmNode.Farm)

                ElseIf (_parentNode.GetType Is GetType(FieldTreeNode)) Then
                    Dim _fieldNode As FieldTreeNode = DirectCast(_parentNode, FieldTreeNode)

                    ' Action depends on selected node's type
                    Dim _worldType As WorldTypes = Globals.WorldTypes.SimulationWorld

                    Select Case (mSelectedNode.ImageIndex)
                        Case ImageIndexes.EventIcon
                            _worldType = Globals.WorldTypes.EventWorld
                        Case ImageIndexes.DesignIcon
                            _worldType = Globals.WorldTypes.DesignWorld
                        Case ImageIndexes.OperationsIcon
                            _worldType = Globals.WorldTypes.OperationsWorld
                    End Select

                    _field = _fieldNode.Field
                    _world = mWinSRFR.AddWorld(_field, _worldType)
                    _analysis = mWinSRFR.AddAnalysis(_world)
                    mWinSRFR.ShowUnit(_analysis)

                ElseIf (_parentNode.GetType Is GetType(WorldTreeNode)) Then
                    Dim _worldNode As WorldTreeNode = DirectCast(_parentNode, WorldTreeNode)

                    _world = _worldNode.World
                    _analysis = mWinSRFR.AddAnalysis(_world)
                    mWinSRFR.ShowUnit(_analysis)

                Else
                    mWinSRFR.NewProject(True)
                End If
            Else
                ' Start a new Project
                mWinSRFR.NewProject(True)
            End If
        End If

    End Sub
    '
    ' Handles KeyDown
    '
    Private Sub AnalysisTreeView_KeyDown(ByVal sender As Object, _
                                         ByVal e As KeyEventArgs) _
    Handles AnalysisTreeView.KeyDown

        Dim _treeNode As TreeNode = AnalysisTreeView.SelectedNode
        If (_treeNode IsNot Nothing) Then

            ' Save Mouse Point and Selected Node
            mMousePoint = New Point(_treeNode.Bounds.X, _treeNode.Bounds.Y + _treeNode.Bounds.Height)
            mSelectedNode = _treeNode

            Select Case (e.KeyValue)
                Case Keys.Left                  ' Collapse the TreeNode
                    mSelectedNode.Collapse()
                Case Keys.Right                 ' Expand the TreeNode
                    mSelectedNode.Expand()
                Case Keys.Delete                ' Delete the node
                    RemoveNode()
                Case Keys.Return                ' Execute the node's Action
                    ExecuteAction()
                Case Keys.Space, Keys.Apps      ' Display the Context Menu for the node
                    DisplayContextMenu()
                Case Keys.F10                   ' Shift+F10 alternate for Keys.App
                    If (e.Modifiers = Keys.Shift) Then
                        DisplayContextMenu()
                    End If
                Case Else
                    Dim _key As Integer = e.KeyValue ' Statement for breakpoint
            End Select
        End If

    End Sub
    '
    ' Display selected item and its Analysis Details after selection change
    '
    Private Sub AnalysisTreeView_AfterSelect(ByVal sender As Object, _
                                             ByVal e As TreeViewEventArgs) _
    Handles AnalysisTreeView.AfterSelect

        ' Get the currently selected TreeView node
        Dim treeNode As TreeNode = AnalysisTreeView.SelectedNode

        If Not (treeNode Is Nothing) Then

            ' Display the object's details
            If (treeNode.ImageIndex = ImageIndexes.FarmIcon) Then

                Dim farm As Farm = GetFarm(treeNode)

                If Not (farm Is Nothing) Then
                    mWinSRFR.SelectedFarm = farm
                    mAnalysisDetails.DisplayFarmDetails(farm)
                End If


            ElseIf (treeNode.ImageIndex = ImageIndexes.FieldIcon) Then

                Dim field As Field = GetField(treeNode)

                If Not (field Is Nothing) Then
                    mWinSRFR.SelectedFarm = field.FarmRef
                    mWinSRFR.SelectedField = field
                    mAnalysisDetails.DisplayFieldDetails(field)
                End If

            ElseIf ((treeNode.ImageIndex = ImageIndexes.EventIcon) _
                 Or (treeNode.ImageIndex = ImageIndexes.DesignIcon) _
                 Or (treeNode.ImageIndex = ImageIndexes.OperationsIcon) _
                 Or (treeNode.ImageIndex = ImageIndexes.SimulationIcon)) Then

                Dim world As World = GetWorld(treeNode)

                If Not (world Is Nothing) Then
                    mWinSRFR.SelectedFarm = world.FieldRef.FarmRef
                    mWinSRFR.SelectedField = world.FieldRef
                    mWinSRFR.SelectedWorld = world
                    mAnalysisDetails.DisplayWorldDetails(world)
                End If

            Else ' Analysis

                Dim analysis As Unit = GetAnalysis(treeNode)

                If Not (analysis Is Nothing) Then
                    mWinSRFR.SelectedFarm = analysis.WorldRef.FieldRef.FarmRef
                    mWinSRFR.SelectedField = analysis.WorldRef.FieldRef
                    mWinSRFR.SelectedWorld = analysis.WorldRef
                    mWinSRFR.SelectedAnalysis = analysis
                    mAnalysisDetails.DisplayUnitDetails(analysis)
                End If
            End If

            Me.Focus()

        End If

    End Sub
    '
    ' Control which AnalysisTreeView nodes can collapse
    '
    Private Sub AnalysisTreeView_BeforeCollapse(ByVal sender As Object, _
                                                ByVal e As TreeViewCancelEventArgs) _
    Handles AnalysisTreeView.BeforeCollapse

        ' Get the currently selected TreeView node
        Dim _treeNode As TreeNode = AnalysisTreeView.SelectedNode

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
    Private Sub AnalysisTreeView_MouseDown(ByVal sender As Object, _
                                           ByVal e As System.Windows.Forms.MouseEventArgs) _
    Handles AnalysisTreeView.MouseDown

        Dim _mousePoint As Point = New Point(e.X, e.Y)
        Dim _treeNode As TreeNode = AnalysisTreeView.GetNodeAt(_mousePoint)

        If Not (_treeNode Is Nothing) Then

            ' Save Mouse Point and Selected Node
            mMousePoint = _mousePoint
            mSelectedNode = _treeNode

            ' Make this the Selected Node in the TreeView
            AnalysisTreeView.SelectedNode = _treeNode

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

    Private Sub AnalysisTreeView_Click(ByVal sender As Object, _
                                       ByVal e As System.EventArgs) _
    Handles AnalysisTreeView.Click

        Select Case (mMouseButton)

            Case MouseButton.Right
                ' Display the right-click (context) menu
                DisplayContextMenu()

        End Select

    End Sub

    Private Sub AnalysisTreeView_DoubleClick(ByVal sender As System.Object, _
                                             ByVal e As System.EventArgs) _
    Handles AnalysisTreeView.DoubleClick
        ' Execute the node's action
        ExecuteAction()
    End Sub

    Private mFirstEnter As Boolean = True
    Private Sub AnalysisTreeView_Enter(ByVal sender As System.Object, _
                                       ByVal e As System.EventArgs) _
    Handles AnalysisTreeView.Enter
        ' Execute the node's action
        If Not (mWinSRFR Is Nothing) Then
            ' Ignore the first Enter; this overwrites the "New Project created" message
            If (mFirstEnter) Then
                mFirstEnter = False
            Else
                mWinSRFR.StatusMessage = AnalysisTreeView.AccessibleDescription
            End If
        End If
    End Sub

#End Region

#Region " Context Menus "

#Region " Context Menu Support Methods "
    '
    ' Add a new World
    '
    Private Sub AddNewWorld(ByVal _worldType As WorldTypes)

        Dim _field As Field = GetField(mSelectedNode)
        If Not (_field Is Nothing) Then
            mWinSRFR.AddWorld(_field, _worldType)
        Else
            Debug.Assert(False, "Could not add new World")
        End If

    End Sub
    '
    ' Start a new Analysis
    '
    Private Sub StartNewAnalysis()

        Dim _world As World = GetWorld(mSelectedNode)
        If Not (_world Is Nothing) Then
            Dim _analysis As Unit = mWinSRFR.AddAnalysis(_world)
            If Not (_analysis Is Nothing) Then
                mWinSRFR.ShowUnit(_analysis)
            Else
                Debug.Assert(False, "Could not create Analysis")
            End If
        Else
            Debug.Assert(False, "Could not find World Folder")
        End If

    End Sub

#End Region

#Region " Farm Context Menu "

    Private Sub FarmContextMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FarmContextMenu.Popup
        ' Display the appropriate Add Case/Field text
        AddFieldItem.Text = mDictionary.tAdd.Translated + " " + mWinSRFR.CaseFieldText + " ..."
        ' Enable Paste Field when appropriate
        PasteFieldItem.Enabled = mWinSRFR.CanPasteField()
    End Sub

    Private Sub AddFieldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AddFieldItem.Click
        ' Add a new Field to the Selected Farm
        Dim _farm As Farm = GetFarm(mSelectedNode)
        mWinSRFR.AddField(_farm)
    End Sub

    Private Sub CutFarmItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CutFarmItem.Click
        Dim _farm As Farm = GetFarm(mSelectedNode)
        mWinSRFR.CutFarm(_farm)
    End Sub

    Private Sub CopyFarmItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CopyFarmItem.Click
        Dim _farm As Farm = GetFarm(mSelectedNode)
        mWinSRFR.CopyFarm(_farm)
    End Sub

    Private Sub PasteFieldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PasteFieldItem.Click
        Dim _farm As Farm = GetFarm(mSelectedNode)
        mWinSRFR.PasteField(_farm)
    End Sub

    Private Sub RunAllFarmAnalysesItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunAllFarmAnalysesItem.Click

        Dim _textViewer As TextViewer = New TextViewer
        _textViewer.Text = mDictionary.tErrors.Translated & " & " & mDictionary.tWarnings.Translated
        _textViewer.ErrorRichTextBox.Clear()

        Dim _farm As Farm = GetFarm(mSelectedNode)
        Dim _field As Field = _farm.GetFirstField
        While (_field IsNot Nothing)
            Dim _world As World = _field.GetFirstWorld
            While (_world IsNot Nothing)
                Dim _unit As Unit = _world.GetFirstAnalysis
                While (_unit IsNot Nothing)
                    mWinSRFR.RunAnalysis(_unit, _textViewer.ErrorRichTextBox)

                    If (mWinSRFR.IsUnitDisplayed(_unit)) Then
                        mWinSRFR.UpdateWorldUI(_unit)
                    End If

                    _unit = _world.GetNextAnalysis
                End While
                _world = _field.GetNextWorld
            End While
            _field = _farm.GetNextField
        End While

        If Not (_textViewer.ErrorRichTextBox.Text = "") Then
            _textViewer.ShowDialog()
        End If
    End Sub

#End Region

#Region " Field Context Menu "

    Private Sub FieldContextMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FieldContextMenu.Popup
        ' Enable Paste World when appropriate
        PasteWorldItem.Enabled = mWinSRFR.CanPasteWorld()
    End Sub

    Private Sub RemoveFieldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RemoveFieldItem.Click
        Dim _field As Field = GetField(mSelectedNode)
        mWinSRFR.RemoveField(_field)
    End Sub

    Private Sub StartNewDesignItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles StartNewDesignItem.Click
        AddNewWorld(Globals.WorldTypes.DesignWorld)
    End Sub

    Private Sub StartNewEventItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles StartNewEventItem.Click
        AddNewWorld(Globals.WorldTypes.EventWorld)
    End Sub

    Private Sub StartNewOperationsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles StartNewOperationsItem.Click
        AddNewWorld(Globals.WorldTypes.OperationsWorld)
    End Sub

    Private Sub StartNewSimulationItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles StartNewSimulationItem.Click
        AddNewWorld(Globals.WorldTypes.SimulationWorld)
    End Sub

    Private Sub CutFieldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CutFieldItem.Click
        Dim _field As Field = GetField(mSelectedNode)
        mWinSRFR.CutField(_field)
    End Sub

    Private Sub CopyFieldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CopyFieldItem.Click
        Dim _field As Field = GetField(mSelectedNode)
        mWinSRFR.CopyField(_field)
    End Sub

    Private Sub PasteWorldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PasteWorldItem.Click
        Dim _field As Field = GetField(mSelectedNode)
        mWinSRFR.PasteWorld(_field)
    End Sub

    Private Sub RunAllFieldAnalysesItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunAllFieldAnalysesItem.Click

        Dim _textViewer As TextViewer = New TextViewer
        _textViewer.Text = mDictionary.tErrors.Translated & " & " & mDictionary.tWarnings.Translated
        _textViewer.ErrorRichTextBox.Clear()

        Dim _field As Field = GetField(mSelectedNode)
        Dim _world As World = _field.GetFirstWorld
        While (_world IsNot Nothing)
            Dim _unit As Unit = _world.GetFirstAnalysis
            While (_unit IsNot Nothing)
                mWinSRFR.RunAnalysis(_unit, _textViewer.ErrorRichTextBox)

                If (mWinSRFR.IsUnitDisplayed(_unit)) Then
                    mWinSRFR.UpdateWorldUI(_unit)
                End If

                _unit = _world.GetNextAnalysis
            End While
            _world = _field.GetNextWorld
        End While

        If Not (_textViewer.ErrorRichTextBox.Text = "") Then
            _textViewer.ShowDialog()
        End If
    End Sub

#End Region

#Region " World Context Menu "

    Private Sub WorldContextMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WorldContextMenu.Popup

        ' Display the appropriate Start New ... menu item
        Dim _world As World = GetWorld(mSelectedNode)

        Select Case (_world.WorldType.Value)
            Case WorldTypes.SimulationWorld
                StartAnalysisItem.Visible = False
                StartSimulationItem.Visible = True

                PasteAnalysisItem.Visible = False
                PasteSimulationItem.Visible = True
                PasteSimulationItem.Enabled = mWinSRFR.CanPasteAnalysis()
            Case Else ' All Analaysis Worlds
                StartSimulationItem.Visible = False
                StartAnalysisItem.Visible = True

                PasteSimulationItem.Visible = False
                PasteAnalysisItem.Visible = True
                PasteAnalysisItem.Enabled = mWinSRFR.CanPasteAnalysis()
        End Select
    End Sub

    Private Sub RemoveWorldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RemoveWorldItem.Click
        Dim _world As World = GetWorld(mSelectedNode)
        mWinSRFR.RemoveWorld(_world)
    End Sub

    Private Sub StartAnalysisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles StartAnalysisItem.Click
        StartNewAnalysis()
    End Sub

    Private Sub StartSimulationItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles StartSimulationItem.Click
        StartNewAnalysis()
    End Sub

    Private Sub CutWorldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CutWorldItem.Click
        Dim _world As World = GetWorld(mSelectedNode)
        mWinSRFR.CutWorld(_world)
    End Sub

    Private Sub CopyWorldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CopyWorldItem.Click
        Dim _world As World = GetWorld(mSelectedNode)
        mWinSRFR.CopyWorld(_world)
    End Sub

    Private Sub PasteAnalysisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PasteAnalysisItem.Click
        Dim _world As World = GetWorld(mSelectedNode)
        mWinSRFR.PasteAnalysis(_world)
    End Sub

    Private Sub PasteSimulationItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PasteSimulationItem.Click
        Dim _world As World = GetWorld(mSelectedNode)
        mWinSRFR.PasteAnalysis(_world)
    End Sub

    Private Sub RunAllWorldAnalysesItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunAllWorldAnalysesItem.Click

        Dim _textViewer As TextViewer = New TextViewer
        _textViewer.Text = mDictionary.tErrors.Translated & " & " & mDictionary.tWarnings.Translated
        _textViewer.ErrorRichTextBox.Clear()

        Dim _world As World = GetWorld(mSelectedNode)
        Dim _unit As Unit = _world.GetFirstAnalysis
        While (_unit IsNot Nothing)
            mWinSRFR.RunAnalysis(_unit, _textViewer.ErrorRichTextBox)

            If (mWinSRFR.IsUnitDisplayed(_unit)) Then
                mWinSRFR.UpdateWorldUI(_unit)
            End If

            _unit = _world.GetNextAnalysis
        End While

        If Not (_textViewer.ErrorRichTextBox.Text = "") Then
            _textViewer.ShowDialog()
        End If
    End Sub

#End Region

#Region " Analysis Context Menu "

    Private Sub OpenAnalysisWindowItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OpenAnalysisWindowItem.Click
        Dim _unit As Unit = GetAnalysis(mSelectedNode)
        mWinSRFR.ShowUnit(_unit)
    End Sub

    Private Sub RemoveAnalysisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RemoveAnalysisItem.Click
        Dim _unit As Unit = GetAnalysis(mSelectedNode)
        mWinSRFR.RemoveAnalysis(_unit)
    End Sub

    Private Sub CutAnalysisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CutAnalysisItem.Click
        Dim _unit As Unit = GetAnalysis(mSelectedNode)
        mWinSRFR.CutAnalysis(_unit)
    End Sub

    Private Sub CopyAnalysisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CopyAnalysisItem.Click
        Dim _unit As Unit = GetAnalysis(mSelectedNode)
        mWinSRFR.CopyAnalysis(_unit)
    End Sub

    Private Sub RunAnalysisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunAnalysisItem.Click

        Dim _textViewer As TextViewer = New TextViewer
        _textViewer.Text = mDictionary.tErrors.Translated & " & " & mDictionary.tWarnings.Translated
        _textViewer.ErrorRichTextBox.Clear()

        Dim _unit As Unit = GetAnalysis(mSelectedNode)
        mWinSRFR.RunAnalysis(_unit, _textViewer.ErrorRichTextBox)

        If (mWinSRFR.IsUnitDisplayed(_unit)) Then
            mWinSRFR.UpdateWorldUI(_unit)
        End If

        If Not (_textViewer.ErrorRichTextBox.Text = "") Then
            _textViewer.ShowDialog()
        End If
    End Sub

#End Region

#End Region

#End Region

End Class
