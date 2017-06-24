Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim koltuklar(9) As Button
    Dim baglanti As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=veri.accdb")
    Private Sub temizle()
        TextBox1.Text = ""
        ComboBox1.Text = ""
        Label4.Text = ""
    End Sub
    Private Sub Listele()
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
        Label4.Text = Button1.Text
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Label4.Text = Button2.Text
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Label4.Text = Button3.Text
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Label4.Text = Button4.Text
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Label4.Text = Button5.Text
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Label4.Text = Button6.Text
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Label4.Text = Button7.Text
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Label4.Text = Button8.Text
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Label4.Text = Button9.Text
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        GroupBox1.Visible = True
        For i = 1 To 9
            koltuklar(i).BackColor = Color.Black
            koltuklar(i).Enabled = True
        Next
        Dim komut As New OleDbCommand("select * from kayit where seans='" & ComboBox1.Text & "'", baglanti)
        Dim dr As OleDbDataReader
        baglanti.Open()
        dr = komut.ExecuteReader
        If dr.HasRows Then
            Do While dr.Read
                For i = 1 To 9
                    If dr("koltuk") = koltuklar(i).Text Then
                        koltuklar(i).BackColor = Color.Red
                        koltuklar(i).Enabled = False
                    End If
                Next
            Loop
        End If
        baglanti.Close()
        temizle()
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        If TextBox1.Text = "" Or ComboBox1.Text = "" Or Label4.Text = "" Then
            MsgBox("Tüm Bilgileri Giriniz")
        Else
            Dim komut As New OleDbCommand("insert into kayit(ad_soyad,seans,koltuk) values('" & TextBox1.Text & "','" & ComboBox1.Text & "','" & Label4.Text & "')", baglanti)
            baglanti.Open()
            komut.ExecuteNonQuery()
            baglanti.Close()
            MsgBox(Label5.Text & " koltuk numaralı bilet alındı")
            koltuklar(Label5.Text).BackColor = Color.Red
            koltuklar(Label5.Text).Enabled = False
            Listele()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        Dim komut As New OleDbDataAdapter("select * from kayit where ad_soyad like '%" & TextBox2.Text & "%'", baglanti)
        Dim ds As New DataSet
        komut.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "Ad Soyad"
        DataGridView1.Columns(1).HeaderText = "Seans"
        DataGridView1.Columns(2).HeaderText = "Koltuk No"
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Listele()
        koltuklar(1) = Button1
        koltuklar(2) = Button2
        koltuklar(3) = Button3
        koltuklar(4) = Button4
        koltuklar(5) = Button5
        koltuklar(6) = Button6
        koltuklar(7) = Button7
        koltuklar(8) = Button8
        koltuklar(9) = Button9
    End Sub

    Private Sub SilToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SilToolStripMenuItem.Click
        Dim seans As String = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("seans").Value
        Dim koltuk As String = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("koltuk").Value
        Dim komut As New OleDbCommand("delete from kayit where seans='" & seans & "' and koltuk='" & koltuk & "'", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        Dim komut2 As New OleDbDataAdapter("select * from kayit", baglanti)
        Dim ds As New DataSet
        komut2.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        baglanti.Close()
    End Sub
End Class
