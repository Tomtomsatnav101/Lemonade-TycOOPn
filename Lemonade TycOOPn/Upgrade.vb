Public Class Upgrade

    Private Sub Upgrade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Log_in.newplayer.getmoney()           'Sets the money label
        If Log_in.newplayer.getupgradeMultiplier = 2 Then       'If the upgrade hasn't been gotten yet, show the button
            Button2.Visible = False
        End If
    End Sub
    Private Sub Upgrade_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Label2.Text = Log_in.newplayer.getmoney()               'Updates money label
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Log_in.newplayer.setmoney(-100)                 'buys the upgrade and removes the button
        Label2.Text = Log_in.newplayer.getmoney()
        Log_in.newplayer.setupgradeMultiplier(2 * Log_in.newplayer.getupgradeMultiplier)        'sets the new upgrade multiplier
        Button2.Visible = False
        Log_in.newplayer.setmoneybefore(Log_in.newplayer.getmoney)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()        'allows the user to leave
    End Sub
    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Hide()
        Form1.Show()        'If the form is closed, the user is taken back to the main screen
    End Sub

End Class