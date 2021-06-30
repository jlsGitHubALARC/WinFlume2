
'**********************************************************************************************
' Water Distribution Diagram form
'
' Displays a Water Distribution Diagram (i.e. 2D Graph) along with controls to select the
' X & Y contour values for the WDD.
'
Imports DataStore
Imports GraphingUI

Public Class WaterDistributionDiagram
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal worldWindow As WorldWindow, _
                   ByVal x As Double, ByVal y As Double)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitWaterDistributionDiagram(worldWindow, x, y)

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
    Friend WithEvents ControlPanel As DataStore.ctl_Panel
    Friend WithEvents CancelIt As DataStore.ctl_Button
    Friend WithEvents SaveIt As DataStore.ctl_Button
    Friend WithEvents ContourPointBox As DataStore.ctl_GroupBox
    Friend WithEvents XValue As ExNumericUpDown
    Friend WithEvents YValue As ExNumericUpDown
    Friend WithEvents YLabel As System.Windows.Forms.Label
    Friend WithEvents XLabel As System.Windows.Forms.Label
    Friend WithEvents InstructionsPanel As DataStore.ctl_Panel
    Friend WithEvents Instructions1 As DataStore.ctl_Label
    Friend WithEvents Instructions2 As DataStore.ctl_Label
    Friend WithEvents WDD As WinMain.grf_WaterDistributionDiagram
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WaterDistributionDiagram))
        Me.ControlPanel = New DataStore.ctl_Panel
        Me.ContourPointBox = New DataStore.ctl_GroupBox
        Me.XLabel = New System.Windows.Forms.Label
        Me.YLabel = New System.Windows.Forms.Label
        Me.XValue = New WinMain.ExNumericUpDown
        Me.YValue = New WinMain.ExNumericUpDown
        Me.SaveIt = New DataStore.ctl_Button
        Me.CancelIt = New DataStore.ctl_Button
        Me.WDD = New WinMain.grf_WaterDistributionDiagram
        Me.InstructionsPanel = New DataStore.ctl_Panel
        Me.Instructions1 = New DataStore.ctl_Label
        Me.Instructions2 = New DataStore.ctl_Label
        Me.ControlPanel.SuspendLayout()
        Me.ContourPointBox.SuspendLayout()
        CType(Me.XValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.YValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WDD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InstructionsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ControlPanel
        '
        Me.ControlPanel.AccessibleDescription = "Controls contour point where the Water Distribution Diagram is shown."
        Me.ControlPanel.AccessibleName = "Control Panel"
        Me.ControlPanel.Controls.Add(Me.ContourPointBox)
        Me.ControlPanel.Controls.Add(Me.SaveIt)
        Me.ControlPanel.Controls.Add(Me.CancelIt)
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ControlPanel.Location = New System.Drawing.Point(0, 501)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(642, 72)
        Me.ControlPanel.TabIndex = 1
        '
        'ContourPointBox
        '
        Me.ContourPointBox.AccessibleDescription = "Selects point within the contour to display the Water Distribution."
        Me.ContourPointBox.AccessibleName = "Contour Point"
        Me.ContourPointBox.Controls.Add(Me.XLabel)
        Me.ContourPointBox.Controls.Add(Me.YLabel)
        Me.ContourPointBox.Controls.Add(Me.XValue)
        Me.ContourPointBox.Controls.Add(Me.YValue)
        Me.ContourPointBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContourPointBox.Location = New System.Drawing.Point(8, 8)
        Me.ContourPointBox.Name = "ContourPointBox"
        Me.ContourPointBox.Size = New System.Drawing.Size(426, 56)
        Me.ContourPointBox.TabIndex = 0
        Me.ContourPointBox.TabStop = False
        Me.ContourPointBox.Text = "Contour Point"
        '
        'XLabel
        '
        Me.XLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XLabel.Location = New System.Drawing.Point(8, 24)
        Me.XLabel.Name = "XLabel"
        Me.XLabel.Size = New System.Drawing.Size(130, 24)
        Me.XLabel.TabIndex = 0
        Me.XLabel.Text = "&Length (L)"
        Me.XLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'YLabel
        '
        Me.YLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YLabel.Location = New System.Drawing.Point(221, 24)
        Me.YLabel.Name = "YLabel"
        Me.YLabel.Size = New System.Drawing.Size(130, 24)
        Me.YLabel.TabIndex = 2
        Me.YLabel.Text = "&Flow Rate (Q)"
        Me.YLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'XValue
        '
        Me.XValue.AccessibleDescription = "Selects the X-axis contour value"
        Me.XValue.AccessibleName = "X value selection"
        Me.XValue.DecimalPlaces = 1
        Me.XValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XValue.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.XValue.Location = New System.Drawing.Point(147, 24)
        Me.XValue.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.XValue.Name = "XValue"
        Me.XValue.Size = New System.Drawing.Size(64, 23)
        Me.XValue.TabIndex = 1
        '
        'YValue
        '
        Me.YValue.AccessibleDescription = "Selects the Y-axis contour value"
        Me.YValue.AccessibleName = "Y value selection"
        Me.YValue.DecimalPlaces = 1
        Me.YValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YValue.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.YValue.Location = New System.Drawing.Point(352, 24)
        Me.YValue.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.YValue.Name = "YValue"
        Me.YValue.Size = New System.Drawing.Size(64, 23)
        Me.YValue.TabIndex = 3
        '
        'SaveIt
        '
        Me.SaveIt.AccessibleDescription = "Saves the currently selected contour point as the Solution."
        Me.SaveIt.AccessibleName = "Save as Solution"
        Me.SaveIt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SaveIt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveIt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SaveIt.Location = New System.Drawing.Point(440, 8)
        Me.SaveIt.Name = "SaveIt"
        Me.SaveIt.Size = New System.Drawing.Size(110, 55)
        Me.SaveIt.TabIndex = 1
        Me.SaveIt.Text = "&Save as Solution"
        Me.SaveIt.UseVisualStyleBackColor = False
        '
        'CancelIt
        '
        Me.CancelIt.AccessibleDescription = "Closes the dialog box without saving the results."
        Me.CancelIt.AccessibleName = "Cancel Button"
        Me.CancelIt.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelIt.Location = New System.Drawing.Point(558, 39)
        Me.CancelIt.Name = "CancelIt"
        Me.CancelIt.Size = New System.Drawing.Size(72, 24)
        Me.CancelIt.TabIndex = 2
        Me.CancelIt.Text = "&Cancel"
        '
        'WDD
        '
        Me.WDD.AccessibleDescription = "A copyable bitmap image of the Water Distribution Diagram for the selected Contou" & _
            "r Point."
        Me.WDD.AccessibleName = "Water Distribution Diagram"
        Me.WDD.BottomTitleAdjY = 0.0!
        Me.WDD.CopyDataSet = Nothing
        Me.WDD.CurveControlIsOn = False
        Me.WDD.DisplayKey = False
        Me.WDD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WDD.FontAdjustment = 0.0!
        Me.WDD.FontName = "Microsoft Sans Serif"
        Me.WDD.FontSize = 10.0!
        Me.WDD.GraphSymbols = Nothing
        Me.WDD.HorizontalKeys = False
        Me.WDD.HorzLines = Nothing
        Me.WDD.LastCurve = -1
        Me.WDD.LeftTitleAdjX = 0.0!
        Me.WDD.Location = New System.Drawing.Point(0, 48)
        Me.WDD.MaxX = 0
        Me.WDD.MaxY = 0
        Me.WDD.MinX = 0
        Me.WDD.MinY = 0
        Me.WDD.Name = "WDD"
        Me.WDD.NewHotspotKeys = True
        Me.WDD.PosDirX = GraphingUI.ctl_Graph2D.PositiveDirection.PosRight
        Me.WDD.PosDirY = GraphingUI.ctl_Graph2D.PositiveDirection.PosUp
        Me.WDD.RightTitleAdjX = 0.0!
        Me.WDD.Size = New System.Drawing.Size(642, 453)
        Me.WDD.TabIndex = 3
        Me.WDD.TabStop = False
        Me.WDD.Text = "Bitmap Diagram"
        Me.WDD.TextLines = Nothing
        Me.WDD.TitleAdjY = 0.0!
        Me.WDD.TopTitleAdjY = 0.0!
        Me.WDD.UnitsX = DataStore.UnitsDefinition.Units.None
        Me.WDD.UnitsY = DataStore.UnitsDefinition.Units.None
        Me.WDD.VertLabels = Nothing
        Me.WDD.VertLines = Nothing
        Me.WDD.VLabelPos = Nothing
        '
        'InstructionsPanel
        '
        Me.InstructionsPanel.Controls.Add(Me.Instructions1)
        Me.InstructionsPanel.Controls.Add(Me.Instructions2)
        Me.InstructionsPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.InstructionsPanel.Location = New System.Drawing.Point(0, 0)
        Me.InstructionsPanel.Name = "InstructionsPanel"
        Me.InstructionsPanel.Size = New System.Drawing.Size(642, 48)
        Me.InstructionsPanel.TabIndex = 0
        '
        'Instructions1
        '
        Me.Instructions1.Location = New System.Drawing.Point(16, 8)
        Me.Instructions1.Name = "Instructions1"
        Me.Instructions1.Size = New System.Drawing.Size(600, 23)
        Me.Instructions1.TabIndex = 0
        Me.Instructions1.Text = "To update the Water Distribution diagram, use the controls at the bottom, or"
        Me.Instructions1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Instructions2
        '
        Me.Instructions2.Location = New System.Drawing.Point(16, 24)
        Me.Instructions2.Name = "Instructions2"
        Me.Instructions2.Size = New System.Drawing.Size(600, 23)
        Me.Instructions2.TabIndex = 1
        Me.Instructions2.Text = "hold down the Ctrl key while moving the mouse over the contours."
        Me.Instructions2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WaterDistributionDiagram
        '
        Me.AccessibleDescription = "Shows the distribution of infiltrated water."
        Me.AccessibleName = "Water Distribution Diagram"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CancelIt
        Me.ClientSize = New System.Drawing.Size(642, 573)
        Me.Controls.Add(Me.WDD)
        Me.Controls.Add(Me.InstructionsPanel)
        Me.Controls.Add(Me.ControlPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(650, 500)
        Me.Name = "WaterDistributionDiagram"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Water Distribution Diagram"
        Me.ControlPanel.ResumeLayout(False)
        Me.ContourPointBox.ResumeLayout(False)
        CType(Me.XValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.YValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WDD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InstructionsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    ' References
    Private mWorldWindow As WorldWindow
    Private mUnit As Unit
    Private mSystemGeometry As SystemGeometry
    Private mInflowManagement As InflowManagement
    Private mBorderCriteria As BorderCriteria
    Private mAnalysis As Analysis
    Private mContourParameter As ContourParameter

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    ' Flag indicating controls are being initialized
    Private mInitializing As Boolean = False

#End Region

#Region " Properties "

    ' Display data
    Private mX As Double
    Public ReadOnly Property X() As Double
        Get
            Return mX
        End Get
    End Property

    Private mXUnits As Units
    Public ReadOnly Property XUnits() As Units
        Get
            Return mXUnits
        End Get
    End Property

    Private mY As Double
    Public ReadOnly Property Y() As Double
        Get
            Return mY
        End Get
    End Property

    Private mYUnits As Units
    Public ReadOnly Property YUnits() As Units
        Get
            Return mYUnits
        End Get
    End Property

#End Region

#Region " Initialization "
    '
    ' Initialize the Water Distribution Diagram
    '
    Public Sub InitWaterDistributionDiagram(ByVal worldWindow As WorldWindow, _
                                            ByVal x As Double, ByVal y As Double)
        ' Save the input arguments
        mWorldWindow = worldWindow

        ' Get references to current Unit & criteria
        If Not (mWorldWindow Is Nothing) Then
            mUnit = mWorldWindow.DisplayedUnit
            If Not (mUnit Is Nothing) Then
                mSystemGeometry = mUnit.SystemGeometryRef
                mInflowManagement = mUnit.InflowManagementRef
                mBorderCriteria = mUnit.BorderCriteriaRef
                mContourParameter = mUnit.PerformanceResultsRef.DesignContour
            Else
                Return
            End If
            mAnalysis = mWorldWindow.CurrentAnalysis
        End If

        ' Load the X&Y controls
        Me.SetXY(x, y)

    End Sub

#End Region

#Region " Methods "
    '
    ' Update the Water Distribution Diagram's UI
    '
    Private Sub UpdateWDD()
        If (mWorldWindow IsNot Nothing) Then
            If (mUnit IsNot Nothing) Then
                If (mAnalysis IsNot Nothing) Then

                    Me.Text = mDictionary.ControlText(Me)

                    ' Get the SI values for selected contour point
                    Dim x As Double = SiValue(Me.mX, mXUnits)    ' X is in Display Units
                    Dim y As Double = SiValue(Me.mY, mYUnits)    ' Y is in Display Units

                    If (mUnit.CrossSection = CrossSections.Furrow) Then
                        If (mYUnits = Units.None) Then
                            ' y is Furrows Per Set; convert to Width
                            Me.mY = Math.Max(CInt(Me.mY), 1.0)
                            y = Me.mY * mSystemGeometry.FurrowSpacing.Value
                        End If
                    End If

                    ' Build the DataSet for the WDD graph
                    mAnalysis.Ymax = 0 ' jls
                    Dim dataSet As DataSet = WddDataSet(mUnit, mAnalysis, x, y)

                    LoadUserColors(WDD)
                    WDD.InitializeGraph2D(dataSet)
                    WDD.DisplayKey = True
                    WDD.UnitsX = UnitsDefinition.Units.Meters
                    WDD.UnitsY = UnitsDefinition.Units.Millimeters
                    WDD.PosDirY = ctl_Graph2D.PositiveDirection.PosDown
                    WDD.MinY = 0.0 ' Start Infiltration graph at top of soil
                    WDD.DrawImage()

                End If
            End If
        End If

    End Sub
    '
    ' Set new X&Y values for Water Distribution Diagram
    '
    ' Note - X&Y are in SI Units
    '
    Public Sub SetXY(ByVal x As Double, ByVal y As Double)
        If (mWorldWindow IsNot Nothing) Then
            mInitializing = True

            ' Get the Contour Grid
            Dim contourGrid As ContourGrid = mContourParameter.Value

            ' Update the X&Y controls
            Select Case (mUnit.UnitType.Value)
                Case WorldTypes.DesignWorld

                    ' X is always Length
                    mXUnits = mUnitsSystem.LengthUnits
                    XLabel.Text = "&" + mDictionary.tLength.Translated + " (L)"

                    Me.mX = UnitValue(x, mXUnits)
                    If (contourGrid Is Nothing) Then
                        XValue.Minimum = Math.Min(Me.mX, 0)
                        XValue.Maximum = Math.Max(Me.mX, 0)
                    Else ' There is a Contour Grid
                        XValue.Minimum = CDec(UnitValue(contourGrid.MinX, mXUnits))
                        XValue.Maximum = CDec(UnitValue(contourGrid.MaxX, mXUnits))
                        Me.mX = Math.Max(Me.mX, XValue.Minimum)
                        Me.mX = Math.Min(Me.mX, XValue.Maximum)
                    End If
                    XValue.Value = CDec(Me.mX)
                    XValue.Refresh()

                    ' Y is either Width/Furrows Per Set or Flow Rate
                    If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
                        ' Y is Width/Furrows Per Set
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            ' Y is Furrows Per Set
                            mYUnits = Units.None
                            YLabel.Text = "&" + mDictionary.tFurrowsPerSet.Translated
                            YValue.Increment = 1
                            YValue.DecimalPlaces = 0

                            Dim fs As Double = mSystemGeometry.FurrowSpacing.Value
                            Me.mY = Math.Max(CInt(y / fs), 1.0)

                            If (contourGrid Is Nothing) Then
                                YValue.Minimum = Math.Min(Me.mY, 0)
                                YValue.Maximum = Math.Max(Me.mY, 0)
                            Else ' There is a Contour Grid
                                YValue.Minimum = 1
                                YValue.Maximum = CInt(UnitValue(contourGrid.MaxY, mYUnits) / fs)
                                Me.mY = Math.Max(Me.mY, YValue.Minimum)
                                Me.mY = Math.Min(Me.mY, YValue.Maximum)
                            End If
                            YValue.Value = CDec(Me.mY)
                            YValue.Refresh()

                            mInitializing = False
                            UpdateWDD()
                            Return
                        Else
                            ' Y is Width
                            mYUnits = mUnitsSystem.LengthUnits
                            YLabel.Text = "&" + mDictionary.tWidth.Translated + " (W)"
                        End If
                    Else
                        ' Y is Flow Rate
                        mYUnits = mUnitsSystem.FlowRateUnits
                        YLabel.Text = "&" + mDictionary.tFlowRate.Translated + " (Q)"
                    End If

                    ' Y is either Width or Flow Rate
                    Me.mY = UnitValue(y, mYUnits)
                    If (contourGrid Is Nothing) Then
                        YValue.Minimum = Math.Min(Me.mY, 0)
                        YValue.Maximum = Math.Max(Me.mY, 0)
                    Else ' There is a Contour Grid
                        YValue.Minimum = CDec(UnitValue(contourGrid.MinY, mYUnits))
                        YValue.Maximum = CDec(UnitValue(contourGrid.MaxY, mYUnits))
                        Me.mY = Math.Max(Me.mY, YValue.Minimum)
                        Me.mY = Math.Min(Me.mY, YValue.Maximum)
                    End If
                    YValue.Value = CDec(Me.mY)
                    YValue.Refresh()

                Case WorldTypes.OperationsWorld
                    ' X is either Cutoff Time or Cutoff Distance Ratio
                    If (mInflowManagement.CutoffMethod.Value = CutoffMethods.TimeBased) Then
                        ' X is Cutoff Time
                        mXUnits = mUnitsSystem.TimeUnits
                        XLabel.Text = "&" + mDictionary.tCutoff.Translated + " (Tco)"
                    Else
                        ' X is Cutoff Distance Ratio
                        mXUnits = Units.None
                        XLabel.Text = "&" + mDictionary.tCutoff.Translated + " (R)"
                    End If

                    Me.mX = UnitValue(x, mXUnits)
                    If (contourGrid Is Nothing) Then
                        XValue.Minimum = Math.Min(Me.mX, 0)
                        XValue.Maximum = Math.Max(Me.mX, 0)
                    Else ' There is a Contour Grid
                        XValue.Minimum = CDec(UnitValue(contourGrid.MinX, mXUnits))
                        XValue.Maximum = CDec(UnitValue(contourGrid.MaxX, mXUnits))
                        Me.mX = Math.Max(Me.mX, XValue.Minimum)
                        Me.mX = Math.Min(Me.mX, XValue.Maximum)
                    End If
                    XValue.Value = CDec(Me.mX)
                    XValue.Refresh()

                    ' Y is either Flow Rate or Furrows Per Set
                    If ((mUnit.CrossSection = CrossSections.Furrow) _
                    And (mUnit.BorderCriteriaRef.OperationsOption.Value = OperationsOptions.InflowRateGiven)) Then

                        ' Y is Furrows Per Set
                        mYUnits = Units.None
                        YLabel.Text = "&" + mDictionary.tFurrowsPerSet.Translated
                        YValue.Increment = 1
                        YValue.DecimalPlaces = 0

                        Me.mY = Math.Max(CInt(y), 1.0)

                        If (contourGrid Is Nothing) Then
                            YValue.Minimum = Math.Min(Me.mY, 0)
                            YValue.Maximum = Math.Max(Me.mY, 0)
                        Else ' There is a Contour Grid
                            YValue.Minimum = 1
                            YValue.Maximum = CInt(contourGrid.MaxY)
                            Me.mY = Math.Max(Me.mY, YValue.Minimum)
                            Me.mY = Math.Min(Me.mY, YValue.Maximum)
                        End If
                        YValue.Value = CDec(Me.mY)
                        YValue.Refresh()

                    Else
                        ' Y is Inflow Rate
                        mYUnits = mUnitsSystem.FlowRateUnits
                        YLabel.Text = "&" + mDictionary.tFlowRate.Translated + " (Q)"

                        Me.mY = UnitValue(y, mYUnits)
                        If (contourGrid Is Nothing) Then
                            YValue.Minimum = Math.Min(Me.mY, 0)
                            YValue.Maximum = Math.Max(Me.mY, 0)
                        Else ' There is a Contour Grid
                            YValue.Minimum = CDec(UnitValue(contourGrid.MinY, mYUnits))
                            YValue.Maximum = CDec(UnitValue(contourGrid.MaxY, mYUnits))
                            Me.mY = Math.Max(Me.mY, YValue.Minimum)
                            Me.mY = Math.Min(Me.mY, YValue.Maximum)
                        End If
                        YValue.Value = CDec(Me.mY)
                        YValue.Refresh()
                    End If
            End Select

            mInitializing = False
            UpdateWDD()
        End If

    End Sub
    '
    ' Save new Solution
    '
    Private Sub SaveSolution()

        Dim units As Units
        Dim y As Double

        ' Update the X&Y controls
        Select Case (mUnit.UnitType.Value)
            Case WorldTypes.DesignWorld

                ' X is always Length
                units = mUnitsSystem.LengthUnits
                Dim length As DoubleParameter = mSystemGeometry.Length
                length.Value = SiValue(Me.mX, units)
                length.Source = ValueSources.UserEntered
                mSystemGeometry.Length = length
                mSystemGeometry.LengthProperty.ToBeCalculated = False

                ' Y is either Width/Furrows Per Set or Flow Rate
                If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
                    ' Y is Width/Furrows Per Set
                    If (mUnit.CrossSection = CrossSections.Furrow) Then
                        ' y is Furrows Per Set
                        y = Math.Max(CInt(Me.mY), 1.0)

                        Dim furrowsPerSet As DoubleParameter = mSystemGeometry.FurrowsPerSet
                        furrowsPerSet.Value = y
                        furrowsPerSet.Source = ValueSources.UserEntered
                        mSystemGeometry.FurrowsPerSet = furrowsPerSet
                        mSystemGeometry.FurrowsPerSetProperty.ToBeCalculated = False

                        ' Width for Furrow Per Set
                        y *= mSystemGeometry.FurrowSpacing.Value
                    Else
                        ' y is Width
                        units = mUnitsSystem.LengthUnits
                        y = SiValue(Me.mY, units)
                    End If

                    Dim width As DoubleParameter = mSystemGeometry.Width
                    width.Value = y
                    width.Source = ValueSources.UserEntered
                    mSystemGeometry.Width = width
                    mSystemGeometry.WidthProperty.ToBeCalculated = False

                Else ' DesignOptions.WidthGiven
                    ' Y is Inflow Rate
                    units = mUnitsSystem.FlowRateUnits
                    Dim inflowRate As DoubleParameter = mInflowManagement.InflowRate
                    inflowRate.Value = SiValue(Me.mY, units)
                    inflowRate.Source = ValueSources.UserEntered
                    mInflowManagement.InflowRate = inflowRate
                    mInflowManagement.InflowRateProperty.ToBeCalculated = False
                End If

            Case WorldTypes.OperationsWorld

                ' X is either Cutoff Time or Cutoff Distance Ratio
                If (mInflowManagement.CutoffMethod.Value = CutoffMethods.TimeBased) Then
                    ' X is Cutoff Time
                    units = mUnitsSystem.TimeUnits
                    Dim cutoffTime As DoubleParameter = mInflowManagement.CutoffTime
                    cutoffTime.Value = SiValue(Me.mX, units)
                    cutoffTime.Source = ValueSources.UserEntered
                    mInflowManagement.CutoffTime = cutoffTime
                    mInflowManagement.CutoffTimeProperty.ToBeCalculated = False
                Else
                    ' X is Cutoff Distance Ratio
                    Dim cutoffRatio As DoubleParameter = mInflowManagement.CutoffLocationRatio
                    cutoffRatio.Value = Me.mX
                    cutoffRatio.Source = ValueSources.UserEntered
                    mInflowManagement.CutoffLocationRatio = cutoffRatio
                    mInflowManagement.CutoffLocationRatioProperty.ToBeCalculated = False
                End If

                ' Y is either Inflow Rate or Furrows Per Set
                If ((mUnit.CrossSection = CrossSections.Furrow) _
                And (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven)) Then
                    ' Y is Furrows Per Set
                    y = Math.Max(CInt(Me.mY), 1.0)

                    Dim furrowsPerSet As DoubleParameter = mSystemGeometry.FurrowsPerSet
                    furrowsPerSet.Value = y
                    furrowsPerSet.Source = ValueSources.UserEntered
                    mSystemGeometry.FurrowsPerSet = furrowsPerSet
                    mSystemGeometry.FurrowsPerSetProperty.ToBeCalculated = False

                    ' Width for Furrow Per Set
                    y *= mSystemGeometry.FurrowSpacing.Value

                    Dim width As DoubleParameter = mSystemGeometry.Width
                    width.Value = y
                    width.Source = ValueSources.UserEntered
                    mSystemGeometry.Width = width
                    mSystemGeometry.WidthProperty.ToBeCalculated = False

                Else
                    ' Y is Inflow Rate
                    units = mUnitsSystem.FlowRateUnits
                    Dim inflowRate As DoubleParameter = mInflowManagement.InflowRate
                    inflowRate.Value = SiValue(Me.mY, units)
                    inflowRate.Source = ValueSources.UserEntered
                    mInflowManagement.InflowRate = inflowRate
                    mInflowManagement.InflowRateProperty.ToBeCalculated = False
                End If
        End Select

    End Sub

#End Region

#Region " Model Event Handler(s) "

    Private Sub mUnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits

        ' Get current SI values
        Dim x As Double = SiValue(Me.mX, mXUnits)    ' X is in Display Units
        Dim y As Double = SiValue(Me.mY, mYUnits)    ' Y is in Display Units

        ' Update the X&Y controls
        Me.SetXY(x, y)

    End Sub

#End Region

#Region " UI Event Handler(s) "

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        If (WDD.Visible) Then
            WDD.DrawImage()
        End If
    End Sub

    Private Sub XValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles XValue.ValueChanged
        If Not (mInitializing) Then
            Me.mX = CDbl(XValue.Value)
            UpdateWDD()
        End If
    End Sub

    Private Sub XValue_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles XValue.Leave
        If Not (mInitializing) Then
            Me.mX = CDbl(XValue.Value)
            UpdateWDD()
        End If
    End Sub

    Private Sub YValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles YValue.ValueChanged
        If Not (mInitializing) Then
            Me.mY = CDbl(YValue.Value)
            UpdateWDD()
        End If
    End Sub

    Private Sub YValue_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles YValue.Leave
        If Not (mInitializing) Then
            Me.mY = CDbl(YValue.Value)
            UpdateWDD()
        End If
    End Sub

    Private Sub CancelIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CancelIt.Click
        ' Close the dialog box
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SaveIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SaveIt.Click
        Me.SaveSolution()
        mWorldWindow.CalculateSolution()
        ' Close the dialog box
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub WaterDistributionDiagram_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        If (mWorldWindow IsNot Nothing) Then
            mWorldWindow.WinSrfr.ShowDialogPdfHelpManual("ch:OperationsContourNavigation", 0)
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            If (mWorldWindow IsNot Nothing) Then
                mWorldWindow.WinSrfr.ShowDialogPdfHelpManual("ch:OperationsContourNavigation", 0)
            End If
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

End Class
