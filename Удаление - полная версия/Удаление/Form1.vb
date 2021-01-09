Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rez As DialogResult
        rez = OpenFileDialog1.ShowDialog()
        If rez = 1 Then
            Dim dat As String
            Button2.Enabled = True
            Button4.Enabled = True
            Dim rez1 As String = My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileName).Name
            dat = OpenFileDialog1.FileName
            ListBox1.Items.Clear()
            ListBox1.Items.Add(dat)
            ListBox1.Items.Add("Имя удаляемого файла: " & Mid(rez1, 1, rez1.LastIndexOf(".")))
            ListBox1.Items.Add("Дата создания файла: " & My.Computer.FileSystem.GetFileInfo(dat).CreationTime)
            ListBox1.Items.Add("Дата последнего доступа к файлу: " & My.Computer.FileSystem.GetFileInfo(dat).LastWriteTime)
            ListBox1.Items.Add("Размер файла: " & Math.Ceiling(My.Computer.FileSystem.GetFileInfo(dat).Length / 1000) & " kb")
            ListBox1.Items.Add("Имя папки, содержащей файл: " & My.Computer.FileSystem.GetFileInfo(dat).DirectoryName)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim rez As DialogResult
        Dim rez1 As String
        Try
            Form2.TextBox1.Text = My.Computer.FileSystem.GetFileInfo(ListBox1.Items.Item(0)).Length
            rez1 = My.Computer.FileSystem.GetFileInfo(ListBox1.Items.Item(0)).Name
            rez1 = Mid(rez1, 1, rez1.LastIndexOf("."))
            rez = Form2.ShowDialog()
            If rez = DialogResult.OK Then
                My.Computer.FileSystem.GetFileInfo(ListBox1.Items.Item(0)).Delete()
                My.Computer.FileSystem.WriteAllText(Application.StartupPath + "/reg.cmf", "  " & OpenFileDialog1.FileName & "  " & My.Computer.Clock.LocalTime & "  Информация о системе: " & My.Computer.Info.OSPlatform & Chr(10) & "--------", True)
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                MsgBox("Удаление файла '" & rez1 & "' завершено успешно!", , "Информация")
            Else
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                MsgBox("Удаление файла '" & rez1 & "' отменено!", , "Информация")
            End If
        Catch ex As Exception
            MsgBox("Нет доступа к файлу для удаления!", , "Информация")
        End Try
        ListBox1.Items.Clear()
        Button2.Enabled = False
        Button4.Enabled = False
        ListBox1.Items.Add("Файл не выбран!")
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SplashScreen1.ShowDialog()
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
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ListBox1.Items.Clear()
        Button2.Enabled = False
        Button4.Enabled = False
        ListBox1.Items.Add("Файл не выбран!")
    End Sub
End Class
