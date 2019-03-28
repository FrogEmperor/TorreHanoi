using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TorreHanci
{
    class Juego
    {
        private Torre[] torres;
        private List<int[]> orden;
        private int indexDonde;
        public Juego(Canvas canvasTorres)
        {
            this.orden = new List<int[]>();
            int indexDonde = 0;
            this.torres = new Torre[3];
            Torre t1 = new Torre((int)(canvasTorres.Width / 8), 100);
            torres[0] = t1;
            Torre t2 = new Torre((int)canvasTorres.Width / 2, 100);
            torres[1] = t2;
            Torre t3 = new Torre((int)canvasTorres.Width * 7 / 8, 100);
            torres[2] = t3;
            foreach (Torre t in torres)
            {
                t.Dibuja(canvasTorres);
            }
            for (int i = 1; i <= 3; i++)
            {
                Disco d = new Disco(i);
                torres[0].discos.Insert(0, d);
            }
            torres[0].DibujaDiscos(canvasTorres);
            TorreHanoi(3, 0, 1, 2);
        }
        public void Next(Canvas canvasTorres)
        {
            if (indexDonde < orden.Count)
            {
                torres[orden[indexDonde][1]].discos.Add(torres[orden[indexDonde][0]].discos[torres[orden[indexDonde][0]].discos.Count - 1]);
                torres[orden[indexDonde][0]].discos.RemoveAt(torres[orden[indexDonde][0]].discos.Count - 1);
                canvasTorres.Children.Clear();
                foreach (Torre t in torres)
                {
                    t.Dibuja(canvasTorres);
                    t.DibujaDiscos(canvasTorres);
                }
                indexDonde++;
            }
        }
        public void Reset(int discos, Canvas canvasTorres)
        {
            orden.Clear();
            indexDonde = 0;
            TorreHanoi(discos, 0, 1, 2);
            canvasTorres.Children.Clear();
            foreach (Torre t in torres)
            {
                t.discos.Clear();
                t.Dibuja(canvasTorres);
            }
            for (int i = 1; i <= discos; i++)
            {
                Disco d = new Disco(i);
                torres[0].discos.Insert(0, d);
            }
            torres[0].DibujaDiscos(canvasTorres);
        }
        public void Reversa(Canvas canvasTorres)
        {
            if (indexDonde <= orden.Count && indexDonde >0)
            {
                indexDonde--;
                torres[orden[indexDonde][0]].discos.Add(torres[orden[indexDonde][1]].discos[torres[orden[indexDonde][1]].discos.Count - 1]);
                torres[orden[indexDonde][1]].discos.RemoveAt(torres[orden[indexDonde][1]].discos.Count - 1);
                canvasTorres.Children.Clear();
                foreach (Torre t in torres)
                {
                    t.Dibuja(canvasTorres);
                    t.DibujaDiscos(canvasTorres);
                }
            }
        }
        public void TorreHanoi(int quienSoy, int dondeEstoy, int vacio, int dondeVoy)
        {
            if (quienSoy > 1)
            {
                TorreHanoi(quienSoy - 1, dondeEstoy, dondeVoy, vacio);
            }
            int[] x = { dondeEstoy, dondeVoy };
            this.orden.Add(x);
            if (quienSoy > 1)
            {
                TorreHanoi(quienSoy - 1, vacio, dondeEstoy, dondeVoy);
            }
        }
    }
}
