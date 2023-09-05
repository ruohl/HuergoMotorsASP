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
	public partial class aspVendedores : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			ActualizarGrilla();
		}
		private void ActualizarGrilla()
		{
			VendedoresNegocio negocio = new VendedoresNegocio();

			List<VendedoresDTO> lista = negocio.BuscarVendedores(txFiltro.Text);

			gvVendedores.DataSource = lista;
			gvVendedores.DataBind();
		}
		protected void gvVendedores_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int posicion = Convert.ToInt32(e.CommandArgument);
			if (e.CommandName == "modificar")
			{
				int id = Convert.ToInt32(gvVendedores.Rows[posicion].Cells[2].Text);
				Response.Redirect("aspVendedoresAlta.aspx?id=" + id.ToString());
			}
			else if (e.CommandName == "eliminar")
			{
				int id = Convert.ToInt32(gvVendedores.Rows[posicion].Cells[2].Text);
				VendedoresNegocio negocio = new VendedoresNegocio();
				negocio.EliminarVendedor(id);
				ActualizarGrilla();
			}
		}

		protected void btFiltro_Click(object sender, EventArgs e)
		{
			ActualizarGrilla();
		}
		protected void btAgregar_Click1(object sender, EventArgs e)
		{
			Response.Redirect("aspVendedoresAlta.aspx?boton=agregar");
		}
	}
}