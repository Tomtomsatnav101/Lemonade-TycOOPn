Public Class Log_in
    Public newplayer As player              'The player needs to be global so it can be accessed from form1
    Public taken As Boolean = False         'Used to see if the name is already in use
    Public number As Integer                'Records the users position in the database
    Public first As Boolean                 'Used to differentiate between sign-up and sign-in in the sub new
    Public correct As Boolean               'Used to see if password and username match
    Public aitrue As Boolean                'Used to see if the AI needs to be created now, or will be creared later
    Public newaiplayer As AIPlayer          'The AI needs to be global so it can be accessed from form1 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then            'This if statement handles people trying to sign into their old account
            MsgBox("Please enter both a username and a password")
        Else
            For i As Integer = 0 To Database.usercount
                If Database.database(i).username = TextBox1.Text And Database.database(i).password = TextBox2.Text Then     'If the username matches the password
                    taken = Nothing
                    first = False
                    number = i          'Sets the players position in the database
                    newplayer = New humanPlayer
                    aitrue = True
                    newaiplayer = New AIPlayer
                    Me.Hide()
                    Form1.Show()

                    correct = 1
                Else
                End If
            Next
            If correct = 0 Then
                MsgBox("Incorrect username or password")    'Handles if no matching username or password was found
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then        'This if statement handles creating a new player
            MsgBox("Please enter both a username and a password")
        Else
            taken = 0
            For i As Integer = 0 To Database.usercount
                If TextBox1.Text = Database.database(i).username Then      'Checks to see if username is taken already
                    taken = 1
                End If
            Next

            If taken = 0 Then
                Database.usercount += 1
                number = Database.usercount             'Sets some variables ready for a new entry in the database
                first = True
                aitrue = False
                newplayer = New humanPlayer
                Database.database(Database.usercount).username = TextBox1.Text
                Database.database(Database.usercount).password = TextBox2.Text
                Database.database(Database.usercount).ID = number
            Else
                MsgBox("Username is taken")
            End If
        End If
    End Sub
    Private Sub Log_in_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Database.read()     'Loads the contents of the database upon opening
    End Sub
    Private Sub Log_in_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

End Class