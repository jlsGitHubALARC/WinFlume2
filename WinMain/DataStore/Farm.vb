
'*************************************************************************************************************
' Farm.vb - Farm class
'
' Farm is a container for a related set of Field folders:
'   - Farm Identification
'   - Field List
'*************************************************************************************************************
Imports DataStore

Public Class Farm

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "Farm"
    Public ReadOnly Property MyID() As String
        Get
            Return mMyID
        End Get
    End Property
    '
    ' Reference to parent object (WinSRFR)
    '
    Private mWinSRFR As WinSRFR = Nothing
    Public ReadOnly Property WinSrfrRef() As WinSRFR
        Get
            Return mWinSRFR
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
    ' Farm Name
    '
    Public Const sFarmName As String = "Farm Name"

    Public Property Name() As StringParameter
        Get
            Return mMyStore.GetStringParameter(sFarmName)
        End Get
        Set(ByVal Value As StringParameter)
            mMyStore.SetParameter(sFarmName, Value)
        End Set
    End Property
    '
    ' Farm Owner
    '
    Private Const sFarmOwner As String = "Farm Owner"

    Public Property Owner() As StringParameter
        Get
            Return mMyStore.GetStringParameter(sFarmOwner)
        End Get
        Set(ByVal Value As StringParameter)
            mMyStore.SetParameter(sFarmOwner, Value)
        End Set
    End Property
    '
    ' Creation Date/Time
    '
    Private Const sCreationDateTime As String = "Creation Date/Time"

    Public Property CreationDateTime() As DateTimeParameter
        Get
            Return mMyStore.GetDateTimeParameter(sCreationDateTime)
        End Get
        Set(ByVal Value As DateTimeParameter)
            mMyStore.SetParameter(sCreationDateTime, Value)
        End Set
    End Property
    '
    ' Notes
    '
    Private Const sFarmNotes As String = "Farm Notes"

    Public Property Notes() As StringParameter
        Get
            Return mMyStore.GetStringParameter(sFarmNotes)
        End Get
        Set(ByVal Value As StringParameter)
            mMyStore.SetParameter(sFarmNotes, Value)
        End Set
    End Property
    '
    ' Field Suffix
    '
    Private Const sFieldSuffix As String = "Field Suffix"

    Private Property FieldSuffix() As IntegerParameter
        Get
            Return mMyStore.GetIntegerParameter(sFieldSuffix)
        End Get
        Set(ByVal Value As IntegerParameter)
            mMyStore.SetParameter(sFieldSuffix, Value)
        End Set
    End Property
    '
    ' UI Support
    '
    Private Const sFieldListExpanded As String = "Field List Expanded"

    Public Property FieldListExpanded() As BooleanParameter
        Get
            Return mMyStore.GetBooleanParameter(sFieldListExpanded)
        End Get
        Set(ByVal Value As BooleanParameter)
            mMyStore.SetParameter(sFieldListExpanded, Value)
        End Set
    End Property

#End Region

