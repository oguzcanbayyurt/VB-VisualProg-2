Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim baglanti As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=veri.accdb")

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        GroupBox1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim komut As New OleDbCommand("Select * from kullanici where kullaniciAdi='" + TextBox1.Text + "' and sifre='" + TextBox2.Text + "'", baglanti)
        Dim dr As OleDbDataReader
        baglanti.Open()
        dr = komut.ExecuteReader
        If dr.HasRows Then
            MsgBox("Giriş Başarılı")

        Else
            GroupBox1.Visible = True
        End If
        baglanti.Close()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim harfler(7) As String
        harfler(0) = "ı"
        harfler(1) = "İ"
        harfler(3) = "ö"
        harfler(4) = "ü"
        harfler(5) = "ş"
        harfler(6) = "ğ"
        Dim durum As Boolean
        durum = True
        Dim kullaniciAd As String
        kullaniciAd = Strings.LCase(TextBox4.Text.ToCharArray)
        Dim a, b As Integer
        For a = 0 To kullaniciAd.Length - 1
            For b = 0 To harfler.Length - 1
                If kullaniciAd(a) = harfler(b) Then
                    durum = False
                End If

            Next
        Next
        If durum = False Then

            MsgBox("Kullanıcı Adında Türkçe Karakter Kullanılamaz")
        ElseIf TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
        MsgBox("bütün alanarı doldurunuz")

        Else
        If TextBox6.Text = TextBox5.Text Then
            Dim komut As New OleDbCommand("insert into kullanici (kullaniciAdi,sifre,adSoyad,e_posta) values( '" & TextBox4.Text & "', '" & TextBox5.Text & "','" & TextBox3.Text & "','" & TextBox7.Text & "')", baglanti)
            baglanti.Open()
            komut.ExecuteNonQuery()
            baglanti.Close()
            MsgBox(" Kayıt Başarılı")
        Else
            MsgBox("Şifreler Uyuşmuyor")


        End If
        End If
    End Sub
End Class
