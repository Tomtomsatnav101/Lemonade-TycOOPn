'Public Class Database
Module Database
    Structure account
        Dim ID As Integer
        Dim username As String
        Dim money As Integer
        Dim score As Integer
        Dim password As String
        Dim lemons As Integer
        Dim sugar As Integer
        Dim ice As Integer
        Dim reputation As Double
        Dim expected As Integer
        Dim totalsales As Integer
        Dim upgradeMultiplier As Integer

        Dim ailemons As Integer
        Dim aisugar As Integer
        Dim aiice As Integer
        Dim aitotalsales As Integer
        Dim aimoney As Integer
        Dim aireputation As Integer
        Dim aiexpected As Integer
        Dim aiscore As Integer
        Dim aiupgradeMultiplier As Integer
        Dim aicounter As Integer



    End Structure

    Public database(1000) As account
    Public usercount As Integer = 1


    Public Sub read()
        If My.Computer.FileSystem.FileExists("C:\Users\tomsw\database.txt") Then
            Dim filetext As String = My.Computer.FileSystem.ReadAllText("C:\Users\tomsw\database.txt")
            Dim records() As String = filetext.Split("▓")
            For i As Integer = 0 To records.Length - 2
                Dim fields() As String = records(i).Split("▒")
                database(usercount).ID = fields(0)
                database(usercount).username = fields(1)
                database(usercount).money = fields(2)
                database(usercount).score = fields(3)
                database(usercount).password = fields(4)
                database(usercount).lemons = fields(5)
                database(usercount).sugar = fields(6)
                database(usercount).ice = fields(7)
                database(usercount).reputation = fields(8)
                database(usercount).expected = fields(9)
                database(usercount).totalsales = fields(10)
                database(usercount).upgradeMultiplier = fields(11)
                database(usercount).ailemons = fields(12)
                database(usercount).aisugar = fields(13)
                database(usercount).aiice = fields(14)
                database(usercount).aitotalsales = fields(15)
                database(usercount).aimoney = fields(16)
                database(usercount).aireputation = fields(17)
                database(usercount).aiexpected = fields(18)
                database(usercount).aiscore = fields(19)
                database(usercount).aiupgradeMultiplier = fields(20)
                database(usercount).aicounter = fields(21)
                usercount += 1


            Next
        Else
            My.Computer.FileSystem.WriteAllText("C:\Users\tomsw\database.txt", "", False)
        End If
        End Sub

    Public Sub write()
        Dim filetext As String = ""
        For i As Integer = 0 To database.Length - 1
            If database(i).username <> Nothing Then
                filetext += database(i).ID.ToString + "▒"
                filetext += database(i).username + "▒"
                filetext += database(i).money.ToString + "▒"
                filetext += database(i).score.ToString + "▒"
                filetext += database(i).password + "▒"
                filetext += database(i).lemons.ToString + "▒"
                filetext += database(i).sugar.ToString + "▒"
                filetext += database(i).ice.ToString + "▒"
                filetext += database(i).reputation.ToString + "▒"
                filetext += database(i).expected.ToString + "▒"
                filetext += database(i).totalsales.ToString + "▒"
                filetext += database(i).upgradeMultiplier.ToString + "▒"
                filetext += database(i).ailemons.ToString + "▒"
                filetext += database(i).aisugar.ToString + "▒"
                filetext += database(i).aiice.ToString + "▒"
                filetext += database(i).aitotalsales.ToString + "▒"
                filetext += database(i).aimoney.ToString + "▒"
                filetext += database(i).aireputation.ToString + "▒"
                filetext += database(i).aiexpected.ToString + "▒"
                filetext += database(i).aiscore.ToString + "▒"
                filetext += database(i).aiupgradeMultiplier.ToString + "▒"
                filetext += database(i).aicounter.ToString + "▓"
            End If
        Next
        My.Computer.FileSystem.WriteAllText("C:\Users\tomsw\database.txt", filetext, False)
        'Change to U at school, C at home
    End Sub


    ' alt + 177 = ▒


    ' alt + 178 = ▓








End Module


'end class