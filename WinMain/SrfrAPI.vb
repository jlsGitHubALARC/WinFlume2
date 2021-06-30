
'*************************************************************************************************************
' SrfrAPI - support for using Srfr.dll
'
' This WinSRFR SrfrAPI Module provides an interface to the SRFR DLL.
'*************************************************************************************************************
Imports System.Collections.Generic

Imports Srfr
Imports DataStore
Imports GraphingUI

Module SrfrAPI

#Region " SRFR Inputs "

#Region " Cross Section "

    '*********************************************************************************************************
    ' Load WinSRFR's System Geometry data into the appropriate SRFR CrossSection object
    '*********************************************************************************************************
    Public Function SrfrCrossSection(ByVal WinSrfrGeometry As SystemGeometry) As Srfr.CrossSection

        SrfrCrossSection = Nothing

        Try
            '
            ' Data to load into SRFR is Cross Section selection dependent
            '
            Dim CrossSection As CrossSections = WinSrfrGeometry.CrossSection.Value

            Select Case (CrossSection)
                Case CrossSections.Basin, CrossSections.Border
                    SrfrCrossSection = SrfrBorderStrip(WinSrfrGeometry)

                Case CrossSections.Furrow

                    Dim furrowShape As FurrowShapes = WinSrfrGeometry.FurrowShape.Value

                    Select Case (furrowShape)
                        Case FurrowShapes.Trapezoid, FurrowShapes.TrapezoidFromFieldData
                            SrfrCrossSection = SrfrTrapezoidFurrow(WinSrfrGeometry)

                        Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData
                            SrfrCrossSection = SrfrPowerLawFurrow(WinSrfrGeometry)

                        Case Else
                            Debug.Assert(False)
                            Throw New System.Exception("Invalid Furrow Shape")
                    End Select

                Case Else
                    Debug.Assert(False)
                    Throw New System.Exception("Invalid Cross Section")
            End Select

        Catch ex As Exception
            Dim errMsg As String = "SrfrAPI:SrfrCrossSection - " & ex.Message
            Throw New System.Exception(errMsg)
        End Try

    End Function

    Public Function SrfrBorderStrip(ByVal WinSrfrGeometry As SystemGeometry) As Srfr.BorderStrip

        ' Instantiate a SRFR Border Strip object
        SrfrBorderStrip = New Srfr.BorderStrip

        ' Load data common to all cross sections
        SrfrGeometry(SrfrBorderStrip, WinSrfrGeometry)

        ' Furrows Per Set = 1 for Basins & Borders
        SrfrBorderStrip.FurrowsPerSet = 1

        ' Load tabulated Border Depth data, if present
        If (WinSrfrGeometry.EnableTabulatedBorderDepth.Value) Then

            Dim varyLoc As VaryByLoc = SrfrBorderStrip.AddCrossSectionTable(LocTypes.ByDist, 0.0)

            Dim borderTable As DataTable = WinSrfrGeometry.BorderDepthTable.Value
            For Each borderRow As DataRow In borderTable.Rows
                Dim dist As Double = borderRow.Item(sDistanceX)
                Dim maxY As Double = borderRow.Item(Srfr.Globals.sDepthMM)

                Dim srfrRow As DataRow = varyLoc.AddRow
                srfrRow.Item(VaryByLoc.sDistM) = dist
                srfrRow.Item(Srfr.Globals.sDepthMM) = maxY
            Next
        End If

    End Function

    Public Function SrfrTrapezoidFurrow(ByVal WinSrfrGeometry As SystemGeometry) As Srfr.TrapezoidFurrow

        ' Instantiate a SRFR Trapezoid Furrow object
        SrfrTrapezoidFurrow = New Srfr.TrapezoidFurrow

        ' Load data common to all cross sections
        SrfrGeometry(SrfrTrapezoidFurrow, WinSrfrGeometry)

        ' Load Trapezoid Furrow data
        SrfrTrapezoidFurrow.BW = WinSrfrGeometry.BottomWidth.Value
        SrfrTrapezoidFurrow.SS = WinSrfrGeometry.SideSlope.Value
        SrfrTrapezoidFurrow.MaxDepth = WinSrfrGeometry.MaximumDepth.Value

        ' Load tabulated Trapezoid Furrow data, if present
        If (WinSrfrGeometry.EnableTabulatedFurrowShape.Value) Then

            Dim varyLoc As VaryByLoc = SrfrTrapezoidFurrow.AddCrossSectionTable(LocTypes.ByDist, 0.0)

            Dim trapezoidTable As DataTable = WinSrfrGeometry.TrapezoidTable.Value
            For Each trapezoidRow As DataRow In trapezoidTable.Rows
                Dim dist As Double = trapezoidRow.Item(sDistanceX)
                Dim bw As Double = trapezoidRow.Item(Srfr.Globals.sBWmm)
                Dim ss As Double = trapezoidRow.Item(Srfr.Globals.sSS)
                Dim maxY As Double = trapezoidRow.Item(Srfr.Globals.sDepthMM)

                Dim srfrRow As DataRow = varyLoc.AddRow
                srfrRow.Item(VaryByLoc.sDistM) = dist
                srfrRow.Item(Srfr.Globals.sBWmm) = bw
                srfrRow.Item(Srfr.Globals.sSS) = ss
                srfrRow.Item(Srfr.Globals.sDepthMM) = maxY
            Next trapezoidRow
        End If

    End Function

    Public Function SrfrPowerLawFurrow(ByVal WinSrfrGeometry As SystemGeometry) As Srfr.PowerLawFurrow

        ' Instantiate a SRFR Power Law Furrow object
        SrfrPowerLawFurrow = New Srfr.PowerLawFurrow

        ' Load data common to all cross sections
        SrfrGeometry(SrfrPowerLawFurrow, WinSrfrGeometry)

        ' Load Power Law Furrow data
        SrfrPowerLawFurrow.M = WinSrfrGeometry.PowerLawExponent.Value
        SrfrPowerLawFurrow.W100 = WinSrfrGeometry.WidthAt100mm.Value
        SrfrPowerLawFurrow.MaxDepth = WinSrfrGeometry.MaximumDepth.Value

        ' Load tabulated PowerLaw Furrow data, if present
        If (WinSrfrGeometry.EnableTabulatedFurrowShape.Value) Then

            Dim varyLoc As VaryByLoc = SrfrPowerLawFurrow.AddCrossSectionTable(LocTypes.ByDist, 0.0)

            Dim powerLawTable As DataTable = WinSrfrGeometry.PowerLawTable.Value
            For Each powerLawRow As DataRow In powerLawTable.Rows
                Dim dist As Double = powerLawRow.Item(sDistanceX)
                Dim w100 As Double = powerLawRow.Item(Srfr.Globals.sW100mm)
                Dim M As Double = powerLawRow.Item(Srfr.Globals.sM)
                Dim maxY As Double = powerLawRow.Item(Srfr.Globals.sDepthMM)

                Dim srfrRow As DataRow = varyLoc.AddRow
                srfrRow.Item(VaryByLoc.sDistM) = dist
                srfrRow.Item(Srfr.Globals.sW100mm) = w100
                srfrRow.Item(Srfr.Globals.sM) = M
                srfrRow.Item(Srfr.Globals.sDepthMM) = maxY
            Next
        End If

    End Function

    '*********************************************************************************************************
    ' Load common Cross Section data into SRFR
    '*********************************************************************************************************
    Private Sub SrfrGeometry(ByVal SrfrCrossSection As Srfr.CrossSection, ByVal WinSrfrGeometry As SystemGeometry)
        '
        ' Upstream & Downstream Conditions & Border Geometry are common to all Cross Sections
        '
        With WinSrfrGeometry
            ' Upstream Condition
            If (WinSRFR.UserLevel = UserLevels.Standard) Then
                SrfrCrossSection.UpstreamBoundary = CrossSection.UpstreamConditions.NoDrainback
            Else
                Select Case (.UpstreamCondition.Value)
                    Case UpstreamConditions.DrainbackAfterCutoff
                        SrfrCrossSection.UpstreamBoundary = CrossSection.UpstreamConditions.Drainback
                    Case Else
                        SrfrCrossSection.UpstreamBoundary = CrossSection.UpstreamConditions.NoDrainback
                End Select
            End If

            ' Downstream Condition
            Select Case (.DownstreamCondition.Value)
                Case DownstreamConditions.BlockedEnd
                    SrfrCrossSection.DownstreamBoundary = CrossSection.DownstreamConditions.BlockedEnd
                Case Else
                    SrfrCrossSection.DownstreamBoundary = CrossSection.DownstreamConditions.OpenEnd
            End Select

            ' Border Geometry
            SrfrCrossSection.Length = .Length.Value
            SrfrCrossSection.BorderWidth = .Width.Value
            SrfrCrossSection.MaxDepth = .Depth.Value

            SrfrCrossSection.FurrowsPerSet = .FurrowsPerSet.Value
            SrfrCrossSection.FurrowSpacing = .FurrowSpacing.Value

            Select Case (.BottomDescription.Value)
                Case BottomDescriptions.Slope
                    SrfrCrossSection.S0 = .Slope.Value

                Case BottomDescriptions.AvgFromSlopeTable, BottomDescriptions.AvgFromElevTable
                    Dim elevationSet As DataSet = .ElevationTable.Value

                    If (.BottomDescription.Value = BottomDescriptions.AvgFromSlopeTable) Then
                        Dim slopeSet As DataSet = .SlopeTable.Value
                        elevationSet = .ElevationTableFromSlopeTable(slopeSet)
                    End If

                    SrfrCrossSection.S0 = .AverageSlopeFromElevationTable(elevationSet)

                Case BottomDescriptions.SlopeTable, BottomDescriptions.ElevationTable
                    Dim elevationSet As DataSet = .ElevationTable.Value

                    If (.BottomDescription.Value = BottomDescriptions.SlopeTable) Then
                        Dim slopeSet As DataSet = .SlopeTable.Value
                        elevationSet = .ElevationTableFromSlopeTable(slopeSet)
                    End If

                    SrfrCrossSection.S0 = .AverageSlopeFromElevationTable(elevationSet)

                    SrfrCrossSection.ClearElevations()

                    For Each elevationTable As DataTable In elevationSet.Tables
                        Dim time As Double = 0.0
                        If (ParseTime(elevationTable.TableName, time)) Then
                            For Each row As DataRow In elevationTable.Rows
                                Dim dist As Double = row.Item(sDistanceX)
                                Dim elevation As Double = row.Item(sElevationX)

                                SrfrCrossSection.AddElevation(dist, time, elevation)
                            Next
                        End If
                    Next

                Case Else
                    Throw New System.Exception("Invalid Bottom Description")
            End Select
        End With

    End Sub

#End Region

