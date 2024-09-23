Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmWallItems
    Public dsMaps As New DataSet
    Public dsWallitems As New DataSet

    Public dsItems As New DataSet

    Public Gameid As Integer = 1
    Public curmap As Integer
    Public CurrentItem As Integer = 0

    Public MyFields(33, 33) As Integer       'Walls in Game-map
    Public MyItems(33, 33) As Integer       'Walls in Game-map

    Public MyPictures(33, 33) As PictureBox
    Public MapsCreated As Boolean
    Public StartX As Integer = 160
    Public StartY As Integer = 40
    Public PicWidth As Integer = 28
    Public PicHeight As Integer = 18

    Public EmptyImageName As String = "\picts\empty.jpg"
    Public RoadImageName As String = "\picts\road.jpg"
    Public StartImageName As String = "\picts\start.jpg"
    Public StairsImageName As String = "\picts\stairs.jpg"
    Public Stairs2ImageName As String = "\picts\stairs2.jpg"
    Public DoorsImageName As String = "\picts\door.jpg"
    Public Doors2ImageName As String = "\picts\door2.jpg"
    Public KeyImageName As String = "\picts\key2.bmp"
    Public SwordImageName As String = "\picts\sword2.bmp"

    Public EMPTY As Bitmap
    Public ROAD As Bitmap
    Public START As Bitmap
    Public DOOR As Bitmap
    Public DOOR2 As Bitmap
    Public STAIRS As Bitmap
    Public STAIRS2 As Bitmap
    Public CURRENT As Bitmap


    Public KEY As Bitmap
    Public SWORD As Bitmap


    Public CurrentImage As String = "picts\current.jpg"
    Public NewImage As String = "picts\new.jpg"
    Public Gamefile As String


    Public Emptymap As String = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"

    Private Sub frmWallItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim game As Integer

        Me.Location = New Point(0, 0)
        Gamefile = CurDir()
        Me.InitializeBitmaps()

        game = CInt(txtGame.Text)
        Gameid = game
        Me.SelectMaps(game)
        Me.MapsToArray()

        Me.FillItems()

    End Sub

    Private Sub Fillitems()
        Dim mysql As String
        Dim mystring As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection
        Dim itemstr, itemnr, itemname As String

        dsItems.Reset()
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        da = New OleDbDataAdapter
        mysql = "select * from Itemtypes where onwall = 'yes' order by itemnr"

        da.SelectCommand = New OleDbCommand(mysql, myconnection1)
        myconnection1.Open()

        da.Fill(dsItems, "Itemtypes")

        For i = 0 To dsItems.Tables(0).Rows.Count - 1
            itemnr = dsItems.Tables(0).Rows(i).Item(0)
            itemname = dsItems.Tables(0).Rows(i).Item(3)
            itemstr = itemnr + "-" + itemname
            lbItems.Items.Add(itemstr)

        Next

    End Sub

    Private Sub InitializeBitmaps()

        'map items
        EMPTY = Bitmap.FromFile(Gamefile + EmptyImageName)
        ROAD = Bitmap.FromFile(Gamefile + RoadImageName)

        START = Bitmap.FromFile(Gamefile + StartImageName)
        DOOR = Bitmap.FromFile(Gamefile + DoorsImageName)
        DOOR2 = Bitmap.FromFile(Gamefile + Doors2ImageName)
        STAIRS = Bitmap.FromFile(Gamefile + StairsImageName)
        STAIRS2 = Bitmap.FromFile(Gamefile + Stairs2ImageName)

        CURRENT = ROAD
        'item bitmaps
        KEY = Bitmap.FromFile(Gamefile + KeyImageName)
        SWORD = Bitmap.FromFile(Gamefile + SwordImageName)


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
        Dim da1, da2 As DbDataAdapter
        Dim myconnection1 As DbConnection

        dsMaps.Reset()
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        da1 = New OleDbDataAdapter
        mysql = "select * from Maps where gameid = " + gamenr.ToString() + " order by gameid,mapnr"

        da1.SelectCommand = New OleDbCommand(mysql, myconnection1)
        myconnection1.Open()

        da1.Fill(dsMaps, "Maps")

        da2 = New OleDbDataAdapter
        mysql = "select * from Wallitems where gameid = " + gamenr.ToString() + " order by gameid,mapnr"

        da2.SelectCommand = New OleDbCommand(mysql, myconnection1)
        da2.Fill(dsWallitems, "Wallitems")
        myconnection1.Close()



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
        Dim mapstr, itemstr, curitem, selected As String
        Dim ind As Integer
        selected = c_level.Text


        curmap = GetLevel(selected)

        mapstr = Me.GetMapstring(Gameid, curmap)
        'mapstr = dsMaps.Tables(0).Row 's(curlevel - 1).Item(5)
        ind = 0
        'show the basic map structure
        For y = 1 To 32
            For x = 1 To 32
                curitem = mapstr.Substring(ind, 1)
                MyFields(x, y) = CInt(curitem)
                ind = ind + 2 'skip the character

            Next
            'ind = ind + 2 'skip the vbcrlf characters
        Next
        'show the possible items on map
        itemstr = Me.GetItemstring(Gameid, curmap)
        ind = 0
        For y = 1 To 32
            For x = 1 To 32
                curitem = itemstr.Substring(ind, 3)
                MyItems(x, y) = CInt(curitem)
                ind = ind + 4 'skip the , character
            Next
            'ind = ind + 2 'skip the vbcrlf characters
        Next

        If Not MapsCreated Then
            Me.CreateControls()
            MapsCreated = True
        End If
        Me.InitializeFields()


    End Sub

    Public Function GetItemstring(ByVal gameid As Integer, ByVal mapnr As Integer) As String

        Dim mysql As String
        Dim mystring, theitem As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "select wallitems from Wallitems where gameid = " + gameid.ToString() + " and mapnr = " + mapnr.ToString()


        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        theitem = mycommand.ExecuteScalar()
        Return theitem


    End Function

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
        'basic layout of map items
        For y = 1 To 32
            For x = 1 To 32
                If MyFields(x, y) <> 0 Then
                    Me.AddImage(x, y, MyFields(x, y))
                End If
            Next
        Next

        For y = 1 To 32
            For x = 1 To 32
                If MyItems(x, y) <> 0 Then
                    Me.AddItemImage(x, y, MyItems(x, y))
                End If
            Next
        Next

    End Sub

    Public Sub AddItemImage(ByVal pictx As Integer, ByVal picty As Integer, ByVal pictnum As Integer)
        Dim pictname, filename As String
        Dim bmp As Bitmap

        'select pictname from table Itemtypes
        pictname = Me.GetItemPict(pictnum)
        filename = Gamefile + "\items\" + pictname
        bmp = Bitmap.FromFile(filename)
        'bmp.MakeTransparent(Color.Black)

        MyPictures(pictx, picty).Image = bmp


    End Sub


    Public Sub AddImage(ByVal pictx As Integer, ByVal picty As Integer, ByVal pictnum As Integer)

        Select Case pictnum

            Case 0
                MyPictures(pictx, picty).Image = EMPTY
                MyPictures(pictx, picty).BackgroundImage = EMPTY
                MyPictures(pictx, picty).Tag = "0"

            Case 1
                MyPictures(pictx, picty).Image = ROAD
                MyPictures(pictx, picty).BackgroundImage = ROAD
                MyPictures(pictx, picty).Tag = "1"

            Case 5
                MyPictures(pictx, picty).Image = STAIRS
                MyPictures(pictx, picty).Tag = "5"

            Case 6
                MyPictures(pictx, picty).Image = STAIRS2
                MyPictures(pictx, picty).Tag = "6"

            Case 7
                MyPictures(pictx, picty).Image = DOOR
                MyPictures(pictx, picty).Tag = "7"

            Case 8
                MyPictures(pictx, picty).Image = DOOR2
                MyPictures(pictx, picty).Tag = "8"

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
                myTB.SizeMode = PictureBoxSizeMode.StretchImage
                myTB.Image = EMPTY
                myTB.Tag = "0"
                myTB.Width = PicWidth
                myTB.Height = PicHeight
                myTB.Location = l
                myTB.Name = "PB" + x.ToString + "-" + y.ToString() ' <- important for later accessing
                'myTB.SizeMode = PictureBoxSizeMode.StretchImage
                Me.Controls.Add(myTB)
                AddHandler MyPictures(x, y).Click, AddressOf Me.ClickButton

            Next
            l.Y = l.Y + PicHeight
            l.X = StartX
        Next

    End Sub


    Private Sub ClickButton(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim str, item As String
        Dim x, y As Integer
        Dim btn As PictureBox
        btn = CType(sender, PictureBox)

        str = btn.Name
        Me.GetXY(str, x, y)

        If cbxDelete.Checked = True Then 'erase current clicked item
            If MyFields(x, y) = 0 Then
                MyPictures(x, y).Image = EMPTY
            ElseIf MyFields(x, y) = 1 Then
                MyPictures(x, y).Image = ROAD
            End If
            MyItems(x, y) = 0
        ElseIf cbxEdit.Checked = True Then
            If MyFields(x, y) = 0 Then 'only items painted on walls
                MyPictures(x, y).Image = CURRENT
                MyItems(x, y) = CurrentItem
            End If
        ElseIf cbxShow.Checked = True Then
            item = MyItems(x, y)
            txtName.Text = Me.GetItemName(item)

        End If

    End Sub

    Public Function GetItemName(ByVal itemnr As Integer) As String

        Dim mysql As String
        Dim mystring, itemname As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "select itemname from Itemtypes where itemnr = " + itemnr.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        itemname = mycommand.ExecuteScalar()
        Return itemname


    End Function


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




    Private Sub lbItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbItems.SelectedIndexChanged
        Dim str, itemstring As String
        Dim itemindex As Integer

        str = lbItems.Text 'get selected item listbox
        itemstring = str.Substring(0, 3)
        itemindex = CInt(itemstring)
        CurrentItem = itemindex
        CURRENT = GetCurrentItemBitmap(CurrentItem)

    End Sub

    Public Function GetCurrentItemBitmap(ByVal theitem As Integer) As Bitmap
        Dim pictname, filename As String
        Dim bmp As Bitmap

        'select pictname from table Itemtypes
        pictname = Me.GetItemPict(theitem)
        filename = Gamefile + "\items\" + pictname
        bmp = Bitmap.FromFile(filename)
        'bmp.MakeTransparent(Color.Black)

        Return bmp

    End Function

    Public Function GetItemPict(ByVal itemnr As Integer) As String

        Dim mysql As String
        Dim mystring, itemname As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "select pictname from Itemtypes where itemnr = " + itemnr.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        itemname = mycommand.ExecuteScalar()
        Return itemname


    End Function




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim mysql, map, item As String
        Dim curitem As Integer
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim ind As Integer = 0

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        map = ""

        For y = 1 To 32
            For x = 1 To 32
                curitem = MyItems(x, y)
                If curitem < 10 Then
                    item = "00" + curitem.ToString()
                ElseIf curitem < 100 Then
                    item = "0" + curitem.ToString()
                Else
                    item = curitem.ToString()
                End If
                map = map + item + ","
                'If y < 31 Or (y = 31 And x < 31) Then
                '    map = map + item + ","
                'End If
            Next
        Next
        mysql = "Update Wallitems set wallitems = '" + map + "' where gameid = " + Gameid.ToString() + " and mapnr = " + curmap.ToString()

        Try

            mycommand = New OleDbCommand
            mycommand.CommandText = mysql
            mycommand.Connection = myconnection1
            myconnection1.Open()
            mycommand.ExecuteNonQuery()

            MsgBox("The Game Items have been saved succesfully !")

            'Get the new maps
            Me.SelectMaps(Gameid)
            Me.MapsToArray()



        Catch ex As Exception

            MsgBox(ex.Message)


            MsgBox("Error while saving the Game Items!")

        End Try


    End Sub


    Private Sub cbxEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxEdit.Click

        cbxEdit.Checked = True
        cbxShow.Checked = False
        cbxDelete.Checked = False

    End Sub

    Private Sub cbxShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxShow.Click

        cbxEdit.Checked = False
        cbxShow.Checked = True
        cbxDelete.Checked = False

    End Sub



    Private Sub cbxDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxDelete.Click

        cbxEdit.Checked = False
        cbxShow.Checked = False
        cbxDelete.Checked = True
    End Sub


End Class