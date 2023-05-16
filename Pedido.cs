﻿/*
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
		public Pedido(Cliente cliente, int numeroDePedido, DateTime fechaDelEvento, float gastoDeComida, int mozos, bool manteleria, int bebidas, float costoTotal, float seña)
		{
			this.numeroDePedido = numeroDePedido;
			this.fechaDelEvento = fechaDelEvento;
			this.gastoDeComida = gastoDeComida;
			this.mozos = mozos;
			this.manteleria = manteleria;
			this.bebidas = bebidas;
			this.costoTotal = costoTotal;
			this.seña = seña;
			this.saldo = costoTotal - seña;
			this.cliente = cliente;
		}
		//Metodos
		public void AgregarServicio(Servicio sv)
		{
			servicio.Add(sv);
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
			ArrayList listado = new ArrayList();
			foreach(Servicio sv in servicio)
			{
				listado.Add(sv.NombreDelServicio);
			}
			return String.Join(" | ", listado);
		}
	}
}