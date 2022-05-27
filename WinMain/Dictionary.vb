
'*************************************************************************************************************
' Class: Dictionary - contains strings capable of translation to other languages
'*************************************************************************************************************
Imports Srfr.Infiltration
Imports DataStore

Public Class Dictionary
    Inherits Translator

#Region " Constructor(s) "

    Protected Sub New()
        MyBase.New()
    End Sub

    ' Allow access to singleton Translator via Instance() method
    Public Shared Shadows Function Instance() As Dictionary
        ' If Dictionary has already been instantiated, just return it
        If (mTranslator IsNot Nothing) Then
            If (mTranslator.GetType IsNot GetType(Dictionary)) Then
                mTranslator = Nothing
            End If
        End If

        ' If Dictionary has not been instantiated, do so
        If (mTranslator Is Nothing) Then
            mTranslator = New Dictionary
        End If
        Return mTranslator
    End Function

#End Region

#Region " Phrases to Translate "

#Region " Project Management "

    Public tWinSrfrDescription As TString = New TString("Windows Surface Irrigation Design, Operations, Analysis & Simulation Software Program")

    Public tFarm As TString = New TString("Farm")
    Public tFarmName As TString = New TString("Farm Name")
    Public tFarmOwner As TString = New TString("Farm Owner")
    Public tDefaultFarmNameOwner As TString = New TString("Default Farm Name / Owner")

    Public tProject As TString = New TString("Project")
    Public tProjectName As TString = New TString("Project Name")
    Public tProjectOwner As TString = New TString("Project Owner")
    Public tProjectManagement As TString = New TString("Project Management")
    Public tDefaultProjectNameOwner As TString = New TString("Default Project Name / Owner")

    Public tField As TString = New TString("Field")
    Public tCase As TString = New TString("Case")

    Public tWorld As TString = New TString("World")
    Public tAnalysis As TString = New TString("Analysis")

    Public tOwner As TString = New TString("Owner")
    Public tEvaluator As TString = New TString("Evaluator")

    Public tAdvanced As TString = New TString("Advanced")
    Public tStandard As TString = New TString("Standard")
    Public tResearch As TString = New TString("Research")

    Public tCreatingNewLanguage As TString = New TString("Creating New Language Translation File")
    Public tNewLanguageCreated As TString = New TString("New Language Translation File Created")
    Public tNewLanguageSaveFailed As TString = New TString("Language Translation File Save Failed")
    Public tResetingLanguageTo As TString = New TString("Reseting language to")
    Public tSaveTranslationAsBin As TString = New TString("Save &Translation as Bin")
    Public tInvalidTranslationFile As TString = New TString("Invalid translation file")

    Public tBackupIsLocatedHere As TString = New TString("A backup of your previously saved file is located here")
    Public tCopiedToClipboard As TString = New TString("Copied to clipboard")
    Public tDoYouWantToSaveChangesToCurrentProject As TString = New TString("Do you want to save the changes to the current project?")

    Public tDataExplorer As TString = New TString("Data Explorer")

    ' Analysis Explorer
    Public tToAdd As TString = New TString("to add")
    Public tToStart As TString = New TString("to start")
    Public tDoubleClickHere As TString = New TString("Double-Click here")
    Public tToStartNewProject As TString = New TString("to start a new Project")
    Public tOpenProject As TString = New TString("Open Project")
    Public tNewProject As TString = New TString("New Project")
    Public tNewProjectCreated As TString = New TString("New Project created")
    Public tNewCaseFieldAdded As TString = New TString("New Case / Field added")
    Public tNewAnalysisAdded As TString = New TString("New Analysis added")
    Public tNewFolderAdded As TString = New TString("New Folder added")

    ' Analysis Details
    Public tDetails As TString = New TString("Details")

#End Region

#Region " System Geometry "

    Public tSystemGeometry As TString = New TString("System Geometry")

    ' Cross Section
    Public tCrossSection As TString = New TString(sCrossSection)
    Public tBasin As TString = New TString(sBasin)
    Public tBorder As TString = New TString(sBorder)
    Public tFurrow As TString = New TString(sFurrow)

    Public tCrossSectionArea As TString = New TString(sCrossSectionArea)
    Public tTabulatedCrossSection As TString = New TString(sTabulatedCrossSection)

    Public tBottomDescription As TString = New TString(sBottomDescription)
    Public tSlope As TString = New TString(sSlope)
    Public tSlopeTable As TString = New TString(sSlopeTable)
    Public tElevationTable As TString = New TString(sElevationTable)
    Public tAverageSlopeTable As TString = New TString(sAverageSlopeTable)
    Public tAverageElevationTable As TString = New TString(sAverageElevationTable)

    Public tUpstreamCondition As TString = New TString(sUpstreamCondition)
    Public tNoDrainback As TString = New TString(sNoDrainback)
    Public tDrainback As TString = New TString(sDrainback)

    Public tDownstreamCondition As TString = New TString(sDownstreamCondition)
    Public tOpenEnd As TString = New TString(sOpenEnd)
    Public tBlockEnd As TString = New TString(sBlockedEnd)
    '
    ' Basin / Border
    '
    Public tBorderLength As TString = New TString("Border Length")
    Public tBorderWidth As TString = New TString("Border Width")
    '
    ' Furrow
    '
    Public tFurrowShape As TString = New TString(sFurrowShape)
    Public tTrapezoid As TString = New TString(sTrapezoid)
    Public tPowerLaw As TString = New TString(sPowerLaw)
    Public tTrapezoidTable As TString = New TString(sTrapezoidTable)
    Public tPowerLawTable As TString = New TString(sPowerLawTable)
    Public tAverageTrapezoidTable As TString = New TString(sAverageTrapezoidTable)
    Public tAveragePowerLawTable As TString = New TString(sAveragePowerLawTable)
    Public tTrapezoidFieldData As TString = New TString(sTrapezoidFieldData)
    Public tPowerLawFieldData As TString = New TString(sPowerLawFieldData)

    Public tFurrowFieldDataType As TString = New TString(sFurrowFieldDataType)
    Public tWidthTable As TString = New TString(sWidthTable)
    Public tDepthWidthTable As TString = New TString(sDepthWidthTable)
    Public tProfilometerTable As TString = New TString(sProfilometerTable)

    Public tFurrowSet As TString = New TString("Furrow Set")
    Public tFurrowLength As TString = New TString("Furrow Length")
    Public tFurrowSetWidth As TString = New TString("Furrow Set Width")
    Public tFurrowSpacing As TString = New TString("Furrow Spacing")
    Public tFurrowsPerSet As TString = New TString("Furrows/Set")
    Public tPerFurrow As TString = New TString("per Furrow")
    Public tEnterFurrowMaximumDepth As TString = New TString("Enter the furrow's Maximum Depth")
    Public tFitTo As TString = New TString("Fit To")

    Public tTrapezoidArea As TString = New TString("Trapezoid Area")
    Public tTrapezoidFurrow As TString = New TString("Trapezoid Furrow")
    Public tPowerLawArea As TString = New TString("Power Law Area")
    Public tPowerLawFurrow As TString = New TString("Power Law Furrow")
    Public tTrapezoidFromFieldData As TString = New TString("Trapezoid from Field Data")
    Public tPowerLawFromFieldData As TString = New TString("Power Law from Field Data")

    Public tBottomWidth As TString = New TString("Bottom Width")
    Public tMiddleWidth As TString = New TString("Middle Width")
    Public tTopWidth As TString = New TString("Top Width")
    Public tWidthAt100mm As TString = New TString("Width At 100mm")
    Public tSideSlope As TString = New TString("Side Slope")
    Public tExponent As TString = New TString("Exponent")

    Public tLength As TString = New TString("Length")
    Public tWidth As TString = New TString("Width")
    Public tWidthAt As TString = New TString("Width at")
    Public tArea As TString = New TString("Area")

    Public tDepth As TString = New TString("Depth")
    Public tMaxDepth As TString = New TString("Max Depth")
    Public tTabulatedBorderDepth As TString = New TString("Tabulated Border Depth")
    Public tElevation As TString = New TString("Elevation")

    Public tSlopeTableEditor As TString = New TString("Slope Table Editor")
    Public tElevationTableEditor As TString = New TString("Elevation Table Editor")
    Public tSlopeDefinedBySlopeTable As TString = New TString("Slope defined by Slope Table")
    Public tSlopeDefinedByElevationTable As TString = New TString("Slope defined by Elevation Table")
    Public tSlopeIsLevel As TString = New TString("Slope is Level")
    Public tAverageSlope As TString = New TString("Average Slope")
    Public tNegativeSlope As TString = New TString("Negative Slope")
    Public tNegativeAverageSlope As TString = New TString("Negative Average Slope")

    Public tTopView As TString = New TString("Top View")
    Public tSideView As TString = New TString("Side View")
    Public tWaterFlow As TString = New TString("Water Flow")

    Public tRodLocation As TString = New TString("Rod Location")
    Public tRodDepth As TString = New TString("Rod Depth")
    Public tRodSpacing As TString = New TString("Rod Spacing")

    Public tEditingSlopeTable As TString = New TString("Editing Bottom Description as Slope Table")
    Public tElevationTableEntered As TString = New TString("Elevation data for this analysis has previously been entered.")
    Public tEditingSlopeWillLoseData As TString = New TString("Editing this data as a Slope Table will result in the loss of the previously entered elevations.")

#End Region

#Region " Soil / Crop Properties "

    Public tSoilCropProperties As TString = New TString("Soil / Crop Properties")
    '
    ' Roughness
    '
    Public tRoughness As TString = New TString("Roughness")
    Public tManningN As TString = New TString("Manning n")
    Public tSayreChi As TString = New TString("Sayre-Albertson Chi")

    Public tRoughnessDefinitionNotAvailable As TString = New TString("Roughness definition is not available on this tab")
    '
    ' Infiltration
    '
    Public tInfiltrationFunction As TString = New TString(sInfiltrationFunction)
    Public tInfiltrationDepthFunction As TString = New TString(sInfiltrationDepthFunction)
    Public tCharacteristicInfiltrationTime As TString = New TString(sCharacteristicInfiltrationTime)
    Public tNrcsIntakeFamily As TString = New TString(sNrcsIntakeFamily)
    Public tTimeRatedIntakeFamily As TString = New TString(sTimeRatedIntakeFamily)
    Public tKostiakovFormula As TString = New TString(sKostiakovFormula)
    Public tModifiedKostiakovFormula As TString = New TString(sModifiedKostiakovFormula)
    Public tBranchFunction As TString = New TString(sBranchFunction)
    Public tHydrus1D As TString = New TString(sHydrus1D)
    Public tGreenAmpt As TString = New TString(sGreenAmpt)
    Public tWarrickGreenAmpt As TString = New TString(sWarrickGreenAmpt)

    Public tWettedPerimeterMethod As TString = New TString(sWettedPerimeterMethod)
    Public tLocalWettedPerimeter As TString = New TString(sLocalWettedPerimeter)
    Public tUpstreamWettedPerimeter As TString = New TString(sUpstreamWettedPerimeter)
    Public tUpstreamWpAtNormalDepth As TString = New TString(sUpstreamWpAtNormalDepth)
    Public tFurrowSpacingNoWpEffect As TString = New TString(sFurrowSpacingNoWpEffect)
    Public tNrcsEmpiricalWettedPerimeter As TString = New TString(sNrcsEmpiricalWettedPerimeter)
    Public tRepresentativeUpstreamWP As TString = New TString(sRepresentativeUpstreamWP)

    Public tInfiltration As TString = New TString("Infiltration")
    Public tInfiltrationFunctionEditor As TString = New TString("Infiltration Function Editor")
    Public tInfiltrationOrdered As TString = New TString("Infiltration (Ordered)")
    Public tUpstreamInfiltration As TString = New TString("Upstream Infiltration")
    Public tWaterBalanceInfiltration As TString = New TString("Water Balance and Infiltration")
    Public tUseInfiltrationFunctionEditor As TString = New TString("Use Infiltration Function &Editor...")
    Public tUseEditor As TString = New TString("&Editor...")

    Public tMinimum As TString = New TString("Minimum")
    Public tMaximum As TString = New TString("Maximum")

    Public tCharacteristicInfiltrationDepth As TString = New TString("Characteristic Infiltration Depth")

    Public tInfiltrationTime As TString = New TString("Infiltration Time")
    Public tBranchTime As TString = New TString("Branch Time")
    Public tUnableToInfiltrateToDreq As TString = New TString("Unable to infiltrate to Dreq")
    Public tInfiltrationBasedOnUpstreamFlowDepth As TString = New TString("Infiltration based on upstream flow depth")
    Public tReferenceUpstreamFlowDepth As TString = New TString("Reference upstream flow depth")
    Public tHydrusGraphNotAvailable As TString = New TString("HYDRUS graph is not available")
    Public tAutomaticConversionSupported As TString = New TString("Automatic conversion between these methods is supported by WinSRFR")
    Public TNrcsFamilyApproximatedByBestFit As TString = New TString("NRCS Family Approximated by Best Fit")
    Public tPerformConversionAutomatically As TString = New TString("Do you want automatic infiltration parameter conversion to be performed?")
    Public tWettedPerimeterChanging As TString = New TString("Wetted Perimeter is Changing")
    Public tChangingWettedPerimeterMsg As TString = New TString("Changing the Wetted Perimeter requires adjusting the Infiltration Parameters to account for this change")
    Public tUseAnalysisTabs As TString = New TString("Use the Analysis Tabs to estimate the infiltration parameters from field measured data.")
    Public tNoInfiltration As TString = New TString("No infiltration")

    Public tInfiltrationEditorDepthsHelpText As TString = New TString("Adjust the parameter values using the up-down controls to match the infiltration depth curve.  (Use the left-hand side controls to modify the magnitude of the adjustment).")
    Public tInfiltrationEditorVolumeHelpText As TString = New TString("Adjust the parameter values using the up-down controls to match the predicted infiltration volumes to the values from volume-balance.  (Use the left-hand side controls to modify the magnitude of the adjustment).")

    Public tSoilTextureSelection As TString = New TString(sSoilTextureSelection)
    Public tSand As TString = New TString(sSand)
    Public tLoamySand As TString = New TString(sLoamySand)
    Public tSandyLoam As TString = New TString(sSandyLoam)
    Public tLoam As TString = New TString(sLoam)
    Public tSiltLoam As TString = New TString(sSiltLoam)
    Public tSandyClayLoam As TString = New TString(sSandyClayLoam)
    Public tClayLoam As TString = New TString(sClayLoam)
    Public tSiltyClayLoam As TString = New TString(sSiltyClayLoam)
    Public tSandyClay As TString = New TString(sSandyClay)
    Public tSiltyClay As TString = New TString(sSiltyClay)
    Public tClay As TString = New TString(sClay)

