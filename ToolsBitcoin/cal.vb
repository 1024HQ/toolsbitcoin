Public Class cal

    Private Sub cal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = 2
        Timer2.Start()
        Me.TopMost = True
    End Sub

  

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim cookie As Double
        cookie = Form1.Label1.Text
        Label2.Text = cookie

        ' ดอลล่า * บาท แปลงดอลล่าเป็นบาท
        If TextBox1.Text = "" Then

        ElseIf IsNumeric(TextBox1.Text) Then
            Dim marker1, marker2 As Double
            marker1 = Label2.Text
            marker2 = TextBox1.Text * marker1
            TextBox2.Text = FormatNumber(marker2, ComboBox1.Text)

        Else
            TextBox1.Text = ""
        End If



        ' แปลงบาทเป็นดอลล่า
        If TextBox4.Text = "" Then

        ElseIf IsNumeric(TextBox4.Text) Then
            Dim marker3, marker4 As Double
            marker3 = Label2.Text
            marker4 = TextBox4.Text / marker3
            TextBox3.Text = FormatNumber(marker4, ComboBox1.Text)

        Else
            TextBox4.Text = ""
        End If
    End Sub
End Class