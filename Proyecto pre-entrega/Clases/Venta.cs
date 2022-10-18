using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_pre_entrega
{
    internal class Venta
    { 
        public int id { get; set; }
        public string comentarios { get; set; }

        public int idUsuario { get; set; }

        public Venta()
        { 
            id = 0;
            comentarios = string.Empty;
            idUsuario = 0;
            
        }

        public void TraerVentas(int idUsuario)
        {
            string connectionString = "Server = DESKTOP-I9OCHFR; Database = SistemaGestion; Trusted_connection = true";
            string query = "SELECT * FROM venta where idUsuario = @idUsu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("idUsu", idUsuario));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Venta venta = new Venta();
                            venta.id = Convert.ToInt32(reader.GetValue(0));
                            venta.comentarios = reader.GetString(1);
                            venta.idUsuario = Convert.ToInt32(reader.GetValue(2));

                            Console.WriteLine("-----Ventas------");
                            Console.WriteLine("Id: " + venta.id);
                            Console.WriteLine("Comentario: " + venta.comentarios);
                            Console.WriteLine("IdUsuario: " + venta.idUsuario);
                            Console.WriteLine("------------------------------\n");
                        }
                        Console.ReadKey();
                        reader.Close();
                    }
                }      
            }
        }
    }
}
