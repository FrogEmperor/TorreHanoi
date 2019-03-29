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
using System.Windows.Threading;

namespace TorreHanci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Juego juego;
        DispatcherTimer elTimer;
        public MainWindow()
        {
            InitializeComponent();
            elTimer = new DispatcherTimer();
            elTimer.Interval = TimeSpan.FromMilliseconds(500);
            elTimer.Tick += NextAutomatico;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            juego = new Juego(canvasTorres);
            lblMoves.Content = "Numero de movimientos: " + juego.Moves();
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            juego.Reset(int.Parse(MiComboBox.Text), canvasTorres);
            elTimer.Stop();
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                juego.Next(canvasTorres);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            elTimer.Stop();
        }
        private void btnLastMove_Click(object sender, RoutedEventArgs e)
        {
            juego.Reversa(canvasTorres);
            elTimer.Stop();
        }
        private void MiComboBox_DropDownClosed(object sender, EventArgs e)
        {
            juego.Reset(int.Parse(MiComboBox.Text), canvasTorres);
            lblMoves.Content = "Numero de movimientos: " + juego.Moves();
            elTimer.Stop();
        }
        private void NextAutomatico(object sender, EventArgs e)
        {
            try
            {
                juego.Next(canvasTorres);
            }
            catch 
            {
                elTimer.Stop();
            }
        }
        private void btnAutomatico_Click(object sender, RoutedEventArgs e)
        {
            elTimer.Start();
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            elTimer.Stop();
        }
    }
}
