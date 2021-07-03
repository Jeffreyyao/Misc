Class MainWindow
    Dim timer As New Threading.DispatcherTimer
    Dim rand As New Random
    Dim every As Boolean = False
    Dim hline, mline, sline As New Line
    Sub size_changed() Handles Me.SizeChanged
        Me.Width = Me.ActualHeight
        hline.Y2 = Me.ActualHeight / 4
        mline.Y2 = Me.ActualHeight / 20 * 8
        sline.Y2 = Me.ActualHeight / 20 * 9.5
    End Sub
    Sub load() Handles Me.Loaded
        For i = 0 To 9
            grid.RowDefinitions.Add(New RowDefinition)
            grid.ColumnDefinitions.Add(New ColumnDefinition)
        Next
        For i = 0 To 9
            For j = 0 To 9
                Dim gri As New Rectangle
                gri.Fill = New SolidColorBrush(Color.FromRgb(rand.Next(0, 220), rand.Next(0, 220), rand.Next(0, 220)))
                AddHandler gri.MouseLeftButtonDown, Sub()
                                                        gri.Fill = New SolidColorBrush(Color.FromRgb(rand.Next(0, 220), rand.Next(0, 220), rand.Next(0, 220)))
                                                    End Sub
                grid.Children.Add(gri)
                Grid.SetColumn(gri, i)
                Grid.SetRow(gri, j)
            Next
        Next
        hline.Y2 = Me.ActualHeight / 4
        hline.Stroke = Brushes.White
        hline.StrokeThickness = 4
        grid.Children.Add(hline)
        mline.Y2 = Me.ActualHeight / 20 * 8
        mline.Stroke = Brushes.White
        mline.StrokeThickness = 4
        grid.Children.Add(mline)
        sline.Y2 = Me.ActualHeight / 20 * 9.5
        sline.Stroke = Brushes.White
        sline.StrokeThickness = 2
        grid.Children.Add(sline)
        Grid.SetColumn(hline, 5)
        Grid.SetRow(hline, 5)
        Grid.SetColumn(mline, 5)
        Grid.SetRow(mline, 5)
        Grid.SetColumn(sline, 5)
        Grid.SetRow(sline, 5)
        Grid.SetRowSpan(hline, 5)
        Grid.SetColumnSpan(hline, 5)
        Grid.SetRowSpan(mline, 5)
        Grid.SetColumnSpan(mline, 5)
        Grid.SetRowSpan(sline, 5)
        Grid.SetColumnSpan(sline, 5)
        Dim cir As New Ellipse
        cir.Width = 5
        cir.Height = 5
        cir.Fill = Brushes.White
        Grid.SetRowSpan(cir, 10)
        Grid.SetColumnSpan(cir, 10)
        grid.Children.Add(cir)
        timer.Interval = New TimeSpan(0, 0, 0, 0, 200)
        AddHandler timer.Tick, AddressOf refresh
        timer.Start()
    End Sub
    Sub drag() Handles grid.MouseLeftButtonDown
        window.WindowState = WindowState.Normal
        window.DragMove()
    End Sub
    Sub refresh()
        Dim hour As Integer = Date.Now.Hour
        Dim min As Integer = Date.Now.Minute
        Dim sec As Integer = Date.Now.Second
        If hour > 12 Then
            hour -= 12
        End If
        hline.RenderTransform = New RotateTransform(Int((hour + min / 60) / 12 * 360 + 180))
        mline.RenderTransform = New RotateTransform(Int(min / 60 * 360 + 180))
        sline.RenderTransform = New RotateTransform(Int(sec / 60 * 360 + 180))
    End Sub
    Sub endd() Handles Me.MouseRightButtonDown
        Me.Close()
    End Sub
End Class
