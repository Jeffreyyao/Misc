﻿#ExternalChecksum("..\..\MainWindow.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","E7C6F23D51AED240A4DB26D435534246")
'------------------------------------------------------------------------------
' <auto-generated>
'     此代码由工具生成。
'     运行时版本:4.0.30319.42000
'
'     对此文件的更改可能会导致不正确的行为，并且如果
'     重新生成代码，这些更改将会丢失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell
Imports WPF_Drawboard


'''<summary>
'''MainWindow
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class MainWindow
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\MainWindow.xaml",2)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents mainwindow As MainWindow
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",10)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents grid As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",25)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents button1 As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",27)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents canvas As System.Windows.Controls.Canvas
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",28)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents grid2 As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",35)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents sl As System.Windows.Controls.Slider
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",36)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents sli As System.Windows.Controls.Slider
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",37)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents slid As System.Windows.Controls.Slider
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\MainWindow.xaml",38)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents btn As System.Windows.Controls.Button
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/WPF Drawboard;component/mainwindow.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\MainWindow.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.mainwindow = CType(target,MainWindow)
            Return
        End If
        If (connectionId = 2) Then
            Me.grid = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 3) Then
            Me.button1 = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 4) Then
            Me.canvas = CType(target,System.Windows.Controls.Canvas)
            Return
        End If
        If (connectionId = 5) Then
            Me.grid2 = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 6) Then
            Me.sl = CType(target,System.Windows.Controls.Slider)
            Return
        End If
        If (connectionId = 7) Then
            Me.sli = CType(target,System.Windows.Controls.Slider)
            Return
        End If
        If (connectionId = 8) Then
            Me.slid = CType(target,System.Windows.Controls.Slider)
            Return
        End If
        If (connectionId = 9) Then
            Me.btn = CType(target,System.Windows.Controls.Button)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

