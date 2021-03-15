
'*************************************************************************************************************
' Class InfiltrationEstimator - allow user to estimate Infiltration Parameters while matching known
'                               infiltration depth hydrograph
'*************************************************************************************************************
Imports Srfr

Imports DataStore

Imports System.Collections.Generic

Public Class InfiltrationEstimator

#Region " Member Data "
    '
    ' SRFR access
    '
    Private mSrfrAPI As Srfr.SrfrAPI
    Private mIrrigation As Srfr.Irrigation
    '
    ' User selections
    '
    Private mDistances As List(Of Double)
    '
    ' Data
    '
    Private mMaxX As Double

    Private mMinY As Double
    Private mMaxY As Double
    '
    ' Axis labels
    '
    Private mXlabel As String

    Private mYminLabel As String
    Private mYmaxLabel As String
    '
    ' Drawing Tools 
    '
    Private mCanvas As Bitmap
    Private mCanvas2 As Bitmap
    Private Function CloneCanvas() As Bitmap
        If (mCanvas2 IsNot Nothing) Then           ' Properly dispose of old bitmap first
            mCanvas2.Dispose()
            mCanvas2 = Nothing
        End If
        mCanvas2 = CType(mCanvas.Clone, Bitmap)     ' Clone original canvas for highlights
        Return mCanvas2
    End Function

    Private PenBlack1 As Pen = New Pen(Color.Black, 1)
    Private PenBlack2 As Pen = New Pen(Color.Black, 2)
    Private PenDarkGray1 As Pen = New Pen(Color.DarkGray, 1)
    Private PenDarkGray2 As Pen = New Pen(Color.DarkGray, 2)
    Private PenDarkBlue1 As Pen = New Pen(Color.DarkBlue, 1)
    Private PenDarkBlue2 As Pen = New Pen(Color.DarkBlue, 2)

    Private BrushBlack As Brush = New SolidBrush(System.Drawing.Color.Black)
    Private BrushDarkGray As Brush = New SolidBrush(System.Drawing.Color.DarkGray)
    Private BrushLightGray As Brush = New SolidBrush(System.Drawing.Color.LightGray)
    Private BrushStreamBlue As Brush = New SolidBrush(System.Drawing.Color.CornflowerBlue)

    Private Vertical As New StringFormat(StringFormatFlags.DirectionVertical)
    '
    ' Graphics
    '
    Private mGraphics As Graphics
    Private mWinRectF As RectangleF
    Private mViewRect As Rectangle

    Private mRegionWidth As Integer
    Private mRegionHeight As Integer

    Private mRegion As Rectangle
    Private mGraph As XYGraph
    '
    ' Clipboard support
    '
    Protected mClipboardText As String
    '
    ' Misc.
    '
    Private mDictionary As Dictionary = Dictionary.Instance

    Private mInitializing As Boolean = False

#End Region

#Region " Properties "

#Region " General "

    Public Enum InfiltrationTypes
        GreenAmpt
        WarrickGreenAmpt
    End Enum

    Private mInfiltrationType As InfiltrationTypes = InfiltrationTypes.GreenAmpt
    Public Property InfiltrationType() As InfiltrationTypes
        Get
            Return mInfiltrationType
        End Get
        Set(ByVal value As InfiltrationTypes)
            mInfiltrationType = value
        End Set
    End Property

#End Region

