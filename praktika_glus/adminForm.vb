Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Xml
Public Class adminForm

    Private Sub xml_write()
        Dim settings As New XmlWriterSettings
        settings.Indent = True
        Dim xmlwrt As XmlWriter = XmlWriter.Create("tabels.xml", settings)
        With xmlwrt
            .WriteStartDocument()
            .WriteComment("tabels")
        End With
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim create As New SqlCommand("CREATE_USER", Form1.conn)
        create.CommandType = CommandType.StoredProcedure
        Form1.conn.Open()
        create.Parameters.AddWithValue("@login", TextBox1.Text)
        create.Parameters.AddWithValue("@pass", TextBox2.Text)
        create.ExecuteNonQuery()
        Form1.conn.Close()
    End Sub


    Public Sub load_admin()
        Dim users As New SqlCommand("sel_users", Form1.conn)
        Dim log As New SqlCommand("actions", Form1.conn)
        Dim uda As New SqlDataAdapter
        uda.SelectCommand = users
        Dim logda As New SqlDataAdapter
        logda.SelectCommand = log
        Dim logds As New DataSet
        logds.Tables.Add("a")
        Dim uds As New DataSet
        uds.Tables.Add("a")
        Form1.conn.Open()
        users.ExecuteNonQuery()
        uda.Fill(uds, "a")
        log.ExecuteNonQuery()
        logda.Fill(logds, "a")
        Form1.conn.Close()

        DataGridView1.DataSource = uds.Tables("a")
        DataGridView2.DataSource = logds.Tables("a")
    End Sub

    Public Sub load_rec_sen()
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
        DataGridView3.DataSource = s_ds.Tables("a")
        DataGridView4.DataSource = r_ds.Tables("a")
    End Sub

    Private Sub adminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_admin()
        load_rec_sen()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim add_send As New SqlCommand("ins_sen", Form1.conn)
        add_send.CommandType = CommandType.StoredProcedure
        Dim id As New Random
        Form1.conn.Open()
        add_send.Parameters.AddWithValue("@id", id.Next)
        add_send.Parameters.AddWithValue("@fio", TextBox3.Text)
        add_send.Parameters.AddWithValue("@type", ComboBox2.Text)
        add_send.Parameters.AddWithValue("@adr", TextBox4.Text)
        add_send.ExecuteNonQuery()
        Form1.conn.Close()
        load_rec_sen()
        load_admin()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim add_rec As New SqlCommand("ins_rec", Form1.conn)
        add_rec.CommandType = CommandType.StoredProcedure
        Dim id As New Random
        Form1.conn.Open()
        add_rec.Parameters.AddWithValue("@id", id.Next)
        add_rec.Parameters.AddWithValue("@fio", TextBox5.Text)
        add_rec.Parameters.AddWithValue("@type", ComboBox1.Text)
        add_rec.Parameters.AddWithValue("@adr", TextBox6.Text)
        add_rec.ExecuteNonQuery()
        Form1.conn.Close()
        load_rec_sen()
        load_admin()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim del As New SqlCommand("del_sen", Form1.conn)
        del.CommandType = CommandType.StoredProcedure
        Form1.conn.Open()
        del.Parameters.AddWithValue("@id", DataGridView3.SelectedCells.Item(0).Value
                                    )
        del.ExecuteNonQuery()
        Form1.conn.Close()
        load_rec_sen()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim del As New SqlCommand("del_rec", Form1.conn)
        del.CommandType = CommandType.StoredProcedure
        Form1.conn.Open()
        del.Parameters.AddWithValue("@id", DataGridView4.SelectedCells.Item(0).Value)
        del.ExecuteNonQuery()
        Form1.conn.Close()
        load_rec_sen()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim add_rec As New SqlCommand("upd_rec", Form1.conn)
        add_rec.CommandType = CommandType.StoredProcedure
        Dim id As New Random
        Form1.conn.Open()
        add_rec.Parameters.AddWithValue("@id", DataGridView4.SelectedCells.Item(0).Value)
        add_rec.Parameters.AddWithValue("@new_fio", TextBox5.Text)
        add_rec.Parameters.AddWithValue("@new_type", ComboBox1.Text)
        add_rec.Parameters.AddWithValue("@new_adr", TextBox6.Text)
        add_rec.ExecuteNonQuery()
        Form1.conn.Close()
        load_rec_sen()
        load_admin()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim add_send As New SqlCommand("upd_sen", Form1.conn)
        add_send.CommandType = CommandType.StoredProcedure
        Dim id As New Random
        Form1.conn.Open()
        add_send.Parameters.AddWithValue("@id", DataGridView3.SelectedCells.Item(0).Value)
        add_send.Parameters.AddWithValue("@new_fio", TextBox3.Text)
        add_send.Parameters.AddWithValue("@new_type", ComboBox2.Text)
        add_send.Parameters.AddWithValue("@new_adr", TextBox4.Text)
        add_send.ExecuteNonQuery()
        Form1.conn.Close()
        load_rec_sen()
        load_admin()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim del As New SqlCommand("drop_user", Form1.conn)
        del.CommandType = CommandType.StoredProcedure
        Form1.conn.Open()
        del.Parameters.AddWithValue("@name", DataGridView1.SelectedCells.Item(0).Value.ToString)
        del.ExecuteNonQuery()
        Form1.conn.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        repForm.Show()
    End Sub
End Class