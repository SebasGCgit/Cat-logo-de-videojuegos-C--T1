using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrador_T1
{
    internal static class Grupo8
    {
        public static int ContarVideojuegos(ListaVideojuegos L)
        {
            int conteo = 0;
            Nodo actual = L.cabeza;
            while(actual != null)
            {
                conteo++;
                actual = actual.Siguiente;
            }
            return conteo;
        }
        public static bool SonIguales(ListaVideojuegos L1, ListaVideojuegos L2)
        {
            Nodo actual1 = L1.cabeza;
            Nodo actual2 = L2.cabeza;
            while (actual1 != null && actual2 != null)
            {
                if (actual1.Dato.Titulo != actual2.Dato.Titulo || actual1.Dato.Genero != actual2.Dato.Genero || 
                    actual1.Dato.AñoDeLanzamiento != actual2.Dato.AñoDeLanzamiento || actual1.Dato.Stock != actual2.Dato.Stock ||
                    actual1.Dato.Precio != actual2.Dato.Precio)
                {
                    return false;
                }
                actual1 = actual1.Siguiente;
                actual2 = actual2.Siguiente;
            }
            if (actual1!= null||actual2!=null)
            {
                return false;
            }
            return true;
        }
        public static void ConcatenarListas(ListaVideojuegos L1, ListaVideojuegos L2) //LO ENTREGA ADRIAN
        {

        }
        public static void InvertirLista(ListaVideojuegos L) //LO ENTREGA JP
        {

        }
        public static void OrdenarPorPrecio(ListaVideojuegos L, string tipo) //LO ENTREGA HANS
        {
            switch(tipo)
            {
                case "1":
                    if (L.cabeza == null) return;  // Lista vacia: nada que ordenar
                    bool hayIntercambio1;
                    do
                    {
                        hayIntercambio1 = false;
                        Nodo actual = L.cabeza;

                        while (actual.Siguiente != null)
                        {
                            // Si el nodo actual tiene mayor precio que el siguiente: intercambiar
                            if (actual.Dato.Precio > actual.Siguiente.Dato.Precio)
                            {
                                // Swap: se intercambia el Dato, no los punteros
                                Producto temp = actual.Dato;
                                actual.Dato = actual.Siguiente.Dato;
                                actual.Siguiente.Dato = temp;
                                hayIntercambio1 = true;
                            }
                            actual = actual.Siguiente;
                        }
                    } while (hayIntercambio1);  // Repite hasta que no haya intercambios
                    break;
                case "2":
                    if (L.cabeza == null) return;
                    bool hayIntercambio2;
                    do
                    {
                        hayIntercambio2 = false;
                        Nodo actual = L.cabeza;

                        while (actual.Siguiente != null)
                        {
                            if (actual.Dato.Precio < actual.Siguiente.Dato.Precio)
                            {
                                Producto temp = actual.Dato;
                                actual.Dato = actual.Siguiente.Dato;
                                actual.Siguiente.Dato = temp;
                                hayIntercambio2 = true;
                            }
                            actual = actual.Siguiente;
                        }
                    } while (hayIntercambio2);
                    break;
            }
        }
        public static void FiltrarPorGenero(ListaVideojuegos L, string genero) //LO ENTREGA ADRIAN
        {

        }
        public static void RestarCatalogos(ListaVideojuegos L1, ListaVideojuegos L2) //LO ENTREGA JP
        {

        }
        public static void EstadisticaPrecio(ListaVideojuegos L) //LO ENTREGA FELIX
        {

        }
    }
}
