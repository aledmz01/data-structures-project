using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectEstructura.Structures
{
    // Clase estatic que permite compartir
    // la misma tabla hash entre forms
    public static class HashGlobal
    {
        public static HashPalabras TablaHash = new HashPalabras();
    }
}
