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

namespace TorreHanci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TorreHanci(5, 1, 2, 3);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Torre t = new Torre(200, 10);
            t.Dibuja(canvasTorres);
        }
        public void TorreHanci(int quienSoy, int dondeEstoy, int vacio, int dondeVoy)
        {
            if (quienSoy > 1)
            {
                TorreHanci(quienSoy-1, dondeEstoy, dondeVoy, vacio);
            }
            Console.WriteLine($"Circulo {quienSoy}: ME MOVI DE {dondeEstoy} A {dondeVoy}");
            if (quienSoy > 1)
            {
                TorreHanci(quienSoy - 1, vacio, dondeEstoy, dondeVoy);
            }
        }
    }
}