#End Region

#Region " Inflow Management "
    '
    ' Inflow
    '
    Public tInflow As TString = New TString("Inflow")
    Public tInflowRate As TString = New TString("Inflow Rate")
    Public tInflowVolume As TString = New TString("Inflow Volume")

    Public tBorderInflowRate As TString = New TString("Border Inflow Rate")
    Public tFurrowInflowRate As TString = New TString("Furrow Inflow Rate")
    Public tFurrowSetInflowRate As TString = New TString("Furrow Set Inflow Rate")

    ' Standard Hydrograph
    Public tStandardHydrograph As TString = New TString(sStandardHydrograph)

    Public tCutoff As TString = New TString(sCutoff)
    Public tCutoffTime As TString = New TString(sCutoffTime)
    Public tCutoffDistance As TString = New TString(sCutoffDistance)

    Public tCutoffMethod As TString = New TString(sCutoffMethod)
    Public tTimeBasedCutoff As TString = New TString(sTimeBasedCutoff)
    Public tDistanceBasedCutoff As TString = New TString(sDistanceBasedCutoff)
    Public tDistanceInfiltrationDepth As TString = New TString(sDistanceInfiltrationDepth)
    Public tDistanceOpportunityTime As TString = New TString(sDistanceOpportunityTime)
    Public tUpstreamInfiltrationDepth As TString = New TString(sUpstreamInfiltrationDepth)

    Public tCutback As TString = New TString(sCutback)
    Public tCutbackTime As TString = New TString(sCutbackTime)
    Public tCutbackDistance As TString = New TString(sCutbackDistance)
    Public tCutbackRate As TString = New TString(sCutbackTime)

    Public tCutbackMethod As TString = New TString(sCutbackMethod)
    Public tNoCutback As TString = New TString(sNoCutback)
    Public tTimeBasedCutback As TString = New TString(sTimeBasedCutback)
    Public tDistanceBasedCutback As TString = New TString(sDistanceBasedCutback)

    ' Tabulated Inflow
    Public tTabulatedInflow As TString = New TString(sTabulatedInflow)

    ' Surge
    Public tSurge As TString = New TString(sSurge)
    Public tSurgeStrategy As TString = New TString(sSurgeStrategy)

    Public tOnLeft As TString = New TString("On Left")
    Public tOnRight As TString = New TString("On Right")
    Public tNumberOfSurges As TString = New TString("Number of Surges")
    Public tNumberOfAdvanceSurges As TString = New TString("Number of Advance Surges")
    Public tSurgeLocationRatio As TString = New TString("Surge Location Ratio")

    Public tUniformTime As TString = New TString(sUniformTime)
    Public tUniformLocation As TString = New TString(sUniformLocation)
    Public tTabulatedTime As TString = New TString(sTabulatedTime)
    Public tTabulatedLocation As TString = New TString(sTabulatedLocation)

    ' Cablegation
    Public tCablegation As TString = New TString(sCablegation)
    '
    ' Runoff
    '
    Public tRunoff As TString = New TString("Runoff")
    Public tRunoffRate As TString = New TString("Runoff Rate")

    Public tTabulatedRunoff As TString = New TString("Tabulated Runoff")
    '
    ' Surface Flow
    '
    Public tFlow As TString = New TString("Flow")
    Public tFlowRate As TString = New TString("Flow Rate")
    Public tFlowDepth As TString = New TString("Flow Depth")
    Public tFlowVelocity As TString = New TString("Flow Velocity")

    Public tSurfaceFlow As TString = New TString("Surface Flow")
    Public tSurfaceVolume As TString = New TString("Surface Volume")
    Public tSurfaceVolumes As TString = New TString("Surface Volumes")
    Public tSurfaceVolumesEstimated As TString = New TString("Surface Volumes (Estimated)")
    Public tSurfaceVolumesMeasured As TString = New TString("Surface Volumes (Measured)")
    Public tSurfaceVolumesNotEstimated As TString = New TString("Surface Volumes are not estimated for this analysis")

    Public tAdvance As TString = New TString("Advance")
    Public tRecession As TString = New TString("Recession")

    Public tAdvanceDidNotReachDistance As TString = New TString("Advance did not reach distance")

    Public tQinRunoffPerFurrow As TString = New TString("Qin and Runoff values are per furrow")
    Public tVolumesPerFurrow As TString = New TString("Volumes are per furrow")

    Public tFieldMeasuredVolumeBalance As TString = New TString("Field-measured Volume Balance")
    Public tFinalSimulatedVolumeBalance As TString = New TString("Final Simulated Volume Balance")

    Public tWaterSurfaceElevation As TString = New TString("Water Surface Elev")
    Public tWaterSurfaceProfiles As TString = New TString("Water Surface Profiles")
    Public tFlowDepthHydrographs As TString = New TString("Flow Depth Hydrographs")
    Public tFlowDepthProfiles As TString = New TString("Flow Depth Profiles")

    Public tAvgOppTime As TString = New TString("Avg. Opportunity Time")

#End Region

#Region " Simulation World "

    ' Simulation
    Public tSimulation As TString = New TString("Simulation")
    Public tSimulationWorld As TString = New TString("Simulation World")
    Public tLoadingSrfrCriteria As TString = New TString("Loading SRFR Criteria")
    Public tLoadingSrfrInputs As TString = New TString("Loading SRFR Inputs")
    Public tExecutingSrfrRun As TString = New TString("Executing SRFR Run")
    Public tSimulationComplete As TString = New TString("Simulation Complete")
    Public tSimulationResults As TString = New TString("Simulation Results")
    Public tGettingSrfrResults As TString = New TString("Getting SRFR Results")
    Public tSimulationAnimation As TString = New TString("Simulation Animation")

    Public tDataSummary As TString = New TString("Data Summary")
    Public tCutoffDistanceBasedCutbackTimeBased As TString = New TString("Cutoff is Distance-Based; Cutback is Time-Based")
    Public tInfiltratedDepthUpstreamEndOfField As TString = New TString("Infiltrated Depth at Upstream End of the Field")
    Public tThisWorldSimulates As TString = New TString("This world simulates unsteady surface-subsurface flow for individual fields")
    Public tSelectYourParameters As TString = New TString("Select system type and boundary conditions, then use tabs to enter geometry, infiltration, roughness, and flow data")

    ' Erosion

    ' Fertigation
    Public tInjectionRate As TString = New TString("Injection Rate")
    Public tInjectionTable As TString = New TString("Injection Table")
    Public tInjectionTimesLimitedByTco As TString = New TString("Injection Time(s) extend past and are limited by Tco")

    ' HYDRUS
    Public tEnsureFileContainsValidData As TString = New TString("Ensure file contains valid data")
    Public tHydrusFileError As TString = New TString("HYDRUS file error")
    Public tHydrusProfiles As TString = New TString("HYDRUS Profiles")
    Public tHydrusProjectValidationFailed As TString = New TString("HYDRUS Project Validation Failed")

    Public tHydrus1DNotAvailable As TString = New TString("HYDRUS-1D is not available")
    Public tHydrus1DNotAvailableForFurrows As TString = New TString("HYDRUS-1D does not support Furrows")
    Public tHydrus1DNotAvailableForOperationsAnalysis As TString = New TString("HYDRUS-1D is not available for Operations Analysis")
    Public tHydrus1DNotAvailableForDesignAnalysis As TString = New TString("HYDRUS-1D is not available for Design Analysis")

    Public tHydrusRunStarted As TString = New TString("HYDRUS Run Started")
    Public tHydrusRunSuccessful As TString = New TString("HYDRUS Run Successful")
    Public tHydrusRunFailed As TString = New TString("HYDRUS Run Failed")
    Public tHydrusExecutionError As TString = New TString("HYDRUS execution error")
    Public tHydrusNotRun As TString = New TString("HYDRUS was not run")
    Public tHydrusContinueExecution As TString = New TString("Continue HYDRUS execution?")

    Public tHydrusMainProcesses As TString = New TString("Main Processes window")
    Public tHydrusTimeInformation As TString = New TString("Time Information window")
    Public tHydrusPrintInformation As TString = New TString("Print Information window")
    Public tHydrusCheckingSoluteTransport As TString = New TString("Checking HYDRUS Solute Transport Parameters")
    Public tHydrusProjectNotSpecified As TString = New TString("HYDRUS project has not been specified")
    Public tEnsureHYDRUSfilesAreCompatible As TString = New TString("Ensure all HYDRUS' input files are compatible with these changes")

    Public tSyncIterationsStarted As TString = New TString("Sync Iterations Started")
    Public tSyncError As TString = New TString("Sync Error")
    Public tSyncSuccessful As TString = New TString("Sync Successful")
    Public tSyncFailed As TString = New TString("Sync Failed")
    Public tSyncHYDRUScompleted As TString = New TString("Sync w/HYDRUS completed successfully")
    Public tSyncHYDRUSterminated As TString = New TString("Sync w/HYDRUS terminated unsuccessfully")

    Public tVaporFlow As TString = New TString("Vapor Flow")
    Public tSnowHydrology As TString = New TString("Snow Hydrology")
    Public tSoluteTransport As TString = New TString("Solute Transport")
    Public tStndSoluteTransport As TString = New TString("Standard Solute Transport")
    Public tNumOfSolutes As TString = New TString("Number of Solutes")
    Public tHeatTransport As TString = New TString("Heat Transport")
    Public tRootWaterUpdake As TString = New TString("Root Water Updake")
    Public tRootGrowth As TString = New TString("Root Growth")
    Public tInverseSolution As TString = New TString("Inverse Solution")
    Public tTimeVariableBC As TString = New TString("Time-Variable BC")
    Public tTLevelInformation As TString = New TString("T-Level Information")
    Public tScreenOutput As TString = New TString("Screen Output")
    Public tPrintAtRegTimeInt As TString = New TString("Print at Reg. Time Ints")
    Public tHitEnterAtEnd As TString = New TString("Hit Enter at End?")
    Public tNoOfPrintTimes As TString = New TString("No. of Print Times")
    Public tTimeInterval As TString = New TString("Time Interval")
    Public tHydrusValidationError As TString = New TString("HYDRUS validation error")
    Public tHydrusValidationSummary As TString = New TString("HYDRUS Validation Summary")
    Public tHydrusInfiltration As TString = New TString("HYDRUS Infiltration")
    Public tHydrusInfiltrationRate As TString = New TString("HYDRUS Infiltration Rate")

