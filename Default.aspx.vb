'---------------------------------------------------------------------------- 
'程式功能	登入畫面
'---------------------------------------------------------------------------- 
Imports System
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Configuration


Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ''GMI Commented out, should never be a post pack.  Only access authenticated user.  Authentication handled by IIS
        'If Not IsPostBack Then
        '    ' 清除工作階段變數。 
        '    Session.Remove("mg_sid")
        '    Session.Remove("mg_name")l
        '    Session.Remove("mg_power")
        '    Session.Remove("mg_yaushing")

        '    ' 取得隨機產生四碼的驗證數字，並存入工作階段變數 confirm 中。 
        '    Session("confirm") = getConfirmCode()

        '    'tb_pass.TextMode = TextBoxMode.SingleLine
        '    'tb_pass.Text = "clsg@2010"
        '    'tb_id.Text = "steve"
        '    'tb_confirm.Text = Session("confirm")

        'End If
        lblDomain.Text = ": " & ApplicationConfig.Instance().adminsGroup

        ''GMI added, copied and modified from btnOk handler
        'If User.Identity.IsAuthenticated Then
        Dim cfc As New Common_Func()
        Dim sfc As New String_Func()
        Dim mg_id As String = "", mg_pass As String = "", confirm As String = "", mErr As String = "", tmpstr As String = ""
        Dim tmparray As String()
        Dim strsplit As String() = New String() {vbTab & vbLf}
        ' 分隔分辦用字串 
        mg_id = UserIdentity.CreateFromCurrentUser().AccountName
'mg_id = "G1595ST"
        tmpstr = cfc.Check_ID(mg_id, "", Request.ServerVariables("REMOTE_ADDR"))

        If sfc.Left(tmpstr, 1) = "*" Then
            mErr = tmpstr.Substring(1)
        Else
            tmparray = tmpstr.Split(strsplit, StringSplitOptions.None)

            Session("mg_sid") = tmparray(0)
            Session("mg_name") = tmparray(1)
            Session("mg_power") = tmparray(2)
        End If

        If mErr = "" Then
            ' 重新導向至主畫面 
            Response.Redirect("Main.html")
        Else
            ' 利用 javascript 顯示錯誤訊息 
            lt_show.Text = "<script language=javascript>alert(""" & mErr & """);</script>"
            Dim strMeta As String
            strMeta = "<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF8"" />" '先把meta設定寫在變數strMeta中
            lt_show.Text = strMeta & lt_show.Text
        End If
        'End If


    End Sub

	Public Function getConfirmCode() As String
		Dim rnd As Random = New Random()
		Dim cnt As Integer = 0
		Dim confirm As String = ""

		' 隨機產生四碼的驗證數字 
		For cnt = 0 To 3
			confirm &= rnd.Next(10).ToString()
		Next

		Return confirm
	End Function

	Protected Sub bn_new_confirm_Click(ByVal sender As Object, ByVal e As EventArgs)
		Session("confirm") = getConfirmCode()

		' 使用 Opera 瀏覽器時，要呼叫此 javascript 更新方式，才會更新驗證圖檔的顯示 
		lt_show.Text = "<script language=javascript>renew_img();</script>"
	End Sub

	



End Class
