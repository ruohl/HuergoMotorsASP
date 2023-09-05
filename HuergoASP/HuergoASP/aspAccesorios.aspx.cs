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
	public partial class aspAccesorios : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			ActualizarGrilla();
		}
		private void ActualizarGrilla()
		{
			AccesoriosNegocio negocio = new AccesoriosNegocio();

			List<AccesoriosDTO> lista = negocio.BuscarAccesorios(txFiltro.Text);

			gvAccesorios.DataSource = lista;
			gvAccesorios.DataBind();
		}
		protected void gvAccesorios_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int posicion = Convert.ToInt32(e.CommandArgument);
			if (e.CommandName == "modificar")
			{
				int id = Convert.ToInt32(gvAccesorios.Rows[posicion].Cells[2].Text);
				Response.Redirect("aspAccesoriosAlta.aspx?id=" + id.ToString());
			}
			else if (e.CommandName == "eliminar")
			{
				int id = Convert.ToInt32(gvAccesorios.Rows[posicion].Cells[2].Text);
				AccesoriosNegocio negocio = new AccesoriosNegocio();
				negocio.EliminarAccesorio(id);
				ActualizarGrilla();
			}
		}

		protected void btFiltro_Click(object sender, EventArgs e)
		{
			ActualizarGrilla();
		}

		protected void btAgregar_Click(object sender, EventArgs e)
		{
			Response.Redirect("aspAccesoriosAlta.aspx?boton=agregar");
		}
	}
}