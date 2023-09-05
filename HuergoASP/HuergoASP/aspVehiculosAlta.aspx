<%@ Page Language="C#" MasterPageFile="~/Huergo.Master" AutoEventWireup="true" CodeBehind="aspVehiculosAlta.aspx.cs" Inherits="HuergoASP.aspVehiculosAlta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenidoDeMisPaginas" runat="server">
    <p>
    ID:<asp:TextBox ID="txId" runat="server" ReadOnly="True"></asp:TextBox>
    <br />TIPO:<asp:TextBox ID="txTipo" runat="server"></asp:TextBox>
    <br />MODELO:<asp:TextBox ID="txModelo" runat="server"></asp:TextBox>
    <br />PRECIO VENTA:<asp:TextBox ID="txPrecioVenta" runat="server"></asp:TextBox>
    <br />
    STOCK:<asp:TextBox ID="txStock" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btGuardar" runat="server" OnClick="btGuardar_Click1" Text="Guardar" />
    <asp:Button ID="btVolver" runat="server" OnClick="btVolver_Click" Text="Volver" />
</p>
<p>
    <asp:Label ID="lbInfo" runat="server" Text="."></asp:Label>
</p>
</asp:Content>
