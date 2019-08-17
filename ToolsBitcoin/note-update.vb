Public Class note_update

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WebBrowser1.Refresh()
    End Sub

    Private Sub note_update_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()

        Me.TopMost = True
        
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        WebBrowser1.Navigate("https://hackerz.in.th/bitcoin/update/patch.txt")
        Timer1.Stop()
    End Sub
End Class