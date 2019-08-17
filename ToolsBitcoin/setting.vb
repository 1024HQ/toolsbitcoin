Public Class setting

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' ถ้า patch = 1 จะแจ้งเตือน patch note ทุกครั้งที่เปิดโปรแกรม ถ้าเป็น 0 จะไม่แจ้งเตือน
        If CheckBox4.Checked = True Then
            My.Settings.patch = "1"
        ElseIf CheckBox4.Checked = False Then
            My.Settings.patch = "0"

        End If

        ' ถ้า patch = 1 จะเปิดเสียงแจ้งเตือน ทุกครั้งที่เปิดโปรแกรม ถ้าเป็น 0 จะไม่แจ้งเตือน
        If CheckBox5.Checked = True Then
            My.Settings.button = "1"
        ElseIf CheckBox5.Checked = False Then
            My.Settings.button = "0"

        End If




        ' เมื่อค่า = 0 จะไม่เล่นเสียงอัตโนมัติ เมื่อค่า = 1 จะเล่นเสียงอัตโนมัติ
        If CheckBox1.Checked = True Then
            My.Settings.test1 = "1"
        ElseIf CheckBox1.Checked = False Then
            My.Settings.test1 = "0"
        End If

        If CheckBox2.Checked = True Then
            My.Settings.test2 = "1"
        ElseIf CheckBox2.Checked = False Then
            My.Settings.test2 = "0"
        End If


        If RadioButton1.Checked = True Then
            My.Settings.btc_setting = "EN"

        ElseIf RadioButton2.Checked = True Then
            My.Settings.btc_setting = "TH"
        End If


        My.Settings.Save()

        MsgBox("บันทึกการตั้งค่าเสร็จสิ้น !", , "แจ้งเตือน")
    End Sub

    Private Sub setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        'เปิดแจ้งเตือน patchNote
        If My.Settings.patch = "1" Then
            CheckBox4.Checked = True
        ElseIf My.Settings.patch = "0" Then
            CheckBox4.Checked = False
        End If

        'ปิดเสียงปุ่มโปรแกรม
        If My.Settings.button = "1" Then
            CheckBox5.Checked = True
        ElseIf My.Settings.button = "0" Then
            CheckBox5.Checked = False
        End If


        If My.Settings.test1 = "1" Then
            CheckBox1.Checked = True
        ElseIf My.Settings.test1 = "0" Then
            CheckBox1.Checked = False
        End If

        If My.Settings.test2 = "1" Then
            CheckBox2.Checked = True
        ElseIf My.Settings.test2 = "0" Then
            CheckBox2.Checked = False
        End If


        If My.Settings.btc_setting = "EN" Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False

        ElseIf My.Settings.btc_setting = "TH" Then
            RadioButton2.Checked = True
            RadioButton1.Checked = False
        End If
    End Sub
End Class