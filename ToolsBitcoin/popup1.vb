Public Class popup1
    Dim trackTransparency As Double
    Private Sub popup1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Timer1.Start()
    End Sub
    

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = Form1.ToolStripStatusLabel1.Text
        Label3.Text = Form1.ToolStripStatusLabel3.Text
        Label5.Text = Form1.ToolStripStatusLabel10.Text
        Label6.Text = Form1.ToolStripStatusLabel11.Text

        If Label5.Text = "เท่าเดิม +-" Then
            Label5.BackColor = Color.Yellow

        ElseIf Label5.Text = "เพิ่มขึ้น +" Then
            Label5.BackColor = Color.Green

        ElseIf Label5.Text = "ลดลง -" Then
            Label5.BackColor = Color.Red

        End If
        trackTransparency = Me.Opacity
        trackTransparency = TrackBar1.Value

    End Sub

    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        Me.Opacity = (trackTransparency / 100)
    End Sub

    
End Class