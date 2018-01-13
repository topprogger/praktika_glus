Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.cr
Public Class repForm
    Dim conn As New SqlConnection("Data Source=KSENIA;User ID=sa;password=123")
    Private Sub repForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim da As New SqlDataAdapter("select * from posylki", conn)
        Dim ds As New DataSet
        ds.Tables.Add("a")
        conn.Open()
        da.Fill(ds, "a")
        conn.Close()
    End Sub
    Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.posylkiTableAdapter.FillBy(Me.posDataSet.posylki)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FillByToolStripButton_Click_1(sender As Object, e As EventArgs)
        Try
            Me.posylkiTableAdapter.FillBy(Me.posDataSet.posylki)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FillByToolStripButton1_Click(sender As Object, e As EventArgs)
        Try
            Me.posylkiTableAdapter.FillBy(Me.posDataSet.posylki)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class