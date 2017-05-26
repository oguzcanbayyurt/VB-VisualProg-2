Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim baglanti As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=veri.accdb")
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim komut As New OleDbDataAdapter("select * from kayit", baglanti)
        Dim ds As New DataSet
        komut.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "Film Adı"
        DataGridView1.Columns(1).HeaderText = "Film Konusu"
        DataGridView1.Columns(2).HeaderText = "Film Türü"
        DataGridView1.Columns(3).HeaderText = "Yapım Yılı"
        DataGridView1.Columns(4).HeaderText = "IMDB Puanı"

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Tüm Filmler" Then
            Dim komut As New OleDbDataAdapter("select * from kayit", baglanti)
            Dim ds As New DataSet
            komut.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Else
            Dim komut As New OleDbDataAdapter("select * from kayit where tur='" & ComboBox1.Text & "'", baglanti)
            Dim ds As New DataSet
            komut.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        End If
    End Sub
End Class
