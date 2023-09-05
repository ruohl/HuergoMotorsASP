using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using HuergoASPDTO;

namespace HuergoASPDatos
{
	public class VendedoresDAO
	{
        public void Create(VendedoresDTO vendedor)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();

                string query = $@"INSERT INTO [Vendedores] (Id, Nombre, Apellido, Sucursal) 
                                VALUES (
                                    (SELECT ISNULL(MAX(Id), 0) FROM Vendedores) + 1, 
                                    '{vendedor.Nombre}',
                                    '{vendedor.Apellido}',
                                    '{vendedor.Sucursal}');";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();

                string query = $"DELETE FROM Vendedores WHERE Id = {id}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(VendedoresDTO vendedor)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();

                string query = $@"UPDATE [Vendedores]
                                  SET Nombre = '{vendedor.Nombre}',
                                      Apellido = '{vendedor.Apellido}',
                                      Sucursal = '{vendedor.Sucursal}'
                                WHERE Id = {vendedor.Id};";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public VendedoresDTO Read(string id)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT * FROM Vendedores WHERE Id = {id}", DBHelper.ConnectionString))
            {
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                VendedoresDTO vendedor = new VendedoresDTO();

                vendedor.Id = Convert.ToInt32(dr["Id"]);
                vendedor.Nombre = Convert.ToString(dr["Nombre"]);
                vendedor.Apellido = Convert.ToString(dr["Apellido"]);
                vendedor.Sucursal = Convert.ToString(dr["Sucursal"]);

                return vendedor;
            }

            return null;
        }

        public List<VendedoresDTO> ReadAll(string filtro)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT * FROM Vendedores WHERE Nombre LIKE '%{filtro}%' or Apellido LIKE '%{filtro}%' ", DBHelper.ConnectionString))
            {
                da.Fill(dt);
            }

            List<VendedoresDTO> lista = new List<VendedoresDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                VendedoresDTO vendedor = new VendedoresDTO();

                vendedor.Id = Convert.ToInt32(dr["Id"]);
                vendedor.Nombre = Convert.ToString(dr["Nombre"]);
                vendedor.Apellido = Convert.ToString(dr["Apellido"]);
                vendedor.Sucursal = Convert.ToString(dr["Sucursal"]);

                lista.Add(vendedor);
            }

            return lista;
        }
    }
}
