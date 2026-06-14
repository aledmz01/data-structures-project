using proyectEstructura.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectEstructura.Forms
{
    public partial class FrmActualizarAVL : Form
    {
        private string QuitarTildes(string texto)
        {
            string normalized = texto.Normalize(System.Text.NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
                    != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }

        public FrmActualizarAVL()
        {
            InitializeComponent();

            dgvPalabras.AutoSizeColumnsMode =
       DataGridViewAutoSizeColumnsMode.Fill;

            // insertar las palabras de la dataGrid en el textboxPalabra
            dgvPalabras.CellClick += dgvPalabras_CellClick;

            // Centrar el formulario en pantalla
            this.StartPosition = FormStartPosition.CenterScreen;

            // Ajusta las columnas para q ocupen todo el ancho del DataGridView
            dgvPalabras.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            //Cargar las tablas
            CargarTabla();
        }
        private void CargarTabla()
        {
            dgvPalabras.DataSource = null;

            dgvPalabras.DataSource =
                AVLGlobal.Arbol
                         .ObtenerPalabras()
                         .Select(p => new { Palabra = p })
                         .ToList();
        }

        private void FrmActualizarAVL_Load(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu menu = Application.OpenForms["FrmMenu"] as FrmMenu;

            if (menu != null)
            {
                menu.InitTrie();
                menu.checkAutocomplete();
                menu.Show();
            }

            this.Close();
        }

        private void dgvPalabras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvPalabras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
        dgvPalabras.Rows[e.RowIndex].Cells[0].Value != null)
            {
                txtPalabra.Text =
                    dgvPalabras.Rows[e.RowIndex]
                               .Cells[0]
                               .Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string palabra = txtPalabra.Text.Trim().ToLower();
            palabra = QuitarTildes(palabra);

            string palabraAct = txtPalabraAct.Text.Trim().ToLower();
            palabraAct = QuitarTildes(palabraAct);

            if (string.IsNullOrWhiteSpace(palabra) || string.IsNullOrWhiteSpace(palabraAct))
            {
                MessageBox.Show(
             this,
             "Existe uno o mas campos vacios!",
             "Advertencia",
             MessageBoxButtons.OK,
             MessageBoxIcon.Warning);

                return;
            }
            if (palabraAct.Contains(" "))
            {
                MessageBox.Show(
                    this,
                    "No se permiten espacios. Ingrese una sola palabra a actualizar.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Solo letras 
            if (!System.Text.RegularExpressions.Regex.IsMatch(palabraAct, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show(
                    this,
                    "Solo se permiten letras sin números ni símbolos.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (palabra == palabraAct)
            {
                MessageBox.Show(
                    this,
                    "La nueva palabra es igual a la actual.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (AVLGlobal.Arbol.Buscar(palabraAct))
            {
                MessageBox.Show(
                    this,
                    "La palabra nueva ya existe en el diccionario.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            bool eliminado = HashGlobal.TablaHash.Eliminar(palabra);
            bool agregado = HashGlobal.TablaHash.Insertar(palabraAct);
            if (eliminado && agregado)
            {
                AVLGlobal.Arbol.Eliminar(palabra);
                AVLGlobal.Arbol.Insertar(palabraAct);
                MessageBox.Show(
            this,
            "Palabra actualizada",
            "Éxito",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
            this,
            "La palabra del primer campo no existe",
            "Información",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            }

            CargarTabla();

            // Limpia el TextBox
            txtPalabra.Clear();
            txtPalabraAct.Clear();

            // Regresa el cursor al TextBox
            txtPalabra.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
