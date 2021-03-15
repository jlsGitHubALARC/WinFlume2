
'*************************************************************************************************************
' Field.vb - Field class
'
' Field is a container for a set of related World folders:
'   - Field Identification
'   - World List
'*************************************************************************************************************
Imports DataStore

Public Class Field

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "Field"
    Public ReadOnly Property MyID() As String
        Get
            Return mMyID
        End Get
    End Property
    '
    ' Reference to parent object (Farm)
    '
    Private mFarm As Farm
    Public ReadOnly Property FarmRef() As Farm
        Get
            Return mFarm
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
    ' Field Name
    '
    Private Const sFieldName070 As String = "FieldName"
    Public Const sFieldName As String = "Field Name"

    Public ReadOnly Property NameProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFieldName)

            ' If property was not found; try previous version's name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sFieldName070)

                ' If it was still not found; create it
                If (_propertyNode Is Nothing) Then
                    Dim _parameter As StringParameter = New StringParameter(String.Empty)
                    mMyStore.AddProperty(sFieldName, _parameter)
                    _propertyNode = mMyStore.GetProperty(sFieldName)
                Else
                    ' The previous named version was found; update it
                    _propertyNode.MyID = sFieldName
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
                If Not (mFarm Is Nothing) Then
                    _dateTime = mFarm.CreationDateTime.Value
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
    Private Const sFieldNotes As String = "Field Notes"

    Public ReadOnly Property FieldNotesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFieldNotes)

            ' If property was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As StringParameter = New StringParameter(String.Empty)
                mMyStore.AddProperty(sFieldNotes, _parameter)
                _propertyNode = mMyStore.GetProperty(sFieldNotes)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Notes() As StringParameter
        Get
            Return FieldNotesProperty.GetStringParameter()
        End Get
        Set(ByVal Value As StringParameter)
            FieldNotesProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' World Suffix
    '
    Private Const sWorldSuffix As String = "World Suffix"

    Private Property WorldSuffix() As IntegerParameter
        Get
            Return mMyStore.GetIntegerParameter(sWorldSuffix)
        End Get
        Set(ByVal Value As IntegerParameter)
            mMyStore.SetParameter(sWorldSuffix, Value)
        End Set
    End Property
    '
    ' UI Support
    '
    Private Const sWorldListExpanded As String = "World List Expanded"

    Public Property WorldListExpanded() As BooleanParameter
        Get
            Return mMyStore.GetBooleanParameter(sWorldListExpanded)
        End Get
        Set(ByVal Value As BooleanParameter)
            mMyStore.SetParameter(sWorldListExpanded, Value)
        End Set
    End Property

#End Region

