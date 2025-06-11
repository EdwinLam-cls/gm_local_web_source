<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Welcome.aspx.vb" Inherits="Welcome" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<link href="css/css.css" rel="stylesheet" type="text/css" />
<title>歡迎使用</title>
    <style type="text/css">
        #Select1
        {
            width: 135px;
        }
        .style1
        {
            width: 90pt;
        }
    </style>
</head>
<body class="text12pt">
	<form id="form1" runat="server">
	<div>
		<center>
		<br />
            
           
		<br />General Mills<br /><font color="black">
		    <br />
		<center>
	    <table cellspacing="0" cellpadding="4" rules="all" border="1" style="background-color:White;border-color:#003366;border-width:1px;border-style:Double;width:98%;border-collapse:collapse;">
		<tr align="left" style="background-color:#99FF99;height:18pt">
			<td align="left" title="「本公司訊息」最多100個字" class="style1">本公司訊息</td>
			<td style="background-color:#F7F7DE" colspan="3">
				<asp:TextBox ID="tb_company_message" runat="server" Height="50px" 
                    TextMode="MultiLine" Width="98%" Enabled="False" ReadOnly="True"></asp:TextBox>
			</td>
    	</tr>
			
		<tr align="left" style="background-color:#99FF99;height:18pt">
			<td align="left" title="「競爭者訊息」最多100個字" class="style1">競爭者訊息</td>
			<td style="background-color:#F7F7DE" colspan="3">
				<asp:TextBox ID="tb_competitor_message" runat="server" Height="50px" 
                    TextMode="MultiLine" Width="98%" Enabled="False" ReadOnly="True"></asp:TextBox>
			</td>
    	</tr>

		<tr align="left" style="background-color:#99FF99;height:18pt">
			<td align="left" title="「其他訊息」最多100個字" class="style1">其他訊息</td>
			<td style="background-color:#F7F7DE" colspan="3">
				<asp:TextBox ID="tb_other_message" runat="server" Height="50px" 
                    TextMode="MultiLine" Width="98%" Enabled="False" ReadOnly="True"></asp:TextBox>
			</td>
    	</tr>

		<tr align="left" style="background-color:#99FF99;height:18pt">
			<td align="left" title="「客戶從？日沒有訂貨」最多1個字" class="style1">客戶從？日沒有訂貨</td>
			<td style="background-color:#F7F7DE" colspan="3">
				<asp:TextBox ID="tb_count_date" runat="server" Width="50px" Enabled="False" 
                    ReadOnly="True"></asp:TextBox>
			</td>
    	</tr>


	</table>
	    </ center>
		<br />登入日期  :<%=Now%></font>
		<br /><br />
		<br />使用者姓名:<font color="#0000ff"><b><%=Session("mg_name")%></b></font>
		<br />
		<br />使用者  IP:<%=Request.ServerVariables("REMOTE_ADDR")%>
		</center>
	</div>
	<asp:Literal ID="lt_show" runat="server"></asp:Literal>
    <asp:Label ID="lb_page" runat="server" Text="" Visible="false"></asp:Label>
	</form>
</body>
</html>