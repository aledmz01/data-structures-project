using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectEstructura.Models
{
    public class NodoTrie
    {
        // Diccionario para los nodos hijos (carácter -> Nodo)
        public Dictionary<char, NodoTrie> Hijo { get; set; }

        // Indica si aquí termina una palabra válida
        public bool EsFinPalabra { get; set; }

        // Frecuencia o peso de la palabra para el ranking del IDE
        public int Frecuencia { get; set; }

        public NodoTrie()
        {
            Hijo = new Dictionary<char, NodoTrie>();
            EsFinPalabra = false;
            Frecuencia = 0;
        }
    }
}
