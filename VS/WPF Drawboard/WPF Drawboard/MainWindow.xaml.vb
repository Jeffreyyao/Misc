Imports System.IO
Class MainWindow
    Dim prex, prey, drawstate, x, y
    Dim point1, point2 As Point
    Dim col As Color
    Dim b As Brush

    Private Sub MainWindow_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseRightButtonDown
        canvas.Children.Clear()
    End Sub

    Private Sub MainWindow_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseUp
        drawstate = False
    End Sub

    Private Sub MainWindow_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseLeftButtonDown
        prex = e.GetPosition(canvas).X
        prey = e.GetPosition(canvas).Y
        drawstate = True
    End Sub

    Private Sub MainWindow_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If drawstate = True Then
            x = e.GetPosition(canvas).X
            y = e.GetPosition(canvas).Y
            b = New SolidColorBrush(col)
            Dim line As New Line
            line.X1 = prex
            line.Y1 = prey
            line.X2 = x
            line.Y2 = y
            line.Stroke = b
            line.StrokeThickness = 2
            canvas.Children.Add(line)
        End If
    End Sub

    Private Sub MainWindow_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles Me.PreviewKeyDown
        Try
            If e.Key = Key.Space Then
                Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                Dim pic As RenderTargetBitmap = New RenderTargetBitmap(mainwindow.ActualWidth, mainwindow.ActualHeight, 96D, 96D, PixelFormats.Default)
                pic.Render(mainwindow)
                Dim encoder As BmpBitmapEncoder = New BmpBitmapEncoder()
                encoder.Frames.Add(BitmapFrame.Create(pic))
                Dim rnd As New Random
                Dim a As Integer = rnd.Next(100000)
                Dim filename As String = path + "\" + a.ToString + ".jpg"
                Dim fs As FileStream = File.Open(filename, FileMode.OpenOrCreate)
                encoder.Save(fs)
                MsgBox("保存图片到" & path)
            End If
        Finally
        End Try
    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        grid2.Visibility = Visibility.Visible
        button1.Visibility = Visibility.Hidden
    End Sub
    Sub changed_select() Handles sl.MouseMove, sli.MouseMove, slid.MouseMove
        col.A = 255
        col.R = Int(sl.Value)
        col.G = Int(sli.Value)
        col.B = Int(slid.Value)
        b = New SolidColorBrush(col)
        btn.Background = b
        button1.Background = b
    End Sub

    Private Sub btn_Click(sender As Object, e As RoutedEventArgs) Handles btn.Click
        grid2.Visibility = Visibility.Hidden
        button1.Visibility = Visibility.Visible
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        col.A = 255
        col.R = 0
        col.G = 0
        col.B = 0
    End Sub
End Class
