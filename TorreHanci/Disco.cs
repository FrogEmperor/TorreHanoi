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
        private int posX;
        private int posY;
        private SolidColorBrush relleno { get; set; }
        public Disco(int number)
        {
            Random rnd = new Random();
            this.altura = 20;
            this.ancho = 25 * number;
            relleno = new SolidColorBrush(Color.FromRgb((byte)(rnd.Next(256)*number%256), (byte)(rnd.Next(256) * number % 256), (byte)(rnd.Next(256) * number % 256)));
            this.posX = 0;
            this.posY = 0;
        }
        public void Dibujar(Canvas elCanvas,int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            Rectangle disco = new Rectangle();
            Ellipse c = new Ellipse();
            c.Width = altura;
            c.Height = altura;
            c.Fill = relleno;

            Ellipse c2 = new Ellipse();
            c2.Width = altura;
            c2.Height = altura;
            c2.Fill = relleno;
            elCanvas.Children.Add(c);
            elCanvas.Children.Add(c2);

            Canvas.SetLeft(c, this.posX-altura/2);
            Canvas.SetTop(c, this.posY);
            Canvas.SetLeft(c2, this.posX + ancho - altura / 2);
            Canvas.SetTop(c2, this.posY);

            disco.Width = ancho;
            disco.Height = altura;
            disco.Fill = relleno;
            elCanvas.Children.Add(disco);
            Canvas.SetLeft(disco, this.posX);
            Canvas.SetTop(disco, this.posY);
        }
    }
}
