<%@ Page Language="C#" MasterPageFile="~/Huergo.Master" AutoEventWireup="true" CodeBehind="aspVendedoresAlta.aspx.cs" Inherits="HuergoASP.aspVendedoresAlta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenidoDeMisPaginas" runat="server">


    <p>
    ID:<asp:TextBox ID="txId" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    NOMBRE:<asp:TextBox ID="txNombre" runat="server"></asp:TextBox>
    <br />
    APELLIDO:<asp:TextBox ID="txApellido" runat="server"></asp:TextBox>
    <br />
    SUCURSAL:<asp:TextBox ID="txSucursal" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btGuardar" runat="server" OnClick="btGuardar_Click" Text="Guardar" />
    <asp:Button ID="btVolver" runat="server" OnClick="btVolver_Click" Text="Volver" />
</p>
<p>
    <asp:Label ID="lbInfo" runat="server" Text="."></asp:Label>
</p>


</asp:Content>