Public Class Composition
    Public aifirst As Boolean = Nothing     'The boolean that saves weatehr this is a new ai or a loaded one from the database

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Hide()
        Form1.Show()            'Allows the user to go back the the main screen without selling anything
    End Sub
    'These buttons add one to the textbox next to them
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = CInt(TextBox1.Text) + 1
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox2.Text = CInt(TextBox2.Text) + 1
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox3.Text = CInt(TextBox3.Text) + 1
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox4.Text = CInt(TextBox4.Text) + 1
    End Sub
    'these buttons remove one from the textbox next to them, unless the value in them is 0
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "0" Then
        Else
            TextBox1.Text = CInt(TextBox1.Text) - 1
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox2.Text = "0" Then
        Else
            TextBox2.Text = CInt(TextBox2.Text) - 1
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox3.Text = "0" Then
        Else
            TextBox3.Text = CInt(TextBox3.Text) - 1
        End If
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If TextBox4.Text = "0" Then
        Else
            TextBox4.Text = CInt(TextBox4.Text) - 1
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            If ((CInt(TextBox1.Text) * CInt(TextBox4.Text)) <= Log_in.newplayer.getlemons) And (CInt(TextBox2.Text) * CInt(TextBox4.Text) <= Log_in.newplayer.getsugar) And (CInt(TextBox3.Text) * CInt(TextBox4.Text) <= Log_in.newplayer.getice) Then 'Makes sure the user can afford each of the stock they want to use



                Dim tempsales As Integer = CInt(TextBox4.Text)      'The number of drinks they want to make
                Dim templemon As Integer = TextBox1.Text            'The number of each stock in each drink
                Dim tempsugar As Integer = TextBox2.Text
                Dim tempice As Integer = TextBox3.Text


                Log_in.newplayer.calculate(tempsales, templemon, tempsugar, tempice)        'The sub that takes in the users composition, and handles profits, multipliers and reputation


                If Log_in.newplayer.getaicounter = 0 Then
                    Log_in.taken = 0
                    Log_in.aitrue = True            'uses the new to create a new ai player
                    aifirst = 1
                    Log_in.newaiplayer = New AIPlayer
                    Log_in.newplayer.setaicounter(1)
                    MsgBox("A new lemmonade stand has set up in your area")
                ElseIf Log_in.newplayer.getaicounter < 0 Then
                    Log_in.newplayer.setaicounter(1)               'adds one to the ai counter to bring the ai one day closer to being created
                ElseIf Log_in.newplayer.getaicounter > 0 Then
                    Log_in.newaiplayer.calculate(tempsales, templemon, tempsugar, tempice)          'Calculates the ai's profit and other values once it exists
                End If


                Log_in.newplayer.setweather()               'Randomly generates the weatehr for the next day


                Me.Hide()
                Form1.Show()

            Else
                MsgBox("Error. Not enough ingridients")
            End If
        Catch ex As Exception
            MsgBox("Check your ingredients")
        End Try
    End Sub

    Private Sub Composition_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Hide()           'When the form is closed, send the user back to the main screen
        Form1.Show()
    End Sub
End Class