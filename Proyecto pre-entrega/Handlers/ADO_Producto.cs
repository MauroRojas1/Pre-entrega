using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_pre_entrega.Handlers
{
    internal class ADO_Producto
    {
        public Producto Produc = new Producto();
        public List<Producto> ListaProductos = new List<Producto>();
        public List<Producto> TraerProducto(int idUsuario)
        {
            string connectionString = "Server = DESKTOP-I9OCHFR; Database = SistemaGestion; Trusted_connection = true";
            string query = "SELECT * FROM producto where IdUsuario = @idUsu";
             
            
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
                            Produc = new Producto();
                            Produc.Id = Convert.ToInt32(reader.GetValue(0));
                            Produc.Descripciones = reader.GetString(1);
                            Produc.Costo = Convert.ToInt32(reader.GetValue(2));
                            Produc.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                            Produc.Stock = Convert.ToInt32(reader.GetValue(4));
                            Produc.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                            ListaProductos.Add(Produc);

                        }
                        return ListaProductos;
                        
                        reader.Close();
                    }

                }

            }
        }
    }
}
