Imports System.Net
Imports Microsoft.VisualBasic.CompilerServices
Imports System.IO
Public Class Form1
    Dim marker1, marker2, marker3, test1, test2, test3 As Double
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.patch = "1" Then
            note_update.Show()

        End If

        

        ' ถ้าเปิดอ่านโค๊ดโปรแกรมนี้แล้ว อาจจะเข้าใจยากนิดนึงนะ แต่ก็พอเขียนคำอธิบายไว้บ้าง เพราะโปรแกรมนี้ทำให้ตัวเองเข้าใจ ไม่ได้เขียนขึ้นให้คนอื่นเข้าใจง่ายสักเท่าไหร่ 555+

        ' สั่งให้เช็ค price bitcoin ทุกๆ 5 วินาที
        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
        Timer6.Start()
        ToolStripStatusLabel1.Text = "0"
        ToolStripStatusLabel2.Text = "ราคาปัจจุบัน : "
        ToolStripStatusLabel3.Text = "0"
        Timer7.Start()
        Timer8.Start()
        Timer9.Start()

        ' Dim web As New WebClient
        'Dim price_btc As String = web.DownloadString("https://hackerz.in.th/bitcoin/api/bitcoin_price.php")
        '  ToolStripStatusLabel1.Text = price_btc

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        

        Label3.Text = ToolStripStatusLabel3.Text

        WebBrowser1.Navigate(TextBox18.Text)
        WebBrowser2.Refresh()
        WebBrowser4.Refresh()
        WebBrowser5.Refresh()
        timer5.start()




    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        




        ' เช็ค setting ว่าตั้ง BTC เป็นนอกหรือไทย  webbrowser 1 คือลิ้งสำหรับ BTC price $
        If My.Settings.btc_setting = "EN" Then
            TextBox18.Text = "https://hackerz.in.th/bitcoin/api/bitcoin_price.php"
        ElseIf My.Settings.btc_setting = "TH" Then
            TextBox18.Text = "https://hackerz.in.th/bitcoin/api/bitcoin_priceth.php"
        End If


        'เช็คปิง
        If Len(WebBrowser5.DocumentText) >= "11" Then

        ElseIf Len(WebBrowser5.DocumentText) <= "11" Then
            Label19.Text = WebBrowser5.DocumentText
        End If

        ' หากโปรแกรมไม่ทำงานเช่น เลขราคาไม่ขึ้นให้มาแก้ตรงนี้ นะ
        ' เช็คเงื่อนไข กันโปรแกรมบัค เวลาโหลดข้อมูลใหม่จาก server ถ้ามันไม่ไช่ค่าตัวเลข จะยังไม่ทำการอัพเดทข้อมูล จนกว่าข้อมูลจะเป็นตัวเลข
        If Len(WebBrowser1.DocumentText) = "7" Then
            Label2.Text = WebBrowser1.DocumentText
        ElseIf Len(WebBrowser1.DocumentText) = "8" Then
            Label2.Text = WebBrowser1.DocumentText
        ElseIf Len(WebBrowser1.DocumentText) >= "10" Then

        Else

        End If


        ' เช็คเงื่อนไข กันโปรแกรมบัค เวลาโหลดข้อมูลใหม่จาก server ถ้ามันไม่ไช่ค่าตัวเลข จะยังไม่ทำการอัพเดทข้อมูล จนกว่าข้อมูลจะเป็นตัวเลข

        'ถ้าเลขไม่ขึ้นให้แก้ตรงนี้ สำหรับเงินบาทแปลง
        If Len(WebBrowser2.DocumentText) = "7" Then
            Label1.Text = WebBrowser2.DocumentText
            If Label3.Text > ToolStripStatusLabel3.Text Then
                ToolStripStatusLabel10.Text = "ลดลง -"
                Dim test01, test03 As Double
                marker1 = ToolStripStatusLabel1.Text
                marker2 = Label1.Text
                marker3 = marker1 * marker2
                test01 = Label3.Text
                test03 = test01 - marker3
                ToolStripStatusLabel11.Text = FormatNumber(test03, 2)
                ToolStripStatusLabel10.BackColor = Color.Red

                'แจ้งเตือนเสียง
                If My.Settings.bitcoin_down = "1" Then
                    My.Computer.Audio.Play(My.Resources.btcsound, AudioPlayMode.Background)
                    My.Settings.bitcoin_down = "0"

                End If

            ElseIf Label3.Text < ToolStripStatusLabel3.Text Then
                ToolStripStatusLabel10.Text = "เพิ่มขึ้น +"
                Dim test01, test03 As Double
                marker1 = ToolStripStatusLabel1.Text
                marker2 = Label1.Text
                marker3 = marker1 * marker2
                test01 = Label3.Text

                test03 = marker3 - test01
                ToolStripStatusLabel11.Text = FormatNumber(test03, 2)
                ToolStripStatusLabel10.BackColor = Color.Green

                'แจ้งเตือนเสียง
                If My.Settings.bitcoin_up = "1" Then
                    My.Computer.Audio.Play(My.Resources.btcsound, AudioPlayMode.Background)
                    My.Settings.bitcoin_up = "0"

                End If

            ElseIf Label3.Text = ToolStripStatusLabel3.Text Then
                ToolStripStatusLabel10.Text = "เท่าเดิม +-"
                ToolStripStatusLabel10.BackColor = Color.Yellow
                ToolStripStatusLabel11.Text = "0"
            Else
                ToolStripStatusLabel10.Text = "= error"
            End If

        ElseIf Len(WebBrowser2.DocumentText) >= "8" Then

        Else

        End If

        'backup เงินก่อนที่จะเปลี่ยนแปลง ใช้คำนวณว่าค่ามันขึ้นหรือลง
        If Label3.Text = "0" And ToolStripStatusLabel3.Text > "0.00" Then
            Label3.Text = ToolStripStatusLabel3.Text
        Else

        End If

        ' คำนวณ เอา ค่าเงินดอลล่า * ค่าเงินบาทไทยปัจจุบัน
        marker1 = ToolStripStatusLabel1.Text
        marker2 = Label1.Text
        marker3 = marker1 * marker2
        'สั่งให้แสดงผล โดยแสดงผลเป็นตัวเลขพร้อมทศนิยม
        ToolStripStatusLabel3.Text = FormatNumber(marker3, 2)
        ToolStripStatusLabel1.Text = FormatNumber(Label2.Text, 2)

        'แสดงผลเวลาปัจจุบัน อ้างอิงจากเครื่อง
        ToolStripStatusLabel8.Text = Now.ToLongTimeString.ToString()
        ToolStripStatusLabel9.Text = DateTime.Now.ToLongDateString()

        'แสดงผลเป็นแถบ process วิ่ง อ้างอิงจากจำนวนเงิน  ค่าความจุทั้งหมดคือ 1,000,000 บาท
        ToolStripProgressBar1.Value = ToolStripStatusLabel3.Text


        'เช็คเวอร์ชั่นจากเซิฟเวอร์
        If Len(WebBrowser4.DocumentText) <= "10" Then
            Label15.Text = WebBrowser4.DocumentText
        End If


    End Sub

    
    Private Sub Server1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Server1ToolStripMenuItem.Click
        Process.Start("http://ssvpool.com")
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        ' เพิ่มเหรียญที่นี่  
        If ComboBox1.Text = "" Then
            TextBox4.Text = "www.hackerz.in.th"

        ElseIf ComboBox1.Text = "Bitcoin [BTC]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/bitcoin_price.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/bitcoin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox2.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else

                    Dim num1, num2, num3 As Double
                    num1 = TextBox2.Text
                    num2 = Label1.Text
                    num3 = num1 * num2
                    TextBox3.Text = FormatNumber(num3, 2)
                    TextBox10.Text = FormatNumber(num3 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / TextBox3.Text, 8)

                End If

            End If

        ElseIf ComboBox1.Text = "Bitcoin Cash (BCH)" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/bitcoin-cash.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/bitcoin-cash/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "BitBay (BAY)" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/bitbay.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/bitbay/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "CampusCoin [CMPCO]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/campuscoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/campuscoin/"
            If Len(WebBrowser3.DocumentText) <= 11 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "CHIPS (CHIPS)" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/chips.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/chips/"
            If Len(WebBrowser3.DocumentText) <= 11 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "DeepOnion [ONION]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/deeponion.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/deeponion/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Dogecoin (DOGE)" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/dogecoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/dogecoin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If


        ElseIf ComboBox1.Text = "EA Coin (EAG)" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/ea-coin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/ea-coin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Enigma [XNG]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/enigma.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/enigma/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Eotcoin (EOT)" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/eotcoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/eot-token/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Ethereum (ETH)" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/ethereum.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/ethereum/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If



        ElseIf ComboBox1.Text = "Happycoin [HPC]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/happycoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/happycoin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "HTMLCOIN [HTML5]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/htmlcoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/htmlcoin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Huncoin [HNC]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/huncoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/huncoin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Levocoin [LEVO]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/levocoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/levocoin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Litecoin (LTC)" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/litecoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/litecoin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Madcoin [MDC]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/madcoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/madcoin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If


        ElseIf ComboBox1.Text = "Mincoin [MNC]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/mincoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/mincoin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "OmiseGO (OMG)" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/omisego.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/omisego/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Onix [ONX]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/onix.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/onix/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Peercoin [PPC]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/peercoin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/peercoin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If


        ElseIf ComboBox1.Text = "Santa Coin [STC]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/santa.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/santa-coin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If
            End If

        

        ElseIf ComboBox1.Text = "Swing [SWING]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/swing.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/swing/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Theresa May Coin [MAY]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/theresa-may-coin.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/theresa-may-coin/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "Walton [WTC]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/walton.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/walton/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        ElseIf ComboBox1.Text = "XGOX [XGOX]" Then
            'เว็บดึงราคาปัจจุบัน
            TextBox1.Text = "https://hackerz.in.th/bitcoin/api/xgox.php"
            'เว็บเช็คราคา
            TextBox4.Text = "https://coinmarketcap.com/currencies/xgox/"
            If Len(WebBrowser3.DocumentText) <= 10 Then
                TextBox16.Text = WebBrowser3.DocumentText
                If ComboBox2.Text = "" Then
                Else
                    Dim num1, num2, num3, num4, num5 As Double


                    ' มูลค่าBTCของเหรียญ
                    num1 = TextBox16.Text
                    'ราคา BTC USD ปัจจุบัน
                    num2 = ToolStripStatusLabel1.Text
                    'ราคาบาทไทยปัจจุบัน
                    num3 = Label1.Text

                    'BTC * ราคาขายusd ปัจจุบัน
                    num4 = num1 * num2

                    'แสดงราคาขาย USD ของเหรียญนี้
                    TextBox2.Text = FormatNumber(num4, 2)

                    num5 = num4 * num3 ' แปลงดอลล่าเป็นบาทไทย
                    TextBox3.Text = FormatNumber(num5, 2)


                    TextBox10.Text = FormatNumber(num5 * ComboBox2.Text, 2)
                    'นำ จำนวนเงินบาทที่ประมวลผลแล้วมาหารกับราคาขาย BTC ปัจจุบัน จะได้ มูลค่าของบาทแปลงเป็น BTC
                    TextBox17.Text = FormatNumber(TextBox10.Text / ToolStripStatusLabel3.Text, 8)
                End If

            End If

        Else 'เมื่อไม่เจอเหรียญที่ค้นหา ให้แสดงผลข้างล่างนี้


        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If

        If ComboBox1.Text = "" Then
            MsgBox("ไม่พบข้อมูลเหรียญในระบบ", , "แจ้งเตือน")
        Else
            TextBox2.Text = "0.00"
            TextBox3.Text = "0.00"
            prgBar.Value = 0
            WebBrowser3.Navigate(TextBox1.Text)
            Timer4.Start()
        End If
    End Sub

    Private Sub WebBrowser3_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser3.DocumentCompleted

    End Sub

    Private Sub WebBrowser3_ProgressChanged(sender As Object, e As WebBrowserProgressChangedEventArgs) Handles WebBrowser3.ProgressChanged


        
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick

        prgBar.Increment(5)
        If prgBar.Value = "100" Then
            Timer4.Stop()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If

        Application.Restart()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(TextBox4.Text)
    End Sub

    ' textbox11 ใส่ได้แค่ตัวเลข
    
    




    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If

        If TextBox5.Text = "" Then
            MsgBox("ห้ามมีช่องว่าง และ กรุณากรอกเพียงตัวเลขเท่านั้น", , "แจ้งเตือน")
        ElseIf TextBox5.Text = " " Then
        Else
            Dim cookie1, cookie2, cookie3, cookie4 As Double
            ' คำนวณ เอา BTC * ราคาขายปัจจุบัน
            cookie1 = TextBox5.Text
            cookie4 = ToolStripStatusLabel1.Text
            cookie2 = cookie1 * cookie4
            TextBox6.Text = FormatNumber(cookie2, 2)
            'เอาดอลล่าที่คำนวณได้ * ค่าเงินบาทไทยปัจจุบัน
            cookie3 = (cookie2 * Label1.Text) * TextBox11.Text
            'แสดงผลลัพธ์
            TextBox9.Text = FormatNumber(cookie3, 2)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        If TextBox8.Text = "" Then
            MsgBox("ห้ามมีช่องว่าง และ กรุณากรอกเพียงตัวเลขเท่านั้น", , "แจ้งเตือน")
        ElseIf TextBox8.Text = " " Then
        Else
            Dim cookie1, cookie2, cookie3 As Double
            cookie1 = TextBox8.Text
            cookie2 = ToolStripStatusLabel3.Text
            'เอา จำนวนเงิน THB / ราคาขาย THB ของ BTC จะได้มูลค่าของ BTC
            cookie3 = (cookie1 / cookie2) * TextBox14.Text
            'แสดงผลลัพธ์
            TextBox7.Text = FormatNumber(cookie3, 10)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        If TextBox13.Text = "" Then
            MsgBox("ห้ามมีช่องว่าง และ กรุณากรอกเพียงตัวเลขเท่านั้น", , "แจ้งเตือน")
        ElseIf TextBox13.Text = " " Then
        Else

            Dim cookie1, cookie2, cookie3 As Double
            cookie1 = TextBox13.Text
            cookie2 = ToolStripStatusLabel1.Text
            'เอา จำนวนเงิน USD / ราคาขาย USD ของ BTC จะได้มูลค่าของ BTC
            cookie3 = (cookie1 / cookie2) * TextBox15.Text

            'แสดงผลลัพธ์
            TextBox12.Text = FormatNumber(cookie3, 10)
        End If
    End Sub

    Private Sub Markerlnwz2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Markerlnwz2ToolStripMenuItem.Click
            Process.Start("http://103.233.194.211/")
    End Sub





    Private Sub ออกจากโปรแกรมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ออกจากโปรแกรมToolStripMenuItem.Click
            End
    End Sub

    Private Sub PoloniexcomToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PoloniexcomToolStripMenuItem1.Click
            Process.Start("https://poloniex.com")
    End Sub

    Private Sub CoinsmarketscomToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CoinsmarketscomToolStripMenuItem1.Click
            Process.Start("https://coinsmarkets.com")
    End Sub



    Private Sub CoinbxcomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoinbxcomToolStripMenuItem.Click
            Process.Start("https://coinbx.com")
    End Sub

    Private Sub BxinthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BxinthToolStripMenuItem.Click
        Process.Start("https://bx.in.th/ref/DYMIwe/")
    End Sub

    

    

   

    Private Sub MiningrigrentalscomToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MiningrigrentalscomToolStripMenuItem1.Click
        Process.Start("https://www.miningrigrentals.com/?ref=49737")
    End Sub

    Private Sub NicehashcomToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NicehashcomToolStripMenuItem1.Click
        Process.Start("https://www.nicehash.com")
    End Sub

    Private Sub GenesisminingcomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenesisminingcomToolStripMenuItem.Click

    End Sub

    Private Sub CheckUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckUpdatesToolStripMenuItem.Click
        Process.Start("launcher.exe")
        End
    End Sub

    Private Sub PatchNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatchNoteToolStripMenuItem.Click
        note_update.Show()
    End Sub

    Private Sub เชคตลาดซอขายToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เชคตลาดซอขายToolStripMenuItem.Click
        MsgBox("ยังไม่เปิดการใช้งาน รอการอัพเดทโปรแกรม :)", , "แจ้งเตือน")
    End Sub

    Private Sub AboutหลกการโปรแกรมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutหลกการโปรแกรมToolStripMenuItem.Click
        about.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        'ล้างค่าให้ว่างเปล่า
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox9.Text = ""
        TextBox11.Text = "1"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        'ล้างค่าให้ว่างเปล่า
        TextBox8.Text = ""
        TextBox7.Text = ""
        TextBox14.Text = "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        'ล้างค่าให้ว่างเปล่า
        TextBox13.Text = ""
        TextBox12.Text = ""
        TextBox15.Text = "1"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick

        If My.Settings.test1 = "1" Then
            My.Settings.bitcoin_up = "1"

        ElseIf My.Settings.test2 = "1" Then
            My.Settings.bitcoin_down = "1"

        End If


        Timer5.Stop()
    End Sub

    Private Sub ตงคาToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ตงคาToolStripMenuItem.Click
        setting.Show()
    End Sub

    Private Sub หองแชทToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles หองแชทToolStripMenuItem.Click
        chat.Show()
    End Sub

    Private Sub ถอนขนตำคาธรรมเนยมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ถอนขนตำคาธรรมเนยมToolStripMenuItem.Click
        Process.Start("https://coinsmarkets.com/fees.php")
    End Sub

   
    Private Sub เหรยญทนาลงทนในตอนนToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เหรยญทนาลงทนในตอนนToolStripMenuItem.Click
        MsgBox("ยังไม่เปิดการใช้งาน รอการอัพเดทโปรแกรม :)", , "แจ้งเตือน")
        coinstatus.Show()
    End Sub

    Private Sub คำนวณราคาBitcoinรวงหนาToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles คำนวณราคาBitcoinรวงหนาToolStripMenuItem.Click
        MsgBox("ยังไม่เปิดการใช้งาน รอการอัพเดทโปรแกรม :)", , "แจ้งเตือน")
        btcstatus.Show()
    End Sub

    Private Sub แกไขโปรแกรมไมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles แกไขโปรแกรมไมToolStripMenuItem.Click
        File.WriteAllText("client.ini", New String(Conversions.ToCharArrayRankOne("0.0.0.0")).ToString)
        MessageBox.Show("แก้ไขการเช็ค Update โปรแกรมแล้ว กรุณาลอง Check Updates อีกครั้ง โปรแกรมจะทำการ Update ใหม่เป็นเวอร์ชั่นล่าสุด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Private Sub USDTradeTHBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles USDTradeTHBToolStripMenuItem.Click
        cal.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub วธการTradeคาธรรมเนยมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles วธการTradeคาธรรมเนยมToolStripMenuItem.Click
        menu_coinmarket.Show()
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        MsgBox("แปลง BTC เป็น USD = จำนวน BTC * ราคาขายBTC(USD)ปัจจุบัน" & vbLf & "แปลง BTC เป็น THB = จำนวน BTC * ราคาขายBTC(THB)ปัจจุบัน", , "แจ้งเตือน")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        MsgBox("แปลง THB เป็น BTC = จำนวนเงินบาท / ราคาBTC(THB)ปัจจุบัน", , "แจ้งเตือน")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        MsgBox("แปลง USD เป็น BTC = จำนวนเงินUSD / ราคาBTC(USD)ปัจจุบัน", , "แจ้งเตือน")
    End Sub

   

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        wallet.Show()
    End Sub

    Private Sub PopupแจงเตอนเลกๆToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PopupแจงเตอนเลกๆToolStripMenuItem.Click
        popup1.Show()
    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        Dim t40, t41, t42, t43, t44, t45, t46, t47, t48, t49, t50, t51, t52, t53 As Double


        t40 = Label26.Text * ToolStripStatusLabel3.Text
        t41 = Label27.Text * ToolStripStatusLabel3.Text
        t42 = Label28.Text * ToolStripStatusLabel3.Text
        t43 = Label29.Text * ToolStripStatusLabel3.Text
        t44 = Label30.Text * ToolStripStatusLabel3.Text
        t45 = Label31.Text * ToolStripStatusLabel3.Text
        t46 = Label32.Text * ToolStripStatusLabel3.Text
        t47 = Label33.Text * ToolStripStatusLabel3.Text
        t48 = Label34.Text * ToolStripStatusLabel3.Text
        t49 = Label35.Text * ToolStripStatusLabel3.Text
        t50 = Label36.Text * ToolStripStatusLabel3.Text
        t51 = Label37.Text * ToolStripStatusLabel3.Text
        t52 = Label38.Text * ToolStripStatusLabel3.Text
        t53 = Label39.Text * ToolStripStatusLabel3.Text

        Label40.Text = FormatNumber(t40, 2)
        Label41.Text = FormatNumber(t41, 2)
        Label42.Text = FormatNumber(t42, 2)
        Label43.Text = FormatNumber(t43, 2)
        Label44.Text = FormatNumber(t44, 2)
        Label45.Text = FormatNumber(t45, 2)
        Label46.Text = FormatNumber(t46, 2)
        Label47.Text = FormatNumber(t47, 2)
        Label48.Text = FormatNumber(t48, 2)
        Label49.Text = FormatNumber(t49, 2)
        Label50.Text = FormatNumber(t50, 2)
        Label51.Text = FormatNumber(t51, 2)
        Label52.Text = FormatNumber(t52, 2)
        Label53.Text = FormatNumber(t53, 2)
    End Sub

    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        WebBrowser1.Navigate(TextBox18.Text)

        WebBrowser6.Navigate("https://hackerz.in.th/bitcoin/api/bitcoin_price.php")
        WebBrowser7.Navigate("https://hackerz.in.th/bitcoin/api/bitcoin_priceth.php")
        Timer7.Stop()
    End Sub

    Private Sub Timer8_Tick(sender As Object, e As EventArgs) Handles Timer8.Tick
        'EN
        WebBrowser6.Navigate("https://hackerz.in.th/bitcoin/api/bitcoin_price.php")
        'TH
        WebBrowser7.Navigate("https://hackerz.in.th/bitcoin/api/bitcoin_priceth.php")
    End Sub

    Private Sub Timer9_Tick(sender As Object, e As EventArgs) Handles Timer9.Tick
        Dim markerz1, markerz2, markerz3, markerz4 As Double
        
        'EN
        If Len(WebBrowser6.DocumentText) = "8" Then
            markerz1 = WebBrowser6.DocumentText
            markerz3 = markerz1 * Label1.Text

            Label59.Text = FormatNumber(markerz3, 2)

            ProgressBar2.Value = Label59.Text
        ElseIf Len(WebBrowser6.DocumentText) = "7" Then
            markerz1 = WebBrowser6.DocumentText
            markerz3 = markerz1 * Label1.Text

            Label59.Text = FormatNumber(markerz3, 2)

            ProgressBar2.Value = Label59.Text

        End If

        'TH
        If Len(WebBrowser7.DocumentText) = "8" Then
            markerz2 = WebBrowser7.DocumentText
            markerz4 = markerz2 * Label1.Text
            Label58.Text = (FormatNumber(markerz4, 2))

            ProgressBar1.Value = Label58.Text
        ElseIf Len(WebBrowser7.DocumentText) = "7" Then
            markerz2 = WebBrowser7.DocumentText
            markerz4 = markerz2 * Label1.Text
            Label58.Text = (FormatNumber(markerz4, 2))

            ProgressBar1.Value = Label58.Text

        End If




    End Sub

    
   

    Private Sub CoinexchangeioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoinexchangeioToolStripMenuItem.Click
        Process.Start("https://www.coinexchange.io")
    End Sub

    Private Sub TradesatoshicomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TradesatoshicomToolStripMenuItem.Click
        Process.Start("https://tradesatoshi.com")
    End Sub

    Private Sub เรมขดเหรยญดวยPoolEasyRigsForPoolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เรมขดเหรยญดวยPoolEasyRigsForPoolsToolStripMenuItem.Click
        MsgBox("รอการ Update เพิ่มเติม", , "แจ้งเตือน")
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If

        If TextBox21.Text = "" Or TextBox23.Text = "" Then
            MsgBox("ห้ามมีช่องว่าง และ กรุณากรอกเพียงตัวเลขเท่านั้น", , "แจ้งเตือน")
        Else
            If RadioButton1.Checked = True Then 'THB
                Dim cookie1, cookie2, cookie3, cookie4, cookie5 As Double
                cookie1 = TextBox21.Text * TextBox23.Text

                'แสดงผลลัพธ์ THB
                cookie5 = cookie1 * TextBox19.Text
                TextBox20.Text = FormatNumber(cookie1, 2)
                'แสดงผลลัพธ์ USD
                cookie3 = Label1.Text
                cookie2 = cookie1 / cookie3
                cookie4 = cookie2 * TextBox19.Text
                TextBox22.Text = FormatNumber(cookie4, 2)

            ElseIf RadioButton2.Checked = True Then 'USD
                Dim cookie1, cookie2, cookie3, cookie4, cookie5 As Double
                cookie1 = TextBox21.Text * TextBox23.Text

                'แสดงผลลัพธ์ THB
                cookie3 = Label1.Text
                cookie2 = cookie1 * cookie3
                cookie5 = cookie2 * TextBox19.Text
                TextBox20.Text = FormatNumber(cookie5, 2)

                'แสดงผลลัพธ์ USD
                cookie4 = cookie1 * TextBox19.Text
                TextBox22.Text = FormatNumber(cookie4, 2)

            End If


        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If

        TextBox21.Text = "0"
        TextBox22.Text = "0"
        TextBox23.Text = "0"
        TextBox20.Text = "0"

        TextBox19.Text = "1"
    End Sub

    Private Sub CoinExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoinExplorerToolStripMenuItem.Click
        Process.Start("https://hackerz.in.th/bitcoin/explorer/index.php")
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        TextBox26.Text = FormatNumber(TextBox24.Text * TextBox25.Text, 8)
    End Sub

    Private Sub DDoSAttackerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DDoSAttackerToolStripMenuItem.Click

    End Sub

    Private Sub PoolServer2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PoolServer2ToolStripMenuItem.Click
        Process.Start("http://miningpool.shop")
    End Sub

    Private Sub PoolServer3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PoolServer3ToolStripMenuItem.Click
        Process.Start("http://coinminers.net/getting_started")
    End Sub

    Private Sub StocksexchangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StocksexchangeToolStripMenuItem.Click
        Process.Start("https://stocks.exchange")
    End Sub

    Private Sub YobitnetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YobitnetToolStripMenuItem.Click
        Process.Start("https://yobit.net/en/")
    End Sub

    Private Sub คำนวณความเสยงเหรยญตางๆToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles คำนวณความเสยงเหรยญตางๆToolStripMenuItem.Click
        reward.Show()
    End Sub

    Private Sub IngpoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngpoolToolStripMenuItem.Click
        Process.Start("http://ns2.ingpool.tk")
    End Sub

    Private Sub ตดตอToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ตดตอToolStripMenuItem.Click

    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        test.Show()
    End Sub

    Private Sub ระบบเตอนราคาขายToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ระบบเตอนราคาขายToolStripMenuItem.Click
        bx1.Show()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click

        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If

        TextBox27.Text = FormatNumber(Int(TextBox28.Text) + Int(TextBox29.Text), 8)
    End Sub

    Private Sub StatusStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

End Class
