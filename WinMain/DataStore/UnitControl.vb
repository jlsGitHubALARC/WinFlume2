
'*************************************************************************************************************
' Class UnitControl - Run & UI information associated with using a Unit.
'
' Note - DataStore properties within this class are not included in the list of DataStore objects checked
'        by Unit.DataHasChangedSince().
'*************************************************************************************************************
Imports DataStore

Public Class UnitControl

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "Unit Control"
    Public ReadOnly Property MyID() As String
        Get
            Return mMyID
        End Get
    End Property
    '
    ' Parent Unit
    '
    Private mUnit As Unit
    Public ReadOnly Property UnitRef() As Unit
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

#Region " Analysis Run "

    Public Const sLog As String = "Log"
    Public Const ShowLog As Boolean = False

    Public Property Log() As ArrayListParameter
        Get
            If (ShowLog) Then ' return the Log
                Return mMyStore.GetArrayListParameter(sLog)
            Else ' clear & return the Log
                Dim param As DataStore.Parameter = mMyStore.GetParameter(sLog)
                If (param IsNot Nothing) Then
                    Dim listParam As ArrayListParameter = DirectCast(param, ArrayListParameter)
                    listParam.Array.Clear()
                    Return listParam
                End If
                Return Nothing
            End If
        End Get
        Set(ByVal Value As ArrayListParameter)
            If (ShowLog) Then
                mMyStore.SetParameter(sLog, Value)
            End If
        End Set
    End Property

    Public Const sProductName As String = "Product Name"

    Public ReadOnly Property ProductNameProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sProductName)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As StringParameter = New StringParameter(Application.ProductName)
                mMyStore.AddProperty(sProductName, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sProductName)
            End If

            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property ProductName() As StringParameter
        Get
            Return ProductNameProperty.GetStringParameter()
        End Get
        Set(ByVal Value As StringParameter)
            ProductNameProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sProductVersion As String = "Product Version"

    Public ReadOnly Property ProductVersionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sProductVersion)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As StringParameter = New StringParameter(Application.ProductVersion)
                mMyStore.AddProperty(sProductVersion, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sProductVersion)
            End If

            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property ProductVersion() As StringParameter
        Get
            Return ProductVersionProperty.GetStringParameter()
        End Get
        Set(ByVal Value As StringParameter)
            ProductVersionProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sRunCount As String = "Run Count"

    Public ReadOnly Property RunCountProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRunCount)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(0)
                mMyStore.AddProperty(sRunCount, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sRunCount)
            End If

            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property RunCount() As IntegerParameter
        Get
            Return RunCountProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            RunCountProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearRunCount()
        mMyStore.DeleteProperty(sRunCount)
    End Sub


    Private Const sRunDateTime As String = "Run Date/Time"

    Public ReadOnly Property RunDateTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRunDateTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DateTimeParameter = New DateTimeParameter(System.DateTime.Now)
                mMyStore.AddProperty(sRunDateTime, _parameter)
                _propertyNode = mMyStore.GetProperty(sRunDateTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property RunDateTime() As DateTimeParameter
        Get
            Return RunDateTimeProperty.GetDateTimeParameter()
        End Get
        Set(ByVal Value As DateTimeParameter)
            RunDateTimeProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearRunDateTime()
        mMyStore.DeleteProperty(sRunDateTime)
    End Sub

#End Region

#Region " User Interface "

#Region " World Window Tab Selection "

    Public Const sSelectedTab As String = "Selected Tab"

    Public ReadOnly Property SelectedTabProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSelectedTab)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(0)
                mMyStore.AddProperty(sSelectedTab, _parameter)
                _propertyNode = mMyStore.GetProperty(sSelectedTab)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SelectedTab() As IntegerParameter
        Get
            Return SelectedTabProperty.GetIntegerParameter()
        End Get
        Set(ByVal value As IntegerParameter)
            SelectedTabProperty.SetParameter(value)
        End Set
    End Property

    Public Const sTabGroup As String = "Tab Group"

    Public ReadOnly Property TabGroupProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTabGroup)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(TabGroups.DataTabs)
                mMyStore.AddProperty(sTabGroup, _parameter)
                _propertyNode = mMyStore.GetProperty(sTabGroup)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property TabGroup() As IntegerParameter
        Get
            Return TabGroupProperty.GetIntegerParameter
        End Get
        Set(ByVal value As IntegerParameter)
            TabGroupProperty.SetParameter(value)
        End Set
    End Property

#End Region

#End Region

