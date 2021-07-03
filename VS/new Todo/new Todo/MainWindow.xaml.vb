Class MainWindow
    Sub size_changed() Handles Me.SizeChanged
        top.Width = Math.Abs(ActualWidth - 23)
        G.Cursor = Cursors.Cross
    End Sub
    Sub red_mouse_enter() Handles red.MouseEnter
        red.Fill = Brushes.DarkRed
    End Sub
    Sub red_mouse_leave() Handles red.MouseLeave
        red.Fill = Brushes.Red
    End Sub
    Sub green_mouse_enter() Handles green.MouseEnter
        green.Fill = Brushes.DarkGreen
        Dim rowdef As New RowDefinition
        rowdef.Height = New GridLength(30)
        Dim rowde As New RowDefinition
        rowde.Height = New GridLength(30)
        grid1.RowDefinitions.Add(rowdef)
        grid1.RowDefinitions.Add(rowde)
        Dim lab As New Label
        Grid.SetColumnSpan(lab, 3)
        lab.FontSize = 15
        lab.FontFamily = New FontFamily("Microsoft Yahei")
        lab.Foreground = Brushes.Yellow
        lab.FontWeight = FontWeights.Bold
        lab.HorizontalAlignment = HorizontalAlignment.Center
        lab.HorizontalContentAlignment = HorizontalAlignment.Center
        lab.VerticalAlignment = VerticalAlignment.Center
        lab.VerticalContentAlignment = VerticalAlignment.Center
        lab.Content = "单击绿键添加新项目"
        grid1.Children.Add(lab)
        Grid.SetRow(lab, grid1.RowDefinitions.Count - 2)
        Dim labe As New Label
        Grid.SetColumnSpan(labe, 3)
        labe.FontSize = 15
        labe.FontFamily = New FontFamily("Microsoft Yahei")
        labe.Foreground = Brushes.Blue
        labe.FontWeight = FontWeights.Bold
        labe.HorizontalAlignment = HorizontalAlignment.Center
        labe.HorizontalContentAlignment = HorizontalAlignment.Center
        labe.VerticalAlignment = VerticalAlignment.Center
        labe.VerticalContentAlignment = VerticalAlignment.Center
        labe.Content = "项目两次点击右键删除"
        grid1.Children.Add(labe)
        Grid.SetRow(labe, grid1.RowDefinitions.Count - 1)
    End Sub
    Sub green_mouse_leave() Handles green.MouseLeave
        green.Fill = Brushes.Green
        grid1.Children.RemoveRange(grid1.Children.Count - 2, grid1.Children.Count - 1)
        grid1.RowDefinitions.RemoveAt(grid1.RowDefinitions.Count - 1)
        grid1.RowDefinitions.RemoveAt(grid1.RowDefinitions.Count - 2)
    End Sub
    Sub yellow_mouse_enter() Handles yellow.MouseEnter
        yellow.Fill = Brushes.YellowGreen
    End Sub
    Sub yellow_mouse_leave() Handles yellow.MouseLeave
        yellow.Fill = Brushes.Yellow
    End Sub
    Sub red_click() Handles red.MouseLeftButtonDown
        window.Close()
    End Sub
    Sub yellow_click() Handles yellow.MouseLeftButtonDown
        window.WindowState = WindowState.Minimized
    End Sub
    Dim path As String
    Dim rand As New Random
    Dim rowcount As Integer
    Sub config() Handles configBtn.Click
        Dim writer As New IO.StreamWriter(path, True)
        If Not input.Text = "" Then
            writer.Write("\" + input.Text)
        End If
        writer.Close()
        configBtn.Visibility = Visibility.Collapsed
        input.Visibility = Visibility.Collapsed
        input.Text = ""
        generate()
        configBtn.IsDefault = False
    End Sub
    Sub load() Handles Me.Loaded
        path = "C://users//" + Environment.UserName + "//documents//todo.txt"
        If IO.File.Exists(path) = False Then
            IO.File.Create(path).Close()
            Dim writer As New IO.StreamWriter(path)
            writer.Write("Hello World!" + "\")
            writer.Close()
            generate()
        End If
        WindowStartupLocation = WindowStartupLocation.CenterOwner
    End Sub
    Function r()
        Return rand.Next(100, 255)
    End Function
    Public Sub generate() Handles Me.Loaded
        Dim e As Integer = 0
        Dim reader As New IO.StreamReader(path)
        Dim str As String = reader.ReadToEnd()
        grid1.RowDefinitions.Clear()
        grid1.Children.RemoveRange(3, 100)
        For Each i In str.Split("\")
            Dim rowdef As New RowDefinition
            rowdef.Height = New GridLength(30)
            grid1.RowDefinitions.Add(rowdef)
            Dim lab As New Label
            lab.Content = i
            lab.FontSize = 16
            lab.FontWeight = FontWeights.Bold
            lab.Foreground = Brushes.White
            lab.FontFamily = New FontFamily("Microsoft Yahei")
            AddHandler lab.MouseRightButtonDown, Sub(render As Object, ByVal a As MouseButtonEventArgs)
                                                     If lab.Background.Equals(Brushes.Red) Then
                                                         Dim writer As New IO.StreamWriter(path)
                                                         writer.Write(str.Replace("\" + lab.Content, ""))
                                                         writer.Close()
                                                         generate()
                                                     Else
                                                         lab.Background = Brushes.Red
                                                     End If
                                                 End Sub
            AddHandler lab.MouseEnter, Sub(render As Object, ByVal a As MouseEventArgs)
                                           lab.Background = New SolidColorBrush(Color.FromRgb(112, 112, 112))
                                       End Sub
            AddHandler lab.MouseLeave, Sub(render As Object, ByVal a As MouseEventArgs)
                                           lab.Background = Brushes.Gray
                                       End Sub
            Grid.SetColumnSpan(lab, 3)
            grid1.Children.Add(lab)
            Grid.SetRow(lab, e)
            e += 1
        Next
        reader.Close()
    End Sub
    Sub add() Handles green.MouseLeftButtonDown
        configBtn.Visibility = Visibility.Visible
        input.Visibility = Visibility.Visible
        configBtn.IsDefault = True
        input.Focus()
    End Sub
    Sub drag() Handles window.MouseLeftButtonDown
        window.WindowState = WindowState.Normal
        window.DragMove()
    End Sub
End Class
