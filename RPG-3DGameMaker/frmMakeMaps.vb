Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmMakeMaps
    Public dsMaps As New DataSet
    Public dsStairs As New DataSet

    Public Gameid As Integer = 1
    Public curmap As Integer
    Public CurItem As Integer = 1
    Public CurPattern As Integer = 1
    Public EditMode As Boolean = False


    Public MyFields(33, 33) As Integer       'Walls in Game-map
    Public MyPictures(33, 33) As PictureBox
    Public MapsCreated As Boolean
    Public StartX As Integer = 280
    Public StartY As Integer = 10
    Public PicWidth As Integer = 20
    Public CurrentClickedX As Integer = 0
    Public CurrentClickedY As Integer = 0

    Public EmptyImageName As String = "\picts\empty.jpg"
    Public RoadImageName As String = "\picts\road.jpg"
    Public StartImageName As String = "\picts\start.jpg"
    Public StairsImageName As String = "\picts\stairs.jpg"
    Public Stairs2ImageName As String = "\picts\stairs2.jpg"
    Public DoorsImageName As String = "\picts\door.jpg"
    Public Doors2ImageName As String = "\picts\door2.jpg"
    Public DoorOpenImageName As String = "\picts\dooropen.jpg"

    Public EMPTY As Bitmap
    Public ROAD As Bitmap
    Public START As Bitmap
    Public DOOR As Bitmap
    Public DOOR2 As Bitmap
    Public DOOR3 As Bitmap
    Public STAIRS As Bitmap
    Public STAIRS2 As Bitmap
    Public CURRENT As Bitmap

    Public CurrentImage As String = "picts\current.jpg"
    Public NewImage As String = "picts\new.jpg"
    Public Gamefile As String



    Public Emptymap As String = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"

    Private Sub frmMakeMaps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim game As Integer

        cbxDoor2.Text = "open" + vbCrLf + "door"
        Me.Location = New Point(0, 0)

        RadioButton1.Checked = True
        Gamefile = CurDir()
        Me.InitializeBitmaps()

        game = CInt(txtGame.Text)
        Gameid = game
        Me.SelectMaps(game)
        Me.SelectStairs(game)

        Me.MapsToArray()
        'cbxDoor2.Text = "door" + vbCrLf + "closed"


    End Sub

    Private Sub InitializeBitmaps()

        EMPTY = Bitmap.FromFile(Gamefile + EmptyImageName)
        ROAD = Bitmap.FromFile(Gamefile + RoadImageName)

        START = Bitmap.FromFile(Gamefile + StartImageName)
        DOOR = Bitmap.FromFile(Gamefile + DoorsImageName)
        DOOR2 = Bitmap.FromFile(Gamefile + Doors2ImageName)
        DOOR3 = Bitmap.FromFile(Gamefile + DoorOpenImageName)

        STAIRS = Bitmap.FromFile(Gamefile + StairsImageName)
        STAIRS2 = Bitmap.FromFile(Gamefile + Stairs2ImageName)

        CURRENT = ROAD

    End Sub

    Private Sub MapsToArray()
        'Fill ComboBox with Game Maps
        Dim map, level, mapname, themap As String

        c_level.Items.Clear()
        For i = 0 To dsMaps.Tables(0).Rows.Count - 1
            level = dsMaps.Tables(0).Rows(i).Item(2)
            mapname = dsMaps.Tables(0).Rows(i).Item(4)
            themap = dsMaps.Tables(0).Rows(i).Item(5)
            map = level + "-" + mapname
            c_level.Items.Add(map)
        Next

        Me.Invalidate()
        Me.Refresh()

    End Sub

    Private Sub SelectMaps(ByVal gamenr As Integer)
        Dim mysql As String
        Dim mystring As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection

        dsMaps.Reset()
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        da = New OleDbDataAdapter
        mysql = "select * from Maps where gameid = " + gamenr.ToString() + " order by gameid,mapnr"

        da.SelectCommand = New OleDbCommand(mysql, myconnection1)
        myconnection1.Open()

        da.Fill(dsMaps, "Maps")

    End Sub

    Private Sub SelectStairs(ByVal gamenr As Integer)

        Dim mysql As String
        Dim mystring As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection

        dsStairs.Reset()
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        da = New OleDbDataAdapter
        mysql = "select * from Stairs where gameid = " + gamenr.ToString() + " order by gameid,trepnr"

        da.SelectCommand = New OleDbCommand(mysql, myconnection1)
        myconnection1.Open()

        da.Fill(dsStairs, "Stairs")

    End Sub

    Public Function CheckGame(ByVal gamenr As Integer) As Boolean
        Dim mysql As String
        Dim rc As Integer
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "select count(*) from Maps where gameid = " + gamenr.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        rc = mycommand.ExecuteScalar()
        If rc = 0 Then
            Return False
        Else
            Return True
        End If


    End Function



    Public Function GetLevel(ByVal str As String) As Integer
        Dim str1, str2 As String
        Dim i, mapnr As Integer

        str2 = ""
        str1 = str.Substring(i, 1)
        While str1 <> "-"

            str2 = str2 + str1
            i = i + 1
            str1 = str.Substring(i, 1)
        End While

        mapnr = CInt(str2)
        Return mapnr


    End Function

    Private Sub c_level_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c_level.SelectedIndexChanged
        Dim mapstr, curitem, selected As String
        Dim ind As Integer
        selected = c_level.Text


        curmap = GetLevel(selected)

        mapstr = Me.GetMapstring(Gameid, curmap)
        'mapstr = dsMaps.Tables(0).Row 's(curlevel - 1).Item(5)

        For y = 1 To 32
            For x = 1 To 32
                curitem = mapstr.Substring(ind, 1)
                MyFields(x, y) = CInt(curitem)
                ind = ind + 2 'skip the , character
            Next
            'ind = ind + 2 'skip the vbcrlf characters
        Next

        If Not MapsCreated Then
            Me.CreateControls()
            MapsCreated = True
        End If
        Me.InitializeFields()


    End Sub

    Public Function GetMapstring(ByVal gameid As Integer, ByVal mapnr As Integer) As String
        Dim mysql As String
        Dim mystring, themap As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "select themap from Maps where gameid = " + gameid.ToString() + " and mapnr = " + mapnr.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        themap = mycommand.ExecuteScalar()
        Return themap


    End Function


    Public Sub InitializeFields()

        For y = 1 To 32
            For x = 1 To 32
                MyPictures(x, y).Image = EMPTY
            Next
        Next

        For y = 1 To 32
            For x = 1 To 32
                If MyFields(x, y) <> 0 Then
                    Me.AddImage(x, y, MyFields(x, y))
                End If
            Next
        Next

    End Sub

    Public Sub AddImage(ByVal pictx As Integer, ByVal picty As Integer, ByVal pictnum As Integer)

        Select Case pictnum

            Case 0
                MyPictures(pictx, picty).Image = EMPTY
                MyPictures(pictx, picty).Tag = "0"

            Case 1
                MyPictures(pictx, picty).Image = ROAD
                MyPictures(pictx, picty).Tag = "1"

            Case 2
                MyPictures(pictx, picty).Image = START
                MyPictures(pictx, picty).Tag = "2"

            Case 5
                MyPictures(pictx, picty).Image = STAIRS
                MyPictures(pictx, picty).Tag = "5"

            Case 6
                MyPictures(pictx, picty).Image = STAIRS2
                MyPictures(pictx, picty).Tag = "6"

            Case 7
                If MyFields(pictx - 1, picty) = 0 Then
                    MyPictures(pictx, picty).Image = DOOR
                    MyPictures(pictx, picty).Tag = "7"
                Else
                    MyPictures(pictx, picty).Image = DOOR2
                    MyPictures(pictx, picty).Tag = "7"
                End If

            Case 8
                'MyPictures(pictx, picty).Image = DOOR2
                'MyPictures(pictx, picty).Tag = "8"

            Case 9
                MyPictures(pictx, picty).Image = DOOR3
                MyPictures(pictx, picty).Tag = "9"

        End Select

    End Sub


    Public Sub CreateControls()
        Dim l As Point

        l.X = StartX
        l.Y = StartY


        For y = 1 To 32
            For x = 1 To 32
                l.X = l.X + PicWidth

                Dim myTB As PictureBox
                Me.MyPictures(x, y) = New PictureBox
                myTB = MyPictures(x, y)
                myTB.Image = EMPTY
                myTB.Tag = "0"
                myTB.Width = PicWidth
                myTB.Height = PicWidth
                myTB.Location = l
                myTB.Name = "PB" + x.ToString + "-" + y.ToString() ' <- important for later accessing
                'myTB.SizeMode = PictureBoxSizeMode.StretchImage
                Me.Controls.Add(myTB)
                AddHandler MyPictures(x, y).Click, AddressOf Me.ClickButton

            Next
            l.Y = l.Y + PicWidth
            l.X = StartX
        Next

    End Sub



    Private Sub AddFields(ByVal px As Integer, ByVal py As Integer, ByVal pattern As Integer)

        Try
            Select Case pattern

                Case 2 'XX
                    MyPictures(px + 1, py).Image = CURRENT
                    MyFields(px + 1, py) = CurItem

                Case 3 'XXXX
                    MyPictures(px + 1, py).Image = CURRENT
                    MyFields(px + 1, py) = CurItem
                    MyPictures(px + 2, py).Image = CURRENT
                    MyFields(px + 2, py) = CurItem
                    MyPictures(px + 3, py).Image = CURRENT
                    MyFields(px + 3, py) = CurItem

                Case 4 'X (4 VERT)
                    MyPictures(px, py + 1).Image = CURRENT
                    MyFields(px, py + 1) = CurItem
                    MyPictures(px, py + 2).Image = CURRENT
                    MyFields(px, py + 2) = CurItem
                    MyPictures(px, py + 3).Image = CURRENT
                    MyFields(px, py + 3) = CurItem

                Case 5 'XX (3 VERT)
                    MyPictures(px + 1, py).Image = CURRENT
                    MyFields(px + 1, py) = CurItem
                    MyPictures(px, py + 1).Image = CURRENT
                    MyFields(px, py + 1) = CurItem
                    MyPictures(px + 1, py + 1).Image = CURRENT
                    MyFields(px + 1, py + 1) = CurItem
                    MyPictures(px, py + 2).Image = CURRENT
                    MyFields(px, py + 2) = CurItem
                    MyPictures(px + 1, py + 2).Image = CURRENT
                    MyFields(px + 1, py + 2) = CurItem

                Case 6 'XXX (2 VERT)
                    MyPictures(px + 1, py).Image = CURRENT
                    MyFields(px + 1, py) = CurItem
                    MyPictures(px + 2, py).Image = CURRENT
                    MyFields(px + 2, py) = CurItem
                    MyPictures(px, py + 1).Image = CURRENT
                    MyFields(px, py + 1) = CurItem
                    MyPictures(px + 1, py + 1).Image = CURRENT
                    MyFields(px + 1, py + 1) = CurItem
                    MyPictures(px + 2, py + 1).Image = CURRENT
                    MyFields(px + 2, py + 1) = CurItem

                Case 7 'X (2 VERT)
                    MyPictures(px, py + 1).Image = CURRENT
                    MyFields(px, py + 1) = CurItem

                Case 8 'XX (2 VERT)
                    MyPictures(px + 1, py).Image = CURRENT
                    MyFields(px + 1, py) = CurItem
                    MyPictures(px, py + 1).Image = CURRENT
                    MyFields(px, py + 1) = CurItem
                    MyPictures(px + 1, py + 1).Image = CURRENT
                    MyFields(px + 1, py + 1) = CurItem

                Case 9 'XXX (3 VERT)
                    MyPictures(px + 1, py).Image = CURRENT
                    MyFields(px + 1, py) = CurItem
                    MyPictures(px + 2, py).Image = CURRENT
                    MyFields(px + 2, py) = CurItem
                    MyPictures(px, py + 1).Image = CURRENT
                    MyFields(px, py + 1) = CurItem
                    MyPictures(px + 1, py + 1).Image = CURRENT
                    MyFields(px + 1, py + 1) = CurItem
                    MyPictures(px + 2, py + 1).Image = CURRENT
                    MyFields(px + 2, py + 1) = CurItem
                    MyPictures(px, py + 2).Image = CURRENT
                    MyFields(px, py + 2) = CurItem
                    MyPictures(px + 1, py + 2).Image = CURRENT
                    MyFields(px + 1, py + 2) = CurItem
                    MyPictures(px + 2, py + 2).Image = CURRENT
                    MyFields(px + 2, py + 2) = CurItem

                Case 10 'XXX (4 VERT)
                    MyPictures(px + 1, py).Image = CURRENT
                    MyFields(px + 1, py) = CurItem
                    MyPictures(px + 2, py).Image = CURRENT
                    MyFields(px + 2, py) = CurItem
                    MyPictures(px, py + 1).Image = CURRENT
                    MyFields(px, py + 1) = CurItem
                    MyPictures(px + 1, py + 1).Image = CURRENT
                    MyFields(px + 1, py + 1) = CurItem
                    MyPictures(px + 2, py + 1).Image = CURRENT
                    MyFields(px + 2, py + 1) = CurItem
                    MyPictures(px, py + 2).Image = CURRENT
                    MyFields(px, py + 2) = CurItem
                    MyPictures(px + 1, py + 2).Image = CURRENT
                    MyFields(px + 1, py + 2) = CurItem
                    MyPictures(px + 2, py + 2).Image = CURRENT
                    MyFields(px + 2, py + 2) = CurItem
                    MyPictures(px, py + 3).Image = CURRENT
                    MyFields(px, py + 3) = CurItem
                    MyPictures(px + 1, py + 3).Image = CURRENT
                    MyFields(px + 1, py + 3) = CurItem
                    MyPictures(px + 2, py + 3).Image = CURRENT
                    MyFields(px + 2, py + 3) = CurItem

                Case 11 'XXXX (3 VERT)

                    MyPictures(px + 1, py).Image = CURRENT
                    MyFields(px + 1, py) = CurItem
                    MyPictures(px + 2, py).Image = CURRENT
                    MyFields(px + 2, py) = CurItem
                    MyPictures(px + 3, py).Image = CURRENT
                    MyFields(px + 3, py) = CurItem

                    MyPictures(px, py + 1).Image = CURRENT
                    MyFields(px, py + 1) = CurItem
                    MyPictures(px + 1, py + 1).Image = CURRENT
                    MyFields(px + 1, py + 1) = CurItem
                    MyPictures(px + 2, py + 1).Image = CURRENT
                    MyFields(px + 2, py + 1) = CurItem
                    MyPictures(px + 3, py + 1).Image = CURRENT
                    MyFields(px + 3, py + 1) = CurItem

                    MyPictures(px, py + 2).Image = CURRENT
                    MyFields(px, py + 2) = CurItem
                    MyPictures(px + 1, py + 2).Image = CURRENT
                    MyFields(px + 1, py + 2) = CurItem
                    MyPictures(px + 2, py + 2).Image = CURRENT
                    MyFields(px + 2, py + 2) = CurItem
                    MyPictures(px + 3, py + 2).Image = CURRENT
                    MyFields(px + 3, py + 2) = CurItem


            End Select


        Catch ex As Exception

        End Try



    End Sub

    Private Sub GetXY(ByVal name As String, ByRef x As Integer, ByRef y As Integer)

        Dim str, str1, str2 As String
        Dim ind1, ind2 As Integer

        str = name
        str1 = str.Substring(2, 1)
        If str.Substring(3, 1) = "-" Then
            ind1 = CInt(str1)
            str2 = str.Substring(4, 1)
            If str.Length() = 5 Then
                ind2 = CInt(str2)
            Else
                str2 = str2 + str.Substring(5, 1)
                ind2 = CInt(str2)
            End If
        Else
            str1 = str1 + str.Substring(3, 1)
            ind1 = CInt(str1)
            str2 = str.Substring(5, 1)
            If str.Length() = 6 Then
                ind2 = CInt(str2)
            Else
                str2 = str2 + str.Substring(6, 1)
                ind2 = CInt(str2)
            End If
        End If
        x = ind1
        y = ind2



    End Sub


    Private Sub txtGame_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtGame.Validating

        Dim gamenr As String

        gamenr = CInt(txtGame.Text)
        If CheckGame(gamenr) = True Then
            Gameid = gamenr
            Me.SelectMaps(gamenr)
            Me.MapsToArray()
        Else
            MsgBox("Game with number: " + txtGame.Text + " does not exist !!!")
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim gameid, mapid, mapnr As Integer
        Dim mapname As String

        mapname = txtMapName.Text
        If mapname = "" Then
            MsgBox("Fill in the name of this new map !!!")
            txtMapName.Focus()
            Return
        End If

        gameid = CInt(txtGame.Text)
        mapid = Me.GetNewMapid(gameid)
        mapnr = Me.GetNewMapnr(gameid)
        'Insert map in database
        Me.InsertNewMap(gameid, mapid, mapnr, mapname)
        'Get the new map to listbox
        Me.SelectMaps(gameid)
        Me.MapsToArray()

        Me.Invalidate()
        Me.Refresh()
        c_level.Refresh()



    End Sub

    Public Sub InsertNewMap(ByVal gameid As Integer, ByVal mapid As Integer, ByVal mapnr As Integer, ByVal mapname As String)

        Dim mysql As String
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim themap As String = "aa"


        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Insert into Maps values ( " + mapid.ToString() + "," + gameid.ToString() + "," + mapnr.ToString() + "," + mapnr.ToString() + ",'" + mapname.ToString() + "','" + Emptymap + "')"

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mapid = mycommand.ExecuteNonQuery()



    End Sub

    Public Function GetNewMapnr(ByVal gameid As Integer) As Integer

        Dim mysql As String
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim mapnr As Integer

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "select max(mapnr) from Maps where gameid = " + gameid.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mapnr = mycommand.ExecuteScalar()
        Return mapnr + 1

    End Function

    Public Function GetNewMapid(ByVal gameid As Integer) As Integer

        Dim mysql As String
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim mapid As Integer

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "select max(mapid) from Maps"

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mapid = mycommand.ExecuteScalar()
        Return mapid + 1


    End Function


    Private Sub cbxWall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxWall.CheckedChanged

        If cbxWall.Checked = True Then

            cbxRoad.Checked = False
            cbxTrep.Checked = False
            cbxDoor.Checked = False
            cbxTrep2.Checked = False
            cbxDoor2.Checked = False
            cbxDoor2.Checked = False

            CURRENT = EMPTY
            CurItem = 0
            Me.MakeControlsVisible(2)

        End If


    End Sub

    Private Sub cbxRoad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxRoad.CheckedChanged

        If cbxRoad.Checked = True Then

            cbxWall.Checked = False
            cbxTrep.Checked = False
            cbxDoor.Checked = False
            cbxTrep2.Checked = False
            cbxDoor2.Checked = False
            cbxDoor2.Checked = False

            CURRENT = ROAD
            CurItem = 1
            Me.MakeControlsVisible(1)


        End If


    End Sub

    Private Sub MakeControlsUnvisible(ByVal control As Integer)

        PB01.Visible = True
        PB02.Visible = False
        PB03.Visible = False
        PB04.Visible = False
        PB05.Visible = False
        PB06.Visible = False
        PB07.Visible = False
        PB08.Visible = False
        PB09.Visible = False
        PB10.Visible = False
        PB11.Visible = False
        RadioButton1.Visible = True
        RadioButton2.Visible = False
        RadioButton4.Visible = False
        RadioButton5.Visible = False
        RadioButton6.Visible = False
        RadioButton7.Visible = False
        RadioButton8.Visible = False
        RadioButton9.Visible = False
        RadioButton10.Visible = False
        RadioButton11.Visible = False
        RadioButton12.Visible = False
        Panel1.Visible = True
        Label4.Visible = True
        RadioButton1.Checked = True
        PB01.Image = ROAD

    End Sub

    Private Sub MakeControlsVisible(ByVal control As Integer)

        PB01.Visible = True
        PB02.Visible = True
        PB03.Visible = True
        PB04.Visible = True
        PB05.Visible = True
        PB06.Visible = True
        PB07.Visible = True
        PB08.Visible = True
        PB09.Visible = True
        PB10.Visible = True
        PB11.Visible = True
        RadioButton1.Visible = True
        RadioButton2.Visible = True
        RadioButton4.Visible = True
        RadioButton5.Visible = True
        RadioButton6.Visible = True
        RadioButton7.Visible = True
        RadioButton8.Visible = True
        RadioButton9.Visible = True
        RadioButton10.Visible = True
        RadioButton11.Visible = True
        RadioButton12.Visible = True
        Panel1.Visible = True
        Label4.Visible = True
        If control = 1 Then 'road
            PB01.Image = ROAD
            PB02.Image = ROAD
            PB03.Image = ROAD
            PB04.Image = ROAD
            PB05.Image = ROAD
            PB06.Image = ROAD
            PB07.Image = ROAD
            PB08.Image = ROAD
            PB09.Image = ROAD
            PB10.Image = ROAD
            PB11.Image = ROAD
        Else 'wall
            PB01.Image = EMPTY
            PB02.Image = EMPTY
            PB03.Image = EMPTY
            PB04.Image = EMPTY
            PB05.Image = EMPTY
            PB06.Image = EMPTY
            PB07.Image = EMPTY
            PB08.Image = EMPTY
            PB09.Image = EMPTY
            PB10.Image = EMPTY
            PB11.Image = EMPTY

        End If

    End Sub
    Private Sub cbxTrep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTrep.CheckedChanged

        If cbxTrep.Checked = True Then

            cbxRoad.Checked = False
            cbxWall.Checked = False
            cbxTrep2.Checked = False
            cbxDoor.Checked = False
            cbxDoor2.Checked = False
            cbxDoor2.Checked = False

            CURRENT = STAIRS
            CurItem = 5
            CurPattern = 1
            Me.MakeControlsUnvisible(3)

        End If


    End Sub

    Private Sub cbxDoor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDoor.CheckedChanged

        If cbxDoor.Checked = True Then

            cbxRoad.Checked = False
            cbxWall.Checked = False
            cbxTrep.Checked = False
            cbxTrep2.Checked = False
            cbxDoor2.Checked = False
            cbxDoor2.Checked = False

            CURRENT = DOOR

            CurItem = 7
            CurPattern = 1
            Me.MakeControlsUnvisible(4)

        End If


    End Sub

    Private Sub PictureBox53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox53.Click

    End Sub

    Private Sub SavetoNewMap()

    End Sub

    Private Sub UpdateTheMaps()

        Dim curitem As Integer
        Dim themap, mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        themap = ""
        For y = 1 To 32
            For x = 1 To 32
                curitem = MyFields(x, y)
                If x = 32 And y = 32 Then
                    themap = themap + curitem.ToString()
                Else
                    themap = themap + curitem.ToString() + ","
                End If
            Next
        Next

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Update Maps set themap = '" + themap + "' where gameid = " + Gameid.ToString() + " and mapnr = " + curmap.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim rc As Integer
        Dim gameid, mapid, mapnr As Integer
        Dim mapname As String

        rc = MsgBox("Save the updates to the current selected Map ?", MsgBoxStyle.YesNoCancel)

        If rc = MsgBoxResult.Cancel Then
            Return
        ElseIf rc = MsgBoxResult.Yes Then
            Me.UpdateTheMaps()
            gameid = CInt(txtGame.Text)

        ElseIf rc = MsgBoxResult.No Then

            mapname = txtMapName.Text
            If mapname = "" Then
                MsgBox("Fill in the name of this new map !!!")
                txtMapName.Focus()
                Return
            End If

            gameid = CInt(txtGame.Text)
            mapid = Me.GetNewMapid(gameid)
            mapnr = Me.GetNewMapnr(gameid)
            'Insert map in database
            Me.InsertNewMap(gameid, mapid, mapnr, mapname)
            curmap = mapnr
            Me.UpdateTheMaps()

        End If

        'Get the new maps
        Me.SelectMaps(gameid)
        Me.MapsToArray()


    End Sub

    Private Sub PB01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB01.Click
        If PB01.BorderStyle = BorderStyle.FixedSingle Then
            PB01.BorderStyle = BorderStyle.Fixed3D
        Else
            PB01.BorderStyle = BorderStyle.FixedSingle
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

        If RadioButton1.Checked = True Then
            PB01.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 1
        Else
            PB01.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            PB02.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 2
        Else
            PB02.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            PB03.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 3
        Else
            PB03.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            PB04.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 4
        Else
            PB04.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then
            PB05.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 5
        Else
            PB05.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        If RadioButton7.Checked = True Then
            PB06.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 6
        Else
            PB06.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub RadioButton8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton8.CheckedChanged
        If RadioButton8.Checked = True Then
            PB07.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 7
        Else
            PB07.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub RadioButton9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton9.CheckedChanged
        If RadioButton9.Checked = True Then
            PB08.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 8
        Else
            PB08.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub RadioButton10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton10.CheckedChanged
        If RadioButton10.Checked = True Then
            PB09.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 9
        Else
            PB09.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub RadioButton11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton11.CheckedChanged
        If RadioButton11.Checked = True Then
            PB10.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 10
        Else
            PB10.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub RadioButton12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton12.CheckedChanged
        If RadioButton12.Checked = True Then
            PB11.BorderStyle = BorderStyle.Fixed3D
            CurPattern = 11
        Else
            PB11.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub cbxTrep2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTrep2.CheckedChanged

        If cbxTrep2.Checked = True Then

            cbxRoad.Checked = False
            cbxWall.Checked = False
            cbxTrep.Checked = False
            cbxDoor.Checked = False
            cbxDoor2.Checked = False
            cbxDoor2.Checked = False

            CURRENT = STAIRS2
            CurItem = 6
            CurPattern = 1
            Me.MakeControlsUnvisible(4)

        End If

    End Sub

    'Private Sub cbxDoor2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If cbxDoor2.Checked = True Then

    '        cbxRoad.Checked = False
    '        cbxWall.Checked = False
    '        cbxDoor.Checked = False
    '        cbxDoor2.Checked = False
    '        cbxTrep.Checked = False
    '        cbxTrep2.Checked = False

    '        CURRENT = DOOR2
    '        CurItem = 8
    '        CurPattern = 1
    '        Me.MakeControlsUnvisible(6)

    '    End If

    'End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim str As String

        str = "C:\_Games\RPG-3DGameMaker\RPG-3DGameMaker\bin\Debug\Database\TEST02.mdb"

        If CreateAccessDatabase(str) = True Then
            MsgBox("Database Created")
        Else
            MsgBox("Database Creation Failed")
        End If



    End Sub

    Public Function CreateAccessDatabase(ByVal DatabaseFullPath As String) As Boolean
        Dim bAns As Boolean
        Dim cat As New ADOX.Catalog()

        Try
            Dim sCreateString As String
            'sCreateString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DatabaseFullPath
            sCreateString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DatabaseFullPath & ";Jet OLEDB:Database Password=Tapyxe01"
            cat.Create(sCreateString)
            'mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"

            bAns = True

        Catch Excep As System.Runtime.InteropServices.COMException
            bAns = False
            'do whatever else you need to do here, log, 
            'msgbox etc.
        Finally
            cat = Nothing
        End Try
        Return bAns
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If EditMode = False Then
            Button4.Text = "EDIT"
            EditMode = True
            'Label5.Visible = True
            'Label6.Visible = True
            'Label7.Visible = True
            'Label8.Visible = True
            'Label9.Visible = True
            'TextBox1.Visible = True
            'TextBox2.Visible = True
            'TextBox3.Visible = True


        Else
            Button4.Text = "SHOW"
            EditMode = False

            'Label5.Visible = False
            'Label6.Visible = False
            'Label7.Visible = False
            'Label8.Visible = False
            'Label9.Visible = False
            'TextBox1.Visible = False
            'TextBox2.Visible = False
            'TextBox3.Visible = False


        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lvl, x, y, lvlnow, xnow, ynow As Integer
        Dim lvlstr, xstr, ystr As String

        lvlstr = TextBox1.Text
        xstr = TextBox2.Text
        ystr = TextBox3.Text

        If lvlstr = "" Or xstr = "" Or ystr = "" Then
            MsgBox("Fill in the Target Level and the X and Y position of the stairs")
            Return
        End If

        lvl = CInt(lvlstr)
        x = CInt(xstr)
        y = CInt(ystr)
        lvlnow = curmap
        xnow = CurrentClickedX
        ynow = CurrentClickedY

        Me.UpdateStairsPositions(lvlnow, xnow, ynow, lvl, x, y)




    End Sub

    Private Sub ClickButton(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim str As String
        Dim x, y, px, py, lvl As Integer
        Dim btn As PictureBox
        btn = CType(sender, PictureBox)

        str = btn.Name
        Me.GetXY(str, x, y)
        CurrentClickedX = x '+ 1
        CurrentClickedY = y '+ 1
        TextBox4.Text = CurrentClickedX.ToString()
        TextBox5.Text = CurrentClickedY.ToString()
        If EditMode = False Then 'No Edits, Just replace tiles
            If cbxDoor.Checked = True Then
                If x > 1 Then
                    If MyFields(x - 1, y) = 0 Then
                        CURRENT = DOOR
                    Else
                        CURRENT = DOOR2
                    End If
                Else
                    If MyFields(x + 1, y) = 0 Then
                        CURRENT = DOOR
                    Else
                        CURRENT = DOOR2
                    End If
                End If

            End If
            MyPictures(x, y).Image = CURRENT
            MyFields(x, y) = CurItem
            If CurPattern <> 1 Then
                Me.AddFields(x, y, CurPattern)
            End If
        Else
            CurItem = MyFields(x, y)
            If CurItem = 5 Or CurItem = 6 Then
                px = 0
                py = 0
                lvl = 0
                Me.GetStairsPositions(curmap, CurrentClickedX, CurrentClickedY, lvl, px, py)
                If lvl > 0 Then
                    TextBox1.Text = lvl.ToString()
                    TextBox2.Text = px.ToString()
                    TextBox3.Text = py.ToString()
                Else
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""

                End If

            End If
        End If

    End Sub

    Private Sub UpdateStairsPositions(ByVal l As Integer, ByVal x As Integer, ByVal y As Integer, ByRef lvl As Integer, ByRef px As Integer, ByRef py As Integer)

        Dim mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Update Stairs set target = " + lvl.ToString() + ",tposx = " + px.ToString() + ",tposy = " + py.ToString() + " where gameid = " + Gameid.ToString() + " and levelid = " + curmap.ToString() + " and posx = " + x.ToString() + " and posy = " + y.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()


    End Sub


    Private Sub GetStairsPositions(ByVal l As Integer, ByVal x As Integer, ByVal y As Integer, ByRef lvl As Integer, ByRef px As Integer, ByRef py As Integer)

        Dim mysql As String
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "select target from Stairs where gameid = " + Gameid.ToString() + " and levelid = " + l.tostring() + " and posx = " + x.ToString() + " and posy = " + y.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        lvl = mycommand.ExecuteScalar()

        mysql = "select tposx from Stairs where gameid = " + Gameid.ToString() + " and levelid = " + l.ToString() + " and posx = " + x.ToString() + " and posy = " + y.ToString()
        mycommand.CommandText = mysql
        px = mycommand.ExecuteScalar()

        mysql = "select tposy from Stairs where gameid = " + Gameid.ToString() + " and levelid = " + l.ToString() + " and posx = " + x.ToString() + " and posy = " + y.ToString()
        mycommand.CommandText = mysql
        py = mycommand.ExecuteScalar()



    End Sub




    Private Sub cbxDoor3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDoor2.CheckedChanged

        If cbxDoor2.Checked = True Then

            cbxRoad.Checked = False
            cbxWall.Checked = False
            cbxDoor.Checked = False
            cbxDoor2.Checked = True
            cbxTrep.Checked = False
            cbxTrep2.Checked = False

            CURRENT = DOOR3
            CurItem = 9
            CurPattern = 1
            Me.MakeControlsUnvisible(6)

        End If

    End Sub
End Class