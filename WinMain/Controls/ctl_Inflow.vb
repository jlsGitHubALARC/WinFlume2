
'**********************************************************************************************
' ctl_Inflow - UI for viewing & editing the Inflow data
'
' Note - ctl_Inflow is a slimmed-down version of ctl_InflowManagement. It is meant to be
'        used in the Evaluation World. The position of the controls are rearranged to better
'        match other Evaluation World input tabs.  An Instructions field is added to guide the
'        user during data entry.
'
' Only Standard Hydrograph & Tabulated Inflow are supported (no Surge, Cablegation or Drainback)
'
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI
Imports PrintingUI

Public Class ctl_Inflow
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
    Friend WithEvents HydrographGraphicsPanel As DataStore.ctl_Panel
    Friend WithEvents InflowHydrograph As GraphingUI.ex_PictureBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents InflowStatsPanel As DataStore.ctl_Panel
    Friend WithEvents AppliedDepthLabel As System.Windows.Forms.Label
    Friend WithEvents AppliedDepthValue As System.Windows.Forms.Label
    Friend WithEvents InflowGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents InflowMethodControl As DataStore.ctl_SelectParameter
    Friend WithEvents StdHydroPanel As DataStore.ctl_Panel
    Friend WithEvents StdHydroControl As WinMain.ctl_StdHydro
    Friend WithEvents TabulatedInflowPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedInflowControl As DataStore.ctl_DataTableParameter
    Friend WithEvents InfiltratedDepthLabel As DataStore.ctl_Label
    Friend WithEvents EqualsLabel2 As System.Windows.Forms.Label
    Friend WithEvents DepthAppliedControl As System.Windows.Forms.Label
    Friend WithEvents DepthAppliedLabel As DataStore.ctl_Label
    Friend WithEvents InfiltratedDepthControl As System.Windows.Forms.Label
    Friend WithEvents AverageDepthsLabel As DataStore.ctl_Label
    Friend WithEvents InflowLabel As DataStore.ctl_Label
    Friend WithEvents InflowInstructions As WinMain.ErrorRichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.HydrographGraphicsPanel = New DataStore.ctl_Panel
        Me.InflowHydrograph = New GraphingUI.ex_PictureBox
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.InflowStatsPanel = New DataStore.ctl_Panel
        Me.AppliedDepthValue = New System.Windows.Forms.Label
        Me.AppliedDepthLabel = New System.Windows.Forms.Label
        Me.InflowGroupBox = New DataStore.ctl_GroupBox
        Me.TabulatedInflowPanel = New DataStore.ctl_Panel
        Me.TabulatedInflowControl = New DataStore.ctl_DataTableParameter
        Me.InflowMethodControl = New DataStore.ctl_SelectParameter
        Me.StdHydroPanel = New DataStore.ctl_Panel
        Me.StdHydroControl = New WinMain.ctl_StdHydro
        Me.AverageDepthsLabel = New DataStore.ctl_Label
        Me.InfiltratedDepthControl = New System.Windows.Forms.Label
        Me.DepthAppliedLabel = New DataStore.ctl_Label
        Me.DepthAppliedControl = New System.Windows.Forms.Label
        Me.EqualsLabel2 = New System.Windows.Forms.Label
        Me.InfiltratedDepthLabel = New DataStore.ctl_Label
        Me.InflowInstructions = New WinMain.ErrorRichTextBox
        Me.InflowLabel = New DataStore.ctl_Label
        Me.HydrographGraphicsPanel.SuspendLayout()
        CType(Me.InflowHydrograph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InflowStatsPanel.SuspendLayout()
        Me.InflowGroupBox.SuspendLayout()
        Me.TabulatedInflowPanel.SuspendLayout()
        CType(Me.TabulatedInflowControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StdHydroPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'HydrographGraphicsPanel
        '
        Me.HydrographGraphicsPanel.Controls.Add(Me.InflowHydrograph)
        Me.HydrographGraphicsPanel.Location = New System.Drawing.Point(244, 4)
        Me.HydrographGraphicsPanel.Name = "HydrographGraphicsPanel"
        Me.HydrographGraphicsPanel.Size = New System.Drawing.Size(531, 150)
        Me.HydrographGraphicsPanel.TabIndex = 3
        '
        'InflowHydrograph
        '
        Me.InflowHydrograph.AccessibleDescription = "A copyable bitmap image"
        Me.InflowHydrograph.AccessibleName = "Inflow Hydrograph"
        Me.InflowHydrograph.Location = New System.Drawing.Point(3, 3)
        Me.InflowHydrograph.Name = "InflowHydrograph"
        Me.InflowHydrograph.Size = New System.Drawing.Size(525, 144)
        Me.InflowHydrograph.TabIndex = 16
        Me.InflowHydrograph.TabStop = False
        Me.InflowHydrograph.Text = "Bitmap Diagram"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'InflowStatsPanel
        '
        Me.InflowStatsPanel.Controls.Add(Me.AppliedDepthValue)
        Me.InflowStatsPanel.Controls.Add(Me.AppliedDepthLabel)
        Me.InflowStatsPanel.Location = New System.Drawing.Point(244, 158)
        Me.InflowStatsPanel.Name = "InflowStatsPanel"
        Me.InflowStatsPanel.Size = New System.Drawing.Size(532, 95)
        Me.InflowStatsPanel.TabIndex = 4
        '
        'AppliedDepthValue
        '
        Me.AppliedDepthValue.Location = New System.Drawing.Point(270, 8)
        Me.AppliedDepthValue.Name = "AppliedDepthValue"
        Me.AppliedDepthValue.Size = New System.Drawing.Size(256, 23)
        Me.AppliedDepthValue.TabIndex = 1
        Me.AppliedDepthValue.Text = "= 100 mm"
        Me.AppliedDepthValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AppliedDepthLabel
        '
        Me.AppliedDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppliedDepthLabel.Location = New System.Drawing.Point(6, 8)
        Me.AppliedDepthLabel.Name = "AppliedDepthLabel"
        Me.AppliedDepthLabel.Size = New System.Drawing.Size(260, 23)
        Me.AppliedDepthLabel.TabIndex = 0
        Me.AppliedDepthLabel.Text = "Depth Applied (Dapp)"
        Me.AppliedDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InflowGroupBox
        '
        Me.InflowGroupBox.Controls.Add(Me.TabulatedInflowPanel)
        Me.InflowGroupBox.Controls.Add(Me.InflowMethodControl)
        Me.InflowGroupBox.Controls.Add(Me.StdHydroPanel)
        Me.InflowGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowGroupBox.Location = New System.Drawing.Point(10, 30)
        Me.InflowGroupBox.Name = "InflowGroupBox"
        Me.InflowGroupBox.Size = New System.Drawing.Size(228, 386)
        Me.InflowGroupBox.TabIndex = 1
        Me.InflowGroupBox.TabStop = False
        Me.InflowGroupBox.Text = "&Inflow"
        '
        'TabulatedInflowPanel
        '
        Me.TabulatedInflowPanel.AccessibleDescription = "Specifies the inflow as a table of time and rate values."
        Me.TabulatedInflowPanel.AccessibleName = "Tabulated Inflow"
        Me.TabulatedInflowPanel.Controls.Add(Me.TabulatedInflowControl)
        Me.TabulatedInflowPanel.Location = New System.Drawing.Point(3, 60)
        Me.TabulatedInflowPanel.Name = "TabulatedInflowPanel"
        Me.TabulatedInflowPanel.Size = New System.Drawing.Size(222, 322)
        Me.TabulatedInflowPanel.TabIndex = 2
        '
        'TabulatedInflowControl
        '
        Me.TabulatedInflowControl.AccessibleDescription = "Table for entering tabulated inflow."
        Me.TabulatedInflowControl.AccessibleName = "Inflow Table"
        Me.TabulatedInflowControl.AllRowsFixed = False
        Me.TabulatedInflowControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedInflowControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedInflowControl.CaptionText = "Inflow Table"
        Me.TabulatedInflowControl.ColumnWidthRatios = Nothing
        Me.TabulatedInflowControl.DataMember = ""
        Me.TabulatedInflowControl.EnableSaveActions = False
        Me.TabulatedInflowControl.FirstColumnIncreases = True
        Me.TabulatedInflowControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedInflowControl.FirstColumnMinimum = 0
        Me.TabulatedInflowControl.FirstRowFixed = True
        Me.TabulatedInflowControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedInflowControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedInflowControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedInflowControl.Location = New System.Drawing.Point(11, 3)
        Me.TabulatedInflowControl.MaxRows = 250
        Me.TabulatedInflowControl.MinRows = 2
        Me.TabulatedInflowControl.Name = "TabulatedInflowControl"
        Me.TabulatedInflowControl.SecondColumnIncreases = False
        Me.TabulatedInflowControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedInflowControl.SecondColumnMinimum = 0
        Me.TabulatedInflowControl.Size = New System.Drawing.Size(200, 317)
        Me.TabulatedInflowControl.TabIndex = 0
        Me.TabulatedInflowControl.TableReadonly = False
        '
        'InflowMethodControl
        '
        Me.InflowMethodControl.AccessibleDescription = "Selects the mechanism used to deliver water to the field."
        Me.InflowMethodControl.AccessibleName = "Inflow Method"
        Me.InflowMethodControl.ApplicationValue = -1
        Me.InflowMethodControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InflowMethodControl.EnableSaveActions = False
        Me.InflowMethodControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowMethodControl.IsCalculated = False
        Me.InflowMethodControl.ItemHeight = 16
        Me.InflowMethodControl.Location = New System.Drawing.Point(14, 25)
        Me.InflowMethodControl.Name = "InflowMethodControl"
        Me.InflowMethodControl.SelectedIndexSet = False
        Me.InflowMethodControl.Size = New System.Drawing.Size(200, 24)
        Me.InflowMethodControl.TabIndex = 1
        '
        'StdHydroPanel
        '
        Me.StdHydroPanel.AccessibleDescription = "Specifies the Inflow Rate, Cutoff and Cutback Options associated with the Standar" & _
            "d Hydograph method."
        Me.StdHydroPanel.AccessibleName = "Standard Hydrograph"
        Me.StdHydroPanel.Controls.Add(Me.StdHydroControl)
        Me.StdHydroPanel.Location = New System.Drawing.Point(3, 60)
        Me.StdHydroPanel.Name = "StdHydroPanel"
        Me.StdHydroPanel.Size = New System.Drawing.Size(222, 322)
        Me.StdHydroPanel.TabIndex = 2
        '
        'StdHydroControl
        '
        Me.StdHydroControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StdHydroControl.Location = New System.Drawing.Point(3, 3)
        Me.StdHydroControl.Margin = New System.Windows.Forms.Padding(4)
        Me.StdHydroControl.Name = "StdHydroControl"
        Me.StdHydroControl.Size = New System.Drawing.Size(216, 290)
        Me.StdHydroControl.TabIndex = 0
        '
        'AverageDepthsLabel
        '
        Me.AverageDepthsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AverageDepthsLabel.Location = New System.Drawing.Point(21, 4)
        Me.AverageDepthsLabel.Name = "AverageDepthsLabel"
        Me.AverageDepthsLabel.Size = New System.Drawing.Size(208, 23)
        Me.AverageDepthsLabel.TabIndex = 1
        Me.AverageDepthsLabel.Text = "Average Depths:"
        Me.AverageDepthsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InfiltratedDepthControl
        '
        Me.InfiltratedDepthControl.AccessibleDescription = "Displays average depth of water that infiltrated into field as Depth Applied - Ru" & _
            "noff Depth."
        Me.InfiltratedDepthControl.AccessibleName = "Infiltrated Depth"
        Me.InfiltratedDepthControl.Location = New System.Drawing.Point(200, 68)
        Me.InfiltratedDepthControl.Name = "InfiltratedDepthControl"
        Me.InfiltratedDepthControl.Size = New System.Drawing.Size(64, 23)
        Me.InfiltratedDepthControl.TabIndex = 7
        Me.InfiltratedDepthControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DepthAppliedLabel
        '
        Me.DepthAppliedLabel.Location = New System.Drawing.Point(26, 28)
        Me.DepthAppliedLabel.Name = "DepthAppliedLabel"
        Me.DepthAppliedLabel.Size = New System.Drawing.Size(170, 23)
        Me.DepthAppliedLabel.TabIndex = 2
        Me.DepthAppliedLabel.Text = "Depth Applied (Dapp):"
        Me.DepthAppliedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DepthAppliedControl
        '
        Me.DepthAppliedControl.AccessibleDescription = "Displays average depth of water applied to the field."
        Me.DepthAppliedControl.AccessibleName = "Depth Applied"
        Me.DepthAppliedControl.Location = New System.Drawing.Point(200, 28)
        Me.DepthAppliedControl.Name = "DepthAppliedControl"
        Me.DepthAppliedControl.Size = New System.Drawing.Size(64, 23)
        Me.DepthAppliedControl.TabIndex = 3
        Me.DepthAppliedControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EqualsLabel2
        '
        Me.EqualsLabel2.Location = New System.Drawing.Point(17, 68)
        Me.EqualsLabel2.Name = "EqualsLabel2"
        Me.EqualsLabel2.Size = New System.Drawing.Size(16, 23)
        Me.EqualsLabel2.TabIndex = 35
        Me.EqualsLabel2.Text = "="
        Me.EqualsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InfiltratedDepthLabel
        '
        Me.InfiltratedDepthLabel.Location = New System.Drawing.Point(37, 68)
        Me.InfiltratedDepthLabel.Name = "InfiltratedDepthLabel"
        Me.InfiltratedDepthLabel.Size = New System.Drawing.Size(159, 23)
        Me.InfiltratedDepthLabel.TabIndex = 6
        Me.InfiltratedDepthLabel.Text = "Depth Infiltrated (Dinf):"
        Me.InfiltratedDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InflowInstructions
        '
        Me.InflowInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.InflowInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.InflowInstructions.Location = New System.Drawing.Point(244, 260)
        Me.InflowInstructions.Name = "InflowInstructions"
        Me.InflowInstructions.ReadOnly = True
        Me.InflowInstructions.Size = New System.Drawing.Size(528, 156)
        Me.InflowInstructions.TabIndex = 5
        Me.InflowInstructions.Text = ""
        '
        'InflowLabel
        '
        Me.InflowLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowLabel.Location = New System.Drawing.Point(10, 4)
        Me.InflowLabel.Name = "InflowLabel"
        Me.InflowLabel.Size = New System.Drawing.Size(228, 24)
        Me.InflowLabel.TabIndex = 0
        Me.InflowLabel.Text = "Inflow"
        Me.InflowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctl_Inflow
        '
        Me.Controls.Add(Me.InflowInstructions)
        Me.Controls.Add(Me.InflowGroupBox)
        Me.Controls.Add(Me.HydrographGraphicsPanel)
        Me.Controls.Add(Me.InflowLabel)
        Me.Controls.Add(Me.InflowStatsPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_Inflow"
        Me.Size = New System.Drawing.Size(780, 422)
        Me.HydrographGraphicsPanel.ResumeLayout(False)
        CType(Me.InflowHydrograph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InflowStatsPanel.ResumeLayout(False)
        Me.InflowGroupBox.ResumeLayout(False)
        Me.TabulatedInflowPanel.ResumeLayout(False)
        CType(Me.TabulatedInflowControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StdHydroPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' References to model objects
    '
    Private mUnit As Unit = Nothing
    Private mWorld As World = Nothing
    Private mField As Field = Nothing
    Private mFarm As Farm = Nothing
    Private mDictionary As Dictionary = Nothing
    Private mMyStore As DataStore.ObjectNode = Nothing

    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Private WithEvents mSystemGeometry As SystemGeometry = Nothing
    Private WithEvents mInflowManagement As InflowManagement = Nothing

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    '
    ' Establish links to model objects and update UI
    '
    Public Sub LinkToModel(ByVal _unit As Unit)

        Debug.Assert(_unit IsNot Nothing)

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef

        mDictionary = Dictionary.Instance
        mMyStore = mUnit.MyStore

        ' Link the contained controls to their models & store
        Me.InflowMethodControl.LinkToModel(mMyStore, mInflowManagement.InflowMethodProperty)

        ' Inflow controls
        Me.StdHydroControl.LinkToModel(mUnit)

        ' Tabulated Inflow control
        Me.TabulatedInflowControl.LinkToModel(mMyStore, mInflowManagement.TabulatedInflowProperty)
        Me.TabulatedInflowControl.UpdateUI()

        ' Update language translation
        UpdateLanguage()

        ' Update this control's User Interface
        UpdateUI()

    End Sub
    '
    ' Update UI when Inflow Management values change
    '
    Private Sub InflowManagement_PropertyChanged(ByVal _reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when System Geometry changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI graphics when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateGraphics()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Public Sub UpdateUI()
        ' Update the UI only if it is linked to a model object
        If (mUnit IsNot Nothing) Then
            UpdateCrossSection()
            UpdateInflow()

            StdHydroControl.UpdateUI()

            UpdateInstructions()
            UpdateGraphics()
        End If
    End Sub
    '
    ' Update the display of the Cross Section related UI
    '
    Private Sub UpdateCrossSection()
        Dim _crossSection As String = mSystemGeometry.CrossSectionName()
        Me.InflowLabel.Text = _crossSection
    End Sub
    '
    ' Update the Inflow method selection list & selection
    '
    Private Sub UpdateInflow()

        ' Update selection list
        Dim inflowMethod As Integer = mInflowManagement.InflowMethod.Value
        Dim selection As String = String.Empty
        Dim idx As Integer = 0

        InflowMethodControl.Clear()

        Dim ok As Boolean = mInflowManagement.GetFirstInflowMethodSelection(selection)
        While (selection IsNot Nothing)
            If (ok) Then
                InflowMethodControl.Add(selection, idx, True)
            ElseIf (inflowMethod = idx) Then
                InflowMethodControl.Add(selection, idx, False)
            End If
            ok = mInflowManagement.GetNextInflowMethodSelection(selection)
            idx += 1
        End While

        ' Update selection
        InflowMethodControl.UpdateUI()

        ' Hide / Show corresponding UI panels
        Select Case mInflowManagement.InflowMethod.Value

            Case InflowMethods.TabulatedInflow
                StdHydroPanel.Hide()
                TabulatedInflowPanel.Show()

                TabulatedInflowControl.UpdateUI()

            Case Else ' Assume StandardHydrograph
                TabulatedInflowPanel.Hide()
                StdHydroPanel.Show()

        End Select

    End Sub
    '
    ' Update instructions for entering inflow data
    '
    Private Sub UpdateInstructions()
        InflowInstructions.Clear()
        InflowInstructions.SelectionAlignment = HorizontalAlignment.Left

        AppendBoldText(InflowInstructions, mDictionary.tInflow.Translated & " - ")
        AppendLine(InflowInstructions, mDictionary.tInflowInstructions.Translated)

        AdvanceLine(InflowInstructions)

    End Sub
    '
    ' Make sure the graphics are up to date whenever they become visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        If (Visible) Then
            UpdateGraphics()
        End If
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " Inflow Graphics "
    '
    ' Update the Inflow graphics
    '
    Private Sub UpdateGraphics()

        If (mUnit IsNot Nothing) Then
            ' Enclose all graphics code in Try Catch block to ignore exceptions
            Try
                Select Case mInflowManagement.InflowMethod.Value

                    Case InflowMethods.TabulatedInflow
                        Dim _tabulatedInflow As DataTable = mInflowManagement.TabulatedInflow.Value
                        GraphTabulatedInflow(InflowHydrograph, _tabulatedInflow)

                    Case Else ' Assume InflowMethods.StandardHydrograph
                        GraphHydrograph(InflowHydrograph)
                End Select

            Catch ex As Exception
                ' Ignore exceptions
            End Try
        End If

    End Sub
    '
    ' Graphics for Standard Hydrograph
    '
    Private Sub GraphHydrograph(ByVal _pictureBox As PictureBox)

        ' Get the Hydrograph values
        Dim _length As Double = mSystemGeometry.Length.Value
        Dim _width As Double = mSystemGeometry.Width.Value

        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
            _width = mSystemGeometry.FurrowSpacing.Value
        End If

        Dim _inflowRate As Double = mInflowManagement.InflowRate.Value
        Dim _cutbackRate As Double = _inflowRate * mInflowManagement.CutbackRateRatio.Value

        Dim _cutoffTime As Double = mInflowManagement.CutoffTime.Value
        Dim _cutbackTime As Double = _cutoffTime * mInflowManagement.CutbackTimeRatio.Value

        Dim _cutoffLocation As Double = _length * mInflowManagement.CutoffLocationRatio.Value
        Dim _cutbackLocation As Double = _length * mInflowManagement.CutbackLocationRatio.Value

        Dim _cutbackMethod As CutbackMethods = CType(mInflowManagement.CutbackMethod.Value, CutbackMethods)
        Dim _cutoffMethod As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)

        Dim _appliedVolume As Double = mInflowManagement.AppliedVolume
        Dim _infiltratedVolume As Double = mInflowManagement.InfiltratedVolume

        Dim _averageInflowRate As Double = _appliedVolume / _cutoffTime

        Dim _maxTime As Double = _cutoffTime
        Dim _maxFlowRate As Double = _inflowRate

        Dim _volumeLabel As String = String.Empty
        Dim _avgInflowLabel As String = String.Empty

        ' Get drawing tools
        Dim _black As Pen = BlackPen1()
        Dim _grayBrush As SolidBrush = DarkGraySolidBrush()

        ' Highlight color is halfway between White and Background colors
        Dim _r As Integer = CInt((Color.White.R / 2) + (Me.BackColor.R / 2))
        Dim _g As Integer = CInt((Color.White.G / 2) + (Me.BackColor.G / 2))
        Dim _b As Integer = CInt((Color.White.B / 2) + (Me.BackColor.B / 2))
        Dim _highlight As Brush = New SolidBrush(Color.FromArgb(_r, _g, _b))

        ' Create a bitmap for the graphics
        Dim _bitmap As Bitmap = New Bitmap(_pictureBox.Width, _pictureBox.Height)
        Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

        ' Fill the bitmap with the background color
        _graphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, _pictureBox.Width, _pictureBox.Height)
        '
        ' Define & draw the Axes for the Hydrograph
        '
        Dim _offset As Integer = 16 ' Offset into bitmap for axes
        Dim _quadrant As QuadrantSelections = QuadrantSelections.UpperRight

        ' X-axis information (Time)
        Dim _xAxis As Axis

        ' Y-axis information (Flow Rate)
        Dim _yAxis As Axis
        _yAxis.AxisLabel = mDictionary.tFlowRate.Translated
        _yAxis.MaxValue = _maxFlowRate

        If (mInflowManagement.InflowRateProperty.ToBeCalculated) Then
            _yAxis.MaxLabel = "TBD"
        Else
            _yAxis.MaxLabel = FlowRateString(_maxFlowRate, 0)
        End If
        '
        ' Define & draw the Hydrograph 'curve'
        '
        Dim x1, x2 As Double
        Dim _xPoints As ArrayList = New ArrayList
        Dim _yPoints As ArrayList = New ArrayList

        ' Graphics is dependent on the Cutback & Cutoff methods
        Select Case _cutoffMethod

            Case Globals.CutoffMethods.TimeBased

                Select Case _cutbackMethod

                    Case CutbackMethods.NoCutback
                        x1 = 0.0

                    Case CutbackMethods.TimeBased
                        x1 = _cutbackTime

                    Case CutbackMethods.DistanceBased
                        x1 = _cutoffTime * 0.5

                End Select

                x2 = _cutoffTime

                ' Define X axis
                _xAxis.AxisLabel = mDictionary.tTime.Translated
                _xAxis.MaxValue = _maxTime

                If (mInflowManagement.CutoffTimeProperty.ToBeCalculated) Then
                    _xAxis.MaxLabel = "TBD"
                Else
                    _xAxis.MaxLabel = TimeString(_maxTime, 0)
                End If

            Case Else ' Assume distance based

                Select Case _cutbackMethod

                    Case CutbackMethods.NoCutback
                        x1 = 0.0

                    Case CutbackMethods.TimeBased
                        x1 = 0.0

                    Case CutbackMethods.DistanceBased
                        x1 = _cutbackLocation

                End Select

                x2 = _cutoffLocation

                ' Define X axis
                _xAxis.AxisLabel = mDictionary.tDistance.Translated
                _xAxis.MaxValue = _length

                If (mInflowManagement.Unit.SystemGeometryRef.LengthProperty.ToBeCalculated) Then
                    _xAxis.MaxLabel = "TBD"
                Else
                    _xAxis.MaxLabel = mInflowManagement.Unit.SystemGeometryRef.Length.ValueString
                End If

        End Select

        DrawAxes(_bitmap, _quadrant, _xAxis, _yAxis, _offset, Me.Font)

        _xPoints.Add(0.0)
        _yPoints.Add(_inflowRate * 0.9)

        If (0.0 < x1) Then
            _xPoints.Add(x1 * 0.97)
            _yPoints.Add(_inflowRate * 0.9)

            _xPoints.Add(x1 * 0.97)
            _yPoints.Add(_cutbackRate * 0.9)
        End If

        _xPoints.Add(x2 * 0.97)
        _yPoints.Add(_yPoints(_yPoints.Count - 1))

        _xPoints.Add(x2 * 0.97)
        _yPoints.Add(0.0)

        ' Draw the Hydrograph
        If ((_cutoffMethod = Globals.CutoffMethods.TimeBased) _
          And (_cutbackMethod = Globals.CutbackMethods.DistanceBased)) Then
            Dim _x1 As Double = CDbl(_xPoints(1)) * 0.9
            Dim _y1 As Double = CDbl(_yPoints(1))
            Dim _x2 As Double = CDbl(_xPoints(2)) * 1.1
            Dim _y2 As Double = CDbl(_yPoints(2))
            FillRect(_bitmap, _quadrant, _highlight, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
            DrawRect(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
        End If

        If (1 < _yPoints.Count) Then
            For _line As Integer = 0 To _yPoints.Count - 2
                Dim _x1 As Double = CDbl(_xPoints(_line))
                Dim _y1 As Double = CDbl(_yPoints(_line))
                Dim _x2 As Double = CDbl(_xPoints(_line + 1))
                Dim _y2 As Double = CDbl(_yPoints(_line + 1))
                DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
            Next _line
        End If
        '
        ' Update the Inflow Mass Balance data
        '
        DepthAppliedControl.Text = "TBD"

        Dim _area As Double = mSystemGeometry.Area

        If (0 < _area) Then
            If Not (mSystemGeometry.LengthProperty.ToBeCalculated) Then
                If Not (mSystemGeometry.WidthProperty.ToBeCalculated) Then
                    Dim _appliedDepth As Double = _appliedVolume / _area
                    Dim _infiltratedDepth As Double = _infiltratedVolume / _area
                    DepthAppliedControl.Text = DepthString(_appliedDepth, 0)
                    AppliedDepthLabel.Text = mDictionary.tDepthApplied.Translated & " (Dapp) = "
                    AppliedDepthValue.Text = DepthString(_appliedDepth, 0)
                    InfiltratedDepthControl.Text = DepthString(_infiltratedDepth, 0)
                End If
            End If
        End If
        '
        ' Add water volume data to graph
        '
        If (_xAxis.MaxLabel = "TBD") Then
            _volumeLabel = mDictionary.tInflow.Translated + ": TBD"
            _avgInflowLabel = "Qavg: TBD"
        Else
            If (0.0 < _appliedVolume) Then
                _volumeLabel = mDictionary.tInflow.Translated + ": " + FieldVolumeString(_appliedVolume, 0)

                _avgInflowLabel = "Qavg: " + FlowRateString(_averageInflowRate, 0)
            End If
        End If

        Dim _size As SizeF = _graphics.MeasureString(_volumeLabel, Me.Font)
        _graphics.DrawString(_volumeLabel, Me.Font, _grayBrush, _
                            _bitmap.Width - _size.Width + 6, 0)

        If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            If Not (_avgInflowLabel Is Nothing) Then
                _size = _graphics.MeasureString(_avgInflowLabel, Me.Font)
                _graphics.DrawString(_avgInflowLabel, Me.Font, _grayBrush, _
                                    _offset + 16, _bitmap.Height - (3 * _size.Height))
            End If
        End If
        '
        ' Copy the new bitmap into the image (this prevents flicker)
        '
        If (_pictureBox.Image IsNot Nothing) Then
            _pictureBox.Image.Dispose()
            _pictureBox.Image = Nothing
        End If

        _pictureBox.Image = _bitmap

    End Sub
    '
    ' Graphics for Tabulated Inflow
    '
    Private Sub GraphTabulatedInflow(ByVal _pictureBox As PictureBox, ByVal _tabulatedInflow As DataTable)

        ' Get the Tabulated Inflow values
        Dim _length As Double = mSystemGeometry.Length.Value
        Dim _width As Double = mSystemGeometry.Width.Value

        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
            _width = mSystemGeometry.FurrowSpacing.Value
        End If

        Dim _maxInflowTime As Double = DataColumnMax(_tabulatedInflow, nTimeX)
        Dim _maxInflow As Double = DataColumnMax(_tabulatedInflow, nInflowX)

        Dim _appliedVolume As Double = mInflowManagement.AppliedVolume
        Dim _infiltratedVolume As Double = mInflowManagement.InfiltratedVolume

        Dim _averageInflowRate As Double = _appliedVolume / _maxInflowTime

        Dim _maxTime As Double = _maxInflowTime
        Dim _maxFlowRate As Double = _maxInflow

        ' Get drawing tools
        Dim _black As Pen = BlackPen1()
        Dim _grayBrush As SolidBrush = DarkGraySolidBrush()

        ' Create a bitmap for the graphics
        Dim _bitmap As Bitmap = New Bitmap(_pictureBox.Width, _pictureBox.Height)
        Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

        ' Fill the bitmap with the background color
        _graphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, _pictureBox.Width, _pictureBox.Height)
        '
        ' Define & draw the Axes for the Hydrograph
        '
        Dim _offset As Integer = 16 ' Offset into bitmap for axes
        Dim _quadrant As QuadrantSelections = QuadrantSelections.UpperRight

        ' X-axis information (Time)
        Dim _xAxis As Axis
        _xAxis.AxisLabel = mDictionary.tTime.Translated
        _xAxis.MaxValue = _maxTime
        _xAxis.MaxLabel = TimeString(_maxTime, 0)

        ' Y-axis information (Inflow Rate)
        Dim _yAxis As Axis
        _yAxis.AxisLabel = mDictionary.tFlowRate.Translated
        _yAxis.MaxValue = _maxFlowRate
        _yAxis.MaxLabel = FlowRateString(_maxFlowRate, 0)

        DrawAxes(_bitmap, _quadrant, _xAxis, _yAxis, _offset, Me.Font)
        '
        ' Define & draw the Tabulated Inflow 'curve'
        '
        Dim _xPoints As ArrayList = New ArrayList
        Dim _yPoints As ArrayList = New ArrayList

        Dim _time1 As Double
        Dim _flow1 As Double

        If Not (_tabulatedInflow Is Nothing) Then

            _time1 = CDbl(_tabulatedInflow.Rows(0).Item(nTimeX))
            _flow1 = CDbl(_tabulatedInflow.Rows(0).Item(nInflowX))

            _xPoints.Add(_time1 * 0.97)
            _yPoints.Add(_flow1 * 0.9)

            For _idx As Integer = 1 To _tabulatedInflow.Rows.Count - 1

                Dim _time2 As Double = CDbl(_tabulatedInflow.Rows(_idx).Item(nTimeX))
                Dim _flow2 As Double = CDbl(_tabulatedInflow.Rows(_idx).Item(nInflowX))

                _xPoints.Add(_time2 * 0.97)
                _yPoints.Add(_flow2 * 0.9)

                _time1 = _time2
                _flow1 = _flow2
            Next
        End If

        If Not (0.0 = _flow1) Then
            _xPoints.Add(_time1 * 0.97)
            _yPoints.Add(0.0 * 0.9)
        End If

        For _line As Integer = 0 To _yPoints.Count - 2
            Dim _x1 As Double = CDbl(_xPoints(_line))
            Dim _y1 As Double = CDbl(_yPoints(_line))
            Dim _x2 As Double = CDbl(_xPoints(_line + 1))
            Dim _y2 As Double = CDbl(_yPoints(_line + 1))
            DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
        Next _line
        '
        ' Update the Inflow Mass Balance data
        '
        DepthAppliedControl.Text = "TBD"

        Dim _area As Double = mSystemGeometry.Area

        If (0 < _area) Then
            If Not (mSystemGeometry.LengthProperty.ToBeCalculated) Then
                If Not (mSystemGeometry.WidthProperty.ToBeCalculated) Then
                    Dim _appliedDepth As Double = _appliedVolume / _area
                    Dim _infiltratedDepth As Double = _infiltratedVolume / _area
                    DepthAppliedControl.Text = DepthString(_appliedDepth, 0)
                    AppliedDepthLabel.Text = mDictionary.tDepthApplied.Translated & " (Dapp) = "
                    AppliedDepthValue.Text = DepthString(_appliedDepth, 0)
                    InfiltratedDepthControl.Text = DepthString(_infiltratedDepth, 0)
                End If
            End If
        End If
        '
        ' Add water volume data to graph
        '
        If (0.0 < _appliedVolume) Then

            Dim _volumeLabel As String = mDictionary.tInflow.Translated + ": " + FieldVolumeString(_appliedVolume, 0)

            Dim _avgInflowLabel As String = "Qavg: " + FlowRateString(_averageInflowRate, 0)

            Dim _size As SizeF = _graphics.MeasureString(_volumeLabel, Me.Font)
            _graphics.DrawString(_volumeLabel, Me.Font, _grayBrush, _
                                _bitmap.Width - _size.Width + 6, 0)

            _size = _graphics.MeasureString(_avgInflowLabel, Me.Font)
            _graphics.DrawString(_avgInflowLabel, Me.Font, _grayBrush, _
                                _offset + 16, _bitmap.Height - (3 * _size.Height))
        End If
        '
        ' Copy the new bitmap into the image (this prevents flicker)
        '
        If (_pictureBox.Image IsNot Nothing) Then
            _pictureBox.Image.Dispose()
            _pictureBox.Image = Nothing
        End If

        _pictureBox.Image = _bitmap

    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated

        Select Case reason
            Case WinSRFR.Reasons.Language
                UpdateLanguage()
        End Select
    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        '
        ' Adjust contained controls to match new height & width
        '

        ' Inflow
        Me.InflowGroupBox.Height = Me.Height - Me.InflowGroupBox.Location.Y - 5
        Me.TabulatedInflowPanel.Height = Me.InflowGroupBox.Height - Me.TabulatedInflowPanel.Location.Y - 5
        Me.TabulatedInflowControl.Height = Me.TabulatedInflowPanel.Height - Me.TabulatedInflowControl.Location.Y - 5

        ' Graph
        Dim graphLoc As Point = New Point(Me.HydrographGraphicsPanel.Location.X, 2)
        Me.HydrographGraphicsPanel.Location = graphLoc

        Dim graphHeight As Integer = ((Me.Height - Me.InflowStatsPanel.Height) / 2) - 4
        Dim graphWidth As Integer = Me.Width - graphLoc.X

        Me.HydrographGraphicsPanel.Height = graphHeight - 4
        Me.HydrographGraphicsPanel.Width = graphWidth - 3

        Me.InflowHydrograph.Location = New Point(2, 2)
        Me.InflowHydrograph.Height = graphHeight - 6
        Me.InflowHydrograph.Width = graphWidth - 6
        UpdateGraphics()

        ' Statistics (Height is fixed)
        Dim statsLoc As Point = New Point(Me.InflowStatsPanel.Location.X, graphLoc.Y + graphHeight + 2)
        Me.InflowStatsPanel.Location = statsLoc
        Me.InflowStatsPanel.Width = graphWidth

        ' Instructions
        Dim instrLoc As Point = Me.InflowInstructions.Location
        Me.InflowInstructions.Location = New Point(instrLoc.X, statsLoc.Y + Me.InflowStatsPanel.Height + 2)
        Me.InflowInstructions.Height = graphHeight - 4
        Me.InflowInstructions.Width = graphWidth - 3

    End Sub

    Private Sub TabulatedInflowControl_ControlValueChanged() _
    Handles TabulatedInflowControl.ControlValueChanged
        UpdateGraphics()
    End Sub

#End Region

End Class
