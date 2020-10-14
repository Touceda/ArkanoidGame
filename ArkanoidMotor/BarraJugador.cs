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
        private bool PowerUp = false;
        public BarraJugador(PointF point, Bitmap imagen = null, int vida = 0)
        : base(point, imagen, vida)
        {
            this.MiCoordenada = point;
            this.MiImagen = imagen;
            this.MiImagenConPowerUp = Properties.Resources.BarraPlayerConPowerUp;
            this.Vidas = 2;
            this.MiTamaño = new SizeF(100,20);
        }

        private HashSet<Keys> pressedKeys = new HashSet<Keys>();
        public override void Update()
        {
            var coordenada = MiCoordenada;
            if (pressedKeys.Contains(Keys.Left) || pressedKeys.Contains(Keys.A))
            {
                if (coordenada.X <= 720)
                {
                    coordenada.X += 100;
                }
               
            }

            if (pressedKeys.Contains(Keys.Right) || pressedKeys.Contains(Keys.D)) 
            {
                if (coordenada.X >= 80)
                {
                    coordenada.X -= 100;
                }
            }

            this.MiCoordenada = coordenada;
        }

        public override void Draw(Graphics Graph)
        {
            if (PowerUp == true)
            {
                Graph.DrawImage(MiImagenConPowerUp, new RectangleF(MiCoordenada,MiTamaño));
            }
            else
            {
                Graph.DrawImage(MiImagen, new RectangleF(MiCoordenada, MiTamaño));
            }
        }

    }
}
