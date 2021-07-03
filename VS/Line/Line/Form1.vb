Public Class Form1
    Dim abc, x, y, i, a

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim g As Graphics = CreateGraphics()
        Dim p = New Pen(ForeColor)
        g.TranslateTransform(x, y)
        If e.KeyCode = Keys.W Then
            g.RotateTransform(-60)
            g.DrawLine(p, 0, 0, 0, 50)
            g.TranslateTransform(0, 50)
            g.RotateTransform(60)
        ElseIf e.KeyCode = Keys.E Then
            g.RotateTransform(60)
            g.DrawLine(p, 0, 0, 0, 50)
            g.TranslateTransform(0, 50)
            g.RotateTransform(-60)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        x = Width \ 2
        y = Height \ 2
    End Sub
End Class
