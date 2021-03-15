
'*************************************************************************************************************
' Performance Results properties
'
' PerformanceResults contains the Performance results from a WinSRFR Run.
'
' This class contains the Results that DO NOT fit under:
'       SystemGeometry      - field geometry
'       InflowManagement    - inflow & surface flow
'       SoilCropProperties  - infiltration & roughness
'*************************************************************************************************************
Imports DataStore

Public Class PerformanceResults

#Region " Identification "
    '
    ' mMyID - unique object ID for DataStore
    '
    Private mMyID As String = "Performance Results"
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

#Region " BORDER Data Classes "

#Region " Curve Label "

    <Serializable()> _
    Public Class CurveLabel

        Public mFlags As Integer = 0
        Public mX As Double = 0.0
        Public mY As Double = 0.0
        Public mLabel As String = Nothing

    End Class

#End Region

#Region " Curve Point "

    <Serializable()> _
    Public Class CurvePoint

        Public mX As Double = 0.0
        Public mY As Double = 0.0
        Public mFlags As Integer = 0

    End Class

#End Region

#Region " Graph Curve "

    <Serializable()> _
    Public Class GraphCurve

        Public mFlags As Integer = 0
        Public mColorFG As Integer = 0
        Public mColorBG As Integer = 0
        Public mLineStyle As Integer = 0
        Public mLineWidth As Double = 0.0
        Public mExtent As Integer = 0
        Public mRows As Integer = 0
        Public mColumns As Integer = 0

        Public mLabels As ArrayList = Nothing

        Public mPoints As ArrayList = Nothing

    End Class

#End Region

#Region " Border Graph "

    <Serializable()> _
    Public Class BorderGraph

        Public mFlags As Integer = 0
        Public mType As Integer = 0
        Public mHelpContext As Integer = 0

        Public mSubtitle As String = Nothing
        Public mTitle As String = Nothing
        Public mCaption1 As String = Nothing
        Public mCaption2 As String = Nothing
        Public mAbscissa As String = Nothing
        Public mOrdinate As String = Nothing
        Public mCoord_abs As String = Nothing
        Public mCoord_ord As String = Nothing

        Public mEvaluationSubtitle As String = Nothing
        Public mEvaluationTitle As String = Nothing
        Public mEvaluationText As String = Nothing

        Public mCurves As ArrayList = Nothing

    End Class

#End Region

#Region " Border Evaluation "

    <Serializable()> _
    Public Class BorderEvaluation

        Public mSubtitle As String = Nothing
        Public mTitle As String = Nothing
        Public mText As String = Nothing

    End Class

#End Region

#End Region

#Region " Serialized Properties "

#Region " Errors & Warnings "
    '
    ' Errors
    '
    Private Const sErrorCount As String = "Error Count"

    Public ReadOnly Property ErrorCountProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErrorCount)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(0)
                mMyStore.AddProperty(sErrorCount, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sErrorCount)
            End If

            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property ErrorCount() As IntegerParameter
        Get
            Return ErrorCountProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            ErrorCountProperty.SetParameter(Value)
        End Set
    End Property


    Private Const sErrorStack As String = "Error Stack"

    Public ReadOnly Property ErrorStackProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErrorStack)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As ArrayListParameter = New ArrayListParameter
                mMyStore.AddProperty(sErrorStack, _parameter)
                _propertyNode = mMyStore.GetProperty(sErrorStack)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErrorStack() As ArrayListParameter
        Get
            Return ErrorStackProperty.GetArrayListParameter()
        End Get
        Set(ByVal Value As ArrayListParameter)
            ErrorStackProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Warnings
    '
    Private Const sWarningCount As String = "Warning Count"

    Public ReadOnly Property WarningCountProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWarningCount)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(0)
                mMyStore.AddProperty(sWarningCount, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sWarningCount)
            End If

            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property WarningCount() As IntegerParameter
        Get
            Return WarningCountProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            WarningCountProperty.SetParameter(Value)
        End Set
    End Property


    Private Const sWarningStack As String = "Warning Stack"

    Public ReadOnly Property WarningStackProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWarningStack)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As ArrayListParameter = New ArrayListParameter
                mMyStore.AddProperty(sWarningStack, _parameter)
                _propertyNode = mMyStore.GetProperty(sWarningStack)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property WarningStack() As ArrayListParameter
        Get
            Return WarningStackProperty.GetArrayListParameter()
        End Get
        Set(ByVal Value As ArrayListParameter)
            WarningStackProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Design / Operation Results "

    Private Const sDesignContour As String = "Design Contour"

    Public ReadOnly Property DesignContourProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDesignContour)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As ContourParameter = New ContourParameter(Nothing)
                mMyStore.AddProperty(sDesignContour, _parameter)
                _propertyNode = mMyStore.GetProperty(sDesignContour)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DesignContour() As ContourParameter
        Get
            Return DesignContourProperty.GetContourParameter()
        End Get
        Set(ByVal Value As ContourParameter)
            DesignContourProperty.SetParameter(Value)
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
        ' Add PerformanceResults to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If Not (mMyStore Is Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "PerformanceResults not added to Data Store")
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
    ' Clear all large ArrayList and DataTable results data from the DataStore
    '
    Public Sub ClearResults()
        ' Clear any stored contours
        Dim contourGrid As ContourGrid = Me.DesignContour.Value
        If Not (contourGrid Is Nothing) Then
            contourGrid.ClearContours()
            contourGrid.ClearContourPoints()
            contourGrid.ClearContourCells()
        End If
    End Sub

#End Region

End Class
