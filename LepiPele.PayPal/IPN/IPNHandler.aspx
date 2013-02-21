<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IPNHandler.aspx.cs" Inherits="LepiPele.PayPal.IPN.IPNHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Upload this page to webserver and submit IPN POSTs to this page using IPN 
        Simulator:<br />
        <a href="https://developer.paypal.com/us/cgi-bin/devscr?cmd=_ipn-link-session">
        https://developer.paypal.com/us/cgi-bin/devscr?cmd=_ipn-link-session</a><br />
        <br />
        Then check Messages folder for txt files that contain IPNs received by Handler</div>
    </form>
</body>
</html>
