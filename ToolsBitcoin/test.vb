Public Class test
    Dim cookie As Integer

   

    Private Sub test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer3.Start()
        Timer1.Start()
        Button2.Hide()
        Button3.Hide()
        Button4.Hide()
        Button5.Hide()
        Button6.Hide()
        Button7.Hide()
        Button8.Hide()
        Button9.Hide()
        Timer2.Start()
    End Sub

    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Hide()
        Button9.Show()
        cookie = cookie + 1
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button9.Hide()
        Button8.Show()
        cookie = cookie + 1
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Button8.Hide()
        Button7.Show()
        cookie = cookie + 1
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button7.Hide()
        Button6.Show()
        cookie = cookie + 1
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Hide()
        Button5.Show()
        cookie = cookie + 1
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Hide()
        Button4.Show()
        cookie = cookie + 1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.Hide()
        Button3.Show()
        cookie = cookie + 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Hide()
        Button1.Show()
        cookie = cookie + 1
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = cookie
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If Label2.Text >= 0 Then
            ProgressBar1.Value = Label2.Text
        ElseIf Label2.Text > 100 Then

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Hide()
        Button2.Show()
        cookie = cookie + 1
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        cookie = cookie - 1
    End Sub
End Class