using CentralDeAbastosConPallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeAbastosConPallets
{
    public class PoolPallets
    {
        private readonly Stack<Pallet> palletsDisponibles = new Stack<Pallet>();
        private readonly List<Pallet> todosLosPallets = new List<Pallet>();
        private const int MAX_PALLETS = 3;

        public PoolPallets()
        {
            for (int i = 1; i <= MAX_PALLETS; i++)
            {
                Pallet nuevo = new Pallet($"Pallet-{i}");
                palletsDisponibles.Push(nuevo);
                todosLosPallets.Add(nuevo);
            }
            Console.WriteLine($" Pool inicializado con {MAX_PALLETS} pallets fijos.\n");
        }

        public Pallet AsignarPallet(string contenido)
        {
            if (palletsDisponibles.Count > 0)
            {
                Pallet p = palletsDisponibles.Pop();
                p.Cargar(contenido); // Usamos Cargar()
                Console.WriteLine($" Pallets disponibles: {palletsDisponibles.Count}\n");
                return p;
            }
            else
            {
                Console.WriteLine(" No hay pallets disponibles en el pool.\n");
                return null;
            }
        }

        public void LiberarPallet(Pallet p)
        {
            if (p == null) return;

            if (!todosLosPallets.Contains(p))
            {
                Console.WriteLine(" Ese pallet no pertenece al pool.\n");
                return;
            }

            if (palletsDisponibles.Count < MAX_PALLETS)
            {
                p.Vaciar();
                palletsDisponibles.Push(p);
                Console.WriteLine($" Pallets disponibles: {palletsDisponibles.Count}\n");
            }
            else
            {
                Console.WriteLine(" El pool ya está completo, no se puede devolver este pallet.\n");
            }
        }

        public void MostrarEstado()
        {
            Console.WriteLine($" Pallets disponibles actualmente: {palletsDisponibles.Count}\n");
        }
    }
}
