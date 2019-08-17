Imports System.Net
Imports System.IO
Imports System.Management
Imports Microsoft.VisualBasic.CompilerServices
Public Class about
    Public str_ As String
    Public count_ As Integer
    Private Sub about_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If RichTextBox1.Text.Length = str_.Length Then
            Timer1.Enabled = True
            Exit Sub
        End If
        RichTextBox1.Text = str_.Substring(0, count_)
        count_ = count_ + 1
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        RichTextBox1.Text = ""
        count_ = 1
        str_ = "โปรแกรมนี้ดึงข้อมูลออนไลน์ แบบ realtime อัพเดทตลอดเวลา ไม่ fix ราคา และ หากราคามีการขึ้นหรือลงการคำนวณก็จะเปลี่ยนไปตามค่าเงินปัจจุบันที่โปรแกรมนั้นดึงจาก Server  , เนื่องด้วย API ที่ต้องใช้ในแต่ละตัว ผมจึงเขียน API ขึ้นมาเองโดยดึงผ่านหน้าเว็บของผมอีกทีจะเป็นแบบนี้   Client > ServerProgram > Bitcoin-*เหรียญต่างๆ  เพราะไม่สามารถดึงโดยตรงได้จึงจำเป็นต้องดึงโดยผ่านตัวกลางที่ผมเขียนขึ้น ข้อมูลจะอัพเดทตลอดเวลา และ โปรแกรมนี้ผมตั้งอัพเดททุกๆ 30 วินาที :)   จัดทำขึ้นเพื่อให้สะดวกในการลงทุนเนื่องด้วยต้องเข้าเช็คหลายเว็บจนมึน ผมเลยทำโปรแกรมนี้ขึ้นมาใช้เองตั้งเป้าหมายไว้ว่าโปรแกรมนี้จะสามารถทำได้ทุกอย่างเพียงคลิกเดียวโดยไม่ยุ่งยากเข้านู่นนี่นั่น แต่ไม่ว่าท่านไหนจะนำไปใช้แล้วเปิดประโยชน์ผมก็ดีใจแล้ว ฮ่าฮ่า  โชคดีครับ :W"
        Timer1.Enabled = True
        Timer2.Stop()
    End Sub
End Class