using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrador_T1
{
    internal class Grupo8
    {
        Nodo cabeza= null;
        public void ContarVideojuegos(ListaVideojuegos L)
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
        }
        public void SonIguales(ListaVideojuegos L1, ListaVideojuegos L2)
        {
            
        }
        public void ConcatenarListas(ListaVideojuegos L1, ListaVideojuegos L2)
        {

        }
        public void InvertirLista(ListaVideojuegos L)
        {

        }
        public void OrdenarPorPrecio(ListaVideojuegos L, string tipo)
        {

        }
        public void FiltrarPorGenero(ListaVideojuegos L, string genero)
        {

        }
        public void RestarCatalogos(ListaVideojuegos L1, ListaVideojuegos L2)
        {

        }
        public void EstadisticaPrecio(ListaVideojuegos L)
        {

        }
    }
}
