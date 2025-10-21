using System;
using System.Collections.Generic;

namespace CentralDeAbastosConPallets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Central de Abastos - Singleton + Object Pool";

            // Instancias que realmente apuntan al mismo singleton
            CentralDeAbastos pedido1 = CentralDeAbastos.Instance;
            CentralDeAbastos pedido2 = CentralDeAbastos.Instance;
            CentralDeAbastos pedido3 = CentralDeAbastos.Instance;

            // Instancia actual que se usará para procesar pedidos
            CentralDeAbastos pedidoActual = pedido1;

            Console.WriteLine(" COMPROBACIÓN DEL PATRÓN SINGLETON:");
            bool singletonCorrecto = ReferenceEquals(pedido1, pedido2) &&
                                     ReferenceEquals(pedido2, pedido3);
            Console.WriteLine($"¿Lleva singleton profe? {singletonCorrecto}\n");

            // Menú
            Console.WriteLine("PEDIDOS ENTRANTES A LA CENTRAL DE ABASTOS\n" +
                              "1. Manzanas\n" +
                              "2. Bananas\n" +
                              "3. Naranjas\n" +
                              "4. Uvas\n" +
                              "5. Liberar un pallet\n" +
                              "6. Mostrar estado del pool\n" +
                              "7. Cambiar de pedido (pedido1, pedido2, pedido3)\n" +
                              "X. Salir\n");

            List<Pallet> palletsEnUso = new List<Pallet>();
            string opcion;

            do
            {
                Console.Write("\nSeleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion.ToLower())
                {
                    case "1":
                        palletsEnUso.Add(pedidoActual.ProcesarPedido("Manzanas"));
                        break;
                    case "2":
                        palletsEnUso.Add(pedidoActual.ProcesarPedido("Bananas"));
                        break;
                    case "3":
                        palletsEnUso.Add(pedidoActual.ProcesarPedido("Naranjas"));
                        break;
                    case "4":
                        palletsEnUso.Add(pedidoActual.ProcesarPedido("Uvas"));
                        break;
                    case "5":
                        if (palletsEnUso.Count > 0)
                        {
                            Pallet p = palletsEnUso[0];
                            palletsEnUso.RemoveAt(0);
                            pedidoActual.LiberarPallet(p);
                        }
                        else
                        {
                            Console.WriteLine(" No hay pallets en uso para liberar.");
                        }
                        break;
                    case "6":
                        pedidoActual.MostrarEstadoPool();
                        break;
                    case "7":
                        Console.WriteLine("Seleccione el pedido a usar (1, 2 o 3):");
                        string seleccion = Console.ReadLine();
                        switch (seleccion)
                        {
                            case "1":
                                pedidoActual = pedido1;
                                break;
                            case "2":
                                pedidoActual = pedido2;
                                break;
                            case "3":
                                pedidoActual = pedido3;
                                break;
                            default:
                                Console.WriteLine(" Opción inválida. Se mantiene el pedido actual.");
                                break;
                        }
                        Console.WriteLine("Pedido cambiado correctamente.");
                        break;
                    case "x":
                        Console.WriteLine("\n Cerrando pedidos...");
                        break;
                    default:
                        Console.WriteLine(" Opción no válida.");
                        break;
                }

            } while (opcion.ToLower() != "x");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
