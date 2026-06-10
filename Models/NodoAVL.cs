using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectEstructura.Models
{
    public class NodoAVL
    {
        public string Palabra;

        public NodoAVL Izquierdo;
        public NodoAVL Derecho;

        public int Altura;

        public NodoAVL(string palabra)
        {
            Palabra = palabra;
            Altura = 1;
        }
    }
}
