
'*************************************************************************************************************
' Unit.vb - Unit class
'
' Unit represents a Basin, Border or Furrow and the Results of an Analysis.  It holds:
'   1) the data input by the user
'   2) the analysis results computed by one of the WinSRFR Worlds
'
' Unit is a complete entity in that its contains all the data needed to analyze a unit in any WinSRFR World.
'*************************************************************************************************************
Imports DataStore

Public Class Unit

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "Unit"
    Public ReadOnly Property MyID() As String
        Get
            Return mMyID
        End Get
    End Property
    '
    ' Reference to parent object (World)
    '
    Private mWorld As World
    Public ReadOnly Property WorldRef() As World
        Get
            Return mWorld
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
    '
    ' Cross Section
    '
    Public Function CrossSection() As CrossSections
        CrossSection = CType(mSystemGeometry.CrossSection.Value, CrossSections)
    End Function

    Public Function FurrowShape() As FurrowShapes
        FurrowShape = CType(mSystemGeometry.FurrowShape.Value, FurrowShapes)
    End Function
    '
    ' Data Comparer
    '
    Private mBeingCompared As Boolean = False
    Public Property BeingCompared() As Boolean
        Get
            Return mBeingCompared
        End Get
        Set(ByVal Value As Boolean)
            mBeingCompared = Value
        End Set
    End Property

#End Region

