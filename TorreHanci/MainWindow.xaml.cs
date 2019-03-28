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
        Juego juego;
        public MainWindow()
        {
            InitializeComponent();
            //TorreHanci(5, 1, 2, 3);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            juego = new Juego(canvasTorres);
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            juego.Reset(int.Parse(MiComboBox.Text),canvasTorres);
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            juego.Next(canvasTorres);
        }

        private void btnLastMove_Click(object sender, RoutedEventArgs e)
        {
            juego.Reversa(canvasTorres);
        }
        private void MiComboBox_DropDownClosed(object sender, EventArgs e)
        {
            juego.Reset(int.Parse(MiComboBox.Text), canvasTorres);
        }
    }
}
