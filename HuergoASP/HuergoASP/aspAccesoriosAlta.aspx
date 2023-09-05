<%@ Page Language="C#" MasterPageFile="~/Huergo.Master" AutoEventWireup="true" CodeBehind="aspAccesoriosAlta.aspx.cs" Inherits="HuergoASP.aspAccesoriosAlta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenidoDeMisPaginas" runat="server">
    <p>
    ID:<asp:TextBox ID="txId" runat="server" ReadOnly="True"></asp:TextBox>
        <br />NOMBRE:<asp:TextBox ID="txNombre" runat="server"></asp:TextBox>
        <br />MODELO:<asp:TextBox ID="txModelo" runat="server"></asp:TextBox>
        <br />PRECIO:<asp:TextBox ID="txPrecio" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btGuardar" runat="server" OnClick="btGuardar_Click" Text="Guardar" />
        <asp:Button ID="btVolver" runat="server" OnClick="btVolver_Click" Text="Volver" />
    </p>
    <p>
        <asp:Label ID="lbInfo" runat="server" Text="."></asp:Label>
    </p>
</asp:Content>