#Region " Constructor(s) "
    '
    ' Constructor that creates a new Unit and adds it to the Data Store
    '
    Public Sub New(ByVal _myID As String, ByVal _world As World)
        '
        ' Save ID
        '
        If (_myID IsNot Nothing) Then
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
        If (_world IsNot Nothing) Then
            mWorld = _world
            mParentStore = mWorld.MyStore
        Else
            Debug.Assert(False, "World is Nothing")
        End If
        '
        ' Add Unit to Parent's Data Store
        '
        If (mParentStore IsNot Nothing) Then

            ' Disable event generation during initialization
            mParentStore.EventsEnabled = False
            mMyStore = mParentStore.AddObject(MyID)

            ' Add serializable data to Field's Data Store
            If (mMyStore IsNot Nothing) Then

                Dim _parameter As Parameter = Nothing
                Dim _success As Integer = 0
                Dim _count As Integer = 0
                '
                ' Add the Unit's properties
                '
                _parameter = New IntegerParameter(mWorld.WorldType.Value)
                _success += CInt(mMyStore.AddProperty(sUnitType, _parameter))
                _count += 1

                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sUnitName, _parameter))
                _count += 1

                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sEvaluator, _parameter))
                _count += 1

                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sUnitNotes, _parameter))
                _count += 1

                _parameter = New DateTimeParameter(System.DateTime.Now)
                _success += CInt(mMyStore.AddProperty(sCreationDateTime, _parameter))
                _count += 1

                _parameter = New ArrayListParameter
                _success += CInt(mMyStore.AddProperty(sDataHistory, _parameter))
                _count += 1

                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sSrfrID, _parameter))
                _count += 1

                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sRefSrfrID, _parameter))
                _count += 1

                ' Verify this worked
                Debug.Assert(Not _parameter Is Nothing, "Parameter was not created")
                Debug.Assert(_success = -_count, "All Properties were not added")
                '
                ' Add the Unit's objects (i.e. the irrigation data)
                '
                mSystemGeometry = New SystemGeometry(sSystemGeometry, Me)
                mSoilCropProperties = New SoilCropProperties(sSoilCropProperties, Me)
                mInflowManagement = New InflowManagement(sInflowManagement, Me)
                mErosion = New Erosion(sErosion, Me)
                mFertigation = New Fertigation(sFertigation, Me)
                mSurfaceFlow = New SurfaceFlow(sSurfaceFlow, Me)
                mSubsurfaceFlow = New SubsurfaceFlow(sSubsurfaceFlow, Me)

                mPerformanceResults = New PerformanceResults(sPerformanceResults, Me)
                mSrfrResults = New SrfrResults(sSrfrResults, Me)

                mUnitControl = New UnitControl(sUnitControl, Me)

                mBorderCriteria = New BorderCriteria(sBorderCriteria, Me)
                mSrfrCriteria = New SrfrCriteria(sSrfrCriteria, Me)
                mEventCriteria = New EventCriteria(sEventCriteria, Me)

                ' Enable event generation
                mMyStore.EventsEnabled = True
                mParentStore.EventsEnabled = True

                ' Enable Undo/Redo at this level for World Windows
                mMyStore.EnableUndoRedo = True

            Else
                Debug.Assert(False, "Unit not added to Data Store")
            End If
        Else
            Debug.Assert(False, "Parent's Data Store is Nothing")
        End If

    End Sub
    '
    ' Constructor that re-creates a Unit from the DataStore
    '
    Public Sub New(ByVal _myStore As DataStore.ObjectNode, ByVal _world As World)
        '
        ' Get Parent & Parent's DataStore
        '
        If (_world IsNot Nothing) Then
            mWorld = _world
            mParentStore = mWorld.MyStore
        Else
            Debug.Assert(False, "World is Nothing")
        End If
        '
        ' Save MyStore & ID
        '
        If (_myStore IsNot Nothing) Then

            Const sDeserializationError As String = "Deserialization Error"

            ' Disable event generation during initialization
            mParentStore.EventsEnabled = False

            ' Restore identification
            mMyStore = _myStore
            mMyID = mMyStore.MyID

            ' Get the Version of the data in the DataStore
            Dim _version As String = ProductVersion()

            ' Restore contained Objects
            Dim _object As DataStore.ObjectNode
            Dim _param As DataStore.Parameter

            _object = mMyStore.GetObject(sSystemGeometry)
            If (_object Is Nothing) Then
                mSystemGeometry = New SystemGeometry(sSystemGeometry, Me)
                DataStore.DeserializationError(mSystemGeometry, sDeserializationError)
            Else
                mSystemGeometry = New SystemGeometry(_object, Me)
            End If

            _object = mMyStore.GetObject(sSoilCropProperties)
            If (_object Is Nothing) Then
                mSoilCropProperties = New SoilCropProperties(sSoilCropProperties, Me)
                DataStore.DeserializationError(mSoilCropProperties, sDeserializationError)
            Else
                mSoilCropProperties = New SoilCropProperties(_object, Me)
            End If

            _object = mMyStore.GetObject(sInflowManagement)
            If (_object Is Nothing) Then
                mInflowManagement = New InflowManagement(sInflowManagement, Me)
                DataStore.DeserializationError(mInflowManagement, sDeserializationError)
            Else
                mInflowManagement = New InflowManagement(_object, Me)
            End If

            _object = mMyStore.GetObject(sErosion)
            If (_object Is Nothing) Then
                mErosion = New Erosion(sErosion, Me)
                'DataStore.DeserializationError(mErosion, sDeserializationError)
            Else
                mErosion = New Erosion(_object, Me)
            End If

            _object = mMyStore.GetObject(sFertigation)
            If (_object Is Nothing) Then
                mFertigation = New Fertigation(sFertigation, Me)
                'DataStore.DeserializationError(mFertigation, sDeserializationError)
            Else
                mFertigation = New Fertigation(_object, Me)
            End If

            _object = mMyStore.GetObject(sSurfaceFlow)
            If (_object Is Nothing) Then
                mSurfaceFlow = New SurfaceFlow(sSurfaceFlow, Me)
                DataStore.DeserializationError(mSurfaceFlow, sDeserializationError)
            Else
                mSurfaceFlow = New SurfaceFlow(_object, Me)
            End If

            _object = mMyStore.GetObject(sSubsurfaceFlow)
            If (_object Is Nothing) Then
                mSubsurfaceFlow = New SubsurfaceFlow(sSubsurfaceFlow, Me)
                DataStore.DeserializationError(mSubsurfaceFlow, sDeserializationError)
            Else
                mSubsurfaceFlow = New SubsurfaceFlow(_object, Me)
            End If

            _object = mMyStore.GetObject(sPerformanceResults)
            If (_object Is Nothing) Then
                mPerformanceResults = New PerformanceResults(sPerformanceResults, Me)
                DataStore.DeserializationError(mPerformanceResults, sDeserializationError)
            Else
                mPerformanceResults = New PerformanceResults(_object, Me)
            End If

            _object = mMyStore.GetObject(sUnitControl)
            If (_object Is Nothing) Then
                mUnitControl = New UnitControl(sUnitControl, Me)
                DataStore.DeserializationError(mUnitControl, sDeserializationError)
            Else
                mUnitControl = New UnitControl(_object, Me)
            End If

            '_object = mMyStore.GetObject(sBasinCriteria) ' No longer used
            'If (_object Is Nothing) Then
            '    mBasinCriteria = New BasinCriteria(sBasinCriteria, Me)
            '    DataStore.DeserializationError(mBasinCriteria, sDeserializationError)
            'Else
            '    mBasinCriteria = New BasinCriteria(_object, Me)
            'End If

            _object = mMyStore.GetObject(sBorderCriteria)
            If (_object Is Nothing) Then
                mBorderCriteria = New BorderCriteria(sBorderCriteria, Me)
                DataStore.DeserializationError(mBorderCriteria, sDeserializationError)
            Else
                mBorderCriteria = New BorderCriteria(_object, Me)
            End If

            _object = mMyStore.GetObject(sSrfrCriteria)
            If (_object Is Nothing) Then
                mSrfrCriteria = New SrfrCriteria(sSrfrCriteria, Me)
                DataStore.DeserializationError(mSrfrCriteria, sDeserializationError)
            Else
                mSrfrCriteria = New SrfrCriteria(_object, Me)
            End If

            ' Added in Version 0.8
            _object = mMyStore.GetObject(sEventCriteria)
            If (_object Is Nothing) Then
                mEventCriteria = New EventCriteria(sEventCriteria, Me)
                If (0 <= _version.CompareTo("0.8")) Then
                    DataStore.DeserializationError(mEventCriteria, sDeserializationError)
                End If
            Else
                mEventCriteria = New EventCriteria(_object, Me)
            End If

            ' Added in Version 3.0.1
            _object = mMyStore.GetObject(sSrfrResults)
            If (_object Is Nothing) Then
                mSrfrResults = New SrfrResults(sSrfrResults, Me)
                If (0 <= _version.CompareTo("3.0.1")) Then
                    DataStore.DeserializationError(mSrfrResults, sDeserializationError)
                End If
            Else
                mSrfrResults = New SrfrResults(_object, Me)
            End If

            ' Added in Version 5.1.1
            _param = mMyStore.GetStringParameter(sSrfrID)
            If (_param Is Nothing) Then
                _param = New StringParameter(String.Empty)
                mMyStore.AddProperty(sSrfrID, _param)
            End If

            _param = mMyStore.GetStringParameter(sRefSrfrID)
            If (_param Is Nothing) Then
                _param = New StringParameter(String.Empty)
                mMyStore.AddProperty(sRefSrfrID, _param)
            End If

            ' Enable event generation
            mMyStore.EventsEnabled = True
            mParentStore.EventsEnabled = True

        Else
            Debug.Assert(False, "MyStore is Nothing")
        End If
    End Sub
    '
    ' Remove the Unit
    '
    Public Sub Remove()
        ' Remove this Unit from the Data Store
        Dim _object As DataStore.ObjectNode = mParentStore.GetObject(MyID)

        If (_object IsNot Nothing) Then
            mParentStore.RemoveObject(MyID)
        Else
            Debug.Assert(False, "Unit was not in Data Store")
        End If
    End Sub

