Public Class Form1
    Dim addstock As Integer     'Saves which stock will be added, so that the same sub can be 0
    Public weather As Integer   'The weather needs to be accessed in the composition form

    Private Sub GetStock(lemon, sugar, ice)
        If addstock = 1 Then
            If Log_in.newplayer.getmoney() >= lemon Then
                Log_in.newplayer.setlemons(lemon)           'if the player has enough money, add the value scroll bar to their total stock, and take it away from their money
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
        GetStock(HScrollBar1.Value, 0, 0)       'Sets the appropriate addstock and add that stock to their reserves
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
        Button1.Text = HScrollBar1.Value.ToString + " Lemons!"      'Changes the labels according to thee scroll bar value
        Button6.Text = HScrollBar1.Value.ToString + " Sugar!"
        Button9.Text = HScrollBar1.Value.ToString + " Ice!"
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Log_in.newplayer.setmoney((CInt(Label4.Text) + CInt(Label5.Text) + CInt(Label7.Text)) * 0.9)        'Calculates the liquidate refund, which is 90% of what they had
        Log_in.newplayer.setlemons(-CInt(Label4.Text))
        Log_in.newplayer.setsugar(-CInt(Label5.Text))
        Log_in.newplayer.setice(-CInt(Label7.Text))
        Log_in.newplayer.setmoneybefore(Log_in.newplayer.getmoney)
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Me.Hide()
        Upgrade.Show()  'Opens upgrade screen
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Me.Hide()
        Leaderboard.Show()  'Opens leaderboard screen
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Hide()
        Composition.Label4.Text = Log_in.newplayer.getlemons()              'Opens cmposition screen
        Composition.Label5.Text = Log_in.newplayer.getsugar()
        Composition.Label6.Text = Log_in.newplayer.getice()
        Composition.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Randomize()

        weather = CInt(Rnd() * 2)
        If weather = 0 Then
            PictureBox6.ImageLocation = "U:\Pictures\sunny.PNG"
            MsgBox("Sunny")                                             'Randomly generates the weather when the form first loads
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
        Database.database(Log_in.number).score = Log_in.newplayer.getmoney
        Database.database(Log_in.number).totalsales = Log_in.newplayer.gettotalsales
        Database.database(Log_in.number).lemons = Log_in.newplayer.getlemons
        Database.database(Log_in.number).sugar = Log_in.newplayer.getsugar
        Database.database(Log_in.number).ice = Log_in.newplayer.getice
        Database.database(Log_in.number).reputation = Log_in.newplayer.getreputation
        Database.database(Log_in.number).expected = Log_in.newplayer.getexpected
        Database.database(Log_in.number).upgradeMultiplier = Log_in.newplayer.getupgradeMultiplier              'All of these variables are being written to the database upon closing

        Database.database(Log_in.number).ailemons = Log_in.newaiplayer.getlemons
        Database.database(Log_in.number).aisugar = Log_in.newaiplayer.getsugar
        Database.database(Log_in.number).aiice = Log_in.newaiplayer.getice
        Database.database(Log_in.number).aitotalsales = Log_in.newaiplayer.gettotalsales
        Database.database(Log_in.number).aimoney = Log_in.newaiplayer.getmoney
        Database.database(Log_in.number).aireputation = Log_in.newaiplayer.getreputation
        Database.database(Log_in.number).aiexpected = Log_in.newaiplayer.getexpected
        Database.database(Log_in.number).aiscore = Log_in.newaiplayer.getmoney
        Database.database(Log_in.number).aiupgradeMultiplier = Log_in.newaiplayer.getupgradeMultiplier
        Database.database(Log_in.number).aicounter = Log_in.newplayer.getaicounter

        Database.write()                    'Add the users info to the database

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

    Protected lemons As Integer                 'Stock levels
    Protected ice As Integer
    Protected sugar As Integer

    Protected reputation As Double          'The number that determines how the users customer base grows
    Protected varience As Integer           'Represents the random uncontrollable change in customers from day to day
    Protected actualsales As Integer        'How many sales the user has on a day. Not just how many they plan to have, but how many drinks they actually sell
    Protected deviation As Double           'varience * reputation - how many customers the day actually differs from planned

    Protected ideallemon As Double
    Protected idealice As Double            'The users ratios of stock in their drinks
    Protected idealsugar As Double
    Protected compositions(2) As Double


    Protected profit As Integer         'How much money the user makes in a day
    Protected moneybefore As Integer    'How much money the user has before buying stock
    Protected moneyafter As Integer     'How much money the user has after selling stock
    Protected totalsales As Integer     'The total number of drinks ever sold
    Protected money As Integer          'The users money
    Protected expected As Integer       'How many customers the user if forecast to have, before deviation

    Protected upgradeMultiplier As Integer      'The profit boost the user has due to any upgrades they've bought
    Protected weatherMultiplier As Integer      'The profit boost the user has due to the weather bonus
    Protected salesMultiplier As Double         'The profit boost the user has due to the users past sales

    Protected aicounter As Integer              'How many turns the player has played before the ai appears


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
                    Database.database(Log_in.number).sugar = 0              'Sets the humanPlayers stats if it is a new player

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
                    Database.database(Log_in.number).aitotalsales = 1           'Sets the aiplayers values if it is a new player

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

                    Form1.Label4.Text = Database.database(Log_in.number).lemons.ToString                'Sets the humanPlayers values if the player is signing in to an old account
                    lemons = Database.database(Log_in.number).lemons                                    'This data is read from the relavent database slots

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

                    totalsales = Database.database(Log_in.number).aitotalsales                  'Sets the aiPlayers values if the player is singing into an old account. This data is read from the database

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
            MsgBox("Username is taken")                         'If there has been an issue creating a new player because the log-in details weren't correct
        End If
    End Sub
    Function getaicounter()
        Return aicounter
    End Function
    Function setaicounter(addaicounter As Integer)
        aicounter += addaicounter
    End Function

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
        varience = (num.Next(-10, 10))              'Randomly generates a number between -10 and 10

        deviation = (varience * reputation)         ' The actual customers can change randomly by a small amount to simulate real life. AS your reputation grows, the maximum deviation increases from 5 to 15

        expected += deviation



        If expected <= tempsales Then               'If you have made more lemonade then you can sell with the amount of customers you have, you sell one lemonade to each customer and have surplus
            actualsales = expected
        Else
            actualsales = tempsales                 'If you have made less lemonade than you can sell, you sell all you made, and cant satisfy demand
        End If
    End Sub

    Overridable Sub getweather(templemon As Integer, tempsugar As Integer, tempice As Integer)
        lemons -= actualsales * templemon
        sugar -= actualsales * tempsugar                'Removes stock in the relavent amounts
        ice -= actualsales * tempice

        compositions(0) = templemon
        compositions(1) = tempsugar
        compositions(2) = tempice

        ideallemon = compositions(0) / (compositions(0) + compositions(1) + compositions(2))
        idealsugar = compositions(1) / (compositions(0) + compositions(1) + compositions(2))            'Works out relative ratios of each stock in the drink
        idealice = compositions(2) / (compositions(0) + compositions(1) + compositions(2))

        If Form1.weather = 2 And (ideallemon + idealsugar + idealice) = 1 Then          'If each stock is in the drink in the same quantites, and the weather is meh, the ideal meh weather is achieved
            weatherMultiplier = 2
            MsgBox("MEHHY")
        ElseIf Form1.weather = 0 And ideallemon = 2 * idealsugar And idealice = 3 * idealsugar Then         'if  the ratio of l:s:i = 2:3:1, and the weather is sunny, the ideal sunny weather is achieved
            weatherMultiplier = 2
            MsgBox("SUNNY")
        ElseIf Form1.weather = 1 And ideallemon = idealice And idealsugar = 2 * idealice Then       'If the ratio of l:s:i = 1:2:1, and the weather is cold, the ideal cold weather is achieved
            weatherMultiplier = 2
            MsgBox("COLD")
        Else
            weatherMultiplier = 1
        End If

        totalsales += actualsales           'Add the sales of today to the total sales

        Form1.Label4.Text = lemons.ToString         'Update stock levels
        Form1.Label5.Text = sugar.ToString
        Form1.Label7.Text = ice.ToString

        'MEH 1 lemon, 1 ice, 1 sugar

        'SUNNY 2 lemon, 3 ice, 1 sugar

        'COLD 1 lemon, 1 ice, 2 sugar
    End Sub

    Overridable Sub getprogress()

        salesMultiplier = ((Math.Log10(totalsales)) / 100) + 1          'Works out the multiplier you get based of the total past sales of the player. Uses a log to stop exponential growth in the end game
        Try
            If Math.Log10(totalsales) >= 5 Then
                Composition.ProgressBar1.Value = 5          'Updates the sales bar - a visual representation of the users sales multiplier
            Else
                Composition.ProgressBar1.Value = Math.Log10(totalsales)
            End If
        Catch ex As exception
        End Try

    End Sub

    Overridable Sub getprofits(templemon As Integer, tempsugar As Integer, tempice As Integer)

        Dim bigprofit As Double         'The big profit is the total money made from selling lemonade on a day - usually in the 100s
        Dim smallprofit As Integer      'The small profit is how much the users total money change from one day to the next - usually in the 10s


        bigprofit = (((templemon + tempsugar + tempice) * actualsales) * salesMultiplier)      'Calculates how mush the stock sells for based on sales and the sales multiplier
        smallprofit = bigprofit - ((templemon + tempsugar + tempice) * actualsales)         'Small profit is the big profit, minus the cost of buying all the stock in the first place

        money += (bigprofit + (upgradeMultiplier - 1) * smallprofit + (weatherMultiplier - 1) * smallprofit)        'upgrades and weather effect the small profit, usually be doubling it

        moneyafter = money


        profit = moneyafter - moneybefore       'Works out the profit from one day to the next by comparing the money before buying stock and the money after selling it

        Form1.Label12.Text = profit.ToString        'Updates profit and money labels
        Form1.Label2.Text = money.ToString

        If profit < 0 Then
            Form1.PictureBox5.ImageLocation = "U:\Pictures\redprofit.png"       'Sets the profit image to the red or the green one, depending on whether you make or loose money
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
                reputation += 0.1           'If the user made too much lemonade, their reputation and expected customers increase
                expected += expected * 0.1
            End If
        Else
            If reputation <= 0.5 Then
            Else
                reputation -= 0.1           'If the user couldn't fulfull demand, their reputation and expected customers decrease
                expected -= expected * 0.1
            End If
        End If

        If weatherMultiplier = 2 Then
            If reputation >= 1.5 Then
            Else
                reputation += 0.1               'If the user achieved the weather multiplier, their reputation and expected customers increase
                expected += expected * 0.1
            End If
        Else
            If reputation <= 0.5 Then
            ElseIf weatherMultiplier = 1 Then      'If the user didn't achieve the weather multiplier, their reputation and expected customers decrease
                reputation -= 0.1
                expected -= expected * 0.1
            End If
        End If

        Form1.Label3.Text = reputation      'Update the repuation and expected labels
        Form1.Label6.Text = expected

        moneybefore = money             'Sets the moneybefore to the money before buying and stock for the next day
    End Sub

    Sub Getstar()

        If reputation > 0.6 Then
            Form1.PictureBox7.ImageLocation = "U:\Pictures\Star.Png"
            If reputation > 0.8 Then
                Form1.PictureBox8.ImageLocation = "U:\Pictures\Star.Png"
                If reputation > 1 Then
                    Form1.PictureBox9.ImageLocation = "U:\Pictures\Star.Png"
                    If reputation > 1.2 Then
                        Form1.PictureBox10.ImageLocation = "U:\Pictures\Star.Png"           'Changes the amount of stars shown depening on reputation
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
            Form1.PictureBox6.ImageLocation = "U:\Pictures\sunny.PNG"           'Randomly generates weather for next day, and updates weather icon accordingly
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
        getweather(templemon, tempsugar, tempice)               'This sub contains all the other subs that calculate the profit, so only one sub needs to be called from the composition form
        getprogress()
        getprofits(templemon, tempsugar, tempice)
        getreputations()
        Getstar()

    End Sub

