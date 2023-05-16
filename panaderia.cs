/*
 * Created by SharpDevelop.
 * User: Mati
 * Date: 12/5/2023
 * Time: 17:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
namespace Proyecto2023
{
	/// <summary>
	/// Description of panaderia.
	/// </summary>
	public class panaderia
	{
		//atributoss
		private ArrayList listaDeClientes = new ArrayList ();
		private ArrayList listaDePedidos = new ArrayList ();
		//constructor
		public panaderia()
		{
			
		}
		//propiedades
		public ArrayList ListaDePedidos {
			get { return listaDePedidos; }
		}
		public ArrayList ListaDeClientes {
			get { return listaDeClientes; }
		}
		//metodos
		public void agregarCliente (Cliente cliente)
		{
			listaDeClientes.Add(cliente);
		}
		public void agregarPedidos (Pedido pedido)
		{
			listaDePedidos.Add(pedido);
		}
		public void crearCliente ()
		{
			Cliente cliente = new Cliente();
			Console.WriteLine ("ingrese el nombre del cliente");
			cliente.Nombre= Console.ReadLine();
			Console.WriteLine ("ingrese el apellido del cliente");
			cliente.Apellido=Console.ReadLine();
			Console.WriteLine ("ingrese el dni del cliente");
			cliente.Dni= int.Parse(Console.ReadLine());
			Console.WriteLine ("ingrese la dirrecion del cliente");
			cliente.Dirreccion = Console.ReadLine();
			agregarCliente(cliente);
		}
		public void crearPedido() 
		{
			Pedido pedido = new Pedido();
			Console.WriteLine ("ingrese el dni del cliente");
			pedido.Dni_Cliente= int.Parse(Console.ReadLine());
			Console.WriteLine("ingrese la fecha del evento");
			pedido.FechaDelEvento=int.Parse(Console.ReadLine());
			Console.WriteLine("ingrese el gasto de la comida ");
			pedido.GastoDeComida=int.Parse(Console.ReadLine());
			Console.WriteLine("ingrese la cantidad de mozos que desea tener");
			pedido.Mozos= int.Parse(Console.ReadLine());
			Console.WriteLine("desea tener manteleria? si o no ");
			pedido.Manteleria=Console.ReadLine();
			Console.WriteLine("ingrese el numero de bebidas");
			pedido.Bebidas = int.Parse(Console.ReadLine());
			Console.WriteLine("ingrese el costo total del evento");
			pedido.CostoTotal=int.Parse(Console.ReadLine());
			Console.WriteLine("ingrese cuanto pago por adelantado");
			pedido.Seña=int.Parse(Console.ReadLine());
			Console.WriteLine("lo que le resta pagar es:");
			pedido.Saldo=int.Parse(Console.ReadLine());
		}
	}
}