#End Region

#Region " Serialized Properties "
    '
    ' Unit Type
    '
    Public Const sUnitType As String = "Unit Type"

    Public Property UnitType() As IntegerParameter
        Get
            Return mMyStore.GetIntegerParameter(sUnitType)
        End Get
        Set(ByVal Value As IntegerParameter)
            mMyStore.SetParameter(sUnitType, Value)
        End Set
    End Property
    '
    ' Unit Name
    '
    Public Const sUnitName As String = "Unit Name"

    Public Property Name() As StringParameter
        Get
            Return mMyStore.GetStringParameter(sUnitName)
        End Get
        Set(ByVal Value As StringParameter)
            mMyStore.SetParameter(sUnitName, Value)
        End Set
    End Property
    '
    ' Creation Date/Time
    '
    Public Const sCreationDateTime As String = "Creation Date/Time"

    Public Property CreationDateTime() As DateTimeParameter
        Get
            Return mMyStore.GetDateTimeParameter(sCreationDateTime)
        End Get
        Set(ByVal Value As DateTimeParameter)
            mMyStore.SetParameter(sCreationDateTime, Value)
        End Set
    End Property
    '
    ' Evaluator
    '
    Public Const sEvaluator As String = "Evaluator"

    Public Property Evaluator() As StringParameter
        Get
            Return mMyStore.GetStringParameter(sEvaluator)
        End Get
        Set(ByVal Value As StringParameter)
            mMyStore.SetParameter(sEvaluator, Value)
        End Set
    End Property
    '
    ' Notes
    '
    Public Const sUnitNotes As String = "Unit Notes"

    Public Property Notes() As StringParameter
        Get
            Return mMyStore.GetStringParameter(sUnitNotes)
        End Get
        Set(ByVal Value As StringParameter)
            mMyStore.SetParameter(sUnitNotes, Value)
        End Set
    End Property
    '
    ' Data History
    '
    Public Const sDataHistory As String = "Data History"
    Public Const ShowDataHistory As Boolean = False

    Public Property DataHistory() As ArrayListParameter
        Get
            If (ShowDataHistory) Then ' return the Data History
                Return mMyStore.GetArrayListParameter(sDataHistory)
            Else ' clear & return the Data History
                Dim param As DataStore.Parameter = mMyStore.GetParameter(sDataHistory)
                If (param IsNot Nothing) Then
                    Dim listParam As ArrayListParameter = DirectCast(param, ArrayListParameter)
                    listParam.Array.Clear()
                    Return listParam
                End If
                Return Nothing
            End If
        End Get
        Set(ByVal Value As ArrayListParameter)
            If (ShowDataHistory) Then
                mMyStore.SetParameter(sDataHistory, Value)
            End If
        End Set
    End Property
    '
    ' SrfrAPI object name
    '
    Public Const sSrfrID As String = "SrfrID"

    Public Property SrfrID() As StringParameter
        Get
            Return mMyStore.GetStringParameter(sSrfrID)
        End Get
        Set(ByVal value As StringParameter)
            mMyStore.SetParameter(sSrfrID, value)
        End Set
    End Property
    '
    ' Reference SrfrAPI object name
    '
    Public Const sRefSrfrID As String = "Ref SrfrID"

    Public Property RefSrfrID() As StringParameter
        Get
            Return mMyStore.GetStringParameter(sRefSrfrID)
        End Get
        Set(ByVal value As StringParameter)
            mMyStore.SetParameter(sRefSrfrID, value)
        End Set
    End Property

