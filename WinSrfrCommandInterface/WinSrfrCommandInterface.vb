
'**********************************************************************************************
' Class WinSrfrCommandInterface - Remote command interface for WinSRFR
'
' Uses .NET Remoting to communicate with Client
'
Imports System

Public Class WinSrfrCommandInterface
    Inherits MarshalByRefObject
    '
    ' Override to prevent setup of connection timeouts
    '
    Public Overrides Function InitializeLifetimeService() As Object
        Return Nothing
    End Function
    '
    ' WinSRFR Command
    '
    Public Function Command(ByVal winSrfrCommand As String) As Integer
        Dim result As Integer
        RaiseEvent RemoteCommand(winSrfrCommand, result)
        Return result
    End Function

    Public Event RemoteCommand(ByVal command As String, ByRef result As Integer)
    '
    ' WinSRFR Queries
    '
    Public Function Query(ByVal winSrfrQuery As String, ByRef reply As String) As Integer
        Dim result As Integer
        RaiseEvent RemoteStringQuery(winSrfrQuery, reply, result)
        Return result
    End Function

    Public Function Query(ByVal winSrfrQuery As String, ByRef reply As Integer) As Integer
        Dim result As Integer
        RaiseEvent RemoteIntegerQuery(winSrfrQuery, reply, result)
        Return result
    End Function

    Public Function Query(ByVal winSrfrQuery As String, ByRef reply As Single) As Integer
        Dim result As Integer
        RaiseEvent RemoteSingleQuery(winSrfrQuery, reply, result)
        Return result
    End Function

    Public Function Query(ByVal winSrfrQuery As String, ByRef reply As Double) As Integer
        Dim result As Integer
        RaiseEvent RemoteDoubleQuery(winSrfrQuery, reply, result)
        Return result
    End Function

    Public Event RemoteStringQuery(ByVal query As String, ByRef reply As String, ByRef result As Integer)
    Public Event RemoteIntegerQuery(ByVal query As String, ByRef reply As Integer, ByRef result As Integer)
    Public Event RemoteSingleQuery(ByVal query As String, ByRef reply As Single, ByRef result As Integer)
    Public Event RemoteDoubleQuery(ByVal query As String, ByRef reply As Double, ByRef result As Integer)

End Class
