namespace ProyectoGrupo5
{
    partial class Sobrenosotros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sobrenosotros));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(12, 368);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(264, 231);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Blue;
            label1.Font = new Font("Berlin Sans FB Demi", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightCyan;
            label1.Location = new Point(500, 46);
            label1.Name = "label1";
            label1.Size = new Size(366, 43);
            label1.TabIndex = 1;
            label1.Text = "QUE ES TASKREADY?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Berlin Sans FB", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(112, 141);
            label2.Name = "label2";
            label2.Size = new Size(795, 187);
            label2.TabIndex = 2;
            label2.Text = resources.GetString("label2.Text");
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.System;
            button1.ForeColor = Color.Azure;
            button1.ImageAlign = ContentAlignment.TopLeft;
            button1.Location = new Point(879, 561);
            button1.Name = "button1";
            button1.Size = new Size(122, 38);
            button1.TabIndex = 3;
            button1.Text = "EVENTOS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = Properties.Resources.task1;
            pictureBox2.Location = new Point(913, 280);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(106, 119);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Blue;
            pictureBox3.Location = new Point(333, 35);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(699, 66);
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // Sobrenosotros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1029, 611);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Name = "Sobrenosotros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sobrenosotros";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Button button1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}