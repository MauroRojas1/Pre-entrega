using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_pre_entrega
{
    internal class ProductoVendido
    {
        public int id { get; set; }

        public int stock { get; set; }

        public int idProducto { get; set; }

        public int idVenta { get; set; }

        public ProductoVendido()
        {
            id = 0;
            stock = 0;
            idProducto = 0;
            idVenta = 0;
        }
        public void TraerProductosVendidos(int idUsuarioProducto)
        {
            string connectionString = "Server = DESKTOP-I9OCHFR; Database = SistemaGestion; Trusted_connection = true";
            string query = "SELECT IdProducto,Producto.Descripciones, ProductoVendido.IdVenta from Producto join ProductoVendido on Producto.Id = ProductoVendido.IdProducto where idUsuario = @idUsu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("idUsu", idUsuarioProducto));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var produc = new ProductoVendido();
                            var producto = new Producto();
                            produc.idProducto = Convert.ToInt32(reader.GetValue(0));
                            producto.descripciones = reader.GetString(1);
                            produc.idVenta = Convert.ToInt32(reader.GetValue(2));

                            Console.WriteLine("-----Productos Vendidos------");
                            Console.WriteLine("IdProducto: " + produc.idProducto);
                            Console.WriteLine("Producto: " + producto.descripciones);
                            Console.WriteLine("IdVenta: " + produc.idVenta);
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
