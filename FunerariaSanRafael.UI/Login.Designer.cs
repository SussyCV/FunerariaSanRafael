namespace FunerariaSanRafael.UI
{
    partial class Login
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
            this.btnLoginIniciaSesion = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoginContraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoginUsuario = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.btnLoginIniciaSesion);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtLoginContraseña);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtLoginUsuario);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 388);
            this.panel1.TabIndex = 0;
            // 
            // btnLoginIniciaSesion
            // 
            this.btnLoginIniciaSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoginIniciaSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnLoginIniciaSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.btnLoginIniciaSesion.FlatAppearance.BorderSize = 2;
            this.btnLoginIniciaSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginIniciaSesion.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoginIniciaSesion.ForeColor = System.Drawing.Color.White;
            this.btnLoginIniciaSesion.Location = new System.Drawing.Point(500, 279);
            this.btnLoginIniciaSesion.Margin = new System.Windows.Forms.Padding(1);
            this.btnLoginIniciaSesion.Name = "btnLoginIniciaSesion";
            this.btnLoginIniciaSesion.Size = new System.Drawing.Size(151, 29);
            this.btnLoginIniciaSesion.TabIndex = 2;
            this.btnLoginIniciaSesion.Text = "Iniciar Sesión";
            this.btnLoginIniciaSesion.UseVisualStyleBackColor = false;
            this.btnLoginIniciaSesion.Click += new System.EventHandler(this.btnLoginIniciaSesion_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.label5.Location = new System.Drawing.Point(481, 215);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.label4.Location = new System.Drawing.Point(481, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Usuario";
            // 
            // txtLoginContraseña
            // 
            this.txtLoginContraseña.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtLoginContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(73)))), ((int)(((byte)(182)))));
            this.txtLoginContraseña.Location = new System.Drawing.Point(481, 233);
            this.txtLoginContraseña.Margin = new System.Windows.Forms.Padding(1);
            this.txtLoginContraseña.Name = "txtLoginContraseña";
            this.txtLoginContraseña.PasswordChar = '*';
            this.txtLoginContraseña.Size = new System.Drawing.Size(182, 22);
            this.txtLoginContraseña.TabIndex = 1;
            this.txtLoginContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoginContraseña_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(73)))), ((int)(((byte)(182)))));
            this.label1.Location = new System.Drawing.Point(516, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Inicio de Sesión";
            // 
            // txtLoginUsuario
            // 
            this.txtLoginUsuario.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtLoginUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(73)))), ((int)(((byte)(182)))));
            this.txtLoginUsuario.Location = new System.Drawing.Point(481, 174);
            this.txtLoginUsuario.Margin = new System.Windows.Forms.Padding(1);
            this.txtLoginUsuario.Name = "txtLoginUsuario";
            this.txtLoginUsuario.Size = new System.Drawing.Size(182, 22);
            this.txtLoginUsuario.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(249)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 388);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FunerariaSanRafael.UI.Properties.Resources.Funeraria_Logo_blanco;
            this.pictureBox1.Location = new System.Drawing.Point(44, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 6.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.label3.Location = new System.Drawing.Point(157, 370);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Versión 1.0.0 | 2022";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(73)))), ((int)(((byte)(182)))));
            this.label2.Location = new System.Drawing.Point(152, 353);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Módulo de Recibos";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 388);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(763, 447);
            this.MinimumSize = new System.Drawing.Size(763, 408);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private TextBox txtLoginUsuario;
        private Label label5;
        private Label label4;
        private TextBox txtLoginContraseña;
        private Label label1;
        private Button btnLoginIniciaSesion;
    }
}