<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.c_level = New System.Windows.Forms.ComboBox
        Me.t_lvlname2 = New System.Windows.Forms.TextBox
        Me.t_level2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.t_position2 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(329, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select Map:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'c_level
        '
        Me.c_level.FormattingEnabled = True
        Me.c_level.Items.AddRange(New Object() {"00  - Wood", "01 - Catacombs 1", "02 - Catacombs 2", "03 - Catacombs 3", "04 - Catacombs 4", "05 - Temple 1", "06 - Temple 2", "07 - Silver Tower 1", "08 - Silver Tower 2", "09 - Silver Tower 3", "10 - Azure Tower 1", "11 - Azure Tower 2", "12 - Azure Tower 3", "13 - Azure Tower 4", "14 - Frost Giants", "15 - Crimson Tower 1", "16 - Crimson Tower 2"})
        Me.c_level.Location = New System.Drawing.Point(126, 12)
        Me.c_level.Name = "c_level"
        Me.c_level.Size = New System.Drawing.Size(142, 21)
        Me.c_level.TabIndex = 2
        '
        't_lvlname2
        '
        Me.t_lvlname2.Enabled = False
        Me.t_lvlname2.Location = New System.Drawing.Point(24, 86)
        Me.t_lvlname2.Name = "t_lvlname2"
        Me.t_lvlname2.Size = New System.Drawing.Size(107, 20)
        Me.t_lvlname2.TabIndex = 34
        '
        't_level2
        '
        Me.t_level2.Enabled = False
        Me.t_level2.Location = New System.Drawing.Point(73, 60)
        Me.t_level2.Name = "t_level2"
        Me.t_level2.Size = New System.Drawing.Size(36, 20)
        Me.t_level2.TabIndex = 33
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Level:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(72, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "MAP:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        't_position2
        '
        Me.t_position2.Enabled = False
        Me.t_position2.Location = New System.Drawing.Point(27, 112)
        Me.t_position2.Name = "t_position2"
        Me.t_position2.Size = New System.Drawing.Size(36, 20)
        Me.t_position2.TabIndex = 35
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 422)
        Me.Controls.Add(Me.t_position2)
        Me.Controls.Add(Me.t_lvlname2)
        Me.Controls.Add(Me.t_level2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.c_level)
        Me.Controls.Add(Me.Button1)
        Me.Name = "MainWindow"
        Me.Text = "MainWindow"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents c_level As System.Windows.Forms.ComboBox
    Friend WithEvents t_lvlname2 As System.Windows.Forms.TextBox
    Friend WithEvents t_level2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents t_position2 As System.Windows.Forms.TextBox

End Class
