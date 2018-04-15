Public Class Form1
    Dim addstock As Integer
    Public weather As Integer

    Private Sub GetStock(lemon, sugar, ice)
        If addstock = 1 Then
            If Log_in.newplayer.getmoney() >= lemon Then
                Log_in.newplayer.setlemons(lemon)
                Log_in.newplayer.setmoney(-lemon)

                Label2.Text = Log_in.newplayer.getmoney()
            Else
                MsgBox("Not enough money!")
            End If
        ElseIf addstock = 2 Then
            If Log_in.newplayer.getmoney() >= sugar Then
                Log_in.newplayer.setsugar(sugar)
                Log_in.newplayer.setmoney(-sugar)

                Label2.Text = Log_in.newplayer.getmoney()
            Else
                MsgBox("Not enough money!")
            End If
        ElseIf addstock = 3 Then
            If Log_in.newplayer.getmoney() >= ice Then
                Log_in.newplayer.setice(ice)
                Log_in.newplayer.setmoney(-ice)

                Label2.Text = Log_in.newplayer.getmoney()
            Else
                MsgBox("Not enough money!")
            End If
        End If

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addstock = 1
        GetStock(HScrollBar1.Value, 0, 0)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        addstock = 2
        GetStock(0, HScrollBar1.Value, 0)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        addstock = 3
        GetStock(0, 0, HScrollBar1.Value)
    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Button1.Text = HScrollBar1.Value.ToString + " Lemons!"
        Button6.Text = HScrollBar1.Value.ToString + " Sugar!"
        Button9.Text = HScrollBar1.Value.ToString + " Ice!"
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Log_in.newplayer.setmoney((CInt(Label4.Text) + CInt(Label5.Text) + CInt(Label7.Text)) * 0.9)
        Log_in.newplayer.setlemons(-CInt(Label4.Text))
        Log_in.newplayer.setsugar(-CInt(Label5.Text))
        Log_in.newplayer.setice(-CInt(Label7.Text))
        Log_in.newplayer.setmoneybefore(Log_in.newplayer.getmoney)
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Me.Hide()
        Upgrade.Show()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Me.Hide()
        Leaderboard.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Hide()
        Composition.Label4.Text = Log_in.newplayer.getlemons()
        Composition.Label5.Text = Log_in.newplayer.getsugar()
        Composition.Label6.Text = Log_in.newplayer.getice()
        Composition.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Randomize()

        weather = CInt(Rnd() * 2)
        If weather = 0 Then
            PictureBox6.ImageLocation = "U:\Pictures\sunny.PNG"
            MsgBox("Sunny")
        ElseIf weather = 1 Then
            PictureBox6.ImageLocation = "U:\Pictures\cold.PNG"
            MsgBox("Cold")
        ElseIf weather = 2 Then
            PictureBox6.ImageLocation = "U:\Pictures\meh.png"
            MsgBox("Meh")
        Else

        End If

        'Log_in.newplayer.setmoneybefore(Log_in.newplayer.getmoney)
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Database.database(Log_in.number).money = Log_in.newplayer.getmoney
        Database.database(Log_in.number).score = Log_in.newplayer.getmoney      'Change to score if have the time
        Database.database(Log_in.number).totalsales = Log_in.newplayer.gettotalsales
        Database.database(Log_in.number).lemons = Log_in.newplayer.getlemons
        Database.database(Log_in.number).sugar = Log_in.newplayer.getsugar
        Database.database(Log_in.number).ice = Log_in.newplayer.getice
        Database.database(Log_in.number).reputation = Log_in.newplayer.getreputation
        Database.database(Log_in.number).expected = Log_in.newplayer.getexpected
        Database.database(Log_in.number).upgradeMultiplier = Log_in.newplayer.getupgradeMultiplier

        Database.database(Log_in.number).ailemons = Log_in.newaiplayer.getlemons
        Database.database(Log_in.number).aisugar = Log_in.newaiplayer.getsugar
        Database.database(Log_in.number).aiice = Log_in.newaiplayer.getice
        Database.database(Log_in.number).aitotalsales = Log_in.newaiplayer.gettotalsales
        Database.database(Log_in.number).aimoney = Log_in.newaiplayer.getmoney
        Database.database(Log_in.number).aireputation = Log_in.newaiplayer.getreputation
        Database.database(Log_in.number).aiexpected = Log_in.newaiplayer.getexpected
        Database.database(Log_in.number).aiscore = Log_in.newaiplayer.getmoney     'Change to score if have the time
        Database.database(Log_in.number).aiupgradeMultiplier = Log_in.newaiplayer.getupgradeMultiplier
        Database.database(Log_in.number).aicounter = Log_in.newplayer.getaicounter

        Database.write()

        End
    End Sub
    Private Sub Panel2_MouseHover(sender As Object, e As EventArgs) Handles Panel2.MouseHover
        Label8.Text = ""
    End Sub
    Private Sub Form1_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
        Label8.Text = ""
    End Sub
    Private Sub Panel3_MouseHover(sender As Object, e As EventArgs) Handles Panel3.MouseHover
        Label8.Text = ""
    End Sub
    Private Sub Panel1_MouseHover(sender As Object, e As EventArgs) Handles Panel1.MouseHover
        Label8.Text = ""
    End Sub
    Private Sub Label3_MouseHover(sender As Object, e As EventArgs) Handles Label3.MouseHover
        Label8.Text = "Yesterday you served " + Log_in.newplayer.getactualsales.ToString + " people"
    End Sub
    Private Sub Label4_MouseHover(sender As Object, e As EventArgs) Handles Label4.MouseHover
        Label8.Text = "Yesterday you sold " + (Log_in.newplayer.getactualsales * CInt(Composition.TextBox1.Text)).ToString + " lemons"
    End Sub
    Private Sub Label5_MouseHover(sender As Object, e As EventArgs) Handles Label5.MouseHover
        Label8.Text = "Yesterday you sold " + (Log_in.newplayer.getactualsales * CInt(Composition.TextBox2.Text)).ToString + " sugar"
    End Sub
    Private Sub Label7_MouseHover(sender As Object, e As EventArgs) Handles Label7.MouseHover
        Label8.Text = "Yesterday you sold " + (Log_in.newplayer.getactualsales * CInt(Composition.TextBox3.Text)).ToString + " ice"
    End Sub
    Private Sub Button20_MouseHover(sender As Object, e As EventArgs) Handles Button20.MouseHover
        Label8.Text = "Press this button if you have accicdently bought too much stock. It will sell it all back, for a small loss, but will ensure all your customers remain happy"
    End Sub
    Private Sub Button21_MouseHover(sender As Object, e As EventArgs) Handles Button21.MouseHover
        Label8.Text = "Press this button to access the upgrade screen"
    End Sub
    Private Sub Label6_MouseHover(sender As Object, e As EventArgs) Handles Label6.MouseHover
        Label8.Text = "This number is a forcast of how many customers you will encounter today. As it is an estimate, the real number may vary, so plan accordingly"
    End Sub
    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        weather = 2
        PictureBox6.ImageLocation = "U:\Pictures\meh.png"
        MsgBox("Meh")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        weather = 0
        MsgBox("sun")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        weather = 1
        MsgBox("Cold")
    End Sub
