Public Class Composition


    Public aifirst As Boolean = Nothing






    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Hide()
        Form1.Show()
    End Sub

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

        ' Try
        If CInt(TextBox1.Text) * CInt(TextBox4.Text) <= Log_in.newplayer.getlemons Or CInt(TextBox2.Text) * CInt(TextBox4.Text) <= Log_in.newplayer.getsugar Or CInt(TextBox3.Text) * CInt(TextBox4.Text) <= Log_in.newplayer.getice Then

            Dim tempsales As Integer = CInt(TextBox4.Text)
            Dim templemon As Integer = TextBox1.Text
            Dim tempsugar As Integer = TextBox2.Text
            Dim tempice As Integer = TextBox3.Text



            'Log_in.newplayer.getsales(tempsales)
            ' Log_in.newaiplayer.learn(tempsales, templemon, tempsugar, tempice, Form1.weather)
            'Log_in.newplayer.getweather(templemon, tempsugar, tempice)


            'Log_in.newplayer.settotalsales(Log_in.newplayer.getactualsales)

            'Log_in.newplayer.getprogress()

            'Log_in.newplayer.getprofits(templemon, tempsugar, tempice)

            'Log_in.newplayer.getreputations()

            'Log_in.newplayer.getstar()

            'Log_in.newplayer.setmoneybefore(Log_in.newplayer.getmoney)

            Log_in.newplayer.calculate(tempsales, templemon, tempsugar, tempice)

            If Log_in.newplayer.getaicounter = 0 Then
                Log_in.taken = 0
                Log_in.aitrue = True
                aifirst = 1
                Log_in.newaiplayer = New AIPlayer
                Log_in.newplayer.setaicounter(1)
                MsgBox("A new lemmonade stand has set up in your area")
            ElseIf Log_in.newplayer.getaicounter < 0 Then
                Log_in.newplayer.setaicounter(1)
            ElseIf Log_in.newplayer.getaicounter > 0 Then
                Log_in.newaiplayer.calculate(tempsales, templemon, tempsugar, tempice)
            End If


            Log_in.newplayer.setweather()




            Me.Hide()
            Form1.Show()

        Else
            MsgBox("Error. Not enough ingridients")
        End If
        'Catch ex As Exception
        '    MsgBox("Check your ingredients")
        ' End Try
    End Sub


    Private Sub Composition_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Hide()
        Form1.Show()
    End Sub

    'Sub getsales()
    '    Dim num As New Random
    '    Log_in.newplayer.setvarience(num.Next(-10, 10))

    '    Log_in.newplayer.setdeviation(Log_in.newplayer.getvarience * Log_in.newplayer.getreputation) 'If this works i'll be so proud of myself

    '    Log_in.newplayer.setexpected(Log_in.newplayer.getdeviation)


    '    If Log_in.newplayer.getexpected <= CInt(TextBox4.Text) Then
    '        Log_in.newplayer.setactualsales(Log_in.newplayer.getexpected)
    '    Else
    '        Log_in.newplayer.setactualsales(CInt(TextBox4.Text))
    '    End If
    'End Sub

    'Sub weather()
    '    Log_in.newplayer.setlemons(-1 * Log_in.newplayer.getactualsales * CInt(TextBox1.Text))
    '    Log_in.newplayer.setsugar(-1 * Log_in.newplayer.getactualsales * CInt(TextBox2.Text))
    '    Log_in.newplayer.setice(-1 * Log_in.newplayer.getactualsales * CInt(TextBox3.Text))

    '    Log_in.newplayer.setcomposition(0, CInt(TextBox1.Text))
    '    Log_in.newplayer.setcomposition(1, CInt(TextBox2.Text))
    '    Log_in.newplayer.setcomposition(2, CInt(TextBox3.Text))

    '    Log_in.newplayer.setideallemon(Log_in.newplayer.getcomposition(0) / (Log_in.newplayer.getcomposition(0) + Log_in.newplayer.getcomposition(1) + Log_in.newplayer.getcomposition(2)))
    '    Log_in.newplayer.setidealsugar(Log_in.newplayer.getcomposition(1) / (Log_in.newplayer.getcomposition(0) + Log_in.newplayer.getcomposition(1) + Log_in.newplayer.getcomposition(2)))
    '    Log_in.newplayer.setidealice(Log_in.newplayer.getcomposition(2) / (Log_in.newplayer.getcomposition(0) + Log_in.newplayer.getcomposition(1) + Log_in.newplayer.getcomposition(2)))

    '    If Form1.weather = 2 And (Log_in.newplayer.getideallemon + Log_in.newplayer.getidealsugar + Log_in.newplayer.getidealice) = 1 Then
    '        Log_in.newplayer.setweatherMultiplier(2)
    '        MsgBox("MEHHY")
    '    ElseIf Form1.weather = 0 And Log_in.newplayer.getideallemon = 2 * Log_in.newplayer.getidealsugar And Log_in.newplayer.getidealice = 3 * Log_in.newplayer.getidealsugar Then
    '        Log_in.newplayer.setweatherMultiplier(2)
    '        MsgBox("SUNNY")
    '    ElseIf Form1.weather = 1 And Log_in.newplayer.getideallemon = Log_in.newplayer.getidealice And Log_in.newplayer.getidealsugar = 2 * Log_in.newplayer.getidealice Then
    '        Log_in.newplayer.setweatherMultiplier(2)
    '        MsgBox("COLD")
    '    Else
    '        Log_in.newplayer.setweatherMultiplier(1)
    '    End If

    '    'MEH 1 lemon, 1 ice, 1 sugar

    '    'SUNNY 2 lemon, 3 ice, 1 sugar

    '    'COLD 1 lemon, 1 ice, 2 sugar
    'End Sub

    'Sub progress()
    '    Log_in.newplayer.setsalesMultiplier(((Math.Log10(Log_in.newplayer.gettotalsales)) / 100) + 1)

    '    If Math.Log10(Log_in.newplayer.gettotalsales) >= 5 Then
    '        ProgressBar1.Value = 5
    '    Else
    '        ProgressBar1.Value = Math.Log10(Log_in.newplayer.gettotalsales)
    '    End If
    'End Sub

    'Sub getprofit()
    '    Dim smallprofit As Integer
    '    Dim bigprofit As Integer

    '    bigprofit = (((CInt(TextBox1.Text) + CInt(TextBox2.Text) + CInt(TextBox3.Text)) * Log_in.newplayer.getactualsales) * Log_in.newplayer.getsalesMultiplier)
    '    smallprofit = bigprofit - ((CInt(TextBox1.Text) + CInt(TextBox2.Text) + CInt(TextBox3.Text)) * Log_in.newplayer.getactualsales)

    '    Log_in.newplayer.setmoney(bigprofit + (Log_in.newplayer.getupgradeMultiplier - 1) * smallprofit + (Log_in.newplayer.getweatherMultiplier - 1) * smallprofit)

    '    Log_in.newplayer.setmoneyafter(Log_in.newplayer.getmoney)


    '    Log_in.newplayer.setprofit(Log_in.newplayer.getmoneyafter - Log_in.newplayer.getmoneybefore)

    '    Form1.Label12.Text = Log_in.newplayer.getprofit.ToString


    '    If Log_in.newplayer.getprofit < 0 Then
    '        Form1.PictureBox5.ImageLocation = "U:\Pictures\redprofit.png"
    '        Form1.Label12.ForeColor = Color.Red
    '    ElseIf Log_in.newplayer.getprofit > -1 Then
    '        Form1.PictureBox5.ImageLocation = "U:\Pictures\profit.png"
    '        Form1.Label12.ForeColor = Color.Green
    '    Else
    '        Form1.Label12.ForeColor = Color.Black
    '    End If
    'End Sub

    'Sub getreputation()
    '    If Log_in.newplayer.getactualsales = Log_in.newplayer.getexpected Then

    '        If Log_in.newplayer.getreputation >= 1.5 Then
    '        Else
    '            Log_in.newplayer.setreputation(0.1)
    '            Log_in.newplayer.setexpected(Log_in.newplayer.getexpected * 0.1)
    '        End If
    '    Else
    '        If Log_in.newplayer.getreputation <= 0.5 Then
    '        Else
    '            Log_in.newplayer.setreputation(-0.1)
    '            Log_in.newplayer.setexpected(Log_in.newplayer.getexpected * -0.1)
    '        End If
    '    End If

    '    If Log_in.newplayer.getweatherMultiplier = 2 Then
    '        If Log_in.newplayer.getreputation >= 1.5 Then
    '        Else
    '            Log_in.newplayer.setreputation(0.1)
    '            Log_in.newplayer.setexpected(Log_in.newplayer.getexpected * 0.1)
    '        End If
    '    Else
    '        If Log_in.newplayer.getreputation <= 0.5 Then
    '        ElseIf Log_in.newplayer.getweatherMultiplier = 1 Then
    '            Log_in.newplayer.setreputation(-0.1)
    '            Log_in.newplayer.setexpected(Log_in.newplayer.getexpected * -0.1)
    '        End If
    '    End If

    '    Form1.Label3.Text = Log_in.newplayer.getreputation
    '    Form1.Label6.Text = Log_in.newplayer.getexpected
    'End Sub

    'Public Sub Getstar()

    '    If Log_in.newplayer.getreputation > 0.6 Then
    '        Form1.PictureBox7.ImageLocation = "U:\Pictures\Star.Png"
    '        If Log_in.newplayer.getreputation > 0.8 Then
    '            Form1.PictureBox8.ImageLocation = "U:\Pictures\Star.Png"
    '            If Log_in.newplayer.getreputation > 1 Then
    '                Form1.PictureBox9.ImageLocation = "U:\Pictures\Star.Png"
    '                If Log_in.newplayer.getreputation > 1.2 Then
    '                    Form1.PictureBox10.ImageLocation = "U:\Pictures\Star.Png"
    '                    If Log_in.newplayer.getreputation > 1.4 Then
    '                        Form1.PictureBox11.ImageLocation = "U:\Pictures\Star.Png"
    '                    Else
    '                        Form1.PictureBox11.ImageLocation = Nothing
    '                    End If
    '                Else
    '                    Form1.PictureBox10.ImageLocation = Nothing
    '                End If
    '            Else
    '                Form1.PictureBox9.ImageLocation = Nothing
    '            End If
    '        Else
    '            Form1.PictureBox8.ImageLocation = Nothing
    '        End If
    '    Else
    '        Form1.PictureBox7.ImageLocation = Nothing
    '    End If
    'End Sub

End Class