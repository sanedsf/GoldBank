Public Class AddPlayer

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If Not Main.ListBox1.Items.Count = 9 Then
                If TextBox1.Text = "" Then
                    TextBox1.Text = "Player"
                End If
                Main.ListBox1.Items.Insert(Main.ListBox1.Items.Count, TextBox1.Text)
                Main.ListBox1.SelectedIndex = Main.ListBox1.Items.Count - 1
                Main.copperpiece(Main.ListBox1.SelectedIndex) = TextBox2.Text
                Main.CopperLabel.Text = Main.copperpiece(Main.ListBox1.SelectedIndex)
                Main.silverpiece(Main.ListBox1.SelectedIndex) = TextBox3.Text
                Main.SilverLabel.Text = Main.silverpiece(Main.ListBox1.SelectedIndex)
                Main.goldpiece(Main.ListBox1.SelectedIndex) = TextBox4.Text
                Main.GoldLabel.Text = Main.goldpiece(Main.ListBox1.SelectedIndex)
                Main.platinumpiece(Main.ListBox1.SelectedIndex) = TextBox5.Text
                Main.PlatinumLabel.Text = Main.platinumpiece(Main.ListBox1.SelectedIndex)
                Main.ListBox1.SelectedIndex = Main.ListBox1.Items.Count - 1
                Me.Close()
            Else
                MsgBox("Cannot add more Players.")
                If MsgBoxResult.Ok Then
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox("Critical error occured.", MsgBoxStyle.Critical)
            Me.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub AddPlayer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        copperpic.Image = Image.FromFile(Main.path & "coppercoin.png")
        silverpic.Image = Image.FromFile(Main.path & "silvercoin.png")
        goldpic.Image = Image.FromFile(Main.path & "goldcoin.png")
        PlatinumPic.Image = Image.FromFile(Main.path & "platinumcoin.png")
    End Sub
End Class