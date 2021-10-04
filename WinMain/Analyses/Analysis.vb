
'*************************************************************************************************************
' Class:    Analysis - abstract baseclass for all WinSRFR Analyses
'
' This must inherit baseclass provides data and methods common across all WinSRFR analyses.
' It provides basic support for:
'
'   * Access to Analysis' Unit of data and its sub-elements
'   * Setup/execution warnings & errors
'   * Contour generation
'   * SRFR Simulation execution
'   * HYDRUS Simulation execution
'   * Analysis execution via both UI & Automation
'   * Solution/Results generation
'*************************************************************************************************************
Imports System.Collections.Generic

Imports Srfr.SrfrAPI
Imports Srfr.SolutionModel

Imports HydrusAPI
Imports HydrusAPI.Hydrus1D

Imports DataStore
Imports GraphingUI

Public MustInherit Class Analysis

#Region " Member Data "

#Region " Unit References "
    '
    ' References to the irrigation unit (Basin / Border / Furrow) and its contained objects
    '
    Protected mUnit As Unit

    Protected mUnitControl As UnitControl

    Protected mSystemGeometry As SystemGeometry
    Protected mSoilCropProperties As SoilCropProperties
    Protected mInflowManagement As InflowManagement
    Protected mSurfaceFlow As SurfaceFlow
    Protected mSubsurfaceFlow As SubsurfaceFlow

    Protected mErosion As Erosion
    Protected mFertigation As Fertigation

    Protected mBorderCriteria As BorderCriteria
    Protected mEventCriteria As EventCriteria
    Protected mSrfrCriteria As SrfrCriteria

    Protected mPerformanceResults As PerformanceResults
    Protected mSrfrResults As SrfrResults

    Protected mWinSRFR As WinSRFR
    Protected mWorldWindow As WorldWindow

    Protected mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Protected mDictionary As Dictionary = Dictionary.Instance

    ' Make unit reference available to other SRFR classes
    Friend Function Unit() As Unit
        Return mUnit
    End Function

#End Region

#Region " Unit Parameters "
    '
    ' Common field parameters used by most analyses
    '

    ' System Geometry
    Protected S0 As Double      ' Slope

    ' Soil Crop Properties - Infiltration
    Protected k As Double       ' Kostiakov Parameters
    Protected a As Double
    Protected b As Double
    Protected c As Double

    ' Soil Crop Properties - Roughness
    Protected n As Double       ' Manning n

#End Region

#Region " Warnings "
    '
    ' Warning bit flags (bits 0-9 reserved for Analysis baseclass)
    '
    Public Enum WarningFlags
        ' Run warnings
        AnalysisHasAlreadyBeenRun = 1 << 0
        ' Tabulated Inflow warnings
        CutoffTimeWarning = 1 << 1
        ' Execution warning
        ExecutionWarning = 1 << 9
        VolumeBalanceWarning = 1 << 10
    End Enum

#End Region

#Region " Errors "
    '
    ' Error flags (values 1-99 reserved for Analysis baseclass)
    '
    Public Enum ErrorFlags
        ' Elevation/Slope Table errors
        InvalidElevationTable = 1
        InvalidSlopeTable
        ' Infiltration Parameter errors
        InvalidKostiakovA
        InvalidKostiakovB
        InvalidKostiakovC
        InvalidKostiakovK
        InvalidBranchB
        InvalidSlope
        ' Infiltration Function / Wetted Perimeter Option error(s)
        Infiltration
        InfiltrationParameters
        WettedPerimeterOption
        GreenAmptNotAvailable
        WarrickGreenAmptNotAvailable
        Hydrus1DNotAvailable
        ' Surface Roughness errors
        RoughnessParameter
        ManningN
        ManningCnAn
        SayreAlbertsonChi
        ' Infiltration Function / Roughness Method error(s)
        InvalidNrcsManning
        ' Inflow/Runoff errors
        Inflow
        InflowParameter
        Cablegation
        StandardHydrograph
        Surge
        TabulatedInflow
        Runoff
        TabulatedRunoff
        ' Advance/Recession
        Advance
        Recession
        OpportunityTimes
        ' Surface Flow errors
        TabulatedAdvance
        TabulatedRecession
        TabulatedOpportunity
        MeasurementStations
        FlowDepths
        ' Volume Balance errors
        VolumeBalances
        EstimatedSurfaceVolumes
        MeasuredSurfaceVolumes
        ' Solution Model errors
        KinematicWave
        ZeroInertia
        ' Execution error
        ExecutionError
    End Enum

#End Region

#Region " Error / Warning Display "
    '
    ' Text box for displaying Analysis Errors and/or Warnings
    '
    Protected mErrorWarningDisplay As ErrorRichTextBox
    Public Function ErrorWarningDisplay() As ErrorRichTextBox
        Return mErrorWarningDisplay
    End Function

#End Region

#Region " Contours "
    '
    ' Grid definitions
    '
    Protected mContourGrid As ContourGrid
    Protected mCenterGrid As CenterGrid
    Protected mLineList As ArrayList

    Protected mNumGridCellsX As Integer
    Protected mNumGridCellsY As Integer
    '
    ' Tuning / Solution Point definitions
    '
    Protected mTuningPoint As ContourPoint
    Protected mSolutionPoint As ContourPoint
    '
    ' Contour definitions
    '
    ' Design Contours:
    '   X axis is always length
    '   Y axis is width or flow rate
    '
    ' Operations Contours:
    '   X is cutoff time or cutoff ratio
    '   Y is is width or flow rate
    '
    Protected Const mNumMajor10Levels As Integer = 10
    Protected Const mNumMinor10Levels As Integer = 12

    Protected mMinLength As Double
    Protected mMaxLength As Double
    Protected mLengthRange As Double

    Protected mMinWidth As Double
    Protected mMaxWidth As Double
    Protected mWidthRange As Double

    Protected mMinInflowRate As Double
    Protected mMaxInflowRate As Double
    Protected mInflowRateRange As Double

    Protected mMinCutoffTime As Double
    Protected mMaxCutoffTime As Double
    Protected mCutoffTimeRange As Double

    Protected mMinCutoffRatio As Double
    Protected mMaxCutoffRatio As Double
    Protected mCutoffRatioRange As Double

    ' First value in ContourParameter is non-Y-axis value
    Protected Const sInflowRate As String = "Inflow Rate"
    Protected Const sWidth As String = "Width"
    Public Const ZIndex As Integer = 0

    ' Parameters expressed as Percentage:
    Protected mMajor10PercentValues() As Single = {0.0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9}
    Protected mMinor10PercentValues() As Single = {0.05, 0.15, 0.25, 0.35, 0.45, 0.55, 0.65, 0.75, 0.85, 0.95}

    Protected Const sApplicationEfficiency As String = "Application Efficiency"
    Protected Const sAE As String = "AE"
    Protected Const AeTolerance As Single = 0.0001
    Public Const AeIndex As Integer = 1

    Protected Const sPotentialApplicationEfficiency As String = "Potential Application Efficiency"
    Protected Const sPAE As String = "PAE"
    Protected Const sPAElq As String = "PAElq"
    Protected Const sPAEmin As String = "PAEmin"
    Protected Const PaeTolerance As Single = 0.0001
    Public Const PaeIndex As Integer = 1

    Protected Const sMinimumDistributionUniformity As String = "Minimum Distribution Uniformity"
    Protected Const sDUmin As String = "DUmin"
    Protected Const sLowQuarterDistributionUniformity As String = "Low-Quarter Distribution Uniformity"
    Protected Const sDUlq As String = "DUlq"
    Protected Const DuTolerance As Single = 0.0001
    Public Const DuIndex As Integer = 2

    Protected Const sMinimumAdequacy As String = "Minimum Adequacy"
    Protected Const sADmin As String = "ADmin"
    Protected Const sLowQuarterAdequacy As String = "Low-Quarter Adequacy"
    Protected Const sADlq As String = "ADlq"
    Protected Const ADTolerance As Single = 0.0001
    Public Const AdIndex As Integer = 3

    Protected Const sRunoff As String = "Runoff"
    Protected Const sRO As String = "RO"
    Protected Const RoTolerance As Single = 0.0001
    Public Const RoIndex As Integer = 4

    Protected Const sDeepPercolation As String = "Deep Percolation"
    Protected Const sDP As String = "DP"
    Protected Const DpTolerance As Single = 0.0001
    Public Const DpIndex As Integer = 5

    ' Parameters expressed as Depth:
    Protected mMajor10LevelDapps() As Single = {0.0, 0.08, 0.1, 0.12, 0.14, 0.16, 0.18, 0.2, 0.22, 0.24}
    Protected mMinor10LevelDapps() As Single = {0.05, 0.06, 0.07, 0.09, 0.11, 0.13, 0.15, 0.17, 0.19, 0.21, 0.23, 0.25}

    Protected Const sAppliedDepth As String = "Applied Depth"
    Protected Const sDapp As String = "Dapp"
    Protected Const DappTolerance As Single = 0.01 * OneMillimeter
    Public Const DappIndex As Integer = 6

    Protected mMajor10LevelDlfs() As Single = {0.0, 0.02, 0.04, 0.06, 0.08, 0.1, 0.12, 0.14, 0.16, 0.18}
    Protected mMinor10LevelDlfs() As Single = {0.01, 0.03, 0.05, 0.07, 0.09, 0.11, 0.13, 0.15, 0.17, 0.19, 0.2}

    Protected Const sMinimumDepth As String = "Minimum Depth"
    Protected Const sDmin As String = "Dmin"
    Protected Const sLowQuarterDepth As String = "Low-Quarter Depth"
    Protected Const sDlq As String = "Dlq"
    Protected Const DLfTolerance As Single = 0.01 * OneMillimeter
    Public Const DLfIndex As Integer = 7

    ' Parameters expressed as Time:
    Protected mMajor10TxaValues() As Single = {0 * OneHour, 2 * OneHour, 4 * OneHour, 6 * OneHour, 8 * OneHour,
                                               10 * OneHour, 12 * OneHour, 14 * OneHour, 16 * OneHour, 18 * OneHour}
    Protected mMinor10TxaValues() As Single = {1 * OneHour, 3 * OneHour, 5 * OneHour, 7 * OneHour, 9 * OneHour,
                                               11 * OneHour, 13 * OneHour, 15 * OneHour, 17 * OneHour, 19 * OneHour,
                                               20 * OneHour}

    Protected mMajor10TcoValues() As Single = {0 * OneHour, 1 * OneHour, 2 * OneHour, 3 * OneHour, 4 * OneHour,
                                               5 * OneHour, 6 * OneHour, 7 * OneHour, 8 * OneHour, 9 * OneHour}
    Protected mMinor10TcoValues() As Single = {0.5 * OneHour, 1.5 * OneHour, 2.5 * OneHour, 3.5 * OneHour, 4.5 * OneHour,
                                               5.5 * OneHour, 6.5 * OneHour, 7.5 * OneHour, 8.5 * OneHour, 9.5 * OneHour,
                                               10.5 * OneHour, 11.0 * OneHour, 11.5 * OneHour, 12.0 * OneHour, 12.5 * OneHour}

    Protected Const sMaxAdvanceTime As String = "Max Advance Time"
    Protected Const sTxa As String = "Txa"
    Protected Const TxaTolerance As Double = OneSecond / 10
    Public Const TxaIndex As Integer = 8

    Protected Const sCutoffTime As String = "Cutoff Time"
    Protected Const sTco As String = "Tco"
    Protected Const TcoTolerance As Single = OneSecond / 10
    Public Const TcoIndex As Integer = 9

    ' Parameters expressed as a Ratio:
    Protected mMajor10LevelsRco() As Single = {0.0, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0, 1.5, 2.0}
    Protected mMinor10LevelsRco() As Single = {0.36, 0.35, 0.45, 0.55, 0.65, 0.75, 0.85, 0.95, 1.25, 1.75, 2.25, 2.5}

    Protected Const sCutoffRatio As String = "Cutoff Ratio; distance (<1.0) or time (>1.0)"
    Protected Const sXR As String = "XR"
    Protected Const RcoTolerance As Single = 0.0001
    Public Const RcoIndex As Integer = 10

    Protected mMajor10LevelsCutback() As Single = {0.0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9}
    Protected mMinor10LevelsCutback() As Single = {0.05, 0.15, 0.25, 0.35, 0.45, 0.55, 0.65, 0.75, 0.85, 0.95, 0.99}

    Protected Const sCutbackRatio As String = "Cutback Time Ratio"
    Protected Const sCutback As String = "Cutback"
    Protected Const CutbackTolerance As Single = 0.0001
    Public Const CutbackIndex As Integer = 11

    ' Parameters expressed as Money:
    Protected mMajor10LevelsCost() As Single = {0, 10, 20, 30, 40, 50, 60, 70, 80, 90}
    Protected mMinor10LevelsCost() As Single = {5, 15, 25, 35, 45, 55, 65, 75, 85, 95}

    Protected Const sCost As String = "Cost"
    Protected Const sDollar As String = "$"
    Protected Const CostTolerance As Single = 0.01
    Public Const CostIndex As Integer = 12

#End Region

#Region " Solution "
    '
    ' The Solution is based on the user chosen parameters, perhaps within a contour.  It can be
    ' used to calculate and display an Infiltration Diagram (e.g. Water Distribution Diagram)
    '
    ' Location
    '
    Protected mX As Double
    Protected mY As Double
    '
    ' System Geometry
    '
    Protected mArea As Double
    '
    ' Irrigation parameters
    '
    Protected mCutbackRateRatio As Double
    Protected mCutbackTimeRatio As Double
    Protected mCutbackMethod As CutbackMethods
    Protected mDepthCriterion As InfiltratedDepthCriteria

    Protected mInflowVolume As Double
    Protected mInfiltratedVolume As Double
    Protected mRunoffVolume As Double
    '
    ' Event Analysis parameters
    '
    ' One / Two-Point advance
    Protected mAdvanceTime1 As Double
    Protected mInflowVolume1 As Double
    Protected mSurfaceVolume1 As Double
    Protected mInfiltratedVolume1 As Double

    Protected mAdvanceTime2 As Double
    Protected mInflowVolume2 As Double
    Protected mSurfaceVolume2 As Double
    Protected mInfiltratedVolume2 As Double

    Protected h As Double
    Protected sigmaZ As Double
    '
    ' Advance / Recession
    '
    Protected mTr0 As Double
    Protected mTrL As Double

    Protected mTlag As Double
    Protected Const MinTlag As Double = TenSeconds

    Protected sTlag As Double
    '
    ' Tuning
    '
    Protected mSigmaY As Double
    Protected mPhi0 As Double
    Protected mPhi1 As Double
    Protected mPhi2 As Double
    Protected mPhi3 As Double

    Protected mDeltaTr As Double

    Protected mTcoRatio As Double
    Protected mDepthRatio As Double
    '
    ' Wetted Perimeter
    '
    Private mConvertWP As DialogResult = DialogResult.No
    Private mRatioWP As Double = 1.0

#End Region

#End Region

#Region " Properties "

#Region " Contours "

    '*********************************************************************************************************
    ' Contour grid points
    '
    ' Design Contours:
    '   X axis is always length
    '   Y axis is width or flow rate
    '
    ' Operations Contours:
    '   X is cutoff time or cutoff ratio
    '   Y is is width or flow rate
    '*********************************************************************************************************
    '
    ' Lengths (L)
    '
    Protected mLengths() As Double = {100, 150.0, 200.0, 240.0, 300.0, 400.0, 600.0} ' m
    Protected mNumLengths As Integer = mLengths.Length
    Public Property Lengths() As Double()
        Get
            Return mLengths
        End Get
        Set(ByVal Value As Double())
            mLengths = Value
        End Set
    End Property

    Protected mLengthTolerance As Single = OneCentimeter
    '
    ' Widths (W)
    '
    Protected mWidths() As Double = {50, 100.0, 120.0, 150.0, 200.0, 300.0, 600.0} ' m
    Protected mNumWidths As Integer = mWidths.Length
    Public Property Widths() As Double()
        Get
            Return mWidths
        End Get
        Set(ByVal Value As Double())
            mWidths = Value
        End Set
    End Property

    Protected mWidthTolerance As Single = OneCentimeter
    '
    ' Inflow Rates (Q)
    '
    Protected mInflowRates() As Double = {0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35} ' cms
    Protected mNumInflowRates As Integer = mInflowRates.Length
    Public Property InflowRates() As Double()
        Get
            Return mInflowRates
        End Get
        Set(ByVal Value As Double())
            mInflowRates = Value
        End Set
    End Property

    Protected mInflowRateTolerance As Single = 0.005 * LiterPerSecond
    '
    ' Cutoff Times (Tco)
    '
    Protected mCutoffTimes() As Double = {1 * OneHour, 2 * OneHour, 3 * OneHour, 4 * OneHour,
                                          5 * OneHour, 6 * OneHour, 7 * OneHour, 8 * OneHour} ' sec
    Protected mNumCutoffTimes As Integer = mCutoffTimes.Length
    Public Property CutoffTimes() As Double()
        Get
            Return mCutoffTimes
        End Get
        Set(ByVal Value As Double())
            mCutoffTimes = Value
        End Set
    End Property

    Protected mCutoffTimeTolerance As Single = OneSecond
    '
    ' Cutoff Ratios (XR)
    '
    Protected mCutoffRatios() As Double = {0.6, 0.8, 1.0, 1.2, 1.4, 1.6, 1.8, 2.0}
    Protected mNumCutoffRatios As Integer = mCutoffRatios.Length
    Public Property CutoffRatios() As Double()
        Get
            Return mCutoffRatios
        End Get
        Set(ByVal Value As Double())
            mCutoffRatios = Value
        End Set
    End Property

    Protected mCutoffRatioTolerance As Single = 0.001
    '
    ' XY Tolerances within contour grid
    '
    Protected mXTolerance As Single
    Public Property XTolerance() As Single
        Get
            Return mXTolerance
        End Get
        Set(ByVal Value As Single)
            mXTolerance = Value
        End Set
    End Property

    Protected mYTolerance As Single
    Public Property YTolerance() As Single
        Get
            Return mYTolerance
        End Get
        Set(ByVal Value As Single)
            mYTolerance = Value
        End Set
    End Property
    '
    ' The number of distances (points) to calculate for the Advance, Recession, etc. curves
    '
    Protected Overridable ReadOnly Property NumDistances() As Integer
        Get
            Return 9
        End Get
    End Property
    '
    ' Color levels for contours
    '
    Protected mContourColors() As System.Drawing.Color = ColorScaleLevels
    Public Property ContourColors() As System.Drawing.Color()
        Get
            Return mContourColors
        End Get
        Set(ByVal Value() As System.Drawing.Color)
            mContourColors = Value
        End Set
    End Property
    '
    ' Standared vs. Precision contour selection
    '
    Public Property Precision() As ContourPrecision = ContourPrecision.Standard

#End Region

#Region " Errors & Warnings "

#Region " Class for Error / Warning Item "
    '
    ' An Error or Warning is stored as an object containing its:
    '   Code    - unique code
    '   Count   - number of times it has occurred
    '   ID      - short identification message
    '   Detail  - longer detailed message
    '
    Public Class ErrorWarningItem
        Private mCode As Integer
        Public Property Code() As Integer
            Get
                Return mCode
            End Get
            Set(ByVal Value As Integer)
                mCode = Value
            End Set
        End Property

        Private mCount As Integer
        Public Property Count() As Integer
            Get
                Return mCount
            End Get
            Set(ByVal Value As Integer)
                mCount = Value
            End Set
        End Property

        Public Function IncCount() As Integer
            mCount += 1
            Return Count
        End Function

        Private mID As String
        Public Property ID() As String
            Get
                Return mID
            End Get
            Set(ByVal Value As String)
                mID = Value
            End Set
        End Property

        Private mDetail As String
        Public Property Detail() As String
            Get
                Return mDetail
            End Get
            Set(ByVal Value As String)
                mDetail = Value
            End Set
        End Property

        Public Sub New(ByVal _code As Integer, ByVal _id As String, ByVal _detail As String)
            mCode = _code
            mCount = 1
            mID = _id
            mDetail = _detail
        End Sub
    End Class

#End Region

#Region " Setup Errors "
    '
    ' Errors occur during the setup of a function for execution.
    ' Errors prevent the execution from being run.
    '

    ' Bit-wise error flags
    Protected mSetupErrors As Integer
    Public ReadOnly Property SetupErrors() As Integer
        Get
            Return mSetupErrors
        End Get
    End Property

    ' Array of error items
    Protected mSetupErrorItems As ArrayList
    Public ReadOnly Property SetupErrorItems() As ArrayList
        Get
            Return mSetupErrorItems
        End Get
    End Property

    Public ReadOnly Property SetupErrorCount() As Integer
        Get
            Dim _count As Integer = 0
            For Each _errorItem As ErrorWarningItem In SetupErrorItems
                _count += _errorItem.Count
            Next
            Return _count
        End Get
    End Property

#End Region

#Region " Execution Errors "
    '
    ' Execution Errors occur during the function execution.
    ' Execution Errors indicate the execution results are invalid.
    '

    ' Array of execution error items
    Protected mExecutionErrorItems As ArrayList
    Public ReadOnly Property ExecutionErrorItems() As ArrayList
        Get
            Return mExecutionErrorItems
        End Get
    End Property

    Public ReadOnly Property ExecutionErrorCount() As Integer
        Get
            Dim _count As Integer = 0
            For Each _errorItem As ErrorWarningItem In ExecutionErrorItems
                _count += _errorItem.Count
            Next
            Return _count
        End Get
    End Property

#End Region

#Region " Setup Warnings "
    '
    ' Warnings occur during the setup of a function for execution.
    ' Warning do not prevent the execution from being run but indicate questionable results.
    '

    ' Bit-wise warning flags
    Protected mSetupWarnings As Integer
    Public ReadOnly Property SetupWarnings() As Integer
        Get
            Return mSetupWarnings
        End Get
    End Property

    ' Array of warning items
    Protected mSetupWarningItems As ArrayList
    Public ReadOnly Property SetupWarningItems() As ArrayList
        Get
            Return mSetupWarningItems
        End Get
    End Property

    Public ReadOnly Property SetupWarningCount() As Integer
        Get
            Dim _count As Integer = 0
            For Each _warningItem As ErrorWarningItem In SetupWarningItems
                _count += _warningItem.Count
            Next
            Return _count
        End Get
    End Property

#End Region

#Region " Execution Warnings "
    '
    ' Execution Warnings occur during the function execution.
    ' Execution Warnings indicate the execution results are questionable.
    '

    ' Array of execution warning items
    Protected mExecutionWarningItems As ArrayList
    Public ReadOnly Property ExecutionWarningItems() As ArrayList
        Get
            Return mExecutionWarningItems
        End Get
    End Property

    Public ReadOnly Property ExecutionWarningCount() As Integer
        Get
            Dim _count As Integer = 0
            For Each _warningItem As ErrorWarningItem In ExecutionWarningItems
                _count += _warningItem.Count
            Next
            Return _count
        End Get
    End Property

#End Region

#End Region

#Region " Solution "
    '
    ' The Solution is based on the user chosen parameters, perhaps within a contour.  It can be
    ' used to calculate and display an Infiltration Diagram (e.g. Water Distribution Diagram)
    '
    '
    ' Irrigation parameters
    '
    Protected mLength As Double
    Public ReadOnly Property Length() As Double
        Get
            Return mLength
        End Get
    End Property

    Protected mWidth As Double
    Public ReadOnly Property Width() As Double
        Get
            Return mWidth
        End Get
    End Property

    Protected mFurrowsPerSet As Double = 1
    Public ReadOnly Property FurrowsPerSet As Double
        Get
            Return mFurrowsPerSet
        End Get
    End Property

    Protected mInflowRate As Double
    Public ReadOnly Property InflowRate() As Double
        Get
            Return mInflowRate
        End Get
    End Property

    Protected mCutbackRate As Double
    Public ReadOnly Property CutbackRate() As Double
        Get
            Return mCutbackRate
        End Get
    End Property
    '
    ' Performance parameters
    '

    ' PAE - AE (Potential) Application Efficiency
    Protected mPAEmin As Double
    Public ReadOnly Property PAEmin() As Double
        Get
            Return mPAEmin
        End Get
    End Property

    Protected mPAElq As Double
    Public ReadOnly Property PAElq() As Double
        Get
            Return mPAElq
        End Get
    End Property

    Protected mAE As Double                             ' Appliation Efficiency
    Public ReadOnly Property AE() As Double
        Get
            Return mAE
        End Get
    End Property

    Protected mRE As Double                             ' Requirement Efficiency
    Public ReadOnly Property RE As Double
        Get
            Return mRE
        End Get
    End Property

    ' DU - Distribution Uniformity (Min & LQ)
    Protected mDUmin As Double
    Public ReadOnly Property DUmin() As Double
        Get
            Return mDUmin
        End Get
    End Property

    Protected mDUlq As Double
    Public ReadOnly Property DUlq() As Double
        Get
            Return mDUlq
        End Get
    End Property

    ' AD - Adequacy (Min & LQ)
    Protected mADmin As Double
    Public ReadOnly Property ADmin() As Double
        Get
            Return mADmin
        End Get
    End Property

    Protected mADlq As Double
    Public ReadOnly Property ADlq() As Double
        Get
            Return mADlq
        End Get
    End Property

    ' Runoff
    Protected mRoFraction As Double
    Public ReadOnly Property RoFraction() As Double
        Get
            Return mRoFraction
        End Get
    End Property

    Protected mRoDepth As Double
    Public ReadOnly Property RoDepth() As Double
        Get
            Return mRoDepth
        End Get
    End Property

    ' Deep Percolation
    Protected mDpFraction As Double
    Public ReadOnly Property DpFraction() As Double
        Get
            Return mDpFraction
        End Get
    End Property

    Protected mDpDepth As Double
    Public ReadOnly Property DpDepth() As Double
        Get
            Return mDpDepth
        End Get
    End Property

    ' Infiltration                                      ' Infiltrated depth
    Protected mDInf As Double
    Public ReadOnly Property DInf() As Double
        Get
            Return mDInf
        End Get
    End Property

    Protected mDReq As Double                           ' Required depth
    Public ReadOnly Property DReq() As Double
        Get
            Return mDReq
        End Get
    End Property

    Protected mDApp As Double                           ' Depth applie
    Public ReadOnly Property DApp() As Double
        Get
            Return mDApp
        End Get
    End Property

    Protected mDMin As Double                           ' Minimum Depth
    Public ReadOnly Property DMin() As Double
        Get
            Return mDMin
        End Get
    End Property

    Protected mDLf As Double                            ' Low Quarter Depth
    Public ReadOnly Property DLf() As Double
        Get
            Return mDLf
        End Get
    End Property

    Protected mTReq As Double                           ' Time to infiltrate to DReq
    Public ReadOnly Property TReq() As Double
        Get
            Return mTReq
        End Get
    End Property

    Protected mTxa As Double                            ' Time to Maxmimum Advance
    Public ReadOnly Property Txa() As Double
        Get
            Return mTxa
        End Get
    End Property

    ' Cutoff / Cutback
    Protected mTco As Double
    Public ReadOnly Property Tco() As Double
        Get
            Return mTco
        End Get
    End Property

    Protected mTcb As Double
    Public ReadOnly Property Tcb() As Double
        Get
            Return mTcb
        End Get
    End Property

    Protected mTL As Double                             ' Advance time to end of field
    Public ReadOnly Property TL() As Double
        Get
            Return mTL
        End Get
    End Property

    Protected mXR As Double                             ' Relative Advance time (1.0 <= R), distance (R < 1.0)
    Public ReadOnly Property XR() As Double
        Get
            Return mXR
        End Get
    End Property

    ' Cost
    Protected mCost As Double
    Public ReadOnly Property Cost() As Double
        Get
            Return mCost
        End Get
    End Property
    '
    ' The calculated irrigation curves
    '
    Protected mDistances As ArrayList = New ArrayList       ' Distance values for curves
    Public ReadOnly Property Distances() As ArrayList
        Get
            Return mDistances
        End Get
    End Property

    Protected mAdvTimes As ArrayList = New ArrayList        ' Advance curve
    Public ReadOnly Property AdvTimes() As ArrayList
        Get
            Return mAdvTimes
        End Get
    End Property

    Protected mRecTimes As ArrayList = New ArrayList        ' Recession curve
    Public ReadOnly Property RecTimes() As ArrayList
        Get
            Return mRecTimes
        End Get
    End Property

    Protected mOppTimes As ArrayList = New ArrayList        ' Opportunity time curve
    Public ReadOnly Property OppTimes() As ArrayList
        Get
            Return mOppTimes
        End Get
    End Property

    Protected mInfDepths As ArrayList = New ArrayList       ' Infiltration curve
    Public ReadOnly Property InfDepths() As ArrayList
        Get
            Return mInfDepths
        End Get
    End Property

    Protected mInfRates As ArrayList = New ArrayList        ' Infiltration rates
    Public ReadOnly Property InfRates() As ArrayList
        Get
            Return mInfRates
        End Get
    End Property

    Public ReadOnly Property AdvanceTimeToEndOfField() As Double
        Get
            If (0 < mAdvTimes.Count) Then
                Return CDbl(mAdvTimes(mAdvTimes.Count - 1))
            Else
                Return Double.NaN
            End If
        End Get
    End Property

    Public ReadOnly Property RecessionTimeAtEndOfField() As Double
        Get
            If (0 < mRecTimes.Count) Then
                Return CDbl(mRecTimes(mRecTimes.Count - 1))
            Else
                Return Double.NaN
            End If
        End Get
    End Property

    Public ReadOnly Property RecessionTimeAtHeadOfField() As Double
        Get
            If (0 < mRecTimes.Count) Then
                Return CDbl(mRecTimes(0))
            Else
                Return Double.NaN
            End If
        End Get
    End Property

    Public Property Ymax As Double ' Maximum Flow Depth comes from Simulation Run

#End Region

#Region " SRFR Simulation "

    Public Property RunInBackgroundThread As Boolean = False

    Protected WithEvents mSrfrControl As Srfr.ThreadingControl
    Public Function SrfrControl() As Srfr.ThreadingControl
        Return mSrfrControl
    End Function

    Public Function SimResultsAreValid() As Boolean
        SimResultsAreValid = False
        If (mUnit IsNot Nothing) Then
            SimResultsAreValid = mUnit.ResultsAreValid
        End If
    End Function

    Protected WithEvents mSolutionModel As Srfr.SolutionModel
    Public Function SolutionModel() As Srfr.SolutionModel
        Return mSolutionModel
    End Function

    Public Property SrfrIrrigation() As Srfr.Irrigation
    Public Property SrfrTransport() As Srfr.ConstituentTransport

    Public Property EnableTimeLimitEvents() As Boolean = False
    Public Property EnableTimestepLimitEvents() As Boolean = False

    Public Property SrfrDepthTableForHydrus() As DataTable

#End Region

#Region " HYDRUS Simulation "
    '
    ' HYDRUS Error Messages - for WinSRFR / HYDRUS coupling
    '
    Protected mHydrusErrorMessages As List(Of String) = Nothing
    Public Property HydrusErrorMessages() As List(Of String)
        Get
            Return mHydrusErrorMessages
        End Get
        Set(ByVal value As List(Of String))
            mHydrusErrorMessages = value
        End Set
    End Property

    ' Clear list of HYDRUS error messages
    Public Sub ClearHydrusErrorMessages()
        If (mHydrusErrorMessages IsNot Nothing) Then
            mHydrusErrorMessages.Clear()
            mHydrusErrorMessages = Nothing
        End If
    End Sub

    ' Clear then initialize list of HYDRUS error messages
    Public Sub ResetHydrusErrorMessages(ByVal ProjectFolder As String)
        ClearHydrusErrorMessages()

        mHydrusErrorMessages = New List(Of String) From {
            mDictionary.tHydrusValidationSummary.Translated,
            "",
            ProjectFolder,
            ""
        }
    End Sub

    Public Sub RemoveFromEndHydrusErrorMessages(ByVal NumDel As Integer)
        While (0 < NumDel)
            mHydrusErrorMessages.RemoveAt(mHydrusErrorMessages.Count - 1)
            NumDel -= 1
        End While
    End Sub

    ' Add column headings (Col 1 - UI text, Col2 - File text)
    Public Sub AddHydrusColumnHeadings(ByVal UiTxt As String, ByVal FileTxt As String)
        mHydrusErrorMessages.Add(UiTxt & vbTab & vbTab & FileTxt)
        mHydrusErrorMessages.Add("Parameter - should be" & vbTab & vbTab & "Parameter - should be")
        mHydrusErrorMessages.Add("--------------------------------------" & vbTab & "----------------------------")
    End Sub

    ' Add HYDRUS error message for Boolean values
    Public Sub AddHydrusErrorMessage(ByVal UiTxt As String, ByVal FileTxt As String,
                                     ByVal UiBool As Boolean, ByVal FileBool As Boolean,
                                     Optional ByVal NumTabs As Integer = 1)

        Dim checked As String = If(UiBool, "checked", "unchecked")
        Dim tf As String = If(FileBool, "True", "False")

        UiTxt &= " - " & checked
        FileTxt &= " - " & tf

        While (0 < NumTabs)
            UiTxt &= vbTab
            NumTabs -= 1
        End While

        Dim line As String = UiTxt & FileTxt
        mHydrusErrorMessages.Add(line)
    End Sub

    ' Add HYDRUS error message for Integer value
    Public Sub AddHydrusErrorMessage(ByVal UiTxt As String, ByVal FileTxt As String,
                                     ByVal Num As Integer,
                                     Optional ByVal NumTabs As Integer = 1)

        UiTxt &= " - " & Num.ToString
        FileTxt &= " - " & Num.ToString

        While (1 < NumTabs)
            UiTxt &= vbTab
            NumTabs -= 1
        End While

        Dim line As String = UiTxt & vbTab & FileTxt
        mHydrusErrorMessages.Add(line)
    End Sub

    ' Add HYDRUS error message for String value
    Public Sub AddHydrusErrorMessage(ByVal UiTxt As String, ByVal FileTxt As String,
                                     ByVal Str As String,
                                     Optional ByVal NumTabs As Integer = 1)

        UiTxt &= " - " & Str
        FileTxt &= " - " & Str

        While (1 < NumTabs)
            UiTxt &= vbTab
            NumTabs -= 1
        End While

        Dim line As String = UiTxt & vbTab & FileTxt
        mHydrusErrorMessages.Add(line)
    End Sub

    Protected mlChem As Boolean = False
    Public ReadOnly Property lChem() As Boolean
        Get
            Return mlChem
        End Get
    End Property

