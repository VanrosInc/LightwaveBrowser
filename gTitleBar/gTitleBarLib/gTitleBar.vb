Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

''' <summary>
''' gTitlebar is a control that can be put on a frameless form to act like a normal title bar
''' but also makes it easy to add controls to the bar  
''' </summary>
''' <remarks>Version 1.0.0</remarks>
Public Class gTitleBar

#Region "New"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

    End Sub
#End Region

#Region "Custom Events"

    Public Event CloseButtonClicked()
    Public Event MinimizeButtonClicked()
    Public Event MaximizeButtonClicked()

#End Region

#Region "Resize-Move form"

    Private _resizeDir As ResizeDirection = ResizeDirection.None

    Public Enum ResizeDirection
        None = 0
        Left = 1
        TopLeft = 2
        Top = 3
        TopRight = 4
        Right = 5
        BottomRight = 6
        Bottom = 7
        BottomLeft = 8
    End Enum

    <Browsable(False)> _
    Public Property resizeDir() As ResizeDirection
        Get
            Return _resizeDir
        End Get
        Set(ByVal value As ResizeDirection)
            _resizeDir = value

            'Change cursor
            Select Case value
                Case ResizeDirection.Left
                    Cursor = Cursors.SizeWE

                Case ResizeDirection.Right
                    Cursor = Cursors.SizeWE

                Case ResizeDirection.Top
                    Cursor = Cursors.SizeNS

                Case ResizeDirection.Bottom
                    Cursor = Cursors.SizeNS

                Case ResizeDirection.BottomLeft
                    Cursor = Cursors.SizeNESW

                Case ResizeDirection.TopRight
                    Cursor = Cursors.SizeNESW

                Case ResizeDirection.BottomRight
                    Cursor = Cursors.SizeNWSE

                Case ResizeDirection.TopLeft
                    Cursor = Cursors.SizeNWSE

                Case ResizeDirection.None
                    Cursor = Cursors.Default

                Case Else
                    Cursor = Cursors.Default
            End Select
        End Set
    End Property

    <DllImport("user32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14

    Private Sub MoveForm()
        ReleaseCapture()
        SendMessage(Parent.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        Invalidate()
    End Sub

    Private Sub ResizeForm(ByVal direction As ResizeDirection)
        Dim dir As Integer = -1
        Select Case direction
            Case ResizeDirection.Left
                dir = HTLEFT
            Case ResizeDirection.TopLeft
                dir = HTTOPLEFT
            Case ResizeDirection.Top
                dir = HTTOP
            Case ResizeDirection.TopRight
                dir = HTTOPRIGHT
            Case ResizeDirection.Right
                dir = HTRIGHT
            Case ResizeDirection.BottomRight
                dir = HTBOTTOMRIGHT
            Case ResizeDirection.Bottom
                dir = HTBOTTOM
            Case ResizeDirection.BottomLeft
                dir = HTBOTTOMLEFT
            Case ResizeDirection.None
        End Select

        If dir <> -1 Then
            ReleaseCapture()
            SendMessage(ParentForm.Handle, WM_NCLBUTTONDOWN, dir, 0)
        End If
    End Sub
#End Region

#Region "Properties"

    Private _TitleText As String = "TitleBar"
    ''' <summary>
    ''' Text to display on the Tile Bar
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Text to display on the Tile Bar")> _
    <DefaultValue("TitleBar")> _
    Public Property TitleText() As String
        Get
            Return _TitleText
        End Get
        Set(ByVal value As String)
            _TitleText = value
            Refresh()
        End Set
    End Property

    Enum eControlBoxAffects
        ParentForm
        EventTrigger
    End Enum
    Private _ControlBoxAffects As eControlBoxAffects = eControlBoxAffects.ParentForm
    ''' <summary>
    ''' Get or Set if clicking the Control Box Buttons affects the Form or triggers the custom Events
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Get or Set if clicking the Control Box Buttons affects the Form or triggers the custom Events")> _
    <DefaultValue(eControlBoxAffects.ParentForm)> _
    Public Property ControlBoxAffects() As eControlBoxAffects
        Get
            Return _ControlBoxAffects
        End Get
        Set(ByVal value As eControlBoxAffects)
            _ControlBoxAffects = value
        End Set
    End Property

    Private _ShowCloseBox As Boolean = True
    ''' <summary>
    ''' Get or Set if the Close button is visible
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Get or Set if the Close button is visible")> _
    <DefaultValue(True)> _
    Public Property ShowCloseBox() As Boolean
        Get
            Return _ShowCloseBox
        End Get
        Set(ByVal value As Boolean)
            _ShowCloseBox = value
            CloseWindowButton.Visible = value
            Invalidate()
        End Set
    End Property

    Private _ShowMinimizeBox As Boolean = True
    ''' <summary>
    ''' Get or Set if the Minimize button is visible
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Get or Set if the Minimize button is visible")> _
    <DefaultValue(True)> _
   Public Property ShowMinimizeBox() As Boolean
        Get
            Return _ShowMinimizeBox
        End Get
        Set(ByVal value As Boolean)
            _ShowMinimizeBox = value
            MinimizeWindowButton.Visible = value
            Invalidate()
        End Set

    End Property

    Private _ShowMaximizeBox As Boolean = True
    ''' <summary>
    ''' Get or Set if the Maximize button is visible
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Get or Set if the Maximize button is visible")> _
    <DefaultValue(True)> _
   Public Property ShowMaximizeBox() As Boolean
        Get
            Return _ShowMaximizeBox
        End Get
        Set(ByVal value As Boolean)
            _ShowMaximizeBox = value
            MaximizeWindowButton.Visible = value
            Invalidate()
        End Set
    End Property

    Private _AllowMove As Boolean = True
    ''' <summary>
    ''' Get or Set if the gTitleBar allows moving with the mouse.
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Get or Set if the gTitleBar allows moving with the mouse.")> _
    <DefaultValue(True)> _
    Public Property AllowMove() As Boolean
        Get
            Return _AllowMove
        End Get
        Set(ByVal value As Boolean)
            _AllowMove = value
        End Set
    End Property

    Private _FrameShow As Boolean = True
    ''' <summary>
    ''' Get or Set if the frame is visible around the parent
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Get or Set if the frame is visible around the parent")> _
    <DefaultValue(True)> _
   Public Property FrameShow() As Boolean
        Get
            Return _FrameShow
        End Get
        Set(ByVal value As Boolean)
            _FrameShow = value
            Invalidate()
        End Set
    End Property

    Private _FrameWidth As Integer = 5
    ''' <summary>
    ''' Get or Set the width of the frame
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Get or Set the width of the frame")> _
    <DefaultValue(5)> _
    Public Property FrameWidth() As Integer
        Get
            Return _FrameWidth
        End Get
        Set(ByVal value As Integer)
            _FrameWidth = value
            Invalidate()
        End Set
    End Property

    Private _FrameHeightAdj As Integer
    ''' <summary>
    ''' Get or Set a padding value for the bottom of the frame
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Get or Set a padding value for the bottom of the frame")> _
    <DefaultValue(0)> _
    Public Property FrameHeightAdj() As Integer
        Get
            Return _FrameHeightAdj
        End Get
        Set(ByVal value As Integer)
            _FrameHeightAdj = value

            Try
                Parent.Invalidate()

            Catch ex As Exception

            End Try
            Invalidate()

        End Set
    End Property

    Private _titleImage As image
    ''' <summary>
    ''' Get or Set The image to display in the TitleBar
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Get or Set The image to display in the TitleBar")> _
    Public Property TitleImage() As Image
        Get
            Return _titleImage
        End Get
        Set(ByVal Value As Image)
            _titleImage = Value
            Invalidate()
        End Set
    End Property

    Private _titleImageSize As Size = New Size(24, 24)
    ''' <summary>
    ''' Get or Set the size to make the image on the TitleBar
    ''' </summary>
    <Category("gTitleBar")> _
    <Description("Get or Set the size to make the image on the TitleBar")> _
    <DefaultValue("24,24")> _
    Public Property TitleImageSize() As Size
        Get
            Return _titleImageSize
        End Get
        Set(ByVal Value As Size)
            _titleImageSize = Value
            Invalidate()
        End Set
    End Property

    Private _IsFormActive As Integer = 1
    <Browsable(False)> _
    Public Property IsFormActive() As Boolean
        Get
            Return _IsFormActive = 1
        End Get
        Set(ByVal value As Boolean)
            If value Then
                _IsFormActive = 1
            Else
                _IsFormActive = 2
            End If
            Invalidate()
        End Set
    End Property

