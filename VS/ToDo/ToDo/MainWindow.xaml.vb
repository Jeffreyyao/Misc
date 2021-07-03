Class MainWindow
    Dim path As String
    Dim rand As New Random
    Sub config() Handles configBtn.Click
        Dim writer As New IO.StreamWriter(path, True)
        If Not input.Text = "" Then
            writer.Write("\" + input.Text)
        End If
        writer.Close()
        label.Visibility = Visibility.Visible
        btnAdd.Visibility = Visibility.Visible
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
        End If
        WindowStartupLocation = WindowStartupLocation.CenterOwner
    End Sub
    Function r()
        Return rand.Next(0, 200)
    End Function
    Public Sub generate() Handles Me.Loaded
        Dim e As Integer = 0
        Dim reader As New IO.StreamReader(path)
        Dim str As String = reader.ReadToEnd()
        grid1.RowDefinitions.Clear()
        grid1.Children.Clear()
        For Each i In str.Split("\")
            Dim rowdef As New RowDefinition
            rowdef.Height = New GridLength(30)
            grid1.RowDefinitions.Add(rowdef)
            Dim lab As New Label
            lab.Content = i
            lab.FontSize = 16
            lab.FontWeight = FontWeights.Bold
            lab.Foreground = New SolidColorBrush(Color.FromRgb(r(), r(), r()))
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
                                           lab.Background = Brushes.Gainsboro
                                       End Sub
            AddHandler lab.MouseLeave, Sub(render As Object, ByVal a As MouseEventArgs)
                                           lab.Background = Brushes.White
                                       End Sub
            AddHandler lab.MouseLeftButtonDown, Sub(render As Object, ByVal a As MouseButtonEventArgs)
                                                    lab.Background = Brushes.White
                                                End Sub
            Grid.SetColumnSpan(lab, 3)
            grid1.Children.Add(lab)
            Grid.SetRow(lab, e)
            e += 1
        Next
        reader.Close()
    End Sub
    Sub add() Handles btnAdd.Click
        label.Visibility = Visibility.Collapsed
        btnAdd.Visibility = Visibility.Collapsed
        configBtn.Visibility = Visibility.Visible
        input.Visibility = Visibility.Visible
        configBtn.IsDefault = True
        input.Focus()
    End Sub
    Sub drag() Handles label.MouseLeftButtonDown
        window.DragMove()
    End Sub
    Sub closee() Handles btnAdd.MouseRightButtonDown
        window.Close()
    End Sub
End Class
