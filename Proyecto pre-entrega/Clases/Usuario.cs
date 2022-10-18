using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_pre_entrega
{
    internal class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombreUsuario { get; set; }
        public string contraseña { get; set; }
        public string mail { get; set; }

      



        public Usuario()
        {
            id = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            nombreUsuario = string.Empty;
            contraseña = string.Empty;
            mail = string.Empty;

        }
        public void TraerUsuario(string nombre)
        {
            string connectionString = "Server = DESKTOP-I9OCHFR; Database = SistemaGestion; Trusted_connection = true";
            string query = "SELECT * FROM usuario where nombre like @idusu";
  
            var listaUsuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("idusu", nombre));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var usuario = new Usuario();
                            usuario.id = Convert.ToInt32(reader.GetValue(0));
                            usuario.nombre = reader.GetString(1);
                            usuario.apellido = reader.GetString(2);
                            usuario.nombreUsuario = reader.GetString(3);
                            usuario.contraseña = reader.GetString(4);
                            usuario.mail = reader.GetString(5);

                            listaUsuarios.Add(usuario);

                            Console.WriteLine("------Informacion del usuario------");
                            Console.WriteLine("IdUsuario: " + usuario.id);
                            Console.WriteLine("Nombre: " + usuario.nombre);
                            Console.WriteLine("Apellido: " + usuario.apellido);
                            Console.WriteLine("NombreUsuario: " + usuario.nombreUsuario);
                            Console.WriteLine("Contraseña" + usuario.contraseña);
                            Console.WriteLine("Mail: " + usuario.mail);
                            Console.WriteLine("--------------------------------------");
                            Console.ReadKey();
                        }
                        reader.Close();

                    }
                }
            }
        }

        public void InicioSesion(string NombreUsuario, string Contraseña)
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
                            var usuario = new Usuario();

                            usuario.id = Convert.ToInt32(reader.GetValue(0));
                            usuario.nombre = reader.GetString(1);
                            usuario.apellido = reader.GetString(2);
                            usuario.nombreUsuario = reader.GetString(3);
                            usuario.contraseña = reader.GetString(4);
                            usuario.mail = reader.GetString(5);

                            if (NombreUsuario == usuario.nombreUsuario && Contraseña == usuario.contraseña)
                            {
                                Console.WriteLine("------Informacion del usuario------");
                                Console.WriteLine("IdUsuario: " + usuario.id);
                                Console.WriteLine("Nombre: " + usuario.nombre);
                                Console.WriteLine("Apellido: " + usuario.apellido);
                                Console.WriteLine("NombreUsuario: " + usuario.nombreUsuario);
                                Console.WriteLine("Contraseña" + usuario.contraseña);
                                Console.WriteLine("Mail: " + usuario.mail);
                                Console.WriteLine("--------------------------------------");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("El usuario no existe");
                                usuario.id = 0;
                                usuario.nombre = string.Empty;
                                usuario.apellido = string.Empty;
                                usuario.nombreUsuario = string.Empty;
                                usuario.contraseña = string.Empty;
                                usuario.mail = string.Empty;
                                Console.WriteLine(usuario.id + " " + usuario.nombre + " " + usuario.apellido + " " + usuario.nombreUsuario + " " + usuario.contraseña + " " + usuario.mail);

                            }
                            Console.ReadKey();
                        }
                        reader.Close();
                    }
                }
                
            }
        }
    }
}
