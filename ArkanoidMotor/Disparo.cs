using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace ArkanoidMotor
{
    public class Disparo
    {

        private Bitmap miImagen;
        public Bitmap MiImagen { get { return miImagen; } set { miImagen = value; } }

        private Point miCoordenada;
        public Point MiCoordenada { get { return miCoordenada; } set { miCoordenada = value; } }

        private Size miTamaño;
        public Size MiTamaño { get { return miTamaño; } }

        public bool saliDelMapaOcolicione = false;

        public Point Pcolicion1;
        public Point Pcolicion2;
        public Point Pcolicion3;
        public Disparo(Point Coordenada)
        {
            this.miCoordenada = Coordenada;
            miTamaño = new Size(20, 30);
        }

        public void Update()
        {
            this.miCoordenada.Y += -12;
            Pcolicion1 = MiCoordenada;
            Pcolicion2 = new Point(MiCoordenada.X + 8, MiCoordenada.Y);
            Pcolicion3 = new Point(MiCoordenada.X + 16, MiCoordenada.Y);

            if (this.miCoordenada.Y < -100)
            {
                 saliDelMapaOcolicione = true;
            }
        }

        internal bool CalcularColicion(List<Point> pListColicion, int vidas)
        {
            foreach (var point in pListColicion)
            {
                if (point == Pcolicion1|| point == Pcolicion2 || point == Pcolicion3)
                {
                    if (vidas == 6)
                    {
                        this.saliDelMapaOcolicione = true;
                        return false;
                    }
                    this.saliDelMapaOcolicione = true;
                    return true;
                }
            }

            return false;
        }

        public void Draw(Graphics Graph)
        {
            Graph.DrawImage(Properties.Resources.Disparo, miCoordenada);
            Graph.DrawEllipse(Pens.Red, new RectangleF(Pcolicion1, new Size(3, 3)));
            Graph.DrawEllipse(Pens.Red, new RectangleF(Pcolicion2, new Size(3, 3)));
            Graph.DrawEllipse(Pens.Red, new RectangleF(Pcolicion3, new Size(3, 3)));
        }
    }
}
