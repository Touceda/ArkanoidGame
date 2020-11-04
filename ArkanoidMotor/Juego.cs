using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidMotor
{
    public class Juego
    { 
        public GameObject[,] NivelJugable;   
        public BarraJugador BarraJugador;
        public List<Pelota> Pelotas = new List<Pelota>();
        public List<PowerUp> PowerUps = new List<PowerUp>();
        public List<Disparo> Disparos = new List<Disparo>();

        private bool derrota = false;
        public bool Derrota { get { return derrota; } set { derrota = value; } }

        private Bitmap[] Imagenes;
        public Juego()
        {
            Imagenes = GenerarImagenes(); //Guardo en un array de Bitmaps Todas las imagenes

            BarraJugador = new BarraJugador(new Point(350, 960), Imagenes, 2);
            Pelotas.Add(new Pelota(new Point(387, 936), Imagenes, 1));

            
            Nivel Nivel = new Nivel(Imagenes);//Creo el nivel
            NivelJugable = Nivel.GenerarNivel(1);//Guardo el nivel generado

            //Extraigo la fila y columna del nivel
            fila = Nivel.fila;
            columna = Nivel.columna;          

            Nivel = null;//Libero el espacio de memoria que ocupa nivel, eliminando su referencia
        }


        private int fila;//Filas del nivel
        private int columna;//Columnas del nivel
  
        public void UpdateAll(Keys tecla) //Actualiza todos los objetos 1 ves
        {
            List<Point> PtsColicionBarras = UpdateBarraPlayer(tecla);

            UpdateColicionPelota();
            UpdatePelota(PtsColicionBarras);
           
            UpdateDisparos();
            UpdatePowerUps(PtsColicionBarras);
        }

        #region Metodos Ejecutados por el UpdateAll (Actualiza objetos)
        private List<Point> UpdateBarraPlayer(Keys tecla)
        {
            //Actualizo la barra del jugador y reviso si cree algun disparo (En el caso de tenel el powerUp Activo)
            BarraJugador.Tecla = tecla;
            this.BarraJugador.Update();//Update de la barra
            List<Point> PtsColicionDeBarra = BarraJugador.CalcularPtsColicion();
            if (BarraJugador.SWdisparo.IsRunning == true && BarraJugador.bala1 != null)
            {
                Disparos.Add(BarraJugador.bala1);
                BarraJugador.bala1 = null;
            }
            return PtsColicionDeBarra;
        }
        private void UpdateColicionPelota()
        {
            //Recorro las pelotas VIVAS y los BLOQUES y miro si colicionaron con los bloques, Despues compruebo si genere un PowerUp
            foreach (var Pelota in Pelotas)
            {  
                UpdatePelotaColicionBloqueABloque(Pelota);
            }
        }

        private Pelota UpdatePelotaColicionBloqueABloque(Pelota Pelota)
        {
            //Recorro todas las barras y si detecto una colicion, guardo un string diciendo que parte de la pelota coliciono
            for (int i = 0; i < fila; i++)
            {
                for (int x = 0; x < columna; x++) 
                {
                    //Aca vei si la barra coliciono con la pelota
                    string anguloDeColicion = NivelJugable[i, x].CalcularColicionPelota(Pelota.pArriba, Pelota.pAbajo, Pelota.pDerecha, Pelota.pIzquierda);
                    if (anguloDeColicion != "")
                    {
                        Pelota.anguloDeColicion = anguloDeColicion;
                        //Miro si se genero un powerUp
                        if (NivelJugable[i, x].generePowerUp != null)
                        {
                            PowerUps.Add(NivelJugable[i, x].generePowerUp);
                        }
                        return Pelota;
                    }
                }
            }
            return Pelota;
        }

        private void UpdatePelota(List<Point> PtsColicionBarras)
        {
            //Actualizo la coordenada de las pelotas y elimino las que murieron
            for (int pelota = 0; pelota < Pelotas.Count; pelota++)//Update de pelotas
            {
                if (Pelotas[pelota].Vidas <= 0)
                {
                    Pelotas.Remove(Pelotas[pelota]);
                }
                else
                {
                    Pelotas[pelota].PtsColicionDeBarra = PtsColicionBarras;
                    Pelotas[pelota].Update();
                }
            }
        }
        private void UpdateDisparos()
        {
            //aca recorro los disparos en busca de coliciones
            foreach (var bala in Disparos)
            {
                for (int i = 0; i < fila; i++)
                {
                    for (int x = 0; x < columna; x++) //Recorro todas las barras y si detecto una colicion, guardo un string diciendo que parte de la pelota coliciono, y luego cierro el metodo con un return (Si coliciona con un objeto, no lo dejo calculando los demas, ya que solo puede colicionar una sola ves)
                    {
                        if (NivelJugable[i, x].CalcularColicionDisparo(new Point(bala.MiCoordenada.X+10,bala.MiCoordenada.Y)) == true)
                        {
                            bala.saliDelMapaOcolicione = true;
                        }
                    }
                }
            }

            //aca recorro las balas Actualizandolas y eliminando las que ya cumplieron su funcion
            for (int disparo = 0; disparo < Disparos.Count; disparo++)
            {
                Disparos[disparo].Update();
                if (Disparos[disparo].saliDelMapaOcolicione == true)
                {
                    Disparos.Remove(Disparos[disparo]);
                }
            }
        }
        private void UpdatePowerUps(List<Point> PtsColicionBarras) 
        {
            //Recorro y actualizo los PowerUps y veo si colicionaron o no con la barra
            for (int powerUp = 0; powerUp < PowerUps.Count; powerUp++)
            {
                if (PowerUps[powerUp].SaliDelMapa)
                {
                    PowerUps.Remove(PowerUps[powerUp]);
                }
                else if (PowerUps[powerUp].UpdatePw(PtsColicionBarras))
                {
                    PowerUps[powerUp].ActivarPowerUp(this);
                    PowerUps.Remove(PowerUps[powerUp]);
                }
            }
        }

        #endregion

        public void DrawAll(Graphics Graph)//Dibuja Todos los objetos 1 ves
        {
            this.BarraJugador.Draw(Graph);

            foreach (var Pelota in Pelotas)
            {
                if (Pelota.Vidas == 1) 
                {
                    Pelota.Draw(Graph);
                }
            }

            for (int i = 0; i < fila; i++)
            {
                for (int x = 0; x < columna; x++)
                {
                    NivelJugable[i, x].Draw(Graph);
                }
            }

            foreach (var powerUp in PowerUps)
            {
                powerUp.DrawPw(Graph);
            }

      
            foreach (var bala in Disparos)
            {
                bala.Draw(Graph);
            }

        }

        public void CondicionDerrota()
        {
            int count = 0; //Contador de pelotas activas
            float vidas;

            foreach (var Pelota in Pelotas)
            {
                if (Pelota.Vidas == 1)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                BarraJugador.Vidas--;
                vidas = BarraJugador.Vidas;
                if (vidas >= 0) 
                {               
                    Pelotas = new List<Pelota>();
                    Pelotas.Add(new Pelota(new Point(387, 936), Imagenes, 1));
                    BarraJugador.MiCoordenada = new Point(350, 960);
                    //perdiUnaVida = true;
                }
                else
                {
                    Derrota = true;
                    //perdiUnaVida = true;
                }               
            }
            else
            {
                return; //No hago nada
            }

        }

        private Bitmap[] GenerarImagenes()
        {
            Bitmap[] Imagenes = new Bitmap[9];
            Imagenes[0] = null;
            Imagenes[1] = new Bitmap(Properties.Resources.Barra1);
            Imagenes[2] = new Bitmap(Properties.Resources.Barra2);
            Imagenes[3] = new Bitmap(Properties.Resources.Barra3);
            Imagenes[4] = new Bitmap(Properties.Resources.Barra4);
            Imagenes[5] = new Bitmap(Properties.Resources.Barra5);
            Imagenes[6] = new Bitmap(Properties.Resources.BarraIndestructible);
            Imagenes[7] = new Bitmap(Properties.Resources.pelota);
            Imagenes[8] = new Bitmap(Properties.Resources.BarraPlayer);

            return Imagenes;
        }
        public void EventPause(Graphics dibujarPausa)
        {
            dibujarPausa.DrawImage(Properties.Resources.Pausa, new RectangleF(75, 300, 650, 325));
        }
    }
}
