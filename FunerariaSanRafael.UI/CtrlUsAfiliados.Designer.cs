namespace FunerariaSanRafael.UI
{
    partial class CtrlUsAfiliados
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAfiliadosBuscar = new System.Windows.Forms.Button();
            this.cbAfiliadosRuta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAfiliadosID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAfiliadosNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvAfiliadosCompleta = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfiliadosCompleta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAfiliadosBuscar
            // 
            this.btnAfiliadosBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAfiliadosBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(249)))));
            this.btnAfiliadosBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnAfiliadosBuscar.FlatAppearance.BorderSize = 2;
            this.btnAfiliadosBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfiliadosBuscar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAfiliadosBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnAfiliadosBuscar.Location = new System.Drawing.Point(870, 34);
            this.btnAfiliadosBuscar.Margin = new System.Windows.Forms.Padding(1);
            this.btnAfiliadosBuscar.Name = "btnAfiliadosBuscar";
            this.btnAfiliadosBuscar.Size = new System.Drawing.Size(151, 29);
            this.btnAfiliadosBuscar.TabIndex = 18;
            this.btnAfiliadosBuscar.Text = "Buscar";
            this.btnAfiliadosBuscar.UseVisualStyleBackColor = false;
            this.btnAfiliadosBuscar.Click += new System.EventHandler(this.btnAfiliadosBuscar_Click);
            // 
            // cbAfiliadosRuta
            // 
            this.cbAfiliadosRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAfiliadosRuta.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbAfiliadosRuta.FormattingEnabled = true;
            this.cbAfiliadosRuta.Items.AddRange(new object[] {
            "Todas",
            "1",
            "2",
            "3"});
            this.cbAfiliadosRuta.Location = new System.Drawing.Point(9, 34);
            this.cbAfiliadosRuta.Margin = new System.Windows.Forms.Padding(1);
            this.cbAfiliadosRuta.Name = "cbAfiliadosRuta";
            this.cbAfiliadosRuta.Size = new System.Drawing.Size(127, 24);
            this.cbAfiliadosRuta.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label3.Location = new System.Drawing.Point(9, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ruta";
            // 
            // txtAfiliadosID
            // 
            this.txtAfiliadosID.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAfiliadosID.Location = new System.Drawing.Point(277, 35);
            this.txtAfiliadosID.Margin = new System.Windows.Forms.Padding(1);
            this.txtAfiliadosID.Name = "txtAfiliadosID";
            this.txtAfiliadosID.Size = new System.Drawing.Size(105, 22);
            this.txtAfiliadosID.TabIndex = 17;
            this.txtAfiliadosID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAfiliadosID_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label4.Location = new System.Drawing.Point(277, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 14);
            this.label4.TabIndex = 43;
            this.label4.Text = "No. Expediente";
            // 
            // txtAfiliadosNombre
            // 
            this.txtAfiliadosNombre.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAfiliadosNombre.Location = new System.Drawing.Point(153, 35);
            this.txtAfiliadosNombre.Margin = new System.Windows.Forms.Padding(1);
            this.txtAfiliadosNombre.Name = "txtAfiliadosNombre";
            this.txtAfiliadosNombre.Size = new System.Drawing.Size(105, 22);
            this.txtAfiliadosNombre.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label5.Location = new System.Drawing.Point(153, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 14);
            this.label5.TabIndex = 47;
            this.label5.Text = "Nombre";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtAfiliadosID);
            this.panel1.Controls.Add(this.btnAfiliadosBuscar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbAfiliadosRuta);
            this.panel1.Controls.Add(this.txtAfiliadosNombre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 71);
            this.panel1.TabIndex = 48;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.dgvAfiliadosCompleta);
            this.panel6.Location = new System.Drawing.Point(0, 88);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1036, 493);
            this.panel6.TabIndex = 49;
            // 
            // dgvAfiliadosCompleta
            // 
            this.dgvAfiliadosCompleta.AllowUserToAddRows = false;
            this.dgvAfiliadosCompleta.AllowUserToDeleteRows = false;
            this.dgvAfiliadosCompleta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAfiliadosCompleta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAfiliadosCompleta.BackgroundColor = System.Drawing.Color.White;
            this.dgvAfiliadosCompleta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAfiliadosCompleta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAfiliadosCompleta.ColumnHeadersHeight = 29;
            this.dgvAfiliadosCompleta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.Ver});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAfiliadosCompleta.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAfiliadosCompleta.Location = new System.Drawing.Point(14, 15);
            this.dgvAfiliadosCompleta.Margin = new System.Windows.Forms.Padding(1);
            this.dgvAfiliadosCompleta.Name = "dgvAfiliadosCompleta";
            this.dgvAfiliadosCompleta.RowHeadersVisible = false;
            this.dgvAfiliadosCompleta.RowHeadersWidth = 51;
            this.dgvAfiliadosCompleta.RowTemplate.Height = 49;
            this.dgvAfiliadosCompleta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAfiliadosCompleta.Size = new System.Drawing.Size(1006, 461);
            this.dgvAfiliadosCompleta.TabIndex = 29;
            this.dgvAfiliadosCompleta.TabStop = false;
            this.dgvAfiliadosCompleta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAfiliadosCompleta_CellClick);
            // 
            // Editar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Baskerville Old Face", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Green;
            this.Editar.DefaultCellStyle = dataGridViewCellStyle2;
            this.Editar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Editar.HeaderText = "Editar";
            this.Editar.MinimumWidth = 12;
            this.Editar.Name = "Editar";
            this.Editar.Text = "Editar";
            this.Editar.UseColumnTextForButtonValue = true;
            this.Editar.Width = 99;
            // 
            // Ver
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Baskerville Old Face", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Ver.DefaultCellStyle = dataGridViewCellStyle3;
            this.Ver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Ver.HeaderText = "Ver";
            this.Ver.MinimumWidth = 12;
            this.Ver.Name = "Ver";
            this.Ver.Text = "Ver";
            this.Ver.UseColumnTextForButtonValue = true;
            this.Ver.Width = 99;
            // 
            // CtrlUsAfiliados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CtrlUsAfiliados";
            this.Size = new System.Drawing.Size(1036, 581);
            this.Load += new System.EventHandler(this.CtrlUsAfiliados_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfiliadosCompleta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnAfiliadosBuscar;
        private ComboBox cbAfiliadosRuta;
        private Label label3;
        private TextBox txtAfiliadosID;
        private Label label4;
        private Label label5;
        private TextBox txtAfiliadosNombre;
        private Panel panel1;
        private Panel panel6;
        private DataGridView dgvAfiliadosCompleta;
        private DataGridViewButtonColumn Editar;
        private DataGridViewButtonColumn Ver;
    }
}