#End Region

#Region " Design & Operations Worlds "
    '
    ' Design / Operations Phrases
    '
    Public tDesign As TString = New TString("Design")
    Public tDesignAnalysis As TString = New TString("Design Analysis")
    Public tDesignCriteria As TString = New TString("Design Criteria")
    Public tDesignWorldUsage As TString = New TString("This world helps optimize the physical dimensions (length and/or width) of level-basin, sloping-border or furrow irrigated fields.")

    Public tOperations As TString = New TString("Operations")
    Public tOperationsAnalysis As TString = New TString("Operations Analysis")
    Public tOperationsWorldUsage As TString = New TString("This world helps determine the best combination of inflow and cutoff criteria (time or distance) for level-basin, sloping-border or furrow irrigated fields.")

    Public tFurrowDesign As TString = New TString("Furrow Design")
    Public tFurrowOperations As TString = New TString("Furrow Operations")

    Public tBasinBorderDesign As TString = New TString("Basin / Border Design")
    Public tBasinBorderOperations As TString = New TString("Basin / Border Operations")

    Public tSrfrSimulations As TString = New TString("SRFR Simulations")
    Public tVBandSrfrSims As TString = New TString("VB and SRFR Sims")

    Public tEstimationSucceeded As TString = New TString("Estimation of Tuning Factors succeeded")
    Public tEstimationFailed As TString = New TString("Estimation of Tuning Factors failed")

    Public tLengthWidthTradeoffs As TString = New TString("Length vs. Width Tradeoffs")
    Public tLengthInflowRateTradeoffs As TString = New TString("Length vs. Inflow Rate Tradeoffs")
    Public tInflowRateCutoffTradeoffs As TString = New TString("Inflow Rate vs. Cutoff Tradeoffs")
    Public tFurrowsPerSetCutoffTradeoffs As TString = New TString("Furrows Per Set vs. Cutoff Tradeoffs")

    Public tMinimumDepth As TString = New TString("Minimum Depth")
    Public tLowQuarterDepth As TString = New TString("Low-Quarter Depth")
    Public tRequiredDepth As TString = New TString("Required Depth")

    Public tRelativeCutoffDistTime As TString = New TString("Relative Cutoff; distance (<1.0) or time (>1.0)")

    'Public tDesignGivenBorderInflowRate As TString = New TString("Develop Performance Contours as a function of Length and Border Width for a given Inflow &Rate")
    'Public tDesignGivenBorderWidth As TString = New TString("Develop Performance Contours as a function of Length and Inflow Rate for a given Border &Width")
    'Public tDesignGivenFurrowSetInflowRate As TString = New TString("Develop Performance Contours as a function of Length and Furrow set Width for a given Inflow &Rate")
    'Public tDesignGivenFurrowSetWidth As TString = New TString("Develop Performance Contours as a function of Length and Inflow Rate for a given Furrow set &Width")

    Public tDesignBorderHelpLengthWidth As TString = New TString("This design option produces a series of design contours showing the tradeoffs between length and width for a border field")
    Public tDesignBorderHelpLengthInflowRate As TString = New TString("This design option produces a series of design contours showing the tradeoffs between length and inflow rate for a border field")

    Public tDesignFurrowHelpLengthWidth As TString = New TString("This design option produces a series of design contours showing the tradeoffs between length and width for a furrow set")
    Public tDesignFurrowHelpLengthInflowRate As TString = New TString("This design option produces a series of design contours showing the tradeoffs between length and inflow rate for a furrow set")

    Public tOperationsBorderInflowRateCutoff As TString = New TString("This option produces a series of contours showing the tradeoffs between inflow rate and cutoff for a border field")
    Public tOperationsFurrowInflowRateCutoff As TString = New TString("This option produces a series of contours showing the tradeoffs between inflow rate and cutoff for a furrow set")
    Public tOperationsFurrowsPerSetCutoff As TString = New TString("This option produces a series of contours showing the tradeoffs between furrows per set and cutoff")

    'Public tOperationsGivenBorderWidth As TString = New TString("Inflow Rate and Cutoff time for the known Border &Width")
    'Public tOperationsGivenFurrowsPerSet As TString = New TString("Inflow Rate and Cutoff time for the known Furrow Set &Width")
    'Public tOperationsGivenInflowRate As TString = New TString("Furrow per Set and Cutoff Time for the known Inflow &Rate")

    Public tValuesWinSrfrWillCalculate As TString = New TString("Values WinSRFR will calculate")
    Public tValuesYouWillEnter As TString = New TString("Values you will enter")

    Public tOverlay As TString = New TString("Overlay")
    Public tContourOverlay As TString = New TString("Contour Overlay")
    Public tRangesLengthWidth As TString = New TString("Ranges for Length & Width")
    Public tRangesLengthInflowRate As TString = New TString("Ranges for Length & Inflow Rate")
    Public tRangesInflowRateCutoffTime As TString = New TString("Ranges for Inflow Rate & Cutoff Time")
    Public tRangesFurrowsPerSetCutoffTime As TString = New TString("Ranges for Furrows Per Set & Cutoff Time")
    Public tRangesInflowRateCutoffLocation As TString = New TString("Ranges for Inflow Rate & Cutoff Location")
    Public tRangesFurrowsPerSetCutoffLocation As TString = New TString("Ranges for Furrows per Set & Cutoff Location")

    Public tLengthWidthContours As TString = New TString("Length vs. Width contours")
    Public tLengthInflowRateContours As TString = New TString("Length vs. Inflow Rate contours")
    Public tInflowRateCutoffTimeContours As TString = New TString("Inflow Rate vs. Cutoff Time contours")
    Public tFurrowsPerSetCutoffTimeContours As TString = New TString("Furrows Per Set vs. Cutoff Time contours")
    Public tInflowRateCutoffLocationContours As TString = New TString("Inflow Rate vs. Cutoff Location contours")
    Public tFurrowsPerSetCutoffLocationContours As TString = New TString("Furrows Per Set vs. Cutoff Location contours")

    Public tTuningFactors As TString = New TString("Tuning Factors")
    Public tTuningError As TString = New TString("Tuning Error")
    Public tTuningFactorsCalculationFailed As TString = New TString("The Tuning Factors calculation for the selected Contour Point failed")
    Public tTuningFactorsSensitiveToPoint As TString = New TString("The Tuning Factors may be sensitive to the selected Tuning Point.")
    Public tCalibrationPoint As TString = New TString("Calibration Point")
    Public tUpstreamDepthAtCalibrationPoint As TString = New TString("Upstream Depth at Calibration Point")
    Public tAlternatePoint As TString = New TString("Alternate Point")
    Public tOriginalPoint As TString = New TString("Original Point")
    Public tSelectContourPoint As TString = New TString("Select a point within the contours so a Water Distribution Diagram and a set of Performance Parameters can be added to the Results")

    Public tAdvancePowerLawCouldNotBeCalculated As TString = New TString("The advance power law 'r' could not be calculated")
    Public tAdvancePowerLawLessThan As TString = New TString("The advance power law exponent r for the Tuning Point is less than")
    Public tYouCanContinueAnalysis As TString = New TString("You can continue the analysis using this Tuning Point,")
    Public tRecommendAlternativePoints As TString = New TString("but recommend that you test alternative points (see User Manual)")
    Public tTuningFactorsCalculationPhi0Failed As TString = New TString("The Tuning Factors calculation for Phi 0 failed")
    Public tTuningFactorsCalculationPhi1Failed As TString = New TString("The Tuning Factors calculation for Phi 1 failed")
    Public tSimulationFailedAtTuningPoint As TString = New TString("The irrigation Simulation at the Tuning Point failed")
    Public tSelectedTuningPointOutsideLimitLine As TString = New TString("The selected Tuning Point is outside of or too close to the Limit Line or has a PAEmin value that is too low")
    Public tAdvanceDidNotReachEndOfField As TString = New TString("Advance did not reach the end of the field")
    Public tCannotBeMatchedToSimulation As TString = New TString("Advance cannot be matched to simulation")
    Public tToCorrectErrorDo As TString = New TString("To correct the error, do one or more of the following:")
    Public tTryOneOrMore As TString = New TString("Try one or more of the following")
    Public tDecreaseInflowRate As TString = New TString("Decrease the Inflow Rate")
    Public tIncreaseInflowRate As TString = New TString("Increase the Inflow Rate")
    Public tDecreaseCutoffTime As TString = New TString("Decrease the Cutoff Time")
    Public tIncreaseCutoffTime As TString = New TString("Increase the Cutoff Time")
    Public tDecreaseLength As TString = New TString("Decrease the Length")
    Public tDecreaseWidth As TString = New TString("Decrease the Width")
    Public tSelectMoreAppropriateTuningPoint As TString = New TString("Select a more appropriate Tuning Point")
    Public tSelectPointWithlargerAppliedDepth As TString = New TString("Select a Tuning Point that will results in a larger applied depth")
    Public tDappLessThanDreq As TString = New TString("The applied depth is less than the required depth with the suggested tuning point")
    Public tTuningPointSuggested As TString = New TString("The following point is suggested as an alternative Tuning Point:")
    Public tPressYesToRetryAtSuggestedPoint As TString = New TString("Press 'Yes' to retry at the suggested point")
    Public tPressNoKeepCurrentPoint As TString = New TString("Press 'No' to keep the current point")
    Public tAdditionalErrorMessagesMayFollow As TString = New TString("Additional error messages may follow")
    Public tDistributionOfInfiltratedDepths As TString = New TString("Distribution of Infiltrated Depths")

    Public tEstimatingPhi0 As TString = New TString("Estimating Phi 0")
    Public tEstimatingPhi1 As TString = New TString("Estimating Phi 1")
    Public tEstimatingPhi2 As TString = New TString("Estimating Phi 2")
    Public tEstimatingPhi3 As TString = New TString("Estimating Phi 3")

    Public tCalculatingMajorContours As TString = New TString("Calculating major contours")
    Public tCalculatingMinorContours As TString = New TString("Calculating minor contours")
    Public tBuildingContourGrid As TString = New TString("Building contour grid")
    Public tRefiningContourGrid As TString = New TString("Refining contour grid")
    Public tCalculatingValueCurve As TString = New TString("Calculating value curve")
    Public tStartingCalculations As TString = New TString("Starting Calculations")
    Public tChooseSolutionAtPoint As TString = New TString("Choose Solution at this point")

    Public tAndOtherParameters As TString = New TString("and other parameters")

    Public tOverflowYaxGtDmax As TString = New TString("Overflow: Ymax > Maximum Depth")
    Public tOverflowYaxNearDmax As TString = New TString("Ymax near Maximum Depth")

    Public tContourOverflow As TString = New TString("Contour Range produces overflow conditions")
    Public tContourOverflowPart1 As TString = New TString("Contour computations have stopped due to overflow conditions under the specified range of operational variables.")
    Public tContourOverflowPart2 As TString = New TString("Performance results are invalid in the overflow region.")
    Public tContourOverflowPart3 As TString = New TString("Resolve this problem by specifying an artificial (larger) Maximum Depth value (System Geometry Tab).")
    Public tContourOverflowPart4 As TString = New TString("For any selected Solution Point, verify that Ymax does not exceed the desired Maximum Depth value (see the value reported in the Solution Tab or conduct an unsteady simulation).")

#End Region

