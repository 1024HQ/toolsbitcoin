Public Class pool

    Private Sub pool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer2.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ComboBox2.Text = "Swipp [SWP]" Then
            TextBox1.Text = "http://localhost/cookie/swipp-hr.php"

            If Len(WebBrowser1.DocumentText) >= 10 Then
                Label9.Text = WebBrowser1.DocumentText


            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        WebBrowser1.Navigate(TextBox1.Text)
    End Sub
End Class