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
	public partial class aspClientes : System.Web.UI.Page
	{
		private void ActualizarGrilla()
		{
			ClientesNegocio negocio = new ClientesNegocio();

			List<ClientesDTO> lista = negocio.BuscarClientes(txFiltro.Text);

			gvClientes.DataSource = lista;
			gvClientes.DataBind();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			ActualizarGrilla();
		}

		protected void btFiltro_Click(object sender, EventArgs e)
		{
			ActualizarGrilla();
		}

		protected void gvClientes_RowCommand1(object sender, GridViewCommandEventArgs e)
		{
			int posicion = Convert.ToInt32(e.CommandArgument);
			if (e.CommandName == "modificar")
			{
				int id = Convert.ToInt32(gvClientes.Rows[posicion].Cells[2].Text);
				Response.Redirect("aspClientesAlta.aspx?id=" + id.ToString());
			}
			else if (e.CommandName == "eliminar")
			{
				int id = Convert.ToInt32(gvClientes.Rows[posicion].Cells[2].Text);
				ClientesNegocio negocio = new ClientesNegocio();
				negocio.EliminarCliente(id);
				ActualizarGrilla();
			}
		}

		protected void btAgregar_Click(object sender, EventArgs e)
		{
			Response.Redirect("aspClientesAlta.aspx?boton=agregar");
		}
	}
}