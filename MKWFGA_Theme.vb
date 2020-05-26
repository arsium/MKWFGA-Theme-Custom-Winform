Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class MKWFGA_Theme
    Inherits Form
    'original from : https://www.youtube.com/watch?v=VQbbSdzGMss
    'Adapted and modified by Arsium based on link above

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        Me.FormBorderStyle = bn
        Me.Controls.Add(Container_)
        Me.Controls.Add(Container_2)
        Me.Controls.Add(Container_3)


    End Sub


    Private bn As FormBorderStyle = FormBorderStyle.None

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Always)>
    Public Overloads Property FormBorderStyle() As FormBorderStyle
        Get
            Return bn
        End Get
        Set(ByVal value As FormBorderStyle)
            bn = value
        End Set
    End Property
    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        FindForm.FormBorderStyle = FormBorderStyle.None
        ' Dock = DockStyle.Fill

        Container_.FlatStyle = FlatStyle.Flat
        Container_.Size = New Size(32, 32)


        Container_.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204)

        ' Container_.FlatAppearance =
        Container_.Text = "X"
        Container_.BackColor = Color.FromArgb(30, 30, 30)

        Container_2.FlatStyle = FlatStyle.Flat
        Container_2.Size = New Size(32, 32)


        Container_2.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204)

        ' Container_.FlatAppearance =
        Container_2.Text = "+"
        Container_2.BackColor = Color.FromArgb(30, 30, 30)





        Container_3.FlatStyle = FlatStyle.Flat
        Container_3.Size = New Size(32, 32)


        Container_3.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204)

        ' Container_.FlatAppearance =
        Container_3.Text = "-"
        Container_3.BackColor = Color.FromArgb(30, 30, 30)

    End Sub

    Private WithEvents Container_ As New Button
    Private WithEvents Container_2 As New Button
    Private WithEvents Container_3 As New Button

    Protected Sub ClickBtnClose(sender As Object, e As EventArgs) Handles Container_.Click
        Application.Exit()
    End Sub
    Protected Sub ClickBtnMaximized(sender As Object, e As EventArgs) Handles Container_2.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Protected Sub ClickBtnMinimized(sender As Object, e As EventArgs) Handles Container_3.Click
        Me.WindowState = FormWindowState.Normal
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)


        Container_.Location = New Point(Me.Width - 34, 2)

        Container_.FlatAppearance.BorderSize = 1
        Container_.ForeColor = Color.White





        Container_2.Location = New Point(Me.Width - 68, 2)

        Container_2.FlatAppearance.BorderSize = 1
        Container_2.ForeColor = Color.White




        Container_3.Location = New Point(Me.Width - 102, 2)

        Container_3.FlatAppearance.BorderSize = 1
        Container_3.ForeColor = Color.White
        '  Container_.Location = New Point(20, 20)

        '  Container_.Name = "ContainerSir"
        '  Container_.BackColor = Color.White
        ' Container_.TabIndex = 4500

        'Container_.Size = New Size(Me.Width - 14, Me.Height - 36)
        ' Container_.Location = (New Point(7, 29))


        Dim MyBitmap As New Bitmap(Width, Height)

        Dim g As Graphics = Graphics.FromImage(MyBitmap)

        g.Clear(Color.FromArgb(30, 30, 30))




        g.DrawRectangle(New Pen(Color.FromArgb(0, 122, 204), 1), New Rectangle(0, 0, Width - 1, Height - 1))


        g.DrawLine(New Pen(Color.FromArgb(0, 122, 204), 1), 0, 36, Width, 36)


        g.FillRectangle(New SolidBrush(Color.FromArgb(0, 122, 204)), New Rectangle(3, 3, 3, 31))

        g.FillRectangle(New SolidBrush(Color.FromArgb(0, 122, 204)), New Rectangle(8, 3, 3, 31))


        g.DrawString(Me.Text, New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular), New SolidBrush(Color.FromArgb(0, 122, 204)), Me.Width / 2 - TextRenderer.MeasureText(Me.Text, New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular)).Width / 2, 36 / 2 - TextRenderer.MeasureText(Me.Text, New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular)).Height / 2)



        Dim x2 As Single = (Width / 2) + (Width / 3) + (Width / 3) - (Width / 4) + (Width / 20)


        If BTLine Then
            g.DrawLine(New Pen(Color.FromArgb(0, 122, 204), 1), Width - x2, Me.Height - 15, x2, Me.Height - 15)
        End If





        Dim DesktopIntPtr As IntPtr = GetDC(IntPtr.Zero)

        Dim azg As Graphics = Graphics.FromHdc(DesktopIntPtr)

        ' azg.FillRectangle(New SolidBrush(Color.FromArgb(0, 122, 204)), New Rectangle(8, 3, 3, 31))

        azg.Dispose()
        ReleaseDC(DesktopIntPtr)




        '  Task.Run(Sub() Ref())
        If ShowCloseBTN Then
            Container_.Show()

        Else
            Container_.Hide()
        End If

        If ShowMaximizeBTN Then
            Container_2.Show()

        Else
            Container_2.Hide()
        End If

        If ShowMinimizeBTN Then

            Container_3.Show()
        Else
            Container_3.Hide()
        End If

        e.Graphics.DrawImage(MyBitmap, 0, 0) : MyBitmap.Dispose() : g.Dispose()


        '   SHChangeNotify(&H8000000, &H0, Nothing, Nothing)
        ' Me.Controls.Add(Container_)
        MyBase.OnPaint(e)


    End Sub



    <DllImport("User32.dll")>
    Public Shared Function GetDC(ByVal hwnd As IntPtr) As IntPtr

    End Function
    <DllImport("User32.dll")>
    Public Shared Sub ReleaseDC(ByVal dc As IntPtr)

    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)

        Me.Refresh()
        MyBase.OnTextChanged(e)
    End Sub




    Private CloseBTN As Boolean = True
    Public Property ShowCloseBTN As Boolean
        Get
            Return CloseBTN
            Me.Refresh()
        End Get
        Set(ByVal value As Boolean)
            CloseBTN = value
            Me.Refresh()
        End Set
    End Property
    Private MaximizeBTN As Boolean = True
    Public Property ShowMaximizeBTN As Boolean
        Get
            Return MaximizeBTN
            Me.Refresh()
        End Get
        Set(ByVal value As Boolean)
            MaximizeBTN = value
            Me.Refresh()
        End Set
    End Property
    Private MinimizeBTN As Boolean = True
    Public Property ShowMinimizeBTN As Boolean
        Get
            Return MinimizeBTN
            Me.Refresh()
        End Get
        Set(ByVal value As Boolean)
            MinimizeBTN = value
            Me.Refresh()
        End Set
    End Property




    Private BTLine As Boolean = True
    Public Property BottomLine As Boolean
        Get
            Return BTLine
            Me.Refresh()
        End Get
        Set(ByVal value As Boolean)
            BTLine = value
            Me.Refresh()
        End Set
    End Property

























    ''Native API adpated from  : https://github.com/RiyadPathan/DragControl/blob/master/DragControl.vb
    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal a As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim p As Point = Me.PointToClient(Me.MousePosition)

        'SHChangeNotify(&H8000000, &H0, Nothing, Nothing)
        If p.Y < 36 Then


            ReleaseCapture()

            SendMessage(Me.FindForm().Handle, 161, 2, 0)


        End If


        MyBase.OnMouseDown(e)
    End Sub



    Const WM_NCHITTEST As Integer = &H84


    Const HTBOTTOMRIGHT As Integer = 17

    Const HTBOTTOM As Integer = 15

    Const HTRIGHT As Integer = 11



    Const HTBOTTOMLEFT As Integer = 16

    'Const HTTOPRIGHT As Integer = 14

    Const HTLEFT As Integer = 10


    'https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest 
    'https://social.msdn.microsoft.com/Forums/vstudio/en-US/0262637f-2448-4da2-a40c-b3232ba798bc/float-a-borderless-form-on-desktop?forum=vbgeneral
    'Second link modified By Arsium reading doc in first link
    Protected Overrides Sub WndProc(ByRef m As Message)

        Select Case m.Msg

            Case WM_NCHITTEST

                Dim loc As New Point(m.LParam.ToInt32 And &HFFFF, m.LParam.ToInt32 >> 16)
                loc = PointToClient(loc)


                Dim blnRight As Boolean = (loc.X > Width - 9)


                Dim blnBottom As Boolean = (loc.Y > Height - 9)

                Dim blnHTLEFT As Boolean = (loc.X < Width - (Width - 9))


                If blnRight And blnBottom Then

                    m.Result = CType(HTBOTTOMRIGHT, IntPtr)
                    Return


                ElseIf blnHTLEFT And blnBottom Then

                    m.Result = CType(HTBOTTOMLEFT, IntPtr)
                    Return

                ElseIf blnRight Then

                    m.Result = CType(HTRIGHT, IntPtr)
                    Return

                ElseIf blnBottom Then

                    m.Result = CType(HTBOTTOM, IntPtr)
                    Return


                ElseIf blnHTLEFT Then

                    m.Result = CType(HTLEFT, IntPtr)
                    Return


                End If

        End Select

        MyBase.WndProc(m)

    End Sub









    Private Declare Function SHChangeNotify Lib "Shell32.dll" (ByVal wEventID As Long,
                                                               ByVal uFlags As Long,
                                                               ByVal dwitem1 As Long,
                                                               ByVal deitem2 As Long) As Long




End Class