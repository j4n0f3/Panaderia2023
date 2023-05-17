/*
 * Created by SharpDevelop.
 * User: Mati
 * Date: 9/5/2023
 * Time: 19:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto2023
{
	class Program
	{
		//Listados Importantes-------------------------------------------------
		private static List<Cliente> clientela = new List<Cliente>();
		private static List<Servicio> servicios = new List<Servicio>();
		private static List<Pedido> pedidos = new List<Pedido>();
		//------------------------------------------------------------------------
		//atributos---------------------------------------------------------------
		private static int id_servicio = 0;
		private static int num_pedido = 0;
		private static bool habra_manteleria;
		//------------------------------------------------------------------------
		
		//Main-------------------------------------------------------------------------
		public static void Main(string[] args)
		{
			while(true)
			{
				MenuPrincipal();
			}
		}
		//------------------------------------------------------------------------------
		
		//Menu inicial-----------------------------------------------------------------
		private static void MenuPrincipal()
		{
			Console.Clear();
			/*
			  * AGREGAR SERIE DE INSTRUCCIONES PARA EL CORRECTO MANEJO DE LA APLICACION
			  * */
			Console.WriteLine("1_Registrar Cliente: \n2_Quitar cliente \n3_Generar Pedido \n4_Eliminar Pedido \n5_Registrar Servicio \n6_Quitar Servicio \n7_Listado de Cliente \n8_Listado pedido \n9_Listado Servicio \n10_Salir ");
			int opcion = int.Parse(Console.ReadLine());
			Ejecucion(opcion);
		}
		//------------------------------------------------------------------------------
		
		//Ejecucion de opciones-----------------------------------------------------------
		private static void Ejecucion(int opcion)
		{
			Console.Clear();
			switch(opcion)
			{
				case 1://CREAR CLIENTE
					Console.WriteLine ("ingrese el nombre del cliente");
					string nombre= Console.ReadLine();
					Console.WriteLine ("ingrese el apellido del cliente");
					string apellido=Console.ReadLine();
					Console.WriteLine ("ingrese el dni del cliente");
					int dni= int.Parse(Console.ReadLine());
					Console.WriteLine ("ingrese la dirrecion del cliente");
					string dirrection = Console.ReadLine();
					Cliente thisCliente = new Cliente(dni, nombre, apellido, dirrection);
					clientela.Add(thisCliente);
					break;
				case 2://ELIMINAR CLIENTE
					Console.WriteLine ("ingrese el dni del cliente a eliminar: ");
					int index= int.Parse(Console.ReadLine());
					clientela.Remove(SelectCliente(index));
					break;
				case 3://CREAR PEDIDO
					Console.WriteLine("Que Cliente registra este pedido?: ");
					int client = int.Parse(Console.ReadLine()); // Esta variable es el dni de un cliente y se envia como identificador del cliente a elejir
					Console.WriteLine("Que Fecha se realizara este evento?: ");
					DateTime fecha = DateTime.Parse(Console.ReadLine());
					Console.WriteLine("Cuantos mozos se requeriran?: ");
					int mozo = int.Parse(Console.ReadLine());
					Console.WriteLine("Cuanto gastara en comida?: ");
					float gastoComida = float.Parse(Console.ReadLine());
					Console.WriteLine("El Evento contara con manteleria?: ");
					string condicion = Console.ReadLine();
					if(condicion == "si")
					{
						habra_manteleria = true;
					}
					else
					{
						if(condicion == "no")
						{
							habra_manteleria = false;
						}
						else
						{
							Console.WriteLine("Error volver a intentar");
							MenuPrincipal();
						}
					}
					Console.WriteLine("Cuantas bebidas necesitara este Evento?: ");
					int bebida = int.Parse(Console.ReadLine());
					Console.WriteLine("Cuanto costar en total el evento?: ");
					float costoTotal = float.Parse(Console.ReadLine());
					Console.WriteLine("Con cuanto se Seño este Evento?: ");
					float seña = float.Parse(Console.ReadLine());
					
					Pedido ticket = new Pedido(SelectCliente(client), num_pedido, fecha, gastoComida, mozo, habra_manteleria, bebida, costoTotal, seña);
					num_pedido++;
					pedidos.Add(ticket);
					break;
				case 4://QUITAR PEDIDO
					Console.WriteLine ("ingrese el numero de pedido a eliminar: ");
					int numPedido= int.Parse(Console.ReadLine());
					pedidos.Remove(SelectPedido(num_pedido));
					break;
				case 5://SERVICIO
					id_servicio += 1;
					Console.WriteLine ("ingrese el nombre del servicio: ");
					string nomS= Console.ReadLine();
					Console.WriteLine ("ingrese el tipo de servicio: ");
					string tipo= Console.ReadLine();
					Console.WriteLine ("ingrese una descripcion del servicio: ");
					string descrip= Console.ReadLine();
					Console.WriteLine ("ingrese el costo del servicio: ");
					float costo= float.Parse(Console.ReadLine());
					Servicio thisService = new Servicio(id_servicio, nomS, tipo, descrip, costo);
					servicios.Add(thisService);
					break;
				case 6://QUITAR SERVICIO
					Console.WriteLine ("ingrese el id del servicio a eliminar: ");
					int ident= int.Parse(Console.ReadLine());
					servicios.Remove(SelectServicio(ident));
					break;
				case 7://LISTADO CLIENTE
					ListadoCliente();
					Console.ReadKey();
					break;
				case 8://LISTADO PEDIDO
					ListadoPedido();
					Console.ReadKey();
					break;
				case 9://LISTADO SERVICIO
					ListadoServicio();
					Console.ReadKey();
					break;
				default:
					Console.WriteLine("Error valor incorrecto");
					Console.ReadKey();
					break;
			}
		}
		//----------------------------------------------------------------------------------------
		
		//Metodos para modificacion---------------------------------------------------------------
		
		
		//-------------------------------------------------------------------------------------------
		
		//Listado----------------------------------------------------------------------------------
		private static void ListadoServicio()
		{
			foreach(Servicio sv in servicios)
			{
				Console.WriteLine("ID: {0}\nNOMBRE: {1}\nTIPO: {2}\nDESCRIPCION: {3}\nCOSTO: {4}", sv.ID, sv.NombreDelServicio, sv.TipoDeServicio, sv.Descripcion, sv.Costo_Individual);
			}
		}
		private static void ListadoCliente()
		{
			foreach(Cliente cl in clientela)
			{
				Console.WriteLine("DNI: {0}\nNOMBRE: {1}\nAPELLIDO: {2}\nDIRECCION: {3} \n", cl.Dni, cl.Nombre, cl.Apellido, cl.Dirreccion);
			}
		}
		private static void ListadoPedido()
		{
			string manteleria_condicion;
			foreach(Pedido pd in pedidos)
			{
				if(pd.Manteleria == true)
				{
					manteleria_condicion = "si";
				}
				else
				{
					manteleria_condicion = "no";
				}
				Console.WriteLine("Numero de pedido: {0} \nDni del cliente: {1}\nFecha del evento: {2}\nServicios contratados: {3}\nContara con manteleria? {4}\nCantidad de mozos empleados: {5}\nCantidad de bebidas en stock: {6}\nValor de la seña: {7}\nCosto Total: {8}\nRestante a pagar: {9}\n", pd.NumeroDePedido, pd.CLIENTE.Dni, pd.FechaDelEvento, pd.RetornoServicio(), manteleria_condicion, pd.Mozos, pd.Bebidas, pd.Seña, pd.CostoTotal, pd.Saldo);
			}
		}
		//-------------------------------------------------------------------------------------------
		
		//Retorno-------------------------------------------------------------------------------------
		private static Cliente SelectCliente(int identificador)
		{
			foreach(Cliente cl in clientela)
			{
				if(cl.Dni == identificador)
				{
					return cl;
				}
			}
			Cliente default_cliente = new Cliente(0, "null", "null", "null");
			return default_cliente;
		}
		
		private static Servicio SelectServicio(int identificador)
		{
			foreach(Servicio sv in servicios)
			{
				if(sv.ID == identificador)
				{
					return sv;
				}
			}
			Servicio default_servicio = new Servicio(0, "null", "null", "null", 0.0f);
			return default_servicio;
		}
		
		private static Pedido SelectPedido(int identificador)
		{
			foreach(Pedido PD in pedidos)
			{
				if(PD.NumeroDePedido == identificador)
				{
					return PD;
				}
			}
			Cliente default_cliente = new Cliente(0, "null", "null", "null");
			DateTime default_time = new DateTime(00, 00, 0000);
			Pedido default_pedido = new Pedido(default_cliente, 0, default_time, 0, 0, false, 0, 0.0f, 0.0f);
			return default_pedido;
		}
	}
}