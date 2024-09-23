Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmGameField
    Public dsGames As New DataSet
    Public MaxGamefields As Integer
    Public CurGamefield As Integer = 1

    Public Gamefile As String
    Public ButtonRightName As String = "\picts\arrowrightS.bmp"
    Public ButtonLeftName As String = "\picts\arrowleftS.bmp"
    Public CurrentRownr As Integer = 0

    Private Sub frmGameField_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New Point(0, 0)
        Gamefile = CurDir()
        Button2.Image = Bitmap.FromFile(Gamefile + "\" + ButtonRightName)
        Button3.Image = Bitmap.FromFile(Gamefile + "\" + ButtonLeftName)

        Me.LoadGames()
        Me.FillGames(CurrentRownr)

    End Sub

    Public Sub LoadGames()

        Dim mysql As String
        Dim mystring As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection

        dsGames.Reset()
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        da = New OleDbDataAdapter
        mysql = "select * from GameField order by fieldnr"

        da.SelectCommand = New OleDbCommand(mysql, myconnection1)
        myconnection1.Open()

        da.Fill(dsGames, "GameField")
        MaxGamefields = dsGames.Tables(0).Rows.Count

    End Sub

    Private Sub FillGames(ByVal rownr As Integer)
        Dim pictname, fnam As String

        'fill in the columns

        tbfieldnr.Text = dsGames.Tables(0).Rows(rownr).Item(0)
        tbname.Text = dsGames.Tables(0).Rows(rownr).Item(1)
        tbpict.Text = dsGames.Tables(0).Rows(rownr).Item(2)

        w1.Text = dsGames.Tables(0).Rows(rownr).Item(3)
        w2.Text = dsGames.Tables(0).Rows(rownr).Item(4)
        w3.Text = dsGames.Tables(0).Rows(rownr).Item(5)
        w4.Text = dsGames.Tables(0).Rows(rownr).Item(6)
        txt1.Text = dsGames.Tables(0).Rows(rownr).Item(7)
        txt2.Text = dsGames.Tables(0).Rows(rownr).Item(8)
        txt3.Text = dsGames.Tables(0).Rows(rownr).Item(9)
        txt4.Text = dsGames.Tables(0).Rows(rownr).Item(10)

        invc1.Text = dsGames.Tables(0).Rows(rownr).Item(11)
        invc2.Text = dsGames.Tables(0).Rows(rownr).Item(12)
        invc3.Text = dsGames.Tables(0).Rows(rownr).Item(13)
        invc4.Text = dsGames.Tables(0).Rows(rownr).Item(14)

        inv1.Text = dsGames.Tables(0).Rows(rownr).Item(15)
        inv2.Text = dsGames.Tables(0).Rows(rownr).Item(16)
        inv3.Text = dsGames.Tables(0).Rows(rownr).Item(17)
        inv4.Text = dsGames.Tables(0).Rows(rownr).Item(18)
        inv5.Text = dsGames.Tables(0).Rows(rownr).Item(19)
        inv6.Text = dsGames.Tables(0).Rows(rownr).Item(20)
        iusr1.Text = dsGames.Tables(0).Rows(rownr).Item(21)
        iusr2.Text = dsGames.Tables(0).Rows(rownr).Item(22)
        iusr3.Text = dsGames.Tables(0).Rows(rownr).Item(23)
        iusr4.Text = dsGames.Tables(0).Rows(rownr).Item(24)
        inam1.Text = dsGames.Tables(0).Rows(rownr).Item(25)
        inam2.Text = dsGames.Tables(0).Rows(rownr).Item(26)
        inam3.Text = dsGames.Tables(0).Rows(rownr).Item(27)
        inam4.Text = dsGames.Tables(0).Rows(rownr).Item(28)

        dir1.Text = dsGames.Tables(0).Rows(rownr).Item(29)
        dir2.Text = dsGames.Tables(0).Rows(rownr).Item(30)
        dir3.Text = dsGames.Tables(0).Rows(rownr).Item(31)
        dir4.Text = dsGames.Tables(0).Rows(rownr).Item(32)
        dir5.Text = dsGames.Tables(0).Rows(rownr).Item(33)
        dir6.Text = dsGames.Tables(0).Rows(rownr).Item(34)

        nam1.Text = dsGames.Tables(0).Rows(rownr).Item(35)
        nam2.Text = dsGames.Tables(0).Rows(rownr).Item(36)
        nam3.Text = dsGames.Tables(0).Rows(rownr).Item(37)
        nam4.Text = dsGames.Tables(0).Rows(rownr).Item(38)
        nam5.Text = dsGames.Tables(0).Rows(rownr).Item(39)
        nam6.Text = dsGames.Tables(0).Rows(rownr).Item(40)
        usr1.Text = dsGames.Tables(0).Rows(rownr).Item(41)
        usr2.Text = dsGames.Tables(0).Rows(rownr).Item(42)
        usr3.Text = dsGames.Tables(0).Rows(rownr).Item(43)
        usr4.Text = dsGames.Tables(0).Rows(rownr).Item(44)
        usr5.Text = dsGames.Tables(0).Rows(rownr).Item(45)
        usr6.Text = dsGames.Tables(0).Rows(rownr).Item(46)
        h11.Text = dsGames.Tables(0).Rows(rownr).Item(47)
        h12.Text = dsGames.Tables(0).Rows(rownr).Item(48)
        h13.Text = dsGames.Tables(0).Rows(rownr).Item(49)
        h14.Text = dsGames.Tables(0).Rows(rownr).Item(50)
        h15.Text = dsGames.Tables(0).Rows(rownr).Item(51)
        h16.Text = dsGames.Tables(0).Rows(rownr).Item(52)
        h21.Text = dsGames.Tables(0).Rows(rownr).Item(53)
        h22.Text = dsGames.Tables(0).Rows(rownr).Item(54)
        h23.Text = dsGames.Tables(0).Rows(rownr).Item(55)
        h24.Text = dsGames.Tables(0).Rows(rownr).Item(56)
        h25.Text = dsGames.Tables(0).Rows(rownr).Item(57)
        h26.Text = dsGames.Tables(0).Rows(rownr).Item(58)
        hlt1.Text = dsGames.Tables(0).Rows(rownr).Item(59)
        hlt2.Text = dsGames.Tables(0).Rows(rownr).Item(60)
        hlt3.Text = dsGames.Tables(0).Rows(rownr).Item(61)
        hlt4.Text = dsGames.Tables(0).Rows(rownr).Item(62)
        hlt5.Text = dsGames.Tables(0).Rows(rownr).Item(63)
        hlt6.Text = dsGames.Tables(0).Rows(rownr).Item(64)

        'show the picture

        pictname = dsGames.Tables(0).Rows(rownr).Item(2)
        fnam = Gamefile + "\gamefield\" + pictname
        Try
            PictureBox1.Image = Bitmap.FromFile(fnam)

        Catch ex As Exception

        End Try

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If CurGamefield = MaxGamefields Then
            Return
        End If
        CurGamefield = CurGamefield + 1
        FillGames(CurGamefield - 1)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If CurGamefield = 1 Then
            Return
        End If
        CurGamefield = CurGamefield - 1
        FillGames(CurGamefield - 1)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim gamenr, z As Integer
        Dim gamename, pictname As String

        gamenr = MaxGamefields + 1
        gamename = "New Game"
        pictname = ""
        z = 0

        Me.InsertGamefield(gamenr, gamename, pictname)
        CurGamefield = gamenr
        Me.LoadGames()
        Me.FillGames(CurGamefield - 1)


    End Sub

    Private Sub InsertGamefield(ByVal gnr As String, ByVal gname As String, ByVal pict As String)

        Dim mysql, mystr As String
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim themap As String = "aa"


        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)


        mystr = gnr + ",'"
        mystr = mystr + gname + "','" + pict + "',"
        mystr = mystr + "0,0,0,0,0,0,0,0,0,0,0,0,"  'window + text + inv.control
        mystr = mystr + "0,0,0,0,0,0,0,0,0,0,0,0,0,0,"  'inventory items
        mystr = mystr + "0,0,0,0,0,0,0,0,0,0,0,0,"  'directions+names
        mystr = mystr + "0,0,0,0,0,0,0,0,0,0,0,0,"  'users+weapons1
        mystr = mystr + "0,0,0,0,0,0,0,0,0,0,0,0"  'weapons2+health
        mysql = "Insert into GameField values (" + mystr + ")"
        '58
        '8,14,12,12,12
        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim rc As Integer
        Dim gameid, mapid, mapnr As Integer
        Dim mapname As String

        rc = MsgBox("Save the updates to the current selected Map ?", MsgBoxStyle.YesNoCancel)

        If rc = MsgBoxResult.Cancel Then
            Return
        ElseIf rc = MsgBoxResult.Yes Then
            Me.UpdateGameField()

        ElseIf rc = MsgBoxResult.No Then
            Return

        End If

    End Sub

    Private Sub UpdateGameField()

        Dim curitem, rownr As Integer
        Dim themap, mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        Dim win1, win2, win3, win4, t1, t2, t3, t4, ic1, ic2, ic3, ic4, iv1, iv2, iv3, iv4, iv5, iv6 As String
        Dim iu1, iu2, iu3, iu4, in1, in2, in3, in4, d1, d2, d3, d4, d5, d6, n1, n2, n3, n4, n5, n6 As String
        Dim u1, u2, u3, u4, u5, u6, w11, w12, w13, w14, w15, w16, w21, w22, w23, w24, w25, w26 As String
        Dim hl1, hl2, hl3, hl4, hl5, hl6 As String
        Dim fnr, fnam, pnam As String

        rownr = CurrentRownr

        'Get Fields
        fnr = tbfieldnr.Text
        fnam = tbname.Text
        pnam = tbpict.Text

        win1 = w1.Text
        win2 = w2.Text
        win3 = w3.Text
        win4 = w4.Text
        t1 = txt1.Text
        t2 = txt2.Text
        t3 = txt3.Text
        t4 = txt4.Text

        ic1 = invc1.Text
        ic2 = invc2.Text
        ic3 = invc3.Text
        ic4 = invc4.Text

        iv1 = inv1.Text
        iv2 = inv2.Text
        iv3 = inv3.Text
        iv4 = inv4.Text
        iv5 = inv5.Text
        iv6 = inv6.Text
        iu1 = iusr1.Text
        iu2 = iusr2.Text
        iu3 = iusr3.Text
        iu4 = iusr4.Text
        in1 = inam1.Text
        in2 = inam2.Text
        in3 = inam3.Text
        in4 = inam4.Text

        d1 = dir1.Text
        d2 = dir2.Text
        d3 = dir3.Text
        d4 = dir4.Text
        d5 = dir5.Text
        d6 = dir6.Text

        n1 = nam1.Text
        n2 = nam2.Text
        n3 = nam3.Text
        n4 = nam4.Text
        n5 = nam5.Text
        n6 = nam6.Text
        u1 = usr1.Text
        u2 = usr2.Text
        u3 = usr3.Text
        u4 = usr4.Text
        u5 = usr5.Text
        u6 = usr6.Text
        w11 = h11.Text
        w12 = h12.Text
        w13 = h13.Text
        w14 = h14.Text
        w15 = h15.Text
        w16 = h16.Text
        w21 = h21.Text
        w22 = h22.Text
        w23 = h23.Text
        w24 = h24.Text
        w25 = h25.Text
        w26 = h26.Text
        hl1 = hlt1.Text
        hl2 = hlt2.Text
        hl3 = hlt3.Text
        hl4 = hlt4.Text
        hl5 = hlt5.Text
        hl6 = hlt6.Text

        'Save Fields in Dataset
        dsGames.Tables(0).Rows(rownr).Item(1) = rownr
        dsGames.Tables(0).Rows(rownr).Item(2) = tbpict.Text

        dsGames.Tables(0).Rows(rownr).Item(3) = w1.Text
        dsGames.Tables(0).Rows(rownr).Item(4) = w2.Text
        dsGames.Tables(0).Rows(rownr).Item(5) = w3.Text
        dsGames.Tables(0).Rows(rownr).Item(6) = w4.Text
        dsGames.Tables(0).Rows(rownr).Item(7) = txt1.Text
        dsGames.Tables(0).Rows(rownr).Item(8) = txt2.Text
        dsGames.Tables(0).Rows(rownr).Item(9) = txt3.Text
        dsGames.Tables(0).Rows(rownr).Item(10) = txt4.Text

        dsGames.Tables(0).Rows(rownr).Item(11) = invc1.Text
        dsGames.Tables(0).Rows(rownr).Item(12) = invc2.Text
        dsGames.Tables(0).Rows(rownr).Item(13) = invc3.Text
        dsGames.Tables(0).Rows(rownr).Item(14) = invc4.Text

        dsGames.Tables(0).Rows(rownr).Item(15) = inv1.Text
        dsGames.Tables(0).Rows(rownr).Item(16) = inv2.Text
        dsGames.Tables(0).Rows(rownr).Item(17) = inv3.Text
        dsGames.Tables(0).Rows(rownr).Item(18) = inv4.Text
        dsGames.Tables(0).Rows(rownr).Item(19) = inv5.Text
        dsGames.Tables(0).Rows(rownr).Item(20) = inv6.Text
        dsGames.Tables(0).Rows(rownr).Item(21) = iusr1.Text
        dsGames.Tables(0).Rows(rownr).Item(22) = iusr2.Text
        dsGames.Tables(0).Rows(rownr).Item(23) = iusr3.Text
        dsGames.Tables(0).Rows(rownr).Item(24) = iusr4.Text
        dsGames.Tables(0).Rows(rownr).Item(25) = inam1.Text
        dsGames.Tables(0).Rows(rownr).Item(26) = inam2.Text
        dsGames.Tables(0).Rows(rownr).Item(27) = inam3.Text
        dsGames.Tables(0).Rows(rownr).Item(28) = inam4.Text

        dsGames.Tables(0).Rows(rownr).Item(29) = dir1.Text
        dsGames.Tables(0).Rows(rownr).Item(30) = dir2.Text
        dsGames.Tables(0).Rows(rownr).Item(31) = dir3.Text
        dsGames.Tables(0).Rows(rownr).Item(32) = dir4.Text
        dsGames.Tables(0).Rows(rownr).Item(33) = dir5.Text
        dsGames.Tables(0).Rows(rownr).Item(34) = dir6.Text

        dsGames.Tables(0).Rows(rownr).Item(35) = nam1.Text
        dsGames.Tables(0).Rows(rownr).Item(36) = nam2.Text
        dsGames.Tables(0).Rows(rownr).Item(37) = nam3.Text
        dsGames.Tables(0).Rows(rownr).Item(38) = nam4.Text
        dsGames.Tables(0).Rows(rownr).Item(39) = nam5.Text
        dsGames.Tables(0).Rows(rownr).Item(40) = nam6.Text
        dsGames.Tables(0).Rows(rownr).Item(41) = usr1.Text
        dsGames.Tables(0).Rows(rownr).Item(42) = usr2.Text
        dsGames.Tables(0).Rows(rownr).Item(43) = usr3.Text
        dsGames.Tables(0).Rows(rownr).Item(44) = usr4.Text
        dsGames.Tables(0).Rows(rownr).Item(45) = usr5.Text
        dsGames.Tables(0).Rows(rownr).Item(46) = usr6.Text
        dsGames.Tables(0).Rows(rownr).Item(47) = h11.Text
        dsGames.Tables(0).Rows(rownr).Item(48) = h12.Text
        dsGames.Tables(0).Rows(rownr).Item(49) = h13.Text
        dsGames.Tables(0).Rows(rownr).Item(50) = h14.Text
        dsGames.Tables(0).Rows(rownr).Item(51) = h15.Text
        dsGames.Tables(0).Rows(rownr).Item(52) = h16.Text
        dsGames.Tables(0).Rows(rownr).Item(53) = h21.Text
        dsGames.Tables(0).Rows(rownr).Item(54) = h22.Text
        dsGames.Tables(0).Rows(rownr).Item(55) = h23.Text
        dsGames.Tables(0).Rows(rownr).Item(56) = h24.Text
        dsGames.Tables(0).Rows(rownr).Item(57) = h25.Text
        dsGames.Tables(0).Rows(rownr).Item(58) = h26.Text
        dsGames.Tables(0).Rows(rownr).Item(59) = hlt1.Text
        dsGames.Tables(0).Rows(rownr).Item(60) = hlt2.Text
        dsGames.Tables(0).Rows(rownr).Item(61) = hlt3.Text
        dsGames.Tables(0).Rows(rownr).Item(62) = hlt4.Text
        dsGames.Tables(0).Rows(rownr).Item(63) = hlt5.Text
        dsGames.Tables(0).Rows(rownr).Item(64) = hlt6.Text

        'Update the Database
        mysql = "Update GameField set fieldname = '" + fnam + "',"
        mysql = mysql + "pictname = '" + pnam + "',"
        mysql = mysql + "mx = " + win1.ToString() + ","
        mysql = mysql + "my = " + win2.ToString() + ","
        mysql = mysql + "mw = " + win3.ToString() + ","
        mysql = mysql + "mh = " + win4.ToString() + ","
        mysql = mysql + "tx1 = " + t1.ToString() + ","
        mysql = mysql + "ty1 = " + t2.ToString() + ","
        mysql = mysql + "tw1 = " + t3.ToString() + ","
        mysql = mysql + "th1 = " + t4.ToString() + ","
        mysql = mysql + "icx = " + ic1.ToString() + ","
        mysql = mysql + "icy = " + ic2.ToString() + ","
        mysql = mysql + "icw = " + ic3.ToString() + ","
        mysql = mysql + "ich = " + ic4.ToString() + ","
        mysql = mysql + "ix = " + iv1.ToString() + ","
        mysql = mysql + "iy = " + iv2.ToString() + ","
        mysql = mysql + "iw = " + iv3.ToString() + ","
        mysql = mysql + "ih = " + iv4.ToString() + ","
        mysql = mysql + "idx = " + iv5.ToString() + ","
        mysql = mysql + "idy = " + iv6.ToString() + ","
        mysql = mysql + "iux = " + iu1.ToString() + ","
        mysql = mysql + "iuy = " + iu2.ToString() + ","
        mysql = mysql + "iuw = " + iu3.ToString() + ","
        mysql = mysql + "iuh = " + iu4.ToString() + ","
        mysql = mysql + "inx = " + in1.ToString() + ","
        mysql = mysql + "iny = " + in2.ToString() + ","
        mysql = mysql + "inw = " + in3.ToString() + ","
        mysql = mysql + "inh = " + in4.ToString() + ","
        mysql = mysql + "dx = " + d1.ToString() + ","
        mysql = mysql + "dy = " + d2.ToString() + ","
        mysql = mysql + "dw = " + d3.ToString() + ","
        mysql = mysql + "dh = " + d4.ToString() + ","
        mysql = mysql + "ddx = " + d5.ToString() + ","
        mysql = mysql + "ddy = " + d6.ToString() + ","
        mysql = mysql + "nx = " + n1.ToString() + ","
        mysql = mysql + "ny = " + n2.ToString() + ","
        mysql = mysql + "nw = " + n3.ToString() + ","
        mysql = mysql + "nh = " + n4.ToString() + ","
        mysql = mysql + "ndx = " + n5.ToString() + ","
        mysql = mysql + "ndy = " + n6.ToString() + ","
        mysql = mysql + "ux = " + u1.ToString() + ","
        mysql = mysql + "uy = " + u2.ToString() + ","
        mysql = mysql + "uw = " + u3.ToString() + ","
        mysql = mysql + "uh = " + u4.ToString() + ","
        mysql = mysql + "udx = " + u5.ToString() + ","
        mysql = mysql + "udy = " + u6.ToString() + ","
        mysql = mysql + "w1x = " + w11.ToString() + ","
        mysql = mysql + "w1y = " + w12.ToString() + ","
        mysql = mysql + "w1w = " + w13.ToString() + ","
        mysql = mysql + "w1h = " + w14.ToString() + ","
        mysql = mysql + "w1dx = " + w15.ToString() + ","
        mysql = mysql + "w1dy = " + w16.ToString() + ","
        mysql = mysql + "w2x = " + w21.ToString() + ","
        mysql = mysql + "w2y = " + w22.ToString() + ","
        mysql = mysql + "w2w = " + w23.ToString() + ","
        mysql = mysql + "w2h = " + w24.ToString() + ","
        mysql = mysql + "w2dx = " + w25.ToString() + ","
        mysql = mysql + "w2dy = " + w26.ToString() + ","
        mysql = mysql + "hx = " + hl1.ToString() + ","
        mysql = mysql + "hy = " + hl2.ToString() + ","
        mysql = mysql + "hw = " + hl3.ToString() + ","
        mysql = mysql + "hh = " + hl4.ToString() + ","
        mysql = mysql + "hdx = " + hl5.ToString() + ","
        mysql = mysql + "hdy = " + hl6.ToString()

        mysql = mysql + " where fieldnr = " + fnr

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()


    End Sub

End Class