namespace FunerariaSanRafael.UI
{
    partial class RegistroServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroServicios));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbServicioStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServicioCtaCont = new System.Windows.Forms.TextBox();
            this.cbServicioTipoCosto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbServicioTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnServicioGuardar = new System.Windows.Forms.Button();
            this.btnServicioSalir = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtServicioCosto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServicioDescripcion = new System.Windows.Forms.TextBox();
            this.txtServicioId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbServicioStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtServicioCtaCont);
            this.panel1.Controls.Add(this.cbServicioTipoCosto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbServicioTipo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnServicioGuardar);
            this.panel1.Controls.Add(this.btnServicioSalir);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtServicioId);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtServicioCosto);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtServicioDescripcion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 356);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(10, 177);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(520, 135);
            this.label6.TabIndex = 102;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // cbServicioStatus
            // 
            this.cbServicioStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServicioStatus.FormattingEnabled = true;
            this.cbServicioStatus.Items.AddRange(new object[] {
            "A",
            "I"});
            this.cbServicioStatus.Location = new System.Drawing.Point(440, 135);
            this.cbServicioStatus.Name = "cbServicioStatus";
            this.cbServicioStatus.Size = new System.Drawing.Size(69, 23);
            this.cbServicioStatus.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(440, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 14);
            this.label5.TabIndex = 100;
            this.label5.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(280, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 14);
            this.label4.TabIndex = 98;
            this.label4.Text = "Cuenta contable";
            // 
            // txtServicioCtaCont
            // 
            this.txtServicioCtaCont.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtServicioCtaCont.Location = new System.Drawing.Point(280, 137);
            this.txtServicioCtaCont.Margin = new System.Windows.Forms.Padding(1);
            this.txtServicioCtaCont.Name = "txtServicioCtaCont";
            this.txtServicioCtaCont.Size = new System.Drawing.Size(116, 22);
            this.txtServicioCtaCont.TabIndex = 99;
            this.txtServicioCtaCont.TabStop = false;
            this.txtServicioCtaCont.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServicioCtaCont_KeyPress);
            // 
            // cbServicioTipoCosto
            // 
            this.cbServicioTipoCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServicioTipoCosto.FormattingEnabled = true;
            this.cbServicioTipoCosto.Items.AddRange(new object[] {
            "M",
            "%"});
            this.cbServicioTipoCosto.Location = new System.Drawing.Point(146, 136);
            this.cbServicioTipoCosto.Name = "cbServicioTipoCosto";
            this.cbServicioTipoCosto.Size = new System.Drawing.Size(69, 23);
            this.cbServicioTipoCosto.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(146, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 96;
            this.label2.Text = "Tipo costo";
            // 
            // cbServicioTipo
            // 
            this.cbServicioTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServicioTipo.FormattingEnabled = true;
            this.cbServicioTipo.Items.AddRange(new object[] {
            "P",
            "A",
            "S",
            "X",
            "Z"});
            this.cbServicioTipo.Location = new System.Drawing.Point(28, 135);
            this.cbServicioTipo.Name = "cbServicioTipo";
            this.cbServicioTipo.Size = new System.Drawing.Size(69, 23);
            this.cbServicioTipo.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 94;
            this.label1.Text = "Tipo";
            // 
            // btnServicioGuardar
            // 
            this.btnServicioGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnServicioGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(236)))), ((int)(((byte)(182)))));
            this.btnServicioGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(87)))), ((int)(((byte)(44)))));
            this.btnServicioGuardar.FlatAppearance.BorderSize = 2;
            this.btnServicioGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicioGuardar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServicioGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(87)))), ((int)(((byte)(44)))));
            this.btnServicioGuardar.Location = new System.Drawing.Point(360, 321);
            this.btnServicioGuardar.Margin = new System.Windows.Forms.Padding(1);
            this.btnServicioGuardar.Name = "btnServicioGuardar";
            this.btnServicioGuardar.Size = new System.Drawing.Size(124, 25);
            this.btnServicioGuardar.TabIndex = 92;
            this.btnServicioGuardar.Text = "Guardar";
            this.btnServicioGuardar.UseVisualStyleBackColor = false;
            this.btnServicioGuardar.Click += new System.EventHandler(this.btnServicioGuardar_Click);
            // 
            // btnServicioSalir
            // 
            this.btnServicioSalir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnServicioSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(249)))));
            this.btnServicioSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnServicioSalir.FlatAppearance.BorderSize = 2;
            this.btnServicioSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicioSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServicioSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnServicioSalir.Location = new System.Drawing.Point(58, 321);
            this.btnServicioSalir.Margin = new System.Windows.Forms.Padding(1);
            this.btnServicioSalir.Name = "btnServicioSalir";
            this.btnServicioSalir.Size = new System.Drawing.Size(124, 25);
            this.btnServicioSalir.TabIndex = 93;
            this.btnServicioSalir.Text = "Salir";
            this.btnServicioSalir.UseVisualStyleBackColor = false;
            this.btnServicioSalir.Click += new System.EventHandler(this.btnServicioSalir_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bookman Old Style", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(183, 19);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(213, 18);
            this.label15.TabIndex = 91;
            this.label15.Text = "Actualización de Servicios";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(393, 56);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 14);
            this.label10.TabIndex = 88;
            this.label10.Text = "Costo";
            // 
            // txtServicioCosto
            // 
            this.txtServicioCosto.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtServicioCosto.Location = new System.Drawing.Point(392, 75);
            this.txtServicioCosto.Margin = new System.Windows.Forms.Padding(1);
            this.txtServicioCosto.Name = "txtServicioCosto";
            this.txtServicioCosto.Size = new System.Drawing.Size(116, 22);
            this.txtServicioCosto.TabIndex = 89;
            this.txtServicioCosto.TabStop = false;
            this.txtServicioCosto.TextChanged += new System.EventHandler(this.txtServicioCosto_TextChanged);
            this.txtServicioCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServicioCosto_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(160, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 14);
            this.label3.TabIndex = 83;
            this.label3.Text = "Descripción";
            // 
            // txtServicioDescripcion
            // 
            this.txtServicioDescripcion.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtServicioDescripcion.Location = new System.Drawing.Point(160, 75);
            this.txtServicioDescripcion.Margin = new System.Windows.Forms.Padding(1);
            this.txtServicioDescripcion.Name = "txtServicioDescripcion";
            this.txtServicioDescripcion.Size = new System.Drawing.Size(219, 22);
            this.txtServicioDescripcion.TabIndex = 80;
            this.txtServicioDescripcion.TabStop = false;
            // 
            // txtServicioId
            // 
            this.txtServicioId.BackColor = System.Drawing.Color.White;
            this.txtServicioId.Enabled = false;
            this.txtServicioId.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtServicioId.Location = new System.Drawing.Point(28, 75);
            this.txtServicioId.Margin = new System.Windows.Forms.Padding(1);
            this.txtServicioId.Name = "txtServicioId";
            this.txtServicioId.Size = new System.Drawing.Size(116, 22);
            this.txtServicioId.TabIndex = 82;
            this.txtServicioId.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(28, 56);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 14);
            this.label11.TabIndex = 90;
            this.label11.Text = "ID";
            // 
            // RegistroServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 356);
            this.Controls.Add(this.panel1);
            this.Name = "RegistroServicios";
            this.Text = "RegistroServicios";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnServicioGuardar;
        private Button btnServicioSalir;
        private Label label15;
        private Label label10;
        private TextBox txtServicioCosto;
        private Label label3;
        private TextBox txtServicioDescripcion;
        private Label label1;
        private ComboBox cbServicioStatus;
        private Label label5;
        private Label label4;
        private TextBox txtServicioCtaCont;
        private ComboBox cbServicioTipoCosto;
        private Label label2;
        private ComboBox cbServicioTipo;
        private Label label6;
        private TextBox txtServicioId;
        private Label label11;
    }
}