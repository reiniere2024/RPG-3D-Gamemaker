Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmGenerateTreps
    Public dsMaps As New DataSet
    Public Gameid As Integer = 1
    Public Mapnr As Integer = 0

    Private Sub frmGenerateTreps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        lbStairs1.Items.Clear()
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
                    If theitem = 5 Or theitem = 6 Then
                        itemstr = "L" + Mapnr.ToString()
                        itemstr = itemstr + ",X:" + x.ToString()
                        itemstr = itemstr + ",Y:" + y.ToString()
                        lbStairs1.Items.Add(itemstr)
                    End If
                    ind = ind + 2 'skip the , character
                Next
            Next

        Next



    End Sub

    Private Sub ClearAllStairs(ByVal Gameid As Integer)

        Dim mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Delete * from Stairs where gameid = " + Gameid.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()

    End Sub

    Private Sub SaveTrep(ByVal Gameid As Integer, ByVal stairsnr As Integer, ByVal gamenr As Integer, ByVal x As Integer, ByVal y As Integer)

        Dim mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Insert into Stairs values (" + Gameid.ToString() + "," + stairsnr.ToString() + ",1," + gamenr.ToString() + "," + x.ToString() + "," + y.ToString() + ",0,0,0)"

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()

    End Sub




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim themap, curitem, itemstr As String
        Dim ind, theitem, stairsnr As Integer

        lbStairs2.Items.Clear()
        Me.ClearAllStairs(Gameid)
        Gameid = CInt(txtGame.Text)
        stairsnr = 1
        Me.SelectMaps(Gameid)
        For i = 0 To dsMaps.Tables(0).Rows.Count - 1
            mapnr = dsMaps.Tables(0).Rows(i).Item(2)
            themap = dsMaps.Tables(0).Rows(i).Item(5)
            ind = 0
            itemstr = ""
            For y = 1 To 32
                For x = 1 To 32
                    curitem = themap.Substring(ind, 1)
                    theitem = CInt(curitem)
                    If theitem = 5 Or theitem = 6 Then
                        'Save the trep in Stairs table
                        Me.SaveTrep(Gameid, stairsnr, Mapnr, x, y)
                        itemstr = "L" + Mapnr.ToString()
                        itemstr = itemstr + ",X:" + x.ToString()
                        itemstr = itemstr + ",Y:" + y.ToString()
                        lbStairs2.Items.Add(itemstr)
                        stairsnr = stairsnr + 1
                        Me.Refresh()

                    End If
                    ind = ind + 2 'skip the , character
                Next
            Next

        Next



    End Sub
End Class