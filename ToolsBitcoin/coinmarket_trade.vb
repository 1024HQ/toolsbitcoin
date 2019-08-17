Imports System.Net

Public Class coinmarket_trade

    Private Sub coinmarket_trade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

    End Sub

   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("https://coinsmarkets.com/fees.php")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WebBrowser1.Navigate("https://hackerz.in.th/bitcoin/update/trade.txt")
    End Sub
End Class