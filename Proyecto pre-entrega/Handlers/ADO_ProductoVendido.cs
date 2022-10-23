using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_pre_entrega.Handlers
{
    internal class ADO_ProductoVendido
    {
        public ProductoVendido ProductoVendido = new ProductoVendido();
        public List<ProductoVendido> ListaProductosVendidos = new List<ProductoVendido>();
        

        public List<ProductoVendido> TraerProductosVendidos(int idUsuarioProducto)
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
                            ProductoVendido = new ProductoVendido();
                            ProductoVendido.IdProducto = Convert.ToInt32(reader.GetValue(0));                          
                            ProductoVendido.IdVenta = Convert.ToInt32(reader.GetValue(2));
                            ListaProductosVendidos.Add(ProductoVendido);
                            

                        }
                        return ListaProductosVendidos;
                        reader.Close();

                    }
                }
            }
        }
    }
}
