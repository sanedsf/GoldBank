Public Class Main

    ''Author: AnaRchX
    ''Country: Greece
    ''Description: Pathfinder Gold metrics and Information Panel.
    ''Designer: AnaRchX
    ''Coder: AnaRchx
    ''Special Thanks: Oblivionaire, Kesidhs

    Public cop As New List(Of Integer)
    Public silv As New List(Of Integer)
    Public gold As New List(Of Integer)
    Public plat As New List(Of Integer)
    Dim dicepic As String()
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
        My.Application.SaveMySettingsOnExit = True
        If Debugger.IsAttached = True Then
            testbtn.Visible = True
        Else
            testbtn.Visible = False
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
            Me.Close()
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

    Private Sub testbtn_Click(sender As System.Object, e As System.EventArgs) Handles testbtn.Click
        For x As Integer = 0 To ComboBox1.Items.Count - 1 Step 1
            Console.WriteLine(cop.Item(x) & " / " & silv.Item(x) & " / " & gold.Item(x) & " / " & plat.Item(x))
        Next
    End Sub

    Private Sub addplayerbtn_Click(sender As System.Object, e As System.EventArgs) Handles addplayerbtn.Click
        Dim c As String = InputBox("Please specify the players name.", "Add a player into the players list.", "Player " & ComboBox1.Items.Count.ToString)
        If c <> "" Then
            ComboBox1.Items.Add(c)
            cop.Add(0)
            silv.Add(0)
            gold.Add(0)
            plat.Add(0)
            ComboBox1.SelectedIndex = ComboBox1.Items.Count - 1
        End If
    End Sub

    Private Sub removeplayer_Click(sender As System.Object, e As System.EventArgs) Handles removeplayer.Click
        Dim h As New ComboBox
        Me.GroupBox4.Controls.Add(h)
        h.Enabled = False
        h.Text = Me.ComboBox1.Text
        h.Name = "h"
        h.Location = ComboBox1.Location
        h.Size = ComboBox1.Size
        List.ShowDialog()
        Me.GroupBox4.Controls.Add(List.Controls.Item("Combobox1"))
        Me.GroupBox4.Controls.Item("Combobox1").Location = New Point(55, 22)
        Me.GroupBox4.Controls.Item("Combobox1").Size = New Size(154, 21)
        Me.ComboBox1.SelectedIndex = 0
        List.Dispose()
        Me.GroupBox4.Controls.RemoveByKey("h")
        h.Dispose()
        h = Nothing
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

    Private Sub Clear_Click(sender As System.Object, e As System.EventArgs) Handles Clear.Click
        ListView1.Clear()
        RichTextBox1.Clear()
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

    Private Sub CopperPic_MouseDown(sender As Object, e As MouseEventArgs) Handles CopperPic.MouseDown
        Dim i As Integer = ComboBox1.SelectedIndex
        If Amount.Text Is "" Then
            MsgBox("Amount cannot be nothing.")
        ElseIf Amount.Text IsNot "" And i >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If (cop.Item(i) + CInt(Amount.Text)) > 999999 Then
                    MsgBox("Cannot add any more.")
                Else
                    cop.Item(i) += CInt(Amount.Text)
                    CopperLabel.Text = cop.Item(i)
                End If
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                If (cop.Item(i) - CInt(Amount.Text)) < 0 Then
                    MsgBox("Cannot subtract any more.")
                Else
                    cop.Item(i) -= CInt(Amount.Text)
                    CopperLabel.Text = cop.Item(i)
                End If
            End If
        End If
        pic_change(CopperLabel, CopperPic, "copper")
    End Sub

    Private Sub SilverPic_MouseDown(sender As Object, e As MouseEventArgs) Handles SilverPic.MouseDown
        Dim i As Integer = ComboBox1.SelectedIndex
        If Amount.Text Is "" Then
            MsgBox("Amount cannot be nothing.")
        ElseIf Amount.Text IsNot "" And i >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If (silv.Item(i) + CInt(Amount.Text)) > 999999 Then
                    MsgBox("Cannot add any more.")
                Else
                    silv.Item(i) += CInt(Amount.Text)
                    SilverLabel.Text = silv.Item(i)
                End If
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                If (silv.Item(i) - CInt(Amount.Text)) < 0 Then
                    MsgBox("Cannot subtract any more.")
                Else
                    silv.Item(i) -= CInt(Amount.Text)
                    SilverLabel.Text = silv.Item(i)
                End If
            End If
        End If
        pic_change(SilverLabel, SilverPic, "silver")
    End Sub

    Private Sub GoldPic_MouseDown(sender As Object, e As MouseEventArgs) Handles GoldPic.MouseDown
        Dim i As Integer = ComboBox1.SelectedIndex
        If Amount.Text Is "" Then
            MsgBox("Amount cannot be nothing.")
        ElseIf Amount.Text IsNot "" And i >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If (gold.Item(i) + CInt(Amount.Text)) > 999999 Then
                    MsgBox("Cannot add any more.")
                Else
                    gold.Item(i) += CInt(Amount.Text)
                    GoldLabel.Text = gold.Item(i)
                End If
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                If (gold.Item(i) - CInt(Amount.Text)) < 0 Then
                    MsgBox("Cannot subtract any more.")
                Else
                    gold.Item(i) -= CInt(Amount.Text)
                    GoldLabel.Text = gold.Item(i)
                End If
            End If
        End If
        pic_change(GoldLabel, GoldPic, "gold")
    End Sub

    Private Sub PlatinumPic_MouseDown(sender As Object, e As MouseEventArgs) Handles PlatinumPic.MouseDown
        Dim i As Integer = ComboBox1.SelectedIndex
        If Amount.Text Is "" Then
            MsgBox("Amount cannot be nothing.")
        ElseIf Amount.Text IsNot "" And i >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If (plat.Item(i) + CInt(Amount.Text)) > 999999 Then
                    MsgBox("Cannot add any more.")
                Else
                    plat.Item(i) += CInt(Amount.Text)
                    PlatinumLabel.Text = plat.Item(i)
                End If
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                If (plat.Item(i) - CInt(Amount.Text)) < 0 Then
                    MsgBox("Cannot subtract any more.")
                Else
                    plat.Item(i) -= CInt(Amount.Text)
                    PlatinumLabel.Text = plat.Item(i)
                End If
            End If
        End If
        pic_change(PlatinumLabel, PlatinumPic, "platinum")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim i As Integer = ComboBox1.SelectedIndex
        CopperLabel.Text = cop.Item(i)
        SilverLabel.Text = silv.Item(i)
        GoldLabel.Text = gold.Item(i)
        PlatinumLabel.Text = plat.Item(i)
    End Sub

    Private Sub Button_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover, Button2.MouseHover, Button3.MouseHover
        sender.Image = Image.FromFile(path & "info3.png")
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave, Button2.MouseLeave, Button3.MouseLeave
        sender.Image = Image.FromFile(path & "info2.png")
    End Sub

    Private Sub Convert_Click(sender As Object, e As EventArgs) Handles Convert.Click
        Dim i As Integer = ComboBox1.SelectedIndex
        For x As Integer = 0 To 1000 Step 1
            plat.Item(i) += Math.Floor(gold.Item(i) / 10)
            gold.Item(i) -= gold.Item(i) - (((gold.Item(i) / 10) - Math.Floor(gold.Item(i) / 10)) * 10)
            gold.Item(i) += Math.Floor(silv.Item(i) / 10)
            silv.Item(i) -= silv.Item(i) - (((silv.Item(i) / 10) - Math.Floor(silv.Item(i) / 10)) * 10)
            silv.Item(i) += Math.Floor(cop.Item(i) / 10)
            cop.Item(i) -= cop.Item(i) - (((cop.Item(i) / 10) - Math.Floor(cop.Item(i) / 10)) * 10)
        Next
        CopperLabel.Text = cop.Item(i)
        SilverLabel.Text = silv.Item(i)
        GoldLabel.Text = gold.Item(i)
        PlatinumLabel.Text = plat.Item(i)
    End Sub

End Class