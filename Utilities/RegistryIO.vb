
'*************************************************************************************************************
' Module RegistryIO - Windows Registry accessors
'
' Get accessors:    1) attempt to read values from the Company/Product key first
'                   2) if that fails, it tries the VB.../Product key
'*************************************************************************************************************
Imports Microsoft.Win32     ' For Registry Access

Module RegistryIO
    '
    ' Registry keys from previous WinFlume
    '
    Friend Const sUsername As String = "Username"
    Friend Const sLocateTabs As String = "LocateTabs"
    Friend Const sLocateSubtabs As String = "LocateSubtabs"
    Friend Const sShowMaxWSP As String = "ShowMaxWSP"
    Friend Const sShowMinWSP As String = "ShowMinWSP"
    Friend Const sRatingGraphSyncAxes As String = "RatingGraphSyncAxes"
    Friend Const sRatingParametersToShow As String = "RatingParametersToShow"
    Friend Const sMeasuredParametersToShow As String = "MeasuredParametersToShow"
    Friend Const sRatingGraphItem1 As String = "RatingGraphItem1"
    Friend Const sRatingGraphItem2 As String = "RatingGraphItem2"
    Friend Const sRatingGraphItem3 As String = "RatingGraphItem3"
    '
    ' Registry keys added for this version
    '
    Friend Const sHorzViewSize As String = "HorzViewSize"
    Friend Const sVertViewSize As String = "VertViewSize"
    Friend Const sSideBarShow As String = "SideBarShow"

    '*********************************************************************************************************
    ' Function CurProductSubkey()   - get registry key for current Company/Product      (i.e. USDA/WinFlume)
    ' Function OldProductSubkey()   -  "      "     "   "  old        "       "         (i.e. VB../WinFlume)
    ' Function RegistryObject()     - get registry entry as an Object
    '*********************************************************************************************************
    Friend Function CurProductSubkey() As RegistryKey
        Try
            ' Open the Current User / Software keys
            Dim currentUserKey As RegistryKey = Registry.CurrentUser
            Dim softwareKey As RegistryKey = currentUserKey.OpenSubKey("Software", True)

            ' Open the Company / Product keys
            Dim companyKey As RegistryKey = softwareKey.CreateSubKey(Application.CompanyName)
            CurProductSubkey = companyKey.CreateSubKey(Application.ProductName)

        Catch ex As Exception
            Debug.Assert(False, ex.ToString)
            CurProductSubkey = Nothing
        End Try
    End Function

    Friend Function OldProductSubkey() As RegistryKey
        Try
            ' Open the Current User / Software keys
            Dim currentUserKey As RegistryKey = Registry.CurrentUser
            Dim softwareKey As RegistryKey = currentUserKey.OpenSubKey("Software", True)

            ' Open the VB... / Product keys
            Dim vbKey As RegistryKey = softwareKey.CreateSubKey("VB and VBA Program Settings")
            Dim productKey As RegistryKey = vbKey.CreateSubKey(Application.ProductName)
            OldProductSubkey = productKey.CreateSubKey("Startup")

        Catch ex As Exception
            Debug.Assert(False, ex.ToString)
            OldProductSubkey = Nothing
        End Try
    End Function

    Friend Function RegistryObject(ByVal ObjectKey As String) As Object
        RegistryObject = Nothing
        Try
            ' Look in current Company/Product registry folder first
            Dim productKey As RegistryKey = CurProductSubkey()
            If (productKey IsNot Nothing) Then
                RegistryObject = productKey.GetValue(ObjectKey, Nothing)
            End If

            ' If registry entry was not found, look in 'VB...' folder
            If (RegistryObject Is Nothing) Then
                productKey = OldProductSubkey()
                If (productKey IsNot Nothing) Then
                    RegistryObject = productKey.GetValue(ObjectKey, Nothing)
                End If
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
            RegistryObject = Nothing
        End Try
    End Function

    '*********************************************************************************************************
    ' Property RegistryBoolean()    - get/set boolean to/from registry
    ' Property RegistryInteger()    -  "   "  integer  "   "      "
    ' Property RegistryString()     -  "   "  string   "   "      "
    '*********************************************************************************************************
    Friend Property RegistryBoolean(ByVal BooleanKey As String) As Boolean
        Get
            RegistryBoolean = False
            Try
                ' Get registry value as an Object
                Dim obj As Object = RegistryObject(BooleanKey)
                If (obj IsNot Nothing) Then
                    If (obj.GetType Is GetType(String)) Then
                        Dim str As String = CStr(obj)
                        ' Parse registry value to a boolean
                        If (str.ToLower.Trim = "true") Then
                            RegistryBoolean = True
                        End If
                    End If
                End If

            Catch ex As Exception
                Debug.Assert(False, ex.ToString)
                RegistryBoolean = False
            End Try
        End Get
        Set(ByVal value As Boolean)
            Try
                ' Save boolean as registry string
                Dim productKey As RegistryKey = CurProductSubkey()
                If (productKey IsNot Nothing) Then
                    Dim str As String = value.ToString
                    productKey.SetValue(BooleanKey, str)
                End If

            Catch ex As Exception
                Debug.Assert(False, ex.ToString)
            End Try
        End Set
    End Property

    Friend Property RegistryInteger(ByVal IntegerKey As String) As Integer
        Get
            RegistryInteger = 0
            Try
                ' Get registry value as an Object
                Dim obj As Object = RegistryObject(IntegerKey)
                If (obj IsNot Nothing) Then
                    If (obj.GetType Is GetType(String)) Then
                        Dim str As String = CStr(obj)
                        ' Parse registry value to an integer
                        If (Integer.TryParse(str, Nothing)) Then
                            RegistryInteger = Integer.Parse(str)
                        End If
                    End If
                End If

            Catch ex As Exception
                Debug.Assert(False, ex.ToString)
                RegistryInteger = 0
            End Try
        End Get
        Set(ByVal value As Integer)
            Try
                ' Save integer as registry string
                Dim productKey As RegistryKey = CurProductSubkey()
                If (productKey IsNot Nothing) Then
                    Dim str As String = value.ToString
                    productKey.SetValue(IntegerKey, str)
                End If

            Catch ex As Exception
                Debug.Assert(False, ex.ToString)
            End Try
        End Set
    End Property

    Friend Property RegistryString(ByVal StringKey As String) As String
        Get
            RegistryString = ""
            Try
                ' Get registry value as an Object
                Dim obj As Object = RegistryObject(StringKey)
                If (obj IsNot Nothing) Then
                    If (obj.GetType Is GetType(String)) Then
                        RegistryString = CStr(obj)
                    End If
                End If

            Catch ex As Exception
                Debug.Assert(False, ex.Message)
                RegistryString = ""
            End Try
        End Get
        Set(ByVal value As String)
            Try
                ' Save integer as registry string
                Dim productKey As RegistryKey = CurProductSubkey()
                If (productKey IsNot Nothing) Then
                    productKey.SetValue(StringKey, value)
                End If

            Catch ex As Exception
                Debug.Assert(False, ex.Message)
            End Try
        End Set
    End Property

End Module
