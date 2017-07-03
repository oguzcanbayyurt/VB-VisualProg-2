Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Dim baglanti As New SqlConnection
    Dim ög, ad, bol, yil, adres, tel As String
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim komut As New SqlCommand(" select * from kayit where ogrnci_no='" & TextBox1.Text & "'", baglanti)
        Dim dr As SqlDataReader
        baglanti.Open()
        dr = komut.ExecuteReader
        If dr.HasRows Then
            Do While dr.Read
                TextBox2.Text = dr("ad_soyad")
                ComboBox1.Text = dr("bolum")
                ComboBox2.Text = dr("yil")
                RichTextBox1.Text = dr("adres")
                MaskedTextBox1.Text = dr("telefon")
            Loop
        Else : MsgBox("Kayıt bulunamadı")
        End If
        baglanti.Close()
    End Sub
    Private Sub temizle()
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        RichTextBox1.Clear()
        MaskedTextBox1.Clear()
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        baglanti.ConnectionString = "Data Source=LAB2SERVER\SQLEXPRESS;Initial Catalog=veri;Integrated Security=True;Pooling=False"
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            ög = TextBox1.Text
            ad = TextBox2.Text
            bol = ComboBox1.Text
            yil = ComboBox2.Text
            adres = RichTextBox1.Text
            tel = MaskedTextBox1.Text
            Dim komut As New SqlCommand("insert into kayit (ogrnci_no,bolum,yil,ad_soyad,adres,telefon) values ('" & ög & "','" & bol & "','" & yil & "','" & ad & "','" & adres & "','" & tel & "')", baglanti)
            baglanti.Open()
            komut.ExecuteNonQuery()
            baglanti.Close()
            MsgBox("Kayıt Başarılı")
            temizle()
        Catch ex As Exception
            MsgBox("hata")
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim komut As New SqlCommand("update kayit set ad_soyad= '" & TextBox2.Text & "' , bolum= '" & ComboBox1.Text & "', yil= '" & ComboBox2.Text & "', telefon ='" & MaskedTextBox1.Text & "', adres= '" & RichTextBox1.Text & "' where ogrnci_no='" & TextBox1.Text & "' ", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()
        MsgBox("Kayıt Güncellendi")
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        temizle()
    End Sub
End Class

