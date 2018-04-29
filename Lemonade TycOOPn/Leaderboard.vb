Public Class Leaderboard
    Dim order As Boolean = True         'saves whether the user wants the data in increasing or decreasing order
    Dim counter As Integer              'used to load the contents of the database into the highscores structure
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()       'takes the user back to the main screen
        Form1.Show()
    End Sub
    Structure highscore
        Dim score As Integer        'The highscore struture is used to keep the username and their score together
        Dim name As String
    End Structure
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If order = True Then
            'bubblesort()       'This if statement automatically reverses the order each time the button is pressed
            sort()
            order = False
        Else
            'bubblesort()
            sort()
            order = True
        End If
    End Sub

    Sub bubblesort()
        Dim highscores(1000) As highscore       'array to hold the users
        Dim counter As Integer = 0

        ListBox1.Items.Clear()      'clears the box

        For i = 0 To Database.database.Length - 1
            If Database.database(i).money <> Nothing Then
                highscores(counter).score = Database.database(i).money      'loads each usrname and score into the highscore structure
                highscores(counter).name = Database.database(i).username
                counter += 1
            End If
        Next

        For i As Integer = 0 To counter - 1
            For j As Integer = 1 To counter - 1 - i
                If order = True Then
                    If highscores(j).score > highscores(j - 1).score Then
                        Dim temp As highscore = highscores(j)
                        highscores(j) = highscores(j - 1)                   'swaps the two neighbouring highscores around if they are in the wrong order
                        highscores(j - 1) = temp
                    End If

                Else
                    If highscores(j).score < highscores(j - 1).score Then
                        Dim temp As highscore = highscores(j)               'Does the same as above, but the other way around if the order is reversed
                        highscores(j) = highscores(j - 1)
                        highscores(j - 1) = temp
                    End If
                End If
            Next
        Next
        For i = 0 To highscores.Length - 1
            If highscores(i).score <> Nothing Then
                ListBox1.Items.Add(highscores(i).score.ToString + " : " + highscores(i).name)           'outputs the usernames and scores in the sorted order
            End If
        Next

    End Sub

    Sub sort()

        Dim highscores(1000) As highscore           'array to hold users

        ListBox1.Items.Clear()                      'clears the box

        For i = 0 To Database.database.Length - 1
            If Database.database(i).money <> Nothing Then
                highscores(counter).score = Database.database(i).money              'loads the usernames and scores into the sturcture fro the database
                highscores(counter).name = Database.database(i).username
                counter += 1
            End If
        Next

        MergeSort(highscores, 0, counter - 1)                   'starts the merge sort process, by passing through the array of highscores, the 

    End Sub

    Sub MergeSort(highscores() As highscore, lowIndex As Integer, highIndex As Integer)

        'the low index is the start of the list and the high index is the end of the list

        If (lowIndex < highIndex) Then

            Dim midIndex = Math.Floor((lowIndex + highIndex) / 2)    ' Finds midpoint 



            MergeSort(highscores, lowIndex, midIndex)                'Recursivly splits the first half of the list until the top equals the bottom (ie.the same element)

            MergeSort(highscores, midIndex + 1, highIndex)           'Recursivly splits the second half of the list until the top equals the bottom (ie.the same element)



            Merge(highscores, lowIndex, midIndex, highIndex)         '

        End If



    End Sub

    Sub Merge(highscores() As highscore, lowIndex As Integer, midIndex As Integer, highIndex As Integer)

        Dim Length1 = midIndex - lowIndex + 1   'length of left list 

        Dim Length2 = highIndex - midIndex      'length of right list 


        Dim Left(Length1) As Integer            'creates two arrays to hold the bottom and top parts of the list

        Dim Right(Length2) As Integer


        'creating index variable to keep track of final answer 

        Dim final As Integer = lowIndex



        Dim counterI = 0

        Dim counterJ = 0





        While (counterI < Length1)
            Left(counterI) = highscores(lowIndex + counterI).score            'Transferes array contents to Left
            counterI += 1
        End While

        While (counterJ < Length2)
            Right(counterJ) = highscores(midIndex + 1 + counterJ).score        'Transferes array contents to Right
            counterJ += 1
        End While



        'Reset variables from previous usage 

        final = lowIndex

        Dim i As Integer = 0

        Dim j As Integer = 0



        'Merge the lists into one list 

        While (i < Length1 And j < Length2)
            If (Left(i) <= Right(j)) Then   'If the value on the left is less than the value on the right then add it to the list 
                highscores(final).score = Left(i)
                i += 1
            Else
                highscores(final).score = Right(j)      'If the value on the right is less than the value on the left then add it to the list 
                j += 1
            End If
            final += 1
        End While



        'Sorts it out if one array is empty after merging 
        While (i < Length1)
            highscores(final).score = Left(i)
            i += 1
            final += 1
        End While

        While (j < Length2)
            highscores(final).score = Right(j)
            j += 1
            final += 1
        End While


        'Checks our answer 
        Dim kk As Boolean = True

        For countercheck As Integer = 0 To counter - 2
            If highscores(countercheck).score > highscores(countercheck + 1).score Then
                kk = False
            End If

        Next


        For l As Integer = 1 To Database.database.Length - 1
            For m As Integer = 1 To Database.database.Length - 1
                If Database.database(m).money = highscores(l).score Then            'creates the second part of the highscore
                    highscores(l).name = Database.database(m).username
                End If
            Next
        Next



        'Outputs the result forwards or backwards
        ListBox1.Items.Clear()
        If kk = False Then
        Else
            If order = False Then
                For counterout As Integer = 0 To counter - 1
                    If highscores(counterout).name = "" Then
                    Else ListBox1.Items.Add(highscores(counterout).score.ToString + " : " + highscores(counterout).name)
                    End If
                Next
            Else
                For counterout As Integer = counter - 1 To 0 Step -1
                    If highscores(counterout).name = "" Then
                    Else
                        ListBox1.Items.Add(highscores(counterout).score.ToString + " : " + highscores(counterout).name)
                    End If
                Next
            End If
        End If







    End Sub

    Private Sub Leaderboard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Hide()           'takes the user back to the main screen if they close this form
        Form1.Show()
    End Sub

    Private Sub Leaderboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListBox1.Items.Clear()              'clears the box and sets the order
        order = True
    End Sub
    Private Sub Leaderboard_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        ListBox1.Items.Clear()               'clears the box and sets the order
        order = True
    End Sub
End Class