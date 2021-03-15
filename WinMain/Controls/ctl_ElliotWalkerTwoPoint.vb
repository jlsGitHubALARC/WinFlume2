
'*************************************************************************************************************
' ctl_ElliotWalkerTwoPoint - UI for Elliott-Walker Two-Point irrigation event analyses
'*************************************************************************************************************
Imports System
Imports DataStore

Public Class ctl_ElliotWalkerTwoPoint
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
    Friend WithEvents ElliotWalkerBox As DataStore.ctl_GroupBox
    Friend WithEvents aLabel As System.Windows.Forms.Label
    Friend WithEvents aControl As System.Windows.Forms.Label
    Friend WithEvents kLabel As System.Windows.Forms.Label
    Friend WithEvents kControl As System.Windows.Forms.Label
    Friend WithEvents CalculateBPanel As DataStore.ctl_Panel
    Friend WithEvents InOutControl As System.Windows.Forms.Label
    Friend WithEvents InOutLabel As System.Windows.Forms.Label
    Friend WithEvents QroTcoControl As System.Windows.Forms.Label
    Friend WithEvents QroTcoLabel As System.Windows.Forms.Label
    Friend WithEvents QavgTcoControl As System.Windows.Forms.Label
    Friend WithEvents QavgTcoLabel As System.Windows.Forms.Label
    Friend WithEvents EstimateB As DataStore.ctl_Button
    Friend WithEvents EstimateBLabel As DataStore.ctl_Label
    Friend WithEvents EstimatedBLabel As System.Windows.Forms.Label
    Friend WithEvents EstimatedBControl As DataStore.ctl_DoubleParameter
    Friend WithEvents EstimateKostiakov As DataStore.ctl_Button
    Friend WithEvents EW2PtInstructions As DataStore.ctl_Label
    Friend WithEvents MinusLabel As System.Windows.Forms.Label
    Friend WithEvents WettedPerimeterControl As DataStore.ctl_SelectParameter
    Friend WithEvents WettedPerimeterLabel As DataStore.ctl_Label
    Friend WithEvents RefInflowPanel As DataStore.ctl_Panel
    Friend WithEvents RefInflowLabel As DataStore.ctl_Label
    Friend WithEvents RefInflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents LabelEquals As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ElliotWalkerBox = New DataStore.ctl_GroupBox
        Me.RefInflowPanel = New DataStore.ctl_Panel
        Me.RefInflowLabel = New DataStore.ctl_Label
        Me.RefInflowRateControl = New DataStore.ctl_DoubleParameter
        Me.WettedPerimeterControl = New DataStore.ctl_SelectParameter
        Me.WettedPerimeterLabel = New DataStore.ctl_Label
        Me.EstimateKostiakov = New DataStore.ctl_Button
        Me.EW2PtInstructions = New DataStore.ctl_Label
        Me.aLabel = New System.Windows.Forms.Label
        Me.aControl = New System.Windows.Forms.Label
        Me.kLabel = New System.Windows.Forms.Label
        Me.kControl = New System.Windows.Forms.Label
        Me.CalculateBPanel = New DataStore.ctl_Panel
        Me.InOutControl = New System.Windows.Forms.Label
        Me.QroTcoControl = New System.Windows.Forms.Label
        Me.QavgTcoControl = New System.Windows.Forms.Label
        Me.EstimatedBLabel = New System.Windows.Forms.Label
        Me.InOutLabel = New System.Windows.Forms.Label
        Me.LabelEquals = New System.Windows.Forms.Label
        Me.QroTcoLabel = New System.Windows.Forms.Label
        Me.MinusLabel = New System.Windows.Forms.Label
        Me.EstimatedBControl = New DataStore.ctl_DoubleParameter
        Me.QavgTcoLabel = New System.Windows.Forms.Label
        Me.EstimateB = New DataStore.ctl_Button
        Me.EstimateBLabel = New DataStore.ctl_Label
        Me.ElliotWalkerBox.SuspendLayout()
        Me.RefInflowPanel.SuspendLayout()
        Me.CalculateBPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ElliotWalkerBox
        '
        Me.ElliotWalkerBox.AccessibleDescription = "Evaluate the performance of an irrigation to determine the field's infiltration c" & _
            "haracteristics."
        Me.ElliotWalkerBox.AccessibleName = "Elliott-Walker Two-Point Solution"
        Me.ElliotWalkerBox.Controls.Add(Me.RefInflowPanel)
        Me.ElliotWalkerBox.Controls.Add(Me.WettedPerimeterControl)
        Me.ElliotWalkerBox.Controls.Add(Me.WettedPerimeterLabel)
        Me.ElliotWalkerBox.Controls.Add(Me.EstimateKostiakov)
        Me.ElliotWalkerBox.Controls.Add(Me.EW2PtInstructions)
        Me.ElliotWalkerBox.Controls.Add(Me.aLabel)
        Me.ElliotWalkerBox.Controls.Add(Me.aControl)
        Me.ElliotWalkerBox.Controls.Add(Me.kLabel)
        Me.ElliotWalkerBox.Controls.Add(Me.kControl)
        Me.ElliotWalkerBox.Controls.Add(Me.CalculateBPanel)
        Me.ElliotWalkerBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElliotWalkerBox.Location = New System.Drawing.Point(4, 4)
        Me.ElliotWalkerBox.Name = "ElliotWalkerBox"
        Me.ElliotWalkerBox.Size = New System.Drawing.Size(370, 383)
        Me.ElliotWalkerBox.TabIndex = 1
        Me.ElliotWalkerBox.TabStop = False
        Me.ElliotWalkerBox.Text = "Elliott-Walker Two-Point Solution"
        '
        'RefInflowPanel
        '
        Me.RefInflowPanel.AccessibleDescription = ""
        Me.RefInflowPanel.AccessibleName = ""
        Me.RefInflowPanel.Controls.Add(Me.RefInflowLabel)
        Me.RefInflowPanel.Controls.Add(Me.RefInflowRateControl)
        Me.RefInflowPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowPanel.Location = New System.Drawing.Point(10, 345)
        Me.RefInflowPanel.Name = "RefInflowPanel"
        Me.RefInflowPanel.Size = New System.Drawing.Size(351, 30)
        Me.RefInflowPanel.TabIndex = 9
        '
        'RefInflowLabel
        '
        Me.RefInflowLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowLabel.Location = New System.Drawing.Point(2, 3)
        Me.RefInflowLabel.Name = "RefInflowLabel"
        Me.RefInflowLabel.Size = New System.Drawing.Size(238, 23)
        Me.RefInflowLabel.TabIndex = 1
        Me.RefInflowLabel.Text = "&Reference Inflow Rate"
        Me.RefInflowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RefInflowRateControl
        '
        Me.RefInflowRateControl.AccessibleDescription = "Specifies the reference inflow rate."
        Me.RefInflowRateControl.AccessibleName = "Reference Inflow Rate"
        Me.RefInflowRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RefInflowRateControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowRateControl.IsCalculated = False
        Me.RefInflowRateControl.IsInteger = False
        Me.RefInflowRateControl.Location = New System.Drawing.Point(246, 3)
        Me.RefInflowRateControl.MaxErrMsg = ""
        Me.RefInflowRateControl.MinErrMsg = ""
        Me.RefInflowRateControl.Name = "RefInflowRateControl"
        Me.RefInflowRateControl.Size = New System.Drawing.Size(102, 24)
        Me.RefInflowRateControl.TabIndex = 2
        Me.RefInflowRateControl.ToBeCalculated = True
        Me.RefInflowRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.RefInflowRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.RefInflowRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.RefInflowRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.RefInflowRateControl.ValueText = ""
        '
        'WettedPerimeterControl
        '
        Me.WettedPerimeterControl.AccessibleDescription = "Select the method for describing the wetted perimeter."
        Me.WettedPerimeterControl.AccessibleName = "Wetted Perimeter"
        Me.WettedPerimeterControl.ApplicationValue = -1
        Me.WettedPerimeterControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WettedPerimeterControl.EnableSaveActions = False
        Me.WettedPerimeterControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WettedPerimeterControl.IsCalculated = False
        Me.WettedPerimeterControl.Location = New System.Drawing.Point(137, 31)
        Me.WettedPerimeterControl.Name = "WettedPerimeterControl"
        Me.WettedPerimeterControl.SelectedIndexSet = False
        Me.WettedPerimeterControl.Size = New System.Drawing.Size(221, 24)
        Me.WettedPerimeterControl.TabIndex = 1
        '
        'WettedPerimeterLabel
        '
        Me.WettedPerimeterLabel.AutoSize = True
        Me.WettedPerimeterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WettedPerimeterLabel.Location = New System.Drawing.Point(12, 33)
        Me.WettedPerimeterLabel.Name = "WettedPerimeterLabel"
        Me.WettedPerimeterLabel.Size = New System.Drawing.Size(118, 17)
        Me.WettedPerimeterLabel.TabIndex = 0
        Me.WettedPerimeterLabel.Text = "&Wetted Perimeter"
        Me.WettedPerimeterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EstimateKostiakov
        '
        Me.EstimateKostiakov.AccessibleDescription = "Have WinSRFR estimate Kostiakov a and k."
        Me.EstimateKostiakov.AccessibleName = "Estimate a and k"
        Me.EstimateKostiakov.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstimateKostiakov.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstimateKostiakov.Location = New System.Drawing.Point(11, 289)
        Me.EstimateKostiakov.Name = "EstimateKostiakov"
        Me.EstimateKostiakov.Size = New System.Drawing.Size(168, 48)
        Me.EstimateKostiakov.TabIndex = 4
        Me.EstimateKostiakov.Text = "Estimate &a && k"
        Me.EstimateKostiakov.UseVisualStyleBackColor = False
        '
        'EW2PtInstructions
        '
        Me.EW2PtInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EW2PtInstructions.Location = New System.Drawing.Point(6, 80)
        Me.EW2PtInstructions.Name = "EW2PtInstructions"
        Me.EW2PtInstructions.Size = New System.Drawing.Size(358, 30)
        Me.EW2PtInstructions.TabIndex = 2
        Me.EW2PtInstructions.Text = "Manually enter b or Set b to Estimate from runoff data"
        Me.EW2PtInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'aLabel
        '
        Me.aLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aLabel.Location = New System.Drawing.Point(204, 291)
        Me.aLabel.Name = "aLabel"
        Me.aLabel.Size = New System.Drawing.Size(24, 23)
        Me.aLabel.TabIndex = 5
        Me.aLabel.Text = "a"
        Me.aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'aControl
        '
        Me.aControl.Location = New System.Drawing.Point(234, 290)
        Me.aControl.Name = "aControl"
        Me.aControl.Size = New System.Drawing.Size(120, 23)
        Me.aControl.TabIndex = 6
        Me.aControl.Text = ".315"
        Me.aControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'kLabel
        '
        Me.kLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kLabel.Location = New System.Drawing.Point(204, 314)
        Me.kLabel.Name = "kLabel"
        Me.kLabel.Size = New System.Drawing.Size(24, 23)
        Me.kLabel.TabIndex = 7
        Me.kLabel.Text = "k"
        Me.kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'kControl
        '
        Me.kControl.Location = New System.Drawing.Point(234, 314)
        Me.kControl.Name = "kControl"
        Me.kControl.Size = New System.Drawing.Size(120, 23)
        Me.kControl.TabIndex = 8
        Me.kControl.Text = "24.3 mm/hr^a"
        Me.kControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CalculateBPanel
        '
        Me.CalculateBPanel.AccessibleDescription = "Have WinSRFR estimate b using steady runoff data."
        Me.CalculateBPanel.AccessibleName = "Kostiakov b"
        Me.CalculateBPanel.Controls.Add(Me.InOutControl)
        Me.CalculateBPanel.Controls.Add(Me.QroTcoControl)
        Me.CalculateBPanel.Controls.Add(Me.QavgTcoControl)
        Me.CalculateBPanel.Controls.Add(Me.EstimatedBLabel)
        Me.CalculateBPanel.Controls.Add(Me.InOutLabel)
        Me.CalculateBPanel.Controls.Add(Me.LabelEquals)
        Me.CalculateBPanel.Controls.Add(Me.QroTcoLabel)
        Me.CalculateBPanel.Controls.Add(Me.MinusLabel)
        Me.CalculateBPanel.Controls.Add(Me.EstimatedBControl)
        Me.CalculateBPanel.Controls.Add(Me.QavgTcoLabel)
        Me.CalculateBPanel.Controls.Add(Me.EstimateB)
        Me.CalculateBPanel.Controls.Add(Me.EstimateBLabel)
        Me.CalculateBPanel.Location = New System.Drawing.Point(6, 112)
        Me.CalculateBPanel.Name = "CalculateBPanel"
        Me.CalculateBPanel.Size = New System.Drawing.Size(360, 145)
        Me.CalculateBPanel.TabIndex = 3
        '
        'InOutControl
        '
        Me.InOutControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InOutControl.Location = New System.Drawing.Point(110, 76)
        Me.InOutControl.Name = "InOutControl"
        Me.InOutControl.Size = New System.Drawing.Size(100, 23)
        Me.InOutControl.TabIndex = 6
        Me.InOutControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'QroTcoControl
        '
        Me.QroTcoControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QroTcoControl.Location = New System.Drawing.Point(110, 56)
        Me.QroTcoControl.Name = "QroTcoControl"
        Me.QroTcoControl.Size = New System.Drawing.Size(100, 23)
        Me.QroTcoControl.TabIndex = 4
        Me.QroTcoControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'QavgTcoControl
        '
        Me.QavgTcoControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QavgTcoControl.Location = New System.Drawing.Point(110, 36)
        Me.QavgTcoControl.Name = "QavgTcoControl"
        Me.QavgTcoControl.Size = New System.Drawing.Size(100, 23)
        Me.QavgTcoControl.TabIndex = 2
        Me.QavgTcoControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EstimatedBLabel
        '
        Me.EstimatedBLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimatedBLabel.Location = New System.Drawing.Point(8, 115)
        Me.EstimatedBLabel.Name = "EstimatedBLabel"
        Me.EstimatedBLabel.Size = New System.Drawing.Size(200, 27)
        Me.EstimatedBLabel.TabIndex = 5
        Me.EstimatedBLabel.Text = "&Steady infiltration rate b"
        Me.EstimatedBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InOutLabel
        '
        Me.InOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InOutLabel.Location = New System.Drawing.Point(5, 76)
        Me.InOutLabel.Name = "InOutLabel"
        Me.InOutLabel.Size = New System.Drawing.Size(95, 23)
        Me.InOutLabel.TabIndex = 3
        Me.InOutLabel.Text = "= Qavg - Qro"
        Me.InOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelEquals
        '
        Me.LabelEquals.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEquals.Location = New System.Drawing.Point(8, 81)
        Me.LabelEquals.Name = "LabelEquals"
        Me.LabelEquals.Size = New System.Drawing.Size(16, 23)
        Me.LabelEquals.TabIndex = 8
        Me.LabelEquals.Text = "="
        Me.LabelEquals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'QroTcoLabel
        '
        Me.QroTcoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QroTcoLabel.Location = New System.Drawing.Point(5, 56)
        Me.QroTcoLabel.Name = "QroTcoLabel"
        Me.QroTcoLabel.Size = New System.Drawing.Size(95, 23)
        Me.QroTcoLabel.TabIndex = 2
        Me.QroTcoLabel.Text = "- Qro at Tco"
        Me.QroTcoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MinusLabel
        '
        Me.MinusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinusLabel.Location = New System.Drawing.Point(8, 61)
        Me.MinusLabel.Name = "MinusLabel"
        Me.MinusLabel.Size = New System.Drawing.Size(16, 23)
        Me.MinusLabel.TabIndex = 7
        Me.MinusLabel.Text = "-"
        Me.MinusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EstimatedBControl
        '
        Me.EstimatedBControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.EstimatedBControl.IsCalculated = False
        Me.EstimatedBControl.IsInteger = False
        Me.EstimatedBControl.Location = New System.Drawing.Point(220, 115)
        Me.EstimatedBControl.MaxErrMsg = ""
        Me.EstimatedBControl.MinErrMsg = ""
        Me.EstimatedBControl.Name = "EstimatedBControl"
        Me.EstimatedBControl.Size = New System.Drawing.Size(116, 24)
        Me.EstimatedBControl.TabIndex = 6
        Me.EstimatedBControl.ToBeCalculated = True
        Me.EstimatedBControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.EstimatedBControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.EstimatedBControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.EstimatedBControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.EstimatedBControl.ValueText = ""
        '
        'QavgTcoLabel
        '
        Me.QavgTcoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QavgTcoLabel.Location = New System.Drawing.Point(5, 36)
        Me.QavgTcoLabel.Name = "QavgTcoLabel"
        Me.QavgTcoLabel.Size = New System.Drawing.Size(95, 23)
        Me.QavgTcoLabel.TabIndex = 1
        Me.QavgTcoLabel.Text = "Qavg at Tco"
        Me.QavgTcoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EstimateB
        '
        Me.EstimateB.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstimateB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimateB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstimateB.Location = New System.Drawing.Point(215, 60)
        Me.EstimateB.Name = "EstimateB"
        Me.EstimateB.Size = New System.Drawing.Size(140, 24)
        Me.EstimateB.TabIndex = 4
        Me.EstimateB.Text = "Estimate &b"
        Me.EstimateB.UseVisualStyleBackColor = False
        '
        'EstimateBLabel
        '
        Me.EstimateBLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimateBLabel.Location = New System.Drawing.Point(16, 8)
        Me.EstimateBLabel.Name = "EstimateBLabel"
        Me.EstimateBLabel.Size = New System.Drawing.Size(341, 24)
        Me.EstimateBLabel.TabIndex = 0
        Me.EstimateBLabel.Text = "b is estimated as:  (Qavg - Qro) * 0.5 / Area"
        Me.EstimateBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctl_ElliotWalkerTwoPoint
        '
        Me.Controls.Add(Me.ElliotWalkerBox)
        Me.Name = "ctl_ElliotWalkerTwoPoint"
        Me.Size = New System.Drawing.Size(379, 390)
        Me.ElliotWalkerBox.ResumeLayout(False)
        Me.ElliotWalkerBox.PerformLayout()
        Me.RefInflowPanel.ResumeLayout(False)
        Me.CalculateBPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "
    '
    ' Access to Elliott-Walker Analysis
    '
    Private mElliotWalker As ElliotWalkerTwoPoint
    Private mCalculating As Boolean = False
    Private mUpdatingUI As Boolean = False
    '
    ' Access to DataStore
    '
    Private mUnit As Unit
    Private mWorld As World = Nothing
    Private mField As Field = Nothing
    Private mFarm As Farm = Nothing
    Private mWinSRFR As WinSRFR = Nothing
    Private mMyStore As DataStore.ObjectNode

    Private WithEvents mEventCriteria As EventCriteria
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mSoilCropProperties As SoilCropProperties
    Private WithEvents mUnitControl As UnitControl

    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow

