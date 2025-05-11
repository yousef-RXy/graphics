using System;
using System.Drawing;
using System.Windows.Forms;

namespace Circle_Ellipse
{
    public partial class Form1 : Form
    {
        private bool shouldDrawCircle = false;
        private bool shouldDrawEllipse = false;

        private int xCenter, yCenter, radius;
        private int rx, ry;

        public Form1()
        {
            InitializeComponent();

            ellipseCheckBox.CheckedChanged += EllipseCheckBox_CheckedChanged;

            ToggleInputFields(false);
        }

        private void EllipseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleInputFields(ellipseCheckBox.Checked);
        }

        private void ToggleInputFields(bool isEllipse)
        {
            radiusTextBox.Visible = !isEllipse;
            radiusXTextBox.Visible = isEllipse;
            radiusYTextBox.Visible = isEllipse;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                xCenter = int.Parse(xCenterTextBox.Text);
                yCenter = int.Parse(yCenterTextBox.Text);
                shouldDrawEllipse = ellipseCheckBox.Checked;
                shouldDrawCircle = !shouldDrawEllipse;

                if (shouldDrawEllipse)
                {
                    rx = int.Parse(radiusXTextBox.Text);
                    ry = int.Parse(radiusYTextBox.Text);
                    if (rx <= 0 || ry <= 0)
                    {
                        MessageBox.Show("Please enter positive values for ellipse radii.");
                        return;
                    }
                }
                else
                {
                    radius = int.Parse(radiusTextBox.Text);
                    if (radius <= 0)
                    {
                        MessageBox.Show("Please enter a positive value for circle radius.");
                        return;
                    }
                }

                drawingPanel.Invalidate();
            }
            catch
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            int unit = 1;
            int centerX = drawingPanel.Width / 2;
            int centerY = drawingPanel.Height / 2;

            DrawAxes(e.Graphics);

            if (shouldDrawCircle)
            {
                DrawCircleBresenham(e.Graphics, xCenter, yCenter, radius, unit, centerX, centerY);
            }
            else if (shouldDrawEllipse)
            {
                DrawEllipseMidpoint(e.Graphics, xCenter, yCenter, rx, ry, unit, centerX, centerY);
            }
        }

        private void DrawAxes(Graphics g)
        {
            int centerX = drawingPanel.Width / 2;
            int centerY = drawingPanel.Height / 2;
            Pen pen = new Pen(Color.Black, 1);

            g.DrawLine(pen, 0, centerY, drawingPanel.Width, centerY);  
            g.DrawLine(pen, centerX, 0, centerX, drawingPanel.Height); 
        }

        private void DrawPixel(Graphics g, int x, int y, int unit, int centerX, int centerY)
        {
            int screenX = centerX + x * unit;
            int screenY = centerY - y * unit;
            g.FillRectangle(Brushes.Black, screenX, screenY, 2, 2);
        }

        private void DrawCircleBresenham(Graphics g, int xc, int yc, int r, int unit, int centerX, int centerY)
        {
            int x = 0, y = r;
            int d = 3 - 2 * r;

            while (x <= y)
            {
                DrawCirclePoints(g, xc, yc, x, y, unit, centerX, centerY);
                if (d < 0)
                    d += 4 * x + 6;
                else
                {
                    d += 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }
        }

        private void DrawCirclePoints(Graphics g, int xc, int yc, int x, int y, int unit, int centerX, int centerY)
        {
            DrawPixel(g, xc + x, yc + y, unit, centerX, centerY);
            DrawPixel(g, xc - x, yc + y, unit, centerX, centerY);
            DrawPixel(g, xc + x, yc - y, unit, centerX, centerY);
            DrawPixel(g, xc - x, yc - y, unit, centerX, centerY);
            DrawPixel(g, xc + y, yc + x, unit, centerX, centerY);
            DrawPixel(g, xc - y, yc + x, unit, centerX, centerY);
            DrawPixel(g, xc + y, yc - x, unit, centerX, centerY);
            DrawPixel(g, xc - y, yc - x, unit, centerX, centerY);
        }

        private void DrawEllipseMidpoint(Graphics g, int xc, int yc, int rx, int ry, int unit, int centerX, int centerY)
        {
            int x = 0;
            int y = ry;
            double rx2 = rx * rx;
            double ry2 = ry * ry;
            double p1 = ry2 - rx2 * ry + 0.25 * rx2;
            double dx = 2 * ry2 * x;
            double dy = 2 * rx2 * y;

            while (dx < dy)
            {
                DrawEllipsePoints(g, xc, yc, x, y, unit, centerX, centerY);
                x++;
                dx += 2 * ry2;
                if (p1 < 0)
                {
                    p1 += dx + ry2;
                }
                else
                {
                    y--;
                    dy -= 2 * rx2;
                    p1 += dx - dy + ry2;
                }
            }

            double p2 = ry2 * (x + 0.5) * (x + 0.5) + rx2 * (y - 1) * (y - 1) - rx2 * ry2;
            while (y >= 0)
            {
                DrawEllipsePoints(g, xc, yc, x, y, unit, centerX, centerY);
                y--;
                dy -= 2 * rx2;
                if (p2 > 0)
                {
                    p2 += rx2 - dy;
                }
                else
                {
                    x++;
                    dx += 2 * ry2;
                    p2 += dx - dy + rx2;
                }
            }
        }

        private void DrawEllipsePoints(Graphics g, int xc, int yc, int x, int y, int unit, int centerX, int centerY)
        {
            DrawPixel(g, xc + x, yc + y, unit, centerX, centerY);
            DrawPixel(g, xc - x, yc + y, unit, centerX, centerY);
            DrawPixel(g, xc + x, yc - y, unit, centerX, centerY);
            DrawPixel(g, xc - x, yc - y, unit, centerX, centerY);
        }
    }
}
