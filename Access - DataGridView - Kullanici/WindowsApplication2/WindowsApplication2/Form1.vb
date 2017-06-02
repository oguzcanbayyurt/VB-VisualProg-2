Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim baglanti As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=verii.accdb")
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim komut As New OleDbDataAdapter("select * from kayitt", baglanti)
        Dim ds As New DataSet
        komut.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim komut As New OleDbDataAdapter("select * from kayitt", baglanti)
        Dim ds As New DataSet
        komut.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim komut As New OleDbCommand("select * from kayitt where tc='" & TextBox1.Text & "'", baglanti)
        Dim dr As OleDbDataReader
        baglanti.Open()
        dr = komut.ExecuteReader
        If dr.HasRows Then
            MsgBox("Tc Zaten Kayıtlı")
            baglanti.Close()
        Else
            baglanti.Close()

            Dim tc, ad_soyad, telefon, adres As String
            tc = TextBox1.Text
            ad_soyad = TextBox2.Text
            telefon = MaskedTextBox1.Text
            adres = RichTextBox1.Text
            Dim komut As New OleDbCommand("insert into kayitt(tc,ad_soyad,telefon,adres) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & MaskedTextBox1.Text & "','" & RichTextBox1.Text & "')", baglanti)
            baglanti.Open()
            komut.ExecuteNonQuery()
            baglanti.Close()
            MsgBox("Kayıt Başarılı")
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        MaskedTextBox1.Text = ""
        RichTextBox1.Text = ""

    End Sub
End Class
