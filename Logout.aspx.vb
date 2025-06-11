'---------------------------------------------------------------------------- 
'程式功能	系統登出
'---------------------------------------------------------------------------- 
Imports System
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data

Partial Public Class Logout
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		If Session("mg_sid") IsNot Nothing Then
			Dim SqlString As String = ""

			' 儲存登出紀錄
			SqlString = "Insert Into Mg_Log (mg_sid, fi_no2, lg_time, lg_ip) Values"
            SqlString &= " (@mg_sid, '0003', @getdate, @lg_ip)"

			Using Sql_conn As New SqlConnection(DBConnUtil.GetConnectionString().ConnectionString)
				Sql_conn.Open()
				Dim Sql_command As New SqlCommand(SqlString, Sql_conn)

				Sql_command.Parameters.AddWithValue("@mg_sid", Session("mg_sid").ToString())
                Sql_command.Parameters.AddWithValue("@lg_ip", Request.ServerVariables("REMOTE_ADDR"))
                Sql_command.Parameters.Add("@getdate", SqlDbType.DateTime)
                Sql_command.Parameters("@getdate").Value = TimeZoneInfo.ConvertTime(Now, TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings("TimeZoneID")))


				Sql_command.ExecuteNonQuery()

				Sql_command.Dispose()
				Sql_conn.Close()
			End Using
		End If

		' 清除所有的工作階段(Session)狀態。
		Session.Clear()
		Session.Abandon()
	End Sub
End Class

