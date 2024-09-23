Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmKeys
    Public dsKeys As New DataSet
    Public Gameid As Integer = 1
    Public KeysChanges As Boolean = False
    Public Image1, Image2 As Bitmap

    'Labels and textboxes for own created dataset-view
    Public MaxKeys As Integer = 50
    Public MaxRowsVisible = 20
    Public CurrentPageNr As Integer = 1
    Public CurrentRownr As Integer = 0
    Public OldRownr As Integer = 0

    Public MyKeyLabel(7) As Label
    Public MyKeys(7, MaxKeys + 1) As TextBox
    Public MyHeaders() As String = {"keynr", "keyname", "picturename", "width", "height", "picturefloor"}
    Public ColWidths() As Integer = {60, 100, 100, 60, 60, 100}
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

    Private Sub frmKeys_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New Point(0, 0)
        Gamefile = CurDir()
        Me.CreateHeaders()
        Me.CreateTexts()
        Button1.Image = Bitmap.FromFile(Gamefile + "\" + ButtonRightName)
        Button2.Image = Bitmap.FromFile(Gamefile + "\" + ButtonLeftName)
        Button4.Image = Bitmap.FromFile(Gamefile + "\" + ButtonCloseName)

        Me.LoadKeys()
        Me.FillKeys()

        KeysChanges = False

    End Sub

    Public Sub FillKeys()

        For i = 0 To dsKeys.Tables(0).Rows.Count - 1
            MyKeys(1, i + 1).Text = dsKeys.Tables(0).Rows(i).Item(1)
            MyKeys(2, i + 1).Text = dsKeys.Tables(0).Rows(i).Item(3)
            MyKeys(3, i + 1).Text = dsKeys.Tables(0).Rows(i).Item(5)
            MyKeys(4, i + 1).Text = dsKeys.Tables(0).Rows(i).Item(6)
            MyKeys(5, i + 1).Text = dsKeys.Tables(0).Rows(i).Item(7)
            If dsKeys.Tables(0).Rows(i).Item(10) Is DBNull.Value Then
                MyKeys(6, i + 1).Text = ""
            Else
                MyKeys(6, i + 1).Text = dsKeys.Tables(0).Rows(i).Item(10)
            End If
        Next
    End Sub

    Public Sub LoadKeys()

        Dim mysql As String
        Dim mystring As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection

        dsKeys.Reset()
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        da = New OleDbDataAdapter
        mysql = "select * from Itemtypes where itemnr < 51 order by itemnr"

        da.SelectCommand = New OleDbCommand(mysql, myconnection1)
        myconnection1.Open()

        da.Fill(dsKeys, "Itemtypes")

    End Sub


    Public Sub CreateHeaders()
        Dim maxwidth As Integer
        Dim l As Point

        l.X = labelX
        l.Y = LabelY
        For x = 1 To 6

            Dim myTB As Label
            Me.MyKeyLabel(x) = New Label
            myTB = MyKeyLabel(x)
            myTB.Text = MyHeaders(x - 1)
            myTB.Font = Label1.Font
            myTB.Tag = "0"
            myTB.Width = ColWidths(x - 1)
            myTB.Height = labelh
            myTB.Location = l
            myTB.Name = "L" + x.ToString  ' <- important for later accessing
            Me.Controls.Add(myTB)
            AddHandler MyKeyLabel(x).Click, AddressOf Me.ClickLabel
            l.X = l.X + ColWidths(x - 1)
            maxwidth = maxwidth + ColWidths(x - 1)

        Next
        Button1.Location = New Point(labelX + maxwidth + 10 + Button2.Width, TextStartY)
        Button2.Location = New Point(labelX + maxwidth + 10, TextStartY)
        Button4.Location = New Point(labelX + maxwidth + 10, Me.Height - 80)
        PictureBox1.Location = New Point(Button2.Location.X, TextStartY + Button2.Height + 10)
        PictureBox2.Location = New Point(Button1.Location.X, TextStartY + Button2.Height + 10)


    End Sub

    Public Sub CreateTexts()
        Dim l As Point
        Dim name As String

        l.X = TextStartX
        l.Y = TextStartY
        For y = 1 To MaxKeys
            For x = 1 To 6

                Dim myTB As TextBox
                Me.MyKeys(x, y) = New TextBox
                myTB = MyKeys(x, y)
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
                AddHandler MyKeys(x, y).TextChanged, AddressOf Me.TextChanged
                AddHandler MyKeys(x, y).Enter, AddressOf Me.TextEntered

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
        Dim str, pictname1, pictname2 As String
        Dim btn As TextBox
        btn = CType(sender, TextBox)

        str = btn.Name
        ind = str.Substring(4, 2)

        If ind <> CurrentRownr Then
            If CurrentRownr > 0 Then
                OldRownr = CurrentRownr
                For i = 1 To MyKeys.GetUpperBound(0) - 1
                    MyKeys(i, OldRownr).BackColor = Color.White
                Next
            End If
            CurrentRownr = ind
            For i = 1 To MyKeys.GetUpperBound(0) - 1
                MyKeys(i, CurrentRownr).BackColor = Color.Cornsilk
            Next
            'show pictures
            pictname1 = MyKeys(3, CurrentRownr).Text
            pictname2 = MyKeys(6, CurrentRownr).Text

            Try
                PictureBox1.Image = Bitmap.FromFile(Gamefile + "\keys\" + pictname1)
                PictureBox2.Image = Bitmap.FromFile(Gamefile + "\keys\" + pictname2)

            Catch ex As Exception

            End Try

        End If


        'MsgBox(ind.ToString())


    End Sub
    Shadows Sub TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim str As String
        Dim btn As TextBox
        btn = CType(sender, TextBox)

        str = btn.Name
        If KeysChanges = False Then
            KeysChanges = True
        End If
        'MsgBox(str)

    End Sub

    Private Sub ScrollRecordsUp()

    End Sub

    Private Sub ScrollRecordsDown()

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        For i = 0 To MaxKeys - 1
            MyKeys(1, i + 1).Location = New Point(MyKeys(1, i + 1).Location.X, MyKeys(1, i + 1).Location.Y - ScrollHeight)
            MyKeys(2, i + 1).Location = New Point(MyKeys(2, i + 1).Location.X, MyKeys(2, i + 1).Location.Y - ScrollHeight)
            MyKeys(3, i + 1).Location = New Point(MyKeys(3, i + 1).Location.X, MyKeys(3, i + 1).Location.Y - ScrollHeight)
            MyKeys(4, i + 1).Location = New Point(MyKeys(4, i + 1).Location.X, MyKeys(4, i + 1).Location.Y - ScrollHeight)
            MyKeys(5, i + 1).Location = New Point(MyKeys(5, i + 1).Location.X, MyKeys(5, i + 1).Location.Y - ScrollHeight)
            MyKeys(6, i + 1).Location = New Point(MyKeys(6, i + 1).Location.X, MyKeys(6, i + 1).Location.Y - ScrollHeight)
        Next

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        For i = 0 To MaxKeys - 1
            MyKeys(1, i + 1).Location = New Point(MyKeys(1, i + 1).Location.X, MyKeys(1, i + 1).Location.Y + ScrollHeight)
            MyKeys(2, i + 1).Location = New Point(MyKeys(2, i + 1).Location.X, MyKeys(2, i + 1).Location.Y + ScrollHeight)
            MyKeys(3, i + 1).Location = New Point(MyKeys(3, i + 1).Location.X, MyKeys(3, i + 1).Location.Y + ScrollHeight)
            MyKeys(4, i + 1).Location = New Point(MyKeys(4, i + 1).Location.X, MyKeys(4, i + 1).Location.Y + ScrollHeight)
            MyKeys(5, i + 1).Location = New Point(MyKeys(5, i + 1).Location.X, MyKeys(5, i + 1).Location.Y + ScrollHeight)
            MyKeys(6, i + 1).Location = New Point(MyKeys(6, i + 1).Location.X, MyKeys(6, i + 1).Location.Y + ScrollHeight)
        Next

    End Sub

    Private Sub UpdateKeys()

        Dim knr, kname, kpict, kw, kh, kpictfloor As String

        'Delete all Keys in Database
        Me.ClearAllkeys()

        'Update new Keys in Database
        For i = 1 To MaxKeys
            knr = MyKeys(1, i).Text
            kname = MyKeys(2, i).Text
            kpict = MyKeys(3, i).Text
            kw = MyKeys(4, i).Text
            kh = MyKeys(5, i).Text
            kpictfloor = MyKeys(6, i).Text
            If knr <> "" Then
                Me.InsertKeys(knr, kname, kpict, kw, kh, kpictfloor)
            End If
        Next
        MsgBox("The new Keys have been saved succesfully !")

    End Sub

    Private Sub ClearAllkeys()

        Dim mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Delete * from Itemtypes where itemnr < 51"

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()

    End Sub

    Private Sub InsertKeys(ByVal nr As String, ByVal name As String, ByVal pict As String, ByVal w As String, ByVal h As String, ByVal pict2 As String)

        Dim mysql, mystr, nr3 As String
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim themap As String = "aa"


        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        nr3 = convert3(nr)
        mystr = nr3 + "'," 'itemid
        mystr = mystr + nr + ",'key','"
        mystr = mystr + name + "','keys','"
        mystr = mystr + pict + "',"
        mystr = mystr + w + ","
        mystr = mystr + h + ",'yes','yes','"
        mystr = mystr + pict2 + "','no','no',''"


        mysql = "Insert into Itemtypes values ('" + mystr + ")"

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()


    End Sub

    Private Function convert3(ByVal nr As String) As String
        Dim num3 As String

        If nr.Length() = 1 Then
            num3 = "00" + nr
        ElseIf nr.Length() = 2 Then
            num3 = "0" + nr
        Else
            num3 = nr
        End If

        Return num3

    End Function


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim rc As Integer

        If KeysChanges = True Then
            rc = MsgBox("Do you want to store these Keys ?", MsgBoxStyle.YesNoCancel)
            If rc = MsgBoxResult.Yes Then
                Me.UpdateKeys()
            End If
        End If

        Me.Close()
    End Sub

  
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_Validated(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class