using System;
using System.Drawing;
using System.Windows.Forms;

namespace packagesFormsApp
{
    public partial class Form1 : Form
    {
        private int x0, y0, x1, y1;
        private int unit = 13;

        public Form1()
        {
            InitializeComponent();

            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox2_CheckedChanged;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                checkBox2.Checked = false;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox1.Checked = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int w = panel1.Width;
            int h = panel1.Height;
            int centerX = w / 2;
            int centerY = h / 2;

            Pen axisPen = new(Color.Gray, 1);
            Pen circlePen = new(Color.LightBlue, 1);
            Pen gridPen = new(Color.LightGray, 1);
            Font font = new("Arial", 7);
            Brush brush = Brushes.Black;

            g.DrawLine(axisPen, 0, centerY, w, centerY);
            g.DrawLine(axisPen, centerX, 0, centerX, h);


            for (int x = -w / 2; x <= w / 2; x += unit)
            {
                g.DrawLine(gridPen, centerX + x, 0, centerX + x, h);
                if (x != 0)
                    g.DrawString((x / unit).ToString(), font, brush, centerX + x + 2, centerY + 2);
            }

            for (int y = -h / 2; y <= h / 2; y += unit)
            {
                g.DrawLine(gridPen, 0, centerY - y, w, centerY - y);
                if (y != 0)
                    g.DrawString((y / unit).ToString(), font, brush, centerX + 2, centerY - y + 2);
            }

            if (checkBox1.Checked)
                lineDDA_Unit(x0, y0, x1, y1, g, unit, centerX, centerY);
            else if (checkBox2.Checked)
                lineBresenham(x0, y0, x1, y1, g, unit, centerX, centerY);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                x0 = int.Parse(textBox1.Text);
                y0 = int.Parse(textBox2.Text);
                x1 = int.Parse(textBox3.Text);
                y1 = int.Parse(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Please enter valid integer coordinates.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                MessageBox.Show("Please select an algorithm (DDA or Bresenham).",
                                "No Algorithm Selected",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            panel1.Invalidate();
        }

        private void lineBresenham(int x0, int y0, int xEnd, int yEnd, Graphics g, int unit, int centerX, int centerY)
        {
            x0 *= unit;
            y0 *= unit;
            xEnd *= unit;
            yEnd *= unit;

            int dx = Math.Abs(xEnd - x0);
            int dy = Math.Abs(yEnd - y0);
            int sx = x0 < xEnd ? 1 : -1;
            int sy = y0 < yEnd ? 1 : -1;

            int x = x0, y = y0;
            bool isSteep = dy > dx;

            if (isSteep)
            {
                int tmp = dx; dx = dy; dy = tmp;
            }

            int p = 2 * dy - dx;

            SolidBrush brush = new SolidBrush(Color.Red);

            for (int i = 0; i <= dx; i++)
            {
                int screenX = centerX + x;
                int screenY = centerY - y;

                g.FillRectangle(brush, screenX, screenY, 2, 2);

                if (p >= 0)
                {
                    if (isSteep)
                        x += sx;
                    else
                        y += sy;
                    p -= 2 * dx;
                }

                if (isSteep)
                    y += sy;
                else
                    x += sx;

                p += 2 * dy;
            }
        }



        private void lineDDA_Unit(float x0, float y0, float xEnd, float yEnd, Graphics g, int unit, int centerX, int centerY)
        {
            float dx = xEnd - x0;
            float dy = yEnd - y0;
            int steps = (int)(Math.Max(Math.Abs(dx), Math.Abs(dy)) * unit);

            float xIncrement = dx / steps;
            float yIncrement = dy / steps;

            float x = x0;
            float y = y0;

            SolidBrush brush = new SolidBrush(Color.BlueViolet);

            for (int k = 0; k <= steps; k++)
            {
                int screenX = (int)Math.Round(centerX + x * unit);
                int screenY = (int)Math.Round(centerY - y * unit);

                g.FillRectangle(brush, screenX, screenY, 2, 2);

                x += xIncrement;
                y += yIncrement;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
