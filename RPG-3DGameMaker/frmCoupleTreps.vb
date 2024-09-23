Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common

Public Class frmCoupleTreps
    Public dsTreps As New DataSet
    Public Gameid As Integer = 1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim itemstr As String
        Dim lvl, x, y As Integer

        Gameid = CInt(txtGame.Text)
        Me.SelectStairs(Gameid)
        For i = 0 To dsTreps.Tables(0).Rows.Count - 1
            itemstr = "L" + dsTreps.Tables(0).Rows(i).Item(3).ToString()
            itemstr = itemstr + ",X:" + dsTreps.Tables(0).Rows(i).Item(4).ToString()
            itemstr = itemstr + ",Y:" + dsTreps.Tables(0).Rows(i).Item(5).ToString()
            lbStairs2.Items.Add(itemstr)
            lvl = dsTreps.Tables(0).Rows(i).Item(6).ToString()
            x = dsTreps.Tables(0).Rows(i).Item(7).ToString()
            y = dsTreps.Tables(0).Rows(i).Item(8).ToString()
            If lvl = 0 Then
                itemstr = itemstr + "-uncoupled"
            Else
                itemstr = itemstr + "-TL" + lvl.ToString()
                itemstr = itemstr + ",TX:" + x.ToString()
                itemstr = itemstr + ",TY:" + y.ToString()
            End If
            lbStairs1.Items.Add(itemstr)

        Next


    End Sub

    Private Sub SelectStairs(ByVal gamenr As Integer)
        Dim mysql As String
        Dim mystring As String
        Dim da As DbDataAdapter
        Dim myconnection1 As DbConnection

        dsTreps.Reset()
        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        da = New OleDbDataAdapter
        mysql = "select * from Stairs where gameid = " + gamenr.ToString() + " order by trepnr"

        da.SelectCommand = New OleDbCommand(mysql, myconnection1)
        myconnection1.Open()

        da.Fill(dsTreps, "Stairs")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim str1, str2 As String
        Dim ind1, ind2 As Integer
        Dim itemstr As String
        Dim lvl, x, y As Integer

        str1 = lbStairs1.Text
        ind1 = lbStairs1.Items.IndexOf(str1)

        str2 = lbStairs2.Text
        ind2 = lbStairs2.Items.IndexOf(str2)

        'Change values in Dataset
        dsTreps.Tables(0).Rows(ind1).Item(6) = dsTreps.Tables(0).Rows(ind2).Item(3)
        dsTreps.Tables(0).Rows(ind1).Item(7) = dsTreps.Tables(0).Rows(ind2).Item(4)
        dsTreps.Tables(0).Rows(ind1).Item(8) = dsTreps.Tables(0).Rows(ind2).Item(5)
        'Change values in Listbox
        itemstr = "L" + dsTreps.Tables(0).Rows(ind1).Item(3).ToString()
        itemstr = itemstr + ",X:" + dsTreps.Tables(0).Rows(ind1).Item(4).ToString()
        itemstr = itemstr + ",Y:" + dsTreps.Tables(0).Rows(ind1).Item(5).ToString()

        lvl = dsTreps.Tables(0).Rows(ind1).Item(6).ToString()
        x = dsTreps.Tables(0).Rows(ind1).Item(7).ToString()
        y = dsTreps.Tables(0).Rows(ind1).Item(8).ToString()
        itemstr = itemstr + "-TL" + lvl.ToString()
        itemstr = itemstr + ",TX:" + x.ToString()
        itemstr = itemstr + ",TY:" + y.ToString()
        lbStairs1.Items(ind1) = itemstr

        'MsgBox(i.ToString())



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim lvl, x, y As Integer
        Dim trepnr As Integer


        For i = 0 To dsTreps.Tables(0).Rows.Count - 1
            trepnr = dsTreps.Tables(0).Rows(i).Item(1)
            lvl = dsTreps.Tables(0).Rows(i).Item(6)
            x = dsTreps.Tables(0).Rows(i).Item(7)
            y = dsTreps.Tables(0).Rows(i).Item(8)
            Me.UpdateStairs(trepnr, lvl, x, y)
            'If lvl > 0 Then
            '    Me.UpdateStairs(trepnr, lvl, x, y)
            'End If
        Next
        MsgBox("The Coupled Stairs Information has been saved !")


    End Sub

    Private Sub UpdateStairs(ByVal trep As Integer, ByVal lvl As Integer, ByVal x As Integer, ByVal y As Integer)

        Dim mystring As String
        Dim mysql As String
        Dim myconnection1 As DbConnection
        Dim mycommand As DbCommand

        mystring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='Database\RPGGamemaker.mdb';Jet OLEDB:Database Password=Tapyxe01"
        myconnection1 = New OleDbConnection(mystring)

        mysql = "Update Stairs set target = " + lvl.ToString() + ",tposx = " + x.ToString() + ",tposy = " + y.ToString() + " where gameid = " + Gameid.ToString() + " and trepnr = " + trep.ToString()

        mycommand = New OleDbCommand
        mycommand.CommandText = mysql
        mycommand.Connection = myconnection1
        myconnection1.Open()
        mycommand.ExecuteNonQuery()
        myconnection1.Close()

    End Sub


    Private Sub frmCoupleTreps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim str1 As String
        Dim ind1 As Integer
        Dim itemstr As String

        str1 = lbStairs1.Text
        ind1 = lbStairs1.Items.IndexOf(str1)

        'Change values in Dataset
        dsTreps.Tables(0).Rows(ind1).Item(6) = 0
        dsTreps.Tables(0).Rows(ind1).Item(7) = 0
        dsTreps.Tables(0).Rows(ind1).Item(8) = 0
        'Change values in Listbox
        itemstr = "L" + dsTreps.Tables(0).Rows(ind1).Item(3).ToString()
        itemstr = itemstr + ",X:" + dsTreps.Tables(0).Rows(ind1).Item(4).ToString()
        itemstr = itemstr + ",Y:" + dsTreps.Tables(0).Rows(ind1).Item(5).ToString()
        itemstr = itemstr + "-uncoupled"
        lbStairs1.Items(ind1) = itemstr


    End Sub
End Class