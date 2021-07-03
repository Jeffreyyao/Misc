Class MainWindow
    Dim t As Threading.DispatcherTimer = New Threading.DispatcherTimer
    Dim countt As Threading.DispatcherTimer = New Threading.DispatcherTimer
    Dim l, r, u, d As Boolean
    Dim foodthick, snakethick As Thickness
    Dim rand As New Random
    Dim record As Integer = 0
    Dim count As Integer = 100

    Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        AddHandler t.Tick, AddressOf move
        randpos()
        t.Interval = New TimeSpan(0, 0, 0, 0, 1)
        t.Start()
        l = False
        r = False
        u = False
        d = False
    End Sub
    Sub move()
        If r = True Then
            snakethick.Left = snakethick.Left + 5
            If snakethick.Left > grid.ActualWidth - 22 Then
                snakethick.Left = 0
            End If
            snake.Margin = snakethick
            If food.Margin.Top - 18 < snake.Margin.Top And snake.Margin.Top < food.Margin.Top + 18 Then
                If food.Margin.Left - 2.5 < snake.Margin.Left + 22 And food.Margin.Left + 2.5 > snake.Margin.Left + 22 Then
                    record = record + 1
                    Title = "纪录   " + Str(record)
                    randpos()
                End If
            End If
        ElseIf u = True Then
            snakethick.Top = snakethick.Top - 5
            If snakethick.Top < 0 Then
                snakethick.Top = grid.ActualHeight - 22
            End If
            snake.Margin = snakethick
            If snake.Margin.Left - 18 < food.Margin.Left And food.Margin.Left < snake.Margin.Left + 18 Then
                If snake.Margin.Top - 2.5 < food.Margin.Top + 22 And snake.Margin.Top + 2.5 < food.Margin.Top + 22 Then
                    record = record + 1
                    Title = "纪录   " + Str(record)
                    randpos()
                End If
            End If
        ElseIf l = True Then
            snakethick.Left = snakethick.Left - 5
            If snakethick.Left < 0 Then
                snakethick.Left = grid.ActualWidth - 22
            End If
            snake.Margin = snakethick
            If snake.Margin.Top - 18 < food.Margin.Top And food.Margin.Top < snake.Margin.Top + 18 Then
                If snake.Margin.Left - 2.5 < food.Margin.Left + 22 And snake.Margin.Left + 2.5 > food.Margin.Left + 22 Then
                    record = record + 1
                    Title = "纪录   " + Str(record)
                    randpos()
                End If
            End If
        ElseIf d = True Then
            snakethick.Top = snakethick.Top + 5
            If snakethick.Top > grid.ActualHeight - 22 Then
                snakethick.Top = 0
            End If
            snake.Margin = snakethick
            If snake.Margin.Left - 18 < food.Margin.Left And food.Margin.Left < snake.Margin.Left + 18 Then
                If food.Margin.Top - 2.5 < snake.Margin.Top + 22 And food.Margin.Top + 2.5 < snake.Margin.Top + 22 Then
                    record = record + 1
                    Title = "纪录   " + Str(record)
                    randpos()
                End If
            End If
        End If
        If count = 0 Then
            countt.Stop()
            count = 100
            MsgBox(Str(record),, "你的成绩")
        End If
    End Sub

    Private Sub snake_Click(sender As Object, e As RoutedEventArgs) Handles snake.Click
        record = 0
        Title = "纪录   " + Str(record)
        count = 100
        AddHandler countt.Tick, AddressOf counting
        countt.Interval = New TimeSpan(0, 0, 0, 1)
        countt.Start()
    End Sub

    Private Sub MainWindow_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles Me.PreviewKeyDown
        If e.Key = Key.I Or e.Key = Key.Up Then
            u = True
            r = False
            d = False
            l = False
        ElseIf e.Key = Key.K Or e.Key = Key.Down Then
            d = True
            u = False
            r = False
            l = False
        ElseIf e.Key = Key.J Or e.Key = Key.Left Then
            r = False
            d = False
            u = False
            l = True
        ElseIf e.Key = Key.L Or e.Key = Key.Left Then
            l = False
            r = True
            d = False
            u = False
        Else
            l = False
            r = False
            d = False
            u = False
        End If
    End Sub
    Sub randpos() Handles food.Click, Me.SizeChanged
        foodthick.Top = rand.Next(11, Int(grid.ActualHeight) - 22)
        foodthick.Left = rand.Next(11, Int(grid.ActualWidth) - 22)
        food.Margin = foodthick
    End Sub
    Sub hhh() Handles food.Click
        record = record + 1
        Title = "记录   " + Str(record)
    End Sub
    Sub counting()
        count = count - 1
        progbar.Value = count
    End Sub
End Class
