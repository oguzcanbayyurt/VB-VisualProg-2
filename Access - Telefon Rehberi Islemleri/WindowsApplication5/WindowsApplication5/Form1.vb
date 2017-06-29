Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim baglanti As New OleDbConnection("Provider= Microsoft.Ace.Oledb.12.0; Data source=veri.accdb")

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim komut As New OleDbCommand("select * from kayit where ad_soyad= '" & TextBox1.Text & "'", baglanti)
        Dim dr As OleDbDataReader
        baglanti.Open()
        dr = komut.ExecuteReader
        If dr.HasRows Then
            Do While dr.Read
                MaskedTextBox1.Text = dr("tel")
                ComboBox1.Text = dr("grup")
                Button4.Visible = True
                MaskedTextBox1.Enabled = False
                Button6.Visible = True
            Loop
        Else
            MsgBox(" Kayıt bulunamadı")
        End If
        baglanti.Close()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim komut As New OleDbCommand("select * from kayit where tel= '" & MaskedTextBox1.Text & "'", baglanti)
        Dim dr As OleDbDataReader
        baglanti.Open()
        dr = komut.ExecuteReader
        If dr.HasRows Then
            Do While dr.Read
                TextBox1.Text = dr("ad_soyad")
                ComboBox1.Text = dr("grup")
                Button4.Visible = True
                MaskedTextBox1.Enabled = False
                Button6.Visible = True
            Loop
        Else
            MsgBox("Kayıtlı kişi bulunamadı")
        End If
        baglanti.Close()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        temizle()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim komut As New OleDbCommand("update kayit set ad_soyad='" & TextBox1.Text & "', grup='" & ComboBox1.Text & "' where tel='" & MaskedTextBox1.Text & "'", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()
        MsgBox("Güncelleme Başarılı")

    End Sub
    Private Sub temizle()
        TextBox1.Clear()
        MaskedTextBox1.Clear()
        ComboBox1.Text = ""
        Button4.Visible = False
        MaskedTextBox1.Enabled = True
        Button6.Visible = False
    End Sub
  

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim komut As New OleDbCommand("delete from kayit  where tel='" & MaskedTextBox1.Text & "'", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()
        MsgBox("Silme İşlemi Başarılı")
        temizle()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or MaskedTextBox1.Text = "(   )    -" Then
            MsgBox(" Boş alanları doldurunuz")
        Else
            Dim komut As New OleDbCommand(" select * from kayit where tel= '" & MaskedTextBox1.Text & "'", baglanti)
            Dim dr As OleDbDataReader
            baglanti.Open()
            dr = komut.ExecuteReader
            If dr.HasRows Then
                MsgBox("Bu numara kayıtlı")
                baglanti.Close()
            Else
                baglanti.Close()
                komut.CommandText = "insert into kayit(ad_soyad,tel,grup) values( '" & TextBox1.Text & "','" & MaskedTextBox1.Text & "','" & ComboBox1.Text & "')"
                baglanti.Open()
                komut.ExecuteNonQuery()
                baglanti.Close()
                MsgBox("Kayıt başarılı")
            End If
        End If
    End Sub
End Class