#Region " Roughness "

    '*********************************************************************************************************
    ' Load WinSRFR's Roughness data into the appropriate SRFR Roughness object
    '*********************************************************************************************************
    Public Function SrfrRoughness(ByVal WinSrfrRoughness As SoilCropProperties) As Srfr.Roughness

        SrfrRoughness = Nothing

        Try
            '
            ' Data to load into SRFR is Roughness Method dependent
            '
            Dim RoughnessMethod As RoughnessMethods = WinSrfrRoughness.RoughnessMethod.Value

            Select Case (RoughnessMethod)
                Case RoughnessMethods.ManningN, RoughnessMethods.NrcsSuggestedManningN
                    SrfrRoughness = SrfrManningN(WinSrfrRoughness)

                Case RoughnessMethods.ManningCnAn
                    SrfrRoughness = SrfrManningCnAn(WinSrfrRoughness)

                Case RoughnessMethods.SayreAlbertson
                    SrfrRoughness = SrfrSayreAlbertsonChi(WinSrfrRoughness)

                Case Else
                    Throw New System.Exception("Invalid Roughness Method")
            End Select

        Catch ex As Exception
            Dim errMsg As String = "SrfrAPI:SrfrRoughness - " & ex.Message
            Throw New System.Exception(errMsg)
        End Try

    End Function

    Public Function SrfrManningN(ByVal winSrfrRoughness As SoilCropProperties) As Srfr.ManningN

        ' Instantiate a SRFR Manning n object
        SrfrManningN = New Srfr.ManningN

        ' Load data common to all roughness methods
        SrfrRoughness(SrfrManningN, winSrfrRoughness)

        Dim nrcsSuggestion As NrcsSuggestedManningN = winSrfrRoughness.NrcsSuggestedManningN.Value
        If (nrcsSuggestion = NrcsSuggestedManningN.UserEntered) Then ' load user-entered Manning n data
            SrfrManningN.n = winSrfrRoughness.ManningN.Value
        Else ' load NRCS suggested Manning n
            SrfrManningN.n = NrcsSuggestedManningNValues(nrcsSuggestion)
        End If

        ' Load tabulated Manning n data, if present
        SrfrManningN.ClearRoughnessTables()

        If (winSrfrRoughness.EnableTabulatedRoughness.Value) Then

            Dim varyLoc As VaryByLoc = SrfrManningN.AddRoughnessTable(LocTypes.ByDist, 0.0)

            Dim manningTable As DataTable = winSrfrRoughness.ManningNTable.Value
            For Each winSrfrRrow As DataRow In manningTable.Rows
                Dim dist As Double = winSrfrRrow.Item(sDistanceX)
                Dim n As Double = winSrfrRrow.Item(Srfr.ManningN.sN)
                Dim vegDensity As Double = 0.0
                If (winSrfrRoughness.EnableVegetativeDensity.Value = True) Then
                    vegDensity = winSrfrRrow.Item(Srfr.Roughness.sVegDensityM)
                End If

                Dim srfrRow As DataRow = varyLoc.AddRow
                srfrRow.Item(VaryByLoc.sDistM) = dist
                srfrRow.Item(Srfr.ManningN.sN) = n
                srfrRow.Item(Srfr.Roughness.sVegDensityM) = vegDensity
            Next
        End If

    End Function

    Public Function SrfrManningCnAn(ByVal winSrfrRoughness As SoilCropProperties) As Srfr.ManningCnAn

        ' Instantiate a SRFR Manning Cn/An object
        SrfrManningCnAn = New Srfr.ManningCnAn

        ' Load data common to all roughness methods
        SrfrRoughness(SrfrManningCnAn, winSrfrRoughness)

        ' Load Manning Cn/An data
        SrfrManningCnAn.Cn = winSrfrRoughness.ManningCn.Value
        SrfrManningCnAn.An = winSrfrRoughness.ManningAn.Value

        ' Load tabulated Manning Cn/An data, if present
        SrfrManningCnAn.ClearRoughnessTables()

        If (winSrfrRoughness.EnableTabulatedRoughness.Value) Then

            Dim varyLoc As VaryByLoc = SrfrManningCnAn.AddRoughnessTable(LocTypes.ByDist, 0.0)

            Dim manningTable As DataTable = winSrfrRoughness.ManningCnAnTable.Value
            For Each winSrfrRrow As DataRow In manningTable.Rows
                Dim dist As Double = winSrfrRrow.Item(sDistanceX)
                Dim Cn As Double = winSrfrRrow.Item(Srfr.ManningCnAn.sCn)
                Dim An As Double = winSrfrRrow.Item(Srfr.ManningCnAn.sAn)
                Dim vegDensity As Double = 0.0
                If (winSrfrRoughness.EnableVegetativeDensity.Value = True) Then
                    vegDensity = winSrfrRrow.Item(Srfr.Roughness.sVegDensityM)
                End If

                Dim srfrRow As DataRow = varyLoc.AddRow
                srfrRow.Item(VaryByLoc.sDistM) = dist
                srfrRow.Item(Srfr.ManningCnAn.sCn) = Cn
                srfrRow.Item(Srfr.ManningCnAn.sAn) = An
                srfrRow.Item(Srfr.Roughness.sVegDensityM) = vegDensity
            Next
        End If

    End Function

    Public Function SrfrSayreAlbertsonChi(ByVal winSrfrRoughness As SoilCropProperties) As Srfr.SayreAlbertsonChi

        ' Instantiate a SRFR Sayre-Albertson Chi object
        SrfrSayreAlbertsonChi = New Srfr.SayreAlbertsonChi

        ' Load data common to all roughness methods
        SrfrRoughness(SrfrSayreAlbertsonChi, winSrfrRoughness)

        ' Load Sayre-Albertson data
        SrfrSayreAlbertsonChi.Chi = winSrfrRoughness.SayreChi.Value

        ' Load tabulated Sayre-Albertson data, if present
        SrfrSayreAlbertsonChi.ClearRoughnessTables()

        If (winSrfrRoughness.EnableTabulatedRoughness.Value) Then

            Dim varyLoc As VaryByLoc = SrfrSayreAlbertsonChi.AddRoughnessTable(LocTypes.ByDist, 0.0)

            Dim sayreChiTable As DataTable = winSrfrRoughness.SayreChiTable.Value
            For Each winSrfrRrow As DataRow In sayreChiTable.Rows
                Dim dist As Double = winSrfrRrow.Item(sDistanceX)
                Dim Chi As Double = winSrfrRrow.Item(Srfr.SayreAlbertsonChi.sChiMM)
                Dim vegDensity As Double = 0.0
                If (winSrfrRoughness.EnableVegetativeDensity.Value = True) Then
                    vegDensity = winSrfrRrow.Item(Srfr.Roughness.sVegDensityM)
                End If

                Dim srfrRow As DataRow = varyLoc.AddRow
                srfrRow.Item(VaryByLoc.sDistM) = dist
                srfrRow.Item(Srfr.SayreAlbertsonChi.sChiMM) = Chi
                srfrRow.Item(Srfr.Roughness.sVegDensityM) = vegDensity
            Next
        End If

    End Function
    '
    ' Load common Roughness data into SRFR
    '
    Private Sub SrfrRoughness(ByVal srfrRoughness As Srfr.Roughness, ByVal winSrfrRoughness As SoilCropProperties)
        '
        ' Vegetative Density is command to all Roughness methods
        '
        With winSrfrRoughness
            If (.EnableVegetativeDensity.Value) Then
                srfrRoughness.VegDensityIsEnabled = True
                srfrRoughness.VegDensity = .VegetativeDensity.Value
            Else
                srfrRoughness.VegDensityIsEnabled = False
                srfrRoughness.VegDensity = 0.0
            End If
        End With

    End Sub

#End Region

