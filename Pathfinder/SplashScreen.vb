Public Class SplashScreen
    Dim rnd As New Random
    Dim test As Short
    Dim img As String()

    Private Sub SplashScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Activate()
        If My.Settings.splashscreen = False Then
            Me.Dispose()
        Else
            img = {"SplashScreen0.png", "SplashScreen1.png", "SplashScreen2.png", "SplashScreen3.png", "SplashScreen4.png", "SplashScreen5.png", "SplashScreen6.png", "SplashScreen7.png", "SplashScreen8.png", "SplashScreen9.png"}
            test = rnd.Next(0, 8)
            Try
                Me.BackgroundImage = Image.FromFile(Main.path & img(test))
            Catch ex As Exception
                MsgBox("An error has occured while trying to load the background image." & vbCrLf & "Ignore this for now until i find a better way to make it work!", MsgBoxStyle.Critical, "- Error -")
            End Try
        End If
    End Sub
End Class