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
        public Jugador Player;
        public GameObject[,] NivelJugable;   
        public BarraJugador BarraJugador;
        public List<Pelota> Pelotas = new List<Pelota>();
        public List<PowerUp> PowerUps = new List<PowerUp>();
        public List<Disparo> Disparos = new List<Disparo>();
        public int Puntuacion;
        public Stopwatch SW = new Stopwatch();


        private bool derrota = false;
        public bool Derrota { get { return derrota; } set { derrota = value; } }

        private bool victoria = false;
        public bool Victoria { get { return victoria; } set { victoria = value; } }

        public bool finDelJuego = false;
        public bool FinDelJuego { get { return finDelJuego; } set { finDelJuego = value; } }

        private Bitmap[] Imagenes;
        public Juego(Jugador PL)
        {
            SW.Start();

            this.Player = PL;
            this.Puntuacion = Player.Puntuacion;

            Imagenes = GenerarImagenes(); //Guardo en un array de Bitmaps Todas las imagenes

            BarraJugador = new BarraJugador(new Point(350, 960), Imagenes, 2);
            Pelotas.Add(new Pelota(new Point(387, 936), Imagenes, 1));

            
            Nivel Nivel = new Nivel(Imagenes);//Creo el nivel
            NivelJugable = Nivel.GenerarNivel(this.Player.NivelActual);//Guardo el nivel generado

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

        private void UpdatePelotaColicionBloqueABloque(Pelota Pelota)
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
                        CalcularPts(NivelJugable[i, x].Vidas);//Sumo los pts    
                        
                        Pelota.anguloDeColicion = anguloDeColicion;//Ajusto de que forma reacciona la pelota
                        
                        if (NivelJugable[i, x].generePowerUp != null)//Miro si se genero un powerUp
                        {
                            PowerUps.Add(NivelJugable[i, x].generePowerUp);
                        }

                        return;
                    }
                }
            }
        }

        private void CalcularPts(int vidas)//La puntuacion Cambia segun el tipo de bloque
        {
            switch (vidas)
            {
                case 0: { Puntuacion += 600; break; }
                case 1: { Puntuacion += 125; break; }
                case 2: { Puntuacion += 350; break; }
                case 3: { Puntuacion += 222; break; }
                case 4: { Puntuacion += 100; break; }
                case 6: { Puntuacion += 50; break; }
                default:
                    break;
            }
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

                        if (NivelJugable[i, x].PtosDeColicion != null)//Primero veo si el objeto existe o ya fue destruido
                        {
                            if (bala.CalcularColicion(NivelJugable[i, x].PtosDeColicion, NivelJugable[i, x].Vidas) == true)//Calculo la colicion si es true
                            {
                                NivelJugable[i, x].Vidas += -1;//Le saco una vida
                                if (NivelJugable[i, x].Vidas <= 0) //Si se quedo sin vidas, elimino sus ptosdecolicion (asi pasa a estar muerto)
                                {
                                    NivelJugable[i, x].PtosDeColicion = null;
                                }
                            }
                            
                        }
                        
                    }
                }
            }

            List<Disparo> disparosVivos = new List<Disparo>();
            foreach (var bala in Disparos) //aca recorro las balas y me quedo con las que sig vivas
            {
                if (bala.saliDelMapaOcolicione == false)
                {
                    disparosVivos.Add(bala);
                }
            }

            this.Disparos = disparosVivos;

            foreach (var bala in Disparos)//Actualizo los disparos
            {
                bala.Update();
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
        private void UpdatePlayerStats()
        {
            Player.Puntuacion = this.Puntuacion; //La puntuacion actual del jugador es la de la run
            if (Player.Puntuacion > Player.Stats.MaximaPuntuacion)//Si los pts de la run superan al record, actualizo los stats
            {
                Player.Stats.MaximaPuntuacion = Player.Puntuacion;
            }

            if (SW.IsRunning == false)//Si se paro el cronometro, es porque el lvl termino, asi que actualizo el tiempo jugado
            {
                Player.Stats.CalcularTiempoJugado(SW);
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
            int pCount = 0; //Contador de pelotas activas
            float vidas;

            foreach (var Pelota in Pelotas)//Recorro la pelota en busca de alguna viva
            {
                if (Pelota.Vidas == 1)
                {
                    pCount++;
                }
            }

            if (pCount == 0)//Si no tengo vidas
            {
                BarraJugador.Vidas--;
                vidas = BarraJugador.Vidas;
                if (vidas >= 0) 
                {               
                    Pelotas = new List<Pelota>();
                    Pelotas.Add(new Pelota(new Point(387, 936), Imagenes, 1));
                    BarraJugador.MiCoordenada = new Point(350, 960);
                }
                else
                {
                    SW.Stop();
                    UpdatePlayerStats();
                    Player.Stats.CalcularTiempoJugado(SW);
                    this.Derrota = true;
                }               
            }
        }
        public void CondicionVictoria()
        {
            int bCount = 0;//Contador de bloques vivos

            foreach (var bloque in NivelJugable)
            {
                if (bloque.Vidas != 0 && bloque.Vidas != 6) //Si los bloques son 0 o 6, no cuentan como vivos
                {
                    if (bloque.Vidas < 0)//Si es menor a 0 esta muerto, pero si no cCount++
                    {

                    }
                    else
                    {
                        bCount++;
                    }
                }
            }
        

            if (bCount == 0)//Si no se encontraron bloques vivos
            {
                Puntuacion += 3000 * (BarraJugador.Vidas + 1); //Añado Pts Segun mis vidas
                Player.NivelActual += 1;
                if (Player.NivelActual >= 11)
                {
                    SW.Stop();
                    UpdatePlayerStats();
                    this.FinDelJuego = true;
                }
                else
                {
                    SW.Stop();
                    UpdatePlayerStats();                   
                    this.Victoria = true;
                }
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
