Imports System.IO

Public Class Players

    Dim ctrl() As TextBox

    Private Sub Players_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ctrl = {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12, TextBox13, TextBox14, TextBox15, TextBox16, TextBox17, TextBox18, TextBox19, TextBox20, TextBox21, TextBox22, TextBox23, TextBox24, TextBox25, TextBox26, TextBox27, TextBox28, TextBox29, TextBox30, TextBox31, TextBox32, TextBox33, TextBox34, TextBox35}
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            My.Computer.FileSystem.DeleteFile(Main.path & "lala.dat")
        Catch ex As Exception

        End Try
        For p As Integer = 0 To 34 Step 1
            For Each character In ctrl(p).Text
                If character = " " Then
                    character = "_"
                End If
                Dim l As Integer = AscW(character)
                Dim q As Integer = 0
                Dim o As Double = Math.Floor(l) / 2
                Dim btarray(6) As Integer
                Do Until o = 0
                    If o = Math.Floor(o) Then
                        btarray(q) = 0
                        l = Math.Floor(o)
                    Else
                        btarray(q) = 1
                        l = Math.Floor(o)
                    End If
                    o = Math.Floor(l) / 2
                    q += 1
                Loop
                Array.Reverse(btarray)
                For t As Integer = 0 To q - 1 Step 1
                    'Console.Write(btarray(t).ToString)
                    My.Computer.FileSystem.WriteAllText(Main.path & "lala.dat", btarray(t).ToString, True, System.Text.Encoding.UTF7)
                Next
            Next
        Next
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim h As String = My.Computer.FileSystem.ReadAllText(Main.path & "lala.dat")
        For u As Integer = 0 To h.Length - 1 Step 7
            Dim k As String
            k = h.Substring(u, 7).ToString
            Dim f As Integer = k.Length
            Dim l As Integer = 0
            Dim chrarray As String = ""
            For i As Integer = 0 To k.Length - 1 Step 1
                f -= 1
                l += k.Substring(i, 1) * (2 ^ (f))
                Application.DoEvents()
            Next
            chrarray += ChrW(l).ToString
            My.Computer.FileSystem.WriteAllText(Main.path & "lala1.dat", ChrW(l).ToString, True)
        Next
        Dim p As String = My.Computer.FileSystem.ReadAllText(Main.path & "lala1.dat")
        For u As Integer = 0 To p.Length - 1 Step 7
            Dim k As String
            k = p.Substring(u, 7).ToString
            ctrl(u / 7).Text = k.ToString
        Next
    End Sub
End Class