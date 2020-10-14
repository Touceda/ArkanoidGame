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
            ActualizarGame.Enabled = true;
            lastStep = Environment.TickCount;         
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics Graph = e.Graphics;
            Bitmap b = new Bitmap(Properties.Resources.ArkanoidFondo);
            Graph.DrawImage(b, new Rectangle(0, 0, 800,1000));
            Juego.DrawAll(Graph);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.X + " " + e.Y;
        }
        private float lastStep = -1;
        private void ActualizarGame_Tick(object sender, EventArgs e)
        {
            float now = Environment.TickCount;
            float delta = (now -lastStep) / 1000;
            if (delta > 0)
            {

                Juego.UpdateAll();//Actualizo el juego 
                lastStep = now;
                Refresh();//Una ves Actualizado lo mando a dibujar
            }
                
        }

       

    }
}
