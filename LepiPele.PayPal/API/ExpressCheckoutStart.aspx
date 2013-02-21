<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpressCheckoutStart.aspx.cs"
    Inherits="LepiPele.PayPal.API.ExpressCheckoutStart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <b>Before starting process be sure to update HostingPrefix address in 
        Web.Config!!</b><br />
        <br />
        Start Express Checkout Process:<br />
        <br />
        <asp:Button ID="oneTimeButton" runat="server" Text="One Time Payment" 
            Width="200px" onclick="oneTimeButton_Click" />
    </div>
    
    </form>
    <div>
        <br />
        <b>Use following credentials to pay:</b><br />
        <b>User: </b>mika_1254623432_per@mailinator.com<br />
        <b>Password:</b> 123456789
    </div>
</body>
</html>