#End Region

#Region "Invalidate Buttons"

    Private Sub gTitleBar_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles Me.Invalidated
        CloseWindowButton.Invalidate()
        MaximizeWindowButton.Invalidate()
        MinimizeWindowButton.Invalidate()
    End Sub
#End Region

#Region "Mouse Events"

    Private Sub Me_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        ' Check for single click.
        ' Bypass if Double clicked.
        If e.Clicks = 1 Then
            If resizeDir = ResizeDirection.None Then
                If _AllowMove Then
                    If TypeOf Parent Is Form Then
                        If FindForm.WindowState = FormWindowState.Normal Then
                            MoveForm()
                        End If
                    Else
                        MoveForm()
                    End If

                End If
            Else
                If TypeOf Parent Is Form Then
                    ResizeForm(resizeDir)
                End If
            End If
        End If

    End Sub

    Private Sub Me_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If TypeOf Parent Is Form Then

            If e.Location.X < _FrameWidth And e.Location.Y < _FrameWidth Then
                resizeDir = ResizeDirection.TopLeft

                'ElseIf e.Location.X < _FrameWidth And e.Location.Y > Height - _FrameWidth Then
                '    resizeDir = ResizeDirection.BottomLeft

                'ElseIf e.Location.X > Width - _FrameWidth And e.Location.Y > Height - _FrameWidth Then
                '    resizeDir = ResizeDirection.BottomRight

            ElseIf e.Location.X > Width - _FrameWidth And e.Location.Y < _FrameWidth Then
                resizeDir = ResizeDirection.TopRight

            ElseIf e.Location.X < _FrameWidth Then
                resizeDir = ResizeDirection.Left

            ElseIf e.Location.X > Width - _FrameWidth Then
                resizeDir = ResizeDirection.Right

            ElseIf e.Location.Y < _FrameWidth Then
                resizeDir = ResizeDirection.Top

                'ElseIf e.Location.Y > Height - _FrameWidth Then
                '    resizeDir = ResizeDirection.Bottom

            Else
                resizeDir = ResizeDirection.None
            End If
        End If

    End Sub
