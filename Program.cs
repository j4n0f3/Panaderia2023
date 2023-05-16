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
		private static ArrayList clientela = new ArrayList();
		public static void Main(string[] args)
		{
			while(true)
			{
				MenuPrincipal();
			}
			Console.ReadKey(true);
		}
		
		
		private static void MenuPrincipal()
		{
			Console.WriteLine("1_Registrar Cliente: \n 2_Quitar cliente \n 3_Generar Pedido \n 4_Eliminar Pedido \n 5_Registrar Servicio \n 6_Quitar Servicio \n 7_Listado de Cliente \n 8_Listado pedido \n 9_Salir ");
			int opcion = int.Parse(Console.ReadLine());
			Ejecucion(opcion);
		}
		
		private static void Ejecucion(int opcion)
		{
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
					
					break;
				case 4:
					break;
				case 5:
					break;
				case 6:
					break;
				case 7:
					break;
				case 8:
					break;
				case 9:
					break;
			}
		}
		private void EliminarCliente(int identificador)
		{
			foreach(Cliente cl in clientela)
			{
				if(cl.Dni == identificador)
				{
					clientela.Remove(cl);
				}
				
			}
		}
	}
}