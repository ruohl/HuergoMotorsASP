using System;
using System.Collections.Generic;
using System.Text;
using HuergoASPDTO;
using HuergoASPDatos;

namespace HuergoASPNegocio
{
	public class VehiculosNegocio
	{
        public void CrearVehiculo(VehiculosDTO vehiculoDto)
        {
            VehiculosDAO dao = new VehiculosDAO();
            dao.Create(vehiculoDto);
        }

        public void EditarVehiculo(VehiculosDTO vehiculoDto)
        {
            VehiculosDAO dao = new VehiculosDAO();
            dao.Update(vehiculoDto);
        }

        public VehiculosDTO BuscarVehiculo(string id)
        {
            VehiculosDAO dao = new VehiculosDAO();
            int id2 = Convert.ToInt32(id);
            return dao.Read(id2);
        }

        public void EliminarVehiculo(int id)
        {
            VehiculosDAO dao = new VehiculosDAO();
            dao.Delete(id);
        }

        public List<VehiculosDTO> BuscarVehiculos(string filtro)
        {
            VehiculosDAO dao = new VehiculosDAO();
            return dao.ReadAll(filtro);
        }
    }
}