End Class

Public Class humanPlayer
    Inherits player             'The human player inherits all the methods from the base class
End Class

Public Class AIPlayer
    Inherits player                     'The AI player inherits all the methds from the base class, but has other variables, most notable the trial 2D array, and overrides a lot of methods with its own
    Private trial(4, 1002) As Integer      'lemon | Sugar | Ice | Weather | weatherMultiplier
    Private trialcounter As Integer = 0     'The number of trials performed, and acts as the ordinal number of a trial in the 2D array

    'Buying stock and setting profit dowsnt need to update any labels for the ai player, so these new subs dont do this

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

    Overrides Sub calculate(tempsales As Integer, templemon As Integer, tempsugar As Integer, tempice As Integer)

        getsales(tempsales)
        getweather(trial(0, trialcounter), trial(1, trialcounter), trial(2, trialcounter))      'This sub contains all the other subs that calculate the profit, so only one sub needs to be called from the composition form
        getprogress()
        getprofits(trial(0, trialcounter), trial(1, trialcounter), trial(2, trialcounter))
        getreputations()
        trialcounter += 1                   'Increases the trial number for the next day
    End Sub

    Overrides Sub getsales(tempsales As Integer)
        Dim num As New Random
        varience = (num.Next(-10, 10))

        deviation = (varience * reputation)         'Calculates the deviation and actual sales in the same way as the humanPlayer 

        expected += deviation

        actualsales = expected

        'This is where it looks at the weather and sees if it either has the best combination, and a multiple of it, or just randomly tries again
        Dim found As Boolean = 0        'This boolean tells the game if the ideal composition for this weather is in the trial array


        For i As Integer = 1 To 10
            For j As Integer = 0 To trialcounter - 1
                If trial(0, j) Mod i = 0 And trial(1, j) Mod i = 0 And trial(2, j) Mod i = 0 Then           'Cancels out common factors, even if a trial wasn't successful
                    trial(0, j) = (trial(0, j) / i)
                    trial(1, j) = (trial(1, j) / i)
                    trial(2, j) = (trial(2, j) / i)
                End If
            Next
        Next


        found = 0
        Dim counter3 As Integer             'saves the location of the optimal composition
        For i As Integer = 0 To trialcounter - 1
            If trial(3, i) = Form1.weather And trial(4, i) = 2 Then
                trial(0, trialcounter) = trial(0, i)                    'Checks to see if a solution that gets the multiplier for tis weather has been discovered
                trial(1, trialcounter) = trial(1, i)
                trial(2, trialcounter) = trial(2, i)
                found = 1
                counter3 = i
                MsgBox("found = " + found.ToString)
                MsgBox("Ideal for " + Form1.weather.ToString + "=" + trial(0, i).ToString + " " + trial(1, i).ToString + " " + trial(2, i).ToString)    'Outputs what the ideal composition is
            End If
        Next


        If found = 1 Then
            money = money - actualsales * (trial(0, counter3) + trial(1, counter3) + trial(2, counter3))        'If the ideal compositon is found, use this compositon to make lemmonade
        ElseIf found = 0 Then


            Do
                Randomize()
                trial(0, trialcounter) = CInt(Math.Ceiling(Rnd() * 4))
                Randomize()
                trial(1, trialcounter) = CInt(Math.Ceiling(Rnd() * 4))                                                                'Randomly generates composition if optimal one hasnt been discovered yet
                Randomize()
                trial(2, trialcounter) = CInt(Math.Ceiling(Rnd() * 4))

                If actualsales * (trial(0, trialcounter) + trial(1, trialcounter) + trial(2, trialcounter)) > money Then        'Check to see if the user can afford to buy the compositon they have chosen 
                Else
                    money = money - actualsales * (trial(0, trialcounter) + trial(1, trialcounter) + trial(2, trialcounter))       'buys stock in the ratios randomly generated
                    MsgBox("found = " + found.ToString)
                    Exit Do
                End If
            Loop
        Else
        End If
    End Sub

    Overrides Sub getweather(templemon As Integer, tempsugar As Integer, tempice As Integer)
        lemons -= actualsales * templemon
        sugar -= actualsales * tempsugar                'Calculates weather multiplier in same was as human player
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
            MsgBox("FAIL = " + trial(0, trialcounter).ToString + trial(1, trialcounter).ToString + trial(2, trialcounter).ToString)         'Outputs the ratio that was unsuccessful
        End If

        totalsales += actualsales
        trial(3, trialcounter) = Form1.weather
        trial(4, trialcounter) = weatherMultiplier

        'MEH 1 lemon, 1 ice, 1 sugar

        'SUNNY 2 lemon, 3 ice, 1 sugar

        'COLD 1 lemon, 1 ice, 2 sugar

        If weatherMultiplier = 2 Then
            MsgBox("composition = " + trial(0, trialcounter).ToString + trial(1, trialcounter).ToString + trial(2, trialcounter).ToString + "weather = " + Form1.weather.ToString)  'Outputs the optimal composition if it has found it
        End If



    End Sub

    Overrides Sub getprogress()
        salesMultiplier = ((Math.Log10(totalsales)) / 100) + 1      'Works out sales multiplier
    End Sub

    Overridable Sub getprofits(templemon As Integer, tempsugar As Integer, tempice As Integer)

        Dim smallprofit As Integer          'A simpler versio of the humanPlayer getprofits as nothing needs to be updated, and the AI cant by upgrades
        Dim bigprofit As Integer

        bigprofit = (((templemon + tempsugar + tempice) * actualsales) * salesMultiplier)
        smallprofit = bigprofit - ((templemon + tempsugar + tempice) * actualsales)

        money += (bigprofit + (weatherMultiplier - 1) * smallprofit)

        moneyafter = money
        profit = moneyafter - moneybefore

    End Sub

    Overrides Sub getreputations()
        If actualsales = expected Then

            If reputation >= 1.5 Then
            Else
                reputation += 0.1               'Same as human player
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
