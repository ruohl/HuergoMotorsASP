using System;
using System.Collections.Generic;
using System.Text;

namespace HuergoASPDTO
{
	public class VehiculosDTO
	{
		public int Id { get; set; }
		public string Tipo { get; set; }
		public string Modelo { get; set; }
		public decimal PrecioVenta { get; set; }
		public int Stock { get; set; }
	}
}
