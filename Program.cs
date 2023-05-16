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

namespace Proyecto2023
{
	class Program
	{
		//Listados Importantes-------------------------------------------------
		private static ArrayList clientela = new ArrayList();
		private static ArrayList servicios = new ArrayList();
		private static ArrayList pedidos = new ArrayList();
		//------------------------------------------------------------------------
		//atributos---------------------------------------------------------------
		static int id_servicio;
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
			Console.WriteLine("1_Registrar Cliente: \n2_Quitar cliente \n3_Generar Pedido \n4_Eliminar Pedido \n5_Registrar Servicio \n6_Quitar Servicio \n7_Listado de Cliente \n8_Listado pedido \n9_Salir ");
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
				case 1:
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
					//En Caso de finalizar While true
					//MenuPrincipal();
					
					break;
				case 2:
					Console.WriteLine ("ingrese el dni del cliente a eliminar: ");
					int index= int.Parse(Console.ReadLine());
					EliminarCliente(index);
					break;
				case 4:
					break;
				case 5:
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
				case 6:
					break;
				case 7:
					break;
				case 8:
					ListadoServicio();
					break;
				case 9:
					break;
			}
		}
		//----------------------------------------------------------------------------------------
		
		//Metodos para modificacion---------------------------------------------------------------
		private static void EliminarCliente(int identificador)
		{
			foreach(Cliente cl in clientela)
			{
				if(cl.Dni == identificador)
				{
					clientela.Remove(cl);
				}
				
			}
		}
		private static void EliminarServicio(int identificador)
		{
			foreach(Servicio sv in servicios)
			{
				if(sv.ID == identificador)
				{
					clientela.Remove(sv);
				}
				
			}
		}
		private static void ListadoServicio()
		{
			foreach(Servicio sv in servicios)
			{
				Console.WriteLine("ID: {0} \nNOMBRE: {1} \nTIPO{2} \nDESCRIPCION: {3} \nCOSTO: {4}", sv.ID, sv.NombreDelServicio, sv.TipoDeServicio, sv.Descripcion, sv.Costo_Individual);
			}
		}
		//-------------------------------------------------------------------------------------------
	}
}