#End Region

#Region " Serialized Objects "
    '
    ' Irrigation Data (created when New'd)
    '
    Public Const sSystemGeometry As String = "System Geometry"
    Private WithEvents mSystemGeometry As SystemGeometry
    Public ReadOnly Property SystemGeometryRef() As SystemGeometry
        Get
            Return mSystemGeometry
        End Get
    End Property

    Public Const sSoilCropProperties As String = "Soil Crop Properties"
    Private WithEvents mSoilCropProperties As SoilCropProperties
    Public ReadOnly Property SoilCropPropertiesRef() As SoilCropProperties
        Get
            Return mSoilCropProperties
        End Get
    End Property

    Public Const sInflowManagement As String = "Inflow Management"
    Private WithEvents mInflowManagement As InflowManagement
    Public ReadOnly Property InflowManagementRef() As InflowManagement
        Get
            Return mInflowManagement
        End Get
    End Property

    Public Const sSurfaceFlow As String = "Surface Flow"
    Private WithEvents mSurfaceFlow As SurfaceFlow
    Public ReadOnly Property SurfaceFlowRef() As SurfaceFlow
        Get
            Return mSurfaceFlow
        End Get
    End Property

    Public Const sSubsurfaceFlow As String = "Subsurface Flow"
    Private WithEvents mSubsurfaceFlow As SubsurfaceFlow
    Public ReadOnly Property SubsurfaceFlowRef() As SubsurfaceFlow
        Get
            Return mSubsurfaceFlow
        End Get
    End Property

    Public Const sErosion As String = "Erosion"
    Private mErosion As Erosion
    Public ReadOnly Property ErosionRef() As Erosion
        Get
            Return mErosion
        End Get
    End Property

    Public Const sFertigation As String = "Fertigation"
    Private mFertigation As Fertigation
    Public ReadOnly Property FertigationRef() As Fertigation
        Get
            Return mFertigation
        End Get
    End Property

    Public Const sPerformanceResults As String = "Performance Results"
    Private mPerformanceResults As PerformanceResults
    Public ReadOnly Property PerformanceResultsRef() As PerformanceResults
        Get
            Return mPerformanceResults
        End Get
    End Property

    Public Const sSrfrResults As String = "SRFR Restuls"
    Private mSrfrResults As SrfrResults
    Public ReadOnly Property SrfrResultsRef() As SrfrResults
        Get
            Return mSrfrResults
        End Get
    End Property
    '
    ' Execution and UI control
    '
    Public Const sUnitControl As String = "Unit Control"
    Private mUnitControl As UnitControl
    Public ReadOnly Property UnitControlRef() As UnitControl
        Get
            Return mUnitControl
        End Get
    End Property
    '
    ' BASIN criteria - obsolete (kept for compatibility with older .srfr files)
    '
    'Public Const sBasinCriteria As String = "Basin Criteria"
    Private mBasinCriteria As BasinCriteria
    'Public ReadOnly Property BasinCriteriaRef() As BasinCriteria
    '    Get
    '        Return mBasinCriteria
    '    End Get
    'End Property
    '
    ' BORDER criteria (now used for contour criteria)
    '
    Public Const sBorderCriteria As String = "Border Criteria"
    Private mBorderCriteria As BorderCriteria
    Public ReadOnly Property BorderCriteriaRef() As BorderCriteria
        Get
            Return mBorderCriteria
        End Get
    End Property
    '
    ' SRFR execution
    '
    Public Const sSrfrCriteria As String = "Srfr Criteria"
    Private mSrfrCriteria As SrfrCriteria
    Public ReadOnly Property SrfrCriteriaRef() As SrfrCriteria
        Get
            Return mSrfrCriteria
        End Get
    End Property
    '
    ' Event Analysis execution
    '
    Public Const sEventCriteria As String = "Event Analysis Criteria"
    Private mEventCriteria As EventCriteria
    Public ReadOnly Property EventCriteriaRef() As EventCriteria
        Get
            Return mEventCriteria
        End Get
    End Property

#End Region

