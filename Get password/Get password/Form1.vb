Public Class Form1
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        If TextBox1.Text = "<get password>" And TextBox2.Text = "deliting" And TextBox4.Text <> "" And TextBox4.TextLength = 4 Then
            Dim dat As String = TextBox4.Text
            Dim number1 As String, number2 As String, number3 As String, number4 As String
            number1 = Mid(dat, 1, 1)
            number2 = Mid(dat, 2, 1)
            number3 = Mid(dat, 3, 1)
            number4 = Mid(dat, 4, 1)
            If number1 = "1" Then
                number1 = "4683"
            ElseIf number1 = "2" Then
                number1 = "2761"
            ElseIf number1 = "3" Then
                number1 = "3794"
            ElseIf number1 = "4" Then
                number1 = "9738"
            ElseIf number1 = "5" Then
                number1 = "3120"
            ElseIf number1 = "6" Then
                number1 = "3127"
            ElseIf number1 = "7" Then
                number1 = "6837"
            ElseIf number1 = "8" Then
                number1 = "9730"
            ElseIf number1 = "9" Then
                number1 = "3420"
            ElseIf number1 = "0" Then
                number1 = "4386"
            End If
            If number2 = "1" Then
                number2 = "6728"
            ElseIf number2 = "2" Then
                number2 = "9721"
            ElseIf number2 = "3" Then
                number2 = "3821"
            ElseIf number2 = "4" Then
                number2 = "3100"
            ElseIf number2 = "5" Then
                number2 = "3728"
            ElseIf number2 = "6" Then
                number2 = "3820"
            ElseIf number2 = "7" Then
                number2 = "3720"
            ElseIf number2 = "8" Then
                number2 = "3740"
            ElseIf number2 = "9" Then
                number2 = "9724"
            ElseIf number2 = "0" Then
                number2 = "9457"
            End If
            If number3 = "1" Then
                number3 = "9705"
            ElseIf number3 = "2" Then
                number3 = "2807"
            ElseIf number3 = "3" Then
                number3 = "3407"
            ElseIf number3 = "4" Then
                number3 = "3101"
            ElseIf number3 = "5" Then
                number3 = "3204"
            ElseIf number3 = "6" Then
                number3 = "3420"
            ElseIf number3 = "7" Then
                number3 = "3720"
            ElseIf number3 = "8" Then
                number3 = "9780"
            ElseIf number3 = "9" Then
                number3 = "6720"
            ElseIf number1 = "0" Then
                number3 = "9467"
            End If
            If number4 = "1" Then
                number4 = "1000"
            ElseIf number4 = "2" Then
                number4 = "4414"
            ElseIf number4 = "3" Then
                number4 = "1010"
            ElseIf number4 = "4" Then
                number4 = "5427"
            ElseIf number4 = "5" Then
                number4 = "9782"
            ElseIf number4 = "6" Then
                number4 = "3420"
            ElseIf number4 = "7" Then
                number4 = "9780"
            ElseIf number4 = "8" Then
                number4 = "4674"
            ElseIf number4 = "9" Then
                number4 = "4377"
            ElseIf number1 = "0" Then
                number4 = "7357"
            End If
            TextBox3.Text = number1 & number2 & number3 & number4
        End If
    End Sub
End Class