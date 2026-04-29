using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T1
{
    internal class ListaVideojuegos
    {
        public Nodo cabeza;

        public ListaVideojuegos()
        {
            cabeza = null;
        }
        public ListaVideojuegos(int cantidadVideojuegos)
        {
            cabeza = null;
            if (cantidadVideojuegos >= 1) { AgregarAlFinal(new Producto("God of War Ragnarök", "Acción", 2022, 36, 190.0)); }
            if (cantidadVideojuegos >= 2) { AgregarAlFinal(new Producto("Red Dead Redemption 2", "Aventura", 2018, 57, 100.0)); }
            if (cantidadVideojuegos >= 3) { AgregarAlFinal(new Producto("Super Mario Bros. Wonder", "Plataformas", 2023, 120, 185.0)); }
            if (cantidadVideojuegos >= 4) { AgregarAlFinal(new Producto("The Legend of Zelda: TotK", "Aventura", 2023, 50, 215.0)); }
            if (cantidadVideojuegos >= 5) { AgregarAlFinal(new Producto("Cyberpunk 2077", "Rol (RPG)", 2020, 101, 130.0)); }
            if (cantidadVideojuegos >= 6) { AgregarAlFinal(new Producto("Street Fighter 6", "Lucha (Fighting)", 2023, 150, 160.0)); }
            if (cantidadVideojuegos >= 7) { AgregarAlFinal(new Producto("Forza Horizon 5", "Carreras", 2021, 20, 160.0)); }
            if (cantidadVideojuegos >= 8) { AgregarAlFinal(new Producto("Helldivers 2", "Disparos (Shooter)", 2024, 10, 160.0)); }
            if (cantidadVideojuegos >= 9) { AgregarAlFinal(new Producto("Hollow Knight", "Plataformas", 2017, 190, 50.0)); }
            if (cantidadVideojuegos >= 10) { AgregarAlFinal(new Producto("Silent Hill 2 (Remake)", "Terror (Horror)", 2024, 132, 250.0)); }
        }
        //Agrega un videojuego al inicio de la lista
        public void AgregarAlInicio(Producto dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (EstaVacia())
            {
                cabeza = nuevoNodo;
                return;
            }
            nuevoNodo.Siguiente = cabeza;
            cabeza = nuevoNodo;
        }
        //Agrega un videojuego al final de la lista
        public void AgregarAlFinal(Producto dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (EstaVacia())
            {
                cabeza = nuevoNodo;
                return;
            }
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
        //Elimina un  videojuego de la lista según su título
        public void EliminarPorTitulo(string titulo)
        {
            if (EstaVacia())
            {
                MessageBox.Show("La lista está vacía.",
                    "Proceso no completado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cabeza.Dato.Titulo == titulo)
            {
                cabeza = cabeza.Siguiente;
                return;
            }
            Nodo anterior = cabeza;
            Nodo actual = cabeza.Siguiente;
            while (actual != null)
            {
                if (actual.Dato.Titulo == titulo)
                {
                    anterior.Siguiente = actual.Siguiente;
                    return;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
            MessageBox.Show("Título no encontrado en la lista.",
                    "Proceso no completado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Muestra los videojuegos de la lista en un DataGridView
        public void Imprimir(DataGridView dgv)
        {
            dgv.Rows.Clear();
            Nodo actual = cabeza;
            while (actual != null)
            {
                dgv.Rows.Add(actual.Dato.Titulo,
                             actual.Dato.Genero,
                             actual.Dato.AñoDeLanzamiento,
                             actual.Dato.Stock,
                             actual.Dato.Precio);
                actual = actual.Siguiente;
            }
        }//Verifica si la lista esta vacía
        public bool EstaVacia()
        {
            return cabeza == null;
        }
        //Verifica si el nuevo título registrado se encuentra en alguna de las dos listas y evita duplicarlo
        public bool Duplicado(string titulo)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Titulo.ToLower() == titulo.ToLower()) return true;
                actual = actual.Siguiente;
            }
            return false;
        }
    }
}