#Region " Results Methods "

    '*********************************************************************************************************
    ' Function ResultsAreValid() - checks if data has changed since the time of the last run
    '*********************************************************************************************************
    Public Function ResultsAreValid() As Boolean
        ResultsAreValid = False

        ' There are no results until first Run
        If (0 < UnitControlRef.RunCount.Value) Then ' at least 1 Run has occurred

            ' Has any data changed since then?
            Dim runTime As DateTime = UnitControlRef.RunDateTime.Value
            Dim dataHasChanged As Boolean = DataHasChangedSince(runTime)

            ResultsAreValid = Not dataHasChanged
        End If
    End Function

    '*********************************************************************************************************
    ' Function DataHasChangedSince() - checks if data has changed since specified timestamp
    '
    ' Input(s):     Timestamp   - Time/Date to check if data has changed since
    '
    ' Note - high-level DataStore objects not included in this method will have no effect.  SrfrResults,
    '        PerformanceResults & UnitControl are deliberatly left out.  This allows data in these objects
    '        to change and not cause the previously run results to become invalid.
    '*********************************************************************************************************
    Public Function DataHasChangedSince(ByVal Timestamp As Date) As Boolean

        If (SystemGeometryRef.MyStore.DataHasChangedSince(False, Timestamp)) Then
            Return True
        End If

        If (SoilCropPropertiesRef.MyStore.DataHasChangedSince(False, Timestamp)) Then
            Return True
        End If

        If (InflowManagementRef.MyStore.DataHasChangedSince(False, Timestamp)) Then
            Return True
        End If

        If (FertigationRef.MyStore.DataHasChangedSince(False, Timestamp)) Then
            Return True
        End If

        If (SurfaceFlowRef.MyStore.DataHasChangedSince(False, Timestamp)) Then
            Return True
        End If

        If (SubsurfaceFlowRef.MyStore.DataHasChangedSince(False, Timestamp)) Then
            Return True
        End If

        If (EventCriteriaRef.MyStore.DataHasChangedSince(False, Timestamp)) Then
            Return True
        End If

        'If (BasinCriteriaRef.MyStore.DataHasChangedSince(False, timestamp)) Then
        '    Return True
        'End If

        If (BorderCriteriaRef.MyStore.DataHasChangedSince(False, Timestamp)) Then
            Return True
        End If

        If (SrfrCriteriaRef.MyStore.DataHasChangedSince(False, Timestamp)) Then
            Return True
        End If

        Return False

    End Function
    '
    ' Clear all large ArrayList and DataTable results data from the DataStore
    '
    Public Sub ClearResults()
        SoilCropPropertiesRef.ClearResults()
        SrfrResultsRef.ClearResults()
        SurfaceFlowRef.ClearResults()
        SubsurfaceFlowRef.ClearResults()
        SrfrCriteriaRef.ClearResults()
        FertigationRef.ClearResults()
        ErosionRef.ClearResults()
        PerformanceResultsRef.ClearResults()
        UnitControlRef.ClearResults()
        EventCriteriaRef.ClearResults()

        RaiseResultsEvent()
    End Sub

#End Region

#Region " Unit Methods "

