
'*************************************************************************************************************
' World.vb - World class
'
' World is the container for a set of related Analyses:
'   - World Identification
'   - Analysis List
'*************************************************************************************************************
Imports DataStore

Public Class World

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "World"
    Public ReadOnly Property MyID() As String
        Get
            Return mMyID
        End Get
    End Property
    '
    ' Reference to parent object (Field)
    '
    Private mField As Field
    Public ReadOnly Property FieldRef() As Field
        Get
            Return mField
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
    '
    ' World Type
    '
    Private Const sWorldType070 As String = "WorldType"
    Public Const sWorldType As String = "World Type"

    Public ReadOnly Property WorldTypeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWorldType)

            ' If property was not found; try previous version's name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sWorldType070)

                ' If it was still not found; create it
                If (_propertyNode Is Nothing) Then
                    Dim _parameter As IntegerParameter = New IntegerParameter(DefaultWorldType)
                    mMyStore.AddProperty(sWorldType, _parameter)
                    _propertyNode = mMyStore.GetProperty(sWorldType)
                Else
                    ' The previous named version was found; update it
                    _propertyNode.MyID = sWorldType
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property WorldType() As IntegerParameter
        Get
            Return WorldTypeProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            WorldTypeProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' World Name
    '
    Private Const sWorldName070 As String = "WorldName"
    Public Const sWorldName As String = "World Name"

    Public ReadOnly Property NameProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWorldName)

            ' If property was not found; try previous version's name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sWorldName070)

                ' If it was still not found; create it
                If (_propertyNode Is Nothing) Then
                    Dim _parameter As StringParameter = New StringParameter(String.Empty)
                    mMyStore.AddProperty(sWorldName, _parameter)
                    _propertyNode = mMyStore.GetProperty(sWorldName)
                Else
                    ' The previous named version was found; update it
                    _propertyNode.MyID = sWorldName
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Name() As StringParameter
        Get
            Return NameProperty.GetStringParameter()
        End Get
        Set(ByVal Value As StringParameter)
            NameProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Creation Date/Time
    '
    Private Const sCreationDateTime As String = "Creation Date/Time"

    Public ReadOnly Property CreationDateTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCreationDateTime)

            ' If property was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _dateTime As DateTime
                If Not (mField Is Nothing) Then
                    _dateTime = mField.CreationDateTime.Value
                Else
                    _dateTime = System.DateTime.Now
                End If

                Dim _parameter As DateTimeParameter = New DateTimeParameter(_dateTime)
                mMyStore.AddProperty(sCreationDateTime, _parameter)
                _propertyNode = mMyStore.GetProperty(sCreationDateTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CreationDateTime() As DateTimeParameter
        Get
            Return CreationDateTimeProperty.GetDateTimeParameter()
        End Get
        Set(ByVal Value As DateTimeParameter)
            CreationDateTimeProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Notes
    '
    Private Const sWorldNotes As String = "World Notes"

    Public ReadOnly Property WorldNotesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWorldNotes)

            ' If property was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As StringParameter = New StringParameter(String.Empty)
                mMyStore.AddProperty(sWorldNotes, _parameter)
                _propertyNode = mMyStore.GetProperty(sWorldNotes)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Notes() As StringParameter
        Get
            Return WorldNotesProperty.GetStringParameter()
        End Get
        Set(ByVal Value As StringParameter)
            WorldNotesProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Analysis Suffix
    '
    Private Const sAnalysisSuffix As String = "Analysis Suffix"

    Private Property AnalysisSuffix() As IntegerParameter
        Get
            Return mMyStore.GetIntegerParameter(sAnalysisSuffix)
        End Get
        Set(ByVal Value As IntegerParameter)
            mMyStore.SetParameter(sAnalysisSuffix, Value)
        End Set
    End Property
    '
    ' UI Support
    '
    Private Const sAnalysisListExpanded As String = "Analysis List Expanded"

    Public Property AnalysisListExpanded() As BooleanParameter
        Get
            Return mMyStore.GetBooleanParameter(sAnalysisListExpanded)
        End Get
        Set(ByVal Value As BooleanParameter)
            mMyStore.SetParameter(sAnalysisListExpanded, Value)
        End Set
    End Property

#End Region

