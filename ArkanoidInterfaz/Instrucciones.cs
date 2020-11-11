using ArkanoidMotor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidInterfaz
{
    public partial class Instrucciones : Form
    {
        public Instrucciones()
        {
            InitializeComponent();
        }

        private void Instrucciones_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Juego";
            lblIntro.Text = "Bienvenido al Arkanoid";
            lbl1.Text = "Controles: Se utilisa wasd o las flechitas para el movimiento, ";
            lblp.Text = "el Space para disparar y la P para pausar";
            lbl2.Text = "Hay 4 PowerUps";
            lbl3.Text = "V++: Vida extra (El maximo de vidas seran 6)";
            lbl4.Text = "Multibola: Se despliegan 4 bolas";
            lbl5.Text = "Inmortal: Efecto de 15sec donde la bola es inmortal";
            lbl6.Text = "Disparo: Tiempo en el que se puede disparar con el Space";
        }
        private void btbSiguiente_Click(object sender, EventArgs e)
        {
            PasarInstrucciones();
        }

        private void PasarInstrucciones()
        {
            this.Close();
        }

    }
}
