Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmDoorTypes
    Public dsDoortypes As New DataSet
    Public Gameid As Integer = 1
    Public DoorsChanges As Boolean = False
    Public Image1, Image2 As Bitmap
    Public Doortype As Integer = 1
    Public CurPictName As String

    'Labels and textboxes for own created dataset-view
    Public MaxDoors As Integer = 100
    Public MaxRowsVisible = 20
    Public CurrentPageNr As Integer = 1
    Public CurrentRownr As Integer = 0
    Public OldRownr As Integer = 0

    Public MyDoorLabel(4) As Label
    Public MyDoortypes(4, MaxDoors + 1) As TextBox
    Public MyHeaders() As String = {"doornr", "doorname", "picturename"}
    Public ColWidths() As Integer = {80, 150, 150}
    Public CurrentFilledRows As Integer = 0

    Public labelX As Integer = 10
    Public LabelY As Integer = 0
    Public labelw As Integer = 100
    Public labelh As Integer = 20
    Public TextStartX As Integer = 10
    Public TextStartY As Integer = 20
    Public textw As Integer = 100
    Public texth As Integer = 20
    Public ScrollHeight As Integer = 20

    Public Gamefile As String
    Public ButtonRightName As String = "\picts\arrowrightS.bmp"
    Public ButtonLeftName As String = "\picts\arrowleftS.bmp"
    Public ButtonSaveName As String = "\picts\DB.gif"
    Public ButtonCloseName As String = "\picts\close1.png"


    Private Sub frmDoorTypes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New Point(0, 0)
        Gamefile = CurDir()
        Me.CreateHeaders()
        Me.CreateTexts()
        Button1.Image = Bitmap.FromFile(Gamefile + "\" + ButtonRightName)
        Button2.Image = Bitmap.FromFile(Gamefile + "\" + ButtonLeftName)
        Button4.Image = Bitmap.FromFile(Gamefile + "\" + ButtonCloseName)
        Button5.BackgroundImage = Bitmap.FromFile(Gamefile + "\" + ButtonLeftName)
        Button6.BackgroundImage = Bitmap.FromFile(Gamefile + "\" + ButtonRightName)

        Me.LoadDoors()
        Me.FillDoors()

        DoorsChanges = False

    End Sub

    Public Sub FillDoors()

        For i = 0 To dsDoortypes.Tables(0).Rows.Count - 1
            MyDoortypes(1, i + 1).Text = dsDoortypes.Tables(0).Rows(i).Item(0)
            MyDoortypes(2, i + 1).Text = dsDoortypes.Tables(0).Rows(i).Item(1)
            MyDoortypes(3, i + 1).Text = dsDoortypes.Tables(0).Rows(i).Item(2)
        Next
    End Sub

    Public Sub LoadDoors()

        Dim mysql As String
        Dim mystring As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection

        dsDoortypes.Reset()
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        da = New OleDbDataAdapter
        mysql = "select * from Doortypes"

        da.SelectCommand = New OleDbCommand(mysql, myconnection1)
        myconnection1.Open()

        da.Fill(dsDoortypes, "Doortypes")

    End Sub


    Public Sub CreateHeaders()
        Dim maxwidth As Integer
        Dim l As Point

        l.X = labelX
        l.Y = LabelY
        For x = 1 To 3

            Dim myTB As Label
            Me.MyDoorLabel(x) = New Label
            myTB = MyDoorLabel(x)
            myTB.Text = MyHeaders(x - 1)
            myTB.Font = Label1.Font
            myTB.Tag = "0"
            myTB.Width = ColWidths(x - 1)
            myTB.Height = labelh
            myTB.Location = l
            myTB.Name = "L" + x.ToString  ' <- important for later accessing
            Me.Controls.Add(myTB)
            AddHandler MyDoorLabel(x).Click, AddressOf Me.ClickLabel
            l.X = l.X + ColWidths(x - 1)
            maxwidth = maxwidth + ColWidths(x - 1)

        Next
        Button1.Location = New Point(labelX + maxwidth + 10 + Button2.Width, TextStartY)
        Button2.Location = New Point(labelX + maxwidth + 10, TextStartY)
        Button4.Location = New Point(labelX + maxwidth + 10, Me.Height - 80)
        PictureBox1.Location = New Point(Button2.Location.X, TextStartY + Button2.Height + 10)
        PictureBox2.Location = New Point(PictureBox1.Location.X, PictureBox1.Location.Y + PictureBox1.Height + 10)
        Button5.Location = New Point(labelX + maxwidth + 10, PictureBox2.Location.Y + PictureBox1.Height + 10)
        Button6.Location = New Point(Button5.Location.X + Button5.Width + 5, PictureBox2.Location.Y + PictureBox1.Height + 10)
        TextBox1.Location = New Point(Button6.Location.X + Button6.Width + 5, PictureBox2.Location.Y + PictureBox1.Height + 10)

    End Sub

    Public Sub CreateTexts()
        Dim l As Point
        Dim name As String

        l.X = TextStartX
        l.Y = TextStartY
        For y = 1 To MaxDoors
            For x = 1 To 3

                Dim myTB As TextBox
                Me.MyDoortypes(x, y) = New TextBox
                myTB = MyDoortypes(x, y)
                myTB.Text = "" '"Field: " + x.ToString() + "-" + y.ToString()
                myTB.Tag = "0"
                myTB.Width = ColWidths(x - 1)
                myTB.Height = texth
                myTB.Location = l
                If y < 10 Then
                    name = "0" + y.ToString()
                Else
                    name = y.ToString()
                End If
                myTB.Name = "TB" + x.ToString + "-" + name ' <- important for later accessing
                Me.Controls.Add(myTB)
                AddHandler MyDoortypes(x, y).TextChanged, AddressOf Me.TextChanged
                AddHandler MyDoortypes(x, y).Enter, AddressOf Me.TextEntered

                l.X = l.X + ColWidths(x - 1)

            Next
            l.Y = l.Y + texth
            l.X = TextStartX
        Next

    End Sub


    Private Sub ClickLabel(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim str As String
        Dim btn As Label
        btn = CType(sender, Label)

        str = btn.Name

        'MsgBox(str)

    End Sub

    Private Sub TextEntered(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ind As Integer
        Dim str, pictname1, pictname2, pictname, fnam1, fnam2 As String
        Dim btn As TextBox
        btn = CType(sender, TextBox)

        str = btn.Name
        ind = str.Substring(4, 2)

        If ind <> CurrentRownr Then
            If CurrentRownr > 0 Then
                OldRownr = CurrentRownr
                For i = 1 To MyDoortypes.GetUpperBound(0) - 1
                    MyDoortypes(i, OldRownr).BackColor = Color.White
                Next
            End If
            CurrentRownr = ind
            For i = 1 To MyDoortypes.GetUpperBound(0) - 1
                MyDoortypes(i, CurrentRownr).BackColor = Color.Cornsilk
            Next
            'show pictures
            pictname = MyDoortypes(3, CurrentRownr).Text
            CurPictname = pictname

            pictname1 = pictname + "A-L01.bmp"
            pictname2 = pictname + "B-L01.bmp"
            fnam1 = Gamefile + "\doors\" + pictname1
            fnam2 = Gamefile + "\doors\" + pictname2

            Try
                PictureBox1.Image = Bitmap.FromFile(fnam1)
                PictureBox2.Image = Bitmap.FromFile(fnam2)

            Catch ex As Exception

            End Try

        End If


    End Sub

    Shadows Sub TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim str As String
        Dim btn As TextBox
        btn = CType(sender, TextBox)

        str = btn.Name
        If DoorsChanges = False Then
            DoorsChanges = True
        End If

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        For i = 0 To MaxDoors - 1
            MyDoortypes(1, i + 1).Location = New Point(MyDoortypes(1, i + 1).Location.X, MyDoortypes(1, i + 1).Location.Y - ScrollHeight)
            MyDoortypes(2, i + 1).Location = New Point(MyDoortypes(2, i + 1).Location.X, MyDoortypes(2, i + 1).Location.Y - ScrollHeight)
            MyDoortypes(3, i + 1).Location = New Point(MyDoortypes(3, i + 1).Location.X, MyDoortypes(3, i + 1).Location.Y - ScrollHeight)
        Next

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        For i = 0 To MaxDoors - 1
            MyDoortypes(1, i + 1).Location = New Point(MyDoortypes(1, i + 1).Location.X, MyDoortypes(1, i + 1).Location.Y + ScrollHeight)
            MyDoortypes(2, i + 1).Location = New Point(MyDoortypes(2, i + 1).Location.X, MyDoortypes(2, i + 1).Location.Y + ScrollHeight)
            MyDoortypes(3, i + 1).Location = New Point(MyDoortypes(3, i + 1).Location.X, MyDoortypes(3, i + 1).Location.Y + ScrollHeight)
        Next

    End Sub

    Private Sub UpdateDoors()

        Dim knr, kname, kpict As String

        'Delete all Keys in Database
        Me.ClearAlldoors()

        'Update new Keys in Database
        For i = 1 To MaxDoors
            knr = MyDoortypes(1, i).Text
            kname = MyDoortypes(2, i).Text
            kpict = MyDoortypes(3, i).Text
            If knr <> "" Then
                Me.InsertDoors(knr, kname, kpict)
            End If
        Next
        MsgBox("The new Doortypes have been saved succesfully !")

    End Sub

    Private Sub ClearAlldoors()

        Dim mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Delete * from Doortypes"

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()

    End Sub

    Private Sub InsertDoors(ByVal nr As String, ByVal name As String, ByVal pict As String)

        Dim mysql, mystr As String
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim themap As String = "aa"


        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)
        mystr = ""
        mystr = mystr + nr + ",'"
        mystr = mystr + name + "','"
        mystr = mystr + pict + "'"
        mysql = "Insert into Doortypes values (" + mystr + ")"

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()


    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim rc As Integer

        If DoorsChanges = True Then
            rc = MsgBox("Do you want to store these Doortypes ?", MsgBoxStyle.YesNoCancel)
            If rc = MsgBoxResult.Yes Then
                Me.UpdateDoors()
            End If
        End If

        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim pictname, pictname1, pictname2, fnam1, fnam2 As String

        If Doortype = 3 Then
            Return

        End If
        Doortype = Doortype + 1

        'show pictures
        pictname = CurPictName
        pictname1 = ""
        pictname2 = ""
        Select Case Doortype
            Case 1
                pictname1 = pictname + "A-L01.bmp"
                pictname2 = pictname + "B-L01.bmp"
            Case 2
                pictname1 = pictname + "A-L02.bmp"
                pictname2 = pictname + "B-L02.bmp"
            Case 3
                pictname1 = pictname + "A-L03.bmp"
                pictname2 = pictname + "B-L03.bmp"
        End Select
        fnam1 = Gamefile + "\doors\" + pictname1
        fnam2 = Gamefile + "\doors\" + pictname2
        PictureBox1.Image = Bitmap.FromFile(fnam1)
        PictureBox2.Image = Bitmap.FromFile(fnam2)
        TextBox1.Text = "LVL-" + Doortype.ToString()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim pictname, pictname1, pictname2, fnam1, fnam2 As String

        If Doortype = 1 Then
            Return

        End If

        Doortype = Doortype - 1

        'show pictures
        pictname = CurPictName
        pictname1 = ""
        pictname2 = ""
        Select Case Doortype
            Case 1
                pictname1 = pictname + "A-L01.bmp"
                pictname2 = pictname + "B-L01.bmp"
            Case 2
                pictname1 = pictname + "A-L02.bmp"
                pictname2 = pictname + "B-L02.bmp"
            Case 3
                pictname1 = pictname + "A-L03.bmp"
                pictname2 = pictname + "B-L03.bmp"
        End Select
        fnam1 = Gamefile + "\doors\" + pictname1
        fnam2 = Gamefile + "\doors\" + pictname2
        PictureBox1.Image = Bitmap.FromFile(fnam1)
        PictureBox2.Image = Bitmap.FromFile(fnam2)
        TextBox1.Text = "LVL-" + Doortype.ToString()

    End Sub
End Class