#Region " Event Analysis World "

    Public tEventWorldUsage As TString = New TString("This world evaluates the performance of irrigation events from field measured data and estimates infiltration parameters needed for evaluation and simulation.")

    Public tDataTabs As TString = New TString("Data Tabs...")
    Public tAnalysisTabs As TString = New TString("Analysis Tabs...")

    Public tInflowRequired As TString = New TString("Inflow is required for all Irrigation Event Analyses")
    Public tRunoffRequired As TString = New TString("Runoff data is needed to compute a post-irrigation volume balance when the system is free-draining.")
    Public tAdvanceRequired As TString = New TString("Advance is required for this Event Analysis")
    Public tRecessionRequired As TString = New TString("Recession is required for this Event Analysis")
    Public tFlowDepthsRequired As TString = New TString("Flow Depths are required for this Event Analysis")

    Public tRecessionUseful As TString = New TString("Recession is useful for volume balance calculations")
    Public tFlowDepthsUseful As TString = New TString("Flow Depths are useful for surface flow calculations")
    '
    ' Evaluation Phrases
    '
    Public tEvent As TString = New TString("Event")
    Public tEvaluation As TString = New TString("Evaluation")
    Public tEventAnalysis As TString = New TString("Event Analysis")

    Public tPowerAdvanceLaw As TString = New TString("Calculations used Advance Power Law")
    Public tPowerRgt1 As TString = New TString("The value for the power law exponent (r) is 1.0 or greater.")
    Public tRInstruct As TString = New TString("A value less than 1.0 is required.  Try fitting the advance data with a smaller value of r by trial-and-error.")

    Public tFlowDepths As TString = New TString("Flow Depths")
    Public tFlowDepthsStation As TString = New TString("Flow Depths for Station at")
    Public tProbeMeasurement As TString = New TString("Probe Measurement")
    Public tRecessionInterpolated As TString = New TString("Recession Interpolated")
    Public tOpportunityTime As TString = New TString("Opportunity Time")
    Public tAverageOpportunityTime As TString = New TString("Average Opportunity Time")
    Public tAverageOpportunityTimes As TString = New TString("Average Opportunity Times")
    Public tAverageInfiltration As TString = New TString("Average Infiltration")
    Public tAverageInfiltratedDepths As TString = New TString("Average Infiltrated Depths")
    Public tRunoffDepths As TString = New TString("Runoff Depths")

    Public tTwoPointAdvance As TString = New TString("Two-Point Advance")
    Public tTwoPointAnalysis As TString = New TString("Two-Point Analysis")
    Public tTwoPointData As TString = New TString("Two-Point Data")
    Public tTwoPointInfiltInstruc1 As TString = New TString("Enter b and then press the Estimate button to estimate the a and k infiltration parameters.")
    Public tTwoPointInfiltInstruc2 As TString = New TString("Note: b is estimated from runoff data as Qin-Qro*0.5/Area.")

    Public tMkInfiltInstruct1 As TString = New TString("Select an infiltration equation and a wetted perimeter option (if provided).  Enter values for the free parameters.  Press the Accept button to calculate the unknown parameter(s).")
    Public tMkInfiltInstruct2 As TString = New TString("The resulting parameters will match the final infiltration volume, calculated from the measured opportunity times, to the value from the field measured volume balance.  Use the Verify tab to examine the goodness-of-fit of your estimated function.")

    Public tVbGraphNotes As TString = New TString("Volume balance calculation times are shown with blue lines.")

    Public tVerifyNotes As TString = New TString("Press the verify button to conduct an unsteady flow simulation with the estimated infiltration function.")

    Public tEvalueMaxTime As TString = New TString("The maximum time for Volume Balance calculations is:  ")

    Public tSummarizeAnalysis As TString = New TString("Summarize Analysis")
    Public tVerifySummarizeAnalysis As TString = New TString("Verify and Summarize Analysis")
    Public tEstimatedParameters As TString = New TString("Estimated Parameters")

    Public tSelectUpdateShapeFactors As TString = New TString("Select 'Update Shape Factors' to run a simulation to update the Sigma Y and Sigma Z shape factors which affect the calculation of the Volume Balance and Predicted infiltration respectively.")
    Public tShapeFactors As TString = New TString("Shape Factors")
    Public tNewShapeFactorsCalculated As TString = New TString("New Shape Factors have been calculated")
    Public tSeeSurfaceVolumesTab As TString = New TString("See Surface Volumes tab")

    Public tInfiltratedProfileAnalysis As TString = New TString("Infiltrated Profile Analysis")
    Public tErosionParameterEstimation As TString = New TString("Erosion Parameter Estimation")
    Public tSummaryMeasuredInflow As TString = New TString("Summary of measured inflow")
    Public tSummaryMeasuredInflowRunoff As TString = New TString("Summary of measured inflow & runoff")

    Public tEvalInfiltratedProfile As TString = New TString("Analysis uses water penetration measurements to determine the depth of water infiltrated in the root zone and requires no estimate of infiltration parameters.")
    Public tEvalMerriamKellerDescr As TString = New TString("Estimation of infiltration parameters from a post-irrigation volume balance. The infiltration function is user selected.  Inflow and runoff measurements are needed to calculate the final volume balance. Advance and recession measurements are needed to calculated intake opportunity times along the field.")
    Public tEvalMerriamKellerNotes As TString = New TString("Note: The Evalue analysis option can enhance the analysis of data collected for the Merriam-Keller method.")
    Public tEvalTwoPointDescr As TString = New TString("Estimation of the k and b parameters of the Extended Kostiakov infiltration equation (z = kt^a+bt) from two advance time measurements. The b parameter must be user entered or estimated from runoff measurements.")
    Public tEvalTwoPointNotes As TString = New TString("Note: If the available data can be used to compute the final volume balance and for post-advance verification, then run the analysis using EVALUE instead of the Two-point method.")
    Public tEvalErosionParams As TString = New TString("Analysis uses field geometry, soil / crop properties, inflow & erosion measurements to estimate the erosion parameters KR, TauC & Beta")
    Public tEvalEvalueDescr As TString = New TString("Estimation of infiltration and hydraulic resistance parameters from irrigation evaluation data.  The analysis depends on the available data.")
    Public tEvalFurrowSpacingDependent As TString = New TString("The values of the parameters depend on the given furrow spacing.")

    Public tMeasurementStations As TString = New TString("Measurement Stations")
    Public tSelectMeasurementStations As TString = New TString("Select Measurement Stations")
    Public tEditMeasurmentStations As TString = New TString("Press to edit the Measurement Stations list")

    Public tStationsTableInstructions As TString = New TString("Table displays the location and elevation of each station where flow depths were measured.")
    Public tEditStationsInstructions1 As TString = New TString("Use the Elevation Profiles view to adjust the elevation at the measurement stations.")
    Public tEditStationsInstructions2 As TString = New TString("Adjusting the elevations here will modify the elevations entered in the System Geometry tab.")
    Public tEnterFlowDepthsInstructions As TString = New TString("Tables are used to enter the flow depths measured at each station. The table displayed is controlled by the selected station in the Measurement Stations table.")
    Public tEvalueInfiltrationInstructions As TString = New TString("Adjust the parameters of the selected infiltration function to match the predicted infiltration to the values derived from volume balance.")
    Public tEvalueRoughnessFlowDepthsInstructions As TString = New TString("Roughness is estimated by fitting predicted flow depths to measured flow depths. The measured values are derived from station measurements.  The predicted values are from a simulation run with the user-selected roughness function.  Adjust the roughness parameter(s) while comparing results.")
    Public tEvalueRoughnessFlowDepthsInstructionsNoSim As TString = New TString("Enter an estimate for the resistance parameter. Then select 'Compare Depth Hydrographs' to generate goodness-of-fit values.")
    Public tEvalueRoughnessFlowDepthsInstructionsWithSim As TString = New TString("Adjust the hydraulic resistance parameter to better match predicted and observed flow depths.")
    Public tEvalueRoughnessNashSutcliffe As TString = New TString("Use the Nash-Sutcliffe efficiency graph to judge goodness-of-fit.")
    Public tEvalueRoughnessPercentBias As TString = New TString("Use the Percent Bias efficiency graph to judge goodness-of-fit.")

    Public tEvalueMassBalancesInstructions As TString = New TString("The Mass Balances table should contain the advance times to each measurement station and additional times to adequately represent the post-advance irrigation phase.")
    Public tEvalueSuggestTimes As TString = New TString("Suggest Times")
    Public tShowEstimatedVolumeBalanceCalculations As TString = New TString("Show Estimated Volume Balance Calculations")
    Public tShowMeasuredVolumeBalanceCalculations As TString = New TString("Show Measured Volume Balance Calculations")
    Public tVolumeBalanceData As TString = New TString("These irrigation measurements will be used for calculating volume balances")
    Public tSurfaceVolumeDescr As TString = New TString("Surface volume estimates depend on the assumed value for the hydraulic resistance parameter and the computed surface shape factors.")
    Public tImproveSyInstructions As TString = New TString("Procedures for improving the surface volume estimates are described in the User Manual.")

    Public tInflowInstructions As TString = New TString("Define as a Standard Hydrograph or a table of time vs. discharge values.")
    Public tNoInflowSpecified As TString = New TString("No inflow has been specified; analysis cannot continue.")
    Public tFinalInflowVolumeNotAvailable As TString = New TString("The final inflow volume required by the Merriam-Keller method cannot be calculated.")
    Public tInflowRunoffInstruct1 As TString = New TString("Use the Partial Hydrograph checkbox if the data is incomplete and final volumes cannot be computed from the given data.")
    Public tInflowRunoffInstruct2 As TString = New TString("Efficiency and uniformity will be predicted only if the final inflow volume can be computed.")
    Public tInflowRunoffInstruct3 As TString = New TString("The final field measured volume balance will be calculated only if both final inflow and runoff volume can be computed.")
    Public tFinalInfiltrationNotAvailable As TString = New TString("Final infiltration cannot be calculated unless both the final inflow and outflow (if applicable) volumes can be computed.")

    Public tRunoffInstructions As TString = New TString("Define as a table of time vs. discharge values.")
    Public tNoRunoffVolumeSpecified As TString = New TString("No Runoff volume has been specified.")
    Public tFinalRunoffVolumeNotAvailable As TString = New TString("The final outflow volume required by the Merriam-Keller method cannot be calculated.")

    Public tSingleAdvanceMeasurement As TString = New TString("Analysis is based on a single advance measurement and assumes an advance power law exponent")
    Public tTestAlternativeValuesOfR As TString = New TString("Test alternative values of r.")

    Public tCannotPredictParameters As TString = New TString("The verification cannot predict final efficiency and uniformity because the inflow is specified using a partial hydrograph. The final inflow volume cannot be computed from the given data.")
    Public tCannotComputeVolumeBalance As TString = New TString("The verification cannot compute a final field-measured volume balance because inflow and/or runoff are not specified or are specified using a partial hydrograph.  The final inflow and/or outflow volumes cannot be computed from the given data.")

    Public tPowerAdvanceExponentGt1ID As TString = New TString("Power Advance Exponent is greater than 1.0")
    Public tPowerAdvanceExponentGt1Detail As TString = New TString("The computed Power Advance Exponent is greater than 1.0 and violates the assumption of a monotonically decreasing advance rate with time.  Either the Two-Point Advance Distances are too far apart or the Times are too close.")
    Public tVolumeRatioPt2GtPt1ID As TString = New TString("Volume ratio (Vy/Vin) at Point 2 is greater than at Point 1")
    Public tVolumeRatioPt2GtPt1Detail As TString = New TString("With the given data, the ratio Vy/Vin (Surface Volume / Inflow Volume) increases with time and violates the assumption of a monotonically decreasing infiltration rate with time.")
    Public tSubsurfaceShapeFactorGt1ID As TString = New TString("Subsurface Shape Factor is greater than 1.0")
    Public tSubsurfaceShapeFactorGt1Detail As TString = New TString("The computed Subsurface Shape Factor is greater than 1.0.")

    Public tAdvanceInstructions As TString = New TString("Define as a table of distance vs time values.")
    Public t2PointAdvInstructions As TString = New TString("Specify with two distance-advance time values.")
    Public tAdvanceTableGraphedAsPoints As TString = New TString("The Advance Table measurements are drawn as circles in the graph.")
    Public tPowerLawAdvanceGraphedAsCurve As TString = New TString("The Advance Power-Law relationship is the curve.")

    Public tRecessionInstructions As TString = New TString("Define as a table of distance vs. time values.")
    Public tRecessionNotes1 As TString = New TString("Note: missing recession times will be interpolated for the given advance stations.")
    Public tRecessionNotes2 As TString = New TString("Note: analysis expects advance and recession times to be measured at the same distances.")

    Public tFlowDepthsVolumeBalance As TString = New TString("Flow Depths will be used for calculating volume balances.")
    Public tFlowDepthsNotAvailable As TString = New TString("The flow depth data required to display the predicted infiltration is not available.")
    Public tUseStdToRecalculate As TString = New TString("Use the saved Standard Infiltration Function parameters to recalculate this analysis.")
    Public tNoPredictedInfiltration As TString = New TString("Predicted infiltration is not available")
    Public tSeeWarningBelow As TString = New TString("See warning below")

    Public tStationInstructions As TString = New TString("If station data will be entered, advance / recession measurements can also be entered at that point.")

    Public tSystemGeometryData As TString = New TString("System Geometry data")
    Public tSoilCropData As TString = New TString("Soil / Crop Properties data")
    Public tInflowData As TString = New TString("Inflow hydrograph")
    Public tInflowRunoffData As TString = New TString("Inflow & Runoff hydrographs")
    Public tFlowDepthsData As TString = New TString("Flow Depth hydrographs")
    Public tPostIrrigationProbedInfiltratedDepths As TString = New TString("Post-Irrigation probed infiltrated depths")
    Public tSoilsWaterHoldingCapacity As TString = New TString("Soil's water holding capacity")
    Public tPreIrrigationMeasurements As TString = New TString("Pre-Irrigation measurements")
    Public tPostIrrigationMeasurements As TString = New TString("Post-Irrigation measurements")
    Public tPlotRootZoneInfiltratedDepth As TString = New TString("Plot of root-zone infiltrated depth")
    Public tLocationAndElevation As TString = New TString("Location & Elevation")
    Public tSummaryMeasuredAdvanceRecession As TString = New TString("Summary of measured advance & recession")
    Public tSedimentComponentMeasurements As TString = New TString("Sediment Component measurements")
    Public tErosionMeasurements As TString = New TString("Erosion measurements")
    Public tSummaryErosionParameterEstimation As TString = New TString("Summary of erosion parameter estimation")

    Public tLowQuarterAverageDepth As TString = New TString("Low-Quarter Average Depth")
    Public tLowQuarterAdequacy As TString = New TString("Low-Quarter Adequacy")
    Public tApplicationEfficiency As TString = New TString("Application Efficiency")
    Public tDeepPerc As TString = New TString("Deep Perc")
    Public tDeepPercolation As TString = New TString("Deep Percolation")
    Public tAreaUnderIrrigated As TString = New TString("Area Under Irrigated")
    Public tDuMinimum As TString = New TString("DU Minimum")
    Public tDuLowQuarter As TString = New TString("DU Low-Quarter")

    Public tAverageDepth As TString = New TString("Average Depth")
    Public tAverageDepthSimulation As TString = New TString("Average Depth from Simulation")
    Public tAverageDepthMeasurements As TString = New TString("Average Depth from Measurements")
    Public tAverageDepthsFinalMassBalance As TString = New TString("Average Depths from Final Mass Balance (Inflow - Runoff)")
    Public tAppliedDepth As TString = New TString("Applied Depth")
    Public tRunoffDepth As TString = New TString("Runoff Depth")
    Public tAppliedMass As TString = New TString("Applied Mass")
    Public tAppliedVolume As TString = New TString("Applied Volume")
    Public tAppliedWater As TString = New TString("Applied Water")
    Public tRunoffVolume As TString = New TString("Runoff Volume")
    Public tInfiltratedDepth As TString = New TString("Infiltrated Depth")
    Public tInfiltratedDepths As TString = New TString("Infiltrated Depths")
    Public tInfiltratedVolume As TString = New TString("Infiltrated Volume")
    Public tInfiltratedVolumes As TString = New TString("Infiltrated Volumes")
    Public tRunoffDataIsNotAvailable As TString = New TString("Runoff data is not available")
    Public tRunoffDataNotBeenEntered As TString = New TString("Runoff data has not been entered")
    Public tValueCannotBeCalculated As TString = New TString("Value cannot be calculated")
    Public tDepthApplied As TString = New TString("Depth Applied")
    Public tDepthInfiltrated As TString = New TString("Depth Infiltrated")
    Public tSumOfSquares As TString = New TString("Sum-of-Squares")

    Public tFinalAppliedDepth As TString = New TString("Final Applied Depth")
    Public tFinalRunoffDepth As TString = New TString("Final Runoff Depth")
    Public tFinalInfiltratedDepth As TString = New TString("Final Infiltrated Depth")

    Public tMeasuredOrFinalAppliedDepth As TString = New TString("(Meas. or Final) Applied Depth")
    Public tMeasuredOrFinalRunoffDepth As TString = New TString("(Meas. or Final) Runoff Depth")

    Public tAverageCalculatedInfiltratedDepths As TString = New TString("Average Calculated Infiltrated Depths")
    Public tUseful As TString = New TString("Useful")
    Public tUsefulDepth As TString = New TString("Useful Depth")
    Public tUsefulInfiltratedDepth As TString = New TString("Useful Infiltrated Depth")

    Public tAdvanceTimes As TString = New TString("Advance Times")
    Public tAdvanceRecessionTimes As TString = New TString("Advance & Recession times")
    Public tAnalysisWoInflow As TString = New TString("Analysis cannot be run without Inflow specified")
    Public tRecessionTimes As TString = New TString("Recession Times")
    Public tRootMeanSquareError As TString = New TString("Root Mean Square Error")
    Public tAdvanceTimeEndOfField As TString = New TString("Advance Time to End of Field")
    Public tMaximumRecessionTime As TString = New TString("Maximum Recession Time")
    Public tMeasured As TString = New TString("Measured")
    Public tMeasuredInfiltration As TString = New TString("Measured Infiltration")
    Public tPredicted As TString = New TString("Predicted")
    Public tPredictedInfiltration As TString = New TString("Predicted Infiltration")
    Public tCoefficientOfDetermination As TString = New TString("Coefficient of Determination")
    Public tNashSutcliffeEfficiency As TString = New TString("Nash-Sutcliffe Efficiency")
    Public tVolumeBalanceError As TString = New TString("Volume Balance Error")
    Public tVolumeBalanceWoRunoff As TString = New TString("Without runoff data, volume balances can only be calculated during the advance phase of the irrigation.")
    Public tRelativeToAppliedDepth As TString = New TString("Relative to Applied Depth")
    Public tCalculatedBasedOnTimeAdjustedRunoffValues As TString = New TString("Calculated based on time-adjusted runoff values")
    Public tSimulatedAdvance As TString = New TString("Simulated Advance")
    Public tSimulatedRecession As TString = New TString("Simulated Recession")
    Public tSimulatedOpportunityTime As TString = New TString("Simulated Opportunity Time")
    Public tSimulatedDepth As TString = New TString("Simulated Depth")
    Public tSimulatedRunoff As TString = New TString("Simulated Runoff")
    Public tSimulatedAdvanceDidNotReachEndOfField As TString = New TString("Simulated Advance did not reach the end of the field")
    Public tSoilWaterDepletionTable As TString = New TString("Soil Water Depletion Table")
    Public tRootZone As TString = New TString("Root Zone")
    Public tRootZoneDepth As TString = New TString("Root Zone Depth")
    Public tRootZoneInfiltratedDepth As TString = New TString("Root Zone Infiltrated Depth")
    Public tParameters As TString = New TString("Parameter(s)")
    Public tProbeLength As TString = New TString("Probe Length")
    Public tIrrigationRequirements As TString = New TString("Irrigation Requirements")
    Public tSoilWaterDeficit As TString = New TString("Soil Water Deficit")
    Public tPreIrrigationSoilWaterDeficit As TString = New TString("Pre-Irrigation soil water deficit")
    Public tLeaching As TString = New TString("Leaching")
    Public tLeachingDepth As TString = New TString("Leaching Depth")
    Public tLeachingRequirement As TString = New TString("Leaching Requirement")
    Public tIrrigationTargetDepth As TString = New TString("Irrigation Target Depth")
    Public tProbedInfiltratedDepthsTable As TString = New TString("Probed Infiltrated Depths Table")
    Public tProbedDepth As TString = New TString("Probed Depth")
    Public tAverageProbedInfiltratedDepths As TString = New TString("Average Probed Infiltrated Depths")
    Public tDeepPercolationEqualsInfiltratedDepthMinusUsefulDepth As TString = New TString("Deep Percolation = Infiltrated Depth (Mass Balance) - Useful Depth")
    Public tDeepPercolationCalculatedFromProbeReadings As TString = New TString("Deep Percolation calculated from probe readings")
    Public tVolume As TString = New TString("Volume")
    Public tVolumeBalance As TString = New TString("Volume Balance")
    Public tVolumeBalances As TString = New TString("Volume Balances")
    Public tVolumeBalancesEstimated As TString = New TString("Volume Balance (Estimated)")
    Public tVolumeBalancesMeasured As TString = New TString("Volume Balance (Measured)")
    Public tVolumeBalancesSimulated As TString = New TString("Volume Balance (Simulated)")
    Public tEstimatedSurfaceVolumes As TString = New TString("Estimated Surface Volumes")
    Public tMeasuredSurfaceVolumes As TString = New TString("Measured Surface Volumes")
    Public tVolumeBalanceInfiltration As TString = New TString("Volume Balance Infiltration")

    Public tRefineSyNote1 As TString = New TString("This procedure assumes you have completed the estimation of the Infiltration parameters.")
    Public tRefineSyNote2 As TString = New TString("Continue with this procedure?")

    Public tElliotWalkerTwoPointAnalysis As TString = New TString("Elliott-Walker Two-Point Analysis")
    Public tGoodnessOfFitMeasures As TString = New TString("Goodness-of-Fit Measures")
    Public tGoodnessOfFitMeasuresEstimatedParameters As TString = New TString("Goodness-of-Fit Measures for Estimated Infiltration Parameters")

    Public tEstimationInstructions As TString = New TString("Estimation Instructions")

    Public tUsesRUWP As TString = New TString("Uses Representative Upstream Wetted Perimeter")

    Public tSetToDefault As TString = New TString("Set to default")
    Public tSetByEvent As TString = New TString("Set by Event Analysis")
    Public tSetByUser As TString = New TString("Set by User")

    Public tCalculatedParameters As TString = New TString("Calculated Parameters")
    Public tEstimatesForKostiakovKAB As TString = New TString("Estimates for Kostiakov k, a & b")