#End Region

#Region " Misc. "
    '
    ' Status messages
    '
    Protected mStatusMessage As String
    Public Property StatusMessage() As String
        Get
            If (mWorldWindow IsNot Nothing) Then
                mStatusMessage = mWorldWindow.WorldStatusMessage
            ElseIf (mWinSRFR IsNot Nothing) Then
                mStatusMessage = mWinSRFR.StatusMessage
            End If
            Return mStatusMessage
        End Get
        Set(ByVal Value As String)
            mStatusMessage = Value
            If (mWorldWindow IsNot Nothing) Then
                mWorldWindow.WorldStatusMessage = mStatusMessage
            ElseIf (mWinSRFR IsNot Nothing) Then
                mWinSRFR.StatusMessage = mStatusMessage
            End If
        End Set
    End Property

    Protected mProgressMessage As String
    Public Property ProgressMessage() As String
        Get
            If (mWorldWindow IsNot Nothing) Then
                mProgressMessage = mWorldWindow.ProgressMessage
            End If
            Return mProgressMessage
        End Get
        Set(ByVal Value As String)
            mProgressMessage = Value
            If (mWorldWindow IsNot Nothing) Then
                mWorldWindow.ProgressMessage = mProgressMessage
            End If
        End Set
    End Property
    '
    ' Running state
    '
    Protected mRunning As Boolean
    Public Property Running() As Boolean
        Get
            If (mWorldWindow IsNot Nothing) Then
                mRunning = mWorldWindow.Running
            End If
            Return mRunning
        End Get
        Set(ByVal Value As Boolean)
            mRunning = Value
            If (mWorldWindow IsNot Nothing) Then
                mWorldWindow.Running = Value
            End If
        End Set
    End Property

    Protected mTuning As Boolean
    Public Property Tuning() As Boolean
        Get
            Return mTuning
        End Get
        Set(ByVal Value As Boolean)
            mTuning = Value
        End Set
    End Property
    '
    ' Run progress
    '
    Protected mRunProgress As Integer
    Public Property RunProgress() As Integer
        Get
            Return mRunProgress
        End Get
        Set(ByVal Value As Integer)
            mRunProgress = Value
            If (mWorldWindow IsNot Nothing) Then
                mWorldWindow.RunProgress = mRunProgress
            End If
        End Set
    End Property

#End Region

#Region " SRFR API "
    '
    ' References to the SRFR.DLL's API
    '
    ' Note - all accesses to SrfrAPI must go this property; do not use mSrfrAPI directly
    '
    Private WithEvents mSrfrAPI As Srfr.SrfrAPI = Nothing
    Public Property SrfrAPI() As Srfr.SrfrAPI
        Get
            If (mWorldWindow IsNot Nothing) Then
                mSrfrAPI = mWorldWindow.SrfrAPI
            End If
            Return mSrfrAPI
        End Get
        Set(ByVal value As Srfr.SrfrAPI)
            mSrfrAPI = value
        End Set
    End Property

    Public Sub NewSrfrAPI()
        If (mWorldWindow IsNot Nothing) Then
            mWorldWindow.NewSrfrAPI()
        End If
    End Sub
    '
    ' Manage the Reference SrfrAPI for each Analysis
    '
    Public Overridable Function SaveRefSrfrAPI() As String
        ' Generate / save random ID for the saved reference SrfrAPI
        Dim srfrID As String = RandomString()
        Dim param As StringParameter = mUnit.RefSrfrID
        param.Value = srfrID
        param.Source = DataStore.Globals.ValueSources.Calculated
        mUnit.RefSrfrID = param
        ' Save the reference SrfrAPI
        If (mWinSRFR IsNot Nothing) Then
            mWinSRFR.RefSrfrAPI(srfrID) = Me.SrfrAPI
        End If
        ' Return ID generated for the reference SrfrAPI
        Return srfrID
    End Function

    Public Function GetRefSrfrAPI(Optional ByVal SrfrID As String = "") As Srfr.SrfrAPI
        GetRefSrfrAPI = Nothing
        If (SrfrID = "") Then
            If (mUnit IsNot Nothing) Then
                SrfrID = mUnit.RefSrfrID.Value
            End If
        End If
        If (mWinSRFR IsNot Nothing) Then
            GetRefSrfrAPI = mWinSRFR.RefSrfrAPI(SrfrID)
        End If
    End Function

    Public Sub RemoveRefSrfrAPI()
        Dim srfrID As String = mUnit.RefSrfrID.Value
        If (mWinSRFR IsNot Nothing) Then
            mWinSRFR.RemoveRefSrfrAPI(srfrID)
        End If
    End Sub

#End Region

#End Region

#Region " Constructor / Initialization "

    '*********************************************************************************************************
    ' Base Constructor for all Analyses
    '
    ' Input(s):     unit            - reference to top-level DataStore object
    '               worldWindow     - reference to World Window (may be Nothing)
    '*********************************************************************************************************
    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)

        If (unit IsNot Nothing) Then
            ' Save Unit reference
            mUnit = unit

            ' Get references to Unit's contained data
            mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef
            mUnitControl = mUnit.UnitControlRef
            mSystemGeometry = mUnit.SystemGeometryRef
            mSoilCropProperties = mUnit.SoilCropPropertiesRef
            mInflowManagement = mUnit.InflowManagementRef
            mSurfaceFlow = mUnit.SurfaceFlowRef
            mSubsurfaceFlow = mUnit.SubsurfaceFlowRef
            mErosion = mUnit.ErosionRef
            mFertigation = mUnit.FertigationRef
            mBorderCriteria = mUnit.BorderCriteriaRef
            mEventCriteria = mUnit.EventCriteriaRef
            mSrfrCriteria = mUnit.SrfrCriteriaRef
            mPerformanceResults = mUnit.PerformanceResultsRef
            mSrfrResults = mUnit.SrfrResultsRef

            ' Initialize Analysis properties
            GetUnitParameters()

            mLength = mSystemGeometry.Length.Value
            mWidth = mSystemGeometry.Width.Value

            mInflowRate = mInflowManagement.InflowRate.Value
            mTco = mInflowManagement.CutoffTime.Value

            mCutbackRate = Math.Min(mInflowRate * mInflowManagement.CutbackRateRatio.Value, mInflowRate)
            mTcb = Math.Min(mTco * mInflowManagement.CutbackTimeRatio.Value, mTco)
        End If

        ' Save WorldWindow reference (may be Nothing; Analyses must be able to run without a WorldWindow)
        mWorldWindow = worldWindow

        ' Create Error & Warning lists
        mSetupErrorItems = New ArrayList
        mSetupWarningItems = New ArrayList
        mExecutionErrorItems = New ArrayList
        mExecutionWarningItems = New ArrayList

    End Sub

#End Region

#Region " Methods "

