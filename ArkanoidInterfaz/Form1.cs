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
        Juego Juego;

        private void Form1_Load(object sender, EventArgs e)
        {
            Juego = new Juego();
            ActualizarGame.Interval = 16;
            ActualizarGame.Enabled = true;

            //Configuracion para que se dibuje bien
            SetStyle(ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.UserPaint
                 | ControlStyles.AllPaintingInWmPaint,
                 true);
            //lastStep = Environment.TickCount; 
            
        }
        
        Bitmap Fondo = new Bitmap(Properties.Resources.ArkanoidFondo);
        RectangleF FondoTamaño = new RectangleF(0, 0, 800, 1000);
        Graphics Graph;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graph = e.Graphics;
            Graph.DrawImage(Fondo, FondoTamaño);
            Juego.DrawAll(Graph);
            if (pausa)
            {
                Juego.EventPause(Graph);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.X + " " + e.Y;
        }
        //private float lastStep = -1;
        private Keys tecla;
        private void ActualizarGame_Tick(object sender, EventArgs e)
        {
            if (pausa)
            {
                Refresh();             
            }
            else
            {
                if (Juego.Derrota == false)
                {
                    Juego.UpdateAll(tecla);//Actualizo el juego         
                    Refresh();//Una ves Actualizado lo mando a dibujar
                    Juego.CondicionDerrota();
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
    }
}
