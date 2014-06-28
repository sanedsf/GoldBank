Module FuncMod

    Function roll(ByVal i As Integer, ByVal p As Integer)
        Dim rndnumber As New Random
        Dim k As Integer
        For t As Integer = 0 To p Step 1
            k = rndnumber.Next(i, p)
        Next
        Return k
    End Function

    Function kp(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 OrElse Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        Return True
    End Function

    Function kp1(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Asc(e.KeyChar) = 8 Then
            If Asc(e.KeyChar) < 43 Then
                e.Handled = True
            ElseIf Asc(e.KeyChar) = 43 OrElse Asc(e.KeyChar) = 45 Then
            ElseIf Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
            Else
                e.Handled = True
            End If
        End If
        Return True
    End Function

    Function algorithm(ByRef data As String, ByVal index As Integer) As String
        'data = the data the function takes to replace
        'index = save or load
        Dim w As String = data
        If index = 1 Then
            For x As Integer = 0 To Main.load1.Length - 1
                w = Replace(w, Main.load1(x), Main.save1(x))
            Next : Return w
        ElseIf index = 0 Then
            For x As Integer = 0 To Main.load1.Length - 1
                w = Replace(w, Main.save1(x), Main.load1(x))
            Next : Return w
        End If
        Return True
    End Function

    Function savedat()
        Main.SaveFileDialog1.Filter = "Data|*.dat"
        Main.SaveFileDialog1.Title = "Save Data File"
        Main.SaveFileDialog1.DefaultExt = "Data|*.dat"
        Main.SaveFileDialog1.InitialDirectory = Main.path
        Main.SaveFileDialog1.ShowDialog()
        If Main.SaveFileDialog1.FileName <> "" Then
            If My.Computer.FileSystem.FileExists(Main.SaveFileDialog1.FileName.ToString) Then
                My.Computer.FileSystem.DeleteFile(Main.SaveFileDialog1.FileName.ToString)
            End If
            For x As Integer = 0 To Main.ListBox1.Items.Count - 1 Step 1
                My.Computer.FileSystem.WriteAllText(Main.SaveFileDialog1.FileName.ToString, algorithm(Main.ListBox1.Items.Item(x).ToString, 1) & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(Main.SaveFileDialog1.FileName.ToString, algorithm(Main.copperpiece(x).ToString, 1) & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(Main.SaveFileDialog1.FileName.ToString, algorithm(Main.silverpiece(x).ToString, 1) & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(Main.SaveFileDialog1.FileName.ToString, algorithm(Main.goldpiece(x).ToString, 1) & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(Main.SaveFileDialog1.FileName.ToString, algorithm(Main.platinumpiece(x).ToString, 1) & vbCrLf, True)
            Next
        End If
        Return True
    End Function

    Function loaddat()
        Main.OpenFileDialog1.Filter = "Data|*.dat"
        Main.OpenFileDialog1.Title = "Load a save file"
        Main.OpenFileDialog1.DefaultExt = "Data|*.dat"
        Main.OpenFileDialog1.InitialDirectory = Main.path
        Main.OpenFileDialog1.ShowDialog()
        If Main.OpenFileDialog1.FileName <> "" Then
            Dim sr As New System.IO.StreamReader(Main.OpenFileDialog1.FileName)
            Main.ListBox1.Items.Clear()
            Dim lineCount = IO.File.ReadAllLines(Main.OpenFileDialog1.FileName).Length
            For x As Integer = 0 To Math.Floor(lineCount / 5) - 1 Step 1
                Main.ListBox1.Items.Add(algorithm(sr.ReadLine(), 0))
                Main.copperpiece(x) = algorithm(sr.ReadLine(), 0)
                Main.silverpiece(x) = algorithm(sr.ReadLine(), 0)
                Main.goldpiece(x) = algorithm(sr.ReadLine(), 0)
                Main.platinumpiece(x) = algorithm(sr.ReadLine(), 0)
            Next
            Main.ListBox1.SelectedIndex = 0
            sr.Close()
        End If
        Return True
    End Function

    Function test(ByVal q As Integer, Optional ByVal w As Integer = 0, Optional ByVal e As Boolean = False)
        'q = Dice side
        'w = optional starting value of the dice. default is 0
        'e : true = normal / false = custom
        Main.RichTextBox1.Clear()
        Dim agf As Integer 'total number added together
        Dim gg As Integer 'rolled dice
        Dim myint As Integer() = {1, 20, 19} 'criticals
        Dim msc As New MSScriptControl.ScriptControl 'modifier scriptcontrol textbox
        Main.TextBox4.Clear()
        msc.Language = "vbscript"
        If e = False Then
            For aga As Integer = 0 To CInt(Main.dicenumber.Text) - 1 Step 1
                gg = roll(w, q) + 1
                agf += gg
                If gg = myint(0) Then
                    Main.RichTextBox1.SelectionColor = Color.Red
                ElseIf gg = myint(1) OrElse gg = myint(2) Then
                    Main.RichTextBox1.SelectionColor = Color.Green
                Else : Main.RichTextBox1.SelectionColor = Color.Black
                End If
                Main.RichTextBox1.AppendText(" +" & gg & " ")
                Main.RichTextBox1.SelectionColor = Color.Black
            Next
        Else
            For aga As Integer = 0 To CInt(Main.dxnumber.Text) - 1 Step 1
                gg = roll(w, q) + 1
                agf += gg
                If gg = myint(0) Then
                    Main.RichTextBox1.SelectionColor = Color.Red
                ElseIf gg = myint(1) OrElse gg = myint(2) Then
                    Main.RichTextBox1.SelectionColor = Color.Green
                Else : Main.RichTextBox1.SelectionColor = Color.Black
                End If
                Main.RichTextBox1.AppendText(" +" & gg & " ")
                Main.RichTextBox1.SelectionColor = Color.Black
            Next
        End If
        Main.RichTextBox1.AppendText(Main.Modifiers.Text)
        Return agf + msc.Eval(Main.Modifiers.Text) 'return everything added together for the ListView1
    End Function

    Function resizewin()
        Main.Size = New Size(998, 379)
        If (Main.GoldBankPanel.Visible = True OrElse Main.InfoPanel.Visible = True) And Main.DiceRollerPanel.Visible = True Then
            Main.Size = New Size(998, 379)
        ElseIf Main.GoldBankPanel.Visible = False And Main.InfoPanel.Visible = False And Main.DiceRollerPanel.Visible = True Then
            Main.Size = New Size(Main.Width - Main.GoldBankPanel.Width, Main.Height)
        ElseIf Main.GoldBankPanel.Visible = True And Main.InfoPanel.Visible = True And Main.DiceRollerPanel.Visible = False Then
            Main.Size = New Size(Main.Width - Main.DiceRollerPanel.Width, Main.Height)
        ElseIf Main.GoldBankPanel.Visible = True And Main.InfoPanel.Visible = False And Main.DiceRollerPanel.Visible = False Then
            Main.Size = New Size(Main.Width - Main.DiceRollerPanel.Width, Main.Height - Main.InfoPanel.Height)
        ElseIf Main.GoldBankPanel.Visible = False And Main.InfoPanel.Visible = True And Main.DiceRollerPanel.Visible = False Then
            Main.Size = New Size(Main.Width - Main.DiceRollerPanel.Width, Main.Height - Main.GoldBankPanel.Height)
        Else
            Main.Size = New Size(162, 53)
        End If
        Return True
    End Function

    Function FindIt(Box As RichTextBox, colore As System.Drawing.Color, Srch As String, Optional Start As Long = 0)
        Dim retval As Long 'return value
        Dim Source As String 'the source of text
        Source = Box.Text
        If Start = 0 Then Start = 1
        retval = InStr(Start, Source, Srch, CompareMethod.Text)
        If retval <> 0 Then
            With Box
                .SelectionStart = retval - 1
                .SelectionLength = Len(Srch)
                .SelectionColor = colore
                .SelectionLength = 0
            End With
            Start = retval + Len(Srch)
            FindIt = 1 + FindIt(Box, colore, Srch, Start)
        End If
        Return retval 'return how many items you found
    End Function
End Module