#End Region

#Region " Results "

    ' Results availability
    Public tResults As TString = New TString("Results")
    Public tNoResults As TString = New TString("No Results")
    Public tResultsAreAvailable As TString = New TString("Results are available")
    Public tNoResultsAreAvailable As TString = New TString("No Results are available")
    Public tAnalysisHasNotBeenRun As TString = New TString("The Analysis or Simulation has not yet been run")
    Public tSelectYourCriteria As TString = New TString("Select your Criteria")
    Public tEnterValuesForAnalysis As TString = New TString("Enter the values for your Analysis or Simulation")
    Public tPressRunButton As TString = New TString("Press the Run button on the Execution tab")
    Public tSelectRunMenuItem As TString = New TString("Select the Run menu item")
    Public tAnalysisHasBeenRunBut As TString = New TString("The Analysis or Simulation has been run BUT you have changed one or more data values so the Analysis or Simulation must be re-run to maintain consistent results")
    Public tUseUndoToGoBack As TString = New TString("Use Undo to go back to the previous results")

    ' Page / graph / section titles
    Public tHydraulicSummary As TString = New TString("Hydraulic Summary")
    Public tInputSummary As TString = New TString("Input Summary")
    Public tHydrographs As TString = New TString("Hydrographs")
    Public tProfiles As TString = New TString("Profiles")

    Public tErosion As TString = New TString("Erosion")
    Public tErosionSoilMovement As TString = New TString("Soil movement down / off field")
    Public tMassConcentration As TString = New TString("Mass Concentration")
    Public tMassTransport As TString = New TString("Mass Transport")
    Public tParametersGoodnessOfFit As TString = New TString("Parameters & Goodness of Fit")
    Public tPerformanceAnalysis As TString = New TString("Performance Analysis")
    Public tPerformanceSummary As TString = New TString("Performance Summary")

    Public tFertigation As TString = New TString("Fertigation")
    Public tFertigationOptions As TString = New TString("Fertigation Options")
    Public tFertigationInputParameters As TString = New TString("Fertigation Input Parameters")
    Public tFertigationResults As TString = New TString("Fertigation Results")
    Public tFertigationInjectionPoint As TString = New TString("Injection Point")
    Public tFertigationInjectionTable As TString = New TString("Injection Table")
    Public tFertigationDulq As TString = New TString("Solute Distribution Uniformity")
    Public tDispersionCalculationsFormula As TString = New TString("Dispersion Calculation Formula")
    Public tWaterDistribution As TString = New TString("Water Distribution")

    Public tCharacteristicsNet As TString = New TString("Characteristics Net")
    Public tSurfaceFlowSummary As TString = New TString("Surface Flow Summary")
    Public tApplicationDensity As TString = New TString("Application Density")
    Public tConcentration As TString = New TString("Concentration")
    Public tEfficiencyUniformityIndicators As TString = New TString("Efficiency & Uniformity Indicators")
    Public tSimulationPerformanceIndicators As TString = New TString("Performance Indicators (from Simulation)")
    Public tVolumeBalanceCannotBeCalculated As TString = New TString("Volume balance cannot be calculated from the available data.")

    ' Misc.
    Public tCopyableBitmapGraphResults As TString = New TString("Copyable bitmap of graph results")
    Public tPrintablePageResults As TString = New TString("Printable page of results")
    Public tRunAnalysisToGenerateResults As TString = New TString("Run Analysis to generate Results")
    Public tPrintSelection As TString = New TString("Print Selection")
    Public tEnterPageSelection As TString = New TString("Enter selection of pages")
    Public tErrorPageSelection As TString = New TString("Error in page selection")
    Public tExample As TString = New TString("Example")

    Public tUnableToCompleteGraph As TString = New TString("Unable to complete graph")
    Public tViewUsingResultsTab As TString = New TString("View using Results tab")
    Public tInflowNotCompletelySpecified As TString = New TString("Inflow has not been completely specified.")
    Public tPage As TString = New TString("Page")
    Public tOf As TString = New TString("of")

