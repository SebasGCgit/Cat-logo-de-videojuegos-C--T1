using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace T1
{
    internal static class Grupo8
    {
        //Cuenta la cantidad de videojuegos de la lista seleccionada
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
        //Compara las dos listas y verifica si son exactamente iguales
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
        //Concatena el ultimo nodo de L1 con el primer nodo de L2 dando una nueva lista
        public static ListaVideojuegos ConcatenarListas(ListaVideojuegos L1, ListaVideojuegos L2)
        {
            if (L1.cabeza == null || L2.cabeza == null)
            {
                MessageBox.Show("Lista 1 o 2 vacía",
                    "Impedimento del proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            ListaVideojuegos nueva = new ListaVideojuegos();
            Nodo actual1 = L1.cabeza;
            while (actual1 != null)
            {
                nueva.AgregarAlFinal(actual1.Dato);
                actual1 = actual1.Siguiente;
            }

            Nodo actual2 = L2.cabeza;
            while (actual2 != null)
            {
                nueva.AgregarAlFinal(actual2.Dato);
                actual2 = actual2.Siguiente;
            }

            return nueva;
        }
        //Invierte el orden de los elementos de la lista seleccionada
        public static ListaVideojuegos InvertirLista(ListaVideojuegos L)
        {
            ListaVideojuegos nueva = new ListaVideojuegos();
            Nodo actual = L.cabeza;

            while (actual != null)
            {
                nueva.AgregarAlInicio(actual.Dato);
                actual = actual.Siguiente;
            }
            return nueva;
        }
        //Ordena (en forma ascendente o descendente) la lista de acuerdo al precio
        public static void OrdenarPorPrecio(ListaVideojuegos L, string tipo)
        {
            switch(tipo)
            {
                case "1":
                    if (L.cabeza == null) return;
                    bool hayIntercambio1;
                    do
                    {
                        hayIntercambio1 = false;
                        Nodo actual = L.cabeza;

                        while (actual.Siguiente != null)
                        {
                            if (actual.Dato.Precio > actual.Siguiente.Dato.Precio)
                            {
                                Producto temp = actual.Dato;
                                actual.Dato = actual.Siguiente.Dato;
                                actual.Siguiente.Dato = temp;
                                hayIntercambio1 = true;
                            }
                            actual = actual.Siguiente;
                        }
                    } while (hayIntercambio1);
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
        //Filtra los videojuegos de la lista seleccionada según el genéro elegido
        public static ListaVideojuegos FiltrarPorGenero(ListaVideojuegos L, string genero)
        {
            ListaVideojuegos nueva = new ListaVideojuegos();

            Nodo actual = L.cabeza;
            while (actual != null)
            {
                if (actual.Dato.Genero.ToLower().Contains(genero.ToLower()))
                    nueva.AgregarAlFinal(actual.Dato);
                actual = actual.Siguiente;
            }

            return nueva;
        }
        //Retorna una nueva lista con los videojuegos de L1 cuyo título no aparezca en L2
        public static ListaVideojuegos RestarCatalogos(ListaVideojuegos L1, ListaVideojuegos L2)
        {
            ListaVideojuegos nueva = new ListaVideojuegos();

            Nodo actual = L1.cabeza;

            while (actual != null)
            {
                bool existe = false;

                Nodo actual2 = L2.cabeza;

                while (actual2 != null)
                {
                    if (actual.Dato.Titulo.ToLower() == actual2.Dato.Titulo.ToLower())
                    {
                        existe = true;
                        break;
                    }
                    actual2 = actual2.Siguiente;
                }

                if (!existe)
                {
                    nueva.AgregarAlFinal(actual.Dato);
                }
                actual = actual.Siguiente;
            }
            return nueva;
        }
        //Calcula y muestra en consola: precio mínimo, precio máximo y promedio de precios de todos los videojuegos de la lista seleccionada
        public static void EstadisticaPrecio(ListaVideojuegos L)
        {
            if (L.cabeza == null)
            {
                MessageBox.Show("Lista vacía",
                    "Impedimento del proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Nodo actual = L.cabeza;

            double min = actual.Dato.Precio;
            double max = actual.Dato.Precio;
            double suma = 0;
            double contador = 0;

            while (actual != null)
            {
                double precio = actual.Dato.Precio;

                if (precio < min) min = precio;
                if (precio > max) max = precio;

                suma += precio;
                contador++;

                actual = actual.Siguiente;
            }

            double promedio = (double)suma / contador;

            MessageBox.Show(
                "Precio mínimo: " + min +
                "\nPrecio máximo: " + max +
                "\nPromedio: " + promedio,
                "Estadísticas:", MessageBoxButtons.OK);
        }
    }
}