#End Region

#Region " Control / Model Linkage "

    Public Sub LinkToModel(ByVal unit As Unit, ByVal worldWindow As WorldWindow, _
                           ByVal eliotWalker As ElliotWalkerTwoPoint)

        If Not (unit Is Nothing) Then
            ' Save input references & get sub-references
            mUnit = unit
            mWorld = mUnit.WorldRef
            mField = mWorld.FieldRef
            mFarm = mField.FarmRef
            mWinSRFR = mFarm.WinSrfrRef
            mMyStore = mUnit.MyStore

            mEventCriteria = mUnit.EventCriteriaRef
            mSystemGeometry = mUnit.SystemGeometryRef
            mInflowManagement = mUnit.InflowManagementRef
            mSoilCropProperties = mUnit.SoilCropPropertiesRef
            mUnitControl = mUnit.UnitControlRef

            mWorldWindow = worldWindow
            mElliotWalker = eliotWalker

            ' Link controls to their model values
            Me.WettedPerimeterControl.LinkToModel(mMyStore, mSoilCropProperties.WettedPerimeterMethodProperty)
            Me.EstimatedBControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovB_MKProperty)

            Me.RefInflowRateControl.LinkToModel(mMyStore, mEventCriteria.ReferenceFlowRateProperty)
        End If

        UpdateUI()

    End Sub

