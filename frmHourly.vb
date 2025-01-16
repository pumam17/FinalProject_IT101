Public Class frmHourly
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtFirstName.Focus()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtAmountPayed.Clear()
        txtHours.Clear()
        txtYearlyGross.Clear()
        lblGrossPay.ResetText()
        lblFICA.ResetText()
        lblState.ResetText()
        lblFederal.ResetText()
        lblNetPay.ResetText()
        radOhio.Checked = False
        radKentucky.Checked = False
        radIndy.Checked = False
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'Declare my Variables
        Dim dblAmountPayed As Double
        Dim dblHours As Double
        Dim dblYearlyGross As Double
        Dim dblGrossPay As Double
        Dim dblFICATax As Double
        Dim dblStateTax As Double
        Dim dblFereralTax As Double
        Dim dblNetPay As Double
        Dim dblDailyGrossPay As Double
        Dim dblDailyNetPay As Double
        Dim blnValidation As Boolean = True
        Dim blnOhio As Boolean
        Dim blnKentucy As Boolean


        'Get and Validate Input
        Get_and_Validate_Input(dblAmountPayed, dblHours, dblYearlyGross, blnValidation, blnOhio, blnKentucy)

        'Do Calculations
        If blnValidation = True Then
            Call Do_Calculations(dblAmountPayed, dblHours, dblYearlyGross, blnOhio, blnKentucy, dblGrossPay, dblFICATax, dblStateTax, dblFereralTax, dblNetPay, dblDailyGrossPay, dblDailyNetPay)
            'Display
            Call Display_Results(dblGrossPay, dblFICATax, dblStateTax, dblFereralTax, dblNetPay)
        End If


    End Sub

    Private Sub Get_and_Validate_Input(ByRef dblAmountPayed As Double, ByRef dblHours As Double, ByRef dblYearlyGross As Double, ByRef blnValidation As Boolean, ByRef blnOhio As Boolean, ByRef blnKentucy As Boolean)
        Call Validate_FirstName(blnValidation)
        Call Validate_LastName(blnValidation)
        Call Validate_HourlyWage(dblAmountPayed, blnValidation)
        Call Validate_HoursAtWork(dblHours, blnValidation)
        Call Validate_YearlyGross(dblYearlyGross, blnValidation)
        Call Validate_State(blnValidation, blnOhio, blnKentucy)
    End Sub

    Private Sub Validate_FirstName(ByRef blnValidation As Boolean)
        If txtFirstName.Text = String.Empty Then
            MessageBox.Show("First Name Must Exist")
            txtLastName.Focus()
            blnValidation = False
        End If
    End Sub
    Private Sub Validate_LastName(ByRef blnValidation As Boolean)
        If txtLastName.Text = String.Empty Then
            MessageBox.Show("Last Name Must Exist")
            txtLastName.Focus()
            blnValidation = False
        End If
    End Sub
    Private Sub Validate_HourlyWage(ByRef dblAmountPayed As Double, ByRef blnValidation As Boolean)
        If Double.TryParse(txtAmountPayed.Text, dblAmountPayed) Then
            If dblAmountPayed < 0 Then
                MessageBox.Show("Hourly Wage In Must Be 0 or Greater")
                txtAmountPayed.Focus()
                blnValidation = False
            End If
        Else
            MessageBox.Show("Hourly Wage Must Exist and Must be Numeric")
            txtAmountPayed.Focus()
            blnValidation = False
        End If
    End Sub
    Private Sub Validate_HoursAtWork(ByRef dblHours As Double, ByRef blnValidation As Boolean)
        If Double.TryParse(txtHours.Text, dblHours) Then
            If dblHours < 0 Then
                MessageBox.Show("Hours Per Pay Period In Must Be 0 or Greater")
                txtHours.Focus()
                blnValidation = False
            End If
        Else
            MessageBox.Show("Hours Per Pay Period Must Exist and Must be Numeric")
            txtHours.Focus()
            blnValidation = False
        End If
    End Sub
    Private Sub Validate_YearlyGross(ByRef dblYearlyGross As Double, ByRef blnValidation As Boolean)
        If Double.TryParse(txtYearlyGross.Text, dblYearlyGross) Then
            If dblYearlyGross < 0 Then
                MessageBox.Show("Yearly Gross In Must Be 0 or Greater")
                txtYearlyGross.Focus()
                blnValidation = False
            End If
        Else
            MessageBox.Show("Yearly Gross Must Exist and Must be Numeric")
            txtYearlyGross.Focus()
            blnValidation = False
        End If
    End Sub
    Private Sub Validate_State(ByRef blnValidation As Boolean, ByRef blnOhio As Boolean, ByRef blnKentucy As Boolean)
        If radOhio.Checked = False And radKentucky.Checked = False And radIndy.Checked = False Then
            MessageBox.Show("State Must Be Selected")
            radOhio.Focus()
            blnValidation = False
        Else
            If radOhio.Checked Then
                blnOhio = True
            Else
                If radKentucky.Checked Then
                    blnKentucy = True
                End If
            End If
        End If
    End Sub

    Private Sub Do_Calculations(ByVal dblAmountPayed As Double, ByVal dblHours As Double, ByVal dblYearlyGross As Double, ByVal blnOhio As Boolean, ByVal blnKentucy As Boolean, ByRef dblGrossPay As Double, ByRef dblFICATax As Double, ByRef dblStateTax As Double, ByRef dblFereralTax As Double, ByRef dblNetPay As Double, ByRef dblDailyGrossPay As Double, ByRef dblDailyNetPay As Double)
        dblGrossPay = Calculate_HoulryGrossPay(dblAmountPayed, dblHours)
        dblFICATax = Calculate_FICATax(dblGrossPay, dblYearlyGross)
        dblStateTax = Calculate_StateTax(dblGrossPay, blnOhio, blnKentucy)
        dblFereralTax = Calculate_FederalTax(dblGrossPay)
        dblNetPay = Calculate_NetPay(dblGrossPay, dblFICATax, dblStateTax, dblFereralTax)
        dblDailyGrossPay = Calculate_DailyGrossPay(dblGrossPay)
        dblDailyNetPay = Calculate_DailyNetPay(dblNetPay)
    End Sub

    Private Sub Display_Results(ByVal dblGrossPay As Double, ByVal dblFICATax As Double, ByVal dblStateTax As Double, ByVal dblFederalTax As Double, ByVal dblNetPay As Double)
        lblGrossPay.Text = dblGrossPay.ToString("c")
        lblFICA.Text = dblFICATax.ToString("c")
        lblState.Text = dblStateTax.ToString("c")
        lblFederal.Text = dblFederalTax.ToString("c")
        lblNetPay.Text = dblNetPay.ToString("c")
    End Sub

    Private Function Calculate_HoulryGrossPay(ByVal dblAmountPayed As Double, ByVal dblHours As Double)

        Dim dblGrossPay As Double
        Dim dblOvertimeWage As Double
        Dim dblOvertimeHours As Double

        If dblHours <= 40 Then
            dblGrossPay = dblHours * dblAmountPayed
        Else
            dblOvertimeWage = Calculate_OvertimeWage(dblAmountPayed)
            dblOvertimeHours = Calculate_OvertimeHours(dblHours)
            dblGrossPay = (40 * dblAmountPayed) + (dblOvertimeWage * dblOvertimeHours)
        End If

        Return dblGrossPay
    End Function

    Private Function Calculate_OvertimeWage(ByVal dblAmountPayed As Double)
        Dim dblOvertimeWage As Double

        dblOvertimeWage = dblAmountPayed + (dblAmountPayed * 0.5)

        Return dblOvertimeWage
    End Function

    Private Function Calculate_OvertimeHours(ByVal dblHours As Double)
        Dim dblOvertimeHours As Double

        dblOvertimeHours = dblHours - 40

        Return dblOvertimeHours
    End Function

End Class