#Region " World List "

    Private mWorldList As New ArrayList
    '
    ' Add an World to the list
    '
    Public Function AddWorld() As World

        ' Generate a unique ID for the World
        Dim _integer As DataStore.IntegerParameter = WorldSuffix
        _integer.Value = _integer.Value + 1
        _integer.Source = DataStore.Globals.ValueSources.Calculated
        WorldSuffix = _integer

        Dim _worldID As String = String.Format("World{0}", WorldSuffix.Value)

        ' Create the World with its unique ID
        Dim _world As World = New World(_worldID, Me)

        If Not (_world Is Nothing) Then
            ' Add it to the World List
            mWorldList.Add(_world)
        Else
            Debug.Assert(False, "World was not New'd")
        End If

        Return _world

    End Function

    Public Function AddWorld(ByVal _worldType As WorldTypes) As World

        ' Add the World then set its type
        Dim _world As World = AddWorld()

        Dim _integer As DataStore.IntegerParameter = _world.WorldType
        _integer.Value = _worldType
        _integer.Source = DataStore.Globals.ValueSources.UserEntered
        _world.WorldType = _integer

        Return _world

    End Function

    Public Function AddWorld(ByVal _worldObject As DataStore.ObjectNode) As World

        If Not (_worldObject Is Nothing) Then

            ' Generate a unique ID for the World
            Dim _integer As DataStore.IntegerParameter = WorldSuffix
            _integer.Value = _integer.Value + 1
            _integer.Source = DataStore.Globals.ValueSources.Calculated
            WorldSuffix = _integer

            _worldObject.MyID() = String.Format("World{0}", WorldSuffix.Value)

            ' Add the World to the DataStore
            ' It is also added to the WorldList via an Event
            MyStore.AddObject(_worldObject)
        Else
            Debug.Assert(False, "World Object is Nothing")
        End If

        Return Nothing

    End Function
    '
    ' Remove an World from the list
    '
    Public Sub RemoveWorld(ByVal _world As World)

        If Not (_world Is Nothing) Then
            ' Remove the World from the World List and from the DataStore
            mWorldList.Remove(_world)
            _world.Remove()
        End If

    End Sub
    '
    ' Return the number of Worlds in the list
    '
    Public ReadOnly Property WorldCount() As Integer
        Get
            Return mWorldList.Count
        End Get
    End Property
    '
    ' Rebuild the World List to match the Data Store
    '
    Private Sub RebuildWorldList()

        ' Clear the current World List
        mWorldList.Clear()

        ' Rebuild it from the Data Store
        Dim _worldObject As DataStore.ObjectNode = mMyStore.GetFirstObject

        While Not (_worldObject Is Nothing)

            ' Re-create the World
            Dim _world As World = New World(_worldObject, Me)

            ' Add it to the World List
            If Not (_world Is Nothing) Then
                mWorldList.Add(_world)
            Else
                Debug.Assert(False, "World is Nothing")
            End If

            _worldObject = mMyStore.GetNextObject
        End While

    End Sub
    '
    ' Get a reference to a World
    '
    ' Note - GetFirstWorld() and GetNextWorld() cannot be used within the Field class
    '        as this would intefere with any other class trying to use them.
    '
    Private mWorldEnum As System.Collections.IEnumerator

    Public Function GetFirstWorld() As World
        ' Reset list enumerator to start of list
        mWorldEnum = mWorldList.GetEnumerator()
        Return GetNextWorld()
    End Function

    Public Function GetNextWorld() As World
        ' Return next World in list
        ' Return Nothing if at end of list
        If (mWorldEnum.MoveNext) Then
            Dim _world As World = CType(mWorldEnum.Current, World)
            Return _world
        Else
            Return Nothing
        End If
    End Function

    Public Function GetFirstWorld(ByVal _worldType As WorldTypes) As World
        ' Reset list enumerator to start of list
        mWorldEnum = mWorldList.GetEnumerator()
        Return GetNextWorld(_worldType)
    End Function

    Public Function GetNextWorld(ByVal _worldType As WorldTypes) As World
        ' Return next typed World in list
        ' Return Nothing if at end of list
        While (mWorldEnum.MoveNext)
            Dim _world As World = CType(mWorldEnum.Current, World)
            If (_world.WorldType.Value = _worldType) Then
                Return _world
            End If
        End While

        Return Nothing
    End Function
    '
    ' Get a reference to a World by ID
    '
    Public Function GetWorldByID(ByVal _worldID As String) As World
        ' Define the enumerator to scan the World List
        Dim _enum As System.Collections.IEnumerator = mWorldList.GetEnumerator

        ' Scan the World List looking for a World with this ID
        While (_enum.MoveNext)
            Dim _world As World = CType(_enum.Current, World)
            If (_worldID = _world.MyID) Then
                Return _world
            End If
        End While

        ' Didn't find it!
        Return Nothing
    End Function
    '
    ' Get a reference to a World by name
    '
    Public Function GetWorldByName(ByVal _type As WorldTypes, ByVal _worldName As String) As World

        If Not (_worldName Is Nothing) Then
            ' Define the enumerator to scan the World List
            Dim _enum As System.Collections.IEnumerator = mWorldList.GetEnumerator

            ' Scan the World List looking for a World with this name
            While (_enum.MoveNext)
                Dim _world As World = CType(_enum.Current, World)
                If ((_type = _world.WorldType.Value) And (_worldName = _world.Name.Value)) Then
                    Return _world
                End If
            End While
        End If

        ' Didn't find it!
        Return Nothing
    End Function

