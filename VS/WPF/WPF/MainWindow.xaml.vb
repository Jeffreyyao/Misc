Class MainWindow
    Dim minus, plus, mulitiply, divide, sec, seccal As Boolean
    Dim result As Double
    Private Sub button00_Click(sender As Object, e As RoutedEventArgs) Handles button00.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "00"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "00"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub button0_Click(sender As Object, e As RoutedEventArgs) Handles button0.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "0"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "0"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "1"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "1"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub button2_Click(sender As Object, e As RoutedEventArgs) Handles button2.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "2"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "2"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub button3_Click(sender As Object, e As RoutedEventArgs) Handles button3.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "3"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "3"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub button4_Click(sender As Object, e As RoutedEventArgs) Handles button4.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "4"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "4"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub button5_Click(sender As Object, e As RoutedEventArgs) Handles button5.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "5"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "5"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub button6_Click(sender As Object, e As RoutedEventArgs) Handles button6.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "6"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "6"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub button7_Click(sender As Object, e As RoutedEventArgs) Handles button7.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "7"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "7"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub button8_Click(sender As Object, e As RoutedEventArgs) Handles button8.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "8"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "8"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub button9_Click(sender As Object, e As RoutedEventArgs) Handles button9.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "9"
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "9"
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub buttoncancel_Click(sender As Object, e As RoutedEventArgs) Handles buttoncancel.Click
        textBox1.Text = ""
        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""
        divide = False
        minus = False
        plus = False
        mulitiply = False
        sec = False
        textBox5.Focus()
    End Sub

    Private Sub buttondivide_Click(sender As Object, e As RoutedEventArgs) Handles buttondivide.Click
        If textBox2.Text <> "" And textBox4.Text <> "" Then
            textBox1.Text = result
            If divide = True Then
                If Val(textBox4.Text) = 0 Then
                    textBox1.Text = "SB"
                Else
                    textBox1.Text = Val(textBox2.Text) / Val(textBox4.Text)
                End If
            ElseIf minus = True Then
                textBox1.Text = Val(textBox2.Text) - Val(textBox4.Text)
            ElseIf plus = True Then
                textBox1.Text = Val(textBox2.Text) + Val(textBox4.Text)
            ElseIf mulitiply = True Then
                textBox1.Text = Val(textBox2.Text) * Val(textBox4.Text)
            End If
            result = Val(textBox1.Text)
            textBox2.Text = ""
            textBox3.Text = ""
            textBox4.Text = ""
            divide = False
            minus = False
            plus = False
            mulitiply = False
            sec = False
            seccal = True
        End If
        divide = True
        minus = False
        plus = False
        mulitiply = False
        sec = True
        textBox3.Text = "/"
        If seccal = True Then
            textBox2.Text = result
        End If
        textBox5.Focus()
    End Sub

    Private Sub buttonequils_Click(sender As Object, e As RoutedEventArgs) Handles buttonequils.Click
        If divide = True Then
            If Val(textBox4.Text) = 0 Then
                textBox1.Text = "SB"
            Else
                textBox1.Text = Val(textBox2.Text) / Val(textBox4.Text)
            End If
        ElseIf minus = True Then
            textBox1.Text = Val(textBox2.Text) - Val(textBox4.Text)
        ElseIf plus = True Then
            textBox1.Text = Val(textBox2.Text) + Val(textBox4.Text)
        ElseIf mulitiply = True Then
            textBox1.Text = Val(textBox2.Text) * Val(textBox4.Text)
        End If
        result = Val(textBox1.Text)
        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""
        divide = False
        minus = False
        plus = False
        mulitiply = False
        sec = False
        seccal = True
        textBox5.Focus()
    End Sub

    Private Sub buttonminus_Click(sender As Object, e As RoutedEventArgs) Handles buttonminus.Click
        If textBox2.Text <> "" And textBox4.Text <> "" Then
            textBox1.Text = result
            If divide = True Then
                If Val(textBox4.Text) = 0 Then
                    textBox1.Text = "SB"
                Else
                    textBox1.Text = Val(textBox2.Text) / Val(textBox4.Text)
                End If
            ElseIf minus = True Then
                textBox1.Text = Val(textBox2.Text) - Val(textBox4.Text)
            ElseIf plus = True Then
                textBox1.Text = Val(textBox2.Text) + Val(textBox4.Text)
            ElseIf mulitiply = True Then
                textBox1.Text = Val(textBox2.Text) * Val(textBox4.Text)
            End If
            result = Val(textBox1.Text)
            textBox2.Text = ""
            textBox3.Text = ""
            textBox4.Text = ""
            divide = False
            minus = False
            plus = False
            mulitiply = False
            sec = False
            seccal = True
        End If
        divide = False
        minus = True
        plus = False
        mulitiply = False
        sec = True
        textBox3.Text = "-"
        If seccal = True Then
            textBox2.Text = result
        End If
        textBox5.Focus()
    End Sub

    Private Sub buttonmultiply_Click(sender As Object, e As RoutedEventArgs) Handles buttonmultiply.Click
        If textBox2.Text <> "" And textBox4.Text <> "" Then
            textBox1.Text = result
            If divide = True Then
                If Val(textBox4.Text) = 0 Then
                    textBox1.Text = "SB"
                Else
                    textBox1.Text = Val(textBox2.Text) / Val(textBox4.Text)
                End If
            ElseIf minus = True Then
                textBox1.Text = Val(textBox2.Text) - Val(textBox4.Text)
            ElseIf plus = True Then
                textBox1.Text = Val(textBox2.Text) + Val(textBox4.Text)
            ElseIf mulitiply = True Then
                textBox1.Text = Val(textBox2.Text) * Val(textBox4.Text)
            End If
            result = Val(textBox1.Text)
            textBox2.Text = ""
            textBox3.Text = ""
            textBox4.Text = ""
            divide = False
            minus = False
            plus = False
            mulitiply = False
            sec = False
            seccal = True
        End If
        divide = False
        minus = False
        plus = False
        mulitiply = True
        sec = True
        textBox3.Text = "*"
        If seccal = True Then
            textBox2.Text = result
        End If
        textBox5.Focus()
    End Sub

    Private Sub buttonplus_Click(sender As Object, e As RoutedEventArgs) Handles buttonplus.Click
        If textBox2.Text <> "" And textBox4.Text <> "" Then
            textBox1.Text = result
            If divide = True Then
                If Val(textBox4.Text) = 0 Then
                    textBox1.Text = "SB"
                Else
                    textBox1.Text = Val(textBox2.Text) / Val(textBox4.Text)
                End If
            ElseIf minus = True Then
                textBox1.Text = Val(textBox2.Text) - Val(textBox4.Text)
            ElseIf plus = True Then
                textBox1.Text = Val(textBox2.Text) + Val(textBox4.Text)
            ElseIf mulitiply = True Then
                textBox1.Text = Val(textBox2.Text) * Val(textBox4.Text)
            End If
            result = Val(textBox1.Text)
            textBox2.Text = ""
            textBox3.Text = ""
            textBox4.Text = ""
            divide = False
            minus = False
            plus = False
            mulitiply = False
            sec = False
            seccal = True
        End If
        divide = False
        minus = False
        mulitiply = False
        plus = True
        sec = True
        textBox3.Text = "+"
        If seccal = True Then
            textBox2.Text = result
        End If
        textBox5.Focus()
    End Sub

    Private Sub buttonpoint_Click(sender As Object, e As RoutedEventArgs) Handles buttonpoint.Click
        If sec = False Then
            textBox2.Text = textBox2.Text + "."
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + "."
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        sec = False
        seccal = False
        textBox5.Focus()
    End Sub

    Private Sub textBox5_TextChanged(sender As Object, e As TextChangedEventArgs) Handles textBox5.TextChanged
        If textBox5.Text = "1" Then
            If sec = False Then
                textBox2.Text = textBox2.Text + "1"
            ElseIf sec = True Then
                textBox4.Text = textBox4.Text + "1"
            End If
            textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
            seccal = False
            textBox5.Focus()
            textBox5.Text = ""
        ElseIf textBox5.Text = "0" Then
            If sec = False Then
                textBox2.Text = textBox2.Text + "0"
            ElseIf sec = True Then
                textBox4.Text = textBox4.Text + "0"
            End If
            textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
            seccal = False
            textBox5.Focus()
            textBox5.Text = ""
        End If
    End Sub
End Class