#Region " Infiltration "

    '*********************************************************************************************************************************
    ' Load WinSRFR's Infiltration data into the appropriate SRFR Infiltration object
    '
    ' Input(s):     WinSrfrInfiltration - Object containing WinSRFR's Infiltration parameters
    '
    ' Returns:      SrfrInfiltration    - Corresponding object containing SRFR's Infiltration parameters
    '*********************************************************************************************************************************
    Public Function SrfrInfiltration(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.Infiltration

        SrfrInfiltration = Nothing

        Try
            '
            ' Data to load into SRFR is Infiltration Method dependent
            '
            Dim InfiltrationFunction As InfiltrationFunctions = WinSrfrInfiltration.InfiltrationFunction.Value

            Select Case (InfiltrationFunction)
                Case InfiltrationFunctions.KostiakovFormula
                    SrfrInfiltration = SrfrKostiakovFormula(WinSrfrInfiltration)

                Case InfiltrationFunctions.ModifiedKostiakovFormula
                    SrfrInfiltration = SrfrModifiedKostiakov(WinSrfrInfiltration)

                Case InfiltrationFunctions.TimeRatedIntakeFamily
                    SrfrInfiltration = SrfrTimeRatedIntakeFamily(WinSrfrInfiltration)

                Case InfiltrationFunctions.CharacteristicInfiltrationTime
                    SrfrInfiltration = SrfrCharacteristicInfiltrationTime(WinSrfrInfiltration)

                Case InfiltrationFunctions.NRCSIntakeFamily
                    SrfrInfiltration = SrfrNrcsIntakeFamily(WinSrfrInfiltration)

                Case InfiltrationFunctions.BranchFunction
                    If (WinSrfrInfiltration.BranchTimeSet.Value) Then
                        SrfrInfiltration = SrfrBranchFunction2(WinSrfrInfiltration)
                    Else
                        SrfrInfiltration = SrfrBranchFunction(WinSrfrInfiltration)
                    End If

                Case InfiltrationFunctions.GreenAmpt
                    SrfrInfiltration = SrfrGreenAmpt(WinSrfrInfiltration)

                Case InfiltrationFunctions.Hydrus1D
                    SrfrInfiltration = SrfrHydrus1D(WinSrfrInfiltration)

                Case InfiltrationFunctions.WarrickGreenAmpt
                    SrfrInfiltration = SrfrWarrickGreenAmpt(WinSrfrInfiltration)

                Case Else
                    Debug.Assert(False)
                    Throw New System.Exception("Invalid Infiltration Method")
            End Select

            Dim SrfrCrossSection As Srfr.CrossSection = SrfrAPI.SrfrCrossSection(WinSrfrInfiltration.Unit.SystemGeometryRef)
            Dim srfrInflow As Srfr.Inflow = SrfrAPI.SrfrInflow(WinSrfrInfiltration.Unit.InflowManagementRef)
            Dim srfrRoughness As Srfr.Roughness = SrfrAPI.SrfrRoughness(WinSrfrInfiltration.Unit.SoilCropPropertiesRef)

            SrfrInfiltration.RefCrossSection = SrfrCrossSection
            SrfrInfiltration.RefInflow = srfrInflow
            SrfrInfiltration.RefRoughness = srfrRoughness

        Catch ex As Exception
            Dim errMsg As String = "SrfrAPI:SrfrInfiltration - " & ex.Message
            Throw New System.Exception(errMsg)
        End Try

    End Function

    Public Function SrfrKostiakovFormula(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.KostiakovFormula
        SrfrKostiakovFormula = Nothing

        If (WinSrfrInfiltration IsNot Nothing) Then
            With WinSrfrInfiltration

                ' Instantiate a SRFR Kostiakov Formula object
                SrfrKostiakovFormula = New Srfr.KostiakovFormula

                ' Load data common to all infiltration methods
                SrfrInfiltration(SrfrKostiakovFormula, WinSrfrInfiltration)

                Dim k, a, b, c As Double

                ' Load Kostiakov data into SRFR object
                a = .KostiakovA
                b = .KostiakovB
                c = .KostiakovC
                k = .KostiakovK

                SrfrKostiakovFormula.a = .KostiakovA
                SrfrKostiakovFormula.b = .KostiakovB
                SrfrKostiakovFormula.c = .KostiakovC
                SrfrKostiakovFormula.k = .KostiakovK

                ' If enabled, load tabulated infiltration data
                SrfrKostiakovFormula.ClearInfiltrationDataSet()

                If (.EnableTabulatedInfiltration.Value) Then

                    Dim varyLoc As VaryByLoc = SrfrKostiakovFormula.AddInfiltrationTable(LocTypes.ByDist, 0.0)

                    Dim kostiakovTable As DataTable = .KostiakovTable.Value
                    For Each winSrfrRow As DataRow In kostiakovTable.Rows
                        Dim dist As Double = winSrfrRow.Item(sDistanceX)

                        LoadKostiakovFromDataRow(winSrfrRow, k, a, b, c)
                        Dim dLimit As Double = 0.0
                        If (.EnableLimitingDepth.Value) Then
                            dLimit = winSrfrRow.Item(Srfr.Globals.sLimit)
                        End If

                        Dim srfrRow As DataRow = varyLoc.AddRow
                        srfrRow.Item(VaryByLoc.sDistM) = dist
                        srfrRow.Item(Srfr.Globals.sK) = k
                        srfrRow.Item(Srfr.Globals.sA) = a
                        srfrRow.Item(Srfr.Globals.sLimit) = dLimit
                    Next
                End If

            End With
        End If
    End Function

    Public Function SrfrModifiedKostiakov(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.ModifiedKostiakov
        SrfrModifiedKostiakov = Nothing

        If (WinSrfrInfiltration IsNot Nothing) Then
            With WinSrfrInfiltration

                ' Instantiate a SRFR Modified Kostiakov object
                If (.TimeOffsetC.Value) Then
                    SrfrModifiedKostiakov = New Srfr.TimeOffsetKostiakov
                Else ' Normal C
                    SrfrModifiedKostiakov = New Srfr.ModifiedKostiakov
                End If

                ' Load data common to all infiltration methods
                SrfrInfiltration(SrfrModifiedKostiakov, WinSrfrInfiltration)

                Dim k, a, b, c As Double

                ' Load Modified Kostiakov data into SRFR object
                a = .KostiakovA
                b = .KostiakovB
                c = .KostiakovC
                k = .KostiakovK

                SrfrModifiedKostiakov.a = .KostiakovA
                SrfrModifiedKostiakov.b = .KostiakovB
                SrfrModifiedKostiakov.c = .KostiakovC
                SrfrModifiedKostiakov.k = .KostiakovK

                ' If enabled, load tabulated infiltration data
                SrfrModifiedKostiakov.ClearInfiltrationDataSet()

                If (.EnableTabulatedInfiltration.Value) Then

                    Dim varyLoc As VaryByLoc = SrfrModifiedKostiakov.AddInfiltrationTable(LocTypes.ByDist, 0.0)

                    Dim modifiedKostiakovTable As DataTable = .ModifiedKostiakovTable.Value
                    For Each winSrfrRow As DataRow In modifiedKostiakovTable.Rows
                        Dim dist As Double = winSrfrRow.Item(sDistanceX)

                        LoadKostiakovFromDataRow(winSrfrRow, k, a, b, c)

                        Dim dLimit As Double = 0.0
                        If (.EnableLimitingDepth.Value) Then
                            dLimit = winSrfrRow.Item(Srfr.Globals.sLimit)
                        End If

                        Dim srfrRow As DataRow = varyLoc.AddRow
                        srfrRow.Item(VaryByLoc.sDistM) = dist
                        srfrRow.Item(Srfr.Globals.sK) = k
                        srfrRow.Item(Srfr.Globals.sA) = a
                        srfrRow.Item(Srfr.Globals.sB) = b
                        srfrRow.Item(Srfr.Globals.sC) = c
                        srfrRow.Item(Srfr.Globals.sLimit) = dLimit
                    Next
                End If

            End With
        End If
    End Function

    Public Function SrfrTimeRatedIntakeFamily(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.TimeRatedIntakeFamily
        SrfrTimeRatedIntakeFamily = Nothing

        If (WinSrfrInfiltration IsNot Nothing) Then
            With WinSrfrInfiltration

                ' Instantiate a SRFR Time-Rated Intake Family object
                SrfrTimeRatedIntakeFamily = New Srfr.TimeRatedIntakeFamily

                ' Load data common to all infiltration methods
                SrfrInfiltration(SrfrTimeRatedIntakeFamily, WinSrfrInfiltration)

                ' Load Time Rated Family data into SRFR object
                SrfrTimeRatedIntakeFamily.CorrInfiltrationTime = .InfiltrationTime_TR.Value

                ' If enabled, load tabulated infiltration data
                SrfrTimeRatedIntakeFamily.ClearInfiltrationDataSet()

                If (.EnableTabulatedInfiltration.Value) Then

                    Dim varyLoc As VaryByLoc = SrfrTimeRatedIntakeFamily.AddInfiltrationTable(LocTypes.ByDist, 0.0)

                    Dim timeRatedTable As DataTable = .TimeRatedTable.Value
                    For Each winSrfrRow As DataRow In timeRatedTable.Rows
                        Dim dist As Double = winSrfrRow.Item(sDistanceX)

                        Dim corrTime As Double = winSrfrRow.Item(Srfr.Globals.sCorrTime)

                        Dim dLimit As Double = 0.0
                        If (.EnableLimitingDepth.Value) Then
                            dLimit = winSrfrRow.Item(Srfr.Globals.sLimit)
                        End If

                        Dim srfrRow As DataRow = varyLoc.AddRow
                        srfrRow.Item(VaryByLoc.sDistM) = dist
                        srfrRow.Item(Srfr.Globals.sCorrTime) = corrTime
                        srfrRow.Item(Srfr.Globals.sLimit) = dLimit
                    Next
                End If

            End With
        End If
    End Function

    Public Function SrfrCharacteristicInfiltrationTime(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.CharacteristicInfiltrationTime
        SrfrCharacteristicInfiltrationTime = Nothing

        If (WinSrfrInfiltration IsNot Nothing) Then
            With WinSrfrInfiltration

                ' Instantiate a SRFR Characteristic Infiltration Time object
                SrfrCharacteristicInfiltrationTime = New Srfr.CharacteristicInfiltrationTime

                ' Load data common to all infiltration methods
                SrfrInfiltration(SrfrCharacteristicInfiltrationTime, WinSrfrInfiltration)

                ' Load Characteristic Infiltration Time data into SRFR object
                SrfrCharacteristicInfiltrationTime.CharInfiltrationDepth = .InfiltrationDepth_KT.Value
                SrfrCharacteristicInfiltrationTime.CharInfiltrationTime = .InfiltrationTime_KT.Value
                SrfrCharacteristicInfiltrationTime.a = .KostiakovA_KT.Value

                ' If enabled, load tabulated infiltration data
                SrfrCharacteristicInfiltrationTime.ClearInfiltrationDataSet()

                If (.EnableTabulatedInfiltration.Value) Then

                    Dim varyLoc As VaryByLoc = SrfrCharacteristicInfiltrationTime.AddInfiltrationTable(LocTypes.ByDist, 0.0)

                    Dim charTimeTable As DataTable = .CharacteristicTimeTable.Value
                    For Each winSrfrRow As DataRow In charTimeTable.Rows
                        Dim dist As Double = winSrfrRow.Item(sDistanceX)

                        Dim charDepth As Double = winSrfrRow.Item(Srfr.Globals.sCharDepth)
                        Dim charTime As Double = winSrfrRow.Item(Srfr.Globals.sCharTime)
                        Dim a As Double = winSrfrRow.Item(Srfr.Globals.sA)

                        Dim dLimit As Double = 0.0
                        If (.EnableLimitingDepth.Value) Then
                            dLimit = winSrfrRow.Item(Srfr.Globals.sLimit)
                        End If

                        Dim srfrRow As DataRow = varyLoc.AddRow
                        srfrRow.Item(VaryByLoc.sDistM) = dist
                        srfrRow.Item(Srfr.Globals.sCharDepth) = charDepth
                        srfrRow.Item(Srfr.Globals.sCharTime) = charTime
                        srfrRow.Item(Srfr.Globals.sA) = a
                        srfrRow.Item(Srfr.Globals.sLimit) = dLimit
                    Next
                End If

            End With
        End If
    End Function

    Public Function SrfrNrcsIntakeFamily(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.NrcsIntakeFamily
        SrfrNrcsIntakeFamily = Nothing

        If (WinSrfrInfiltration IsNot Nothing) Then
            With WinSrfrInfiltration

                ' Instantiate a SRFR NRCS Intake Family object
                SrfrNrcsIntakeFamily = New Srfr.NrcsIntakeFamily

                ' Load data common to all infiltration methods
                SrfrInfiltration(SrfrNrcsIntakeFamily, WinSrfrInfiltration)

                ' Load NRCS Intake Family data into SRFR object
                If (.Unit.CrossSection = CrossSections.Furrow) Then
                    SrfrNrcsIntakeFamily.WettedPerimeterMethod = Srfr.Infiltration.WettedPerimeterMethods.NRCS
                Else ' Basin|Border
                    SrfrNrcsIntakeFamily.WettedPerimeterMethod = Srfr.Infiltration.WettedPerimeterMethods.BorderWidth
                End If
                SrfrNrcsIntakeFamily.NrcsFamily = .NrcsIntakeFamily.Value
                SrfrNrcsIntakeFamily.NrcsOption = .NrcsToKostiakovMethod.Value
                SrfrNrcsIntakeFamily.c = .KostiakovC

                ' If enabled, load tabulated infiltration data
                SrfrNrcsIntakeFamily.ClearInfiltrationDataSet()

                If (.EnableTabulatedInfiltration.Value) Then

                    Dim varyLoc As VaryByLoc = SrfrNrcsIntakeFamily.AddInfiltrationTable(LocTypes.ByDist, 0.0)

                    Dim nrcsFamilyTable As DataTable = .NrcsIntakeTable.Value
                    For Each winSrfrRow As DataRow In nrcsFamilyTable.Rows
                        Dim dist As Double = winSrfrRow.Item(sDistanceX)

                        Dim nrcsFamilyName As String = winSrfrRow.Item(Srfr.Globals.sNrcsFamily)
                        Dim nrcsFamily As Srfr.NrcsIntakeFamily.NrcsIntakeFamilies = Srfr.NrcsIntakeFamily.FindNrcsIntakeFamily(nrcsFamilyName)

                        Dim dLimit As Double = 0.0
                        If (.EnableLimitingDepth.Value) Then
                            dLimit = winSrfrRow.Item(Srfr.Globals.sLimit)
                        End If

                        Dim srfrRow As DataRow = varyLoc.AddRow
                        srfrRow.Item(VaryByLoc.sDistM) = dist
                        srfrRow.Item(Srfr.Globals.sNrcsFamily) = nrcsFamily
                        srfrRow.Item(Srfr.Globals.sLimit) = dLimit
                    Next
                End If

            End With
        End If
    End Function

    Public Function SrfrBranchFunction(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.BranchFunction
        SrfrBranchFunction = Nothing

        If (WinSrfrInfiltration IsNot Nothing) Then
            With WinSrfrInfiltration

                ' Instantiate a SRFR Branch Function object
                If (.TimeOffsetC.Value) Then
                    SrfrBranchFunction = New Srfr.TimeOffsetBranch
                Else ' Time Offset C
                    SrfrBranchFunction = New Srfr.BranchFunction
                End If

                ' Load data common to all infiltration methods
                SrfrInfiltration(SrfrBranchFunction, WinSrfrInfiltration)

                Dim k, a, b, c As Double

                ' Load Branch Function data into SRFR object
                a = .KostiakovA
                b = .KostiakovB
                c = .KostiakovC
                k = .KostiakovK

                SrfrBranchFunction.a = .KostiakovA
                SrfrBranchFunction.b = .KostiakovB
                SrfrBranchFunction.c = .KostiakovC
                SrfrBranchFunction.k = .KostiakovK

                ' If enabled, load tabulated infiltration data
                SrfrBranchFunction.ClearInfiltrationDataSet()

                If (.EnableTabulatedInfiltration.Value) Then

                    Dim varyLoc As VaryByLoc = SrfrBranchFunction.AddInfiltrationTable(LocTypes.ByDist, 0.0)

                    Dim branchFunctionTable As DataTable = .BranchFunctionTable.Value
                    For Each winSrfrRow As DataRow In branchFunctionTable.Rows
                        Dim dist As Double = winSrfrRow.Item(sDistanceX)

                        LoadKostiakovFromDataRow(winSrfrRow, k, a, b, c)

                        Dim dLimit As Double = 0.0
                        If (.EnableLimitingDepth.Value) Then
                            dLimit = winSrfrRow.Item(Srfr.Globals.sLimit)
                        End If

                        Dim srfrRow As DataRow = varyLoc.AddRow
                        srfrRow.Item(VaryByLoc.sDistM) = dist
                        srfrRow.Item(Srfr.Globals.sK) = k
                        srfrRow.Item(Srfr.Globals.sA) = a
                        srfrRow.Item(Srfr.Globals.sB) = b
                        srfrRow.Item(Srfr.Globals.sC) = c
                        srfrRow.Item(Srfr.Globals.sLimit) = dLimit
                    Next
                End If

            End With
        End If
    End Function

    Public Function SrfrBranchFunction2(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.BranchFunction2
        SrfrBranchFunction2 = Nothing

        If (WinSrfrInfiltration IsNot Nothing) Then
            With WinSrfrInfiltration

                ' Instantiate a SRFR Branch Function object
                If (.TimeOffsetC.Value) Then
                    SrfrBranchFunction2 = New Srfr.TimeOffsetBranch2
                Else ' Time Offset C
                    SrfrBranchFunction2 = New Srfr.BranchFunction2
                End If

                ' Load data common to all infiltration methods
                SrfrInfiltration(SrfrBranchFunction2, WinSrfrInfiltration)

                Dim k, a, b, c, t As Double

                ' Load Branch Function data into SRFR object
                a = .KostiakovA
                b = .KostiakovB
                c = .KostiakovC
                k = .KostiakovK
                t = .BranchTime_BF.Value

                SrfrBranchFunction2.a = .KostiakovA
                SrfrBranchFunction2.b = .KostiakovB
                SrfrBranchFunction2.c = .KostiakovC
                SrfrBranchFunction2.k = .KostiakovK
                SrfrBranchFunction2.Tb = t

                ' If enabled, load tabulated infiltration data
                SrfrBranchFunction2.ClearInfiltrationDataSet()

                If (.EnableTabulatedInfiltration.Value) Then

                    Dim varyLoc As VaryByLoc = SrfrBranchFunction2.AddInfiltrationTable(LocTypes.ByDist, 0.0)

                    Dim branchFunctionTable As DataTable = .BranchFunctionTable.Value
                    For Each winSrfrRow As DataRow In branchFunctionTable.Rows
                        Dim dist As Double = winSrfrRow.Item(sDistanceX)

                        LoadKostiakovFromDataRow(winSrfrRow, k, a, b, c)
                        LoadBranchTimeFromDataRow(winSrfrRow, t)

                        Dim dLimit As Double = 0.0
                        If (.EnableLimitingDepth.Value) Then
                            dLimit = winSrfrRow.Item(Srfr.Globals.sLimit)
                        End If

                        Dim srfrRow As DataRow = varyLoc.AddRow
                        srfrRow.Item(VaryByLoc.sDistM) = dist
                        srfrRow.Item(Srfr.Globals.sK) = k
                        srfrRow.Item(Srfr.Globals.sA) = a
                        srfrRow.Item(Srfr.Globals.sB) = b
                        srfrRow.Item(Srfr.Globals.sC) = c
                        srfrRow.Item(Srfr.Globals.sTb) = t
                        srfrRow.Item(Srfr.Globals.sLimit) = dLimit
                    Next
                End If

            End With
        End If
    End Function

    Public Function SrfrGreenAmpt(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.GreenAmpt
        SrfrGreenAmpt = Nothing

        If (WinSrfrInfiltration IsNot Nothing) Then
            With WinSrfrInfiltration

                ' Instantiate a SRFR Green-Ampt object
                SrfrGreenAmpt = New Srfr.GreenAmpt

                ' Load data common to all infiltration methods
                SrfrInfiltration(SrfrGreenAmpt, WinSrfrInfiltration)

                ' Load Green-Ampt data into SRFR object
                SrfrGreenAmpt.ThetaS = .EffectivePorosityGA.Value
                SrfrGreenAmpt.Theta0 = .InitialWaterContentGA.Value
                SrfrGreenAmpt.hf = .WettingFrontPressureHeadGA.Value
                SrfrGreenAmpt.Ks = .HydraulicConductivityGA.Value
                SrfrGreenAmpt.c = .GreenAmptC.Value

                ' If enabled, load tabulated infiltration data
                SrfrGreenAmpt.ClearInfiltrationDataSet()

                If (.EnableTabulatedInfiltration.Value) Then

                    Dim varyLoc As VaryByLoc = SrfrGreenAmpt.AddInfiltrationTable(LocTypes.ByDist, 0.0)

                    Dim greenAmptTable As DataTable = .GreenAmptTable.Value
                    For Each winSrfrRow As DataRow In greenAmptTable.Rows
                        Dim dist As Double = winSrfrRow.Item(sDistanceX)

                        Dim Phi As Double = winSrfrRow.Item(Srfr.Globals.sPhi)
                        Dim Theta0 As Double = winSrfrRow.Item(Srfr.Globals.sTheta0)
                        Dim hf As Double = winSrfrRow.Item(Srfr.Globals.sHf)
                        Dim Ks As Double = winSrfrRow.Item(Srfr.Globals.sKs)
                        Dim c As Double = winSrfrRow.Item(Srfr.Globals.sC)

                        Dim dLimit As Double = 0.0
                        If (.EnableLimitingDepth.Value) Then
                            dLimit = winSrfrRow.Item(Srfr.Globals.sLimit)
                        End If

                        Dim srfrRow As DataRow = varyLoc.AddRow
                        srfrRow.Item(VaryByLoc.sDistM) = dist
                        srfrRow.Item(Srfr.Globals.sPhi) = Phi
                        srfrRow.Item(Srfr.Globals.sTheta0) = Theta0
                        srfrRow.Item(Srfr.Globals.sHf) = hf
                        srfrRow.Item(Srfr.Globals.sKs) = Ks
                        srfrRow.Item(Srfr.Globals.sC) = c
                        srfrRow.Item(Srfr.Globals.sLimit) = dLimit
                    Next
                End If

            End With
        End If

    End Function

    Public Function SrfrWarrickGreenAmpt(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.WarrickGreenAmpt
        SrfrWarrickGreenAmpt = Nothing

        If (WinSrfrInfiltration IsNot Nothing) Then
            With WinSrfrInfiltration

                ' Instantiate a SRFR Warrick / Green-Ampt object
                SrfrWarrickGreenAmpt = New Srfr.WarrickGreenAmpt

                ' Load data common to all infiltration methods
                SrfrInfiltration(SrfrWarrickGreenAmpt, WinSrfrInfiltration)

                ' Load Warrick / Green-Ampt data into SRFR object
                SrfrWarrickGreenAmpt.WettedPerimeterMethod = Infiltration.WettedPerimeterMethods.Local

                SrfrWarrickGreenAmpt.ThetaS = .SaturatedWaterContentWGA.Value
                SrfrWarrickGreenAmpt.Theta0 = .InitialWaterContentWGA.Value
                SrfrWarrickGreenAmpt.hf = .WettingFrontPressureHeadWGA.Value
                SrfrWarrickGreenAmpt.Ks = .HydraulicConductivityWGA.Value
                SrfrWarrickGreenAmpt.c = .WarrickGreenAmptC.Value
                SrfrWarrickGreenAmpt.Gamma = .WarrickGreenAmptGamma.Value
                SrfrWarrickGreenAmpt.Method = WarrickGreenAmpt.Methods.Method2

                ' If enabled, load tabulated infiltration data
                SrfrWarrickGreenAmpt.ClearInfiltrationDataSet()

                If (.EnableTabulatedInfiltration.Value) Then

                    Dim varyLoc As VaryByLoc = SrfrWarrickGreenAmpt.AddInfiltrationTable(LocTypes.ByDist, 0.0)

                    Dim warrickGreenAmptTable As DataTable = .WarrickGreenAmptTable.Value
                    For Each winSrfrRow As DataRow In warrickGreenAmptTable.Rows
                        Dim dist As Double = winSrfrRow.Item(sDistanceX)

                        Dim ThetaS As Double = winSrfrRow.Item(Srfr.Globals.sThetaS)
                        Dim Theta0 As Double = winSrfrRow.Item(Srfr.Globals.sTheta0)
                        Dim hf As Double = winSrfrRow.Item(Srfr.Globals.sHf)
                        Dim Ks As Double = winSrfrRow.Item(Srfr.Globals.sKs)
                        Dim c As Double = winSrfrRow.Item(Srfr.Globals.sC)
                        Dim Gamma As Double = winSrfrRow.Item(Srfr.Globals.sGamma)

                        Dim dLimit As Double = 0.0
                        If (.EnableLimitingDepth.Value) Then
                            dLimit = winSrfrRow.Item(Srfr.Globals.sLimit)
                        End If

                        Dim srfrRow As DataRow = varyLoc.AddRow
                        srfrRow.Item(VaryByLoc.sDistM) = dist
                        srfrRow.Item(Srfr.Globals.sThetaS) = ThetaS
                        srfrRow.Item(Srfr.Globals.sTheta0) = Theta0
                        srfrRow.Item(Srfr.Globals.sHf) = hf
                        srfrRow.Item(Srfr.Globals.sKs) = Ks
                        srfrRow.Item(Srfr.Globals.sC) = c
                        srfrRow.Item(Srfr.Globals.sGamma) = Gamma
                        srfrRow.Item(Srfr.Globals.sLimit) = dLimit
                    Next
                End If

            End With
        End If
    End Function

    Public Function SrfrHydrus1D(ByVal WinSrfrInfiltration As SoilCropProperties) As Srfr.Hydrus
        SrfrHydrus1D = Nothing

        If (WinSrfrInfiltration IsNot Nothing) Then
            With WinSrfrInfiltration

                ' Instantiate a SRFR Hydrus object
                SrfrHydrus1D = New Srfr.Hydrus

                ' Load data common to all infiltration methods
                SrfrInfiltration(SrfrHydrus1D, WinSrfrInfiltration)
                '
                ' Load Hydrus' scalar data into SRFR
                ' Hydrus' scalar data is either tabulated Infiltration Rate or Depth data
                '   Infiltration Rate data from HYDRUS does not work well in SRFR, so...
                '   Infiltration Depth data is used
                '
                SrfrHydrus1D.DistInterpolationMethod = InterpolationMethods.Linear
                SrfrHydrus1D.ClearInfiltrationDataSet()
                Dim varyLoc As VaryByLoc = SrfrHydrus1D.AddInfiltrationTable(LocTypes.ByDist, 0.0)

                'Dim hydrusInfiltration As DataSet = WinSrfrInfiltration.HydrusInfiltrationRate.Value
                Dim hydrusInfiltration As DataSet = WinSrfrInfiltration.HydrusInfiltrationDepth.Value
                If (hydrusInfiltration IsNot Nothing) Then

                    If (0 < hydrusInfiltration.Tables.Count) Then

                        For Each table As DataTable In hydrusInfiltration.Tables
                            Dim dist As Double = CDbl(table.ExtendedProperties("Dist"))
                            Dim row As DataRow = varyLoc.AddRow
                            row.Item(Srfr.VaryByLoc.sDistM) = dist
                            'row.Item(Srfr.Hydrus.sInfiltrationRateTable) = table
                            row.Item(Srfr.Hydrus.sInfiltrationDepthTable) = table
                        Next
                    Else
                        Throw New System.Exception("Invalid HYDRUS Data")
                    End If
                Else
                    Throw New System.Exception("Invalid HYDRUS Data")
                End If

                ' If enabled, load tabulated infiltration data
                SrfrHydrus1D.ClearHydrusDataSet()

                If (.EnableTabulatedInfiltration.Value) Then

                    varyLoc = SrfrHydrus1D.AddHydrusTable(LocTypes.ByDist, 0.0)

                    Dim hydrusProjectTable As DataTable = .HydrusProjectTable.Value
                    For Each winSrfrRow As DataRow In hydrusProjectTable.Rows
                        Dim dist As Double = winSrfrRow.Item(sDistanceX)

                        Dim hydrusProject As String = winSrfrRow.Item(Srfr.Hydrus.sHydrusProject)

                        Dim srfrRow As DataRow = varyLoc.AddRow
                        srfrRow.Item(VaryByLoc.sDistM) = dist
                        srfrRow.Item(Srfr.Hydrus.sHydrusProject) = hydrusProject
                    Next

                End If

            End With
        End If
    End Function
    '
    ' Load common Infiltration data into SRFR object
    '
    Private Sub SrfrInfiltration(ByVal SrfrInfiltration As Srfr.Infiltration, ByVal WinSrfrInfiltration As SoilCropProperties)
        '
        ' Wetted Perimeter, Limiting Depth & Surge 2+ Infiltration are common to all Infiltration methods
        '
        With WinSrfrInfiltration

            ' Load Wetted Perimeter
            If (.Unit.CrossSection = CrossSections.Furrow) Then
                Dim wettedPerimeterMethod As WettedPerimeterMethods = .WettedPerimeterMethod.Value
                Select Case (wettedPerimeterMethod)
                    Case WettedPerimeterMethods.LocalWettedPerimeter
                        SrfrInfiltration.WettedPerimeterMethod = Infiltration.WettedPerimeterMethods.Local
                    Case WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter
                        SrfrInfiltration.WettedPerimeterMethod = Infiltration.WettedPerimeterMethods.RepresentativeUpstream
                    Case WettedPerimeterMethods.NrcsEmpiricalFunction
                        SrfrInfiltration.WettedPerimeterMethod = Infiltration.WettedPerimeterMethods.NRCS
                    Case Else ' FurrowSpacing
                        SrfrInfiltration.WettedPerimeterMethod = Infiltration.WettedPerimeterMethods.FurrowSpacing
                End Select
            Else
                SrfrInfiltration.WettedPerimeterMethod = Infiltration.WettedPerimeterMethods.BorderWidth
            End If

            ' Load Limiting Depth
            If (.EnableLimitingDepth.Value) Then
                SrfrInfiltration.DlimitIsEnabled = True
                SrfrInfiltration.Dlimit = .LimitingDepth.Value
            Else
                SrfrInfiltration.DlimitIsEnabled = False
                SrfrInfiltration.Dlimit = 0.0
            End If

            If (.Surge2InfiltrationMethod.Value = Surge2InfiltrationMethods.BlairSmerdon) Then
                SrfrInfiltration.ReadvanceInfiltrationMethod = Infiltration.ReadvanceInfiltrationMethods.BlairSmerdon
            Else ' Izuno-Podmore
                SrfrInfiltration.ReadvanceInfiltrationMethod = Infiltration.ReadvanceInfiltrationMethods.IzunoPodmore
            End If

        End With

    End Sub

#End Region

#Region " Inflow "

    '*********************************************************************************************************
    ' Load WinSRFR's Inflow data into the appropriate SRFR Inflow object
    '*********************************************************************************************************
    Public Function SrfrInflow(ByVal winSrfrInflow As InflowManagement, _
              Optional ByVal InflowMethod As InflowMethods = InflowMethods.LowLimit) As Srfr.Inflow

        SrfrInflow = Nothing

        Try
            '
            ' Data to load into SRFR is Inflow Method dependent
            '
            If (InflowMethod = InflowMethods.LowLimit) Then
                InflowMethod = winSrfrInflow.InflowMethod.Value
            End If

            Select Case (InflowMethod)
                Case InflowMethods.StandardHydrograph
                    SrfrInflow = SrfrStandardHydrograph(winSrfrInflow)

                Case InflowMethods.Cablegation ' uses SRFR's Tabulated Inflow
                    SrfrInflow = SrfrCablegation(winSrfrInflow)

                Case InflowMethods.TabulatedInflow
                    SrfrInflow = SrfrTabulatedInflow(winSrfrInflow)

                Case InflowMethods.Surge
                    SrfrInflow = SrfrSurgeInflow(winSrfrInflow)

                Case Else
                    Throw New System.Exception("Invalid Inflow Method")
            End Select
            '
            ' Data parameters common to all Inflow Methods
            '
            SrfrInflow.L = winSrfrInflow.Unit.SystemGeometryRef.Length.Value

        Catch ex As Exception
            Dim errMsg As String = "SrfrAPI:SrfrInflow - " & ex.Message
            Throw New System.Exception(errMsg)
        End Try

    End Function

    Public Function SrfrStandardHydrograph(ByVal winSrfrInflow As InflowManagement) As Srfr.StandardHydrograph

        ' Instantiate a SRFR Standard Hydrograph object
        SrfrStandardHydrograph = New Srfr.StandardHydrograph

        ' Load data common to all inflow methods
        SrfrInflow(SrfrStandardHydrograph, winSrfrInflow)

        ' Load Standard Hydrograph data into SRFR
        With winSrfrInflow
            SrfrStandardHydrograph.Q0 = .InflowRate.Value

            SrfrStandardHydrograph.CutoffMethod = .CutoffMethod.Value
            SrfrStandardHydrograph.Tco = .CutoffTime.Value
            SrfrStandardHydrograph.R = .CutoffLocationRatio.Value
            SrfrStandardHydrograph.RDinf = .CutoffInfiltrationDepth.Value
            SrfrStandardHydrograph.RDup = .CutoffUpstreamDepth.Value
            SrfrStandardHydrograph.TnR = .CutoffOpportunityTime.Value

            SrfrStandardHydrograph.CutbackMethod = .CutbackMethod.Value
            SrfrStandardHydrograph.RXcb = .CutbackLocationRatio.Value
            SrfrStandardHydrograph.RQcb = .CutbackRateRatio.Value
            SrfrStandardHydrograph.RTcb = .CutbackTimeRatio.Value
        End With

    End Function

    Public Function SrfrCablegation(ByVal winSrfrInflow As InflowManagement) As Srfr.TabulatedInflow

        ' Instantiate a SRFR Tabulated Inflow object
        SrfrCablegation = New Srfr.TabulatedInflow

        ' Load data common to all infiltration methods
        SrfrInflow(SrfrCablegation, winSrfrInflow)

        ' Load Cablegation Inflow data into SRFR
        With winSrfrInflow
            Dim inflowTable As DataTable = .CablegationInflowTable

            SrfrCablegation.ClearInflowTable()

            For Each row As DataRow In inflowTable.Rows
                Dim time As Double = row.Item(sTimeX)
                Dim inflow As Double = row.Item(sInflowX)

                SrfrCablegation.AddInflowChange(time, inflow)
            Next row

        End With

    End Function

    Public Function SrfrTabulatedInflow(ByVal winSrfrInflow As InflowManagement) As Srfr.TabulatedInflow

        ' Instantiate a SRFR Tabulated Inflow object
        SrfrTabulatedInflow = New Srfr.TabulatedInflow

        ' Load data common to all infiltration methods
        SrfrInflow(SrfrTabulatedInflow, winSrfrInflow)

        ' Load Cablegation Inflow data into SRFR
        With winSrfrInflow
            Dim inflowTable As DataTable = .TabulatedInflow.Value

            SrfrTabulatedInflow.ClearInflowTable()

            For Each row As DataRow In inflowTable.Rows
                Dim time As Double = row.Item(sTimeX)
                Dim inflow As Double = row.Item(sInflowX)

                SrfrTabulatedInflow.AddInflowChange(time, inflow)
            Next row

        End With

    End Function

    Public Function SrfrSurgeInflow(ByVal winSrfrInflow As InflowManagement) As Srfr.SurgeInflow

        ' Instantiate a SRFR Surge Inflow object
        SrfrSurgeInflow = New Srfr.SurgeInflow

        ' Load data common to all inflow methods
        SrfrInflow(SrfrSurgeInflow, winSrfrInflow)

        ' Load Surge Inflow data into SRFR
        With winSrfrInflow
            Dim Qin As Double = .SurgeInflowRate.Value
            Dim L As Double = .Unit.SystemGeometryRef.Length.Value

            SrfrSurgeInflow.Q0 = Qin
            SrfrSurgeInflow.Tco = .SurgeCutoffTime.Value
            SrfrSurgeInflow.SurgeOnTime = .SurgeOnTime.Value

            SrfrSurgeInflow.ClearSurgeTimeTable()
            SrfrSurgeInflow.ClearSurgeDistanceTable()

            Select Case (.SurgeStrategy.Value)

                Case SurgeStrategies.UniformLocation

                    Dim numSurges As Integer = .NumberOfSurges.Value

                    For surgeNum As Integer = 1 To numSurges
                        Dim dist As Double = L * surgeNum / numSurges

                        SrfrSurgeInflow.AddSurgeDistanceEntry(dist, Qin)
                    Next surgeNum

                Case SurgeStrategies.TabulatedLocation

                    Dim surgeTable As DataTable = .SurgeLocationsTable.Value
                    For Each row As DataRow In surgeTable.Rows
                        Dim location As Double = row.Item(sLocationX)
                        Dim dist As Double = L * location

                        SrfrSurgeInflow.AddSurgeDistanceEntry(dist, Qin)
                    Next row

                Case SurgeStrategies.TabulatedTime

                    SrfrSurgeInflow.Tco = 0

                    Dim surgeTable As DataTable = .SurgeTimesTable.Value
                    For Each row As DataRow In surgeTable.Rows
                        Dim onTime As Double = row.Item(sStartTimeX)
                        Dim offTime As Double = row.Item(sEndTimeX)

                        SrfrSurgeInflow.AddSurgeTimeEntry(onTime, offTime, Qin)

                        If (SrfrSurgeInflow.Tco < offTime) Then
                            SrfrSurgeInflow.Tco = offTime
                        End If
                    Next row

                Case Else ' assume SurgeStrategies.UniformTime

                    Dim onTime As Double = 0.0
                    Dim offTime As Double = onTime + .SurgeOnTime.Value
                    Dim Tco As Double = .SurgeCutoffTime.Value

                    While (offTime < Tco)
                        SrfrSurgeInflow.AddSurgeTimeEntry(onTime, offTime, Qin)
                        onTime = offTime + .SurgeOnTime.Value
                        offTime = onTime + .SurgeOnTime.Value
                    End While

                    If (onTime < Tco) Then
                        SrfrSurgeInflow.AddSurgeTimeEntry(onTime, Tco, Qin)
                    End If
            End Select
        End With

    End Function
    '
    ' Load common Inflow data into SRFR
    '
    Private Sub SrfrInflow(ByVal srfrInflow As Srfr.Inflow, ByVal winSrfrInflow As InflowManagement)
        '
        ' Target Depth (Dreq) & Water Cost are common to all Inflow methods
        '
        With winSrfrInflow
            srfrInflow.Dreq = .RequiredDepth.Value
            srfrInflow.Tdd = .DrawDownTime.Value
            srfrInflow.UnitWaterCost = .UnitWaterCost.Value
            'srfrInflow.UnitLaborCost = .UnitLaborCost.Value
        End With

    End Sub

#End Region

#End Region

#Region " SRFR Irrigation Calculations "

#Region " Infiltration "

    '*************************************************************************************************************
    ' Calculate Infiltration Function for non-depth dependent infiltration methods (e.g. Kostiakov, Branch, etc.)
    '*************************************************************************************************************
    Public Function InfiltrationFunction(ByVal Tend As Double, ByVal NumPoints As Integer, _
                                         ByVal WinSrfrInfiltration As SoilCropProperties) As DataTable
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationFunction = SrfrInfiltration.InfiltrationFunction(Tend, NumPoints)
        InfiltrationFunction.TableName = sInfiltrationFunction
        InfiltrationFunction.Columns(0).ColumnName = sTimeX
        InfiltrationFunction.Columns(1).ColumnName = sInfiltrationX
    End Function

    Public Function InfiltrationFunction(ByVal Tend As Double, ByVal NumPoints As Integer, _
                                         ByVal SrfrInfiltration As Srfr.Infiltration) As DataTable
        InfiltrationFunction = SrfrInfiltration.InfiltrationFunction(Tend, NumPoints)
        InfiltrationFunction.TableName = sInfiltrationFunction
        InfiltrationFunction.Columns(0).ColumnName = sTimeX
        InfiltrationFunction.Columns(1).ColumnName = sInfiltrationX
    End Function

    Public Function InfiltrationFunctionTimes(ByVal Tend As Double, ByVal NumPoints As Integer, _
                                              ByVal WinSrfrInfiltration As SoilCropProperties) As ArrayList
        InfiltrationFunctionTimes = New ArrayList

        Dim SrfrInfiltration As DataTable = InfiltrationFunction(Tend, NumPoints, WinSrfrInfiltration)

        For Each row As DataRow In SrfrInfiltration.Rows
            Dim Tau As Double = CDbl(row.Item(0))
            InfiltrationFunctionTimes.Add(Tau)
        Next row
    End Function

    Public Function InfiltrationFunctionDepths(ByVal Tend As Double, ByVal NumPoints As Integer, _
                                               ByVal WinSrfrInfiltration As SoilCropProperties) As ArrayList
        InfiltrationFunctionDepths = New ArrayList

        Dim SrfrInfiltration As DataTable = InfiltrationFunction(Tend, NumPoints, WinSrfrInfiltration)

        For Each row As DataRow In SrfrInfiltration.Rows
            Dim Z As Double = CDbl(row.Item(1))
            InfiltrationFunctionDepths.Add(Z)
        Next row
    End Function

    Public Function InfiltrationFunction(ByVal Tend As Double, ByVal RowIdx As Integer, ByVal NumPoints As Integer, _
                                         ByVal WinSrfrInfiltration As SoilCropProperties) As DataTable
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationFunction = SrfrInfiltration.InfiltrationFunction(Tend, RowIdx, NumPoints)
        InfiltrationFunction.TableName = sInfiltrationFunction
        InfiltrationFunction.Columns(0).ColumnName = sTimeX
        InfiltrationFunction.Columns(1).ColumnName = sInfiltrationX
    End Function

    Public Function InfiltrationFunction(ByVal Tend As Double, ByVal RowIdx As Integer, ByVal NumPoints As Integer, _
                                         ByVal SrfrInfiltration As Srfr.Infiltration) As DataTable
        InfiltrationFunction = SrfrInfiltration.InfiltrationFunction(Tend, RowIdx, NumPoints)
        InfiltrationFunction.TableName = sInfiltrationFunction
        InfiltrationFunction.Columns(0).ColumnName = sTimeX
        InfiltrationFunction.Columns(1).ColumnName = sInfiltrationX
    End Function

    Public Function InfiltrationFunctionTimes(ByVal Tend As Double, ByVal RowIdx As Integer, ByVal NumPoints As Integer, _
                                              ByVal WinSrfrInfiltration As SoilCropProperties) As ArrayList
        InfiltrationFunctionTimes = New ArrayList

        Dim SrfrInfiltration As DataTable = InfiltrationFunction(Tend, RowIdx, NumPoints, WinSrfrInfiltration)

        For Each row As DataRow In SrfrInfiltration.Rows
            Dim Tau As Double = CDbl(row.Item(0))
            InfiltrationFunctionTimes.Add(Tau)
        Next row
    End Function

    Public Function InfiltrationFunctionDepths(ByVal Tend As Double, ByVal RowIdx As Integer, ByVal NumPoints As Integer, _
                                               ByVal WinSrfrInfiltration As SoilCropProperties) As ArrayList
        InfiltrationFunctionDepths = New ArrayList

        Dim SrfrInfiltration As DataTable = InfiltrationFunction(Tend, RowIdx, NumPoints, WinSrfrInfiltration)

        For Each row As DataRow In SrfrInfiltration.Rows
            Dim Z As Double = CDbl(row.Item(1))
            InfiltrationFunctionDepths.Add(Z)
        Next row
    End Function

    '*********************************************************************************************************
    ' Calculate Infiltration Function for depth dependent, tabulated infiltration methods
    '*********************************************************************************************************
    Public Function InfiltrationFunction(ByVal Tend As Double, ByVal Y As Double,
                                         ByVal RowIdx As Integer, ByVal NumPoints As Integer,
                                         ByVal WinSrfrInfiltration As SoilCropProperties) As DataTable
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationFunction = SrfrInfiltration.InfiltrationFunction(Tend, Y, RowIdx, NumPoints)
        InfiltrationFunction.TableName = sInfiltrationFunction
        InfiltrationFunction.Columns(0).ColumnName = sTimeX
        InfiltrationFunction.Columns(1).ColumnName = sInfiltrationX
    End Function

    '*********************************************************************************************************
    ' Calculate Z, dZdT & Tau for depth dependent infiltration methods (e.g. Green-Ampt, Warrick / Green-Ampt)
    '*********************************************************************************************************
    Public Function InfiltrationDepth(ByVal Tau As Double, ByVal Y As Double, _
                                      ByVal WinSrfrInfiltration As SoilCropProperties) As Double
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationDepth = SrfrInfiltration.InfiltrationDepth(Tau, Y)
    End Function

    Public Function InfiltrationDepth(ByVal Tau As Double, ByVal Y As Double, _
                                      ByVal SrfrInfiltration As Srfr.Infiltration) As Double
        InfiltrationDepth = SrfrInfiltration.InfiltrationDepth(Tau, Y)
    End Function

    Public Function InfiltrationDepth(ByVal Tau As Double, ByVal FlowDepthHydrograph As DataTable, _
                                      ByVal WinSrfrInfiltration As SoilCropProperties) As Double
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationDepth = SrfrInfiltration.InfiltrationDepth(Tau, FlowDepthHydrograph)
    End Function

    Public Function InfiltrationDepth(ByVal Tau As Double, ByVal FlowDepthHydrograph As DataTable, _
                                      ByVal SrfrInfiltration As Srfr.Infiltration) As Double
        InfiltrationDepth = SrfrInfiltration.InfiltrationDepth(Tau, FlowDepthHydrograph)
    End Function

    Public Function InfiltrationRate(ByVal Tau As Double, ByVal Y As Double, _
                                     ByVal WinSrfrInfiltration As SoilCropProperties) As Double
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationRate = SrfrInfiltration.InfiltrationRate(Tau, Y)
    End Function

    Public Function InfiltrationRate(ByVal Tau As Double, ByVal Y As Double, _
                                     ByVal SrfrInfiltration As Srfr.Infiltration) As Double
        InfiltrationRate = SrfrInfiltration.InfiltrationRate(Tau, Y)
    End Function

    Public Function InfiltrationRate(ByVal Tau As Double, ByVal FlowDepthHydrograph As DataTable, _
                                     ByVal WinSrfrInfiltration As SoilCropProperties) As Double
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationRate = SrfrInfiltration.InfiltrationRate(Tau, FlowDepthHydrograph)
    End Function

    Public Function InfiltrationRate(ByVal Tau As Double, ByVal FlowDepthHydrograph As DataTable, _
                                     ByVal SrfrInfiltration As Srfr.Infiltration) As Double
        InfiltrationRate = SrfrInfiltration.InfiltrationRate(Tau, FlowDepthHydrograph)
    End Function

    Public Function InfiltrationTime(ByVal Zn As Double, ByVal WP As Double, ByVal FS As Double, _
                                     ByVal WinSrfrInfiltration As SoilCropProperties) As Double
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationTime = SrfrInfiltration.InfiltrationTime(Zn, WP, FS)
    End Function

    Public Function InfiltrationTime(ByVal Zn As Double, ByVal WP As Double, ByVal FS As Double, _
                                     ByVal SrfrInfiltration As Srfr.Infiltration) As Double
        InfiltrationTime = SrfrInfiltration.InfiltrationTime(Zn, WP, FS)
    End Function

    Public Function InfiltrationTime(ByVal Zn As Double, ByVal Y As Double, _
                                     ByVal WinSrfrInfiltration As SoilCropProperties) As Double
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationTime = SrfrInfiltration.InfiltrationTime(Zn, Y)
    End Function

    Public Function InfiltrationTime(ByVal Zn As Double, ByVal Y As Double, _
                                     ByVal SrfrInfiltration As Srfr.Infiltration) As Double
        InfiltrationTime = SrfrInfiltration.InfiltrationTime(Zn, Y)
    End Function

    Public Function InfiltrationTime(ByVal Zn As Double, ByVal FlowDepthHydrograph As DataTable, _
                                     ByVal WinSrfrInfiltration As SoilCropProperties) As Double
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationTime = SrfrInfiltration.InfiltrationTime(Zn, FlowDepthHydrograph)
    End Function

    Public Function InfiltrationTime(ByVal Zn As Double, ByVal FlowDepthHydrograph As DataTable, _
                                     ByVal SrfrInfiltration As Srfr.Infiltration) As Double
        InfiltrationTime = SrfrInfiltration.InfiltrationTime(Zn, FlowDepthHydrograph)
    End Function


    Public Function InfiltrationTime(ByVal Zn As Double, ByVal RowIdx As Integer, ByVal Y As Double, _
                                     ByVal WinSrfrInfiltration As SoilCropProperties) As Double
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationTime = SrfrInfiltration.InfiltrationTime(Zn, RowIdx, Y)
    End Function

    Public Function InfiltrationTime(ByVal Zn As Double, ByVal RowIdx As Integer, ByVal Y As Double, _
                                     ByVal SrfrInfiltration As Srfr.Infiltration) As Double
        InfiltrationTime = SrfrInfiltration.InfiltrationTime(Zn, RowIdx, Y)
    End Function

    '*********************************************************************************************************************************
    ' Calculate Infiltration Function for depth dependent infiltration methods (e.g. Green-Ampt, Warrick / Green-Ampt)
    '*********************************************************************************************************************************
    Public Function InfiltrationFunction(ByVal Tend As Double, ByVal Y As Double, ByVal NumPoints As Integer, _
                                         ByVal WinSrfrInfiltration As SoilCropProperties) As DataTable
        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)
        InfiltrationFunction = SrfrInfiltration.InfiltrationFunction(Tend, Y, NumPoints)
        InfiltrationFunction.TableName = sInfiltrationFunction
        InfiltrationFunction.Columns(0).ColumnName = sTimeX
        InfiltrationFunction.Columns(1).ColumnName = sInfiltrationX
    End Function

    Public Function InfiltrationFunction(ByVal Tend As Double, ByVal Y As Double, ByVal NumPoints As Integer, _
                                         ByVal SrfrInfiltration As Srfr.Infiltration) As DataTable
        InfiltrationFunction = SrfrInfiltration.InfiltrationFunction(Tend, Y, NumPoints)
        InfiltrationFunction.TableName = sInfiltrationFunction
        InfiltrationFunction.Columns(0).ColumnName = sTimeX
        InfiltrationFunction.Columns(1).ColumnName = sInfiltrationX
    End Function

    Public Function InfiltrationFunctionTimes(ByVal Tend As Double, ByVal Y As Double, ByVal NumPoints As Integer, _
                                              ByVal WinSrfrInfiltration As SoilCropProperties) As ArrayList
        InfiltrationFunctionTimes = New ArrayList

        Dim SrfrInfiltration As DataTable = InfiltrationFunction(Tend, Y, NumPoints, WinSrfrInfiltration)

        For Each row As DataRow In SrfrInfiltration.Rows
            Dim Tau As Double = CDbl(row.Item(0))
            InfiltrationFunctionTimes.Add(Tau)
        Next row
    End Function

    Public Function InfiltrationFunctionDepths(ByVal Tend As Double, ByVal Y As Double, ByVal NumPoints As Integer, _
                                               ByVal WinSrfrInfiltration As SoilCropProperties) As ArrayList
        InfiltrationFunctionDepths = New ArrayList

        Dim SrfrInfiltration As DataTable = InfiltrationFunction(Tend, Y, NumPoints, WinSrfrInfiltration)

        For Each row As DataRow In SrfrInfiltration.Rows
            Dim Z As Double = CDbl(row.Item(1))
            InfiltrationFunctionDepths.Add(Z)
        Next row
    End Function

    '*********************************************************************************************************************************
    ' Integrate Infiltration Profile for all infiltration methods (e.g. Kostiakov, Branch, etc.)
    '*********************************************************************************************************************************
    Public Function InfiltrationProfile_GQ(ByVal Xa As Double, ByVal Txa As Double, ByVal T As Double, ByVal r As Double, _
                                           ByVal NS As Integer, ByVal WinSrfrInfiltration As SoilCropProperties, _
                                           Optional ByVal RefSrfrAPI As Srfr.SrfrAPI = Nothing) As Double

        Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(WinSrfrInfiltration)

        SrfrInfiltration.RefSrfrAPI = RefSrfrAPI

        InfiltrationProfile_GQ = SrfrInfiltration.InfiltrationProfile_GQ(Xa, Txa, T, r, NS)
    End Function

    Public Function InfiltrationProfile_GQ(ByVal Xa As Double, ByVal Txa As Double, ByVal T As Double, ByVal r As Double, _
                                           ByVal NS As Integer, ByVal SrfrInfiltration As Srfr.Infiltration, _
                                           Optional ByVal RefSrfrAPI As Srfr.SrfrAPI = Nothing) As Double

        SrfrInfiltration.RefSrfrAPI = RefSrfrAPI

        InfiltrationProfile_GQ = SrfrInfiltration.InfiltrationProfile_GQ(Xa, Txa, T, r, NS)
    End Function

#End Region

#End Region

#Region " SRFR Simulation Execution "

#Region " Load SRFR Inputs "

    '*********************************************************************************************************
    ' LoadSrfrInputs() - load SRFR's Inputs objects with WinSRFR values
    '*********************************************************************************************************
    Public Function LoadSrfrInputs(ByVal srfr As Srfr.SrfrAPI, ByVal unit As Unit) As Boolean

        Try
            '
            ' Instantiate and fill each SRFR Input object with WinSRFR values
            '
            Dim SrfrCrossSection As Srfr.CrossSection = SrfrAPI.SrfrCrossSection(unit.SystemGeometryRef)
            Dim SrfrRoughness As Srfr.Roughness = SrfrAPI.SrfrRoughness(unit.SoilCropPropertiesRef)
            Dim SrfrInfiltration As Srfr.Infiltration = SrfrAPI.SrfrInfiltration(unit.SoilCropPropertiesRef)
            Dim SrfrInflow As Srfr.Inflow = SrfrAPI.SrfrInflow(unit.InflowManagementRef)
            Dim SrfrConstituentTransport As Srfr.ConstituentTransport = SrfrAPI.SrfrConstituentTransport(srfr, unit)
            '
            ' Load SRFR with the Input objects
            '
            srfr.CrossSection = SrfrCrossSection
            srfr.Roughness = SrfrRoughness
            srfr.Infiltration = SrfrInfiltration
            srfr.Inflow = SrfrInflow
            srfr.ConstituentTransport = SrfrConstituentTransport

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "SRFR Inputs Invalid")
            Return False
        End Try

        Return True
    End Function

#Region " Constituent Transport "
    '
    ' Load WinSRFR's Constituent Transport data into the appropriate SRFR Constituent Transport object
    '
    Public Function SrfrConstituentTransport(ByVal srfr As Srfr.SrfrAPI, ByVal unit As Unit) As Srfr.ConstituentTransport
        SrfrConstituentTransport = Nothing

        Try
            Dim winSrfrErosion As Erosion = unit.ErosionRef
            With winSrfrErosion

                If (.EnableErosion.Value) Then
                    Dim srfrSedimentTransport As Srfr.SedimentTransport = New Srfr.SedimentTransport(srfr)
                    SrfrConstituentTransport = srfrSedimentTransport

                    srfrSedimentTransport.TransportIsEnabled = True

                    srfrSedimentTransport.CharacteristicType = ConstituentTransport.CharacteristicTypes.Continuous
                    srfrSedimentTransport.UseTcsRep = winSrfrErosion.EnableCriticalShear.Value

                    srfrSedimentTransport.DsRep = winSrfrErosion.ParticleDiameter.Value
                    srfrSedimentTransport.SgRep = winSrfrErosion.SpecificGravity.Value
                    srfrSedimentTransport.TcsRep = winSrfrErosion.CriticalShear.Value
                    srfrSedimentTransport.Kr = winSrfrErosion.Kr.Value
                    srfrSedimentTransport.Nu = winSrfrErosion.KinematicViscosity.Value

                    Exit Try
                End If
            End With

            Dim winSrfrFertigation As Fertigation = unit.FertigationRef
            With winSrfrFertigation

                If (.EnableFertigation.Value) Then
                    Dim srfrSoluteTransport As Srfr.SoluteTransport = New Srfr.SoluteTransport(srfr)
                    SrfrConstituentTransport = srfrSoluteTransport

                    srfrSoluteTransport.TransportIsEnabled = True

                    Dim tankCo As Double = winSrfrFertigation.TankConcentration.Value

                    srfrSoluteTransport.AddInjectionTable("", 0.0, tankCo)

                    Dim injTable As DataTable = winSrfrFertigation.TabulatedInjectionRate.Value
                    For Each injRow As DataRow In injTable.Rows
                        Dim time As Double = injRow.Item(0)
                        Dim injRate As Double = injRow.Item(1)

                        srfrSoluteTransport.AddInjectionPulse(time, injRate)
                    Next

                    srfrSoluteTransport.CharacteristicType = winSrfrFertigation.CharacteristicType.Value
                    srfrSoluteTransport.AdvectionInterpolationMethod = winSrfrFertigation.AdvectionInterpolationMethod.Value
                    srfrSoluteTransport.IncludeDispersion = winSrfrFertigation.IncludeDispersion.Value
                    srfrSoluteTransport.DispersivityCoefficientMethod = winSrfrFertigation.DispersivityCoefficientMethod.Value
                    srfrSoluteTransport.ElderCe = winSrfrFertigation.ElderCe.Value
                    srfrSoluteTransport.SpecifiedKx = winSrfrFertigation.SpecifiedKx.Value

                    Exit Try
                End If
            End With

        Catch ex As Exception
            Dim errMsg As String = "SrfrAPI:SrfrConstituentTransport - " & ex.Message
            Throw New System.Exception(errMsg)
        End Try

    End Function

#End Region

#End Region

#Region " Load SRFR Criteria "

    '*********************************************************************************************************
    ' LoadSrfrCriteria() - load WinSRFR UI values for Srfr Criteria into SRFR.
    '*********************************************************************************************************
    Public Sub LoadSrfrCriteria(ByVal unit As Unit, ByVal solmod As SolutionModel)

        Dim criteria As SrfrCriteria = unit.SrfrCriteriaRef

        solmod.CellDensity = criteria.CellDensity.Value

        ' Diagnostics available to Researcher & Programmer
        If (WinSRFR.IsResearchLevel Or WinSRFR.DebuggerIsAttached) Then
            solmod.EnableDiagnostics = criteria.EnableDiagnostics.Value
        Else
            solmod.EnableDiagnostics = False
        End If

        ' SRFR controls available to Researcher
        If (WinSRFR.IsResearchLevel) Then
            ' Shape factors
            Dim phiAYL As DoubleParameter = criteria.PhiAYL_KW
            If Not (phiAYL.Source = ValueSources.Defaulted) Then
                solmod.PhiAYL = phiAYL.Value
            End If

            Dim phiAZL As DoubleParameter = criteria.PhiAZL
            If Not (phiAZL.Source = ValueSources.Defaulted) Then
                solmod.PhiAZL = phiAZL.Value
            End If

            Dim theta As DoubleParameter = criteria.Theta
            If Not (theta.Source = ValueSources.Defaulted) Then
                solmod.Theta = theta.Value
            End If
        End If

        solmod.StopCriteria = SolutionModel.StopCriterion.None

    End Sub

#End Region

#Region " Unload SRFR Results "

    '*********************************************************************************************************
    ' UnloadSrfrResults() - transfers SRFR Results data into WinSRFR DataStore Results
    '*********************************************************************************************************
    Public Function UnloadSrfrResults(ByVal srfrAPI As Srfr.SrfrAPI, ByVal unit As Unit, ByVal compareRun As Boolean, _
                                ByVal skipProfiles As Boolean, ByVal skipHydroGraphs As Boolean) As Irrigation

        ' SRFR Results
        Dim srfrIrrigation As Irrigation = srfrAPI.Irrigation
        Dim srfrTransport As ConstituentTransport = srfrAPI.ConstituentTransport
        Dim lastTimestep As Timestep = srfrIrrigation.LastTimestep

        ' WinSRFR Results
        Dim winSrfrSysGeo As SystemGeometry = unit.SystemGeometryRef
        Dim winSrfrInflow As InflowManagement = unit.InflowManagementRef
        Dim winSrfrCriteria As SrfrCriteria = unit.SrfrCriteriaRef
        '
        ' Load WinSRFR Results with SRFR Results
        '
        Dim ldx As Integer
        Dim dValue As Double
        Dim table As DataTable
        Dim dSet As DataSet

        Dim bParam As BooleanParameter
        Dim dParam As DoubleParameter
        Dim tParam As DataTableParameter
        Dim dsParam As DataSetParameter
        '
        ' Profiles & Hydrographs need time & distance locations, respectively
        '
        Dim length As Double = winSrfrSysGeo.Length.Value

        tParam = winSrfrCriteria.ProfileTable                           ' Times (T) for Profiles
        Dim times As List(Of Double) = DoubleColumn(tParam.Value, 0)
        If (times Is Nothing) Then
            times = New List(Of Double)
        End If

        tParam = winSrfrCriteria.HydrographTable                        ' Distances (X) for Hydrographs
        Dim dists As List(Of Double) = DoubleColumn(tParam.Value, 0)
        If (dists Is Nothing) Then
            dists = New List(Of Double)
        End If
        If (dists.Count = 0) Then
            dists.Add(0.0)
            dists.Add(length)
        End If

        Dim dist0 As Double = dists(0)
        Dim distL As Double = dists(dists.Count - 1)
        If ((Not dist0 = 0.0) Or (Not distL = length)) Then
            ' Distances do not span field; adjust them so they do
            Dim span As Double = distL - dist0
            For ddx As Integer = 0 To dists.Count - 2
                Dim dist As Double = dists(ddx)
                ' Calculate hydrograph location as ratio of table values to actual length
                Dim adjDist As Double = ((dist - dist0) * length) / span
                dists(ddx) = adjDist
            Next
            dists(dists.Count - 1) = length ' Last distance must by Length
        End If
        '
        ' Comparison runs return only a subset of the full SRFR results
        '
        If (compareRun) Then ' SRFR being run for comparison results only

            Dim winSrfrSurfaceFlow As SurfaceFlow = unit.SurfaceFlowRef

            dValue = srfrIrrigation.Ymax                            ' Maximum Flow Depth (Ymax)
            dParam = winSrfrSurfaceFlow.Ymax
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.Ymax = dParam
            '
            ' Comparison results are stored in SrfrResults object
            '
            Dim winSrfrResults As SrfrResults = unit.SrfrResultsRef

            '*************************************************************************************************
            ' Advance, Recession & Infiltration Curves
            '*************************************************************************************************

            table = srfrIrrigation.AdvanceCurve                             ' Advance Curve
            tParam = winSrfrResults.Advance
            tParam.Value = table
            tParam.Source = ValueSources.Calculated
            winSrfrResults.Advance = tParam

            table = srfrIrrigation.RecessionCurve                           ' Recession Curve
            tParam = winSrfrResults.Recession
            tParam.Value = table
            tParam.Source = ValueSources.Calculated
            winSrfrResults.Recession = tParam

            table = srfrIrrigation.InfiltrationCurve                        ' Infiltration Profile
            tParam = winSrfrResults.LongitudinalInfiltration
            tParam.Value = table
            tParam.Source = ValueSources.Calculated
            winSrfrResults.LongitudinalInfiltration = tParam

            '*************************************************************************************************
            ' Hydrographs
            '*************************************************************************************************

            table = srfrIrrigation.Hydrographs("Q", dists)                  ' Flow Rate (Q) Flow Hydrographs
            table.Columns(0).ColumnName = sTimeX
            table.Columns(1).ColumnName = sQinX
            table.Columns(table.Columns.Count - 1).ColumnName = sRunoffX

            tParam = winSrfrResults.FlowHydrographs
            tParam.Value = table
            tParam.Source = ValueSources.Calculated
            winSrfrResults.FlowHydrographs = tParam

            '*************************************************************************************************
            ' Overflow
            '*************************************************************************************************

            Dim dist, time As Double
            Dim overflow As Boolean = srfrIrrigation.Overflow(dist, time)

            bParam = winSrfrResults.Overflow                                ' Overflow
            bParam.Value = overflow
            bParam.Source = ValueSources.Calculated
            winSrfrResults.Overflow = bParam

            dParam = winSrfrResults.OverflowDist                            ' Overflow distance
            dParam.Value = dist
            dParam.Source = ValueSources.Calculated
            winSrfrResults.OverflowDist = dParam

            dParam = winSrfrResults.OverflowTime                            ' Overflow Time
            dParam.Value = time
            dParam.Source = ValueSources.Calculated
            winSrfrResults.OverflowTime = dParam

        Else ' Not (compareRun)
            '
            ' Full results are stored throughtout I/O objects
            '
            Dim winSrfrErosion As Erosion = unit.ErosionRef
            Dim winSrfrFertigation As Fertigation = unit.FertigationRef
            Dim winSrfrSurfaceFlow As SurfaceFlow = unit.SurfaceFlowRef
            Dim winSrfrSubsurfaceFlow As SubsurfaceFlow = unit.SubsurfaceFlowRef
            Dim winSrfrPerformanceResults As PerformanceResults = unit.PerformanceResultsRef

            '*************************************************************************************************
            ' Performance Indicators
            '*************************************************************************************************

            dValue = srfrIrrigation.Dapp                            ' Applied Depth (Dapp)
            dParam = winSrfrSubsurfaceFlow.Dapp
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.Dapp = dParam

            dParam = winSrfrSurfaceFlow.DappG                       ' (Dapp G)
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.DappG = dParam

            dValue = srfrIrrigation.Ddbk                            ' Drainback Depth (Ddp)
            dParam = winSrfrSurfaceFlow.Ddb
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.Ddb = dParam

            dValue = srfrIrrigation.Dinf                            ' Infiltrated Depth (Dinf)
            dParam = winSrfrSubsurfaceFlow.Davg
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.Davg = dParam

            dValue = srfrIrrigation.Ddp                             ' Deep Percolation Depth (Ddp)
            dParam = winSrfrSubsurfaceFlow.DP
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.DP = dParam

            dValue = srfrIrrigation.Dlq                             ' Low-Quarter Depth (Dlq)
            dParam = winSrfrSubsurfaceFlow.Dlq
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.Dlq = dParam

            dValue = srfrIrrigation.Dro                             ' Runoff Depth (Dro)
            dParam = winSrfrSurfaceFlow.ROd
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.ROd = dParam

            dValue = srfrIrrigation.Dmin                            ' Minimum Depth (Dmin)
            dParam = winSrfrSubsurfaceFlow.Dmin
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.Dmin = dParam

            dValue = srfrIrrigation.Q0avg                           ' Average Inflow Rate (Q0avg)
            dParam = winSrfrSurfaceFlow.Q0avg
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.Q0avg = dParam

            dValue = srfrIrrigation.Ymax                            ' Maximum Flow Depth (Ymax)
            dParam = winSrfrSurfaceFlow.Ymax
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.Ymax = dParam

            dValue = srfrIrrigation.WPnrcs                          ' NRCS Upstream Wetted Perimeter (WPnrcs)
            dParam = winSrfrSurfaceFlow.NrcsWettedPerimeter
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.NrcsWettedPerimeter = dParam

            dValue = srfrIrrigation.WPup                            ' Representative Upstream Wetted Perimeter (WPup)
            dParam = winSrfrSurfaceFlow.RepresentativeWettedPerimeter
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.RepresentativeWettedPerimeter = dParam

            dValue = srfrIrrigation.Tco                             ' Cutoff time (Tco)
            dParam = winSrfrSurfaceFlow.Tco
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.Tco = dParam

            ' Save Simulation's Cutoff time if Cutoff by Distance
            If (winSrfrInflow.InflowMethod.Value = InflowMethods.StandardHydrograph) Then
                dParam = winSrfrInflow.CutoffTime
                If Not (dParam.Value = dValue) Then
                    dParam.Value = dValue
                    dParam.Source = ValueSources.Calculated
                    winSrfrInflow.CutoffTime = dParam
                End If
            End If

            dValue = srfrIrrigation.XadvMax                         ' Max advance distance (Xmax)
            dParam = winSrfrSurfaceFlow.Xmax
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.Xmax = dParam

            dValue = srfrIrrigation.TadvMax                         ' Max advance time (Txa)
            dParam = winSrfrSurfaceFlow.Txa
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.Txa = dParam

            dValue = srfrIrrigation.TL                              ' Time advance reached end-of-field (TL)
            dParam = winSrfrSurfaceFlow.TL
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.TL = dParam

            dValue = srfrIrrigation.XR                              ' Cutoff ratio (XR)
            dParam = winSrfrSurfaceFlow.XaR
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.XaR = dParam

            dValue = srfrIrrigation.RE                              ' Requirement Efficiency (RE)
            dParam = winSrfrSubsurfaceFlow.RE
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.RE = dParam

            dValue = srfrIrrigation.AE                              ' Application Efficiency (AE)
            dParam = winSrfrSubsurfaceFlow.AE
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.AE = dParam

            dValue = srfrIrrigation.PAElq                           ' Potential Application Efficiency (PAElq)
            dParam = winSrfrSubsurfaceFlow.PAElq
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.PAElq = dParam

            dValue = srfrIrrigation.PAEmin                          ' Potential Application Efficiency (PAEmin)
            dParam = winSrfrSubsurfaceFlow.PAEmin
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.PAEmin = dParam

            dValue = srfrIrrigation.DUmin                           ' Distribution Uniformity (DUmin)
            dParam = winSrfrSubsurfaceFlow.DUmin
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.DUmin = dParam

            dValue = srfrIrrigation.DUlq                            ' Distribution Uniformity (DUlq)
            dParam = winSrfrSubsurfaceFlow.DUlq
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.DUlq = dParam

            dValue = srfrIrrigation.ADmin                           ' Adequacy (Dmin)
            dParam = winSrfrSubsurfaceFlow.ADmin
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.ADmin = dParam

            dValue = srfrIrrigation.ADlq                            ' Adequacy (Dlq)
            dParam = winSrfrSubsurfaceFlow.ADlq
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.ADlq = dParam

            dValue = srfrIrrigation.DPpct                           ' Deep Percolation Percentage (DP%)
            dParam = winSrfrSubsurfaceFlow.DPpct
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.DPpct = dParam

            Dim Dreq As Double = winSrfrInflow.RequiredDepth.Value
            dValue = srfrIrrigation.LengthUnderIrrigated(Dreq)      ' Length Under Irrigated (Lui)
            dParam = winSrfrSubsurfaceFlow.Lui
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.Lui = dParam

            dValue = srfrIrrigation.ROpct                           ' Runoff Percentage (RO%)
            dParam = winSrfrSurfaceFlow.ROpct
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.ROpct = dParam

            dValue = srfrIrrigation.VerrPct                         ' Volume Error (Verr%)
            dParam = winSrfrSurfaceFlow.VerrPct
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.VerrPct = dParam

            dValue = srfrIrrigation.WaterCostPerHectare             ' Water cost / hectare
            dParam = winSrfrInflow.Cost
            dParam.Value = dValue
            dParam.Source = ValueSources.Calculated
            winSrfrInflow.Cost = dParam

            '*************************************************************************************************
            ' Overflow
            '*************************************************************************************************

            Dim dist, time As Double
            Dim overflow As Boolean = srfrIrrigation.Overflow(dist, time)

            bParam = winSrfrSurfaceFlow.Overflow                            ' Overflow
            bParam.Value = overflow
            bParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.Overflow = bParam

            dParam = winSrfrSurfaceFlow.OverflowDist                        ' Overflow distance
            dParam.Value = dist
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.OverflowDist = dParam

            dParam = winSrfrSurfaceFlow.OverflowTime                        ' Overflow Time
            dParam.Value = time
            dParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.OverflowTime = dParam

            '*************************************************************************************************
            ' Advance, Recession & Infiltration Curves
            '*************************************************************************************************

            table = srfrIrrigation.AdvanceCurve                             ' Advance Curve(s)
            tParam = winSrfrSurfaceFlow.Advance
            tParam.Value = table
            tParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.Advance = tParam

            dSet = srfrIrrigation.AdvanceCurves
            dsParam = winSrfrSurfaceFlow.AdvanceSet
            dsParam.Value = dSet
            dsParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.AdvanceSet = dsParam

            table = srfrIrrigation.RecessionCurve                           ' Recession Curve(s)
            tParam = winSrfrSurfaceFlow.Recession
            tParam.Value = table
            tParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.Recession = tParam

            dSet = srfrIrrigation.RecessionCurves
            dsParam = winSrfrSurfaceFlow.RecessionSet
            dsParam.Value = dSet
            dsParam.Source = ValueSources.Calculated
            winSrfrSurfaceFlow.RecessionSet = dsParam

            table = srfrIrrigation.InfiltrationCurve                        ' Infiltration Profile
            table.Columns(0).ColumnName = sTimeX
            table.Columns(1).ColumnName = "Infiltration (mm)"

            tParam = winSrfrSubsurfaceFlow.LongitudinalInfiltration
            tParam.Value = table
            tParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.LongitudinalInfiltration = tParam

            table = srfrIrrigation.InfiltrationOrderedCurve                 ' Ordered Infiltration Profile
            table.Columns(1).ColumnName = "Ordered Infiltration (mm)"

            tParam = winSrfrSubsurfaceFlow.OrderedInfiltration
            tParam.Value = table
            tParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.OrderedInfiltration = tParam

            table = srfrIrrigation.Hydrographs("AZ", 0.0)                   ' Upstream Infiltration Function (AZ)
            table.Columns(0).ColumnName = sTimeX
            table.Columns(1).ColumnName = "Upstream Infiltration Function (m²)"

            tParam = winSrfrSubsurfaceFlow.UpstreamInfiltrationFunction
            tParam.Value = table
            tParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.UpstreamInfiltrationFunction = tParam

            table = srfrIrrigation.Hydrographs("Zwp", 0.0)                  ' Upstream Infiltration Depth (Zwp)
            table.Columns(0).ColumnName = sTimeX
            table.Columns(1).ColumnName = "Upstream Infiltration Depth Function (mm)"

            tParam = winSrfrSubsurfaceFlow.UpstreamInfiltrationDepthFunction
            tParam.Value = table
            tParam.Source = ValueSources.Calculated
            winSrfrSubsurfaceFlow.UpstreamInfiltrationDepthFunction = tParam

            '*************************************************************************************************
            ' Profiles
            '*************************************************************************************************

            If Not (skipProfiles) Then
                table = srfrIrrigation.TopDepthProfile()                    ' Flow Depth (Y) Profile
                table.Columns(0).ColumnName = sDistanceX

                If (0 < times.Count) Then
                    ldx = table.Columns.Count
                    srfrIrrigation.AppendProfiles(table, "Y", times)
                End If

                tParam = winSrfrSurfaceFlow.DepthProfiles
                tParam.Value = table
                tParam.Source = ValueSources.Calculated
                winSrfrSurfaceFlow.DepthProfiles = tParam


                table = srfrIrrigation.TopElevationProfile                  ' Flow Elevation (H) Profile
                table.Columns(0).ColumnName = sDistanceX
                table.Columns(1).ColumnName = "H (mm)"

                If (0 < times.Count) Then
                    ldx = table.Columns.Count
                    srfrIrrigation.AppendElevationProfiles(table, times)
                End If

                srfrIrrigation.AppendBottomElevationProfile(table)

                tParam = winSrfrSurfaceFlow.ElevationProfiles
                tParam.Value = table
                tParam.Source = ValueSources.Calculated
                winSrfrSurfaceFlow.ElevationProfiles = tParam

                Dim AyAzByTime As Boolean = False

                If (AyAzByTime) Then
                    table = srfrIrrigation.AYavgProfile                     ' Average AY vs. Time Profile
                    table.Columns(0).ColumnName = sTimeX
                Else
                    table = srfrIrrigation.AYavgProfile("Advance")          ' Average AY vs. Advance Profile
                    table.Columns(0).ColumnName = sAdvanceX
                End If

                tParam = winSrfrSurfaceFlow.AYavgProfile
                tParam.Value = table
                tParam.Source = ValueSources.Calculated
                winSrfrSurfaceFlow.AYavgProfile = tParam


                If (AyAzByTime) Then
                    table = srfrIrrigation.AZavgProfile                     ' Average AZ vs. Time Profile
                    table.Columns(0).ColumnName = sTimeX
                Else
                    table = srfrIrrigation.AZavgProfile("Advance")          ' Average AZ vs. Advance Profile
                    table.Columns(0).ColumnName = sAdvanceX
                End If

                tParam = winSrfrSubsurfaceFlow.AZavgProfile
                tParam.Value = table
                tParam.Source = ValueSources.Calculated
                winSrfrSubsurfaceFlow.AZavgProfile = tParam

            End If

            '*************************************************************************************************
            ' Hydrographs
            '*************************************************************************************************

            If Not (skipHydroGraphs) Then
                table = srfrIrrigation.Hydrographs("Q", dists)              ' Flow Rate (Q) Hydrographs
                table.Columns(0).ColumnName = sTimeX
                table.Columns(1).ColumnName = sQinX
                table.Columns(table.Columns.Count - 1).ColumnName = sRunoffX

                tParam = winSrfrSurfaceFlow.FlowHydrographs
                tParam.Value = table
                tParam.Source = ValueSources.Calculated
                winSrfrSurfaceFlow.FlowHydrographs = tParam


                table = srfrIrrigation.Hydrographs("Y", dists)              ' Flow Depth (Y) Hydrographs
                table.Columns(0).ColumnName = sTimeX

                tParam = winSrfrSurfaceFlow.DepthHydrographs
                tParam.Value = table
                tParam.Source = ValueSources.Calculated
                winSrfrSurfaceFlow.DepthHydrographs = tParam
            End If

            '*************************************************************************************************
            ' Erosion / Fertigation Results
            '*************************************************************************************************

            If (srfrTransport IsNot Nothing) Then ' Constituent Transport is included

                If (srfrTransport.GetType Is GetType(Srfr.SedimentTransport)) Then
                    If (winSrfrErosion.EnableErosion.Value) Then
                        '
                        ' Get Erosion Results
                        '
                        If (dists.Contains(0.0)) Then ' do not include the upstream end of the field
                            dists.Remove(0.0)
                        End If

                        table = srfrIrrigation.Hydrographs("Gs", dists)     ' Mass Transport hydrograph
                        table.Columns(0).ColumnName = sTimeX

                        tParam = winSrfrErosion.MassTransportHydrographs
                        tParam.Value = table
                        tParam.Source = ValueSources.Calculated
                        winSrfrErosion.MassTransportHydrographs = tParam

                        table = srfrIrrigation.Hydrographs("Cs", dists)     ' Mass Concentration hydrograph
                        table.Columns(0).ColumnName = sTimeX

                        tParam = winSrfrErosion.MassConcentrationHydrographs
                        tParam.Value = table
                        tParam.Source = ValueSources.Calculated
                        winSrfrErosion.MassConcentrationHydrographs = tParam
                        '
                        ' Soil movement / loss
                        '
                        Dim L As Double = srfrIrrigation.Length
                        Dim Tco As Double = srfrIrrigation.Tco

                        Dim GL01 As Double = srfrIrrigation.HydrographIntegral("Gs", (L * 1.0) / 4.0, 0.0, Tco)
                        Dim GL02 As Double = srfrIrrigation.HydrographIntegral("Gs", (L * 2.0) / 4.0, 0.0, Tco)
                        Dim GL03 As Double = srfrIrrigation.HydrographIntegral("Gs", (L * 3.0) / 4.0, 0.0, Tco)
                        Dim GL04 As Double = srfrIrrigation.HydrographIntegral("Gs", (L * 4.0) / 4.0, 0.0, Tco)

                        dParam = winSrfrErosion.GL01
                        dParam.Value = GL01
                        dParam.Source = ValueSources.Calculated
                        winSrfrErosion.GL01 = dParam

                        dParam = winSrfrErosion.GL02
                        dParam.Value = GL02
                        dParam.Source = ValueSources.Calculated
                        winSrfrErosion.GL02 = dParam

                        dParam = winSrfrErosion.GL03
                        dParam.Value = GL03
                        dParam.Source = ValueSources.Calculated
                        winSrfrErosion.GL03 = dParam

                        dParam = winSrfrErosion.GL04
                        dParam.Value = GL04
                        dParam.Source = ValueSources.Calculated
                        winSrfrErosion.GL04 = dParam

                        '*************************************************************************************
                        ' Uncomment this code to validate the Shields/Laursen/Rouse/Capacity functions
                        '   | | |
                        '   v v v
                        '
                        'Dim NodeL As Srfr.Node = srfrIrrigation.Timesteps(1).Nodes(0)
                        'ValidateErosionFunctions(NodeL)
                        '
                        '   ^ ^ ^
                        '   | | |
                        '*************************************************************************************

                    End If ' EnableErosion
                End If ' Srfr.SedimentTransport

                If (srfrTransport.GetType Is GetType(Srfr.SoluteTransport)) Then

                    If (winSrfrFertigation.EnableFertigation.Value) Then
                        '
                        ' Get Fertigation Results
                        '
                        Dim Tco As Double = srfrIrrigation.Tco
                        Dim TL As Double = srfrIrrigation.TL
                        Dim Ttl As Double = srfrIrrigation.Ttl

                        ' Make sure the Profiles include the time at the end of the simulation
                        If Not (times.Contains(Ttl)) Then
                            times.Add(Ttl)
                        End If

                        table = srfrIrrigation.Profiles("M", times)         ' Application Density (M) Profiles

                        tParam = winSrfrFertigation.DensityProfiles
                        tParam.Value = table
                        tParam.Source = ValueSources.Calculated
                        winSrfrFertigation.DensityProfiles = tParam
                        '
                        ' Get Fertigation Hydrographs
                        '
                        If (dists.Contains(0.0)) Then
                            'dists.Remove(0.0)       ' do not include upstream end of the field
                        Else
                            dists.Insert(0, 0.0)    ' include upstream end of the field
                        End If

                        table = srfrIrrigation.Hydrographs("Co", dists)     ' Concentration (Co) Hydrographs
                        table.Columns(0).ColumnName = sTimeX

                        tParam = winSrfrFertigation.ConcentrationHydrographs
                        tParam.Value = table
                        tParam.Source = ValueSources.Calculated
                        winSrfrFertigation.ConcentrationHydrographs = tParam
                        '
                        ' Infiltrated solute
                        '
                        Dim L As Double = srfrIrrigation.Length

                        Dim Minf As Double = srfrIrrigation.ProfileIntegral("M", Ttl, 0.0, L)

                        dParam = winSrfrFertigation.Minf
                        dParam.Value = Minf
                        dParam.Source = ValueSources.Calculated
                        winSrfrFertigation.Minf = dParam

                        Dim Mcurve As DataTable = srfrIrrigation.Profiles("M", Ttl)
                        Dim Mlq As Double = Srfr.SrfrAPI.ProfileLQ(Mcurve)
                        Dim DUlq As Double = Mlq * L / Minf

                        dParam = winSrfrFertigation.MDUlq
                        dParam.Value = DUlq
                        dParam.Source = ValueSources.Calculated
                        winSrfrFertigation.MDUlq = dParam
                        '
                        ' Runoff solute
                        '
                        Dim Mro As Double = srfrIrrigation.HydroMathIntegral("Co", "Q", "*", L, 0.0, Ttl)

                        dParam = winSrfrFertigation.Mro
                        dParam.Value = Mro
                        dParam.Source = ValueSources.Calculated
                        winSrfrFertigation.Mro = dParam
                        '
                        ' Average Kx
                        '
                        Dim kxTime As Double = Math.Min(Tco, TL)
                        Dim avgKx As Double = srfrIrrigation.KxAvgAtTime(kxTime)

                        dParam = winSrfrFertigation.AverageKx
                        dParam.Value = avgKx
                        dParam.Source = ValueSources.Calculated
                        winSrfrFertigation.AverageKx = dParam

                    End If ' EnableFertigation
                End If ' SoluteTransport
            End If ' srfrTransport IsNot Nothing
        End If

        Return srfrIrrigation
    End Function

    '*********************************************************************************************************
    ' Validate the Shields/Laursen/Rouse/Capacity functions within SRFR Erosion Transport component
    '*********************************************************************************************************
    Public Sub ValidateErosionFunctions(ByVal NodeL As Srfr.Node)

        Dim dbGraph2d As db_Graph2D = New db_Graph2D()
        Dim dataOk As DialogResult

        Dim Fig2 As DataTable = SedimentTransport.ShieldsFunctionGraph()
        dbGraph2d.DisplayData(Fig2)
        dataOk = dbGraph2d.ShowDialog

        Dim Fig3 As DataTable = SedimentTransport.LaursenFunctionGraph()
        dbGraph2d.DisplayData(Fig3)
        dataOk = dbGraph2d.ShowDialog

        Dim Fig4 As DataTable = SedimentTransport.RouseFunctionGraph()
        dbGraph2d.DisplayData(Fig4)
        dataOk = dbGraph2d.ShowDialog

        Dim Fig5 As DataTable = SedimentTransport.TransportCapacityGraph(NodeL)
        dbGraph2d.UnitsX = Units.Microns
        dbGraph2d.UnitsY = Units.GramsPerSecond
        dbGraph2d.DisplayData(Fig5)
        dataOk = dbGraph2d.ShowDialog

    End Sub

#End Region

#End Region

End Module
