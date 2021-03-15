
'*************************************************************************************************************
' BasinCriteria class - holds the criteria for BASIN
'
' BasinCriteria is no longer used but is required for backward compatibility to previous versions of WinSRFR.
'*************************************************************************************************************
Imports DataStore

Public Class BasinCriteria

#Region " Identification "
    '
    ' mMyID - unique object ID for DataStore
    '
    Private mMyID As String = "Basin Criteria"
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
    '
    ' There are no longer Basin Criteria; see BorderCriteria for contour properties
    '
#End Region

#Region " Constructor(s) "
    '
    ' New() - Instantiate a new Basin Criteria object
    '
    ' _myID - Object ID string
    '   Nothing or String.Empty - default ID is used
    '
    ' _unit - Parent Unit reference
    '
    Public Sub New(ByVal _myID As String, ByVal _unit As Unit)
        '
        ' Save ID, if one is provided; use default otherwise
        '
        If Not (_myID Is Nothing) Then
            If Not (_myID.Trim = String.Empty) Then
                mMyID = _myID.Trim
            End If
        End If
        '
        ' Save Parent Unit reference and get Parent's Data Store
        '
        If Not (_unit Is Nothing) Then
            mUnit = _unit
            mParentStore = mUnit.MyStore
        Else
            Debug.Assert(False, "Parent Unit is Nothing")
        End If
        '
        ' Add BasinCriteria to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If Not (mMyStore Is Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "BasinCriteria not added to DataStore")
            End If
        Else
            Debug.Assert(False, "Parent's Data Store is Nothing")
        End If

    End Sub
    '
    ' New() - Instantiate a BasinCriteria object; then connect to DataStore
    '
    ' _myStore - DataStore ObjectNode reference
    '
    ' _unit - Parent Unit reference
    '
    Public Sub New(ByVal _myStore As DataStore.ObjectNode, ByVal _unit As Unit)
        '
        ' Restore Parent & Parent's DataStore
        '
        If Not (_unit Is Nothing) Then
            mUnit = _unit
            mParentStore = mUnit.MyStore
        Else
            Debug.Assert(False, "Parent Unit is Nothing")
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

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        BasinCriteria
    End Enum
    '
    ' Event generated when a property's data changes
    '
    Public Event PropertyDataChanged(ByVal _reason As Reasons)
    '
    ' MyStore generates change events
    '
    Private Sub MyStore_PropertyDataChanged(ByVal _id As String, ByVal _reason As PropertyNode.Reasons) _
    Handles mMyStore.PropertyDataChanged
        ' Regenerate the DataStore event as a BasinCriteria event
        RaiseEvent PropertyDataChanged(Reasons.BasinCriteria)
    End Sub

#End Region

End Class
