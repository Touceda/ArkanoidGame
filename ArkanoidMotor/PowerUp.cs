using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

        private bool saliDelMapa = false;
        public bool SaliDelMapa { get { return saliDelMapa; } }
        public PowerUp(Point point,int nroPowerUp)
        {
            this.miCoordenada = point;
            this.nroDePowerUp = nroPowerUp;
            this.miTamaño = new Size(60, 20);

            CalcularPts();

            switch (nroDePowerUp)
            {
                case 1: { this.miImagen = Properties.Resources.PildoraVida; break; }
                case 2: { this.miImagen = Properties.Resources.PildoraMiltiBola; break; }
                case 3: { this.miImagen = Properties.Resources.PildoraInmortal; break; }
                case 4: { this.miImagen = Properties.Resources.PildoraDisparo; break; }

                default:
                    break;
            }  
        }

        public Point Pabajo;
        public Point Pderecha;
        public Point Pizquierda;

        public bool UpdatePw(List<Point> PtsColicionBarra)
        {
            this.miCoordenada.Y += 15;
            CalcularPts();

            if (this.miCoordenada.Y >= 1100)
            {
                this.saliDelMapa = true;
            }

            if (Pabajo.Y >= 955) //960 es la altura donde se encuentra la barra
            {
                return CalcularColicionConPowerUp(PtsColicionBarra);
            }
            return false;
        }
        public void DrawPw(Graphics graphics)
        {
            graphics.DrawImage(this.miImagen, new RectangleF(this.miCoordenada, this.miTamaño));
        }

        private void CalcularPts()
        {
            Pabajo = new Point(MiCoordenada.X, MiCoordenada.Y + 10);
            Pderecha = new Point(MiCoordenada.X + 30, MiCoordenada.Y);
            Pizquierda = new Point(MiCoordenada.X - 30, MiCoordenada.Y);
        }

        private bool CalcularColicionConPowerUp(List<Point> PtsColicionBarra)
        {
            foreach (var punto in PtsColicionBarra)
            {
                if (Pabajo == punto)
                {
                    return true;
                }
                else if (Pderecha == punto)
                {
                    return true;
                }
                else if (Pizquierda == punto)
                {
                    return true;
                }
            }
            return false;
        }

        public void ActivarPowerUp(Juego juego)
        {
            switch (nroDePowerUp)
            {
                case 1: { PwExtraLife(juego); break; }
                case 2: { PwMultiplicarPelotas(juego); break; }
                case 3: { PwInmortabilidad(juego); break; }
                case 4: { PwDisparar(juego); break; }
                default:
                    break;
            }
        }
        public void PwExtraLife(Juego juego)
        {
            if (juego.BarraJugador.Vidas < 5) 
            {
                juego.BarraJugador.Vidas += 1;
            }
        }

        public void PwMultiplicarPelotas(Juego juego)
        {
            Random rnd = new Random();
            Point coordenada = juego.Pelotas[0].MiCoordenada;
            var imagen = juego.Pelotas[0].MiImagen;
            juego.Pelotas[0].movX = rnd.Next(8, 11);
            juego.Pelotas[0].movY = rnd.Next(8, 11);

            Pelota p1 = new Pelota(coordenada, imagen, 1);
            p1.movX = rnd.Next(8, 11);
            p1.movY = rnd.Next(-11, -8);
            juego.Pelotas.Add(p1);

            Pelota p2 = new Pelota(coordenada, imagen, 1);
            p2.movX = rnd.Next(-11, -8);
            p2.movY = rnd.Next(8, 11);
            juego.Pelotas.Add(p2);

            Pelota p3 = new Pelota(coordenada, imagen, 1);
            p3.movX = rnd.Next(-11, -8);
            p3.movY = rnd.Next(-11, -8);
            juego.Pelotas.Add(p3);
        }

        public void PwInmortabilidad(Juego juego)
        {
            juego.BarraJugador.IniciarSW(1);
            for (int pelota = 0; pelota < juego.Pelotas.Count; pelota++)
            {
                juego.Pelotas[pelota].IniciarSW();
            }
        }

        public void PwDisparar(Juego juego)
        {
            juego.BarraJugador.IniciarSW(2);  
        }
    }
}
