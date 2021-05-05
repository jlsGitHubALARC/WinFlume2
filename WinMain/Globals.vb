
'*************************************************************************************************************
' Module: Globals
'
' Globals Contains:
'   1) Minimum, Maximum and Defaults for numeric parameters (in SI units)
'   2) Available Choices and Defaults for selection parameters
'*************************************************************************************************************
Imports Srfr
Imports Srfr.SoluteTransport
Imports Srfr.Infiltration
Imports DataStore

Public Module Globals

#Region " Drop Down Selection Qualification "
    '
    ' These bit values are used to flag when a Selection is NOT available
    '
    Public Enum SelFlags
        Basin = 1                   ' 0000 0000 0001
        Border = 2                  ' 0000 0000 0010
        BasinBorder = 3             ' 0000 0000 0011
        Furrow = 4                  ' 0000 0000 0100
        Srfr = 8                    ' 0000 0000 1000

        Standard = 16               ' 0000 0001 0000
        Advanced = 32               ' 0000 0010 0000
        StandardAdvanced = 48       ' 0000 0011 0000
        Research = 64               ' 0000 0100 0000

        EventAnalysis = 256         ' 0001 0000 0000
        PhysicalDesign = 512        ' 0010 0000 0000
        OperationsAnalysis = 1024   ' 0100 0000 0000
        Simulation = 2048           ' 1000 0000 0000
        DesignOperations = 1536     ' 0110 0000 0000
        AllButSimulation = 1792     ' 0111 0000 0000
        EventSimulation = 2304      ' 1001 0000 0000
        AllButEvent = 3584          ' 1110 0000 0000
        AllWorlds = 3840            ' 1111 0000 0000
    End Enum

    Public Structure Selection
        Private mNative As String
        Private mTranslated As String
        Public ReadOnly Property Value() As String
            Get
                mTranslated = Dictionary.Instance.Translate(mNative)
                Return mTranslated
            End Get
        End Property
        Public Flags As SelFlags
        Public Sub New(ByVal _value As String, ByVal _flags As SelFlags)
            mNative = _value
            Me.Flags = _flags
        End Sub
    End Structure

#End Region

#Region " Constants "
    '
    ' Resolve reference conflicts between DataStore & Srfr
    '
    Const MetersPerMillimeter As Double = Srfr.Globals.MetersPerMillimeter

    Const SecondsPerMinute As Double = Srfr.Globals.SecondsPerMinute
    Const SecondsPerHour As Double = Srfr.Globals.SecondsPerHour

    Const TenMinutes As Double = Srfr.Globals.TenMinutes
    Const TwentyMinutes As Double = Srfr.Globals.TwentyMinutes

    Const HalfHour As Double = Srfr.Globals.HalfHour
    Const OneHour As Double = Srfr.Globals.OneHour

    Const LiterPerSecond As Double = Srfr.Globals.LiterPerSecond
    '
    ' Physical constants
    '
    Public Const G As Double = 9.80665                              ' (m/s²) Gravitational Acceleration
    Public Const Pi As Double = 3.14159265359
    '
    ' Others
    '
    'Public Const Beta As Double = 0.45

#End Region