#Region " Analysis List "

    Private mAnalysisList As New ArrayList
    '
    ' Add an Analysis to the list
    '
    Public Function AddAnalysis() As Unit

        ' Generate a unique ID for the Analysis
        Dim _integer As DataStore.IntegerParameter = AnalysisSuffix
        _integer.Value = _integer.Value + 1
        _integer.Source = DataStore.Globals.ValueSources.Calculated
        AnalysisSuffix = _integer

        Dim _analysisID As String = String.Format("Analysis{0}", AnalysisSuffix.Value)

        ' Get a new Analysis; this also adds it to the Data Store
        Dim _analysis As Unit = New Unit(_analysisID, Me)

        If Not (_analysis Is Nothing) Then

            ' Use default evaluator from User Preferences
            Dim _evaluator As StringParameter = _analysis.Evaluator
            _evaluator.Value = WinSRFR.UserPreferences.DefaultEvaluator
            _analysis.Evaluator = _evaluator

            ' Add it to the Analysis List
            mAnalysisList.Add(_analysis)
        Else
            Debug.Assert(False, "Analysis was not New'd")
        End If

        Return _analysis

    End Function
    '
    ' Add an Analysis Object to the DataStore
    '
    Public Sub AddAnalysisObject(ByVal _analysisObject As DataStore.ObjectNode)

        If Not (_analysisObject Is Nothing) Then

            ' Generate a unique ID for the Analysis
            Dim _integer As DataStore.IntegerParameter = AnalysisSuffix
            _integer.Value = _integer.Value + 1
            _integer.Source = DataStore.Globals.ValueSources.Calculated
            AnalysisSuffix = _integer

            _analysisObject.MyID() = String.Format("Analysis{0}", AnalysisSuffix.Value)

            ' Add the Analysis to the DataStore
            ' It is also added to the AnalysisList via an Event
            MyStore.AddObject(_analysisObject)
        Else
            Debug.Assert(False, "Analysis Object is Nothing")
        End If

        ' If Analysis is being added to Simulation World; verify SRFR Criteria
        If (Me.WorldType.Value = WorldTypes.SimulationWorld) Then
            ' Create a corresponding Analysis
            Dim _analysis As Unit = New Unit(_analysisObject, Me)
            ' Verify Solution Model & DMLMOD
            _analysis.SrfrCriteriaRef.CheckSolutionModel()
        End If

    End Sub
    '
    ' Remove an Analysis from the list
    '
    Public Sub RemoveAnalysis(ByVal _analysis As Unit)

        If Not (_analysis Is Nothing) Then
            ' Remove the Analysis from the Analysis List and from the DataStore
            mAnalysisList.Remove(_analysis)
            _analysis.Remove()
        End If
    End Sub
    '
    ' Return the number of Analyses in the list
    '
    Public ReadOnly Property AnalysisCount() As Integer
        Get
            Return mAnalysisList.Count
        End Get
    End Property
    '
    ' Rebuild the Analysis List to match the Data Store
    '
    Private Sub RebuildAnalysisList()

        ' Clear the current Analysis List
        mAnalysisList.Clear()

        ' Rebuild it from the Data Store
        Dim _analysisObject As DataStore.ObjectNode = mMyStore.GetFirstObject

        While Not (_analysisObject Is Nothing)

            ' Re-create the Analysis
            Dim _analysis As Unit = New Unit(_analysisObject, Me)

            ' Add it to the Analysis List
            If Not (_analysis Is Nothing) Then
                mAnalysisList.Add(_analysis)
            Else
                Debug.Assert(False, "Analysis is Nothing")
            End If

            _analysisObject = mMyStore.GetNextObject
        End While
    End Sub
    '
    ' Get a reference to a Analysis
    '
    Private mAnalysisEnum As System.Collections.IEnumerator

    Public Function GetFirstAnalysis() As Unit
        ' Reset list enumerator to start of list
        mAnalysisEnum = mAnalysisList.GetEnumerator()
        Return GetNextAnalysis()
    End Function

    Public Function GetNextAnalysis() As Unit
        ' Return next Analysis in list
        ' Return Nothing if at end of list
        While (mAnalysisEnum.MoveNext)
            Dim _analysis As Unit = CType(mAnalysisEnum.Current, Unit)
            Dim _object As ObjectNode = mMyStore.GetObject(_analysis.MyID)
            If Not (_object Is Nothing) Then
                Return _analysis
            End If
        End While
        Return Nothing
    End Function
    '
    ' Get a reference to a Analysis by ID
    '
    Public Function GetAnalysisByID(ByVal _analysisID As String) As Unit
        ' Define the enumerator to scan the Analysis List
        Dim _enum As System.Collections.IEnumerator = mAnalysisList.GetEnumerator

        ' Scan the Analysis List looking for a Analysis with this name
        While (_enum.MoveNext)
            Dim _analysis As Unit = CType(_enum.Current, Unit)
            If (_analysisID = _analysis.MyID) Then
                Return _analysis
            End If
        End While

        ' Didn't find it!
        Return Nothing
    End Function
    '
    ' Get a reference to a Analysis by name
    '
    Public Function GetAnalysisByName(ByVal _analysisName As String) As Unit

        If Not (_analysisName Is Nothing) Then
            ' Define the enumerator to scan the Analysis List
            Dim _enum As System.Collections.IEnumerator = mAnalysisList.GetEnumerator

            ' Scan the Analysis List looking for a Analysis with this name
            While (_enum.MoveNext)
                Dim _analysis As Unit = CType(_enum.Current, Unit)
                If (_analysisName = _analysis.Name.Value) Then
                    Return _analysis
                End If
            End While
        End If

        ' Didn't find it!
        Return Nothing
    End Function

