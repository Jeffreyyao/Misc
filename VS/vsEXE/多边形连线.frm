VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H00FFFFFF&
   Caption         =   "CircleLines"
   ClientHeight    =   6180
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   10290
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   ScaleHeight     =   6180
   ScaleWidth      =   10290
   StartUpPosition =   3  '´°¿ÚÈ±Ê¡
   Begin VB.CommandButton Command2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "color"
      Height          =   495
      Left            =   0
      Style           =   1  'Graphical
      TabIndex        =   11
      Top             =   5640
      Width           =   735
   End
   Begin VB.TextBox Text9 
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   0
      TabIndex        =   9
      Top             =   4920
      Width           =   735
   End
   Begin VB.TextBox Text8 
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   0
      TabIndex        =   8
      Top             =   4440
      Width           =   735
   End
   Begin VB.CommandButton Command1 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "random"
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   0
      MaskColor       =   &H00FFFFFF&
      Style           =   1  'Graphical
      TabIndex        =   7
      Top             =   2640
      Width           =   735
   End
   Begin VB.TextBox Text7 
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   0
      TabIndex        =   6
      Top             =   3960
      Width           =   735
   End
   Begin VB.TextBox Text6 
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   0
      TabIndex        =   5
      Top             =   3480
      Width           =   735
   End
   Begin VB.TextBox Text5 
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   0
      TabIndex        =   4
      Top             =   1920
      Width           =   735
   End
   Begin VB.TextBox Text4 
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   0
      TabIndex        =   3
      Top             =   1440
      Width           =   735
   End
   Begin VB.TextBox Text3 
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   0
      TabIndex        =   2
      Top             =   960
      Width           =   735
   End
   Begin VB.TextBox Text2 
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   0
      TabIndex        =   1
      Top             =   480
      Width           =   735
   End
   Begin VB.TextBox Text1 
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   10
      Left            =   5520
      Top             =   1920
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "Ó×Ô²"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   840
      TabIndex        =   10
      Top             =   0
      Width           =   735
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Dim xi, yi, i, j, n, m, xj, yj, a, b, c, d, e, f, g, h, k, x, y, z, abc, ab, bc, xy, yz

Private Sub Command1_Click()
Form1.Cls
Randomize
a = Int(Rnd * (9001)) + 1000
b = Int(Rnd * (9001)) + 1000
c = Int(Rnd * (9001)) + 1000
d = Int(Rnd * (9001)) + 1000
e = Int(Rnd * (9001)) + 1000
Text1 = a
Text2 = b
Text3 = c
Text4 = d
Text5 = e
End Sub

Private Sub Command2_Click()
Form1.Cls
abc = abc + 1
End Sub

Private Sub Form_Click()
Form1.Cls
Form1.BackColor = vbWhite
Label1.BackColor = vbWhite
x = 0
y = 0
z = 0
i = 0
End Sub

Private Sub Form_DblClick()
Form1.BackColor = vbBlack
Label1.BackColor = vbBlack
x = 255
y = 255
z = 255
i = 0
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
If KeyCode = vbKeyF Then
ab = ab + 1
If ab Mod 2 = 0 Then
Timer1.Interval = 10
Else
Timer1.Interval = 100
End If
End If
If KeyCode = vbKeyS Then
bc = bc + 1
If bc Mod 2 = 0 Then
Timer1.Enabled = True
Else
Timer1.Enabled = False
End If
End If
If KeyCode = vbKeyE Then
End
End If
End Sub

Private Sub Form_Resize()
Form1.Cls
End Sub

Private Sub Label1_Click()
MsgBox (i)
End Sub

Private Sub Text1_Change()
a = Val(Text1.Text)
Form1.Cls
i = 0
End Sub

Private Sub Text2_Change()
b = Val(Text2.Text)
Form1.Cls
i = 0
End Sub

Private Sub Text3_Change()
c = Val(Text3.Text)
Form1.Cls
i = 0
End Sub

Private Sub Text4_Change()
d = Val(Text4.Text)
Form1.Cls
i = 0
End Sub

Private Sub Text5_Change()
e = Val(Text5.Text)
Form1.Cls
i = 0
End Sub

Private Sub Text6_Change()
f = Val(Text6.Text)
Form1.Cls
i = 0
End Sub

Private Sub Text7_Change()
g = Val(Text7.Text)
Form1.Cls
i = 0
End Sub

Private Sub Text8_Change()
h = Val(Text8.Text)
Form1.Cls
i = 0
End Sub

Private Sub Text9_Change()
k = Val(Text9.Text)
Form1.Cls
i = 0
End Sub

Private Sub Timer1_Timer()
 xy = Form1.Height / 2
 yz = Form1.Width / 2
 i = i + 1
 xi = d * Cos(i * a) + f + yz
 yi = d * Sin(i * a) + g + xy
 xj = e * Cos(i * b + c) + h + yz
 yj = e * Sin(i * b + c) + k + xy
 If abc Mod 2 = 1 Then
 Randomize
 x = Int(Rnd * (255)) + 1
 y = Int(Rnd * (255)) + 1
 z = Int(Rnd * (255)) + 1
 Me.Line (xi, yi)-(xj, yj), RGB(x, y, z)
 Command2.BackColor = RGB(x, y, z)
 Else
 Me.Line (xi, yi)-(xj, yj), RGB(x, y, z)
 End If
 If i = 1000 Then
 Form1.Cls
 Form1.Cls
Randomize
a = Int(Rnd * (9001)) + 1000
b = Int(Rnd * (9001)) + 1000
c = Int(Rnd * (9001)) + 1000
d = Int(Rnd * (9001)) + 1000
e = Int(Rnd * (9001)) + 1000
Text1 = a
Text2 = b
Text3 = c
Text4 = d
Text5 = e
 End If
End Sub

