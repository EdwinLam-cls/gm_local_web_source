'---------------------------------------------------------------------------- 
'程式功能 錯誤訊息 
'---------------------------------------------------------------------------- 

Partial Class _Error
	Inherits System.Web.UI.Page
	Public ErrMsg As String
	Public ErrPage As String

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Request("ErrCode") Is Nothing Then
            ErrMsg = "Uncertain Error!"
			ErrPage = "Default.aspx"
		Else
			Select Case Request("ErrCode").ToString()
				Case "1"
                    ErrMsg = "No User Right!"
					ErrPage = "Main.html"
					Exit Select
				Case "2"
                    ErrMsg = "Session Timeout!"
					ErrPage = "Default.aspx"
					Exit Select
				Case Else
                    ErrMsg = "Session Timeout!"
					ErrPage = "Default.aspx"
					Exit Select
			End Select
		End If
	End Sub
End Class