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
	public partial class aspVehiculosAlta : System.Web.UI.Page
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
                    VehiculosNegocio negocio = new VehiculosNegocio();
                    VehiculosDTO vehiculo = negocio.BuscarVehiculo(id);
                    if (vehiculo != null)
                    {
                        txId.Text = Convert.ToString(vehiculo.Id);
                        txTipo.Text = vehiculo.Tipo;
                        txModelo.Text = vehiculo.Modelo;
                        txPrecioVenta.Text = vehiculo.PrecioVenta.ToString();
                        txStock.Text = vehiculo.Stock.ToString();
                    }
                }
            }
        }

		protected void btGuardar_Click1(object sender, EventArgs e)
		{
            if (btGuardar.Text == "Crear")
            {
                if (string.IsNullOrWhiteSpace(txTipo.Text) | string.IsNullOrWhiteSpace(txModelo.Text) | string.IsNullOrWhiteSpace(txPrecioVenta.Text) | string.IsNullOrWhiteSpace(txStock.Text))
                {
                    lbInfo.Text = "Datos incompletos!";
                    return;
                }
                VehiculosDTO vehiculo = new VehiculosDTO();
                vehiculo.Id = 0;
                vehiculo.Tipo = txTipo.Text;
                vehiculo.Modelo = txModelo.Text;
                vehiculo.PrecioVenta = Convert.ToDecimal(txPrecioVenta.Text);
                vehiculo.Stock = Convert.ToInt32(txStock.Text);
                VehiculosNegocio negocio = new VehiculosNegocio();
                negocio.CrearVehiculo(vehiculo);
                lbInfo.Text = "Creado";

            }
            else
            {
                if (string.IsNullOrWhiteSpace(txModelo.Text))
                {
                    lbInfo.Text = "Modelo vacío";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txId.Text))
                {
                    lbInfo.Text = "ID vacío";
                    return;
                }
                VehiculosDTO vehiculo = new VehiculosDTO();
                vehiculo.Id = Convert.ToInt32(txId.Text);
                vehiculo.Tipo = txTipo.Text;
                vehiculo.Modelo = txModelo.Text;
                vehiculo.PrecioVenta = Convert.ToDecimal(txPrecioVenta.Text);
                vehiculo.Stock = Convert.ToInt32(txStock.Text);
                VehiculosNegocio negocio = new VehiculosNegocio();
                negocio.EditarVehiculo(vehiculo);
                lbInfo.Text = "Actualizado";
            }
        }

		protected void btVolver_Click(object sender, EventArgs e)
		{
            Response.Redirect("aspVehiculos.aspx");
        }
	}
}