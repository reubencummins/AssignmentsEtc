<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Response.aspx.cs" Inherits="WebAssignment1.Response" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet1.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblResponse" runat="server" />
    </div>
    <div>
        <asp:Button Text="Go Back" ID="btnBack" runat="server" OnClick="btnBack_Click" />
    </div>
    </form>
</body>
</html>
