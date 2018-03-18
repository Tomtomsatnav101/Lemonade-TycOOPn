Public Class Log_in
    Public newplayer As player
    Public taken As Boolean
    Public number As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
        Else
            For i As Integer = 1 To Database.usercount
                If Database.database(i).username = TextBox1.Text And Database.database(i).password = TextBox2.Text Then
                    newplayer = New humanPlayer

                    newplayer.setlemons(Database.database(i).lemons)            'Form1.Label4.Text = Database.database(i).lemons.ToString

                    newplayer.setsugar(Database.database(i).sugar)              'Form1.Label5.Text = Database.database(i).sugar.ToString

                    newplayer.setice(Database.database(i).ice)                  'Form1.Label7.Text = Database.database(i).ice.ToString

                    newplayer.setmoney(Database.database(i).money)              'Form1.Label2.Text = Database.database(i).money.ToString

                    Form1.Label12.Text = Database.database(i).profit.ToString
                    newplayer.totalsales = Database.database(i).customers
                    Form1.Label3.Text = Database.database(i).reputation.ToString
                    Form1.Label6.Text = Database.database(i).expected.ToString


                    Me.Hide()
                    Form1.Show()
                    number = i

                Else
                End If
            Next
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
            Database.usercount += 1
            newplayer = New humanPlayer
        End If
    End Sub

End Class