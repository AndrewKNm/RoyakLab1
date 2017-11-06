using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Line objLine = new Line();

            objLine.Stroke = System.Windows.Media.Brushes.Black; //Umriss 
            objLine.Fill = System.Windows.Media.Brushes.Black; //Fuellung 

            //< Start-Point > 
            objLine.X1 = 0;
            objLine.Y1 = 0;
            //</ Start-Point > 

            //< End-Point > 
            objLine.X2 = Application.Current.MainWindow.ActualWidth - 50;
            objLine.Y2 = Application.Current.MainWindow.ActualHeight - 100;
            //</ End-Point > 

            DrawGrid.Children.Clear();
            //< show in maingrid > 
            DrawGrid.Children.Add(objLine);
            //</ show in maingrid > 
        }
    }
}
