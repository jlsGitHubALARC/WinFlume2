
'*************************************************************************************************************
' SrfrContourParameter  - extends WinLib's ContourParameter to add support for SRFR Simulation Results
'*************************************************************************************************************
Imports System.Runtime.Serialization

Imports DataStore

<Serializable()>
Public Class SrfrContourParameter
    Inherits ContourParameter

#Region " SrfrContourPoint "

    <Serializable()>
    Public Class SrfrContourPoint
        Inherits ContourPoint
        Implements ISerializable

#Region " Member Data "

        Public SrfrResults As Srfr.Results      ' Results from SRFR Simulation

#End Region

#Region " Constructor(s) "
        '
        ' New SrfrContourPoint
        '
        Public Sub New()
            MyBase.New()
        End Sub
        '
        ' Clone (i.e. structure & data) SrfrContourPoint
        '
        Public Sub New(ByVal contourPoint As SrfrContourPoint, ByVal includeZ As Boolean)
            MyBase.New(contourPoint, includeZ)
            If (contourPoint.SrfrResults IsNot Nothing) Then
                Me.SrfrResults = contourPoint.SrfrResults.Clone
            End If
        End Sub

        Public Sub New(ByVal contourPoint As ContourPoint, ByVal includeZ As Boolean)
            MyBase.New(contourPoint, includeZ)
        End Sub

#End Region

#Region " Serialization "
        '
        ' Serialization (i.e. Write to file)
        '
        Public Overrides Sub GetObjectData(ByVal _info As SerializationInfo,
                                           ByVal _context As StreamingContext) _
        Implements ISerializable.GetObjectData
            MyBase.GetObjectData(_info, _context)

            ' Attempt to save the properties within this parameter
            On Error GoTo ErrorHandler

            With _info
                .AddValue("SrfrResults", Me.SrfrResults, GetType(Srfr.Results))
            End With

            Exit Sub

ErrorHandler:
            SerializationError(Me, Err)
            Resume Next

        End Sub
        '
        ' De-serialization (i.e. Read from file)
        '
        Public Sub New(ByVal _info As SerializationInfo,
                       ByVal _context As StreamingContext)
            MyBase.New(_info, _context)

            ' Attempt to read property values from De-serialization stream
            On Error GoTo ErrorHandler

            With _info
                Me.SrfrResults = CType(.GetValue("SrfrResults", GetType(Srfr.Results)), Srfr.Results)
            End With

            Exit Sub

ErrorHandler:
            Resume Next

        End Sub

#End Region

    End Class

#End Region

End Class
