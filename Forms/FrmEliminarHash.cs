using proyectEstructura.Forms;
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

namespace proyectEstructura
{
    public partial class FrmEliminarHash : Form
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

        public FrmEliminarHash()
        {
            InitializeComponent();

            // insertar las palabras de la dataGrid en el textboxPalabra
            dgvPalabras.CellClick += dgvPalabras_CellClick;

            // Centrar el formulario en pantalla
            this.StartPosition = FormStartPosition.CenterScreen;

            // Ajusta las columnas para q ocupen todo el ancho del DataGridView
            dgvPalabras.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            // Mostrar datos al abrir el formulario
            CargarTabla();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            string palabra = txtPalabra.Text.Trim().ToLower();
            palabra = QuitarTildes(palabra);

            if (string.IsNullOrWhiteSpace(palabra))
            {
                MessageBox.Show(
             this,
             "Ingrese una palabra",
             "Advertencia",
             MessageBoxButtons.OK,
             MessageBoxIcon.Warning);

                return;
            }

            bool eliminado = HashGlobal.TablaHash.Eliminar(palabra);

            if (eliminado)
            {
                AVLGlobal.Arbol.Eliminar(palabra);
                MessageBox.Show(
            this,
            "Palabra eliminada",
            "Éxito",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
            this,
            "La palabra no existe",
            "Información",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            }

            CargarTabla();

            // Limpia el TextBox
            txtPalabra.Clear();

            // Regresa el cursor al TextBox
            txtPalabra.Focus();
        }

        // Muestra el contenido actual de la tabla hash
        private void CargarTabla()
        {
            dgvPalabras.DataSource = null;
            dgvPalabras.DataSource = HashGlobal.TablaHash.ObtenerRegistros();
        }

        private void dgvPalabras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtPalabra.Text = dgvPalabras.Rows[e.RowIndex]
                                             .Cells[1]
                                             .Value?.ToString();
            }
        }

        /// Regresa al principal menu 
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu menu = Application.OpenForms["FrmMenu"] as FrmMenu;

            if (menu != null)
            {
                menu.Show();
            }

            this.Close();
        }

        private void dgvPalabras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPalabra_TextChanged(object sender, EventArgs e)
        {

        }
    }


 }

