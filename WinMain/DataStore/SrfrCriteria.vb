
'*************************************************************************************************************
' Srfr Criteria properties
'
' SrfrCriteria contains the SRFR Simulation execution criteria.
'*************************************************************************************************************
Imports DataStore

Public Class SrfrCriteria

#Region " Identification "
    '
    ' mMyID - unique object ID for DataStore
    '
    Private mMyID As String = "Srfr Criteria"
    Public ReadOnly Property MyID() As String
        Get
            Return mMyID
        End Get
    End Property
    '
    ' Parent Unit
    '
    Private mUnit As Unit
    Public ReadOnly Property Unit() As Unit
        Get
            Return mUnit
        End Get
    End Property
    '
    ' Data Store
    '
    Private mParentStore As DataStore.ObjectNode = Nothing
    Private WithEvents mMyStore As DataStore.ObjectNode = Nothing
    Public ReadOnly Property MyStore() As DataStore.ObjectNode
        Get
            Return mMyStore
        End Get
    End Property

#End Region

#Region " Serialized Properties "

#Region " Simulation Graphics "
    '
    ' Profile Times Table
    '
    Public Const sProfileTable As String = "Profile Table"

    Public ReadOnly Property ProfileTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sProfileTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                ' Build default Profile Table
                Dim _profileTable As DataTable = New DataTable(sProfileTable)

                ResetProfileTable(_profileTable, DefaultCutoffTime)

                Dim _parameter As DataTableParameter = New DataTableParameter(_profileTable)
                mMyStore.AddProperty(sProfileTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sProfileTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ProfileTable() As DataTableParameter
        Get
            Dim _table As DataTableParameter = ProfileTableProperty.GetDataTableParameter()

            If Not (_table.Value Is Nothing) Then
                ' Ensure data within table is up to date.
                If (_table.Value.Columns(0).ColumnName = "#") Then
                    _table.Value.Columns.RemoveAt(0)
                End If

                _table.Value.Columns(nTimeX).ColumnName = sTimeX
            End If

            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            ProfileTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetProfileTable(ByVal _profileTable As DataTable, ByVal _cutoffTime As Double)

        ' Remove the previous data
        _profileTable.Clear()
        _profileTable.Columns.Clear()

        ' Add the columns
        _profileTable.Columns.Add(sTimeX, GetType(Double))

        ' Add the rows of reset data
        Dim _profileTime As DataRow = _profileTable.NewRow      ' 1/8 cutoff
        _profileTime.Item(nTimeX) = _cutoffTime / 8.0
        _profileTable.Rows.Add(_profileTime)

        _profileTime = _profileTable.NewRow                     ' 1/4 cutoff
        _profileTime.Item(nTimeX) = _cutoffTime / 4.0
        _profileTable.Rows.Add(_profileTime)

        _profileTime = _profileTable.NewRow                     ' 1/2 cutoff
        _profileTime.Item(nTimeX) = _cutoffTime / 2.0
        _profileTable.Rows.Add(_profileTime)

    End Sub
    '
    ' Hydrograph Locations Table
    '
    Public Const sHydrographTable As String = "Hydrograph Table"

    Public ReadOnly Property HydrographTableProperty() As PropertyNode
        Get
            ' Build default Hydrograph Table
            Dim _hydrographTable As DataTable = New DataTable(sHydrographTable)
            ResetHydrographTable(_hydrographTable, DefaultLength)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sHydrographTable, _hydrographTable)
            Return _propertyNode
        End Get
    End Property

    Public Property HydrographTable() As DataTableParameter
        Get
            Dim _table As DataTableParameter = HydrographTableProperty.GetDataTableParameter()

            If Not (_table.Value Is Nothing) Then
                ' Ensure data within table is up to date.
                If (_table.Value.Columns(0).ColumnName = "#") Then
                    _table.Value.Columns.RemoveAt(0)
                End If

                _table.Value.Columns(nDistanceX).ColumnName = sDistanceX
            End If

            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            HydrographTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetHydrographTable(ByVal _hydrographTable As DataTable, ByVal _length As Double)

        ' Remove the previous data
        _hydrographTable.Clear()
        _hydrographTable.Columns.Clear()

        ' Add the columns
        _hydrographTable.Columns.Add(sDistanceX, GetType(Double))

        ' Add the rows of reset data
        Dim _hydrographLocation As DataRow = _hydrographTable.NewRow    ' Start of field (Qin)
        _hydrographLocation.Item(nDistanceX) = 0.0
        _hydrographTable.Rows.Add(_hydrographLocation)

        _hydrographLocation = _hydrographTable.NewRow                   ' 1/4 of field
        _hydrographLocation.Item(nDistanceX) = _length / 4.0
        _hydrographTable.Rows.Add(_hydrographLocation)

        _hydrographLocation = _hydrographTable.NewRow                   ' 1/2 of field
        _hydrographLocation.Item(nDistanceX) = _length / 2.0
        _hydrographTable.Rows.Add(_hydrographLocation)

        _hydrographLocation = _hydrographTable.NewRow                   ' 3/4 of field
        _hydrographLocation.Item(nDistanceX) = _length * 3 / 4
        _hydrographTable.Rows.Add(_hydrographLocation)

        _hydrographLocation = _hydrographTable.NewRow                   ' End of field (Runoff)
        _hydrographLocation.Item(nDistanceX) = _length
        _hydrographTable.Rows.Add(_hydrographLocation)

    End Sub