#Region " Green-Ampt "

    Public Enum GA_Estimations
        GA_hf
        GA_Ks
    End Enum

    Private mGA_Estimation As GA_Estimations = GA_Estimations.GA_Ks
    Public Property GA_Estimation() As GA_Estimations
        Get
            Return mGA_Estimation
        End Get
        Set(ByVal value As GA_Estimations)
            mGA_Estimation = value
        End Set
    End Property

    Private mGA_ThetaS As Double
    Public Property GA_ThetaS() As Double
        Get
            Return mGA_ThetaS
        End Get
        Set(ByVal value As Double)
            mGA_ThetaS = value
        End Set
    End Property

    Private mGA_Theta0 As Double
    Public Property GA_Theta0() As Double
        Get
            Return mGA_Theta0
        End Get
        Set(ByVal value As Double)
            mGA_Theta0 = value
        End Set
    End Property

    Private mGA_hf As Double
    Public Property GA_hf() As Double
        Get
            Return mGA_hf
        End Get
        Set(ByVal value As Double)
            mGA_hf = value
        End Set
    End Property

    Private mGA_Ks As Double
    Public Property GA_Ks() As Double
        Get
            Return mGA_Ks
        End Get
        Set(ByVal value As Double)
            mGA_Ks = value
        End Set
    End Property

    Private mGA_c As Double
    Public Property GA_c() As Double
        Get
            Return mGA_c
        End Get
        Set(ByVal value As Double)
            mGA_c = value
        End Set
    End Property

#End Region

#Region " Warrick Green-Ampt "

    Public Enum WGA_Estimations
        WGA_hf
        WGA_Ks
    End Enum

    Private mWGA_Estimation As WGA_Estimations = WGA_Estimations.WGA_Ks
    Public Property WGA_Estimation() As WGA_Estimations
        Get
            Return mWGA_Estimation
        End Get
        Set(ByVal value As WGA_Estimations)
            mWGA_Estimation = value
        End Set
    End Property

    Private mWGA_ThetaS As Double
    Public Property WGA_ThetaS() As Double
        Get
            Return mWGA_ThetaS
        End Get
        Set(ByVal value As Double)
            mWGA_ThetaS = value
        End Set
    End Property

    Private mWGA_Theta0 As Double
    Public Property WGA_Theta0() As Double
        Get
            Return mWGA_Theta0
        End Get
        Set(ByVal value As Double)
            mWGA_Theta0 = value
        End Set
    End Property

    Private mWGA_hf As Double
    Public Property WGA_hf() As Double
        Get
            Return mWGA_hf
        End Get
        Set(ByVal value As Double)
            mWGA_hf = value
        End Set
    End Property

    Private mWGA_Ks As Double
    Public Property WGA_Ks() As Double
        Get
            Return mWGA_Ks
        End Get
        Set(ByVal value As Double)
            mWGA_Ks = value
        End Set
    End Property

    Private mWGA_c As Double
    Public Property WGA_c() As Double
        Get
            Return mWGA_c
        End Get
        Set(ByVal value As Double)
            mWGA_c = value
        End Set
    End Property

#End Region

#End Region

#Region " Methods "

#Region " Initialization "

    Public Sub New(ByVal srfr As Srfr.SrfrAPI)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mSrfrAPI = srfr
        mIrrigation = mSrfrAPI.Irrigation

        Me.Text = mDictionary.ControlText(Me)

        InitFieldLocationList()

        UpdateUI()

    End Sub

    Public Sub InitUI(ByVal SoilCropProperties As SoilCropProperties, ByVal MyStore As DataStore.ObjectNode)
        If ((SoilCropProperties IsNot Nothing) And (MyStore IsNot Nothing)) Then
            mInitializing = True

            Me.GA_hf_Estimate.LinkToModel(MyStore, SoilCropProperties.WettingFrontPressureHeadGA_Property)
            Me.GA_Ks_Estimate.LinkToModel(MyStore, SoilCropProperties.HydraulicConductivityGA_Property)
            Me.WGA_hf_Estimate.LinkToModel(MyStore, SoilCropProperties.WettingFrontPressureHeadWGA_Property)
            Me.WGA_Ks_Estimate.LinkToModel(MyStore, SoilCropProperties.HydraulicConductivityWGA_Property)

            mInitializing = False
        End If
    End Sub

    Private Sub InitFieldLocationList()
        If (mIrrigation IsNot Nothing) Then
            If (mDistances IsNot Nothing) Then
                mDistances.Clear()
                mDistances = Nothing
            End If
            mDistances = New List(Of Double)

            Dim mLoc As Double = mIrrigation.XadvMax / 2.0      ' halfway to max advance distance
            Dim dLoc As Double = Double.MaxValue

            Dim tStep As Timestep = mIrrigation.LastTimestep
            Dim tdx As Integer = 0
            Dim mdx As Integer = 0

            Me.FieldLocation.Items.Clear()
            For Each tNode As Srfr.Node In tStep.Nodes
                mDistances.Add(tNode.X)
                Dim dist As String = LengthString(tNode.X)
                Me.FieldLocation.Items.Add(dist)

                If (dLoc > Math.Abs(mLoc - tNode.X)) Then
                    dLoc = Math.Abs(mLoc - tNode.X)
                    mdx = tdx
                End If
                tdx += 1
            Next tNode

            Me.FieldLocation.SelectedIndex = mdx
        End If
    End Sub

