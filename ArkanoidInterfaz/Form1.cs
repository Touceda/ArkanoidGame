using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArkanoidMotor;


namespace ArkanoidInterfaz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Jugador Player;
        Juego Juego;

        private void Form1_Load(object sender, EventArgs e)
        {
            Juego = new Juego(Player);
            ActualizarGame.Interval = 16;
            ActualizarGame.Enabled = true;

            //Configuracion para que se dibuje bien
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.UserPaint
                 | ControlStyles.AllPaintingInWmPaint,
                 true);
            
        }
        
        Bitmap Fondo = new Bitmap(Properties.Resources.ArkanoidFondo);
        RectangleF FondoTamaño = new RectangleF(0, 0, 800, 1000);
        Graphics Graph;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.DrawString("Puntuacion: " + Juego.Puntuacion, new Font("Arial", 20), new SolidBrush(Color.Black), 820, 20);
            Graph = e.Graphics;
            Graph.DrawImage(Fondo, FondoTamaño);
            Juego.DrawAll(Graph);
            if (pausa)
            {
                Juego.EventPause(Graph);
            }
        }
 
        private Keys tecla;
        private void ActualizarGame_Tick(object sender, EventArgs e)
        {
            if (pausa)
            {
                Refresh();             
            }
            else
            {
                if (Juego.Derrota == false && Juego.Victoria == false && Juego.finDelJuego == false)
                {
                    Juego.UpdateAll(tecla);//Actualizo el juego         
                    Refresh();//Una ves Actualizado lo mando a dibujar
                    Juego.CondicionVictoria();
                    Juego.CondicionDerrota();
                }
                else
                {
                    Player = Juego.Player;
                    if (Juego.Derrota == true)
                    {
                        Player.Stats.PartidasJugadas++;
                        Player.Stats.Derrotas++;
                        Player.Stats.NivelesPerdidos++;
                        Player.NivelActual = 1;
                        Player.Puntuacion = 0;
                        Player.ActualizarCuentaStats();
                        this.Close();
                    }

                    if (Juego.Victoria == true)
                    {
                        Player.Stats.NivelesCompletos++;
                        Player.ActualizarCuentaStats();
                        Juego = new Juego(Player);
                    }

                    if (Juego.finDelJuego == true)
                    {                                       
                        Player.Stats.PartidasJugadas++;
                        Player.Stats.NivelesCompletos++;
                        Player.Stats.Victorias++;
                        Player.NivelActual = 1;
                        Player.Puntuacion = 0;
                        Player.ActualizarCuentaStats();
                        this.Close();
                    }
                }
            }
        }

        private bool pausa = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            tecla = e.KeyCode;

            if (tecla == Keys.P)
            {
                pausa = !pausa;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            tecla = Keys.N;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.X + " " + e.Y;
        }
    }
}
