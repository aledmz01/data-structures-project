using proyectEstructura.Models;
using System.Collections.Generic;

namespace proyectEstructura.Structures
{
    // Implementación de una tabla hash para almacenar palabras
    public class HashPalabras
    {
        // Arreglo de listas que representa la tabla hash
        private List<string>[] tabla;

        // Tamaño total de la tabla hash
        private int tamaño;

        // Constructor de la tabla hash.
        // Inicializa cada posición con una lista vacía
        public HashPalabras()
        {
            tamaño = 10;
            tabla = new List<string>[tamaño];

            for (int i = 0; i < tamaño; i++)
            {
                tabla[i] = new List<string>();
            }
        }

        // Genera el índice hash para una palabra
        // Suma los valores ASCII de cada carácter y aplica módulo
        private int FuncionHash(string palabra)
        {
            int suma = 0;

            foreach (char letra in palabra)
            {
                suma += letra;
            }

            return suma % tamaño;
        }

        // Inserta una palabra en la tabla hash
        // true si la inserción fue exitosa
        // false si la palabra ya existe
        public bool Insertar(string palabra)
        {
            int indice = FuncionHash(palabra);

            if (tabla[indice].Contains(palabra))
            {
                return false;
            }

            tabla[indice].Add(palabra);
            return true;
        }

        // Elimina una palabra de la tabla hash
        // true si la palabra fue eliminada
        // false si no existe
        public bool Eliminar(string palabra)
        {
            int indice = FuncionHash(palabra);

            return tabla[indice].Remove(palabra);
        }

        // Obtiene todas las palabras almacenadas
        public List<string> ObtenerTodas()
        {
            List<string> resultado = new List<string>();

            foreach (var lista in tabla)
            {
                resultado.AddRange(lista);
            }

            return resultado;
        }

        // Obtiene todos los registros de la tabla hash
        // mostrando el índice donde están almacenados
        public List<RegistroHash> ObtenerRegistros()
        {
            List<RegistroHash> registros = new List<RegistroHash>();

            for (int i = 0; i < tamaño; i++)
            {
                foreach (string palabra in tabla[i])
                {
                    registros.Add(new RegistroHash
                    {
                        Indice = i,
                        Palabra = palabra
                    });
                }
            }

            return registros;
        }
    }
}