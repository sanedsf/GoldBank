Public Class Main

    ''Author: AnaRchX
    ''Country: Greece
    ''Description: Pathfinder Gold metrics and Information Panel.
    ''Designer: AnaRchX
    ''Coder: AnaRchx
    ''Special Thanks: Oblivionaire, Kesidhs

    Dim cop As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0}
    Dim silv As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0}
    Dim gold As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0}
    Dim plat As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0}
    Public copperpiece As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0}
    Public silverpiece As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0}
    Public goldpiece As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0}
    Public platinumpiece As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0}
    Public save1 As String()
    Public load1 As String()
    Dim dicepic As String()
    Dim httppath As String()
    Dim buttons As Button()
    Public path As String = My.Application.Info.DirectoryPath & "\Resources\"

    Private Sub Form1_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        My.Settings.Save()
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Activate()
        CopperPic.Image = Image.FromFile(path & "coppercoin.png")
        SilverPic.Image = Image.FromFile(path & "silvercoin.png")
        GoldPic.Image = Image.FromFile(path & "goldcoin.png")
        PlatinumPic.Image = Image.FromFile(path & "platinumcoin.png")
        buttons = {d4btn, d6btn, d8btn, d10btn, d12btn, d20btn}
        dicepic = {"d4", "d6", "d8", "d10", "d12", "d20"}
        Playername.Text = ""
        Try
            For f As Integer = 0 To buttons.Length - 1 Step 1
                buttons(f).Text = ""
                buttons(f).BackgroundImage = Image.FromFile(path & dicepic(f) & ".png")
            Next
        Catch ex As Exception
            For f As Integer = 0 To buttons.Length - 1 Step 1
                buttons(f).Text = dicepic(f)
            Next
        End Try
        If My.Settings.splashscreen = True Then
            OnToolStripMenuItem.Checked = True
            OffToolStripMenuItem.Checked = False
        Else
            OnToolStripMenuItem.Checked = False
            OffToolStripMenuItem.Checked = True
        End If
        load1 = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", _
                 "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", _
                 "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " ", "-"}
        save1 = {"☺", "☻", "♥", "♦", "♣", "♠", "•", "◘", "○", "◙", "♂", "♀", "♪", "♫", "☼", "►", "◄", "↕", "‼", "¶", "§", "▬", "↨", "↑", "↓", "→", _
                 "←", "∟", "↔", "▲", "▼", "!", "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", "-", ".", "/", "[", "\", "]", "^", "_", "`", "ü", _
                 "é", "â", "ä", "à", "å", "ç", "ê", "ë", "è", "ï", "î", "ì"}
        My.Application.SaveMySettingsOnExit = True
        ListBox1.SelectedIndex = 0
        If Debugger.IsAttached = True Then
            testbtn.Visible = True
            Button12.Visible = True
        Else
            testbtn.Visible = False
            Button12.Visible = False
        End If
        httppath = {"http://paizo.com/pathfinderRPG/prd/skillDescriptions.html", _
                    "http://paizo.com/pathfinderRPG/prd/combat.html", _
                    "http://paizo.com/pathfinderRPG/", _
                    "http://paizo.com/pathfinderRPG/prd/races.html", _
                    "http://paizo.com/pathfinderRPG/prd/classes.html", _
                    "http://paizo.com/pathfinderRPG/prd/feats.html", _
                    "http://paizo.com/pathfinderRPG/prd/equipment.html", _
                    "http://paizo.com/pathfinderRPG/prd/magic.html", _
                    "http://paizo.com/pathfinderRPG/prd/spellLists.html", _
                    "http://paizo.com/pathfinderRPG/prd/gamemastering.html", _
                    "http://paizo.com/pathfinderRPG/prd/magicItems.html"}
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "ERROR - Talk to SaNe about this!")
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        savedat()
    End Sub

    Private Sub LoadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LoadToolStripMenuItem.Click
        loaddat()
    End Sub

    Private Sub didenumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles _
                dicenumber.KeyPress, dxside.KeyPress, dxnumber.KeyPress, Amount.KeyPress
        kp(sender, e)
    End Sub

    Private Sub modifiers_keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles _
                Modifiers.KeyPress
        kp1(sender, e)
    End Sub

    Private Sub OnToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OnToolStripMenuItem.Click
        OnToolStripMenuItem.Checked = True
        OffToolStripMenuItem.Checked = False
        My.Application.SplashScreen = SplashScreen
        My.Settings.splashscreen = True
    End Sub

    Private Sub OffToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OffToolStripMenuItem.Click
        OnToolStripMenuItem.Checked = False
        OffToolStripMenuItem.Checked = True
        My.Application.SplashScreen = Nothing
        My.Settings.splashscreen = False
    End Sub

    Private Sub GoldBankToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles GoldBankToolStripMenuItem.Click
        If GoldBankPanel.Visible = True Then
            GoldBankPanel.Hide()
        Else
            GoldBankPanel.Show()
        End If
        resizewin()
    End Sub

    Private Sub DiceRollerToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles DiceRollerToolStripMenuItem.Click
        If DiceRollerPanel.Visible = True Then
            DiceRollerPanel.Hide()
        Else
            DiceRollerPanel.Show()
        End If
        resizewin()
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles InfoToolStripMenuItem.Click
        If InfoPanel.Visible = True Then
            InfoPanel.Hide()
        Else
            InfoPanel.Show()
        End If
        resizewin()
    End Sub

    Private Sub testbtn_Click(sender As System.Object, e As System.EventArgs) Handles testbtn.Click
        For x As Integer = 0 To 8 Step 1
            Console.WriteLine(copperpiece(x) & " / " & silverpiece(x) & " / " & goldpiece(x) & " / " & platinumpiece(x))
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            Playername.Text = ListBox1.SelectedItem.ToString
            CopperLabel.Text = copperpiece(ListBox1.SelectedIndex.ToString)
            SilverLabel.Text = silverpiece(ListBox1.SelectedIndex.ToString)
            GoldLabel.Text = goldpiece(ListBox1.SelectedIndex.ToString)
            PlatinumLabel.Text = platinumpiece(ListBox1.SelectedIndex.ToString)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles plus.Click
        Dim i As String = ListBox1.SelectedIndex.ToString
        If Currency.SelectedIndex = 0 Then 'Copper
            cop(i) = copperpiece(i)
            copperpiece(i) += Amount.Text
            If copperpiece(i) > 999999 Then
                MsgBox("Cannot add that amount of coins.")
                copperpiece(i) = cop(i)
            End If
            CopperLabel.Text = copperpiece(i)
        ElseIf Currency.SelectedIndex = 1 Then 'Silver
            silv(i) = silverpiece(i)
            silverpiece(i) += Amount.Text
            If silverpiece(i) > 999999 Then
                MsgBox("Cannot add that amount of coins.")
                silverpiece(i) = silv(i)
            End If
            SilverLabel.Text = silverpiece(i)
        ElseIf Currency.SelectedIndex = 2 Then 'Gold
            gold(i) = goldpiece(i)
            goldpiece(i) += Amount.Text
            If goldpiece(i) > 999999 Then
                MsgBox("Cannot add that amount of coins.")
                goldpiece(i) = gold(i)
            End If
            GoldLabel.Text = goldpiece(i)
        ElseIf Currency.SelectedIndex = 3 Then 'Platinum
            plat(i) = platinumpiece(i)
            platinumpiece(i) += Amount.Text
            If platinumpiece(i) > 999999 Then
                MsgBox("Cannot add that amount of coins.")
                platinumpiece(i) = plat(i)
            End If
            PlatinumLabel.Text = platinumpiece(i)
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles minus.Click
        Dim i As String = ListBox1.SelectedIndex.ToString
        If Currency.SelectedIndex = 0 Then 'Copper
            cop(i) = copperpiece(i)
            copperpiece(i) -= Amount.Text
            If copperpiece(i) < 0 Then
                MsgBox("Cannot dubtract that amount of coins.")
                copperpiece(i) = cop(i)
            End If
            CopperLabel.Text = copperpiece(i)
        ElseIf Currency.SelectedIndex = 1 Then 'Silver
            silv(i) = silverpiece(i)
            silverpiece(i) -= Amount.Text
            If silverpiece(i) < 0 Then
                MsgBox("Cannot subtract that amount of coins.")
                silverpiece(i) = silv(i)
            End If
            SilverLabel.Text = silverpiece(i)
        ElseIf Currency.SelectedIndex = 2 Then 'Gold
            gold(i) = goldpiece(i)
            goldpiece(i) -= Amount.Text
            If goldpiece(i) < 0 Then
                MsgBox("Cannot subtract that amount of coins.")
                goldpiece(i) = gold(i)
            End If
            GoldLabel.Text = goldpiece(i)
        ElseIf Currency.SelectedIndex = 3 Then 'Platinum
            plat(i) = platinumpiece(i)
            platinumpiece(i) -= Amount.Text
            If platinumpiece(i) < 0 Then
                MsgBox("Cannot subtract that amount of coins.")
                platinumpiece(i) = plat(i)
            End If
            PlatinumLabel.Text = platinumpiece(i)
        End If
    End Sub

    Private Sub addplayerbtn_Click(sender As System.Object, e As System.EventArgs) Handles addplayerbtn.Click
        If Not ListBox1.Items.Count = 9 Then
            AddPlayer.ShowDialog()
        Else
            MsgBox("Cannot add more Players.")
        End If
    End Sub

    Private Sub removeplayer_Click(sender As System.Object, e As System.EventArgs) Handles removeplayer.Click
        Try
            Dim c As Integer
            c = ListBox1.SelectedIndex
            ListBox1.Items.RemoveAt(c)
            If c = ListBox1.Items.Count Then
                c = c - 1
            End If
            ListBox1.SelectedIndex = c
        Catch ex As Exception
        End Try
    End Sub

    Private Sub d4btn_Click(sender As System.Object, e As System.EventArgs) Handles d4btn.Click
        Dim d4 As ListViewItem = Me.ListView1.Items.Add(test(4), 0)
        d4.Selected = True
        d4.EnsureVisible()
        d4.ToolTipText = RichTextBox1.Text
        ListView1.Focus()
    End Sub

    Private Sub d6btn_Click(sender As System.Object, e As System.EventArgs) Handles d6btn.Click
        Dim d6 As ListViewItem = Me.ListView1.Items.Add(test(6), 1)
        d6.Selected = True
        d6.EnsureVisible()
        d6.ToolTipText = RichTextBox1.Text
        ListView1.Focus()
    End Sub

    Private Sub d8btn_Click(sender As System.Object, e As System.EventArgs) Handles d8btn.Click
        Dim d8 As ListViewItem = Me.ListView1.Items.Add(test(8), 2)
        d8.Selected = True
        d8.EnsureVisible()
        d8.ToolTipText = RichTextBox1.Text
        ListView1.Focus()
    End Sub

    Private Sub d10btn_Click(sender As System.Object, e As System.EventArgs) Handles d10btn.Click
        Dim d10 As ListViewItem = Me.ListView1.Items.Add(test(10), 3)
        d10.Selected = True
        d10.EnsureVisible()
        d10.ToolTipText = RichTextBox1.Text
        ListView1.Focus()
    End Sub

    Private Sub d12btn_Click(sender As System.Object, e As System.EventArgs) Handles d12btn.Click
        Dim d12 As ListViewItem = Me.ListView1.Items.Add(test(12), 4)
        d12.Selected = True
        d12.EnsureVisible()
        d12.ToolTipText = RichTextBox1.Text
        ListView1.Focus()
    End Sub

    Private Sub d20btn_Click(sender As System.Object, e As System.EventArgs) Handles d20btn.Click
        Dim d20 As ListViewItem = Me.ListView1.Items.Add(test(20), 5)
        d20.Selected = True
        d20.EnsureVisible()
        d20.ToolTipText = RichTextBox1.Text
        ListView1.Focus()
    End Sub

    Private Sub dxroll_Click(sender As System.Object, e As System.EventArgs) Handles dxroll.Click
        Dim dx As ListViewItem = Me.ListView1.Items.Add(test(dxside.Text, , True), 6)
        dx.Selected = True
        dx.EnsureVisible()
        dx.ToolTipText = RichTextBox1.Text
        ListView1.Focus()
    End Sub

    Private Sub nameadd_Click(sender As System.Object, e As System.EventArgs)
        ListBox1.Items.Insert(ListBox1.SelectedIndex, Playername.Text)
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        ListBox1.SelectedIndex = 0
    End Sub

    Private Sub Clear_Click(sender As System.Object, e As System.EventArgs) Handles Clear.Click
        ListView1.Clear()
        RichTextBox1.Clear()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        System.Diagnostics.Process.Start(httppath(0))
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        System.Diagnostics.Process.Start(httppath(1))
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        System.Diagnostics.Process.Start(httppath(2))
    End Sub

    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        System.Diagnostics.Process.Start(httppath(3))
    End Sub

    Private Sub Button5_Click_1(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        System.Diagnostics.Process.Start(httppath(4))
    End Sub

    Private Sub Button6_Click_1(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        System.Diagnostics.Process.Start(httppath(5))
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        System.Diagnostics.Process.Start(httppath(6))
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        System.Diagnostics.Process.Start(httppath(7))
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        System.Diagnostics.Process.Start(httppath(8))
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        System.Diagnostics.Process.Start(httppath(9))
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        System.Diagnostics.Process.Start(httppath(10))
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        MsgBox("Not yet finished! Still working on the engine to support this.")
    End Sub

    Private Sub InformationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InformationToolStripMenuItem.Click
        About.ShowDialog()
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        For j As Integer = 1 To ListView1.Items.Count Step 1
            If Not ListView1.Items.Item(j - 1).ToolTipText = Nothing Then
                If ListView1.Items.Item(j - 1).Selected = True Then
                    RichTextBox1.Focus()
                    RichTextBox1.Clear()
                    RichTextBox1.SelectionColor = Color.Black
                    RichTextBox1.Text = ListView1.Items.Item(j - 1).ToolTipText
                End If
            End If
        Next
        FindIt(RichTextBox1, Color.Red, " +1 ")
        FindIt(RichTextBox1, Color.Green, " +20 ")
        FindIt(RichTextBox1, Color.Green, " +19 ")
        RichTextBox1.SelectionStart = 0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        If CInt(CopperLabel.Text) >= 500 Then
            CopperPic.Image = Image.FromFile(path & "copperbars.png")
        ElseIf CInt(CopperLabel.Text) < 500 Then
            CopperPic.Image = Image.FromFile(path & "coppercoin.png")
        End If
        If CInt(SilverLabel.Text) >= 500 Then
            SilverPic.Image = Image.FromFile(path & "silverbars.png")
        ElseIf CInt(SilverLabel.Text) < 500 Then
            SilverPic.Image = Image.FromFile(path & "silvercoin.png")
        End If
        If CInt(GoldLabel.Text) >= 500 Then
            GoldPic.Image = Image.FromFile(path & "goldbars.png")
        ElseIf CInt(GoldLabel.Text) < 500 Then
            GoldPic.Image = Image.FromFile(path & "goldcoin.png")
        End If
        If CInt(PlatinumLabel.Text) >= 500 Then
            PlatinumPic.Image = Image.FromFile(path & "platinumbars.png")
        ElseIf CInt(PlatinumLabel.Text) < 500 Then
            PlatinumPic.Image = Image.FromFile(path & "platinumcoin.png")
        End If
    End Sub

End Class