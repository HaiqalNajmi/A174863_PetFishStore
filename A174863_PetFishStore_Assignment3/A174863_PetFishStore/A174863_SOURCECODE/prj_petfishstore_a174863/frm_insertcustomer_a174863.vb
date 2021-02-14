﻿Public Class frm_insertcustomer_a174863
    Private Sub frm_insertcustomer_a174863_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refresh_grid()

    End Sub
    Private Sub refresh_grid()
        Dim mysql As String = "SELECT * FROM TBL_CUSTOMER_A174863"
        Dim mydatatable As New DataTable
        Dim myreader As New OleDb.OleDbDataAdapter(mysql, myconnection)
        myreader.Fill(mydatatable)
        grd_customer.DataSource = mydatatable
    End Sub
    Private Sub clear_fields()
        txt_customerid.Text = ""
        txt_customername.Text = ""
        txt_phonenum.Text = ""

    End Sub

    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        Dim mysql As String = "INSERT INTO TBL_CUSTOMER_A174863 VALUES ('" & txt_customerid.Text & "', '" & txt_customername.Text & "', '" & txt_phonenum.Text & "')"
        Dim mywriter As New OleDb.OleDbCommand(mysql, myconnection2)

        Try
            mywriter.Connection.Open()
            mywriter.ExecuteNonQuery()
            mywriter.Connection.Close()

            refresh_grid()
            clear_fields()

        Catch ex As Exception
            Beep()
            MsgBox(“There is a mistake in the data you entered, as shown below” & vbCrLf & vbCrLf & ex.Message)
            mywriter.Connection.Close()
        End Try
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        frm_mainmenu_a174863.Show()
        Me.Hide()

    End Sub
End Class