Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim sayac1 As Integer
    Dim sayac2 As Integer
    Dim sayac3 As Integer
    Dim sayac4 As Integer
    Dim sayac5 As Integer
    Dim sayac6 As Integer
    Dim sayac7 As Integer
    Dim sayac8 As Integer
    Dim sayac9 As Integer
    Dim baglanti As New OleDbConnection("provider= Microsoft.ace.oledb.12.0; Data source= veri.accdb")

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        baglanti.Open()
        Dim komut As New OleDbDataAdapter("select * from kayit", baglanti)
        Dim ds As New DataSet
        komut.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        baglanti.Close()
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "Ad Soyad"
        DataGridView1.Columns(1).HeaderText = "Seans"
        DataGridView1.Columns(2).HeaderText = "Koltuk No"

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then

        Else
            sayac1 += 1
            If sayac1 Mod 2 = 1 Then
                Button1.BackColor = Color.Blue
            Else
                Button1.BackColor = Color.Transparent
            End If
            End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Then

        Else
            sayac2 += 1
            If sayac2 Mod 2 = 1 Then
                Button2.BackColor = Color.Blue
            Else
                Button2.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If ComboBox1.Text = "" Then

        Else
            sayac3 += 1
            If sayac3 Mod 2 = 1 Then
                Button3.BackColor = Color.Blue
            Else
                Button3.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
            baglanti.Open()
        Dim komut As New OleDbCommand(" select * from bilet where seans='" + ComboBox1.Text + "'", baglanti)
        Dim dr As OleDbDataReader
            dr = komut.ExecuteReader
            If dr.HasRows Then
                Do While dr.Read
                    If dr("koltuk1").ToString() = "Evet" Then
                        Button1.Enabled = False
                    Button1.BackColor = Color.Red
                    Else
                        Button1.Enabled = True
                    Button1.BackColor = Color.Transparent
                    End If
                    If dr("koltuk2").ToString() = "Evet" Then
                        Button2.Enabled = False
                        Button2.BackColor = Color.Red
                    Else
                        Button2.Enabled = True
                        Button2.BackColor = Color.Transparent
                End If
                If dr("koltuk3").ToString() = "Evet" Then
                    Button3.Enabled = False
                    Button3.BackColor = Color.Red
                Else
                    Button3.Enabled = True
                    Button3.BackColor = Color.Transparent
                End If
                If dr("koltuk4").ToString() = "Evet" Then
                    Button4.Enabled = False
                    Button4.BackColor = Color.Red
                Else
                    Button4.Enabled = True
                    Button4.BackColor = Color.Transparent
                End If
                If dr("koltuk5").ToString() = "Evet" Then
                    Button5.Enabled = False
                    Button5.BackColor = Color.Red
                Else
                    Button5.Enabled = True
                    Button5.BackColor = Color.Transparent
                End If
                If dr("koltuk6").ToString() = "Evet" Then
                    Button6.Enabled = False
                    Button6.BackColor = Color.Red
                Else
                    Button6.Enabled = True
                    Button6.BackColor = Color.Transparent
                End If
                If dr("koltuk7").ToString() = "Evet" Then
                    Button7.Enabled = False
                    Button7.BackColor = Color.Red
                Else
                    Button7.Enabled = True
                    Button7.BackColor = Color.Transparent
                End If
                If dr("koltuk8").ToString() = "Evet" Then
                    Button8.Enabled = False
                    Button8.BackColor = Color.Red
                Else
                    Button8.Enabled = True
                    Button8.BackColor = Color.Transparent
                End If
                If dr("koltuk9").ToString() = "Evet" Then
                    Button9.Enabled = False
                    Button9.BackColor = Color.Red
                Else
                    Button9.Enabled = True
                    Button9.BackColor = Color.Transparent
                End If
                Loop

        End If
        baglanti.Close()


    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If ComboBox1.Text = "" Then

        Else
            sayac4 += 1
            If sayac4 Mod 2 = 1 Then
                Button4.BackColor = Color.Blue
            Else
                Button4.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If ComboBox1.Text = "" Then

        Else
            sayac5 += 1
            If sayac5 Mod 2 = 1 Then
                Button5.BackColor = Color.Blue
            Else
                Button5.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If ComboBox1.Text = "" Then

        Else
            sayac6 += 1
            If sayac6 Mod 2 = 1 Then
                Button6.BackColor = Color.Blue
            Else
                Button6.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        If ComboBox1.Text = "" Then

        Else
            sayac7 += 1
            If sayac7 Mod 2 = 1 Then
                Button7.BackColor = Color.Blue
            Else
                Button7.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        If ComboBox1.Text = "" Then

        Else
            sayac8 += 1
            If sayac8 Mod 2 = 1 Then
                Button8.BackColor = Color.Blue
            Else
                Button8.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        If ComboBox1.Text = "" Then

        Else

            sayac9 += 1
            If sayac9 Mod 2 = 1 Then
                Button9.BackColor = Color.Blue
            Else
                Button9.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        If Button1.BackColor = Color.Red And Button2.BackColor = Color.Red And Button3.BackColor = Color.Red And Button4.BackColor = Color.Red And Button5.BackColor = Color.Red And Button6.BackColor = Color.Red And Button7.BackColor = Color.Red And Button8.BackColor = Color.Red And Button9.BackColor = Color.Red Then
            MsgBox("Tüm Koltuklar Dolu")
        Else
            If TextBox1.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Lütfen Bilgileri Giriniz")
            Else
                If Button1.BackColor = Color.Blue Or Button2.BackColor = Color.Blue Or Button3.BackColor = Color.Blue Or Button4.BackColor = Color.Blue Or Button5.BackColor = Color.Blue Or Button6.BackColor = Color.Blue Or Button7.BackColor = Color.Blue Or Button8.BackColor = Color.Blue Or Button9.BackColor = Color.Blue Then
                    Dim secilenkoltuk As String = ""
                    If Button1.BackColor = Color.Blue Then
                        secilenkoltuk += "1,"
                        baglanti.Open()
                        Dim koltuk1guncelle As New OleDbCommand("update bilet set koltuk1='Evet' where seans='" + ComboBox1.Text + "'", baglanti)
                        koltuk1guncelle.ExecuteNonQuery()
                        baglanti.Close()
                    End If
                    If Button2.BackColor = Color.Blue Then
                        secilenkoltuk += "2,"
                        baglanti.Open()
                        Dim koltuk2guncelle As New OleDbCommand("update bilet set koltuk2='Evet' where seans='" + ComboBox1.Text + "'", baglanti)
                        koltuk2guncelle.ExecuteNonQuery()
                        baglanti.Close()
                    End If
                    If Button3.BackColor = Color.Blue Then
                        secilenkoltuk += "3,"
                        baglanti.Open()
                        Dim koltuk3guncelle As New OleDbCommand("update bilet set koltuk3='Evet' where seans='" + ComboBox1.Text + "'", baglanti)
                        koltuk3guncelle.ExecuteNonQuery()
                        baglanti.Close()
                    End If
                    If Button4.BackColor = Color.Blue Then
                        secilenkoltuk += "4,"
                        baglanti.Open()
                        Dim koltuk4guncelle As New OleDbCommand("update bilet set koltuk4='Evet' where seans='" + ComboBox1.Text + "'", baglanti)
                        koltuk4guncelle.ExecuteNonQuery()
                        baglanti.Close()
                    End If
                    If Button5.BackColor = Color.Blue Then
                        secilenkoltuk += "5,"
                        baglanti.Open()
                        Dim koltuk5guncelle As New OleDbCommand("update bilet set koltuk5='Evet' where seans='" + ComboBox1.Text + "'", baglanti)
                        koltuk5guncelle.ExecuteNonQuery()
                        baglanti.Close()
                    End If
                    If Button6.BackColor = Color.Blue Then
                        secilenkoltuk += "6,"
                        baglanti.Open()
                        Dim koltuk6guncelle As New OleDbCommand("update bilet set koltuk6='Evet' where seans='" + ComboBox1.Text + "'", baglanti)
                        koltuk6guncelle.ExecuteNonQuery()
                        baglanti.Close()
                    End If
                    If Button7.BackColor = Color.Blue Then
                        secilenkoltuk += "7,"
                        baglanti.Open()
                        Dim koltuk7guncelle As New OleDbCommand("update bilet set koltuk7='Evet' where seans='" + ComboBox1.Text + "'", baglanti)
                        koltuk7guncelle.ExecuteNonQuery()
                        baglanti.Close()
                    End If
                    If Button8.BackColor = Color.Blue Then
                        secilenkoltuk += "8,"
                        baglanti.Open()
                        Dim koltuk8guncelle As New OleDbCommand("update bilet set koltuk8='Evet' where seans='" + ComboBox1.Text + "'", baglanti)
                        koltuk8guncelle.ExecuteNonQuery()
                        baglanti.Close()
                    End If
                    If Button9.BackColor = Color.Blue Then
                        secilenkoltuk += "9"
                        baglanti.Open()
                        Dim koltuk9guncelle As New OleDbCommand("update bilet set koltuk9='Evet' where seans='" + ComboBox1.Text + "'", baglanti)
                        koltuk9guncelle.ExecuteNonQuery()
                        baglanti.Close()
                    End If
                    baglanti.Open()
                    Dim komut As New OleDbCommand("insert into kayit(ad_soyad,seans,koltuk) values('" + TextBox1.Text + "','" + ComboBox1.Text + "','" + secilenkoltuk + "')", baglanti)
                    komut.ExecuteNonQuery()
                    baglanti.Close()
                    baglanti.Open()
                    Dim komut2 As New OleDbDataAdapter("select * from kayit", baglanti)
                    Dim ds As New DataSet
                    komut2.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    baglanti.Close()
                    baglanti.Open()
                    Dim komut3 As New OleDbCommand(" select * from bilet where seans='" + ComboBox1.Text + "'", baglanti)
                    Dim dr As OleDbDataReader
                    dr = komut3.ExecuteReader
                    If dr.HasRows Then
                        Do While dr.Read
                            If dr("koltuk1").ToString() = "Evet" Then
                                Button1.Enabled = False
                                Button1.BackColor = Color.Red
                            Else
                                Button1.Enabled = True
                                Button1.BackColor = Color.Transparent
                            End If
                            If dr("koltuk2").ToString() = "Evet" Then
                                Button2.Enabled = False
                                Button2.BackColor = Color.Red
                            Else
                                Button2.Enabled = True
                                Button2.BackColor = Color.Transparent
                            End If
                            If dr("koltuk3").ToString() = "Evet" Then
                                Button3.Enabled = False
                                Button3.BackColor = Color.Red
                            Else
                                Button3.Enabled = True
                                Button3.BackColor = Color.Transparent
                            End If
                            If dr("koltuk4").ToString() = "Evet" Then
                                Button4.Enabled = False
                                Button4.BackColor = Color.Red
                            Else
                                Button4.Enabled = True
                                Button4.BackColor = Color.Transparent
                            End If
                            If dr("koltuk5").ToString() = "Evet" Then
                                Button5.Enabled = False
                                Button5.BackColor = Color.Red
                            Else
                                Button5.Enabled = True
                                Button5.BackColor = Color.Transparent
                            End If
                            If dr("koltuk6").ToString() = "Evet" Then
                                Button6.Enabled = False
                                Button6.BackColor = Color.Red
                            Else
                                Button6.Enabled = True
                                Button6.BackColor = Color.Transparent
                            End If
                            If dr("koltuk7").ToString() = "Evet" Then
                                Button7.Enabled = False
                                Button7.BackColor = Color.Red
                            Else
                                Button7.Enabled = True
                                Button7.BackColor = Color.Transparent
                            End If
                            If dr("koltuk8").ToString() = "Evet" Then
                                Button8.Enabled = False
                                Button8.BackColor = Color.Red
                            Else
                                Button8.Enabled = True
                                Button8.BackColor = Color.Transparent
                            End If
                            If dr("koltuk9").ToString() = "Evet" Then
                                Button9.Enabled = False
                                Button9.BackColor = Color.Red
                            Else
                                Button9.Enabled = True
                                Button9.BackColor = Color.Transparent
                            End If
                        Loop

                    End If
                    baglanti.Close()
                Else

                    MsgBox("Koltuk Seçiniz")
                End If
            End If
        End If
        
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        Dim komut As New OleDbDataAdapter("select * from kayit where ad_soyad like '%" & TextBox2.Text & "%'  ", baglanti)
        Dim ds As New DataSet
        komut.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "Ad Soyad"
        DataGridView1.Columns(1).HeaderText = "Seans"
        DataGridView1.Columns(2).HeaderText = "Koltuk No"
    End Sub

    Private Sub SilToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SilToolStripMenuItem.Click
        Dim ad_soyad As String = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("ad_soyad").Value
        Dim komut As New OleDbCommand("delete from kayit where ad_soyad= '" & ad_soyad & "' ", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        Dim komut2 As New OleDbDataAdapter("select * from kayit", baglanti)
        Dim ds As New DataSet
        komut2.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        baglanti.Close()
    End Sub
End Class
