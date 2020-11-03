using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidMotor
{
    public class Pelota : GameObject
    {
        public Pelota(Point point, Bitmap[] imagen = null, int vida = 0)
       :base(point, imagen, vida)
        {
            this.MiCoordenada = point;
            this.MiImagen = imagen;
            this.Vidas = vida;
            this.MiTamaño = new Size(26, 26);

            if (rnd.Next(0, 2) == 1) 
            {
                MovHorizontalX = rnd.Next(8, 11);           
            }
            else
            {
                MovHorizontalX = rnd.Next(-11, -8);
            }
            
            MovVerticalY = rnd.Next(-11, -8);      
        }

        public Point pArriba;
        public Point pAbajo;
        public Point pDerecha;
        public Point pIzquierda;
        private int MovHorizontalX;
        private int MovVerticalY; //Si es positivo se mueve hacia abajo (Esta al reves)
        public int movX { get{ return MovHorizontalX; }set { MovHorizontalX = value; } }
        public int movY { get { return MovVerticalY; } set { MovVerticalY = value; } }

        public override void Update()
        {
            CalcularPuntos();
            CalcularColicionConObjetos();
            CalcularColicionConParedes();
            CalcularColicionConBarra();
            Mover();
        }

        private void CalcularPuntos() //Calculo los 4 puntos de la pelota para luego ver si coliciona con algo
        {
            Point Actual = new Point(int.Parse(MiCoordenada.X.ToString()), int.Parse(MiCoordenada.Y.ToString())); //Copio mi coordenada actual en un nuevo punto

            pArriba = new Point(Actual.X, Actual.Y - 13);
            pAbajo = new Point(Actual.X, Actual.Y + 13);

            pDerecha = new Point(Actual.X + 13, Actual.Y);
            pIzquierda = new Point(Actual.X - 13, Actual.Y);
        }

        public string anguloDeColicion="";
        private void CalcularColicionConObjetos()
        {
            switch (anguloDeColicion)
            {
                case "Arriba": { MovVerticalY = rnd.Next(8, 11); break; }
                case "Arbajo": { MovVerticalY = rnd.Next(-11, -8); break; }
                case "Derecha": { MovHorizontalX = rnd.Next(-11, -8); break; }
                case "Izquierda": { MovHorizontalX = rnd.Next(8, 11); break; }
                default:
                    break;
            }
            anguloDeColicion = "";
        }

        Random rnd = new Random();
        public Stopwatch SW = new Stopwatch();
        public void IniciarSW()
        {
            SW.Restart();
        }
        private void CalcularColicionConParedes()
        {
            if (pArriba.Y <= 0)
            {
                MovVerticalY = rnd.Next(8,11);
            }     

            if (pDerecha.X >= 770)
            {
                MovHorizontalX = rnd.Next(-11, -8);
            }

            if (pIzquierda.X <= 0) 
            {
                MovHorizontalX = rnd.Next(8, 11);
            }

            if (pAbajo.Y >= 1000)
            {
                if (SW.IsRunning == true)
                {
                    if (SW.ElapsedMilliseconds < 20000)
                    {
                        MovVerticalY = rnd.Next(-11, 8);
                    }
                    else
                    {
                        SW.Stop();
                        Vidas = 0;
                    }
                    return;
                }
                Vidas = 0;
            }  
        }

        public List<Point> PtsColicionDeBarra;
        private void CalcularColicionConBarra()
        {
            foreach (var point in PtsColicionDeBarra)
            {

                if (pAbajo == point)
                {
                    MovVerticalY = rnd.Next(-11, -8);
                }
                else if (pDerecha == point)
                {
                    MovHorizontalX = rnd.Next(-11, -8);
                    MovVerticalY = rnd.Next(-11, -8);
                }
                else if (pIzquierda == point)
                {
                    MovHorizontalX = rnd.Next(8, 12);
                    MovVerticalY = rnd.Next(-11, -8);
                }
            }
        }

        private void Mover()
        {
            MiCoordenada = new Point(MiCoordenada.X + MovHorizontalX, MiCoordenada.Y + MovVerticalY);
        }

        public override void Draw(Graphics Graph)
        {
            Graph.DrawImage(MiImagen[7], new RectangleF(MiCoordenada, MiTamaño));
        }
        
    }
}
