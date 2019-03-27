﻿using System;
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
        public int posX { get; set; }
        public int posY { get; set; }
        public int discos { get; set; }
        public Torre(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
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
        }
    }
}
