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
    public partial class FrmBusquedaAVL : Form
    {
        public FrmBusquedaAVL()
        {
            InitializeComponent(); 

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
        private void dgvPalabras_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void txtPalabra_TextChanged(object sender, EventArgs e)
        {
            string texto = txtPalabra.Text.Trim().ToLower();

            var palabras = AVLGlobal.Arbol.ObtenerPalabras();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvPalabras.DataSource = palabras
            .Select(p => new { Palabra = p })
            .ToList();


                return;
            }

            var resultados = palabras
                .Where(p => p.ToLower().StartsWith(texto))
                .Select(p => new { Palabra = p })
                .ToList();

            dgvPalabras.DataSource = resultados;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
