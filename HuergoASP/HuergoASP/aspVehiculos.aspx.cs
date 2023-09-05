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
	public partial class aspVehiculos : System.Web.UI.Page
	{
		private void ActualizarGrilla()
		{
			VehiculosNegocio negocio = new VehiculosNegocio();

			List<VehiculosDTO> lista = negocio.BuscarVehiculos(txFiltro.Text);

			gvVehiculos.DataSource = lista;
			gvVehiculos.DataBind();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			ActualizarGrilla();
		}

		protected void btAgregar_Click(object sender, EventArgs e)
		{
			Response.Redirect("aspVehiculosAlta.aspx?boton=agregar");
		}

		protected void btFiltro_Click(object sender, EventArgs e)
		{
			ActualizarGrilla();
		}

		protected void gvVehiculos_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int posicion = Convert.ToInt32(e.CommandArgument);
			if (e.CommandName == "modificar")
			{
				int id = Convert.ToInt32(gvVehiculos.Rows[posicion].Cells[2].Text);
				Response.Redirect("aspVehiculosAlta.aspx?id=" + id.ToString());
			}
			else if (e.CommandName == "eliminar")
			{
				int id = Convert.ToInt32(gvVehiculos.Rows[posicion].Cells[2].Text);
				VehiculosNegocio negocio = new VehiculosNegocio();
				negocio.EliminarVehiculo(id);
				ActualizarGrilla();
			}
		}
	}
}