End Class



Public Class player

    Protected lemons As Integer
    Protected ice As Integer
    Protected sugar As Integer

    Protected reputation As Double
    Protected varience As Integer
    Protected actualsales As Integer
    Protected deviation As Double

    Protected ideallemon As Double
    Protected idealice As Double
    Protected idealsugar As Double
    Protected compositions(2) As Double


    Protected profit As Integer
    Protected moneybefore As Integer
    Protected moneyafter As Integer
    Protected totalsales As Integer
    Protected money As Integer
    Protected expected As Integer

    Protected upgradeMultiplier As Integer
    Protected weatherMultiplier As Integer
    Protected salesMultiplier As Double

    Protected aicounter As Integer


    Private Number As Integer 'Ordinal number of the player in the database


    Sub New()

        'If Log_in.aitrue = True Then
        If Log_in.taken = 0 Then
            If Log_in.first = True Then
                If Log_in.aitrue = False Then
                    Database.database(Database.usercount).username = Log_in.TextBox1.Text
                    Database.database(Database.usercount).password = Log_in.TextBox2.Text

                    Form1.Label4.Text = 0
                    lemons = 0
                    Database.database(Log_in.number).lemons = 0

                    Form1.Label5.Text = 0
                    sugar = 0
                    Database.database(Log_in.number).sugar = 0

                    Form1.Label7.Text = 0
                    ice = 0
                    Database.database(Log_in.number).ice = 0

                    Form1.Label12.Text = 0
                    profit = 0

                    totalsales = 1
                    Database.database(Log_in.number).totalsales = 1

                    Form1.Label2.Text = 1000
                    money = 1000
                    Database.database(Log_in.number).money = 1000

                    Form1.Label3.Text = 0.5
                    reputation = 0.5
                    Database.database(Log_in.number).reputation = 0.5

                    Form1.Label6.Text = 100
                    expected = 100
                    Database.database(Log_in.number).expected = 100

                    upgradeMultiplier = 1

                    aicounter = 0

                    'MsgBox("Test1")
                    Number = usercount
                    moneybefore = 1000
                    Log_in.Hide()
                    Form1.Show()
                Else
                    lemons = 0
                    Database.database(Log_in.number).ailemons = 0

                    sugar = 0
                    Database.database(Log_in.number).aisugar = 0

                    ice = 0
                    Database.database(Log_in.number).aiice = 0

                    profit = 0

                    totalsales = 1
                    Database.database(Log_in.number).aitotalsales = 1

                    money = 1000
                    Database.database(Log_in.number).aimoney = 1000

                    reputation = 0.5
                    Database.database(Log_in.number).aireputation = 0.5

                    expected = 100
                    Database.database(Log_in.number).aiexpected = 100

                    upgradeMultiplier = 1

                    Number = usercount
                    moneybefore = 1000
                    'MsgBox("test2")
                End If
            ElseIf Log_in.first = False Then

                If Log_in.aitrue = False Then
                    Form1.Label2.Text = Database.database(Log_in.number).money.ToString
                    money = Database.database(Log_in.number).money.ToString

                    totalsales = Database.database(Log_in.number).totalsales

                    Form1.Label4.Text = Database.database(Log_in.number).lemons.ToString
                    lemons = Database.database(Log_in.number).lemons

                    Form1.Label7.Text = Database.database(Log_in.number).ice
                    ice = Database.database(Log_in.number).ice

                    Form1.Label5.Text = Database.database(Log_in.number).sugar
                    sugar = Database.database(Log_in.number).sugar

                    Form1.Label3.Text = Database.database(Log_in.number).reputation
                    reputation = Database.database(Log_in.number).reputation

                    Form1.Label6.Text = Database.database(Log_in.number).expected
                    expected = Database.database(Log_in.number).expected

                    upgradeMultiplier = Database.database(Log_in.number).upgradeMultiplier

                    aicounter = Database.database(Log_in.number).aicounter

                    moneybefore = money
                    'MsgBox("Test3")
                Else
                    money = Database.database(Log_in.number).aimoney.ToString

                    totalsales = Database.database(Log_in.number).aitotalsales

                    lemons = Database.database(Log_in.number).ailemons

                    ice = Database.database(Log_in.number).aiice

                    sugar = Database.database(Log_in.number).aisugar

                    reputation = Database.database(Log_in.number).aireputation

                    expected = Database.database(Log_in.number).aiexpected

                    upgradeMultiplier = Database.database(Log_in.number).aiupgradeMultiplier

                    moneybefore = money
                    'MsgBox("test4")

                End If
            End If
        Else
            MsgBox("Username is taken")
        End If
    End Sub
    Function getaicounter()
        Return aicounter
    End Function
    Function setaicounter(addaicounter As Integer)
        aicounter += addaicounter
    End Function
    ''''''
    Function getmoney()
        Return money
    End Function
    Overridable Function setmoney(addmoney As Integer)
        money += addmoney
        Form1.Label2.Text = Log_in.newplayer.getmoney()
    End Function

    Function getlemons()
        Return lemons
    End Function
    Overridable Function setlemons(addlemons As Integer)
        lemons += addlemons
        Form1.Label4.Text = Log_in.newplayer.getlemons()

    End Function

    Function getice()
        Return ice
    End Function
    Overridable Function setice(addice As Integer)
        ice += addice
        Form1.Label7.Text = Log_in.newplayer.getice()
    End Function

    Function getsugar()
        Return sugar
    End Function
    Overridable Function setsugar(addsugar As Integer)
        sugar += addsugar
        Form1.Label5.Text = Log_in.newplayer.getsugar()
    End Function

    Function getreputation()
        Return reputation
    End Function
    Overridable Function setreputation(addreputation As Double)
        reputation += addreputation
        Form1.Label3.Text = Log_in.newplayer.getreputation()
    End Function

    Function getprofit()
        Return profit
    End Function
    Overridable Function setprofit(addprofit As Double)
        profit = addprofit
        Form1.Label12.Text = Math.Round(addprofit).ToString
    End Function
    ''''''
    Function getmoneybefore()
        Return moneybefore
    End Function
    Function setmoneybefore(addmoneybefore As Integer)
        moneybefore = addmoneybefore
    End Function

    Function getmoneyafter()
        Return moneyafter
    End Function
    Function setmoneyafter(addmoneyafter As Integer)
        moneyafter = addmoneyafter
    End Function

    Function setvarience(addvarience As Integer)
        varience = addvarience
    End Function
    Function getvarience()
        Return varience
    End Function

    Function setdeviation(adddeviation As Integer)
        deviation = adddeviation
    End Function
    Function getdeviation()
        Return deviation
    End Function

    Function setideallemon(addideallemon As Double)
        ideallemon = addideallemon
    End Function
    Function getideallemon()
        Return ideallemon
    End Function

    Function setidealice(addidealice As Double)
        idealice = addidealice
    End Function
    Function getidealice()
        Return idealice
    End Function

    Function setidealsugar(addidealsugar As Double)
        idealsugar = addidealsugar
    End Function
    Function getidealsugar()
        Return idealsugar
    End Function

    Function setcompositions(number As Integer, addcompositions As Integer)
        compositions(number) = addcompositions
    End Function
    Function getcompositions(number As Integer)
        Return compositions(number)
    End Function

    Function getexpected()
        Return expected
    End Function
    Function setexpected(addexpected As Double)
        expected += addexpected
    End Function

    Function getactualsales()
        Return actualsales
    End Function
    Function setactualsales(addactualsales As Integer)
        actualsales = addactualsales
    End Function

    Function getupgradeMultiplier()
        Return upgradeMultiplier
    End Function
    Function setupgradeMultiplier(addupgradeMultiplier As Integer)
        upgradeMultiplier = addupgradeMultiplier
    End Function

    Function getweatherMultiplier()
        Return weatherMultiplier
    End Function
    Function setweatherMultiplier(addweatherMultiplier As Integer)
        weatherMultiplier = addweatherMultiplier
    End Function

    Function getsalesMultiplier()
        Return salesMultiplier
    End Function
    Function setsalesMultiplier(addsalesMultiplier As Double)
        salesMultiplier = addsalesMultiplier
    End Function

    Function gettotalsales()
        Return totalsales
    End Function
    Function settotalsales(addtotalsales As Integer)
        totalsales += addtotalsales
    End Function

    Overridable Sub getsales(tempsales As Integer)

        Dim num As New Random
        varience = (num.Next(-10, 10))

        deviation = (varience * reputation)

        expected += deviation



        If expected <= tempsales Then
            actualsales = expected
        Else
            actualsales = tempsales
        End If
    End Sub

    Overridable Sub getweather(templemon As Integer, tempsugar As Integer, tempice As Integer)
        lemons -= actualsales * templemon
        sugar -= actualsales * tempsugar
        ice -= actualsales * tempice

        compositions(0) = templemon
        compositions(1) = tempsugar
        compositions(2) = tempice

        ideallemon = compositions(0) / (compositions(0) + compositions(1) + compositions(2))
        idealsugar = compositions(1) / (compositions(0) + compositions(1) + compositions(2))
        idealice = compositions(2) / (compositions(0) + compositions(1) + compositions(2))

        If Form1.weather = 2 And (ideallemon + idealsugar + idealice) = 1 Then
            weatherMultiplier = 2
            MsgBox("MEHHY")
        ElseIf Form1.weather = 0 And ideallemon = 2 * idealsugar And idealice = 3 * idealsugar Then
            weatherMultiplier = 2
            MsgBox("SUNNY")
        ElseIf Form1.weather = 1 And ideallemon = idealice And idealsugar = 2 * idealice Then
            weatherMultiplier = 2
            MsgBox("COLD")
        Else
            weatherMultiplier = 1
        End If

        totalsales += actualsales

        Form1.Label4.Text = lemons.ToString
        Form1.Label5.Text = sugar.ToString
        Form1.Label7.Text = ice.ToString

        'MEH 1 lemon, 1 ice, 1 sugar

        'SUNNY 2 lemon, 3 ice, 1 sugar

        'COLD 1 lemon, 1 ice, 2 sugar
    End Sub

    Overridable Sub getprogress()

        salesMultiplier = ((Math.Log10(totalsales)) / 100) + 1
        Try
            If Math.Log10(totalsales) >= 5 Then
                Composition.ProgressBar1.Value = 5
            Else
                Composition.ProgressBar1.Value = Math.Log10(totalsales)
            End If
        Catch ex As exception
        End Try

    End Sub

    Overridable Sub getprofits(templemon As Integer, tempsugar As Integer, tempice As Integer)

        Dim smallprofit As Integer
        Dim bigprofit As Double

        bigprofit = (((templemon + tempsugar + tempice) * actualsales) * salesMultiplier)
        smallprofit = bigprofit - ((templemon + tempsugar + tempice) * actualsales)

        money += (bigprofit + (upgradeMultiplier - 1) * smallprofit + (weatherMultiplier - 1) * smallprofit)

        moneyafter = money


        profit = moneyafter - moneybefore

        Form1.Label12.Text = profit.ToString
        Form1.Label2.Text = money.ToString

        If profit < 0 Then
            Form1.PictureBox5.ImageLocation = "U:\Pictures\redprofit.png"
            Form1.Label12.ForeColor = Color.Red
        ElseIf profit > 0 Then
            Form1.PictureBox5.ImageLocation = "U:\Pictures\profit.png"
            Form1.Label12.ForeColor = Color.Green
        Else
            Form1.Label12.ForeColor = Color.Black
        End If
    End Sub

    Overridable Sub getreputations()
        If actualsales = expected Then

            If reputation >= 1.5 Then
            Else
                reputation += 0.1
                expected += expected * 0.1
            End If
        Else
            If reputation <= 0.5 Then
            Else
                reputation -= 0.1
                expected -= expected * 0.1
            End If
        End If

        If weatherMultiplier = 2 Then
            If reputation >= 1.5 Then
            Else
                reputation += 0.1
                expected += expected * 0.1
            End If
        Else
            If reputation <= 0.5 Then
            ElseIf weatherMultiplier = 1 Then
                reputation -= 0.1
                expected -= expected * 0.1
            End If
        End If

        Form1.Label3.Text = reputation
        Form1.Label6.Text = expected

        moneybefore = money
    End Sub

    Sub Getstar()

        If reputation > 0.6 Then
            Form1.PictureBox7.ImageLocation = "U:\Pictures\Star.Png"
            If reputation > 0.8 Then
                Form1.PictureBox8.ImageLocation = "U:\Pictures\Star.Png"
                If reputation > 1 Then
                    Form1.PictureBox9.ImageLocation = "U:\Pictures\Star.Png"
                    If reputation > 1.2 Then
                        Form1.PictureBox10.ImageLocation = "U:\Pictures\Star.Png"
                        If reputation > 1.4 Then
                            Form1.PictureBox11.ImageLocation = "U:\Pictures\Star.Png"
                        Else
                            Form1.PictureBox11.ImageLocation = Nothing
                        End If
                    Else
                        Form1.PictureBox10.ImageLocation = Nothing
                    End If
                Else
                    Form1.PictureBox9.ImageLocation = Nothing
                End If
            Else
                Form1.PictureBox8.ImageLocation = Nothing
            End If
        Else
            Form1.PictureBox7.ImageLocation = Nothing
        End If
    End Sub

    Sub setweather()
        Randomize()

        Form1.weather = CInt(Rnd() * 2)
        If Form1.weather = 0 Then
            Form1.PictureBox6.ImageLocation = "U:\Pictures\sunny.PNG"
            MsgBox("Sunny")
        ElseIf Form1.weather = 1 Then
            Form1.PictureBox6.ImageLocation = "U:\Pictures\cold.PNG"
            MsgBox("Cold")
        ElseIf Form1.weather = 2 Then
            Form1.PictureBox6.ImageLocation = "U:\Pictures\meh.png"
            MsgBox("Meh")
        Else

        End If
    End Sub


    Overridable Sub calculate(tempsales As Integer, templemon As Integer, tempsugar As Integer, tempice As Integer)
        getsales(tempsales)
        getweather(templemon, tempsugar, tempice)
        getprogress()
        getprofits(templemon, tempsugar, tempice)
        getreputations()
        Getstar()

    End Sub

