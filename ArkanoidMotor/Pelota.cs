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
                MovHorizontalX = rnd.Next(7, 10);           
            }
            else
            {
                MovHorizontalX = rnd.Next(-10, -7);
            }
            
            MovVerticalY = rnd.Next(-10, -7);

            CalcularPuntos();
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
            CalcularPuntos();
        }

        private void CalcularPuntos() //Calculo los 4 puntos de la pelota para luego ver si coliciona con algo
        {
            Point Actual = MiCoordenada; //Copio mi coordenada actual en un nuevo punto

            pArriba = new Point(Actual.X + 13, Actual.Y);
            pAbajo = new Point(Actual.X + 13, Actual.Y + 26);

            pDerecha = new Point(Actual.X + 26, Actual.Y + 13);
            pIzquierda = new Point(Actual.X, Actual.Y + 13);
        }

        public string anguloDeColicion="";
        private void CalcularColicionConObjetos()
        {
            switch (anguloDeColicion)
            {
                case "Arriba": { MovVerticalY = rnd.Next(7, 10); break; }
                case "Abajo": { MovVerticalY = rnd.Next(-10, -7); break; }
                case "Derecha": { MovHorizontalX = rnd.Next(-10, -7); break; }
                case "Izquierda": { MovHorizontalX = rnd.Next(7, 10); break; }
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
            if (pArriba.Y <= 24)
            {
                MovVerticalY = rnd.Next(7,10);
            }     

            if (pDerecha.X >= 783)
            {
                MovHorizontalX = rnd.Next(-10, -7);
            }

            if (pIzquierda.X <= 18) 
            {
                MovHorizontalX = rnd.Next(7, 10);
            }

            if (pAbajo.Y >= 1000)
            {
                if (SW.IsRunning == true)
                {
                    if (SW.ElapsedMilliseconds < 20000)
                    {
                        MovVerticalY = rnd.Next(-10, 7);
                    }
                    else
                    {
                        SW.Stop();
                        Vidas = 0;
                    }
                    return;
                }
                if (pAbajo.Y >= 1100) 
                {
                    Vidas = 0;
                }
            }  
        }

        public List<Point> PtsColicionDeBarra;
        private void CalcularColicionConBarra()
        {
            foreach (var point in PtsColicionDeBarra)
            {

                if (pAbajo == point)
                {
                    MovVerticalY = rnd.Next(-10, -7);
                }
                else if (pDerecha == point)
                {
                    MovHorizontalX = rnd.Next(-10, -7);
                    MovVerticalY = rnd.Next(-10, -7);
                }
                else if (pIzquierda == point)
                {
                    MovHorizontalX = rnd.Next(7, 10);
                    MovVerticalY = rnd.Next(-10, -7);
                }
            }
        }

        private void Mover()
        {
            var coordenada = MiCoordenada;
            coordenada.X += movX;
            coordenada.Y += movY;
            MiCoordenada = coordenada;
        }

        public override void Draw(Graphics Graph)
        {
            Graph.DrawImage(MiImagen[7], new RectangleF(MiCoordenada, MiTamaño));
            //GraficarHitbox(Graph);
        }
        private void GraficarHitbox(Graphics Graph)
        {
            Graph.DrawEllipse(Pens.Red,new RectangleF(pArriba,new Size(3,3)));
            Graph.DrawEllipse(Pens.Red, new RectangleF(pAbajo, new Size(3, 3)));
            Graph.DrawEllipse(Pens.Red, new RectangleF(pDerecha,new Size(3, 3)));
            Graph.DrawEllipse(Pens.Red, new RectangleF(pIzquierda,new Size(3, 3)));
        }
    }
}
