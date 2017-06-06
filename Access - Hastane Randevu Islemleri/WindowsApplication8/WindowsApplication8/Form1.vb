Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim baglanti As New OleDbConnection("Provider= Microsoft.Ace.Oledb.12.0; Data Source=veri.accdb")

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        GroupBox1.Visible = True
        Button3.Visible = True
        Button4.Visible = True
        Button5.Visible = True
        Button6.Visible = True
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or MaskedTextBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
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
                komut.CommandText = ("insert into kayit (tc,ad_soyad,dogum_tarihi,dogum_yeri,yasadigi_yer) values( '" & TextBox1.Text & "', '" & TextBox2.Text & "','" & MaskedTextBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')")
                baglanti.Open()
                komut.ExecuteNonQuery()
                baglanti.Close()
                MsgBox(" KAYIT BAŞARILI")
            End If
        End If
        LinkLabel1.Visible = True
        Button1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim komut As New OleDbCommand("select * from kayit where tc= '" & TextBox1.Text & "'", baglanti)
        Dim dr As OleDbDataReader
        baglanti.Open()
        dr = komut.ExecuteReader
        If dr.HasRows Then
            Do While dr.Read
                TextBox2.Text = dr("ad_soyad")
                MaskedTextBox1.Text = dr("dogum_tarihi")
                TextBox3.Text = dr("dogum_yeri")
                TextBox4.Text = dr("yasadigi_yer")
                LinkLabel1.Visible = True
            Loop
        Else
            MsgBox("KAYDINIZ BULUNAMADI")
            LinkLabel1.Visible = True
            Button2.Visible = True
        End If
        baglanti.Close()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("TÜM ALANLARI DOLDURUN")
        Else
            Dim komut As New OleDbCommand("select * from randevu where tc= '" & TextBox1.Text & "'", baglanti)
            Dim dr As OleDbDataReader
            baglanti.Open()
            dr = komut.ExecuteReader
            If dr.HasRows Then
                MsgBox("RANDEVUNUZ ZATEN VAR")
                baglanti.Close()
            Else
                baglanti.Close()
                komut.CommandText = ("insert into randevu (tc,poliklinik,doktor,saat) values( '" & TextBox1.Text & "', '" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "')")
                baglanti.Open()
                komut.ExecuteNonQuery()
                baglanti.Close()
                ComboBox3.Items.Remove(ComboBox3.Text)
                MsgBox("RANDEVUNUZ KAYDEDİLDİ")
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim komut As New OleDbCommand("select * from randevu where tc= '" & TextBox1.Text & "'", baglanti)
        Dim dr As OleDbDataReader
        baglanti.Open()
        dr = komut.ExecuteReader
        If dr.HasRows Then
            Do While dr.Read
                ComboBox1.Text = dr("poliklinik")
                ComboBox2.Text = dr("doktor")
                ComboBox3.Text = dr("saat")
            Loop
        Else
            MsgBox("RANDEVUNUZ BULUNAMADI")
        End If
        baglanti.Close()
    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim komut As New OleDbCommand("update randevu set poliklinik='" & ComboBox1.Text & "', doktor='" & ComboBox2.Text & "', saat='" & ComboBox3.Text & "' where tc= '" & TextBox1.Text & "' ", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()
        MsgBox("KAYDINIZ GUNCELLENDI")
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim komut As New OleDbCommand(" delete from randevu where tc= '" & TextBox1.Text & "'", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()
        MsgBox("KAYIT SILINDI")
        temizle2()
    End Sub
    Private Sub temizle1()
        TextBox1.Text = ""
        TextBox2.Text = ""
        MaskedTextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub
    Private Sub temizle2()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        temizle1()
        Button2.Visible = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "DAHİLİYE" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Özgür Şengül")
            ComboBox2.Items.Add("Selman Karadere")
        ElseIf ComboBox1.Text = "GÖZ" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Oğuzcan Bayyurt")
        End If
    End Sub
End Class
