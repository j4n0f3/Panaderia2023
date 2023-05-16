/*
 * Created by SharpDevelop.
 * User: Mati
 * Date: 9/5/2023
 * Time: 19:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Proyecto2023
{
	/// <summary>
	/// Description of Cliente.
	/// </summary>
	public class Cliente
	{
		//atributo 
		private string nombre ;
		
		private string apellido;
		
		private int dni ;
		
		private string dirreccion;
		
		//constructor
		public Cliente(int dni, string nombre, string apellido, string dirreccion)
		{
			this.dni = dni;
			this.nombre = nombre;
			this.apellido = apellido;
			this.dirreccion = dirreccion;
		}
		//propiedades 
		public string Nombre {
			get { return nombre; }
			set { nombre = value; }}
		
		public string Apellido {
			get { return apellido; }
			set { apellido = value; }}
		
		public int Dni {
			get { return dni; }
			set { dni = value; }}
		
		public string Dirreccion {
			get { return dirreccion; }
			set { dirreccion = value; }}
		//metodos
	}
}
