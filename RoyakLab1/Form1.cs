using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;

namespace RoyakLab1
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private IGraphicsBuilder GraphicsBuilder;
        private int factor = 100;
        private int deltainc = 0;

        private void picturebox1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            deltainc += e.Delta;
            if (factor < 204800 && factor > 12)
            {
                if (e.Delta > 0)
                    factor *= 2;
                else
                    factor /= 2;
                label2.Text = factor.ToString();
                DrawGraph();
            }
            else
            {
                deltainc -= e.Delta;
                if (e.Delta > 0)
                    factor /= 2;
                else
                    factor *= 2;
            }
          }

        public Form1()
        {

            InitializeComponent();
            GraphicsBuilder = new GraphicsBuilder();
            this.pictureBox1.MouseWheel += picturebox1_MouseWheel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
        }

        private void DrawGraph()
        {
            g.Clear(Color.White);
            GraphicsBuilder.ParseExpression(textBox3.Text, pictureBox1.Height, pictureBox1.Width, factor);
            var myBrush = new SolidBrush(Color.Aqua);
            var gg = GraphicsBuilder.GetPath();
            drawAxis();
            g.DrawPath(new Pen(Color.Black), gg);
            myBrush.Dispose();
        }
        private void Form1_Buttom(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //  Brush aBrush = (Brush)Brushes.Black;
            //  var posX = pictureBox1.PointToClient(Cursor.Position).X;
            //  var posY = pictureBox1.PointToClient(Cursor.Position).Y;
            //
            //  label1.Text = Convert.ToString(posX + ";"+ posY);
            //  GraphicsBuilder.AddPoint(PointToClient(Cursor.Position));
            //  g.FillRectangle(aBrush, posX, posY, 2, 2);

        }
        private void drawAxis()
        {
            g.DrawLine(new Pen(Color.Black), 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            for (int i = 0; i < pictureBox1.Width; i += factor)
            {
                g.DrawLine(new Pen(Color.Black), i, pictureBox1.Height / 2 - 2, i, pictureBox1.Height / 2 + 2);
                var ai = i / factor;
                g.DrawString($"{ai}", new Font("Arial", 11), Brushes.Black, i, pictureBox1.Height / 2 + 2);
            }
            g.DrawLine(new Pen(Color.Black), 1, pictureBox1.Height, 1, 0);
            for (int i = pictureBox1.Height / 2+ factor; i < pictureBox1.Height; i += factor)
            {
                g.DrawLine(new Pen(Color.Black), 0, i, 2, i);
                g.DrawLine(new Pen(Color.Black), 0, pictureBox1.Height - i, 2, pictureBox1.Height - i);
                var ai = (i - pictureBox1.Height/2) / factor;
                g.DrawString($"-{ai}", new Font("Arial", 11), Brushes.Black, 2,i -1);
                g.DrawString($"{ai}", new Font("Arial", 11), Brushes.Black, 2, pictureBox1.Height - i -1);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = Convert.ToString("x:" + pictureBox1.PointToClient(Cursor.Position).X + ";y:" + pictureBox1.PointToClient(Cursor.Position).Y);
        }

    }
}