#Region " Application Globals "
    '
    ' Program Identification
    '
    Public Const WinSrfrName As String = "WinSRFR"

    Public Const DepartmentName As String = "U.S. Department of Agriculture"
    Public Const DepartmentAbbr As String = "USDA"

    Public Const ServiceName As String = "Agricultural Research Service"
    Public Const ServiceAbbr As String = "ARS"

    Public Const CenterName As String = "Arid-Land Agricultural Research Center"
    Public Const CenterAbbr As String = "ALARC"
    Public Const CenterAddress As String = "21881 North Cardon Lane"
    Public Const CenterCity As String = "Maricopa"
    Public Const CenterState As String = "AZ"
    Public Const CenterZipCode As String = "85238"
    Public Const CenterPhone As String = "(520) 316-6300"
    Public Const CenterFaxAdmin As String = "(520) 316-6329"
    Public Const CenterFaxResearch As String = "(520) 316-6330"
    '
    ' URLs
    '
    Public Const URL_USDA As String = "https://www.usda.gov"
    Public Const URL_ARS As String = "https://www.ars.usda.gov"
    Public Const URL_ALARC As String = "https://www.ars.usda.gov/pacific-west-area/maricopa-arizona/us-arid-land-agricultural-research-center/"
    '
    ' Nomenclature Options
    '
    Public Const sProjectNomenclature As String = "ProjectNomenclature"
    Public Enum ProjectNomenclatures
        LowLimit = -1
        ProjectCase
        FarmField
        HighLimit
    End Enum

    Public Const DefaultProjectNomenclature As ProjectNomenclatures = ProjectNomenclatures.FarmField
    '
    ' Window Sizes
    '
    Public Const sWindowSize As String = "WindowSize"
    Public Enum WindowSizes
        LowLimit = -1
        S800x600
        S900x675
        S949x768
        S1024x768
        HighLimit
    End Enum

    Public Const DefaultWindowSize As WindowSizes = WindowSizes.S1024x768
    '
    ' Application Functions
    '
    Public Enum ApplicationFunctions
        LowLimit = -1
        EventAnalysis
        OperationsAnalysis
        PhysicalDesign
        Simulation
        HighLimit
    End Enum
    '
    ' User Levels
    '
    Public Const sUserLevel As String = "UserLevel"
    Public Enum UserLevels
        LowLimit = -1
        Standard
        Advanced
        Research
        HighLimit
    End Enum

    Public Const DefaultUserLevel As UserLevels = UserLevels.Standard

    Private mUserLevelSelections() As String = {"Standard", "Advanced", "Research"}
    Public Function UserLevelText(ByVal UserLevel As UserLevels) As String
        UserLevelText = mUserLevelSelections(UserLevel)
        UserLevelText = Dictionary.Instance.Translate(UserLevelText)
    End Function
    '
    ' World Types
    '
    Public Enum WorldTypes
        LowLimit = -1
        EventWorld
        DesignWorld
        OperationsWorld
        SimulationWorld
        HighLimit
    End Enum

    Public Const DefaultWorldType As WorldTypes = WorldTypes.EventWorld

    Public Const sEvent As String = "Event"
    Public Const sDesign As String = "Design"
    Public Const sOperations As String = "Operations"
    Public Const sSimulation As String = "Simulation"

    Public Const sWorld As String = "World"
    Public Const sAnalysis As String = "Analysis"

    Public WorldsText() As String = {sEvent, sDesign, sOperations, sSimulation}

    Private mAnalysesText() As String = {sAnalysis, sAnalysis, sAnalysis, sSimulation}
    Public Function AnalysesText(ByVal WorldType As WorldTypes) As String
        AnalysesText = mAnalysesText(WorldType)
        AnalysesText = Dictionary.Instance.Translate(AnalysesText)
    End Function
    '
    ' Tab Properties
    '
    Public Enum TabGroups
        LowLimit = -1
        DataTabs
        AnalysisTabs
        HighLimit
    End Enum
    '
    ' Views Properties
    '
    Public Const DefaultOpenPreviousFile As Boolean = False
    Public Const DefaultShowSimulationAnimation As Boolean = False
    '
    ' Graph / Contour Properties
    '
    Public Const DefaultCalculatePrecisionContours As Boolean = False

    Public Const DefaultDisplayTitle As Boolean = True
    Public Const DefaultDisplaySubtitles As Boolean = True
    Public Const DefaultDisplayAxisLabels As Boolean = True

    Public Const DefaultDisplayMinorContours As Boolean = True
    Public Const DefaultDisplayContourKey As Boolean = True
    Public Const DefaultDisplayContourLabels As Boolean = True
    Public Const DefaultDisplayContourPoints As Boolean = True

    Public Const NumWddPoints As Integer = 101

    Public Enum ResultsViews
        LowLimit = -1
        PortraitPage
        'LandscapePage
        GraphsOnly
        HighLimit
    End Enum

    Public Const DefaultResultsView As ResultsViews = ResultsViews.GraphsOnly

    Public Enum FillColors
        LowLimit = -1
        NoFill
        ColorScale
        GrayScale
        UserDefined
        HighLimit
    End Enum

    Public Const DefaultFillColors As FillColors = FillColors.ColorScale
    '
    ' Dialogs Properties
    '
    Public Enum DefaultValueResponses
        LowLimit = -1
        UnconditionallyAccept
        RequireConfirmation
        HighLimit
    End Enum

    Public Const DefaultValueResponse As DefaultValueResponses = DefaultValueResponses.RequireConfirmation
    '
    ' Table Data
    '
    ' NOTE - To maintain backward file compatibility, column indeces must not change
    '

    ' Various DataTable names
    Public Const sElevationProfile As String = "Elevation Profile - H(X)"
    Public Const sDepthProfile As String = "Depth Profile - Y(X)"
    Public Const sInfiltrationDepth As String = "Infiltration - D(X)"
    Public Const sRequiredDepth As String = "Required Depth"
    Public Const sSedimentConcentrationC As String = "Sediment Concentration - C"
    Public Const sSedimentConcentrations As String = "Sediment Concentrations"
    Public Const sSedimentTransport As String = "Sediment Transport"
    Public Const sCharacteristicCurve As String = "Characteristic Curve"
    '
    ' Most data tables use Column 0 for Distance or Time
    '
    ' Hydrographs are Time vs. value where column 0 is Time
    ' Profiles are Distance vs. value where column 0 is Distance
    '
    Public Const nDistanceX As Integer = 0                  ' Column 0 is Distance
    Public Const sDistanceX As String = "Distance (m)"
    Public Const sDistX As String = "Dist. (m)"
    Public Const sAdvanceX As String = "Advance (m)"
    Public Const sLocationX As String = "Location"

    Public Const nTimeX As Integer = 0                      ' Column 0 is Time
    Public Const sTimeX As String = "Time (sec)"
    Public Const sStartTimeX As String = "Start Time (sec)"
    Public Const sEndTimeX As String = "End Time (sec)"

    ' Slope / Elevation Profiles (Column 0 is Distance)
    Public Const nSlopeX As Integer = 1                     ' Column 1 is Slope
    Public Const sSlopeX As String = "Slope (m/m)"

    Public Const nElevationX As Integer = 1                 ' Column 1 is Elevation
    Public Const sElevationX As String = "Elevation (m)"

    ' Infiltration Function Profile (Column 0 is Distance)
    Public Const nInfiltrationX As Integer = 1              ' Column 1 is Infiltration
    Public Const sInfiltrationX As String = "Infiltration (m)"
    Public Const sInfiltrationAZ As String = "Infiltration (m²)"

    ' Opportunity Time Profile (Column 0 is Distance)
    Public Const nTauX As Integer = 1                       ' Column 1 is Tau

    ' Infiltration Function Rate Table (Column 0 is Time)
    'Public Const nInfRateX As Integer = 1                   ' Column 1 is Infiltration Rate
    'Public Const sInfRateX As String = "Inf. Rate (m/s)"

    ' Fertigation Injection Rate Hydrograph (Column 0 is Time)
    Public Const sInjectionRateX As String = "Inj. Rate (cms)"
    Public Const nInjectionRateX As Integer = 1

    ' HYDRUS Infiltration Rate Table (Column 0 is Distance)
    Public Const sHydrusRateTable As String = "HYDRUS Rate Table"

    ' Advance / Recession Profile (Column 0 is Distance)
    Public Const nTimeX1 As Integer = 1                     ' Column 1 is Time

    ' Flow Depth Hydrograph (Column 0 is Time)
    Public Const nDepthX1 As Integer = 1                    ' Column 1 is Depth

    ' Inflow / Runoff Hydrographs (Column 0 is Time)
    Public Const nInflowX As Integer = 1                    ' Column 1 is Inflow Rate
    Public Const sInflowX As String = "Inflow (cms)"
    Public Const sQinX As String = "Qin (cms)"

    Public Const nRunoffX As Integer = 1                    ' Column 1 is Runoff Rate
    Public Const sRunoffX As String = "Runoff (cms)"

    ' Measurement Station Table
    Public Const sAdvanceT As String = "Advance (s)"
    Public Const sRecessiontT As String = "Recession (s)"
    Public Const sElevAdjustX As String = "Elev. Adjust. (m)"
    Public Const sDepthAdjustX As String = "Depth Adjust. (mm)"
    Public Const sUseForVB As String = "Use for VB"

    ' Soil Water Depletion Table
    Public Const nProfileDepthX As Integer = 0              ' Column 0 is Profile Soil Depth
    Public Const sProfileDepthX As String = "Profile Depth (m)"

    Public Const nCumulativeDepthX As Integer = 1           ' Column 1 is Cumulative Soil Depth
    Public Const sCumulativeDepthX As String = "Cum. Pr. Depth (m)"

    Public Const nTextureX As Integer = 2                   ' Column 2 is Soil Texture
    Public Const sTextureX As String = "Texture"

    Public Const nAwcX As Integer = 3                       ' Column 3 is Available Water Capacity (AWC)
    Public Const sAwcX As String = "AWC (mm/m)"

    Public Const nSwdX As Integer = 4                       ' Column 4 is Soil Water Depletion (SWD %)
    Public Const sSwdX As String = "SWD (%)"

    Public Const nProfileSwdX As Integer = 5                ' Column 5 is Profile SWD (mm)
    Public Const sProfileSwdX As String = "Profile SWD (mm)"

    Public Const nCumulativeSwdX As Integer = 6             ' Column 6 is Cumulative SWD (mm)
    Public Const sCumulativeSwdX As String = "Cum. Pr. SWD (mm)"

    ' Infiltrated Depth Table (Column 0 is Distance)
    Public Const nProbedDepthX As Integer = 1               ' Column 1 is Probe Penetration Depth
    Public Const sProbedDepthX As String = "Probed Depth (m)"

    Public Const nProfileIdX As Integer = 2                 ' Column 2 is Profile Infiltrated Depth
    Public Const sProfileIdX As String = "Profile ID (mm)"

    Public Const nRootZoneIdX As Integer = 3                ' Column 4 is Root Zone Infiltrated Depth
    Public Const sRootZoneIdX As String = "Root Zone ID (mm)"

    Public Const nUsefulIdX As Integer = 4                  ' Column 4 is Useful Infiltrated Depth
    Public Const sUsefulIdX As String = "Useful ID (mm)"

    Public Const nDeepPercIdX As Integer = 5                ' Column 5 is Deep Percolcation Infiltrated Depth
    Public Const sDeepPercIdX As String = "Deep Perc. (mm)"

    ' Profilometer Data Table
    Public Const nRodLocationX As Integer = 0               ' Column 0 is Rod Location
    Public Const sRodLocationX As String = "Rod Location (mm)"

    Public Const nRodDepthX As Integer = 1                  ' Column 1 is Rod Depth
    Public Const sRodDepthX As String = "Rod Depth (mm)"

    ' Depth / Width Table
    Public Const nDepthX As Integer = 0                     ' Column 0 is Depth
    Public Const sDepthX As String = "Depth (mm)"

    Public Const nWidthX As Integer = 1                     ' Column 1 is Width
    Public Const sWidthX As String = "Width (mm)"

    ' Sediment Components Table
    Public Const nPercentRetainedX As Integer = 0           ' Column 0 is % Retained
    Public Const sPercentRetainedX As String = "Retained (%)"

    Public Const nSieveSizeX As Integer = 1                 ' Column 1 is SieveSize
    Public Const sSieveSizeX As String = "Sieve Size (microns)"

    Public Const nSpecificGravityX As Integer = 2           ' Column 2 is SpecificGravity
    Public Const sSpecificGravityX As String = "Spec. Grav."

    Public Const nFallVelocityX As Integer = 3              ' Column 3 is Fall Velocity
    Public Const sFallVelocityX As String = "Fall Velocity (m/s)"

    ' Volume Balance Times / Surface Value Tables
    Public Const sVolumeBalance As String = "Volume Balance"

    Public Const sVin As String = "Vin (m³)"                ' Vin - applied  volume
    Public Const sVy As String = "Vy (m³)"                  ' Vy  - surface     "
    Public Const sVro As String = "Vro (m³)"                ' Vro - runoff      "
    Public Const sVz As String = "Vz (m³)"                  ' Vz  - infiltrated " (Vz = Vin - Vy - Vro)

    Public Const sVyMeas As String = "Meas. (m³)"           ' Vy Measured
    Public Const sVyPred As String = "Pred. (m³)"           ' Vy Predicted
    Public Const sY0 As String = "Y0 (mm)"                  ' Upstream flow depth (Y)
    Public Const sAY0 As String = "AY0 (m²)"                ' Upstream flow area (AY)

    Public Const sBeta As String = "Beta"
    Public Const sSigmaY As String = "Sigma Y"
    Public Const sSigmaZ As String = "Sigma Z"
    Public Const sStreamLength As String = "Stream Length"

    ' Characteristics
    Public Const sXXm As String = "XX (m)"                  ' Column 0 is XX
    Public Const sTXs As String = "TX (s)"                  ' Column 1 is TX
    Public Const sZwpXmm As String = "ZwpX (mm)"            ' Column 2 is ZwpX
    Public Const sAZXm2 As String = "AZX (m²)"              ' Column 2 may be AZX (for debugging)
    Public Const sYXmm As String = "YX (mm)"                '    "   "  "   " Y     "      "
    Public Const sQXcms As String = "QX (cms)"              '    "   "  "   " Q     "      "
    Public Const sCoXgpl As String = "CoX (g/l)"            '    "   "  "   " Co    "      "

    Public Const sConcentrationXgpl As String = "Concentration (g/l)"
    Public Const sMoistureX As String = "Moisture"
    Public Const sNewMoistureX As String = "New Moisture"

    ' Profile Time Table (Column 0 is Time)
    '   The Profile Time Table has no additional columns of data

    ' Hydrograph Location Table (Column 0 is Distance)
    '   The Hydrograph Location Table has no additional columns of data

    '
    ' Performance Data
    '
    Public Enum PerformanceParameters
        PAE = 1
        DU = 2
        AD = 3
        RO = 4
        DP = 5
        Dapp = 6
        Dlqmin = 7
        Txa = 8
        Tco = 9
        R = 10 ' XAco/L
    End Enum

    Public Const sHydraulicSummary As String = "Hydraulic Summary"
    Public Const sAdvance As String = "Advance"
    Public Const sRecession As String = "Recession"
    Public Const sOpportunityTime As String = "Opportunity Time"
    Public Const sAdvanceRecession As String = sAdvance + " & " + sRecession
    Public Const sInfiltration As String = "Infiltration"
    Public Const sInfiltrationOrdered As String = sInfiltration + " (Ordered)"
    Public Const sUpstreamInfiltration As String = "Upstream Infiltration"
    Public Const sInflow As String = "Inflow"
    Public Const sRunoff As String = "Runoff"
    Public Const sInflowRunoff As String = sInflow + " & " + sRunoff
    Public Const sErosionG As String = "Erosion G"
    Public Const sErosionCGm As String = "Erosion CGm"
    Public Const sErosionCGv As String = "Erosion CGv"
    Public Const sHydrograph As String = "Hydrograph"
    Public Const sProfile As String = "Profile"
    '
    ' Data Comparison Types
    '
    Public Enum DataComparisonTypes
        AdvanceGraph = 1
        AdvanceRecessionGraph = 2
        InfiltrationGraph = 4
        InfiltrationFunctionGraph = 8
        InflowGraph = 16
        InflowRunoffGraph = 32
        UpstreamInfiltrationGraph = 64
        PerformanceIndicators = 128
        AllDataComparisonTypes = 255 ' No GoodnessOfFit or Erosion
        GoodnessOfFit = 256
        VolumeBalance = 512
        VsAdvance = 1024
        ErosionGGraph = 2048
        ErosionCGmGraph = 4096
        ErosionCGvGraph = 8192
        LastDataComparisonType = 8192
    End Enum
    '
    ' 10-color levels for contours work well for percentage and (0.0-1.0) decimal values:
    '
    ' Values below 50% [0-50%)
    '    0-10%  - Red
    '   10-20%  - 
    '   20-30%  - Orange
    '   30-40%  - 
    '   40-50%  - Yellow
    '
    ' Value above 50% [50-100%]
    '   50-60% - Blue
    '   60-70% - 
    '   70-80% - Blue Green
    '   80-90% - 
    '   90+%   - Green
    '
    Public ColorScaleLevels() As System.Drawing.Color = {Color.FromArgb(255, 80, 80),
                                                         Color.FromArgb(255, 120, 80),
                                                         Color.FromArgb(255, 160, 80),
                                                         Color.FromArgb(255, 200, 160),
                                                         Color.FromArgb(255, 255, 160),
                                                         Color.FromArgb(160, 185, 255),
                                                         Color.FromArgb(160, 222, 255),
                                                         Color.FromArgb(160, 255, 222),
                                                         Color.FromArgb(160, 255, 185),
                                                         Color.FromArgb(160, 255, 160)}
    '
    ' Gray-scale levels:
    '
    Public GrayScaleLevels() As System.Drawing.Color = {Color.FromArgb(80, 80, 80),
                                                        Color.FromArgb(100, 100, 100),
                                                        Color.FromArgb(120, 120, 120),
                                                        Color.FromArgb(140, 140, 140),
                                                        Color.FromArgb(160, 160, 160),
                                                        Color.FromArgb(180, 180, 180),
                                                        Color.FromArgb(200, 200, 200),
                                                        Color.FromArgb(220, 220, 220),
                                                        Color.FromArgb(240, 240, 240),
                                                        Color.FromArgb(255, 255, 255)}

