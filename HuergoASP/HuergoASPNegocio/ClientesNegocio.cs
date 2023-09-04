using System;
using System.Collections.Generic;
using System.Text;
using HuergoASPDTO;
using HuergoASPDatos;

namespace HuergoASPNegocio
{
	public class ClientesNegocio
	{
        public void CrearCliente(ClientesDTO clienteDto)
        {
            ClienteDAO dao = new ClienteDAO();
            dao.Create(clienteDto);
        }

        public void EditarCliente(ClientesDTO clienteDto)
        {
            ClienteDAO dao = new ClienteDAO();
            dao.Update(clienteDto);
        }

        public void EliminarCliente(int id)
        {
            ClienteDAO dao = new ClienteDAO();
            dao.Delete(id);
        }
        public ClientesDTO BuscarCliente(string ID)
		{
            ClienteDAO dao = new ClienteDAO();
            int id2 = Convert.ToInt32(ID);
            return dao.Read(id2);
        }
        public List<ClientesDTO> BuscarClientes(string filtro)
        {
            ClienteDAO dao = new ClienteDAO();
            return dao.ReadAll(filtro);
        }
    }
}
