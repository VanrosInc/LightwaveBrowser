<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gTitleBar
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CloseWindowButton = New System.Windows.Forms.Button
        Me.MaximizeWindowButton = New System.Windows.Forms.Button
        Me.MinimizeWindowButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CloseWindowButton
        '
        Me.CloseWindowButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseWindowButton.BackColor = System.Drawing.SystemColors.Control
        Me.CloseWindowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CloseWindowButton.FlatAppearance.BorderSize = 0
        Me.CloseWindowButton.Location = New System.Drawing.Point(549, 6)
        Me.CloseWindowButton.Name = "CloseWindowButton"
        Me.CloseWindowButton.Size = New System.Drawing.Size(21, 21)
        Me.CloseWindowButton.TabIndex = 0
        Me.CloseWindowButton.UseVisualStyleBackColor = False
        '
        'MaximizeWindowButton
        '
        Me.MaximizeWindowButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaximizeWindowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MaximizeWindowButton.FlatAppearance.BorderSize = 0
        Me.MaximizeWindowButton.Location = New System.Drawing.Point(526, 6)
        Me.MaximizeWindowButton.Name = "MaximizeWindowButton"
        Me.MaximizeWindowButton.Size = New System.Drawing.Size(21, 21)
        Me.MaximizeWindowButton.TabIndex = 1
        Me.MaximizeWindowButton.UseVisualStyleBackColor = True
        '
        'MinimizeWindowButton
        '
        Me.MinimizeWindowButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MinimizeWindowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MinimizeWindowButton.FlatAppearance.BorderSize = 0
        Me.MinimizeWindowButton.Location = New System.Drawing.Point(503, 6)
        Me.MinimizeWindowButton.Name = "MinimizeWindowButton"
        Me.MinimizeWindowButton.Size = New System.Drawing.Size(21, 21)
        Me.MinimizeWindowButton.TabIndex = 2
        Me.MinimizeWindowButton.UseVisualStyleBackColor = True
        '
        'gTitleBar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.MinimizeWindowButton)
        Me.Controls.Add(Me.MaximizeWindowButton)
        Me.Controls.Add(Me.CloseWindowButton)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Name = "gTitleBar"
        Me.Size = New System.Drawing.Size(576, 30)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CloseWindowButton As System.Windows.Forms.Button
    Friend WithEvents MaximizeWindowButton As System.Windows.Forms.Button
    Friend WithEvents MinimizeWindowButton As System.Windows.Forms.Button

End Class
