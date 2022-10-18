using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_pre_entrega
{
    internal class Producto
    {
        public int id { get; set; }
        public string descripciones { get; set; }
        public int costo { get; set; }
        public int precioVenta { get; set; }
        public int stock { get; set; }
        public int idUsuario { get; set; }

        public Producto()
        {
            id = 0;
            descripciones = string.Empty;
            costo = 0;
            precioVenta = 0;
            stock = 0;
            idUsuario = 0;

        }
        public  void TraerProducto(int idUsuario)
        {
            string connectionString = "Server = DESKTOP-I9OCHFR; Database = SistemaGestion; Trusted_connection = true";
            string query = "SELECT * FROM producto where IdUsuario = @idUsu";

            var ListaProductos = new List<Producto>();

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
                            var produc = new Producto();

                            produc.id = Convert.ToInt32(reader.GetValue(0));
                            produc.descripciones = reader.GetString(1);
                            produc.costo = Convert.ToInt32(reader.GetValue(2));
                            produc.precioVenta = Convert.ToInt32(reader.GetValue(3));
                            produc.stock = Convert.ToInt32(reader.GetValue(4));
                            produc.idUsuario = Convert.ToInt32(reader.GetValue(5));

                            ListaProductos.Add(produc);

                        }
                        Console.Clear();

                        foreach (var produc in ListaProductos)
                        {

                            Console.WriteLine("Producto: " + produc.descripciones);
                            Console.WriteLine("IdUsuario: " + produc.idUsuario);
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
