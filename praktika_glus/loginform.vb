Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class loginform
    Public Shared curr_id As Integer
    Private Sub TextBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseClick
        TextBox2.Text = ""
    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        TextBox1.Text = ""
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "sa" And TextBox2.Text = "sa" Then
            adminForm.Show()
        Else Form1.Show()
            Form1.loaddata()
        End If
        Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        repForm.Show()
    End Sub
End Class