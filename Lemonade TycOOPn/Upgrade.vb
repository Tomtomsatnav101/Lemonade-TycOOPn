Public Class Upgrade

    Private Sub Upgrade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Log_in.newplayer.getmoney()
        If Log_in.newplayer.getupgradeMultiplier = 2 Then
            Button2.Visible = False
        End If
    End Sub
    Private Sub Upgrade_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Label2.Text = Log_in.newplayer.getmoney()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Log_in.newplayer.setmoney(-100)
        Label2.Text = Log_in.newplayer.getmoney()
        Log_in.newplayer.setupgradeMultiplier(2 * Log_in.newplayer.getupgradeMultiplier)
        Button2.Visible = False
        Log_in.newplayer.setmoneybefore(Log_in.newplayer.getmoney)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
    End Sub
    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Hide()
        Form1.Show()
    End Sub

End Class