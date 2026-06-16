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
using proyectEstructura.Models;

namespace proyectEstructura.Forms
{
    public partial class FrmMenu : Form
    {
        private Trie _trie;
        private ContextMenuStrip _autocompleteMenu;
        private int _selectedIndex = -1;
        private List<string> list;
        public FrmMenu()
        {
            InitializeComponent();
            InitTrie();
            InitContextMenu();
        }

        public void InitTrie()
        {
            _trie = new Trie();
            list = AVLGlobal.Arbol.ObtenerPalabras();
            
            foreach (var palabra in list)
            {
                _trie.agregar(palabra);
            }
        }

        private void InitContextMenu()
        {
            _autocompleteMenu = new ContextMenuStrip();

            // Configuración para que el menú no le robe el foco azul/de escritura al TextBox
            _autocompleteMenu.ShowCheckMargin = false;
            _autocompleteMenu.ShowImageMargin = false;

            _autocompleteMenu.AutoClose = false;

            // Evento cuando el usuario hace clic en una opción del menú
            _autocompleteMenu.ItemClicked += AutocompleteMenu_ItemClicked;
        }

        private void ResaltarItemSeleccionado()
        {
            if (_autocompleteMenu.Items.Count == 0) return;

            for (int i = 0; i < _autocompleteMenu.Items.Count; i++)
            {
                if (i == _selectedIndex)
                {
                    _autocompleteMenu.Items[i].Select(); // Ilumina la opción en azul sin robar el foco
                }
            }
        }

        private void ActualizarMenuSugerencias(List<string> sugerencias)
        {
            _autocompleteMenu.Items.Clear();
            foreach (var sug in sugerencias)
            {
                _autocompleteMenu.Items.Add(sug);
            }

            _selectedIndex = 0; // Apuntar al primer elemento por defecto
            ResaltarItemSeleccionado();
        }
        private void CerrarMenu()
        {
            _autocompleteMenu.Close();
            _selectedIndex = -1;
        }

        private void MostrarMenuEnCursor()
        {
            // Obtiene las coordenadas (X, Y) relativas de la posición del cursor de texto
            Point caretPoint = txtEditor.GetPositionFromCharIndex(txtEditor.SelectionStart);

            // Sumamos un pequeño margen en Y para que baje justo debajo de la línea de texto actual (aprox 15-20 píxeles)
            caretPoint.Y += 18;

            // Mostramos el menú en la posición calculada dentro del TextBox
            // Sin este truco, el ContextMenuStrip se abriría donde esté el puntero del mouse.
            if (!_autocompleteMenu.Visible)
            {
                _autocompleteMenu.Show(txtEditor, caretPoint);

                // Devolvemos inmediatamente el foco al TextBox para que el usuario pueda seguir escribiendo
                txtEditor.Focus();
            }
        }

        private void InsertarSugerencia(string sugerencia)
        {
            int cursorPosition = txtEditor.SelectionStart;
            string texto = txtEditor.Text;

            // Encontrar dónde empieza la última palabra para reemplazarla
            int inicioPalabra = texto.LastIndexOfAny(new char[] { ' ', '\n', '\r', '\t' }, cursorPosition - 1);
            inicioPalabra = inicioPalabra == -1 ? 0 : inicioPalabra + 1;

            // Reemplazar texto viejo por la sugerencia del Trie
            string nuevoTexto = texto.Substring(0, inicioPalabra) + sugerencia + texto.Substring(cursorPosition);
            txtEditor.Text = nuevoTexto;

            // Reposicionar el cursor al final de la palabra insertada
            txtEditor.SelectionStart = inicioPalabra + sugerencia.Length;
            txtEditor.SelectionLength = 0;

            CerrarMenu();
            txtEditor.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_autocompleteMenu.Visible)
            {
                // Intercepta Flecha Abajo
                if (keyData == Keys.Down)
                {
                    if (_selectedIndex < _autocompleteMenu.Items.Count - 1)
                    {
                        _selectedIndex++;
                        ResaltarItemSeleccionado();
                    }
                    return true; // Evita que el cursor del TextBox se mueva
                }

                // Intercepta Flecha Arriba
                if (keyData == Keys.Up)
                {
                    if (_selectedIndex > 0)
                    {
                        _selectedIndex--;
                        ResaltarItemSeleccionado();
                    }
                    return true; // Evita que el cursor del TextBox se mueva
                }

                // Intercepta Enter o Tab para confirmar
                if (keyData == Keys.Enter || keyData == Keys.Tab)
                {
                    if (_selectedIndex >= 0 && _selectedIndex < _autocompleteMenu.Items.Count)
                    {
                        InsertarSugerencia(_autocompleteMenu.Items[_selectedIndex].Text);
                    }
                    return true; // Evita que el TextBox salte de línea o use el Tab nativo
                }

                // Intercepta Escape para cerrar
                if (keyData == Keys.Escape)
                {
                    CerrarMenu();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AutocompleteMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            InsertarSugerencia(e.ClickedItem.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmInsertarHash frm = new FrmInsertarHash();

            frm.Show();

            this.Hide(); 

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FrmEliminarHash frm = new FrmEliminarHash();
            frm.Show();

            this.Hide();

        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            FrmActualizarAVL frm = new FrmActualizarAVL();
            frm.Show();

            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FrmBusquedaAVL frm = new FrmBusquedaAVL();
            frm.Show();

            this.Hide();
        }

        public void checkAutocomplete()
        {
            if (list.Count == 0)
            {
                
                MessageBox.Show(
                    this,
                    "No hay palabras reservadas. Por favor, inserta palabras para activar el autocompletado.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            
            
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            //InitTrie();
            checkAutocomplete();

        }

        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            string texto = txtEditor.Text;
            if (string.IsNullOrEmpty(texto))
            {
                CerrarMenu();
                return;
            }

            // Obtener la última palabra escrita antes del cursor
            int cursorPosition = txtEditor.SelectionStart;
            string textoHastaCursor = texto.Substring(0, cursorPosition);
            string[] palabras = textoHastaCursor.Split(' ', '\n', '\r', '\t');
            string ultimaPalabra = palabras[palabras.Length - 1];

            // Disparar autocompletado a partir de 2 caracteres
            if (ultimaPalabra.Length >= 2)
            {
                List<string> sugerencias = _trie.autocompletar(ultimaPalabra);

                if (sugerencias.Count > 0)
                {
                    ActualizarMenuSugerencias(sugerencias);
                    MostrarMenuEnCursor();
                }
                else
                {
                    CerrarMenu();
                }
            }
            else
            {
                CerrarMenu();
            }
        }
    }
}
