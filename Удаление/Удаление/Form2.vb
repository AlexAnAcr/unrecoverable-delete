Public Class Form2
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 80 Then
            Timer1.Enabled = False
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            ProgressBar1.Value = ProgressBar1.Value + 1
        End If
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Left = Form1.Left + 40
        Top = Form1.Top + 40
        ProgressBar1.Value = 0
        Timer1.Interval = (TextBox1.Text / 2000) + 1
        Timer1.Enabled = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProgressBar1.Value = 0
        Timer1.Enabled = False
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class