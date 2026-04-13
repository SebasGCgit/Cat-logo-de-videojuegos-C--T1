using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrador_T1
{
    internal class ListaVideojuegos
    {
        ListaVideojuegos lista = new ListaVideojuegos();
        ListaVideojuegos lista1 = new ListaVideojuegos();
        ListaVideojuegos lista2 = new ListaVideojuegos();

        public Nodo cabeza;

        public void AgregarAlInicio()
        {

        }
        public void AgregarAlFinal(int dato)
        {
            
        }
        public Nodo EliminarPorTitulo(int dato)
        {
            return cabeza;
        }
        public void Imprimir()
        {
            
        }
        public bool EstaVacia()
        {
            return cabeza == null;
        }
    }
}
