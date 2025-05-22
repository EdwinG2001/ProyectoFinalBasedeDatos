namespace ProyectoGrupo5
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textUsuario = new TextBox();
            textContrasena = new TextBox();
            button1 = new Button();
            btnIngreso = new Button();
            linkLabel1 = new LinkLabel();
            checkBox1 = new CheckBox();
            label3 = new Label();
            pictureBox4 = new PictureBox();
            pbMostrarContraseña = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMostrarContraseña).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(505, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 464);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = Properties.Resources.logo;
            pictureBox2.Location = new Point(84, 113);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(327, 359);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.Image = Properties.Resources.Persona;
            pictureBox3.Location = new Point(694, 113);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(93, 81);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Berlin Sans FB", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(633, 232);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 3;
            label1.Text = "USUARIO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Berlin Sans FB", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(633, 278);
            label2.Name = "label2";
            label2.Size = new Size(102, 17);
            label2.TabIndex = 4;
            label2.Text = "CONTRASEÑA";
            // 
            // textUsuario
            // 
            textUsuario.Location = new Point(633, 252);
            textUsuario.Name = "textUsuario";
            textUsuario.Size = new Size(192, 23);
            textUsuario.TabIndex = 5;
            // 
            // textContrasena
            // 
            textContrasena.Location = new Point(633, 296);
            textContrasena.Name = "textContrasena";
            textContrasena.PasswordChar = '●';
            textContrasena.Size = new Size(192, 23);
            textContrasena.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.SeaShell;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(678, 358);
            button1.Name = "button1";
            button1.Size = new Size(36, 28);
            button1.TabIndex = 7;
            button1.Text = "<--";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnIngreso
            // 
            btnIngreso.BackColor = Color.SeaShell;
            btnIngreso.FlatStyle = FlatStyle.Popup;
            btnIngreso.Font = new Font("Berlin Sans FB", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIngreso.Location = new Point(734, 358);
            btnIngreso.Name = "btnIngreso";
            btnIngreso.Size = new Size(91, 28);
            btnIngreso.TabIndex = 8;
            btnIngreso.Text = "INGRESAR";
            btnIngreso.UseVisualStyleBackColor = false;
            btnIngreso.Click += btnIngreso_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.White;
            linkLabel1.Font = new Font("Berlin Sans FB", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(621, 439);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(232, 15);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Registrarse en caso de no tener credenciales";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.White;
            checkBox1.Location = new Point(633, 399);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 10;
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Berlin Sans FB", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(654, 399);
            label3.Name = "label3";
            label3.Size = new Size(144, 13);
            label3.TabIndex = 11;
            label3.Text = "Acepta terminos y condiciones";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.White;
            pictureBox4.Image = Properties.Resources.Fondo;
            pictureBox4.Location = new Point(12, 67);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(494, 464);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            // 
            // pbMostrarContraseña
            // 
            pbMostrarContraseña.BackColor = Color.White;
            pbMostrarContraseña.Image = Properties.Resources.mostrar_contrasena;
            pbMostrarContraseña.Location = new Point(831, 296);
            pbMostrarContraseña.Name = "pbMostrarContraseña";
            pbMostrarContraseña.Size = new Size(22, 23);
            pbMostrarContraseña.SizeMode = PictureBoxSizeMode.StretchImage;
            pbMostrarContraseña.TabIndex = 13;
            pbMostrarContraseña.TabStop = false;
            pbMostrarContraseña.MouseDown += pbMostrarContraseña_MouseDown;
            pbMostrarContraseña.MouseUp += pbMostrarContraseña_MouseUp;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1029, 611);
            Controls.Add(pbMostrarContraseña);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(linkLabel1);
            Controls.Add(btnIngreso);
            Controls.Add(button1);
            Controls.Add(textContrasena);
            Controls.Add(textUsuario);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox4);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMostrarContraseña).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private TextBox textUsuario;
        private TextBox textContrasena;
        private Button button1;
        private Button btnIngreso;
        private LinkLabel linkLabel1;
        private CheckBox checkBox1;
        private Label label3;
        private PictureBox pictureBox4;
        private PictureBox pbMostrarContraseña;
    }
}