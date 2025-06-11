<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Status.aspx.vb" Inherits="Status" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<link href="css/css.css" rel="stylesheet" type="text/css" />
<title>Status</title>
</head>
<body style="margin:0pt 0pt 0pt 0pt; background-color:#eaeaea">
<form id="form1" runat="server">
<div>
<table width="100%" border="0" cellpadding="2" cellspacing="0" bgcolor="#eaeaea" class="text14pt">
<tr valign="middle">
	<td width="220">&nbsp;
		&nbsp;<a href="javascript:hide_menu();" id="hd_menu_btn"><img id="hd_menu_pic" src="images/t_Left.gif" alt="Close Menu" style="border-width:0pt" /></a>
		&nbsp;<a href="javascript:hide_title();" id="hd_title_btn"><img id="hd_title_pic" src="images/t_Up.gif" alt="Close Top Area" style="border-width:0pt" /></a>
	</td>
	<td>User:<%=Session("mg_name")%></td>
	<td align="right"><a href="Logout.aspx" class="abtn"><b>&nbsp;&nbsp;Logout&nbsp;&nbsp;</b></a></td>
</tr>
</table>
</div>
</form>
<script language="javascript" type="text/javascript">
	// menu 選單開關
	function hide_menu() {
		var frameobj;
		var imgobj;
		frameobj = top.document.getElementById("subframe");
		imgobj = document.getElementById("hd_menu_pic");
		if (frameobj.cols != "0,*") {
			frameobj.cols = "0,*";			
			imgobj.src = "images/t_Right.gif";
			imgobj.alt = "Open Menu";
		}
		else {
			frameobj.cols = "220pt,*";
			imgobj.src = "images/t_Left.gif";
			imgobj.alt = "Close Menu";
		}
	}

	// title 選單開關
	function hide_title() {
		var frameobj;
		frameobj = top.document.getElementById("mainframe");
		imgobj = document.getElementById("hd_title_pic");
		if (frameobj.rows != "0,32pt,*") {
			frameobj.rows = "0,32pt,*";
			imgobj.src = "images/t_Down.gif";
			imgobj.alt = "Open Top Area";
		}
		else {
			frameobj.rows = "80pt,32pt,*";
			imgobj.src = "images/t_Up.gif";
			imgobj.alt = "Close Top Area";
		}
	}
</script>
</body>
</html>
