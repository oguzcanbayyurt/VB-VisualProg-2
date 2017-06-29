Public Class Form1
    Dim koltuk1, koltuk2, koltuk3, koltuk4, koltuk5, koltuk6 As Integer
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        koltuk1 = koltuk1 + 1
        If koltuk1 Mod 2 = 1 And ComboBox1.Text = "KADIN" Then
            Button1.BackColor = Color.Red
            Button1.ForeColor = Color.White
        ElseIf koltuk1 Mod 2 = 1 And ComboBox1.Text = "ERKEK" Then
            Button1.BackColor = Color.Blue
            Button1.ForeColor = Color.White

        Else
            Button1.BackColor = Color.Transparent
            Button1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        koltuk2 = koltuk2 + 1
        If koltuk2 Mod 2 = 1 And ComboBox1.Text = "KADIN" Then
            Button2.BackColor = Color.Red
            Button2.ForeColor = Color.White
        ElseIf koltuk1 Mod 2 = 1 And ComboBox1.Text = "ERKEK" Then
            Button2.BackColor = Color.Blue
            Button2.ForeColor = Color.White
        Else
            Button2.BackColor = Color.Transparent
            Button2.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        koltuk3 = koltuk3 + 1
        If koltuk3 Mod 2 = 1 And ComboBox1.Text = "KADIN" Then
            Button3.BackColor = Color.Red
            Button3.ForeColor = Color.White
        ElseIf koltuk1 Mod 2 = 1 And ComboBox1.Text = "ERKEK" Then
            Button3.BackColor = Color.Blue
            Button3.ForeColor = Color.White
        Else
            Button3.BackColor = Color.Transparent
            Button3.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        koltuk4 = koltuk4 + 1
        If koltuk4 Mod 2 = 1 And ComboBox1.Text = "KADIN" Then
            Button4.BackColor = Color.Red
            Button4.ForeColor = Color.White
        ElseIf koltuk1 Mod 2 = 1 And ComboBox1.Text = "ERKEK" Then
            Button4.BackColor = Color.Blue
            Button4.ForeColor = Color.White
        Else
            Button4.BackColor = Color.Transparent
            Button4.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        koltuk5 = koltuk5 + 1
        If koltuk5 Mod 2 = 1 And ComboBox1.Text = "KADIN" Then
            Button5.BackColor = Color.Red
            Button5.ForeColor = Color.White
        ElseIf koltuk1 Mod 2 = 1 And ComboBox1.Text = "ERKEK" Then
            Button5.BackColor = Color.Blue
            Button5.ForeColor = Color.White
        Else
            Button5.BackColor = Color.Transparent
            Button5.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        koltuk6 = koltuk6 + 1
        If koltuk6 Mod 2 = 1 And ComboBox1.Text = "KADIN" Then
            Button6.BackColor = Color.Red
            Button6.ForeColor = Color.White
        ElseIf koltuk1 Mod 2 = 1 And ComboBox1.Text = "ERKEK" Then
            Button6.BackColor = Color.Blue
            Button6.ForeColor = Color.White
        Else
            Button6.BackColor = Color.Transparent
            Button6.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "ERKEK" Or ComboBox1.Text = "KADIN" Then
            GroupBox1.Enabled = True
        Else
            GroupBox1.Enabled = False

        End If
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Dim butonlar(6) As Button
        butonlar(1) = Button1
        butonlar(2) = Button2
        butonlar(3) = Button3
        butonlar(4) = Button4
        butonlar(5) = Button5
        butonlar(6) = Button6
        For i = 1 To 6
            If butonlar(i).BackColor = Color.Red Or butonlar(i).BackColor = Color.Blue Then
                butonlar(i).Enabled = False
                butonlar(i).Text = "DOLU"
            End If
        Next
    End Sub
End Class
