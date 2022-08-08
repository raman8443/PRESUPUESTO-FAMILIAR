Imports System.Data.SqlClient

Friend Class SqlDataAdaptador
    Private v As String
    Private conexion As SqlConnection

    Public Sub New(v As String, conexion As SqlConnection)
        Me.v = v
        Me.conexion = conexion
    End Sub
End Class
