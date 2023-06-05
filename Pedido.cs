/*
 * Created by SharpDevelop.
 * User: Mati
 * Date: 9/5/2023
 * Time: 19:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Proyecto2023
{
	/// <summary>
	/// Description of Pedido.
	/// </summary>
	public class Pedido
	{	
		/*
		  * ACA SOLAMENTE DECLARAMOS LO QUE SERA CADA UNO DE NUESTROS PEDIDOS
		*/
		//atributos
		private int numeroDePedido ;
		private DateTime fechaDelEvento; //fecha en numeros y todo junto
		private float gastoDeComida; //numero del gasto
		private int mozos;  //cuantos mozos
		private bool manteleria; //si o no
		private int bebidas; //numero de bebidas
		private float costoTotal;
		private float seña; //numero de cuanto dejo de seña
		private float saldo; // el resto de lo que falte pagar  
		private ArrayList servicio = new ArrayList();
		private Cliente cliente;
		
		//constructor
		public Pedido(Cliente cliente, ArrayList newServicio, int numeroDePedido, DateTime fechaDelEvento, float gastoDeComida, int mozos, bool manteleria, int bebidas, float seña)
		{
			this.numeroDePedido = numeroDePedido;
			this.fechaDelEvento = fechaDelEvento;
			this.gastoDeComida = gastoDeComida;
			this.mozos = mozos;
			this.manteleria = manteleria;
			this.bebidas = bebidas;
			/*
			  * CHECKEAMOS QUE LA MANTELERIA INGRESADA SEA UN BOOL Y CALCULAMOS EL COSTO TOTAL EN BASE A ESTA RESPUESTA
			  * */
			if(manteleria == true)
			{
				this.costoTotal = (mozos* 10000) + 2000 + (bebidas * 200) + gastoDeComida;
			}
			else
			{
				this.costoTotal = (mozos* 10000) + (bebidas * 200) + gastoDeComida;
			}
			
			this.seña = seña;
			this.saldo = costoTotal - seña;
			this.cliente = cliente;
			this.servicio = newServicio;
		}
		//propiedades 
		public int NumeroDePedido {
			get { return numeroDePedido; }
			set { numeroDePedido = value; }
		}
		
		public DateTime FechaDelEvento {
			get { return fechaDelEvento; }
			set { fechaDelEvento = value; }
		}
		public float GastoDeComida {
			get { return gastoDeComida; }
			set { gastoDeComida = value; }
		}
		public int Mozos {
			get { return mozos; }
			set { mozos = value; }
		}
		public bool Manteleria {
			get { return manteleria; }
			set { manteleria = value; }
		}
		public int Bebidas {
			get { return bebidas; }
			set { bebidas = value; }
		}
		public float CostoTotal {
			get { return costoTotal; }
			set { costoTotal = value; }
		}
		public float Seña {
			get { return seña; }
			set { seña = value; }
		}
		public float Saldo {
			get { return saldo; }
			set { saldo = value; }
		}
		public Cliente CLIENTE{
			get { return cliente; }
			set { cliente = value; }
		}
		//metodos
		public string RetornoServicio()
		{
			string devolver = "";
			foreach(Servicio sv in servicio)
			{
				/*
				  * DEVOLVEMOS UN ARRAY CON TODOS LOS SERVICIOS QUE INCLUIRA 
				  * CUANDO SE LISTEN LOS PEDIDOS 
				  * */
				devolver = devolver + sv.NombreDelServicio + ", ";
			}
			return devolver;
		}
		
	}
}
