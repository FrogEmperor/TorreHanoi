using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TorreHanci
{
    class Disco
    {
        public int altura { get; }
        public int ancho { get; set; }
        private SolidColorBrush relleno { get; set; }
        public Disco(int number)
        {
            Random rnd = new Random();
            this.altura = 5 + 5 * number;
            this.ancho = 30 * number;
            relleno = new SolidColorBrush(Color.FromRgb((byte)(rnd.Next(256)*number%256), (byte)(rnd.Next(256) * number % 256), (byte)(rnd.Next(256) * number % 256)));
        }
        public void Dibujar(Canvas elCanvas,int posX, int posY)
        {
            Rectangle disco = new Rectangle();
            disco.Width = ancho;
            disco.Height = altura;
            disco.Fill = relleno;
            elCanvas.Children.Add(disco);
            Canvas.SetLeft(disco, posX);
            Canvas.SetTop(disco, posY);
        }
    }
}
