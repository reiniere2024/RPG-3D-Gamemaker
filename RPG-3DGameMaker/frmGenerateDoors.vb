Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmGenerateDoors
    Public dsMaps As New DataSet
    Public Gameid As Integer = 1
    Public Mapnr As Integer = 0

    Private Sub frmGenerateDoors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)

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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim themap, curitem, itemstr As String
        Dim ind, theitem As Integer

        lbDoors1.Items.Clear()
        Gameid = CInt(txtGame.Text)
        Me.SelectMaps(Gameid)
        For i = 0 To dsMaps.Tables(0).Rows.Count - 1
            Mapnr = dsMaps.Tables(0).Rows(i).Item(2)
            themap = dsMaps.Tables(0).Rows(i).Item(5)
            ind = 0
            itemstr = ""
            For y = 1 To 32
                For x = 1 To 32
                    curitem = themap.Substring(ind, 1)
                    theitem = CInt(curitem)
                    If theitem = 7 Or theitem = 8 Then
                        itemstr = "L" + Mapnr.ToString()
                        itemstr = itemstr + ",X:" + x.ToString()
                        itemstr = itemstr + ",Y:" + y.ToString()
                        lbDoors1.Items.Add(itemstr)
                    End If
                    ind = ind + 2 'skip the , character
                Next
            Next

        Next


    End Sub

    Private Sub ClearAllDoors(ByVal Gameid As Integer)

        Dim mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Delete * from Doors where gameid = " + Gameid.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()

    End Sub

    Private Sub SaveDoor(ByVal Gameid As Integer, ByVal doornr As Integer, ByVal gamenr As Integer, ByVal x As Integer, ByVal y As Integer)

        Dim mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Insert into Doors values (" + Gameid.ToString() + "," + doornr.ToString() + ",1," + gamenr.ToString() + "," + x.ToString() + "," + y.ToString() + ",1,0,0,0,0,0,0,0)"

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim themap, curitem, itemstr As String
        Dim ind, theitem, doorsnr As Integer

        lbDoors2.Items.Clear()
        Me.ClearAllDoors(Gameid)
        Gameid = CInt(txtGame.Text)
        doorsnr = 1
        Me.SelectMaps(Gameid)
        For i = 0 To dsMaps.Tables(0).Rows.Count - 1
            Mapnr = dsMaps.Tables(0).Rows(i).Item(2)
            themap = dsMaps.Tables(0).Rows(i).Item(5)
            ind = 0
            itemstr = ""
            For y = 1 To 32
                For x = 1 To 32
                    curitem = themap.Substring(ind, 1)
                    theitem = CInt(curitem)
                    If theitem = 7 Or theitem = 8 Then
                        'Save the door in Doors table
                        Me.SaveDoor(Gameid, doorsnr, Mapnr, x, y)
                        itemstr = "L" + Mapnr.ToString()
                        itemstr = itemstr + ",X:" + x.ToString()
                        itemstr = itemstr + ",Y:" + y.ToString()
                        lbDoors2.Items.Add(itemstr)
                        doorsnr = doorsnr + 1
                        Me.Refresh()

                    End If
                    ind = ind + 2 'skip the , character
                Next
            Next

        Next

    End Sub
End Class