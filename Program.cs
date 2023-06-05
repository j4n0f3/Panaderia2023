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
		/*
			  * ATRIBUTOS AUXILIARES PARA LA CREACION DE
			  * LAS EMPRESAS PANADERAS
		*/
		private static int id = 0;
		private static int exists = 0;
		//-----------------------------------------
		private static bool condicion = true;
		private static List<Panaderia> empresas = new List<Panaderia>();
		
		public static void Main(string[] args)
		{	
			Console.ForegroundColor = ConsoleColor.Red;
			
			while(condicion)
			{
				Console.Clear();
				try
				{
					//CHECKEO LA EXISTENCIA DE EMPRESAS PARA MOSTRARLAS
					if(empresas.Count == 0)
					{
						Console.WriteLine("No existe ninguna empresa.");
					}
					else
					{
						foreach(Panaderia muestra in empresas)
						{
							Console.WriteLine("\tEmpresas\n ID:{0} Empresa:{1}", muestra.ID, muestra.Nombre);
						}
					}
					//TERMINO POR MOSTRAR EL MENU Y POSTERIORMENTE EJECUTAR
					Console.WriteLine("\n1_Crear empresa \n2_Retomar Empresa \n3_Eliminar Empresa \n4_Renombrar \n5_Salir");
					int opcion = int.Parse(Console.ReadLine());
					if(opcion > 4)
					{
						condicion = false;
					}
					else
					{
						EJECUCION(opcion);
					}
				}
				catch(FormatException)
				{
					Console.WriteLine("ERROR, TIPO DE DATOS INVALIDO"); 
					Console.ReadKey();
				}
				catch(ArgumentNullException)
				{
					Console.WriteLine("ERROR, ARGUMENTO NULO"); 
					Console.ReadKey();
				}
				catch(InvalidOperationException)
				{
					Console.WriteLine("ERROR, OPERACION INVALIDA"); 
					Console.ReadKey();
				}
				
			}
		}
		
		private static void EJECUCION(int opcion)
		{
			Console.Clear();
			try
			{
				switch(opcion)
				{
					//CREACION DE EMPRESA
					case 1:
						Console.WriteLine("Ingrese el nombre de la panaderia: ");
						string name = Console.ReadLine();
						//CHECKEO LA EXISTENCIA DE ESTA EMPRESA
						foreach(Panaderia creationPAN in empresas)
						{
							if(creationPAN.Nombre == name)
							{
								exists++;
							}
						}
						if(exists == 0)
						{
							//EN CASO DE NO EXISTIR SE CREARA Y EJECUTARA LA EMPRESA
							Panaderia pan = new Panaderia(id++, name, true);
							empresas.Add(pan);
						}
						else
						{
							Console.WriteLine("La empresa ya existe");
							Console.ReadKey();
						}
						break;
					//RETOMANDO UNA EMPRESA
					case 2:
					//CHECKEA LA EXISTENCIA DE EMPRESAS EN EL LISTADO
						if(empresas.Count == 0)
						{
							Console.WriteLine("No existe ninguna empresa.");
						}
						else
						{
							foreach(Panaderia muestra in empresas)
							{
								Console.WriteLine("\tEmpresas\n ID:{0} Empresa:{1}", muestra.ID, muestra.Nombre);
							}
						}
						if(empresas.Count > 0)
						{
							//EN CASO DE QUE HAYA EMPRESAS EN EL LISTADO, SE PEDIRA EL ID DE LA EMPRESA A ACCEDER
							Console.WriteLine("Ingrese el id de la empresa a acceder: ");
							int identificador = int.Parse(Console.ReadLine());
							Panaderia aux = Returning_To(empresas[identificador]);
							/*
							  * TRAS CONSULTAR A QUE EMPRESA QUIERO ACCEDER LO QUE HAGO ES LLAMAR A RETURNING_TO PARA EJECUTAR UN
							  * OBJETO NUEVO QUE HAYA GUARDADO LOS DATOS DEL OBJETO VIEJO PARA POSTERIORMENTE DECIR
							  * QUE EL OBJETO VIEJO GUARDARA LOS DATOS QUE POSEE EL OBJETO NUEVO
							  * */
							for(int i = 0; i < empresas.Count -1; i++)
							{
								if(empresas[i].ID == aux.ID)
								{
									empresas[i] = aux;
								}
							}
						}
						else
						{
							Console.WriteLine("NO EXISTEN EMPRESAS, PRIMERO CREE UNA");
							Console.ReadKey();
						}
						break;
					//ELIMINAR EMPRESA
					case 3:
					//CHECKEO DE EXISTENCIA DE EMPRESAS
						if(empresas.Count == 0)
						{
							Console.WriteLine("No existe ninguna empresa.");
							Console.ReadKey();
						}
						else
						{
							foreach(Panaderia muestra in empresas)
							{
								Console.WriteLine("\tEmpresas\n ID:{0} Empresa:{1}", muestra.ID, muestra.Nombre);
							}
							Console.WriteLine("Ingrese el id de la empresa a eliminar: ");	
							int elim_id = int.Parse(Console.ReadLine());
							foreach(Panaderia elimPAN in empresas)
							{
								if(elimPAN.ID == elim_id)
								{
									empresas.Remove(elimPAN);
								}
							}
						}
						break;
					case 4:
						foreach(Panaderia PN_A in empresas)
						{
							Console.WriteLine("id:{0} nombre:{1}", PN_A.ID, PN_A.Nombre);
						}
						
						Console.WriteLine("Elija el id de la empresa a renombrar: ");
						int id_change = int.Parse(Console.ReadLine());
						
						foreach(Panaderia PN_B in empresas)
						{
							if(PN_B.ID == id_change)
							{
								Console.WriteLine("Ingrese el nuevo nombre: ");
								PN_B.Nombre = Console.ReadLine();
								
							}
						}
						
						break;
				}
			}
			catch (IndexOutOfRangeException)
			{ 
				Console.WriteLine("ERROR, LIMITE DE LISTA EXCEDIDO"); 
				Console.ReadKey();
			}
			catch(FormatException)
			{
				Console.WriteLine("ERROR, TIPO DE DATOS INVALIDO"); 
				Console.ReadKey();
			}
			catch(ArgumentNullException)
			{
				Console.WriteLine("ERROR, ARGUMENTO NULO"); 
				Console.ReadKey();
			}
			catch(ArgumentOutOfRangeException)
			{
				Console.WriteLine("ERROR, ARGUMENTO EXCEDIDO"); 
				Console.ReadKey();
			}
			catch(InvalidOperationException)
			{
				Console.WriteLine("ERROR, OPERACION INVALIDA"); 
				Console.ReadKey();
			}
			catch(OverflowException)
			{
				Console.WriteLine("ERROR, OVERFLOW DE DATO"); 
				Console.ReadKey();
			}
		}
		private static Panaderia Returning_To(Panaderia pan)
		{
			/*
			  * ACA INSTANCIO UN NUEVO OBJETO USANDO LOS DATOS DEL VIEJO 
			  * */
			Panaderia returning_panaderia = new Panaderia(pan.ID, pan.Nombre, true);
			
			return returning_panaderia;
		}
	}
	
	
}