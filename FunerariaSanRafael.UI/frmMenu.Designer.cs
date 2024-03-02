namespace FunerariaSanRafael.UI
{
    partial class frmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.pnlMenu1 = new System.Windows.Forms.Panel();
            this.btnRutas = new System.Windows.Forms.Button();
            this.btnMenuSinc = new System.Windows.Forms.Button();
            this.btnRecibos = new System.Windows.Forms.Button();
            this.btnLiquidacion = new System.Windows.Forms.Button();
            this.btnAfiliados = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlExe = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlExe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu1
            // 
            this.pnlMenu1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(249)))));
            this.pnlMenu1.Controls.Add(this.btnRutas);
            this.pnlMenu1.Controls.Add(this.btnMenuSinc);
            this.pnlMenu1.Controls.Add(this.btnRecibos);
            this.pnlMenu1.Controls.Add(this.btnLiquidacion);
            this.pnlMenu1.Controls.Add(this.btnAfiliados);
            this.pnlMenu1.Controls.Add(this.pictureBox1);
            this.pnlMenu1.Controls.Add(this.panel2);
            this.pnlMenu1.Location = new System.Drawing.Point(23, 18);
            this.pnlMenu1.Margin = new System.Windows.Forms.Padding(1);
            this.pnlMenu1.Name = "pnlMenu1";
            this.pnlMenu1.Size = new System.Drawing.Size(256, 663);
            this.pnlMenu1.TabIndex = 0;
            // 
            // btnRutas
            // 
            this.btnRutas.AutoEllipsis = true;
            this.btnRutas.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRutas.FlatAppearance.BorderSize = 0;
            this.btnRutas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRutas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.btnRutas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRutas.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRutas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnRutas.Location = new System.Drawing.Point(40, 284);
            this.btnRutas.Margin = new System.Windows.Forms.Padding(1);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Size = new System.Drawing.Size(173, 37);
            this.btnRutas.TabIndex = 16;
            this.btnRutas.Text = "Mantenimiento";
            this.btnRutas.UseVisualStyleBackColor = true;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // btnMenuSinc
            // 
            this.btnMenuSinc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuSinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnMenuSinc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnMenuSinc.FlatAppearance.BorderSize = 2;
            this.btnMenuSinc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSinc.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMenuSinc.ForeColor = System.Drawing.Color.White;
            this.btnMenuSinc.Location = new System.Drawing.Point(68, 95);
            this.btnMenuSinc.Margin = new System.Windows.Forms.Padding(1);
            this.btnMenuSinc.Name = "btnMenuSinc";
            this.btnMenuSinc.Size = new System.Drawing.Size(124, 24);
            this.btnMenuSinc.TabIndex = 15;
            this.btnMenuSinc.Text = "Sincronizar";
            this.btnMenuSinc.UseVisualStyleBackColor = false;
            this.btnMenuSinc.Click += new System.EventHandler(this.btnMenuSinc_Click);
            // 
            // btnRecibos
            // 
            this.btnRecibos.AutoEllipsis = true;
            this.btnRecibos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRecibos.FlatAppearance.BorderSize = 0;
            this.btnRecibos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRecibos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.btnRecibos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecibos.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRecibos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnRecibos.Location = new System.Drawing.Point(40, 168);
            this.btnRecibos.Margin = new System.Windows.Forms.Padding(1);
            this.btnRecibos.Name = "btnRecibos";
            this.btnRecibos.Size = new System.Drawing.Size(173, 37);
            this.btnRecibos.TabIndex = 0;
            this.btnRecibos.Text = "Recibos";
            this.btnRecibos.UseVisualStyleBackColor = true;
            this.btnRecibos.Click += new System.EventHandler(this.btnRecibos_Click);
            // 
            // btnLiquidacion
            // 
            this.btnLiquidacion.AutoEllipsis = true;
            this.btnLiquidacion.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLiquidacion.FlatAppearance.BorderSize = 0;
            this.btnLiquidacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLiquidacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.btnLiquidacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiquidacion.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLiquidacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnLiquidacion.Location = new System.Drawing.Point(40, 245);
            this.btnLiquidacion.Margin = new System.Windows.Forms.Padding(1);
            this.btnLiquidacion.Name = "btnLiquidacion";
            this.btnLiquidacion.Size = new System.Drawing.Size(173, 37);
            this.btnLiquidacion.TabIndex = 3;
            this.btnLiquidacion.Text = "Liquidación";
            this.btnLiquidacion.UseVisualStyleBackColor = true;
            this.btnLiquidacion.Click += new System.EventHandler(this.btnLiquidacion_Click);
            // 
            // btnAfiliados
            // 
            this.btnAfiliados.AutoEllipsis = true;
            this.btnAfiliados.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAfiliados.FlatAppearance.BorderSize = 0;
            this.btnAfiliados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAfiliados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.btnAfiliados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfiliados.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAfiliados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnAfiliados.Location = new System.Drawing.Point(40, 207);
            this.btnAfiliados.Margin = new System.Windows.Forms.Padding(1);
            this.btnAfiliados.Name = "btnAfiliados";
            this.btnAfiliados.Size = new System.Drawing.Size(173, 37);
            this.btnAfiliados.TabIndex = 2;
            this.btnAfiliados.Text = "Afiliados";
            this.btnAfiliados.UseVisualStyleBackColor = true;
            this.btnAfiliados.Click += new System.EventHandler(this.btnAfiliados_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(15, 582);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 68);
            this.panel2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 6.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label3.Location = new System.Drawing.Point(66, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Versión 1.0.0 | 2022";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(73)))), ((int)(((byte)(182)))));
            this.label2.Location = new System.Drawing.Point(61, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Módulo de Recibos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.label1.Location = new System.Drawing.Point(52, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Funeraria San Rafael";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlExe
            // 
            this.pnlExe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExe.AutoScroll = true;
            this.pnlExe.Controls.Add(this.pictureBox2);
            this.pnlExe.Location = new System.Drawing.Point(294, 100);
            this.pnlExe.Margin = new System.Windows.Forms.Padding(1);
            this.pnlExe.Name = "pnlExe";
            this.pnlExe.Size = new System.Drawing.Size(1036, 581);
            this.pnlExe.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::FunerariaSanRafael.UI.Properties.Resources.logo_azul;
            this.pictureBox2.Location = new System.Drawing.Point(258, 129);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(520, 335);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(294, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(1036, 69);
            this.panel1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 6.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(73)))), ((int)(((byte)(182)))));
            this.label5.Location = new System.Drawing.Point(988, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(45, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Usuario";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(922, 38);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNombre.Size = new System.Drawing.Size(111, 15);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre de usuario";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 25);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 18);
            this.lblTitulo.TabIndex = 4;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1345, 694);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlExe);
            this.Controls.Add(this.pnlMenu1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MinimumSize = new System.Drawing.Size(799, 408);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funeraria San Rafael";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.pnlMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlExe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Panel pnlMenu1;
        private Panel panel2;
        private ContextMenuStrip contextMenuStrip1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnRecibos;
        private Button btnLiquidacion;
        private Button btnAfiliados;
        private Panel pnlExe;
        private Panel panel1;
        private Label lblTitulo;
        private Label label5;
        private Label lblNombre;
        private Panel panel3;
        private PictureBox pictureBox2;
        private Button btnMenuSinc;
        private Button btnRutas;
    }
}