#End Region

#Region " Elliott-Walker Two-Point Analysis "

    Private Sub EstimateB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EstimateB.Click
        If (mElliotWalker IsNot Nothing) Then
            Dim undoText As String = EstimateB.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)
            ' Run the Elliott-Walker analysis
            mElliotWalker.PerformTwoPointAnalysis()
            ' Load the calculated B
            Dim _b As DoubleParameter = mSoilCropProperties.KostiakovB_MK
            _b.Value = mElliotWalker.EstimateKostiakovB
            _b.Source = ValueSources.Calculated
            mSoilCropProperties.KostiakovB_MK = _b
        End If
    End Sub

    Private Sub EstimateKostiakov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EstimateKostiakov.Click
        If (mElliotWalker IsNot Nothing) Then
            Dim undoText As String = EstimateKostiakov.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)
            ' Estimate Kostiakov k & a
            mElliotWalker.EstimateKostiakovKA()
            ' Check Warnings & Errors
            mElliotWalker.CheckSetupErrorsAndWarnings()
        End If
    End Sub

#End Region

#Region " UI Update Methods "

    Public Sub UpdateUI()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mEventCriteria Is Nothing) Then
            Return
        End If

        ' Only update Elliott-Walker UI if this is the actual Event Analysis selected
        Dim _eventType As EventAnalysisTypes = mEventCriteria.EventAnalysisType.Value
        If Not (_eventType = EventAnalysisTypes.TwoPointAnalysis) Then
            Return
        End If

        mUpdatingUI = True

        ' Reference Inflow is a Research level option
        If (WinSRFR.UserLevel = UserLevels.Research) Then
            RefInflowPanel.Show()
        Else
            RefInflowPanel.Hide()
        End If

        ' Update estimate controls
        Dim kChangedTime As DateTime = mSoilCropProperties.KostiakovK_MK.Timestamp
        Dim kHasChanged As Boolean = mUnit.DataHasChangedSince(kChangedTime)
        Dim resultsAreInvalid As Boolean = Not mUnit.ResultsAreValid

        If ((kHasChanged) And (resultsAreInvalid)) Then
            ' Display all values as 'errored'
            Me.aControl.Text = String.Empty
            Me.aControl.BackColor = DataStore.Globals.BackColor_Errored

            Me.kControl.Text = String.Empty
            Me.kControl.BackColor = DataStore.Globals.BackColor_Errored
        Else
            ' Display corresponding k & a
            Dim k As Double = mSoilCropProperties.KostiakovK
            Dim a As Double = mSoilCropProperties.KostiakovA

            Dim kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            Me.kControl.Text = KostiakovKParameter.KostiakovKString(k, a, kunits, 0)
            Me.kControl.BackColor = SystemColors.Control

            Me.aControl.Text = Format(a, "0.00#")
            Me.aControl.BackColor = SystemColors.Control
        End If

        ' Verify Time values
        Dim pt2Time As Double = mInflowManagement.TwoPointTime2
        Dim cutoff As Double = mInflowManagement.Cutoff

        If (cutoff < pt2Time) Then
            Me.EstimateB.Enabled = False
            Me.EstimateKostiakov.Enabled = False
        Else
            Me.EstimateB.Enabled = True
            Me.EstimateKostiakov.Enabled = True
        End If

        ' Run the Elliott-Walker analysis
        mElliotWalker.PerformTwoPointAnalysis()

        ' Display inputs for Kostiakov b
        Dim _qavg As Double = mElliotWalker.QavgFinal
        Me.QavgTcoControl.Text = FlowRateString(_qavg, 0)

        Dim _qro As Double = mElliotWalker.SteadyRO
        Me.QroTcoControl.Text = FlowRateString(_qro, 0)
        If (0 < _qro) Then
            Me.QroTcoControl.BackColor = SystemColors.Control
        Else
            Me.QroTcoControl.BackColor = DataStore.BackColor_Warning
        End If

        Dim _inout As Double = mElliotWalker.InOut
        Me.InOutControl.Text = FlowRateString(_inout, 0)
        If (0 <= _inout) Then
            Me.InOutControl.BackColor = SystemColors.Control
        Else
            Me.InOutControl.BackColor = DataStore.BackColor_Errored
        End If

        ' Wetted Perimeter only applies to Furrows
        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

            ' Get selection flags for current World, Cross Section & User Level
            Dim worldType As WorldTypes = CType(mWorld.WorldType.Value, WorldTypes)
            Dim crossSection As CrossSections = mUnit.CrossSection
            Dim userLevel As UserLevels = mWinSRFR.UserLevel
            Dim selFlags As Globals.SelFlags = GetSelFlags(worldType, crossSection, userLevel)

            Dim _infiltration As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value

            ' Update selection list
            Dim wettedPerimeterOption As WettedPerimeterMethods = CType(mSoilCropProperties.WettedPerimeterMethod.Value, WettedPerimeterMethods)
            Dim sel As String = String.Empty

            Me.WettedPerimeterControl.Clear()

            Dim wettedPerimeters As SelFlags() = InfiltrationWettedPerimeterConstraints(_infiltration)
            Dim val As Integer = 0

            Dim selOk As Boolean = mSoilCropProperties.GetFirstWettedPerimeterMethodSelection(sel)
            While Not (sel Is Nothing)
                If Not (sel = sLocalWettedPerimeter) Then
                    Dim worldFlags As SelFlags = wettedPerimeters(val)
                    If Not (0 = (worldFlags And selFlags)) Then
                        Me.WettedPerimeterControl.Add(sel, val, True)
                    ElseIf (wettedPerimeterOption = val) Then
                        Me.WettedPerimeterControl.Add(sel, val, False)
                    End If
                End If

                selOk = mSoilCropProperties.GetNextWettedPerimeterMethodSelection(sel)
                val += 1
            End While

            Me.WettedPerimeterLabel.Show()
            Me.WettedPerimeterControl.Show()

            ' Update selection
            Me.WettedPerimeterControl.UpdateUI()

        Else ' Basin / Border

            Me.WettedPerimeterLabel.Hide()
            Me.WettedPerimeterControl.Hide()
        End If

        mUpdatingUI = False

    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' Update UI when referenced Model data changes
    '
    Private Sub EventCriteria_PropertyChanged(ByVal reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        If Not (mCalculating Or mElliotWalker.Running) Then
            UpdateUI()
        End If
    End Sub

    Private Sub SystemGeometry_PropertyChanged(ByVal reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        If Not (mCalculating Or mElliotWalker.Running) Then
            UpdateUI()
        End If
    End Sub

    Private Sub SoilCropProperties_PropertyChanged(ByVal reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        If Not (mCalculating Or mElliotWalker.Running) Then
            UpdateUI()
        End If
    End Sub

    Private Sub InflowManagement_PropertyChanged(ByVal reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        If Not (mCalculating Or mElliotWalker.Running) Then
            UpdateUI()
        End If
    End Sub

    Private Sub UnitControl_PropertyChanged(ByVal reason As UnitControl.Reasons) _
    Handles mUnitControl.PropertyDataUpdated
        If Not (mCalculating Or mElliotWalker.Running) Then
            UpdateUI()
        End If
    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub WettedPerimeterControl_PreSaveAction(ByRef selection As Integer, ByRef saveOk As Boolean) _
    Handles WettedPerimeterControl.PreSaveAction
        saveOk = False
        If (mElliotWalker IsNot Nothing) Then
            mElliotWalker.WettedPerimeterMessage(selection)
            saveOk = True
        End If
    End Sub

    Private Sub MK_WettedPerimeterControl_ControlValueChanged() _
    Handles WettedPerimeterControl.ControlValueChanged
        If (mElliotWalker IsNot Nothing) Then
            mElliotWalker.ConvertWettedPerimeter()
        End If
    End Sub

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        Try
            ' Adjust control heights
            Dim ctrlHeight As Integer = Me.Height

            Me.ElliotWalkerBox.Height = ctrlHeight - 9

        Catch ex As Exception
        End Try
    End Sub
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

End Class
