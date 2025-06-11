Imports System.Data.SqlClient

Partial Class checksite
    Inherits System.Web.UI.Page
    Const C_WEBSITE_IS_OK As String = "WEBSITE IS OK<br>"
    Const C_DB_CONN_OK As String = "DB CONNECTION OK<br>"
    Const C_DB_CONN_FAIL As String = "!!UNABLE TO CONNECT TO DB!!<br>"
    Const C_SQL_EXCEPTION_NUM As String = "SQL EXCEPTION NUMBER {0}<br>"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim detail As String
        detail = Me.Request.Params("detail")
        If Not detail Is Nothing Then
            Try
                Dim sqlConn As SqlConnection = DBConnUtil.GetSQLConn()
                sqlConn.Open()
                sqlConn.Close()
                Response.Write(C_DB_CONN_OK)
                Response.Write(C_WEBSITE_IS_OK)
            Catch se As SqlException
                Response.Write(C_DB_CONN_FAIL)
                Response.Write(String.Format(C_SQL_EXCEPTION_NUM, se.Number))
                Response.Write(se.ToString())

            Catch ex As Exception
                Response.Write(C_DB_CONN_FAIL)
                Response.Write(ex.ToString())

            End Try

        Else
            Response.Write(C_WEBSITE_IS_OK)
        End If
    End Sub
End Class
