Public Class MainWindow

    Public MyPictures(1024) As PictureBox
    Public MyFields(1024) As Integer
    Public ds As New DataSet

    Public StartX As Integer = 300
    Public StartY As Integer = 30
    Public PicWidth As Integer = 20
    Public WinHeight As Integer = 720
    Public WinWidth As Integer = 1000

    Public LevelSelectedMap As Integer = -1
    Public EmptyImage As String = "picts\empty.jpg"
    Public RoadImage As String = "picts\road.jpg"
    Public StartImage As String = "picts\start.jpg"
    Public StairsImage As String = "picts\stairs.jpg"
    Public CurrentImage As String = "picts\current.jpg"
    Public NewImage As String = "picts\new.jpg"

    Public GameFolder As String = ""
    Public CurrentClicked As Integer = 0
    Public CurrentClickedTag As Integer = 0

    Private Sub MainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Width = WinWidth
        Me.Height = WinHeight
        Me.Location = New Point(0, 0)

        'Read Game Settings in EOB.XML
        ds.ReadXml(CurDir() + "\xml\eob2.xml")
        GameFolder = ds.Tables(0).Rows(0).Item(0)

        Me.CreateControls()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub c_level_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c_level.SelectedIndexChanged

        Dim str As String

        str = c_level.Text

        Select Case str
            Case "00  - Wood"
                Me.FillMaps(1)
                Me.InitializeFields()
                LevelSelectedMap = 0
                t_level2.Text = "0"
                t_lvlname2.Text = "Wood Level"
            Case "01 - Catacombs 1"
                Me.FillMaps(2)
                Me.InitializeFields()
                LevelSelectedMap = 1
                t_lvlname2.Text = "Catacomb Level 1"
            Case "02 - Catacombs 2"
                Me.FillMaps(3)
                Me.InitializeFields()
                LevelSelectedMap = 2
                t_lvlname2.Text = "Catacomb Level 2"
            Case "03 - Catacombs 3"
                Me.FillMaps(4)
                Me.InitializeFields()
                LevelSelectedMap = 3
                t_lvlname2.Text = "Catacomb Level 3"
            Case "04 - Catacombs 4"
                Me.FillMaps(5)
                Me.InitializeFields()
                LevelSelectedMap = 4
                t_lvlname2.Text = "Catacomb Level 4"
            Case "05 - Temple 1"
                Me.FillMaps(6)
                Me.InitializeFields()
                LevelSelectedMap = 5
                t_lvlname2.Text = "Temple Level 1"
            Case "06 - Temple 2"
                Me.FillMaps(7)
                Me.InitializeFields()
                LevelSelectedMap = 6
                t_lvlname2.Text = "Temple Level 2"
            Case "07 - Silver Tower 1"
                Me.FillMaps(8)
                Me.InitializeFields()
                LevelSelectedMap = 7
                t_lvlname2.Text = "Silver Tower Level 1"
            Case "08 - Silver Tower 2"
                Me.FillMaps(9)
                Me.InitializeFields()
                LevelSelectedMap = 8
                t_lvlname2.Text = "Silver Tower Level 2"
            Case "09 - Silver Tower 3"
                Me.FillMaps(10)
                Me.InitializeFields()
                LevelSelectedMap = 9
                t_lvlname2.Text = "Silver Tower Level 3"
            Case "10 - Azure Tower 1"
                Me.FillMaps(11)
                Me.InitializeFields()
                LevelSelectedMap = 10
                t_lvlname2.Text = "Azure Tower Level 1"
            Case "11 - Azure Tower 2"
                Me.FillMaps(12)
                Me.InitializeFields()
                LevelSelectedMap = 11
                t_lvlname2.Text = "Azure Tower Level 2"
            Case "12 - Azure Tower 3"
                Me.FillMaps(13)
                Me.InitializeFields()
                LevelSelectedMap = 12
                t_lvlname2.Text = "Azure Tower Level 3"
            Case "13 - Azure Tower 4"
                Me.FillMaps(14)
                Me.InitializeFields()
                LevelSelectedMap = 13
                t_lvlname2.Text = "Azure Tower Level 4"
            Case "14 - Frost Giants"
                Me.FillMaps(15)
                Me.InitializeFields()
                LevelSelectedMap = 14
                t_lvlname2.Text = "Frost Giants Level"
            Case "15 - Crimson Tower 1"
                Me.FillMaps(16)
                Me.InitializeFields()
                LevelSelectedMap = 15
                t_lvlname2.Text = "Crimson Tower Level 1"
            Case "16 - Crimson Tower 2"
                Me.FillMaps(17)
                Me.InitializeFields()
                LevelSelectedMap = 16
                t_lvlname2.Text = "Crimson Tower Level 2"
        End Select
        t_level2.Text = LevelSelectedMap.ToString()

    End Sub

    Public Sub FillMaps(ByVal mapnr As Integer)

        Select Case mapnr
            Case 1
                For i = 0 To 1023
                    MyFields(i) = MyFields1(i)
                Next
            Case 2
                For i = 0 To 1023
                    MyFields(i) = MyFields2(i)
                Next
            Case 3
                For i = 0 To 1023
                    MyFields(i) = MyFields3(i)
                Next
            Case 4
                For i = 0 To 1023
                    MyFields(i) = MyFields4(i)
                Next
            Case 5
                For i = 0 To 1023
                    MyFields(i) = MyFields5(i)
                Next
            Case 6
                For i = 0 To 1023
                    MyFields(i) = MyFields6(i)
                Next
            Case 7
                For i = 0 To 1023
                    MyFields(i) = MyFields7(i)
                Next
            Case 8
                For i = 0 To 1023
                    MyFields(i) = MyFields8(i)
                Next
            Case 9
                For i = 0 To 1023
                    MyFields(i) = MyFields9(i)
                Next
            Case 10
                For i = 0 To 1023
                    MyFields(i) = MyFields10(i)
                Next
            Case 11
                For i = 0 To 1023
                    MyFields(i) = MyFields11(i)
                Next
            Case 12
                For i = 0 To 1023
                    MyFields(i) = MyFields12(i)
                Next
            Case 13
                For i = 0 To 1023
                    MyFields(i) = MyFields13(i)
                Next
            Case 14
                For i = 0 To 1023
                    MyFields(i) = MyFields14(i)
                Next
            Case 15
                For i = 0 To 1023
                    MyFields(i) = MyFields15(i)
                Next
            Case 16
                For i = 0 To 1023
                    MyFields(i) = MyFields16(i)
                Next
            Case 17
                For i = 0 To 1023
                    MyFields(i) = MyFields17(i)
                Next


        End Select


    End Sub

    Public Sub InitializeFields()

        For i As Integer = 0 To 1023
            MyPictures(i).Image = Image.FromFile(EmptyImage)
        Next

        For i As Integer = 0 To 1023

            If MyFields(i) <> 0 Then
                Me.AddImage(i, MyFields(i))
            End If

        Next

    End Sub

    Public Sub AddImage(ByVal pict As Integer, ByVal pictnum As Integer)

        Select Case pictnum

            Case 0
                MyPictures(pict).Image = Image.FromFile(EmptyImage)
                MyPictures(pict).Tag = "0"

            Case 1
                MyPictures(pict).Image = Image.FromFile(RoadImage)
                MyPictures(pict).Tag = "1"

            Case 2
                MyPictures(pict).Image = Image.FromFile(EmptyImage)
                'MyPictures(pict).Image = Image.FromFile(StartImage)
                MyPictures(pict).Tag = "2"

            Case 5
                MyPictures(pict).Image = Image.FromFile(StairsImage)
                MyPictures(pict).Tag = "5"

        End Select

        'MyPictures(pict).Image = Image.FromFile("picts\road01.jpg")

    End Sub

    Public Sub CreateControls()
        Dim l As Point

        l.X = StartX
        l.Y = StartY

        For i As Integer = 0 To 1023
            l.X = l.X + PicWidth

            Dim myTB As PictureBox
            Me.MyPictures(i) = New PictureBox
            myTB = MyPictures(i)
            myTB.Image = Image.FromFile(EmptyImage)
            myTB.Tag = "0"
            myTB.Width = PicWidth
            myTB.Height = PicWidth
            myTB.Location = l
            myTB.Name = "PB" + i.ToString  ' <- important for later accessing
            'myTB.SizeMode = PictureBoxSizeMode.StretchImage
            Me.Controls.Add(myTB)
            AddHandler MyPictures(i).Click, AddressOf Me.ClickButton

            If ((i + 1) Mod 32) = 0 Then
                l.Y = l.Y + PicWidth
                l.X = StartX

            End If


        Next

        'AddHandler MyPictures(0).Click, AddressOf Me.ClickButton



    End Sub

    Private Sub ClickButton(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim str As String
        Dim ind As Integer
        Dim btn As PictureBox
        btn = CType(sender, PictureBox)

        str = btn.Name
        str = str.Substring(2, str.Length - 2)
        ind = CInt(str)
        If CurrentClicked > 0 Then
            Me.AddImage(CurrentClicked, CurrentClickedTag)
        End If
        CurrentClicked = ind
        CurrentClickedTag = MyPictures(CurrentClicked).Tag
        MyPictures(CurrentClicked).Image = Image.FromFile(NewImage)
        t_position2.Text = CurrentClicked.ToString()


        'MsgBox("you clicked button: " + str)


    End Sub

End Class
