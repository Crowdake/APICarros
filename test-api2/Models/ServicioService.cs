using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace test_api2.Models
{
    public class ServicioService
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

        public bool GuardarServicio(ServicioModel servicio)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("INSERT INTO servicios (ID_Servicio, Nombre_Servicio, Precio, Descripcion_Servicio) VALUES (@ID_Servicio, @Nombre_Servicio, @Precio, @Descripcion_Servicio)", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@ID_Servicio", servicio.ID_Servicio));
                        com.Parameters.Add(new MySqlParameter("@Nombre_Servicio", servicio.Nombre_Servicio));
                        com.Parameters.Add(new MySqlParameter("@Precio", servicio.Precio));
                        com.Parameters.Add(new MySqlParameter("@Descripcion_Servicio", servicio.Descripcion_Servicio));
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

        public bool EliminarServicio(int ID_Servicio)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("DELETE FROM servicios WHERE ID_Servicio = @ID_Servicio", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@ID_Servicio", ID_Servicio));
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

        public List<ServicioModel> LeerServicio()
        {
            List<ServicioModel> servicios = new List<ServicioModel>();

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM servicios", conexion))
            {
                com.Connection.Open();
                MySqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    var servicio = new ServicioModel();
                    servicio.ID_Servicio = Convert.ToInt32(reader["ID_Servicio"]);
                    servicio.Nombre_Servicio = reader["Nombre_Servicio"].ToString();
                    servicio.Precio = Convert.ToSingle(reader["Precio"]);
                    servicio.Descripcion_Servicio = reader["Descripcion_Servicio"].ToString();
                    servicios.Add(servicio);
                }
                return servicios;
            }
        }

        public ServicioModel BuscarServicio(int ID_Servicio)
        {
            ServicioModel servicio = null;

            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = BuildConnection();

            using (MySqlCommand com = new MySqlCommand("SELECT * FROM servicios WHERE ID_Servicio = @ID_Servicio", conexion))
            {
                com.Connection.Open();
                com.Parameters.Add(new MySqlParameter("@ID_Servicio", ID_Servicio));
                MySqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    servicio = new ServicioModel();
                    servicio.ID_Servicio = Convert.ToInt32(reader["ID_Servicio"]);
                    servicio.Nombre_Servicio = reader["Nombre_Servicio"].ToString();
                    servicio.Precio = Convert.ToSingle(reader["Precio"]);
                    servicio.Descripcion_Servicio = reader["Descripcion_Servicio"].ToString();
                }
            }
            return servicio;
        }

        public bool EditarServicio(int ID_Servicio, ServicioModel servicio)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(BuildConnection()))
                {
                    conexion.Open();

                    using (MySqlCommand com = new MySqlCommand("UPDATE servicios SET ID_Servicio = @ID_Servicio, Nombre_Servicio = @Nombre_Servicio, Precio = @Precio,  Descripcion_Servicio = @Descripcion_Servicio WHERE ID_Servicio = @ID_Servicio", conexion))
                    {
                        com.Parameters.Add(new MySqlParameter("@ID_Servicio", ID_Servicio));
                        com.Parameters.Add(new MySqlParameter("@Nombre_Servicio", servicio.Nombre_Servicio));
                        com.Parameters.Add(new MySqlParameter("@Precio", servicio.Precio));
                        com.Parameters.Add(new MySqlParameter("@Descripcion_Servicio", servicio.Descripcion_Servicio));
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
