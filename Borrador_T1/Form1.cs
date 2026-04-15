using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borrador_T1
{
    public partial class Form1 : Form
    {
        //Instancias de las dos listas enlazadas
        private ListaVideojuegos lista1 = new ListaVideojuegos();
        private ListaVideojuegos lista2 = new ListaVideojuegos(10);

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
            lista2.Imprimir(dgvLista2);
        }

        //Auxiliares
        private bool ValidarEntradaAtributos(out string titulo, out string genero, out int año_de_lanzamiento, out int stock, out double precio)
        {
            titulo = txtTitulo.Text.Trim();
            genero = txtGenero.Text.Trim();
            año_de_lanzamiento = 0;
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
            if (string.IsNullOrEmpty(genero))
            {
                MessageBox.Show("El cuadro de género no puede estar vacio.",
                    "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return false;
            }
            // Validación de los espacios "año de lanzamiento", "stock" y "precio"
            string texto1 = txtAñoLanz.Text.Trim().Replace(",", ".");
            bool exito1 = int.TryParse(texto1, out año_de_lanzamiento);
            if (!exito1 || año_de_lanzamiento <= 0)
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
            txtGenero.Clear();
            txtAñoLanz.Clear();
            txtStock.Clear();
            txtPrecio.Clear();
            txtTitulo.Focus();
        }

    }
}
