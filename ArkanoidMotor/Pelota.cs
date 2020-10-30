using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
            this.MiTamaño = new Size(25, 25);

            if (rnd.Next(0, 2) == 1) 
            {
                MovHorizontalX = rnd.Next(6, 9);           
            }
            else
            {
                MovHorizontalX = rnd.Next(-9, -6);
            }
            
            MovVerticalY = rnd.Next(-9, -6);

            
        }

        public Point pArriba;
        public Point pAbajo;
        public Point pDerecha;
        public Point pIzquierda;
        int MovHorizontalX;
        int MovVerticalY; //Si es positivo se mueve hacia abajo (Esta al reves)
        public override void Update()
        {
            CalcularPuntos();
            CalcularColicionConObjetos();
            CalcularColicionConParedes();
            Mover();
        }

        private void CalcularPuntos() //Calculo los 4 puntos de la pelota para luego ver si coliciona con algo
        {
            Point Actual = new Point(int.Parse(MiCoordenada.X.ToString()), int.Parse(MiCoordenada.Y.ToString())); //Copio mi coordenada actual en un nuevo punto

            pArriba = new Point(Actual.X, Actual.Y - 25);
            pAbajo = new Point(Actual.X, Actual.Y + 25);

            pDerecha = new Point(Actual.X + 25, Actual.Y);
            pIzquierda = new Point(Actual.X - 25, Actual.Y);
        }

        public string anguloDeColicion="";
        private void CalcularColicionConObjetos()
        {
            switch (anguloDeColicion)
            {
                case "Arriba": { MovVerticalY = rnd.Next(3, 9); break; }
                case "Arbajo": { MovVerticalY = rnd.Next(-9, -6); break; }
                case "Derecha": { MovHorizontalX = rnd.Next(-9, -6); break; }
                case "Izquierda": { MovHorizontalX = rnd.Next(6, 9); break; }
                default:
                    break;
            }
            anguloDeColicion = "";
        }




        Random rnd = new Random();
        private void CalcularColicionConParedes()
        {
            if (pArriba.Y <= 0)
            {
                MovVerticalY = rnd.Next(6,9);
            }

            if (pAbajo.Y >= 1000)
            {
                
                MovVerticalY = rnd.Next(-9, -6);
            }

            if (pDerecha.X >= 780)
            {
                MovHorizontalX = rnd.Next(-9, -6);
            }

            if (pIzquierda.X<=-5)
            {
                MovHorizontalX = rnd.Next(6, 9);
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
