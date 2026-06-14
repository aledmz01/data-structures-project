namespace proyectEstructura
{
    partial class FrmEliminarHash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvPalabras = new System.Windows.Forms.DataGridView();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelControl2 = new System.Windows.Forms.Label();
            this.txtPalabra = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.labelControl1 = new System.Windows.Forms.Label();
            this.panelControl1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabras)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1957, 749);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Location = new System.Drawing.Point(989, 62);
            this.panel4.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(853, 579);
            this.panel4.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dgvPalabras);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(35, 45);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(781, 470);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dgvPalabras
            // 
            this.dgvPalabras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPalabras.Location = new System.Drawing.Point(8, 7);
            this.dgvPalabras.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dgvPalabras.Name = "dgvPalabras";
            this.dgvPalabras.RowHeadersWidth = 102;
            this.dgvPalabras.Size = new System.Drawing.Size(773, 463);
            this.dgvPalabras.TabIndex = 0;
            this.dgvPalabras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPalabras_CellContentClick);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRegresar.Location = new System.Drawing.Point(1723, 677);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(200, 55);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.txtPalabra);
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Location = new System.Drawing.Point(67, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(824, 579);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.labelControl2);
            this.panel3.Location = new System.Drawing.Point(64, 45);
            this.panel3.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(688, 86);
            this.panel3.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSize = true;
            this.labelControl2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(157, 5);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(382, 77);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Eliminación";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // txtPalabra
            // 
            this.txtPalabra.Location = new System.Drawing.Point(64, 269);
            this.txtPalabra.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtPalabra.Name = "txtPalabra";
            this.txtPalabra.Size = new System.Drawing.Size(681, 38);
            this.txtPalabra.TabIndex = 2;
            this.txtPalabra.TextChanged += new System.EventHandler(this.txtPalabra_TextChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.HotPink;
            this.btnEliminar.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(280, 384);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(256, 83);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSize = true;
            this.labelControl1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(109, 200);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(612, 61);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ingrese Palabra a eliminar :";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Location = new System.Drawing.Point(-5, -2);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1992, 754);
            this.panelControl1.TabIndex = 1;
            // 
            // FrmEliminarHash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1949, 744);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FrmEliminarHash";
            this.Text = "Pantalla de Eliminación";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabras)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelControl2;
        private System.Windows.Forms.TextBox txtPalabra;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label labelControl1;
        private System.Windows.Forms.Panel panelControl1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvPalabras;
    }
}