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
using Proyecto_pre_entrega.Handlers;

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
            
            ADO_Usuario ADO_usuario = new ADO_Usuario();
            ADO_Producto ADO_producto = new ADO_Producto();
            ADO_ProductoVendido ADO_productoVendido = new ADO_ProductoVendido();
            ADO_Venta ADO_venta = new ADO_Venta();

            switch (nums)
            {
                case 1:
                    Console.WriteLine("Ingrese nombre del usuario");
                    string NombreUsuario = Console.ReadLine();
                    Console.Clear();
                    ADO_usuario.TraerUsuario(NombreUsuario);
                    Console.WriteLine("------Informacion del usuario------");
                    Console.WriteLine("IdUsuario: " + ADO_usuario.Usuario.Id);
                    Console.WriteLine("Nombre: " + ADO_usuario.Usuario.Nombre);
                    Console.WriteLine("Apellido: " + ADO_usuario.Usuario.Apellido);
                    Console.WriteLine("NombreUsuario: " + ADO_usuario.Usuario.NombreUsuario);
                    Console.WriteLine("Contraseña: " + ADO_usuario.Usuario.Contraseña);
                    Console.WriteLine("Mail: " + ADO_usuario.Usuario.Mail);
                    Console.WriteLine("--------------------------------------");
                    Console.ReadKey();
                    break;
               
                case 2:
                    Console.WriteLine("Ingrese id del usuario");
                    int idUsuario = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();    
                    ADO_producto.TraerProducto(idUsuario);
                    foreach (var produc in ADO_producto.ListaProductos)
                    {
                        Console.WriteLine("Producto: " + produc.Descripciones);
                        Console.WriteLine("Costo: " + produc.Costo);
                        Console.WriteLine("IdUsuario: " + produc.IdUsuario);
                        Console.WriteLine("------------------------------\n");
                    }
                    Console.ReadKey();
                    break;
                
                case 3:
                    Console.WriteLine("Ingrese el id del usuario para ver sus ventas");
                    int idUsuarioProducto = Convert.ToInt32(Console.ReadLine());
                    ADO_productoVendido.TraerProductosVendidos(idUsuarioProducto);
                    Console.Clear();
                    foreach (var productoVendido in ADO_productoVendido.ListaProductosVendidos)
                    {
                        Console.WriteLine("Id del producto Vendido: " + productoVendido.IdProducto);
                        Console.WriteLine("IdUsuario que realizo la venta: " + productoVendido.IdVenta);
                        Console.WriteLine("------------------------------\n");
                    }
                   
                    Console.ReadKey();
                    break;
                
                case 4:
                    Console.WriteLine("Ingrese el ID del usuario para buscar ventas ");
                    int idUsuarioVenta = Convert.ToInt32(Console.ReadLine());
                    ADO_venta.TraerVentas(idUsuarioVenta);
                    Console.Clear(); 
                    Console.WriteLine("-----Ventas------");
                    foreach (var venta in ADO_venta.ListaVentas)
                    {
                        Console.WriteLine("Id: " + venta.Id);
                        Console.WriteLine("Comentario: " + venta.Comentarios);
                        Console.WriteLine("IdUsuario: " + venta.IdUsuario);
                        Console.WriteLine("------------------------------\n");
                    }
                    Console.ReadKey();
                    break;
                
                case 5:
                    Console.WriteLine("Ingrese Usuario");
                    string nombreUsuario = Console.ReadLine();
                    Console.WriteLine("Ingrese Contra");
                    string contra = Console.ReadLine();
                    Console.Clear();
                    ADO_usuario.InicioSesion(nombreUsuario, contra);

                    Console.WriteLine("------Informacion del usuario------");
                    Console.WriteLine("IdUsuario: " + ADO_usuario.Usuario.Id);
                    Console.WriteLine("Nombre: " + ADO_usuario.Usuario.Nombre);
                    Console.WriteLine("Apellido: " + ADO_usuario.Usuario.Apellido);
                    Console.WriteLine("NombreUsuario: " + ADO_usuario.Usuario.NombreUsuario);
                    Console.WriteLine("Contraseña: " + ADO_usuario.Usuario.Contraseña);
                    Console.WriteLine("Mail: " + ADO_usuario.Usuario.Mail);
                    Console.WriteLine("--------------------------------------"); 
                    Console.ReadKey();
                    break;
            }

        }

    }
}
