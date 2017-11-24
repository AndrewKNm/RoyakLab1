using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class parameters
        {
            public double x { get; set; }
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LinkedList<Point> pointList = new LinkedList<Point>();
            var script = Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.Create<double>(TextBox.Text, Microsoft.CodeAnalysis.Scripting.ScriptOptions.Default.WithImports("System.Math").WithReferences(typeof(parameters).AssemblyQualifiedName), typeof(parameters));
            Microsoft.CodeAnalysis.Scripting.ScriptRunner<double> fun = script.CreateDelegate();
            for (int i = 0; i < DrawGrid.ActualWidth; i += 4)
            {
                double ax = (double)i / 100;
                var y = DrawGrid.ActualHeight/200 - (fun.Invoke(new parameters() { x = ax }).Result);
                pointList.AddLast(new Point(i, (int)(y * 100)));
            }

            var myPath = new Path
            {
                Stroke = Brushes.Black,
                StrokeThickness = 4,
                Data = Linearize(pointList)
            };

            DrawGrid.Children.Clear();
            DrawGrid.Children.Add(myPath);
            drawAxis();
        }

        public PathGeometry Linearize(LinkedList<Point> points)
        {
            var path = new PathGeometry();
            for (var point = points.First; point.Next != null; point = point.Next)
            {
                path.AddGeometry(new LineGeometry(point.Value, point.Next.Value));
            }
            return path;
        }
        private void drawAxis()
        {
            var myLine1 = new Line();
            myLine1.Stroke = Brushes.Black;
            myLine1.X1 = 0;
            myLine1.X2 = DrawGrid.ActualWidth;
            myLine1.Y1 = DrawGrid.ActualHeight / 2;
            myLine1.Y2 = DrawGrid.ActualHeight / 2;
            myLine1.StrokeThickness = 1;
            DrawGrid.Children.Add(myLine1);
            for (int i = 0; i < DrawGrid.ActualWidth; i += 100)
            {
                var myVLine = new Line();
                myVLine.Stroke = Brushes.Black;
                myVLine.X1 = i;
                myVLine.X2 = i;
                myVLine.Y1 = DrawGrid.ActualHeight / 2 - 2;
                myVLine.Y2 = DrawGrid.ActualHeight / 2 + 2;
                myVLine.StrokeThickness = 1;
                DrawGrid.Children.Add(myVLine);
                var ai = i / 100;
                string ts = $"{ai}";
                var txb = new TextBlock();
                txb.Text = ts;
                txb.Foreground = Brushes.Black;
                txb.Margin = new Thickness(i, DrawGrid.ActualHeight/2 +2, i, 0);
                DrawGrid.Children.Add(txb);
            }
            var myLine2 = new Line();
            myLine2.Stroke = Brushes.Black;
            myLine2.X1 = 1;
            myLine2.X2 = 1;
            myLine2.Y1 = DrawGrid.ActualHeight;
            myLine2.Y2 = 0;
            myLine2.StrokeThickness = 1;
            DrawGrid.Children.Add(myLine2);
            for (int i = (int)DrawGrid.ActualHeight / 2 + 100; i < DrawGrid.ActualHeight; i += 100)
            {
                var ai = (i - DrawGrid.ActualHeight / 2) / 100; ;
                

                var myHLine1 = new Line();
                myHLine1.Stroke = Brushes.Black;
                myHLine1.X1 = 0;
                myHLine1.X2 = 3;
                myHLine1.Y1 = i;
                myHLine1.Y2 = i;
                myHLine1.StrokeThickness = 1;
                DrawGrid.Children.Add(myHLine1);

                string ts = $"-{ai}";
                var txb1 = new TextBlock();
                txb1.Text = ts;
                txb1.Foreground = Brushes.Black;
                txb1.Margin = new Thickness(2, i-1, 2, 0);
                DrawGrid.Children.Add(txb1);

                var myHLine2 = new Line();
                myHLine2.Stroke = Brushes.Black;
                myHLine2.X1 = 0;
                myHLine2.X2 = 3;
                myHLine2.Y1 = DrawGrid.ActualHeight - i;
                myHLine2.Y2 = DrawGrid.ActualHeight - i;
                myHLine2.StrokeThickness = 1;
                DrawGrid.Children.Add(myHLine2);

                ts = $"{ai}";
                var txb2 = new TextBlock();
                txb2.Text = ts;
                txb2.Foreground = Brushes.Black;
                txb2.Margin = new Thickness(2, DrawGrid.ActualHeight - i - 1, 2, 0);
                DrawGrid.Children.Add(txb2);
            }
                //g.DrawLine(new Pen(Color.Black), 1, pictureBox1.Height, 1, 0);
                //for (int i = pictureBox1.Height / 2 + 100; i < pictureBox1.Height; i += 100)
                //{
                //    g.DrawLine(new Pen(Color.Black), 0, i, 2, i);
                //    g.DrawLine(new Pen(Color.Black), 0, pictureBox1.Height - i, 2, pictureBox1.Height - i);
                //    var ai = (i - pictureBox1.Height / 2) / 100;
                //    g.DrawString($"-{ai}", new Font("Arial", 11), Brushes.Black, 2, i - 1);
                //    g.DrawString($"{ai}", new Font("Arial", 11), Brushes.Black, 2, pictureBox1.Height - i - 1);
                //}
            }
    }
}