#End Region

#Region " Simulation Control "
    '
    ' Solution Model
    '
    Private Const sSolutionModel As String = "Solution Model"

    Public ReadOnly Property SolutionModelProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSolutionModel)
            If (_propertyNode Is Nothing) Then ' If it was not found; create it
                Dim _intParam As IntegerParameter = New IntegerParameter(DefaultSolutionModel)
                mMyStore.AddProperty(sSolutionModel, _intParam)
                _propertyNode = mMyStore.GetProperty(sSolutionModel)
            End If

            Dim _param As Parameter = _propertyNode.GetParameter
            If (_param.GetType Is GetType(IntegerParameter)) Then
                Dim _intParam As IntegerParameter = DirectCast(_param, IntegerParameter)

                Dim _blocked As DownstreamConditions = mUnit.SystemGeometryRef.DownstreamCondition.Value
                If (_blocked) Then
                    _intParam.Value = SolutionModels.ZeroInertia
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SolutionModel() As IntegerParameter
        Get
            Return SolutionModelProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            SolutionModelProperty.SetParameter(Value)
        End Set
    End Property

    Private mSolutionModelIndex As Integer = -1
    Public Function GetFirstSolutionModelSelection(ByRef _sel As String) As Boolean
        mSolutionModelIndex = -1
        Return GetNextSolutionModelSelection(_sel)
    End Function

    Public Function GetNextSolutionModelSelection(ByRef _sel As String) As Boolean
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mSolutionModelIndex += 1
        If (mSolutionModelIndex < SolutionModels.HighLimit) Then
            _sel = SolutionModelSelections(mSolutionModelIndex).Value
            If ((SolutionModelSelections(mSolutionModelIndex).Flags And _flags) = 0) Then
                If (mSolutionModelIndex = SolutionModels.KinematicWave) Then
                    Dim _blocked As DownstreamConditions = mUnit.SystemGeometryRef.DownstreamCondition.Value
                    If (_blocked) Then
                        Return False
                    End If
                End If

                Return True
            Else
                Return False
            End If
        End If
        _sel = Nothing
        Return False
    End Function
    '
    ' Cell Density
    '
    Private Const sCellDensity As String = "Cell Density"

    Public ReadOnly Property CellDensityProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCellDensity)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultCellDensity)
                mMyStore.AddProperty(sCellDensity, _parameter)
                _propertyNode = mMyStore.GetProperty(sCellDensity)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CellDensity() As IntegerParameter
        Get
            Return CellDensityProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            Dim cellDensity As Integer = CellDensityProperty.GetIntegerParameter.Value
            If Not (cellDensity = Value.Value) Then
                CellDensityProperty.SetParameter(Value)
            End If
        End Set
    End Property
    '
    ' Shape Factors
    '
    Private Const sPhiAYL_KW As String = "PhiAYL KW"

    Public ReadOnly Property PhiAYL_KW_Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhiAYL_KW)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhiAYL_KW)
                mMyStore.AddProperty(sPhiAYL_KW, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhiAYL_KW)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property PhiAYL_KW() As DoubleParameter
        Get
            Return PhiAYL_KW_Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            PhiAYL_KW_Property.SetParameter(Value)
        End Set
    End Property


    Private Const sPhiAYL_ZI As String = "PhiAYL ZI"

    Public ReadOnly Property PhiAYL_ZI_Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhiAYL_ZI)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhiAYL_ZI)
                mMyStore.AddProperty(sPhiAYL_ZI, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhiAYL_ZI)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property PhiAYL_ZI() As DoubleParameter
        Get
            Return PhiAYL_ZI_Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            PhiAYL_ZI_Property.SetParameter(Value)
        End Set
    End Property


    Private Const sPhiAZL As String = "PhiAZL"

    Public ReadOnly Property PhiAZLProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhiAZL)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhiAZL)
                mMyStore.AddProperty(sPhiAZL, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhiAZL)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property PhiAZL() As DoubleParameter
        Get
            Return PhiAZLProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            PhiAZLProperty.SetParameter(Value)
        End Set
    End Property


    Private Const sTheta As String = "Theta"

    Public ReadOnly Property ThetaProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTheta)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultTheta)
                mMyStore.AddProperty(sTheta, _parameter)
                _propertyNode = mMyStore.GetProperty(sTheta)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Theta() As DoubleParameter
        Get
            Return ThetaProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ThetaProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Enable Diagnostics
    '
    Private Const sEnableDiagnostics As String = "Enable Diagnostics"

    Public ReadOnly Property EnableDiagnosticsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEnableDiagnostics)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As BooleanParameter = New BooleanParameter(False)
                mMyStore.AddProperty(sEnableDiagnostics, _parameter)
                _propertyNode = mMyStore.GetProperty(sEnableDiagnostics)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EnableDiagnostics() As BooleanParameter
        Get
            Return EnableDiagnosticsProperty.GetBooleanParameter
        End Get
        Set(ByVal value As BooleanParameter)
            EnableDiagnosticsProperty.SetParameter(value)
        End Set
    End Property

