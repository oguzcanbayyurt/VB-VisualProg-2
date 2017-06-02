Imports System.Data
Imports System.Data.OleDb
Public Class Form2
    Dim baglanti As New OleDbConnection("provider= Microsoft.ace.oledb.12.0; Data source= veri.accdb")
    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        listele()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim cinsiyet, eposta As String
        Dim dogum_t, kayit_t As Date
        dogum_t = DateTimePicker2.Text
        kayit_t = DateTimePicker1.Text
        eposta = TextBox3.Text & "@" & TextBox4.Text
        If RadioButton1.Checked = True Then
            cinsiyet = "Erkek"
        Else
            cinsiyet = "Kadın"
        End If
        Dim komut As New OleDbCommand("insert into kayit(tc,adi,baba_adi,bolum,program,e_posta,tel,adres,kayit_tarihi,dogum_tarihi,cinsiyet) values('" & MaskedTextBox1.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & eposta & "','" & MaskedTextBox2.Text & "','" & RichTextBox1.Text & "','" & kayit_t & "','" & dogum_t & "','" & cinsiyet & "')", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()

        listele()
        'temizle()
    End Sub
    Private Sub listele()
        Dim komut As New OleDbDataAdapter("select * from kayit", baglanti)
        Dim ds As New DataSet
        komut.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "TC"
        DataGridView1.Columns(1).HeaderText = "AD-SOYAD"
        DataGridView1.Columns(2).HeaderText = "BABA ADI"
        DataGridView1.Columns(3).HeaderText = "BÖLÜM"
        DataGridView1.Columns(4).HeaderText = "PROGRAM"
        DataGridView1.Columns(5).HeaderText = "e-POSTA"
        DataGridView1.Columns(6).HeaderText = "TELEFON"
        DataGridView1.Columns(7).HeaderText = "ADRES"
        DataGridView1.Columns(8).HeaderText = "KAYIT TARİHİ"
        DataGridView1.Columns(9).HeaderText = "DOĞUM TARİHİ"
        DataGridView1.Columns(10).HeaderText = "CİNSİYET"
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        Dim komut As New OleDbDataAdapter("select * from kayit where tc like '%" & TextBox5.Text & "%'", baglanti)
        Dim ds As New DataSet
        komut.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "TC"
        DataGridView1.Columns(1).HeaderText = "AD-SOYAD"
        DataGridView1.Columns(2).HeaderText = "BABA ADI"
        DataGridView1.Columns(3).HeaderText = "BÖLÜM"
        DataGridView1.Columns(4).HeaderText = "PROGRAM"
        DataGridView1.Columns(5).HeaderText = "e-POSTA"
        DataGridView1.Columns(6).HeaderText = "TELEFON"
        DataGridView1.Columns(7).HeaderText = "ADRES"
        DataGridView1.Columns(8).HeaderText = "KAYIT TARİHİ"
        DataGridView1.Columns(9).HeaderText = "DOĞUM TARİHİ"
        DataGridView1.Columns(10).HeaderText = "CİNSİYET"
    End Sub

    Private Sub SilToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SilToolStripMenuItem.Click
        Dim tc As String = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("tc").Value
        Dim komut As New OleDbCommand("delete from kayit where tc= '" & tc & "'", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()
        MsgBox("Kayıt Silindi")
        listele()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "Tüm Bölümler" Then
            Dim komut As New OleDbDataAdapter("select * from kayit", baglanti)
            Dim ds As New DataSet
            komut.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Else
            Dim komut As New OleDbDataAdapter("select * from kayit where bolum like '%" & ComboBox3.Text & "%'", baglanti)
            Dim ds As New DataSet
            komut.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        End If
        
    End Sub
End Class