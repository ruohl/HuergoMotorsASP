using System;
using System.Collections.Generic;
using System.Text;
using HuergoASPDTO;
using HuergoASPDatos;

namespace HuergoASPNegocio
{
	public class AccesoriosNegocio
	{
        public void CrearAccesorio(AccesoriosDTO accesorioDto)
        {
            AccesoriosDAO dao = new AccesoriosDAO();
            dao.Create(accesorioDto);
        }
        public void EditarAccesorio(AccesoriosDTO accesorioDto)
        {
            AccesoriosDAO dao = new AccesoriosDAO();
            dao.Update(accesorioDto);
        }
        public AccesoriosDTO BuscarAccesorio(string id)
        {
            AccesoriosDAO dao = new AccesoriosDAO();
            int id2 = Convert.ToInt32(id);
            return dao.Read(id2);
        }

        public void EliminarAccesorio(int id)
        {
            AccesoriosDAO dao = new AccesoriosDAO();
            dao.Delete(id);
        }

        public List<AccesoriosDTO> BuscarAccesorios(string filtro)
        {
            AccesoriosDAO dao = new AccesoriosDAO();
            return dao.ReadAll(filtro);
        }
    }
}