#End Region

#Region " System Geometry Globals "
    '
    ' Cross Section
    '
    Public Enum CrossSections
        LowLimit = -1
        Basin
        Border
        Furrow
        HighLimit
    End Enum

    Public Const DefaultCrossSection As CrossSections = CrossSections.Furrow

    Public Const sCrossSection As String = "Cross Section"
    Public Const sBasin As String = "Basin"
    Public Const sBorder As String = "Border"
    Public Const sFurrow As String = "Furrow"

    Public CrossSectionSelections() As Selection =
        {New Selection(sBasin, 0),
         New Selection(sBorder, 0),
         New Selection(sFurrow, 0)}

    Public Const sCrossSectionArea As String = "Cross Section Area"
    Public Const sTabulatedCrossSection As String = "Tabulated Cross Section"
    '
    ' Upstream Conditions
    '
    Public Enum UpstreamConditions
        LowLimit = -1
        NoDrainback
        DrainbackAfterCutoff
        HighLimit
    End Enum

    Public Const DefaultUpstreamCondition As UpstreamConditions = UpstreamConditions.NoDrainback

    Public Const sUpstreamCondition As String = "Upstream Condition"
    Public Const sNoDrainback As String = "No Drainback"
    Public Const sDrainback As String = "Drainback"

    Public UpstreamConditionSelections() As Selection =
        {New Selection(sNoDrainback, 0),
         New Selection(sDrainback, SelFlags.BasinBorder)}
    '
    ' Downstream Conditions
    '
    Public Enum DownstreamConditions
        LowLimit = -1
        OpenEnd
        BlockedEnd
        HighLimit
    End Enum

    Public Const DefaultDownstreamCondition As DownstreamConditions = DownstreamConditions.OpenEnd

    Public Const sDownstreamCondition As String = "Downstream Condition"
    Public Const sOpenEnd As String = "Open End"
    Public Const sBlockedEnd As String = "Blocked End"

    Public DownstreamConditionSelections() As Selection =
        {New Selection(sOpenEnd, SelFlags.Basin),
         New Selection(sBlockedEnd, SelFlags.Border)}
    '
    ' Bottom Description
    '
    Public Enum BottomDescriptions
        LowLimit = -1
        Slope
        SlopeTable
        ElevationTable
        AvgFromSlopeTable
        AvgFromElevTable
        HighLimit
    End Enum

    Public Const DefaultBottomDescription As BottomDescriptions = BottomDescriptions.Slope

    Public Const sBottomDescription As String = "Bottom Description"
    Public Const sSlope As String = "Slope"
    Public Const sSlopeTable As String = "Slope Table"
    Public Const sElevationTable As String = "Elevation Table"
    Public Const sAverageSlopeTable As String = "Average from Slope Table"
    Public Const sAverageElevationTable As String = "Average from Elevation Table"

    Public BottomDescriptionSelections() As Selection =
        {New Selection(sSlope, 0),
         New Selection(sSlopeTable, SelFlags.PhysicalDesign Or SelFlags.OperationsAnalysis),
         New Selection(sElevationTable, SelFlags.PhysicalDesign Or SelFlags.OperationsAnalysis),
         New Selection(sAverageSlopeTable, SelFlags.Basin),
         New Selection(sAverageElevationTable, SelFlags.Basin)}

    Public Const DefaultSlopeVariation As VaryByLocTime.Variations = VaryByLocTime.Variations.VaryWithDistance

    Public Const DefaultElevationVariation As VaryByLocTime.Variations = VaryByLocTime.Variations.VaryWithDistance

    Public Const DefaultEnableTabulatedBorderDepth As Boolean = False
    '
    ' Furrow Shape
    '
    Public Enum FurrowShapes
        LowLimit = -1
        Trapezoid
        PowerLaw
        TrapezoidTable
        PowerLawTable
        AverageTrapezoidFromTable
        AveragePowerLawFromTable
        TrapezoidFromFieldData
        PowerLawFromFieldData
        HighLimit
    End Enum

    Public Const DefaultFurrowShape As FurrowShapes = FurrowShapes.Trapezoid

    Public Const sFurrowShape As String = "Furrow Shape"
    Public Const sTrapezoid As String = "Trapezoid"
    Public Const sPowerLaw As String = "Power Law"
    Public Const sTrapezoidTable As String = "Trapezoid Table"
    Public Const sPowerLawTable As String = "Power Law Table"
    Public Const sAverageTrapezoidTable As String = "Average from Trapezoid Table"
    Public Const sAveragePowerLawTable As String = "Average from Power Law Table"
    Public Const sTrapezoidFieldData As String = "Trapezoid from Field Data"
    Public Const sPowerLawFieldData As String = "Power Law from Field Data"

    Public FurrowShapeSelections() As Selection =
        {New Selection(sTrapezoid, 0),
         New Selection(sPowerLaw, 0),
         New Selection(sTrapezoidTable, SelFlags.Standard Or SelFlags.AllWorlds),
         New Selection(sPowerLawTable, SelFlags.Standard Or SelFlags.AllWorlds),
         New Selection(sAverageTrapezoidTable, SelFlags.Standard Or SelFlags.AllWorlds),
         New Selection(sAveragePowerLawTable, SelFlags.Standard Or SelFlags.AllWorlds),
         New Selection(sTrapezoidFieldData, 0),
         New Selection(sPowerLawFieldData, 0)}

    Public Const DefaultEnableTabulatedFurrowShape As Boolean = False

    Public Enum FurrowFieldDataTypes
        LowLimit = -1
        WidthTable
        DepthWidthTable
        ProfilometerTable
        HighLimit
    End Enum

    Public Const DefaultFurrowFieldDataType As FurrowFieldDataTypes = FurrowFieldDataTypes.WidthTable

    Public Const sFurrowFieldDataType As String = "Furrow Field Data Type"
    Public Const sWidthTable As String = "Width Table"
    Public Const sDepthWidthTable As String = "Depth / Width Table"
    Public Const sProfilometerTable As String = "Profilometer Table"

    Public FurrowFieldDataTypeSelections() As Selection =
        {New Selection("Width Table", 0),
         New Selection("Depth / Width Table", 0),
         New Selection("Profilometer Table", 0)}
    '
    ' Field Geometry
    '
    Public Const MinimumLength As Double = 0.1
    Public Const DefaultLength As Double = 150.0 ' 150 m
    Public Const MaximumLength As Double = 10000.0

    Public Const MinimumWidth As Double = 0.1
    Public Const DefaultWidth As Double = 25.0 ' 25 m
    Public Const MaximumWidth As Double = 5000.0

    Public Const MinimumDepth As Double = 0.01
    Public Const DefaultDepth As Double = 0.3 ' 300 mm
    Public Const MaximumDepth As Double = 10.0

    Public Const MinimunAdverseSlope As Double = -0.001

    Public Const MinimumBasinBorderSlope As Double = 0.0
    Public Const MaximumLevelSlope As Double = 0.0001
    Public Const DefaultBasinBorderSlope As Double = 0.005 ' m/m
    Public Const MaximumBasinBorderSlope As Double = 0.1

    Public Const MinimumFurrowSlope As Double = 0.0
    Public Const DefaultFurrowSlope As Double = 0.005 ' m/m
    Public Const MaximumFurrowSlope As Double = 0.1

    Public Const MinimumElevation As Double = 0.0

    Public Const MinimumFurrowSpacing As Double = 0.0
    Public Const DefaultFurrowSpacing As Double = 1.0 ' 1 m
    Public Const MaximumFurrowSpacing As Double = 10.0

    Public Const MinimumSurfaceShapeFactor As Double = 0.5
    Public Const DefaultSurfaceShapeFactor1 As Double = 0.76
    Public Const DefaultSurfaceShapeFactor2 As Double = 0.76
    Public Const MaximumSurfaceSahpeFactor As Double = 1.0

    ' Trapezoid Furrow
    Public Const MinimumBottomWidth As Double = 0.0
    Public Const DefaultBottomWidth As Double = 0.2 ' 200 mm
    Public Const MaximumBottomWidth As Double = 1.0

    Public Const MinimumMaximumDepth As Double = 0.0
    Public Const DefaultMaximumDepth As Double = 0.3 ' 300 mm
    Public Const MaximumMaximumDepth As Double = 1.0

    Public Const MinimumSideSlope As Double = 0.1
    Public Const DefaultSideSlope As Double = 1.0 ' 1 m/m
    Public Const MaximumSideSlope As Double = 1.0

    ' Power Law Furrow
    Public Const MinimumWidthAt100mm As Double = 0.0
    Public Const DefaultWidthAt100mm As Double = 0.3 ' 300 mm
    Public Const MaximumWidthAt100mm As Double = 10.0

    Public Const MinimumPowerLawExponent As Double = 0.0
    Public Const DefaultPowerLawExponent As Double = 0.5
    Public Const MaximumPowerLawExponent As Double = 1.0

    ' Cross-Section Furrow
    Public Const MinimumTopSectionWidth As Double = 0.0
    Public Const DefaultTopSectionWidth As Double = 0.8 ' 800 mm
    Public Const MaximumTopSectionWidth As Double = 9.9

    Public Const MinimumMiddleSectionWidth As Double = 0.0
    Public Const DefaultMiddleSectionWidth As Double = 0.5 ' 500 mm
    Public Const MaximumMiddleSectionWidth As Double = 9.9

    Public Const MinimumBottomSectionWidth As Double = 0.0
    Public Const DefaultBottomSectionWidth As Double = 0.2 ' 200 mm
    Public Const MaximumBottomSectionWidth As Double = 9.9

    Public Const MinimumSectionDepth As Double = 0.0
    Public Const DefaultSectionDepth As Double = 0.3 ' 300 mm
    Public Const MaximumSectionDepth As Double = 1.0

    ' Profilometer Furrow
    Public Const MinimumNoOfRods As Integer = 4
    Public Const DefaultNoOfRods As Integer = 9
    Public Const MaximumNoOfRods As Integer = 100

    Public Const MinimumRodSpacing As Double = 0.01 ' 10 mm
    Public Const DefaultRodSpacing As Double = 0.1  ' 100 mm
    Public Const MaximumRodSpacing As Double = 1.0  ' 1000 mm (1 m)

    ' Depth / Width Table Furrow
    Public Const MinimumNoOfWidths As Integer = 3
    Public Const DefaultNoOfWidths As Integer = 3
    Public Const MaximumNoOfWidths As Integer = 10

