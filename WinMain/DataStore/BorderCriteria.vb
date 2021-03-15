
'*************************************************************************************************************
' Border Criteria properties
'
' Desc: This class contains Design and Operations execution criteria for Basins & Furrows as well as Borders.
'
' BorderCriteria was originally designed when contours were produced only for Borders.  Contours are now
' produced for Basins & Furrows as well so this class is also used for them.
'
' The use of the word 'Border' in names, etc. is continued to provide backward compatibility to previous
' versions of WinSRFR.
'*************************************************************************************************************
Imports DataStore

Public Class BorderCriteria

#Region " Identification "
    '
    ' mMyID - unique object ID for DataStore
    '
    Private mMyID As String = "Border Criteria"
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

#Region " Application & Options "
    '
    ' Border Application
    '
    Public Const sBorderApplication As String = "Border Application"

    Public ReadOnly Property BorderApplicationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sBorderApplication)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(0)

                mMyStore.AddProperty(sBorderApplication, _parameter)
                _propertyNode = mMyStore.GetProperty(sBorderApplication)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property BorderApplication() As IntegerParameter
        Get
            Return BorderApplicationProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            BorderApplicationProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Design Option
    '
    Public Const sDesignOption As String = "Border Design Option"

    Public ReadOnly Property DesignOptionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDesignOption)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultDesignOption)
                mMyStore.AddProperty(sDesignOption, _parameter)
                _propertyNode = mMyStore.GetProperty(sDesignOption)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DesignOption() As IntegerParameter
        Get
            Return DesignOptionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            DesignOptionProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Operations Option
    '
    Public Const sOperationsOption As String = "Operations Option"

    Public ReadOnly Property OperationsOptionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sOperationsOption)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultOperationsOption)
                mMyStore.AddProperty(sOperationsOption, _integer)
                _propertyNode = mMyStore.GetProperty(sOperationsOption)
            Else
                If Not (mUnit.CrossSection = CrossSections.Furrow) Then ' Basin or Border
                    Dim _param As Parameter = _propertyNode.GetParameter
                    Dim _integer As IntegerParameter = DirectCast(_param, IntegerParameter)
                    _integer.Value = DefaultOperationsOption
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property OperationsOption() As IntegerParameter
        Get
            Return OperationsOptionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            OperationsOptionProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Infiltrated Depth Criteria
    '
    Public Const sInfiltratedDepthCriteria As String = "Border Depth Criterion"

    Public ReadOnly Property InfiltratedDepthCriterionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInfiltratedDepthCriteria)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultInfiltratedDepthCriterion)
                mMyStore.AddProperty(sInfiltratedDepthCriteria, _parameter)
                _propertyNode = mMyStore.GetProperty(sInfiltratedDepthCriteria)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property InfiltratedDepthCriterion() As IntegerParameter
        Get
            Return InfiltratedDepthCriterionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            InfiltratedDepthCriterionProperty.SetParameter(Value)
        End Set
    End Property

    ' Return the text selections for Infiltrated Depth Criteria
    Private mInfiltratedDepthCriteriaIndex As Integer = -1
    Public Function GetFirstInfiltratedDepthCriteriaSelection() As String
        mInfiltratedDepthCriteriaIndex = -1
        Return GetNextInfiltratedDepthCriteriaSelection()
    End Function

    Public Function GetNextInfiltratedDepthCriteriaSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mInfiltratedDepthCriteriaIndex += 1
        If (mInfiltratedDepthCriteriaIndex < InfiltratedDepthCriteria.HighLimit) Then
            If ((InfiltratedDepthCriteriaSelections(mInfiltratedDepthCriteriaIndex).Flags And _flags) = 0) Then
                Return InfiltratedDepthCriteriaSelections(mInfiltratedDepthCriteriaIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function

#End Region

#Region " Tuning Factors "
    '
    ' Tuning factors used by design & operations calculations
    '
    Public Const sSigmaY As String = "Sigma Y"

    Public ReadOnly Property SigmaYProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSigmaY)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _doubleParam As DoubleParameter = New DoubleParameter(DefaultSigmaY, Units.None)
                _doubleParam.MinValue = MinSigmaY
                _doubleParam.MaxValue = MaxSigmaY
                mMyStore.AddProperty(sSigmaY, _doubleParam)
                _propertyNode = mMyStore.GetProperty(sSigmaY)
            Else
                Dim _param As Parameter = mMyStore.GetParameter(sSigmaY)
                Dim _doubleParam As DoubleParameter = DirectCast(_param, DoubleParameter)
                _doubleParam.MinValue = MinSigmaY
                _doubleParam.MaxValue = MaxSigmaY
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SigmaY() As DoubleParameter
        Get
            Return SigmaYProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SigmaYProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPhi0Furrows As String = "Phi 0 Furrows"

    Public ReadOnly Property Phi0FurrowsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhi0Furrows)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhi0Furrows, Units.None)
                mMyStore.AddProperty(sPhi0Furrows, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhi0Furrows)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Phi0Furrows() As DoubleParameter
        Get
            Return Phi0FurrowsProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Phi0FurrowsProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPhi1Furrows As String = "Phi 1 Furrows"

    Public ReadOnly Property Phi1FurrowsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhi1Furrows)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhi1Furrows, Units.None)
                mMyStore.AddProperty(sPhi1Furrows, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhi1Furrows)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Phi1Furrows() As DoubleParameter
        Get
            Return Phi1FurrowsProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Phi1FurrowsProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPhi2Furrows As String = "Phi 2 Furrows"

    Public ReadOnly Property Phi2FurrowsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhi2Furrows)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhi2Furrows, Units.None)
                mMyStore.AddProperty(sPhi2Furrows, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhi2Furrows)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Phi2Furrows() As DoubleParameter
        Get
            Return Phi2FurrowsProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Phi2FurrowsProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPhi3Furrows As String = "Phi 3 Furrows"

    Public ReadOnly Property Phi3FurrowsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhi3Furrows)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhi3Furrows, Units.None)
                mMyStore.AddProperty(sPhi3Furrows, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhi3Furrows)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Phi3Furrows() As DoubleParameter
        Get
            Return Phi3FurrowsProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Phi3FurrowsProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPwrAdvRFurrows As String = "Pwr Adv r Furrows"

    Public ReadOnly Property PwrAdvRFurrowsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPwrAdvRFurrows)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0, Units.None)
                mMyStore.AddProperty(sPwrAdvRFurrows, _parameter)
                _propertyNode = mMyStore.GetProperty(sPwrAdvRFurrows)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property PwrAdvRFurrows() As DoubleParameter
        Get
            Return PwrAdvRFurrowsProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            PwrAdvRFurrowsProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPhi0Borders As String = "Phi 0 Borders"

    Public ReadOnly Property Phi0BordersProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhi0Borders)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhi0Borders, Units.None)
                mMyStore.AddProperty(sPhi0Borders, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhi0Borders)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Phi0Borders() As DoubleParameter
        Get
            Return Phi0BordersProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Phi0BordersProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPhi1Borders As String = "Phi 1 Borders"

    Public ReadOnly Property Phi1BordersProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhi1Borders)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhi1Borders, Units.None)
                mMyStore.AddProperty(sPhi1Borders, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhi1Borders)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Phi1Borders() As DoubleParameter
        Get
            Return Phi1BordersProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Phi1BordersProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPhi2Borders As String = "Phi 2 Borders"

    Public ReadOnly Property Phi2BordersProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhi2Borders)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhi2Borders, Units.None)
                mMyStore.AddProperty(sPhi2Borders, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhi2Borders)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Phi2Borders() As DoubleParameter
        Get
            Return Phi2BordersProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Phi2BordersProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPhi3Borders As String = "Phi 3 Borders"

    Public ReadOnly Property Phi3BordersProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPhi3Borders)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPhi3Borders, Units.None)
                mMyStore.AddProperty(sPhi3Borders, _parameter)
                _propertyNode = mMyStore.GetProperty(sPhi3Borders)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Phi3Borders() As DoubleParameter
        Get
            Return Phi3BordersProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Phi3BordersProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPwrAdvRBorders As String = "Pwr Adv r Borders"

    Public ReadOnly Property PwrAdvRBordersProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPwrAdvRBorders)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0, Units.None)
                mMyStore.AddProperty(sPwrAdvRBorders, _parameter)
                _propertyNode = mMyStore.GetProperty(sPwrAdvRBorders)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property PwrAdvRBorders() As DoubleParameter
        Get
            Return PwrAdvRBordersProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            PwrAdvRBordersProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Contour Point used for Tuning Factor Estimation
    '
    ' Design Contours:
    '   X axis is always length
    '   Y axis is width or flow rate
    '
    ' Operations Contours:
    '   X is cutoff time or cutoff ratio
    '   Y is flow rate or, if furrows, furrows per set
    '
    Public Const sContourLengthPoint As String = "Contour Length Point"

    Public ReadOnly Property ContourLengthPointProperty() As PropertyNode
        Get
            ' Calculate default contour length
            Dim lengthPoint As Double

            ' Get property from the DataStore
            Dim minLength As Double = Me.MinContourLength.Value
            Dim maxLength As Double = Me.MaxContourLength.Value
            Dim midLength As Double = (minLength + maxLength) / 2

            Dim S0 As Double = mUnit.SystemGeometryRef.AverageSlope

            If (S0 <= MaximumLevelSlope) Then ' Level Basin
                lengthPoint = midLength ' Center
            Else ' Sloping Border
                lengthPoint = maxLength ' Right edge
            End If

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sContourLengthPoint)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _doubleParam As DoubleParameter = New DoubleParameter(lengthPoint, Units.Meters)
                _doubleParam.Source = ValueSources.Calculated
                mMyStore.AddProperty(sContourLengthPoint, _doubleParam)
                _propertyNode = mMyStore.GetProperty(sContourLengthPoint)
            Else ' If found; update calculated value
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _doubleParam As DoubleParameter = DirectCast(_param, DoubleParameter)
                If (_doubleParam.Source = ValueSources.Calculated) Then
                    _doubleParam.Value = lengthPoint
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ContourLengthPoint() As DoubleParameter
        Get
            Return ContourLengthPointProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ContourLengthPointProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sContourWidthPoint As String = "Contour Width Point"

    Public ReadOnly Property ContourWidthPointProperty() As PropertyNode
        Get
            ' Get property from the DataStore
            Dim minWidth As Double = Me.MinContourWidth.Value
            Dim maxWidth As Double = Me.MaxContourWidth.Value
            Dim midWidth As Double = (minWidth + maxWidth) / 2

            ' Get property from the DataStore
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sContourWidthPoint)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(midWidth, Units.Meters)
                _parameter.Source = ValueSources.Calculated
                mMyStore.AddProperty(sContourWidthPoint, _parameter)
                _propertyNode = mMyStore.GetProperty(sContourWidthPoint)
            Else ' If found; update calculated value
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _doubleParam As DoubleParameter = DirectCast(_param, DoubleParameter)
                If (_doubleParam.Source = ValueSources.Calculated) Then
                    _doubleParam.Value = midWidth
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ContourWidthPoint() As DoubleParameter
        Get
            Return ContourWidthPointProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ContourWidthPointProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sContourInflowRatePoint As String = "Contour Inflow Rate Point"
    Public ReadOnly Property ContourInflowRatePointProperty() As PropertyNode
        Get
            ' Calculate default contour inflow rate

            Dim minInflow As Double = Me.MinContourInflowRate.Value
            Dim maxInflow As Double = Me.MaxContourInflowRate.Value
            Dim midInflow As Double = (minInflow + maxInflow) / 2

            ' Get property from the DataStore
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sContourInflowRatePoint)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _minContourInflowRate As Double = Me.MinContourInflowRate.Value
                Dim _maxContourInflowRate As Double = Me.MaxContourInflowRate.Value
                Dim _parameter As DoubleParameter = New DoubleParameter(midInflow, Units.Cms)
                _parameter.Source = ValueSources.Calculated
                mMyStore.AddProperty(sContourInflowRatePoint, _parameter)
                _propertyNode = mMyStore.GetProperty(sContourInflowRatePoint)
            Else ' If found; update calculated value
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _doubleParam As DoubleParameter = DirectCast(_param, DoubleParameter)
                If (_doubleParam.Source = ValueSources.Calculated) Then
                    _doubleParam.Value = midInflow
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ContourInflowRatePoint() As DoubleParameter
        Get
            Return ContourInflowRatePointProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ContourInflowRatePointProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sContourFurrowsPerSetPoint As String = "Contour Furrows Per Set Point"
    Public ReadOnly Property ContourFurrowsPerSetPointProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sContourFurrowsPerSetPoint)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _minContourFurrowsPerSet As Double = Me.MinContourFurrowsPerSet.Value
                Dim _maxContourFurrowsPerSet As Double = Me.MaxContourFurrowsPerSet.Value
                Dim _parameter As DoubleParameter = New DoubleParameter((_minContourFurrowsPerSet + _maxContourFurrowsPerSet) / 2.0, Units.None)
                _parameter.Source = ValueSources.Calculated
                mMyStore.AddProperty(sContourFurrowsPerSetPoint, _parameter)
                _propertyNode = mMyStore.GetProperty(sContourFurrowsPerSetPoint)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ContourFurrowsPerSetPoint() As DoubleParameter
        Get
            Return ContourFurrowsPerSetPointProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ContourFurrowsPerSetPointProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sContourCutoffTimePoint As String = "Contour Cutoff Time Point"
    Public ReadOnly Property ContourCutoffTimePointProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sContourCutoffTimePoint)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _minContourCutoffTime As Double = Me.MinContourCutoffTime.Value
                Dim _maxContourCutoffTime As Double = Me.MaxContourCutoffTime.Value
                Dim _parameter As DoubleParameter = New DoubleParameter((_minContourCutoffTime + _maxContourCutoffTime) / 2.0, Units.Seconds)
                _parameter.Source = ValueSources.Calculated
                mMyStore.AddProperty(sContourCutoffTimePoint, _parameter)
                _propertyNode = mMyStore.GetProperty(sContourCutoffTimePoint)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ContourCutoffTimePoint() As DoubleParameter
        Get
            Return ContourCutoffTimePointProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ContourCutoffTimePointProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Min / Max Contour Display Ranges "
    '
    ' User can specify the X & Y ranges for both Design & Operations contours
    '
    ' Design Contours:
    '   X axis is always length
    '   Y axis is width or flow rate
    '
    ' Operations Contours:
    '   X is cutoff time or cutoff ratio
    '   Y is flow rate or, if furrows, furrows per set
    '
    Public Const sMinContourLength As String = "Min Border Field Length"

    Public ReadOnly Property MinContourLengthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinContourLength)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMinContourLength, Units.Meters)
                mMyStore.AddProperty(sMinContourLength, _parameter)
                _propertyNode = mMyStore.GetProperty(sMinContourLength)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MinContourLength() As DoubleParameter
        Get
            Return MinContourLengthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MinContourLengthProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMaxContourLength As String = "Max Border Field Length"

    Public ReadOnly Property MaxContourLengthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMaxContourLength)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMaxContourLength, Units.Meters)
                mMyStore.AddProperty(sMaxContourLength, _parameter)
                _propertyNode = mMyStore.GetProperty(sMaxContourLength)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MaxContourLength() As DoubleParameter
        Get
            Return MaxContourLengthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MaxContourLengthProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMinContourWidth As String = "Min Border Field Width"

    Public ReadOnly Property MinContourWidthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinContourWidth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMinContourWidth, Units.Meters)
                mMyStore.AddProperty(sMinContourWidth, _parameter)
                _propertyNode = mMyStore.GetProperty(sMinContourWidth)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MinContourWidth() As DoubleParameter
        Get
            Return MinContourWidthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MinContourWidthProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMaxContourWidth As String = "Max Border Field Width"

    Public ReadOnly Property MaxContourWidthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMaxContourWidth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMaxContourWidth, Units.Meters)
                mMyStore.AddProperty(sMaxContourWidth, _parameter)
                _propertyNode = mMyStore.GetProperty(sMaxContourWidth)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MaxContourWidth() As DoubleParameter
        Get
            Return MaxContourWidthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MaxContourWidthProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMinContourInflowRate As String = "Min Border Inflow Rate"

    Public ReadOnly Property MinContourInflowRateProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinContourInflowRate)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMinContourInflowRate, Units.Lps)
                mMyStore.AddProperty(sMinContourInflowRate, _parameter)
                _propertyNode = mMyStore.GetProperty(sMinContourInflowRate)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MinContourInflowRate() As DoubleParameter
        Get
            Return MinContourInflowRateProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MinContourInflowRateProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMaxContourInflowRate As String = "Max Border Inflow Rate"

    Public ReadOnly Property MaxContourInflowRateProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMaxContourInflowRate)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMaxContourInflowRate, Units.Lps)
                mMyStore.AddProperty(sMaxContourInflowRate, _parameter)
                _propertyNode = mMyStore.GetProperty(sMaxContourInflowRate)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MaxContourInflowRate() As DoubleParameter
        Get
            Return MaxContourInflowRateProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MaxContourInflowRateProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMinContourFurrowsPerSet As String = "Min Furrows Per Set"

    Public ReadOnly Property MinContourFurrowsPerSetProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinContourFurrowsPerSet)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMinContourFurrowsPerSet, Units.None)
                mMyStore.AddProperty(sMinContourFurrowsPerSet, _parameter)
                _propertyNode = mMyStore.GetProperty(sMinContourFurrowsPerSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MinContourFurrowsPerSet() As DoubleParameter
        Get
            Return MinContourFurrowsPerSetProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MinContourFurrowsPerSetProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMaxContourFurrowsPerSet As String = "Max Furrows Per Set"

    Public ReadOnly Property MaxContourFurrowsPerSetProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMaxContourFurrowsPerSet)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMaxContourFurrowsPerSet, Units.None)
                mMyStore.AddProperty(sMaxContourFurrowsPerSet, _parameter)
                _propertyNode = mMyStore.GetProperty(sMaxContourFurrowsPerSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MaxContourFurrowsPerSet() As DoubleParameter
        Get
            Return MaxContourFurrowsPerSetProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MaxContourFurrowsPerSetProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMinContourCutoffTime As String = "Min Border Cutoff Time"

    Public ReadOnly Property MinContourCutoffTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinContourCutoffTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMinContourCutoffTime, Units.Hours)
                mMyStore.AddProperty(sMinContourCutoffTime, _parameter)
                _propertyNode = mMyStore.GetProperty(sMinContourCutoffTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MinContourCutoffTime() As DoubleParameter
        Get
            Return MinContourCutoffTimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MinContourCutoffTimeProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMaxContourCutoffTime As String = "Max Border Cutoff Time"

    Public ReadOnly Property MaxContourCutoffTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMaxContourCutoffTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMaxContourCutoffTime, Units.Hours)
                mMyStore.AddProperty(sMaxContourCutoffTime, _parameter)
                _propertyNode = mMyStore.GetProperty(sMaxContourCutoffTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MaxContourCutoffTime() As DoubleParameter
        Get
            Return MaxContourCutoffTimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MaxContourCutoffTimeProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMinContourCutoffLocationRatio As String = "Min Border Cutoff Location Ratio"

    Public ReadOnly Property MinContourCutoffLocationRatioProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinContourCutoffLocationRatio)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _param As DoubleParameter = New DoubleParameter(DefaultMinContourCutoffLocationRatio, "x L")
                mMyStore.AddProperty(sMinContourCutoffLocationRatio, _param)
                _propertyNode = mMyStore.GetProperty(sMinContourCutoffLocationRatio)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.GetType Is GetType(DoubleParameter)) Then
                    Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                    _double.TextUnits = "x L"
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MinContourCutoffLocationRatio() As DoubleParameter
        Get
            Return MinContourCutoffLocationRatioProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MinContourCutoffLocationRatioProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMaxContourCutoffLocationRatio As String = "Max Border Cutoff Location Ratio"

    Public ReadOnly Property MaxContourCutoffLocationRatioProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMaxContourCutoffLocationRatio)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _param As DoubleParameter = New DoubleParameter(DefaultMaxContourCutoffLocationRatio, "x L")
                mMyStore.AddProperty(sMaxContourCutoffLocationRatio, _param)
                _propertyNode = mMyStore.GetProperty(sMaxContourCutoffLocationRatio)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.GetType Is GetType(DoubleParameter)) Then
                    Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                    _double.TextUnits = "x L"
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MaxContourCutoffLocationRatio() As DoubleParameter
        Get
            Return MaxContourCutoffLocationRatioProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MaxContourCutoffLocationRatioProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Contour Options "
    '
    ' Contour Grid Resolution
    '
    Public Const sGridResolution As String = "Grid Resolution"
    Public ReadOnly Property GridResolutionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGridResolution)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultGridResolution)
                mMyStore.AddProperty(sGridResolution, _parameter)
                _propertyNode = mMyStore.GetProperty(sGridResolution)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property GridResolution() As IntegerParameter
        Get
            Return GridResolutionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            GridResolutionProperty.SetParameter(Value)
        End Set
    End Property

    Private mGridResolutionIndex As Integer = -1
    Public Function GetFirstGridResolutionSelection() As String
        mGridResolutionIndex = -1
        Return GetNextGridResolutionSelection()
    End Function

    Public Function GetNextGridResolutionSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = mUnit.CrossSection
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        mGridResolutionIndex += 1
        If (mGridResolutionIndex < ResolutionSelections.HighLimit) Then
            If ((GridResolutionSelections(mGridResolutionIndex).Flags And _flags) = 0) Then
                Return GridResolutionSelections(mGridResolutionIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function

#End Region

#End Region

#Region " Constructor(s) "
    '
    ' New() - Instantiate a new BorderCriteria object
    '
    ' _myID - Object ID string
    '   Nothing or String.Empty - default ID is used
    '
    ' _unit - Parent Unit reference
    '
    Public Sub New(ByVal _myID As String, ByVal _unit As Unit)
        '
        ' Save ID
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
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Add BorderCriteria to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If Not (mMyStore Is Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "BorderCriteria not added to Data Store")
            End If
        Else
            Debug.Assert(False, "Parent's Data Store is Nothing")
        End If

    End Sub
    '
    ' New() - Instantiate a BorderCriteria object; then connect to DataStore
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

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        BorderCriteria
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
        ' Regenerate the DataStore event as a Border Criteria event
        RaiseEvent PropertyDataChanged(Reasons.BorderCriteria)
    End Sub

#End Region

End Class
