Class MainWindow
    Dim count As Integer = 1
    Sub sizechange() Handles Me.SizeChanged
        window.Width = window.ActualHeight
    End Sub
    Sub load() Handles Me.Loaded
        For e = 0 To 20
            grid.RowDefinitions.Add(New RowDefinition)
            grid.ColumnDefinitions.Add(New ColumnDefinition)
        Next
    End Sub
    Sub generate() Handles Me.Loaded
        grid.Children.Clear()
        Title = "Black"
        For i = 0 To 20
            For j = 0 To 20
                Dim bor As New Border
                bor.BorderBrush = Brushes.White
                bor.BorderThickness = New Thickness(0.7)
                Grid.SetColumn(bor, i)
                Grid.SetRow(bor, j)
                Dim gri As New Grid
                gri.Background = Brushes.Chocolate
                grid.Children.Add(bor)
                bor.Child = gri
                AddHandler gri.MouseLeftButtonDown, Sub(render As Object, e As MouseButtonEventArgs)
                                                        gri.Children.Clear()
                                                        Dim ell As New Ellipse
                                                        If count = 1 Then
                                                            ell.Fill = Brushes.Black
                                                            count = count * -1
                                                            Title = "White"
                                                        Else
                                                            ell.Fill = Brushes.White
                                                            count = count * -1
                                                            Title = "Black"
                                                        End If
                                                        gri.Children.Add(ell)
                                                        findFives()
                                                    End Sub
            Next
        Next
    End Sub
    Sub findFives()
        Dim arrWhite(30, 30) As Integer
        Dim arrBlack(30, 30) As Integer
        Dim collection As UIElementCollection = grid.Children
        For Each bo As Border In collection
            Dim g As Grid = bo.Child
            If Not g.Children.Count = 0 Then
                Dim ell As Ellipse = g.Children(g.Children.Count - 1)
                If ell.Fill.Equals(Brushes.White) Then
                    Dim gri As Grid = ell.Parent
                    Dim bor As Border = gri.Parent
                    arrWhite(Grid.GetColumn(bor) + 1, Grid.GetRow(bor) + 1) = 1
                ElseIf ell.Fill.Equals(Brushes.Black) Then
                    Dim gri As Grid = ell.Parent
                    Dim bor As Border = gri.Parent
                    arrBlack(Grid.GetColumn(bor) + 1, Grid.GetRow(bor) + 1) = 1
                End If
            End If
        Next
        For x = 0 To 20
            For y = 0 To 20
                If arrWhite(x, y) = 1 And arrWhite(x + 1, y) = 1 And arrWhite(x + 2, y) = 1 And arrWhite(x + 3, y) = 1 And arrWhite(x + 4, y) = 1 Then
                    wins("white")
                End If
                If arrBlack(x, y) = 1 And arrBlack(x + 1, y) = 1 And arrBlack(x + 2, y) = 1 And arrBlack(x + 3, y) = 1 And arrBlack(x + 4, y) = 1 Then
                    wins("black")
                End If
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------               
                If arrWhite(x, y) = 1 And arrWhite(x + 1, y + 1) = 1 And arrWhite(x + 2, y + 2) = 1 And arrWhite(x + 3, y + 3) = 1 And arrWhite(x + 4, y + 4) = 1 Then
                    wins("white")
                End If
                If arrBlack(x, y + 1) = 1 And arrBlack(x + 1, y + 1) = 1 And arrBlack(x + 2, y + 2) = 1 And arrBlack(x + 3, y + 3) = 1 And arrBlack(x + 4, y + 4) = 1 Then
                    wins("black")
                End If
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------               
                If arrWhite(x, y) = 1 And arrWhite(x, y + 1) = 1 And arrWhite(x, y + 2) = 1 And arrWhite(x, y + 3) = 1 And arrWhite(x, y + 4) = 1 Then
                    wins("white")
                End If
                If arrBlack(x, y) = 1 And arrBlack(x, y + 1) = 1 And arrBlack(x, y + 2) = 1 And arrBlack(x, y + 3) = 1 And arrBlack(x, y + 4) = 1 Then
                    wins("black")
                End If
            Next
        Next
        For x = 4 To 24
            For y = 4 To 24
                If arrWhite(x, y) = 1 And arrWhite(x - 1, y + 1) = 1 And arrWhite(x - 2, y + 2) = 1 And arrWhite(x - 3, y + 3) = 1 And arrWhite(x - 4, y + 4) = 1 Then
                    wins("White")
                End If
                If arrBlack(x, y) = 1 And arrBlack(x - 1, y + 1) = 1 And arrBlack(x - 2, y + 2) = 1 And arrBlack(x - 3, y + 3) = 1 And arrBlack(x - 4, y + 4) = 1 Then
                    wins("Black")
                End If
            Next
        Next
    End Sub
    Sub wins(color As String)
        grid.Children.Clear()
        Dim lab As New Label
        lab.Content = color + " wins!"
        lab.HorizontalContentAlignment = HorizontalAlignment.Center
        lab.VerticalContentAlignment = VerticalAlignment.Center
        lab.HorizontalAlignment = HorizontalAlignment.Center
        lab.VerticalAlignment = VerticalAlignment.Center
        Grid.SetColumnSpan(lab, 20)
        Grid.SetRowSpan(lab, 20)
        grid.Children.Add(lab)
        lab.FontSize = 50
        AddHandler lab.MouseRightButtonDown, AddressOf generate
    End Sub
End Class
