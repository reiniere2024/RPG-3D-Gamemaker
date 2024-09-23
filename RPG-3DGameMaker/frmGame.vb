Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmGame


    Private Sub frmGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gnr As Integer

        Me.Location = New Point(0, 0)
        gnr = Me.CheckGame()
        txtGame.Text = gnr.ToString()


    End Sub

    Public Function CheckGame() As Integer
        Dim mysql As String
        Dim rc As Integer
        Dim mystring As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "select count(*) from Game"

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        rc = mycommand.ExecuteScalar()
        Return rc + 1

    End Function


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

        mysql = "Insert into Game values ( " + gamenr + ",'" + gamename + "','" + description + "')"

        Try
            mycommand = New OleDbCommand
            mycommand.CommandText = mysql
            mycommand.Connection = myconnection1
            myconnection1.Open()
            mycommand.ExecuteNonQuery()

            MsgBox("New Game is inserted succesfully !!!")

        Catch ex As Exception

            MsgBox("Error inserting new game !!!")
        End Try

        Me.Close()



    End Sub
End Class