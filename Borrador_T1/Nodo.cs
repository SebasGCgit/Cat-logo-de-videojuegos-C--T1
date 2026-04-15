using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrador_T1
{
    internal class Nodo
    {
        //Encapsulamiento
        public Producto Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Producto dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}
