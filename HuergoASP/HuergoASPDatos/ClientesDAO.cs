using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using HuergoASPDTO;

namespace HuergoASPDatos
{
    public class ClienteDAO
    {
        public void Create(ClientesDTO cliente)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();

                string query = $@"INSERT INTO [Clientes] (Id, Nombre, Direccion, Telefono, Email, Contraseña) 
                                VALUES (
                                    (SELECT ISNULL(MAX(Id), 0) FROM Clientes) + 1, 
                                    '{cliente.Nombre}',
                                    '{cliente.Direccion}',
                                    '{cliente.Telefono}',
                                    '{cliente.Email}',
                                    '{cliente.Contraseña}');";

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

                string query = $"DELETE FROM Clientes WHERE Id = {id}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(ClientesDTO cliente)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();

                string query = $@"UPDATE [Clientes]
                                  SET Nombre = '{cliente.Nombre}',
                                      Direccion = '{cliente.Direccion}',
                                      Telefono = '{cliente.Telefono}',
                                      Email = '{cliente.Email}',
                                      Contraseña = '{cliente.Contraseña}'
                                WHERE Id = {cliente.Id};";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public ClientesDTO Read(int id)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT * FROM Clientes WHERE Id = {id}", DBHelper.ConnectionString))
            {
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                ClientesDTO cliente = new ClientesDTO();

                cliente.Id = Convert.ToInt32(dr["Id"]);
                cliente.Nombre = Convert.ToString(dr["Nombre"]);
                cliente.Direccion = Convert.ToString(dr["Direccion"]);
                cliente.Email = Convert.ToString(dr["Email"]);
                cliente.Contraseña = Convert.ToString(dr["Contraseña"]);
                cliente.Telefono = Convert.ToString(dr["Telefono"]);

                return cliente;
            }

            return null;
        }

        public List<ClientesDTO> ReadAll(string filtro)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT * FROM Clientes WHERE Nombre LIKE '%{filtro}%'", DBHelper.ConnectionString))
            {
                da.Fill(dt);
            }

            List<ClientesDTO> lista = new List<ClientesDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                ClientesDTO cliente = new ClientesDTO();

                cliente.Id = Convert.ToInt32(dr["Id"]);
                cliente.Nombre = Convert.ToString(dr["Nombre"]);
                cliente.Direccion = Convert.ToString(dr["Direccion"]);
                cliente.Email = Convert.ToString(dr["Email"]);
                cliente.Contraseña = Convert.ToString(dr["Contraseña"]);
                cliente.Telefono = Convert.ToString(dr["Telefono"]);

                lista.Add(cliente);
            }

            return lista;
        }
    }
}
