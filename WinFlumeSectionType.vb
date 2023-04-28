
'*************************************************************************************************************
' Class WinFlumeSectionType - extension of the Flume.SectionType class to allow for additional cross-sections
'*************************************************************************************************************
Public Class WinFlumeSectionType
    Inherits Flume.SectionType

#Region " Constants and Enums "

    '*********************************************************************************************************
    ' Enum MatchConstraint - constraints to apply when Control Section is Matched to Approach Channel
    '
    ' Note - these constraints can be OR'd together to specify more than one apply
    '*********************************************************************************************************
    Public Enum MatchConstraint
        None = 0
        InnerSillHeightMatchesProfileSillHeight = 1
        SectionHeightMatchesProfileSillHeight = 2
        OuterHeightProfileSillMinusInnerSill = 4
        OuterShapeMatchesApproachChannel = 8
        InnerSideSlopeMatchesApproach = 16
        ShapeMatchesApproachChannel = 32
    End Enum

    '*********************************************************************************************************
    ' Enum MethodOfContraction - methods of contraction available when evaluating alternative designs
    '
    ' Note - these methods can be OR'd together to specify more than one are available
    '*********************************************************************************************************
    Public Enum MethodOfContraction
        None = 0
        RaiseLowerSillHeight = 1
        RaiseLowerEntireSection = 2
        RaiseLowerInnerSection = 4
        VarySideContraction = 8
    End Enum

#End Region

#Region " Properties "

    Public Property ApproachShape As Integer = 0
    Public Property ControlShape As Integer = 0
    Public Property TailwaterShape As Integer = 0

    Public Property MatchConstraints As Integer = MatchConstraint.None          ' OR'd values

    Public Property MethodsOfContraction As Integer = MethodOfContraction.None  ' OR'd values

#End Region

#Region " Constructor(s) "

    ' New
    Public Sub New(ByVal Approach As Integer, ByVal Control As Integer, ByVal Tailwater As Integer,
                   ByVal MatchConstraints As Integer, ContractionMethods As Integer)
        ApproachShape = Approach
        ControlShape = Control
        TailwaterShape = Tailwater

        Me.MatchConstraints = MatchConstraints
        Me.MethodsOfContraction = ContractionMethods
    End Sub

    ' From Flume.Section type
    Public Sub New(ByVal SectionType As Flume.SectionType)
        LoadFlumeSectionType(SectionType)
    End Sub

    ' Copy constructor
    Public Sub New(ByVal SectionType As WinFlumeSectionType)
        LoadFlumeSectionType(SectionType)
        LoadWinFlumeSectionType(SectionType)
    End Sub

#End Region

#Region " Methods "

    ' Load Flume.SectionType values
    Public Sub LoadFlumeSectionType(ByVal SectionType As Flume.SectionType)
        With SectionType
            Me.D1 = .D1
            Me.D2 = .D2
            Me.DiameterFocalD = .DiameterFocalD
            Me.OuterBottomWidth = .OuterBottomWidth
            Me.Shape = .Shape
            Me.Z1 = .Z1
            Me.Z2 = .Z2
            Me.Z3 = .Z3

            Select Case (SectionType.Shape)
                Case Flume.shCircle, Flume.shParabola, Flume.shSillInCircle,
                     Flume.shSillInParabola, Flume.shSillInUShaped, Flume.shUShaped
                    Me.BottomWidth = .DiameterFocalD
                Case Else
                    Me.BottomWidth = .BottomWidth
            End Select
        End With
    End Sub

    ' Load WinFlumeSectionType values
    Public Sub LoadWinFlumeSectionType(ByVal SectionType As WinFlumeSectionType)
        With SectionType
            Me.ApproachShape = .ApproachShape
            Me.ControlShape = .ControlShape
            Me.TailwaterShape = .TailwaterShape
            Me.MatchConstraints = .MatchConstraints
            Me.MethodsOfContraction = .MethodsOfContraction
        End With
    End Sub

    Public Shared Sub LoadWinFlumeSectionType(ByVal SectionType As WinFlumeSectionType,
           ByVal Approach As Integer, ByVal Control As Integer, ByVal Tailwater As Integer)
        With SectionType
            .ApproachShape = Approach
            .ControlShape = Control
            .TailwaterShape = Tailwater

            For Each winFlumeSection In WinFlumeForm.ApproachControlMatchTypes
                If ((winFlumeSection.ApproachShape = Approach) _
                And (winFlumeSection.ControlShape = Control)) Then
                    .MatchConstraints = winFlumeSection.MatchConstraints
                    .MethodsOfContraction = winFlumeSection.MethodsOfContraction
                    Exit For
                End If
            Next
        End With

    End Sub

#End Region

End Class
