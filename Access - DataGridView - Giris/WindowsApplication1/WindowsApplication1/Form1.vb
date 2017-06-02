Imports System.Data
Imports System.Data.OleDb
Imports System.Media
Public Class Form1
    Dim baglanti As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=veri.accdb")
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Tüm alanları doldurunuz")
        Else
            Dim komut As New OleDbCommand("select * from giris where kullanici_adi='" & TextBox1.Text & "' and sifre='" & TextBox2.Text & "'", baglanti)
            Dim dr As OleDbDataReader
            baglanti.Open()
            dr = komut.ExecuteReader
            If dr.HasRows Then
                Me.Hide()
                Form2.Show()
            Else
                MsgBox("Bilgiler Yanlış")
            End If
            baglanti.Close()
        End If
    End Sub
End Class
