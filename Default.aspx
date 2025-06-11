<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" Debug="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="text9pt" style="background-image: url('images/logo_back.png');
            background-repeat: repeat-x">
            <tr><td><img src="images/logo2.png" border="0" alt="標題" /></td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <center>
            <p style="font-size: 18pt; margin: 15pt 0pt 5pt 0pt">
                <b>If you have access, you will be redirected to the Application<asp:Label 
                    ID="lblDomain" runat="server"></asp:Label>
                </b></p>
            <span style="text-align:centre">Version: 3.0.3 (At 2012-07-03 13:09) 
            </span></center>
        
        <script language="javascript" type="text/javascript">
            function renew_img() {
                var img, now;
                now = new Date();
                img = document.getElementById("img_confirm");
                img.src = "confirm.ashx?ti=" + now.getSeconds().toString() + now.getMilliseconds().toString();
            }
        </script>
        <asp:Literal ID="lt_show" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>