#End Region

#Region " Undo / Redo "
    '
    ' Undo / Redo Phrases
    '
    Public tUndo As TString = New TString("Undo")
    Public tRedo As TString = New TString("Redo")
    Public tComputeTauCBeta As TString = New TString("Compute TauC && Beta")
    Public tCrossSectionChange As TString = New TString("Cross Section Change")
    Public tElevationTableChange As TString = New TString("Elevation Table Change")
    Public tDesignOptionChange As TString = New TString("Design Option Change")
    Public tEvaluatorChange As TString = New TString("Evaluator Change")
    Public tHydrusProjectChange As TString = New TString("HYDRUS Project Change")
    Public tOperationsOptionChange As TString = New TString("Operations Option Change")
    Public tEstimateTuningFactors As TString = New TString("Estimate Tuning Factors")
    Public tNameChange As TString = New TString("Name Change")
    Public tNotesChange As TString = New TString("Notes Change")
    Public tNrcsOptionChange As TString = New TString("NRCS Option Change")
    Public tOwnerChange As TString = New TString("Owner Change")
    Public tResetAdvancePandR As TString = New TString("Reset Advance P & R")
    Public tSelectNrcsFamily As TString = New TString("Select NRCS Intake Family")
    Public tSelectStation As TString = New TString("Select Station")
    Public tSlopeTableChange As TString = New TString("Slope Table Change")
    Public tTabPageSelection As TString = New TString("Tab Page Selection")

#End Region

