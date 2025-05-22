namespace ProyectoGrupo5
{
    partial class Registro
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
            label1 = new Label();
            label2 = new Label();
            textNombre = new TextBox();
            label3 = new Label();
            textApellido = new TextBox();
            label4 = new Label();
            textNumeroTelefono = new TextBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label5 = new Label();
            textCorreoElectronico = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textBoxusuario = new TextBox();
            textBoxcontrasena = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(12, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1005, 468);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Fondo;
            pictureBox2.Location = new Point(567, 78);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(450, 469);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(179, 90);
            label1.Name = "label1";
            label1.Size = new Size(220, 23);
            label1.TabIndex = 3;
            label1.Text = "Sign Up to TASKREADY";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(69, 125);
            label2.Name = "label2";
            label2.Size = new Size(70, 18);
            label2.TabIndex = 4;
            label2.Text = "Nombre :";
            // 
            // textNombre
            // 
            textNombre.Location = new Point(69, 146);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(153, 23);
            textNombre.TabIndex = 5;
            textNombre.Validating += textNombre_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(314, 125);
            label3.Name = "label3";
            label3.Size = new Size(70, 18);
            label3.TabIndex = 6;
            label3.Text = "Apellido :";
            // 
            // textApellido
            // 
            textApellido.Location = new Point(314, 146);
            textApellido.Name = "textApellido";
            textApellido.Size = new Size(202, 23);
            textApellido.TabIndex = 7;
            textApellido.Validating += textApellido_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(69, 172);
            label4.Name = "label4";
            label4.Size = new Size(138, 18);
            label4.TabIndex = 8;
            label4.Text = "Numero Telefonico :";
            // 
            // textNumeroTelefono
            // 
            textNumeroTelefono.Location = new Point(69, 193);
            textNumeroTelefono.Name = "textNumeroTelefono";
            textNumeroTelefono.Size = new Size(153, 23);
            textNumeroTelefono.TabIndex = 9;
            textNumeroTelefono.Validating += textNumeroTelefono_Validating;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.White;
            radioButton1.Location = new Point(69, 293);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(89, 19);
            radioButton1.TabIndex = 10;
            radioButton1.TabStop = true;
            radioButton1.Text = "New Cliente";
            radioButton1.UseVisualStyleBackColor = false;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.White;
            radioButton2.Location = new Point(213, 293);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(108, 19);
            radioButton2.TabIndex = 11;
            radioButton2.TabStop = true;
            radioButton2.Text = "New Trabajador";
            radioButton2.UseVisualStyleBackColor = false;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(69, 219);
            label5.Name = "label5";
            label5.Size = new Size(132, 18);
            label5.TabIndex = 12;
            label5.Text = "Correo Electronico :";
            // 
            // textCorreoElectronico
            // 
            textCorreoElectronico.Location = new Point(69, 240);
            textCorreoElectronico.Name = "textCorreoElectronico";
            textCorreoElectronico.Size = new Size(252, 23);
            textCorreoElectronico.TabIndex = 13;
            textCorreoElectronico.Validating += textCorreoElectronico_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(69, 357);
            label6.Name = "label6";
            label6.Size = new Size(111, 18);
            label6.TabIndex = 14;
            label6.Text = "Nuevo Usuario :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(69, 404);
            label7.Name = "label7";
            label7.Size = new Size(137, 18);
            label7.TabIndex = 15;
            label7.Text = "Nueva Contraseña :";
            // 
            // textBoxusuario
            // 
            textBoxusuario.Location = new Point(69, 378);
            textBoxusuario.Name = "textBoxusuario";
            textBoxusuario.Size = new Size(252, 23);
            textBoxusuario.TabIndex = 16;
            textBoxusuario.Validating += textBoxusuario_Validating;
            // 
            // textBoxcontrasena
            // 
            textBoxcontrasena.Location = new Point(69, 425);
            textBoxcontrasena.Name = "textBoxcontrasena";
            textBoxcontrasena.Size = new Size(252, 23);
            textBoxcontrasena.TabIndex = 17;
            textBoxcontrasena.Validating += textBoxcontrasena_Validating;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "COCINERO", "AYUDANTE DE COCINA", "DECORADOR", "AYUDANTE DE DECORACION", "REPONEDOR", "RESPONSABLE DE EQUIPOS" });
            comboBox1.Location = new Point(350, 289);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(166, 23);
            comboBox1.TabIndex = 18;
            comboBox1.Text = "Cargo";
            // 
            // button1
            // 
            button1.Location = new Point(1144, 589);
            button1.Name = "button1";
            button1.Size = new Size(350, 680);
            button1.TabIndex = 19;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 192, 192);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Berlin Sans FB", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(480, 465);
            button2.Name = "button2";
            button2.Size = new Size(81, 30);
            button2.TabIndex = 20;
            button2.Text = "REGRESAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(192, 255, 192);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Berlin Sans FB", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(480, 501);
            button3.Name = "button3";
            button3.Size = new Size(81, 30);
            button3.TabIndex = 21;
            button3.Text = "REGISTRAR";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Registro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1029, 611);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBoxcontrasena);
            Controls.Add(textBoxusuario);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textCorreoElectronico);
            Controls.Add(label5);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textNumeroTelefono);
            Controls.Add(label4);
            Controls.Add(textApellido);
            Controls.Add(label3);
            Controls.Add(textNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Registro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private TextBox textNombre;
        private Label label3;
        private TextBox textApellido;
        private Label label4;
        private TextBox textNumeroTelefono;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label5;
        private TextBox textCorreoElectronico;
        private Label label6;
        private Label label7;
        private TextBox textBoxusuario;
        private TextBox textBoxcontrasena;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}