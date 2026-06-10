using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyectEstructura.Models;

namespace proyectEstructura.Structures
{
    public class AVLPalabras
    {
        private NodoAVL raiz;


        //Inserción al AVL
        public void Insertar(string palabra)
        {
            raiz = InsertarRec(raiz, palabra);
        }

        private NodoAVL InsertarRec(NodoAVL nodo, string palabra)
        {
            if (nodo == null)
                return new NodoAVL(palabra);

            int comparacion = string.Compare(
                palabra,
                nodo.Palabra,
                StringComparison.OrdinalIgnoreCase);

            if (comparacion < 0)
            {
                nodo.Izquierdo = InsertarRec(nodo.Izquierdo, palabra);
            }
            else if (comparacion > 0)
            {
                nodo.Derecho = InsertarRec(nodo.Derecho, palabra);
            }
            else
            {
                return nodo; //No duplicados
            }

            nodo.Altura = 1 + Math.Max(
                Altura(nodo.Izquierdo),
                Altura(nodo.Derecho));

            int balance = Balance(nodo);

            //Caso Izquierda-Izquierda
            if (balance > 1 &&
                string.Compare(palabra, nodo.Izquierdo.Palabra,
                StringComparison.OrdinalIgnoreCase) < 0)
            {
                return RotarDerecha(nodo);
            }

            //Caso Derecha-Derecha
            if (balance < -1 &&
                string.Compare(palabra, nodo.Derecho.Palabra,
                StringComparison.OrdinalIgnoreCase) > 0)
            {
                return RotarIzquierda(nodo);
            }

            //Caso Izquierda-Derecha
            if (balance > 1 &&
                string.Compare(palabra, nodo.Izquierdo.Palabra,
                StringComparison.OrdinalIgnoreCase) > 0)
            {
                nodo.Izquierdo = RotarIzquierda(nodo.Izquierdo);
                return RotarDerecha(nodo);
            }

            //Caso Derecha-Izquierda
            if (balance < -1 &&
                string.Compare(palabra, nodo.Derecho.Palabra,
                StringComparison.OrdinalIgnoreCase) < 0)
            {
                nodo.Derecho = RotarDerecha(nodo.Derecho);
                return RotarIzquierda(nodo);
            }

            return nodo;
        }


        //Metodo busqueda del AVL
        public bool Buscar(string palabra)
        {
            return BuscarRec(raiz, palabra);
        }

        private bool BuscarRec(NodoAVL nodo, string palabra)
        {
            if (nodo == null)
                return false;

            int comparacion = string.Compare(
                palabra,
                nodo.Palabra,
                StringComparison.OrdinalIgnoreCase);

            if (comparacion == 0)
                return true;

            if (comparacion < 0)
                return BuscarRec(nodo.Izquierdo, palabra);

            return BuscarRec(nodo.Derecho, palabra);
        }

        //Metodo eliminar del AVL
        public void Eliminar(string palabra)
        {
            raiz = EliminarRec(raiz, palabra);
        }

        private NodoAVL EliminarRec(NodoAVL nodo, string palabra)
        {
            if (nodo == null)
                return null;

            int comparacion = string.Compare(
                palabra,
                nodo.Palabra,
                StringComparison.OrdinalIgnoreCase);

            if (comparacion < 0)
            {
                nodo.Izquierdo = EliminarRec(nodo.Izquierdo, palabra);
            }
            else if (comparacion > 0)
            {
                nodo.Derecho = EliminarRec(nodo.Derecho, palabra);
            }
            else
            {
                if (nodo.Izquierdo == null)
                    return nodo.Derecho;

                if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                NodoAVL sucesor = ObtenerMinimo(nodo.Derecho);

                nodo.Palabra = sucesor.Palabra;

                nodo.Derecho = EliminarRec(
                    nodo.Derecho,
                    sucesor.Palabra);
            }

            nodo.Altura = 1 + Math.Max(
                Altura(nodo.Izquierdo),
                Altura(nodo.Derecho));

            int balance = Balance(nodo);

            //Caso izquierda-Izquierda
            if (balance > 1 &&
                Balance(nodo.Izquierdo) >= 0)
            {
                return RotarDerecha(nodo);
            }

            //Caso izquierda-Derecha
            if (balance > 1 &&
                Balance(nodo.Izquierdo) < 0)
            {
                nodo.Izquierdo = RotarIzquierda(nodo.Izquierdo);
                return RotarDerecha(nodo);
            }

            //Caso derecha-Derecha
            if (balance < -1 &&
                Balance(nodo.Derecho) <= 0)
            {
                return RotarIzquierda(nodo);
            }

            //Caso derecha-Izquierda
            if (balance < -1 &&
                Balance(nodo.Derecho) > 0)
            {
                nodo.Derecho = RotarDerecha(nodo.Derecho);
                return RotarIzquierda(nodo);
            }

            return nodo;
        }

        private NodoAVL ObtenerMinimo(NodoAVL nodo)
        {
            while (nodo.Izquierdo != null)
            {
                nodo = nodo.Izquierdo;
            }

            return nodo;
        }


        //Metodo para obtener las palabras y luego realizar un recorrido In-order
        public List<string> ObtenerPalabras()
        {
            List<string> lista = new List<string>();

            InOrder(raiz, lista);

            return lista;
        }
        //recorrido In-order
        private void InOrder(NodoAVL nodo, List<string> lista)
        {
            if (nodo == null)
                return;

            InOrder(nodo.Izquierdo, lista);

            lista.Add(nodo.Palabra);

            InOrder(nodo.Derecho, lista);
        }


        //Metodos para el calculo y rotación del arbol

        //Obtener que tan profundo es un nodo
        private int Altura(NodoAVL nodo)
        {
            return nodo == null ? 0 : nodo.Altura;
        }
        //Medir si el arbol esta inclinado hacia un lado
        private int Balance(NodoAVL nodo)
        {
            if (nodo == null)
                return 0;

            return Altura(nodo.Izquierdo)
                   - Altura(nodo.Derecho);
        }
        //Corregir si el arbol tiene mas valores a la izquierda
        private NodoAVL RotarDerecha(NodoAVL y)
        {
            NodoAVL x = y.Izquierdo;
            NodoAVL t2 = x.Derecho;

            x.Derecho = y;
            y.Izquierdo = t2;

            y.Altura = Math.Max(
                Altura(y.Izquierdo),
                Altura(y.Derecho)) + 1;

            x.Altura = Math.Max(
                Altura(x.Izquierdo),
                Altura(x.Derecho)) + 1;

            return x;
        }

        //Corregir si el arbol tiene mas valores a la derecha
        private NodoAVL RotarIzquierda(NodoAVL x)
        {
            NodoAVL y = x.Derecho;
            NodoAVL t2 = y.Izquierdo;

            y.Izquierdo = x;
            x.Derecho = t2;

            x.Altura = Math.Max(
                Altura(x.Izquierdo),
                Altura(x.Derecho)) + 1;

            y.Altura = Math.Max(
                Altura(y.Izquierdo),
                Altura(y.Derecho)) + 1;

            return y;
        }
    }
}