#End Region

#Region "DoubleClick-Maximize/Restore"

    Private Sub gTitleBar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        If FindForm.WindowState = FormWindowState.Maximized Then
            FindForm.WindowState = FormWindowState.Normal
        Else
            FindForm.WindowState = FormWindowState.Maximized
            FindForm.Invalidate()
            Invalidate()
        End If
    End Sub

#End Region

#Region "Theme Functions"

#Region "Enums"

    ''' <summary>
    '''  "Window" (i.e., non-client) Parts
    ''' </summary>
    Public Enum UxThemeWindowParts As Integer

        ''' <summary>Caption</summary>
        WP_CAPTION = 1
        ''' <summary>Small Caption</summary>
        WP_SMALLCAPTION = 2
        ''' <summary>Minimised Caption</summary>
        WP_MINCAPTION = 3
        ''' <summary>Small minimised Caption</summary>
        WP_SMALLMINCAPTION = 4
        ''' <summary>Maximised Caption</summary>
        WP_MAXCAPTION = 5
        ''' <summary>Small maximised Caption</summary>
        WP_SMALLMAXCAPTION = 6
        ''' <summary>Frame left</summary>
        WP_FRAMELEFT = 7
        ''' <summary>Frame right</summary>
        WP_FRAMERIGHT = 8
        ''' <summary>Frame bottom</summary>
        WP_FRAMEBOTTOM = 9
        ''' <summary>Small frame left</summary>
        WP_SMALLFRAMELEFT = 10
        ''' <summary>Small frame right</summary>
        WP_SMALLFRAMERIGHT = 11
        ''' <summary>Small frame bottom</summary>
        WP_SMALLFRAMEBOTTOM = 12
        ''' <summary>System button</summary>
        WP_SYSBUTTON = 13
        ''' <summary>MDI System button</summary>
        WP_MDISYSBUTTON = 14
        ''' <summary>Min button</summary>
        WP_MINBUTTON = 15
        ''' <summary>MDI Min button</summary>
        WP_MDIMINBUTTON = 16
        ''' <summary>Max button</summary>
        WP_MAXBUTTON = 17
        ''' <summary>Close button</summary>
        WP_CLOSEBUTTON = 18
        ''' <summary>Small close button</summary>
        WP_SMALLCLOSEBUTTON = 19
        ''' <summary>MDI close button</summary>
        WP_MDICLOSEBUTTON = 20
        ''' <summary>Restore button</summary>
        WP_RESTOREBUTTON = 21
        ''' <summary>MDI Restore button</summary>
        WP_MDIRESTOREBUTTON = 22
        ''' <summary>Help button</summary>
        WP_HELPBUTTON = 23
        ''' <summary>MDI Help button</summary>
        WP_MDIHELPBUTTON = 24
        ''' <summary>Horizontal scroll bar</summary>
        WP_HORZSCROLL = 25
        ''' <summary>Horizontal scroll thumb</summary>
        WP_HORZTHUMB = 26
        ''' <summary>Vertical scroll bar</summary>
        WP_VERTSCROLL = 27
        ''' <summary>Vertical scroll thumb</summary>
        WP_VERTTHUMB = 28
        ''' <summary>Dialog</summary>
        WP_DIALOG = 29
        ''' <summary>Caption sizing hittest template</summary>
        WP_CAPTIONSIZINGTEMPLATE = 30
        ''' <summary>Small caption sizing hittest template</summary>
        WP_SMALLCAPTIONSIZINGTEMPLATE = 31
        ''' <summary>Frame left sizing hittest template</summary>
        WP_FRAMELEFTSIZINGTEMPLATE = 32
        ''' <summary>Small frame left sizing hittest template</summary>
        WP_SMALLFRAMELEFTSIZINGTEMPLATE = 33
        ''' <summary>Frame right sizing hittest template</summary>
        WP_FRAMERIGHTSIZINGTEMPLATE = 34
        ''' <summary>Small frame right sizing hittest template</summary>
        WP_SMALLFRAMERIGHTSIZINGTEMPLATE = 35
        ''' <summary>Frame button sizing hittest template</summary>
        WP_FRAMEBOTTOMSIZINGTEMPLATE = 36
        ''' <summary>Small frame bottom sizing hittest template</summary>
        WP_SMALLFRAMEBOTTOMSIZINGTEMPLATE = 37
    End Enum

    ''' <summary>
    ''' System Button states
    ''' </summary>
    Public Enum UxThemeSysButtonStates As Integer
        ''' <summary>Normal</summary>
        SBS_NORMAL = 1
        ''' <summary>Hot</summary>
        SBS_HOT = 2
        ''' <summary>Pushed</summary>
        SBS_PUSHED = 3
        ''' <summary>Disabled</summary>
        SBS_DISABLED = 4
        ''' <summary>Inactive</summary>
        SBS_INACTIVE = 5
    End Enum

    Public Enum DrawTextFlags As UInteger
        DT_TOP = &H0
        DT_LEFT = &H0
        DT_CENTER = &H1
        DT_RIGHT = &H2
        DT_VCENTER = &H4
        DT_BOTTOM = &H8
        DT_WORDBREAK = &H10
        DT_SINGLELINE = &H20
        DT_EXPANDTABS = &H40
        DT_TABSTOP = &H80
        DT_NOCLIP = &H100
        DT_EXTERNALLEADING = &H200
        DT_CALCRECT = &H400
        DT_NOPREFIX = &H800
        DT_INTERNAL = &H1000
        DT_EDITCONTROL = &H2000
        DT_PATH_ELLIPSIS = &H4000
        DT_END_ELLIPSIS = &H8000
        DT_MODIFYSTRING = &H10000
        DT_RTLREADING = &H20000
        DT_WORD_ELLIPSIS = &H40000
        DT_NOFULLWIDTHCHARBREAK = &H80000
        DT_HIDEPREFIX = &H100000
        DT_PREFIXONLY = &H200000
    End Enum
    ' UxTheme DrawText Additional Flag
    Const DTT_GRAYED As Integer = &H1
