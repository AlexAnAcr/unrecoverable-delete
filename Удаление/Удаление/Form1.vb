Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rez As DialogResult
        rez = OpenFileDialog1.ShowDialog()
        If rez = 1 Then
            TextBox1.Enabled = True
            Button2.Enabled = True
            TextBox1.Text = OpenFileDialog1.FileName
        Else
            TextBox1.Enabled = False
            Button2.Enabled = False
            TextBox1.Text = "Проверьте путь к файлу"
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim rez As DialogResult
        Try
            Form2.TextBox1.Text = My.Computer.FileSystem.GetFileInfo(TextBox1.Text).Length
            rez = Form2.ShowDialog()
            If rez = DialogResult.OK Then
                My.Computer.FileSystem.GetFileInfo(TextBox1.Text).Delete()
                My.Computer.FileSystem.WriteAllText(Application.StartupPath + "/reg.cmf", "  " & OpenFileDialog1.FileName & "  " & My.Computer.Clock.LocalTime & "  Информация о системе: " & My.Computer.Info.OSPlatform & Chr(10) & "--------", True)
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                MsgBox("Удаление завершено.", , "Информация")
            Else
                MsgBox("Удаление отменено.", , "Информация")
            End If
        Catch ex As Exception
            MsgBox("Нет доступа к данному файлу!", , "Системная ошибка")
        End Try
        TextBox1.Enabled = False
        Button2.Enabled = False
        TextBox1.Text = "Проверьте путь к файлу"
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(Application.StartupPath + "/reg.cmf") <> True Or My.Computer.FileSystem.FileExists(Application.StartupPath + "/inf.cmf") <> True Then
            If My.Computer.FileSystem.FileExists(Application.StartupPath + "/reg.cmf") <> True Then
                IO.File.Create(Application.StartupPath + "/reg.cmf")
            End If
            If My.Computer.FileSystem.FileExists(Application.StartupPath + "/inf.cmf") <> True Then
                IO.File.Create(Application.StartupPath + "/inf.cmf")
            End If
            MsgBox("Нет данных для работы программы! Для восстановления перезагрузите программу.", , "Системная ошибка")
            Me.Close()
        End If
        If My.Computer.FileSystem.FileExists("C:\data.cmf") = True Then
            MsgBox("Не найден модуль доступа к каталогу файлов!", , "Системная ошибка")
            Me.Close()
        End If
        Dim info() As String = IO.File.ReadAllLines(Application.StartupPath + "/inf.cmf")
        If info.Length = 3 Then
            If info(0) <> My.Computer.Info.OSFullName Or info(1) <> My.Computer.Info.OSPlatform Or info(2) <> My.Computer.Info.OSVersion Then
                Dim rez As MsgBoxResult
                rez = MsgBox("Данная копия программы не зарегистрирована!" & Chr(10) & "Получить лицензию?", MsgBoxStyle.YesNo, "Менеджер лицензий")
                If rez = 6 Then
                    Dim rez1 As DialogResult
                    rez1 = regist.ShowDialog()
                    If rez1 <> DialogResult.OK Then
                        Me.Close()
                    End If
                Else
                    Me.Close()
                End If
            End If
        Else
            Dim rez As MsgBoxResult
            rez = MsgBox("Данная копия программы не зарегистрирована!" & Chr(10) & "Получить лицензию?", MsgBoxStyle.YesNo, "Менеджер лицензий")
            If rez = 6 Then
                Dim rez1 As DialogResult
                rez1 = regist.ShowDialog()
                If rez1 <> DialogResult.OK Then
                    Me.Close()
                End If
            Else
                Me.Close()
            End If
        End If
    End Sub
End Class
