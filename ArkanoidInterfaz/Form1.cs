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


            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics Graph = e.Graphics;
            Bitmap b = new Bitmap(Properties.Resources.ArkanoidFondo);
            Graph.DrawImage(b, new Rectangle(0, 0, 800,1000));
            Juego.DrawAll(Graph);




        }



     
    }
}
