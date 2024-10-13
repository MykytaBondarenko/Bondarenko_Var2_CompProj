using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bondarenko_Var2_CompProj
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Graphics gr;
        Bitmap gr_bmp;
        double x, y, t;
        int i1, i2, j1, j2, x1, x2, y1, y2, n;

        private void button5_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
            x1--; x2--;
            system_koordinat(x1, x2, y1, y2);
        } // вправо

        private void button7_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
            y1++; y2++;
            system_koordinat(x1, x2, y1, y2);
        } // вниз

        private void button6_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
            x1++; x2++; // двигаем влево на 1
            system_koordinat(x1, x2, y1, y2);
        } // вліво

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } // вихід з форми

        private void button4_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
            y1--; y2--;
            system_koordinat(x1, x2, y1, y2);
        } // вгору

        private void button3_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
            x1--; x2++;
            y1--; y2++;
            system_koordinat(x1, x2, y1, y2);
        } // масштаб --

        private void button2_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
            x1++; x2--;
            y1++; y2--;
            system_koordinat(x1, x2, y1, y2);
        } // масштаб ++

        int xtoi(double x)
        {
            int ii;
            ii = i1 + (int)Math.Truncate((x - x1) * ((i2 - i1) / (x2 - x1)));
            return ii;
        }

        int ytoi(double y)
        {
            int jj;
            jj = j2 + (int)Math.Truncate((y - y1) * (j1 - j2) / (y2 - y1));
            return jj;
        }

        void system_koordinat(double x1, double x2, double y1, double y2)
        {
            Pen pen_setka = new Pen(Brushes.LightBlue, 1);
            pen_setka.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            for (int p = (int)x1; p <= (int)x2; p++)
            {
                gr.DrawLine(pen_setka, xtoi(p), ytoi(y2), xtoi(p), ytoi(y1));
            }

            for (int p = (int)y1; p <= (int)y2; p++)
            {
                gr.DrawLine(pen_setka, xtoi(x1), ytoi(p), xtoi(x2), ytoi(p));
            }

            Pen pen_os = new Pen(Brushes.Blue, 1);
            pen_os.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen_os.StartCap = System.Drawing.Drawing2D.LineCap.Triangle;

            gr.DrawLine(pen_os, xtoi(x1), ytoi(0), xtoi(x2), ytoi(0));
            gr.DrawLine(pen_os, xtoi(0), ytoi(y1), xtoi(0), ytoi(y2));

            Font MyFont = new Font("arial", 8, FontStyle.Regular);
            for (int p = 1; p <= x2; p++) gr.DrawString(Convert.ToString(p), MyFont, Brushes.Blue, new Point(xtoi(p - 0.2), ytoi(-0.05)));
            for (int p = -1; p >= x1; p--) gr.DrawString(Convert.ToString(p), MyFont, Brushes.Blue, new Point(xtoi(p - 0.2), ytoi(-0.05)));
            for (int p = 0; p <= y2; p++) gr.DrawString(Convert.ToString(p), MyFont, Brushes.Blue, new Point(xtoi(-0.5), ytoi(p + 0.1)));
            for (int p = -1; p >= y1; p--) gr.DrawString(Convert.ToString(p), MyFont, Brushes.Blue, new Point(xtoi(-0.6), ytoi(p + 0.1)));
        } // система координат

        double fx(double xt, int a, int b, int c) // координата х точки параболи
        {
            double x = xt;
            return x;
        }

        double fy(double xt, int a, int b, int c) // координата у точки параболи
        {
            double y = a * Math.Pow(xt, 2) + b * xt + c;
            return y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);

            i1 = 0;
            j1 = 0;
            i2 = pictureBox1.Width - 1;
            j2 = pictureBox1.Height - 1;
            x1 = Convert.ToInt32(txtx1.Text);
            x2 = Convert.ToInt32(txtx2.Text);
            y1 = Convert.ToInt32(txty1.Text);
            y2 = Convert.ToInt32(txty2.Text);
            system_koordinat(x1, x2, y1, y2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lblR1.Text = "_";
            lblR2.Text = "_";
            int a1 = Convert.ToInt32(txta1.Text);
            int b1 = Convert.ToInt32(txtb1.Text);
            int c1 = Convert.ToInt32(txtc1.Text);
            int a2 = Convert.ToInt32(txta2.Text);
            int b2 = Convert.ToInt32(txtb2.Text);
            int c2 = Convert.ToInt32(txtc2.Text);

            gr.Clear(Color.White);
            i1 = 0;
            j1 = 0;
            i2 = pictureBox1.Width - 1;
            j2 = pictureBox1.Height - 1;
            n = pictureBox1.Width;

            double xR1 = 0, xR2 = 0, yR1 = 0, yR2 = 0, dot = 0, vertexX1 = 0, vertexX2 = 0, vertexY1 = 0, vertexY2 = 0, maxx = 0, maxy = 0, minx = 0, miny = 0;

            if (Math.Pow(b1 - b2, 2) - 4 * (a1 - a2) * (c1 - c2) > 0)
            {
                xR1 = (-(b1 - b2) + Math.Sqrt(Math.Pow(b1 - b2, 2) - 4 * (a1 - a2) * (c1 - c2))) / (2 * (a1 - a2));
                xR2 = (-(b1 - b2) - Math.Sqrt(Math.Pow(b1 - b2, 2) - 4 * (a1 - a2) * (c1 - c2))) / (2 * (a1 - a2));
                yR1 = a1 * Math.Pow(xR1, 2) + b1 * xR1 + c1;
                yR2 = a1 * Math.Pow(xR2, 2) + b1 * xR2 + c1;

                vertexX1 = -b1 / (2 * a1);                                   // знаходження координат висот парабол
                vertexY1 = a1 * Math.Pow(vertexX1, 2) + b1 * vertexX1 + c1;
                vertexX2 = -b2 / (2 * a2);
                vertexY2 = a2 * Math.Pow(vertexX2, 2) + b2 * vertexX2 + c2;

                maxx = vertexX1;                            // знаходження найбільшого х серед координат точок перетину та висот парабол
                if (vertexX2 > maxx) maxx = vertexX2;
                if (xR1 > maxx) maxx = xR1;
                if (xR2 > maxx) maxx = xR2;

                minx = vertexX1;                            // знаходження найменшого х серед координат точок перетину та висот парабол
                if (vertexX2 < minx) minx = vertexX2;
                if (xR1 < minx) minx = xR1;
                if (xR2 < minx) minx = xR2;

                maxy = vertexY1;                            // знаходження найбільшого у серед координат точок перетину та висот парабол
                if (vertexY2 > maxy) maxy = vertexY2;
                if (yR1 > maxy) maxy = yR1;
                if (yR2 > maxy) maxy = yR2;

                miny = vertexY1;                            // знаходження найменшого у серед координат точок перетину та висот парабол
                if (vertexY2 < miny) miny = vertexY2;
                if (yR1 < miny) miny = yR1;
                if (yR2 < miny) miny = yR2;

                lblR1.Text = "Параболи перетинаються в двох точках";
                lblR2.Text = "Перша: (" + Math.Round(xR1, 2) + ";" + Math.Round(yR1, 2) + "), друга: (" + Math.Round(xR2, 2) + ";" + Math.Round(yR2, 2) + ").";

                dot = 2;
            }
            else if (Math.Pow(b1 - b2, 2) - 4 * (a1 - a2) * (c1 - c2) == 0)
            {
                xR1 = (-(b1 - b2)) / (2 * (a1 - a2));
                yR1 = a1 * Math.Pow(xR1, 2) + b1 * xR1 + c1;
                lblR1.Text = "Параболи перетинаються в одній точці";
                lblR2.Text = "(" + Math.Round(xR1, 2) + ";" + Math.Round(yR1, 2) + ").";

                vertexX1 = -b1 / (2 * a1);
                vertexY1 = a1 * Math.Pow(vertexX1, 2) + b1 * vertexX1 + c1;
                vertexX2 = -b2 / (2 * a2);
                vertexY2 = a2 * Math.Pow(vertexX2, 2) + b2 * vertexX2 + c2;

                maxx = vertexX1;
                if (vertexX2 > maxx) maxx = vertexX2;
                if (xR1 > maxx) maxx = xR1;

                minx = vertexX1;
                if (vertexX2 < minx) minx = vertexX2;
                if (xR1 < minx) minx = xR1;

                maxy = vertexY1;
                if (vertexY2 > maxy) maxy = vertexY2;
                if (yR1 > maxy) maxy = yR1;

                miny = vertexY1;
                if (vertexY2 < miny) miny = vertexY2;
                if (yR1 < miny) miny = yR1;

                dot = 1;
            }
            else
            {
                vertexX1 = -b1 / (2 * a1);
                vertexY1 = a1 * Math.Pow(vertexX1, 2) + b1 * vertexX1 + c1;
                vertexX2 = -b2 / (2 * a2);
                vertexY2 = a2 * Math.Pow(vertexX2, 2) + b2 * vertexX2 + c2;

                maxx = vertexX1;
                if (vertexX2 > maxx) maxx = vertexX2;

                minx = vertexX1;
                if (vertexX2 < minx) minx = vertexX2;

                maxy = vertexY1;
                if (vertexY2 > maxy) maxy = vertexY2;

                miny = vertexY1;
                if (vertexY2 < miny) miny = vertexY2;

                lblR1.Text = "Параболи не перетинаються.";

                dot = 0;
            }

            x1 = Convert.ToInt32(Math.Floor(minx - 1)); // довжина осі х вліво визначаеться найменшим х - 1, округленим до меншого (щоб точка не лежала на границі PictureBox)
            x2 = Convert.ToInt32(Math.Ceiling(maxx + 1)); // довжина осі х вправо визначається найбільшим х + 1, округленим до більшого (щоб точка не лежала на границі PictureBox)
            y1 = Convert.ToInt32(Math.Floor(miny - 1)); // аналогічно з лівою границею х
            y2 = Convert.ToInt32(Math.Ceiling(maxy + 1)); // аналогічно з правою границею х

            system_koordinat(x1, x2, y1, y2);

            t = -2 * Math.PI;
            while (t < 2 * Math.PI)
            {
                gr.FillEllipse(Brushes.Orange, xtoi(fx(t, a1, b1, c1)), ytoi(fy(t, a1, b1, c1)), 3, 3);
                t = t + 0.001;
            }

            t = -2 * Math.PI;
            while (t < 2 * Math.PI)
            {
                gr.FillEllipse(Brushes.Green, xtoi(fx(t, a2, b2, c2)), ytoi(fy(t, a2, b2, c2)), 3, 3);
                t = t + 0.001;
            }

            if (dot == 2)
            {
                gr.FillEllipse(Brushes.Red, xtoi(xR1) - 3, ytoi(yR1) - 3, 7, 7); // позначає точки перетину парабол
                gr.FillEllipse(Brushes.Red, xtoi(xR2) - 3, ytoi(yR2) - 3, 7, 7);
            }
            else if (dot == 1) gr.FillEllipse(Brushes.Red, xtoi(xR1), ytoi(yR1), 5, 5);
        }
    }
}
