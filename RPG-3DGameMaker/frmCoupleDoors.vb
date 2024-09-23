Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmCoupleDoors
    Public dsDoors As New DataSet
    Public dsWallitems As New DataSet
    Public Gameid As Integer = 1

    Private Sub frmCoupleDoors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New Point(0, 0)

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim itemstr, itemstring, curmap, curitem As String
        Dim lvl, x, y, ind, MyItem As Integer

        Gameid = CInt(txtGame.Text)
        Me.SelectDoors(Gameid)
        For i = 0 To dsDoors.Tables(0).Rows.Count - 1
            itemstr = "L" + dsDoors.Tables(0).Rows(i).Item(3).ToString()
            itemstr = itemstr + ",X:" + dsDoors.Tables(0).Rows(i).Item(4).ToString()
            itemstr = itemstr + ",Y:" + dsDoors.Tables(0).Rows(i).Item(5).ToString()
            'lbDoors2.Items.Add(itemstr)
            lvl = dsDoors.Tables(0).Rows(i).Item(7).ToString()
            x = dsDoors.Tables(0).Rows(i).Item(8).ToString()
            y = dsDoors.Tables(0).Rows(i).Item(9).ToString()
            If lvl = 0 Then
                itemstr = itemstr + "-uncoupled"
            Else
                itemstr = itemstr + "-TL" + lvl.ToString()
                itemstr = itemstr + ",TX:" + x.ToString()
                itemstr = itemstr + ",TY:" + y.ToString()
            End If
            lbDoors1.Items.Add(itemstr)
        Next
        Me.Refresh()
        itemstr = ""
        For i = 0 To dsWallitems.Tables(0).Rows.Count - 1
            curmap = dsWallitems.Tables(0).Rows(i).Item(2)
            'find the possible locks on the map
            itemstring = Me.GetItemstring(Gameid, curmap)
            ind = 0
            For y = 1 To 32
                For x = 1 To 32
                    curitem = itemstring.Substring(ind, 3)
                    MyItem = CInt(curitem)
                    If MyItem > 50 And MyItem < 101 Then 'Keylock Item
                        lvl = curmap
                        itemstr = "KL" + lvl.ToString()
                        itemstr = itemstr + ",KX:" + x.ToString()
                        itemstr = itemstr + ",KY:" + y.ToString()
                        lbItems.Items.Add(itemstr)
                    End If
                    ind = ind + 4 'skip the , character
                Next
                'ind = ind + 2 'skip the vbcrlf characters
            Next
            Me.Refresh()

        Next

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



    Private Sub SelectDoors(ByVal gamenr As Integer)
        Dim mysql As String
        Dim mystring As String
        Dim da1, da2 As DbDataAdapter
        Dim myconnection1 As DbConnection

        dsDoors.Reset()
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        da1 = New OleDbDataAdapter
        mysql = "select * from Doors where gameid = " + gamenr.ToString() + " order by doornr"

        da1.SelectCommand = New OleDbCommand(mysql, myconnection1)
        myconnection1.Open()

        da1.Fill(dsDoors, "Doors")

        da2 = New OleDbDataAdapter
        mysql = "select * from Wallitems where gameid = " + gamenr.ToString() + " order by gameid,mapnr"

        da2.SelectCommand = New OleDbCommand(mysql, myconnection1)
        da2.Fill(dsWallitems, "Wallitems")
        myconnection1.Close()



    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim str1, MyResults As String
        Dim ind1, ind2, start1, index1, index2 As Integer
        Dim itemstr, lenStr, kl, kx, ky As String
        Dim lvl, x, y As Integer

        str1 = lbDoors1.Text
        ind1 = lbDoors1.Items.IndexOf(str1)

        MyResults = lbItems.Text
        ind2 = lbItems.Items.IndexOf(MyResults)

        'read values lvl,x,y from lblItems.text
        lenStr = MyResults.Length
        index1 = 1
        start1 = 1
        index2 = MyResults.IndexOf(",", start1)
        kl = MyResults.Substring(2, index2 - index1 - 1)
        index1 = index2 + 4
        start1 = index1
        index2 = MyResults.IndexOf(",", start1)
        kx = MyResults.Substring(index1, index2 - index1)
        index1 = index2 + 4
        ky = MyResults.Substring(index1, lenStr - index1)

        'Change values in Dataset
        dsDoors.Tables(0).Rows(ind1).Item(7) = kl
        dsDoors.Tables(0).Rows(ind1).Item(8) = kx
        dsDoors.Tables(0).Rows(ind1).Item(9) = ky

        'Change values in Listbox
        itemstr = "L" + dsDoors.Tables(0).Rows(ind1).Item(3).ToString()
        itemstr = itemstr + ",X:" + dsDoors.Tables(0).Rows(ind1).Item(4).ToString()
        itemstr = itemstr + ",Y:" + dsDoors.Tables(0).Rows(ind1).Item(5).ToString()
        lvl = dsDoors.Tables(0).Rows(ind1).Item(7).ToString()
        x = dsDoors.Tables(0).Rows(ind1).Item(8).ToString()
        y = dsDoors.Tables(0).Rows(ind1).Item(9).ToString()
        itemstr = itemstr + "-TL" + lvl.ToString()
        itemstr = itemstr + ",TX:" + x.ToString()
        itemstr = itemstr + ",TY:" + y.ToString()
        lbDoors1.Items(ind1) = itemstr

        'MsgBox(i.ToString())

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim lvl, x, y As Integer
        Dim doornr As Integer


        For i = 0 To dsDoors.Tables(0).Rows.Count - 1
            doornr = dsDoors.Tables(0).Rows(i).Item(1)
            lvl = dsDoors.Tables(0).Rows(i).Item(7)
            x = dsDoors.Tables(0).Rows(i).Item(8)
            y = dsDoors.Tables(0).Rows(i).Item(9)
            Me.UpdateDoors(doornr, lvl, x, y)
            'If lvl > 0 Then
            '    Me.UpdateDoors(doornr, lvl, x, y)
            'End If
        Next
        MsgBox("The Coupled Doors Information has been saved !")


    End Sub

    Private Sub UpdateDoors(ByVal door As Integer, ByVal lvl As Integer, ByVal x As Integer, ByVal y As Integer)

        Dim mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Update Doors set locklevel = " + lvl.ToString() + ",lockposx = " + x.ToString() + ",lockposy = " + y.ToString() + " where gameid = " + Gameid.ToString() + " and doornr = " + door.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim str1 As String
        Dim ind1 As Integer
        Dim itemstr As String

        str1 = lbDoors1.Text
        ind1 = lbDoors1.Items.IndexOf(str1)

        'Change values in Dataset
        dsDoors.Tables(0).Rows(ind1).Item(7) = 0
        dsDoors.Tables(0).Rows(ind1).Item(8) = 0
        dsDoors.Tables(0).Rows(ind1).Item(9) = 0

        'Change values in Listbox
        itemstr = "L" + dsDoors.Tables(0).Rows(ind1).Item(3).ToString()
        itemstr = itemstr + ",X:" + dsDoors.Tables(0).Rows(ind1).Item(4).ToString()
        itemstr = itemstr + ",Y:" + dsDoors.Tables(0).Rows(ind1).Item(5).ToString()
        itemstr = itemstr + "-uncoupled"
        lbDoors1.Items(ind1) = itemstr

    End Sub
End Class