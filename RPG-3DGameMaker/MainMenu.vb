Public Class MainMenu

    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click

        Dim myform As New frmGame
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub EditGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditGameToolStripMenuItem.Click

        Dim myform As New frmEditGame
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub MakeGameMapsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeGameMapsToolStripMenuItem.Click

        Dim myform As New frmMakeMaps
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub NumericMapsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericMapsToolStripMenuItem.Click
        Dim myform As New frmMap
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub NumericItemsOnMapsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericItemsOnMapsToolStripMenuItem.Click

        Dim myform As New frmItem
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub PutItemsOnMapsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PutItemsOnMapsToolStripMenuItem.Click

        Dim myform As New frmMapItems
        myform.MdiParent = Me
        myform.Show()


    End Sub


    Private Sub ItemsOnWallsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsOnWallsToolStripMenuItem.Click

        Dim myform As New frmWallItems
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub CoupleTrepsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoupleTrepsToolStripMenuItem.Click

        Dim myform As New frmCoupleTreps
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub GenerateTrepsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateTrepsToolStripMenuItem.Click

        Dim myform As New frmGenerateTreps
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub GenerateDoorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateDoorsToolStripMenuItem.Click

        Dim myform As New frmGenerateDoors
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub CoupleDoorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoupleDoorsToolStripMenuItem.Click

        Dim myform As New frmCoupleDoors
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub KeysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeysToolStripMenuItem.Click

        Dim myform As New frmKeys
        myform.MdiParent = Me
        myform.Show()

    End Sub


    Private Sub KeylocksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeylocksToolStripMenuItem.Click

        Dim myform As New frmKeyLocks
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub ClothesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClothesToolStripMenuItem.Click

        Dim myform As New frmClothes
        myform.MdiParent = Me
        myform.Show()


    End Sub

    Private Sub WeaponsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeaponsToolStripMenuItem.Click

        Dim myform As New frmWeapons
        myform.MdiParent = Me
        myform.Show()


    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click

        Dim myform As New frmMageSpells
        myform.MdiParent = Me
        myform.Show()

    End Sub


    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click

        Dim myform As New frmClericSpells
        myform.MdiParent = Me
        myform.Show()

    End Sub


    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click

        Dim myform As New frmDefineWallItems
        myform.MdiParent = Me
        myform.Show()
 

    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click

        Dim myform As New frmEffects
        myform.MdiParent = Me
        myform.Show()

    End Sub


    Private Sub MiscellaneousToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MiscellaneousToolStripMenuItem.Click

        Dim myform As New frmMisc
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click

        Dim myform As New frmDoorTypes
        myform.MdiParent = Me
        myform.Show()

    End Sub



    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click

        Dim myform As New frmStairTypes
        myform.MdiParent = Me
        myform.Show()


    End Sub

    Private Sub MainWallsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainWallsToolStripMenuItem.Click

        Dim myform As New frmWalls
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub SideWallsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SideWallsToolStripMenuItem.Click

        Dim myform As New frmSideWalls
        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub BackDropsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackDropsToolStripMenuItem.Click

        Dim myform As New frmBackdrops
        myform.MdiParent = Me
        myform.Show()

    End Sub


    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click

        Dim myform As New frmGameField

        myform.MdiParent = Me
        myform.Show()

    End Sub

    Private Sub MonstersOnMapsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonstersOnMapsToolStripMenuItem.Click

        Dim myform As New frmMapMonsters
        myform.MdiParent = Me
        myform.Show()


    End Sub

    Private Sub DefineMonstersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefineMonstersToolStripMenuItem.Click

        Dim myform As New frmMonsters
        myform.MdiParent = Me
        myform.Show()

    End Sub


End Class