#Region " Field List "

    Private mFieldList As New ArrayList
    '
    ' Add a Field to the list
    '
    Public Function AddField() As Field

        ' Generate a unique ID for the Field
        Dim _integer As DataStore.IntegerParameter = FieldSuffix
        _integer.Value = _integer.Value + 1
        _integer.Source = DataStore.Globals.ValueSources.Calculated
        FieldSuffix = _integer

        Dim _fieldID As String = String.Format("Field{0}", FieldSuffix.Value)

        ' Create the Field with its unique ID
        Dim _field As Field = New Field(_fieldID, Me)

        If Not (_field Is Nothing) Then
            ' Add it to the Field List
            mFieldList.Add(_field)
        Else
            Debug.Assert(False, "Field was not created")
            mWinSRFR.SeriousError("Farm[AddField]", "Field was not created")
        End If

        Return _field

    End Function

    Public Function AddField(ByVal _fieldObject As DataStore.ObjectNode) As Field

        If Not (_fieldObject Is Nothing) Then

            ' Generate a unique ID for the Field
            Dim _integer As DataStore.IntegerParameter = FieldSuffix
            _integer.Value = _integer.Value + 1
            _integer.Source = DataStore.Globals.ValueSources.Calculated
            FieldSuffix = _integer

            _fieldObject.MyID() = String.Format("Field{0}", FieldSuffix.Value)

            ' Add the Field to the DataStore
            ' It is also added to the FieldList via an Event
            MyStore.AddObject(_fieldObject)
        Else
            Debug.Assert(False, "Field Object is Nothing")
        End If

        Return Nothing

    End Function
    '
    ' Remove a Field from the list
    '
    Public Sub RemoveField(ByVal _field As Field)

        If Not (_field Is Nothing) Then
            ' Remove the Field from the Field List and from the DataStore
            mFieldList.Remove(_field)
            _field.Remove()
        End If
    End Sub
    '
    ' Return the number of Fields in the list
    '
    Public ReadOnly Property FieldCount() As Integer
        Get
            Return mFieldList.Count
        End Get
    End Property
    '
    ' Rebuild the Field List to match the Data Store
    '
    Private Sub RebuildFieldList()

        ' Clear the current Field List
        mFieldList.Clear()

        ' Rebuild it from the Data Store
        Dim _fieldObject As DataStore.ObjectNode = mMyStore.GetFirstObject

        While Not (_fieldObject Is Nothing)

            ' Re-create the Field
            Dim _field As Field = New Field(_fieldObject, Me)

            ' Add it to the Field List
            If Not (_field Is Nothing) Then
                mFieldList.Add(_field)
            Else
                Debug.Assert(False, "Field is Nothing")
            End If

            _fieldObject = mMyStore.GetNextObject
        End While
    End Sub
    '
    ' Get a reference to a Field
    '
    ' Note - GetFirstField() and GetNextField() cannot be used within the Farm class
    '        as this would intefere with any other class trying to use them.
    '
    Private mFieldEnum As System.Collections.IEnumerator

    Public Function GetFirstField() As Field
        ' Reset list enumerator to start of list
        mFieldEnum = mFieldList.GetEnumerator()
        Return GetNextField()
    End Function

    Public Function GetNextField() As Field
        ' Return next Field in list
        ' Return Nothing if at end of list
        If (mFieldEnum.MoveNext) Then
            Dim _field As Field = CType(mFieldEnum.Current, Field)
            Return _field
        End If

        Return Nothing
    End Function
    '
    ' Get a reference to a Field by ID
    '
    Public Function GetFieldByID(ByVal _fieldID As String) As Field
        ' Define the enumerator to scan the Field List
        Dim _enum As System.Collections.IEnumerator = mFieldList.GetEnumerator

        ' Scan the Field List looking for a Field with this name
        While (_enum.MoveNext)
            Dim _field As Field = CType(_enum.Current, Field)

            If (_fieldID = _field.MyID) Then
                Return _field
            End If
        End While

        ' Didn't find it!
        Return Nothing
    End Function
    '
    ' Get a reference to a Field by name
    '
    Public Function GetFieldByName(ByVal _fieldName As String) As Field

        If Not (_fieldName Is Nothing) Then
            ' Define the enumerator to scan the Field List
            Dim _enum As System.Collections.IEnumerator = mFieldList.GetEnumerator

            ' Scan the Field List looking for a Field with this name
            While (_enum.MoveNext)
                Dim _field As Field = CType(_enum.Current, Field)
                If (_fieldName = _field.Name.Value) Then
                    Return _field
                End If
            End While
        End If

        ' Didn't find it!
        Return Nothing
    End Function

#End Region