#End Region

#Region " General "

    Public Sub UpdateUI()

        If Not (mInitializing) Then
            Select Case (mInfiltrationType)
                Case InfiltrationTypes.GreenAmpt

                    Me.WarrickGreenAmptPanel.Hide()
                    Me.GreenAmptPanel.Show()
                    Me.UpdateGreenAmpt()

                Case InfiltrationTypes.WarrickGreenAmpt

                    Me.GreenAmptPanel.Hide()
                    Me.WarrickGreenAmptPanel.Show()
                    Me.UpdateWarrickGreenAmpt()

            End Select

            UpdateGraphics()
        End If

    End Sub

    Public Sub UpdateGraphics()
        Try
            ' Create canvas (bitmap) & graph regions (i.e. areas within bitmap) to draw on
            mCanvas = New Bitmap(InfiltrationGraphics.Width, InfiltrationGraphics.Height)
            mGraphics = Graphics.FromImage(mCanvas)

            mRegionWidth = mCanvas.Width
            mRegionHeight = mCanvas.Height
            mRegion = New Rectangle(0, 0, mRegionWidth, mRegionHeight)

            mGraph = New XYGraph(mCanvas, mRegion, False, True)

            If (mIrrigation IsNot Nothing) Then
                '
                ' Start with selected "Zwp" hydrograph from Merriam-Keller SRFR simulation
                '
                Dim ldx As Integer = Me.FieldLocation.SelectedIndex
                Dim X As Double = mDistances(ldx)
                Dim value As Double

                Dim InfiltrationCurves As DataTable = mIrrigation.Hydrographs("Zwp", X)
                Dim SurfaceFlowDepthCurve As DataTable = mIrrigation.Hydrographs("Y", X)
                Debug.Assert(InfiltrationCurves.Rows.Count = SurfaceFlowDepthCurve.Rows.Count)
                Dim rowCount As Integer = InfiltrationCurves.Rows.Count

                Dim WettedPerimeterCurve As DataTable = Nothing
                If (mInfiltrationType = InfiltrationTypes.WarrickGreenAmpt) Then
                    WettedPerimeterCurve = mIrrigation.Hydrographs("WP", X)
                End If
                '
                ' Add generated 'matching' estimation curve
                '
                InfiltrationCurves.Columns.Add("Estimate", GetType(Double))
                InfiltrationCurves.ExtendedProperties.Add("Curve", 2)
                InfiltrationCurves.ExtendedProperties.Add("Color", Color.Blue)

                Dim Gamma As Double = 1.0
                Dim Tadv As Double = 0.0
                Dim Z As Double = 0.0

                Dim Tau As Double = 0.0
                Dim Tauprev As Double = 0.0
                Dim Z1D As Double = 0.0
                Dim Z1Dprev As Double = 0.0
                Dim AZ As Double = 0.0
                Dim AZprev As Double = 0.0
                Dim WP As Double = 0.0
                Dim WPprev As Double = 0.0
                Dim WPsum As Double = 0.0

                Select Case (mInfiltrationType)
                    Case InfiltrationTypes.GreenAmpt
                        Z1Dprev = mGA_c
                    Case InfiltrationTypes.WarrickGreenAmpt
                        Z1Dprev = mWGA_c
                        AZprev = mWGA_c * mIrrigation.Width
                    Case Else
                        Debug.Assert(False)
                End Select

                For rdx As Integer = 0 To rowCount - 1
                    Dim row As DataRow = InfiltrationCurves.Rows(rdx)
                    Dim T As Double = CDbl(row.Item(0))
                    Dim Y As Double = CDbl(SurfaceFlowDepthCurve.Rows(rdx).Item(1))

                    Tau = 0.0
                    If (0.0 < Y) Then
                        If (Tadv = 0.0) Then
                            Tadv = T
                        End If
                        Tau = T - Tadv
                    End If

                    Dim DTau As Double = Tau - Tauprev

                    Select Case (mInfiltrationType)
                        Case InfiltrationTypes.GreenAmpt

                            Dim SWD As Double = mGA_ThetaS - mGA_Theta0

                            If (0.0 < Y) Then ' there is surface water

                                Z1D = Srfr.SrfrAPI.InfiltrationDepthGA_Explicit(mGA_Ks, SWD, mGA_hf, Y, Tau, Tauprev, Z1Dprev)
                                Z = Z1D

                                Z1Dprev = Z1D

                            ElseIf (0.0 < Tau) Then
                                Z1D = Z1Dprev
                                Z = Z1D
                            End If

                        Case InfiltrationTypes.WarrickGreenAmpt

                            Dim SWD As Double = mWGA_ThetaS - mWGA_Theta0

                            If (0.0 < Y) Then ' there is surface water

                                WP = CDbl(WettedPerimeterCurve.Rows(rdx).Item(1))
                                Dim Wa As Double = WP
                                If (0 < rdx) Then
                                    Wa = (WP + WPprev) / 2.0
                                End If

                                If (WPsum <= 0.0) Then
                                    WPsum = WP * DTau / 2.0
                                Else
                                    WPsum += (WP + WPprev) * DTau / 2.0
                                End If
                                Dim Wr As Double = WPsum
                                If (0.0 < Tau) Then
                                    Wr /= Tau
                                End If

                                Dim h0 As Double = Y

                                ' Variables not used here
                                Dim dWPadY, ZE, dZdT, dAZdY, dAZdT As Double

                                Srfr.SrfrAPI.InfiltrationPropertiesWGA2(Tau, mWGA_c, Gamma, Wa, Wr, dWPadY, SWD, h0, mWGA_hf, mWGA_Ks, _
                                                                        Tauprev, Z1Dprev, AZprev, Z, Z1D, ZE, dZdT, AZ, dAZdY, dAZdT)

                                Z1Dprev = Z1D
                                AZprev = AZ
                                WPprev = WP

                                Z = AZ / mIrrigation.Width

                            End If

                        Case Else
                            Debug.Assert(False)

                    End Select

                    Tauprev = Tau

                    row.Item(2) = Z
                Next rdx

                ' Scale X & Y axis to match Merriam-Keller "Zwp" hydrograph data
                mMaxX = mIrrigation.LastTimestep.T
                mXlabel = HHMMSS(mMaxX)
                mMaxX /= DataStore.SecondsPerHour

                mMinY = DataStore.Utilities.DataColumnMin(InfiltrationCurves, 1)
                mMaxY = DataStore.Utilities.DataColumnMax(InfiltrationCurves, 1)
                mYminLabel = DataStore.DepthString(mMinY)
                mYmaxLabel = DataStore.DepthString(mMaxY)
                mMinY *= DataStore.MillimetersPerMeter
                mMaxY *= DataStore.MillimetersPerMeter

                ' Scale X & Y data
                For Each row As DataRow In InfiltrationCurves.Rows
                    value = CDbl(row.Item(0))
                    row.Item(0) = value / DataStore.SecondsPerHour
                    value = CDbl(row.Item(1))
                    row.Item(1) = value * DataStore.MillimetersPerMeter
                    value = CDbl(row.Item(2))
                    row.Item(2) = value * DataStore.MillimetersPerMeter
                Next row
                '
                ' Load Infiltration Curves into graph and draw them
                '
                Dim windowRectF As RectangleF = New RectangleF(0, CSng(mMinY), CSng(mMaxX), CSng(mMaxY))

                If (0 = mMinY) Then
                    mYminLabel = Nothing
                End If

                mGraph.GraphTable = InfiltrationCurves
                mGraph.Window = windowRectF
                mGraph.MaxX = mMaxX
                mGraph.MinY = mMinY
                mGraph.MaxY = mMaxY
                mGraph.XAxisLabel = "Time"
                mGraph.XAxisLabelMax = mXlabel
                mGraph.YAxisLabelMin = mYminLabel
                mGraph.YAxisLabelMax = mYmaxLabel
                mGraph.ShowXAxisLabel = True
                mGraph.ShowYAxisLabel = True

                mGraph.Title = "Infiltration Depth vs. Time"

                mGraph.DrawGraph()

                ' Display new graph
                If (InfiltrationGraphics.Image IsNot Nothing) Then    ' Properly dispose of old bitmap first
                    InfiltrationGraphics.Image.Dispose()
                    InfiltrationGraphics.Image = Nothing
                End If

                InfiltrationGraphics.Image = mCanvas
                InfiltrationGraphics.Refresh()

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " Green-Ampt "

    Private Sub UpdateGreenAmpt()

        Select Case (mGA_Estimation)
            Case GA_Estimations.GA_hf
                Me.GA_hf_Fixed.Hide()
                Me.GA_Ks_Estimate.Hide()
                Me.GA_Ks_Fixed.Show()
                Me.GA_hf_Estimate.Show()
            Case GA_Estimations.GA_Ks
                Me.GA_Ks_Fixed.Hide()
                Me.GA_hf_Estimate.Hide()
                Me.GA_hf_Fixed.Show()
                Me.GA_Ks_Estimate.Show()
        End Select

    End Sub

