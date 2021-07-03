Class MainWindow
    Dim minus, plus, mulitiply, divide, sec, seccal As Boolean
    Dim result As Double
    Sub addNum(str As String)
        If sec = False Then
            textBox2.Text = textBox2.Text + str
        ElseIf sec = True Then
            textBox4.Text = textBox4.Text + str
        End If
        textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
        seccal = False
    End Sub
    Private Sub button00_Click() Handles button00.MouseLeftButtonDown
        addNum("00")
    End Sub
    Private Sub button0_Click() Handles button0.MouseLeftButtonDown
        addNum("0")
    End Sub
    Private Sub button1_Click() Handles button1.MouseLeftButtonDown
        addNum("1")
    End Sub
    Private Sub button2_Click() Handles button2.MouseLeftButtonDown
        addNum("2")
    End Sub
    Private Sub button3_Click() Handles button3.MouseLeftButtonDown
        addNum("3")
    End Sub
    Private Sub button4_Click() Handles button4.MouseLeftButtonDown
        addNum("4")
    End Sub
    Private Sub button5_Click() Handles button5.MouseLeftButtonDown
        addNum("5")
    End Sub
    Private Sub button6_Click() Handles button6.MouseLeftButtonDown
        addNum("6")
    End Sub
    Private Sub button7_Click() Handles button7.MouseLeftButtonDown
        addNum("7")
    End Sub
    Private Sub button8_Click() Handles button8.MouseLeftButtonDown
        addNum("8")
    End Sub
    Private Sub button9_Click() Handles button9.MouseLeftButtonDown
        addNum("9")
    End Sub
    Private Sub buttoncancel_Click() Handles buttoncancel.MouseLeftButtonDown
        textBox1.Text = ""
        textBox2.Text = ""
        textBox3.Text = ""
        textBox4.Text = ""
        divide = False
        minus = False
        plus = False
        mulitiply = False
        sec = False
    End Sub
    Private Sub buttondel_Click() Handles buttondel.MouseLeftButtonDown
        If sec = False Then
            If textBox2.Text.Length <> 0 Then
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1, 1)
                textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
            End If
        ElseIf sec = True Then
            If textBox4.Text.Length <> 0 Then
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1, 1)
                textBox1.Text = textBox2.Text + textBox3.Text + textBox4.Text
            End If
        End If
        If textBox2.Text = "" And textBox4.Text = "" Then
            textBox1.Text = ""
        End If
    End Sub
    Private Sub buttondivide_Click() Handles buttondivide.MouseLeftButtonDown
        divide = True
        minus = False
        plus = False
        mulitiply = False
        textBox3.Text = "÷"
        calc()
        If seccal = True Then
            textBox2.Text = result
        End If
    End Sub
    Sub btnplus() Handles buttonplus.MouseLeftButtonDown
        divide = False
        minus = False
        plus = True
        mulitiply = False
        textBox3.Text = "+"
        calc()
        If seccal = True Then
            textBox2.Text = result
        End If
    End Sub
    Sub btnmultiply() Handles buttonmultiply.MouseLeftButtonDown
        divide = False
        minus = False
        plus = False
        mulitiply = True
        textBox3.Text = "×"
        calc()
        If seccal = True Then
            textBox2.Text = result
        End If
    End Sub
    Sub btnminus() Handles buttonminus.MouseLeftButtonDown
        divide = False
        minus = True
        plus = False
        mulitiply = False
        textBox3.Text = "-"
        calc()
        If seccal = True Then
            textBox2.Text = result
        End If
    End Sub
    Private Sub buttonequils_Click() Handles buttonequils.MouseLeftButtonDown
        calc()
    End Sub
    Private Sub buttonpoint_Click() Handles buttonpoint.MouseLeftButtonDown
        addNum(".")
    End Sub
    Private Sub MainWindow_Loaded() Handles Me.Loaded
        sec = False
        seccal = False
    End Sub
    Private Sub MainWindow_SizeChanged() Handles Me.SizeChanged
        textBox1.FontSize = textBox1.ActualHeight * 0.65
        button0.FontSize = button0.ActualHeight / 2
        button1.FontSize = button1.ActualHeight / 2
        button2.FontSize = button2.ActualHeight / 2
        button3.FontSize = button3.ActualHeight / 2
        button4.FontSize = button4.ActualHeight / 2
        button5.FontSize = button5.ActualHeight / 2
        button6.FontSize = button6.ActualHeight / 2
        button7.FontSize = button7.ActualHeight / 2
        button8.FontSize = button8.ActualHeight / 2
        button9.FontSize = button9.ActualHeight / 2
        button00.FontSize = button00.ActualHeight / 2
        buttondel.FontSize = buttondel.ActualHeight / 2
        buttonplus.FontSize = buttonplus.ActualHeight / 2
        buttonminus.FontSize = buttonminus.ActualHeight / 2
        buttonpoint.FontSize = buttonpoint.ActualHeight / 2
        buttondivide.FontSize = buttondivide.ActualHeight / 2
        buttonequils.FontSize = buttonequils.ActualHeight / 2
        buttoncancel.FontSize = buttoncancel.ActualHeight / 2
        buttonmultiply.FontSize = buttonmultiply.ActualHeight / 2
    End Sub
    Sub calc()
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
            sec = False
            seccal = True
        End If
        sec = True
    End Sub
End Class
