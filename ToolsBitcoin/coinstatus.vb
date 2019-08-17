Public Class coinstatus

    Private Sub coinstatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
    End Sub
End Class