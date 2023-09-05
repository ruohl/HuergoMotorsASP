<%@ Page Language="C#" MasterPageFile="~/Huergo.Master" AutoEventWireup="true" CodeBehind="aspVendedores.aspx.cs" Inherits="HuergoASP.aspVendedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenidoDeMisPaginas" runat="server">
    <asp:TextBox ID="txFiltro" runat="server" Height="27px" Width="784px"></asp:TextBox>
    <asp:Button ID="btFiltro" runat="server" OnClick="btFiltro_Click" Text="Buscar" Width="104px" />
    <asp:GridView ID="gvVendedores" runat="server" CellPadding="4" GridLines="None" Height="357px" OnRowCommand="gvVendedores_RowCommand" Width="964px">
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
    <asp:Button ID="btAgregar" runat="server" OnClick="btAgregar_Click1" Text="Agregar" Width="143px" />
</asp:Content>