#End Region

#End Region

#Region " Constructor(s) "

    Public Sub New(ByVal _myID As String, ByVal _unit As Unit)
        '
        ' Save ID
        '
        If Not (_myID Is Nothing) Then
            If Not (_myID.Trim = String.Empty) Then
                mMyID = _myID.Trim
            Else
                Debug.Assert(False, "MyID is Empty")
            End If
        Else
            Debug.Assert(False, "MyID is Nothing")
        End If
        '
        ' Get Parent's Data Store
        '
        If Not (_unit Is Nothing) Then
            mUnit = _unit
            mParentStore = mUnit.MyStore
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Add SrfrCriteria to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If Not (mMyStore Is Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "SrfrCriteria not added to Data Store")
            End If
        Else
            Debug.Assert(False, "Parent's Data Store is Nothing")
        End If

    End Sub
    '
    ' Constructor that restores from the Data Store
    '
    Public Sub New(ByVal _myStore As DataStore.ObjectNode, ByVal _unit As Unit)
        '
        ' Restore Parent & Parent's DataStore
        '
        If Not (_unit Is Nothing) Then
            mUnit = _unit
            mParentStore = mUnit.MyStore
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Restore MyStore
        '
        If Not (_myStore Is Nothing) Then
            ' Restore identification
            mMyStore = _myStore
            mMyID = mMyStore.MyID

            ' Enable event generation
            mMyStore.EventsEnabled = True
        Else
            Debug.Assert(False, "MyStore is Nothing")
        End If
    End Sub

