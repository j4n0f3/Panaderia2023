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
			private int id;
			
			private string nombreDelServicio ;	
			
			
			private string tipoDeServicio;
			
			
			private string descripcion ;
			
			
			private float costo_Individual ;
			
			//constructor
		public Servicio(int id, string nombreServicio, string tipoServcio, string descripcion, float costo_individual)
		{
			this.id = id;
			this.nombreDelServicio = nombreServicio;
			this.tipoDeServicio = tipoServcio; 
			this.descripcion =  descripcion;
			this.costo_Individual = costo_individual;
			
		}
		//propiedades
		public int ID {
				get { return id; }
				set { id = value; }
			}
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
		public float Costo_Individual {
				get { return costo_Individual; }
				set { costo_Individual = value; }
			}
		//metodos
	}
}
