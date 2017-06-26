Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim baglanti As New OleDbConnection("Provider= Microsoft.Ace.Oledb.12.0; Data Source=veri.accdb")

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or TextBox4.Text = "" Then
            MsgBox("TÜM ALANLARI DOLDURUN")
        Else
            Dim komut As New OleDbCommand("select * from kayit where tc= '" & TextBox1.Text & "'", baglanti)
            Dim dr As OleDbDataReader
            baglanti.Open()
            dr = komut.ExecuteReader
            If dr.HasRows Then
                MsgBox("BU KAYIT ZATEN KAYITLI")
                baglanti.Close()
            Else
                baglanti.Close()
                komut.CommandText = ("insert into kayit (tc,ad_soyad,dogum_yeri,dogum_yili,baba_adi) values( '" & TextBox1.Text & "', '" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "')")
                baglanti.Open()
                komut.ExecuteNonQuery()
                baglanti.Close()
                MsgBox(" KAYIT BAŞARILI")
                temizle()
            End If
        End If
    End Sub
    Private Sub temizle()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.Text = ""
        Button4.Visible = False
        Button5.Visible = False
        TextBox1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        temizle()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim komut As New OleDbCommand("select * from kayit where tc= '" & TextBox1.Text & "'", baglanti)
        Dim dr As OleDbDataReader
        baglanti.Open()
        dr = komut.ExecuteReader
        If dr.HasRows Then
            Do While dr.Read
                TextBox2.Text = dr("ad_soyad")
                TextBox3.Text = dr("dogum_yeri")
                ComboBox1.Text = dr("dogum_yili")
                TextBox4.Text = dr("baba_adi")
                Button4.Visible = True
                Button5.Visible = True
                TextBox1.Enabled = False
            Loop
        Else
            MsgBox("KAYDINIZ BULUNAMADI")
        End If
        baglanti.Close()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim komut As New OleDbCommand("update kayit set ad_soyad='" & TextBox2.Text & "', baba_adi='" & TextBox4.Text & "', dogum_yeri='" & TextBox3.Text & "', dogum_yili='" & ComboBox1.Text & "' where tc= '" & TextBox1.Text & "' ", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()
        MsgBox("KAYDINIZ GUNCELLENDI")
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim komut As New OleDbCommand(" delete from kayit where tc= '" & TextBox1.Text & "'", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()
        MsgBox("KAYIT SILINDI")
        temizle()
    End Sub
End Class
