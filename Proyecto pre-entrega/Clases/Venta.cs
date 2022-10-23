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
        public int Id { get; set; }
        public string Comentarios { get; set; }

        public int IdUsuario { get; set; }

        public Venta()
        { 
            Id = 0;
            Comentarios = string.Empty;
            IdUsuario = 0;
            
        }
    }
}
