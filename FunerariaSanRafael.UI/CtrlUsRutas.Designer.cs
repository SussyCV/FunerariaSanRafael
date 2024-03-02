namespace FunerariaSanRafael.UI
{
    partial class CtrlUsRutas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRutasBuscar = new System.Windows.Forms.Button();
            this.dgvRutasCompleta = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnServiciosNuevo = new System.Windows.Forms.Button();
            this.dgvServiciosCompleta = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRutasNuevo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServiciosNombre = new System.Windows.Forms.TextBox();
            this.txtRutasId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRutasNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutasCompleta)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosCompleta)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRutasBuscar
            // 
            this.btnRutasBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRutasBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(249)))));
            this.btnRutasBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnRutasBuscar.FlatAppearance.BorderSize = 2;
            this.btnRutasBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRutasBuscar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRutasBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnRutasBuscar.Location = new System.Drawing.Point(870, 30);
            this.btnRutasBuscar.Margin = new System.Windows.Forms.Padding(1);
            this.btnRutasBuscar.Name = "btnRutasBuscar";
            this.btnRutasBuscar.Size = new System.Drawing.Size(151, 29);
            this.btnRutasBuscar.TabIndex = 54;
            this.btnRutasBuscar.Text = "Buscar";
            this.btnRutasBuscar.UseVisualStyleBackColor = false;
            this.btnRutasBuscar.Click += new System.EventHandler(this.btnRutasBuscar_Click);
            // 
            // dgvRutasCompleta
            // 
            this.dgvRutasCompleta.AllowUserToAddRows = false;
            this.dgvRutasCompleta.AllowUserToDeleteRows = false;
            this.dgvRutasCompleta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRutasCompleta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRutasCompleta.BackgroundColor = System.Drawing.Color.White;
            this.dgvRutasCompleta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRutasCompleta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRutasCompleta.ColumnHeadersHeight = 29;
            this.dgvRutasCompleta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.Eliminar});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRutasCompleta.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRutasCompleta.Location = new System.Drawing.Point(14, 15);
            this.dgvRutasCompleta.Margin = new System.Windows.Forms.Padding(1);
            this.dgvRutasCompleta.Name = "dgvRutasCompleta";
            this.dgvRutasCompleta.RowHeadersVisible = false;
            this.dgvRutasCompleta.RowHeadersWidth = 51;
            this.dgvRutasCompleta.RowTemplate.Height = 49;
            this.dgvRutasCompleta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRutasCompleta.Size = new System.Drawing.Size(837, 206);
            this.dgvRutasCompleta.TabIndex = 29;
            this.dgvRutasCompleta.TabStop = false;
            this.dgvRutasCompleta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRutasCompleta_CellClick);
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
            // Eliminar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Baskerville Old Face", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.Eliminar.DefaultCellStyle = dataGridViewCellStyle3;
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseColumnTextForButtonValue = true;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnServiciosNuevo);
            this.panel6.Controls.Add(this.dgvServiciosCompleta);
            this.panel6.Controls.Add(this.btnRutasNuevo);
            this.panel6.Controls.Add(this.dgvRutasCompleta);
            this.panel6.Location = new System.Drawing.Point(0, 88);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1036, 493);
            this.panel6.TabIndex = 57;
            // 
            // btnServiciosNuevo
            // 
            this.btnServiciosNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServiciosNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(249)))));
            this.btnServiciosNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnServiciosNuevo.FlatAppearance.BorderSize = 2;
            this.btnServiciosNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiciosNuevo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServiciosNuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnServiciosNuevo.Location = new System.Drawing.Point(885, 250);
            this.btnServiciosNuevo.Margin = new System.Windows.Forms.Padding(1);
            this.btnServiciosNuevo.Name = "btnServiciosNuevo";
            this.btnServiciosNuevo.Size = new System.Drawing.Size(135, 30);
            this.btnServiciosNuevo.TabIndex = 57;
            this.btnServiciosNuevo.Text = "Agregar Servicio";
            this.btnServiciosNuevo.UseVisualStyleBackColor = false;
            this.btnServiciosNuevo.Click += new System.EventHandler(this.btnServiciosNuevo_Click);
            // 
            // dgvServiciosCompleta
            // 
            this.dgvServiciosCompleta.AllowUserToAddRows = false;
            this.dgvServiciosCompleta.AllowUserToDeleteRows = false;
            this.dgvServiciosCompleta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiciosCompleta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvServiciosCompleta.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosCompleta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosCompleta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvServiciosCompleta.ColumnHeadersHeight = 29;
            this.dgvServiciosCompleta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1,
            this.Eliminar1});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosCompleta.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvServiciosCompleta.Location = new System.Drawing.Point(14, 250);
            this.dgvServiciosCompleta.Margin = new System.Windows.Forms.Padding(1);
            this.dgvServiciosCompleta.Name = "dgvServiciosCompleta";
            this.dgvServiciosCompleta.RowHeadersVisible = false;
            this.dgvServiciosCompleta.RowHeadersWidth = 51;
            this.dgvServiciosCompleta.RowTemplate.Height = 49;
            this.dgvServiciosCompleta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosCompleta.Size = new System.Drawing.Size(837, 206);
            this.dgvServiciosCompleta.TabIndex = 56;
            this.dgvServiciosCompleta.TabStop = false;
            this.dgvServiciosCompleta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosCompleta_CellClick);
            this.dgvServiciosCompleta.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvServiciosCompleta_CellMouseMove);
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Baskerville Old Face", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Green;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn1.HeaderText = "Editar";
            this.dataGridViewButtonColumn1.MinimumWidth = 12;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Editar";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 99;
            // 
            // Eliminar1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Baskerville Old Face", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            this.Eliminar1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Eliminar1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Eliminar1.HeaderText = "Eliminar";
            this.Eliminar1.Name = "Eliminar1";
            this.Eliminar1.Text = "Eliminar";
            this.Eliminar1.UseColumnTextForButtonValue = true;
            // 
            // btnRutasNuevo
            // 
            this.btnRutasNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRutasNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(249)))));
            this.btnRutasNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnRutasNuevo.FlatAppearance.BorderSize = 2;
            this.btnRutasNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRutasNuevo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRutasNuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnRutasNuevo.Location = new System.Drawing.Point(885, 15);
            this.btnRutasNuevo.Margin = new System.Windows.Forms.Padding(1);
            this.btnRutasNuevo.Name = "btnRutasNuevo";
            this.btnRutasNuevo.Size = new System.Drawing.Size(135, 30);
            this.btnRutasNuevo.TabIndex = 55;
            this.btnRutasNuevo.Text = "Agregar Ruta";
            this.btnRutasNuevo.UseVisualStyleBackColor = false;
            this.btnRutasNuevo.Click += new System.EventHandler(this.btnRutasNuevo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtServiciosNombre);
            this.panel1.Controls.Add(this.txtRutasId);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnRutasBuscar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtRutasNombre);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 71);
            this.panel1.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label2.Location = new System.Drawing.Point(288, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 56;
            this.label2.Text = "Servicio";
            // 
            // txtServiciosNombre
            // 
            this.txtServiciosNombre.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtServiciosNombre.Location = new System.Drawing.Point(288, 33);
            this.txtServiciosNombre.Margin = new System.Windows.Forms.Padding(1);
            this.txtServiciosNombre.Name = "txtServiciosNombre";
            this.txtServiciosNombre.Size = new System.Drawing.Size(105, 22);
            this.txtServiciosNombre.TabIndex = 55;
            // 
            // txtRutasId
            // 
            this.txtRutasId.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRutasId.Location = new System.Drawing.Point(139, 33);
            this.txtRutasId.Margin = new System.Windows.Forms.Padding(1);
            this.txtRutasId.Name = "txtRutasId";
            this.txtRutasId.Size = new System.Drawing.Size(105, 22);
            this.txtRutasId.TabIndex = 17;
            this.txtRutasId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRutasId_KeyPress);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(249)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Baskerville Old Face", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.button1.Location = new System.Drawing.Point(1727, 34);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 22);
            this.button1.TabIndex = 18;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nombre";
            // 
            // txtRutasNombre
            // 
            this.txtRutasNombre.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRutasNombre.Location = new System.Drawing.Point(15, 33);
            this.txtRutasNombre.Margin = new System.Windows.Forms.Padding(1);
            this.txtRutasNombre.Name = "txtRutasNombre";
            this.txtRutasNombre.Size = new System.Drawing.Size(105, 22);
            this.txtRutasNombre.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label6.Location = new System.Drawing.Point(139, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 14);
            this.label6.TabIndex = 43;
            this.label6.Text = "Id Ruta";
            // 
            // CtrlUsRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Name = "CtrlUsRutas";
            this.Size = new System.Drawing.Size(1036, 581);
            this.Load += new System.EventHandler(this.CtrlUsRutas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutasCompleta)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosCompleta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnRutasBuscar;
        private DataGridView dgvRutasCompleta;
        private Panel panel6;
        private Panel panel1;
        private TextBox txtRutasId;
        private Button button1;
        private Label label1;
        private TextBox txtRutasNombre;
        private Label label6;
        private Button btnRutasNuevo;
        private DataGridViewButtonColumn Editar;
        private DataGridViewButtonColumn Eliminar;
        private Button btnServiciosNuevo;
        private DataGridView dgvServiciosCompleta;
        private Label label2;
        private TextBox txtServiciosNombre;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private DataGridViewButtonColumn Eliminar1;
    }
}
