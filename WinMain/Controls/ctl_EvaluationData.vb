
'*************************************************************************************************************
' ctl_EvaluationData - UI for viewing & editing the Irrigation Evaluation data for:
'
'   * Elliot-Walker Two-Point Analysis
'   * Erosion Parameter Estimation
'*************************************************************************************************************
Imports DataStore
Imports PrintingUI

Public Class ctl_EvaluationData
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeEvaluationDataControl()

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
    Friend WithEvents TwoPointAdvanceControl As WinMain.ctl_TwoPointAdvance
    Friend WithEvents InfiltratedProfileControl As WinMain.ctl_InfiltratedProfile
    Friend WithEvents AdvanceRecessionControl As WinMain.ctl_AdvanceRecession
    Friend WithEvents ErosionControl As WinMain.ctl_Erosion
    Friend WithEvents StationMeasurements As WinMain.ctl_StationMeasurements
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TwoPointAdvanceControl = New WinMain.ctl_TwoPointAdvance
        Me.InfiltratedProfileControl = New WinMain.ctl_InfiltratedProfile
        Me.AdvanceRecessionControl = New WinMain.ctl_AdvanceRecession
        Me.ErosionControl = New WinMain.ctl_Erosion
        Me.StationMeasurements = New WinMain.ctl_StationMeasurements
        Me.SuspendLayout()
        '
        'TwoPointAdvanceControl
        '
        Me.TwoPointAdvanceControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TwoPointAdvanceControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TwoPointAdvanceControl.Location = New System.Drawing.Point(0, 0)
        Me.TwoPointAdvanceControl.Name = "TwoPointAdvanceControl"
        Me.TwoPointAdvanceControl.Size = New System.Drawing.Size(780, 430)
        Me.TwoPointAdvanceControl.TabIndex = 0
        '
        'InfiltratedProfileControl
        '
        Me.InfiltratedProfileControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InfiltratedProfileControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltratedProfileControl.Location = New System.Drawing.Point(0, 0)
        Me.InfiltratedProfileControl.Name = "InfiltratedProfileControl"
        Me.InfiltratedProfileControl.Size = New System.Drawing.Size(780, 430)
        Me.InfiltratedProfileControl.TabIndex = 1
        '
        'AdvanceRecessionControl
        '
        Me.AdvanceRecessionControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvanceRecessionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvanceRecessionControl.Location = New System.Drawing.Point(0, 0)
        Me.AdvanceRecessionControl.Name = "AdvanceRecessionControl"
        Me.AdvanceRecessionControl.Size = New System.Drawing.Size(780, 430)
        Me.AdvanceRecessionControl.TabIndex = 3
        '
        'ErosionControl
        '
        Me.ErosionControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ErosionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErosionControl.Location = New System.Drawing.Point(0, 0)
        Me.ErosionControl.Name = "ErosionControl"
        Me.ErosionControl.Size = New System.Drawing.Size(780, 430)
        Me.ErosionControl.TabIndex = 4
        '
        'StationMeasurements
        '
        Me.StationMeasurements.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StationMeasurements.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StationMeasurements.Location = New System.Drawing.Point(0, 0)
        Me.StationMeasurements.Name = "StationMeasurements"
        Me.StationMeasurements.Size = New System.Drawing.Size(780, 430)
        Me.StationMeasurements.TabIndex = 5
        '
        'ctl_EvaluationData
        '
        Me.Controls.Add(Me.TwoPointAdvanceControl)
        Me.Controls.Add(Me.InfiltratedProfileControl)
        Me.Controls.Add(Me.ErosionControl)
        Me.Controls.Add(Me.AdvanceRecessionControl)
        Me.Controls.Add(Me.StationMeasurements)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_EvaluationData"
        Me.Size = New System.Drawing.Size(780, 430)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "
    '
    ' Control heights for re-sizing
    '
    Private mMinEvaluationDataHeight As Integer
    Private mEvaluationDataHeight As Integer

    Private mControlHeightsSaved As Boolean = False
    Private mLinkedToModel As Boolean = False

#End Region

