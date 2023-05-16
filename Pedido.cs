/*
 * Created by SharpDevelop.
 * User: Mati
 * Date: 9/5/2023
 * Time: 19:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Proyecto2023
{
	/// <summary>
	/// Description of Pedido.
	/// </summary>
	public class Pedido
	{	
		//atributos
		private int numeroDePedido ;
		private int dni_Cliente;
		private int fechaDelEvento; //fecha en numeros y todo junto
		private int gastoDeComida; //numero del gasto
		private int mozos;  //cuantos mozos
		private string manteleria; //si o no
		private int bebidas; //numero de bebidas
		private int costoTotal ;
		private int seña; //numero de cuanto dejo de seña
		private int saldo; // el resto de lo que falte pagar  
		
		
		//constructor
		public Pedido()
		{
			
		}
		//propiedades 
		public int NumeroDePedido {
			get { return numeroDePedido; }
			set { numeroDePedido = value; }
		}
		public int Dni_Cliente {
			get { return dni_Cliente; }
			set { dni_Cliente = value; }
		}
		public int FechaDelEvento {
			get { return fechaDelEvento; }
			set { fechaDelEvento = value; }
		}
		public int GastoDeComida {
			get { return gastoDeComida; }
			set { gastoDeComida = value; }
		}
		public int Mozos {
			get { return mozos; }
			set { mozos = value; }
		}
		public string Manteleria {
			get { return manteleria; }
			set { manteleria = value; }
		}
		public int Bebidas {
			get { return bebidas; }
			set { bebidas = value; }
		}
		public int CostoTotal {
			get { return costoTotal; }
			set { costoTotal = value; }
		}
		public int Seña {
			get { return seña; }
			set { seña = value; }
		}
		public int Saldo {
			get { return saldo; }
			set { saldo = value; }
		}
		//metodos
	}
}
