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

namespace RoyakLab1
{
    public partial class Form1 : Form
    {
        private IGraphicsBuilder GraphicsBuilder;

        public Form1()
        {
            InitializeComponent();
            GraphicsBuilder = new GraphicsBuilder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Buttom(object sender, EventArgs e)
        {
            var myBrush = new SolidBrush(Color.Aqua);
            var formGraphics = CreateGraphics();
            var h = 200;
            var w = 300;
            if (Int32.TryParse(textBox1.Text, out var numValue1))
            {
                h = numValue1;
            }

            if (Int32.TryParse(textBox2.Text, out var numValue2))
            {
                w = numValue2;
            }

            formGraphics.Clear(Color.White);
            formGraphics.DrawPath(new Pen(Color.Black), GraphicsBuilder.GetPath());
            myBrush.Dispose();
      }
        
    }
}
