<%@ Page Language="C#" MasterPageFile="~/Huergo.Master" AutoEventWireup="true" CodeBehind="aspAccesorios.aspx.cs" Inherits="HuergoASP.aspAccesorios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenidoDeMisPaginas" runat="server">
    <asp:TextBox ID="txFiltro" runat="server" Height="27px" Width="784px"></asp:TextBox>
    <asp:Button ID="btFiltro" runat="server" Text="Buscar" Width="104px" OnClick="btFiltro_Click" />
    <asp:GridView ID="gvAccesorios" runat="server" CellPadding="4" GridLines="None" Height="357px" Width="964px" OnRowCommand="gvAccesorios_RowCommand">
        <AlternatingRowStyle BackColor="#F2F2F2" ForeColor="#000066" />
        <Columns>
            <asp:ButtonField CommandName="modificar" Text="Modificar">
                <FooterStyle BackColor="#006699" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Button" CommandName="eliminar" Text="Eliminar">
                <FooterStyle BackColor="#006699" />
                <HeaderStyle BackColor="#006699" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:ButtonField>
        </Columns>
        <EditRowStyle BackColor="#CC0099" />
        <HeaderStyle BackColor="#006699" />
    </asp:GridView>
    <asp:Button ID="btAgregar" runat="server" Text="Agregar" Width="143px" OnClick="btAgregar_Click" />
</asp:Content>
