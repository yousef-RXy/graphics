namespace Circle_Ellipse
{
    partial class Form1
    {
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
            xCenterTextBox = new TextBox();
            yCenterTextBox = new TextBox();
            radiusTextBox = new TextBox();
            radiusXTextBox = new TextBox();
            radiusYTextBox = new TextBox();
            btnDraw = new Button();
            drawingPanel = new Panel();
            ellipseCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // xCenterTextBox
            // 
            xCenterTextBox.BackColor = SystemColors.ActiveCaption;
            xCenterTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            xCenterTextBox.Location = new Point(40, 671);
            xCenterTextBox.Name = "xCenterTextBox";
            xCenterTextBox.PlaceholderText = "X Center";
            xCenterTextBox.Size = new Size(100, 25);
            xCenterTextBox.TabIndex = 0;
            xCenterTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // yCenterTextBox
            // 
            yCenterTextBox.BackColor = SystemColors.ActiveCaption;
            yCenterTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            yCenterTextBox.Location = new Point(150, 671);
            yCenterTextBox.Name = "yCenterTextBox";
            yCenterTextBox.PlaceholderText = "Y Center";
            yCenterTextBox.Size = new Size(100, 25);
            yCenterTextBox.TabIndex = 1;
            yCenterTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // radiusTextBox
            // 
            radiusTextBox.BackColor = SystemColors.ActiveCaption;
            radiusTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            radiusTextBox.Location = new Point(260, 671);
            radiusTextBox.Name = "radiusTextBox";
            radiusTextBox.PlaceholderText = "Radius";
            radiusTextBox.Size = new Size(100, 25);
            radiusTextBox.TabIndex = 2;
            radiusTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // radiusXTextBox
            // 
            radiusXTextBox.BackColor = SystemColors.ActiveCaption;
            radiusXTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            radiusXTextBox.Location = new Point(399, 671);
            radiusXTextBox.Name = "radiusXTextBox";
            radiusXTextBox.PlaceholderText = "Radius X";
            radiusXTextBox.Size = new Size(100, 25);
            radiusXTextBox.TabIndex = 3;
            radiusXTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // radiusYTextBox
            // 
            radiusYTextBox.BackColor = SystemColors.ActiveCaption;
            radiusYTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            radiusYTextBox.Location = new Point(519, 671);
            radiusYTextBox.Name = "radiusYTextBox";
            radiusYTextBox.PlaceholderText = "Radius Y";
            radiusYTextBox.Size = new Size(100, 25);
            radiusYTextBox.TabIndex = 4;
            radiusYTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDraw
            // 
            btnDraw.BackColor = SystemColors.ButtonShadow;
            btnDraw.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnDraw.Location = new Point(734, 666);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(86, 33);
            btnDraw.TabIndex = 6;
            btnDraw.Text = "Draw Shape";
            btnDraw.UseVisualStyleBackColor = false;
            btnDraw.Click += btnDraw_Click;
            // 
            // drawingPanel
            // 
            drawingPanel.BackColor = Color.WhiteSmoke;
            drawingPanel.Location = new Point(28, 18);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(821, 639);
            drawingPanel.TabIndex = 7;
            drawingPanel.Paint += drawingPanel_Paint;
            // 
            // ellipseCheckBox
            // 
            ellipseCheckBox.AutoSize = true;
            ellipseCheckBox.Location = new Point(639, 675);
            ellipseCheckBox.Name = "ellipseCheckBox";
            ellipseCheckBox.Size = new Size(89, 19);
            ellipseCheckBox.TabIndex = 5;
            ellipseCheckBox.Text = "Draw Ellipse";
            ellipseCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(882, 711);
            Controls.Add(drawingPanel);
            Controls.Add(btnDraw);
            Controls.Add(ellipseCheckBox);
            Controls.Add(radiusYTextBox);
            Controls.Add(radiusXTextBox);
            Controls.Add(radiusTextBox);
            Controls.Add(yCenterTextBox);
            Controls.Add(xCenterTextBox);
            Name = "Form1";
            Text = "Circle and Ellipse Drawer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox xCenterTextBox;
        private System.Windows.Forms.TextBox yCenterTextBox;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.TextBox radiusXTextBox;
        private System.Windows.Forms.TextBox radiusYTextBox;
        private System.Windows.Forms.CheckBox ellipseCheckBox;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Panel drawingPanel;
    }
}
