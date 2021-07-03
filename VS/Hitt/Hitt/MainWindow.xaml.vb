Class MainWindow
    Dim rand As New Random
    Dim x, y As Integer
    Dim i As Integer = 0
    Dim thick As Thickness
    Dim timer As New Threading.DispatcherTimer
    Dim tcount As New Threading.DispatcherTimer
    Dim count As Double = 9
    Dim state As Boolean = False
    Sub start() Handles Me.Loaded
        AddHandler tcount.Tick, AddressOf counting
        AddHandler timer.Tick, AddressOf randpos
        tcount.Interval = New TimeSpan(0, 0, 0, 0, 100)
        timer.Interval = New TimeSpan(0, 0, 0, 1)
        timer.Start()
        Title = "纪录   " + Str(i)
    End Sub
    Sub randpos()
        x = rand.Next(0, Int(window.ActualWidth) - Int(btn.ActualWidth) - progbar.ActualWidth)
        y = rand.Next(0, Int(window.ActualHeight) - Int(btn.ActualHeight))
        thick.Top = y
        thick.Left = x
        btn.Margin = thick
    End Sub
    Sub true_clicked() Handles btn.Click
        grid.Focus()
        i = i + 1
        Title = "纪录   " + Str(i)
        If state = False Then
            state = True
            tcount.Start()
            count = Int(textbox.Text) - 1
            progbar.Value = count
        End If
    End Sub

    Sub counting()
        count = count - 0.1
        progbar.Value = count
        If Int(count) = -1 Then
            tcount.Stop()
            count = 10
            state = False
            grid.Visibility = Visibility.Collapsed
            grid2.Visibility = Visibility.Collapsed
            label.Visibility = Visibility.Visible
            label.Content = Str(i)
            i = 0
        End If
    End Sub

    Private Sub label_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs) Handles label.PreviewMouseRightButtonDown
        grid.Visibility = Visibility.Visible
        grid2.Visibility = Visibility.Visible
        label.Visibility = Visibility.Collapsed
    End Sub

    Private Sub MainWindow_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles Me.SizeChanged
        Try
            textbox.FontSize = textbox.ActualHeight / 4 * 3
            label.FontSize = grid.ActualHeight / 4 * 3
            config.FontSize = config.ActualHeight / 4 * 3
        Catch
        End Try
    End Sub

    Sub config_Click() Handles config.Click
        Try
            count = Int(textbox.Text) - 1
        Catch
            count = 10
        End Try
        progbar.Maximum = Int(textbox.Text) - 1
        progbar.Value = Int(textbox.Text) - 1
        grid3.Visibility = Visibility.Collapsed
    End Sub

    Private Sub config_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs) Handles config.MouseRightButtonDown
        grid3.Visibility = Visibility.Visible
    End Sub
End Class
