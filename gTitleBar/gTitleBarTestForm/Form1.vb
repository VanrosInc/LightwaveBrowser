Public Class Form1

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

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        GTitleBar1.IsFormActive = True
    End Sub

    Private Sub Form1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        GTitleBar1.IsFormActive = False
    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'To allow the panel to paint the background add it to the gTitleBar
        panrbut.Location = New Point(GTitleBar1.Width - 75 - panrbut.Width, 4)
        GTitleBar1.Controls.Add(panrbut)

        Button_MDI.Location = New Point(panrbut.Left - Button_MDI.Width - 10, 4)
        GTitleBar1.Controls.Add(Button_MDI)

        LoadGrid()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form2.Show()
    End Sub

#Region "Load Grid"
    Private Sub LoadGrid()
        For i As Integer = 0 To 20
            Dim row As New DataGridViewRow
            row.CreateCells(DataGridView1)
            row.Cells(1).Value = Rnd(10000)
            row.Cells(2).Value = Rnd(10000)
            row.Cells(3).Value = Rnd(10000)
            row.Cells(4).Value = Rnd(10000)
            row.Cells(5).Value = Rnd(10000)
            DataGridView1.Rows.Add(row)
        Next
    End Sub
#End Region

    Private Sub Button_MDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_MDI.Click
        Form3.Show()
    End Sub
End Class