#End Region

#Region "Structures"

    <StructLayout(LayoutKind.Sequential)> _
           Friend Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer

        Public Sub New(ByVal rect As Rectangle)
            MyClass.New(rect.Left, rect.Top, rect.Right, rect.Bottom)
        End Sub 'New

        Public Sub New(ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
            Me.left = left
            Me.top = top
            Me.right = right
            Me.bottom = bottom

        End Sub 'New

        ' Handy method for converting to a System.Drawing.Rectangle
        Public Function ToRectangle() As Rectangle
            Return New Rectangle(left, top, right - left, bottom - top)
        End Function 'ToRectangle

    End Structure 'RECT
#End Region

    <DllImport("Uxtheme", EntryPoint:="OpenThemeData", CharSet:=CharSet.Unicode)> _
Friend Shared Function openThemeData(ByVal hWnd As IntPtr, ByVal classList As String) As IntPtr
    End Function

    <DllImport("Uxtheme", EntryPoint:="DrawThemeBackground", SetLastError:=True)> _
    Friend Shared Function drawThemeBackground(ByVal hTheme As IntPtr, ByVal hDC As IntPtr, ByVal iPartId As Int32, ByVal iStateId As Int32, ByRef pRect As RECT, ByVal nullRECT As IntPtr) As <MarshalAs(UnmanagedType.Error)> Int32
    End Function

    <DllImport("UxTheme.dll", CallingConvention:=CallingConvention.Cdecl)> _
    Private Shared Function CloseThemeData(ByVal hTheme As IntPtr) As Integer
    End Function

    <DllImport("Uxtheme", EntryPoint:="IsAppThemed")> _
    Friend Shared Function isAppThemed() As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Private Shared Function ConvertThemeToClassic(ByVal themeButtonState As UxThemeSysButtonStates) As ButtonState
        Select Case themeButtonState
            Case UxThemeSysButtonStates.SBS_NORMAL
                Return ButtonState.Normal
            Case UxThemeSysButtonStates.SBS_HOT
                Return ButtonState.Normal
            Case UxThemeSysButtonStates.SBS_PUSHED
                Return ButtonState.Pushed
            Case UxThemeSysButtonStates.SBS_INACTIVE
                Return ButtonState.Inactive
            Case UxThemeSysButtonStates.SBS_DISABLED
                Return ButtonState.Inactive
            Case Else
                Return ButtonState.Normal
        End Select
    End Function

#End Region

#Region "Paint"

    Private intptrWindowTheme As IntPtr
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        'Draw the frame if requested
        If _FrameShow Then
            If isAppThemed() Then
                Dim g As Graphics = Parent.CreateGraphics
                Dim hdcGraphics As IntPtr = g.GetHdc

                intptrWindowTheme = openThemeData(Parent.Handle, "Window")

                'Draw Left Side of the Frame
                drawThemeBackground(intptrWindowTheme, hdcGraphics, _
                    UxThemeWindowParts.WP_FRAMELEFT, _
                    _IsFormActive, _
                    New RECT(New Rectangle(0, 0, _
                    _FrameWidth, Parent.Height - _FrameHeightAdj)), _
                    IntPtr.Zero)

                'Draw Right Side of the Frame
                drawThemeBackground(intptrWindowTheme, hdcGraphics, _
                    UxThemeWindowParts.WP_FRAMERIGHT, _
                    _IsFormActive, _
                    New RECT(New Rectangle(Parent.Width - _FrameWidth, 0, _
                    _FrameWidth, Parent.Height - _FrameHeightAdj)), _
                    IntPtr.Zero)

                'Draw Bottom Side of the Frame
                drawThemeBackground(intptrWindowTheme, hdcGraphics, _
                UxThemeWindowParts.WP_FRAMEBOTTOM, _
                    _IsFormActive, _
                    New RECT(New Rectangle(0, Parent.Height - _FrameWidth - _
                    _FrameHeightAdj, Parent.Width, _FrameWidth)), _
                    IntPtr.Zero)

                g.ReleaseHdc(hdcGraphics)
                CloseThemeData(intptrWindowTheme)
            Else
                'Draw Left Side of the Frame
                ControlPaint.DrawBorder3D(Parent.CreateGraphics, _
                    New Rectangle(0, 0, _FrameWidth, _
                    Parent.Height - _FrameHeightAdj), _
                    Border3DStyle.Raised, _
                    Border3DSide.All)

                'Draw Right Side of the Frame
                ControlPaint.DrawBorder3D(Parent.CreateGraphics, _
                    New Rectangle(Parent.Width - _FrameWidth, 0, _
                    _FrameWidth, Parent.Height - _FrameHeightAdj), _
                    Border3DStyle.Raised, _
                    Border3DSide.All)

                'Draw Bottom Side of the Frame
                ControlPaint.DrawBorder3D(Parent.CreateGraphics, _
                    New Rectangle(0, _
                    Parent.Height - _FrameWidth - _FrameHeightAdj, _
                    Parent.Width, _FrameWidth), _
                    Border3DStyle.Raised, _
                    Border3DSide.All)

            End If
        End If

        'Draw TitleBar
        If isAppThemed() Then

            Dim hdcGraphics As IntPtr = e.Graphics.GetHdc
            intptrWindowTheme = openThemeData(Handle, "Window")

            drawThemeBackground(intptrWindowTheme, hdcGraphics, _
                UxThemeWindowParts.WP_CAPTION, _
                _IsFormActive, _
                New RECT(New Rectangle(0, 0, Width, Height)), _
                 IntPtr.Zero)

            e.Graphics.ReleaseHdc(hdcGraphics)
            CloseThemeData(intptrWindowTheme)
        Else

            Dim rect As Rectangle = DisplayRectangle
            Dim focuscolorDark As Color = SystemColors.ActiveCaption
            Dim focuscolorLight As Color = SystemColors.GradientActiveCaption
            If Not IsFormActive Then
                focuscolorDark = SystemColors.InactiveCaption
                focuscolorLight = SystemColors.GradientInactiveCaption

            End If
            Using br As Brush = New LinearGradientBrush(rect, focuscolorDark, _
                focuscolorLight, LinearGradientMode.Horizontal)
                e.Graphics.FillRectangle(br, rect)

                'Top
                ControlPaint.DrawBorder3D(e.Graphics, _
                    New Rectangle(_FrameWidth - 2, 0, _
                    Width - _FrameWidth, _FrameWidth), _
                    Border3DStyle.Raised, _
                    Border3DSide.All)

                'Top Left Corner
                ControlPaint.DrawBorder3D(e.Graphics, _
                    New Rectangle(0, 0, _FrameWidth, _FrameWidth), _
                    Border3DStyle.Raised, _
                    Border3DSide.Top Or _
                    Border3DSide.Left Or Border3DSide.Middle)

                'Left Side
                ControlPaint.DrawBorder3D(e.Graphics, _
                    New Rectangle(0, _FrameWidth - 2, _FrameWidth, _
                    Height - _FrameWidth + 2), _
                    Border3DStyle.Raised, _
                    Border3DSide.Top Or Border3DSide.Left Or _
                    Border3DSide.Right Or Border3DSide.Middle)

                'Right Side
                ControlPaint.DrawBorder3D(e.Graphics, _
                    New Rectangle(Width - _FrameWidth, 0, _
                    _FrameWidth, Height), _
                    Border3DStyle.Raised, _
                    Border3DSide.Top Or Border3DSide.Left Or _
                    Border3DSide.Right Or Border3DSide.Middle)

            End Using
        End If

        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
        Dim ImagePad As Integer
        If _titleImage IsNot Nothing Then
            ImagePad = _titleImageSize.Width
            e.Graphics.DrawImage(_titleImage, 5, 3, _titleImageSize.Width, _titleImageSize.Height)
        End If

        e.Graphics.DrawString(_TitleText, Font, New SolidBrush(Color.DimGray), ImagePad + 11, 9)
        e.Graphics.DrawString(_TitleText, Font, New SolidBrush(ForeColor), ImagePad + 10, 8)
    End Sub

    Private Sub IsButtonActive(ByRef ButtonState As UxThemeSysButtonStates)
        If Not IsFormActive And ButtonState = UxThemeSysButtonStates.SBS_NORMAL Then
            ButtonState = UxThemeSysButtonStates.SBS_INACTIVE
        ElseIf ButtonState = UxThemeSysButtonStates.SBS_INACTIVE Then
            ButtonState = UxThemeSysButtonStates.SBS_NORMAL
        End If
    End Sub

#End Region

#Region "Close Button"

    Private CloseButtonState As UxThemeSysButtonStates = UxThemeSysButtonStates.SBS_NORMAL

    Private Sub CloseWindowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseWindowButton.Click
        If _ControlBoxAffects = eControlBoxAffects.ParentForm Then
            FindForm.Close()
        Else
            RaiseEvent CloseButtonClicked()
        End If
    End Sub

    Private Sub CloseWindowButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CloseWindowButton.MouseDown
        CloseButtonState = UxThemeSysButtonStates.SBS_PUSHED
        CloseWindowButton.Invalidate()
    End Sub

    Private Sub CloseWindowButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CloseWindowButton.MouseEnter
        CloseButtonState = UxThemeSysButtonStates.SBS_HOT
        CloseWindowButton.Invalidate()
    End Sub

    Private Sub CloseWindowButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CloseWindowButton.MouseLeave
        CloseButtonState = UxThemeSysButtonStates.SBS_NORMAL
        CloseWindowButton.Invalidate()
    End Sub

    Private Sub CloseWindowButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CloseWindowButton.MouseUp

        CloseButtonState = UxThemeSysButtonStates.SBS_NORMAL
        CloseWindowButton.Invalidate()
    End Sub

    Private Sub CloseWindowButton_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles CloseWindowButton.Paint
        IsButtonActive(CloseButtonState)
        If isAppThemed() Then
            intptrWindowTheme = openThemeData(CloseWindowButton.Handle, "Window")

            drawThemeBackground(intptrWindowTheme, e.Graphics.GetHdc, _
            UxThemeWindowParts.WP_CLOSEBUTTON, _
            CloseButtonState, _
            New RECT(New Rectangle(0, 0, _
            CloseWindowButton.Width, CloseWindowButton.Height)), _
            IntPtr.Zero)

            e.Graphics.ReleaseHdc()
            CloseThemeData(intptrWindowTheme)
        Else
            ControlPaint.DrawCaptionButton(e.Graphics, _
                CloseWindowButton.DisplayRectangle, _
                CaptionButton.Close, _
                ConvertThemeToClassic(CloseButtonState))
        End If

    End Sub
#End Region

#Region "Maximize Button"

    Private MaximizeButtonState As UxThemeSysButtonStates = UxThemeSysButtonStates.SBS_NORMAL

    Private Sub MaximizeWindowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaximizeWindowButton.Click
        If _ControlBoxAffects = eControlBoxAffects.ParentForm Then
            If FindForm.WindowState = FormWindowState.Maximized Then
                FindForm.WindowState = FormWindowState.Normal
            Else
                FindForm.WindowState = FormWindowState.Maximized
            End If
        Else
            RaiseEvent MaximizeButtonClicked()
        End If
        FindForm.Invalidate()
        Invalidate()
    End Sub

    Private Sub MaximizeWindowButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MaximizeWindowButton.MouseDown
        MaximizeButtonState = UxThemeSysButtonStates.SBS_PUSHED
        MaximizeWindowButton.Invalidate()

    End Sub

    Private Sub MaximizeWindowButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaximizeWindowButton.MouseEnter
        MaximizeButtonState = UxThemeSysButtonStates.SBS_HOT
        MaximizeWindowButton.Invalidate()

    End Sub

    Private Sub MaximizeWindowButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaximizeWindowButton.MouseLeave
        MaximizeButtonState = UxThemeSysButtonStates.SBS_NORMAL
        MaximizeWindowButton.Invalidate()

    End Sub

    Private Sub MaximizeWindowButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MaximizeWindowButton.MouseUp
        MaximizeButtonState = UxThemeSysButtonStates.SBS_NORMAL
        MaximizeWindowButton.Invalidate()

    End Sub

    Private Sub MaximizeWindowButton_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MaximizeWindowButton.Paint
        intptrWindowTheme = openThemeData(MaximizeWindowButton.Handle, "Window")
        IsButtonActive(MaximizeButtonState)
        If FindForm.WindowState = FormWindowState.Maximized Then
            If isAppThemed() Then
                drawThemeBackground(intptrWindowTheme, e.Graphics.GetHdc, _
                UxThemeWindowParts.WP_RESTOREBUTTON, _
                MaximizeButtonState, _
                New RECT(New Rectangle(0, 0, _
                MaximizeWindowButton.Width, MaximizeWindowButton.Height)), _
                IntPtr.Zero)

                e.Graphics.ReleaseHdc()
                CloseThemeData(intptrWindowTheme)
            Else
                ControlPaint.DrawCaptionButton(e.Graphics, _
                    MaximizeWindowButton.DisplayRectangle, _
                    CaptionButton.Restore, _
                    ConvertThemeToClassic(MaximizeButtonState))
            End If
        Else
            If isAppThemed() Then
                drawThemeBackground(intptrWindowTheme, e.Graphics.GetHdc, _
                UxThemeWindowParts.WP_MAXBUTTON, _
                CInt(IIf(Not IsFormActive And _
                MaximizeButtonState = UxThemeSysButtonStates.SBS_NORMAL, _
                UxThemeSysButtonStates.SBS_INACTIVE, MaximizeButtonState)), _
                New RECT(New Rectangle(0, 0, _
                MaximizeWindowButton.Width, MaximizeWindowButton.Height)), _
                IntPtr.Zero)

                e.Graphics.ReleaseHdc()
                CloseThemeData(intptrWindowTheme)
            Else
                ControlPaint.DrawCaptionButton(e.Graphics, _
                    MaximizeWindowButton.DisplayRectangle, _
                    CaptionButton.Maximize, _
                    ConvertThemeToClassic(MaximizeButtonState))
            End If
        End If


    End Sub
#End Region

#Region "Minimize Button"

    Private MinimizeButtonState As UxThemeSysButtonStates = UxThemeSysButtonStates.SBS_NORMAL

    Private Sub MinimizeWindowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizeWindowButton.Click

        If _ControlBoxAffects = eControlBoxAffects.ParentForm Then
            FindForm.WindowState = FormWindowState.Minimized
        Else
            RaiseEvent MinimizeButtonClicked()
        End If


    End Sub

    Private Sub MinimizeWindowButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MinimizeWindowButton.MouseDown
        MinimizeButtonState = UxThemeSysButtonStates.SBS_PUSHED
        MinimizeWindowButton.Invalidate()

    End Sub

    Private Sub MinimizeWindowButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinimizeWindowButton.MouseEnter
        MinimizeButtonState = UxThemeSysButtonStates.SBS_HOT
        MinimizeWindowButton.Invalidate()

    End Sub

    Private Sub MinimizeWindowButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinimizeWindowButton.MouseLeave
        MinimizeButtonState = UxThemeSysButtonStates.SBS_NORMAL
        MinimizeWindowButton.Invalidate()

    End Sub

    Private Sub MinimizeWindowButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MinimizeWindowButton.MouseUp
        MinimizeButtonState = UxThemeSysButtonStates.SBS_NORMAL
        MinimizeWindowButton.Invalidate()

    End Sub

    Private Sub MinimizeWindowButton_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MinimizeWindowButton.Paint

        IsButtonActive(MinimizeButtonState)

        If isAppThemed() Then

            intptrWindowTheme = openThemeData(MinimizeWindowButton.Handle, "Window")
            drawThemeBackground(intptrWindowTheme, e.Graphics.GetHdc, _
            UxThemeWindowParts.WP_MINBUTTON, _
            MinimizeButtonState, _
            New RECT(New Rectangle(0, 0, _
            MinimizeWindowButton.Width, MinimizeWindowButton.Height)), _
            IntPtr.Zero)

            e.Graphics.ReleaseHdc()
            CloseThemeData(intptrWindowTheme)
            '    MsgBox("is " & MinimizeWindowButton.Left)

        Else
            ControlPaint.DrawCaptionButton(e.Graphics, _
                MinimizeWindowButton.DisplayRectangle, _
                CaptionButton.Minimize, _
                ConvertThemeToClassic(MinimizeButtonState))
            MsgBox(MinimizeWindowButton.Left)

        End If

    End Sub
#End Region

End Class