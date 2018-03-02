Public Class Form3

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim frmChild As New gTitleBarLib.gTitleBarMDI
        frmChild.MdiParent = Me
        frmChild.Show()

        'workaround for the minimize not displaying
        'correctly if tried before a maximize?
        frmChild.WindowState = FormWindowState.Maximized
        frmChild.WindowState = FormWindowState.Normal

    End Sub
End Class