#Region " Errors / Warnings "
    '
    ' Error / Warning messages
    '
    Public tError As TString = New TString("Error")
    Public tErrors As TString = New TString("Error(s)")
    Public tNoError As TString = New TString("No Error")
    Public tNoErrors As TString = New TString("No Error(s)")
    Public tWarning As TString = New TString("Warning")
    Public tWarnings As TString = New TString("Warning(s)")
    Public tNoWarning As TString = New TString("No Warning")
    Public tNoWarnings As TString = New TString("No Warning(s)")

    Public tErrMessage As TString = New TString("Error Message")
    Public tErrExecution As TString = New TString("Execution errors")
    Public tErrExecutionStoppedDueTo As TString = New TString("Execution stopped due to")
    Public tErrAnalysisVerification As TString = New TString("Analysis Verification Error")

    Public tErrFileIsEmpty As TString = New TString("File is empty")
    Public tErrFirstLineIsBlank As TString = New TString("First line is blank")
    Public tErrReadingFiles As TString = New TString("Error reading file(s)")
    Public tErrOpeningReadingFile As TString = New TString("Error opening or reading file")
    Public tErrOpeningWritingFile As TString = New TString("Error opening or writing file")

    Public tErrCannotUseSameFileForInputOutput As New TString("Cannot use same file for both input & output")

    Public tErrCutbackCantBeTimeBased As TString = New TString("Cutback can't be Time-Based when Cutoff is Distance-Based")
    Public tErrNameChange As TString = New TString("Name Change Error")

    Public tErrOccurredDuringRun As TString = New TString("Error(s) occurred during run")
    Public tErrPowerLawCalculations As TString = New TString("Error during Power Law Calculations")
    Public tErrTrapezoidCalculations As TString = New TString("Error during Trapezoid Calculations")
    Public tErrParametersCannotBeFitted As TString = New TString("The cross-sectional parameters cannot be automatically fitted due to the irregularity of the data")
    Public tErrAdjustParametersManually As TString = New TString("Use the controls to adjust the parameters manually")
    Public tErrProfilometerDataVerification As TString = New TString("Profilometer Data Verification")
    Public tErrProfilometerDepthDataInverted As TString = New TString("The Profilometer Depth data appears to be inverted from the format used by WinSRFR")
    Public tErrContinuingWillInvertDepthData As TString = New TString("Continuing will invert the Depth data")
    Public tErrSimulationFailedDueToData As TString = New TString("The simulation failed due to the irregularity of the data")
    Public tErrPerformanceIndicatorsNotCalculated As TString = New TString("Performance Indicators could not be calculated")

    Public tErrAnalysisFromOlderWinSrfrVersion As TString = New TString("This analysis or simulation is from a older WinSRFR version")
    Public tErrToCorrectlyDisplayComparisonResultsItMustBeRerun As TString = New TString("To correctly display comparison results, it must be re-run")
    Public tRepresentativeLocationSurgeGraph As TString = New TString("Representative Graph for Location-Based Surges")

    Public tWrnIpaRoughnessParametersNotUsed As TString = New TString("Roughness parameters are not used by Infiltrated Profile Analysis")
    Public tWrnIpaInfiltrationParametersNotEstimated As TString = New TString("Infiltration parameters are not estimated by Infiltrated Profile Analysis")
    Public tWrnOverflowCondition As TString = New TString("Simulation under the proposed conditions produced an overflow condition." _
                                              & Chr(10) & "The resulting irrigation performance measures are in error." _
                                              & Chr(10) & "The magnitude of the error cannot be quantified but depends on the severity of the overflow")

    Public tInvalidElevationTableID As TString = New TString("Elevation Table is invalid")
    Public tInvalidElevationTableDetail As TString = New TString("In the Elevation Table, the first Distance must be at the head of the field and the last Distance must be at the end of the field (i.e. = Length)")

    Public tInvalidSlopeTableID As TString = New TString("Slope Table is invalid")
    Public tInvalidSlopeTableDetail As TString = New TString("In the Slope Table, the first Distance must be at the head of the field (i.e. = 0) and the last Distance must be prior to the end of the field (i.e. < Length)")

    Public tInvalidKostiakovAID As TString = New TString("Kostiakov a is invalid")
    Public tInvalidKostiakovADetail As TString = New TString("Kostiakov a is outside its acceptable range for this function")

    Public tInvalidKostiakovBID As TString = New TString("Kostiakov b is invalid")
    Public tInvalidKostiakovBDetail As TString = New TString("Kostiakov b is outside its acceptable range for this function")

    Public tInvalidKostiakovCID As TString = New TString("Kostiakov c is invalid")
    Public tInvalidKostiakovCDetail As TString = New TString("Kostiakov c is outside its acceptable range for this function")

    Public tInvalidBranchBID As TString = New TString("Branch b is invalid")
    Public tInvalidBranchBDetail As TString = New TString("Branch b cannot cause infiltration rate to increase at Branch Time")

    Public tInvalidKostiakovKID As TString = New TString("Kostiakov k is invalid")
    Public tInvalidKostiakovKDetail As TString = New TString("Kostiakov k is outside its acceptable range for this function")

    Public tInvalidRoughnessMethodID As TString = New TString("Roughness Method is invalid")
    Public tInvalidRoughnessMethodDetail As TString = New TString("Roughness Method is not currently supported by this function")
    Public tInvalidManningNID As TString = New TString("Manning N is invalid")
    Public tInvalidManningNDetail As TString = New TString("Manning N a is outside its acceptable range for this function")
    Public tMinLimitManningN As TString = New TString("Manning N limited to its minimum value")
    Public tMaxLimitManningN As TString = New TString("Manning N limited to its maximum value")

    Public tInvalidManningCnID As TString = New TString("Manning Cn is invalid")
    Public tInvalidManningCnDetail As TString = New TString("Manning Cn a is outside its acceptable range for this function")
    Public tInvalidManningAnID As TString = New TString("Manning An is invalid")
    Public tInvalidManningAnDetail As TString = New TString("Manning An a is outside its acceptable range for this function")

    Public tInvalidSayreChiID As TString = New TString("Sayre/Albertson Chi is invalid")
    Public tInvalidSayreChiDetail As TString = New TString("Sayre/Albertson Chi a is outside its acceptable range for this function")
    Public tMinLimitSayreChi As TString = New TString("Sayre/Albertson Chi limited to its minimum value")
    Public tMaxLimitSayreChi As TString = New TString("Sayre/Albertson Chi limited to its maximum value")

    Public tInvalidNrcsManningID As TString = New TString("NRCS / Manning n invalid")
    Public tInvalidNrcsManningDetail As TString = New TString("NRCS infiltration function requires Manning n roughness method")

    Public tInvalidInfiltrationSlopeID As TString = New TString("Invalid Slope for Infiltration Function")
    Public tInvalidInfiltrationSlopeDetail As TString = New TString("Selected Infiiltration Function does not support negative slopes")
    '
    ' Inflow error ID/Detail
    '
    Public tInvalidInflowID As TString = New TString("Inflow is invalid")
    Public tInvalidInflowDetail As TString = New TString("Inflow parameters contain invalid data")

    Public tInvalidStandardHydrographID As TString = New TString("Standard Hydrograph is invalid")
    Public tInvalidStandardHydrographDetail As TString = New TString("Standard Hydrograph contains invalid data")
    Public tInvalidInflowTableID As TString = New TString("Inflow Table is invalid")
    Public tInvalidInflowTableDetail As TString = New TString("Times in the Inflow Table must start at 0 and increase monotonically; Flow Rate values must be positive.")
    Public tInvalidInflowTime0 As TString = New TString("First Inflow Time must be 0")
    Public tInvalidInflowRate0 As TString = New TString("First Inflow Rate must be greater than 0")
    Public tInvalidInflowTimesNotMonotonic As TString = New TString("Inflow Times must increase monotonically")
    Public tInvalidInflowRate As TString = New TString("Inflow rate must be greater than 0")
    Public tInvalidInflowVolume As TString = New TString("Inflow volume must be greater than 0")
    Public tInvalidInflowCutoff As TString = New TString("Cutoff is invalid; Tco must be greater than 0")
    Public tInvalidInflowCutback As TString = New TString("Cutback is invalid; Time & Rate must be greater than 0")
    '
    ' Runoff error ID/Detail
    '
    Public tInvalidRunoffTableID As TString = New TString("Runoff table is expected to be completely specified; should 'Partial Hydrograph' be checked?")
    Public tInvalidRunoffTableDetail As TString = New TString("When Advance reaches the end of an Open-Ended field, there should be Runoff.  Also, the first and last Runoff values must be zero")
    Public tInvalidRunoffStart As TString = New TString("First runoff value should be 0")
    Public tInvalidRunoffAdvance As TString = New TString("The Runoff table and the Advance table are expected to align")
    Public tInvalidRunoffStartTime As TString = New TString("First runoff time should match last Advance time")
    Public tInvalidRunoffEnd As TString = New TString("Last runoff value should be 0")
    Public tInvalidRunoffRecession As TString = New TString("The Runoff table and the Recession table are expected to align")
    Public tInvalidRunoffEndTime As TString = New TString("Last runoff time should match last Recession time")
    Public tInvalidRunoffTime As TString = New TString("Runoff Time cannot be negative")
    Public tInvalidRunoffTimesNotMonotonic As TString = New TString("Runoff Times must increase monotonically")
    Public tInvalidRunoffRate As TString = New TString("Runoff rate must be greater than 0")
    Public tInvalidRunoffVolume As TString = New TString("Runoff volume must be greater than 0")
    Public tInvalidRunoffForVB As TString = New TString("Runoff data is not usable for volume balance calculations.")
    Public tInvalidRunoffUseForVB As TString = New TString("The runoff checkbox 'Use for VB calculations' should be unchecked.")
    '
    ' Advance Profile error ID/Detail
    '
    Public tInvalidAdvanceTableID As TString = New TString("Advance Table is invalid for volume balance calculations")
    Public tInvalidAdvanceTableDetail As TString = New TString("The analysis expects the tabulated advance data to cover the entire length of the field.")
    Public tInvalidAdvanceTableStart As TString = New TString("Advance Table must start at distance = 0, time = 0")
    Public tInvalidAdvanceTableEnd As TString = New TString("Advance Table must reach end-of-field")
    Public tInvalidAdvanceValuesNotMonotonic As TString = New TString("Advance Distances and Times must increase monotonically")
    '
    ' Recession Profile error ID/Detail
    '
    Public tNoRecessionSpecified As TString = New TString("No Recession has been specified; analysis cannot continue.")
    Public tInvalidRecessionTableID As TString = New TString("Recession Table is invalid for volume balance calculations")
    Public tInvalidRecessionTableDetail As TString = New TString("The analysis expects the tabulated recession data to cover the entire length of the field.")
    Public tInvalidRecessionTableStart As TString = New TString("Distances must start at 0 and increase monotonically; Times must be greater then 0")
    Public tInvalidRecessionTableEnd As TString = New TString("Recession Table must end at end-of-field; TL <= time")
    Public tInvalidRecessionTableTimes As TString = New TString("Times in Recession Table must be larger than times in the Advance Table")
    Public tInvalidRecessionValuesNotMonotonic As TString = New TString("Recession Distances must increase monotonically")

    Public tInvalidAdvanceRecessionID As TString = New TString("Advance/recession measurements are deficient.")
    Public tInvalidAdvanceRecessionDetail As TString = New TString("Analysis expects advance/recession measurements at least at 0, 25, 50, 75 and 100% of L.")
    Public tInvalidAdvanceRecessionMisalignedID As TString = New TString("Advance/recession measurements are misaligned.")
    Public tInvalidAdvanceRecessionMisalignedDetail As TString = New TString("Analysis expects advance/recession measurements at coincident locations.")

    Public tInvalidRecessionDataUseID As TString = New TString("Recession data cannot be used for post-irrigation volume balance calculations.")
    Public tInvalidRecessionDataUseDetail As TString = New TString("Recession data provided for use in post-irrigation volume balance calculations.  However, a final volume balance cannot be calculated due to incomplete runoff data.")
    '
    ' Measurement Stations error ID/Detail
    '
    Public tInvalidStationsTableID As TString = New TString("Stations Table is invalid/incomplete to be used for volume balance calculations.")
    Public tInvalidStationsTableDetail As TString = New TString("The analysis expects the stations data to cover the entire length of the field.")
    Public tFirstStationNotAtHeadDetail As TString = New TString("First Station must be at the head of the field")
    Public tLastStationNotAtEndDetail As TString = New TString("Last Station must be at the end of the field")
    Public tNotEnoughStationsDetail As TString = New TString("A minimum of 5 Measurement Stations are required")
    Public tInvalidStationDistancesNotMonotonic As TString = New TString("Measurement Station distances must increase monotonically")
    Public tInvalidStationAdvanceID As TString = New TString("Measurement Station advance time not found")
    Public tInvalidStationAdvanceDetail As TString = New TString("The Advance table must have an entry")
    Public tInvalidStationLocationID As TString = New TString("All Measurement Station locations must be entered in the System Geometry's Elevation Table")
    Public tInvalidStationLocationDetail As TString = New TString("Measurement Station location not found in Elevation Table")
    Public tInvalidStationElevationID As TString = New TString("All Measurement Station elevations must match values in the System Geometry's Elevation Table")
    Public tInvalidStationElevationDetail As TString = New TString("Measurement Station elevation doesn't match value in Elevation Table")
    Public tInvalidStationRecessionID As TString = New TString("Measurement Station recession time not found")
    Public tInvalidStationRecessionDetail As TString = New TString("The Recession table must have an entry")
    '
    ' Flow Depth Hydrograph error ID/Detail
    '
    Public tInvalidFlowDepthTablesID As TString = New TString("Flow Depth Table(s) are invalid")
    Public tInvalidFlowDepthTablesDetail As TString = New TString("Flow Depth Table is empty or invalid/incomplete")
    Public tInvalidInitialFlowDepth As TString = New TString("Initial depth in Flow Depth Table should be zero")
    Public tInvalidInitialFlowDepthTime As TString = New TString("Initial time in Flow Depth Table must match Advance time")
    Public tInvalidFinalFlowDepth As TString = New TString("Final depth in Flow Depth Table should be zero")
    Public tInvalidFinalFlowDepthTime As TString = New TString("Final time in Flow Depth Table must match Recession time at Station")
    Public tInvalidFlowDepthTimesNotMonotonic As TString = New TString("Flow Depth Times must increase monotonically")
    Public tInvalidFlowDepthTime As TString = New TString("Time in Flow Depth Table cannot be negative")
    Public tInvalidFlowDepthDepth As TString = New TString("Depth in Flow Depth Table cannot be negative")

    Public tVolumeBalanceTableID As TString = New TString("Volume Balance table")
    Public tInvalidVolumeBalanceTableID As TString = New TString("Volume Balance table is invalid")
    Public tInvalidVolumeBalanceDetail As TString = New TString("Volume Balance table is empty or invalid/incomplete")
    Public tInvalidVbTimeDetail As TString = New TString("Proposed volume balance calculation time is not supported by the available data.")
    Public tInvalidVbVzValuesDetail As TString = New TString("Infiltrated Volumes (Vz) do not increase with time")

    Public tInvalidEstimatedSurfaceVolumeTableID As TString = New TString("Estimated Surface Volumes table is invalid")
    Public tInvalidEstimatedSurfaceVolumeDetail As TString = New TString("Estimated Surface Volumes table is empty or invalid/incomplete")
    Public tInvalidEstimatedSurfaceVolumeXpaDistance As TString = New TString("Invalid post-advance distance(s)")
    Public tVerifyAdvancePowerLawParameters As TString = New TString("Verify Advance Power Law Parameters (p & r) are correct")
    Public tSigmaYEstimatedSurfaceVolumeID As TString = New TString("Unusual estimate for the surface shape factor SigmaY")
    Public tSigmaYEstimatedSurfaceVolumeDetail As TString = New TString("The data does not satisfy assumptions of the volume balance analysis.  Delete the volume balance calculation time associated with this value")

    Public tAnalysisHasAlreadyBeenRunID As TString = New TString("Analysis has already been run")
    Public tAnalysisHasAlreadyBeenRunDetail As TString = New TString("This analysis has already been run.  If you run it again, you will lose the current results.  To save the current results, copy & paste this analysis to a new one, then make your changes in and run the new analysis")

    Public tCannotCalculatePIVB As TString = New TString("Final volume balance cannot be calculated.")
    Public tSeeVerifyTabForDetails As TString = New TString("See Verify tab for details")

    Public tLevelBasinNotBlockedID As TString = New TString("Level Basins must have Blocked End")
    Public tLevelBasinNotBlockedDetails As TString = New TString("Operations functions only support Level Basins with Blocked Ends")

    Public tCutoffOptionNotSupportID As TString = New TString("Cutoff option not supported")
    Public tCutoffOptionNotSupportDetails As TString = New TString("Basin / Border Operations functions only support Time-Based Cutoff")

    Public tCutbackNotSupportedID As TString = New TString("Cutback not supported")
    Public tCutbackBasinBorderNotSupportedDetails As TString = New TString("Basin / Border function does not support Cutback")
    Public tCutbackFurrowNotSupportedDetails As TString = New TString("Furrow function does not support Cutback for the selected Wetted Perimeter")

    Public tDefaultTuningFactorsID As TString = New TString("Tuning Factor(s) have default values")
    Public tDefaultTuningFactorsDetails As TString = New TString("One or more Tuning Factors have default values.  Estimate Tuning Factors must be run prior to running the design")

    Public tAdvanceRecessionInadequateID As TString = New TString("Advance cannot be completed")
    Public tAdvanceRecessionInadequateDetail As TString = New TString("For one or more points, a Cutoff Time cannot be found that meets both the Advance and Recession requirements")

    Public tTimeTooLongErrorID As TString = New TString("Irrigation Time greater than 7 days")
    Public tTimeTooLongErrorDetail As TString = New TString("For one or more points, total Irrigation Time is greater than seven days which is beyond the capabilities of WinSRFR")

    Public tTcbLimitedToTcoID As TString = New TString("Cutback Time limited to Cutoff Time")
    Public tTcbLimitedToTcoDetail As TString = New TString("For one or more points, Cutback Time (Tcb) is limited by Cutoff Time (Tco).  Cutback is not recommended for these points")

    Public tLimitLineExceededID As TString = New TString("Limit Line Exceeded")
    Public tLimitLineExceededDetail As TString = New TString("For one or more points, Cutoff Time and/or Inflow Rate do not meet recommended operations limits")

    Public tPT1DistLeZeroID As TString = New TString("Point 1 Distance is at or prior to the head of the field")
    Public tPT1DistLeZeroDetail As TString = New TString("Point 1 Distance must be after the start of the field and before Point 2 Distance")

    Public tPT2DistGtLengthID As TString = New TString("Point 2 Distance is beyond the end of the field")
    Public tPT2DistGtLengthDetail As TString = New TString("Point 2 Distance must be at or before the end of the field")

    Public tPT1DistGePT2DistID As TString = New TString("Point 1 Distance is at or after Point 2 Distance")
    Public tPT1DistGePT2DistDetail As TString = New TString("Point 1 Distance must be after the start of the field and before Point 2 Distance")

    Public tPT1TimeLeZeroID As TString = New TString("Point 1 Time is at or prior to the start of the irrigation")
    Public tPT1TimeLeZeroDetail As TString = New TString("Point 1 Time must be after the start of the irrigation and before Point 2 Time")

    Public tPT2TimeGtCutoffID As TString = New TString("Station 2 Time is after last inflow rate.")
    Public tPT2TimeGtCutoffDetail As TString = New TString("This analysis requires that inflow rate be specified for times greater than the advance time to station 2.")

    Public tPT1TimeGePT2TimeID As TString = New TString("Point 1 Time is at or after Point 2 Time")
    Public tPT1TimeGePT2TimeDetail As TString = New TString("Point 1 Time must be after the start of the irrigation and before Point 2 Time")

    Public tOutflowGtInflowID As TString = New TString("Outflow rate at cutoff exceeds Inflow rate at cutoff")
    Public tOutflowGtInflowDetail As TString = New TString("The given data cannot be used to estimate the steady-state infiltration rate")

    Public tInvalidInfiltrationParametersID As TString = New TString("Estimated Infiltration Parameters are invalid")
    Public tInvalidInfiltrationParametersDetail As TString = New TString("The estimated infiltration parameters are either undefined or are incorrect")

    Public tProbeLengthLtProbedDepthID As TString = New TString("Probe Length < Probed Depth")
    Public tProbeLengthLtProbedDepthDetail As TString = New TString("One or more Probed Depth values in the Infiltrated Depths table is larger than the Probe Length.  Probed Depth values must be less than or equal to the Probe Length.  This error must be corrected before the analysis can be run")

    Public tLastInfiltratedDepthDistanceNotLengthID As TString = New TString("Last Infiltrated Depth Distance <> Length")
    Public tLastInfiltratedDepthDistanceNotLengthDetail As TString = New TString("The last Infiltrated Depth distance must be at the end of the field")

    Public tNoOpportunityTimesID As TString = New TString("No Opportunity Time table was found")
    Public tNoOpportunityTimesDetail As TString = New TString("The Opportunity Time table is undefined.  Correct the values in the Advance and Recession tables to fix this error")

    Public tOutsideNrcsRangeID As TString = New TString("Infiltration is outside range predicted by NRCS Families")
    Public tOutsideNrcsRangeDetail As TString = New TString("The Mass-Balance Infiltrated Volume is outside the range supported by the NRCS Intake Families")

    Public tOutsideTimeRatedRangeID As TString = New TString("Infiltration is outside range predicted by Time-Rated Families")
    Public tOutsideTimeRatedRangeDetail As TString = New TString("The Mass-Balance Infiltrated Volume is outside the range supported by the Time-Rated Intake Families")

    Public tSlopeWarning As TString = New TString("Slope too mild for Kinematic Wave")
    Public tKinematicWaveUseInvalid As TString = New TString("The Kinematic Wave model is not valid for use with this set of parameters")
    Public tKinematicWaveBlockedEnd As TString = New TString("The Kinematic Wave model does not support blocked-end fields")
    Public tKinematicWaveZeroSlope As TString = New TString("The Kinematic Wave model does not support zero or negative slopes")
    Public tKinematicWaveSlopeWarning As TString = New TString("The kinematic wave model is not recommended for use with mild slopes ( < 0.004).  If you need to run this simulation, repeat the analysis using the zero-inertia model and contrast the results")

    Public tGreenAmptNotAvailable As TString = New TString("Green-Ampt not available")
    Public tGreenAmptNotAvailableForFurrows As TString = New TString("Green-Ampt not available for Furrow Simulation")
    Public tGreenAmptNotAvailableForOperationsAnalysis As TString = New TString("Green-Ampt not available for Operations Analysis")
    Public tGreenAmptNotAvailableForDesignAnalysis As TString = New TString("Green-Ampt not available for Design Analysis")
    Public tWarrickGreenAmptNotAvailable As TString = New TString("Warrick Green-Ampt not available")
    Public tWarrickGreenAmptNotAvailableForBorders As TString = New TString("Warrick Green-Ampt not available for Basin/Border Simulation")
    Public tWarrickGreenAmptNotAvailableForOperationsAnalysis As TString = New TString("Warrick Green-Ampt not available for Operations Analysis")
    Public tWarrickGreenAmptNotAvailableForDesignAnalysis As TString = New TString("Warrick Green-Ampt not available for Design Analysis")

    Public tPercentLessThanZero As TString = New TString("Retained (%) < 0")
    Public tIndividualRetainedValuesCannotBeNegative As TString = New TString("Individual Retained (%) values cannot be negative")

    Public tRetainedTooLarge As TString = New TString("Retained (%) total greater than 100%")
    Public tSumRetainedValuesMustBeLessThan100 As TString = New TString("Sum of Retained (%) values must be less than 100%")

    Public tSieveSizeLessThanZero As TString = New TString("Sieve Size < 0")
    Public tIndividualSieveSizeValuesCannotBeNegative As TString = New TString("Individual Sieve Size values cannot be negative")

    Public tSpecificGravityInvalid As TString = New TString("Specific Gravity is invalid")
    Public tSpecificGravityLessThan1OrGreaterThan3 As TString = New TString("Specific Gravity is less than 1.0 or greater than 3.0")

    Public tSoilErodibilityInvalid As TString = New TString("Soil Erodibility value(s) are invalid")
    Public tSoilErodibilityValuesAreInvalid As TString = New TString("One or more Soil Erodibility value(s) are invalid")

    Public tProbeLengthLtRootZoneDepthID As TString = New TString("Probe Length < Root Zone Depth")
    Public tProbeLengthLtRootZoneDepthDetail As TString = New TString("Infiltrated depth cannot be measured correctly for the entire root zone.  A longer probe needs to be used to determine water penetration")

    Public tCumulativeProfileDepthLtRootZoneDepthID As TString = New TString("Cumulative Profile Depth < Root Zone Depth")
    Public tCumulativeProfileDepthLtRootZoneDepthDetail As TString = New TString("The soil water deficit cannot be computed for the entire root zone.  Soil water depletion data needs to be provided to a depth at least equal to the root zone depth.  The actual root zone infiltration exceeds the computed value.  A performance summary cannot be computed under these conditions")

    Public tRootZoneInfiltrationUnderestimatedID As TString = New TString("Possible Underestimation of Root Zone Infiltrated Depth")
    Public tRootZoneInfiltrationUnderestimatedDetail As TString = New TString("Infiltrated depth cannot be computed correctly for the entire root zone.  A longer probe needs to be used to determine water penetration.  The actual root zone infiltration exceeds the computed value.  A performance summary cannot be computed under these conditions")

    Public tLeachingRequirementUnderestimatedID As TString = New TString("Possible Underestimation of Leaching Requirement")
    Public tLeachingRequirementUnderestimatedDetail As TString = New TString("Infiltrated depth contributing to the leaching requirement cannot be determined from the available probe readings.  Actual useful infiltrated depth may be under predicted and deep percolation over predicted.  This may occur if either a Probed Depth is equal to the Probe Length or a Probed Depth is larger than the Cummulative Profile Depth")

    Public tInfiltratedDepthLtUsefulDepthID As TString = New TString("Infiltrated Depth < Useful Depth")
    Public tInfiltratedDepthLtUsefulDepthDetail As TString = New TString("The useful infiltrated depth computed from the probe measurements exceeds the infiltration from the inflow-outflow mass balance.  Check the values used to compute soil water deficit and/or inflow-outflow values used to compute the mass balance")

    Public tDesignNotRecommendedID As TString = New TString("Design Solution is Not Recommended")
    Public tDesignNotRecommendedDetail As TString = New TString("For one or more points, the design solution is deficient and not recommended")

    Public tDesignNotValidID As TString = New TString("Design Solution is Not Valid")
    Public tDesignNotValidDetail As TString = New TString("For one or more points, the operation solution invalid")

    Public tOperationNotRecommendedID As TString = New TString("Operation Solution is Not Recommended")
    Public tOperationNotRecommendedDetail As TString = New TString("For one or more points, the operation solution is deficient and not recommended")

    Public tOperationNotValidID As TString = New TString("Operation Solution is Not Valid")
    Public tOperationNotValidDetail As TString = New TString("For one or more points, the operation solution invalid")

