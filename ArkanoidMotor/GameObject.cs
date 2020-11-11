using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidMotor
{
    public class GameObject
    {
        private int vidas;
        public int Vidas { get { return vidas; } set { vidas = value; } }

        private Bitmap[] miImagen;
        public Bitmap[] MiImagen { get { return miImagen; } set { miImagen = value; } }

        private Point miCoordenada;
        public Point MiCoordenada { get { return miCoordenada; } set { miCoordenada = value; }}

        private Size miTamaño;
        public Size MiTamaño { get { return miTamaño; } set { miTamaño = value; }}


        public GameObject(Point point, Bitmap[] imagen = null, int vida = 0, int tamañoLargo = 0, int probabilidadPowerUp = 0)
        {
            miCoordenada = point;
            this.MiImagen = imagen;
            this.vidas = vida;
            this.ProbabilidadPowerUp = probabilidadPowerUp;
            this.miTamaño = new Size(tamañoLargo,32);

            if (vida != 0) 
            {
                PtosDeColicion = CalcularPtsColicion(tamañoLargo);
            }  
        }

        internal List<Point> PtosDeColicion;
       
        internal string CalcularColicionPelota(Point pArriba, Point pAbajo, Point pDerecha, Point pIzquierda)
        {
            if (PtosDeColicion == null)
            {
                return "";
            }

            foreach (var point in PtosDeColicion)
            {

                if (pAbajo == point)
                {
                    Update();
                    return "Abajo";
                }

                if (pArriba == point)
                {
                    Update();
                    return "Arriba";
                }                           
                
                if (pDerecha == point)
                {
                    Update();
                    return "Derecha";
                }
                
                if (pIzquierda == point)
                {
                    Update();
                    return "Izquierda";
                }
            }

            return "";
        }

        int count = 0;
        Stopwatch SW = new Stopwatch();
        internal PowerUp generePowerUp;
        internal int ProbabilidadPowerUp;
        public virtual void Update()
        {
            if (SW.ElapsedMilliseconds > 100) //Sistema para que no desintegre el bloque al chocar con la pelota
            {
                count = 0;
            }

            if (count == 0)
            {
                if (vidas == 6)
                {

                }
                else
                {
                    count++;
                    vidas += -1;
                    SW.Restart();
                }
            }
       
            if (vidas <= 0)  
            {
                PtosDeColicion = null;
                Random rnd = new Random();

                //int probabilidad = rnd.Next(0, 100);
                //if (probabilidad <= ProbabilidadPowerUp)
                //{
                //    int pildora = rnd.Next(1, 5);
                //    this.generePowerUp = new PowerUp(this.MiCoordenada, pildora);
                //}

                int probabilidad = rnd.Next(0, 100);
                if (probabilidad <= ProbabilidadPowerUp)
                {
                    
                    this.generePowerUp = new PowerUp(this.MiCoordenada, 4);
                }

            }
        }
        public virtual void Draw(Graphics Graph)
        {
            if (vidas > 0) 
            {
                Graph.DrawImage(this.MiImagen[vidas], new RectangleF(MiCoordenada, MiTamaño));//Le puedo pasar el wh y he para ajustar el tamaño (Revisar para futuros niveles)
            }     
        }


        internal List<Point> CalcularPtsColicion(int tamañoLargo)
        {
            Point coordenada = MiCoordenada;

            List<Point> Puntos = new List<Point>();
            for (int x = 0; x <= tamañoLargo; x++)
            {
                for (int y = 0; y <= 33; y++)
                {
                    Puntos.Add(new Point(coordenada.X + x, coordenada.Y + y));
                }
            }
            return Puntos;
        }
    }
}