#End Region

#Region " Warrick Green-Ampt "

    Private Sub UpdateWarrickGreenAmpt()

        Select Case (mWGA_Estimation)
            Case WGA_Estimations.WGA_hf
                Me.WGA_hf_Fixed.Hide()
                Me.WGA_Ks_Estimate.Hide()
                Me.WGA_Ks_Fixed.Show()
                Me.WGA_hf_Estimate.Show()
            Case WGA_Estimations.WGA_Ks
                Me.WGA_Ks_Fixed.Hide()
                Me.WGA_hf_Estimate.Hide()
                Me.WGA_hf_Fixed.Show()
                Me.WGA_Ks_Estimate.Show()
        End Select

    End Sub

#End Region

#End Region

#Region " Event Handlers "

    Private Sub FieldLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FieldLocation.SelectedIndexChanged
        UpdateUI()
    End Sub

    Private Sub GA_Ks_Estimate_ValueChanged() Handles GA_Ks_Estimate.ValueChanged
        mGA_Ks = GA_Ks_Estimate.Value
        UpdateUI()
    End Sub

    Private Sub GA_hf_Estimate_ValueChanged() Handles GA_hf_Estimate.ValueChanged
        mGA_hf = GA_hf_Estimate.Value
        UpdateUI()
    End Sub

    Private Sub WGA_Ks_Estimate_ValueChanged() Handles WGA_Ks_Estimate.ValueChanged
        mWGA_Ks = WGA_Ks_Estimate.Value
        UpdateUI()
    End Sub

    Private Sub WGA_hf_Estimate_ValueChanged() Handles WGA_hf_Estimate.ValueChanged
        mWGA_hf = WGA_hf_Estimate.Value
        UpdateUI()
    End Sub

    Private Sub OkMatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkMatchButton.Click
        ' Set OK result & close the dialog box
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

#End Region

End Class