#End Region

#Region " Application Wide "

    Public tFolder As TString = New TString("Folder")
    Public tFile As TString = New TString("File")
    Public tFileCannotBeWritten As TString = New TString("File cannot be written")
    Public tFileContainsUnexpectedData As TString = New TString("File contains unexpected data")
    Public tFileIsEmpty As TString = New TString("File is empty")
    Public tFileIsReadOnly As TString = New TString("File is ReadOnly")
    Public tFileNotFound As TString = New TString("File was not found")
    Public tFileReadError As TString = New TString("File Read Error")
    Public tSaving As TString = New TString("Saving")
    Public tSaveComplete As TString = New TString("Save Complete")
    Public tSaveFailed As TString = New TString("Save Failed")
    Public tSaveError As TString = New TString("Save Error")
    Public tSaveProject As TString = New TString("Save Project")
    Public tSaveProjectConfirmation As TString = New TString("Save Project Confirmation")

    Public tAdd As TString = New TString("Add")
    Public tBrowseForProject As TString = New TString("Browse for project")
    Public tConstant As TString = New TString("Constant")
    Public tCost As TString = New TString("Cost")
    Public tCosts As TString = New TString("Costs")
    Public tDataComparisonError As TString = New TString("Data Comparison Error")
    Public tDistance As TString = New TString("Distance")
    Public tDoYouWantToContinue As TString = New TString("Do you want to continue?")
    Public tEnterTime As TString = New TString("Enter a Time value")
    Public tFamily As TString = New TString("Family")
    Public tFrom As TString = New TString("From")
    Public tGoodness As TString = New TString("Goodness")
    Public tGoodnessOfFit As TString = New TString("Goodness of Fit")
    Public tIndicators As TString = New TString("Indicators")
    Public tInputParameters As TString = New TString("Input Parameters")
    Public tInputAndPerformanceSummary As TString = New TString("Input and Performance Summary")
    Public tIrrigationWater As TString = New TString("Irrigation Water")
    Public tIsNotUnique As TString = New TString("is not unique")
    Public tIteration As TString = New TString("Iteration")
    Public tLevel As TString = New TString("Level")
    Public tMakeChangesListedAbove As TString = New TString("Make the changes listed above")
    Public tNA As TString = New TString("N/A")
    Public tNone As TString = New TString("None")
    Public tNormal As TString = New TString("Normal")
    Public tOr As TString = New TString("or")
    Public tPartial As TString = New TString("Partial")
    Public tParameter As TString = New TString("Parameter")
    Public tParameterSet As TString = New TString("Parameter Set")
    Public tPaste As TString = New TString("Paste")
    Public tPerformanceIndicators As TString = New TString("Performance Indicators")
    Public tPoint As TString = New TString("Point")
    Public tProceedDownTabs As TString = New TString("Proceed down tabs verifying data is correct for your field.")
    Public tProblemNearLine As TString = New TString("Problem is near line")
    Public tProfile As TString = New TString("Profile")
    Public tOverflow As TString = New TString("Overflow")
    Public tOverflowAt As TString = New TString("OVERFLOW at")
    Public tOverflowMayExist As TString = New TString("Overflow conditions may exist")
    Public tRelativeError As TString = New TString("Relative Error")
    Public tRemove As TString = New TString("Remove")
    Public tSampleText As TString = New TString("Sample Text")
    Public tSedimentParticle As TString = New TString("Sediment Particle")
    Public tSelectOneOrMore As TString = New TString("Select One or More")
    Public tSelected As TString = New TString("Selected")
    Public tShouldBe0 As TString = New TString("should be 0")
    Public tShouldBe1 As TString = New TString("should be 1")
    Public tShouldBeFalse As TString = New TString("should be false")
    Public tShouldBeTrue As TString = New TString("should be true")
    Public tSolution As TString = New TString("Solution")
    Public tSolutionModel As TString = New TString("Solution Model")
    Public tSummary As TString = New TString("Summary")
    Public tTable As TString = New TString("Table")
    Public tTabulated As TString = New TString("Tabulated")
    Public tTexture As TString = New TString("Texture")
    Public tThenYouWill As TString = New TString("Then you will")
    Public tTime As TString = New TString("Time")
    Public tTimestep As TString = New TString("Timestep")
    Public tTo As TString = New TString("To")
    Public tToThe As TString = New TString("to the")
    Public tTotal As TString = New TString("Total")
    Public tUserLevel As TString = New TString("User Level")
    Public tUserEnteredParameters As TString = New TString("User-Entered Parameters")
    Public tVariableNotFound As TString = New TString("Variable was not found")
    Public tVariableNotParsed As TString = New TString("Variable could not be parsed")
    Public tVerify As TString = New TString("Verify")
    Public tVerifyFileIsCorrect As TString = New TString("Verify file is correct")
    Public tVerifyMatchResults As TString = New TString("Verify match results and adjust if necessary")
    Public tWaterMassBalanceExceedsLimit As TString = New TString("Water mass balance exceeds limit")
    Public tWhatsThisHelp As TString = New TString("What's This? Help")
    Public tWithin As TString = New TString("Within")
    Public tWithinFarm As TString = New TString("Within Farm")
    Public tWithinField As TString = New TString("Within Field")

#End Region

#End Region

End Class
