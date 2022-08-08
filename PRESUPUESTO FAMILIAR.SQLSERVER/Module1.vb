Imports System.Data.SqlClient
Imports System.Data.Sql

Module Module1
    Public conexion As New SqlConnection
    Public comando As New SqlCommand
    Public estado As String

    Sub enlace()
        Try
            conexion.ConnectionString = "Data Source=DESKTOP-OLRRRLC;Initial Catalog=Datan;Integrated Security=True"
            conexion.Open()
            estado = "conectado"
        Catch ex As Exception
            estado = "desconectado"
        End Try
    End Sub

End Module
