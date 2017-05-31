Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Dim baglanti As New OleDbConnection("provider= Microsoft.ace.oledb.12.0; Data source= veri.accdb")

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim komut As New OleDbCommand("select * from kayit where plaka= '" & TextBox1.Text & "'", baglanti)
        Dim dr As OleDbDataReader
        baglanti.Open()
        dr = komut.ExecuteReader
        If dr.HasRows Then
            MsgBox("Bu kullanıcı adı sisteme kayıtlı")
            baglanti.Close()
        Else
            baglanti.Close()

            baglanti.Open()
            komut.CommandText = " insert into kayit(marka,model,plaka,renk) values ('" & ComboBox2.Text & "','" & ComboBox1.Text & "','" & TextBox1.Text & "','" & ComboBox3.Text & "') "
            komut.ExecuteNonQuery()
            MsgBox("Kayıt Başarılı")
            baglanti.Close()
            listele()
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        listele()
    End Sub
    Private Sub listele()
        Dim komut As New OleDbDataAdapter("select * from kayit", baglanti)
        Dim ds As New DataSet
        komut.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        baglanti.Close()
        DataGridView1.Columns(0).HeaderText = "PLAKA"
        DataGridView1.Columns(1).HeaderText = "YIL"
        DataGridView1.Columns(2).HeaderText = "MARKA"
        DataGridView1.Columns(3).HeaderText = "RENK"
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        Dim komut As New OleDbDataAdapter("select * from kayit where plaka like '%" & TextBox2.Text & "%'  ", baglanti)
        Dim ds As New DataSet
        komut.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "PLAKA"
        DataGridView1.Columns(1).HeaderText = "YIL"
        DataGridView1.Columns(2).HeaderText = "MARKA"
        DataGridView1.Columns(3).HeaderText = "RENK"
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim komut As New OleDbCommand("update kayit set model='" & ComboBox1.Text & "', marka='" & ComboBox2.Text & "', renk='" & ComboBox3.Text & "' where plaka= '" & TextBox1.Text & "' ", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()
        listele()
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As System.EventArgs) Handles DataGridView1.DoubleClick
        ComboBox1.Text = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("model").Value
        ComboBox2.Text = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("marka").Value
        TextBox1.Text = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("plaka").Value
        ComboBox3.Text = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("renk").Value
    End Sub

    Private Sub SilToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SilToolStripMenuItem.Click
        Dim plaka As String = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("plaka").Value
        Dim komut As New OleDbCommand("delete from kayit where plaka= '" & plaka & "' ", baglanti)
        baglanti.Open()
        komut.ExecuteNonQuery()
        baglanti.Close()
        listele()
    End Sub
End Class
