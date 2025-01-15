Public Class frmSalary
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtFirstName.Focus()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtAmountPayed.Clear()
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
        Get_and_Validate_Input(dblAmountPayed, dblYearlyGross, blnValidation, blnOhio, blnKentucy)

        'Do Calculations
        If blnValidation = True Then
            Call Do_Calculations(dblAmountPayed, dblYearlyGross, blnOhio, blnKentucy, dblGrossPay, dblFICATax, dblStateTax, dblFereralTax, dblNetPay, dblDailyGrossPay, dblDailyNetPay)
            'Display
            Call Display_Results(dblGrossPay, dblFICATax, dblStateTax, dblFereralTax, dblNetPay)
        End If

    End Sub

    Private Sub Get_and_Validate_Input(ByRef dblAmountPayed As Double, ByRef dblYearlyGross As Double, ByRef blnValidation As Boolean, ByRef blnOhio As Boolean, ByRef blnKentucy As Boolean)
        Call Validate_FirstName(blnValidation)
        Call Validate_LastName(blnValidation)
        Call Validate_Salary(dblAmountPayed, blnValidation)
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
    Private Sub Validate_Salary(ByRef dblAmountPayed As Double, ByRef blnValidation As Boolean)
        If Double.TryParse(txtAmountPayed.Text, dblAmountPayed) Then
            If dblAmountPayed < 0 Then
                MessageBox.Show("Salary Must Be 0 or Greater")
                txtAmountPayed.Focus()
                blnValidation = False
            End If
        Else
            MessageBox.Show("Salary Must Exist and Must be Numeric")
            txtAmountPayed.Focus()
            blnValidation = False
        End If
    End Sub
    Private Sub Validate_YearlyGross(ByRef dblYearlyGross As Double, ByRef blnValidation As Boolean)
        If Double.TryParse(txtYearlyGross.Text, dblYearlyGross) Then
            If dblYearlyGross < 0 Then
                MessageBox.Show("Hourly Wage In Must Be 0 or Greater")
                txtYearlyGross.Focus()
                blnValidation = False
            End If
        Else
            MessageBox.Show("Hourly Wage Must Exist and Must be Numeric")
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
    Private Sub Do_Calculations(ByVal dblAmountPayed As Double, ByVal dblYearlyGross As Double, ByVal blnOhio As Boolean, ByRef blnKentucy As Boolean, ByRef dblGrossPay As Double, ByRef dblFICATax As Double, ByRef dblStateTax As Double, ByRef dblFereralTax As Double, ByRef dblNetPay As Double, ByRef dblDailyGrossPay As Double, ByRef dblDailyNetPay As Double)
        dblGrossPay = Calculate_SalaryGrossPay(dblAmountPayed)
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

    Private Function Calculate_SalaryGrossPay(dblAmountPayed)
        Dim dblGrossPay As Double
        dblGrossPay = dblAmountPayed / 52
        Return dblGrossPay
    End Function

End Class