#Region " Upstream Parameters "

    '*********************************************************************************************************
    ' UpstreamParameters() - interfaces with the SRFR DLL to calculate Upstream hydraulic parameters:
    '
    '   Y0  - Upstream flow depth
    '   AY0 -     "    flow area
    '   R0  -     "    hydraulic radius
    '   WP0 -     "    wetter perimeter
    '   Sf0 -     "    friction slope
    '
    ' Calculation of the Upstsream Parameters is dependent on the current CrossSection & Roughness.
    '
    ' NOTE - Currently (01/03/2011), this method does not support tabulated CrossSection or Roughness. 
    '        However, since this method is used by the Event, Design & Operations Worlds which also do
    '        not support tabulated CrossSection or Roughness it is not neccessary to do so.
    '*********************************************************************************************************
    Public Sub UpstreamParameters(ByVal Q As Double, ByVal L As Double, ByVal W As Double, ByVal S0 As Double, _
                                  ByRef Y0 As Double, ByRef AY0 As Double, ByRef R0 As Double, _
                                  ByRef WP0 As Double, ByRef Sf0 As Double, _
                                  Optional ByVal Beta As Double = 0.0)

        ' If input Beta is undefined, calculate value
        If (Beta <= 0.0) Then
            Beta = Me.Beta(S0) '  Globals.Beta
        End If

        ' Instantiate SRFR CrossSection object based on WinSRFR & input parameters
        Dim crossSection As Srfr.CrossSection = SrfrAPI.SrfrCrossSection(mSystemGeometry)

        crossSection.Length = L
        crossSection.BorderWidth = W
        crossSection.S0 = S0
        crossSection.MaxDepth = OneMeter ' prevent Overflow handling

        ' Instantiate SRFR Roughness object based on WinSRFR parameters
        Dim roughness As Srfr.Roughness = SrfrAPI.SrfrRoughness(mSoilCropProperties)

        ' Call SRFR UpstreamParameters to perform the calculations
        Srfr.SrfrAPI.UpstreamParameters(Q, crossSection, roughness, Y0, AY0, R0, WP0, Sf0, Beta)

    End Sub
    '
    ' Compute Upstream Flow Depth based on values passed via parameter list
    '
    Public Function UpstreamDepth(ByVal Q As Double, ByVal L As Double, ByVal W As Double, ByVal S0 As Double, _
                                  Optional ByVal Beta As Double = 0.0) As Double
        Dim Y0, AY0, R0, WP0, SF0 As Double
        UpstreamParameters(Q, L, W, S0, Y0, AY0, R0, WP0, SF0, Beta)
        Return Y0
    End Function
    '
    ' Compute Upstream Flow Depth based on current Unit parameters
    '
    Public Function UpstreamDepth(Optional ByVal Beta As Double = 0.0) As Double

        ' DataStore Q0 is for Border / Furrow Set
        Dim Q0 As Double = mInflowManagement.AverageInflowRateForCrossSection
        If (Q0 <= 0.0) Then ' Q will be 0.0 for Distance-Based Cutoff/Cutback
            Q0 = mInflowManagement.InflowRate.Value
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                Q0 /= mSystemGeometry.FurrowsPerSet.Value
            End If
        End If

        Dim S0 As Double = mSystemGeometry.AverageSlope
        Dim L As Double = mSystemGeometry.Length.Value
        Dim W As Double = mSystemGeometry.WidthForCrossSection

        UpstreamDepth = Me.UpstreamDepth(Q0, L, W, S0, Beta)

    End Function
    '
    ' Compute Upstream Flow Area based on values passed via parameter list
    '
    Public Function UpstreamArea(ByVal Q As Double, ByVal L As Double, ByVal W As Double, ByVal S0 As Double, _
                                 Optional ByVal Beta As Double = 0.0) As Double
        Dim Y0, AY0, R0, WP0, SF0 As Double
        UpstreamParameters(Q, L, W, S0, Y0, AY0, R0, WP0, SF0, Beta)
        Return AY0
    End Function
    '
    ' Compute Upstream Flow Depth based on current Unit parameters
    '
    Public Function UpstreamArea(ByVal Q As Double, ByVal L As Double, _
                                 Optional ByVal Beta As Double = 0.0) As Double

        Dim S0 As Double = mSystemGeometry.AverageSlope
        Dim W As Double = mSystemGeometry.WidthForCrossSection

        Dim Y0, AY0, R0, WP0, SF0 As Double
        UpstreamParameters(Q, L, W, S0, Y0, AY0, R0, WP0, SF0, Beta)
        Return AY0
    End Function
    '
    ' Compute Upstream Wetted Perimeter based on values passed via parameter list
    '
    Public Function UpstreamWettedPerimeter(ByVal Q As Double, ByVal L As Double, ByVal W As Double, _
                                            ByVal S0 As Double, Optional ByVal Beta As Double = 0.0) As Double
        Dim Y0, AY0, R0, WP0, SF0 As Double
        UpstreamParameters(Q, L, W, S0, Y0, AY0, R0, WP0, SF0, Beta)
        Return WP0
    End Function
    '
    ' Compute Upstream Wetted Perimeter based on current Unit parameters
    '
    Public Function UpstreamWettedPerimeter(Optional ByVal Beta As Double = 0.0) As Double

        ' Get required parameters for Upstream Wetted Perimeter calculations
        Dim Q0 As Double = mInflowManagement.AverageInflowRateForCrossSection
        If (Q0 <= 0.0) Then ' Q will be 0.0 for Distance-Based Cutoff/Cutback
            Q0 = mInflowManagement.InflowRate.Value
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                Q0 /= mSystemGeometry.FurrowsPerSet.Value
            End If
        End If

        Dim S0 As Double = mSystemGeometry.AverageSlope
        Dim L As Double = mSystemGeometry.Length.Value
        Dim W As Double = mSystemGeometry.WidthForCrossSection

        UpstreamWettedPerimeter = Me.UpstreamWettedPerimeter(Q0, L, W, S0, Beta)

    End Function

    Public Function NrcsUpstreamWettedPerimeter() As Double

        ' Get required parameters for Upstream Wetted Perimeter calculations
        Dim Q0 As Double = mInflowManagement.AverageInflowRateForCrossSection
        If (Q0 <= 0.0) Then ' Q will be 0.0 for Distance-Based Cutoff/Cutback
            Q0 = mInflowManagement.InflowRate.Value
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                Q0 /= mSystemGeometry.FurrowsPerSet.Value
            End If
        End If

        Dim S0 As Double = mSystemGeometry.AverageSlope
        If (S0 <= 0.0) Then ' Eq. 5-25 in SCS (1984) Section 15, Ch5 Furrow Irrigation
            Dim L As Double = mSystemGeometry.Length.Value
            S0 = Srfr.SrfrAPI.NrcsHydraulicGradient(Q0, L)
        End If

        Dim n As Double = mSoilCropProperties.ManningN.Value

        NrcsUpstreamWettedPerimeter = Srfr.SrfrAPI.NrcsUpstreamWettedPerimeter(Q0, S0, n)
    End Function

#End Region

