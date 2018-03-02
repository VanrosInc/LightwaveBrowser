
Public Class gTitleBarMDI
    Inherits Form

#Region "Borderless Form Helper"

    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const WM_NCHITTEST As Integer = &H84

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_NCHITTEST Then
            Dim pt As New Point(m.LParam.ToInt32)
            pt = PointToClient(pt)
            If pt.X < GTitleBar1.FrameWidth AndAlso _
                pt.Y < GTitleBar1.FrameWidth Then
                m.Result = New IntPtr(HTTOPLEFT)
            ElseIf pt.X > (Width - GTitleBar1.FrameWidth) AndAlso _
                pt.Y < GTitleBar1.FrameWidth Then
                m.Result = New IntPtr(HTTOPRIGHT)
            ElseIf pt.Y < GTitleBar1.FrameWidth Then
                m.Result = New IntPtr(HTTOP)
            ElseIf pt.X < GTitleBar1.FrameWidth AndAlso _
                pt.Y > (Height - GTitleBar1.FrameWidth - _
                GTitleBar1.FrameHeightAdj) Then
                m.Result = New IntPtr(HTBOTTOMLEFT)
            ElseIf pt.X > (Width - GTitleBar1.FrameWidth) AndAlso _
                pt.Y > (Height - GTitleBar1.FrameWidth - _
                GTitleBar1.FrameHeightAdj) Then
                m.Result = New IntPtr(HTBOTTOMRIGHT)
            ElseIf pt.Y > (Height - GTitleBar1.FrameWidth - _
                GTitleBar1.FrameHeightAdj) Then
                m.Result = New IntPtr(HTBOTTOM)
            ElseIf pt.X < GTitleBar1.FrameWidth Then
                m.Result = New IntPtr(HTLEFT)
            ElseIf pt.X > (Width - GTitleBar1.FrameWidth) Then
                m.Result = New IntPtr(HTRIGHT)
            Else
                MyBase.WndProc(m)
            End If
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs)
        GTitleBar1.IsFormActive = True
        GTitleBar1.BackColor = Parent.BackColor

    End Sub

    Private Sub Form1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs)
        GTitleBar1.IsFormActive = False
    End Sub

#End Region

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)

        Refresh()

    End Sub

    Private Sub Button_Press_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Press.Click
        lblMDI.Text = "The Button Was Pressed"
    End Sub

    Private Sub gTitleBarMDI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GTitleBar1.BackColor = Parent.BackColor
    End Sub

    Private Sub gTitleBarMDI_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Parent.Refresh()
    End Sub
End Class
