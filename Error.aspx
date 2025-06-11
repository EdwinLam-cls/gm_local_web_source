<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Error.aspx.vb" Inherits="_Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>錯誤訊息</title>
	<link href="css/css.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#F7F7F7; white-space:normal">
	<form id="form1" runat="server">
	<div>
		<script type="text/javascript" language="javascript">
			alert("<%=ErrMsg%>");
			top.location.replace("<%=ErrPage%>");
		</script>
	</div>
	</form>
</body>
</html>