#Region " Shape Factors "
    '
    ' Shape Factor calculations user equations in:
    '
    '   Improved Surface Volume Estimates for Surface Irrigaion Volume Balance Calculations
    '   Journal of Irrigation and Drainage Engineering - Aug 2012
    '       Bautista, Strelkoff, Clemmens
    '
    'Const b0 As Double = 0.0984 ' 0.18
    'Const m As Double = 0.0611 ' 0.0588
    Const S0min As Double = 0.00001

    Public Function Beta(ByVal S0 As Double) As Double
        Beta = Srfr.SrfrAPI.Beta(S0)
        'S0 = Math.Max(S0, S0min)
        'Beta = b0 - m * Math.Log10(S0)                              ' Equation 6
    End Function

    Public Function Beta(ByVal Sy As Double, ByVal Qin As Double, ByVal Xa As Double, _
                         ByVal W As Double, ByVal S0 As Double) As Double

        ' Start with estimate of Beta based on Slope
        Beta = Me.Beta(S0)

        ' Binary search for Beta that yields input SigmaY
        Dim minBeta As Double = 0.0
        Dim maxBeta As Double = 1.0

        For iter As Integer = 1 To 20

            Dim sigmaY As Double = Me.SigmaY(Qin, Xa, W, S0, Beta)

            If (ThisClose(sigmaY, Sy, 0.000001)) Then
                Exit Function
            ElseIf (sigmaY < Sy) Then ' Beta is too large
                maxBeta = Beta
            Else ' (Sy < sigmaY) - Beta is too small
                minBeta = Beta
            End If

            Beta = (minBeta + maxBeta) / 2.0
        Next iter

    End Function

    '*********************************************************************************************************
    ' Function SigmaY()     - calculate Surface Shape Factor (Sy) upto the end of advance
    '
    ' Input(s):     Qin     - Inflow rate
    '               Xa      - Advance distance
    '               W       - Border / Furrow width
    '               S0      - Average slope
    '               Beta    - Empirical power law exponent for flow depth equation (optional)
    '
    ' Returns:      Double  - SigmaY (Sy) i.e. Surface Shape Factor
    '
    ' Note - 'Equation n' references in the following code refer to:
    '
    '         Eduardo Bautista's "Expert System for Event Analysis" document (currently version 4)
    '*********************************************************************************************************
    Public Function SigmaY(ByVal Qin As Double, ByVal Xa As Double, ByVal W As Double, ByVal S0 As Double, _
                           Optional ByVal Beta As Double = 0.0) As Double

        S0 = Math.Max(S0, S0min)

        ' If input Beta is undefined, calculate value
        If (Beta <= 0.0) Then
            Beta = Me.Beta(S0)                                                      ' Equation 6
        End If

        Dim L As Double = mSystemGeometry.Length.Value

        Select Case (Me.CrossSection)
            Case CrossSections.Basin, CrossSections.Border

                SigmaY = 1.0 / (Beta + 1.0)                                         ' Equation 7

            Case Else ' Assume CrossSections.Furrow

                Select Case (mSystemGeometry.FurrowShape.Value)

                    Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData

                        Dim m As Double = SystemGeometryRef.PowerLawExponent.Value  ' From Equation 8

                        SigmaY = 1.0 / (Beta * (m + 1.0) + 1.0)                     ' Equation 9

                    Case Else ' Assume FurrowShapes.Trapezoid

                        Dim Y0, AY0, R0, WP0, Sf0 As Double
                        UpstreamParameters(Qin, Xa, W, S0, Y0, AY0, R0, WP0, Sf0, Beta)

                        Dim mSystemGeometry As SystemGeometry = Me.SystemGeometryRef

                        Dim BW As Double = mSystemGeometry.BottomWidth.Value
                        Dim SS As Double = mSystemGeometry.SideSlope.Value

                        If (0.0 < AY0) Then

                            Dim term1 As Double = (Y0 * BW) / (Beta + 1.0)
                            Dim term2 As Double = (Y0 ^ 2 * SS) / (2 * Beta + 1.0)

                            SigmaY = (1.0 / AY0) * (term1 + term2)                  ' Equation 10

                        Else ' AY0 <= 0.0
                            SigmaY = 1.0 / (Beta + 1.0)
                        End If

                End Select
        End Select

    End Function

    '*********************************************************************************************************
    ' Function SigmaYpa()   - calculate Surface Shape Factor (Sy) post advance (open-end only)
    '
    ' Input(s):     Qin     - Inflow rate
    '               Xpa     - Extrapolated advance distance past the end of the field (L)
    '               L       - Border / Furrow length
    '               W       -    "   /    "   width
    '               S0      - Average slope
    '               Beta    - Empirical power law exponent for flow depth equation (optional)
    '
    ' Returns:      Double  - SigmaYpa (Sy) i.e. Surface Shape Factor (post advance)
    '
    ' Note - 'Equation n' references in the following code refer to:
    '
    '         Eduardo Bautista's "Expert System for Event Analysis" document (currently version 4)
    '*********************************************************************************************************
    Public Function SigmaYpa(ByVal Qin As Double, ByVal Xpa As Double, ByVal L As Double, ByVal W As Double, _
                             ByVal S0 As Double, Optional ByVal Beta As Double = 0.0) As Double

        S0 = Math.Max(S0, S0min)

        ' If input Beta is undefined, calculate value
        If (Beta <= 0.0) Then
            Beta = Me.Beta(S0)                                                      ' Equation 6
        End If

        Dim XpaL As Double = Xpa / L
        Dim LXpa As Double = 1.0 - L / Xpa

        Select Case (Me.CrossSection)
            Case CrossSections.Basin, CrossSections.Border

                Dim bTerm As Double = Beta + 1.0
                Dim term1 As Double = 1.0 - LXpa ^ bTerm

                SigmaYpa = (1.0 / bTerm) * XpaL * term1                             ' Equation 12

            Case Else ' Assume CrossSections.Furrow

                Select Case (mSystemGeometry.FurrowShape.Value)

                    Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData

                        Dim m As Double = SystemGeometryRef.PowerLawExponent.Value  ' From Equation 8

                        Dim bTerm As Double = Beta * (m + 1.0) + 1.0
                        Dim term1 As Double = 1.0 - LXpa ^ bTerm

                        SigmaYpa = (1.0 / bTerm) * XpaL * term1                     ' Equation 13

                    Case Else ' Assume FurrowShapes.Trapezoid

                        Dim Y0, AY0, R0, WP0, Sf0 As Double
                        UpstreamParameters(Qin, Xpa, W, S0, Y0, AY0, R0, WP0, Sf0, Beta)

                        Dim mSystemGeometry As SystemGeometry = Me.SystemGeometryRef

                        Dim BW As Double = mSystemGeometry.BottomWidth.Value
                        Dim SS As Double = mSystemGeometry.SideSlope.Value

                        Dim bTerm1 As Double = Beta + 1.0
                        Dim bTerm2 As Double = 2.0 * Beta + 1.0

                        Dim term1 As Double = 1.0 - LXpa ^ bTerm1
                        Dim term2 As Double = 1.0 - LXpa ^ bTerm2

                        Dim term3 As Double = Y0 * BW / bTerm1 * term1
                        Dim term4 As Double = Y0 ^ 2.0 * SS / bTerm2 * term2

                        If (0.0 < AY0) Then
                            SigmaYpa = (1.0 / AY0) * XpaL * (term3 + term4)         ' Equation 14

                        Else ' AY0 <= 0.0
                            SigmaYpa = 1.0 / (Beta + 1.0)
                        End If

                End Select
        End Select

    End Function

