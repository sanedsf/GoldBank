Public Class List
    Private Sub List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Controls.Add(Main.ComboBox1)
        Me.Controls.Item("ComboBox1").Location = New Point(12, 12)
        Me.Controls.Item("ComboBox1").Size = New Size(158, 21)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim g As ComboBox = Me.Controls.Item("ComboBox1")
        Dim c As Integer = g.SelectedIndex
        If c <> -1 Then
            Main.cop.RemoveAt(c)
            Main.silv.RemoveAt(c)
            Main.gold.RemoveAt(c)
            Main.plat.RemoveAt(c)
            g.Items.RemoveAt(c)
        End If
    End Sub
End Class