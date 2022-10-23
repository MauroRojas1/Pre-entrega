using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Identity.Client;

namespace Proyecto_pre_entrega.Handlers
{
    internal class ADO_Venta
    {   
        public Venta venta = new Venta();
        public List<Venta> ListaVentas = new List<Venta>();
        public List<Venta> TraerVentas(int idUsuario)
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
                            venta = new Venta();
                            venta.Id = Convert.ToInt32(reader.GetValue(0));
                            venta.Comentarios = reader.GetString(1);
                            venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));
                            ListaVentas.Add(venta);
                        }
                        return ListaVentas;
                        reader.Close();
                    }
                }
            }
        }
    }
}
