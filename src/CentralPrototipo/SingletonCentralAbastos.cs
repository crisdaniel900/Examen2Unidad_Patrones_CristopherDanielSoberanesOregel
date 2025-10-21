using CentralDeAbastosConPallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PATRÓN SINGLETON: CENTRAL DE ABASTOS (que luego se me olvida que show)

namespace CentralDeAbastosConPallets
{
    public class CentralDeAbastos
    {
        private static CentralDeAbastos _instance;
        private static readonly object _lock = new object();

        private readonly PoolPallets pool;

        // Inventario de productos
        private readonly Dictionary<string, int> inventario;

        private CentralDeAbastos()
        {
            Console.WriteLine(" Central de abastos, que va a querer WERITO...\n");
            pool = new PoolPallets(); // inicializa el pool aquí

            // Inicializar inventario con 10 unidades de cada producto
            inventario = new Dictionary<string, int>
            {
                { "Manzanas", 10 },
                { "Bananas", 10 },
                { "Naranjas", 10 },
                { "Uvas", 10 },
            };
        }

        public static CentralDeAbastos Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new CentralDeAbastos();
                    }
                }
                return _instance;
            }
        }

        // Método para procesar un pedido
        public Pallet ProcesarPedido(string producto)
        {
            //Verificamso si exite 
            if (!inventario.ContainsKey(producto))
            {
                Console.WriteLine($" El producto {producto} no existe en el inventario.");
                return null;
            }
            //Tambien que no sea 0
            if (inventario[producto] <= 0)
            {
                Console.WriteLine($" Lo sentimos, {producto} está agotado.");
                return null;
            }

            // Disminuir cantidad
            inventario[producto]--;
            Console.WriteLine($" Pedido recibido: {producto}. Cantidad restante: {inventario[producto]}");

            // Asignar pallet
            return pool.AsignarPallet(producto);
        }

        public void LiberarPallet(Pallet p)
        {
            pool.LiberarPallet(p);
        }

        // Método para mostrar cuántos pallets están disponibles
        public void MostrarEstadoPool()
        {
            pool.MostrarEstado();
        }

        // Método opcional para mostrar inventario
        public void MostrarInventario()
        {
            Console.WriteLine("Inventario actual:");
            foreach (var item in inventario)
            {
                Console.WriteLine($" {item.Key}: {item.Value}");
            }
            Console.WriteLine();
        }
    }
}
