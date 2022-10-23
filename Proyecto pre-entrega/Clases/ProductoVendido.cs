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
        public int Id { get; set; }

        public int Stock { get; set; }

        public int IdProducto { get; set; }

        public int IdVenta { get; set; }

        public ProductoVendido()
        {
            Id = 0;
            Stock = 0;
            IdProducto = 0;
            IdVenta = 0;
        }
        
    }
}