#End Region

#Region " Soil Properties Globals "

    Public Const DefaultProbeLength As Double = 1.5

    Public Const DefaultRootZoneDepth As Double = 1.0

    Public Const DefaultLeachingFraction As Double = 0.1

    ' Soil Textures
    Public Const stC As String = "C"        ' Clay
    Public Const stCL As String = "CL"      ' Clay-Loam

    Public Const stL As String = "L"        ' Loam
    Public Const stLS As String = "LS"      ' Loamy Sand

    Public Const stS As String = "S"        ' Sand
    Public Const stSC As String = "SC"      ' Sandy Clay
    Public Const stSL As String = "SL"      ' Sandy Loam
    Public Const stSCL As String = "SCL"    ' Sandy Clay-Loam

    Public Const stSi As String = "Si"      ' Silt
    Public Const stSiC As String = "SiC"    ' Silty Clay
    Public Const stSiL As String = "SiL"    ' Silty Loam
    Public Const stSiCL As String = "SiCL"  ' Silty Clay-Loam

    Public SoilTextures() As String = {stC, stCL, stL, stLS, stS, stSC, stSL, stSCL, stSi, stSiC, stSiL, stSiCL}

#End Region

#Region " Infiltration Globals "
    '
    ' Infiltration Functions
    '
    Public Enum InfiltrationFunctions
        LowLimit = -1
        CharacteristicInfiltrationTime
        NRCSIntakeFamily
        TimeRatedIntakeFamily
        KostiakovFormula
        ModifiedKostiakovFormula
        BranchFunction
        GreenAmpt
        Hydrus1D
        WarrickGreenAmpt
        HighLimit
    End Enum

    Public Const DefaultInfiltrationFunction As InfiltrationFunctions = InfiltrationFunctions.KostiakovFormula

    Public Const sInfiltrationFunction As String = "Infiltration Function"
    Public Const sInfiltrationDepthFunction As String = "Infiltration Depth Function"
    Public Const sCharacteristicInfiltrationTime As String = "Characteristic Infiltration Time"
    Public Const sNrcsIntakeFamily As String = "NRCS Intake Family"
    Public Const sTimeRatedIntakeFamily As String = "Time Rated Intake Family"
    Public Const sKostiakovFormula As String = "Kostiakov Formula"
    Public Const sModifiedKostiakovFormula As String = "Modified Kostiakov Formula"
    Public Const sBranchFunction As String = "Branch Function"
    Public Const sHydrus1D As String = "Richards (HYDRUS-1D)"
    Public Const sGreenAmpt As String = "Green-Ampt"
    Public Const sWarrickGreenAmpt As String = "Warrick / Green-Ampt"

    Public Function InfiltrationFunctionEnum(ByVal InfiltrationFunctionText As String) As InfiltrationFunctions
        InfiltrationFunctionEnum = InfiltrationFunctions.LowLimit

        Select Case (InfiltrationFunctionText)
            Case sCharacteristicInfiltrationTime
                InfiltrationFunctionEnum = InfiltrationFunctions.CharacteristicInfiltrationTime
            Case sNrcsIntakeFamily
                InfiltrationFunctionEnum = InfiltrationFunctions.NRCSIntakeFamily
            Case sTimeRatedIntakeFamily
                InfiltrationFunctionEnum = InfiltrationFunctions.TimeRatedIntakeFamily
            Case sKostiakovFormula
                InfiltrationFunctionEnum = InfiltrationFunctions.KostiakovFormula
            Case sModifiedKostiakovFormula
                InfiltrationFunctionEnum = InfiltrationFunctions.ModifiedKostiakovFormula
            Case sBranchFunction
                InfiltrationFunctionEnum = InfiltrationFunctions.BranchFunction
            Case sHydrus1D
                InfiltrationFunctionEnum = InfiltrationFunctions.Hydrus1D
            Case sGreenAmpt
                InfiltrationFunctionEnum = InfiltrationFunctions.GreenAmpt
            Case sWarrickGreenAmpt
                InfiltrationFunctionEnum = InfiltrationFunctions.WarrickGreenAmpt
        End Select
    End Function

    '*********************************************************************************************************
    ' Table providing the Infiltration Function name as well as constraining the Infiltration Function usage
    ' by User Level & Cross Section.
    '                                          User Level               Cross Section
    '                                 ----------------------------    -----------------
    '                                 Standard  Advanced  Research    Furrow     Border
    '   Infiltration Function
    '   --------------------------
    '   Characteristic Time              X         X         X           X         X
    '   NRCS Intake Family               X         X         X           X         X
    '   Time-Rated Intake Family         X         X         X           X         X
    '   Kostiakov Formula                X         X         X           X         X
    '   Modified Kostiakov Formula       X         X         X           X         X
    '   Branch Function                  X         X         X           X         X
    '   Green-Ampt                       -         X         X           -         X
    '   HYDRUS-1D                        -         X         X           -         X
    '   Warrick / Green-Ampt             -         X         X           X         -
    '
    ' Note - flags are set when Infiltration Function CANNOT be used
    '
    Public InfiltrationFunctionSelections() As Selection =
        {New Selection(sCharacteristicInfiltrationTime, 0),
         New Selection(sNrcsIntakeFamily, 0),
         New Selection(sTimeRatedIntakeFamily, 0),
         New Selection(sKostiakovFormula, 0),
         New Selection(sModifiedKostiakovFormula, 0),
         New Selection(sBranchFunction, 0),
         New Selection(sGreenAmpt, SelFlags.Standard Or SelFlags.Furrow),
         New Selection(sHydrus1D, SelFlags.Standard Or SelFlags.Furrow),
         New Selection(sWarrickGreenAmpt, SelFlags.Standard Or SelFlags.BasinBorder)}

    Public Enum GA_EstimationOptions
        LowLimit = -1
        EstimateKs
        EstimateHf
        HighLimit
    End Enum

    Public Enum WGA_EstimationOptions
        LowLimit = -1
        EstimateKs
        EstimateHf
        HighLimit
    End Enum

    Public Const DefaultGA_EstimationOption As GA_EstimationOptions = GA_EstimationOptions.EstimateKs
    Public Const DefaultWGA_EstimationOption As WGA_EstimationOptions = WGA_EstimationOptions.EstimateKs

    Public GreenAmptEstimationSelections() As Selection =
        {New Selection("Estimate Ks", 0),
         New Selection("Estimate hf", 0)}

    Public WarrickGreenAmptEstimationSelections() As Selection =
        {New Selection("Estimate Ks", 0),
         New Selection("Estimate hf", 0)}

    Public Enum Surge2InfiltrationMethods
        LowLimit = -1
        BlairSmerdon
        IzunoPodmore
        HighLimit
    End Enum

    Public Const DefaultSurge2InfiltrationMethod As Surge2InfiltrationMethods = Surge2InfiltrationMethods.BlairSmerdon

    Public Surge2InfiltrationMethodSelections() As Selection =
        {New Selection("Blair-Smerdon", 0),
         New Selection("Izuno-Podmore", 0)}
    '
    ' Wetted Perimeter Methods
    '
    Public Enum WettedPerimeterMethods
        LowLimit = -1
        LocalWettedPerimeter
        UpstreamWettedPerimeter
        AtNormalInflowDepth
        FurrowSpacing
        NrcsEmpiricalFunction
        RepresentativeUpstreamWettedPerimeter
        HighLimit
    End Enum

    Public Const DefaultWettedPerimeterMethod As WettedPerimeterMethods = WettedPerimeterMethods.FurrowSpacing

    Public Const sWettedPerimeterMethod As String = "Wetted Perimeter Method"
    Public Const sLocalWettedPerimeter As String = "Local Wetted Perimeter"
    Public Const sUpstreamWettedPerimeter As String = "Upstream Wetted Perimeter"
    Public Const sUpstreamWpAtNormalDepth As String = "Upstream WP at Normal Depth"
    Public Const sFurrowSpacingNoWpEffect As String = "Furrow Spacing (No WP Effect)"
    Public Const sNrcsEmpiricalWettedPerimeter As String = "NRCS Empirical Wetted Perimeter"
    Public Const sRepresentativeUpstreamWP As String = "Representative Upstream WP"

    Public Function WettedPerimeterMethodEnum(ByVal WettedPerimeterMethodText As String) As WettedPerimeterMethods
        WettedPerimeterMethodEnum = WettedPerimeterMethods.LowLimit

        Select Case (WettedPerimeterMethodText)
            Case sLocalWettedPerimeter
                WettedPerimeterMethodEnum = WettedPerimeterMethods.LocalWettedPerimeter
            Case sFurrowSpacingNoWpEffect
                WettedPerimeterMethodEnum = WettedPerimeterMethods.FurrowSpacing
            Case sNrcsEmpiricalWettedPerimeter
                WettedPerimeterMethodEnum = WettedPerimeterMethods.NrcsEmpiricalFunction
            Case sUpstreamWettedPerimeter, sUpstreamWpAtNormalDepth, sRepresentativeUpstreamWP
                WettedPerimeterMethodEnum = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter
        End Select
    End Function

    '*********************************************************************************************************
    ' Table providing the Wetted Perimeter Method name as well as constraining the Wetted Perimeter usage
    ' by User Level & WinSRFR World.
    '                                         User Level                          WinSRFR World
    '                                ----------------------------    -----------------------------------------
    '                                Standard  Advanced  Research    Event     Design   Operations  Simulation
    '   Wetted Perimeter Method
    '   --------------------------
    '   Local Wetted Perimeter          -         X         X          X         -          -           X
    '   Upstream Wetted Perimeter       X         X         X          -         -          -           -
    '   Upstream WP at Normal Depth     X         X         X          -         -          -           -
    '   Furrow Spacing (No WP Effect)   X         X         X          X         X          X           X
    '   NRCS Wetted Perimeter           X         X         X          X         X          X           X
    '   Representative Upstream WP      X         X         X          X         X          X           X
    '
    ' Note - flags are set when Infiltration Function CANNOT be used
    '
    Public WettedPerimeterMethodSelections() As Selection =
        {New Selection(sLocalWettedPerimeter, SelFlags.Standard Or SelFlags.DesignOperations),
         New Selection(sUpstreamWettedPerimeter, SelFlags.AllWorlds),
         New Selection(sUpstreamWpAtNormalDepth, SelFlags.AllWorlds),
         New Selection(sFurrowSpacingNoWpEffect, 0),
         New Selection(sNrcsEmpiricalWettedPerimeter, 0),
         New Selection(sRepresentativeUpstreamWP, 0)}

    Public Const DefaultEnableTabulatedInfiltration As Boolean = False

    Public Function WettedPerimeterMethod(ByVal WettedPerimeterText As String) As WettedPerimeterMethods
        Select Case WettedPerimeterText
            Case sFurrowSpacingNoWpEffect
                WettedPerimeterMethod = WettedPerimeterMethods.FurrowSpacing
            Case sLocalWettedPerimeter
                WettedPerimeterMethod = WettedPerimeterMethods.LocalWettedPerimeter
            Case sNrcsEmpiricalWettedPerimeter
                WettedPerimeterMethod = WettedPerimeterMethods.NrcsEmpiricalFunction
            Case Else
                WettedPerimeterMethod = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter
        End Select
    End Function

    '*********************************************************************************************************
    ' Table constraining Infiltration Function selection by WinSRFR world.
    '
    ' This table is for use with Basins & Borders.
    '
    '                                               WinSRFR World
    '                                 --------------------------------------------
    '                                 Event      Design    Operations   Simulation
    '   Infiltration Function
    '   --------------------------
    '   Characteristic Time             X           X           X           X
    '   NRCS Intake Family              X           X           X           X
    '   Time-Rated Intake Family        X           X           X           X
    '   Kostiakov Formula               X           X           X           X
    '   Modified Kostiakov Formula      X           X           X           X
    '   Branch Function                 X           -           -           X
    '   Green-Ampt                      X           -           X           X
    '   HYDRUS-1D                       -           -           -           X
    '   Warrick / Green-Ampt            -           -           X           -
    '
    '   Note - this table is used for Basins & Borders for one purpose:
    '       1) to indicate which Infiltration Functions are valid for a specific WinSRFR World
    '
    Public InfiltrationFunctionConstraints()() As Boolean =
         {New Boolean() {True, True, True, True},
          New Boolean() {True, True, True, True},
          New Boolean() {True, True, True, True},
          New Boolean() {True, True, True, True},
          New Boolean() {True, True, True, True},
          New Boolean() {True, False, False, True},
          New Boolean() {True, False, True, True},
          New Boolean() {False, False, False, True},
          New Boolean() {False, False, True, False}}

    '*********************************************************************************************************
    ' Table constraining Infiltration Function / Wetted Perimeter Option selections by WinSRFR World.
    '
    ' This table is for use with Furrows only.
    '
    '                                                        Wetted Perimeter Option
    '                                 ----------------------------------------------------------------
    '                                 Local    2 Upstream Options    Furrow      NRCS        Rep.     
    '                                              Deprecated        Spacing   Empirical   Upstream
    '   Infiltration Function                      See Note 4
    '   --------------------------
    '   Characteristic Time             -           -      -           All         -           -    
    '   NRCS Intake Family              -           -      -            -         All          -          
    '   Time-Rated Intake Family        -           -      -            -          -           -    
    '   Kostiakov Formula               -           -      -           All         -         All    
    '   Modified Kostiakov Formula     ES           -      -           All         -         All    
    '   Branch Function                 -           -      -           ES          -          ES    
    '   Green-Ampt                      -           -      -            -          -           -    
    '   HYDRUS-1D                       -           -      -            -          -           -    
    '   Warrick / Green-Ampt           ES           -      -            -          -           -    
    '
    '   Valid World Key:    E - Event Analysis, D - Design, O - Operations, S - Simulation
    '
    '   Note 1 - this table is used for Furrows for two purposes:
    '       1) to indicate which Infiltration Methods are valid for a specific WinSRFR World
    '       2) to indicate which Wetted Perimeter Options are valid for a specific Infiltration Method
    '
    '   Note 2 - Green-Ampt & HYDRUS-1D are 1D (i.e. for Basins/Borders only) wetted perimeter does not apply
    '
    '   Note 3 - Warrick / Green-Ampt is 2D (i.e. wetted perimeter calculations are 'Local')
    '
    '   Note 4 - Upstream WP & Upstream WP at Normal Depth replaced by Representative Upstream WP (2007/11/28)
    '
    '   Note 5 - Time-Rated Intake Family is  no longer available for furrows (2017/04/21)
    '
    Public InfiltrationWettedPerimeterConstraints()() As SelFlags =
        {New SelFlags() {0, 0, 0, SelFlags.AllWorlds, 0, 0},
         New SelFlags() {0, 0, 0, 0, SelFlags.AllWorlds, 0},
         New SelFlags() {0, 0, 0, 0, 0, 0},
         New SelFlags() {0, 0, 0, SelFlags.AllWorlds, 0, SelFlags.AllWorlds},
         New SelFlags() {SelFlags.EventSimulation, 0, 0, SelFlags.AllWorlds, 0, SelFlags.AllWorlds},
         New SelFlags() {0, 0, 0, SelFlags.EventSimulation, 0, SelFlags.EventSimulation},
         New SelFlags() {0, 0, 0, 0, 0, 0},
         New SelFlags() {0, 0, 0, 0, 0, 0},
         New SelFlags() {SelFlags.EventSimulation, 0, 0, 0, 0, 0}}

    '*********************************************************************************************************
    ' Minimum / Maximum / Default values in SI units (meters / seconds)
    '
    Public Const DefaultEnableLimitingDepth As Boolean = False

    Public Const MinimumLimitingDepth As Double = 0.0
    Public Const DefaultLimitingDepth As Double = 1.0
    Public Const MaximumLimitingDepth As Double = 1000.0

    ' Infiltration
    Public Const DefaultInfiltrationDepth As Double = Depth100mm
    Public Const DefaultInfiltrationDepthUnits As Units = Units.Millimeters

    Public Const MinimumInfiltrationTime As Double = 0.0
    Public Const DefaultInfiltrationTime As Double = FourHours
    Public Const MaximumInfiltrationTime As Double = TenHours
    Public Const DefaultInfiltrationTimeUnits As Units = Units.Hours

    ' Kostiakov
    'Public Const MinimumKostiakovA As Double = Srfr.Amin - See Function MinimumKostiakovA() in WinSRFR.vb
    Public Const DefaultKostiakovA As Double = Srfr.Adef
    Public Const MaximumKostiakovA As Double = Srfr.Amax

    Public Const MinimumKostiakovB As Double = Srfr.Bmin
    Public Const DefaultKostiakovB As Double = Srfr.Bdef
    Public Const MaximumKostiakovB As Double = Srfr.Bmax
    Public Const DefaultKostiakovBUnits As Units = Units.MillimetersPerHour

    Public Const MinimumKostiakovC As Double = Srfr.Cmin
    Public Const DefaultKostiakovC As Double = Srfr.Cdef
    Public Const MaximumKostiakovC As Double = Srfr.Cmax
    Public Const DefaultKostiakovCUnits As Units = Units.Millimeters

    Public Const MinimumKostiakovK As Double = Srfr.Kmin
    Public Const DefaultKostiakovK As Double = Srfr.Kdef
    Public Const MaximumKostiakovK As Double = Srfr.Kmax
    Public Const DefaultKostiakovKUnits As KostiakovKParameter.K_Units = KostiakovKParameter.K_Units.MillimetersPerHour_A

    ' Branch Function
    Public Const MinimumBranchB As Double = Srfr.Bmin
    Public Const DefaultBranchB As Double = Srfr.BBdef
    Public Const MaximumBranchB As Double = Srfr.Bmax
    Public Const DefaultBranchBUnits As Units = Units.MillimetersPerHour

    ' Green-Ampt
    Public Const DefaultSoilTextureSelection As SoilTextures = Infiltration.SoilTextures.ClayLoam

    Public Const sSoilTextureSelection As String = "Soil Texture Selection"

    Public SoilTextureSelections() As Selection =
        {New Selection(sSand, 0),
         New Selection(sLoamySand, 0),
         New Selection(sSandyLoam, 0),
         New Selection(sLoam, 0),
         New Selection(sSiltLoam, 0),
         New Selection(sSandyClayLoam, 0),
         New Selection(sClayLoam, 0),
         New Selection(sSiltyClayLoam, 0),
         New Selection(sSandyClay, 0),
         New Selection(sSiltyClay, 0),
         New Selection(sClay, 0)}

    Public Const DefaultPorosityUnits As Units = Units.CentimetersPerCentimeter
    Public Const DefaultPressureHeadUnits As Units = Units.CentimetersPerHour
    Public Const DefaultHydraulicConductivityUnits As Units = Units.Millimeters

    ' HYDRUS
    Public Const DefaultHydrusInfiltrationFilename As String = "Use ""Select HYDRUS Project..."" to select a project"
    Public Const DefaultHydrusRowFilename As String = "Use row menu to browse for project"

    Public Enum SyncHydrusOptions
        LowLimit = -1
        SyncWithUserDistances
        SyncWithWinSrfrDistances
        HighLimit
    End Enum

    Public SyncHydrusSelections() As Selection =
        {New Selection("Sync with User Distances", 0),
         New Selection("Sync with WinSRFR Distances", 0)}

    Public Const DefaultSyncHydrusOption As SyncHydrusOptions = SyncHydrusOptions.SyncWithWinSrfrDistances
    '
    ' NRCS Intake Families
    '
    Public Enum NrcsIntakeFamilies
        LowLimit = -1
        Family005
        Family010
        Family015
        Family020
        Family025
        Family030
        Family035
        Family040
        Family045
        Family050
        Family060
        Family070
        Family080
        Family090
        Family100
        Family150
        Family200
        Family300
        Family400
        HighLimit
    End Enum

    Public Const DefaultNrcsIntakeFamily As NrcsIntakeFamilies = NrcsIntakeFamilies.Family050

    Public Const sNrcs005 As String = "0.05"
    Public Const sNrcs010 As String = "0.10"
    Public Const sNrcs015 As String = "0.15"
    Public Const sNrcs020 As String = "0.20"
    Public Const sNrcs025 As String = "0.25"
    Public Const sNrcs030 As String = "0.30"
    Public Const sNrcs035 As String = "0.35"
    Public Const sNrcs040 As String = "0.40"
    Public Const sNrcs045 As String = "0.45"
    Public Const sNrcs050 As String = "0.50"
    Public Const sNrcs060 As String = "0.60"
    Public Const sNrcs070 As String = "0.70"
    Public Const sNrcs080 As String = "0.80"
    Public Const sNrcs090 As String = "0.90"
    Public Const sNrcs100 As String = "1.00"
    Public Const sNrcs150 As String = "1.50"
    Public Const sNrcs200 As String = "2.00"
    Public Const sNrcs300 As String = "3.00"
    Public Const sNrcs400 As String = "4.00"

    Public NrcsSelections As String() = {sNrcs005, sNrcs010, sNrcs015, sNrcs020, sNrcs025,
                                         sNrcs030, sNrcs035, sNrcs040, sNrcs045, sNrcs050,
                                         sNrcs060, sNrcs070, sNrcs080, sNrcs090, sNrcs100,
                                         sNrcs150, sNrcs200, sNrcs300, sNrcs400}

    Public Const DefaultNrcsSelection As String = sNrcs050

    Public Class NrcsIntakeValues
        Public Family As NrcsIntakeFamilies
        Public Name As String
        Public k As Double
        Public a As Double

        Public Sub New(ByVal _family As NrcsIntakeFamilies, ByVal _name As String, ByVal _k As Double, ByVal _a As Double)
            Me.Family = _family
            Me.Name = _name
            Me.k = _k
            Me.a = _a
        End Sub

    End Class
    '
    ' BASIN & BORDER have different NRCS Intake Families than SRFR (Furrow values)
    '
    'Public NrcsBasinBorderIntakeValuesTable() As NrcsIntakeValues = _
    '    {New NrcsIntakeValues(NrcsIntakeFamilies.Family005, sNrcs005, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family010, sNrcs010, 0.00009638, 0.595), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family015, sNrcs015, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family020, sNrcs020, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family025, sNrcs025, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family030, sNrcs030, 0.00011027, 0.65), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family035, sNrcs035, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family040, sNrcs040, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family045, sNrcs045, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family050, sNrcs050, 0.00011784, 0.684), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family060, sNrcs060, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family070, sNrcs070, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family080, sNrcs080, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family090, sNrcs090, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family100, sNrcs100, 0.0001581, 0.706), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family150, sNrcs150, 0.00018785, 0.719), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family200, sNrcs200, 0.00021549, 0.727), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family300, sNrcs300, 0.00026669, 0.735), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family400, sNrcs400, 0.0003149, 0.74)}

    'Public NrcsSrfrIntakeValuesTable() As NrcsIntakeValues = _
    '    {New NrcsIntakeValues(NrcsIntakeFamilies.Family005, sNrcs005, 0.0000424773, 0.618), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family010, sNrcs010, 0.0000413872, 0.661), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family015, sNrcs015, 0.0000427125, 0.6834), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family020, sNrcs020, 0.0000444615, 0.6988), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family025, sNrcs025, 0.0000464988, 0.7107), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family030, sNrcs030, 0.0000484123, 0.7204), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family035, sNrcs035, 0.0000504356, 0.7285), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family040, sNrcs040, 0.0000523649, 0.7356), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family045, sNrcs045, 0.0000541981, 0.7419), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family050, sNrcs050, 0.0000560644, 0.7475), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family060, sNrcs060, 0.000059487, 0.7572), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family070, sNrcs070, 0.0000627813, 0.7656), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family080, sNrcs080, 0.0000658943, 0.7728), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family090, sNrcs090, 0.0000688945, 0.7792), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family100, sNrcs100, 0.0000717697, 0.785), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family150, sNrcs150, 0.0000866665, 0.799), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family200, sNrcs200, 0.00010072, 0.808), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family300, sNrcs300, 0, 0), _
    '     New NrcsIntakeValues(NrcsIntakeFamilies.Family400, sNrcs400, 0, 0)}

    Public NrcsIntakeValuesTable() As NrcsIntakeValues =
        {New NrcsIntakeValues(NrcsIntakeFamilies.Family005, sNrcs005, 0.0000424773, 0.618),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family010, sNrcs010, 0.0000413872, 0.661),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family015, sNrcs015, 0.0000427125, 0.6834),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family020, sNrcs020, 0.0000444615, 0.6988),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family025, sNrcs025, 0.0000464988, 0.7107),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family030, sNrcs030, 0.0000484123, 0.7204),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family035, sNrcs035, 0.0000504356, 0.7285),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family040, sNrcs040, 0.0000523649, 0.7356),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family045, sNrcs045, 0.0000541981, 0.7419),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family050, sNrcs050, 0.0000560644, 0.7475),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family060, sNrcs060, 0.000059487, 0.7572),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family070, sNrcs070, 0.0000627813, 0.7656),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family080, sNrcs080, 0.0000658943, 0.7728),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family090, sNrcs090, 0.0000688945, 0.7792),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family100, sNrcs100, 0.0000717697, 0.785),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family150, sNrcs150, 0.0000866665, 0.799),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family200, sNrcs200, 0.0001007205, 0.808),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family300, sNrcs300, 0.0001292171, 0.816),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family400, sNrcs400, 0.0001529158, 0.823)}

    Public NrcsApproxValuesTable() As NrcsIntakeValues =
        {New NrcsIntakeValues(NrcsIntakeFamilies.Family005, sNrcs005, 0.0000987269, 0.556),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family010, sNrcs010, 0.0000962202, 0.595),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family015, sNrcs015, 0.000099116, 0.615),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family020, sNrcs020, 0.0001026487, 0.629),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family025, sNrcs025, 0.0001066236, 0.64),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family030, sNrcs030, 0.0001112269, 0.648),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family035, sNrcs035, 0.000114734, 0.656),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family040, sNrcs040, 0.0001190613, 0.662),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family045, sNrcs045, 0.000122474, 0.668),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family050, sNrcs050, 0.0001263079, 0.673),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family060, sNrcs060, 0.0001329357, 0.682),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family070, sNrcs070, 0.0001401881, 0.689),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family080, sNrcs080, 0.0001458081, 0.696),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family090, sNrcs090, 0.000152718, 0.701),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family100, sNrcs100, 0.0001574363, 0.707),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family150, sNrcs150, 0.00018749, 0.719),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family200, sNrcs200, 0.0002148398, 0.727),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family300, sNrcs300, 0.000267087, 0.735),
         New NrcsIntakeValues(NrcsIntakeFamilies.Family400, sNrcs400, 0.0003115687, 0.741)}
    '
    ' NRCS Intake Family Options
    '
    Public Enum NrcsToKostiakovMethods
        LowLimit = -1
        ApproximateByBestFit
        DescribeByNrcsFormula
        HighLimit
    End Enum

    Public Const DefaultNrcsToKostiakovMethod As NrcsToKostiakovMethods = NrcsToKostiakovMethods.DescribeByNrcsFormula

    Public NrcsToKostiakovMethodSelections() As Selection =
        {New Selection("Approximate By Best Fit", SelFlags.Standard),
         New Selection("Describe By NRCS Formula", 0)}

