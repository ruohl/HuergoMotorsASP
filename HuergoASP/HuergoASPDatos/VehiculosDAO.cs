using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using HuergoASPDTO;

namespace HuergoASPDatos
{
	public class VehiculosDAO
	{
        public void Create(VehiculosDTO vehiculo)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();

                string query = $@"INSERT INTO [Vehiculos] (Id, Tipo, Modelo, PrecioVenta, Stock) 
                                VALUES (
                                    (SELECT ISNULL(MAX(Id), 0) FROM Vendedores) + 1, 
                                    '{vehiculo.Tipo}',
                                    '{vehiculo.Modelo}',
                                    '{vehiculo.PrecioVenta.ToString(System.Globalization.CultureInfo.InvariantCulture)}',
                                    '{vehiculo.Stock}');";

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

                string query = $"DELETE FROM Vehiculos WHERE Id = {id}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(VehiculosDTO vehiculo)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();

                string query = $@"UPDATE [Vehiculos]
                                SET Tipo = '{vehiculo.Tipo}',
                                    Modelo = '{vehiculo.Modelo}',
                                    PrecioVenta = '{vehiculo.PrecioVenta.ToString(System.Globalization.CultureInfo.InvariantCulture)}',
                                    Stock = '{vehiculo.Stock}'
                                WHERE Id = {vehiculo.Id};";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public VehiculosDTO Read(int id)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT * FROM Vehiculos WHERE Id = {id}", DBHelper.ConnectionString))
            {
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                VehiculosDTO vehiculo = new VehiculosDTO();
                vehiculo.Id = Convert.ToInt32(dr["Id"]);
                vehiculo.Tipo = Convert.ToString(dr["Tipo"]);
                vehiculo.Modelo = Convert.ToString(dr["Modelo"]);
                vehiculo.PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]);
                vehiculo.Stock = Convert.ToInt32(dr["Stock"]);

                return vehiculo;
            }

            return null;
        }

        public List<VehiculosDTO> ReadAll(string filtro)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT * FROM Vehiculos WHERE Modelo LIKE '%{filtro}%'", DBHelper.ConnectionString))
            {
                da.Fill(dt);
            }

            List<VehiculosDTO> lista = new List<VehiculosDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                VehiculosDTO vehiculo = new VehiculosDTO();
                vehiculo.Id = Convert.ToInt32(dr["Id"]);
                vehiculo.Tipo = Convert.ToString(dr["Tipo"]);
                vehiculo.Modelo = Convert.ToString(dr["Modelo"]);
                vehiculo.PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]);
                vehiculo.Stock = Convert.ToInt32(dr["Stock"]);
                lista.Add(vehiculo);
            }

            return lista;
        }
    }
}
