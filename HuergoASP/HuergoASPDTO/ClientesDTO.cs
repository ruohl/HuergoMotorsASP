using System;
using System.Collections.Generic;
using System.Text;

namespace HuergoASPDTO
{
	public class ClientesDTO
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
    }
}
