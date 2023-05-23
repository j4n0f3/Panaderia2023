/*
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
			//Listados Importantes-------------------------------------------------
			private static List<Cliente> clientela = new List<Cliente>();
			private static List<Servicio> servicios = new List<Servicio>();
			private static List<Pedido> pedidos = new List<Pedido>();
			//------------------------------------------------------------------------
			//atributos---------------------------------------------------------------
			private static int id_servicio = 0;
			private static int num_pedido = 0;
			private static bool habra_manteleria;
			private static bool condicion = true;
			//------------------------------------------------------------------------
			
			//Constructor----------------------------------------------------------------
			public Panaderia()
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Title();
				Console.ReadKey();
				Console.Clear();
				
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
			private static void Title()
			{
				
		    	Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
		        Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
		        string title = @"
                        		  *******      **     ****     **     **     *******   ******** *******   **     **        ****   ****   ****   ****
                        		/**////**    ****   /**/**   /**    ****   /**////** /**///// /**////** /**    ****      */// * *///** */// * */// *
                        		/**   /**   **//**  /**//**  /**   **//**  /**    /**/**      /**   /** /**   **//**    /    /*/*  */*/    /*/    /*
                        		/*******   **  //** /** //** /**  **  //** /**    /**/******* /*******  /**  **  //**      *** /* * /*   ***    ***
                        		/**////   **********/**  //**/** **********/**    /**/**////  /**///**  /** **********    *//  /**  /*  *//    /// *
                        		/**      /**//////**/**   //****/**//////**/**    ** /**      /**  //** /**/**//////**   *     /*   /* *      *   /*
                        		/**      /**     /**/**    //***/**     /**/*******  /********/**   //**/**/**     /**  /******/ **** /******/ ****
                        		//       //      // //      /// //      // ///////   //////// //     // // //      //   //////  ////  //////  ////


                                                                                                                        ..,*//////////////////***,,,,..                                            
                                                                                                              ..,********/*******************///***//*/********,,***,.                                  
                                                                                                      ,**////////////(/*/////(/////*///***////////***,,************,,*///*,.                            
                                                                                               .,///((((((////((////**//*/////((//(////////****////////(/*,,***,***,,*,,*//****,.                       
                                                                                           ,(/**/(((((////*///*/(//,*/***//***/*****///////////////****/*////**,,,,,********/**//(/,                    
                                                                                      .,*//(///*//*//*,*****/*/*,,**,***,,,**/**,*****,,,,**//********//***//****/***,,**,*/***//***(*                  
                                                                                 ,*//*//*/**/******/**/**,,,,,**,,,,*/(/,,,,****,,*//**,,**,,,*********************/*,,,,,*,,****///**/*                
                                                                            .*(//////////////////////***////***,,,,,,,,**,,,,,,,,...,,,**,,*//**,**//******,*********/*,,,,,****/*********              
                                                                       .,*/***//****///**/(///*//////////////*/*///*,***,,,,,,...,,.,,,,,,,,,,************//********/*****,,,,,************,            
                                                                  ,***//(///(///////////////(((//////////////*****//////////**,,,,.,,..,,.,,,,,,,**,*******//************/****,,,,*********/*,          
                                                             .,**//////////////////((///(//(///((/((*//(/*************/*****/////*,,,,,,,......,,,,,,*********/*****************,,,,,*,*****/**.        
                                                         ,*//////(/((((///////(/(/****//*/**///*//(((((//////**,***,*,***,**************,**,..,,,..,,,,,,,*,*****/*****************,,,**********.       
                                                   .*//(///(((/*/((///*////**/*//((##(///*////**********///*****/****,,,***,*/*,*,,*****,****/*,....,,.,,,,,,,,,*********************,,**********       
                                              ,((//(//*/(/**////*/////***,,****,,**,,,*/*,*,,*/***//**,************,*,*****,,,,******,,,,,,*****//*,.....,,,,,,,*,,*,,,,***,**********,*****,,***.      
                                         .*(((((////////*,*/****/****,,,*,,,,,,,,,,**********/**//***,****,,*,,*****,*,,,,,,,,,,,,**,,,,,,,,,************,....,,,,****,,,******************,***,*.      
                                       ,/((((//////**************,,**,,,,,,,,,*,,,,,,**,,****,,*/*,,****,***,***,,****,*,,,,,,,,******,,,,,*****************,,,,,,,,**,***,,,*******,,**,,,*****,.      
                                   ,/(((((//**//******/***************,,,,,,,,,,*,,,,,,,,....,,.,*******,,,,,**,,*******,*,**,,,****,,**,,****,,,,,,**,,,,,,*,,...,,,,,,*,**,**,,,,*******,,,**,.       
                                 */((//*//*///((((((((/////(/***/**//*******,,,,,,,,,,,,,,...........,***,,,,,***,******,,,,**,,****,,,,*,,,*,,,,,*,,,,**,,,,,**...,,,,,,,,,,****,,***,,,,,***,.        
                               ,(//////////////////////////////*****/******/**//****,,,...,,,,...,......,,,,,,,,*****,,***,,,***,***,*,,,,,,,,,,,,,,,,,,*,,,,,,,,,,,,,,,,,,,,,**,,,*****,,,,,,          
                             ,//*/(((///*////(/////////////*///*****/**,,*****,,*,,,*****/*,,*,,,,,,,,......,,,**,,,,,**,,,,,,,,,*,,**,,,,,,,*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.           
                           ,///////((/////*//**/**/***/////*****///*********,,,,,,***,,,,,*,**,*******,,,,,.....,,**,.,*/*,,.,*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.              
                        .***//////(///***//*/*/**//////////(/*******,***,**,,,,,*,,,,,,,,,,,,,,,,,,*,,,,,,,,,,,,,...,,,*,,,,,..,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,                 
                     .,*/*//////////////////*//////////*////**//******,,,,*,,,,,,,,,,,,,,,,,,,,,*,,,,,,,,,,,,,**,,,*****,,..,,,,..,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.                   
                   ,*/////(/(//((/(((((////(///////////////*//******,,,,,,,,*,,,,,,,,,,,,,,*,,,,,,,,,,,,,,,,,,,,,,,**,,*,,,,,.,,,,,...,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.                      
                 ,////((((((((((((/(((////////**//**////*/**********,,,,,,,*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,..,....,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,**,.                         
               ,(((((((((((((((((((((///((***/((((///****/************,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,......,,,,,,,,,,,,,,,,,,,,,,,,,,,**,.                             
             *//(((((((((/////(///*/(///*/////***//***///*****,,,,,,,,,*,,,,,,,,,,,,,,,,,,,,,,,,**,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,...,,,,,,,,,,,,,,,,,,,,,,,.,,**.                                  
           ,(/((#(/((((((/////////******//**/*////**,,*//***//*/,,,,,,,,,*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.,**.                                      
         ./(//((/(//*//****,,,,*,,*//,,/,,**,*****/*,,,,*//*,,,*,//***,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.,,,,,,,,,,,,***.                                          
        .(((((/*///***/*//*//*,,,,**//,,,,,,*,,,,,,,,*,,.,,,,*/*,********,**,,,,,,,,,*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,**.                                              
       ,((((((/*///////////****///**,*/***,,,,,,,,,,,,,*,,,,,,,,,,,*,,*******,,*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.                                                  
      ./((((((((((######(//(//////**/***/***,,,,,,,,,,,,,...,,,,,,,,,,,,,,,*****,,,,,,,,,,,,,,,,,,,,,,,*,,,,,,,,,,,,,,,**,,,,,,,,,,,,,,,,,,,,,,,,.                                                      
      *(((/(##((#((##((((#(**(((((((////*/**/**,*/****,,.,......,,...,,,,,,,,,,**,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.,,**,.                                                         
      */(((##(((((((((((((((((((((((/(((/(///((///*//***,,,,,,,,*,....,....,..,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.,***,.                                                             
      ,/((((#((((((((((((((((((((//((((((((((((((/(//***********,*,,,,,,,,,,,,......,,,,,,,,,,,,,,,,,,,,,,*,,,,,,,,,,,,,,,,,,,,..,**,.                                                                  
      .*/(((((((#((((((((((((((((((//((((//////(///**////*******/******/*****,,,,,..,,,,,,,,,,,,,,******,,,,,,,,,,,,,,,,,,..,***.                                                                       
       .////(((#(((((((((/((////(///(/////////*****/*************************,,,,,,,,,,,,,,,,,,,,,,,,****,,,,,,,,,,,...,*/*.                                                                            
        .,*///((((((((((//////////////////////**//************************,,*,,,,,,,,,,,,,,,,,,,****,***,,,,,,,.,,*//*.                                                                                 
          ,**///*/(//(((/((///(//////**////**//*************************,,**,,,,,,,,,,,,,,,,,,,,*,,,,,,,,,,,*/(/,.                                                                                      
           .,***//////////////**///*//**/**//***********,,*****,********,,,*****,,,,,**,,,,,,,,,,,,,*((((/*.                                                                                            
             .,**///////////////*//***/**/**********,,**,,****,,*************,**,,,,,,,,,,..,*/(((/,..                                                                                                  
               .,*******////*/*///**//**************,*,,,,,,,,,,,,,,,,****,,,,,,,,,,,,*/(((/,.                                                                                                          
                 ,************/**************************,,,,,,,,,,,*,,,,,,,,*/((##(/*..                                                                                                                
                   .,/(#((/**********************,*,,,,,,,,,,,,,,,.,,,/((##(/*,.                                                                                                                        
                       .*(%%%&&%(/**,**,*,,,,,,,,,,,,,,,,,,,,*/(###/*,.                                                                                                                                 
                             .,*(##%%%&&&&&&&&&&%%%%%##(/*,,..                                                                                                                                          

";
		        int consoleBufferWidth = Math.Max(Console.WindowWidth, title.Length);
		        Console.SetBufferSize(consoleBufferWidth, Console.BufferHeight);
		
		        // Imprimir el arte ASCII centrado
		        Console.WriteLine(title);
		        
			}
			
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
				 	Console.WriteLine("\t\t|1_Registrar Cliente:      |\n\t\t|2_Quitar cliente          |\n\t\t|3_Generar Pedido          |\n\t\t|4_Eliminar Pedido         |\n\t\t|5_Registrar Servicio      |\n\t\t|6_Quitar Servicio         |\n\t\t|7_Listado de Cliente      |\n\t\t|8_Listado pedido          |\n\t\t|9_Listado Servicio        |\n\t\t|10_Salir                  |");
				 	Console.WriteLine("\t\t|__________________________|\n");
				 	int opcion =  int.Parse(Console.ReadLine());
				
					if(opcion == 10)
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
						Console.WriteLine ("ingrese el nombre del cliente");
						string nombre= Console.ReadLine();
						Console.WriteLine ("ingrese el apellido del cliente");
						string apellido=Console.ReadLine();
						Console.WriteLine ("ingrese el dni del cliente (en numeros)");
						int dni= int.Parse(Console.ReadLine());
						Console.WriteLine ("ingrese la dirrecion del cliente");
						string dirrection = Console.ReadLine();
						Cliente thisCliente = new Cliente(dni, nombre, apellido, dirrection);
						clientela.Add(thisCliente);
						break;
					case 2://ELIMINAR CLIENTE
						Console.WriteLine ("ingrese el dni del cliente a eliminar( en numeros): ");
						int index= int.Parse(Console.ReadLine());
						clientela.Remove(SelectCliente(index));
						break;
					case 3://CREAR PEDIDO
						ArrayList thisServicios = new ArrayList();
						Console.WriteLine("Que Cliente registra este pedido?( Ingresar el dni del cliente ): ");
						int client = int.Parse(Console.ReadLine()); // Esta variable es el dni de un cliente y se envia como identificador del cliente a elejir
						ListadoServicio();
						Console.WriteLine("cuantos servicios incluira?  (ingrese el numero de servicios): ");
						int serv_cant = int.Parse(Console.ReadLine());
						for(int i = 0; i < serv_cant; i++)
						{
							Console.WriteLine("Que servicio incluira?(ingresar el ID): ");
							int serv_id = int.Parse(Console.ReadLine());
							Servicio retornarSERV = SelectServicio(serv_id);
							thisServicios.Add(retornarSERV);
						}
						Console.WriteLine("Que Fecha se realizara este evento? ( ingresar la fecha en formato **/**/****): ");
						DateTime fecha = DateTime.Parse(Console.ReadLine());
						Console.WriteLine("Cuantos mozos se requeriran?: (ingresar el numero de mozos) ");
						int mozo = int.Parse(Console.ReadLine());
						Console.WriteLine("Cuanto gastara en comida?:(ingresar el monto en numeros) ");
						float gastoComida = float.Parse(Console.ReadLine());
						Console.WriteLine("El Evento contara con manteleria?: (ingresar si o no)  ");
						string condicion = Console.ReadLine();
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
						Console.WriteLine("Cuanto costar en total el evento?: (ingresar el monto en numeros)");
						float costoTotal = float.Parse(Console.ReadLine());
						Console.WriteLine("Con cuanto se Seño este Evento?:(ingresar el monto en numeros) ");
						float seña = float.Parse(Console.ReadLine());
						Pedido ticket = new Pedido(SelectCliente(client), thisServicios, num_pedido, fecha, gastoComida, mozo, habra_manteleria, bebida, costoTotal, seña);
						num_pedido++;
						pedidos.Add(ticket);
						break;
					case 4://QUITAR PEDIDO
						Console.WriteLine ("ingrese el numero de pedido a eliminar: ");
						int numPedido= int.Parse(Console.ReadLine());
						if (numPedido>pedidos.Count) {
							Console.WriteLine("error no existe el Pedido");
							Console.ReadKey(true);
							MenuPrincipalPanaderia();
						}
						pedidos.Remove(SelectPedido(num_pedido));
						break;
					case 5://SERVICIO
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
					case 6://QUITAR SERVICIO
						Console.WriteLine ("ingrese el id del servicio a eliminar:(ingresar el dni de la persona en numeros) ");
						int ident= int.Parse(Console.ReadLine());
						if (ident>servicios.Count) {
						Console.WriteLine("error no existe el servicio");
							Console.ReadKey(true);
							MenuPrincipalPanaderia();
						}
						servicios.Remove(SelectServicio(ident));
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
					if(pd.Manteleria == true)
					{
						manteleria_condicion = "si";
					}
					else
					{
						manteleria_condicion = "no";
					}
					Console.WriteLine("Numero de pedido: {0} \nDni del cliente: {1}\nFecha del evento: {2}\nServicios contratados: {3}\nContara con manteleria? {4}\nCantidad de mozos empleados: {5}\nCantidad de bebidas en stock: {6}\nValor de la seña: {7}\nCosto Total: {8}\nRestante a pagar: {9}\n", pd.NumeroDePedido, pd.CLIENTE.Dni, pd.FechaDelEvento, pd.RetornoServicio(), manteleria_condicion, pd.Mozos, pd.Bebidas, pd.Seña, pd.CostoTotal, pd.Saldo);
				}
			}
			//-------------------------------------------------------------------------------------------
		
			//Retorno-------------------------------------------------------------------------------------
			
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
				Pedido default_pedido = new Pedido(default_cliente, null, 0, default_time, 0, 0, false, 0, 0.0f, 0.0f);
				return default_pedido;
			}
		}
	}
