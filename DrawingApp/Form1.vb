Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Public Property w As Integer
    Public Property h As Integer
    Dim type As String
    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
            m_Previous = e.Location
            pictureBox1_MouseMove(sender, e)
        End Sub
        Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
            If m_Previous IsNot Nothing Then
            Dim d As Object

            d = New Line(PictureBox1.Image, m_Previous, e.Location)
            d.Pen = New Pen(c, w)
            d.xspeed = xspeedtb.Value
            If type = "line" Then
                    d = New Line(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
                d.xspeed = xspeedtb.Value
            End If
                If type = "rectangle" Then
                    d = New myrect(PictureBox1.Image, m_Previous, e.Location)
                    d.Pen = New Pen(c, w)
                End If
                If type = "arc" Then
                    d = New arc(PictureBox1.Image, m_Previous, e.Location)
                    d.Pen = New Pen(c, w)
                End If
                If type = "solid" Then
                    d = New solidrect(PictureBox1.Image, m_Previous, e.Location)
                    d.Pen = New Pen(c, w)
                End If
                If type = "pie" Then
                    d = New pie(PictureBox1.Image, m_Previous, e.Location)
                    d.Pen = New Pen(c, w)
                End If
            If type = "polyg" Then
                d = New poly(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If type = "circ" Then
                d = New circle(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If type = "n-gon" Then
                d = New ngon(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
                d.sides = TrackBar2.Value
                d.radius = TrackBar3.Value
            End If
            If type = "Picture" Then
                d = New PBox(PictureBox1.Image, m_Previous, e.Location)
                d.w = TrackBar2.Value
                d.h = TrackBar3.Value

                d.picture = PictureBox2.Image
            End If
            m_shapes.Add(d)
                PictureBox1.Invalidate()
                m_Previous = e.Location
            End If
        End Sub
        Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
            m_Previous = Nothing
        End Sub
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
            If PictureBox1.Image Is Nothing Then
                Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                Using g As Graphics = Graphics.FromImage(bmp)
                    g.Clear(Color.White)
                End Using
                PictureBox1.Image = bmp
            End If
        End Sub
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw()
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            ColorDialog1.ShowDialog()
            c = ColorDialog1.Color
            Button1.BackColor = c

        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            c = sender.backcolor
        End Sub

        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
            c = sender.backcolor
        End Sub

        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End Sub

        Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
            c = sender.backcolor
        End Sub

        Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
            c = sender.backcolor
        End Sub

        Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
            c = sender.backcolor
        End Sub

        Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
            c = sender.backcolor
        End Sub

        Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
            c = sender.backcolor
        End Sub

        Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
            c = sender.backcolor
        End Sub

        Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
            w = TrackBar1.Value
        End Sub

        Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
            SaveFileDialog1.ShowDialog()
            PictureBox1.Image.Save(SaveFileDialog1.FileName)
        End Sub

        Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
            type = "arc"
        End Sub

        Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
            type = "pie"
        End Sub

        Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
            type = "rectangle"
        End Sub

        Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
            type = "solid"
        End Sub

        Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
            type = "line"
        End Sub

        Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
            type = "polyg"
        End Sub

        Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
            h = TrackBar2.Value
        End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        type = "circ"
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        type = "n-gon"
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        w = TrackBar3.Value
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        type = "Picture"
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox2.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        OpenFileDialog1.ShowDialog()
    End Sub
End Class