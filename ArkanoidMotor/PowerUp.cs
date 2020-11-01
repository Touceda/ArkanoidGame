using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidMotor
{
    public class PowerUp
    {
        private int nroDePowerUp;
        public int NroDePowerUp { get { return nroDePowerUp; } }

        private Bitmap miImagen;
        public Bitmap MiImagen { get { return miImagen; } set { miImagen = value; } }

        private Point miCoordenada;
        public Point MiCoordenada { get { return miCoordenada; } set { miCoordenada = value; } }

        private Size miTamaño;
        public Size MiTamaño { get { return miTamaño; } }

        public PowerUp(Point point,int nroPowerUp)
        {
            this.miCoordenada = point;
            this.nroDePowerUp = nroPowerUp;
            this.miTamaño = new Size(60, 20);

            switch (nroDePowerUp)
            {
                case 1: { this.miImagen = Properties.Resources.PildoraVida; break; }
                case 2: { this.miImagen = Properties.Resources.PildoraMiltiBola; break; }
                case 3: { this.miImagen = Properties.Resources.PildoraInmortal; break; }

                default:
                    break;
            }  
        }

        public void UpdatePw() 
        {
        
        }
        public void DrawPw(Graphics graphics)
        {
            graphics.DrawImage(this.miImagen, new RectangleF(this.miCoordenada, this.miTamaño));
        }


        public void ActivarPowerUp(int poder)
        {
            switch (poder)
            {
                case 1: { PwExtraLife(); break; }
                case 2: { PwMultiplicarPelotas(); break; }
                case 3: { PwInmortabilidad(); break; }
                default:
                    break;
            }
        }
        public void PwExtraLife()
        { 
        
        }

        public void PwMultiplicarPelotas()
        {

        }

        public void PwInmortabilidad()
        {

        }
    }
}
