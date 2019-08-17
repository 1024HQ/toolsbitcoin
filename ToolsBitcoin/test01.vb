Public Class test01

    Private Sub test01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'เรียก ค่าเงินบาทไทยมาโชว์
        Label1.Text = Form1.Label1.Text
    End Sub
End Class