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

        public Disparo(Point Coordenada)
        {
            this.miCoordenada = Coordenada;
            miTamaño = new Size(20, 30);
        }

        public void Update()
        {
            this.miCoordenada.Y += -12;
            if (this.miCoordenada.Y < -100) 
            {
                saliDelMapaOcolicione = true;
            }
        }



        public void Draw(Graphics Graph)
        {
            Graph.DrawImage(Properties.Resources.Disparo, miCoordenada);
        }
    }
}
