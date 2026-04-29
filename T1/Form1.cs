using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T1
{
    public partial class Form1 : Form
    {
        //Instancias de las dos listas enlazadas
        private ListaVideojuegos lista1 = new ListaVideojuegos();
        private ListaVideojuegos lista2 = new ListaVideojuegos();

        public Form1()
        {
            InitializeComponent();
        }
        private void btnAgregarInicio1_Click(object sender, EventArgs e)
        {
            if (lista1.Duplicado(txtTitulo.Text.Trim()))
            {
                MessageBox.Show("Este título ya se encuentra en la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return;
            }
            if (!ValidarEntradaAtributos(out string titulo, out string genero, out int año_de_lanzamiento, out int stock, out double precio)) return;
            lista1.AgregarAlInicio(new Producto(titulo,genero,año_de_lanzamiento,stock,precio));
            lista1.Imprimir(dgvLista1);
            LimpiarEntradas();
        }
        private void btnAgregarFinal1_Click(object sender, EventArgs e)
        {
            if (lista1.Duplicado(txtTitulo.Text.Trim()))
            {
                MessageBox.Show("Este título ya se encuentra en la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return;
            }
            if (!ValidarEntradaAtributos(out string titulo, out string genero, out int año_de_lanzamiento, out int stock, out double precio)) return;
            lista1.AgregarAlFinal(new Producto(titulo, genero, año_de_lanzamiento, stock, precio));
            lista1.Imprimir(dgvLista1);
            LimpiarEntradas();
        }
        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            lista1.EliminarPorTitulo(txtTitulo.Text.Trim());
            lista1.Imprimir(dgvLista1);
            txtTitulo.Focus();
        }
        private void btnAgregarInicio2_Click(object sender, EventArgs e)
        {
            if (lista2.Duplicado(txtTitulo.Text.Trim()))
            {
                MessageBox.Show("Este título ya se encuentra en la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return;
            }
            if (!ValidarEntradaAtributos(out string titulo, out string genero, out int año_de_lanzamiento, out int stock, out double precio)) return;
            lista2.AgregarAlInicio(new Producto(titulo, genero, año_de_lanzamiento, stock, precio));
            lista2.Imprimir(dgvLista2);
            LimpiarEntradas();
        }
        private void btnAgregarFinal2_Click(object sender, EventArgs e)
        {
            if (lista2.Duplicado(txtTitulo.Text.Trim()))
            {
                MessageBox.Show("Este título ya se encuentra en la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return;
            }
            if (!ValidarEntradaAtributos(out string titulo, out string genero, out int año_de_lanzamiento, out int stock, out double precio)) return;
            lista2.AgregarAlFinal(new Producto(titulo, genero, año_de_lanzamiento, stock, precio));
            lista2.Imprimir(dgvLista2);
            LimpiarEntradas();
        }
        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            lista2.EliminarPorTitulo(txtTitulo.Text.Trim());
            lista2.Imprimir(dgvLista2);
            txtTitulo.Focus();
        }
        private void btnPredeterminados_Click(object sender, EventArgs e)
        {
            lista2 = new ListaVideojuegos(10);
            lista2.Imprimir(dgvLista2);
        }

        //Auxiliares
        private bool ValidarEntradaAtributos(out string titulo, out string genero, out int año_de_lanzamiento, out int stock, out double precio)
        {
            titulo = txtTitulo.Text.Trim();
            año_de_lanzamiento = 0;
            genero = "";
            stock = 0;
            precio = 0;
            // Validación de los espacios "título" y "género"
            if (string.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("El cuadro de tìtulo no puede estar vacio.",
                    "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return false;
            }
            if (cmbGenero.SelectedIndex == -1) //-1 significa que no selecciono nada
            {
                MessageBox.Show("Seleccione un género",
                    "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return false;
            }
            genero = cmbGenero.SelectedItem.ToString();

            // Validación de los espacios "año de lanzamiento", "stock" y "precio"
            string texto1 = txtAñoLanz.Text.Trim().Replace(",", ".");
            bool exito1 = int.TryParse(texto1, out año_de_lanzamiento);
            if (!exito1 || año_de_lanzamiento <= 1900 || año_de_lanzamiento >=2026)
            {
                MessageBox.Show("Ingrese un año válido",
                    "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAñoLanz.Focus();
                return false;
            }
            string texto2 = txtStock.Text.Trim().Replace(",", ".");
            bool exito2 = int.TryParse(texto2, out stock);
            if (!exito2 || stock <= 0)
            {
                MessageBox.Show("Ingrese una cantidad numérica mayor a cero",
                    "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }
            string texto3 = txtPrecio.Text.Trim().Replace(",", ".");
            bool exito3 = double.TryParse(texto3, out precio);
            if (!exito3 || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio numérico mayor a cero",
                    "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }
            return true;
        }
        private void LimpiarEntradas()
        {
            txtTitulo.Clear();
            cmbGenero.SelectedIndex = -1;
            txtAñoLanz.Clear();
            txtStock.Clear();
            txtPrecio.Clear();
            txtTitulo.Focus();
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem)
            {
                case "Lista 1":
                    lblConteo.Text = $"Total de videojuegos: {Grupo8.ContarVideojuegos(lista1)}";
                    break;
                case "Lista 2":
                    lblConteo.Text = $"Total de videojuegos: {Grupo8.ContarVideojuegos(lista2)}";
                    break;
            }
        }
        private void btnIgualdad_Click(object sender, EventArgs e)
        {
            bool igualdadListas = Grupo8.SonIguales(lista1,lista2);
            switch(igualdadListas)
            {
                case false:
                    lblIgualdad.Text = "Las listas no son iguales";
                    break;
                case true:
                    lblIgualdad.Text = "Las listas son iguales";
                    break;
            }
        }

        private void btnOrdenarPrecio_Click(object sender, EventArgs e)
        {
            ListaVideojuegos listaSeleccionada = comboBox1.Text == "Lista 1" ? lista1 : lista2;
            if(!rbAscendente.Checked && !rbDescendente.Checked)
            {
                MessageBox.Show("Seleccione un tipo de orden");
                return;
            }
            string tipo = rbAscendente.Checked ? "1" : "2";
            Grupo8.OrdenarPorPrecio(listaSeleccionada, tipo);
            listaSeleccionada.Imprimir(dgvResultante);
        }

        private void btnInvierte_Click(object sender, EventArgs e)
        {
            ListaVideojuegos listaSeleccionada=null;

            switch (comboBox1.SelectedItem)
            {
                case "Lista 1":
                    listaSeleccionada = lista1;
                    break;
                case "Lista 2":
                    listaSeleccionada = lista2;
                    break;
                default:
                    MessageBox.Show("Seleccione una lista",
                    "Impedimento del proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            if (listaSeleccionada.EstaVacia())
            {
                MessageBox.Show("No hay juegos en la lista");
                return;
            }

            // Invertir
            ListaVideojuegos invertida = Grupo8.InvertirLista(listaSeleccionada);
            invertida.Imprimir(dgvResultante);
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            ListaVideojuegos resultado = Grupo8.RestarCatalogos(lista1, lista2);

            resultado.Imprimir(dgvResultante);

            MessageBox.Show("Catálogos restados correctamente");
        }

        private void btnEstadistica_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Lista 1":
                    Grupo8.EstadisticaPrecio(lista1);
                    break;
                case "Lista 2":
                    Grupo8.EstadisticaPrecio(lista2);
                    break;
            }
        }

        private void btnConcatena_Click(object sender, EventArgs e)
        {
            ListaVideojuegos resultado = Grupo8.ConcatenarListas(lista1, lista2);
            if (resultado == null) return;
            resultado.Imprimir(dgvResultante);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string genero = cmbGenero.Text.Trim();

            if (cmbGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un género para filtrar",
                    "Impedimento del proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListaVideojuegos listaSeleccionada = comboBox1.Text == "Lista 1" ? lista1 : lista2;

            ListaVideojuegos resultado = Grupo8.FiltrarPorGenero(listaSeleccionada, genero);

            if (resultado.EstaVacia())
            {
                MessageBox.Show("No se encontraron videojuegos con ese género.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            resultado.Imprimir(dgvResultante);
        }
    }
}
