using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.Identity.Client;
using System.ComponentModel;

namespace Proyecto_pre_entrega
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese las opcion a utilizar");
            Console.WriteLine("1. Traer Usuario");
            Console.WriteLine("2. Traer Producto");
            Console.WriteLine("3. Traer Productos vendidos");
            Console.WriteLine("4. Traer Ventas");
            Console.WriteLine("5. Inicio de sesion");
           
            int nums = Convert.ToInt32(Console.ReadLine());
            
            Usuario usuario = new Usuario();
            Producto producto = new Producto();
            ProductoVendido productoVendido = new ProductoVendido();
            Venta venta = new Venta();

            switch (nums)
            {
                case 1:
                    Console.WriteLine("Ingrese nombre del usuario");
                    string nombre = Console.ReadLine();
                    Console.Clear();
                    usuario.TraerUsuario(nombre);
                    break;
                case 2:
                    Console.WriteLine("Ingrese id del usuario");
                    int idUsuario = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();    
                    producto.TraerProducto(idUsuario);
                    break;
                case 3:
                    Console.WriteLine("Ingrese el id del usuario para ver sus ventas");
                    int idUsuarioProducto = Convert.ToInt32(Console.ReadLine());
                    productoVendido.TraerProductosVendidos(idUsuarioProducto);
                    break;
                case 4:
                    Console.WriteLine("Ingrese el ID del usuario para buscar ventas ");
                    int idUsuarioVenta = Convert.ToInt32(Console.ReadLine());
                    venta.TraerVentas(idUsuarioVenta);
                    break;
                case 5:
                    Console.WriteLine("Ingrese Usuario");
                    string nombreUsuario = Console.ReadLine();
                    Console.WriteLine("Ingrese Contra");
                    string contra =Console.ReadLine();
                    Console.Clear();
                    usuario.InicioSesion(nombreUsuario, contra);
                    break;

            }

        }

    }
}
