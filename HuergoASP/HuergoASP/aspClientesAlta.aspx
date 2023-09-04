<%@ Page Language="C#" MasterPageFile="~/Huergo.Master" AutoEventWireup="true" CodeBehind="aspClientesAlta.aspx.cs" Inherits="HuergoASP.aspClientesAlta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenidoDeMisPaginas" runat="server">

    <p>
        ID:<asp:TextBox ID="txId" runat="server"></asp:TextBox>
        <br />
        NOMBRE:<asp:TextBox ID="txNombre" runat="server"></asp:TextBox>
        <br />
        DIRECCIÓN:<asp:TextBox ID="txDireccion" runat="server"></asp:TextBox>
        <br />
        TELEFONO:<asp:TextBox ID="txTelefono" runat="server"></asp:TextBox>
        <br />
        EMAIL:<asp:TextBox ID="txEmail" runat="server"></asp:TextBox>
        <br />
        CONTRASEÑA:<asp:TextBox ID="txContraseña" runat="server"></asp:TextBox>
    </p>
    <asp:Button ID="btGuardar" runat="server" OnClick="btGuardar_Click" Text="Guardar" />
    <asp:Button ID="btVolver" runat="server" OnClick="btVolver_Click" Text="Volver" />
    <br />
    <asp:Label ID="lbInfo" runat="server" Text="."></asp:Label>

</asp:Content>