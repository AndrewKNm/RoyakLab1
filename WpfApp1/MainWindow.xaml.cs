using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using org.mariuszgromada.math.mxparser;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        org.mariuszgromada.math.mxparser.Expression exp;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LinkedList<Point> pointList = new LinkedList<Point>();
            for (int i = 0; i < DrawGrid.ActualWidth; i += 4)
            {
                double ax = (double)i / 100;
                Argument x = new Argument($"x = {ax}");
                exp = new org.mariuszgromada.math.mxparser.Expression(TextBox.Text, x);
                var y = exp.calculate();
                y = -y + DrawGrid.ActualHeight/100;
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
    }
}
