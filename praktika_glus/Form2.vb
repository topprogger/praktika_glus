Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Form2
    Public Shared state As Integer
    Private Sub new_pos()

        Dim ins_send As New SqlCommand()

        Dim send As Random = New Random
        Dim res As Random = New Random
        Dim pos As Random = New Random

        ins_send.CommandType = CommandType.StoredProcedure
        ins_send.CommandText = "ins_pos"
        ins_send.Connection = Form1.conn
        Dim id As New Random

        Form1.conn.Open()
        ins_send.Parameters.AddWithValue("@id", id.Next)


        ins_send.Parameters.AddWithValue("@date", DateTimePicker1.Value)
        ins_send.Parameters.AddWithValue("@cost", TextBox5.Text)
        ins_send.Parameters.AddWithValue("@ves", Val(TextBox6.Text))
        Dim sen, rec As New Integer
        sen = DataGridView1.SelectedCells.Item(0).Value
        rec = DataGridView2.SelectedCells.Item(0).Value
        ins_send.Parameters.AddWithValue("@rec",rec)
        ins_send.Parameters.AddWithValue("@sen", sen)


        ins_send.Parameters.AddWithValue("@user", Form1.user)


        If (TextBox5.Text <> "" And TextBox6.Text <> "" And DateTimePicker1.Value.ToString <> "") Then
            ins_send.ExecuteNonQuery()
            MsgBox(DataGridView2.SelectedRows.Item(0).ToString + "" + DataGridView1.SelectedRows.Item(0).ToString)
            Form1.conn.Close()
            Hide()
            Form1.loaddata()
        Else MsgBox("заполните все поля")
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If state = 1 Then
            new_pos()
            Form1.loaddata()
        End If
        If state = 2 Then
            Form1.upd()
            Form1.loaddata()
        End If
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub
    Public Sub load_f2()
        Dim load_s As New SqlCommand("sel_sen", Form1.conn)
        load_s.CommandType = CommandType.StoredProcedure
        Dim load_r As New SqlCommand("sel_rec", Form1.conn)
        load_r.CommandType = CommandType.StoredProcedure

        Dim r_da As New SqlDataAdapter(load_r.CommandText, Form1.conn)
        Dim s_da As New SqlDataAdapter(load_s.CommandText, Form1.conn)

        Dim r_ds As New DataSet
        Dim s_ds As New DataSet

        Form1.conn.Open()
        load_r.ExecuteNonQuery()
        load_s.ExecuteNonQuery()
        r_da.Fill(r_ds, "a")
        s_da.Fill(s_ds, "a")
        Form1.conn.Close()
        DataGridView1.DataSource = s_ds.Tables("a")
        DataGridView2.DataSource = r_ds.Tables("a")
    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_f2()
    End Sub
End Class