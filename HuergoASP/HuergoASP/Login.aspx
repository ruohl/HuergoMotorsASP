<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Login.aspx.cs" Inherits="HuergoASP.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        USUARIO: <asp:TextBox ID="txUser" runat="server"></asp:TextBox>
        <br />

        PASSWORD:
        <asp:TextBox ID="txPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btLogin" runat="server" OnClick="btLogin_Click" Text="Iniciar Sesión" />
        <br />
        <asp:Label ID="lbMsg" runat="server" Text="."></asp:Label>
    </form>
</body>
</html>