End Class

Public Class humanPlayer
    Inherits player
End Class

Public Class AIPlayer
    Inherits player
    Private trial(4, 1002) As Integer      'lemon | Sugar | Ice | Weather | weatherMultiplier
    Private trialcounter As Integer = 0

    Overrides Function setmoney(addmoney As Integer)
        money += addmoney
    End Function
    Overrides Function setlemons(addlemons As Integer)
        lemons += addlemons
    End Function
    Overrides Function setsugar(addsugar As Integer)
        sugar += addsugar
    End Function
    Overrides Function setice(addice As Integer)
        ice += addice
    End Function
    Overrides Function setreputation(addreputation As Double)
        reputation += addreputation
    End Function
    Overrides Function setprofit(addprofit As Double)
        profit = addprofit
    End Function

    'Sub Learn() 'tempsales As Integer, templemon As Integer, tempsugar As Integer, tempice As Integer, weather As Integer)


    '    For i As Integer = 0 To trialcounter
    '        If trial(3, i) = Form1.weather Then
    '            For j As Integer = 0 To 2
    '                MsgBox(trial(j, i).ToString)
    '            Next
    '        End If
    '    Next




    'End Sub




    Overrides Sub calculate(tempsales As Integer, templemon As Integer, tempsugar As Integer, tempice As Integer)

        getsales(tempsales)
        getweather(trial(0, trialcounter), trial(1, trialcounter), trial(2, trialcounter))
        getprogress()
        getprofits(trial(0, trialcounter), trial(1, trialcounter), trial(2, trialcounter))
        getreputations()


        'For i As Integer = 0 To trialcounter - 1
        '    For j As Integer = 0 To 4
        '        MsgBox("trial(" + j.ToString + "," + i.ToString + ") = " + trial(j, i).ToString)
        '    Next

        'Next
        trialcounter += 1
    End Sub

    Overrides Sub getsales(tempsales As Integer)
        Dim num As New Random
        varience = (num.Next(-10, 10))

        deviation = (varience * reputation)

        expected += deviation

        actualsales = expected

        'This is where it looks at the weather and sees if it either has the best combination, and a multiple of it, or just randomly tries again
        Dim found As Boolean = 0


        For i As Integer = 1 To 10
            For j As Integer = 0 To trialcounter - 1
                If trial(0, j) Mod i = 0 And trial(1, j) Mod i = 0 And trial(2, j) Mod i = 0 Then           'Cancels out common factors
                    trial(0, j) = (trial(0, j) / i)
                    trial(1, j) = (trial(1, j) / i)
                    trial(2, j) = (trial(2, j) / i)
                End If
            Next
        Next


        found = 0
        For i As Integer = 0 To trialcounter - 1
            If trial(3, i) = Form1.weather And trial(4, i) = 2 Then
                trial(0, trialcounter) = trial(0, i)                    'Checks to see if a solution that gets the multiplier has been discovered
                trial(1, trialcounter) = trial(1, i)
                trial(2, trialcounter) = trial(2, i)
                found = 1
                MsgBox("found = " + found.ToString)
                MsgBox("Ideal for " + Form1.weather.ToString + "=" + trial(0, i).ToString + " " + trial(1, i).ToString + " " + trial(2, i).ToString)
            End If
        Next


        If found = 1 Then
            money = money - actualsales * (trial(0, trialcounter) + trial(1, trialcounter) + trial(2, trialcounter))
        ElseIf found = 0 Then


            Do
                Randomize()
                trial(0, trialcounter) = CInt(Math.Ceiling(Rnd() * 4))
                Randomize()
                trial(1, trialcounter) = CInt(Math.Ceiling(Rnd() * 4))                                                                'Randomly generates composition if optimal one hasnt been discovered yet
                Randomize()
                trial(2, trialcounter) = CInt(Math.Ceiling(Rnd() * 4))

                If actualsales * (trial(0, trialcounter) + trial(1, trialcounter) + trial(2, trialcounter)) > money Then
                Else
                    money = money - actualsales * (trial(0, trialcounter) + trial(1, trialcounter) + trial(2, trialcounter))
                    MsgBox("test.,,,,,,,")
                    MsgBox("found = " + found.ToString)
                    Exit Do
                End If
            Loop
        Else
        End If
    End Sub

    Overrides Sub getweather(templemon As Integer, tempsugar As Integer, tempice As Integer)
        lemons -= actualsales * templemon
        sugar -= actualsales * tempsugar
        ice -= actualsales * tempice
        compositions(0) = templemon
        compositions(1) = tempsugar
        compositions(2) = tempice

        ideallemon = compositions(0) / (compositions(0) + compositions(1) + compositions(2))
        idealsugar = compositions(1) / (compositions(0) + compositions(1) + compositions(2))
        idealice = compositions(2) / (compositions(0) + compositions(1) + compositions(2))

        If Form1.weather = 2 And ideallemon = idealsugar And idealsugar = idealice Then
            weatherMultiplier = 2
            MsgBox(" AI  ***** MEHHY ")
        ElseIf Form1.weather = 0 And ideallemon = 2 * idealsugar And idealice = 3 * idealsugar Then
            weatherMultiplier = 2
            MsgBox("AI        ***********SUNNY")
        ElseIf Form1.weather = 1 And ideallemon = idealice And idealsugar = 2 * idealice Then
            weatherMultiplier = 2
            MsgBox("AI   *****COLD")
        Else
            weatherMultiplier = 1
            MsgBox("FAIL = " + trial(0, trialcounter).ToString + trial(1, trialcounter).ToString + trial(2, trialcounter).ToString)
        End If

        totalsales += actualsales
        trial(3, trialcounter) = Form1.weather
        trial(4, trialcounter) = weatherMultiplier

        'MEH 1 lemon, 1 ice, 1 sugar

        'SUNNY 2 lemon, 3 ice, 1 sugar

        'COLD 1 lemon, 1 ice, 2 sugar

        If weatherMultiplier = 2 Then
            MsgBox("composition = " + trial(0, trialcounter).ToString + trial(1, trialcounter).ToString + trial(2, trialcounter).ToString + "weather = " + Form1.weather.ToString)
        End If



    End Sub

    Overrides Sub getprogress()
        salesMultiplier = ((Math.Log10(totalsales)) / 100) + 1
    End Sub

    Overridable Sub getprofits(templemon As Integer, tempsugar As Integer, tempice As Integer)

        Dim smallprofit As Integer
        Dim bigprofit As Integer

        bigprofit = (((templemon + tempsugar + tempice) * actualsales) * salesMultiplier)
        smallprofit = bigprofit - ((templemon + tempsugar + tempice) * actualsales)

        money += (bigprofit + (weatherMultiplier - 1) * smallprofit)

        moneyafter = money
        'MsgBox("expected = " + expected.ToString)
        'MsgBox("bigprofit = " + bigprofit.ToString)
        'MsgBox("smallprofit = " + smallprofit.ToString)
        'MsgBox("money = " + money.ToString)
        profit = moneyafter - moneybefore

    End Sub

    Overrides Sub getreputations()
        If actualsales = expected Then

            If reputation >= 1.5 Then
            Else
                reputation += 0.1
                expected += expected * 0.1
            End If
        Else
            If reputation <= 0.5 Then
            Else
                reputation -= 0.1
                expected -= expected * 0.1
            End If
        End If

        If weatherMultiplier = 2 Then
            If reputation >= 1.5 Then
            Else
                reputation += 0.1
                expected += expected * 0.1
            End If
        Else
            If reputation <= 0.5 Then
            ElseIf weatherMultiplier = 1 Then
                reputation -= 0.1
                expected -= expected * 0.1
            End If
        End If

        moneybefore = money
    End Sub

End Class