#End Region

#Region " Surface Roughness Globals "
    '
    ' Roughness Specification Methods
    '
    Public Enum RoughnessMethods
        LowLimit = -1
        ManningN
        NrcsSuggestedManningN
        ManningCnAn
        SayreAlbertson
        HighLimit
    End Enum

    Public Const DefaultRoughnessMethod As RoughnessMethods = RoughnessMethods.NrcsSuggestedManningN

    Public RoughnessMethodSelections() As Selection =
        {New Selection("User Entered Manning n", SelFlags.AllWorlds),
         New Selection("Manning n", 0),
         New Selection("Manning Cn/An", SelFlags.StandardAdvanced Or SelFlags.AllButSimulation),
         New Selection("Sayre-Albertson Chi", SelFlags.Standard Or SelFlags.DesignOperations)}

    Public Const DefaultEnableTabulatedRoughness As Boolean = False
    '
    ' NRCS Suggested Manning N
    '
    Public Enum NrcsSuggestedManningN
        LowLimit = -1
        BareSoil
        SmallGrain
        AlfalfaMintBroadcast
        AlfalfaDenseOrLong
        DenseSodCrops
        UserEntered
        HighLimit
    End Enum

    Public Const DefaultNrcsSuggestedManningN As NrcsSuggestedManningN = NrcsSuggestedManningN.BareSoil

    Public NrcsSuggestedManningNValues() As Double = {0.04, 0.1, 0.15, 0.2, 0.25, 0.33}
    '
    ' Vegetative Density
    '
    Public Const DefaultEnableVegetativeDensity As Boolean = False

