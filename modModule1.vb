Module modModule1
    Dim sngSocialSecurityLimit As Single = 125000
    Dim sngMedicareTax As Single = 0.0145
    Dim sngSocialSecurityTaxRate As Single = 0.062
    Dim sngOhioTax As Single = 0.065
    Dim sngKentuckyTax As Single = 0.06
    Dim sngIndyTax As Single = 0.055
    Public dblDailyNetPay As Double
    Public dblDailyGrossPay As Double

    Public Function Calculate_FICATax(ByVal dblGrossPay As Double, ByVal dblYearlyGross As Double)
        Dim dblSubtotal As Double
        Dim dblFICATax As Double

        If dblYearlyGross >= sngSocialSecurityLimit Then
            dblFICATax = dblGrossPay * sngMedicareTax
        Else
            dblSubtotal = Calculate_SubtotalForSSTax(dblGrossPay, dblYearlyGross)
            If dblSubtotal < sngSocialSecurityLimit Then
                dblFICATax = (dblGrossPay * sngSocialSecurityTaxRate) + (dblGrossPay * sngMedicareTax)
            Else
                dblFICATax = (sngSocialSecurityLimit - dblYearlyGross) + (dblGrossPay * sngMedicareTax)
            End If
        End If

        Return dblFICATax
    End Function


    Private Function Calculate_SubtotalForSSTax(ByVal dblGrossPay As Double, ByVal dblYearlyGross As Double)
        Dim Subtotal As Double

        Subtotal = (dblGrossPay * sngSocialSecurityTaxRate) + dblYearlyGross

        Return Subtotal
    End Function

    Public Function Calculate_StateTax(ByVal dblGrossPay As Double, ByVal blnOhio As Boolean, ByVal blnKentucy As Boolean)

        Dim dblStateTax As Double

        If blnOhio = True Then
            dblStateTax = dblGrossPay * sngOhioTax
        Else
            If blnKentucy = True Then
                dblStateTax = dblGrossPay * sngKentuckyTax
            Else
                dblStateTax = dblGrossPay * sngIndyTax
            End If
        End If

        Return dblStateTax
    End Function

    Public Function Calculate_FederalTax(dblGrossPay)

        Dim dblFederalTax As Double

        If dblGrossPay <= 50 Then
            dblFederalTax = 0
        Else
            If dblGrossPay < 500 Then
                dblFederalTax = (dblGrossPay - 50) * 0.1
            Else
                If dblGrossPay < 2500 Then
                    dblFederalTax = 45 + ((dblGrossPay - 500) * 0.15)
                Else
                    If dblGrossPay < 5000 Then
                        dblFederalTax = 345 + ((dblGrossPay - 2500) * 0.2)
                    Else
                        If dblGrossPay >= 5000 Then
                            dblFederalTax = 845 + ((dblGrossPay - 5000) * 0.25)
                        End If
                    End If
                End If
            End If
        End If

        Return dblFederalTax
    End Function

    Public Function Calculate_NetPay(ByVal dblGrossPay As Double, ByVal dblFICATax As Double, ByVal dblStateTax As Double, ByVal dblFederalTax As Double)

        Dim dblNetPay As Double

        dblNetPay = dblGrossPay - (dblFICATax + dblStateTax + dblFederalTax)

        Return dblNetPay
    End Function

    Public Function Calculate_DailyGrossPay(ByVal dblGrossPay As Double)

        dblDailyGrossPay += dblGrossPay

        Return dblDailyGrossPay
    End Function
    Public Function Calculate_DailyNetPay(ByVal dblNetPay As Double)

        dblDailyNetPay += dblNetPay

        Return dblDailyNetPay
    End Function

End Module
