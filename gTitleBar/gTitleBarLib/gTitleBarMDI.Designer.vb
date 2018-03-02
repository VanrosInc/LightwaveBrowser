<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gTitleBarMDI
    Inherits System.Windows.Forms.Form

    'Control overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblMDI = New System.Windows.Forms.Label
        Me.Button_Press = New System.Windows.Forms.Button
        Me.GTitleBar1 = New gTitleBar
        Me.SuspendLayout()
        '
        'lblMDI
        '
        Me.lblMDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMDI.Location = New System.Drawing.Point(12, 129)
        Me.lblMDI.Name = "lblMDI"
        Me.lblMDI.Size = New System.Drawing.Size(345, 34)
        Me.lblMDI.TabIndex = 0
        Me.lblMDI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_Press
        '
        Me.Button_Press.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Press.BackColor = System.Drawing.Color.LightCoral
        Me.Button_Press.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button_Press.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Press.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Button_Press.ForeColor = System.Drawing.Color.Black
        Me.Button_Press.Location = New System.Drawing.Point(224, 4)
        Me.Button_Press.Name = "Button_Press"
        Me.Button_Press.Size = New System.Drawing.Size(55, 22)
        Me.Button_Press.TabIndex = 10
        Me.Button_Press.Text = "Press"
        Me.Button_Press.UseVisualStyleBackColor = False
        '
        'GTitleBar1
        '
        Me.GTitleBar1.BackColor = System.Drawing.Color.Transparent
        Me.GTitleBar1.ControlBoxAffects = gTitleBar.eControlBoxAffects.ParentForm
        Me.GTitleBar1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GTitleBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GTitleBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GTitleBar1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GTitleBar1.IsFormActive = True
        Me.GTitleBar1.Location = New System.Drawing.Point(0, 0)
        Me.GTitleBar1.Name = "GTitleBar1"
        Me.GTitleBar1.resizeDir = gTitleBar.ResizeDirection.None
        Me.GTitleBar1.Size = New System.Drawing.Size(369, 30)
        Me.GTitleBar1.TabIndex = 11
        Me.GTitleBar1.TitleImage = Nothing
        Me.GTitleBar1.TitleImageSize = New System.Drawing.Size(24, 24)
        Me.GTitleBar1.TitleText = "MDI TitleBar"
        '
        'gTitleBarMDI
        '
        Me.ClientSize = New System.Drawing.Size(369, 301)
        Me.Controls.Add(Me.Button_Press)
        Me.Controls.Add(Me.GTitleBar1)
        Me.Controls.Add(Me.lblMDI)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "gTitleBarMDI"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblMDI As System.Windows.Forms.Label
    Friend WithEvents Button_Press As System.Windows.Forms.Button
    Friend WithEvents GTitleBar1 As gTitleBar

End Class

