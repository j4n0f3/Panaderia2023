/*
 * Created by SharpDevelop.
 * User: Mati
 * Date: 9/5/2023
 * Time: 19:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Proyecto2023
{
	/// <summary>
	/// Description of Servicio.
	/// </summary>
	public class Servicio
	{
			//atributos
			private string nombreDelServicio ;	
			
			
			private string tipoDeServicio;
			
			
			private string descripcion ;
			
			
			private int costo_Individual ;
			
			//constructor
		public Servicio( string nombreServicio, string tipoServcio, string descripcion, int costo_individual)
		{
			this.nombreDelServicio = nombreServicio;
			this.tipoDeServicio = tipoServcio; 
			this.descripcion =  descripcion;
			this.costo_Individual = costo_individual;
			
		}
		//propiedades
		public string NombreDelServicio {
				get { return nombreDelServicio; }
				set { nombreDelServicio = value; }
			}
		public string TipoDeServicio {
				get { return tipoDeServicio; }
				set { tipoDeServicio = value; }
			}
		public string Descripcion {
				get { return descripcion; }
				set { descripcion = value; }
			}
		public int Costo_Individual {
				get { return costo_Individual; }
				set { costo_Individual = value; }
			}
		//metodos
	}
}
