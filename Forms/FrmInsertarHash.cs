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
    public partial class FrmInsertarHash : Form
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

        public FrmInsertarHash()
        {
            InitializeComponent();

            // Centrar el formulario en pantalla
            this.StartPosition = FormStartPosition.CenterScreen;

            // Mostrar datos al abrir el formulario
            CargarTabla();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ajustar columnas automáticamente
            dgvPalabras.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Inserta una nueva palabra en la tabla hash
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string palabra = txtPalabra.Text.Trim().ToLower();
            palabra = QuitarTildes(palabra);

            // Validar que el usuario escriba algo
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

            //No permitir espacios
            if (palabra.Contains(" "))
            {
                MessageBox.Show(
                    this,
                    "No se permiten espacios. Ingrese una sola palabra.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Solo letras 
            if (!System.Text.RegularExpressions.Regex.IsMatch(palabra, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show(
                    this,
                    "Solo se permiten letras sin números ni símbolos.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            bool agregado = HashGlobal.TablaHash.Insertar(palabra);

            if (agregado)
            {
                AVLGlobal.Arbol.Insertar(palabra);
                MessageBox.Show(
            this,
            "Palabra insertada correctamente.",
            "Éxito",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
            this,
            "La palabra ya existe.",
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

            // Regresa al principal menu 
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
    }
}
