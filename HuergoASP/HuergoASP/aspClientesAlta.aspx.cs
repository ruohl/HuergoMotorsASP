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
	public partial class aspClientesAlta : System.Web.UI.Page
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
                    ClientesNegocio negocio = new ClientesNegocio();
                    ClientesDTO cliente = negocio.BuscarCliente(id);
                    if (cliente != null)
                    {
                        txId.Text = Convert.ToString(cliente.Id);
                        txNombre.Text = cliente.Nombre;
                        txDireccion.Text = cliente.Direccion;
                        txTelefono.Text = cliente.Telefono;
                        txEmail.Text = cliente.Email;
                        txContraseña.Text = cliente.Contraseña;
                    }
                }
            }
        }
		protected void btGuardar_Click(object sender, EventArgs e)
		{
            if (btGuardar.Text == "Crear")
			{
                if (string.IsNullOrWhiteSpace(txNombre.Text) | string.IsNullOrWhiteSpace(txDireccion.Text) | string.IsNullOrWhiteSpace(txTelefono.Text) | string.IsNullOrWhiteSpace(txEmail.Text) | string.IsNullOrWhiteSpace(txContraseña.Text))
				{
                    lbInfo.Text = "Datos incompletos!";
                    return;
                }
                ClientesDTO cliente = new ClientesDTO();
                cliente.Id = 0;
                cliente.Nombre = txNombre.Text;
                cliente.Direccion = txDireccion.Text;
                cliente.Telefono = txTelefono.Text;
                cliente.Email = txEmail.Text;
                cliente.Contraseña = txContraseña.Text;
                ClientesNegocio negocio = new ClientesNegocio();
                negocio.CrearCliente(cliente);
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
                ClientesDTO cliente = new ClientesDTO();
                cliente.Id = Convert.ToInt32(txId.Text);
                cliente.Nombre = txNombre.Text;
                cliente.Direccion = txDireccion.Text;
                cliente.Telefono = txTelefono.Text;
                cliente.Email = txEmail.Text;
                cliente.Contraseña = txContraseña.Text;
                ClientesNegocio negocio = new ClientesNegocio();
                negocio.EditarCliente(cliente);
                lbInfo.Text = "Actualizado";
            }
        }

		protected void btVolver_Click(object sender, EventArgs e)
		{
            Response.Redirect("aspClientes.aspx");

        }
	}
}