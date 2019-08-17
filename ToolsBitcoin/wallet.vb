Imports System.Net
Imports Microsoft.VisualBasic.CompilerServices
Imports System.IO
Public Class wallet
    Public WithEvents download As WebClient

    Private Sub download_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles download.DownloadProgressChanged
        ProgressBar1.value = e.ProgressPercentage
    End Sub
    Private Sub wallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        download = New WebClient
        ' textbox1 คือ ลิ้งโหลด textbox2 คือที่อยู่ไฟล์ที่จะไปไว้
        download.DownloadFileAsync(New Uri(TextBox1.Text), TextBox4.Text)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox4.Text = ComboBox1.Text + TextBox3.Text
        Label3.Text = ProgressBar1.Value

        

        If ComboBox1.Text = "Bitpaycoin[BP]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/Bitpaycoin-Qt.rar"

        ElseIf ComboBox1.Text = "Crypto[CTO]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/crypto-qt.rar"

        ElseIf ComboBox1.Text = "Dotcoin[DOT]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/dotcoin-qt.rar"

        ElseIf ComboBox1.Text = "Enigmacoin[XNG]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/Enigmacoin-qt.rar"

        ElseIf ComboBox1.Text = "Eotcoin[EOT]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/eotcoin-wallet.rar"

        ElseIf ComboBox1.Text = "Frazcoin[FRAZ]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/frazcoin-qt.rar"


        ElseIf ComboBox1.Text = "GanjaCoin[MRJA]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/GanjaProject-qt.rar"

        ElseIf ComboBox1.Text = "InterstellarHoldings[HOLD]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/InterstellarHoldings-qt.rar"

        ElseIf ComboBox1.Text = "Joincoin[J]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/joincoin-qt.rar"

        ElseIf ComboBox1.Text = "Madcoin[MDC]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/MadCoin-1.0.0.1.rar"

        ElseIf ComboBox1.Text = "Mincoin[MNC]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/mincoin-0.8.8.0-win32.rar"

        ElseIf ComboBox1.Text = "Mlccoin[MLC]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/mlccoin-qt.rar"

        ElseIf ComboBox1.Text = "Opcoin[OPC]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/OPCoin-qt.rar"

        ElseIf ComboBox1.Text = "Ozziecoin[OZC]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/ozziecoin-qt.rar"

        ElseIf ComboBox1.Text = "SantaCoin[STC]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/santa-qt.rar"

        ElseIf ComboBox1.Text = "Swipp[SWP]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/swipp-qt.rar"

        ElseIf ComboBox1.Text = "Vgina[VGINA]" Then
            Button1.Enabled = True
            TextBox1.Text = "https://hackerz.in.th/bitcoin/wallet/Vgina-Multisend-QT.rar"
        Else
            Button1.Enabled = False

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        MsgBox("เป็นเพียงระบบดาวน์โหลดกระเป๋า wallet ซึ่งได้รวบรวมมาไว้แล้วที่นี่ หากไม่มีประเป๋า wallet สำหรับใช้เก็บเหรียญ ก็สามารถดาวน์โหลดได้ที่นี่ โดยใช้ในการเก็บเหรียญต่างๆ สามารถสร้าง wallet มารับเหรียญได้ โดยไฟล์ที่ดาวน์โหลดจะเป็นสกุล .rar ท่านต้องไปแยกไฟล์เองอีกทีเพื่อใช้งาน", , "แจ้งเตือน")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'เล่นเสียงปุ่ม
        If My.Settings.button = "1" Then
            My.Computer.Audio.Play(My.Resources.button, AudioPlayMode.Background)
        End If
        Process.Start(".\")
    End Sub
End Class