#End Region

#Region " Methods "
    '
    ' Delete previous Fortran SRFR's deprecated controls from the DataStore
    '
    Public Sub ClearResults()
        mMyStore.DeleteProperty("Nondimensional Mode")
        mMyStore.DeleteProperty("Fiflt")
        mMyStore.DeleteProperty("Rdfct")
        mMyStore.DeleteProperty("Vdb1")
        mMyStore.DeleteProperty("Dtlrat")
        mMyStore.DeleteProperty("IT40")
        mMyStore.DeleteProperty("YtRec")
        mMyStore.DeleteProperty("Qcoavg")
        mMyStore.DeleteProperty("Nyubc")
        mMyStore.DeleteProperty("Niwait")
        mMyStore.DeleteProperty("Ndxkg")
        mMyStore.DeleteProperty("Idt")
        mMyStore.DeleteProperty("Auto Rdt")
        mMyStore.DeleteProperty("Uniformity Weighting")
        mMyStore.DeleteProperty("Stop When Stagnant")
        mMyStore.DeleteProperty("Rdtstg")
        mMyStore.DeleteProperty("R0")
        mMyStore.DeleteProperty("R1")
        mMyStore.DeleteProperty("Imax")
        mMyStore.DeleteProperty("TStop")
        mMyStore.DeleteProperty("Rcmxr")
        mMyStore.DeleteProperty("Rmmxr")
        mMyStore.DeleteProperty("Jhi")
        mMyStore.DeleteProperty("Jlo")
        mMyStore.DeleteProperty("JMax")
        mMyStore.DeleteProperty("JCountMax")
        mMyStore.DeleteProperty("Diag Flags")
        mMyStore.DeleteProperty("Diag Exp Flags")
        mMyStore.DeleteProperty("Diag Aux1 Flags")
        mMyStore.DeleteProperty("Diag Aux2 Flags")
        mMyStore.DeleteProperty("Diag Aux3 Flags")
        mMyStore.DeleteProperty("Start I")
        mMyStore.DeleteProperty("Start J")
        mMyStore.DeleteProperty("Start K")
        mMyStore.DeleteProperty("End K")
    End Sub
    '
    ' Comments from SRFR Shell code:
    '
    '// The following comments were written by Fedja on 1998/09/18:
    '// Cell density (NSTD)
    '//     (In the confirmation message, give both the current number and designation and suggested defaults):
    '// The current relation between number and designation are:
    '// 10: Coarse
    '// 20: Medium
    '// 40: Fine
    '// 80: Extra fine
    '// ??: Numerical (anything other than the above)
    '// No default should be less than 20
    '// If any slope segment > 0.005 select 40 (KW, ZI, or SV)*
    '// If any slope segment > 0.01 and not now KW*, select 80
    '// If s is the smallest segment length and L is the total length, select
    '// NSTD=5*L/s, then round up to the next designation, or next 10, 
    '//             but not greater than KMX/2, 
    '//             nor less than the first three criteria.
    '
    ' * KW = Kinematic Wave Model
    '   ZI = Zero Inertia Model
    '   SV = Saint Venant Model
    '
    Private Const KMX As Double = 1201.0

    Public Sub CheckCellDensity(ByVal minCellDensity As Integer)

        ' Only change Cell Density for non-Researchers
        If Not (WinSRFR.IsResearchLevel) Then

            Dim _userPreferences As UserPreferences = UserPreferences.Instance

            If (mUnit IsNot Nothing) Then
                Dim _systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
                Dim _soilCropProperties As SoilCropProperties = mUnit.SoilCropPropertiesRef
                Dim _inflowManagement As InflowManagement = mUnit.InflowManagementRef
                Dim _erosion As Erosion = mUnit.ErosionRef
                Dim _fertigation As Fertigation = mUnit.FertigationRef
                '
                ' Compute the new, suggested, value for Cell Density.
                '
                ' This code was ported from the SRFR Shell function DefaultCellDensity()
                '

                ' Get dependent values
                Dim _length As Double = _systemGeometry.Length.Value
                Dim _maxSlope As Double = _systemGeometry.MaximumSlope
                Dim _minSegmentLength As Double = _systemGeometry.MinimumSegmentLength
                Dim _solutionModel As SolutionModels = CType(SolutionModel.Value, SolutionModels)

                '// If any slope segment > 0.005 select 40 (KW, ZI, or SV)
                If (0.005 < _maxSlope) Then
                    minCellDensity = Math.Max(minCellDensity, CellDensities.Medium)
                End If

                '// If any slope segment > 0.01 and not now KW, select 80
                If (0.01 < _maxSlope) Then
                    If ((_solutionModel = Globals.SolutionModels.ZeroInertia) _
                     Or (_solutionModel = Globals.SolutionModels.SaintVenant)) Then
                        minCellDensity = Math.Max(minCellDensity, CellDensities.ExtraFine)
                    End If
                End If

                '// NSTD=5*L/s
                Dim _nstd As Double = (5.0 * _length) / _minSegmentLength

                '// round up to the next designation, or next 10
                If (_nstd < CellDensities.Coarse) Then
                    _nstd = CellDensities.Coarse
                ElseIf (_nstd < CellDensities.Medium) Then
                    _nstd = CellDensities.Medium
                ElseIf (_nstd < CellDensities.Fine) Then
                    _nstd = CellDensities.Fine
                Else
                    _nstd = CellDensities.ExtraFine
                End If

                '// nor less than the first three criteria
                If (_nstd < minCellDensity) Then
                    _nstd = minCellDensity
                End If
                '
                ' Added criteria to Fedja's
                '
                If (_inflowManagement.InflowMethod.Value = InflowMethods.StandardHydrograph) Then
                    If Not (_inflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                        _nstd = Math.Max(_nstd, CellDensities.ExtraFine) ' w/ Cutback
                    End If
                Else ' Surge, Cablegation, Tabulated Inflow
                    _nstd = Math.Max(_nstd, CellDensities.ExtraFine) ' w/ Cutback
                End If

                If (_systemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
                    If (_systemGeometry.UpstreamCondition.Value = UpstreamConditions.NoDrainback) Then
                        _nstd = Math.Max(_nstd, CellDensities.ExtraFine)
                    End If
                End If

                If (_erosion.EnableErosion.Value = True) Then
                    _nstd = Math.Max(_nstd, CellDensities.ExtraFine)
                End If

                If (_fertigation.EnableFertigation.Value = True) Then
                    _nstd = Math.Max(_nstd, CellDensities.ExtraFine)
                End If

                If ((_systemGeometry.BottomDescription.Value = BottomDescriptions.ElevationTable) Or _
                    (_systemGeometry.BottomDescription.Value = BottomDescriptions.SlopeTable)) Then
                    Dim _numChanges As Integer = _systemGeometry.NumElevationDistances
                    While (_nstd <= _numChanges * 2)
                        _nstd += 20
                    End While
                End If
                '
                ' If this Unit is in the Simulation World, prompt the user before making
                ' any changes.
                '
                ' For all other worlds, simply make the change.
                '

                ' Is this a new Cell Density?
                Dim _currentCellDensity As Integer = CellDensity.Value
                If (_currentCellDensity < _nstd) Then
                    ' This is a new Cell Density, is this the Simulation World?
                    If (mUnit.UnitType.Value = WorldTypes.SimulationWorld) Then
                        ' This is the Simulation World, prompt user for change verification

                        If (_userPreferences.DefaultValueResponse = DefaultValueResponses.RequireConfirmation) Then

                            Dim _title As String = "Simulation Defaults"
                            Dim _style As MsgBoxStyle = MsgBoxStyle.YesNo Or MsgBoxStyle.Information
                            Dim _prompt As String = "Present conditions indicate that the Cell Density" _
                                       + ChrW(10) + "should be changed.  Please confirm this change" _
                                       + ChrW(10) + ChrW(10) + "Change Cell Density from "

                            If (_currentCellDensity = CellDensities.Coarse) Then
                                _prompt += "Coarse"
                            ElseIf (_currentCellDensity = CellDensities.Medium) Then
                                _prompt += "Medium"
                            ElseIf (_currentCellDensity = CellDensities.Fine) Then
                                _prompt += "Fine"
                            ElseIf (_currentCellDensity = CellDensities.ExtraFine) Then
                                _prompt += "ExtraFine"
                            Else
                                _prompt += "Numeric"
                            End If

                            _prompt += " (" + _currentCellDensity.ToString + ") to "

                            If (_nstd = CellDensities.Coarse) Then
                                _prompt += "Coarse"
                            ElseIf (_nstd = CellDensities.Medium) Then
                                _prompt += "Medium"
                            ElseIf (_nstd = CellDensities.Fine) Then
                                _prompt += "Fine"
                            ElseIf (_nstd = CellDensities.ExtraFine) Then
                                _prompt += "ExtraFine"
                            Else
                                _prompt += "Numeric"
                            End If

                            _prompt += " (" + _nstd.ToString + ")?"

                            Dim _result As MsgBoxResult = MsgBox(_prompt, _style, _title)

                            ' If user said no, don't save the suggested value
                            If (_result = MsgBoxResult.No) Then
                                Return
                            End If
                        End If
                    End If
                End If
                '
                ' Change the Cell Density to its new value
                '
                Dim _cellDensity As IntegerParameter = CellDensity
                If (_cellDensity.Source = ValueSources.Calculated) Then
                    _cellDensity.Value = CInt(_nstd)
                    _cellDensity.Source = ValueSources.Calculated
                    CellDensity = _cellDensity
                Else ' Set by user
                    If (_currentCellDensity <= _nstd) Then
                        _cellDensity.Value = CInt(_nstd)
                        _cellDensity.Source = ValueSources.Calculated
                        CellDensity = _cellDensity
                    End If
                End If
            End If
        End If

    End Sub
    '
    '// Use the logic described by Fedja on 1998/09/18:
    '// If Drainback, choose ZI*
    '// Else if Blocked End, and was KW, choose ZI*
    '// Else If any field segment slope at any time <= 0.0, and was KW, choose ZI*
    '// Else If the smallest (in algebraic sense) distance-averaged slope < 0.001, choose ZI*
    '// Else, choose KW*
    '
    ' * KW = Kinematic Wave Model
    '   ZI = Zero Inertia Model
    '   SV = Saint Venant Model
    '
    Public Sub CheckSolutionModel()

        Dim _userPreferences As UserPreferences = UserPreferences.Instance

        If Not (mUnit Is Nothing) Then
            Dim _systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
            If Not (_systemGeometry Is Nothing) Then
                '
                ' Compute the new, suggested, value for Solution Model.
                '
                ' This code was ported from the SRFR Shell function DefaultSolutionModel()
                '

                ' Get dependent values
                Dim _upstreamCondition As UpstreamConditions = CType(_systemGeometry.UpstreamCondition.Value, UpstreamConditions)
                Dim _downstreamCondition As DownstreamConditions = CType(_systemGeometry.DownstreamCondition.Value, DownstreamConditions)
                Dim _minSlope As Double = _systemGeometry.MinimumSlope
                Dim _avgFieldSlope As Double = _systemGeometry.AverageSlope
                Dim _newModel As SolutionModels = Globals.SolutionModels.KinematicWave

                If (_upstreamCondition = Globals.UpstreamConditions.DrainbackAfterCutoff) Then
                    '// If Drainback, choose ZI*
                    _newModel = Globals.SolutionModels.ZeroInertia
                ElseIf (_downstreamCondition = Globals.DownstreamConditions.BlockedEnd) Then
                    '// Else if Blocked End, and was KW, choose ZI*
                    _newModel = Globals.SolutionModels.ZeroInertia
                ElseIf (_minSlope <= 0.0) Then
                    '// Else If any field segment slope at any time <= 0.0, and was KW, choose ZI*
                    _newModel = Globals.SolutionModels.ZeroInertia
                ElseIf (_avgFieldSlope < ZeroInertiaSlope) Then
                    '// Else If the smallest (in algebraic sense) distance-averaged slope < 0.001, choose ZI*
                    _newModel = Globals.SolutionModels.ZeroInertia
                End If

                ' If the Solution Model should change, prompt user for verification
                If Not (_newModel = SolutionModel.Value) Then
                    Dim _solutionModel As IntegerParameter = SolutionModel
                    ' This is a new Solution Model, is this the Simulation World?
                    If (mUnit.UnitType.Value = WorldTypes.SimulationWorld) Then
                        ' This is the Simulation World, prompt user for change verification

                        If (_userPreferences.DefaultValueResponse = DefaultValueResponses.RequireConfirmation) Then
                            ' User has requested verification

                            Dim _title As String = "Simulation Selections"
                            If (mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel = UserLevels.Standard) Then
                                ' Standard users simply get notice of change
                                Dim _style As MsgBoxStyle = MsgBoxStyle.Information
                                Dim _prompt As String = "Present conditions indicate that the Solution Model" _
                                           + ChrW(10) + "must be changed from "

                                _prompt += ChrW(10) + "     " + SolutionModelSelections(SolutionModel.Value).Value
                                _prompt += ChrW(10) + "       to"
                                _prompt += ChrW(10) + "     " + SolutionModelSelections(_newModel).Value

                                MsgBox(_prompt, _style, _title)
                            Else
                                ' Advanced users are given choice to make the change
                                Dim _style As MsgBoxStyle = MsgBoxStyle.YesNo Or MsgBoxStyle.Information
                                Dim _prompt As String = "Present conditions indicate that the Solution Model" _
                                           + ChrW(10) + "should be changed.  Please confirm this change" _
                                           + ChrW(10) + ChrW(10) + "Change Solution Model from "

                                _prompt += ChrW(10) + "     " + SolutionModelSelections(SolutionModel.Value).Value
                                _prompt += ChrW(10) + "       to"
                                _prompt += ChrW(10) + "     " + SolutionModelSelections(_newModel).Value

                                Dim _result As MsgBoxResult = MsgBox(_prompt, _style, _title)

                                ' If user said no, don't save the suggested value
                                If (_result = MsgBoxResult.No) Then
                                    ' Mark current value as User Entered since user overrode the calculated value
                                    _solutionModel.Source = ValueSources.UserEntered
                                    SolutionModel = _solutionModel
                                    Return
                                End If
                            End If
                        End If
                    End If
                    '
                    ' Change the Solution Model to its new value
                    '
                    _solutionModel.Source = ValueSources.Calculated
                    _solutionModel.Value = _newModel
                    SolutionModel = _solutionModel

                End If
            End If
        End If

    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        SrfrCriteria
    End Enum
    '
    ' Event generated when a property changes
    '
    Public Event PropertyDataChanged(ByVal _reason As Reasons)
    '
    ' MyStore generates change events
    '
    Private Sub MyStore_PropertyDataChanged(ByVal _id As String, ByVal _reason As PropertyNode.Reasons) _
    Handles mMyStore.PropertyDataChanged
        ' Regenerate the DataStore event as a Srfr Criteria event
        RaiseEvent PropertyDataChanged(Reasons.SrfrCriteria)
    End Sub

#End Region

End Class
