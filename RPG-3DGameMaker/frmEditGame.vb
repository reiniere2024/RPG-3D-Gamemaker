Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmEditGame
    Public dsGames As New DataSet

    Private Sub frmEditGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)

        Me.LoadGames()
        Me.FillListbox()

    End Sub

    Private Sub FillListbox()
        Dim gnr, gname As String

        lbGames.Items.Clear()
        For i = 0 To dsGames.Tables(0).Rows.Count - 1

            gnr = dsGames.Tables(0).Rows(i).Item(0)
            gname = dsGames.Tables(0).Rows(i).Item(1)
            lbGames.Items.Add(gnr + "-" + gname)

        Next

    End Sub

    Private Sub LoadGames()
        Dim mysql As String
        Dim mystring As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection

        dsGames.Reset()
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        da = New OleDbDataAdapter
        mysql = "select * from Game order by gamenr"

        da.SelectCommand = New OleDbCommand(mysql, myconnection1)
        myconnection1.Open()

        da.Fill(dsGames, "Game")


    End Sub

    Private Sub lbGames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbGames.SelectedIndexChanged

        Dim selected As String
        Dim ind As Integer
        Dim gamenr, char1, char2, char3 As String

        selected = lbGames.Text
        char1 = selected.Substring(0, 1)
        gamenr = char1
        char2 = selected.Substring(1, 1)
        If char2 = "-" Then
            'continue
        Else
            gamenr = gamenr + char2
            char3 = selected.Substring(2, 1)
            If char3 = "-" Then
                'continue
            Else
                gamenr = gamenr + char3
            End If
        End If
        ind = CInt(gamenr)
        txtGame.Text = dsGames.Tables(0).Rows(ind - 1).Item(0)
        txtName.Text = dsGames.Tables(0).Rows(ind - 1).Item(1)
        txtDescription.Text = dsGames.Tables(0).Rows(ind - 1).Item(2)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim gamenr, gamename, description, mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        gamenr = txtGame.Text
        gamename = txtName.Text
        description = txtDescription.Text
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Update Game set gamename = '" + gamename + "',description = '" + description + "' where gamenr = " + gamenr.ToString()

        Try
            mycommand = New OleDbCommand
            mycommand.CommandText = mysql
            mycommand.Connection = myconnection1
            myconnection1.Open()
            mycommand.ExecuteNonQuery()

            MsgBox("Game information is updated succesfully !!!")
            Me.LoadGames()
            Me.FillListbox()
            lbGames.Text = ""


        Catch ex As Exception

            MsgBox("Error updating game !!!")
        End Try


    End Sub
End Class