#Region " Constructor(s) "
    '
    ' Constructor that creates a new Farm and adds it to the Data Store
    '
    Public Sub New(ByVal _myID As String, ByVal _winSRFR As WinSRFR)
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
        If Not (_winSRFR Is Nothing) Then
            mWinSRFR = _winSRFR
            mParentStore = mWinSRFR.MyStore
        Else
            Debug.Assert(False, "WinSRFR is Nothing")
        End If
        '
        ' Add Farm to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            ' Disable event generation during initialization
            mParentStore.EventsEnabled = False
            mMyStore = mParentStore.AddObject(MyID)
            '
            ' Add serializable data to Farm's Data Store
            '
            If Not (mMyStore Is Nothing) Then

                Dim _parameter As Parameter = Nothing
                Dim _success As Integer = 0
                Dim _count As Integer = 0
                '
                ' Farm data
                '
                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sFarmName, _parameter))
                _count += 1

                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sFarmOwner, _parameter))
                _count += 1

                _parameter = New StringParameter(String.Empty)
                _success += CInt(mMyStore.AddProperty(sFarmNotes, _parameter))
                _count += 1

                _parameter = New DateTimeParameter(System.DateTime.Now)
                _success += CInt(mMyStore.AddProperty(sCreationDateTime, _parameter))
                _count += 1
                '
                ' Field List data
                '
                _parameter = New IntegerParameter(0)
                _success += CInt(mMyStore.AddProperty(sFieldSuffix, _parameter))
                _count += 1

                _parameter = New BooleanParameter(True)
                _success += CInt(mMyStore.AddProperty(sFieldListExpanded, _parameter))
                _count += 1

                ' Verify this worked
                Debug.Assert(Not _parameter Is Nothing, "Parameter was not created")
                Debug.Assert(_success = -_count, "All Properties were not added")

                ' Enable event generation
                mMyStore.EventsEnabled = True
                mParentStore.EventsEnabled = True

            Else
                Debug.Assert(False, "Farm not added to Data Store")
            End If
        Else
            Debug.Assert(False, "Parent Data Store is Nothing")
        End If

    End Sub
    '
    ' Constructor that re-creates a Farm from the Data Store
    '
    Public Sub New(ByVal _myStore As DataStore.ObjectNode, ByVal _winSRFR As WinSRFR)
        '
        ' Get Parent & Parent's DataStore
        '
        If Not (_winSRFR Is Nothing) Then
            mWinSRFR = _winSRFR
            mParentStore = mWinSRFR.MyStore
        Else
            Debug.Assert(False, "WinSRFR is Nothing")
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
            RebuildFieldList()

            ' Enable event generation
            mMyStore.EventsEnabled = True
            mParentStore.EventsEnabled = True

        Else
            Debug.Assert(False, "MyStore is Nothing")
        End If
    End Sub
    '
    ' Remove the Farm
    '
    Public Sub Remove()
        ' Remove Farm from the Data Store
        Dim _object As DataStore.ObjectNode = mParentStore.GetObject(MyID)

        If Not (_object Is Nothing) Then
            mParentStore.RemoveObject(MyID)
        Else
            Debug.Assert(False, "Farm not in the Data Store")
        End If
    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Enumeration of properties which may cause a UpdateProperty event)
    '
    Public Enum Reasons
        Name
        Owner
        Notes
        FieldList
    End Enum
    '
    ' Event generated when a property changes
    '
    Public Event FarmUpdated(ByVal _reason As Farm.Reasons)
    '
    ' MyStore generates change events
    '
    Private Sub MyStore_ObjectDataChanged(ByVal _reason As ObjectNode.Reasons) _
    Handles mMyStore.ObjectDataChanged
        ' Regenerate the DataStore event as a Farm event
        Select Case _reason
            Case ObjectNode.Reasons.ObjectListChanged
                RebuildFieldList()
                RaiseEvent FarmUpdated(Reasons.FieldList)
        End Select
    End Sub

    Private Sub MyStore_PropertyDataChanged(ByVal _id As String, ByVal _reason As PropertyNode.Reasons) _
    Handles mMyStore.PropertyDataChanged
        ' Regenerate the DataStore event as a Farm event
        Select Case _id
            Case sFarmName
                RaiseEvent FarmUpdated(Reasons.Name)
            Case sFarmOwner
                RaiseEvent FarmUpdated(Reasons.Owner)
            Case sFarmNotes
                RaiseEvent FarmUpdated(Reasons.Notes)
        End Select
    End Sub

#End Region

End Class
