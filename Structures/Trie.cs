using proyectEstructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace proyectEstructura.Structures
{
    internal class Trie
    {
        private NodoTrie nodo;

        public Trie()
        {
            nodo = new NodoTrie();
        }

        /// <summary>
        /// Inserta una palabra en el Trie con una frecuencia inicial.
        /// </summary>
        public void agregar(string palabra, int frequencia = 1)
        {
            if (string.IsNullOrEmpty(palabra)) return;

            NodoTrie nodoActual = nodo;
            foreach (char ch in palabra)
            {
                if (!nodoActual.Hijo.ContainsKey(ch))
                {
                    nodoActual.Hijo[ch] = new NodoTrie();
                }
                nodoActual = nodoActual.Hijo[ch];
            }

            nodoActual.EsFinPalabra = true;
            // Si la palabra ya existe, sumamos la frecuencia (ej: la variable se usa mucho)
            nodoActual.Frecuencia += frequencia;
        }

        public void limpiar()
        {
            nodo = new NodoTrie(); // La raíz vieja queda huérfana y el GC la destruye
        }

        /// <summary>
        /// Devuelve las sugerencias de autocompletado ordenadas por relevancia.
        /// </summary>
        public List<string> autocompletar(string prefijo)
        {
            if (string.IsNullOrEmpty(prefijo)) return new List<string>();

            NodoTrie current = nodo;

            // Navegar hasta el nodo donde termina el prefijo escrito
            foreach (char ch in prefijo)
            {
                if (!current.Hijo.ContainsKey(ch))
                {
                    return new List<string>(); // No hay coincidencias
                }
                current = current.Hijo[ch];
            }

            // Recolectar todas las palabras que parten de ese prefijo
            List<(string Word, int Freq)> results = new List<(string, int)>();
            colectarPalabra(current, prefijo, results);

            // Ordenar por frecuencia descendentemente usando LINQ
            return results
                .OrderByDescending(r => r.Freq)
                .Select(r => r.Word)
                .ToList();
        }

        // Método auxiliar DFS (Deepth-First Search) para recorrer el árbol
        private void colectarPalabra(NodoTrie nodo, string prefijoActual, List<(string, int)> resultados)
        {
            if (nodo.EsFinPalabra)
            {
                resultados.Add((prefijoActual, nodo.Frecuencia));
            }

            foreach (var child in nodo.Hijo)
            {
                // child.Key es el carácter, child.Value es el nodo hijo
                colectarPalabra(child.Value, prefijoActual + child.Key, resultados);
            }
        }
    }
}
