'Public Class Database
Module Database
    Structure account
        Dim ID As Integer
        Dim username As String
        Dim money As Integer
        Dim score As Integer            'These are all the values that need to be saved. They are all being contained in a signle structure for ease
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

    Public database(1000) As account            'The database will have 1000 entries, though this can be changed
    Public usercount As Integer = 1             'The size of the databse, and also acts as the ordinal number of entries in the database


    Public Sub read()
        If My.Computer.FileSystem.FileExists("C:\Users\tomsw\database.txt") Then            'Checks to see if the file exists
            Dim filetext As String = My.Computer.FileSystem.ReadAllText("C:\Users\tomsw\database.txt")      'Saves the contents of he file as a string
            Dim records() As String = filetext.Split("▓")           'Splits the database at that symbol, to obtain individual accounts
            For i As Integer = 0 To records.Length - 2
                Dim fields() As String = records(i).Split("▒")          'Splits the database at that symbol to obain each individual value
                database(usercount).ID = fields(0)
                database(usercount).username = fields(1)
                database(usercount).money = fields(2)
                database(usercount).score = fields(3)
                database(usercount).password = fields(4)
                database(usercount).lemons = fields(5)
                database(usercount).sugar = fields(6)
                database(usercount).ice = fields(7)
                database(usercount).reputation = fields(8)
                database(usercount).expected = fields(9)                'saves the values into memory locations the game can access easilly
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
            My.Computer.FileSystem.WriteAllText("C:\Users\tomsw\database.txt", "", False)       'Creates the text file if it doesn't exist yet
        End If
        End Sub

    Public Sub write()
        Dim filetext As String = ""     'creates a strin to hold all the data to be saved into the database
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
                filetext += database(i).reputation.ToString + "▒"               'adds the valuse into the database, seperating each value with that symbol
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
        My.Computer.FileSystem.WriteAllText("C:\Users\tomsw\database.txt", filetext, False)         'writes the string that contans all the data into the textfile
        'Change to U at school, C at home
    End Sub

    ' alt + 177 = ▒

    ' alt + 178 = ▓

End Module