#End Region

#Region " Fertigation Globals "

    Public Const DefaultEnableFertigation As Boolean = False
    Public Const DefaultNumInjectionPoints As Integer = 1
    Public Const DefaultInjectionPointNum As Integer = 1
    Public Const DefaultInjectionPointLoc As Double = 0.0 ' m
    Public Const DefaultTankConcentration As Double = 0.1 ' g/l

    Public Const DefaultInjectionTimeOn As Double = TenMinutes
    Public Const DefaultInjectionTimeOff As Double = TwentyMinutes
    Public Const DefaultInjectionRate As Double = GallonPerHour
    '
    ' Advection / Dispersion
    '
    Public Const DefaultCharacteristicType As CharacteristicTypes = CharacteristicTypes.Continuous

    Public CharacteristicTypeSelections() As Selection =
        {New Selection("Continuous", 0),
         New Selection("Piece-Wise", 0)}

    Public Const DefaultAdvectionInterpolationMethod As AdvectionInterpolationMethods = AdvectionInterpolationMethods.AkimaSpline

    Public AdvectionInterpolationMethodSelections() As Selection =
        {New Selection("Akima Spline", 0),
         New Selection("Cubic Spline", 0)}

    Public Const DefaultIncludeDispersion As Boolean = True

    Public Const DefaultDispersivityCoefficientMethod As DispersivityCoefficientMethods = DispersivityCoefficientMethods.Elder

    Public DispersivityCoefficientMethodSelections() As Selection =
        {New Selection("Fischer", 0),
         New Selection("Elder", 0),
         New Selection("Deng", 0),
         New Selection("Rutherford", 0),
         New Selection("Specified Kx", 0)}

    Public Const DefaultElderCe As Double = 5.86
    Public Const DefaultSpecifiedKx As Double = 0.0

#End Region

