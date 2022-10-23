using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Proyecto_pre_entrega.Handlers
{
    internal class ADO_Usuario
    {
        public Usuario Usuario = new Usuario();
        public Usuario TraerUsuario(string NombreUsuario)
        {
            string connectionString = "Server = DESKTOP-I9OCHFR; Database = SistemaGestion; Trusted_connection = true";
            string query = "SELECT * FROM usuario where NombreUsuario like @idusu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("idusu", NombreUsuario));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Usuario.Id = Convert.ToInt32(reader.GetValue(0));
                            Usuario.Nombre = reader.GetString(1);
                            Usuario.Apellido = reader.GetString(2);
                            Usuario.NombreUsuario = reader.GetString(3);
                            Usuario.Contraseña = reader.GetString(4);
                            Usuario.Mail = reader.GetString(5);
                        }
                        return Usuario;

                        reader.Close();

                    }
                }
            }
        }

        public Usuario InicioSesion(string NombreUsuario, string Contraseña)
        {
            string connectionString = "Server = DESKTOP-I9OCHFR; Database = SistemaGestion; Trusted_connection = true";
            string query = "SELECT * FROM usuario where nombreUsuario like @idusu and Contraseña like @Contra";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("idusu", NombreUsuario));
                    command.Parameters.Add(new SqlParameter("Contra", Contraseña));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario.Id = Convert.ToInt32(reader.GetValue(0));
                            Usuario.Nombre = reader.GetString(1);
                            Usuario.Apellido = reader.GetString(2);
                            Usuario.NombreUsuario = reader.GetString(3);
                            Usuario.Contraseña = reader.GetString(4);
                            Usuario.Mail = reader.GetString(5);
                         
                        }
                        if (NombreUsuario == Usuario.NombreUsuario && Contraseña == Usuario.Contraseña)
                        {
                            return Usuario;
                        }
                        else
                        {
                            Usuario.Id = 0;
                            Usuario.Nombre = string.Empty;
                            Usuario.Apellido = string.Empty;
                            Usuario.NombreUsuario = string.Empty;
                            Usuario.Contraseña = string.Empty;
                            Usuario.Mail = string.Empty;
                            return Usuario;
                        }
                            reader.Close();
                    }
                }

            }
        }
    }
}
