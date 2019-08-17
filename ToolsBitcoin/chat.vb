Public Class chat

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        WebBrowser1.Refresh()
    End Sub

    Private Sub chat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class