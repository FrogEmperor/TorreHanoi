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
    class Torre
    {
        private int posX { get; set; }
        private int posY { get; set; }
        private int posXdiscos { get; set; }
        private int posYdiscos { get; set; }
        public List<Disco> discos { get; set; }
        public Torre(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            discos = new List<Disco>();
        }
        public void Dibuja(Canvas elCanvas)
        {
            Rectangle r1 = new Rectangle();
            r1.Fill = Brushes.Brown;
            r1.Height = elCanvas.ActualHeight / 2;
            r1.Width = elCanvas.ActualWidth / 40;

            Rectangle r2 = new Rectangle();
            r2.Fill = Brushes.Brown;
            r2.Height = elCanvas.ActualHeight / 20;
            r2.Width = elCanvas.ActualWidth / 4;

            elCanvas.Children.Add(r1);
            elCanvas.Children.Add(r2);
            Canvas.SetLeft(r1, posX);
            Canvas.SetTop(r1, posY);
            Canvas.SetLeft(r2, posX - (r2.Width / 2 - r1.Width / 2));
            Canvas.SetTop(r2, posY + (r1.Height - r2.Height));

            posYdiscos = (int)(posY + (r1.Height - r2.Height));
            posXdiscos = (int)(r1.Width / 2);
        }
        public void DibujaDiscos(Canvas elCanvas)
        {
            int posY = posYdiscos;
            foreach (Disco i in discos)
            {
                posY -= (int)i.altura;
                i.Dibujar(elCanvas,(int)(posX-(i.ancho/2-posXdiscos)),posY);
            }
        }
    }
}
