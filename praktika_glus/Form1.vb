Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Form1
    Public Shared conn As New SqlConnection("Data Source=KSENIA;User ID=" + loginform.TextBox2.Text + ";password=" + loginform.TextBox1.Text + ";Initial Catalog=praktika")
    Public Shared user As String

    Public Sub loaddata()
        Dim a As New SqlCommand("select_info_for_user", conn)
        a.CommandType = CommandType.StoredProcedure
        a.Parameters.AddWithValue("@user", user)
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da.SelectCommand = a
        ds.Tables.Add("res")
        conn.Open()
        a.ExecuteNonQuery()
        da.Fill(ds, "res")
        conn.Close()
        mainDGV.DataSource = ds.Tables("res")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Form2.state = 1
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        user = loginform.TextBox2.Text
        loaddata()
    End Sub

    Private Sub mainDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles mainDGV.CellClick

    End Sub

    Public Sub upd()

        Dim update As New SqlCommand("upd_pos", conn)
        update.CommandType = CommandType.StoredProcedure

        conn.Open()
        update.Parameters.AddWithValue("@id", mainDGV.SelectedCells.Item(0).Value)
        update.Parameters.AddWithValue("@new_date", Form2.DateTimePicker1.Value)
        update.Parameters.AddWithValue("@new_cost", Form2.TextBox5.Text)
        update.Parameters.AddWithValue("@new_ves", Form2.TextBox6.Text)
        Dim sen, rec As New Integer
        sen = Form2.DataGridView1.SelectedCells.Item(0).Value
        rec = Form2.DataGridView2.SelectedCells.Item(0).Value
        update.Parameters.AddWithValue("@new_rec", rec)
        update.Parameters.AddWithValue("@new_sen", sen)



        update.ExecuteNonQuery()
        conn.Close()
        loaddata()

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.Show()
        MsgBox(mainDGV.SelectedCells.Item(0).Value)
        Form2.state = 2
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim del As New SqlCommand("del_pos", conn)
        del.CommandType = CommandType.StoredProcedure
        conn.Open()
        del.Parameters.AddWithValue("@id", mainDGV.SelectedCells.Item(0).Value)
        del.ExecuteNonQuery()
        conn.Close()
        loaddata()
    End Sub
End Class
