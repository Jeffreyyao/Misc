Public Class Form1
    Dim z, x1, x2, x3, x4, result As Double  'x1加，x2减,x3乘,x4除
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        z = 1
        x1 = 0
        x2 = 0
        x3 = 1
        x4 = 0
        TextBox4.Text = "*"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        z = 1
        x1 = 0
        x2 = 0
        x3 = 0
        x4 = 1
        TextBox4.Text = "/"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        z = 1
        x1 = 1
        x2 = 0
        x3 = 0
        x4 = 0
        TextBox4.Text = "+"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        z = 1
        x1 = 0
        x2 = 1
        x3 = 0
        x4 = 0
        TextBox4.Text = "-"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "."
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "."
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "0"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "0"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "00"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "00"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "1"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "1"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "2"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "2"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        z = 0
        x1 = 0
        x2 = 0
        x3 = 0
        x4 = 0
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "3"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "3"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "4"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "4"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "5"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "5"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "6"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "6"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "7"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "7"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "8"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "8"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If z = 1 Then
            TextBox3.Text = TextBox3.Text + "9"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        Else
            TextBox2.Text = TextBox2.Text + "9"
            TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If x1 = 1 Then
            result = Val(TextBox2.Text) + Val(TextBox3.Text)
            TextBox1.Text = result
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            z = 0
            x1 = 0
            x2 = 0
            x3 = 0
            x4 = 0
        ElseIf x2 = 1 Then
            result = Val(TextBox2.Text) - Val(TextBox3.Text)
            TextBox1.Text = result
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            z = 0
            x1 = 0
            x2 = 0
            x3 = 0
            x4 = 0
        ElseIf x3 = 1 Then
            result = Val(TextBox2.Text) * Val(TextBox3.Text)
            TextBox1.Text = result
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            z = 0
            x1 = 0
            x2 = 0
            x3 = 0
            x4 = 0
        ElseIf x4 = 1 Then
            If TextBox3.Text = 0 Then
                TextBox1.Text = "除数不能为零sb"
            Else
                result = Val(TextBox2.Text) / Val(TextBox3.Text)
                TextBox1.Text = result
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                z = 0
                x1 = 0
                x2 = 0
                x3 = 0
                x4 = 0
            End If
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.L Then
            Height = 337
        ElseIf e.KeyCode = Keys.S Then
            Height = 302
        ElseIf e.KeyCode = Keys.D0 Then
            If z = 1 Then
                TextBox3.Text = TextBox3.Text + "0"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            Else
                TextBox2.Text = TextBox2.Text + "0"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            End If
        ElseIf e.KeyCode = Keys.D1 Then
            If z = 1 Then
                TextBox3.Text = TextBox3.Text + "1"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            Else
                TextBox2.Text = TextBox2.Text + "1"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            End If
        ElseIf e.KeyCode = Keys.D2 Then
            If z = 1 Then
                TextBox3.Text = TextBox3.Text + "2"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            Else
                TextBox2.Text = TextBox2.Text + "2"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            End If
        ElseIf e.KeyCode = Keys.D3 Then
            If z = 1 Then
                TextBox3.Text = TextBox3.Text + "3"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            Else
                TextBox2.Text = TextBox2.Text + "3"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            End If
        ElseIf e.KeyCode = Keys.D4 Then
            If z = 1 Then
                TextBox3.Text = TextBox3.Text + "4"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            Else
                TextBox2.Text = TextBox2.Text + "4"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            End If
        ElseIf e.KeyCode = Keys.D5 Then
            If z = 1 Then
                TextBox3.Text = TextBox3.Text + "5"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            Else
                TextBox2.Text = TextBox2.Text + "5"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            End If
        ElseIf e.KeyCode = Keys.D6 Then
            If z = 1 Then
                TextBox3.Text = TextBox3.Text + "6"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            Else
                TextBox2.Text = TextBox2.Text + "6"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            End If
        ElseIf e.KeyCode = Keys.D7 Then
            If z = 1 Then
                TextBox3.Text = TextBox3.Text + "7"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            Else
                TextBox2.Text = TextBox2.Text + "7"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            End If
        ElseIf e.KeyCode = Keys.D8 Then
            If z = 1 Then
                TextBox3.Text = TextBox3.Text + "8"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            Else
                TextBox2.Text = TextBox2.Text + "8"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            End If
        ElseIf e.KeyCode = Keys.D9 Then
            If z = 1 Then
                TextBox3.Text = TextBox3.Text + "9"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            Else
                TextBox2.Text = TextBox2.Text + "9"
                TextBox1.Text = TextBox2.Text + TextBox4.Text + TextBox3.Text
            End If
        ElseIf e.KeyCode = Keys.oemplus Then
            z = 1
            x1 = 1
            x2 = 0
            x3 = 0
            x4 = 0
            TextBox4.Text = "+"
        ElseIf e.KeyCode = Keys.OemMinus Then
            z = 1
            x1 = 0
            x2 = 1
            x3 = 0
            x4 = 0
            TextBox4.Text = "-"
        ElseIf e.KeyCode = Keys.space Then
            Button19.Focus()
            If x1 = 1 Then
                result = Val(TextBox2.Text) + Val(TextBox3.Text)
                TextBox1.Text = result
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                z = 0
                x1 = 0
                x2 = 0
                x3 = 0
                x4 = 0
            ElseIf x2 = 1 Then
                result = Val(TextBox2.Text) - Val(TextBox3.Text)
                TextBox1.Text = result
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                z = 0
                x1 = 0
                x2 = 0
                x3 = 0
                x4 = 0
            ElseIf x3 = 1 Then
                result = Val(TextBox2.Text) * Val(TextBox3.Text)
                TextBox1.Text = result
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                z = 0
                x1 = 0
                x2 = 0
                x3 = 0
                x4 = 0
            ElseIf x4 = 1 Then
                If TextBox3.Text = 0 Then
                    TextBox1.Text = "除数不能为零sb"
                Else
                    result = Val(TextBox2.Text) / Val(TextBox3.Text)
                    TextBox1.Text = result
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    z = 0
                    x1 = 0
                    x2 = 0
                    x3 = 0
                    x4 = 0
                End If
            End If
        ElseIf e.KeyCode = Keys.Back Then
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            z = 0
            x1 = 0
            x2 = 0
            x3 = 0
            x4 = 0
        End If
    End Sub
End Class
