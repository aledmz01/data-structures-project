using proyectEstructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace proyectEstructura.Structures
{
    internal class Trie
    {
        private NodoTrie _root;

        public Trie()
        {
            _root = new NodoTrie();
        }

        /// <summary>
        /// Inserta una palabra en el Trie con una frecuencia inicial.
        /// </summary>
        public void agregar(string word, int frequency = 1)
        {
            if (string.IsNullOrEmpty(word)) return;

            NodoTrie nodoActual = _root;
            foreach (char ch in word)
            {
                if (!nodoActual.Children.ContainsKey(ch))
                {
                    nodoActual.Children[ch] = new NodoTrie();
                }
                nodoActual = nodoActual.Children[ch];
            }

            nodoActual.IsEndOfWord = true;
            // Si la palabra ya existe, sumamos la frecuencia (ej: la variable se usa mucho)
            nodoActual.Frequency += frequency;
        }

        public void Clear()
        {
            _root = new NodoTrie(); // La raíz vieja queda huérfana y el GC la destruye
        }

        /// <summary>
        /// Devuelve las sugerencias de autocompletado ordenadas por relevancia.
        /// </summary>
        public List<string> Autocompletar(string prefijo)
        {
            if (string.IsNullOrEmpty(prefijo)) return new List<string>();

            NodoTrie current = _root;

            // Navegar hasta el nodo donde termina el prefijo escrito
            foreach (char ch in prefijo)
            {
                if (!current.Children.ContainsKey(ch))
                {
                    return new List<string>(); // No hay coincidencias
                }
                current = current.Children[ch];
            }

            // Recolectar todas las palabras que parten de ese prefijo
            List<(string Word, int Freq)> results = new List<(string, int)>();
            CollectWords(current, prefijo, results);

            // Ordenar por frecuencia descendentemente usando LINQ
            return results
                .OrderByDescending(r => r.Freq)
                .Select(r => r.Word)
                .ToList();
        }

        // Método auxiliar DFS (Deepth-First Search) para recorrer el árbol
        private void CollectWords(NodoTrie node, string currentPrefix, List<(string, int)> results)
        {
            if (node.IsEndOfWord)
            {
                results.Add((currentPrefix, node.Frequency));
            }

            foreach (var child in node.Children)
            {
                // child.Key es el carácter, child.Value es el nodo hijo
                CollectWords(child.Value, currentPrefix + child.Key, results);
            }
        }
    }
}
