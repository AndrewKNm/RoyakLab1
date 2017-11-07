using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System;

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
