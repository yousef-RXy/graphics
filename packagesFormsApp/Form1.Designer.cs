namespace packagesFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            btnDraw = new Button();
            textBox5 = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(70, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(552, 384);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Highlight;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox1.Location = new Point(215, 417);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "X0";
            textBox1.Size = new Size(50, 29);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Highlight;
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox2.Location = new Point(278, 417);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Y0";
            textBox2.Size = new Size(50, 29);
            textBox2.TabIndex = 1;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Highlight;
            textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox3.Location = new Point(343, 417);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "X1";
            textBox3.Size = new Size(50, 29);
            textBox3.TabIndex = 2;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.Highlight;
            textBox4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox4.Location = new Point(409, 417);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Y1";
            textBox4.Size = new Size(50, 29);
            textBox4.TabIndex = 3;
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDraw
            // 
            btnDraw.BackColor = Color.SkyBlue;
            btnDraw.Location = new Point(579, 412);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(80, 30);
            btnDraw.TabIndex = 5;
            btnDraw.Text = "Draw";
            btnDraw.UseVisualStyleBackColor = false;
            btnDraw.Click += btnDraw_Click;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.ControlLight;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(2, 418);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Enter Coordinates :";
            textBox5.Size = new Size(196, 26);
            textBox5.TabIndex = 6;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(475, 412);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(50, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "DDA";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(475, 433);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(85, 19);
            checkBox2.TabIndex = 8;
            checkBox2.Text = "Bresenham";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(698, 452);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(textBox5);
            Controls.Add(btnDraw);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button btnDraw;
        private TextBox textBox5;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
    }
}
