Class MainWindow
    Dim btnList As New ArrayList
    Dim c As Collection
    Dim timer, timer2, timer3 As New Threading.DispatcherTimer
    Dim counts, cc As Integer
    Dim rand As New Random
    Dim b1, b2, b3, b4, b5, b6 As Boolean
    Sub generate()
        btnList.add(btn1)
        btnList.add(btn2)
        btnList.add(btn3)
        btnList.add(btn4)
        btnList.add(btn5)
        btnList.add(btn6)
        For Each btn In btnList
            randpos(btn)
        Next
        Grid.SetRow(btn1, 250)
        Grid.SetRow(btn2, 200)
        Grid.SetRow(btn3, 150)
        Grid.SetRow(btn4, 100)
        Grid.SetRow(btn5, 50)
        Grid.SetRow(btn6, 0)
        grid.Visibility = Visibility.Visible
        label.Visibility = Visibility.Hidden
        b1 = b2 = b3 = b4 = b5 = False
    End Sub
    Sub restart() Handles Me.PreviewMouseRightButtonDown
        generate()
        timer.Stop()
        timer2.Stop()
        timer3.Stop()
        Title = "0"
        counts = 0
        cc = 0
    End Sub
    Sub start() Handles Me.Loaded
        generate()
        AddHandler timer2.Tick, AddressOf count
        AddHandler timer.Tick, AddressOf count
        AddHandler timer3.Tick, AddressOf count
        timer3.Interval = New TimeSpan(0, 0, 0, 0, 1)
        timer.Interval = New TimeSpan(0, 0, 0, 0, 1)
        timer2.Interval = New TimeSpan(0, 0, 0, 0, 1)
    End Sub
    Sub count()
        cc += 1
        If cc = 1000 Then
            timer3.Start()
        ElseIf cc = 3000 Then
            timer2.Start()
        End If
        For Each btn In btnList
            Grid.SetRow(btn1, Grid.GetRow(btn) + 2)
        Next
        If Grid.GetRow(btn1) >= 300 Then
            acti(btn1, b1)
            b1 = False
        ElseIf Grid.GetRow(btn2) >= 300 Then
            acti(btn2, b2)
            b2 = False
        ElseIf Grid.GetRow(btn3) >= 300 Then
            acti(btn3, b3)
            b3 = False
        ElseIf Grid.GetRow(btn4) >= 300 Then
            acti(btn4, b4)
            b4 = False
        ElseIf Grid.GetRow(btn5) >= 300 Then
            acti(btn5, b5)
            b5 = False
        ElseIf Grid.GetRow(btn6) >= 300 Then
            acti(btn6, b6)
            b6 = False
        End If
    End Sub
    Sub acti(btn As Label, b As Boolean)
        If b = False Then
        End If
        randpos(btn)
        Grid.SetRow(btn, 0)
    End Sub
    Sub randpos(a As Label)
        Grid.SetColumn(a, rand.Next(1, 5) - 1)
        Dim b As New SolidColorBrush(Color.FromRgb(rand.Next(0, 155), rand.Next(0, 155), rand.Next(0, 155)))
        a.Background = b
    End Sub
    Sub b1c() Handles btn1.PreviewMouseLeftButtonDown
        timer.Start()
        clicked(btn1, b1)
        b1 = True
    End Sub
    Sub b2c() Handles btn2.PreviewMouseLeftButtonDown
        clicked(btn2, b2)
        b2 = True
    End Sub
    Sub b3c() Handles btn3.PreviewMouseLeftButtonDown
        clicked(btn3, b3)
        b3 = True
    End Sub
    Sub b4c() Handles btn4.PreviewMouseLeftButtonDown
        clicked(btn4, b4)
        b4 = True
    End Sub
    Sub b5c() Handles btn5.PreviewMouseLeftButtonDown
        clicked(btn5, b5)
        b5 = True
    End Sub
    Sub b6c() Handles btn6.PreviewMouseLeftButtonDown
        clicked(btn6, b6)
        b6 = True
    End Sub
    Sub clicked(btn As Label, b As Boolean)
        counts += 1
        Title = counts.ToString
        btn.Background = Brushes.White
    End Sub
    Sub stepWhite() Handles label.PreviewMouseLeftButtonDown
        grid.Visibility = Visibility.Collapsed
        label.Visibility = Visibility.Visible
        label.Content = counts.ToString
    End Sub
End Class
