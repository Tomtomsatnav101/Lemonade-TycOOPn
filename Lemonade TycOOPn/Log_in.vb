Public Class Log_in
    Public newplayer As player
    Public taken As Boolean = False
    Public number As Integer
    Public first As Boolean
    Public correct As Boolean
    Public aitrue As Boolean
    Public newaiplayer As AIPlayer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Please enter both a username and a password")
        Else
            For i As Integer = 0 To Database.usercount
                If Database.database(i).username = TextBox1.Text And Database.database(i).password = TextBox2.Text Then
                    taken = Nothing
                    first = False
                    number = i
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
                MsgBox("Incorrect username or password")
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
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
                number = Database.usercount
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
        Database.read()
    End Sub
    Private Sub Log_in_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

End Class