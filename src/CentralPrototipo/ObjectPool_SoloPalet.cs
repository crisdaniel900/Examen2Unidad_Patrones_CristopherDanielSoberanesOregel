using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeAbastosConPallets
{

    // Clase pallet

    public class Pallet
    {
        public string Nombre { get; private set; }
        public bool Ocupado { get; private set; }

        public Pallet(string nombre)
        {
            Nombre = nombre;
            Ocupado = false;
        }

        public void Cargar(string contenido)
        {
            Ocupado = true;
            Console.WriteLine($" {Nombre} está transportando {contenido}...");
        }

        public void Vaciar()
        {
            Ocupado = false;
            Console.WriteLine($" {Nombre} ha sido vaciado y está libre.");
        }
    }
}
