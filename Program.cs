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
		private static int id = 0;
		private static int exists = 0;
		private static bool condicion = true;
		private static List<Panaderia> empresas = new List<Panaderia>();
		public static void Main(string[] args)
		{	
			Console.ForegroundColor = ConsoleColor.Red;
			foreach(Panaderia listado in empresas)
			{
				Console.WriteLine("Empresa: {0} Id: {1}", listado.Nombre, listado.ID);
			}
			while(condicion)
			{
				Console.Clear();
				try
				{
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
					Console.WriteLine("\n1_Crear empresa \n2_Retomar Empresa \n3_Eliminar Empresa \n4_Salir");
					int opcion = int.Parse(Console.ReadLine());
					if(opcion >= 4)
					{
						condicion = false;
					}
					else
					{
						MENU(opcion);
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
		
		
		private static void MENU(int opcion)
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
						foreach(Panaderia creationPAN in empresas)
						{
							if(creationPAN.Nombre == name)
							{
								exists++;
							}
						}
						if(exists == 0)
						{
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
							Console.WriteLine("Ingrese el id de la empresa a acceder: ");
							int identificador = int.Parse(Console.ReadLine());
							Panaderia aux = Returning_To(empresas[identificador]);
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
						Console.WriteLine("Ingrese el id de la empresa a eliminar: ");	
						int elim_id = int.Parse(Console.ReadLine());
						foreach(Panaderia elimPAN in empresas)
						{
							if(elimPAN.ID == elim_id)
							{
								empresas.Remove(elimPAN);
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
			Panaderia returning_panaderia = new Panaderia(pan.ID, pan.Nombre, true);
			
			return returning_panaderia;
		}
	}
	
	
}