#Region " Erosion Globals "

    Public Const DefaultEnableErosion As Boolean = False

    Public Const DefaultKinematicViscosity As Double = 0.000001143762
    Public Const DefaultMassDensity As Double = 1000.0
    Public Const DefaultErodibilityA As Double = 0.05
    Public Const DefaultErodibilityB As Double = 0.0
    Public Const DefaultErodibilityTauc As Double = 0.02
    Public Const DefaultErodibilityBeta As Double = 1.0
    Public Const DefaultFullScaleG As Double = 0.1  ' 100 g/s
    Public Const DefaultErodibilityTolerance As Double = 0.00005

    Public Const DefaultSedimentConcentration As Double = 100.0
    Public Const DefaultSedimentTime As Double = Srfr.Globals.TwoHours

    Public Const MinErosionCoefficient As Double = 0.0
    Public Const DefaultErosionCoefficient As Double = 0.1
    Public Const MaxErosionCoefficient As Double = 1.0

    Public Const DefaultWaterTempC As Double = 15

    Public Enum ErosionResolutions
        LowLimit = -1
        SingleRes
        FieldRes
        CoarseRes
        FineRes
        HighLimit
    End Enum

    Public Const DefaultErosionResolution As ErosionResolutions = ErosionResolutions.CoarseRes

    Public ErosionResolutionSelections() As Selection =
        {New Selection("Single", 0),
         New Selection("Field", 0),
         New Selection("Coarse (5)", 0),
         New Selection("Fine (9)", 0)}

    Public Enum ErosionFits
        LowLimit = -1
        PieceWiseLinear
        GaussNormal
        LogNormal
        HighLimit
    End Enum

    Public Const DefaultErosionFit As ErosionFits = ErosionFits.PieceWiseLinear

    Public ErosionFitSelections() As Selection =
        {New Selection("Piece-Wise Linear", 0),
         New Selection("Gauss Normal", SelFlags.AllWorlds),
         New Selection("Log Normal", SelFlags.AllWorlds)}

    Public Const DefaultEnableCriticalShear As Boolean = False

#End Region

#Region " Inflow Management Globals "
    '
    ' Inflow Methods
    '
    Public Enum InflowMethods
        LowLimit = -1
        StandardHydrograph
        Surge
        Cablegation
        TabulatedInflow
        HighLimit
    End Enum

    Public Const DefaultInflowMethod As InflowMethods = InflowMethods.StandardHydrograph

    Public Const sStandardHydrograph As String = "Standard Hydrograph"
    Public Const sSurge As String = "Surge"
    Public Const sCablegation As String = "Cablegation"
    Public Const sTabulatedInflow As String = "Tabulated Inflow"

    Public InflowMethodSelections() As Selection =
        {New Selection(sStandardHydrograph, 0),
         New Selection(sSurge, SelFlags.Standard Or SelFlags.AllButSimulation),
         New Selection(sCablegation, SelFlags.StandardAdvanced Or SelFlags.AllButSimulation),
         New Selection(sTabulatedInflow, SelFlags.DesignOperations)}
    '
    ' Cutoff Options
    '
    Public Enum CutoffMethods
        LowLimit = -1
        TimeBased
        DistanceBased
        DistanceInfDepth
        DistanceOppTime
        UpstreamInfDepth
        HighLimit
    End Enum

    Public Const DefaultCutoffMethod As CutoffMethods = CutoffMethods.TimeBased

    Public Const sCutoff As String = "Cutoff"
    Public Const sCutoffTime As String = "Cutoff Time"
    Public Const sCutoffDistance As String = "Cutoff Distance"

    Public Const sCutoffMethod As String = "Cutoff Method"
    Public Const sTimeBasedCutoff As String = "Time-Based Cutoff"
    Public Const sDistanceBasedCutoff As String = "Distance-Based Cutoff"
    Public Const sDistanceInfiltrationDepth As String = "Distance and Infiltration Depth"
    Public Const sDistanceOpportunityTime As String = "Distance and Opportunity Time"
    Public Const sUpstreamInfiltrationDepth As String = "Upstream Infiltration Depth"

    Public CutoffMethodSelections() As Selection =
        {New Selection(sTimeBasedCutoff, 0),
         New Selection(sDistanceBasedCutoff, SelFlags.AllButSimulation),
         New Selection(sDistanceInfiltrationDepth, SelFlags.Standard Or SelFlags.AllButSimulation),
         New Selection(sDistanceOpportunityTime, SelFlags.Standard Or SelFlags.AllButSimulation),
         New Selection(sUpstreamInfiltrationDepth, SelFlags.Standard Or SelFlags.AllButSimulation)}
    '
    ' Cutback Methods
    '
    Public Enum CutbackMethods
        LowLimit = -1
        NoCutback
        TimeBased
        DistanceBased
        HighLimit
    End Enum

    Public Const DefaultCutbackMethod As CutbackMethods = CutbackMethods.NoCutback

    Public Const sCutback As String = "Cutback"
    Public Const sCutbackTime As String = "Cutback Time"
    Public Const sCutbackDistance As String = "Cutback Distance"
    Public Const sCutbackRate As String = "Cutback Rate"

    Public Const sCutbackMethod As String = "Cutback Method"
    Public Const sNoCutback As String = "No Cutback"
    Public Const sTimeBasedCutback As String = "Time-Based Cutback"
    Public Const sDistanceBasedCutback As String = "Distance-Based Cutback"

    Public CutbackMethodSelections() As Selection =
        {New Selection(sNoCutback, 0),
         New Selection(sTimeBasedCutback, 0),
         New Selection(sDistanceBasedCutback, SelFlags.AllButSimulation)}
    '
    ' Surge Strategies
    '
    Public Enum SurgeStrategies
        LowLimit = -1
        UniformTime
        UniformLocation
        TabulatedTime
        TabulatedLocation
        HighLimit
    End Enum

    Public Const DefaultSurgeStrategy As SurgeStrategies = SurgeStrategies.UniformTime

    Public Const sSurgeStrategy As String = "Surge Strategy"
    Public Const sUniformTime As String = "Uniform Time"
    Public Const sUniformLocation As String = "Uniform Location"
    Public Const sTabulatedTime As String = "Tabulated Time"
    Public Const sTabulatedLocation As String = "Tabulated Location"

    Public SurgeStrategySelections() As Selection =
        {New Selection(sUniformTime, 0),
         New Selection(sUniformLocation, 0),
         New Selection(sTabulatedTime, 0),
         New Selection(sTabulatedLocation, 0)}
    '
    ' Cablegation Options
    '
    Public Enum OrificeOptions
        LowLimit = -1
        EquivalentDiameter
        PeakFlow
        HighLimit
    End Enum

    Public Const DefaultOrificeOption As OrificeOptions = OrificeOptions.PeakFlow

    Public OrificeOptionSelections() As Selection =
        {New Selection("Equivalent Diameter", 0),
         New Selection("Peak Flow", 0)}
    '
    ' Required Depth
    '
    Public Const MinimumRequiredDepth As Double = 0.0
    Public Const DefaultRequiredDepth As Double = 0.1 ' 100 mm
    Public Const MaximumRequiredDepth As Double = 1.0
    '
    ' Water Cost
    '
    Public Const MinimumUnitWaterCost As Double = 0.0
    Public Const DefaultUnitWaterCost As Double = 30.0
    '
    ' Labor Cost
    '
    Public Const MinimumUnitLaborCost As Double = 0.0
    Public Const DefaultUnitLaborCost As Double = 7.5
    '
    ' Inflow Rate
    '
    Public Const MinimumInflowRate As Double = 0.0
    Public Const DefaultInflowRate As Double = 0.1 ' 0.1 cms = 100 lps
    Public Const DefaultFurrowInflowRate As Double = DefaultInflowRate / DefaultWidth / DefaultFurrowSpacing
    Public Const MaximumInflowRate As Double = 10.0
    '
    ' Distribution Uniformity
    '
    Public Const MinimumDU As Double = 0.0
    Public Const DefaultDU As Double = 0.9  ' 90%
    Public Const MaximumDU As Double = 100.0
    '
    ' Cutoff
    '
    Public Const MinimumCutoffTime As Double = 0.0
    Public Const DefaultCutoffTime As Double = 4.0 * SecondsPerHour ' 4 hr
    Public Const MaximumCutoffTime As Double = 100.0 * SecondsPerHour

    Public Const MinimumCutoffLocationRatio As Double = 0.0
    Public Const DefaultCutoffLocationRatio As Double = 1.0
    Public Const MaximumCutoffLocationRatio As Double = 2.0

    Public Const MinimumCutoffLocation As Double = MinimumCutoffLocationRatio * DefaultLength
    Public Const DefaultCutoffLocation As Double = DefaultCutoffLocationRatio * DefaultLength
    Public Const MaximumCutoffLocation As Double = MaximumCutoffLocationRatio * DefaultLength

    Public Const MinimumCutoffInfiltrationDepth As Double = 0.0
    Public Const DefaultCutoffInfiltrationDepth As Double = 1.0
    Public Const MaximumCutoffInfiltrationDepth As Double = 2.0

    Public Const MinimumCutoffOpportunityTime As Double = 0.0
    Public Const DefaultCutoffOpportunityTime As Double = 2.0 * SecondsPerHour ' 2 hr
    Public Const MaximumCutoffOpportunityTime As Double = 100.0 * SecondsPerHour

    Public Const MinimumCutoffUpstreamDepth As Double = 0.0
    Public Const DefaultCutoffUpstreamDepth As Double = 1.0
    Public Const MaximumCutoffUpstreamDepth As Double = 2.0

    Public Const MinimumDrawDownTime As Double = 0.0
    Public Const DefaultDrawDownTime As Double = 20.0 * SecondsPerMinute ' 20 min
    Public Const MaximumDrawDownTime As Double = 100.0 * SecondsPerHour
    '
    ' Cutback
    '
    Public Const MinimumCutbackTimeRatio As Double = 0.0
    Public Const DefaultCutbackTimeRatio As Double = 0.5 ' .5 of Cutoff Time
    Public Const MaximumCutbackTimeRatio As Double = 1.0

    Public Const MinimumCutbackfLocationRatio As Double = 0.0
    Public Const DefaultCutbackLocationRatio As Double = 0.5 ' .5 of Cutoff Location
    Public Const MaximumCutbackLocationRatio As Double = 1.0

    Public Const MinimumCutbackRateRatio As Double = 0.0
    Public Const DefaultCutbackRateRatio As Double = 0.5 ' .5 of Inflow Rate
    Public Const MaximumCutbackRateRatio As Double = 1.0
    '
    ' Surge
    '
    Public Const MinimumSurgeOnTime As Double = 0.0
    Public Const DefaultSurgeOnTime As Double = OneHour

    Public Const MinimumNumberOfSurges As Integer = 1
    Public Const DefaultNumberOfSurges As Integer = 4

    Public Const DefaultSurgeInflowRate As Double = 25.0 * LiterPerSecond
    Public Const DefaultSurgeCutbackTime As Double = DefaultNumberOfSurges * DefaultSurgeOnTime * 2.0
    Public Const DefaultSurgeCutoffTime As Double = 10.0 * OneHour
    '
    ' Cablegation
    '
    Public Const DefaultTotalInflow As Double = 38.0 * LiterPerSecond
    Public Const DefaultCablegationPeakOrificeFlow As Double = 2.0 * LiterPerSecond
    Public Const DefaultCutoffFlow As Double = 0.0 * LiterPerSecond
    Public Const DefaultPipeSlope As Double = 0.003
    Public Const DefaultPipeDiameter As Double = 10.0 * OneInch
    Public Const DefaultOrificeDiameter As Double = OneInch
    Public Const DefaultOrificeSpacing As Double = 30.0 * OneInch
    Public Const DefaultPlugSpeed As Double = 3.4 / OneHour
    Public Const DefaultHazenWilliamsPipeCoefficient As Double = 150.0

