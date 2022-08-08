Imports System.Data.SqlClient
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enlace()

    End Sub

    Private Sub btnregistrar_Click(sender As Object, e As EventArgs) Handles btnregistrar.Click
        Dim consulta As String = "insert into GASTO values(@CODIGO, @TIPO,@FECHA,@MONTO,@RESPONSABLE)"
        comando = New SqlClient.SqlCommand(consulta, conexion)
        comando.Parameters.AddWithValue("@CODIGO", txtcodigo.Text)
        comando.Parameters.AddWithValue("@TIPO", cbotipo.Text)
        comando.Parameters.AddWithValue("@FECHA", txtfecha.Text)
        comando.Parameters.AddWithValue("@MONTO", txtmonto.Text)
        comando.Parameters.AddWithValue("@RESPONSABLE", txtresponsable.Text.ToUpper)
        comando.ExecuteNonQuery()
        MsgBox("Listo")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtcodigo.Text = ""
        cbotipo.Text = ""
        txtfecha.Text = ""
        txtmonto.Text = ""
        txtresponsable.Text = ""
        txtbuscador.Text = ""
    End Sub

    Private Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        Dim conexion As String
        conexion = "Data Source=DESKTOP-OLRRRLC;Initial Catalog=Datan;Integrated Security=True"
        Dim cn As New SqlConnection
        cn.ConnectionString = conexion

        Dim adapta As New SqlCommand("update GASTO set TIPO = '" & cbotipo.Text & "',FECHA= '" & txtfecha.Text & "',MONTO= '" & txtmonto.Text & "',RESPONSABLE='" & txtresponsable.Text & "' Where CODIGO= " & txtcodigo.Text & "", cn)
        cn.Open()
        adapta.ExecuteNonQuery()
        MsgBox("Datos Modificados")
    End Sub

    Private Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        Dim conexion As String
        conexion = "Data Source=DESKTOP-OLRRRLC;Initial Catalog=Datan;Integrated Security=True"
        Dim cn As New SqlConnection
        cn.ConnectionString = conexion

        Dim adaptador As New SqlDataAdapter("select*from GASTO where CODIGO=" & txtbuscador.Text & "", cn)
        Dim ds As New DataSet
        adaptador.Fill(ds, "datos")


        If ds.Tables("datos").Rows.Count > 0 Then
            txtcodigo.Text = ds.Tables("datos").Rows(0).Item(0).ToString
            cbotipo.Text = ds.Tables("datos").Rows(0).Item(1).ToString
            txtfecha.Text = ds.Tables("datos").Rows(0).Item(2).ToString
            txtmonto.Text = ds.Tables("datos").Rows(0).Item(3).ToString
            txtresponsable.Text = ds.Tables("datos").Rows(0).Item(4).ToString

        Else

            MsgBox("Codigo no existe")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conexion As String
        conexion = "Data Source=DESKTOP-OLRRRLC;Initial Catalog=Datan;Integrated Security=True"
        Dim cn As New SqlConnection
        cn.ConnectionString = conexion
        Dim comando As New SqlCommand("delete from GASTO where CODIGO=" & txtcodigo.Text & "", cn)
        cn.Open()
        comando.ExecuteNonQuery()
        MsgBox("Se Elimino Correctamente")
    End Sub

    Private Sub lblconexion_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class

