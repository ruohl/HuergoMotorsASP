using System;
using System.Collections.Generic;
using System.Text;
using HuergoASPDTO;
using HuergoASPDatos;


namespace HuergoASPNegocio
{
	public class VendedoresNegocio
	{
        public void CrearVendedor(VendedoresDTO vendedorDto)
        {
            VendedoresDAO dao = new VendedoresDAO();
            dao.Create(vendedorDto);
        }

        public void EditarVendedor(VendedoresDTO vendedorDto)
        {
            VendedoresDAO dao = new VendedoresDAO();
            dao.Update(vendedorDto);
        }

        public VendedoresDTO BuscarVendedor(string id)
        {
            VendedoresDAO dao = new VendedoresDAO();
            string id2 = Convert.ToString(id);
            return dao.Read(id2);
        }

        public void EliminarVendedor(int id)
        {
            VendedoresDAO dao = new VendedoresDAO();
            dao.Delete(id);
        }

        public List<VendedoresDTO> BuscarVendedores(string filtro)
        {
            VendedoresDAO dao = new VendedoresDAO();
            return dao.ReadAll(filtro);
        }
    }
}
