Public Class Log_in
    Public newplayer As player
    Public taken As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
        Else

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
        Else

            taken = False
            For i As Integer = 1 To Database.usercount
                If TextBox1.Text = Database.database(i).username Then      'Checks to see if username is taken already
                    taken = 1
                End If
            Next



            'If taken = 0 Then
            '    Dim newplayer As player = New player
            '    Me.Hide()
            '    Form1.Show()
            'Else
            '    MsgBox("Username is taken")
            'End If

            newplayer = New humanPlayer
        End If
    End Sub

End Class