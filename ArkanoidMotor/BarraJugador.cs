using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidMotor
{
    public class BarraJugador : GameObject
    {
        private Bitmap MiImagenConPowerUp;

        private bool powerUp = false;
        public bool PowerUp { get { return powerUp; } set { powerUp = value; } }

        public BarraJugador(Point point, Bitmap[] imagen = null, int vida = 0)
        : base(point, imagen, vida)
        {
            this.MiCoordenada = point;
            this.MiImagen = imagen;
            this.MiImagenConPowerUp = Properties.Resources.BarraPlayerConPowerUp;
            this.Vidas = 2;
            this.MiTamaño = new Size(100,20);
            this.ImagenVidas = Properties.Resources.PlayerVida;
        }

        private Keys tecla;
        public Keys Tecla { get { return tecla; } set { tecla = value; }}
        public override void Update()
        {
            var coordenada = MiCoordenada;
            if (tecla == Keys.D || tecla == Keys.Right)
            {
                if (coordenada.X <= 675)
                {
                    coordenada.X += 10;
                }

            }

            if (tecla == Keys.A || tecla == Keys.Left)
            {

                if (coordenada.X >= 25)
                {
                    coordenada.X -= 10;
                }
            }

            this.MiCoordenada = coordenada;
        }

        Bitmap ImagenVidas;
        public override void Draw(Graphics Graph)
        {
            int dist = 1000;
            for (int i = 0; i < Vidas; i++)
            {
                dist -= 80;
                Graph.DrawImage(ImagenVidas, new RectangleF(new PointF(0, dist), new SizeF(17, 80)));
            }

            if (PowerUp == true)
            {
                Graph.DrawImage(MiImagenConPowerUp, new RectangleF(MiCoordenada,MiTamaño));
            }
            else
            {
                Graph.DrawImage(MiImagen[8], new RectangleF(MiCoordenada, MiTamaño));
            }
        }
        public List<Point> CalcularPtsColicion()
        {
            Point coordenada = MiCoordenada; //Es de 17 - 80 el tamaño
            List<Point> Puntos = new List<Point>();          

            for (int x = 0; x <= 80; x++)
            {
                for (int y = 0; y <= 17; y++)
                {
                    Puntos.Add(new Point(coordenada.X + x, coordenada.Y + y));
                }
            }
            return Puntos;
        }
    }
}
