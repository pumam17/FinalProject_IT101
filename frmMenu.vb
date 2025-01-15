Public Class frmMenu
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnSalary_Click(sender As Object, e As EventArgs) Handles btnSalary.Click
        Dim frmSalary As New frmSalary
        frmSalary.ShowDialog()
    End Sub

    Private Sub btnHourly_Click(sender As Object, e As EventArgs) Handles btnHourly.Click
        Dim frmHourly As New frmHourly
        frmHourly.ShowDialog()
    End Sub

    Public Sub btnTotals_Click(sender As Object, e As EventArgs) Handles btnTotals.Click

        MessageBox.Show("Daily summary for Gross Pay = " & dblDailyGrossPay.ToString("c") & vbCr & "Daily Summary for NetPay = " & dblDailyNetPay.ToString("c"))

    End Sub
End Class
