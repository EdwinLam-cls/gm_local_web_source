<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TestWS.aspx.vb" Inherits="TestWS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="tbVanNumber" runat="server" ToolTip="Van Number">281</asp:TextBox>
        <asp:TextBox ID="m_txtEnv" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:DropDownList ID="ddlForm" runat="server">
            <asp:ListItem>t_GeneralMills/down_business_unit</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_customer_group_master</asp:ListItem>
            <asp:ListItem Selected="True">t_GeneralMills/down_customer_master</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_customer_material_info</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_district_master</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_item_balance</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_item_group_master</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_item_master</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_message_master</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_price_list</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_reason_master</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_uom_convert</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_user</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_van_message</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_gm_route</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_rush_order_header</asp:ListItem>
            <asp:ListItem>t_GeneralMills/down_rush_order_detail</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:TextBox ID="tbAction" runat="server" ToolTip="Action">Download File</asp:TextBox>
        <br />
        <asp:TextBox ID="tbTimeZone" runat="server" ToolTip="Action">China Standard Time</asp:TextBox>
        <asp:TextBox ID="m_txtDBConn" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Button ID="btnTest" runat="server" Text="Test" />
    
    </div>
    <asp:TextBox ID="tbResult" runat="server" EnableViewState="False" Rows="50" 
        TextMode="MultiLine" Width="100%"></asp:TextBox>
    </form>
</body>
</html>
