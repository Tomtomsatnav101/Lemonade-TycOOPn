Public Class Form1
    Dim addstock As Integer
    Public weather As Integer

    Private Sub GetStock(lemon, sugar, ice)
        If addstock = 1 Then
            If Log_in.newplayer.getmoney() >= lemon Then
                Log_in.newplayer.setlemons(lemon)
                Log_in.newplayer.setmoney(-lemon)

                Label2.Text = Log_in.newplayer.getmoney()
            End If
        ElseIf addstock = 2 Then
            If Log_in.newplayer.getmoney() >= sugar Then
                Log_in.newplayer.setsugar(sugar)
                Log_in.newplayer.setmoney(-sugar)

                Label2.Text = Log_in.newplayer.getmoney()

            End If
        ElseIf addstock = 3 Then
            If Log_in.newplayer.getmoney() >= ice Then
                Log_in.newplayer.setice(ice)
                Log_in.newplayer.setmoney(-ice)

                Label2.Text = Log_in.newplayer.getmoney()
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
        ElseIf weather = 1 Then
            PictureBox6.ImageLocation = "U:\Pictures\cold.PNG"
        ElseIf weather = 2 Then
            PictureBox6.ImageLocation = "U:\Pictures\meh.png"
        Else

        End If
    End Sub
End Class



Public Class player
    Private lemons As Integer
    Private ice As Integer
    Private sugar As Integer

    Private reputation As Double
    Private customers As Integer
    Private progress As Double
    Private varience As Integer
    Private actualsales As Integer
    Private deviation As Double

    Private ideallemon As Double
    Private idealice As Double
    Private idealsugar As Double
    Private composition(2) As Double


    Private profit As Integer
    Private moneybefore As Integer
    Private moneyafter As Integer
    Private totalsales As Integer
    Private money As Integer
    Private expected As Integer

    Private upgradeMultiplier As Integer
    Private weatherMultiplier As Integer
    Private salesMultiplier As Double


    Private Number As Integer 'Ordinal number of the player in the database


    Sub New()


        If Log_in.taken = 0 Then
            Database.usercount += 1
            Database.database(Database.usercount).username = Log_in.TextBox1.Text
            Database.database(Database.usercount).password = Log_in.TextBox2.Text

            Form1.Label4.Text = 0
            lemons = 0
            Form1.Label5.Text = 0
            sugar = 0
            Form1.Label7.Text = 0
            ice = 0
            Form1.Label12.Text = 0
            profit = 0
            totalsales = 0
            customers = 0
            Form1.Label2.Text = 1000
            money = 1000
            Form1.Label3.Text = 0.5
            reputation = 0.5
            Form1.Label6.Text = 100
            expected = 100                      'Database.database(Database.usercount).
            Number = usercount
            upgradeMultiplier = 1
            Log_in.Hide()
            Form1.Show()

        Else
            MsgBox("Username is taken")
        End If
    End Sub

    Function getmoney()
        Return money
    End Function
    Function setmoney(addmoney As Integer)
        money += addmoney
        Form1.Label2.Text = Log_in.newplayer.getmoney()
    End Function

    Function getlemons()
        Return lemons
    End Function
    Function setlemons(addlemons As Integer)
        lemons += addlemons
        Form1.Label4.Text = Log_in.newplayer.getlemons()

    End Function

    Function getice()
        Return ice
    End Function
    Function setice(addice As Integer)
        ice += addice
        Form1.Label7.Text = Log_in.newplayer.getice()
    End Function

    Function getsugar()
        Return sugar
    End Function
    Function setsugar(addsugar As Integer)
        sugar += addsugar
        Form1.Label5.Text = Log_in.newplayer.getsugar()
    End Function

    Function getreputation()
        Return reputation
    End Function
    Function setreputation(addreputation As Double)
        reputation += addreputation
    End Function


    Function getprofit()
        Return profit
    End Function
    Function setprofit(addprofit As Double)
        profit = addprofit
    End Function

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
        varience = adddeviation
    End Function
    Function getdeviation()
        Return deviation
    End Function

    Function setideallemon(addideallemon As Integer)
        ideallemon = addideallemon
    End Function
    Function getideallemon()
        Return ideallemon
    End Function
    Function setidealice(addidealice As Integer)
        idealice = addidealice
    End Function
    Function getidealice()
        Return idealice
    End Function
    Function setidealsugar(addidealsugar As Integer)
        idealsugar = addidealsugar
    End Function
    Function getidealsugar()
        Return idealsugar
    End Function

    Function setcomposition(number As Integer, addcomposition As Integer)
        composition(number) = addcomposition
    End Function
    Function getcomposition(number As Integer)
        Return composition(number)
    End Function


    Function getcustomers()
        Return customers
    End Function
    Function setcustomers(addcustomers As Double)
        customers += addcustomers
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



End Class

Public Class humanPlayer
    Inherits player

End Class

Public Class AIPlayer
    Inherits player

End Class
