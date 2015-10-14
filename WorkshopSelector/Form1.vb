Public Class Form1
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Closes the program
        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        'Removes items from Cost list, clears the total cost and deselects items in listbox
        lblTotalCost.Text = String.Empty
        lstCosts.Items.Clear()
        lstWorkshops.SelectedIndex = -1
        lstLocations.SelectedIndex = -1
    End Sub

    Private Sub btnAddWorkshop_Click(sender As Object, e As EventArgs) Handles btnAddWorkshop.Click
        Dim intDays As Integer, intRegistrationFee As Integer, intLodgingFee As Integer

        'Setup variables for Workshop
        Select Case CStr(lstWorkshops.SelectedItem)
            Case "Handling Stress"
                intDays = 3
                intRegistrationFee = 595
            Case "Time Management"
                intDays = 3
                intRegistrationFee = 695
            Case "Supervision Skills"
                intDays = 3
                intRegistrationFee = 995
            Case "Negotiation"
                intDays = 5
                intRegistrationFee = 1295
            Case "How to Interview"
                intDays = 1
                intRegistrationFee = 395
            Case String.Empty 'If nothing is selected inform user and stop
                MessageBox.Show("Please select a Workshop")
                Exit Sub
            Case Else
                lblTotalCost.Text = "ERROR!"
                Exit Sub
        End Select

        'Setup variables for location
        Select Case CStr(lstLocations.SelectedItem)
            Case String.Empty 'If nothing is selected inform user and stop
                MessageBox.Show("Please select a Location")
                Exit Sub
            Case "Austin"
                intLodgingFee = intDays * 95
            Case "Chicago"
                intLodgingFee = intDays * 125
            Case "Dallas"
                intLodgingFee = intDays * 110
            Case "Orlando"
                intLodgingFee = intDays * 100
            Case "Phoenix"
                intLodgingFee = intDays * 92
            Case "Raleigh"
                intLodgingFee = intDays * 90
            Case Else
                lblTotalCost.Text = "ERROR!"
                Exit Sub
        End Select

        'Add the fees and place them in the cost list
        lstCosts.Items.Add((intLodgingFee + intRegistrationFee).ToString("c"))
    End Sub

    Private Sub btnCalculateTotal_Click(sender As Object, e As EventArgs) Handles btnCalculateTotal.Click
        Dim intLoopLimit As Integer = lstCosts.Items.Count - 1, intTotalCosts As Integer = 0

        'Iterate through costs lists and add them to the total
        For i = 0 To intLoopLimit
            intTotalCosts += CInt(lstCosts.Items(i))
        Next

        'Display the total in currency format
        lblTotalCost.Text = intTotalCosts.ToString("c")
    End Sub
End Class