#Region " Initialization "

    Private Sub InitializeEvaluationDataControl()
        '
        ' Save initial control sizing for later re-sizing
        '
        mMinEvaluationDataHeight = MyBase.Height
        mEvaluationDataHeight = MyBase.Height
        mControlHeightsSaved = True

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Field data
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm
    Private mWinSRFR As WinSRFR

    Private WithEvents mEventCriteria As EventCriteria
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mSoilCropProperties As SoilCropProperties
    Private WithEvents mInflowManagement As InflowManagement

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    Private mMyStore As DataStore.ObjectNode
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal worldWindow As WorldWindow)

        Debug.Assert(Not (_unit Is Nothing), "Unit is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mEventCriteria = mUnit.EventCriteriaRef
        mSystemGeometry = mUnit.SystemGeometryRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mInflowManagement = mUnit.InflowManagementRef

        mWorldWindow = worldWindow

        mMyStore = mUnit.MyStore

        ' Link contained data controls
        Me.InfiltratedProfileControl.LinkToModel(mUnit, mWorldWindow)
        Me.AdvanceRecessionControl.LinkToModel(mUnit, mWorldWindow)
        Me.TwoPointAdvanceControl.LinkToModel(mUnit, mWorldWindow)
        Me.ErosionControl.LinkToModel(mUnit, mWorldWindow, Nothing)
        Me.StationMeasurements.LinkToModel(mUnit, mWorldWindow)

        ' Update this control's User Interface
        UpdateUI()

        mLinkedToModel = True

    End Sub
    '
    ' Update the UI when Event Criteria changes
    '
    Private Sub EventCriteria_PropertyChanged(ByVal _reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyChanged
        If Not (mWorldWindow.Running) Then
            UpdateUI()
        End If
    End Sub
    '
    ' Update the UI when System Geometry changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyChanged
        If Not (mWorldWindow.Running) Then
            UpdateUI()
        End If
    End Sub
    '
    ' Update the UI when Soil Crop Properties changes
    '
    Private Sub SoilCropProperties_PropertyChanged(ByVal _reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyChanged
        If Not (mWorldWindow.Running) Then
            UpdateUI()
        End If
    End Sub
    '
    ' Update the UI when Inflow Management data changes
    '
    Private Sub InflowManagement_PropertyChanged(ByVal _reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyChanged
        If Not (mWorldWindow.Running) Then
            UpdateUI()
        End If
    End Sub
    '
    ' Update the graphics when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update the UI for appropriate Event Analysis
    '
    Public Sub UpdateUI()

        ' Display appropriate Analysis panel
        If Not (mEventCriteria Is Nothing) Then
            Select Case (mEventCriteria.EventAnalysisType.Value)

                Case EventAnalysisTypes.InfiltratedProfileAnalysis

                    Me.TwoPointAdvanceControl.Hide()
                    Me.AdvanceRecessionControl.Hide()
                    Me.ErosionControl.Hide()
                    Me.StationMeasurements.Hide()

                    Me.InfiltratedProfileControl.Show()
                    Me.InfiltratedProfileControl.UpdateUI()

                Case EventAnalysisTypes.MerriamKellerAnalysis

                    Me.InfiltratedProfileControl.Hide()
                    Me.TwoPointAdvanceControl.Hide()
                    Me.ErosionControl.Hide()
                    Me.StationMeasurements.Hide()

                    Me.AdvanceRecessionControl.Show()
                    Me.AdvanceRecessionControl.UpdateUI()

                Case EventAnalysisTypes.TwoPointAnalysis

                    Me.InfiltratedProfileControl.Hide()
                    Me.AdvanceRecessionControl.Hide()
                    Me.ErosionControl.Hide()
                    Me.StationMeasurements.Hide()

                    Me.TwoPointAdvanceControl.Show()
                    Me.TwoPointAdvanceControl.UpdateUI()

                Case EventAnalysisTypes.ErosionAnalysis

                    Me.InfiltratedProfileControl.Hide()
                    Me.AdvanceRecessionControl.Hide()
                    Me.TwoPointAdvanceControl.Hide()
                    Me.StationMeasurements.Hide()

                    Me.ErosionControl.Show()
                    Me.ErosionControl.UpdateUI()

                Case EventAnalysisTypes.EvalueAnalysis

                    Me.InfiltratedProfileControl.Hide()
                    Me.AdvanceRecessionControl.Hide()
                    Me.TwoPointAdvanceControl.Hide()
                    Me.ErosionControl.Hide()

                    Me.StationMeasurements.Show()

                Case Else
                    Debug.Assert(False, "Event Analysis not supported")
            End Select
        End If

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        ' Skip premature Resize events
        If (mControlHeightsSaved And mLinkedToModel) Then

            Select Case (mEventCriteria.EventAnalysisType.Value)

                Case EventAnalysisTypes.InfiltratedProfileAnalysis
                    Me.InfiltratedProfileControl.ResizeUI()

                Case EventAnalysisTypes.MerriamKellerAnalysis
                    Me.AdvanceRecessionControl.ResizeUI()

                Case EventAnalysisTypes.TwoPointAnalysis
                    Me.TwoPointAdvanceControl.ResizeUI()

                Case EventAnalysisTypes.ErosionAnalysis

                Case EventAnalysisTypes.EvalueAnalysis
                    Me.StationMeasurements.ResizeUI()

                Case Else
                    Debug.Assert(False, "Event Analysis not supported")
            End Select

        End If

    End Sub

#End Region

End Class