#Region " SRFR Simulation Execution "

    '*********************************************************************************************************
    ' Execution control for the SRFR simulation is in this base class to make it available to all Analyses.
    '*********************************************************************************************************

    '*********************************************************************************************************
    ' Sub VerifySrfrParameters() - Verify SRFR parameters match current conditions.
    '
    ' Input(s):     MinCellDensity  - minimum Cell Density for SRFR Simulation run
    '*********************************************************************************************************
    Protected Sub VerifySrfrParameters(ByVal MinCellDensity As Integer)

        ' Verify SRFR's Solution Model
        If Not ((mSrfrCriteria.SolutionModel.Source = ValueSources.UserEntered) _
             Or (mSrfrCriteria.SolutionModel.Source = ValueSources.Remote)) Then
            mSrfrCriteria.CheckSolutionModel()
        End If

        ' Verify SRFR's Cell Denstiry
        mSrfrCriteria.CheckCellDensity(MinCellDensity)

        ' Let the SRFR changes get reflected by the UI, if there is one
        If (mWorldWindow IsNot Nothing) Then
            mWorldWindow.Refresh()
        End If

    End Sub

    '*********************************************************************************************************
    ' Mechanism for Analyses to adjust SRFR criteria & field data prior to running a simulation
    '
    ' Input(s):     Unit        - reference to Unit being analysed
    '               SolMod      - reference to SRFR's Solution Model
    '*********************************************************************************************************
    Public Overridable Sub AdjustSrfrCriteria(ByVal Unit As Unit, ByVal Solmod As Srfr.SolutionModel)
    End Sub

    Public Overridable Sub AdjustSrfrInputs(ByVal Unit As Unit)
    End Sub

    '*********************************************************************************************************
    ' Function UnloadSrfrResults() - unloads SRFR results after running a simulation
    '
    ' Input(s):     SrfrAPI             - reference to SRFR's Application Programming Interface (API)
    '               Unit                - reference to Uint being analysed
    '               CompareRun          - selects whether or not this is a comparison run of SRFR.  Comparison
    '                                     runs store the results in the Unit's SrfrResults objects while
    '                                     normal runs store the results throughout the Unit as approppraite
    '               SkipProfiles        - if True, skips uploading the SRFR profiles
    '               SkipHydroGraphs     -  "   "     "       "      "    "  hydrographs
    '
    ' Returns:      Irrigation          - reference to SRFR's Irrigation object
    '*********************************************************************************************************
    Protected Overridable Function UnloadSrfrResults(ByVal SrfrAPI As Srfr.SrfrAPI, ByVal Unit As Unit,
        ByVal CompareRun As Boolean, ByVal SkipProfiles As Boolean, ByVal SkipHydroGraphs As Boolean) As Srfr.Irrigation
        ' Unload the 'standard' SRFR results
        Dim srfrIrrigation As Srfr.Irrigation = Nothing
        srfrIrrigation = WinMain.UnloadSrfrResults(SrfrAPI, Unit, CompareRun, SkipProfiles, SkipHydroGraphs)
        Return srfrIrrigation
    End Function

    '*********************************************************************************************************
    ' Sub RunSimulation() - Run a Simulation
    '
    ' Input(s):     MinCellDensity  - minimum Cell Density for SRFR Simulation run
    '*********************************************************************************************************
    Public Overridable Sub RunSimulation(Optional ByVal MinCellDensity As Integer = CellDensities.Medium)
        If (mUnit IsNot Nothing) Then
            ' Check SRFR parameters match current conditions
            Me.VerifySrfrParameters(MinCellDensity)
            ' Generate / save random ID for the simulation run
            Dim randomID As String = RandomString()
            ' Execute standard start analysis code
            Me.StartRun(randomID, False)
            ' Run SRFR
            Me.RunSRFR(False, False, False)
            ' Execute standard end analysis code
            Me.EndRun()
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub RunSRFR() - Run a complete SRFR simulation
    '
    ' Input(s):     CompareRun          - selects whether or not this is a comparison run of SRFR.  Comparison
    '                                     runs store the results in the Unit's SrfrResults objects while
    '                                     normal runs store the results throughout the Unit as approppraite
    '               SkipProfiles        - if True, skips uploading the SRFR profiles
    '               SkipHydroGraphs     -  "   "     "       "      "    "  hydrographs
    '*********************************************************************************************************
    Protected Sub RunSRFR(ByVal CompareRun As Boolean, ByVal SkipProfiles As Boolean, ByVal SkipHydroGraphs As Boolean)
        '
        ' Reset conditions that may occur during the SRFR Run
        '
        Dim overflow As BooleanParameter = mSurfaceFlow.Overflow
        If Not (overflow.Value = False) Then
            overflow.Value = False
            overflow.Source = ValueSources.Calculated
            mSurfaceFlow.Overflow = overflow
        End If

        Dim overflowTime As DoubleParameter = mSurfaceFlow.OverflowTime
        If Not (overflowTime.Value = 0.0) Then
            overflowTime.Value = 0.0
            overflowTime.Source = ValueSources.Calculated
            mSurfaceFlow.OverflowTime = overflowTime
        End If
        '
        ' Instantiate the appropriate Solution Model
        '
        Dim solmod As IntegerParameter = mSrfrCriteria.SolutionModel

        Dim chooseSolutionModel As Boolean = False
        If (mWinSRFR.UserLevel = UserLevels.Standard) Then ' choose Solution Model for Standard users
            chooseSolutionModel = True
        Else
            If Not ((solmod.Source = ValueSources.UserEntered) _
                 Or (solmod.Source = ValueSources.Remote)) Then ' if previously chosen, continue choosing
                chooseSolutionModel = True
            End If
        End If

        If (chooseSolutionModel) Then ' Solution Model should be chosen automatically by WinSRFR

            Dim minS0 As Double = mSystemGeometry.MinimumSlope
            Dim avgS0 As Double = mSystemGeometry.AverageSlope

            Dim chosen As SolutionModels = SolutionModels.KinematicWave ' Default to Kinematic Wave

            ' Choose Zero-Inertia based on current conditions
            If (mSystemGeometry.UpstreamCondition.Value = UpstreamConditions.DrainbackAfterCutoff) Then ' Drainback
                chosen = SolutionModels.ZeroInertia
            ElseIf (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then ' Blocked End
                chosen = SolutionModels.ZeroInertia
            ElseIf (minS0 <= 0.0) Then ' Negative slopes
                chosen = SolutionModels.ZeroInertia
            ElseIf (avgS0 <= ZeroInertiaSlope) Then ' ZI better for small slopes
                chosen = SolutionModels.ZeroInertia
            End If

            ' Update Solution Model choice, if necessary
            If Not (solmod.Value = chosen) Then
                solmod.Value = chosen
                solmod.Source = ValueSources.Calculated
                mSrfrCriteria.SolutionModel = solmod
            End If

        End If
        '
        ' Instantiate the selected Solution Model
        '
        If (solmod.Value = SolutionModels.KinematicWave) Then
            Dim KW As Srfr.KinematicWave = New Srfr.KinematicWave()
            KW.ZeroInertiaRecession = True
            mSolutionModel = KW
        Else
            Dim ZI As Srfr.ZeroInertia = New Srfr.ZeroInertia()
            mSolutionModel = ZI
        End If
        '
        ' Load SRFR's Criteria & Inputs
        '
        Me.StatusMessage = mDictionary.tLoadingSrfrCriteria.Translated

        LoadSrfrCriteria(mUnit, mSolutionModel)
        AdjustSrfrCriteria(mUnit, mSolutionModel)

        Me.StatusMessage = mDictionary.tLoadingSrfrInputs.Translated

        Dim inputsOk As Boolean = LoadSrfrInputs(SrfrAPI, mUnit)
        If (Not inputsOk) Then
            Return
        End If
        AdjustSrfrInputs(mUnit)

        SrfrTransport = SrfrAPI.ConstituentTransport
        '
        ' Initialize Simulation Animation
        '
        If (mWorldWindow IsNot Nothing) Then ' Animation Viewer can be displayed
            mWorldWindow.InitSrfrAnimation()
            ' Show Animation Viewer, if requested
            If ((WinSRFR.UserPreferences.ShowSimulationAnimation) Or (mWorldWindow.AnimationViewer.Visible)) Then
                mWorldWindow.AnimationViewer.Show()
                mWorldWindow.AnimationViewer.BringToFront()
            End If
        End If
        '
        ' Run SRFR Simulation Engine
        '
        Me.StatusMessage = mDictionary.tExecutingSrfrRun.Translated

        Try
            ' Clear any previous results
            SrfrIrrigation = Nothing
            mSrfrControl = Nothing

            Dim SrfrDB As SrfrThreadingControl = Nothing
            If (mWorldWindow IsNot Nothing) Then
                SrfrDB = mWorldWindow.SrfrThreadingControl

                If (SrfrDB IsNot Nothing) Then
                    If (RunInBackgroundThread) Then
                        mSrfrControl = SrfrDB.AbortThreadControl
                        SrfrDB.Show()
                    End If
                End If
            End If

            ' Run simulation using input Solution Model
            SrfrAPI.SimName = mUnit.SrfrID.Value
            SrfrAPI.Simulate(mSolutionModel, mSrfrControl)

            ' If SRFR simulation is running in separate thread, wait for it to complete
            If (mSrfrControl IsNot Nothing) Then
                Dim srfrThread As Threading.Thread = mSrfrControl.SrfrThread
                If (srfrThread IsNot Nothing) Then
                    While (srfrThread.IsAlive)
                        Application.DoEvents()
                    End While

                    If (SrfrDB IsNot Nothing) Then
                        SrfrDB.Hide()
                    End If

                    SrfrErrorCode = SrfrAPI.Irrigation.ErrCode
                    SrfrErrorMsg = SrfrAPI.Irrigation.ErrMsg
                End If
            End If

            ' Get SRFR results
            Me.StatusMessage = mDictionary.tGettingSrfrResults.Translated

            If ((SrfrErrorCode = SrfrErrorCodes.NoError) _
             Or (SrfrErrorCode = SrfrErrorCodes.SimulationStopped)) Then
                SrfrIrrigation = Me.UnloadSrfrResults(SrfrAPI, mUnit, CompareRun, SkipProfiles, SkipHydroGraphs)
            End If
        Catch ex As Exception
            SrfrErrorCode = SrfrErrorCodes.OperationFailed
            'mWinSRFR.UsageException("Analysis:RunSRFR() - srfrAPI.Simulate", ex)
            SrfrErrorMsg = ex.ToString
            If (mSolutionModel.ErrMsg IsNot Nothing) Then
                If Not (mSolutionModel.ErrMsg = String.Empty) Then
                    SrfrErrorMsg = mSolutionModel.ErrMsg
                End If
            End If
        End Try

        ' Save SRFR Error, if any
        Dim errorCount As IntegerParameter = mPerformanceResults.ErrorCount
        Dim errorStack As ArrayListParameter = mPerformanceResults.ErrorStack

        errorCount.Value = 0
        errorCount.Source = ValueSources.Calculated
        errorStack.Array.Clear()
        errorStack.Source = ValueSources.Calculated

        If (Not ((SrfrErrorCode = SrfrErrorCodes.NoError) _
              Or (SrfrErrorCode = SrfrErrorCodes.SimulationStopped))) Then
            errorCount.Value = 2
            errorStack.Array.Add(SrfrErrorCode)
            errorStack.Array.Add(SrfrErrorMsg)
        End If

        mPerformanceResults.ErrorCount = errorCount
        mPerformanceResults.ErrorStack = errorStack

        If (mWorldWindow IsNot Nothing) Then
            mWorldWindow.Refresh()
        End If

    End Sub

#End Region

#Region " SRFR Simulation Events "

    '*********************************************************************************************************
    ' Sub Srfr_SrfrStatus() - handler for SRFR SrfrStatus event.  This event is generated after each
    '                         Timestep's calculations have completed
    '
    ' Input(s):     Timestep    - reference to the SRFR Timestep that just completed
    '
    ' The SrfrStatus event is generated in one of two ways:
    '       1) by SRFR's Solution Model object when running a single simulation using the UI thread
    '       2) by SRFR's Control object when running simultaneous simulations using backgroun threads
    '
    ' This handler collects SRFR simulation data to be displayed is WinSRFR's status bar.
    '*********************************************************************************************************
    Protected Overridable Sub Srfr_SrfrStatus(ByVal Timestep As Srfr.Timestep) _
    Handles mSolutionModel.SrfrStatus, mSrfrControl.SrfrStatus

        Dim time As Double = Timestep.T                         ' Time for this Timestep
        Dim tsNo As Integer = Timestep.TimestepNumber           ' Timestep's sequential number
        Dim LBFLG As LBFLGS = Timestep.LBFLG                    ' Left boundary flag
        Dim RBFLG As RBFLGS = Timestep.RBFLG                    ' Right    "      "
        Dim Qin As Double = Timestep.Qin                        ' Inflow
        Dim XA As Double = Timestep.XA                          ' Advance distance for Timestep
        Dim XU As Double = Timestep.XU                          ' Upstream    "     "      "

        Dim surgeNum As Integer = Timestep.Inflow.SurgeNumber(time)
        Dim numSurges As Integer = Timestep.Inflow.NumberOfSurges

        Dim msg As String = String.Empty

        msg &= mDictionary.tTimestep.Translated & ": " & Format(tsNo, "#000") & " - "
        msg &= Srfr.Utilities.HHMMSS(time) & ", "
        msg &= "Surge " & surgeNum.ToString & " / " & numSurges.ToString & ", "

        msg &= LbflgNames(LBFLG)
        If (LBFLG = LBFLGS.Inflow) Then
            msg &= " (" & FlowRateString(Qin) & ")"
        ElseIf (LBFLG = LBFLGS.NoInflow) Then
            msg &= " (" & LengthString(XU) & ")"
        End If

        msg &= ":" & RbflgNames(RBFLG)
        If ((RBFLG = RBFLGS.Advance) Or (RBFLG = RBFLGS.Readvance) Or (RBFLG = RBFLGS.FER)) Then
            msg &= " (" & LengthString(XA) & ")"
        End If

        Me.StatusMessage = msg

        Dim overTime, overDist As Double
        If (Timestep.Overflow(overDist, overTime)) Then
            Me.ProgressMessage = mDictionary.tOverflow.Translated
        Else
            If (Me.ProgressMessage = mDictionary.tOverflow.Translated) Then
                Me.ProgressMessage = ""
            End If
        End If
    End Sub

#End Region

#Region " HYDRUS Simulation Execution "

#Region " Sync SRFR w/HYDRUS "

    '*********************************************************************************************************
    ' Function SyncWithHydrus() - Sync SRFR with HYDRUS project(s)
    '*********************************************************************************************************
    Public Function SyncWithHydrus() As Boolean
        SyncWithHydrus = False

        If (mSoilCropProperties.SyncHydrusOption.Value = SyncHydrusOptions.SyncWithWinSrfrDistances) Then
            SaveHydrusSyncDists()
        End If

        Try
            'Me.StartRun("Sync w/HYDRUS", False)

            SyncWithHydrus = Me.SyncParallelHydrusWithSRFR()

            'Me.EndRun()

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Function

    '*********************************************************************************************************
    ' Function InitHydrusForSync() - initialize HYDRUS files for upcoming Sync w/SRFR
    '
    ' Inputs:   HydrusProject   - the HYDRUS Project to synchronize SRFR to
    '
    ' Returns:  Boolean         - whether or not the initialization succeeded
    '
    ' This method generates a reasonable initial set of input data for HYDRUS to ensure a successful first
    ' run.  The first sync distance is the upstream end (dist = 0).  At the upstream end, the flow depth can
    ' be estimated using the UpstreamParameters() method since the inflow rate is known.
    '*********************************************************************************************************
    Private Function InitHydrusForSync(ByVal HydrusProject As String) As Boolean
        InitHydrusForSync = True

        ' Get upstream depth (Y0), Tco & solute values used to generate ATMOSPM.IN
        Dim Q0 As Double = mInflowManagement.AverageInflowRateForField
        If (Q0 <= 0.0) Then
            Q0 = mInflowManagement.InflowRate.Value
        End If

        Dim L As Double = mSystemGeometry.Length.Value
        Dim W As Double = mSystemGeometry.Width.Value
        Dim S0 As Double = mSystemGeometry.AverageSlope
        Dim Y0 As Double = UpstreamDepth(Q0, L, W, S0)

        Dim Tco As Double = mInflowManagement.Cutoff

        Dim solute As Boolean = mFertigation.EnableFertigation.Value

        Try
            ' Get reference to HYDRUS 1D's API
            Dim hydrus1D As HydrusAPI.Hydrus1D = New HydrusAPI.Hydrus1D

            ' Build initial ATMOSPM.IN with upstream Depth & Tco values
            hydrus1D.Generate_ATMOSPH_IN_FromInflow(Y0, Tco, solute)
            hydrus1D.Write_ATMOSPH_IN(HydrusProject, False)

        Catch ex As Exception
            Dim msg As String = "InitHydrusForSync() - "
            msg &= ex.Message
            Debug.Assert(False, msg)
            InitHydrusForSync = False
        End Try

    End Function

    '*********************************************************************************************************
    ' Function SyncParallelHydrusWithSRFR() - sync HYDRUS & SRFR in parallel at all distances down the field
    '
    ' Returns:  Boolean         - whether or not the initialization succeeded
    '*********************************************************************************************************
    Private Function SyncParallelHydrusWithSRFR() As Boolean
        SyncParallelHydrusWithSRFR = False
        Dim syncOK As Boolean = False

        ' Get the sync distances specified by the user
        Dim distTable As DataTable = mSoilCropProperties.HydrusSyncDistances.Value
        Dim distCount As Integer = distTable.Rows.Count
        Dim dist As Double = 0.0
        Dim tMin As Double = 0.0
        Dim tMax As Double = mInflowManagement.Cutoff

        ' Get reference to HYDRUS 1D's API
        Dim hydrus1D As HydrusAPI.Hydrus1D = New HydrusAPI.Hydrus1D

        UpdateAnalysisStatus(Reasons.HydrusStatus, "HYDRUS/SRFR Sync Started")

        ' Get HYDRUS project(s) specified by the user
        Dim hydrusProject As String = mSoilCropProperties.HydrusProject.Value
        Dim hydrusProjects As DataTable = Nothing

        Try
            ' Validate user has setup all HYDRUS' input files correctly
            If (mSoilCropProperties.EnableTabulatedInfiltration.Value) Then
                hydrusProjects = mSoilCropProperties.HydrusProjectTable.Value
                If (hydrusProjects IsNot Nothing) Then
                    ' Check HYDRUS' files for each tabulated HYDRUS Project
                    For Each hydrusRow As DataRow In hydrusProjects.Rows
                        hydrusProject = hydrusRow.Item(Srfr.Hydrus.sHydrusProject)

                        If Not (ReadValidateHydrus(hydrusProject)) Then
                            StatusMessage = mDictionary.tHydrusProjectValidationFailed.Translated
                            Exit Try
                        End If
                    Next hydrusRow

                    If (0 < hydrusProjects.Rows.Count) Then
                        hydrusProject = hydrusProjects.Rows(0).Item(Srfr.Hydrus.sHydrusProject)
                    End If
                End If
            End If

            If Not (ReadValidateHydrus(hydrusProject)) Then
                StatusMessage = mDictionary.tHydrusProjectValidationFailed.Translated
                Exit Try
            End If

            Dim msg As String = ""
            Dim title As String = hydrusProject

            ' Set initial (approximate) data for first HYDRUS run
            syncOK = InitHydrusForSync(hydrusProject)
            If Not (syncOK) Then
                Exit Try
            End If

            ' Run HYDRUS to get initial infiltration rate data
            syncOK = RunHydrus1D(hydrusProject, dist, tMin, tMax)
            If Not (syncOK) Then
                Exit Try
            End If

            ' Check HYDRUS error messages
            syncOK = CheckHydrusErrorMessages(hydrusProject)
            If Not (syncOK) Then
                Exit Try
            End If

            ' Check HYDRUS mass balances
            syncOK = CheckHydrusMassBalances(hydrusProject)
            If Not (syncOK) Then
                'Exit Try
            End If

            ' Get initial infiltration rate/depth data from HYDRUS
            syncOK = AppendHydrusInfiltrationData(hydrusProject, dist, True)
            If Not (syncOK) Then
                Exit Try
            End If

            ' Run SRFR to get initial flow depths
            RunSimulation()

            ' Initialize convergence criteria
            InitializeSyncConvergenceCriteria()

            ' Iterate between HYDRUS & SRFR checking for convergence of their solutions
            Dim tolerance As Double = Math.Max(0.001, distCount * 0.00025)
            If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
                tolerance = Math.Max(0.001, tolerance / 2)
            End If
            Dim iter As Integer
            For iter = 1 To 10

                ' Clear HYDRUS' infiltration rate table prior to first addition to set
                Dim preclear As Boolean = True

                ' Run HYDRUS for each sync distance
                For Each distRow As DataRow In distTable.Rows

                    dist = distRow.Item(sDistanceX) ' Next sync distance

                    ' Choose appropriate HYDRUS project if tabulated entries
                    If (hydrusProjects IsNot Nothing) Then
                        For Each tableProject As DataRow In hydrusProjects.Rows
                            Dim tableDist As Double = tableProject.Item(sDistanceX)
                            If (tableDist <= dist) Then
                                hydrusProject = tableProject.Item(Srfr.Hydrus.sHydrusProject)
                            End If
                        Next
                    End If

                    ' Update HYDRUS' surface water hydrograph from SRFR hydrographs
                    syncOK = GenerateHydrusWaterHydrograph(hydrusProject, dist, tMin, tMax)
                    If Not (syncOK) Then ' Hydrograph not generated for this Dist
                        If (0 < mSoilCropProperties.HydrusInfiltrationDepth.Value.Tables.Count) Then
                            ' There is some HYDRUS surface water data; go with that
                            Exit For ' proceed to SRFR run
                        Else ' There is no HYDRUS surface water data; cannot continue
                            Exit Try
                        End If
                    End If

                    'Dim dbGraph2d As db_Graph2D = New db_Graph2D()

                    'If (7 < iter) Then
                    '    dbGraph2d.DisplayData(mSrfrDepthTableForHydrus)
                    '    Dim dataOk As DialogResult = dbGraph2d.ShowDialog

                    '    If (dataOk = DialogResult.Cancel) Then
                    '        syncOK = False
                    '        Exit Try
                    '    End If
                    'End If

                    ' Run HYDRUS for this distance
                    syncOK = RunHydrus1D(hydrusProject, dist, tMin, tMax)
                    If Not (syncOK) Then
                        Exit Try
                    End If

                    ' Check HYDRUS error messages
                    syncOK = CheckHydrusErrorMessages(hydrusProject)
                    If Not (syncOK) Then
                        Exit Try
                    End If

                    ' Check HYDRUS mass balances
                    syncOK = CheckHydrusMassBalances(hydrusProject)
                    If Not (syncOK) Then
                        'Exit Try
                    End If

                    ' Append infiltration data from HYDRUS to WinSRFR's infiltration DataSet
                    syncOK = AppendHydrusInfiltrationData(hydrusProject, dist, preclear)
                    If Not (syncOK) Then
                        Exit Try
                    End If

                    'If (7 < iter) Then
                    '    Dim winSrfrInfiltrationRate As DataSetParameter = mSoilCropProperties.HydrusInfiltrationRate
                    '    Dim winSrfrRateSet As DataSet = winSrfrInfiltrationRate.Value

                    '    dbGraph2d = New db_Graph2D()
                    '    dbGraph2d.DisplayData(winSrfrRateSet)
                    '    Dim dataOk As DialogResult = dbGraph2d.ShowDialog

                    '    If (dataOk = DialogResult.Cancel) Then
                    '        syncOK = False
                    '        Exit Try
                    '    End If
                    'End If

                    ' Append concentration data from HYDRUS to WinSRFR's concentration DataSet
                    syncOK = AppendHydrusConcentrationData(hydrusProject, dist, preclear)
                    If Not (syncOK) Then
                        Exit Try
                    End If

                    preclear = False    ' Only preclear before first append

                Next distRow

                ' Run SRFR after HYDRUS has been run for all distances
                RunSimulation()

                ' Check for convergence between SRFR & HYDRUS
                syncOK = CheckSyncConvergence(tolerance, iter)
                If ((syncOK) And (2 < iter)) Then
                    Exit Try
                End If
            Next iter

            ' If execution gets here, convergence did not happen in iteration loop; check if close enough
            syncOK = CheckSyncConvergence(tolerance * 2.0, iter)

        Catch ex As Exception

        End Try

        If (syncOK) Then

            ' Final update of HYDRUS' surface water hydrographs from last SRFR hydrographs
            For Each distRow As DataRow In distTable.Rows

                dist = distRow.Item(sDistanceX) ' Next sync distance

                ' Choose appropriate HYDRUS project if tabulated entries
                If (hydrusProjects IsNot Nothing) Then
                    For Each tableProject As DataRow In hydrusProjects.Rows
                        Dim tableDist As Double = tableProject.Item(sDistanceX)
                        If (tableDist <= dist) Then
                            hydrusProject = tableProject.Item(Srfr.Hydrus.sHydrusProject)
                        End If
                    Next
                End If

                ' Update HYDRUS' surface water hydrograph from SRFR hydrographs
                syncOK = GenerateHydrusWaterHydrograph(hydrusProject, dist, tMin, tMax)
                If Not (syncOK) Then ' Hydrograph not generated for this Dist
                    If (Double.IsNaN(tMin)) Then ' Advance did not reach Dist
                        AddExecutionWarning(WarningFlags.ExecutionWarning, mDictionary.tAdvance.Translated,
                            mDictionary.tAdvanceDidNotReachDistance.Translated & ": " & LengthString(dist))
                        syncOK = True
                    End If
                    Exit For
                End If

            Next distRow
        End If

        If (syncOK) Then
            UpdateAnalysisStatus(Reasons.HydrusStatus, mDictionary.tSyncSuccessful.Translated)
        Else
            UpdateAnalysisStatus(Reasons.HydrusStatus, mDictionary.tSyncFailed.Translated)
        End If

        SyncParallelHydrusWithSRFR = syncOK
    End Function

    '*********************************************************************************************************
    ' Sub InitializeSyncConvergenceCriteria() - Initialize data used to check for SRFR/HYDRUS convergence
    '*********************************************************************************************************
    Private mSyncDUmin As Double
    Private mSyncDUlq As Double
    Private mSyncZfirst As Double
    Private mSyncZlast As Double
    Private mSyncZavg As Double
    Private Sub InitializeSyncConvergenceCriteria()
        UpdateAnalysisStatus(Reasons.HydrusStatus, mDictionary.tSyncIterationsStarted.Translated)

        mSyncDUmin = mSubsurfaceFlow.DUmin.Value
        mSyncDUlq = mSubsurfaceFlow.DUlq.Value
        mSyncZfirst = mSubsurfaceFlow.InfiltrationAtDistance(mSoilCropProperties.FirstHydrusSyncDistance)
        mSyncZlast = mSubsurfaceFlow.InfiltrationAtDistance(mSoilCropProperties.LastHydrusSyncDistance)
        mSyncZavg = (mSyncZfirst + mSyncZlast) / 2
    End Sub

    '*********************************************************************************************************
    ' Function CheckSyncConvergence() - check for SRFR/HYDRUS convergence
    '
    ' Inputs:   Tolerance       - error tolerance for convergence check
    '           Iteration       - iteration number
    '*********************************************************************************************************
    Private Function CheckSyncConvergence(ByVal Tolerance As Double, ByVal Iteration As Integer) As Boolean
        CheckSyncConvergence = False

        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            Dim syncDUmin As Double = mSubsurfaceFlow.DUmin.Value
            Dim DUminDiff As Double = syncDUmin - mSyncDUmin

            UpdateAnalysisStatus(Reasons.HydrusStatus, mDictionary.tIteration.Translated & " " & Iteration.ToString _
                             & "; " & mDictionary.tSyncError.Translated & " = " & Format(DUminDiff, "0.00##"))

            If (ThisClose(syncDUmin, mSyncDUmin, Tolerance)) Then
                CheckSyncConvergence = True
            Else
                mSyncDUmin = syncDUmin
            End If

            'Dim syncDUlq As Double = mSubsurfaceFlow.DUlq.Value
            'Dim DUlqDiff As Double = syncDUlq = mSyncDUlq
            'UpdateAnalysisStatus(Reasons.HydrusStatus, mDictionary.tIteration.Translated & " " & Iteration.ToString _
            '                     & "; " & mDictionary.tSyncError.Translated & " = " & Format(DUlqDiff, "0.00##"))

            'If (ThisClose(syncDUlq, mSyncDUlq, Tolerance)) Then
            '    CheckSyncConvergence = True
            'Else
            '    mSyncDUlq = syncDUlq
            'End If
        Else ' blocked
            Dim syncZfirst As Double = mSubsurfaceFlow.InfiltrationAtDistance(mSoilCropProperties.FirstHydrusSyncDistance)
            Dim syncZlast As Double = mSubsurfaceFlow.InfiltrationAtDistance(mSoilCropProperties.LastHydrusSyncDistance)
            Dim syncZavg As Double = (syncZfirst + syncZlast) / 2
            Dim syncZavgDiff As Double = syncZavg - mSyncZavg

            UpdateAnalysisStatus(Reasons.HydrusStatus, mDictionary.tIteration.Translated & " " & Iteration.ToString _
                             & "; " & mDictionary.tSyncError.Translated & " = " & Format(syncZavgDiff, "0.00##"))

            If (ThisClose(syncZavg, mSyncZavg, Tolerance)) Then
                CheckSyncConvergence = True
            End If
            mSyncZavg = syncZavg
        End If
    End Function

#End Region

#Region " Run HYDRUS "

    '*********************************************************************************************************
    ' Function ReadValidateHydrus() -  read & validate the compatiblity of the specified HYDRUS Project files
    '
    ' Inputs:   ProjectFolder           - path to folder containing the HYDRUS Project files
    '           SoluteTransport         - whether or not to include solute transport simulation
    '           ReportIncompatibilies   - whether or not to report any incompatibilities found to the user
    '
    ' Returns:  Boolean                 - True, if HYDRUS Project is deemed compatible with WinSRFR / SRFR
    '                                     False, if not
    '*********************************************************************************************************
    Protected Function ReadValidateHydrus(ByVal ProjectFolder As String,
                                          Optional ByVal SoluteTransport As Boolean = False,
                                          Optional ByVal ReportIncompatibilies As Boolean = True) As Boolean
        ReadValidateHydrus = False

        ' Clear then initialize list of HYDRUS error messages
        ResetHydrusErrorMessages(ProjectFolder)

        Dim ui As String = ""
        Dim file As String = ""
        Dim param As String = ""
        Dim selectorInOK As Boolean = True
        Dim profileDatOK As Boolean = True
        Dim atmosphInOK As Boolean = True
        Dim hydrusFilesOK As Boolean = True

        Try
            ' Instantiate the API wrapping HYDRUS-1D
            Dim hydrus1D As HydrusAPI.Hydrus1D = New HydrusAPI.Hydrus1D

            ' Read & validate HYDRUS' SELECTOR.IN file
            ui = mDictionary.tHydrusMainProcesses.Translated
            file = Hydrus1D.SELECTOR_IN
            AddHydrusColumnHeadings(ui, file & " file")

            hydrus1D.Read_SELECTOR_IN(ProjectFolder) ' throws Exception if read fails
            '
            ' Ensure lChem is read regardless of validation result
            '
            param = "lChem"
            mlChem = hydrus1D.GetBoolean(param, file)
            '
            ' Check parameters in Main Processes window
            '
            param = "lWat"
            Dim lWat As Boolean = hydrus1D.GetBoolean(param, file)
            If (lWat = False) Then
                ui = mDictionary.tWaterFlow.Translated
                AddHydrusErrorMessage(ui, param, True, True)
                selectorInOK = False
                'hydrus1D.SetBoolean(param, file, True)

            Else ' lWat = True; check water flow parameters

                param = "lVapor"
                Dim lVapor As Boolean = hydrus1D.GetBoolean(param, file)
                If (lVapor = True) Then
                    ui = mDictionary.tVaporFlow.Translated
                    AddHydrusErrorMessage(ui, param, False, False, 2)
                    selectorInOK = False
                    'hydrus1D.SetBoolean(param, file, False)
                End If

                param = "lSnow"
                Dim lSnow As Boolean = hydrus1D.GetBoolean(param, file)
                If (lSnow = True) Then
                    ui = mDictionary.tSnowHydrology.Translated
                    AddHydrusErrorMessage(ui, param, False, False)
                    selectorInOK = False
                    'hydrus1D.SetBoolean(param, file, False)
                End If

                param = "lTemp"
                Dim lTemp As Boolean = hydrus1D.GetBoolean(param, file)
                If (lTemp = True) Then
                    ui = mDictionary.tHeatTransport.Translated
                    AddHydrusErrorMessage(ui, param, False, False, 2)
                    selectorInOK = False
                    'hydrus1D.SetBoolean(param, file, False)
                End If

                param = "lSink"
                Dim lSink As Boolean = hydrus1D.GetBoolean(param, file)
                If (lSink = True) Then
                    ui = mDictionary.tRootWaterUpdake.Translated
                    AddHydrusErrorMessage(ui, param, False, False)
                    selectorInOK = False
                    'hydrus1D.SetBoolean(param, file, False)
                End If

                param = "lRoot"
                Dim lRoot As Boolean = hydrus1D.GetBoolean(param, file)
                If (lRoot = True) Then
                    ui = mDictionary.tRootGrowth.Translated
                    AddHydrusErrorMessage(ui, param, False, False, 2)
                    selectorInOK = False
                    'hydrus1D.SetBoolean(param, file, False)
                End If

                param = "lInverse"
                If (hydrus1D.ContainsVariable(param, file)) Then
                    Dim lInverse As Boolean = hydrus1D.GetBoolean(param, file)
                    If (lInverse = True) Then
                        ui = mDictionary.tInverseSolution.Translated
                        AddHydrusErrorMessage(ui, param, False, False)
                        selectorInOK = False
                        'hydrus1D.SetBoolean(param, file, False)
                    End If
                End If
                '
                ' Check Solute Transport parameters, if used
                '
                If (SoluteTransport) Then ' also check Solute Transport parameters
                    param = "lChem"
                    If (lChem = False) Then
                        ui = mDictionary.tSoluteTransport.Translated
                        AddHydrusErrorMessage(ui, param, True, True)
                        selectorInOK = False
                        'hydrus1D.SetBoolean(param, file, False)

                    Else ' lChem = True; check solute transport parameters
                        param = "No.Solutes"
                        If (hydrus1D.ContainsVariable(param, file)) Then
                            Dim ReqNo As Integer = 1
                            Dim NoSolutes As Integer = hydrus1D.GetInteger(param, file)
                            If (NoSolutes <> ReqNo) Then
                                ui = mDictionary.tNumOfSolutes.Translated
                                AddHydrusErrorMessage(ui, param, ReqNo)
                                selectorInOK = False
                                'hydrus1D.SetInteger(param, file, 1)
                            End If
                        End If

                        param = "lHP1"
                        If (hydrus1D.ContainsVariable(param, file)) Then
                            Dim HP1 As Boolean = hydrus1D.GetBoolean(param, file)
                            If (HP1 = True) Then
                                ui = mDictionary.tStndSoluteTransport.Translated
                                AddHydrusErrorMessage(ui, param, True, False)
                                selectorInOK = False
                                'hydrus1D.SetBoolean(param, file, False)
                            End If
                        End If
                    End If ' lChem = True
                End If ' SoluteTransport
            End If ' lWat = True
            '
            ' Check parameters in Time Information window
            '
            If (selectorInOK) Then
                RemoveFromEndHydrusErrorMessages(2)
                mHydrusErrorMessages.Add("")
                mHydrusErrorMessages.Add("  OK")
                mHydrusErrorMessages.Add("")

                ui = mDictionary.tHydrusTimeInformation.Translated
                file = Hydrus1D.SELECTOR_IN
                AddHydrusColumnHeadings(ui, file & " file")

                param = "lVariabBC"
                If (hydrus1D.ContainsVariable(param, file)) Then
                    Dim lVariabBC As Boolean = hydrus1D.GetBoolean(param, file)
                    If (lVariabBC = False) Then
                        ui = mDictionary.tTimeVariableBC.Translated
                        AddHydrusErrorMessage(ui, param, True, True, 2)
                        selectorInOK = False
                        'hydrus1D.SetBoolean(param, file, True)
                    End If

                End If

            End If
            '
            ' Check parameters in Print Information window
            '
            If (selectorInOK) Then
                RemoveFromEndHydrusErrorMessages(2)
                mHydrusErrorMessages.Add("")
                mHydrusErrorMessages.Add("  OK")
                mHydrusErrorMessages.Add("")

                ui = mDictionary.tHydrusPrintInformation.Translated
                file = Hydrus1D.SELECTOR_IN
                AddHydrusColumnHeadings(ui, file & " file")

                param = "lShort"
                If (hydrus1D.ContainsVariable(param, file)) Then
                    Dim lShort As Boolean = hydrus1D.GetBoolean(param, file)
                    If (lShort = False) Then
                        ui = mDictionary.tTLevelInformation.Translated
                        AddHydrusErrorMessage(ui, param, False, True)
                        selectorInOK = False
                        'hydrus1D.SetBoolean(param, file, True)
                    End If
                End If

                param = "ShortF"
                If (hydrus1D.ContainsVariable(param, file)) Then
                    Dim ShortF As Boolean = hydrus1D.GetBoolean(param, file)
                    If (ShortF = False) Then
                        ui = mDictionary.tTLevelInformation.Translated
                        AddHydrusErrorMessage(ui, param, False, True)
                        selectorInOK = False
                        'hydrus1D.SetBoolean(param, file, True)
                    End If
                End If

                param = "lPrintD"
                Dim lPrintD As Boolean = hydrus1D.GetBoolean(param, file)
                If (lPrintD = False) Then
                    ui = mDictionary.tPrintAtRegTimeInt.Translated
                    AddHydrusErrorMessage(ui, param, True, True)
                    selectorInOK = False
                    'hydrus1D.SetBoolean(param, file, False)
                End If

                param = "lScreen"
                Dim lScreen As Boolean = hydrus1D.GetBoolean(param, file)
                If (lScreen = True) Then
                    ui = mDictionary.tScreenOutput.Translated
                    AddHydrusErrorMessage(ui, param, False, False, 2)
                    selectorInOK = False
                    'hydrus1D.SetBoolean(param, file, False)
                End If

                param = "lEnter"
                Dim lEnter As Boolean = hydrus1D.GetBoolean(param, file)
                If (lEnter = True) Then
                    ui = mDictionary.tHitEnterAtEnd.Translated
                    AddHydrusErrorMessage(ui, param, False, False)
                    selectorInOK = False
                    'hydrus1D.SetBoolean(param, file, False)
                End If

                Dim ReqNo As Integer = 1
                param = "MPL"
                Dim MPL As Integer = hydrus1D.GetInteger(param, file)
                If (MPL <> ReqNo) Then
                    ui = mDictionary.tNoOfPrintTimes.Translated
                    AddHydrusErrorMessage(ui, param, ReqNo, 2)
                    selectorInOK = False
                    'hydrus1D.SetInteger(param, file, 1)
                End If

                param = "tPrintInterval" ' should be One Minute (60 sec) or less
                Dim tPrintInterval As Double = hydrus1D.GetDouble(param, file, Units.Time)
                If (tPrintInterval > 60.1) Then ' add 0.1 to account for rounding errors
                    ui = mDictionary.tTimeInterval.Translated
                    AddHydrusErrorMessage(ui, param, "1 minute", 2)
                    selectorInOK = False
                    'hydrus1D.SetDouble(param, file, 60.0, Units.Time)
                End If

            End If

            mHydrusErrorMessages.Add("")
            If (selectorInOK) Then
                mHydrusErrorMessages.Add("  OK")
            Else
                hydrusFilesOK = False
            End If
            mHydrusErrorMessages.Add("")

            ' Read & validate HYDRUS' PROFILE.DAT file
            file = Hydrus1D.PROFILE_DAT
            mHydrusErrorMessages.Add(file)
            mHydrusErrorMessages.Add("")

            hydrus1D.Read_PROFILE_DAT(ProjectFolder) ' throws Exception if read fails

            If (profileDatOK) Then
                mHydrusErrorMessages.Add("  OK")
            Else
                hydrusFilesOK = False
            End If
            mHydrusErrorMessages.Add("")

            ' Read & validate HYDRUS' ATMOSPH.IN file
            file = Hydrus1D.ATMOSPH_IN
            mHydrusErrorMessages.Add(file)
            mHydrusErrorMessages.Add("")

            hydrus1D.Read_ATMOSPH_IN(ProjectFolder) ' throws Exception if read fails

            If (atmosphInOK) Then
                mHydrusErrorMessages.Add("  OK")
            Else
                hydrusFilesOK = False
            End If

            If (hydrusFilesOK) Then
                ReadValidateHydrus = True
                Exit Function
            End If

        Catch hex As HydrusException
            mHydrusErrorMessages.Add(ProjectFolder & "\" & file)
            mHydrusErrorMessages.Add("")

            Select Case hex.Reason
                Case IO_Errors.FileNotFound
                    mHydrusErrorMessages.Add(hex.Text & " - " & mDictionary.tFileNotFound.Translated)
                Case IO_Errors.FileIsEmpty
                    mHydrusErrorMessages.Add(hex.Text & " - " & mDictionary.tFileIsEmpty.Translated)
                Case IO_Errors.FileContentsAreBad
                    mHydrusErrorMessages.Add(hex.Text & " - " & mDictionary.tFileContainsUnexpectedData.Translated)
                Case IO_Errors.NameNotFound
                    mHydrusErrorMessages.Add(hex.Text & " - " & mDictionary.tVariableNotFound.Translated)
                Case IO_Errors.ParseFailed
                    mHydrusErrorMessages.Add(hex.Text & " - " & mDictionary.tVariableNotParsed.Translated)
                Case Else
                    mHydrusErrorMessages.Add(hex.Text & Chr(10) & hex.Reason.ToString)
            End Select

            mHydrusErrorMessages.Add("")
            mHydrusErrorMessages.Add(mDictionary.tEnsureFileContainsValidData.Translated)

            If (0 <= hex.LineNo) Then
                mHydrusErrorMessages.Add(mDictionary.tProblemNearLine.Translated & " #" & hex.LineNo.ToString)
            End If

        Catch ex As Exception
            mHydrusErrorMessages.Add(ProjectFolder & "\" & file)
            mHydrusErrorMessages.Add("")
            mHydrusErrorMessages.Add(ex.Message)
        End Try

        mHydrusErrorMessages.Add("")
        mHydrusErrorMessages.Add("------------------------------------------------------------------------")
        mHydrusErrorMessages.Add("")
        mHydrusErrorMessages.Add("1) " & mDictionary.tMakeChangesListedAbove.Translated)
        mHydrusErrorMessages.Add("2) " & mDictionary.tEnsureHYDRUSfilesAreCompatible.Translated)

        If (ReportIncompatibilies) Then
            If (mHydrusErrorMessages IsNot Nothing) Then
                If (0 < mHydrusErrorMessages.Count) Then

                    Dim title As String = mDictionary.tHydrusValidationError.Translated

                    Dim msg As String = ""
                    For Each line As String In mHydrusErrorMessages
                        msg &= line & Chr(10)
                    Next

                    MsgBox(msg, MsgBoxStyle.OkOnly, title)

                    AddExecutionError(ErrorFlags.ExecutionError, title, msg)
                End If
            End If
        End If

    End Function

    '*********************************************************************************************************
    ' Function RunHydrus1D() - execute the specified HYDRUS-1D simulation
    '
    ' Inputs:   HydrusProject   - path to folder containing the HYDRUS Project files
    '           Dist            - distance down field HYDRUS is being run at
    '           tInit, tMax     - initial/final times for HYDRUS simulation
    '
    ' Returns:  Boolean         - True, if HYDRUS execution completed successfully
    '                             False, if not
    '
    ' Note - tInit & tMax are the initial & final times set in ATMOSPH.IN
    '*********************************************************************************************************
    Protected Function RunHydrus1D(ByVal HydrusProject As String, ByVal Dist As Double,
                                   ByVal tInit As Double, ByVal tMax As Double) As Boolean
        RunHydrus1D = False

        Debug.Assert((0.0 <= Dist) And (0.0 <= tInit) And (tInit < tMax))

        StatusMessage = mDictionary.tHydrusRunStarted.Translated & " at " & LengthString(Dist)

        Dim title As String = mDictionary.tHydrusExecutionError.Translated
        Dim file As String = HydrusAPI.Hydrus1D.SELECTOR_IN
        Dim msg As String = HydrusProject & "\" & file & Chr(10) & Chr(10)
        Dim MPL As Integer = 1
        Dim MPLtimes As List(Of Double) = New List(Of Double)
        Dim hydrus1D As HydrusAPI.Hydrus1D = Nothing

        Try
            ' Instantiate the API wrapping HYDRUS-1D
            hydrus1D = New HydrusAPI.Hydrus1D
            '
            ' Set initial / maximum time values for HYDRUS simulation
            '
            ' The initial time set in SELECTOR.IN must be less than the initial time in ATMOSPH.IN by:
            '
            '   Must be LESS THAN: tInit - dtInit (i.e. dt)
            '
            hydrus1D.Read_SELECTOR_IN(HydrusProject)

            Dim dtInit As Double = hydrus1D.GetDouble("dt", file, Units.Time)

            tInit = Math.Max(0.0, (tInit - 2.0 * dtInit))

            hydrus1D.SetDouble("tInit", file, tInit, Units.Time)
            hydrus1D.SetDouble("tMax", file, tMax, Units.Time)
            '
            ' Set solute duration pulse time; 'tPulse' is present in SELECTOR.IN if 'lChem' is true.
            '
            ' Since WinSRFR turns 'lChem' false during its sync process; 'tPulse' may be present even
            ' when 'lChem' is false.  'tPulse' should be set to 0.0 in this case.
            '
            If (lChem) Then 'tPulse' should be in SELECTOR.IN
                hydrus1D.SetDouble("tPulse", file, tMax - tInit, Units.Time)

            Else 'lChem' is false; set 'tPulse' to 0.0
                Try
                    hydrus1D.SetDouble("tPulse", file, 0.0, Units.Time)
                Catch ex As Exception ' when 'tPulse' is not present in SELECTOR.IN
                End Try
            End If

            ' Set number of print lines to 0 (tInit & tMax times still print); save original MPL first
            MPL = hydrus1D.GetInteger("MPL", file)
            MPLtimes = hydrus1D.Get_SELECTOR_IN_TPrintTimes

            hydrus1D.SetInteger("MPL", file, 0)
            hydrus1D.Set_SELECTOR_IN_TPrintTimes(tMax - tInit)

            hydrus1D.Write_SELECTOR_IN(HydrusProject)

            ' Write LEVEL_01.DIR file to user selected HYDRUS Project folder
            hydrus1D.Write_LEVEL_01_DIR(HydrusProject, HydrusProject)

            ' Run HYDRUS-1D using project folder as working folder
            'Dim HydrusPath As String = "C:\Program Files (x86)\PC-Progress\Hydrus-1D 4.xx\H1D_CALC.exe"
            Dim HydrusPath As String = Application.StartupPath & "\H1D_CALC.exe"

            RunHydrus1D = hydrus1D.Execute(HydrusProject, HydrusPath)

            StatusMessage = mDictionary.tHydrusRunSuccessful.Translated

        Catch hex As HydrusException

            Select Case hex.Reason
                Case IO_Errors.FileNotFound
                    msg &= hex.Text & " - " & mDictionary.tFileNotFound.Translated
                Case IO_Errors.FileIsEmpty
                    msg &= hex.Text & " - " & mDictionary.tFileIsEmpty.Translated
                Case IO_Errors.FileContentsAreBad
                    msg &= hex.Text & " - " & mDictionary.tFileContainsUnexpectedData.Translated
                Case IO_Errors.NameNotFound
                    msg &= hex.Text & " - " & mDictionary.tVariableNotFound.Translated
                Case IO_Errors.ParseFailed
                    msg &= hex.Text & " - " & mDictionary.tVariableNotParsed.Translated
                Case Else
                    msg &= hex.Text & Chr(10) & hex.Reason.ToString & Chr(10)
            End Select

            msg &= Chr(10)
            msg &= mDictionary.tEnsureFileContainsValidData.Translated & Chr(10)

            If (0 <= hex.LineNo) Then
                msg &= Chr(10) & mDictionary.tProblemNearLine.Translated & " #" & hex.LineNo.ToString
            End If

            msg &= Chr(10) & mDictionary.tHydrusNotRun.Translated
            MsgBox(msg, MsgBoxStyle.Exclamation, title)

            StatusMessage = mDictionary.tHydrusRunFailed.Translated

        Catch ex As Exception
            msg &= ex.Message & Chr(10) & Chr(10)
            msg &= mDictionary.tHydrusNotRun.Translated
            MsgBox(msg, MsgBoxStyle.Exclamation, title)

            StatusMessage = mDictionary.tHydrusRunFailed.Translated

        Finally

            ' Replace original MPL value (number of print times)
            MPL = Math.Max(MPL, 1) ' HYDRUS UI requires 0 < MPL
            If (hydrus1D IsNot Nothing) Then
                hydrus1D.SetInteger("MPL", file, MPL)
                'hydrus1D.Set_SELECTOR_IN_TPrintTimes(MPLtimes)
                hydrus1D.Write_SELECTOR_IN(HydrusProject)
            End If

        End Try

    End Function

    '*********************************************************************************************************
    ' Function GenerateHydrusWaterHydrograph() - generate the surface flow hydrograph table for HYDRUS
    '
    ' Inputs:   HydrusProject   - path to HYDRUS' project's I/O text files
    '           Dist            - distance down field HYDRUS simulation is to be run
    '
    ' Outputs:  Tmin            - minimum time appearing in generated hydrograph
    '           Tmax            - maximum   "      "      "     "          "
    '
    ' Returns:  Boolean         - whether or not the flow data was successfully generated
    '
    ' NOTE - if the surface flow advance does not reach Dist, hydrograph is not available
    '*********************************************************************************************************
    Protected Function GenerateHydrusWaterHydrograph(ByVal HydrusProject As String, ByVal Dist As Double,
                                                     ByRef Tmin As Double, ByRef Tmax As Double) As Boolean
        GenerateHydrusWaterHydrograph = False

        Try
            ' Get reference to HYDRUS 1D's API
            Dim hydrus1D As HydrusAPI.Hydrus1D = New HydrusAPI.Hydrus1D

            Tmin = SrfrIrrigation.Tadv(Dist)                ' Tmin is Advance Time
            Tmax = SrfrIrrigation.Trec(Dist)                ' Tmax  " Recession "

            ' Check Advance to ensure water made it to Dist
            If (Double.IsNaN(Tmin)) Then
                Exit Try
            End If

            Dim row As DataRow

            ' Generate HYDRUS' hydrograph from SRFR's depth/fertigation hydrographs
            SrfrDepthTableForHydrus = SrfrIrrigation.Hydrographs("Y", Dist)
            If (SrfrDepthTableForHydrus IsNot Nothing) Then

                ' Remove rows prior to Advance Time or with no flow depth
                While (0 < SrfrDepthTableForHydrus.Rows.Count)
                    row = SrfrDepthTableForHydrus.Rows(0)
                    If (row.Item(0) < Tmin) Then ' time prior to Advance Time
                        SrfrDepthTableForHydrus.Rows.RemoveAt(0)
                    ElseIf (row.Item(1) <= 0.0) Then ' no flow depth (Y)
                        SrfrDepthTableForHydrus.Rows.RemoveAt(0)
                    Else
                        Exit While
                    End If
                End While

                ' Remove rows after Recession Time
                Dim Trec As Double = 0.0
                While (0 < SrfrDepthTableForHydrus.Rows.Count)
                    row = SrfrDepthTableForHydrus.Rows(SrfrDepthTableForHydrus.Rows.Count - 1)
                    If (Tmax < row.Item(0)) Then ' time after Recession Time
                        Trec = row.Item(0)
                        SrfrDepthTableForHydrus.Rows.RemoveAt(SrfrDepthTableForHydrus.Rows.Count - 1)
                    Else
                        Exit While
                    End If
                End While

                ' Remove rows with miniscule DTs; leave first & last rows
                If (0 < SrfrDepthTableForHydrus.Rows.Count) Then
                    row = SrfrDepthTableForHydrus.Rows(0)
                    Dim T0 As Double = row.Item(0)
                    Dim Y0 As Double = row.Item(1)

                    Dim rdx As Integer = 1
                    While (rdx < SrfrDepthTableForHydrus.Rows.Count - 1)
                        row = SrfrDepthTableForHydrus.Rows(rdx)
                        Dim T1 As Double = row.Item(0)
                        Dim Y1 As Double = row.Item(1)
                        Dim DT As Double = Math.Abs(T1 - T0)
                        Dim DY As Double = Math.Abs(Y1 - Y0)

                        If (DT < OneSecond) Then
                            SrfrDepthTableForHydrus.Rows.RemoveAt(rdx)
                        Else
                            T0 = T1
                            Y0 = Y1
                            rdx += 1
                        End If
                    End While
                End If

                ' Is there anything left?
                If (0 < SrfrDepthTableForHydrus.Rows.Count) Then ' Yes, go with it

                    Dim hydrusHydrograph As DataTable = New DataTable("HYDRUS Water Hydrograph")
                    hydrusHydrograph.Columns.Add(SrfrDepthTableForHydrus.Columns(0).ColumnName, GetType(Double))
                    hydrusHydrograph.Columns.Add(SrfrDepthTableForHydrus.Columns(1).ColumnName, GetType(Double))

                    If (lChem) Then
                        hydrusHydrograph.Columns.Add("C (g/l)", GetType(Double))
                    End If
                    '
                    ' Add rows from SRFR Depth Table
                    '
                    Dim T As Double = 0.0
                    Dim Y As Double = 0.0
                    Dim newHydrusRow As DataRow = Nothing

                    For Each row In SrfrDepthTableForHydrus.Rows

                        ' Get time & flow depth data from SRFR table
                        T = row.Item(0)
                        Y = row.Item(1)

                        If (T <= Tmax) Then
                            ' Generate next HYDRUS table row; including Co, if selected
                            newHydrusRow = hydrusHydrograph.NewRow
                            newHydrusRow.Item(0) = T
                            newHydrusRow.Item(1) = Y

                            If (lChem) Then
                                Dim Co As Double = SrfrIrrigation.NodePropertyValue("Co", Dist, T)
                                If ((Co < 0) Or (Double.IsNaN(Co))) Then
                                    Co = 0
                                End If
                                newHydrusRow.Item(2) = Co
                            End If

                            hydrusHydrograph.Rows.Add(newHydrusRow)

                        Else
                            Exit For
                        End If
                    Next row
                    '
                    ' Add row after Recession, if required; (last row may still have surface water)
                    '
                    If (Y > 0.0) Then ' last row still had surface water
                        Y = 0.0
                        Tmax = Trec
                        newHydrusRow = hydrusHydrograph.NewRow
                        newHydrusRow.Item(0) = Tmax
                        newHydrusRow.Item(1) = Y

                        If (lChem) Then
                            Dim Co As Double = SrfrIrrigation.NodePropertyValue("Co", Dist, Tmax)
                            If ((Co < 0) Or (Double.IsNaN(Co))) Then
                                Co = 0
                            End If
                            newHydrusRow.Item(2) = Co
                        End If

                        hydrusHydrograph.Rows.Add(newHydrusRow)
                    End If

                    ' Generate new ATMOSPH.IN contents from SRFR depth data
                    hydrus1D.Generate_ATMOSPH_IN_FromWaterHydrograph(hydrusHydrograph)
                    hydrus1D.Write_ATMOSPH_IN(HydrusProject, False)

                    GenerateHydrusWaterHydrograph = True
                Else
                    GenerateHydrusWaterHydrograph = False
                End If
            End If

        Catch ex As Exception

        End Try

    End Function

    '*********************************************************************************************************
    ' Sub SaveHydrusSyncDists() - save HYDRUS sync distances as Hydrograph distances
    '*********************************************************************************************************
    Public Sub SaveHydrusSyncDists()

        Dim fieldLength As Double = mSystemGeometry.Length.Value

        Dim hydrusSyncDists As DataTable = mSoilCropProperties.HydrusSyncDistances.Value
        Dim hydroDists As DataTable = hydrusSyncDists.Copy
        hydroDists.TableName = SrfrCriteria.sHydrographTable
        Dim row As DataRow = hydroDists.NewRow
        row.Item(sDistanceX) = fieldLength
        hydroDists.Rows.Add(row)

        Dim distsParam As DataTableParameter = mSrfrCriteria.HydrographTable
        distsParam.Source = ValueSources.Calculated
        distsParam.Value = hydroDists
        mSrfrCriteria.HydrographTable = distsParam

    End Sub

#End Region

#Region " Get HYDRUS Results "

    '*********************************************************************************************************
    ' Function AppendHydrusInfiltrationData() - appends HYDRUS' infiltration rate/depth data to WinSRFR's
    '
    ' Inputs:   HydrusProject   - path to HYDRUS' project's I/O text files
    '           Dist            - distance down field HYDRUS simulation was run
    '           Preclear        - whether or not WinSRFR's infiltration DataSet should be pre-cleared
    '
    ' Returns:  Boolean         - whether or not the infiltration rate/depth data was successfully transfered
    '
    ' NOTE - imports infiltration rate/depth data from HYDRUS' T_LEVEL.OUT file as DataTables that are
    '        appended to HydrusInfiltrationRate/Depth DataSets used by SRFR as its infiltration input.
    '*********************************************************************************************************
    Protected Function AppendHydrusInfiltrationData(ByVal HydrusProject As String, ByVal Dist As Double,
                                                    Optional ByVal Preclear As Boolean = False) As Boolean
        AppendHydrusInfiltrationData = False

        Dim title As String = mDictionary.tHydrusExecutionError.Translated
        Dim file As String = Hydrus1D.T_LEVEL_OUT
        Dim msg As String = HydrusProject & "\" & file & Chr(10) & Chr(10)

        Try
            ' Get reference to HYDRUS 1D's API
            Dim hydrus1D As HydrusAPI.Hydrus1D = New HydrusAPI.Hydrus1D

            ' Read infiltration data from the previous HYDRUS run
            hydrus1D.Read_T_LEVEL_OUT(HydrusProject) ' T_LEVEL.OUT contains HYDRUS' infiltration data

            Dim hydrusTLevelTable As DataTable = hydrus1D.TLevelTable
            If (hydrusTLevelTable IsNot Nothing) Then ' file successfully imported

                ' Extract the infiltration rate data from the T_LEVEL.OUT data
                Dim fromHydrusRateTable As DataTable = ExtractInfiltrationRateTable(hydrusTLevelTable)
                If (fromHydrusRateTable IsNot Nothing) Then ' file contained infiltration data
                    fromHydrusRateTable.TableName = "Infiltration Rate [X = " & LengthString(Dist) & "]"
                    fromHydrusRateTable.ExtendedProperties.Add("Dist", Dist)

                    Dim winSrfrInfiltrationRate As DataSetParameter = mSoilCropProperties.HydrusInfiltrationRate
                    Dim winSrfrRateSet As DataSet = winSrfrInfiltrationRate.Value

                    If (Preclear) Then
                        If (winSrfrRateSet IsNot Nothing) Then
                            winSrfrRateSet.Tables.Clear()
                            winSrfrRateSet.Dispose()
                            winSrfrRateSet = Nothing
                        End If

                        winSrfrRateSet = New DataSet(mDictionary.tHydrusInfiltration.Translated)

                        winSrfrInfiltrationRate.Value = winSrfrRateSet
                    End If

                    winSrfrRateSet.Tables.Add(fromHydrusRateTable)
                    mSoilCropProperties.HydrusInfiltrationRate = winSrfrInfiltrationRate

                Else ' No infiltration data in T_LEVEL.OUT
                    msg &= mDictionary.tHydrusFileError.Translated & Chr(10) & Chr(10)
                    msg &= mDictionary.tFileIsEmpty.Translated
                    MsgBox(msg, MsgBoxStyle.Exclamation, title)
                End If

                ' Extract the infiltration depth data from the T_LEVEL.OUT data
                Dim fromHydrusDepthTable As DataTable = ExtractInfiltrationDepthTable(hydrusTLevelTable)
                If (fromHydrusDepthTable IsNot Nothing) Then ' file contained infiltration data
                    fromHydrusDepthTable.TableName = "Infiltration Depth [X = " & LengthString(Dist) & "]"
                    fromHydrusDepthTable.ExtendedProperties.Add("Dist", Dist)

                    Dim winSrfrInfiltrationDepth As DataSetParameter = mSoilCropProperties.HydrusInfiltrationDepth
                    Dim winSrfrDepthSet As DataSet = winSrfrInfiltrationDepth.Value

                    If (Preclear) Then
                        If (winSrfrDepthSet IsNot Nothing) Then
                            winSrfrDepthSet.Tables.Clear()
                            winSrfrDepthSet.Dispose()
                            winSrfrDepthSet = Nothing
                        End If

                        winSrfrDepthSet = New DataSet(mDictionary.tHydrusInfiltration.Translated)

                        winSrfrInfiltrationDepth.Value = winSrfrDepthSet
                    End If

                    winSrfrDepthSet.Tables.Add(fromHydrusDepthTable)
                    mSoilCropProperties.HydrusInfiltrationDepth = winSrfrInfiltrationDepth

                    AppendHydrusInfiltrationData = True

                Else ' No infiltration data in T_LEVEL.OUT
                    msg &= mDictionary.tHydrusFileError.Translated & Chr(10) & Chr(10)
                    msg &= mDictionary.tFileIsEmpty.Translated
                    MsgBox(msg, MsgBoxStyle.Exclamation, title)
                End If

            Else ' No T_LEVEL.OUT file
                msg &= mDictionary.tHydrusFileError.Translated & Chr(10) & Chr(10)
                msg &= mDictionary.tFileNotFound.Translated
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
            End If

        Catch ex As Exception
            msg &= ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
        End Try

    End Function

    '*********************************************************************************************************
    ' Function AppendHydrusSubsurfaceProfiles() - append HYDRUS' concentration data to WinSRFR's
    '
    ' Inputs:   HydrusProject   - path to HYDRUS' project's I/O text files
    '           Dist            - distance down field HYDRUS simulation was run
    '           Preclear        - whether or not WinSRFR's concentration DataSet should be pre-cleared
    '
    ' Returns:  Boolean         - whether or not the subsurface data was successfully transferred
    '
    ' NOTE - imports the concentration data from HYDRUS' NOD_INF.OUT file as a DataTable that is appended to
    '        WinSRFR's HydrusConcentration DataSet.
    '*********************************************************************************************************
    Protected Function AppendHydrusConcentrationData(ByVal HydrusProject As String, ByVal Dist As Double,
                                                     Optional ByVal Preclear As Boolean = False) As Boolean
        AppendHydrusConcentrationData = False

        Dim title As String = mDictionary.tHydrusExecutionError.Translated
        Dim file As String = Hydrus1D.NOD_INF_OUT
        Dim msg As String = HydrusProject & "\" & file & Chr(10) & Chr(10)

        Try
            ' Get reference to HYDRUS 1D's API
            Dim hydrus1D As HydrusAPI.Hydrus1D = New HydrusAPI.Hydrus1D

            ' Read profiles data from the previous HYDRUS run
            hydrus1D.Read_NOD_INF_OUT(HydrusProject) ' NOD_INF.OUT contains HYDRUS' concentration data

            Dim hydrusNodInfTables As DataSet = hydrus1D.NodInfTables
            If (hydrusNodInfTables IsNot Nothing) Then ' file successfully imported

                ' Extract the concentration data from the NOD_INF.OUT data
                Dim fromHydrusSubsurfaceProfiles As DataTable = ExtractConcentrationTable(hydrusNodInfTables)
                If (fromHydrusSubsurfaceProfiles IsNot Nothing) Then ' file contained concentration data
                    fromHydrusSubsurfaceProfiles.TableName = "Profiles [X = " & LengthString(Dist) & "]"
                    fromHydrusSubsurfaceProfiles.ExtendedProperties.Add("Dist", Dist)

                    Dim winSrfrProfiles As DataSetParameter = mSoilCropProperties.HydrusProfiles
                    Dim winSrfrProfilesSet As DataSet = winSrfrProfiles.Value

                    If (Preclear) Then
                        If (winSrfrProfilesSet IsNot Nothing) Then
                            winSrfrProfilesSet.Tables.Clear()
                            winSrfrProfilesSet.Dispose()
                            winSrfrProfilesSet = Nothing
                        End If

                        winSrfrProfilesSet = New DataSet(mDictionary.tHydrusProfiles.Translated)

                        winSrfrProfiles.Value = winSrfrProfilesSet
                    End If

                    winSrfrProfilesSet.Tables.Add(fromHydrusSubsurfaceProfiles)
                    mSoilCropProperties.HydrusProfiles = winSrfrProfiles

                    AppendHydrusConcentrationData = True

                Else ' No profiles data in NOD_INF.OUT
                    msg &= mDictionary.tHydrusFileError.Translated & Chr(10) & Chr(10)
                    msg &= mDictionary.tFileIsEmpty.Translated
                    MsgBox(msg, MsgBoxStyle.Exclamation, title)
                End If

            Else ' No NOD_INF.OUT file
                msg &= mDictionary.tHydrusFileError.Translated & Chr(10) & Chr(10)
                msg &= mDictionary.tFileNotFound.Translated
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
            End If

        Catch ex As Exception
            msg &= ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
        End Try

    End Function

    '*********************************************************************************************************
    ' Function CheckHydrusErrorMessages() - check for error messages from HYDRUS run
    '
    ' Inputs:   HydrusProject   - path to HYDRUS' project's I/O text files
    '
    ' Returns:  Boolean         - whether or not to continue using HYDRUS as setup
    '*********************************************************************************************************
    Protected Function CheckHydrusErrorMessages(ByVal HydrusProject As String) As Boolean
        CheckHydrusErrorMessages = True

        Dim title As String = mDictionary.tHydrusExecutionError.Translated
        Dim file As String = Hydrus1D.ERROR_MSG
        Dim msg As String = HydrusProject & "\" & file & Chr(10) & Chr(10)

        Try
            ' Get reference to HYDRUS 1D's API
            Dim hydrus1D As HydrusAPI.Hydrus1D = New HydrusAPI.Hydrus1D

            ' Read profiles data from the previous HYDRUS run
            hydrus1D.Read_Error_msg(HydrusProject) ' Error.msg contains HYDRUS' error message(s)

            Dim errMsgs As List(Of String) = hydrus1D.ErrorMsgs
            If (errMsgs IsNot Nothing) Then
                If (0 < errMsgs.Count) Then

                    For Each eMsg As String In errMsgs
                        msg &= eMsg & Chr(10)
                        msg &= Chr(10) & "Continue HYDRUS execution?"
                        Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                        If (result = MsgBoxResult.No) Then
                            CheckHydrusErrorMessages = False
                        End If
                    Next
                End If
            End If

        Catch ex As Exception
            msg &= ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
        End Try

    End Function

    '*********************************************************************************************************
    ' Function CheckHydrusMassBalances() - check mass balances from HYDRUS run
    '
    ' Inputs:   HydrusProject   - path to HYDRUS' project's I/O text files
    '
    ' Returns:  Boolean         - whether or not to continue using HYDRUS as setup
    '*********************************************************************************************************
    Protected Function CheckHydrusMassBalances(ByVal HydrusProject As String) As Boolean
        CheckHydrusMassBalances = True

        Dim title As String = mDictionary.tHydrusExecutionError.Translated
        Dim file As String = Hydrus1D.BALANCE_OUT
        Dim msg As String = HydrusProject & "\" & file & Chr(10) & Chr(10)

        Dim WatBalRLimit As Double = 0.001 ' %

        Try
            ' Get reference to HYDRUS 1D's API
            Dim hydrus1D As HydrusAPI.Hydrus1D = New HydrusAPI.Hydrus1D

            ' Read profiles data from the previous HYDRUS run
            hydrus1D.Read_BALANCE_OUT(HydrusProject) ' BALANCE.OUT contains HYDRUS' mass balance data

            Dim WatBalT As Double = hydrus1D.FinalWatBalT
            Dim WatBalR As Double = hydrus1D.FinalWatBalR
            Dim Time0 As Double = hydrus1D.BalanceTableTime
            Dim Time1 As Double = hydrus1D.BalanceTableTime(1)
            Dim CalcTime As Double = hydrus1D.CalculationTime

            If (WatBalRLimit < WatBalR) Then
                msg &= mDictionary.tWaterMassBalanceExceedsLimit.Translated & " (WatBalR=" & PercentageString(WatBalR) & ")." & Chr(10) & Chr(10)
                msg &= Chr(10) & mDictionary.tHydrusContinueExecution.Translated
                Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                If (result = MsgBoxResult.No) Then
                    CheckHydrusMassBalances = False
                End If
            End If

        Catch ex As Exception
            msg &= ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
        End Try

    End Function

#End Region

#Region " Extract WinSRFR Data "

    '*********************************************************************************************************
    ' Function ExtractInfiltrationRateTable()  - extract WinSRFR infiltration rate table from HYDRUS table
    ' Function ExtractInfiltrationDepthTable() -    "       "         "       depth  "     "     "     "
    '
    ' Inputs:   HydrusTable - DataTable of HYDRUS data imported from T_LEVEL.OUT file
    '
    ' Returns:  DataTable   - WinSRFR table of just the infiltration rate/depth data
    '
    ' Note - HYDRUS' Time is WinSRFR's Tau
    '*********************************************************************************************************
    Protected Function ExtractInfiltrationRateTable(ByVal HydrusTable As DataTable) As DataTable
        ExtractInfiltrationRateTable = Nothing

        ' Verify input HYDRUS Table contains the correct data to generate a WinSRFR Infiltration Table
        If (HydrusTable IsNot Nothing) Then
            If (0 < HydrusTable.Rows.Count) Then
                If ((HydrusTable.Columns.Contains(Hydrus1D.TimeT)) _
                And (HydrusTable.Columns.Contains("vTop [m/s]"))) Then ' HYDRUS infiltration data available

                    Dim hydrusRow As DataRow = HydrusTable.Rows(0)
                    Dim T0 As Double = CDbl(hydrusRow.Item(Hydrus1D.TimeT))

                    ' Instantiate WinSRFR Infiltration Rate table
                    Dim WinSrfrTable As DataTable = New DataTable("HYDRUS Infiltration Rate")
                    WinSrfrTable.Columns.Add("Tau (sec)", GetType(Double))
                    WinSrfrTable.Columns.Add("Inf. Rate (m/s)", GetType(Double))

                    ' Extract infiltration rate data from HYDRUS table into WinSRFR table
                    For Each hydrusRow In HydrusTable.Rows
                        Dim Tn As Double = CDbl(hydrusRow.Item(Hydrus1D.TimeT))

                        Dim winSrfrRow As DataRow = WinSrfrTable.NewRow
                        winSrfrRow.Item("Tau (sec)") = Tn - T0 + OneMinute
                        winSrfrRow.Item("Inf. Rate (m/s)") = Math.Abs(CDbl(hydrusRow.Item("vTop [m/s]")))

                        WinSrfrTable.Rows.Add(winSrfrRow)
                    Next

                    ExtractInfiltrationRateTable = WinSrfrTable
                End If
            End If
        End If

    End Function

    Protected Function ExtractInfiltrationDepthTable(ByVal HydrusTable As DataTable) As DataTable
        ExtractInfiltrationDepthTable = Nothing

        ' Verify input HYDRUS Table contains the correct data to generate a WinSRFR Infiltration Table
        If (HydrusTable IsNot Nothing) Then
            If (0 < HydrusTable.Rows.Count) Then
                If ((HydrusTable.Columns.Contains(Hydrus1D.TimeT)) _
                And (HydrusTable.Columns.Contains(Hydrus1D.SumVtopL))) Then ' HYDRUS infiltration data available

                    Dim hydrusRow As DataRow = HydrusTable.Rows(0)
                    Dim T0 As Double = CDbl(hydrusRow.Item(Hydrus1D.TimeT))

                    ' Instantiate WinSRFR Infiltration Depth table
                    Dim WinSrfrTable As DataTable = New DataTable("HYDRUS Infiltration Depth")
                    WinSrfrTable.Columns.Add("Tau (sec)", GetType(Double))
                    WinSrfrTable.Columns.Add("Inf. Depth (m)", GetType(Double))

                    Dim Tau0 As Double = 0.0
                    Dim Dinf0 As Double = 0.0

                    ' Extract infiltration rate data from HYDRUS table into WinSRFR table
                    For Each hydrusRow In HydrusTable.Rows

                        Dim Tau As Double = CDbl(hydrusRow.Item(Hydrus1D.TimeT))
                        Dim Dinf As Double = Math.Abs(CDbl(hydrusRow.Item(Hydrus1D.SumVtopL)))

                        ' Ensure Tau (opp. time) & Dinf (infiltrated depth) increase row-by-row
                        If ((Tau0 < Tau) And (Dinf0 <= Dinf)) Then
                            Dim winSrfrRow As DataRow = WinSrfrTable.NewRow

                            winSrfrRow.Item("Tau (sec)") = Tau - T0 + OneMinute
                            winSrfrRow.Item("Inf. Depth (m)") = Dinf

                            WinSrfrTable.Rows.Add(winSrfrRow)

                            Tau0 = Tau
                            Dinf0 = Dinf
                        End If
                    Next

                    ExtractInfiltrationDepthTable = WinSrfrTable
                End If
            End If
        End If

    End Function

    '*********************************************************************************************************
    ' Function ExtractSubsurfaceProfiles() - extract subsurface profiles table from HYDRUS tables
    '
    ' Inputs:   HydrusTables - DataSet of HYDRUS data imported from NOD_INF.OUT file
    '
    ' Returns:  DataTable   - WinSRFR table of just the final concentration data
    '*********************************************************************************************************
    Protected Function ExtractConcentrationTable(ByVal HydrusTables As DataSet) As DataTable
        ExtractConcentrationTable = Nothing

        ' Verify input HYDRUS Table contains the correct data to generate a WinSRFR Profiles Table
        If (HydrusTables IsNot Nothing) Then
            Dim numTables As Integer = HydrusTables.Tables.Count
            If (1 < numTables) Then

                Dim table0 As DataTable = HydrusTables.Tables(0)
                If ((table0.Columns.Contains(Hydrus1D.DepthL)) _
                And (table0.Columns.Contains(Hydrus1D.Moisture))) Then ' HYDRUS profile data available

                    Dim table1 As DataTable = HydrusTables.Tables(numTables - 1)
                    If ((table1.Columns.Contains(Hydrus1D.DepthL)) _
                    And (table1.Columns.Contains(Hydrus1D.Moisture))) Then ' HYDRUS profile data available

                        If (table0.Rows.Count = table1.Rows.Count) Then

                            ' Instantiate WinSRFR Profiles table
                            Dim WinSrfrTable As DataTable = New DataTable("HYDRUS Profiles")
                            WinSrfrTable.Columns.Add(sDepthX, GetType(Double))
                            WinSrfrTable.Columns.Add(sMoistureX, GetType(Double))
                            WinSrfrTable.Columns.Add(sNewMoistureX, GetType(Double))

                            If (table1.Columns.Contains(Hydrus1D.ConcML3)) Then ' Concentration data available
                                WinSrfrTable.Columns.Add(sConcentrationXgpl, GetType(Double))
                            End If

                            For rdx As Integer = 0 To table1.Rows.Count - 1

                                Dim row0 As DataRow = table0.Rows(rdx)    ' Original values
                                Dim row1 As DataRow = table1.Rows(rdx)    ' Final      "

                                Dim WinSrfrRow As DataRow = WinSrfrTable.NewRow

                                ' HYDRUS infiltration depth's are negative values; make them positive for WinSRFR
                                Dim Depth1 As Double = -row1.Item(Hydrus1D.DepthL)

                                WinSrfrRow.Item(sDepthX) = Depth1

                                ' HYDRUS moisture values are totals including what was already in profile
                                Dim Moisture0 As Double = row0.Item(Hydrus1D.Moisture)
                                Dim Moisture1 As Double = row1.Item(Hydrus1D.Moisture)

                                WinSrfrRow.Item(sMoistureX) = Moisture1

                                ' Subtract original soil moisture from final soil moisture for irrigation contribution
                                Dim NewMoisture As Double = Moisture1 - Moisture0
                                WinSrfrRow.Item(sNewMoistureX) = NewMoisture

                                If (table1.Columns.Contains(Hydrus1D.ConcML3)) Then ' Concentration data available
                                    Dim Co As Double = row1.Item(Hydrus1D.ConcML3)
                                    WinSrfrRow.Item(sConcentrationXgpl) = Co
                                End If

                                WinSrfrTable.Rows.Add(WinSrfrRow)

                            Next

                            ExtractConcentrationTable = WinSrfrTable

                        End If ' # rows match
                    End If ' Table 1 OK
                End If ' Table 0 OK
            End If ' At least 2 tables
        End If ' Input DataSet is not nothing

    End Function

#End Region

#End Region

#Region " Analysis Execution "

    '*********************************************************************************************************
    ' Get parameters required for most Analyses' runs
    '*********************************************************************************************************
    Protected Sub GetUnitParameters()

        ' System Geometry
        S0 = mSystemGeometry.AverageSlope

        k = mSoilCropProperties.KostiakovK
        a = mSoilCropProperties.KostiakovA
        b = mSoilCropProperties.KostiakovB
        c = mSoilCropProperties.KostiakovC

        n = mSoilCropProperties.ManningN.Value

    End Sub

    '*********************************************************************************************************
    ' Sub GetContourParameters()    - Get parameters required to generate contours
    '
    ' Get Unit parameters used to generate the Design & Operations contours.  Includes Solution Point values
    ' as well as contour values (min, max range) for X & Y axes
    '*********************************************************************************************************
    Protected Sub GetContourParameters()

        ' System geometry
        mLength = mSystemGeometry.Length.Value
        mWidth = mSystemGeometry.Width.Value

        ' Inflow management
        mInflowRate = mInflowManagement.InflowRate.Value

        mCutbackMethod = mInflowManagement.CutbackMethod.Value
        mCutbackRateRatio = mInflowManagement.CutbackRateRatio.Value
        mCutbackRate = mInflowRate * mCutbackRateRatio

        mTco = mInflowManagement.CutoffTime.Value
        mCutbackTimeRatio = mInflowManagement.CutbackTimeRatio.Value
        If (Double.IsNaN(mCutbackTimeRatio)) Then
            Dim _param As DoubleParameter = mInflowManagement.CutbackTimeRatio
            _param.Value = DefaultCutbackTimeRatio
            _param.Source = ValueSources.Defaulted
            mInflowManagement.CutbackTimeRatio = _param
            mCutbackTimeRatio = mInflowManagement.CutbackTimeRatio.Value
        End If
        mCutbackTimeRatio = Math.Min(mCutbackTimeRatio, 1.0)
        mTcb = mTco * mCutbackTimeRatio

        ' Contour grid points / cells
        mMinLength = Math.Max(mBorderCriteria.MinContourLength.Value, OneMeter)
        mMaxLength = Math.Max(mBorderCriteria.MaxContourLength.Value, mMinLength + OneMeter)
        mLengthRange = mMaxLength - mMinLength

        mMinWidth = Math.Max(mBorderCriteria.MinContourWidth.Value, OneCentimeter)
        mMaxWidth = Math.Max(mBorderCriteria.MaxContourWidth.Value, mMinWidth + OneMeter)
        mWidthRange = mMaxWidth - mMinWidth

        mMinInflowRate = Math.Max(mBorderCriteria.MinContourInflowRate.Value, 0.1 * LiterPerSecond)
        mMaxInflowRate = Math.Max(mBorderCriteria.MaxContourInflowRate.Value, mMinInflowRate + 0.1 * LiterPerSecond)
        mInflowRateRange = mMaxInflowRate - mMinInflowRate

        mMinCutoffTime = Math.Max(mBorderCriteria.MinContourCutoffTime.Value, OneMinute)
        mMaxCutoffTime = Math.Max(mBorderCriteria.MaxContourCutoffTime.Value, mMinCutoffTime + OneMinute)
        mCutoffTimeRange = mMaxCutoffTime - mMinCutoffTime

        mMinCutoffRatio = Math.Max(mBorderCriteria.MinContourCutoffLocationRatio.Value, 0.1)
        mMaxCutoffRatio = Math.Max(mBorderCriteria.MaxContourCutoffLocationRatio.Value, mMinCutoffRatio + 0.1)
        mCutoffRatioRange = mMaxCutoffRatio - mMinCutoffRatio

    End Sub

    '*********************************************************************************************************
    ' Common code to start many analyses' runs; used in conjunction with EndRun()
    '*********************************************************************************************************
    Public Overridable Sub StartRun(ByVal SimName As String, ByVal contourRun As Boolean)

        ' Save the Simulation's Name
        Dim srfrID As StringParameter = mUnit.SrfrID
        srfrID.Value = SimName
        mUnit.SrfrID = srfrID

        ' Set running state
        Me.Running = True
        Me.StatusMessage = mDictionary.tStartingCalculations.Translated & ": " & SimName
        Me.RunProgress = 0

        ' Get Unit parameters
        GetUnitParameters()

        ' Get contour parameters, if necessary
        If (contourRun) Then
            '
            ' Get Unit parameters used to generate the Design & Operations contours
            '
            GetContourParameters()
            '
            ' Generate values for contour grid
            '
            Select Case (mBorderCriteria.GridResolution.Value)
                Case ResolutionSelections.FineResolution
                    mNumGridCellsX = 40
                    mNumGridCellsY = 40
                Case ResolutionSelections.MediumResolution
                    mNumGridCellsX = 20
                    mNumGridCellsY = 20
                Case Else 'Assume ResolutionSelections.CoarseResolution
                    mNumGridCellsX = 10
                    mNumGridCellsY = 10
            End Select

            ReDim mLengths(mNumGridCellsX)
            ReDim mWidths(mNumGridCellsY)
            ReDim mCutoffTimes(mNumGridCellsX)
            ReDim mCutoffRatios(mNumGridCellsX)
            ReDim mInflowRates(mNumGridCellsY)

            mNumLengths = Lengths.Length
            mNumWidths = Widths.Length
            mNumCutoffTimes = CutoffTimes.Length
            mNumCutoffRatios = CutoffRatios.Length
            mNumInflowRates = InflowRates.Length

            For idx As Integer = 0 To mNumLengths - 1
                mLengths(idx) = mMinLength + (mLengthRange * (idx / (mNumLengths - 1)))
            Next

            For idx As Integer = 0 To mNumWidths - 1
                mWidths(idx) = mMinWidth + (mWidthRange * (idx / (mNumWidths - 1)))
            Next

            For idx As Integer = 0 To mNumCutoffTimes - 1
                mCutoffTimes(idx) = mMinCutoffTime + (mCutoffTimeRange * (idx / (mNumCutoffTimes - 1)))
            Next

            For idx As Integer = 0 To mNumCutoffRatios - 1
                mCutoffRatios(idx) = mMinCutoffRatio + (mCutoffRatioRange * (idx / (mNumCutoffRatios - 1)))
            Next

            For idx As Integer = 0 To mNumInflowRates - 1
                mInflowRates(idx) = mMinInflowRate + (mInflowRateRange * (idx / (mNumInflowRates - 1)))
            Next
        End If

        ' Increment Run Count
        Dim runCount As IntegerParameter = mUnit.UnitControlRef.RunCount
        runCount.Value = runCount.Value + 1
        runCount.Source = ValueSources.Calculated
        mUnit.UnitControlRef.RunCount = runCount

        ' Set Application Name & Version for this Run
        Dim appName As StringParameter = mUnit.UnitControlRef.ProductName
        If Not (appName.Value = Application.ProductName) Then
            appName.Value = Application.ProductName
            appName.Source = ValueSources.Calculated
            mUnit.UnitControlRef.ProductName = appName
        End If

        Dim appVersion As StringParameter = mUnit.UnitControlRef.ProductVersion
        If Not (appVersion.Value = Application.ProductVersion) Then
            appVersion.Value = Application.ProductVersion
            appVersion.Source = ValueSources.Calculated
            mUnit.UnitControlRef.ProductVersion = appVersion
        End If

        ' Clear previously calculated results - be careful not to clear Analysis' specific results
        mUnit.SurfaceFlowRef.ClearResults()
        mUnit.SubsurfaceFlowRef.ClearResults()
        mUnit.FertigationRef.ClearResults()
        mUnit.ErosionRef.ClearResults()

    End Sub

    '*********************************************************************************************************
    ' Common code to end many analyses' runs; used in conjunction with StartRun()
    '*********************************************************************************************************
    Public Overridable Sub EndRun()

        ' Compute Run Time before Log update; save Run Time last
        Dim runTime As DateTimeParameter = mUnit.UnitControlRef.RunDateTime
        runTime.Value = System.DateTime.Now
        runTime.Source = DataStore.Globals.ValueSources.Calculated

        ' Update the Log
        Dim log As ArrayListParameter = mUnit.UnitControlRef.Log
        If (log IsNot Nothing) Then

            Dim warningCount As Integer = SetupWarningItems.Count + ExecutionWarningItems.Count
            If (0 < warningCount) Then
                log.Array.Insert(0, "   " & warningCount.ToString & " " & mDictionary.tWarnings.Translated)
            Else
                log.Array.Insert(0, "   " & mDictionary.tNoWarnings.Translated)
            End If

            Dim errorCount As Integer = SetupErrorItems.Count + ExecutionErrorItems.Count
            If (0 < errorCount) Then
                log.Array.Insert(0, "   " & errorCount.ToString & " " & mDictionary.tErrors.Translated)
            Else
                log.Array.Insert(0, "   " & mDictionary.tNoErrors.Translated)
            End If

            log.Array.Insert(0, "Simulation run by " & mUnit.UnitControlRef.ProductVersion.Value & " at - " _
                                        & runTime.Value.ToLongDateString & " " & runTime.Value.ToLongTimeString)

            ' Limit log to the last 5 runs (3 lines per run)
            While (15 < log.Array.Count)
                log.Array.RemoveAt(log.Array.Count - 1)
            End While

            log.Source = DataStore.Globals.ValueSources.Calculated

            mUnit.UnitControlRef.Log = log

        End If

        ' Save the Run Time last
        '   DataHasChangedSince() uses the Run Time to track subsequent input changes
        mUnit.UnitControlRef.RunDateTime = runTime

        ' Clear running state
        Me.RunProgress = 0
        Me.StatusMessage = mDictionary.tSimulationComplete.Translated
        Me.Running = False

        If (mWorldWindow IsNot Nothing) Then
            mWorldWindow.UpdateResultsControls()
        End If

    End Sub

    Public Overridable Sub CheckOverflow()
        ' Check for Overflow
        Dim overDist, overTime As Double
        If (SrfrIrrigation IsNot Nothing) Then
            If (SrfrIrrigation.Overflow(overDist, overTime)) Then
                Dim title As String = mDictionary.tSimulationResults.Translated
                Dim msg As String = mDictionary.tWrnOverflowCondition.Translated
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
            End If
        End If
    End Sub

#End Region

#Region " Contours "

#Region " Major / Minor Contours "

    '*********************************************************************************************************
    ' Scale contour ranges based on contour grid data
    '
    ' Sub ScaleDapp()   - Application Depth
    ' Sub ScaleDlf()    - Low-Quarter / Minimum Depth
    ' Sub ScaleTco()    - Cutoff Time
    ' Sub ScaleTxa()    - Maximum Advance Time
    ' Sub ScaleCost()   - Application Cost
    '*********************************************************************************************************
    Protected Sub ScaleDapp()
        Dim depthUnits As Units = mUnitsSystem.DepthUnits

        ' Find min / max / range of values from contour grid (SI units)
        Dim minDapp, maxDapp As Single
        Dim rangeDapp As Single = mContourGrid.RangeValues(DappIndex, True, minDapp, maxDapp)

        ' If valid range was found, scale it; otherwise set to maximum
        Dim majorTick, minorTick As Single
        If (Single.IsNaN(rangeDapp)) Then
            ' Set scale in User units
            minDapp = 0

            If (depthUnits = DataStore.Units.Inches) Then
                majorTick = 2        '  2 in
            Else ' Assume mm
                majorTick = 50       ' 50 mm
            End If
        Else
            ' Convert SI range to User units
            rangeDapp = CSng(UnitDepth(rangeDapp, depthUnits))

            ' Scale to 1-2-5 range in User units
            Dim scaleDapp As Single = Scale125(rangeDapp, majorTick, minorTick)

            ' Limit scale
            If (depthUnits = DataStore.Units.Inches) Then
                majorTick = CSng(Math.Max(majorTick, 0.1))      ' Min .1 in
                majorTick = CSng(Math.Min(majorTick, 2))        ' Max  2 in
            Else ' Assume mm
                majorTick = CSng(Math.Max(majorTick, 5))        ' Min  5 mm
                majorTick = CSng(Math.Min(majorTick, 50))       ' Max 50 mm
            End If
        End If

        ' Convert range back to SI units
        majorTick = CSng(SiDepth(majorTick, depthUnits))

        ' Calculate new Major contour levels is SI units
        minDapp = CInt(Math.Floor(minDapp / majorTick)) * majorTick

        ReDim mMajor10LevelDapps(mNumMajor10Levels - 1)
        For major As Integer = 0 To mMajor10LevelDapps.GetUpperBound(0)
            mMajor10LevelDapps(major) = minDapp + (major * majorTick)
        Next

        ' Calculate new Minor contour levels in SI units
        minDapp -= (majorTick / 2)

        ReDim mMinor10LevelDapps(mNumMinor10Levels - 1)
        For minor As Integer = 0 To mMinor10LevelDapps.GetUpperBound(0)
            mMinor10LevelDapps(minor) = minDapp + (minor * majorTick)
        Next

    End Sub

    Protected Sub ScaleDlf()
        Dim depthUnits As Units = mUnitsSystem.DepthUnits

        ' Find min / max / range of values from contour grid (SI units)
        Dim minDlf, maxDlf As Single
        Dim rangeDlf As Single = mContourGrid.RangeValues(DLfIndex, True, minDlf, maxDlf)

        ' If valid range was found, scale it; otherwise set to maximum
        Dim majorTick, minorTick As Single
        If (Single.IsNaN(rangeDlf)) Then
            ' Set scale in User units
            minDlf = 0

            If (depthUnits = DataStore.Units.Inches) Then
                majorTick = 2        '  2 in
            Else ' Assume mm
                majorTick = 50       ' 50 mm
            End If
        Else
            ' Convert SI range to User units
            rangeDlf = CSng(UnitDepth(rangeDlf, depthUnits))

            ' Scale to 1-2-5 range in User units
            Dim scaleDlf As Single = Scale125(rangeDlf, majorTick, minorTick)

            ' Limit scale
            If (depthUnits = DataStore.Units.Inches) Then
                majorTick = CSng(Math.Max(majorTick, 0.1))      ' Min .1 in
                majorTick = CSng(Math.Min(majorTick, 2))        ' Max  2 in
            Else ' Assume mm
                majorTick = CSng(Math.Max(majorTick, 5))        ' Min  5 mm
                majorTick = CSng(Math.Min(majorTick, 50))       ' Max 50 mm
            End If
        End If

        ' Convert range back to SI units
        majorTick = CSng(SiDepth(majorTick, depthUnits))

        ' Calculate new Major contour levels
        minDlf = CInt(Math.Floor(minDlf / majorTick)) * majorTick

        ReDim mMajor10LevelDlfs(mNumMajor10Levels - 1)
        For major As Integer = 0 To mMajor10LevelDlfs.GetUpperBound(0)
            mMajor10LevelDlfs(major) = minDlf + (major * majorTick)
        Next

        ' Calculate new Minor contour levels
        minDlf -= (majorTick / 2)

        ReDim mMinor10LevelDlfs(mNumMinor10Levels - 1)
        For minor As Integer = 0 To mMinor10LevelDlfs.GetUpperBound(0)
            mMinor10LevelDlfs(minor) = minDlf + (minor * majorTick)
        Next

    End Sub

    Protected Sub ScaleTco()
        Dim timeUnits As Units = mUnitsSystem.TimeUnits

        ' Find min / max / range of values from contour grid (SI units)
        Dim minTco, maxTco As Single
        Dim rangeTco As Single = mContourGrid.RangeValues(TcoIndex, True, minTco, maxTco)

        ' If valid range was found, scale it; otherwise set to maximum
        Dim majorTick, minorTick As Single
        If (Single.IsNaN(rangeTco)) Then
            ' Set scale in User units
            minTco = 0
            majorTick = 5           ' 5 hr
        Else
            ' Convert SI range to User units
            rangeTco = CSng(UnitTime(rangeTco, DataStore.Units.Hours))

            ' Scale to 1-2-5 range in User units
            Dim scaleTco As Single = Scale125(rangeTco, majorTick, minorTick)

            ' Limit scale
            'majorTick = CSng(Math.Max(majorTick, 1))    ' Min 1 hr
            majorTick = CSng(Math.Min(majorTick, 5))    ' Max 5 hr
        End If

        ' Convert range back to SI units
        majorTick = CSng(SiTime(majorTick, DataStore.Units.Hours))

        ' Calculate new Major contour levels
        minTco = CInt(Math.Floor(minTco / majorTick)) * majorTick

        ReDim mMajor10TcoValues(mNumMajor10Levels - 1)
        For major As Integer = 0 To mMajor10TcoValues.GetUpperBound(0)
            mMajor10TcoValues(major) = minTco + (major * majorTick)
        Next

        ' Calculate new Minor contour levels
        minTco -= (majorTick / 2)

        ReDim mMinor10TcoValues(mNumMinor10Levels - 1)
        For minor As Integer = 0 To mMinor10TcoValues.GetUpperBound(0)
            mMinor10TcoValues(minor) = minTco + (minor * majorTick)
        Next

    End Sub

    Protected Sub ScaleTxa()
        Dim timeUnits As Units = mUnitsSystem.TimeUnits

        ' Find min / max / range of values from contour grid (SI units)
        Dim minTxa, maxTxa As Single
        Dim rangeTxa As Single = mContourGrid.RangeValues(TxaIndex, True, minTxa, maxTxa)

        ' If valid range was found, scale it; otherwise set to maximum
        Dim majorTick, minorTick As Single
        If (Single.IsNaN(rangeTxa)) Then
            ' Set scale in User units
            minTxa = 0
            majorTick = 5           ' 5 hr
        Else
            ' Convert SI range to User units
            rangeTxa = CSng(UnitTime(rangeTxa, DataStore.Units.Hours))

            ' Scale to 1-2-5 range in User units
            Dim scaleTxa As Single = Scale125(rangeTxa, majorTick, minorTick)

            ' Limit scale
            'majorTick = CSng(Math.Max(majorTick, 1))    ' Min 1 hr
            majorTick = CSng(Math.Min(majorTick, 5))    ' Max 5 hr
        End If

        ' Convert range back to SI units
        majorTick = CSng(SiTime(majorTick, DataStore.Units.Hours))

        ' Calculate new Major contour levels
        minTxa = CInt(Math.Floor(minTxa / majorTick)) * majorTick

        ReDim mMajor10TxaValues(mNumMajor10Levels - 1)
        For major As Integer = 0 To mMajor10TxaValues.GetUpperBound(0)
            mMajor10TxaValues(major) = minTxa + (major * majorTick)
        Next

        ' Calculate new Minor contour levels
        minTxa -= (majorTick / 2)

        ReDim mMinor10TxaValues(mNumMinor10Levels - 1)
        For minor As Integer = 0 To mMinor10TxaValues.GetUpperBound(0)
            mMinor10TxaValues(minor) = minTxa + (minor * majorTick)
        Next

    End Sub

    Protected Sub ScaleCost()
        Dim costUnits As Units = mUnitsSystem.WaterCostAreaUnits

        ' Find min / max / range of values from contour grid (SI units)
        Dim minCost, maxCost As Single
        Dim rangeCost As Single = mContourGrid.RangeValues(CostIndex, True, minCost, maxCost)

        ' If valid range was found, scale it; otherwise set to maximum
        Dim majorTick, minorTick As Single
        If (Single.IsNaN(rangeCost)) Then
            ' Set scale in User units
            minCost = 0
            majorTick = 100
        Else
            ' Convert SI range to User units
            rangeCost = CSng(UnitWaterCostArea(rangeCost, costUnits))

            ' Scale to 1-2-5 range in User units
            Dim scaleCost As Single = Scale125(rangeCost, majorTick, minorTick)

            ' Limit scale
            If (costUnits = DataStore.Units.DollarsPerAcre) Then
                majorTick = CSng(Math.Max(majorTick, 1))        ' Min $1
                majorTick = CSng(Math.Min(majorTick, 20))       ' Max $20
            Else ' Assume DollarsPerHectare
                majorTick = CSng(Math.Max(majorTick, 2))        ' Min $2
                majorTick = CSng(Math.Min(majorTick, 40))       ' Max $40
            End If
        End If

        ' Convert range back to SI units
        majorTick = CSng(SiWaterCostArea(majorTick, costUnits))

        ' Calculate new Major contour levels is SI units
        minCost = CInt(Math.Floor(minCost / majorTick)) * majorTick

        ReDim mMajor10LevelsCost(mNumMajor10Levels - 1)
        For major As Integer = 0 To mMajor10LevelsCost.GetUpperBound(0)
            mMajor10LevelsCost(major) = minCost + (major * majorTick)
        Next

        ' Calculate new Minor contour levels in SI units
        minCost -= (majorTick / 2)

        ReDim mMinor10LevelsCost(mNumMinor10Levels - 1)
        For minor As Integer = 0 To mMinor10LevelsCost.GetUpperBound(0)
            mMinor10LevelsCost(minor) = minCost + (minor * majorTick)
        Next

    End Sub

    '*********************************************************************************************************
    ' Sub BuildMajorContours()  - Build Major Contours based on Contour Grid
    ' Sub BuildMinorContours()  -   "   Minor     "      "    "    "      "
    '
    ' Input(s):     name        - contour name
    '               symbol      - symbol for name
    '               idx         - contour index
    '               values()    - contour values
    '               zTolerance  - tolerence for making real number comparisons
    '               units       - units for contour
    '               biggerIsBetter  - are bigger values better (e.g. PAE - yes, runoff - no)
    '*********************************************************************************************************
    Protected Sub BuildMajorContours(ByVal name As String, ByVal symbol As String,
            ByVal idx As Integer, ByVal values() As Single, ByVal zTolerance As Single,
            ByVal units As DataStore.Units, ByVal biggerIsBetter As Boolean)

        Dim polygons As ContourPolygons

        Dim loVal As Single = values(0)
        Dim hiVal As Single = values(values.Length - 1)
        Dim level As Integer = 0

        Me.StatusMessage = mDictionary.tCalculatingMajorContours.Translated & ": " & name

        ' Build all but the last contour level
        For cdx As Integer = 0 To values.Length - 2
            loVal = values(cdx)
            hiVal = values(cdx + 1)

            If (biggerIsBetter) Then
                level = cdx
            Else
                level = values.Length - 1 - cdx
            End If

            polygons = mContourGrid.BuildValueContours(name, symbol, idx, loVal, hiVal,
                            zTolerance, units, level, biggerIsBetter)

            mContourGrid.MajorContours.Add(polygons)

            Me.RunProgress = CInt((100 * (cdx + 1)) / values.Length)
        Next

        ' Build the last contour level; note use of Single.NaN
        If (biggerIsBetter) Then
            level = values.Length - 1
        Else
            level = 0
        End If

        polygons = mContourGrid.BuildValueContours(name, symbol, idx, hiVal, Single.NaN,
                            zTolerance, units, level, biggerIsBetter)

        mContourGrid.MajorContours.Add(polygons)

        ' Build the error contour
        polygons = mContourGrid.BuildErrorContours(name, symbol, idx, loVal, hiVal,
                            zTolerance, units, level, biggerIsBetter)

        mContourGrid.ErrorContours.Add(polygons)

        Me.RunProgress = 100

    End Sub

    Protected Sub BuildMinorContours(ByVal name As String, ByVal symbol As String,
            ByVal idx As Integer, ByVal values() As Single, ByVal zTolerance As Single,
            ByVal units As DataStore.Units, ByVal biggerIsBetter As Boolean)

        Dim polygons As ContourPolygons

        Dim loVal As Single = values(0)
        Dim hiVal As Single = values(values.Length - 1)
        Dim level As Integer = 0

        Me.StatusMessage = mDictionary.tCalculatingMinorContours.Translated & ": " & name

        ' Build all but the last contour level
        For cdx As Integer = 0 To values.Length - 2
            loVal = values(cdx)
            hiVal = values(cdx + 1)

            polygons = mContourGrid.BuildValueContours(name, symbol, idx, loVal, hiVal,
                                zTolerance, units, level, biggerIsBetter)

            mContourGrid.MinorContours.Add(polygons)

            Me.RunProgress = CInt((100 * (cdx + 1)) / values.Length)
        Next

        ' Build the last contour level; note use of Single.NaN
        polygons = mContourGrid.BuildValueContours(name, symbol, idx, hiVal, Single.NaN,
                            zTolerance, units, level, biggerIsBetter)

        mContourGrid.MinorContours.Add(polygons)

        Me.RunProgress = 100

    End Sub

    '*********************************************************************************************************
    ' Sub BuildValueCurve()     - Build Value Curve based on Contour Grid
    '
    ' Input(s):     name        - contour name
    '               symbol      - symbol for name
    '               idx         - contour index
    '               value       - curve value
    '               zTolerance  - tolerence for making real number comparisons
    '               units       - units for contour
    '*********************************************************************************************************
    Protected Sub BuildValueCurve(ByVal name As String, ByVal symbol As String,
            ByVal idx As Integer, ByVal value As Single, ByVal zTolerance As Single,
            ByVal units As DataStore.Units)

        Dim polygons As ContourPolygons

        Me.StatusMessage = mDictionary.tCalculatingValueCurve.Translated & ": " & name

        polygons = mContourGrid.BuildValueCurve(name, symbol, idx, value, Single.NaN,
                            zTolerance, units, 0, False)

        mContourGrid.ContourCurve = polygons

        Me.RunProgress = 100

    End Sub

#End Region

#Region " Value Contour Point "

    '*********************************************************************************************************
    ' Determine if the 'value' of parameter 'idx' has already been calculated
    '        OR if the 'value' lies between two already calculated points.
    '
    '   If matching value is found, return that point and TRUE
    '   If not, return bounding points and FALSE 
    '
    '   aX, aY, aZ  - XYZ values for the starting point of a line
    '   bX, bY, bZ  - XYZ values for the ending point of a line
    '   idx         - index of the Z parameter value
    '   zValue      - Z parameter value to be recalled
    '*********************************************************************************************************
    Private Function RecallValuePoint(
                ByRef aX As Single, ByRef aY As Single, ByRef aZ As Single,
                ByRef bX As Single, ByRef bY As Single, ByRef bZ As Single,
                ByVal idx As Integer, ByVal zValue As Single, ByVal zTolerance As Single,
                ByRef c As ContourPoint) As Boolean

        ' If Line List does not exist; nothing to search
        If (mLineList Is Nothing) Then
            Return False
        End If

        ' If Line List is empty; nothing to search
        If (0 = mLineList.Count) Then
            Return False
        End If

        ' Sort a & b - lines in list are sorted by increasing XY position
        Dim reverse As Boolean = False
        If (bX < aX) Then
            reverse = True
            Swap(aX, bX)
            Swap(aY, bY)
            Swap(aZ, bZ)
        ElseIf (bX = aX) Then
            If (bY < aY) Then
                reverse = True
                Swap(aX, bX)
                Swap(aY, bY)
                Swap(aZ, bZ)
            End If
        End If

        Dim aI As Integer = 0
        Dim bI As Integer = mLineList.Count

        ' Binary search for line in list, if one exists
        While (True)
            ' Next line is halfway between current lines
            Dim cI As Integer = (aI + bI) >> 1

            ' If search point goes beyond the end of the line; line was not found
            If (mLineList.Count <= cI) Then
                Exit While
            End If

            ' Get the next line to examine
            Dim line As ArrayList = DirectCast(mLineList(cI), ArrayList)

            ' Get first point in line
            c = DirectCast(line(0), ContourPoint)
            Dim cX As Single = c.X.Value
            Dim cY As Single = c.Y.Value
            Dim cZ As Single

            ' Does a match first point in line?
            If (cX < aX) Then
                aI = cI ' Line toward end of list; move start to midpoint
            ElseIf (aX < cX) Then
                bI = cI ' Line toward start of list; move end to midpoint
            Else ' (aX = cX)
                ' X values match; do Y values match?
                If (cY < aY) Then
                    aI = cI ' Line toward end of list; move start to midpoint
                ElseIf (aY < cY) Then
                    bI = cI ' Line toward start of list; move end to midpoint
                Else ' (aY = cY)
                    ' a matches first point in line; does b match last point?
                    c = DirectCast(line(line.Count - 1), ContourPoint)
                    cX = c.X.Value
                    cY = c.Y.Value

                    If (cX < bX) Then
                        aI = cI ' Line toward end of list; move start to midpoint
                    ElseIf (bX < cX) Then
                        bI = cI ' Line toward start of list; move end to midpoint
                    Else ' (bX = cX)
                        ' b's X matches first point's X value; does Y match?
                        If (cY < bY) Then
                            bI = cI ' Line toward end of list; move start to midpoint
                        ElseIf (bY < cY) Then
                            bI = cI ' Line toward start of list; move end to midpoint
                        Else ' (bY = cY)
                            ' b matches last point in line; this is the line!

                            ' Perform a linear search looking for requested z value
                            '
                            ' Note - line is sorted by increasing contour position, not z value.
                            '        Z values are not necessarily monotonic along the line!

                            ' Check interior points within line first
                            For cdx As Integer = 1 To line.Count - 2
                                c = DirectCast(line(cdx), ContourPoint)
                                cX = c.X.Value
                                cY = c.Y.Value
                                cZ = DirectCast(c.Z(idx), SingleParameter).Value

                                If ((zValue <= cZ) And (cZ <= zValue + zTolerance)) Then
                                    Return True
                                End If
                            Next

                            ' Check end points last (note - zTolerance is not used)
                            c = DirectCast(line(0), ContourPoint) ' first point
                            cX = c.X.Value
                            cY = c.Y.Value
                            cZ = DirectCast(c.Z(idx), SingleParameter).Value

                            If (zValue = cZ) Then
                                Return True
                            End If

                            c = DirectCast(line(line.Count - 1), ContourPoint) ' last point
                            cX = c.X.Value
                            cY = c.Y.Value
                            cZ = DirectCast(c.Z(idx), SingleParameter).Value

                            If (zValue = cZ) Then
                                Return True
                            End If

                            Exit While
                        End If
                    End If
                End If
            End If

            ' Check for end conditions
            If (aI = bI) Then
                Exit While ' End lines are the same; nothing was found
            ElseIf (aI = bI - 1) Then
                aI = bI ' End lines are adjacent; make sure last line is checked
            End If
        End While

        ' Nothing was found; put input values back in order, if necessary
        If (reverse) Then
            Swap(aX, bX)
            Swap(aY, bY)
            Swap(aZ, bZ)
        End If

        Return False
    End Function

    '*********************************************************************************************************
    ' Store a point in a line in the Line List
    '
    ' Store point c on line with end points a & b
    '*********************************************************************************************************
    Private Sub StoreValuePoint(ByVal a As ContourPoint, ByVal b As ContourPoint,
                                ByVal c As ContourPoint, ByVal overwrite As Boolean)

        ' Uncomment 'Return' to disable optimization
        'Return ' Disable optimization

        ' If Line List does not exist; create it
        If (mLineList Is Nothing) Then
            mLineList = New ArrayList
        End If

        Dim line As ArrayList

        ' Get XY values from points
        Dim aI As Integer = 0
        Dim aX As Single = a.X.Value
        Dim aY As Single = a.Y.Value

        Dim bI As Integer = mLineList.Count
        Dim bX As Single = b.X.Value
        Dim bY As Single = b.Y.Value

        Dim cX As Single = c.X.Value
        Dim cY As Single = c.Y.Value

        ' Sort a & b - lines in list are sorted by increasing XY position
        Dim reverse As Boolean = False
        If (bX < aX) Then
            reverse = True
            Swap(aX, bX)
            Swap(aY, bY)
        ElseIf (bX = aX) Then
            If (bY < aY) Then
                reverse = True
                Swap(aX, bX)
                Swap(aY, bY)
            End If
        End If

        ' Verify c is on line a-b
        If ((cX < aX) Or (bX < cX)) Then
            Debug.Assert(False)
        End If

        If (aX = bX) Then
            If ((cY < aY) Or (bY < cY)) Then
                Debug.Assert(False)
            End If
        End If

        ' If Line List contains Lines; search for line a-b
        If (0 < mLineList.Count) Then
            ' Binary search for line, if one exists
            While (True)
                ' Next line is halfway between current lines
                Dim ptI As Integer = (aI + bI) >> 1

                ' If line beyond limit, line was not found
                If (mLineList.Count <= ptI) Then
                    Exit While
                End If

                line = DirectCast(mLineList(ptI), ArrayList)

                ' Get first point in line
                Dim pt As ContourPoint = DirectCast(line(0), ContourPoint)
                Dim ptX As Single = pt.X.Value
                Dim ptY As Single = pt.Y.Value

                ' Do X values match?
                If (ptX < aX) Then
                    aI = ptI ' Line toward end of list; move start line to midpoint
                ElseIf (aX < ptX) Then
                    bI = ptI ' Line toward start of list; move end line to midpoint
                Else ' (aX = ptX)
                    ' X values match; do Y values match?
                    If (ptY < aY) Then
                        aI = ptI ' Line toward end of list; move start line to midpoint
                    ElseIf (aY < ptY) Then
                        bI = ptI ' Line toward start of list; move end line to midpoint
                    Else ' (aY = ptY)
                        ' a matches first point in line; does b match last point?
                        pt = DirectCast(line(line.Count - 1), ContourPoint)
                        ptX = pt.X.Value
                        ptY = pt.Y.Value

                        If (ptX < bX) Then
                            aI = ptI ' Line toward end of list; move start line to midpoint
                        ElseIf (bX < ptX) Then
                            bI = ptI ' Line toward start of list; move end line to midpoint
                        Else ' (bX = ptX)
                            ' b's X matches first point's X value; does Y match?
                            If (ptY < bY) Then
                                bI = ptI ' Line toward end of list; move start line to midpoint
                            ElseIf (bY < ptY) Then
                                bI = ptI ' Line toward start of list; move end line to midpoint
                            Else ' (bY = ptY)
                                ' b matches last point in line; this is the line!
                                aI = 0
                                bI = line.Count - 1

                                ' Binary search for position to insert point into line
                                While (True)
                                    ' Next point is halfway between current points
                                    ptI = (aI + bI) >> 1
                                    pt = DirectCast(line(ptI), ContourPoint)
                                    ptX = pt.X.Value
                                    ptY = pt.Y.Value

                                    ' Do X values match?
                                    If (ptX < cX) Then
                                        aI = ptI ' Point toward end of line; move start point to midpoint
                                    ElseIf (cX < ptX) Then
                                        bI = ptI ' Point toward start of line; move end point to midpoint
                                    Else ' (cX = ptX)
                                        ' X values matches; do Y values match?
                                        If (ptY < cY) Then
                                            aI = ptI ' Point toward end of line; move start point to midpoint
                                        ElseIf (cY < ptY) Then
                                            bI = ptI ' Point toward start of line; move end point to midpoint
                                        Else
                                            If (overwrite) Then
                                                line.Remove(ptI) ' Replace point with new one
                                                line.Insert(ptI, c)
                                                Return
                                            Else
                                                Return
                                            End If
                                        End If
                                    End If

                                    If (aI = bI) Then
                                        ' End points are the same; insert prior to this point
                                        line.Insert(aI, c)
                                        Return
                                    ElseIf (aI = bI - 1) Then
                                        ' End points are adjadent; insert between points
                                        line.Insert(bI, c)
                                        Return
                                    End If
                                End While
                            End If
                        End If
                    End If
                End If

                ' Check for end conditions
                If (aI = bI) Then
                    Exit While ' End lines are the same; nothing was found
                ElseIf (aI = bI - 1) Then
                    aI = bI ' End lines are adjacent; make sure last line is checked
                End If
            End While
        End If

        ' Matching line was not found; insert new line
        line = New ArrayList
        If (reverse) Then
            line.Add(b)
            line.Add(c) ' Line is b-c-a
            line.Add(a)
        Else
            line.Add(a)
            line.Add(c) ' Line is a-c-b
            line.Add(b)
        End If
        mLineList.Insert(aI, line)

    End Sub

    '*********************************************************************************************************
    ' Function ValuePoint()     - Determine if 'value' of parameter 'idx' lies on the line between contour
    '                             points 'a' & 'b'
    '
    ' Input(s):     a, b        - contour points defining line
    '               idx         - parameter index
    '               value       - contour value to search for
    '               zTolerance  - tolerence for making real number comparisons
    '
    ' Output(s):    c           - ContourPoint for value, if found, Nothing if not
    '
    ' Returns:      Boolean     - true: ContourPoint c found on line between a & b
    '                             false: c not found
    '*********************************************************************************************************
    Public Overridable Function ValuePoint(ByVal a As ContourPoint, ByVal b As ContourPoint,
                ByVal idx As Integer, ByVal loValue As Single, ByVal zTolerance As Single,
                ByRef c As ContourPoint) As Boolean

        ' Get XYZ values from points a & b
        Dim aX As Single = a.X.Value
        Dim aY As Single = a.Y.Value
        Dim aZ As Single = DirectCast(a.Z(idx), SingleParameter).Value

        Dim bX As Single = b.X.Value
        Dim bY As Single = b.Y.Value
        Dim bZ As Single = DirectCast(b.Z(idx), SingleParameter).Value

        Dim cZ As Single
        Dim x, y As Single
        Dim parameter As SingleParameter = Nothing

        ' Check if 'value' is between the ends of the line
        If ((aZ < loValue) And (loValue < bZ)) Then
            ' First, check if this point (or points bounding this point) have already been calculated
            If Not (RecallValuePoint(aX, aY, aZ, bX, bY, bZ, idx, loValue, zTolerance, c)) Then
                Debug.Assert((aZ < loValue) And (loValue < bZ))
                ' Binary search for 'value' point
                While (True)

                    x = (aX + bX) / 2       ' Get mid-point
                    y = (aY + bY) / 2

                    c = GetContourPoint(x, y)
                    If Not (c Is Nothing) Then
                        ' Get 'value' from new point
                        cZ = DirectCast(c.Z(idx), SingleParameter).Value

                        ' Is 'value' within tolerance?
                        If ((loValue <= cZ) And (cZ <= loValue + zTolerance)) Then
                            ' Store the new point
                            StoreValuePoint(a, b, c, False)
                            Exit While
                        End If

                        ' No, divide & conquer
                        If (cZ < loValue) Then
                            If ((aX = x) And (aY = y)) Then
                                ' Binary search converged on one point; this must be it.
                                DirectCast(c.Z(idx), SingleParameter).Value = loValue
                                ' Store the new point
                                StoreValuePoint(a, b, c, True)
                                Exit While
                            Else
                                aX = x
                                aY = y
                            End If
                        ElseIf (loValue + zTolerance < cZ) Then
                            If ((bX = x) And (bY = y)) Then
                                ' Binary search converged on one point; this must be it.
                                DirectCast(c.Z(idx), SingleParameter).Value = loValue + zTolerance
                                ' Store the new point
                                StoreValuePoint(a, b, c, True)
                                Exit While
                            Else
                                bX = x
                                bY = y
                            End If
                        Else
                            Debug.Assert(False)
                        End If

                        ' Store the new point
                        StoreValuePoint(a, b, c, False)
                    Else
                        Debug.Assert(False, "c is Nothing")
                    End If
                End While
            End If

            Return True
        End If

        If ((bZ < loValue) And (loValue < aZ)) Then
            ' First, check if this point (or points bounding this point) have already been calculated
            If Not (RecallValuePoint(aX, aY, aZ, bX, bY, bZ, idx, loValue, zTolerance, c)) Then
                Debug.Assert((bZ < loValue) And (loValue < aZ))
                ' Binary search for 'value' point
                While (True)

                    x = (aX + bX) / 2       ' Get mid-point
                    y = (aY + bY) / 2

                    c = GetContourPoint(x, y)
                    If Not (c Is Nothing) Then
                        ' Get 'value' from new point
                        cZ = DirectCast(c.Z(idx), SingleParameter).Value

                        ' Is 'value' within tolerance?
                        If ((loValue <= cZ) And (cZ <= loValue + zTolerance)) Then
                            ' Store the new point
                            StoreValuePoint(a, b, c, False)
                            Exit While
                        End If

                        ' No, divide & conquer
                        If (cZ < loValue) Then
                            If ((bX = x) And (bY = y)) Then
                                ' Binary search converged on one point; this must be it.
                                DirectCast(c.Z(idx), SingleParameter).Value = loValue
                                ' Store the new point
                                StoreValuePoint(a, b, c, True)
                                Exit While
                            Else
                                bX = x
                                bY = y
                            End If
                        ElseIf (loValue + zTolerance < cZ) Then
                            If ((aX = x) And (aY = y)) Then
                                ' Binary search converged on one point; this must be it.
                                DirectCast(c.Z(idx), SingleParameter).Value = loValue + zTolerance
                                ' Store the new point
                                StoreValuePoint(a, b, c, True)
                                Exit While
                            Else
                                aX = x
                                aY = y
                            End If
                        Else
                            Debug.Assert(False)
                        End If

                        ' Store the new point
                        StoreValuePoint(a, b, c, False)
                    Else
                        Debug.Assert(False, "c is Nothing")
                    End If
                End While
            End If

            Return True
        End If

        c = Nothing
        Return False
    End Function

#End Region

#Region " Limit Contour Point "

    '*********************************************************************************************************
    ' Function LimitPoint()     - Determine if 'error' point lies on the line between contour points 'a' & 'b'
    '
    ' Input(s):     a, b        - contour points defining line
    '
    ' Output(s):    c           - ContourPoint for value, if found, Nothing if not
    '
    ' Returns:      Boolean     - true: ContourPoint c found on line between a & b
    '                             false: c not found
    '*********************************************************************************************************
    Public Overridable Function LimitPoint(ByVal a As ContourPoint, ByVal b As ContourPoint,
                                           ByRef c As ContourPoint) As Boolean

        Dim aX As Single = a.X.Value
        Dim aY As Single = a.Y.Value

        Dim bX As Single = b.X.Value
        Dim bY As Single = b.Y.Value

        Dim x, y As Single
        Dim parameter As SingleParameter

        ' Check if 'error' is between the ends of the line
        If (a.HasError And Not b.HasError) Then
            ' A has error; B does not
            ' Binary search for 'error' point
            For iter As Integer = 1 To 15

                x = (aX + bX) / 2       ' Get mid-point
                y = (aY + bY) / 2

                c = GetContourPoint(x, y)
                If (c IsNot Nothing) Then

                    If (c.HasError) Then
                        aX = x
                        aY = y
                    Else
                        bX = x
                        bY = y
                    End If

                    If ((ThisClose(aX, bX, XTolerance)) _
                    And (ThisClose(aY, bY, YTolerance))) Then
                        Exit For
                    End If
                Else ' (c Is Nothing)
                    Return False
                End If
            Next

            parameter = New SingleParameter(x, a.X.Units)
            c.X = parameter      ' X-axis
            parameter = New SingleParameter(y, a.Y.Units)
            c.Y = parameter      ' Y-axis

            c.ErrMsg = a.ErrMsg
            c.HasError = a.HasError
            c.WarnMsg = a.WarnMsg
            c.HasWarning = a.HasWarning

            Return True
        End If

        If (b.HasError And Not a.HasError) Then
            ' B has error; A does not
            ' Binary search for 'error' point
            For iter As Integer = 1 To 15

                x = (aX + bX) / 2       ' Get mid-point
                y = (aY + bY) / 2

                c = GetContourPoint(x, y)
                If (c IsNot Nothing) Then

                    If (c.HasError) Then
                        bX = x
                        bY = y
                    Else
                        aX = x
                        aY = y
                    End If

                    If ((ThisClose(aX, bX, XTolerance)) _
                    And (ThisClose(aY, bY, YTolerance))) Then
                        Exit For
                    End If
                Else ' (c Is Nothing)
                    Return False
                End If
            Next

            parameter = New SingleParameter(x, a.X.Units)
            c.X = parameter      ' X-axis
            parameter = New SingleParameter(y, a.Y.Units)
            c.Y = parameter      ' Y-axis

            c.ErrMsg = b.ErrMsg
            c.HasError = b.HasError
            c.WarnMsg = b.WarnMsg
            c.HasWarning = b.HasWarning

            Return True
        End If

        c = Nothing
        Return False
    End Function

#End Region

#Region " Contour Point "

    '******************************************************************************************
    ' Method to get a specified Contour Point
    '
    Private Function GetContourPoint(ByVal x As Double, ByVal y As Double) As ContourPoint
        Dim contourPoint As ContourPoint = GetContourPoint(x, y, NumDistances)
        Return contourPoint
    End Function
    '
    ' All Analyses must override this method to calculate the specified contour point
    '
    Public MustOverride Function GetContourPoint(ByVal x As Double, ByVal y As Double,
                                                 ByVal numDistances As Integer) As ContourPoint

#End Region

#End Region

#Region " Automation "

    '*********************************************************************************************************
    ' Function PreAutoRun()     - performs pre-AutoRun functions such as setup error checking
    ' Sub AutoRun()             - runs an Analysis via automation interface as opposed the user interface
    ' Function PostAutoRun()    - performs pre-AutoRun functions such as check for overflow
    '
    ' Returns:      True        OK - No Error/Warning present
    '               False       Not OK - Error/Warning present
    '
    ' These methods can be overridden by the Analysis' baseclasses to add analysis specific functionality
    '*********************************************************************************************************
    Public Overridable Function PreAutoRun() As Boolean
        UpdateSetupErrorsAndWarnings()                  ' Check for Setup errors/warnings
        PreAutoRun = Not HasSetupErrors()          ' Setup errors should prevent AutoRun()
    End Function

    Public Overridable Sub AutoRun()
        CalculateSolution()
    End Sub

    Public Overridable Function PostAutoRun() As Boolean
        PostAutoRun = True
        ' Check for Overflow
        Dim overDist, overTime As Double
        If (SrfrIrrigation IsNot Nothing) Then
            If (SrfrIrrigation.Overflow(overDist, overTime)) Then
                Dim title As String = mDictionary.tSimulationResults.Translated
                Dim msg As String = mDictionary.tWrnOverflowCondition.Translated
                AddExecutionWarning(WarningFlags.ExecutionWarning, title, msg)
                PostAutoRun = False
            End If
        End If
    End Function

#End Region

#Region " Solution "

    '*********************************************************************************************************
    ' Overridable Sub CalculateSolution() - Calculate the Solution for the Analysis.
    '
    ' Analyses should override this method to calculate a solution based on user input.
    ' This base method should be called first to initialize common solution parameters.
    '*********************************************************************************************************
    Public Overridable Sub CalculateSolution()

        ' Verify SRFR Parameters are set correctly
        VerifySrfrParameters(CellDensities.Medium)

        ' Get System Geometry parameters
        mLength = mSystemGeometry.Length.Value
        mWidth = mSystemGeometry.Width.Value

        ' Get Inflow parameters
        mInflowRate = mInflowManagement.InflowRate.Value
        mTco = mInflowManagement.CutoffTime.Value
        mTcb = mTco * mInflowManagement.CutbackTimeRatio.Value
        mXR = mInflowManagement.CutoffLocationRatio.Value
        mDReq = mInflowManagement.RequiredDepth.Value

        ' Performance Indicators
        mTL = Double.NaN
        mTReq = Double.NaN

        mDApp = Double.NaN
        mDInf = Double.NaN
        mDMin = Double.NaN
        mDLf = Double.NaN

        mTxa = Double.NaN

        mCost = Double.NaN

        mDpFraction = Double.NaN
        mRoFraction = Double.NaN

        mAE = Double.NaN
        mRE = Double.NaN
        mPAElq = Double.NaN
        mPAEmin = Double.NaN
        mDUlq = Double.NaN
        mDUmin = Double.NaN
        mADlq = Double.NaN
        mADmin = Double.NaN

        mInflowVolume = Double.NaN
        mRunoffVolume = Double.NaN
        mInfiltratedVolume = Double.NaN

        mAdvanceTime1 = Double.NaN
        mInflowVolume1 = Double.NaN
        mSurfaceVolume1 = Double.NaN
        mInfiltratedVolume1 = Double.NaN

        mAdvanceTime2 = Double.NaN
        mInflowVolume2 = Double.NaN
        mSurfaceVolume2 = Double.NaN
        mInfiltratedVolume2 = Double.NaN

        Ymax = Double.NaN

    End Sub

    '*********************************************************************************************************
    ' Overridable Sub SaveSolution() - save the Solution calculated for the Analysis.
    '
    ' Analyses should override this method to save their specific solution results.
    ' This base method should be called first to save common solution results.
    '*********************************************************************************************************
    Protected Overridable Sub SaveSolution()

        '
        ' Performance Indicators
        '

        ' Surface Flow - Tcb, Tco, TL, R
        Dim _rcb As DoubleParameter = mInflowManagement.CutbackTimeRatio
        If Not (_rcb.Value = mTcb / mTco) Then
            _rcb.Value = mTcb / mTco
            _rcb.Source = ValueSources.Calculated
            mInflowManagement.CutbackTimeRatio = _rcb
        End If
        mInflowManagement.CutbackTimeRatioProperty.ToBeCalculated = False

        Dim _tco As DoubleParameter = mInflowManagement.CutoffTime
        If Not (_tco.Value = mTco) Then
            _tco.Value = mTco
            _tco.Source = ValueSources.Calculated
            mInflowManagement.CutoffTime = _tco
        End If
        mInflowManagement.CutoffTimeProperty.ToBeCalculated = False

        Dim _xar As DoubleParameter = mSurfaceFlow.XaR
        _xar.Value = mXR
        _xar.Source = ValueSources.Calculated
        mSurfaceFlow.XaR = _xar
        mSurfaceFlow.XaRProperty.ToBeCalculated = False

        Dim _txa As DoubleParameter = mSurfaceFlow.Txa
        _txa.Value = mTxa
        _txa.Source = ValueSources.Calculated
        mSurfaceFlow.Txa = _txa
        mSurfaceFlow.TxaProperty.ToBeCalculated = False

        Dim _tl As DoubleParameter = mSurfaceFlow.TL
        _tl.Value = mTL
        _tl.Source = ValueSources.Calculated
        mSurfaceFlow.TL = _tl
        mSurfaceFlow.TLProperty.ToBeCalculated = False

        ' Infiltrated Depths
        Dim _dapp As DoubleParameter = mSubsurfaceFlow.Dapp
        _dapp.Value = mDApp
        _dapp.Source = ValueSources.Calculated
        mSubsurfaceFlow.Dapp = _dapp
        mSubsurfaceFlow.DappProperty.ToBeCalculated = False

        Dim _davg As DoubleParameter = mSubsurfaceFlow.Davg
        _davg.Value = mDInf
        _davg.Source = ValueSources.Calculated
        mSubsurfaceFlow.Davg = _davg
        mSubsurfaceFlow.DavgProperty.ToBeCalculated = False

        Dim _ddp As DoubleParameter = mSubsurfaceFlow.DP
        _ddp.Value = _dapp.Value * mDpFraction
        _ddp.Source = ValueSources.Calculated
        mSubsurfaceFlow.DP = _ddp
        mSubsurfaceFlow.DPProperty.ToBeCalculated = False

        Dim _dro As DoubleParameter = mSurfaceFlow.ROd
        _dro.Value = _dapp.Value * mRoFraction
        _dro.Source = ValueSources.Calculated
        mSurfaceFlow.ROd = _dro
        mSurfaceFlow.ROdProperty.ToBeCalculated = False

        Dim _dmin As DoubleParameter = mSubsurfaceFlow.Dmin
        _dmin.Value = mDMin
        _dmin.Source = ValueSources.Calculated
        mSubsurfaceFlow.Dmin = _dmin
        mSubsurfaceFlow.DminProperty.ToBeCalculated = False

        Dim _dlq As DoubleParameter = mSubsurfaceFlow.Dlq
        _dlq.Value = mDLf
        _dlq.Source = ValueSources.Calculated
        mSubsurfaceFlow.Dlq = _dlq
        mSubsurfaceFlow.DlqProperty.ToBeCalculated = False

        ' Performance
        Dim _re As DoubleParameter = mSubsurfaceFlow.RE
        _re.Value = mRE
        _re.Source = ValueSources.Calculated
        mSubsurfaceFlow.RE = _re
        mSubsurfaceFlow.AEProperty.ToBeCalculated = False

        Dim _ae As DoubleParameter = mSubsurfaceFlow.AE
        _ae.Value = mAE
        _ae.Source = ValueSources.Calculated
        mSubsurfaceFlow.AE = _ae
        mSubsurfaceFlow.AEProperty.ToBeCalculated = False

        Dim _paeMin As DoubleParameter = mSubsurfaceFlow.PAEmin
        _paeMin.Value = mPAEmin
        _paeMin.Source = ValueSources.Calculated
        mSubsurfaceFlow.PAEmin = _paeMin
        mSubsurfaceFlow.PAEminProperty.ToBeCalculated = False

        Dim _paeLq As DoubleParameter = mSubsurfaceFlow.PAElq
        _paeLq.Value = mPAElq
        _paeLq.Source = ValueSources.Calculated
        mSubsurfaceFlow.PAElq = _paeLq
        mSubsurfaceFlow.PAElqProperty.ToBeCalculated = False

        Dim _duMin As DoubleParameter = mSubsurfaceFlow.DUmin
        _duMin.Value = mDUmin
        _duMin.Source = ValueSources.Calculated
        mSubsurfaceFlow.DUmin = _duMin
        mSubsurfaceFlow.DUminProperty.ToBeCalculated = False

        Dim _duLq As DoubleParameter = mSubsurfaceFlow.DUlq
        _duLq.Value = mDUlq
        _duLq.Source = ValueSources.Calculated
        mSubsurfaceFlow.DUlq = _duLq
        mSubsurfaceFlow.DUlqProperty.ToBeCalculated = False

        Dim _adMin As DoubleParameter = mSubsurfaceFlow.ADmin
        _adMin.Value = mADmin
        _adMin.Source = ValueSources.Calculated
        mSubsurfaceFlow.ADmin = _adMin
        mSubsurfaceFlow.ADminProperty.ToBeCalculated = False

        Dim _adLq As DoubleParameter = mSubsurfaceFlow.ADlq
        _adLq.Value = mADlq
        _adLq.Source = ValueSources.Calculated
        mSubsurfaceFlow.ADlq = _adLq
        mSubsurfaceFlow.ADlqProperty.ToBeCalculated = False

        ' Costs
        Dim _cost As DoubleParameter = mInflowManagement.Cost
        _cost.Value = mCost
        _cost.Source = ValueSources.Calculated
        mInflowManagement.Cost = _cost
        mInflowManagement.CostProperty.ToBeCalculated = False

        '
        ' Save calculated Curves, if any
        '
        If (0 < mDistances.Count) Then

            ' Advance
            Dim advance As DataTableParameter = mSurfaceFlow.Advance
            Dim advTable As DataTable = advance.Value
            advTable.TableName = sAdvance
            advTable.Clear()
            If (mDistances.Count <= mAdvTimes.Count) Then
                For idx As Integer = 0 To mDistances.Count - 1
                    Dim row As DataRow = advTable.NewRow
                    row(0) = CDbl(mDistances.Item(idx))
                    row(1) = CDbl(mAdvTimes.Item(idx))
                    advTable.Rows.Add(row)
                Next
            End If
            advance.Source = ValueSources.Calculated
            mSurfaceFlow.Advance = advance

            ' Recession
            Dim recession As DataTableParameter = mSurfaceFlow.Recession
            Dim recTable As DataTable = recession.Value
            recTable.TableName = sRecession
            recTable.Clear()
            If (mDistances.Count <= mRecTimes.Count) Then
                For idx As Integer = 0 To mDistances.Count - 1
                    Dim row As DataRow = recTable.NewRow
                    row(0) = CDbl(mDistances.Item(idx))
                    row(1) = CDbl(mRecTimes.Item(idx))
                    recTable.Rows.Add(row)
                Next
            End If
            recession.Source = ValueSources.Calculated
            mSurfaceFlow.Recession = recession

            ' Infiltration
            Dim infiltration As DataTableParameter = mSubsurfaceFlow.LongitudinalInfiltration
            Dim infTable As DataTable = infiltration.Value
            infTable.TableName = sInfiltration
            infTable.Clear()
            If (mDistances.Count <= mInfDepths.Count) Then
                For idx As Integer = 0 To mDistances.Count - 1
                    Dim row As DataRow = infTable.NewRow
                    row(0) = CDbl(mDistances.Item(idx))
                    row(1) = CDbl(mInfDepths.Item(idx))
                    infTable.Rows.Add(row)
                Next
            End If
            infiltration.Source = ValueSources.Calculated
            mSubsurfaceFlow.LongitudinalInfiltration = infiltration
        End If

    End Sub

#End Region

#Region " Upstream Parameters "

    '********************************************************************************************************************************
    ' UpstreamParameters(), etc. - shortcuts to methods in the Unit class
    '
    ' Input(s):     Q0      - inflow
    '               L       - border/furrow length
    '               W       - border width | furrow spacing
    '               S0      - slope
    '
    '               Beta    - optional weighting factor
    '
    ' Output(s):    Y0      - upstream flow depth
    '               AY0     -     "    flow area
    '               R0      -     "    hydraulic radius
    '               WP0     -     "    wetted perimeter
    '               Sf0     -     "    friction slope
    '********************************************************************************************************************************
    Public Overridable Sub UpstreamParameters(ByVal Q0 As Double, ByVal L As Double, ByVal W As Double, ByVal S0 As Double,
           ByRef Y0 As Double, ByRef AY0 As Double, ByRef R0 As Double, ByRef WP0 As Double, ByRef Sf0 As Double,
           Optional ByVal Beta As Double = 0.0)

        If (mSoilCropProperties.SrfrInfiltration IsNot Nothing) Then
            Dim roughness As Srfr.Roughness = mSoilCropProperties.SrfrInfiltration.RefRoughness
            Dim crossSection As Srfr.CrossSection = mSoilCropProperties.SrfrInfiltration.RefCrossSection

            crossSection.Length = L
            crossSection.BorderWidth = W
            crossSection.S0 = S0
            crossSection.MaxDepth = OneMeter ' prevent Overflow handling

            If (Beta <= 0.0) Then
                Beta = mUnit.Beta(S0) ' Globals.Beta
            End If

            Srfr.SrfrAPI.UpstreamParameters(Q0, crossSection, roughness, Y0, AY0, R0, WP0, Sf0, Beta)
        Else
            mUnit.UpstreamParameters(Q0, L, W, S0, Y0, AY0, R0, WP0, Sf0, Beta)
        End If
    End Sub

    Public Function UpstreamDepth(ByVal Q As Double, ByVal L As Double, ByVal W As Double, ByVal S0 As Double,
                                  Optional ByVal Beta As Double = 0.0) As Double
        Dim Y0, AY0, R0, WP0, SF0 As Double
        UpstreamParameters(Q, L, W, S0, Y0, AY0, R0, WP0, SF0, Beta)
        Return Y0
    End Function

    Public Function UpstreamArea(ByVal Q As Double, ByVal L As Double, ByVal W As Double, ByVal S0 As Double,
                                 Optional ByVal Beta As Double = 0.0) As Double
        Dim Y0, AY0, R0, WP0, SF0 As Double
        UpstreamParameters(Q, L, W, S0, Y0, AY0, R0, WP0, SF0, Beta)
        Return AY0
    End Function

    Public Function UpstreamWettedPerimeter(ByVal Q As Double, ByVal L As Double, ByVal W As Double, ByVal S0 As Double,
                                 Optional ByVal Beta As Double = 0.0) As Double
        Dim Y0, AY0, R0, WP0, SF0 As Double
        UpstreamParameters(Q, L, W, S0, Y0, AY0, R0, WP0, SF0, Beta)
        Return WP0
    End Function

#End Region

#Region " Shape Factors "

    '********************************************************************************************************************************
    ' Shortcuts to methods in the Unit class
    '
    ' Function SigmaY()     - calculate Surface Shape Factor (Sy) upto the end of advance
    ' Function SigmaYpa()   - calculate Surface Shape Factor (Sy) post advance (open-end only)
    '********************************************************************************************************************************
    Public Function SigmaY(ByVal Qin As Double, ByVal Xa As Double, ByVal W As Double, ByVal S0 As Double,
                           Optional ByVal Beta As Double = 0.0) As Double
        SigmaY = mUnit.SigmaY(Qin, Xa, W, S0, Beta)
    End Function

    Public Function SigmaYpa(ByVal Qin As Double, ByVal Xpa As Double, ByVal L As Double, ByVal W As Double, ByVal S0 As Double,
                           Optional ByVal Beta As Double = 0.0) As Double
        SigmaYpa = mUnit.SigmaYpa(Qin, Xpa, L, W, S0, Beta)
    End Function

#End Region

#Region " Infiltration Utilities "

    '*********************************************************************************************************
    ' Compute infiltrated volume from irrigation curves
    '*********************************************************************************************************
    Protected Function InfiltratedVolume(ByVal width As Double) As Double
        Dim Vinf As Double = 0.0

        Debug.Assert(mDistances.Count = mInfDepths.Count, "Array lengths do not match")

        If (2 <= mDistances.Count) Then

            For idx As Integer = 1 To mDistances.Count - 1
                Dim dist1 As Double = CDbl(mDistances(idx - 1))
                Dim dist2 As Double = CDbl(mDistances(idx))

                Dim Dinf1 As Double = CDbl(mInfDepths(idx - 1))
                Dim Dinf2 As Double = CDbl(mInfDepths(idx))

                Vinf += (dist2 - dist1) * (Dinf2 + Dinf1) / 2.0 ' dX * dZavg
            Next

            Vinf *= width ' L * Z * W
        End If

        Return Vinf
    End Function

    '*********************************************************************************************************
    ' Compute deep percolation volume from irrigation curves
    '*********************************************************************************************************
    Protected Function DeepPercolationVolume(ByVal width As Double, ByVal dreq As Double) As Double
        Dim Vdp As Double = 0.0

        Debug.Assert(mDistances.Count = mInfDepths.Count, "Array lengths do not match")

        If (2 <= mDistances.Count) Then

            For idx As Integer = 1 To mDistances.Count - 1
                Dim dist1 As Double = CDbl(mDistances(idx - 1))
                Dim dist2 As Double = CDbl(mDistances(idx))

                Dim Ddp1 As Double = Math.Max(CDbl(mInfDepths(idx - 1)) - dreq, 0)
                Dim Ddp2 As Double = Math.Max(CDbl(mInfDepths(idx)) - dreq, 0)

                Vdp += (dist2 - dist1) * (Ddp1 + Ddp2) / 2.0 ' dX * dDPavg
            Next

            Vdp *= width ' L * DP * W
        End If

        Return Vdp
    End Function

    '*********************************************************************************************************
    ' Function MeasuredInfiltrationVolumeTable()
    ' Function PredictedInfiltrationVolumeTable()
    '
    ' Input(s)  SrfrInfiltration    - reference to Srfr.Infiltration object for infiltration calculations
    '
    ' Note - these baseclass definitions should be over-ridden by subclasses when needed.
    '*********************************************************************************************************
    Public Overridable Function MeasuredInfiltrationVolumeTable() As DataTable
        MeasuredInfiltrationVolumeTable = New DataTable
    End Function

    Public Overridable Function PredictedInfiltrationVolumeTable(
                 Optional ByVal SrfrInfiltration As Srfr.Infiltration = Nothing) As DataTable
        PredictedInfiltrationVolumeTable = New DataTable
    End Function

#End Region

#Region " Wetted Perimeter Utilities "

    Public Overridable Sub LoadWettedPerimeterControl(ByVal WettedPerimeterControl As ctl_SelectParameter)

        ' Get Wetted Perimeter selection
        Dim WPparam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
        Dim WPsource As ValueSources = WPparam.Source
        Dim WPmethod As WettedPerimeterMethods = WPparam.Value

        ' Update selection list
        WettedPerimeterControl.Clear()

        Dim _sel As String = String.Empty
        Dim _val As Integer = 0

        Dim _selOk As Boolean = mSoilCropProperties.GetFirstWettedPerimeterMethodSelection(_sel)
        While (_sel IsNot Nothing)
            If (_selOk) Then
                WettedPerimeterControl.Add(_sel, _val, True)
            Else ' Is selection the current WP selection? Yes, flag it
                If (WPmethod = _val) Then
                    WettedPerimeterControl.Add(_sel, _val, False)
                End If
            End If

            _selOk = mSoilCropProperties.GetNextWettedPerimeterMethodSelection(_sel)
            _val += 1
        End While

    End Sub

    '*********************************************************************************************************************************
    ' Sub LoadInfiltrationEquationControl() - load a ctl_SelectParameter control with its appropriate selection list
    '
    ' Input(s):     InfiltrationEquationControl - ctl_SelectParameter control to load
    '               WPmethod                    - current Wetted Perimeter method
    '               IEmethod                    - current Infiltration Equation method
    '               AddInvalid                  - should invalid selection be loaded or not
    '*********************************************************************************************************************************
    Public Overridable Sub LoadInfiltrationEquationControl(ByVal InfiltrationEquationControl As ctl_SelectParameter,
                                                  Optional ByVal WPmethod As WettedPerimeterMethods = WettedPerimeterMethods.LowLimit,
                                                  Optional ByVal IEmethod As InfiltrationFunctions = InfiltrationFunctions.LowLimit,
                                                  Optional ByVal AddInvalid As Boolean = True)

        ' Get Infiltration Function selections, if needed
        If (WPmethod = WettedPerimeterMethods.LowLimit) Then
            WPmethod = mSoilCropProperties.WettedPerimeterMethod.Value
        End If

        If (IEmethod = InfiltrationFunctions.LowLimit) Then
            IEmethod = mSoilCropProperties.InfiltrationFunction.Value
        End If

        ' Get selection flags for current World, Cross Section & User Level
        Dim _worldType As WorldTypes = CType(mUnit.WorldRef.WorldType.Value, WorldTypes)
        Dim _crossSection As CrossSections = mUnit.CrossSection
        Dim _userLevel As UserLevels = mWinSRFR.UserLevel

        Dim _selFlags As Globals.SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        ' Update selection list
        Dim _sel As String = String.Empty
        Dim _val As Integer = 0

        InfiltrationEquationControl.Clear()

        Dim _selOk As Boolean = mSoilCropProperties.GetFirstInfiltrationFunctionSelection(_sel)

        While (_sel IsNot Nothing)
            Dim _added As Boolean = False

            If (_selOk) Then
                Select Case (mUnit.CrossSection)
                    Case CrossSections.Furrow
                        If (_val < InfiltrationWettedPerimeterConstraints.Length) Then
                            ' Check criteria for adding furrow Infiltration Equations
                            Dim infRowFlags As SelFlags() = InfiltrationWettedPerimeterConstraints(_val)
                            Dim wpColFlags As Integer = infRowFlags(WPmethod)
                            If Not (0 = (wpColFlags And _selFlags)) Then
                                InfiltrationEquationControl.Add(_sel, _val, True)
                                _added = True
                            End If
                        End If

                    Case Else ' Basin/Border
                        If (_val < InfiltrationFunctionConstraints.Length) Then
                            ' Check criteria for adding basin/border Infiltration Equations
                            Dim _infiltration As Boolean() = InfiltrationFunctionConstraints(_val)
                            If (_infiltration(_worldType)) Then
                                InfiltrationEquationControl.Add(_sel, _val, True)
                                _added = True
                            End If
                        End If
                End Select
            End If

            ' Current selection may not be valid
            If (AddInvalid And (Not (_added))) Then ' Check if current invalid selection should be added
                If (IEmethod = _val) Then ' Yes, it should
                    InfiltrationEquationControl.Add(_sel, _val, False) ' Add, but mark as invalid
                End If
            End If

            _selOk = mSoilCropProperties.GetNextInfiltrationFunctionSelection(_sel)
            _val += 1
        End While

    End Sub

    Protected Function WettedPerimeter(Optional ByVal Q0 As Double = 0.0,
                                       Optional ByVal Y As Double = 0.0) As Double
        Dim WP As Double = mSystemGeometry.Width.Value ' Start with Border/Furrow Set Width

        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

            If (Q0 <= 0.0) Then
                Q0 = mInflowManagement.AverageInflowRateForCrossSection
            End If

            Dim L As Double = mSystemGeometry.Length.Value
            Dim FS As Double = mSystemGeometry.FurrowSpacing.Value
            Dim S0 As Double = mSystemGeometry.AverageSlope
            Dim n As Double = mSoilCropProperties.ManningN.Value

            Dim wpMethod As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value

            Select Case (wpMethod)

                Case WettedPerimeterMethods.FurrowSpacing

                    WP = FS

                Case WettedPerimeterMethods.LocalWettedPerimeter

                    WP = mSystemGeometry.WettedPerimeter(Y)

                Case WettedPerimeterMethods.NrcsEmpiricalFunction

                    If (S0 <= 0.0) Then ' Eq. 5-25 in SCS (1984) Section 15, Ch5 Furrow Irrigation
                        S0 = Srfr.SrfrAPI.NrcsHydraulicGradient(Q0, L)
                    End If

                    WP = Srfr.SrfrAPI.NrcsUpstreamWettedPerimeter(Q0, S0, n)

                Case Else ' Assume RepresentativeUpstreamWettedPerimeter & equivalents

                    WP = Me.UpstreamWettedPerimeter(Q0, L, FS, S0)

            End Select
        End If

        Return WP
    End Function

    Protected Function WettedPerimeterMessage(ByVal fromWP As WettedPerimeterMethods,
                                              ByVal toWP As WettedPerimeterMethods) As DialogResult

        Dim title As String = mDictionary.tWettedPerimeterChanging.Translated
        Dim msg As String

        Dim fromText As String = WettedPerimeterMethodSelections(fromWP).Value
        Dim toText As String = WettedPerimeterMethodSelections(toWP).Value

        msg = mDictionary.tWettedPerimeterChanging.Translated & ":"
        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tFrom.Translated & ": " & fromText
        msg &= Chr(13) & mDictionary.tTo.Translated & ": " & toText
        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tChangingWettedPerimeterMsg.Translated
        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tAutomaticConversionSupported.Translated
        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tPerformConversionAutomatically.Translated
        msg &= Chr(13)

        Dim result As DialogResult = MsgBox(msg, MsgBoxStyle.YesNo, title)

        Return result
    End Function

    Public Sub WettedPerimeterMessage(ByVal selection As Integer)

        ' Initialize member data
        mConvertWP = DialogResult.No
        mRatioWP = 1.0

        ' Get current Infiltration Method & Wetted Perimeter
        Dim curInfParam As IntegerParameter = mSoilCropProperties.InfiltrationFunction
        Dim curInfMethod As InfiltrationFunctions = curInfParam.Value
        Dim curInfSource As ValueSources = curInfParam.Source

        Dim curWPparam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
        Dim curWPmethod As WettedPerimeterMethods = curWPparam.Value
        Dim curWPsource As ValueSources = curWPparam.Source

        ' Change from 'default' should not display Wetted Perimeter message
        If (mSoilCropProperties.InfiltrationParameterAreDefault) Then
            Exit Sub
        End If

        ' Convert selection to its corresponding Wetted Perimeter Method
        Dim newWPmethod As WettedPerimeterMethods = curWPmethod
        If ((WettedPerimeterMethods.LowLimit < selection) And (selection < WettedPerimeterMethods.HighLimit)) Then
            newWPmethod = CType(selection, WettedPerimeterMethods)
        Else
            Exit Sub
        End If

        ' Conversion is available for a subset of the Infiltration Methods
        If ((curInfMethod = InfiltrationFunctions.BranchFunction) _
         Or (curInfMethod = InfiltrationFunctions.KostiakovFormula) _
         Or (curInfMethod = InfiltrationFunctions.ModifiedKostiakovFormula)) Then

            Dim FS As Double = mSystemGeometry.FurrowSpacing.Value
            Dim WP0 As Double = mUnit.UpstreamWettedPerimeter()

            ' Conversion from FurrowSpacing to RepresentativeUpstreamWettedPerimeter
            If (curWPmethod = WettedPerimeterMethods.FurrowSpacing) Then
                If (newWPmethod = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter) Then
                    mConvertWP = Me.WettedPerimeterMessage(curWPmethod, newWPmethod)
                    mRatioWP = FS / WP0
                End If
            End If

            ' Conversion from RepresentativeUpstreamWettedPerimeter to FurrowSpacing
            If (curWPmethod = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter) Then
                If (newWPmethod = WettedPerimeterMethods.FurrowSpacing) Then
                    mConvertWP = Me.WettedPerimeterMessage(curWPmethod, newWPmethod)
                    mRatioWP = WP0 / FS
                End If
            End If

        End If

    End Sub

    Public Sub ConvertWettedPerimeter()

        If (mConvertWP = DialogResult.Yes) Then
            Dim dValue As Double
            '
            ' Convert Kostiakov Function (KF) parameters
            '
            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_KF   ' k
            dValue = kParam.Value
            dValue *= mRatioWP

            kParam.Value = dValue
            kParam.Source = ValueSources.Calculated
            mSoilCropProperties.KostiakovK_KF = kParam
            '
            ' Convert Modified Kostiakov (MK) parameters
            '
            Dim bParam As KostiakovBParameter = mSoilCropProperties.KostiakovB_MK   ' b
            dValue = bParam.Value
            dValue *= mRatioWP

            bParam.Value = dValue
            bParam.Source = ValueSources.Calculated
            mSoilCropProperties.KostiakovB_MK = bParam

            kParam = mSoilCropProperties.KostiakovK_MK   ' k
            dValue = kParam.Value
            dValue *= mRatioWP

            kParam.Value = dValue
            kParam.Source = ValueSources.Calculated
            mSoilCropProperties.KostiakovK_MK = kParam
            '
            ' Convert Branch Function (BF) parameters
            '
            bParam = mSoilCropProperties.BranchB_BF         ' b
            dValue = bParam.Value
            dValue *= mRatioWP

            bParam.Value = dValue
            bParam.Source = ValueSources.Calculated
            mSoilCropProperties.BranchB_BF = bParam

            kParam = mSoilCropProperties.KostiakovK_BF      ' k
            dValue = kParam.Value
            dValue *= mRatioWP

            kParam.Value = dValue
            kParam.Source = ValueSources.Calculated
            mSoilCropProperties.KostiakovK_BF = kParam
        End If

    End Sub

#End Region

#Region " Advance / Recession Utilities "

    '*********************************************************************************************************
    ' Compute recession time (TR) at specified distance
    '*********************************************************************************************************
    Protected Function TRatDistance(ByVal Dist As Double, ByVal W As Double, ByVal WP As Double) As Double
        Dim Trec As Double = 0.0

        Dim S0 As Double = mSystemGeometry.AverageSlope
        Dim ratio As Double = 1.0
        Dim pct As Double = 0.005

        If (S0 <= 0.001) Then
            ratio -= pct - (pct * (S0 * 1000.0))
        End If

        Dim Tadv As Double = mSurfaceFlow.AdvanceAtDistance(Dist)
        Dim Z As Double = mSubsurfaceFlow.InfiltrationAtDistance(Dist * ratio)
        Dim Tau As Double = mSoilCropProperties.InfiltrationTime(Z, WP, W)

        Trec = Tadv + Tau

        Return Trec
    End Function

    '*********************************************************************************************************
    ' Compute 2 Point advance based on Upstream Flow Area (A0) and Upstream Velocity (V0).
    '
    ' Inputs:   L1      - length of 1st advance point
    '           A01     - Upstream Flow Area for point 1
    '           V01     - Upstream Flow Velocity for point 1
    '           L2      - length of 2nd advance point
    '           A02     - Upstream Flow Area for point 2
    '           V02     - Upstream Flow Velocity for point 2
    '           W       - width of border | furrow spacing
    '           WP      - wetted perimeter
    '           Qin     - border inflow rate | furrow inflow rate
    '
    ' Subroutine also uses / sets several class data members.
    '
    ' Outputs:  mDistances()    - distance along irrigation points
    '           mAdvTimes()     - advance curve
    '*********************************************************************************************************
    Protected Sub ComputeTwoPointAdvance(ByVal L1 As Double, ByVal A01 As Double, ByVal V01 As Double,
                                         ByVal L2 As Double, ByVal A02 As Double, ByVal V02 As Double,
                                         ByVal W As Double, ByVal WP As Double, ByVal Qin As Double,
                                         ByVal numDistances As Integer)

        Debug.Assert(L1 < L2, "Point 1 must be before Point 2")

        Dim area1 As Double = L1 * W
        Dim area2 As Double = L2 * W

        Dim lengthLogRatio As Double = Math.Log10(L2 / L1)

        Dim saveC As Double = c
        Dim TauC As Double = 0.0
        If (mSoilCropProperties.TimeOffsetC.Value) Then
            TauC = Srfr.SrfrAPI.InfiltrationTimeMKTO(c, k, a, b)
            c = 0.0
        End If

        ' Initial guesses
        mAdvanceTime1 = L1 / V01 + TauC
        mAdvanceTime2 = L2 / V02 + TauC

        mSurfaceVolume1 = (mSigmaY * mPhi0) * A01 * L1
        mSurfaceVolume2 = (mSigmaY * mPhi0) * A02 * L2

        Try
            Dim zTolerance As Double = 0.001            ' 0.1%

            For iter As Integer = 1 To 25
                ' Calculate surface shape factor changing advance times
                h = Math.Log10((mAdvanceTime2 + TauC) / (mAdvanceTime1 + TauC)) / lengthLogRatio
                sigmaZ = (h + a * (h - 1) + 1) / (1 + a) / (1 + h)

                ' Infiltrated Volumes based on new h & sigmaZ
                Select Case (mSoilCropProperties.InfiltrationFunction.Value)

                    Case InfiltrationFunctions.BranchFunction
                        Dim Tb As Double = BranchTime(k, a, b)
                        If (mSoilCropProperties.BranchTimeSet.Value) Then
                            Tb = mSoilCropProperties.BranchTime_BF.Value
                        End If

                        Dim depth1 As Double
                        If ((mAdvanceTime1 + TauC) <= Tb) Then
                            depth1 = (sigmaZ * k * (mAdvanceTime1 + TauC) ^ a) * WP / W             ' kt^a term
                            depth1 += c                                                             ' c
                        Else
                            depth1 = (sigmaZ * k * Tb ^ a) * WP / W                                 ' kt^a
                            depth1 += (h * b * ((mAdvanceTime1 + TauC) - Tb) / (1 + h)) * WP / W    ' bt
                            depth1 += c                                                             ' c
                        End If

                        Dim depth2 As Double
                        If ((mAdvanceTime2 + TauC) <= Tb) Then
                            depth2 = (sigmaZ * k * (mAdvanceTime2 + TauC) ^ a) * WP / W             ' kt^a
                            depth2 += c                                                             ' c
                        Else
                            depth2 = (sigmaZ * k * Tb ^ a) * WP / W                                 ' kt^a
                            depth2 += (h * b * ((mAdvanceTime2 + TauC) - Tb) / (1 + h)) * WP / W    ' bt
                            depth2 += c                                                             ' c
                        End If

                        mInfiltratedVolume1 = area1 * depth1
                        mInfiltratedVolume2 = area2 * depth2

                    Case InfiltrationFunctions.NRCSIntakeFamily
                        Dim depth1 As Double = (sigmaZ * k * (mAdvanceTime1 + TauC) ^ a) * WP / W   ' kt^a term
                        depth1 += c * WP / W                                                        ' c

                        Dim depth2 As Double = (sigmaZ * k * (mAdvanceTime2 + TauC) ^ a) * WP / W   ' kt^a
                        depth2 += c * WP / W                                                        ' c

                        mInfiltratedVolume1 = area1 * depth1
                        mInfiltratedVolume2 = area2 * depth2

                    Case InfiltrationFunctions.GreenAmpt, InfiltrationFunctions.Hydrus1D, InfiltrationFunctions.WarrickGreenAmpt
                        Debug.Assert(False)

                    Case Else ' Modified Kostiakov based
                        Dim depth1 As Double = (sigmaZ * k * (mAdvanceTime1 + TauC) ^ a) * WP / W   ' kt^a term
                        depth1 += (h * b * (mAdvanceTime1 + TauC) / (1 + h)) * WP / W               ' bt
                        depth1 += c                                                                 ' c

                        Dim depth2 As Double = (sigmaZ * k * (mAdvanceTime2 + TauC) ^ a) * WP / W   ' kt^a
                        depth2 += (h * b * (mAdvanceTime2 + TauC) / (1 + h)) * WP / W               ' bt
                        depth2 += c                                                                 ' c

                        mInfiltratedVolume1 = area1 * depth1
                        mInfiltratedVolume2 = area2 * depth2
                End Select

                ' Advance Times based on new h & sigmaZ
                Dim estimatedAdvanceTime1 As Double = (mSurfaceVolume1 + mInfiltratedVolume1) / Qin
                Dim estimatedAdvanceTime2 As Double = (mSurfaceVolume2 + mInfiltratedVolume2) / Qin

                Dim advErr1 As Double = (mAdvanceTime1 + TauC) - estimatedAdvanceTime1
                Dim advErr2 As Double = (mAdvanceTime2 + TauC) - estimatedAdvanceTime2

                ' Inflow Volumes based on new h & sigmaZ
                Dim inflowVolume1 As Double = (mAdvanceTime1 + TauC) * Qin
                Dim inflowVolume2 As Double = (mAdvanceTime2 + TauC) * Qin

                Dim volErr1 As Double = (inflowVolume1 - mSurfaceVolume1 - mInfiltratedVolume1) / inflowVolume1
                Dim volErr2 As Double = (inflowVolume2 - mSurfaceVolume2 - mInfiltratedVolume2) / inflowVolume2

                ' Is this close enough?
                If ((Math.Abs(advErr1) < zTolerance) _
                And (Math.Abs(advErr2) < zTolerance) _
                And (Math.Abs(volErr1) < zTolerance) _
                And (Math.Abs(volErr2) < zTolerance)) Then
                    ' Yes, exit loop
                    Exit For
                Else
                    ' No, save new Advance Time estimates and try again
                    mAdvanceTime1 = estimatedAdvanceTime1
                    mAdvanceTime2 = estimatedAdvanceTime2
                End If
            Next

        Catch ex As Exception
        Finally
            ' Calculate surface shape factor for selected advance times
            h = Math.Log10((mAdvanceTime2 + TauC) / (mAdvanceTime1 + TauC)) / lengthLogRatio
            sigmaZ = (h + a * (h - 1) + 1) / (1 + a) / (1 + h)

            ' Clear previous irrigation curves
            mDistances.Clear()
            mAdvTimes.Clear()
            mRecTimes.Clear()
            mOppTimes.Clear()
            mInfDepths.Clear()

            ' Compute new Advance Curve
            Dim numSpaces As Integer = numDistances - 1

            For idx As Integer = 0 To numSpaces
                Dim ratio As Double = idx / numSpaces

                ' Calculate next advance point on curve
                Dim distance As Double = L2 * ratio
                Dim advTime As Double = (mAdvanceTime2 + TauC) * ratio ^ h

                ' Save advance point
                mDistances.Add(distance)
                mAdvTimes.Add(advTime)
            Next
        End Try

        c = saveC
    End Sub

    '*********************************************************************************************************
    ' Function AdvanceTable() - build/return an Advance DataTable from the Distances & AdvTimes ArrayLists
    '*********************************************************************************************************
    Public Function AdvanceTable() As DataTable

        ' Generate Advance DataTable from ArrayLists
        AdvanceTable = New DataTable(sAdvance)
        AdvanceTable.Columns.Add(sDistanceX, GetType(Double))
        AdvanceTable.Columns.Add(sTimeX, GetType(Double))
        If (mDistances.Count <= mAdvTimes.Count) Then
            For idx As Integer = 0 To mDistances.Count - 1
                Dim row As DataRow = AdvanceTable.NewRow
                row(0) = CDbl(mDistances.Item(idx))
                row(1) = CDbl(mAdvTimes.Item(idx))
                AdvanceTable.Rows.Add(row)
            Next idx
        End If

    End Function

    '*********************************************************************************************************
    ' Function ValidateTuningAdvancePandR() - validate tuning point's advance curve by checking 'r'
    '*********************************************************************************************************
    Public Function ValidateTuningAdvancePandR(ByVal PandRok As Boolean, ByVal p As Double, ByVal r As Double) As Boolean
        ValidateTuningAdvancePandR = False

        Dim title As String = mDictionary.tTuningError.Translated
        Dim msg As String = ""

        If (PandRok) Then ' p & r calculated correctly

            If (r < MinPowerAdvanceLawR) Then
                msg &= mDictionary.tAdvancePowerLawLessThan.Translated & " " & MinPowerAdvanceLawR.ToString
                msg &= Chr(13) & mDictionary.tTuningFactorsSensitiveToPoint.Translated
                msg += Chr(13)
                msg &= Chr(13) & mDictionary.tYouCanContinueAnalysis.Translated
                msg &= Chr(13) & mDictionary.tRecommendAlternativePoints.Translated
            Else
                ValidateTuningAdvancePandR = True
            End If

        Else ' p & r calculation failed
            msg &= Chr(13) & mDictionary.tAdvancePowerLawCouldNotBeCalculated.Translated
        End If

        If Not (ValidateTuningAdvancePandR) Then
            msg &= Chr(13)
            msg &= Chr(13) & mDictionary.tTryOneOrMore.Translated & ":"
            msg &= Chr(13)
            msg &= Chr(13) & "1) " & mDictionary.tIncreaseInflowRate.Translated
            msg &= Chr(13) & "2) " & mDictionary.tDecreaseLength.Translated
            msg &= Chr(13) & "3) " & mDictionary.tDecreaseWidth.Translated

            MsgBox(msg, MsgBoxStyle.Exclamation, title)
        End If

    End Function

#End Region

#Region " Irrigation Curve Utilities "

    '*********************************************************************************************************
    ' Compute irrigation curves assuming there is Runoff (i.e. Open End) using a straight line
    ' for the recession curve from TR0 to TrL.
    '
    ' Inputs:   W       - border width | furrow spacing
    '           Qin     - border inflow rate | furrow inflow rate
    '           TR0     - recession time at head of field
    '           TR1     - recession time at end of field
    '
    ' Returns   Dmin    - minimum infiltration depth
    '           Vinf    - infiltrated volume
    '
    ' Assumes mDistances() & mAdvTimes() have been previously set by ComputeTwoPointAdvance()
    '
    ' Outputs:  mRecTimes()     - recession curve
    '           mOppTimes()     - opportunity time curve
    '           mInfDepths()    - infiltration curve
    '*********************************************************************************************************
    Protected Sub ComputeIrrigationCurves(ByVal W As Double, ByVal Qin As Double,
                                          ByVal TR0 As Double, ByVal TR1 As Double,
                                          ByRef Dmin As Double, ByRef Vinf As Double)

        ' Clear previous irrigation curves
        Debug.Assert(1 < mDistances.Count)
        Debug.Assert(1 < mAdvTimes.Count)

        mRecTimes.Clear()
        mOppTimes.Clear()
        mInfDepths.Clear()

        Dim numSpaces As Integer = mDistances.Count - 1
        Dim length As Double = mDistances(numSpaces)
        Dim trDelta As Double = TR1 - TR0

        If (mSoilCropProperties.SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
            mSoilCropProperties.SrfrInfiltration.RefInflow.Q0 = Qin
            mSoilCropProperties.SrfrInfiltration.RefInflow.L = length
        End If

        Vinf = 0.0

        For idx As Integer = 0 To numSpaces
            Dim ratio As Double = idx / numSpaces

            ' Calculate next point on curves
            Dim Tadv As Double = mAdvTimes(idx)
            Dim Trec As Double = Math.Max(TR0 + trDelta * ratio, Tadv)
            Dim Tau As Double = Trec - Tadv
            Dim Z As Double = mSoilCropProperties.InfiltrationDepth(Tau)

            ' Save point
            mRecTimes.Add(Trec)
            mOppTimes.Add(Tau)
            mInfDepths.Add(Z)

            Vinf += Z    ' Sum infiltrated depths
        Next

        ' Return Dmin & Vinf after infiltration
        Dmin = Math.Min(mInfDepths(0), mInfDepths(numSpaces))

        Vinf -= mInfDepths(0) / 2.0             ' Subtract 1/2 of first point
        Vinf -= mInfDepths(numSpaces) / 2.0     ' Subtract 1/2 of last point
        Vinf /= numSpaces                       ' Average infiltrated depth
        Vinf *= length * W                      ' Multiply by area to get volume

    End Sub

    '*********************************************************************************************************
    ' Compute irrigation curves assuming Runoff (i.e. Open End) using a sloped line followed by a level line
    ' for the recession curve from TR0 to TrL.  The change from sloped line to level line occurs at Xdist.
    '
    ' Inputs:   W       - Width of Border / Furrow
    '           WP      - wetted perimeter (Border Width, Furrow Spacing, Upstream Rep. WP)
    '           Xdist   - recession transition point
    '           TR0     - recession time at head of field
    '           TR1     - recession time at end of field
    '
    ' Returns   Dmin    - minimum infiltration depth
    '           Vinf    - infiltrated volume
    '
    ' Assumes mDistances() & mAdvTimes() have been previously set by ComputeTwoPointAdvance()
    '
    ' Outputs:  mRecTimes()     - recession curve
    '           mOppTimes()     - opportunity time curve
    '           mInfDepths()    - infiltration curve
    '*********************************************************************************************************
    Protected Sub ComputeIrrigationCurves(ByVal W As Double, ByVal WP As Double, ByVal Xdist As Double,
                                          ByVal TR0 As Double, ByVal trl As Double,
                                          ByRef Dmin As Double, ByRef Vinf As Double)

        ' Clear previous irrigation curves
        Debug.Assert(1 < mDistances.Count)
        Debug.Assert(1 < mAdvTimes.Count)

        mRecTimes.Clear()
        mOppTimes.Clear()
        mInfDepths.Clear()

        Dim numSpaces As Integer = mDistances.Count - 1
        Dim length As Double = mDistances(numSpaces)
        Dim recSpaces As Integer = (mDistances.Count * Xdist) / length
        Dim trDelta As Double = trl - TR0

        Debug.Assert((0.0 <= Xdist) And (Xdist <= length))

        Vinf = 0.0

        For idx As Integer = 0 To numSpaces
            Dim distRatio As Double = idx / numSpaces
            Dim recRatio As Double = idx / recSpaces

            Dim Tadv As Double = mAdvTimes(idx)
            Dim Trec As Double = trl

            If (idx < recSpaces) Then
                Trec = Math.Max(TR0 + trDelta * recRatio, Tadv)
            Else
                Trec = Math.Max(trl, Tadv)
            End If

            Dim Tau As Double = Math.Max(Trec - Tadv, 0)
            Dim Z As Double = mSoilCropProperties.InfiltrationDepth(Tau)

            mRecTimes.Add(Trec)
            mOppTimes.Add(Tau)
            mInfDepths.Add(Z)

            Vinf += Z    ' Sum infiltrated depths
        Next

        ' Return Dmin & Vinf after infiltration
        Dmin = Math.Min(mInfDepths(0), mInfDepths(numSpaces))

        Vinf -= mInfDepths(0) / 2.0             ' Subtract 1/2 of first point
        Vinf -= mInfDepths(numSpaces) / 2.0     ' Subtract 1/2 of last point
        Vinf /= numSpaces                       ' Average infiltrated depth
        Vinf *= length * W                      ' Multiply by area to get volume

    End Sub

    '*********************************************************************************************************
    ' Modify irrigation curves adding pond above head end for sloping field
    '*********************************************************************************************************
    Protected Sub AddConstantDepth(ByVal W As Double, ByVal WP As Double, ByVal PondVolume As Double,
                                   ByRef Dmin As Double, ByRef Vinf As Double)

        Dmin = Double.MaxValue
        Vinf = 0.0

        ' Level depth to be infiltrated
        Dim numSpaces As Integer = mDistances.Count - 1
        Dim length As Double = mDistances(numSpaces)
        Dim depth As Double = PondVolume / (length * W)

        ' Infiltrate level volume evenly across furrow
        For idx As Integer = 0 To numSpaces
            Dim Z As Double = mInfDepths(idx) + depth ' add pond depth

            Dim Tau As Double = mSoilCropProperties.InfiltrationTime(Z, WP, W)
            Dim Tadv As Double = mAdvTimes(idx)
            Dim Trec As Double = Tadv + Tau

            ' Save modified curve values
            mRecTimes(idx) = Trec
            mOppTimes(idx) = Tau
            mInfDepths(idx) = Z

            ' Check for new Dmin
            If (Dmin > Z) Then
                Dmin = Z
            End If

            Vinf += Z    ' Sum infiltrated depths
        Next

        Vinf -= mInfDepths(0) / 2.0             ' Subtract 1/2 of first point
        Vinf -= mInfDepths(numSpaces) / 2.0     ' Subtract 1/2 of last point
        Vinf /= numSpaces                       ' Average infiltrated depth
        Vinf *= length * W                  ' Multiply by area to get volume

    End Sub

    '*********************************************************************************************************
    ' Modify irrigation curves to infiltrate pond at end of sloping field
    '*********************************************************************************************************
    Protected Sub AddSlopingFieldPond(ByVal W As Double, ByRef WP As Double, ByVal PondVolume As Double,
                                      ByRef Dmin As Double, ByRef Vinf As Double)

        ' If field is level, use different algorithm
        Dim S0 As Double = mSystemGeometry.AverageSlope
        Debug.Assert(0.0 < S0, "Slope must not be level")

        ' Calculate pond dimensions at end of furrow
        Dim numSpaces As Integer = mDistances.Count - 1
        Dim length As Double = mDistances(numSpaces)
        Dim pondLength, pondDepth As Double

        mSystemGeometry.PondDimensions(PondVolume, length, W, pondDepth, pondLength)

        Dim pondStart As Double = length - pondLength
        If (pondStart <= 0.0) Then
            ' Pond covers entire field
            Dim fieldVolume As Double = mSystemGeometry.PondVolume(S0, length, WP)
            Dim levelVolume As Double = PondVolume - fieldVolume

            ' Infiltrate level portion of pond
            AddConstantDepth(W, WP, levelVolume, Dmin, Vinf)

            ' Pond depth at head of furrow is now zero
            pondDepth = pondLength * S0
        End If

        ' Adjust irrigation curves for ponding (i.e. Blocked End)
        Dim incr As Double
        Dim depth As Double = 0

        ' Reset DMin and Infiltrated volume
        Dmin = Double.MaxValue
        Vinf = 0.0

        For idx As Integer = 0 To numSpaces
            Dim distance As Double = mDistances(idx)
            Dim Z As Double = mInfDepths(idx)

            ' Adjust for pond at end of furrow
            If (pondStart < distance) Then

                pondLength = length - distance

                ' Field is sloping; recession time varies
                Dim volStart As Double = mSystemGeometry.PondVolume(S0, length - pondStart, WP)
                Dim volDist As Double = mSystemGeometry.PondVolume(S0, pondLength, WP)

                If (0 < pondLength) Then
                    incr = (volStart - volDist) / (pondLength * WP)
                    depth += incr
                Else
                    incr /= 2.0
                    depth += incr
                End If

                Z += depth

                Dim Tau As Double = mSoilCropProperties.InfiltrationTime(Z, WP, W)
                Dim Tadv As Double = mAdvTimes(idx)
                Dim Trec As Double = Tadv + Tau

                ' Save modified curve values
                mRecTimes(idx) = Trec
                mOppTimes(idx) = Tau
                mInfDepths(idx) = Z

                pondStart = distance
            End If

            ' Find new DMin after pond infiltrates
            If (Dmin > Z) Then
                Dmin = Z
            End If

            Vinf += Z    ' Sum infiltrated depths
        Next

        Vinf -= mInfDepths(0) / 2.0             ' Subtract 1/2 of first point
        Vinf -= mInfDepths(numSpaces) / 2.0     ' Subtract 1/2 of last point
        Vinf /= numSpaces                       ' Average infiltrated depth
        Vinf *= length * W                      ' Multiply by area to get volume

    End Sub

#End Region

#Region " Performance Parameters Utilties "

    '*********************************************************************************************************
    ' Compute Performance Parameters from irrigation curves
    '
    ' Inputs:   length  - length of field
    '           width   - width of field/furrow
    '*********************************************************************************************************
    Protected Sub ComputePerformanceParameters(ByVal length As Double, ByVal width As Double)

        Dim area As Double = length * width                                             ' m^2
        Dim hectares As Double = area / SquareMetersPerHectare                          ' hectares
        Dim numSpaces As Integer = mDistances.Count - 1

        ' Applied & Required Depths
        mDApp = mInflowVolume / area
        mDReq = mInflowManagement.RequiredDepth.Value

        ' Cost
        Dim Vml As Double = mInflowVolume / CubicMetersPerMegaLiter                     ' Megaliters applied
        Dim unitVolumeCost As Double = mUnit.InflowManagementRef.UnitWaterCost.Value    ' $ / ML
        mCost = Vml * unitVolumeCost / hectares                                         ' $ / hectare

        ' Flow Depth is unknown
        Ymax = 0.0

        '*****************************************************************************************************
        ' Some Performance Parameters are dependent on Advance
        '
        mTxa = 0.0
        For idx As Integer = 0 To numSpaces
            If (0.0 < CDbl(mOppTimes(idx))) Then
                mTxa = CDbl(mAdvTimes(idx))
            End If
        Next

        If (0 < mOppTimes(numSpaces)) Then
            ' Advance reached end of field; compute relative advance (R)
            mTL = CDbl(mAdvTimes(numSpaces))

            If (mTL <= mTco) Then
                ' Relative Advance time based; 1.0 <= R
                mXR = Math.Max(1.0, mTco / mTL)
            Else
                ' Relative Advance distance based; R <= 1.0

                ' Find advance point at Tco
                Dim idx As Integer
                Dim adv2, dst2 As Double

                For idx = 1 To numSpaces
                    adv2 = CDbl(mAdvTimes(idx))
                    dst2 = CDbl(mDistances(idx))
                    If (mTco <= adv2) Then
                        Exit For
                    End If
                    idx += 1
                Next

                Dim adv1 As Double = CDbl(mAdvTimes(idx - 1))
                Dim dst1 As Double = CDbl(mDistances(idx - 1))

                Dim ratio As Double = (mTco - adv1) / (adv2 - adv1)

                mXR = Math.Min(1.0, (dst1 + ((dst2 - dst1) * ratio)) / length)
            End If

            ' Infiltrated depth
            mDInf = mInfiltratedVolume / area

            ' Minimum Depth
            mDMin = CDbl(mInfDepths(0))
            For idx As Integer = 1 To numSpaces
                Dim infDepth As Double = CDbl(mInfDepths(idx))
                If (mDMin > infDepth) Then
                    mDMin = infDepth
                End If
            Next
        Else
            ' Advance did not reach end of field
            mTL = Double.NaN
            mXR = 0.0

            ' Infiltrated depth = Applied Depth
            mDInf = mDApp

            ' Zero Minimum Depth
            mDMin = 0.0

            ' No Runoff
            mRunoffVolume = 0.0
        End If

        ' Runoff Depth
        mRoFraction = mRunoffVolume / mInflowVolume
        mRoDepth = mRunoffVolume / area

        '**************************************************************************************
        ' Some Performance Parameters are independent of Advance
        '

        ' Low Fraction Depth
        mDLf = AverageInfiltratedDepthLQ(mDistances, mInfDepths)

        ' Deep Percolation
        mDpDepth = Math.Min(DeepPercolationDepth(mDistances, mInfDepths, mDReq), mDApp)
        mDpFraction = mDpDepth / mDApp

        ' Application Efficiency
        mAE = Math.Min((mDInf - mDpDepth) / mDApp, 1.0)

        ' Requirement Efficiency
        mRE = Math.Min((mDInf - mDpDepth) / mDReq, 1.0)

        ' Potential Application Efficiency (min & lq)
        Dim dpMin As Double = Math.Min(DeepPercolationDepth(mDistances, mInfDepths, mDMin), mDApp)
        mPAEmin = Math.Min((mDInf - dpMin) / mDApp, 1.0)

        Dim dpLf As Double = Math.Min(DeepPercolationDepth(mDistances, mInfDepths, mDLf), mDApp)
        mPAElq = Math.Min((mDInf - dpLf) / mDApp, 1.0)

        ' Distribution Uniformity (min & lq)
        mDUmin = mDMin / mDInf
        mDUlq = mDLf / mDInf

        ' Adequacy (min & lq)
        mADmin = mDMin / mDReq
        mADlq = mDLf / mDReq

    End Sub

    '*********************************************************************************************************
    ' Calculate Low-Quarter Average Infiltrated Depth from Infiltrated Depths array list
    '*********************************************************************************************************
    Public Shared Function AverageInfiltratedDepthLQ(ByVal distances As ArrayList,
                                                     ByVal infDepths As ArrayList) As Double
        Dim DavgLQ As Double = 0.0
        '
        ' The Low-Quarter Average Infiltrated Depth is calculated as the:
        '
        '       Sum of each segment's average infiltrated depth / Quarter Field Length
        '       for the Low-Quarter of the field
        '

        ' N+1 points create N segments; minimum of 1 segment (i.e. 2 points)
        Dim points As Integer = distances.Count
        If (2 <= points) Then
            '
            ' Build list of segment infiltrated depths
            '
            Dim lengths As ArrayList = New ArrayList
            Dim depths As ArrayList = New ArrayList

            ' Get the start point of the 1st segment
            Dim x1 As Double = distances(0)
            Dim z1 As Double = infDepths(0)
            Dim x2 As Double
            Dim z2 As Double

            For idx As Integer = 1 To points - 1
                ' Get the end point of the segment
                x2 = distances(idx)
                z2 = infDepths(idx)

                ' Save the segment data
                lengths.Add(x2 - x1)           ' Length of segment
                depths.Add((z1 + z2) / 2.0)  ' Average depth for segment

                ' Start of the next segment is the end of the previous segment
                x1 = x2
                z1 = z2
            Next
            '
            ' Sort list of infiltrated depths (bubble sort)
            '
            Dim _temp As Object
            For idx As Integer = 0 To depths.Count
                Dim _swap As Boolean = False
                For _jdx As Integer = 0 To depths.Count - 2
                    z1 = CDbl(depths(_jdx))
                    z2 = CDbl(depths(_jdx + 1))
                    If (z2 < z1) Then
                        ' Swap locations
                        _swap = True
                        ' Swap depths
                        _temp = depths(_jdx)
                        depths(_jdx) = depths(_jdx + 1)
                        depths(_jdx + 1) = _temp
                        ' Swap lengths
                        _temp = lengths(_jdx)
                        lengths(_jdx) = lengths(_jdx + 1)
                        lengths(_jdx + 1) = _temp
                    End If
                Next
                If Not (_swap) Then
                    Exit For
                End If
            Next
            '
            ' Sum the infiltrated depths for the Low-Quarter
            '
            x1 = distances(0)               ' Start of field
            x2 = distances(points - 1)     ' End of field

            Dim _lengthLQ As Double = (x2 - x1) / 4.0
            Dim _length1 As Double = 0.0
            Dim _length2 As Double

            For idx As Integer = 0 To depths.Count - 2
                _length2 = CDbl(lengths(idx))
                z2 = CDbl(depths(idx))
                If (_length1 + _length2 < _lengthLQ) Then
                    ' Haven't reached Low-Quarter length, yet
                    _length1 += _length2
                    ' Sum the average segment depths weighted by the segment lengths
                    DavgLQ += z2 * _length2
                Else
                    ' Have reached Low-Quarter length; interpolate last value
                    Dim _remainingLength As Double = _lengthLQ - _length1
                    _length1 += _remainingLength
                    ' Sum the average segment depths weighted by the segment lengths
                    DavgLQ += z2 * _remainingLength

                    Exit For
                End If
            Next
            '
            ' Divide sum of weighted segment depths by Low-Quarter field length to get average depth
            '
            DavgLQ /= _lengthLQ    ' / Low-Quarter Field length
        End If

        Return DavgLQ
    End Function

    '*********************************************************************************************************
    ' Calculate Deep Percolation Depth from an Infiltrated Depths array list
    '*********************************************************************************************************
    Public Shared Function DeepPercolationDepth(ByVal distances As ArrayList, ByVal infDepths As ArrayList,
                                                ByVal Dreq As Double) As Double
        ' Average Infiltrated Depth
        Dim Ddp As Double = 0.0
        '
        ' The Deep Percolation Depth is calculated as the:
        '
        '   Infiltrated Depth area beyond the Required Depth
        '

        ' N+1 points create N segments; minimum of 1 segment (i.e. 2 points)
        Dim points As Integer = distances.Count
        If (2 <= points) Then
            ' Get the start point of the 1st segment
            Dim x1 As Double = CDbl(distances(0))
            Dim z1 As Double = CDbl(infDepths(0))
            Dim x2 As Double
            Dim z2 As Double
            Dim delta1 As Double
            Dim delta2 As Double

            ' Compute Average Infiltrated Depth
            For idx As Integer = 1 To points - 1
                ' Get the segment's end point
                x2 = CDbl(distances(idx))
                z2 = CDbl(infDepths(idx))

                ' Sum the average segment depths weighted by the segment lengths
                If ((z1 < Dreq) And (Dreq < z2)) Then
                    delta2 = z2 - Dreq
                    Ddp += ((delta2 ^ 2) * (x2 - x1)) / ((z2 - z1) * 2.0)
                ElseIf ((z2 < Dreq) And (Dreq < z1)) Then
                    delta1 = z1 - Dreq
                    Ddp += ((delta1 ^ 2) * (x2 - x1)) / ((z1 - z2) * 2.0)
                ElseIf ((Dreq <= z1) And (Dreq <= z2)) Then
                    delta1 = z1 - Dreq
                    delta2 = z2 - Dreq
                    Ddp += ((delta1 + delta2) / 2.0) * (x2 - x1)
                End If

                ' Start of the next segment is the end of the previous segment
                x1 = x2
                z1 = z2
            Next

            ' Divide sum of weighted segment depths by field length to get average depth
            x1 = CDbl(distances(0))
            x2 = CDbl(distances(points - 1))
            Ddp /= (x2 - x1)
        End If

        Return Ddp
    End Function

#End Region

#Region " Errors & Warnings "
    '
    ' Basic check of setup errors and warnings for all Analyses
    '
    Public Overridable Sub UpdateSetupErrorsAndWarnings()
        CheckSetupErrorsAndWarnings()
        CheckGeometryErrors()
        CheckInfiltrationErrors()
        CheckRoughnessErrors()
        CheckInflowErrors()
        CheckSolutionModelErrors()
    End Sub

#Region " Setup Errors "
    '
    ' Setup Errors prevent an Analysis from running
    '
    ' Input(s):     _code       Unique error code
    '               _id         Short error identification string
    '               _detail     Long error detail string
    '
    Public Sub AddSetupError(ByVal _code As Integer, ByVal _id As String, ByVal _detail As String)

        ' Check if this error is already in the list
        Dim _errorItem As ErrorWarningItem
        _id = _id.Trim
        _detail = _detail.Trim

        For Each _errorItem In SetupErrorItems ' scan errors already in list
            If ((_code = _errorItem.Code) And (_id = _errorItem.ID) And (_detail = _errorItem.Detail)) Then
                _errorItem.IncCount() ' Found it, increment its count & return
                Return
            End If
        Next _errorItem

        ' This is a new error, add it to the list
        _errorItem = New ErrorWarningItem(_code, _id, _detail)
        mSetupErrorItems.Add(_errorItem)
        mSetupErrors = mSetupErrors Or _code

    End Sub

    Public Sub RemoveSetupError(ByVal _code As Integer, ByVal _id As String, ByVal _detail As String)

        ' Check if this error is in the list
        Dim _errorItem As ErrorWarningItem
        _id = _id.Trim
        _detail = _detail.Trim

        For Each _errorItem In SetupErrorItems
            If ((_code = _errorItem.Code) _
            And (_id = _errorItem.ID) _
            And (_detail = _errorItem.Detail)) Then
                ' Found it, remove it
                SetupErrorItems.Remove(_errorItem)
                Return
            End If
        Next

    End Sub

    Public Function HasSetupError(ByVal _code As Integer) As Boolean
        ' Check if error is in the list
        For Each _errorItem As ErrorWarningItem In SetupErrorItems
            If (_code = _errorItem.Code) Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function HasOnlySetupError(ByVal _code As Integer) As Boolean
        ' Check if error is the only one in the list
        Dim inList As Boolean = False
        For Each _errorItem As ErrorWarningItem In SetupErrorItems
            If (_code = _errorItem.Code) Then ' error is in the list
                inList = True
            Else ' another error is in the list
                Return False
            End If
        Next

        Return inList
    End Function

    Public Function HasSetupErrors() As Boolean
        Dim _hasErrors As Boolean = (0 < SetupErrorItems.Count)
        Return _hasErrors
    End Function

    Public Sub ClearSetupErrors()
        mSetupErrors = 0
        If (mSetupErrorItems IsNot Nothing) Then
            mSetupErrorItems.Clear()
            mSetupErrorItems = Nothing
        End If

        mSetupErrorItems = New ArrayList
    End Sub
    '
    ' Analysis Baseclass method clears setup error list; subclass loads errors
    '
    Public Overridable Function CheckSetupErrors() As Boolean
        ClearSetupErrors() ' Clear all error indicators
        Dim _hasErrors As Boolean = Me.HasSetupErrors ' Check for current setup errors
        Return _hasErrors
    End Function

    '*********************************************************************************************************
    ' Sub CheckGeometryErrors() - Check System Geometry parameter errors
    '*********************************************************************************************************
    Public Overridable Sub CheckGeometryErrors()

        ' Get System Geometry data
        Dim _length As Double = mSystemGeometry.Length.Value
        Dim _bottomDescription As Integer = mSystemGeometry.BottomDescription.Value
        Dim _elevationSet As DataSet = mSystemGeometry.ElevationTable.Value
        Dim _elevationTable As DataTable = _elevationSet.Tables(0)
        Dim _slopeSet As DataSet = mSystemGeometry.SlopeTable.Value
        Dim _slopeTable As DataTable = _slopeSet.Tables(0)

        ' Validate Bottom Description & definition
        Select Case (_bottomDescription)
            Case BottomDescriptions.ElevationTable ', BottomDescriptions.AvgFromElevTable
                ' Validate Elevation Table data
                Dim _elevationCount As Integer = _elevationTable.Rows.Count
                If (2 <= _elevationCount) Then
                    Dim _firstDistance As Double = CDbl(_elevationTable.Rows(0).Item(sDistanceX))
                    Dim _lastDistance As Double = CDbl(_elevationTable.Rows(_elevationCount - 1).Item(sDistanceX))

                    ' First elevation distance must be at head of field
                    If Not (0.0 = _firstDistance) Then
                        AddSetupError(ErrorFlags.InvalidElevationTable,
                                 mDictionary.tInvalidElevationTableID.Translated,
                                 mDictionary.tInvalidElevationTableDetail.Translated)
                    End If

                    ' Last elevation distance must be at end of field
                    If Not (mSystemGeometry.LengthProperty.ToBeCalculated) Then
                        If Not (ThisClose(_length, _lastDistance, OneDecimeter)) Then
                            AddSetupError(ErrorFlags.InvalidElevationTable,
                                     mDictionary.tInvalidElevationTableID.Translated,
                                     mDictionary.tInvalidElevationTableDetail.Translated)
                        End If
                    End If
                End If
            Case BottomDescriptions.SlopeTable ', BottomDescriptions.AvgFromSlopeTable
                ' Validate Slope Table data
                Dim _slopeCount As Integer = _slopeTable.Rows.Count
                If (1 <= _slopeCount) Then
                    Dim _firstDistance As Double = CDbl(_slopeTable.Rows(0).Item(sDistanceX))
                    Dim _lastDistance As Double = CDbl(_slopeTable.Rows(_slopeCount - 1).Item(sDistanceX))

                    ' First slope distance must be at head of field
                    If Not (0.0 = _firstDistance) Then
                        AddSetupError(ErrorFlags.InvalidSlopeTable,
                                 mDictionary.tInvalidSlopeTableID.Translated,
                                 mDictionary.tInvalidSlopeTableDetail.Translated)
                    End If

                    ' Last slope distance cannot be at or after end of field
                    If Not (mSystemGeometry.LengthProperty.ToBeCalculated) Then
                        If (_length <= _lastDistance) Then
                            AddSetupError(ErrorFlags.InvalidSlopeTable,
                                     mDictionary.tInvalidSlopeTableID.Translated,
                                     mDictionary.tInvalidSlopeTableDetail.Translated)
                        End If
                    End If
                End If
        End Select
    End Sub

    '*********************************************************************************************************
    ' Sub CheckInfiltrationErrors() - Check Infiltration parameter errors
    '*********************************************************************************************************
    Public Overridable Sub CheckInfiltrationErrors()

        Dim infiltrationFunction As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value
        Dim wettedPerimeter As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value
        Dim roughnessMethod As RoughnessMethods = mSoilCropProperties.RoughnessMethod.Value

        Select Case (infiltrationFunction)

            Case InfiltrationFunctions.GreenAmpt

                If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                    ' Green-Ampt not available for Furrows
                    AddSetupError(ErrorFlags.GreenAmptNotAvailable,
                             mDictionary.tGreenAmptNotAvailable.Translated,
                             mDictionary.tGreenAmptNotAvailableForFurrows.Translated)
                End If

            Case InfiltrationFunctions.WarrickGreenAmpt

                If Not (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then ' Basin/Border
                    ' Warrick Green-Ampt not available for Basins/Borders
                    AddSetupError(ErrorFlags.WarrickGreenAmptNotAvailable,
                             mDictionary.tWarrickGreenAmptNotAvailable.Translated,
                             mDictionary.tWarrickGreenAmptNotAvailableForBorders.Translated)
                End If

            Case InfiltrationFunctions.Hydrus1D

                If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                    ' HYDRUS-1D not available for Furrows
                    AddSetupError(ErrorFlags.Hydrus1DNotAvailable,
                             mDictionary.tHydrus1DNotAvailable.Translated,
                             mDictionary.tHydrus1DNotAvailableForFurrows.Translated)
                Else ' Basin/Border
                    'JLS
                End If

            Case Else ' Kostiakov

                ' Get Kostiakov infiltration parameters
                Dim k As Double = mSoilCropProperties.KostiakovK
                Dim a As Double = mSoilCropProperties.KostiakovA
                Dim b As Double = mSoilCropProperties.KostiakovB
                Dim c As Double = mSoilCropProperties.KostiakovC

                If ((Double.IsNaN(k)) Or (k < MinimumKostiakovK)) Then
                    AddSetupError(ErrorFlags.InvalidKostiakovK,
                             mDictionary.tInvalidKostiakovKID.Translated,
                             mDictionary.tInvalidKostiakovKDetail.Translated)
                End If

                If (Double.IsNaN(a)) Then
                    AddSetupError(ErrorFlags.InvalidKostiakovA,
                             mDictionary.tInvalidKostiakovAID.Translated,
                             mDictionary.tInvalidKostiakovADetail.Translated)
                ElseIf ((a < mWinSRFR.MinimumKostiakovA) Or (MaximumKostiakovA < a)) Then
                    AddSetupError(ErrorFlags.InvalidKostiakovA,
                             mDictionary.tInvalidKostiakovAID.Translated,
                             mDictionary.tInvalidKostiakovADetail.Translated)
                End If

                If ((Double.IsNaN(b)) Or (b < MinimumKostiakovB)) Then
                    AddSetupError(ErrorFlags.InvalidKostiakovB,
                             mDictionary.tInvalidKostiakovBID.Translated,
                             mDictionary.tInvalidKostiakovBDetail.Translated)
                End If

                If ((Double.IsNaN(c)) Or (c < MinimumKostiakovC)) Then
                    AddSetupError(ErrorFlags.InvalidKostiakovC,
                             mDictionary.tInvalidKostiakovCID.Translated,
                             mDictionary.tInvalidKostiakovCDetail.Translated)
                End If

                ' Additional check for Branch Function
                If (infiltrationFunction = InfiltrationFunctions.BranchFunction) Then
                    If (mSoilCropProperties.BranchTimeSet.Value) Then
                        Dim Tb As Double = mSoilCropProperties.BranchTime_BF.Value
                        Dim dZdT As Double = mSoilCropProperties.InfiltrationRate(Tb)
                        If (dZdT < b) Then
                            AddSetupError(ErrorFlags.InvalidBranchB,
                                     mDictionary.tInvalidBranchBID.Translated,
                                     mDictionary.tInvalidBranchBDetail.Translated)
                        End If
                    End If
                End If

                ' Additional checks for NRCS
                If (infiltrationFunction = InfiltrationFunctions.NRCSIntakeFamily) Then
                    Select Case roughnessMethod
                        Case RoughnessMethods.ManningN, RoughnessMethods.NrcsSuggestedManningN
                            ' NRCS requires Manning n
                        Case Else
                            AddSetupError(ErrorFlags.InvalidNrcsManning,
                                      mDictionary.tInvalidNrcsManningID.Translated,
                                      mDictionary.tInvalidNrcsManningDetail.Translated)
                    End Select

                    Dim leastS0 As Double = mSystemGeometry.AverageSlope
                    Select Case (mSystemGeometry.BottomDescription.Value)
                        Case BottomDescriptions.ElevationTable, BottomDescriptions.SlopeTable
                            leastS0 = mSystemGeometry.LeastSlopeFromElevationTable
                    End Select
                    If (leastS0 < 0.0) Then
                        AddSetupError(ErrorFlags.InvalidSlope,
                                  mDictionary.tInvalidInfiltrationSlopeID.Translated,
                                  mDictionary.tInvalidInfiltrationSlopeDetail.Translated)
                    End If
                End If

                ' Additional check for RUWP
                If (wettedPerimeter = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter) Then
                    Dim leastS0 As Double = mSystemGeometry.AverageSlope
                    Select Case (mSystemGeometry.BottomDescription.Value)
                        Case BottomDescriptions.ElevationTable, BottomDescriptions.SlopeTable
                            leastS0 = mSystemGeometry.LeastSlopeFromElevationTable
                    End Select
                    If (leastS0 < 0.0) Then
                        AddSetupError(ErrorFlags.InvalidSlope,
                                  mDictionary.tInvalidInfiltrationSlopeID.Translated,
                                  mDictionary.tInvalidInfiltrationSlopeDetail.Translated)
                    End If
                End If
        End Select

    End Sub

    '*********************************************************************************************************
    ' CheckRoughnessErrors() - Check Roughness parameter errors
    '*********************************************************************************************************
    Public Overridable Sub CheckRoughnessErrors()

        Dim roughnessMethod As RoughnessMethods = mSoilCropProperties.RoughnessMethod.Value

        Select Case (roughnessMethod)

            Case RoughnessMethods.ManningN, RoughnessMethods.NrcsSuggestedManningN

                Dim _n As Double = mSoilCropProperties.ManningN.Value

                ' Validate Manning N Parameters
                If (Double.IsNaN(_n)) Then
                    AddSetupError(ErrorFlags.RoughnessParameter,
                             mDictionary.tInvalidManningNID.Translated,
                             mDictionary.tInvalidManningNDetail.Translated)
                ElseIf ((_n < mWinSRFR.Nmin) Or (mWinSRFR.Nmax < _n)) Then
                    AddSetupError(ErrorFlags.RoughnessParameter,
                             mDictionary.tInvalidManningNID.Translated,
                             mDictionary.tInvalidManningNDetail.Translated)
                End If

            Case RoughnessMethods.ManningCnAn

                Dim _Cn As Double = mSoilCropProperties.ManningCn.Value
                Dim _An As Double = mSoilCropProperties.ManningAn.Value

                ' Validate Manning Cn/An Parameters
                If (Double.IsNaN(_Cn)) Then
                    AddSetupError(ErrorFlags.RoughnessParameter,
                             mDictionary.tInvalidManningCnID.Translated,
                             mDictionary.tInvalidManningCnDetail.Translated)
                ElseIf ((_Cn < mWinSRFR.CnMin) Or (mWinSRFR.CnMax < _Cn)) Then
                    AddSetupError(ErrorFlags.RoughnessParameter,
                             mDictionary.tInvalidManningCnID.Translated,
                             mDictionary.tInvalidManningCnDetail.Translated)
                End If

                If (Double.IsNaN(_An)) Then
                    AddSetupError(ErrorFlags.RoughnessParameter,
                             mDictionary.tInvalidManningAnID.Translated,
                             mDictionary.tInvalidManningAnDetail.Translated)
                ElseIf ((_An < mWinSRFR.AnMin) Or (mWinSRFR.AnMax < _An)) Then
                    AddSetupError(ErrorFlags.RoughnessParameter,
                             mDictionary.tInvalidManningAnID.Translated,
                             mDictionary.tInvalidManningAnDetail.Translated)
                End If

            Case RoughnessMethods.SayreAlbertson

                Dim _chi As Double = mSoilCropProperties.SayreChi.Value

                ' Validate Sayre/Albertson Chi Parameters
                If (Double.IsNaN(_chi)) Then
                    AddSetupError(ErrorFlags.RoughnessParameter,
                             mDictionary.tInvalidSayreChiID.Translated,
                             mDictionary.tInvalidSayreChiDetail.Translated)
                ElseIf ((_chi < mWinSRFR.ChiMin) Or (mWinSRFR.ChiMax < _chi)) Then
                    AddSetupError(ErrorFlags.RoughnessParameter,
                             mDictionary.tInvalidSayreChiID.Translated,
                             mDictionary.tInvalidSayreChiDetail.Translated)
                End If

            Case Else

                AddSetupError(ErrorFlags.RoughnessParameter,
                        mDictionary.tInvalidRoughnessMethodID.Translated,
                        mDictionary.tInvalidRoughnessMethodDetail.Translated)

        End Select

    End Sub

    '*********************************************************************************************************
    ' Sub CheckInflowErrors() - Check Inflow parameter errors
    '*********************************************************************************************************
    Public Overridable Sub CheckInflowErrors()

        Dim inflowError As InflowManagement.InflowErrors = InflowManagement.InflowErrors.NoError

        ' Start with the most general inflow error
        Dim errorFlag As ErrorFlags = ErrorFlags.Inflow
        Dim errorID As String = mDictionary.tInvalidInflowID.Translated
        Dim errorDetail As String = mDictionary.tInvalidInflowDetail.Translated

        ' Validate inflow method dependent inflow
        Dim inflowMethod As InflowMethods = mInflowManagement.InflowMethod.Value
        Select Case (inflowMethod)

            Case InflowMethods.Surge

                inflowError = mInflowManagement.ValidateSurge

            Case InflowMethods.Cablegation

                inflowError = mInflowManagement.ValidateCablegation

            Case InflowMethods.TabulatedInflow

                ' Refine to general Tabulated Inflow error
                errorFlag = ErrorFlags.TabulatedInflow
                errorID = mDictionary.tInvalidInflowTableID.Translated
                errorDetail = mDictionary.tInvalidInflowTableDetail.Translated

                inflowError = mInflowManagement.ValidateTabulatedInflow

                If Not (inflowError = InflowManagement.InflowErrors.NoError) Then ' there is an inflow error

                    Select Case (inflowError) ' get specific error's detail
                        Case InflowManagement.InflowErrors.FirstTimeNotZero
                            errorDetail = mDictionary.tInvalidInflowTime0.Translated
                        Case InflowManagement.InflowErrors.FirstRateIsZero
                            errorDetail = mDictionary.tInvalidInflowRate0.Translated
                        Case InflowManagement.InflowErrors.TimesNotMonotonic
                            errorDetail = mDictionary.tInvalidInflowTimesNotMonotonic.Translated
                        Case InflowManagement.InflowErrors.RateNotPositive
                            errorDetail = mDictionary.tInvalidInflowRate.Translated
                    End Select

                    AddSetupError(errorFlag, errorID, errorDetail)

                Else ' no error

                    ' Validate inflow volume
                    inflowError = mInflowManagement.ValidateInflowVolume

                    If (inflowError = InflowManagement.InflowErrors.NoAppliedVolume) Then
                        errorDetail = mDictionary.tInvalidInflowVolume.Translated
                        AddSetupError(errorFlag, errorID, errorDetail)
                    End If
                End If

            Case Else ' Assume InflowMethods.StandardHydrograph

                ' Refine to general Standare Hydrograph error
                errorFlag = ErrorFlags.StandardHydrograph
                errorID = mDictionary.tInvalidStandardHydrographID.Translated
                errorDetail = mDictionary.tInvalidStandardHydrographDetail.Translated

                inflowError = mInflowManagement.ValidateStandardHydrograph

                If Not (inflowError = InflowManagement.InflowErrors.NoError) Then ' there is an inflow error

                    Select Case (inflowError) ' get specific error's detail
                        Case InflowManagement.InflowErrors.RateNotPositive
                            errorDetail = mDictionary.tInvalidInflowRate.Translated
                        Case InflowManagement.InflowErrors.CutoffInvalid
                            errorDetail = mDictionary.tInvalidInflowCutoff.Translated
                        Case InflowManagement.InflowErrors.CutbackInvalid
                            errorDetail = mDictionary.tInvalidInflowCutback.Translated
                    End Select

                    AddSetupError(errorFlag, errorID, errorDetail)
                End If

        End Select

    End Sub

    '*********************************************************************************************************
    ' Sub CheckRunoffErrors() - Check & add to SetupError list any basic Runoff errors
    '
    ' Output(s):    SetupError      - adds single error, if found, to list
    '
    ' This method only checks for basic runoff table errors:
    '   1) - table exists and is setup correctly with Time & Runoff columns
    '   2) - Times are positive (0 < T)
    '   3) - Times increase monotonically
    '   4) - Rates are positive (0 <= Qro)
    '
    ' Runoff values in relation to other user input data are checked elsewhere; see:
    '   CheckRunoffAdvanceErrors()
    '   CheckRunoffRecessionErrors()
    '*********************************************************************************************************
    Public Overridable Sub CheckRunoffErrors()

        ' Validate Runoff if downstream end of field is open (free draining) and it has been measured
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then ' free draining

            If (mInflowManagement.RunoffMeasured.Value) Then ' Runoff has been measured

                ' Start with the most general runoff error
                Dim errorFlag As ErrorFlags = ErrorFlags.Runoff
                Dim errorID As String = mDictionary.tInvalidRunoffTableID.Translated
                Dim errorDetail As String = mDictionary.tInvalidRunoffTableDetail.Translated

                ' InflowManagement method checks errors; this method adds them to the SetupError list
                Dim runoffError As InflowManagement.RunoffErrors = mInflowManagement.ValidateTabulatedRunoff()

                If Not (runoffError = InflowManagement.RunoffErrors.NoError) Then ' error found

                    Select Case (runoffError) ' get specific error's detail
                        Case InflowManagement.RunoffErrors.InvalidTable
                            ' general errorDetail is used; see above
                        Case InflowManagement.RunoffErrors.TimeNotPositive
                            errorDetail = mDictionary.tInvalidRunoffTime.Translated
                        Case InflowManagement.RunoffErrors.TimesNotMonotonic
                            errorDetail = mDictionary.tInvalidRunoffTimesNotMonotonic.Translated
                        Case InflowManagement.RunoffErrors.RateNotPositive
                            errorDetail = mDictionary.tInvalidRunoffRate.Translated
                    End Select

                    AddSetupError(errorFlag, errorID, errorDetail)

                End If ' Runoff error
            End If ' RunoffMeasured
        End If ' OpenEnd

    End Sub

    '*********************************************************************************************************
    ' Sub CheckAdvanceErrors() - Check Advance parameter errors
    '*********************************************************************************************************
    Public Overridable Sub CheckAdvanceErrors(Optional ByVal L As Double = 0.0)

        ' Start with the most general Advance Error
        Dim errorFlag As ErrorFlags = ErrorFlags.Runoff
        Dim errorID As String = mDictionary.tInvalidAdvanceTableID.Translated
        Dim errorDetail As String = mDictionary.tInvalidAdvanceTableDetail.Translated

        Dim advanceError As InflowManagement.AdvanceErrors = mInflowManagement.ValidateTabulatedAdvance(L)

        If Not (advanceError = InflowManagement.AdvanceErrors.NoError) Then

            Select Case (advanceError) ' get specific error's detail
                Case InflowManagement.AdvanceErrors.FirstDistanceNotZero, InflowManagement.AdvanceErrors.FirstTimeNotZero
                    errorDetail = mDictionary.tInvalidAdvanceTableStart.Translated
                Case InflowManagement.AdvanceErrors.DistancesNotMonotonic, InflowManagement.AdvanceErrors.TimesNotMonotonic
                    errorDetail = mDictionary.tInvalidAdvanceValuesNotMonotonic.Translated
                Case InflowManagement.AdvanceErrors.LastDistanceNotLength
                    errorDetail = mDictionary.tInvalidAdvanceTableEnd.Translated
            End Select

            AddSetupError(errorFlag, errorID, errorDetail)
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub CheckRecessionErrors() - Check Recession parameter errors
    '
    ' Input(s):     X0              - upstream X to check
    '               XL              - downstream X to check
    '
    ' Note - the Recession Curve should start at (X=0, Tco<T) with X increasing monotonically down the field.
    '        If (0 = X0), the Recession curve must start at X0
    '        If (0 < XL), the Recession curve must end at XL
    '*********************************************************************************************************
    Public Overridable Sub CheckRecessionErrors(ByVal X0 As Double, ByVal XL As Double)

        ' Start with the most general Recession Error
        Dim errorFlag As ErrorFlags = ErrorFlags.Runoff
        Dim errorID As String = mDictionary.tInvalidRecessionTableID.Translated
        Dim errorDetail As String = mDictionary.tInvalidRecessionTableDetail.Translated

        Dim advanceError As InflowManagement.RecessionErrors = mInflowManagement.ValidateTabulatedRecession(X0, XL)

        If Not (advanceError = InflowManagement.RecessionErrors.NoError) Then ' there is a recession error

            Select Case (advanceError) ' get specific error's detail
                Case InflowManagement.RecessionErrors.FirstDistanceNotZero, InflowManagement.RecessionErrors.FirstTimeNotAfterCutoff
                    errorDetail = mDictionary.tInvalidRecessionTableStart.Translated
                Case InflowManagement.RecessionErrors.DistancesNotMonotonic
                    errorDetail = mDictionary.tInvalidRecessionValuesNotMonotonic.Translated
                Case InflowManagement.RecessionErrors.LastDistanceNotLength
                    errorDetail = mDictionary.tInvalidRecessionTableEnd.Translated
                Case InflowManagement.RecessionErrors.TimeNotPositive, InflowManagement.RecessionErrors.TimeNotAfterAdvanceTime
                    errorDetail = mDictionary.tInvalidRecessionTableTimes.Translated
            End Select

            AddSetupError(errorFlag, errorID, errorDetail)
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub CheckFlowDepthErrors() - Check & add to SetupError list any basic Flow Depth errors
    '
    ' Output(s):    SetupError      - adds single error, if found, to list
    '
    ' This method only checks for basic flow depth table errors:
    '   1) - table exists and is setup correctly with Time & Depth columns
    '   2) - Times are positive (0 < T)
    '   3) - Times increase monotonically
    '   4) - Depths are positive (0 <= Qro)
    '
    ' FlowDepth values in relation to other user input data are checked elsewhere; see:
    '   CheckFlowDepthAdvanceErrors()
    '   CheckFlowDepthRecessionErrors()
    '*********************************************************************************************************
    Public Overridable Sub CheckFlowDepthErrors()

        ' Validate Flow Depth data if it has been measured
        If (mInflowManagement.FlowDepthsMeasured.Value) Then ' Flow Depths have been measured

            ' Start with the most general runoff error
            Dim errorFlag As ErrorFlags = ErrorFlags.FlowDepths
            Dim errorID As String = mDictionary.tInvalidFlowDepthTablesID.Translated
            Dim errorDetail As String = mDictionary.tInvalidFlowDepthTablesDetail.Translated

            ' InflowManagement method checks errors; this method adds them to the SetupError list
            Dim stationIdx As Integer
            Dim flowDepthError As InflowManagement.StationErrors = mInflowManagement.ValidateTabulatedFlowDepths(stationIdx)

            If Not (flowDepthError = InflowManagement.StationErrors.NoError) Then ' error found

                Select Case (flowDepthError) ' get specific error's detail
                    Case InflowManagement.StationErrors.InvalidTable
                        errorFlag = ErrorFlags.MeasurementStations
                        ' general errorID/Detail are used; see above
                    Case InflowManagement.StationErrors.TimeIsNegative
                        errorDetail = mDictionary.tInvalidFlowDepthTime.Translated
                    Case InflowManagement.StationErrors.TimesNotMonotonic
                        errorDetail = mDictionary.tInvalidFlowDepthTimesNotMonotonic.Translated
                    Case InflowManagement.StationErrors.DepthIsNegative
                        errorDetail = mDictionary.tInvalidFlowDepthDepth.Translated
                End Select

                Dim stationsTable As DataTable = mInflowManagement.MeasurementStations.Value
                If ((0 <= stationIdx) And (stationIdx < stationsTable.Rows.Count)) Then
                    Dim staRow As DataRow = stationsTable.Rows(stationIdx)
                    Dim staDist As Double = staRow.Item(nDistanceX) ' Location of Measurement Station
                    errorDetail &= " for Station at " & LengthString(staDist)
                End If

                AddSetupError(errorFlag, errorID, errorDetail)

            End If ' Runoff error
        End If ' RunoffMeasured

    End Sub

    '*********************************************************************************************************
    ' Sub CheckRunoffAdvanceErrors()     - verify runoff & advance alignment as an Error
    ' Sub CheckRunoffRecessionErrors()   -    "      "   & recession   "      "  "   "
    '
    ' Input(s):     L               - Length of the field
    '
    ' Output(s):    SetupError      - error added to Setup Error list
    '*********************************************************************************************************
    Public Overridable Sub CheckRunoffAdvanceErrors(ByVal L As Double)

        ' Validate Runoff only if downstream end of field is open (free draining)
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then

            ' Start with the most general runoff error
            Dim errorFlag As ErrorFlags = ErrorFlags.Runoff
            Dim errorID As String = mDictionary.tInvalidRunoffAdvance.Translated
            Dim errorDetail As String = mDictionary.tInvalidRunoffTableDetail.Translated

            Dim runoffError As InflowManagement.RunoffErrors = mInflowManagement.ValidateRunoffAdvanceAlignment(L)

            If (Not runoffError = InflowManagement.RunoffErrors.NoError) Then ' an error was found
                Select Case (runoffError) ' get specific error's detail
                    Case InflowManagement.RunoffErrors.FirstRunoffNotZero
                        errorDetail = mDictionary.tInvalidRunoffStart.Translated
                    Case InflowManagement.RunoffErrors.FirstRunoffTimeNotAdv
                        errorDetail = mDictionary.tInvalidRunoffStartTime.Translated
                End Select

                AddSetupError(errorFlag, errorID, errorDetail)
            End If
        End If

    End Sub

    Public Overridable Sub CheckRunoffRecessionErrors(ByVal L As Double)

        ' Validate Runoff only if downstream end of field is open (free draining)
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then

            ' Start with the most general runoff error
            Dim errorFlag As ErrorFlags = ErrorFlags.Runoff
            Dim errorID As String = mDictionary.tInvalidRunoffRecession.Translated
            Dim errorDetail As String = mDictionary.tInvalidRunoffTableDetail.Translated

            Dim runoffError As InflowManagement.RunoffErrors = mInflowManagement.ValidateRunoffRecessionAlignment(L)
            If (Not runoffError = InflowManagement.RunoffErrors.NoError) Then

                Select Case (runoffError) ' get specific error's detail
                    Case InflowManagement.RunoffErrors.LastRunoffNotZero
                        errorDetail = mDictionary.tInvalidRunoffEnd.Translated
                    Case InflowManagement.RunoffErrors.LastRunoffTimeNotRec
                        errorDetail = mDictionary.tInvalidRunoffEndTime.Translated
                End Select

                AddSetupError(errorFlag, errorID, errorDetail)
            End If
        End If

    End Sub

    '*********************************************************************************************************
    ' Check Contour setup errors
    '*********************************************************************************************************
    Public Overridable Sub CheckContourCriteriaErrors()

    End Sub

    '*********************************************************************************************************
    ' Check setup errors related to selected Solution Model
    '*********************************************************************************************************
    Public Overridable Sub CheckSolutionModelErrors()

        Dim solutionModel As SolutionModels = mSrfrCriteria.SolutionModel.Value
        If (solutionModel = SolutionModels.KinematicWave) Then

            ' Start with the most general Kinematic Wave error
            Dim errorFlag As ErrorFlags = ErrorFlags.KinematicWave
            Dim errorID As String = mDictionary.tKinematicWaveUseInvalid.Translated
            Dim errorDetail As String = ""

            If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
                errorDetail = mDictionary.tKinematicWaveBlockedEnd.Translated
                AddSetupError(errorFlag, errorID, errorDetail)
            End If

            Dim S0min As Double = mSystemGeometry.MinimumSlope
            If (S0min <= 0.0) Then
                errorDetail = mDictionary.tKinematicWaveZeroSlope.Translated
                AddSetupError(errorFlag, errorID, errorDetail)
            End If
        End If
    End Sub

#End Region

#Region " Execution Errors "

    Public Sub AddExecutionError(ByVal _code As Integer, ByVal _id As String, ByVal _detail As String)

        ' First, check if this error is already in the list
        Dim _errorItem As ErrorWarningItem
        _id = _id.Trim
        _detail = _detail.Trim

        For Each _errorItem In ExecutionErrorItems
            If ((_code = _errorItem.Code) _
            And (_id = _errorItem.ID) _
            And (_detail = _errorItem.Detail)) Then
                ' Found it, increment its count
                _errorItem.IncCount()
                Return
            End If
        Next

        ' This is a new error, add it to the list
        _errorItem = New ErrorWarningItem(_code, _id, _detail)
        mExecutionErrorItems.Add(_errorItem)
        mSetupErrors = mSetupErrors Or _code

    End Sub

    Public Function HasExecutionErrors() As Boolean
        Dim _hasErrors As Boolean = (0 < ExecutionErrorItems.Count)
        Return _hasErrors
    End Function

    Public Sub ClearExecutionErrors()
        If (mExecutionErrorItems IsNot Nothing) Then
            mExecutionErrorItems.Clear()
            mExecutionErrorItems = Nothing
        End If

        mExecutionErrorItems = New ArrayList
    End Sub

#End Region

#Region " Setup Warnings "

    Public Sub AddSetupWarning(ByVal _code As Integer, ByVal _id As String, ByVal _detail As String)

        ' First, check if this warning is already in the list
        Dim _warningItem As ErrorWarningItem
        _id = _id.Trim
        _detail = _detail.Trim

        For Each _warningItem In SetupWarningItems
            If ((_code = _warningItem.Code) _
            And (_id = _warningItem.ID) _
            And (_detail = _warningItem.Detail)) Then
                ' Found it, increment its count
                _warningItem.IncCount()
                Return
            End If
        Next

        ' This is a new warning, add it to the list
        _warningItem = New ErrorWarningItem(_code, _id, _detail)
        mSetupWarningItems.Add(_warningItem)
        mSetupWarnings = mSetupWarnings Or _code

    End Sub

    Public Sub RemoveSetupWarning(ByVal _code As Integer, ByVal _id As String, ByVal _detail As String)

        ' Check if this warning is in the list
        Dim _warningItem As ErrorWarningItem
        _id = _id.Trim
        _detail = _detail.Trim

        For Each _warningItem In SetupWarningItems
            If ((_code = _warningItem.Code) _
            And (_id = _warningItem.ID) _
            And (_detail = _warningItem.Detail)) Then
                ' Found it, remove it
                SetupWarningItems.Remove(_warningItem)
                Return
            End If
        Next

    End Sub

    Public Function HasSetupWarning(ByVal _code As Integer) As Boolean
        ' Check if this warning is in the list
        Dim _warningItem As ErrorWarningItem

        For Each _warningItem In SetupWarningItems
            If (_code = _warningItem.Code) Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function HasSetupWarnings() As Boolean
        Dim _hasWarnings As Boolean = (0 < SetupWarningItems.Count)
        Return _hasWarnings
    End Function

    Public Overridable Function CheckSetupWarnings() As Boolean
        ClearSetupWarnings() ' Clear all warning indicators
        Dim _hasWarnings As Boolean = Me.HasSetupWarnings ' Check for current setup warnings
        Return _hasWarnings
    End Function

    Public Sub ClearSetupWarnings()
        mSetupWarnings = 0
        If (mSetupWarningItems IsNot Nothing) Then
            mSetupWarningItems.Clear()
            mSetupWarningItems = Nothing
        End If

        mSetupWarningItems = New ArrayList
    End Sub

    '*********************************************************************************************************
    ' Sub CheckRunoffAdvanceWarnings()   - verify runoff & advance alignment as a Warning
    ' Sub CheckRunoffRecessionWarnings() -    "      "   & recession   "      " "    "
    '
    ' Input(s):     L               - Length of the field
    '
    ' Output(s):    SetupWarning    - warning added to Setup Warning list
    '*********************************************************************************************************
    Public Overridable Sub CheckRunoffAdvanceWarnings(ByVal L As Double)

        ' Validate Runoff only if downstream end of field is open (free draining)
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then

            ' Start with the most general runoff error
            Dim errorFlag As ErrorFlags = ErrorFlags.Runoff
            Dim errorID As String = mDictionary.tInvalidRunoffTableID.Translated
            Dim errorDetail As String = mDictionary.tInvalidRunoffTableDetail.Translated

            Dim runoffError As InflowManagement.RunoffErrors = mInflowManagement.ValidateRunoffAdvanceAlignment(L)

            If (Not runoffError = InflowManagement.RunoffErrors.NoError) Then

                Select Case (runoffError) ' get specific error's detail
                    Case InflowManagement.RunoffErrors.FirstRunoffNotZero
                        errorDetail = mDictionary.tInvalidRunoffStart.Translated
                    Case InflowManagement.RunoffErrors.FirstRunoffTimeNotAdv
                        errorDetail = mDictionary.tInvalidRunoffStartTime.Translated
                End Select

                AddSetupWarning(errorFlag, errorID, errorDetail)
            End If
        End If

    End Sub

    Public Overridable Sub CheckRunoffRecessionWarnings(ByVal L As Double)

        ' Validate Runoff only if downstream end of field is open (free draining)
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then

            ' Start with the most general runoff error
            Dim errorFlag As ErrorFlags = ErrorFlags.Runoff
            Dim errorID As String = mDictionary.tInvalidRunoffTableID.Translated
            Dim errorDetail As String = mDictionary.tInvalidRunoffTableDetail.Translated

            Dim runoffError As InflowManagement.RunoffErrors = mInflowManagement.ValidateRunoffRecessionAlignment(L)
            If (Not runoffError = InflowManagement.RunoffErrors.NoError) Then

                Select Case (runoffError) ' get specific error's detail
                    Case InflowManagement.RunoffErrors.LastRunoffNotZero
                        errorDetail = mDictionary.tInvalidRunoffEnd.Translated
                    Case InflowManagement.RunoffErrors.LastRunoffTimeNotRec
                        errorDetail = mDictionary.tInvalidRunoffEndTime.Translated
                End Select

                AddSetupWarning(errorFlag, errorID, errorDetail)
            End If
        End If

    End Sub

    '*********************************************************************************************************
    '*********************************************************************************************************
    Public Overridable Sub CheckAdvanceRecessionWarnings()
        Dim valid As Boolean = mInflowManagement.ValidateAdvanceRecessionAlignment
        If (valid) Then
            Dim advTable As DataTable = mInflowManagement.TabulatedAdvance.Value
            Dim advRows As Integer = advTable.Rows.Count
            valid = (5 <= advRows)

            If (Not valid) Then
                AddSetupWarning(ErrorFlags.Recession,
                                mDictionary.tInvalidAdvanceRecessionID.Translated,
                                mDictionary.tInvalidAdvanceRecessionDetail.Translated)
            End If
        Else
            AddSetupWarning(ErrorFlags.Recession,
                            mDictionary.tInvalidAdvanceRecessionMisalignedID.Translated,
                            mDictionary.tInvalidAdvanceRecessionMisalignedDetail.Translated)
        End If
    End Sub

#End Region

#Region " Execution Warnings "

    Public Sub AddExecutionWarning(ByVal _code As Integer, ByVal _id As String, ByVal _detail As String)

        ' First, check if warning is already in the list
        Dim _warningItem As ErrorWarningItem
        _id = _id.Trim
        _detail = _detail.Trim

        For Each _warningItem In ExecutionWarningItems
            If ((_code = _warningItem.Code) _
            And (_id = _warningItem.ID) _
            And (_detail = _warningItem.Detail)) Then
                ' Found it, increment its count
                _warningItem.IncCount()
                Return
            End If
        Next

        ' This is a new warning, add it to the list
        _warningItem = New ErrorWarningItem(_code, _id, _detail)
        mExecutionWarningItems.Add(_warningItem)
        mSetupWarnings = mSetupWarnings Or _code

    End Sub

    Public Function HasExecutionWarning(ByVal _code As Integer) As Boolean

        ' Check if warning is in the list
        For Each _warningItem As ErrorWarningItem In ExecutionWarningItems
            If (_code = _warningItem.Code) Then ' Found it
                Return True
            End If
        Next

        Return False
    End Function

    Public Function HasExecutionWarnings() As Boolean
        Dim _hasWarnings As Boolean = (0 < ExecutionWarningItems.Count)
        Return _hasWarnings
    End Function

    Public Sub ClearExecutionWarnings()
        If (mExecutionWarningItems IsNot Nothing) Then
            mExecutionWarningItems.Clear()
            mExecutionWarningItems = Nothing
        End If

        mExecutionWarningItems = New ArrayList
    End Sub

#End Region

#Region " Support Functions "
    '
    ' Display all Errors
    '
    Public Sub DisplayErrors()
        If (HasSetupErrors() Or HasExecutionErrors()) Then
            Dim _textViewer As TextViewer = New TextViewer
            _textViewer.Text = mDictionary.tErrors.Translated
            _textViewer.ErrorRichTextBox.Clear()
            _textViewer.ErrorRichTextBox.DisplayErrors(Me, True)
            _textViewer.ShowDialog()
        End If
    End Sub
    '
    ' Display all Warnings
    '
    Public Sub DisplayWarnings()
        If (HasSetupWarnings() Or HasExecutionWarnings()) Then
            Dim _textViewer As TextViewer = New TextViewer
            _textViewer.Text = mDictionary.tWarnings.Translated
            _textViewer.ErrorRichTextBox.Clear()
            _textViewer.ErrorRichTextBox.DisplayWarnings(Me, True)
            _textViewer.ShowDialog()
        End If
    End Sub
    '
    ' Display all Errors & Warnings
    '
    Public Sub DisplayErrorsAndWarnings()
        If (HasExecutionErrors() Or HasSetupWarnings() Or HasExecutionWarnings()) Then
            Dim _textViewer As TextViewer = New TextViewer
            _textViewer.Text = mDictionary.tErrors.Translated & " & " & mDictionary.tWarnings.Translated
            _textViewer.ErrorRichTextBox.Clear()
            _textViewer.ErrorRichTextBox.DisplayErrorsAndWarnings(Me, True)
            _textViewer.ShowDialog()
        End If
    End Sub
    '
    ' Check for setup Errors and/or Warnings
    '
    Public Function CheckSetupErrorsAndWarnings() As Boolean
        Dim _errors As Boolean = CheckSetupErrors()             ' Baseclass method clears setup error
        Dim _warnings As Boolean = CheckSetupWarnings()         '     "        "      "     "   warnings
        Return _errors Or _warnings
    End Function

    Public Function HasSetupErrorsOrWarnings() As Boolean
        Dim _hasErrors As Boolean = HasSetupErrors()
        Dim _hasWarnings As Boolean = HasSetupWarnings()
        Return _hasErrors Or _hasWarnings
    End Function
    '
    ' Check for execution Errors and/or Warnings
    '
    Public Function HasExecutionErrorsOrWarnings() As Boolean
        Dim _hasExecutionErrors As Boolean = HasExecutionErrors()
        Dim _hasExecutionWarnings As Boolean = HasExecutionWarnings()
        Return _hasExecutionErrors Or _hasExecutionWarnings
    End Function
    '
    ' Display specific error messages
    '
    Public Sub DisplayTuningPointBadMessage(Optional ByVal errmsg As String = "")

        Dim title As String = mDictionary.tTuningError.Translated
        Dim msg As String = mDictionary.tTuningFactorsCalculationFailed.Translated

        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tError.Translated & ": " & errmsg
        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tSelectMoreAppropriateTuningPoint.Translated
        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tAdditionalErrorMessagesMayFollow.Translated

        MsgBox(msg, MsgBoxStyle.Exclamation, title)

    End Sub

    Public Sub DisplayTuningPointBadAdvanceMessage()

        Dim title As String = mDictionary.tTuningError.Translated
        Dim msg As String = mDictionary.tTuningFactorsCalculationFailed.Translated

        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tAdvanceRecessionInadequateID.Translated
        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tSelectMoreAppropriateTuningPoint.Translated
        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tTryOneOrMore.Translated & ":"
        msg &= Chr(13)
        msg &= Chr(13) & "1) " & mDictionary.tIncreaseInflowRate.Translated
        msg &= Chr(13) & "2) " & mDictionary.tIncreaseCutoffTime.Translated

        MsgBox(msg, MsgBoxStyle.Exclamation, title)

    End Sub

    Public Sub DisplayTuningPointBadAppliedDepthMessage()

        Dim title As String = mDictionary.tTuningError.Translated
        Dim msg As String = mDictionary.tDappLessThanDreq.Translated

        msg &= Chr(13)
        msg &= Chr(13) & mDictionary.tSelectPointWithlargerAppliedDepth.Translated

        MsgBox(msg, MsgBoxStyle.Exclamation, title)

    End Sub

#End Region

#End Region

#End Region

#Region " Events "

    Enum Reasons
        HydrusStatus

    End Enum

    Public Event AnalysisEvent(ByVal Reason As Reasons, ByVal Msg As String)

    Public Overridable Sub UpdateAnalysisStatus(ByVal Reason As Reasons, ByVal Msg As String)
        Try ' ignore events caused by AnalysisEvent event handlers
            RaiseEvent AnalysisEvent(Reason, Msg)
        Catch ex As Exception
        End Try
    End Sub

#End Region

End Class