#End Region

#Region " Contouring Criteria "
    '
    ' Resolution Selections
    '
    Public Enum ResolutionSelections
        LowLimit = -1
        GrossResolution
        CoarseResolution
        MediumResolution
        FineResolution
        HighLimit
    End Enum

    Public GridResolutionSelections() As Selection =
        {New Selection("Gross (5x5)", SelFlags.AllWorlds),
         New Selection("Coarse (10x10)", 0),
         New Selection("Medium (20x20)", 0),
         New Selection("Fine (40x40)", 0)}

    Public Const DefaultGridResolution As ResolutionSelections = ResolutionSelections.CoarseResolution
    '
    ' Contour Precision
    '
    Public Enum ContourPrecision
        Standard
        Precise
    End Enum

    Public Const DefaultContourPrecision As ContourPrecision = ContourPrecision.Standard

#End Region

#Region " Simulation Criteria "

#Region " Simulation Animation "
    '
    ' Animation Profile
    '
    Public Enum AnimationProfiles
        LowLimit = -1
        PlotElevations
        PlotDepths
        HighLimit
    End Enum

    Public Const DefaultAnimationProfile As AnimationProfiles = AnimationProfiles.PlotElevations

    Public GraphicProfileSelections() As Selection =
        {New Selection("Plot Elevations", 0),
         New Selection("Plot Depths", 0)}
    '
    ' Animation Display
    '
    Public Const DefaultRlLeft As Double = 0.0
    Public Const DefaultRlRight As Double = 1.0

    Public Const DefaultRyBottom As Double = 0.0
    Public Const DefaultRyTop As Double = 1.0

    Public Const DefaultRfsH As Double = 1.0
    Public Const DefaultRfsX As Double = 1.0
    Public Const DefaultRfsY As Double = 1.0
    Public Const DefaultRfsZ As Double = 1.0

#End Region

#Region " Simulation Control "
    '
    ' Solution Model
    '
    Enum SolutionModels
        LowLimit = -1
        ZeroInertia
        KinematicWave
        SaintVenant
        HighLimit
    End Enum

    Public Const DefaultSolutionModel As SolutionModels = SolutionModels.KinematicWave

    Public SolutionModelSelections() As Selection =
         {New Selection("Zero-Inertia", 0),
          New Selection("Kinematic-Wave", 0),
          New Selection("Saint Venant", SelFlags.AllWorlds)}

    Public Const ZeroInertiaSlope As Double = 0.004 ' User Zero-Inertia if less than this slope
    '
    ' Cell Density
    '
    Enum CellDensities
        Coarse = 20
        Medium = 40
        Fine = 60
        ExtraFine = 80
    End Enum

    Public Const DefaultCellDensity As CellDensities = CellDensities.Medium
    '
    ' Shape Factors
    '
    Public Const DefaultPhiAYL_KW As Double = 0.0
    Public Const DefaultPhiAYL_ZI As Double = 0.5
    Public Const DefaultPhiAZL As Double = 0.5
    Public Const DefaultTheta As Double = 0.6

#End Region

#Region " Simulation Diagnostics "
    '
    ' Diagnostic Output Flags
    '
    Enum SimDiagFlags
        Bit0 = 1
        Bit1 = 2
        Bit2 = 4
        Bit3 = 8
        Bit4 = 16
        Bit5 = 32
        Bit6 = 64
        Bit7 = 128
        Bit8 = 256
        Bit9 = 512
        Bit10 = 1024
        Bit11 = 2048
        Bit12 = 4096
        Bit13 = 8192
        Bit14 = 16384
        Bit15 = 32768
    End Enum

    Public Const DefaultDiagFlags As Integer = SimDiagFlags.Bit0 _
                                             + SimDiagFlags.Bit1 _
                                             + SimDiagFlags.Bit2

    Public Const DefaultAux1Flags As Integer = SimDiagFlags.Bit10 _
                                             + SimDiagFlags.Bit11

    Public Const DefaultAux2Flags As Integer = 0

    Public Const DefaultAux3Flags As Integer = 0

    Public Const DefaultExpFlags As Integer = SimDiagFlags.Bit6
    '
    ' Diagnostic Iteration Control
    '
    Public Const DefaultStartI As Integer = 1
    Public Const DefaultStartJ As Integer = 1
    Public Const DefaultStartK As Integer = 1

    Public Const DefaultEndK As String = "END"

#End Region

#End Region

#Region " Event Analysis Criteria "
    '
    ' Event Analysis type
    '
    Public Enum EventAnalysisTypes
        LowLimit = -1
        InfiltratedProfileAnalysis
        MerriamKellerAnalysis
        TwoPointAnalysis
        ErosionAnalysis
        EvalueAnalysis
        HighLimit
    End Enum

    Public Const DefaultEventAnalysisType As EventAnalysisTypes = EventAnalysisTypes.EvalueAnalysis

    Public EventAnalysisTypeSelections() As Selection =
        {New Selection("Infiltrated Profile Analysis", 0),
         New Selection("Merriam-Keller Analysis", 0),
         New Selection("Two-Point Analysis", 0),
         New Selection("Erosion Analysis", 0),
         New Selection("EVALUE Analysis", 0)}
    '
    ' Elliott-Walker B Selection
    '
    Public Enum ElliotWalkerBSelections
        LowLimit = -1
        CalculateB
        EnterB
        HighLimit
    End Enum

    Public Const DefaultElliotWalkerBSelection As ElliotWalkerBSelections = ElliotWalkerBSelections.CalculateB
    '
    ' EVALUE Selections
    '
    Public Enum StationsGraphs
        LowLimit = -1
        StationsHydrographs
        StationsProfiles
        HighLimit
    End Enum
    '
    ' Goodness-of-Fit Indication methods
    '
    Public Enum GoodnessOfFitMethods
        LowLimit = -1
        NashSutcliffeE
        IndexOfAgreementD
        PercentBias
        RMSEstandardRatio
        HighLimit
    End Enum

    Public Const DefaultGoodnessOfFitMethod As GoodnessOfFitMethods = GoodnessOfFitMethods.NashSutcliffeE

    Public GoodnessOfFitMethodSelections() As Selection =
        {New Selection("Nash-Sutcliffe E (NSE)", 0),
         New Selection("Index of Agreement d", 0),
         New Selection("Percent Bias (PBIAS)", 0),
         New Selection("RMSE Standard Ratio (RSR)", 0)}

    Public Const UsePowerAdvanceLaw As Boolean = False
    Public Const MinPowerAdvanceLawR As Double = 0.5

#End Region

#Region " Physical Design Criteria "
    '
    ' Design Options
    '
    Public Enum DesignOptions
        LowLimit = -1
        WidthGiven
        InflowRateGiven
        HighLimit
    End Enum

    Public Const DefaultDesignOption As DesignOptions = DesignOptions.InflowRateGiven
    '
    ' Infiltrated Depth Criteria
    '
    Public Enum InfiltratedDepthCriteria
        LowLimit = -1
        MinimumDepth
        LowQuarterDepth
        HighLimit
    End Enum

    Public Const DefaultInfiltratedDepthCriterion As InfiltratedDepthCriteria = InfiltratedDepthCriteria.MinimumDepth

    Public InfiltratedDepthCriteriaSelections() As Selection =
        {New Selection("Minimum", 0),
         New Selection("Low Quarter", SelFlags.PhysicalDesign)}
    '
    ' Min / Max contour display ranges
    '
    Public Const DefaultMinContourLength As Double = 50.0
    Public Const DefaultMaxContourLength As Double = 200.0

    Public Const DefaultMinContourWidth As Double = 10.0
    Public Const DefaultMaxContourWidth As Double = 100.0

    Public Const DefaultMinContourInflowRate As Double = 0.0
    Public Const DefaultMaxContourInflowRate As Double = 0.2 ' 0.200 cms = 200 lps

    Public Const DefaultMinContourFurrowsPerSet As Double = 1.0
    Public Const DefaultMaxContourFurrowsPerSet As Double = 25.0
    '
    ' Tuning Factors
    '
    Public Const MinSigmaY As Double = 0.0
    Public Const DefaultSigmaY As Double = 0.75
    Public Const MaxSigmaY As Double = 2.0

    Public Const DefaultPhi0Furrows As Double = 1.0
    Public Const DefaultPhi1Furrows As Double = 1.0
    Public Const DefaultPhi2Furrows As Double = 1.0
    Public Const DefaultPhi3Furrows As Double = 1.0

    Public Const DefaultPhi0Borders As Double = 1.0
    Public Const DefaultPhi1Borders As Double = 1.0
    Public Const DefaultPhi2Borders As Double = 1.0
    Public Const DefaultPhi3Borders As Double = 3.0
    '
    ' Misc.
    '
    Public Const DesignLimitLine As Double = 0.85
    Public Const RoDpRatioLimit As Double = 0.1

#End Region

#Region " Operations Analysis Criteria "
    '
    ' Operations Options
    '
    Public Enum OperationsOptions
        WidthGiven
        InflowRateGiven
    End Enum

    Public Const DefaultOperationsOption As OperationsOptions = OperationsOptions.WidthGiven

    Public Enum OperationsMethod
        VolumeBalance
        SrfrSimulations
    End Enum

    Public Const DefaultOperationsMethod As OperationsMethod = OperationsMethod.VolumeBalance
    '
    ' Min / Max contour display ranges
    '
    Public Const DefaultMinContourCutoffTime As Double = 0.0 * SecondsPerHour
    Public Const DefaultMaxContourCutoffTime As Double = 1000.0 * SecondsPerMinute ' 1000 min

    Public Const DefaultMinFurrowsPerSet As Double = 1.0

    Public Const DefaultMinContourCutoffLocationRatio As Double = 0.6
    Public Const DefaultMaxContourCutoffLocationRatio As Double = 1.0

#End Region

End Module