#End Region

#Region " Constructor(s) "
    '
    ' Constructor that creates a new World and adds it to the Data Store
    '
    Public Sub New(ByVal _myID As String, ByVal _field As Field)
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
        If Not (_field Is Nothing) Then
            mField = _field
            mParentStore = mField.MyStore
        Else
            Debug.Assert(False, "Field is Nothing")
        End If
        '
        ' Add Unit to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            ' Disable event generation during initialization
            mParentStore.EventsEnabled = False
            mMyStore = mParentStore.AddObject(MyID)
            '
            ' Add serializable data to Field's Data Store
            '
            If Not (mMyStore Is Nothing) Then

                Dim _parameter As Parameter = Nothing
                Dim _success As Integer = 0
                Dim _count As Integer = 0
                '
                ' World data
                '
                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sWorldName, _parameter))
                _count += 1

                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sWorldNotes, _parameter))
                _count += 1

                _parameter = New DateTimeParameter(System.DateTime.Now)
                _success += CInt(mMyStore.AddProperty(sCreationDateTime, _parameter))
                _count += 1
                '
                ' Analysis List data
                '
                _parameter = New IntegerParameter(0)
                _success += CInt(mMyStore.AddProperty(sAnalysisSuffix, _parameter))
                _count += 1

                _parameter = New BooleanParameter(True)
                _success += CInt(mMyStore.AddProperty(sAnalysisListExpanded, _parameter))
                _count += 1

                ' Verify this worked
                Debug.Assert(Not _parameter Is Nothing, "Parameter was not created")
                Debug.Assert(_success = -_count, "All Properties were not added")

                ' Enable event generation
                mMyStore.EventsEnabled = True
                mParentStore.EventsEnabled = True

            Else
                Debug.Assert(False, "World not added to Data Store")
            End If
        Else
            Debug.Assert(False, "Parent's Data Store is Nothing")
        End If

    End Sub
    '
    ' Constructor that restores a World from the Data Store
    '
    Public Sub New(ByVal _myStore As DataStore.ObjectNode, ByVal _field As Field)
        '
        ' Restore Parent & Parent's DataStore
        '
        If Not (_field Is Nothing) Then
            mField = _field
            mParentStore = mField.MyStore
        Else
            Debug.Assert(False, "Field is Nothing")
        End If
        '
        ' Restore MyStore, ID & contained Objects
        '
        If Not (_myStore Is Nothing) Then

            ' Disable event generation during initialization
            mParentStore.EventsEnabled = False

            ' Restore identification
            mMyStore = _myStore
            mMyID = mMyStore.MyID

            ' Restore contained Objects
            RebuildAnalysisList()

            ' Enable event generation
            mMyStore.EventsEnabled = True
            mParentStore.EventsEnabled = True

        Else
            Debug.Assert(False, "MyStore is Nothing")
        End If
    End Sub
    '
    ' Remove the World
    '
    Public Sub Remove()
        ' Remove this World from the Data Store
        Dim _object As DataStore.ObjectNode = mParentStore.GetObject(MyID)

        If Not (_object Is Nothing) Then
            mParentStore.RemoveObject(MyID)
        Else
            Debug.Assert(False, "World was not in Data Store")
        End If
    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Enumeration of properties which may cause a UpdateProperty event)
    '
    Public Enum Reasons
        Name
        Notes
        AnalysisList
    End Enum
    '
    ' Event generated when a property changes
    '
    Public Event WorldUpdated(ByVal _property As World.Reasons)
    '
    ' MyStore generates change events
    '
    Private Sub MyStore_ObjectDataChanged(ByVal _reason As ObjectNode.Reasons) _
    Handles mMyStore.ObjectDataChanged
        ' Regenerate the DataStore event as a World event
        Select Case _reason
            Case ObjectNode.Reasons.ObjectListChanged
                RebuildAnalysisList()
                RaiseEvent WorldUpdated(Reasons.AnalysisList)
        End Select
    End Sub

    Private Sub MyStore_PropertyDataChanged(ByVal _id As String, ByVal _reason As PropertyNode.Reasons) _
    Handles mMyStore.PropertyDataChanged
        ' Regenerate the DataStore event as a World event
        Select Case _id
            Case sWorldName
                RaiseEvent WorldUpdated(Reasons.Name)
            Case sWorldNotes
                RaiseEvent WorldUpdated(Reasons.Notes)
        End Select
    End Sub

#End Region

End Class