#End Region

#Region " Constructor(s) "
    '
    ' Constructor that creates a new Field and adds it to the Data Store
    '
    Public Sub New(ByVal _myID As String, ByVal _farm As Farm)
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
        If Not (_farm Is Nothing) Then
            mFarm = _farm
            mParentStore = _farm.MyStore
        Else
            Debug.Assert(False, "Farm is Nothing")
        End If
        '
        ' Add Field to Parent's Data Store
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
                ' Field data
                '
                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sFieldName, _parameter))
                _count += 1

                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sFieldNotes, _parameter))
                _count += 1

                _parameter = New DateTimeParameter(System.DateTime.Now)
                _success += CInt(mMyStore.AddProperty(sCreationDateTime, _parameter))
                _count += 1
                '
                ' World List data
                '
                _parameter = New IntegerParameter(0)
                _success += CInt(mMyStore.AddProperty(sWorldSuffix, _parameter))
                _count += 1

                _parameter = New BooleanParameter(True)
                _success += CInt(mMyStore.AddProperty(sWorldListExpanded, _parameter))
                _count += 1

                ' Verify this worked
                Debug.Assert(Not _parameter Is Nothing, "Parameter was not created")
                Debug.Assert(_success = -_count, "All Properties were not added")

                ' Enable event generation
                mMyStore.EventsEnabled = True
                mParentStore.EventsEnabled = True

            Else
                Debug.Assert(False, "Field not added to Data Store")
            End If
        Else
            Debug.Assert(False, "Parent's Data Store is Nothing")
        End If

    End Sub
    '
    ' Constructor that re-creates a Field from the Data Store
    '
    Public Sub New(ByVal _myStore As DataStore.ObjectNode, ByVal _farm As Farm)
        '
        ' Get Parent & Parent's DataStore
        '
        If Not (_farm Is Nothing) Then
            mFarm = _farm
            mParentStore = mFarm.MyStore
        Else
            Debug.Assert(False, "Farm is Nothing")
        End If
        '
        ' Save MyStore & ID
        '
        If Not (_myStore Is Nothing) Then

            ' Disable event generation during initialization
            mParentStore.EventsEnabled = False

            ' Restore identification
            mMyStore = _myStore
            mMyID = mMyStore.MyID

            ' Restore contained Objects
            RebuildWorldList()

            ' Enable event generation
            mMyStore.EventsEnabled = True
            mParentStore.EventsEnabled = True

        Else
            Debug.Assert(False, "MyStore is Nothing")
        End If
    End Sub
    '
    ' Remove the Field
    '
    Public Sub Remove()
        ' Remove Field from the Farm Store
        Dim _object As DataStore.ObjectNode = mParentStore.GetObject(MyID)

        If Not (_object Is Nothing) Then
            mParentStore.RemoveObject(MyID)
        Else
            Debug.Assert(False, "Field was not in Data Store")
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
        WorldList
    End Enum
    '
    ' Event generated when a property changes
    '
    Public Event FieldUpdated(ByVal _property As Field.Reasons)
    '
    ' MyStore generates change events
    '
    Private Sub MyStore_ObjectDataChanged(ByVal _reason As ObjectNode.Reasons) _
    Handles mMyStore.ObjectDataChanged
        ' Regenerate the DataStore event as a Field event
        Select Case _reason
            Case ObjectNode.Reasons.ObjectListChanged
                RebuildWorldList()
                RaiseEvent FieldUpdated(Reasons.WorldList)
        End Select
    End Sub

    Private Sub MyStore_PropertyDataChanged(ByVal _id As String, ByVal _reason As PropertyNode.Reasons) _
    Handles mMyStore.PropertyDataChanged
        ' Regenerate the DataStore event as a Field event
        Select Case _id
            Case sFieldName
                RaiseEvent FieldUpdated(Reasons.Name)
            Case sFieldNotes
                RaiseEvent FieldUpdated(Reasons.Notes)
        End Select
    End Sub

#End Region

End Class