#End Region

#Region " Sync Methods "

    Public Sub SyncMeasStationsWithElevationTable()
        Try
            Dim measStationTable As DataTable = mInflowManagement.MeasurementStations.Value

            Dim elevSetParam As DataSetParameter = mSystemGeometry.ElevationTable
            Dim elevSet As DataSet = elevSetParam.Value
            Dim elevTable As DataTable = elevSet.Tables(0)
            Dim elevChange As Boolean = False

            For Each staRow As DataRow In measStationTable.Rows
                Dim staLoc As Double = staRow.Item(sDistanceX)
                Dim staElev As Double = staRow.Item(sElevationX)

                For Each elevRow As DataRow In elevTable.Rows
                    Dim elevLoc As Double = elevRow.Item(sDistanceX)
                    Dim elev As Double = elevRow.Item(sElevationX)

                    If (ThisClose(staLoc, elevLoc, OneDecimeter)) Then
                        If Not (elev = staElev) Then
                            elevRow.Item(sElevationX) = staElev
                            elevChange = True
                        End If
                    End If
                Next elevRow
            Next staRow

            If (elevChange) Then
                elevSetParam.Source = DataStore.Globals.ValueSources.UserEntered
                elevSetParam.Value = elevSet
                mSystemGeometry.ElevationTable = elevSetParam
            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region

#End Region

#Region " Events & Handlers "
    '
    ' Enumeration of properties which may cause a UpdateProperty event)
    '
    Public Enum Reasons
        Name
        Evaluator
        Notes
        DataHistory
        Results
    End Enum
    '
    ' Event generated when a property changes
    '
    Public Event UnitUpdated(ByVal _property As Unit.Reasons)

    Public Sub RaiseResultsEvent()
        RaiseEvent UnitUpdated(Reasons.Results)
    End Sub
    '
    ' MyStore generates change events
    '
    Private Sub MyStore_PropertyDataChanged(ByVal _id As String, ByVal _reason As PropertyNode.Reasons) _
    Handles mMyStore.PropertyDataChanged
        ' Regenerate the DataStore event as a Unit event
        Select Case _id
            Case sUnitName
                RaiseEvent UnitUpdated(Reasons.Name)
            Case sEvaluator
                RaiseEvent UnitUpdated(Reasons.Evaluator)
            Case sUnitNotes
                RaiseEvent UnitUpdated(Reasons.Notes)
            Case sDataHistory
                RaiseEvent UnitUpdated(Reasons.DataHistory)
        End Select
    End Sub

#End Region

End Class
