<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMapMonsters
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
        Me.cbxDelete = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbItems = New System.Windows.Forms.ListBox
        Me.txtGame = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.c_level = New System.Windows.Forms.ComboBox
        Me.cbxEdit = New System.Windows.Forms.CheckBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.cbxShow = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'cbxDelete
        '
        Me.cbxDelete.AutoSize = True
        Me.cbxDelete.Location = New System.Drawing.Point(650, 15)
        Me.cbxDelete.Name = "cbxDelete"
        Me.cbxDelete.Size = New System.Drawing.Size(55, 17)
        Me.cbxDelete.TabIndex = 32
        Me.cbxDelete.Text = "delete"
        Me.cbxDelete.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(884, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 23)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Monsters:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbItems
        '
        Me.lbItems.FormattingEnabled = True
        Me.lbItems.Location = New System.Drawing.Point(24, 30)
        Me.lbItems.Name = "lbItems"
        Me.lbItems.Size = New System.Drawing.Size(150, 615)
        Me.lbItems.TabIndex = 29
        '
        'txtGame
        '
        Me.txtGame.Location = New System.Drawing.Point(260, 14)
        Me.txtGame.Name = "txtGame"
        Me.txtGame.Size = New System.Drawing.Size(37, 20)
        Me.txtGame.TabIndex = 28
        Me.txtGame.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(202, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Game:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(319, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Select Map:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'c_level
        '
        Me.c_level.FormattingEnabled = True
        Me.c_level.Location = New System.Drawing.Point(400, 14)
        Me.c_level.Name = "c_level"
        Me.c_level.Size = New System.Drawing.Size(130, 21)
        Me.c_level.TabIndex = 25
        '
        'cbxEdit
        '
        Me.cbxEdit.AutoSize = True
        Me.cbxEdit.Checked = True
        Me.cbxEdit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxEdit.Location = New System.Drawing.Point(588, 16)
        Me.cbxEdit.Name = "cbxEdit"
        Me.cbxEdit.Size = New System.Drawing.Size(43, 17)
        Me.cbxEdit.TabIndex = 33
        Me.cbxEdit.Text = "edit"
        Me.cbxEdit.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(771, 11)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(83, 20)
        Me.txtName.TabIndex = 35
        '
        'cbxShow
        '
        Me.cbxShow.AutoSize = True
        Me.cbxShow.Location = New System.Drawing.Point(714, 13)
        Me.cbxShow.Name = "cbxShow"
        Me.cbxShow.Size = New System.Drawing.Size(51, 17)
        Me.cbxShow.TabIndex = 34
        Me.cbxShow.Text = "show"
        Me.cbxShow.UseVisualStyleBackColor = True
        '
        'frmMapMonsters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 647)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.cbxShow)
        Me.Controls.Add(Me.cbxEdit)
        Me.Controls.Add(Me.cbxDelete)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbItems)
        Me.Controls.Add(Me.txtGame)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.c_level)
        Me.Name = "frmMapMonsters"
        Me.Text = "RPG 3D GameMaker Place Monsters on Map"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxDelete As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbItems As System.Windows.Forms.ListBox
    Friend WithEvents txtGame As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents c_level As System.Windows.Forms.ComboBox
    Friend WithEvents cbxEdit As System.Windows.Forms.CheckBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cbxShow As System.Windows.Forms.CheckBox
End Class