#Region " Contours "

    Private Const sContourOverlayEnabled As String = "Contour Overlay Enabled"

    Public ReadOnly Property ContourOverlayEnabledProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sContourOverlayEnabled)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As BooleanParameter = New BooleanParameter(False)
                mMyStore.AddProperty(sContourOverlayEnabled, _parameter)
                _propertyNode = mMyStore.GetProperty(sContourOverlayEnabled)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ContourOverlayEnabled() As BooleanParameter
        Get
            Return ContourOverlayEnabledProperty.GetBooleanParameter()
        End Get
        Set(ByVal Value As BooleanParameter)
            ContourOverlayEnabledProperty.SetParameter(Value)
        End Set
    End Property

    Private Const sMajorContourOverlays As String = "Major Contour Overlays"

    Public ReadOnly Property MajorContourOverlaysProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMajorContourOverlays)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As ArrayListParameter = New ArrayListParameter
                mMyStore.AddProperty(sMajorContourOverlays, _parameter)
                _propertyNode = mMyStore.GetProperty(sMajorContourOverlays)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MajorContourOverlays() As ArrayListParameter
        Get
            Return MajorContourOverlaysProperty.GetArrayListParameter()
        End Get
        Set(ByVal Value As ArrayListParameter)
            MajorContourOverlaysProperty.SetParameter(Value)
        End Set
    End Property

    Private Const sMinorContourOverlays As String = "Minor Contour Overlays"

    Public ReadOnly Property MinorContourOverlaysProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinorContourOverlays)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As ArrayListParameter = New ArrayListParameter
                mMyStore.AddProperty(sMinorContourOverlays, _parameter)
                _propertyNode = mMyStore.GetProperty(sMinorContourOverlays)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MinorContourOverlays() As ArrayListParameter
        Get
            Return MinorContourOverlaysProperty.GetArrayListParameter()
        End Get
        Set(ByVal Value As ArrayListParameter)
            MinorContourOverlaysProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Green-Ampt "

    Public Const sGA_EstimationOption As String = "GA Estimation Option"
    Public ReadOnly Property GA_EstimationOptionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGA_EstimationOption)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultGA_EstimationOption)
                mMyStore.AddProperty(sGA_EstimationOption, _integer)
                _propertyNode = mMyStore.GetProperty(sGA_EstimationOption)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property GA_EstimationOption() As IntegerParameter
        Get
            Return GA_EstimationOptionProperty.GetIntegerParameter
        End Get
        Set(ByVal value As IntegerParameter)
            GA_EstimationOptionProperty.SetParameter(value)
        End Set
    End Property


    Public Const sWGA_EstimationOption As String = "WGA Estimation Option"
    Public ReadOnly Property WGA_EstimationOptionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWGA_EstimationOption)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultWGA_EstimationOption)
                mMyStore.AddProperty(sWGA_EstimationOption, _integer)
                _propertyNode = mMyStore.GetProperty(sWGA_EstimationOption)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property WGA_EstimationOption() As IntegerParameter
        Get
            Return WGA_EstimationOptionProperty.GetIntegerParameter
        End Get
        Set(ByVal value As IntegerParameter)
            WGA_EstimationOptionProperty.SetParameter(value)
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
            mParentStore = _unit.MyStore
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Add UnitControl to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then
            mMyStore = mParentStore.AddObject(MyID)

            If Not (mMyStore Is Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "MyStore is Nothing")
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

    Public Sub ClearResults()
        Me.ClearRunCount()
        Me.ClearRunDateTime()
    End Sub

#End Region

#Region " Unit Events & Handlers "
    '
    ' Enumeration of properties which may cause a UpdateProperty event
    '
    Public Enum Reasons
        Log
        SelectedTab
        TabGroup
        RunDateTime
        WGA_EstimationOption
        StationsGraphSelection
    End Enum
    '
    ' Event generated when a property changes
    '
    Public Event PropertyDataUpdated(ByVal _property As UnitControl.Reasons)
    '
    ' MyStore generates change events
    '
    Private Sub MyStore_PropertyDataChanged(ByVal _id As String, ByVal _reason As PropertyNode.Reasons) _
    Handles mMyStore.PropertyDataChanged
        ' Regenerate the DataStore event as a Unit Control event
        Select Case _id
            Case sLog
                RaiseEvent PropertyDataUpdated(Reasons.Log)
            Case sSelectedTab
                RaiseEvent PropertyDataUpdated(Reasons.SelectedTab)
            Case sTabGroup
                RaiseEvent PropertyDataUpdated(Reasons.TabGroup)
            Case sRunDateTime
                RaiseEvent PropertyDataUpdated(Reasons.RunDateTime)
            Case sWGA_EstimationOption
                RaiseEvent PropertyDataUpdated(Reasons.WGA_EstimationOption)
        End Select
    End Sub

#End Region

End Class
