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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
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
    }
}
