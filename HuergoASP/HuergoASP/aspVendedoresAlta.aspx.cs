using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoASPNegocio;
using HuergoASPDTO;

namespace HuergoASP
{
	public partial class aspVendedoresAlta : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string boton = Request.QueryString["boton"];
            if (Page.IsPostBack)
            {

            }
            else
            {
                if (boton == "agregar")
                {
                    btGuardar.Text = "Crear";
                }
                else
                {
                    string id = Request.QueryString["id"];
                    VendedoresNegocio negocio = new VendedoresNegocio();
                    VendedoresDTO vendedor = negocio.BuscarVendedor(id);
                    if (vendedor != null)
                    {
                        txId.Text = Convert.ToString(vendedor.Id);
                        txNombre.Text = vendedor.Nombre;
                        txApellido.Text = vendedor.Apellido;
                        txSucursal.Text = vendedor.Sucursal;
                    }
                }
            }

        }

		protected void btGuardar_Click(object sender, EventArgs e)
		{
            if (btGuardar.Text == "Crear")
            {
                if (string.IsNullOrWhiteSpace(txNombre.Text) | string.IsNullOrWhiteSpace(txApellido.Text) | string.IsNullOrWhiteSpace(txSucursal.Text))
                {
                    lbInfo.Text = "Datos incompletos!";
                    return;
                }
                VendedoresDTO vendedor = new VendedoresDTO();
                vendedor.Id = 0;
                vendedor.Nombre = txNombre.Text;
                vendedor.Apellido = txApellido.Text;
                vendedor.Sucursal = txSucursal.Text;
                VendedoresNegocio negocio = new VendedoresNegocio();
                negocio.CrearVendedor(vendedor);
                lbInfo.Text = "Creado";

            }
            else
            {
                if (string.IsNullOrWhiteSpace(txNombre.Text))
                {
                    lbInfo.Text = "Nombre vacío";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txId.Text))
                {
                    lbInfo.Text = "ID vacío";
                    return;
                }
                VendedoresDTO vendedor = new VendedoresDTO();
                vendedor.Id = Convert.ToInt32(txId.Text);
                vendedor.Nombre = txNombre.Text;
                vendedor.Apellido = txApellido.Text;
                vendedor.Sucursal = txSucursal.Text;
                VendedoresNegocio negocio = new VendedoresNegocio();
                negocio.EditarVendedor(vendedor);
                lbInfo.Text = "Actualizado";
            }
        }

		protected void btVolver_Click(object sender, EventArgs e)
		{
            Response.Redirect("aspVendedores.aspx");
        }
	}
}