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
	public partial class aspAccesoriosAlta : System.Web.UI.Page
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
                    AccesoriosNegocio negocio = new AccesoriosNegocio();
                    AccesoriosDTO accesorio = negocio.BuscarAccesorio(id);
                    if (accesorio != null)
                    {
                        txId.Text = Convert.ToString(accesorio.Id);
                        txNombre.Text = accesorio.Nombre;
                        txModelo.Text = accesorio.Modelo;
                        txPrecio.Text = Convert.ToString(accesorio.Precio);
                    }
                }
            }
        }

		protected void btGuardar_Click(object sender, EventArgs e)
		{
            if (btGuardar.Text == "Crear")
            {
                if (string.IsNullOrWhiteSpace(txNombre.Text) | string.IsNullOrWhiteSpace(txModelo.Text) | string.IsNullOrWhiteSpace(txPrecio.Text))
                {
                    lbInfo.Text = "Datos incompletos!";
                    return;
                }
                AccesoriosDTO accesorio = new AccesoriosDTO();
                accesorio.Id = 0;
                accesorio.Nombre = txNombre.Text;
                accesorio.Modelo = txModelo.Text;
                accesorio.Precio = Convert.ToDecimal(txPrecio.Text);
                AccesoriosNegocio negocio = new AccesoriosNegocio();
                negocio.CrearAccesorio(accesorio);
                lbInfo.Text = "Creado";

            }
            else
            {
                if (string.IsNullOrWhiteSpace(txNombre.Text))
                {
                    lbInfo.Text = "Nombre vacío";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txModelo.Text))
                {
                    lbInfo.Text = "Modelo vacío";
                    return;
                }
                AccesoriosDTO accesorio = new AccesoriosDTO();
                accesorio.Id = Convert.ToInt32(txId.Text);
                accesorio.Nombre = txNombre.Text;
                accesorio.Modelo = txModelo.Text;
                accesorio.Precio = Convert.ToDecimal(txPrecio.Text);
                AccesoriosNegocio negocio = new AccesoriosNegocio();
                negocio.EditarAccesorio(accesorio);
                lbInfo.Text = "Actualizado";
            }
        }

		protected void btVolver_Click(object sender, EventArgs e)
		{
            Response.Redirect("aspAccesorios.aspx");
        }
	}
}