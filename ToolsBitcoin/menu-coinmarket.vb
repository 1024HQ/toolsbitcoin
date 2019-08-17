Public Class menu_coinmarket

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        coinmarket_trade.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        coinmarket_2.Show()
    End Sub

    Private Sub menu_coinmarket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class