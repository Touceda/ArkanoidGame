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
        Juego Juego = new Juego();
        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics Graph = e.Graphics;
            var nivel = Juego.Nivel.NivelUno;


            for (int fila = 0; fila < Nivel.GetLength(0); fila++)
            {
                for (int columna = 0; columna < Nivel.GetLength(1); columna++)
                {
                    
                }
            }





        }


        void DrawOn(Graphics grap, Nivel lvl)
        {


        }

     
    }
}
