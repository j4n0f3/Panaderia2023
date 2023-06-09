﻿/*
 * Created by SharpDevelop.
 * User: Mati
 * Date: 20/5/2023
 * Time: 20:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Proyecto2023
{
	/// <summary>
	/// Description of Panaderia.
	/// </summary>
	public class Panaderia
	{
			//Atributos propios de una panaderia
			/*
			  * ACA DECLARAMOS LA BASE DE LA PANADERIA, PROPIOS DE ELLOS Y NO DEPENDEN DE LAS
			  * OTRAS CLASES PARA RELLENARSE(A EXCEPCION DEL MAIN)
			  * */
			private int id;
			private string nombre_panaderia;
			public int ID{ get{return id;}}
			public string Nombre{ get{return nombre_panaderia;}set{nombre_panaderia = value;}}
			//Listados Importantes-------------------------------------------------
			/*
			  * DONDE SE GUARDARAN CADA CLIENTE, SERVICIO Y PEDIDO PARA PODER ACCEDER A ELLOS
			  * CUANDO SE REQUIERAN Y NO SE PIERDAN
			  * */
			private static List<Cliente> clientela = new List<Cliente>();
			private static List<Servicio> servicios = new List<Servicio>();
			private static List<Pedido> pedidos = new List<Pedido>();
			//------------------------------------------------------------------------
			//atributos---------------------------------------------------------------
			/*
			  * ATRIBUTOS AUXILIARES PARA LA RESOLUCION DE
			  * ALGUNOS CASE
			 */
			private static int id_servicio = 0;
			private static int num_pedido = 0;
			private static bool habra_manteleria;
			private static bool condicion;
			//------------------------------------------------------------------------
			
			//Constructor----------------------------------------------------------------
			public Panaderia(int id, string nombre_panaderia, bool new_condicion)
			{
				/*
				  * EL CONSTRUCTOR INSTANCIA EL MENU Y EL MENU RECIEN INSTANCIA LA EJECUCION DE CADA CASO
				  * */
				this.id = id;
				this.nombre_panaderia = nombre_panaderia;
				condicion = new_condicion;
				try
				{
					while(condicion)
					{
						MenuPrincipalPanaderia();
					}
				}
				catch(StackOverflowException)
				{
					Console.WriteLine("BUCLE INFINITO DETECTADO.");
				 	Console.ReadKey();
				}
			}
			//------------------------------------------------------------------------
			
			
			//Menu de panaderia----------------------------------------------------------------
			private static void MenuPrincipalPanaderia()
			{
				Console.Clear();
				/*
				  * AGREGAR SERIE DE INSTRUCCIONES PARA EL CORRECTO MANEJO DE LA APLICACION
				  * */
				 try {
				 	Console.WriteLine("\n\t ******                                                  **                         **\n\t/*////**                                                /**                        /**\n\t/*   /**  **   **  *****  *******   ******    ******   ******  ******   ******     /**  *****   ******\n\t/******  /**  /** **///**//**///** //////**  **////   ///**/  //////** //**//*  ****** **///** **////\n\t/*//// **/**  /**/******* /**  /**  ******* //*****     /**    *******  /** /  **///**/*******//*****\n\t/*    /**/**  /**/**////  /**  /** **////**  /////**    /**   **////**  /**   /**  /**/**////  /////**\n\t/******* //******//****** ***  /**//******** ******     //** //********/***   //******//****** ******\n\t///////   //////  ////// ///   //  //////// //////       //   //////// ///     //////  ////// //////");
				 	Console.WriteLine("\t\t____________________________");
				 	Console.WriteLine("\t\t|1_Registrar Cliente:      |\n\t\t|2_Quitar cliente         |\n\t\t|3_Registrar Servicio         |\n\t\t|4_Quitar Servicio         |\n\t\t|5_Generar Pedido         |\n\t\t|6_Eliminar Pedido         |\n\t\t|7_Listado de Cliente      |\n\t\t|8_Listado pedido          |\n\t\t|9_Listado Servicio        |\n\t\t|10_Pago_Cliente        |\n\t\t|11_Salir                  |");
				 	Console.WriteLine("\t\t|__________________________|\n");
				 	int opcion =  int.Parse(Console.ReadLine());
					/*
					  * FINALIZO EN ESTE SITIO LA APLICACION PARA REDUCIR LA CANTIDAD DE OPCIONES A CHECKEAR EN CASO DE QUE SOLO QUISIERA SALIR
					*/
					if(opcion == 11)
					{
						condicion = false;
					}
					else
					{
						Ejecucion(opcion);
					}
							 		
				 } 
				 catch (FormatException) {
				 	
				 	Console.WriteLine("Tipo de dato invalido.");
				 	Console.ReadKey(true);
				 	MenuPrincipalPanaderia();
				 }
				
			}
			//------------------------------------------------------------------------------
			
			//Ejecucion de opciones-----------------------------------------------------------
			private static void Ejecucion(int opcion)
			{	
				
				Console.Clear();
				
				try {
				switch(opcion)
				{
					
					case 1://CREAR CLIENTE
						/*
						  * PRIMERO SE PREGUNTA POR EL DNI A AGREGAR, POSTERIORMENTE SE CHECKEA SI ESTE
						  * CLIENTE EXISTE, EN CASO DE QUE EXISTA CAMBIARA LA EXISTENCIA DE ESE DNI Y
						  * SOLTAR UN ERROR, FINALIZANDO EL PROCESO
						  * */
						bool dni_exists_check = false;
						Console.WriteLine ("ingrese el dni del cliente (en numeros)");
						int dni= int.Parse(Console.ReadLine());
						foreach(Cliente cliente in clientela)
						{
							if(cliente.Dni == dni)
							{
								dni_exists_check = true;
							}
						}
						if(dni_exists_check ==  true)
						{
							Console.WriteLine("Error, usuario ya existente");
							Console.ReadKey();
							break;
						}
						//------------------------------------------------------------------------------
						//TERMINA DE HACER LAS CONSULTAS DE AGREGADO
						Console.WriteLine ("ingrese el nombre del cliente");
						string nombre= Console.ReadLine();
						Console.WriteLine ("ingrese el apellido del cliente");
						string apellido=Console.ReadLine();
						Console.WriteLine ("ingrese la dirrecion del cliente");
						string dirrection = Console.ReadLine();
						Cliente thisCliente = new Cliente(dni, nombre, apellido, dirrection);
						clientela.Add(thisCliente);
						break;
					case 2://ELIMINAR CLIENTE
						ListadoCliente();
						Console.WriteLine ("ingrese el dni del cliente a eliminar( en numeros): ");
						int index= int.Parse(Console.ReadLine());
						//REMUEVE EL CLIENTE OBTENIDO DEL METODO SELECTCLIENTE
						clientela.Remove(SelectCliente(index));
						break;
					case 3://SERVICIO
						//USANDO EL ATRIBUTO DECLARADO PREVIAMENTE ID_SERVICIO SE SABRA CUAL SERA EL ID DEL SERVICIO A AGREGAR Y PARA SABER LA CANTIDAD TOTAL HISTORICA DE AGREGADO DE SERVICIOS
						id_servicio += 1;
						Console.WriteLine ("ingrese el nombre del servicio: ");
						string nomS= Console.ReadLine();
						Console.WriteLine ("ingrese el tipo de servicio: ");
						string tipo= Console.ReadLine();
						Console.WriteLine ("ingrese una descripcion del servicio: ");
						string descrip= Console.ReadLine();
						Console.WriteLine ("ingrese el costo del servicio:(en numeros) ");
						float costo= float.Parse(Console.ReadLine());
						Servicio thisService = new Servicio(id_servicio, nomS, tipo, descrip, costo);
						servicios.Add(thisService);
						break;
					case 4://QUITAR SERVICIO
						ListadoServicio();
						Console.WriteLine ("ingrese el id del servicio a eliminar:(ingresar el dni de la persona en numeros) ");
						int ident= int.Parse(Console.ReadLine());
						/*
						  * TRAS CONSULTAR EL ID DE QUIEN VAYA A QUITAR, SE COMPRUEBA LA EXISTENCIA DEL MISMO
						  * EN CASO DE NO EXISTIR, SE REINICIARA LA CONSULTA*/
						if (ident>servicios.Count) {
							Console.WriteLine("error no existe el servicio");
							Console.ReadKey(true);
							Ejecucion(4);
							break;
						}
						servicios.Remove(SelectServicio(ident));
						break;
					case 5://CREAR PEDIDO
						/*
						  * ATRIBUTOS AUXILIARES QUE SOLO SERAN UTILIZADOS EN
						  * LA CREACION DEL PEDIDO
						  * */
						int dni_check = 0;
						int cantidad_pedidos = 0;
						ArrayList thisServicios = new ArrayList();
						//---------------------------------------------------
						ListadoCliente();
						Console.WriteLine("Que Cliente registra este pedido?( Ingresar el dni del cliente ): ");
						int client = int.Parse(Console.ReadLine()); // Esta variable es el dni de un cliente y se envia como identificador del cliente a elejir
						/*
						  * POSTERIOR A LA CONSULTA DEL CLIENTE A ASIGNAR EL PEDIDO, SE CHECKEA QUE EXISTA.
						  * EN CASO DE NO EXISTIR SE INFORMARA EL ERROR Y FINALIZARA EL CASO
						  * */
						foreach(Cliente cliente in clientela)
						{
							if(cliente.Dni == client)
							{
								dni_check++;
							}
						}
						if(dni_check == 0)
						{
							Console.WriteLine("Cliente inexistente, debe registrarse: ");
							Console.ReadKey();
							break;
						}
						//--------------------------------------------------------------------------
						ListadoServicio();
						Console.WriteLine("cuantos servicios incluira?  (ingrese el numero de servicios): ");
						int serv_cant = int.Parse(Console.ReadLine());
						//SE CONSULTARAN Y AGREGARAN TANTOS SERVICIOS COMO SE HAYA REQUERIDO
						for(int i = 0; i < serv_cant; i++)
						{
							Console.WriteLine("Que servicio incluira?(ingresar el ID): ");
							int serv_id = int.Parse(Console.ReadLine());
							Servicio retornarSERV = SelectServicio(serv_id);
							thisServicios.Add(retornarSERV);
						}
						Console.WriteLine("Que Fecha se realizara este evento? ( ingresar la fecha en formato **/**/****): ");
						DateTime fecha = DateTime.Parse(Console.ReadLine());
						//checkeo de cantidad de pedidos para una misma fecha
						foreach(Pedido PED in pedidos)
						{
							if(PED.FechaDelEvento == fecha)
							{
								cantidad_pedidos++;
							}
						}
						if(cantidad_pedidos >2)
						{
							Console.WriteLine("Limite de pedidos para esta fecha alcanzada");
							Console.ReadKey();
							break;
						}
						//------------------------------------------------------------
						Console.WriteLine("Cuantos mozos se requeriran?: (ingresar el numero de mozos) ");
						int mozo = int.Parse(Console.ReadLine());
						Console.WriteLine("Cuanto gastara en comida?:(ingresar el monto en numeros) ");
						float gastoComida = float.Parse(Console.ReadLine());
						Console.WriteLine("El Evento contara con manteleria?: (ingresar si o no)  ");
						string condicion = Console.ReadLine();
						//TRANSFORMAR LA RESPUESTA DE STRING A BOOL COMO LO REQUIERE EL CONSTRUCTOR DE PEDIDO
						if(condicion == "si")
						{
							habra_manteleria = true;
						}
						else
						{
							if(condicion == "no")
							{
								habra_manteleria = false;
							}
							else
							{
								Console.WriteLine("Error volver a intentar");
								MenuPrincipalPanaderia();
							}
						}
						Console.WriteLine("Cuantas bebidas necesitara este Evento?: (ingresar el numero de bebidas) ");
						int bebida = int.Parse(Console.ReadLine());
						Console.WriteLine("Con cuanto se Seño este Evento?:(ingresar el monto en numeros) ");
						float seña = float.Parse(Console.ReadLine());
						Pedido ticket = new Pedido(SelectCliente(client), thisServicios, num_pedido, fecha, gastoComida, mozo, habra_manteleria, bebida, seña);
						num_pedido++;
						pedidos.Add(ticket);
						break;
					case 6://QUITAR PEDIDO
						DateTime fechaActual = DateTime.Now;
						ListadoPedido();
						Console.WriteLine ("ingrese el numero de pedido a eliminar: ");
						int numPedido= int.Parse(Console.ReadLine());
						/*
						  * PRIMERO REVISA QUE EL NUMERO COINCIDA CON EL PEDIDO A MODIFICAR
						  * EN CUANTO LO LOCALIZA CONSULTA SI YA FUE PAGADO EN SU TOTALIDAD EL PEDIDO Y YA FUE REALIZADO EN SU FECHA
						  * EN CASO DE CUMPLIR ESTAS CONDICIONES SE PREGUNTARA SI EL TIEMPO PARA CANCELAR EL PEDIDO FUE PAGADO O ESTA A UN MES DE DARSE EL EVENTO
						  * EN CASO DE POSITIVO A AMBOS PUNTOS SE ELIMINARA SIN PROBLEMA
						  * EN CASO NEGATIVO, MIENTRAS NO SEA PAGADO EN SU TOTALIDAD SE REQUERIRA EL PAGO DEL SALDO RESTANTE SE LE PEDIRA CUMPLIR CON EL PAGO EN SU TOTALIDAD
						  * POSTERIORMENTE TERMINARA EL LOOP DE PAGO Y SE ELIMINARA AUTOMATICAMENTE EL PEDIDO SOLICITADO
						  * */
						foreach(Pedido PD in pedidos)
						{
							if(PD.NumeroDePedido == num_pedido)
							{
								if(PD.FechaDelEvento >= fechaActual && PD.Saldo <= 0)
								{
									pedidos.Remove(PD);
									Console.WriteLine("Se ha cancelado sin problemas, la fecha del evento llego y su saldo fue pagado ");
									Console.ReadKey();
								}
								else
								{
									if(fechaActual.AddMonths(1) <  PD.FechaDelEvento)
									{
										pedidos.Remove(PD);
										Console.WriteLine("Se ha cancelado sin problemas");
										Console.ReadKey();
										break;
									}
									else
									{
										while(PD.Saldo <= 0)
										{
											Console.WriteLine("Debe abonar el pedido completo {0} PESOS", PD.Saldo);
											Console.ReadKey();
											Ejecucion(10);
										}
										pedidos.Remove(PD);
									}
								}
							}
						}
						break;
					case 7://LISTADO CLIENTE
						ListadoCliente();
						Console.ReadKey();
						break;
					case 8://LISTADO PEDIDO
						ListadoPedido();
						Console.ReadKey();
						break;
					case 9://LISTADO SERVICIO
						ListadoServicio();
						Console.ReadKey();
						break;
					case 10:
						//PAGO CLIENTE
						Console.WriteLine("Ingrese el numero de pedido a pagar: ");
						int ident_pedido = int.Parse(Console.ReadLine());
						foreach(Pedido pd in pedidos)
						{
							if(pd.NumeroDePedido == ident_pedido)
							{
								Console.WriteLine("Ingrese monto a pagar: ");
								float pago = float.Parse(Console.ReadLine());
								pd.Saldo -= pago;							
							}
						}
						Console.ReadKey();
						break;
						
					default:
						Console.WriteLine("Error valor incorrecto");
						Console.ReadKey();
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
			//----------------------------------------------------------------------------------------
		
			//Metodos para modificacion---------------------------------------------------------------
			/*
				  * AGARRA LOS LISTADOS, CREA UNO AUXILIAR
				  * CHEQUEA LA ULTIMA POSICION DEL LISTADO Y LO AÑADE COMO PRIMERA POSICION EN EL EL LISTADO AUXILIAR
				  * TERMINA POR IGUALAR EL LISTADO ORIGINAL AL AUXILIAR QUE FINALIZA CON LAS POSICIONES INTERCAMBIADAS
			*/
			public static void CambiarOrdenSERV()
			{
				
				List<Servicio> aux = new List<Servicio>();
				if(servicios.Count == 0)
				{
					Console.WriteLine("Necesita registrar un servicio, lista vacia");
					Console.ReadKey();
				}
				else
				{
					for(int i = servicios.Count-1; i > -1; i--)
					{
						aux.Add(servicios[i]);
					}
					servicios = aux;
				}
			}
			
			public static void CambiarOrdenCLI()
			{
				List<Cliente> aux = new List<Cliente>();
				if(clientela.Count == 0)
				{
					Console.WriteLine("Necesita registrar un cliente, lista vacia");
					Console.ReadKey();
				}
				else
				{
					for(int i = clientela.Count-1; i > -1; i--)
					{
						aux.Add(clientela[i]);
					}
					clientela = aux;
				}
			}
			
			public static void CambiarOrdenPED()
			{
				List<Pedido> aux = new List<Pedido>();
				if(pedidos.Count == 0)
				{
					Console.WriteLine("Necesita registrar un pedido, lista vacia");
					Console.ReadKey();
				}
				else
				{
					for(int i = pedidos.Count-1; i > -1; i--)
					{
						aux.Add(pedidos[i]);
					}
					pedidos = aux;
				}
			}
			//-------------------------------------------------------------------------------------------
		
			//Listado----------------------------------------------------------------------------------
			private static void ListadoServicio()
			{
				foreach(Servicio sv in servicios)
				{
					Console.WriteLine("ID: {0}\nNOMBRE: {1}\nTIPO: {2}\nDESCRIPCION: {3}\nCOSTO: {4}", sv.ID, sv.NombreDelServicio, sv.TipoDeServicio, sv.Descripcion, sv.Costo_Individual);
				}
			}
			private static void ListadoCliente()
			{
				foreach(Cliente cl in clientela)
				{
					Console.WriteLine("DNI: {0}\nNOMBRE: {1}\nAPELLIDO: {2}\nDIRECCION: {3} \n", cl.Dni, cl.Nombre, cl.Apellido, cl.Dirreccion);
				}
			}
			private static void ListadoPedido()
			{
				string manteleria_condicion;
				foreach(Pedido pd in pedidos)
				{
					//PEDIDO GUARDA COMO BOOL LA CONDICION DE USO DE MANTELERIA, ACA SE LO TRANSFORMA EN STRING PARA SU POSTERIOR USO
					if(pd.Manteleria == true)
					{
						manteleria_condicion = "si";
					}
					else
					{
						manteleria_condicion = "no";
					}
					Console.WriteLine("Numero de pedido: {0} \nDni del cliente: {1}\nFecha del evento: {2}\nServicios contratados: {3}\nContara con manteleria? {4}\nCantidad de mozos empleados: {5}\nCantidad de bebidas en stock: {6}\nGasto en comida: {7}\nValor de la seña: {8}\nCosto Total: {9}\nRestante a pagar: {10}\n", pd.NumeroDePedido, pd.CLIENTE.Dni, pd.FechaDelEvento.Date, pd.RetornoServicio(), manteleria_condicion, pd.Mozos, pd.Bebidas, pd.GastoDeComida, pd.Seña, pd.CostoTotal, pd.Saldo);
				}
			}
			//-------------------------------------------------------------------------------------------
		
			//Retorno-------------------------------------------------------------------------------------
			/*
			  * METODOS QUE RECIBEN POR PARAMETROS EL IDENTIFICADOR DEL OBJETO SOLICITADO
			  * LO DEVUELVE Y EN CASO DE NO EXISTIR EL MISMO DEVUELVE UN OBJETO PREDETERMINADO*/
			private static Cliente SelectCliente(int identificador)
			{
				foreach(Cliente cl in clientela)
				{
					if(cl.Dni == identificador)
					{
						return cl;
					}
				}
				Cliente default_cliente = new Cliente(0, "null", "null", "null");
				return default_cliente;
			}
		
			private static Servicio SelectServicio(int identificador)
			{
				foreach(Servicio sv in servicios)
				{
					if(sv.ID == identificador)
					{
						return sv;
					}
				}
				Servicio default_servicio = new Servicio(0, "null", "null", "null", 0.0f);
				return default_servicio;
			}
		
			private static Pedido SelectPedido(int identificador)
			{
				foreach(Pedido PD in pedidos)
				{
					if(PD.NumeroDePedido == identificador)
					{
						return PD;
					}
				}
				Cliente default_cliente = new Cliente(0, "null", "null", "null");
				DateTime default_time = new DateTime(00, 00, 0000);
				Pedido default_pedido = new Pedido(default_cliente, null, 0, default_time, 0, 0, false, 0, 0.0f);
				return default_pedido;
			}
		}
	}
