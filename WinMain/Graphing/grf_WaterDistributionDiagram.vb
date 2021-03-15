
'**********************************************************************************************
' grf_WaterDistributionDiagram provides graphics support for Water Distribution Diagrams.
'
' The graph is drawn as a Bitmap.
'
Imports DataStore
Imports GraphingUI

Public Class grf_WaterDistributionDiagram
    Inherits grf_XYGraph

#Region " Contructor(s) "

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal dataSet As DataSet)
        MyBase.New(dataSet)
    End Sub

#End Region

End Class
