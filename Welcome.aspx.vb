'---------------------------------------------------------------------------- 
'程式功能	歡迎畫面
'程式名稱	/Welcome.aspx.vb
'設計人員	
'修改人員
'備註說明 
'---------------------------------------------------------------------------- 
Imports System
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Public Class Welcome
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		' 檢查使用者權限並存入登入紀錄
        Check_Power("0002", True)
        Dim SqlString As String = ""

        Using Sql_Conn As New SqlConnection(DBConnUtil.GetConnectionString().ConnectionString)
            SqlString = "Select Top 1 * "
            SqlString &= " From message_master b"

            Using Sql_Command As New SqlCommand(SqlString, Sql_Conn)
                Sql_Conn.Open()

                Using Sql_Reader As SqlDataReader = Sql_Command.ExecuteReader()
                    If Sql_Reader.Read() Then
                        tb_company_message.Text = Sql_Reader("company_message").ToString().Trim()
                        tb_competitor_message.Text = Sql_Reader("competitor_message").ToString().Trim()
                        tb_other_message.Text = Sql_Reader("other_message").ToString().Trim()
                        tb_count_date.Text = Sql_Reader("cont_date").ToString().Trim()

                    Else
                        tb_company_message.Text = ""
                        tb_competitor_message.Text = ""
                        tb_other_message.Text = ""
                        tb_count_date.Text = ""
                    End If
                End Using
            End Using
        End Using

	End Sub

	' 檢查使用者權限並存入登入紀錄
	Private Sub Check_Power(ByVal f_power As String, ByVal bl_save As Boolean)
		' 載入公用函數
		Dim cfc As New Common_Func()

		Try
			If cfc.Check_Power(Session("mg_sid").ToString(), Session("mg_name").ToString(), Session("mg_power").ToString(), f_power, Request.ServerVariables("REMOTE_ADDR"), bl_save) > 0 Then
				Response.Redirect("/Error.aspx?ErrCode=1")
			End If
		Catch
			Response.Redirect("/Error.aspx?ErrCode=2")
		End Try
	End Sub
End Class
