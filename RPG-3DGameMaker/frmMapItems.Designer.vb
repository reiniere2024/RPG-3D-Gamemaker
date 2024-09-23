<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMapItems
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
        Me.txtGame = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.c_level = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbItems = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cbxDelete = New System.Windows.Forms.CheckBox
        Me.cbxEdit = New System.Windows.Forms.CheckBox
        Me.cbxShow = New System.Windows.Forms.CheckBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtGame
        '
        Me.txtGame.Location = New System.Drawing.Point(248, 9)
        Me.txtGame.Name = "txtGame"
        Me.txtGame.Size = New System.Drawing.Size(37, 20)
        Me.txtGame.TabIndex = 14
        Me.txtGame.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(190, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Game:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(307, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Select Map:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'c_level
        '
        Me.c_level.FormattingEnabled = True
        Me.c_level.Location = New System.Drawing.Point(388, 9)
        Me.c_level.Name = "c_level"
        Me.c_level.Size = New System.Drawing.Size(130, 21)
        Me.c_level.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Items:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbItems
        '
        Me.lbItems.FormattingEnabled = True
        Me.lbItems.Location = New System.Drawing.Point(12, 25)
        Me.lbItems.Name = "lbItems"
        Me.lbItems.Size = New System.Drawing.Size(150, 615)
        Me.lbItems.TabIndex = 20
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(876, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbxDelete
        '
        Me.cbxDelete.AutoSize = True
        Me.cbxDelete.Location = New System.Drawing.Point(630, 11)
        Me.cbxDelete.Name = "cbxDelete"
        Me.cbxDelete.Size = New System.Drawing.Size(55, 17)
        Me.cbxDelete.TabIndex = 24
        Me.cbxDelete.Text = "delete"
        Me.cbxDelete.UseVisualStyleBackColor = True
        '
        'cbxEdit
        '
        Me.cbxEdit.AutoSize = True
        Me.cbxEdit.Checked = True
        Me.cbxEdit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxEdit.Location = New System.Drawing.Point(568, 11)
        Me.cbxEdit.Name = "cbxEdit"
        Me.cbxEdit.Size = New System.Drawing.Size(43, 17)
        Me.cbxEdit.TabIndex = 25
        Me.cbxEdit.Text = "edit"
        Me.cbxEdit.UseVisualStyleBackColor = True
        '
        'cbxShow
        '
        Me.cbxShow.AutoSize = True
        Me.cbxShow.Location = New System.Drawing.Point(700, 11)
        Me.cbxShow.Name = "cbxShow"
        Me.cbxShow.Size = New System.Drawing.Size(51, 17)
        Me.cbxShow.TabIndex = 26
        Me.cbxShow.Text = "show"
        Me.cbxShow.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(757, 9)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(83, 20)
        Me.txtName.TabIndex = 27
        '
        'frmMapItems
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
        Me.Name = "frmMapItems"
        Me.Text = "RPG 3D GameMaker Place  Floor Items on Map"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtGame As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents c_level As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbItems As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbxDelete As System.Windows.Forms.CheckBox
    Friend WithEvents cbxEdit As System.Windows.Forms.CheckBox
    Friend WithEvents cbxShow As System.Windows.Forms.CheckBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
End Class
