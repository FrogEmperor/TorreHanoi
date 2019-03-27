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
        Torre[] torres;
        List<int[]> orden;
        int indexDonde = 0;
        public MainWindow()
        {
            InitializeComponent();
            orden = new List<int[]>();
            //TorreHanci(5, 1, 2, 3);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            torres = new Torre[3];
            Torre t1 = new Torre((int)(canvasTorres.Width / 4), 100);
            torres[0] = t1;
            Torre t2 = new Torre((int)canvasTorres.Width / 2, 100);
            torres[1] = t2;
            Torre t3 = new Torre((int)canvasTorres.Width * 3 / 4, 100);
            torres[2] = t3;
            foreach (Torre t in torres)
            {
                t.Dibuja(canvasTorres);
            }
            for (int i = 1; i<=3;i++)
            {
                Disco d = new Disco(i);
                torres[0].discos.Insert(0,d);
            }
            torres[0].DibujaDiscos(canvasTorres);
        }
        public void TorreHanoi(int quienSoy, int dondeEstoy, int vacio, int dondeVoy)
        {
            if (quienSoy > 1)
            {
                TorreHanoi(quienSoy - 1, dondeEstoy, dondeVoy, vacio);
            }
            int[] x = { dondeEstoy, dondeVoy };
            orden.Add(x);
            if (quienSoy > 1)
            {
                TorreHanoi(quienSoy - 1, vacio, dondeEstoy, dondeVoy);
            }
        }
        private void Animate_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }
        private void MiComboBox_DropDownClosed(object sender, EventArgs e)
        {
            reset();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (indexDonde<orden.Count) {
                torres[orden[indexDonde][1]].discos.Add(torres[orden[indexDonde][0]].discos[torres[orden[indexDonde][0]].discos.Count - 1]);
                torres[orden[indexDonde][0]].discos.RemoveAt(torres[orden[indexDonde][0]].discos.Count - 1);
                canvasTorres.Children.Clear();
                foreach (Torre t in torres)
                {
                    t.Dibuja(canvasTorres);
                }
                torres[0].DibujaDiscos(canvasTorres);
                torres[1].DibujaDiscos(canvasTorres);
                torres[2].DibujaDiscos(canvasTorres);
                indexDonde++;
            }
        }
        public void reset()
        {
            orden.Clear();
            indexDonde = 0;
            TorreHanoi(int.Parse(MiComboBox.Text), 0, 1, 2);
            canvasTorres.Children.Clear();
            torres[0].discos.Clear();
            torres[1].discos.Clear();
            torres[2].discos.Clear();
            foreach (Torre t in torres)
            {
                t.Dibuja(canvasTorres);
            }
            for (int i = 1; i <= int.Parse(MiComboBox.Text); i++)
            {
                Disco d = new Disco(i);
                torres[0].discos.Insert(0, d);
            }
            torres[0].DibujaDiscos(canvasTorres);
        }
    }
}
