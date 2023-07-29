using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace test_api2.Models
{
    public class CategoriaService
    {
        private string BuildConnection()
        {
            // Configura la cadena de conexión a la base de datos MySQL
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "test",
                UserID = "root",
                Password = "EDUAup202016"
            };

            return builder.ConnectionString;
        }

        public bool GuardarCategoria(CategoriaModel categoria)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("INSERT INTO categorias (ID_Categoria, Nombre_Categoria, Descripcion_Categoria) VALUES (@ID_Categoria, @Nombre_Categoria, @Descripcion_Categoria)", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@ID_Categoria", categoria.ID_Categoria));
                        com.Parameters.Add(new MySqlParameter("@Nombre_Categoria", categoria.Nombre_Categoria));
                        com.Parameters.Add(new MySqlParameter("@Descripcion_Categoria", categoria.Descripcion_Categoria));
                        int rowsAffected = com.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool EliminarCategoria(int ID_Categoria)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("DELETE FROM categorias WHERE ID_Categoria = @ID_Categoria", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@ID_Categoria", ID_Categoria));
                        int rowsAffected = com.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<CategoriaModel> LeerCategoria()
        {
            List<CategoriaModel> categorias = new List<CategoriaModel>();

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM categorias", conexion))
            {
                com.Connection.Open();
                MySqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    var categoria = new CategoriaModel();
                    categoria.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                    categoria.Nombre_Categoria = reader["Nombre_Categoria"].ToString();
                    categoria.Descripcion_Categoria = reader["Descripcion_Categoria"].ToString();
                    categorias.Add(categoria);
                }
                return categorias;
            }
        }

        public CategoriaModel BuscarCategoria(int ID_Categoria)
        {
            CategoriaModel categoria = null;

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM categorias WHERE ID_Categoria = @ID_Categoria", conexion))
            {
                com.Connection.Open();
                com.Parameters.Add(new MySqlParameter("@ID_Categoria", ID_Categoria));
                MySqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    categoria = new CategoriaModel();
                    categoria.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                    categoria.Nombre_Categoria = reader["Nombre_Categoria"].ToString();
                    categoria.Descripcion_Categoria = reader["Descripcion_Categoria"].ToString();
                }
            }
            return categoria;
        }

        public bool EditarCategoria(int ID_Categoria, CategoriaModel categoria)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("UPDATE categorias SET ID_Categoria = @ID_Categoria, Nombre_Categoria = @Nombre_Categoria,  Descripcion_Categoria = @Descripcion_Categoria WHERE ID_Categoria = @ID_Categoria", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@ID_Categoria", ID_Categoria));
                        com.Parameters.Add(new MySqlParameter("@Nombre_Categoria", categoria.Nombre_Categoria));
                        com.Parameters.Add(new MySqlParameter("@Descripcion_Categoria", categoria.Descripcion_Categoria));
                        int rowsAffected = com.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
