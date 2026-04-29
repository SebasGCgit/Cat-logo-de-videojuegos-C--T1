using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal class Producto
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int AñoDeLanzamiento { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }

        public Producto(string titulo, string genero, int año_lanzamiento, int stock, double precio)
        {
            Titulo = titulo;
            Genero = genero;
            AñoDeLanzamiento = año_lanzamiento;
            Stock = stock;
            Precio = precio;
        }
    }
}
