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

        public Form1()
        {
            
            InitializeComponent();
            GraphicsBuilder = new GraphicsBuilder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
        }

        private void Form1_Buttom(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            GraphicsBuilder.ParseExpression(textBox3.Text, pictureBox1.Height, pictureBox1.Width);
            var myBrush = new SolidBrush(Color.Aqua);
            var gg = GraphicsBuilder.GetPath();
            g.DrawPath(new Pen(Color.Black), gg);
            myBrush.Dispose();
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
