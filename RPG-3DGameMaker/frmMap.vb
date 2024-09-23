Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmMap
    Public dsMaps As New DataSet
    Public Gameid As Integer = 1
    Public curmap As Integer
    Public CurItem As Integer = 1


    Private Sub frmMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim game As Integer

        Me.Location = New Point(0, 0)
        game = CInt(txtGame.Text)
        Gameid = game
        Me.SelectMaps(game)
        Me.MapsToArray()


    End Sub




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim mysql, mapstr, map, curitem As String
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand
        Dim ind As Integer = 0

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mapstr = txtMap.Text
        map = ""

        For y = 1 To 32
            For x = 1 To 32
                curitem = mapstr.Substring(ind, 1)
                map = map + curitem + ","
                ind = ind + 2 'skip the , character
            Next
            ind = ind + 2 'skip the vbcrlf characters
        Next

        mysql = "Update Maps set themap = '" + map + "' where gameid = " + Gameid.ToString() + " and mapnr = " + curmap.ToString()

        Try

            mycommand = New OleDbCommand
            mycommand.CommandText = mysql
            mycommand.Connection = myconnection1
            myconnection1.Open()
            mycommand.ExecuteNonQuery()

            MsgBox("The Game map has been saved succesfully !")

            'Get the new maps
            Me.SelectMaps(Gameid)
            Me.MapsToArray()


        Catch ex As Exception

            MsgBox("Error while saving the Game map !")

        End Try


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

    Private Sub c_level_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c_level.SelectedIndexChanged

        Dim mapstr, screenstr, curitem, selected As String
        Dim ind As Integer
        selected = c_level.Text


        curmap = GetLevel(selected)
        screenstr = ""
        mapstr = Me.GetMapstring(Gameid, curmap)
        For y = 1 To 32
            For x = 1 To 32
                curitem = mapstr.Substring(ind, 1)
                screenstr = screenstr + curitem + ","
                ind = ind + 2 'skip the , character
            Next
            screenstr = screenstr + vbCrLf
            'ind = ind + 2 'skip the vbcrlf characters
        Next
        txtMap.Text = screenstr

    End Sub

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

    Private Sub txtGame_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGame.TextChanged

    End Sub
End Class