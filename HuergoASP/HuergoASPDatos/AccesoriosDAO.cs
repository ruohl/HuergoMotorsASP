using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using HuergoASPDTO;

namespace HuergoASPDatos
{
	public class AccesoriosDAO
	{
        public void Create(AccesoriosDTO accesorio)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();

                string query = $@"INSERT INTO [Accesorios] (Id, Nombre, Modelo, Precio) 
                                VALUES (
                                    (SELECT ISNULL(MAX(Id), 0) FROM Clientes) + 1, 
                                    '{accesorio.Nombre}',
                                    '{accesorio.Modelo}',
                                    '{accesorio.Precio}');";

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

                string query = $"DELETE FROM Accesorios WHERE Id = {id}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(AccesoriosDTO accesorio)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();

                string query = $@"UPDATE [Accesorios]
                                  SET Nombre = '{accesorio.Nombre}',
                                      Modelo = '{accesorio.Modelo}',
                                      Precio = '{accesorio.Precio.ToString(System.Globalization.CultureInfo.InvariantCulture)}'
                                WHERE Id = {accesorio.Id};";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AccesoriosDTO Read(int id)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT * FROM Accesorios WHERE Id = {id}", DBHelper.ConnectionString))
            {
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                AccesoriosDTO accesorio = new AccesoriosDTO();

                accesorio.Id = Convert.ToInt32(dr["Id"]);
                accesorio.Nombre = Convert.ToString(dr["Nombre"]);
                accesorio.Modelo = Convert.ToString(dr["Modelo"]);
                accesorio.Precio = Convert.ToDecimal(dr["Precio"]);

                return accesorio;
            }

            return null;
        }

        public List<AccesoriosDTO> ReadAll(string filtro)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT * FROM Accesorios WHERE Nombre LIKE '%{filtro}%' or Modelo LIKE '%{filtro}%'", DBHelper.ConnectionString))
            {
                da.Fill(dt);
            }

            List<AccesoriosDTO> lista = new List<AccesoriosDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                AccesoriosDTO accesorio = new AccesoriosDTO();

                accesorio.Id = Convert.ToInt32(dr["Id"]);
                accesorio.Nombre = Convert.ToString(dr["Nombre"]);
                accesorio.Modelo = Convert.ToString(dr["Modelo"]);
                accesorio.Precio = Convert.ToDecimal(dr["Precio"]);

                lista.Add(accesorio);
            }

            return lista;
        }
    }
}
