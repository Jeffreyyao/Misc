Class MainWindow
    Dim rand As New Random
    Dim isDown As Boolean = False
    Sub load() Handles Me.Loaded
        For e = 0 To 10
            Dim rd As New RowDefinition()
            rd.Height = New GridLength(1, GridUnitType.Star)
            grid.RowDefinitions.Add(New RowDefinition)
        Next
        For i = 0 To 100
            For j = 0 To 100
                Dim gri As New Grid
                Grid.SetRow(gri, i)
                Grid.SetColumn(gri, j)
                grid.Children.Add(gri)
                AddHandler gri.MouseLeftButtonDown, Sub()
                                                        Dim ell As New Ellipse
                                                        ell.Fill = New SolidColorBrush(Color.FromRgb(255, 0, 0))
                                                        gri.Children.Add(ell)
                                                    End Sub
            Next
        Next

    End Sub
    Function c() As Brush
        Dim r As Integer = rand.Next(100, 255)
        Dim g As Integer = rand.Next(100, 255)
        Dim b As Integer = rand.Next(100, 255)
        Return New SolidColorBrush(Color.FromRgb(r, g, b))
    End Function
End Class
